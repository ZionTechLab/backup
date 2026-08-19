const crypto = require('crypto');
const db = require('../../../database');
const { getNextSerialNo } = require('../../../repository/getNextSerialNo');
const { snapshotBefore, snapshotInsert } = require('../../../repository/auditHistory');
const { pickFields } = require('../../../repository/pickFields');
const { postGl, voidGl, round2 } = require('../../../repository/glPosting');
const workflow = require('../../../repository/workflow');
const { AppError } = require('../../../middleware/errorHandler');

const TABLE = 'pc_txn_iou';
const AUDIT_TABLE = 'pc_log_iouAudit';
const DOC = 'PIOU';

const FIELDS = ['cashBookId', 'partyType', 'partyId', 'purpose', 'requestAmount',
  'expectedSettlementDate', 'jobPoRef', 'supportingDocPath', 'paymentMode',
  'voucherRef', 'paidDate', 'paidByCashierId', 'currencyCode', 'exchangeRate', 'remarks', 'iouRequestId',
  'branchOrgUnitId', 'iouDate'];

// Denormalized inbox label for the workflow engine. docNo is the human number;
// summary a short one-line description. row needs partyType, partyId,
// requestAmount and docNo (the serial).
async function buildDisplay(trx, row) {
  let partyName = '';
  if (row.partyId) {
    const p = await trx('mas_businessPartner').where({ businessPartnerId: row.partyId }).first('partnerName');
    partyName = p ? p.partnerName : '';
  }
  const amt = row.requestAmount != null ? Number(row.requestAmount).toLocaleString() : '';
  const summary = [row.partyType, amt, partyName].filter(Boolean).join(' | ');
  return { docNo: `PIOU/${row.docNo}`, summary };
}

const repo = {
  async getUi(ctx = {}) {
    const cashBooks = await db('pc_mas_cashBook')
      .select('cashBookId', 'code', 'name', 'currencyCode', 'glAccountId')
      .where({ tenantId: ctx.tenantId, companyId: ctx.companyId, isActive: true, deleted: false })
      .orderBy('code');
    const parties = await db('mas_businessPartner')
      .select('businessPartnerId', 'partnerName')
      .orderBy('partnerName');
    const branches = await db('mas_orgUnit')
      .select('orgUnitId', 'code', 'name')
      .where({ unitType: 'Branch', isActive: true, deleted: false, companyId: ctx.companyId })
      .orderBy('name');
    const approvers = await db('mas_users').select('userId', 'fullName').orderBy('fullName');
    const currencies = await db('sec_currencies')
      .select('currencyCode', 'currencyName', 'symbol')
      .where({ isActive: true })
      .orderBy('currencyCode');
    const partyTypes = [
      { value: 'Employee', label: 'Employee' },
      { value: 'Contractor', label: 'Contractor' },
      { value: 'Supplier', label: 'Supplier' },
      { value: 'Customer', label: 'Customer' },
      { value: 'ThirdParty', label: 'Third Party' },
    ];

    // Business-rule toggle: does an IOU have to originate from an Approved
    // IOU Request, or can it be created directly? Configured via the Param
    // screen (paramGroup IOU_LIMIT, key REQUIRE_REQUEST). Default: allowed.
    const requireParam = await db('pc_ref_param')
      .where({ companyId: ctx.companyId, paramGroup: 'IOU_LIMIT', paramKey: 'REQUIRE_REQUEST', isActive: true, deleted: false })
      .first();
    const requireIouRequest = !!(requireParam && requireParam.numValue === 1);

    return { cashBooks, parties, branches, approvers, currencies, partyTypes, requireIouRequest };
  },

  // Approved requests with remaining balance. A request keeps appearing here
  // across multiple partial issues until its (possibly revised) approved
  // amount is fully drawn or it's manually Closed.
  async getApprovedRequests(ctx = {}) {
    const requests = await db('pc_txn_iouRequest')
      .select('iouRequestId', 'docNo', 'partyType', 'partyId', 'requestAmount', 'confirmedAmount', 'approvedAmount',
        'purpose', 'expectedSettlementDate', 'jobPoRef', 'branchOrgUnitId', 'departmentOrgUnitId', 'sectionOrgUnitId',
        'currencyCode')
      .where({ tenantId: ctx.tenantId, companyId: ctx.companyId, status: 'Approved' })
      .orderBy('docNo');
    if (!requests.length) return requests;

    const requestIds = requests.map((r) => r.iouRequestId);
    const issuedRows = await db('pc_txn_iou')
      .whereIn('iouRequestId', requestIds)
      .whereNotIn('status', ['Cancelled', 'Rejected', 'Approval Rejected'])
      .select('iouRequestId')
      .sum('requestAmount as total')
      .groupBy('iouRequestId');
    const issuedMap = Object.fromEntries(issuedRows.map((r) => [r.iouRequestId, round2(Number(r.total || 0))]));

    const docs = await db('pc_txn_iouRequestDoc').whereIn('iouRequestId', requestIds).orderBy(['iouRequestId', 'lineNo']);

    const orgUnitIds = [...new Set(requests.flatMap((r) => [r.branchOrgUnitId, r.departmentOrgUnitId, r.sectionOrgUnitId]).filter(Boolean))];
    const orgUnits = orgUnitIds.length
      ? await db('mas_orgUnit').whereIn('orgUnitId', orgUnitIds).select('orgUnitId', 'name')
      : [];
    const orgUnitName = (id) => orgUnits.find((o) => o.orgUnitId === id)?.name || null;

    for (const r of requests) {
      const issued = issuedMap[r.iouRequestId] || 0;
      const ceiling = Number(r.approvedAmount ?? r.confirmedAmount ?? r.requestAmount);
      r.issuedAmount = issued;
      r.remaining = round2(ceiling - issued);
      r.docs = docs.filter((d) => d.iouRequestId === r.iouRequestId);
      r.branchName = orgUnitName(r.branchOrgUnitId);
      r.departmentName = orgUnitName(r.departmentOrgUnitId);
      r.sectionName = orgUnitName(r.sectionOrgUnitId);
    }
    return requests.filter((r) => r.remaining > 0);
  },

  async getAll(filters = {}) {
    return db(`${TABLE} as i`)
      .select(
        'i.iouId', 'i.docNo', 'i.iouDate', 'i.cashBookId', 'i.partyType', 'i.partyId',
        'i.requestAmount', 'i.status', 'i.expectedSettlementDate',
        'cb.code as cashBookCode',
        'bp.partnerName as partyName',
        db.raw("'PIOU/' || i.docNo as iouNo")
      )
      .leftJoin('pc_mas_cashBook as cb', 'cb.cashBookId', 'i.cashBookId')
      .leftJoin('mas_businessPartner as bp', 'bp.businessPartnerId', 'i.partyId')
      .where({ 'i.tenantId': filters.tenantId, 'i.companyId': filters.companyId })
      .orderBy([{ column: 'i.docNo', order: 'desc' }]);
  },

  // conn defaults to db; pass a trx when called inside a transaction.
  async get(filters = {}, conn = db) {
    const row = await conn(TABLE).where({ iouId: filters.id }).first();
    if (!row) return null;
    const audits = await conn(AUDIT_TABLE)
      .select('pc_log_iouAudit.*', 'u.fullName as auditorName')
      .leftJoin('mas_users as u', 'u.userId', 'pc_log_iouAudit.auditorUserId')
      .where({ 'pc_log_iouAudit.iouId': filters.id })
      .orderBy('pc_log_iouAudit.auditedAt', 'desc');
    const docs = await conn('pc_txn_iouDoc').where({ iouId: filters.id }).orderBy('lineNo');
    const approval = await workflow.getHistory(DOC, filters.id, conn);
    return { ...row, audits, docs, approval };
  },

  async update(data) {
    return db.transaction(async (trx) => {
      if (data.isUpdate) {
        const existing = await trx(TABLE).where({ iouId: data.iouId }).first();
        if (!existing) throw new AppError('Not found', 404);
        if (existing.status !== 'Draft') throw new AppError('Only draft IOUs can be edited', 409);

        const fields = pickFields(data, FIELDS);
        if (!fields.paymentMode) fields.paymentMode = null;
        await snapshotBefore(trx, TABLE, { iouId: data.iouId }, data.userId, 'UPDATE');
        await trx(TABLE).where({ iouId: data.iouId }).update({
          ...fields,
          requestedByUserId: data.userId ?? null,
          updatedBy: data.userId ?? null,
          updatedAt: new Date(),
        });
        await replaceDocs(trx, data.iouId, data.companyId, data.docs);

        // Heal drafts created while approval was switched off before the
        // engine handled that case: no workflow state exists, so start it now
        // (auto-approves when no active levels).
        const state = await workflow.getState(DOC, data.iouId, trx);
        if (!state) {
          const display = await buildDisplay(trx, { partyType: fields.partyType, partyId: fields.partyId, requestAmount: fields.requestAmount, docNo: existing.docNo });
          const wfState = await workflow.start(
            trx, { tenantId: existing.tenantId, companyId: existing.companyId, userId: data.userId },
            DOC, data.iouId, fields.requestAmount, display,
          );
          if (wfState?.autoApproved) {
            await trx(TABLE).where({ iouId: data.iouId }).update({
              status: 'Approved',
              approvedAmount: fields.requestAmount,
              approvedAt: new Date(),
            });
          }
        }
        return repo.get({ id: data.iouId }, trx);
      }

      // Block rule: reject if the party already has an open IOU (when param enabled).
      const blockParam = await trx('pc_ref_param')
        .where({ companyId: data.companyId, paramGroup: 'IOU_LIMIT', paramKey: 'BLOCK_MULTIPLE', isActive: true, deleted: false })
        .first();
      if (blockParam && blockParam.numValue === 1) {
        const openIou = await trx(TABLE)
          .where({ companyId: data.companyId, partyId: data.partyId })
          .whereNotIn('status', ['Settled', 'Cancelled'])
          .first();
        if (openIou) {
          throw new AppError('This party already has an open IOU that is not settled or cancelled.', 409);
        }
      }

      // Require-request rule: reject direct creation when the company mandates
      // that every IOU originate from an Approved IOU Request.
      const requireParam = await trx('pc_ref_param')
        .where({ companyId: data.companyId, paramGroup: 'IOU_LIMIT', paramKey: 'REQUIRE_REQUEST', isActive: true, deleted: false })
        .first();
      if (requireParam && requireParam.numValue === 1 && !data.iouRequestId) {
        throw new AppError('An approved IOU Request must be linked to create an IOU.', 400);
      }

      const docNo = await getNextSerialNo(trx, DOC, DOC);
      const iouId = crypto.randomUUID();
      const fields = pickFields(data, FIELDS);
      if (!fields.paymentMode) fields.paymentMode = null;
      await trx(TABLE).insert({
        ...fields,
        iouId,
        tenantId: data.tenantId,
        companyId: data.companyId,
        docType: DOC,
        txnType: DOC,
        docNo,
        status: 'Draft',
        iouDate: fields.iouDate || new Date().toISOString().split('T')[0],
        requestedByUserId: data.userId ?? null,
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      await snapshotInsert(trx, TABLE, { iouId }, data.userId);

      // When issued against a request: this may be one of several partial
      // issues, so validate against what's left rather than the whole
      // approved amount, then close the request only once fully drawn.
      if (fields.iouRequestId) {
        const reqRow = await trx('pc_txn_iouRequest').where({ iouRequestId: fields.iouRequestId }).first();
        if (reqRow && reqRow.status === 'Approved') {
          // This IOU row was already inserted above, so exclude it here —
          // otherwise it would be counted against its own remaining balance.
          const issuedRow = await trx('pc_txn_iou')
            .where({ iouRequestId: fields.iouRequestId })
            .whereNot({ iouId })
            .whereNotIn('status', ['Cancelled', 'Rejected', 'Approval Rejected'])
            .sum('requestAmount as total')
            .first();
          const alreadyIssued = round2(Number(issuedRow?.total || 0));
          const ceiling = Number(reqRow.approvedAmount ?? reqRow.confirmedAmount ?? reqRow.requestAmount);
          const remaining = round2(ceiling - alreadyIssued);
          if (round2(Number(fields.requestAmount)) > remaining) {
            throw new AppError(`Issue amount exceeds the remaining approved balance of ${remaining} on this request`, 409);
          }
          if (remaining - round2(Number(fields.requestAmount)) <= 0) {
            await trx('pc_txn_iouRequest').where({ iouRequestId: fields.iouRequestId }).update({
              status: 'Settled',
              updatedBy: data.userId ?? null,
              updatedAt: new Date(),
            });
          }
        }
      }

      await replaceDocs(trx, iouId, data.companyId, data.docs);

      // Enter the approval workflow at its first configured level. With no
      // active level for this docType (approval switched off), the engine
      // auto-approves and the IOU goes straight to Approved, ready to pay.
      const display = await buildDisplay(trx, { partyType: fields.partyType, partyId: fields.partyId, requestAmount: fields.requestAmount, docNo });
      const wfState = await workflow.start(
        trx,
        { tenantId: data.tenantId, companyId: data.companyId, userId: data.userId },
        DOC, iouId, fields.requestAmount, display,
      );
      if (wfState?.autoApproved) {
        await trx(TABLE).where({ iouId }).update({
          status: 'Approved',
          approvedAmount: fields.requestAmount,
          approvedAt: new Date(),
        });
      }

      return repo.get({ id: iouId }, trx);
    });
  },

  // Unified workflow action. The current level decides whether this is the
  // confirm step or the approve step, and sets the matching status and amount.
  //   action: Approve, Reject, OnHold
  async act(data) {
    return db.transaction(async (trx) => {
      const row = await trx(TABLE).where({ iouId: data.id }).first();
      if (!row) throw new AppError('Not found', 404);
      if (['Paid', 'Fully Settled', 'Cancelled', 'Rejected', 'Approval Rejected'].includes(row.status)) {
        throw new AppError('IOU is closed and cannot be actioned', 409);
      }
      const ctx = { tenantId: row.tenantId, companyId: row.companyId, userId: data.userId };
      const state = await workflow.getState(DOC, data.id, trx);
      if (!state) throw new AppError('No approval flow for this IOU', 400);
      const level = state.currentLevel;

      await snapshotBefore(trx, TABLE, { iouId: data.id }, data.userId, 'UPDATE');
      const display = await buildDisplay(trx, row);
      await workflow.act(trx, ctx, {
        docType: DOC, docId: data.id, action: data.action,
        amount: row.requestAmount, comment: null, onHoldUntil: null, ...display,
      });

      const now = new Date();
      const updates = { updatedBy: data.userId ?? null, updatedAt: now };
      if (data.action === 'Reject') {
        updates.status = level === 1 ? 'Rejected' : 'Approval Rejected';
      } else if (data.action === 'OnHold') {
        updates.status = level === 1 ? 'On-Hold' : 'Approval On-Hold';
      } else { // Approve
        if (level === 1) {
          updates.status = 'Confirmed';
          updates.confirmedAmount = row.requestAmount;
          updates.certifiedBy = data.userId ?? null;
          updates.certifiedAt = now;
        } else {
          updates.status = 'Approved';
          updates.approvedAmount = row.requestAmount;
          updates.approvedBy = data.userId ?? null;
          updates.approvedAt = now;
        }
      }
      await trx(TABLE).where({ iouId: data.id }).update(updates);
      return repo.get({ id: data.id }, trx);
    });
  },

  // Backward-compatible wrappers. The workflow level decides which status
  // transition applies; action labels the log entry distinctly.
  async certify(data) { return repo.act({ ...data, action: 'Certify' }); },
  async approve(data) { return repo.act({ ...data, action: 'Approve' }); },

  async pay(data) {
    return db.transaction(async (trx) => {
      const iou = await trx(TABLE).where({ iouId: data.id }).first();
      if (!iou) throw new AppError('Not found', 404);
      if (iou.status !== 'Approved') throw new AppError('Only approved IOUs can be paid', 409);

      // Resolve advance GL account from pc_ref_param.
      const advanceParam = await trx('pc_ref_param')
        .where({
          companyId: iou.companyId,
          paramGroup: 'ADVANCE_GL',
          paramKey: iou.partyType,
          isActive: true,
          deleted: false,
        })
        .first();
      if (!advanceParam || !advanceParam.glAccountId) {
        throw new AppError(`No advance GL account configured for ${iou.partyType}`, 400);
      }

      const book = await trx('pc_mas_cashBook').where({ cashBookId: iou.cashBookId }).first();
      if (!book) throw new AppError('Cash book not found', 404);

      const amount = round2(Number(iou.requestAmount || 0));
      const rate = Number(iou.exchangeRate || 1);

      const details = [
        {
          accountId: advanceParam.glAccountId,
          debitAmount: amount,
          creditAmount: 0,
          currencyCode: iou.currencyCode,
          exchangeRate: rate,
        },
        {
          accountId: book.glAccountId,
          debitAmount: 0,
          creditAmount: amount,
          currencyCode: iou.currencyCode,
          exchangeRate: rate,
        },
      ];

      const paidDate = data.paidDate || new Date().toISOString().split('T')[0];

      const glTransactionId = await postGl(trx, {
        tenantId: iou.tenantId,
        companyId: iou.companyId,
        docType: DOC,
        txnType: DOC,
        docNo: iou.docNo,
        txnDate: paidDate,
        reference: `PIOU/${iou.docNo}`,
        description: iou.purpose || `IOU ${iou.docNo}`,
        updatedBy: data.userId,
        details,
      });

      await trx(TABLE).where({ iouId: iou.iouId }).update({
        status: 'Paid',
        paidByCashierId: data.userId ?? null,
        paidDate,
        glTransactionId,
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      return repo.get({ id: iou.iouId }, trx);
    });
  },

  async cancel(data) {
    return db.transaction(async (trx) => {
      const row = await trx(TABLE).where({ iouId: data.id }).first();
      if (!row) throw new AppError('Not found', 404);
      if (row.status === 'Settled') throw new AppError('Cannot cancel a settled IOU', 409);
      if (row.status === 'Cancelled') return 'success';
      await snapshotBefore(trx, TABLE, { iouId: data.id }, data.userId, 'CANCEL');
      if (row.glTransactionId) await voidGl(trx, row.glTransactionId, data.userId);
      await trx(TABLE).where({ iouId: data.id }).update({
        status: 'Cancelled',
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      return 'success';
    });
  },

  async addAudit(data) {
    const auditLogId = crypto.randomUUID();
    await db(AUDIT_TABLE).insert({
      auditLogId,
      tenantId: data.tenantId,
      companyId: data.companyId,
      iouId: data.iouId,
      auditorUserId: data.userId,
      auditorRole: data.auditorRole ?? null,
      comment: data.comment ?? null,
      auditedAt: new Date(),
    });
    return db(AUDIT_TABLE).where({ auditLogId }).first();
  },
};

// Replace the IOU's document rows. Up to 5, each { filePath, comment }.
async function replaceDocs(trx, iouId, companyId, docs) {
  await trx('pc_txn_iouDoc').where({ iouId }).del();
  const rows = (Array.isArray(docs) ? docs : [])
    .filter((d) => d && d.filePath)
    .slice(0, 5)
    .map((d, i) => ({ iouId, companyId, lineNo: i + 1, filePath: d.filePath, comment: d.comment || null }));
  if (rows.length) await trx('pc_txn_iouDoc').insert(rows);
}

module.exports = repo;

