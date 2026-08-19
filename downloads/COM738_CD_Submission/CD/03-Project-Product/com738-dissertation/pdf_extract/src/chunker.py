"""
COM738 — Chunker: Segment extracted Sinhala text into passages for embedding.
Strategies: paragraph, 500-char sliding, semantic (curriculum topic boundaries).
Output: data/chunked/knowledge_base.json — 50-100 passages with metadata.
"""

import json
import re
from pathlib import Path
from dataclasses import dataclass, field, asdict

PROCESSED_DIR = Path(__file__).resolve().parent / "data" / "processed"
OUTPUT_DIR = Path(__file__).resolve().parent / "data" / "chunked"
OUTPUT_DIR.mkdir(parents=True, exist_ok=True)


@dataclass
class Passage:
    id: str
    source: str
    text: str
    chunk_strategy: str
    char_count: int
    topic: str = ""


def _clean_text(text: str) -> str:
    """Remove leading bullet markers and excessive whitespace."""
    text = text.strip()
    while text and text[0] in "•—x×":
        text = text[1:].strip()
    text = re.sub(r" {2,}", " ", text)
    return text


# ── Table parsing ─────────────────────────────────────────────

def _merge_markdown_table_rows(lines: list[str]) -> list[list[str]]:
    """Parse markdown table. Merge wrapped rows into logical rows."""
    table_lines = []
    for line in lines:
        if line.startswith("|") and "---" not in line:
            if "නිපුණතා" in line and "අන්තර්ගතය" in line:
                continue
            cols = [c.strip() for c in line.split("|")[1:-1]]
            table_lines.append(cols)

    merged = []
    current = ["", "", "", "", ""]

    for cols in table_lines:
        while len(cols) < 5:
            cols.append("")
        cols = cols[:5]

        non_empty = sum(1 for c in cols if c)
        has_hours = bool(re.match(r"^\d+$", cols[4].strip())) if cols[4] else False

        if non_empty == 0:
            continue

        if has_hours or non_empty >= 3:
            if any(current):
                merged.append([_clean_text(c) for c in current])
            current = cols
        else:
            for j in range(5):
                if cols[j]:
                    separator = " " if current[j] else ""
                    current[j] = current[j] + separator + cols[j]

    if any(current):
        merged.append([_clean_text(c) for c in current])

    return merged


# ── Chunkers ──────────────────────────────────────────────────

def chunk_paragraph(text: str, source: str, prefix: str) -> list[Passage]:
    """Split by blank lines. For syllabus/textbook content, uses table-aware splitting."""
    lines = text.split("\n")

    table_rows = _merge_markdown_table_rows(lines)
    if table_rows:
        return _chunk_syllabus_by_rows(table_rows, source, prefix)

    chunks = []
    current = ""
    for line in lines:
        stripped = line.strip()
        if stripped == "":
            if current.strip():
                clean = _clean_text(current)
                if len(clean) > 20:
                    chunks.append(clean)
                current = ""
        else:
            current += line + "\n"

    if current.strip():
        clean = _clean_text(current)
        if len(clean) > 20:
            chunks.append(clean)

    return [
        Passage(
            id=f"{prefix}-p{i+1:03d}",
            source=source,
            text=chunk,
            chunk_strategy="paragraph",
            char_count=len(chunk),
        )
        for i, chunk in enumerate(chunks)
    ]


def _chunk_syllabus_by_rows(rows: list[list[str]], source: str, prefix: str) -> list[Passage]:
    """Each logical row + its continuations = one passage."""
    passages = []
    for i, row in enumerate(rows):
        parts = [c for c in row if c]
        if not parts:
            continue
        text = " | ".join(parts)
        topic = parts[1][:40] if len(parts) > 1 else ""
        passages.append(Passage(
            id=f"{prefix}-p{i+1:03d}",
            source=source,
            text=text,
            chunk_strategy="paragraph",
            char_count=len(text),
            topic=topic,
        ))
    return passages


def chunk_sliding(text: str, source: str, prefix: str, window: int = 800, overlap: int = 150) -> list[Passage]:
    """Character-based sliding window chunks."""
    text = re.sub(r"\n{3,}", "\n\n", text)
    text = re.sub(r" {2,}", " ", text)

    chunks = []
    for i in range(0, max(len(text) - window + overlap, 1), window - overlap):
        chunk = text[i:i + window]
        if len(chunk.strip()) > 50:
            chunks.append(chunk.strip())

    return [
        Passage(
            id=f"{prefix}-s{i+1:03d}",
            source=source,
            text=chunk,
            chunk_strategy="500-char-sliding",
            char_count=len(chunk),
        )
        for i, chunk in enumerate(chunks)
    ]


def chunk_semantic_syllabus(lines: list[str], source: str, prefix: str) -> list[Passage]:
    """Chunk syllabus by curriculum topic boundaries."""
    rows = _merge_markdown_table_rows(lines)
    current_topic = ""
    current_rows = []
    passages = []

    for i, row in enumerate(rows):
        col1 = row[1] if len(row) > 1 else ""
        section_match = re.match(r"^(\d+)\.?\s", col1)
        sub_match = re.match(r"^\.(\d+)", col1) or re.match(r"^(\d+)\.(\d+)", col1)

        if section_match or sub_match:
            if current_rows:
                passages.append(_build_passage(current_topic, current_rows, source, prefix))
                current_rows = []
            if section_match:
                current_topic = f"Section {section_match.group(1)}"
            else:
                current_topic = f"Topic {col1[:30].strip('•').strip()}"

        current_rows.append(row)

    if current_rows:
        passages.append(_build_passage(current_topic, current_rows, source, prefix))

    return passages


def _build_passage(topic: str, rows: list[list[str]], source: str, prefix: str) -> Passage:
    lines = []
    for row in rows:
        parts = [c for c in row if c]
        if parts:
            lines.append(" ".join(parts))

    text = "\n".join(lines)
    return Passage(
        id=f"{prefix}-sem-{topic.lower().replace(' ','_')[:20]}",
        source=source,
        text=text,
        chunk_strategy="semantic-section",
        char_count=len(text),
        topic=topic,
    )


def chunk_semantic_past_paper(lines: list[str], source: str, prefix: str) -> list[Passage]:
    """Chunk past paper by question boundaries."""
    text = "\n".join(lines)
    passages = []

    question_splits = re.split(r"\n(?=0\d+\.\s|\d{2}\.\s|[A-D]\s)", text)

    for i, chunk in enumerate(question_splits):
        chunk = chunk.strip()
        if len(chunk) < 30:
            continue

        topic = ""
        first_line = chunk.split("\n")[0][:50]
        if re.match(r"^\d+\.", first_line):
            topic = first_line.strip()

        passages.append(Passage(
            id=f"{prefix}-q{i+1:03d}",
            source=source,
            text=chunk,
            chunk_strategy="semantic-question",
            char_count=len(chunk),
            topic=topic,
        ))

    return passages


# ── Filename convention parser ────────────────────────────────

def _parse_filename(filename: str) -> dict:
    """Parse: bs-<type>-<grade>-<lang>-<year>-<desc>.{md,txt}"""
    stem = Path(filename).stem
    parts = stem.split("-", maxsplit=6)
    return {
        "subject": parts[0] if len(parts) > 0 else "",
        "type": parts[1] if len(parts) > 1 else "",
        "grade": parts[2] if len(parts) > 2 else "",
        "lang": parts[3] if len(parts) > 3 else "",
        "year": parts[4] if len(parts) > 4 else "",
        "desc": parts[5] if len(parts) > 5 else "",
    }


def _source_label(parsed: dict) -> str:
    """Human-readable source label."""
    type_map = {
        "syl": "Syllabus", "tg": "Teacher's Guide", "tb": "Textbook",
        "pol": "O/L Past Paper", "p": "Term Paper", "pm": "Model Paper",
    }
    grade_map = {"ol": "O/L", "10": "Grade 10", "11": "Grade 11"}
    rtype = type_map.get(parsed["type"], parsed["type"])
    grade = grade_map.get(parsed["grade"], parsed["grade"])
    return f"{rtype} {grade} ({parsed['year']})"


def _file_key(filename: str) -> str:
    """Short unique key from filename stem for ID prefixing."""
    stem = Path(filename).stem
    # e.g., bs-tb-10-s-textbook → tb10
    parts = stem.split("-")
    if len(parts) >= 3:
        return f"{parts[1]}{parts[2]}"  # type+grade, e.g. "tb10", "polol"
    return stem[:12].replace("-", "")


def _is_question_type(rtype: str) -> bool:
    return rtype in ("pol", "p", "pm")


def _is_syllabus_type(rtype: str) -> bool:
    return rtype in ("syl", "tb")


def _is_structured_type(rtype: str) -> bool:
    return rtype in ("syl", "tb", "tg")


# ── Main ──────────────────────────────────────────────────────

def build_knowledge_base() -> list[Passage]:
    """Process all .md + .txt files → unified knowledge base."""
    all_passages = []
    seen_ids = set()

    for text_file in sorted(
        list(PROCESSED_DIR.glob("*.md")) + list(PROCESSED_DIR.glob("*.txt"))
    ):
        if "refined" in text_file.stem:
            continue

        text = text_file.read_text(encoding="utf-8")
        lines = text.split("\n")

        parsed = _parse_filename(text_file.name)
        source = _source_label(parsed)
        rtype = parsed["type"]
        prefix = _file_key(text_file.name)

        print(f"  📄 {text_file.name} [{rtype}] ({len(text):,} chars, {len(lines)} lines)")

        if _is_syllabus_type(rtype):
            para = chunk_paragraph(text, source, prefix)
            para = sorted(para, key=lambda p: p.char_count, reverse=True)[:30]
            print(f"     Paragraph: {len(para)} chunks (top)")
            all_passages.extend(para)

            sem = chunk_semantic_syllabus(lines, source, prefix)
            print(f"     Semantic: {len(sem)} chunks")
            all_passages.extend(sem)

            slide = chunk_sliding(text, source, prefix)
            slide = slide[:10]
            print(f"     Sliding: {len(slide)} chunks")
            all_passages.extend(slide)

        elif _is_question_type(rtype):
            sem = chunk_semantic_past_paper(lines, source, prefix)
            print(f"     Semantic-question: {len(sem)} chunks")
            all_passages.extend(sem)

        elif _is_structured_type(rtype):
            para = chunk_paragraph(text, source, prefix)
            if not para or len(para) < 3:
                para = chunk_sliding(text, source, prefix)
                print(f"     Sliding (fallback): {len(para)} chunks")
            else:
                print(f"     Paragraph: {len(para)} chunks")
            all_passages.extend(para)

        else:
            print(f"     ⚠️  Unknown type '{rtype}' — sliding window only")
            slide = chunk_sliding(text, source, prefix)
            all_passages.extend(slide)

    # Deduplicate by ID (keep first occurrence)
    seen = set()
    deduped = []
    for p in all_passages:
        if p.id not in seen:
            seen.add(p.id)
            deduped.append(p)

    return deduped


def main():
    print("\n🔪 COM738 Chunker — Building Knowledge Base\n")

    passages = build_knowledge_base()

    outpath = OUTPUT_DIR / "knowledge_base.json"
    data = [asdict(p) for p in passages]
    outpath.write_text(json.dumps(data, ensure_ascii=False, indent=2), encoding="utf-8")

    unique_ids = set(p.id for p in passages)
    strategies = {}
    total_chars = 0
    for p in passages:
        strategies[p.chunk_strategy] = strategies.get(p.chunk_strategy, 0) + 1
        total_chars += p.char_count

    print(f"\n✅ Saved: {outpath} ({len(passages)} passages, {total_chars:,} total chars)")
    print(f"   Unique IDs: {len(unique_ids)} (duplicates removed: {len(passages) - len(unique_ids)})")
    for strat, count in sorted(strategies.items()):
        print(f"   {strat}: {count}")

    print(f"\n📝 Sample passages:")
    for p in passages[:3]:
        print(f"   [{p.id}] {p.source} | {p.chunk_strategy} | {p.char_count}c")
        print(f"   → {p.text[:100]}...")
        print()


if __name__ == "__main__":
    main()
