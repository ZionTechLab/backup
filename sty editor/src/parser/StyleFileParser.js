/**
 * Yamaha Style File Parser
 * Supports SFF1 (PSR-S series) and SFF2 (PSR-SX series) formats
 * All Yamaha style extensions (.sty, .prs, .sst, .bcs, .pst, .pcs, .fps)
 * share the same internal binary format.
 */

export const STYLE_EXTENSIONS = ['.sty', '.prs', '.sst', '.bcs', '.pst', '.pcs', '.fps'];

export const FORMAT_SFF1 = 'SFF1';
export const FORMAT_SFF2 = 'SFF2';

// MIDI event types
const META_EVENT = 0xFF;
const SYSEX_EVENT = 0xF0;
const SYSEX_END = 0xF7;

// Channel voice messages
const NOTE_OFF = 0x80;
const NOTE_ON = 0x90;
const POLY_PRESSURE = 0xA0;
const CONTROL_CHANGE = 0xB0;
const PROGRAM_CHANGE = 0xC0;
const CHANNEL_PRESSURE = 0xD0;
const PITCH_BEND = 0xE0;

// Style section identifiers (used in CASM/CSEG)
export const SECTION_NAMES = [
  'Intro 1', 'Intro 2', 'Intro 3',
  'Main A', 'Main B', 'Main C', 'Main D',
  'Fill In AA', 'Fill In BB', 'Fill In CC', 'Fill In DD', 'Fill In BA',
  'Break Fill',
  'Ending 1', 'Ending 2', 'Ending 3',
];

// Section type codes found in CSEG
export const SECTION_TYPE_MAP = {
  0x00: 'Intro 1',
  0x01: 'Intro 2',
  0x02: 'Intro 3',
  0x08: 'Main A',
  0x09: 'Main B',
  0x0A: 'Main C',
  0x0B: 'Main D',
  0x10: 'Fill In AA',
  0x11: 'Fill In BB',
  0x12: 'Fill In CC',
  0x13: 'Fill In DD',
  0x14: 'Fill In BA',
  0x18: 'Break Fill',
  0x20: 'Ending 1',
  0x21: 'Ending 2',
  0x22: 'Ending 3',
};

// Alternate section name spellings used by SFF2 Format-0 files
const SECTION_NAME_ALIASES = {
  'Intro A': 'Intro 1', 'Intro B': 'Intro 2', 'Intro C': 'Intro 3',
  'Ending A': 'Ending 1', 'Ending B': 'Ending 2', 'Ending C': 'Ending 3',
};
function normalizeSectionMarker(text) {
  const t = (text || '').trim();
  return SECTION_NAME_ALIASES[t] || t;
}

// Reverse map: name -> code
export const SECTION_CODE_MAP = Object.fromEntries(
  Object.entries(SECTION_TYPE_MAP).map(([k, v]) => [v, parseInt(k)])
);

// Part (MIDI channel) names — 1-indexed
export const PART_NAMES = {
  1: 'Rhythm 1',
  2: 'Rhythm 2',
  3: 'Bass',
  4: 'Chord 1',
  5: 'Chord 2',
  6: 'Pad',
  7: 'Phrase 1',
  8: 'Phrase 2',
};

// ─── Low-level buffer reader ─────────────────────────────────────────────────

class BufferReader {
  constructor(buffer) {
    this.view = new DataView(buffer);
    this.bytes = new Uint8Array(buffer);
    this.pos = 0;
    this.length = buffer.byteLength;
  }

  eof() { return this.pos >= this.length; }
  remaining() { return this.length - this.pos; }

  peek(offset = 0) { return this.bytes[this.pos + offset]; }

  readUint8() {
    if (this.pos >= this.length) throw new Error(`EOF at position ${this.pos}`);
    return this.bytes[this.pos++];
  }

  readUint16BE() {
    const v = this.view.getUint16(this.pos, false);
    this.pos += 2;
    return v;
  }

  readUint32BE() {
    const v = this.view.getUint32(this.pos, false);
    this.pos += 4;
    return v;
  }

  readBytes(n) {
    const slice = this.bytes.slice(this.pos, this.pos + n);
    this.pos += n;
    return slice;
  }

  readString(n) {
    const bytes = this.readBytes(n);
    return String.fromCharCode(...bytes).replace(/\0/g, '').trim();
  }

  readVarLen() {
    let value = 0;
    let byte;
    do {
      if (this.pos >= this.length) throw new Error('EOF while reading var-len');
      byte = this.bytes[this.pos++];
      value = (value << 7) | (byte & 0x7F);
    } while (byte & 0x80);
    return value;
  }

  seek(pos) { this.pos = pos; }
  skip(n) { this.pos += n; }

  subReader(length) {
    const slice = this.bytes.buffer.slice(this.pos, this.pos + length);
    this.pos += length;
    return new BufferReader(slice);
  }
}

// ─── MIDI track event parser ──────────────────────────────────────────────────

function parseMidiTrack(reader) {
  const events = [];
  let absoluteTick = 0;
  let runningStatus = 0;

  while (!reader.eof()) {
    const delta = reader.readVarLen();
    absoluteTick += delta;

    if (reader.eof()) break;

    let statusByte = reader.peek();

    // Running status: reuse previous if high bit not set
    if (statusByte & 0x80) {
      runningStatus = statusByte;
      reader.readUint8();
    } else {
      statusByte = runningStatus;
    }

    const type = statusByte & 0xF0;
    const channel = (statusByte & 0x0F) + 1; // 1-based

    const event = { tick: absoluteTick, delta, type: statusByte };

    if (statusByte === META_EVENT) {
      const metaType = reader.readUint8();
      const length = reader.readVarLen();
      const data = reader.readBytes(length);
      event.kind = 'meta';
      event.metaType = metaType;
      event.data = data;

      switch (metaType) {
        case 0x00: event.name = 'Sequence Number'; break;
        case 0x01: event.name = 'Text'; event.text = String.fromCharCode(...data); break;
        case 0x02: event.name = 'Copyright'; event.text = String.fromCharCode(...data); break;
        case 0x03: event.name = 'Track Name'; event.text = String.fromCharCode(...data).replace(/\0/g, '').trim(); break;
        case 0x04: event.name = 'Instrument Name'; event.text = String.fromCharCode(...data); break;
        case 0x05: event.name = 'Lyric'; event.text = String.fromCharCode(...data); break;
        case 0x06: event.name = 'Marker'; event.text = String.fromCharCode(...data).replace(/\0/g, '').trim(); break;
        case 0x07: event.name = 'Cue Point'; event.text = String.fromCharCode(...data).replace(/\0/g, '').trim(); break;
        case 0x20: event.name = 'MIDI Channel Prefix'; event.channel = data[0] + 1; break;
        case 0x21: event.name = 'MIDI Port'; event.port = data[0]; break;
        case 0x2F: event.name = 'End of Track'; break;
        case 0x51: {
          event.name = 'Set Tempo';
          event.tempo = (data[0] << 16) | (data[1] << 8) | data[2];
          event.bpm = Math.round(60000000 / event.tempo);
          break;
        }
        case 0x54: event.name = 'SMPTE Offset'; break;
        case 0x58: {
          event.name = 'Time Signature';
          event.numerator = data[0];
          event.denominator = Math.pow(2, data[1]);
          event.clocksPerClick = data[2];
          event.thirtySecondsPer24Clocks = data[3];
          break;
        }
        case 0x59: {
          event.name = 'Key Signature';
          const sf = data[0] > 127 ? data[0] - 256 : data[0]; // signed
          event.sharpsFlats = sf;
          event.major = data[1] === 0;
          break;
        }
        case 0x7F: event.name = 'Sequencer Specific'; break;
        default: event.name = `Meta 0x${metaType.toString(16).padStart(2, '0')}`; break;
      }
      runningStatus = 0; // meta resets running status
    } else if (statusByte === SYSEX_EVENT || statusByte === SYSEX_END) {
      const length = reader.readVarLen();
      const data = reader.readBytes(length);
      event.kind = 'sysex';
      event.data = data;
      runningStatus = 0;
    } else {
      event.kind = 'channel';
      event.channel = channel;

      switch (type) {
        case NOTE_OFF:
          event.name = 'Note Off';
          event.note = reader.readUint8();
          event.velocity = reader.readUint8();
          break;
        case NOTE_ON: {
          const note = reader.readUint8();
          const velocity = reader.readUint8();
          event.name = velocity === 0 ? 'Note Off' : 'Note On';
          event.note = note;
          event.velocity = velocity;
          break;
        }
        case POLY_PRESSURE:
          event.name = 'Poly Pressure';
          event.note = reader.readUint8();
          event.pressure = reader.readUint8();
          break;
        case CONTROL_CHANGE: {
          const cc = reader.readUint8();
          const val = reader.readUint8();
          event.name = 'Control Change';
          event.controller = cc;
          event.value = val;
          event.ccName = getControllerName(cc);
          break;
        }
        case PROGRAM_CHANGE:
          event.name = 'Program Change';
          event.program = reader.readUint8();
          break;
        case CHANNEL_PRESSURE:
          event.name = 'Channel Pressure';
          event.pressure = reader.readUint8();
          break;
        case PITCH_BEND: {
          const lsb = reader.readUint8();
          const msb = reader.readUint8();
          event.name = 'Pitch Bend';
          event.value = ((msb << 7) | lsb) - 8192;
          break;
        }
        default:
          event.name = `Unknown 0x${statusByte.toString(16)}`;
          break;
      }
    }

    events.push(event);

    if (event.kind === 'meta' && event.metaType === 0x2F) break; // End of Track
  }

  return events;
}

function getControllerName(cc) {
  const names = {
    0: 'Bank Select MSB', 1: 'Modulation', 2: 'Breath',
    4: 'Foot', 5: 'Portamento Time', 6: 'Data Entry MSB',
    7: 'Volume', 8: 'Balance', 10: 'Pan',
    11: 'Expression', 32: 'Bank Select LSB', 38: 'Data Entry LSB',
    64: 'Sustain', 65: 'Portamento', 66: 'Sostenuto',
    67: 'Soft Pedal', 71: 'Resonance', 72: 'Release',
    73: 'Attack', 74: 'Brightness', 84: 'Portamento Control',
    91: 'Reverb Send', 92: 'Tremolo Depth', 93: 'Chorus Send',
    94: 'Celeste Depth', 95: 'Phaser Depth',
    96: 'Data Increment', 97: 'Data Decrement',
    98: 'NRPN LSB', 99: 'NRPN MSB', 100: 'RPN LSB', 101: 'RPN MSB',
    120: 'All Sound Off', 121: 'Reset All Controllers',
    123: 'All Notes Off',
  };
  return names[cc] || `CC ${cc}`;
}

// ─── Extract per-channel info from track events ───────────────────────────────

function extractChannelInfo(events) {
  const channels = {};

  for (const ev of events) {
    if (ev.kind !== 'channel') continue;
    const ch = ev.channel;
    if (!channels[ch]) {
      channels[ch] = {
        channel: ch,
        partName: PART_NAMES[ch] || `Channel ${ch}`,
        volume: 100,
        pan: 64,
        reverb: 40,
        chorus: 0,
        expression: 127,
        bankMSB: 0,
        bankLSB: 0,
        program: 0,
        notes: [],
        events: [],
      };
    }
    const ch_data = channels[ch];
    ch_data.events.push(ev);

    if (ev.name === 'Control Change') {
      switch (ev.controller) {
        case 0:  ch_data.bankMSB  = ev.value; break;
        case 7:  ch_data.volume   = ev.value; break;
        case 10: ch_data.pan      = ev.value; break;
        case 11: ch_data.expression = ev.value; break;
        case 32: ch_data.bankLSB  = ev.value; break;
        case 91: ch_data.reverb   = ev.value; break;
        case 93: ch_data.chorus   = ev.value; break;
      }
    } else if (ev.name === 'Program Change') {
      ch_data.program = ev.program;
    } else if (ev.name === 'Note On' && ev.velocity > 0) {
      ch_data.notes.push(ev);
    }
  }

  return channels;
}

// ─── CASM chunk parser ────────────────────────────────────────────────────────

function parseCASM(data) {
  const reader = new BufferReader(data.buffer.slice(data.byteOffset, data.byteOffset + data.byteLength));
  const segments = [];

  while (reader.remaining() >= 8) {
    // Each CASM entry: "CSEG" + 4-byte size + data
    const tag = reader.readString(4);
    if (tag !== 'CSEG') {
      // Try to skip unknown sub-chunks
      if (reader.remaining() >= 4) {
        const size = reader.readUint32BE();
        if (size > reader.remaining()) break;
        reader.skip(size);
      }
      continue;
    }

    const segSize = reader.readUint32BE();
    if (segSize > reader.remaining()) break;
    const segReader = reader.subReader(segSize);
    const seg = parseCSEG(segReader);
    if (seg) segments.push(seg);
  }

  return segments;
}

function parseCSEG(reader) {
  if (reader.remaining() < 8) return null; // SFF1 CSEGs are 8 bytes; SFF2 are 12 or 16

  const seg = {};
  seg.sectionCode = reader.readUint8();
  seg.sectionName = SECTION_TYPE_MAP[seg.sectionCode] || `Section 0x${seg.sectionCode.toString(16)}`;
  seg.channel     = reader.readUint8() + 1; // 0-based in file, 1-based for us
  seg.noteTransposition = reader.readUint8();  // Crd vs. Mel note transposition
  seg.sourceRootNote    = reader.readUint8();  // source root note
  seg.chordType         = reader.readUint8();  // chord type
  seg.sourceRootRange   = reader.readUint8();  // source root range
  seg.noteTranspRule    = reader.readUint8();  // note transposition rule
  seg.highKey           = reader.readUint8();  // high key (SFF1 source root)

  if (reader.remaining() >= 4) {
    seg.noteRange       = reader.readUint8();
    seg.rtpRtpg         = reader.readUint8();
    seg.reserved1       = reader.readUint8();
    seg.reserved2       = reader.readUint8();
  }

  // SFF2 additional fields
  if (reader.remaining() >= 4) {
    seg.editable      = reader.readUint8();
    seg.portamento    = reader.readUint8();
    seg.reserved3     = reader.readUint8();
    seg.reserved4     = reader.readUint8();
  }

  return seg;
}

// ─── Sdec chunk parser (Style Declaration) ────────────────────────────────────

function parseSdec(data) {
  const sdec = {};

  // Style name (usually first 8-16 bytes, null-padded)
  const nameBytes = [];
  let i = 0;
  while (i < data.length && data[i] !== 0) {
    nameBytes.push(data[i]);
    i++;
  }
  sdec.styleName = String.fromCharCode(...nameBytes).trim();
  sdec.rawLength = data.length;

  return sdec;
}

// ─── OTS chunk parser (One Touch Settings) ────────────────────────────────────

function parseOTSc(data) {
  const reader = new BufferReader(data.buffer.slice(data.byteOffset, data.byteOffset + data.byteLength));
  const slots = [];

  // OTSc has 4 slots; each slot is a mini MIDI data block
  // The exact structure varies between PSR models; we do a best-effort parse
  for (let slot = 0; slot < 4; slot++) {
    if (reader.remaining() < 4) break;
    const slotData = {
      slot: slot + 1,
      voices: {},
    };

    // Read voice assignments per slot (R1, R2, R3, L)
    // Format: bank MSB, bank LSB, program, volume, octave, reserved...
    for (const part of ['right1', 'right2', 'right3', 'left']) {
      if (reader.remaining() < 8) break;
      slotData.voices[part] = {
        bankMSB:  reader.readUint8(),
        bankLSB:  reader.readUint8(),
        program:  reader.readUint8(),
        volume:   reader.readUint8(),
        octave:   reader.readUint8() - 64, // signed offset
        reserved: reader.readBytes(3),
      };
    }
    slots.push(slotData);
  }

  return slots;
}

// ─── Ctab chunk parser (Chord Table) ─────────────────────────────────────────

function parseCtab(data) {
  const reader = new BufferReader(data.buffer.slice(data.byteOffset, data.byteOffset + data.byteLength));
  const entries = [];

  while (reader.remaining() >= 4) {
    entries.push({
      noteNumber:    reader.readUint8(),
      chordType:     reader.readUint8(),
      bassNote:      reader.readUint8(),
      reserved:      reader.readUint8(),
    });
  }

  return entries;
}

// ─── MThd parser ─────────────────────────────────────────────────────────────

function parseMThd(data) {
  if (data.length < 6) throw new Error('MThd chunk too short');
  const view = new DataView(data.buffer, data.byteOffset, data.byteLength);
  return {
    format:   view.getUint16(0, false),
    numTracks: view.getUint16(2, false),
    division: view.getUint16(4, false), // ticks per quarter note (if bit 15 = 0)
    ticksPerQuarter: (view.getUint16(4, false) & 0x8000) === 0
      ? view.getUint16(4, false)
      : null,
  };
}

// ─── SFF format detector ──────────────────────────────────────────────────────

function detectFormat(buffer) {
  // SFF2 files contain "SFF2" text in their SysEx or Sdec data
  const bytes = new Uint8Array(buffer);
  const text = String.fromCharCode(...bytes.slice(0, Math.min(512, bytes.length)));

  if (text.includes('SFF2')) return FORMAT_SFF2;
  if (text.includes('SFF1')) return FORMAT_SFF1;

  // Secondary detection: scan all bytes for the marker
  for (let i = 0; i < bytes.length - 4; i++) {
    if (bytes[i] === 0x53 && bytes[i+1] === 0x46 && bytes[i+2] === 0x46) {
      if (bytes[i+3] === 0x32) return FORMAT_SFF2;
      if (bytes[i+3] === 0x31) return FORMAT_SFF1;
    }
  }

  // Default to SFF1 for older files without the marker
  return FORMAT_SFF1;
}

// ─── Build note objects with duration ────────────────────────────────────────

function buildNoteObjects(events) {
  const noteOns = {}; // key: `${note}-${channel}`
  const notes = [];

  for (const ev of events) {
    if (ev.kind !== 'channel') continue;
    const key = `${ev.note}-${ev.channel}`;

    if (ev.name === 'Note On' && ev.velocity > 0) {
      noteOns[key] = ev;
    } else if (ev.name === 'Note Off' || (ev.name === 'Note On' && ev.velocity === 0)) {
      if (noteOns[key]) {
        const on = noteOns[key];
        notes.push({
          tick:     on.tick,
          duration: ev.tick - on.tick,
          note:     on.note,
          velocity: on.velocity,
          channel:  on.channel,
        });
        delete noteOns[key];
      }
    }
  }

  // Any still-open notes (no Note Off found)
  for (const key of Object.keys(noteOns)) {
    const on = noteOns[key];
    notes.push({
      tick:     on.tick,
      duration: 0,
      note:     on.note,
      velocity: on.velocity,
      channel:  on.channel,
    });
  }

  notes.sort((a, b) => a.tick - b.tick);
  return notes;
}

// ─── Group tracks into style sections ────────────────────────────────────────

// ─── Format-0 / SFF2: section splitting by Meta Marker events ────────────────
//
// Some Yamaha keyboards (PSR-SX, etc.) store all sections in ONE MTrk and use
// Meta Marker events (type 0x06) as section boundaries.  Notes live on MIDI
// channels 9-16; we remap those down to 1-8 so the rest of the app is unaware.

function splitTrackBySectionMarkers(allEvents) {
  // Collect Marker events that map to known section names
  const sectionMarkers = [];
  for (const ev of allEvents) {
    if (ev.kind !== 'meta' || ev.metaType !== 0x06) continue;
    const name = normalizeSectionMarker(ev.text || '');
    if (SECTION_NAMES.includes(name)) sectionMarkers.push({ tick: ev.tick, name });
  }
  if (sectionMarkers.length === 0) return null; // not a Marker-style file

  // Build a channel remap: sort all used channels, map to 1-8
  const allChs = [...new Set(allEvents.filter(e => e.kind === 'channel').map(e => e.channel))].sort((a, b) => a - b);
  const chMap = {};
  allChs.forEach((ch, i) => { chMap[ch] = i + 1; });
  const remapCh = ch => chMap[ch] ?? ch;

  // Global setup events that appear before the first section marker (CCs, PCs, SysEx)
  const firstMarkerTick = sectionMarkers[0].tick;
  const preEvents = allEvents.filter(ev => ev.tick < firstMarkerTick);

  const sections = {};

  for (let i = 0; i < sectionMarkers.length; i++) {
    const { tick: startTick, name: sectionName } = sectionMarkers[i];
    const endTick = i + 1 < sectionMarkers.length ? sectionMarkers[i + 1].tick : Infinity;

    // Section-range events (notes, CCs, meta within this section)
    const secRaw = allEvents.filter(ev => ev.tick >= startTick && ev.tick < endTick);

    // Remap helper (tick-relative + channel normalised)
    const remap = (ev, baseTick) => ({
      ...ev,
      tick: Math.max(0, ev.tick - baseTick),
      channel: ev.kind === 'channel' ? remapCh(ev.channel) : ev.channel,
    });

    // Channel info uses pre-events (initial patch/volume) + section events
    const setupEvents = [...preEvents, ...secRaw].map(ev => remap(ev, startTick));
    const chInfo = extractChannelInfo(setupEvents);

    // Notes come only from section-range events (not pre-events) to avoid duplication
    const noteEvents = secRaw.map(ev => remap(ev, startTick));
    const notes = buildNoteObjects(noteEvents);

    // Per-channel virtual tracks
    const chNums = new Set(noteEvents.filter(e => e.kind === 'channel').map(e => e.channel));
    const tracks = {};
    const channelInfo = {};
    for (const ch of chNums) {
      tracks[ch] = { events: noteEvents.filter(e => e.kind === 'meta' || e.channel === ch) };
      channelInfo[ch] = chInfo[ch] || { channel: ch };
    }

    // Timing info from the combined event stream
    let tempo = null, timeSignature = null;
    for (const ev of setupEvents) {
      if (ev.kind !== 'meta') continue;
      if (ev.metaType === 0x51 && tempo === null) tempo = ev.bpm;
      if (ev.metaType === 0x58 && timeSignature === null) {
        timeSignature = { numerator: ev.numerator, denominator: ev.denominator };
      }
    }

    const length = notes.length > 0 ? Math.max(...notes.map(n => n.tick + Math.max(n.duration, 0))) : 0;

    sections[sectionName] = { name: sectionName, tracks, channelInfo, notes, tempo, timeSignature, length };
  }

  // Writer metadata — needed to reconstruct the original binary layout
  const chMapInverse = {};
  for (const [origCh, remappedCh] of Object.entries(chMap)) chMapInverse[remappedCh] = Number(origCh);
  sections.__meta = {
    preEvents,
    sectionOrder: sectionMarkers.map(m => m.name),
    chMapInverse,
    sectionStartTicks: Object.fromEntries(sectionMarkers.map(m => [m.name, m.tick])),
  };

  return sections;
}

function groupTracksIntoSections(tracks, casmSegments) {
  // SFF2 Format-0: single track with Meta Marker section boundaries — handle first
  if (tracks.length === 1) {
    const markerSections = splitTrackBySectionMarkers(tracks[0].events);
    if (markerSections) return markerSections;
  }

  // Strategy: each MTrk after track 0 corresponds to a style section+channel
  // The CASM segments provide the mapping metadata.
  const sections = {};

  // Initialize all section slots
  for (const name of SECTION_NAMES) {
    sections[name] = {
      name,
      tracks: {},
      channelInfo: {},
      notes: [],
      tempo: null,
      timeSignature: null,
      length: 0, // in bars
    };
  }

  // Helper: populate a section from a set of MIDI events + CASM segment
  function applySectionEvents(sectionName, chNum, events, casmSeg) {
    if (!sections[sectionName]) {
      sections[sectionName] = {
        name: sectionName, tracks: {}, channelInfo: {}, notes: [],
        tempo: null, timeSignature: null, length: 0,
      };
    }
    const sec = sections[sectionName];
    const chInfo = extractChannelInfo(events);
    sec.tracks[chNum] = { events };
    sec.channelInfo[chNum] = { ...(chInfo[chNum] || { channel: chNum }), casmSeg };
    sec.notes.push(...buildNoteObjects(events));
    for (const ev of events) {
      if (ev.kind !== 'meta') continue;
      if (ev.metaType === 0x51 && !sec.tempo) sec.tempo = ev.bpm;
      if (ev.metaType === 0x58 && !sec.timeSignature) {
        sec.timeSignature = { numerator: ev.numerator, denominator: ev.denominator };
      }
    }
    const lastTick = events.length > 0 ? Math.max(...events.map(e => e.tick)) : 0;
    sec.length = Math.max(sec.length, lastTick);
  }

  if (casmSegments.length > 0 && tracks.length > 1) {
    // Format 1: CASM segments map 1-to-1 to data tracks (skip conductor track 0)
    const dataTracks = tracks.slice(1);
    for (let i = 0; i < casmSegments.length && i < dataTracks.length; i++) {
      const seg = casmSegments[i];
      applySectionEvents(seg.sectionName, seg.channel, dataTracks[i].events, seg);
    }
  } else if (casmSegments.length > 0 && tracks.length === 1) {
    // Format 0: single track — split events by channel per CASM segment
    const allEvents = tracks[0].events;
    for (const seg of casmSegments) {
      const chEvents = allEvents.filter(
        ev => ev.kind === 'meta' || ev.channel === seg.channel
      );
      applySectionEvents(seg.sectionName, seg.channel, chEvents, seg);
    }
  } else if (tracks.length > 1) {
    // No CASM — infer from track order (8 tracks per section)
    const dataTracks = tracks.slice(1);
    for (let i = 0; i < dataTracks.length; i++) {
      const sectionIdx = Math.floor(i / 8);
      const chNum = (i % 8) + 1;
      const sectionName = SECTION_NAMES[sectionIdx] || `Section ${sectionIdx + 1}`;
      applySectionEvents(sectionName, chNum, dataTracks[i].events, null);
    }
  } else if (tracks.length === 1) {
    // Format 0, no CASM — put all channel events under Main A
    const allEvents = tracks[0].events;
    const channelSet = new Set(allEvents.filter(e => e.kind === 'channel').map(e => e.channel));
    for (const ch of channelSet) {
      const chEvents = allEvents.filter(ev => ev.kind === 'meta' || ev.channel === ch);
      applySectionEvents('Main A', ch, chEvents, null);
    }
  }

  // Remove empty sections
  const result = {};
  for (const [name, sec] of Object.entries(sections)) {
    const hasData = Object.keys(sec.tracks).length > 0 || sec.notes.length > 0;
    if (hasData) result[name] = sec;
  }

  return result;
}

// ─── Main parser entry point ──────────────────────────────────────────────────

export function parseStyleFile(arrayBuffer, filename = '') {
  // ── Pre-parse validation ─────────────────────────────────────────────────
  if (arrayBuffer.byteLength < 14) {
    throw new Error(
      `File is too small to be a valid style file (${arrayBuffer.byteLength} bytes). ` +
      `The minimum size for a MIDI-based file is 14 bytes.`
    );
  }

  const magic = String.fromCharCode(...new Uint8Array(arrayBuffer, 0, 4));
  if (magic !== 'MThd') {
    const hex = Array.from(new Uint8Array(arrayBuffer, 0, 4))
      .map(b => b.toString(16).padStart(2, '0')).join(' ');
    throw new Error(
      `Not a valid Yamaha style file — expected MIDI header "MThd" ` +
      `but found "${magic}" (${hex}). ` +
      `The file may be corrupt, encrypted, or use an unsupported format.`
    );
  }

  const reader = new BufferReader(arrayBuffer);
  const result = {
    filename,
    extension: filename.split('.').pop().toLowerCase(),
    format: detectFormat(arrayBuffer),
    header: null,
    tracks: [],
    casmSegments: [],
    sdec: null,
    ctab: [],
    cntt: [],
    otsSlots: [],
    mhdc: null,
    sections: {},
    globalTempo: 120,
    globalTimeSignature: { numerator: 4, denominator: 4 },
    styleName: filename.replace(/\.[^.]+$/, ''),
    rawChunks: [],
    errors: [],
    warnings: [],
  };

  try {
    // Parse chunks — each chunk is read fully before its handler runs, so
    // a handler error never corrupts the reader position.
    while (!reader.eof()) {
      if (reader.remaining() < 8) break;

      const tag = reader.readString(4);
      const size = reader.readUint32BE();

      if (size > reader.remaining()) {
        result.warnings.push(`Chunk "${tag}" size ${size} exceeds remaining bytes ${reader.remaining()}`);
        break;
      }

      // Read the chunk body BEFORE the switch — even if the handler throws,
      // the main reader is already past this chunk so the loop can continue.
      const chunkData = reader.readBytes(size);
      result.rawChunks.push({ tag, size, offset: reader.pos - size - 8, data: chunkData.slice() });

      try {
        switch (tag) {
          case 'MThd':
            result.header = parseMThd(chunkData);
            result.ticksPerBeat = result.header.ticksPerQuarter || 480;
            break;

          case 'MTrk': {
            // Parse track events; on error push an empty track so CASM index
            // alignment is preserved (CASM segment i → data track i).
            let events = [];
            try {
              const trackReader = new BufferReader(chunkData.buffer.slice(chunkData.byteOffset, chunkData.byteOffset + chunkData.byteLength));
              events = parseMidiTrack(trackReader);
            } catch (trackErr) {
              result.warnings.push(
                `MIDI track ${result.tracks.length} could not be fully read: ${trackErr.message}. ` +
                `Notes in this track may be missing or incomplete.`
              );
            }
            const trackIndex = result.tracks.length;
            result.tracks.push({ index: trackIndex, events, eventCount: events.length });

            // Extract global tempo and time sig from conductor track (track 0)
            if (trackIndex === 0) {
              for (const ev of events) {
                if (ev.kind === 'meta' && ev.metaType === 0x51) result.globalTempo = ev.bpm;
                if (ev.kind === 'meta' && ev.metaType === 0x58) {
                  result.globalTimeSignature = { numerator: ev.numerator, denominator: ev.denominator };
                }
              }
            }
            break;
          }

          case 'CASM':
            result.casmSegments = parseCASM(chunkData);
            break;

          case 'Sdec':
            result.sdec = parseSdec(chunkData);
            if (result.sdec.styleName) result.styleName = result.sdec.styleName;
            break;

          case 'Ctab':
            result.ctab = parseCtab(chunkData);
            break;

          case 'Cntt':
            result.cntt = Array.from(chunkData);
            break;

          case 'OTSc':
            result.otsSlots = parseOTSc(chunkData);
            break;

          case 'MHdc':
            result.mhdc = { rawData: Array.from(chunkData), length: chunkData.length };
            break;

          case 'SInt':
            result.sint = { rawData: Array.from(chunkData), length: chunkData.length };
            break;

          default:
            result.warnings.push(`Unknown chunk "${tag}" (${size} bytes)`);
            break;
        }
      } catch (chunkErr) {
        result.warnings.push(`Chunk "${tag}" processing error: ${chunkErr.message}`);
      }
    }

    // Build sections from parsed data
    result.sections = groupTracksIntoSections(result.tracks, result.casmSegments);

    // Lift writer metadata out of sections so it never pollutes section iteration
    result.writerMeta = result.sections.__meta || null;
    if (result.writerMeta) delete result.sections.__meta;

    // Ensure styleName from Sdec takes priority
    if (result.sdec?.styleName) result.styleName = result.sdec.styleName;

    // ── Post-parse diagnostics ──────────────────────────────────────────────
    if (result.tracks.length === 0) {
      result.errors.push('No MIDI tracks found in the file. The file may be empty or corrupt.');
    }
    if (!result.header) {
      result.errors.push('No valid MIDI header (MThd) was found inside the file body.');
    }
    if (Object.keys(result.sections).length === 0) {
      if (result.casmSegments.length === 0 && result.tracks.length > 0) {
        result.errors.push(
          'No style sections found and no CASM chunk present. ' +
          'This may be a plain MIDI file rather than a Yamaha style file.'
        );
      } else if (result.tracks.length > 0) {
        result.errors.push(
          'No style sections could be extracted. ' +
          'The file structure was recognised but section markers are missing or unreadable.'
        );
      }
    } else if (!result.format) {
      result.warnings.push(
        'Could not detect SFF1 or SFF2 format marker. ' +
        'The file loaded but may not round-trip correctly when saved.'
      );
    }

    if (result.warnings.some(w => w.includes('Unknown chunk'))) {
      const unknowns = result.warnings
        .filter(w => w.includes('Unknown chunk'))
        .map(w => w.match(/"([^"]+)"/)?.[1])
        .filter(Boolean);
      // Keep the originals but also add a summary tip
      result.warnings.push(
        `${unknowns.length} unknown chunk(s) [${unknowns.join(', ')}] were skipped. ` +
        `This is normal for files from instruments with proprietary extensions.`
      );
    }

    // Build summary
    result.summary = {
      styleName:      result.styleName,
      format:         result.format,
      bpm:            result.globalTempo,
      timeSignature:  `${result.globalTimeSignature.numerator}/${result.globalTimeSignature.denominator}`,
      trackCount:     result.tracks.length,
      sectionCount:   Object.keys(result.sections).length,
      sectionNames:   Object.keys(result.sections),
      chunkCount:     result.rawChunks.length,
      casmSegments:   result.casmSegments.length,
      hasOTS:         result.otsSlots.length > 0,
      hasMHdc:        !!result.mhdc,
      totalNotes:     Object.values(result.sections).reduce((acc, s) => acc + (s.notes?.length ?? 0), 0),
      fileSize:       arrayBuffer.byteLength,
      warnings:       result.warnings.length,
    };

  } catch (err) {
    result.errors.push(`Parse error: ${err.message}`);
    console.error('StyleFileParser error:', err);
  }

  return result;
}

// ─── Utility: get note name ───────────────────────────────────────────────────

const NOTE_NAMES = ['C', 'C#', 'D', 'D#', 'E', 'F', 'F#', 'G', 'G#', 'A', 'A#', 'B'];

export function noteName(midiNote) {
  const octave = Math.floor(midiNote / 12) - 2;
  const name = NOTE_NAMES[midiNote % 12];
  return `${name}${octave}`;
}

export function midiNoteFromName(name) {
  const match = name.match(/^([A-G]#?)(-?\d+)$/);
  if (!match) return 60;
  const noteIdx = NOTE_NAMES.indexOf(match[1]);
  const octave = parseInt(match[2]) + 2;
  return octave * 12 + noteIdx;
}
