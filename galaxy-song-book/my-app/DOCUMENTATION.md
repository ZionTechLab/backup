# Technical Documentation

## Project Overview

A React SPA for managing service operations — job registrations, invoices, business partners, vehicle confirmations, inquiries, and reference data. Built as an npm workspace monorepo with a shared component library.

---

## Key Technologies

| Technology | Role |
|---|---|
| React 19 | UI framework |
| Redux Toolkit | Auth state only |
| React Router v6 | Client-side routing with lazy loading |
| Formik + Yup | Form state and validation |
| Axios | HTTP client with interceptor layer |
| Bootstrap 5 | CSS framework |
| npm Workspaces | Monorepo — shared component package |

---

## Repository Structure

```
├── components/             # UI components
│   ├── DataTable/          # Paginated read-only table
│   ├── ErrorBoundary.jsx
│   ├── InputField/
│   ├── ImageInputField/
│   ├── Modal/
│   └── SwitchGroup/
├── config/
│   └── config.js           # API base URL, feature flags
├── features/               # Feature modules (not Redux slices)
│   ├── auth/               # Only feature with a Redux slice
│   ├── BusinessPartners/
│   ├── DailyReport/
│   ├── Dashboard/
│   ├── HRCM/
│   ├── Inquary/
│   ├── Invoice/
│   ├── ItemMaster/
│   ├── JobRegistration/
│   ├── JollySnap/
│   ├── Refferances/
│   ├── Reports/
│   ├── SongBook/
│   ├── UomMaster/
│   ├── UserMaster/
│   └── VehicaleConfirmation/
├── helpers/
│   ├── axiosInterceptors.js
│   └── formikBuilder.js    # Core form pattern
├── layout/
│   └── MainLayout.jsx      # Sidebar + responsive shell
├── services/
│   └── MessageBoxService.js
├── App.js
├── AppRoutes.js            # All route definitions (lazy loaded)
├── store.js
└── storeAccessor.js        # Exposes getState/dispatch outside React
```

---

## Core Patterns

### 1. Declarative Form Pattern (`formikBuilder`)

The primary way forms are built in this app. Define a `fields` config object; `useFormikBuilder` derives Formik state and Yup validation from it. `FieldsRenderer` renders the fields automatically.

```js
const fields = {
  uomName: {
    type: 'text',
    placeholder: 'UOM Name',
    initialValue: '',
    validation: Yup.string().required('UOM name is required'),
    className: 'col-12',
  },
  active: {
    type: 'switch',
    initialValue: true,
    placeholder: 'Active',
  },
};

const formik = useFormikBuilder(fields, handleSubmit);

return <FieldsRenderer fields={fields} formik={formik} />;
```

**Supported field types:** `text`, `number`, `textarea`, `select`, `phone`, `amount`, `checkbox`, `switch`, `switch-group`, `images`, `partner-select`, `br`, `heading`

**Default initial values by type** (applied when `initialValue` is absent):

| Type | Default |
|---|---|
| `checkbox`, `switch` | `false` |
| `images`, `switch-group` | `[]` |
| everything else | `''` |

---

### 2. Feature Module Structure

Each feature follows the same layout:

```
features/SomeFeature/
├── index.jsx        # List view — DataTable + delete handler
├── Add.jsx          # Add/edit form — formikBuilder pattern
└── service.js       # Axios calls, returns { success, data, error }
```

The list view mounts `DataTable` unconditionally and passes `loading` as a prop so the table shows an inline spinner during fetch rather than unmounting.

---

### 3. UI Components (`src/components/`)

Local components used throughout the app:

- **`DataTable`** — read-only paginated table. Props: `data`, `columns`, `loading`, `name`, `page`, `onPageChange`, `pageSize`, `pageSizeOptions`. Accepts `children` rendered in the toolbar.
- **`InputField`** — form input with support for text, select, checkbox, switch, phone, amount, images, and more.
- **`Modal`** — modal dialogs for confirmations and messages.
- **`SwitchGroup`** — group of toggle switches.

Import: `import { DataTable } from '../components/DataTable'`

---

### 4. `MessageBoxService`

Global imperative service for alerts and confirmations. Backed by a React portal, decoupled from component trees.

```js
// Alert
MessageBoxService.show({ message: 'Saved!', type: 'success', onClose: () => {} });

// Confirm (returns Promise<boolean>)
const confirmed = await MessageBoxService.confirmAsync({
  message: 'Delete this record?',
  type: 'danger',
  confirmText: 'Delete',
  cancelText: 'Cancel',
});
```

---

## State Management

Redux Toolkit is used **for auth only**. All other feature state is local `useState` inside components.

### Auth Slice (`src/features/auth/authSlice.js`)

| State field | Description |
|---|---|
| `token` | Access token — kept in memory only (XSS protection) |
| `refreshToken` | Stored in `localStorage` |
| `user` | User profile object |
| `isLoggedIn` | Boolean derived from token presence |
| `expiresAt` | Token expiry timestamp |

Key exports from `src/features/auth/index.js`:

- `selectIsLoggedIn` — boolean selector
- `selectUserId` — resolves user ID across multiple field name conventions
- `refreshAccessToken` — async thunk, calls refresh endpoint
- `logoutAsync` — async thunk, clears server session and local storage

On rejected refresh or logout, `clearAuthStorage()` wipes all auth keys from `localStorage`.

---

## Routing

Routes are defined in `src/AppRoutes.js` using React Router v6. All feature routes are **lazy loaded** via `React.lazy` + `Suspense` to reduce initial bundle size.

Protected routes use a `ProtectedRoute` component that redirects to `/login` when `isLoggedIn` is false.

The main shell (`MainLayout`) wraps all authenticated routes and handles responsive sidebar toggling using the Bootstrap `lg` breakpoint (992px).

---

## API Layer

### Axios Interceptors (`src/helpers/axiosInterceptors.js`)

Registered once at app startup via `registerAxiosInterceptors()`. Two interceptors:

**Request interceptor:**
1. Checks if the access token is within 30 seconds of expiry
2. If so, dispatches `refreshAccessToken` (single-flight — concurrent requests share one refresh promise)
3. Attaches `Authorization: Bearer <token>` header
4. Attaches `X-User-Id` header (configurable via `config.userIdHeaderName`)

**Response interceptor:**
- On `401`: attempts one token refresh and retries the original request
- Sets `_retry` flag to prevent infinite loops

Default timeout: 30 seconds.

### Service Layer

Each feature has a `service.js` that wraps Axios calls and normalises responses to `{ success: boolean, data?, error? }`. Components never call Axios directly.

---

## Configuration (`src/config/config.js`)

```js
const config = {
  apiBaseUrl: '...',
  userIdHeaderName: 'X-User-Id',
  features: {
    selectSearch: false,         // Searchable select dropdowns
    dataTableCSVExport: false,   // CSV export button on DataTable
    dataTableColumnVisibility: false,
    useMockApi: false,           // Local fake API layer
    useMockAuth: false,          // Bypass auth network call
    showThemeControls: true,
    theme: 'light',
    colorTheme: 'sepia',
    uiTheme: 'fluent',
  },
};
```

Feature flags are read at component level via `config.features.*`.

---

## Error Handling

An `ErrorBoundary` (class component) wraps the entire app in `App.js`. Unhandled render errors are caught, logged via `console.error`, and shown as a fallback UI rather than a blank screen.

---

## Setup

### Prerequisites
- Node.js v16+
- npm v8+ (workspace support required)

### Install
```bash
npm install
```
Installs all dependencies for the React app.

### Environment
Create `.env` in the project root:
```
REACT_APP_API_BASE_URL=https://your-api.example.com/api/
```
The app reads this at build time. `src/config/config.js` overrides it at runtime if needed.

### Run
```bash
npm start
```
Available at `http://localhost:3000`.

### Build
```bash
npm run build
```
Output in `/build`. Deploy to any static host (Vercel, Netlify, S3, etc.).

---

## Known Limitations

- No test suite (React Testing Library is installed but no tests are written)
- `SwitchGroup` maintains internal state alongside Formik — a controlled-component rewrite is planned (see `FUTURE_IMPROVEMENTS.md`)
- `fields` config objects are declared inside component functions in most `Add.jsx` files, causing `FieldsRenderer` to re-render on every parent render
