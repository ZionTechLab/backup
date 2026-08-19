"""
COM738 — Embed + Index: Load knowledge base, generate embeddings, store in ChromaDB.
Models: multilingual-E5-large (primary) + BGE-M3 (comparison).
"""

import json
import time
from pathlib import Path
from sentence_transformers import SentenceTransformer
import chromadb

KB_PATH = Path(__file__).resolve().parent / "data" / "chunked" / "knowledge_base.json"
CHROMA_PATH = Path(__file__).resolve().parent.parent / "data" / "chroma_db"
PROCESSED_DIR = Path(__file__).resolve().parent.parent / "data" / "processed"
CHUNKED_DIR = Path(__file__).resolve().parent.parent / "data" / "chunked"
E5_MODEL = "intfloat/multilingual-e5-large"
BGE_MODEL = "BAAI/bge-m3"

# Strategy → collection name mapping
COLLECTIONS = {
    "paragraph":         ("syllabus_paragraph", "Grade 10 Syllabus — per-row paragraph chunks"),
    "semantic-section":  ("syllabus_section",   "Grade 10 Syllabus — curriculum topic sections"),
    "semantic-question": ("pastpaper_question", "2019 O/L Past Paper — question boundaries"),
    "500-char-sliding":  ("syllabus_sliding",   "Grade 10 Syllabus — 800-char sliding windows"),
}


def load_passages() -> list[dict]:
    with open(KB_PATH, encoding="utf-8") as f:
        return json.load(f)


def embed_and_index(model_name: str, model_label: str):
    """Load model, embed all passages, store in ChromaDB collections."""
    print(f"\n{'='*60}")
    print(f"📦 Loading model: {model_name}")
    print(f"{'='*60}")

    t0 = time.time()
    model = SentenceTransformer(model_name, device="cpu")
    print(f"   Loaded in {time.time() - t0:.1f}s")

    passages = load_passages()
    print(f"   {len(passages)} passages from {KB_PATH}")

    # Group passages by strategy
    by_strategy = {}
    for p in passages:
        s = p["chunk_strategy"]
        by_strategy.setdefault(s, []).append(p)

    client = chromadb.PersistentClient(path=str(CHROMA_PATH))

    for strategy, collection_name in COLLECTIONS.items():
        chunks = by_strategy.get(strategy, [])
        if not chunks:
            print(f"   ⏭  {strategy}: no chunks, skipping")
            continue

        name = f"{collection_name[0]}_{model_label}"
        desc = collection_name[1]

        # Delete existing collection so we get a clean rebuild
        try:
            client.delete_collection(name)
        except Exception:
            pass

        collection = client.create_collection(
            name=name,
            metadata={
                "hnsw:space": "cosine",
                "model": model_name,
                "strategy": strategy,
                "language": "si",
            }
        )

        texts = []
        ids = []
        metadatas = []

        for p in chunks:
            # E5 convention: prefix passages with "passage: "
            if "e5" in model_name.lower():
                embedding_text = f"passage: {p['text']}"
            else:
                embedding_text = p["text"]

            texts.append(embedding_text)
            ids.append(p["id"])
            metadatas.append({
                "source": p["source"],
                "topic": p.get("topic", ""),
                "char_count": p["char_count"],
            })

        print(f"   🧠 {strategy} ({name}): embedding {len(texts)} chunks...")
        t1 = time.time()

        # Batch encode
        embeddings = model.encode(
            texts,
            batch_size=16,
            show_progress_bar=False,
            normalize_embeddings=True,
        )

        # Add to collection in batches
        batch_size = 50
        for i in range(0, len(texts), batch_size):
            end = min(i + batch_size, len(texts))
            collection.add(
                ids=ids[i:end],
                embeddings=embeddings[i:end].tolist(),
                documents=[p["text"] for p in chunks[i:end]],
                metadatas=metadatas[i:end],
            )

        elapsed = time.time() - t1
        print(f"      ✅ {len(texts)} chunks in {elapsed:.1f}s ({len(texts)/elapsed:.0f} chunks/s)")

    print(f"\n   Total time: {time.time() - t0:.1f}s")


def test_retrieval(model_label: str = "e5", top_k: int = 5):
    """Quick sanity check: ask Sinhala questions, see what chunks come back."""
    model_name = E5_MODEL if model_label == "e5" else BGE_MODEL
    model = SentenceTransformer(model_name, device="cpu")
    client = chromadb.PersistentClient(path=str(CHROMA_PATH))

    questions = [
        "ව්‍යාපාර සංවිධාන වර්ග මොනවාද?",
        "ගිණුම්කරණ සමීකරණය යනු කුමක්ද?",
        "බැංකු සැසඳීම් ප්‍රකාශනය පිළියෙල කරන්නේ කෙසේද?",
        "සුළු මුදල් පොත යනු කුමක්ද?",
        "ව්‍යාපාර පරිසරයට බලපාන සාධක මොනවාද?",
        "ලෙජරයක් යනු කුමක්ද?",
        "ව්‍යාපාරයක ඇල්මැති පාර්ශ්ව නම් කරන්න",
        "ශේෂ පිරික්සුමක් යනු කුමක්ද?",
        "තනි පුද්ගල ව්‍යාපාරයක වාසි මොනවාද?",
        "මුදල් වට්ටම් යනු කුමක්ද?",
    ]

    print(f"\n{'='*60}")
    print(f"🔍 Retrieval Test — {model_label.upper()} | top-{top_k}")
    print(f"{'='*60}")

    for q in questions:
        print(f"\n❓ {q}")

        # E5 query prefix
        if model_label == "e5":
            query_text = f"query: {q}"
        else:
            query_text = q

        q_embedding = model.encode([query_text], normalize_embeddings=True)

        # Search all collections
        found_any = False
        for _, (coll_name, _) in COLLECTIONS.items():
            name = f"{coll_name}_{model_label}"
            try:
                coll = client.get_collection(name)
                results = coll.query(query_embeddings=q_embedding.tolist(), n_results=top_k)
                distances = results.get("distances", [[]])[0]

                if distances and distances[0] < 1.5:  # reasonable match
                    found_any = True
                    doc = results["documents"][0][0]
                    print(f"   [{coll_name}] dist={distances[0]:.3f} → {doc[:100]}...")
            except Exception:
                continue

        if not found_any:
            print(f"   ⚠️  No strong matches")


def main():
    import sys
    test_only = "--test" in sys.argv
    model_choice = "e5"
    if "--bge" in sys.argv:
        model_choice = "bge"

    if test_only:
        test_retrieval(model_choice)
    else:
        # Full pipeline: embed both models
        embed_and_index(E5_MODEL, "e5")
        embed_and_index(BGE_MODEL, "bge")
        # Quick sanity test
        test_retrieval("e5")


if __name__ == "__main__":
    main()
