exports.up = function(knex) {
  return knex.schema.createTable('gl_transactions', function(table) {
    table.uuid('transactionId').primary().defaultTo(knex.fn.uuid());
    table.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    table.uuid('companyId').notNullable().references('companyId').inTable('sec_companies');
    table.integer('txnYear').notNullable();
    table.integer('txnMonth').notNullable();
    table.string('docType').notNullable();
    table.string('txnType').notNullable();
    table.integer('docNo').notNullable();
    table.date('txnDate').notNullable();
    table.string('reference', 100);
    table.string('description', 500);
    table.enu('status', ['Draft', 'Posted', 'Void']).notNullable().defaultTo('Draft');
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.timestamp('updatedAt').defaultTo(knex.fn.now());

    table.foreign(['companyId', 'docType']).references(['companyId', 'docType']).inTable('conf_docType');
    table.foreign(['companyId', 'docType', 'txnType']).references(['companyId', 'docType', 'txnType']).inTable('conf_txnType');
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('gl_transactions');
};
