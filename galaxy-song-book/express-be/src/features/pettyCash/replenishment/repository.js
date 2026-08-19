const crypto = require('crypto');
const db = require('../../../database');
const { getNextSerialNo } = require('../../../repository/getNextSerialNo');
const { snapshotBefore, snapshotInsert } = require('../../../repository/auditHistory');
const { pickFields } = require('../../../repository/pickFields');
const { postGl, voidGl, round2 } = require('../../../repository/glPosting');
const workflow = require('../../../repository/workflow');
const { AppError } = require('../../../middleware/errorHandler');

const TABLE = 'pc_txn_replenishment';
const DOC = 'PRPL';

const FIELDS = ['cashBookId', 'requestDate', 'amountRequested', 'periodFrom',
  'periodTo', 'bankTransferRef', 'bankGlAccountId'];

// Denormalized inbox label for the workflow engine.
async function buildDisplay(trx, row) {
  const book = row.cashBookId
    ? await trx('pc_mas_cashBook').where({ cashBookId: row.cashBookId }).first('code')
    : null;
  const amt = row.amountRequested != null ? Number(row.amountRequested).toLocaleString() : '';
  const summary = [book?.code, amt].filter(Boolean).join(' | ');
  return { docNo: `PRPL/${row.docNo}`, summary };
}

// Runs a workflow Approve action at the replenishment's current level and
// reports whether that was the final configured level (fully Approved) or an
// earlier one (still Verified, awaiting the next level).
async function actLevel(trx, ctx, row, data) {
  const state = await workflow.getState(DOC, row.replenishmentId, trx);
  if (!state) throw new AppError('No approval flow for this replenishment', 400);
  const levels = await workflow.getLevels(trx, ctx, DOC, row.amountRequested);
  const idx = levels.findIndex((l) => l.levelNo === state.currentLevel);
  const isFinal = idx === -1 || idx === levels.length - 1;
  const display = await buildDisplay(trx, row);
  await workflow.act(trx, ctx, {
    docType: DOC, docId: row.replenishmentId, action: workflow.WF_ACTION.APPROVE,
    amount: row.amountRequested, comment: data.comment ?? null, ...display,
  });
  return isFinal;
}

// Posted GL balance for an account: SUM(debitBase) - SUM(creditBase).
async function bookBalance(trx, glAccountId) {
  const row = await trx('gl_transactionDetail as d')
    .join('gl_transactions as h', 'h.transactionId', 'd.transactionId')
    .where({ 'h.status': 'Posted', 'd.accountId': glAccountId })
    .select(
      trx.raw('COALESCE(SUM(d.debitBase), 0) - COALESCE(SUM(d.creditBase), 0) as balance')
    )
    .first();
  return round2(row ? row.balance : 0);
}

const repo = {
  async getUi(ctx = {}) {
    const cashBooks = await db('pc_mas_cashBook')
      .select('cashBookId', 'code', 'name', 'currencyCode', 'glAccountId', 'floatLimit')
      .where({ tenantId: ctx.tenantId, companyId: ctx.companyId, isActive: true, deleted: false })
      .orderBy('code');
    const bankAccounts = await db('gl_chartOfAccounts')
      .select('accountId', 'accountCode', 'accountName')
      .where({ isActive: true, tenantId: ctx.tenantId })
      .orderBy('accountCode');
    return { cashBooks, bankAccounts };
  },

  async getAll(filters = {}) {
    return db(`${TABLE} as r`)
      .select(
        'r.replenishmentId', 'r.docNo', 'r.requestDate', 'r.cashBookId',
        'r.amountRequested', 'r.status', 'r.periodFrom', 'r.periodTo',
        'cb.code as cashBookCode', 'cb.name as cashBookName',
        db.raw("'PRPL/' || r.docNo as replenishmentNo")
      )
      .leftJoin('pc_mas_cashBook as cb', 'cb.cashBookId', 'r.cashBookId')
      .where({ 'r.tenantId': filters.tenantId, 'r.companyId': filters.companyId })
      .orderBy([{ column: 'r.requestDate', order: 'desc' }, { column: 'r.docNo', order: 'desc' }]);
  },

  async get(filters = {}, conn = db) {
    const row = await conn(TABLE).where({ replenishmentId: filters.id }).first();
    if (!row) return null;
    const approval = await workflow.getHistory(DOC, filters.id, conn);
    return { ...row, approval };
  },

  async update(data) {
    return db.transaction(async (trx) => {
      if (data.isUpdate) {
        const existing = await trx(TABLE).where({ replenishmentId: data.replenishmentId }).first();
        if (!existing) throw new AppError('Not found', 404);
        if (existing.status !== 'Requested') throw new AppError('Only Requested replenishments can be edited', 409);

        await snapshotBefore(trx, TABLE, { replenishmentId: data.replenishmentId }, data.userId, 'UPDATE');
        await trx(TABLE).where({ replenishmentId: data.replenishmentId }).update({
          ...pickFields(data, FIELDS),
          updatedBy: data.userId ?? null,
          updatedAt: new Date(),
        });
        return repo.get({ id: data.replenishmentId }, trx);
      }

      // New draft.
      const book = await trx('pc_mas_cashBook')
        .where({ cashBookId: data.cashBookId, deleted: false })
        .first();
      if (!book) throw new AppError('Cash book not found', 404);

      const currentBalance = await bookBalance(trx, book.glAccountId);
      const docNo = await getNextSerialNo(trx, DOC, DOC);
      const replenishmentId = crypto.randomUUID();

      await trx(TABLE).insert({
        ...pickFields(data, FIELDS),
        replenishmentId,
        tenantId: data.tenantId,
        companyId: data.companyId,
        docType: DOC,
        txnType: DOC,
        docNo,
        currentBalance,
        status: 'Requested',
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      await snapshotInsert(trx, TABLE, { replenishmentId }, data.userId);

      // Enter the approval workflow at its first configured level. With no
      // active level configured, the engine auto-approves and the
      // replenishment goes straight to Approved, ready to post.
      const ctx = { tenantId: data.tenantId, companyId: data.companyId, userId: data.userId };
      const display = await buildDisplay(trx, { replenishmentId, docNo, cashBookId: data.cashBookId, amountRequested: data.amountRequested });
      const wfState = await workflow.start(trx, ctx, DOC, replenishmentId, data.amountRequested, display);
      if (wfState?.autoApproved) {
        await trx(TABLE).where({ replenishmentId }).update({
          status: 'Approved',
          approvedAt: new Date(),
        });
      }

      return repo.get({ id: replenishmentId }, trx);
    });
  },

  // Verify (level 1) and Approve (level 2) both run the same underlying
  // workflow action; actLevel() reports whether the level just actioned was
  // the last configured one, which decides which status name applies.
  async verify(data) {
    return db.transaction(async (trx) => {
      const row = await trx(TABLE).where({ replenishmentId: data.id }).first();
      if (!row) throw new AppError('Not found', 404);
      if (row.status !== 'Requested') throw new AppError('Only Requested can be verified', 409);
      const ctx = { tenantId: row.tenantId, companyId: row.companyId, userId: data.userId };
      const isFinal = await actLevel(trx, ctx, row, data);
      await snapshotBefore(trx, TABLE, { replenishmentId: data.id }, data.userId, 'VERIFY');
      const now = new Date();
      const updates = isFinal
        ? { status: 'Approved', approvedBy: data.userId ?? null, approvedAt: now }
        : { status: 'Verified', verifiedBy: data.userId ?? null, verifiedAt: now };
      await trx(TABLE).where({ replenishmentId: data.id }).update({
        ...updates, updatedBy: data.userId ?? null, updatedAt: now,
      });
      return repo.get({ id: data.id }, trx);
    });
  },

  async approve(data) {
    return db.transaction(async (trx) => {
      const row = await trx(TABLE).where({ replenishmentId: data.id }).first();
      if (!row) throw new AppError('Not found', 404);
      if (row.status !== 'Verified') throw new AppError('Only Verified can be approved', 409);
      const ctx = { tenantId: row.tenantId, companyId: row.companyId, userId: data.userId };
      await actLevel(trx, ctx, row, data);
      await snapshotBefore(trx, TABLE, { replenishmentId: data.id }, data.userId, 'APPROVE');
      await trx(TABLE).where({ replenishmentId: data.id }).update({
        status: 'Approved',
        approvedBy: data.userId ?? null,
        approvedAt: new Date(),
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      return repo.get({ id: data.id }, trx);
    });
  },

  async post(data) {
    return db.transaction(async (trx) => {
      const row = await trx(TABLE).where({ replenishmentId: data.id }).first();
      if (!row) throw new AppError('Not found', 404);
      if (row.status !== 'Approved') throw new AppError('Only Approved replenishments can be posted', 409);
      if (!row.bankGlAccountId) throw new AppError('Bank GL account is required to post', 400);

      const book = await trx('pc_mas_cashBook')
        .where({ cashBookId: row.cashBookId, deleted: false })
        .first();
      if (!book) throw new AppError('Cash book not found', 404);

      const currencyCode = book.currencyCode || 'LKR';
      const amount = Number(row.amountRequested || 0);

      const details = [
        {
          accountId: book.glAccountId,
          debitAmount: amount,
          creditAmount: 0,
          currencyCode,
          exchangeRate: 1,
        },
        {
          accountId: row.bankGlAccountId,
          debitAmount: 0,
          creditAmount: amount,
          currencyCode,
          exchangeRate: 1,
        },
      ];

      const glTransactionId = await postGl(trx, {
        tenantId: row.tenantId,
        companyId: row.companyId,
        docType: DOC,
        txnType: DOC,
        docNo: row.docNo,
        txnDate: row.requestDate,
        reference: `PRPL/${row.docNo}`,
        description: 'Float top-up',
        updatedBy: data.userId,
        details,
      });

      await trx(TABLE).where({ replenishmentId: data.id }).update({
        status: 'Posted',
        glTransactionId,
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      return repo.get({ id: data.id }, trx);
    });
  },

  async cancel(data) {
    return db.transaction(async (trx) => {
      const row = await trx(TABLE).where({ replenishmentId: data.id }).first();
      if (!row) throw new AppError('Not found', 404);
      if (row.status === 'Cancelled') return 'success';
      const ctx = { tenantId: row.tenantId, companyId: row.companyId, userId: data.userId };
      const state = await workflow.getState(DOC, data.id, trx);
      if (state && state.status === workflow.WF_STATUS.PENDING) {
        await workflow.act(trx, ctx, { docType: DOC, docId: data.id, action: workflow.WF_ACTION.CANCEL, amount: row.amountRequested });
      }
      await snapshotBefore(trx, TABLE, { replenishmentId: data.id }, data.userId, 'DELETE');
      if (row.glTransactionId) await voidGl(trx, row.glTransactionId, data.userId);
      await trx(TABLE).where({ replenishmentId: data.id }).update({
        status: 'Cancelled',
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      return 'success';
    });
  },
};

module.exports = repo;
