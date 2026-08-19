## 2024-06-25 - Replace spread map pattern with reduce
**Learning:** Using `Math.max(...data.map(d => d.value))` creates an intermediate array and throws stack overflow on large datasets.
**Action:** Replace `Math.max(...array)` with `array.reduce((acc, d) => Math.max(acc, d.value), initValue)`.
## 2026-07-04 - Debounce expensive parent callbacks in generic UI components
**Learning:** Components like `DataGrid` that trigger callbacks on every keystroke (`onItemsChange`) can cause significant performance degradation when parents perform expensive computations (like summing totals across hundreds of lines) on each update.
**Action:** Debounce generic state changes passed up to parents (using `setTimeout` inside `useEffect`) in frequently updated UI elements like grids or large forms.

## 2024-05-24 - Avoid Spread Operator in Array Aggregations
**Learning:** Using `Math.max(...array.map(d => d.value))` or `Math.max(...array.flatMap(d => ...))` can cause stack overflow errors on large datasets because the spread operator passes all elements as individual arguments to the function, exceeding JavaScript engine call stack limits (usually ~65k items).
**Action:** Always use `array.reduce((acc, d) => Math.max(acc, d.value), initialValue)` instead for finding minimum or maximum values over arrays.
## 2024-07-23 - Extract list item rows to React.memo wrapper in grid forms
**Learning:** For components rendering large lists of editable items (like `DataGrid.js`), relying on `O(N)` renders on every keystroke causes significant performance lag.
**Action:** Extract the row logic into a standalone component (`DataGridRow`), wrap it with `React.memo`, and use stable references (via `useCallback`) for the row's event handlers to reduce keystroke renders from `O(N)` to `O(1)`.
