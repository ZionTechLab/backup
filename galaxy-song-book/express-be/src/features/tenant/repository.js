const crypto = require('crypto');
const db = require('../../database');
const { AppError } = require('../../middleware/errorHandler');
const { snapshotBefore, snapshotInsert } = require('../../repository/auditHistory');
const { SETTINGS_KEYS, parseSettings, mergeWithDefaults } = require('./settingsDefaults');

const repo = {
  async getAll(filters = {}) {
    const result = await db('sec_tenants')
      .select('tenantId', 'tenantName', 'legalName', 'status', 'email', 'phone',
              'addressLine1', 'addressLine2', 'city', 'stateProvince', 'postalCode', 'country')
      .where('status', 'active')
      .orderBy('tenantName');
    return result;
  },

  async get(filters = {}) {
    const result = await db('sec_tenants')
      .select('tenantId', 'tenantName', 'legalName', 'status', 'email', 'phone',
              'addressLine1', 'addressLine2', 'city', 'stateProvince', 'postalCode', 'country')
      .where({ tenantId: filters.tenantId, status: 'active' })
      .first();
    return result || null;
  },

  async update(data) {
    return db.transaction(async (trx) => {
      if (data.isUpdate) {
        const existing = await snapshotBefore(trx, 'sec_tenants', { tenantId: data.tenantId }, data.userId, 'UPDATE');
        if (!existing) throw new AppError('Not found', 404);
        await trx('sec_tenants')
          .where({ tenantId: data.tenantId })
          .update({
            tenantName:     data.tenantName,
            legalName:      data.legalName     || null,
            status:         data.status        || 'active',
            email:          data.email         || null,
            phone:          data.phone         || null,
            addressLine1:  data.addressLine1 || null,
            addressLine2:  data.addressLine2 || null,
            city:           data.city          || null,
            stateProvince: data.stateProvince || null,
            postalCode:    data.postalCode   || null,
            country:        data.country       || null,
          });
        return trx('sec_tenants').where({ tenantId: data.tenantId }).first();
      }

      const tenantId = crypto.randomUUID();
      await trx('sec_tenants').insert({
        tenantId,
        tenantName:     data.tenantName,
        legalName:      data.legalName     || null,
        status:         data.status        || 'active',
        email:          data.email         || null,
        phone:          data.phone         || null,
        addressLine1:  data.addressLine1 || null,
        addressLine2:  data.addressLine2 || null,
        city:           data.city          || null,
        stateProvince: data.stateProvince || null,
        postalCode:    data.postalCode   || null,
        country:        data.country       || null,
      });
      await snapshotInsert(trx, 'sec_tenants', { tenantId }, data.userId);
      return trx('sec_tenants').where({ tenantId }).first();
    });
  },

  async delete(data) {
    return db.transaction(async (trx) => {
      const existing = await snapshotBefore(trx, 'sec_tenants', { tenantId: data.tenantId }, data.userId, 'DELETE');
      if (!existing) throw new AppError('Not found', 404);
      await trx('sec_tenants')
        .where({ tenantId: data.tenantId })
        .update({ status: 'inactive' });
      return 'success';
    });
  },

  async isMember(tenantId, userId) {
    const row = await db('sec_userTenants').where({ tenantId, userId }).first();
    return !!row;
  },

  async getSettings(tenantId) {
    const row = await db('sec_tenants').where({ tenantId }).first('settings');
    if (!row) throw new AppError('Not found', 404);
    return mergeWithDefaults(parseSettings(row.settings));
  },

  async updateSettings(data) {
    return db.transaction(async (trx) => {
      const existing = await snapshotBefore(trx, 'sec_tenants', { tenantId: data.tenantId }, data.userId, 'UPDATE');
      if (!existing) throw new AppError('Not found', 404);

      const merged = mergeWithDefaults({ ...parseSettings(existing.settings), ...data.settings });
      const picked = {};
      SETTINGS_KEYS.forEach((key) => { picked[key] = merged[key]; });

      await trx('sec_tenants')
        .where({ tenantId: data.tenantId })
        .update({ settings: JSON.stringify(picked) });
      return picked;
    });
  },

  // --- Tenant user membership ---

  async listUsers(tenantId) {
    const rows = await db('sec_userTenants as ut')
      .join('mas_users as u', 'u.userId', 'ut.userId')
      .where({ 'ut.tenantId': tenantId, 'ut.isDeleted': false })
      .select(
        'ut.id',
        'ut.userId',
        'u.userName',
        'u.fullName',
        'u.email',
        'ut.isDefault',
        'ut.isActive',
        'ut.updatedAt',
      )
      .orderBy('u.fullName');
    return rows;
  },

  async addUser(data) {
    return db.transaction(async (trx) => {
      const existing = await trx('sec_userTenants')
        .where({ tenantId: data.tenantId, userId: data.userId, isDeleted: false })
        .first();
      if (existing) throw new AppError('User already has access to this tenant', 409);

      await trx('sec_userTenants').insert({
        tenantId: data.tenantId,
        userId: data.userId,
        isDefault: false,
        isActive: true,
        isDeleted: false,
        updatedBy: data.updatedBy,
        updatedAt: new Date(),
      });

      const row = await trx('sec_userTenants')
        .where({ tenantId: data.tenantId, userId: data.userId, isDeleted: false })
        .first();
      await snapshotInsert(trx, 'sec_userTenants', { id: row.id }, data.updatedBy);
      return row;
    });
  },

  async removeUser(data) {
    return db.transaction(async (trx) => {
      const existing = await snapshotBefore(trx, 'sec_userTenants', { id: data.id, isDeleted: false }, data.userId, 'DELETE');
      if (!existing) throw new AppError('Membership not found', 404);

      await trx('sec_userTenants')
        .where({ id: data.id })
        .update({ isActive: false, isDeleted: true, updatedBy: data.userId, updatedAt: new Date() });
      return 'success';
    });
  },

  async setDefault(data) {
    return db.transaction(async (trx) => {
      const target = await trx('sec_userTenants')
        .where({ id: data.id, isDeleted: false })
        .first();
      if (!target) throw new AppError('Membership not found', 404);

      // Snapshot the target row before updating
      await snapshotBefore(trx, 'sec_userTenants', { id: data.id }, data.userId, 'UPDATE');

      // Clear all other defaults for this user
      await trx('sec_userTenants')
        .where({ userId: target.userId, isDeleted: false })
        .whereNot({ id: data.id })
        .update({ isDefault: false, updatedBy: data.userId, updatedAt: new Date() });

      // Set this one as default
      await trx('sec_userTenants')
        .where({ id: data.id })
        .update({ isDefault: true, updatedBy: data.userId, updatedAt: new Date() });

      return trx('sec_userTenants').where({ id: data.id }).first();
    });
  },

  async countOtherActiveTenants(userId, excludeId) {
    const rows = await db('sec_userTenants')
      .where({ userId, isActive: true, isDeleted: false })
      .whereNot({ id: excludeId })
      .count('id as cnt')
      .first();
    return Number(rows?.cnt ?? 0);
  },
};

module.exports = repo;