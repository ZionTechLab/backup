// Adds view-detail permissions for 8 PettyCash features to existing databases.
// Fresh setups get them automatically from the catalog seed.

const PERMS = [
  { code: 'pc-voucher-view-detail',          name: 'Payment Voucher - View Detail' },
  { code: 'pc-iou-view-detail',              name: 'IOU - View Detail' },
  { code: 'pc-settlement-view-detail',       name: 'IOU Settlement - View Detail' },
  { code: 'pc-replenishment-view-detail',    name: 'Replenishment - View Detail' },
  { code: 'pc-cash-count-view-detail',       name: 'Cash Count - View Detail' },
  { code: 'pc-expense-category-view-detail', name: 'Petty Cash Category - View Detail' },
  { code: 'pc-param-view-detail',            name: 'Parameters - View Detail' },
  { code: 'pc-approval-band-view-detail',    name: 'Approval Bands - View Detail' },
];

exports.up = async function (knex) {
  const module = await knex('sec_module').where({ moduleCode: 'PETTY_CASH' }).first();
  if (!module) return;

  for (const p of PERMS) {
    const existing = await knex('sec_permission').where({ permCode: p.code }).first();
    if (!existing) {
      const maxSort = await knex('sec_permission').max('sortOrder as m').first();
      await knex('sec_permission').insert({
        permCode: p.code,
        permName: p.name,
        moduleId: module.moduleId,
        sortOrder: (maxSort.m ?? 0) + 1,
      });
    }
  }

  const permIds = [];
  for (const p of PERMS) {
    const perm = await knex('sec_permission').where({ permCode: p.code }).first();
    if (perm) permIds.push(perm.permId);
  }

  if (permIds.length === 0) return;

  const groups = await knex('sec_permissionGroup').where({ permGroupName: 'Full Access' }).select('permGroupId');
  for (const g of groups) {
    for (const permId of permIds) {
      const link = await knex('sec_permissionGroupDetail')
        .where({ permGroupId: g.permGroupId, permId }).first();
      if (!link) {
        await knex('sec_permissionGroupDetail').insert({ permGroupId: g.permGroupId, permId });
      }
    }
  }
};

exports.down = async function (knex) {
  const codes = PERMS.map((p) => p.code);
  const perms = await knex('sec_permission').whereIn('permCode', codes).select('permId', 'permCode');
  const permIds = perms.map((p) => p.permId);
  if (permIds.length) {
    await knex('sec_permissionGroupDetail').whereIn('permId', permIds).del();
    await knex('sec_permission').whereIn('permId', permIds).del();
  }
};
