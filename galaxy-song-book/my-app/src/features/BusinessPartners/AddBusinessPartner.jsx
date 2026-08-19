import { useEffect } from "react";
import * as Yup from "yup";
import { useParams, useNavigate } from "react-router-dom";
import { useFormikBuilder, FieldsRenderer } from "../../helpers/formikBuilder";
import { phoneYup } from "../../helpers/phoneValidation";
import MeridianPage from "../Meridian/MeridianPage";
import ApiService from "./PartnerService";
import MessageBoxService from "../../services/MessageBoxService";
import transformDateFields from "../../helpers/transformDateFields";
import config from "../../config/config";

const fileUrl = (name) => (name ? config.apiBaseUrl + "uploads/" + name : "");

const fields = {
  businessPartnerId: {
    name: "businessPartnerId", type: "text", placeholder: "Partner ID",
    initialValue: "<New>", disabled: true, className: "col-md-4 col-sm-6",
  },
  partnerCode: {
    name: "partnerCode", type: "text", placeholder: "Partner Code",
    initialValue: "", className: "col-md-4 col-sm-6",
    validation: Yup.string().required("Partner Code is required"),
  },
  partnerName: {
    name: "partnerName", type: "text", placeholder: "Partner Name",
    initialValue: "", className: "col-md-4 col-sm-12",
    validation: Yup.string().required("Partner Name is required"),
  },
  contactPerson: {
    name: "contactPerson", type: "text", placeholder: "Contact Person",
    initialValue: "", className: "col-md-6 col-sm-6",
  },
  email: {
    name: "email", type: "email", placeholder: "Email",
    initialValue: "", className: "col-md-6 col-sm-12",
  },
  phone1: {
    name: "phone1", type: "phone", placeholder: "Phone 1",
    initialValue: "", className: "col-md-3 col-sm-6",
    validation: phoneYup({ required: true }),
  },
  phone2: {
    name: "phone2", type: "phone", placeholder: "Phone 2",
    initialValue: "", className: "col-md-3 col-sm-6",
    validation: phoneYup(),
  },
  whatsappId: {
    name: "whatsappId", type: "text", placeholder: "WhatsApp ID",
    initialValue: "", className: "col-md-3 col-sm-6",
  },
  nic: {
    name: "nic", type: "text", placeholder: "NIC",
    initialValue: "", className: "col-md-3 col-sm-6",
  },
  empNo: {
    name: "empNo", type: "text", placeholder: "Emp No",
    initialValue: "", className: "col-md-3 col-sm-6",
  },
  preferredName: {
    name: "preferredName", type: "text", placeholder: "Preferred Name",
    initialValue: "", className: "col-md-3 col-sm-6",
  },
  fullName: {
    name: "fullName", type: "text", placeholder: "Full Name",
    initialValue: "", className: "col-md-6 col-sm-12",
  },
  address: {
    name: "address", type: "text", placeholder: "Address",
    initialValue: "", className: "col-md-6 col-sm-12",
  },
  isCustomer: { name: "isCustomer", type: "switch", initialValue: false, placeholder: "Customer", className: "col-md-2 col-4", validation: Yup.boolean() },
  isSupplier: { name: "isSupplier", type: "switch", initialValue: false, placeholder: "Supplier", className: "col-md-2 col-4", validation: Yup.boolean() },
  isDriver:   { name: "isDriver",   type: "switch", initialValue: false, placeholder: "Driver",   className: "col-md-2 col-4", validation: Yup.boolean() },
  isOperator: { name: "isOperator", type: "switch", initialValue: false, placeholder: "Operator", className: "col-md-2 col-4", validation: Yup.boolean() },
  isHelper:   { name: "isHelper",   type: "switch", initialValue: false, placeholder: "Helper",   className: "col-md-2 col-4", validation: Yup.boolean() },
  isStaff:    { name: "isStaff",    type: "switch", initialValue: false, placeholder: "Staff",    className: "col-md-2 col-4", validation: Yup.boolean() },
  isActive:   { name: "isActive",   type: "switch", initialValue: true,  placeholder: "Active",   className: "col-md-3 col-6",  validation: Yup.boolean() },
};

const IDENTITY = ["businessPartnerId", "partnerCode", "partnerName", "fullName", "preferredName", "contactPerson", "nic", "empNo", "email", "phone1", "phone2", "whatsappId", "address"];
const ROLES = ["isCustomer", "isSupplier", "isDriver", "isOperator", "isHelper", "isStaff", "isActive"];
const pick = (keys) => Object.fromEntries(keys.map((k) => [k, fields[k]]));

export default function AddBusinessPartner() {
  const { id } = useParams();
  const navigate = useNavigate();
  const isEdit = Boolean(id);

  const handleSubmit = async (values, { resetForm }) => {
    const { isCustomer, isSupplier, isDriver, isHelper, isOperator, isStaff, businessPartnerId, ...rest } = values;
    const param = {
      header: { ...rest, businessPartnerId: id || null },
      detail: [
        isCustomer ? { type: "C" } : null,
        isSupplier ? { type: "S" } : null,
        isDriver   ? { type: "D" } : null,
        isHelper   ? { type: "H" } : null,
        isOperator ? { type: "O" } : null,
        isStaff    ? { type: "E" } : null,
      ].filter(Boolean),
      isUpdate: isEdit,
    };
    const response = await ApiService.update(param);
    if (response.success) {
      MessageBoxService.show({
        message: "Business Partner saved successfully!",
        type: "success",
        onClose: () => {
          if (config.features.returnToListAfterSave) {
            navigate("/business-partner");
          } else if (!id && response.data?.businessPartnerId) {
            navigate(`/business-partner/edit/${response.data.businessPartnerId}`);
          } else if (!id) {
            resetForm();
          }
        },
      });
    }
  };

  const formik = useFormikBuilder(fields, handleSubmit);

  const handleUpload = async (fieldName, file) => {
    if (!file) return;
    const { success, data } = await ApiService.uploadFile(file);
    if (success && data?.filename) formik.setFieldValue(fieldName, data.filename);
  };

  useEffect(() => {
    if (!isEdit) return;
    ApiService.get(id).then((response) => {
      if (response.success && response.data) {
        const { partnerType, ...rest } = response.data;
        formik.setValues({ ...transformDateFields(rest, fields) });
        const types = partnerType || [];
        formik.setFieldValue("isCustomer", types.includes("C"));
        formik.setFieldValue("isSupplier", types.includes("S"));
        formik.setFieldValue("isDriver",   types.includes("D"));
        formik.setFieldValue("isOperator", types.includes("O"));
        formik.setFieldValue("isHelper",   types.includes("H"));
        formik.setFieldValue("isStaff",    types.includes("E"));
      }
    });
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const handleDelete = async () => {
    if (!isEdit) return;
    const confirmed = await MessageBoxService.confirmAsync({
      message: "Delete this business partner? This cannot be undone.",
      type: "danger",
      confirmText: "Delete",
      cancelText: "Cancel",
    });
    if (!confirmed) return;
    const response = await ApiService.delete({ id });
    if (response.success) {
      MessageBoxService.show({
        message: "Business Partner deleted.",
        type: "success",
        onClose: () => navigate("/business-partner"),
      });
    }
  };

  return (
    <MeridianPage
      title={isEdit ? "Edit Business Partner" : "New Business Partner"}
      backTo="/business-partner"
      cardClass="ml-form-card"
      actions={
        <>
          {isEdit && (
            <button type="button" className="ml-btn-ghost ml-btn-danger-ghost ml-fab-1" onClick={handleDelete}>
              <i className="bi bi-trash" aria-hidden="true" />
              Delete
            </button>
          )}
          <button type="submit" form="bp-form" className="ml-btn-action ml-fab" disabled={formik.isSubmitting}>
            {formik.isSubmitting
              ? <span className="ml-spinner" aria-hidden="true" />
              : <i className="bi bi-check-lg" aria-hidden="true" />}
            {isEdit ? "Save Changes" : "Create Partner"}
          </button>
        </>
      }
    >
      <form id="bp-form" onSubmit={formik.handleSubmit} autoComplete="off">
        <div className="ml-form-section">
          <div className="ml-form-section-label">Identity</div>
          <div className="row g-3">
            <FieldsRenderer fields={pick(IDENTITY)} formik={formik} />
          </div>
        </div>
        <div className="ml-form-section">
          <div className="ml-form-section-label">Documents</div>
          <div className="row g-3">
            <div className="col-md-6 col-sm-12">
              <label className="form-label">Photo</label>
              <input type="file" accept="image/*" className="form-control"
                onChange={(e) => handleUpload("photoPath", e.target.files?.[0])} />
              {formik.values.photoPath && (
                <div className="d-flex align-items-center gap-2 mt-2">
                  <img src={fileUrl(formik.values.photoPath)} alt="Photo" style={{ height: 48, borderRadius: 6, objectFit: "cover" }} />
                  <button type="button" className="btn btn-sm btn-outline-danger" onClick={() => formik.setFieldValue("photoPath", "")}>Remove</button>
                </div>
              )}
            </div>
            <div className="col-md-6 col-sm-12">
              <label className="form-label">Digital Signature</label>
              <input type="file" accept="image/*" className="form-control"
                onChange={(e) => handleUpload("digitalSignPath", e.target.files?.[0])} />
              {formik.values.digitalSignPath && (
                <div className="d-flex align-items-center gap-2 mt-2">
                  <img src={fileUrl(formik.values.digitalSignPath)} alt="Signature" style={{ height: 48, borderRadius: 6, objectFit: "contain" }} />
                  <button type="button" className="btn btn-sm btn-outline-danger" onClick={() => formik.setFieldValue("digitalSignPath", "")}>Remove</button>
                </div>
              )}
            </div>
          </div>
        </div>
        <div className="ml-form-section">
          <div className="ml-form-section-label">Roles</div>
          <div className="row g-3">
            <FieldsRenderer fields={pick(ROLES)} formik={formik} />
          </div>
        </div>
      </form>
    </MeridianPage>
  );
}
