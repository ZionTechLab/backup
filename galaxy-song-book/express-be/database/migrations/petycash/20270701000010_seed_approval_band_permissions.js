// Adds pc-approval-band-save/update/delete permissions to PETTY_CASH module and Full Access groups.
// Idempotent by permCode.

exports.up = async function (knex) {
  const module = await knex('sec_module').where({ moduleCode: 'PETTY_CASH' }).first();
  if (!module) return;

  const perms = [
    { code: 'pc-approval-band-save',   name: 'Approval Band - Save' },
    { code: 'pc-approval-band-update', name: 'Approval Band - Update' },
    { code: 'pc-approval-band-delete', name: 'Approval Band - Delete' },
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
    .whereIn('permCode', ['pc-approval-band-save', 'pc-approval-band-update', 'pc-approval-band-delete'])
    .select('permId');
  const permIds = perms.map((p) => p.permId);
  if (permIds.length) {
    await knex('sec_permissionGroupDetail').whereIn('permId', permIds).del();
    await knex('sec_permission').whereIn('permId', permIds).del();
  }
};
