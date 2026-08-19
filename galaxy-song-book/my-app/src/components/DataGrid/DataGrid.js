import { useState, useEffect, useRef, useMemo, forwardRef, useImperativeHandle, memo, useCallback } from "react";
import { createPortal } from "react-dom";
import MessageBoxService from "../../services/MessageBoxService";
import { formatAmountInput } from "../../helpers/formatAmount";

function SearchableSelect({ value, options, placeholder, onChange }) {
  const [open, setOpen] = useState(false);
  const [query, setQuery] = useState("");
  const [menuPos, setMenuPos] = useState(null);
  const wrapRef = useRef(null);
  const toggleRef = useRef(null);
  const menuRef = useRef(null);

  const selected = useMemo(
    () => (options || []).find((o) => String(o.value) === String(value)),
    [options, value]
  );

  const updatePosition = () => {
    if (!toggleRef.current) return;
    const r = toggleRef.current.getBoundingClientRect();
    const width = Math.max(r.width, 240);
    const spaceBelow = window.innerHeight - r.bottom;
    const openUp = spaceBelow < 260 && r.top > spaceBelow;
    setMenuPos({
      left: r.left,
      top: openUp ? undefined : r.bottom + 2,
      bottom: openUp ? window.innerHeight - r.top + 2 : undefined,
      width,
    });
  };

  useEffect(() => {
    if (!open) return;
    updatePosition();
    const onScroll = () => updatePosition();
    window.addEventListener("scroll", onScroll, true);
    window.addEventListener("resize", onScroll);
    return () => {
      window.removeEventListener("scroll", onScroll, true);
      window.removeEventListener("resize", onScroll);
    };
  }, [open]);

  useEffect(() => {
    const onDocClick = (e) => {
      if (
        wrapRef.current && !wrapRef.current.contains(e.target) &&
        menuRef.current && !menuRef.current.contains(e.target)
      ) {
        setOpen(false);
        setQuery("");
      }
    };
    document.addEventListener("mousedown", onDocClick);
    return () => document.removeEventListener("mousedown", onDocClick);
  }, []);

  const filtered = useMemo(() => {
    const q = query.trim().toLowerCase();
    if (!q) return options || [];
    return (options || []).filter((o) => String(o.label).toLowerCase().includes(q));
  }, [options, query]);

  const pick = (opt) => {
    onChange(opt.value);
    setOpen(false);
    setQuery("");
  };

  return (
    <div className="dg-ss" ref={wrapRef}>
      <button
        ref={toggleRef}
        type="button"
        className="form-select dg-ss-toggle text-start"
        onClick={() => setOpen((v) => !v)}
      >
        {selected ? selected.label : <span className="text-muted">{placeholder || "Select..."}</span>}
      </button>
      {open && menuPos && createPortal(
        <div
          ref={menuRef}
          className="dg-ss-menu"
          style={{
            position: "fixed",
            left: menuPos.left,
            top: menuPos.top ?? "auto",
            bottom: menuPos.bottom ?? "auto",
            width: menuPos.width,
          }}
        >
          <input
            autoFocus
            type="text"
            className="form-control form-control-sm dg-ss-search"
            placeholder="Search..."
            value={query}
            onChange={(e) => setQuery(e.target.value)}
          />
          <div className="dg-ss-list">
            {filtered.length === 0 && (
              <div className="dg-ss-empty">No matches</div>
            )}
            {filtered.map((opt) => (
              <div
                key={opt.value}
                className={"dg-ss-item" + (selected && String(selected.value) === String(opt.value) ? " active" : "")}
                onClick={() => pick(opt)}
              >
                {opt.label}
              </div>
            ))}
          </div>
        </div>,
        document.body
      )}
    </div>
  );
}

const DataGridRow = memo(({ item, idx, columns, isLastRow, handleChange, handleRemove }) => {
  return (
    <tr>
      <td className="text-center">{idx + 1}</td>
      {columns.map((col, cidx) => {
        const setField = (val) => handleChange(idx, { ...item, [col.field]: val });
        const setRow   = (newItem) => handleChange(idx, newItem);
        return (
          <td key={col.field || cidx}>
            {col.render ? (
              col.render(item, setField, idx, setRow)
            ) : col.type === "select" ? (
              col.searchable ? (
                <SearchableSelect
                  value={item[col.field] ?? ""}
                  options={col.options || []}
                  placeholder={col.placeholder}
                  onChange={(val) => setField(val)}
                />
              ) : (
                <select
                  className="form-select"
                  value={item[col.field] ?? ""}
                  onChange={e => setField(e.target.value)}
                >
                  <option value="">{col.placeholder || "Select..."}</option>
                  {(col.options || []).map((opt) => (
                    <option key={opt.value} value={opt.value}>{opt.label}</option>
                  ))}
                </select>
              )
            ) : col.type === "amount" ? (
              <input
                type="text"
                inputMode="decimal"
                className="form-control text-end"
                value={formatAmountInput(item[col.field])}
                onChange={e => setField(e.target.value)}
                placeholder={col.placeholder || col.header}
                maxLength={15}
              />
            ) : (
              <input
                type={col.type || "text"}
                className="form-control"
                value={item[col.field] ?? ""}
                onChange={e => setField(e.target.value)}
                placeholder={col.placeholder || col.header}
              />
            )}
          </td>
        );
      })}
      <td>
        <button
          type="button"
          className="btn btn-danger btn-sm data-grid-remove-btn"
          onClick={() => handleRemove(idx)}
          disabled={isLastRow}
          aria-label="Remove row"
          title={isLastRow ? "Cannot remove last row" : "Remove row"}
        >
          <i className="bi bi-trash" aria-hidden="true"></i>
        </button>
      </td>
    </tr>
  );
});

DataGridRow.displayName = 'DataGridRow';

const DataGrid = forwardRef(({ columns, initialItems, onItemsChange }, ref) => {
  const emptyLineItem = columns.reduce((acc, col) => ({ ...acc, [col.field]: "" }), {});
  const [items, setItems] = useState(initialItems && initialItems.length ? initialItems : [{ ...emptyLineItem }]);
  const itemsRef = useRef(items);

  useEffect(() => {
    itemsRef.current = items;
  }, [items]);

  useImperativeHandle(ref, () => ({
    reset: (items) => {
      setItems(items ? items : [{ ...emptyLineItem }]);
    }
  }));

  useEffect(() => {
    if (typeof onItemsChange === "function") {
      const timer = setTimeout(() => {
        onItemsChange(items);
      }, 500);
      return () => clearTimeout(timer);
    }
    // eslint-disable-next-line
  }, [items]);

  const handleChange = useCallback((idx, newItem) => {
    setItems((prevItems) => {
      const updated = [...prevItems];
      updated[idx] = newItem;
      return updated;
    });
  }, []);

  const handleAdd = () => {
    setItems([...items, { ...emptyLineItem }]);
  };
  const isRowEmpty = (row) =>
    Object.values(row || {}).every((v) => v === "" || v === null || v === undefined);

  const handleRemove = useCallback(async (idx) => {
    const currentItems = itemsRef.current;
    if (currentItems.length <= 1) return;

    if (!isRowEmpty(currentItems[idx])) {
      const ok = await MessageBoxService.confirmAsync({
        message: "Delete this row?",
        type: "danger",
        confirmText: "Delete",
        cancelText: "Cancel",
      });
      if (!ok) return;
    }

    setItems((prevItems) => prevItems.filter((_, i) => i !== idx));
  }, []);

  return (
    <div className="mb-3">
      <div className="table-responsive">
        <table className="table table-bordered table-editable align-middle mb-0" id="table-editable">
          <thead>
            <tr>
              <th className="col-w-40">#</th>
              {columns.map((col, i) => (
                <th key={col.field || i} style={col.width ? { width: col.width } : {}} className={col.type === "amount" ? "text-end" : ""}>
                  {col.header}
                </th>
              ))}
              <th className="col-w-40"></th>
            </tr>
          </thead>
          <tbody>
            {items.map((item, idx) => (
              <DataGridRow
                key={idx}
                item={item}
                idx={idx}
                columns={columns}
                isLastRow={items.length === 1}
                handleChange={handleChange}
                handleRemove={handleRemove}
              />
            ))}
          </tbody>
        </table>
      </div>
      <button
        type="button"
        className="btn btn-outline-primary btn-sm mt-2"
        onClick={handleAdd}
        aria-label="Add new row"
        title="Add new row"
      >
        <i className="bi bi-plus" aria-hidden="true"></i>
      </button>
    </div>
  );
});

DataGrid.displayName = 'DataGrid';

export { DataGrid };