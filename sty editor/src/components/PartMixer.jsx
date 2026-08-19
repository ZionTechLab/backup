import { useEditor } from '../store/useEditorStore';
import { PART_NAMES } from '../parser/StyleFileParser';
import { lookupVoiceName } from '../data/VoiceMap';

export default function PartMixer() {
  const { state, actions } = useEditor();
  const { styleFile, selectedSection } = state;

  const section = styleFile?.sections[selectedSection];

  // Show every channel that has data in this section, sorted numerically
  const activeParts = section
    ? Object.keys(section.channelInfo || {}).map(Number).sort((a, b) => a - b)
    : [];

  return (
    <aside
      className="flex flex-col overflow-y-auto shrink-0"
      style={{ width: 180, background: '#16213e', borderLeft: '1px solid #0f3460' }}
    >
      <div
        className="px-3 py-2 text-xs font-semibold uppercase tracking-wider shrink-0"
        style={{ color: '#9ca3af', borderBottom: '1px solid #0f3460' }}
      >
        Part Mixer
      </div>

      {!section ? (
        <div className="p-3 text-xs text-center" style={{ color: '#9ca3af' }}>
          Select a section to see part settings.
        </div>
      ) : (
        <div className="flex flex-col gap-0 overflow-y-auto">
          {activeParts.map(ch => {
            const info = section.channelInfo?.[ch];
            const isActive = !!info;

            return (
              <PartStrip
                key={ch}
                channel={ch}
                info={info}
                isActive={isActive}
                sectionName={selectedSection}
                onUpdate={(updates) =>
                  actions.updateChannelInfo(selectedSection, ch, updates)
                }
              />
            );
          })}
        </div>
      )}
    </aside>
  );
}

function PartStrip({ channel, info, isActive, sectionName, onUpdate }) {
  const partName = PART_NAMES[channel] || `Ch ${channel}`; // PART_NAMES covers 1–8; fallback for extra channels
  const voiceName = info
    ? lookupVoiceName(info.bankMSB ?? 0, info.bankLSB ?? 0, info.program ?? 0)
    : '—';

  const volume  = info?.volume  ?? 100;
  const pan     = info?.pan     ?? 64;
  const reverb  = info?.reverb  ?? 0;
  const chorus  = info?.chorus  ?? 0;
  const muted   = info?.muted   ?? false;
  const soloed  = info?.soloed  ?? false;

  const handleCC = (key, value) => onUpdate({ [key]: value });

  return (
    <div
      className="px-2 py-2"
      style={{
        borderBottom: '1px solid #0f3460',
        opacity: isActive ? 1 : 0.35,
      }}
    >
      {/* Header row */}
      <div className="flex items-center justify-between mb-1.5">
        <div>
          <div className="text-xs font-semibold" style={{ color: '#eaeaea' }}>
            {partName}
          </div>
          <div className="text-xs truncate max-w-[100px]" style={{ color: '#9ca3af', fontSize: 10 }}>
            {voiceName}
          </div>
        </div>
        <div className="flex gap-1">
          <MuteBtn
            active={muted}
            onClick={() => handleCC('muted', !muted)}
            label="M"
            activeColor="#f59e0b"
          />
          <MuteBtn
            active={soloed}
            onClick={() => handleCC('soloed', !soloed)}
            label="S"
            activeColor="#10b981"
          />
        </div>
      </div>

      {/* Faders */}
      <CCSlider label="Vol" value={volume}  onChange={v => handleCC('volume', v)}  disabled={!isActive} />
      <CCSlider label="Pan" value={pan}     onChange={v => handleCC('pan', v)}     disabled={!isActive} center />
      <CCSlider label="Rev" value={reverb}  onChange={v => handleCC('reverb', v)}  disabled={!isActive} />
      <CCSlider label="Chr" value={chorus}  onChange={v => handleCC('chorus', v)}  disabled={!isActive} />

      {/* Ch number */}
      <div className="text-right mt-1" style={{ color: '#6b7280', fontSize: 9 }}>
        CH {channel}
      </div>
    </div>
  );
}

function CCSlider({ label, value, onChange, disabled, center }) {
  const pct = Math.round((value / 127) * 100);
  const displayVal = center ? value - 64 : value;

  return (
    <div className="flex items-center gap-1 mb-0.5">
      <span className="text-xs w-6 shrink-0" style={{ color: '#9ca3af', fontSize: 9 }}>
        {label}
      </span>
      <input
        type="range"
        min={0} max={127}
        value={value}
        onChange={e => onChange(parseInt(e.target.value))}
        disabled={disabled}
        className="flex-1 h-1 accent-[#e94560]"
        style={{ opacity: disabled ? 0.4 : 1 }}
      />
      <span className="text-xs w-7 text-right shrink-0" style={{ color: '#d1d5db', fontSize: 9 }}>
        {center
          ? (displayVal > 0 ? `+${displayVal}` : displayVal)
          : value
        }
      </span>
    </div>
  );
}

function MuteBtn({ active, onClick, label, activeColor }) {
  return (
    <button
      onClick={onClick}
      className="w-5 h-5 rounded text-xs font-bold transition-colors"
      style={{
        background: active ? activeColor : '#0f3460',
        color: active ? '#fff' : '#9ca3af',
        fontSize: 9,
      }}
    >
      {label}
    </button>
  );
}
