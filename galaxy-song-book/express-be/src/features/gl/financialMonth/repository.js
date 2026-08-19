const db = require('../../../database');
const { AppError } = require('../../../middleware/errorHandler');

const repo = {

  async getAll({ companyId }) {
    const glCo = await db('gl_companies').where({ companyId }).first();
    if (!glCo) throw new AppError('GL company config not found', 404);

    // Current financial year window. Start month is configurable, so the
    // window can span a calendar-year boundary. Compare as (year * 12 + month).
    const startMonth     = glCo.financialYearStartMonth || 1;
    const fyStartYear    = glCo.currentFinMonth >= startMonth ? glCo.currentFinYear : glCo.currentFinYear - 1;
    const fyStartPeriod  = fyStartYear * 12 + startMonth;
    const fyEndPeriod    = fyStartPeriod + 11;

    return db('gl_financialMonths')
      .select('fnYear', 'fnMonth', 'startDate', 'endDate', 'isClosed', 'updatedAt')
      .where({ companyId })
      .whereRaw('(fnYear * 12 + fnMonth) BETWEEN ? AND ?', [fyStartPeriod, fyEndPeriod])
      .orderByRaw('(fnYear * 12 + fnMonth)');
  },

  async update(data) {
    return db.transaction(async (trx) => {
      // Load GL company config
      const glCo = await trx('gl_companies').where({ companyId: data.companyId }).first();
      if (!glCo) throw new AppError('GL company config not found', 404);

      // Load the target month record
      const month = await trx('gl_financialMonths')
        .where({ companyId: data.companyId, fnYear: data.fnYear, fnMonth: data.fnMonth })
        .first();
      if (!month) throw new AppError('Financial month record not found', 404);

      if (data.isClosed) {
        return repo._closeMonth(trx, data, glCo, month);
      } else {
        return repo._openMonth(trx, data, glCo, month);
      }
    });
  },

  async _closeMonth(trx, data, glCo, month) {
    if (data.fnYear !== glCo.currentFinYear || data.fnMonth !== glCo.currentFinMonth) {
      throw new AppError('Can only close the current open month', 400);
    }
    if (month.isClosed) throw new AppError('Month is already closed', 400);

    const now = new Date();
    const { companyId, tenantId, fnYear, fnMonth, userId } = data;

    // Cumulative rows — sum all period rows in the current financial year up to this month.
    const startMonth     = glCo.financialYearStartMonth || 1;
    const fyStartYear    = fnMonth >= startMonth ? fnYear : fnYear - 1;
    const fyStartPeriod  = fyStartYear * 12 + startMonth;
    const currentPeriod  = fnYear * 12 + fnMonth;

    // Explicit target columns so INSERT...SELECT does not depend on column count
    // (e.g. the table's isDeleted column takes its default).
    const balTarget = trx.raw(
      'gl_accountBalances (tenantId, companyId, accountId, fnYear, fnMonth, isCumulative, costCenter, debitTotal, creditTotal, updatedBy, updatedAt)'
    );

    // Knex native INSERT INTO ... SELECT
    await trx.into(balTarget)
      .insert(function() {
        this.select(
          'tenantId',
          'companyId',
          'accountId',
          trx.raw('? as fnYear', [fnYear]),
          trx.raw('? as fnMonth', [fnMonth]),
          trx.raw('1 as isCumulative'),
          'costCenter',
          trx.raw('SUM(debitTotal) as debitTotal'),
          trx.raw('SUM(creditTotal) as creditTotal'),
          trx.raw('? as updatedBy', [userId]),
          trx.raw('? as updatedAt', [now])
        )
        .from('gl_accountBalances')
        .where('companyId', companyId)
        .whereBetween(trx.raw('(fnYear * 12 + fnMonth)'), [fyStartPeriod, currentPeriod])
        .where('isCumulative', 0)
        .groupBy('tenantId', 'companyId', 'accountId', 'costCenter');
      });

    // Period rows — detail lines may have a null costCenter; the balances table
    // requires it (part of the PK, NOT NULL default ''), so coalesce to ''.
    await trx.into(balTarget)
      .insert(function() {
        this.select(
          'tenantId',
          'companyId',
          'accountId',
          trx.raw('? as fnYear', [fnYear]),
          trx.raw('? as fnMonth', [fnMonth]),
          trx.raw('0 as isCumulative'),
          trx.raw("COALESCE(costCenter, '') as costCenter"),
          trx.raw('SUM(debitBase) as debitTotal'),
          trx.raw('SUM(creditBase) as creditTotal'),
          trx.raw('? as updatedBy', [userId]),
          trx.raw('? as updatedAt', [now])
        )
        .from('gl_transactionDetail')
        .where('companyId', companyId)
        .where('fnYear', fnYear)
        .where('fnMonth', fnMonth)
        .groupBy('tenantId', 'companyId', 'accountId', trx.raw("COALESCE(costCenter, '')"));
      });

    // Close the month
    await trx('gl_financialMonths')
      .where({ companyId, fnYear, fnMonth })
      .update({ isClosed: true, updatedBy: userId, updatedAt: now });

    // Advance currentFinMonth (with year rollover)
    const nextMonth = fnMonth === 12 ? 1 : fnMonth + 1;
    const nextYear  = fnMonth === 12 ? fnYear + 1 : glCo.currentFinYear;
    await trx('gl_companies')
      .where({ companyId })
      .update({ currentFinYear: nextYear, currentFinMonth: nextMonth, updatedBy: userId, updatedAt: now });

    const monthRow = await trx('gl_financialMonths').where({ companyId, fnYear, fnMonth }).first();
    return { ...monthRow, currentFinYear: nextYear, currentFinMonth: nextMonth };
  },

  async _openMonth(trx, data, glCo, month) {
    // Only allow reopening the month immediately before currentFinMonth
    const expectedMonth = glCo.currentFinMonth === 1 ? 12 : glCo.currentFinMonth - 1;
    const expectedYear  = glCo.currentFinMonth === 1 ? glCo.currentFinYear - 1 : glCo.currentFinYear;

    if (data.fnYear !== expectedYear || data.fnMonth !== expectedMonth) {
      throw new AppError('Can only reopen the immediately preceding month', 400);
    }
    if (!month.isClosed) throw new AppError('Month is already open', 400);

    const now = new Date();
    const { companyId, fnYear, fnMonth, userId } = data;

    // Remove summary records for this period (period + cumulative)
    await trx('gl_accountBalances')
      .where({ companyId, fnYear, fnMonth })
      .delete();

    // Reopen the month
    await trx('gl_financialMonths')
      .where({ companyId, fnYear, fnMonth })
      .update({ isClosed: false, updatedBy: userId, updatedAt: now });

    // Roll back currentFinMonth
    await trx('gl_companies')
      .where({ companyId })
      .update({ currentFinYear: fnYear, currentFinMonth: fnMonth, updatedBy: userId, updatedAt: now });

    const monthRow = await trx('gl_financialMonths').where({ companyId, fnYear, fnMonth }).first();
    return { ...monthRow, currentFinYear: fnYear, currentFinMonth: fnMonth };
  },
};

module.exports = repo;