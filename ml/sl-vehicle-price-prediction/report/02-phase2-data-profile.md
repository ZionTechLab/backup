# Phase 2 — Data Collection Profile

*Both sources, collected 18 July 2026. Supersedes the earlier cars-only pilot.*

## 1. Collection outcome

| | riyasewana | ikman |
|---|---|---|
| Listing URLs harvested | 7,255 | 3,764 |
| Detail pages fetched | 488 | 3,724 |
| Parse failures | 0 | 0 |
| Rows exported | 488 | 3,724 |
| Body types | car only *(see §6)* | car 1,809 / SUV 1,056 / van 859 |

**Total: 4,212 listings.**

### Rate limiting shaped the dataset

riyasewana returned HTTP 429 after roughly 700 requests and issued
`Retry-After: 85687` — a ~24-hour hard limit. Delay was raised from 1.5s to
4s and then 8s; the limit is volume-based, not rate-based, so slowing down
did not help. riyasewana therefore contributes ~700 listings/day and remains
a supplementary source.

ikman served 3,724 requests at 1s spacing with **zero** throttling.

This is worth reporting rather than hiding: the constraint was detected,
respected, and documented, and it materially shaped the collection design.
No attempt was made to evade it by rotating addresses or spoofing agents.

## 2. Field completeness

| Field | riyasewana | ikman |
|---|---|---|
| brand, model, year, engine_cc, condition | 100% | 99.9% |
| price_lkr | **73.2%** | **99.9%** |
| mileage_km | 98.0% | 99.9% |
| transmission, fuel_type | 100% | **79.5%** |
| location | 100% | 98.0% |
| trim | n/a (folded into model) | 79.4% |

Two gaps are structural rather than accidental, and both are explained below.

## 3. Finding — the import ban replicates on an independent source

Section 1.7 of the Problem Definition predicted, before any collection, that
model years inside the 2020–February 2025 import suspension would be sparse.
The riyasewana pilot supported it on 488 cars. **ikman confirms it on 2,959
independent listings, and reveals a fuller shape.**

| Model year | ikman listings |
|---|---|
| 2015 | 151 |
| 2016 | 114 |
| 2017 | 158 |
| 2018 | 176 |
| 2019 | 92 |
| **2020** | **35** |
| **2021** | **21** |
| **2022** | **12** |
| 2023 | 218 |
| 2024 | 338 |
| 2025 | 468 |
| 2026 | 758 |

Supply falls from ~140/year to a trough of 12 in 2022, then rises steeply
from 2023 as post-February-2025 imports arrive. The 2026 cohort alone is
larger than 2015–2017 combined.

Consequences for modelling:

1. `year` encodes import regime as well as age, as anticipated.
2. **2020–2022 is a genuine extrapolation zone.** Predictions there rest on
   68 listings across three model years. The deployed application should
   widen or withhold its estimate in that range rather than answer
   confidently.
3. The prediction was registered in Section 1.7 before collection and
   confirmed on two independent sources. Present it that way — a
   pre-registered hypothesis tested against data is a materially stronger
   claim than the same pattern noticed afterwards.

## 4. Finding — a source effect that must be controlled

The two sites do not price alike, and the difference survives every obvious
control.

Cars only, priced, by condition (median LKR):

| Condition | riyasewana | ikman |
|---|---|---|
| used | **5,200,000** (n=329) | **7,150,000** (n=973) |
| reconditioned | 8,200,000 (n=17) | 8,897,500 (n=312) |
| new | 8,820,000 (n=10) | 11,250,000 (n=469) |

Restricting to **used cars only** — same body type, same condition — ikman
listings are still **38% higher**. This is not a composition artefact.

Implications:

- `source_site` must be retained as a feature or control. Pooling the two
  sources without it builds a model whose predictions depend on an unmodelled
  marketplace effect.
- ikman also skews far more heavily to new and reconditioned stock (43% of
  cars vs riyasewana's 8%), consistent with it carrying more of the
  post-ban import surge.
- Worth a paragraph in Evaluation: does a model trained on one source
  transfer to the other? Fitting on ikman and testing on riyasewana is a
  cheap and genuinely informative robustness check.

## 5. Finding — data quality differs sharply by source

**Mileage.** riyasewana flagged 51/488 (**10.5%**) implausibly low; ikman
flagged 15/3,724 (**0.4%**). riyasewana appears to accept free-text mileage
entry — a 2017 Premio listed at "119 km" is almost certainly 119,000 — while
ikman validates the field. Correction logic is therefore needed mainly for
riyasewana rows, and Phase 3 should treat the two sources separately:

| Pattern | Likely cause | Handling |
|---|---|---|
| 0 or 1 km on an old vehicle | field not filled | treat as missing |
| 100–200 km on a modern vehicle | entered in thousands | candidate ×1000, flag every change |
| >1,000,000 km | typo | cap or treat as missing |

**Price outliers.** riyasewana: a 1971 Morris Mini Cooper at **Rs 33**.
ikman: minimum **Rs 2,541**, maximum **Rs 810,000,000**. A plausibility band
is required before training; all values are retained raw at collection time.

## 6. Finding — schema asymmetries between sources

Resolved in `schema.py` at collection time so Phase 3 inherits one vocabulary:

- **Condition.** riyasewana `Registered (Used)` ≡ ikman `Used` → `used`.
  Both sources now emit `used / reconditioned / new / antique`. ikman adds
  `import` (96 rows), kept distinct rather than folded into `reconditioned`
  since the two have not been confirmed equivalent.
- **Body type.** ikman files SUVs under `cars` with body type as a field;
  riyasewana treats SUV as a separate category. Both now map to
  car / suv / van.
- **Trim.** ikman separates `Trim / Edition`; riyasewana folds it into the
  model string. Concatenate model+trim on ikman rows before cross-site
  comparison.
- **Van schema (ikman).** Van listings carry a *reduced* field set —
  Brand, Model, Trim, Condition, Model year, Mileage, Engine capacity. They
  have **no Transmission and no Fuel type at all.** This is genuine absence,
  not a parse failure, and accounts for the 79.5% completeness above.
  Options: explicit "missing" category (tree models handle it natively),
  imputation, or excluding vans. The explicit category is recommended — it
  retains 859 rows and states the limitation honestly.

**Sampling caveat.** All 488 riyasewana rows are cars: `fetch` originally
selected URLs in insertion order and cars were harvested first. Fixed
(`ORDER BY RANDOM()`), but riyasewana's SUV and van coverage remains
outstanding pending the daily rate limit.

## 7. Cross-site duplication

Only **9** brand+model+year+mileage keys appear on both sites — cross-site
duplication is currently negligible. Within-source seller concentration
remains the larger leakage risk: one riyasewana seller posted 18 listings,
and 51 sellers posted more than one. `GroupKFold` on `seller_hash` should be
compared against a random split in Phase 5.

## 8. Recommended next steps

1. Continue riyasewana in daily ~700-listing batches; harvest its SUV and van
   categories so the source is not cars-only.
2. Optionally deepen ikman — 2,998 of 8,307 cars harvested so far.
3. Begin Phase 3 on current data. 4,212 rows is already inside the
   3,000–10,000 target, and the cleaning decisions above are well specified.
