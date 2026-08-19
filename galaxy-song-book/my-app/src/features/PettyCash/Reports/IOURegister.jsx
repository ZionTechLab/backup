import { useEffect, useState, useMemo } from 'react';
import { DataTable } from '../../../components/DataTable/DataTable';
import { useFormikBuilder, FieldsRenderer } from '../../../helpers/formikBuilder';
import MeridianPage from '../../Meridian/MeridianPage';
import { todayISO } from '../../../helpers/transformDateFields';
import ApiService from './service';
import CashBookService from '../CashBook/service';

const now = new Date();
const monthStart = todayISO(new Date(now.getFullYear(), now.getMonth(), 1));
const monthEnd = todayISO(new Date(now.getFullYear(), now.getMonth() + 1, 0));

const filterFields = {
  cashBookId: {
    name: 'cashBookId', type: 'select', placeholder: 'All Cash Books',
    initialValue: '', className: 'col-12 col-md', labelOnTop: false, clearable: true,
    dataBinding: { data: [], keyField: 'cashBookId', valueField: 'label' },
  },
  fromDate: {
    name: 'fromDate', type: 'date', placeholder: 'From',
    initialValue: monthStart, className: 'col-6 col-md-auto',
  },
  toDate: {
    name: 'toDate', type: 'date', placeholder: 'To',
    initialValue: monthEnd, className: 'col-6 col-md-auto',
  },
};

const STATUS_CLASS = {
  Draft: 'ml-badge-draft', Certified: 'ml-badge-draft', Approved: 'ml-badge-locked',
  Paid: 'ml-badge-open', Settled: 'ml-badge-void', Overdue: 'ml-badge-void', Cancelled: 'ml-badge-void',
};

function StatusBadge({ status }) {
  return <span className={`ml-badge ${STATUS_CLASS[status] || 'ml-badge-locked'}`}>{status}</span>;
}

export default function IouRegister() {
  const [uiData, setUiData] = useState({ loading: false, data: [] });
  const [cashBooks, setCashBooks] = useState([]);

  useEffect(() => {
    CashBookService.getUi().then(({ success, data }) => {
      if (success && data?.cashBooks) {
        setCashBooks(data.cashBooks);
      }
    });
  }, []);

  const cbOptions = useMemo(() =>
    cashBooks.map(c => ({ cashBookId: c.cashBookId, label: c.code + ' - ' + c.name })),
  [cashBooks]);

  const fields = useMemo(() => ({
    ...filterFields,
    cashBookId: { ...filterFields.cashBookId, dataBinding: { ...filterFields.cashBookId.dataBinding, data: cbOptions } },
  }), [cbOptions]);

  const handleApply = (values) => {
    setUiData(p => ({ ...p, loading: true }));
    ApiService.iouRegister(values).then(({ success, data }) => {
      setUiData({ loading: false, data: success ? data : [] });
    });
  };

  const filterFormik = useFormikBuilder(fields, handleApply);

  // auto-load current month on mount
  useEffect(() => {
    handleApply({ cashBookId: '', fromDate: monthStart, toDate: monthEnd });
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const columns = [
    { header: 'IOU No', field: 'iouNo', class: 'text-nowrap', cardRole: 'title' },
    { header: 'Date', field: 'iouDate', type: 'date', class: 'text-nowrap', cardRole: 'subtitle' },
    { header: 'Cash Book', field: 'cashBookCode', class: 'text-nowrap' },
    { header: 'Party', field: 'partyName', class: 'text-nowrap' },
    { header: 'Requested', field: 'requestAmount', type: 'currency', class: 'text-nowrap text-end' },
    { header: 'Settled', field: 'settledAmount', type: 'currency', class: 'text-nowrap text-end' },
    { header: 'Outstanding', field: 'outstanding', type: 'currency', class: 'text-nowrap text-end', cardRole: 'amount' },
    { header: 'Status', field: 'status', render: (r) => <StatusBadge status={r.status} />, cardRole: 'badge' },
  ];

  return (
    <MeridianPage title="IOU Register">
      <div className="ml-filter-bar">
        <div className="row g-2 align-items-end">
          <FieldsRenderer fields={fields} formik={filterFormik} />
          <div className="col-auto d-flex gap-2">
            <button type="button" className="btn btn-primary" onClick={filterFormik.handleSubmit}>
              <i className="bi bi-search me-1" />Search
            </button>
          </div>
        </div>
      </div>
      <DataTable
        columns={columns} data={uiData.data} loading={uiData.loading}
        name="IOU Register" features={{ columnVisibility: true, csvExport: true }}
      />
    </MeridianPage>
  );
}
