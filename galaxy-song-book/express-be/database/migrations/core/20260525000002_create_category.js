exports.up = function(knex) {
  return knex.schema.createTable('ref_category', function(table) {
    table.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    table.uuid('companyId').notNullable().references('companyId').inTable('sec_companies');
    table.increments('index').primary(); // INT PRIMARY KEY
    table.integer('id');
    table.integer('parentId').notNullable().defaultTo(0);
    table.integer('categoryType').notNullable();
    table.string('value').notNullable();
    table.string('description');
    table.boolean('isActive').notNullable();
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
    table.string('ref1');
    table.string('ref2');
    table.string('ref3');
    table.string('ref4');
    table.string('ref5');
  });
};

exports.down = function(knex) {
  return knex.schema.dropTable('ref_category');
};
