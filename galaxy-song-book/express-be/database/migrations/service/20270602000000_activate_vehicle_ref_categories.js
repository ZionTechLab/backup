exports.up = async function(knex) {
  const categoryTypes = [10, 20, 30, 40, 50, 60];

  await knex('conf_category')
    .whereIn('categoryType', categoryTypes)
    .update({ isActive: true });

  const rows = [];
  for (const id of categoryTypes) {
    rows.push({ tenantId: '1', companyId: '1', id, roleId: 1,  isCategory: 1 });
    rows.push({ tenantId: '1', companyId: '1', id, roleId: -1, isCategory: 1 });
  }
  await knex('sec_userMenu').insert(rows);
};

exports.down = async function(knex) {
  const categoryTypes = [10, 20, 30, 40, 50, 60];

  await knex('conf_category')
    .whereIn('categoryType', categoryTypes)
    .update({ isActive: false });

  await knex('sec_userMenu')
    .whereIn('id', categoryTypes)
    .where('isCategory', 1)
    .del();
};
