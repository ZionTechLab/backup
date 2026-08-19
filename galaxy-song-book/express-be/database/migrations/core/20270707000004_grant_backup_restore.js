// backup-restore was deliberately left ungranted when seeded
// (20270706000004_backup_restore_permissions.js) since it's destructive.
// Granting it to Full Access now, on request, same group backup-export
// already uses — backup-restore-full (whole database) stays ungranted.

exports.up = async function (knex) {
  const perm = await knex('sec_permission').where({ permCode: 'backup-restore' }).first();
  if (!perm) return;
  const tenants = await knex('sec_tenants').select('tenantId');
  for (const t of tenants) {
    const group = await knex('sec_permissionGroup').where({ tenantId: t.tenantId, permGroupName: 'Full Access' }).first();
    if (!group) continue;
    const exists = await knex('sec_permissionGroupDetail').where({ permGroupId: group.permGroupId, permId: perm.permId }).first();
    if (!exists) await knex('sec_permissionGroupDetail').insert({ permGroupId: group.permGroupId, permId: perm.permId });
  }
};

exports.down = async function (knex) {
  const perm = await knex('sec_permission').where({ permCode: 'backup-restore' }).first();
  if (!perm) return;
  const groups = await knex('sec_permissionGroup').where({ permGroupName: 'Full Access' }).select('permGroupId');
  for (const g of groups) {
    await knex('sec_permissionGroupDetail').where({ permGroupId: g.permGroupId, permId: perm.permId }).del();
  }
};
