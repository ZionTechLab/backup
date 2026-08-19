# Future Architecture Improvements

## 1. `useCrudForm` Hook — highest priority

Every `Add.js` file is structurally identical: fetch on mount, submit, delete, navigate.
Extract into a single hook so each form is just config + JSX.

```js
function useCrudForm({ fields, service, redirectPath, id }) {
  const navigate = useNavigate();
  const formik = useFormikBuilder(fields, handleSubmit);

  useEffect(() => {
    if (!id) return;
    service.get(id).then(r => r.success && formik.setValues(r.data));
  }, [id]);

  async function handleSubmit(values, { resetForm }) {
    const res = await service.update({
      header: { ...values, id: parseInt(id ?? 0) },
      isUpdate: !!id,
    });
    if (res.success) {
      MessageBoxService.show({ message: 'Saved!', type: 'success',
        onClose: () => navigate(redirectPath) });
      resetForm();
    }
  }

  return formik;
}
```

Affected files: every `src/features/*/Add.js` or `Add.jsx`.

---

## 2. Auto-derive `name` from Object Key

Every field declares `name` twice — as the object key and inside the field config.
They will eventually diverge, causing silent Formik binding bugs.

Fix in `formikBuilder.js` inside the render map:

```js
const field = { ...fields[key], name: fields[key].name ?? key };
```

After this, remove explicit `name:` from every field definition across all `Add.js` files.

---

## 3. Strip Layout/Structural Entries from Formik

`br` and `heading` type entries currently get `initialValues` entries and Yup schema entries.
They are layout hints, not data — they should never reach Formik.

Fix in `useFormikBuilder`:

```js
const LAYOUT_TYPES = new Set(['br', 'heading']);

const dataFields = Object.fromEntries(
  Object.entries(fields).filter(([, f]) => !LAYOUT_TYPES.has(f.type))
);

// use dataFields for initialValues and validationSchema
// use fields for rendering
```

---

## 4. Split Field Config — Data vs Layout

Currently `className: 'col-sm-6 col-6'` (Bootstrap layout) lives inside the field schema
alongside `validation` and `type`. Changing grid columns means touching the data model.

Proposed split:

```js
const fields = {
  uomName: {
    type: 'text',
    placeholder: 'UOM Name',
    validation: Yup.string().required('UOM name is required'),
  },
};

const layout = {
  uomName: { className: 'col-12' },
};
```

`FieldsRenderer` merges them at render time. `fields` stays pure data/validation config.

---

## 5. Make `SwitchGroup` a Controlled Component

`SwitchGroup` currently owns internal `items` state alongside Formik, creating two sources
of truth. The initialization race (data loads vs values loads) required a workaround.

Replace with a pure controlled component:

```js
function SwitchGroup({ data, value = [], onChange }) {
  return data.map(item => (
    <input
      key={item.id}
      type="checkbox"
      checked={value.includes(item.id)}
      onChange={e => {
        const next = e.target.checked
          ? [...value, item.id]
          : value.filter(id => id !== item.id);
        onChange(next);
      }}
    />
  ));
}
```

Formik owns all state. No internal `useState`, no `useEffect`, no sync logic.

---

## 6. Propagate `isSubmitting` Automatically

Save buttons across all forms need `disabled={formik.isSubmitting}` to prevent double
submits. Currently missing on most forms.

Pass `isSubmitting` as a prop to `FieldsRenderer` and apply it automatically to submit
buttons, or pass it down via a React context so individual forms don't need to remember it.

---

## 7. `fields` Objects — Move Outside Components

In every `Add.js`, `fields` is declared inside the component function body. This creates
a new object reference on every render, defeating `React.memo` on `FieldsRenderer`.

If `fields` has no runtime dependencies (most don't), move it to module level:

```js
// module level — created once
const fields = { ... };

function AddUom() {
  const formik = useFormikBuilder(fields, handleSubmit);
  ...
}
```

If `fields` needs runtime data (e.g. `dataBinding` populated from API), wrap with `useMemo`.

---

## 8. `BusinessPartnerFind` — Update to Loading Prop Pattern

`BusinessPartnerFind.js` still uses the old conditional render pattern:

```jsx
{!uiData.loading && !uiData.error && <DataTable ...>}
```

Should be updated to match all other index files:

```jsx
{!uiData.error && <DataTable loading={uiData.loading} ...>}
```
