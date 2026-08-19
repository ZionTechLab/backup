"""
COM738 — Question Set Generator
Uses Gemini (via 9router) to generate 70–80 Sinhala O/L Business Studies
evaluation questions with reference answers from textbook content.
"""

import json, re, os, random
from pathlib import Path
from openai import OpenAI

# ─── CONFIG ──────────────────────────────────────────────
PROCESSED = Path(__file__).resolve().parent.parent / "data" / "processed"
OUTPUT = Path(__file__).resolve().parent.parent / "eval_questions.json"
MODEL = "9router-Gemini"

client = OpenAI(
    base_url="http://localhost:20128/v1",
    api_key="no-key-needed",
)

# ─── 7 SYLLABUS TOPICS (from NIE O/L Business Studies) ──
TOPICS = {
    "1. Business Environment": {
        "sinhala": "ව්‍යාපාර පරිසරය",
        "subtopics": [
            "ව්‍යාපාර පිළිබඳ මූලික පදනම",
            "ව්‍යාපාර කෙරෙහි ඇල්මැති පාර්ශ්ව",
            "ව්‍යාපාර පරිසරයේ සාධක (අභ්‍යන්තර හා බාහිර)",
            "තාක්ෂණික හා ආර්ථික පරිසරය",
            "ගෝලීය පරිසරය හා ව්‍යාපාර",
        ],
        "textbook_files": ["bs-tb-10-s-textbook.txt"],
        "pastpaper_years": ["2016", "2017", "2018", "2019", "2020"],
    },
    "2. Business Organisations": {
        "sinhala": "ව්‍යාපාර සංවිධාන",
        "subtopics": [
            "තනි පුද්ගල ව්‍යාපාර",
            "හවුල් ව්‍යාපාර",
            "සංස්ථාපිත සමාගම්",
            "සමුපකාර සමිති",
            "රාජ්‍ය අංශයේ ව්‍යාපාර",
        ],
        "textbook_files": ["bs-tb-10-s-textbook.txt"],
        "pastpaper_years": ["2016", "2017", "2018", "2019", "2020"],
    },
    "3. Marketing": {
        "sinhala": "අලෙවිකරණය",
        "subtopics": [
            "වෙළෙඳාම හා උපකාරක සේවා",
            "අලෙවිකරණ මිශ්‍රණය (4P)",
            "පාරිභෝගික හැසිරීම",
            "වෙළඳපොළ පර්යේෂණ",
            "බෙදාහැරීමේ මාර්ග",
        ],
        "textbook_files": ["bs-tb-11-s-textbook.txt"],
        "pastpaper_years": ["2019", "2020", "2021", "2022"],
    },
    "4. Finance & Accounting": {
        "sinhala": "මූල්‍ය හා ගිණුම්කරණය",
        "subtopics": [
            "ගිණුම්කරණ සමීකරණය",
            "ද්විත්ව සටහන් ක්‍රමය",
            "මූලික පොත් හා ලෙජර්",
            "ශේෂ පිරික්සුම",
            "බැංකු සැසඳීම් ප්‍රකාශනය",
            "මූල්‍ය ප්‍රකාශන",
            "අනුපාත විශ්ලේෂණය",
        ],
        "textbook_files": ["bs-tb-10-s-textbook.txt", "bs-tb-11-s-textbook.txt"],
        "pastpaper_years": ["2016", "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025"],
    },
    "5. Human Resources": {
        "sinhala": "මානව සම්පත් කළමනාකරණය",
        "subtopics": [
            "සේවක බඳවා ගැනීම හා තෝරා ගැනීම",
            "පුහුණුව හා සංවර්ධනය",
            "අභිප්‍රේරණය",
            "කම්කරු සබඳතා හා වෘත්තීය සමිති",
            "සේවක ඇගයීම",
        ],
        "textbook_files": ["bs-tb-10-s-textbook.txt"],
        "pastpaper_years": ["2019", "2020", "2021", "2022"],
    },
    "6. Operations Management": {
        "sinhala": "මෙහෙයුම් කළමනාකරණය",
        "subtopics": [
            "නිෂ්පාදන ක්‍රියාවලිය",
            "තත්ත්ව පාලනය",
            "ඉන්වෙන්ටරි කළමනාකරණය",
            "සැපයුම් දාම කළමනාකරණය",
            "තාක්ෂණය හා නිෂ්පාදනය",
        ],
        "textbook_files": ["bs-tb-10-s-textbook.txt"],
        "pastpaper_years": ["2020", "2021", "2022", "2023"],
    },
    "7. Business Ethics & Social Responsibility": {
        "sinhala": "ව්‍යාපාර ආචාර ධර්ම හා සමාජ වගකීම",
        "subtopics": [
            "ව්‍යාපාර ආචාර ධර්ම",
            "පාරිසරික වගකීම",
            "පාරිභෝගික ආරක්ෂණය",
            "සමාජ සුභසාධනය",
            "තිරසාර සංවර්ධනය",
        ],
        "textbook_files": ["bs-tb-10-s-textbook.txt"],
        "pastpaper_years": ["2019", "2020", "2021", "2022", "2023"],
    },
}

BLOOMS_LEVELS = [
    ("දැනුම (Knowledge)", "අර්ථ දැක්වීම, නම් කිරීම, හඳුනා ගැනීම"),
    ("අවබෝධය (Understanding)", "පැහැදිලි කිරීම, විස්තර කිරීම, වෙනස හඳුනා ගැනීම"),
    ("යෙදුම (Application)", "ගණනය කිරීම, සකස් කිරීම, යෙදීම"),
    ("විශ්ලේෂණය (Analysis)", "සංසන්දනය, වර්ගීකරණය, හේතු දැක්වීම"),
]


# ─── STEP 1: Extract past paper sample questions ─────────
def extract_pastpaper_samples(topic_key: str, max_samples: int = 8) -> list[str]:
    """Get real Sinhala questions from past papers for a given topic."""
    years = TOPICS[topic_key]["pastpaper_years"]
    sample_questions = []
    
    for year in years:
        pp_file = PROCESSED / f"bs-pol-ol-s-{year}-past-paper.txt"
        if not pp_file.exists():
            continue
        
        text = pp_file.read_text(encoding="utf-8", errors="replace")
        # Extract question-like lines: numbered items with Sinhala text
        # Pattern: "1.", "01.", followed by Sinhala
        matches = re.findall(r'(?:^|\n)\s*(\d{1,2}\.\s+[^\n]{30,200})', text)
        for m in matches:
            cleaned = m.strip()
            if len(cleaned) > 30:
                sample_questions.append(cleaned)
        
        if len(sample_questions) >= max_samples:
            break
    
    return sample_questions[:max_samples]


# ─── STEP 2: Extract textbook content for a topic ──────
def extract_textbook_content(topic_key: str, max_chars: int = 8000) -> str:
    """Get relevant textbook passages for the topic."""
    files = TOPICS[topic_key]["textbook_files"]
    content_parts = []
    total = 0
    
    for fname in files:
        fpath = PROCESSED / fname
        if not fpath.exists():
            continue
        text = fpath.read_text(encoding="utf-8", errors="replace")
        # Take chunks from throughout the file
        step = max(len(text) // 6, 5000)
        for i in range(0, len(text), step):
            chunk = text[i:i+2000]
            if total + len(chunk) > max_chars:
                break
            content_parts.append(chunk)
            total += len(chunk)
        if total >= max_chars:
            break
    
    return "\n...\n".join(content_parts)


# ─── STEP 3: Generate questions via Gemini ──────────────
def generate_questions_for_topic(
    topic_key: str,
    questions_per_level: dict,
    pastpaper_samples: list[str],
    textbook_content: str,
) -> list[dict]:
    """Generate questions + reference answers for one topic."""
    
    topic_name = topic_key.split(". ", 1)[1] if ". " in topic_key else topic_key
    sinhala_name = TOPICS[topic_key]["sinhala"]
    subtopics = TOPICS[topic_key]["subtopics"]
    
    pp_examples = "\n".join(f"  • {q}" for q in pastpaper_samples[:6])
    topic_list = "\n".join(f"  - {s}" for s in subtopics)
    
    total_questions = sum(questions_per_level.values())
    
    prompt = f"""ඔබ ශ්‍රී ලංකාවේ අ.පො.ස (සාමාන්‍ය පෙළ) ව්‍යාපාර හා ගිණුම්කරණ අධ්‍යයනය විෂය සඳහා ප්‍රශ්න සකස් කරන විශේෂඥයෙකි.

පහත මාතෘකාව සඳහා ප්‍රශ්න {total_questions}ක් සහ ඒ සෑම ප්‍රශ්නයකටම සම්පූර්ණ සිංහල පිළිතුරක් සකස් කරන්න:

මාතෘකාව: {sinhala_name} ({topic_name})
උප මාතෘකා:
{topic_list}

Bloom's Taxonomy මට්ටම් අනුව ප්‍රශ්න බෙදාහරින්න:
"""
    for level_name, level_desc in BLOOMS_LEVELS:
        count = questions_per_level.get(level_name, 0)
        if count > 0:
            prompt += f"  - {level_name}: ප්‍රශ්න {count}ක් ({level_desc})\n"
    
    prompt += f"""
පහත දැක්වෙන්නේ පෙර විභාග ප්‍රශ්න පත්‍රවලින් උපුටා ගත් සැබෑ ප්‍රශ්න ආදර්ශ කිහිපයකි. මෙම ශෛලිය හා දුෂ්කරතා මට්ටම අනුගමනය කරන්න:

{pp_examples}

පහත දැක්වෙන්නේ පෙළ පොත් අන්තර්ගතයේ කොටස් වේ. පිළිතුරු සැකසීමේදී මෙම අන්තර්ගතය පදනම් කරගෙන නිවැරදි, සම්පූර්ණ පිළිතුරු ලියන්න.

පෙළ පොත් අන්තර්ගතය:
{textbook_content[:6000]}

වැදගත් උපදෙස්:
1. සියලුම ප්‍රශ්න හා පිළිතුරු සිංහල භාෂාවෙන් පමණක් ලියන්න.
2. ප්‍රශ්න කෙටි, පැහැදිලි හා O/L විභාගයට ගැලපෙන ආකාරයෙන් ලියන්න.
3. පිළිතුරු සම්පූර්ණ වාක්‍ය වලින්, පෙළපොතේ අන්තර්ගතයට අනුකූලව ලියන්න.
4. ප්‍රශ්නය Bloom's මට්ටම පැහැදිලිව දක්වන්න.
5. පිළිතුරු අවම වශයෙන් වචන 30-100 අතර විය යුතුය.

ප්‍රතිදාන ආකෘතිය (JSON array පමණක්, වෙනත් පැහැදිලි කිරීම් නැතිව):

```json
[
  {{
    "question": "සිංහල ප්‍රශ්නය",
    "reference": "සම්පූර්ණ සිංහල පිළිතුර",
    "topic": "{sinhala_name}",
    "subtopic": "උප මාතෘකාව",
    "blooms_level": "{BLOOMS_LEVELS[0][0] if questions_per_level.get(BLOOMS_LEVELS[0][0],0)>0 else BLOOMS_LEVELS[1][0]}"
  }}
]
```"""

    try:
        resp = client.chat.completions.create(
            model=MODEL,
            messages=[{"role": "user", "content": prompt}],
            temperature=0.3,
            max_tokens=8000,
        )
        content = resp.choices[0].message.content or ""
        
        # Extract JSON from response
        json_match = re.search(r'\[.*\]', content, re.DOTALL)
        if json_match:
            raw = json_match.group(0)
            questions = json.loads(raw)
            # Validate required fields
            valid = []
            for q in questions:
                if isinstance(q, dict) and "question" in q and "reference" in q:
                    if len(q["question"]) > 10 and len(q["reference"]) > 20:
                        q.setdefault("topic", sinhala_name)
                        q.setdefault("blooms_level", "")
                        valid.append(q)
            return valid
        else:
            print(f"  ⚠️ No JSON found in response for {topic_name}")
            return []
            
    except Exception as e:
        print(f"  ❌ Gemini error for {topic_name}: {e}")
        return []


# ─── MAIN ────────────────────────────────────────────────
def main():
    print("🔬 COM738 — Question Set Generator\n")
    print(f"   Model: {MODEL}")
    print(f"   Topics: {len(TOPICS)}")
    print()
    
    all_questions = []
    
    # Per-topic question allocation: 10 each = 70 total
    # Extra 10 on Finance (extensive past papers available)
    allocation = {
        "1. Business Environment": {BLOOMS_LEVELS[0][0]: 2, BLOOMS_LEVELS[1][0]: 4, BLOOMS_LEVELS[2][0]: 2, BLOOMS_LEVELS[3][0]: 2},
        "2. Business Organisations": {BLOOMS_LEVELS[0][0]: 2, BLOOMS_LEVELS[1][0]: 4, BLOOMS_LEVELS[2][0]: 2, BLOOMS_LEVELS[3][0]: 2},
        "3. Marketing": {BLOOMS_LEVELS[0][0]: 2, BLOOMS_LEVELS[1][0]: 4, BLOOMS_LEVELS[2][0]: 3, BLOOMS_LEVELS[3][0]: 1},
        "4. Finance & Accounting": {BLOOMS_LEVELS[0][0]: 3, BLOOMS_LEVELS[1][0]: 4, BLOOMS_LEVELS[2][0]: 6, BLOOMS_LEVELS[3][0]: 3},
        "5. Human Resources": {BLOOMS_LEVELS[0][0]: 2, BLOOMS_LEVELS[1][0]: 4, BLOOMS_LEVELS[2][0]: 2, BLOOMS_LEVELS[3][0]: 2},
        "6. Operations Management": {BLOOMS_LEVELS[0][0]: 2, BLOOMS_LEVELS[1][0]: 3, BLOOMS_LEVELS[2][0]: 3, BLOOMS_LEVELS[3][0]: 2},
        "7. Business Ethics & Social Responsibility": {BLOOMS_LEVELS[0][0]: 3, BLOOMS_LEVELS[1][0]: 4, BLOOMS_LEVELS[2][0]: 2, BLOOMS_LEVELS[3][0]: 1},
    }
    
    for topic_key in TOPICS:
        topic_name = topic_key.split(". ", 1)[1]
        target = sum(allocation[topic_key].values())
        print(f"📚 {topic_name} (target: {target})")
        
        # Extract samples
        print("   Extracting past paper samples...")
        samples = extract_pastpaper_samples(topic_key, max_samples=8)
        print(f"   → {len(samples)} sample questions found")
        
        # Extract textbook content
        print("   Loading textbook content...")
        textbook = extract_textbook_content(topic_key, max_chars=8000)
        print(f"   → {len(textbook):,} chars loaded")
        
        # Generate
        print(f"   Generating questions via Gemini...")
        questions = generate_questions_for_topic(
            topic_key,
            allocation[topic_key],
            samples,
            textbook,
        )
        
        print(f"   → {len(questions)} questions generated (target: {target})")
        
        # If under target, retry once
        if len(questions) < target:
            print(f"   ⚠️ Below target, retrying...")
            remaining = target - len(questions)
            retry_allocation = {k: max(1, v // 2) for k, v in allocation[topic_key].items()}
            more = generate_questions_for_topic(topic_key, retry_allocation, samples, textbook)
            questions.extend(more)
            print(f"   → After retry: {len(questions)} total")
        
        all_questions.extend(questions)
        print()
    
    # Save
    print(f"\n{'='*50}")
    print(f"✅ Total: {len(all_questions)} questions")
    
    # Quality check
    topics_seen = set()
    for q in all_questions:
        topics_seen.add(q.get("topic", "unknown"))
    print(f"   Topics covered: {len(topics_seen)}/7")
    
    bloom_counts = {}
    for q in all_questions:
        level = q.get("blooms_level", "unknown")
        bloom_counts[level] = bloom_counts.get(level, 0) + 1
    print(f"   Bloom's distribution: {bloom_counts}")
    
    with open(OUTPUT, "w", encoding="utf-8") as f:
        json.dump(all_questions, f, ensure_ascii=False, indent=2)
    
    print(f"\n💾 Saved to: {OUTPUT}")
    
    # Print sample
    print(f"\n📝 Sample question:")
    if all_questions:
        q = all_questions[0]
        print(f"   Q: {q['question'][:100]}")
        print(f"   A: {q['reference'][:120]}")
        print(f"   Topic: {q.get('topic','')}")
        print(f"   Bloom: {q.get('blooms_level','')}")


if __name__ == "__main__":
    main()
