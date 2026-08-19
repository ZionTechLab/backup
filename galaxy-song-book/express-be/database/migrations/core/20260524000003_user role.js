exports.up = async function(knex) {
  const tenant = await knex('sec_tenants').first('tenantId');
  const group  = await knex('sec_groups').where({ tenantId: tenant.tenantId }).first('groupId');

  await knex('ref_roles').insert([
    { tenantId: tenant.tenantId, groupId: group.groupId, id: 1, roleName: 'Admin', isActive: true },
    { tenantId: tenant.tenantId, groupId: group.groupId, id: 2, roleName: 'User',  isActive: true },
    { tenantId: tenant.tenantId, groupId: group.groupId, id: 3, roleName: 'Guest', isActive: true },
  ]);
};

exports.down = function(knex) {
  return knex('ref_roles').del();
};
