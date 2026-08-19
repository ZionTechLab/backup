// Reworks the settlement into a per-party cash box event that can settle
// MULTIPLE IOUs at once:
//
//   Bills + Cash Returned = IOU Allocations + Extra Paid to Party
//
// 1. New pc_txn_settlementAllocation: one row per (settlement, iou) with the
//    amount allocated against that IOU's outstanding advance.
// 2. Header gains partyType/partyId. The document is party-scoped; the party
//    drives the advance suspense account at posting time.
// 3. Header iouId becomes nullable (rebuilt). Legacy single-IOU rows keep it;
//    new rows leave it null and use allocation rows.
// 4. Legacy rows are backfilled into allocation rows so cancel/reporting reads
//    one shape. balanceReturned is reused as the cash-returned amount; its
//    meaning is unchanged (cash coming back into the box).

exports.up = async function (knex) {
  await knex.schema.createTable('pc_txn_settlementAllocation', (t) => {
    t.uuid('settlementId').notNullable().references('settlementId').inTable('pc_txn_iouSettlement');
    t.uuid('iouId').notNullable().references('iouId').inTable('pc_txn_iou');
    t.decimal('allocatedAmount', 18, 2).notNullable().defaultTo(0);
    t.primary(['settlementId', 'iouId']);
  });

  await knex.schema.alterTable('pc_txn_iouSettlement', (t) => {
    t.string('partyType', 20);
    t.uuid('partyId');
  });

  // Rebuild iouId as nullable. MySQL requires the FK dropped before the
  // column can be replaced; SQLite has no named constraints to drop and
  // rebuilds the table on its own when the column is dropped below.
  if (knex.client.config.client === 'mysql') {
    await knex.raw('ALTER TABLE ?? DROP FOREIGN KEY ??', ['pc_txn_iouSettlement', 'pc_txn_iousettlement_iouid_foreign']);
  }
  await knex.schema.alterTable('pc_txn_iouSettlement', (t) => {
    t.uuid('iouIdNew');
  });
  await knex('pc_txn_iouSettlement').update({ iouIdNew: knex.raw('iouId') });
  await knex.schema.alterTable('pc_txn_iouSettlement', (t) => {
    t.dropColumn('iouId');
  });
  await knex.schema.alterTable('pc_txn_iouSettlement', (t) => {
    t.renameColumn('iouIdNew', 'iouId');
  });

  // Backfill legacy single-IOU settlements.
  const legacy = await knex('pc_txn_iouSettlement').whereNotNull('iouId');
  for (const s of legacy) {
    const iou = await knex('pc_txn_iou').where({ iouId: s.iouId }).first();
    if (!iou) continue;
    const allocated =
      Number(s.totalBills || 0) + Number(s.balanceReturned || 0) - Number(s.balanceClaimed || 0);
    const existing = await knex('pc_txn_settlementAllocation')
      .where({ settlementId: s.settlementId, iouId: s.iouId }).first();
    if (!existing && allocated > 0) {
      await knex('pc_txn_settlementAllocation').insert({
        settlementId: s.settlementId, iouId: s.iouId, allocatedAmount: allocated,
      });
    }
    await knex('pc_txn_iouSettlement').where({ settlementId: s.settlementId }).update({
      partyType: iou.partyType, partyId: iou.partyId,
    });
  }
};

exports.down = async function (knex) {
  await knex.schema.dropTableIfExists('pc_txn_settlementAllocation');
  await knex.schema.alterTable('pc_txn_iouSettlement', (t) => {
    t.dropColumn('partyType');
    t.dropColumn('partyId');
  });
  // iouId stays nullable on rollback; restoring NOT NULL would fail for any
  // allocation-based rows created in the meantime.
};
