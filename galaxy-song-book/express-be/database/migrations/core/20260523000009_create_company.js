// migration file: 202508201436_create_companies_table.js

exports.up = function(knex) {
  return knex.schema.createTable('sec_companies', function(table) {
    table.uuid('companyId').primary().defaultTo(knex.fn.uuid());
    table.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    table.uuid('groupId').notNullable().references('groupId').inTable('sec_groups');
    // Core Info
    table.string('companyCode').nullable();
    table.string('companyName').notNullable();
    table.string('legalName');
    table.string('registrationNumber');
    table.text('description');
    // table.string('industryType');
    // table.string('companyType');
    // Location & Contact
    table.string('addressLine1');
    table.string('addressLine2');
    table.string('city');
    table.string('stateProvince');
    table.string('postalCode');
    table.integer('country').nullable();
    table.string('phoneNumber');
    table.string('tel2');
    table.string('mobile');
    table.string('email');
    table.string('websiteUrl');

    // Key Contacts
    table.string('primaryContactName');
    table.string('primaryContactEmail');
    table.string('primaryContactPhone');
    table.string('secondaryContactName');

    // Operational Details
    table.date('dateOfIncorporation');
    table.integer('numberOfEmployees');
    // table.decimal('annualRevenue', 15, 2);

    table.uuid('parentCompanyId').references('companyId').inTable('sec_companies');

    // Compliance & Finance
    table.string('taxId');
    table.string('vatNumber');
    table.string('gstNumber');
    table.string('panNumber');
    table.string('bankAccountDetails');

    // Metadata
    // table.timestamp('createdAt').defaultTo(knex.fn.now());
    // table.string('createdBy');
    // table.timestamp('updatedAt').defaultTo(knex.fn.now());
    // table.string('updated_by');
    table.text('remarks');
    table.specificType('baseCurrencyCode', 'CHAR(3)').references('currencyCode').inTable('sec_currencies');
    table.integer('fiscalYear').nullable();
    table.integer('period').nullable();

    table.boolean('isActive').notNullable().defaultTo(true);
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
    // Integration
    // table.string('external_system_id');
    // table.timestamp('last_synced_at');
    // table.string('sync_status');
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('sec_companies');
};