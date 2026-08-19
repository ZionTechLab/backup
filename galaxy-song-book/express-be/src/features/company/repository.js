const db = require('../../database');
const { AppError } = require('../../middleware/errorHandler');
const { snapshotBefore, snapshotInsert } = require('../../repository/auditHistory');

const repo = {
  async getAll(filters = {}) {
    const result = await db({ c: 'sec_companies' })
      .select(
        'c.companyId',
        'c.companyCode',
        'c.companyName',
        't.tenantName',
        'g.groupName',
        db.raw('r.description AS country'),
        'c.baseCurrencyCode AS baseCCY'
        // 'c.fiscalYear',
        // 'c.period'
      )
      .leftJoin({ t: 'sec_tenants' }, 't.tenantId', 'c.tenantId')
      .leftJoin({ g: 'sec_groups' }, 'g.groupId', 'c.groupId')
      .leftJoin({ r: 'ref_category' }, function() {
        this.on('r.id', '=', 'c.country')
          .andOn('r.categoryType', '=', db.raw('2107'));
      })
      .where('c.isActive', true)
      .orderBy('c.companyName');
    return result;
  },

  async get(filters = {}) {
    const result = await db({ c: 'sec_companies' })
      .select(
        'companyId',
        'companyCode',
        'companyName',
        'tenantId',
        'groupId',
        'country',
        'baseCurrencyCode',
        'isActive'
      )
      .where({ 'c.companyId': filters.id, 'c.isActive': true })
      .first();
    return result || null;
  },

  async getPrint(companyId) {
    const result = await db({ c: 'sec_companies' })
      .select(
        'c.companyName',
        'c.description',
        'c.legalName',
        'c.registrationNumber',
        'c.addressLine1',
        'c.addressLine2',
        'c.city',
        'c.stateProvince',
        'c.postalCode',
        'c.phoneNumber',
        'c.tel2',
        'c.mobile',
        'c.email',
        'c.websiteUrl',
        'c.vatNumber',
        'c.taxId'
      )
      .where({ 'c.companyId': companyId, 'c.isActive': true })
      .first();
    return result || null;
  },

  async getUi() {
    const [groups, countries, currencies, tenants] = await Promise.all([
      db('sec_groups').select('groupId', 'groupName').orderBy('groupName'),
      db('ref_category').select('id', 'description').where({ categoryType: 2107 }).orderBy('description'),
      db('sec_currencies').select(db.raw('currencyCode'), db.raw(`CONCAT(currencyCode, ' - ', currencyName) AS label`)).orderBy('currencyCode'),
      db('sec_tenants').select('tenantId', 'tenantName').where({ status: 'active' }).orderBy('tenantName'),
    ]);
    return { groups, countries, currencies, tenants };
  },

  async update(data) {
    return db.transaction(async (trx) => {
      if (data.isUpdate) {
        const existing = await snapshotBefore(trx, 'sec_companies', { companyId: data.companyId }, data.userId, 'UPDATE');
        if (!existing) throw new AppError('Not found', 404);
        const affected = await trx('sec_companies')
          .where({ companyId: data.companyId })
          .update({
            companyCode:      data.companyCode,
            companyName:      data.companyName,
            tenantId:         data.tenantId,
            groupId:          data.groupId,
            country:          data.country,
            baseCurrencyCode: data.baseCurrencyCode,
          });
        if (!affected) throw new AppError('Update failed - record not found', 404);
        return true;
      }

      const crypto = require('crypto');
      const companyId = crypto.randomUUID();
      await trx('sec_companies').insert({
        companyId,
        tenantId:         data.tenantId,
        groupId:          data.groupId,
        companyCode:      data.companyCode,
        companyName:      data.companyName,
        country:          data.country,
        baseCurrencyCode: data.baseCurrencyCode,
        // fiscalYear:       data.fiscalYear,
        // period:           data.period,
        isActive:         true,
      });
      await snapshotInsert(trx, 'sec_companies', { companyId }, data.userId);
      const result = await trx({ c: 'sec_companies' })
        .select(
          'c.companyId',
          'c.companyCode',
          'c.companyName',
          't.tenantName',
          'g.groupName',
          db.raw('r.description AS country'),
          'c.baseCurrencyCode AS baseCCY'
          // 'c.fiscalYear',
          // 'c.period'
        )
        .leftJoin({ t: 'sec_tenants' }, 't.tenantId', 'c.tenantId')
        .leftJoin({ g: 'sec_groups' }, 'g.groupId', 'c.groupId')
        .leftJoin({ r: 'ref_category' }, function() {
          this.on('r.id', '=', 'c.country')
            .andOn('r.categoryType', '=', db.raw('2107'));
        })
        .leftJoin({ cu: 'sec_currencies' }, 'cu.currencyCode', 'c.baseCurrencyCode')
        .where({ 'c.companyId': companyId, 'c.isActive': true })
        .first();
      return result;
    });
  },

  async delete(data) {
    return db.transaction(async (trx) => {
      const existing = await snapshotBefore(trx, 'sec_companies', { companyId: data.companyId }, data.userId, 'DELETE');
      if (!existing) throw new AppError('Not found', 404);
      await trx('sec_companies')
        .where({ companyId: data.companyId })
        .update({ isActive: false });
      return 'success';
    });
  },

  // --- Company user membership ---

  async listUsers(companyId) {
    const rows = await db('sec_userCompanies as uc')
      .join('mas_users as u', 'u.userId', 'uc.userId')
      .where({ 'uc.companyId': companyId, 'uc.isDeleted': false })
      .select(
        'uc.id',
        'uc.userId',
        'u.userName',
        'u.fullName',
        'u.email',
        'uc.isDefault',
        'uc.isActive',
        'uc.updatedAt',
      )
      .orderBy('u.fullName');
    return rows;
  },

  async addUser(data) {
    return db.transaction(async (trx) => {
      const existing = await trx('sec_userCompanies')
        .where({ companyId: data.companyId, userId: data.userId, isDeleted: false })
        .first();
      if (existing) throw new AppError('User already has access to this company', 409);

      await trx('sec_userCompanies').insert({
        companyId: data.companyId,
        userId: data.userId,
        isDefault: false,
        isActive: true,
        isDeleted: false,
        updatedBy: data.updatedBy,
        updatedAt: new Date(),
      });

      const row = await trx('sec_userCompanies')
        .where({ companyId: data.companyId, userId: data.userId, isDeleted: false })
        .first();
      await snapshotInsert(trx, 'sec_userCompanies', { id: row.id }, data.updatedBy);
      return row;
    });
  },

  async removeUser(data) {
    return db.transaction(async (trx) => {
      const existing = await snapshotBefore(trx, 'sec_userCompanies', { id: data.id, isDeleted: false }, data.userId, 'DELETE');
      if (!existing) throw new AppError('Membership not found', 404);

      await trx('sec_userCompanies')
        .where({ id: data.id })
        .update({ isActive: false, isDeleted: true, updatedBy: data.userId, updatedAt: new Date() });
      return 'success';
    });
  },

  async setDefault(data) {
    return db.transaction(async (trx) => {
      const target = await trx('sec_userCompanies')
        .where({ id: data.id, isDeleted: false })
        .first();
      if (!target) throw new AppError('Membership not found', 404);

      await snapshotBefore(trx, 'sec_userCompanies', { id: data.id }, data.userId, 'UPDATE');

      // Clear all other defaults for this user
      await trx('sec_userCompanies')
        .where({ userId: target.userId, isDeleted: false })
        .whereNot({ id: data.id })
        .update({ isDefault: false, updatedBy: data.userId, updatedAt: new Date() });

      // Set this one as default
      await trx('sec_userCompanies')
        .where({ id: data.id })
        .update({ isDefault: true, updatedBy: data.userId, updatedAt: new Date() });

      return trx('sec_userCompanies').where({ id: data.id }).first();
    });
  },

  async countOtherCompanies(userId, excludeId) {
    const rows = await db('sec_userCompanies')
      .where({ userId, isActive: true, isDeleted: false })
      .whereNot({ id: excludeId })
      .count('id as cnt')
      .first();
    return Number(rows?.cnt ?? 0);
  },
};

module.exports = repo;