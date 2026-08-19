// Adds iou-request-* permissions to the PETTY_CASH module and Full Access groups.
// Idempotent by permCode.

exports.up = async function (knex) {
  const module = await knex('sec_module').where({ moduleCode: 'PETTY_CASH' }).first();
  if (!module) return;

  const perms = [
    { code: 'iou-request-view',   name: 'IOU Request - View' },
    { code: 'iou-request-new',    name: 'IOU Request - New' },
    { code: 'iou-request-save',   name: 'IOU Request - Save' },
    { code: 'iou-request-delete', name: 'IOU Request - Delete' },
    { code: 'iou-request-certify', name: 'IOU Request - Certify' },
    { code: 'iou-request-approve', name: 'IOU Request - Approve' },
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
    .whereIn('permCode', ['iou-request-view', 'iou-request-new', 'iou-request-save', 'iou-request-delete', 'iou-request-certify', 'iou-request-approve'])
    .select('permId');
  const permIds = perms.map((p) => p.permId);
  if (permIds.length) {
    await knex('sec_permissionGroupDetail').whereIn('permId', permIds).del();
    await knex('sec_permission').whereIn('permId', permIds).del();
  }
};
