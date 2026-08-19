// Audit rows need a tenant for per-tenant scoping. Adds tenantId and backfills
// it from each snapshot's own tenantId where present (most domain tables carry
// one). Rows whose snapshot has no tenantId stay null (visible only globally).
exports.up = async function (knex) {
  await knex.schema.alterTable('sec_auditHistory', (t) => {
    t.string('tenantId', 36).nullable().index();
  });

  const rows = await knex('sec_auditHistory').select('historyId', 'snapshot');
  for (const r of rows) {
    try {
      const snap = JSON.parse(r.snapshot);
      if (snap && snap.tenantId != null) {
        await knex('sec_auditHistory')
          .where({ historyId: r.historyId })
          .update({ tenantId: String(snap.tenantId) });
      }
    } catch (e) {
      // skip unparseable snapshots
    }
  }
};

exports.down = async function (knex) {
  await knex.schema.alterTable('sec_auditHistory', (t) => {
    t.dropColumn('tenantId');
  });
};
