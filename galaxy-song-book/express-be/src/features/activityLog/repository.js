const db = require('../../database');
const { getNextSerialNo } = require('../../repository/getNextSerialNo');
const { pickFields } = require('../../repository/pickFields');
const { snapshotInsert } = require('../../repository/auditHistory');

// Client-settable columns. id, docType, txnType, tenantId, companyId, deleted,
// updatedBy, updatedAt (and txnIndex/txnLineNo/txnDate on details) are set explicitly.
const ACT_HEADER = ['txnDate', 'partner', 'vehicle', 'typeOfMachine', 'operator', 'helper', 'remarks', 'km', 'time', 'diesel', 'certifiedHours'];
const ACT_LINE = ['description', 'amount', 'hours'];

const activityLog = {
  async getUi() {
    const VehicleType = await db('ref_category')
      .select('id', 'parentId', 'value')
      .where({ categoryType: 70, isActive: 1 });
    const Vehicle = await db('ref_category')
      .select('id', 'parentId', 'value')
      .where({ categoryType: 80, isActive: 1 });

    return {VehicleType, Vehicle };
  },
  async getAll(filters = {}) {
    const result = await db('imp_txn_activityLog as DB')
      .select(
        'DB.id',
        'DB.txnDate',
        'BP.partnerName',
        db.raw('op.partnerName as operator'),
        db.raw('hp.partnerName as helper'),
        'remarks'
      )
      .leftJoin('mas_businessPartner AS BP', 'DB.partner', 'BP.businessPartnerId')
      .leftJoin('mas_businessPartner AS op', 'DB.operator', 'op.businessPartnerId')
      .leftJoin('mas_businessPartner AS hp', 'DB.helper', 'hp.businessPartnerId')
      .where('DB.deleted', false);
  return result;
  },

    async get(filters = {}) {
    const result = await db('imp_txn_activityLog')
      .select('id', 'txnDate', 'partner', 'vehicle', 'typeOfMachine', 'operator', 'helper', 'remarks', 'km', 'time', 'diesel', 'certifiedHours')
      .where({ id: filters.id, deleted: false })
      .first();
    const result2 = await db('imp_txn_activityLogDetail')
      .select('description', 'amount', 'hours')
      .where({ id: filters.id, deleted: false });

    return { ...result, lineItems: result2 };
  },

  async update(data) {
    const docType = 'ACT', txnType = 'ACT';

    return db.transaction(async trx => {
      const id = data.isUpdate ? data.header.id : await getNextSerialNo(trx, docType, txnType);


      if (data.isUpdate) {
        await trx('imp_txn_activityLog').where({ id,deleted:false }).update({deleted:true});
        await trx('imp_txn_activityLogDetail').where({ id,deleted:false }).update({deleted:true});
      }

      const [txnIndex] = await trx('imp_txn_activityLog').insert({
        ...pickFields(data.header, ACT_HEADER),
        id,
        docType,
        txnType,
        tenantId: data.tenantId ?? null,
        companyId: data.companyId ?? null,
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      await snapshotInsert(trx, 'imp_txn_activityLog', { txnIndex }, data.userId);

      let txnLineNo = 1;
      for (const item of data.lineItems) {
        await trx('imp_txn_activityLogDetail').insert({
          ...pickFields(item, ACT_LINE),
          txnIndex,
          id,
          txnDate: data.header.txnDate,
          docType,
          txnType,
          txnLineNo: txnLineNo++,
        });
      }
      return trx('imp_txn_activityLog').where({ txnIndex }).first();
    });
  },


  async delete(data) {
    const docType = "INV";

    return db.transaction(async (trx) => {
      await trx("imp_txn_activityLog")
        .where({ id: data.id, deleted: false })
        .update({ deleted: true });
      await trx("imp_txn_activityLogDetail")
        .where({ id: data.id,  deleted: false })
        .update({ deleted: true });

      return 'success';
    });
  }
}

module.exports = activityLog;