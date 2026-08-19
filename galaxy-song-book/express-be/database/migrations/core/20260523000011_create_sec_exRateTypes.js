exports.up = function(knex) {
  return knex.schema.createTable('sec_exRateTypes', function(table) {
    table.increments('rateTypeId').primary();
    table.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    table.string('typeName', 50).notNullable();
    table.string('description', 255);
    table.boolean('isActive').notNullable().defaultTo(true);
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('sec_exRateTypes');
};
