const db = require('../../../database');
const { snapshotInsert } = require('../../../repository/auditHistory');

const repo = {
  async getAll() {
    return db('gl_accountTypes').select('accountType', 'typeName', 'sortOrder','isActive').orderBy('sortOrder');
  },

  async get(filters = {}) {
    return db('gl_accountTypes').where({ accountType: filters.accountType }).first();
  },

  async update(data) {
    if (data.isUpdate) {
      await db('gl_accountTypes').where({ accountType: data.header.accountType }).update({
        typeName:  data.header.typeName,
        sortOrder: data.header.sortOrder,
        isActive:   data.header.isActive,
      });
      return db('gl_accountTypes').where({ accountType: data.header.accountType }).first();
    }
    await db('gl_accountTypes').insert({
      accountType: data.header.accountType,
      typeName:   data.header.typeName,
      sortOrder:  data.header.sortOrder,
      isActive:    data.header.isActive,
    });
    await snapshotInsert(db, 'gl_accountTypes', { accountType: data.header.accountType }, data.userId);
    return db('gl_accountTypes').where({ accountType: data.header.accountType }).first();
  },

  async delete(data) {
    const existing = await db('gl_accountTypes').where({ accountType: data.header.accountType }).first();
    if (!existing) throw new (require('../../../middleware/errorHandler').AppError)('Not found', 404);
    await db('gl_accountTypes').where({ accountType: data.accountType }).delete();
    return 'success';
  },
};

module.exports = repo;
