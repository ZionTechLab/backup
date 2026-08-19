import { useMemo, useState } from 'react';
import MeridianPage from '../../Meridian/MeridianPage';
import { TRANSACTIONS, CASHIERS, filterByPeriod } from './mockReportData';

// Demo-only: sample data below, not wired to live petty cash transactions yet.
// Same grouping/period logic as SummaryReport — its cashier subtotals must
// match this page's for the same date range.
export default function DetailedReport() {
  const [from, setFrom] = useState('2026-07-01');
  const [to, setTo] = useState('2026-07-12');

  const rows = useMemo(() => filterByPeriod(TRANSACTIONS, from, to), [from, to]);

  const groups = useMemo(() => {
    return CASHIERS.map((cashier) => {
      const cashierRows = rows.filter((r) => r.cashier === cashier).sort((a, b) => a.date.localeCompare(b.date));
      return { cashier, rows: cashierRows, subtotal: cashierRows.reduce((s, r) => s + r.amount, 0) };
    }).filter((g) => g.rows.length > 0);
  }, [rows]);

  const grandTotal = groups.reduce((s, g) => s + g.subtotal, 0);

  return (
    <MeridianPage title="Detailed Report" subtitle="Demo data — not wired to live transactions yet">
      <div className="ml-form-section">
        <div className="row g-2 mb-3">
          <div className="col-sm-3">
            <label className="form-label">From</label>
            <input type="date" className="form-control" value={from} onChange={(e) => setFrom(e.target.value)} />
          </div>
          <div className="col-sm-3">
            <label className="form-label">To</label>
            <input type="date" className="form-control" value={to} onChange={(e) => setTo(e.target.value)} />
          </div>
        </div>

        {groups.map((g) => (
          <div key={g.cashier} className="mb-4">
            <h6 className="mb-2">{g.cashier}</h6>
            <div className="table-responsive">
              <table className="table table-sm align-middle mb-0">
                <thead className="table-light">
                  <tr>
                    <th>Date</th>
                    <th>Category</th>
                    <th>Department</th>
                    <th>Description</th>
                    <th className="text-end">Amount</th>
                  </tr>
                </thead>
                <tbody>
                  {g.rows.map((r, i) => (
                    <tr key={i}>
                      <td className="text-nowrap">{r.date}</td>
                      <td>{r.category}</td>
                      <td>{r.department}</td>
                      <td>{r.description}</td>
                      <td className="text-end">{r.amount.toLocaleString(undefined, { minimumFractionDigits: 2 })}</td>
                    </tr>
                  ))}
                </tbody>
                <tfoot>
                  <tr className="table-light fw-semibold">
                    <td colSpan={4} className="text-end">Subtotal — {g.cashier}</td>
                    <td className="text-end">{g.subtotal.toLocaleString(undefined, { minimumFractionDigits: 2 })}</td>
                  </tr>
                </tfoot>
              </table>
            </div>
          </div>
        ))}

        {groups.length === 0 ? (
          <div className="text-muted text-center py-3">No transactions in this period.</div>
        ) : (
          <div className="d-flex justify-content-end">
            <div className="fw-bold fs-5">
              Grand Total: {grandTotal.toLocaleString(undefined, { minimumFractionDigits: 2 })}
            </div>
          </div>
        )}
      </div>
    </MeridianPage>
  );
}
