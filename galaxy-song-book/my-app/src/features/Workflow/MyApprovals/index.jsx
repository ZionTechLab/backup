import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { DataTable } from '../../../components/DataTable/DataTable';
import MeridianPage from '../../Meridian/MeridianPage';
import PermissionGate from '../../../components/PermissionGate';
import ApiService from '../service';
import ApprovalHistory from './ApprovalHistory';

// Maps a transaction type to the screen that opens that document.
const DOC_ROUTE = {
  PIOU: (id) => `/petty-cash/iou/approve/${id}`,
  PREQ: (id) => `/petty-cash/iou-request/approve/${id}`,
  PRPL: (id) => `/petty-cash/replenishment/edit/${id}`,
  PSET: (id) => `/petty-cash/settlement/edit/${id}`,
};

const HISTORY_CLOSED = { open: false, key: null, docType: '', docId: '', label: '' };

export default function MyApprovals() {
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, data: [] });
  const [history, setHistory] = useState(HISTORY_CLOSED);

  useEffect(() => { fetchAll(); /* eslint-disable-next-line */ }, []);

  const fetchAll = async () => {
    setUiData((prev) => ({ ...prev, loading: true }));
    const { success, data } = await ApiService.getInbox();
    setUiData({ loading: false, data: success ? data : [] });
  };

  const open = (row) => {
    const fn = DOC_ROUTE[row.docType];
    if (fn) navigate(fn(row.docId));
  };

  const toggleHistory = (row) => {
    const key = `${row.docType}:${row.docId}`;
    if (history.open && history.key === key) { setHistory(HISTORY_CLOSED); return; }
    setHistory({ open: true, key, docType: row.docType, docId: row.docId, label: row.docNo || row.docId });
  };

  const columns = [
    { header: 'Document', field: 'docNo', class: 'text-nowrap', cardRole: 'title', render: (r) => r.docNo || r.docId },
    { header: 'Summary', field: 'summary', cardRole: 'subtitle', render: (r) => r.summary || '-' },
    { header: 'Transaction', field: 'docType', class: 'text-nowrap' },
    { header: 'Level', field: 'levelName', class: 'text-nowrap' },
    { header: 'Status', field: 'status', class: 'text-nowrap', cardRole: 'badge' },
    { header: 'Updated', field: 'updatedAt', type: 'date', class: 'text-nowrap' },
    {
      header: '', field: 'actions', isAction: true,
      actionTemplate: (row) => (
        <>
          <button aria-label="History" className="btn btn-outline-secondary btn-sm btn-borderless" onClick={() => toggleHistory(row)}>
            <i className="bi bi-clock-history" />
          </button>
          <button aria-label="Open" className="btn btn-outline-primary btn-sm btn-borderless" onClick={() => open(row)}>
            <i className="bi bi-box-arrow-up-right" />
          </button>
        </>
      ),
    },
  ];

  return (
    <MeridianPage title="My Approvals">
      <PermissionGate codes="approvals-view" mode="message">
        <DataTable columns={columns} data={uiData.data} loading={uiData.loading} name="My Approvals"
          //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
           />

        {history.open && (
          <ApprovalHistory docType={history.docType} docId={history.docId} label={history.label}
            onClose={() => setHistory(HISTORY_CLOSED)} />
        )}
      </PermissionGate>
    </MeridianPage>
  );
}
