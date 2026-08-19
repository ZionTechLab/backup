exports.up = function(knex) {
  return knex.schema.createTable('sec_auditHistory', function(table) {
    table.uuid('historyId').primary().defaultTo(knex.fn.uuid());
    table.integer('tableId').notNullable();
    table.integer('recordId').notNullable();
    table.integer('changedBy');
    table.dateTime('changedAt').notNullable();
    table.string('changeType', 1).notNullable(); // 'E' | 'I' | 'D'
    table.text('snapshot').notNullable();

    table.index('tableId');
  });
};

exports.down = function(knex) {
  return knex.schema.dropTable('sec_auditHistory');
};
