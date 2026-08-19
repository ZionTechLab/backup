// Seeds default pc_ref_param rows for IOU pay and cash count variance.
// ADVANCE_GL entries (Employee->1-1200, Supplier->1-1210) and
// SHORT_OVER_GL (Cash Short / Over -> 5-9000 GL account).
// Idempotent (upserts by unique index).

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

async function upsertParam(knex, scope, updatedBy, now, paramGroup, paramKey, glAccountId) {
  const existing = await knex('pc_ref_param')
    .where({ companyId: scope.companyId, paramGroup, paramKey, deleted: false })
    .first();
  if (existing) {
    await knex('pc_ref_param')
      .where({ paramId: existing.paramId })
      .update({ glAccountId, updatedBy, updatedAt: now });
  } else {
    await knex('pc_ref_param').insert({
      paramId: crypto.randomUUID(),
      tenantId: scope.tenantId,
      companyId: scope.companyId,
      paramGroup,
      paramKey,
      glAccountId,
      isActive: true,
      deleted: false,
      updatedBy,
      updatedAt: now,
    });
  }
}

exports.up = async function (knex) {
  const scope = await scopeFor(knex);
  if (!scope) return;

  const admin = await knex('mas_users').where({ userName: 'admin' }).first();
  const updatedBy = admin ? admin.userId : null;
  const now = new Date();

  // --- ADVANCE_GL defaults ---
  const advanceDefaults = [
    { paramKey: 'Employee', accountCode: '1-1200' },
    { paramKey: 'Supplier', accountCode: '1-1210' },
  ];
  for (const d of advanceDefaults) {
    const account = await knex('gl_chartOfAccounts')
      .where({ accountCode: d.accountCode, tenantId: scope.tenantId, isActive: true })
      .first();
    if (!account) continue;
    await upsertParam(knex, scope, updatedBy, now, 'ADVANCE_GL', d.paramKey, account.accountId);
  }

  // --- SHORT_OVER_GL --- Seed Cash Short / Over GL account then param ---
  const parentAccount = await knex('gl_chartOfAccounts')
    .where({ accountType: 'X', tenantId: scope.tenantId, accountCode: '5200', isActive: true })
    .first();
  if (parentAccount) {
    let shortOver = await knex('gl_chartOfAccounts')
      .where({ accountCode: '5-9000', tenantId: scope.tenantId })
      .first();
    let accountId;
    if (shortOver) {
      accountId = shortOver.accountId;
      await knex('gl_chartOfAccounts')
        .where({ accountId })
        .update({
          accountName: 'Cash Short / Over',
          parentAccountId: parentAccount.accountId,
          level: 3,
          sortOrder: 10,
          updatedBy,
          updatedAt: now,
        });
    } else {
      accountId = crypto.randomUUID();
      await knex('gl_chartOfAccounts').insert({
        accountId,
        tenantId: scope.tenantId,
        groupId: parentAccount.groupId,
        accountType: 'X',
        accountCode: '5-9000',
        accountName: 'Cash Short / Over',
        parentAccountId: parentAccount.accountId,
        level: 3,
        sortOrder: 10,
        isActive: true,
        updatedBy,
        updatedAt: now,
      });
    }

    // Upsert SHORT_OVER_GL param for every company under the demo tenant.
    const companies = await knex('sec_companies').where({ tenantId: scope.tenantId });
    for (const company of companies) {
      await upsertParam(knex, { tenantId: scope.tenantId, companyId: company.companyId }, updatedBy, now, 'SHORT_OVER_GL', 'DEFAULT', accountId);
    }
  }
};

exports.down = async function (knex) {
  const scope = await scopeFor(knex);
  if (!scope) return;

  await knex('pc_ref_param')
    .where({ companyId: scope.companyId, paramGroup: 'ADVANCE_GL' })
    .whereIn('paramKey', ['Employee', 'Supplier'])
    .del();

  const account = await knex('gl_chartOfAccounts')
    .where({ accountCode: '5-9000', tenantId: scope.tenantId })
    .first();
  if (account) {
    await knex('pc_ref_param')
      .where({ glAccountId: account.accountId })
      .del();
    await knex('gl_chartOfAccounts')
      .where({ accountId: account.accountId })
      .del();
  }
};
