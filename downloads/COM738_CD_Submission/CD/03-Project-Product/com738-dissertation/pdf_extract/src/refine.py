"""AI refinement pass — send extracted text to LLM for OCR cleanup.

⚠️ DISABLED: Both DeepSeek v4 and Gemini summarise Sinhala content despite
explicit anti-summarisation prompts. Code preserved for re-enablement when
a Sinhala-stable model is available.
"""

import os
from pathlib import Path
from openai import OpenAI


def _clean_lines(client: OpenAI, lines: list[str]) -> list[str]:
    """Send 15 lines at a time with a strict 'copy or fix' directive.
    Returns same number of lines, each either fixed or copied verbatim.
    """
    numbered = "\n".join(f"{i + 1}. {line}" for i, line in enumerate(lines))

    response = client.chat.completions.create(
        model="9router-Gemini",
        messages=[
            {
                "role": "system",
                "content": (
                    "Copy each line exactly. If a line has obvious OCR garbage characters "
                    "(random punctuation, numbers in Sinhala words, garbled symbols), fix ONLY "
                    "those specific characters. If a line is fine, copy it VERBATIM. "
                    "Output EXACTLY one line per input line, keeping the original numbering. "
                    "DO NOT skip, merge, reorder, or summarise any line. "
                    "Output format: '1. <text>\\n2. <text>' etc."
                ),
            },
            {
                "role": "user",
                "content": (
                    f"Fix obvious OCR errors only. Keep everything else identical:\n\n{numbered}"
                ),
            },
        ],
        temperature=0.0,
        max_tokens=4096,
    )

    result = response.choices[0].message.content.strip()
    # Parse numbered output back into lines
    cleaned = []
    for line in result.split("\n"):
        line = line.strip()
        if not line:
            continue
        # Strip leading "N. "
        for j in range(1, len(lines) + 1):
            prefix = f"{j}. "
            if line.startswith(prefix):
                cleaned.append(line[len(prefix) :])
                break

    # Fallback: if parsing failed, return originals
    if len(cleaned) != len(lines):
        return lines

    return cleaned


def refine_with_ai(filepath: Path) -> Path:
    """Send extracted text to DeepSeek v4 for cleanup:
    - Fix OCR artifacts and garbled Sinhala
    - Preserve table structure (markdown pipe format)
    - Remove junk characters / noise
    - Normalize Sinhala spelling consistency
    """
    text = filepath.read_text(encoding="utf-8")

    # Skip tiny files (no meaningful refinement)
    if len(text) < 200:
        return filepath

    print(f"    🤖 Refining with AI ({len(text):,} chars)...")

    client = OpenAI(
        base_url=os.environ.get("LLM_BASE_URL", "http://localhost:20128/v1"),
        api_key=os.environ.get("LLM_API_KEY", ""),
    )

    MAX_CHUNK = 12000  # chars per chunk
    chunks = []
    lines = text.split("\n")
    current = ""
    for line in lines:
        if len(current) + len(line) > MAX_CHUNK and current:
            chunks.append(current)
            current = line + "\n"
        else:
            current += line + "\n"
    if current.strip():
        chunks.append(current)
    if not chunks:
        chunks = [text]

    refined = ""
    for i, chunk in enumerate(chunks):
        if len(chunks) > 1:
            print(f"      Chunk {i + 1}/{len(chunks)}...")

        response = client.chat.completions.create(
            model="9router-Gemini",
            messages=[
                {
                    "role": "system",
                    "content": (
                        "You are a Sinhala text cleaner. Fix obvious OCR errors and spelling mistakes only. "
                        "DO NOT summarise, shorten, delete, merge, split, or reorder anything. "
                        "Output the FULL text unchanged except for fixing clear errors. "
                        "Keep all markdown table formatting exactly as-is."
                    ),
                },
                {
                    "role": "user",
                    "content": (
                        f"Fix obvious OCR/spelling errors only. Output the complete text:\n\n{chunk}"
                    ),
                },
            ],
            temperature=0.0,
            max_tokens=8192,
            stream=True,
        )
        # Collect streaming chunks
        chunk_text = ""
        for chunk in response:
            if chunk.choices[0].delta.content:
                chunk_text += chunk.choices[0].delta.content
        refined += chunk_text + "\n"

    # Validate
    ratio = len(refined) / max(len(text), 1)
    orig_lines = len(text.split("\n"))
    refined_lines = len(refined.split("\n"))
    if ratio < 0.5:
        print(
            f"    ⚠️  WARNING: Refined text is {ratio*100:.0f}% of original "
            f"({orig_lines}→{refined_lines} lines)"
        )
        print(f"    ⚠️  Keeping original instead — AI over-summarised")
        return filepath

    # Save refined version
    outpath = Path(str(filepath).replace(".md", "_refined.md"))
    outpath.write_text(refined.strip(), encoding="utf-8")
    print(
        f"    ✅ Refined → {outpath} "
        f"({outpath.stat().st_size:,} bytes, {ratio*100:.0f}% retained)"
    )

    return outpath
