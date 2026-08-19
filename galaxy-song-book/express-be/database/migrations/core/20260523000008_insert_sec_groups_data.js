exports.up = async function(knex) {
  const tenant = await knex('sec_tenants').where({ tenantName: 'demo' }).first();

  return knex('sec_groups').insert([
    { tenantId: tenant.tenantId, groupName: 'Headquarters',    baseCurrencyCode: 'USD', isActive: true },
    { tenantId: tenant.tenantId, groupName: 'Asia Pacific',    baseCurrencyCode: 'LKR', isActive: true },
    { tenantId: tenant.tenantId, groupName: 'Europe Division', baseCurrencyCode: 'EUR', isActive: true },
    { tenantId: tenant.tenantId, groupName: 'India Cluster',   baseCurrencyCode: 'INR', isActive: false },
  ]);
};

exports.down = async function(knex) {
  const tenant = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  return knex('sec_groups').where({ tenantId: tenant.tenantId }).del();
};
