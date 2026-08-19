exports.up = function(knex) {
  return knex.schema.createTable('imp_txn_vehicleConfirmation', function(table) {
    table.uuid('tenantId').references('tenantId').inTable('sec_tenants')
    table.uuid('companyId').references('companyId').inTable('sec_companies')
    table.increments('index').primary(); // INT PRIMARY KEY
    table.integer('id');
    table.integer('make', 100);
    table.integer('model', 100);
    table.integer('grade', 50);
    table.integer('colour', 50);
    table.integer('year'); 
    table.integer('engineCapacity');
    table.integer('fuelType');
    table.integer('transmission');
    table.integer('millage');
    table.string('chassisNo', 100);
    table.uuid('supplier'); // Foreign key to BusinessPartner
    table.uuid('customer'); // Foreign key to BusinessPartner
    table.date('purchaseDate');
    table.decimal('cifYen', 18, 2);
    table.decimal('auctionPrice', 18, 2);
    table.decimal('tax', 18, 2);
    table.decimal('freight', 18, 2);
    table.date('paymentDate');
    table.decimal('paymentAmount', 18, 2);
    table.decimal('paymentRate', 18, 4);
    table.decimal('paymentAmountYen', 18, 2);
    table.text('paymentDetails');
    table.string('lcOpenDetailsBank', 100);
    table.decimal('JPY', 18, 2);
    table.date('lcOpenDetailsDate');
    table.decimal('lcMarginAmount', 18, 2);
    table.date('lcMarginDate');
    table.decimal('lcSettlementAmount', 18, 2);
    table.decimal('lcSettlementCharges', 18, 2);
    table.date('lcSettlementDate');
    table.decimal('dutyAmount', 18, 2);
    table.date('dutyDate');
    table.decimal('clearingCharges', 18, 2);
    table.date('clearingDate');
    table.decimal('salesTax', 18, 2);
    table.decimal('transportCost', 18, 2);
    table.decimal('totalCost', 18, 2);
    table.text('description');
    table.boolean('deleted').notNullable().defaultTo(false);
    table.uuid('updatedBy');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('imp_txn_vehicleConfirmation');
};
