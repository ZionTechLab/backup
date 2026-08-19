exports.up = function(knex) {
  return knex.schema.createTable('sec_txnType', function(table) {
    table.string('docType').notNullable();
    table.string('txnType').notNullable();
    table.string('txnTypename').notNullable();
    table.boolean('isActive').notNullable().defaultTo(true);
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
    table.primary(['docType', 'txnType']);
    table.foreign('docType').references('docType').inTable('sec_docType');
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('sec_txnType');
};
