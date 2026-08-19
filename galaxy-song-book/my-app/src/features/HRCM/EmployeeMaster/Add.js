import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import * as Yup from "yup";
import {
  useFormikBuilder,
  FieldsRenderer,
} from "../../../helpers/formikBuilder";
import ApiService from "./service";
import MessageBoxService from "../../../services/MessageBoxService";
import Tabs from "../../../components/Tabs";
import {
  getFieldsQualifications,
  getFieldsFinancial,
  getFieldsDocumentation,
  getFieldsMovement,
  getFieldsPersonal,
} from "./fields";

function AddEmployee() {
  const { id } = useParams();
  const navigate = useNavigate();
  // uiData placeholder removed (not currently used)
  const [activeTab, setActiveTab] = useState("search");
  const [tabsInitialized, setTabsInitialized] = useState(false);
  const [uiData, setUiData] = useState({
    loading: false,
    success: false,
    error: "",
    data: {},
  });

  const [uiDataFiltered, setuiDataFiltered] = useState({
    Status: [],
    Title: [],
    Gender: [],
    MaritalStatus: [],
    Nationality: [],
    Religion: [],
    BloodGroup: [],
    Country: [],
    Province: [],
    District: [],
    City: [],
    Division: [],
    Department: [],
    Section: [],
    SubSection: [],
    Designation: [],
    RecruitmentType: [],
    PaymentMethod: [],
    Bank: [],
    BankBranch: [],
  });

  const fields_qualifications = getFieldsQualifications(uiDataFiltered);
  const fields_financial = getFieldsFinancial(uiDataFiltered);
  const fields_documentation = getFieldsDocumentation(uiDataFiltered);
  const fields_movement = getFieldsMovement(uiDataFiltered);
  const fields_personal = getFieldsPersonal(uiDataFiltered);

  const allFields = {
    ...fields_personal,
    ...fields_qualifications,
    ...fields_financial,
    ...fields_documentation,
    ...fields_movement,
  };
  useEffect(() => {
    const fetchUi = async () => {
      setUiData((prev) => ({ ...prev, loading: true, error: "", data: {} }));
      const data = await ApiService.getUi();
      setUiData((prev) => ({ ...prev, ...data, loading: false }));
      setuiDataFiltered((prev) => ({
        ...prev,
        Status: data.data.Status || [],
        Title: data.data.Title || [],
        Gender: data.data.Gender || [],
        MaritalStatus: data.data.MaritalStatus || [],
        Nationality: data.data.Nationality || [],
        Religion: data.data.Religion || [],
        BloodGroup: data.data.BloodGroup || [],
        Country: data.data.Country || [],
        Province: data.data.Province || [],
        District: data.data.District || [],
        City: data.data.City || [],
        Division: data.data.Division || [],
        Department: data.data.Department || [],
        Section: data.data.Section || [],
        SubSection: data.data.SubSection || [],
        Designation: data.data.Designation || [],
        RecruitmentType: data.data.RecruitmentType || [],
        PaymentMethod: data.data.PaymentMethod || [],
        Bank: data.data.Bank || [],
        BankBranch: data.data.BankBranch || [],
      }));
    };
    fetchUi();

    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const handleSubmit = async (values, { resetForm }) => {
    const param = {
      header: { ...values, id: parseInt(id ? id : 0) },
      isUpdate: id ? true : false,
    };
    const response = await ApiService.update({ ...param });

    if (response.success) {
      MessageBoxService.show({
        message: "Employee saved successfully!",
        type: "success",
        onClose: () => navigate("/employee"),
      });
      resetForm();
    }
  };

  const formik = useFormikBuilder(allFields, handleSubmit);

  const handleDelete = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: "Are you sure you want to delete this Employee?",
      type: "danger",
      confirmText: "Delete",
      cancelText: "Cancel",
    });

    if (!confirmed) return;

    const response = await ApiService.delete({ id });
    if (response.success) {
      MessageBoxService.show({
        message: "Employee deleted successfully!",
        type: "success",
        onClose: () => navigate("/employee"),
      });
    }
  };
  const tabs = [
    { id: "personal", label: `Personal`, disabled: false },
    { id: "official", label: `Official`, disabled: false },
    { id: "qualifications", label: `Qualifications`, disabled: false },
    { id: "financial", label: `Financial`, disabled: false },
    { id: "documentation", label: `Documentation`, disabled: false },
    { id: "movement", label: `Movement`, disabled: false },
  ];

  const handleTabChange = (tabId) => {
    setActiveTab(tabId);
  };
  return (
    <div className="container ">
      <Tabs tabs={tabs} activeTab={activeTab} onTabChange={handleTabChange}>
        {activeTab === "personal" && (
          <div className="card mb-3">
            <div className="card-body">
              <div className="row g-2">
                <FieldsRenderer
                  fields={fields_personal}
                  formik={formik}
                  inputProps={{ autocomplete: "off" }}
                />
              </div>
              <div className="d-flex justify-content-end mt-3">
                {id && (
                  <button
                    type="button"
                    className="btn btn-outline-danger me-2"
                    onClick={() => handleDelete()}
                  >
                    Delete
                  </button>
                )}
                <button type="submit" className="btn btn-primary">
                  Save
                </button>
              </div>
            </div>
          </div>
        )}
        {activeTab === "official" && (
          <div className="card mb-3">
            <div className="card-body">
              <div className="row g-2">
                <FieldsRenderer
                  fields={fields_financial}
                  formik={formik}
                  inputProps={{ autocomplete: "off" }}
                />
              </div>
              <div className="d-flex justify-content-end mt-3">
                {id && (
                  <button
                    type="button"
                    className="btn btn-outline-danger me-2"
                    onClick={() => handleDelete()}
                  >
                    Delete
                  </button>
                )}
                <button type="submit" className="btn btn-primary">
                  Save
                </button>
              </div>
            </div>
          </div>
        )}
        {activeTab === "qualifications" && (
          <div className="card mb-3">
            <div className="card-body">
              <div className="row g-2">
                <FieldsRenderer
                  fields={fields_qualifications}
                  formik={formik}
                  inputProps={{ autocomplete: "off" }}
                />
              </div>
              <div className="d-flex justify-content-end mt-3">
                {id && (
                  <button
                    type="button"
                    className="btn btn-outline-danger me-2"
                    onClick={() => handleDelete()}
                  >
                    Delete
                  </button>
                )}
                <button type="submit" className="btn btn-primary">
                  Save
                </button>
              </div>
            </div>
          </div>
        )}
        {activeTab === "financial" && (
          <div className="card mb-3">
            <div className="card-body">
              <div className="row g-2">
                <FieldsRenderer
                  fields={fields_financial}
                  formik={formik}
                  inputProps={{ autocomplete: "off" }}
                />
              </div>
              <div className="d-flex justify-content-end mt-3">
                {id && (
                  <button
                    type="button"
                    className="btn btn-outline-danger me-2"
                    onClick={() => handleDelete()}
                  >
                    Delete
                  </button>
                )}
                <button type="submit" className="btn btn-primary">
                  Save
                </button>
              </div>
            </div>
          </div>
        )}
        {activeTab === "documentation" && <div className="mt-3">"jgjghgj"</div>}
        {activeTab === "movement" && <div className="mt-3">"jgjghgj"</div>}
      </Tabs>

      <form onSubmit={formik.handleSubmit} className=" g-3"></form>
    </div>
  );
}

export default AddEmployee;
