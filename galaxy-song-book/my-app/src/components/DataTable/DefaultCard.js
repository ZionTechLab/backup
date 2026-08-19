import { useState, Fragment } from 'react';
import { formatColumnValue } from './formatColumnValue';
import { IdCell } from './IdCell';

// A column produces card output when it has a field, a custom renderer, or an id.
const isDataCol = (c) => !c.isAction && (c.field !== undefined || c.render || c.cardRender || c.isId);

// A data cell counts as blank when its raw value is empty. Custom-rendered
// cells (render/cardRender/isId/type) always show, since their output is not a plain value.
const cardValueIsBlank = (col, row) => {
  if (col.render || col.cardRender || col.isId || col.type) return false;
  const v = row[col.field];
  return v === null || v === undefined || (typeof v === 'string' && v.trim() === '');
};

// Cards may override the table renderer via col.cardRender, e.g. show a full
// value in the card where the table shows a compressed one. Id columns expand
// to the full value automatically.
const cardCellValue = (col, row) => {
  if (col.cardRender) return col.cardRender(row);
  if (col.isId) return <IdCell id={row[col.field]} full />;
  return formatColumnValue(col, row);
};

// Split columns into card zones. cardRole on a column places it in the header
// (title/subtitle/badge/amount) or the meta strip; unflagged columns stay as
// body label/value rows. cardHide drops a column from the card entirely.
// With no cardRole/cardHide anywhere, every column lands in body — identical to
// the original flat card, so existing screens are unaffected.
const partition = (columns) => {
  const head = { title: null, subtitle: null, badge: null, amount: null };
  const body = [];
  const meta = [];
  const actions = [];

  for (const col of columns) {
    if (col.isAction) { actions.push(col); continue; }
    if (col.cardHide) continue;
    if (!isDataCol(col)) continue;
    switch (col.cardRole) {
      case 'title': head.title = col; break;
      case 'subtitle': head.subtitle = col; break;
      case 'badge': head.badge = col; break;
      case 'amount': head.amount = col; break;
      case 'meta': meta.push(col); break;
      default: body.push(col);
    }
  }
  return { head, body, meta, actions };
};

// Default mobile card. Built from the same column config as the table, so
// screens need no card markup. cardRole flags add a header (title, subtitle,
// status badge, amount) and a muted meta strip; everything else is a label/value
// body row. Blank body fields hide behind an expand toggle.
export function DefaultCard({ row, columns }) {
  const [expanded, setExpanded] = useState(false);
  const { head, body, meta, actions } = partition(columns);

  const hasHead = head.title || head.subtitle || head.badge || head.amount;
  const hiddenCount = body.filter((c) => cardValueIsBlank(c, row)).length;
  const visibleBody = expanded ? body : body.filter((c) => !cardValueIsBlank(c, row));

  return (
    <>
      {hasHead && (
        <div className="d-flex align-items-start justify-content-between gap-3 mb-3">
          {(head.title || head.subtitle) && (
            <div className="dt-card-head-main">
              {head.title && <div className="dt-card-title fw-semibold text-break">{cardCellValue(head.title, row)}</div>}
              {head.subtitle && <div className="dt-card-subtitle mt-1">{cardCellValue(head.subtitle, row)}</div>}
            </div>
          )}
          {(head.badge || head.amount) && (
            <div className="d-flex flex-column align-items-end gap-1 text-nowrap">
              {head.badge && <div className="d-inline-flex">{cardCellValue(head.badge, row)}</div>}
              {head.amount && <div className="dt-card-amount">{cardCellValue(head.amount, row)}</div>}
            </div>
          )}
        </div>
      )}

      {visibleBody.length > 0 && (
        <div>
          {visibleBody.map((col, idx) => {
            const blank = cardValueIsBlank(col, row);
            return (
              <div key={idx} className="d-flex align-items-baseline justify-content-between gap-3 border-bottom py-2 dt-card-row">
                <span className="dt-card-label text-nowrap">{col.header}</span>
                <span className={`dt-card-value text-end text-break ${col.cardClass || ''}`}>
                  {blank ? '—' : cardCellValue(col, row)}
                </span>
              </div>
            );
          })}
        </div>
      )}

      {meta.length > 0 && (
        <div className="d-flex flex-wrap gap-3 small text-secondary mt-3 pt-3 border-top">
          {meta.map((col, idx) => (
            <span key={idx} className={`d-inline-flex align-items-center gap-1 ${col.cardClass || ''}`}>
              {col.cardIcon && <i className={col.cardIcon} aria-hidden="true" />}
              {cardCellValue(col, row)}
            </span>
          ))}
        </div>
      )}

      {(actions.length > 0 || hiddenCount > 0) && (
        <div className="d-flex align-items-center gap-2 mt-3 pt-3 border-top">
          {actions.map((col, idx) => (
            <Fragment key={idx}>{formatColumnValue(col, row)}</Fragment>
          ))}
          {hiddenCount > 0 && (
            <button
              type="button"
              className="dt-card-expand"
              onClick={(e) => { e.stopPropagation(); setExpanded((v) => !v); }}
              aria-label={expanded ? 'Show less' : `Show all fields (${hiddenCount} more)`}
              title={expanded ? 'Show less' : `Show all (${hiddenCount} more)`}
            >
              <i className={`bi ${expanded ? 'bi-chevron-up' : 'bi-three-dots'}`} />
            </button>
          )}
        </div>
      )}
    </>
  );
}
