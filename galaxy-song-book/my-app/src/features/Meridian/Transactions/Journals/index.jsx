import { useEffect, useMemo, useState } from "react";
import { useNavigate,useLocation } from "react-router-dom";
import { DataTable } from "../../../../components/DataTable/DataTable";
import MeridianPage from "../../MeridianPage";
import ApiService from "./service";


const TABS = ["All", "Posted", "Drafts", "Voided"];
const TAB_STATUS = { Posted: "Posted", Drafts: "Draft", Voided: "Void" };

const MONTH_NAMES = [
  "January", "February", "March", "April", "May", "June",
  "July", "August", "September", "October", "November", "December",
];

function StatusBadge({ status }) {
  const map = {
    Posted: "ml-badge-open",
    Draft:  "ml-badge-draft",
    Void:   "ml-badge-void",
  };
  const cls = map[status] || "ml-badge-locked";
  return <span className={`ml-badge ${cls}`}>{status}</span>;
}

function Journals() {
    const [uiData, setUiData] = useState({loading: false, success: false, error: '', data: [] });
    const navigate = useNavigate();
    const location = useLocation();
    const [activeTab, setTab]   = useState("All");

  useEffect(() => {
    fetchUi();
    // eslint-disable-next-line
  }, []);

   const fetchUi = async () => {
      setUiData((prev) => ({ ...prev, loading: true, error: '', data: [] }));
      const data = await ApiService.getAll();
      setUiData((prev) => ({ ...prev, ...data, loading: false }));
    };

const columns = [
  { header: "TXN ID",    class:'text-nowrap',    render: (row) => row.docType + "-" + row.docNo, cardRole: 'title' },
  { header: "ID",        field: "transactionId" ,class:'d-none', cardHide: true },
  { header: "DATE",        field: "txnDate",        class:'text-nowrap' ,type: 'date', cardRole: 'subtitle' },
  { header: "REFERENCE",   field: "reference" },
  { header: "DESCRIPTION", field: "description" },
  { header: "AMOUNT",      field: "totalAmount",  class: 'text-nowrap text-end', type: 'currency', cardRole: 'amount' },
  { header: "STATUS",      field: "status",             render: (row) => <StatusBadge status={row.status} />, cardRole: 'badge' },
  { header: "AUTHOR",      field: "createdByName",      render: (row) => row.createdByName || "-", cardRole: 'meta', cardIcon: 'bi bi-person' },
     {
      header: "",
      field: "actions",
      isAction: true,
      actionTemplate: (row) => (
        <button aria-label="Edit" className="btn btn-outline-primary btn-sm btn-borderless" onClick={() => navigate(`${location.pathname}/edit/${row.transactionId}`)}>
          <i className="bi bi-pencil" />
        </button>
      ),
    },
];
  const counts = useMemo(() => ({
    All:    uiData.data.length,
    Posted: uiData.data.filter((r) => r.status === "Posted").length,
    Drafts: uiData.data.filter((r) => r.status === "Draft").length,
    Voided: uiData.data.filter((r) => r.status === "Void").length,
  }), [uiData]);

  const filtered = activeTab === "All"
    ? uiData.data
    : uiData.data.filter((r) => r.status === TAB_STATUS[activeTab]);

  const subtitle = useMemo(() => {
    if (!uiData.data.length) return "No entries";
    const latest = uiData.data.reduce((a, b) => (a.txnDate > b.txnDate ? a : b));
    const d = new Date(latest.txnDate);
    const label = `${MONTH_NAMES[d.getMonth()]} ${d.getFullYear()}`;
    return `${label} · ${counts.Posted} posted · ${counts.Drafts} drafts · ${counts.Voided} voided`;
  }, [uiData, counts]);

  return (
    <MeridianPage title="Journal Entries">
      <p className="ml-page-subtitle">{subtitle}</p>

      <div className="ml-coa-tabs">
        {TABS.map((tab) => (
          <button
            key={tab}
            className={`ml-coa-tab${activeTab === tab ? " ml-coa-tab-active" : ""}`}
            onClick={() => setTab(tab)}
          >
            {tab}
            <span className="ml-tab-count">{counts[tab] ?? 0}</span>
          </button>
        ))}
      </div>

      <DataTable
        columns={columns}
        data={filtered}
         loading={uiData.loading}
        onRowClick={(row) => navigate(`/journals/edit/${row.transactionId}`)}
        // //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      >
        <button className="ml-btn-action ml-fab" onClick={() => navigate("/journals/add")}>
          <i className="bi bi-plus-lg" aria-hidden="true" />
          New Entry
        </button>
      </DataTable>
    </MeridianPage>
  );
}
export default Journals;