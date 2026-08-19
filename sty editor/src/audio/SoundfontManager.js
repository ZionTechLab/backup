/**
 * SoundfontManager
 *
 * Loads GM instrument samples via smplr's Soundfont class (MusyngKite kit).
 * Maintains the same interface used by usePlayback so the rest of the app
 * doesn't need to know which underlying library is used.
 *
 * Note: drum channels ("percussion") are intentionally excluded — they are
 * handled by Tone.js synthesis in usePlayback.
 */
import { Soundfont } from 'smplr';
import * as Tone from 'tone';

// ─── GM instrument names (program 0-127) ─────────────────────────────────────

export const GM_INSTRUMENT_NAMES = [
  // Piano
  'acoustic_grand_piano', 'bright_acoustic_piano', 'electric_grand_piano', 'honkytonk_piano',
  'electric_piano_1', 'electric_piano_2', 'harpsichord', 'clavinet',
  // Chromatic Perc
  'celesta', 'glockenspiel', 'music_box', 'vibraphone',
  'marimba', 'xylophone', 'tubular_bells', 'dulcimer',
  // Organ
  'drawbar_organ', 'percussive_organ', 'rock_organ', 'church_organ',
  'reed_organ', 'accordion', 'harmonica', 'tango_accordion',
  // Guitar
  'acoustic_guitar_nylon', 'acoustic_guitar_steel', 'electric_guitar_jazz', 'electric_guitar_clean',
  'electric_guitar_muted', 'overdriven_guitar', 'distortion_guitar', 'guitar_harmonics',
  // Bass
  'acoustic_bass', 'electric_bass_finger', 'electric_bass_pick', 'fretless_bass',
  'slap_bass_1', 'slap_bass_2', 'synth_bass_1', 'synth_bass_2',
  // Strings
  'violin', 'viola', 'cello', 'contrabass',
  'tremolo_strings', 'pizzicato_strings', 'orchestral_harp', 'timpani',
  // Ensemble
  'string_ensemble_1', 'string_ensemble_2', 'synth_strings_1', 'synth_strings_2',
  'choir_aahs', 'voice_oohs', 'synth_voice', 'orchestra_hit',
  // Brass
  'trumpet', 'trombone', 'tuba', 'muted_trumpet',
  'french_horn', 'brass_section', 'synth_brass_1', 'synth_brass_2',
  // Reed
  'soprano_sax', 'alto_sax', 'tenor_sax', 'baritone_sax',
  'oboe', 'english_horn', 'bassoon', 'clarinet',
  // Pipe
  'piccolo', 'flute', 'recorder', 'pan_flute',
  'blown_bottle', 'shakuhachi', 'whistle', 'ocarina',
  // Synth Lead
  'lead_1_square', 'lead_2_sawtooth', 'lead_3_calliope', 'lead_4_chiff',
  'lead_5_charang', 'lead_6_voice', 'lead_7_fifths', 'lead_8_bass_lead',
  // Synth Pad
  'pad_1_new_age', 'pad_2_warm', 'pad_3_polysynth', 'pad_4_choir',
  'pad_5_bowed', 'pad_6_metallic', 'pad_7_halo', 'pad_8_sweep',
  // Synth FX
  'fx_1_rain', 'fx_2_soundtrack', 'fx_3_crystal', 'fx_4_atmosphere',
  'fx_5_brightness', 'fx_6_goblins', 'fx_7_echoes', 'fx_8_sci_fi',
  // World
  'sitar', 'banjo', 'shamisen', 'koto',
  'kalimba', 'bag_pipe', 'fiddle', 'shanai',
  // Percussive
  'tinkle_bell', 'agogo', 'steel_drums', 'woodblock',
  'taiko_drum', 'melodic_tom', 'synth_drum', 'reverse_cymbal',
  // Sound FX
  'guitar_fret_noise', 'breath_noise', 'seashore', 'bird_tweet',
  'telephone_ring', 'helicopter', 'applause', 'gunshot',
];

/** GM program number (0-based) → instrument name string */
export function programToInstrumentName(program) {
  return GM_INSTRUMENT_NAMES[Math.max(0, Math.min(127, program ?? 0))]
    ?? 'acoustic_grand_piano';
}

// ─── Manager (module-level singleton) ────────────────────────────────────────

class SoundfontManagerClass {
  constructor() {
    this._promises = new Map(); // name → Promise<Soundfont | null>
    this._players  = new Map(); // name → Soundfont  (populated on resolve)
  }

  /**
   * Begin loading an instrument if not already loading/loaded.
   * Returns a Promise that resolves to the Soundfont instance, or null on failure.
   * Safe to call multiple times — subsequent calls return the cached promise.
   */
  preload(name) {
    if (this._promises.has(name)) return this._promises.get(name);

    const ctx = Tone.getContext().rawContext;
    const sf = new Soundfont(ctx, { kit: 'MusyngKite', instrument: name });

    const p = sf.load
      .then(loaded => {
        this._players.set(name, loaded);
        return loaded;
      })
      .catch(err => {
        console.warn(`[Soundfont] Failed to load "${name}":`, err?.message ?? err);
        this._promises.delete(name); // allow retry on next preload call
        return null;
      });

    this._promises.set(name, p);
    return p;
  }

  /**
   * Synchronously return a loaded Soundfont instance, or null if not ready yet.
   * Use this inside time-sensitive callbacks where awaiting is impossible.
   */
  getPlayer(name) {
    return this._players.get(name) ?? null;
  }

  isLoaded(name) { return this._players.has(name); }

  /** Stop all currently playing soundfont notes. */
  stopAll() {
    for (const player of this._players.values()) {
      try { player.stop(); } catch { /* ignore */ }
    }
  }
}

export const SoundfontManager = new SoundfontManagerClass();
