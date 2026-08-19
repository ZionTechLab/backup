# Sri Lankan Used Vehicle Price Prediction — Project Plan

*Revised 18 Jul 2026 — robots.txt verified, leakage controls added, timeline reweighted to rubric.*

## Course Context
MSc Computer Science coursework: design, build, evaluate, and deploy a complete ML system.
Deliverables:
- One consolidated technical report (Word/PDF, submitted via Turnitin on Moodle)
- Working system deployed on Streamlit Community Cloud
- `.ipynb` notebook pushed to a GitHub repository

### Grading Rubric
| Section | Weight |
|---|---|
| Problem Definition and System Framing | 15% |
| Data Pipeline and Feature Handling | 25% |
| Model Implementation and Debugging | 30% |
| Experimental Evaluation and Model Selection | 20% |
| Presentation, Structure, and Communication | 10% |

Report must include: step-by-step development narrative, Streamlit app URL, screenshots of key code/outputs (not full dumps), evaluation visuals (charts, confusion matrices, error plots, metric tables, CV results), and diagrams (pipeline, model comparison, system overview).

## Project Idea
**Sri Lankan Used Vehicle Price Prediction** — chosen to be unique (not a common Kaggle dataset like churn/loan default). Data self-scraped from ikman.lk and riyasewana.com, which strengthens the Data Pipeline section since collection and cleaning are original work.

**Problem:** Buyers and sellers of used vehicles in Sri Lanka lack a reliable way to judge fair market price; pricing is often based on gut feeling or dealer negotiation.

**Why ML:** Price depends on many interacting features (brand, model, year, mileage, fuel type, transmission, engine capacity, location) — a good fit for supervised regression rather than fixed rules.

**Task framing:** Supervised regression, target variable = price (LKR).

### Framing caveats to state explicitly in the report
These are cheap marks in the 15% section and holes if omitted:

1. **The target is *asking* price, not transaction price.** Listings show what sellers ask, not what vehicles sold for. Actual sale prices in Sri Lanka are typically below asking after negotiation. The model predicts "what would this vehicle be listed at", which is still useful as a negotiation anchor — say so rather than letting a marker notice it first.
2. **Define the user and the decision.** A buyer sanity-checking one listing tolerates different error than a dealer pricing inventory. Pick one; it determines what counts as good enough.
3. **Set a success criterion up front.** e.g. "median absolute percentage error ≤ 15%, and 80% of predictions within 25% of asking price." Without this, Phase 5 collapses into "whichever model had the highest R²", which is weak justification.
4. **The dataset is a snapshot.** Sri Lankan vehicle prices have been unusually volatile because of import restrictions and their subsequent relaxation. Record the scrape window and note that the deployed model decays. Verify the current import-policy position before writing this up rather than relying on memory.

## Scraping Notes — robots.txt verified 18 Jul 2026

Both files were fetched and read. Findings below are specific and should be quoted in the report's ethics subsection; re-check before scraping since these files change.

### riyasewana.com — permissive
```
User-agent: *
Allow: /
Disallow: /vehicle_more.php, /login.php?, /add-favorite.php,
          /get-phone.php, /get-price-range.php, /sug.php
```
Listing and detail pages are allowed. Do **not** touch the six disallowed endpoints — note that `/get-price-range.php` and `/get-phone.php` are exactly the kind of thing a scraper is tempted to hit. No `Crawl-delay` is set for `*`, so set your own.

### ikman.lk — search URLs are disallowed; use the sitemaps
This changes the approach. Disallowed patterns include `/*?*filters=*`, `/*?*sort=*`, `/*?*type=*`, `/*?*query=*`, `/*?*tree.brand=*` and `/*--*`. That rules out the obvious method of paginating filtered search results.

The same file **publishes sitemaps**, including `https://ikman.lk/sitemap-listings-index.xml` and `sitemap-serp-index.xml`. Harvest listing URLs from the sitemap index, then fetch detail pages directly. This is compliant, more stable than parsing search HTML, and gives the report a strong, concrete ethics paragraph instead of a generic one.

Also note `CCBot`, `Baiduspider`, `Sogou` and `BLEXBot` are fully disallowed while `*` is not — worth a sentence on how robots.txt discriminates by agent, and set an honest descriptive User-Agent.

### General scraping practice
- Rate-limit to ~1 request/sec with jitter; scrape over several sessions rather than one burst.
- Cache raw HTML/JSON to disk before parsing, so re-parsing never means re-fetching.
- Record `scrape_timestamp` and `source_site` on every row. Both are needed later.
- Target: 3,000–10,000 listings **after** deduplication (see below) — the raw count will be meaningfully higher.
- Save raw data as scraped to CSV/SQLite; clean afterward in a separate step.

> Practical note: scraping must be run from your own machine. Claude can write and dry-test the parser against saved HTML fixtures, but cannot issue the live requests.

## Two-Site Reconciliation
Scraping both sites doubles the data and is good for the Pipeline section (25%), but only if the merge is done deliberately. Add this as explicit work, not an afterthought:

- **Canonical schema first.** Define the target columns, then write a per-site mapping into it. Do not merge two differently-shaped dataframes and patch afterwards.
- **Field mismatches to expect:** location granularity (district vs city), condition categories, transmission labels, mileage units (km vs miles), engine capacity (cc vs litres), and price formats ("Rs 5,650,000", "Rs. 56 lakhs", "Negotiable").
- **Brand/model normalisation.** "Toyota Premio", "TOYOTA Premio 260", "Premio" must resolve to the same thing across sites. This is the fiddliest part of the whole pipeline — budget real time for it.

## Leakage Controls — read before Phase 3
The highest-risk methodological error in this project is duplicate-listing leakage, and it will silently inflate every metric.

- **The same vehicle appears multiple times.** Sellers relist, dealers post the same stock repeatedly, and a vehicle may be on both sites. If near-identical rows land in both train and test, R² looks excellent and the model is worthless.
- **Deduplicate before splitting**, not after. Match on a fuzzy key (brand + model + year + mileage bucket + engine cc + seller/phone-adjacent fields), not exact row equality.
- **Fit preprocessing inside the CV folds.** Target encoding or scaling fitted on the full training set before cross-validation leaks the target into every fold. Use an sklearn `Pipeline` so each fold fits its own transformers.
- **High-cardinality `model` field.** With ~3k rows and several hundred model names, target encoding overfits badly. Set a minimum-count threshold and bucket rare models into `Other`.
- **Drop price-adjacent text.** Description fields often restate or hint at the price. Either exclude free text or verify it carries no price signal.
- **Touch the test set once**, at the very end, after the final model is chosen.

## Phased Plan

Time is reweighted toward the 30% and 25% sections. Report sections are written as each phase completes rather than deferred — a week-6 writing crunch is the most common way these projects lose the 10% presentation marks and rush the 20% evaluation section.

### Phase 1 — Problem Definition (Week 1, ~2 days)
- Define the real-world problem, the user, and the decision the prediction supports.
- State the asking-vs-transaction-price caveat and the success criterion.
- Frame task as supervised regression.
- Draw system overview diagram (scrape → clean → train → deploy).
- **Write the Problem Definition report section now, while it is fresh.**

### Phase 2 — Data Collection (Week 1–2)
- Re-verify robots.txt for both sites on the day you scrape; screenshot both files.
- riyasewana: paginate listing pages → detail pages, avoiding the six disallowed endpoints.
- ikman: pull `sitemap-listings-index.xml` → filter to vehicle listings → fetch detail pages.
- Cache raw responses; parse from cache.
- Record `scrape_timestamp` and `source_site` per row.
- Screenshot scraper code and raw output for the report.

### Phase 3 — Data Pipeline & Features (Week 2–3)
- Map both sites into the canonical schema.
- Parse price strings to numeric; handle lakhs notation; drop "negotiable"/missing prices.
- **Deduplicate within and across sites — before any split.**
- Normalise units, brands, and model names.
- Extract features: brand, model, year, mileage, fuel type, transmission, engine cc, district.
- Handle outliers (luxury vehicles, obvious typos, implausible mileage).
- EDA: distributions, price vs year/mileage, correlation heatmap, per-site comparison.
- Encoding (fold-safe target encoding / one-hot), scaling, log-transform price if skewed.
- Train/validation/test split — stratify by price band so all splits span the range.
- Draw data pipeline diagram.
- **Write the Data Pipeline report section now.**

### Phase 4 — Model Implementation & Debugging (Week 3–4, largest allocation)
- **Trivial baselines first:** global median price, then brand+year median. These make the ML lift measurable and cost an hour.
- Then Linear Regression → Ridge/Lasso → Random Forest → XGBoost/LightGBM.
- Hyperparameter tuning (GridSearch/Optuna), feature importance, error analysis on worst predictions.
- If log-transforming the target, handle **retransformation bias** when converting predictions back to LKR — naive `exp()` of a mean-log prediction is biased low. Worth a paragraph; markers notice it.
- **Keep a running experiment log from day one** — date, what changed, hypothesis, result. This is the 30% section, and a debugging narrative reconstructed at week 5 reads as reconstructed. A dated log written as you go is the single highest-leverage habit in this project.
- Screenshot each meaningful debugging step into a dated folder as you go.
- **Write the Model Implementation section now.**

### Phase 5 — Evaluation & Selection (Week 4–5)
- Metrics: MAE, RMSE, R², and **median** APE (plain MAPE is unstable on low-priced vehicles).
- 5-fold cross-validation comparison table, preprocessing inside the pipeline.
- Residual plots, predicted-vs-actual plots, error broken down by price band and by source site.
- Justify the final model against the Phase 1 success criterion, not just the best R².
- Single final evaluation on the held-out test set.
- **Write the Evaluation section now.**

### Phase 6 — Deployment (Week 5)
- Build Streamlit app: input form → predicted price, ideally with a prediction interval.
- **Serialise the entire fitted Pipeline**, not just the estimator, so the app applies identical preprocessing.
- **Pin library versions** in `requirements.txt` to match the training environment — sklearn/XGBoost version drift between local training and Streamlit Cloud is the most common deployment failure here.
- Handle unseen categories at inference (user selects a model absent from training data).
- Push app code + notebook to GitHub; deploy on Streamlit Community Cloud; verify the live URL works from a different device.

### Phase 7 — Report Consolidation (Week 5–6)
Sections are already drafted, so this is assembly rather than writing:
- Consolidate, add the development narrative connecting phases.
- Insert diagrams, screenshots, metric tables.
- Include the Streamlit app URL and GitHub link.
- Proofread; check Turnitin similarity; submit via Moodle.

## Repo Layout
Scraping in a notebook is painful and the notebook is a graded deliverable — keep them separate:

```
/scrapers      # .py scripts — riyasewana.py, ikman.py, run from your machine
/data/raw      # cached responses + raw CSV (gitignore if large)
/data/clean    # canonical, deduplicated dataset
/notebook      # the graded .ipynb — pipeline, modelling, evaluation
/app           # streamlit_app.py + requirements.txt
/screenshots   # dated folders, captured as you go
/report        # per-phase section drafts
experiment-log.md
```

## Next Step
Phase 2 — build the two scrapers. riyasewana first (simpler HTML, faster to a working dataset), then ikman via the sitemap route.
