exports.up = function(knex) {
  return knex.schema.createTable('mas_userRoles', function(table) {
    table.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    table.uuid('companyId').notNullable().references('companyId').inTable('sec_companies');
    table.increments('index').primary();
    table.integer('userCompanyId').unsigned().references('id').inTable('sec_userCompanies');
    table.integer('roleID').unsigned().notNullable();
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
    table.foreign(['tenantId', 'roleID']).references(['tenantId', 'id']).inTable('ref_roles');
  });
};

exports.down = function(knex) {
  return knex.schema.dropTable('mas_userRoles');
};
