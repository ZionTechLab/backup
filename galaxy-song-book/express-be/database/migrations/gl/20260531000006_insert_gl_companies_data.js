exports.up = async function(knex) {
  const tenant  = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const company = await knex('sec_companies').where({ tenantId: tenant.tenantId, companyName: 'Demo Company' }).first();
  const user    = await knex('mas_users').where({ userName: 'admin' }).first();

  return knex('gl_companies').insert({
    companyId:               company.companyId,
    tenantId:                tenant.tenantId,
    financialYearStartMonth: 1,
    currentFinYear:          2026,
    currentFinMonth:         5,
    isActive:                true,
    updatedBy:               user.userId,
  });
};

exports.down = async function(knex) {
  const tenant  = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const company = await knex('sec_companies').where({ tenantId: tenant.tenantId, companyName: 'Demo Company' }).first();
  return knex('gl_companies').where({ companyId: company.companyId }).del();
};
