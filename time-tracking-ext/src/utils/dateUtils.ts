export function localDateStr(d: Date): string {
  const y = d.getFullYear();
  const m = String(d.getMonth() + 1).padStart(2, '0');
  const day = String(d.getDate()).padStart(2, '0');
  return `${y}-${m}-${day}`;
}

export function currentMonthRange(): { dateFrom: string; dateTo: string } {
  const now = new Date();
  const dateFrom = localDateStr(new Date(now.getFullYear(), now.getMonth(), 1));
  const dateTo = localDateStr(new Date(now.getFullYear(), now.getMonth() + 1, 0));
  return { dateFrom, dateTo };
}
