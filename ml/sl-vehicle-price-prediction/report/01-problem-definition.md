# 1. Problem Definition and System Framing

*Rubric weight: 15%. Draft — rewrite in your own voice before submission (see note at end).*

## 1.1 Problem Statement

Sri Lanka's used vehicle market operates without a public, reliable price reference. Buyers and private sellers establish prices largely through informal means: comparison against a handful of similar listings, advice from acquaintances, or negotiation with dealers who hold considerably better market information than the individuals they transact with. The result is an information asymmetry in which the least-informed party in a transaction is usually the private individual.

The consequence is measurable in individual terms. A private seller who under-prices a vehicle by 10% on a Rs. 8M listing forfeits Rs. 800,000. A buyer who over-pays by the same margin absorbs an equivalent loss. Neither party currently has an accessible instrument for checking whether a given asking price is reasonable for the vehicle's attributes.

This project develops a machine learning system that predicts the market asking price of a used vehicle in Sri Lanka from its observable characteristics, and deploys it as a publicly accessible web application.

## 1.2 Intended Users and the Decision Supported

The system targets two consumer-side users, both of whom face the same underlying estimation problem from opposite sides of a transaction:

**The prospective buyer**, who has found a listing and wants to know whether the asking price is consistent with the market for comparable vehicles. The decision supported is whether to pursue, negotiate, or dismiss a particular listing.

**The private seller**, who owns a vehicle and must decide what to list it at. The decision supported is the selection of an initial asking price.

Both users are served by the same prediction, and both are well matched to the available data — a point developed in Section 1.5. Motor traders are explicitly *not* the target user. Dealers require transaction prices and margin analysis rather than asking-price estimates, and serving them properly would demand data this project cannot obtain.

Framing the users this way has a direct methodological consequence: because neither user is making an automated or high-frequency decision, the system does not need extreme point accuracy. It needs to be reliably approximately right, and it needs to communicate its own uncertainty. This shapes the success criterion in Section 1.6.

## 1.3 Justification for a Machine Learning Approach

A rule-based valuation system is conceivable — depreciation schedules of the form "deduct *n*% per year from list price" are widely used informally. Such rules fail here for three reasons.

First, the relationship between price and its determinants is **non-linear**. Depreciation is steepest in a vehicle's early years and flattens thereafter; mileage penalties accelerate past service thresholds rather than accruing linearly.

Second, the determinants **interact**. The price effect of high mileage differs between a Toyota and a marque with weaker local parts availability. The premium attached to an automatic transmission differs across vehicle segments. A rule system would require a separate hand-tuned rule for each combination, and the combinatorics defeat manual specification.

Third, the relevant knowledge is **tacit and undocumented**. No published Sri Lankan depreciation table exists at the model level. The information is distributed across thousands of individual listings, which is precisely the form supervised learning is suited to exploit.

Supervised regression learns these non-linearities and interactions directly from observed market data without requiring them to be specified in advance.

## 1.4 Task Framing and Scope

**Task type:** Supervised regression.
**Target variable:** Listed asking price, in Sri Lankan Rupees (LKR).
**Predictors:** Brand, model, year of manufacture, mileage, fuel type, transmission, engine capacity, body type, and district.

### Vehicle scope

The dataset covers **cars, vans and SUVs**, excluding motorcycles and three-wheelers. Three considerations drive this boundary.

Motorcycles and three-wheelers trade one to two orders of magnitude below four-wheeled vehicles. Including them would produce a model whose apparent accuracy is dominated by the trivial distinction between vehicle classes rather than by genuine within-market discrimination — an inflated R² that reflects nothing useful. If a coefficient of determination is high because the model has learned that motorcycles cost less than cars, it has learned nothing a buyer needs.

Restricting to cars alone, however, creates a different problem. The category boundaries used by ikman.lk and riyasewana.com between "car", "SUV" and "jeep" are inconsistently applied by the sellers who post the listings, so a cars-only dataset would require an arbitrary and unreliable filtering rule imposed on already-noisy source taxonomy.

Cars, vans and SUVs share a common order of magnitude in price, which keeps a single regression target coherent, while body type becomes a genuine predictive feature rather than a class label the model trivially exploits.

## 1.5 Data Source and Its Principal Limitation

Data is collected by scraping public listings from ikman.lk and riyasewana.com, the two dominant vehicle classified platforms in Sri Lanka. Collection is original to this project; no existing dataset is used.

**The target variable is asking price, not transaction price.** This distinction is material and must be stated plainly rather than glossed. Listings record what sellers request, not what buyers ultimately paid. Sri Lankan used vehicle transactions typically involve negotiation, and final prices generally settle below the listed figure.

Three points follow.

The system predicts *what a vehicle of these characteristics would typically be listed at* — not its resale value or its transaction price. All interpretation of outputs must respect that.

For the two intended users, this is nonetheless the right quantity. A buyer evaluating a listing is comparing against other listings; a seller choosing an asking price is choosing a listing price. Both questions are natively expressed in asking-price terms. The limitation would be disqualifying for a dealer-facing tool, which is part of why that user was excluded.

Transaction price data is not publicly available in Sri Lanka, so no feasible alternative exists at this project's scale. The constraint is acknowledged rather than worked around, and the deployed application will state it explicitly to users.

## 1.6 Success Criteria

Defining success before modelling begins prevents model selection from degenerating into "whichever configuration produced the highest R²". The system is considered successful if it satisfies all three:

| Criterion | Threshold | Rationale |
|---|---|---|
| Median absolute percentage error | ≤ 15% | Consistent with published used-vehicle price models; sufficient for a negotiation anchor |
| Predictions within ±25% of asking price | ≥ 80% of test set | Bounds the tail; a tool that is occasionally wildly wrong is not trustworthy |
| Improvement over baseline | Materially better than a brand-and-year median predictor | Establishes that machine learning is earning its complexity |

The third criterion is the most important and the most commonly omitted. If a sophisticated gradient-boosted model cannot beat the median price of its brand-and-year cohort by a meaningful margin, the modelling has added cost without value, and the report should say so.

Median absolute percentage error is preferred to the conventional mean because percentage errors on lower-priced vehicles are unstable and disproportionately influence the mean.

## 1.7 Market Context and Its Implications for the Data

Sri Lanka's vehicle market has been unusually volatile, and this bears directly on both data interpretation and the system's useful lifetime.

Private vehicle imports were suspended in early 2020 amid a foreign exchange shortage, and the restriction remained in force for approximately five years. Imports resumed on 1 February 2025 under a tax regime in which duties can exceed 250% of a vehicle's cost, insurance and freight value. More recently, in June 2026, the customs valuation discount previously applied to imported used vehicles was withdrawn, which the Vehicle Importers Association has indicated will push retail prices for imported used vehicles upward.

Two implications follow for this project.

**Year of manufacture is confounded with import regime.** A vehicle's model year does not only proxy its age and accumulated wear; in the Sri Lankan context it also indicates which import and tax regime the vehicle entered the country under. Vehicles of model years falling within the suspension window largely could not be imported during that period, so the dataset should be expected to show a pronounced dip in listing volume across those cohorts. This is stated here as a **hypothesis to be tested during exploratory analysis in Phase 3**, not as an established fact — and confirming or refuting it against the collected data is itself a reportable finding.

**The model is a snapshot.** Because the market is actively repricing, the scrape window must be recorded and stated, and the deployed application must be understood to decay. A model trained on listings from one month will drift as the import surge and the June 2026 valuation change work through the market. The application should display its training data window to users.

## 1.8 Legal and Ethical Considerations

The `robots.txt` files of both target sites were retrieved and examined before any collection was designed.

**riyasewana.com** permits general crawling, with six specific endpoints disallowed — including `/get-price-range.php` and `/get-phone.php`. These are excluded from collection despite their apparent relevance, and personal contact information is not collected at all.

**ikman.lk** disallows URL patterns carrying search and filter parameters, which rules out the conventional approach of paginating filtered search results. The same file, however, publishes sitemap indices including `sitemap-listings-index.xml`. Listing URLs are therefore harvested from the published sitemap and detail pages fetched directly — an approach that is both compliant with the site's stated preferences and more robust than parsing search result markup.

Requests are rate-limited with jitter and distributed across sessions to avoid imposing load. Responses are cached locally so that re-parsing never requires re-fetching. Only publicly visible listing attributes are retained; no seller names, telephone numbers or other personal data enter the dataset.

## 1.9 System Overview

The end-to-end architecture is shown in `diagrams/system-overview.mmd`, spanning four stages: collection from the two sources, pipeline processing into a canonical deduplicated dataset, model development and selection, and deployment of the fitted pipeline as a Streamlit application.

The design point worth noting is that the **entire fitted preprocessing pipeline** — not merely the trained estimator — is serialised and deployed. Preprocessing applied at inference must be identical to that applied during training; separating them is a common and silent source of deployment failure.

---

> **Note on this draft:** this is a structured draft carrying the substantive reasoning and decisions. Rewrite it in your own voice before submission — both because the argument should be one you can defend in person, and because the submission goes through Turnitin. The `academic-writer` skill in this workspace is built for exactly that pass.

## Sources

- [Sri Lanka Resumes Used Car Imports After 5 Years](https://providecars.co.jp/blog/sri-lanka-resumes-private-car-and-motorcycle-imports-after-nearly-five-years)
- [Sri Lanka Used Car Market 2026 — Price Trends, Segment Data & Market Analysis](https://pricemart.lk/blog/sri-lanka-used-car-market-2026-price-data)
- [Used Car Prices Set to Climb as Sri Lanka Scraps 15% Valuation Discount](https://www.lankanewspapers.com/2026/06/17/used-car-prices-set-to-climb-as-sri-lanka-scraps-15-valuation-discount-warns-importers)
- [Sri Lanka Vehicle Import Restrictions Relaxed: New Rules for 2026 | MotorGuide](https://motorguide.lk/en/news-advice/sri-lanka-vehicle-import-restrictions-relaxed-new-rules-for-2026)
- ikman.lk `robots.txt` and riyasewana.com `robots.txt`, retrieved 18 July 2026
