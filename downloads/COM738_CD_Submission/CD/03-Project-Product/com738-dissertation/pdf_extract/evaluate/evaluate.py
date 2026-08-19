"""
COM738 — Phase 5: Automated Evaluation (Cosine Similarity) with Checkpointing
Incremental question-by-question processing with JSON state saving.
"""

import json
import os
from pathlib import Path
import numpy as np
from sentence_transformers import SentenceTransformer
import chromadb
from openai import OpenAI
from scipy.stats import wilcoxon

# ─── CONFIG ──────────────────────────────────────────────
CHROMA_PATH = Path(__file__).resolve().parent.parent / "data" / "chroma_db"
E5_MODEL = "intfloat/multilingual-e5-large"
RESULTS_PATH = Path(__file__).resolve().parent / "eval_results_checkpoint.json"

def _load_env():
    env_paths = [
        Path(__file__).resolve().parent.parent.parent / ".env",
        Path(__file__).resolve().parent.parent / ".env",
    ]
    for env_path in env_paths:
        if env_path.exists():
            for line in env_path.read_text().strip().split("\n"):
                if "=" in line and not line.startswith("#"):
                    k, v = line.split("=", 1)
                    os.environ.setdefault(k.strip(), v.strip())
            break

_load_env()
LLM_BASE_URL = os.environ.get("LLM_BASE_URL", "http://localhost:20128/v1")
LLM_API_KEY = os.environ.get("LLM_API_KEY", "")
LLM_MODEL = os.environ.get("LLM_MODEL", "cmc/deepseek/deepseek-v4-pro")

COLLECTION_NAMES = [
    "syllabus_paragraph_e5",
    "pastpaper_question_e5",
    "syllabus_sliding_e5",
]

# ─── EVALUATION SET ──────────────────────────────────────
_EVAL_PATH = Path(__file__).resolve().parent / "eval_questions.json"
if _EVAL_PATH.exists():
    _raw = json.loads(_EVAL_PATH.read_text(encoding="utf-8"))
    EVAL_SET = [{"id": i, "question": q["question"], "reference": q["reference"]} for i, q in enumerate(_raw)]
    print(f"✅ Loaded {len(EVAL_SET)} evaluation questions from eval_questions.json")
else:
    _EVAL_PATH_PARENT = Path(__file__).resolve().parent.parent / "eval_questions.json"
    if _EVAL_PATH_PARENT.exists():
        _raw = json.loads(_EVAL_PATH_PARENT.read_text(encoding="utf-8"))
        EVAL_SET = [{"id": i, "question": q["question"], "reference": q["reference"]} for i, q in enumerate(_raw)]
        print(f"✅ Loaded {len(EVAL_SET)} evaluation questions from parent eval_questions.json")
    else:
        EVAL_SET = [
            {"id": 0, "question": "ව්‍යාපාර සංවිධාන වර්ග මොනවාද?", "reference": "තනි පුද්ගල ව්‍යාපාර, හවුල් ව්‍යාපාර, සංස්ථාපිත සමාගම්, සමුපකාර, සමිති, රාජ්‍ය සංස්ථා හා දෙපාර්තමේන්තු"},
        ]
        print(f"⚠️  eval_questions.json not found — using {len(EVAL_SET)} fallback question(s)")


# ─── GLOBAL STATE ─────────────────────────────────────────
embed_model = None
llm_client = None
chroma = None

def init():
    global embed_model, llm_client, chroma
    if embed_model is None:
        print("📦 Loading models and initializing clients...")
        embed_model = SentenceTransformer(E5_MODEL, device="cpu")
        llm_client = OpenAI(base_url=LLM_BASE_URL, api_key=LLM_API_KEY)
        chroma = chromadb.PersistentClient(path=str(CHROMA_PATH))


# ─── RETRIEVE & GENERATE ──────────────────────────────────
def retrieve(question: str, top_k: int = 3) -> list[str]:
    q_emb = embed_model.encode([f"query: {question}"], normalize_embeddings=True)
    all_results = []
    for cname in COLLECTION_NAMES:
        try:
            coll = chroma.get_collection(cname)
            r = coll.query(query_embeddings=q_emb.tolist(), n_results=top_k)
            for d in r["documents"][0]:
                all_results.append(d)
        except Exception:
            continue
    return all_results[:top_k]


def generate_rag(question: str, contexts: list[str]) -> str:
    ctx = "\n\n".join(c[:800] for c in contexts)
    prompt = f"""Context:
{ctx}

Question: {question}

Answer in Sinhala:"""
    try:
        r = llm_client.chat.completions.create(
            model=LLM_MODEL, messages=[{"role":"user","content":prompt}],
            temperature=0.2, max_tokens=600,
        )
        return r.choices[0].message.content.strip() if r.choices[0].message.content else ""
    except Exception as e:
        print(f"⚠️ LLM Error (RAG): {e}")
        return ""


def generate_baseline_a(question: str) -> str:
    try:
        r = llm_client.chat.completions.create(
            model=LLM_MODEL, messages=[{"role":"user","content":question}],
            temperature=0.2, max_tokens=600,
        )
        return r.choices[0].message.content.strip() if r.choices[0].message.content else ""
    except Exception as e:
        print(f"⚠️ LLM Error (Baseline A): {e}")
        return ""


def generate_baseline_b(question: str) -> str:
    prompt = f"""ඔබ ශ්‍රී ලංකාවේ අ.පො.ස. (සාමාන්‍ය පෙළ) ව්‍යාපාර සහ ගිණුම්කරණ අධ්‍යයන විෂය සඳහා සහායකයෙකි.

ප්‍රශ්නය: {question}
පිළිතුර:"""
    try:
        r = llm_client.chat.completions.create(
            model=LLM_MODEL, messages=[{"role":"user","content":prompt}],
            temperature=0.2, max_tokens=600,
        )
        return r.choices[0].message.content.strip() if r.choices[0].message.content else ""
    except Exception as e:
        print(f"⚠️ LLM Error (Baseline B): {e}")
        return ""


# ─── METRICS ──────────────────────────────────────────────
def cosine_sim(a: str, b: str) -> float:
    if not a or not b:
        return 0.0
    emb = embed_model.encode([a, b], normalize_embeddings=True)
    return float(np.dot(emb[0], emb[1]))


def evaluate_single(item: dict) -> dict:
    q = item["question"]
    ref = item["reference"]

    # 1. Retrieve
    contexts = retrieve(q, top_k=3)

    # 2. Generate
    ans_rag = generate_rag(q, contexts)
    ans_bA = generate_baseline_a(q)
    ans_bB = generate_baseline_b(q)

    # 3. Score via Embedding Cosine Similarity against Reference
    score_rag = cosine_sim(ans_rag, ref)
    score_bA = cosine_sim(ans_bA, ref)
    score_bB = cosine_sim(ans_bB, ref)

    # Faithfulness (RAG answer vs retrieved contexts)
    ctx_text = " ".join(contexts)
    faithfulness = cosine_sim(ans_rag, ctx_text) if ctx_text else 0.0

    return {
        "id": item["id"],
        "question": q,
        "reference": ref,
        "rag_answer": ans_rag,
        "baseline_a_answer": ans_bA,
        "baseline_b_answer": ans_bB,
        "score_rag": score_rag,
        "score_baseline_a": score_bA,
        "score_baseline_b": score_bB,
        "faithfulness": faithfulness,
        "contexts_retrieved": len(contexts)
    }


# ─── MAIN EXECUTION & CHECKPOINTING ───────────────────────
def main():
    init()

    # Load existing checkpoint results if any
    results = []
    completed_ids = set()
    if RESULTS_PATH.exists():
        try:
            results = json.loads(RESULTS_PATH.read_text(encoding="utf-8"))
            completed_ids = {r["id"] for r in results}
            print(f"📂 Loaded checkpoint: {len(completed_ids)} questions already evaluated.")
        except Exception as e:
            print(f"⚠️ Could not load checkpoint: {e}")

    print(f"\n🚀 Starting Evaluation Pipeline ({len(EVAL_SET)} total questions)...")
    
    for idx, item in enumerate(EVAL_SET):
        qid = item["id"]
        if qid in completed_ids:
            continue

        print(f"\n[{idx+1}/{len(EVAL_SET)}] Evaluating Q{qid}: {item['question']}")
        res = evaluate_single(item)
        results.append(res)
        
        # Save checkpoint immediately
        RESULTS_PATH.write_text(json.dumps(results, ensure_ascii=False, indent=2), encoding="utf-8")
        print(f"   ↳ RAG Score: {res['score_rag']:.4f} | Baseline A: {res['score_baseline_a']:.4f} | Faithfulness: {res['faithfulness']:.4f}")

    print("\n✅ All questions evaluated! Generating Combined Summary Report...")

    # Combine & Compute Statistics
    rag_scores = [r["score_rag"] for r in results]
    b_a_scores = [r["score_baseline_a"] for r in results]
    b_b_scores = [r["score_baseline_b"] for r in results]
    faithfulness_scores = [r["faithfulness"] for r in results]

    mean_rag = np.mean(rag_scores) if rag_scores else 0
    mean_ba = np.mean(b_a_scores) if b_a_scores else 0
    mean_bb = np.mean(b_b_scores) if b_b_scores else 0
    mean_faith = np.mean(faithfulness_scores) if faithfulness_scores else 0

    # Wilcoxon signed-rank test (RAG vs Baseline A)
    try:
        stat, p_value = wilcoxon(rag_scores, b_a_scores)
    except Exception:
        stat, p_value = 0.0, 1.0

    summary = {
        "total_evaluated": len(results),
        "mean_score_rag": float(mean_rag),
        "mean_score_baseline_a": float(mean_ba),
        "mean_score_baseline_b": float(mean_bb),
        "mean_faithfulness": float(mean_faith),
        "wilcoxon_stat": float(stat),
        "wilcoxon_p_value": float(p_value)
    }

    summary_path = Path(__file__).resolve().parent / "eval_summary_report.json"
    summary_path.write_text(json.dumps(summary, indent=2), encoding="utf-8")

    print("\n" + "="*50)
    print("📊 FINAL EVALUATION SUMMARY REPORT")
    print("="*50)
    print(json.dumps(summary, indent=2))
    print("="*50)
    print(f"📁 Results saved to: {RESULTS_PATH}")
    print(f"📁 Summary saved to: {summary_path}")

if __name__ == "__main__":
    main()
