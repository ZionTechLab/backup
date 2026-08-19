/**
 * Module-level mutable object for sharing playhead position between
 * the Tone.js playback hook and the PianoRoll canvas draw loop,
 * without going through React state (which would cause per-frame re-renders).
 */
export const playhead = {
  tick: 0,
  isPlaying: false,
};
