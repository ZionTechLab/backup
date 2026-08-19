const db = require("../../database");
const { randomUUID } = require("crypto");
const { ensureUnique } = require("../../repository/validators");
const { snapshotBefore, snapshotInsert } = require("../../repository/auditHistory");

const repo = {

  async getAll(filters = {}) {

    let partnerType;
    switch (filters.type) {
      case "customer":
        partnerType = "C";
        break;
      case "supplier":
        partnerType = "S";
        break;
      case "driver":
        partnerType = "D";
        break;
      case "helper":
        partnerType = "H";
        break;
      case "operator":
        partnerType = "O";
        break;
      case "staff":
        partnerType = "E";
        break;
      default:
        partnerType = null;
        break;
    }

    const query = db('mas_businessPartner as bp')
      .select(
        'bp.businessPartnerId',
        'bp.tenantId',
        'bp.partnerCode',
        'bp.partnerName',
        'bp.contactPerson',
        'bp.email',
        'bp.address',
        'bp.phone1',
        'bp.phone2',
        'bp.whatsappId',
        'bp.nic',
        'bp.preferredName',
        'bp.fullName',
        'bp.empNo',
        'bp.photoPath',
        'bp.digitalSignPath',
        'bp.isActive',
        db.raw('pt.partnerTypes')
      )
      .joinRaw(
        `left join (
          select businessPartnerId, group_concat(distinct partnerType) as partnerTypes
          from mas_businessPartnerTypes
          ${partnerType ? 'where partnerType = ?' : ''}
          group by businessPartnerId
        ) pt on bp.businessPartnerId = pt.businessPartnerId`,
        partnerType ? [partnerType] : []
      );

    if (partnerType) {
      query.whereRaw('pt.partnerTypes is not null');
    }

    const result = await query;
    return result;
  },

  async get(filters = {}) {
    const businessPartnerId = filters.businessPartnerId || filters.id;

    let result = await db("mas_businessPartner")
      .select(
        "businessPartnerId",
        "tenantId",
        "partnerCode",
        "partnerName",
        "contactPerson",
        "email",
        "address",
        "phone1",
        "phone2",
        "whatsappId",
        "nic",
        "preferredName",
        "fullName",
        "empNo",
        "photoPath",
        "digitalSignPath",
        "isActive"
      )
      .where({ businessPartnerId })
      .first();

    let result2 = await db("mas_businessPartnerTypes")
      .select("partnerType")
      .where({ businessPartnerId });

    const partnerTypes = result2.map((item) => item.partnerType);

    return { ...result, partnerType: partnerTypes };
  },

  async update(data) {
    return db.transaction(async (trx) => {

      const isUpdate = !!data.isUpdate;
      const businessPartnerId = isUpdate ? data.header.businessPartnerId : randomUUID();

      await ensureUnique(trx, "mas_businessPartner", { partnerCode: data.header.partnerCode }, { businessPartnerId },
        `Business partner with code ${data.header.partnerCode} already exists.`, 409, {}
      );

      await ensureUnique(trx, "mas_businessPartner", { partnerName: data.header.partnerName }, { businessPartnerId },
        `Business partner with Name ${data.header.partnerName} already exists.`, 409, {}
      );

      const fields = {
        partnerCode: data.header.partnerCode,
        partnerName: data.header.partnerName,
        contactPerson: data.header.contactPerson,
        email: data.header.email,
        address: data.header.address,
        phone1: data.header.phone1,
        phone2: data.header.phone2,
        whatsappId: data.header.whatsappId,
        nic: data.header.nic,
        preferredName: data.header.preferredName,
        fullName: data.header.fullName,
        empNo: data.header.empNo,
        photoPath: data.header.photoPath,
        digitalSignPath: data.header.digitalSignPath,
        isActive: data.header.isActive,
        updatedBy: data.userId,
        updatedAt: new Date(),
      };

      if (isUpdate) {
        await snapshotBefore(trx, "mas_businessPartner", { businessPartnerId }, data.userId, "UPDATE");
        await trx("mas_businessPartner").where({ businessPartnerId }).update(fields);
        await trx("mas_businessPartnerTypes").where({ businessPartnerId }).del();
      } else {
        await trx("mas_businessPartner").insert({
          businessPartnerId,
          tenantId: data.header.tenantId,
          ...fields,
        });
        await snapshotInsert(trx, "mas_businessPartner", { businessPartnerId }, data.userId);
      }

      for (const item of data.detail || []) {
        await trx("mas_businessPartnerTypes").insert({
          tenantId: data.header.tenantId,
          businessPartnerId,
          partnerType: item.type,
          updatedBy: data.userId,
          updatedAt: new Date(),
        });
      }

      if (data.header.companyId) {
        const link = await trx("mas_businessPartnerCompany")
          .where({ businessPartnerId, companyId: data.header.companyId })
          .first();
        if (!link) {
          await trx("mas_businessPartnerCompany").insert({
            businessPartnerId,
            companyId: data.header.companyId,
            isDefault: true,
            updatedBy: data.userId,
            updatedAt: new Date(),
          });
        }
      }

      return trx("mas_businessPartner").where({ businessPartnerId }).first();
    });

  },

  async delete(data) {
    const businessPartnerId = data.businessPartnerId || data.id;
    return db.transaction(async (trx) => {
      await snapshotBefore(trx, "mas_businessPartner", { businessPartnerId }, data.userId, "DELETE");
      await trx("mas_businessPartnerTypes").where({ businessPartnerId }).del();
      await trx("mas_businessPartnerCompany").where({ businessPartnerId }).del();
      await trx("mas_businessPartner").where({ businessPartnerId }).del();
      return "success";
    });
  },
};

module.exports = repo;