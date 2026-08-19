exports.up = function (knex) {
  return knex.schema.alterTable('pc_txn_iouRequest', function (t) {
    t.date('iouDate');
  });
};

exports.down = function (knex) {
  return knex.schema.alterTable('pc_txn_iouRequest', function (t) {
    t.dropColumn('iouDate');
  });
};
