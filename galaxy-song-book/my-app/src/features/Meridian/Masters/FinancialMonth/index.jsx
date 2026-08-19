import { useEffect, useMemo, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { DataTable } from "../../../../components/DataTable/DataTable";
import MessageBoxService from "../../../../services/MessageBoxService";
import MeridianPage from "../../MeridianPage";
import ApiService from "./service";
import { reloadInitData, selectSelectedCompany } from "../../../auth/authSlice";


const MONTH_NAMES = [
  "January", "February", "March", "April", "May", "June",
  "July", "August", "September", "October", "November", "December",
];

function StatusBadge({ isClosed }) {
  const cls = isClosed ? "ml-badge-locked" : "ml-badge-open";
  return <span className={`ml-badge ${cls}`}>{isClosed ? "Closed" : "Open"}</span>;
}

// The period immediately before the current one (with year rollover).
function prevPeriod(cur) {
  if (!cur) return null;
  const fnMonth = cur.currentFinMonth === 1 ? 12 : cur.currentFinMonth - 1;
  const fnYear  = cur.currentFinMonth === 1 ? cur.currentFinYear - 1 : cur.currentFinYear;
  return { fnYear, fnMonth };
}

export default function FinancialMonth() {

  const dispatch = useDispatch();
  const company = useSelector(selectSelectedCompany);
  const [uiData, setUiData] = useState({ loading: false, success: false, error: "", data: [] });
  const [saving, setSaving] = useState(false);

  const fetchUi = async () => {
    setUiData((prev) => ({ ...prev, loading: true, error: "", data: [] }));
    const data = await ApiService.getAll();
    setUiData((prev) => ({ ...prev, ...data, loading: false }));
  };

  useEffect(() => {
   fetchUi();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const setStatus = async (row, isClosed) => {
    const label = `${MONTH_NAMES[row.fnMonth - 1]} ${row.fnYear}`;
    const confirmed = await MessageBoxService.confirmAsync({
      message: `${isClosed ? "Close" : "Reopen"} ${label}?`,
      type: isClosed ? "danger" : "info",
      confirmText: isClosed ? "Close" : "Reopen",
      cancelText: "Cancel",
    });
    if (!confirmed) return;

    setSaving(true);
    const response = await ApiService.update({ fnYear: row.fnYear, fnMonth: row.fnMonth, isClosed });
    setSaving(false);
    if (response.success) {
      dispatch(reloadInitData()); // refresh cached company current-period in store
      MessageBoxService.show({
        message: `${label} ${isClosed ? "closed" : "reopened"}.`,
        type: "success",
        onClose: fetchUi,
      });
    }
  };

  const columns = useMemo(() => {
    const cur  = company;
    const prev = prevPeriod(cur);
    const isCurrent = (row) => cur && row.fnYear === cur.currentFinYear && row.fnMonth === cur.currentFinMonth;
    const isPrev    = (row) => prev && row.fnYear === prev.fnYear && row.fnMonth === prev.fnMonth;

    return [
      { header: "YEAR",   field: "fnYear" },
      { header: "MONTH",  field: "fnMonth", render: (row) => MONTH_NAMES[row.fnMonth - 1] ?? row.fnMonth },
      { header: "PERIOD", class: "text-nowrap", render: (row) => `${row.fnYear}-${String(row.fnMonth).padStart(2, "0")}` },
      { header: "START",  field: "startDate", class: "text-nowrap" },
      { header: "END",    field: "endDate",   class: "text-nowrap" },
      { header: "STATUS", field: "isClosed", render: (row) => <StatusBadge isClosed={row.isClosed} /> },
      {
        header: "",
        field: "actions",
        isAction: true,
        actionTemplate: (row) => {
          if (isCurrent(row) && !row.isClosed) {
            return (
              <button
                className="btn btn-outline-danger btn-sm btn-borderless"
                onClick={() => setStatus(row, true)}
                disabled={saving}
              >
                <i className="bi bi-lock" aria-hidden="true" /> Close
              </button>
            );
          }
          if (isPrev(row) && row.isClosed) {
            return (
              <button
                className="btn btn-outline-primary btn-sm btn-borderless"
                onClick={() => setStatus(row, false)}
                disabled={saving}
              >
                <i className="bi bi-unlock" aria-hidden="true" /> Open
              </button>
            );
          }
          return null;
        },
      },
    ];
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [company, saving]);

  const subtitle = useMemo(() => {
    if (!uiData.data.length) return "No periods";
    const closed = uiData.data.filter((r) => r.isClosed).length;
    const open   = uiData.data.length - closed;
    return `${open} open · ${closed} closed`;
  }, [uiData]);

  return (
    <MeridianPage title="Financial Year / Month">
      <p className="ml-page-subtitle">{subtitle}</p>

      <DataTable
        columns={columns}
        data={uiData.data}
        loading={uiData.loading}
        showHeader={false}
        pageSize={12}
        // //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      />
    </MeridianPage>
  );
}
