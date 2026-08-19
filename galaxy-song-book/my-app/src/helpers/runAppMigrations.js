import config from "../config/config";

// Theme keys (theme/colorTheme/uiTheme) are intentionally NOT seeded here.
// Their default now comes from the tenant's DB settings (see ThemeContext),
// with an absent localStorage key meaning "no personal override yet".
// Seeding a value here would permanently mask that tenant default.
export default function runAppMigrations() {
  const localVersion = localStorage.getItem("appVersion");
  if (localVersion !== config.features.version || localVersion === undefined || localVersion === null) {
    localStorage.setItem("appVersion", config.features.version);
  }
}
