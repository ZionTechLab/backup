import { Link } from "react-router-dom";
import "../Meridian/meridian-screens.css";
import "../auth/meridian-login.css";
import "./Dashboard.css";

const KPIS = [
  { label: "Group Revenue (YTD)", currency: "USD", value: "29,836,038", delta: "+12.4%", deltaTone: "pos", deltaLabel: "vs PY" },
  { label: "Group Expenses",      currency: "USD", value: "19,739,136", delta: "+8.1%",  deltaTone: "pos", deltaLabel: "vs PY" },
  { label: "Net Profit",          currency: "USD", value: "10,096,902", delta: "+18.6%", deltaTone: "pos", deltaLabel: "vs PY", highlight: true },
  { label: "Cash & Equivalents",  currency: "USD", value: "7,263,978",  delta: "-2.3%",  deltaTone: "neg", deltaLabel: "vs PM" },
];

const SUBSIDIARIES = [
  { code: "MER-US", name: "Galaxy US, Inc.",         country: "United States",  fx: "USD", revenue: 14820400, npLocal: 5680200, npUsd: 5680200, status: "open" },
  { code: "MER-UK", name: "Galaxy UK Ltd.",          country: "United Kingdom", fx: "GBP", revenue: 6340000,  npLocal: 2220000, npUsd: 2826282, status: "open" },
  { code: "MER-DE", name: "Galaxy Deutschland GmbH", country: "Germany",        fx: "EUR", revenue: 4280000,  npLocal: 1140000, npUsd: 1235988, status: "open" },
  { code: "MER-SG", name: "Galaxy Singapore Pte Ltd", country: "Singapore",     fx: "SGD", revenue: 3120000,  npLocal: 480000,  npUsd: 354432,  status: "locked" },
];

const FX_RATES = [
  { pair: "EUR → USD", rate: "1.0842", mtd: "+0.47%", tone: "pos" },
  { pair: "GBP → USD", rate: "1.2731", mtd: "+1.41%", tone: "pos" },
  { pair: "SGD → USD", rate: "0.7384", mtd: "+0.86%", tone: "pos" },
];

const PNL_SERIES = [
  { m: "Jun", r: 2120, e: 1410 }, { m: "Jul", r: 2340, e: 1520 },
  { m: "Aug", r: 2510, e: 1620 }, { m: "Sep", r: 2280, e: 1490 },
  { m: "Oct", r: 2640, e: 1700 }, { m: "Nov", r: 2580, e: 1660 },
  { m: "Dec", r: 2880, e: 1810 }, { m: "Jan", r: 2160, e: 1450 },
  { m: "Feb", r: 2380, e: 1540 }, { m: "Mar", r: 2620, e: 1690 },
  { m: "Apr", r: 2740, e: 1760 }, { m: "May", r: 2890, e: 1820 },
];

const REPORTS = [
  { label: "Consolidated P&L",         meta: "May 2026 YTD",      to: "/group/pnl" },
  { label: "Consolidated Balance Sheet", meta: "As of 2026-05-31", to: "/reports/balance-sheet" },
  { label: "Elimination Report",        meta: "4 entries",         to: "/group/eliminations" },
  { label: "FX Variance Report",        meta: "CTA: $(180,400)",   to: "/group/fx-variance" },
];

function fmtAmount(n) {
  return n.toLocaleString("en-US", { minimumFractionDigits: 0 });
}

function ConsolidatedBars({ data, height = 220 }) {
  const padX = 16;
  const padTop = 12;
  const padBottom = 28;
  const width = 760;
  const innerW = width - padX * 2;
  const innerH = height - padTop - padBottom;
  const max = data.reduce((acc, d) => Math.max(acc, d.r, d.e), 1);
  const slot = innerW / data.length;
  const barW = Math.max((slot - 12) / 2, 4);

  return (
    <svg width="100%" viewBox={`0 0 ${width} ${height}`} preserveAspectRatio="xMidYMid meet">
      <g transform={`translate(${padX},${padTop})`}>
        {data.map((d, i) => {
          const cx = i * slot + slot / 2;
          const rH = (d.r / max) * innerH;
          const eH = (d.e / max) * innerH;
          return (
            <g key={d.m}>
              <rect x={cx - barW - 1} y={innerH - rH} width={barW} height={rH} rx={2} fill="#4f7cff" />
              <rect x={cx + 1}        y={innerH - eH} width={barW} height={eH} rx={2} fill="#4f7cff" opacity={0.35} />
              <text x={cx} y={innerH + 18} fontSize={11} textAnchor="middle" fill="currentColor" opacity={0.65}>{d.m}</text>
            </g>
          );
        })}
      </g>
    </svg>
  );
}

const Dashboard = () => {
  return (
    <div className="ml-screen mh-screen p-4">
      <div className="ml-page-header">
        <div className="ml-page-header-left">
          <h1 className="ml-page-title">Galaxy</h1>
          <p className="ml-page-subtitle">Group dashboard · 4 companies · Reporting in USD</p>
        </div>
        <div className="ml-page-actions">
          <button className="ml-btn-ghost">
            <i className="bi bi-download" aria-hidden="true" /> Export
          </button>
          <Link to="/group/pnl" className="ml-btn-action">
            <i className="bi bi-plus-lg" aria-hidden="true" /> Consolidated P&amp;L
          </Link>
        </div>
      </div>

      <div className="mh-kpi-grid">
        {KPIS.map(k => (
          <div key={k.label} className={`mh-kpi${k.highlight ? " mh-kpi-active" : ""}`}>
            <div className="mh-kpi-label">{k.label}</div>
            <div className="mh-kpi-value">
              <span className="mh-kpi-ccy">{k.currency}</span>
              <span className="mh-kpi-amount">{k.value}</span>
            </div>
            <div className={`mh-kpi-delta mh-kpi-delta-${k.deltaTone}`}>
              <span className="mh-kpi-arrow">{k.deltaTone === "pos" ? "↑" : "↓"}</span>
              {k.delta.replace(/^[+-]/, "")} <span className="mh-kpi-delta-label">{k.deltaLabel}</span>
            </div>
          </div>
        ))}
      </div>

      <div className="mh-body-grid">
        <div className="mh-main-col">
          <div className="mh-card">
            <div className="mh-card-head">
              <span className="mh-card-title">Subsidiaries</span>
              <Link to="/settings/companies" className="ml-btn-ghost-sm">Manage</Link>
            </div>
            <table className="mh-table">
              <thead>
                <tr>
                  <th>Company</th>
                  <th>Country</th>
                  <th>FX</th>
                  <th className="text-end">Revenue (Local)</th>
                  <th className="text-end">Net Profit (Local)</th>
                  <th className="text-end">Net Profit (USD)</th>
                  <th>Status</th>
                </tr>
              </thead>
              <tbody>
                {SUBSIDIARIES.map(s => (
                  <tr key={s.code}>
                    <td>
                      <div className="mh-co-name">{s.name}</div>
                      <div className="mh-co-code">{s.code}</div>
                    </td>
                    <td className="mh-dim">{s.country}</td>
                    <td><span className="ml-acct-chip">{s.fx}</span></td>
                    <td className="text-end mh-mono">{fmtAmount(s.revenue)}</td>
                    <td className="text-end mh-mono">{fmtAmount(s.npLocal)}</td>
                    <td className="text-end mh-mono mh-strong">$ {fmtAmount(s.npUsd)}</td>
                    <td>
                      <span className={`ml-badge ml-badge-${s.status}`}>{s.status}</span>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>

          <div className="mh-card mh-card-pad">
            <div className="mh-card-head">
              <span className="mh-card-title">Consolidated P&amp;L — Last 12 months</span>
              <span className="mh-card-meta">USD thousands</span>
            </div>
            <ConsolidatedBars data={PNL_SERIES} />
            <div className="mh-legend">
              <span className="mh-legend-item"><i className="mh-swatch mh-swatch-rev" /> Revenue</span>
              <span className="mh-legend-item"><i className="mh-swatch mh-swatch-exp" /> Expenses</span>
            </div>
          </div>
        </div>

        <div className="mh-side-col">
          <div className="mh-card mh-card-pad">
            <div className="mh-card-head">
              <span className="mh-card-title">FX Rates</span>
              <button className="ml-btn-ghost-sm">Update</button>
            </div>
            <div className="mh-fx-grid">
              {FX_RATES.map(fx => (
                <div key={fx.pair} className="mh-fx-cell">
                  <div className="mh-fx-pair">{fx.pair}</div>
                  <div className="mh-fx-rate">{fx.rate}</div>
                  <div className={`mh-fx-mtd mh-fx-mtd-${fx.tone}`}>{fx.mtd} MTD</div>
                </div>
              ))}
            </div>
            <div className="mh-fx-foot">Last updated 2026-05-22 09:14 by david.park</div>
          </div>

          <div className="mh-card mh-card-pad">
            <div className="mh-card-head">
              <span className="mh-card-title">Group Reports</span>
            </div>
            <ul className="mh-report-list">
              {REPORTS.map(r => (
                <li key={r.label}>
                  <Link to={r.to} className="mh-report-link">
                    <span className="mh-report-chev">›</span>
                    <span className="mh-report-label">{r.label}</span>
                    <span className="mh-report-meta">{r.meta}</span>
                  </Link>
                </li>
              ))}
            </ul>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Dashboard;
