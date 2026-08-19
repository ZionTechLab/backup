const db = require('../../database');
const { randomUUID } = require('crypto');
const { ensureUnique } = require("../../repository/validators");
const { snapshotInsert } = require('../../repository/auditHistory');

const argon2 = require('argon2');

const UserRepo = {
  async getUi(tenantId) {
    const Role = await db('sec_permissionGroup')
      .select('permGroupId as id', 'permGroupName as roleName')
      .where({ tenantId, deleted: false, isActive: true })
      .orderBy('permGroupName');
    return { Role };
  },

  async getAll(filters = {}) {
    const result = await db('mas_users')
      .select('userId', 'userName', 'fullName', 'email', 'phone', 'phone2', 'isActive');
    return result;
  },

  async get(filters = {}) {
    const result = await db('mas_users as u')
      .select(
        'u.userId',
        'u.userName',
        'u.fullName',
        'u.email',
        'u.phone',
        'u.phone2',
        'u.isActive',
        db.raw(`(
          SELECT ur.roleID
          FROM mas_userRoles ur
          JOIN sec_userCompanies uc ON uc.id = ur.userCompanyId
          WHERE uc.userId = u.userId
          ORDER BY uc.isDefault DESC
          LIMIT 1
        ) as roleId`)
      )
      .where('u.userId', filters.userId)
      .first();
    if (!result) return null;

    // Also fetch all roleIds for this user across their companies
    const roleRows = await db('mas_userRoles as ur')
      .join('sec_userCompanies as uc', 'uc.id', 'ur.userCompanyId')
      .where('uc.userId', filters.userId)
      .select('ur.companyId', 'ur.roleID');
    result.roleIds = [...new Set(roleRows.map((r) => r.roleID))];

    // Direct permission grants
    const permRows = await db('sec_userPermission')
      .where({ userId: filters.userId })
      .select('permId');
    result.permissionIds = permRows.map((r) => r.permId);

    return result;
  },

  async update(data) {
    return db.transaction(async (trx) => {

      const isUpdate = !!data.isUpdate;
      const userId = isUpdate ? data.header.userId : randomUUID();
      const { tenantId, companyId } = data;

      await ensureUnique(trx, "mas_users", { userName: data.header.userName }, { userId },
        `User with username ${data.header.userName} already exists.`, 409, {}
      );
      await ensureUnique(trx, "mas_users", { fullName: data.header.fullName }, { userId },
        `User with full name ${data.header.fullName} already exists.`, 409, {}
      );
      await ensureUnique(trx, "mas_users", { email: data.header.email }, { userId },
        `User with email ${data.header.email} already exists.`, 409, {}
      );
      await ensureUnique(trx, "mas_users", { phone: data.header.phone }, { userId },
        `User with phone ${data.header.phone} already exists.`, 409, {}
      );

      const header = { ...data.header };

      // If password not provided on update, keep existing hashed password
      let current = null;
      if (isUpdate) {
        current = await trx("mas_users").where({ userId }).first();
      }
      const isBlankPassword =
        header.password == null ||
        (typeof header.password === 'string' && header.password.trim() === '');
      if (isUpdate && isBlankPassword && current?.password) {
        header.password = current.password;
      }

      // Hash password if provided and not already an argon2 hash
      if (header.password && typeof header.password === 'string') {
        const alreadyHashed = header.password.startsWith('$argon2');
        if (!alreadyHashed) {
          header.password = await argon2.hash(header.password, {
            type: argon2.argon2id,
            timeCost: 2,
            memoryCost: 19456,
            parallelism: 1,
          });
        }
      }

      const fields = {
        userName: header.userName,
        password: header.password,
        fullName: header.fullName,
        email: header.email,
        phone: header.phone,
        phone2: header.phone2,
        isActive: header.isActive,
        updatedBy: data.userId || null,
        updatedAt: new Date(),
      };

      if (isUpdate) {
        await trx("mas_users").where({ userId }).update(fields);
      } else {
        await trx("mas_users").insert({ userId, ...fields });
        await snapshotInsert(trx, "mas_users", { userId }, data.userId);
      }

      // Tenant membership: required by tenantContext middleware, which 403s any
      // request scoped to a tenant the user isn't linked to in sec_userTenants.
      if (tenantId) {
        const ut = await trx('sec_userTenants').where({ userId, tenantId }).first();
        if (!ut) {
          await trx('sec_userTenants').insert({
            userId, tenantId, isDefault: true, isActive: true,
          });
        }
      }

      // Role assignment: find or create the user-company link, then sync roles
      if (tenantId && companyId) {
        let uc = await trx('sec_userCompanies')
          .where({ userId, companyId })
          .first();
        if (!uc) {
          await trx('sec_userCompanies').insert({
            userId, companyId, isDefault: true, isActive: true,
          });
          uc = await trx('sec_userCompanies')
            .where({ userId, companyId })
            .first();
        }
        // Replace role assignments for this user-company
        await trx('mas_userRoles').where({ tenantId, companyId, userCompanyId: uc.id }).del();
        const roleIds = data.header.roleIds;
        if (roleIds && roleIds.length) {
          await trx('mas_userRoles').insert(
            roleIds.map((roleId) => ({
              tenantId,
              companyId,
              userCompanyId: uc.id,
              roleID: roleId,
              updatedBy: data.userId || null,
              updatedAt: new Date(),
            }))
          );
        }

        // Direct permission grants
        await trx('sec_userPermission').where({ userId }).del();
        const permIds = data.header.permissionIds;
        if (permIds && permIds.length) {
          await trx('sec_userPermission').insert(
            permIds.map((permId) => ({ userId, permId }))
          );
        }
      }

      return trx("mas_users").where({ userId }).first();
    });
  },

  // Verify user credentials: returns user (without password) when valid, otherwise null
  async verifyCredentials({ userName, password }) {
    const row = await db('mas_users as u')
      .select(
        'u.userId',
        'u.userName',
        'u.password',
        'u.fullName',
        'u.email',
        'u.phone',
        'u.phone2',
        'u.isActive',
        db.raw(`(
          SELECT ur.roleID
          FROM mas_userRoles ur
          JOIN sec_userCompanies uc ON uc.id = ur.userCompanyId
          WHERE uc.userId = u.userId
          ORDER BY uc.isDefault DESC
          LIMIT 1
        ) as roleId`)
      )
      .where('u.userName', userName)
      .first();

    if (!row || !row.password) return null;
    const ok = await argon2.verify(row.password, password);
    if (!ok) return null;
    const { password: _pw, ...safeUser } = row;
    return safeUser;
  },

  async delete(data) {
    return db.transaction(async (trx) => {
      await trx("mas_users").where({ userId: data.userId || data.id }).del();
      return 'success';
    });
  },

  async changePassword(userId, newPassword) {
    const hash = await argon2.hash(newPassword, { type: argon2.argon2id });
    await db('mas_users').where({ userId }).update({ password: hash });
  },
};

module.exports = UserRepo;