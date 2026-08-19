// Attachment table for IOU requests, mirroring pc_txn_iouDoc on the IOU
// advance. Up to five files per request, each with an optional comment.

exports.up = async function (knex) {
  await knex.schema.createTable('pc_txn_iouRequestDoc', function (t) {
    t.uuid('docId').primary().defaultTo(knex.fn.uuid());
    t.uuid('iouRequestId').notNullable().references('iouRequestId').inTable('pc_txn_iouRequest');
    t.uuid('companyId').notNullable();
    t.integer('lineNo').notNullable();
    t.string('filePath', 300).notNullable();
    t.string('comment', 500);
  });
};

exports.down = async function (knex) {
  await knex.schema.dropTableIfExists('pc_txn_iouRequestDoc');
};
