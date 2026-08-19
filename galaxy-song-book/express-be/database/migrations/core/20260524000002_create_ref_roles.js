exports.up = function(knex) {
  return knex.schema.createTable('ref_roles', function(table) {
    table.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    table.uuid('groupId').notNullable().references('groupId').inTable('sec_groups');
    table.increments('index').primary(); // INT PRIMARY KEY
    table.integer('id').unsigned();
    table.string('roleName').notNullable();
    table.boolean('isActive').notNullable();
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
    table.unique(['tenantId', 'id']);
  });
};

exports.down = function(knex) {
  return knex.schema.dropTable('ref_roles');
};
