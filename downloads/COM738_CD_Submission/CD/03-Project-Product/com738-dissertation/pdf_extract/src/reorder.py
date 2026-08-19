"""Sinhala vowel reordering — fixes PDF visual-order artifact.

PDFs store glyphs in visual order instead of logical Unicode order.
Sinhala vowel modifiers (kombuwa, etc.) appear *before* their consonant
in the character stream. This module swaps them back to correct Unicode.
"""

# Consonant set used by kombuwa-swap logic
SINHALA_CONSONANTS = set(
    "කඛගඝඞඟචඡජඣඤඥටඨඩඪණඬතථදධනඳපඵබභමඹයරලවශෂසහළෆ"
)


def reorder_sinhala(text: str) -> str:
    """Reorder legacy Sinhala text where vowel modifiers appear before the consonant."""
    output = []
    i = 0
    n = len(text)

    while i < n:
        char = text[i]

        # Kombuwa (ෙ) followed by consonant → swap
        if char == "ෙ" and i + 1 < n:
            next_char = text[i + 1]
            if next_char in SINHALA_CONSONANTS:
                output.append(next_char)
                output.append(char)
                i += 2
                continue

            # Double kombuwa → ෛ
            if next_char == "ෙ" and i + 2 < n:
                next_next = text[i + 2]
                if next_next in SINHALA_CONSONANTS:
                    output.append(next_next)
                    output.append("ෛ")
                    i += 3
                    continue

        output.append(char)
        i += 1

    result = "".join(output)

    # Post-processing: fix split vowel signs
    result = result.replace("අා", "ආ")
    result = result.replace("අැ", "ඇ")
    result = result.replace("ේ", "ේ")
    result = result.replace("ො", "ො")
    result = result.replace("ෝ", "ෝ")
    # Fix vowel-before-reph ordering (ේ + ්‍ර → ්‍රේ)
    result = result.replace("ේ්‍ර", "්‍රේ")
    result = result.replace("ෝ‍ර", "්‍රො")
    result = result.replace("ෝ්‍ර", "්‍රෝ")
    # Also before combining: ෙ + ් + ්‍ර → ්‍රේ
    result = result.replace("ේ්‍ර", "්‍රේ")
    # Fix typo: ෙ + þ combined wrong in Bold subset
    result = result.replace("මොද", "මාව")
    return result
