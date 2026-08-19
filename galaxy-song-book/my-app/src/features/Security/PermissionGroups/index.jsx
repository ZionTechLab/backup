import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { DataTable } from '../../../components/DataTable/DataTable';
import MeridianPage from '../../Meridian/MeridianPage';
import PermissionGate, { useHasPermission } from '../../../components/PermissionGate';
import MessageBoxService from '../../../services/MessageBoxService';
import ApiService from './service';

export default function PermissionGroupsList() {
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, data: [] });
  const canNew = useHasPermission('permission-group-new');
  const canSave = useHasPermission('permission-group-save');
  const canDelete = useHasPermission('permission-group-delete');

  useEffect(() => { fetchAll(); /* eslint-disable-next-line */ }, []);

  const fetchAll = async () => {
    setUiData((prev) => ({ ...prev, loading: true }));
    const { success, data } = await ApiService.getAll();
    setUiData({ loading: false, data: success ? data.permissionGroups || [] : [] });
  };

  const handleDelete = async (id) => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Delete this role? Users assigned this role will lose its permissions.',
      type: 'danger', confirmText: 'Delete', cancelText: 'Cancel',
    });
    if (!confirmed) return;
    const { success } = await ApiService.delete(id);
    if (success) MessageBoxService.show({ message: 'Role deleted.', type: 'success', onClose: fetchAll });
  };

  const columns = [
    { header: 'ID', field: 'permGroupId', class: 'text-nowrap', cardRole: 'subtitle' },
    { header: 'Role Name', field: 'permGroupName', cardRole: 'title' },
    {
      header: '', field: 'actions', isAction: true,
      actionTemplate: (row) => (
        <div className="d-flex gap-1">
          {canSave && (
            <button aria-label="Edit" className="btn btn-outline-primary btn-sm btn-borderless"
              onClick={() => navigate(`/settings/permission-groups/edit/${row.permGroupId}`)}>
              <i className="bi bi-pencil" />
            </button>
          )}
          {canDelete && (
            <button aria-label="Delete" className="btn btn-outline-danger btn-sm btn-borderless"
              onClick={() => handleDelete(row.permGroupId)}>
              <i className="bi bi-trash" />
            </button>
          )}
        </div>
      ),
    },
  ];

  return (
    <MeridianPage title="Roles">
      <PermissionGate codes="permission-group-view" mode="message">
        <DataTable
          columns={columns}
          data={uiData.data}
          loading={uiData.loading}
          name="Roles"
          //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
        >
          {canNew && (
            <button className="ml-btn-action ml-fab" onClick={() => navigate('/settings/permission-groups/add')}>
              <i className="bi bi-plus-lg" aria-hidden="true" />
              New Role
            </button>
          )}
        </DataTable>
      </PermissionGate>
    </MeridianPage>
  );
}
