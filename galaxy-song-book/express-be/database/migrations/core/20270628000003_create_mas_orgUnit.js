exports.up = function (knex) {
  return knex.schema.createTable('mas_orgUnit', function (table) {
    table.uuid('orgUnitId').primary().defaultTo(knex.fn.uuid());
    table.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    table.uuid('companyId').notNullable().references('companyId').inTable('sec_companies');
    table.enu('unitType', ['Branch', 'Division', 'Department', 'Section']).notNullable();
    table.string('code', 40).notNullable();
    table.string('name', 150).notNullable();
    table.uuid('parentId').nullable().references('orgUnitId').inTable('mas_orgUnit');
    table.boolean('isActive').notNullable().defaultTo(true);
    table.boolean('deleted').notNullable().defaultTo(false);
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());

    table.unique(['companyId', 'unitType', 'code']);
  });
};

exports.down = function (knex) {
  return knex.schema.dropTableIfExists('mas_orgUnit');
};
