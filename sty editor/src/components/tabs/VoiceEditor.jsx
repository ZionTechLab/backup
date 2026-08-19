import { useState, useEffect, useRef } from 'react';
import { useEditor } from '../../store/useEditorStore';
import { PART_NAMES } from '../../parser/StyleFileParser';
import { lookupVoiceName, VOICE_CATEGORIES, getVoicesByCategory, findVoice } from '../../data/VoiceMap';

export default function VoiceEditor() {
  const { state, actions } = useEditor();
  const { styleFile, selectedSection, selectedPart } = state;
  const section = styleFile?.sections[selectedSection];

  const [browserCategory, setBrowserCategory] = useState('Piano');
  const activeVoiceRef = useRef(null);

  const info = section?.channelInfo?.[selectedPart];

  // When the selected part changes, jump the browser to that voice's category
  useEffect(() => {
    if (!info) return;
    const voice = findVoice(info.bankMSB ?? 0, info.bankLSB ?? 0, info.program ?? 0);
    if (voice?.category) setBrowserCategory(voice.category);
  }, [selectedPart, info?.bankMSB, info?.bankLSB, info?.program]); // eslint-disable-line react-hooks/exhaustive-deps

  // Scroll the active voice into view whenever the list or selection changes
  useEffect(() => {
    activeVoiceRef.current?.scrollIntoView({ block: 'nearest', behavior: 'smooth' });
  }, [browserCategory, selectedPart]);

  if (!section) {
    return <EmptyState msg="Select a section to edit voices." />;
  }

  const parts = Object.keys(section.channelInfo || {}).map(Number).sort((a, b) => a - b);
  const partVoices = getVoicesByCategory(browserCategory);
  const isActiveVoice = v =>
    info &&
    v.msb === (info.bankMSB ?? 0) &&
    v.lsb === (info.bankLSB ?? 0) &&
    v.pc  === (info.program  ?? 0);

  return (
    <div className="flex h-full" style={{ background: '#1a1a2e' }}>

      {/* Left: Part list */}
      <div
        className="flex flex-col overflow-y-auto shrink-0"
        style={{ width: 140, borderRight: '1px solid #0f3460', background: '#16213e' }}
      >
        <div
          className="px-3 py-2 text-xs font-semibold uppercase tracking-wider"
          style={{ color: '#9ca3af', borderBottom: '1px solid #0f3460' }}
        >
          Parts
        </div>
        {parts.map(ch => {
          const chInfo  = section.channelInfo?.[ch];
          const hasData = !!chInfo;
          const vName   = hasData
            ? lookupVoiceName(chInfo.bankMSB ?? 0, chInfo.bankLSB ?? 0, chInfo.program ?? 0)
            : 'Empty';

          return (
            <button
              key={ch}
              onClick={() => actions.selectPart(ch)}
              className="w-full text-left px-3 py-2"
              style={{
                background: selectedPart === ch ? '#0f3460' : 'transparent',
                borderLeft: selectedPart === ch ? '3px solid #e94560' : '3px solid transparent',
                opacity: hasData ? 1 : 0.35,
              }}
            >
              <div className="text-xs font-semibold" style={{ color: '#eaeaea' }}>
                {PART_NAMES[ch] || `Ch ${ch}`}
              </div>
              <div style={{ color: '#6b7280', fontSize: 9 }} className="truncate max-w-full">
                {vName}
              </div>
            </button>
          );
        })}
      </div>

      {/* Center: Part voice detail */}
      <div className="flex flex-col flex-1 overflow-y-auto p-4 gap-4">
        <h3 className="text-sm font-semibold" style={{ color: '#eaeaea' }}>
          {PART_NAMES[selectedPart] || `Ch ${selectedPart}`} — Voice Assignment
        </h3>

        {info ? (
          <div className="flex flex-col gap-3 max-w-md">
            {/* Voice name display */}
            <div
              className="px-3 py-2 rounded text-sm font-semibold"
              style={{ background: '#16213e', color: '#e94560', border: '1px solid #0f3460' }}
            >
              {lookupVoiceName(info.bankMSB ?? 0, info.bankLSB ?? 0, info.program ?? 0)}
            </div>

            {/* MSB / LSB / PC */}
            <div className="grid grid-cols-3 gap-2">
              <VoiceField
                label="Bank MSB (CC0)"
                value={info.bankMSB ?? 0}
                onChange={v => actions.updateChannelInfo(selectedSection, selectedPart, { bankMSB: v })}
              />
              <VoiceField
                label="Bank LSB (CC32)"
                value={info.bankLSB ?? 0}
                onChange={v => actions.updateChannelInfo(selectedSection, selectedPart, { bankLSB: v })}
              />
              <VoiceField
                label="Program (1–128)"
                value={(info.program ?? 0) + 1}
                onChange={v => actions.updateChannelInfo(selectedSection, selectedPart, { program: v - 1 })}
                min={1} max={128}
              />
            </div>

            {/* Channel info summary */}
            <div
              className="rounded p-3 grid grid-cols-2 gap-2 text-xs"
              style={{ background: '#16213e', border: '1px solid #0f3460' }}
            >
              <InfoRow label="Volume"     value={info.volume     ?? 100} />
              <InfoRow label="Pan"        value={info.pan        ?? 64}  />
              <InfoRow label="Reverb"     value={info.reverb     ?? 0}   />
              <InfoRow label="Chorus"     value={info.chorus     ?? 0}   />
              <InfoRow label="Expression" value={info.expression ?? 127} />
              <InfoRow label="Channel"    value={selectedPart}            />
            </div>
          </div>
        ) : (
          <div className="text-sm" style={{ color: '#9ca3af' }}>
            No voice data for this part in the selected section.
          </div>
        )}
      </div>

      {/* Right: Voice browser */}
      <div
        className="flex flex-col shrink-0 overflow-hidden"
        style={{ width: 220, borderLeft: '1px solid #0f3460', background: '#16213e' }}
      >
        <div
          className="px-3 py-2 text-xs font-semibold uppercase tracking-wider"
          style={{ color: '#9ca3af', borderBottom: '1px solid #0f3460' }}
        >
          Voice Browser
        </div>

        {/* Category tabs */}
        <div className="overflow-y-auto" style={{ maxHeight: 160, borderBottom: '1px solid #0f3460' }}>
          {VOICE_CATEGORIES.map(cat => (
            <button
              key={cat}
              onClick={() => setBrowserCategory(cat)}
              className="w-full text-left px-3 py-1.5 text-xs"
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

        {/* Voice list */}
        <div className="flex-1 overflow-y-auto">
          {partVoices.map((v, i) => {
            const active = isActiveVoice(v);
            return (
              <button
                key={i}
                ref={active ? activeVoiceRef : null}
                className="w-full text-left px-3 py-1.5 text-xs hover:opacity-80"
                style={{
                  background: active ? '#0f3460' : 'transparent',
                  borderLeft: active ? '2px solid #e94560' : '2px solid transparent',
                  borderBottom: '1px solid rgba(15,52,96,0.5)',
                  color: '#d1d5db',
                }}
                onClick={() => {
                  if (info) {
                    actions.updateChannelInfo(selectedSection, selectedPart, {
                      bankMSB: v.msb,
                      bankLSB: v.lsb,
                      program: v.pc,
                    });
                  }
                }}
              >
                <div style={{ color: active ? '#e94560' : '#eaeaea' }}>{v.name}</div>
                <div style={{ color: '#6b7280', fontSize: 9 }}>
                  {v.msb}/{v.lsb}/{v.pc + 1}
                </div>
              </button>
            );
          })}
        </div>
      </div>
    </div>
  );
}

function VoiceField({ label, value, onChange, min = 0, max = 127 }) {
  return (
    <label className="flex flex-col gap-1">
      <span className="text-xs" style={{ color: '#9ca3af' }}>{label}</span>
      <input
        type="number"
        min={min} max={max}
        value={value}
        onChange={e => {
          const v = parseInt(e.target.value);
          if (!isNaN(v) && v >= min && v <= max) onChange(v);
        }}
        className="w-full px-2 py-1 rounded text-xs font-mono"
        style={{
          background: '#0f3460',
          color: '#eaeaea',
          border: '1px solid #1a1a2e',
          outline: 'none',
        }}
      />
    </label>
  );
}

function InfoRow({ label, value }) {
  return (
    <div className="flex justify-between">
      <span style={{ color: '#6b7280' }}>{label}</span>
      <span style={{ color: '#eaeaea' }}>{value}</span>
    </div>
  );
}

function EmptyState({ msg }) {
  return (
    <div
      className="flex items-center justify-center h-full"
      style={{ background: '#1a1a2e', color: '#9ca3af' }}
    >
      {msg}
    </div>
  );
}
