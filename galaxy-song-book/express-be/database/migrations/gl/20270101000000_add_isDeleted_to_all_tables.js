exports.up = function(knex) {
  return knex.schema
    .alterTable('gl_accountBalances', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('gl_accountTypes', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('gl_centers', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('gl_chartOfAccounts', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('gl_chartOfAccounts_company', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('gl_companies', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('gl_financialMonths', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('gl_transactionDetail', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('gl_transactions', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    });
};

exports.down = function(knex) {
  return knex.schema
    .alterTable('gl_accountBalances', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('gl_accountTypes', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('gl_centers', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('gl_chartOfAccounts', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('gl_chartOfAccounts_company', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('gl_companies', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('gl_financialMonths', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('gl_transactionDetail', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('gl_transactions', function(table) {
      table.dropColumn('isDeleted');
    });
};
