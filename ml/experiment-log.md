# Experiment Log — Sri Lankan Used Vehicle Price Prediction

*Kept as work happens, not reconstructed afterwards. This is the primary
evidence for the Model Implementation & Debugging section (30%). Each entry:
date, what changed, the hypothesis, the result, and the decision it led to.*

Target: `log_price` (log LKR). Metrics reported on the **validation** split.
Test set is untouched until the single final evaluation.

Success criteria (from Problem Definition §1.6):
- MedAPE ≤ 15%
- ≥ 80% of predictions within ±25% of asking price
- must beat the brand+year median baseline

---

## 2026-07-18 — Baselines established

**What:** Two non-ML predictors, fit on train, scored on validation.

| Predictor | MAE | RMSE | R² | MedAPE | within 25% |
|---|---|---|---|---|---|
| Global median | 8.26M | 16.82M | −0.087 | 40.1% | 29.9% |
| Brand + year median | 4.64M | 12.78M | 0.372 | 18.3% | 62.1% |

**Reading it:**
- Global median R² is *negative* on validation — worse than predicting the
  validation mean. Expected: the median is fit on train, and the two splits
  differ slightly, so a constant carries no explanatory power.
- The brand+year median is a strong floor at **18.3% MedAPE**, only 3 points
  off the 15% target. This is the number every real model must beat. If a
  gradient-booster lands near 18% it has added complexity for nothing.
- 62% already within ±25% from a lookup table alone — the ±25%/80% criterion
  is achievable but not trivial.

**Decision:** brand+year median is the reference line. Report improvements
against it, not against the global median (which is a straw man).

**Note for the report:** the strength of the simple baseline is itself a
finding. Vehicle price in this market is largely explained by make and year;
the ML's job is to capture the *residual* structure — mileage, condition,
body type, the import-era effect, source differences — that the lookup misses.

---

## 2026-07-18 — Retransformation-bias bug (metrics contradiction)

**What:** First run of the full pipeline (Linear/Ridge/Lasso) with log-price
target, predictions back-transformed to LKR for scoring.

**Symptom:** Linear R² = 0.46 (respectable) but MedAPE = 52.6% — *three times
worse than the brand+year baseline*. A model can't be simultaneously decent
on R² and catastrophic on percentage error unless something systematic is
shifting every prediction.

**Diagnosis:** The back-transform `exp(log_pred + σ²/2)` used the wrong σ².
I passed the **target** variance (0.834) where the bias correction needs the
**residual** variance (0.109). exp(0.834/2) = 1.52, so every prediction was
inflated by 52% — which is exactly the MedAPE that appeared. R² survived
because it is scale-sensitive in a different way and partly absorbed the
shift.

Isolation run (Ridge, one fold set):

| Back-transform | MedAPE | within 25% |
|---|---|---|
| none — `exp(log_pred)` | 11.7% | 78% |
| **wrong (target var)** | **52.9%** | **14%** |
| correct (residual var) | 13.0% | 74% |

**Fix:** estimate residual variance per model from its own out-of-fold
residuals, `var(y_log − log_pred)`, not from the target.

**Lesson for the report:** a healthy R² next to a broken MedAPE is a
back-transform smell, not a modelling failure. The two metrics disagreeing is
the diagnostic. Cost ~15 minutes because the metrics were computed in LKR
(where the report's claims live) rather than in log space (where the bug is
invisible).

---

## 2026-07-18 — Model progression, leakage-safe, corrected metrics

**What:** Five models, each an sklearn Pipeline (preprocessing fit inside
every fold), 5-fold **GroupKFold grouped by seller_hash**, residual-var
back-transform. Development set = train+val (3,040 rows); test sealed.

| Model | MAE | R² | MedAPE | within 25% |
|---|---|---|---|---|
| brand+year median *(baseline)* | 4.64M | 0.372 | 18.3% | 62.1% |
| LinearRegression | 3.56M | 0.651 | 13.1% | 74.4% |
| Ridge | 3.55M | 0.634 | 13.0% | 74.3% |
| Lasso | 7.49M | −35.2 | 23.8% | 52.0% |
| **RandomForest** | **2.44M** | **0.843** | **9.1%** | **81.1%** |
| HistGradientBoosting | 2.52M | 0.853 | 10.6% | 80.5% |

**Reading it:**
- **Both success criteria met.** RandomForest: MedAPE 9.1% ≤ 15%, and 81.1%
  within ±25% ≥ 80%. It also halves the baseline's error, so the ML clearly
  earns its complexity — the third criterion.
- Linear/Ridge already beat the baseline (13% vs 18%), confirming the
  hypothesis that using mileage and condition continuously helps. The tree
  models add a further 4 points by capturing interactions (mileage×age,
  condition×import_era) a linear model can't.
- **Lasso is broken** (R² −35). alpha=0.01 on standardised log-price features
  over-shrinks and it is effectively predicting a near-constant. Not a real
  competitor as configured — next step is to tune alpha by CV rather than
  drop it, since a working Lasso is a useful feature-selection story.
- RF and HGB are within noise of each other. RF wins on MedAPE, HGB on R²;
  the choice will come down to Phase 5 error analysis and calibration, not
  this table alone.

**Decisions:**
1. Carry RandomForest and HistGradientBoosting to Phase 5 tuning + error
   analysis. Drop plain Linear (dominated); keep Ridge as the interpretable
   reference.
2. Fix Lasso alpha via CV before writing it off.
3. GroupKFold matters: these numbers are seller-grouped, so they are not
   inflated by a seller straddling train/val. Re-run with plain KFold once to
   quantify the optimism gap — that comparison is a reportable result.

**Next:** hyperparameter tuning on the two tree models, feature importance,
and error analysis on the worst predictions.
