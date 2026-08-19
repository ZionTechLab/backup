import pkg from '../../package.json';
const { version } = pkg;

const config = {
  apiBaseUrl: 'https://fnbe.zionsl.com/api/',
  userIdHeaderName: 'X-User-Id',
  tenantIdHeaderName: 'X-Tenant-Id',
  companyIdHeaderName: 'X-Company-Id',

  // DISPLAY_DATE_FORMAT: 'YY-MMM-DD',

  contact: {
    whatsapp: process.env.REACT_APP_WHATSAPP_NUMBER || '94XXXXXXXXX',
    email: process.env.REACT_APP_CONTACT_EMAIL || 'hello@sinhalahymnal.lk',
  },

  features: {
    // dataTableColumnVisibility: false,
    // actionColumnsRightEnd: false,
    // dataTableCSVExport: false,
    selectSearch: true,
    // returnToListAfterSave: false,
    version,
    // showThemeControls: true,
    // theme: "dark",
    // colorTheme: "sepia",
    // uiTheme: "fluent",
    // localMenu: false,
    // useMockApi: false,
    // useMockAuth: false,
    sso: {
      enabled: true,
      google: true,
      microsoft: true,
      apple: true,
    }
  },
};

export default config;
