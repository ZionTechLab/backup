exports.up = function(knex) {
  return knex.schema.createTable('sec_docType', function(table) {
    table.string('docType').primary();
    table.string('docTypename').notNullable();
    table.boolean('isActive').notNullable().defaultTo(true);
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('sec_docType');
};
