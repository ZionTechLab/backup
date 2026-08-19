// The default cash book seed pointed every company's Main Cash Book at the
// generic "Cash & Cash Equivalents" (1101) GL account. That account is also
// used by ordinary journal entries (e.g. business-partner opening balances),
// so the Cash Book Balances report summed unrelated postings into the
// cash book's balance.
//
// This migration gives each company's cash book its own dedicated sub-account
// under 1101, e.g. "1101.01 - Petty Cash - Main Cash Book", and repoints the
// cash book to it. Historical postings already made against 1101 are left in
// place — they were not petty cash transactions and rewriting ledger history
// in a migration is out of scope. Going forward, petty cash Pay/Replenishment
// entries post to the dedicated account, so the report reflects only real
// petty cash activity.

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
  const updatedBy = admin ? admin.userId : null;
  const now = new Date();

  const parent = await knex('gl_chartOfAccounts')
    .where({ accountCode: '1101', tenantId: scope.tenantId, isActive: true })
    .first();
  if (!parent) return;

  const companies = await knex('sec_companies').where({ tenantId: scope.tenantId });

  for (const company of companies) {
    const cashBooks = await knex('pc_mas_cashBook')
      .where({ companyId: company.companyId, deleted: false });

    for (const book of cashBooks) {
      // Idempotent: skip if this book no longer points at the shared 1101 account.
      if (book.glAccountId !== parent.accountId) continue;

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
        accountName: `Petty Cash - ${book.name}`,
        parentAccountId: parent.accountId,
        level: parent.level + 1,
        sortOrder: Number(siblingCount.c) + 1,
        isActive: true,
        updatedBy,
        updatedAt: now,
      });

      await knex('pc_mas_cashBook')
        .where({ cashBookId: book.cashBookId })
        .update({ glAccountId: accountId, updatedBy, updatedAt: now });
    }
  }
};

exports.down = async function (knex) {
  const scope = await scopeFor(knex);
  if (!scope) return;

  const parent = await knex('gl_chartOfAccounts')
    .where({ accountCode: '1101', tenantId: scope.tenantId })
    .first();
  if (!parent) return;

  const dedicated = await knex('gl_chartOfAccounts')
    .where({ parentAccountId: parent.accountId })
    .andWhere('accountName', 'like', 'Petty Cash - %');

  for (const acc of dedicated) {
    await knex('pc_mas_cashBook')
      .where({ glAccountId: acc.accountId })
      .update({ glAccountId: parent.accountId });
    await knex('gl_chartOfAccounts').where({ accountId: acc.accountId }).del();
  }
};
