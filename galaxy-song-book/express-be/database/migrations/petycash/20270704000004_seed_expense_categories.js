// Seeds default petty cash categories for vouchers, linked to appropriate GL
// expense accounts. Idempotent — skips any category that
// already exists per company.

const crypto = require('crypto');

const CATEGORIES = [
  { name: 'Office Supplies', glAccount: '5200', taxMode: 'exempt', taxRate: 0 },
  { name: 'Meals & Entertainment', glAccount: '5100', taxMode: 'exempt', taxRate: 0 },
  { name: 'Transportation', glAccount: '5100', taxMode: 'exempt', taxRate: 0 },
  { name: 'Postage & Shipping', glAccount: '5200', taxMode: 'exempt', taxRate: 0 },
  { name: 'Miscellaneous', glAccount: '5100', taxMode: 'exempt', taxRate: 0 },
];

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
  const updatedBy = admin ? admin.userId : null;
  const now = new Date();

  for (const cat of CATEGORIES) {
    const existing = await knex('pc_ref_expenseCategory')
      .where({ companyId: scope.companyId, name: cat.name, deleted: false })
      .first();
    if (existing) continue;

    const glAccount = await knex('gl_chartOfAccounts')
      .where({ accountCode: cat.glAccount, tenantId: scope.tenantId, isActive: true })
      .first();
    if (!glAccount) continue;

    await knex('pc_ref_expenseCategory').insert({
      categoryId: crypto.randomUUID(),
      tenantId: scope.tenantId,
      companyId: scope.companyId,
      name: cat.name,
      glAccountId: glAccount.accountId,
      taxMode: cat.taxMode,
      taxRate: cat.taxRate,
      inputVatGlAccountId: null,
      isActive: true,
      deleted: false,
      updatedBy,
      updatedAt: now,
    });
  }
};

exports.down = async function (knex) {
  const scope = await scopeFor(knex);
  if (!scope) return;
  await knex('pc_ref_expenseCategory')
    .where({ tenantId: scope.tenantId, companyId: scope.companyId })
    .del();
};
