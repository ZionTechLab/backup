import { Fragment } from "react";
import ReportPrint from "../../components/ReportPrint";
import { formatDate } from "../../../../helpers/transformDateFields";

const TYPE_LABELS = { A: "Asset", L: "Liability", E: "Equity", R: "Revenue", X: "Expense" };

function money(value) {
  if (value == null || value === 0) return "-";
  const num = Number(value);
  const abs = Math.abs(num).toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
  return num < 0 ? `(${abs})` : abs;
}

function fmtDate(value) {
  return formatDate(value);
}

// General Ledger print body. Renders every group and line so pagination
// never clips the report. The print shell lives in ReportPrint.
function GeneralLedgerPrint({ account, dateFrom, dateTo, groups = [], summary }) {
  const accountLabel = account
    ? account.accountCode
      ? `${account.accountCode} · ${account.accountName}`
      : account.accountName
    : "All accounts";

  const meta = [];
  if (dateFrom || dateTo) {
    meta.push(`Period: ${fmtDate(dateFrom) || "…"} – ${fmtDate(dateTo) || "…"}`);
  }

  return (
    <ReportPrint title="General Ledger" subtitle={accountLabel} meta={meta}>
      <table className="ml-print-table">
        <thead>
          <tr>
            <th>Date</th>
            <th>Journal</th>
            <th>Reference</th>
            <th>Description</th>
            <th className="ml-print-num">Debit</th>
            <th className="ml-print-num">Credit</th>
            <th className="ml-print-num">Running</th>
          </tr>
        </thead>
        <tbody>
          {groups.length === 0 ? (
            <tr>
              <td colSpan={7} className="ml-print-empty">No transactions.</td>
            </tr>
          ) : (
            groups.map((g, gi) => (
              <Fragment key={g.account?.accountId ?? gi}>
                <tr className="ml-print-group">
                  <td colSpan={4}>
                    <span className="ml-print-group-code">{g.account?.accountCode}</span>
                    {g.account?.accountName}
                    {g.account?.accountType && (
                      <span className="ml-print-group-muted">
                        {TYPE_LABELS[g.account.accountType] ?? g.account.accountType}
                      </span>
                    )}
                    <span className="ml-print-group-muted">Opening {money(g.opbl)}</span>
                  </td>
                  <td className="ml-print-num">{money(g.debit)}</td>
                  <td className="ml-print-num">{money(g.credit)}</td>
                  <td className="ml-print-num">{money(g.clbl)}</td>
                </tr>
                {(g.lines ?? []).map((line, li) => (
                  <tr key={li}>
                    <td className="ml-print-nowrap">{fmtDate(line.txnDate)}</td>
                    <td className="ml-print-nowrap">{line.journalRef}</td>
                    <td>{line.reference}</td>
                    <td>{line.description}</td>
                    <td className="ml-print-num">{money(line.debit)}</td>
                    <td className="ml-print-num">{money(line.credit)}</td>
                    <td className="ml-print-num">{money(line.runningBalance)}</td>
                  </tr>
                ))}
              </Fragment>
            ))
          )}
        </tbody>
        {summary && groups.length > 0 && (
          <tfoot>
            <tr className="ml-print-total">
              <td colSpan={4}>Total · Opening {money(summary.openingBalance)}</td>
              <td className="ml-print-num">{money(summary.totalDebits)}</td>
              <td className="ml-print-num">{money(summary.totalCredits)}</td>
              <td className="ml-print-num">{money(summary.closingBalance)}</td>
            </tr>
          </tfoot>
        )}
      </table>
    </ReportPrint>
  );
}

export default GeneralLedgerPrint;
