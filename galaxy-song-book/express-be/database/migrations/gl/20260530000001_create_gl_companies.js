exports.up = function(knex) {
  return knex.schema.createTable('gl_companies', function(table) {
    table.uuid('companyId').primary()
         .references('companyId').inTable('sec_companies');
    table.uuid('tenantId').notNullable()
         .references('tenantId').inTable('sec_tenants');
    table.integer('financialYearStartMonth').notNullable().defaultTo(1);
    table.integer('currentFinYear').notNullable();
    table.integer('currentFinMonth').notNullable();
    table.boolean('isActive').notNullable().defaultTo(true);
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('gl_companies');
};
