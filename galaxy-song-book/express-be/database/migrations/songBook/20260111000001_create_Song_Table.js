exports.up = function(knex) {
  return knex.schema.createTable('sb_txn_song', function(table) {
    table.uuid('tenantId').references('tenantId').inTable('sec_tenants')
    table.uuid('companyId').references('companyId').inTable('sec_companies')
    table.increments('index').primary(); // INT PRIMARY KEY
    table.integer('id').notNullable();
    table.string('title').notNullable();
    table.text('lyrics').notNullable();
    table.string('language').notNullable();//to be link to master
    table.boolean('active').notNullable();
    table.boolean('deleted').notNullable().defaultTo(false);
    table.uuid('updatedBy');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
  });
};

exports.down = function(knex) {
  return knex.schema.dropTable('sb_txn_song');
};
