import { useEffect, useMemo } from "react";
import * as Yup from "yup";
import { useParams, useNavigate } from "react-router-dom";
import { useFormikBuilder, FieldsRenderer } from "../../../../helpers/formikBuilder";
import MeridianPage from "../../MeridianPage";
import ApiService from "./service";
import MessageBoxService from "../../../../services/MessageBoxService";

import config from "../../../../config/config";

export default function AddAccountType() {
  const { id }   = useParams();
  const navigate = useNavigate();
  const isEdit   = Boolean(id);

  const fields = useMemo(() => ({
    accountType: {
      name: "accountType", type: "text", placeholder: "Account Type",
      initialValue: "",
      disabled: isEdit,
      validation: Yup.string().required("Account type is required"),
      className: "col-md-6",
    },
    typeName: {
      name: "typeName", type: "text", placeholder: "Type Name",
      initialValue: "",
      validation: Yup.string().required("Type name is required"),
      className: "col-md-6",
    },
    sortOrder: {
      name: "sortOrder", type: "number", placeholder: "Sort Order",
      initialValue: "",
      validation: Yup.number().required("Sort order is required").integer("Must be an integer"),
      className: "col-md-6",
    },
    isActive: {
      name: "isActive", type: "switch", placeholder: "Active",
      initialValue: true,
      className: "col-md-6",  validation: Yup.boolean(),
    },
  }), [isEdit]);

  useEffect(() => {

    if (id) {
      const fetchTxn = async () => {
        const response = await ApiService.get(id);
        if (response.success) {
          if (response.data) {
            formik.setValues({ ...response.data, isActive: Boolean(response.data.isActive) });
          }
        }
      };
      fetchTxn();
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const handleSubmit = async (values, { resetForm }) => {
    const param = {
      header: { ...values, accountType: id || values.accountType },
      isUpdate: isEdit,
    };
    const response = await ApiService.update(param);
    const { success, data } = response;
    if (success) {
      MessageBoxService.show({
        message: "Account type saved successfully!",
        type: "success",
        onClose: () => {
          if (config.features.returnToListAfterSave) {
            navigate("/settings/account-types");
          } else if (!id && data?.accountType) {
            navigate(`/settings/account-types/edit/${data.accountType}`);
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
      message: "Delete this account type? This cannot be undone.",
      type: "danger",
      confirmText: "Delete",
      cancelText: "Cancel",
    });
    if (!confirmed) return;
    const response = await ApiService.delete(id);
    if (response.success) {
      MessageBoxService.show({
        message: "Account type deleted.",
        type: "success",
        onClose: () => navigate("/settings/account-types"),
      });
    }
  };

  return (
    <MeridianPage
      title={isEdit ? "Edit Account Type" : "New Account Type"}
      backTo="/settings/account-types"
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
            form="account-type-form"
            className="ml-btn-action ml-fab"
            disabled={formik.isSubmitting}
          >
            {formik.isSubmitting
              ? <span className="ml-spinner" aria-hidden="true" />
              : <i className="bi bi-check-lg" aria-hidden="true" />}
            {isEdit ? "Save Changes" : "Create Account Type"}
          </button>
        </>
      }
    >
      <form id="account-type-form" onSubmit={formik.handleSubmit}>
        <div className="ml-form-section">
          <div className="row g-3">
            <FieldsRenderer fields={fields} formik={formik} />
          </div>
        </div>
      </form>
    </MeridianPage>
  );
}
