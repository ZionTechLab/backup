exports.up = function(knex) {
  return knex.schema.createTable('conf_docType', function(table) {
    table.uuid('companyId').notNullable().references('companyId').inTable('sec_companies');
    table.string('docType').notNullable();
    table.primary(['companyId', 'docType']);
    table.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    table.boolean('isActive').notNullable();
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
    table.foreign('docType').references('docType').inTable('sec_docType');
  });
};

exports.down = function(knex) {
  return knex.schema.dropTable('conf_docType');
};
