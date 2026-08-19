// Reorganize Petty Cash menu into Masters / Transactions / Reports groups:
//   Masters (new group)      -> Petty Cash Account (401), Petty Cash Expense
//                                Categories (403), Parameters (405)
//   Transactions (new group) -> IOU Request (415), IOU Issue (404),
//                                IOU Settlement (407)
//   Reports (416, unchanged)
// The old Settings group (417) becomes empty once its children move to
// Masters, so it is removed. Everything not mentioned (Dashboard, Payment
// Vouchers, Replenishments, Cash Counts, Approval Bands) stays top-level,
// ordered after Reports.

// ids 420/421 are hardcoded to stay clear of 20270706000002_seed_menu_manage.js,
// which computes its own menu id dynamically as max(id)+1 and previously landed
// on 418 in-sequence, colliding with this migration's original fixed id.
const MASTERS_GROUP = { id: 420, parentId: 400, route: '#', name: 'Masters', icon: 'bi bi-hdd-stack', isGroup: true };
const TRANSACTIONS_GROUP = { id: 421, parentId: 400, route: '#', name: 'Transactions', icon: 'bi bi-arrow-left-right', isGroup: true };

// (id, parentId, order, displayName)
const REORDER = [
  [410, 400,  1, 'Dashboard'],
  [420, 400,  2, 'Masters'],
  [421, 400,  3, 'Transactions'],
  [416, 400,  4, 'Reports'],
  [402, 400, 10, 'Payment Vouchers'],
  [408, 400, 11, 'Replenishments'],
  [409, 400, 12, 'Cash Counts'],
  [406, 400, 13, 'Approval Bands'],

  // Masters children (parentId=420)
  [401, 420, 1, 'Petty Cash Account'],
  [403, 420, 2, 'Petty Cash Expense Categories'],
  [405, 420, 3, 'Parameters'],

  // Transactions children (parentId=421)
  [415, 421, 1, 'IOU Request'],
  [404, 421, 2, 'IOU Issue'],
  [407, 421, 3, 'IOU Settlement'],
];

const GRANT_ROLES = [1, 2];
const NEW_GROUP_IDS = [420, 421];

async function scopeFor(knex) {
  const tenant = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  if (!tenant) return null;
  const company = await knex('sec_companies')
    .where({ tenantId: tenant.tenantId, companyName: 'Demo Company' })
    .first();
  if (!company) return null;
  return { tenantId: tenant.tenantId, companyId: company.companyId };
}

exports.up = async function (knex) {
  const scope = await scopeFor(knex);
  if (!scope) return;
  const admin = await knex('mas_users').where({ userName: 'admin' }).first();
  const updatedBy = admin ? admin.userId : null;
  const now = new Date();

  // 1. Insert the new Masters / Transactions groups
  for (const g of [MASTERS_GROUP, TRANSACTIONS_GROUP]) {
    const existing = await knex('sec_menu').where({ ...scope, id: g.id }).first();
    if (!existing) {
      await knex('sec_menu').insert({
        ...scope,
        id: g.id,
        parentId: g.parentId,
        route: g.route,
        displayName: g.name,
        icon: g.icon,
        order: g.id,
        isGroup: true,
        isActive: true,
        updatedBy,
        updatedAt: now,
      });
      await knex('sec_userMenu').insert(
        GRANT_ROLES.map((roleId) => ({ ...scope, id: g.id, roleId, isCategory: 0, updatedBy, updatedAt: now }))
      );
    }
  }

  // 2. Reparent + reorder + rename existing items
  for (const [id, parentId, order, displayName] of REORDER) {
    await knex('sec_menu').where({ ...scope, id }).update({ parentId, order, displayName, updatedBy, updatedAt: now });
  }

  // 3. Remove the now-empty Settings group (417)
  await knex('sec_userMenu').where({ ...scope, id: 417 }).del();
  await knex('sec_menu').where({ ...scope, id: 417 }).del();
};

exports.down = async function (knex) {
  const scope = await scopeFor(knex);
  if (!scope) return;
  const admin = await knex('mas_users').where({ userName: 'admin' }).first();
  const updatedBy = admin ? admin.userId : null;
  const now = new Date();

  // Restore the Settings group
  const settingsExisting = await knex('sec_menu').where({ ...scope, id: 417 }).first();
  if (!settingsExisting) {
    await knex('sec_menu').insert({
      ...scope, id: 417, parentId: 400, route: '#', displayName: 'Settings', icon: 'bi bi-gear',
      order: 417, isGroup: true, isActive: true, updatedBy, updatedAt: now,
    });
    await knex('sec_userMenu').insert(
      GRANT_ROLES.map((roleId) => ({ ...scope, id: 417, roleId, isCategory: 0, updatedBy, updatedAt: now }))
    );
  }

  // Restore original parentId / order / displayName
  const RESTORE = [
    [410, 400,  1, 'Dashboard'],
    [415, 400,  2, 'IOU Requests'],
    [404, 400,  3, 'IOU Advances'],
    [407, 400,  4, 'Settlements'],
    [401, 417, 10, 'Cash Books'],
    [403, 417, 11, 'Expense Categories'],
    [405, 417, 12, 'Parameters'],
    [402, 400, 60, 'Payment Vouchers'],
    [408, 400, 61, 'Replenishments'],
    [409, 400, 62, 'Cash Counts'],
    [406, 400, 63, 'Approval Bands'],
    [416, 400, 70, 'Reports'],
  ];
  for (const [id, parentId, order, displayName] of RESTORE) {
    await knex('sec_menu').where({ ...scope, id }).update({ parentId, order, displayName, updatedBy, updatedAt: now });
  }

  // Remove Masters / Transactions groups
  await knex('sec_userMenu').where(scope).whereIn('id', NEW_GROUP_IDS).del();
  await knex('sec_menu').where(scope).whereIn('id', NEW_GROUP_IDS).del();
};
