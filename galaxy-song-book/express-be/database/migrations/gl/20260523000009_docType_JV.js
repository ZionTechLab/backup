exports.up = async function(knex) {
  const tenant  = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const company = await knex('sec_companies').where({ tenantId: tenant.tenantId, companyName: 'Demo Company' }).first();

  const existing = await knex('sec_docType').where({ docType: 'JV' }).first();
  if (!existing) {
    await knex('sec_docType').insert([{ docType: 'JV', docTypename: 'Journal Voucher', isActive: true }]);
  }

  return knex('conf_docType').insert([
    { tenantId: tenant.tenantId, companyId: company.companyId, docType: 'JV', isActive: true },
  ]);
};

exports.down = async function(knex) {
  await knex('conf_docType').where({ docType: 'JV' }).del();
  return knex('sec_docType').where({ docType: 'JV' }).del();
};
