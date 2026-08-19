exports.up = async function(knex) {
  await knex.schema.dropTableIfExists('sec_auditHistory');
  return knex.schema.createTable('sec_auditHistory', function(table) {
    table.uuid('historyId').primary().defaultTo(knex.fn.uuid());
    table.string('tableName', 100).notNullable();
    table.string('recordId', 36).notNullable();
    table.string('changedBy', 36).nullable();
    table.dateTime('changedAt').notNullable();
    table.string('changeType', 1).notNullable(); // 'I' | 'E' | 'D'
    table.text('snapshot').notNullable();
    table.index('tableName');
    table.index('recordId');
  });
};

exports.down = async function(knex) {
  await knex.schema.dropTableIfExists('sec_auditHistory');
  return knex.schema.createTable('sec_auditHistory', function(table) {
    table.uuid('historyId').primary().defaultTo(knex.fn.uuid());
    table.integer('tableId').notNullable();
    table.integer('recordId').notNullable();
    table.integer('changedBy');
    table.dateTime('changedAt').notNullable();
    table.string('changeType', 1).notNullable();
    table.text('snapshot').notNullable();
    table.index('tableId');
  });
};
