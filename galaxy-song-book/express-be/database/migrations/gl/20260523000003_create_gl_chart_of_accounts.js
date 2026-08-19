exports.up = function(knex) {
  return knex.schema.createTable('gl_chartOfAccounts', function(table) {
    table.uuid('accountId').primary().defaultTo(knex.fn.uuid());
    table.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    table.uuid('groupId').notNullable().references('groupId').inTable('sec_groups');
    table.specificType('accountType', 'CHAR(1)').notNullable().references('accountType').inTable('gl_accountTypes');
    table.string('accountCode', 20).notNullable();
    table.string('accountName', 150).notNullable();
    table.uuid('parentAccountId').references('accountId').inTable('gl_chartOfAccounts');
    table.integer('level').notNullable().defaultTo(1);
    table.integer('sortOrder').notNullable();
    table.boolean('isActive').notNullable().defaultTo(true);
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('gl_chartOfAccounts');
};
