// Seeds default approval levels for the IOU (PIOU), plus the Workflow permission
// codes, added to every tenant's Full Access group so Admin keeps working.

const LEVELS = {
  PIOU: [
    { levelNo: 1, levelName: 'Confirm (HoD)', approverFunction: 'pc-iou-certify' },
    { levelNo: 2, levelName: 'Approve (Director)', approverFunction: 'pc-iou-approve' },
  ],
};

const PERMS = [
  { code: 'wf-config-view', name: 'Approval Levels - View' },
  { code: 'wf-config-save', name: 'Approval Levels - Save' },
  { code: 'wf-config-delete', name: 'Approval Levels - Delete' },
  { code: 'approvals-view', name: 'My Approvals - View' },
];

exports.up = async function (knex) {
  // Level config per company.
  const companies = await knex('sec_companies').select('tenantId', 'companyId');
  for (const c of companies) {
    for (const [docType, levels] of Object.entries(LEVELS)) {
      for (const l of levels) {
        const exists = await knex('wf_levelConfig')
          .where({ companyId: c.companyId, docType, levelNo: l.levelNo }).first();
        if (!exists) {
          await knex('wf_levelConfig').insert({
            tenantId: c.tenantId, companyId: c.companyId, docType,
            levelNo: l.levelNo, levelName: l.levelName, approverFunction: l.approverFunction,
            isActive: true,
          });
        }
      }
    }
  }

  // Permission catalog: a Workflow module and its codes.
  let mod = await knex('sec_module').where({ moduleCode: 'WORKFLOW' }).first();
  if (!mod) {
    await knex('sec_module').insert({ moduleCode: 'WORKFLOW', moduleName: 'Workflow', sortOrder: 70 });
    mod = await knex('sec_module').where({ moduleCode: 'WORKFLOW' }).first();
  }
  for (const p of PERMS) {
    const exists = await knex('sec_permission').where({ permCode: p.code }).first();
    if (!exists) {
      await knex('sec_permission').insert({ permCode: p.code, permName: p.name, moduleId: mod.moduleId, isActive: true });
    }
  }

  // Add the new permissions to every Full Access group.
  const permIds = await knex('sec_permission').whereIn('permCode', PERMS.map((p) => p.code)).pluck('permId');
  const groups = await knex('sec_permissionGroup').where({ permGroupName: 'Full Access' }).select('permGroupId');
  for (const g of groups) {
    for (const permId of permIds) {
      const has = await knex('sec_permissionGroupDetail').where({ permGroupId: g.permGroupId, permId }).first();
      if (!has) await knex('sec_permissionGroupDetail').insert({ permGroupId: g.permGroupId, permId });
    }
  }
};

exports.down = async function (knex) {
  const codes = PERMS.map((p) => p.code);
  const permIds = await knex('sec_permission').whereIn('permCode', codes).pluck('permId');
  if (permIds.length) await knex('sec_permissionGroupDetail').whereIn('permId', permIds).del();
  await knex('sec_permission').whereIn('permCode', codes).del();
  await knex('sec_module').where({ moduleCode: 'WORKFLOW' }).del();
  await knex('wf_levelConfig').whereIn('docType', Object.keys(LEVELS)).del();
};
