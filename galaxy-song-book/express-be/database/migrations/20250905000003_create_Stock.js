exports.up = function(knex) {
  return knex.schema.createTable('ims_txn_stock', function(table) {
    table.uuid('tenantId').references('tenantId').inTable('sec_tenants')
    table.uuid('companyId').references('companyId').inTable('sec_companies')
    table.increments('index').primary(); // INT PRIMARY KEY
    table.integer('storeId'); 
    table.integer('itemId'); 
    table.decimal('quantity', 10, 2).notNullable()
    table.decimal('reservedQty', 10, 2).notNullable()
    table.uuid('updatedBy');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('ims_txn_stock');
};

