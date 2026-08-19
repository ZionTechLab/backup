const db = require("../../database");
const { pickFields } = require("../../repository/pickFields");
const { snapshotInsert } = require("../../repository/auditHistory");

// Client-settable columns on ref_category. id, tenantId, companyId, updatedBy, updatedAt set explicitly.
const CAT_FIELDS = ['parentId', 'categoryType', 'value', 'description', 'isActive', 'ref1', 'ref2', 'ref3', 'ref4', 'ref5'];

const repo = {
  async getUi(filters = {}) {
    const categoryType = Number(filters.categoryType);

    const meta = await db("conf_category")
      .select("categoryTypeName", "parentCategoryType", "metaValue", "ref1", "ref2", "ref3", "ref4", "ref5", "metaDesc")
      .where({ categoryType })
      .first();

    if (meta && meta.parentCategoryType) {
      const parentCategory = await db("conf_category")
        .select("categoryTypeName")
        .where({ categoryType: meta.parentCategoryType })
        .first();
      meta.parentCategory = parentCategory.categoryTypeName;

      const parentCategoryData = await db("ref_category")
        .select("id", "parentId", "value", "description", "isActive")
        .where({ categoryType: meta.parentCategoryType });

      meta.parentCategoryData = parentCategoryData;
    }

    return { meta };
  },

  async getAll(filters = {}) {
    const categoryType = Number(filters.categoryType);
    const meta = await db("conf_category")
      .select("categoryTypeName", "metaValue", "metaDesc", "ref1", "ref2", "ref3", "ref4", "ref5", "parentCategoryType")
      .where({ categoryType })
      .first();

    if (meta && meta.parentCategoryType) {
      const parentCategory = await db("conf_category")
        .select("categoryTypeName")
        .where({ categoryType: meta.parentCategoryType })
        .first();
      meta.parentCategory = parentCategory.categoryTypeName;
    }

    let data;
    if (meta && meta.parentCategoryType) {
      data = await db("ref_category as C")
        .select(
          "C.id",
          "C.parentId",
          "CC.value as parentValue",
          "C.value",
          "C.description",
          "C.ref1",
          "C.ref2",
          "C.ref3",
          "C.ref4",
          "C.ref5",
          "C.isActive"
        )
        .leftJoin("ref_category as CC", function() {
          this.on("CC.categoryType", "=", db.raw("?", [meta.parentCategoryType]))
            .andOn("CC.id", "=", "C.parentId");
        })
        .where("C.categoryType", categoryType);
    } else {
      data = await db("ref_category as C")
        .select(
          "C.id",
          "C.parentId",
          "C.value",
          "C.description",
          "C.ref1",
          "C.ref2",
          "C.ref3",
          "C.ref4",
          "C.ref5",
          "C.isActive"
        )
        .where("C.categoryType", categoryType);
    }

    return { data, meta };
  },

  async get(filters = {}) {
    if (!filters.id) return null;
    const result = await db("ref_category")
      .select("id", "parentId", "categoryType", "value", "ref1", "ref2", "ref3", "ref4", "ref5", "description", "isActive")
      .where({ id: Number(filters.id), categoryType: Number(filters.categoryType) })
      .first();
    return result || null;
  },

  async update(data) {
    return db.transaction(async (trx) => {
      const isUpdate = !!data.isUpdate;
      const header = data.header || {};

      let id;
      if (isUpdate) {
        id = Number(header.id);
      } else {
        const maxRow = await trx("ref_category")
          .max("id as maxId")
          .where({ categoryType: Number(header.categoryType) })
          .first();
        id = (maxRow.maxId || 0) + 1;
      }

      if (isNaN(id)) {
        throw new Error("Invalid id");
      }

      if (isUpdate) {
        await trx("ref_category")
          .where({ id, categoryType: data.header.categoryType })
          .update({
            parentId: header.parentId,
            value: header.value,
            description: header.description,
            ref1: header.ref1,
            ref2: header.ref2,
            ref3: header.ref3,
            ref4: header.ref4,
            ref5: header.ref5,
            isActive: header.isActive,
            updatedBy: data.userId || null,
            updatedAt: new Date(),
          });
        return trx("ref_category").where({ id, categoryType: data.header.categoryType }).first();
      }

      const [index] = await trx("ref_category").insert({
        ...pickFields(header, CAT_FIELDS),
        id,
        tenantId: data.tenantId ?? 1,
        companyId: data.companyId ?? 1,
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
      });
      await snapshotInsert(trx, "ref_category", { index }, data.userId);

      return trx("ref_category").where({ index }).first();
    });
  },

  async delete(data) {
    return db.transaction(async (trx) => {
      await trx("ref_category")
        .where({ id: data.id, categoryType: data.categoryType })
        .del();
      return "success";
    });
  },
};

module.exports = repo;