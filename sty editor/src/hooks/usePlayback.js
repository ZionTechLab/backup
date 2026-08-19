/**
 * Tone.js playback engine for Yamaha style sections.
 *
 * Audio priority (melodic channels):
 *   1. SoundFont sample (smplr MusyngKite GM) — loaded asynchronously
 *   2. Tone.js PolySynth fallback — used until SF has loaded
 *
 * Drum channels always use Tone.js synthesis (MembraneSynth / NoiseSynth /
 * MetalSynth) — no network dependency, no CDN 404 issues.
 *
 * MIDI hardware output works regardless of which audio path is active.
 */
import { useEffect, useRef } from 'react';
import * as Tone from 'tone';
import { playhead } from '../playheadSync';
import {
  SoundfontManager,
  programToInstrumentName,
} from '../audio/SoundfontManager';

const DEFAULT_TICKS_PER_BEAT = 480;

// ─── Helpers ─────────────────────────────────────────────────────────────────

function midiToHz(midiNote) {
  return 440 * Math.pow(2, (midiNote - 69) / 12);
}

// ─── Synth factory ───────────────────────────────────────────────────────────

function createSynths() {
  const dest = Tone.getDestination();

  const limiter    = new Tone.Limiter(-3);         limiter.connect(dest);
  const compressor = new Tone.Compressor(-18, 4);  compressor.connect(limiter);
  const reverb     = new Tone.Reverb({ decay: 1.2, wet: 0.15 }); reverb.connect(compressor);

  // ── Drum synths ──────────────────────────────────────────────────────────
  const drumKick = new Tone.MembraneSynth({
    pitchDecay: 0.05, octaves: 5,
    envelope: { attack: 0.001, decay: 0.35, sustain: 0, release: 0.1 },
  });
  drumKick.volume.value = -2; drumKick.connect(compressor);

  const drumSnare = new Tone.NoiseSynth({
    noise: { type: 'white' },
    envelope: { attack: 0.001, decay: 0.18, sustain: 0, release: 0.05 },
  });
  drumSnare.volume.value = -6; drumSnare.connect(compressor);

  const drumHH = new Tone.MetalSynth({
    frequency: 400, harmonicity: 5.1, modulationIndex: 32,
    resonance: 4000, octaves: 1.5,
    envelope: { attack: 0.001, decay: 0.08, release: 0.01 },
  });
  drumHH.volume.value = -10; drumHH.connect(compressor);

  const drumTom = new Tone.MembraneSynth({
    pitchDecay: 0.07, octaves: 4,
    envelope: { attack: 0.001, decay: 0.3, sustain: 0, release: 0.1 },
  });
  drumTom.volume.value = -4; drumTom.connect(compressor);

  const drumCymbal = new Tone.MetalSynth({
    frequency: 250, harmonicity: 3.1, modulationIndex: 64,
    resonance: 3500, octaves: 2,
    envelope: { attack: 0.001, decay: 0.6, release: 0.4 },
  });
  drumCymbal.volume.value = -12; drumCymbal.connect(compressor);

  // ── Melodic fallback synths ──────────────────────────────────────────────
  const bass = new Tone.PolySynth(Tone.Synth, {
    oscillator: { type: 'triangle' },
    envelope: { attack: 0.01, decay: 0.35, sustain: 0.55, release: 0.25 },
  });
  bass.volume.value = -4; bass.connect(compressor);

  const chord = new Tone.PolySynth(Tone.Synth, {
    oscillator: { type: 'sawtooth' },
    envelope: { attack: 0.03, decay: 0.2, sustain: 0.45, release: 0.4 },
  });
  chord.volume.value = -10; chord.connect(reverb);

  const pad = new Tone.PolySynth(Tone.Synth, {
    oscillator: { type: 'sine' },
    envelope: { attack: 0.12, decay: 0.5, sustain: 0.75, release: 1.2 },
  });
  pad.volume.value = -12; pad.connect(reverb);

  const phrase = new Tone.PolySynth(Tone.Synth, {
    oscillator: { type: 'sine' },
    envelope: { attack: 0.02, decay: 0.15, sustain: 0.6, release: 0.35 },
  });
  phrase.volume.value = -9; phrase.connect(reverb);

  const metro = new Tone.MembraneSynth({
    pitchDecay: 0.02, octaves: 3,
    envelope: { attack: 0.001, decay: 0.08, sustain: 0, release: 0.03 },
  });
  metro.volume.value = -6; metro.connect(compressor);

  return { drumKick, drumSnare, drumHH, drumTom, drumCymbal, bass, chord, pad, phrase, metro, reverb, compressor, limiter };
}

// ─── Drum note trigger ───────────────────────────────────────────────────────

function triggerDrumNote(synths, midiNote, time, vel) {
  const v = Math.max(0.05, Math.min(1, vel));
  if (midiNote >= 33 && midiNote <= 36) {
    // A0=33 (metronome click), B0=35 (acoustic bass drum), C1=36 (bass drum 1)
    synths.drumKick.triggerAttackRelease('C1', '16n', time, v);
  } else if (midiNote === 31 || midiNote === 32 ||
             (midiNote >= 37 && midiNote <= 40)) {
    // G0=31 (sticks), G#0=32 (square click), C#1=37 (side stick),
    // D1=38 (acoustic snare), D#1=39 (hand clap), E1=40 (electric snare)
    synths.drumSnare.triggerAttackRelease('16n', time, v);
  } else if (midiNote === 42 || midiNote === 44) {
    // Closed hi-hat, pedal hi-hat
    synths.drumHH.triggerAttackRelease('32n', time, v * 0.5);
  } else if (midiNote === 46) {
    // Open hi-hat
    synths.drumHH.triggerAttackRelease('16n', time, v * 0.8);
  } else if (midiNote === 41 || midiNote === 43 || midiNote === 45 ||
             midiNote === 47 || midiNote === 48 || midiNote === 50) {
    // Floor toms and rack toms — pitch down 2 octaves for a deeper sound
    synths.drumTom.triggerAttackRelease(
      midiToHz(Math.max(24, midiNote - 24)), '16n', time, v
    );
  } else {
    // Crash, ride, and other cymbals
    synths.drumCymbal.triggerAttackRelease('8n', time, v * 0.6);
  }
}

// ─── Melodic fallback synth selector ─────────────────────────────────────────

function getFallbackSynth(synths, channel) {
  if (channel === 3) return synths.bass;
  if (channel <= 5)  return synths.chord;
  if (channel === 6) return synths.pad;
  if (channel <= 8)  return synths.phrase;
  const melodic = [synths.phrase, synths.chord, synths.pad, synths.bass];
  return melodic[(channel - 9) % melodic.length];
}

// ─── Hook ─────────────────────────────────────────────────────────────────────

export function usePlayback({
  styleFile,
  selectedSection,
  isPlaying,
  playbackTempo,
  transposeAmount,
  metronomeEnabled,
  loopSection,
  channelFilter,
  selectedMidiOutput,
  muteSoloKey,
  onStop,
}) {
  const synthsRef = useRef(null);
  const partRef   = useRef(null);
  const metroRef  = useRef(null);
  const rafRef    = useRef(null);
  const activeRef = useRef(false);

  // Mount: create fallback synths once
  useEffect(() => {
    synthsRef.current = createSynths();
    return () => {
      stopAll();
      const s = synthsRef.current;
      if (s) {
        for (const v of Object.values(s)) { try { v.dispose(); } catch {} }
        synthsRef.current = null;
      }
    };
  }, []); // eslint-disable-line react-hooks/exhaustive-deps

  // ── Stop helper ────────────────────────────────────────────────────────────
  function stopAll() {
    activeRef.current = false;
    if (rafRef.current)  { cancelAnimationFrame(rafRef.current); rafRef.current = null; }
    if (metroRef.current){ try { metroRef.current.stop(0); metroRef.current.dispose(); } catch {} metroRef.current = null; }
    if (partRef.current) { try { partRef.current.stop(0);  partRef.current.dispose();  } catch {} partRef.current  = null; }
    try { Tone.getTransport().stop(); Tone.getTransport().cancel(); } catch {}
    SoundfontManager.stopAll();
    playhead.isPlaying = false;
    playhead.tick = 0;
  }

  // ── Start / stop ───────────────────────────────────────────────────────────
  useEffect(() => {
    if (!isPlaying) {
      stopAll();
      onStop?.();
      return;
    }

    const synths = synthsRef.current;
    if (!synths || !styleFile || !selectedSection) return;

    const section = styleFile.sections[selectedSection];
    if (!section) return;

    const TICKS_PER_BEAT  = styleFile.ticksPerBeat || DEFAULT_TICKS_PER_BEAT;
    const notes           = section.notes || [];
    const bpm             = Math.round((section.tempo || styleFile.globalTempo || 120) * playbackTempo);
    const secondsPerTick  = 60 / (bpm * TICKS_PER_BEAT);

    const BAR_TICKS   = TICKS_PER_BEAT * (styleFile.globalTimeSignature?.numerator || 4);
    const allEndTicks = notes.map(n => n.tick + Math.max(n.duration || 0, 1));
    const rawEndTick  = allEndTicks.length > 0 ? Math.max(...allEndTicks) : BAR_TICKS;
    const loopEndTick = Math.ceil(rawEndTick / BAR_TICKS) * BAR_TICKS;
    const loopEndSec  = loopEndTick * secondsPerTick;

    // Mute / solo
    const channelInfo = section.channelInfo || {};
    const mutedSet    = new Set(Object.entries(channelInfo).filter(([, i]) => i?.muted) .map(([ch]) => Number(ch)));
    const soloedSet   = new Set(Object.entries(channelInfo).filter(([, i]) => i?.soloed).map(([ch]) => Number(ch)));
    const anySoloed   = soloedSet.size > 0;

    // Drum detection: Yamaha XG uses bankMSB=127 for drum kits.
    // Fall back to channel <= 2 (CASM convention) when bank hasn't been set.
    const drumChannelSet = new Set(
      Object.entries(channelInfo)
        .filter(([, info]) => (info?.bankMSB ?? 0) >= 120 || Number(info?.channel) <= 2)
        .map(([ch]) => Number(ch))
    );

    // Instrument name per channel (drums flagged as 'percussion')
    const channelInstrument = {};
    for (const [ch, info] of Object.entries(channelInfo)) {
      const channel = Number(ch);
      channelInstrument[channel] = drumChannelSet.has(channel)
        ? 'percussion'
        : programToInstrumentName(info?.program ?? 0);
    }

    const chMapInverse = styleFile.writerMeta?.chMapInverse || {};
    const events = notes
      .filter(n => {
        if (channelFilter && !channelFilter.includes(n.channel)) return false;
        if (mutedSet.has(n.channel)) return false;
        if (anySoloed && !soloedSet.has(n.channel)) return false;
        return true;
      })
      .map(note => {
        const isDrum   = drumChannelSet.has(note.channel);
        const midiNote = Math.max(0, Math.min(127, note.note + (isDrum ? 0 : transposeAmount)));
        const timeSec  = note.tick * secondsPerTick;
        const durSec   = Math.max(0.04, note.duration * secondsPerTick);
        const vel      = Math.max(0.05, Math.min(1, note.velocity / 127));
        const midiCh   = ((chMapInverse[note.channel] ?? note.channel) - 1) & 0x0F;
        const instName = channelInstrument[note.channel]
          ?? (drumChannelSet.has(note.channel) ? 'percussion' : programToInstrumentName(0));
        return [timeSec, {
          durSec, vel,
          channel:        note.channel,
          isDrum,
          midiNote,
          midiCh,
          midiVel:        note.velocity & 0x7F,
          midiDurMs:      Math.max(20, note.duration * secondsPerTick * 1000),
          instrumentName: instName,
          pitch:          midiToHz(midiNote), // used only by melodic Tone.js fallback
        }];
      });

    Tone.start().then(() => {
      if (!activeRef.current && !isPlaying) return;

      // Pre-load SF instruments in the background (exclude drum channels).
      // They fill in as they arrive; Tone.js fallback covers until then.
      const uniqueInstruments = new Set(
        Object.values(channelInstrument).filter(n => n !== 'percussion')
      );
      for (const name of uniqueInstruments) {
        SoundfontManager.preload(name);
      }

      Tone.getTransport().cancel();
      Tone.getTransport().bpm.value = bpm;

      const part = new Tone.Part((time, value) => {
        if (value.isDrum) {
          // ── Drum path: always Tone.js synthesis ──────────────────────────
          triggerDrumNote(synths, value.midiNote, time, value.vel);
        } else {
          // ── Melodic path: smplr SF → Tone.js fallback ────────────────────
          const sfPlayer = SoundfontManager.getPlayer(value.instrumentName);
          if (sfPlayer) {
            try {
              sfPlayer.start({
                note:     value.midiNote,
                time,
                velocity: value.midiVel,
                duration: value.durSec,
              });
            } catch { /* ignore */ }
          } else {
            const synth = getFallbackSynth(synths, value.channel);
            if (synth) {
              try { synth.triggerAttackRelease(value.pitch, value.durSec, time, value.vel); } catch {}
            }
          }
        }

        // ── Web MIDI hardware output ──────────────────────────────────────
        if (selectedMidiOutput?.output) {
          const out     = selectedMidiOutput.output;
          const delayMs = Math.max(0, (time - Tone.getContext().rawContext.currentTime) * 1000);
          const nowMs   = performance.now();
          try {
            out.send([0x90 | value.midiCh, value.midiNote, value.midiVel], nowMs + delayMs);
            out.send([0x80 | value.midiCh, value.midiNote, 0],             nowMs + delayMs + value.midiDurMs);
          } catch {}
        }
      }, events);

      if (loopSection && loopEndSec > 0) {
        part.loop    = true;
        part.loopEnd = loopEndSec;
      }

      part.start(0);
      partRef.current = part;

      // Metronome
      if (metronomeEnabled) {
        const beatSec   = 60 / bpm;
        const metroPart = new Tone.Loop(time => {
          synths.metro.triggerAttackRelease('C2', '32n', time, 0.6);
        }, beatSec);
        metroPart.start(0);
        metroRef.current = metroPart;
      }

      Tone.getTransport().start('+0.05');
      activeRef.current = true;
      playhead.isPlaying = true;

      // RAF: update playhead tick for piano roll cursor
      function tick() {
        if (!activeRef.current) return;
        const posSec  = Tone.getTransport().seconds;
        const rawTick = Math.round(posSec / secondsPerTick);
        playhead.tick = loopSection ? rawTick % loopEndTick : rawTick;
        rafRef.current = requestAnimationFrame(tick);
      }
      rafRef.current = requestAnimationFrame(tick);

    }).catch(err => {
      console.warn('[Playback] Tone.start() failed:', err);
    });

    return () => { stopAll(); };
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [isPlaying, selectedSection, playbackTempo, transposeAmount, metronomeEnabled, loopSection, selectedMidiOutput, muteSoloKey]);
}
