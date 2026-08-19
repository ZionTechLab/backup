exports.up = function(knex) {
  return knex.schema.alterTable('sec_companies', function(table) {
    table.string('fax');
  });
};

exports.down = function(knex) {
  return knex.schema.alterTable('sec_companies', function(table) {
    table.dropColumn('fax');
  });
};
