import { useEffect, useMemo, useState } from "react";
import { useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";
import * as Yup from "yup";
import { DataTable } from "../../../../components/DataTable/DataTable";
import { useFormikBuilder, FieldsRenderer } from "../../../../helpers/formikBuilder";
import MeridianPage from "../../MeridianPage";
import ApiService from "./service";
import GeneralLedgerPrint from "./GeneralLedgerPrint";
import { selectSelectedCompany } from "../../../auth/authSlice";

// Date range of the company's current financial month. Prefers the persisted
// start/end dates from the store; falls back to computed calendar boundaries.
function finMonthRange(company) {
  if (company?.currentFinStartDate && company?.currentFinEndDate) {
    return { from: company.currentFinStartDate, to: company.currentFinEndDate };
  }
  if (!company?.currentFinYear || !company?.currentFinMonth) return null;
  const y = company.currentFinYear;
  const m = company.currentFinMonth;
  const pad = (n) => String(n).padStart(2, "0");
  const lastDay = new Date(y, m, 0).getDate();
  return { from: `${y}-${pad(m)}-01`, to: `${y}-${pad(m)}-${pad(lastDay)}` };
}


const filterFields = {
  accountId: {
    name: "accountId",
    type: "select",
    placeholder: "Select account",
    initialValue: "",
    className: "col-12 col-md",
    labelOnTop: false,
    clearable:true,
    // validation: Yup.string().required("Account is required"),
    dataBinding: { data: [], keyField: "accountId", valueField: "label" },
  },
  dateFrom: {
    name: "dateFrom",
    type: "date",
    placeholder: "Date From",
    initialValue: "",
    className: "col-6 col-md-auto",
    validation: Yup.string().required("Date From is required"),
  },
  dateTo: {
    name: "dateTo",
    type: "date",
    placeholder: "Date To",
    initialValue: "",
    className: "col-6 col-md-auto",
    validation: Yup.string()
      .required("Date To is required")
      .test("after-from", "Date To must be on or after Date From", function (value) {
        const { dateFrom } = this.parent;
        if (!value || !dateFrom) return true;
        return value >= dateFrom;
      }),
  },
};

const MONTH_NAMES = [
  "January", "February", "March", "April", "May", "June",
  "July", "August", "September", "October", "November", "December",
];

const TYPE_LABELS = { A: "Asset", L: "Liability", E: "Equity", R: "Revenue", X: "Expense" };

function fmtAmount(value) {
  if (value == null || value === 0) return "-";
  return Number(value).toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
}

function deriveSummary(groups) {
  return groups.reduce(
    (acc, g) => ({
      openingBalance: acc.openingBalance + (g.opbl || 0),
      totalDebits:    acc.totalDebits    + (g.debit || 0),
      totalCredits:   acc.totalCredits   + (g.credit || 0),
      closingBalance: acc.closingBalance + (g.clbl || 0),
    }),
    { openingBalance: 0, totalDebits: 0, totalCredits: 0, closingBalance: 0 }
  );
}

function RunningBalance({ value }) {
  if (value == null) return <span className="ml-mono-dim">-</span>;
  const num = Number(value);
  if (num < 0) {
    const abs = Math.abs(num).toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
    return <span className="gl-running-negative">({abs})</span>;
  }
  return <span className="ml-mono-dim">{num.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 })}</span>;
}

function StatCard({ label, value, accent }) {
  return (
    <div className={`gl-stat-card${accent ? " gl-stat-card-accent" : ""}`}>
      <p className="gl-stat-label">{label}</p>
      <p className="gl-stat-value">
        <span className="gl-stat-currency">USD</span>
        {" "}{Number(value || 0).toLocaleString("en-US", { minimumFractionDigits: 0, maximumFractionDigits: 0 })}
      </p>
    </div>
  );
}

function GeneralLedger() {
  const navigate = useNavigate();
  const company = useSelector(selectSelectedCompany);
  const [accounts, setAccounts] = useState([]);
  const [uiData, setUiData] = useState({ loading: false, data: [], error: "" });
  const [summary, setSummary] = useState({ openingBalance: 0, totalDebits: 0, totalCredits: 0, closingBalance: 0 });

  const accountOptions = useMemo(
    () => accounts.map((a) => ({
      accountId: String(a.accountId),
      label: a.accountCode ? `${a.accountCode} · ${a.accountName}` : a.accountName,
    })),
    [accounts]
  );

  const fields = useMemo(() => ({
    ...filterFields,
    accountId: {
      ...filterFields.accountId,
      dataBinding: { ...filterFields.accountId.dataBinding, data: accountOptions },
    },
  }), [accountOptions]);

  const fetchReport = async (accountId, fromDate, toDate) => {
    setUiData({ loading: true, data: [], error: "" });
    const result = await ApiService.getReport(accountId, fromDate, toDate);
    if (result.success) {
      const groups = result.data?.accounts ?? (Array.isArray(result.data) ? result.data : []);
      const hasTopSummary = result.data && result.data.openingBalance != null;
      setSummary(
        hasTopSummary
          ? {
              openingBalance: result.data.openingBalance ?? 0,
              totalDebits:    result.data.totalDebits    ?? 0,
              totalCredits:   result.data.totalCredits   ?? 0,
              closingBalance: result.data.closingBalance ?? 0,
            }
          : deriveSummary(groups)
      );
      setUiData({ loading: false, data: groups, error: "" });
    } else {
      setUiData({ loading: false, data: [], error: result.error });
    }
  };

  const handleApplyFilters = (values) => {
    fetchReport(values.accountId, values.dateFrom, values.dateTo);
  };

  const filterFormik = useFormikBuilder(fields, handleApplyFilters);

  const selectedAccount = useMemo(
    () => accounts.find((a) => String(a.accountId) === String(filterFormik.values.accountId)) ?? null,
    [accounts, filterFormik.values.accountId]
  );

  useEffect(() => {
    ApiService.getAccounts().then(({ success, data }) => {
      if (success && data?.length) {
        setAccounts(data);
      }
    });
    // eslint-disable-next-line
  }, []);

  // Default the date range to the current financial month on load (and whenever
  // the company's current period changes).
  useEffect(() => {
    const range = finMonthRange(company);
    if (range) {
      filterFormik.setFieldValue("dateFrom", range.from);
      filterFormik.setFieldValue("dateTo", range.to);
    }
    // eslint-disable-next-line
  }, [company]);

  const handlePrint = () => window.print();

  const handleClearFilters = () => {
    const range = finMonthRange(company);
    filterFormik.setFieldValue("dateFrom", range?.from ?? "");
    filterFormik.setFieldValue("dateTo", range?.to ?? "");
    filterFormik.setFieldValue("accountId", "");
    setUiData({ loading: false, data: [], error: "" });
    setSummary({ openingBalance: 0, totalDebits: 0, totalCredits: 0, closingBalance: 0 });
  };

  const subtitle = useMemo(() => {
    const lines = uiData.data.flatMap((g) => g.lines ?? []);
    if (!lines.length) return "All transactions for selected account";
    const latest = lines.reduce((a, b) => (a.txnDate > b.txnDate ? a : b));
    const d = new Date(latest.txnDate);
    return `All transactions for selected account · ${MONTH_NAMES[d.getMonth()]} ${d.getFullYear()} YTD`;
  }, [uiData.data]);

  const columns = [
    {
      header: "DATE",
      field: "txnDate",
      type: "date",
      class: "text-nowrap",
    },
    {
      header: "JOURNAL",
      field: "journalRef",
      class: "text-nowrap",
      render: (row) => (
        <span
          className="ml-mono-primary cursor-pointer"
          onClick={() => navigate(`/journals/edit/${row.transactionId}`)}
        >
          {row.journalRef}
        </span>
      ),
    },
    { header: "REFERENCE",   field: "reference" },
    { header: "DESCRIPTION", field: "description" },
    {
      header: "DEBIT",
      field: "debit",
      class: "text-end text-nowrap",
      render: (row) => <span className="ml-mono-dim">{fmtAmount(row.debit)}</span>,
    },
    {
      header: "CREDIT",
      field: "credit",
      class: "text-end text-nowrap",
      render: (row) => <span className="ml-mono-dim">{fmtAmount(row.credit)}</span>,
    },
    {
      header: "RUNNING",
      field: "runningBalance",
      class: "text-end text-nowrap",
      render: (row) => <RunningBalance value={row.runningBalance} />,
    },
  ];

  return (
    <MeridianPage title="General Ledger">
      <p className="ml-page-subtitle">{subtitle}</p>
      <div className="ml-page-actions">
        <button
          className="ml-btn-ghost"
          onClick={handlePrint}
          disabled={uiData.loading || !uiData.data.length}
        >
          <i className="bi bi-printer" aria-hidden="true" />
          Print
        </button>
      </div>
      <form className="row g-2 align-items-end mb-3" onSubmit={filterFormik.handleSubmit}>
        <FieldsRenderer fields={fields} formik={filterFormik} />
        <div className="col-12 col-md-auto d-flex gap-2 ms-md-auto">
          <button type="submit" className="ml-btn-action ml-fab" disabled={uiData.loading}>
            Apply
          </button>
          <button type="button" className="ml-btn-ghost" onClick={handleClearFilters} disabled={uiData.loading}>
            Clear
          </button>
        </div>
      </form>
      {/* <div className="gl-stat-row">
        <StatCard label="OPENING BALANCE" value={summary.openingBalance} />
        <StatCard label="TOTAL DEBITS"    value={summary.totalDebits} />
        <StatCard label="TOTAL CREDITS"   value={summary.totalCredits} />
        <StatCard label="CLOSING BALANCE" value={summary.closingBalance} accent />
      </div> */}

      <DataTable
        columns={columns}
        data={uiData.data}
        loading={uiData.loading}
        name="GeneralLedger"
        showHeader={false}
        pageSizeOptions={[10, 25, 50]}
        // //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
        grouping={{
          childrenField: "lines",
          groupKey: (g) => g.account?.accountId,
          groupRowClassName: (g) => `gl-grp gl-grp-${g.account?.accountType ?? "X"}`,
          collapsible: true,
          defaultExpanded: true,
          groupHeaderCells: (g) => [
            {
              colSpan: columns.length - 3,
              content: (
                <span className="gl-group-acct">
                  <span className="gl-account-code">{g.account?.accountCode}</span>
                  <span className="gl-group-name">{g.account?.accountName}</span>
                  {g.account?.accountType && (
                    <span className="gl-account-type">
                      {TYPE_LABELS[g.account.accountType] ?? g.account.accountType}
                    </span>
                  )}
                  <span className="gl-group-opening">Opening {fmtAmount(g.opbl)}</span>
                </span>
              ),
            },
            {
              className: "text-end text-nowrap",
              content: <span className="gl-group-total">{fmtAmount(g.debit)}</span>,
            },
            {
              className: "text-end text-nowrap",
              content: <span className="gl-group-total">{fmtAmount(g.credit)}</span>,
            },
            {
              className: "text-end text-nowrap",
              content: <RunningBalance value={g.clbl} />,
            },
          ],
        }}
      />

      <GeneralLedgerPrint
        account={selectedAccount}
        dateFrom={filterFormik.values.dateFrom}
        dateTo={filterFormik.values.dateTo}
        groups={uiData.data}
        summary={summary}
      />
    </MeridianPage>
  );
}

export default GeneralLedger;
