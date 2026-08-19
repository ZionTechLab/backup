const crypto = require('crypto');
const db = require('../../database');
const { AppError } = require('../../middleware/errorHandler');
const { snapshotBefore, snapshotInsert } = require('../../repository/auditHistory');

const repo = {
  async getAll(filters = {}) {
    const result = await db({ g: 'sec_groups' })
      .select('g.groupId', 'g.tenantId', 'g.groupName', 'g.baseCurrencyCode', 'g.isActive', 'g.updatedAt')
      .where('g.isActive', true)
      .orderBy('g.groupName');
    return result;
  },

  async get(filters = {}) {
    const result = await db({ g: 'sec_groups' })
      .select('g.groupId', 'g.tenantId', 'g.groupName', 'g.baseCurrencyCode', 'g.isActive', 'g.updatedAt')
      .where({ 'g.groupId': filters.groupId, 'g.isActive': true })
      .first();
    return result || null;
  },

  async update(data) {
    return db.transaction(async (trx) => {
      if (data.isUpdate) {
        const existing = await snapshotBefore(trx, 'sec_groups', { groupId: data.groupId }, data.userId, 'UPDATE');
        if (!existing) throw new AppError('Not found', 404);
        await trx('sec_groups')
          .where({ groupId: data.groupId, isActive: true })
          .update({
            groupName:        data.groupName,
            baseCurrencyCode: data.baseCurrencyCode || null,
          });
        return trx('sec_groups').where({ groupId: data.groupId }).first();
      }

      const groupId = crypto.randomUUID();
      await trx('sec_groups').insert({
        groupId,
        tenantId:         data.tenantId,
        groupName:        data.groupName,
        baseCurrencyCode: data.baseCurrencyCode || null,
        isActive:         true,
      });
      await snapshotInsert(trx, 'sec_groups', { groupId }, data.userId);
      return trx('sec_groups').where({ groupId }).first();
    });
  },

  async delete(data) {
    return db.transaction(async (trx) => {
      const existing = await snapshotBefore(trx, 'sec_groups', { groupId: data.groupId }, data.userId, 'DELETE');
      if (!existing) throw new AppError('Not found', 404);
      await trx('sec_groups')
        .where({ groupId: data.groupId })
        .update({ isActive: false });
      return 'success';
    });
  },
};

module.exports = repo;