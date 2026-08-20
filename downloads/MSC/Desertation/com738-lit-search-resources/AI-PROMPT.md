# Literature Review Search Task — COM738 Dissertation

**For the External AI Tool** — execute this research task and return results as structured Markdown.

---

## Context

I am completing an MSc Computer Science dissertation at Wrexham University (via Londontec, Sri Lanka). My dissertation title:

> **"A Retrieval-Augmented Generation (RAG) Architecture for Low-Resource Languages: A Case Study on Sinhala-Medium Secondary Business Education"**

**Deadline:** August 2, 2026 (submission before 1 PM at Londontec Nugegoda).

**Current Status:** ~17,000 words drafted. Chapters 1-4 are complete with 28+ references in the Literature Review (Chapter 2). Chapters 5-7 (Results, Discussion, Conclusion) need completion. The Lit Review is solid but I want to strengthen it with additional recent papers the external AI can find.

---

## Your Task

Conduct a **literature search** across arXiv, Semantic Scholar, and Google Scholar for the **most recent (2024-2026) and highest-impact papers** across these 6 categories:

### Category 1: RAG Hallucination Mitigation in Low-Resource Languages
- Papers that go beyond the standard surveys (Ji et al. 2023, Huang et al. 2025, Alansari & Luqman 2026 — all already cited)
- Specific techniques for reducing hallucination when retrieval is paired with a low-resource target language
- Any new 2026 papers on hallucination detection in non-English RAG outputs

### Category 2: Multilingual Embedding Models for Dense Retrieval
- Beyond BGE-M3 and multilingual-E5 (already cited)
- Papers benchmarking embedding models specifically on South Asian languages (beyond SEA-BED, already cited)
- Any 2025-2026 embedding models with proven performance on Sinhala, Tamil, Hindi, Bengali, or Urdu

### Category 3: RAG in Non-English / Low-Resource Education
- The biggest gap in current literature (see Chapter2_LiteratureReview.md Section 2.7)
- Any RAG-based educational systems in non-English languages, especially South/Southeast Asian curricula
- Papers on AI tutoring systems in low-resource language classrooms

### Category 4: Sinhala NLP Advances (2025-2026)
- Beyond SinLlama and Sinhala encoder-only models (already cited)
- Any new Sinhala benchmarks, datasets, or tools released in 2025-2026
- Papers on Sinhala tokenization, Sinhala OCR improvements, Sinhala text normalization

### Category 5: RAG Evaluation Metrics Beyond RAGAS
- RAGAS is cited (Es et al. 2024). What's newer?
- Any 2025-2026 evaluation frameworks for RAG systems
- LLM-as-judge reliability for non-English languages — especially when the judge model itself may be weak in the target language

### Category 6: Document Processing & Chunking for Non-Latin Scripts
- Chunking strategies validated on non-Latin scripts (Sinhala, Tamil, Arabic, Thai, etc.)
- Papers on Sinhala PDF extraction, Sinhala OCR, or multi-column Sinhala document layout analysis
- Any work on segmentation-aware retrieval for morphologically rich languages

---

## Deliverable Format

For **each paper found**, provide:

```markdown
### [N] Paper Title

- **Authors:** ...
- **Year:** 20XX
- **Venue:** Conference/Journal name + abbreviation
- **arXiv ID / DOI:** (if available)
- **Citations:** (from Semantic Scholar if available)
- **Relevance (1-5):** How directly relevant to my dissertation
- **Key Contribution:** 2-3 sentence summary of the contribution
- **How It Fits:** Which part of my dissertation this strengthens (e.g. "Supports RQ2 embedding comparison", "Used in Chapter 2.6 Sinhala NLP gap", "Cited in Chapter 2.7 RAG in education section", "Methodological precedent for Chapter 3 evaluation design")
- **BibTeX:** Full BibTeX entry
```

Then a summary section:

```markdown
## Summary & Recommendations

- **Most impactful find:** [1-2 sentences about the single most important paper]
- **Papers to cite immediately (top 3):** 
- **Papers worth reading but lower priority (next 5):**
- **Gaps confirmed (no papers found for):** 
- **Suggested new Chapter 2 subsection or paragraph topic from these findings:**
```

---

## Resource Files Provided

| File | Use |
|------|-----|
| `Chapter2_LiteratureReview.md` | Full Chapter 2 with all 28 existing references — do NOT duplicate papers already cited here |
| `dissertation-main.txt` | Full dissertation — check existing references section (end of file) for additional citations to avoid duplicates |
| `README.md` | Project overview — word count, status, structure, pending work |

---

## Critical Constraints

1. **Do NOT suggest papers already cited** — cross-reference against the reference list in Chapter 2 and the main dissertation. 28 papers are already covered.
2. **Prioritize 2025-2026 publications** — these strengthen the "currency" of the literature review. 2024 papers are acceptable if highly relevant.
3. **Target 10-15 genuinely new papers** — quality over quantity. 5 high-quality, directly relevant papers are better than 15 tangentially related ones.
4. **If you find zero new papers in a category**, say so honestly — that is itself a useful finding that confirms the research gap.
5. **Return BibTeX entries that actually compile** — check for missing braces, unescaped special characters.

---

## Sample Searches to Run

Use these exact queries on Semantic Scholar API, arXiv API, and Google Scholar:

```
"retrieval augmented generation" "low resource language" 2025 2026
RAG hallucination Sinhala education
multilingual embedding benchmark South Asia 2025
Sinhala NLP tokenization 2025 2026
RAG evaluation framework multilingual 2025
"document chunking" "non Latin script" retrieval
"RAG in education" "non English"
cross-lingual retrieval morphology agglutinative
```

---

**Respond with the full structured deliverable above. Include BibTeX entries.**
