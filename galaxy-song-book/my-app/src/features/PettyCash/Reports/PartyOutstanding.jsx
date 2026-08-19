import { useEffect, useState } from 'react';
import { DataTable } from '../../../components/DataTable/DataTable';
import MeridianPage from '../../Meridian/MeridianPage';
import ApiService from './service';

export default function PartyOutstanding() {
  const [uiData, setUiData] = useState({ loading: true, data: [] });

  useEffect(() => {
    setUiData(p => ({ ...p, loading: true }));
    ApiService.partyOutstanding().then(({ success, data }) => {
      setUiData({ loading: false, data: success ? data : [] });
    });
  }, []);

  const columns = [
    { header: 'Party', field: 'partyName', class: 'text-nowrap', cardRole: 'title' },
    { header: 'IOU Count', field: 'iouCount', class: 'text-nowrap text-end', cardRole: 'subtitle' },
    { header: 'Total Advance', field: 'totalAdvance', type: 'currency', class: 'text-nowrap text-end' },
    { header: 'Total Settled', field: 'totalSettled', type: 'currency', class: 'text-nowrap text-end' },
    { header: 'Outstanding', field: 'outstanding', type: 'currency', class: 'text-nowrap text-end fw-bold', cardRole: 'amount' },
  ];

  return (
    <MeridianPage title="Party Outstanding">
      <DataTable
        columns={columns} data={uiData.data} loading={uiData.loading}
        name="Party Outstanding" features={{ columnVisibility: true, csvExport: true }}
      />
    </MeridianPage>
  );
}
