# COM738 — Dissertation

**Student:** M.A.A.T. Perera (S25021960), Wrexham University via Londontec
**Title:** *A Retrieval-Augmented Generation (RAG) Architecture for Low-Resource Languages: A Case Study on Sinhala-Medium Secondary Business Education*
**Credits:** 60 (Level 7)
**Deadline:** 🔴 **Aug 2, 2026** — submit before 1 PM at Londontec City Campus, Nugegoda
**Status:** 🟡 In progress — main doc at 16,985 words (target 15K–20K ✅)

---

## Word Count (as of Jul 29)

| File | Words | Status |
|---|---|---|
| `final-project/COM738 - Dissertation.md` | **16,985** | ✅ in target range |
| `final-project/Chapter2_LiteratureReview.md` | 6,172 | drafted |
| **Total** | **23,157** | healthy |

---

## Document Structure (current state)

| Chapter | Topic | Status |
|---|---|---|
| **Abstract** | — | ✅ done |
| **Acknowledgements** | — | ✅ done |
| **TOC** | — | ✅ done |
| **Ch 1** | Introduction (7 sections) | ✅ done |
| **Ch 2** | Literature Review (9 sections) | ✅ drafted (6,172 words) |
| **Ch 3** | Research Methodology (10 sections) | ✅ skeleton + content |
| **Ch 4** | System Design & Implementation | ✅ done |
| **Ch 5** | Results & Evaluation (5 sections) | ⚠️ skeleton only — needs results |
| **Ch 6** | Discussion (5 sections) | ⚠️ skeleton only — needs discussion |
| **Ch 7** | Conclusion & Future Work (3 sections) | ⚠️ skeleton only — needs summary |
| **References** | — | ✅ populated |
| **Appendices A–F** | Question set, rubric, consent, code, RAGAS, Gantt | ✅ skeletons present |

---

## Code Repo (`~/projects/com738-dissertation/`)

| Component | File | Status |
|---|---|---|
| PDF extractor | `extract/` | ✅ done |
| Chunker | `chunker.py` | ✅ done |
| Embedder | `embed.py` | ✅ done (E5 model) |
| Query/RAG | `query.py` | ✅ done (5/5 queries working) |
| Evaluator | `evaluate.py` | ✅ scaffolded — RAGAS ready |
| Vector DB | `chroma_db/` | ✅ 4 collections, 75 docs total |

**ChromaDB collections:**
- `syllabus_paragraph_e5`: 30 docs
- `pastpaper_question_e5`: 20 docs
- `syllabus_section_e5`: 15 docs
- `syllabus_sliding_e5`: 10 docs

---

## 📅 4-Day Plan (Jul 29 → Aug 2)

| Day | Focus | Deliverable |
|---|---|---|
| **Today (Jul 29)** | Review Chapter 5/6/7 skeletons, fill gaps | Skeletons fleshed out |
| **Jul 30** | Run Phase 5 evaluation, write results | Chapter 5 complete |
| **Jul 31** | Discussion + Conclusion | Chapters 6 + 7 complete |
| **Aug 1** | Plagiarism check, format per Wrexham guide, CD burning | Final DOCX + CDs |
| **Aug 2** | Submit before 1 PM at Londontec Nugegoda | ✅ Submitted |

---

## Still Needed ⬜

- [ ] Run RAGAS evaluation (`evaluate.py`) — Phase 5
- [ ] Fill Chapter 5 with actual results (5.1–5.5)
- [ ] Write Chapter 6 discussion based on results
- [ ] Write Chapter 7 conclusion + future work
- [ ] Plagiarism check (Turnitin or similar)
- [ ] Format per `COM738 - Formatting Guide.md` (Times New Roman 12pt, 1.5 spacing)
- [ ] Burn 2 CDs (dissertation + code)
- [ ] Poster (Phase 6)

---

## Folder Structure

```
com738_dissertation/
├── README.md                          ← this file
├── proposal/
│   ├── COM738 - Dissertation Proposal.md
│   ├── COM738 - Project Proposal Guide.md
│   └── Literature-Review-Knowledge/
└── final-project/
    ├── README.md                      ← implementation plan (Phases 1–6)
    ├── COM738 - Dissertation.md       ← main dissertation (1,116 lines)
    ├── Chapter2_LiteratureReview.md   ← Chapter 2 (separate, 6,172 words)
    ├── COM738 - PDF Pipeline.md       ← PDF extraction pipeline
    ├── COM738 - Formatting Guide.md   ← Wrexham formatting rules
    ├── pipeline-mermaid.md
    ├── pipeline-diagram.html
    └── MSc Dissertation.md            ← (superseded by this README)
```

---

## Quick Links

| What | Where |
|---|---|
| Main dissertation | `final-project/COM738 - Dissertation.md` |
| Chapter 2 draft | `final-project/Chapter2_LiteratureReview.md` |
| Formatting rules | `final-project/COM738 - Formatting Guide.md` |
| Proposal | `proposal/COM738 - Dissertation Proposal.md` |
| Code repo | `~/projects/com738-dissertation/` |

---

*Last updated: Jul 29, 2026 — by Nia, after Thilina flagged the stale tracker*