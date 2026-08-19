import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { DataTable } from '../../../components/DataTable/DataTable';
import MeridianPage from '../../Meridian/MeridianPage';
import PermissionGate, { useHasPermission } from '../../../components/PermissionGate';
import ApiService from './service';
import STATUS_CLASS from '../../../helpers/statusBadge';
import useMenuLabel from '../../../helpers/useMenuLabel';

const STATUS_LABEL = {
  Draft: 'New',
};

function StatusBadge({ status }) {
  const label = STATUS_LABEL[status] || status;
  return <span className={`ml-badge ${STATUS_CLASS[status] || 'ml-badge-locked'}`}>{label}</span>;
}

export default function IouList() {
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, data: [] });
  // The document's own status stays 'Draft' while pending level-1 Certify,
  // since only workflow.act() (not create) advances it. A certifier/approver
  // must land on the approval screen even for a Draft row, or they have no
  // way to act on it — only a non-approver (the owner) should be sent to edit.
  const isApprover = useHasPermission(['pc-iou-certify', 'pc-iou-approve']);
  const menuLabel = useMenuLabel('/petty-cash/iou', 'IOU Issues');

  useEffect(() => { fetchAll(); /* eslint-disable-next-line */ }, []);

  const fetchAll = async () => {
    setUiData((prev) => ({ ...prev, loading: true }));
    const { success, data } = await ApiService.getAll();
    setUiData({ loading: false, data: success ? data : [] });
  };

  const columns = [
    { header: 'IOU No', field: 'iouNo', class: 'text-nowrap', cardRole: 'title' },
    { header: 'Date', field: 'iouDate', type: 'date', class: 'text-nowrap', cardRole: 'subtitle' },
    { header: 'Cash Book', field: 'cashBookCode', class: 'text-nowrap' },
    { header: 'Party', field: 'partyName', class: 'text-nowrap' },
    { header: 'Amount', field: 'requestAmount', type: 'currency', class: 'text-nowrap text-end', cardRole: 'amount' },
    { header: 'Status', field: 'status', render: (r) => <StatusBadge status={r.status} />, cardRole: 'badge' },
    {
      header: '', field: 'actions', isAction: true,
      actionTemplate: (row) => {
        // A non-approver's own Draft opens the editable form. Everything else
        // — including a Draft an approver is meant to certify — opens the
        // approval/pay screen, read-only or actionable depending on status.
        const opensEditForm = row.status === 'Draft' && !isApprover;
        const target = opensEditForm ? `/petty-cash/iou/edit/${row.iouId}` : `/petty-cash/iou/approve/${row.iouId}`;
        return (
          <PermissionGate codes="pc-iou-view-detail">
            <button aria-label={opensEditForm ? 'Edit' : 'Open'} className="btn btn-outline-primary btn-sm btn-borderless"
              onClick={() => navigate(target)}>
              <i className={`bi bi-${opensEditForm ? 'pencil' : 'box-arrow-up-right'}`} />
            </button>
          </PermissionGate>
        );
      },
    },
  ];

  return (
    <MeridianPage title={menuLabel}>
      <PermissionGate codes="pc-iou-view" mode="message">
      <DataTable
        columns={columns}
        data={uiData.data}
        loading={uiData.loading}
        name={menuLabel}
        //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      >
        <PermissionGate codes="pc-iou-new">
          <button className="ml-btn-action ml-fab" onClick={() => navigate('/petty-cash/iou/add')}>
            <i className="bi bi-plus-lg" aria-hidden="true" />
            New IOU Issue
          </button>
        </PermissionGate>
      </DataTable>
      </PermissionGate>
    </MeridianPage>
  );
}
