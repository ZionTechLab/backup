const db = require('../../database');
const { ensureUnique } = require('../../repository/validators');
const { snapshotBefore, snapshotInsert } = require('../../repository/auditHistory');

const TABLE = 'sec_permissionGroup';
const DETAIL = 'sec_permissionGroupDetail';

const repo = {
  // Full catalog plus the tenant's groups. Drives the list and the create matrix.
  async getAll(ctx) {
    const permissionGroups = await db(TABLE)
      .select('permGroupId', 'permGroupName', 'isActive')
      .where({ tenantId: ctx.tenantId, deleted: false })
      .orderBy('permGroupName');
    const modules = await db('sec_module')
      .select('moduleId', 'moduleName')
      .where({ isActive: true })
      .orderBy('sortOrder');
    const permissions = await db('sec_permission')
      .select('permId', 'permCode', 'permName', 'moduleId')
      .where({ isActive: true })
      .orderBy('sortOrder');
    return { permissionGroups, modules, permissions };
  },

  // One group's matrix: every permission flagged with this group's selections.
  async get(ctx, permGroupId) {
    const group = await db(TABLE)
      .select('permGroupId', 'permGroupName', 'isActive')
      .where({ permGroupId, tenantId: ctx.tenantId, deleted: false })
      .first();
    if (!group) return null;

    const modules = await db('sec_module')
      .select('moduleId', 'moduleName')
      .where({ isActive: true })
      .orderBy('sortOrder');
    const selected = new Set(await db(DETAIL).where({ permGroupId }).pluck('permId'));
    const perms = await db('sec_permission')
      .select('permId', 'permCode', 'permName', 'moduleId')
      .where({ isActive: true })
      .orderBy('sortOrder');
    const permissions = perms.map((p) => ({ ...p, isPermitted: selected.has(p.permId) ? 1 : 0 }));

    return { group, modules, permissions };
  },

  async save(ctx, data) {
    const grp = (data.permissionGroups || [])[0] || {};
    const isUpdate = !!data.isUpdateMode;
    const permitted = (data.permissions || []).filter((p) => p.isPermitted === 1 || p.isPermitted === true);

    return db.transaction(async (trx) => {
      let permGroupId = grp.permGroupId;

      if (isUpdate) {
        await ensureUnique(
          trx, TABLE,
          { tenantId: ctx.tenantId, permGroupName: grp.permGroupName },
          { permGroupId }, 'Permission group name already exists.'
        );
        await snapshotBefore(trx, TABLE, { permGroupId, deleted: false }, ctx.userId, 'UPDATE');
        await trx(TABLE).where({ permGroupId, tenantId: ctx.tenantId, deleted: false }).update({
          permGroupName: grp.permGroupName,
          updatedBy: ctx.userId ?? null,
          updatedAt: new Date(),
        });
      } else {
        await ensureUnique(
          trx, TABLE,
          { tenantId: ctx.tenantId, permGroupName: grp.permGroupName },
          null, 'Permission group name already exists.'
        );
        const [id] = await trx(TABLE).insert({
          tenantId: ctx.tenantId,
          permGroupName: grp.permGroupName,
          updatedBy: ctx.userId ?? null,
          updatedAt: new Date(),
        });
        await snapshotInsert(trx, TABLE, { permGroupId: id }, ctx.userId);
        permGroupId = id;
      }

      await trx(DETAIL).where({ permGroupId }).del();
      if (permitted.length) {
        await trx(DETAIL).insert(permitted.map((p) => ({ permGroupId, permId: p.permId })));
      }
      return { permGroupId };
    });
  },

  async delete(ctx, permGroupId) {
    return db.transaction(async (trx) => {
      await snapshotBefore(trx, TABLE, { permGroupId, deleted: false }, ctx.userId, 'DELETE');
      await trx(TABLE).where({ permGroupId, tenantId: ctx.tenantId, deleted: false }).update({ deleted: true });
      return 'success';
    });
  },
};

module.exports = repo;
