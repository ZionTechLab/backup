const crypto = require('crypto');
const db = require('../../../database');
const { AppError } = require('../../../middleware/errorHandler');
const { getNextSerialNo } = require('../../../repository/getNextSerialNo');
const { snapshotBefore, snapshotInsert } = require('../../../repository/auditHistory');

const HEADER = 'gl_transactions';
const DETAIL = 'gl_transactionDetail';

function round2(n) {
  return Math.round((Number(n) + Number.EPSILON) * 100) / 100;
}

function assertBalanced(details) {
  if (!Array.isArray(details) || details.length < 2) {
    throw new AppError('At least two detail lines are required', 400);
  }

  let debit = 0;
  let credit = 0;

  for (const d of details) {
    const dr = Number(d.debitAmount  || 0);
    const cr = Number(d.creditAmount || 0);

    if (dr < 0 || cr < 0) throw new AppError('Amounts cannot be negative', 400);
    if (dr > 0 && cr > 0) throw new AppError('A line cannot have both debit and credit', 400);
    if (dr === 0 && cr === 0) throw new AppError('A line must have a debit or credit amount', 400);

    const rate = Number(d.exchangeRate || 1);
    debit  += dr * rate;
    credit += cr * rate;
  }

  if (round2(debit) !== round2(credit)) {
    throw new AppError(`Debits (${round2(debit)}) do not equal credits (${round2(credit)})`, 400);
  }
}

async function insertDetails(trx, header, details) {
  let lineNo = 0;
  for (const d of details) {
    lineNo += 1;
    const debit  = Number(d.debitAmount  || 0);
    const credit = Number(d.creditAmount || 0);
    const rate   = Number(d.exchangeRate || 1);

    await trx(DETAIL).insert({
      lineId:        lineNo,
      transactionId: header.transactionId,
      tenantId:      header.tenantId,
      companyId:     header.companyId,
      fnYear:       header.fnYear,
      fnMonth:      header.fnMonth,
      docType:       header.docType,
      txnType:       header.txnType,
      docNo:         header.docNo,
      txnDate:       header.txnDate,
      lineNo,
      accountId:     d.accountId,
      debitAmount:   debit,
      creditAmount:  credit,
      currencyCode:  d.currencyCode,
      exchangeRate:  rate,
      rateTypeId:    d.rateTypeId || null,
      debitBase:     round2(debit  * rate),
      creditBase:    round2(credit * rate),
      description:   d.description || null,
    });
  }
}

async function loadWithDetails(trx, transactionId) {
  const header = await trx(HEADER).where({ transactionId }).first();
  if (!header) return null;
  const details = await trx(DETAIL).where({ transactionId }).orderBy('lineNo');
  return { ...header, details };
}

const repo = {
  async getAccounts() {
    return db('gl_chartOfAccounts')
      .select('accountId', 'accountCode', 'accountName', 'accountType')
      .where({ isActive: true })
      .orderBy('accountCode');
  },

  async getReport(data) {
    const { accountId, fromDate, toDate } = data;

    // Opening balance query
    const obRow = await db('gl_transactionDetail as d')
      .join('gl_transactions as t', 'd.transactionId', 't.transactionId')
      .where('d.accountId', accountId)
      .where('t.status', 'Posted')
      .where('t.txnDate', '<', fromDate)
      .select(db.raw('COALESCE(SUM(d.debitBase), 0) - COALESCE(SUM(d.creditBase), 0) as openingBalance'))
      .first();

    const openingBalance = Number(obRow?.openingBalance || 0);

    const account = await db('gl_chartOfAccounts')
      .where({ accountId })
      .select('accountId', 'accountCode', 'accountName', 'accountType')
      .first();

    // Report body — detail lines within the requested window
    const rows = await db('gl_transactionDetail as d')
      .join('gl_transactions as t', 'd.transactionId', 't.transactionId')
      .where('d.accountId', accountId)
      .where('t.status', 'Posted')
      .whereBetween('t.txnDate', [fromDate, toDate])
      .select(
        't.txnDate',
        't.txnType',
        't.fnYear',
        't.docNo',
        't.transactionId',
        't.reference',
        db.raw('COALESCE(d.description, t.description) AS description'),
        db.raw('d.debitBase AS debit'),
        db.raw('d.creditBase AS credit')
      )
      .orderBy(['t.txnDate', 't.docNo', 'd.lineNo']);

    let running = openingBalance;
    let totalDebits = 0;
    let totalCredits = 0;

    const lines = rows.map(row => {
      const debit  = Number(row.debit  || 0);
      const credit = Number(row.credit || 0);
      running      += debit - credit;
      totalDebits  += debit;
      totalCredits += credit;
      return {
        txnDate:     row.txnDate,
        journalRef:  `${row.txnType}-${row.fnYear}-${String(row.docNo).padStart(4, '0')}`,
        transactionId: row.transactionId,
        reference:   row.reference,
        description: row.description,
        debit,
        credit,
        runningBalance: running,
      };
    });

    return {
      account,
      openingBalance,
      totalDebits,
      totalCredits,
      closingBalance: openingBalance + totalDebits - totalCredits,
      lines,
    };
  },

  async getAll(tenantId, companyId) {
    // Transaction total = sum of base-currency debits across its detail lines.
    const totals = db(DETAIL)
      .select('transactionId')
      .sum({ totalAmount: 'debitBase' })
      .groupBy('transactionId')
      .as('amt');

    return db({ h: HEADER })
      .select(
        'h.transactionId', 'h.tenantId', 'h.companyId', 'h.fnYear', 'h.fnMonth',
        'h.docType', 'h.txnType', 'h.docNo', 'h.txnDate', 'h.reference',
        'h.description', 'h.status', 'h.updatedBy', 'h.updatedAt',
        db.raw('COALESCE(amt.totalAmount, 0) AS totalAmount'),
        'u.fullName AS createdByName'
      )
      .leftJoin(totals, 'amt.transactionId', 'h.transactionId')
      .leftJoin({ u: 'mas_users' }, 'u.userId', 'h.updatedBy')
      .where({ 'h.tenantId': tenantId, 'h.companyId': companyId })
      .orderBy([{ column: 'h.txnDate', order: 'desc' }, { column: 'h.docNo', order: 'desc' }]);
  },

  async get(filters = {}) {
    return loadWithDetails(db, filters.transactionId);
  },

  async update(data) {
    assertBalanced(data.details);

    return db.transaction(async (trx) => {
      if (data.isUpdate) {
        const existing = await snapshotBefore(trx, HEADER, { transactionId: data.transactionId }, data.userId, 'UPDATE');
        if (!existing) throw new AppError('Not found', 404);

        await trx(HEADER).where({ transactionId: data.transactionId }).update({
          fnYear:     data.fnYear,
          fnMonth:    data.fnMonth,
          docType:     data.docType,
          txnType:     data.txnType,
          txnDate:     data.txnDate,
          reference:   data.reference || null,
          description: data.description || null,
          status:      data.status,
          updatedBy:   data.userId,
          updatedAt:   new Date(),
        });

        const oldLines = await trx(DETAIL).where({ transactionId: data.transactionId });
        for (const line of oldLines) {
          await snapshotBefore(trx, DETAIL, { transactionId: line.transactionId, lineId: line.lineId }, data.userId, 'UPDATE');
        }
        await trx(DETAIL).where({ transactionId: data.transactionId }).delete();

        const header = await trx(HEADER).where({ transactionId: data.transactionId }).first();
        await insertDetails(trx, header, data.details);

        return loadWithDetails(trx, data.transactionId);
      }

      const transactionId = crypto.randomUUID();
      const docNo = await getNextSerialNo(trx, data.docType, data.txnType);

      await trx(HEADER).insert({
        transactionId,
        tenantId:    data.tenantId,
        companyId:   data.companyId,
        fnYear:     data.fnYear,
        fnMonth:    data.fnMonth,
        docType:     data.docType,
        txnType:     data.txnType,
        docNo,
        txnDate:     data.txnDate,
        reference:   data.reference || null,
        description: data.description || null,
        status:      data.status || 'Draft',
        updatedBy:   data.userId,
        updatedAt:   new Date(),
      });
      await snapshotInsert(trx, HEADER, { transactionId }, data.userId);

      const header = await trx(HEADER).where({ transactionId }).first();
      await insertDetails(trx, header, data.details);

      return loadWithDetails(trx, transactionId);
    });
  },

  async delete(data) {
    return db.transaction(async (trx) => {
      const existing = await snapshotBefore(trx, HEADER, { transactionId: data.transactionId }, data.userId, 'DELETE');
      if (!existing) throw new AppError('Not found', 404);

      const oldLines = await trx(DETAIL).where({ transactionId: data.transactionId });
      for (const line of oldLines) {
        await snapshotBefore(trx, DETAIL, { transactionId: line.transactionId, lineId: line.lineId }, data.userId, 'DELETE');
      }

      await trx(HEADER).where({ transactionId: data.transactionId }).update({
        status:    'Void',
        updatedBy: data.userId,
        updatedAt: new Date(),
      });

      return 'success';
    });
  },
};

module.exports = repo;