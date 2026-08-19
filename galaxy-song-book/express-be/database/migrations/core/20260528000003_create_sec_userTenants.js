exports.up = function(knex) {
  return knex.schema.createTable('sec_userTenants', function(table) {
    table.increments('id').primary();
    table.uuid('userId').notNullable().references('userId').inTable('mas_users').onDelete('CASCADE');
    table.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants').onDelete('CASCADE');
    table.boolean('isDefault').notNullable().defaultTo(false);
    table.boolean('isActive').notNullable().defaultTo(true);
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
    table.unique(['userId', 'tenantId']);
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('sec_userTenants');
};
