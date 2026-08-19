// Puts Replenishment and Settlement on the central wf_levelConfig approval
// engine, same as IOU and IOU Request. Two changes:
//
// 1. New permission pc-settlement-approve, for the settlement's single
//    approval level (replenishment already has pc-replenishment-verify and
//    pc-replenishment-approve from its earlier hand-rolled status ladder,
//    reused here as the two workflow levels).
// 2. wf_levelConfig rows per company:
//      PRPL (Replenishment): level 1 Verify, level 2 Approve.
//      PSET (Settlement):    level 1 Approve — this is the payment control
//        gap being closed. Settlement previously had no approval at all
//        before Clear posted GL and disbursed cash.
//
// Idempotent: skips any company that already has a level row for that docType.

const crypto = require('crypto');

const NEW_PERMS = [
  { code: 'pc-settlement-approve', name: 'Settlement - Approve' },
];

const LEVELS = {
  PRPL: [
    { levelNo: 1, levelName: 'Verify', approverFunction: 'pc-replenishment-verify' },
    { levelNo: 2, levelName: 'Approve', approverFunction: 'pc-replenishment-approve' },
  ],
  PSET: [
    { levelNo: 1, levelName: 'Approve', approverFunction: 'pc-settlement-approve' },
  ],
};

exports.up = async function (knex) {
  const module = await knex('sec_module').where({ moduleCode: 'PETTY_CASH' }).first();
  if (module) {
    const maxPermSort = await knex('sec_permission').max('sortOrder as mx').first();
    let permSort = (maxPermSort?.mx ?? 0) + 1;

    for (const p of NEW_PERMS) {
      const existing = await knex('sec_permission').where({ permCode: p.code }).first();
      if (!existing) {
        await knex('sec_permission').insert({
          permCode: p.code, permName: p.name, moduleId: module.moduleId, sortOrder: permSort,
        });
        permSort += 1;
      }
    }

    const newPerms = await knex('sec_permission')
      .whereIn('permCode', NEW_PERMS.map((p) => p.code))
      .select('permId', 'permCode');

    const tenants = await knex('sec_tenants').select('tenantId');
    for (const t of tenants) {
      const group = await knex('sec_permissionGroup').where({ tenantId: t.tenantId, permGroupName: 'Full Access' }).first();
      if (!group) continue;
      for (const p of newPerms) {
        const exists = await knex('sec_permissionGroupDetail').where({ permGroupId: group.permGroupId, permId: p.permId }).first();
        if (!exists) {
          await knex('sec_permissionGroupDetail').insert({ permGroupId: group.permGroupId, permId: p.permId });
        }
      }
    }
  }

  const companies = await knex('sec_companies').select('tenantId', 'companyId');
  for (const c of companies) {
    for (const [docType, levels] of Object.entries(LEVELS)) {
      const existing = await knex('wf_levelConfig').where({ companyId: c.companyId, docType }).first();
      if (existing) continue;
      for (const lvl of levels) {
        await knex('wf_levelConfig').insert({
          levelId: crypto.randomUUID(),
          tenantId: c.tenantId,
          companyId: c.companyId,
          docType,
          levelNo: lvl.levelNo,
          levelName: lvl.levelName,
          approverFunction: lvl.approverFunction,
          minAmount: null,
          maxAmount: null,
          isActive: true,
          deleted: false,
          updatedAt: new Date(),
        });
      }
    }
  }
};

exports.down = async function (knex) {
  await knex('wf_levelConfig').whereIn('docType', Object.keys(LEVELS)).del();

  const perms = await knex('sec_permission').whereIn('permCode', NEW_PERMS.map((p) => p.code)).select('permId');
  const permIds = perms.map((p) => p.permId);
  if (permIds.length) {
    await knex('sec_permissionGroupDetail').whereIn('permId', permIds).del();
    await knex('sec_permission').whereIn('permId', permIds).del();
  }
};
