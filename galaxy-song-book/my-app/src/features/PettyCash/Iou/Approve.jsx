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

const STATUS_LABEL = {
  Draft: 'New',
};

const fileUrl = (name) => (name ? config.apiBaseUrl + 'uploads/' + name : '');

export default function ApproveIou() {
  const { id } = useParams();
  const navigate = useNavigate();
  const menuLabel = useMenuLabel('/petty-cash/iou', 'IOU Issue');
  const [loading, setLoading] = useState(true);
  const [iou, setIou] = useState(null);
  const [submitting, setSubmitting] = useState(false);

  useEffect(() => {
    const init = async () => {
      const { success, data } = await ApiService.get(id);
      if (success && data) {
        setIou(data);
      }
      setLoading(false);
    };
    init();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [id]);

  const statusClass = (status) => STATUS_CLASS[status] || 'ml-badge-locked';
  const statusLabel = (status) => STATUS_LABEL[status] || status;

  const act = async (action) => {
    setSubmitting(true);
    const { success } = await ApiService.act({ id, action });
    setSubmitting(false);
    if (success) {
      MessageBoxService.show({
        message: `IOU ${action === 'Approve' ? 'processed' : action === 'Reject' ? 'rejected' : 'put on hold'}.`,
        type: 'success',
        onClose: () => navigate('/my-approvals'),
      });
    }
  };

  const handlePay = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Pay this IOU? This posts the disbursement to the ledger and cannot be undone.',
      type: 'primary',
      confirmText: 'Pay',
      cancelText: 'Cancel',
    });
    if (!confirmed) return;
    setSubmitting(true);
    const { success } = await ApiService.pay(id);
    setSubmitting(false);
    if (success) {
      MessageBoxService.show({
        message: 'IOU paid.',
        type: 'success',
        onClose: () => navigate('/petty-cash/iou'),
      });
    }
  };

  if (loading) {
    return <MeridianPage title={`${menuLabel} Approval`} backTo="/my-approvals" loading />;
  }

  if (!iou) {
    return (
      <MeridianPage title={`${menuLabel} Approval`} backTo="/my-approvals">
        <div className="alert alert-warning">IOU not found.</div>
      </MeridianPage>
    );
  }

  return (
    <MeridianPage
      title={`${menuLabel} Approval`}
      subtitle={iou.docNo ? `PIOU/${iou.docNo}` : null}
      backTo="/my-approvals"
      // cardClass="ml-form-card"
    >
      {/* Header */}
      <div className="row g-3 mb-4">
        <div className="col-md-8">
          <DetailGrid items={[
            {
              label: 'PCR No',
              value: <strong>{iou.iouNo ? 'PIOU/' + iou.iouNo : '-'}</strong>,
            }, {
              label: 'Status',
              value: <span className={`ml-badge ${statusClass(iou.status)}`}>{statusLabel(iou.status)}</span>,
            }, {
              label: 'Date',
              value: iou.expectedSettlementDate ? formatDate(iou.expectedSettlementDate) : '-',
            }, {
              label: 'Branch',
              value: iou.branchOrgUnit?.name || '-',
            }, {
              label: 'Party',
              value: iou.partyName || '-',
            }, {
              label: 'Currency',
              value: iou.currencyCode || '-',
            },
          ]} />
        </div>
        <div className="col-md-4">
          <div className="row g-2 align-items-stretch">
            <div className="col-4">
              <StatCard title="Requested" value={formatAmount(iou.requestAmount)} color="primary" />
            </div>
            <div className="col-4">
              <StatCard title="Confirmed" value={formatAmount(iou.confirmedAmount)} color="warning" />
            </div>
            <div className="col-4">
              <StatCard title="Approved" value={formatAmount(iou.approvedAmount)} color="success" />
            </div>
          </div>
        </div>
      </div>

      {/* Purpose */}
      {iou.purpose && (
        <div className="mb-4">
          <div className="text-muted small mb-1">Purpose</div>
          <p className="mb-0">{iou.purpose}</p>
        </div>
      )}

      {/* Documents */}
      {iou.docs && iou.docs.length > 0 && (
        <div className="ml-form-section mb-4">
          <h6 className="mb-2">Documents</h6>
          <div className="table-responsive">
            <table className="table table-sm mb-0">
              <thead className="table-light">
                <tr>
                  <th>File</th>
                  <th>Comment</th>
                </tr>
              </thead>
              <tbody>
                {iou.docs.map((d, i) => (
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

      {/* Approval History */}
      {iou.approval && iou.approval.length > 0 && (
        <div className="ml-form-section mb-4">
          <h6 className="mb-2">Approval History</h6>
          <div className="table-responsive">
            <table className="table table-sm mb-0">
              <thead className="table-light">
                <tr>
                  <th>Level</th>
                  <th>Action</th>
                  <th>Comment</th>
                  <th>Actor</th>
                  <th>Date / Time</th>
                </tr>
              </thead>
              <tbody>
                {iou.approval.map((a, i) => (
                  <tr key={i}>
                    <td>{a.levelNo || '-'}</td>
                    <td>
                      <span className={`ml-badge ${statusClass(a.action)}`}>
                        {a.action}
                      </span>
                    </td>
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

      {/* Pay box — shown once the IOU is Approved. Disburses cash and posts GL. */}
      {iou.status === 'Approved' && (
        <PermissionGate codes="pc-iou-pay" mode="message">
          <div className="ml-form-section mb-4">
            <h6 className="mb-3">Pay</h6>
            <p className="text-muted small mb-3">
              This IOU is approved and ready for disbursement. Paying posts the
              amount from the cash book and marks the IOU as Paid.
            </p>
            <button type="button" className="btn btn-primary" disabled={submitting} onClick={handlePay}>
              <i className="bi bi-cash-coin me-1" />
              Pay IOU
            </button>
          </div>
        </PermissionGate>
      )}

      {/* Action Box — hidden once closed (matches the backend's own block list
          in repo.act). The list screen can route here for any status, so a
          Paid/Settled/Cancelled/Rejected IOU must not show live action buttons. */}
      {!['Paid', 'Fully Settled', 'Cancelled', 'Rejected', 'Approval Rejected'].includes(iou.status) && (
      <PermissionGate codes={['pc-iou-approve', 'pc-iou-certify']} mode="message">
        <div className="ml-form-section">
          <h6 className="mb-3">Action</h6>
          <div className="d-flex gap-2">
            <button type="button" className="btn btn-success" disabled={submitting}
              onClick={() => act('Approve')}>
              <i className="bi bi-check-lg me-1" />
              Approve
            </button>
            <button type="button" className="btn btn-warning" disabled={submitting}
              onClick={() => act('OnHold')}>
              <i className="bi bi-pause-circle me-1" />
              On Hold
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

function formatAmount(val) {
  if (val === null || val === undefined || val === '') return '-';
  const n = Number(val);
  if (isNaN(n)) return '-';
  return n.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
}
