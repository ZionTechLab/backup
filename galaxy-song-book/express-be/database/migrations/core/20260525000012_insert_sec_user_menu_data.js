exports.up = async function(knex) {
  const tenant  = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const company = await knex('sec_companies').where({ tenantId: tenant.tenantId, companyName: 'Demo Company' }).first();
  const base = { tenantId: tenant.tenantId, companyId: company.companyId };

  return knex('sec_userMenu').insert([
    { ...base, id: 130, roleId: 1 },
    { ...base, id: 140, roleId: 1 },
    { ...base, id: 150, roleId: 1 },
    { ...base, id: 160, roleId: 1 },
    { ...base, id: 130, roleId: -1 },
    { ...base, id: 140, roleId: -1 },
    { ...base, id: 150, roleId: -1 },
    { ...base, id: 160, roleId: -1 },
  ]);
};

exports.down = async function(knex) {
  const tenant = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  return knex('sec_userMenu').where({ tenantId: tenant.tenantId }).del();
};
