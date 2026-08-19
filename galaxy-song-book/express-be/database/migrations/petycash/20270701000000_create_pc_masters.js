// Petty cash masters and config. Cash book, petty cash category, generic param,
// approval bands. UUID PKs. tenant/company/user are UUIDs per the repo.
// Audit is centralized in sec_auditHistory, so no _history twins.
//
// Cash book includes fields from original CREATE plus merged ALTERs:
//   status, branchOrgUnitId, minFloat, maxFloat, iouClosingDays.

exports.up = async function (knex) {
  // Cash book. One petty cash float. One currency. One cashier.
  await knex.schema.createTable('pc_mas_cashBook', function (t) {
    t.uuid('cashBookId').primary().defaultTo(knex.fn.uuid());
    t.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    t.uuid('companyId').notNullable().references('companyId').inTable('sec_companies');
    t.string('code', 20).notNullable();
    t.string('name', 150).notNullable();
    t.uuid('cashierUserId').notNullable().references('userId').inTable('mas_users');
    t.specificType('currencyCode', 'CHAR(3)').notNullable().references('currencyCode').inTable('sec_currencies');
    t.uuid('glAccountId').notNullable().references('accountId').inTable('gl_chartOfAccounts');
    t.decimal('floatLimit', 18, 2).notNullable().defaultTo(0);
    t.decimal('topUpThreshold', 18, 2).notNullable().defaultTo(0);
    t.string('status', 20).notNullable().defaultTo('Active');
    t.uuid('branchOrgUnitId').references('orgUnitId').inTable('mas_orgUnit');
    t.decimal('minFloat', 18, 2).notNullable().defaultTo(0);
    t.decimal('maxFloat', 18, 2).notNullable().defaultTo(0);
    t.integer('iouClosingDays').notNullable().defaultTo(0);
    t.boolean('isActive').notNullable().defaultTo(true);
    t.string('remarks', 500);
    t.boolean('deleted').notNullable().defaultTo(false);
    t.uuid('updatedBy').references('userId').inTable('mas_users');
    t.dateTime('updatedAt').defaultTo(knex.fn.now());
    t.unique(['companyId', 'name']);
  });

  // Petty cash category. Maps to an expense GL account. Carries VAT setup.
  await knex.schema.createTable('pc_ref_expenseCategory', function (t) {
    t.uuid('categoryId').primary().defaultTo(knex.fn.uuid());
    t.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    t.uuid('companyId').notNullable().references('companyId').inTable('sec_companies');
    t.string('name', 150).notNullable();
    t.uuid('glAccountId').notNullable().references('accountId').inTable('gl_chartOfAccounts');
    t.enu('taxMode', ['inclusive', 'exclusive', 'exempt']).notNullable().defaultTo('exempt');
    t.decimal('taxRate', 9, 4).notNullable().defaultTo(0);
    t.uuid('inputVatGlAccountId').references('accountId').inTable('gl_chartOfAccounts');
    t.boolean('isActive').notNullable().defaultTo(true);
    t.boolean('deleted').notNullable().defaultTo(false);
    t.uuid('updatedBy').references('userId').inTable('mas_users');
    t.dateTime('updatedAt').defaultTo(knex.fn.now());
    t.unique(['companyId', 'name']);
  });

  // Generic parameter store. Party limits, settlement periods, defaults.
  await knex.schema.createTable('pc_ref_param', function (t) {
    t.uuid('paramId').primary().defaultTo(knex.fn.uuid());
    t.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    t.uuid('companyId').notNullable().references('companyId').inTable('sec_companies');
    t.string('paramGroup', 50).notNullable();
    t.string('paramKey', 50).notNullable();
    t.decimal('numValue', 18, 2);
    t.string('textValue', 250);
    t.uuid('glAccountId').references('accountId').inTable('gl_chartOfAccounts');
    t.boolean('isActive').notNullable().defaultTo(true);
    t.boolean('deleted').notNullable().defaultTo(false);
    t.uuid('updatedBy').references('userId').inTable('mas_users');
    t.dateTime('updatedAt').defaultTo(knex.fn.now());
    t.unique(['companyId', 'paramGroup', 'paramKey']);
  });

  // Approval matrix. Amount bands to an approver function. Configurable.
  await knex.schema.createTable('conf_pcApprovalBand', function (t) {
    t.uuid('bandId').primary().defaultTo(knex.fn.uuid());
    t.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    t.uuid('companyId').notNullable().references('companyId').inTable('sec_companies');
    t.string('docType', 10).notNullable();
    t.decimal('minAmount', 18, 2).notNullable().defaultTo(0);
    t.decimal('maxAmount', 18, 2);
    t.string('approverFunction', 100).notNullable();
    t.integer('sortOrder').notNullable().defaultTo(0);
    t.boolean('deleted').notNullable().defaultTo(false);
    t.uuid('updatedBy').references('userId').inTable('mas_users');
    t.dateTime('updatedAt').defaultTo(knex.fn.now());
  });
};

exports.down = async function (knex) {
  await knex.schema.dropTableIfExists('conf_pcApprovalBand');
  await knex.schema.dropTableIfExists('pc_ref_param');
  await knex.schema.dropTableIfExists('pc_ref_expenseCategory');
  await knex.schema.dropTableIfExists('pc_mas_cashBook');
};
