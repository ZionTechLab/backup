import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { DataTable } from '../../../components/DataTable/DataTable';
import MeridianPage from '../../Meridian/MeridianPage';
import PermissionGate, { useHasPermission } from '../../../components/PermissionGate';
import MessageBoxService from '../../../services/MessageBoxService';
import ApiService from './service';

export default function OrgUnitList({ unitType, title }) {
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, data: [], error: '' });
  const canNew = useHasPermission('org-unit-new');
  const canSave = useHasPermission('org-unit-save');
  const canDelete = useHasPermission('org-unit-delete');
  const isBranch = unitType === 'Branch';

  useEffect(() => { fetchAll(); /* eslint-disable-next-line */ }, [unitType]);

  const fetchAll = async () => {
    setUiData((prev) => ({ ...prev, loading: true }));
    const { success, data } = await ApiService.getAll(unitType);
    setUiData({ loading: false, data: success ? data : [], error: '' });
  };

  const handleDelete = async (id) => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Delete this unit? This cannot be undone.',
      type: 'danger',
      confirmText: 'Delete',
      cancelText: 'Cancel',
    });
    if (!confirmed) return;
    const { success } = await ApiService.delete({ id });
    if (success) {
      MessageBoxService.show({ message: 'Unit deleted.', type: 'success', onClose: fetchAll });
    }
  };

  const routeBase = `/masters/${unitType.toLowerCase()}`;

  const columns = [
    { header: 'Code', field: 'code', class: 'text-nowrap', cardRole: 'title' },
    { header: 'Name', field: 'name', class: 'text-nowrap', cardRole: 'subtitle' },
    ...(isBranch
      ? [{ header: 'Company', field: 'companyName', class: 'text-nowrap' }]
      : [{ header: 'Parent', field: 'parentName', class: 'text-nowrap' }]),
    { header: 'Active', field: 'isActive', type: 'boolean', class: 'text-nowrap' },
    {
      header: '', field: 'actions', isAction: true,
      actionTemplate: (row) => (
        <div className="d-flex gap-1">
          {canSave && (
          <button aria-label="Edit" className="btn btn-outline-primary btn-sm btn-borderless"
            onClick={() => navigate(`${routeBase}/edit/${row.orgUnitId}`)}>
            <i className="bi bi-pencil" />
          </button>
          )}
          {canDelete && (
          <button aria-label="Delete" className="btn btn-outline-danger btn-sm btn-borderless"
            onClick={() => handleDelete(row.orgUnitId)}>
            <i className="bi bi-trash" />
          </button>
          )}
        </div>
      ),
    },
  ];

  return (
    <MeridianPage title={title || unitType}>
      <PermissionGate codes="org-unit-view" mode="message">
      <DataTable
        columns={columns}
        data={uiData.data}
        loading={uiData.loading}
        name={title || unitType}
        // //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      >
        {canNew && (
        <button className="ml-btn-action ml-fab" onClick={() => navigate(`${routeBase}/add`)}>
          <i className="bi bi-plus-lg" aria-hidden="true" />
          New {unitType}
        </button>
        )}
      </DataTable>
      </PermissionGate>
    </MeridianPage>
  );
}
