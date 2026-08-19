exports.up = async function(knex) {
  await knex.schema.alterTable('gl_transactionDetail', function(table) {
    table.renameColumn('txnYear', 'fnYear');
    table.renameColumn('txnMonth', 'fnMonth');
  });
  await knex.schema.alterTable('gl_transactionDetail', function(table) {
    table.string('costCenter', 50).nullable();
    table.string('profitCenter', 50).nullable();
  });
};

exports.down = async function(knex) {
  await knex.schema.alterTable('gl_transactionDetail', function(table) {
    table.dropColumn('costCenter');
    table.dropColumn('profitCenter');
  });
  await knex.schema.alterTable('gl_transactionDetail', function(table) {
    table.renameColumn('fnYear', 'txnYear');
    table.renameColumn('fnMonth', 'txnMonth');
  });
};
