const db = require('../../database');
const { ensureUnique } = require('../../repository/validators');
const { snapshotInsert } = require('../../repository/auditHistory');

const repo = {
  async getAll() {
    const result = await db('sec_currencies')
      .select('currencyCode', 'currencyName', 'symbol', 'isActive')
      .orderBy('currencyCode');
    return result;
  },

  async get(filters = {}) {
    const result = await db('sec_currencies')
      .select('currencyCode', 'currencyName', 'symbol', 'isActive')
      .where({ currencyCode: filters.id })
      .first();
    return result || null;
  },

  async update(data) {
    return db.transaction(async (trx) => {
      if (data.isUpdate) {
        await ensureUnique(
          trx, 'sec_currencies',
          { currencyName: data.currencyName },
          { currencyCode: data.currencyCode },
          'Currency name already exists',
          409,
          {}
        );
        await trx('sec_currencies')
          .where({ currencyCode: data.currencyCode })
          .update({
            currencyName: data.currencyName,
            symbol:       data.symbol,
            isActive:     data.isActive,
          });
        return trx('sec_currencies').where({ currencyCode: data.currencyCode }).first();
      }

      await ensureUnique(
        trx, 'sec_currencies',
        { currencyCode: data.currencyCode },
        null,
        'Currency code already exists',
        409,
        {}
      );
      await trx('sec_currencies').insert({
        currencyCode: data.currencyCode,
        currencyName: data.currencyName,
        symbol:       data.symbol,
        isActive:     data.isActive ?? true,
      });
      await snapshotInsert(trx, 'sec_currencies', { currencyCode: data.currencyCode }, data.userId);
      return trx('sec_currencies').where({ currencyCode: data.currencyCode }).first();
    });
  },

  async delete(data) {
    await db('sec_currencies')
      .where({ currencyCode: data.currencyCode })
      .update({ isActive: false });
    return 'success';
  },
};

module.exports = repo;