# DataGrid — Pending Fixes

Limitations of [DataGrid.js](DataGrid.js) to address later. Priority is rough order of pain.

## Done
- [x] `type: 'select'` support with `options: [{value, label}]`.
- [x] `render(item, setField, idx, setRow)` escape hatch with whole-row writer.
- [x] Trash button restyled for Galaxy theme (scoped via `.ml-screen .data-grid-remove-btn`).

## High priority

- [ ] **Amount returns formatted string, not number.** `formatAmount` stores `"1,234.56"` in state. Every caller must `Number(String(v).replace(/,/g, ""))` to use it. Should expose raw value alongside display value, or emit a number.
- [ ] **No per-cell validation.** No `is-invalid` styling, no error tooltips. Validation only at submit. Add `getError(item, col) => string | null` prop.
- [x] **`onItemsChange` fires on every keystroke.** Fine for small grids, expensive when parent recomputes totals across hundreds of rows. Consider debouncing or emitting only on blur.

## Medium priority

- [ ] **No keyboard navigation.** Tab works (browser default). No Enter-to-next-row, no arrow keys, no Esc-to-cancel.
- [ ] **No paste from Excel.** Multi-row clipboard paste hits a single cell.
- [ ] **No conditional row state.** Can't disable a row, can't lock a posted row, can't style by data. Add `getRowProps(item) => { disabled, className }`.
- [ ] **Select options are flat.** No `<optgroup>`, no search, no async load. Long account lists (1000+) become unusable. Need a searchable variant — either custom dropdown or react-select integration.
- [ ] **No empty state.** Always renders at least one row. Can't show "no lines yet" placeholder.

## Low priority

- [ ] **Add button always at bottom.** No insert above/below per row.
- [ ] **No row reorder.** No drag handles. Order is insertion order only.
- [ ] **No virtualization.** Every row sits in the DOM. ~500+ rows starts to lag.
- [ ] **Width is column-only.** No min/max, no responsive collapse on small screens.
- [ ] **No header tooltip / help text** per column.

## Notes

- `DataGrid` is used in: `Journals/AddJournal`, `Invoice/AddInvoice`, `Invoice/AddAdvance`, `DailyReport/AddReport`, `Reports/Invoice`.
- Any API change must stay backward compatible — keep additive (new optional props), don't break existing callers.
- Meridian-specific styles live in [meridian-screens.css](../../features/Meridian/meridian-screens.css) and are scoped under `.ml-screen` so other consumers retain Bootstrap defaults.
