import { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import * as Yup from 'yup';
import InputField from '../../../components/InputField';
import { useFormikBuilder } from '../../../helpers/formikBuilder';
import { todayISO, formatDateTime } from '../../../helpers/transformDateFields';
import MessageBoxService from '../../../services/MessageBoxService';
import PermissionGate from '../../../components/PermissionGate';
import MeridianPage from '../../Meridian/MeridianPage';
import DocumentUploader from '../../../components/DocumentUploader';
import ApiService from './service';
import useMenuLabel from '../../../helpers/useMenuLabel';

import config from '../../../config/config';

export default function AddIou() {
  const { id } = useParams();
  const navigate = useNavigate();
  const menuLabel = useMenuLabel('/petty-cash/iou', 'IOU Issue');
  const [status, setStatus] = useState(null);
  const [iouNo, setIouNo] = useState('');
  const [auditLog, setAuditLog] = useState([]);
  const [auditComment, setAuditComment] = useState('');
  const [docs, setDocs] = useState([]);
  const [approvedRequests, setApprovedRequests] = useState([]);
  const [selectedRequestId, setSelectedRequestId] = useState('');
  const [uiData, setUiData] = useState({
    loading: true, cashBooks: [], parties: [], partyTypes: [], branches: [], currencies: [], requireIouRequest: false,
  });

  const selectedRequest = approvedRequests.find((r) => r.iouRequestId === selectedRequestId) || null;

  const fields = {
    cashBookId: {
      name: 'cashBookId', type: 'select', placeholder: 'Cash Book', initialValue: '',
      dataBinding: { data: uiData.cashBooks, keyField: 'cashBookId', valueField: 'code' },
      validation: Yup.string().required('Cash book is required'), className: 'col-sm-4',
    },
    branchOrgUnitId: {
      name: 'branchOrgUnitId', type: 'select', placeholder: 'Branch', initialValue: '',
      dataBinding: { data: uiData.branches, keyField: 'orgUnitId', valueField: 'name' },
      className: 'col-sm-4',
    },
    iouDate: {
      name: 'iouDate', type: 'date', placeholder: 'IOU Date',
      initialValue: todayISO(), className: 'col-sm-4',
    },
    partyType: {
      name: 'partyType', type: 'select', placeholder: 'Party Type', initialValue: '',
      dataBinding: { data: uiData.partyTypes, keyField: 'value', valueField: 'label' },
      validation: Yup.string().required('Party type is required'), className: 'col-sm-4',
    },
    partyId: {
      name: 'partyId', type: 'select', placeholder: 'Party', initialValue: '',
      dataBinding: { data: uiData.parties, keyField: 'businessPartnerId', valueField: 'partnerName' },
      validation: Yup.string().required('Party is required'), className: 'col-sm-4',
    },
    currencyCode: {
      name: 'currencyCode', type: 'select', placeholder: 'Currency', initialValue: '',
      dataBinding: { data: uiData.currencies, keyField: 'currencyCode', valueField: 'currencyCode' },
      validation: Yup.string().required('Currency is required'), className: 'col-sm-4',
    },
    requestAmount: {
      name: 'requestAmount', type: 'amount', placeholder: 'Request Amount', initialValue: '',
      validation: selectedRequest
        ? Yup.number().required('Amount is required').moreThan(0, 'Must be greater than zero')
          .max(selectedRequest.remaining, `Cannot exceed the remaining balance of ${selectedRequest.remaining} on this request`)
        : Yup.number().required('Amount is required').moreThan(0, 'Must be greater than zero'),
      className: 'col-sm-4',
    },
    expectedSettlementDate: {
      name: 'expectedSettlementDate', type: 'date', placeholder: 'Expected Settlement', initialValue: '', className: 'col-sm-4',
    },
    jobPoRef: {
      name: 'jobPoRef', type: 'text', placeholder: 'Job / PO Ref', initialValue: '', className: 'col-sm-6',
    },
    paymentMode: {
      name: 'paymentMode', type: 'select', placeholder: 'Payment Mode', initialValue: '',
      dataBinding: { data: [
        { value: 'PettyCash', label: 'Petty Cash' },
        { value: 'BankTransfer', label: 'Bank Transfer' },
        { value: 'Cheque', label: 'Cheque' },
        { value: 'Cash', label: 'Cash' },
      ], keyField: 'value', valueField: 'label' }, className: 'col-sm-6',
    },
    purpose: {
      name: 'purpose', type: 'textarea', placeholder: 'Purpose', initialValue: '', className: 'col-12',
    },
  };

  useEffect(() => {
    const init = async () => {
      const { success, data } = await ApiService.getUi();
      setUiData({
        loading: false,
        cashBooks: success ? data.cashBooks || [] : [],
        parties: success ? data.parties || [] : [],
        partyTypes: success ? data.partyTypes || [] : [],
        branches: success ? data.branches || [] : [],
        currencies: success ? data.currencies || [] : [],
        requireIouRequest: success ? !!data.requireIouRequest : false,
      });
      if (id) {
        const res = await ApiService.get(id);
        if (res.success && res.data) {
          const { audits, docs: existingDocs, ...header } = res.data;
          formik.setValues({
            cashBookId: header.cashBookId ?? '',
            branchOrgUnitId: header.branchOrgUnitId ?? '',
            iouDate: (header.iouDate || '').split('T')[0],
            partyType: header.partyType ?? '',
            partyId: header.partyId ?? '',
            requestAmount: header.requestAmount ?? '',
            expectedSettlementDate: (header.expectedSettlementDate || '').split('T')[0],
            jobPoRef: header.jobPoRef ?? '',
            paymentMode: header.paymentMode ?? '',
            purpose: header.purpose ?? '',
            currencyCode: header.currencyCode ?? '',
          });
          setStatus(header.status);
          setIouNo(`PIOU/${header.docNo}`);
          setAuditLog(audits || []);
          setDocs(existingDocs || []);
          setSelectedRequestId(header.iouRequestId ?? '');
        }
      } else {
        // New IOU: offer approved requests not yet converted.
        const reqRes = await ApiService.getApprovedRequests();
        setApprovedRequests(reqRes.success ? reqRes.data || [] : []);
      }
    };
    init();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [id]);

  const formik = useFormikBuilder(fields, handleSubmit);

  // Prefill the form from an approved IOU request. Clearing keeps typed values.
  // The request's own attachments (quotes, receipts) are copied onto the IOU
  // too, since they're the evidence the advance was approved against.
  const handleRequestPick = (requestId) => {
    setSelectedRequestId(requestId);
    if (!requestId) return;
    const r = approvedRequests.find((x) => x.iouRequestId === requestId);
    if (!r) return;
    formik.setValues({
      ...formik.values,
      partyType: r.partyType ?? '',
      partyId: r.partyId ?? '',
      // Default to what's left to issue, not the original ask — a request can
      // be drawn down across several IOUs.
      requestAmount: r.remaining ?? r.requestAmount ?? '',
      expectedSettlementDate: (r.expectedSettlementDate || '').split('T')[0],
      jobPoRef: r.jobPoRef ?? '',
      purpose: r.purpose ?? '',
      branchOrgUnitId: r.branchOrgUnitId || formik.values.branchOrgUnitId,
    });
    if (r.docs && r.docs.length) {
      const copied = r.docs.map((d) => ({ filePath: d.filePath, comment: d.comment || '' }));
      setDocs((prev) => [...copied, ...prev].slice(0, 5));
    }
  };

  // Auto-set currency from the selected cashbook. Locked once set.
  useEffect(() => {
    const cashBookId = formik.values.cashBookId;
    if (!cashBookId) return;
    const book = uiData.cashBooks.find((cb) => cb.cashBookId === cashBookId);
    if (book?.currencyCode && formik.values.currencyCode !== book.currencyCode) {
      formik.setFieldValue('currencyCode', book.currencyCode);
    }
  }, [formik.values.cashBookId, uiData.cashBooks]);

  async function handleSubmit(values) {
    if (!id && uiData.requireIouRequest && !selectedRequestId) {
      MessageBoxService.show({ message: 'An approved IOU Request must be selected to create an IOU.', type: 'danger' });
      return;
    }
    const payload = {
      ...values, iouId: id || null, isUpdate: !!id, exchangeRate: 1,
      branchOrgUnitId: values.branchOrgUnitId || null,
      iouRequestId: selectedRequestId || null,
      docs,
    };
    const { success, data } = await ApiService.update(payload);
    if (success) {
      MessageBoxService.show({
        message: 'IOU saved.',
        type: 'success',
        onClose: () => {
          // if (config.features.returnToListAfterSave) {
            // navigate('/petty-cash/iou');
          // } else if (!id && data?.iouId) {
            navigate(`/petty-cash/iou/approve/${data.iouId}`);
          // }
        },
      });
    }
  }

  const handleCancel = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Cancel this IOU? Any posting is voided.',
      type: 'danger', confirmText: 'Cancel IOU', cancelText: 'Back',
    });
    if (!confirmed) return;
    const { success } = await ApiService.cancel(id);
    if (success) {
      MessageBoxService.show({ message: 'IOU cancelled.', type: 'success', onClose: () => navigate('/petty-cash/iou') });
    }
  };

  const handleAddAudit = async () => {
    if (!auditComment.trim()) return;
    const { success } = await ApiService.addAudit({ iouId: id, comment: auditComment, auditorRole: 'Reviewer' });
    if (success) {
      setAuditComment('');
      const res = await ApiService.get(id);
      if (res.success && res.data) {
        setAuditLog(res.data.audits || []);
      }
    }
  };

  const isDraft = !id || status === 'Draft';
  const canCancel = id && !['Settled', 'Cancelled'].includes(status);

  return (
    <MeridianPage
      title={`${id ? 'Edit' : 'New'} ${menuLabel}`}
      subtitle={iouNo || null}
      backTo="/petty-cash/iou"
      cardClass="ml-form-card"
      actions={
        <>
          {canCancel && (
            <PermissionGate codes="pc-iou-cancel">
              <button type="button" className="ml-btn-ghost ml-btn-danger-ghost ml-fab-1" onClick={handleCancel}>
                <i className="bi bi-x-circle" aria-hidden="true" />
                Cancel
              </button>
            </PermissionGate>
          )}
          {isDraft && (
            <PermissionGate codes={id ? 'pc-iou-update' : 'pc-iou-save'}>
              <button type="submit" form="iou-form" className="ml-btn-action ml-fab" disabled={uiData.loading}>
                <i className="bi bi-check-lg" aria-hidden="true" />
                Save
              </button>
            </PermissionGate>
          )}
        </>
      }
    >
      {!id && uiData.requireIouRequest && approvedRequests.length === 0 && (
        <div className="ml-form-section mb-3">
          <div className="alert alert-warning mb-0">
            IOUs can only be created from an approved IOU Request, and none are available. Submit and approve an IOU Request first.
          </div>
        </div>
      )}

      {!id && (approvedRequests.length > 0 || uiData.requireIouRequest) && (
        <div className="ml-form-section mb-3">
          <label htmlFor="approvedRequestPick" className="form-label mb-1">
            From Approved Request{uiData.requireIouRequest ? ' (required)' : ''}
          </label>
          <select
            id="approvedRequestPick"
            className="form-select form-select-sm"
            value={selectedRequestId}
            onChange={(e) => handleRequestPick(e.target.value)}
          >
            {!uiData.requireIouRequest && <option value="">None (manual entry)</option>}
            {uiData.requireIouRequest && <option value="">Select a request...</option>}
            {approvedRequests.map((r) => (
              <option key={r.iouRequestId} value={r.iouRequestId}>
                {`PREQ/${r.docNo} - ${r.partyType} - remaining ${Number(r.remaining).toLocaleString()} of ${Number(r.approvedAmount ?? r.confirmedAmount ?? r.requestAmount).toLocaleString()}`}
              </option>
            ))}
          </select>
          <div className="form-text">
            Picking a request prefills the form, copies its attachments, and links it. A request can be issued across
            several IOUs; it's marked Settled once its full approved amount has been issued.
          </div>

          {selectedRequest && (
            <div className="row g-2 mt-2">
              <div className="col-sm-3">
                <label className="form-label text-muted small">Branch</label>
                <div className="form-control-plaintext">{selectedRequest.branchName || '-'}</div>
              </div>
              <div className="col-sm-3">
                <label className="form-label text-muted small">Department / Section</label>
                <div className="form-control-plaintext">
                  {[selectedRequest.departmentName, selectedRequest.sectionName].filter(Boolean).join(' / ') || '-'}
                </div>
              </div>
              <div className="col-sm-2">
                <label className="form-label text-muted small">Original</label>
                <div className="form-control-plaintext">{Number(selectedRequest.requestAmount).toLocaleString()}</div>
              </div>
              <div className="col-sm-2">
                <label className="form-label text-muted small">Approved</label>
                <div className="form-control-plaintext">
                  {Number(selectedRequest.approvedAmount ?? selectedRequest.confirmedAmount ?? selectedRequest.requestAmount).toLocaleString()}
                </div>
              </div>
              <div className="col-sm-2">
                <label className="form-label text-muted small">Remaining</label>
                <div className="form-control-plaintext fw-bold">{Number(selectedRequest.remaining).toLocaleString()}</div>
              </div>
            </div>
          )}
        </div>
      )}

      <form id="iou-form" onSubmit={formik.handleSubmit}>
        <div className="ml-form-section">
          <div className="row g-2">
            <InputField {...fields.cashBookId} formik={formik} />
            <InputField {...fields.branchOrgUnitId} formik={formik} />
            <InputField {...fields.iouDate} formik={formik} />
            <InputField {...fields.partyType} formik={formik} />
            <InputField {...fields.partyId} formik={formik} />
            <InputField {...fields.currencyCode} formik={formik} disabled={!!formik.values.cashBookId} />
            <InputField {...fields.requestAmount} formik={formik} />
            <InputField {...fields.expectedSettlementDate} formik={formik} />
            <InputField {...fields.jobPoRef} formik={formik} />
            <InputField {...fields.paymentMode} formik={formik} />
            <InputField {...fields.purpose} formik={formik} />
          </div>
        </div>
      </form>

      <div className="ml-form-section mt-3">
        <DocumentUploader value={docs} onChange={setDocs} readOnly={!isDraft} max={5} />
      </div>

      {id && auditLog.length > 0 && (
        <div className="ml-form-section mt-3">
          <h6 className="mb-2">Audit Trail</h6>
          <div className="table-responsive">
            <table className="table table-sm table-borderless mb-0">
              <thead className="table-light">
                <tr>
                  <th>Date</th>
                  <th>Auditor</th>
                  <th>Role</th>
                  <th>Comment</th>
                </tr>
              </thead>
              <tbody>
                {auditLog.map((a) => (
                  <tr key={a.auditLogId}>
                    <td className="text-nowrap">{formatDateTime(a.auditedAt)}</td>
                    <td>{a.auditorName || a.auditorUserId}</td>
                    <td>{a.auditorRole}</td>
                    <td>{a.comment}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
          <div className="input-group mt-2">
            <input type="text" className="form-control form-control-sm" placeholder="Add audit note..."
              value={auditComment} onChange={(e) => setAuditComment(e.target.value)} />
            <button className="btn btn-outline-secondary btn-sm" type="button" onClick={handleAddAudit}
              disabled={!auditComment.trim()}>
              Add Note
            </button>
          </div>
        </div>
      )}
    </MeridianPage>
  );
}
