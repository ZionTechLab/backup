import { useEffect, useRef, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import * as Yup from 'yup';
import InputField from '../../../components/InputField';
import { DataGrid } from '../../../components/DataGrid';
import { useFormikBuilder } from '../../../helpers/formikBuilder';
import { todayISO } from '../../../helpers/transformDateFields';
import MessageBoxService from '../../../services/MessageBoxService';
import PermissionGate from '../../../components/PermissionGate';
import MeridianPage from '../../Meridian/MeridianPage';
import ApiService from './service';
import config from '../../../config/config';
import ApprovalHistory from '../../Workflow/MyApprovals/ApprovalHistory';
import useMenuLabel from '../../../helpers/useMenuLabel';

const toNum = (v) => Number(String(v ?? '').replace(/[^\d.]/g, '')) || 0;

const WF_BADGE = {
  Pending: 'ml-badge-locked',
  Approved: 'ml-badge-open',
  Rejected: 'ml-badge-void',
  OnHold: 'ml-badge-locked',
  Cancelled: 'ml-badge-void',
};

// Settlement is a per-party cash box event balancing
//   bills + cash returned = IOU allocations + extra paid to party
// Cash book is the entry point: it fixes the currency and scopes which IOUs
// and petty cash requests can be settled, since Clear posts against that
// book's GL account.

export default function AddSettlement() {
  const { id } = useParams();
  const navigate = useNavigate();
  const menuLabel = useMenuLabel('/petty-cash/settlement', 'Settlement / Payment');
  const gridRef = useRef();
  const [lineItems, setLineItems] = useState([]);
  const [status, setStatus] = useState(null);
  const [cashBookId, setCashBookId] = useState('');
  const [partyId, setPartyId] = useState('');
  const [allocs, setAllocs] = useState({});
  const [cashReturned, setCashReturned] = useState('');
  const [selectedVoucherId, setSelectedVoucherId] = useState('');
  const [savedView, setSavedView] = useState(null);
  const [settlementNo, setSettlementNo] = useState('');
  const [workflowStatus, setWorkflowStatus] = useState(null);
  const [showHistory, setShowHistory] = useState(false);
  const [actComment, setActComment] = useState('');
  const [showRejectInput, setShowRejectInput] = useState(false);
  const [uiData, setUiData] = useState({
    loading: true, openIous: [], categories: [], draftVouchers: [], parties: [], cashBooks: [],
  });

  const fields = {
    settlementDate: {
      name: 'settlementDate', type: 'date', placeholder: 'Settlement Date',
      initialValue: todayISO(),
      validation: Yup.string().required('Date is required'), className: 'col-sm-3',
    },
    remarks: {
      name: 'remarks', type: 'textarea', placeholder: 'Remarks', initialValue: '', className: 'col-12',
    },
  };

  const lineColumns = [
    {
      header: 'Category', field: 'categoryId', type: 'select', searchable: true, placeholder: 'Category',
      options: uiData.categories.map((c) => ({ value: c.categoryId, label: c.name })),
    },
    { header: 'Description', field: 'description', type: 'text', placeholder: 'Description' },
    { header: 'Amount', field: 'amount', type: 'amount', placeholder: 'Amount', width: '22%' },
  ];

  const formik = useFormikBuilder(fields, handleSubmit);

  const selectedCashBookId = cashBookId;
  const selectedBook = uiData.cashBooks.find((b) => b.cashBookId === selectedCashBookId) || null;

  // Everything below is scoped to the selected cash book, since Clear posts
  // against that book's GL account and its currency.
  const cashBookIous = selectedCashBookId
    ? uiData.openIous.filter((i) => i.cashBookId === selectedCashBookId)
    : [];
  const cashBookVouchers = selectedCashBookId
    ? uiData.draftVouchers.filter((v) => v.cashBookId === selectedCashBookId)
    : [];

  // Parties come from that cash book's open IOUs and draft petty cash
  // requests, plus any other party (for a fresh direct payment).
  const partyMap = new Map();
  for (const i of cashBookIous) {
    const e = partyMap.get(i.partyId) || {
      partyId: i.partyId, partyType: i.partyType, name: i.partyName, outstanding: 0, iouCount: 0,
    };
    e.iouCount += 1;
    e.outstanding += toNum(i.advanceOutstanding);
    partyMap.set(i.partyId, e);
  }
  for (const v of cashBookVouchers) {
    const e = partyMap.get(v.payeePartyId) || {
      partyId: v.payeePartyId, partyType: v.payeePartyType, name: v.payeeName, outstanding: 0, iouCount: 0,
    };
    if (!e.name) e.name = v.payeeName;
    partyMap.set(v.payeePartyId, e);
  }
  for (const p of uiData.parties) {
    if (!partyMap.has(p.businessPartnerId)) {
      partyMap.set(p.businessPartnerId, {
        partyId: p.businessPartnerId, partyType: p.partyType || 'Employee', name: p.partnerName, outstanding: 0, iouCount: 0,
      });
    }
  }
  const partyOptions = [...partyMap.values()];
  const selectedParty = partyOptions.find((p) => p.partyId === partyId) || null;

  const partyIous = selectedParty ? cashBookIous.filter((i) => i.partyId === selectedParty.partyId) : [];
  const eligibleVouchers = selectedParty ? cashBookVouchers.filter((v) => v.payeePartyId === selectedParty.partyId) : [];

  useEffect(() => {
    const init = async () => {
      const { success, data } = await ApiService.getUi();
      setUiData({
        loading: false,
        openIous: success ? data.openIous || [] : [],
        categories: success ? data.categories || [] : [],
        draftVouchers: success ? data.draftVouchers || [] : [],
        parties: success ? data.parties || [] : [],
        cashBooks: success ? data.cashBooks || [] : [],
      });
      if (id) {
        const res = await ApiService.get(id);
        if (res.success && res.data) {
          const { lines, allocations, ...header } = res.data;
          formik.setValues({
            settlementDate: (header.settlementDate || '').split('T')[0],
            remarks: header.remarks ?? '',
          });
          setCashBookId(header.cashBookId || '');
          setStatus(header.status);
          setSettlementNo(`PSET/${header.docNo}`);
          setWorkflowStatus(header.workflowStatus ?? null);
          setSelectedVoucherId(header.voucherId ?? '');
          setCashReturned(header.balanceReturned > 0 ? String(header.balanceReturned) : '');
          setPartyId(header.partyId || '');
          setAllocs(Object.fromEntries((allocations || []).map((a) => [a.iouId, String(a.allocatedAmount)])));
          const items = (lines || []).map((l) => ({
            categoryId: l.categoryId, description: l.description, amount: l.lineTotal,
          }));
          setLineItems(items);
          gridRef.current?.reset(items);
          setSavedView({ header, allocations: allocations || [], lines: lines || [] });
        }
      }
    };
    init();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [id]);

  const isDraft = !id || status === 'Draft';
  const canClear = id && status === 'Draft' && workflowStatus === 'Approved';
  const canCancel = id && status !== 'Cancelled';
  const canAct = id && status === 'Draft' && workflowStatus === 'Pending';

  // Changing the cash book invalidates the party/bills/allocations picked
  // under the previous one.
  const handleCashBookPick = (nextCashBookId) => {
    setCashBookId(nextCashBookId);
    setPartyId('');
    setAllocs({});
    setSelectedVoucherId('');
    setCashReturned('');
    setLineItems([]);
    gridRef.current?.reset([]);
  };

  const handlePartyPick = (nextPartyId) => {
    setPartyId(nextPartyId);
    setAllocs({});
    setSelectedVoucherId('');
    setCashReturned('');
    setLineItems([]);
    gridRef.current?.reset([]);
  };

  // Selecting a request loads its lines as the bills. Clearing restores manual entry.
  const handleVoucherPick = (voucherId) => {
    setSelectedVoucherId(voucherId);
    const v = uiData.draftVouchers.find((x) => x.voucherId === voucherId);
    const items = v
      ? (v.lines || []).map((l) => ({ categoryId: l.categoryId, description: l.description, amount: l.lineTotal }))
      : [];
    setLineItems(items);
    gridRef.current?.reset(items);
  };

  const buildLines = () =>
    lineItems
      .filter((it) => it.categoryId && toNum(it.amount) > 0)
      .map((it) => {
        const amt = toNum(it.amount);
        return { categoryId: it.categoryId, description: it.description || null, netAmount: amt, vatAmount: 0, lineTotal: amt };
      });

  // Live equation.
  const totalBills = buildLines().reduce((s, l) => s + Number(l.lineTotal || 0), 0);
  const cashR = toNum(cashReturned);
  const totalAllocated = partyIous.reduce((s, i) => s + toNum(allocs[i.iouId]), 0);
  const extraPaid = totalBills + cashR - totalAllocated;
  const allocProblems = partyIous
    .filter((i) => toNum(allocs[i.iouId]) > toNum(i.advanceOutstanding))
    .map((i) => i.iouNo);
  const bothWays = extraPaid > 0 && cashR > 0 && totalAllocated > 0;

  // Distribute bills plus returned cash across the IOUs, oldest first.
  const autoAllocate = () => {
    let remaining = totalBills + cashR;
    const next = {};
    for (const i of partyIous) {
      const out = toNum(i.advanceOutstanding);
      const take = Math.min(out, Math.max(remaining, 0));
      if (take > 0) next[i.iouId] = String(take);
      remaining -= take;
    }
    setAllocs(next);
  };

  async function handleSubmit(values) {
    if (!cashBookId) {
      MessageBoxService.show({ message: 'Pick a cash book first.', type: 'danger' });
      return;
    }
    if (!selectedParty) {
      MessageBoxService.show({ message: 'Pick a party first.', type: 'danger' });
      return;
    }
    const lines = buildLines();
    const allocations = partyIous
      .filter((i) => toNum(allocs[i.iouId]) > 0)
      .map((i) => ({ iouId: i.iouId, amount: toNum(allocs[i.iouId]) }));
    if (!selectedVoucherId && !allocations.length && !lines.length && cashR === 0) {
      MessageBoxService.show({ message: 'Add bills, a petty cash request, an IOU allocation, or a cash return.', type: 'danger' });
      return;
    }
    if (extraPaid < 0) {
      MessageBoxService.show({ message: 'Allocations exceed bills plus cash returned.', type: 'danger' });
      return;
    }
    if (bothWays) {
      MessageBoxService.show({ message: 'Cannot both return cash and pay extra. Reduce cash returned.', type: 'danger' });
      return;
    }

    const { success, data } = await ApiService.update({
      cashBookId,
      settlementDate: values.settlementDate,
      remarks: values.remarks || null,
      currencyCode: selectedBook?.currencyCode || null,
      exchangeRate: 1,
      settlementId: id || null, isUpdate: !!id,
      partyType: selectedParty.partyType, partyId: selectedParty.partyId,
      cashReturned: cashR,
      voucherId: selectedVoucherId || null,
      lines: selectedVoucherId ? [] : lines,
      allocations,
    });
    if (success) {
      setWorkflowStatus(data?.workflowStatus ?? null);
      MessageBoxService.show({
        message: 'Settlement saved.',
        type: 'success',
        onClose: () => {
          if (config.features.returnToListAfterSave) {
            navigate('/petty-cash/settlement');
          } else if (!id && data?.settlementId) {
            navigate(`/petty-cash/settlement/edit/${data.settlementId}`);
          }
        },
      });
    }
  }

  const handleClear = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Clear this settlement? It posts to the general ledger.',
      type: 'warning', confirmText: 'Clear', cancelText: 'Cancel',
    });
    if (!confirmed) return;
    const { success } = await ApiService.clear(id);
    if (success) {
      MessageBoxService.show({ message: 'Settlement cleared and posted.', type: 'success', onClose: () => navigate('/petty-cash/settlement') });
    }
  };

  const handleApprove = async () => {
    const { success, data } = await ApiService.act(id, 'Approve', actComment);
    if (success) {
      setWorkflowStatus(data?.workflowStatus ?? null);
      setActComment('');
      MessageBoxService.show({ message: 'Settlement approved.', type: 'success' });
    }
  };

  const handleRejectClick = () => {
    setShowRejectInput(true);
    setActComment('');
  };

  const handleRejectConfirm = async () => {
    if (!actComment.trim()) return;
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Reject this settlement?',
      type: 'danger', confirmText: 'Reject', cancelText: 'Back',
    });
    if (!confirmed) return;
    const { success, data } = await ApiService.act(id, 'Reject', actComment);
    if (success) {
      setWorkflowStatus(data?.workflowStatus ?? null);
      setShowRejectInput(false);
      setActComment('');
      MessageBoxService.show({ message: 'Settlement rejected.', type: 'success' });
    }
  };

  const handleCancel = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Cancel this settlement? Any posting is voided.',
      type: 'danger', confirmText: 'Cancel Settlement', cancelText: 'Back',
    });
    if (!confirmed) return;
    const { success } = await ApiService.cancel(id);
    if (success) {
      MessageBoxService.show({ message: 'Settlement cancelled.', type: 'success', onClose: () => navigate('/petty-cash/settlement') });
    }
  };

  // Allocation rows: live IOUs while drafting, the saved rows afterwards.
  const allocationRows = isDraft
    ? partyIous
    : (savedView?.allocations || []).map((a) => ({
        iouId: a.iouId, iouNo: a.iouNo, requestAmount: a.requestAmount,
        advanceOutstanding: null, saved: a.allocatedAmount,
      }));

  return (
    <MeridianPage
      title={`${id ? 'Edit' : 'New'} ${menuLabel}`}
      subtitle={settlementNo || null}
      backTo="/petty-cash/settlement"
      cardClass="ml-form-card"
      actions={
        <>
          {canCancel && (
            <PermissionGate codes="pc-settlement-cancel">
              <button type="button" className="ml-btn-ghost ml-btn-danger-ghost ml-fab-1" onClick={handleCancel}>
                <i className="bi bi-x-circle" aria-hidden="true" />
                Cancel
              </button>
            </PermissionGate>
          )}
          {canClear && (
            <PermissionGate codes="pc-settlement-clear">
              <button type="button" className="ml-btn-ghost ml-fab-2" onClick={handleClear}>
                <i className="bi bi-check2-square" aria-hidden="true" />
                Clear
              </button>
            </PermissionGate>
          )}
          {isDraft && (
            <PermissionGate codes={id ? 'pc-settlement-update' : 'pc-settlement-save'}>
              <button type="submit" form="settlement-form" className="ml-btn-action ml-fab" disabled={uiData.loading}>
                <i className="bi bi-check-lg" aria-hidden="true" />
                Save
              </button>
            </PermissionGate>
          )}
        </>
      }
    >
      <form id="settlement-form" onSubmit={formik.handleSubmit}>
        <div className="ml-form-section">
          <div className="row g-2">
            <div className="col-sm-3">
              <label htmlFor="cashBookPick" className="form-label">Cash Book</label>
              {isDraft ? (
                <select
                  id="cashBookPick"
                  className="form-select"
                  value={cashBookId}
                  onChange={(e) => handleCashBookPick(e.target.value)}
                >
                  <option value="">Select cash book...</option>
                  {uiData.cashBooks.map((b) => (
                    <option key={b.cashBookId} value={b.cashBookId}>{b.code} - {b.name}</option>
                  ))}
                </select>
              ) : (
                <div className="form-control-plaintext fw-bold">{selectedBook?.code || '-'}</div>
              )}
            </div>
            <div className="col-sm-2">
              <label className="form-label text-muted small">Currency</label>
              <div className="form-control-plaintext fw-bold">{selectedBook?.currencyCode || '-'}</div>
            </div>
            <div className="col-sm-3">
              <label htmlFor="partyPick" className="form-label">Party</label>
              {isDraft ? (
                <select
                  id="partyPick"
                  className="form-select"
                  value={partyId}
                  disabled={!selectedCashBookId}
                  onChange={(e) => handlePartyPick(e.target.value)}
                >
                  <option value="">{selectedCashBookId ? 'Select party...' : 'Select a cash book first'}</option>
                  {partyOptions.map((p) => (
                    <option key={p.partyId} value={p.partyId}>
                      {`${p.name || p.partyId}${p.outstanding > 0 ? ` - Outstanding ${p.outstanding.toLocaleString()}` : ''}`}
                    </option>
                  ))}
                </select>
              ) : (
                <div className="form-control-plaintext fw-bold">{savedView?.header?.partyName || '-'}</div>
              )}
            </div>
            <InputField {...fields.settlementDate} formik={formik} className="col-sm-2" />
            <div className="col-sm-2">
              <label htmlFor="cashReturned" className="form-label">Cash Returned</label>
              <input
                id="cashReturned" type="number" min="0" step="0.01"
                className="form-control" value={cashReturned}
                disabled={!isDraft}
                onChange={(e) => setCashReturned(e.target.value)}
              />
            </div>
            <InputField {...fields.remarks} formik={formik} disabled={!isDraft} />
          </div>
        </div>

        {(allocationRows.length > 0 || !isDraft) && (
          <div className="ml-form-section mt-3">
            <div className="d-flex justify-content-between align-items-center mb-2">
              <h6 className="mb-0">IOU Allocations</h6>
              {isDraft && partyIous.length > 0 && (
                <button type="button" className="btn btn-sm btn-outline-primary" onClick={autoAllocate}>
                  <i className="bi bi-magic" aria-hidden="true" /> Auto Allocate
                </button>
              )}
            </div>
            <div className="table-responsive">
              <table className="table table-sm align-middle mb-0">
                <thead className="table-light">
                  <tr>
                    <th>IOU</th>
                    <th className="text-end">Advance</th>
                    <th className="text-end">Outstanding</th>
                    <th className="text-end" style={{ width: 180 }}>Allocate</th>
                  </tr>
                </thead>
                <tbody>
                  {allocationRows.map((i) => (
                    <tr key={i.iouId}>
                      <td>{i.iouNo}</td>
                      <td className="text-end">{Number(i.requestAmount || 0).toLocaleString()}</td>
                      <td className="text-end">{i.advanceOutstanding != null ? Number(i.advanceOutstanding).toLocaleString() : '-'}</td>
                      <td className="text-end">
                        {isDraft ? (
                          <input
                            type="number" min="0" step="0.01"
                            className="form-control form-control-sm text-end"
                            value={allocs[i.iouId] ?? ''}
                            onChange={(e) => setAllocs({ ...allocs, [i.iouId]: e.target.value })}
                          />
                        ) : (
                          Number(i.saved || 0).toLocaleString()
                        )}
                      </td>
                    </tr>
                  ))}
                  {allocationRows.length === 0 && (
                    <tr><td colSpan={4} className="text-muted">No open IOUs for this party in this cash book. Bills below are paid directly.</td></tr>
                  )}
                </tbody>
              </table>
            </div>
            {allocProblems.length > 0 && (
              <div className="text-danger small mt-1">Allocation exceeds outstanding on {allocProblems.join(', ')}.</div>
            )}
          </div>
        )}

        <div className="ml-form-section mt-3">
          <h6 className="mb-2">Bills</h6>
          {selectedParty && eligibleVouchers.length > 0 && isDraft && (
            <div className="mb-2">
              <label htmlFor="voucherPick" className="form-label">Settle with Petty Cash Request</label>
              <select
                id="voucherPick"
                className="form-select form-select-sm"
                value={selectedVoucherId}
                onChange={(e) => handleVoucherPick(e.target.value)}
              >
                <option value="">None (enter bills manually)</option>
                {eligibleVouchers.map((v) => (
                  <option key={v.voucherId} value={v.voucherId}>
                    {`${v.voucherNo} - ${v.payeeName || ''} - ${Number(v.totalAmount).toLocaleString()}`}
                  </option>
                ))}
              </select>
              <div className="form-text">
                The request's bill lines become this settlement. On clear, the request is marked Settled and is not paid separately.
              </div>
            </div>
          )}

          {selectedVoucherId ? (
            <table className="table table-sm mb-0">
              <thead className="table-light">
                <tr><th>Category</th><th>Description</th><th className="text-end">Amount</th></tr>
              </thead>
              <tbody>
                {lineItems.map((l, i) => (
                  <tr key={i}>
                    <td>{uiData.categories.find((c) => c.categoryId === l.categoryId)?.name || '-'}</td>
                    <td>{l.description || '-'}</td>
                    <td className="text-end">{toNum(l.amount).toLocaleString()}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          ) : (
            <div className="row g-2">
              <DataGrid ref={gridRef} initialItems={lineItems} columns={lineColumns} onItemsChange={setLineItems} />
            </div>
          )}
        </div>

        {(totalBills > 0 || cashR > 0 || totalAllocated > 0) && (
          <div className="ml-form-section mt-3">
            <div className="row g-2">
              <div className="col-sm-3">
                <label className="form-label text-muted small">Total Bills</label>
                <div className="form-control-plaintext fw-bold">{totalBills.toLocaleString()}</div>
              </div>
              <div className="col-sm-3">
                <label className="form-label text-muted small">Cash Returned</label>
                <div className="form-control-plaintext text-success fw-bold">{cashR.toLocaleString()}</div>
              </div>
              <div className="col-sm-3">
                <label className="form-label text-muted small">Allocated to IOUs</label>
                <div className="form-control-plaintext fw-bold">{totalAllocated.toLocaleString()}</div>
              </div>
              <div className="col-sm-3">
                <label className="form-label text-muted small">Extra to Pay Party</label>
                <div className={`form-control-plaintext fw-bold ${extraPaid > 0 ? 'text-danger' : ''}`}>
                  {Math.max(extraPaid, 0).toLocaleString()}
                </div>
              </div>
            </div>
            {extraPaid < 0 && (
              <div className="text-danger small">Allocations exceed bills plus cash returned by {Math.abs(extraPaid).toLocaleString()}.</div>
            )}
            {bothWays && (
              <div className="text-danger small">Cannot both return cash and pay extra. Reduce cash returned.</div>
            )}
          </div>
        )}
      </form>

      {id && workflowStatus && (
        <div className="ml-form-section mt-3">
          <div className="d-flex align-items-center gap-2 mb-2">
            <span className="text-muted">Approval:</span>
            <span className={`ml-badge ${WF_BADGE[workflowStatus] || 'ml-badge-locked'}`}>{workflowStatus}</span>
            <button type="button" className="btn btn-outline-secondary btn-sm btn-borderless ms-2"
              onClick={() => setShowHistory((v) => !v)} title="Approval history">
              <i className="bi bi-clock-history" />
            </button>
          </div>

          {canAct && (
            <PermissionGate codes="pc-settlement-approve">
              <div className="d-flex gap-2 flex-wrap">
                <button type="button" className="btn btn-outline-success btn-sm" onClick={handleApprove}>
                  <i className="bi bi-check2-all" aria-hidden="true" /> Approve
                </button>
                {!showRejectInput ? (
                  <button type="button" className="btn btn-outline-danger btn-sm" onClick={handleRejectClick}>
                    <i className="bi bi-x-circle" aria-hidden="true" /> Reject
                  </button>
                ) : (
                  <div className="d-flex gap-2 align-items-center">
                    <input
                      type="text" className="form-control form-control-sm" style={{ width: '220px' }}
                      placeholder="Rejection reason..." value={actComment}
                      onChange={(e) => setActComment(e.target.value)}
                    />
                    <button type="button" className="btn btn-danger btn-sm" onClick={handleRejectConfirm}
                      disabled={!actComment.trim()}>
                      Confirm
                    </button>
                    <button type="button" className="btn btn-outline-secondary btn-sm"
                      onClick={() => setShowRejectInput(false)}>
                      Cancel
                    </button>
                  </div>
                )}
              </div>
            </PermissionGate>
          )}
        </div>
      )}

      {showHistory && (
        <ApprovalHistory docType="PSET" docId={id} label={savedView?.header?.docNo || id}
          onClose={() => setShowHistory(false)} />
      )}
    </MeridianPage>
  );
}
