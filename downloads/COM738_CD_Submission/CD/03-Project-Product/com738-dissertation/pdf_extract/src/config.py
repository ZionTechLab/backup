"""Shared configuration for the PDF extraction pipeline."""

from pathlib import Path

# Data lives at pdf_extract/data/ — one level up from src/
DATA_DIR = Path(__file__).resolve().parent.parent / "data"
RAW_DIR = DATA_DIR / "raw"
PROCESSED_DIR = DATA_DIR / "processed"
PROCESSED_DIR.mkdir(parents=True, exist_ok=True)
