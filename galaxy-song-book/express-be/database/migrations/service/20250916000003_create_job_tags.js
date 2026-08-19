exports.up = function(knex) {
  return knex.schema.createTable('svc_txn_job_tags', function(table) {
    table.uuid('tenantId').references('tenantId').inTable('sec_tenants');
    table.uuid('companyId').references('companyId').inTable('sec_companies');
    table.increments('index').primary();  // INT PRIMARY KEY
    table.integer('id'); 
    table.integer('tag_id');
    table.boolean('deleted').notNullable().defaultTo(false);
    table.uuid('updatedBy');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
    // table.primary(['tenantId', 'companyId', 'index', 'tag_id']);
    // table.index(['tenantId', 'companyId','id','tag_id']);
  });
};

exports.down = function(knex) {
  return knex.schema.dropTable('svc_txn_job_tags');
};
