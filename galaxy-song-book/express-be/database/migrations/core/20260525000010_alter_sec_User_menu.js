exports.up = function(knex) {
  return knex.schema.alterTable('sec_userMenu', function(table) {
    table.boolean('isCategory').defaultTo(false);
  });
};

exports.down = function(knex) {
  return knex.schema.alterTable('sec_userMenu', function(table) {
    table.dropColumn('isCategory');
  });
};
