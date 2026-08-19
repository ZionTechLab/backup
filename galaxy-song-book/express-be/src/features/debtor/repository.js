const db = require("../../database");
const { randomUUID } = require("crypto");
const { getNextSerialNo } = require("../../repository/getNextSerialNo");
const { pickFields } = require("../../repository/pickFields");
const { snapshotBefore, snapshotInsert } = require("../../repository/auditHistory");

// Client-settable columns. id, docType, txnType, tenantId, companyId, deleted,
// updatedBy, updatedAt (and txnIndex/txnLineNo/txnDate on details) are set explicitly.
const DEBTOR_HEADER = ['txnDate', 'partner', 'remarks', 'ref1', 'ref2', 'ref3', 'amount', 'taxAmount', 'taxRate', 'advance', 'totalAmount'];
const DEBTOR_LINE = ['description', 'amount'];

const repo = {
  
  async getUi() {
    const VehicleType = await db("ref_category")
      .select("id", "parentId", "value")
      .where({ categoryType: 70, isActive: true });
    const Vehicle = await db("ref_category")
      .select("id", "parentId", "value")
      .where({ categoryType: 80, isActive: true });
    return { VehicleType, Vehicle };
  },

  async getAll(filters = {}) {
    const result = await db("ar_txn_debtorTXN AS DB")
      .select(
        db.raw("CONCAT(DB.txnType, '/', DB.id) AS txnNoDisplay"),
        "DB.id",
        "DB.txnDate",
        "BP.partnerName",
        "DB.remarks",
        "DB.totalAmount",
        "DB.ref1",
        "DB.ref2"
      )
      .leftOuterJoin("mas_businessPartner AS BP", "DB.partner", "BP.businessPartnerId")
      .where({ "DB.deleted": false, "DB.txnType": filters.txnType });
    return result;
  },

  async get(filters = {}) {
    const result = await db("ar_txn_debtorTXN as DB")
      .select(
        "DB.id",
        db.raw("CONCAT(DB.txnType, '/', DB.id) AS txnNoDisplay"),
        "DB.txnDate",
        "DB.partner",
        "ref1",
        "ref2",
        "remarks",
        "DB.amount",
        "DB.advance",
        "DB.totalAmount"
      )
      .where({ "DB.id": filters.id, deleted: false, "DB.txnType": filters.txnType })
      .first();
    const result2 = await db("ar_txn_debtorTXNDetail")
      .select("description", "amount")
      .where({ id: filters.id, deleted: false, TxnType: filters.txnType });
    return { ...result, lineItems: result2 };
  },

  async getPrint(filters = {}) {
    const result = await db("ar_txn_debtorTXN as DB")
      .select(
        "DB.id",
        db.raw("CONCAT(DB.txnType, '/', DB.id) AS txnNoDisplay"),
        "DB.txnDate",
        "BP.partnerName",
        "BP.address",
        db.raw("v.value vType"),
        db.raw("vv.value vehicle"),
        "DB.amount",
        "DB.advance",
        "DB.totalAmount"
      )
      .leftOuterJoin("mas_businessPartner AS BP", "DB.partner", "BP.businessPartnerId")
      .leftOuterJoin("ref_category AS v", function() {
        this.on("v.categoryType", "=", db.raw("70"))
          .andOn("v.id", "=", "DB.ref1");
      })
      .leftOuterJoin("ref_category AS vv", function() {
        this.on("vv.categoryType", "=", db.raw("80"))
          .andOn("vv.id", "=", "DB.ref2");
      })
      .where({ "DB.id": filters.id, "DB.deleted": false, "DB.txnType": filters.txnType })
      .first();
    const result2 = await db("ar_txn_debtorTXNDetail")
      .select("description", "amount")
      .where({ id: filters.id, deleted: false, TxnType: filters.txnType });
    return { ...result, lineItems: result2 };
  },

  async update(data) {
    const docType = "INV",
      txnType = data.isTaxInvoice ? "TAX" : "NT";

    return db.transaction(async (trx) => {
      const id = data.isUpdate
        ? data.header.id
        : await getNextSerialNo(trx, docType, txnType);

      if (data.isUpdate) {
        await snapshotBefore(trx, "ar_txn_debtorTXN", { id, docType, txnType, deleted: false }, data.userId, "UPDATE");
        await trx("ar_txn_debtorTXN")
          .where({ id, docType, txnType, deleted: false })
          .update({ deleted: true });
        await trx("ar_txn_debtorTXNDetail")
          .where({ id, docType, txnType, deleted: false })
          .update({ deleted: true });
      }

      const txnIndex = randomUUID();
      await trx("ar_txn_debtorTXN").insert({
        ...pickFields(data.header, DEBTOR_HEADER),
        txnIndex,
        id,
        docType,
        txnType,
        tenantId: data.tenantId ?? null,
        companyId: data.companyId ?? null,
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      await snapshotInsert(trx, "ar_txn_debtorTXN", { txnIndex }, data.userId);

      let txnLineNo = 1;
      for (const item of data.lineItems) {
        await trx("ar_txn_debtorTXNDetail").insert({
          ...pickFields(item, DEBTOR_LINE),
          txnIndex,
          id,
          txnDate: data.header.txnDate,
          docType,
          txnType,
          txnLineNo: txnLineNo++,
        });
      }
      return trx("ar_txn_debtorTXN").where({ txnIndex }).first();
    });
  },

  async delete(data) {
    const docType = "INV";

    return db.transaction(async (trx) => {
      await snapshotBefore(trx, "ar_txn_debtorTXN", { id: data.id, docType, txnType: data.txnType, deleted: false }, data.userId, "DELETE");
      await trx("ar_txn_debtorTXN")
        .where({ id: data.id, docType, txnType: data.txnType, deleted: false })
        .update({ deleted: true });
      await trx("ar_txn_debtorTXNDetail")
        .where({ id: data.id, docType, txnType: data.txnType, deleted: false })
        .update({ deleted: true });

      return 'success';
    });
  },

  async updateAdvance(data) {
    const docType = data.isAdvance ? "ADV" : "PAY";
    const txnType = data.isAdvance ? "ADV" : "PAY";

    return db.transaction(async (trx) => {
      const id = data.isUpdate
        ? data.header.id
        : await getNextSerialNo(trx, docType, txnType);

      if (data.isUpdate) {
        await snapshotBefore(trx, "ar_txn_debtorTXN", { id, docType, txnType, deleted: false }, data.userId, "UPDATE");
        await trx("ar_txn_debtorTXN")
          .where({ id, docType, txnType, deleted: false })
          .update({ deleted: true });
      }

      const txnIndex = randomUUID();
      await trx("ar_txn_debtorTXN").insert({
        ...pickFields(data.header, DEBTOR_HEADER),
        txnIndex,
        id,
        docType,
        txnType,
        totalAmount: data.header.amount,
        tenantId: data.tenantId ?? null,
        companyId: data.companyId ?? null,
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      await snapshotInsert(trx, "ar_txn_debtorTXN", { txnIndex }, data.userId);

      return trx("ar_txn_debtorTXN").where({ txnIndex }).first();
    });
  },

  async deleteAdvance(data) {
    const docType = data.txnType; // 'ADV' | 'PAY'
    const txnType = data.txnType;
    return db.transaction(async (trx) => {
      await snapshotBefore(trx, "ar_txn_debtorTXN", { id: data.id, docType, txnType, deleted: false }, data.userId, "DELETE");
      await trx("ar_txn_debtorTXN")
        .where({ id: data.id, docType, txnType, deleted: false })
        .update({ deleted: true });
      return "success";
    });
  },
};

module.exports = repo;