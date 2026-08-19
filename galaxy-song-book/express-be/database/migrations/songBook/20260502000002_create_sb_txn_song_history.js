exports.up = function(knex) {
  return knex.schema.createTable('sb_txn_song_history', function(table) {
    table.increments('historyId').primary();
    table.integer('id').notNullable();          // business ID of the song that changed
    table.integer('changedBy');                  // userId who triggered the change
    table.dateTime('changedAt').notNullable();
    table.string('changeType', 10).notNullable(); // 'INSERT' | 'UPDATE' | 'DELETE'
    table.text('snapshot').notNullable();         // JSON of the full row before the change

    table.index('id');
  });
};

exports.down = function(knex) {
  return knex.schema.dropTable('sb_txn_song_history');
};
