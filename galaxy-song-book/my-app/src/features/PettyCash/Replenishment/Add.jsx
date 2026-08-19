import { useEffect, useState, useMemo } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import * as Yup from 'yup';
import InputField from '../../../components/InputField';
import { useFormikBuilder } from '../../../helpers/formikBuilder';
import MessageBoxService from '../../../services/MessageBoxService';
import PermissionGate from '../../../components/PermissionGate';
import MeridianPage from '../../Meridian/MeridianPage';
import ApiService from './service';
import config from '../../../config/config';
import ApprovalHistory from '../../Workflow/MyApprovals/ApprovalHistory';
import useMenuLabel from '../../../helpers/useMenuLabel';

import STATUS_CLASS from '../../../helpers/statusBadge';

export default function AddReplenishment() {
  const { id } = useParams();
  const navigate = useNavigate();
  const menuLabel = useMenuLabel('/petty-cash/replenishment', 'Replenishment');
  const [status, setStatus] = useState(null);
  const [record, setRecord] = useState(null);
  const [showHistory, setShowHistory] = useState(false);
  const [uiData, setUiData] = useState({
    loading: true, cashBooks: [], bankAccounts: [],
  });

  const selectedBook = useMemo(() => {
    if (!record) return null;
    return uiData.cashBooks.find((b) => String(b.cashBookId) === String(record.cashBookId)) || null;
  }, [record, uiData.cashBooks]);

  const fields = useMemo(() => ({
    cashBookId: {
      name: 'cashBookId', type: 'select', placeholder: 'Cash Book', initialValue: '',
      dataBinding: { data: uiData.cashBooks, keyField: 'cashBookId', valueField: 'code' },
      validation: Yup.string().required('Cash book is required'), className: 'col-sm-4',
    },
    requestDate: {
      name: 'requestDate', type: 'date', placeholder: 'Request Date', initialValue: '',
      validation: Yup.string().required('Request date is required'), className: 'col-sm-4',
    },
    amountRequested: {
      name: 'amountRequested', type: 'number', placeholder: 'Amount', initialValue: '',
      validation: Yup.number().required('Amount is required').moreThan(0, 'Must be greater than zero'), className: 'col-sm-4',
    },
    bankGlAccountId: {
      name: 'bankGlAccountId', type: 'select', placeholder: 'Bank Account', initialValue: '',
      dataBinding: { data: uiData.bankAccounts, keyField: 'accountId', valueField: 'accountName' },
      className: 'col-sm-6',
    },
    bankTransferRef: {
      name: 'bankTransferRef', type: 'text', placeholder: 'Bank Transfer Ref', initialValue: '', className: 'col-sm-6',
    },
    periodFrom: {
      name: 'periodFrom', type: 'date', placeholder: 'Period From', initialValue: '', className: 'col-sm-4',
    },
    periodTo: {
      name: 'periodTo', type: 'date', placeholder: 'Period To', initialValue: '', className: 'col-sm-4',
    },
    currentBalance_display: {
      name: 'currentBalance_display', type: 'text', placeholder: 'Current Balance', initialValue: '',
      disabled: true, className: 'col-sm-4',
    },
    floatLimit_display: {
      name: 'floatLimit_display', type: 'text', placeholder: 'Float Limit', initialValue: '',
      disabled: true, className: 'col-sm-4',
    },
  }), [uiData]);

  async function handleSubmit(values) {
    const { currentBalance_display, floatLimit_display, ...payload } = values;
    const { success, data } = await ApiService.update({
      ...payload,
      replenishmentId: id || null,
      isUpdate: !!id,
    });
    if (success) {
      MessageBoxService.show({
        message: 'Replenishment saved.',
        type: 'success',
        onClose: () => {
          if (config.features.returnToListAfterSave) {
            navigate('/petty-cash/replenishment');
          } else if (!id && data?.replenishmentId) {
            navigate(`/petty-cash/replenishment/edit/${data.replenishmentId}`);
          }
        },
      });
    }
  }

  const formik = useFormikBuilder(fields, handleSubmit);

  // Load UI data and existing record on mount.
  useEffect(() => {
    const init = async () => {
      const { success, data } = await ApiService.getUi();
      setUiData({
        loading: false,
        cashBooks: success ? data.cashBooks || [] : [],
        bankAccounts: success ? data.bankAccounts || [] : [],
      });
      if (id) {
        const res = await ApiService.get(id);
        if (res.success && res.data) {
          setRecord(res.data);
          setStatus(res.data.status);
          formik.setValues({
            cashBookId: res.data.cashBookId ?? '',
            requestDate: (res.data.requestDate || '').split('T')[0],
            amountRequested: res.data.amountRequested ?? '',
            bankGlAccountId: res.data.bankGlAccountId ?? '',
            bankTransferRef: res.data.bankTransferRef ?? '',
            periodFrom: (res.data.periodFrom || '').split('T')[0],
            periodTo: (res.data.periodTo || '').split('T')[0],
            currentBalance_display: res.data.currentBalance ?? '',
            floatLimit_display: '',
          });
        }
      }
    };
    init();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [id]);

  // Derive float limit and current balance from the selected cash book.
  useEffect(() => {
    const book = uiData.cashBooks.find((b) => String(b.cashBookId) === String(formik.values.cashBookId));
    if (book) {
      formik.setFieldValue('floatLimit_display', book.floatLimit ?? '');
      if (!id) {
        formik.setFieldValue('currentBalance_display', 'Will compute on save');
      }
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [formik.values.cashBookId, uiData.cashBooks]);

  const handleVerify = async () => {
    const { success } = await ApiService.verify(id);
    if (success) {
      MessageBoxService.show({ message: 'Replenishment verified.', type: 'success', onClose: () => navigate('/petty-cash/replenishment') });
    }
  };

  const handleApprove = async () => {
    const { success } = await ApiService.approve(id);
    if (success) {
      MessageBoxService.show({ message: 'Replenishment approved.', type: 'success', onClose: () => navigate('/petty-cash/replenishment') });
    }
  };

  const handlePost = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Post this replenishment? It posts to the general ledger.',
      type: 'warning', confirmText: 'Post', cancelText: 'Cancel',
    });
    if (!confirmed) return;
    const { success } = await ApiService.post(id);
    if (success) {
      MessageBoxService.show({ message: 'Replenishment posted.', type: 'success', onClose: () => navigate('/petty-cash/replenishment') });
    }
  };

  const handleCancel = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Cancel this replenishment? Any posting is voided.',
      type: 'danger', confirmText: 'Cancel Replenishment', cancelText: 'Back',
    });
    if (!confirmed) return;
    const { success } = await ApiService.cancel(id);
    if (success) {
      MessageBoxService.show({ message: 'Replenishment cancelled.', type: 'success', onClose: () => navigate('/petty-cash/replenishment') });
    }
  };

  const isRequested = !id || status === 'Requested';
  const isVerified = status === 'Verified';
  const isApproved = status === 'Approved';
  const canCancel = id && !['Posted', 'Cancelled'].includes(status);

  // Update read-only display when record loads after book data is ready.
  useEffect(() => {
    if (record && selectedBook) {
      formik.setFieldValue('floatLimit_display', selectedBook.floatLimit ?? '');
      formik.setFieldValue('currentBalance_display', record.currentBalance ?? '');
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [selectedBook, record]);

  return (
    <MeridianPage
      title={`${id ? 'Edit' : 'New'} ${menuLabel}`}
      backTo="/petty-cash/replenishment"
      cardClass="ml-form-card"
      actions={
        <>
          {canCancel && (
            <PermissionGate codes="pc-replenishment-cancel">
              <button type="button" className="ml-btn-ghost ml-btn-danger-ghost ml-fab-1" onClick={handleCancel}>
                <i className="bi bi-x-circle" aria-hidden="true" />
                Cancel
              </button>
            </PermissionGate>
          )}
          {isApproved && (
            <PermissionGate codes="pc-replenishment-post">
              <button type="button" className="ml-btn-ghost ml-fab-2" onClick={handlePost}>
                <i className="bi bi-cash-coin" aria-hidden="true" />
                Post
              </button>
            </PermissionGate>
          )}
          {isVerified && (
            <PermissionGate codes="pc-replenishment-approve">
              <button type="button" className="ml-btn-ghost ml-fab-3" onClick={handleApprove}>
                <i className="bi bi-check2-square" aria-hidden="true" />
                Approve
              </button>
            </PermissionGate>
          )}
          {isRequested && id && (
            <PermissionGate codes="pc-replenishment-verify">
              <button type="button" className="ml-btn-ghost ml-fab-4" onClick={handleVerify}>
                <i className="bi bi-shield-check" aria-hidden="true" />
                Verify
              </button>
            </PermissionGate>
          )}
          {isRequested && (
            <PermissionGate codes={id ? 'pc-replenishment-update' : 'pc-replenishment-save'}>
              <button type="submit" form="replenishment-form" className="ml-btn-action ml-fab" disabled={uiData.loading}>
                <i className="bi bi-check-lg" aria-hidden="true" />
                Save
              </button>
            </PermissionGate>
          )}
        </>
      }
    >
      {status && (
        <div className="d-flex align-items-center gap-2 mb-3">
          <span className={`ml-badge ${STATUS_CLASS[status] || 'ml-badge-locked'}`}>{status}</span>
          <button type="button" className="btn btn-outline-secondary btn-sm btn-borderless" title="Approval history"
            onClick={() => setShowHistory((v) => !v)}>
            <i className="bi bi-clock-history" />
          </button>
        </div>
      )}
      <form id="replenishment-form" onSubmit={formik.handleSubmit}>
        <div className="ml-form-section">
          <div className="row g-2">
            <InputField {...fields.cashBookId} formik={formik} />
            <InputField {...fields.requestDate} formik={formik} />
            <InputField {...fields.amountRequested} formik={formik} />
            <InputField {...fields.bankGlAccountId} formik={formik} />
            <InputField {...fields.bankTransferRef} formik={formik} />
            <InputField {...fields.periodFrom} formik={formik} />
            <InputField {...fields.periodTo} formik={formik} />
            <InputField {...fields.currentBalance_display} formik={formik} />
            <InputField {...fields.floatLimit_display} formik={formik} />
          </div>
        </div>
      </form>

      {showHistory && (
        <ApprovalHistory docType="PRPL" docId={id} label={record?.docNo ? `PRPL/${record.docNo}` : id}
          onClose={() => setShowHistory(false)} />
      )}
    </MeridianPage>
  );
}
