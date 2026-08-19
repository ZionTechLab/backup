exports.up = async function(knex) {
  const tenant  = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const company = await knex('sec_companies').where({ tenantId: tenant.tenantId, companyName: 'Demo Company' }).first();

  return knex('conf_docType').insert([
    { tenantId: tenant.tenantId, companyId: company.companyId, docType: 'USR', isActive: true },
    { tenantId: tenant.tenantId, companyId: company.companyId, docType: 'BP',  isActive: true },
  ]);
};

exports.down = function(knex) {
  return knex('conf_docType').whereIn('docType', ['USR', 'BP']).del();
};
