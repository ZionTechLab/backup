import { useMemo, useState } from 'react';
import MeridianPage from '../../Meridian/MeridianPage';
import { TRANSACTIONS, CASHIERS, filterByPeriod } from './mockReportData';

// Demo-only: sample data below, not wired to live petty cash transactions yet.
export default function SummaryReport() {
  const [from, setFrom] = useState('2026-07-01');
  const [to, setTo] = useState('2026-07-12');

  const rows = useMemo(() => filterByPeriod(TRANSACTIONS, from, to), [from, to]);

  const byCashier = useMemo(() => {
    return CASHIERS.map((cashier) => {
      const cashierRows = rows.filter((r) => r.cashier === cashier).sort((a, b) => a.date.localeCompare(b.date));
      return {
        cashier,
        count: cashierRows.length,
        total: cashierRows.reduce((s, r) => s + r.amount, 0),
        firstDate: cashierRows[0]?.date,
        lastDate: cashierRows[cashierRows.length - 1]?.date,
      };
    }).filter((c) => c.count > 0);
  }, [rows]);

  const grandTotal = byCashier.reduce((s, c) => s + c.total, 0);

  return (
    <MeridianPage title="Summary Report" subtitle="Demo data — not wired to live transactions yet">
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

        <div className="table-responsive">
          <table className="table table-sm align-middle mb-0">
            <thead className="table-light">
              <tr>
                <th>Cashier</th>
                <th className="text-end">Transactions</th>
                <th>First Date</th>
                <th>Last Date</th>
                <th className="text-end">Total Amount</th>
              </tr>
            </thead>
            <tbody>
              {byCashier.map((c) => (
                <tr key={c.cashier}>
                  <td className="fw-semibold">{c.cashier}</td>
                  <td className="text-end">{c.count}</td>
                  <td>{c.firstDate}</td>
                  <td>{c.lastDate}</td>
                  <td className="text-end">{c.total.toLocaleString(undefined, { minimumFractionDigits: 2 })}</td>
                </tr>
              ))}
              {byCashier.length === 0 && (
                <tr><td colSpan={5} className="text-muted text-center py-3">No transactions in this period.</td></tr>
              )}
            </tbody>
            {byCashier.length > 0 && (
              <tfoot>
                <tr className="table-light fw-bold">
                  <td colSpan={4} className="text-end">Grand Total</td>
                  <td className="text-end">{grandTotal.toLocaleString(undefined, { minimumFractionDigits: 2 })}</td>
                </tr>
              </tfoot>
            )}
          </table>
        </div>
      </div>
    </MeridianPage>
  );
}
