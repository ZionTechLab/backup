const db = require('../../../database');
const { AppError } = require('../../../middleware/errorHandler');
const { snapshotBefore, snapshotInsert } = require('../../../repository/auditHistory');

const TABLE = 'gl_chartOfAccounts';

const repo = {
  async getAll() {
    return db(TABLE)
      .select('accountId', 'tenantId', 'groupId', 'accountType', 'accountCode', 'accountName', 'parentAccountId', 'level', 'sortOrder', 'isActive', 'updatedBy', 'updatedAt')
      .orderBy('sortOrder');
  },

  async get(filters = {}) {
    return db(TABLE).where({ accountId: filters.accountId }).first();
  },

  async update(data) {
    return db.transaction(async (trx) => {
      if (data.isUpdate) {
        const existing = await snapshotBefore(trx, TABLE, { accountId: data.accountId }, data.userId, 'UPDATE');
        if (!existing) throw new AppError('Not found', 404);

        await trx(TABLE).where({ accountId: data.accountId }).update({
          accountType:     data.accountType,
          accountCode:     data.accountCode,
          accountName:     data.accountName,
          parentAccountId: data.parentAccountId || null,
          level:           data.level,
          sortOrder:       data.sortOrder,
          isActive:        data.isActive,
          updatedBy:       data.userId,
          updatedAt:       new Date(),
        });

        return trx(TABLE).where({ accountId: data.accountId }).first();
      }

      const [accountId] = await trx(TABLE).insert({
        tenantId:        data.tenantId,
        groupId:         data.groupId,
        accountType:     data.accountType,
        accountCode:     data.accountCode,
        accountName:     data.accountName,
        parentAccountId: data.parentAccountId || null,
        level:           data.level,
        sortOrder:       data.sortOrder,
        isActive:        data.isActive,
        updatedBy:       data.userId,
        updatedAt:       new Date(),
      });
      await snapshotInsert(trx, TABLE, { accountId }, data.userId);

      return trx(TABLE).where({ accountId: accountId || data.accountId }).first();
    });
  },

  async delete(data) {
    return db.transaction(async (trx) => {
      const existing = await snapshotBefore(trx, TABLE, { accountId: data.accountId }, data.userId, 'DELETE');
      if (!existing) throw new AppError('Not found', 404);
      await trx(TABLE).where({ accountId: data.accountId }).delete();
      return 'success';
    });
  },
};

module.exports = repo;
