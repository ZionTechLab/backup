# Literature Search Results — COM738 Dissertation
## Sinhala RAG for Secondary Business Education — Supplementary Lit Search (2024–2026)

Searched arXiv, Semantic Scholar and Google Scholar across the six requested categories. Cross-checked every candidate against the 28 references already in `Chapter2_LiteratureReview.md` — none of the 14 papers below duplicate an existing citation. Citation counts are omitted where a paper is a 2025/2026 preprint too recent to have an indexed Semantic Scholar count; stating a number I could not verify would be a guess, not a fact.

---

## Category 1: RAG Hallucination Mitigation in Low-Resource Languages

### [1] CCL-XCoT: An Efficient Cross-Lingual Knowledge Transfer Method for Mitigating Hallucination Generation

- **Authors:** Weihua Zheng, Roy Ka-Wei Lee, Zhengyuan Liu, Kui Wu, AiTi Aw, Bowei Zou
- **Year:** 2025
- **Venue:** Findings of the Association for Computational Linguistics: EMNLP 2025
- **arXiv ID / DOI:** arXiv:2507.14239
- **Citations:** Not yet indexed (2025 preprint/Findings paper)
- **Relevance (1-5):** 4
- **Key Contribution:** A two-stage fine-tuning framework — curriculum-based contrastive learning for cross-lingual semantic alignment, followed by a cross-lingual Chain-of-Thought (XCoT) prompting strategy that reasons in a high-resource language before answering in the low-resource target language. Reports up to 62% hallucination reduction without retrieval or ensembling.
- **How It Fits:** A non-retrieval alternative mitigation strategy for the same problem framed in section 2.1 (hallucination scaling inversely with training data volume). Useful as a contrasting approach to cite alongside Alansari and Luqman (2026) and Trivedi et al. (2026) — shows the field is also pursuing fine-tuning-based fixes as an alternative to RAG, which strengthens the justification (in section 2.3) for why this dissertation chose RAG specifically.
- **BibTeX:**
```bibtex
@inproceedings{zheng2025cclxcot,
  author    = {Zheng, Weihua and Lee, Roy Ka-Wei and Liu, Zhengyuan and Wu, Kui and Aw, AiTi and Zou, Bowei},
  title     = {{CCL-XCoT}: An Efficient Cross-Lingual Knowledge Transfer Method for Mitigating Hallucination Generation},
  booktitle = {Findings of the Association for Computational Linguistics: EMNLP 2025},
  year      = {2025},
  eprint    = {2507.14239},
  archivePrefix = {arXiv}
}
```

### [2] Towards Typologically Aware Rescoring to Mitigate Unfaithfulness in Lower-Resource Languages

- **Authors:** Tsan Tsai Chan, Xin Tong, Thi Thu Uyen Hoang, Barbare Tepnadze, Wojciech Stempniak
- **Year:** 2025
- **Venue:** arXiv preprint (Saarland University)
- **arXiv ID / DOI:** arXiv:2502.17664
- **Citations:** Not yet indexed
- **Relevance (1-5):** 3
- **Key Contribution:** Proposes lightweight auxiliary rescoring models (small monolingual BERT models trained from scratch on <700MB of data) to detect unfaithful/hallucinated summaries, tested on three typologically diverse, unrelated low-resource languages (Vietnamese, Polish, Georgian). Finds morphological complexity interacts with which regularisation and model depth work best.
- **How It Fits:** Directly relevant to section 2.4's discussion of morphologically rich languages and section 2.8's evaluation design — offers a computationally cheap faithfulness-detection alternative that could be mentioned as future work if RAGAS-plus-human-validation proves too costly to scale.
- **BibTeX:**
```bibtex
@article{chan2025typological,
  author  = {Chan, Tsan Tsai and Tong, Xin and Hoang, Thi Thu Uyen and Tepnadze, Barbare and Stempniak, Wojciech},
  title   = {Towards Typologically Aware Rescoring to Mitigate Unfaithfulness in Lower-Resource Languages},
  journal = {arXiv preprint arXiv:2502.17664},
  year    = {2025}
}
```

### [3] Investigating Hallucination in Conversations for Low Resource Languages

- **Authors:** Amit Das, Md. Najib Hasan, Souvika Sarkar, Zheng Zhang, Fatemeh Jamshidi, Tathagata Bhattacharya, Nilanjana Raychawdhury, Dongji Feng, Vinija Jain, Aman Chadha
- **Year:** 2025
- **Venue:** arXiv preprint
- **arXiv ID / DOI:** arXiv:2507.22720
- **Citations:** Not yet indexed
- **Relevance (1-5):** 3
- **Key Contribution:** Extends hallucination analysis to conversational (multi-turn) data across Hindi, Farsi and Mandarin using GPT-3.5, GPT-4o, Llama-3.1, Gemma-2.0, DeepSeek-R1 and Qwen-3. Finds Mandarin is comparatively well-served while Hindi and Farsi hallucinate far more — evidence that "low-resource" is not a single category but varies sharply by language.
- **How It Fits:** Reinforces the section 2.1 claim that hallucination severity is language-specific rather than uniform across all "low-resource" languages — useful corroborating evidence that Sinhala cannot be assumed to behave like any other low-resource language merely by analogy.
- **BibTeX:**
```bibtex
@article{das2025investigating,
  author  = {Das, Amit and Hasan, Md. Najib and Sarkar, Souvika and Zhang, Zheng and Jamshidi, Fatemeh and Bhattacharya, Tathagata and Raychawdhury, Nilanjana and Feng, Dongji and Jain, Vinija and Chadha, Aman},
  title   = {Investigating Hallucination in Conversations for Low Resource Languages},
  journal = {arXiv preprint arXiv:2507.22720},
  year    = {2025}
}
```

---

## Category 2: Multilingual Embedding Models for Dense Retrieval

### [4] IndicRAGSuite: Large-Scale Datasets and a Benchmark for Indian Language RAG Systems

- **Authors:** Pasunuti Prasanjith, Prathmesh B. More, Anoop Kunchukuttan, Raj Dabre
- **Year:** 2025
- **Venue:** arXiv preprint (AI4Bharat)
- **arXiv ID / DOI:** arXiv:2506.01615
- **Citations:** Not yet indexed
- **Relevance (1-5):** 5
- **Key Contribution:** Introduces IndicMSMarco, a 13-Indian-language retrieval/generation benchmark built by manually translating 1,000 MS MARCO-dev queries, plus a large-scale (question, answer, passage) training set derived from 19 Indian-language Wikipedias. Directly benchmarks multilingual-E5, BGE-M3 and LLM2Vec variants and finds substantial cross-language MRR variance (e.g. Hindi 0.44–0.52, Bengali/Tamil 0.38–0.49).
- **How It Fits:** The single strongest new find. It is the first large-scale South Asian RAG benchmark to empirically confirm — for languages typologically adjacent to Sinhala — exactly the multilingual-E5/BGE-M3 degradation pattern this dissertation's RQ2 tests for Sinhala specifically. Strengthens section 2.4 and section 2.9's framing of the research gap; South Asia now has an Indic precedent (though still not Sinhala) rather than only the Nigerian (Omotoso et al., 2025) and Southeast Asian (SEA-BED) precedents already cited.
- **BibTeX:**
```bibtex
@article{prasanjith2025indicragsuite,
  author  = {Prasanjith, Pasunuti and More, Prathmesh B. and Kunchukuttan, Anoop and Dabre, Raj},
  title   = {{IndicRAGSuite}: Large-Scale Datasets and a Benchmark for Indian Language {RAG} Systems},
  journal = {arXiv preprint arXiv:2506.01615},
  year    = {2025}
}
```

### [5] Less is More: Adapting Text Embeddings for Low-Resource Languages with Small Scale Noisy Synthetic Data

- **Authors:** Zaruhi Navasardyan, Spartak Bughdaryan, Bagrat Minasyan, Hrant Davtyan
- **Year:** 2026
- **Venue:** Proceedings of the 2nd Workshop on Language Models for Low-Resource Languages (LoResLM)
- **arXiv ID / DOI:** arXiv:2603.22290
- **Citations:** Not yet indexed
- **Relevance (1-5):** 4
- **Key Contribution:** Fine-tunes multilingual-E5 on just 10,000 noisy, machine-translated Armenian sentence pairs (translated Reddit title-body data) and matches performance obtained with ~1 million clean examples — an 11–12% average benchmark improvement. Also shows scaling data further, improving translation quality, or diversifying domains gives no additional gain; semantic alignment for low-resource languages "saturates early."
- **How It Fits:** Directly actionable for this dissertation's methodology (Chapter 3/4): if multilingual-E5 or BGE-M3 underperforms on Sinhala under RQ2, this paper is evidence that a small, cheaply-generated synthetic fine-tuning set (not a large curated corpus) could be a viable, low-cost remediation — a concrete answer to the gap Omotoso et al. (2025) identify for BGE-M3's out-of-the-box multilingual coverage.
- **BibTeX:**
```bibtex
@inproceedings{navasardyan2026lessismore,
  author    = {Navasardyan, Zaruhi and Bughdaryan, Spartak and Minasyan, Bagrat and Davtyan, Hrant},
  title     = {Less is More: Adapting Text Embeddings for Low-Resource Languages with Small Scale Noisy Synthetic Data},
  booktitle = {Proceedings of the 2nd Workshop on Language Models for Low-Resource Languages (LoResLM)},
  year      = {2026},
  eprint    = {2603.22290},
  archivePrefix = {arXiv}
}
```

---

## Category 3: RAG in Non-English / Low-Resource Education

### [6] Shiksha Copilot: Teacher-AI Collaboration for Curating and Customizing Lesson Plans in Low-Resource Schools

- **Authors:** Deepak Varuvel Dennison, Bakhtawar Ahtisham, Kavyansh Chourasia, Nirmit Arora, Rahul Singh, Rene F. Kizilcec, Akshay Nambi, Tanuja Ganu, Aditya Vashistha
- **Year:** 2026 (arXiv v1: Jul 2025; PACM HCI publication: 2026)
- **Venue:** Proceedings of the ACM on Human-Computer Interaction (CSCW)
- **arXiv ID / DOI:** arXiv:2507.00456; https://doi.org/10.1145/3788074
- **Citations:** Not yet indexed
- **Relevance (1-5):** 5
- **Key Contribution:** A large-scale (1,043 teachers, 23 curators) deployed system, built by Microsoft Research, that co-creates English and Kannada lesson plans for government schools in Karnataka, India, then lets teachers customise them. Finds the tool reduced planning time and administrative burden and shifted practice toward activity-based pedagogy, but that staffing shortages limited deeper pedagogical change.
- **How It Fits:** The closest real-world precedent found for the exact gap identified in section 2.7 — an AI system grounded in curriculum content, deployed in a South Asian, multilingual, low-resource government-school setting. It is not Sinhala, not RAG in the strict retrieve-then-generate sense (it is closer to AI-assisted content curation than question-answering), and not Business Studies, so it does not close the gap, but it is directly citable evidence that "no RAG-based educational application situated in South Asia" understates how close adjacent work has come. Worth a paragraph in section 2.7 distinguishing lesson-plan curation from student-facing RAG QA.
- **BibTeX:**
```bibtex
@article{dennison2026shiksha,
  author  = {Dennison, Deepak Varuvel and Ahtisham, Bakhtawar and Chourasia, Kavyansh and Arora, Nirmit and Singh, Rahul and Kizilcec, Rene F. and Nambi, Akshay and Ganu, Tanuja and Vashistha, Aditya},
  title   = {Shiksha Copilot: Teacher-{AI} Collaboration for Curating and Customizing Lesson Plans in Low-Resource Schools},
  journal = {Proceedings of the ACM on Human-Computer Interaction},
  year    = {2026},
  note    = {arXiv:2507.00456}
}
```

**No further genuinely new papers were found for Category 3.** Several English-medium, high-resource RAG tutoring systems appeared (e.g. mobile RAG architectures for higher education, KG-RAG tutors for technical courses) but none situated in a non-English or South/Southeast Asian K-12 context beyond Shiksha Copilot. This confirms the gap already documented in section 2.7 rather than closing it.

---

## Category 4: Sinhala NLP Advances (2025–2026)

### [7] SinhaLegal: A Benchmark Corpus for Information Extraction and Analysis in Sinhala Legislative Texts

- **Authors:** Minduli Lasandi, Nevidu Jayatilleke
- **Year:** 2026
- **Venue:** arXiv preprint (Informatics Institute of Technology / University of Moratuwa, Sri Lanka)
- **arXiv ID / DOI:** arXiv:2603.04854
- **Citations:** Not yet indexed
- **Relevance (1-5):** 3
- **Key Contribution:** A ~2-million-word Sinhala legislative corpus (1,206 Acts and Bills, 1981–2014), OCR-extracted via Google Document AI with manual cleaning, evaluated with corpus statistics, NER, topic modelling and LLM perplexity analysis. Explicitly notes many source PDFs had multi-column layouts that degraded OCR accuracy.
- **How It Fits:** Not education-domain, but directly relevant to section 2.6 (Sinhala NLP resource scarcity) as evidence the field is still building basic domain corpora one sector at a time, and to Category 6 concerns — the multi-column PDF/OCR degradation problem it reports is the same document-processing risk facing this dissertation's own O/L Business Studies PDF pipeline.
- **BibTeX:**
```bibtex
@article{lasandi2026sinhalegal,
  author  = {Lasandi, Minduli and Jayatilleke, Nevidu},
  title   = {{SinhaLegal}: A Benchmark Corpus for Information Extraction and Analysis in Sinhala Legislative Texts},
  journal = {arXiv preprint arXiv:2603.04854},
  year    = {2026}
}
```

### [8] Sri Lanka Document Datasets: A Large-Scale, Multilingual Resource for Law, News, and Policy

- **Authors:** Nuwan I. Senaratna
- **Year:** 2025 (continuously updated through 2026)
- **Venue:** arXiv preprint (independent researcher)
- **arXiv ID / DOI:** arXiv:2510.04124
- **Citations:** Not yet indexed
- **Relevance (1-5):** 2
- **Key Contribution:** A continuously updated, open, machine-readable collection of 278,621 Sri Lankan government/legal/news documents (80.7GB) across 26 datasets in Sinhala, Tamil and English, with an automated GitHub Actions collection pipeline. Single-author, non-peer-reviewed preprint — treat as a data resource rather than a validated research contribution.
- **How It Fits:** A potential future-work pointer for section 2.6/2.9 (Sinhala resource scarcity) — a general-purpose Sinhala/Tamil/English corpus that could seed pretraining or fine-tuning data for a future, broader Sinhala RAG system beyond the single-subject O/L Business Studies scope of this dissertation. Cite cautiously given the lack of peer review.
- **BibTeX:**
```bibtex
@article{senaratna2026srilanka,
  author  = {Senaratna, Nuwan I.},
  title   = {Sri Lanka Document Datasets: A Large-Scale, Multilingual Resource for Law, News, and Policy},
  journal = {arXiv preprint arXiv:2510.04124},
  year    = {2025}
}
```

### [9] Cross-Temporal Sinhala OCR: Page-Level Adaptation and Diachronic Analysis

- **Authors:** Avisha Dilhara, Nevidu Jayatilleke
- **Year:** 2026
- **Venue:** arXiv preprint
- **arXiv ID / DOI:** arXiv:2606.29378
- **Citations:** Not yet indexed
- **Relevance (1-5):** 3
- **Key Contribution:** Studies Sinhala OCR performance across documents from different historical periods (diachronic text), proposing page-level adaptation to handle typographic and orthographic drift over time.
- **How It Fits:** Directly relevant to Category 6 and section 2.6 — one of the only 2025-2026 papers addressing Sinhala OCR specifically rather than generic multilingual OCR. Useful precedent if the dissertation's own PDF extraction pipeline needed to justify OCR-quality assumptions, and confirms Sinhala OCR remains an active, unsolved research problem rather than a solved infrastructural detail.
- **BibTeX:**
```bibtex
@article{dilhara2026crosstemporal,
  author  = {Dilhara, Avisha and Jayatilleke, Nevidu},
  title   = {Cross-Temporal Sinhala {OCR}: Page-Level Adaptation and Diachronic Analysis},
  journal = {arXiv preprint arXiv:2606.29378},
  year    = {2026}
}
```

---

## Category 5: RAG Evaluation Metrics Beyond RAGAS

### [10] Challenges and Recommendations for LLMs-as-a-Judge in Multilingual Settings and Low-Resource Languages

- **Authors:** Seza Doğruöz, Xixian Liao, Verena Blaschke, Jakob Prange, Senyu Li, David Ifeoluwa Adelani
- **Year:** 2026
- **Venue:** arXiv preprint
- **arXiv ID / DOI:** arXiv:2607.02235
- **Citations:** Not yet indexed
- **Relevance (1-5):** 5
- **Key Contribution:** A survey/position paper finding that of 650 papers using LLM-as-a-judge, only 33 address low-resource or multilingual settings at all. Documents systematic overtrust of LLM judgments in these settings, inconsistent outcomes, and near-universal reliance on a single judge model per study — and issues concrete recommendations (ensembling judges, mandatory human-validation subsets, reporting per-language reliability rather than pooled scores).
- **How It Fits:** This is the strongest possible corroboration for section 2.8's central methodological claim — that RAGAS's LLM-judged faithfulness/relevancy scores cannot be trusted at face value for Sinhala. It should be cited directly alongside Trivedi et al. (2026) and Pramodya et al. (2025) as the paper that turns "the present study is cautious about this" into "the present study follows an emerging, explicit recommendation in the literature." Its recommendation to report per-language reliability and use human validation is precisely the two-tier design (RAGAS + blinded human rating + Cohen's kappa) this dissertation already adopted.
- **BibTeX:**
```bibtex
@article{dogruoz2026challenges,
  author  = {Do{\u{g}}ru{\"o}z, Seza and Liao, Xixian and Blaschke, Verena and Prange, Jakob and Li, Senyu and Adelani, David Ifeoluwa},
  title   = {Challenges and Recommendations for {LLMs}-as-a-Judge in Multilingual Settings and Low-Resource Languages},
  journal = {arXiv preprint arXiv:2607.02235},
  year    = {2026}
}
```

### [11] RAG-Zeval: Towards Robust and Interpretable Evaluation on RAG Responses through End-to-End Rule-Guided Reasoning

- **Authors:** Kun Li, Yunxiang Li, Tianhua Zhang, Hongyin Luo, Xixin Wu, James Glass, Helen Meng
- **Year:** 2025
- **Venue:** Proceedings of the 2025 Conference on Empirical Methods in Natural Language Processing (EMNLP)
- **arXiv ID / DOI:** arXiv:2505.22430
- **Citations:** Not yet indexed
- **Relevance (1-5):** 3
- **Key Contribution:** Reframes RAG faithfulness/correctness evaluation as a rule-guided reasoning task, trained via reinforcement learning with a ranking-based (preference) reward rather than absolute pointwise scoring. Reports stronger correlation with human judgments than baseline LLM judges 10–100x larger.
- **How It Fits:** A genuine post-RAGAS evaluation framework (the category the prompt specifically asked for). Its ranking-based reward, rather than absolute LLM-assigned scores, is methodologically relevant to section 2.8's concern that absolute RAGAS scores from a Sinhala-weak judge model are hard to trust — a paired/ranking approach may be more robust than absolute scoring in exactly the same way the Wilcoxon signed-rank test used here is a paired rather than absolute comparison.
- **BibTeX:**
```bibtex
@inproceedings{li2025ragzeval,
  author    = {Li, Kun and Li, Yunxiang and Zhang, Tianhua and Luo, Hongyin and Wu, Xixin and Glass, James and Meng, Helen},
  title     = {{RAG-Zeval}: Towards Robust and Interpretable Evaluation on {RAG} Responses through End-to-End Rule-Guided Reasoning},
  booktitle = {Proceedings of the 2025 Conference on Empirical Methods in Natural Language Processing (EMNLP)},
  year      = {2025},
  eprint    = {2505.22430},
  archivePrefix = {arXiv}
}
```

### [12] BabelJudge: Measuring LLM-as-a-Judge Reliability Across Languages and Agent Trajectories

- **Authors:** Shreyas KC
- **Year:** 2026
- **Venue:** arXiv preprint (single-author, non-peer-reviewed)
- **arXiv ID / DOI:** arXiv:2606.22329
- **Citations:** Not yet indexed
- **Relevance (1-5):** 2
- **Key Contribution:** An open-source reliability-audit framework for LLM judges that measures position bias, verbosity bias, order inconsistency and cross-lingual degradation without needing human preference labels, via "gold-labelling by degradation" (controlled perturbation of a known-good reference). Evaluated on Qwen2.5-7B across English, Hindi, Arabic and Swahili; finds a 23-point reliability gap between Hindi and Swahili.
- **How It Fits:** Supporting evidence for section 2.8, lower priority than [10] given it is a single-author preprint with no institutional affiliation found and an unverified peer-review status — worth a footnote rather than a load-bearing citation, but the Hindi-vs-Swahili reliability gap is a useful concrete number to cite for "judge reliability varies substantially even among languages both nominally covered by the model."
- **BibTeX:**
```bibtex
@article{kc2026babeljudge,
  author  = {KC, Shreyas},
  title   = {{BabelJudge}: Measuring {LLM}-as-a-Judge Reliability Across Languages and Agent Trajectories},
  journal = {arXiv preprint arXiv:2606.22329},
  year    = {2026}
}
```

---

## Category 6: Document Processing & Chunking for Non-Latin Scripts

### [13] Evaluation of Chunking Strategies for Effective Text Embedding in Low-Resource Language on Agricultural Documents

- **Authors:** Sovandara Chhoun, Pichdara Po, Sereiwathna Ros, Wan-Sup Cho, Saksonita Khoeurn
- **Year:** 2026
- **Venue:** arXiv preprint
- **arXiv ID / DOI:** arXiv:2605.22203
- **Citations:** Not yet indexed
- **Relevance (1-5):** 5
- **Key Contribution:** Compares four chunking strategies (Recursive, Khmer-Aware, Sentence-Based, LLM-Based) for RAG over Khmer-language agricultural documents, embedded with BGE-M3 and retrieved via FAISS. Character-based Recursive chunking at 300 characters wins on L2 distance, Answer Relevance and a "Khmer IoU" script-coverage metric — beating more elaborate script-aware chunking.
- **How It Fits:** The single most methodologically relevant find of the whole search. Khmer is, like Sinhala, a non-Latin, morphologically distinct, low-resource script, and this is a same-architecture (BGE-M3) chunking comparison directly answering the empirical question this dissertation poses under RQ2/RQ3 (section 2.4's "none of the chunking literature was validated on Sinhala"). The counterintuitive finding — that simple character-based chunking beat a purpose-built "Khmer-aware" segmenter — is a concrete, citable data point to weigh against Wang et al.'s (2025) general chunking findings when interpreting this dissertation's own chunking-strategy results.
- **BibTeX:**
```bibtex
@article{chhoun2026chunking,
  author  = {Chhoun, Sovandara and Po, Pichdara and Ros, Sereiwathna and Cho, Wan-Sup and Khoeurn, Saksonita},
  title   = {Evaluation of Chunking Strategies for Effective Text Embedding in Low-Resource Language on Agricultural Documents},
  journal = {arXiv preprint arXiv:2605.22203},
  year    = {2026}
}
```

### [14] A Comparative Study of Language Models for Khmer Retrieval-Augmented Question Answering

- **Authors:** Sereiwathna Ros, Phannet Pov, Ratanaktepi Chhor, Kimleang Ly, Wan-Sup Cho, Saksonita Khoeurn
- **Year:** 2026
- **Venue:** arXiv preprint
- **arXiv ID / DOI:** arXiv:2605.22099
- **Citations:** Not yet indexed
- **Relevance (1-5):** 5
- **Key Contribution:** A full RAG pipeline for Khmer telecom-domain QA, benchmarking three embedding models (BGE-M3, Jina-Embeddings-v3, Qwen3-Embedding — BGE-M3 wins) and five open generator backends on 200 Khmer QA pairs. Explicitly frames the motivation as: "RAG efficacy remains largely unexamined for low-resource, non-Latin-script languages such as Khmer."
- **How It Fits:** A near-exact structural precedent for this dissertation's own system design (embedding-model comparison + generator comparison + domain-specific QA set), just for Khmer instead of Sinhala, and for telecom rather than education. Should be cited in section 2.5 alongside DR-RAG (Ahmad et al., 2026) as a second non-Latin-script precedent — strengthening the claim that RAG techniques validated on one morphologically rich, low-resource script provide a reasoned basis for testing analogous approaches on Sinhala, while confirming Sinhala-specific validation still does not exist anywhere in the literature.
- **BibTeX:**
```bibtex
@article{ros2026khmerrag,
  author  = {Ros, Sereiwathna and Pov, Phannet and Chhor, Ratanaktepi and Ly, Kimleang and Cho, Wan-Sup and Khoeurn, Saksonita},
  title   = {A Comparative Study of Language Models for Khmer Retrieval-Augmented Question Answering},
  journal = {arXiv preprint arXiv:2605.22099},
  year    = {2026}
}
```

---

## Summary & Recommendations

**Most impactful find:** [13]/[14] together — the two Khmer RAG papers (Chhoun et al., 2026; Ros et al., 2026). Khmer is the closest linguistic analogue to Sinhala found anywhere in this search (non-Latin, low-resource, morphologically distinct, and — unlike the already-cited Urdu DR-RAG precedent — evaluated with the *same* BGE-M3 embedding model this dissertation uses). They give this dissertation a second, structurally closer non-Latin-script precedent than DR-RAG alone, and [13]'s finding that simple recursive chunking beat a custom Khmer-aware segmenter is directly citable when interpreting your own RQ2/RQ3 chunking results, whichever way they turn out.

**Papers to cite immediately (top 3):**
- [13] Evaluation of Chunking Strategies for Khmer Agricultural Documents — strengthens section 2.4/2.5, methodologically closest precedent for chunking on a non-Latin low-resource script.
- [10] Challenges and Recommendations for LLMs-as-a-Judge in Multilingual Settings — strengthens section 2.8's justification for not trusting RAGAS alone on Sinhala; this is now an explicit literature recommendation, not just an inference from adjacent findings.
- [4] IndicRAGSuite — strengthens section 2.4/2.9; a South Asian (though not Sinhala) empirical confirmation of the multilingual-E5/BGE-M3 degradation pattern your RQ2 investigates.

**Papers worth reading but lower priority (next 5):**
- [6] Shiksha Copilot — closest South Asian precedent for section 2.7, though curation rather than QA.
- [14] Khmer RAG comparative study — companion to [13], same-architecture non-Latin precedent.
- [5] Less is More (Armenian embeddings) — practical remediation option if Sinhala embedding performance under RQ2 is poor.
- [11] RAG-Zeval — a genuine post-RAGAS evaluation framework, useful for the Chapter 6/7 future-work discussion.
- [7] SinhaLegal — evidence of continuing Sinhala resource-building activity and a shared OCR/multi-column layout problem.

**Gaps confirmed (no papers found for):**
- No RAG-based educational question-answering system (student-facing, not lesson-plan curation) was found in Sinhala, Tamil, or any South Asian national-curriculum language. Shiksha Copilot [6] is the closest analogue and is teacher-facing lesson-plan curation, not retrieval-grounded student QA.
- No Sinhala-specific dense retrieval, chunking, or embedding fine-tuning study exists anywhere in the literature as of this search — the closest available precedents remain Khmer ([13],[14]) and Urdu (already-cited DR-RAG), not Sinhala itself.
- No new Sinhala tokenizer or Sinhala-specific evaluation benchmark beyond SinhalaMMLU/SinLlama (already cited) was found; the 2025-2026 Sinhala NLP activity found here ([7],[8],[9]) is concentrated in legal-domain corpora and OCR, not in tokenization or RAG.

**Suggested new Chapter 2 subsection or paragraph topic from these findings:** A short addition to section 2.5 (Cross-Lingual NLP and the Digital Language Divide) introducing the two Khmer RAG papers [13],[14] alongside DR-RAG as a second non-Latin-script precedent, explicitly noting that Khmer's use of the *same* BGE-M3 embedding model as this dissertation makes it a closer methodological comparator than Urdu DR-RAG's dual-representation approach. A one-paragraph addition to section 2.8 citing [10] as direct literature support (not just inference) for distrusting RAGAS's LLM-judged scores on Sinhala.
