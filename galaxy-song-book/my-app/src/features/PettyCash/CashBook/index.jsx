import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { DataTable } from '../../../components/DataTable/DataTable';
import MeridianPage from '../../Meridian/MeridianPage';
import PermissionGate from '../../../components/PermissionGate';
import MessageBoxService from '../../../services/MessageBoxService';
import ApiService from './service';
import STATUS_CLASS from '../../../helpers/statusBadge';
import useMenuLabel from '../../../helpers/useMenuLabel';

function StatusBadge({ status }) {
  return <span className={`ml-badge ${STATUS_CLASS[status] || 'ml-badge-locked'}`}>{status}</span>;
}

export default function CashBookList() {
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, data: [], error: '' });
  const menuLabel = useMenuLabel('/petty-cash/cash-book', 'Cash Books');

  useEffect(() => { fetchAll(); /* eslint-disable-next-line */ }, []);

  const fetchAll = async () => {
    setUiData((prev) => ({ ...prev, loading: true }));
    const { success, data } = await ApiService.getAll();
    setUiData({ loading: false, data: success ? data : [], error: '' });
  };

  const handleDelete = async (id) => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Delete this cash book? This cannot be undone.',
      type: 'danger',
      confirmText: 'Delete',
      cancelText: 'Cancel',
    });
    if (!confirmed) return;
    const { success } = await ApiService.delete({ id });
    if (success) {
      MessageBoxService.show({ message: 'Cash book deleted.', type: 'success', onClose: fetchAll });
    }
  };

  const columns = [
    { header: 'Code', field: 'code', class: 'text-nowrap', cardRole: 'title' },
    { header: 'Name', field: 'name', class: 'text-nowrap', cardRole: 'subtitle' },
    { header: 'Branch', field: 'branchName', class: 'text-nowrap' },
    { header: 'Cashier', field: 'cashierName', class: 'text-nowrap' },
    { header: 'Currency', field: 'currencyCode', class: 'text-nowrap', cardRole: 'badge' },
    { header: 'GL Account', field: 'accountCode', class: 'text-nowrap', render: (r) => `${r.accountCode || ''} ${r.accountName || ''}`.trim() },
    { header: 'Max Float', field: 'maxFloat', type: 'currency', class: 'text-nowrap text-end', cardRole: 'amount' },
    { header: 'Status', field: 'status', class: 'text-nowrap', cardRole: 'badge', render: (r) => <StatusBadge status={r.status} /> },
    {
      header: '', field: 'actions', isAction: true,
      actionTemplate: (row) => (
        <div className="d-flex gap-1">
          <PermissionGate codes="pc-cash-book-view-detail">
            <button aria-label="Edit" className="btn btn-outline-primary btn-sm btn-borderless"
              onClick={() => navigate(`/petty-cash/cash-book/edit/${row.cashBookId}`)}>
              <i className="bi bi-pencil" />
            </button>
          </PermissionGate>
          <PermissionGate codes="pc-cash-book-delete">
            <button aria-label="Delete" className="btn btn-outline-danger btn-sm btn-borderless"
              onClick={() => handleDelete(row.cashBookId)}>
              <i className="bi bi-trash" />
            </button>
          </PermissionGate>
        </div>
      ),
    },
  ];

  return (
    <MeridianPage title={menuLabel}>
      <PermissionGate codes="pc-cash-book-view" mode="message">
      <DataTable
        columns={columns}
        data={uiData.data}
        loading={uiData.loading}
        name={menuLabel}
        // //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      >
        <PermissionGate codes="pc-cash-book-new">
          <button className="ml-btn-action ml-fab" onClick={() => navigate('/petty-cash/cash-book/add')}>
            <i className="bi bi-plus-lg" aria-hidden="true" />
            New {menuLabel}
          </button>
        </PermissionGate>
      </DataTable>
      </PermissionGate>
    </MeridianPage>
  );
}
