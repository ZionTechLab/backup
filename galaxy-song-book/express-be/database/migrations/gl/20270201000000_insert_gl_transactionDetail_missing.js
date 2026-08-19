// Adds detail lines for the two demo transactions (docNo 1003, 2002) that were
// seeded as headers only. Without lines they show a zero amount in the JV list.
exports.up = async function(knex) {
  const tenant  = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const company = await knex('sec_companies').where({ tenantId: tenant.tenantId, companyName: 'Demo Company' }).first();
  const buying  = await knex('sec_exRateTypes').where({ tenantId: tenant.tenantId, typeName: 'Buying' }).first();

  const txns = await knex('gl_transactions')
    .where({ tenantId: tenant.tenantId, companyId: company.companyId })
    .whereIn('docNo', [1003, 2002]);

  const accounts = await knex('gl_chartOfAccounts')
    .where({ tenantId: tenant.tenantId, groupId: company.groupId })
    .whereIn('accountCode', ['1102', '2101', '4101', '5101']);

  const acc = Object.fromEntries(accounts.map(a => [a.accountCode, a.accountId]));
  const txn = Object.fromEntries(txns.map(t => [t.docNo, t]));

  const line = (docNo, lineNo, accountCode, debit, credit, currency, rate, description) => {
    const t = txn[docNo];
    return {
      transactionId: t.transactionId,
      tenantId:      tenant.tenantId,
      companyId:     company.companyId,
      fnYear:        t.fnYear,
      fnMonth:       t.fnMonth,
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
      debitBase:     parseFloat((debit  * rate).toFixed(2)),
      creditBase:    parseFloat((credit * rate).toFixed(2)),
      description,
    };
  };

  return knex('gl_transactionDetail').insert([
    // docNo 1003 — BP adjustment entry (USD, rate 299.50)
    line(1003, 1, '1102', 800.00, 0,      'USD', 299.50, 'Accounts receivable adjustment'),
    line(1003, 2, '4101', 0,      800.00, 'USD', 299.50, 'Revenue adjustment'),

    // docNo 2002 — User account reversal (LKR, rate 1.00)
    line(2002, 1, '2101', 50000.00, 0,        'LKR', 1.00, 'Reverse accounts payable — salaries'),
    line(2002, 2, '5101', 0,        50000.00, 'LKR', 1.00, 'Reverse salary expense'),
  ]);
};

exports.down = async function(knex) {
  const tenant  = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const company = await knex('sec_companies').where({ tenantId: tenant.tenantId, companyName: 'Demo Company' }).first();

  const txns = await knex('gl_transactions')
    .where({ tenantId: tenant.tenantId, companyId: company.companyId })
    .whereIn('docNo', [1003, 2002]);

  const ids = txns.map(t => t.transactionId);
  return knex('gl_transactionDetail').whereIn('transactionId', ids).del();
};
