// Petty cash transaction tables. Voucher, IOU, settlement, replenishment,
// cash count, IOU audit log, IOU documents, IOU request, cash count denom.
// UUID PKs plus a serial docNo per the gl pattern. glTransactionId links to
// the posted gl_transactions row. Cost center uses the composite
// (companyId, centerCode) FK like gl_transactionDetail.
//
// Merged ALTERs absorbed:
//   pc_txn_iou.paymentMode: includes 'Cash'
//   pc_txn_iou.status: plain string (app-enforced)
//   pc_txn_iou: branchOrgUnitId, confirmedAmount, approvedAmount, onHoldUntil, iouRequestId
//   pc_txn_replenishment: bankGlAccountId
//   pc_txn_iouDoc: new table
//   pc_txn_iouRequest: new table

const common = (knex, t) => {
  t.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
  t.uuid('companyId').notNullable().references('companyId').inTable('sec_companies');
  t.string('docType', 10).notNullable();
  t.string('txnType', 10).notNullable();
  t.integer('docNo').notNullable();
  t.uuid('glTransactionId').references('transactionId').inTable('gl_transactions');
  t.uuid('updatedBy').references('userId').inTable('mas_users');
  t.dateTime('updatedAt').defaultTo(knex.fn.now());
};

exports.up = async function (knex) {
  // Payment voucher header. Direct expense paid from a cash book.
  await knex.schema.createTable('pc_txn_voucher', function (t) {
    t.uuid('voucherId').primary().defaultTo(knex.fn.uuid());
    common(knex, t);
    t.uuid('cashBookId').notNullable().references('cashBookId').inTable('pc_mas_cashBook');
    t.date('voucherDate').notNullable();
    t.string('payeePartyType', 20);
    t.uuid('payeePartyId').references('businessPartnerId').inTable('mas_businessPartner');
    t.string('payeeName', 200);
    t.string('payeeNic', 30);
    t.specificType('costCenterCode', 'CHAR(3)');
    t.string('jobNo', 50);
    t.string('description', 500);
    t.specificType('currencyCode', 'CHAR(3)').notNullable().references('currencyCode').inTable('sec_currencies');
    t.decimal('exchangeRate', 18, 8).notNullable().defaultTo(1);
    t.decimal('subTotal', 18, 2).notNullable().defaultTo(0);
    t.decimal('vatTotal', 18, 2).notNullable().defaultTo(0);
    t.decimal('totalAmount', 18, 2).notNullable().defaultTo(0);
    t.string('receiptPath', 300);
    t.enu('status', ['Draft', 'Submitted', 'Approved', 'Paid', 'Cancelled']).notNullable().defaultTo('Draft');
    t.uuid('approvedBy').references('userId').inTable('mas_users');
    t.dateTime('approvedAt');
    t.uuid('paidBy').references('userId').inTable('mas_users');
    t.dateTime('paidAt');
    t.string('remarks', 500);
    t.foreign(['companyId', 'docType', 'txnType']).references(['companyId', 'docType', 'txnType']).inTable('conf_txnType');
    t.foreign(['companyId', 'costCenterCode']).references(['companyId', 'centerCode']).inTable('gl_centers');
  });

  await knex.schema.createTable('pc_txn_voucherDetail', function (t) {
    t.uuid('voucherId').notNullable().references('voucherId').inTable('pc_txn_voucher');
    t.integer('lineNo').notNullable();
    t.uuid('companyId').notNullable();
    t.uuid('categoryId').notNullable().references('categoryId').inTable('pc_ref_expenseCategory');
    t.string('description', 500);
    t.decimal('qty', 18, 4).notNullable().defaultTo(1);
    t.decimal('unitPrice', 18, 4).notNullable().defaultTo(0);
    t.decimal('netAmount', 18, 2).notNullable().defaultTo(0);
    t.decimal('vatAmount', 18, 2).notNullable().defaultTo(0);
    t.decimal('lineTotal', 18, 2).notNullable().defaultTo(0);
    t.specificType('costCenterCode', 'CHAR(3)');
    t.primary(['voucherId', 'lineNo']);
    t.foreign(['companyId', 'costCenterCode']).references(['companyId', 'centerCode']).inTable('gl_centers');
  });

  // IOU Request. Pre-authorization before converting to an IOU.
  // Created BEFORE pc_txn_iou because pc_txn_iou references this table.
  await knex.schema.createTable('pc_txn_iouRequest', function (t) {
    t.uuid('iouRequestId').primary().defaultTo(knex.fn.uuid());
    common(knex, t);
    t.string('partyType', 20).notNullable();
    t.uuid('partyId').notNullable().references('businessPartnerId').inTable('mas_businessPartner');
    t.string('purpose', 500);
    t.decimal('requestAmount', 18, 2).notNullable();
    t.date('expectedSettlementDate');
    t.string('jobPoRef', 50);
    t.string('supportingDocPath', 300);
    t.uuid('requestedByUserId').references('userId').inTable('mas_users');
    t.enu('status', ['Draft', 'Certified', 'Approved', 'Rejected', 'Settled', 'Cancelled']).notNullable().defaultTo('Draft');
    t.uuid('certifiedBy').references('userId').inTable('mas_users');
    t.dateTime('certifiedAt');
    t.uuid('approvedBy').references('userId').inTable('mas_users');
    t.dateTime('approvedAt');
    t.uuid('rejectedBy').references('userId').inTable('mas_users');
    t.dateTime('rejectedAt');
    t.string('rejectReason', 500);
    t.string('remarks', 500);
    t.foreign(['companyId', 'docType', 'txnType']).references(['companyId', 'docType', 'txnType']).inTable('conf_txnType');
  });

  // IOU. Cash advance to a party. Settled later with bills.
  // Status is plain string (app-enforced) to allow extended lifecycle values.
  // paymentMode includes 'Cash' alongside PettyCash, BankTransfer, Cheque.
  await knex.schema.createTable('pc_txn_iou', function (t) {
    t.uuid('iouId').primary().defaultTo(knex.fn.uuid());
    common(knex, t);
    t.uuid('cashBookId').notNullable().references('cashBookId').inTable('pc_mas_cashBook');
    t.string('partyType', 20).notNullable();
    t.uuid('partyId').notNullable().references('businessPartnerId').inTable('mas_businessPartner');
    t.string('purpose', 500);
    t.decimal('requestAmount', 18, 2).notNullable();
    t.date('expectedSettlementDate');
    t.string('jobPoRef', 50);
    t.string('supportingDocPath', 300);
    t.uuid('requestedByUserId').references('userId').inTable('mas_users');
    t.string('status', 24).notNullable().defaultTo('Draft');
    t.uuid('certifiedBy').references('userId').inTable('mas_users');
    t.dateTime('certifiedAt');
    t.uuid('approvedBy').references('userId').inTable('mas_users');
    t.dateTime('approvedAt');
    t.string('paymentMode', 20);
    t.string('voucherRef', 50);
    t.date('paidDate');
    t.uuid('paidByCashierId').references('userId').inTable('mas_users');
    t.decimal('settledAmount', 18, 2).notNullable().defaultTo(0);
    t.specificType('currencyCode', 'CHAR(3)').notNullable().references('currencyCode').inTable('sec_currencies');
    t.decimal('exchangeRate', 18, 8).notNullable().defaultTo(1);
    t.uuid('branchOrgUnitId').references('orgUnitId').inTable('mas_orgUnit');
    t.decimal('confirmedAmount', 18, 2);
    t.decimal('approvedAmount', 18, 2);
    t.date('onHoldUntil');
    t.uuid('iouRequestId').references('iouRequestId').inTable('pc_txn_iouRequest');
    t.string('remarks', 500);
    t.foreign(['companyId', 'docType', 'txnType']).references(['companyId', 'docType', 'txnType']).inTable('conf_txnType');
  });

  // Settlement. Clears an IOU with bills. Returns or claims the balance.
  await knex.schema.createTable('pc_txn_iouSettlement', function (t) {
    t.uuid('settlementId').primary().defaultTo(knex.fn.uuid());
    common(knex, t);
    t.uuid('iouId').notNullable().references('iouId').inTable('pc_txn_iou');
    t.date('settlementDate').notNullable();
    t.decimal('totalBills', 18, 2).notNullable().defaultTo(0);
    t.decimal('balanceReturned', 18, 2).notNullable().defaultTo(0);
    t.decimal('balanceClaimed', 18, 2).notNullable().defaultTo(0);
    t.uuid('accountantClearedBy').references('userId').inTable('mas_users');
    t.dateTime('clearedAt');
    t.string('receiptsPath', 300);
    t.enu('status', ['Draft', 'Cleared', 'Cancelled']).notNullable().defaultTo('Draft');
    t.foreign(['companyId', 'docType', 'txnType']).references(['companyId', 'docType', 'txnType']).inTable('conf_txnType');
  });

  await knex.schema.createTable('pc_txn_settlementDetail', function (t) {
    t.uuid('settlementId').notNullable().references('settlementId').inTable('pc_txn_iouSettlement');
    t.integer('lineNo').notNullable();
    t.uuid('companyId').notNullable();
    t.uuid('categoryId').notNullable().references('categoryId').inTable('pc_ref_expenseCategory');
    t.string('description', 500);
    t.decimal('netAmount', 18, 2).notNullable().defaultTo(0);
    t.decimal('vatAmount', 18, 2).notNullable().defaultTo(0);
    t.decimal('lineTotal', 18, 2).notNullable().defaultTo(0);
    t.specificType('costCenterCode', 'CHAR(3)');
    t.primary(['settlementId', 'lineNo']);
    t.foreign(['companyId', 'costCenterCode']).references(['companyId', 'centerCode']).inTable('gl_centers');
  });

  // Replenishment. Top-up the float back toward its limit. Posts one PV.
  await knex.schema.createTable('pc_txn_replenishment', function (t) {
    t.uuid('replenishmentId').primary().defaultTo(knex.fn.uuid());
    common(knex, t);
    t.uuid('cashBookId').notNullable().references('cashBookId').inTable('pc_mas_cashBook');
    t.date('requestDate').notNullable();
    t.decimal('currentBalance', 18, 2).notNullable().defaultTo(0);
    t.decimal('amountRequested', 18, 2).notNullable();
    t.date('periodFrom');
    t.date('periodTo');
    t.uuid('verifiedBy').references('userId').inTable('mas_users');
    t.dateTime('verifiedAt');
    t.uuid('approvedBy').references('userId').inTable('mas_users');
    t.dateTime('approvedAt');
    t.string('bankTransferRef', 50);
    t.uuid('bankGlAccountId').references('accountId').inTable('gl_chartOfAccounts');
    t.enu('status', ['Requested', 'Verified', 'Approved', 'Posted', 'Cancelled']).notNullable().defaultTo('Requested');
    t.foreign(['companyId', 'docType', 'txnType']).references(['companyId', 'docType', 'txnType']).inTable('conf_txnType');
  });

  // Cash count. Physical vs system balance. Variance to Cash Short/Over.
  await knex.schema.createTable('pc_txn_cashCount', function (t) {
    t.uuid('cashCountId').primary().defaultTo(knex.fn.uuid());
    common(knex, t);
    t.uuid('cashBookId').notNullable().references('cashBookId').inTable('pc_mas_cashBook');
    t.date('countDate').notNullable();
    t.decimal('systemBalance', 18, 2).notNullable().defaultTo(0);
    t.decimal('physicalTotal', 18, 2).notNullable().defaultTo(0);
    t.decimal('variance', 18, 2).notNullable().defaultTo(0);
    t.string('reason', 500);
    t.uuid('cashierSignedBy').references('userId').inTable('mas_users');
    t.dateTime('cashierSignedAt');
    t.uuid('accountantSignedBy').references('userId').inTable('mas_users');
    t.dateTime('accountantSignedAt');
    t.uuid('auditorSignedBy').references('userId').inTable('mas_users');
    t.dateTime('auditorSignedAt');
    t.string('photoPath', 300);
    t.enu('status', ['Draft', 'Signed', 'Countersigned', 'Audited']).notNullable().defaultTo('Draft');
    t.foreign(['companyId', 'docType', 'txnType']).references(['companyId', 'docType', 'txnType']).inTable('conf_txnType');
  });

  await knex.schema.createTable('pc_txn_cashCountDenom', function (t) {
    t.uuid('cashCountId').notNullable().references('cashCountId').inTable('pc_txn_cashCount');
    t.integer('lineNo').notNullable();
    t.decimal('denomination', 18, 2).notNullable();
    t.integer('count').notNullable().defaultTo(0);
    t.decimal('lineTotal', 18, 2).notNullable().defaultTo(0);
    t.primary(['cashCountId', 'lineNo']);
  });

  // IOU audit log. One row per auditor. Reports list all auditors.
  await knex.schema.createTable('pc_log_iouAudit', function (t) {
    t.uuid('auditLogId').primary().defaultTo(knex.fn.uuid());
    t.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    t.uuid('companyId').notNullable().references('companyId').inTable('sec_companies');
    t.uuid('iouId').notNullable().references('iouId').inTable('pc_txn_iou');
    t.uuid('auditorUserId').notNullable().references('userId').inTable('mas_users');
    t.string('auditorRole', 30);
    t.dateTime('auditedAt').defaultTo(knex.fn.now());
    t.string('comment', 500);
  });

  // IOU supporting documents. Linked to pc_txn_iou.
  await knex.schema.createTable('pc_txn_iouDoc', function (t) {
    t.uuid('docId').primary().defaultTo(knex.fn.uuid());
    t.uuid('iouId').notNullable().references('iouId').inTable('pc_txn_iou');
    t.uuid('companyId').notNullable();
    t.integer('lineNo').notNullable();
    t.string('filePath', 300).notNullable();
    t.string('comment', 500);
  });
};

exports.down = async function (knex) {
  await knex.schema.dropTableIfExists('pc_txn_iouDoc');
  await knex.schema.dropTableIfExists('pc_log_iouAudit');
  await knex.schema.dropTableIfExists('pc_txn_cashCountDenom');
  await knex.schema.dropTableIfExists('pc_txn_cashCount');
  await knex.schema.dropTableIfExists('pc_txn_replenishment');
  await knex.schema.dropTableIfExists('pc_txn_settlementDetail');
  await knex.schema.dropTableIfExists('pc_txn_iouSettlement');
  await knex.schema.dropTableIfExists('pc_txn_iou');
  await knex.schema.dropTableIfExists('pc_txn_iouRequest');
  await knex.schema.dropTableIfExists('pc_txn_voucherDetail');
  await knex.schema.dropTableIfExists('pc_txn_voucher');
};
