const crypto = require('crypto');
const db = require('../../../database');
const { getNextSerialNo } = require('../../../repository/getNextSerialNo');
const { snapshotBefore, snapshotInsert } = require('../../../repository/auditHistory');
const { pickFields } = require('../../../repository/pickFields');
const { postGl, voidGl, round2 } = require('../../../repository/glPosting');
const workflow = require('../../../repository/workflow');
const { AppError } = require('../../../middleware/errorHandler');

const TABLE = 'pc_txn_iouSettlement';
const DETAIL = 'pc_txn_settlementDetail';
const ALLOC = 'pc_txn_settlementAllocation';
const DOC = 'PSET';

// The settlement is a per-party cash box event balancing
//   bills + cash returned = IOU allocations + extra paid to party
// Bills recognize expenses. Allocations clear the advance suspense per IOU.
// Cash lines move the float. One GL posting at clear.

const SETT_FIELDS = ['settlementDate', 'receiptsPath', 'remarks', 'voucherId', 'partyType', 'partyId', 'cashBookId', 'currencyCode', 'exchangeRate'];
const LINE_FIELDS = ['categoryId', 'description', 'netAmount', 'vatAmount', 'lineTotal', 'costCenterCode'];

// Loads and validates the draft voucher a settlement offsets against, and
// returns its lines mapped to settlement-line shape. The voucher must belong
// to the same company, still be Draft, and be for the settlement's party.
async function resolveVoucherLines(trx, voucherId, header, companyId) {
  const v = await trx('pc_txn_voucher').where({ voucherId }).first();
  if (!v) throw new AppError('Linked petty cash request not found', 404);
  if (v.companyId !== companyId) throw new AppError('Petty cash request belongs to another company', 409);
  if (v.status !== 'Draft') throw new AppError('Petty cash request is no longer open', 409);
  if (!v.payeePartyId || v.payeePartyId !== header.partyId) {
    throw new AppError('Petty cash request is not for the settlement party', 409);
  }
  if (header.cashBookId && v.cashBookId !== header.cashBookId) {
    throw new AppError('Petty cash request belongs to a different cash book', 409);
  }
  const vLines = await trx('pc_txn_voucherDetail').where({ voucherId }).orderBy('lineNo');
  if (!vLines.length) throw new AppError('Petty cash request has no lines', 400);
  return vLines.map((l) => ({
    categoryId: l.categoryId,
    description: l.description,
    netAmount: l.netAmount,
    vatAmount: l.vatAmount,
    lineTotal: l.lineTotal,
    costCenterCode: l.costCenterCode,
  }));
}

// Loads and validates the IOUs behind the allocations. All must be Paid,
// belong to the settlement party, share one currency and one cash book, and
// each allocation must fit within that IOU's outstanding balance.
async function resolveAllocations(trx, allocations, header) {
  const seen = new Set();
  const resolved = [];
  for (const a of allocations) {
    if (seen.has(a.iouId)) throw new AppError('Duplicate IOU in allocations', 400);
    seen.add(a.iouId);
    const iou = await trx('pc_txn_iou').where({ iouId: a.iouId }).first();
    if (!iou) throw new AppError('Allocated IOU not found', 404);
    if (iou.status !== 'Paid') throw new AppError(`IOU ${iou.docNo} is not open for settlement`, 409);
    if (iou.partyId !== header.partyId) throw new AppError(`IOU ${iou.docNo} belongs to a different party`, 409);
    // The advance suspense account is keyed by partyType. A mismatch would
    // credit a different advance account than the IOU pay debited, leaving
    // suspense uncleared. Keep the header partyType consistent with the IOU.
    if (header.partyType && iou.partyType !== header.partyType) {
      throw new AppError(`IOU ${iou.docNo} party type (${iou.partyType}) does not match the settlement (${header.partyType})`, 409);
    }
    // Cash book is the entry point: only IOUs paid from that same book may be
    // allocated here, since the clear posts against that book's GL account.
    if (header.cashBookId && iou.cashBookId !== header.cashBookId) {
      throw new AppError(`IOU ${iou.docNo} belongs to a different cash book`, 409);
    }
    const outstanding = round2(Number(iou.requestAmount || 0) - Number(iou.settledAmount || 0));
    const amount = round2(Number(a.amount || 0));
    if (amount <= 0) throw new AppError('Allocation must be greater than zero', 400);
    if (amount > outstanding) {
      throw new AppError(`Allocation ${amount} exceeds outstanding ${outstanding} on IOU ${iou.docNo}`, 409);
    }
    resolved.push({ iou, amount });
  }
  const currencies = new Set(resolved.map((r) => r.iou.currencyCode));
  if (currencies.size > 1) throw new AppError('Allocated IOUs must share one currency', 409);
  const books = new Set(resolved.map((r) => r.iou.cashBookId));
  if (books.size > 1) throw new AppError('Allocated IOUs must share one cash book', 409);
  return resolved;
}

// Denormalized inbox label plus the amount used for level-band matching.
// Uses the largest of the three sides of the settlement equation, since any
// of bills, allocations, or cash returned can be the dominant figure
// depending on the scenario (direct payment, pure return, multi-IOU clear).
async function buildDisplay(trx, header, totals) {
  const bp = header.partyId
    ? await trx('mas_businessPartner').where({ businessPartnerId: header.partyId }).first('partnerName')
    : null;
  const amount = Math.max(
    Number(totals.totalBills || 0),
    Number(totals.totalAllocated || 0),
    Number(totals.cashReturned || 0)
  );
  const summary = [header.partyType, amount.toLocaleString(), bp?.partnerName].filter(Boolean).join(' | ');
  return { docNo: `PSET/${header.docNo}`, summary, amount };
}

const repo = {
  async getUi(ctx = {}) {
    const openIous = await db('pc_txn_iou as i')
      .select(
        'i.iouId', 'i.docNo', 'i.partyType', 'i.partyId', 'i.requestAmount', 'i.settledAmount',
        'i.currencyCode', 'i.exchangeRate', 'i.cashBookId', 'i.iouDate',
        'bp.partnerName as partyName',
        db.raw("'PIOU/' || i.docNo as iouNo"),
        db.raw('(i.requestAmount - i.settledAmount) as advanceOutstanding')
      )
      .leftJoin('mas_businessPartner as bp', 'bp.businessPartnerId', 'i.partyId')
      .where({ 'i.tenantId': ctx.tenantId, 'i.companyId': ctx.companyId, 'i.status': 'Paid' })
      .orderBy('i.docNo');
    const categories = await db('pc_ref_expenseCategory')
      .select('categoryId', 'name', 'glAccountId', 'inputVatGlAccountId', 'taxMode', 'taxRate')
      .where({ tenantId: ctx.tenantId, companyId: ctx.companyId, isActive: true, deleted: false })
      .orderBy('name');

    // Draft petty cash requests, offerable as the bills of a settlement.
    // The frontend filters them to the selected party.
    const draftVouchers = await db('pc_txn_voucher as v')
      .select(
        'v.voucherId', 'v.docNo', 'v.payeePartyType', 'v.payeePartyId', 'v.payeeName',
        'v.currencyCode', 'v.totalAmount', 'v.cashBookId',
        db.raw("'PCV/' || v.docNo as voucherNo")
      )
      .leftJoin('mas_businessPartner as bp', 'bp.businessPartnerId', 'v.payeePartyId')
      .where({ 'v.tenantId': ctx.tenantId, 'v.companyId': ctx.companyId, 'v.status': 'Draft' })
      .whereNotNull('v.payeePartyId')
      .orderBy('v.docNo', 'desc');
    const voucherIds = draftVouchers.map((v) => v.voucherId);
    const voucherLines = voucherIds.length
      ? await db('pc_txn_voucherDetail').whereIn('voucherId', voucherIds).orderBy(['voucherId', 'lineNo'])
      : [];
    for (const v of draftVouchers) {
      v.lines = voucherLines.filter((l) => l.voucherId === v.voucherId);
    }

    const parties = await db('mas_businessPartner as bp')
      .select(
        'bp.businessPartnerId',
        'bp.partnerName',
        db.raw('(SELECT partnerType FROM mas_businessPartnerTypes t WHERE t.businessPartnerId = bp.businessPartnerId LIMIT 1) as partyType')
      )
      .orderBy('bp.partnerName');

    const cashBooks = await db('pc_mas_cashBook')
      .select('cashBookId', 'code', 'name', 'currencyCode', 'glAccountId')
      .where({ tenantId: ctx.tenantId, companyId: ctx.companyId, isActive: true, deleted: false })
      .orderBy('code');

    return { openIous, categories, draftVouchers, parties, cashBooks };
  },

  async getAll(filters = {}) {
    return db(`${TABLE} as s`)
      .select(
        's.settlementId', 's.docNo', 's.settlementDate', 's.totalBills',
        's.balanceReturned', 's.balanceClaimed', 's.status',
        db.raw("'PSET/' || s.docNo as settlementNo"),
        db.raw('COALESCE(bp.partnerName, bp2.partnerName) as partyName'),
        db.raw('(SELECT COUNT(*) FROM pc_txn_settlementAllocation a WHERE a.settlementId = s.settlementId) as iouCount')
      )
      .leftJoin('mas_businessPartner as bp', 'bp.businessPartnerId', 's.partyId')
      .leftJoin('pc_txn_iou as i', 'i.iouId', 's.iouId')
      .leftJoin('mas_businessPartner as bp2', 'bp2.businessPartnerId', 'i.partyId')
      .where({ 's.tenantId': filters.tenantId, 's.companyId': filters.companyId })
      .orderBy([{ column: 's.docNo', order: 'desc' }]);
  },

  async get(filters = {}, conn = db) {
    const header = await conn(TABLE).where({ settlementId: filters.id }).first();
    if (!header) return null;
    const bp = header.partyId
      ? await conn('mas_businessPartner').where({ businessPartnerId: header.partyId }).first('partnerName')
      : null;
    header.partyName = bp ? bp.partnerName : null;
    const lines = await conn(DETAIL).where({ settlementId: filters.id }).orderBy('lineNo');
    const allocations = await conn(`${ALLOC} as a`)
      .select(
        'a.iouId', 'a.allocatedAmount',
        'i.docNo', 'i.requestAmount', 'i.settledAmount', 'i.currencyCode',
        db.raw("'PIOU/' || i.docNo as iouNo")
      )
      .join('pc_txn_iou as i', 'i.iouId', 'a.iouId')
      .where({ 'a.settlementId': filters.id });
    const approval = await workflow.getHistory(DOC, filters.id, conn);
    const state = await workflow.getState(DOC, filters.id, conn);
    return {
      ...header, lines, allocations, approval,
      workflowStatus: state ? state.status : null,
      workflowLevel: state ? state.currentLevel : null,
    };
  },

  async update(data) {
    return db.transaction(async (trx) => {
      // The cash book is the entry point: it decides currency and scopes
      // which IOUs/requests can be settled here, since Clear posts against
      // that book's GL account.
      if (!data.cashBookId) throw new AppError('Cash book is required', 400);
      const book = await trx('pc_mas_cashBook')
        .where({ cashBookId: data.cashBookId, deleted: false })
        .first();
      if (!book) throw new AppError('Cash book not found', 404);

      const header = { partyType: data.partyType, partyId: data.partyId, cashBookId: data.cashBookId };

      // Currency is derived from the cash book, not client-supplied.
      data.currencyCode = book.currencyCode;
      data.exchangeRate = data.exchangeRate || 1;

      // Bills come from the linked petty cash request when one is chosen,
      // otherwise from the manually entered lines. Both may be absent for a
      // pure money return.
      const lines = data.voucherId
        ? await resolveVoucherLines(trx, data.voucherId, header, data.companyId)
        : (data.lines || []);

      const allocations = await resolveAllocations(trx, data.allocations || [], header);

      if (!allocations.length && !data.voucherId && !(data.lines || []).length && !Number(data.cashReturned || 0)) {
        throw new AppError('Add bills, a petty cash request, an IOU allocation, or a cash return', 400);
      }

      let totalBills = 0;
      for (const l of lines) totalBills += Number(l.lineTotal || 0);
      totalBills = round2(totalBills);

      const totalAllocated = round2(allocations.reduce((s, a) => s + a.amount, 0));
      const cashReturned = round2(Number(data.cashReturned || 0));
      if (cashReturned < 0) throw new AppError('Cash returned cannot be negative', 400);

      const balanceClaimed = round2(totalBills + cashReturned - totalAllocated);
      if (balanceClaimed < 0) {
        throw new AppError('Allocations exceed bills plus cash returned', 400);
      }
      if (balanceClaimed > 0 && cashReturned > 0) {
        throw new AppError('Cannot both return cash and claim extra. Reduce cash returned.', 400);
      }

      const writeChildren = async (settlementId) => {
        await trx(DETAIL).where({ settlementId }).delete();
        await insertLines(trx, settlementId, data.companyId, lines);
        await trx(ALLOC).where({ settlementId }).delete();
        for (const a of allocations) {
          await trx(ALLOC).insert({ settlementId, iouId: a.iou.iouId, allocatedAmount: a.amount });
        }
      };

      const ctx = { tenantId: data.tenantId, companyId: data.companyId, userId: data.userId };

      if (data.isUpdate) {
        const existing = await trx(TABLE).where({ settlementId: data.settlementId }).first();
        if (!existing) throw new AppError('Not found', 404);
        if (existing.status !== 'Draft') throw new AppError('Only draft settlements can be edited', 409);

        await snapshotBefore(trx, TABLE, { settlementId: data.settlementId }, data.userId, 'UPDATE');
        await trx(TABLE).where({ settlementId: data.settlementId }).update({
          ...pickFields(data, SETT_FIELDS),
          totalBills, balanceReturned: cashReturned, balanceClaimed,
          updatedBy: data.userId ?? null,
          updatedAt: new Date(),
        });
        await writeChildren(data.settlementId);

        // Totals can change on every edit while still Draft/unapproved, so the
        // approval restarts at level 1 each save (workflow.start is an upsert).
        const display = await buildDisplay(trx, { ...header, docNo: existing.docNo }, { totalBills, totalAllocated, cashReturned });
        await workflow.start(trx, ctx, DOC, data.settlementId, display.amount, display);

        return repo.get({ id: data.settlementId }, trx);
      }

      const docNo = await getNextSerialNo(trx, DOC, DOC);
      const settlementId = crypto.randomUUID();
      await trx(TABLE).insert({
        ...pickFields(data, SETT_FIELDS),
        settlementId,
        tenantId: data.tenantId,
        companyId: data.companyId,
        docType: DOC,
        txnType: DOC,
        docNo,
        totalBills, balanceReturned: cashReturned, balanceClaimed,
        status: 'Draft',
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      await snapshotInsert(trx, TABLE, { settlementId }, data.userId);
      await writeChildren(settlementId);

      const display = await buildDisplay(trx, { ...header, docNo }, { totalBills, totalAllocated, cashReturned });
      await workflow.start(trx, ctx, DOC, settlementId, display.amount, display);

      return repo.get({ id: settlementId }, trx);
    });
  },

  // Approve/Reject/OnHold on the settlement's own approval flow. Clear stays
  // blocked until this reaches the final configured level.
  async act(data) {
    return db.transaction(async (trx) => {
      const s = await trx(TABLE).where({ settlementId: data.id }).first();
      if (!s) throw new AppError('Not found', 404);
      if (s.status !== 'Draft') throw new AppError('Only draft settlements can be actioned', 409);
      const ctx = { tenantId: s.tenantId, companyId: s.companyId, userId: data.userId };
      const state = await workflow.getState(DOC, data.id, trx);
      if (!state) throw new AppError('No approval flow for this settlement', 400);

      const allocRows = await trx(ALLOC).where({ settlementId: s.settlementId });
      const totalAllocated = round2(allocRows.reduce((sum, a) => sum + Number(a.allocatedAmount || 0), 0));
      const display = await buildDisplay(
        trx, { partyType: s.partyType, partyId: s.partyId, docNo: s.docNo },
        { totalBills: s.totalBills, totalAllocated, cashReturned: s.balanceReturned }
      );

      await snapshotBefore(trx, TABLE, { settlementId: data.id }, data.userId, 'UPDATE');
      await workflow.act(trx, ctx, {
        docType: DOC, docId: data.id, action: data.action,
        amount: display.amount, comment: data.comment ?? null, onHoldUntil: data.onHoldUntil ?? null,
        docNo: display.docNo, summary: display.summary,
      });
      return repo.get({ id: data.id }, trx);
    });
  },

  async clear(data) {
    return db.transaction(async (trx) => {
      const s = await trx(TABLE).where({ settlementId: data.id }).first();
      if (!s) throw new AppError('Not found', 404);
      if (s.status !== 'Draft') throw new AppError('Only draft settlements can be cleared', 409);

      // Payment cannot post without the settlement's own approval reaching
      // its final level. Closes the control gap this workflow was added for.
      const wfState = await workflow.getState(DOC, s.settlementId, trx);
      if (!wfState) {
        throw new AppError('No approval levels configured for settlements. Configure Approval Levels before clearing.', 400);
      }
      if (wfState.status !== workflow.WF_STATUS.APPROVED) {
        throw new AppError('This settlement has not been approved yet.', 409);
      }

      const lines = await trx(DETAIL).where({ settlementId: s.settlementId }).orderBy('lineNo');
      const allocRows = await trx(ALLOC).where({ settlementId: s.settlementId });

      // Re-validate allocations against live IOU state.
      const allocations = await resolveAllocations(
        trx,
        allocRows.map((a) => ({ iouId: a.iouId, amount: a.allocatedAmount })),
        { partyId: s.partyId, partyType: s.partyType, cashBookId: s.cashBookId }
      );

      // Currency, rate and cash book anchor: the allocated IOUs, or the
      // linked voucher for direct payments.
      let currencyCode, exchangeRate, cashBookId;
      if (allocations.length) {
        currencyCode = allocations[0].iou.currencyCode;
        exchangeRate = Number(allocations[0].iou.exchangeRate || 1);
        cashBookId = allocations[0].iou.cashBookId;
      }

      let voucher = null;
      if (s.voucherId) {
        voucher = await trx('pc_txn_voucher').where({ voucherId: s.voucherId }).first();
        if (!voucher || voucher.status !== 'Draft') {
          throw new AppError('Linked petty cash request is no longer open', 409);
        }
        // The voucher was edited after this settlement copied its lines.
        if (round2(Number(voucher.totalAmount || 0)) !== round2(Number(s.totalBills || 0))) {
          throw new AppError('Petty cash request changed since this settlement was saved. Re-save the settlement first.', 409);
        }
        if (voucher.payeePartyId !== s.partyId) {
          throw new AppError('Petty cash request payee changed since this settlement was saved. Re-save the settlement first.', 409);
        }
        if (currencyCode && voucher.currencyCode !== currencyCode) {
          throw new AppError('Petty cash request currency does not match the allocated IOUs', 409);
        }
        if (!currencyCode) {
          currencyCode = voucher.currencyCode;
          exchangeRate = Number(voucher.exchangeRate || 1);
          cashBookId = voucher.cashBookId;
        }
      }

      if (!currencyCode) {
        if (s.cashBookId && s.currencyCode) {
          currencyCode = s.currencyCode;
          exchangeRate = Number(s.exchangeRate || 1);
          cashBookId = s.cashBookId;
        }
      }

      if (!currencyCode) throw new AppError('Settlement has nothing to post', 400);

      const book = await trx('pc_mas_cashBook').where({ cashBookId }).first();
      if (!book) throw new AppError('Cash book not found', 404);

      const totalAllocated = round2(allocations.reduce((sum, a) => sum + a.amount, 0));
      const balanceReturned = round2(Number(s.balanceReturned || 0));
      const balanceClaimed = round2(Number(s.balanceClaimed || 0));

      // Advance suspense account, needed only when IOUs are being cleared.
      let advanceParam = null;
      if (totalAllocated > 0) {
        advanceParam = await trx('pc_ref_param')
          .where({
            companyId: s.companyId,
            paramGroup: 'ADVANCE_GL',
            paramKey: s.partyType,
            isActive: true,
            deleted: false,
          })
          .first();
        if (!advanceParam || !advanceParam.glAccountId) {
          throw new AppError(`No advance GL account configured for ${s.partyType}`, 400);
        }
      }

      // Resolve category GL accounts and build expense debits.
      const debits = {};
      if (lines.length) {
        const catIds = [...new Set(lines.map((l) => l.categoryId))];
        const cats = await trx('pc_ref_expenseCategory').whereIn('categoryId', catIds);
        const catMap = Object.fromEntries(cats.map((c) => [c.categoryId, c]));
        for (const l of lines) {
          const cat = catMap[l.categoryId];
          if (!cat) throw new AppError('Category not found for a line', 400);
          debits[cat.glAccountId] = round2((debits[cat.glAccountId] || 0) + Number(l.netAmount || 0));
          const vat = Number(l.vatAmount || 0);
          if (vat > 0 && cat.inputVatGlAccountId) {
            debits[cat.inputVatGlAccountId] = round2((debits[cat.inputVatGlAccountId] || 0) + vat);
          }
        }
      }

      const details = Object.entries(debits).map(([accountId, amount]) => ({
        accountId, debitAmount: amount, creditAmount: 0,
        currencyCode, exchangeRate,
      }));
      if (balanceReturned > 0) {
        details.push({
          accountId: book.glAccountId, debitAmount: balanceReturned, creditAmount: 0,
          currencyCode, exchangeRate,
        });
      }
      if (totalAllocated > 0) {
        details.push({
          accountId: advanceParam.glAccountId, debitAmount: 0, creditAmount: totalAllocated,
          currencyCode, exchangeRate,
        });
      }
      if (balanceClaimed > 0) {
        details.push({
          accountId: book.glAccountId, debitAmount: 0, creditAmount: balanceClaimed,
          currencyCode, exchangeRate,
        });
      }

      const glTransactionId = await postGl(trx, {
        tenantId: s.tenantId, companyId: s.companyId,
        docType: DOC, txnType: DOC, docNo: s.docNo,
        txnDate: s.settlementDate,
        reference: `PSET/${s.docNo}`,
        description: `Settlement PSET/${s.docNo}`,
        updatedBy: data.userId,
        details,
      });

      // Consume the linked petty cash request. Its expenses just posted via
      // this settlement, so it must never also be paid in cash. Deliberately
      // does NOT store the GL id on the voucher: voucher.cancel voids by
      // glTransactionId, which would void this settlement's posting.
      if (voucher) {
        await trx('pc_txn_voucher').where({ voucherId: voucher.voucherId }).update({
          status: 'Settled',
          updatedBy: data.userId ?? null,
          updatedAt: new Date(),
        });
      }

      // Apply allocations: bump settledAmount per IOU, close fully settled ones.
      for (const a of allocations) {
        const newSettled = round2(Number(a.iou.settledAmount || 0) + a.amount);
        const iouUpdate = { settledAmount: newSettled, updatedBy: data.userId, updatedAt: new Date() };
        if (newSettled >= Number(a.iou.requestAmount || 0)) {
          iouUpdate.status = 'Settled';
        }
        await trx('pc_txn_iou').where({ iouId: a.iou.iouId }).update(iouUpdate);
      }

      await trx(TABLE).where({ settlementId: s.settlementId }).update({
        status: 'Cleared',
        accountantClearedBy: data.userId ?? null,
        clearedAt: new Date(),
        glTransactionId,
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });

      return repo.get({ id: s.settlementId }, trx);
    });
  },

  async cancel(data) {
    return db.transaction(async (trx) => {
      const s = await trx(TABLE).where({ settlementId: data.id }).first();
      if (!s) throw new AppError('Not found', 404);
      if (s.status === 'Cancelled') return 'success';

      const ctx = { tenantId: s.tenantId, companyId: s.companyId, userId: data.userId };
      const wfState = await workflow.getState(DOC, data.id, trx);
      if (wfState && wfState.status === workflow.WF_STATUS.PENDING) {
        await workflow.act(trx, ctx, { docType: DOC, docId: data.id, action: workflow.WF_ACTION.CANCEL });
      }

      await snapshotBefore(trx, TABLE, { settlementId: s.settlementId }, data.userId, 'CANCEL');

      if (s.status === 'Cleared' && s.glTransactionId) {
        const allocRows = await trx(ALLOC).where({ settlementId: s.settlementId });

        if (allocRows.length) {
          // Reverse each IOU by its exact allocation.
          for (const a of allocRows) {
            const iou = await trx('pc_txn_iou').where({ iouId: a.iouId }).first();
            if (!iou) continue;
            const newSettled = round2(Number(iou.settledAmount || 0) - Number(a.allocatedAmount || 0));
            await trx('pc_txn_iou').where({ iouId: a.iouId }).update({
              settledAmount: Math.max(newSettled, 0),
              status: 'Paid',
              updatedBy: data.userId,
              updatedAt: new Date(),
            });
          }
        } else if (s.iouId) {
          // Legacy single-IOU settlement without allocation rows.
          const iou = await trx('pc_txn_iou').where({ iouId: s.iouId }).first();
          if (iou) {
            const advanceCleared = round2(Number(s.totalBills || 0) + Number(s.balanceReturned || 0) - Number(s.balanceClaimed || 0));
            const newSettled = round2(Number(iou.settledAmount || 0) - advanceCleared);
            await trx('pc_txn_iou').where({ iouId: s.iouId }).update({
              settledAmount: Math.max(newSettled, 0),
              status: 'Paid',
              updatedBy: data.userId,
              updatedAt: new Date(),
            });
          }
        }

        await voidGl(trx, s.glTransactionId, data.userId);

        // Release the consumed petty cash request back to Draft.
        if (s.voucherId) {
          await trx('pc_txn_voucher')
            .where({ voucherId: s.voucherId, status: 'Settled' })
            .update({ status: 'Draft', updatedBy: data.userId ?? null, updatedAt: new Date() });
        }
      }

      await trx(TABLE).where({ settlementId: s.settlementId }).update({
        status: 'Cancelled',
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      return 'success';
    });
  },
};

async function insertLines(trx, settlementId, companyId, lines) {
  let lineNo = 0;
  for (const l of lines) {
    lineNo += 1;
    await trx(DETAIL).insert({
      ...pickFields(l, LINE_FIELDS),
      settlementId,
      companyId,
      lineNo,
    });
  }
}

module.exports = repo;
