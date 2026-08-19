import React from 'react';
import { TimeEntry } from '../models/TimeEntry';
import { formatDate } from '../utils/formatUtils';

interface Props {
  entries: TimeEntry[];
  currentUserId: string;
  onEdit: (entry: TimeEntry) => void;
  onDelete: (entry: TimeEntry) => void;
}

export function TimeEntryTable({ entries, currentUserId, onEdit, onDelete }: Props) {
  const total = entries.reduce((sum, e) => sum + e.hours, 0);

  if (entries.length === 0) {
    return <p className="empty-state">No time logged yet.</p>;
  }

  return (
    <table className="entry-table">
      <thead>
        <tr>
          <th>Date</th>
          <th>Hours</th>
          <th>Task Type</th>
          <th>Notes</th>
          <th>Logged by</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        {entries.map(entry => {
          const isOwn = entry.createdById === currentUserId;
          return (
            <tr key={entry.id} className={isOwn ? 'row-own' : ''}>
              <td className="cell-date">{formatDate(entry.date)}</td>
              <td className="cell-hours">{entry.hours}h</td>
              <td className="cell-type">
                {entry.taskType
                  ? <span className="task-type-badge">{entry.taskType}</span>
                  : <span className="muted">—</span>
                }
              </td>
              <td className="cell-notes">{entry.notes || <span className="muted">—</span>}</td>
              <td className="cell-user">{entry.createdBy}</td>
              <td className="cell-actions">
                {isOwn && (
                  <>
                    <button
                      className="action-btn"
                      onClick={() => onEdit(entry)}
                      aria-label={`Edit entry from ${entry.date}`}
                    >
                      Edit
                    </button>
                    <button
                      className="action-btn action-btn--danger"
                      onClick={() => onDelete(entry)}
                      aria-label={`Delete entry from ${entry.date}`}
                    >
                      Delete
                    </button>
                  </>
                )}
              </td>
            </tr>
          );
        })}
      </tbody>
      <tfoot>
        <tr>
          <td colSpan={2} className="cell-total">
            <strong>Total: {Number.isInteger(total) ? total : total.toFixed(2)}h</strong>
          </td>
          <td colSpan={4}></td>
        </tr>
      </tfoot>
    </table>
  );
}
