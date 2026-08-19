import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { DataTable } from '../../../components/DataTable/DataTable';
import MeridianPage from '../../Meridian/MeridianPage';
import PermissionGate from '../../../components/PermissionGate';
import MessageBoxService from '../../../services/MessageBoxService';
import ApiService from './service';
import useMenuLabel from '../../../helpers/useMenuLabel';

const TAX_MODE_LABELS = {
  exempt: 'Exempt',
  inclusive: 'Inclusive',
  exclusive: 'Exclusive',
};
export default function ExpenseCategoryList() {
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, data: [], error: '' });
  const menuLabel = useMenuLabel('/petty-cash/expense-category', 'Petty Cash Categories');

  useEffect(() => { fetchAll(); /* eslint-disable-next-line */ }, []);

  const fetchAll = async () => {
    setUiData((prev) => ({ ...prev, loading: true }));
    const { success, data } = await ApiService.getAll();
    setUiData({ loading: false, data: success ? data : [], error: '' });
  };

  const handleDelete = async (id) => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Delete this petty cash category? This cannot be undone.',
      type: 'danger',
      confirmText: 'Delete',
      cancelText: 'Cancel',
    });
    if (!confirmed) return;
    const { success } = await ApiService.delete({ id });
    if (success) {
      MessageBoxService.show({ message: 'Petty cash category deleted.', type: 'success', onClose: fetchAll });
    }
  };

  const columns = [
    { header: 'Name', field: 'name', class: 'text-nowrap', cardRole: 'title' },
    {
      header: 'Expense Account', field: 'accountCode', class: 'text-nowrap',
      render: (r) => `${r.accountCode || ''} ${r.accountName || ''}`.trim(), cardRole: 'subtitle',
    },
    // {
    //   header: 'Tax Mode', field: 'taxMode', class: 'text-nowrap',
    //   render: (r) => TAX_MODE_LABELS[r.taxMode] || r.taxMode, cardRole: 'badge'
    // },
    // { header: 'Tax Rate', field: 'taxRate', type: 'decimal', class: 'text-nowrap text-end' },
    // {
    //   header: 'Input VAT Account', field: 'inputVatAccountCode', class: 'text-nowrap',
    //   render: (r) => r.inputVatAccountCode ? `${r.inputVatAccountCode} ${r.inputVatAccountName}`.trim() : '',
    // },
    { header: 'Active', field: 'isActive', type: 'boolean', class: 'text-nowrap' },
    {
      header: '', field: 'actions', isAction: true,
      actionTemplate: (row) => (
        <div className="d-flex gap-1">
          <PermissionGate codes="pc-expense-category-view-detail">
            <button aria-label="Edit" className="btn btn-outline-primary btn-sm btn-borderless"
              onClick={() => navigate(`/petty-cash/expense-category/edit/${row.categoryId}`)}>
              <i className="bi bi-pencil" />
            </button>
          </PermissionGate>
          <PermissionGate codes="pc-expense-category-delete">
            <button aria-label="Delete" className="btn btn-outline-danger btn-sm btn-borderless"
              onClick={() => handleDelete(row.expenseCategoryId)}>
              <i className="bi bi-trash" />
            </button>
          </PermissionGate>
        </div>
      ),
    },
  ];

  return (
    <MeridianPage title={menuLabel}>
      <PermissionGate codes="pc-expense-category-view" mode="message">
      <DataTable
        columns={columns}
        data={uiData.data}
        loading={uiData.loading}
        name={menuLabel}
        // //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      >
        <PermissionGate codes="pc-expense-category-new">
          <button className="ml-btn-action ml-fab" onClick={() => navigate('/petty-cash/expense-category/add')}>
            <i className="bi bi-plus-lg" aria-hidden="true" />
            New Category
          </button>
        </PermissionGate>
      </DataTable>
      </PermissionGate>
    </MeridianPage>
  );
}
