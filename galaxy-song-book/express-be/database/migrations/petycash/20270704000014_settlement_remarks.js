// Adds a free-text remarks field to the settlement/payment header. There was
// no way to note context (e.g. why extra was paid, why cash was returned).

exports.up = async function (knex) {
  await knex.schema.alterTable('pc_txn_iouSettlement', (t) => {
    t.string('remarks', 500);
  });
};

exports.down = async function (knex) {
  await knex.schema.alterTable('pc_txn_iouSettlement', (t) => {
    t.dropColumn('remarks');
  });
};
