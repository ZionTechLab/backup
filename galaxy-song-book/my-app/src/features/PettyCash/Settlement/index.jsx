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

export default function SettlementList() {
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, data: [] });
  const menuLabel = useMenuLabel('/petty-cash/settlement', 'Settlements');

  useEffect(() => { fetchAll(); /* eslint-disable-next-line */ }, []);

  const fetchAll = async () => {
    setUiData((prev) => ({ ...prev, loading: true }));
    const { success, data } = await ApiService.getAll();
    setUiData({ loading: false, data: success ? data : [] });
  };

  const columns = [
    { header: 'Settlement No', field: 'settlementNo', class: 'text-nowrap', cardRole: 'title' },
    { header: 'Date', field: 'settlementDate', type: 'date', class: 'text-nowrap', cardRole: 'subtitle' },
    { header: 'Party', field: 'partyName', class: 'text-nowrap' },
    { header: 'IOUs', field: 'iouCount', class: 'text-nowrap text-end' },
    { header: 'Total Bills', field: 'totalBills', type: 'currency', class: 'text-nowrap text-end' },
    { header: 'Returned', field: 'balanceReturned', type: 'currency', class: 'text-nowrap text-end' },
    { header: 'Paid Out', field: 'balanceClaimed', type: 'currency', class: 'text-nowrap text-end' },
    { header: 'Status', field: 'status', render: (r) => <StatusBadge status={r.status} />, cardRole: 'badge' },
    {
      header: '', field: 'actions', isAction: true,
      actionTemplate: (row) => (
        <>
          <PermissionGate codes="pc-settlement-view-detail">
            <button aria-label="Edit" className="btn btn-outline-primary btn-sm btn-borderless"
              onClick={() => navigate(`/petty-cash/settlement/edit/${row.settlementId}`)}>
              <i className="bi bi-pencil" />
            </button>
          </PermissionGate>
        </>
      ),
    },
  ];

  return (
    <MeridianPage title={menuLabel}>
      <PermissionGate codes="pc-settlement-view" mode="message">
      <DataTable
        columns={columns}
        data={uiData.data}
        loading={uiData.loading}
        name={menuLabel}
        //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      >
        <PermissionGate codes="pc-settlement-new">
          <button className="ml-btn-action ml-fab" onClick={() => navigate('/petty-cash/settlement/add')}>
            <i className="bi bi-plus-lg" aria-hidden="true" />
            New Settlement
          </button>
        </PermissionGate>
      </DataTable>
      </PermissionGate>
    </MeridianPage>
  );
}
