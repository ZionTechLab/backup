exports.up = async function(knex) {
  const tenant = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const group  = await knex('sec_groups').where({ tenantId: tenant.tenantId }).first();

  return knex('ref_roles').insert([
    { tenantId: tenant.tenantId, groupId: group.groupId, id: 4, roleName: 'HRM Users', isActive: true },
  ]);
};

exports.down = function(knex) {
  return knex('ref_roles').where('id', 4).del();
};
