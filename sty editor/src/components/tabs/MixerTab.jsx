import { useState, useEffect, useRef } from 'react';
import { useEditor } from '../../store/useEditorStore';
import { PART_NAMES } from '../../parser/StyleFileParser';
import { lookupVoiceName, VOICE_CATEGORIES, getVoicesByCategory, findVoice } from '../../data/VoiceMap';

export default function MixerTab() {
  const { state, actions } = useEditor();
  const { styleFile, selectedSection, selectedPart } = state;
  const section = styleFile?.sections[selectedSection];

  const [browserCategory, setBrowserCategory] = useState('Piano');
  const activeVoiceRef = useRef(null);

  const info = section?.channelInfo?.[selectedPart];

  // Auto-switch voice browser category when selected part changes
  useEffect(() => {
    if (!info) return;
    const voice = findVoice(info.bankMSB ?? 0, info.bankLSB ?? 0, info.program ?? 0);
    if (voice?.category) setBrowserCategory(voice.category);
  }, [selectedPart, info?.bankMSB, info?.bankLSB, info?.program]); // eslint-disable-line react-hooks/exhaustive-deps

  // Scroll active voice into view
  useEffect(() => {
    activeVoiceRef.current?.scrollIntoView({ block: 'nearest', behavior: 'smooth' });
  }, [browserCategory, selectedPart]);

  if (!section) {
    return <EmptyState msg="Select a section to view the mixer." />;
  }

  const parts = Object.keys(section.channelInfo || {}).map(Number).sort((a, b) => a - b);

  return (
    <div className="flex flex-col h-full" style={{ background: '#1a1a2e' }}>

      {/* ── Channel strips ── */}
      <div className="flex gap-1 p-4 overflow-x-auto" style={{ minHeight: 0, flex: '1 1 0' }}>
        {parts.map(ch => {
          const chInfo = section.channelInfo?.[ch];
          return (
            <MixerChannel
              key={ch}
              channel={ch}
              info={chInfo}
              selected={ch === selectedPart}
              onClick={() => actions.selectPart(ch)}
              onUpdate={updates => actions.updateChannelInfo(selectedSection, ch, updates)}
            />
          );
        })}
      </div>

      {/* ── Voice panel (shown when a channel is selected) ── */}
      {selectedPart != null && (
        <VoicePanel
          section={section}
          selectedPart={selectedPart}
          selectedSection={selectedSection}
          browserCategory={browserCategory}
          setBrowserCategory={setBrowserCategory}
          activeVoiceRef={activeVoiceRef}
          actions={actions}
        />
      )}
    </div>
  );
}

// ── Channel strip ─────────────────────────────────────────────────────────────

function MixerChannel({ channel, info, selected, onClick, onUpdate }) {
  const partName  = PART_NAMES[channel] || `Ch ${channel}`;
  const hasData   = !!info;
  const voiceName = hasData
    ? lookupVoiceName(info.bankMSB ?? 0, info.bankLSB ?? 0, info.program ?? 0)
    : '—';

  const volume = info?.volume ?? 100;
  const pan    = info?.pan    ?? 64;
  const reverb = info?.reverb ?? 0;
  const chorus = info?.chorus ?? 0;
  const muted  = info?.muted  ?? false;
  const soloed = info?.soloed ?? false;

  return (
    <div
      onClick={onClick}
      className="flex flex-col items-center gap-2 rounded p-3 shrink-0 cursor-pointer"
      style={{
        width: 88,
        background: selected ? '#1e2d50' : '#16213e',
        border: `1px solid ${selected ? '#e94560' : muted ? '#f59e0b40' : '#0f3460'}`,
        opacity: hasData ? 1 : 0.35,
        transition: 'border-color 0.15s',
      }}
    >
      {/* Part name */}
      <div className="text-xs font-semibold text-center" style={{ color: selected ? '#e94560' : '#eaeaea' }}>
        {partName}
      </div>
      {/* Voice name */}
      <div className="text-center leading-tight" style={{ color: '#9ca3af', fontSize: 9, minHeight: 24 }}>
        {voiceName}
      </div>

      {/* Pan knob */}
      <PanKnob value={pan} onChange={v => onUpdate({ pan: v })} disabled={!hasData} />

      {/* Volume fader */}
      <div className="flex flex-col items-center gap-1 w-full">
        <span style={{ color: '#6b7280', fontSize: 9 }}>VOL</span>
        <input
          type="range" min={0} max={127} value={volume}
          onChange={e => onUpdate({ volume: parseInt(e.target.value) })}
          disabled={!hasData}
          onClick={e => e.stopPropagation()}
          className="accent-[#e94560]"
          style={{ writingMode: 'vertical-lr', direction: 'rtl', height: 80, opacity: hasData ? 1 : 0.4 }}
        />
        <span style={{ color: '#eaeaea', fontSize: 9 }}>{volume}</span>
      </div>

      {/* Rev / Chr send knobs */}
      <div className="flex justify-around w-full">
        <SendKnob label="Rev" value={reverb} onChange={v => onUpdate({ reverb: v })} disabled={!hasData} />
        <SendKnob label="Chr" value={chorus} onChange={v => onUpdate({ chorus: v })} disabled={!hasData} />
      </div>

      {/* Mute / Solo */}
      <div className="flex gap-1" onClick={e => e.stopPropagation()}>
        <button
          onClick={() => onUpdate({ muted: !muted })}
          className="w-8 h-6 rounded text-xs font-bold"
          style={{ background: muted ? '#f59e0b' : '#0f3460', color: muted ? '#000' : '#9ca3af' }}
          disabled={!hasData}
        >M</button>
        <button
          onClick={() => onUpdate({ soloed: !soloed })}
          className="w-8 h-6 rounded text-xs font-bold"
          style={{ background: soloed ? '#10b981' : '#0f3460', color: soloed ? '#000' : '#9ca3af' }}
          disabled={!hasData}
        >S</button>
      </div>

      {/* Channel number badge */}
      <div
        className="w-full text-center rounded py-0.5 text-xs font-mono"
        style={{ background: '#0f3460', color: '#e94560', fontSize: 9 }}
      >
        CH {channel}
      </div>
    </div>
  );
}

// ── Voice panel ───────────────────────────────────────────────────────────────

function VoicePanel({ section, selectedPart, selectedSection, browserCategory, setBrowserCategory, activeVoiceRef, actions }) {
  const info = section?.channelInfo?.[selectedPart];
  const partVoices = getVoicesByCategory(browserCategory);
  const isActive = v =>
    info &&
    v.msb === (info.bankMSB ?? 0) &&
    v.lsb === (info.bankLSB ?? 0) &&
    v.pc  === (info.program  ?? 0);

  return (
    <div
      className="flex shrink-0"
      style={{ height: 210, borderTop: '2px solid #0f3460', background: '#16213e' }}
    >
      {/* Left: voice detail */}
      <div
        className="flex flex-col gap-2 p-3 shrink-0 overflow-y-auto"
        style={{ width: 190, borderRight: '1px solid #0f3460' }}
      >
        <div className="text-xs font-semibold uppercase tracking-wider" style={{ color: '#9ca3af' }}>
          {PART_NAMES[selectedPart] || `Ch ${selectedPart}`}
        </div>

        {info ? (
          <>
            <div
              className="px-2 py-1.5 rounded text-xs font-semibold"
              style={{ background: '#0f3460', color: '#e94560', border: '1px solid #1a1a2e' }}
            >
              {lookupVoiceName(info.bankMSB ?? 0, info.bankLSB ?? 0, info.program ?? 0)}
            </div>

            <div className="grid grid-cols-3 gap-1.5">
              <VoiceField
                label="MSB"
                value={info.bankMSB ?? 0}
                onChange={v => actions.updateChannelInfo(selectedSection, selectedPart, { bankMSB: v })}
              />
              <VoiceField
                label="LSB"
                value={info.bankLSB ?? 0}
                onChange={v => actions.updateChannelInfo(selectedSection, selectedPart, { bankLSB: v })}
              />
              <VoiceField
                label="PC"
                value={(info.program ?? 0) + 1}
                onChange={v => actions.updateChannelInfo(selectedSection, selectedPart, { program: v - 1 })}
                min={1} max={128}
              />
            </div>

            <div className="grid grid-cols-2 gap-1 text-xs" style={{ color: '#6b7280' }}>
              <span>Vol: <span style={{ color: '#eaeaea' }}>{info.volume ?? 100}</span></span>
              <span>Pan: <span style={{ color: '#eaeaea' }}>{info.pan ?? 64}</span></span>
            </div>
          </>
        ) : (
          <div className="text-xs" style={{ color: '#6b7280' }}>No voice data for this channel.</div>
        )}
      </div>

      {/* Center: category list */}
      <div className="overflow-y-auto shrink-0" style={{ width: 120, borderRight: '1px solid #0f3460' }}>
        {VOICE_CATEGORIES.map(cat => (
          <button
            key={cat}
            onClick={() => setBrowserCategory(cat)}
            className="w-full text-left px-2 py-1 text-xs"
            style={{
              background: browserCategory === cat ? '#0f3460' : 'transparent',
              color: browserCategory === cat ? '#eaeaea' : '#9ca3af',
              borderLeft: browserCategory === cat ? '2px solid #e94560' : '2px solid transparent',
            }}
          >
            {cat}
          </button>
        ))}
      </div>

      {/* Right: voice list */}
      <div className="flex-1 overflow-y-auto">
        {partVoices.map((v, i) => {
          const active = isActive(v);
          return (
            <button
              key={i}
              ref={active ? activeVoiceRef : null}
              className="w-full text-left px-3 py-1 text-xs hover:opacity-80"
              style={{
                background: active ? '#0f3460' : 'transparent',
                borderLeft: active ? '2px solid #e94560' : '2px solid transparent',
                borderBottom: '1px solid rgba(15,52,96,0.4)',
                color: '#d1d5db',
              }}
              onClick={() => {
                if (info) {
                  actions.updateChannelInfo(selectedSection, selectedPart, {
                    bankMSB: v.msb, bankLSB: v.lsb, program: v.pc,
                  });
                }
              }}
            >
              <div style={{ color: active ? '#e94560' : '#eaeaea' }}>{v.name}</div>
              <div style={{ color: '#6b7280', fontSize: 9 }}>{v.msb}/{v.lsb}/{v.pc + 1}</div>
            </button>
          );
        })}
      </div>
    </div>
  );
}

// ── Sub-components ────────────────────────────────────────────────────────────

function PanKnob({ value, onChange, disabled }) {
  const normalized = (value - 64) / 64;
  const angle = normalized * 135;

  return (
    <div className="flex flex-col items-center gap-0.5">
      <svg width={40} height={40} viewBox="-20 -20 40 40">
        <circle cx={0} cy={0} r={14} fill="none" stroke="#0f3460" strokeWidth={3} />
        <circle
          cx={0} cy={0} r={14}
          fill="none" stroke="#e94560" strokeWidth={3}
          strokeDasharray={`${Math.abs(normalized) * 44} 88`}
          strokeDashoffset={normalized > 0 ? 44 : 44 - Math.abs(normalized) * 44}
          transform="rotate(-90)"
          opacity={0.8}
        />
        <line x1={0} y1={0} x2={0} y2={-11} stroke="#eaeaea" strokeWidth={2} transform={`rotate(${angle})`} />
        <circle cx={0} cy={0} r={4} fill="#16213e" stroke="#9ca3af" strokeWidth={1} />
      </svg>
      <input
        type="range" min={0} max={127} value={value}
        onChange={e => onChange(parseInt(e.target.value))}
        disabled={disabled}
        onClick={e => e.stopPropagation()}
        className="w-full accent-[#e94560]"
        style={{ opacity: 0, position: 'absolute', width: 40, height: 40, cursor: 'pointer' }}
      />
      <span style={{ color: '#6b7280', fontSize: 9 }}>
        {value === 64 ? 'C' : value < 64 ? `L${64 - value}` : `R${value - 64}`}
      </span>
    </div>
  );
}

function SendKnob({ label, value, onChange, disabled }) {
  const r = 10;
  const circ = 2 * Math.PI * r;
  const maxArc = circ * 0.75;
  const arcLen = (value / 127) * maxArc;

  return (
    <div className="flex flex-col items-center gap-0.5" style={{ opacity: disabled ? 0.4 : 1 }}>
      <div style={{ position: 'relative', width: 28, height: 28 }}>
        <svg width={28} height={28} viewBox="-14 -14 28 28">
          <circle cx={0} cy={0} r={r} fill="none" stroke="#0f3460" strokeWidth={2.5}
            strokeDasharray={`${maxArc} ${circ}`} transform="rotate(135)" />
          {arcLen > 0 && (
            <circle cx={0} cy={0} r={r} fill="none" stroke="#e94560" strokeWidth={2.5}
              strokeDasharray={`${arcLen} ${circ}`} transform="rotate(135)" opacity={0.85} />
          )}
          <circle cx={0} cy={0} r={3} fill="#16213e" stroke="#9ca3af" strokeWidth={1} />
        </svg>
        <input
          type="range" min={0} max={127} value={value}
          onChange={e => onChange(parseInt(e.target.value))}
          disabled={disabled}
          onClick={e => e.stopPropagation()}
          style={{ position: 'absolute', top: 0, left: 0, width: 28, height: 28, opacity: 0, cursor: disabled ? 'default' : 'pointer', margin: 0 }}
        />
      </div>
      <span style={{ color: '#6b7280', fontSize: 9 }}>{label}</span>
      <span style={{ color: '#9ca3af', fontSize: 9 }}>{value}</span>
    </div>
  );
}

function VoiceField({ label, value, onChange, min = 0, max = 127 }) {
  return (
    <label className="flex flex-col gap-0.5">
      <span style={{ color: '#9ca3af', fontSize: 9 }}>{label}</span>
      <input
        type="number" min={min} max={max} value={value}
        onChange={e => { const v = parseInt(e.target.value); if (!isNaN(v) && v >= min && v <= max) onChange(v); }}
        className="w-full px-1 py-0.5 rounded text-xs font-mono"
        style={{ background: '#0f3460', color: '#eaeaea', border: '1px solid #1a1a2e', outline: 'none' }}
      />
    </label>
  );
}

function EmptyState({ msg }) {
  return (
    <div className="flex items-center justify-center h-full" style={{ background: '#1a1a2e', color: '#9ca3af' }}>
      {msg}
    </div>
  );
}
