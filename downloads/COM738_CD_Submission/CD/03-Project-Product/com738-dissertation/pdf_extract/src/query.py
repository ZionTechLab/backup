"""
COM738 — RAG Query Pipeline
Phase 3: embed query → retrieve top-k chunks → prompt DeepSeek → Sinhala answer.
"""

import json
import os
from pathlib import Path
from sentence_transformers import SentenceTransformer
import chromadb
from openai import OpenAI

CHROMA_PATH = Path(__file__).resolve().parent.parent / "data" / "chroma_db"
E5_MODEL = "intfloat/multilingual-e5-large"

# Load from .env (project root, one level up)
def _load_env():
    env_paths = [
        Path(__file__).resolve().parent.parent / ".env",   # project root
        Path(__file__).resolve().parent / ".env",           # pdf_extract/
    ]
    for env_path in env_paths:
        if env_path.exists():
            for line in env_path.read_text().strip().split("\n"):
                if "=" in line and not line.startswith("#"):
                    k, v = line.split("=", 1)
                    os.environ.setdefault(k.strip(), v.strip())
            break  # use first found

_load_env()
LLM_BASE_URL = os.environ.get("LLM_BASE_URL", "http://localhost:20128/v1")
LLM_API_KEY = os.environ.get("LLM_API_KEY", "")
LLM_MODEL = os.environ.get("LLM_MODEL", "cmc/deepseek/deepseek-v4-pro")

COLLECTION_NAMES = [
    "syllabus_section_e5",
    "syllabus_sliding_e5",
    "pastpaper_question_e5",
    "syllabus_paragraph_e5",
]

PROMPT_TEMPLATE = """පහත දක්වා ඇති තොරතුරු පමණක් භාවිතා කර ප්‍රශ්නයට පිළිතුරු දෙන්න. 
තොරතුරු වල නොමැති දේවල් අනුමාන නොකරන්න.

තොරතුරු:
{context}

ප්‍රශ්නය: {question}

පිළිතුර:"""


def load_models():
    """Load embedding model + LLM client."""
    print("📦 Loading embedding model...")
    embed_model = SentenceTransformer(E5_MODEL, device="cpu")
    llm = OpenAI(base_url=LLM_BASE_URL, api_key=LLM_API_KEY)
    chroma = chromadb.PersistentClient(path=str(CHROMA_PATH))
    return embed_model, llm, chroma


def retrieve(embed_model, chroma, question: str, top_k: int = 5) -> list[dict]:
    """Embed query, search all collections, return top-k chunks."""
    query_embedding = embed_model.encode(
        [f"query: {question}"],
        normalize_embeddings=True,
    )

    all_results = []

    for coll_name in COLLECTION_NAMES:
        try:
            coll = chroma.get_collection(coll_name)
            results = coll.query(
                query_embeddings=query_embedding.tolist(),
                n_results=top_k,
            )
            for i, doc in enumerate(results["documents"][0]):
                dist = results["distances"][0][i]
                all_results.append({
                    "collection": coll_name,
                    "distance": dist,
                    "text": doc,
                })
        except Exception:
            continue

    # Sort by distance (lower = better for cosine)
    all_results.sort(key=lambda r: r["distance"])
    return all_results[:top_k]


def generate(llm, question: str, chunks: list[dict]) -> str:
    """Build prompt with retrieved chunks, send to LLM."""
    if not chunks:
        return "කණගාටුයි, අදාළ තොරතුරු කිසිවක් සොයාගත නොහැකි විය."

    context = "\n\n".join(
        c['text'][:800]
        for c in chunks
    )

    prompt = f"""Context:
{context}

Question: {question}

Answer in Sinhala:"""

    response = llm.chat.completions.create(
        model=LLM_MODEL,
        messages=[{"role": "user", "content": prompt}],
        temperature=0.2,
        max_tokens=800,
    )

    content = response.choices[0].message.content
    if content is None:
        return ""
    return content.strip()


def baseline_ungrounded(llm, question: str) -> str:
    """Baseline A: Ask LLM directly with no prompt, no context, no constraints."""
    response = llm.chat.completions.create(
        model=LLM_MODEL,
        messages=[{"role": "user", "content": question}],
        temperature=0.2,
        max_tokens=800,
    )
    content = response.choices[0].message.content
    return content.strip() if content else ""


def baseline_constrained(llm, question: str) -> str:
    """Baseline B: Sinhala role prompt WITHOUT retrieved context."""
    prompt = (
        "ඔබ ශ්‍රී ලංකාවේ අ.පො.ස. (සාමාන්‍ය පෙළ) ව්‍යාපාර සහ ගිණුම්කරණ අධ්‍යයන විෂය සඳහා "
        "සහායකයෙකි. විෂය නිර්දේශයට අනුකූලව, ශ්‍රී ලංකා අධ්‍යාපන සන්දර්භය තුළ "
        "පිළිතුරු සපයන්න. ඔබට විශ්වාස නැති තොරතුරු සඳහන් නොකරන්න.\n\n"
        f"ප්‍රශ්නය: {question}\nපිළිතුර:"
    )
    response = llm.chat.completions.create(
        model=LLM_MODEL,
        messages=[{"role": "user", "content": prompt}],
        temperature=0.2,
        max_tokens=800,
    )
    content = response.choices[0].message.content
    return content.strip() if content else ""


def query(embed_model, llm, chroma, question: str, top_k: int = 5, verbose: bool = True):
    """Full RAG pipeline: embed → retrieve → generate. Models passed in, not reloaded."""
    if verbose:
        print(f"\n❓ {question}\n")

    chunks = retrieve(embed_model, chroma, question, top_k)

    if verbose:
        print(f"📚 Top {len(chunks)} chunks:")
        for i, c in enumerate(chunks):
            print(f"   [{i + 1}] {c['collection']} dist={c['distance']:.4f}")
            print(f"       {c['text'][:120]}...\n")

    answer = generate(llm, question, chunks)

    if not answer or not answer.strip():
        answer = "⚠️  LLM returned empty response. Try again."

    if verbose:
        print(f"🤖 පිළිතුර:\n{answer}\n")
        print("─" * 60)

    return answer, chunks


def main():
    import sys

    # Default test questions
    questions = [
        "ව්‍යාපාර සංවිධාන වර්ග මොනවාද?",
        "ගිණුම්කරණ සමීකරණය යනු කුමක්ද?",
        "බැංකු සැසඳීම් ප්‍රකාශනය පිළියෙල කරන්නේ කෙසේද?",
        "සුළු මුදල් පොත යනු කුමක්ද?",
        "ලෙජරයක් යනු කුමක්ද?",
    ]

    # If user provides a question, use that
    if len(sys.argv) > 1 and not sys.argv[1].startswith("--"):
        questions = [" ".join(sys.argv[1:])]

    top_k = 5
    if "--top" in sys.argv:
        idx = sys.argv.index("--top")
        top_k = int(sys.argv[idx + 1])

    # Load once
    embed_model, llm, chroma = load_models()

    mode = "rag"
    if "--baseline-a" in sys.argv:
        mode = "baseline-a"
    elif "--baseline-b" in sys.argv:
        mode = "baseline-b"
    elif "--all" in sys.argv:
        mode = "all"

    for q in questions:
        print(f"\n❓ {q}\n")

        if mode in ("rag", "all"):
            answer, _ = query(embed_model, llm, chroma, q, top_k, verbose=False)
            print(f"   📚 RAG: {answer[:150]}...")
        if mode in ("baseline-a", "all"):
            a = baseline_ungrounded(llm, q)
            print(f"   🎯 Ungrounded: {a[:150]}...")
        if mode in ("baseline-b", "all"):
            a = baseline_constrained(llm, q)
            print(f"   🔒 Constrained: {a[:150]}...")

        print()


if __name__ == "__main__":
    main()
