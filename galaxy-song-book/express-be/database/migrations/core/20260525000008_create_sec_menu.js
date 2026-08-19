exports.up = function(knex) {
  return knex.schema.createTable('sec_menu', function(table) {
    table.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    table.uuid('companyId').notNullable().references('companyId').inTable('sec_companies');
    table.integer('id').primary();
    table.integer('parentId')
    table.string('route').notNullable()
    table.string('displayName').notNullable()
    table.string('icon').notNullable()
    table.integer('order');
    table.boolean('isGroup');
    table.boolean('isActive').notNullable();
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('sec_menu');
};
