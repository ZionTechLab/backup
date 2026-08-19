import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import * as Yup from "yup";
import { useFormikBuilder, FieldsRenderer } from "../../helpers/formikBuilder";
import ApiService from "./service";
import MessageBoxService from "../../services/MessageBoxService";
import Tabs from "../../components/Tabs";
import transformDateFields, { todayISO } from "../../helpers/transformDateFields";
import { useModalService } from "../../helpers/ModalService";
import InvoicePrintView from "./InvoicePrintView";
import config from "../../config/config";

function TabPlaceholder({ title, description, enhancements }) {
  return (
    <div className="card">
      <div className="card-body">
        <h5 className="card-title mb-3">{title}</h5>
        <p className="text-muted mb-0">{description}</p>
        {enhancements && (
          <div className="mt-3">
            <p className="small text-muted mb-1">Future enhancements:</p>
            <ul className="small mb-0">
              {enhancements.map((item) => <li key={item}>{item}</li>)}
            </ul>
          </div>
        )}
      </div>
    </div>
  );
}

function AddJobRegistration() {
  const { id } = useParams();
  const navigate = useNavigate();
  const [activeTab, setActiveTab] = useState("create");
  const [uiData, setUiData] = useState({
    loading: false,
    success: false,
    error: "",
    data: {},
  });
    const { openModal, closeModal } = useModalService();
  const [uiDataFiltered, setuiDataFiltered] = useState({
    VehicleType: [],
    Vehicle: [],
  });

  const showModal = (tabId = activeTab) => {
    openModal({
      title: "Select Business Partner",
      component: (
        // lineItems={lineItems} isTaxInvoice={isTaxInvoice} txnType={isTaxInvoice?'TAX':'NT'}
        <> <InvoicePrintView formikValues={formik.values}  id={id} fields={fields} />
        <div className="mt-3 d-flex justify-content-end">
          <button className="btn btn-secondary me-2" onClick={closeModal}>Close</button>
          <button className="btn btn-primary" onClick={() => window.print()}>Print</button>
        </div>
        </>
      ),
    });
  };


  // const [jobTags, setJobTags] = useState([]);

  useEffect(() => {
    const fetchUi = async () => {
      setUiData((prev) => ({ ...prev, loading: true, error: "", data: {} }));
      const data = await ApiService.getUi();
      setUiData((prev) => ({ ...prev, ...data, loading: false }));
      setuiDataFiltered((prev) => ({ ...prev, ...data }));
    };
    fetchUi();

    if (id) {
      const fetchTxn = async () => {
        const response = await ApiService.get(id);
        if (response.success) {
          if (response.data) {
            const normalized = transformDateFields(response.data, fields);
            formik.setValues({ ...normalized });
          }
        }
      };
      fetchTxn();
    }
  }, [id]);

  const fields = {
    id: {
      name: "id",
      type: "text",
      placeholder: "Job ID",
      initialValue: "<Auto>",
      disabled: true,
      className: "col-sm-4 col-12",
    },
    txnDate: {
      name: "txnDate",
      type: "date",
      placeholder: "Intake Date",
      initialValue: todayISO(),
      validation: Yup.string().required("Intake Date is required"),
      className: "col-sm-4 col-12",
    },
    status: {
      name: "status",
      type: "select",
      placeholder: "Status",
      dataBinding: {
        data: uiData?.data?.JobStatus,
        keyField: "id",
        valueField: "value",
      },
      initialValue: 1,
      className: "col-sm-4 col-12",
    },
    partner: {
      name: "partner",
      type: "partner-select",
      placeholder: "Partner",
      initialValue: -1,
      validation: Yup.number().required("Partner is required").min(0, "Invalied Partner"),
      className: "col-12",
    },
    ref3: {
      name: 'ref3',
      type: 'text',
      placeholder: 'Delivered By',
      initialValue: '',
      validation: Yup.string().required('Delivered By is required'),
      className: 'col-12',
    },
    ref1: {
      name: "ref1",
      type: "text",
      placeholder: "Item",
      initialValue: "",
      validation: Yup.string().required("Item is required"),
      className: "col-12",
    },
    ref2: {
      name: "ref2",
      type: "text",
      placeholder: "Serial Number",
      initialValue: "",
      className: "col-12",
    },
    description: {
      name: "description",
      type: "textarea",
      placeholder: "Nature of Fault",
      initialValue: "",
      validation: Yup.string().required("Nature of Fault is required"),
      className: "col-12",
    },
    remarks: {
      name: "remarks",
      type: "textarea",
      placeholder: "Remarks",
      initialValue: "",
      className: "col-12",
    },
    jobTags: {
      name: "jobTags",
      type: "switch-group",
      placeholder: "Items / Accessories",
      initialValue: [],
      className: "col-12",
      dataBinding: {
        data: uiData?.data?.JobTags,
      },
    },
  };

  // const handleJobTagChange = (updatedTags) => {
  //   setJobTags(updatedTags);
  // };

  const handleSubmit = async (values, { resetForm }) => {
    const param = {
      header: { ...values, id: parseInt(id ? id : 0) },
      isUpdate: id ? true : false,
    };
    const response = await ApiService.update({ ...param });
    const { success, data } = response;

    if (success) {
      MessageBoxService.show({
        message: "Job saved successfully!",
        type: "success",
        onClose: () => {
          if (config.features.returnToListAfterSave) {
            navigate("/job-registration");
          } else if (!id && data?.id) {
            navigate(`/job-registration/edit/${data.id}`);
          } else if (!id) {
            resetForm();
          }
        },
      });
    }
  };

  const formik = useFormikBuilder(fields, handleSubmit);

  const handleDelete = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: "Are you sure you want to delete this Job?",
      type: "danger",
      confirmText: "Delete",
      cancelText: "Cancel",
    });

    if (!confirmed) return;

    const response = await ApiService.delete({ id });
    if (response.success) {
      MessageBoxService.show({
        message: "Job deleted successfully!",
        type: "success",
        onClose: () => navigate("/job-registration"),
      });
    }
  };

  const tabs = [
    { id: "create", label: "Create Job" },
    { id: "inspection", label: "Technical Inspection", disabled: !id },
    { id: "service-note", label: "Service Note", disabled: !id },
    { id: "qa", label: "QA", disabled: !id },
    { id: "completion", label: "Job Completion", disabled: !id },
  ];

  return (
    <div className="container">
      <Tabs tabs={tabs} activeTab={activeTab} onTabChange={setActiveTab}>
        {activeTab === "create" && (
          <>
            <form onSubmit={formik.handleSubmit} className=" g-3">
              <div className="card mb-3">
                <div className="card-body">
                  <div className="row g-2">
                    <FieldsRenderer
                      fields={fields}
                      formik={formik}
                      inputProps={{ autocomplete: "off" }}
                    />
                  </div>
                  <div className="d-flex justify-content-end mt-3">
                    {id && (
                      <>
                        <button type="button" className="btn btn-outline-secondary me-2" onClick={() => showModal()}>Print Preview</button>
                        <button type="button" className="btn btn-outline-danger me-2" onClick={() => handleDelete()}>Delete</button>
                      </>)}
                    <button type="submit" className="btn btn-primary" disabled={uiData.loading}>
                      Save
                    </button>
                  </div>
                </div>
              </div>
            </form>
            {id &&
              ""
              // <JobLogSection jobId={id} />
            }
          </>
        )}
        {activeTab === "inspection" && (
          <TabPlaceholder
            title="Technical Inspection"
            description="Placeholder for technical inspection details (e.g., diagnostics, components tested, findings). Add fields here once specs are ready."
          />
        )}
        {activeTab === "service-note" && (
          <TabPlaceholder
            title="Service Note"
            description="Placeholder for service notes (e.g., actions taken, parts replaced, labor time). Implement form fields similarly to Create Job tab."
          />
        )}
        {activeTab === "qa" && (
          <TabPlaceholder
            title="Quality Assurance"
            description="Placeholder for QA checklist / verification steps before completion. Include pass/fail toggles or checklist later."
          />
        )}
        {activeTab === "completion" && (
          <TabPlaceholder
            title="Job Completion"
            description="Finalize the job, capture completion remarks, delivery info, and generate any closing documents."
            enhancements={["Mark job status as Completed/Delivered", "Upload completion photos/documents", "Trigger customer notification"]}
          />
        )}
      </Tabs>
    </div>
  );
}

export default AddJobRegistration;
