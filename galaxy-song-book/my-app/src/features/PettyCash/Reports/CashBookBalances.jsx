import { useEffect, useState } from 'react';
import { DataTable } from '../../../components/DataTable/DataTable';
import MeridianPage from '../../Meridian/MeridianPage';
import ApiService from './service';

export default function CashBookBalances() {
  const [uiData, setUiData] = useState({ loading: true, data: [] });

  useEffect(() => {
    setUiData(p => ({ ...p, loading: true }));
    ApiService.cashBookBalances().then(({ success, data }) => {
      setUiData({ loading: false, data: success ? data : [] });
    });
  }, []);

  const columns = [
    { header: 'Code', field: 'code', class: 'text-nowrap', cardRole: 'title' },
    { header: 'Name', field: 'name', class: 'text-nowrap', cardRole: 'subtitle' },
    { header: 'Cashier', field: 'cashierName', class: 'text-nowrap' },
    { header: 'Currency', field: 'currencyCode', class: 'text-nowrap text-center' },
    { header: 'Float Limit', field: 'floatLimit', type: 'currency', class: 'text-nowrap text-end' },
    { header: 'Balance', field: 'balance', type: 'currency', class: 'text-nowrap text-end' },
    { header: 'Headroom', field: 'headroom', type: 'currency', class: 'text-nowrap text-end fw-bold', cardRole: 'amount' },
  ];

  return (
    <MeridianPage title="Cash Book Balances">
      <DataTable
        columns={columns} data={uiData.data} loading={uiData.loading}
        name="Cash Book Balances" features={{ columnVisibility: true, csvExport: true }}
      />
    </MeridianPage>
  );
}
