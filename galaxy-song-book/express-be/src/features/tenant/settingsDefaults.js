// Default tenant-level settings, applied when a tenant has no row yet.
// Mirrors my-app/src/config/config.js `features` defaults so behavior is
// unchanged for a tenant until an admin edits its Tenant Settings.
const DEFAULT_TENANT_SETTINGS = {
  DISPLAY_DATE_FORMAT: 'YY-MMM-DD',
  returnToListAfterSave: false,
  showThemeControls: true,
  dataTableColumnVisibility: true,
  actionColumnsRightEnd: false,
  dataTableCSVExport: true,
  selectSearch: true,
  theme: 'dark',
  colorTheme: 'sepia',
  uiTheme: 'fluent',
};

const SETTINGS_KEYS = Object.keys(DEFAULT_TENANT_SETTINGS);

function parseSettings(raw) {
  if (!raw) return {};
  if (typeof raw === 'string') {
    try {
      return JSON.parse(raw);
    } catch {
      return {};
    }
  }
  return raw;
}

function mergeWithDefaults(settings) {
  return { ...DEFAULT_TENANT_SETTINGS, ...(settings || {}) };
}

module.exports = { DEFAULT_TENANT_SETTINGS, SETTINGS_KEYS, parseSettings, mergeWithDefaults };
