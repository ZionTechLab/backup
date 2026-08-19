// Chord parsing and transposition logic

const AllNotes = ['C', 'C#', 'D', 'D#', 'E', 'F', 'F#', 'G', 'G#', 'A', 'A#', 'B'];
const AllNotesFlat = ['C', 'Db', 'D', 'Eb', 'E', 'F', 'Gb', 'G', 'Ab', 'A', 'Bb', 'B']; // For reference or future use

const noteEquivalents = {
  'DB': 'C#', 'EB': 'D#', 'FB': 'E', 'GB': 'F#', 'AB': 'G#', 'BB': 'A#', 'CB': 'B',
  'E#': 'F', 'B#': 'C'
};

const normalizeNote = (note) => {
  const upperNote = note.toUpperCase();
  if (noteEquivalents[upperNote]) {
    return noteEquivalents[upperNote];
  }
  if (AllNotes.includes(note)) return note;
  const flatIndex = AllNotesFlat.indexOf(note);
  if (flatIndex !== -1) return AllNotes[flatIndex];
  return note;
};

/**
 * Parses lyrics with inline chords into an array of objects.
 * Example: "[C]Lyrics [G]here" -> [{chord: 'C', text: 'Lyrics '}, {chord: 'G', text: 'here'}]
 * And "Intro [C]Verse" -> [{type: 'text', content: 'Intro '}, {type: 'chord', chord: 'C', text: 'Verse'}]
 */
export const parseChordProFormat = (chordLyricText) => {
  if (typeof chordLyricText !== 'string' || !chordLyricText) return [];

  const parts = [];
  // Regex: Optionally match a chord `(\[[^\]]+?\])?`, then match any text that is not an opening bracket `([^\[]*)`
  // The `g` flag ensures we find all occurrences.
  const regex = /(\[[^\]]+?\])?([^\[]*)/g;
  let match;

  // Important: regex.lastIndex is automatically managed by `exec` with the `g` flag.
  // We must ensure that the loop terminates if `exec` stops finding matches or if it finds an empty match that doesn't advance `lastIndex`.
  while ((match = regex.exec(chordLyricText)) !== null) {
    // If match[0] (the whole match) is an empty string, and lastIndex didn't advance,
    // it means the regex matched nothing and we risk an infinite loop.
    // This can happen if the regex can match an empty string at the end of the input.
    // For `([^\[]*)`, it can match an empty string.
    if (match[0] === "") {
      // If lastIndex isn't advancing, break to prevent infinite loop.
      // This might happen if the regex matches an empty string at the end of input.
      // A common way to handle this is to advance lastIndex manually if an empty match occurs at the end.
      // However, the below logic should only add non-empty segments.
      if (regex.lastIndex === match.index) { // Check if lastIndex advanced
          regex.lastIndex++; // Manually advance to avoid loop on empty match
      }
      // Continue to next iteration if it was an empty match, or if we decide to break.
      // For this parser, an empty string match from `([^\[]*)` at the end is possible.
      // We only care about non-empty segments.
    }

    const chord = match[1] ? match[1].substring(1, match[1].length - 1) : null; // Extract chord name without brackets
    const text = match[2];

    if (chord) {
      parts.push({ type: 'chord', chord: chord, text: text });
    } else if (text) { // Only text, no preceding chord in this segment
      parts.push({ type: 'text', content: text });
    }
    // If both chord and text are null/empty for a match, this iteration added nothing, which is fine.
  }

  return parts.filter(part => (part.type === 'chord' && (part.chord || part.text)) || (part.type === 'text' && part.content));
};


/**
 * Transposes a single chord by a number of semitones.
 */
export const transposeChord = (chord, semitones) => {
  if (typeof chord !== 'string' || !chord || semitones === 0) return chord;

  const chordRegex = /^([A-Ga-g](?:#|b)?)(.*)$/;
  const match = chord.match(chordRegex);

  if (!match) return chord;

  let root = match[1];
  const quality = match[2] || '';

  const firstChar = root.charAt(0).toUpperCase();
  const accidental = root.length > 1 ? root.substring(1) : '';
  let normalizedRoot = normalizeNote(firstChar + accidental);

  let noteIndex = AllNotes.indexOf(normalizedRoot);
  if (noteIndex === -1) {
      console.warn(`Could not find note index for normalized root: ${normalizedRoot} (original: ${root})`);
      return chord;
  }

  let newNoteIndex = (noteIndex + semitones) % 12;
  if (newNoteIndex < 0) {
    newNoteIndex += 12;
  }

  const newRoot = AllNotes[newNoteIndex];
  return newRoot + quality;
};

/**
 * Transposes all chords in a ChordPro-formatted string.
 */
export const transposeChordProString = (chordProString, semitones) => {
  if (semitones === 0 || typeof chordProString !== 'string') return chordProString;

  return chordProString.replace(/\[([^\]]+?)\]/g, (matchInBrackets, chordName) => {
    const transposed = transposeChord(chordName, semitones);
    return `[${transposed}]`;
  });
};

/**
 * Validates basic bracket usage.
 */
export const validateBrackets = (text) => {
  if (typeof text !== 'string') return true;
  let balance = 0;
  for (const char of text) {
    if (char === '[') balance++;
    else if (char === ']') balance--;
    if (balance < 0) return false;
  }
  return balance === 0;
};

// --- Test Area for parseChordProFormat ---
const runParserTests = () => {
  console.log("--- Running parseChordProFormat Tests (v4 Simple Regex) ---");
  const testCases = [
    { input: "[C]This is [G]a test. [Am]End.", name: "Basic" },
    { input: "Leading text [C]here.", name: "Leading Text" },
    { input: "[C]No text after.", name: "No Text After Chord" },
    { input: "Only text, no chords.", name: "Only Text" },
    { input: "", name: "Empty String" },
    { input: "[C]", name: "Single Chord No Text" },
    { input: "[C][G][Am]", name: "Back-to-back Chords" },
    { input: "Text [C] then [G] more [Am] text.", name: "Mixed" },
    { input: "[C] Start [G] mid [Am] end", name: "Start Mid End Chords"},
    { input: "  [C]Space before [G]  space after and around[Am]  ", name: "Spaces Around"},
    { input: "[C]Line1\n[G]Line2", name: "Newline character (treated as text)"},
    { input: "[C]Almost[Unmatched", name: "Unmatched Bracket (should be handled by validateBrackets, parser might misinterpret)"},
    { input: "[[C]]Double Brackets", name: "Double Brackets"}
  ];

  testCases.forEach(tc => {
    console.log(`Test: ${tc.name} | Input: "${tc.input}"`);
    const result = parseChordProFormat(tc.input);
    console.log("Output:", JSON.stringify(result, null, 2));
    console.log("-----");
  });
};

// runParserTests(); // Re-commenting after verification.
// --- End Test Area ---


console.log("Chord Utils Loaded (v4 - Simple Regex Parser)");
