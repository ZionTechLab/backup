const crypto = require('crypto');
const { AppError } = require('../middleware/errorHandler');

const HEADER = 'gl_transactions';
const DETAIL = 'gl_transactionDetail';

function round2(n) {
  return Math.round((Number(n) + Number.EPSILON) * 100) / 100;
}

// Validates a set of detail lines balances in base currency.
function assertBalanced(details) {
  if (!Array.isArray(details) || details.length < 2) {
    throw new AppError('At least two detail lines are required', 400);
  }
  let debit = 0;
  let credit = 0;
  for (const d of details) {
    const dr = Number(d.debitAmount || 0);
    const cr = Number(d.creditAmount || 0);
    if (dr < 0 || cr < 0) throw new AppError('Amounts cannot be negative', 400);
    if (dr > 0 && cr > 0) throw new AppError('A line cannot have both debit and credit', 400);
    if (dr === 0 && cr === 0) throw new AppError('A line must have a debit or credit amount', 400);
    const rate = Number(d.exchangeRate || 1);
    debit += dr * rate;
    credit += cr * rate;
  }
  if (round2(debit) !== round2(credit)) {
    throw new AppError(`Debits (${round2(debit)}) do not equal credits (${round2(credit)})`, 400);
  }
}

// Resolves the financial period for a date and confirms it is open.
async function resolveFinPeriod(trx, companyId, txnDate) {
  const row = await trx('gl_financialMonths')
    .where({ companyId })
    .andWhere('startDate', '<=', txnDate)
    .andWhere('endDate', '>=', txnDate)
    .first();
  if (!row) throw new AppError(`No financial period for ${txnDate}`, 400);
  if (row.isClosed) throw new AppError('Financial period is closed', 400);
  return { fnYear: row.fnYear, fnMonth: row.fnMonth };
}

// Posts a balanced double entry to the GL inside the caller's transaction.
// Reuses the caller's docType/txnType/docNo so the GL row links to the source
// document. Returns the new gl_transactions id.
async function postGl(trx, opts) {
  const {
    tenantId, companyId, docType, txnType, docNo, txnDate,
    reference = null, description = null, updatedBy = null,
    status = 'Posted', details,
  } = opts;

  assertBalanced(details);
  const { fnYear, fnMonth } = await resolveFinPeriod(trx, companyId, txnDate);

  const transactionId = crypto.randomUUID();
  await trx(HEADER).insert({
    transactionId, tenantId, companyId, fnYear, fnMonth,
    docType, txnType, docNo, txnDate, reference, description,
    status, updatedBy, updatedAt: new Date(),
  });

  let lineNo = 0;
  const detailRows = details.map((d) => {
    lineNo += 1;
    const debit = Number(d.debitAmount || 0);
    const credit = Number(d.creditAmount || 0);
    const rate = Number(d.exchangeRate || 1);
    return {
      lineId: lineNo,
      transactionId,
      tenantId,
      companyId,
      fnYear,
      fnMonth,
      docType,
      txnType,
      docNo,
      txnDate,
      lineNo,
      accountId: d.accountId,
      debitAmount: debit,
      creditAmount: credit,
      currencyCode: d.currencyCode,
      exchangeRate: rate,
      rateTypeId: d.rateTypeId || null,
      debitBase: round2(debit * rate),
      creditBase: round2(credit * rate),
      costCenter: d.costCenter || null,
      profitCenter: d.profitCenter || null,
      description: d.description || null,
    };
  });

  if (detailRows.length > 0) {
    await trx(DETAIL).insert(detailRows);
  }

  return transactionId;
}

// Voids a posted GL transaction. Marks Void, keeps the audit trail.
async function voidGl(trx, transactionId, updatedBy = null) {
  if (!transactionId) return;
  await trx(HEADER).where({ transactionId }).update({
    status: 'Void', updatedBy, updatedAt: new Date(),
  });
}

module.exports = { postGl, voidGl, assertBalanced, resolveFinPeriod, round2 };
