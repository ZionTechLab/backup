const db = require('../../database');
const { getNextSerialNo } = require('../../repository/getNextSerialNo');
const { ensureUnique } = require('../../repository/validators');
const { pickFields } = require('../../repository/pickFields');
const { snapshotBefore, snapshotInsert } = require('../../repository/auditHistory');

// Columns a client may set on ims_mas_items. id, itemCode, tenantId, companyId,
// deleted, updatedBy, updatedAt are set explicitly below.
const ITEM_FIELDS = ['itemName', 'description', 'uom', 'brand', 'reorderLevel', 'costPrice', 'sellingPrice', 'active'];

const ItemRepo = {
  async getUi() {
    const UOM = await db('ref_category').select('id', 'value').where({ categoryType: 80, isActive: true });
    return { UOM };
  },

  async getAll(filters = {}) {
    const result = await db('ims_mas_items')
      .select('tenantId', 'companyId', 'id', 'itemCode', 'itemName', 'uom', 'brand', 'reorderLevel', 'costPrice', 'sellingPrice', 'active')
      .where('deleted', false);
    return result;
  },

  async get(filters = {}) {
    const result = await db('ims_mas_items')
      .select(
        'tenantId',
        'companyId',
        'id',
        'itemCode',
        'itemName',
        'description',
        'uom',
        'brand',
        'reorderLevel',
        'costPrice',
        'sellingPrice',
        'active'
      )
      .where({ id: filters.id, deleted: false })
      .first();

    return result;
  },

  async getPrint(filters = {}) {
    // For master record, get same as get but could join to show additional lookup values
    const item = await this.get(filters);
    return item;
  },

  async update(data) {
    // This master uses soft-update pattern similar to other masters
    const docType = 'ITM', txnType = 'ITM';
    return db.transaction(async (trx) => {
      const id = data.isUpdate ? data.header.id : await getNextSerialNo(trx, docType, txnType);
      await ensureUnique(trx, 'ims_mas_items', { itemCode: data.header.itemCode }, { id }, `Item with code ${data.header.itemCode} already exists.`);

      if (data.isUpdate) {
        await trx('ims_mas_items').where({ id, deleted: false }).update({ deleted: true });
      }

      const [index] = await trx('ims_mas_items').insert({
        ...pickFields(data.header, ITEM_FIELDS),
        id,
        itemCode: id,
        tenantId: data.tenantId ?? null,
        companyId: data.companyId ?? null,
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      await snapshotInsert(trx, 'ims_mas_items', { id }, data.userId);

      return trx('ims_mas_items').where({ id }).first();
    });
  },

  async delete(data) {
    return db.transaction(async (trx) => {
      await snapshotBefore(trx, 'ims_mas_items', { id: data.id, deleted: false }, data.userId, 'DELETE');
      await trx('ims_mas_items').where({ id: data.id, deleted: false }).update({ deleted: true });
      return 'success';
    });
  },
};

module.exports = ItemRepo;