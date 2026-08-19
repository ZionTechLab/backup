import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { DataTable } from "../../../../components/DataTable/DataTable";
import MeridianPage from "../../MeridianPage";
import companiesService from "./service";

function PeriodCell({ period }) {
  if (!period) return <span className="ml-badge ml-badge-locked">-</span>;
  const cls = period.status === "open" ? "ml-badge ml-badge-open" : "ml-badge ml-badge-locked";
  return <span className={cls}>{period.label}</span>;
}

function buildColumns(navigate) {
  return [
    { header: "Company ID",   field: "companyId", isId: true },
    { header: "Code",         field: "companyCode" },
    { header: "Company Name", field: "companyName" },
    { header: "Tenant",       field: "tenantName" },
    { header: "Group",        field: "groupName" },
    { header: "Country",      field: "country" },
    { header: "Base CCY",     field: "baseCCY" },
    {
      header: "Fiscal Year",
      field: "fiscalYear",
      render: (row) => <span className="ml-mono-dim">{row.fiscalYear}</span>,
    },
    {
      header: "Period",
      field: "period",
      render: (row) => <PeriodCell period={row.period} />,
    },
    {
      header: "",
      field: "actions",
      isAction: true,
      actionTemplate: (row) => (
        <button aria-label="Edit" className="btn btn-outline-primary btn-sm btn-borderless" onClick={() => navigate(`/settings/companies/edit/${row.companyId}`)}>
          <i className="bi bi-pencil" />
        </button>
      ),
    },
  ];
}

export default function Companies() {
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, data: [], error: "" });
  const columns = buildColumns(navigate);

  useEffect(() => { fetchAll(); }, []);

  const fetchAll = async () => {
    setUiData(prev => ({ ...prev, loading: true, data: [] }));
    const { success, data } = await companiesService.getAll();
    setUiData(prev => ({ ...prev, data: success ? data : [], loading: false }));
  };

  return (
    <MeridianPage title="Companies">
      <DataTable
        columns={columns}
        data={uiData.data}
        loading={uiData.loading}
        name="Companies"
        // //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      >
        <button className="ml-btn-action ml-fab" onClick={() => navigate("/settings/companies/add")}>
          <i className="bi bi-plus-lg" aria-hidden="true" />
          Add Company
        </button>
      </DataTable>
    </MeridianPage>
  );
}
