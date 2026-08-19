/**
 * Yamaha Style File Writer
 * Serializes an edited styleFile object back to a binary .sty ArrayBuffer.
 *
 * Strategy:
 *  - MThd  — always reconstructed from styleFile.header / ticksPerBeat
 *  - MTrk  — reconstructed from sections + __meta (preEvents, channel map, etc.)
 *  - All other chunks (CASM, Sdec, Ctab, Cntt, OTSc, MHdc, SInt …)
 *            written verbatim from rawChunks[i].data stored during parsing
 */

// ─── Variable-length integer encoding ────────────────────────────────────────

function writeVarLen(value) {
  if (value <= 0) return [0x00];
  const bytes = [];
  bytes.unshift(value & 0x7F);
  value >>>= 7;
  while (value > 0) {
    bytes.unshift((value & 0x7F) | 0x80);
    value >>>= 7;
  }
  return bytes;
}

// ─── Big-endian helpers ───────────────────────────────────────────────────────

function uint32BE(n) {
  return [(n >>> 24) & 0xFF, (n >>> 16) & 0xFF, (n >>> 8) & 0xFF, n & 0xFF];
}

function uint16BE(n) {
  return [(n >>> 8) & 0xFF, n & 0xFF];
}

// ─── Chunk assembler ─────────────────────────────────────────────────────────

function packChunk(tag, bodyBytes) {
  const tagBytes = [...tag].map(c => c.charCodeAt(0));
  return [...tagBytes, ...uint32BE(bodyBytes.length), ...bodyBytes];
}

// ─── Serialize a single parsed-event object back to raw MIDI bytes ────────────
// (no delta time — caller prepends delta)

function serializeEvent(ev) {
  if (ev.kind === 'meta') {
    const data = ev.data ? Array.from(ev.data) : [];
    return [0xFF, ev.metaType, ...writeVarLen(data.length), ...data];
  }

  if (ev.kind === 'sysex') {
    const data = ev.data ? Array.from(ev.data) : [];
    const header = (ev.type === 0xF7) ? 0xF7 : 0xF0;
    return [header, ...writeVarLen(data.length), ...data];
  }

  if (ev.kind === 'channel') {
    const ch = (ev.channel - 1) & 0x0F; // 0-indexed MIDI channel
    const type = ev.type & 0xF0;
    switch (type) {
      case 0x80: return [0x80 | ch, ev.note ?? 0, ev.velocity ?? 0];
      case 0x90: return [0x90 | ch, ev.note ?? 0, ev.velocity ?? 0];
      case 0xA0: return [0xA0 | ch, ev.note ?? 0, ev.pressure ?? 0];
      case 0xB0: return [0xB0 | ch, ev.controller ?? 0, ev.value ?? 0];
      case 0xC0: return [0xC0 | ch, ev.program ?? 0];
      case 0xD0: return [0xD0 | ch, ev.pressure ?? 0];
      case 0xE0: {
        const pb = (ev.value ?? 0) + 8192;
        return [0xE0 | ch, pb & 0x7F, (pb >> 7) & 0x7F];
      }
      default: return [];
    }
  }

  return [];
}

// ─── Build a single MTrk body for Format-0 files ─────────────────────────────

function buildFormat0Mtrk(sections, writerMeta) {
  const meta = writerMeta;

  // Flat list of { tick (absolute), priority, bytes[] }
  // Priority controls ordering at equal ticks:
  //   0 = meta/setup,  1 = note off / section marker,  2 = note on
  const evList = [];

  if (meta) {
    const { preEvents, sectionOrder, chMapInverse, sectionStartTicks } = meta;

    // 1. Pre-section setup events (tempo, time sig, SysEx resets, CCs, PCs …)
    for (const ev of preEvents) {
      if (ev.kind === 'meta' && ev.metaType === 0x2F) continue; // skip EOT
      const bytes = serializeEvent(ev);
      if (bytes.length > 0) {
        evList.push({ tick: ev.tick, priority: 0, bytes });
      }
    }

    // 2. Section marker + notes for each section in original order
    for (const sectionName of sectionOrder) {
      const section = sections[sectionName];
      if (!section) continue;
      const startTick = sectionStartTicks[sectionName] ?? 0;

      // Section marker: FF 06 <len> <text>
      const textBytes = [...new TextEncoder().encode(sectionName)];
      evList.push({
        tick: startTick,
        priority: 1,
        bytes: [0xFF, 0x06, ...writeVarLen(textBytes.length), ...textBytes],
      });

      // Notes → NoteOn + NoteOff pairs (un-remap channels)
      for (const note of section.notes || []) {
        const origCh  = (chMapInverse[note.channel] ?? note.channel) - 1; // 0-indexed
        const absTick = startTick + note.tick;
        const absOff  = absTick + Math.max(1, note.duration);

        evList.push({ tick: absTick, priority: 2, bytes: [0x90 | origCh, note.note & 0x7F, (note.velocity || 64) & 0x7F] });
        evList.push({ tick: absOff,  priority: 1, bytes: [0x80 | origCh, note.note & 0x7F, 0] });
      }
    }
  } else {
    // Fallback: no writerMeta — just write all sections with sequential ticks
    let cursor = 0;
    for (const [sectionName, section] of Object.entries(sections)) {
      const textBytes = [...new TextEncoder().encode(sectionName)];
      evList.push({
        tick: cursor,
        priority: 1,
        bytes: [0xFF, 0x06, ...writeVarLen(textBytes.length), ...textBytes],
      });
      for (const note of section.notes || []) {
        const ch = (note.channel - 1) & 0x0F;
        const absTick = cursor + note.tick;
        const absOff  = absTick + Math.max(1, note.duration);
        evList.push({ tick: absTick, priority: 2, bytes: [0x90 | ch, note.note & 0x7F, (note.velocity || 64) & 0x7F] });
        evList.push({ tick: absOff,  priority: 1, bytes: [0x80 | ch, note.note & 0x7F, 0] });
      }
      const sectionLen = section.length || (section.notes?.length
        ? Math.max(...section.notes.map(n => n.tick + n.duration))
        : 0);
      cursor += sectionLen + 1;
    }
  }

  // End of Track (after everything)
  const lastTick = evList.reduce((m, e) => Math.max(m, e.tick), 0);
  evList.push({ tick: lastTick, priority: 99, bytes: [0xFF, 0x2F, 0x00] });

  // Sort: tick ASC, then priority ASC
  evList.sort((a, b) => a.tick - b.tick || a.priority - b.priority);

  // Encode with delta times
  const trackBytes = [];
  let currentTick = 0;
  for (const ev of evList) {
    const delta = Math.max(0, ev.tick - currentTick);
    currentTick = ev.tick;
    trackBytes.push(...writeVarLen(delta), ...ev.bytes);
  }

  return trackBytes;
}

// ─── Build MTrk for a single Format-1 data track ─────────────────────────────

function buildFormat1Mtrk(trackEvents) {
  const evList = [];

  for (const ev of trackEvents) {
    if (ev.kind === 'meta' && ev.metaType === 0x2F) continue; // skip EOT
    const bytes = serializeEvent(ev);
    if (bytes.length > 0) {
      evList.push({ tick: ev.tick, priority: ev.kind === 'meta' ? 0 : 2, bytes });
    }
  }

  const lastTick = evList.reduce((m, e) => Math.max(m, e.tick), 0);
  evList.push({ tick: lastTick, priority: 99, bytes: [0xFF, 0x2F, 0x00] });
  evList.sort((a, b) => a.tick - b.tick || a.priority - b.priority);

  const trackBytes = [];
  let currentTick = 0;
  for (const ev of evList) {
    const delta = Math.max(0, ev.tick - currentTick);
    currentTick = ev.tick;
    trackBytes.push(...writeVarLen(delta), ...ev.bytes);
  }
  return trackBytes;
}

// ─── Main entry point ─────────────────────────────────────────────────────────

export function writeStyleFile(styleFile) {
  const output = []; // flat byte array

  const tpb      = styleFile.ticksPerBeat || styleFile.header?.ticksPerQuarter || 480;
  const isFormat0 = styleFile.header?.format === 0 || !!styleFile.writerMeta;

  // ── MThd ──────────────────────────────────────────────────────────────────
  const numTracks = isFormat0 ? 1 : (() => {
    let n = 1; // conductor
    for (const sec of Object.values(styleFile.sections || {})) {
      n += Object.keys(sec.tracks || {}).length;
    }
    return Math.max(1, n);
  })();

  const mthdBody = [...uint16BE(isFormat0 ? 0 : 1), ...uint16BE(numTracks), ...uint16BE(tpb)];
  output.push(...packChunk('MThd', mthdBody));

  // ── MTrk(s) ───────────────────────────────────────────────────────────────
  if (isFormat0) {
    const trkBody = buildFormat0Mtrk(styleFile.sections || {}, styleFile.writerMeta);
    output.push(...packChunk('MTrk', trkBody));
  } else {
    // Conductor track: tempo + time sig + EOT
    const tempo = Math.round(60_000_000 / (styleFile.globalTempo || 120));
    const tsNum = styleFile.globalTimeSignature?.numerator ?? 4;
    const tsDen = Math.round(Math.log2(styleFile.globalTimeSignature?.denominator ?? 4));
    const conductor = [
      ...writeVarLen(0), 0xFF, 0x58, 0x04, tsNum, tsDen, 24, 8,
      ...writeVarLen(0), 0xFF, 0x51, 0x03, (tempo >> 16) & 0xFF, (tempo >> 8) & 0xFF, tempo & 0xFF,
      ...writeVarLen(0), 0xFF, 0x2F, 0x00,
    ];
    output.push(...packChunk('MTrk', conductor));

    for (const sec of Object.values(styleFile.sections || {})) {
      for (const track of Object.values(sec.tracks || {})) {
        const trkBody = buildFormat1Mtrk(track.events || []);
        output.push(...packChunk('MTrk', trkBody));
      }
    }
  }

  // ── All other chunks: copied verbatim from rawChunks ──────────────────────
  const SKIP = new Set(['MThd', 'MTrk']);
  for (const chunk of styleFile.rawChunks || []) {
    if (SKIP.has(chunk.tag)) continue;
    if (!chunk.data) continue;
    const tagBytes = [...chunk.tag].map(c => c.charCodeAt(0));
    output.push(...tagBytes, ...uint32BE(chunk.data.length), ...Array.from(chunk.data));
  }

  return new Uint8Array(output).buffer;
}
