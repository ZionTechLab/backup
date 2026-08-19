// Formats a value into a currency-style numeric string with thousand separators
// and two decimal places: e.g. 12345.6 -> "12,345.60". Handles null/undefined
// and non-numeric input gracefully by returning an empty string.
function formatAmount(value) {
  if (value === null || value === undefined || value === '') return '';

  // If already a string that contains commas, remove them.
  let num = typeof value === 'string' ? value.replace(/,/g, '') : value;

  // Coerce to number
  num = Number(num);
  if (!isFinite(num)) return '';

  const negative = num < 0;
  num = Math.abs(num);

  // Ensure two decimal places, use fixed to avoid floating precision issues
  const parts = num.toFixed(2).split('.');
  const intPart = parts[0];
  const decPart = parts[1];

  // Add thousand separators to integer part
  const withCommas = intPart.replace(/\B(?=(\d{3})+(?!\d))/g, ',');

  return (negative ? '-' : '') + withCommas + '.' + decPart;
}

export default formatAmount;

// Live-editing formatter for editable amount inputs. Unlike the default export
// it does NOT force two decimals (so a user can type freely); it strips
// non-numeric characters, allows a single dot, caps to 2 decimals, and groups
// the integer part with thousands separators. Stored value stays the raw string.
export function formatAmountInput(val) {
  if (val === undefined || val === null || val === '') return '';
  let cleaned = String(val).replace(/[^\d.]/g, '');
  const parts = cleaned.split('.');
  if (parts.length > 2) cleaned = parts[0] + '.' + parts.slice(1).join('');
  if (cleaned.includes('.')) {
    const [intPart, decPart] = cleaned.split('.');
    cleaned = intPart + '.' + decPart.slice(0, 2);
  }
  cleaned = cleaned.replace(/\B(?=(\d{3})+(?!\d))/g, ',');
  return cleaned;
}
