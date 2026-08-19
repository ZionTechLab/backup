
# Copilot Instructions for service-plus

## What this app is
React SPA for service operations (inquiries, partners, invoices, reports). UI is tabbed and inline (no modals except confirmations/column visibility). Data comes from a backend API via axios; UI/theme prefs persist in localStorage.

## Tech and build
- React 19 + Redux Toolkit (auth slice only); React Router v6 with **BrowserRouter**; CRA scripts in `package.json`.
- Forms: Formik + Yup via `helpers/formikBuilder.js`. Styling: Bootstrap 5 + `themes.css`.
- Backend: axios through `helpers/axiosMiddleware.js` (barrel for `axiosInterceptors.js` + `axiosRequest.js` + `axiosErrorHandler.js`) pointing to `config.apiBaseUrl` (see `src/config/config.js`). PWA enabled via `serviceWorkerRegistration`.
- Shared UI components: Local components in `src/components/`. Import as `import { DataTable } from '../components/DataTable'`.
- Commands: `npm start` | `npm test` | `npm run build`.

## Architecture highlights
- App shell: `layout/MainLayout.jsx` with `Navbar`, `Drawer`, `Overlay`, `Footer`, and `<Outlet />`.
- Routing: `src/AppRoutes.jsx` with `ProtectedRoute`/`PublicRoute`. All feature routes are lazy-loaded via `React.lazy`. Error path: `/service-unavailable`.
- Drawer/menu: items are defined as `{ route, displayName, icon }` objects in `helpers/menuItems.js`. Nested children are supported via a `children` array.
- Store: `src/store.js`; auth slice only in `features/auth/authSlice.js`. All other feature state is local `useState`. Auth persists refresh token to localStorage; access token is kept in memory only (XSS protection).
- Error boundary: `src/components/ErrorBoundary.jsx` wraps the full app in `App.js`.

## Patterns to follow

### Forms
Use `useFormikBuilder(fields, onSubmit)` and `FieldsRenderer` from `src/helpers/formikBuilder.js`.

- Field config keys: `name`, `type`, `placeholder`, `className`, `initialValue`, `validation` (Yup), optional `dataBinding` for selects.
- **Declare `fields` at module level** (outside the component function) so `FieldsRenderer` does not re-render on every parent render.
- `useFormikBuilder` derives `initialValues` from `field.initialValue`. If absent, it falls back by type: `checkbox`/`switch` → `false`, `images`/`switch-group` → `[]`, everything else → `''`.
- Supported `InputField` types: `text`, `textarea`, `number`, `select`, `checkbox`, `switch`, `phone` (formatted to `(###) ###-####`), `amount` (commas; raw numeric string stored), `images`. Layout helpers: `type: 'br'` adds spacing; `type: 'heading'` renders a section header.
- Special: `type: 'partner-select'` renders `features/BusinessPartners/select-bp`.
- Example: see `src/features/BusinessPartners/AddBusinessPartner.jsx` and `src/helpers/transformDateFields.js`.

### Tables
Use `DataTable` from `src/components/DataTable` with columns `{ header, field, type?, isAction?, actionTemplate? }`.

- Always pass `loading={uiData.loading}` so the table shows an inline spinner during fetch — do not unmount it with `!uiData.loading &&`.
- Feature flags in `config.features`: `dataTableColumnVisibility` shows a gear to toggle columns; `actionColumnsRightEnd` moves action columns to the far right.

### Services
Create a class per feature in `service.js`. Call backend via `axiosRequest` from `helpers/axiosMiddleware.js`:

```js
import axios, { axiosRequest } from '../../helpers/axiosMiddleware';

async getAll() {
  return axiosRequest(axios.get(`${this.apiBase}/get-all`));
}
```

`axiosRequest` wraps the promise in try/catch, shows a loading spinner, and returns `{ success, data, error }`. Centralized errors: `handleAxiosError` (also from `axiosMiddleware.js`) shows a `MessageBoxService` popup and redirects to `/service-unavailable` on network failures.

### Feedback / confirmations
Never use `alert`. Two options:

**Option A — `MessageBoxService` (imperative, no JSX needed):**
```js
import MessageBoxService from '../../services/MessageBoxService';

MessageBoxService.show({ message: 'Saved!', type: 'success', onClose: () => {} });

const confirmed = await MessageBoxService.confirmAsync({
  message: 'Delete this record?', type: 'danger',
  confirmText: 'Delete', cancelText: 'Cancel',
});
```

**Option B — `useConfirm` hook (inline dialog):**
```js
const [ConfirmationDialog, confirm] = useConfirm();
// render <ConfirmationDialog /> in JSX
const ok = await confirm('Delete this record?', { type: 'danger' });
```

## Adding a feature (minimum steps)
1. Create `src/features/FeatureName/` with `index.jsx` (list), `Add.jsx` (form), `service.js` (API calls). Use the `create-feature` chat mode for scaffolding.
2. Add lazy-loaded routes in `src/AppRoutes.jsx`.
3. Add a menu entry in `src/helpers/menuItems.js` as `{ route: '/feature-url', displayName: 'Name', icon: 'bi bi-...' }`.
4. For forms: define a `fields` map at module level and wire with `useFormikBuilder`; render via `FieldsRenderer`.

## Key references by concern
- Routing: `src/AppRoutes.jsx`.
- Menu: `src/helpers/menuItems.js`.
- Forms: `src/helpers/formikBuilder.js`, `src/components/InputField/index.js`, `src/helpers/transformDateFields.js`.
- Services / back-end: `src/helpers/axiosMiddleware.js`, `src/helpers/axiosRequest.js`, `src/helpers/axiosErrorHandler.js`, `src/config/config.js`.
- UI components: `src/components/` (`DataTable.js`, `InputField/`, `Modal/`, etc.).
- Global UX: `src/components/MessageBoxProvider.jsx`, `src/hooks/useConfirm.js`, `src/hooks/useLoadingSpinner.js`, `src/services/MessageBoxService.js`.
- App shell / theme: `src/App.js`, `src/layout/*`, `src/helpers/runAppMigrations.js`. Theme keys in localStorage: `theme`, `uiTheme`, `colorTheme`.

## Gotchas
- `initialValue` in the field config is the source of initial form state — `useFormikBuilder` reads it to build `initialValues`. If omitted, a type-appropriate default is used (`''`, `false`, or `[]`).
- `fields` must be declared outside the component (module level) or wrapped in `useMemo`. Declaring inside the function body creates a new reference every render and defeats `React.memo` on `FieldsRenderer`.
- Add `disabled={formik.isSubmitting}` to every Save button to prevent double submits.
- Network failures auto-redirect to `/service-unavailable` via `axiosErrorHandler`; keep that route available in `AppRoutes.jsx`.
- Auth access token lives in memory only — lost on page reload. `App.js` silently refreshes it on mount if `isLoggedIn` is true but `token` is absent.
