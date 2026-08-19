"""Pipeline router — detect type, route to correct extractor, save output.

Entry points:
  process_pdf(filepath, mapper) → output path (single PDF)
  main()                          → batch process all PDFs in data/raw/
"""

import os
import sys
from pathlib import Path

import fitz  # pymupdf

from src.config import RAW_DIR, PROCESSED_DIR
from src.detect import detect_type
from src.mapper import FontMapper
from src.unicode import extract_unicode
from src.legacy import extract_legacy_plumber
from src.ocr import extract_ocr


# Guard flag — AI refinement is disabled because models summarise Sinhala
# despite explicit anti-summarisation prompts. Re-enable when a
# Sinhala-stable model is available.
ENABLE_AI_REFINEMENT = False


def process_pdf(filepath: Path, mapper: FontMapper) -> str:
    """Full pipeline for one PDF. Returns output file path."""
    dtype = detect_type(str(filepath))
    filename = filepath.stem

    print(f"  📄 {filepath.name} → {dtype.upper()}")

    if dtype == "legacy":
        all_text = extract_legacy_plumber(str(filepath), mapper)
    elif dtype == "unicode":
        doc = fitz.open(str(filepath))
        all_text = extract_unicode(
            "".join(
                extract_unicode(page.get_text()) + "\n" for page in doc
            )
        )
        doc.close()
    elif dtype == "ocr":
        doc = fitz.open(str(filepath))
        all_text = ""
        for page in doc:
            all_text += extract_ocr(page) + "\n"
        doc.close()
    else:
        all_text = ""

    # Save
    outpath = PROCESSED_DIR / f"{filename}.md"
    outpath.write_text(all_text.strip(), encoding="utf-8")

    # AI Refinement (disabled — models summarise Sinhala)
    if ENABLE_AI_REFINEMENT:
        from src.refine import refine_with_ai
        outpath = Path(refine_with_ai(outpath))

    return str(outpath)


def main():
    full_pipeline = "--full" in sys.argv or "-f" in sys.argv

    pdfs = sorted(RAW_DIR.glob("*.pdf"))
    if not pdfs:
        print("No PDFs found in data/raw/")
        return

    print(f"\n🔍 Processing {len(pdfs)} PDF(s)...\n")

    mapper = FontMapper()

    for pdf in pdfs:
        try:
            out = process_pdf(pdf, mapper)
            size = os.path.getsize(out)
            preview = (
                Path(out).read_text(encoding="utf-8")[:150]
                .replace("\n", " ")
            )
            print(f"    ✅ → {out} ({size:,} bytes)")
            print(f"    📝 Preview: {preview}...\n")
        except Exception as e:
            print(f"    ❌ FAILED: {pdf.name} — {e}")

    print(f"✅ All done. Processed {len(pdfs)} PDF(s).")

    # Run chunker if --full
    if full_pipeline:
        print("\n📦 Running chunker...")
        import subprocess
        subprocess.run(
            [sys.executable, "chunker.py"],
            cwd=Path(__file__).resolve().parent,
        )


if __name__ == "__main__":
    main()
