import { useCallback, useState } from "react";
import ApiService from "./service";
import MeridianPage from "../../MeridianPage";
import { todayISO } from "../../../../helpers/transformDateFields";
import DateInput from "../../../../components/DateInput/index.jsx";

function today() {
  return todayISO();
}

function firstOfMonth() {
  return todayISO(new Date(new Date().getFullYear(), new Date().getMonth(), 1));
}

function flattenTree(nodes = [], depth = 0, out = []) {
  for (const n of nodes) {
    out.push({ rowType: "account", accountCode: n.accountCode, accountName: n.accountName, balance: n.balance, depth });
    if (n.children?.length) flattenTree(n.children, depth + 1, out);
  }
  return out;
}

function buildRows(data) {
  if (!data) return [];
  const rows = [];
  rows.push({ rowType: "section", label: "Income" });
  flattenTree(data.income ?? [], 0, rows);
  rows.push({ rowType: "subtotal", label: "Total Income", balance: data.totalIncome });
  rows.push({ rowType: "section", label: "Expenses" });
  flattenTree(data.expense ?? [], 0, rows);
  rows.push({ rowType: "subtotal", label: "Total Expenses", balance: data.totalExpense });
  rows.push({ rowType: "metric", label: "Net Profit", balance: data.netProfit });
  return rows;
}

function AmountCell({ value, dim, bold }) {
  const cls = [dim ? "pnl-amt-dim" : "pnl-amt", bold ? "pnl-amt-bold" : ""].filter(Boolean).join(" ");
  if (value == null) return <span className={cls}>-</span>;
  const num = Number(value);
  const abs = Math.abs(num).toLocaleString("en-US", { minimumFractionDigits: 0, maximumFractionDigits: 0 });
  return <span className={`${cls}${num < 0 ? " pnl-negative" : ""}`}>{num < 0 ? `(${abs})` : abs}</span>;
}

function PnLTable({ rows = [], loading }) {
  const renderRow = (row, i) => {
    switch (row.rowType) {
      case "section":
        return (
          <tr key={i} className="pnl-section-row">
            <td colSpan={2}>{row.label}</td>
          </tr>
        );
      case "account":
        return (
          <tr key={i} className="pnl-account-row">
            <td style={row.depth ? { paddingLeft: 20 + row.depth * 16 + "px" } : undefined}>
              <span className="pnl-account-chip">{row.accountCode}</span>
              <span className="pnl-account-name">{row.accountName}</span>
            </td>
            <td className="text-end"><AmountCell value={row.balance} /></td>
          </tr>
        );
      case "subtotal":
        return (
          <tr key={i} className="pnl-subtotal-row">
            <td>{row.label}</td>
            <td className="text-end"><AmountCell value={row.balance} bold /></td>
          </tr>
        );
      case "metric":
        return (
          <tr key={i} className="pnl-metric-row">
            <td>{row.label}</td>
            <td className="text-end"><AmountCell value={row.balance} /></td>
          </tr>
        );
      default:
        return null;
    }
  };

  return (
    <div className="ml-screen-card overflow-hidden">
      <table className="pnl-table">
        <thead>
          <tr className="pnl-col-header-row">
            <th className="pnl-col-account">ACCOUNT</th>
            <th className="pnl-col-amount text-end">AMOUNT</th>
          </tr>
        </thead>
        <tbody>
          {loading ? (
            <tr>
              <td colSpan={2} className="text-center py-4 text-muted">
                <span className="spinner-border spinner-border-sm me-2" role="status" aria-hidden="true" />
                Loading...
              </td>
            </tr>
          ) : rows.length === 0 ? (
            <tr>
              <td colSpan={2} className="text-center py-4 text-muted">No data</td>
            </tr>
          ) : (
            rows.map(renderRow)
          )}
        </tbody>
      </table>
    </div>
  );
}

function PnLStatement() {
  const [fromDate, setFromDate] = useState(firstOfMonth());
  const [toDate, setToDate]     = useState(today());
  const [uiData, setUiData]     = useState({ loading: false, rows: [], data: null, error: "" });

  const run = useCallback(async (from, to) => {
    if (!from || !to) return;
    setUiData({ loading: true, rows: [], data: null, error: "" });
    const result = await ApiService.get(from, to);
    if (result.success) {
      setUiData({ loading: false, rows: buildRows(result.data), data: result.data, error: "" });
    } else {
      setUiData({ loading: false, rows: [], data: null, error: result.error });
    }
  }, []);

  return (
    <MeridianPage title="Profit &amp; Loss Statement">
      {uiData.data?.company && (
        <p className="ml-page-subtitle">{uiData.data.company}</p>
      )}
      <div className="ml-page-actions">
        <div className="ml-btn-ghost d-flex align-items-center gap-2 ml-period-bar">
          <span className="ml-period-label">From</span>
          <DateInput
            name="fromDate"
            className="pnl-date-input"
            value={fromDate}
            onChange={(e) => setFromDate(e.target.value)}
          />
          <span className="ml-period-label">To</span>
          <DateInput
            name="toDate"
            className="pnl-date-input"
            value={toDate}
            onChange={(e) => setToDate(e.target.value)}
          />
        </div>
        <button
          className="ml-btn-ghost"
          onClick={() => run(fromDate, toDate)}
          disabled={uiData.loading}
        >
          Run
        </button>
        <button className="ml-btn-ghost">
          <i className="bi bi-file-earmark-pdf" aria-hidden="true" /> PDF
        </button>
        <button className="ml-btn-ghost">
          <i className="bi bi-file-earmark-excel" aria-hidden="true" /> Excel
        </button>
      </div>

      <PnLTable rows={uiData.rows} loading={uiData.loading} />
    </MeridianPage>
  );
}

export default PnLStatement;
