"""Auto-detect PDF type — Unicode, legacy font-encoded, or scanned OCR."""

import re
import fitz  # pymupdf


def detect_type(filepath: str) -> str:
    """Open with pymupdf, sample first 3 pages. Return: 'unicode' | 'legacy' | 'ocr'."""
    doc = fitz.open(filepath)
    sample = ""
    image_count = 0
    for page in doc[:3]:
        text = page.get_text()
        sample += text
        image_count += len(page.get_images())

    doc.close()

    # If pages have images AND minimal text → scanned
    if image_count >= 3 and len(sample.strip()) < 600:
        return "ocr"

    if not sample.strip():
        return "ocr"

    # Unicode Sinhala: U+0D80–U+0DFF range
    if re.search(r"[\u0D80-\u0DFF]{5,}", sample):
        return "unicode"

    # Gibberish Latin = legacy font
    if re.search(r"[a-zA-Z]{4,}", sample[:300]):
        return "legacy"

    return "ocr"
