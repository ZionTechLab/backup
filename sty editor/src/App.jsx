import { useEffect } from 'react';
import * as Tone from 'tone';
import { EditorProvider, useEditor } from './store/useEditorStore';
import { usePlayback } from './hooks/usePlayback';
import TopBar                from './components/TopBar';
import SectionSidebar        from './components/SectionSidebar';
import MainEditor            from './components/MainEditor';
import PartMixer             from './components/PartMixer';
import BottomBar             from './components/BottomBar';
import DropZone              from './components/DropZone';
import ParseDiagnosticsModal from './components/ParseDiagnosticsModal';

function AppInner() {
  const { state, actions } = useEditor();

  // Stable key that changes whenever any mute/solo is toggled in the current section
  const sectionChannelInfo = state.styleFile?.sections[state.selectedSection]?.channelInfo || {};
  const muteSoloKey = Object.entries(sectionChannelInfo)
    .map(([ch, i]) => `${ch}:${i?.muted ? 'M' : ''}${i?.soloed ? 'S' : ''}`)
    .join(',');

  // ── Tone.js playback ───────────────────────────────────────────────────────
  usePlayback({
    styleFile:          state.styleFile,
    selectedSection:    state.selectedSection,
    isPlaying:          state.isPlaying,
    playbackTempo:      state.playbackTempo,
    transposeAmount:    state.transposeAmount,
    metronomeEnabled:   state.metronomeEnabled,
    loopSection:        state.loopSection,
    channelFilter:      state.channelFilter,
    selectedMidiOutput: state.selectedMidiOutput,
    muteSoloKey,
    onStop:             () => actions.setPlaying(false),
  });

  // ── Web MIDI init ──────────────────────────────────────────────────────────
  useEffect(() => {
    if (!navigator.requestMIDIAccess) return;
    navigator.requestMIDIAccess({ sysex: true })
      .then(access => {
        function refresh() {
          const outputs = [];
          for (const out of access.outputs.values()) {
            outputs.push({ id: out.id, name: out.name, output: out });
          }
          actions.setMidiOutputs(outputs);
        }
        refresh();
        access.onstatechange = refresh;
      })
      .catch(() => {});
  }, []); // eslint-disable-line react-hooks/exhaustive-deps

  // ── Global keyboard shortcuts ──────────────────────────────────────────────
  useEffect(() => {
    function onKey(e) {
      // Space = play/stop (only when not in a text input)
      if (e.code === 'Space' && document.activeElement?.tagName !== 'INPUT') {
        e.preventDefault();
        if (state.styleFile) {
          if (!state.isPlaying) Tone.start();
          actions.setPlaying(!state.isPlaying);
        }
      }
    }
    window.addEventListener('keydown', onKey);
    return () => window.removeEventListener('keydown', onKey);
  }, [state.isPlaying, state.styleFile]); // eslint-disable-line react-hooks/exhaustive-deps

  return (
    <DropZone>
      <div
        className="flex flex-col"
        style={{ width: '100vw', height: '100vh', overflow: 'hidden', background: '#1a1a2e' }}
      >
        <TopBar />
        <div className="flex flex-1 overflow-hidden">
          <SectionSidebar />
          <MainEditor />
          <PartMixer />
        </div>
        <BottomBar />
      </div>
      <ParseDiagnosticsModal />
    </DropZone>
  );
}

export default function App() {
  return (
    <EditorProvider>
      <AppInner />
    </EditorProvider>
  );
}
