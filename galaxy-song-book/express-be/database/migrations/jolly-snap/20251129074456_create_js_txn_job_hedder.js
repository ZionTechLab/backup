exports.up = function (knex) {
    return knex.schema.createTable('js_txn_job_hedder', function (table) {
        table.integer('tenantId').notNullable();
        table.integer('companyId').notNullable();
        table.increments('index').primary();
        table.integer('id');
        table.string('name');
        table.string('email');
        table.string('whatsAppNo');
        table.integer('package');
        table.decimal('amount', 10, 2);
        table.boolean('isPaid').defaultTo(false);
        table.boolean('deleted').defaultTo(false);
        table.uuid('updatedBy');
        table.dateTime('updatedAt').defaultTo(knex.fn.now());
        //   table.timestamp('created_at').defaultTo(knex.fn.now());
        //  table.timestamp('updated_at').defaultTo(knex.fn.now());
    });
};


exports.down = function (knex) {
    return knex.schema.dropTableIfExists('js_txn_job_hedder');
};
