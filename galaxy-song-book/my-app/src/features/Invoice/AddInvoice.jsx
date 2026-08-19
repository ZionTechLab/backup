import { useRef, useState,useEffect } from "react";
import { useParams,useNavigate ,useLocation} from "react-router-dom";
import * as Yup from "yup";
import InputField from "../../components/InputField";
import { useFormikBuilder } from "../../helpers/formikBuilder";
import MessageBoxService from "../../services/MessageBoxService";
// import DataGrid from "../../components/DataGrid";
import {DataGrid} from '../../components/DataGrid';
import ApiService from "./InvoiceService";
import SelectedBusinessPartnerBox from "../BusinessPartners/select-bp";
import sanitizeAmountFields from "../../helpers/sanitizeAmountFields";
import transformDateFields, { todayISO } from "../../helpers/transformDateFields";
import  "./Invoice.css";
import Modal from "../../components/Modal";
import InvoicePrintView from "./InvoicePrintView";
import MeridianPage from "../Meridian/MeridianPage";
import config from "../../config/config";

const lineItemColumns = [
  { header: "Description", field: "description", type: "text", placeholder: "Description" },
  { header: "Amount", field: "amount", type: "amount", placeholder: "Amount", width: "25%" },
];

function AddInvoice() {
  const { id } = useParams();
  const navigate = useNavigate();
  const dataGridRef = useRef();
  const [lineItems, setLineItems] = useState([]);
  const [uiData, setUiData] = useState({loading: false, success: false, error: '', data: {} });
  const location = useLocation(); 
  const [isTaxInvoice, setIsTaxInvoice] = useState(false);
  const [showPreview, setShowPreview] = useState(false);
  const [uiDataFiltered, setuiDataFiltered] = useState({ VehicleType: [], Vehicle: [] });
 
  useEffect(() => {
   let isTaxInvoice_ = 0;
    if(location.pathname.includes('tax-invoice')) {
      isTaxInvoice_=1
      setIsTaxInvoice(true)
    }

   const fetchUi = async () => {
      setUiData(prev => ({ ...prev, loading: true, error: '', data: {} }));
      const data = await ApiService.getUi();
      setUiData(prev => ({ ...prev, ...data , loading: false }));
      setuiDataFiltered(prev => ({ ...prev,  VehicleType: data.data.VehicleType || []}));
    };
    fetchUi();

    if (id) {
      const fetchTxn = async () => {
        const response = await ApiService.get(id,isTaxInvoice_?'TAX':'NT');
        if (response.success) {
          if (response.data) {
            const { lineItems, ...formData } = response.data;
            const normalized = transformDateFields(formData, fields);
            formik.setValues({ ...normalized });
            dataGridRef.current.reset(lineItems); // fires onItemsChange ? setLineItems
          }
        }
      };
      fetchTxn();
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);
 
  const fields = {
    id: {
      name: "id",
      type: "text",
      placeholder: "Transaction No",
      initialValue: "<Auto>",
      disabled: true,
      
    },
    txnNoDisplay: {
      name: "txnNoDisplay",
      type: "text",
      placeholder: "Transaction No",
      initialValue: "<Auto>",
      disabled: true,
    },
    txnDate: {
      name: "txnDate",
      type: "date",
      placeholder: "Transaction Date",
      initialValue: todayISO(),
      validation: Yup.string().required("Transaction Date is required"),
    },
    partner: {
      name: "partner",
      type: "Customer",
      placeholder : "Customer",
      initialValue: "",
      validation: Yup.string().required("Customer is required"),
      isOpen: false,
    },
    ref1: {
      name: "ref1",
      type: "select",
      placeholder: "Type of Vehicle/Machine",
      dataBinding: {
        data: uiDataFiltered?.VehicleType,
        keyField: "id",
        valueField: "value",
      },

      validation: isTaxInvoice ? undefined : Yup.number().required("Type of Vehicle/Machine is required")
    },
      ref2: {
      name: "ref2",
      type: "select",
      placeholder: "Vehicle",
      dataBinding: {
        data: uiDataFiltered?.Vehicle,
        keyField: "id",
        valueField: "value",
      },

      validation: isTaxInvoice ? undefined : Yup.number().required("Vehicle is required")
    },
    amount: {
      name: "amount",
      type: "amount",
      placeholder: "Amount",
      initialValue: 0,
      validation: Yup.number()
        .typeError("Amount must be a number")
        .positive("Amount must be greater than 0"),
      disabled: true,
      labelOnTop: false,
    },
    taxAmount: {
      name: "taxAmount",
      type: "amount",
      placeholder: "Vat (18 %)",
      initialValue: 0,
      validation: Yup.number()
        .typeError("Vat must be a number"),
      disabled: true,
      labelOnTop: false,
    },
    advance: {
      name: "advance",
      type: "amount",
      placeholder: "Advance",
      initialValue: 0,
      validation: Yup.number().typeError("Advance must be a number"),
      labelOnTop: false,
    },
    totalAmount: {
      name: "totalAmount",
      type: "amount",
      placeholder: "Total Amount",
      initialValue: 0,
      validation: Yup.number()
      .typeError("Total Amount must be a number")
      .positive("Amount must be greater than 0"),
      disabled: true,
      labelOnTop: false,
    },
  };

  const handleSubmit = async (values, { resetForm } ) => {
if(id)
{
   MessageBoxService.show({
        message: "not available",
        type: "success",
        onClose: () => navigate(isTaxInvoice ? "/tax-invoice" : "/invoice"),
      });
      return;
}
    const filledLineItems = lineItems.filter(item => item.description || item.amount);
    const sanitizedLineItems = sanitizeAmountFields(filledLineItems, lineItemColumns);
    const param = { 
      header: { ...values ,txnNoDisplay:undefined, id: parseInt(id ? id : 0)}, 
      lineItems: sanitizedLineItems,
      isUpdate:id ? true : false
      , isTaxInvoice
    };
    const response = await ApiService.update({ ...param });
    const { success, data } = response;

    if (success) {
      MessageBoxService.show({
        message: "Invoice saved successfully!",
        type: "success",
        onClose: () => {
          if (config.features.returnToListAfterSave) {
            navigate(isTaxInvoice ? "/tax-invoice" : "/invoice");
          } else if (!id && data?.id) {
            navigate(isTaxInvoice ? `/tax-invoice/edit/${data.id}` : `/invoice/edit/${data.id}`);
          } else if (!id) {
            resetForm();
            dataGridRef.current.reset();
          }
        },
      });
    }
  };

  const formik = useFormikBuilder(fields, handleSubmit);

  useEffect(() => {
    const filteredVehicles = (uiData.data.Vehicle || []).filter(
      // eslint-disable-next-line
      (m) => m.parentId == formik.values.ref1
    );
    setuiDataFiltered((prev) => ({...prev,Vehicle: filteredVehicles}));
    // eslint-disable-next-line
  }, [formik.values.ref1]);

  useEffect(() => {
    calculateTotal();
    // eslint-disable-next-line
  }, [lineItems,formik.values.advance]);
   
  function calculateTotal() {
    const total = lineItems.reduce(
      (sum, item) => sum + (parseFloat( String(item.amount).replace(/[^\d.]/g, '')   )|| 0),
      0
    );

    formik.setFieldValue("amount", total);
    const taxAmount = isTaxInvoice ? total * 0.18 : 0;
    formik.setFieldValue("taxAmount", taxAmount);
    formik.setFieldValue(
      "totalAmount",
      total + taxAmount - (parseFloat(formik.values.advance) || 0)
    );
  }
  
  const handleDelete = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Are you sure you want to delete this invoice?',
      type: 'danger',
      confirmText: 'Delete',
      cancelText: 'Cancel',
    });

    if (!confirmed) return;

    const response = await ApiService.delete({ id, txnType: (isTaxInvoice ? 'TAX' : 'NT' )});
    if (response.success) {
      MessageBoxService.show({
        message: "Invoice deleted successfully!",
        type: "success",
        onClose: () => navigate(isTaxInvoice ? "/tax-invoice" : "/invoice"),
      });
    }
  };

  return (
    <MeridianPage
      title={`${id ? "Edit" : "New"} ${isTaxInvoice ? "Tax Invoice" : "Invoice"}`}
      backTo={isTaxInvoice ? "/tax-invoice" : "/invoice"}
      cardClass="ml-form-card"
      actions={
        <>
          {id && (
            <>
              <button type="button" className="ml-btn-ghost ml-fab-2" onClick={() => setShowPreview((s) => !s)}>
                <i className="bi bi-printer" aria-hidden="true" />
                {showPreview ? "Hide Preview" : "Preview"}
              </button>
              <button type="button" className="ml-btn-ghost ml-btn-danger-ghost ml-fab-1" onClick={handleDelete}>
                <i className="bi bi-trash" aria-hidden="true" />
                Delete
              </button>
            </>
          )}
          <button type="submit" form="invoice-form" className="ml-btn-action ml-fab" disabled={uiData.loading}>
            <i className="bi bi-check-lg" aria-hidden="true" />
            Save
          </button>
        </>
      }
    >
      <form id="invoice-form" onSubmit={formik.handleSubmit}>
        <div className="ml-form-section">
          <div className="row g-2">
            <InputField {...fields.txnNoDisplay} formik={formik} className={isTaxInvoice ? "col-md-6 col-sm-6" : "col-md-3 col-sm-6"} />
            <InputField {...fields.txnDate} formik={formik} className={isTaxInvoice ? "col-md-6 col-sm-6" : "col-md-3 col-sm-6"} />
            {isTaxInvoice ? null : (<InputField {...fields.ref1} formik={formik} className="col-sm-3" />)}
            {isTaxInvoice ? null : (<InputField {...fields.ref2} formik={formik} className="col-sm-3" />)}
            <SelectedBusinessPartnerBox field={fields.partner} formik={formik} />

            <DataGrid
              ref={dataGridRef}
              initialItems={lineItems}
              columns={lineItemColumns}
              onItemsChange={setLineItems}
            />
          </div>
          <div className="row justify-content-end">
            <InputField {...fields.amount} formik={formik} className="col-md-6 text-end" />
          </div>
          {isTaxInvoice ? (
            <div className="row justify-content-end">
              <InputField {...fields.taxAmount} formik={formik} className="col-md-6 text-end" />
            </div>
          ) : null}
          {isTaxInvoice ? null : (
            <div className="row justify-content-end">
              <InputField {...fields.advance} formik={formik} className="col-md-6 text-end" />
            </div>
          )}
          <div className="row justify-content-end">
            <InputField {...fields.totalAmount} formik={formik} className="col-md-6 text-end" />
          </div>
        </div>
      </form>

      <Modal show={showPreview} onClose={() => setShowPreview(false)} title="Invoice Preview">
        <InvoicePrintView formikValues={formik.values} lineItems={lineItems} isTaxInvoice={isTaxInvoice} txnType={isTaxInvoice ? 'TAX' : 'NT'} id={id} fields={fields} />
        <div className="mt-3 d-flex justify-content-end">
          <button className="btn btn-secondary me-2" onClick={() => setShowPreview(false)}>Close</button>
          <button className="btn btn-primary" onClick={() => window.print()}>Print</button>
        </div>
      </Modal>
    </MeridianPage>
  );
}

export default AddInvoice;