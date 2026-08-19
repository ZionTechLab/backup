import { useState } from 'react';
import { useEditor } from '../../store/useEditorStore';
import { FORMAT_SFF1, FORMAT_SFF2 } from '../../parser/StyleFileParser';

function formatBytes(bytes) {
  if (bytes < 1024) return `${bytes} B`;
  if (bytes < 1024 * 1024) return `${(bytes / 1024).toFixed(1)} KB`;
  return `${(bytes / (1024 * 1024)).toFixed(2)} MB`;
}

export default function StyleInfo() {
  const { state, actions } = useEditor();
  const { styleFile } = state;
  const [editingName, setEditingName] = useState(false);
  const [nameValue, setNameValue] = useState('');

  if (!styleFile) {
    return (
      <div
        className="flex flex-col items-center justify-center h-full gap-4"
        style={{ background: '#1a1a2e', color: '#9ca3af' }}
      >
        <div className="text-6xl opacity-20">♪</div>
        <div className="text-lg font-semibold" style={{ color: '#eaeaea' }}>
          Yamaha Style Editor
        </div>
        <div className="text-sm text-center max-w-sm">
          Open a Yamaha style file (.sty, .prs, .sst, .bcs, .pst, .pcs, .fps)
          to get started. Drag and drop is also supported.
        </div>
        <div className="flex gap-2 text-xs mt-2">
          {['.sty', '.prs', '.sst', '.bcs', '.pst', '.pcs', '.fps'].map(ext => (
            <span
              key={ext}
              className="px-2 py-1 rounded font-mono"
              style={{ background: '#16213e', color: '#e94560' }}
            >
              {ext}
            </span>
          ))}
        </div>
      </div>
    );
  }

  const s = styleFile.summary;

  function startEditName() {
    setNameValue(styleFile.styleName);
    setEditingName(true);
  }

  function saveName() {
    actions.updateStyleInfo({ styleName: nameValue });
    setEditingName(false);
  }

  return (
    <div
      className="p-4 overflow-y-auto h-full flex flex-col gap-4"
      style={{ background: '#1a1a2e' }}
    >
      {/* Style name */}
      <div
        className="rounded p-4 flex items-center gap-3"
        style={{ background: '#16213e', border: '1px solid #0f3460' }}
      >
        <div
          className="w-10 h-10 rounded flex items-center justify-center text-lg font-bold shrink-0"
          style={{ background: '#e94560', color: '#fff' }}
        >
          {styleFile.styleName?.[0]?.toUpperCase() || '?'}
        </div>
        <div className="flex-1 min-w-0">
          {editingName ? (
            <div className="flex gap-2">
              <input
                type="text"
                value={nameValue}
                onChange={e => setNameValue(e.target.value)}
                onKeyDown={e => { if (e.key === 'Enter') saveName(); if (e.key === 'Escape') setEditingName(false); }}
                autoFocus
                maxLength={64}
                className="flex-1 px-2 py-1 rounded text-sm"
                style={{ background: '#0f3460', color: '#eaeaea', border: '1px solid #e94560', outline: 'none' }}
              />
              <button
                onClick={saveName}
                className="px-3 py-1 rounded text-xs"
                style={{ background: '#e94560', color: '#fff' }}
              >Save</button>
              <button
                onClick={() => setEditingName(false)}
                className="px-3 py-1 rounded text-xs"
                style={{ background: '#0f3460', color: '#9ca3af' }}
              >Cancel</button>
            </div>
          ) : (
            <div className="flex items-center gap-2">
              <span className="text-base font-semibold truncate" style={{ color: '#eaeaea' }}>
                {styleFile.styleName || 'Unnamed Style'}
              </span>
              <button
                onClick={startEditName}
                className="text-xs px-2 py-0.5 rounded"
                style={{ background: '#0f3460', color: '#9ca3af' }}
              >✏ Edit</button>
            </div>
          )}
          <div className="text-xs mt-0.5" style={{ color: '#6b7280' }}>
            {styleFile.filename}
          </div>
        </div>
        <div
          className="px-2 py-1 rounded text-xs font-bold shrink-0"
          style={{
            background: styleFile.format === FORMAT_SFF2 ? 'rgba(16,185,129,0.2)' : 'rgba(233,69,96,0.2)',
            color: styleFile.format === FORMAT_SFF2 ? '#10b981' : '#e94560',
          }}
        >
          {styleFile.format}
        </div>
      </div>

      {/* Stats grid */}
      <div className="grid grid-cols-2 gap-3">
        <InfoCard label="Tempo" value={`${s?.bpm ?? '?'} BPM`} icon="♩" />
        <InfoCard label="Time Signature" value={s?.timeSignature ?? '?'} icon="♪" />
        <InfoCard label="Tracks" value={s?.trackCount ?? '?'} icon="≡" />
        <InfoCard label="Sections" value={s?.sectionCount ?? '?'} icon="§" />
        <InfoCard label="CASM Segments" value={s?.casmSegments ?? '?'} icon="C" />
        <InfoCard label="Total Notes" value={(s?.totalNotes ?? '?').toLocaleString()} icon="●" />
        <InfoCard label="File Size" value={formatBytes(s?.fileSize ?? 0)} icon="⊙" />
        <InfoCard label="OTS Slots" value={styleFile.otsSlots.length} icon="⚙" />
      </div>

      {/* Sections breakdown */}
      <div
        className="rounded p-3"
        style={{ background: '#16213e', border: '1px solid #0f3460' }}
      >
        <div className="text-xs font-semibold mb-2" style={{ color: '#9ca3af' }}>
          SECTIONS
        </div>
        <div className="flex flex-col gap-1">
          {Object.entries(styleFile.sections).map(([name, sec]) => {
            const noteCount = sec.notes?.length ?? 0;
            const partCount = Object.keys(sec.channelInfo ?? {}).length;
            const bars = sec.length ? Math.ceil(sec.length / 1920) : 0;

            return (
              <div
                key={name}
                className="flex items-center gap-2 text-xs py-1 px-2 rounded cursor-pointer"
                style={{ background: '#1a1a2e' }}
                onClick={() => actions.selectSection(name)}
              >
                <span className="font-medium w-24 shrink-0" style={{ color: '#eaeaea' }}>{name}</span>
                <span style={{ color: '#6b7280' }}>{partCount} parts</span>
                <span style={{ color: '#6b7280' }}>·</span>
                <span style={{ color: '#6b7280' }}>{noteCount} notes</span>
                {bars > 0 && (
                  <>
                    <span style={{ color: '#6b7280' }}>·</span>
                    <span style={{ color: '#6b7280' }}>{bars} bars</span>
                  </>
                )}
                {sec.tempo && (
                  <span className="ml-auto text-xs" style={{ color: '#9ca3af' }}>
                    {sec.tempo} BPM
                  </span>
                )}
              </div>
            );
          })}
        </div>
      </div>

      {/* Raw chunks list */}
      <div
        className="rounded p-3"
        style={{ background: '#16213e', border: '1px solid #0f3460' }}
      >
        <div className="text-xs font-semibold mb-2" style={{ color: '#9ca3af' }}>
          BINARY CHUNKS ({styleFile.rawChunks.length})
        </div>
        <div className="flex flex-wrap gap-1">
          {styleFile.rawChunks.map((chunk, i) => (
            <span
              key={i}
              className="text-xs px-2 py-0.5 rounded font-mono"
              style={{ background: '#0f3460', color: '#d1d5db' }}
              title={`Offset: ${chunk.offset}, Size: ${chunk.size} bytes`}
            >
              {chunk.tag}
            </span>
          ))}
        </div>
      </div>

      {/* Warnings */}
      {styleFile.warnings?.length > 0 && (
        <div
          className="rounded p-3"
          style={{ background: 'rgba(245,158,11,0.1)', border: '1px solid rgba(245,158,11,0.3)' }}
        >
          <div className="text-xs font-semibold mb-2" style={{ color: '#f59e0b' }}>
            WARNINGS ({styleFile.warnings.length})
          </div>
          {styleFile.warnings.map((w, i) => (
            <div key={i} className="text-xs mb-1" style={{ color: '#fcd34d' }}>• {w}</div>
          ))}
        </div>
      )}

      {/* Errors */}
      {styleFile.errors?.length > 0 && (
        <div
          className="rounded p-3"
          style={{ background: 'rgba(233,69,96,0.1)', border: '1px solid rgba(233,69,96,0.3)' }}
        >
          <div className="text-xs font-semibold mb-2" style={{ color: '#e94560' }}>
            ERRORS ({styleFile.errors.length})
          </div>
          {styleFile.errors.map((e, i) => (
            <div key={i} className="text-xs mb-1" style={{ color: '#fca5a5' }}>• {e}</div>
          ))}
        </div>
      )}
    </div>
  );
}

function InfoCard({ label, value, icon }) {
  return (
    <div
      className="rounded p-3 flex items-center gap-3"
      style={{ background: '#16213e', border: '1px solid #0f3460' }}
    >
      <div
        className="w-8 h-8 rounded flex items-center justify-center shrink-0"
        style={{ background: '#0f3460', color: '#e94560', fontSize: 14 }}
      >
        {icon}
      </div>
      <div>
        <div className="text-xs" style={{ color: '#6b7280' }}>{label}</div>
        <div className="text-sm font-semibold" style={{ color: '#eaeaea' }}>{value}</div>
      </div>
    </div>
  );
}
