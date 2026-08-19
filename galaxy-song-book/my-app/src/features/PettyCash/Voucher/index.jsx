import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { DataTable } from '../../../components/DataTable/DataTable';
import MeridianPage from '../../Meridian/MeridianPage';
import PermissionGate from '../../../components/PermissionGate';
import ApiService from './service';

import STATUS_CLASS from '../../../helpers/statusBadge';
import useMenuLabel from '../../../helpers/useMenuLabel';

function StatusBadge({ status }) {
  return <span className={`ml-badge ${STATUS_CLASS[status] || 'ml-badge-locked'}`}>{status}</span>;
}

export default function VoucherList() {
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, data: [] });
  const menuLabel = useMenuLabel('/petty-cash/voucher', 'Payment Vouchers');

  useEffect(() => { fetchAll(); /* eslint-disable-next-line */ }, []);

  const fetchAll = async () => {
    setUiData((prev) => ({ ...prev, loading: true }));
    const { success, data } = await ApiService.getAll();
    setUiData({ loading: false, data: success ? data : [] });
  };

  const columns = [
    { header: 'Voucher No', field: 'voucherNo', class: 'text-nowrap', cardRole: 'title' },
    { header: 'Date', field: 'voucherDate', type: 'date', class: 'text-nowrap', cardRole: 'subtitle' },
    { header: 'Cash Book', field: 'cashBookCode', class: 'text-nowrap' },
    { header: 'Payee', field: 'payeeName', class: 'text-nowrap' },
    { header: 'Currency', field: 'currencyCode', class: 'text-nowrap' },
    { header: 'Amount', field: 'totalAmount', type: 'currency', class: 'text-nowrap text-end', cardRole: 'amount' },
    { header: 'Status', field: 'status', render: (r) => <StatusBadge status={r.status} />, cardRole: 'badge' },
    {
      header: '', field: 'actions', isAction: true,
      actionTemplate: (row) => (
        <>
          <PermissionGate codes="pc-voucher-view-detail">
            <button aria-label="Edit" className="btn btn-outline-primary btn-sm btn-borderless"
              onClick={() => navigate(`/petty-cash/voucher/edit/${row.voucherId}`)}>
              <i className="bi bi-pencil" />
            </button>
          </PermissionGate>
        </>
      ),
    },
  ];

  return (
    <MeridianPage title={menuLabel}>
      <PermissionGate codes="pc-voucher-view" mode="message">
      <DataTable
        columns={columns}
        data={uiData.data}
        loading={uiData.loading}
        name={menuLabel}
        //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      >
        <PermissionGate codes="pc-voucher-new">
          <button className="ml-btn-action ml-fab" onClick={() => navigate('/petty-cash/voucher/add')}>
            <i className="bi bi-plus-lg" aria-hidden="true" />
            New Voucher
          </button>
        </PermissionGate>
      </DataTable>
      </PermissionGate>
    </MeridianPage>
  );
}
