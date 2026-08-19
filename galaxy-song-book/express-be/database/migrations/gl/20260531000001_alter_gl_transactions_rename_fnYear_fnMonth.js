exports.up = function(knex) {
  return knex.schema.alterTable('gl_transactions', function(table) {
    table.renameColumn('txnYear', 'fnYear');
    table.renameColumn('txnMonth', 'fnMonth');
  });
};

exports.down = function(knex) {
  return knex.schema.alterTable('gl_transactions', function(table) {
    table.renameColumn('fnYear', 'txnYear');
    table.renameColumn('fnMonth', 'txnMonth');
  });
};
