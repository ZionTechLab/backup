import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { DataTable } from "../../../../components/DataTable/DataTable";
import MeridianPage from "../../MeridianPage";
import ApiService from "./service";

function buildColumns(navigate) {
  return [
    { header: "Account Type", field: "accountType" },
    { header: "Type Name",    field: "typeName" },
    { header: "Sort Order",   field: "sortOrder" },
    { header: "Active",       field: "isActive", type: "boolean", class: "text-center" },
    {
      header: "",
      field: "actions",
      isAction: true,
      actionTemplate: (row) => (
        <button aria-label="Edit" className="btn btn-outline-primary btn-sm btn-borderless" onClick={() => navigate(`/settings/account-types/edit/${row.accountType}`)}>
          <i className="bi bi-pencil" />
        </button>
      ),
    },
  ];
}

export default function AccountTypes() {
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, data: [], error: "" });
  const columns = buildColumns(navigate);

  useEffect(() => { fetchAll(); }, []);

  const fetchAll = async () => {
    setUiData(prev => ({ ...prev, loading: true, data: [] }));
    const { success, data } = await ApiService.getAll();
    setUiData(prev => ({ ...prev, data: success ? data : [], loading: false }));
  };

  return (
    <MeridianPage title="Account Types">
      <DataTable
        columns={columns}
        data={uiData.data}
        loading={uiData.loading}
        name="AccountTypes"
        // //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      >
        <button className="ml-btn-action ml-fab" onClick={() => navigate("/settings/account-types/add")}>
          <i className="bi bi-plus-lg" aria-hidden="true" />
          Add Account Type
        </button>
      </DataTable>
    </MeridianPage>
  );
}
