import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { DataTable } from '../../../components/DataTable/DataTable';
import MeridianPage from '../../Meridian/MeridianPage';
import PermissionGate from '../../../components/PermissionGate';
import MessageBoxService from '../../../services/MessageBoxService';
import ApiService from './service';
import useMenuLabel from '../../../helpers/useMenuLabel';

const DOC_TYPE_LABELS = { PCV: 'PCV', PIOU: 'PIOU' };

export default function ApprovalBandList() {
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, data: [], error: '' });
  const menuLabel = useMenuLabel('/petty-cash/approval-band', 'Approval Bands');

  useEffect(() => { fetchAll(); /* eslint-disable-next-line */ }, []);

  const fetchAll = async () => {
    setUiData((prev) => ({ ...prev, loading: true }));
    const { success, data } = await ApiService.getAll();
    setUiData({ loading: false, data: success ? data : [], error: '' });
  };

  const handleDelete = async (id) => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Delete this approval band? This cannot be undone.',
      type: 'danger',
      confirmText: 'Delete',
      cancelText: 'Cancel',
    });
    if (!confirmed) return;
    const { success } = await ApiService.delete({ id });
    if (success) {
      MessageBoxService.show({ message: 'Approval band deleted.', type: 'success', onClose: fetchAll });
    }
  };

  const columns = [
    {
      header: 'Doc Type', field: 'docType', class: 'text-nowrap', cardRole: 'badge',
      render: (r) => DOC_TYPE_LABELS[r.docType] || r.docType,
    },
    { header: 'Min Amount', field: 'minAmount', type: 'currency', class: 'text-nowrap text-end', cardRole: 'amount' },
    {
      header: 'Max Amount', field: 'maxAmount', type: 'currency', class: 'text-nowrap text-end',
      render: (r) => r.maxAmount != null ? r.maxAmount : 'No limit',
    },
    { header: 'Approver', field: 'approverFunction', class: 'text-nowrap', cardRole: 'title' },
    { header: 'Order', field: 'sortOrder', type: 'number', class: 'text-nowrap text-center', cardRole: 'subtitle' },
    {
      header: '', field: 'actions', isAction: true,
      actionTemplate: (row) => (
        <div className="d-flex gap-1">
          <PermissionGate codes="pc-approval-band-view-detail">
            <button aria-label="Edit" className="btn btn-outline-primary btn-sm btn-borderless"
              onClick={() => navigate(`/petty-cash/approval-band/edit/${row.bandId}`)}>
              <i className="bi bi-pencil" />
            </button>
          </PermissionGate>
          <PermissionGate codes="pc-approval-band-delete">
            <button aria-label="Delete" className="btn btn-outline-danger btn-sm btn-borderless"
              onClick={() => handleDelete(row.bandId)}>
              <i className="bi bi-trash" />
            </button>
          </PermissionGate>
        </div>
      ),
    },
  ];

  return (
    <MeridianPage title={menuLabel}>
      <PermissionGate codes="pc-approval-band-view" mode="message">
      <DataTable
        columns={columns}
        data={uiData.data}
        loading={uiData.loading}
        name={menuLabel}
        // //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      >
        <PermissionGate codes="pc-approval-band-new">
          <button className="ml-btn-action ml-fab" onClick={() => navigate('/petty-cash/approval-band/add')}>
            <i className="bi bi-plus-lg" aria-hidden="true" />
            New Band
          </button>
        </PermissionGate>
      </DataTable>
      </PermissionGate>
    </MeridianPage>
  );
}
