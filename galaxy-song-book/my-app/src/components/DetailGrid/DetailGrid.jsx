/**
 * DetailGrid — renders label:value pairs in a responsive grid, two pairs per row.
 *
 * Props:
 *   items       Array<{ label: string, value: ReactNode, span?: number }>
 *               Items are auto-paired: items 0&1 in row 1, items 2&3 in row 2, etc.
 *               An item with span > 1 takes a full row by itself.
 *   cols        Columns per row on md+ (default 4, so each slot = col-md-3).
 *               Two-pair row: label|value|label|value (each 1 slot).
 *               Full-span row: label(1)|value(span).
 *   className   Extra classes on the wrapper.
 */
export default function DetailGrid({ items = [], cols = 4, className = '' }) {
  if (!items.length) return null;

  const slotClass = `col-6 col-md-${12 / cols}`;

  // Group items into rows: pair items unless an item has span > 1 (then solo row)
  const rows = [];
  let i = 0;
  while (i < items.length) {
    const item = items[i];
    if ((item.span || 1) > 1) {
      rows.push([item]);
      i++;
    } else if (i + 1 < items.length && (items[i + 1].span || 1) <= 1) {
      rows.push([items[i], items[i + 1]]);
      i += 2;
    } else {
      rows.push([items[i]]);
      i++;
    }
  }

  return (
    <div className={`d-grid gap-2 ${className}`}>
      {rows.map((row, ri) => (
        <div className="row g-2" key={ri}>
          {row.map((item, ci) => {
            const span = item.span || 1;
            if (span > 1) {
              // Full-row item: label in 1 slot, value in remaining slots
              return (
                <>
                  <div className={`${slotClass} text-muted small`}>{item.label}</div>
                  <div className={`col-6 col-md-${(12 / cols) * span}`}>{item.value}</div>
                </>
              );
            }
            // Normal pair item
            return (
              <>
                <div className={`${slotClass} text-muted small`}>{item.label}</div>
                <div className={slotClass}>{item.value}</div>
              </>
            );
          })}
        </div>
      ))}
    </div>
  );
}
