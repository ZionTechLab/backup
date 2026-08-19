// Lets an IOU settlement consume a petty cash request (voucher) as its bills
// instead of manually typed lines. Two schema changes:
//
// 1. pc_txn_iouSettlement.voucherId — nullable link to the voucher whose lines
//    were used. Set once at save, consumed at clear.
// 2. pc_txn_voucher.status — was an enum CHECK (Draft/Submitted/Approved/Paid/
//    Cancelled). Offsetting against an IOU needs a distinct terminal status
//    'Settled' (expenses posted via the settlement, no cash paid out), so the
//    column is rebuilt as plain varchar. Same pattern as the earlier
//    iouRequest status rebuild.

exports.up = async function (knex) {
  await knex.schema.alterTable('pc_txn_iouSettlement', (t) => {
    t.uuid('voucherId').references('voucherId').inTable('pc_txn_voucher');
  });

  await knex.schema.alterTable('pc_txn_voucher', (t) => {
    t.string('statusNew', 30).notNullable().defaultTo('Draft');
  });
  await knex('pc_txn_voucher').update({ statusNew: knex.raw('status') });
  await knex.schema.alterTable('pc_txn_voucher', (t) => {
    t.dropColumn('status');
  });
  await knex.schema.alterTable('pc_txn_voucher', (t) => {
    t.renameColumn('statusNew', 'status');
  });
};

exports.down = async function (knex) {
  await knex.schema.alterTable('pc_txn_iouSettlement', (t) => {
    t.dropColumn('voucherId');
  });
  // Status stays varchar on rollback; restoring the CHECK would fail if any
  // row already holds 'Settled'.
};
