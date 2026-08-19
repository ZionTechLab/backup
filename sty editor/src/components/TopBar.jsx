import { useRef, useState } from 'react';
import * as Tone from 'tone';
import { useEditor } from '../store/useEditorStore';
import { parseStyleFile, STYLE_EXTENSIONS } from '../parser/StyleFileParser';

const ACCEPT_EXT = STYLE_EXTENSIONS.join(',');

export default function TopBar() {
  const { state, actions } = useEditor();
  const { styleFile, isPlaying, playbackTempo, transposeAmount, metronomeEnabled, loopSection } = state;
  const fileInputRef = useRef(null);
  const [midiDropdownOpen, setMidiDropdownOpen] = useState(false);

  async function handleFileOpen(e) {
    const file = e.target.files?.[0];
    if (!file) return;
    try {
      actions.setStatus(`Loading ${file.name}...`);
      const buffer = await file.arrayBuffer();
      const parsed = parseStyleFile(buffer, file.name);
      console.group(`[STY Editor] Parsed: ${file.name}`);
      console.log('Format:', parsed.format);
      console.log('Summary:', parsed.summary);
      console.log('Header:', parsed.header);
      console.log('CASM Segments:', parsed.casmSegments);
      console.log('Sections:', parsed.sections);
      console.log('OTS Slots:', parsed.otsSlots);
      console.log('Raw Chunks:', parsed.rawChunks);
      if (parsed.warnings.length) console.warn('Warnings:', parsed.warnings);
      if (parsed.errors.length)   console.error('Errors:', parsed.errors);
      console.groupEnd();

      actions.loadFile(parsed, file.name, null);
      actions.addRecentFile({ name: file.name, size: file.size, date: Date.now() });

      if (parsed.errors.length) {
        actions.setStatus(`Loaded with ${parsed.errors.length} error(s): ${file.name}`);
      }
    } catch (err) {
      actions.setStatus(`Error loading file: ${err.message}`);
      actions.addError(err.message);
      console.error(err);
    }
    // Reset input so same file can be re-opened
    e.target.value = '';
  }

  async function handleFileSave() {
    if (!styleFile) return;
    try {
      actions.setStatus('Saving…');
      const { writeStyleFile } = await import('../parser/StyleFileWriter.js');
      const buffer = writeStyleFile(styleFile);
      const blob = new Blob([buffer], { type: 'application/octet-stream' });
      const url  = URL.createObjectURL(blob);
      const a    = document.createElement('a');
      a.href     = url;
      a.download = state.filename || 'edited.sty';
      a.click();
      URL.revokeObjectURL(url);
      actions.setStatus(`Saved: ${state.filename || 'edited.sty'}`);
    } catch (err) {
      console.error('[Save]', err);
      actions.addError(err.message);
      actions.setStatus(`Save error: ${err.message}`);
    }
  }

  function handlePlayStop() {
    // Tone.start() must be called synchronously within a user gesture to unlock
    // the Web Audio API context. Calling it only inside useEffect is too late.
    if (!isPlaying) Tone.start();
    actions.setPlaying(!isPlaying);
  }

  return (
    <header
      className="flex items-center gap-2 px-3 h-12 border-b shrink-0"
      style={{ background: '#16213e', borderColor: '#0f3460' }}
    >
      {/* Logo / Title */}
      <div className="flex items-center gap-2 mr-4">
        <div
          className="w-7 h-7 rounded flex items-center justify-center text-sm font-bold"
          style={{ background: '#e94560', color: '#fff' }}
        >
          Y
        </div>
        <span className="font-semibold text-sm tracking-wide" style={{ color: '#eaeaea' }}>
          Yamaha Style Editor
        </span>
      </div>

      {/* File controls */}
      <div className="flex items-center gap-1">
        <input
          ref={fileInputRef}
          type="file"
          accept={ACCEPT_EXT}
          onChange={handleFileOpen}
          className="hidden"
        />
        <TopBarBtn onClick={() => fileInputRef.current?.click()} title="Open style file (Ctrl+O)">
          Open
        </TopBarBtn>
        <TopBarBtn onClick={handleFileSave} disabled={!styleFile} title="Save style file (Ctrl+S)">
          Save
        </TopBarBtn>
      </div>

      <Divider />

      {/* Playback controls */}
      <div className="flex items-center gap-1">
        <TopBarBtn
          onClick={handlePlayStop}
          disabled={!styleFile}
          active={isPlaying}
          title={isPlaying ? 'Stop playback' : 'Play selected section'}
          style={{ minWidth: 56 }}
        >
          {isPlaying ? '⏹ Stop' : '▶ Play'}
        </TopBarBtn>

        <TopBarBtn
          onClick={actions.toggleMetronome}
          disabled={!styleFile}
          active={metronomeEnabled}
          title="Toggle metronome"
        >
          ♩
        </TopBarBtn>

        <TopBarBtn
          onClick={actions.toggleLoop}
          disabled={!styleFile}
          active={loopSection}
          title="Loop section"
        >
          ↻
        </TopBarBtn>
      </div>

      {/* Tempo multiplier */}
      <div className="flex items-center gap-1.5 text-xs" style={{ color: '#9ca3af' }}>
        <span>Tempo</span>
        <input
          type="range"
          min={50} max={200}
          value={Math.round(playbackTempo * 100)}
          onChange={e => actions.setTempo(e.target.value / 100)}
          className="w-20 accent-[#e94560]"
          title="Playback tempo %"
        />
        <span className="w-9 text-right" style={{ color: '#eaeaea' }}>
          {Math.round(playbackTempo * 100)}%
        </span>
      </div>

      {/* Transpose */}
      <div className="flex items-center gap-1.5 text-xs" style={{ color: '#9ca3af' }}>
        <span>Key</span>
        <button
          className="w-5 h-5 flex items-center justify-center rounded text-xs"
          style={{ background: '#0f3460', color: '#eaeaea' }}
          onClick={() => actions.setTranspose(transposeAmount - 1)}
          disabled={!styleFile}
        >−</button>
        <span className="w-7 text-center" style={{ color: '#eaeaea' }}>
          {transposeAmount > 0 ? `+${transposeAmount}` : transposeAmount}
        </span>
        <button
          className="w-5 h-5 flex items-center justify-center rounded text-xs"
          style={{ background: '#0f3460', color: '#eaeaea' }}
          onClick={() => actions.setTranspose(transposeAmount + 1)}
          disabled={!styleFile}
        >+</button>
      </div>

      <Divider />

      {/* MIDI connect */}
      <div className="relative">
        <TopBarBtn
          onClick={() => setMidiDropdownOpen(o => !o)}
          active={state.selectedMidiOutput !== null}
          title="MIDI device selection"
        >
          MIDI {state.midiOutputs.length > 0 ? `(${state.midiOutputs.length})` : '—'}
        </TopBarBtn>
        {midiDropdownOpen && (
          <MidiDropdown
            outputs={state.midiOutputs}
            selected={state.selectedMidiOutput}
            onSelect={out => { actions.selectMidiOutput(out); setMidiDropdownOpen(false); }}
            onClose={() => setMidiDropdownOpen(false)}
          />
        )}
      </div>

      {/* Spacer */}
      <div className="flex-1" />

      {/* File info */}
      {styleFile && (
        <div className="text-xs flex items-center gap-3" style={{ color: '#9ca3af' }}>
          <span
            className="px-1.5 py-0.5 rounded text-xs font-mono"
            style={{ background: '#0f3460', color: '#e94560' }}
          >
            {styleFile.format}
          </span>
          <span>{styleFile.summary?.bpm} BPM</span>
          <span>{styleFile.summary?.timeSignature}</span>
          <span style={{ color: '#eaeaea' }}>{styleFile.styleName}</span>
        </div>
      )}
    </header>
  );
}

function TopBarBtn({ children, onClick, disabled, active, title, style: extraStyle }) {
  return (
    <button
      onClick={onClick}
      disabled={disabled}
      title={title}
      className="px-2.5 h-7 rounded text-xs font-medium transition-colors"
      style={{
        background: active ? '#e94560' : '#0f3460',
        color: active ? '#fff' : '#eaeaea',
        opacity: disabled ? 0.4 : 1,
        cursor: disabled ? 'not-allowed' : 'pointer',
        ...extraStyle,
      }}
    >
      {children}
    </button>
  );
}

function Divider() {
  return <div className="h-6 w-px mx-1" style={{ background: '#0f3460' }} />;
}

function MidiDropdown({ outputs, selected, onSelect, onClose }) {
  return (
    <div
      className="absolute top-8 left-0 z-50 rounded shadow-lg min-w-48 py-1"
      style={{ background: '#16213e', border: '1px solid #0f3460' }}
    >
      <div className="px-3 py-1 text-xs font-semibold" style={{ color: '#9ca3af' }}>
        MIDI Outputs
      </div>
      {outputs.length === 0 ? (
        <div className="px-3 py-2 text-xs" style={{ color: '#9ca3af' }}>
          No MIDI devices found.
          <br />Use Chrome for Web MIDI support.
        </div>
      ) : (
        outputs.map(out => (
          <button
            key={out.id}
            onClick={() => onSelect(out)}
            className="w-full text-left px-3 py-1.5 text-xs hover:opacity-80"
            style={{
              background: selected?.id === out.id ? '#0f3460' : 'transparent',
              color: '#eaeaea',
            }}
          >
            {out.name}
          </button>
        ))
      )}
      <div className="border-t mt-1 pt-1" style={{ borderColor: '#0f3460' }}>
        <button
          onClick={onClose}
          className="w-full text-left px-3 py-1.5 text-xs"
          style={{ color: '#9ca3af' }}
        >
          Close
        </button>
      </div>
    </div>
  );
}
