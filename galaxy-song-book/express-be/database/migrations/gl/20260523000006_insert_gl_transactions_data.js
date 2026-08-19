exports.up = async function(knex) {
  const tenant  = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const company = await knex('sec_companies').where({ tenantId: tenant.tenantId, companyName: 'Demo Company' }).first();
  const user    = await knex('mas_users').where({ userName: 'admin' }).first();

  const base = {
    tenantId:  tenant.tenantId,
    companyId: company.companyId,
    updatedBy: user.userId,
  };

  return knex('gl_transactions').insert([
    { ...base, txnYear: 2026, txnMonth: 5, docType: 'BP', txnType: 'BP', docNo: 1001, txnDate: '2026-05-01', reference: 'BP-2026-001', description: 'Business partner transaction - May opening',  status: 'Posted' },
    { ...base, txnYear: 2026, txnMonth: 5, docType: 'BP', txnType: 'BP', docNo: 1002, txnDate: '2026-05-05', reference: 'BP-2026-002', description: 'Business partner payment received',            status: 'Posted' },
    { ...base, txnYear: 2026, txnMonth: 5, docType: 'BP', txnType: 'BP', docNo: 1003, txnDate: '2026-05-10', reference: 'BP-2026-003', description: 'Business partner adjustment entry',            status: 'Draft'  },
    { ...base, txnYear: 2026, txnMonth: 5, docType: 'USR', txnType: 'USR', docNo: 2001, txnDate: '2026-05-12', reference: 'USR-2026-001', description: 'User account provisioning charge',         status: 'Posted' },
    { ...base, txnYear: 2026, txnMonth: 5, docType: 'USR', txnType: 'USR', docNo: 2002, txnDate: '2026-05-15', reference: 'USR-2026-002', description: 'User account reversal',                    status: 'Void'   },
    { ...base, txnYear: 2026, txnMonth: 6, docType: 'BP', txnType: 'BP', docNo: 1004, txnDate: '2026-06-01', reference: 'BP-2026-004', description: 'Business partner transaction - June opening', status: 'Draft'  },
  ]);
};

exports.down = async function(knex) {
  const tenant  = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const company = await knex('sec_companies').where({ tenantId: tenant.tenantId, companyName: 'Demo Company' }).first();
  return knex('gl_transactions').where({ tenantId: tenant.tenantId, companyId: company.companyId }).del();
};
