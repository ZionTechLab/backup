exports.up = async function(knex) {
  const tenant  = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const company = await knex('sec_companies').where({ tenantId: tenant.tenantId, companyName: 'Demo Company' }).first();
  const user    = await knex('mas_users').where({ userName: 'admin' }).first();

  const base = { tenantId: tenant.tenantId, companyId: company.companyId, updatedBy: user.userId };

  // FY2026: Jan–Apr closed, May open (current period)
  return knex('gl_financialMonths').insert([
    { ...base, fnYear: 2026, fnMonth: 1,  isClosed: true  },
    { ...base, fnYear: 2026, fnMonth: 2,  isClosed: true  },
    { ...base, fnYear: 2026, fnMonth: 3,  isClosed: true  },
    { ...base, fnYear: 2026, fnMonth: 4,  isClosed: true  },
    { ...base, fnYear: 2026, fnMonth: 5,  isClosed: false },
    { ...base, fnYear: 2026, fnMonth: 6,  isClosed: false },
    { ...base, fnYear: 2026, fnMonth: 7,  isClosed: false },
    { ...base, fnYear: 2026, fnMonth: 8,  isClosed: false },
    { ...base, fnYear: 2026, fnMonth: 9,  isClosed: false },
    { ...base, fnYear: 2026, fnMonth: 10, isClosed: false },
    { ...base, fnYear: 2026, fnMonth: 11, isClosed: false },
    { ...base, fnYear: 2026, fnMonth: 12, isClosed: false },
  ]);
};

exports.down = async function(knex) {
  const tenant  = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const company = await knex('sec_companies').where({ tenantId: tenant.tenantId, companyName: 'Demo Company' }).first();
  return knex('gl_financialMonths').where({ companyId: company.companyId, fnYear: 2026 }).del();
};
