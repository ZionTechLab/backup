import { DataTable } from '../../../components/DataTable/DataTable';
import MeridianPage from '../../Meridian/MeridianPage';
import STATUS_CLASS from '../../../helpers/statusBadge';
import { TRACKING_ROWS } from './mockReportData';

function StatusBadge({ status }) {
  return <span className={`ml-badge ${STATUS_CLASS[status] || 'ml-badge-locked'}`}>{status}</span>;
}

// Demo-only: sample data below, not wired to live petty cash transactions yet.
export default function TrackingReport() {
  const rows = TRACKING_ROWS.map((r) => ({ ...r, variance: r.requested - r.paidOut }));

  const columns = [
    { header: 'Request No', field: 'requestNo', class: 'text-nowrap', cardRole: 'title' },
    { header: 'Party', field: 'party', class: 'text-nowrap' },
    { header: 'Department', field: 'department', class: 'text-nowrap' },
    { header: 'Date', field: 'requestDate', type: 'date', class: 'text-nowrap', cardRole: 'subtitle' },
    { header: 'Requested', field: 'requested', type: 'currency', class: 'text-nowrap text-end' },
    { header: 'Paid Out', field: 'paidOut', type: 'currency', class: 'text-nowrap text-end' },
    { header: 'Settled', field: 'settled', type: 'currency', class: 'text-nowrap text-end' },
    { header: 'Unissued Balance', field: 'variance', type: 'currency', class: 'text-nowrap text-end' },
    { header: 'Status', field: 'status', render: (r) => <StatusBadge status={r.status} />, cardRole: 'badge' },
  ];

  return (
    <MeridianPage title="Tracking Report" subtitle="Request vs Payout vs Settled — demo data, not wired to live transactions yet">
      <DataTable
        columns={columns} data={rows} loading={false}
        name="Tracking Report" features={{ columnVisibility: true, csvExport: true }}
      />
    </MeridianPage>
  );
}
