import { useEffect, useMemo, useRef, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import * as Yup from "yup";
import InputField from "../../../../components/InputField";
import { useFormikBuilder } from "../../../../helpers/formikBuilder";
import { DataGrid } from "../../../../components/DataGrid";
import MeridianPage from "../../MeridianPage";
import ApiService from "./service";
import ChartOfAccountsService from "../../Masters/ChartOfAccounts/service";
import CurrencyService from "../../Masters/Currency/service";
import MessageBoxService from "../../../../services/MessageBoxService";
import sanitizeAmountFields from "../../../../helpers/sanitizeAmountFields";
import transformDateFields, { toDateOnly, todayISO } from "../../../../helpers/transformDateFields";
import { formatAmountInput } from "../../../../helpers/formatAmount";
import config from "../../../../config/config";


const STATUS = { DRAFT: "Draft", POSTED: "Posted" };

const fields = {
  txnDate: {
    name: "txnDate", type: "date", placeholder: "Date",
    initialValue: todayISO(),
    validation: Yup.string().required("Date is required"),
    className: "col-md-3",
  },
  reference: {
    name: "reference", type: "text", placeholder: "Reference",
    initialValue: "",
    className: "col-md-3",
  },
  description: {
    name: "description", type: "text", placeholder: "Narration", 
    initialValue: "",
    className: "col-md-6",
  },
};

function toNum(v) {
  if (v === null || v === undefined || v === "") return 0;
  const n = Number(String(v).replace(/,/g, ""));
  return Number.isFinite(n) ? n : 0;
}


function emptyLine() {
  return { accountId: "", description: "", debitAmount: "", creditAmount: "", currencyCode: "LKR", exchangeRate: "1" };
}

export default function AddJournal() {
  const { id }   = useParams();
  const navigate = useNavigate();
  const isEdit   = Boolean(id);
  const gridRef  = useRef();


  // const [transactionId, setTxnId] = useState(null);
  const [lines, setLines]         = useState([emptyLine(), emptyLine()]);
  const [accounts, setAccounts]   = useState([]);
  const [currencies, setCcys]     = useState([]);
  const [saving, setSaving]       = useState(false);
  const statusRef                 = useRef(STATUS.DRAFT);

  const handleSubmit = async (values) => {
    const status = statusRef.current;
    const err = validateLines();
    if (err) {
      MessageBoxService.show({ message: err, type: "warning" });
      return;
    }
    if (status === STATUS.POSTED && !balanced) {
      MessageBoxService.show({
        message: "Debits and credits must balance before posting.",
        type: "warning",
      });
      return;
    }

    const txnDate = toDateOnly(values.txnDate);
    if (!txnDate) {
      MessageBoxService.show({ message: "Enter a valid transaction date.", type: "warning" });
      return;
    }
    const [yy, mm] = txnDate.split("-");
    const param = {
      isUpdate:      isEdit,
      transactionId: id ,
      fnYear:       Number(yy),
      fnMonth:      Number(mm),
      docType:       "JV",
      txnType:       "JV",
      txnDate,
      reference:     values.reference,
      description:   values.description,
      status,
      details: lines
        .filter((l) => l.accountId)
        .map((l) => ({
          accountId:    l.accountId,
          debitAmount:  toNum(l.debitAmount),
          creditAmount: toNum(l.creditAmount),
          currencyCode: l.currencyCode,
          exchangeRate: toNum(l.exchangeRate) || 1,
          description:  l.description,
        })),
    };
    setSaving(true);
    const response = await ApiService.update(param);
    setSaving(false);
    const { success, data } = response;
    if (success) {
      MessageBoxService.show({
        message: status === STATUS.POSTED ? "Journal posted." : "Draft saved.",
        type: "success",
        onClose: () => {
          if (config.features.returnToListAfterSave) {
            navigate("/journals");
          } else if (!id && data?.transactionId) {
            navigate(`/journals/edit/${data.transactionId}`);
          }
        },
      });
    }
  };

  const formik = useFormikBuilder(fields, handleSubmit);




  useEffect(() => {
    ChartOfAccountsService.getAll().then(({ success, data }) => {
      if (success) setAccounts(data ?? []);
    });
    CurrencyService.getAll().then(({ success, data }) => {
      if (success) setCcys(data ?? []);
    });
    if (id) {
      const fetchTxn = async () => {
        const response = await ApiService.get(id);
        if (response.success) {
          if (response.data) {
            const { details, ...formData } = response.data;
            const normalized = transformDateFields(formData, fields);
            formik.setValues({ ...normalized });
            gridRef.current.reset(details); // fires onItemsChange → setLineItems
          }
        }
      };
      fetchTxn();
    }
  
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [id]);

  const accountOptions = useMemo(
    () => accounts.map((a) => ({
      value: a.accountId,
      label: `${a.accountCode} — ${a.accountName}`,
    })),
    [accounts]
  );

  const currencyOptions = useMemo(
    () => (currencies.length
      ? currencies.map((c) => ({ value: c.currencyCode, label: c.currencyCode }))
      : [{ value: "LKR", label: "LKR" }]),
    [currencies]
  );

  const amountInput = (field, oppositeField) => (item, _setField, _idx, setRow) => (
    <input
      type="text"
      inputMode="decimal"
      className="form-control text-end"
      value={formatAmountInput(item[field])}
      onChange={(e) => {
        const val = e.target.value;
        setRow({
          ...item,
          [field]: val,
          [oppositeField]: toNum(val) > 0 ? "" : item[oppositeField],
        });
      }}
      onKeyDown={(e) => {
        if (["e", "E", "+", "-"].includes(e.key)) e.preventDefault();
      }}
      maxLength={15}
    />
  );

  const columns = useMemo(() => ([
    { header: "Account",     field: "accountId",    type: "select", searchable: true, options: accountOptions, placeholder: "Select account...", width: "26%" },
    { header: "Description", field: "description",  type: "text",   placeholder: "Narration" },
    { header: "Debit",       field: "debitAmount",  render: amountInput("debitAmount",  "creditAmount"), width: "12%" },
    { header: "Credit",      field: "creditAmount", render: amountInput("creditAmount", "debitAmount"),  width: "12%" },
    { header: "CCY",         field: "currencyCode", type: "select", options: currencyOptions, width: "90px" },
    { header: "Rate",        field: "exchangeRate", type: "amount", width: "100px" },
  ]), [accountOptions, currencyOptions]);

  const totals = useMemo(() => {
    const debit  = lines.reduce((s, l) => s + toNum(l.debitAmount)  * (toNum(l.exchangeRate) || 1), 0);
    const credit = lines.reduce((s, l) => s + toNum(l.creditAmount) * (toNum(l.exchangeRate) || 1), 0);
    return { debit, credit, diff: debit - credit };
  }, [lines]);

  const balanced = Math.abs(totals.diff) < 0.005;

  const validateLines = () => {
    const cleaned = lines.filter((l) => l.accountId);
    if (cleaned.length < 2) return "Add at least two lines with accounts.";
    const anyAmount = cleaned.some((l) => toNum(l.debitAmount) || toNum(l.creditAmount));
    if (!anyAmount) return "Enter debit or credit amounts.";
    if (cleaned.some((l) => !l.currencyCode)) return "Select a currency for every line.";
    return null;
  };

  const triggerSave = (status) => {
    statusRef.current = status;
    formik.handleSubmit();
  };

  return (
    <MeridianPage
      title={isEdit ? "Edit Journal Entry" : "New Journal Entry"}
      backTo="/journals"
      cardClass="ml-form-card"
      actions={
        <>
          <button
            type="button"
            className="ml-btn-ghost ml-fab-1"
            onClick={() => triggerSave(STATUS.DRAFT)}
            disabled={saving}
          >
            <i className="bi bi-save" aria-hidden="true" />
            Save Draft
          </button>
          <button
            type="button"
            className="ml-btn-action ml-fab"
            onClick={() => triggerSave(STATUS.POSTED)}
            disabled={saving || !balanced}
          >
            <i className="bi bi-check-lg" aria-hidden="true" />
            Post Entry
          </button>
        </>
      }
    >
      <div className="mb-3">
        <form onSubmit={formik.handleSubmit}>
          <div className="ml-form-section border-bottom-0">
            <div className="ml-form-section-label">Entry Details</div>
            <div className="row g-3">
              <InputField {...fields.txnDate}     formik={formik} />
              <InputField {...fields.reference}   formik={formik} />
              <InputField {...fields.description} formik={formik} />
            </div>
          </div>
        </form>
      </div>

      <div className="ml-screen-card overflow-hidden ml-jv-lines">
        <div className="ml-form-section-label">Lines</div>
        <div className="ml-jv-lines-grid">
          <DataGrid
            ref={gridRef}
            columns={columns}
            initialItems={lines}
            onItemsChange={setLines}
          />
        </div>

        <div className="ml-jv-footer">
          <div />
          <div className="ml-jv-totals">
            <div className="ml-jv-total-cell">
              <span className="ml-jv-total-label">Total Debit</span>
              <span className="ml-mono-dim">{totals.debit.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 })}</span>
            </div>
            <div className="ml-jv-total-cell">
              <span className="ml-jv-total-label">Total Credit</span>
              <span className="ml-mono-dim">{totals.credit.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 })}</span>
            </div>
            <div className="ml-jv-total-cell">
              <span className="ml-jv-total-label">Difference</span>
              <span className={balanced ? "ml-badge ml-badge-open" : "ml-badge ml-badge-void"}>
                {balanced ? "Balanced" : totals.diff.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
              </span>
            </div>
          </div>
        </div>
      </div>
    </MeridianPage>
  );
}
