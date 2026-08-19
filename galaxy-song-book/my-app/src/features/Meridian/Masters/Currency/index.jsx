import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { DataTable } from "../../../../components/DataTable/DataTable";
import MeridianPage from "../../MeridianPage";
import currencyService from "./service";


function buildColumns(navigate) {
  return [
    { header: "Code",   field: "currencyCode"},
    { header: "Name",   field: "currencyName" },
    { header: "Symbol", field: "symbol"},
    {
      header: "Status",
      field: "isActive",
      render: (row) => (
        <span className={row.isActive ? "ml-badge ml-badge-open" : "ml-badge ml-badge-locked"}>
          {row.isActive ? "Active" : "Inactive"}
        </span>
      ),
    },
    {
      header: "",
      field: "actions",
      isAction: true,
      actionTemplate: (row) => (
        <button aria-label="Edit" className="btn btn-outline-primary btn-sm btn-borderless" onClick={() => navigate(`/settings/currencies/edit/${row.currencyCode}`)}>
          <i className="bi bi-pencil" />
        </button>
      ),
    },
  ];
}

export default function Currencies() {
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, data: [], error: "" });
  const columns = buildColumns(navigate);

  useEffect(() => { fetchAll(); }, []);

  const fetchAll = async () => {
    setUiData(prev => ({ ...prev, loading: true, data: [] }));
    const { success, data } = await currencyService.getAll();
    setUiData(prev => ({ ...prev, data: success ? data : [], loading: false }));
  };

  return (
    <MeridianPage title="Currencies">
      <DataTable
        columns={columns}
        data={uiData.data}
        loading={uiData.loading}
        name="Currencies"
        // //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      >
        <button className="ml-btn-action ml-fab" onClick={() => navigate("/settings/currencies/add")}>
          <i className="bi bi-plus-lg" aria-hidden="true" />
          Add Currency
        </button>
      </DataTable>
    </MeridianPage>
  );
}
