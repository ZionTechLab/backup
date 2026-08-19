// Tenant-level settings (theme defaults, table/behavior flags) persisted as a
// JSON string. Stored as text (not the knex json() type) so behavior is
// identical across sqlite/mysql/pg — the app always JSON.stringify/parse
// explicitly rather than relying on driver-specific json handling.
exports.up = function(knex) {
  return knex.schema.alterTable('sec_tenants', function(table) {
    table.text('settings');
  });
};

exports.down = function(knex) {
  return knex.schema.alterTable('sec_tenants', function(table) {
    table.dropColumn('settings');
  });
};
