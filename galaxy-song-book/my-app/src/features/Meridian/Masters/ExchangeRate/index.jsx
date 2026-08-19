import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { DataTable } from "../../../../components/DataTable/DataTable";
import MeridianPage from "../../MeridianPage";
import ApiService from "./service";


function buildColumns(navigate) {
  return [ 
    { header: "ID",             field: "rateId", isId: true },
    { header: "From",           field: "from_currency" },
    { header: "To",             field: "to_currency" },
    { header: "Rate Type",      field: "rateType" },
    { header: "Rate",           field: "rate" },
    { header: "Effective Date", field: "effectiveDate", type: "date" },
    {
      header: "",
      field: "actions",
      isAction: true,
      actionTemplate: (row) => (
        <button aria-label="Edit" className="btn btn-outline-primary btn-sm btn-borderless" onClick={() => navigate(`/settings/exchange-rates/edit/${row.rateId}`)}>
          <i className="bi bi-pencil" />
        </button>
      ),
    },
  ];
}

export default function ExchangeRates() {
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, data: [], error: "" });
  const columns = buildColumns(navigate);

  useEffect(() => { fetchAll(); }, []);

  const fetchAll = async () => {
    setUiData(prev => ({ ...prev, loading: true, data: [] }));
    const { success, data } = await ApiService.getAll();
    setUiData(prev => ({ ...prev, data: success ? data : [], loading: false }));
  };

  return (
    <MeridianPage title="Exchange Rates">
      <DataTable
        columns={columns}
        data={uiData.data}
        loading={uiData.loading}
        name="ExchangeRates"
        // //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      >
        <button className="ml-btn-action ml-fab" onClick={() => navigate("/settings/exchange-rates/add")}>
          <i className="bi bi-plus-lg" aria-hidden="true" />
          Add Rate
        </button>
      </DataTable>
    </MeridianPage>
  );
}
