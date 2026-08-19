exports.up = function(knex) {
  return knex.schema.createTable('ar_txn_debtorTXN', function(table) {
    table.uuid('tenantId').references('tenantId').inTable('sec_tenants')
    table.uuid('companyId').references('companyId').inTable('sec_companies')
    table.increments('txnIndex').primary();
    table.integer('id').notNullable();
    table.string('docType');
    table.string('txnType');
    table.date('txnDate');
    table.uuid('partner');
    table.string('remarks');
    table.string('ref1');
    table.string('ref2');
    table.string('ref3');
    table.decimal('amount', 15, 2);
    table.decimal('taxAmount', 15, 2);
    table.decimal('taxRate', 15, 2);
    table.decimal('advance', 15, 2);
    table.decimal('totalAmount', 15, 2);
    table.boolean('deleted').notNullable().defaultTo(false);
    table.uuid('updatedBy');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());

  });
};

exports.down = function(knex) {
  return knex.schema.dropTable('ar_txn_debtorTXN');
};
