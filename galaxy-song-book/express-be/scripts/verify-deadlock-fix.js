// Deadlock verification — runs all 4 fixed repos with real data.
const path = require('path');
const BE = 'C:/repo/personal/service-plus/express-be';
process.chdir(BE);
const db = require(path.join(BE, 'src/database'));

function requireRepo(name) {
  return require(path.join(BE, 'src/features/pettyCash', name, 'repository'));
}

const repos = {
  cashCount:    requireRepo('cashCount'),
  replenishment: requireRepo('replenishment'),
  settlement:   requireRepo('settlement'),
  voucher:      requireRepo('voucher'),
};

// Real DB IDs
const TENANT  = 'af8b2ce9-059a-4042-80f8-ed04a6fb4da3';
const COMPANY = 'b9bac52d-c3d7-416e-b3d7-e21f176583b2';
const USER    = '557e950a-0136-46fe-b6a7-00fe5f53d878';

function deadlockGuard(name) {
  const t = setTimeout(() => {
    console.error(`\n❌ ${name}: TIMEOUT — still deadlocked after 10s`);
    process.exit(1);
  }, 10000);
  return () => { clearTimeout(t); console.log(`✅ ${name}: OK`); };
}

async function cleanup() { try { await db.destroy(); } catch {} }

// ══════════════════════════════════════════════════════════════
// 1. cashCount
// ══════════════════════════════════════════════════════════════
async function testCashCount() {
  const done = deadlockGuard('cashCount');
  const cb = await db('pc_mas_cashBook').where({ tenantId: TENANT, companyId: COMPANY, isActive: true, deleted: false }).first();

  const created = await repos.cashCount.update({
    tenantId: TENANT, companyId: COMPANY, userId: USER,
    cashBookId: cb.cashBookId,
    countDate: '2026-06-29',
    reason: 'deadlock-test',
    denominations: [
      { denomination: 1000, count: 5, lineNo: 1 },
      { denomination: 500, count: 2, lineNo: 2 },
    ],
    isUpdate: false,
  });
  console.log('cashCount create:', created.status);

  const signed = await repos.cashCount.sign({ id: created.cashCountId, userId: USER });
  console.log('cashCount sign:', signed.status);

  try {
    const cs = await repos.cashCount.countersign({ id: created.cashCountId, userId: USER });
    console.log('cashCount countersign:', cs.status);
  } catch (e) { console.log('cashCount countersign (expected):', e.message); }

  const audited = await repos.cashCount.audit({ id: created.cashCountId, userId: USER });
  console.log('cashCount audit:', audited.status);

  await repos.cashCount.cancel({ id: created.cashCountId, userId: USER });
  console.log('cashCount cancel: success');
  done();
}

// ══════════════════════════════════════════════════════════════
// 2. replenishment
// ══════════════════════════════════════════════════════════════
async function testReplenishment() {
  const done = deadlockGuard('replenishment');
  const cb = await db('pc_mas_cashBook').where({ tenantId: TENANT, companyId: COMPANY, isActive: true, deleted: false }).first();
  const bankAcct = await db('gl_chartOfAccounts').where({ isActive: true, tenantId: TENANT }).first();
  const bankGl = bankAcct ? bankAcct.accountId : cb.glAccountId;

  const created = await repos.replenishment.update({
    tenantId: TENANT, companyId: COMPANY, userId: USER,
    cashBookId: cb.cashBookId,
    requestDate: '2026-06-29',
    amountRequested: 5000,
    periodFrom: '2026-01-01',
    periodTo: '2026-06-30',
    bankGlAccountId: bankGl,
    isUpdate: false,
  });
  console.log('replenishment create:', created.status);

  const verified = await repos.replenishment.verify({ id: created.replenishmentId, userId: USER });
  console.log('replenishment verify:', verified.status);

  const approved = await repos.replenishment.approve({ id: created.replenishmentId, userId: USER });
  console.log('replenishment approve:', approved.status);

  try {
    await repos.replenishment.post({ id: created.replenishmentId, userId: USER });
    console.log('replenishment post: success');
  } catch (e) { console.log('replenishment post (expected):', e.message); }

  await repos.replenishment.cancel({ id: created.replenishmentId, userId: USER });
  console.log('replenishment cancel: success');
  done();
}

// ══════════════════════════════════════════════════════════════
// 3. voucher
// ══════════════════════════════════════════════════════════════
async function testVoucher() {
  const done = deadlockGuard('voucher');
  const cb = await db('pc_mas_cashBook').where({ tenantId: TENANT, companyId: COMPANY, isActive: true, deleted: false }).first();
  const cat = await db('pc_ref_expenseCategory').where({ tenantId: TENANT, companyId: COMPANY, isActive: true, deleted: false }).first();

  const created = await repos.voucher.update({
    tenantId: TENANT, companyId: COMPANY, userId: USER,
    cashBookId: cb.cashBookId,
    voucherDate: '2026-06-29',
    payeePartyType: 'Supplier',
    payeePartyId: null,
    payeeName: 'Deadlock Test Supplier',
    currencyCode: 'LKR',
    exchangeRate: 1,
    description: 'deadlock-test',
    lines: [
      { categoryId: cat.categoryId, description: 'Test line', qty: 1, unitPrice: 100, netAmount: 100, vatAmount: 0, lineTotal: 100 },
    ],
    isUpdate: false,
  });
  console.log('voucher create:', created.status);

  try {
    await repos.voucher.pay({ id: created.voucherId, userId: USER });
    console.log('voucher pay: success');
  } catch (e) { console.log('voucher pay (expected):', e.message); }

  await repos.voucher.cancel({ id: created.voucherId, userId: USER });
  console.log('voucher cancel: success');
  done();
}

// ══════════════════════════════════════════════════════════════
// 4. settlement
// ══════════════════════════════════════════════════════════════
async function testSettlement() {
  const done = deadlockGuard('settlement');

  // Create a Paid IOU first
  const iouRepo = requireRepo('iou');
  const cb = await db('pc_mas_cashBook').where({ tenantId: TENANT, companyId: COMPANY, isActive: true, deleted: false }).first();

  const iouCreated = await iouRepo.update({
    tenantId: TENANT, companyId: COMPANY, userId: USER,
    cashBookId: cb.cashBookId,
    partyType: 'Employee', partyId: null,
    purpose: 'deadlock-test', requestAmount: 5000,
    expectedSettlementDate: '2026-07-29',
    currencyCode: 'LKR', exchangeRate: 1,
    isUpdate: false,
  });
  console.log('IOU create:', iouCreated.status);

  await iouRepo.certify({ id: iouCreated.iouId, userId: USER });
  await iouRepo.approve({ id: iouCreated.iouId, userId: USER });
  try { await iouRepo.pay({ id: iouCreated.iouId, userId: USER }); } catch (e) { console.log('IOU pay (expected):', e.message); }

  const cat = await db('pc_ref_expenseCategory').where({ tenantId: TENANT, companyId: COMPANY, isActive: true, deleted: false }).first();

  const created = await repos.settlement.update({
    tenantId: TENANT, companyId: COMPANY, userId: USER,
    iouId: iouCreated.iouId,
    settlementDate: '2026-06-29',
    lines: [
      { categoryId: cat.categoryId, description: 'Test line', netAmount: 100, vatAmount: 0, lineTotal: 100 },
    ],
    isUpdate: false,
  });
  console.log('settlement create:', created.status);

  try {
    await repos.settlement.clear({ id: created.settlementId, userId: USER });
    console.log('settlement clear: success');
  } catch (e) { console.log('settlement clear (expected):', e.message); }

  await repos.settlement.cancel({ id: created.settlementId, userId: USER });
  console.log('settlement cancel: success');
  done();
}

(async () => {
  try {
    console.log('=== Deadlock Verification ===\n');
    await testCashCount();
    await testReplenishment();
    await testVoucher();
    await testSettlement();
    console.log('\n=== ALL VERIFIED — no deadlocks ===');
  } catch (e) {
    console.error('ERR:', e.message);
    process.exit(1);
  } finally {
    await cleanup();
  }
})();
