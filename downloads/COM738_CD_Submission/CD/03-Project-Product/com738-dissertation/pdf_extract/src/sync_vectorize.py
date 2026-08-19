"""
COM738 — Direct Cloudflare Vectorize Sync Script
Converts local chunks (knowledge_base.json), generates BGE-M3/E5 embeddings, 
and directly inserts/upserts them into Cloudflare Vectorize via Wrangler API.
"""

import os
import json
from pathlib import Path
import subprocess
from sentence_transformers import SentenceTransformer

KB_PATH = Path(__file__).resolve().parent.parent / "data" / "chunked" / "knowledge_base.json"
OUTPUT_NDJSON = Path(__file__).resolve().parent.parent.parent.parent / "com738-rag-app" / "worker" / "vectors.ndjson"
E5_MODEL = "intfloat/multilingual-e5-large"

def main():
    if not KB_PATH.exists():
        print(f"❌ Knowledge base not found at {KB_PATH}")
        return

    print(f"📂 Loading chunks from {KB_PATH}...")
    chunks = json.loads(KB_PATH.read_text(encoding="utf-8"))
    print(f"✅ Loaded {len(chunks)} chunks.")

    print(f"📦 Loading embedding model ({E5_MODEL})...")
    model = SentenceTransformer(E5_MODEL, device="cpu")

    print("🔄 Generating embeddings and formatting to NDJSON for Cloudflare Vectorize...")
    ndjson_lines = []
    
    # Take first 50 or all chunks
    for idx, chunk in enumerate(chunks):
        text = chunk.get("text", "")
        if not text.strip():
            continue
            
        # Generate embedding (1024 dimensions for e5-large)
        embedding = model.encode([f"passage: {text}"], normalize_embeddings=True)[0].tolist()
        
        record = {
            "id": chunk.get("id", f"chunk-{idx}"),
            "values": embedding,
            "metadata": {
                "text": text[:1000],  # Cloudflare metadata size limits
                "source": chunk.get("source", "textbook"),
                "chunkStrategy": chunk.get("chunk_strategy", "paragraph")
            }
        }
        ndjson_lines.append(json.dumps(record, ensure_ascii=False))

    OUTPUT_NDJSON.parent.mkdir(parents=True, exist_ok=True)
    OUTPUT_NDJSON.write_text("\n".join(ndjson_lines), encoding="utf-8")
    print(f"✅ Generated NDJSON file at {OUTPUT_NDJSON} with {len(ndjson_lines)} records.")

    print("\n🚀 Pushing directly to Cloudflare Vectorize via Wrangler...")
    worker_dir = OUTPUT_NDJSON.parent
    try:
        cmd = ["npx", "wrangler", "vectorize", "insert", "com738-rag-index", "--file=vectors.ndjson", "--env=production"]
        print(f"Executing: {' '.join(cmd)} in {worker_dir}")
        res = subprocess.run(cmd, cwd=str(worker_dir), capture_output=True, text=True, timeout=120)
        print("STDOUT:", res.stdout)
        if res.stderr:
            print("STDERR:", res.stderr)
        if res.returncode == 0:
            print("🎉 Successfully synced local chunks directly to Cloudflare Vectorize!")
        else:
            print("⚠️ Wrangler insert returned non-zero code. Check credentials or index name.")
    except Exception as e:
        print(f"❌ Error executing wrangler: {e}")

if __name__ == "__main__":
    main()
