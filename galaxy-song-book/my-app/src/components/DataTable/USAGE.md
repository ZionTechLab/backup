# DataTable Usage Guide

## Import

```js
import { DataTable } from '../../components/DataTable/DataTable';
```

---

## Basic Usage

```jsx
<DataTable
  data={uiData.data}
  columns={columns}
  loading={uiData.loading}
/>
```

Always pass `loading` so the table shows an inline spinner during fetch. Do not unmount with `!uiData.loading &&`.

---

## Props

| Prop | Type | Default | Description |
|------|------|---------|-------------|
| `data` | `array` | `[]` | Array of row objects |
| `columns` | `array` | `[]` | Column definitions (see below) |
| `loading` | `boolean` | `false` | Shows spinner while true |
| `name` | `string` | — | Used as CSV filename (`name_export.csv`) |
| `pageSize` | `number` | `10` | Initial rows per page |
| `pageSizeOptions` | `number[]` | — | Shows rows-per-page selector (e.g. `[10, 25, 50]`) |
| `showHeader` | `boolean` | `true` | Hides filter bar and toolbar when false |
| `onRowSelect` | `(row) => void` | — | Called when a row is clicked |
| `page` | `number` | — | Controlled page number |
| `onPageChange` | `(page) => void` | — | Required when `page` is controlled |
| `features` | `object` | — | Per-instance feature flags (overrides global config) |
| `onExport` | `function` | — | Per-instance CSV export handler |
| `children` | `ReactNode` | — | Rendered in the top-left toolbar slot (e.g. a New button) |

---

## Column Definition

```js
const columns = [
  { header: 'Name',   field: 'partnerName' },
  { header: 'Active', field: 'active',      type: 'boolean' },
  { header: 'Date',   field: 'txnDate',     type: 'date' },
  { header: 'Amount', field: 'totalAmount', type: 'currency' },
];
```

| Key | Type | Description |
|-----|------|-------------|
| `header` | `string` | Column heading text |
| `field` | `string` | Key in the row object |
| `type` | `string` | Built-in formatter: `'boolean'` (checkbox), `'date'` (locale date), `'currency'` (2 dp, comma-separated) |
| `render` | `(row) => value\|JSX` | Computed/custom cell — overrides `type` and `field` |
| `isAction` | `boolean` | Marks as action column — excluded from search, sort, and column visibility |
| `actionTemplate` | `(row) => JSX` | Used with `isAction: true` to render buttons |
| `class` | `string` | CSS class applied to `<th>` and `<td>` (e.g. `'text-nowrap'`, `'text-center'`, `'d-none'`) |

**Declare columns outside the component** (module level) or in `useMemo`. Inline declarations create a new reference every render.

---

## Computed Columns (render)

Use `render` to display values derived from multiple fields, or to render custom JSX.

```js
// Concatenated value
{ header: 'TXN ID', render: (row) => row.docType + '-' + row.docNo }

// Formatted value
{ header: 'Amount', field: 'totalAmount', render: (row) => '$' + Number(row.totalAmount).toFixed(2) }

// JSX / badge
{ header: 'Status', field: 'status', render: (row) => <StatusBadge status={row.status} /> }
```

When `render` is present, `field` is still useful for search/sort/column-visibility targeting.

---

## Action Columns

Use `isAction: true` with `actionTemplate` for edit/delete buttons.

```js
{
  header: '',
  field: 'actions',
  isAction: true,
  actionTemplate: (row) => (
    <div className="d-flex gap-2">
      <button className="btn btn-outline-primary btn-sm btn-borderless" onClick={() => handleEdit(row.id)}>
        <i className="bi bi-pencil" />
      </button>
      <button className="btn btn-outline-danger btn-sm btn-borderless" onClick={() => handleDelete(row.id)}>
        <i className="bi bi-trash" />
      </button>
    </div>
  ),
}
```

Action columns are excluded from search and sort. To push them to the far right, enable `actionColumnsRightEnd` in global config.

---

## Toolbar Slot (children)

Anything passed as `children` renders in the top-left of the header bar.

```jsx
<DataTable data={uiData.data} columns={columns} loading={uiData.loading} name="Partners">
  <button className="btn btn-primary" onClick={() => navigate('/business-partner/add')}>New</button>
</DataTable>
```

---

## Controlled Pagination

By default pagination is internal. Pass `page` and `onPageChange` to control it externally (e.g. for server-side paging).

```jsx
const [page, setPage] = useState(1);

<DataTable
  data={uiData.data}
  columns={columns}
  loading={uiData.loading}
  page={page}
  onPageChange={setPage}
/>
```

---

## Global Config

Call `initDataTableConfig` once in your app entry (e.g. `App.js`) to set defaults for all tables.

```js
import { initDataTableConfig } from './components/DataTable/DataTableConfig';

initDataTableConfig({
  features: {
    columnVisibility: true,   // gear icon to show/hide columns
    csvExport: true,          // download button
    actionColumnsRightEnd: true, // action columns always at far right
  },
  onExport: (data, columns, filename) => {
    // custom CSV export logic
  },
});
```

Override per-instance with the `features` prop:

```jsx
<DataTable features={{ csvExport: false }} ... />
```

---

## Full Example

```jsx
import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { DataTable } from '../../components/DataTable/DataTable';
import ApiService from './service';
import MessageBoxService from '../../services/MessageBoxService';

// Declare outside component
const columns = (onEdit, onDelete) => [
  { header: 'Code',   field: 'partnerCode' },
  { header: 'Name',   field: 'partnerName', class: 'text-nowrap' },
  { header: 'Active', field: 'active',      type: 'boolean', class: 'text-center' },
  {
    header: '',
    field: 'actions',
    isAction: true,
    actionTemplate: (row) => (
      <div className="d-flex gap-2">
        <button className="btn btn-outline-primary btn-sm btn-borderless" onClick={() => onEdit(row.id)}>
          <i className="bi bi-pencil" />
        </button>
        <button className="btn btn-outline-danger btn-sm btn-borderless" onClick={() => onDelete(row.id)}>
          <i className="bi bi-trash" />
        </button>
      </div>
    ),
  },
];

function PartnerIndex() {
  const [uiData, setUiData] = useState({ loading: false, data: [], error: '' });
  const navigate = useNavigate();

  useEffect(() => { fetchAll(); }, []);

  const fetchAll = async () => {
    setUiData(prev => ({ ...prev, loading: true, data: [] }));
    const result = await ApiService.getAll();
    setUiData(prev => ({ ...prev, ...result, loading: false }));
  };

  const handleDelete = async (id) => {
    const ok = await MessageBoxService.confirmAsync({ message: 'Delete this record?', type: 'danger' });
    if (!ok) return;
    const res = await ApiService.delete({ id });
    if (res.success) { MessageBoxService.show({ message: 'Deleted', type: 'success', onClose: fetchAll }); }
  };

  return (
    <DataTable
      data={uiData.data}
      columns={columns((id) => navigate(`/partners/edit/${id}`), handleDelete)}
      loading={uiData.loading}
      name="Partners"
      pageSizeOptions={[10, 25, 50]}
    >
      <button className="btn btn-primary" onClick={() => navigate('/partners/add')}>New</button>
    </DataTable>
  );
}

export default PartnerIndex;
```
