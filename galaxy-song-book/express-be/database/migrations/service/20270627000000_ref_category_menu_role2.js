exports.up = async function(knex) {
  const categoryTypes = [10, 20, 30, 40, 50, 60];
  const rows = categoryTypes.map(id => ({
    tenantId: '1', companyId: '1', id, roleId: 2, isCategory: 1,
  }));
  await knex('sec_userMenu').insert(rows);
};

exports.down = async function(knex) {
  await knex('sec_userMenu')
    .whereIn('id', [10, 20, 30, 40, 50, 60])
    .where({ isCategory: 1, roleId: 2 })
    .del();
};
