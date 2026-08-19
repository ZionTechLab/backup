// Seeds the Menu Arrangement admin screen: a menu-manage permission under the
// SECURITY module (granted to Full Access), and a menu item under Settings
// (group 340) granted to role 1 (Admin). Idempotent.

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
  // Permission
  const module = await knex('sec_module').where({ moduleCode: 'SECURITY' }).first();
  if (module) {
    const code = 'menu-manage';
    let perm = await knex('sec_permission').where({ permCode: code }).first();
    if (!perm) {
      const mx = await knex('sec_permission').max('sortOrder as m').first();
      await knex('sec_permission').insert({
        permCode: code, permName: 'Menu - Manage', moduleId: module.moduleId, sortOrder: (mx?.m ?? 0) + 1,
      });
      perm = await knex('sec_permission').where({ permCode: code }).first();
    }
    const tenants = await knex('sec_tenants').select('tenantId');
    for (const t of tenants) {
      const group = await knex('sec_permissionGroup').where({ tenantId: t.tenantId, permGroupName: 'Full Access' }).first();
      if (!group) continue;
      const exists = await knex('sec_permissionGroupDetail').where({ permGroupId: group.permGroupId, permId: perm.permId }).first();
      if (!exists) await knex('sec_permissionGroupDetail').insert({ permGroupId: group.permGroupId, permId: perm.permId });
    }
  }

  // Menu item under Settings (340)
  const scope = await scopeFor(knex);
  if (!scope) return;
  const admin = await knex('mas_users').where({ userName: 'admin' }).first();
  const updatedBy = admin ? admin.userId : null;
  const now = new Date();

  const existing = await knex('sec_menu').where({ ...scope, route: '/settings/menu' }).first();
  if (existing) return;

  const mxId = await knex('sec_menu').max('id as m').first();
  const id = (mxId?.m ?? 0) + 1;
  const mxOrder = await knex('sec_menu').where({ ...scope, parentId: 340 }).max('order as m').first();

  await knex('sec_menu').insert({
    ...scope, id, parentId: 340, route: '/settings/menu', displayName: 'Menu Arrangement',
    icon: 'bi bi-list-nested', order: (mxOrder?.m ?? 0) + 1, isGroup: false, isActive: true,
    updatedBy, updatedAt: now,
  });
  await knex('sec_userMenu').insert({ ...scope, id, roleId: 1, isCategory: 0, updatedBy, updatedAt: now });
};

exports.down = async function (knex) {
  const scope = await scopeFor(knex);
  if (scope) {
    const row = await knex('sec_menu').where({ ...scope, route: '/settings/menu' }).first();
    if (row) {
      await knex('sec_userMenu').where({ ...scope, id: row.id }).del();
      await knex('sec_menu').where({ ...scope, id: row.id }).del();
    }
  }
  const perm = await knex('sec_permission').where({ permCode: 'menu-manage' }).first();
  if (perm) {
    await knex('sec_permissionGroupDetail').where({ permId: perm.permId }).del();
    await knex('sec_permission').where({ permId: perm.permId }).del();
  }
};
