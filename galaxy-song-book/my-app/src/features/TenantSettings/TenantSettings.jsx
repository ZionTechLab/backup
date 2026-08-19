import { useEffect, useState } from "react";
import { useSelector, useDispatch } from "react-redux";
import { useFormikBuilder, FieldsRenderer } from "../../helpers/formikBuilder";
import MeridianPage from "../Meridian/MeridianPage";
import tenantSettingsService from "./service";
import MessageBoxService from "../../services/MessageBoxService";
import { selectTenantId, reloadInitData } from "../auth";
import {
  DISPLAY_DATE_FORMAT_OPTIONS,
  THEME_MODE_OPTIONS,
  UI_THEME_OPTIONS,
  COLOR_THEME_OPTIONS,
} from "../../config/themeOptions";

const fields = {
  DISPLAY_DATE_FORMAT: {
    name: "DISPLAY_DATE_FORMAT",
    type: "select",
    placeholder: "Display Date Format",
    initialValue: "YY-MMM-DD",
    className: "col-md-4",
    dataBinding: { data: DISPLAY_DATE_FORMAT_OPTIONS, keyField: "value", valueField: "label" },
  },
  theme: {
    name: "theme",
    type: "select",
    placeholder: "Default Mode",
    initialValue: "dark",
    className: "col-md-4",
    dataBinding: { data: THEME_MODE_OPTIONS, keyField: "value", valueField: "label" },
  },
  uiTheme: {
    name: "uiTheme",
    type: "select",
    placeholder: "Default UI Style",
    initialValue: "material",
    className: "col-md-4",
    dataBinding: { data: UI_THEME_OPTIONS, keyField: "value", valueField: "label" },
  },
  colorTheme: {
    name: "colorTheme",
    type: "select",
    placeholder: "Default Color Palette",
    initialValue: "default",
    className: "col-md-4",
    dataBinding: { data: COLOR_THEME_OPTIONS, keyField: "value", valueField: "label" },
  },
  br1: { type: "br" },
  returnToListAfterSave: {
    name: "returnToListAfterSave",
    type: "switch",
    placeholder: "Return to list after save",
    initialValue: false,
    className: "col-md-4",
  },
  showThemeControls: {
    name: "showThemeControls",
    type: "switch",
    placeholder: "Show theme controls to users",
    initialValue: true,
    className: "col-md-4",
  },
  selectSearch: {
    name: "selectSearch",
    type: "switch",
    placeholder: "Searchable dropdowns",
    initialValue: true,
    className: "col-md-4",
  },
  dataTableColumnVisibility: {
    name: "dataTableColumnVisibility",
    type: "switch",
    placeholder: "Table column visibility toggle",
    initialValue: true,
    className: "col-md-4",
  },
  dataTableCSVExport: {
    name: "dataTableCSVExport",
    type: "switch",
    placeholder: "Table CSV export",
    initialValue: true,
    className: "col-md-4",
  },
  actionColumnsRightEnd: {
    name: "actionColumnsRightEnd",
    type: "switch",
    placeholder: "Pin action columns to the right",
    initialValue: false,
    className: "col-md-4",
  },
};

export default function TenantSettings() {
  const dispatch = useDispatch();
  const tenantId = useSelector(selectTenantId);
  const [loading, setLoading] = useState(true);

  const handleSubmit = async (values) => {
    const response = await tenantSettingsService.update(tenantId, values);
    if (response.success) {
      // Refresh the cached initData so config.features/DataTableConfig (applied
      // from initData.tenantSettings in App.js) pick up the new values without
      // requiring a full reload. Without this, the saved settings only take
      // effect on the next login.
      await dispatch(reloadInitData());
      MessageBoxService.show({
        message: "Tenant settings saved.",
        type: "success",
      });
    }
  };

  const formik = useFormikBuilder(fields, handleSubmit);

  useEffect(() => {
    if (!tenantId) return;
    setLoading(true);
    tenantSettingsService.get(tenantId).then(({ success, data }) => {
      if (success && data) formik.setValues({ ...data });
      setLoading(false);
    });
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [tenantId]);

  return (
    <MeridianPage
      title="Tenant Settings"
      subtitle="Defaults applied across this tenant. Users can still pick their own theme."
      cardClass="ml-form-card"
      actions={
        <button
          type="submit"
          form="tenant-settings-form"
          className="ml-btn-action ml-fab"
          disabled={formik.isSubmitting || loading}
        >
          {formik.isSubmitting
            ? <span className="ml-spinner" aria-hidden="true" />
            : <i className="bi bi-check-lg" aria-hidden="true" />}
          Save Changes
        </button>
      }
    >
      <form id="tenant-settings-form" onSubmit={formik.handleSubmit}>
        <div className="ml-form-section">
          <div className="ml-form-section-label">Theme Defaults</div>
          <div className="row g-3">
            <FieldsRenderer
              fields={{ DISPLAY_DATE_FORMAT: fields.DISPLAY_DATE_FORMAT, theme: fields.theme, uiTheme: fields.uiTheme, colorTheme: fields.colorTheme }}
              formik={formik}
            />
          </div>
        </div>

        <div className="ml-form-section">
          <div className="ml-form-section-label">Behavior</div>
          <div className="row g-3">
            <FieldsRenderer
              fields={{
                returnToListAfterSave: fields.returnToListAfterSave,
                showThemeControls: fields.showThemeControls,
                selectSearch: fields.selectSearch,
                dataTableColumnVisibility: fields.dataTableColumnVisibility,
                dataTableCSVExport: fields.dataTableCSVExport,
                actionColumnsRightEnd: fields.actionColumnsRightEnd,
              }}
              formik={formik}
            />
          </div>
        </div>
      </form>
    </MeridianPage>
  );
}
