import { useState } from 'react';
import { useEditor } from '../store/useEditorStore';

const SECTION_GROUPS = [
  { label: 'Intro',     keys: ['Intro 1', 'Intro 2', 'Intro 3'] },
  { label: 'Main',      keys: ['Main A', 'Main B', 'Main C', 'Main D'] },
  { label: 'Fill In',   keys: ['Fill In AA', 'Fill In BB', 'Fill In CC', 'Fill In DD', 'Fill In BA'] },
  { label: 'Break / End', keys: ['Break Fill', 'Ending 1', 'Ending 2', 'Ending 3'] },
];

const SHORT = {
  'Intro 1': 'Int 1', 'Intro 2': 'Int 2', 'Intro 3': 'Int 3',
  'Main A': 'Main A', 'Main B': 'Main B', 'Main C': 'Main C', 'Main D': 'Main D',
  'Fill In AA': 'Fill AA', 'Fill In BB': 'Fill BB', 'Fill In CC': 'Fill CC',
  'Fill In DD': 'Fill DD', 'Fill In BA': 'Fill BA',
  'Break Fill': 'Break', 'Ending 1': 'End 1', 'Ending 2': 'End 2', 'Ending 3': 'End 3',
};

export default function SectionSidebar() {
  const { state, actions } = useEditor();
  const { styleFile, selectedSection, clipboard } = state;
  const [transposeInput, setTransposeInput] = useState(0);
  const [showActions, setShowActions] = useState(true);

  const available = new Set(styleFile ? Object.keys(styleFile.sections) : []);

  return (
    <aside
      className="flex flex-col overflow-hidden shrink-0"
      style={{ width: 158, background: '#16213e', borderRight: '1px solid #0f3460' }}
    >
      <div
        className="px-3 py-2 text-xs font-semibold uppercase tracking-wider shrink-0 flex items-center justify-between"
        style={{ color: '#9ca3af', borderBottom: '1px solid #0f3460' }}
      >
        <span>Sections</span>
        {styleFile && (
          <span style={{ color: '#6b7280', fontWeight: 400 }}>
            {available.size}
          </span>
        )}
      </div>

      {/* Section list */}
      <div className="flex-1 overflow-y-auto">
        {!styleFile && (
          <div className="p-3 text-xs text-center" style={{ color: '#6b7280' }}>
            Open a style file
          </div>
        )}

        {SECTION_GROUPS.map(group => (
          <div key={group.label}>
            <div
              className="px-3 pt-2 pb-0.5 text-xs font-semibold uppercase tracking-wide"
              style={{ color: '#e94560', fontSize: 9 }}
            >
              {group.label}
            </div>

            {group.keys.map(name => {
              const hasData  = available.has(name);
              const isActive = name === selectedSection;
              const section  = styleFile?.sections[name];
              const nCount   = section?.notes?.length ?? 0;
              const parts    = section ? Object.keys(section.channelInfo || {}).length : 0;

              return (
                <button
                  key={name}
                  onClick={() => hasData && actions.selectSection(name)}
                  className="w-full text-left px-2 py-1.5 flex items-center justify-between"
                  style={{
                    background: isActive ? '#0f3460' : 'transparent',
                    borderLeft: isActive ? '3px solid #e94560' : '3px solid transparent',
                    cursor: hasData ? 'pointer' : 'default',
                    opacity: hasData ? 1 : 0.28,
                  }}
                >
                  <span
                    className="text-xs truncate"
                    style={{ color: isActive ? '#eaeaea' : hasData ? '#d1d5db' : '#4b5563' }}
                  >
                    {SHORT[name] || name}
                  </span>
                  {hasData && (
                    <span
                      style={{
                        background: isActive ? '#e94560' : '#1a1a2e',
                        color: isActive ? '#fff' : '#6b7280',
                        fontSize: 9,
                        borderRadius: 3,
                        padding: '0 3px',
                        minWidth: 18,
                        textAlign: 'right',
                      }}
                    >
                      {nCount}
                    </span>
                  )}
                </button>
              );
            })}
          </div>
        ))}
      </div>

      {/* Section actions panel */}
      {selectedSection && styleFile && (
        <div
          className="shrink-0 p-2 flex flex-col gap-1.5"
          style={{ borderTop: '1px solid #0f3460' }}
        >
          <button
            className="flex items-center justify-between w-full px-1 mb-0.5"
            onClick={() => setShowActions(a => !a)}
          >
            <span className="text-xs font-semibold" style={{ color: '#9ca3af' }}>
              Actions
            </span>
            <span style={{ color: '#6b7280', fontSize: 10 }}>{showActions ? '▲' : '▼'}</span>
          </button>

          {showActions && (
            <>
              <div className="text-xs truncate mb-0.5" style={{ color: '#e94560', fontSize: 9 }}>
                {selectedSection}
              </div>

              <ActionBtn onClick={actions.copySection}>
                Copy Section
              </ActionBtn>
              <ActionBtn
                onClick={() => actions.pasteSection(selectedSection)}
                disabled={!clipboard}
              >
                Paste Here
              </ActionBtn>
              <ActionBtn
                onClick={() => {
                  if (window.confirm(`Clear all notes in "${selectedSection}"?`)) {
                    actions.clearSectionNotes(selectedSection);
                  }
                }}
                danger
              >
                Clear Notes
              </ActionBtn>

              {/* Transpose */}
              <div className="flex items-center gap-1 mt-1">
                <span className="text-xs shrink-0" style={{ color: '#9ca3af', fontSize: 9 }}>Transp</span>
                <input
                  type="number"
                  value={transposeInput}
                  onChange={e => setTransposeInput(parseInt(e.target.value) || 0)}
                  min={-24} max={24}
                  className="flex-1 px-1 py-0.5 rounded text-xs font-mono text-center"
                  style={{ background: '#0f3460', color: '#eaeaea', border: 'none', outline: 'none', width: 0 }}
                />
                <button
                  onClick={() => {
                    actions.transposeSection(selectedSection, transposeInput);
                    actions.setStatus(`Transposed ${selectedSection} by ${transposeInput} semitones`);
                  }}
                  className="px-2 py-0.5 rounded text-xs"
                  style={{ background: '#0f3460', color: '#eaeaea' }}
                >Go</button>
              </div>
            </>
          )}
        </div>
      )}
    </aside>
  );
}

function ActionBtn({ children, onClick, disabled, danger }) {
  return (
    <button
      onClick={onClick}
      disabled={disabled}
      className="w-full text-xs py-1 rounded"
      style={{
        background: danger ? 'rgba(233,69,96,0.15)' : '#0f3460',
        color: danger ? '#e94560' : disabled ? '#4b5563' : '#eaeaea',
        cursor: disabled ? 'not-allowed' : 'pointer',
        opacity: disabled ? 0.5 : 1,
      }}
    >
      {children}
    </button>
  );
}
