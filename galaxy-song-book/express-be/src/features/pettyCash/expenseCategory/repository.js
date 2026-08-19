const crypto = require('crypto');
const db = require('../../../database');
const { ensureUnique } = require('../../../repository/validators');
const { snapshotBefore, snapshotInsert } = require('../../../repository/auditHistory');
const { pickFields } = require('../../../repository/pickFields');

const TABLE = 'pc_ref_expenseCategory';
const FIELDS = ['name', 'glAccountId', 'taxMode', 'taxRate', 'inputVatGlAccountId', 'isActive'];

const repo = {
  // Lookups for the petty cash category form.
  async getUi(ctx = {}) {
    const accounts = await db('gl_chartOfAccounts')
      .select('accountId', 'accountCode', 'accountName')
      .where({ isActive: true, tenantId: ctx.tenantId })
      .orderBy('accountCode');
    return { accounts };
  },

  async getAll(filters = {}) {
    return db(`${TABLE} as ec`)
      .select(
        'ec.categoryId', 'ec.name', 'ec.glAccountId', 'ec.taxMode', 'ec.taxRate',
        'ec.inputVatGlAccountId', 'ec.isActive',
        'coa.accountCode', 'coa.accountName',
        'vat.accountCode as inputVatAccountCode', 'vat.accountName as inputVatAccountName'
      )
      .leftJoin('gl_chartOfAccounts as coa', 'coa.accountId', 'ec.glAccountId')
      .leftJoin('gl_chartOfAccounts as vat', 'vat.accountId', 'ec.inputVatGlAccountId')
      .where({ 'ec.deleted': false, 'ec.tenantId': filters.tenantId, 'ec.companyId': filters.companyId })
      .orderBy('ec.name');
  },

  async get(filters = {}) {
    return db(TABLE)
      .select('categoryId', 'name', 'glAccountId', 'taxMode', 'taxRate', 'inputVatGlAccountId', 'isActive')
      .where({ categoryId: filters.id, deleted: false })
      .first();
  },

  async update(data) {
    return db.transaction(async (trx) => {
      if (data.isUpdate) {
        const id = data.categoryId;
        await ensureUnique(trx, TABLE, { companyId: data.companyId, name: data.name }, { categoryId: id }, 'Petty cash category name already exists.');
        await snapshotBefore(trx, TABLE, { categoryId: id, deleted: false }, data.userId, 'UPDATE');
        await trx(TABLE).where({ categoryId: id, deleted: false }).update({
          ...pickFields(data, FIELDS),
          updatedBy: data.userId ?? null,
          updatedAt: new Date(),
        });
        return trx(TABLE).where({ categoryId: id }).first();
      }

      await ensureUnique(trx, TABLE, { companyId: data.companyId, name: data.name }, null, 'Petty cash category name already exists.');

      const categoryId = crypto.randomUUID();
      await trx(TABLE).insert({
        ...pickFields(data, FIELDS),
        categoryId,
        tenantId: data.tenantId,
        companyId: data.companyId,
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      await snapshotInsert(trx, TABLE, { categoryId }, data.userId);
      return trx(TABLE).where({ categoryId }).first();
    });
  },

  async delete(data) {
    return db.transaction(async (trx) => {
      // Block if the petty cash category is used in any voucher or settlement detail.
      const used = await trx('pc_txn_voucherDetail').where({ categoryId: data.id }).first()
        || await trx('pc_txn_settlementDetail').where({ categoryId: data.id }).first();
      if (used) {
        const err = new Error('Petty cash category has transactions and cannot be deleted.');
        err.statusCode = 409;
        throw err;
      }
      await snapshotBefore(trx, TABLE, { categoryId: data.id, deleted: false }, data.userId, 'DELETE');
      await trx(TABLE).where({ categoryId: data.id, deleted: false }).update({ deleted: true });
      return 'success';
    });
  },
};

module.exports = repo;
