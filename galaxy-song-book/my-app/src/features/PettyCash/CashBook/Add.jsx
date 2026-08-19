import * as Yup from 'yup';
import { useParams, useNavigate } from 'react-router-dom';
import { useEffect, useState } from 'react';
import InputField from '../../../components/InputField';
import { useFormikBuilder } from '../../../helpers/formikBuilder';
import { todayISO, formatDate } from '../../../helpers/transformDateFields';
import DateInput from '../../../components/DateInput';
import ApiService from './service';
import MessageBoxService from '../../../services/MessageBoxService';
import PermissionGate from '../../../components/PermissionGate';
import MeridianPage from '../../Meridian/MeridianPage';
import useMenuLabel from '../../../helpers/useMenuLabel';

import config from '../../../config/config';

export default function AddCashBook() {
  const { id } = useParams();
  const navigate = useNavigate();
  const menuLabel = useMenuLabel('/petty-cash/cash-book', 'Cash Book');
  const [uiData, setUiData] = useState({ loading: true, cashiers: [], currencies: [], accounts: [], branches: [] });
  const [book, setBook] = useState(null);
  const [floatAmount, setFloatAmount] = useState('');
  const [contraAccountId, setContraAccountId] = useState('');
  const [floatDate, setFloatDate] = useState(todayISO());
  const statusOptions = [
    { code: 'Active', name: 'Active' },
    { code: 'Inactive', name: 'Inactive' },
    { code: 'Suspended', name: 'Suspended' },
  ];

  const fields = {
    code: {
      name: 'code', type: 'text', placeholder: 'Code', initialValue: '',
      validation: Yup.string().required('Code is required'), className: 'col-sm-6',
    },
    name: {
      name: 'name', type: 'text', placeholder: 'Name', initialValue: '',
      validation: Yup.string().required('Name is required'), className: 'col-sm-6',
    },
    cashierUserId: {
      name: 'cashierUserId', type: 'select', placeholder: 'Cashier', initialValue: '',
      dataBinding: { data: uiData.cashiers, keyField: 'userId', valueField: 'fullName' },
      validation: Yup.string().required('Cashier is required'), className: 'col-sm-6',
    },
    currencyCode: {
      name: 'currencyCode', type: 'select', placeholder: 'Currency', initialValue: '',
      dataBinding: { data: uiData.currencies, keyField: 'currencyCode', valueField: 'currencyName' },
      validation: Yup.string().required('Currency is required'), className: 'col-sm-6',
    },
    glAccountId: {
      name: 'glAccountId', type: 'select', placeholder: 'GL Account', initialValue: '',
      dataBinding: { data: uiData.accounts, keyField: 'accountId', valueField: 'accountName' },
      validation: Yup.string().required('GL account is required'), className: 'col-sm-6',
    },
    branchOrgUnitId: {
      name: 'branchOrgUnitId', type: 'select', placeholder: 'Branch', initialValue: '',
      dataBinding: { data: uiData.branches, keyField: 'orgUnitId', valueField: 'name' }, className: 'col-sm-6',
    },
    minFloat: {
      name: 'minFloat', type: 'amount', placeholder: 'Min Daily Float', initialValue: 0, className: 'col-sm-6',
    },
    maxFloat: {
      name: 'maxFloat', type: 'amount', placeholder: 'Max Daily Float', initialValue: 0, className: 'col-sm-6',
    },
    iouClosingDays: {
      name: 'iouClosingDays', type: 'number', placeholder: 'IOU Closing Period (days)', initialValue: 0, className: 'col-sm-6',
    },
    status: {
      name: 'status', type: 'select', placeholder: 'Status', initialValue: 'Active',
      dataBinding: { data: statusOptions, keyField: 'code', valueField: 'name' }, validation: Yup.string().required('Status is required'), className: 'col-sm-6',
    },
    remarks: {
      name: 'remarks', type: 'textarea', placeholder: 'Remarks', initialValue: '', className: 'col-12',
    },
  };

  useEffect(() => {
    const init = async () => {
      const { success, data } = await ApiService.getUi();
      setUiData({
        loading: false,
        cashiers: success ? data.cashiers || [] : [],
        currencies: success ? data.currencies || [] : [],
        accounts: success ? data.accounts || [] : [],
        branches: success ? data.branches || [] : [],
      });
      if (id) {
        const res = await ApiService.get(id);
        if (res.success && res.data) {
          formik.setValues({ ...res.data });
          setBook(res.data);
          setFloatAmount(res.data.maxFloat ? String(res.data.maxFloat) : '');
        }
      }
    };
    init();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [id]);

  const handleSubmit = async (values, { resetForm }) => {
    const { success, data } = await ApiService.update({
      ...values,
      // Keep the existing float fields in sync so top-up and alert logic works.
      maxFloat: values.maxFloat,
      minFloat: values.minFloat,
      floatLimit: values.maxFloat,
      topUpThreshold: values.minFloat,
      cashBookId: id || null,
      isUpdate: !!id,
    });
    if (success) {
      MessageBoxService.show({
        message: 'Cash book saved successfully!',
        type: 'success',
        onClose: () => {
          if (config.features.returnToListAfterSave) {
            navigate('/petty-cash/cash-book');
          } else if (!id && data?.cashBookId) {
            navigate(`/petty-cash/cash-book/edit/${data.cashBookId}`);
          } else if (!id) {
            resetForm();
          }
        },
      });
    }
  };

  const handleDelete = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Delete this cash book?',
      type: 'danger',
      confirmText: 'Delete',
      cancelText: 'Cancel',
    });
    if (!confirmed) return;
    const { success } = await ApiService.delete({ id });
    if (success) {
      MessageBoxService.show({
        message: 'Cash book deleted.',
        type: 'success',
        onClose: () => navigate('/petty-cash/cash-book'),
      });
    }
  };

  const formik = useFormikBuilder(fields, handleSubmit);

  const isEstablished = !!book?.establishGlTransactionId;

  const handleEstablish = async () => {
    const amt = Number(String(floatAmount).replace(/[^\d.]/g, '')) || 0;
    if (amt <= 0) {
      MessageBoxService.show({ message: 'Enter a float amount greater than zero.', type: 'danger' });
      return;
    }
    if (!contraAccountId) {
      MessageBoxService.show({ message: 'Select the contra (bank / equity) account.', type: 'danger' });
      return;
    }
    const confirmed = await MessageBoxService.confirmAsync({
      message: `Establish float of ${amt.toLocaleString()}? This posts an opening entry to the ledger.`,
      type: 'primary', confirmText: 'Establish', cancelText: 'Cancel',
    });
    if (!confirmed) return;
    const { success, data } = await ApiService.establishFloat({
      cashBookId: id, amount: amt, bankGlAccountId: contraAccountId, date: floatDate,
    });
    if (success) {
      setBook(data);
      MessageBoxService.show({ message: 'Float established and posted.', type: 'success' });
    }
  };

  const handleReverseFloat = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Reverse the float? The opening entry is voided.',
      type: 'danger', confirmText: 'Reverse', cancelText: 'Back',
    });
    if (!confirmed) return;
    const { success } = await ApiService.reverseFloat(id);
    if (success) {
      const res = await ApiService.get(id);
      if (res.success) setBook(res.data);
      MessageBoxService.show({ message: 'Float reversed.', type: 'success' });
    }
  };

  return (
    <MeridianPage
      title={`${id ? 'Edit' : 'New'} ${menuLabel}`}
      backTo="/petty-cash/cash-book"
      cardClass="ml-form-card"
      actions={
        <>
          {id && (
            <PermissionGate codes="pc-cash-book-delete">
              <button type="button" className="ml-btn-ghost ml-btn-danger-ghost ml-fab-1" onClick={handleDelete}>
                <i className="bi bi-trash" aria-hidden="true" />
                Delete
              </button>
            </PermissionGate>
          )}
          <PermissionGate codes={id ? 'pc-cash-book-update' : 'pc-cash-book-save'}>
            <button type="submit" form="cashbook-form" className="ml-btn-action ml-fab" disabled={uiData.loading}>
              <i className="bi bi-check-lg" aria-hidden="true" />
              Save
            </button>
          </PermissionGate>
        </>
      }
    >
      <form id="cashbook-form" onSubmit={formik.handleSubmit}>
        <div className="ml-form-section">
          <div className="row g-2">
            <InputField {...fields.code} formik={formik} />
            <InputField {...fields.name} formik={formik} />
            <InputField {...fields.cashierUserId} formik={formik} />
            <InputField {...fields.currencyCode} formik={formik} />
            <InputField {...fields.glAccountId} formik={formik} />
            <InputField {...fields.branchOrgUnitId} formik={formik} />
            <InputField {...fields.minFloat} formik={formik} />
            <InputField {...fields.maxFloat} formik={formik} />
            <InputField {...fields.iouClosingDays} formik={formik} />
            <InputField {...fields.status} formik={formik} />
            <InputField {...fields.remarks} formik={formik} />
          </div>
        </div>
      </form>

      {id && (
        <div className="ml-form-section mt-3">
          <h6 className="mb-2">Float</h6>
          {isEstablished ? (
            <div className="row g-2 align-items-end">
              <div className="col-sm-4">
                <label className="form-label text-muted small">Established Float</label>
                <div className="form-control-plaintext fw-bold">{Number(book.establishedFloat || 0).toLocaleString()}</div>
              </div>
              <div className="col-sm-4">
                <label className="form-label text-muted small">Established On</label>
                <div className="form-control-plaintext">{book.establishedAt ? formatDate(book.establishedAt) : '-'}</div>
              </div>
              <div className="col-sm-4">
                <PermissionGate codes="pc-cash-book-save">
                  <button type="button" className="btn btn-outline-danger btn-sm" onClick={handleReverseFloat}>
                    <i className="bi bi-arrow-counterclockwise me-1" />
                    Reverse Float
                  </button>
                </PermissionGate>
              </div>
            </div>
          ) : (
            <>
              <p className="text-muted small mb-2">
                Fund the cash book once so the ledger reflects real cash. Posts Dr Petty Cash / Cr the contra account.
              </p>
              <div className="row g-2 align-items-end">
                <div className="col-sm-3">
                  <label htmlFor="floatAmount" className="form-label">Amount</label>
                  <input id="floatAmount" type="number" min="0" step="0.01" className="form-control"
                    value={floatAmount} onChange={(e) => setFloatAmount(e.target.value)} />
                </div>
                <div className="col-sm-4">
                  <label htmlFor="contraAccount" className="form-label">Contra (Bank / Equity)</label>
                  <select id="contraAccount" className="form-select"
                    value={contraAccountId} onChange={(e) => setContraAccountId(e.target.value)}>
                    <option value="">Select account...</option>
                    {uiData.accounts
                      .filter((a) => a.accountId !== formik.values.glAccountId)
                      .map((a) => (
                        <option key={a.accountId} value={a.accountId}>{`${a.accountCode} - ${a.accountName}`}</option>
                      ))}
                  </select>
                </div>
                <div className="col-sm-3">
                  <label htmlFor="floatDate" className="form-label">Date</label>
                  <DateInput id="floatDate" name="floatDate"
                    value={floatDate} onChange={(e) => setFloatDate(e.target.value)} />
                </div>
                <div className="col-sm-2">
                  <PermissionGate codes="pc-cash-book-save">
                    <button type="button" className="btn btn-primary w-100" onClick={handleEstablish}>
                      <i className="bi bi-cash-stack me-1" />
                      Establish
                    </button>
                  </PermissionGate>
                </div>
              </div>
            </>
          )}
        </div>
      )}
    </MeridianPage>
  );
}
