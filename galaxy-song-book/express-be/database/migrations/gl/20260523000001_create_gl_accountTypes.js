exports.up = function(knex) {
  return knex.schema.createTable('gl_accountTypes', function(table) {
    table.specificType('accountType', 'CHAR(1)').primary();
    table.string('typeName', 50).notNullable();
    table.integer('sortOrder').notNullable();
    table.boolean('isActive').notNullable().defaultTo(true);
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('gl_accountTypes');
};
