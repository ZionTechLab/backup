exports.up = function(knex) {
  return knex.schema.createTable('ar_txn_debtorTXNDetail', function(table) {
    table.uuid('tenantId').references('tenantId').inTable('sec_tenants');
    table.uuid('companyId').references('companyId').inTable('sec_companies');
    table.integer('txnIndex');
    table.integer('id').notNullable();
    table.integer('txnLineNo');
    table.string('docType').notNullable();
    table.string('txnType').notNullable();
    table.date('txnDate').notNullable();
    table.string('description');
    table.decimal('amount', 15, 2).notNullable();
    table.boolean('deleted').notNullable().defaultTo(false);
    table.uuid('updatedBy');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
    table.primary(['txnIndex', 'txnLineNo']);
  });
};

exports.down = function(knex) {
  return knex.schema.dropTable('ar_txn_debtorTXNDetail');
};
