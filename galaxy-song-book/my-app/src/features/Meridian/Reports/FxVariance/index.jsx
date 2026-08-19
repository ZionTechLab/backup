import { useEffect, useMemo, useState } from "react";
import { DataTable } from "../../../../components/DataTable/DataTable";
import ApiService from "./service";
import MeridianPage from "../../MeridianPage";

const MONTH_NAMES = [
  "January", "February", "March", "April", "May", "June",
  "July", "August", "September", "October", "November", "December",
];

function generatePeriods(count = 18) {
  const out = [];
  const now = new Date();
  for (let i = 0; i < count; i++) {
    const d = new Date(now.getFullYear(), now.getMonth() - i, 1);
    out.push({
      value: `${d.getFullYear()}-${String(d.getMonth() + 1).padStart(2, "0")}`,
      label: `${MONTH_NAMES[d.getMonth()]} ${d.getFullYear()}`,
    });
  }
  return out;
}

const PERIODS = generatePeriods();

function fmtWhole(value) {
  if (value == null) return "–";
  return Number(value).toLocaleString("en-US", { minimumFractionDigits: 0, maximumFractionDigits: 0 });
}

function fmtAmount(value) {
  if (value == null) return "–";
  return Number(value).toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
}

function fmtRate(value) {
  if (value == null) return "–";
  return Number(value).toLocaleString("en-US", { minimumFractionDigits: 4, maximumFractionDigits: 4 });
}

function fmtPct(value) {
  if (value == null) return "–";
  return `${Number(value).toFixed(2)}%`;
}

function FxVariance() {
  const [period, setPeriod] = useState(PERIODS[0].value);
  const [uiData, setUiData] = useState({ loading: false, data: [], error: "" });
  const [meta, setMeta] = useState({
    title: "",
    totalCta: 0,
    alert: null,        // { company, threshold, amount, pctOfEquity }
    rateSource: "Manual",
  });

  useEffect(() => {
    fetchReport(period);
    // eslint-disable-next-line
  }, [period]);

  const fetchReport = async (p) => {
    setUiData({ loading: true, data: [], error: "" });
    const result = await ApiService.get(p);
    if (result.success) {
      setMeta({
        title:      result.data?.title      ?? "",
        totalCta:   result.data?.totalCta   ?? 0,
        alert:      result.data?.alert      ?? null,
        rateSource: result.data?.rateSource ?? "Manual",
      });
      setUiData({ loading: false, data: result.data?.rows ?? [], error: "" });
    } else {
      setUiData({ loading: false, data: [], error: result.error });
    }
  };

  const subtitle = useMemo(() => {
    const label = PERIODS.find((p) => p.value === period)?.label ?? period;
    return `Cumulative Translation Adjustment (CTA) · YTD ${label} · Reporting in USD`;
  }, [period]);

  const columns = [
    {
      header: "COMPANY",
      field: "companyCode",
      class: "text-nowrap",
      render: (row) => (
        <>
          <span className="fxv-company-chip">{row.companyCode}</span>
          <span className="fxv-company-name">{row.companyName}</span>
        </>
      ),
    },
    {
      header: "LOCAL CCY",
      field: "localCcy",
      render: (row) => <span className="fxv-ccy">{row.localCcy}</span>,
    },
    {
      header: "OPENING EQUITY (LOCAL)",
      field: "openingEquityLocal",
      class: "text-end text-nowrap",
      render: (row) => <span className="fxv-num">{fmtWhole(row.openingEquityLocal)}</span>,
    },
    {
      header: "CLOSING EQUITY (LOCAL)",
      field: "closingEquityLocal",
      class: "text-end text-nowrap",
      render: (row) => <span className="fxv-num">{fmtWhole(row.closingEquityLocal)}</span>,
    },
    {
      header: "OPENING RATE",
      field: "openingRate",
      class: "text-end text-nowrap",
      render: (row) => <span className="fxv-num">{fmtRate(row.openingRate)}</span>,
    },
    {
      header: "CLOSING RATE",
      field: "closingRate",
      class: "text-end text-nowrap",
      render: (row) => <span className="fxv-num">{fmtRate(row.closingRate)}</span>,
    },
    {
      header: "CTA (USD)",
      field: "ctaUsd",
      class: "text-end text-nowrap",
      render: (row) => (
        <span className="fxv-cta">
          <span className="fxv-cta-currency">$</span>
          {fmtAmount(row.ctaUsd)}
        </span>
      ),
    },
    {
      header: "% OF EQUITY",
      field: "pctOfEquity",
      class: "text-end text-nowrap",
      render: (row) => <span className="fxv-num-dim">{fmtPct(row.pctOfEquity)}</span>,
    },
  ];

  return (
    <MeridianPage title="FX Variance Report">
      <p className="ml-page-subtitle">{subtitle}</p>
      <div className="ml-page-actions">
        <div className="ml-btn-ghost d-flex align-items-center gap-1 ml-period-bar">
          <span className="ml-period-label">Period:</span>
          <select
            className="fxv-period-select"
            value={period}
            onChange={(e) => setPeriod(e.target.value)}
          >
            {PERIODS.map((p) => (
              <option key={p.value} value={p.value}>{p.label}</option>
            ))}
          </select>
        </div>
        <button className="ml-btn-ghost">Rate source: {meta.rateSource}</button>
        <button className="ml-btn-ghost">
          <i className="bi bi-download" aria-hidden="true" />
          Export
        </button>
      </div>

      {meta.alert && (
        <div className="fxv-alert">
          <i className="bi bi-exclamation-triangle-fill fxv-alert-icon" aria-hidden="true" />
          <div className="fxv-alert-body">
            <p className="fxv-alert-title">
              {meta.alert.company} CTA exceeds threshold ({Number(meta.alert.threshold).toFixed(1)}%)
            </p>
            <p className="fxv-alert-text">
              Cumulative translation adjustment of{" "}
              <span className="fxv-alert-amt">{fmtAmount(meta.alert.amount)}</span>{" "}
              represents {Number(meta.alert.pctOfEquity).toFixed(1)}% of opening equity. Review FX policy or hedging strategy.
            </p>
          </div>
        </div>
      )}

      <div className="fxv-section-card">
        <div className="fxv-section-header">TRANSLATION DETAIL</div>
        <div className="fxv-table-wrap">
          <DataTable
            columns={columns}
            data={uiData.data}
            loading={uiData.loading}
            name="FxVariance"
            pageSizeOptions={[10, 25, 50]}
            // //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
          />
        </div>
        <div className="fxv-total-row">
          <span className="fxv-total-label">Total CTA (Equity)</span>
          <span className="fxv-total-amount">{fmtAmount(meta.totalCta)}</span>
        </div>
      </div>
    </MeridianPage>
  );
}

export default FxVariance;
