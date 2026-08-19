import { Link, useNavigate, useLocation } from "react-router-dom";
import { DataTable } from '../../../components/DataTable';
import { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { selectIsLoggedIn } from "../../auth/authSlice";
import RegisterService from "./service";
import MessageBoxService from "../../../services/MessageBoxService";

function RegisterList() {
  const [uiData, setUiData] = useState({
    loading: false,
    success: false,
    error: "",
    data: [],
  });
  const navigate = useNavigate();
  const isLoggedIn = useSelector(selectIsLoggedIn);
  const PAGE_STORAGE_KEY = 'songbook_register_page';
  const location = useLocation();
  const [page, setPage] = useState(() => {
    try {
      // If navigation came from the main menu, always start on page 1
      if (location?.state?.fromMenu) return 1;
      const stored = Number(sessionStorage.getItem(PAGE_STORAGE_KEY));
      return stored && !isNaN(stored) && stored > 0 ? stored : 1;
    } catch (e) {
      return 1;
    }
  });

  useEffect(() => {
    fetchUi();
  }, []);

  useEffect(() => {
    sessionStorage.setItem(PAGE_STORAGE_KEY, String(page));
  }, [page]);

  const fetchUi = async () => {
    setUiData((prev) => ({ ...prev, loading: true, error: "", data: [] }));
    const data = await RegisterService.getAll();
    setUiData((prev) => ({ ...prev, ...data, loading: false }));
  };

  const handleDelete = async (id) => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: "Are you sure you want to delete this registration?",
      type: "danger",
      confirmText: "Delete",
      cancelText: "Cancel",
    });

    if (!confirmed) return;

    const response = await RegisterService.delete({ id });
    if (response.success) {
      MessageBoxService.show({
        message: "Registration deleted successfully!",
        type: "success",
        onClose: () => {
          fetchUi();
        },
      });
    }
  };

  const handleEdit = (id) => {
    navigate(`/song-book/song/view/${id}`);
  };

  const columns = [
    {
      header: "Actions",
      isAction: true,
      actionTemplate: (row) => (
        <div className="d-flex gap-2 justify-content-center">
          <button
            className="btn btn-outline-primary btn-sm btn-borderless"
            title="Edit"
            onClick={() => handleEdit(row.id)}
          >
            <i className="bi bi-eye"></i>
          </button>
          {isLoggedIn && (
            <button
              className="btn btn-outline-secondary btn-sm btn-borderless"
              title="Edit"
              onClick={() => navigate(`/song-book/song/edit/${row.id}`)}
            >
              <i className="bi bi-pencil"></i>
            </button>
          )}
          {/* <button className="btn btn-outline-danger btn-sm btn-borderless" title="Delete" onClick={() => handleDelete(row.id)}>
                        <i className="bi bi-trash"></i>
                    </button> */}
        </div>
      ),
    },
    { header: "ID", field: "id" },
    { header: "Title", field: "title", class: "text-nowrap" },
    // { header: 'Email', field: 'email', class: 'text-nowrap' },
    // { header: 'WhatsApp No', field: 'whatsAppNo', class: 'text-nowrap' },
    // { header: 'Package', field: 'package', class: 'text-nowrap' },
    // { header: 'Amount Paid?', field: 'amountPaid', class: 'text-nowrap' },
  ];

  return (
    <div>
      {!uiData.error && (
        <DataTable loading={uiData.loading}
          name="Songs"
          data={uiData.data}
          columns={columns}
          page={page}
          onPageChange={setPage}
          pageSize={15}
          pageSizeOptions={[5, 10, 25, 50]}
        >
          <div className="d-flex align-items-center gap-2">
            <Link to="/song-book/song/add"></Link>
            <div className="input-group input-group-sm sb-page-input">
              {/* <span className="input-group-text">Page</span> */}
      
            </div>
          </div>
        </DataTable>
      )}
      {uiData.error && (
        <div className="alert alert-danger mt-3">{uiData.error}</div>
      )}

        {/* <input
                type="number"
                className="form-control"
                value={page}
                min={1}
                onChange={(e) => {
                  const v = Number(e.target.value) || 1;
                  setPage(Math.max(1, v));
                }}
              /> */}

      {/* sdsfsf */}
    </div>
  );
}

export default RegisterList;
