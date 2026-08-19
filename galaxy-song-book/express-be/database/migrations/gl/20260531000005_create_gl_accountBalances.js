exports.up = function(knex) {
  return knex.schema.createTable('gl_accountBalances', function(table) {
    table.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    table.uuid('companyId').notNullable().references('companyId').inTable('sec_companies');
    table.uuid('accountId').notNullable().references('accountId').inTable('gl_chartOfAccounts');
    table.integer('fnYear').notNullable();
    table.integer('fnMonth').notNullable();
    table.boolean('isCumulative').notNullable().defaultTo(false);
    table.specificType('costCenter', 'CHAR(3)').notNullable().defaultTo('');
    table.decimal('debitTotal', 18, 2).notNullable().defaultTo(0);
    table.decimal('creditTotal', 18, 2).notNullable().defaultTo(0);
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
    table.primary(['companyId', 'accountId', 'fnYear', 'fnMonth', 'isCumulative', 'costCenter']);
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('gl_accountBalances');
};
