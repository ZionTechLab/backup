import { Link, useNavigate, useParams } from "react-router-dom";
import { useSelector } from "react-redux";
import { selectInitData } from "../../features/auth";
import { DataTable } from '../../components/DataTable';
import { useEffect, useState } from "react";
import ApiService from "./ReferenceService";
import MessageBoxService from "../../services/MessageBoxService";

function RefferanceListing() {
  const [uiData, setUiData] = useState({
    loading: false,
    success: false,
    error: "",
    data: [],
  });

  const navigate = useNavigate();
  const { category } = useParams();
  const initData = useSelector(selectInitData);

  const slugify = (s) =>
    String(s || "")
      .toLowerCase()
      .trim()
      .replace(/[^a-z0-9\s-]/g, "")
      .replace(/\s+/g, "-")
      .replace(/-+/g, "-");
  const metaList = initData?.meta || [];

  const matched = category
    ? metaList.find((m) => slugify(m.categoryTypeName) === category)
    : null;

  const categoryType = matched?.categoryType;

  useEffect(() => {
    fetchUi();
    // eslint-disable-next-line
  }, [categoryType]);
  const fetchUi = async () => {
    setUiData((prev) => ({ ...prev, loading: true, error: "", data: [] }));
    const data = await ApiService.getAll({ categoryType });

    setUiData((prev) => ({ ...prev, ...data, loading: false }));
  };
  const handleDelete = async (id) => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: "Are you sure you want to delete?",
      type: "danger",
      confirmText: "Delete",
      cancelText: "Cancel",
    });

    if (!confirmed) return;

    const response = await ApiService.delete(id, categoryType);
    if (response.success) {
      MessageBoxService.show({
        message: "Deleted successfully!",
        type: "success",
        onClose: () => {
          fetchUi();
        },
      });
    }
  };

  const handleEdit = (id) => {
    const base = category ? `/reference/${category}` : "/reference";
    navigate(`${base}/edit/${id}`);
  };

  const columns = [
    {
      header: "Actions",
      isAction: true,
      actionTemplate: (row) => (
        <div className="d-flex gap-2 justify-content-center">
          <button
            className="btn btn-outline-primary  btn-sm btn-borderless"
            title="Edit"
            onClick={() => handleEdit(row.id)}
          >
            <i className="bi bi-pencil"></i>
          </button>
          <button
            className="btn btn-outline-danger  btn-sm btn-borderless"
            title="Delete"
            onClick={() => handleDelete(row.id, row.categoryType)}
          >
            <i className="bi bi-trash"></i>
          </button>
        </div>
      ),
    },
    { header: "ID", field: "id" },
    {
      header: uiData.data?.meta?.metaValue.placeholder,
      field: "value",
      class: "text-nowrap",
    },
    {
      header: uiData.data?.meta?.parentCategory,
      field: "parentValue",
      class: "text-nowrap",
    },

    uiData.data?.meta?.ref1 !== null &&
      (uiData.data?.meta?.ref1?.isVisible === false
        ? null
        : {
            header: uiData.data?.meta?.ref1.placeholder,
            field: "ref1",
            class: "text-nowrap",
          }),

    uiData.data?.meta?.ref2 !== null &&
      (uiData.data?.meta?.ref2?.isVisible === false
        ? null
        : {
            header: uiData.data?.meta?.ref2.placeholder,
            field: "ref2",

            class: "text-nowrap",
          }),

    uiData.data?.meta?.ref3 !== null &&
      (uiData.data?.meta?.ref3?.isVisible === false
        ? null
        : {
            header: uiData.data?.meta?.ref3.placeholder,
            field: "ref3",
            class: "text-nowrap",
          }),
    // uiData.data?.meta?.ref3 && uiData.data?.meta?.ref3?.isVisible === false
    //   ? ""
    //   : {
    //       header: uiData.data?.meta?.ref3.placeholder,
    //       field: "ref3",
    //       class: "text-nowrap",
    //     },
    // { header: uiData.data?.meta?.ref1, field: "ref1", class: "text-nowrap" },
    // { header: uiData.data?.meta?.ref2, field: "ref2", class: "text-nowrap" },
    // { header: uiData.data?.meta?.ref3, field: "ref3", class: "text-nowrap" },
    uiData.data?.meta?.metaDesc?.isVisible === false
      ? ""
      : {
          header: uiData.data?.meta?.metaDesc.placeholder,
          field: "description",
          class: "text-nowrap",
        },
    {
      header: "Active",
      field: "active",
      type: "boolean",
      class: "text-center",
    },
  ];

  return (
    <div>
      {!uiData.loading && !uiData.error && (
        <DataTable
          name={uiData.data?.meta?.metaName || "References"}
          data={uiData.data.data}
          columns={columns}
        >
          <Link
            to={category ? `/reference/${category}/add` : "/reference/add"}
          >
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

export default RefferanceListing;
