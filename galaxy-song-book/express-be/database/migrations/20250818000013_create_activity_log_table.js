exports.up = function(knex) {
  return knex.schema.createTable('imp_txn_activityLog', function(table) {
    table.uuid('tenantId').references('tenantId').inTable('sec_tenants')
    table.uuid('companyId').references('companyId').inTable('sec_companies')
    table.increments('txnIndex').primary();
    table.integer('id').notNullable();
    table.string('docType');
    table.string('txnType');
    table.date('txnDate');
    table.uuid('partner').notNullable();
    table.integer('vehicle').notNullable();
    table.integer('typeOfMachine').notNullable();
    table.uuid('operator').notNullable();
    table.uuid('helper');
    table.text('remarks');
    table.decimal('km', 10, 2);
    table.string('time', 50);
    table.string('diesel', 50);
    table.string('certifiedHours', 50);
    table.boolean('deleted').notNullable().defaultTo(false);
    table.uuid('updatedBy');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('imp_txn_activityLog');
};
