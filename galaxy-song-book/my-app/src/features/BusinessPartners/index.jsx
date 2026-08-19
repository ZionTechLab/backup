import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { DataTable } from "../../components/DataTable/DataTable";
import MeridianPage from "../Meridian/MeridianPage";
import ApiService from "./PartnerService";

const TYPE_LABELS = { C: "Customer", S: "Supplier", D: "Driver", O: "Operator", H: "Helper", E: "Staff" };

function buildColumns(navigate) {
  return [
    { header: "Partner ID", field: "businessPartnerId", isId: true },
    { header: "Code",       field: "partnerCode" },
    { header: "Name",       field: "partnerName",   class: "text-nowrap" },
    { header: "Full Name",  field: "fullName",      class: "text-nowrap" },
    { header: "NIC",        field: "nic",           class: "text-nowrap" },
    { header: "Contact",    field: "contactPerson", class: "text-nowrap" },
    { header: "Email",      field: "email" },
    { header: "Phone",      field: "phone1",        class: "text-nowrap" },
    {
      header: "Types", field: "partnerTypes",
      render: (row) => (row.partnerTypes || "").split(",").filter(Boolean).map((c) => TYPE_LABELS[c] || c).join(", "),
    },
    { header: "Active", field: "isActive", type: "boolean", class: "text-center" },
    {
      header: "", field: "actions", isAction: true,
      actionTemplate: (row) => (
        <button
          aria-label="Edit"
          className="btn btn-outline-primary btn-sm btn-borderless"
          onClick={() => navigate(`/business-partner/edit/${row.businessPartnerId}`)}
        >
          <i className="bi bi-pencil" />
        </button>
      ),
    },
  ];
}

export default function BusinessPartnerIndex() {
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, data: [], error: "" });
  const columns = buildColumns(navigate);

  useEffect(() => { fetchAll(); }, []);

  const fetchAll = async () => {
    setUiData((prev) => ({ ...prev, loading: true, data: [] }));
    const { success, data } = await ApiService.getAll();
    setUiData((prev) => ({ ...prev, data: success ? data : [], loading: false }));
  };

  return (
    <MeridianPage title="Business Partners">
      <DataTable
        columns={columns}
        data={uiData.data}
        loading={uiData.loading}
        name="BusinessPartners"
        // //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      >
        <button className="ml-btn-action ml-fab" onClick={() => navigate("/business-partner/add")}>
          <i className="bi bi-plus-lg" aria-hidden="true" />
          Add Partner
        </button>
      </DataTable>
    </MeridianPage>
  );
}
