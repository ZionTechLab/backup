"""
Phase 4 — trivial baselines.

    python pipeline/baselines.py

Two non-ML predictors that every real model must beat to justify its
complexity. This is the third success criterion from Section 1.6, made
concrete: if gradient boosting cannot beat a brand-and-year median by a
meaningful margin, the ML has added cost without value and the report should
say so.

  Baseline 0  global median      — the dumbest possible predictor
  Baseline 1  brand+year median  — the "informed human with a price guide"

Both are fit on TRAIN only and scored on VALIDATION. The test set is not
touched here; it is reserved for the single final evaluation in Phase 5.
"""

from __future__ import annotations

import json
from pathlib import Path

import numpy as np
import pandas as pd

CLEAN = Path("data/clean/vehicles.csv")
OUT = Path("data/clean/baseline_metrics.json")


def metrics(y_true: np.ndarray, y_pred: np.ndarray) -> dict:
    """MAE, RMSE, R², and median APE — the Section 1.6 metric set."""
    err = y_pred - y_true
    mae = float(np.mean(np.abs(err)))
    rmse = float(np.sqrt(np.mean(err**2)))
    ss_res = float(np.sum(err**2))
    ss_tot = float(np.sum((y_true - np.mean(y_true)) ** 2))
    r2 = 1 - ss_res / ss_tot if ss_tot > 0 else float("nan")
    ape = np.abs(err) / y_true
    return {
        "MAE": mae,
        "RMSE": rmse,
        "R2": r2,
        "MedAPE": float(np.median(ape)),
        "pct_within_25pct": float(np.mean(ape <= 0.25)),
    }


def show(name: str, m: dict) -> None:
    print(
        f"  {name:24s}  MAE {m['MAE']/1e6:5.2f}M  RMSE {m['RMSE']/1e6:5.2f}M  "
        f"R2 {m['R2']:5.3f}  MedAPE {m['MedAPE']*100:5.1f}%  "
        f"within25% {m['pct_within_25pct']*100:4.1f}%"
    )


def main() -> None:
    df = pd.read_csv(CLEAN)
    train = df[df.split == "train"]
    val = df[df.split == "val"]
    print(f"train {len(train)}   val {len(val)}\n")

    results = {}

    # --- Baseline 0: global median -------------------------------------
    gm = train.price_lkr.median()
    m0 = metrics(val.price_lkr.values, np.full(len(val), gm))
    results["global_median"] = m0
    show("global median", m0)

    # --- Baseline 1: brand+year median ---------------------------------
    # Fit a lookup on train; fall back through brand median then global
    # median for combinations unseen in training. The fallbacks matter —
    # without them, an unseen brand+year would produce NaN and silently
    # break the metrics.
    by = train.groupby(["brand_norm", "year"]).price_lkr.median()
    brand_med = train.groupby("brand_norm").price_lkr.median()

    def predict(row) -> float:
        key = (row.brand_norm, row.year)
        if key in by.index:
            return by[key]
        if row.brand_norm in brand_med.index:
            return brand_med[row.brand_norm]
        return gm

    preds = val.apply(predict, axis=1).values
    m1 = metrics(val.price_lkr.values, preds)
    results["brand_year_median"] = m1
    show("brand+year median", m1)

    OUT.write_text(json.dumps(results, indent=2), encoding="utf-8")
    print(f"\nwrote {OUT}")
    print(
        "\nThese are the numbers to beat. A real model that cannot improve on\n"
        "the brand+year median MedAPE is not earning its complexity."
    )


if __name__ == "__main__":
    main()
