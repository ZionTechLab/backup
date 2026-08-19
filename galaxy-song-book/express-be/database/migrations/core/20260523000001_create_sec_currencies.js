exports.up = function(knex) {
  return knex.schema.createTable('sec_currencies', function(table) {
    table.string('currencyCode', 3).primary();
    table.string('currencyName', 50).notNullable();
    table.string('symbol', 5);
    table.boolean('isActive').defaultTo(true);
    table.uuid('updatedBy');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('sec_currencies');
};
