exports.up = function(knex) {
  return knex.schema.alterTable('sec_companies', function(table) {
    table.dropColumn('fiscalYear');
    table.dropColumn('period');
  });
};

exports.down = function(knex) {
  return knex.schema.alterTable('sec_companies', function(table) {
    table.integer('fiscalYear').nullable();
    table.integer('period').nullable();
  });
};
