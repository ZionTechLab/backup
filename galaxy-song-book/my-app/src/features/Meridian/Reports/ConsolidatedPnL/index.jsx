import { useEffect, useMemo, useState } from "react";
import ApiService from "./service";
import MeridianPage from "../../MeridianPage";

const MONTH_NAMES = [
  "January", "February", "March", "April", "May", "June",
  "July", "August", "September", "October", "November", "December",
];

function generatePeriods(count = 18) {
  const out = [];
  const now = new Date();
  for (let i = 0; i < count; i++) {
    const d = new Date(now.getFullYear(), now.getMonth() - i, 1);
    out.push({
      value: `${d.getFullYear()}-${String(d.getMonth() + 1).padStart(2, "0")}`,
      label: `${MONTH_NAMES[d.getMonth()]} ${d.getFullYear()}`,
    });
  }
  return out;
}

const PERIODS = generatePeriods();

// ── Cell helpers ───────────────────────────────────────────────────

function CoAmtCell({ value }) {
  if (value == null) return <span className="gpnl-amt-dim">–</span>;
  const num = Number(value);
  const abs = Math.abs(num).toLocaleString("en-US", { minimumFractionDigits: 0 });
  return (
    <span className={`gpnl-amt-co${num < 0 ? " gpnl-negative" : ""}`}>
      {num < 0 ? `(${abs})` : abs}
    </span>
  );
}

function TotalAmtCell({ value, dim, bold }) {
  const cls = [
    dim ? "gpnl-amt-dim" : "gpnl-amt-total",
    bold ? "gpnl-amt-bold" : "",
  ].filter(Boolean).join(" ");

  if (value == null) return <span className={cls}>–</span>;
  const num = Number(value);
  const abs = Math.abs(num).toLocaleString("en-US", { minimumFractionDigits: 0 });
  return (
    <span className={`${cls}${num < 0 ? " gpnl-negative" : ""}`}>
      {num < 0 ? `(${abs})` : abs}
    </span>
  );
}

function VarianceCell({ value }) {
  if (value == null) return <span className="gpnl-amt-dim">–</span>;
  const num = Number(value);
  const sign = num >= 0 ? "+" : "";
  return (
    <span className={num >= 0 ? "gpnl-var-pos" : "gpnl-var-neg"}>
      {sign}{num.toFixed(1)}%
    </span>
  );
}

// ── Extended ConsolidatedPnLTable ──────────────────────────────────
//
// Dynamic company columns are derived from the `companies` prop.
// Each row.companies is an object keyed by company code: { "MER-US": 7410200, … }
//
// rowType values:
//   "section"  — section header  (REVENUE, COST OF GOODS SOLD …)
//   "account"  — leaf account row
//   "subtotal" — section total
//   "metric"   — computed line   (Gross Profit, Net Income …)

function ConsolidatedPnLTable({ companies = [], rows = [], currentLabel, priorLabel, showPY, loading }) {
  const colCount = 1 + companies.length + 1 + 1 + (showPY ? 2 : 0);

  const renderRow = (row, i) => {
    switch (row.rowType) {
      case "section":
        return (
          <tr key={i} className="gpnl-section-row">
            <td colSpan={colCount}>{row.label}</td>
          </tr>
        );

      case "account":
        return (
          <tr key={i} className="gpnl-account-row">
            <td>
              <span className="gpnl-account-chip">{row.accountCode}</span>
              <span className="gpnl-account-name">{row.accountName}</span>
            </td>
            {companies.map((co) => (
              <td key={co.code} className="text-end">
                <CoAmtCell value={row.companies?.[co.code]} />
              </td>
            ))}
            <td className="text-end">
              <CoAmtCell value={row.eliminations} />
            </td>
            <td className="text-end gpnl-td-total">
              <TotalAmtCell value={row.current} />
            </td>
            {showPY && <td className="text-end"><TotalAmtCell value={row.prior} dim /></td>}
            {showPY && <td className="text-end"><VarianceCell value={row.variance} /></td>}
          </tr>
        );

      case "subtotal":
        return (
          <tr key={i} className="gpnl-subtotal-row">
            <td>{row.label}</td>
            {companies.map((co) => (
              <td key={co.code} className="text-end">
                <TotalAmtCell value={row.companies?.[co.code]} bold />
              </td>
            ))}
            <td className="text-end">
              <TotalAmtCell value={row.eliminations} bold />
            </td>
            <td className="text-end gpnl-td-total">
              <TotalAmtCell value={row.current} bold />
            </td>
            {showPY && <td className="text-end"><TotalAmtCell value={row.prior} dim bold /></td>}
            {showPY && <td className="text-end"><VarianceCell value={row.variance} /></td>}
          </tr>
        );

      case "metric":
        return (
          <tr key={i} className="gpnl-metric-row">
            <td>{row.label}</td>
            {companies.map((co) => (
              <td key={co.code} className="text-end">
                <TotalAmtCell value={row.companies?.[co.code]} />
              </td>
            ))}
            <td className="text-end">
              <TotalAmtCell value={row.eliminations} />
            </td>
            <td className="text-end gpnl-td-total">
              <TotalAmtCell value={row.current} />
            </td>
            {showPY && <td className="text-end"><TotalAmtCell value={row.prior} dim /></td>}
            {showPY && <td className="text-end"><VarianceCell value={row.variance} /></td>}
          </tr>
        );

      default:
        return null;
    }
  };

  return (
    <div className="gpnl-card">
      <table className="gpnl-table">
        <thead>
          <tr className="gpnl-col-header-row">
            <th className="gpnl-col-account">ACCOUNT</th>
            {companies.map((co) => (
              <th key={co.code} className="gpnl-col-company text-end">{co.code}</th>
            ))}
            <th className="gpnl-col-elim text-end">ELIMINATIONS</th>
            <th className="gpnl-col-total text-end gpnl-td-total gpnl-th-total">{currentLabel}</th>
            {showPY && <th className="gpnl-col-prior text-end">{priorLabel}</th>}
            {showPY && <th className="gpnl-col-var text-end">Δ %</th>}
          </tr>
        </thead>
        <tbody>
          {loading ? (
            <tr>
              <td colSpan={colCount} className="text-center py-4 text-muted">
                <span className="spinner-border spinner-border-sm me-2" role="status" aria-hidden="true" />
                Loading...
              </td>
            </tr>
          ) : rows.length === 0 ? (
            <tr>
              <td colSpan={colCount} className="text-center py-4 text-muted">No data</td>
            </tr>
          ) : (
            rows.map(renderRow)
          )}
        </tbody>
      </table>
    </div>
  );
}

// ── Main screen ────────────────────────────────────────────────────

function ConsolidatedPnL() {
  const [period, setPeriod] = useState(PERIODS[0].value);
  const [showPY, setShowPY] = useState(true);
  const [uiData, setUiData] = useState({ loading: false, rows: [], companies: [], meta: null, error: "" });

  useEffect(() => {
    fetchReport(period);
    // eslint-disable-next-line
  }, [period]);

  const fetchReport = async (p) => {
    setUiData({ loading: true, rows: [], companies: [], meta: null, error: "" });
    const result = await ApiService.get(p);
    if (result.success) {
      setUiData({
        loading:   false,
        rows:      result.data?.rows      ?? [],
        companies: result.data?.companies ?? [],
        meta:      result.data            ?? null,
        error:     "",
      });
    } else {
      setUiData({ loading: false, rows: [], companies: [], meta: null, error: result.error });
    }
  };

  const { meta, companies } = uiData;

  const subtitle = useMemo(() => {
    const parts = [];
    if (meta?.company)     parts.push(meta.company);
    if (meta?.periodLabel) parts.push(meta.periodLabel);
    if (companies.length)  parts.push(`${companies.length} companies`);
    if (meta?.currency)    parts.push(meta.currency);
    return parts.join(" · ");
  }, [meta, companies]);

  const currentLabel = meta?.periodLabel ?? PERIODS.find((p) => p.value === period)?.label ?? period;
  const priorLabel   = meta?.priorLabel  ?? "YTD PY";

  return (
    <MeridianPage title="Consolidated Profit &amp; Loss">
      <p className="ml-page-subtitle">{subtitle}</p>
      <div className="ml-page-actions">
        <div className="ml-btn-ghost d-flex align-items-center gap-1 ml-period-bar">
          <span className="ml-period-label">Period:</span>
          <select
            className="gpnl-period-select"
            value={period}
            onChange={(e) => setPeriod(e.target.value)}
          >
            {PERIODS.map((p) => (
              <option key={p.value} value={p.value}>{p.label}</option>
            ))}
          </select>
        </div>
        <button
          className={`ml-btn-ghost${showPY ? " gpnl-btn-active" : ""}`}
          onClick={() => setShowPY((v) => !v)}
        >
          Compare: YTD
        </button>
        <button className="ml-btn-ghost">
          <i className="bi bi-file-earmark-pdf" aria-hidden="true" />
          PDF
        </button>
        <button className="ml-btn-ghost">
          <i className="bi bi-file-earmark-excel" aria-hidden="true" />
          Excel
        </button>
      </div>

      <ConsolidatedPnLTable
        companies={companies}
        rows={uiData.rows}
        currentLabel={currentLabel}
        priorLabel={priorLabel}
        showPY={showPY}
        loading={uiData.loading}
      />
    </MeridianPage>
  );
}

export default ConsolidatedPnL;
