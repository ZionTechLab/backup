// Denormalized display fields on the workflow state, so the My Approvals inbox
// can show a human document number and summary without joining each feature's
// table. Populated by the feature via workflow.start/act. Display-only.

exports.up = async function (knex) {
  const hasDocNo = await knex.schema.hasColumn('wf_approvalState', 'docNo');
  const hasSummary = await knex.schema.hasColumn('wf_approvalState', 'summary');
  await knex.schema.alterTable('wf_approvalState', (t) => {
    if (!hasDocNo) t.string('docNo', 64).nullable();
    if (!hasSummary) t.string('summary', 255).nullable();
  });
};

exports.down = async function (knex) {
  const hasDocNo = await knex.schema.hasColumn('wf_approvalState', 'docNo');
  const hasSummary = await knex.schema.hasColumn('wf_approvalState', 'summary');
  await knex.schema.alterTable('wf_approvalState', (t) => {
    if (hasDocNo) t.dropColumn('docNo');
    if (hasSummary) t.dropColumn('summary');
  });
};
