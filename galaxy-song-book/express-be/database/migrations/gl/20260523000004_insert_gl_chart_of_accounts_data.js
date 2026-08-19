const { randomUUID } = require('crypto');

exports.up = async function(knex) {
  const uuidv4 = () => randomUUID();
  const tenant = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const group  = await knex('sec_groups').where({ tenantId: tenant.tenantId, groupName: 'Headquarters' }).first();
  const user   = await knex('mas_users').where({ userName: 'admin' }).first();

  const base = { tenantId: tenant.tenantId, groupId: group.groupId, updatedBy: user.userId };

  // Level 1 — root accounts
  const ids = {
    assets:      uuidv4(),
    liabilities: uuidv4(),
    equity:      uuidv4(),
    income:      uuidv4(),
    expenses:    uuidv4(),
    // Level 2
    currentAssets:    uuidv4(),
    fixedAssets:      uuidv4(),
    currentLiab:      uuidv4(),
    longTermLiab:     uuidv4(),
    revenue:          uuidv4(),
    otherIncome:      uuidv4(),
    opExpenses:       uuidv4(),
    adminExpenses:    uuidv4(),
    // Level 3
    cash:             uuidv4(),
    accountsRec:      uuidv4(),
    inventory:        uuidv4(),
    ppe:              uuidv4(),
    accountsPay:      uuidv4(),
    shortTermLoans:   uuidv4(),
    salesRevenue:     uuidv4(),
    salaries:         uuidv4(),
    rent:             uuidv4(),
    utilities:        uuidv4(),
  };

  return knex('gl_chartOfAccounts').insert([
    // Level 1
    { ...base, accountId: ids.assets,      accountType: 'A', accountCode: '1000', accountName: 'Assets',                 parentAccountId: null,              level: 1, sortOrder: 1 },
    { ...base, accountId: ids.liabilities, accountType: 'L', accountCode: '2000', accountName: 'Liabilities',            parentAccountId: null,              level: 1, sortOrder: 2 },
    { ...base, accountId: ids.equity,      accountType: 'E', accountCode: '3000', accountName: 'Equity',                 parentAccountId: null,              level: 1, sortOrder: 3 },
    { ...base, accountId: ids.income,      accountType: 'I', accountCode: '4000', accountName: 'Income',                 parentAccountId: null,              level: 1, sortOrder: 4 },
    { ...base, accountId: ids.expenses,    accountType: 'X', accountCode: '5000', accountName: 'Expenses',               parentAccountId: null,              level: 1, sortOrder: 5 },
    // Level 2 — Assets
    { ...base, accountId: ids.currentAssets,  accountType: 'A', accountCode: '1100', accountName: 'Current Assets',     parentAccountId: ids.assets,        level: 2, sortOrder: 1 },
    { ...base, accountId: ids.fixedAssets,    accountType: 'A', accountCode: '1200', accountName: 'Fixed Assets',       parentAccountId: ids.assets,        level: 2, sortOrder: 2 },
    // Level 2 — Liabilities
    { ...base, accountId: ids.currentLiab,    accountType: 'L', accountCode: '2100', accountName: 'Current Liabilities',parentAccountId: ids.liabilities,   level: 2, sortOrder: 1 },
    { ...base, accountId: ids.longTermLiab,   accountType: 'L', accountCode: '2200', accountName: 'Long-Term Liabilities',parentAccountId: ids.liabilities,  level: 2, sortOrder: 2 },
    // Level 2 — Income
    { ...base, accountId: ids.revenue,        accountType: 'I', accountCode: '4100', accountName: 'Revenue',            parentAccountId: ids.income,        level: 2, sortOrder: 1 },
    { ...base, accountId: ids.otherIncome,    accountType: 'I', accountCode: '4200', accountName: 'Other Income',       parentAccountId: ids.income,        level: 2, sortOrder: 2 },
    // Level 2 — Expenses
    { ...base, accountId: ids.opExpenses,     accountType: 'X', accountCode: '5100', accountName: 'Operating Expenses', parentAccountId: ids.expenses,      level: 2, sortOrder: 1 },
    { ...base, accountId: ids.adminExpenses,  accountType: 'X', accountCode: '5200', accountName: 'Admin Expenses',     parentAccountId: ids.expenses,      level: 2, sortOrder: 2 },
    // Level 3 — Current Assets
    { ...base, accountId: ids.cash,           accountType: 'A', accountCode: '1101', accountName: 'Cash & Cash Equivalents', parentAccountId: ids.currentAssets, level: 3, sortOrder: 1 },
    { ...base, accountId: ids.accountsRec,    accountType: 'A', accountCode: '1102', accountName: 'Accounts Receivable',    parentAccountId: ids.currentAssets, level: 3, sortOrder: 2 },
    { ...base, accountId: ids.inventory,      accountType: 'A', accountCode: '1103', accountName: 'Inventory',               parentAccountId: ids.currentAssets, level: 3, sortOrder: 3 },
    // Level 3 — Fixed Assets
    { ...base, accountId: ids.ppe,            accountType: 'A', accountCode: '1201', accountName: 'Property, Plant & Equipment', parentAccountId: ids.fixedAssets, level: 3, sortOrder: 1 },
    // Level 3 — Current Liabilities
    { ...base, accountId: ids.accountsPay,    accountType: 'L', accountCode: '2101', accountName: 'Accounts Payable',     parentAccountId: ids.currentLiab,  level: 3, sortOrder: 1 },
    { ...base, accountId: ids.shortTermLoans, accountType: 'L', accountCode: '2102', accountName: 'Short-Term Loans',     parentAccountId: ids.currentLiab,  level: 3, sortOrder: 2 },
    // Level 3 — Revenue
    { ...base, accountId: ids.salesRevenue,   accountType: 'I', accountCode: '4101', accountName: 'Sales Revenue',        parentAccountId: ids.revenue,       level: 3, sortOrder: 1 },
    // Level 3 — Operating Expenses
    { ...base, accountId: ids.salaries,       accountType: 'X', accountCode: '5101', accountName: 'Salaries & Wages',     parentAccountId: ids.opExpenses,    level: 3, sortOrder: 1 },
    { ...base, accountId: ids.rent,           accountType: 'X', accountCode: '5102', accountName: 'Rent',                 parentAccountId: ids.opExpenses,    level: 3, sortOrder: 2 },
    { ...base, accountId: ids.utilities,      accountType: 'X', accountCode: '5103', accountName: 'Utilities',            parentAccountId: ids.opExpenses,    level: 3, sortOrder: 3 },
  ]);
};

exports.down = async function(knex) {
  const tenant = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  return knex('gl_chartOfAccounts').where({ tenantId: tenant.tenantId }).del();
};
