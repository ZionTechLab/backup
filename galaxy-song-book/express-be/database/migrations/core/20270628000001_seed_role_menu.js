// Adds the Roles screen under the Settings menu group (id 340).
// Granted to Admin (role 1) only. Forward-only dev seed.

const ITEM = { id: 352, parentId: 340, route: '/settings/roles', name: 'Roles', icon: 'bi bi-person-badge' };
const GRANT_ROLES = [1];

async function scopeFor(knex) {
  const tenant = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  if (!tenant) return null;
  const company = await knex('sec_companies')
    .where({ tenantId: tenant.tenantId, companyName: 'Demo Company' })
    .first();
  if (!company) return null;
  return { tenantId: tenant.tenantId, companyId: company.companyId };
}

exports.up = async function (knex) {
  const scope = await scopeFor(knex);
  if (!scope) return;
  const admin = await knex('mas_users').where({ userName: 'admin' }).first();
  const updatedBy = admin ? admin.userId : null;
  const now = new Date();

  await knex('sec_userMenu').where(scope).where({ id: ITEM.id }).del();
  await knex('sec_menu').where(scope).where({ id: ITEM.id }).del();

  await knex('sec_menu').insert({
    ...scope, id: ITEM.id, parentId: ITEM.parentId, route: ITEM.route,
    displayName: ITEM.name, icon: ITEM.icon, order: ITEM.id, isGroup: false,
    isActive: true, updatedBy, updatedAt: now,
  });
  for (const roleId of GRANT_ROLES) {
    await knex('sec_userMenu').insert({ ...scope, id: ITEM.id, roleId, isCategory: 0, updatedBy, updatedAt: now });
  }
};

exports.down = async function (knex) {
  const scope = await scopeFor(knex);
  if (!scope) return;
  await knex('sec_userMenu').where(scope).where({ id: ITEM.id }).del();
  await knex('sec_menu').where(scope).where({ id: ITEM.id }).del();
};
