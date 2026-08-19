import { Fragment, useCallback, useState } from "react";
import ApiService from "./service";
import MeridianPage from "../../MeridianPage";
import { todayISO } from "../../../../helpers/transformDateFields";
import DateInput from "../../../../components/DateInput/index.jsx";

function today() {
  return todayISO();
}

function flattenLeaves(nodes, depth = 0) {
  const rows = [];
  for (const n of nodes) {
    if (!n.children?.length) {
      rows.push({ accountCode: n.accountCode, accountName: n.accountName, current: n.balance, depth });
    } else {
      rows.push(...flattenLeaves(n.children, depth + 1));
    }
  }
  return rows;
}

function treeToSections(nodes = []) {
  return nodes.map((node) => ({
    label: node.accountName,
    rows: node.children?.length
      ? flattenLeaves(node.children, 0)
      : [{ accountCode: node.accountCode, accountName: node.accountName, current: node.balance }],
    total: { label: `Total ${node.accountName}`, current: node.balance },
  }));
}

function AmountCell({ value, bold }) {
  const cls = ["bs-amt", bold ? "bs-amt-bold" : ""].filter(Boolean).join(" ");
  if (value == null) return <span className={cls}>-</span>;
  const num = Number(value);
  const abs = Math.abs(num).toLocaleString("en-US", { minimumFractionDigits: 0, maximumFractionDigits: 0 });
  return <span className={`${cls}${num < 0 ? " bs-negative" : ""}`}>{num < 0 ? `(${abs})` : abs}</span>;
}

function GrandAmtCell({ value }) {
  if (value == null) return <span className="bs-grand-amt">-</span>;
  const num = Number(value);
  const abs = Math.abs(num).toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
  return <span className={`bs-grand-amt${num < 0 ? " bs-negative" : ""}`}>{num < 0 ? `(${abs})` : abs}</span>;
}

function GroupedTable({ title, sections = [], grandTotal, loading }) {
  return (
    <div className="bs-panel">
      <div className="bs-panel-header">{title}</div>
      <table className="bs-table">
        <thead>
          <tr className="bs-col-header-row">
            <th className="bs-col-account">ACCOUNT</th>
            <th className="bs-col-amount text-end">AMOUNT</th>
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
          ) : sections.length === 0 ? (
            <tr>
              <td colSpan={2} className="text-center py-4 text-muted">No data</td>
            </tr>
          ) : (
            sections.map((section, si) => (
              <Fragment key={si}>
                <tr className="bs-section-header-row">
                  <td colSpan={2}>{section.label}</td>
                </tr>
                {section.rows.map((row, ri) => (
                  <tr key={ri} className="bs-row">
                    <td style={row.depth ? { paddingLeft: 16 + row.depth * 14 + "px" } : undefined}>
                      <span className="bs-account-chip">{row.accountCode}</span>
                      <span className="bs-account-name">{row.accountName}</span>
                    </td>
                    <td className="text-end"><AmountCell value={row.current} /></td>
                  </tr>
                ))}
                {section.total && (
                  <tr className="bs-subtotal-row">
                    <td>{section.total.label}</td>
                    <td className="text-end"><AmountCell value={section.total.current} bold /></td>
                  </tr>
                )}
              </Fragment>
            ))
          )}
        </tbody>
        {grandTotal && !loading && (
          <tfoot>
            <tr className="bs-grand-total-row">
              <td className="bs-amt-bold">{grandTotal.label}</td>
              <td className="text-end"><GrandAmtCell value={grandTotal.current} /></td>
            </tr>
          </tfoot>
        )}
      </table>
    </div>
  );
}

function BalanceSheet() {
  const [asOf, setAsOf]     = useState(today());
  const [uiData, setUiData] = useState({ loading: false, data: null, error: "" });

  const run = useCallback(async (date) => {
    if (!date) return;
    setUiData({ loading: true, data: null, error: "" });
    const result = await ApiService.get(date);
    if (result.success) {
      setUiData({ loading: false, data: result.data, error: "" });
    } else {
      setUiData({ loading: false, data: null, error: result.error });
    }
  }, []);

  const { data } = uiData;

  const assetSections = treeToSections(data?.assets ?? []);
  const liabEquitySections = [
    ...treeToSections(data?.liabilities ?? []),
    ...treeToSections(data?.equity ?? []),
  ];

  const totalLiabEquity = (data?.totalLiabilities ?? 0) + (data?.totalEquity ?? 0);

  return (
    <MeridianPage title="Balance Sheet">
      {data?.company && (
        <p className="ml-page-subtitle">{data.company}</p>
      )}
      <div className="ml-page-actions">
        <div className="ml-btn-ghost d-flex align-items-center gap-2 ml-period-bar">
          <span className="ml-period-label">As of</span>
          <DateInput
            name="asOf"
            className="bs-date-input"
            value={asOf}
            onChange={(e) => setAsOf(e.target.value)}
          />
        </div>
        <button
          className="ml-btn-ghost"
          onClick={() => run(asOf)}
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

      <div className="bs-layout">
        <GroupedTable
          title="ASSETS"
          sections={assetSections}
          grandTotal={data ? { label: "Total Assets", current: data.totalAssets } : null}
          loading={uiData.loading}
        />
        <GroupedTable
          title="LIABILITIES & EQUITY"
          sections={liabEquitySections}
          grandTotal={data ? { label: "Total Liabilities & Equity", current: totalLiabEquity } : null}
          loading={uiData.loading}
        />
      </div>

      <div className="bs-status-bar">
        <div className="bs-status-items">
          {data?.company && (
            <span className="bs-status-item">{data.company}</span>
          )}
          {data?.company && <span className="bs-status-divider">|</span>}
          <span className="bs-status-item">
            AS OF <span className="bs-status-value">{asOf}</span>
          </span>
          {data != null && (
            <>
              <span className="bs-status-divider">|</span>
              <span className="bs-status-item">
                <span className={data.balanced ? "bs-status-balanced" : "bs-status-unbalanced"}>
                  {data.balanced ? "BALANCED" : "UNBALANCED"}
                </span>
              </span>
            </>
          )}
        </div>
        <div className="bs-status-synced">◇ SYNCED</div>
      </div>
    </MeridianPage>
  );
}

export default BalanceSheet;
