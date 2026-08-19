import { Link, useNavigate } from 'react-router-dom';
import {DataTable} from '../../components/DataTable';
import { useEffect, useState } from 'react';
import MessageBoxService from '../../services/MessageBoxService';
import { useLoadingSpinner } from '../../hooks/useLoadingSpinner';
import ApiService from "./DailyReportService";

function DailyReportIndex() {
  const [uiData, setUiData] = useState({loading: false, success: false, error: '', data: [] });
  const navigate = useNavigate();
  const { showSpinner, hideSpinner } = useLoadingSpinner();

  useEffect(() => {
  
    fetchUi();
    // eslint-disable-next-line
  }, []);

  const fetchUi = async () => {
      setUiData(prev => ({ ...prev, loading: true, error: '', data: [] }));
      showSpinner();
        const data = await ApiService.getAll();
        setUiData(prev => ({ ...prev, ...data , loading: false }));
        hideSpinner();
    };
    
  const handleDelete = async (id) => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Are you sure you want to delete this Transaction?',
      type: 'danger',
      confirmText: 'Delete',
      cancelText: 'Cancel',
    });

    if (!confirmed) return;

    const response = await ApiService.delete({ id });
    if (response.success) {
      MessageBoxService.show({
        message: "Transaction deleted successfully!",
        type: "success",
        onClose: () => { fetchUi(); },
      });
    }
  };

  const handleEdit = (id) => {
    navigate(`/daily-report/edit/${id}`);
  };

  const columns = [
    {
      header: 'Actions',
      isAction: true,
      actionTemplate: (row) => (
        <div className="d-flex gap-2 justify-content-center">
          <button className="btn btn-outline-primary  btn-sm btn-borderless" onClick={() => handleEdit(row.id)}>
            <i className="bi bi-pencil"></i>
          </button>
          <button className="btn btn-outline-danger  btn-sm btn-borderless" onClick={() => handleDelete(row.id)}>
            <i className="bi bi-trash"></i>
          </button>
        </div>
      ),
    },
    { header: 'Txn No', field: 'id',class:'text-nowrap ' },
    { header: 'Date', field: 'txnDate' ,type: 'date'},
    { header: 'Customer', field: 'partnerName' },
    { header: 'Vehicle No', field: 'vehicleNo' },
    { header: 'Type of Machine', field: 'typeOfMachine' },
    { header: 'Operator', field: 'operator' },
    { header: 'Helper', field: 'helper' },
  ];

  return (
    <div>
      {!uiData.error && (
        <DataTable loading={uiData.loading} name="Daily Report" data={uiData.data} columns={columns}>
          <Link to="/daily-report/add">
            <button className="btn btn-primary">New</button>
          </Link>
        </DataTable>
      )}
      {uiData.error && (
        <div className="alert alert-danger mt-3">{uiData.error}</div>
      )}
    </div>
  );
}

export default DailyReportIndex;