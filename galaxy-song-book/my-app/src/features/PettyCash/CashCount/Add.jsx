import { useEffect, useRef, useState, useMemo } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import * as Yup from 'yup';
import InputField from '../../../components/InputField';
import { DataGrid } from '../../../components/DataGrid';
import { todayISO } from '../../../helpers/transformDateFields';
import { useFormikBuilder } from '../../../helpers/formikBuilder';
import MessageBoxService from '../../../services/MessageBoxService';
import PermissionGate from '../../../components/PermissionGate';
import MeridianPage from '../../Meridian/MeridianPage';
import ApiService from './service';
import config from '../../../config/config';
import useMenuLabel from '../../../helpers/useMenuLabel';

import STATUS_CLASS from '../../../helpers/statusBadge';

const toNum = (v) => Number(String(v ?? '').replace(/[^\d.]/g, '')) || 0;

function round2(n) {
  return Math.round((Number(n) + Number.EPSILON) * 100) / 100;
}

export default function AddCashCount() {
  const { id } = useParams();
  const navigate = useNavigate();
  const menuLabel = useMenuLabel('/petty-cash/cash-count', 'Cash Count');
  const gridRef = useRef();
  const [denomLines, setDenomLines] = useState([]);
  const [status, setStatus] = useState(null);
  const [record, setRecord] = useState(null);
  const [uiData, setUiData] = useState({ loading: true, cashBooks: [] });

  // Live computed totals from denomination lines.
  const physicalTotal = useMemo(() => {
    return round2(denomLines.reduce((sum, d) => sum + toNum(d.denomination) * toNum(d.count), 0));
  }, [denomLines]);

  const systemBalance = useMemo(() => toNum(record?.systemBalance ?? 0), [record]);
  const variance = useMemo(() => round2(physicalTotal - systemBalance), [physicalTotal, systemBalance]);

  const fields = useMemo(() => ({
    cashBookId: {
      name: 'cashBookId', type: 'select', placeholder: 'Cash Book', initialValue: '',
      dataBinding: { data: uiData.cashBooks, keyField: 'cashBookId', valueField: 'code' },
      validation: Yup.string().required('Cash book is required'), className: 'col-sm-4',
    },
    countDate: {
      name: 'countDate', type: 'date', placeholder: 'Count Date',
      initialValue: todayISO(),
      validation: Yup.string().required('Count date is required'), className: 'col-sm-4',
    },
    reason: {
      name: 'reason', type: 'text', placeholder: 'Reason / Notes', initialValue: '', className: 'col-sm-4',
    },
    photoPath: {
      name: 'photoPath', type: 'text', placeholder: 'Photo Path', initialValue: '', className: 'col-sm-4',
    },
    systemBalance_display: {
      name: 'systemBalance_display', type: 'text', placeholder: 'System Balance', initialValue: '',
      disabled: true, className: 'col-sm-4',
    },
    physicalTotal_display: {
      name: 'physicalTotal_display', type: 'text', placeholder: 'Physical Total', initialValue: '',
      disabled: true, className: 'col-sm-4',
    },
    variance_display: {
      name: 'variance_display', type: 'text', placeholder: 'Variance', initialValue: '',
      disabled: true, className: 'col-sm-4',
    },
  }), [uiData]);

  const denomColumns = [
    {
      header: 'Denomination', field: 'denomination', type: 'amount', placeholder: '0.00', width: '30%',
    },
    {
      header: 'Count', field: 'count', type: 'number', placeholder: '0', width: '30%',
    },
    {
      header: 'Line Total', field: 'lineTotal', type: 'amount', placeholder: '0.00', readOnly: true, width: '40%',
    },
  ];

  const formik = useFormikBuilder(fields, handleSubmit);

  // On change, recompute line totals and provide to grid via getRowClass.
  useEffect(() => {
    const updated = denomLines.map((d) => ({
      ...d,
      lineTotal: round2(toNum(d.denomination) * toNum(d.count)),
    }));
    // Only update if values actually changed to avoid infinite loops.
    const changed = updated.some((u, i) => u.lineTotal !== (denomLines[i]?.lineTotal));
    if (changed) setDenomLines(updated);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [denomLines.map((d) => `${d.denomination}_${d.count}`).join('|')]);

  // Keep display fields in sync.
  useEffect(() => {
    formik.setFieldValue('systemBalance_display', systemBalance ? systemBalance.toLocaleString(undefined, { minimumFractionDigits: 2 }) : '');
    formik.setFieldValue('physicalTotal_display', physicalTotal ? physicalTotal.toLocaleString(undefined, { minimumFractionDigits: 2 }) : '');
    const v = variance;
    const sign = v > 0 ? '+' : v < 0 ? '-' : '';
    formik.setFieldValue('variance_display', v !== 0 ? `${sign}${Math.abs(v).toLocaleString(undefined, { minimumFractionDigits: 2 })}` : '0.00');
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [physicalTotal, systemBalance, variance]);

  useEffect(() => {
    const init = async () => {
      const { success, data } = await ApiService.getUi();
      setUiData({
        loading: false,
        cashBooks: success ? data.cashBooks || [] : [],
      });
      if (id) {
        const res = await ApiService.get(id);
        if (res.success && res.data) {
          const { denominations, ...header } = res.data;
          setRecord(header);
          setStatus(header.status);
          formik.setValues({
            cashBookId: header.cashBookId ?? '',
            countDate: (header.countDate || '').split('T')[0],
            reason: header.reason ?? '',
            photoPath: header.photoPath ?? '',
            systemBalance_display: '',
            physicalTotal_display: '',
            variance_display: '',
          });
          const lines = (denominations || []).map((d) => ({
            denomination: d.denomination,
            count: d.count,
            lineTotal: d.lineTotal,
          }));
          setDenomLines(lines);
          gridRef.current?.reset(lines);
        }
      }
    };
    init();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [id]);

  // Compute system balance from cash book selection for new records.
  useEffect(() => {
    if (!id && formik.values.cashBookId) {
      const book = uiData.cashBooks.find((b) => String(b.cashBookId) === String(formik.values.cashBookId));
      if (book) {
        formik.setFieldValue('systemBalance_display', `Cash book: ${book.code} — balance computed on save`);
      }
    } else if (id && record) {
      formik.setFieldValue('systemBalance_display', record.systemBalance?.toLocaleString(undefined, { minimumFractionDigits: 2 }) ?? '');
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [formik.values.cashBookId, id, record, uiData.cashBooks]);

  async function handleSubmit(values) {
    const { systemBalance_display, physicalTotal_display, variance_display, ...payload } = values;
    const lines = denomLines
      .filter((d) => toNum(d.denomination) > 0)
      .map((d, i) => ({
        lineNo: i + 1,
        denomination: toNum(d.denomination),
        count: Math.round(toNum(d.count)),
      }));
    const { success, data } = await ApiService.update({
      ...payload,
      cashCountId: id || null,
      isUpdate: !!id,
      denominations: lines,
    });
    if (success) {
      MessageBoxService.show({
        message: 'Cash count saved.',
        type: 'success',
        onClose: () => {
          if (config.features.returnToListAfterSave) {
            navigate('/petty-cash/cash-count');
          } else if (!id && data?.cashCountId) {
            navigate(`/petty-cash/cash-count/edit/${data.cashCountId}`);
          }
        },
      });
    }
  }

  const handleSign = async () => {
    const { success } = await ApiService.sign(id);
    if (success) {
      MessageBoxService.show({ message: 'Cash count signed.', type: 'success', onClose: () => navigate('/petty-cash/cash-count') });
    }
  };

  const handleCountersign = async () => {
    const hasVariance = Math.abs(Number(record?.variance || 0)) > 0.005;
    const message = hasVariance
      ? 'Countersign this cash count? A variance entry will be posted to the general ledger.'
      : 'Countersign this cash count? No variance to post.';
    const confirmed = await MessageBoxService.confirmAsync({
      message, type: 'warning', confirmText: 'Countersign', cancelText: 'Cancel',
    });
    if (!confirmed) return;
    const { success } = await ApiService.countersign(id);
    if (success) {
      MessageBoxService.show({ message: 'Cash count countersigned.', type: 'success', onClose: () => navigate('/petty-cash/cash-count') });
    }
  };

  const handleAudit = async () => {
    const { success } = await ApiService.audit(id);
    if (success) {
      MessageBoxService.show({ message: 'Cash count audited.', type: 'success', onClose: () => navigate('/petty-cash/cash-count') });
    }
  };

  const handleCancel = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Cancel this cash count? Any posting is voided.',
      type: 'danger', confirmText: 'Cancel Count', cancelText: 'Back',
    });
    if (!confirmed) return;
    const { success } = await ApiService.cancel(id);
    if (success) {
      MessageBoxService.show({ message: 'Cash count cancelled.', type: 'success', onClose: () => navigate('/petty-cash/cash-count') });
    }
  };

  const isDraft = !id || status === 'Draft';
  const isSigned = status === 'Signed';
  const isCountersigned = status === 'Countersigned';
  const canCancel = id && !['Audited', 'Cancelled'].includes(status);

  return (
    <MeridianPage
      title={`${id ? 'Edit' : 'New'} ${menuLabel}`}
      backTo="/petty-cash/cash-count"
      cardClass="ml-form-card"
      actions={
        <>
          {canCancel && (
            <PermissionGate codes="pc-cash-count-cancel">
              <button type="button" className="ml-btn-ghost ml-btn-danger-ghost ml-fab-1" onClick={handleCancel}>
                <i className="bi bi-x-circle" aria-hidden="true" />
                Cancel
              </button>
            </PermissionGate>
          )}
          {isCountersigned && (
            <PermissionGate codes="pc-cash-count-audit">
              <button type="button" className="ml-btn-ghost ml-fab-2" onClick={handleAudit}>
                <i className="bi bi-check2-all" aria-hidden="true" />
                Audit
              </button>
            </PermissionGate>
          )}
          {isSigned && (
            <PermissionGate codes="pc-cash-count-countersign">
              <button type="button" className="ml-btn-ghost ml-fab-3" onClick={handleCountersign}>
                <i className="bi bi-check2-square" aria-hidden="true" />
                Countersign
              </button>
            </PermissionGate>
          )}
          {isDraft && id && (
            <PermissionGate codes="pc-cash-count-sign">
              <button type="button" className="ml-btn-ghost ml-fab-4" onClick={handleSign}>
                <i className="bi bi-shield-check" aria-hidden="true" />
                Sign
              </button>
            </PermissionGate>
          )}
          {isDraft && (
            <PermissionGate codes={id ? 'pc-cash-count-update' : 'pc-cash-count-save'}>
              <button type="submit" form="cash-count-form" className="ml-btn-action ml-fab" disabled={uiData.loading}>
                <i className="bi bi-check-lg" aria-hidden="true" />
                Save
              </button>
            </PermissionGate>
          )}
        </>
      }
    >
      {status && (
        <div className="mb-3">
          <span className={`ml-badge ${STATUS_CLASS[status] || 'ml-badge-locked'}`}>{status}</span>
        </div>
      )}
      <form id="cash-count-form" onSubmit={formik.handleSubmit}>
        <div className="ml-form-section">
          <div className="row g-2">
            <InputField {...fields.cashBookId} formik={formik} />
            <InputField {...fields.countDate} formik={formik} />
            <InputField {...fields.reason} formik={formik} />
            <InputField {...fields.photoPath} formik={formik} />
            <InputField {...fields.systemBalance_display} formik={formik} />
            <InputField {...fields.physicalTotal_display} formik={formik} />
            <InputField {...fields.variance_display} formik={formik} />
          </div>
        </div>
        <div className="ml-form-section">
          <h6 className="ml-form-section-title">Denominations</h6>
          <DataGrid
            ref={gridRef}
            columns={denomColumns}
            data={denomLines}
            onDataChange={(data) => setDenomLines(data)}
            allowAdd={isDraft}
            allowDelete={isDraft}
            placeholder="Add denomination..."
          />
        </div>
      </form>
    </MeridianPage>
  );
}
