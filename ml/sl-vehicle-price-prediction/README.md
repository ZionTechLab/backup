# Sri Lankan Used Vehicle Price Prediction

MSc Computer Science coursework — an end-to-end machine learning system that
predicts the asking price of a used vehicle in Sri Lanka from its attributes,
trained on data self-scraped from **ikman.lk** and **riyasewana.com**.

> **Open the analysis notebook in Colab:**
> replace `USER/REPO` in this URL after you push, or click the badge once the
> repo is public:
> `https://colab.research.google.com/github/USER/REPO/blob/main/notebooks/vehicle_price_prediction.ipynb`

## What the model achieves

On a seller-grouped 5-fold cross-validation (leakage-controlled), the
RandomForest model reaches:

| Metric | Result | Target (§1.6) |
|---|---|---|
| Median APE | **9.1%** | ≤ 15% |
| Within ±25% of asking price | **81.1%** | ≥ 80% |
| vs brand+year baseline (18.3% MedAPE) | **halved** | must beat |

## Repository layout

```
notebooks/
  vehicle_price_prediction.ipynb   ← main deliverable: load → clean → EDA → model → evaluate
scrapers/                          ← data collection (run locally, not in Colab)
  schema.py                        canonical schema + shared parsing/reconciliation
  riyasewana.py                    riyasewana.com scraper (robots-compliant, rate-limited)
  ikman.py                         ikman.lk scraper (sitemap + pagination)
  test_*.py                        offline parser/robots/backoff tests
pipeline/                          ← analysis modules (mirrored in the notebook)
  clean.py                         merge, dedup-before-split, source-specific cleaning
  baselines.py                     trivial baselines (global + brand-year median)
  train.py                         model progression, leakage-safe CV
data/
  raw/       riyasewana.csv, ikman.csv          (scraper output; caches gitignored)
  clean/     vehicles.csv + audit/metric JSON   (the modelling dataset)
report/                            ← per-phase report sections (drafts)
diagrams/    system-overview.mmd   (renders on GitHub; export PNG for the Word report)
experiment-log.md                  ← dated debugging narrative (Model Implementation, 30%)
```

## Running it

**The notebook (Colab or local):** open `notebooks/vehicle_price_prediction.ipynb`
and Run All. It reads `data/clean/vehicles.csv` from the repo, so it runs
end-to-end without the scrapers.

**Reproducing the dataset from scratch (local only):**

```bash
pip install -r requirements.txt

# collect (run over several sessions; both sites rate-limit)
python scrapers/riyasewana.py harvest --categories cars suvs vans
python scrapers/riyasewana.py fetch --limit 700 --delay 8 --max-cooldowns 6
python scrapers/riyasewana.py export --out data/raw/riyasewana.csv
python scrapers/ikman.py harvest --categories cars vans
python scrapers/ikman.py fetch --limit 4000 --delay 2
python scrapers/ikman.py export --out data/raw/ikman.csv

# clean + model
python pipeline/clean.py
python pipeline/baselines.py
python pipeline/train.py

# tests
python scrapers/test_parsing.py && python scrapers/test_ikman.py && python scrapers/test_backoff.py
```

## Data collection ethics

`robots.txt` for both sites was retrieved and respected. ikman search-filter
URLs are disallowed, so listings are reached via its published sitemap and
plain pagination; riyasewana's six disallowed endpoints are hard-blocked in
code. Requests are rate-limited with jitter and cached; when riyasewana
returned an HTTP 429 with a ~24h `Retry-After`, the scraper stopped and
reported rather than evading the limit. No personal data (names, phone
numbers) is stored — seller identity is kept only as a salted hash for
deduplication.

## Status

Phases 1–4 complete (problem framing, collection, cleaning pipeline, model
progression). Phase 5 (tuning + error analysis), Phase 6 (Streamlit
deployment) and Phase 7 (report consolidation) are in progress.
