import { Link, useNavigate } from 'react-router-dom';
import {DataTable} from '../../components/DataTable';
import { useEffect, useState } from 'react';
import ApiService from './UserService';
import MessageBoxService from '../../services/MessageBoxService';

function UserMaster() {
  const [uiData, setUiData] = useState({loading: false, success: false, error: '', data: [] });
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
    
  const handleDelete = async (userId) => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Are you sure you want to delete this User?',
      type: 'danger',
      confirmText: 'Delete',
      cancelText: 'Cancel',
    });

    if (!confirmed) return;

    const response = await ApiService.delete({ userId });
    if (response.success) {
      MessageBoxService.show({
        message: "User deleted successfully!",
        type: "success",
        onClose: () => { fetchUi(); },
      });
    }
  };

  const handleEdit = (userId) => {
    navigate(`/user-master/edit/${userId}`);
  };

  const columns = [
    {
      header: 'Actions',
      isAction: true,
      actionTemplate: (row) => (
        <div className="d-flex gap-2 justify-content-center">
          <button className="btn btn-outline-primary  btn-sm btn-borderless" title="Edit" onClick={() => handleEdit(row.userId)}>
            <i className="bi bi-pencil"></i>
          </button>
          <button className="btn btn-outline-danger btn-sm btn-borderless" title="Delete" onClick={() => handleDelete(row.userId)}>
            <i className="bi bi-trash"></i>
          </button>
        </div>
      )
    },
    { header: 'ID', field: 'userId' },
    { header: 'Username', field: 'userName', class:'text-nowrap'  },
    { header: 'Email', field: 'email', class:'text-nowrap'  },
    { header: 'Full Name', field: 'fullName', class:'text-nowrap'  },
    { header: 'Phone', field: 'phone', class:'text-nowrap'  },
    { header: 'Phone 2', field: 'phone2', class:'text-nowrap'  },
    // { header: 'Status', field: 'status', class:'text-nowrap'  },
  ];

  return (

 <div className="ml-screen p-4">
      <div className="ml-page-header">
        <div className="ml-page-header-left">
          <h1 className="ml-page-title">Users</h1>
          <button
            className="ml-btn-action ml-fab ms-3"
            onClick={() => navigate("/settings/users/add")}
          >
            <i className="bi bi-plus-lg" aria-hidden="true" />
            Add User
          </button>
        </div>
      </div>
   {!uiData.error && (
        <div className="ml-screen-card overflow-hidden">
        <DataTable loading={uiData.loading} name="User Master" data={uiData.data} columns={columns}>
          {/* <Link to="/user-master/add">
            <button className="btn btn-primary">New</button>
          </Link> */}
        </DataTable>
        </div>
      )}
      {uiData.error && (
        <div className="alert alert-danger mt-3">{uiData.error}</div>
      )}

    </div>

  );
}

export default UserMaster;