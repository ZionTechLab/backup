exports.up = function(knex) {
  return knex.schema.createTable('conf_txnType', function(table) {
    table.uuid('companyId').notNullable();
    table.string('docType').notNullable();
    table.string('txnType').notNullable();
    table.primary(['companyId', 'docType', 'txnType']);
    table.foreign(['companyId', 'docType']).references(['companyId', 'docType']).inTable('conf_docType');
    table.foreign(['docType', 'txnType']).references(['docType', 'txnType']).inTable('sec_txnType');
    table.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    table.integer('serialNo').notNullable();
    table.boolean('isActive').notNullable();
    table.boolean('isReport').notNullable();
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
  });
};

exports.down = function(knex) {
  return knex.schema.dropTable('conf_txnType');
};
