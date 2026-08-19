const crypto = require('crypto');
const db = require('../../../database');
const { getNextSerialNo } = require('../../../repository/getNextSerialNo');
const { snapshotBefore, snapshotInsert } = require('../../../repository/auditHistory');
const { pickFields } = require('../../../repository/pickFields');
const { postGl, voidGl, round2 } = require('../../../repository/glPosting');
const { AppError } = require('../../../middleware/errorHandler');

const TABLE = 'pc_txn_cashCount';
const DENOM = 'pc_txn_cashCountDenom';
const DOC = 'PCNT';

const FIELDS = ['cashBookId', 'countDate', 'reason', 'photoPath'];

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

async function getDenomLines(trx, cashCountId) {
  return trx(DENOM)
    .where({ cashCountId })
    .orderBy('lineNo');
}

const repo = {
  async getUi(ctx = {}) {
    const cashBooks = await db('pc_mas_cashBook')
      .select('cashBookId', 'code', 'name', 'currencyCode', 'glAccountId', 'floatLimit')
      .where({ tenantId: ctx.tenantId, companyId: ctx.companyId, isActive: true, deleted: false })
      .orderBy('code');
    return { cashBooks };
  },

  async getAll(filters = {}) {
    return db(`${TABLE} as c`)
      .select(
        'c.cashCountId', 'c.docNo', 'c.countDate', 'c.cashBookId',
        'c.systemBalance', 'c.physicalTotal', 'c.variance', 'c.status',
        'cb.code as cashBookCode', 'cb.name as cashBookName',
        db.raw("'PCNT/' || c.docNo as countNo")
      )
      .leftJoin('pc_mas_cashBook as cb', 'cb.cashBookId', 'c.cashBookId')
      .where({ 'c.tenantId': filters.tenantId, 'c.companyId': filters.companyId })
      .orderBy([{ column: 'c.countDate', order: 'desc' }, { column: 'c.docNo', order: 'desc' }]);
  },

  async get(filters = {}, conn = db) {
    const header = await conn(TABLE).where({ cashCountId: filters.id }).first();
    if (!header) return null;
    const denominations = await conn(DENOM).where({ cashCountId: filters.id }).orderBy('lineNo');
    return { ...header, denominations };
  },

  async update(data) {
    return db.transaction(async (trx) => {
      if (data.isUpdate) {
        const existing = await trx(TABLE).where({ cashCountId: data.cashCountId }).first();
        if (!existing) throw new AppError('Not found', 404);
        if (existing.status !== 'Draft') throw new AppError('Only Draft cash counts can be edited', 409);

        await snapshotBefore(trx, TABLE, { cashCountId: data.cashCountId }, data.userId, 'UPDATE');

        const book = await trx('pc_mas_cashBook')
          .where({ cashBookId: data.cashBookId, deleted: false })
          .first();
        if (!book) throw new AppError('Cash book not found', 404);

        const systemBalance = await bookBalance(trx, book.glAccountId);

        // Recompute physicalTotal from denomination lines.
        await trx(DENOM).where({ cashCountId: data.cashCountId }).del();
        let physicalTotal = 0;
        if (Array.isArray(data.denominations)) {
          for (let i = 0; i < data.denominations.length; i++) {
            const d = data.denominations[i];
            const denomination = Number(d.denomination || 0);
            const count = Number(d.count || 0);
            const lineTotal = round2(denomination * count);
            physicalTotal += lineTotal;
            await trx(DENOM).insert({
              cashCountId: data.cashCountId,
              lineNo: d.lineNo ?? (i + 1),
              denomination,
              count,
              lineTotal,
            });
          }
        }
        physicalTotal = round2(physicalTotal);
        const variance = round2(physicalTotal - systemBalance);

        await trx(TABLE).where({ cashCountId: data.cashCountId }).update({
          ...pickFields(data, FIELDS),
          systemBalance,
          physicalTotal,
          variance,
          updatedBy: data.userId ?? null,
          updatedAt: new Date(),
        });
        return repo.get({ id: data.cashCountId }, trx);
      }

      // New draft.
      const book = await trx('pc_mas_cashBook')
        .where({ cashBookId: data.cashBookId, deleted: false })
        .first();
      if (!book) throw new AppError('Cash book not found', 404);

      const systemBalance = await bookBalance(trx, book.glAccountId);
      const docNo = await getNextSerialNo(trx, DOC, DOC);
      const cashCountId = crypto.randomUUID();

      let physicalTotal = 0;
      const denomRows = [];
      if (Array.isArray(data.denominations)) {
        for (let i = 0; i < data.denominations.length; i++) {
          const d = data.denominations[i];
          const denomination = Number(d.denomination || 0);
          const count = Number(d.count || 0);
          const lineTotal = round2(denomination * count);
          physicalTotal += lineTotal;
          denomRows.push({
            cashCountId,
            lineNo: d.lineNo ?? (i + 1),
            denomination,
            count,
            lineTotal,
          });
        }
      }
      physicalTotal = round2(physicalTotal);
      const variance = round2(physicalTotal - systemBalance);

      await trx(TABLE).insert({
        ...pickFields(data, FIELDS),
        cashCountId,
        tenantId: data.tenantId,
        companyId: data.companyId,
        docType: DOC,
        txnType: DOC,
        docNo,
        systemBalance,
        physicalTotal,
        variance,
        status: 'Draft',
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      await snapshotInsert(trx, TABLE, { cashCountId }, data.userId);

      if (denomRows.length) {
        await trx(DENOM).insert(denomRows);
      }
      return repo.get({ id: cashCountId }, trx);
    });
  },

  async sign(data) {
    return db.transaction(async (trx) => {
      const row = await trx(TABLE).where({ cashCountId: data.id }).first();
      if (!row) throw new AppError('Not found', 404);
      if (row.status !== 'Draft') throw new AppError('Only Draft cash counts can be signed', 409);
      await snapshotBefore(trx, TABLE, { cashCountId: data.id }, data.userId, 'SIGN');
      await trx(TABLE).where({ cashCountId: data.id }).update({
        status: 'Signed',
        cashierSignedBy: data.userId ?? null,
        cashierSignedAt: new Date(),
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      return repo.get({ id: data.id }, trx);
    });
  },

  async countersign(data) {
    return db.transaction(async (trx) => {
      const row = await trx(TABLE).where({ cashCountId: data.id }).first();
      if (!row) throw new AppError('Not found', 404);
      if (row.status !== 'Signed') throw new AppError('Only Signed cash counts can be countersigned', 409);

      const glTransactionId = null;
      const variance = Number(row.variance || 0);

      if (Math.abs(variance) > 0.005) {
        // Variance exists — post to Cash Short / Over.
        const param = await trx('pc_ref_param')
          .where({ companyId: row.companyId, paramGroup: 'SHORT_OVER_GL', paramKey: 'DEFAULT', deleted: false, isActive: true })
          .first();
        if (!param || !param.glAccountId) throw new AppError('Cash Short/Over GL account not configured', 400);

        const book = await trx('pc_mas_cashBook')
          .where({ cashBookId: row.cashBookId, deleted: false })
          .first();
        if (!book) throw new AppError('Cash book not found', 404);

        const currencyCode = book.currencyCode || 'LKR';
        const absVar = round2(Math.abs(variance));
        const details = [];

        if (variance > 0) {
          // Physical > System = surplus → Dr cash, Cr Short/Over
          details.push({ accountId: book.glAccountId, debitAmount: absVar, creditAmount: 0, currencyCode, exchangeRate: 1 });
          details.push({ accountId: param.glAccountId, debitAmount: 0, creditAmount: absVar, currencyCode, exchangeRate: 1 });
        } else {
          // Physical < System = shortage → Dr Short/Over, Cr cash
          details.push({ accountId: param.glAccountId, debitAmount: absVar, creditAmount: 0, currencyCode, exchangeRate: 1 });
          details.push({ accountId: book.glAccountId, debitAmount: 0, creditAmount: absVar, currencyCode, exchangeRate: 1 });
        }

        const glId = await postGl(trx, {
          tenantId: row.tenantId,
          companyId: row.companyId,
          docType: DOC,
          txnType: DOC,
          docNo: row.docNo,
          txnDate: row.countDate,
          reference: `PCNT/${row.docNo}`,
          description: variance > 0 ? 'Cash count surplus' : 'Cash count shortage',
          updatedBy: data.userId,
          details,
        });

        await trx(TABLE).where({ cashCountId: data.id }).update({
          status: 'Countersigned',
          glTransactionId: glId,
          accountantSignedBy: data.userId ?? null,
          accountantSignedAt: new Date(),
          updatedBy: data.userId ?? null,
          updatedAt: new Date(),
        });
      } else {
        // Zero variance — no GL posting needed.
        await trx(TABLE).where({ cashCountId: data.id }).update({
          status: 'Countersigned',
          accountantSignedBy: data.userId ?? null,
          accountantSignedAt: new Date(),
          updatedBy: data.userId ?? null,
          updatedAt: new Date(),
        });
      }
      return repo.get({ id: data.id }, trx);
    });
  },

  async audit(data) {
    return db.transaction(async (trx) => {
      const row = await trx(TABLE).where({ cashCountId: data.id }).first();
      if (!row) throw new AppError('Not found', 404);
      if (row.status !== 'Countersigned') throw new AppError('Only Countersigned cash counts can be audited', 409);
      await snapshotBefore(trx, TABLE, { cashCountId: data.id }, data.userId, 'AUDIT');
      await trx(TABLE).where({ cashCountId: data.id }).update({
        status: 'Audited',
        auditorSignedBy: data.userId ?? null,
        auditorSignedAt: new Date(),
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      return repo.get({ id: data.id }, trx);
    });
  },

  async cancel(data) {
    return db.transaction(async (trx) => {
      const row = await trx(TABLE).where({ cashCountId: data.id }).first();
      if (!row) throw new AppError('Not found', 404);
      if (row.status === 'Cancelled') return 'success';
      await snapshotBefore(trx, TABLE, { cashCountId: data.id }, data.userId, 'DELETE');
      if (row.glTransactionId) await voidGl(trx, row.glTransactionId, data.userId);
      await trx(TABLE).where({ cashCountId: data.id }).update({
        status: 'Cancelled',
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      return 'success';
    });
  },
};

module.exports = repo;
