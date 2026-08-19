// Adds pc-cash-book-view-detail permission to existing databases.
// Fresh setups get it automatically from the catalog seed.

exports.up = async function (knex) {
  const module = await knex('sec_module').where({ moduleCode: 'PETTY_CASH' }).first();
  if (!module) return;

  const existing = await knex('sec_permission').where({ permCode: 'pc-cash-book-view-detail' }).first();
  if (!existing) {
    const maxSort = await knex('sec_permission').max('sortOrder as m').first();
    await knex('sec_permission').insert({
      permCode: 'pc-cash-book-view-detail',
      permName: 'Cash Book - View Detail',
      moduleId: module.moduleId,
      sortOrder: (maxSort.m ?? 0) + 1,
    });
  }

  const perm = await knex('sec_permission').where({ permCode: 'pc-cash-book-view-detail' }).first();
  const groups = await knex('sec_permissionGroup').where({ permGroupName: 'Full Access' }).select('permGroupId');
  for (const g of groups) {
    const link = await knex('sec_permissionGroupDetail')
      .where({ permGroupId: g.permGroupId, permId: perm.permId }).first();
    if (!link) {
      await knex('sec_permissionGroupDetail').insert({ permGroupId: g.permGroupId, permId: perm.permId });
    }
  }
};

exports.down = async function (knex) {
  const perm = await knex('sec_permission').where({ permCode: 'pc-cash-book-view-detail' }).first();
  if (perm) {
    await knex('sec_permissionGroupDetail').where({ permId: perm.permId }).del();
    await knex('sec_permission').where({ permId: perm.permId }).del();
  }
};
