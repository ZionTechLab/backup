import { useEffect, useState, useMemo } from 'react';
import { DataTable } from '../../../components/DataTable/DataTable';
import { useFormikBuilder, FieldsRenderer } from '../../../helpers/formikBuilder';
import MeridianPage from '../../Meridian/MeridianPage';
import { todayISO } from '../../../helpers/transformDateFields';
import ApiService from '../Reports/service';

const getCurrentMonth = () => {
  const n = new Date();
  return {
    fromDate: todayISO(new Date(n.getFullYear(), n.getMonth(), 1)),
    toDate: todayISO(new Date(n.getFullYear(), n.getMonth() + 1, 0)),
  };
};

const defaults = getCurrentMonth();

const filterFields = {
  fromDate: {
    name: 'fromDate', type: 'date', placeholder: 'From',
    initialValue: defaults.fromDate, className: 'col-sm-6 col-md-auto',
  },
  toDate: {
    name: 'toDate', type: 'date', placeholder: 'To',
    initialValue: defaults.toDate, className: 'col-sm-6 col-md-auto',
  },
};

function StatCard({ label, value, accent }) {
  return (
    <div className={`gl-stat-card${accent ? ' gl-stat-card-accent' : ''}`}>
      <p className="gl-stat-label">{label}</p>
      <p className="gl-stat-value">
        {Number(value || 0).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 2 })}
      </p>
    </div>
  );
}

export default function ManagerDashboard() {
  const [data, setData] = useState({ loading: true, rows: [], kpi: null });

  useEffect(() => {
    const m = getCurrentMonth();
    fetchDashboard(m);
  }, []);

  const fetchDashboard = (filters) => {
    setData(p => ({ ...p, loading: true }));
    ApiService.managerDashboard(filters).then(({ success, data: d }) => {
      if (success) {
        setData({ loading: false, rows: d.rows || [], kpi: d.kpi || null });
      } else {
        setData({ loading: false, rows: [], kpi: null });
      }
    });
  };

  const handleApply = (values) => fetchDashboard(values);
  const filterFormik = useFormikBuilder(filterFields, handleApply);

  const columns = [
    { header: 'Code', field: 'code', class: 'text-nowrap', cardRole: 'title' },
    { header: 'Cash Book', field: 'name', class: 'text-nowrap', cardRole: 'subtitle' },
    { header: 'Cashier', field: 'cashierName', class: 'text-nowrap' },
    { header: 'On Hand', field: 'onHand', type: 'currency', class: 'text-nowrap text-end', cardRole: 'amount' },
    { header: 'IOU Issued', field: 'iouIssued', type: 'currency', class: 'text-nowrap text-end' },
    { header: 'IOU Settled', field: 'iouSettled', type: 'currency', class: 'text-nowrap text-end' },
    { header: 'PC Paid', field: 'pettyCashPaid', type: 'currency', class: 'text-nowrap text-end' },
  ];

  return (
    <MeridianPage title="Petty Cash Dashboard">
      <div className="ml-filter-bar">
        <div className="row g-2 align-items-end">
          <FieldsRenderer fields={filterFields} formik={filterFormik} />
          <div className="col-auto">
            <button type="button" className="btn btn-primary" onClick={filterFormik.handleSubmit}>
              <i className="bi bi-search me-1" />Apply
            </button>
          </div>
        </div>
      </div>

      <div className="row mb-4">
        <div className="col-6 col-md mb-2">
          <StatCard label="Total Float" value={data.kpi?.totalFloat ?? 0} accent />
        </div>
        <div className="col-6 col-md mb-2">
          <StatCard label="Outstanding IOU" value={data.kpi?.totalOutstandingIou ?? 0} />
        </div>
        <div className="col-6 col-md mb-2">
          <StatCard label={`Overdue IOUs (>${data.kpi?.settlementPeriodDays ?? '-'}d)`} value={data.kpi?.overdueIouCount ?? 0} />
        </div>
      </div>

      <DataTable
        columns={columns} data={data.rows} loading={data.loading}
        name="Manager Dashboard" features={{ columnVisibility: true, csvExport: true }}
      />
    </MeridianPage>
  );
}
