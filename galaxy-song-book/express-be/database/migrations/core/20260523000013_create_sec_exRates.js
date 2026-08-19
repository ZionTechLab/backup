exports.up = function(knex) {
  return knex.schema.createTable('sec_exRates', function(table) {
    table.uuid('rateId').primary().defaultTo(knex.fn.uuid());
    table.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    table.uuid('groupId').notNullable().references('groupId').inTable('sec_groups');
    table.specificType('fromCurrencyCode', 'CHAR(3)').notNullable().references('currencyCode').inTable('sec_currencies');
    table.specificType('toCurrencyCode',   'CHAR(3)').notNullable().references('currencyCode').inTable('sec_currencies');
    table.integer('rateTypeId').unsigned().notNullable().references('rateTypeId').inTable('sec_exRateTypes');
    table.decimal('rate', 18, 6).notNullable();
    table.date('effectiveDate').notNullable();
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('sec_exRates');
};
