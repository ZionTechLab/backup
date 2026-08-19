"""Unicode PDF extraction — direct pymupdf text + NFC normalisation."""

import re
import unicodedata


def extract_unicode(text: str) -> str:
    """Normalize and clean Sinhala Unicode text."""
    text = unicodedata.normalize("NFC", text)
    text = text.replace("\u200d", "").replace("\u200c", "")
    text = re.sub(r"^\d+\s*$", "", text, flags=re.MULTILINE)
    text = re.sub(r"\n{3,}", "\n\n", text)
    return text.strip()
