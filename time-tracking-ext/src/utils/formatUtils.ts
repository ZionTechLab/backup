export function fmt(h: number): string {
  if (h === 0) return '—';
  return `${Number.isInteger(h) ? h : h.toFixed(2)}h`;
}

export function formatDate(iso: string): string {
  const [y, m, d] = iso.split('-');
  return `${d}/${m}/${y}`;
}
