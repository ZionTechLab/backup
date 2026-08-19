const db = require('../database');
const { AppError } = require('../middleware/errorHandler');

const CFG = 'wf_levelConfig';
const STATE = 'wf_approvalState';
const LOG = 'wf_approvalLog';

// The single source of truth for workflow vocabulary. Values are stored as-is
// (human-readable strings). Use these constants instead of string literals.
const WF_ACTION = Object.freeze({
  APPROVE: 'Approve',
  CONFIRM: 'Confirm',
  REJECT: 'Reject',
  ON_HOLD: 'OnHold',
  CANCEL: 'Cancel',
});

const WF_STATUS = Object.freeze({
  PENDING: 'Pending',
  APPROVED: 'Approved',
  REJECTED: 'Rejected',
  ON_HOLD: 'OnHold',
  CANCELLED: 'Cancelled',
});

// Active, ordered levels for a transaction type, filtered by amount band.
async function getLevels(trx, ctx, docType, amount = null) {
  const rows = await (trx || db)(CFG)
    .where({ companyId: ctx.companyId, docType, isActive: true, deleted: false })
    .orderBy('levelNo');
  return rows.filter((l) => {
    if (amount == null) return true;
    const min = l.minAmount == null ? -Infinity : Number(l.minAmount);
    const max = l.maxAmount == null ? Infinity : Number(l.maxAmount);
    return Number(amount) >= min && Number(amount) <= max;
  });
}

// Start a document's approval at its first applicable level.
// When no active level matches (approval switched off for the docType, or the
// amount falls outside every configured band), the document is auto-approved
// immediately: the state row is written as Approved so downstream gates that
// check the workflow state pass, and { autoApproved: true } tells the caller
// to advance its own document status too.
// meta { docNo, summary } are denormalized display fields for the inbox.
async function start(trx, ctx, docType, docId, amount = null, meta = {}) {
  const levels = await getLevels(trx, ctx, docType, amount);
  const display = { docNo: meta.docNo ?? null, summary: meta.summary ?? null };
  if (!levels.length) {
    await trx(STATE)
      .insert({
        docType, docId: String(docId), tenantId: ctx.tenantId, companyId: ctx.companyId,
        currentLevel: 0, status: WF_STATUS.APPROVED, ...display, updatedAt: new Date(),
      })
      .onConflict(['docType', 'docId'])
      .merge({ currentLevel: 0, status: WF_STATUS.APPROVED, ...display, updatedAt: new Date() });
    return { currentLevel: 0, status: WF_STATUS.APPROVED, autoApproved: true };
  }
  const first = levels[0].levelNo;
  await trx(STATE)
    .insert({
      docType, docId: String(docId), tenantId: ctx.tenantId, companyId: ctx.companyId,
      currentLevel: first, status: WF_STATUS.PENDING, ...display, updatedAt: new Date(),
    })
    .onConflict(['docType', 'docId'])
    .merge({ currentLevel: first, status: WF_STATUS.PENDING, ...display, updatedAt: new Date() });
  return { currentLevel: first, status: WF_STATUS.PENDING };
}

// Record an action and move the state. Returns the new state.
//   action: Approve advances to the next level or finalizes; Reject ends;
//   OnHold parks at the level with an until-date; Cancel ends as Cancelled.
async function act(trx, ctx, { docType, docId, action, amount = null, comment = null, onHoldUntil = null, actorUserId = null, docNo, summary }) {
  const id = String(docId);
  const state = await trx(STATE).where({ docType, docId: id }).first();
  if (!state) throw new AppError('No approval flow for this document', 400);

  await trx(LOG).insert({
    tenantId: ctx.tenantId, companyId: ctx.companyId,
    docType, docId: id, levelNo: state.currentLevel, action,
    actorUserId: actorUserId ?? ctx.userId ?? null,
    comment, onHoldUntil, actedAt: new Date(),
  });

  let next = { currentLevel: state.currentLevel, status: state.status };
  if (action === WF_ACTION.REJECT) {
    next = { currentLevel: state.currentLevel, status: WF_STATUS.REJECTED };
  } else if (action === WF_ACTION.ON_HOLD) {
    next = { currentLevel: state.currentLevel, status: WF_STATUS.ON_HOLD };
  } else if (action === WF_ACTION.CANCEL) {
    next = { currentLevel: state.currentLevel, status: WF_STATUS.CANCELLED };
  } else if (action === WF_ACTION.APPROVE || action === WF_ACTION.CONFIRM) {
    const levels = await getLevels(trx, ctx, docType, amount);
    const idx = levels.findIndex((l) => l.levelNo === state.currentLevel);
    const after = levels.slice(idx + 1);
    next = after.length
      ? { currentLevel: after[0].levelNo, status: WF_STATUS.PENDING }
      : { currentLevel: state.currentLevel, status: WF_STATUS.APPROVED };
  } else {
    throw new AppError('Unknown action', 400);
  }

  // Refresh the denormalized display fields if the caller supplied them.
  if (docNo !== undefined) next.docNo = docNo;
  if (summary !== undefined) next.summary = summary;
  await trx(STATE).where({ docType, docId: id }).update({ ...next, updatedAt: new Date() });
  return next;
}

// Documents waiting on this user: status Pending and the current level's
// approverFunction is one of the user's permission codes. Across all docTypes.
async function getPending(ctx, permissionCodes = []) {
  if (!permissionCodes.length) return [];
  return db(`${STATE} as s`)
    .join(`${CFG} as c`, function () {
      this.on('c.companyId', '=', 's.companyId')
        .andOn('c.docType', '=', 's.docType')
        .andOn('c.levelNo', '=', 's.currentLevel');
    })
    .select('s.docType', 's.docId', 's.docNo', 's.summary', 's.currentLevel', 's.status', 'c.levelName', 'c.approverFunction', 's.updatedAt')
    .where({ 's.companyId': ctx.companyId, 's.status': WF_STATUS.PENDING, 'c.isActive': true, 'c.deleted': false })
    .whereIn('c.approverFunction', permissionCodes)
    .orderBy('s.updatedAt', 'desc');
}

// conn lets callers pass a transaction so reads inside a trx reuse its connection.
async function getState(docType, docId, conn = db) {
  return conn(STATE).where({ docType, docId: String(docId) }).first();
}

async function getHistory(docType, docId, conn = db) {
  return conn(`${LOG} as l`)
    .leftJoin('mas_users as u', 'u.userId', 'l.actorUserId')
    .select('l.levelNo', 'l.action', 'l.comment', 'l.onHoldUntil', 'l.actedAt', 'u.fullName as actorName')
    .where({ 'l.docType': docType, 'l.docId': String(docId) })
    .orderBy('l.actedAt', 'asc');
}

module.exports = { getLevels, start, act, getPending, getState, getHistory, WF_ACTION, WF_STATUS };
