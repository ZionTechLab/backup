import { useRef, useState,useEffect } from "react";
import { useParams,useNavigate ,useLocation} from "react-router-dom";
import * as Yup from "yup";
import InputField from "../../components/InputField";
import { useFormikBuilder } from "../../helpers/formikBuilder";
import MessageBoxService from "../../services/MessageBoxService";
import ApiService from "./InvoiceService";
import SelectedBusinessPartnerBox from "../BusinessPartners/select-bp";
import transformDateFields, { todayISO } from "../../helpers/transformDateFields";
import  "./Invoice.css";
 import Modal from "../../components/Modal";
 import InvoicePrintView from "./InvoicePrintView";
import MeridianPage from "../Meridian/MeridianPage";

import config from "../../config/config";

function Invoice() {
  const { id } = useParams();
  const navigate = useNavigate();
  const dataGridRef = useRef();
  const [lineItems, setLineItems] = useState([]);
  const [uiData, setUiData] = useState({loading: false, success: false, error: '', data: {} });
  const location = useLocation(); 
  const [isAdvance, setIsAdvance] = useState(0);
  const [showPreview, setShowPreview] = useState(false);


  useEffect(() => {
   let isAdvance_ = 0;
    if(location.pathname.includes('advance')) {
      isAdvance_=1
      setIsAdvance(1)
    }

   const fetchUi = async () => {
      setUiData(prev => ({ ...prev, loading: true, error: '', data: {} }));
      const data = await ApiService.getUi();
      setUiData(prev => ({ ...prev, ...data , loading: false }));
    };
    fetchUi();

    if (id) {
      const fetchTxn = async () => {
        const response = await ApiService.get(id,isAdvance_?'ADV':'PAY' );
        if (response.success) {
          if (response.data) {
            const { lineItems, ...formData } = response.data;
            // normalize all date fields using the fields descriptor
            const normalized = transformDateFields(formData, fields);
            formik.setValues({ ...normalized });
            // setLineItems(lineItems);
            // dataGridRef.current.reset(lineItems);
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
      // validation: Yup.string().required("Transaction No is required"),
      disabled: true,
    },
    txnNoDisplay: {
      name: "txnNoDisplay",
      type: "text",
      placeholder: "Transaction No",
      initialValue: "<Auto>",
      // validation: Yup.string().required("Transaction No is required"),
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
        type: "Employee",
      placeholder: "Employee",
      initialValue: "",
      validation: Yup.string().required("Employee is required"),
      isOpen: false,
    },
       remarks: {
      name: "remarks",
      type: "textarea",
      placeholder: "Description",
      initialValue: "",
      validation: Yup.string().required("Description is required"),
    }, 
    ref1: {
      name: "ref1",
      type: "select",
      placeholder: "Type of Vehicle",
      dataBinding: {
        data: uiData.data.VehicleType,
        keyField: "id",
        valueField: "value",
      },

      validation: isAdvance ? undefined : Yup.number().required("Type of Vehicle is required")
    },
    amount: {
      name: "amount",
      type: "amount",
      placeholder: "Amount",
      initialValue: 0,
      validation: Yup.number()
        .typeError("Amount must be a number")
        .positive("Amount must be greater than 0"),
      // disabled: true,
      labelOnTop: false,
    },
    // taxAmount: {
    //   name: "taxAmount",
    //   type: "amount",
    //   placeholder: "Vat (18 %)",
    //   initialValue: 0,
    //   validation: Yup.number()
    //     .typeError("Vat must be a number"),
    //     // .positive("Vat must be greater than 0"),
    //   disabled: true,
    //   labelOnTop: false,
    // },
    // advance: {
    //   name: "advance",
    //   type: "amount",
    //   placeholder: "Advance",
    //   initialValue: 0,
    //   validation: Yup.number().typeError("Advance must be a number"),
    //   labelOnTop: false,
    // },
    // totalAmount: {
    //   name: "totalAmount",
    //   type: "amount",
    //   placeholder: "Total Amount",
    //   initialValue: 0,
    //   validation: Yup.number()
    //   .typeError("Total Amount must be a number")
    //   .positive("Amount must be greater than 0"),
    //   disabled: true,
    //   labelOnTop: false,
    // },
  };


  const handleSubmit = async (values, { resetForm } ) => {
if(id)
{
   MessageBoxService.show({
        message: "not available",
        type: "success",
        onClose: () => navigate(isAdvance ? "/advance" : "/payment"),
      });
      return;
}
    const param = { 
      header: { ...values ,txnNoDisplay:undefined, id: parseInt(id ? id : 0)}, 
      isUpdate:id ? true : false
      , isAdvance
    };
    const response = await ApiService.update_advance({ ...param });
    const { success, data } = response;

    if (success) {
      MessageBoxService.show({
        message: `${isAdvance ? "Advance" : "payment"} saved successfully!`,
        type: "success",
        onClose: () => {
          if (config.features.returnToListAfterSave) {
            navigate(isAdvance ? "/advance" : "/payment");
          } else if (!id && data?.id) {
            navigate(isAdvance ? `/advance/edit/${data.id}` : `/payment/edit/${data.id}`);
          } else if (!id) {
            resetForm();
            dataGridRef.current?.reset();
            setLineItems([]);
          }
        },
      });
    }
  };

  const formik = useFormikBuilder(fields, handleSubmit);



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
    const taxAmount = isAdvance ? total * 0.18 : 0;
    formik.setFieldValue("taxAmount", taxAmount);
    formik.setFieldValue(
      "totalAmount",
      total + taxAmount - (parseFloat(formik.values.advance) || 0)
    );
  }
  const handleDelete = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Are you sure you want to delete this transaction?',
      type: 'danger',
      confirmText: 'Delete',
      cancelText: 'Cancel',
    });

    if (!confirmed) return;

    const response = await ApiService.deleteAdvance({ id, txnType: (isAdvance ? 'ADV' : 'PAY' )});
    if (response.success) {
      MessageBoxService.show({
        message: "Transaction deleted successfully!",
        type: "success",
        onClose: () => navigate(isAdvance ? "/advance" : "/payment"),
      });
    }
  };
  const label = isAdvance ? "Advance" : "Payment";
  return (
    <MeridianPage
      title={`${id ? "Edit" : "New"} ${label}`}
      backTo={isAdvance ? "/advance" : "/payment"}
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
          <button type="submit" form="advance-form" className="ml-btn-action ml-fab" disabled={uiData.loading}>
            <i className="bi bi-check-lg" aria-hidden="true" />
            Save
          </button>
        </>
      }
    >
      <form id="advance-form" onSubmit={formik.handleSubmit}>
        <div className="ml-form-section">
          <div className="row g-2">
            <InputField {...fields.txnNoDisplay} formik={formik} className={isAdvance ? "col-md-6 col-sm-6" : "col-md-3 col-sm-6"} />
            <InputField {...fields.txnDate} formik={formik} className={isAdvance ? "col-md-6 col-sm-6" : "col-md-3 col-sm-6"} />
            {isAdvance ? null : (<InputField {...fields.ref1} formik={formik} className="col-sm-6" />)}
            <SelectedBusinessPartnerBox field={fields.partner} formik={formik} />
            <InputField {...fields.remarks} formik={formik} />
          </div>
          <div className="row justify-content-end mt-3">
            <InputField {...fields.amount} formik={formik} className="col-md-6 text-end" />
          </div>
        </div>
      </form>

      <Modal show={showPreview} onClose={() => setShowPreview(false)} title="Preview">
        <InvoicePrintView formikValues={formik.values} lineItems={lineItems} isTaxInvoice={isAdvance} txnType={isAdvance ? 'ADV' : 'PAY'} id={id} fields={fields} />
        <div className="mt-3 d-flex justify-content-end">
          <button className="btn btn-secondary me-2" onClick={() => setShowPreview(false)}>Close</button>
          <button className="btn btn-primary" onClick={() => window.print()}>Print</button>
        </div>
      </Modal>
    </MeridianPage>
  );
}

export default Invoice;