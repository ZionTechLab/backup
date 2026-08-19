import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { DataTable } from '../../components/DataTable/DataTable';
import MeridianPage from '../Meridian/MeridianPage';
import MessageBoxService from '../../services/MessageBoxService';
import ApiService from './service';

export default function UomMaster() {
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, data: [], error: '' });

  useEffect(() => { fetchAll(); /* eslint-disable-next-line */ }, []);

  const fetchAll = async () => {
    setUiData((prev) => ({ ...prev, loading: true }));
    const { success, data } = await ApiService.getAll();
    setUiData({ loading: false, data: success ? data : [], error: '' });
  };

  const handleDelete = async (id) => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Delete this UOM? This cannot be undone.',
      type: 'danger',
      confirmText: 'Delete',
      cancelText: 'Cancel',
    });
    if (!confirmed) return;
    const { success } = await ApiService.delete({ id });
    if (success) {
      MessageBoxService.show({ message: 'UOM deleted.', type: 'success', onClose: fetchAll });
    }
  };

  const columns = [
    { header: 'Code', field: 'uomCode', class: 'text-nowrap' },
    { header: 'Name', field: 'uomName', class: 'text-nowrap' },
    { header: 'Description', field: 'description' },
    { header: 'Active', field: 'active', type: 'boolean', class: 'text-nowrap' },
    {
      header: '', field: 'actions', isAction: true,
      actionTemplate: (row) => (
        <div className="d-flex gap-1">
          <button aria-label="Edit" className="btn btn-outline-primary btn-sm btn-borderless"
            onClick={() => navigate(`/uom-master/edit/${row.id}`)}>
            <i className="bi bi-pencil" />
          </button>
          <button aria-label="Delete" className="btn btn-outline-danger btn-sm btn-borderless"
            onClick={() => handleDelete(row.id)}>
            <i className="bi bi-trash" />
          </button>
        </div>
      ),
    },
  ];

  return (
    <MeridianPage title="UOM Master">
      <DataTable
        columns={columns}
        data={uiData.data}
        loading={uiData.loading}
        name="UOMs"
        //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      >
        <button className="ml-btn-action ml-fab" onClick={() => navigate('/uom-master/add')}>
          <i className="bi bi-plus-lg" aria-hidden="true" />
          New UOM
        </button>
      </DataTable>
    </MeridianPage>
  );
}
