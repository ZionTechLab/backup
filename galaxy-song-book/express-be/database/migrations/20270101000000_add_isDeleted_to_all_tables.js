exports.up = function(knex) {
  return knex.schema
    .alterTable('ar_txn_debtorTXN', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('ar_txn_debtorTXNDetail', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('gen_txn_images', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('imp_txn_activityLog', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('imp_txn_activityLogDetail', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('imp_txn_vehicleConfirmation', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('ims_mas_items', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('ims_mas_stores', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    })
    .alterTable('ims_txn_stock', function(table) {
      table.boolean('isDeleted').notNullable().defaultTo(false);
    });
};

exports.down = function(knex) {
  return knex.schema
    .alterTable('ar_txn_debtorTXN', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('ar_txn_debtorTXNDetail', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('gen_txn_images', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('imp_txn_activityLog', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('imp_txn_activityLogDetail', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('imp_txn_vehicleConfirmation', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('ims_mas_items', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('ims_mas_stores', function(table) {
      table.dropColumn('isDeleted');
    })
    .alterTable('ims_txn_stock', function(table) {
      table.dropColumn('isDeleted');
    });
};
