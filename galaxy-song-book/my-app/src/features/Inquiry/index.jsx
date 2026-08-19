import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { DataTable } from '../../components/DataTable/DataTable';
import MeridianPage from '../Meridian/MeridianPage';
import MessageBoxService from '../../services/MessageBoxService';
import InquiryService from './InquiryService';

export default function InquiryList() {
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, data: [], error: '' });

  useEffect(() => { fetchAll(); /* eslint-disable-next-line */ }, []);

  const fetchAll = async () => {
    setUiData((prev) => ({ ...prev, loading: true }));
    const { success, data } = await InquiryService.getAll();
    setUiData({ loading: false, data: success ? data : [], error: '' });
  };

  const handleDelete = async (id) => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Delete this inquiry? This cannot be undone.',
      type: 'danger',
      confirmText: 'Delete',
      cancelText: 'Cancel',
    });
    if (!confirmed) return;
    const { success } = await InquiryService.delete(id);
    if (success) {
      MessageBoxService.show({ message: 'Inquiry deleted.', type: 'success', onClose: fetchAll });
    }
  };

  const columns = [
    { header: 'Job No', field: 'txnNoDisplay', class: 'text-nowrap' },
    { header: 'Date', field: 'txnDate', type: 'date', class: 'text-nowrap' },
    { header: 'Customer', field: 'partnerName', class: 'text-nowrap' },
    { header: 'Status', field: 'status', class: 'text-nowrap' },
    { header: 'Item', field: 'ref1' },
    { header: 'Serial No', field: 'ref2' },
    { header: 'Nature of Faulty', field: 'description' },
    { header: 'Due Date', field: 'ref3', type: 'date', class: 'text-nowrap' },
    {
      header: '', field: 'actions', isAction: true,
      actionTemplate: (row) => (
        <div className="d-flex gap-1">
          <button aria-label="Edit" className="btn btn-outline-primary btn-sm btn-borderless"
            onClick={() => navigate(`/inquiry/edit/${row.id}`)}>
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
    <MeridianPage title="Inquiry">
      <DataTable
        columns={columns}
        data={uiData.data}
        loading={uiData.loading}
        name="Inquiries"
        // //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      >
        <button className="ml-btn-action ml-fab" onClick={() => navigate('/inquiry/add')}>
          <i className="bi bi-plus-lg" aria-hidden="true" />
          New Inquiry
        </button>
      </DataTable>
    </MeridianPage>
  );
}
