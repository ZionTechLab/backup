// Adds pc-replenishment-save/update/cancel/verify/approve/post permissions to PETTY_CASH module and Full Access groups.
// Idempotent by permCode.

exports.up = async function (knex) {
  const module = await knex('sec_module').where({ moduleCode: 'PETTY_CASH' }).first();
  if (!module) return;

  const perms = [
    { code: 'pc-replenishment-save',    name: 'Replenishment - Save' },
    { code: 'pc-replenishment-update',  name: 'Replenishment - Update' },
    { code: 'pc-replenishment-cancel',  name: 'Replenishment - Cancel' },
    { code: 'pc-replenishment-verify',  name: 'Replenishment - Verify' },
    { code: 'pc-replenishment-approve', name: 'Replenishment - Approve' },
    { code: 'pc-replenishment-post',    name: 'Replenishment - Post' },
  ];

  const maxPermSort = await knex('sec_permission').max('sortOrder as mx').first();
  let permSort = (maxPermSort?.mx ?? 0) + 1;

  for (const p of perms) {
    const existing = await knex('sec_permission').where({ permCode: p.code }).first();
    if (!existing) {
      await knex('sec_permission').insert({
        permCode: p.code, permName: p.name, moduleId: module.moduleId, sortOrder: permSort,
      });
      permSort += 1;
    }
  }

  const newPerms = await knex('sec_permission')
    .whereIn('permCode', perms.map((p) => p.code))
    .select('permId', 'permCode');

  const tenants = await knex('sec_tenants').select('tenantId');
  for (const t of tenants) {
    const group = await knex('sec_permissionGroup').where({ tenantId: t.tenantId, permGroupName: 'Full Access' }).first();
    if (!group) continue;
    for (const p of newPerms) {
      const exists = await knex('sec_permissionGroupDetail').where({ permGroupId: group.permGroupId, permId: p.permId }).first();
      if (!exists) {
        await knex('sec_permissionGroupDetail').insert({ permGroupId: group.permGroupId, permId: p.permId });
      }
    }
  }
};

exports.down = async function (knex) {
  const perms = await knex('sec_permission')
    .whereIn('permCode', [
      'pc-replenishment-save', 'pc-replenishment-update', 'pc-replenishment-cancel',
      'pc-replenishment-verify', 'pc-replenishment-approve', 'pc-replenishment-post',
    ])
    .select('permId');
  const permIds = perms.map((p) => p.permId);
  if (permIds.length) {
    await knex('sec_permissionGroupDetail').whereIn('permId', permIds).del();
    await knex('sec_permission').whereIn('permId', permIds).del();
  }
};
