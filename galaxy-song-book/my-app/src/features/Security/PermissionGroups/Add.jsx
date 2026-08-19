import { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import MeridianPage from '../../Meridian/MeridianPage';
import MessageBoxService from '../../../services/MessageBoxService';
import ApiService from './service';

// Builds the module-grouped matrix from the catalog and a set of selected ids.
function buildMatrix(modules, permissions, selectedSet) {
  return modules.map((m) => ({
    moduleId: m.moduleId,
    moduleName: m.moduleName,
    permissions: permissions
      .filter((p) => p.moduleId === m.moduleId)
      .map((p) => ({ permId: p.permId, permName: p.permName, checked: selectedSet.has(p.permId) })),
  }));
}

export default function AddPermissionGroup() {
  const { id } = useParams();
  const navigate = useNavigate();
  const [name, setName] = useState('');
  const [matrix, setMatrix] = useState([]);
  const [loading, setLoading] = useState(true);
  const [saving, setSaving] = useState(false);

  useEffect(() => {
    const init = async () => {
      if (id) {
        const { success, data } = await ApiService.get(id);
        if (success && data) {
          setName(data.group?.permGroupName ?? '');
          const selected = new Set(data.permissions.filter((p) => p.isPermitted === 1).map((p) => p.permId));
          setMatrix(buildMatrix(data.modules, data.permissions, selected));
        }
      } else {
        const { success, data } = await ApiService.getAll();
        if (success && data) setMatrix(buildMatrix(data.modules, data.permissions, new Set()));
      }
      setLoading(false);
    };
    init();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [id]);

  const togglePerm = (moduleId, permId) => {
    setMatrix((prev) => prev.map((mod) => mod.moduleId !== moduleId ? mod : {
      ...mod,
      permissions: mod.permissions.map((p) => p.permId === permId ? { ...p, checked: !p.checked } : p),
    }));
  };

  const toggleModule = (moduleId, value) => {
    setMatrix((prev) => prev.map((mod) => mod.moduleId !== moduleId ? mod : {
      ...mod,
      permissions: mod.permissions.map((p) => ({ ...p, checked: value })),
    }));
  };

  const handleSave = async () => {
    if (!name || name.trim().length < 3) {
      MessageBoxService.show({ message: 'Role name needs at least 3 characters.', type: 'danger' });
      return;
    }
    setSaving(true);
    const permissions = matrix.flatMap((mod) =>
      mod.permissions.map((p) => ({ permId: p.permId, moduleId: mod.moduleId, isPermitted: p.checked ? 1 : 0 }))
    );
    const payload = {
      isUpdateMode: !!id,
      permissionGroups: [{ permGroupId: id ? Number(id) : 0, permGroupName: name.trim() }],
      permissions,
    };
    const { success } = await ApiService.save(payload);
    setSaving(false);
    if (success) {
      MessageBoxService.show({
        message: `Role ${id ? 'updated' : 'created'}.`,
        type: 'success',
        onClose: () => navigate('/settings/permission-groups'),
      });
    }
  };

  const allChecked = (mod) => mod.permissions.length > 0 && mod.permissions.every((p) => p.checked);

  return (
    <MeridianPage
      title={`${id ? 'Edit' : 'New'} Role`}
      backTo="/settings/permission-groups"
      cardClass="ml-form-card"
      actions={
        <button type="button" className="ml-btn-action ml-fab" onClick={handleSave} disabled={loading || saving}>
          <i className="bi bi-check-lg" aria-hidden="true" />
          Save
        </button>
      }
    >
      <div className="ml-form-section">
        <div className="row g-2 mb-3">
          <div className="col-sm-6">
            <label className="form-label">Role Name</label>
            <input className="form-control" value={name} maxLength={150}
              placeholder="Enter role name" onChange={(e) => setName(e.target.value)} />
          </div>
        </div>

        {loading ? (
          <div className="text-muted">Loading permissions…</div>
        ) : (
          matrix.map((mod) => (
            <div key={mod.moduleId} className="card mb-3">
              <div className="card-header d-flex align-items-center justify-content-between">
                <span className="fw-semibold">{mod.moduleName}</span>
                <div className="form-check m-0">
                  <input className="form-check-input" type="checkbox" id={`mod-${mod.moduleId}`}
                    checked={allChecked(mod)} onChange={(e) => toggleModule(mod.moduleId, e.target.checked)} />
                  <label className="form-check-label small" htmlFor={`mod-${mod.moduleId}`}>All</label>
                </div>
              </div>
              <div className="card-body">
                <div className="d-flex flex-wrap gap-3">
                  {mod.permissions.map((p) => (
                    <div key={p.permId} className="form-check">
                      <input className="form-check-input" type="checkbox" id={`perm-${p.permId}`}
                        checked={p.checked} onChange={() => togglePerm(mod.moduleId, p.permId)} />
                      <label className="form-check-label" htmlFor={`perm-${p.permId}`}>{p.permName}</label>
                    </div>
                  ))}
                </div>
              </div>
            </div>
          ))
        )}
      </div>
    </MeridianPage>
  );
}
