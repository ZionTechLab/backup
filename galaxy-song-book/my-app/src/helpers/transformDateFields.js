import config from '../config/config';

// Read live (not destructured at import) so a tenant-level override applied
// after login is picked up by every formatter below.
const getDisplayDateFormat = () => config.DISPLAY_DATE_FORMAT;

// Month name lookup tables for custom format patterns.
const MONTH_SHORT = ['Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec'];
const MONTH_LONG = ['January','February','March','April','May','June','July','August','September','October','November','December'];

// Formats a Date using the DISPLAY_DATE_FORMAT pattern.
// Tokens: YYYY, YY, MMMM, MMM, MM, DD
function formatWithPattern(d, pattern) {
  const day = String(d.getDate()).padStart(2, '0');
  const month = String(d.getMonth() + 1).padStart(2, '0');
  const year = String(d.getFullYear());

  return pattern
    .replace('YYYY', year)
    .replace('YY', year.slice(2))
    .replace('MMMM', MONTH_LONG[d.getMonth()])
    .replace('MMM', MONTH_SHORT[d.getMonth()])
    .replace('MM', month)
    .replace('DD', day);
}

// Formats any Date|string|number for display using DISPLAY_DATE_FORMAT.
export function formatDate(v) {
  if (!v && v !== 0) return '';
  const d = toDate(v);
  return d ? formatWithPattern(d, getDisplayDateFormat()) : '';
}

// Formats any Date|string|number as full date+time for display.
// Date portion uses DISPLAY_DATE_FORMAT, time is locale 24h HH:mm.
export function formatDateTime(v) {
  if (!v && v !== 0) return '';
  const d = toDate(v);
  if (!d) return '';
  const hh = String(d.getHours()).padStart(2, '0');
  const mm = String(d.getMinutes()).padStart(2, '0');
  return `${formatWithPattern(d, getDisplayDateFormat())} ${hh}:${mm}`;
}

// Returns any Date as YYYY-MM-DD for HTML date inputs. Defaults to today.
// (HTML <input type="date"> requires YYYY-MM-DD regardless of display config.)
export function toInputDate(d = new Date()) {
  return d instanceof Date && !isNaN(d.getTime())
    ? d.toISOString().slice(0, 10)
    : toInputDate(new Date());
}

// Convenience: today as YYYY-MM-DD (for form initialValue).
// Pass a Date to get that date formatted; omit for today.
export function todayISO(d) {
  return toInputDate(d);
}

// Returns now as YYYY-MM-DDTHH:mm (for datetime-local inputs).
export function nowDatetimeLocal() {
  return new Date().toISOString().slice(0, 16);
}

function toDate(v) {
  if (v instanceof Date) return isNaN(v.getTime()) ? null : v;
  const d = /^\d+$/.test(String(v)) ? new Date(Number(v)) : new Date(v);
  return isNaN(d.getTime()) ? null : d;
}

// Coerce any stored date shape (YYYY-MM-DD, ISO string, Date, or epoch-ms) to a
// plain YYYY-MM-DD string suitable for a date input. Returns "" when the value
// is falsy or cannot be parsed.
export function toDateOnly(v) {
  if (!v && v !== 0) return "";
  const d = toDate(v);
  if (!d) return "";
  return d.toISOString().slice(0, 10); // HTML date inputs always need YYYY-MM-DD
}

// Converts YYYY-MM-DD (internal) → DISPLAY_DATE_FORMAT (e.g. 26-Jul-04).
export function toDisplayDate(v) {
  if (!v) return '';
  const d = toDate(v);
  return d ? formatWithPattern(d, getDisplayDateFormat()) : '';
}

// Parses a user-typed display-format string back to YYYY-MM-DD.
// Handles: "26-Jul-04", "26Jul04", "260704", "20260704"
export function parseDisplayDate(raw) {
  if (!raw) return null;
  // Strip non-alphanumeric, uppercase the month letters
  const s = raw.replace(/[^a-zA-Z0-9]/g, '').toUpperCase();
  if (!s) return null;

  const displayFormat = getDisplayDateFormat();

  // Build a token list from the display format pattern (e.g. ['YY','MMM','DD'])
  const tokens = [];
  let i = 0;
  while (i < displayFormat.length) {
    if (displayFormat[i] === 'Y') {
      if (displayFormat.startsWith('YYYY', i)) { tokens.push('YYYY'); i += 4; }
      else { tokens.push('YY'); i += 2; }
    } else if (displayFormat[i] === 'M') {
      if (displayFormat.startsWith('MMMM', i)) { tokens.push('MMMM'); i += 4; }
      else if (displayFormat.startsWith('MMM', i)) { tokens.push('MMM'); i += 3; }
      else { tokens.push('MM'); i += 2; }
    } else if (displayFormat[i] === 'D') {
      tokens.push('DD'); i += 2;
    } else {
      i++;
    }
  }

  let year = null, month = null, day = null;

  // Case 1: all-numeric input (e.g. "260704" or "20260704")
  if (/^\d+$/.test(s)) {
    if (s.length === 6) {
      // YY MM DD
      const yy = parseInt(s.slice(0, 2), 10);
      year = 2000 + yy;
      month = parseInt(s.slice(2, 4), 10);
      day = parseInt(s.slice(4, 6), 10);
    } else if (s.length === 8) {
      // YYYY MM DD
      year = parseInt(s.slice(0, 4), 10);
      month = parseInt(s.slice(4, 6), 10);
      day = parseInt(s.slice(6, 8), 10);
    }
    if (year && month && day) {
      return `${year}-${String(month).padStart(2, '0')}-${String(day).padStart(2, '0')}`;
    }
    return null;
  }

  // Case 2: mixed digits + letters — split by token lengths
  let pos = 0;
  for (const tok of tokens) {
    if (tok === 'YYYY') {
      const part = s.slice(pos, pos + 4);
      if (/^\d{4}$/.test(part)) year = parseInt(part, 10);
      pos += 4;
    } else if (tok === 'YY') {
      const part = s.slice(pos, pos + 2);
      if (/^\d{2}$/.test(part)) year = 2000 + parseInt(part, 10);
      pos += 2;
    } else if (tok === 'MMMM') {
      // Find full month name in the remaining string
      const currentPos = pos;
      const idx = MONTH_LONG.findIndex(m => s.startsWith(m.toUpperCase(), currentPos));
      if (idx >= 0) { month = idx + 1; pos += MONTH_LONG[idx].length; }
    } else if (tok === 'MMM') {
      const currentPos = pos;
      const idx = MONTH_SHORT.findIndex(m => s.startsWith(m.toUpperCase(), currentPos));
      if (idx >= 0) { month = idx + 1; pos += 3; }
      else {
        // Fallback: try 2-digit month
        const part = s.slice(pos, pos + 2);
        if (/^\d{2}$/.test(part)) { month = parseInt(part, 10); pos += 2; }
      }
    } else if (tok === 'MM') {
      const part = s.slice(pos, pos + 2);
      if (/^\d{2}$/.test(part)) month = parseInt(part, 10);
      pos += 2;
    } else if (tok === 'DD') {
      const part = s.slice(pos, pos + 2);
      if (/^\d{2}$/.test(part)) day = parseInt(part, 10);
      pos += 2;
    }
  }

  if (year && month && day) {
    return `${year}-${String(month).padStart(2, '0')}-${String(day).padStart(2, '0')}`;
  }
  return null;
}

// Normalizes date fields in a plain object using the `fields` descriptor.
// For each key in `fields` with type === 'date', the value is replaced with a
// YYYY-MM-DD string (via toDateOnly) or "" when falsy.
export default function transformDateFields(formData = {}, fields = {}) {
  // shallow clone so we don't mutate the original
  const result = { ...formData };

  Object.keys(fields || {}).forEach((key) => {
    try {
      const meta = fields[key];
      if (meta && meta.type === "date" && Object.prototype.hasOwnProperty.call(formData, key)) {
        result[key] = toDateOnly(formData[key]);
      }
      else if(meta && meta.type === "switch" && Object.prototype.hasOwnProperty.call(formData, key)) {
        const val = formData[key];
        result[key] = Boolean(val);
      }
    } catch (e) {
      // on any unexpected error, leave the original value
      // (fail-safe: do not throw)
    }
  });

  return result;
}
