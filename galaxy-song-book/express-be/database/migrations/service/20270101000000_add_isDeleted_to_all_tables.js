exports.up = function(knex) {
  return knex.schema
    .alterTable('svc_txn_job_activities', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('svc_txn_job_tags', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('svc_txn_jobs', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    });
};

exports.down = function(knex) {
  return knex.schema
    .alterTable('svc_txn_job_activities', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('svc_txn_job_tags', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('svc_txn_jobs', function(table) {
      table.dropColumn('isDeleted');
    });
};
