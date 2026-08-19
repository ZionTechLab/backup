const crypto = require('crypto');
const db = require('../../../database');
const { snapshotBefore, snapshotInsert } = require('../../../repository/auditHistory');
const { pickFields } = require('../../../repository/pickFields');

const TABLE = 'conf_pcApprovalBand';
const FIELDS = ['docType', 'minAmount', 'maxAmount', 'approverFunction', 'sortOrder'];

const DOC_TYPES = ['PCV', 'PIOU'];
const FUNCTIONS = ['HOD', 'Accountant', 'Director'];

const repo = {
  async getUi(ctx = {}) {
    return { docTypes: DOC_TYPES, functions: FUNCTIONS };
  },

  async getAll(filters = {}) {
    return db(TABLE)
      .select('bandId', 'docType', 'minAmount', 'maxAmount', 'approverFunction', 'sortOrder')
      .where({ deleted: false, tenantId: filters.tenantId, companyId: filters.companyId })
      .orderBy(['docType', 'sortOrder']);
  },

  async get(filters = {}) {
    return db(TABLE)
      .select('bandId', 'docType', 'minAmount', 'maxAmount', 'approverFunction', 'sortOrder')
      .where({ bandId: filters.id, deleted: false })
      .first();
  },

  async update(data) {
    return db.transaction(async (trx) => {
      if (data.isUpdate) {
        const id = data.bandId;
        await snapshotBefore(trx, TABLE, { bandId: id, deleted: false }, data.userId, 'UPDATE');
        await trx(TABLE).where({ bandId: id, deleted: false }).update({
          ...pickFields(data, FIELDS),
          updatedBy: data.userId ?? null,
          updatedAt: new Date(),
        });
        return trx(TABLE).where({ bandId: id }).first();
      }

      const bandId = crypto.randomUUID();
      await trx(TABLE).insert({
        ...pickFields(data, FIELDS),
        bandId,
        tenantId: data.tenantId,
        companyId: data.companyId,
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      await snapshotInsert(trx, TABLE, { bandId }, data.userId);
      return trx(TABLE).where({ bandId }).first();
    });
  },

  async delete(data) {
    return db.transaction(async (trx) => {
      await snapshotBefore(trx, TABLE, { bandId: data.id, deleted: false }, data.userId, 'DELETE');
      await trx(TABLE).where({ bandId: data.id, deleted: false }).update({ deleted: true });
      return 'success';
    });
  },
};

module.exports = repo;
