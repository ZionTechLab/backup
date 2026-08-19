exports.up = async function(knex) {
  const tenant  = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const company = await knex('sec_companies').where({ tenantId: tenant.tenantId, companyName: 'Demo Company' }).first();
  const buying  = await knex('sec_exRateTypes').where({ tenantId: tenant.tenantId, typeName: 'Buying' }).first();

  const txns = await knex('gl_transactions')
    .where({ tenantId: tenant.tenantId, companyId: company.companyId })
    .orderBy('docNo');

  const accounts = await knex('gl_chartOfAccounts')
    .where({ tenantId: tenant.tenantId, groupId: company.groupId })
    .whereIn('accountCode', ['1101', '1102', '2101', '4101', '5101', '5102']);

  const acc = Object.fromEntries(accounts.map(a => [a.accountCode, a.accountId]));

  const txn = Object.fromEntries(txns.map(t => [t.docNo, t]));

  const line = (docNo, lineNo, accountCode, debit, credit, currency, rate, description) => {
    const t = txn[docNo];
    const baseDebit  = parseFloat((debit  * rate).toFixed(2));
    const baseCredit = parseFloat((credit * rate).toFixed(2));
    return {
      transactionId: t.transactionId,
      tenantId:      tenant.tenantId,
      companyId:     company.companyId,
      txnYear:       t.txnYear,
      txnMonth:      t.txnMonth,
      docType:       t.docType,
      txnType:       t.txnType,
      docNo:         t.docNo,
      txnDate:       t.txnDate,
      lineId:        lineNo,
      lineNo,
      accountId:     acc[accountCode],
      debitAmount:   debit,
      creditAmount:  credit,
      currencyCode:  currency,
      exchangeRate:  rate,
      rateTypeId:    buying.rateTypeId,
      debitBase:     baseDebit,
      creditBase:    baseCredit,
      description,
    };
  };

  return knex('gl_transactionDetail').insert([
    // docNo 1001 — BP payment received (USD, rate 299.50)
    line(1001, 1, '1101', 1500.00, 0,       'USD', 299.50, 'Cash received from business partner'),
    line(1001, 2, '1102', 0,       1500.00, 'USD', 299.50, 'Clear accounts receivable'),

    // docNo 1002 — BP adjustment (USD, rate 299.50)
    line(1002, 1, '4101', 0,       2000.00, 'USD', 299.50, 'Sales revenue recognised'),
    line(1002, 2, '1102', 2000.00, 0,       'USD', 299.50, 'Accounts receivable raised'),

    // docNo 2001 — User account charge (LKR, rate 1.00)
    line(2001, 1, '5101', 50000.00, 0,       'LKR', 1.00, 'Salary expense for user provisioning'),
    line(2001, 2, '2101', 0,        50000.00,'LKR', 1.00, 'Accounts payable — salaries'),

    // docNo 1004 — June opening entry (USD, rate 301.00)
    line(1004, 1, '5102', 3000.00, 0,       'USD', 301.00, 'Rent expense — June'),
    line(1004, 2, '2101', 0,       3000.00, 'USD', 301.00, 'Accounts payable — rent'),
  ]);
};

exports.down = async function(knex) {
  const tenant  = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const company = await knex('sec_companies').where({ tenantId: tenant.tenantId, companyName: 'Demo Company' }).first();
  return knex('gl_transactionDetail').where({ tenantId: tenant.tenantId, companyId: company.companyId }).del();
};
