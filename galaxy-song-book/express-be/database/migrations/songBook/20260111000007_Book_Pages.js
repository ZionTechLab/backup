exports.up = function(knex) {
  return knex.schema.createTable('sb_txn_BookPages', function(table) {
    table.uuid('tenantId').references('tenantId').inTable('sec_tenants')
    table.uuid('companyId').references('companyId').inTable('sec_companies')
    table.increments('index').primary(); // INT PRIMARY KEY
    table.integer('Book_id').notNullable();
    table.integer('Song_id').notNullable();
    table.integer('Song_No').notNullable();
    table.boolean('deleted').notNullable().defaultTo(false);
    table.uuid('updatedBy');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
  });
};

exports.down = function(knex) {
  return knex.schema.dropTable('sb_txn_BookPages');
};
