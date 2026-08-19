exports.up = function(knex) {
  return knex.schema.createTable('sec_groups', function(table) {
    table.uuid('groupId').primary().defaultTo(knex.fn.uuid());
    table.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    table.string('groupName', 150).notNullable();
    table.string('baseCurrencyCode', 3).references('currencyCode').inTable('sec_currencies');
    table.boolean('isActive').notNullable().defaultTo(true);
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('sec_groups');
};
