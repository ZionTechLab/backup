exports.up = async function(knex) {
  const tenant = await knex('sec_tenants').where({ tenantName: 'demo' }).first();

  return knex('sec_exRateTypes').insert([
    { tenantId: tenant.tenantId, typeName: 'Buying',   description: 'Rate at which currency is bought',     isActive: true  },
    { tenantId: tenant.tenantId, typeName: 'Selling',  description: 'Rate at which currency is sold',       isActive: true  },
    { tenantId: tenant.tenantId, typeName: 'Official', description: 'Central bank official exchange rate',  isActive: true  },
    { tenantId: tenant.tenantId, typeName: 'Mid',      description: 'Midpoint between buying and selling',  isActive: false },
  ]);
};

exports.down = async function(knex) {
  const tenant = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  return knex('sec_exRateTypes').where({ tenantId: tenant.tenantId }).del();
};
