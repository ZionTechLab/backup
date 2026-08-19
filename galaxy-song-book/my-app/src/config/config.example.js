import pkg from '../../package.json';
const { version } = pkg;

const config = {
  // apiBaseUrl: 'http://localhost:3000/api/',
  // apiBaseUrl: 'https://song-book-be.zionsl.com/api/',
  // apiBaseUrl: 'http://samanala-ent.propcsol.com/api/',
  apiBaseUrl: 'https://YOUR-FUNCTION-APP.azurewebsites.net/api/',

  userIdHeaderName: 'X-User-Id',
  tenantIdHeaderName: 'X-Tenant-Id',
  companyIdHeaderName: 'X-Company-Id',

  contact: {
    whatsapp: process.env.REACT_APP_WHATSAPP_NUMBER || 'YOUR_WHATSAPP_NUMBER',
    email: process.env.REACT_APP_CONTACT_EMAIL || 'your@email.com',
  },

  features: {
    dataTableColumnVisibility: false,
    actionColumnsRightEnd: true,
    dataTableCSVExport: false,
    selectSearch: true,
    version,
    showThemeControls: false,
    theme: 'dark',
    colorTheme: 'sepia',
    uiTheme: 'fluent',
    localMenu: false,
    useMockApi: false,
    useMockAuth: false,
    sso: {
      enabled: true,
      google: true,
      microsoft: true,
      apple: true,
    },
  },
};

export default config;
