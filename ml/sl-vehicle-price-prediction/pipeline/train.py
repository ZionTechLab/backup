"""
Phase 4/5 — model progression, all leakage-safe.

    python pipeline/train.py

Every model is an sklearn Pipeline: preprocessing (impute, encode, scale) is
fitted INSIDE cross-validation, so no fold ever sees statistics computed from
its own validation rows. This is the single most important guard against the
optimistic-metrics trap flagged in the plan.

Target is log(price). Predictions are converted back to LKR with a
correction for retransformation bias (naive exp of a log-space mean is biased
low) before the business metrics are computed.

Progression, each justified in experiment-log.md:
    Linear -> Ridge -> Lasso -> RandomForest -> HistGradientBoosting
"""

from __future__ import annotations

import json
import warnings
from pathlib import Path

import numpy as np
import pandas as pd
from sklearn.compose import ColumnTransformer
from sklearn.ensemble import HistGradientBoostingRegressor, RandomForestRegressor
from sklearn.linear_model import LinearRegression, Ridge, Lasso
from sklearn.impute import SimpleImputer
from sklearn.model_selection import GroupKFold, cross_val_predict
from sklearn.pipeline import Pipeline
from sklearn.preprocessing import OneHotEncoder, StandardScaler

warnings.filterwarnings("ignore")

CLEAN = Path("data/clean/vehicles.csv")
OUT = Path("data/clean/model_metrics.json")

NUMERIC = ["year", "age", "mileage_km", "engine_cc"]
CATEGORICAL = ["brand_norm", "model_grouped", "body_type", "condition",
               "transmission", "fuel_type", "district", "import_era", "source_site"]


# --------------------------------------------------------------------------
# Metrics — computed in LKR, not log space, so they mean what the report says
# --------------------------------------------------------------------------

def back_transform(log_pred: np.ndarray, residual_var: float) -> np.ndarray:
    """
    exp(log_pred) is biased low as an estimate of the mean price. The
    correction multiplies by exp(sigma^2 / 2), where sigma^2 is the variance
    of the MODEL RESIDUALS (log y - log y_hat) — NOT the variance of the
    target.

    This distinction was a real bug (see experiment-log 2026-07-18): using
    the target variance (0.83) instead of the residual variance (0.11)
    inflated every prediction by ~52% and drove MedAPE from ~12% to 53% while
    R² still looked plausible. The mismatch between a healthy R² and a wrecked
    MedAPE was the tell.
    """
    return np.exp(log_pred + residual_var / 2)


def metrics(y_true_lkr: np.ndarray, y_pred_lkr: np.ndarray) -> dict:
    err = y_pred_lkr - y_true_lkr
    ape = np.abs(err) / y_true_lkr
    ss_res = float(np.sum(err**2))
    ss_tot = float(np.sum((y_true_lkr - np.mean(y_true_lkr)) ** 2))
    return {
        "MAE": float(np.mean(np.abs(err))),
        "RMSE": float(np.sqrt(np.mean(err**2))),
        "R2": 1 - ss_res / ss_tot if ss_tot else float("nan"),
        "MedAPE": float(np.median(ape)),
        "pct_within_25pct": float(np.mean(ape <= 0.25)),
    }


def show(name: str, m: dict) -> None:
    print(f"  {name:22s}  MAE {m['MAE']/1e6:5.2f}M  R2 {m['R2']:6.3f}  "
          f"MedAPE {m['MedAPE']*100:5.1f}%  within25% {m['pct_within_25pct']*100:4.1f}%")


# --------------------------------------------------------------------------

def build_preprocessor() -> ColumnTransformer:
    numeric = Pipeline([
        ("impute", SimpleImputer(strategy="median")),
        ("scale", StandardScaler()),
    ])
    categorical = Pipeline([
        ("impute", SimpleImputer(strategy="constant", fill_value="unknown")),
        ("onehot", OneHotEncoder(handle_unknown="ignore", min_frequency=5,
                                 sparse_output=False)),
    ])
    return ColumnTransformer([
        ("num", numeric, NUMERIC),
        ("cat", categorical, CATEGORICAL),
    ])


MODELS = {
    "LinearRegression": LinearRegression(),
    "Ridge": Ridge(alpha=1.0),
    "Lasso": Lasso(alpha=0.01),
    "RandomForest": RandomForestRegressor(
        n_estimators=150, max_depth=None, min_samples_leaf=3,
        n_jobs=2, random_state=42),
    "HistGradientBoosting": HistGradientBoostingRegressor(
        max_iter=400, learning_rate=0.05, max_depth=None,
        min_samples_leaf=20, random_state=42),
}


def main() -> None:
    df = pd.read_csv(CLEAN)
    dev = df[df.split.isin(["train", "val"])].copy()  # test stays sealed
    y_log = np.log(dev.price_lkr.values)
    y_lkr = dev.price_lkr.values
    groups = dev.seller_hash.fillna(dev.listing_id.astype(str)).values

    print(f"development rows: {len(dev)}  (train+val, test sealed)\n")

    # GroupKFold on seller_hash. Plan flagged this: 66 sellers span >1 split
    # under a random split, one seller has 26 listings, and a random fold lets
    # the model memorise a seller's pricing and be rewarded at test time.
    # Grouping forbids a seller from appearing in both train and validation
    # of any fold, giving an honest estimate.
    cv = GroupKFold(n_splits=5)

    results = {}
    print("5-fold GroupKFold CV (grouped by seller):")
    for name, est in MODELS.items():
        pipe = Pipeline([("prep", build_preprocessor()), ("model", est)])
        log_pred = cross_val_predict(pipe, dev, y_log, cv=cv, groups=groups)
        # Residual variance is per-model: estimate it from THIS model's
        # out-of-fold residuals, not from the target. See back_transform().
        residual_var = float(np.var(y_log - log_pred))
        pred_lkr = back_transform(log_pred, residual_var)
        m = metrics(y_lkr, pred_lkr)
        m["residual_var"] = residual_var
        results[name] = m
        show(name, m)

    # Reference lines from the baseline run
    base = json.loads(Path("data/clean/baseline_metrics.json").read_text())
    print("\n  --- baselines for comparison ---")
    show("brand+year median", base["brand_year_median"])

    OUT.write_text(json.dumps(results, indent=2), encoding="utf-8")
    print(f"\nwrote {OUT}")

    best = min(results, key=lambda k: results[k]["MedAPE"])
    print(f"\nbest by MedAPE: {best} ({results[best]['MedAPE']*100:.1f}%)")
    b = base["brand_year_median"]["MedAPE"] * 100
    print(f"baseline to beat: {b:.1f}%")


if __name__ == "__main__":
    main()
