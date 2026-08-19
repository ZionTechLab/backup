exports.up = async function(knex) {
  await knex.schema.alterTable('gl_transactionDetail', function(table) {
    table.specificType('costCenter', 'CHAR(3)').nullable().alter();
    table.specificType('profitCenter', 'CHAR(3)').nullable().alter();
  });
};

exports.down = async function(knex) {
  await knex.schema.alterTable('gl_transactionDetail', function(table) {
    table.string('costCenter', 50).nullable().alter();
    table.string('profitCenter', 50).nullable().alter();
  });
};
