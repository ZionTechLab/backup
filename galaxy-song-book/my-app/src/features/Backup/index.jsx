import { useEffect, useState } from 'react';
import MeridianPage from '../Meridian/MeridianPage';
import PermissionGate, { useHasPermission } from '../../components/PermissionGate';
import MessageBoxService from '../../services/MessageBoxService';
import useMenuLabel from '../../helpers/useMenuLabel';
import ApiService from './service';

const SCOPES = [
  { value: 'tenant', label: 'This Tenant', description: 'Every registered table, filtered to your tenant and company.' },
  { value: 'module', label: 'Selected Module(s)', description: 'Only the tables belonging to the modules you pick below.' },
  { value: 'full', label: 'Full Database', description: 'Every table, every tenant, unfiltered.' },
];

function ScopePicker({ scope, setScope, canFull, fullNote }) {
  const visible = SCOPES.filter((s) => s.value !== 'full' || canFull);
  return (
    <div className="ml-form-section">
      <h6 className="mb-3">Scope</h6>
      <div className="d-flex flex-column gap-2">
        {visible.map((s) => (
          <label key={s.value} className="d-flex align-items-start gap-2" style={{ cursor: 'pointer' }}>
            <input
              type="radio" name="backupScope" value={s.value}
              checked={scope === s.value}
              onChange={() => setScope(s.value)}
              className="form-check-input mt-1"
            />
            <span>
              <strong>{s.label}</strong>
              <div className="text-muted small">{s.description}{s.value === 'full' ? ` ${fullNote}` : ''}</div>
            </span>
          </label>
        ))}
      </div>
    </div>
  );
}

function ModulePicker({ modules, loading, selected, toggle }) {
  return (
    <div className="ml-form-section mt-3">
      <h6 className="mb-3">Modules</h6>
      {loading ? (
        <div className="text-muted small">Loading modules...</div>
      ) : modules.length === 0 ? (
        <div className="text-muted small">No exportable modules registered.</div>
      ) : (
        <div className="d-flex flex-column gap-2">
          {modules.map((m) => (
            <label key={m.moduleCode} className="d-flex align-items-center gap-2" style={{ cursor: 'pointer' }}>
              <input
                type="checkbox" className="form-check-input"
                checked={selected.includes(m.moduleCode)}
                onChange={() => toggle(m.moduleCode)}
              />
              <span>{m.moduleName} <span className="text-muted small">({m.tableCount} tables)</span></span>
            </label>
          ))}
        </div>
      )}
    </div>
  );
}

function useModules() {
  const [modules, setModules] = useState([]);
  const [loading, setLoading] = useState(true);
  useEffect(() => {
    const init = async () => {
      const { success, data } = await ApiService.getModules();
      setModules(success ? data || [] : []);
      setLoading(false);
    };
    init();
  }, []);
  return { modules, loading };
}

function ExportPanel() {
  const canExportFull = useHasPermission('backup-export-full');
  const { modules, loading } = useModules();
  const [scope, setScope] = useState('tenant');
  const [selectedModules, setSelectedModules] = useState([]);
  const [exporting, setExporting] = useState(false);

  const toggleModule = (code) => {
    setSelectedModules((prev) => (prev.includes(code) ? prev.filter((c) => c !== code) : [...prev, code]));
  };

  const handleExport = async () => {
    if (scope === 'module' && selectedModules.length === 0) {
      MessageBoxService.show({ message: 'Select at least one module.', type: 'warning' });
      return;
    }
    if (scope === 'full') {
      const confirmed = await MessageBoxService.confirmAsync({
        message: 'Export the whole database, across every tenant? This includes data that is not yours.',
        type: 'danger', confirmText: 'Export Everything', cancelText: 'Cancel',
      });
      if (!confirmed) return;
    }

    setExporting(true);
    const { success, data, error } = await ApiService.exportBackup(scope, scope === 'module' ? selectedModules : []);
    setExporting(false);

    if (!success) {
      MessageBoxService.show({ message: error || 'Export failed.', type: 'danger' });
      return;
    }

    const blob = data instanceof Blob ? data : new Blob([data], { type: 'application/zip' });
    const url = URL.createObjectURL(blob);
    const link = document.createElement('a');
    link.href = url;
    link.download = `backup-${scope}-${new Date().toISOString().slice(0, 10)}.zip`;
    link.style.display = 'none';
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
    URL.revokeObjectURL(url);

    MessageBoxService.show({ message: 'Export downloaded.', type: 'success' });
  };

  return (
    <>
      <ScopePicker scope={scope} setScope={setScope} canFull={canExportFull} fullNote="Requires the Full Database export permission." />
      {scope === 'module' && (
        <ModulePicker modules={modules} loading={loading} selected={selectedModules} toggle={toggleModule} />
      )}
      <div className="ml-form-section mt-3">
        <button type="button" className="btn btn-primary" disabled={exporting} onClick={handleExport}>
          <i className="bi bi-cloud-download me-1" aria-hidden="true" />
          {exporting ? 'Exporting...' : 'Export'}
        </button>
      </div>
    </>
  );
}

function RestorePanel() {
  const canRestoreFull = useHasPermission('backup-restore-full');
  const { modules, loading } = useModules();
  const [scope, setScope] = useState('tenant');
  const [selectedModules, setSelectedModules] = useState([]);
  const [file, setFile] = useState(null);
  const [previewing, setPreviewing] = useState(false);
  const [applying, setApplying] = useState(false);
  const [preview, setPreview] = useState(null); // { token, manifest, tables, warnings }

  const toggleModule = (code) => {
    setSelectedModules((prev) => (prev.includes(code) ? prev.filter((c) => c !== code) : [...prev, code]));
    setPreview(null);
  };

  const resetPreview = () => setPreview(null);

  const handleFileChange = (e) => {
    setFile(e.target.files?.[0] || null);
    resetPreview();
  };

  const handlePreview = async () => {
    if (!file) {
      MessageBoxService.show({ message: 'Choose a backup .zip file first.', type: 'warning' });
      return;
    }
    if (scope === 'module' && selectedModules.length === 0) {
      MessageBoxService.show({ message: 'Select at least one module.', type: 'warning' });
      return;
    }

    setPreviewing(true);
    const { success, data, error } = await ApiService.previewRestore(file, scope, scope === 'module' ? selectedModules : []);
    setPreviewing(false);

    if (!success) {
      MessageBoxService.show({ message: error || 'Could not read this backup.', type: 'danger' });
      return;
    }
    setPreview(data);
  };

  const handleConfirm = async () => {
    if (!preview) return;
    const confirmed = await MessageBoxService.confirmAsync({
      message: `This wipes ${preview.tables.length} table(s) in the selected scope and reinserts the backup's data. A safety snapshot of the current data is taken first, but this action changes live data immediately. Continue?`,
      type: 'danger', confirmText: 'Restore', cancelText: 'Cancel',
    });
    if (!confirmed) return;

    setApplying(true);
    const { success, error } = await ApiService.applyRestore(preview.token, scope, scope === 'module' ? selectedModules : []);
    setApplying(false);

    if (!success) {
      MessageBoxService.show({ message: error || 'Restore failed.', type: 'danger' });
      return;
    }
    setPreview(null);
    setFile(null);
    MessageBoxService.show({ message: 'Restore complete.', type: 'success' });
  };

  return (
    <>
      <div className="ml-form-section">
        <h6 className="mb-3">Backup File</h6>
        <input type="file" accept=".zip" className="form-control" onChange={handleFileChange} />
      </div>

      <ScopePicker
        scope={scope}
        setScope={(v) => { setScope(v); resetPreview(); }}
        canFull={canRestoreFull}
        fullNote="Requires the Full Database restore permission. Wipes and replaces every tenant's data."
      />

      {scope === 'module' && (
        <ModulePicker modules={modules} loading={loading} selected={selectedModules} toggle={toggleModule} />
      )}

      <div className="ml-form-section mt-3">
        <button type="button" className="btn btn-outline-primary" disabled={!file || previewing} onClick={handlePreview}>
          <i className="bi bi-eye me-1" aria-hidden="true" />
          {previewing ? 'Reading...' : 'Preview'}
        </button>
      </div>

      {preview && (
        <div className="ml-form-section mt-3">
          <h6 className="mb-2">Preview — backup exported {preview.manifest?.exportedAt ? new Date(preview.manifest.exportedAt).toLocaleString() : '-'}</h6>

          {preview.warnings.length > 0 && (
            <div className="alert alert-warning small mb-3">
              {preview.warnings.map((w, i) => <div key={i}>{w}</div>)}
            </div>
          )}

          {preview.tables.length === 0 ? (
            <div className="text-muted small mb-3">Nothing in this backup matches the selected scope.</div>
          ) : (
            <div className="table-responsive mb-3">
              <table className="table table-sm mb-0">
                <thead className="table-light">
                  <tr>
                    <th>Table</th>
                    <th className="text-end">Currently in DB</th>
                    <th className="text-end">In Backup</th>
                  </tr>
                </thead>
                <tbody>
                  {preview.tables.map((t) => (
                    <tr key={t.name}>
                      <td>{t.name}</td>
                      <td className="text-end">{t.currentCount}</td>
                      <td className="text-end">{t.zipCount}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          )}

          {preview.tables.length > 0 && (
            <button type="button" className="btn btn-danger" disabled={applying} onClick={handleConfirm}>
              <i className="bi bi-arrow-counterclockwise me-1" aria-hidden="true" />
              {applying ? 'Restoring...' : 'Confirm Restore'}
            </button>
          )}
        </div>
      )}
    </>
  );
}

export default function BackupExport() {
  const menuLabel = useMenuLabel('/settings/backup-export', 'Backup Export');
  const canRestore = useHasPermission(['backup-restore', 'backup-restore-full']);
  const [tab, setTab] = useState('export');

  return (
    <MeridianPage title={menuLabel}>
      <PermissionGate codes={['backup-export', 'backup-export-full']} mode="message">
        {canRestore && (
          <div className="ml-coa-tabs mb-3">
            <button className={`ml-coa-tab${tab === 'export' ? ' ml-coa-tab-active' : ''}`} onClick={() => setTab('export')}>
              Export
            </button>
            <button className={`ml-coa-tab${tab === 'restore' ? ' ml-coa-tab-active' : ''}`} onClick={() => setTab('restore')}>
              Restore
            </button>
          </div>
        )}

        {tab === 'export' || !canRestore ? <ExportPanel /> : <RestorePanel />}
      </PermissionGate>
    </MeridianPage>
  );
}
