import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { DataTable } from '../../../components/DataTable/DataTable';
import MeridianPage from '../../Meridian/MeridianPage';
import PermissionGate, { useHasPermission } from '../../../components/PermissionGate';
import MessageBoxService from '../../../services/MessageBoxService';
import ApiService from '../service';

export default function ApprovalLevelsList() {
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, data: [] });
  const canNew = useHasPermission('wf-config-save');
  const canDelete = useHasPermission('wf-config-delete');

  useEffect(() => { fetchAll(); /* eslint-disable-next-line */ }, []);

  const fetchAll = async () => {
    setUiData((prev) => ({ ...prev, loading: true }));
    const { success, data } = await ApiService.getAll();
    setUiData({ loading: false, data: success ? data : [] });
  };

  const handleDelete = async (id) => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Delete this approval level?', type: 'danger', confirmText: 'Delete', cancelText: 'Cancel',
    });
    if (!confirmed) return;
    const { success } = await ApiService.delete(id);
    if (success) MessageBoxService.show({ message: 'Level deleted.', type: 'success', onClose: fetchAll });
  };

  const columns = [
    { header: 'Transaction', field: 'docType', class: 'text-nowrap', cardRole: 'subtitle' },
    { header: 'Level', field: 'levelNo', class: 'text-nowrap' },
    { header: 'Name', field: 'levelName', cardRole: 'title' },
    { header: 'Approver Permission', field: 'approverFunction', class: 'text-nowrap' },
    { header: 'Min', field: 'minAmount', type: 'currency', class: 'text-nowrap text-end' },
    { header: 'Max', field: 'maxAmount', type: 'currency', class: 'text-nowrap text-end' },
    { header: 'Active', field: 'isActive', type: 'boolean', class: 'text-nowrap' },
    {
      header: '', field: 'actions', isAction: true,
      actionTemplate: (row) => (
        <div className="d-flex gap-1">
          {canNew && (
            <button aria-label="Edit" className="btn btn-outline-primary btn-sm btn-borderless"
              onClick={() => navigate(`/settings/approval-levels/edit/${row.levelId}`)}>
              <i className="bi bi-pencil" />
            </button>
          )}
          {canDelete && (
            <button aria-label="Delete" className="btn btn-outline-danger btn-sm btn-borderless"
              onClick={() => handleDelete(row.levelId)}>
              <i className="bi bi-trash" />
            </button>
          )}
        </div>
      ),
    },
  ];

  return (
    <MeridianPage title="Approval Levels">
      <PermissionGate codes="wf-config-view" mode="message">
        <DataTable columns={columns} data={uiData.data} loading={uiData.loading} name="Approval Levels"
          //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
          >
          {canNew && (
            <button className="ml-btn-action ml-fab" onClick={() => navigate('/settings/approval-levels/add')}>
              <i className="bi bi-plus-lg" aria-hidden="true" />
              New Level
            </button>
          )}
        </DataTable>
      </PermissionGate>
    </MeridianPage>
  );
}
