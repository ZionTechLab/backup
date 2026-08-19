const crypto = require('crypto');
const db = require('../../../database');
const { getNextSerialNo } = require('../../../repository/getNextSerialNo');
const { snapshotBefore, snapshotInsert } = require('../../../repository/auditHistory');
const { pickFields } = require('../../../repository/pickFields');
const { round2 } = require('../../../repository/glPosting');
const workflow = require('../../../repository/workflow');
const { AppError } = require('../../../middleware/errorHandler');

const TABLE = 'pc_txn_iouRequest';
const DOC = 'PREQ';

const FIELDS = ['partyType', 'partyId', 'purpose', 'requestAmount',
  'expectedSettlementDate', 'iouDate', 'jobPoRef', 'supportingDocPath', 'remarks',
  'branchOrgUnitId', 'departmentOrgUnitId', 'sectionOrgUnitId', 'currencyCode'];

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
  return { docNo: `PREQ/${row.docNo}`, summary };
}

// Sum of IOUs already issued against a request. Cancelled/Rejected IOUs never
// drew against the approved amount, so they don't count. Everything else
// (Draft through Settled) does, since it has reserved part of the balance.
async function getIssuedTotal(conn, iouRequestId) {
  const row = await conn('pc_txn_iou')
    .where({ iouRequestId })
    .whereNotIn('status', ['Cancelled', 'Rejected', 'Approval Rejected'])
    .sum('requestAmount as total')
    .first();
  return round2(Number(row?.total || 0));
}

const repo = {
  async getUi(ctx = {}) {
    const parties = await db('mas_businessPartner')
      .select('businessPartnerId', 'partnerName')
      .orderBy('partnerName');
    const partyTypes = [
      { value: 'Employee', label: 'Employee' },
      { value: 'Contractor', label: 'Contractor' },
      { value: 'Supplier', label: 'Supplier' },
      { value: 'Customer', label: 'Customer' },
      { value: 'ThirdParty', label: 'Third Party' },
    ];
    const orgUnitsOf = (unitType) => db('mas_orgUnit')
      .select('orgUnitId', 'code', 'name', 'parentId')
      .where({ unitType, isActive: true, deleted: false, companyId: ctx.companyId })
      .orderBy('name');
    const branches = await orgUnitsOf('Branch');
    const departments = await orgUnitsOf('Department');
    const sections = await orgUnitsOf('Section');
    const currencies = await db('sec_currencies')
      .select('currencyCode', 'currencyName', 'symbol')
      .where({ isActive: true })
      .orderBy('currencyCode');
    return { parties, partyTypes, branches, departments, sections, currencies };
  },

  async getAll(filters = {}) {
    const q = db(`${TABLE} as r`)
      .select(
        'r.iouRequestId', 'r.docNo', 'r.iouDate', 'r.partyType', 'r.partyId',
        'r.requestAmount', 'r.expectedSettlementDate', 'r.status',
        'bp.partnerName as partyName',
        db.raw("'PREQ/' || r.docNo as requestNo")
      )
      .leftJoin('mas_businessPartner as bp', 'bp.businessPartnerId', 'r.partyId')
      .where({ 'r.tenantId': filters.tenantId, 'r.companyId': filters.companyId })
      .orderBy([{ column: 'r.docNo', order: 'desc' }]);
    if (filters.mine) q.where('r.requestedByUserId', filters.userId);
    return q;
  },

  // conn defaults to db; pass a trx when called inside a transaction to avoid a
  // pool deadlock (the open write trx holds a connection on SQLite).
  async get(filters = {}, conn = db) {
    const row = await conn(TABLE).where({ iouRequestId: filters.id }).first();
    if (!row) return null;
    const docs = await conn('pc_txn_iouRequestDoc').where({ iouRequestId: filters.id }).orderBy('lineNo');
    const approval = await workflow.getHistory(DOC, filters.id, conn);
    const state = await workflow.getState(DOC, filters.id, conn);
    const issuedAmount = await getIssuedTotal(conn, filters.id);
    const ceiling = Number(row.approvedAmount ?? row.confirmedAmount ?? row.requestAmount ?? 0);

    const party = row.partyId ? await conn('mas_businessPartner').where({ businessPartnerId: row.partyId }).first('partnerName') : null;
    const orgUnitIds = [row.branchOrgUnitId, row.departmentOrgUnitId, row.sectionOrgUnitId].filter(Boolean);
    const orgUnits = orgUnitIds.length ? await conn('mas_orgUnit').whereIn('orgUnitId', orgUnitIds).select('orgUnitId', 'name') : [];
    const orgUnitName = (id) => orgUnits.find((o) => o.orgUnitId === id)?.name || null;

    return {
      ...row, docs, approval, issuedAmount,
      remaining: round2(ceiling - issuedAmount),
      partyName: party ? party.partnerName : null,
      branchName: orgUnitName(row.branchOrgUnitId),
      departmentName: orgUnitName(row.departmentOrgUnitId),
      sectionName: orgUnitName(row.sectionOrgUnitId),
      workflowStatus: state ? state.status : null,
      workflowLevel: state ? state.currentLevel : null,
    };
  },

  async update(data) {
    // Validate advance limit from pc_ref_param (applies to both create & update).
    const limitParam = await db('pc_ref_param')
      .where({ companyId: data.companyId, paramGroup: 'ADVANCE_LIMIT', paramKey: data.partyType, deleted: false, isActive: true })
      .first();
    if (limitParam && limitParam.numValue != null) {
      if (Number(data.requestAmount) > Number(limitParam.numValue)) {
        throw new AppError(`Request amount exceeds the ${data.partyType} advance limit of ${limitParam.numValue}`, 400);
      }
    }

    return db.transaction(async (trx) => {
      if (data.isUpdate) {
        const existing = await trx(TABLE).where({ iouRequestId: data.iouRequestId }).first();
        if (!existing) throw new AppError('Not found', 404);
        if (existing.status !== 'Draft') throw new AppError('Only draft requests can be edited', 409);

        const fields = pickFields(data, FIELDS);
        await snapshotBefore(trx, TABLE, { iouRequestId: data.iouRequestId }, data.userId, 'UPDATE');
        await trx(TABLE).where({ iouRequestId: data.iouRequestId }).update({
          ...fields,
          requestedByUserId: data.userId ?? null,
          updatedBy: data.userId ?? null,
          updatedAt: new Date(),
        });
        await replaceDocs(trx, data.iouRequestId, data.companyId, data.docs);

        // Heal drafts created while approval was switched off before the
        // engine handled that case: no workflow state exists, so start it now
        // (auto-approves when no active levels).
        const state = await workflow.getState(DOC, data.iouRequestId, trx);
        if (!state) {
          const display = await buildDisplay(trx, { partyType: data.partyType, partyId: data.partyId, requestAmount: data.requestAmount, docNo: existing.docNo });
          const wfState = await workflow.start(
            trx, { tenantId: existing.tenantId, companyId: existing.companyId, userId: data.userId },
            DOC, data.iouRequestId, data.requestAmount, display
          );
          if (wfState?.autoApproved) {
            await trx(TABLE).where({ iouRequestId: data.iouRequestId }).update({
              status: 'Approved',
              approvedAmount: data.requestAmount,
              approvedAt: new Date(),
            });
          }
        }
        return repo.get({ id: data.iouRequestId }, trx);
      }

      const docNo = await getNextSerialNo(trx, DOC, DOC);
      const iouRequestId = crypto.randomUUID();
      const fields = pickFields(data, FIELDS);
      // Request date is a stamp, not user-entered: always today at creation.
      fields.iouDate = new Date().toISOString().split('T')[0];
      await trx(TABLE).insert({
        ...fields,
        iouRequestId,
        tenantId: data.tenantId,
        companyId: data.companyId,
        docType: DOC,
        txnType: DOC,
        docNo,
        status: 'Draft',
        requestedByUserId: data.userId ?? null,
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      await snapshotInsert(trx, TABLE, { iouRequestId }, data.userId);
      await replaceDocs(trx, iouRequestId, data.companyId, data.docs);
      // Open the approval flow on the central engine. With no active level
      // configured, the engine auto-approves and the request goes straight to
      // Approved, immediately issuable.
      const display = await buildDisplay(trx, { partyType: data.partyType, partyId: data.partyId, requestAmount: data.requestAmount, docNo });
      const wfState = await workflow.start(
        trx,
        { tenantId: data.tenantId, companyId: data.companyId, userId: data.userId },
        DOC, iouRequestId, data.requestAmount, display
      );
      if (wfState?.autoApproved) {
        await trx(TABLE).where({ iouRequestId }).update({
          status: 'Approved',
          approvedAmount: data.requestAmount,
          approvedAt: new Date(),
        });
      }
      return repo.get({ id: iouRequestId }, trx);
    });
  },

  // Unified workflow action for the dedicated Approval/Rejection screen. The
  // current level decides whether this is the Confirm step or the Approve
  // step. Approve may revise the amount (stored per level; the original
  // requestAmount is never touched) — a comment is required whenever the
  // amount is actually changed from that level's baseline. Reject always
  // requires a comment, which doubles as rejectReason.
  async act(data) {
    return db.transaction(async (trx) => {
      const row = await trx(TABLE).where({ iouRequestId: data.id }).first();
      if (!row) throw new AppError('Not found', 404);
      if (!['Draft', 'Certified'].includes(row.status)) {
        throw new AppError('Only draft or certified requests can be actioned', 409);
      }
      const ctx = { tenantId: row.tenantId, companyId: row.companyId, userId: data.userId };
      const state = await workflow.getState(DOC, data.id, trx);
      if (!state) throw new AppError('No approval flow for this request', 400);
      const level = state.currentLevel;

      if (data.action === workflow.WF_ACTION.REJECT) {
        if (!data.comment || !data.comment.trim()) {
          throw new AppError('A comment is required to reject.', 400);
        }
        await snapshotBefore(trx, TABLE, { iouRequestId: data.id }, data.userId, 'REJECT');
        const display = await buildDisplay(trx, row);
        await workflow.act(trx, ctx, {
          docType: DOC, docId: data.id, action: workflow.WF_ACTION.REJECT,
          amount: row.requestAmount, comment: data.comment, ...display,
        });
        await trx(TABLE).where({ iouRequestId: data.id }).update({
          status: 'Rejected',
          rejectedBy: data.userId ?? null,
          rejectedAt: new Date(),
          rejectReason: data.comment,
          updatedBy: data.userId ?? null,
          updatedAt: new Date(),
        });
        return repo.get({ id: data.id }, trx);
      }

      // Approve at this level. Baseline is what this level revises from: the
      // original ask at level 1, the level-1 revision at level 2.
      const baseline = round2(Number(level === 1 ? row.requestAmount : (row.confirmedAmount ?? row.requestAmount)));
      const amount = data.amount != null ? round2(Number(data.amount)) : baseline;
      if (amount <= 0) throw new AppError('Amount must be greater than zero', 400);
      if (amount !== baseline && (!data.comment || !data.comment.trim())) {
        throw new AppError('A comment is required when overriding the amount.', 400);
      }

      await snapshotBefore(trx, TABLE, { iouRequestId: data.id }, data.userId, 'UPDATE');
      const display = await buildDisplay(trx, { ...row, requestAmount: amount });
      await workflow.act(trx, ctx, {
        docType: DOC, docId: data.id, action: workflow.WF_ACTION.APPROVE,
        amount, comment: data.comment ?? null, ...display,
      });

      const now = new Date();
      const updates = { updatedBy: data.userId ?? null, updatedAt: now };
      if (level === 1) {
        updates.status = 'Certified';
        updates.confirmedAmount = amount;
        updates.certifiedBy = data.userId ?? null;
        updates.certifiedAt = now;
      } else {
        updates.status = 'Approved';
        updates.approvedAmount = amount;
        updates.approvedBy = data.userId ?? null;
        updates.approvedAt = now;
      }
      await trx(TABLE).where({ iouRequestId: data.id }).update(updates);
      return repo.get({ id: data.id }, trx);
    });
  },

  // Manual early close: stops further issuing against an Approved request
  // even though its approved amount hasn't been fully drawn.
  async close(data) {
    return db.transaction(async (trx) => {
      const row = await trx(TABLE).where({ iouRequestId: data.id }).first();
      if (!row) throw new AppError('Not found', 404);
      if (row.status !== 'Approved') throw new AppError('Only approved requests can be closed', 409);
      await snapshotBefore(trx, TABLE, { iouRequestId: data.id }, data.userId, 'CLOSE');
      await trx(TABLE).where({ iouRequestId: data.id }).update({
        status: 'Closed',
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      return repo.get({ id: data.id }, trx);
    });
  },

  async cancel(data) {
    return db.transaction(async (trx) => {
      const row = await trx(TABLE).where({ iouRequestId: data.id }).first();
      if (!row) throw new AppError('Not found', 404);
      if (['Settled', 'Closed'].includes(row.status)) throw new AppError('Cannot cancel a settled or closed request', 409);
      if (row.status === 'Cancelled') return 'success';
      const ctx = { tenantId: row.tenantId, companyId: row.companyId, userId: data.userId };
      await snapshotBefore(trx, TABLE, { iouRequestId: data.id }, data.userId, 'CANCEL');
      const state = await workflow.getState(DOC, data.id, trx);
      if (state && state.status === 'Pending') {
        await workflow.act(trx, ctx, { docType: DOC, docId: data.id, action: workflow.WF_ACTION.CANCEL, amount: row.requestAmount });
      }
      await trx(TABLE).where({ iouRequestId: data.id }).update({
        status: 'Cancelled',
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      return 'success';
    });
  },

  // Approved requests with remaining balance, offerable to the IOU Issue
  // picker. A request keeps appearing here across multiple partial issues
  // until its (possibly revised) approved amount is fully drawn or it's
  // manually Closed.
  async getApproved(filters = {}) {
    const rows = await db(TABLE)
      .select('iouRequestId', 'docNo', 'partyType', 'partyId', 'requestAmount', 'confirmedAmount', 'approvedAmount',
        'purpose', 'expectedSettlementDate', 'jobPoRef', 'branchOrgUnitId', 'departmentOrgUnitId', 'sectionOrgUnitId',
        'currencyCode')
      .where({ tenantId: filters.tenantId, companyId: filters.companyId, status: 'Approved' })
      .orderBy('docNo');
    for (const r of rows) {
      const issued = await getIssuedTotal(db, r.iouRequestId);
      const ceiling = Number(r.approvedAmount ?? r.confirmedAmount ?? r.requestAmount);
      r.issuedAmount = issued;
      r.remaining = round2(ceiling - issued);
    }
    return rows.filter((r) => r.remaining > 0);
  },
};

// Replace all attachments for a request. Up to five files, each optional
// comment. Mirrors the IOU issue's replaceDocs.
async function replaceDocs(trx, iouRequestId, companyId, docs) {
  await trx('pc_txn_iouRequestDoc').where({ iouRequestId }).del();
  const rows = (Array.isArray(docs) ? docs : [])
    .filter((d) => d && d.filePath)
    .slice(0, 5)
    .map((d, i) => ({ iouRequestId, companyId, lineNo: i + 1, filePath: d.filePath, comment: d.comment || null }));
  if (rows.length) await trx('pc_txn_iouRequestDoc').insert(rows);
}

module.exports = repo;
