import React, { useState, useEffect, useMemo } from 'react';
import { loadRawEntries, loadOrgMembers, getDistinctOptions } from '../../services/ReportService';
import { ReportEntry } from '../../models/ReportEntry';
import { fmt } from '../../utils/formatUtils';
import { currentMonthRange, localDateStr } from '../../utils/dateUtils';

interface UserUtilization {
  user: string;
  actualUtilization: number;
}

type SortKey = 'user' | 'expected' | 'actual' | 'pct';
type SortDir = 'asc' | 'desc';

function SortIcon({ active, dir }: { active: boolean; dir: SortDir }) {
  if (!active) return <span style={{ opacity: 0.3, marginLeft: 4 }}>↕</span>;
  return <span style={{ marginLeft: 4 }}>{dir === 'asc' ? '▲' : '▼'}</span>;
}

export function UserUtilizationReport() {
  const [dateFrom, setDateFrom] = useState<string>(currentMonthRange().dateFrom);
  const [dateTo, setDateTo] = useState<string>(currentMonthRange().dateTo);
  const [monthlyExpectedTime, setMonthlyExpectedTime] = useState<number>(160);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string>('');
  const [utilizationData, setUtilizationData] = useState<UserUtilization[]>([]);
  const [allEntries, setAllEntries] = useState<ReportEntry[]>([]);
  const [orgMembers, setOrgMembers] = useState<string[]>([]);

  const [sortKey, setSortKey] = useState<SortKey>('user');
  const [sortDir, setSortDir] = useState<SortDir>('asc');

  useEffect(() => {
    setLoading(true);
    Promise.all([loadRawEntries(), loadOrgMembers()])
      .then(([entries, members]) => {
        setAllEntries(entries);
        setOrgMembers(members);
        setLoading(false);
      })
      .catch(e => {
        setError(e?.message ?? 'Failed to load time entries.');
        setLoading(false);
      });
  }, []);

  useEffect(() => {
    if (loading) return;

    // Prefer org members (all project users); fall back to users found in entries
    const entryUsers = getDistinctOptions(allEntries).users.map(u => u.name);
    const allUsers = orgMembers.length > 0
      ? [...new Set([...orgMembers, ...entryUsers])].sort((a, b) => a.localeCompare(b))
      : entryUsers;

    // Hours per user within the selected date range
    const filtered = allEntries.filter(e => e.date >= dateFrom && e.date <= dateTo);
    const userHoursMap = new Map<string, number>();
    for (const e of filtered) {
      userHoursMap.set(e.createdBy, (userHoursMap.get(e.createdBy) ?? 0) + e.hours);
    }

    // Every known user gets a row, 0h if no entries in range
    const data: UserUtilization[] = allUsers.map(user => ({
      user,
      actualUtilization: userHoursMap.get(user) ?? 0,
    }));

    setUtilizationData(data);
  }, [allEntries, orgMembers, dateFrom, dateTo, loading]);

  function handleSortClick(key: SortKey) {
    if (sortKey === key) {
      setSortDir(d => d === 'asc' ? 'desc' : 'asc');
    } else {
      setSortKey(key);
      setSortDir('asc');
    }
  }

  const sortedData = useMemo(() => {
    return [...utilizationData].sort((a, b) => {
      let diff: number;
      if (sortKey === 'user') {
        diff = a.user.localeCompare(b.user);
      } else if (sortKey === 'actual') {
        diff = a.actualUtilization - b.actualUtilization;
      } else if (sortKey === 'pct') {
        const aPct = monthlyExpectedTime > 0 ? a.actualUtilization / monthlyExpectedTime : 0;
        const bPct = monthlyExpectedTime > 0 ? b.actualUtilization / monthlyExpectedTime : 0;
        diff = aPct - bPct;
      } else {
        // expected is same for all users — fall back to user name
        diff = a.user.localeCompare(b.user);
      }
      return sortDir === 'asc' ? diff : -diff;
    });
  }, [utilizationData, sortKey, sortDir, monthlyExpectedTime]);

  function handlePrint() {
    window.print();
  }

  function handleExportCsv() {
    const exportRows = [...utilizationData].sort((a, b) => a.user.localeCompare(b.user));
    const rows = [
      ['User', 'Monthly Expected Time', 'Actual Utilization', 'Percentage']
    ];
    for (const row of exportRows) {
      const percentage = monthlyExpectedTime > 0
        ? ((row.actualUtilization / monthlyExpectedTime) * 100).toFixed(2)
        : '0.00';
      rows.push([row.user, String(monthlyExpectedTime), row.actualUtilization.toFixed(2), `${percentage}%`]);
    }

    const csvContent = rows.map(r => r.map(c => `"${c.replace(/"/g, '""')}"`).join(',')).join('\n');
    const blob = new Blob([csvContent], { type: 'text/csv;charset=utf-8;' });
    const url = URL.createObjectURL(blob);
    const link = document.createElement('a');
    link.href = url;
    link.setAttribute('download', `user_utilization_${dateFrom}_${dateTo}.csv`);
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
    URL.revokeObjectURL(url);
  }

  const grandTotalActual = sortedData.reduce((s, r) => s + r.actualUtilization, 0);
  const grandTotalExpected = monthlyExpectedTime * sortedData.length;
  const grandPct = grandTotalExpected > 0
    ? ((grandTotalActual / grandTotalExpected) * 100).toFixed(2)
    : '0.00';

  const thStyle: React.CSSProperties = { cursor: 'pointer', userSelect: 'none', whiteSpace: 'nowrap' };

  return (
    <div className="report-root">
      <div className="report-header">
        <h2 className="report-title">User Utilization Report</h2>
      </div>

      {error && <div className="error-banner" role="alert">{error}</div>}

      <div className="filter-bar">
        <div className="filter-bar-row">
          <div className="filter-field">
            <label className="filter-label" htmlFor="util-date-from">From</label>
            <input
              id="util-date-from"
              type="date"
              className="filter-input"
              value={dateFrom}
              onChange={e => setDateFrom(e.target.value)}
              disabled={loading}
            />
          </div>
          <div className="filter-field">
            <label className="filter-label" htmlFor="util-date-to">To</label>
            <input
              id="util-date-to"
              type="date"
              className="filter-input"
              value={dateTo}
              onChange={e => setDateTo(e.target.value)}
              disabled={loading}
            />
          </div>
          <div className="filter-field">
            <label className="filter-label" htmlFor="expected-time">Monthly Expected Time (Hours)</label>
            <input
              id="expected-time"
              type="number"
              className="filter-input"
              value={monthlyExpectedTime}
              onChange={e => setMonthlyExpectedTime(Number(e.target.value))}
              min="0"
              disabled={loading}
            />
          </div>
        </div>
      </div>

      {loading ? (
        <div className="loading-state">Loading time entries…</div>
      ) : (
        <div className="report-table-wrap">
          <div className="report-table-toolbar">
            <button className="btn btn-secondary" onClick={handlePrint}>
              ⎙ Print
            </button>
            <button className="btn btn-secondary" onClick={handleExportCsv}>
              ↓ Export CSV
            </button>
          </div>
          <table className="entry-table report-table">
            <thead>
              <tr>
                <th className="col-label" style={thStyle} onClick={() => handleSortClick('user')}>
                  User <SortIcon active={sortKey === 'user'} dir={sortDir} />
                </th>
                <th className="col-hours" style={thStyle} onClick={() => handleSortClick('expected')}>
                  Monthly Expected Time <SortIcon active={sortKey === 'expected'} dir={sortDir} />
                </th>
                <th className="col-hours" style={thStyle} onClick={() => handleSortClick('actual')}>
                  Actual Utilization <SortIcon active={sortKey === 'actual'} dir={sortDir} />
                </th>
                <th className="col-hours col-total" style={thStyle} onClick={() => handleSortClick('pct')}>
                  Percentage <SortIcon active={sortKey === 'pct'} dir={sortDir} />
                </th>
              </tr>
            </thead>
            <tbody>
              {sortedData.length === 0 ? (
                <tr>
                  <td colSpan={4} className="empty-cell">No users found.</td>
                </tr>
              ) : (
                sortedData.map(row => {
                  const pct = monthlyExpectedTime > 0
                    ? ((row.actualUtilization / monthlyExpectedTime) * 100).toFixed(2)
                    : '0.00';
                  return (
                    <tr key={row.user} className="report-row">
                      <td className="col-label">{row.user}</td>
                      <td className="col-hours">{fmt(monthlyExpectedTime)}</td>
                      <td className="col-hours">{fmt(row.actualUtilization)}</td>
                      <td className="col-hours col-total">{pct}%</td>
                    </tr>
                  );
                })
              )}
            </tbody>
            <tfoot>
              <tr className="report-footer">
                <td><strong>Grand Total</strong></td>
                <td className="col-hours"><strong>{fmt(grandTotalExpected)}</strong></td>
                <td className="col-hours"><strong>{fmt(grandTotalActual)}</strong></td>
                <td className="col-hours col-total"><strong>{grandPct}%</strong></td>
              </tr>
            </tfoot>
          </table>
        </div>
      )}
    </div>
  );
}
