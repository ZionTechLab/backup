// Canonical option lists for theme/display settings. Single source shared by
// the personal Theme Settings page (hooks/useTheme) and the tenant-admin
// Tenant Settings page, so the two selects never drift out of sync.
// `value` must match what ThemeContext writes to localStorage / the backend
// tenant settings JSON — see express-be/src/features/tenant/settingsDefaults.js.

export const DISPLAY_DATE_FORMAT_OPTIONS = [
  { value: "YY-MMM-DD",  label: "YY-MMM-DD (26-Jul-04)" },
  { value: "DD-MMM-YY",  label: "DD-MMM-YY (04-Jul-26)" },
  { value: "YYYY-MM-DD", label: "YYYY-MM-DD (2026-07-04)" },
  { value: "DD/MM/YYYY", label: "DD/MM/YYYY (04/07/2026)" },
  { value: "MM/DD/YYYY", label: "MM/DD/YYYY (07/04/2026)" },
];

export const THEME_MODE_OPTIONS = [
  { value: "dark",  label: "Dark" },
  { value: "light", label: "Light" },
];

export const UI_THEME_OPTIONS = [
  { value: "flat",       label: "Flat" },
  { value: "material",   label: "Material" },
  { value: "round",      label: "Round" },
  { value: "glass",      label: "Glass" },
  { value: "neumorphic", label: "Neumorphic (Soft)" },
  { value: "torn",       label: "Torn (Paper)" },
];

// `group` is optional — screens that render a flat <select> can ignore it;
// ThemeSettings.jsx uses it to put the more niche palettes in an <optgroup>.
export const COLOR_THEME_OPTIONS = [
  { value: "default",     label: "Default" },
  { value: "ocean",       label: "Ocean (Blue)" },
  { value: "forest",      label: "Forest (Green)" },
  { value: "sunset",      label: "Sunset (Orange)" },
  { value: "grape",       label: "Grape (Purple)" },
  { value: "candy",       label: "Candy (Pink)" },
  { value: "slate",       label: "Slate (Neutral)" },
  { value: "mathbook",    label: "Math Book (Grid)" },
  { value: "engineering", label: "Engineering / Blueprint (Grid)" },
  { value: "cloud",       label: "Cloud (Neumorphic)" },
  { value: "terminal",    label: "Terminal (Green/Black)", group: "Specialized Palettes" },
  { value: "aurora",      label: "Aurora (Deep Blue)",      group: "Specialized Palettes" },
  { value: "luxe",        label: "Luxe (Gold/Black)",       group: "Specialized Palettes" },
];
