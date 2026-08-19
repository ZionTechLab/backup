const db = require('../../../database');
const { round2 } = require('../../../repository/glPosting');

const repo = {
  // --- IOU Register -----------------------------------------------------------
  async iouRegister(filters) {
    const { tenantId, companyId, fromDate, toDate, cashBookId } = filters;
    let q = db('pc_txn_iou as i')
      .select(
        'i.iouId', 'i.docNo', 'i.iouDate', 'i.cashBookId',
        'i.partyType', 'i.partyId', 'i.requestAmount', 'i.settledAmount',
        db.raw('i.requestAmount - i.settledAmount as outstanding'),
        'i.status', 'i.purpose', 'i.expectedSettlementDate', 'i.paidDate',
        'cb.code as cashBookCode', 'cb.name as cashBookName',
        'bp.partnerName as partyName',
        db.raw("'PIOU/' || i.docNo as iouNo")
      )
      .leftJoin('pc_mas_cashBook as cb', 'cb.cashBookId', 'i.cashBookId')
      .leftJoin('mas_businessPartner as bp', 'bp.businessPartnerId', 'i.partyId')
      .where({ 'i.tenantId': tenantId, 'i.companyId': companyId });
    if (fromDate) q = q.where('i.iouDate', '>=', fromDate);
    if (toDate) q = q.where('i.iouDate', '<=', toDate);
    if (cashBookId) q = q.where('i.cashBookId', cashBookId);
    return q.orderBy([{ column: 'i.iouDate', order: 'desc' }, { column: 'i.docNo', order: 'desc' }]);
  },

  // --- IOU Aging --------------------------------------------------------------
  async iouAging(filters) {
    const { tenantId, companyId, asOf } = filters;
    const cutoff = asOf || new Date().toISOString().split('T')[0];

    const rows = await db('pc_txn_iou as i')
      .select(
        'i.iouId', 'i.docNo', 'i.paidDate', 'i.requestAmount',
        'i.settledAmount', 'i.partyId',
        'bp.partnerName as partyName',
        db.raw("'PIOU/' || i.docNo as iouRef"),
        db.raw('i.requestAmount - COALESCE(i.settledAmount, 0) as outstanding')
      )
      .leftJoin('mas_businessPartner as bp', 'bp.businessPartnerId', 'i.partyId')
      .where({ 'i.tenantId': tenantId, 'i.companyId': companyId })
      .where({ 'i.status': 'Paid' })
      .whereRaw('i.requestAmount > COALESCE(i.settledAmount, 0)')
      .orderBy('bp.partnerName');

    const now = new Date(cutoff);
    const partyMap = new Map();
    const totals = { b0_7: 0, b8_15: 0, b16_30: 0, b30plus: 0 };

    for (const r of rows) {
      const days = r.paidDate
        ? Math.floor((now - new Date(r.paidDate)) / (1000 * 60 * 60 * 24))
        : 0;
      const bucket = days <= 7 ? 'b0_7' : days <= 15 ? 'b8_15' : days <= 30 ? 'b16_30' : 'b30plus';
      const outstanding = Number(r.outstanding || 0);
      if (!partyMap.has(r.partyId)) {
        partyMap.set(r.partyId, {
          partyId: r.partyId,
          partyName: r.partyName || 'Unknown',
          b0_7: 0, b8_15: 0, b16_30: 0, b30plus: 0, total: 0,
        });
      }
      const party = partyMap.get(r.partyId);
      party[bucket] = round2(party[bucket] + outstanding);
      party.total = round2(party.total + outstanding);
      totals[bucket] = round2(totals[bucket] + outstanding);
    }

    return {
      parties: Array.from(partyMap.values()),
      totals,
      asOf: cutoff,
    };
  },

  // --- Party Outstanding ------------------------------------------------------
  async partyOutstanding(filters) {
    const { tenantId, companyId } = filters;
    const rows = await db('pc_txn_iou as i')
      .select(
        'bp.partnerName as partyName',
        'i.partyId',
        db.raw('COUNT(*) as iouCount'),
        db.raw('COALESCE(SUM(i.requestAmount), 0) as totalAdvance'),
        db.raw('COALESCE(SUM(i.settledAmount), 0) as totalSettled'),
        db.raw('COALESCE(SUM(i.requestAmount), 0) - COALESCE(SUM(i.settledAmount), 0) as outstanding')
      )
      .leftJoin('mas_businessPartner as bp', 'bp.businessPartnerId', 'i.partyId')
      .where({ 'i.tenantId': tenantId, 'i.companyId': companyId })
      .whereIn('i.status', ['Paid'])
      .whereRaw('i.requestAmount > COALESCE(i.settledAmount, 0)')
      .groupBy('i.partyId', 'bp.partnerName')
      .orderByRaw('COALESCE(SUM(i.requestAmount), 0) - COALESCE(SUM(i.settledAmount), 0) desc');
    return rows;
  },

  // --- Cash Book Balances -----------------------------------------------------
  async cashBookBalances(filters) {
    const { tenantId, companyId } = filters;
    const books = await db('pc_mas_cashBook as cb')
      .select(
        'cb.cashBookId', 'cb.code', 'cb.name', 'cb.currencyCode',
        'cb.glAccountId', 'cb.floatLimit',
        'u.fullName as cashierName'
      )
      .leftJoin('mas_users as u', 'u.userId', 'cb.cashierUserId')
      .where({ 'cb.tenantId': tenantId, 'cb.companyId': companyId, 'cb.deleted': false, 'cb.isActive': true })
      .orderBy('cb.code');

    const glAccountIds = books.map(b => b.glAccountId).filter(Boolean);
    const balances = {};
    if (glAccountIds.length) {
      const glRows = await db('gl_transactionDetail as d')
        .join('gl_transactions as h', 'h.transactionId', 'd.transactionId')
        .where({ 'h.status': 'Posted' })
        .whereIn('d.accountId', glAccountIds)
        .select(
          'd.accountId',
          db.raw('COALESCE(SUM(d.debitBase), 0) - COALESCE(SUM(d.creditBase), 0) as balance')
        )
        .groupBy('d.accountId');
      for (const r of glRows) {
        balances[r.accountId] = round2(r.balance);
      }
    }

    return books.map(b => ({
      cashBookId: b.cashBookId,
      code: b.code,
      name: b.name,
      currencyCode: b.currencyCode,
      cashierName: b.cashierName || '-',
      floatLimit: Number(b.floatLimit || 0),
      balance: round2(balances[b.glAccountId] || 0),
      headroom: round2(Number(b.floatLimit || 0) - (balances[b.glAccountId] || 0)),
    }));
  },

  // --- Manager Dashboard ------------------------------------------------------
  async managerDashboard(filters) {
    const { tenantId, companyId, fromDate, toDate } = filters;

    const books = await db('pc_mas_cashBook as cb')
      .select(
        'cb.cashBookId', 'cb.code', 'cb.name', 'cb.glAccountId', 'cb.floatLimit',
        'u.fullName as cashierName'
      )
      .leftJoin('mas_users as u', 'u.userId', 'cb.cashierUserId')
      .where({ 'cb.tenantId': tenantId, 'cb.companyId': companyId, 'cb.deleted': false, 'cb.isActive': true })
      .orderBy('cb.code');

    const bookIds = books.map(b => b.cashBookId);

    // GL balances (on hand).
    const glAccountIds = books.map(b => b.glAccountId).filter(Boolean);
    const balances = {};
    if (glAccountIds.length) {
      const glRows = await db('gl_transactionDetail as d')
        .join('gl_transactions as h', 'h.transactionId', 'd.transactionId')
        .where({ 'h.status': 'Posted' })
        .whereIn('d.accountId', glAccountIds)
        .select('d.accountId', db.raw('COALESCE(SUM(d.debitBase), 0) - COALESCE(SUM(d.creditBase), 0) as balance'))
        .groupBy('d.accountId');
      for (const r of glRows) { balances[r.accountId] = round2(r.balance); }
    }

    // IOU issued: only IOUs where cash has actually been disbursed (Paid or
    // later), not merely requested/approved. Draft/Confirmed/Approved/Rejected/
    // OnHold IOUs have not moved any cash.
    const iouIssuedRows = await db('pc_txn_iou')
      .select('cashBookId', db.raw('COALESCE(SUM(requestAmount), 0) as total'))
      .whereIn('cashBookId', bookIds)
      .whereIn('status', ['Paid', 'Settled', 'Fully Settled'])
      .groupBy('cashBookId')
      .modify(q => { if (fromDate) q.where('iouDate', '>=', fromDate); if (toDate) q.where('iouDate', '<=', toDate); });

    // IOU settled.
    const iouSettledRows = await db('pc_txn_iou')
      .select('cashBookId', db.raw('COALESCE(SUM(settledAmount), 0) as total'))
      .whereIn('cashBookId', bookIds)
      .whereNotIn('status', ['Cancelled'])
      .groupBy('cashBookId')
      .modify(q => { if (fromDate) q.where('iouDate', '>=', fromDate); if (toDate) q.where('iouDate', '<=', toDate); });

    // Petty cash paid: legacy directly-paid vouchers, plus extra paid to
    // parties at cleared settlements (the merged payment path). Settlements
    // are attributed to the cash book of their voucher or first allocated IOU.
    const voucherRows = await db('pc_txn_voucher')
      .select('cashBookId', db.raw('COALESCE(SUM(totalAmount), 0) as total'))
      .whereIn('cashBookId', bookIds)
      .where({ status: 'Paid' })
      .groupBy('cashBookId')
      .modify(q => { if (fromDate) q.where('voucherDate', '>=', fromDate); if (toDate) q.where('voucherDate', '<=', toDate); });

    const settlementPaidRows = await db('pc_txn_iouSettlement as s')
      .select(
        db.raw('COALESCE(v.cashBookId, i.cashBookId) as cashBookId'),
        db.raw('COALESCE(SUM(s.balanceClaimed), 0) as total')
      )
      .leftJoin('pc_txn_voucher as v', 'v.voucherId', 's.voucherId')
      .leftJoin(
        db('pc_txn_settlementAllocation').select('settlementId', db.raw('MIN(iouId) as iouId')).groupBy('settlementId').as('fa'),
        'fa.settlementId', 's.settlementId'
      )
      .leftJoin('pc_txn_iou as i', 'i.iouId', db.raw('COALESCE(fa.iouId, s.iouId)'))
      .where({ 's.status': 'Cleared' })
      .where('s.balanceClaimed', '>', 0)
      .groupBy(db.raw('COALESCE(v.cashBookId, i.cashBookId)'))
      .modify(q => { if (fromDate) q.where('s.settlementDate', '>=', fromDate); if (toDate) q.where('s.settlementDate', '<=', toDate); });

    const issuedMap = Object.fromEntries(iouIssuedRows.map(r => [r.cashBookId, round2(r.total)]));
    const settledMap = Object.fromEntries(iouSettledRows.map(r => [r.cashBookId, round2(r.total)]));
    const voucherMap = Object.fromEntries(voucherRows.map(r => [r.cashBookId, round2(r.total)]));
    for (const r of settlementPaidRows) {
      if (!r.cashBookId) continue;
      voucherMap[r.cashBookId] = round2((voucherMap[r.cashBookId] || 0) + Number(r.total || 0));
    }

    const rows = books.map(b => ({
      cashBookId: b.cashBookId,
      code: b.code,
      name: b.name,
      cashierName: b.cashierName || '-',
      onHand: round2(balances[b.glAccountId] || 0),
      iouIssued: round2(issuedMap[b.cashBookId] || 0),
      iouSettled: round2(settledMap[b.cashBookId] || 0),
      pettyCashPaid: round2(voucherMap[b.cashBookId] || 0),
    }));

    // KPIs.
    const totalFloat = books.reduce((s, b) => s + Number(b.floatLimit || 0), 0);

    const outstandingRow = await db('pc_txn_iou')
      .select(db.raw('COALESCE(SUM(requestAmount), 0) - COALESCE(SUM(settledAmount), 0) as total'))
      .where({ tenantId, companyId, status: 'Paid' })
      .whereIn('cashBookId', bookIds)
      .whereRaw('requestAmount > COALESCE(settledAmount, 0)')
      .first();

    // Settlement period from params.
    const settlementParam = await db('pc_ref_param')
      .where({ companyId, paramGroup: 'SETTLEMENT_PERIOD', paramKey: 'DAYS', deleted: false, isActive: true })
      .first();
    const periodDays = Number(settlementParam?.numValue || 14);

    const overdueRow = await db('pc_txn_iou')
      .where({ tenantId, companyId, status: 'Paid' })
      .whereIn('cashBookId', bookIds)
      .where('paidDate', '<=', db.raw("date('now', ? || ' days')", ['-' + periodDays]))
      .whereRaw('requestAmount > COALESCE(settledAmount, 0)')
      .count('* as count')
      .first();

    return {
      rows,
      kpi: {
        totalFloat: round2(totalFloat),
        totalOutstandingIou: round2(outstandingRow?.total || 0),
        overdueIouCount: Number(overdueRow?.count || 0),
        settlementPeriodDays: periodDays,
      },
    };
  },
};

module.exports = repo;
