const crypto = require('crypto');
const db = require('../../database');
const { ensureUnique } = require('../../repository/validators');
const { snapshotBefore, snapshotInsert } = require('../../repository/auditHistory');
const { pickFields } = require('../../repository/pickFields');
const { AppError } = require('../../middleware/errorHandler');

const TABLE = 'mas_orgUnit';
const FIELDS = ['unitType', 'code', 'name', 'parentId', 'isActive'];

const UNIT_RANK = { Branch: 1, Division: 2, Department: 3, Section: 4 };

const repo = {
  async getAll(ctx, unitType) {
    const q = db(`${TABLE} as ou`)
      .select(
        'ou.orgUnitId', 'ou.unitType', 'ou.code', 'ou.name',
        'ou.parentId', 'ou.isActive', 'ou.companyId',
        'c.companyName',
        'p.name as parentName'
      )
      .leftJoin(`${TABLE} as p`, 'p.orgUnitId', 'ou.parentId')
      .leftJoin({ c: 'sec_companies' }, 'c.companyId', 'ou.companyId')
      .where({ 'ou.deleted': false, 'ou.tenantId': ctx.tenantId })
      .orderBy('ou.code');

    if (unitType) q.andWhere('ou.unitType', unitType);
    if (ctx.companyId) q.andWhere('ou.companyId', ctx.companyId);

    return q;
  },

  async getParents(ctx, unitType, companyId) {
    const rank = UNIT_RANK[unitType];
    if (!rank) return [];

    const q = db(TABLE)
      .select('orgUnitId', 'code', 'name', 'unitType', 'companyId')
      .where({
        deleted: false,
        isActive: true,
        tenantId: ctx.tenantId,
      })
      .whereNot({ unitType })
      .whereIn('unitType', Object.keys(UNIT_RANK).filter((t) => UNIT_RANK[t] === rank - 1))
      .orderBy('code');

    if (companyId) q.andWhere({ companyId });
    else if (ctx.companyId) q.andWhere({ companyId: ctx.companyId });

    return q;
  },

  async get(ctx, id) {
    return db(`${TABLE} as ou`)
      .select(
        'ou.orgUnitId', 'ou.unitType', 'ou.code', 'ou.name',
        'ou.parentId', 'ou.isActive', 'ou.companyId',
        'c.companyName',
        'p.name as parentName'
      )
      .leftJoin(`${TABLE} as p`, 'p.orgUnitId', 'ou.parentId')
      .leftJoin({ c: 'sec_companies' }, 'c.companyId', 'ou.companyId')
      .where({ 'ou.orgUnitId': id, 'ou.deleted': false })
      .first();
  },

  async save(ctx, data) {
    return db.transaction(async (trx) => {
      const isUpdate = !!data.orgUnitId;

      // Derive company from parent; fall back to explicit or ctx companyId
      let targetCompanyId;
      if (data.parentId) {
        const parent = await trx(TABLE)
          .where({ orgUnitId: data.parentId, deleted: false })
          .first();

        if (!parent) {
          throw new AppError('Parent not found.', 400);
        }
        const expectedRank = UNIT_RANK[data.unitType] - 1;
        if (UNIT_RANK[parent.unitType] !== expectedRank) {
          throw new AppError(
            `${data.unitType} parent must be a ${Object.keys(UNIT_RANK).find((k) => UNIT_RANK[k] === expectedRank)} (got ${parent.unitType}).`,
            400
          );
        }
        targetCompanyId = parent.companyId;
      } else {
        targetCompanyId = data.companyId || ctx.companyId;
      }

      await ensureUnique(
        trx, TABLE,
        { companyId: targetCompanyId, unitType: data.unitType, code: data.code },
        isUpdate ? { orgUnitId: data.orgUnitId } : {},
        `${data.unitType} code already exists.`
      );

      if (isUpdate) {
        const id = data.orgUnitId;
        await snapshotBefore(trx, TABLE, { orgUnitId: id, deleted: false }, ctx.userId, 'UPDATE');
        await trx(TABLE).where({ orgUnitId: id, deleted: false }).update({
          ...pickFields(data, FIELDS),
          companyId: targetCompanyId,
          updatedBy: ctx.userId ?? null,
          updatedAt: new Date(),
        });
        return trx(TABLE).where({ orgUnitId: id }).first();
      }

      const orgUnitId = crypto.randomUUID();
      await trx(TABLE).insert({
        ...pickFields(data, FIELDS),
        orgUnitId,
        tenantId: ctx.tenantId,
        companyId: targetCompanyId,
        updatedBy: ctx.userId ?? null,
        updatedAt: new Date(),
      });
      await snapshotInsert(trx, TABLE, { orgUnitId }, ctx.userId);
      return trx(TABLE).where({ orgUnitId }).first();
    });
  },

  async getCompanies(ctx) {
    return db('sec_companies')
      .select('companyId', 'companyCode', 'companyName')
      .where({ isActive: true })
      .orderBy('companyName');
  },

  async del(ctx, id) {
    return db.transaction(async (trx) => {
      const child = await trx(TABLE)
        .where({ parentId: id, deleted: false })
        .first();
      if (child) {
        throw new AppError('This unit has child units and cannot be deleted.', 409);
      }
      await snapshotBefore(trx, TABLE, { orgUnitId: id, deleted: false }, ctx.userId, 'DELETE');
      await trx(TABLE).where({ orgUnitId: id, deleted: false }).update({ deleted: true });
      return 'success';
    });
  },
};

module.exports = repo;
