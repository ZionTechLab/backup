import * as Yup from "yup";
import { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { useFormikBuilder, FieldsRenderer } from "../../../../helpers/formikBuilder";
import MeridianPage from "../../MeridianPage";
import ApiService from "./service";
import MessageBoxService from "../../../../services/MessageBoxService";

import config from "../../../../config/config";

export default function AddExchangeRate() {
  const { id }   = useParams();
  const navigate = useNavigate();
  const isEdit   = Boolean(id);
  const [uiData, setUiData] = useState({ loading: false, success: false, error: '', data: {} });

  const fields = {
    rateId: {
      name: "rateId", type: "text", placeholder: "Rate ID",
      initialValue: "<Auto>", disabled: true, visible: false,
    },
    from_currencyCode: {
      name: "from_currencyCode", type: "select", placeholder: "From Currency",
      initialValue: "",
      dataBinding: { data: uiData?.data?.currencies, keyField: "currencyCode", valueField: "label" },
      validation: Yup.string().required("From currency is required"),
      className: "col-md-4",
    },
    to_currencyCode: {
      name: "to_currencyCode", type: "select", placeholder: "To Currency",
      initialValue: "",
      dataBinding: { data: uiData?.data?.currencies, keyField: "currencyCode", valueField: "label" },
      validation: Yup.string().required("To currency is required"),
      className: "col-md-4",
    },
    rateTypeId: {
      name: "rateTypeId", type: "select", placeholder: "Rate Type",
      initialValue: "",
      dataBinding: { data: uiData?.data?.rateTypes, keyField: "rateTypeId", valueField: "typeName" },
      validation: Yup.string().required("Rate type is required"),
      className: "col-md-4",
    },
    rate: {
      name: "rate", type: "amount", placeholder: "Rate",
      initialValue: "",
      validation: Yup.string().required("Rate is required"),
      className: "col-md-6",
    },
    effectiveDate: {
      name: "effectiveDate", type: "text", placeholder: "Effective Date",
      initialValue: "",
      validation: Yup.string().required("Effective date is required"),
      className: "col-md-6",
    },
  };

  const handleSubmit = async (values, { resetForm }) => {
    const param = {
      header: { ...values, rateId: id ? parseInt(id) : 0 },
      isUpdate: isEdit,
    };
    const response = await ApiService.update(param);
    const { success, data } = response;
    if (success) {
      MessageBoxService.show({
        message: "Exchange rate saved successfully!",
        type: "success",
        onClose: () => {
          if (config.features.returnToListAfterSave) {
            navigate("/settings/exchange-rates");
          } else if (!id && data?.rateId) {
            navigate(`/settings/exchange-rates/edit/${data.rateId}`);
          } else if (!id) {
            resetForm();
          }
        },
      });
    }
  };

  const formik = useFormikBuilder(fields, handleSubmit);

  useEffect(() => {
    const fetchUi = async () => {
      setUiData(prev => ({ ...prev, loading: true }));
      const res = await ApiService.getUi();
      setUiData(prev => ({ ...prev, ...res, loading: false }));
    };
    fetchUi();

    if (id) {
      const fetchRecord = async () => {
        const response = await ApiService.get(id);
        if (response.success && response.data) {
          formik.setValues({ ...response.data });
        }
      };
      fetchRecord();
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const handleDelete = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: "Delete this exchange rate? This cannot be undone.",
      type: "danger",
      confirmText: "Delete",
      cancelText: "Cancel",
    });
    if (!confirmed) return;
    const response = await ApiService.delete(id);
    if (response.success) {
      MessageBoxService.show({
        message: "Exchange rate deleted.",
        type: "success",
        onClose: () => navigate("/settings/exchange-rates"),
      });
    }
  };

  return (
    <MeridianPage
      title={isEdit ? "Edit Exchange Rate" : "New Exchange Rate"}
      backTo="/settings/exchange-rates"
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
            form="exchange-rate-form"
            className="ml-btn-action ml-fab"
            disabled={formik.isSubmitting}
          >
            {formik.isSubmitting
              ? <span className="ml-spinner" aria-hidden="true" />
              : <i className="bi bi-check-lg" aria-hidden="true" />}
            {isEdit ? "Save Changes" : "Create Rate"}
          </button>
        </>
      }
    >
      <form id="exchange-rate-form" onSubmit={formik.handleSubmit}>
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
