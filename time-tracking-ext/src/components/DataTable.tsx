import React, { useState } from 'react';

export interface Column<T> {
  header: string;
  key?: keyof T;
  render?: (row: T, index: number) => React.ReactNode;
  className?: string;
  sortable?: boolean;
}

interface Props<T> {
  columns: Column<T>[];
  data: T[];
  emptyMessage?: string;
  className?: string;
}

type SortDir = 'asc' | 'desc';

export function DataTable<T>({ columns, data, emptyMessage = 'No data.', className = 'roles-table' }: Props<T>) {
  const [sortKey, setSortKey] = useState<keyof T | null>(null);
  const [sortDir, setSortDir] = useState<SortDir>('asc');

  function handleSort(col: Column<T>) {
    if (!col.sortable || !col.key) return;
    if (sortKey === col.key) {
      setSortDir(d => d === 'asc' ? 'desc' : 'asc');
    } else {
      setSortKey(col.key);
      setSortDir('asc');
    }
  }

  const sortedData = sortKey
    ? [...data].sort((a, b) => {
        const av = String(a[sortKey] ?? '');
        const bv = String(b[sortKey] ?? '');
        return sortDir === 'asc' ? av.localeCompare(bv) : bv.localeCompare(av);
      })
    : data;

  return (
    <div className="table-responsive">
      <table className={className}>
        <thead>
          <tr>
            {columns.map((col, i) => (
              <th
                key={i}
                className={col.className}
                onClick={() => handleSort(col)}
                style={col.sortable ? { cursor: 'pointer', userSelect: 'none' } : undefined}
              >
                {col.header}
                {col.sortable && col.key && (
                  <span className="sort-indicator">
                    {sortKey === col.key ? (sortDir === 'asc' ? ' ↑' : ' ↓') : ' ↕'}
                  </span>
                )}
              </th>
            ))}
          </tr>
        </thead>
        <tbody>
          {sortedData.length === 0 ? (
            <tr>
              <td colSpan={columns.length} className="task-type-empty">{emptyMessage}</td>
            </tr>
          ) : (
            sortedData.map((row, i) => (
              <tr key={i}>
                {columns.map((col, j) => (
                  <td key={j} className={col.className}>
                    {col.render
                      ? col.render(row, i)
                      : col.key != null
                        ? String(row[col.key] ?? '')
                        : null}
                  </td>
                ))}
              </tr>
            ))
          )}
        </tbody>
      </table>
    </div>
  );
}
