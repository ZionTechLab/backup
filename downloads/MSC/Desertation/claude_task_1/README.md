# COM738 — RAG Implementation Plan

**System:** RAG Pipeline for Sinhala O/L Business Studies  
**Deadline:** Aug 2, 2026  
**Platform:** Python + LangChain + Chroma + Claude/GPT-4o API  

---

## Phase 1: Data Preparation (2-3 hours)

| # | Task | Detail | Status |
|---|------|--------|--------|
| 1 | **Collect PDFs** | NIE syllabus, Grade 10 & 11 textbooks, 3-5 past papers — all Sinhala | 🔄 2/6 collected |
| 2 | **Extract text** | Python `pymupdf` — auto-detect Unicode / legacy font / scanned | ✅ `src/extract.py` ready |
| 3 | **Clean text** | NFC normalize, strip ZWJ/ZWNJ, remove headers/page numbers | ✅ In extract.py |
| 4 | **Segment chunks** | 3 strategies: paragraph, 500-char window, semantic boundary | ⬜ |
| 5 | **Build knowledge base** | JSON `[{id, text, source, chunk_strategy}]` — 50-100 passages | ⬜ |

---

## Phase 2: Embedding & Vector DB (2-3 hours)

| # | Task | Detail | Status |
|---|------|--------|--------|
| 1 | **Embed knowledge base** | `sentence-transformers` — multilingual-E5-large + BGE-M3 | ⬜ |
| 2 | **Store in Chroma** | Local vector DB, 2 collections: `sinhala_rag_E5` + `sinhala_rag_BGE` | ⬜ |
| 3 | **Test retrieval** | 10 sample questions → check relevance of returned chunks | ⬜ |

---

## Phase 3: Query Pipeline (3-4 hours)

| # | Task | Detail | Status |
|---|------|--------|--------|
| 1 | **LangChain RAG chain** | `langchain` + `langchain-community` — embed → retrieve → prompt → generate | ⬜ |
| 2 | **Sinhala prompt template** | "පහත තොරතුරු පමණක් භාවිතා කර පිළිතුරු දෙන්න..." | ⬜ |
| 3 | **LLM connection** | Claude / GPT-4o via `langchain-openai` or `langchain-anthropic` | ⬜ |
| 4 | **End-to-end test** | 5 sample questions → full RAG → Sinhala answers | ⬜ |

---

## Phase 4: Baselines (2-3 hours)

| # | Task | Detail | Status |
|---|------|--------|--------|
| 1 | **Baseline A — Ungrounded** | Same LLM, no retrieval, free-form Sinhala | ⬜ |
| 2 | **Baseline B — Constrained** | Same constraint prompt but NO retrieval (empty context) | ⬜ |
| 3 | **Compare all 3** | RAG vs Baseline A vs Baseline B — same 5 questions | ⬜ |

---

## Phase 5: Evaluation (3-4 hours)

| # | Task | Detail | Status |
|---|------|--------|--------|
| 1 | **Build evaluation set** | 60-80 Sinhala questions + reference answers | ⬜ |
| 2 | **Run RAGAS** | Faithfulness, hallucination rate — all 3 variants | ⬜ |
| 3 | **Statistical test** | `scipy.stats.wilcoxon` — paired comparison RAG vs baselines | ⬜ |
| 4 | **Results table** | All metrics. All variants. Clean table. | ⬜ |

---

## Phase 6: Final Deliverables (4-5 hours)

| # | Task | Londontec Requirement | Status |
|---|------|----------------------|--------|
| 1 | **Dissertation writing** | 15-20K words (Nia drafts, Thilina reviews) | ⬜ |
| 2 | **Code organized** | `src/ingest.py`, `src/query.py`, `src/evaluate.py`, `requirements.txt`, `README.md` | 🔄 Partially |
| 3 | **Poster** | Academic poster — problem → method → results → conclusion | ⬜ |
| 4 | **Specification** | Technical spec — architecture, data flow, tools, APIs | ⬜ |
| 5 | **Plagiarism report** | Run Turnitin or equivalent | ⬜ |
| 6 | **Burn 2 CDs** | Identical copies, all files organized | ⬜ |

---

## Timeline

```
Jul 25-26        Phase 1-2  → Data + Embeddings ready
Jul 27           Phase 3    → RAG pipeline working
Jul 28           Phase 4    → Baselines working
Jul 29-30        Phase 5    → Evaluation complete, results in hand
Jul 31-Aug 1     Phase 6    → Writing + CD burning
Aug 2            SUBMIT     → Londontec before 1 PM
```

---

## Project Structure

```
~/projects/com738-dissertation/
├── src/
│   ├── extract.py        ✅ PDF → clean Sinhala text
│   ├── chunk.py          ⬜ Text → knowledge base JSON
│   ├── embed.py          ⬜ KB → Chroma vector DB
│   ├── query.py          ⬜ LangChain RAG pipeline
│   ├── evaluate.py       ⬜ RAGAS metrics + Wilcoxon test
│   └── baselines.py      ⬜ Ungrounded + constrained baselines
├── data/
│   ├── raw/              📄 Source PDFs
│   ├── processed/        📝 Extracted .txt files
│   └── evaluation/       ✅ 60-80 Q&A pairs
├── venv/                 🔧 Python virtual environment
├── requirements.txt      📦 Dependencies
├── pipeline-diagram.html 🖼️ Visual pipeline
├── pipeline-mermaid.md   📊 Mermaid diagram
└── README.md             📖 This file
```
