import { Link, useNavigate } from 'react-router-dom';
import { DataTable } from '../../../components/DataTable';
import { useEffect, useState } from 'react';
import RegisterService from './service';
import MessageBoxService from '../../../services/MessageBoxService';

function RegisterList() {
    const [uiData, setUiData] = useState({ loading: false, success: false, error: '', data: [] });
    const navigate = useNavigate();

    useEffect(() => {
        fetchUi();
    }, []);

    const fetchUi = async () => {
        setUiData((prev) => ({ ...prev, loading: true, error: '', data: [] }));
        const data = await RegisterService.getAll();
        setUiData((prev) => ({ ...prev, ...data, loading: false }));
    };

    const handleDelete = async (id) => {
        const confirmed = await MessageBoxService.confirmAsync({
            message: 'Are you sure you want to delete this registration?',
            type: 'danger',
            confirmText: 'Delete',
            cancelText: 'Cancel',
        });

        if (!confirmed) return;

        const response = await RegisterService.delete({ id });
        if (response.success) {
            MessageBoxService.show({
                message: 'Registration deleted successfully!',
                type: 'success',
                onClose: () => { fetchUi(); },
            });
        }
    };

    const handleEdit = (id) => {
        navigate(`/jolly-snap/register/edit/${id}`);
    };

    const columns = [
        {
            header: 'Actions',
            isAction: true,
            actionTemplate: (row) => (
                <div className="d-flex gap-2 justify-content-center">
                    <button className="btn btn-outline-primary btn-sm btn-borderless" title="Edit" onClick={() => handleEdit(row.id)}>
                        <i className="bi bi-pencil"></i>
                    </button>
                    <button className="btn btn-outline-danger btn-sm btn-borderless" title="Delete" onClick={() => handleDelete(row.id)}>
                        <i className="bi bi-trash"></i>
                    </button>
                </div>
            )
        },
        { header: 'ID', field: 'id' },
        { header: 'Name', field: 'name', class: 'text-nowrap' },
        { header: 'Email', field: 'email', class: 'text-nowrap' },
        { header: 'WhatsApp No', field: 'whatsAppNo', class: 'text-nowrap' },
        { header: 'Package', field: 'package', class: 'text-nowrap' },
        { header: 'Amount Paid?', field: 'amountPaid', class: 'text-nowrap' },
    ];

    return (
        <div>
            {!uiData.error && (
                <DataTable loading={uiData.loading} name="JollySnap Register" data={uiData.data} columns={columns}>
                    <Link to="/jolly-snap/register/add">
                        <button className="btn btn-primary">+ Add New</button>
                    </Link>
                </DataTable>
            )}
            {uiData.error && (
                <div className="alert alert-danger mt-3">{uiData.error}</div>
            )}
        </div>
    );
}

export default RegisterList;
