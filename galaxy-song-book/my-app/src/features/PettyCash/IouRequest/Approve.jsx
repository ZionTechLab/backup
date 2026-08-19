import { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import MeridianPage from '../../Meridian/MeridianPage';
import PermissionGate from '../../../components/PermissionGate';
import MessageBoxService from '../../../services/MessageBoxService';
import config from '../../../config/config';
import ApiService from './service';
import { formatDate, formatDateTime } from '../../../helpers/transformDateFields';
import STATUS_CLASS from '../../../helpers/statusBadge';
import StatCard from '../../../components/StatCard/StatCard';
import DetailGrid from '../../../components/DetailGrid/DetailGrid';
import useMenuLabel from '../../../helpers/useMenuLabel';

const fileUrl = (name) => (name ? config.apiBaseUrl + 'uploads/' + name : '');

const formatAmount = (val) => {
  if (val === null || val === undefined || val === '') return '-';
  const n = Number(val);
  if (isNaN(n)) return '-';
  return n.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
};

export default function ApproveIouRequest() {
  const { id } = useParams();
  const navigate = useNavigate();
  const menuLabel = useMenuLabel('/petty-cash/iou-request', 'IOU Request');
  const [loading, setLoading] = useState(true);
  const [request, setRequest] = useState(null);
  const [amount, setAmount] = useState('');
  const [comment, setComment] = useState('');
  const [submitting, setSubmitting] = useState(false);

  useEffect(() => {
    const init = async () => {
      const { success, data } = await ApiService.get(id);
      if (success && data) {
        setRequest(data);
        // Baseline this level revises from: the original ask at level 1, the
        // level-1 revision at level 2. Matches the backend's own logic.
        const baseline = data.workflowLevel === 1 ? data.requestAmount : (data.confirmedAmount ?? data.requestAmount);
        setAmount(baseline ?? '');
      }
      setLoading(false);
    };
    init();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [id]);

  if (loading) {
    return <MeridianPage title={`${menuLabel} Approval`} backTo="/my-approvals" loading />;
  }
  if (!request) {
    return (
      <MeridianPage title={`${menuLabel} Approval`} backTo="/my-approvals">
        <div className="alert alert-warning">Request not found.</div>
      </MeridianPage>
    );
  }

  const baseline = request.workflowLevel === 1 ? request.requestAmount : (request.confirmedAmount ?? request.requestAmount);
  const isRevised = amount !== '' && Number(amount).toFixed(2) !== Number(baseline || 0).toFixed(2);
  const canAct = request.status === 'Draft' || request.status === 'Certified';

  const act = async (action) => {
    if (action === 'Reject' && !comment.trim()) {
      MessageBoxService.show({ message: 'A comment is required to reject.', type: 'warning' });
      return;
    }
    if (action === 'Approve' && isRevised && !comment.trim()) {
      MessageBoxService.show({ message: 'A comment is required when overriding the amount.', type: 'warning' });
      return;
    }
    setSubmitting(true);
    const { success } = await ApiService.act(id, action, action === 'Approve' ? parseFloat(amount) || 0 : undefined, comment.trim());
    setSubmitting(false);
    if (success) {
      MessageBoxService.show({
        message: `IOU Request ${action === 'Approve' ? 'processed' : 'rejected'}.`,
        type: 'success',
        onClose: () => navigate('/my-approvals'),
      });
    }
  };

  const handleClose = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Close this request? No further IOUs can be issued against it, even with remaining balance.',
      type: 'warning', confirmText: 'Close', cancelText: 'Cancel',
    });
    if (!confirmed) return;
    setSubmitting(true);
    const { success } = await ApiService.close(id);
    setSubmitting(false);
    if (success) {
      MessageBoxService.show({ message: 'Request closed.', type: 'success', onClose: () => navigate('/petty-cash/iou-request') });
    }
  };

  return (
    <MeridianPage
      title={`${menuLabel} Approval`}
      // subtitle={request.docNo ? `PREQ/${request.docNo}` : null}
      backTo="/my-approvals"
    >
      <div className="row g-3 mb-4">
        <div className="col-md-8">
          <DetailGrid items={[
            {
              label: 'Request No',
              value: <strong>{request.docNo ? 'PREQ/' + request.docNo : '-'}</strong>,
            }, {
              label: 'Status',
              value: <span className={`ml-badge ${STATUS_CLASS[request.status] || 'ml-badge-locked'}`}>{request.status}</span>,
            }, {
              label: 'Request Date',
              value: request.iouDate ? formatDate(request.iouDate) : '-',
            }, {
              label: 'Expected Settlement',
              value: request.expectedSettlementDate ? formatDate(request.expectedSettlementDate) : '-',
            }, {
              label: 'Party',
              value: request.partyName || '-',
            }, {
              label: 'Party Type',
              value: request.partyType || '-',
            }, {
              label: 'Branch',
              value: request.branchName || '-',
            }, {
              label: 'Currency',
              value: request.currencyCode || '-',
            }, {
              label: 'Department',
              value: request.departmentName || '-',
            }, {
              label: 'Section',
              value: request.sectionName || '-',
            }, {
              label: 'Job / PO Ref',
              value: request.jobPoRef || '-',
              span: 3,
            },
          ]} />
        </div>
        <div className="col-md-4">
          <div className="row g-2 align-items-stretch">
            <div className="col-4">
              <StatCard title="Original" value={formatAmount(request.requestAmount)} color="primary" />
            </div>
            <div className="col-4">
              <StatCard title="Confirmed" value={formatAmount(request.confirmedAmount)} color="warning" />
            </div>
            <div className="col-4">
              <StatCard title="Approved" value={formatAmount(request.approvedAmount)} color="success" />
            </div>
          </div>
          {request.status === 'Approved' && (
            <div className="mt-2">
              <StatCard title="Remaining to Issue" value={formatAmount(request.remaining)} color="success" size="sm" />
            </div>
          )}
        </div>
      </div>

      {request.purpose && (
        <div className="mb-4">
          <div className="text-muted small mb-1">Purpose</div>
          <p className="mb-0">{request.purpose}</p>
        </div>
      )}

      {request.docs && request.docs.length > 0 && (
        <div className="ml-form-section mb-4">
          <h6 className="mb-2">Documents</h6>
          <div className="table-responsive">
            <table className="table table-sm mb-0">
              <thead className="table-light">
                <tr><th>File</th><th>Comment</th></tr>
              </thead>
              <tbody>
                {request.docs.map((d, i) => (
                  <tr key={i}>
                    <td>
                      <a href={fileUrl(d.filePath)} target="_blank" rel="noreferrer">
                        <i className="bi bi-file-earmark me-1" />
                        {d.filePath}
                      </a>
                    </td>
                    <td>{d.comment || '-'}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </div>
      )}

      {request.approval && request.approval.length > 0 && (
        <div className="ml-form-section mb-4">
          <h6 className="mb-2">Approval History</h6>
          <div className="table-responsive">
            <table className="table table-sm mb-0">
              <thead className="table-light">
                <tr>
                  <th>Level</th><th>Action</th><th>Comment</th><th>Actor</th><th>Date / Time</th>
                </tr>
              </thead>
              <tbody>
                {request.approval.map((a, i) => (
                  <tr key={i}>
                    <td>{a.levelNo || '-'}</td>
                    <td><span className={`ml-badge ${STATUS_CLASS[a.action] || 'ml-badge-locked'}`}>{a.action}</span></td>
                    <td>{a.comment || '-'}</td>
                    <td>{a.actorName || a.actor || '-'}</td>
                    <td className="text-nowrap">{a.actedAt ? formatDateTime(a.actedAt) : '-'}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </div>
      )}

      {/* Close — stops further issuing early, even with balance remaining. */}
      {request.status === 'Approved' && (
        <PermissionGate codes="iou-request-close" mode="message">
          <div className="ml-form-section mb-4">
            <h6 className="mb-3">Close Request</h6>
            <p className="text-muted small mb-3">
              This request has {formatAmount(request.remaining)} remaining to issue. Closing it stops
              any further IOUs from being issued against it.
            </p>
            <button type="button" className="btn btn-outline-danger" disabled={submitting} onClick={handleClose}>
              <i className="bi bi-lock me-1" />
              Close Request
            </button>
          </div>
        </PermissionGate>
      )}

      {/* Action box — revise the amount, approve, or reject. */}
      {canAct && (
        <PermissionGate codes={['iou-request-certify', 'iou-request-approve']} mode="message">
          <div className="ml-form-section">
            <h6 className="mb-3">Action</h6>
            <div className="row g-3">
              <div className="col-md-4">
                <label className="form-label">Revised Amount</label>
                <input type="number" className="form-control" value={amount}
                  onChange={(e) => setAmount(e.target.value)} step="0.01" min="0" />
                {isRevised && (
                  <div className="form-text text-warning">
                    Revised from the original {formatAmount(baseline)}. A comment is required.
                  </div>
                )}
              </div>
              <div className="col-md-8">
                <label className="form-label">
                  Comment{(isRevised) && <span className="text-danger"> *</span>}
                </label>
                <textarea className="form-control" rows={2} value={comment}
                  onChange={(e) => setComment(e.target.value)} />
              </div>
            </div>
            <div className="d-flex gap-2 mt-3">
              <button type="button" className="btn btn-success" disabled={submitting}
                onClick={() => act('Approve')}>
                <i className="bi bi-check-lg me-1" />
                Approve
              </button>
              <button type="button" className="btn btn-danger" disabled={submitting}
                onClick={() => act('Reject')}>
                <i className="bi bi-x-circle me-1" />
                Reject
              </button>
            </div>
          </div>
        </PermissionGate>
      )}
    </MeridianPage>
  );
}
