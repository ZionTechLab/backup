const crypto = require('crypto');
const db = require('../../../database');
const { ensureUnique } = require('../../../repository/validators');
const { snapshotBefore, snapshotInsert } = require('../../../repository/auditHistory');
const { pickFields } = require('../../../repository/pickFields');
const { getNextSerialNo } = require('../../../repository/getNextSerialNo');
const { postGl, voidGl, round2 } = require('../../../repository/glPosting');
const { AppError } = require('../../../middleware/errorHandler');

const TABLE = 'pc_mas_cashBook';
const FLOAT_DOC = 'PFLT';
// isActive is derived from status, so it is not picked from the client.
const FIELDS = ['code', 'name', 'cashierUserId', 'currencyCode', 'glAccountId', 'floatLimit', 'topUpThreshold', 'remarks', 'status', 'branchOrgUnitId', 'minFloat', 'maxFloat', 'iouClosingDays'];

const repo = {
  // Lookups for the cash book form.
  async getUi(ctx = {}) {
    const cashiers = await db('mas_users')
      .select('userId', 'fullName')
      .orderBy('fullName');
    const currencies = await db('sec_currencies')
      .select('currencyCode', 'currencyName', 'symbol')
      .where({ isActive: true })
      .orderBy('currencyCode');
    const accounts = await db('gl_chartOfAccounts')
      .select('accountId', 'accountCode', 'accountName')
      .where({ isActive: true, tenantId: ctx.tenantId })
      .orderBy('accountCode');
    const branches = await db('mas_orgUnit')
      .select('orgUnitId', 'code', 'name')
      .where({ unitType: 'Branch', isActive: true, deleted: false, companyId: ctx.companyId })
      .orderBy('name');
    return { cashiers, currencies, accounts, branches };
  },

  async getAll(filters = {}) {
    return db(`${TABLE} as cb`)
      .select(
        'cb.cashBookId', 'cb.code', 'cb.name', 'cb.cashierUserId', 'cb.currencyCode',
        'cb.glAccountId', 'cb.floatLimit', 'cb.topUpThreshold', 'cb.isActive', 'cb.status', 'cb.remarks',
        'cb.branchOrgUnitId', 'cb.minFloat', 'cb.maxFloat', 'cb.iouClosingDays',
        'u.fullName as cashierName',
        'cur.currencyName',
        'coa.accountCode', 'coa.accountName',
        'br.name as branchName'
      )
      .leftJoin('mas_users as u', 'u.userId', 'cb.cashierUserId')
      .leftJoin('sec_currencies as cur', 'cur.currencyCode', 'cb.currencyCode')
      .leftJoin('gl_chartOfAccounts as coa', 'coa.accountId', 'cb.glAccountId')
      .leftJoin('mas_orgUnit as br', 'br.orgUnitId', 'cb.branchOrgUnitId')
      .where({ 'cb.deleted': false, 'cb.tenantId': filters.tenantId, 'cb.companyId': filters.companyId })
      .orderBy('cb.code');
  },

  async get(filters = {}) {
    return db(TABLE)
      .select('cashBookId', 'code', 'name', 'cashierUserId', 'currencyCode', 'glAccountId', 'floatLimit', 'topUpThreshold', 'isActive', 'status', 'remarks', 'branchOrgUnitId', 'minFloat', 'maxFloat', 'iouClosingDays',
        'establishedFloat', 'establishGlTransactionId', 'establishedAt', 'establishedBy')
      .where({ cashBookId: filters.id, deleted: false })
      .first();
  },

  // Fund the cash book's GL account once: Dr Petty Cash, Cr Bank. Without this
  // the account starts at zero and goes negative as IOUs pay out. Idempotent
  // guard: a book can only be established once, until reversed.
  async establishFloat(data) {
    return db.transaction(async (trx) => {
      const book = await trx(TABLE).where({ cashBookId: data.cashBookId, deleted: false }).first();
      if (!book) throw new AppError('Cash book not found', 404);
      if (book.establishGlTransactionId) throw new AppError('Float already established for this cash book', 409);

      const amount = round2(Number(data.amount || 0));
      if (amount <= 0) throw new AppError('Establishment amount must be greater than zero', 400);
      if (!data.bankGlAccountId) throw new AppError('Contra (bank / equity) account is required', 400);
      if (data.bankGlAccountId === book.glAccountId) throw new AppError('Contra account must differ from the cash book account', 400);

      const txnDate = data.date || new Date().toISOString().split('T')[0];
      const docNo = await getNextSerialNo(trx, FLOAT_DOC, FLOAT_DOC);
      const glTransactionId = await postGl(trx, {
        tenantId: book.tenantId, companyId: book.companyId,
        docType: FLOAT_DOC, txnType: FLOAT_DOC, docNo,
        txnDate,
        reference: `PFLT/${docNo}`,
        description: `Establish float ${book.code}`,
        updatedBy: data.userId,
        details: [
          { accountId: book.glAccountId, debitAmount: amount, creditAmount: 0, currencyCode: book.currencyCode, exchangeRate: 1 },
          { accountId: data.bankGlAccountId, debitAmount: 0, creditAmount: amount, currencyCode: book.currencyCode, exchangeRate: 1 },
        ],
      });

      await snapshotBefore(trx, TABLE, { cashBookId: book.cashBookId, deleted: false }, data.userId, 'UPDATE');
      await trx(TABLE).where({ cashBookId: book.cashBookId }).update({
        establishedFloat: amount,
        establishGlTransactionId: glTransactionId,
        establishedAt: new Date(),
        establishedBy: data.userId ?? null,
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      return trx(TABLE).where({ cashBookId: book.cashBookId }).first();
    });
  },

  // Undo an establishment. Voids the opening entry and clears the stamp. Blocked
  // once the book carries real activity, so the opening entry stays consistent
  // with what follows it.
  async reverseFloat(data) {
    return db.transaction(async (trx) => {
      const book = await trx(TABLE).where({ cashBookId: data.id, deleted: false }).first();
      if (!book) throw new AppError('Cash book not found', 404);
      if (!book.establishGlTransactionId) throw new AppError('Float is not established', 409);

      const used = await trx('pc_txn_voucher').where({ cashBookId: book.cashBookId }).first()
        || await trx('pc_txn_iou').where({ cashBookId: book.cashBookId }).first()
        || await trx('pc_txn_replenishment').where({ cashBookId: book.cashBookId }).first();
      if (used) throw new AppError('Cash book has activity. Reverse those transactions before the float.', 409);

      await voidGl(trx, book.establishGlTransactionId, data.userId);
      await snapshotBefore(trx, TABLE, { cashBookId: book.cashBookId, deleted: false }, data.userId, 'UPDATE');
      await trx(TABLE).where({ cashBookId: book.cashBookId }).update({
        establishedFloat: null,
        establishGlTransactionId: null,
        establishedAt: null,
        establishedBy: null,
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      return 'success';
    });
  },

  async update(data) {
    return db.transaction(async (trx) => {
      if (data.isUpdate) {
        const id = data.cashBookId;
        await ensureUnique(trx, TABLE, { companyId: data.companyId, name: data.name }, { cashBookId: id }, 'Cash book name already exists.');
        await ensureUnique(trx, TABLE, { companyId: data.companyId, code: data.code }, { cashBookId: id }, 'Cash book code already exists.');
        await snapshotBefore(trx, TABLE, { cashBookId: id, deleted: false }, data.userId, 'UPDATE');
        await trx(TABLE).where({ cashBookId: id, deleted: false }).update({
          ...pickFields(data, FIELDS),
          isActive: (data.status ?? 'Active') === 'Active',
          updatedBy: data.userId ?? null,
          updatedAt: new Date(),
        });
        return trx(TABLE).where({ cashBookId: id }).first();
      }

      await ensureUnique(trx, TABLE, { companyId: data.companyId, name: data.name }, null, 'Cash book name already exists.');
      await ensureUnique(trx, TABLE, { companyId: data.companyId, code: data.code }, null, 'Cash book code already exists.');

      const cashBookId = crypto.randomUUID();
      await trx(TABLE).insert({
        ...pickFields(data, FIELDS),
        isActive: (data.status ?? 'Active') === 'Active',
        cashBookId,
        tenantId: data.tenantId,
        companyId: data.companyId,
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      await snapshotInsert(trx, TABLE, { cashBookId }, data.userId);
      return trx(TABLE).where({ cashBookId }).first();
    });
  },

  async delete(data) {
    return db.transaction(async (trx) => {
      // Block if the book already carries transactions.
      const used = await trx('pc_txn_voucher').where({ cashBookId: data.id }).first()
        || await trx('pc_txn_iou').where({ cashBookId: data.id }).first();
      if (used) {
        const err = new Error('Cash book has transactions and cannot be deleted.');
        err.statusCode = 409;
        throw err;
      }
      await snapshotBefore(trx, TABLE, { cashBookId: data.id, deleted: false }, data.userId, 'DELETE');
      await trx(TABLE).where({ cashBookId: data.id, deleted: false }).update({ deleted: true });
      return 'success';
    });
  },
};

module.exports = repo;
