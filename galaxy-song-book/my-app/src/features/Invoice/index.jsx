import { useEffect, useState } from "react";
import { useNavigate, useLocation } from "react-router-dom";
import { DataTable } from "../../components/DataTable/DataTable";
import MeridianPage from "../Meridian/MeridianPage";
import MessageBoxService from "../../services/MessageBoxService";
import ApiService from "./InvoiceService";

export default function InvoiceIndex() {
  const navigate = useNavigate();
  const location = useLocation();
  const isTax = location.pathname === "/tax-invoice";
  const txnType = isTax ? "TAX" : "NT";
  const [uiData, setUiData] = useState({ loading: true, data: [], error: "" });

  useEffect(() => { fetchAll(); /* eslint-disable-next-line */ }, [location.pathname]);

  const fetchAll = async () => {
    setUiData((prev) => ({ ...prev, loading: true, data: [] }));
    const { success, data } = await ApiService.getAll(txnType);
    setUiData((prev) => ({ ...prev, data: success ? data : [], loading: false }));
  };

  const handleDelete = async (id) => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: "Delete this invoice? This cannot be undone.",
      type: "danger",
      confirmText: "Delete",
      cancelText: "Cancel",
    });
    if (!confirmed) return;
    const response = await ApiService.delete({ id, txnType });
    if (response.success) {
      MessageBoxService.show({ message: "Invoice deleted.", type: "success", onClose: fetchAll });
    }
  };

  const columns = [
    { header: "Invoice No",   field: "txnNoDisplay", class: "text-nowrap" },
    { header: "Date",         field: "txnDate",      class: "text-nowrap", type: "date" },
    { header: "Customer",     field: "partnerName",  class: "text-nowrap" },
    { header: "Total Amount", field: "totalAmount",  class: "text-nowrap text-end", type: "currency" },
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
    <MeridianPage title={isTax ? "Tax Invoices" : "Invoices"}>
      <DataTable
        columns={columns}
        data={uiData.data}
        loading={uiData.loading}
        name={isTax ? "TaxInvoices" : "Invoices"}
        // //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      >
        <button className="ml-btn-action ml-fab" onClick={() => navigate(isTax ? "/tax-invoice/add" : "/invoice/add")}>
          <i className="bi bi-plus-lg" aria-hidden="true" />
          New Invoice
        </button>
      </DataTable>
    </MeridianPage>
  );
}
