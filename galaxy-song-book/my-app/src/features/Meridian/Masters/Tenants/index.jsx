import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { DataTable } from "../../../../components/DataTable/DataTable";
import MeridianPage from "../../MeridianPage";
import tenantService from "./service";

export default function Tenants() {
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, data: [] });

  useEffect(() => { fetchAll(); }, []);

  const fetchAll = async () => {
    setUiData((prev) => ({ ...prev, loading: true, data: [] }));
    const result = await tenantService.getAll();
    setUiData({ loading: false, data: result.success ? result.data : [] });
  };

  const columns = [
    { header: "Tenant ID", field: "tenantId", isId: true },
    { header: "Name", field: "tenantName" },
    { header: "Legal Name", field: "legalName" },
    { header: "Email", field: "email" },
    { header: "Phone", field: "phone" },
    { header: "City", field: "city" },
    { header: "Country", field: "country" },
    { header: "Status", field: "status" },
    {
      header: "",
      field: "actions",
      isAction: true,
      actionTemplate: (row) => (
        <button
          aria-label="Edit"
          className="btn btn-outline-primary btn-sm btn-borderless"
          onClick={() => navigate(`/settings/tenants/edit/${row.tenantId}`)}
        >
          <i className="bi bi-pencil" />
        </button>
      ),
    },
  ];

  return (
    <MeridianPage title="Tenants">
      <DataTable
        data={uiData.data}
        columns={columns}
        loading={uiData.loading}
        name="Tenants"
        // //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      >
         <button
          className="ml-btn-action  ml-fab"
          onClick={() => navigate("/settings/tenants/add")}
        >
          <i className="bi bi-plus-lg" aria-hidden="true" />
          Add Tenant
        </button>
      </DataTable>
    </MeridianPage>
  );
}