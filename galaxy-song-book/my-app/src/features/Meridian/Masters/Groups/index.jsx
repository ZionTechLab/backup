import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { DataTable } from "../../../../components/DataTable/DataTable";
import MeridianPage from "../../MeridianPage";
import groupService from "./service";


function buildColumns(navigate) {
  return [
       { header: "Group ID",      field: "groupId", isId: true },
    { header: "Group Name",    field: "groupName" },
    { header: "Tenant",        field: "tenantName" },
    { header: "Base Currency", field: "baseCurrencyCode" },
    {
      header: "",
      field: "actions",
      isAction: true,
      actionTemplate: (row) => (
        <button aria-label="Edit" className="btn btn-outline-primary btn-sm btn-borderless" onClick={() => navigate(`/settings/groups/edit/${row.groupId}`)}>
          <i className="bi bi-pencil" />
        </button>
      ),
    },
  ];
}

export default function Groups() {
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, data: [], error: "" });
  const columns = buildColumns(navigate);

  useEffect(() => { fetchAll(); }, []);

  const fetchAll = async () => {
    setUiData(prev => ({ ...prev, loading: true, data: [] }));
    const { success, data } = await groupService.getAll();
    setUiData(prev => ({ ...prev, data: success ? data : [], loading: false }));
  };

  return (
    <MeridianPage title="Groups">
      <DataTable
        columns={columns}
        data={uiData.data}
        loading={uiData.loading}
        name="Groups"
        // //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      >
        <button className="ml-btn-action ml-fab" onClick={() => navigate("/settings/groups/add")}>
          <i className="bi bi-plus-lg" aria-hidden="true" />
          Add Group
        </button>
      </DataTable>
    </MeridianPage>
  );
}
