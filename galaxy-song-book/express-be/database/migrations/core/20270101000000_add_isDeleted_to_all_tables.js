exports.up = function(knex) {
  return knex.schema
    .alterTable('conf_docType', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('conf_txnType', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('mas_businessPartner', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('mas_businessPartnerCompany', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('mas_businessPartnerTypes', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('mas_userRoles', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('mas_users', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('ref_category', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('ref_roles', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('sec_auditHistory', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('sec_companies', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('sec_currencies', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('sec_docType', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('sec_exRateTypes', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('sec_exRates', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('sec_groups', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('sec_menu', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('sec_refreshTokens', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('sec_tenants', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('sec_txnType', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('sec_userCompanies', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('sec_userMenu', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('sec_userTenants', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    });
};

exports.down = function(knex) {
  return knex.schema
    .alterTable('conf_docType', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('conf_txnType', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('mas_businessPartner', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('mas_businessPartnerCompany', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('mas_businessPartnerTypes', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('mas_userRoles', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('mas_users', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('ref_category', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('ref_roles', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('sec_auditHistory', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('sec_companies', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('sec_currencies', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('sec_docType', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('sec_exRateTypes', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('sec_exRates', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('sec_groups', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('sec_menu', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('sec_refreshTokens', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('sec_tenants', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('sec_txnType', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('sec_userCompanies', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('sec_userMenu', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('sec_userTenants', function(table) {
      table.dropColumn('isDeleted');
    });
};
