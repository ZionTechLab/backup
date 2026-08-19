"""
FontMapper — character-level Sinhala font conversion using JSON mappings.
Extracted from pdf-reader/pdf_processor.py — works with pdfplumber.
"""

import os
import json
from pathlib import Path


class FontMapper:
    def __init__(self, mappings_dir=None):
        if mappings_dir is None:
            # Default to src/mappings/
            mappings_dir = str(
                Path(__file__).resolve().parent / "mappings"
            )
        self.mappings_dir = mappings_dir
        self.font_mappings = {}
        self.load_mappings()

    def load_mappings(self):
        """Loads all JSON files in the mappings directory."""
        if not os.path.exists(self.mappings_dir):
            os.makedirs(self.mappings_dir)
            return

        for filename in sorted(os.listdir(self.mappings_dir)):
            if filename.endswith(".json"):
                try:
                    with open(
                        os.path.join(self.mappings_dir, filename),
                        "r",
                        encoding="utf-8",
                    ) as f:
                        data = json.load(f)
                        names = data.get("font_family_names", [])
                        mapping = data.get("mapping", {})
                        for name in names:
                            self.font_mappings[name] = mapping
                except Exception as e:
                    print(f"  ⚠ Error loading mapping {filename}: {e}")

        print(f"  📦 Loaded {len(self.font_mappings)} font mapping(s)")

    def map_char(self, char, font_name):
        """Maps a character based on font name. Returns original char if no mapping found."""
        for known_font in self.font_mappings:
            if known_font.lower() in font_name.lower():
                return self.font_mappings[known_font].get(char, char)
        return char
