exports.up = function(knex) {
  return knex.schema.createTable('svc_txn_job_activities', function(table) {
    table.uuid('tenantId').references('tenantId').inTable('sec_tenants');
    table.uuid('companyId').references('companyId').inTable('sec_companies');
    table.increments('activity_id').primary();
    table.integer('index'); // INT PRIMARY KEY
    table.integer('JobId');     
    table.string('docType');
    table.string('txnType');
    table.date('activityDate');
    table.text('description');
    table.text('remarks');
    table.boolean('deleted').notNullable().defaultTo(false);
    table.uuid('updatedBy');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
  });
};

exports.down = function(knex) {
  return knex.schema.dropTable('svc_txn_job_activities');
};
