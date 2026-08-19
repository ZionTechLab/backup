const db = require('../../database');
const { snapshotBefore, snapshotInsert } = require('../../repository/auditHistory');
const { AppError } = require('../../middleware/errorHandler');

// Menu arrangement admin. sec_menu is a tree via parentId (0 = root) with
// sibling ordering in `order`; sec_userMenu holds role visibility grants.

const MENU = 'sec_menu';
const GRANT = 'sec_userMenu';

// Rejects any arrangement where following parentId from a node revisits it.
function assertNoCycles(items) {
  const parentOf = new Map(items.map((i) => [i.id, i.parentId]));
  for (const item of items) {
    let cur = item.parentId;
    let hops = 0;
    while (cur && cur !== 0) {
      if (cur === item.id) throw new AppError(`Menu ${item.id} would become its own ancestor`, 400);
      cur = parentOf.get(cur) ?? 0;
      if (++hops > 100) throw new AppError('Menu tree too deep or cyclic', 400);
    }
  }
}

const repo = {
  async getAll(ctx) {
    const scope = { tenantId: ctx.tenantId, companyId: ctx.companyId };
    const menus = await db(MENU).where({ ...scope, isDeleted: false })
      .select('id', 'parentId', 'route', 'displayName', 'icon', 'order', 'isGroup', 'isActive')
      .orderBy(['parentId', 'order']);
    const roles = await db('sec_permissionGroup').where({ tenantId: ctx.tenantId, isActive: true }).select('permGroupId as id', 'permGroupName as roleName');
    const grants = await db(GRANT).where({ ...scope, isDeleted: false }).select('id', 'roleId');
    return { menus, roles, grants };
  },

  // Create or edit a single item's properties. New items get id = max+1 and go
  // last under their parent, auto-granted to role 1 so the admin sees them.
  async save(ctx, data) {
    const scope = { tenantId: ctx.tenantId, companyId: ctx.companyId };
    return db.transaction(async (trx) => {
      if (data.parentId !== 0) {
        const parent = await trx(MENU).where({ ...scope, id: data.parentId, isDeleted: false }).first();
        if (!parent) throw new AppError('Parent menu not found', 404);
        if (data.id != null && Number(data.parentId) === Number(data.id)) {
          throw new AppError('A menu cannot be its own parent', 400);
        }
      }

      if (data.id != null) {
        const existing = await trx(MENU).where({ ...scope, id: data.id, isDeleted: false }).first();
        if (!existing) throw new AppError('Menu not found', 404);
        await snapshotBefore(trx, MENU, { ...scope, id: data.id }, ctx.userId, 'UPDATE');
        await trx(MENU).where({ ...scope, id: data.id }).update({
          route: data.route, displayName: data.displayName, icon: data.icon,
          parentId: data.parentId, isGroup: !!data.isGroup, isActive: !!data.isActive,
          updatedBy: ctx.userId ?? null, updatedAt: new Date(),
        });
        return trx(MENU).where({ ...scope, id: data.id }).first();
      }

      const mxId = await trx(MENU).max('id as m').first();
      const id = (mxId?.m ?? 0) + 1;
      const mxOrder = await trx(MENU).where({ ...scope, parentId: data.parentId, isDeleted: false }).max('order as m').first();
      await trx(MENU).insert({
        ...scope, id, parentId: data.parentId, route: data.route,
        displayName: data.displayName, icon: data.icon,
        order: (mxOrder?.m ?? 0) + 1, isGroup: !!data.isGroup, isActive: !!data.isActive,
        updatedBy: ctx.userId ?? null, updatedAt: new Date(),
      });
      await snapshotInsert(trx, MENU, { ...scope, id }, ctx.userId);
      await trx(GRANT).insert({ ...scope, id, roleId: 1, isCategory: 0, updatedBy: ctx.userId ?? null, updatedAt: new Date() });
      return trx(MENU).where({ ...scope, id }).first();
    });
  },

  // The whole arrangement in one transactional batch: [{id, parentId, order}].
  async arrange(ctx, items) {
    const scope = { tenantId: ctx.tenantId, companyId: ctx.companyId };
    assertNoCycles(items);
    return db.transaction(async (trx) => {
      const rows = await trx(MENU).where({ ...scope, isDeleted: false }).select('id');
      const known = new Set(rows.map((r) => r.id));
      for (const item of items) {
        if (!known.has(item.id)) throw new AppError(`Menu ${item.id} not found in this company`, 404);
        if (item.parentId !== 0 && !known.has(item.parentId)) {
          throw new AppError(`Parent ${item.parentId} not found for menu ${item.id}`, 404);
        }
      }
      for (const item of items) {
        await trx(MENU).where({ ...scope, id: item.id }).update({
          parentId: item.parentId, order: item.order,
          updatedBy: ctx.userId ?? null, updatedAt: new Date(),
        });
      }
      return 'success';
    });
  },

  // Replace which roles can see one menu item.
  async setGrants(ctx, { id, roleIds }) {
    const scope = { tenantId: ctx.tenantId, companyId: ctx.companyId };
    return db.transaction(async (trx) => {
      const menu = await trx(MENU).where({ ...scope, id, isDeleted: false }).first();
      if (!menu) throw new AppError('Menu not found', 404);
      await trx(GRANT).where({ ...scope, id }).del();
      for (const roleId of roleIds) {
        await trx(GRANT).insert({ ...scope, id, roleId, isCategory: 0, updatedBy: ctx.userId ?? null, updatedAt: new Date() });
      }
      return 'success';
    });
  },
};

module.exports = repo;
