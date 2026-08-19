import { useState, useMemo } from 'react';
import { DataTable } from '../../../components/DataTable/DataTable';
import { useFormikBuilder, FieldsRenderer } from '../../../helpers/formikBuilder';
import MeridianPage from '../../Meridian/MeridianPage';
import ApiService from './service';

const filterFields = {
  asOf: {
    name: 'asOf', type: 'date', placeholder: 'As of (default: today)',
    initialValue: '', className: 'col-sm-6 col-md-auto',
  },
};

export default function IouAging() {
  const [uiData, setUiData] = useState({ loading: false, data: [] });
  const [summary, setSummary] = useState(null);

  const handleApply = (values) => {
    setUiData(p => ({ ...p, loading: true }));
    ApiService.iouAging(values).then(({ success, data }) => {
      if (success && data?.parties) {
        setSummary({ totals: data.totals, asOf: data.asOf });
        setUiData({ loading: false, data: data.parties });
      } else {
        setUiData({ loading: false, data: [] });
      }
    });
  };

  const filterFormik = useFormikBuilder(filterFields, handleApply);

  const columns = [
    { header: 'Party', field: 'partyName', class: 'text-nowrap', cardRole: 'title' },
    { header: '0-7 Days', field: 'b0_7', type: 'currency', class: 'text-nowrap text-end' },
    { header: '8-15 Days', field: 'b8_15', type: 'currency', class: 'text-nowrap text-end' },
    { header: '16-30 Days', field: 'b16_30', type: 'currency', class: 'text-nowrap text-end' },
    { header: '30+ Days', field: 'b30plus', type: 'currency', class: 'text-nowrap text-end' },
    { header: 'Total', field: 'total', type: 'currency', class: 'text-nowrap text-end fw-bold', cardRole: 'amount' },
  ];

  return (
    <MeridianPage title="IOU Aging" subtitle={summary ? `As of ${summary.asOf}` : ''}>
      <div className="ml-filter-bar">
        <div className="row g-2 align-items-end">
          <FieldsRenderer fields={filterFields} formik={filterFormik} />
          <div className="col-auto d-flex gap-2">
            <button type="button" className="btn btn-primary" onClick={filterFormik.handleSubmit}>
              <i className="bi bi-search me-1" />Run
            </button>
          </div>
        </div>
      </div>
      <DataTable
        columns={columns} data={uiData.data} loading={uiData.loading}
        name="IOU Aging" features={{ columnVisibility: true, csvExport: true }}
      />
      {summary && (
        <div className="row mt-3">
          {Object.entries(summary.totals).map(([k, v]) => {
            const labels = { b0_7: '0-7 Days', b8_15: '8-15 Days', b16_30: '16-30 Days', b30plus: '30+ Days' };
            return (
              <div className="col-6 col-md-3 mb-2" key={k}>
                <div className="ml-card-stat">
                  <p className="ml-stat-label">{labels[k] || k}</p>
                  <p className="ml-stat-value">{Number(v || 0).toLocaleString('en-US', { minimumFractionDigits: 2 })}</p>
                </div>
              </div>
            );
          })}
        </div>
      )}
    </MeridianPage>
  );
}
