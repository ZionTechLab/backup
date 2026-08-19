exports.up = async function (knex) {
  await knex.schema.alterTable('pc_txn_iouSettlement', (t) => {
    t.uuid('cashBookId').references('cashBookId').inTable('pc_mas_cashBook');
    t.specificType('currencyCode', 'CHAR(3)').references('currencyCode').inTable('sec_currencies');
    t.decimal('exchangeRate', 18, 8).defaultTo(1);
  });
};

exports.down = async function (knex) {
  await knex.schema.alterTable('pc_txn_iouSettlement', (t) => {
    t.dropColumn('cashBookId');
    t.dropColumn('currencyCode');
    t.dropColumn('exchangeRate');
  });
};
