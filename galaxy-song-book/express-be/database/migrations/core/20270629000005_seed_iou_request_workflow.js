// Seeds approval levels for the IOU Request (PREQ) so it runs on the central
// workflow engine, same shape as PIOU. Level 1 certify (HoD), level 2 approve
// (Director). Permissions iou-request-certify / iou-request-approve already exist.

const LEVELS = {
  PREQ: [
    { levelNo: 1, levelName: 'Confirm (HoD)', approverFunction: 'iou-request-certify' },
    { levelNo: 2, levelName: 'Approve (Director)', approverFunction: 'iou-request-approve' },
  ],
};

exports.up = async function (knex) {
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
};

exports.down = async function (knex) {
  await knex('wf_levelConfig').whereIn('docType', Object.keys(LEVELS)).del();
};
