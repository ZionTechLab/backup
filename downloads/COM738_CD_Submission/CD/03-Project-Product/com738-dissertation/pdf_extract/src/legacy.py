"""Legacy font PDF extraction — pdfplumber + FontMapper for FM Abhaya-encoded Sinhala.

Two-phase pipeline:
  1. pdfplumber extracts raw font-encoded characters with table structure
  2. FontMapper converts each character to proper Sinhala Unicode

Also handles Bold-font deduplication (PDF renderer duplicates Bold chars
across every visible column), table detection from vertical edge lines,
and column assignment by x-coordinate boundaries.

Output: markdown pipe-delimited tables + prose lines.
"""

import unicodedata
import pdfplumber

from src.mapper import FontMapper
from src.reorder import reorder_sinhala


def _col_text(line_chars, col_bounds, mapper):
    """Extract mapped Sinhala text from chars falling within column bounds."""
    columns = []
    assigned = set()
    for x0, x1 in col_bounds:
        col_chars = [
            c
            for c in line_chars
            if (round(c["x0"]), c["text"], c.get("fontname", "")[:20])
            not in assigned
            and x0 - 3 <= c["x0"] <= x1 + 3
        ]
        for c in col_chars:
            assigned.add(
                (round(c["x0"]), c["text"], c.get("fontname", "")[:20])
            )
        col_chars.sort(key=lambda c: c["x0"])
        t = ""
        for c in col_chars:
            t += mapper.map_char(c["text"], c.get("fontname", ""))
        columns.append(reorder_sinhala(t).strip())
    return columns


def extract_legacy_plumber(filepath: str, mapper: FontMapper) -> str:
    """Use pdfplumber + FontMapper for per-character font-aware extraction.

    Detects and preserves table structure: uses vertical edge lines to define
    column boundaries, splits chars into columns within table regions, and
    deduplicates Bold font chars that PDF renderer duplicates across columns.
    Outputs tables as markdown pipe-delimited format.
    """
    all_text = ""

    with pdfplumber.open(filepath) as pdf:
        for i, page in enumerate(pdf.pages):
            chars = page.chars if hasattr(page, "chars") else []
            if not chars:
                continue

            # Detect table regions and column boundaries from vertical edges
            edges = page.edges if hasattr(page, "edges") else []
            table_regions = []

            for tb in page.find_tables():
                tx0, ttop, tx1, tbottom = tb.bbox
                vert_x = set()
                for e in edges:
                    if abs(e.get("x0", 0) - e.get("x1", 1)) < 2:
                        ey0 = e.get("top", 0)
                        ey1 = e.get("bottom", 0)
                        if (
                            ttop - 5 <= ey0 <= tbottom + 5
                            or ttop - 5 <= ey1 <= tbottom + 5
                        ):
                            vert_x.add(round(e["x0"]))
                if len(vert_x) >= 4:
                    vert_x = sorted(vert_x)
                    col_bounds = [
                        (vert_x[j], vert_x[j + 1])
                        for j in range(len(vert_x) - 1)
                    ]
                    table_regions.append(
                        (ttop - 2, tbottom + 2, col_bounds)
                    )

            # Group + deduplicate chars into lines
            lines = {}
            for char in chars:
                top = char.get("top", 0)
                found = False
                for line_top in list(lines.keys()):
                    if abs(top - line_top) < 4:
                        lines[line_top].append(char)
                        found = True
                        break
                if not found:
                    lines[top] = [char]

            for line_top in lines:
                seen = {}
                deduped = []
                for c in sorted(
                    lines[line_top], key=lambda c: c.get("x0", 0)
                ):
                    cid = (
                        round(c.get("x0", 0)),
                        c.get("text", ""),
                        c.get("fontname", "")[:20],
                    )
                    if cid not in seen:
                        seen[cid] = True
                        deduped.append(c)
                lines[line_top] = deduped

            in_table_region = False

            for line_top in sorted(lines.keys()):
                line_chars = sorted(
                    lines[line_top], key=lambda c: c.get("x0", 0)
                )
                if not line_chars:
                    continue

                # Find matching table region
                match = None
                for r in table_regions:
                    if r[0] <= line_top <= r[1]:
                        match = r
                        break

                if match:
                    ty_top, ty_bottom, col_bounds = match
                    bold_count = sum(
                        1
                        for c in line_chars
                        if "Bold" in c.get("fontname", "")
                    )
                    is_bold_row = bold_count > len(line_chars) * 0.5

                    if not in_table_region:
                        columns = _col_text(line_chars, col_bounds, mapper)
                        non_empty = sum(1 for c in columns if c.strip())

                        if non_empty < 2 and is_bold_row:
                            # Single-column Bold text = title/prose
                            line_text = "".join(columns)
                            all_text += (
                                reorder_sinhala(line_text).strip() + "\n"
                            )
                            continue

                        # Start of a new table — this row IS the header
                        in_table_region = True
                        line_text = (
                            "| " + " | ".join(columns) + " |"
                        )
                        all_text += line_text + "\n"
                        all_text += (
                            "|" + "---|" * len(columns) + "\n"
                        )

                    if is_bold_row:
                        # Subsequent Bold row = duplicate header, skip
                        continue

                    # Regular data row
                    columns = _col_text(line_chars, col_bounds, mapper)
                    line_text = "| " + " | ".join(columns) + " |"
                    if line_text.strip() != "| |":
                        all_text += line_text + "\n"
                    continue

                # Not in a table region
                in_table_region = False

                # Non-table prose line — map each char through FontMapper
                line_text = ""
                last_x1 = line_chars[0].get("x0", 0)

                for char_obj in line_chars:
                    gap = char_obj.get("x0", 0) - last_x1
                    if gap > 2.5:
                        line_text += " "

                    original_char = char_obj.get("text", "")
                    font_name = char_obj.get("fontname", "")
                    mapped_char = mapper.map_char(
                        original_char, font_name
                    )
                    line_text += mapped_char
                    last_x1 = char_obj.get("x1", 0)

                reordered = reorder_sinhala(line_text).strip()
                if reordered:
                    reordered = unicodedata.normalize("NFC", reordered)
                    all_text += reordered + "\n"

    return all_text.strip()
