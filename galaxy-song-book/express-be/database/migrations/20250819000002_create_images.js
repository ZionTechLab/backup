exports.up = function(knex) {
  return knex.schema.createTable('gen_txn_images', function(table) {
    table.uuid('tenantId').references('tenantId').inTable('sec_tenants')
    table.uuid('companyId').references('companyId').inTable('sec_companies')
    table.increments('index').primary(); // INT PRIMARY KEY
    table.integer('id');
    table.string('docType').notNullable();
    table.string('txnType').notNullable();
    table.string('image');
    table.boolean('deleted').notNullable().defaultTo(false);
    table.uuid('updatedBy');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('gen_txn_images');
};
