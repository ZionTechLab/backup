// The Wallet screen (my-app/src/features/Wallet) has a working route
// (/wallet) and component, but was never given a sec_menu entry — so it
// never showed up in the drawer or in menu search. Seeds that entry.
// Top-level, right after the existing top items, granted to Admin + User
// (the component itself has no permission gate, so this matches its
// current no-permission-check behavior rather than inventing a new one).

async function scopeFor(knex) {
  const tenant = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  if (!tenant) return null;
  const company = await knex('sec_companies')
    .where({ tenantId: tenant.tenantId, companyName: 'Demo Company' })
    .first();
  if (!company) return null;
  return { tenantId: tenant.tenantId, companyId: company.companyId };
}

const GRANT_ROLES = [1, 2];

exports.up = async function (knex) {
  const scope = await scopeFor(knex);
  if (!scope) return;
  const admin = await knex('mas_users').where({ userName: 'admin' }).first();
  const updatedBy = admin ? admin.userId : null;
  const now = new Date();

  const existing = await knex('sec_menu').where({ ...scope, route: '/wallet' }).first();
  if (existing) return;

  const mxId = await knex('sec_menu').max('id as m').first();
  const id = (mxId?.m ?? 0) + 1;
  const mxOrder = await knex('sec_menu').where({ ...scope, parentId: 0 }).max('order as m').first();

  await knex('sec_menu').insert({
    ...scope, id, parentId: 0, route: '/wallet', displayName: 'My Wallet',
    icon: 'bi bi-wallet2', order: (mxOrder?.m ?? 0) + 1, isGroup: false, isActive: true,
    updatedBy, updatedAt: now,
  });

  await knex('sec_userMenu').insert(
    GRANT_ROLES.map((roleId) => ({ ...scope, id, roleId, isCategory: 0, updatedBy, updatedAt: now }))
  );
};

exports.down = async function (knex) {
  const scope = await scopeFor(knex);
  if (!scope) return;
  const row = await knex('sec_menu').where({ ...scope, route: '/wallet' }).first();
  if (row) {
    await knex('sec_userMenu').where({ ...scope, id: row.id }).del();
    await knex('sec_menu').where({ ...scope, id: row.id }).del();
  }
};
