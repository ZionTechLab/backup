/**
 * Yamaha XG / PSR-SX Voice Map
 * Format: { msb, lsb, pc, name, category }
 * pc is 0-based (MIDI program number 0-127)
 */

export const VOICE_CATEGORIES = [
  'Piano', 'Chromatic Perc', 'Organ', 'Guitar', 'Bass',
  'Strings', 'Ensemble', 'Brass', 'Reed', 'Pipe',
  'Synth Lead', 'Synth Pad', 'Synth FX', 'World', 'Percussive',
  'Sound FX', 'Drum Kit',
];

// General MIDI program names (0-based)
export const GM_VOICES = [
  // Piano (0-7)
  { pc: 0,   msb: 0, lsb: 0, name: 'Grand Piano',        category: 'Piano' },
  { pc: 1,   msb: 0, lsb: 0, name: 'Bright Grand Piano', category: 'Piano' },
  { pc: 2,   msb: 0, lsb: 0, name: 'Electric Grand',     category: 'Piano' },
  { pc: 3,   msb: 0, lsb: 0, name: 'Honky-Tonk Piano',   category: 'Piano' },
  { pc: 4,   msb: 0, lsb: 0, name: 'Electric Piano 1',   category: 'Piano' },
  { pc: 5,   msb: 0, lsb: 0, name: 'Electric Piano 2',   category: 'Piano' },
  { pc: 6,   msb: 0, lsb: 0, name: 'Harpsichord',        category: 'Piano' },
  { pc: 7,   msb: 0, lsb: 0, name: 'Clavinet',           category: 'Piano' },
  // Chromatic Perc (8-15)
  { pc: 8,   msb: 0, lsb: 0, name: 'Celesta',            category: 'Chromatic Perc' },
  { pc: 9,   msb: 0, lsb: 0, name: 'Glockenspiel',       category: 'Chromatic Perc' },
  { pc: 10,  msb: 0, lsb: 0, name: 'Music Box',          category: 'Chromatic Perc' },
  { pc: 11,  msb: 0, lsb: 0, name: 'Vibraphone',         category: 'Chromatic Perc' },
  { pc: 12,  msb: 0, lsb: 0, name: 'Marimba',            category: 'Chromatic Perc' },
  { pc: 13,  msb: 0, lsb: 0, name: 'Xylophone',          category: 'Chromatic Perc' },
  { pc: 14,  msb: 0, lsb: 0, name: 'Tubular Bells',      category: 'Chromatic Perc' },
  { pc: 15,  msb: 0, lsb: 0, name: 'Dulcimer',           category: 'Chromatic Perc' },
  // Organ (16-23)
  { pc: 16,  msb: 0, lsb: 0, name: 'Drawbar Organ',      category: 'Organ' },
  { pc: 17,  msb: 0, lsb: 0, name: 'Percussive Organ',   category: 'Organ' },
  { pc: 18,  msb: 0, lsb: 0, name: 'Rock Organ',         category: 'Organ' },
  { pc: 19,  msb: 0, lsb: 0, name: 'Church Organ',       category: 'Organ' },
  { pc: 20,  msb: 0, lsb: 0, name: 'Reed Organ',         category: 'Organ' },
  { pc: 21,  msb: 0, lsb: 0, name: 'Accordion',          category: 'Organ' },
  { pc: 22,  msb: 0, lsb: 0, name: 'Harmonica',          category: 'Organ' },
  { pc: 23,  msb: 0, lsb: 0, name: 'Bandoneon',          category: 'Organ' },
  // Guitar (24-31)
  { pc: 24,  msb: 0, lsb: 0, name: 'Nylon Guitar',       category: 'Guitar' },
  { pc: 25,  msb: 0, lsb: 0, name: 'Steel Guitar',       category: 'Guitar' },
  { pc: 26,  msb: 0, lsb: 0, name: 'Jazz Guitar',        category: 'Guitar' },
  { pc: 27,  msb: 0, lsb: 0, name: 'Clean Guitar',       category: 'Guitar' },
  { pc: 28,  msb: 0, lsb: 0, name: 'Muted Guitar',       category: 'Guitar' },
  { pc: 29,  msb: 0, lsb: 0, name: 'Overdriven Guitar',  category: 'Guitar' },
  { pc: 30,  msb: 0, lsb: 0, name: 'Distortion Guitar',  category: 'Guitar' },
  { pc: 31,  msb: 0, lsb: 0, name: 'Guitar Harmonics',   category: 'Guitar' },
  // Bass (32-39)
  { pc: 32,  msb: 0, lsb: 0, name: 'Acoustic Bass',      category: 'Bass' },
  { pc: 33,  msb: 0, lsb: 0, name: 'Finger Bass',        category: 'Bass' },
  { pc: 34,  msb: 0, lsb: 0, name: 'Pick Bass',          category: 'Bass' },
  { pc: 35,  msb: 0, lsb: 0, name: 'Fretless Bass',      category: 'Bass' },
  { pc: 36,  msb: 0, lsb: 0, name: 'Slap Bass 1',        category: 'Bass' },
  { pc: 37,  msb: 0, lsb: 0, name: 'Slap Bass 2',        category: 'Bass' },
  { pc: 38,  msb: 0, lsb: 0, name: 'Synth Bass 1',       category: 'Bass' },
  { pc: 39,  msb: 0, lsb: 0, name: 'Synth Bass 2',       category: 'Bass' },
  // Strings (40-47)
  { pc: 40,  msb: 0, lsb: 0, name: 'Violin',             category: 'Strings' },
  { pc: 41,  msb: 0, lsb: 0, name: 'Viola',              category: 'Strings' },
  { pc: 42,  msb: 0, lsb: 0, name: 'Cello',              category: 'Strings' },
  { pc: 43,  msb: 0, lsb: 0, name: 'Contrabass',         category: 'Strings' },
  { pc: 44,  msb: 0, lsb: 0, name: 'Tremolo Strings',    category: 'Strings' },
  { pc: 45,  msb: 0, lsb: 0, name: 'Pizzicato Strings',  category: 'Strings' },
  { pc: 46,  msb: 0, lsb: 0, name: 'Orchestral Harp',    category: 'Strings' },
  { pc: 47,  msb: 0, lsb: 0, name: 'Timpani',            category: 'Strings' },
  // Ensemble (48-55)
  { pc: 48,  msb: 0, lsb: 0, name: 'String Ensemble 1',  category: 'Ensemble' },
  { pc: 49,  msb: 0, lsb: 0, name: 'String Ensemble 2',  category: 'Ensemble' },
  { pc: 50,  msb: 0, lsb: 0, name: 'Synth Strings 1',    category: 'Ensemble' },
  { pc: 51,  msb: 0, lsb: 0, name: 'Synth Strings 2',    category: 'Ensemble' },
  { pc: 52,  msb: 0, lsb: 0, name: 'Choir Aahs',         category: 'Ensemble' },
  { pc: 53,  msb: 0, lsb: 0, name: 'Voice Oohs',         category: 'Ensemble' },
  { pc: 54,  msb: 0, lsb: 0, name: 'Synth Voice',        category: 'Ensemble' },
  { pc: 55,  msb: 0, lsb: 0, name: 'Orchestra Hit',      category: 'Ensemble' },
  // Brass (56-63)
  { pc: 56,  msb: 0, lsb: 0, name: 'Trumpet',            category: 'Brass' },
  { pc: 57,  msb: 0, lsb: 0, name: 'Trombone',           category: 'Brass' },
  { pc: 58,  msb: 0, lsb: 0, name: 'Tuba',               category: 'Brass' },
  { pc: 59,  msb: 0, lsb: 0, name: 'Muted Trumpet',      category: 'Brass' },
  { pc: 60,  msb: 0, lsb: 0, name: 'French Horn',        category: 'Brass' },
  { pc: 61,  msb: 0, lsb: 0, name: 'Brass Section',      category: 'Brass' },
  { pc: 62,  msb: 0, lsb: 0, name: 'Synth Brass 1',      category: 'Brass' },
  { pc: 63,  msb: 0, lsb: 0, name: 'Synth Brass 2',      category: 'Brass' },
  // Reed (64-71)
  { pc: 64,  msb: 0, lsb: 0, name: 'Soprano Sax',        category: 'Reed' },
  { pc: 65,  msb: 0, lsb: 0, name: 'Alto Sax',           category: 'Reed' },
  { pc: 66,  msb: 0, lsb: 0, name: 'Tenor Sax',          category: 'Reed' },
  { pc: 67,  msb: 0, lsb: 0, name: 'Baritone Sax',       category: 'Reed' },
  { pc: 68,  msb: 0, lsb: 0, name: 'Oboe',               category: 'Reed' },
  { pc: 69,  msb: 0, lsb: 0, name: 'English Horn',       category: 'Reed' },
  { pc: 70,  msb: 0, lsb: 0, name: 'Bassoon',            category: 'Reed' },
  { pc: 71,  msb: 0, lsb: 0, name: 'Clarinet',           category: 'Reed' },
  // Pipe (72-79)
  { pc: 72,  msb: 0, lsb: 0, name: 'Piccolo',            category: 'Pipe' },
  { pc: 73,  msb: 0, lsb: 0, name: 'Flute',              category: 'Pipe' },
  { pc: 74,  msb: 0, lsb: 0, name: 'Recorder',           category: 'Pipe' },
  { pc: 75,  msb: 0, lsb: 0, name: 'Pan Flute',          category: 'Pipe' },
  { pc: 76,  msb: 0, lsb: 0, name: 'Blown Bottle',       category: 'Pipe' },
  { pc: 77,  msb: 0, lsb: 0, name: 'Shakuhachi',         category: 'Pipe' },
  { pc: 78,  msb: 0, lsb: 0, name: 'Whistle',            category: 'Pipe' },
  { pc: 79,  msb: 0, lsb: 0, name: 'Ocarina',            category: 'Pipe' },
  // Synth Lead (80-87)
  { pc: 80,  msb: 0, lsb: 0, name: 'Square Lead',        category: 'Synth Lead' },
  { pc: 81,  msb: 0, lsb: 0, name: 'Sawtooth Lead',      category: 'Synth Lead' },
  { pc: 82,  msb: 0, lsb: 0, name: 'Calliope Lead',      category: 'Synth Lead' },
  { pc: 83,  msb: 0, lsb: 0, name: 'Chiff Lead',         category: 'Synth Lead' },
  { pc: 84,  msb: 0, lsb: 0, name: 'Charang Lead',       category: 'Synth Lead' },
  { pc: 85,  msb: 0, lsb: 0, name: 'Voice Lead',         category: 'Synth Lead' },
  { pc: 86,  msb: 0, lsb: 0, name: 'Fifths Lead',        category: 'Synth Lead' },
  { pc: 87,  msb: 0, lsb: 0, name: 'Bass+Lead',          category: 'Synth Lead' },
  // Synth Pad (88-95)
  { pc: 88,  msb: 0, lsb: 0, name: 'New Age Pad',        category: 'Synth Pad' },
  { pc: 89,  msb: 0, lsb: 0, name: 'Warm Pad',           category: 'Synth Pad' },
  { pc: 90,  msb: 0, lsb: 0, name: 'Polysynth Pad',      category: 'Synth Pad' },
  { pc: 91,  msb: 0, lsb: 0, name: 'Choir Pad',          category: 'Synth Pad' },
  { pc: 92,  msb: 0, lsb: 0, name: 'Bowed Pad',          category: 'Synth Pad' },
  { pc: 93,  msb: 0, lsb: 0, name: 'Metallic Pad',       category: 'Synth Pad' },
  { pc: 94,  msb: 0, lsb: 0, name: 'Halo Pad',           category: 'Synth Pad' },
  { pc: 95,  msb: 0, lsb: 0, name: 'Sweep Pad',          category: 'Synth Pad' },
  // Synth FX (96-103)
  { pc: 96,  msb: 0, lsb: 0, name: 'Rain FX',            category: 'Synth FX' },
  { pc: 97,  msb: 0, lsb: 0, name: 'Soundtrack FX',      category: 'Synth FX' },
  { pc: 98,  msb: 0, lsb: 0, name: 'Crystal FX',         category: 'Synth FX' },
  { pc: 99,  msb: 0, lsb: 0, name: 'Atmosphere FX',      category: 'Synth FX' },
  { pc: 100, msb: 0, lsb: 0, name: 'Brightness FX',      category: 'Synth FX' },
  { pc: 101, msb: 0, lsb: 0, name: 'Goblins FX',         category: 'Synth FX' },
  { pc: 102, msb: 0, lsb: 0, name: 'Echoes FX',          category: 'Synth FX' },
  { pc: 103, msb: 0, lsb: 0, name: 'Sci-Fi FX',          category: 'Synth FX' },
  // World (104-111)
  { pc: 104, msb: 0, lsb: 0, name: 'Sitar',              category: 'World' },
  { pc: 105, msb: 0, lsb: 0, name: 'Banjo',              category: 'World' },
  { pc: 106, msb: 0, lsb: 0, name: 'Shamisen',           category: 'World' },
  { pc: 107, msb: 0, lsb: 0, name: 'Koto',               category: 'World' },
  { pc: 108, msb: 0, lsb: 0, name: 'Kalimba',            category: 'World' },
  { pc: 109, msb: 0, lsb: 0, name: 'Bag Pipe',           category: 'World' },
  { pc: 110, msb: 0, lsb: 0, name: 'Fiddle',             category: 'World' },
  { pc: 111, msb: 0, lsb: 0, name: 'Shanai',             category: 'World' },
  // Percussive (112-119)
  { pc: 112, msb: 0, lsb: 0, name: 'Tinkle Bell',        category: 'Percussive' },
  { pc: 113, msb: 0, lsb: 0, name: 'Agogo',              category: 'Percussive' },
  { pc: 114, msb: 0, lsb: 0, name: 'Steel Drums',        category: 'Percussive' },
  { pc: 115, msb: 0, lsb: 0, name: 'Woodblock',          category: 'Percussive' },
  { pc: 116, msb: 0, lsb: 0, name: 'Taiko Drum',         category: 'Percussive' },
  { pc: 117, msb: 0, lsb: 0, name: 'Melodic Tom',        category: 'Percussive' },
  { pc: 118, msb: 0, lsb: 0, name: 'Synth Drum',         category: 'Percussive' },
  { pc: 119, msb: 0, lsb: 0, name: 'Reverse Cymbal',     category: 'Percussive' },
  // Sound FX (120-127)
  { pc: 120, msb: 0, lsb: 0, name: 'Guitar Fret Noise',  category: 'Sound FX' },
  { pc: 121, msb: 0, lsb: 0, name: 'Breath Noise',       category: 'Sound FX' },
  { pc: 122, msb: 0, lsb: 0, name: 'Seashore',           category: 'Sound FX' },
  { pc: 123, msb: 0, lsb: 0, name: 'Bird Tweet',         category: 'Sound FX' },
  { pc: 124, msb: 0, lsb: 0, name: 'Telephone Ring',     category: 'Sound FX' },
  { pc: 125, msb: 0, lsb: 0, name: 'Helicopter',         category: 'Sound FX' },
  { pc: 126, msb: 0, lsb: 0, name: 'Applause',           category: 'Sound FX' },
  { pc: 127, msb: 0, lsb: 0, name: 'Gunshot',            category: 'Sound FX' },
];

// Yamaha XG / PSR-SX extended voices (common ones)
export const XG_VOICES = [
  // Mega Voices
  { pc: 0,  msb: 56, lsb: 0,   name: 'MegaVoice Guitar',    category: 'Guitar' },
  { pc: 32, msb: 56, lsb: 0,   name: 'MegaVoice Bass',      category: 'Bass' },
  // Sweet Voices
  { pc: 40, msb: 104, lsb: 0,  name: 'Sweet Violin',        category: 'Strings' },
  { pc: 56, msb: 104, lsb: 0,  name: 'Sweet Trumpet',       category: 'Brass' },
  { pc: 65, msb: 104, lsb: 0,  name: 'Sweet Alto Sax',      category: 'Reed' },
  { pc: 73, msb: 104, lsb: 0,  name: 'Sweet Flute',         category: 'Pipe' },
  // Cool Voices
  { pc: 25, msb: 104, lsb: 8,  name: 'Cool Steel Guitar',   category: 'Guitar' },
  { pc: 33, msb: 104, lsb: 8,  name: 'Cool Finger Bass',    category: 'Bass' },
  // Drum kits (ch 10)
  { pc: 0,  msb: 127, lsb: 0,  name: 'Standard Kit',        category: 'Drum Kit' },
  { pc: 8,  msb: 127, lsb: 0,  name: 'Room Kit',            category: 'Drum Kit' },
  { pc: 16, msb: 127, lsb: 0,  name: 'Power Kit',           category: 'Drum Kit' },
  { pc: 24, msb: 127, lsb: 0,  name: 'Electronic Kit',      category: 'Drum Kit' },
  { pc: 25, msb: 127, lsb: 0,  name: 'Analog Kit',          category: 'Drum Kit' },
  { pc: 32, msb: 127, lsb: 0,  name: 'Jazz Kit',            category: 'Drum Kit' },
  { pc: 40, msb: 127, lsb: 0,  name: 'Brush Kit',           category: 'Drum Kit' },
  { pc: 48, msb: 127, lsb: 0,  name: 'Orchestra Kit',       category: 'Drum Kit' },
  { pc: 56, msb: 127, lsb: 0,  name: 'SFX Kit',             category: 'Drum Kit' },
];

export const ALL_VOICES = [...GM_VOICES, ...XG_VOICES];

export function lookupVoiceName(msb, lsb, pc) {
  // Try exact match first
  const exact = ALL_VOICES.find(v => v.msb === msb && v.lsb === lsb && v.pc === pc);
  if (exact) return exact.name;

  // Fall back to GM by program number
  const gm = GM_VOICES.find(v => v.pc === pc);
  if (gm) return gm.name;

  return `Voice ${msb}/${lsb}/${pc + 1}`;
}

export function getVoicesByCategory(category) {
  return ALL_VOICES.filter(v => v.category === category);
}

// Returns the full voice object (including category) for a given msb/lsb/pc, or null.
export function findVoice(msb, lsb, pc) {
  const exact = ALL_VOICES.find(v => v.msb === msb && v.lsb === lsb && v.pc === pc);
  if (exact) return exact;
  return ALL_VOICES.find(v => v.pc === pc) ?? null;
}
