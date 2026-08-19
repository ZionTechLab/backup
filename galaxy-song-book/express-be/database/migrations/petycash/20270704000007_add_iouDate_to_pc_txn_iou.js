// Adds iouDate to pc_txn_iou. This originally lived as an orphan file in the
// root database/migrations directory, which no stream scans, so a per-stream
// rebuild (migrate:petycash) silently skipped it and left the column missing.
// Relocated into the petycash stream so rebuilds include it. Idempotent in case
// a legacy DB already has the column from the old root migration.

exports.up = async function (knex) {
  const has = await knex.schema.hasColumn('pc_txn_iou', 'iouDate');
  if (has) return;
  await knex.schema.alterTable('pc_txn_iou', function (t) {
    t.date('iouDate');
  });
};

exports.down = async function (knex) {
  const has = await knex.schema.hasColumn('pc_txn_iou', 'iouDate');
  if (!has) return;
  await knex.schema.alterTable('pc_txn_iou', function (t) {
    t.dropColumn('iouDate');
  });
};
