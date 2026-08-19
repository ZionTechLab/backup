import { useEffect, useMemo, useState } from "react";
import { useNavigate } from "react-router-dom";
import { DataTable } from "../../../components/DataTable/DataTable";
import MessageBoxService from "../../../services/MessageBoxService";
import MeridianPage from "../MeridianPage";
import ApiService from "./service";

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

function fmtAmount(value) {
  if (value == null) return "–";
  return Number(value).toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
}

function fmtAmountWhole(value) {
  if (value == null) return "0";
  return Number(value).toLocaleString("en-US", { minimumFractionDigits: 0, maximumFractionDigits: 0 });
}

function StatCard({ label, value, accent }) {
  return (
    <div className={`er-stat-card${accent ? " er-stat-card-accent" : ""}`}>
      <p className="er-stat-label">{label}</p>
      <p className="er-stat-value">
        <span className="er-stat-currency">USD</span>
        {" "}{fmtAmountWhole(value)}
      </p>
    </div>
  );
}

function Eliminations() {
  const navigate = useNavigate();
  const [period, setPeriod] = useState(PERIODS[0].value);
  const [uiData, setUiData] = useState({ loading: false, data: [], error: "" });
  const [totals, setTotals] = useState({ all: 0, sales: 0, loans: 0, equity: 0 });

  useEffect(() => {
    fetchAll(period);
    // eslint-disable-next-line
  }, [period]);

  const fetchAll = async (p) => {
    setUiData({ loading: true, data: [], error: "" });
    const result = await ApiService.getAll(p);
    if (result.success) {
      setTotals({
        all:    result.data?.totals?.all    ?? 0,
        sales:  result.data?.totals?.sales  ?? 0,
        loans:  result.data?.totals?.loans  ?? 0,
        equity: result.data?.totals?.equity ?? 0,
      });
      setUiData({ loading: false, data: result.data?.items ?? [], error: "" });
    } else {
      setUiData({ loading: false, data: [], error: result.error });
    }
  };

  const handleDelete = async (id) => {
    const ok = await MessageBoxService.confirmAsync({
      message: "Delete this elimination?",
      type: "danger",
    });
    if (!ok) return;
    const res = await ApiService.delete(id);
    if (res.success) {
      MessageBoxService.show({ message: "Deleted", type: "success", onClose: () => fetchAll(period) });
    }
  };

  const subtitle = useMemo(() => {
    const label = PERIODS.find((p) => p.value === period)?.label ?? period;
    return `Intercompany transactions eliminated on consolidation · ${label} · USD`;
  }, [period]);

  const columns = [
    {
      header: "ID",
      field: "id",
      class: "text-nowrap",
      render: (row) => (
        <span
          className="ml-mono-primary cursor-pointer"
          onClick={() => navigate(`/group/eliminations/edit/${row.id}`)}
        >
          {row.id}
        </span>
      ),
    },
    {
      header: "TYPE",
      field: "type",
      render: (row) => <span className="er-type">{row.type}</span>,
    },
    {
      header: "FROM → TO",
      field: "fromCompany",
      class: "text-nowrap",
      render: (row) => (
        <span className="er-route">
          {row.fromCompany}
          <span className="er-route-arrow">→</span>
          {row.toCompany}
        </span>
      ),
    },
    {
      header: "ACCOUNT",
      field: "accountCode",
      render: (row) => <span className="ml-acct-chip">{row.accountCode}</span>,
    },
    {
      header: "DESCRIPTION",
      field: "description",
    },
    {
      header: "AMOUNT",
      field: "amount",
      class: "text-end text-nowrap",
      render: (row) => (
        <span className="er-amount">
          <span className="er-amount-currency">$</span>
          {fmtAmount(row.amount)}
        </span>
      ),
    },
    {
      header: "",
      field: "actions",
      isAction: true,
      actionTemplate: (row) => (
        <div className="d-flex gap-2">
          <button
            aria-label="Edit"
            className="btn btn-outline-primary btn-sm btn-borderless"
            onClick={() => navigate(`/group/eliminations/edit/${row.id}`)}
          >
            <i className="bi bi-pencil" />
          </button>
          <button
            className="btn btn-outline-danger btn-sm btn-borderless"
            onClick={() => handleDelete(row.id)}
          >
            <i className="bi bi-trash" />
          </button>
        </div>
      ),
    },
  ];

  return (
    <MeridianPage title="Elimination Report">
      <p className="ml-page-subtitle">{subtitle}</p>
      <div className="ml-page-actions">
        <div className="ml-btn-ghost d-flex align-items-center gap-1 ml-period-bar">
          <span className="ml-period-label">Period:</span>
          <select
            className="er-period-select"
            value={period}
            onChange={(e) => setPeriod(e.target.value)}
          >
            {PERIODS.map((p) => (
              <option key={p.value} value={p.value}>{p.label}</option>
            ))}
          </select>
        </div>
        <button className="ml-btn-action ml-fab" onClick={() => navigate("/group/eliminations/add")}>
          <i className="bi bi-plus-lg" aria-hidden="true" />
          Add Elimination
        </button>
        <button className="ml-btn-ghost">
          <i className="bi bi-download" aria-hidden="true" />
          Export
        </button>
      </div>

      <div className="er-stat-row">
        <StatCard label="TOTAL ELIMINATIONS" value={totals.all} />
        <StatCard label="SALES ELIMINATED"   value={totals.sales} />
        <StatCard label="LOANS ELIMINATED"   value={totals.loans} />
        <StatCard label="EQUITY ELIMINATED"  value={totals.equity} accent />
      </div>

      <div className="rounded-bottom-0">
        <DataTable
          columns={columns}
          data={uiData.data}
          loading={uiData.loading}
          name="Eliminations"
          pageSizeOptions={[10, 25, 50]}
          // //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
        />
      </div>

      <div className="er-total-row">
        <span className="er-total-label">Total Eliminations</span>
        <span className="er-total-amount">
          <span className="er-amount-currency">$</span>
          {fmtAmount(totals.all)}
        </span>
      </div>
    </MeridianPage>
  );
}

export default Eliminations;
