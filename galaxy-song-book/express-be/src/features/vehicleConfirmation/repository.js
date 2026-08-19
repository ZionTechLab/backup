const db = require('../../database');
const { getNextSerialNo } = require('../../repository/getNextSerialNo');
const { pickFields } = require('../../repository/pickFields');
const { snapshotInsert } = require('../../repository/auditHistory');

const docType = 'VCO', txnType = 'VCO';

// Columns a client is allowed to set on imp_txn_vehicleConfirmation.
// System columns (index, id, deleted, tenantId, companyId, updatedBy, updatedAt) are set explicitly below.
const VC_FIELDS = [
  'make', 'model', 'grade', 'colour', 'year', 'engineCapacity', 'fuelType', 'transmission',
  'millage', 'chassisNo', 'supplier', 'customer', 'purchaseDate', 'cifYen', 'auctionPrice',
  'tax', 'freight', 'paymentDate', 'paymentAmount', 'paymentRate', 'paymentAmountYen',
  'paymentDetails', 'lcOpenDetailsBank', 'JPY', 'lcOpenDetailsDate', 'lcMarginAmount',
  'lcMarginDate', 'lcSettlementAmount', 'lcSettlementCharges', 'lcSettlementDate', 'dutyAmount',
  'dutyDate', 'clearingCharges', 'clearingDate', 'salesTax', 'transportCost', 'totalCost', 'description',
];

const vehicleConfirmation = {

  async getUi() {
    const Make         = await db('ref_category').select('id', 'value').where({ categoryType: 10, isActive: true });
    const Model        = await db('ref_category').select('id', 'parentId', 'value').where({ categoryType: 20, isActive: true });
    const Grade        = await db('ref_category').select('id', 'parentId', 'value').where({ categoryType: 30, isActive: true });
    const FuelType     = await db('ref_category').select('id', 'value').where({ categoryType: 40, isActive: true });
    const Transmission = await db('ref_category').select('id', 'value').where({ categoryType: 50, isActive: true });
    const Colour       = await db('ref_category').select('id', 'value').where({ categoryType: 60, isActive: true });
    return { Make, Model, Grade, FuelType, Transmission, Colour };
  },

  async getAll(filters = {}) {
    const result = await db('imp_txn_vehicleConfirmation AS vc')
      .select(
        'vc.id',
        db.raw('make.value make'),
        db.raw('model.value model'),
        db.raw('grade.value grade'),
        db.raw('colour.value colour'),
        'year',
        'purchaseDate'
      )
      .leftOuterJoin('ref_category as make', function() {
        this.on('make.categoryType', '=', db.raw('10'))
          .andOn('make.id', '=', 'vc.make');
      })
      .leftOuterJoin('ref_category as model', function() {
        this.on('model.categoryType', '=', db.raw('20'))
          .andOn('model.id', '=', 'vc.model');
      })
      .leftOuterJoin('ref_category as grade', function() {
        this.on('grade.categoryType', '=', db.raw('30'))
          .andOn('grade.id', '=', 'vc.grade');
      })
      .leftOuterJoin('ref_category as colour', function() {
        this.on('colour.categoryType', '=', db.raw('60'))
          .andOn('colour.id', '=', 'vc.colour');
      })
      .where('vc.deleted', false)
      .limit(100);
    return result;
  },

  async get(filters = {}) {
    const data = await db('imp_txn_vehicleConfirmation')
      .where({ id: filters.id, deleted: false })
      .select(
        `JPY`, `auctionPrice`, `chassisNo`, `cifYen`, `clearingCharges`, `clearingDate`,
        `colour`, `tenantId`, `companyId`, `customer`, `deleted`, `description`,
        `dutyAmount`, `dutyDate`, `engineCapacity`, `freight`, `fuelType`, `grade`, `id`,
        `lcMarginAmount`, `lcMarginDate`, `lcOpenDetailsBank`, `lcOpenDetailsDate`,
        `lcSettlementAmount`, `lcSettlementCharges`, `lcSettlementDate`, `make`, `millage`,
        `model`, `paymentAmount`, `paymentAmountYen`, `paymentDate`, `paymentDetails`,
        `paymentRate`, `purchaseDate`, `salesTax`, `supplier`, `tax`, `totalCost`,
        `transmission`, `transportCost`, `updatedAt`, `updatedBy`, `year`
      )
      .first();
    const images = await db('gen_txn_images')
      .where({ docType, txnType, id: filters.id, deleted: false })
      .select(`image`);
    return { ...data, images: images.map(img => img.image) };
  },

  async uploadImage(data) {
    return db.transaction(async trx => {
      if (!data.images || data.images.length === 0) return [];
      const now = new Date();
      const insertData = data.images.map(item => ({
        id: data.id,
        docType,
        txnType,
        image: item,
        updatedBy: data.userId || null,
        updatedAt: now
      }));
      await trx('gen_txn_images').insert(insertData);
      return data.images;
    });
  },

  async delete(data) {
    return db.transaction(async (trx) => {
      await trx('imp_txn_vehicleConfirmation').where({ id: data.id, deleted: false }).update({ deleted: true });
      return 'success';
    });
  },

  async update(data) {
    return db.transaction(async trx => {
      const id = data.isUpdate ? data.header.id : await getNextSerialNo(trx, docType, txnType);
      if (data.isUpdate) {
        await trx('imp_txn_vehicleConfirmation').where({ id, deleted: false }).update({ deleted: true });
      }
      await trx('imp_txn_vehicleConfirmation').insert({
        ...pickFields(data.header, VC_FIELDS),
        id,
        tenantId: data.tenantId ?? null,
        companyId: data.companyId ?? null,
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      await snapshotInsert(trx, 'imp_txn_vehicleConfirmation', { id }, data.userId);
      return id;
    });
  },
};

module.exports = vehicleConfirmation;