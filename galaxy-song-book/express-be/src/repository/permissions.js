const db = require('../database');

// Resolves a user's role assignments, optionally scoped to a company.
// A user may hold many permission groups per company.  After the ref_roles
// collapse, mas_userRoles.roleID directly stores a permGroupId.
// Returns { tenantId, roleID } pairs where roleID is a permGroupId.
async function getUserRoles(userId, companyId) {
  let q = db('mas_userRoles as ur')
    .join('sec_userCompanies as uc', 'uc.id', 'ur.userCompanyId')
    .where('uc.userId', userId);
  if (companyId) q = q.andWhere('ur.companyId', companyId);
  return q.distinct('ur.tenantId', 'ur.roleID');
}

// The single source of truth for a user's effective permission codes.
// user -> mas_userRoles (roleID = permGroupId) -> permission group details
// -> permission codes, unioned with any direct user permissions.
// Used by both the auth init and the route guard.
async function getEffectivePermissions(userId, { companyId } = {}) {
  if (!userId) return [];

  const roles = await getUserRoles(userId, companyId);

  let codes = [];
  if (roles.length) {
    const rows = await db('mas_userRoles as ur')
      .join('sec_permissionGroupDetail as gd', 'gd.permGroupId', 'ur.roleID')
      .join('sec_permission as p', 'p.permId', 'gd.permId')
      .where('p.isActive', true)
      .where(function () {
        for (const r of roles) {
          this.orWhere(function () {
            this.where('ur.tenantId', r.tenantId).andWhere('ur.roleID', r.roleID);
          });
        }
      })
      .distinct('p.permCode');
    codes = rows.map((r) => r.permCode);
  }

  const direct = await db('sec_userPermission as up')
    .join('sec_permission as p', 'p.permId', 'up.permId')
    .where({ 'up.userId': userId, 'p.isActive': true })
    .distinct('p.permCode');

  return [...new Set([...codes, ...direct.map((r) => r.permCode)])];
}

module.exports = { getEffectivePermissions, getUserRoles };
