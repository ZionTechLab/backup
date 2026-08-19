import { useRef, useState,useEffect } from "react";
import { useParams,useNavigate } from "react-router-dom";
import * as Yup from "yup";
import InputField from "../../components/InputField";
import { useFormikBuilder } from "../../helpers/formikBuilder";
import MessageBoxService from "../../services/MessageBoxService";
import {DataGrid} from '../../components/DataGrid';
import ApiService from "./DailyReportService";
import SelectedBusinessPartnerBox from "../BusinessPartners/select-bp";
import sanitizeAmountFields from "../../helpers/sanitizeAmountFields";
import transformDateFields, { todayISO } from "../../helpers/transformDateFields";

import config from "../../config/config";

function AddDailyReport() {  
  const { id } = useParams();
  const navigate = useNavigate();
  const dataGridRef = useRef();
  const [lineItems, setLineItems] = useState([]);
  const [uiData, setUiData] = useState({loading: false, success: false, error: '', data: {} });
  const [uiDataFiltered, setuiDataFiltered] = useState({ VehicleType: [], Vehicle: [] });

  useEffect(() => {

    const fetchUi = async () => {
      setUiData(prev => ({ ...prev, loading: true, error: '', data: {} }));
      const data = await ApiService.getUi();
      setUiData(prev => ({ ...prev, ...data , loading: false }));
      setuiDataFiltered(prev => ({ ...prev,  VehicleType: data.data.VehicleType || []}));
    };
    fetchUi();

    if (id) {
      const fetchTxn = async () => {
        const response = await ApiService.get(id);
        if (response.success) {
          if (response.data) {
            const { lineItems, ...formData } = response.data;
               const normalized = transformDateFields(formData, fields);
            formik.setValues({...normalized});
            setLineItems(lineItems);
            dataGridRef.current.reset(lineItems);
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
    txnDate: {
      name: "txnDate",
      type: "date",
      placeholder: "Transaction Date",
      initialValue: todayISO(),
      validation: Yup.string().required("Transaction Date is required"),
    },    
    partner: {
      name: "partner",
      type: "customer",
      placeholder: "Customer",
      initialValue: "",
      validation: Yup.string().required("Customer is required"),
      isOpen: false,
    },
    operator: {
      name: "operator",
      type: "operator",
      placeholder: "Operator",
      initialValue: "",
      validation: Yup.string().required("Operator is required"),
      isOpen: false,
    },
    helper: {
      name: "helper",
      type: "helper",
      placeholder: "Helper",
      initialValue: "",
      validation: Yup.string().required("Helper is required"),
      isOpen: false,
    },
  
    typeOfMachine: {
      name: "typeOfMachine",
      type: "select",
      placeholder: "Type of Machine",
        dataBinding: {
        data: uiDataFiltered?.VehicleType,
        keyField: "id",
        valueField: "value",
      },
      // initialValue: "",
      validation: Yup.string().required("Type of Machine is required"),
    },
      vehicle: {
      name: "vehicle",
      type: "select",
      placeholder: "Vehicle No",
        dataBinding: {
        data: uiDataFiltered?.Vehicle,
        keyField: "id",
        valueField: "value",
      },
      // initialValue: "",
      validation: Yup.string().required("Vehicle No is required"),
    },
    remarks: {
      name: "remarks",
      type: "textarea",
      placeholder: "Remarks",
      initialValue: "",
    },
    km: {
      name: "km",
      type: "number",
      placeholder: "K.M.",
      initialValue: 0,
    },
    time: {
      name: "time",
      type: "text",
      placeholder: "Time",
      initialValue: 0,
    },
    diesel: {
      name: "diesel",
      type: "text",
      placeholder: "Diesel",
      initialValue: 0,
    },
    certifiedHours: {
      name: "certifiedHours",
      type: "text",
      placeholder: "Certified Hours",
      initialValue: 0,
    },
  };

  const lineItemColumns = [
    { header: "Work Commence Form", field: "description", type: "text", placeholder: "Work Item" },
    { header: "Amount", field: "amount", type: "amount", placeholder: "Amount" },
    { header: "Hours", field: "hours", type: "text", placeholder: "Hours" },
  ];

  const handleSubmit = async (values, { resetForm }) => {
//     if(id)
// {
//    MessageBoxService.show({
//         message: "not available",
//         type: "success",
//         onClose: () => navigate("/daily-report"),
//       });
//       return;
// }
    const sanitizedLineItems = sanitizeAmountFields(lineItems, lineItemColumns);
    const param = { 
      header: { ...values , id: parseInt(id ? id : 0)}, 
      lineItems: sanitizedLineItems,
      isUpdate:id ? true : false
    };
    const response = await ApiService.update({ ...param });
    const { success, data } = response;

    if (success) {
      MessageBoxService.show({
        message: "Daily Report saved successfully!",
        type: "success",
        onClose: () => {
          if (config.features.returnToListAfterSave) {
            navigate("/daily-report");
          } else if (!id && data?.id) {
            navigate(`/daily-report/edit/${data.id}`);
          } else if (!id) {
            resetForm();
            dataGridRef.current.reset();
            setLineItems([]);
          }
        },
      });
    }
  };

  const formik = useFormikBuilder(fields, handleSubmit);

  useEffect(() => {
    const filteredVehicles = (uiData.data.Vehicle || []).filter(
      // eslint-disable-next-line
      (m) => m.parentId == formik.values.typeOfMachine
    );
    setuiDataFiltered((prev) => ({...prev,Vehicle: filteredVehicles}));
    // eslint-disable-next-line
  }, [formik.values.typeOfMachine]);

  const handleDelete = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Are you sure you want to delete this transaction?',
      type: 'danger',
      confirmText: 'Delete',
      cancelText: 'Cancel',
    });

    if (!confirmed) return;

    const response = await ApiService.delete({ id});
    if (response.success) {
      MessageBoxService.show({
        message: "Transaction deleted successfully!",
        type: "success",
        onClose: () => navigate("/daily-report"),
      });
    }
  };



  return (
    <div className="container p-3">
      <form onSubmit={formik.handleSubmit} >
         <div className="card mb-3">

            <div className="card-body">
        <div className="row g-2">
        <InputField {...fields.id} formik={formik} className="col-md-3 col-sm-6"/>
        <InputField {...fields.txnDate} formik={formik} className="col-md-3 col-sm-6"/>
        <SelectedBusinessPartnerBox field={fields.partner} formik={formik} className="col-sm-6"/>
         <InputField {...fields.typeOfMachine} formik={formik} className="col-md-3 col-sm-6"/>
        <InputField {...fields.vehicle} formik={formik} className="col-md-3 col-sm-6"/>
      
        <SelectedBusinessPartnerBox field={fields.operator} formik={formik} className="col-md-3 col-sm-6"/>
        <SelectedBusinessPartnerBox field={fields.helper} formik={formik} className="col-md-3 col-sm-6"/>
        {/* <InputField {...fields.operator} formik={formik} className="col-md-3 col-sm-6"/>
        <InputField {...fields.helper} formik={formik} className="col-md-3 col-sm-6"/> */}
        <div className="col-md-12">
          <DataGrid
            ref={dataGridRef}
            columns={lineItemColumns}
            initialItems={[]}
            onItemsChange={setLineItems}
          />
        </div></div>
         <div className="row g-2">
        <InputField {...fields.remarks} formik={formik} className="col-sm-6"/>
 <div className="col-sm-6 ">
    <div className="row g-2">
        <InputField {...fields.km} formik={formik} className="col-md-6"/>
        <InputField {...fields.time} formik={formik} className="col-md-6"/>
        <InputField {...fields.diesel} formik={formik} className="col-md-6"/>
        <InputField {...fields.certifiedHours} formik={formik} className="col-md-6"/></div>
        </div></div>
        {/* <button type="submit" className="btn btn-primary">Save Report</button> */}
    <div className="d-flex justify-content-end mt-3">
            {id &&( <>
              {/* <button type="button" className="btn btn-outline-secondary me-2" onClick={() => setShowPreview((s) => !s)}>          
                {showPreview ? "Hide Preview" : "Print Preview"}
              </button> */}
              <button type="button" className="btn btn-outline-danger me-2" onClick={() => handleDelete()}>Delete</button>
            </> )}
              <button type="submit" className="btn btn-primary">Save</button>
              
            </div>


    </div></div>
      </form>
    </div>
  );
}

export default AddDailyReport;