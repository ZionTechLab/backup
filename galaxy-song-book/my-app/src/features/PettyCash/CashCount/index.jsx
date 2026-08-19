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

function VarianceCell({ row }) {
  const v = Number(row.variance || 0);
  const cls = v > 0 ? 'text-success' : v < 0 ? 'text-danger' : '';
  return <span className={cls}>{v.toLocaleString(undefined, { minimumFractionDigits: 2, maximumFractionDigits: 2 })}</span>;
}

export default function CashCountList() {
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, data: [] });
  const menuLabel = useMenuLabel('/petty-cash/cash-count', 'Cash Counts');

  useEffect(() => { fetchAll(); /* eslint-disable-next-line */ }, []);

  const fetchAll = async () => {
    setUiData((prev) => ({ ...prev, loading: true }));
    const { success, data } = await ApiService.getAll();
    setUiData({ loading: false, data: success ? data : [] });
  };

  const columns = [
    { header: 'Count No', field: 'countNo', class: 'text-nowrap', cardRole: 'title' },
    { header: 'Date', field: 'countDate', type: 'date', class: 'text-nowrap', cardRole: 'subtitle' },
    { header: 'Cash Book', field: 'cashBookCode', class: 'text-nowrap' },
    { header: 'System Balance', field: 'systemBalance', type: 'currency', class: 'text-nowrap text-end' },
    { header: 'Physical Total', field: 'physicalTotal', type: 'currency', class: 'text-nowrap text-end' },
    { header: 'Variance', field: 'variance', render: (r) => <VarianceCell row={r} />, class: 'text-nowrap text-end', cardRole: 'amount' },
    { header: 'Status', field: 'status', render: (r) => <StatusBadge status={r.status} />, cardRole: 'badge' },
    {
      header: '', field: 'actions', isAction: true,
      actionTemplate: (row) => (
        <>
          <PermissionGate codes="pc-cash-count-view-detail">
            <button aria-label="Edit" className="btn btn-outline-primary btn-sm btn-borderless"
              onClick={() => navigate(`/petty-cash/cash-count/edit/${row.cashCountId}`)}>
              <i className="bi bi-pencil" />
            </button>
          </PermissionGate>
        </>
      ),
    },
  ];

  return (
    <MeridianPage title={menuLabel}>
      <PermissionGate codes="pc-cash-count-view" mode="message">
      <DataTable
        columns={columns}
        data={uiData.data}
        loading={uiData.loading}
        name={menuLabel}
        // //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      >
        <PermissionGate codes="pc-cash-count-new">
          <button className="ml-btn-action ml-fab" onClick={() => navigate('/petty-cash/cash-count/add')}>
            <i className="bi bi-plus-lg" aria-hidden="true" />
            New Count
          </button>
        </PermissionGate>
      </DataTable>
      </PermissionGate>
    </MeridianPage>
  );
}
