/**
 * Piano Roll editor
 *
 * Interactions:
 *  Left-click empty space  → add note at snapped position + drag for duration
 *  Left-click on note      → select / drag to move
 *  Right-click on note     → delete
 *  Delete / Backspace key  → delete selected note
 *  Ctrl+scroll             → horizontal zoom
 *  Alt+scroll              → vertical zoom
 *  Space (global)          → play/stop (wired in App.jsx)
 */
import { useRef, useEffect, useCallback, useState, useMemo } from 'react';
import { useEditor } from '../../store/useEditorStore';
import { PART_NAMES, noteName } from '../../parser/StyleFileParser';
import { playhead } from '../../playheadSync';

// ─── Layout ──────────────────────────────────────────────────────────────────
const PITCHES      = 128;
const BASE_NOTE_H  = 8;     // px per row at vZoom = 1
const RULER_H      = 24;
const LABEL_W      = 44;
const VEL_H        = 80;
const DEFAULT_tpb  = 480;
const DEFAULT_VEL  = 100;
const BLACK_NOTES  = new Set([1, 3, 6, 8, 10]);
const V_ZOOM_MIN   = 0.5;
const V_ZOOM_MAX   = 5;

const CH_COLOR = [
  '#e94560', '#f59e0b', '#10b981', '#3b82f6',
  '#8b5cf6', '#ec4899', '#06b6d4', '#84cc16',
];

// ─── Helpers ─────────────────────────────────────────────────────────────────
const toPx   = (tick, zoom) => tick * zoom * 0.12;
const toTick = (px,   zoom) => px   / (zoom * 0.12);
const snap   = (tick, s)    => Math.round(tick / s) * s;

function canvasXY(e, canvas) {
  const r = canvas.getBoundingClientRect();
  return [e.clientX - r.left, e.clientY - r.top];
}

function xyToNotePos(cx, cy, zoom, noteH) {
  return {
    tick:  Math.max(0, toTick(cx - LABEL_W, zoom)),
    pitch: Math.max(0, Math.min(127, PITCHES - 1 - Math.floor(cy / noteH))),
  };
}

function hitVelBar(notes, cx, zoom, sl, filter) {
  let best = -1, bestDist = 6;
  for (let i = 0; i < notes.length; i++) {
    const n = notes[i];
    if (!filter.includes(n.channel)) continue;
    const bx = LABEL_W + toPx(n.tick, zoom) - sl;
    const d  = Math.abs(cx - bx);
    if (d < bestDist) { bestDist = d; best = i; }
  }
  return best;
}

function hitNote(notes, cx, cy, zoom, noteH) {
  const pitch = PITCHES - 1 - Math.floor(cy / noteH);
  for (let i = notes.length - 1; i >= 0; i--) {
    const n = notes[i];
    if (n.note !== pitch) continue;
    const nx = LABEL_W + toPx(n.tick, zoom);
    const nw = Math.max(4, toPx(Math.max(n.duration, 30), zoom));
    if (cx >= nx && cx <= nx + nw) return i;
  }
  return -1;
}

// ─── Component ────────────────────────────────────────────────────────────────
export default function PianoRoll() {
  const { state, actions } = useEditor();
  const { styleFile, selectedSection, selectedPart, zoom, snapGrid, channelFilter } = state;

  const tpb     = styleFile?.ticksPerBeat || DEFAULT_tpb;
  const SNAP_MAP = useMemo(() => ({
    '1/4': tpb, '1/8': tpb / 2, '1/16': tpb / 4, '1/32': tpb / 8,
  }), [tpb]);

  const section = styleFile?.sections[selectedSection];
  const notes   = useMemo(() => section?.notes || [], [section]);

  // Vertical zoom state — local to the roll, not in global store
  const [vZoom, setVZoom] = useState(1);
  const noteH = Math.max(2, Math.round(BASE_NOTE_H * vZoom));
  const prevNoteHRef = useRef(noteH);

  const clampVZoom = (v) => Math.max(V_ZOOM_MIN, Math.min(V_ZOOM_MAX, v));

  const sectionChannels = useMemo(
    () => Object.keys(section?.channelInfo || {}).map(Number).sort((a, b) => a - b),
    [section]
  );

  const effectiveFilter = useMemo(() => {
    const chInfo = section?.channelInfo || {};
    const mutedChs  = new Set(Object.entries(chInfo).filter(([, i]) => i?.muted) .map(([ch]) => Number(ch)));
    const soloedChs = new Set(Object.entries(chInfo).filter(([, i]) => i?.soloed).map(([ch]) => Number(ch)));
    const anySoloed = soloedChs.size > 0;
    return channelFilter.filter(ch => {
      if (mutedChs.has(ch)) return false;
      if (anySoloed && !soloedChs.has(ch)) return false;
      return true;
    });
  }, [channelFilter, section?.channelInfo]);

  const snapVal = SNAP_MAP[snapGrid] || tpb / 4;

  const mainRef  = useRef(null);
  const rulerRef = useRef(null);
  const velRef   = useRef(null);
  const contRef  = useRef(null);

  const dragRef     = useRef(null);
  const velDragRef  = useRef(null);
  const velHoverRef = useRef(-1);
  const scrollRef   = useRef(0);
  const rafRef      = useRef(null);

  const [selectedIdx, setSelectedIdx] = useState(null);
  const [scrollLeft,  setScrollLeft]  = useState(0);

  const canvasW = useMemo(() => {
    const lastTick = notes.length > 0
      ? Math.max(...notes.map(n => n.tick + Math.max(n.duration, tpb)))
      : tpb * 32;
    return Math.max(600, LABEL_W + toPx(lastTick + tpb * 8, zoom));
  }, [notes, zoom, tpb]);

  const canvasH = PITCHES * noteH;

  useEffect(() => { scrollRef.current = scrollLeft; }, [scrollLeft]);

  // ── Auto-scroll to note range when section changes ─────────────────────────
  useEffect(() => {
    if (!contRef.current) return;
    const c = contRef.current;
    if (notes.length === 0) {
      c.scrollTop = (PITCHES - 1 - 72) * noteH - c.clientHeight / 2;
    } else {
      const min = Math.min(...notes.map(n => n.note));
      const max = Math.max(...notes.map(n => n.note));
      c.scrollTop = (PITCHES - 1 - (min + max) / 2) * noteH - c.clientHeight / 2;
    }
    setSelectedIdx(null);
  }, [selectedSection]); // eslint-disable-line react-hooks/exhaustive-deps

  // ── Preserve center pitch when vertical zoom changes ──────────────────────
  useEffect(() => {
    const c = contRef.current;
    const prev = prevNoteHRef.current;
    if (!c || prev === noteH) return;
    // find the pitch at the center of the viewport, then re-center on it
    const centerPitch = PITCHES - 1 - Math.round((c.scrollTop + c.clientHeight / 2) / prev);
    prevNoteHRef.current = noteH;
    c.scrollTop = Math.max(0, (PITCHES - 1 - centerPitch) * noteH - c.clientHeight / 2);
  }, [noteH]);

  // ── Unified RAF draw loop ──────────────────────────────────────────────────
  const drawAll = useCallback(() => {
    const sl  = scrollRef.current;
    const drg = dragRef.current;

    // ── Main canvas ───────────────────────────────────────────────────────────
    const mc = mainRef.current;
    if (mc) {
      const ctx = mc.getContext('2d');
      const W = mc.width, H = mc.height;
      ctx.clearRect(0, 0, W, H);

      // Row backgrounds
      for (let p = 0; p < PITCHES; p++) {
        const y = (PITCHES - 1 - p) * noteH;
        ctx.fillStyle = BLACK_NOTES.has(p % 12) ? '#121224' : '#1a1a2e';
        ctx.fillRect(LABEL_W, y, W - LABEL_W, noteH);
        if (p % 12 === 0) {
          ctx.fillStyle = 'rgba(15,52,96,0.45)';
          ctx.fillRect(LABEL_W, y, W - LABEL_W, noteH);
        }
      }

      // Beat grid
      const pxBeat = toPx(tpb, zoom);
      const sb = Math.floor(sl / pxBeat);
      const vb = Math.ceil((W - LABEL_W) / pxBeat) + 2;
      for (let b = sb; b < sb + vb; b++) {
        const x     = LABEL_W + b * pxBeat - sl;
        const isBar = b % 4 === 0;
        ctx.strokeStyle = isBar ? 'rgba(255,255,255,0.09)' : 'rgba(255,255,255,0.03)';
        ctx.lineWidth = 1;
        ctx.beginPath(); ctx.moveTo(x, 0); ctx.lineTo(x, H); ctx.stroke();
      }

      // Pitch labels (fixed left column)
      ctx.fillStyle = '#16213e';
      ctx.fillRect(0, 0, LABEL_W, H);
      for (let p = 0; p < PITCHES; p++) {
        const y       = (PITCHES - 1 - p) * noteH;
        const isBlack = BLACK_NOTES.has(p % 12);
        ctx.fillStyle = isBlack ? '#0a0a18' : '#252538';
        ctx.fillRect(0, y, LABEL_W - 2, noteH);
        if (p % 12 === 0 && noteH >= 5) {
          ctx.fillStyle = '#e94560';
          ctx.font = `${Math.min(8, noteH - 1)}px monospace`;
          ctx.fillText(noteName(p), 2, y + noteH - 1);
        }
      }

      // Notes
      const nh = Math.max(2, noteH - 2);
      for (let i = 0; i < notes.length; i++) {
        const n = notes[i];
        if (!effectiveFilter.includes(n.channel)) continue;

        let t = n.tick, p = n.note;
        if (drg?.mode === 'move' && drg.idx === i) {
          t = drg.curTick; p = drg.curPitch;
        }

        const x  = LABEL_W + toPx(t, zoom) - sl;
        const nw = Math.max(3, toPx(Math.max(n.duration, 30), zoom) - 1);
        const y  = (PITCHES - 1 - p) * noteH + 1;
        if (x + nw < LABEL_W || x > W) continue;

        const color = CH_COLOR[(n.channel - 1) % CH_COLOR.length];
        const sel   = i === selectedIdx;
        ctx.globalAlpha = 0.6 + (n.velocity / 127) * 0.4;
        ctx.fillStyle   = sel ? '#fff' : color;
        ctx.fillRect(x, y, nw, nh);
        ctx.globalAlpha = 0.3; ctx.fillStyle = '#fff';
        ctx.fillRect(x, y, nw, Math.min(2, nh));
        ctx.globalAlpha = 1;
        if (sel) {
          ctx.strokeStyle = '#e94560'; ctx.lineWidth = 1.5;
          ctx.strokeRect(x, y, nw, nh);
        }
      }

      // Ghost note (draw mode)
      if (drg?.mode === 'draw') {
        const x  = LABEL_W + toPx(drg.startTick, zoom) - sl;
        const nw = Math.max(3, toPx(Math.max(drg.curDur, 30), zoom) - 1);
        const y  = (PITCHES - 1 - drg.pitch) * noteH + 1;
        const c  = CH_COLOR[(drg.channel - 1) % CH_COLOR.length];
        ctx.globalAlpha = 0.55;
        ctx.fillStyle   = c;
        ctx.fillRect(x, y, nw, nh);
        ctx.globalAlpha = 1;
        ctx.strokeStyle = '#fff'; ctx.lineWidth = 1;
        ctx.strokeRect(x, y, nw, nh);
      }

      // Playback cursor
      if (playhead.isPlaying) {
        const cx = LABEL_W + toPx(playhead.tick, zoom) - sl;
        if (cx >= LABEL_W && cx <= W) {
          ctx.strokeStyle = 'rgba(255,210,0,0.9)'; ctx.lineWidth = 2;
          ctx.beginPath(); ctx.moveTo(cx, 0); ctx.lineTo(cx, H); ctx.stroke();
          ctx.fillStyle = 'rgba(255,210,0,0.9)';
          ctx.beginPath();
          ctx.moveTo(cx - 5, 0); ctx.lineTo(cx + 5, 0); ctx.lineTo(cx, 8);
          ctx.fill();
        }
      }
    }

    // ── Ruler ─────────────────────────────────────────────────────────────────
    const rc = rulerRef.current;
    if (rc) {
      const ctx = rc.getContext('2d');
      const W = rc.width, H = rc.height;
      ctx.fillStyle = '#16213e'; ctx.fillRect(0, 0, W, H);

      const pxBeat = toPx(tpb, zoom);
      const sb     = Math.floor(sl / pxBeat);
      const vb     = Math.ceil((W - LABEL_W) / pxBeat) + 2;
      ctx.font = '9px monospace';
      for (let b = sb; b < sb + vb; b++) {
        const x     = LABEL_W + b * pxBeat - sl;
        const isBar = b % 4 === 0;
        if (isBar) {
          ctx.fillStyle = '#e94560';
          ctx.fillText(`${Math.floor(b / 4) + 1}`, x + 2, 13);
        } else if (pxBeat > 28) {
          ctx.fillStyle = '#3a3a5e';
          ctx.fillText(`${b % 4 + 1}`, x + 2, 13);
        }
        ctx.strokeStyle = isBar ? 'rgba(233,69,96,0.5)' : 'rgba(255,255,255,0.06)';
        ctx.lineWidth = 1;
        ctx.beginPath(); ctx.moveTo(x, isBar ? 0 : H / 2); ctx.lineTo(x, H); ctx.stroke();
      }

      if (playhead.isPlaying) {
        const cx = LABEL_W + toPx(playhead.tick, zoom) - sl;
        if (cx >= LABEL_W && cx <= W) {
          ctx.fillStyle = 'rgba(255,210,0,0.7)';
          ctx.fillRect(cx - 1, 0, 2, H);
        }
      }

      ctx.fillStyle = '#16213e'; ctx.fillRect(0, 0, LABEL_W, H);
      ctx.fillStyle = '#4b5563'; ctx.font = '9px monospace';
      ctx.fillText('BAR', 4, 13);
    }

    // ── Velocity lane ──────────────────────────────────────────────────────────
    const vc = velRef.current;
    if (vc) {
      const ctx = vc.getContext('2d');
      const W = vc.width, H = vc.height;
      ctx.fillStyle = '#0e0e1e'; ctx.fillRect(0, 0, W, H);
      ctx.fillStyle = '#16213e'; ctx.fillRect(0, 0, LABEL_W, H);

      [32, 64, 96, 127].forEach(v => {
        const y = H - Math.round((v / 127) * (H - 4));
        ctx.strokeStyle = 'rgba(255,255,255,0.05)'; ctx.lineWidth = 1;
        ctx.beginPath(); ctx.moveTo(LABEL_W, y); ctx.lineTo(W, y); ctx.stroke();
      });

      let tooltipNote = null;
      for (let i = 0; i < notes.length; i++) {
        const n = notes[i];
        if (!effectiveFilter.includes(n.channel)) continue;
        const x = LABEL_W + toPx(n.tick, zoom) - sl;
        if (x < LABEL_W - 10 || x > W + 10) continue;

        const isDrag  = velDragRef.current?.idx  === i;
        const isHover = velHoverRef.current === i && !velDragRef.current;
        const vel     = isDrag ? velDragRef.current.liveVel : n.velocity;
        const bh      = Math.max(2, Math.round((vel / 127) * (H - 4)));
        const color   = CH_COLOR[(n.channel - 1) % CH_COLOR.length];

        ctx.globalAlpha = (isDrag || isHover) ? 1 : 0.8;
        ctx.fillStyle   = color;
        ctx.fillRect(x - 1, H - bh, (isDrag || isHover) ? 4 : 3, bh);

        ctx.globalAlpha = 1;
        ctx.fillStyle   = isDrag ? '#fff' : color;
        ctx.fillRect(x - 1, H - bh - 1, (isDrag || isHover) ? 4 : 3, 2);

        if (isDrag || isHover) tooltipNote = { x, bh, vel };
      }
      ctx.globalAlpha = 1;

      if (tooltipNote) {
        const tx = Math.min(tooltipNote.x + 4, W - 22);
        const ty = Math.max(H - tooltipNote.bh - 6, 10);
        ctx.font = 'bold 9px monospace';
        ctx.fillStyle = '#fff';
        ctx.fillText(String(tooltipNote.vel), tx, ty);
      }

      ctx.fillStyle = '#6b7280'; ctx.font = '8px monospace';
      ctx.fillText('VEL', 4, 11);
    }
  }, [notes, zoom, noteH, selectedIdx, effectiveFilter, tpb]);

  useEffect(() => {
    let live = true;
    function frame() {
      if (!live) return;
      drawAll();
      rafRef.current = requestAnimationFrame(frame);
    }
    rafRef.current = requestAnimationFrame(frame);
    return () => {
      live = false;
      if (rafRef.current) cancelAnimationFrame(rafRef.current);
    };
  }, [drawAll]);

  // ── Scroll ────────────────────────────────────────────────────────────────
  function onScroll(e) {
    const sl = e.currentTarget.scrollLeft;
    scrollRef.current = sl;
    setScrollLeft(sl);
  }

  function onWheel(e) {
    if (e.ctrlKey || e.metaKey) {
      e.preventDefault();
      actions.setZoom(zoom + (e.deltaY > 0 ? -0.12 : 0.12));
    } else if (e.altKey) {
      e.preventDefault();
      setVZoom(v => clampVZoom(v * (e.deltaY > 0 ? 0.85 : 1.18)));
    }
  }

  // ── Mouse down ────────────────────────────────────────────────────────────
  const onMouseDown = useCallback((e) => {
    e.preventDefault();
    const canvas = mainRef.current;
    if (!canvas) return;
    const [cx, cy] = canvasXY(e, canvas);
    if (cx < LABEL_W) return;

    if (e.button === 2) {
      const idx = hitNote(notes, cx, cy, zoom, noteH);
      if (idx !== -1) {
        actions.deleteNote(selectedSection, idx);
        if (selectedIdx === idx) setSelectedIdx(null);
      }
      return;
    }

    if (e.button === 0) {
      const idx = hitNote(notes, cx, cy, zoom, noteH);
      if (idx !== -1) {
        setSelectedIdx(idx);
        const n = notes[idx];
        dragRef.current = {
          mode: 'move', idx,
          sx: cx, sy: cy,
          origTick: n.tick, origPitch: n.note,
          curTick: n.tick, curPitch: n.note,
        };
      } else {
        const { tick, pitch } = xyToNotePos(cx, cy, zoom, noteH);
        const st = snap(tick, snapVal);
        dragRef.current = {
          mode: 'draw',
          startTick: st, pitch,
          channel: selectedPart,
          curDur: snapVal, sx: cx,
        };
        setSelectedIdx(null);
      }
    }

    document.addEventListener('mousemove', onMouseMove);
    document.addEventListener('mouseup',   onMouseUp);
  }, [notes, zoom, noteH, snapVal, selectedPart, selectedSection, selectedIdx]); // eslint-disable-line react-hooks/exhaustive-deps

  const onMouseMove = useCallback((e) => {
    const canvas = mainRef.current;
    if (!canvas || !dragRef.current) return;
    const [cx, cy] = canvasXY(e, canvas);
    const d = dragRef.current;

    if (d.mode === 'move') {
      const { tick: rawTick, pitch } = xyToNotePos(cx, cy, zoom, noteH);
      const dTick = rawTick - toTick(d.sx - LABEL_W, zoom);
      dragRef.current = {
        ...d,
        curTick:  Math.max(0, snap(d.origTick + dTick, snapVal)),
        curPitch: Math.max(0, Math.min(127, pitch)),
      };
    } else if (d.mode === 'draw') {
      const { tick: rawTick } = xyToNotePos(cx, cy, zoom, noteH);
      const dur = Math.max(snapVal, snap(rawTick - d.startTick + snapVal, snapVal));
      dragRef.current = { ...d, curDur: dur };
    }
  }, [zoom, noteH, snapVal]);

  const onMouseUp = useCallback(() => {
    document.removeEventListener('mousemove', onMouseMove);
    document.removeEventListener('mouseup',   onMouseUp);
    const d = dragRef.current;
    dragRef.current = null;
    if (!d) return;

    if (d.mode === 'move') {
      if (d.curTick !== d.origTick || d.curPitch !== d.origPitch) {
        actions.updateNote(selectedSection, d.idx, { tick: d.curTick, note: d.curPitch });
      }
    } else if (d.mode === 'draw') {
      actions.addNote(selectedSection, {
        tick: d.startTick, note: d.pitch, duration: d.curDur,
        velocity: DEFAULT_VEL, channel: d.channel,
      });
    }
  }, [selectedSection, onMouseMove]); // eslint-disable-line react-hooks/exhaustive-deps

  function onContextMenu(e) { e.preventDefault(); }

  // ── Velocity lane interactions ─────────────────────────────────────────────
  const onVelMouseDown = useCallback((e) => {
    e.preventDefault();
    const canvas = velRef.current;
    if (!canvas) return;
    const [cx] = canvasXY(e, canvas);
    if (cx < LABEL_W) return;
    const idx = hitVelBar(notes, cx, zoom, scrollRef.current, effectiveFilter);
    if (idx === -1) return;
    velDragRef.current = { idx, liveVel: notes[idx].velocity };
    document.addEventListener('mousemove', onVelDragMove);
    document.addEventListener('mouseup',   onVelDragUp);
  }, [notes, zoom, effectiveFilter]); // eslint-disable-line react-hooks/exhaustive-deps

  const onVelDragMove = useCallback((e) => {
    if (!velDragRef.current || !velRef.current) return;
    const [, cy] = canvasXY(e, velRef.current);
    const newVel = Math.max(1, Math.min(127, Math.round((1 - cy / VEL_H) * 127)));
    velDragRef.current = { ...velDragRef.current, liveVel: newVel };
  }, []);

  const onVelDragUp = useCallback(() => {
    document.removeEventListener('mousemove', onVelDragMove);
    document.removeEventListener('mouseup',   onVelDragUp);
    const d = velDragRef.current;
    velDragRef.current = null;
    if (d) actions.updateNote(selectedSection, d.idx, { velocity: d.liveVel });
  }, [selectedSection, onVelDragMove]); // eslint-disable-line react-hooks/exhaustive-deps

  const onVelHover = useCallback((e) => {
    if (velDragRef.current) return;
    const canvas = velRef.current;
    if (!canvas) return;
    const [cx] = canvasXY(e, canvas);
    velHoverRef.current = cx >= LABEL_W
      ? hitVelBar(notes, cx, zoom, scrollRef.current, effectiveFilter)
      : -1;
  }, [notes, zoom, effectiveFilter]); // eslint-disable-line react-hooks/exhaustive-deps

  const onVelLeave = useCallback(() => { velHoverRef.current = -1; }, []);

  // ── Delete key ────────────────────────────────────────────────────────────
  useEffect(() => {
    function onKey(e) {
      if (e.key === 'Delete' || e.key === 'Backspace') {
        if (selectedIdx !== null && selectedSection) {
          actions.deleteNote(selectedSection, selectedIdx);
          setSelectedIdx(null);
        }
      }
      if (e.key === 'Escape') setSelectedIdx(null);
    }
    window.addEventListener('keydown', onKey);
    return () => window.removeEventListener('keydown', onKey);
  }, [selectedIdx, selectedSection]); // eslint-disable-line react-hooks/exhaustive-deps

  // ── Empty state ───────────────────────────────────────────────────────────
  if (!section) {
    return (
      <div className="flex flex-col items-center justify-center h-full gap-2"
        style={{ background: '#1a1a2e', color: '#9ca3af' }}>
        <div className="text-4xl opacity-20">♪</div>
        <div className="font-semibold" style={{ color: '#eaeaea' }}>No Section Selected</div>
        <div className="text-sm">Select a section from the left sidebar.</div>
      </div>
    );
  }

  const visNotes = notes.filter(n => effectiveFilter.includes(n.channel));

  return (
    <div className="flex flex-col h-full" style={{ background: '#1a1a2e' }} tabIndex={-1}>

      {/* ── Toolbar ── */}
      <div
        className="flex items-center gap-2 px-3 h-9 shrink-0 border-b overflow-x-auto"
        style={{ borderColor: '#0f3460', background: '#16213e' }}
      >
        {/* Horizontal zoom */}
        <IcoLabel title="Horizontal zoom (Ctrl+scroll)"><IcoArrowsH /></IcoLabel>
        <Btn title="Zoom in" onClick={() => actions.setZoom(zoom * 1.5)}><IcoZoomIn /></Btn>
        <span className="text-xs" style={{ color: '#eaeaea', minWidth: 32, textAlign: 'center' }}>{Math.round(zoom * 100)}%</span>
        <Btn title="Zoom out" onClick={() => actions.setZoom(zoom / 1.5)}><IcoZoomOut /></Btn>
        <Btn title="Reset horizontal zoom" onClick={() => actions.setZoom(1)} muted><IcoFit /></Btn>

        <Sep />

        {/* Vertical zoom */}
        <IcoLabel title="Vertical zoom / row height (Alt+scroll)"><IcoArrowsV /></IcoLabel>
        <Btn title="Taller rows" onClick={() => setVZoom(v => clampVZoom(v * 1.5))}><IcoZoomIn /></Btn>
        <span className="text-xs" style={{ color: '#eaeaea', minWidth: 26, textAlign: 'center' }}>{noteH}px</span>
        <Btn title="Shorter rows" onClick={() => setVZoom(v => clampVZoom(v / 1.5))}><IcoZoomOut /></Btn>
        <Btn title="Reset row height" onClick={() => setVZoom(1)} muted><IcoFit /></Btn>

        <Sep />

        {/* Snap */}
        <IcoLabel title="Snap grid"><IcoGrid /></IcoLabel>
        {Object.keys(SNAP_MAP).map(g => (
          <Btn key={g} title={`Snap to ${g} note`} onClick={() => actions.setSnapGrid(g)} active={snapGrid === g}>{g}</Btn>
        ))}

        <Sep />

        {/* Quantize */}
        <Btn title="Quantize notes to snap grid"
          onClick={() => { actions.quantizeNotes(selectedSection, snapVal); actions.setStatus(`Quantized to ${snapGrid}`); }}>
          <IcoQuantize /> Quantize
        </Btn>

        <Sep />

        {/* Transpose */}
        <IcoLabel title="Transpose section"><IcoNote /></IcoLabel>
        <Btn title="Transpose down 1 semitone" onClick={() => actions.transposeSection(selectedSection, -1)}>♭ −1</Btn>
        <Btn title="Transpose up 1 semitone"   onClick={() => actions.transposeSection(selectedSection,  1)}>♯ +1</Btn>

        <Sep />

        {/* Channel filter */}
        <IcoLabel title="Channel visibility"><IcoCh /></IcoLabel>
        {sectionChannels.map(ch => {
          const on    = channelFilter.includes(ch);
          const muted = !effectiveFilter.includes(ch) && on;
          const color = CH_COLOR[(ch - 1) % CH_COLOR.length];
          return (
            <button key={ch} onClick={() => actions.toggleChannelFilter(ch)}
              title={PART_NAMES[ch] || `Ch ${ch}`}
              className="w-6 h-6 rounded text-xs font-bold shrink-0"
              style={{
                background: on ? color : '#0f3460',
                color: on ? '#000' : '#555',
                opacity: muted ? 0.35 : on ? 1 : 0.6,
                textDecoration: muted ? 'line-through' : 'none',
              }}>{ch}</button>
          );
        })}

        <div className="flex-1" />
        <span className="text-xs shrink-0" style={{ color: '#4b5563' }}>
          {visNotes.length}/{notes.length}
        </span>
      </div>

      {/* ── Ruler ── */}
      <div className="shrink-0" style={{ height: RULER_H, overflow: 'hidden' }}>
        <canvas ref={rulerRef} width={canvasW} height={RULER_H} style={{ display: 'block' }} />
      </div>

      {/* ── Main scrollable ── */}
      <div
        ref={contRef}
        className="flex-1 overflow-auto"
        onScroll={onScroll}
        onWheel={onWheel}
        style={{ cursor: 'crosshair' }}
      >
        <canvas
          ref={mainRef}
          width={canvasW}
          height={canvasH}
          style={{ display: 'block' }}
          onMouseDown={onMouseDown}
          onContextMenu={onContextMenu}
        />
      </div>

      {/* ── Velocity lane ── */}
      <div className="shrink-0" style={{ height: VEL_H, borderTop: '1px solid #0f3460', overflow: 'hidden' }}>
        <canvas
          ref={velRef}
          width={canvasW}
          height={VEL_H}
          style={{ display: 'block', cursor: 'ns-resize' }}
          onMouseDown={onVelMouseDown}
          onMouseMove={onVelHover}
          onMouseLeave={onVelLeave}
        />
      </div>
    </div>
  );
}

function Btn({ children, onClick, active, muted, title }) {
  return (
    <button onClick={onClick} title={title} className="px-2 h-6 rounded text-xs shrink-0"
      style={{
        background: active ? '#e94560' : '#0f3460',
        color: muted ? '#9ca3af' : '#eaeaea',
        display: 'inline-flex', alignItems: 'center', gap: 3,
      }}>
      {children}
    </button>
  );
}

function Sep() {
  return <div className="w-px h-4 shrink-0" style={{ background: '#0f3460' }} />;
}

// Section label with optional tooltip — no button affordance
function IcoLabel({ children, title }) {
  return (
    <span title={title} style={{ color: '#6b7280', display: 'inline-flex', alignItems: 'center' }}>
      {children}
    </span>
  );
}

// ─── Toolbar SVG icons ────────────────────────────────────────────────────────
const SVG = ({ children, w = 12, h = 12 }) => (
  <svg width={w} height={h} viewBox={`0 0 ${w} ${h}`}
    fill="none" stroke="currentColor" strokeWidth="1.3" strokeLinecap="round" strokeLinejoin="round"
    style={{ display: 'block', flexShrink: 0 }}>
    {children}
  </svg>
);

function IcoZoomIn() {
  return (
    <SVG>
      <circle cx="5" cy="5" r="3.5" />
      <line x1="7.5" y1="7.5" x2="11" y2="11" />
      <line x1="3.5" y1="5"   x2="6.5" y2="5" />
      <line x1="5"   y1="3.5" x2="5"   y2="6.5" />
    </SVG>
  );
}

function IcoZoomOut() {
  return (
    <SVG>
      <circle cx="5" cy="5" r="3.5" />
      <line x1="7.5" y1="7.5" x2="11" y2="11" />
      <line x1="3.5" y1="5"   x2="6.5" y2="5" />
    </SVG>
  );
}

function IcoFit() {
  return (
    <SVG>
      <polyline points="1,4 1,1 4,1" />
      <polyline points="8,1 11,1 11,4" />
      <polyline points="11,8 11,11 8,11" />
      <polyline points="4,11 1,11 1,8" />
    </SVG>
  );
}

function IcoArrowsH() {
  return (
    <SVG>
      <polyline points="4,3 1,6 4,9" />
      <polyline points="8,3 11,6 8,9" />
      <line x1="1" y1="6" x2="11" y2="6" />
    </SVG>
  );
}

function IcoArrowsV() {
  return (
    <SVG>
      <polyline points="3,4 6,1 9,4" />
      <polyline points="3,8 6,11 9,8" />
      <line x1="6" y1="1" x2="6" y2="11" />
    </SVG>
  );
}

function IcoGrid() {
  return (
    <SVG w={12} h={12}>
      <rect x="1"   y="1"   width="3" height="3" rx="0.5" fill="currentColor" stroke="none" />
      <rect x="5"   y="1"   width="3" height="3" rx="0.5" fill="currentColor" stroke="none" />
      <rect x="9"   y="1"   width="2" height="3" rx="0.5" fill="currentColor" stroke="none" />
      <rect x="1"   y="5"   width="3" height="2" rx="0.5" fill="currentColor" stroke="none" />
      <rect x="5"   y="5"   width="3" height="2" rx="0.5" fill="currentColor" stroke="none" />
      <rect x="9"   y="5"   width="2" height="2" rx="0.5" fill="currentColor" stroke="none" />
      <rect x="1"   y="9"   width="3" height="2" rx="0.5" fill="currentColor" stroke="none" />
      <rect x="5"   y="9"   width="3" height="2" rx="0.5" fill="currentColor" stroke="none" />
      <rect x="9"   y="9"   width="2" height="2" rx="0.5" fill="currentColor" stroke="none" />
    </SVG>
  );
}

function IcoQuantize() {
  return (
    <SVG w={12} h={12}>
      {/* note head + stem */}
      <ellipse cx="3.5" cy="9.5" rx="2.5" ry="1.8" fill="currentColor" stroke="none" transform="rotate(-15 3.5 9.5)" />
      <line x1="5.8" y1="9" x2="5.8" y2="2" strokeWidth="1.4" />
      {/* vertical grid lines */}
      <line x1="8"  y1="1" x2="8"  y2="11" strokeWidth="1" stroke="currentColor" strokeDasharray="1.5,1" />
      <line x1="11" y1="1" x2="11" y2="11" strokeWidth="1" stroke="currentColor" strokeDasharray="1.5,1" />
    </SVG>
  );
}

function IcoNote() {
  return (
    <SVG w={12} h={12}>
      <ellipse cx="3.5" cy="9.5" rx="2.5" ry="1.8" fill="currentColor" stroke="none" transform="rotate(-15 3.5 9.5)" />
      <line x1="5.8" y1="9" x2="5.8" y2="2" strokeWidth="1.4" />
      <line x1="5.8" y1="2" x2="10" y2="3.5" strokeWidth="1.2" />
    </SVG>
  );
}

function IcoCh() {
  return (
    <SVG w={12} h={12}>
      {/* four horizontal bars of different widths representing channels */}
      <line x1="1" y1="2.5"  x2="9"  y2="2.5"  strokeWidth="1.5" />
      <line x1="1" y1="5.5"  x2="11" y2="5.5"  strokeWidth="1.5" />
      <line x1="1" y1="8.5"  x2="7"  y2="8.5"  strokeWidth="1.5" />
    </SVG>
  );
}
