import React, { useState } from 'react';
import * as SDK from 'azure-devops-extension-sdk';
import { GroupBy, GroupedRow, ReportEntry, ReportResult } from '../../models/ReportEntry';
import { exportToCsv } from '../../services/ReportService';
import { fmt, formatDate } from '../../utils/formatUtils';

interface Props {
  result: ReportResult;
  groupBy: GroupBy;
  filteredEntries: ReportEntry[];
}

function workItemUrl(entry: ReportEntry): string {
  try {
    const host = SDK.getHost();
    return `https://dev.azure.com/${host.name}/${encodeURIComponent(entry.project)}/_workitems/edit/${entry.workItemId}`;
  } catch {
    return '#';
  }
}

function DrillDown({ entries }: { entries: ReportEntry[] }) {
  // ⚡ Bolt: Memoize sort operation to prevent re-sorting on every render
  const sorted = React.useMemo(
    () => [...entries].sort((a, b) => a.date.localeCompare(b.date)),
    [entries]
  );
  return (
    <tr className="drill-row">
      <td colSpan={100}>
        <table className="drill-table">
          <colgroup>
            <col style={{ width: 88 }} />
            <col style={{ width: '22%' }} />
            <col style={{ width: 100 }} />
            <col style={{ width: 110 }} />
            <col style={{ width: 130 }} />
            <col style={{ width: 110 }} />
            <col style={{ width: 60 }} />
            <col />
          </colgroup>
          <thead>
            <tr>
              <th>Date</th>
              <th>Work Item</th>
              <th>Project</th>
              <th>Cost Centre</th>
              <th>User</th>
              <th>Task Type</th>
              <th>Hours</th>
              <th>Notes</th>
            </tr>
          </thead>
          <tbody>
            {sorted.map(e => (
              <tr key={e.id}>
                <td className="cell-date">{formatDate(e.date)}</td>
                <td>
                  <a href={workItemUrl(e)} target="_top" rel="noreferrer" className="wi-link">
                    #{e.workItemId} {e.workItemTitle}
                  </a>
                </td>
                <td>{e.project}</td>
                <td>{e.costCenter || <span className="muted">—</span>}</td>
                <td>{e.createdBy}</td>
                <td>
                  {e.taskType
                    ? <span className="task-type-badge">{e.taskType}</span>
                    : <span className="muted">Unspecified</span>
                  }
                </td>
                <td className="cell-hours">{fmt(e.hours)}</td>
                <td className="cell-notes">{e.notes || <span className="muted">—</span>}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </td>
    </tr>
  );
}

export function ReportTable({ result, groupBy, filteredEntries }: Props) {
  const [expandedKeys, setExpandedKeys] = useState<Set<string>>(new Set());

  function toggleRow(key: string) {
    setExpandedKeys(prev => {
      const next = new Set(prev);
      next.has(key) ? next.delete(key) : next.add(key);
      return next;
    });
  }

  function handlePrint() {
    const allKeys = new Set(rows.map(r => r.key));
    const prevExpanded = expandedKeys;

    // Expand all rows so drill-downs are in the DOM before printing
    setExpandedKeys(allKeys);

    // Wait two animation frames for React to render the expanded rows
    requestAnimationFrame(() => {
      requestAnimationFrame(() => {
        window.print();
      });
    });

    // Restore expanded state after the print dialog closes
    const restore = () => {
      setExpandedKeys(prevExpanded);
      window.removeEventListener('afterprint', restore);
    };
    window.addEventListener('afterprint', restore);
  }

  const { rows, taskTypeColumns, grandTotal } = result;

  if (rows.length === 0) {
    return <p className="empty-state">No entries match the selected filters.</p>;
  }

  const grandByType: Record<string, number> = {};
  for (const row of rows) {
    for (const [type, h] of Object.entries(row.hoursByType)) {
      grandByType[type] = (grandByType[type] ?? 0) + h;
    }
  }

  return (
    <div className="report-table-wrap">
      <div className="report-table-toolbar">
        <button
          className="btn btn-secondary"
          onClick={handlePrint}
        >
          ⎙ Print
        </button>
        <button
          className="btn btn-secondary"
          onClick={() => exportToCsv(filteredEntries, groupBy)}
        >
          ↓ Export CSV
        </button>
      </div>

      <table className="entry-table report-table">
        <thead>
          <tr>
            <th className="col-expand"></th>
            <th>{groupBy === 'user' ? 'User' : groupBy === 'project' ? 'Project' : groupBy === 'date' ? 'Date' : groupBy === 'category' ? 'Category' : 'Cost Centre'}</th>
            {taskTypeColumns.map(t => <th key={t} className="col-hours">{t}</th>)}
            <th className="col-hours col-total">Total</th>
          </tr>
        </thead>
        <tbody>
          {rows.map(row => {
            const expanded = expandedKeys.has(row.key);
            return (
              <React.Fragment key={row.key}>
                <tr
                  className={`report-row ${expanded ? 'report-row--expanded' : ''}`}
                  onClick={() => toggleRow(row.key)}
                  style={{ cursor: 'pointer' }}
                >
                  <td className="col-expand">{expanded ? '▼' : '▶'}</td>
                  <td className="col-label">{row.label}</td>
                  {taskTypeColumns.map(t => (
                    <td key={t} className="col-hours">{fmt(row.hoursByType[t] ?? 0)}</td>
                  ))}
                  <td className="col-hours col-total"><strong>{fmt(row.total)}</strong></td>
                </tr>
                {expanded && <DrillDown entries={row.entries} />}
              </React.Fragment>
            );
          })}
        </tbody>
        <tfoot>
          <tr className="report-footer">
            <td></td>
            <td><strong>Grand Total</strong></td>
            {taskTypeColumns.map(t => (
              <td key={t} className="col-hours"><strong>{fmt(grandByType[t] ?? 0)}</strong></td>
            ))}
            <td className="col-hours col-total"><strong>{fmt(grandTotal)}</strong></td>
          </tr>
        </tfoot>
      </table>
    </div>
  );
}
