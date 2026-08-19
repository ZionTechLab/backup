exports.up = function(knex) {
  return knex.schema.createTable('gl_financialMonths', function(table) {
    table.uuid('companyId').notNullable()
         .references('companyId').inTable('sec_companies');
    table.uuid('tenantId').notNullable()
         .references('tenantId').inTable('sec_tenants');
    table.integer('fnYear').notNullable();
    table.integer('fnMonth').notNullable();
    table.boolean('isClosed').notNullable().defaultTo(false);
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
    table.primary(['companyId', 'fnYear', 'fnMonth']);
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('gl_financialMonths');
};
