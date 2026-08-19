import { useMemo, useRef, useEffect } from 'react';
import { useEditor } from '../store/useEditorStore';

// Piano keyboard constants
const NOTES_PER_OCTAVE = 12;
const NUM_OCTAVES = 7;
const WHITE_KEY_WIDTH = 14;
const WHITE_KEY_HEIGHT = 48;
const BLACK_KEY_WIDTH = 9;
const BLACK_KEY_HEIGHT = 30;
const TOTAL_WHITE_KEYS = NUM_OCTAVES * 7;
const PIANO_WIDTH = TOTAL_WHITE_KEYS * WHITE_KEY_WIDTH;

// Black key pattern per octave (0=no, 1=yes) for C through B
const IS_BLACK = [0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0];
const WHITE_KEY_INDEX = [0, 1, 2, 3, 4, 5, 6]; // C D E F G A B

// Map white key position within octave to semitone
const WHITE_TO_SEMITONE = [0, 2, 4, 5, 7, 9, 11];
// Black key x offsets are computed inline in drawPiano using:
// whitesBefore * WHITE_KEY_WIDTH - BLACK_KEY_WIDTH / 2

export default function BottomBar() {
  const { state } = useEditor();
  const { status, errors, styleFile, selectedSection } = state;

  const canvasRef = useRef(null);
  const activeNotes = useMemo(() => {
    if (!styleFile || !selectedSection) return new Set();
    const section = styleFile.sections[selectedSection];
    if (!section) return new Set();
    // Show notes that appear in the first beat
    return new Set(section.notes.filter(n => n.tick < 480).map(n => n.note));
  }, [styleFile, selectedSection]);

  useEffect(() => {
    const canvas = canvasRef.current;
    if (!canvas) return;
    const ctx = canvas.getContext('2d');
    drawPiano(ctx, activeNotes);
  }, [activeNotes]);

  return (
    <footer
      className="flex items-end gap-0 shrink-0"
      style={{ background: '#16213e', borderTop: '1px solid #0f3460', height: WHITE_KEY_HEIGHT + 20 }}
    >
      {/* Piano keyboard */}
      <div
        className="overflow-x-auto shrink-0"
        style={{ height: WHITE_KEY_HEIGHT + 4, borderRight: '1px solid #0f3460' }}
      >
        <canvas
          ref={canvasRef}
          width={PIANO_WIDTH}
          height={WHITE_KEY_HEIGHT}
          style={{ display: 'block', cursor: 'pointer' }}
        />
      </div>

      {/* Status bar */}
      <div
        className="flex-1 flex items-center px-3 text-xs gap-4"
        style={{ height: '100%', color: '#9ca3af' }}
      >
        <span
          className="flex items-center gap-1.5"
          style={{ color: errors.length > 0 ? '#e94560' : '#10b981' }}
        >
          <span
            className="w-2 h-2 rounded-full"
            style={{ background: errors.length > 0 ? '#e94560' : '#10b981' }}
          />
          {status}
        </span>

        {styleFile && (
          <>
            <div className="h-4 w-px" style={{ background: '#0f3460' }} />
            <span>{styleFile.summary.sectionCount} sections</span>
            <span>{styleFile.summary.totalNotes.toLocaleString()} notes</span>
            <span>{styleFile.format}</span>
          </>
        )}

        <div className="flex-1" />

        {errors.length > 0 && (
          <span style={{ color: '#f59e0b' }}>
            ⚠ {errors.length} error{errors.length !== 1 ? 's' : ''}
          </span>
        )}

        <span style={{ color: '#6b7280' }}>
          Yamaha Style Editor — Chrome recommended for Web MIDI
        </span>
      </div>
    </footer>
  );
}

function drawPiano(ctx, activeNotes) {
  const w = PIANO_WIDTH;
  const h = WHITE_KEY_HEIGHT;

  ctx.clearRect(0, 0, w, h);

  // Background
  ctx.fillStyle = '#16213e';
  ctx.fillRect(0, 0, w, h);

  let whiteKeyIndex = 0;

  // Draw white keys first
  for (let octave = 0; octave < NUM_OCTAVES; octave++) {
    for (let wi = 0; wi < 7; wi++) {
      const semitone = WHITE_TO_SEMITONE[wi];
      const midiNote = (octave + 1) * 12 + semitone; // octave 1 = MIDI 12 (C1)
      const x = whiteKeyIndex * WHITE_KEY_WIDTH;
      const isActive = activeNotes.has(midiNote);
      const isC = semitone === 0;

      ctx.fillStyle = isActive ? '#e94560' : '#eaeaea';
      ctx.fillRect(x + 1, 1, WHITE_KEY_WIDTH - 2, h - 2);

      ctx.strokeStyle = '#1a1a2e';
      ctx.lineWidth = 1;
      ctx.strokeRect(x + 1, 1, WHITE_KEY_WIDTH - 2, h - 2);

      if (isC && !isActive) {
        ctx.fillStyle = '#9ca3af';
        ctx.font = '7px monospace';
        ctx.fillText(`C${octave + 1}`, x + 2, h - 3);
      }

      whiteKeyIndex++;
    }
  }

  // Draw black keys on top
  let octaveX = 0;
  for (let octave = 0; octave < NUM_OCTAVES; octave++) {
    const blackKeys = [1, 3, 6, 8, 10]; // C# D# F# G# A#
    for (let bi = 0; bi < blackKeys.length; bi++) {
      const semitone = blackKeys[bi];
      const midiNote = (octave + 1) * 12 + semitone;
      const isActive = activeNotes.has(midiNote);

      // Position black key
      const whitesBefore = [0, 1, 1, 2, 2, 3, 4, 4, 5, 5, 6, 6][semitone];
      const x = octaveX + whitesBefore * WHITE_KEY_WIDTH - BLACK_KEY_WIDTH / 2;

      ctx.fillStyle = isActive ? '#e94560' : '#1a1a2e';
      ctx.fillRect(x, 0, BLACK_KEY_WIDTH, BLACK_KEY_HEIGHT);

      ctx.strokeStyle = isActive ? '#fff' : '#0f3460';
      ctx.lineWidth = 0.5;
      ctx.strokeRect(x, 0, BLACK_KEY_WIDTH, BLACK_KEY_HEIGHT);
    }
    octaveX += 7 * WHITE_KEY_WIDTH;
  }
}
