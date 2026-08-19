const db = require('../../../database');
const { getNextSerialNo } = require('../../../repository/getNextSerialNo');
const { snapshotBefore, snapshotInsert } = require('../../../repository/auditHistory');
const { pickFields } = require('../../../repository/pickFields');
const { postGl, voidGl, round2 } = require('../../../repository/glPosting');
const { AppError } = require('../../../middleware/errorHandler');

const HEADER = 'pc_txn_voucher';
const DETAIL = 'pc_txn_voucherDetail';
const DOC = 'PCV';

const HEAD_FIELDS = ['cashBookId', 'voucherDate', 'payeePartyType', 'payeePartyId', 'payeeName', 'payeeNic', 'costCenterCode', 'jobNo', 'description', 'currencyCode', 'exchangeRate', 'receiptPath', 'remarks'];
const LINE_FIELDS = ['categoryId', 'description', 'qty', 'unitPrice', 'netAmount', 'vatAmount', 'lineTotal', 'costCenterCode'];

function totalsOf(lines) {
  let subTotal = 0;
  let vatTotal = 0;
  let totalAmount = 0;
  for (const l of lines) {
    subTotal += Number(l.netAmount || 0);
    vatTotal += Number(l.vatAmount || 0);
    totalAmount += Number(l.lineTotal || 0);
  }
  return { subTotal: round2(subTotal), vatTotal: round2(vatTotal), totalAmount: round2(totalAmount) };
}

const repo = {
  async getUi(ctx = {}) {
    const cashBooks = await db('pc_mas_cashBook')
      .select('cashBookId', 'code', 'name', 'currencyCode', 'glAccountId')
      .where({ tenantId: ctx.tenantId, companyId: ctx.companyId, isActive: true, deleted: false })
      .orderBy('code');
    const categories = await db('pc_ref_expenseCategory')
      .select('categoryId', 'name', 'taxMode', 'taxRate')
      .where({ tenantId: ctx.tenantId, companyId: ctx.companyId, isActive: true, deleted: false })
      .orderBy('name');
    const parties = await db('mas_businessPartner')
      .select('businessPartnerId', 'partnerName')
      .orderBy('partnerName');
    const centers = await db('gl_centers')
      .select('centerCode', 'centerName')
      .where({ companyId: ctx.companyId, isActive: true })
      .orderBy('centerCode');
    const partyTypes = [
      { value: 'Employee', label: 'Employee' },
      { value: 'Contractor', label: 'Contractor' },
      { value: 'Supplier', label: 'Supplier' },
      { value: 'Customer', label: 'Customer' },
      { value: 'ThirdParty', label: 'Third Party' },
    ];
    return { cashBooks, categories, parties, centers, partyTypes };
  },

  async getAll(filters = {}) {
    return db(`${HEADER} as v`)
      .select(
        'v.voucherId', 'v.docNo', 'v.voucherDate', 'v.cashBookId', 'cb.code as cashBookCode',
        'v.payeeName', 'v.currencyCode', 'v.totalAmount', 'v.status',
        db.raw("'PCV/' || v.docNo as voucherNo")
      )
      .leftJoin('pc_mas_cashBook as cb', 'cb.cashBookId', 'v.cashBookId')
      .where({ 'v.tenantId': filters.tenantId, 'v.companyId': filters.companyId })
      .orderBy([{ column: 'v.voucherDate', order: 'desc' }, { column: 'v.docNo', order: 'desc' }]);
  },

  async get(filters = {}, conn = db) {
    const header = await conn(HEADER).where({ voucherId: filters.id }).first();
    if (!header) return null;
    const lines = await conn(DETAIL).where({ voucherId: filters.id }).orderBy('lineNo');
    return { ...header, lines };
  },

  async update(data) {
    const lines = Array.isArray(data.lines) ? data.lines : [];
    if (!lines.length) throw new AppError('At least one line is required', 400);
    const t = totalsOf(lines);

    return db.transaction(async (trx) => {
      if (data.isUpdate) {
        const existing = await trx(HEADER).where({ voucherId: data.voucherId }).first();
        if (!existing) throw new AppError('Not found', 404);
        if (existing.status !== 'Draft') throw new AppError('Only draft vouchers can be edited', 409);

        await snapshotBefore(trx, HEADER, { voucherId: data.voucherId }, data.userId, 'UPDATE');
        await trx(HEADER).where({ voucherId: data.voucherId }).update({
          ...pickFields(data, HEAD_FIELDS),
          ...t,
          updatedBy: data.userId ?? null,
          updatedAt: new Date(),
        });
        await trx(DETAIL).where({ voucherId: data.voucherId }).delete();
        await insertLines(trx, data.voucherId, data.companyId, lines);
        return repo.get({ id: data.voucherId }, trx);
      }

      const docNo = await getNextSerialNo(trx, DOC, DOC);
      const crypto = require('crypto');
      const voucherId = crypto.randomUUID();
      await trx(HEADER).insert({
        ...pickFields(data, HEAD_FIELDS),
        ...t,
        voucherId,
        tenantId: data.tenantId,
        companyId: data.companyId,
        docType: DOC,
        txnType: DOC,
        docNo,
        status: 'Draft',
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      await snapshotInsert(trx, HEADER, { voucherId }, data.userId);
      await insertLines(trx, voucherId, data.companyId, lines);
      return repo.get({ id: voucherId }, trx);
    });
  },

  // Posts the voucher to GL and marks it Paid.
  // Dr expense (category GL) net + Dr input VAT, Cr petty cash (book GL) gross.
  async pay(data) {
    return db.transaction(async (trx) => {
      const v = await trx(HEADER).where({ voucherId: data.id }).first();
      if (!v) throw new AppError('Not found', 404);
      if (v.status === 'Paid') throw new AppError('Voucher already paid', 409);
      if (v.status === 'Cancelled') throw new AppError('Voucher is cancelled', 409);
      if (v.status === 'Settled') throw new AppError('Voucher was settled against an IOU and cannot be paid', 409);

      const lines = await trx(DETAIL).where({ voucherId: v.voucherId });
      if (!lines.length) throw new AppError('Voucher has no lines', 400);

      const book = await trx('pc_mas_cashBook').where({ cashBookId: v.cashBookId }).first();
      if (!book) throw new AppError('Cash book not found', 404);

      const catIds = [...new Set(lines.map((l) => l.categoryId))];
      const cats = await trx('pc_ref_expenseCategory').whereIn('categoryId', catIds);
      const catMap = Object.fromEntries(cats.map((c) => [c.categoryId, c]));

      // Accumulate debits by GL account. Expense net to category GL. VAT to input VAT GL.
      const debits = {};
      for (const l of lines) {
        const cat = catMap[l.categoryId];
        if (!cat) throw new AppError('Category not found for a line', 400);
        debits[cat.glAccountId] = round2((debits[cat.glAccountId] || 0) + Number(l.netAmount || 0));
        const vat = Number(l.vatAmount || 0);
        if (vat > 0 && cat.inputVatGlAccountId) {
          debits[cat.inputVatGlAccountId] = round2((debits[cat.inputVatGlAccountId] || 0) + vat);
        }
      }

      const rate = Number(v.exchangeRate || 1);
      const details = Object.entries(debits).map(([accountId, amount]) => ({
        accountId, debitAmount: amount, creditAmount: 0,
        currencyCode: v.currencyCode, exchangeRate: rate,
        costCenter: v.costCenterCode || null,
      }));
      details.push({
        accountId: book.glAccountId, debitAmount: 0, creditAmount: Number(v.totalAmount || 0),
        currencyCode: v.currencyCode, exchangeRate: rate,
      });

      const glTransactionId = await postGl(trx, {
        tenantId: v.tenantId, companyId: v.companyId,
        docType: DOC, txnType: DOC, docNo: v.docNo,
        txnDate: v.voucherDate,
        reference: `PCV/${v.docNo}`,
        description: v.description || v.payeeName,
        updatedBy: data.userId,
        details,
      });

      await trx(HEADER).where({ voucherId: v.voucherId }).update({
        status: 'Paid', paidBy: data.userId, paidAt: new Date(),
        glTransactionId, updatedBy: data.userId, updatedAt: new Date(),
      });
      return repo.get({ id: v.voucherId }, trx);
    });
  },

  async cancel(data) {
    return db.transaction(async (trx) => {
      const v = await trx(HEADER).where({ voucherId: data.id }).first();
      if (!v) throw new AppError('Not found', 404);
      if (v.status === 'Cancelled') return 'success';
      if (v.status === 'Settled') {
        throw new AppError('Voucher was settled against an IOU. Cancel the settlement instead.', 409);
      }
      await snapshotBefore(trx, HEADER, { voucherId: v.voucherId }, data.userId, 'DELETE');
      if (v.glTransactionId) await voidGl(trx, v.glTransactionId, data.userId);
      await trx(HEADER).where({ voucherId: v.voucherId }).update({
        status: 'Cancelled', updatedBy: data.userId, updatedAt: new Date(),
      });
      return 'success';
    });
  },
};

async function insertLines(trx, voucherId, companyId, lines) {
  let lineNo = 0;
  for (const l of lines) {
    lineNo += 1;
    await trx(DETAIL).insert({
      ...pickFields(l, LINE_FIELDS),
      voucherId,
      companyId,
      lineNo,
    });
  }
}

module.exports = repo;
