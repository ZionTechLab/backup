exports.up = function(knex) {
  return knex.schema.createTable('sec_userCompanies', function(table) {
    table.increments('id').primary();
    table.uuid('userId').notNullable().references('userId').inTable('mas_users').onDelete('CASCADE');
    table.uuid('companyId').notNullable().references('companyId').inTable('sec_companies').onDelete('CASCADE');
    table.boolean('isDefault').notNullable().defaultTo(false);
    table.boolean('isActive').notNullable().defaultTo(true);
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
    table.unique(['userId', 'companyId']);
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('sec_userCompanies');
};
