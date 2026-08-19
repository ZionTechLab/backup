import { Link, useNavigate } from 'react-router-dom';
import { DataTable } from '../../components/DataTable';
import { useEffect, useState } from 'react';
import ApiService from './service';
import MessageBoxService from '../../services/MessageBoxService';

function JobRegistration() {
  const [uiData, setUiData] = useState({ loading: false, success: false, error: '', data: [] });
  const navigate = useNavigate();

  useEffect(() => {
    fetchUi();
    // eslint-disable-next-line
  }, []);

  const fetchUi = async () => {
    setUiData((prev) => ({ ...prev, loading: true, error: '', data: [] }));
    const data = await ApiService.getAll();
    setUiData((prev) => ({ ...prev, ...data, loading: false }));
  };

  const handleDelete = async (id) => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Are you sure you want to delete this Job?',
      type: 'danger',
      confirmText: 'Delete',
      cancelText: 'Cancel',
    });

    if (!confirmed) return;

    const response = await ApiService.delete({ id });
    if (response.success) {
      MessageBoxService.show({
        message: 'Job deleted successfully!',
        type: 'success',
        onClose: () => {
          fetchUi();
        },
      });
    }
  };

  const handleEdit = (id) => {
    navigate(`/job-registration/edit/${id}`);
  };

  const columns = [
    {
      header: 'Actions',
      isAction: true,
      actionTemplate: (row) => (
        <div className="d-flex gap-2 justify-content-center">
          <button className="btn btn-outline-primary  btn-sm btn-borderless" title="Edit" onClick={() => handleEdit(row.id)}>
            <i className="bi bi-pencil"></i>
          </button>
          <button className="btn btn-outline-danger btn-sm btn-borderless" title="Delete" onClick={() => handleDelete(row.id)}>
            <i className="bi bi-trash"></i>
          </button>
        </div>
      )
    },
    { header: 'Job #', field: 'txnNoDisplay', class: 'text-nowrap' },
    { header: 'Intake Date', field: 'txnDate', type: 'date', class: 'text-nowrap' },
    { header: 'Partner', field: 'partnerName', class: 'text-nowrap' },
    { header: 'Delivered By', field: 'deliveredBy', class: 'text-nowrap' },
    { header: 'Item', field: 'ref1', class: 'text-nowrap' },
    { header: 'Serial #', field: 'ref2', class: 'text-nowrap' },
    // { header: 'Fault', field: 'description', class: 'text-truncate' },
    { header: 'Status', field: 'status', class: 'text-nowrap' },
  ];

  return (
    <div>
      {!uiData.error && (
        <DataTable loading={uiData.loading} name="Job Registration" data={uiData.data} columns={columns}>
          <Link to="/job-registration/add">
            <button className="btn btn-primary">+ Add Job</button>
          </Link>
        </DataTable>
      )}
      {uiData.error && (
        <div className="alert alert-danger mt-3">{uiData.error}</div>
      )}
    </div>
  );
}

export default JobRegistration;
