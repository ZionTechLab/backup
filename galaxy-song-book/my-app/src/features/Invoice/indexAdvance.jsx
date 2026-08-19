import { useEffect, useState } from "react";
import { useNavigate, useLocation } from "react-router-dom";
import { DataTable } from "../../components/DataTable/DataTable";
import MeridianPage from "../Meridian/MeridianPage";
import MessageBoxService from "../../services/MessageBoxService";
import ApiService from "./InvoiceService";

export default function AdvanceIndex() {
  const navigate = useNavigate();
  const location = useLocation();
  const isAdvance = location.pathname === "/advance";
  const txnType = isAdvance ? "ADV" : "PAY";
  const [uiData, setUiData] = useState({ loading: true, data: [], error: "" });

  useEffect(() => { fetchAll(); /* eslint-disable-next-line */ }, [location.pathname]);

  const fetchAll = async () => {
    setUiData((prev) => ({ ...prev, loading: true, data: [] }));
    const { success, data } = await ApiService.getAll(txnType);
    setUiData((prev) => ({ ...prev, data: success ? data : [], loading: false }));
  };

  const handleDelete = async (id) => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: "Delete this transaction? This cannot be undone.",
      type: "danger",
      confirmText: "Delete",
      cancelText: "Cancel",
    });
    if (!confirmed) return;
    const response = await ApiService.deleteAdvance({ id, txnType });
    if (response.success) {
      MessageBoxService.show({ message: "Transaction deleted.", type: "success", onClose: fetchAll });
    }
  };

  const columns = [
    { header: isAdvance ? "Advance No" : "Payment No", field: "txnNoDisplay", class: "text-nowrap" },
    { header: "Date", field: "txnDate", class: "text-nowrap", type: "date" },
    ...(!isAdvance ? [{ header: "Vehicle", field: "Vehicle", class: "text-nowrap" }] : []),
    { header: "Employee", field: "partnerName", class: "text-nowrap" },
    { header: "Total Amount", field: "totalAmount", class: "text-nowrap text-end", type: "currency" },
    {
      header: "", field: "actions", isAction: true,
      actionTemplate: (row) => (
        <div className="d-flex gap-1">
          <button aria-label="Edit" className="btn btn-outline-primary btn-sm btn-borderless"
            onClick={() => navigate(`${location.pathname}/edit/${row.id}`)}>
            <i className="bi bi-pencil" />
          </button>
          <button aria-label="Delete" className="btn btn-outline-danger btn-sm btn-borderless"
            onClick={() => handleDelete(row.id)}>
            <i className="bi bi-trash" />
          </button>
        </div>
      ),
    },
  ];

  return (
    <MeridianPage title={isAdvance ? "Advances" : "Payments"}>
      <DataTable
        columns={columns}
        data={uiData.data}
        loading={uiData.loading}
        name={isAdvance ? "Advances" : "Payments"}
        // //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      >
        <button className="ml-btn-action ml-fab" onClick={() => navigate(isAdvance ? "/advance/add" : "/payment/add")}>
          <i className="bi bi-plus-lg" aria-hidden="true" />
          {isAdvance ? "New Advance" : "New Payment"}
        </button>
      </DataTable>
    </MeridianPage>
  );
}
