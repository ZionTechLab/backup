exports.up = async function(knex) {
  const tenant  = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const company = await knex('sec_companies').where({ tenantId: tenant.tenantId, companyName: 'Demo Company' }).first();

  const existing = await knex('sec_txnType').where({ docType: 'JV', txnType: 'JV' }).first();
  if (!existing) {
    await knex('sec_txnType').insert([{ docType: 'JV', txnType: 'JV', txnTypename: 'Journal Voucher', isActive: true }]);
  }

  return knex('conf_txnType').insert([
    { tenantId: tenant.tenantId, companyId: company.companyId, docType: 'JV', txnType: 'JV', serialNo: 0, isActive: true, isReport: true },
  ]);
};

exports.down = async function(knex) {
  await knex('conf_txnType').where({ docType: 'JV', txnType: 'JV' }).del();
  return knex('sec_txnType').where({ docType: 'JV', txnType: 'JV' }).del();
};
