import { useEffect, useState } from "react";
import * as Yup from "yup";
import { useParams, useNavigate } from "react-router-dom";
import { useFormikBuilder, FieldsRenderer } from "../../../../helpers/formikBuilder";
import MeridianPage from "../../MeridianPage";
import ApiService from "./service";
import MessageBoxService from "../../../../services/MessageBoxService";
import config from "../../../../config/config";

const ACCOUNT_TYPE_OPTIONS = [
  { label: "Asset",     value: "A" },
  { label: "Liability", value: "L" },
  { label: "Equity",    value: "E" },
  { label: "Revenue",   value: "R" },
  { label: "Expense",   value: "X" },
];

const fields = {
  accountCode: {
    name: "accountCode", type: "text", placeholder: "Account Code",
    initialValue: "",
    validation: Yup.string().required("Account code is required"),
    className: "col-md-4",
  },
  accountName: {
    name: "accountName", type: "text", placeholder: "Account Name",
    initialValue: "",
    validation: Yup.string().required("Account name is required"),
    className: "col-md-8",
  },
  accountType: {
    name: "accountType", type: "select", placeholder: "Account Type",
    initialValue: "",
    validation: Yup.string().required("Account type is required"),
    className: "col-md-4",
    dataBinding: { data: ACCOUNT_TYPE_OPTIONS, valueField: "value", displayField: "label" },
  },
  level: {
    name: "level", type: "number", placeholder: "Level",
    initialValue: 1,
    validation: Yup.number().required("Level is required").integer("Must be an integer").min(1),
    className: "col-md-4",
  },
  sortOrder: {
    name: "sortOrder", type: "number", placeholder: "Sort Order",
    initialValue: "",
    validation: Yup.number().required("Sort order is required").integer("Must be an integer"),
    className: "col-md-4",
  },
  isActive: {
    name: "isActive", type: "switch", placeholder: "Active",
    initialValue: true,
    validation: Yup.boolean(),
    className: "col-md-4",
  },
};

export default function AddChartOfAccount() {
  const { id }   = useParams();
  const navigate = useNavigate();
  const isEdit   = Boolean(id);
  const [accountId, setAccountId] = useState(null);

  useEffect(() => {
    if (id) {
      ApiService.get(id).then(({ success, data }) => {
        if (success && data) {
          setAccountId(data.accountId);
          formik.setValues({
            accountCode: data.accountCode ?? "",
            accountName: data.accountName ?? "",
            accountType: data.accountType ?? "",
            level:       data.level ?? 1,
            sortOrder:   data.sortOrder ?? "",
            isActive:    Boolean(data.isActive),
          });
        }
      });
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const handleSubmit = async (values, { resetForm }) => {
    const param = {
      ...values,
      accountId: accountId ?? undefined,
      isUpdate: isEdit,
    };
    const response = await ApiService.update(param);
    const { success, data } = response;
    if (success) {
      MessageBoxService.show({
        message: isEdit ? "Account updated successfully!" : "Account created successfully!",
        type: "success",
        onClose: () => {
          if (config.features.returnToListAfterSave) {
            navigate("/coa");
          } else if (!id && data?.accountId) {
            navigate(`/coa/edit/${data.accountId}`);
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
      message: "Delete this account? This cannot be undone.",
      type: "danger",
      confirmText: "Delete",
      cancelText: "Cancel",
    });
    if (!confirmed) return;
    const response = await ApiService.delete(accountId ?? id);
    if (response.success) {
      MessageBoxService.show({
        message: "Account deleted.",
        type: "success",
        onClose: () => navigate("/coa"),
      });
    }
  };

  return (
    <MeridianPage
      title={isEdit ? "Edit Account" : "New Account"}
      backTo="/coa"
      cardClass="ml-form-card"
      actions={
        <>
          {isEdit && (
            <button
              type="button"
              className="ml-btn-ghost ml-btn-danger-ghost ml-fab-1"
              onClick={handleDelete}
            >
              <i className="bi bi-trash" aria-hidden="true" />
              Delete
            </button>
          )}
          <button
            type="submit"
            form="coa-form"
            className="ml-btn-action ml-fab"
            disabled={formik.isSubmitting}
          >
            {formik.isSubmitting
              ? <span className="ml-spinner" aria-hidden="true" />
              : <i className="bi bi-check-lg" aria-hidden="true" />}
            {isEdit ? "Save Changes" : "Create Account"}
          </button>
        </>
      }
    >
      <form id="coa-form" onSubmit={formik.handleSubmit}>
        <div className="ml-form-section border-bottom-0">
          <div className="ml-form-section-label">Account Details</div>
          <div className="row g-3">
            <FieldsRenderer fields={fields} formik={formik} />
          </div>
        </div>
      </form>
    </MeridianPage>
  );
}
