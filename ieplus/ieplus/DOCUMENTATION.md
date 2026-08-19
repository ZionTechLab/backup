# Zion Sales Force Management (`ieplus`) — Complete Documentation

A React single‑page application for a field sales / van‑sales operation. It lets a
logged‑in sales rep view live stock by route, browse route‑wise customers and their
outstanding balances, and (in partially‑built modules) take point‑of‑sale orders and
register new customers.

- **App name (package):** `ieplus`
- **Display name (manifest / page title):** *Zion Sales Force Management*
- **Version:** `0.1.0` (private, bootstrapped with Create React App)
- **Backend base URL:** `https://iepbe001.zionsl.com/` (see [src/Common/Config.js](src/Common/Config.js))

---

## Table of Contents

1. [Tech Stack](#1-tech-stack)
2. [Scripts](#2-scripts)
3. [Application Bootstrap & Architecture](#3-application-bootstrap--architecture)
4. [Redux Store](#4-redux-store)
5. [Backend API](#5-backend-api)
6. [Data Model & localStorage Cache](#6-data-model--localstorage-cache)
7. [Authentication & Initialization Flow](#7-authentication--initialization-flow)
8. [Navigation (Drawer, AppBar, Menu)](#8-navigation-drawer-appbar-menu)
9. [Pages / Features (every screen)](#9-pages--features-every-screen)
10. [Public Assets & PWA](#10-public-assets--pwa)
11. [Known Issues & Broken References](#11-known-issues--broken-references)
12. [File Index](#12-file-index)

---

## 1. Tech Stack

| Concern | Library |
|---|---|
| UI framework | React 18 (`react`, `react-dom`) |
| Build tooling | `react-scripts` 5 (Create React App, not ejected) |
| State management | Redux Toolkit (`@reduxjs/toolkit`), `react-redux`, `redux`, `redux-thunk` |
| HTTP client | `axios` |
| UI components | MUI v5 (`@mui/material`, `@mui/icons-material`), Emotion |
| Forms & validation | `formik` + `yup` |
| LINQ‑style data ops | `linq` (imported as `linq` or `Enumerable`) |
| Fonts | `@fontsource/roboto` |
| Web vitals | `web-vitals` (reporting wired but unused) |

> ⚠️ Some POS files import `@material-ui/core` (MUI v4), which is **not** in
> `package.json`. See [Known Issues](#11-known-issues--broken-references).

---

## 2. Scripts

Defined in [package.json](package.json):

| Command | Action |
|---|---|
| `npm start` | Run dev server at `http://localhost:3000` |
| `npm run build` | Production build into `build/` |
| `npm test` | CRA/Jest test runner (watch mode) |
| `npm run eject` | One‑way CRA eject |

ESLint config: `react-app`, `react-app/jest`. Browserslist: CRA defaults.

---

## 3. Application Bootstrap & Architecture

### Entry point — [src/index.js](src/index.js)

Creates the React root, wraps `<App />` in the Redux `<Provider>`, imports global
`index.css`, and calls `reportWebVitals()`. `React.StrictMode` is present but
commented out.

### Root component — [src/App.js](src/App.js)

`App` is a state machine driven by the `auth` slice. Two booleans decide what renders:

| `isAuthOK` | `isInitOK` | Rendered |
|---|---|---|
| `false` | — | `<Test />` → the **Login** screen ([src/Components/item2.js](src/Components/item2.js)) |
| `true` | `false` | `<Spinner />` (loading) and a `dispatch(init({ user_id }))` is fired via `useEffect` |
| `true` | `true` | The authenticated shell: `<Drawer />` + the active page |

When authenticated, the active page is chosen by a `switch` on `authData.ActiveForm`:

| `ActiveForm` | Renders |
|---|---|
| `"Home"` | The literal string `Welcome` |
| `"Admin"` | `<Admin />` **only if** `localStorage.userType == 1`, else the text `No Access` |
| `"Inventory"` | `<Item />` → [src/Components/Inventory/index.js](src/Components/Inventory/index.js) |
| `"Outstanding"` | `<RouteWiseCustomers />` → [src/Components/Customer/Customer2.js](src/Components/Customer/Customer2.js) |
| *default* | The text `404` |

> Note: there is **no react‑router**. "Routing" is purely the `ActiveForm` string in
> Redux, set by the drawer menu.

> ⚠️ `App.js` imports `./Components/Admin`, but the `src/Components/Admin/` directory
> is **empty** — this import currently breaks the build. See [Known Issues](#11-known-issues--broken-references).

---

## 4. Redux Store

Configured in [src/store/index.js](src/store/index.js) via `configureStore`. Five
reducers are registered:

| Slice key | Source | Purpose |
|---|---|---|
| `auth` | [authSlice.js](src/store/slices/authSlice.js) | Login, initialization, active page |
| `inventory` | [inventorySlice.js](src/store/slices/inventorySlice.js) | Route‑wise stock list |
| `songs` | [songsSlice.js](src/store/slices/songsSlice.js) | CRA learning leftover (unused by UI) |
| `sake` | [sakeSlice.js](src/store/slices/sakeSlice.js) | CRA learning leftover (unused by UI) |
| `user` | `./slices/userSlice` | **Imported but file does not exist** (build break) |

A global `reset` action is defined in [src/store/actions.js](src/store/actions.js)
(`createAction('app/reset')`) and handled by `songs`/`sake` (resets them to `[]`).

### 4.1 `auth` slice — [src/store/slices/authSlice.js](src/store/slices/authSlice.js)

**State shape:**

```js
{ ActiveForm: '', isAuthOK: false, isInitOK: false, user_id: '', err: '', route: '' }
```

**Reducers:**
- `setAuthStatus(payload)` — pushes payload (note: written as if state were an array; effectively unused).
- `setActiveForm(payload)` — sets `ActiveForm` (the navigation switch).

**Async thunks:**
- `logginAsync` → `POST {API_URL}Inventory/Login`. On fulfilled, sets
  `isAuthOK = response.isSuccess`, `user_id`, `err = response.strMessage`, and
  `ActiveForm = 'Home'` when authenticated. On rejected, clears auth and stores the
  error message.
- `initAsync` → `POST {API_URL}Inventory/initialize`. On fulfilled, **persists the
  whole payload into `localStorage`** (see [§6](#6-data-model--localstorage-cache))
  and sets `isInitOK = true`, `route = payload.route`.

**Thunk creators exported:** `loggin(payload)`, `init(payload)`.

### 4.2 `inventory` slice — [src/store/slices/inventorySlice.js](src/store/slices/inventorySlice.js)

**State shape:** `{ init: [], stock: [], status: 'idle' }`

**Async thunk `getInventoryAsync(payload)`** where `payload = { route, isInit }`:
1. `GET {API_URL}Inventory/Get_Inventory` → live stock array.
2. Reads `itemPricing` from `localStorage`, filters rows where
   `route_Code.toUpperCase() == payload.route`.
3. Uses `linq` to **inner‑join** three sources on `item_ID`:
   `localStorage.items` ⋈ `Get_Inventory` response ⋈ filtered `itemPricing`,
   merging all fields with `{ ...left, ...right }`.
4. Returns the joined array → stored in `state.stock`.

`status` transitions: `idle` → `Processing` (pending) → `pass` (fulfilled).
Exported thunk creator: `getInventory(payload)`.

### 4.3 `songs` / `sake` slices

Both initialize to `['PK', 'GK']` and expose `addSong/removeSong` and
`addSake/removeSake`. They respond to the global `reset` action by emptying.
**Not referenced by any rendered component** — leftovers from a Redux tutorial.

---

## 5. Backend API

Base URL from [src/Common/Config.js](src/Common/Config.js):
`https://iepbe001.zionsl.com/` (a commented localhost URL
`https://localhost:44303/` is the dev alternative).

| Method | Endpoint | Body / Param | Response (used fields) |
|---|---|---|---|
| `POST` | `Inventory/Login` | `{ user_id, password }` | `{ isSuccess: bool, strMessage: string }` |
| `POST` | `Inventory/initialize` | `{ user_id }` | `{ items, customer, customerOutstanding, route, userType, saleHistory, itemPricing }` |
| `GET` | `Inventory/Get_Inventory` | — | array of `{ item_ID, qty, ... }` (live stock) |
| `GET` | `Inventory/getImage/{item_ID}` | path param | item image (used as `<img src>`) |

There is no auth token / header handling — login simply gates the UI; subsequent
calls are unauthenticated GETs.

---

## 6. Data Model & localStorage Cache

On successful `initialize`, `authSlice` writes these `localStorage` keys (all JSON
unless noted). They are the app's offline data source — most screens read from
`localStorage`, not the network.

| Key | Type | Written from | Consumed by |
|---|---|---|---|
| `items` | JSON array | `payload.items` | Inventory join, POS |
| `customer` | JSON array | `payload.customer` | Customer screens, POS customer search |
| `customerOutstanding` | JSON array | `payload.customerOutstanding` | Outstanding/transaction screens |
| `route` | string (CSV, e.g. `"A,B,C"`) | `payload.route` | Route filters & selectors |
| `userType` | value (`1` = admin) | `payload.userType` | Admin access gate in `App.js` |
| `saleHistory` | JSON array | `payload.saleHistory` | Stored, not yet read by UI |
| `itemPricing` | JSON array | `payload.itemPricing` | Route‑wise pricing join |

> `synchronizedTime` and `userId` writes exist in the code but are **commented out**.

### 6.1 Item record (after the inventory join)

Fields referenced in [Inventory/item.js](src/Components/Inventory/item.js) and
[Components/Item.js](src/Components/Item.js):

| Field | Meaning |
|---|---|
| `item_ID` | Item code (also used for image lookup) |
| `itemName` | Description / display name |
| `qty` | Stock quantity (from live `Get_Inventory`) |
| `uomCode` | Unit of measure |
| `packingSize` | Units per pack |
| `costPrice_WA` | Weighted‑avg cost price (**only shown to `user_id == "indika"`**) |
| `sellingPrice` | Selling price |
| `route_Code` | Route this pricing row belongs to (from `itemPricing`) |

### 6.2 Customer record

Fields referenced in customer screens and `CustomerSearch.js`:

| Field | Meaning |
|---|---|
| `customer_ID` | Customer code |
| `customerName` | Customer name |
| `route_Code` | Route assignment (matched against the CSV `route`) |
| `telephone` | Land line |
| `mobile` | Mobile number |
| `addressRegister` | Registered address |
| `outstanding` | Computed/joined outstanding total |
| `summary` | Computed sum of all transaction amounts |

### 6.3 Outstanding transaction record (`customerOutstanding`)

| Field | Meaning |
|---|---|
| `customerID` | FK to customer (`customer_ID`) |
| `transactionCode` | Invoice / document number |
| `transactionDate` | Date (rendered `en-US` locale) |
| `transactionRemark` | Free‑text remark |
| `transactionType` | Numeric category — see table below |
| `amount` | Outstanding balance amount |
| `totalAmount` | Original document amount |
| `age` | Ageing value |

**`transactionType` codes** (derived from filters across the customer screens):

| Code(s) | Category | Notes |
|---|---|---|
| `1`, `2` | Invoices / Outstanding Invoices | Shown in the invoices table |
| `3` | Returned Cheques | Separate table |
| `5` | Cheque In Hand | **Excluded** from the outstanding sum; styled green (`.CIH`) |
| `0`, `4`, `7`, `8`, `9`, `10` | Other | Filter present in commented‑out section |

Outstanding aggregation logic ([Customer2.js](src/Components/Customer/Customer2.js)):
group by `customerID`, then
- `summary` = sum of all `amount`
- `outstanding` = sum of `amount` where `transactionType != 5`

---

## 7. Authentication & Initialization Flow

1. App loads → `isAuthOK=false` → **Login screen** ([item2.js](src/Components/item2.js)).
2. User submits User ID + Password → `dispatch(loggin({ user_id, password }))`.
   - Validation (`yup`): User ID min 5 chars & required; Password min 4 chars & required.
   - Server `isSuccess=true` → `isAuthOK=true`, `ActiveForm='Home'`; otherwise the
     server's `strMessage` is shown inline above the Sign‑in button.
3. `App` `useEffect` sees `isAuthOK && !isInitOK` → renders `<Spinner />` and
   `dispatch(init({ user_id }))`.
4. `initialize` returns the data bundle → cached to `localStorage` → `isInitOK=true`.
5. App renders the **Drawer + Home** ("Welcome").

There is **no logout** action and no session persistence — a page refresh returns
to the Login screen (though `localStorage` data survives).

---

## 8. Navigation (Drawer, AppBar, Menu)

### Menu definition — [src/Common/menu.js](src/Common/menu.js)

`MenuItems` is an array of `[icon, label]` pairs:

| Icon | Label (`ActiveForm`) |
|---|---|
| Home | `Home` |
| Admin Panel Settings | `Admin` |
| Inventory2 | `Inventory` |
| Inventory | `Outstanding` |
| Help | `Help` (no case in `App.js` → renders `404`) |

### Drawer — [src/Components/Drawer/index.js](src/Components/Drawer/index.js)

`TemporaryDrawer` renders the `AppBar` plus a MUI `<Drawer>` containing the menu
list. Clicking a menu item dispatches `setActiveForm(label)`. The drawer open state
is local component state; `toggleDrawer` ignores `Tab`/`Shift` keydown events.

### AppBar — [src/Components/Drawer/AppBar.js](src/Components/Drawer/AppBar.js)

Fixed top bar (style in [AppBar.module.css](src/Components/Drawer/AppBar.module.css),
indigo `#3f51b5`): a hamburger `IconButton` that opens the drawer, a button showing
the current `ActiveForm`, and two empty (placeholder) icon buttons for *Refresh* and
*account* on the right.

---

## 9. Pages / Features (every screen)

### 9.1 Login — [src/Components/item2.js](src/Components/item2.js)

- Full‑height radial‑gradient blue background ([Auth.module.css](src/Components/Auth.module.css)) with the `ZionSFM_logo.png`.
- Formik form, MUI filled `TextField`s:
  - **User ID** (`email` field — initial value oddly `"asasas"`, label "User ID")
  - **Password** (`type=password`)
- Inline server error text (`authState.err`) and a full‑width **Sign in** button.
- An unused `email2` initial value exists in the form model.

### 9.2 Spinner — [src/Components/Spinner/Spinner.js](src/Components/Spinner/Spinner.js)

A CSS loader `<div>` plus the text `Loading...`. Shown between successful login and
completed initialization.

### 9.3 Home

Not a component — `App.js` returns the literal string **`Welcome`** for
`ActiveForm === "Home"`.

### 9.4 Admin

`App.js` renders `<Admin />` when `userType == 1`, else the text **`No Access`**.
The `Admin` component file is **missing** (empty directory) — currently a build
break. Intended as an admin‑only area gated by `localStorage.userType`.

### 9.5 Inventory (active) — [src/Components/Inventory/index.js](src/Components/Inventory/index.js)

The screen shown for `ActiveForm === "Inventory"`.

- **On mount:** reads `localStorage.route`, splits the CSV into route options,
  selects the first route, and dispatches `getInventory({ route, isInit:true })`.
- **Bottom fixed control bar** (`.appBar2`):
  - **Find** text input — client‑side, case‑insensitive `itemName` contains filter.
  - **Route** MUI `Select` — re‑dispatches `getInventory` for the chosen route.
- **List:** for each stock row, an *image* button + an `<Item>` card.
- **Image modal:** opens `Inventory/getImage/{item_ID}`, shows the image and item
  name with a close (X) icon.

#### Item card — [src/Components/Inventory/item.js](src/Components/Inventory/item.js)

Renders per item:
- Header: `item_ID - itemName`
- Row 1: `Stock : {qty} {uomCode}` | `Packing Size : {packingSize}`
- Row 2: `Cost Price : {costPrice_WA}` **only when `user_id === "indika"`** |
  `sellingPrice` (both formatted to 2 decimals).

### 9.6 Inventory (legacy) — [src/Components/Item.js](src/Components/Item.js)

An older **class component** alternative to 9.5 (not wired into `App.js` routing).
- `componentDidMount`: `GET Get_Inventory` into `stock`; reads `itemPricing` into `Pricing`.
- `onSearch(Route_Code, FilterText)`: filters pricing by route, triple `linq` join
  (`items` ⋈ `stock` ⋈ pricing), then filters by `itemName` contains.
- Renders a MUI `Table` (Item, Description, Qty, Price). Clicking the item name
  opens an image `Modal` (`Inventory/getImage/{item_ID}`).
- Two text inputs: **Find** and **Route**. Imports `AppBar` but it is commented out.

### 9.7 Outstanding / Route‑wise Customers (active) — [src/Components/Customer/Customer2.js](src/Components/Customer/Customer2.js)

The screen shown for `ActiveForm === "Outstanding"`.

- **On mount:** reads `customer`, `customerOutstanding`, and `route` (CSV) from
  `localStorage`. Filters customers to the rep's routes. Groups outstanding by
  `customerID` computing `Txn`, `summary`, and `outstanding` (excludes type 5).
  Left‑joins customers with their grouped transactions.
- **Bottom fixed bar:** a **Find** input filtering by `customerName` (an
  "Outstanding Only" checkbox is present but commented out).
- **Body:** grouped by route (`Route - {r}`); each customer is a clickable card
  showing `customer_ID`, `customerName`, and outstanding total (2 decimals, `0.00`
  when undefined).
- **Modal:** clicking a card opens that customer's transaction list via the
  transaction component.

#### Transaction list — [src/Components/Customer/txn.js](src/Components/Customer/txn.js)

Renders each transaction row: `transactionCode`, `transactionDate` (en‑US),
`transactionRemark`, `age`, and `amount` (2 decimals). Rows with
`transactionType == 5` get the green `.CIH` style.

### 9.8 Route‑wise Customers (alternate) — [src/Components/Customer/RouteWiseCustomers.js](src/Components/Customer/RouteWiseCustomers.js)

A more detailed class‑component version (not wired into `App.js`; note `App.js`
imports a *different* `RouteWiseCustomers` — actually `Customer2.js`).

- `componentDidMount`: filters `customer` by route, sorts by name, groups by
  `route_Code` (via `linq`), loads `customerOutstanding`.
- Renders MUI `Accordion` per route; each expands to a paginated `<Customers>` list.
- A row's edit icon opens a `Modal` showing two tables for the selected customer:
  - **Invoices** (`transactionType` 1 or 2)
  - **Returned Cheques** (`transactionType` 3)
  - Commented‑out **Cheques In Hand** (type 5) and **Other** (types 0/4/7/8/9/10) tables.
  - Columns: Inv. No., Inv. date, Inv Amount (`totalAmount`), Balance (`amount`).

#### Customers list — [src/Components/Customer/Customers.js](src/Components/Customer/Customers.js)

MUI `Grid` rows of `customer_ID | customerName | outstanding | edit‑icon`,
paginated 10 per page, with an edit click reporting `{ Customer_Code, customer_Name }`.

#### Pagination — [src/Components/Customer/Pagination.js](src/Components/Customer/Pagination.js)

Numbered page list (`ceil(totalPosts / postsPerPage)`); clicking a number calls
`paginate(n)`. (`SelectedPage` is hard‑coded to `1` for active‑page styling.)

### 9.9 New Customer — [src/Components/Customer/NewCustomer.js](src/Components/Customer/NewCustomer.js)

An incomplete class component for adding customers. Controlled form with validation:

| Field | Type | Validation |
|---|---|---|
| `customerName` | input | required, min length 6 |
| `customerAddress` | textarea | required, min length 6 |
| `telephoneNo` | input | required, min length 10 |
| `mobile` | input | required, min length 10 |
| `email` | input | required, email pattern |

`checkValidity` supports `required`, `minLength`, `maxLength`, `isEmail`,
`isNumeric`. **Not wired into navigation** and depends on missing UI components
(`UI/Input`, `UI/Button`, `UI/Spinner`) — see [Known Issues](#11-known-issues--broken-references).
`submitHandler` references a nonexistent `password` control.

### 9.10 POS — Order — [src/Components/POS/Order.js](src/Components/POS/Order.js)

A point‑of‑sale order builder (class component, **not wired into navigation**).

- `connect`ed to Redux (`stock`, `items` — note it reads `state.init.items`, which
  is not a registered slice key).
- Customer selection flow with `SelectedCustomerValidity`: `0` invalid → `1` valid
  (a **Select** button appears) → `2` confirmed (order entry shows).
- Confirmed view shows the customer header and a list of `<Item2>` order lines plus
  an **Add Item** action.
- **Add Item modal:** a *Find Item* field filtering `props.items` by name
  (`linq`, top 10), click a row to add it; duplicate selection alerts
  "Selected item already added!".
- Running total `Sum` of line `Amount`s is displayed.

#### POS line item — [src/Components/POS/Item2.js](src/Components/POS/Item2.js)

- State: `Qty` (initialized to `PackingSize`), `DiscountPre`, `Amount`.
- `+ / -` buttons change `Qty` by `PackingSize` (floored at 0).
- `Amount = Qty * UnitPrice * (100 - Discount%) / 100`.
- Discount modal: input validated against `MaxDiscount`; values above max are
  rejected (logs `overdisc`).
- Emits state to parent via `props.changed` on `Amount` change.
- Uses `<Price>` from `Common/DecimalFormater` (**missing file**).

#### POS customer search — [src/Components/POS/CustomerSearch.js](src/Components/POS/CustomerSearch.js)

- Loads `customer` + `customerOutstanding` from `localStorage`.
- An `Autocomplete` (`{key: customer_ID, value: customerName}`) selects a customer.
- Shows customer detail (code, telephone, mobile, address, route) and four
  `KpiCard`s: **Cr. Period**, **Credit Limit**, **Outstanding**, **Balance**
  (Cr. Period / Credit Limit / Balance hard‑coded to `0`).
- Two grids: **Outstanding Invoices** (`transactionType` 1/2) and
  **Returned Cheques** (`transactionType` 3) — columns Inv. Date, Inv. No.,
  Amount (`totalAmount`), Balance (`amount`).
- Depends on missing `UI/Autocomplete`, `UI/Cards/KpiCard`, `Common/DecimalFormater`.

### 9.11 Cart — [src/Components/Cart.js](src/Components/Cart.js)

Entirely commented out — a dead Redux‑counter demo. No exported component.

---

## 10. Public Assets & PWA

- [public/index.html](public/index.html): title & description "Zion Sales Force
  Management"; favicon & apple‑touch‑icon point to `image/ieplus-logo.png`;
  theme color `#000000`.
- [public/manifest.json](public/manifest.json): installable PWA metadata,
  `short_name`/`name` "Zion Sales Force Management", `display: standalone`, icons
  `favicon.ico` / `logo192.png` / `logo512.png`.
- `public/image/ieplus-logo.png` — browser/app icon.
- `public/image/ZionSFM_logo.png` — logo on the Login screen.
- `public/robots.txt`, `public/favicon.ico`, `public/logo192.png`,
  `public/logo512.png` — CRA defaults.
- No service worker is registered (CRA default; not a true offline PWA despite the
  manifest).

---

## 11. Known Issues & Broken References

These will prevent a clean `npm start` / `npm run build` until resolved:

| # | Problem | Location |
|---|---|---|
| 1 | `import Admin from "./Components/Admin"` but `src/Components/Admin/` is **empty** | [src/App.js](src/App.js) |
| 2 | `store/index.js` imports `./slices/userSlice` (`userReducer`, `GetAllUsers`, `Update_User`) — **file does not exist** | [src/store/index.js](src/store/index.js) |
| 3 | `NewCustomer.js` imports `UI/Input/Input`, `UI/Button/Button`, `UI/Spinner/Spinner` — **none exist** | [src/Components/Customer/NewCustomer.js](src/Components/Customer/NewCustomer.js) |
| 4 | POS files import `@material-ui/core` (MUI v4) which is **not a dependency** (only `@mui/material` v5 is installed) | [Order.js](src/Components/POS/Order.js), [Item2.js](src/Components/POS/Item2.js) |
| 5 | `Common/DecimalFormater` (`Price`) imported but **missing** | [POS/Item2.js](src/Components/POS/Item2.js), [POS/CustomerSearch.js](src/Components/POS/CustomerSearch.js) |
| 6 | `UI/Autocomplete/Autocomplete` and `UI/Cards/KpiCard` imported but **missing** | [POS/CustomerSearch.js](src/Components/POS/CustomerSearch.js) |
| 7 | `Order.js` maps `state.init.items` but there is no `init` reducer (it is `inventory.init`) | [POS/Order.js](src/Components/POS/Order.js) |

Other notes:
- No router, no logout, no token/auth header on API calls.
- `setAuthStatus` reducer uses array `.push` on an object state (effectively dead).
- Login form's User ID initial value is the placeholder string `"asasas"`.
- `Help` menu item has no route case → renders `404`.
- `songs` / `sake` slices, `Cart.js`, and the legacy `Item.js`/`RouteWiseCustomers.js`
  are unused leftovers.
- The active "Outstanding" screen is `Customer/Customer2.js`, **not** the more
  detailed `Customer/RouteWiseCustomers.js`.

---

## 12. File Index

| Path | Role |
|---|---|
| [src/index.js](src/index.js) | React/Redux bootstrap |
| [src/App.js](src/App.js) | Root state machine & "routing" |
| [src/Common/Config.js](src/Common/Config.js) | API base URL |
| [src/Common/menu.js](src/Common/menu.js) | Drawer menu items |
| [src/store/index.js](src/store/index.js) | Store config & re‑exports |
| [src/store/actions.js](src/store/actions.js) | Global `reset` action |
| [src/store/slices/authSlice.js](src/store/slices/authSlice.js) | Auth + init |
| [src/store/slices/inventorySlice.js](src/store/slices/inventorySlice.js) | Route stock |
| [src/store/slices/songsSlice.js](src/store/slices/songsSlice.js) | Unused demo |
| [src/store/slices/sakeSlice.js](src/store/slices/sakeSlice.js) | Unused demo |
| [src/Components/item2.js](src/Components/item2.js) | **Login screen** |
| [src/Components/Auth.module.css](src/Components/Auth.module.css) | Login styles |
| [src/Components/Spinner/Spinner.js](src/Components/Spinner/Spinner.js) | Loading spinner |
| [src/Components/Drawer/index.js](src/Components/Drawer/index.js) | Nav drawer |
| [src/Components/Drawer/AppBar.js](src/Components/Drawer/AppBar.js) | Top app bar |
| [src/Components/Inventory/index.js](src/Components/Inventory/index.js) | **Inventory page** |
| [src/Components/Inventory/item.js](src/Components/Inventory/item.js) | Inventory item card |
| [src/Components/Item.js](src/Components/Item.js) | Legacy inventory table (unused) |
| [src/Components/Customer/Customer2.js](src/Components/Customer/Customer2.js) | **Outstanding page** |
| [src/Components/Customer/txn.js](src/Components/Customer/txn.js) | Transaction list |
| [src/Components/Customer/RouteWiseCustomers.js](src/Components/Customer/RouteWiseCustomers.js) | Detailed route customers (unused) |
| [src/Components/Customer/Customers.js](src/Components/Customer/Customers.js) | Paginated customer grid |
| [src/Components/Customer/Pagination.js](src/Components/Customer/Pagination.js) | Pager |
| [src/Components/Customer/NewCustomer.js](src/Components/Customer/NewCustomer.js) | New‑customer form (broken) |
| [src/Components/POS/Order.js](src/Components/POS/Order.js) | POS order builder (broken) |
| [src/Components/POS/Item2.js](src/Components/POS/Item2.js) | POS line item (broken) |
| [src/Components/POS/CustomerSearch.js](src/Components/POS/CustomerSearch.js) | POS customer search (broken) |
| [src/Components/Cart.js](src/Components/Cart.js) | Commented‑out dead code |
| `src/Components/Admin/` | **Empty** (referenced by App.js) |
| [public/index.html](public/index.html) | HTML shell |
| [public/manifest.json](public/manifest.json) | PWA manifest |

---

*Generated from a full read of every source, store, config, and public file in the
repository as of branch `master`.*
