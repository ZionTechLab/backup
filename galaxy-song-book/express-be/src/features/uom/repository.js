const db = require('../../database');
const { getNextSerialNo } = require('../../repository/getNextSerialNo');
const { ensureUnique } = require('../../repository/validators');
const { pickFields } = require('../../repository/pickFields');
const { snapshotBefore, snapshotInsert } = require('../../repository/auditHistory');

const docType = 'UOM';
const txnType = 'UOM';

const UOM_FIELDS = ['uomName', 'description', 'active'];

const repo = {
  async getAll() {
    return db('ims_mas_uom')
      .select('id', 'uomCode', 'uomName', 'description', 'active')
      .where({ deleted: false })
      .orderBy('uomName');
  },

  async get(filters = {}) {
    return db('ims_mas_uom')
      .select('id', 'uomCode', 'uomName', 'description', 'active')
      .where({ id: filters.id, deleted: false })
      .first();
  },

  async update(data) {
    return db.transaction(async (trx) => {
      const id = data.isUpdate ? data.header.id : await getNextSerialNo(trx, docType, txnType);

      await ensureUnique(
        trx, 'ims_mas_uom',
        { uomName: data.header.uomName, deleted: false },
        { id },
        `UOM "${data.header.uomName}" already exists.`
      );

      if (data.isUpdate) {
        await snapshotBefore(trx, 'ims_mas_uom', { id, deleted: false }, data.userId, 'UPDATE');
        await trx('ims_mas_uom').where({ id, deleted: false }).update({
          ...pickFields(data.header, UOM_FIELDS),
          updatedBy: data.userId ?? null,
          updatedAt: new Date(),
        });
        return trx('ims_mas_uom').where({ id, deleted: false }).first();
      }

      await trx('ims_mas_uom').insert({
        ...pickFields(data.header, UOM_FIELDS),
        id,
        uomCode: String(id),
        tenantId: data.tenantId ?? null,
        companyId: data.companyId ?? null,
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      await snapshotInsert(trx, 'ims_mas_uom', { id }, data.userId);

      return trx('ims_mas_uom').where({ id }).first();
    });
  },

  async delete(data) {
    return db.transaction(async (trx) => {
      await snapshotBefore(trx, 'ims_mas_uom', { id: data.id, deleted: false }, data.userId, 'DELETE');
      await trx('ims_mas_uom').where({ id: data.id, deleted: false }).update({ deleted: true });
      return 'success';
    });
  },
};

module.exports = repo;
