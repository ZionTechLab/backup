import React from 'react';
import ReactDOM from 'react-dom/client';
import { Provider } from 'react-redux';
import store from './store';
import { setStore } from './storeAccessor';
import { registerAxiosInterceptors } from './helpers/axiosInterceptors';
import './index.css';
import './themes.css';
import './ui-polish.css';
import './meridian-tokens.css';
import './theme-palettes.css';
import './brand.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter } from "react-router-dom";
import { register as registerServiceWorker } from './serviceWorkerRegistration';
import config from './config/config';
import { applyBrand } from './config/brand';
import { initDataTableConfig } from './components/DataTable';
import { exportToCSV } from './hooks/useCSVExport';

// Apply white-label brand (title, favicon, primary color) before first paint.
applyBrand();

// Initialize DataTable configuration from app config
initDataTableConfig({
  features: {
    columnVisibility: config.features.dataTableColumnVisibility,
    csvExport: config.features.dataTableCSVExport,
    actionColumnsRightEnd: config.features.actionColumnsRightEnd,
  },
  onExport: exportToCSV,
});

// Optional mock API (UOM Master) controlled via config.features.useMockApi
if (config?.features?.useMockApi) {
  import('./mocks/fakeApi').then(mod => mod.registerFakeApi && mod.registerFakeApi());
}
const root = ReactDOM.createRoot(document.getElementById('root'));
// Make the Redux store accessible to non-React modules, then register
// axios interceptors — order matters: interceptors call getState()/dispatch().
setStore(store);
registerAxiosInterceptors();
root.render(
  <React.StrictMode>
    <BrowserRouter>
      <Provider store={store}>
        <App />
      </Provider>
    </BrowserRouter>
  </React.StrictMode>
);

reportWebVitals();
// Register Service Worker for PWA capabilities
registerServiceWorker();
