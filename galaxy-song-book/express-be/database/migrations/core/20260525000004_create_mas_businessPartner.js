exports.up = function(knex) {
  return knex.schema.createTable('mas_businessPartner', function(table) {
    table.uuid('businessPartnerId').primary().defaultTo(knex.fn.uuid());
    table.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    table.string('partnerCode').notNullable();
    table.string('partnerName').notNullable();
    table.string('contactPerson').notNullable();
    table.string('email').notNullable();
    table.string('address').notNullable();
    table.string('phone1').notNullable();
    table.string('phone2').notNullable();
    table.boolean('isActive').notNullable();
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
  });
};

exports.down = function(knex) {
  return knex.schema.dropTable('mas_businessPartner');
};
