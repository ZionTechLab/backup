"""OCR extraction — render scanned PDF pages + Tesseract for Sinhala text."""

import io
import fitz  # pymupdf


def extract_ocr(page: fitz.Page) -> str:
    """Render page as image, preprocess, and OCR for Sinhala text."""
    try:
        import pytesseract
        from PIL import Image, ImageFilter

        # Render at 200 dpi — good balance of quality vs OCR speed
        pix = page.get_pixmap(dpi=200)
        img = Image.open(io.BytesIO(pix.tobytes("png")))

        # Preprocess: grayscale + sharpen to improve Sinhala OCR accuracy
        img = img.convert("L")
        img = img.filter(ImageFilter.SHARPEN)

        # Use 'sin' (NOT 'script/Sinhala' — that traineddata file doesn't
        # exist on this system; the invalid lang silently falls back to
        # English-only and produces utter gibberish on Sinhala text.)
        return pytesseract.image_to_string(img, lang="sin", config="--psm 6")
    except ImportError:
        return ""
