# COM738 — MSc Dissertation Proposal

**Student:** S25021960 — M.A.A.T. Perera  
**Module:** COM738 — Dissertation (60 credits, Level 7)  
**Supervisor:** Requested: NLP / LLM / Low-Resource Language expertise  
## Londontec Lecture Schedule — COM738 Dissertation

| Date | Time | Session |
|------|------|---------|
| Jun 14 | 3:30 PM – 5:00 PM | Proposal Writing |
| Jun 21 | Before 11:59 PM | **Proposal Submission** ✅ |
| Jun 28 | 3:30 PM – 5:00 PM | Layout of the Dissertation |
| Jul 5 | 3:30 PM – 5:00 PM | Dissertation Review — Physical |
| Jul 12 | 3:30 PM – 5:00 PM | Dissertation Review — Physical |
| **Jul 26** | **3:30 PM – 5:00 PM** | **Dissertation Review — Physical** |
| **Aug 2** | **3:30 PM – 5:00 PM** | **Submission of Dissertation** |

### Today

**Sunday, Jul 26 — Dissertation Review at 3:30 PM.** You're expected to present progress. Physical attendance.  

---

## Status

| Item | Status |
|------|--------|
| Proposal | ✅ Submitted Jun 21 |
| Dissertation writing | 🛑 **DO NOT START** — wait for Thilina's signal |
| Knowledge gathering | 🔄 In progress — sources collected |

### When Ready — What Nia Will Do

1. Expand proposal sections into dissertation chapters
2. Write full methodology + literature review (27 refs)
3. Build RAG pipeline code
4. Design poster + specification documents
5. Structure to Londontec CD requirements

**Just say the word. Not before.**

---

## Title

A Retrieval-Augmented Generation (RAG) Architecture for Low-Resource Languages: A Case Study on Sinhala-Medium Secondary Business Education

---

## Abstract

Design and test a RAG model grounded on a verified Sinhala Business Studies knowledge base. Compare against an ungrounded baseline using faithfulness, hallucination rate, retrieval accuracy, and response quality. First application of RAG to formal Sinhala curriculum content.

---

## Research Questions

| RQ | Question |
|----|----------|
| RQ1 | Will grounding in verified Sinhala O/L Business Studies content decrease hallucination and increase faithfulness vs a baseline LLM? |
| RQ2 | Which embedding model(s) + chunking strategies give optimal results for Sinhala educational text? |
| RQ3 (optional) | Does dual representation (LLM-generated QA pairs indexed alongside passages) improve retrieval over single-vector indexing? |

---

## Methodology

| Component | Choice |
|-----------|--------|
| Approach | Positivist, deductive, controlled experiment |
| Baselines | (i) Ungrounded LLM, (ii) Prompt-constrained but ungrounded |
| Evaluation set | 60-80 Sinhala questions from past papers + textbook, all with reference answers |
| Automated metrics | RAGAS — faithfulness, hallucination rate |
| Human validation | 2-3 O/L Business Studies teachers, blind, 1-5 rubric, Cohen's kappa |
| Statistical test | Wilcoxon signed-rank (or paired t-test if distributional) |
| Embedding models | multilingual-E5, BGE-M3 |
| Vector DB | Pinecone (hosted) or Chroma (local) |
| LLM | Claude / GPT-4o / Gemini via API |
| Pipeline | LangChain |
| Timeline | Apr 1 – Jul 31, 2026 (4 months) |

---

## Knowledge Base

NIE O/L Business Studies syllabus, textbook, teacher's guide, past papers — all in Sinhala, all publicly available, collected in PDF, cleaned and normalized.

---

## Key References (27 Total)

| # | Paper | Relevance |
|---|-------|-----------|
| [1] | Lewis et al. 2020 | Original RAG architecture |
| [9] | Trivedi et al. 2026 | Hallucination rates in low-resource languages |
| [23] | Ahmad et al. 2026 | DR-RAG for Urdu — closest morphological parallel to Sinhala |
| [24] | Aravinda et al. 2025 | SinLlama — Sinhala LLM |
| [25] | Ranasinghe et al. 2025 | Sinhala encoder-only models |
| [26] | Jayakody & Dias 2024 | Claude + GPT-4o Sinhala performance |
| [27] | Pramodya et al. 2025 | SinhalaMMLU benchmark |

---

## Ethics

- Only published curricular documents — no PII
- Teachers provide informed consent, review anonymized outputs
- No copyrighted material shared with third parties

---

## Limitations

- Single subject (Business Studies), single language (Sinhala), single country (Sri Lanka)
- Small evaluation set (60-80 questions)
- API costs limit reproducibility
- No model training — retrieval + prompt improvements only
- Automated metrics depend on LLM judging Sinhala (validated by humans)

---

## Expected Outcomes

1. Modular RAG architecture for Sinhala Business Studies
2. Curated evaluation set with reference answers
3. Empirical evidence on hallucination reduction via grounding
4. Optimized embedding + chunking parameters for Sinhala
5. Framework for extending to other subjects and low-resource languages

---

## Related

- [[COM713 - DSA Assignment]]
- [[COM738 - Project Proposal Guide]]
- [[ML 2nd Assignment]]
