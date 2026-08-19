// Adds pc-cash-count-save/update/cancel/sign/countersign/audit permissions to PETTY_CASH module and Full Access groups.
// Idempotent by permCode.

exports.up = async function (knex) {
  const module = await knex('sec_module').where({ moduleCode: 'PETTY_CASH' }).first();
  if (!module) return;

  const perms = [
    { code: 'pc-cash-count-save',        name: 'Cash Count - Save' },
    { code: 'pc-cash-count-update',      name: 'Cash Count - Update' },
    { code: 'pc-cash-count-cancel',      name: 'Cash Count - Cancel' },
    { code: 'pc-cash-count-sign',        name: 'Cash Count - Sign' },
    { code: 'pc-cash-count-countersign', name: 'Cash Count - Countersign' },
    { code: 'pc-cash-count-audit',       name: 'Cash Count - Audit' },
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
      'pc-cash-count-save', 'pc-cash-count-update', 'pc-cash-count-cancel',
      'pc-cash-count-sign', 'pc-cash-count-countersign', 'pc-cash-count-audit',
    ])
    .select('permId');
  const permIds = perms.map((p) => p.permId);
  if (permIds.length) {
    await knex('sec_permissionGroupDetail').whereIn('permId', permIds).del();
    await knex('sec_permission').whereIn('permId', permIds).del();
  }
};
