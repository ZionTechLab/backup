// Seeds a default Main Cash Book for every company under the demo tenant.
// Uses Cash & Cash Equivalents (1101) as the GL account, LKR as currency,
// and the admin user as cashier. Idempotent — skips if a cashbook with
// the same companyId + name already exists.

const crypto = require('crypto');

async function scopeFor(knex) {
  const tenant = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  if (!tenant) return null;
  const company = await knex('sec_companies')
    .where({ tenantId: tenant.tenantId, companyName: 'Demo Company' })
    .first();
  if (!company) return null;
  return { tenantId: tenant.tenantId, companyId: company.companyId };
}

exports.up = async function (knex) {
  const scope = await scopeFor(knex);
  if (!scope) return;

  const admin = await knex('mas_users').where({ userName: 'admin' }).first();
  if (!admin) return;

  const updatedBy = admin.userId;
  const cashierUserId = admin.userId;
  const now = new Date();

  // Resolve the GL account — Cash & Cash Equivalents (1101) under demo tenant.
  const glAccount = await knex('gl_chartOfAccounts')
    .where({ accountCode: '1101', tenantId: scope.tenantId, isActive: true })
    .first();
  if (!glAccount) return;

  // Resolve LKR currency.
  const currency = await knex('sec_currencies')
    .where({ currencyCode: 'LKR' })
    .first();
  if (!currency) return;

  // One default cashbook per company under the demo tenant.
  const companies = await knex('sec_companies').where({ tenantId: scope.tenantId });
  for (const company of companies) {
    const existing = await knex('pc_mas_cashBook')
      .where({ companyId: company.companyId, name: 'Main Cash Book', deleted: false })
      .first();

    if (existing) {
      // Ensure the row is up to date with the latest defaults.
      await knex('pc_mas_cashBook')
        .where({ cashBookId: existing.cashBookId })
        .update({
          code: 'MAIN',
          currencyCode: 'LKR',
          glAccountId: glAccount.accountId,
          cashierUserId,
          floatLimit: 50000.00,
          topUpThreshold: 10000.00,
          isActive: true,
          status: 'Active',
          minFloat: 0.00,
          maxFloat: 50000.00,
          iouClosingDays: 30,
          updatedBy,
          updatedAt: now,
        });
    } else {
      await knex('pc_mas_cashBook').insert({
        cashBookId: crypto.randomUUID(),
        tenantId: scope.tenantId,
        companyId: company.companyId,
        code: 'MAIN',
        name: 'Main Cash Book',
        cashierUserId,
        currencyCode: 'LKR',
        glAccountId: glAccount.accountId,
        floatLimit: 50000.00,
        topUpThreshold: 10000.00,
        isActive: true,
        status: 'Active',
        minFloat: 0.00,
        maxFloat: 50000.00,
        iouClosingDays: 30,
        remarks: 'Default cash book created by system seed',
        deleted: false,
        updatedBy,
        updatedAt: now,
      });
    }
  }
};

exports.down = async function (knex) {
  const scope = await scopeFor(knex);
  if (!scope) return;
  await knex('pc_mas_cashBook')
    .where({ tenantId: scope.tenantId, name: 'Main Cash Book' })
    .del();
};
