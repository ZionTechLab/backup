// Adds the Organization menu group with Branch, Division, Department, Section
// children. Granted to Admin (role 1). Forward-only dev seed. Idempotent.

const GROUP = { id: 360, parentId: 0, route: '#', name: 'Organization', icon: 'bi bi-diagram-3', isGroup: true };
const ITEMS = [
  { id: 361, parentId: 360, route: '/masters/branch',     name: 'Branches',     icon: 'bi bi-diagram-3' },
  { id: 362, parentId: 360, route: '/masters/division',    name: 'Divisions',    icon: 'bi bi-diagram-3' },
  { id: 363, parentId: 360, route: '/masters/department',  name: 'Departments',  icon: 'bi bi-diagram-3' },
  { id: 364, parentId: 360, route: '/masters/section',     name: 'Sections',     icon: 'bi bi-diagram-3' },
];
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

  const all = [GROUP, ...ITEMS];

  for (const item of all) {
    // Delete any existing grant + menu row for this id (scope-scoped) so we can re-insert.
    await knex('sec_userMenu').where(scope).where({ id: item.id }).del();
    await knex('sec_menu').where(scope).where({ id: item.id }).del();

    await knex('sec_menu').insert({
      ...scope,
      id: item.id,
      parentId: item.parentId,
      route: item.route,
      displayName: item.name,
      icon: item.icon,
      order: item.id,
      isGroup: item.isGroup || false,
      isActive: true,
      updatedBy,
      updatedAt: now,
    });

    if (!item.isGroup) {
      for (const roleId of GRANT_ROLES) {
        await knex('sec_userMenu').insert({
          ...scope,
          id: item.id,
          roleId,
          isCategory: 0,
          updatedBy,
          updatedAt: now,
        });
      }
    }
  }
};

exports.down = async function (knex) {
  const scope = await scopeFor(knex);
  if (!scope) return;
  const ids = [360, 361, 362, 363, 364];
  await knex('sec_userMenu').where(scope).whereIn('id', ids).del();
  await knex('sec_menu').where(scope).whereIn('id', ids).del();
};
