exports.up = async function(knex) {
  const tenant = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  if (!tenant) return;

  const users = await knex('mas_users').select('userId');
  if (!users.length) return;

  await knex('sec_userTenants').insert(
    users.map(u => ({ userId: u.userId, tenantId: tenant.tenantId, isDefault: true }))
  );
};

exports.down = function(knex) {
  return knex('sec_userTenants').del();
};
