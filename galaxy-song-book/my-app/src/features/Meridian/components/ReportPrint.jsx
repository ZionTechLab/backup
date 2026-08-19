import "./report-print.css";
import { formatDateTime } from "../../../helpers/transformDateFields";
import { brand } from "../../../config/brand";

// Reusable print shell for Galaxy report screens.
// Hidden on screen; the @media print rules in report-print.css reveal it
// and hide the rest of the app shell. Pass the report body as children.
//
// Props:
//   title     — report name ("General Ledger")
//   subtitle  — optional line under the title (account, scope)
//   meta      — optional array of right-aligned nodes (period, company, …)
//   children  — the report body (a table)
function ReportPrint({ title, subtitle, meta = [], children }) {
  return (
    <div className="ml-print-area">
      <div className="ml-print-brand">
        {brand.reportLogo ? (
          <img className="ml-print-logo" src={brand.reportLogo} alt={brand.name} />
        ) : (
          <span className="ml-print-brand-name">{brand.name}</span>
        )}
      </div>
      <header className="ml-print-header">
        <div>
          <h1 className="ml-print-title">{title}</h1>
          {subtitle && <p className="ml-print-subtitle">{subtitle}</p>}
        </div>
        <div className="ml-print-meta">
          {meta.map((line, i) => (
            <p key={i}>{line}</p>
          ))}
          <p>Printed: {formatDateTime(new Date())}</p>
        </div>
      </header>
      {children}
    </div>
  );
}

export default ReportPrint;
