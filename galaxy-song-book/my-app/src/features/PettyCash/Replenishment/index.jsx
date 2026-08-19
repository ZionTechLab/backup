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

export default function ReplenishmentList() {
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, data: [] });
  const menuLabel = useMenuLabel('/petty-cash/replenishment', 'Float Replenishments');

  useEffect(() => { fetchAll(); /* eslint-disable-next-line */ }, []);

  const fetchAll = async () => {
    setUiData((prev) => ({ ...prev, loading: true }));
    const { success, data } = await ApiService.getAll();
    setUiData({ loading: false, data: success ? data : [] });
  };

  const columns = [
    { header: 'Replenish No', field: 'replenishmentNo', class: 'text-nowrap', cardRole: 'title' },
    { header: 'Date', field: 'requestDate', type: 'date', class: 'text-nowrap', cardRole: 'subtitle' },
    { header: 'Cash Book', field: 'cashBookCode', class: 'text-nowrap' },
    { header: 'Amount', field: 'amountRequested', type: 'currency', class: 'text-nowrap text-end', cardRole: 'amount' },
    { header: 'Status', field: 'status', render: (r) => <StatusBadge status={r.status} />, cardRole: 'badge' },
    {
      header: '', field: 'actions', isAction: true,
      actionTemplate: (row) => (
        <>
          <PermissionGate codes="pc-replenishment-view-detail">
            <button aria-label="Edit" className="btn btn-outline-primary btn-sm btn-borderless"
              onClick={() => navigate(`/petty-cash/replenishment/edit/${row.replenishmentId}`)}>
              <i className="bi bi-pencil" />
            </button>
          </PermissionGate>
        </>
      ),
    },
  ];

  return (
    <MeridianPage title={menuLabel}>
      <PermissionGate codes="pc-replenishment-view" mode="message">
      <DataTable
        columns={columns}
        data={uiData.data}
        loading={uiData.loading}
        name={menuLabel}
        //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      >
        <PermissionGate codes="pc-replenishment-new">
          <button className="ml-btn-action ml-fab" onClick={() => navigate('/petty-cash/replenishment/add')}>
            <i className="bi bi-plus-lg" aria-hidden="true" />
            New Top-Up
          </button>
        </PermissionGate>
      </DataTable>
      </PermissionGate>
    </MeridianPage>
  );
}
