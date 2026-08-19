import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { DataTable } from '../../../components/DataTable/DataTable';
import MeridianPage from '../../Meridian/MeridianPage';
import PermissionGate from '../../../components/PermissionGate';
import MessageBoxService from '../../../services/MessageBoxService';
import ApiService from './service';
import useMenuLabel from '../../../helpers/useMenuLabel';

export default function ParamList() {
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, data: [], error: '' });
  const menuLabel = useMenuLabel('/petty-cash/param', 'Parameters');

  useEffect(() => { fetchAll(); /* eslint-disable-next-line */ }, []);

  const fetchAll = async () => {
    setUiData((prev) => ({ ...prev, loading: true }));
    const { success, data } = await ApiService.getAll();
    setUiData({ loading: false, data: success ? data : [], error: '' });
  };

  const handleDelete = async (id) => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Delete this parameter? This cannot be undone.',
      type: 'danger',
      confirmText: 'Delete',
      cancelText: 'Cancel',
    });
    if (!confirmed) return;
    const { success } = await ApiService.delete({ id });
    if (success) {
      MessageBoxService.show({ message: 'Parameter deleted.', type: 'success', onClose: fetchAll });
    }
  };

  const columns = [
    { header: 'Group', field: 'paramGroup', class: 'text-nowrap', cardRole: 'badge' },
    { header: 'Key', field: 'paramKey', class: 'text-nowrap', cardRole: 'title' },
    { header: 'Num Value', field: 'numValue', type: 'currency', class: 'text-nowrap text-end', cardRole: 'amount' },
    { header: 'Text Value', field: 'textValue', class: 'text-nowrap', cardRole: 'subtitle' },
    {
      header: 'GL Account', field: 'accountCode', class: 'text-nowrap',
      render: (r) => `${r.accountCode || ''} ${r.accountName || ''}`.trim(),
    },
    { header: 'Active', field: 'isActive', type: 'boolean', class: 'text-nowrap' },
    {
      header: '', field: 'actions', isAction: true,
      actionTemplate: (row) => (
        <div className="d-flex gap-1">
          <PermissionGate codes="pc-param-view-detail">
            <button aria-label="Edit" className="btn btn-outline-primary btn-sm btn-borderless"
              onClick={() => navigate(`/petty-cash/param/edit/${row.paramId}`)}>
              <i className="bi bi-pencil" />
            </button>
          </PermissionGate>
          <PermissionGate codes="pc-param-delete">
            <button aria-label="Delete" className="btn btn-outline-danger btn-sm btn-borderless"
              onClick={() => handleDelete(row.paramId)}>
              <i className="bi bi-trash" />
            </button>
          </PermissionGate>
        </div>
      ),
    },
  ];

  return (
    <MeridianPage title={menuLabel}>
      <PermissionGate codes="pc-param-view" mode="message">
      <DataTable
        columns={columns}
        data={uiData.data}
        loading={uiData.loading}
        name={menuLabel}
        //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      >
        <PermissionGate codes="pc-param-new">
          <button className="ml-btn-action ml-fab" onClick={() => navigate('/petty-cash/param/add')}>
            <i className="bi bi-plus-lg" aria-hidden="true" />
            New Parameter
          </button>
        </PermissionGate>
      </DataTable>
      </PermissionGate>
    </MeridianPage>
  );
}
