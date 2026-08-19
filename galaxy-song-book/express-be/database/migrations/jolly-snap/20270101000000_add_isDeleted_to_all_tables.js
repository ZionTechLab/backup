exports.up = function(knex) {
  return knex.schema
    .alterTable('js_txn_job_hedder', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    });
};

exports.down = function(knex) {
  return knex.schema
    .alterTable('js_txn_job_hedder', function(table) {
      table.dropColumn('isDeleted');
    });
};
