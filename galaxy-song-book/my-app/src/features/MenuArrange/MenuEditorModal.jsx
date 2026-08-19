import ICONS from './iconList';

export default function MenuEditorModal({ editor, setEditor, parentOptions, onSave }) {
  if (!editor) return null;

  return (
    <>
      <div className="modal-backdrop fade show z-popup-backdrop" onClick={() => setEditor(null)} />
      <div className="modal fade show modal-shown z-popup" tabIndex="-1">
        <div className="modal-dialog modal-dialog-centered ml-menu-modal-dialog">
          <div className="modal-content">

            {/* ---- Header ---- */}
            <div className="modal-header">
              <div className="d-flex align-items-center gap-3">
                <span className="ml-menu-modal-icon-preview">
                  <i className={editor.icon || 'bi bi-dot'} />
                </span>
                <div>
                  <h5 className="modal-title mb-0">{editor.id ? 'Edit Item' : 'New Menu Item'}</h5>
                  <small className="text-muted">
                    {editor.id ? 'Update the menu item details below.' : 'Add a new entry to the navigation menu.'}
                  </small>
                </div>
              </div>
              <button type="button" className="btn-close" aria-label="Close" onClick={() => setEditor(null)} />
            </div>

            {/* ---- Body ---- */}
            <div className="modal-body">

              {/* --- Basic --- */}
              <fieldset className="ml-menu-fieldset">
                <legend className="ml-menu-legend">Basic</legend>
                <div className="row g-3">
                  <div className="col-sm-7">
                    <label className="form-label">Display Name</label>
                    <input className="form-control" value={editor.displayName} onChange={(e) => setEditor({ ...editor, displayName: e.target.value })} placeholder="e.g. Dashboard" />
                  </div>
                  <div className="col-sm-5">
                    <label className="form-label">Route</label>
                    <input className="form-control font-monospace" value={editor.route} onChange={(e) => setEditor({ ...editor, route: e.target.value })} placeholder="/path or #" />
                  </div>
                </div>
              </fieldset>

              {/* --- Icon --- */}
              <fieldset className="ml-menu-fieldset">
                <legend className="ml-menu-legend">Icon</legend>
                <div className="ml-icon-grid">
                  {ICONS.map((ic) => (
                    <button
                      key={ic}
                      type="button"
                      className={`ml-icon-btn${editor.icon === ic ? ' selected' : ''}`}
                      title={ic.replace('bi bi-', '')}
                      aria-label={ic.replace('bi bi-', '')}
                      onClick={() => setEditor({ ...editor, icon: ic })}
                    >
                      <i className={ic} />
                    </button>
                  ))}
                </div>
              </fieldset>

              {/* --- Placement --- */}
              <fieldset className="ml-menu-fieldset">
                <legend className="ml-menu-legend">Placement</legend>
                <div className="row g-3">
                  <div className="col-sm-6">
                    <label className="form-label">Parent Menu</label>
                    <select className="form-select" value={editor.parentId} onChange={(e) => setEditor({ ...editor, parentId: Number(e.target.value) })}>
                      {parentOptions.filter((o) => o.id !== editor.id).map((o) => <option key={o.id} value={o.id}>{o.label}</option>)}
                    </select>
                  </div>
                  <div className="col-sm-6">
                    <label className="form-label">&nbsp;</label>
                    <div className="d-flex gap-4 h-100 align-items-end pb-1">
                      <label className="form-check form-switch">
                        <input type="checkbox" className="form-check-input" checked={editor.isGroup} onChange={(e) => setEditor({ ...editor, isGroup: e.target.checked })} />
                        <span className="form-check-label">Group <small className="text-muted d-block">Holds children, no route</small></span>
                      </label>
                      <label className="form-check form-switch">
                        <input type="checkbox" className="form-check-input" checked={editor.isActive} onChange={(e) => setEditor({ ...editor, isActive: e.target.checked })} />
                        <span className="form-check-label">Active</span>
                      </label>
                    </div>
                  </div>
                </div>
              </fieldset>

            </div>

            {/* ---- Footer ---- */}
            <div className="modal-footer">
              <button type="button" className="btn btn-outline-secondary" onClick={() => setEditor(null)}>Cancel</button>
              <button type="button" className="btn btn-primary" onClick={onSave}>
                <i className="bi bi-check-lg me-1" />{editor.id ? 'Save Changes' : 'Create Item'}
              </button>
            </div>

          </div>
        </div>
      </div>
    </>
  );
}
