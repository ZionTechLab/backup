// Menu: Approval Levels under Settings (Admin), My Approvals at top level for
// everyone with the approvals-view permission (granted via Full Access today).

const ITEMS = [
  { id: 353, parentId: 340, route: '/settings/approval-levels', name: 'Approval Levels', icon: 'bi bi-diagram-3-fill', roles: [1] },
  { id: 305, parentId: 0,   route: '/my-approvals',             name: 'My Approvals',     icon: 'bi bi-inbox',          roles: [1, 2] },
];

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

  for (const m of ITEMS) {
    await knex('sec_userMenu').where(scope).where({ id: m.id }).del();
    await knex('sec_menu').where(scope).where({ id: m.id }).del();
    await knex('sec_menu').insert({
      ...scope, id: m.id, parentId: m.parentId, route: m.route, displayName: m.name,
      icon: m.icon, order: m.id, isGroup: false, isActive: true, updatedBy, updatedAt: now,
    });
    for (const roleId of m.roles) {
      await knex('sec_userMenu').insert({ ...scope, id: m.id, roleId, isCategory: 0, updatedBy, updatedAt: now });
    }
  }
};

exports.down = async function (knex) {
  const scope = await scopeFor(knex);
  if (!scope) return;
  for (const m of ITEMS) {
    await knex('sec_userMenu').where(scope).where({ id: m.id }).del();
    await knex('sec_menu').where(scope).where({ id: m.id }).del();
  }
};
