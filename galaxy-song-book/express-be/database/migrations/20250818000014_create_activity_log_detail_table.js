exports.up = function(knex) {
  return knex.schema.createTable('imp_txn_activityLogDetail', function(table) {
    table.uuid('tenantId').references('tenantId').inTable('sec_tenants');
    table.uuid('companyId').references('companyId').inTable('sec_companies');
    table.increments('txnIndex').primary();
    table.integer('id').notNullable();
    table.integer('txnLineNo').notNullable();
    table.string('docType').notNullable();
    table.string('txnType').notNullable();
    table.date('txnDate').notNullable();
    table.string('description');
    table.decimal('amount', 15, 2).notNullable();
    table.string('hours', 50);
    table.primary(['txnIndex', 'txnLineNo']);
    table.boolean('deleted').notNullable().defaultTo(false);
    table.uuid('updatedBy');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('imp_txn_activityLogDetail');
};
