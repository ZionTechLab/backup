import React, { useEffect, useState, useMemo } from 'react';
import { useSaveState } from '../hooks/useSaveState';
import * as RoleService from '../services/RoleService';
import { Column, DataTable } from './DataTable';

export function UserRolesTab() {
  const [roles, setRoles] = useState<RoleService.Role[]>([]);
  const [users, setUsers] = useState<RoleService.ADOUser[]>([]);
  const [userRoles, setUserRoles] = useState<RoleService.UserRoles>({});
  const [searchQuery, setSearchQuery] = useState('');

  const [loading, setLoading] = useState(true);
  const { saving, error, success, setError, withSaveState } = useSaveState();

  useEffect(() => {
    Promise.all([
      RoleService.getRoles(),
      RoleService.fetchAllUsers(),
      RoleService.getUserRoles()
    ])
    .then(([fetchedRoles, fetchedUsers, fetchedUserRoles]) => {
      setRoles(fetchedRoles);
      setUsers(fetchedUsers);
      setUserRoles(fetchedUserRoles);
    })
    .catch(e => setError(e?.message ?? 'Failed to load user roles data.'))
    .finally(() => setLoading(false));
  }, []);

  const filteredUsers = useMemo(() => {
    if (!searchQuery.trim()) return users;
    const query = searchQuery.toLowerCase();
    return users.filter(u =>
      u.displayName.toLowerCase().includes(query) ||
      u.principalName.toLowerCase().includes(query)
    );
  }, [users, searchQuery]);

  const columns: Column<RoleService.ADOUser>[] = useMemo(() => [
    {
      header: 'User',
      render: (user) => (
        <div className="user-info">
          <div className="user-display-name">{user.displayName}</div>
          <div className="user-principal-name">{user.principalName}</div>
        </div>
      ),
    },
    ...roles.map(role => ({
      header: role.name,
      className: 'role-checkbox-cell',
      render: (user: RoleService.ADOUser) => {
        const hasRole = (userRoles[user.principalName] || []).includes(role.roleId);
        return (
          <input
            type="checkbox"
            checked={hasRole}
            disabled={saving}
            onChange={e => handleToggleRole(user.principalName, role.roleId, e.target.checked)}
            aria-label={`Assign ${role.name} to ${user.displayName}`}
          />
        );
      },
    })),
  ], [roles, userRoles, saving]);

  async function handleToggleRole(userId: string, roleId: string, checked: boolean) {
    const currentRoles = userRoles[userId] || [];
    let newRoles: string[];

    if (checked) {
      if (currentRoles.includes(roleId)) return;
      newRoles = [...currentRoles, roleId];
    } else {
      newRoles = currentRoles.filter(id => id !== roleId);
    }

    const updatedUserRoles = {
      ...userRoles,
      [userId]: newRoles
    };

    // Set locally immediately for responsive UI
    setUserRoles(updatedUserRoles);

    await withSaveState(async () => {
      await RoleService.saveUserRoles(updatedUserRoles);
    });
  }

  if (loading) {
    return <div className="loading-state">Loading users and roles…</div>;
  }

  if (roles.length === 0) {
    return (
      <div>
        <p className="settings-desc">Assign roles to users.</p>
        <div className="task-type-empty">
          No roles defined yet. Please add roles in the Roles tab first.
        </div>
      </div>
    );
  }

  return (
    <div>
      <p className="settings-desc">
        Assign roles to users. These mappings can be used to control access or visibility.
      </p>

      {error && (
        <div className="error-banner" role="alert">
          {error}
          <button className="error-dismiss" onClick={() => setError('')} aria-label="Dismiss">×</button>
        </div>
      )}
      {success && <div className="success-banner" role="status">{success}</div>}

      <div className="search-container">
        <input
          type="text"
          className="settings-input search-input"
          placeholder="Search users..."
          value={searchQuery}
          onChange={e => setSearchQuery(e.target.value)}
          aria-label="Search users"
        />
      </div>

      <DataTable<RoleService.ADOUser>
        columns={columns}
        data={filteredUsers.slice(0, 100)}
        emptyMessage="No users found."
        className="user-roles-table"
      />

      {filteredUsers.length > 100 && (
        <p className="text-center text-muted">
          Showing first 100 users. Use search to find specific users.
        </p>
      )}
    </div>
  );
}
