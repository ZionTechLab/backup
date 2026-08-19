const crypto = require('crypto');
const db = require('../../../database');
const { ensureUnique } = require('../../../repository/validators');
const { snapshotBefore, snapshotInsert } = require('../../../repository/auditHistory');
const { pickFields } = require('../../../repository/pickFields');

const TABLE = 'pc_ref_param';
const FIELDS = ['paramGroup', 'paramKey', 'numValue', 'textValue', 'glAccountId', 'isActive'];

const GROUP_HINTS = ['MAX_ADVANCE', 'SETTLEMENT_DAYS', 'ALERT_DAYS', 'ESCALATION_DAYS', 'ADVANCE_GL', 'FLOAT', 'ALERT', 'IOU_LIMIT'];

const repo = {
  async getUi(ctx = {}) {
    const accounts = await db('gl_chartOfAccounts')
      .select('accountId', 'accountCode', 'accountName')
      .where({ isActive: true, tenantId: ctx.tenantId })
      .orderBy('accountCode');
    return { accounts, groups: GROUP_HINTS };
  },

  async getAll(filters = {}) {
    return db(`${TABLE} as p`)
      .select(
        'p.paramId', 'p.paramGroup', 'p.paramKey', 'p.numValue', 'p.textValue',
        'p.glAccountId', 'p.isActive',
        'coa.accountCode', 'coa.accountName'
      )
      .leftJoin('gl_chartOfAccounts as coa', 'coa.accountId', 'p.glAccountId')
      .where({ 'p.deleted': false, 'p.tenantId': filters.tenantId, 'p.companyId': filters.companyId })
      .orderBy(['p.paramGroup', 'p.paramKey']);
  },

  async get(filters = {}) {
    return db(TABLE)
      .select('paramId', 'paramGroup', 'paramKey', 'numValue', 'textValue', 'glAccountId', 'isActive')
      .where({ paramId: filters.id, deleted: false })
      .first();
  },

  async update(data) {
    return db.transaction(async (trx) => {
      if (data.isUpdate) {
        const id = data.paramId;
        await ensureUnique(trx, TABLE, { companyId: data.companyId, paramGroup: data.paramGroup, paramKey: data.paramKey }, { paramId: id }, 'Parameter with same group and key already exists.');
        await snapshotBefore(trx, TABLE, { paramId: id, deleted: false }, data.userId, 'UPDATE');
        await trx(TABLE).where({ paramId: id, deleted: false }).update({
          ...pickFields(data, FIELDS),
          updatedBy: data.userId ?? null,
          updatedAt: new Date(),
        });
        return trx(TABLE).where({ paramId: id }).first();
      }

      await ensureUnique(trx, TABLE, { companyId: data.companyId, paramGroup: data.paramGroup, paramKey: data.paramKey }, null, 'Parameter with same group and key already exists.');

      const paramId = crypto.randomUUID();
      await trx(TABLE).insert({
        ...pickFields(data, FIELDS),
        paramId,
        tenantId: data.tenantId,
        companyId: data.companyId,
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      await snapshotInsert(trx, TABLE, { paramId }, data.userId);
      return trx(TABLE).where({ paramId }).first();
    });
  },

  async delete(data) {
    return db.transaction(async (trx) => {
      await snapshotBefore(trx, TABLE, { paramId: data.id, deleted: false }, data.userId, 'DELETE');
      await trx(TABLE).where({ paramId: data.id, deleted: false }).update({ deleted: true });
      return 'success';
    });
  },
};

module.exports = repo;
