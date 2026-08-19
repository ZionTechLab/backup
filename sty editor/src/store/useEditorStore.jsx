/**
 * Global editor state using React's built-in useReducer + Context.
 */
import { createContext, useContext, useReducer } from 'react';

const initialState = {
  // Loaded file
  styleFile: null,
  filename: null,
  fileHandle: null,

  // Selection
  selectedSection: null,
  selectedPart: 1,
  activeTab: 'piano-roll',

  // Playback
  isPlaying: false,
  playbackTempo: 1.0,
  transposeAmount: 0,
  metronomeEnabled: false,
  loopSection: true,

  // MIDI
  midiOutputs: [],
  selectedMidiOutput: null,

  // UI
  zoom: 1.0,
  snapGrid: '1/16',
  status: 'Ready',
  errors: [],
  channelFilter: [1, 2, 3, 4, 5, 6, 7, 8], // which channels are visible

  // Load diagnostics (shown after file open if there are errors/warnings)
  loadDiagnostics: null, // { filename, errors[], warnings[], sectionCount, fatal? }

  // Clipboard
  clipboard: null,

  // Recent files
  recentFiles: (() => { try { return JSON.parse(localStorage.getItem('sty-recent-files') || '[]'); } catch { return []; } })(),
};

function reducer(state, action) {
  switch (action.type) {

    case 'FILE_LOADED': {
      const allChannels = new Set();
      for (const sec of Object.values(action.styleFile.sections || {})) {
        for (const note of (sec.notes || [])) allChannels.add(note.channel);
      }
      const channelFilter = allChannels.size > 0
        ? [...allChannels].sort((a, b) => a - b)
        : [1, 2, 3, 4, 5, 6, 7, 8];
      return {
        ...state,
        styleFile: action.styleFile,
        filename: action.filename,
        fileHandle: action.fileHandle || null,
        selectedSection: Object.keys(action.styleFile.sections)[0] || null,
        selectedPart: 1,
        channelFilter,
        status: `Loaded: ${action.filename}`,
        errors: action.styleFile.errors || [],
      };
    }

    case 'FILE_CLEARED':
      return { ...state, styleFile: null, filename: null, fileHandle: null, selectedSection: null, selectedPart: 1, status: 'Ready' };

    case 'SELECT_SECTION':
      return { ...state, selectedSection: action.name };

    case 'SELECT_PART':
      return { ...state, selectedPart: action.part };

    case 'SET_ACTIVE_TAB':
      return { ...state, activeTab: action.tab };

    case 'SET_PLAYBACK_TEMPO':
      return { ...state, playbackTempo: Math.max(0.5, Math.min(2.0, action.value)) };

    case 'SET_TRANSPOSE':
      return { ...state, transposeAmount: Math.max(-12, Math.min(12, action.value)) };

    case 'SET_PLAYING':
      return { ...state, isPlaying: action.value };

    case 'TOGGLE_METRONOME':
      return { ...state, metronomeEnabled: !state.metronomeEnabled };

    case 'TOGGLE_LOOP':
      return { ...state, loopSection: !state.loopSection };

    case 'SET_ZOOM':
      return { ...state, zoom: Math.max(0.2, Math.min(10, action.value)) };

    case 'SET_SNAP_GRID':
      return { ...state, snapGrid: action.value };

    case 'SET_STATUS':
      return { ...state, status: action.message };

    case 'ADD_ERROR':
      return { ...state, errors: [...state.errors, action.message] };

    case 'CLEAR_ERRORS':
      return { ...state, errors: [] };

    case 'SET_LOAD_DIAGNOSTICS':
      return { ...state, loadDiagnostics: action.value };

    case 'CLEAR_LOAD_DIAGNOSTICS':
      return { ...state, loadDiagnostics: null };

    case 'SET_MIDI_OUTPUTS':
      return { ...state, midiOutputs: action.outputs };

    case 'SELECT_MIDI_OUTPUT':
      return { ...state, selectedMidiOutput: action.output };

    case 'TOGGLE_CHANNEL_FILTER': {
      const ch = action.channel;
      const current = state.channelFilter;
      const next = current.includes(ch)
        ? current.filter(c => c !== ch)
        : [...current, ch].sort((a, b) => a - b);
      return { ...state, channelFilter: next.length === 0 ? current : next };
    }

    case 'SET_CHANNEL_FILTER':
      return { ...state, channelFilter: action.channels };

    case 'COPY_SECTION': {
      const sec = state.styleFile?.sections[state.selectedSection];
      return { ...state, clipboard: sec ? JSON.parse(JSON.stringify(sec)) : null };
    }

    case 'PASTE_SECTION': {
      if (!state.styleFile || !state.clipboard || !state.selectedSection) return state;
      const target = action.targetSection || state.selectedSection;
      return {
        ...state,
        styleFile: {
          ...state.styleFile,
          sections: {
            ...state.styleFile.sections,
            [target]: {
              ...JSON.parse(JSON.stringify(state.clipboard)),
              name: target,
            },
          },
        },
        status: `Pasted to ${target}`,
      };
    }

    case 'UPDATE_SECTION': {
      if (!state.styleFile) return state;
      return {
        ...state,
        styleFile: {
          ...state.styleFile,
          sections: { ...state.styleFile.sections, [action.name]: action.section },
        },
      };
    }

    case 'UPDATE_STYLE_INFO': {
      if (!state.styleFile) return state;
      return {
        ...state,
        styleFile: {
          ...state.styleFile,
          ...action.updates,
          summary: { ...state.styleFile.summary, ...action.updates },
        },
      };
    }

    case 'UPDATE_CHANNEL_INFO': {
      if (!state.styleFile) return state;
      const section = state.styleFile.sections[action.sectionName];
      if (!section) return state;
      return {
        ...state,
        styleFile: {
          ...state.styleFile,
          sections: {
            ...state.styleFile.sections,
            [action.sectionName]: {
              ...section,
              channelInfo: {
                ...section.channelInfo,
                [action.channel]: { ...section.channelInfo?.[action.channel], ...action.updates },
              },
            },
          },
        },
      };
    }

    // ── Note editing ─────────────────────────────────────────────────────────

    case 'ADD_NOTE': {
      if (!state.styleFile) return state;
      const sec = state.styleFile.sections[action.sectionName];
      if (!sec) return state;
      const newNotes = [...(sec.notes || []), action.note];
      newNotes.sort((a, b) => a.tick - b.tick || a.note - b.note);
      return {
        ...state,
        styleFile: {
          ...state.styleFile,
          sections: {
            ...state.styleFile.sections,
            [action.sectionName]: { ...sec, notes: newNotes },
          },
        },
      };
    }

    case 'DELETE_NOTE': {
      if (!state.styleFile) return state;
      const sec = state.styleFile.sections[action.sectionName];
      if (!sec) return state;
      const newNotes = (sec.notes || []).filter((_, i) => i !== action.noteIdx);
      return {
        ...state,
        styleFile: {
          ...state.styleFile,
          sections: {
            ...state.styleFile.sections,
            [action.sectionName]: { ...sec, notes: newNotes },
          },
        },
      };
    }

    case 'UPDATE_NOTE': {
      if (!state.styleFile) return state;
      const sec = state.styleFile.sections[action.sectionName];
      if (!sec) return state;
      const newNotes = (sec.notes || []).map((n, i) =>
        i === action.noteIdx ? { ...n, ...action.updates } : n
      );
      newNotes.sort((a, b) => a.tick - b.tick || a.note - b.note);
      return {
        ...state,
        styleFile: {
          ...state.styleFile,
          sections: {
            ...state.styleFile.sections,
            [action.sectionName]: { ...sec, notes: newNotes },
          },
        },
      };
    }

    case 'CLEAR_SECTION_NOTES': {
      if (!state.styleFile) return state;
      const sec = state.styleFile.sections[action.sectionName];
      if (!sec) return state;
      return {
        ...state,
        styleFile: {
          ...state.styleFile,
          sections: {
            ...state.styleFile.sections,
            [action.sectionName]: { ...sec, notes: [] },
          },
        },
      };
    }

    case 'QUANTIZE_NOTES': {
      if (!state.styleFile) return state;
      const sec = state.styleFile.sections[action.sectionName];
      if (!sec) return state;
      const snap = action.snapTicks;
      const newNotes = (sec.notes || []).map(n => ({
        ...n,
        tick: Math.round(n.tick / snap) * snap,
        duration: Math.max(snap, Math.round(n.duration / snap) * snap),
      }));
      newNotes.sort((a, b) => a.tick - b.tick);
      return {
        ...state,
        styleFile: {
          ...state.styleFile,
          sections: {
            ...state.styleFile.sections,
            [action.sectionName]: { ...sec, notes: newNotes },
          },
        },
      };
    }

    case 'TRANSPOSE_SECTION': {
      if (!state.styleFile) return state;
      const sec = state.styleFile.sections[action.sectionName];
      if (!sec) return state;
      const semitones = action.semitones;
      const newNotes = (sec.notes || []).map(n => ({
        ...n,
        note: n.channel <= 2 ? n.note : Math.max(0, Math.min(127, n.note + semitones)),
      }));
      return {
        ...state,
        styleFile: {
          ...state.styleFile,
          sections: {
            ...state.styleFile.sections,
            [action.sectionName]: { ...sec, notes: newNotes },
          },
        },
      };
    }

    case 'UPDATE_OTS_SLOT': {
      if (!state.styleFile) return state;
      const slots = (state.styleFile.otsSlots || []).map(s =>
        s.slot === action.slotNumber
          ? {
              ...s,
              voices: {
                ...s.voices,
                [action.part]: { ...(s.voices?.[action.part] || {}), ...action.updates },
              },
            }
          : s
      );
      return { ...state, styleFile: { ...state.styleFile, otsSlots: slots } };
    }

    case 'ADD_RECENT_FILE': {
      const recent = [
        action.entry,
        ...state.recentFiles.filter(f => f.name !== action.entry.name),
      ].slice(0, 10);
      try { localStorage.setItem('sty-recent-files', JSON.stringify(recent)); } catch {}
      return { ...state, recentFiles: recent };
    }

    default:
      return state;
  }
}

// ─── Context ──────────────────────────────────────────────────────────────────

export const EditorContext = createContext(null);

export function EditorProvider({ children }) {
  const [state, dispatch] = useReducer(reducer, initialState);

  const actions = {
    loadFile:        (sf, fn, fh) => dispatch({ type: 'FILE_LOADED', styleFile: sf, filename: fn, fileHandle: fh }),
    clearFile:       ()           => dispatch({ type: 'FILE_CLEARED' }),
    selectSection:   (name)       => dispatch({ type: 'SELECT_SECTION', name }),
    selectPart:      (part)       => dispatch({ type: 'SELECT_PART', part }),
    setActiveTab:    (tab)        => dispatch({ type: 'SET_ACTIVE_TAB', tab }),
    setTempo:        (v)          => dispatch({ type: 'SET_PLAYBACK_TEMPO', value: v }),
    setTranspose:    (v)          => dispatch({ type: 'SET_TRANSPOSE', value: v }),
    setPlaying:      (v)          => dispatch({ type: 'SET_PLAYING', value: v }),
    toggleMetronome: ()           => dispatch({ type: 'TOGGLE_METRONOME' }),
    toggleLoop:      ()           => dispatch({ type: 'TOGGLE_LOOP' }),
    setZoom:         (v)          => dispatch({ type: 'SET_ZOOM', value: v }),
    setSnapGrid:     (g)          => dispatch({ type: 'SET_SNAP_GRID', value: g }),
    setStatus:       (m)          => dispatch({ type: 'SET_STATUS', message: m }),
    addError:        (m)          => dispatch({ type: 'ADD_ERROR', message: m }),
    clearErrors:          ()      => dispatch({ type: 'CLEAR_ERRORS' }),
    setLoadDiagnostics:   (v)    => dispatch({ type: 'SET_LOAD_DIAGNOSTICS', value: v }),
    clearLoadDiagnostics: ()     => dispatch({ type: 'CLEAR_LOAD_DIAGNOSTICS' }),
    setMidiOutputs:  (o)          => dispatch({ type: 'SET_MIDI_OUTPUTS', outputs: o }),
    selectMidiOutput:(o)          => dispatch({ type: 'SELECT_MIDI_OUTPUT', output: o }),
    toggleChannelFilter: (ch)     => dispatch({ type: 'TOGGLE_CHANNEL_FILTER', channel: ch }),
    setChannelFilter: (chs)       => dispatch({ type: 'SET_CHANNEL_FILTER', channels: chs }),
    copySection:     ()           => dispatch({ type: 'COPY_SECTION' }),
    pasteSection:    (target)     => dispatch({ type: 'PASTE_SECTION', targetSection: target }),
    updateSection:   (n, s)       => dispatch({ type: 'UPDATE_SECTION', name: n, section: s }),
    updateStyleInfo: (u)          => dispatch({ type: 'UPDATE_STYLE_INFO', updates: u }),
    updateChannelInfo:(sn, ch, u) => dispatch({ type: 'UPDATE_CHANNEL_INFO', sectionName: sn, channel: ch, updates: u }),
    addNote:         (sn, note)   => dispatch({ type: 'ADD_NOTE', sectionName: sn, note }),
    deleteNote:      (sn, idx)    => dispatch({ type: 'DELETE_NOTE', sectionName: sn, noteIdx: idx }),
    updateNote:      (sn, idx, u) => dispatch({ type: 'UPDATE_NOTE', sectionName: sn, noteIdx: idx, updates: u }),
    clearSectionNotes:(sn)        => dispatch({ type: 'CLEAR_SECTION_NOTES', sectionName: sn }),
    quantizeNotes:   (sn, snap)   => dispatch({ type: 'QUANTIZE_NOTES', sectionName: sn, snapTicks: snap }),
    transposeSection:(sn, semi)   => dispatch({ type: 'TRANSPOSE_SECTION', sectionName: sn, semitones: semi }),
    updateOtsSlot:   (slot, part, updates) => dispatch({ type: 'UPDATE_OTS_SLOT', slotNumber: slot, part, updates }),
    addRecentFile:   (e)          => dispatch({ type: 'ADD_RECENT_FILE', entry: e }),
  };

  return (
    <EditorContext.Provider value={{ state, actions }}>
      {children}
    </EditorContext.Provider>
  );
}

export function useEditor() {
  const ctx = useContext(EditorContext);
  if (!ctx) throw new Error('useEditor must be used inside EditorProvider');
  return ctx;
}
