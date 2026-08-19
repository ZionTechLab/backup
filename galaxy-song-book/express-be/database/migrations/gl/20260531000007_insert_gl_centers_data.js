exports.up = async function(knex) {
  const tenant  = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const company = await knex('sec_companies').where({ tenantId: tenant.tenantId, companyName: 'Demo Company' }).first();
  const user    = await knex('mas_users').where({ userName: 'admin' }).first();

  const base = { tenantId: tenant.tenantId, companyId: company.companyId, updatedBy: user.userId };

  return knex('gl_centers').insert([
    // Cost centres
    { ...base, centerCode: 'MKT', centerName: 'Marketing',     isProfitCenter: false, parentCenterCode: null },
    { ...base, centerCode: 'OPS', centerName: 'Operations',    isProfitCenter: false, parentCenterCode: null },
    { ...base, centerCode: 'ADM', centerName: 'Administration', isProfitCenter: false, parentCenterCode: null },
    // Profit centres
    { ...base, centerCode: 'PRD', centerName: 'Products',  isProfitCenter: true, parentCenterCode: null },
    { ...base, centerCode: 'SVC', centerName: 'Services',  isProfitCenter: true, parentCenterCode: null },
  ]);
};

exports.down = async function(knex) {
  const tenant  = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const company = await knex('sec_companies').where({ tenantId: tenant.tenantId, companyName: 'Demo Company' }).first();
  return knex('gl_centers').where({ companyId: company.companyId }).del();
};
