import * as Yup from "yup";
import { useMemo, useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { useFormikBuilder, FieldsRenderer } from "../../../../helpers/formikBuilder";
import MeridianPage from "../../MeridianPage";
import ApiService from "./service";
import MessageBoxService from "../../../../services/MessageBoxService";

import config from "../../../../config/config";

export default function AddCurrency() {
  const { id }   = useParams();
  const navigate = useNavigate();
  const isEdit   = Boolean(id);

  const fields = useMemo(() => ({
    currencyCode: { name: "currencyCode", type: "text",     placeholder: "Currency Code (e.g. USD)", initialValue: "", className: "col-md-4", disabled: isEdit, validation: Yup.string().required("Code is required") },
    currencyName: { name: "currencyName", type: "text",     placeholder: "Currency Name",            initialValue: "", className: "col-md-5", validation: Yup.string().required("Name is required") },
    symbol:       { name: "symbol",       type: "text",     placeholder: "Symbol (e.g. $)",          initialValue: "", className: "col-md-3", validation: Yup.string().required("Symbol is required") },
    isActive:     { name: "isActive",     type: "switch",   placeholder: "Active",                   initialValue: true, className: "col-md-12" },
  }), [isEdit]);
 const [uiData, setUiData] = useState({loading: false, success: false, error: '', data: [] });
  
 const handleSubmit = async (values, { resetForm }) => {
    const param = {
      header: { ...values, currencyCode: id ? id : values.currencyCode },
      isUpdate: id ? true : false
    };
    const response = await ApiService.update({ ...param });
    const { success, data } = response;

    if (success) {
      MessageBoxService.show({
        message: "Currency saved successfully!",
        type: "success",
        onClose: () => {
          if (config.features.returnToListAfterSave) {
            navigate("/settings/currencies");
          } else if (!id && data?.currencyCode) {
            navigate(`/settings/currencies/edit/${data.currencyCode}`);
          } else if (!id) {
            resetForm();
          }
        },
      });
    }
  };
 const formik = useFormikBuilder(fields, handleSubmit);

  useEffect(() => {

    if (id) {
      const fetchTxn = async () => {
        const response = await ApiService.get(id);
        if (response.success) {
          if (response.data) {
            formik.setValues({ ...response.data });
          }
        }
      };
      fetchTxn();
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const handleDelete = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: "Delete this currency? This cannot be undone.",
      type: "danger",
      confirmText: "Delete",
      cancelText: "Cancel",
    });
    if (!confirmed) return;
    const response = await ApiService.delete(id);
    if (response.success) {
      MessageBoxService.show({
        message: "Currency deleted.",
        type: "success",
        onClose: () => navigate("/settings/currencies"),
      });
    }
  };

  return (
    <MeridianPage
      title={isEdit ? "Edit Currency" : "New Currency"}
      backTo="/settings/currencies"
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
            form="currency-form"
            className="ml-btn-action ml-fab"
            disabled={formik.isSubmitting}
          >
            {formik.isSubmitting
              ? <span className="ml-spinner" aria-hidden="true" />
              : <i className="bi bi-check-lg" aria-hidden="true" />}
            {isEdit ? "Save Changes" : "Create Currency"}
          </button>
        </>
      }
    >
      <form id="currency-form" onSubmit={formik.handleSubmit}>
        <div className="ml-form-section">
          <div className="ml-form-section-label">Details</div>
          <div className="row g-3">
            <FieldsRenderer fields={fields} formik={formik} />
          </div>
        </div>
      </form>
    </MeridianPage>
  );
}
