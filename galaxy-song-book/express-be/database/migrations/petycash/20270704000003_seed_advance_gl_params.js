// IOU Pay resolves the advance GL account from pc_ref_param (group ADVANCE_GL,
// key = partyType), and there was no data for it, so Pay failed for every
// party type with "No advance GL account configured for X".
//
// This creates a dedicated sub-account per party type under 1102 Accounts
// Receivable (an IOU advance is a receivable until settled or expensed), and
// seeds the matching ADVANCE_GL param for each company. Idempotent: skips any
// party type that already has a param.

const crypto = require('crypto');

const PARTY_TYPES = [
  { key: 'Employee', label: 'Employee' },
  { key: 'Contractor', label: 'Contractor' },
  { key: 'Supplier', label: 'Supplier' },
  { key: 'Customer', label: 'Customer' },
  { key: 'ThirdParty', label: 'Third Party' },
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

  const parent = await knex('gl_chartOfAccounts')
    .where({ accountCode: '1102', tenantId: scope.tenantId, isActive: true })
    .first();
  if (!parent) return;

  const companies = await knex('sec_companies').where({ tenantId: scope.tenantId });

  for (const company of companies) {
    for (const pt of PARTY_TYPES) {
      const existingParam = await knex('pc_ref_param')
        .where({ companyId: company.companyId, paramGroup: 'ADVANCE_GL', paramKey: pt.key, deleted: false })
        .first();
      if (existingParam) continue;

      let account = await knex('gl_chartOfAccounts')
        .where({ parentAccountId: parent.accountId, accountName: `Advances - ${pt.label}`, tenantId: scope.tenantId })
        .first();

      if (!account) {
        const siblingCount = await knex('gl_chartOfAccounts')
          .where({ parentAccountId: parent.accountId }).count('* as c').first();
        const seq = String(Number(siblingCount.c) + 1).padStart(2, '0');
        const accountId = crypto.randomUUID();
        await knex('gl_chartOfAccounts').insert({
          accountId,
          tenantId: scope.tenantId,
          groupId: parent.groupId,
          accountType: parent.accountType,
          accountCode: `${parent.accountCode}.${seq}`,
          accountName: `Advances - ${pt.label}`,
          parentAccountId: parent.accountId,
          level: parent.level + 1,
          sortOrder: Number(siblingCount.c) + 1,
          isActive: true,
          updatedBy,
          updatedAt: now,
        });
        account = { accountId };
      }

      await knex('pc_ref_param').insert({
        paramId: crypto.randomUUID(),
        tenantId: scope.tenantId,
        companyId: company.companyId,
        paramGroup: 'ADVANCE_GL',
        paramKey: pt.key,
        glAccountId: account.accountId,
        isActive: true,
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
  await knex('pc_ref_param')
    .where({ tenantId: scope.tenantId, paramGroup: 'ADVANCE_GL' })
    .del();
  // Leave the GL accounts in place — they may already be referenced by
  // posted IOU Pay transactions by the time this would be rolled back.
};
