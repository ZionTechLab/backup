import config from './config';
import { initDataTableConfig } from '../components/DataTable';

// Applies DB-backed tenant settings over the app's hardcoded config defaults.
// Mutates the shared `config` singleton in place so every existing call site
// (config.features.X, config.DISPLAY_DATE_FORMAT) picks up the tenant value
// without needing to be rewritten. Called whenever initData.tenantSettings
// changes (login, SSO, silent-refresh reload).
export default function applyTenantSettings(settings) {
  if (!settings) return;

  if (settings.DISPLAY_DATE_FORMAT) config.DISPLAY_DATE_FORMAT = settings.DISPLAY_DATE_FORMAT;
  if (settings.returnToListAfterSave !== undefined) config.features.returnToListAfterSave = settings.returnToListAfterSave;
  if (settings.showThemeControls !== undefined) config.features.showThemeControls = settings.showThemeControls;
  if (settings.selectSearch !== undefined) config.features.selectSearch = settings.selectSearch;

  initDataTableConfig({
    features: {
      columnVisibility: settings.dataTableColumnVisibility,
      csvExport: settings.dataTableCSVExport,
      actionColumnsRightEnd: settings.actionColumnsRightEnd,
    },
  });
}
