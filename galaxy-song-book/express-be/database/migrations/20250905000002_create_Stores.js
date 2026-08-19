exports.up = function(knex) {
  return knex.schema.createTable('ims_mas_stores', function(table) {
    table.uuid('tenantId').references('tenantId').inTable('sec_tenants')
    table.uuid('companyId').references('companyId').inTable('sec_companies')
    table.increments('index').primary(); // INT PRIMARY KEY
    table.integer('id'); 
    table.integer('parentId'); 
    table.integer('storeCode') .notNullable()
    table.string('storeName').notNullable()
    table.text('description')
       table.boolean('active').notNullable();
    table.boolean('deleted').notNullable().defaultTo(false);
    table.uuid('updatedBy');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('ims_mas_stores');
};

