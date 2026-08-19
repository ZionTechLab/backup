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
import useMenuLabel from '../../../helpers/useMenuLabel';

const toNum = (v) => Number(String(v ?? '').replace(/[^\d.]/g, '')) || 0;

export default function AddVoucher() {
  const { id } = useParams();
  const navigate = useNavigate();
  const menuLabel = useMenuLabel('/petty-cash/voucher', 'Voucher');
  const gridRef = useRef();
  const [lineItems, setLineItems] = useState([]);
  const [status, setStatus] = useState(null);
  const [uiData, setUiData] = useState({ loading: true, cashBooks: [], categories: [], parties: [], centers: [], partyTypes: [] });

  const fields = {
    cashBookId: {
      name: 'cashBookId', type: 'select', placeholder: 'Cash Book', initialValue: '',
      dataBinding: { data: uiData.cashBooks, keyField: 'cashBookId', valueField: 'code' },
      validation: Yup.string().required('Cash book is required'), className: 'col-sm-4',
    },
    voucherDate: {
      name: 'voucherDate', type: 'date', placeholder: 'Date',
      initialValue: todayISO(),
      validation: Yup.string().required('Date is required'), className: 'col-sm-5',
    },
    // currencyCode: {
    //   name: 'currencyCode', type: 'text', placeholder: 'Currency', initialValue: '',  className: 'col-sm-4',
    // },
    payeePartyType: {
      name: 'payeePartyType', type: 'select', placeholder: 'Party Type', initialValue: '',
      dataBinding: { data: uiData.partyTypes, keyField: 'value', valueField: 'label' },
      validation: Yup.string().required('Party type is required'), className: 'col-sm-4',
    },
    payeePartyId: {
      name: 'payeePartyId', type: 'select', placeholder: 'Party', initialValue: '',
      dataBinding: { data: uiData.parties, keyField: 'businessPartnerId', valueField: 'partnerName' },
      validation: Yup.string().required('Party is required'), className: 'col-sm-4',
    },
    payeeName: {
      name: 'payeeName', type: 'text', placeholder: 'Payee Name (display)', initialValue: '', className: 'col-sm-4',
    },
    payeeNic: {
      name: 'payeeNic', type: 'text', placeholder: 'NIC / Co.Reg', initialValue: '', className: 'col-sm-6',
    },
    costCenterCode: {
      name: 'costCenterCode', type: 'select', placeholder: 'Cost Center', initialValue: '',
      dataBinding: { data: uiData.centers, keyField: 'centerCode', valueField: 'centerName' }, className: 'col-sm-6',
    },
    jobNo: {
      name: 'jobNo', type: 'text', placeholder: 'Job No', initialValue: '', className: 'col-sm-6',
    },
    description: {
      name: 'description', type: 'textarea', placeholder: 'Description', initialValue: '', className: 'col-12',
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

  useEffect(() => {
    const init = async () => {
      const { success, data } = await ApiService.getUi();
      setUiData({
        loading: false,
        cashBooks: success ? data.cashBooks || [] : [],
        categories: success ? data.categories || [] : [],
        parties: success ? data.parties || [] : [],
        centers: success ? data.centers || [] : [],
        partyTypes: success ? data.partyTypes || [] : [],
      });
      if (id) {
        const res = await ApiService.get(id);
        if (res.success && res.data) {
          const { lines, ...header } = res.data;
          formik.setValues({
            cashBookId: header.cashBookId ?? '',
            voucherDate: (header.voucherDate || '').split('T')[0],
            currencyCode: header.currencyCode ?? '',
            payeePartyType: header.payeePartyType ?? '',
            payeePartyId: header.payeePartyId ?? '',
            payeeName: header.payeeName ?? '',
            payeeNic: header.payeeNic ?? '',
            costCenterCode: header.costCenterCode ?? '',
            jobNo: header.jobNo ?? '',
            description: header.description ?? '',
          });
          setStatus(header.status);
          const items = (lines || []).map((l) => ({
            categoryId: l.categoryId, description: l.description, amount: l.lineTotal,
          }));
          setLineItems(items);
          gridRef.current?.reset(items);
        }
      }
    };
    init();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [id]);

  const buildLines = () =>
    lineItems
      .filter((it) => it.categoryId && toNum(it.amount) > 0)
      .map((it) => {
        const amt = toNum(it.amount);
        return { categoryId: it.categoryId, description: it.description || null, qty: 1, unitPrice: amt, netAmount: amt, vatAmount: 0, lineTotal: amt };
      });

  const handleSubmit = async (values) => {
    const lines = buildLines();
    if (!lines.length) {
      MessageBoxService.show({ message: 'Add at least one line with an amount.', type: 'danger' });
      return;
    }
    const { success, data } = await ApiService.update({ ...values, voucherId: id || null, isUpdate: !!id, exchangeRate: 1, lines });
    if (success) {
      MessageBoxService.show({
        message: 'Voucher saved.',
        type: 'success',
        onClose: () => {
          if (config.features.returnToListAfterSave) {
            navigate('/petty-cash/voucher');
          } else if (!id && data?.voucherId) {
            navigate(`/petty-cash/voucher/edit/${data.voucherId}`);
          }
        },
      });
    }
  };

  const handleCancel = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Cancel this voucher? Any posting is voided.',
      type: 'danger', confirmText: 'Cancel Voucher', cancelText: 'Back',
    });
    if (!confirmed) return;
    const { success } = await ApiService.cancel(id);
    if (success) {
      MessageBoxService.show({ message: 'Voucher cancelled.', type: 'success', onClose: () => navigate('/petty-cash/voucher') });
    }
  };

  const formik = useFormikBuilder(fields, handleSubmit);

  // Derive currency from the selected cash book.
  useEffect(() => {
    const book = uiData.cashBooks.find((b) => String(b.cashBookId) === String(formik.values.cashBookId));
    if (book && book.currencyCode !== formik.values.currencyCode) {
      formik.setFieldValue('currencyCode', book.currencyCode);
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [formik.values.cashBookId, uiData.cashBooks]);

  // Prefill the display name from the picked party; stays editable.
  useEffect(() => {
    if (!formik.values.payeePartyId) return;
    const p = uiData.parties.find((x) => x.businessPartnerId === formik.values.payeePartyId);
    if (p && !formik.values.payeeName) {
      formik.setFieldValue('payeeName', p.partnerName);
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [formik.values.payeePartyId, uiData.parties]);

  // Payment happens on the Settlement / Payment screen, which consumes this
  // voucher as its bills. No direct Pay here.
  const isDraft = !id || status === 'Draft';
  const canCancel = id && status !== 'Cancelled';

  return (
    <MeridianPage
      title={`${id ? 'Edit' : 'New'} ${menuLabel}`}
      backTo="/petty-cash/voucher"
      cardClass="ml-form-card"
      actions={
        <>
          {canCancel && (
            <PermissionGate codes="pc-voucher-cancel">
              <button type="button" className="ml-btn-ghost ml-btn-danger-ghost ml-fab-1" onClick={handleCancel}>
                <i className="bi bi-x-circle" aria-hidden="true" />
                Cancel
              </button>
            </PermissionGate>
          )}
          {isDraft && (
            <PermissionGate codes={id ? 'pc-voucher-update' : 'pc-voucher-save'}>
              <button type="submit" form="voucher-form" className="ml-btn-action ml-fab" disabled={uiData.loading}>
                <i className="bi bi-check-lg" aria-hidden="true" />
                Save
              </button>
            </PermissionGate>
          )}
        </>
      }
    >
      <form id="voucher-form" onSubmit={formik.handleSubmit}>
        <div className="ml-form-section">
          <div className="row g-2">
            <InputField {...fields.cashBookId} formik={formik} />
            <InputField {...fields.voucherDate} formik={formik} />
            <InputField {...fields.currencyCode} formik={formik} />
            <InputField {...fields.payeePartyType} formik={formik} />
            <InputField {...fields.payeePartyId} formik={formik} />
            <InputField {...fields.payeeName} formik={formik} />
            <InputField {...fields.payeeNic} formik={formik} />
            <InputField {...fields.costCenterCode} formik={formik} />
            <InputField {...fields.jobNo} formik={formik} />
            <InputField {...fields.description} formik={formik} />
            <DataGrid ref={gridRef} initialItems={lineItems} columns={lineColumns} onItemsChange={setLineItems} />
          </div>
        </div>
      </form>
    </MeridianPage>
  );
}
