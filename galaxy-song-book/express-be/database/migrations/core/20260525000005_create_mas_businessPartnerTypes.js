exports.up = function(knex) {
  return knex.schema.createTable('mas_businessPartnerTypes', function(table) {
    table.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    table.uuid('businessPartnerId').notNullable().references('businessPartnerId').inTable('mas_businessPartner').onDelete('CASCADE');
    table.string('partnerType').notNullable();
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());

    table.primary(['businessPartnerId', 'partnerType']);
  });
};

exports.down = function(knex) {
  return knex.schema.dropTable('mas_businessPartnerTypes');
};
