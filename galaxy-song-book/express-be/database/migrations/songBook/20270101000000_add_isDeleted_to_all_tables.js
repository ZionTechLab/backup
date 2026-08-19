exports.up = function(knex) {
  return knex.schema
    .alterTable('sb_txn_Book', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('sb_txn_BookPages', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('sb_txn_song', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('sb_txn_song_history', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    });
};

exports.down = function(knex) {
  return knex.schema
    .alterTable('sb_txn_Book', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('sb_txn_BookPages', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('sb_txn_song', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('sb_txn_song_history', function(table) {
      table.dropColumn('isDeleted');
    });
};
