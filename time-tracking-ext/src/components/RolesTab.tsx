import React, { useEffect, useRef, useState } from 'react';
import { useSaveState } from '../hooks/useSaveState';
import * as RoleService from '../services/RoleService';
import { Column, DataTable } from './DataTable';

export function RolesTab() {
  const [roles, setRoles] = useState<RoleService.Role[]>([]);
  const [loading, setLoading] = useState(true);
  const { saving, error, success, setError, withSaveState } = useSaveState();

  const [newRoleId, setNewRoleId] = useState('');
  const [newName, setNewName] = useState('');
  const [newDesc, setNewDesc] = useState('');
  const roleIdRef = useRef<HTMLInputElement>(null);

  useEffect(() => {
    RoleService.getRoles()
      .then(setRoles)
      .catch(e => setError(e?.message ?? 'Failed to load roles.'))
      .finally(() => setLoading(false));
  }, []);

  async function persist(updated: RoleService.Role[]) {
    await withSaveState(async () => {
      await RoleService.saveRoles(updated);
      setRoles(updated);
    });
  }

  function handleAdd() {
    const roleId = newRoleId.trim();
    const name = newName.trim();
    const desc = newDesc.trim();

    if (!roleId || !name) {
      setError('Role ID and Name are required.');
      return;
    }
    if (roles.some(r => r.roleId.toLowerCase() === roleId.toLowerCase())) {
      setError(`Role ID "${roleId}" already exists.`);
      return;
    }

    setNewRoleId('');
    setNewName('');
    setNewDesc('');

    persist([...roles, { roleId, name, desc }]);
    roleIdRef.current?.focus();
  }

  function handleDelete(index: number) {
    persist(roles.filter((_, i) => i !== index));
  }

  const rolesColumns: Column<RoleService.Role>[] = [
    { header: 'Role ID', key: 'roleId' },
    { header: 'Name', key: 'name' },
    { header: 'Description', key: 'desc' },
    {
      header: 'Actions',
      render: (role, i) => (
        <button
          className="action-btn action-btn--danger"
          onClick={() => handleDelete(i)}
          disabled={saving}
          aria-label={`Remove ${role.name}`}
        >
          Remove
        </button>
      ),
    },
  ];

  return (
    <div>
      <p className="settings-desc">
        Define custom roles available for users (e.g. admin, supervisor).
      </p>

      {error && (
        <div className="error-banner" role="alert">
          {error}
          <button className="error-dismiss" onClick={() => setError('')} aria-label="Dismiss">×</button>
        </div>
      )}
      {success && <div className="success-banner" role="status">{success}</div>}

      {loading ? (
        <div className="loading-state">Loading…</div>
      ) : (
        <>
          <DataTable<RoleService.Role>
            columns={rolesColumns}
            data={roles}
            emptyMessage="No roles yet. Add one below."
          />

          <div className="roles-add-row">
            <input
              ref={roleIdRef}
              type="text"
              className="settings-input"
              placeholder="Role ID (e.g. admin)"
              value={newRoleId}
              onChange={e => setNewRoleId(e.target.value)}
              disabled={saving}
            />
            <input
              type="text"
              className="settings-input"
              placeholder="Name (e.g. Administrator)"
              value={newName}
              onChange={e => setNewName(e.target.value)}
              disabled={saving}
            />
            <input
              type="text"
              className="settings-input"
              placeholder="Description"
              value={newDesc}
              onChange={e => setNewDesc(e.target.value)}
              disabled={saving}
            />
            <button
              className="btn btn-primary"
              onClick={handleAdd}
              disabled={saving || !newRoleId.trim() || !newName.trim()}
            >
              {saving ? 'Saving…' : 'Add Role'}
            </button>
          </div>
        </>
      )}
    </div>
  );
}
