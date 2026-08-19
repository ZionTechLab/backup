exports.up = function(knex) {
  return knex.schema.createTable('mas_businessPartnerCompany', function(table) {
    table.increments('id').primary();
    table.uuid('businessPartnerId').notNullable().references('businessPartnerId').inTable('mas_businessPartner').onDelete('CASCADE');
    table.uuid('companyId').notNullable().references('companyId').inTable('sec_companies').onDelete('CASCADE');
    table.boolean('isDefault').notNullable().defaultTo(false);
    table.boolean('isActive').notNullable().defaultTo(true);
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
    table.unique(['businessPartnerId', 'companyId']);
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('mas_businessPartnerCompany');
};
