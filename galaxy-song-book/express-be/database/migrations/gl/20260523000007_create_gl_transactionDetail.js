exports.up = function(knex) {
  return knex.schema.createTable('gl_transactionDetail', function(table) {
    table.integer('lineId').notNullable();
    table.uuid('transactionId').notNullable().references('transactionId').inTable('gl_transactions');
    table.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    table.uuid('companyId').notNullable().references('companyId').inTable('sec_companies');
    table.integer('txnYear').notNullable();
    table.integer('txnMonth').notNullable();
    table.string('docType').notNullable();
    table.string('txnType').notNullable();
    table.integer('docNo').notNullable();
    table.date('txnDate').notNullable();
    table.integer('lineNo').notNullable();
    table.uuid('accountId').notNullable().references('accountId').inTable('gl_chartOfAccounts');
    table.decimal('debitAmount', 18, 2).notNullable().defaultTo(0);
    table.decimal('creditAmount', 18, 2).notNullable().defaultTo(0);
    table.specificType('currencyCode', 'CHAR(3)').notNullable().references('currencyCode').inTable('sec_currencies');
    table.decimal('exchangeRate', 18, 6).notNullable().defaultTo(1);
    table.integer('rateTypeId').unsigned().references('rateTypeId').inTable('sec_exRateTypes');
    table.decimal('debitBase', 18, 2).notNullable().defaultTo(0);
    table.decimal('creditBase', 18, 2).notNullable().defaultTo(0);
    table.string('description', 500);
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());

    table.primary(['transactionId', 'lineId']);
    table.foreign(['companyId', 'docType']).references(['companyId', 'docType']).inTable('conf_docType');
    table.foreign(['companyId', 'docType', 'txnType']).references(['companyId', 'docType', 'txnType']).inTable('conf_txnType');
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('gl_transactionDetail');
};
