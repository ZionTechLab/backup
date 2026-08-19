const crypto = require('crypto');
const db = require('../../database');
const { ensureUnique } = require('../../repository/validators');
const { snapshotBefore, snapshotInsert } = require('../../repository/auditHistory');
const { pickFields } = require('../../repository/pickFields');
const workflow = require('../../repository/workflow');

const TABLE = 'wf_levelConfig';
const FIELDS = ['docType', 'levelNo', 'levelName', 'approverFunction', 'minAmount', 'maxAmount', 'isActive'];

const repo = {
  // Options for the config form: known transaction types and approver functions.
  async getOptions(ctx) {
    const docTypes = await db('conf_txnType')
      .distinct('docType')
      .where({ companyId: ctx.companyId })
      .orderBy('docType');
    const functions = await db('sec_permission')
      .select('permCode', 'permName')
      .where({ isActive: true })
      .orderBy('permCode');
    return { docTypes: docTypes.map((d) => d.docType), functions };
  },

  async getAll(ctx) {
    return db(TABLE)
      .select('levelId', 'docType', 'levelNo', 'levelName', 'approverFunction', 'minAmount', 'maxAmount', 'isActive')
      .where({ companyId: ctx.companyId, deleted: false })
      .orderBy(['docType', 'levelNo']);
  },

  async get(ctx, levelId) {
    return db(TABLE).where({ levelId, companyId: ctx.companyId, deleted: false }).first();
  },

  async save(ctx, data) {
    return db.transaction(async (trx) => {
      if (data.isUpdate) {
        const id = data.levelId;
        await ensureUnique(trx, TABLE, { companyId: ctx.companyId, docType: data.docType, levelNo: data.levelNo }, { levelId: id }, 'A level with this number already exists for the transaction.');
        await snapshotBefore(trx, TABLE, { levelId: id, deleted: false }, ctx.userId, 'UPDATE');
        await trx(TABLE).where({ levelId: id, deleted: false }).update({
          ...pickFields(data, FIELDS),
          updatedBy: ctx.userId ?? null,
          updatedAt: new Date(),
        });
        return trx(TABLE).where({ levelId: id }).first();
      }
      await ensureUnique(trx, TABLE, { companyId: ctx.companyId, docType: data.docType, levelNo: data.levelNo }, null, 'A level with this number already exists for the transaction.');
      const levelId = crypto.randomUUID();
      await trx(TABLE).insert({
        ...pickFields(data, FIELDS),
        levelId,
        tenantId: ctx.tenantId,
        companyId: ctx.companyId,
        updatedBy: ctx.userId ?? null,
        updatedAt: new Date(),
      });
      await snapshotInsert(trx, TABLE, { levelId }, ctx.userId);
      return trx(TABLE).where({ levelId }).first();
    });
  },

  async delete(ctx, levelId) {
    return db.transaction(async (trx) => {
      await snapshotBefore(trx, TABLE, { levelId, deleted: false }, ctx.userId, 'DELETE');
      await trx(TABLE).where({ levelId, companyId: ctx.companyId, deleted: false }).update({ deleted: true });
      return 'success';
    });
  },

  // My Approvals inbox.
  async getInbox(ctx, permissionCodes) {
    return workflow.getPending(ctx, permissionCodes);
  },

  async getDoc(docType, docId) {
    const state = await workflow.getState(docType, docId);
    const history = await workflow.getHistory(docType, docId);
    return { state, history };
  },
};

module.exports = repo;
