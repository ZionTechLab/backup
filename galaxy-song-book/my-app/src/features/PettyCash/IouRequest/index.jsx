import { useEffect,  useState } from 'react';
import { useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { DataTable } from '../../../components/DataTable/DataTable';
import MeridianPage from '../../Meridian/MeridianPage';
import PermissionGate, { useHasPermission } from '../../../components/PermissionGate';
import { selectUserId } from '../../auth/authSlice';
import ApiService from './service';
import STATUS_CLASS from '../../../helpers/statusBadge';
import useMenuLabel from '../../../helpers/useMenuLabel';

const TABS = ["My Requests", "All"];

function StatusBadge({ status }) {
  return <span className={`ml-badge ${STATUS_CLASS[status] || 'ml-badge-locked'}`}>{status}</span>;
}

export default function IouRequestList() {
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, data: [] });
  const [activeTab, setActiveTab] = useState('My Requests');
  const canSeeAll = useHasPermission(['iou-request-certify', 'iou-request-approve']);
  const loggedInUserId = useSelector(selectUserId);
  const menuLabel = useMenuLabel('/petty-cash/iou-request', 'IOU Requests');

  useEffect(() => { fetchAll(); /* eslint-disable-next-line */ }, []);

   const fetchAll = async () => {
      setUiData(prev => ({ ...prev, loading: true, error: '' }));
      const res = await ApiService.getAll();
       setUiData(prev => ({ ...prev, ...res , loading: false }));
    };

  const dataArray = Array.isArray(uiData.data) ? uiData.data : [];
  const filtered = activeTab === 'My Requests'
    ? dataArray.filter((p) => p.requestedByUserId === loggedInUserId)
    : dataArray;

  const columns = [
    { header: 'Request No', field: 'requestNo', class: 'text-nowrap', cardRole: 'title' },
    { header: 'Date', field: 'iouDate', type: 'date', class: 'text-nowrap', cardRole: 'subtitle' },
    { header: 'Party Type', field: 'partyType', class: 'text-nowrap' },
    { header: 'Party', field: 'partyName', class: 'text-nowrap' },
    { header: 'Amount', field: 'requestAmount', type: 'currency', class: 'text-nowrap text-end', cardRole: 'amount' },
    { header: 'Status', field: 'status', render: (r) => <StatusBadge status={r.status} />, cardRole: 'badge' },
    {
      header: '', field: 'actions', isAction: true,
      actionTemplate: (row) => {
        const opensEditForm = row.status === 'Draft' && !canSeeAll;
        const target = opensEditForm
          ? `/petty-cash/iou-request/edit/${row.iouRequestId}`
          : `/petty-cash/iou-request/approve/${row.iouRequestId}`;
        return (
          <button aria-label={opensEditForm ? 'Edit' : 'Open'} className="btn btn-outline-primary btn-sm btn-borderless"
            onClick={() => navigate(target)}>
            <i className={`bi bi-${opensEditForm ? 'pencil' : 'box-arrow-up-right'}`} />
          </button>
        );
      },
    },
  ];

  return (
    <MeridianPage title={menuLabel}>
      <PermissionGate codes="iou-request-view" mode="message">

      {canSeeAll && (
        <div className="ml-coa-tabs">
          {TABS.map((tab) => (
            <button
              key={tab}
              className={`ml-coa-tab${activeTab === tab ? " ml-coa-tab-active" : ""}`}
              onClick={() => setActiveTab(tab)}
            >
              {tab}
            </button>
          ))}
        </div>
      )}

      <DataTable
        columns={columns}
        data={filtered}
        loading={uiData.loading}
        name={menuLabel}
        //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      >
        <PermissionGate codes="iou-request-new">
          <button className="ml-btn-action ml-fab" onClick={() => navigate('/petty-cash/iou-request/add')}>
            <i className="bi bi-plus-lg" aria-hidden="true" />
            New IOU Request
          </button>
        </PermissionGate>
      </DataTable>
      </PermissionGate>
    </MeridianPage>
  );
}