const db = require('../../database');
const { AppError } = require('../../middleware/errorHandler');
const { snapshotBefore, snapshotInsert } = require('../../repository/auditHistory');

const repo = {
  async getAll() {
    const result = await db({ e: 'sec_exRates' })
      .select(
        'e.rateId',
        'e.fromCurrencyCode',
        'fc.currencyName AS from_currency',
        'e.toCurrencyCode',
        'tc.currencyName AS to_currency',
        'e.rateTypeId',
        'rt.typeName AS rateType',
        'e.rate',
        'e.effectiveDate'
      )
      .leftJoin({ fc: 'sec_currencies' }, 'fc.currencyCode', 'e.fromCurrencyCode')
      .leftJoin({ tc: 'sec_currencies' }, 'tc.currencyCode', 'e.toCurrencyCode')
      .leftJoin({ rt: 'sec_exRateTypes' }, 'rt.rateTypeId', 'e.rateTypeId')
      .orderBy('e.effectiveDate', 'desc');
    return result;
  },

  async get(filters = {}) {
    const result = await db('sec_exRates')
      .select(
        'rateId',
        'fromCurrencyCode',
        'toCurrencyCode',
        'rateTypeId',
        'rate',
        'effectiveDate'
      )
      .where({ rateId: filters.rateId })
      .first();
    return result || null;
  },

  async getUi() {
    const [currencies, rateTypes] = await Promise.all([
      db('sec_currencies').select(db.raw('currencyCode'), db.raw(`CONCAT(currencyCode, ' - ', currencyName) AS label`)).orderBy('currencyCode'),
      db('sec_exRateTypes').select('rateTypeId', 'typeName').where({ isActive: true }).orderBy('typeName'),
    ]);
    return { currencies, rateTypes };
  },

  async update(data) {
    return db.transaction(async (trx) => {
      if (data.isUpdate) {
        const existing = await snapshotBefore(trx, 'sec_exRates', { rateId: data.rateId }, data.userId, 'UPDATE');
        if (!existing) throw new AppError('Not found', 404);
        await trx('sec_exRates')
          .where({ rateId: data.rateId })
          .update({
            fromCurrencyCode: data.fromCurrencyCode,
            toCurrencyCode:   data.toCurrencyCode,
            rateTypeId:       data.rateTypeId,
            rate:             data.rate,
            effectiveDate:    data.effectiveDate,
            updatedBy:        data.userId,
            updatedAt:        new Date(),
          });
        return trx('sec_exRates').where({ rateId: data.rateId }).first();
      }

      const rateId = require('crypto').randomUUID();
      const tenant = await trx('sec_tenants').first('tenantId');
      const group  = await trx('sec_groups').where({ tenantId: tenant.tenantId }).first('groupId');

      await trx('sec_exRates').insert({
        rateId,
        tenantId:         tenant.tenantId,
        groupId:          group.groupId,
        fromCurrencyCode: data.fromCurrencyCode,
        toCurrencyCode:   data.toCurrencyCode,
        rateTypeId:       data.rateTypeId,
        rate:             data.rate,
        effectiveDate:    data.effectiveDate,
        updatedBy:        data.userId,
        updatedAt:        new Date(),
      });
      await snapshotInsert(trx, 'sec_exRates', { rateId }, data.userId);

      return trx('sec_exRates').where({ rateId }).first();
    });
  },
};

module.exports = repo;