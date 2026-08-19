exports.up = function(knex) {
  return knex.schema.createTable('svc_txn_jobs', function(table) {
    table.uuid('tenantId').references('tenantId').inTable('sec_tenants');
    table.uuid('companyId').references('companyId').inTable('sec_companies');
    table.increments('txnIndex').primary();
    table.integer('id').notNullable();
    table.string('docType');
    table.string('txnType');
    table.date('txnDate');
    table.uuid('partner');
    // table.string('client_project').notNullable().defaultTo('');
    // table.integer('service_type').notNullable().defaultTo(0);
    // table.integer('assigned_to');
    table.integer('status').notNullable();
    // table.date('due_date');
    table.string('ref1');
    table.string('ref2');
    table.string('ref3');
    table.text('description');
    table.text('remarks');
    // table.boolean('active').notNullable();
    table.boolean('deleted').notNullable().defaultTo(false);
    table.uuid('updatedBy');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
  });
};

exports.down = function(knex) {
  return knex.schema.dropTable('svc_txn_jobs');
};
