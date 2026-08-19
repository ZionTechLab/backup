import { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";
import { selectInitData } from "../../features/auth";
import * as Yup from "yup";
import { useFormikBuilder, FieldsRenderer } from "../../helpers/formikBuilder";
import ApiService from "./ReferenceService";
import MessageBoxService from "../../services/MessageBoxService";
import transformDateFields from "../../helpers/transformDateFields";

import config from "../../config/config";

function AddReferences() {
  const { id } = useParams();
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({
    loading: false,
    success: false,
    error: "",
    data: {},
  });
  const { category } = useParams();
  const initData = useSelector(selectInitData);
  const metaList = initData?.meta || [];

  const slugify = (s) =>
    String(s || "")
      .toLowerCase()
      .trim()
      .replace(/[^a-z0-9\s-]/g, "")
      .replace(/\s+/g, "-")
      .replace(/-+/g, "-");

  const matched = category
    ? metaList.find((m) => slugify(m.categoryTypeName) === category)
    : null;
  const categoryType = matched?.categoryType;

  function buildYupField(field) {
    if (field?.validation === undefined || field?.validation === null)
      return undefined;
    let schema = Yup.string();
    if (field.validation?.required) {
      schema = schema.required(field.validation.message || "Required");
    }
    return schema;
  }

  const fields1 = {
    id: {
      name: "id",
      type: "text",
      placeholder: "Code",
      initialValue: "<Auto>",
      disabled: true,
      className: "col-md-3 col-sm-6 col-12",
    },
    value: {
      ...uiData.data.meta?.metaValue,
      validation: buildYupField(uiData.data.meta?.metaValue),
    },

    parentId: {
      name: "parentId",
      type: "select",
      placeholder: uiData.data.meta?.parentCategory,
      isVisible: uiData.data.meta?.parentCategoryType == 0 ? false : true,
      dataBinding: {
        data: uiData.data.meta?.parentCategoryData,
        keyField: "id",
        valueField: "value",
      },
    },
    description: {
      ...uiData.data.meta?.metaDesc,
      validation: buildYupField(uiData.data.meta?.metaDesc),
    },
    active: {
      name: "active",
      type: "switch",
      initialValue: true,
      validation: Yup.boolean(),
      placeholder: "Active",
    },
  };

  const fields = Object.fromEntries(
    Object.entries(fields1).filter(([key, field]) => field !== undefined),
  );

  // Ensure every field has a `name` and a stable `initialValue` so Formik
  // doesn't create an `undefined` key when InputField initializes defaults.
  Object.keys(fields).forEach((key) => {
    const f = fields[key];
    if (!f) return;
    if (f.name === undefined) f.name = key;
    if (f.initialValue === undefined) {
      switch (f.type) {
        case "checkbox":
        case "switch":
          f.initialValue = false;
          break;
        case "images":
          f.initialValue = [];
          break;
        default:
          f.initialValue = "";
      }
    }
  });

  useEffect(() => {
    const fetchUi = async () => {
      setUiData((prev) => ({ ...prev, loading: true, error: "", data: {} }));
      const data = await ApiService.getUi({ categoryType });
      setUiData((prev) => ({ ...prev, ...data, loading: false }));
    };
    fetchUi();

    if (id) {
      const fetchTxn = async () => {
        const response = await ApiService.get(id, categoryType);
        if (response.success) {
          if (response.data) {
            const normalized = transformDateFields(response.data, fields);
            formik.setValues({ ...normalized });
          }
        }
      };
      fetchTxn();
    }

    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const handleSubmit = async (values, { resetForm }) => {
    const param = {
      header: {
        ...values,
        id: parseInt(id ? id : 0),
        categoryType,
        parentId: values.parentId ? parseInt(values.parentId) : 0,
      },
      isUpdate: id ? true : false,
    };
    const response = await ApiService.update({ ...param });
    const { success, data } = response;

    if (success) {
      MessageBoxService.show({
        message: `${category} saved successfully!`,
        type: "success",
        onClose: () => {
          if (config.features.returnToListAfterSave) {
            navigate(category ? `/reference/${category}` : "/reference");
          } else if (!id && data?.id) {
            navigate(`/reference/${category}/edit/${data.id}`);
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
      message: "Are you sure you want to delete?",
      type: "danger",
      confirmText: "Delete",
      cancelText: "Cancel",
    });

    if (!confirmed) return;

    const response = await ApiService.delete(id, categoryType);
    if (response.success) {
      MessageBoxService.show({
        message: "deleted successfully!",
        type: "success",
        onClose: () =>
          navigate(category ? `/reference/${category}` : "/reference"),
      });
    }
  };

  return (
    <div className="container container-small">
      {!uiData.loading && !uiData.error && (
        <form onSubmit={formik.handleSubmit}>
          <div className="card mb-2">
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
                    {/* <button type="button" className="btn btn-outline-secondary me-2" onClick={() => setShowPreview((s) => !s)}>          
                {showPreview ? "Hide Preview" : "Print Preview"}
              </button> */}
                    <button
                      type="button"
                      className="btn btn-outline-danger me-2"
                      onClick={() => handleDelete()}
                    >
                      Delete
                    </button>
                  </>
                )}
                <button type="submit" className="btn btn-primary">
                  Save
                </button>
              </div>
            </div>
          </div>
        </form>
      )}
    </div>
  );
}

export default AddReferences;
