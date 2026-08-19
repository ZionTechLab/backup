import { useMemo, useState } from 'react';
import MeridianPage from '../../Meridian/MeridianPage';
import SimpleBarChart from '../../../components/Charts/SimpleBarChart';
import { TRANSACTIONS, CATEGORIES, DEPARTMENTS, VENDORS, ITEM_CATEGORIES } from './mockReportData';

const PERIODS = [
  { value: 'monthly', label: 'Monthly', weeks: 4 },
  { value: 'quarterly', label: 'Quarterly', weeks: 13 },
  { value: 'half-yearly', label: 'Half-Yearly', weeks: 26 },
  { value: 'annually', label: 'Annually', weeks: 52 },
  { value: '3-years', label: '3 Years', weeks: 156 },
];

const GROUP_BY = [
  { value: 'category', label: 'Petty Cash Expense Category', field: 'category', options: CATEGORIES },
  { value: 'department', label: 'Department', field: 'department', options: DEPARTMENTS },
  { value: 'vendor', label: 'Vendor', field: 'vendor', options: VENDORS },
  { value: 'itemCategory', label: 'Item Category', field: 'itemCategory', options: ITEM_CATEGORIES },
];

// Demo-only: derives a plausible "weekly average" from the shared sample
// transaction set, scaled by the chosen period's week count — not wired to
// live petty cash transactions yet.
export default function AnalyticalReport() {
  const [period, setPeriod] = useState('monthly');
  const [groupBy, setGroupBy] = useState('category');

  const periodDef = PERIODS.find((p) => p.value === period);
  const groupDef = GROUP_BY.find((g) => g.value === groupBy);

  const chartData = useMemo(() => {
    return groupDef.options.map((label, i) => {
      const rows = TRANSACTIONS.filter((r) => r[groupDef.field] === label);
      const totalOverSample = rows.reduce((s, r) => s + r.amount, 0);
      // Sample data spans ~2 weeks; project a per-week average and hold it
      // roughly flat (with a mild per-group variance) across the chosen period.
      const perWeek = totalOverSample / 2;
      const variance = 1 + ((i % 3) - 1) * 0.08;
      return { label, value: Math.round(perWeek * variance) };
    });
  }, [groupDef]);

  return (
    <MeridianPage title="Analytical Report" subtitle="Weekly average spend — demo data, not wired to live transactions yet">
      <div className="ml-form-section">
        <div className="row g-2 mb-4">
          <div className="col-sm-4">
            <label className="form-label">Period</label>
            <select className="form-select" value={period} onChange={(e) => setPeriod(e.target.value)}>
              {PERIODS.map((p) => <option key={p.value} value={p.value}>{p.label}</option>)}
            </select>
          </div>
          <div className="col-sm-4">
            <label className="form-label">Group By</label>
            <select className="form-select" value={groupBy} onChange={(e) => setGroupBy(e.target.value)}>
              {GROUP_BY.map((g) => <option key={g.value} value={g.value}>{g.label}</option>)}
            </select>
          </div>
        </div>

        <div className="card">
          <div className="card-header">
            <h6 className="mb-0">Weekly Average by {groupDef.label} — {periodDef.label} view ({periodDef.weeks} weeks)</h6>
          </div>
          <div className="card-body">
            <SimpleBarChart data={chartData} height={260} color="#427FA8" />
          </div>
        </div>

        <div className="table-responsive mt-3">
          <table className="table table-sm mb-0">
            <thead className="table-light">
              <tr><th>{groupDef.label}</th><th className="text-end">Weekly Average</th></tr>
            </thead>
            <tbody>
              {chartData.map((d) => (
                <tr key={d.label}>
                  <td>{d.label}</td>
                  <td className="text-end">{d.value.toLocaleString(undefined, { minimumFractionDigits: 2 })}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </MeridianPage>
  );
}
