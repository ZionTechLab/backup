exports.up = async function(knex) {
  const tenant  = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const company = await knex('sec_companies').where({ tenantId: tenant.tenantId, companyName: 'Demo Company' }).first();

  return knex('conf_txnType').insert([
    { tenantId: tenant.tenantId, companyId: company.companyId, docType: 'USR', txnType: 'USR', serialNo: 0, isActive: true, isReport: true },
    { tenantId: tenant.tenantId, companyId: company.companyId, docType: 'BP',  txnType: 'BP',  serialNo: 0, isActive: true, isReport: true },
  ]);
};

exports.down = function(knex) {
  return knex('conf_txnType').whereIn('txnType', ['USR', 'BP']).del();
};
