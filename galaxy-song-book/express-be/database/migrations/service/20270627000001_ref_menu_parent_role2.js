exports.up = async function(knex) {
  const tenantId = 'b6e0c530-4588-4d26-b073-44a5f56c9c34';
  const companyId = 'b8191325-80b9-44e6-90d0-bd9a08652739';
  await knex('sec_userMenu').insert({
    tenantId, companyId, id: 160, roleId: 2, isCategory: 0,
  });
};

exports.down = async function(knex) {
  await knex('sec_userMenu').where({ id: 160, roleId: 2, isCategory: 0 }).del();
};
