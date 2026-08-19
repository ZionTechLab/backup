// Modal to toggle which (non-action) columns are visible. The last visible
// column cannot be hidden, so the table never goes empty.
export function ColumnVisibilityModal({ columns = [], visibleColumns = [], onToggle, isOpen, onClose }) {
  if (!isOpen) return null;
  const safeColumns = Array.isArray(columns) ? columns : [];
  const safeVisibleColumns = Array.isArray(visibleColumns) ? visibleColumns : [];

  const handleSelectAll = () => {
    safeColumns.filter(c => !c.isAction).forEach(col => {
      if (!safeVisibleColumns.includes(col.field)) onToggle(col.field);
    });
  };
  const handleDeselectAll = () => {
    const fieldsToHide = safeVisibleColumns.slice(0, -1);
    fieldsToHide.forEach(field => {
      if (safeVisibleColumns.includes(field)) onToggle(field);
    });
  };

  return (
    <>
      <div className="modal-backdrop fade show z-colvis-backdrop" onClick={onClose} />
      <div className="modal fade show modal-shown z-colvis" tabIndex="-1">
        <div className="modal-dialog modal-dialog-centered">
          <div className="modal-content">
            <div className="modal-header">
              <h5 className="modal-title">Column Visibility</h5>
              <button type="button" className="btn-close" aria-label="Close" onClick={onClose}></button>
            </div>
            <div className="modal-body">
              <div className="mb-3">
                <button className="btn btn-sm btn-outline-primary me-2" onClick={handleSelectAll}>Select All</button>
                <button className="btn btn-sm btn-outline-secondary" onClick={handleDeselectAll}>Deselect All</button>
              </div>
              <div className="border rounded p-3 scroll-box-300">
                {safeColumns.filter(c => !c.isAction).map(col => (
                  <div key={col.field} className="form-check mb-2">
                    <input className="form-check-input" type="checkbox" id={`col-${col.field}`} checked={safeVisibleColumns.includes(col.field)} onChange={() => onToggle(col.field)} />
                    <label className="form-check-label" htmlFor={`col-${col.field}`}>{col.header}</label>
                  </div>
                ))}
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
