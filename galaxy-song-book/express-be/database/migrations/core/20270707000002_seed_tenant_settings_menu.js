// Seeds a "Tenant Settings" menu item under Settings (group 340), granted to
// role 1 (Admin). Idempotent.

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

  const existing = await knex('sec_menu').where({ ...scope, route: '/settings/tenant-preferences' }).first();
  if (existing) return;

  const mxId = await knex('sec_menu').max('id as m').first();
  const id = (mxId?.m ?? 0) + 1;
  const mxOrder = await knex('sec_menu').where({ ...scope, parentId: 340 }).max('order as m').first();

  await knex('sec_menu').insert({
    ...scope, id, parentId: 340, route: '/settings/tenant-preferences', displayName: 'Tenant Settings',
    icon: 'bi bi-sliders', order: (mxOrder?.m ?? 0) + 1, isGroup: false, isActive: true,
    updatedBy, updatedAt: now,
  });
  await knex('sec_userMenu').insert({ ...scope, id, roleId: 1, isCategory: 0, updatedBy, updatedAt: now });
};

exports.down = async function (knex) {
  const scope = await scopeFor(knex);
  if (!scope) return;
  const row = await knex('sec_menu').where({ ...scope, route: '/settings/tenant-preferences' }).first();
  if (row) {
    await knex('sec_userMenu').where({ ...scope, id: row.id }).del();
    await knex('sec_menu').where({ ...scope, id: row.id }).del();
  }
};
