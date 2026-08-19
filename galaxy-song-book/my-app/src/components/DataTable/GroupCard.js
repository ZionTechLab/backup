import { useState } from 'react';
import { DefaultCard } from './DefaultCard';
import './GroupCard.css';

// Mobile card for a grouped table. Fully driven by the `grouping` config the
// screen already passes for the desktop table: the first groupHeaderCell is the
// card title, the rest become a summary strip, and each child row is rendered
// with DefaultCard from the same columns. Collapsible like the desktop groups.
export function GroupCard({ group, columns, grouping, defaultExpanded }) {
  const collapsible = grouping.collapsible !== false;
  const [expanded, setExpanded] = useState(defaultExpanded !== false);

  const ctx = { expanded, displayColumns: columns };
  const cells = grouping.groupHeaderCells ? (grouping.groupHeaderCells(group, ctx) || []) : [];
  const title = cells.length
    ? cells[0].content
    : (grouping.groupHeader ? grouping.groupHeader(group, ctx) : null);
  const summary = cells.slice(1);
  const children = group[grouping.childrenField] || [];
  const groupCls = grouping.groupRowClassName ? grouping.groupRowClassName(group) : '';

  return (
    <div className={`dt-group-card ${groupCls}`}>
      <div
        className={`d-flex align-items-center gap-2 ${collapsible ? 'dt-group-card-toggle' : ''}`}
        onClick={collapsible ? () => setExpanded((v) => !v) : undefined}
      >
        {collapsible && (
          <span className={`dt-group-caret ${expanded ? 'dt-group-caret-open' : ''}`} aria-hidden="true">
            {expanded ? '▾' : '▸'}
          </span>
        )}
        <span className="dt-group-card-title">{title}</span>
      </div>

      {summary.length > 0 && (
        <div className="dt-group-card-summary">
          {summary.map((c, i) => (
            <span key={i} className={c.className || ''}>{c.content}</span>
          ))}
        </div>
      )}

      {expanded && (
        <div className="d-flex flex-column gap-2 mt-2">
          {children.length ? (
            children.map((child, i) => (
              <div key={i} className="dt-group-card-child">
                <DefaultCard row={child} columns={columns} />
              </div>
            ))
          ) : (
            <div className="py-4 px-3 text-center text-muted">No items</div>
          )}
        </div>
      )}
    </div>
  );
}
