import { useState, useMemo, useRef, useEffect } from 'react';
import { DataGrid } from '../DataGrid';

const toNum = (v) => Number(String(v ?? '').replace(/[^\d.]/g, '')) || 0;

function round2(n) {
  return Math.round((Number(n) + Number.EPSILON) * 100) / 100;
}

const DENOM_COLUMNS = [
  {
    header: 'Denomination',
    field: 'denomination',
    type: 'amount',
    placeholder: '0.00',
    width: '30%',
  },
  {
    header: 'Count',
    field: 'count',
    type: 'number',
    placeholder: '0',
    width: '30%',
  },
  {
    header: 'Line Total',
    field: 'lineTotal',
    type: 'amount',
    placeholder: '0.00',
    readOnly: true,
    width: '40%',
  },
];

/**
 * Reusable cash denomination grid.
 *
 * Props:
 *   value      –     cashDenomination[]   { denomination: number, count: number }
 *   onChange   –     (lines) => void       fires on every change with updated lines
 *   readOnly   –     boolean               disables add/delete/edit when true
 *
 * Returns:
 *   { lines, total } via render prop or onChange + value
 *
 * Usage:
 *   <CashDenomination
 *     value={lines}
 *     onChange={setLines}
 *     readOnly={!isDraft}
 *   />
 */
export default function CashDenomination({ value = [], onChange, readOnly = false }) {
  const gridRef = useRef();
  const [lines, setLines] = useState([]);

  // Sync external value → internal state
  useEffect(() => {
    const mapped = (value || []).map((d) => ({
      denomination: d.denomination,
      count: d.count,
      lineTotal: round2(toNum(d.denomination) * toNum(d.count)),
    }));
    if (JSON.stringify(mapped) !== JSON.stringify(lines)) {
      setLines(mapped);
      gridRef.current?.reset(mapped);
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [JSON.stringify(value)]);

  // Recompute line totals on change
  useEffect(() => {
    const updated = lines.map((d) => ({
      ...d,
      lineTotal: round2(toNum(d.denomination) * toNum(d.count)),
    }));
    const changed = updated.some((u, i) => u.lineTotal !== (lines[i]?.lineTotal));
    if (changed) setLines(updated);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [lines.map((d) => `${d.denomination}_${d.count}`).join('|')]);

  // Notify parent on every change
  useEffect(() => {
    if (onChange) onChange(lines);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [JSON.stringify(lines)]);

  // Live total
  const total = useMemo(() => round2(lines.reduce((sum, d) => sum + toNum(d.denomination) * toNum(d.count), 0)), [lines]);

  return (
    <div>
      <DataGrid
        ref={gridRef}
        columns={DENOM_COLUMNS}
        data={lines}
        onDataChange={(data) => setLines(data)}
        allowAdd={!readOnly}
        allowDelete={!readOnly}
        placeholder="Add denomination..."
      />
      <div className="d-flex justify-content-end mt-2">
        <span className="fw-bold">Total: {total.toLocaleString(undefined, { minimumFractionDigits: 2 })}</span>
      </div>
    </div>
  );
}

/**
 * Convert denomination lines to API-ready format.
 * Filters out zero-amount lines, rounds values.
 */
export function toDenomPayload(lines) {
  return lines
    .filter((d) => toNum(d.denomination) > 0)
    .map((d, i) => ({
      lineNo: i + 1,
      denomination: toNum(d.denomination),
      count: Math.round(toNum(d.count)),
    }));
}

/**
 * Compute total from denomination lines.
 */
export function denomTotal(lines) {
  return round2((lines || []).reduce((sum, d) => sum + toNum(d.denomination) * toNum(d.count), 0));
}
