exports.up = function(knex) {
  return knex.schema.createTable('gl_centers', function(table) {
    table.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    table.uuid('companyId').notNullable().references('companyId').inTable('sec_companies');
    table.specificType('centerCode', 'CHAR(3)').notNullable();
    table.string('centerName', 150).notNullable();
    table.specificType('parentCenterCode', 'CHAR(3)').nullable();
    table.boolean('isProfitCenter').notNullable().defaultTo(false);
    table.boolean('isActive').notNullable().defaultTo(true);
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());

    table.primary(['companyId', 'centerCode']);
    table.foreign(['companyId', 'parentCenterCode'])
         .references(['companyId', 'centerCode'])
         .inTable('gl_centers');
  });
};

exports.down = async function(knex) {
  // pc_txn_voucher (petycash module) has a cross-module FK to gl_centers;
  // drop it first so the table can be dropped. SQLite has no named
  // constraints and drops the FK along with the table itself.
  if (knex.client.config.client === 'mysql') {
    await knex.raw('ALTER TABLE ?? DROP FOREIGN KEY IF EXISTS ??', ['pc_txn_voucher', 'pc_txn_voucher_companyid_costcentercode_foreign']);
  }
  await knex.schema.dropTableIfExists('gl_centers');
};
