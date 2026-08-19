exports.up = function(knex) {
  return knex.schema.createTable('gl_chartOfAccounts_company', function(table) {
    table.uuid('companyAccountId').primary().defaultTo(knex.fn.uuid());
    table.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    table.uuid('companyId').notNullable().references('companyId').inTable('sec_companies');
    table.uuid('accountId').notNullable().references('accountId').inTable('gl_chartOfAccounts');

    // Company-level overrides (nullable — fall back to gl_chartOfAccounts when null)
    table.string('accountCode', 20);
    table.string('accountName', 150);

    // Company-level controls
    table.boolean('allowPosting').notNullable().defaultTo(true);
    table.boolean('isActive').notNullable().defaultTo(true);

    // Opening balances per company
    table.decimal('openingBalance', 18, 2).notNullable().defaultTo(0);
    table.date('openingBalanceDate');
    table.specificType('currencyCode', 'CHAR(3)').references('currencyCode').inTable('sec_currencies');

    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.timestamp('updatedAt').defaultTo(knex.fn.now());

    table.unique(['companyId', 'accountId']);
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('gl_chartOfAccounts_company');
};
