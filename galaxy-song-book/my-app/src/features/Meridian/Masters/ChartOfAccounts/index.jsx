import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { DataTable } from "../../../../components/DataTable/DataTable";
import MeridianPage from "../../MeridianPage";
import ApiService from "./service";


const TYPE_LABELS = { A: "Asset", L: "Liability", E: "Equity", R: "Revenue", X: "Expense" };
const TABS        = ["All", "Assets", "Liabilities", "Equities", "Revenues", "Expenses"];
const TAB_TYPE    = { Assets: "A", Liabilities: "L", Equities: "E", Revenues: "R", Expenses: "X" };

function makeColumns(navigate) {
  return [
    { header: "Code",    field: "accountCode", class: "ml-mono-primary" },
    { header: "Name",    field: "accountName", class: "text-nowrap" },
    { header: "Type",    field: "accountType", render: (row) => TYPE_LABELS[row.accountType] ?? row.accountType },
    { header: "Section", field: "sectionName" },
    {
      header: "Balance (USD)",
      field: "balance",
      class: "text-end",
      render: (row) => (
        <span className="ml-mono-dim">
          {row.balance != null
            ? `$${Number(row.balance).toLocaleString("en-US", { minimumFractionDigits: 0 })}`
            : "-"}
        </span>
      ),
    },
    {
      header: "Status",
      field: "isActive",
      class: "text-center",
      render: (row) => (
        <span className={`ml-badge ${row.isActive ? "ml-badge-open" : "ml-badge-locked"}`}>
          {row.isActive ? "Active" : "Inactive"}
        </span>
      ),
    },
    {
      header: "",
      field: "actions",
      isAction: true,
      actionTemplate: (row) => (
        <button
          aria-label="Edit"
          className="btn btn-outline-primary btn-sm btn-borderless"
          onClick={() => navigate(`/coa/edit/${row.accountId}`)}
        >
          <i className="bi bi-pencil" />
        </button>
      ),
    },
  ];
}

export default function ChartOfAccounts() {
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: false, data: [], error: "" });
  const [activeTab, setTab] = useState("All");

  useEffect(() => { fetchAll(); }, []);

  const fetchAll = async () => {
    setUiData(prev => ({ ...prev, loading: true, data: [] }));
    const result = await ApiService.getAll();
    setUiData(prev => ({ ...prev, ...result, loading: false }));
  };

  const filtered = activeTab === "All"
    ? (uiData.data ?? [])
    : (uiData.data ?? []).filter((r) => r.accountType === TAB_TYPE[activeTab]);

  const columns = makeColumns(navigate);

  return (
    <MeridianPage title="Chart of Accounts">
      <p className="ml-page-subtitle">{(uiData.data ?? []).length} accounts</p>

      <div className="ml-coa-tabs">
        {TABS.map((tab) => (
          <button
            key={tab}
            className={`ml-coa-tab${activeTab === tab ? " ml-coa-tab-active" : ""}`}
            onClick={() => setTab(tab)}
          >
            {tab}
          </button>
        ))}
      </div>

      <DataTable
        data={filtered}
        columns={columns}
        loading={uiData.loading}
        name="ChartOfAccounts"
        pageSizeOptions={[10, 25, 50]}
        // //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      >
        <button className="ml-btn-action ml-fab" onClick={() => navigate("/coa/add")}>
          <i className="bi bi-plus-lg" aria-hidden="true" />
          New Account
        </button>
      </DataTable>
    </MeridianPage>
  );
}
