# Sri Lankan Used Vehicle Price Estimator — Model Card

*Model cards provide essential information about a machine learning system: its purpose, the data behind it, how it performs, and its known limitations and responsible-use boundaries. This card documents the vehicle price estimator developed in Portfolio Task 1.*

**Author:** M.A.A.T. Perera (S25021960) · **Module:** COM763 Advanced Machine Learning
**Model type:** Random Forest regressor · **Version:** 1.0 · **Status:** Research prototype
**Last updated:** July 2026

---

## 1. Model Overview and Intended Use

**Description.** The Sri Lankan Used Vehicle Price Estimator is a supervised machine learning model that predicts the fair market *asking price* of a used car from its observable attributes. It addresses a real-world problem: Sri Lanka has no public, reliable reference for used-vehicle values, so private buyers and sellers set prices through informal comparison and dealer negotiation, in which the individual is usually the least-informed party. The problem has been sharpened by recent regulatory shocks — the February 2025 reopening of vehicle imports, a subsequent 50% customs-duty surcharge, and a new Social Security Contribution Levy — which have made pre-2025 pricing intuition unreliable.

**Intended users and context.** The model is built for two consumer-facing users: a **prospective buyer** checking whether a listing is reasonably priced, and a **private seller** deciding what to ask for their vehicle. It is delivered as an interactive web dashboard where a user enters vehicle attributes and receives an indicative price. It is intended as a *negotiation reference and sanity check*, not an authoritative valuation.

**Appropriate uses.** Estimating a plausible listing price for a common used car in Sri Lanka; comparing an advertised price against a data-driven benchmark; understanding how attributes such as age and mileage influence value.

**Non-intended and inappropriate uses.** The model must **not** be used for: loan collateral or insurance valuation; legal, tax, or customs assessment; automated dealer inventory pricing; or any decision treated as a guaranteed transaction price. It is not valid outside Sri Lanka, outside its data window, or for vehicle classes it was not trained on (motorcycles, three-wheelers, commercial and heavy vehicles).

## 2. System and Data Summary

**Model type.** A Random Forest regression ensemble, selected over Linear Regression and XGBoost baselines for its lowest absolute error.

**Inputs and output.**

| Inputs (vehicle attributes) | Output |
|---|---|
| Brand, model, year of manufacture, mileage, transmission, fuel type, engine capacity, location, listing source | Estimated asking price in Sri Lankan Rupees (LKR) |

**Data summary.** The model was trained on **4,212 vehicle listings** collected from Sri Lanka's two largest classified platforms, ikman.lk (3,724) and Riyasewana (488). After removing duplicates and implausible records, **2,764 clean listings** formed the modelling dataset. The data reflects the market during the collection window in mid-2026 and is dominated by common brands (Toyota 31%, Suzuki 22%, Nissan 13%).

**Key assumption.** The target is the *listed asking price*, not the final transaction price. Sri Lankan sales typically settle below the advertised figure, so the model estimates what a vehicle would reasonably be *listed* at — which is the quantity both intended users actually need.

## 3. Evaluation and Performance Summary

**How it was evaluated.** Performance was measured on a **held-out test set of 629 listings** (20% of the data) that the model never saw during training. This mirrors real use, where the model must price vehicles it has not encountered. The headline metric is the **median absolute percentage error (MedAPE)** — the typical percentage gap between predicted and listed price — chosen because it is robust to a handful of very expensive vehicles that would distort an average.

**Key results (held-out test set).**

| What it measures | Result |
|---|---|
| Typical error (MedAPE) | **8.2%** |
| Predictions within ±25% of the listed price | **82%** |
| Share of price variation explained (R²) | **0.876** |
| Average error in Rupees (MAE) | **Rs. 2.06M** |

In plain terms, a typical estimate lands within about 8% of the advertised price, and roughly four in five estimates fall within a quarter of it. This comfortably beats the project's pre-set success targets (MedAPE ≤ 15%; ≥ 80% within ±25%) and a simple "brand-and-year average" benchmark, which achieved only 18.3% MedAPE.

**Evaluation limitations.** Accuracy is uneven across the market. The model is most reliable for common, mid-priced vehicles that are well represented in the data, and least reliable for rare models and for very high-value vehicles (above ~125M LKR), which it tends to underestimate. Because the test data comes from the same short time window as the training data, these figures describe performance *at that moment* and may not hold as the market moves.

## 4. Limitations, Risks, and Responsible Use

**Asking price, not sale price.** The single most important limitation: outputs represent advertised prices, which are typically higher than what buyers actually pay. Users should treat an estimate as a negotiation starting point, never as the value a vehicle will sell for.

**A perishable snapshot.** Sri Lanka's vehicle market is unusually volatile due to the 2025 import reopening and the 2026 duty and levy changes. The model reflects only its collection window and will drift out of date; a figure that is fair today may mislead within months. Responsible deployment requires periodic retraining and clear display of the data's date.

**Sparse and uneven data.** Very few listings exist for model years 2020–2022 (25, 16 and 11 records respectively), a direct trace of the import ban. Predictions in that range are extrapolation and should be treated with low confidence. The data also concentrates geographically in the Western Province (Kohuwala, Boralesgamuwa, Dehiwala), so valuations for other regions are less well supported, and rarer models were grouped into an "other" category covering about a quarter of records.

**Risks and misuse.** The chief societal risk is *false authority* — a confident-looking figure being treated as definitive, disadvantaging a user in negotiation or, worse, being used by a third party (a lender or insurer) for a purpose it was never validated for. This is why such uses are explicitly excluded above. Presenting the estimate as a range, with its uncertainty visible, mitigates this.

**Data ethics.** Collection respected each site's `robots.txt`, used rate limiting to avoid burdening the servers, and stopped rather than circumventing access limits. No personal data was retained: seller identities are stored only as salted SHA-256 hashes for deduplication, consistent with GDPR pseudonymisation principles.

**Deployment transparency.** The trained Random Forest is the intended production model; where a lightweight fallback estimator is served instead, this should be disclosed so users are not misled about which system produced their estimate.

---

## 5. References

The system, methodology, and evaluation summarised here are documented in full in the Task 1 technical report and accompanying notebook. Core methods: Breiman (2001), *Random Forests*; Duan (1983), *Smearing Estimate*; Kaufman et al. (2012), *Leakage in Data Mining*. Market context: EconomyNext (2025); MotorGuide (2026). Data sources: ikman.lk (2026); Riyasewana (2026).
