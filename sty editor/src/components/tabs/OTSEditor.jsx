import { useEditor } from '../../store/useEditorStore';
import { lookupVoiceName } from '../../data/VoiceMap';

const OTS_PARTS = ['right1', 'right2', 'right3', 'left'];
const OTS_PART_LABELS = { right1: 'Right 1', right2: 'Right 2', right3: 'Right 3', left: 'Left' };

export default function OTSEditor() {
  const { state, actions } = useEditor();
  const { styleFile } = state;
  const slots = styleFile?.otsSlots || [];

  if (!styleFile) {
    return <EmptyState msg="Open a style file to edit OTS slots." />;
  }

  if (slots.length === 0) {
    return (
      <div
        className="flex flex-col items-center justify-center h-full gap-2"
        style={{ background: '#1a1a2e', color: '#9ca3af' }}
      >
        <div className="text-4xl opacity-20">⚙</div>
        <div className="font-semibold" style={{ color: '#eaeaea' }}>No OTS Data</div>
        <div className="text-sm text-center max-w-sm">
          This style file does not contain One Touch Settings data (OTSc chunk).
          OTS data is more common in SFF2 (PSR-SX) format files.
        </div>
        <div className="text-xs mt-2 px-3 py-1 rounded" style={{ background: '#16213e', color: '#e94560' }}>
          Format: {styleFile.format}
        </div>
      </div>
    );
  }

  function handleUpdate(slotNum, part, field, raw) {
    const val = Number(raw);
    if (Number.isNaN(val)) return;
    actions.updateOtsSlot(slotNum, part, { [field]: val });
  }

  return (
    <div className="p-4 overflow-y-auto h-full" style={{ background: '#1a1a2e' }}>
      <h2 className="text-sm font-semibold mb-4" style={{ color: '#eaeaea' }}>
        One Touch Settings (OTS)
      </h2>

      <div className="grid grid-cols-2 gap-4">
        {slots.map(slot => (
          <OTSSlot key={slot.slot} slot={slot} onUpdate={handleUpdate} />
        ))}
        {Array.from({ length: Math.max(0, 4 - slots.length) }, (_, i) => (
          <OTSSlotEmpty key={`empty-${i}`} number={slots.length + i + 1} />
        ))}
      </div>
    </div>
  );
}

function OTSSlot({ slot, onUpdate }) {
  return (
    <div className="rounded p-3" style={{ background: '#16213e', border: '1px solid #0f3460' }}>
      <div
        className="flex items-center justify-between mb-3 pb-2"
        style={{ borderBottom: '1px solid #0f3460' }}
      >
        <h3 className="text-sm font-semibold" style={{ color: '#e94560' }}>OTS {slot.slot}</h3>
        <span className="text-xs px-2 py-0.5 rounded" style={{ background: '#0f3460', color: '#9ca3af' }}>
          Slot {slot.slot}
        </span>
      </div>

      <div className="flex flex-col gap-2">
        {OTS_PARTS.map(part => {
          const voice = slot.voices?.[part];
          if (!voice) return null;
          const vName = lookupVoiceName(voice.bankMSB, voice.bankLSB, voice.program);

          return (
            <div
              key={part}
              className="rounded p-2"
              style={{ background: '#1a1a2e', border: '1px solid #0f3460' }}
            >
              {/* Part label + voice name */}
              <div className="flex items-center justify-between mb-1.5">
                <span className="text-xs font-semibold" style={{ color: '#9ca3af' }}>
                  {OTS_PART_LABELS[part]}
                </span>
                <span className="text-xs font-semibold truncate ml-2" style={{ color: '#eaeaea', maxWidth: 120 }}>
                  {vName}
                </span>
              </div>

              {/* Bank MSB / LSB / Program */}
              <div className="grid grid-cols-3 gap-1 mb-1.5">
                <NumField label="MSB" value={voice.bankMSB}  min={0} max={127}
                  onChange={v => onUpdate(slot.slot, part, 'bankMSB', v)} />
                <NumField label="LSB" value={voice.bankLSB}  min={0} max={127}
                  onChange={v => onUpdate(slot.slot, part, 'bankLSB', v)} />
                <NumField label="PC"  value={voice.program + 1} min={1} max={128}
                  onChange={v => onUpdate(slot.slot, part, 'program', v - 1)} />
              </div>

              {/* Volume / Octave */}
              <div className="grid grid-cols-2 gap-1">
                <NumField label="Vol" value={voice.volume} min={0} max={127}
                  onChange={v => onUpdate(slot.slot, part, 'volume', v)} />
                <NumField label="Oct" value={voice.octave} min={-3} max={3}
                  onChange={v => onUpdate(slot.slot, part, 'octave', v)} signed />
              </div>
            </div>
          );
        })}
      </div>
    </div>
  );
}

function NumField({ label, value, min, max, onChange, signed }) {
  return (
    <label className="flex flex-col gap-0.5">
      <span style={{ color: '#6b7280', fontSize: 9 }}>{label}</span>
      <input
        type="number"
        min={min}
        max={max}
        value={value ?? 0}
        onChange={e => {
          const v = parseInt(e.target.value, 10);
          if (!Number.isNaN(v) && v >= min && v <= max) onChange(v);
        }}
        className="w-full rounded px-1 text-xs text-center"
        style={{
          background: '#0f3460',
          color: '#eaeaea',
          border: '1px solid #1e3a5f',
          outline: 'none',
          height: 20,
          MozAppearance: 'textfield',
        }}
      />
    </label>
  );
}

function OTSSlotEmpty({ number }) {
  return (
    <div
      className="rounded p-3 flex items-center justify-center"
      style={{ background: '#16213e', border: '1px dashed #0f3460', minHeight: 120, opacity: 0.4 }}
    >
      <span className="text-sm" style={{ color: '#6b7280' }}>OTS {number} — Empty</span>
    </div>
  );
}

function EmptyState({ msg }) {
  return (
    <div className="flex items-center justify-center h-full" style={{ background: '#1a1a2e', color: '#9ca3af' }}>
      {msg}
    </div>
  );
}
