import { useEffect, useMemo, useState } from "react";
import { useNavigate } from "react-router-dom";
import { DataTable } from "../../../../components/DataTable/DataTable";
import ApiService from "./service";
import MeridianPage from "../../MeridianPage";


const MONTH_NAMES = [
  "January", "February", "March", "April", "May", "June",
  "July", "August", "September", "October", "November", "December",
];

const TYPE_LABELS = { A: "Asset", L: "Liability", E: "Equity", R: "Revenue", X: "Expense" };

function fmtAmount(value) {
  if (value == null || value === 0) return "–";
  return Number(value).toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
}

function Balance({ value }) {
  if (value == null || value === 0) return <span className="ml-mono-dim">–</span>;
  const num = Number(value);
  if (num < 0) {
    const abs = Math.abs(num).toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
    return <span className="ml-mono-negative">({abs})</span>;
  }
  return <span className="ml-mono-dim">{fmtAmount(num)}</span>;
}

// Period (YYYY-MM) -> { from, to } covering the full calendar month.
function periodRange(period) {
  const [year, month] = period.split("-").map(Number);
  const pad = (n) => String(n).padStart(2, "0");
  const lastDay = new Date(year, month, 0).getDate();
  return { from: `${year}-${pad(month)}-01`, to: `${year}-${pad(month)}-${pad(lastDay)}` };
}

// Endpoint rows nest account details under `account`; flatten to top level.
function normalizeRow(row) {
  const a = row.account ?? row;
  return {
    accountId:   a.accountId,
    accountCode: a.accountCode,
    accountName: a.accountName,
    accountType: a.accountType,
    opbl:   row.opbl,
    debit:  row.debit,
    credit: row.credit,
    clbl:   row.clbl,
  };
}

function generatePeriods(count = 18) {
  const periods = [];
  const now = new Date();
  for (let i = 0; i < count; i++) {
    const d = new Date(now.getFullYear(), now.getMonth() - i, 1);
    const value = `${d.getFullYear()}-${String(d.getMonth() + 1).padStart(2, "0")}`;
    const label = `${MONTH_NAMES[d.getMonth()]} ${d.getFullYear()}`;
    periods.push({ value, label });
  }
  return periods;
}

const PERIODS = generatePeriods();

function TrialBalance() {
  const navigate = useNavigate();
  const [period, setPeriod] = useState(PERIODS[0].value);
  const [uiData, setUiData] = useState({ loading: false, data: [], error: "" });
  const [meta, setMeta] = useState({ asOf: "", company: "", currency: "USD" });

  useEffect(() => {
    fetchReport(period);
    // eslint-disable-next-line
  }, [period]);

  const fetchReport = async (p) => {
    setUiData({ loading: true, data: [], error: "" });
    const { from, to } = periodRange(p);
    const result = await ApiService.getTrialBalance(from, to);
    if (result.success) {
      const raw = Array.isArray(result.data) ? result.data : result.data?.rows ?? [];
      setMeta({ asOf: to, company: result.data?.company ?? "", currency: result.data?.currency ?? "USD" });
      setUiData({ loading: false, data: raw.map(normalizeRow), error: "" });
    } else {
      setUiData({ loading: false, data: [], error: result.error });
    }
  };

  const subtitle = useMemo(() => {
    const parts = [];
    if (meta.asOf)    parts.push(`As of ${meta.asOf}`);
    if (meta.company) parts.push(meta.company);
    if (meta.currency) parts.push(meta.currency);
    return parts.join(" · ");
  }, [meta]);

  const periodLabel = useMemo(
    () => PERIODS.find((p) => p.value === period)?.label ?? period,
    [period]
  );

  const columns = [
    {
      header: "CODE",
      field: "accountCode",
      class: "text-nowrap",
      render: (row) => (
        <span
          className="ml-mono-primary cursor-pointer"
          onClick={() => navigate(`/coa/edit/${row.accountId}`)}
        >
          {row.accountCode}
        </span>
      ),
    },
    { header: "ACCOUNT", field: "accountName" },
    {
      header: "TYPE",
      field: "accountType",
      render: (row) => (
        <span className="ml-mono-dim">
          {TYPE_LABELS[row.accountType] ?? row.accountType}
        </span>
      ),
    },
    {
      header: "OPENING",
      field: "opbl",
      class: "text-end text-nowrap",
      render: (row) => <Balance value={row.opbl} />,
    },
    {
      header: "DEBIT",
      field: "debit",
      class: "text-end text-nowrap",
      render: (row) => <span className="ml-mono-dim">{fmtAmount(row.debit)}</span>,
    },
    {
      header: "CREDIT",
      field: "credit",
      class: "text-end text-nowrap",
      render: (row) => <span className="ml-mono-dim">{fmtAmount(row.credit)}</span>,
    },
    {
      header: "CLOSING",
      field: "clbl",
      class: "text-end text-nowrap",
      render: (row) => <Balance value={row.clbl} />,
    },
  ];

  return (
    <MeridianPage title="Trial Balance">
      <p className="ml-page-subtitle">{subtitle}</p>
      <div className="ml-page-actions">
        <div className="d-flex align-items-center gap-1 ml-btn-ghost ml-period-bar-tb">
          <span className="ml-period-label">Period:</span>
          <select
            className="border-0 bg-transparent ml-period-select"
            value={period}
            onChange={(e) => setPeriod(e.target.value)}
          >
            {PERIODS.map((p) => (
              <option key={p.value} value={p.value}>{p.label}</option>
            ))}
          </select>
        </div>
        <button className="ml-btn-ghost">
          <i className="bi bi-file-earmark-pdf" aria-hidden="true" />
          PDF
        </button>
        <button className="ml-btn-ghost">
          <i className="bi bi-file-earmark-excel" aria-hidden="true" />
          Excel
        </button>
      </div>

      <DataTable
        columns={columns}
        data={uiData.data}
        loading={uiData.loading}
        name="TrialBalance"
        pageSizeOptions={[50, 100, 250]}
        // //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      />
    </MeridianPage>
  );
}

export default TrialBalance;
