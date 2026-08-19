"""
Phase 3 — cleaning pipeline.

    python pipeline/clean.py

Reads data/raw/{riyasewana,ikman}.csv, writes data/clean/vehicles.csv plus a
JSON audit trail of every decision and how many rows it touched.

Ordering is deliberate and load-bearing:

    load -> reconcile -> clean -> DEDUPLICATE -> split

Deduplication happens BEFORE the split. The same vehicle is relisted by
sellers, reposted by dealers, and occasionally appears on both sites. If
near-identical rows land on both sides of a train/test boundary the model is
scored on rows it effectively memorised, and every metric is inflated. This
is the single most consequential ordering choice in the project.

Nothing here silently corrects data. Every transformation is counted and
written to the audit file so the report can state exactly what was changed
and why.
"""

from __future__ import annotations

import json
import re
import sys
from pathlib import Path

import numpy as np
import pandas as pd

RAW = Path("data/raw")
OUT = Path("data/clean")
CURRENT_YEAR = 2026

# Plausibility bounds. Chosen from the Phase 2 profile, not from thin air:
# riyasewana carried a 1971 Morris Mini Cooper at Rs 33 and ikman a listing
# at Rs 810,000,000. Both are data entry artefacts rather than real prices.
PRICE_MIN = 150_000
PRICE_MAX = 200_000_000
MILEAGE_MAX = 1_000_000
YEAR_MIN = 1960

audit: dict[str, object] = {}


def note(key: str, value) -> None:
    audit[key] = value
    print(f"  {key}: {value}")


# --------------------------------------------------------------------------
# 1. Load and combine
# --------------------------------------------------------------------------

def load() -> pd.DataFrame:
    print("\n[1] load")
    frames = []
    for name in ("riyasewana", "ikman"):
        p = RAW / f"{name}.csv"
        if not p.exists():
            print(f"  ! {p} missing, skipping")
            continue
        df = pd.read_csv(p)
        print(f"  {name}: {len(df)} rows")
        frames.append(df)
    if not frames:
        sys.exit("No input CSVs found. Run the scrapers' export step first.")
    df = pd.concat(frames, ignore_index=True)
    note("rows_loaded", len(df))
    return df


# --------------------------------------------------------------------------
# 2. Reconcile the two sources
# --------------------------------------------------------------------------

def reconcile(df: pd.DataFrame) -> pd.DataFrame:
    print("\n[2] reconcile sources")

    # ikman separates Trim/Edition; riyasewana folds it into the model string.
    # Build one comparable model key across both.
    df["model_full"] = (
        df["model"].fillna("").astype(str).str.strip()
        + " "
        + df["trim"].fillna("").astype(str).str.strip()
    ).str.strip()

    # Brand and model normalisation. Source strings vary in case, spacing and
    # punctuation: "Mercedes-Benz" / "Mercedes Benz", "Wagon R" / "wagon-r".
    def norm_token(s: pd.Series) -> pd.Series:
        return (
            s.fillna("").astype(str).str.lower()
            .str.replace(r"[^a-z0-9]+", " ", regex=True)
            .str.strip()
            .str.replace(r"\s+", " ", regex=True)
        )

    df["brand_norm"] = norm_token(df["brand"])
    df["model_norm"] = norm_token(df["model_full"])
    note("brands_before_norm", int(df["brand"].nunique()))
    note("brands_after_norm", int(df["brand_norm"].nunique()))

    # Two model fields with different jobs, and conflating them is a trap.
    #
    # `model_norm` includes trim ("wagon r fz", "x trail t32 hybrid 2wd") and
    # is what deduplication needs — trim distinguishes genuinely different
    # vehicles. But it has ~2,350 distinct values across 4,000 rows, so using
    # it as a MODEL FEATURE pushed 77% of rows into the rare-category bucket
    # and destroyed the signal.
    #
    # `model_base` takes the FIRST token only, qualified by brand.
    #
    # Two tokens was tried first and failed: the second token is usually trim,
    # not model name. It split Yaris into yaris/yaris g/yaris x/yaris gr/
    # yaris grmn, Polo into polo r/polo sti/polo style, and Every into
    # every/every pa/every join — leaving 1,362 categories over 3,572 rows and
    # 46% of data in the rare bucket.
    #
    # One token over-truncates genuine multi-word names ("land cruiser" ->
    # "land", "x trail" -> "x"), but pairing it with the brand keeps the key
    # unambiguous: "toyota|land" and "nissan|x" identify exactly one vehicle
    # line each. The label is ugly; the grouping is correct, which is what
    # matters for a categorical feature.
    df["model_base"] = (
        df["brand_norm"] + "|" + df["model_norm"].str.split().str[0].fillna("")
    ).str.strip("|")
    note("model_with_trim_cardinality", int(df["model_norm"].nunique()))
    note("model_base_cardinality", int(df["model_base"].nunique()))

    # ikman gives "City, District"; riyasewana gives a bare city. Take the
    # coarsest available unit so the two are comparable.
    df["district"] = (
        df["location"].fillna("").astype(str)
        .str.split(",").str[-1].str.strip().str.lower()
    )
    note("districts", int(df["district"].nunique()))

    # Vans on ikman genuinely have no transmission or fuel type. Mark this
    # explicitly rather than imputing — tree models handle a category, and
    # inventing values would fabricate signal.
    for col in ("transmission", "fuel_type"):
        missing = df[col].isna()
        df[col] = df[col].fillna("unknown").astype(str).str.lower().str.strip()
        note(f"{col}_marked_unknown", int(missing.sum()))

    return df


# --------------------------------------------------------------------------
# 3. Clean values
# --------------------------------------------------------------------------

def clean_price(df: pd.DataFrame) -> pd.DataFrame:
    print("\n[3a] price")
    before = len(df)
    df = df[df["price_lkr"].notna()].copy()
    note("dropped_no_price", before - len(df))

    out_of_band = ~df["price_lkr"].between(PRICE_MIN, PRICE_MAX)
    note("dropped_price_out_of_band", int(out_of_band.sum()))
    df = df[~out_of_band].copy()
    note("price_median", f"{df['price_lkr'].median():,.0f}")
    return df


def clean_mileage(df: pd.DataFrame) -> pd.DataFrame:
    """
    Source-specific mileage repair.

    Phase 2 found riyasewana flagged 10.5% of rows as implausibly low against
    ikman's 0.4% — riyasewana accepts free-text entry, ikman validates the
    field. A 2017 Premio listed at "119 km" is near-certainly 119,000.

    The x1000 correction is applied ONLY where the implied value lands in a
    plausible band for the vehicle's age, and every corrected row is counted.
    Values that stay implausible are set to NaN rather than guessed at.
    """
    print("\n[3b] mileage")
    df["age"] = (CURRENT_YEAR - df["year"]).clip(lower=0)
    df["mileage_corrected"] = False

    is_new = df["condition"].isin(["new", "reconditioned"]) | (df["age"] <= 1)

    # Candidates: old vehicle, absurdly low reading, and x1000 lands sensibly
    implied = df["mileage_km"] * 1000
    fixable = (
        df["mileage_km"].notna()
        & ~is_new
        & (df["age"] >= 3)
        & df["mileage_km"].between(20, 999)
        & implied.between(20_000, 500_000)
    )
    df.loc[fixable, "mileage_km"] = implied[fixable]
    df.loc[fixable, "mileage_corrected"] = True
    note("mileage_x1000_corrected", int(fixable.sum()))

    # Remaining implausible values become missing rather than corrected.
    bad = df["mileage_km"].notna() & (
        ((df["mileage_km"] < 1000) & ~is_new & (df["age"] >= 3))
        | (df["mileage_km"] > MILEAGE_MAX)
    )
    df.loc[bad, "mileage_km"] = np.nan
    note("mileage_set_missing", int(bad.sum()))
    note("mileage_missing_total", int(df["mileage_km"].isna().sum()))
    return df


def clean_year(df: pd.DataFrame) -> pd.DataFrame:
    print("\n[3c] year")
    before = len(df)
    df = df[df["year"].between(YEAR_MIN, CURRENT_YEAR + 1)].copy()
    note("dropped_bad_year", before - len(df))
    df["age"] = (CURRENT_YEAR - df["year"]).clip(lower=0)
    return df


# --------------------------------------------------------------------------
# 4. Deduplicate — BEFORE any split
# --------------------------------------------------------------------------

def deduplicate(df: pd.DataFrame) -> pd.DataFrame:
    """
    Remove repeat listings of what is plausibly the same vehicle.

    Exact-row matching is not enough: a relisted vehicle gets a new advert id,
    and mileage may be re-entered slightly differently. Matching uses a fuzzy
    key — brand, normalised model, year, engine size and a 5,000 km mileage
    bucket — which tolerates small edits while staying tight enough not to
    collapse genuinely distinct vehicles.

    Cross-site duplicates are removed too. The riyasewana row is kept when a
    vehicle appears on both, purely so the smaller source is not eroded.
    """
    print("\n[4] deduplicate (before split)")
    before = len(df)

    df["mileage_bucket"] = (df["mileage_km"].fillna(-1) // 5000).astype(int)
    key = ["brand_norm", "model_norm", "year", "engine_cc", "mileage_bucket"]

    # Prefer riyasewana on cross-site collisions, then the cheaper listing id
    df["_pref"] = (df["source_site"] == "ikman").astype(int)
    df = df.sort_values(["_pref", "listing_id"]).drop_duplicates(subset=key, keep="first")
    df = df.drop(columns=["_pref"])

    note("rows_before_dedup", before)
    note("duplicates_removed", before - len(df))
    note("rows_after_dedup", len(df))
    return df


# --------------------------------------------------------------------------
# 5. Features
# --------------------------------------------------------------------------

def engineer(df: pd.DataFrame) -> pd.DataFrame:
    print("\n[5] features")

    df["log_price"] = np.log(df["price_lkr"])
    df["mileage_per_year"] = df["mileage_km"] / df["age"].replace(0, np.nan)

    # Import-regime cohort. Phase 2 confirmed a supply collapse for model
    # years inside the 2020-Feb 2025 suspension: ~140/yr before, 12 in 2022.
    # Predictions in that range rest on very few listings, so flag it as a
    # feature and so the app can widen its interval there.
    df["import_era"] = pd.cut(
        df["year"],
        bins=[0, 2019, 2022, 2026, 9999],
        labels=["pre_ban", "ban_window", "post_ban", "future"],
    ).astype(str)
    note("import_era_counts", df["import_era"].value_counts().to_dict())

    # High-cardinality guard. 77% of brand+model combinations appeared once in
    # the pilot; target encoding on a category seen once leaks the target
    # directly. Rare models collapse into an explicit bucket.
    # Group on model_base, NOT model_norm — see the note in reconcile().
    # Threshold of 5 keeps categories with enough rows to estimate from while
    # bounding how much of the data disappears into "other".
    counts = df["model_base"].value_counts()
    rare = counts[counts < 5].index
    df["model_grouped"] = df["model_base"].where(~df["model_base"].isin(rare), "other")
    note("models_before_grouping", int(df["model_base"].nunique()))
    note("models_after_grouping", int(df["model_grouped"].nunique()))
    other_n = int((df["model_grouped"] == "other").sum())
    note("rows_in_other_bucket", other_n)
    note("pct_in_other_bucket", f"{100 * other_n / len(df):.1f}%")
    if other_n / len(df) > 0.25:
        print("    WARNING: >25% of rows in 'other' — model feature is weak")
    return df


# --------------------------------------------------------------------------
# 6. Split
# --------------------------------------------------------------------------

def split(df: pd.DataFrame) -> pd.DataFrame:
    """
    Stratified by price band so all three splits span the price range.

    Test is touched once, at the very end of Phase 5, after the final model
    is chosen. Assigned here so that discipline is enforced by the data
    rather than by memory.
    """
    print("\n[6] split")
    rng = np.random.default_rng(42)
    df["price_band"] = pd.qcut(df["price_lkr"], q=10, labels=False, duplicates="drop")

    df["split"] = "train"
    for _band, idx in df.groupby("price_band").groups.items():
        idx = np.array(idx)
        rng.shuffle(idx)
        n = len(idx)
        df.loc[idx[: int(0.15 * n)], "split"] = "test"
        df.loc[idx[int(0.15 * n): int(0.30 * n)], "split"] = "val"

    note("split_counts", df["split"].value_counts().to_dict())
    for s in ("train", "val", "test"):
        med = df.loc[df["split"] == s, "price_lkr"].median()
        print(f"    {s:5s} median price Rs {med:,.0f}")
    return df


# --------------------------------------------------------------------------

def main() -> None:
    OUT.mkdir(parents=True, exist_ok=True)

    df = load()
    df = reconcile(df)
    df = clean_price(df)
    df = clean_year(df)
    df = clean_mileage(df)
    df = deduplicate(df)
    df = engineer(df)
    df = split(df)

    print("\n[7] write")
    out = OUT / "vehicles.csv"
    df.to_csv(out, index=False)
    note("rows_final", len(df))
    note("source_mix", df["source_site"].value_counts().to_dict())
    note("body_type_mix", df["body_type"].value_counts().to_dict())

    audit_path = OUT / "cleaning_audit.json"
    audit_path.write_text(json.dumps(audit, indent=2, default=str), encoding="utf-8")
    print(f"\nwrote {out} ({len(df)} rows)")
    print(f"wrote {audit_path} — every decision and its row count, for the report")


if __name__ == "__main__":
    main()
