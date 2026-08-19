// Reorganize Petty Cash menu layout:
//   - Create "Settings" group (id=417) under Petty Cash
//   - Move Cash Books (401), Expense Categories (403), Parameters (405) under Settings
//   - Reorder all items to match the desired menu layout:
//       Dashboard → IOU Requests → IOU Advances → Settlements →
//       Settings (cash books, expense categories, parameters) →
//       Reports (party outstanding, cash book balances, iou aging, iou register)

const NEW_SETTINGS_GROUP = { id: 417, parentId: 400, route: '#', name: 'Settings', icon: 'bi bi-gear', isGroup: true };

// (id, parentId, order, displayName)
const REORDER = [
  // level-1 items under Petty Cash (400)
  [410, 400,  1, 'Dashboard'],
  [415, 400,  2, 'IOU Requests'],
  [404, 400,  3, 'IOU Advances'],
  [407, 400,  4, 'Settlements'],
  [417, 400,  5, 'Settings'],        // new group
  [402, 400, 60, 'Payment Vouchers'],
  [408, 400, 61, 'Replenishments'],
  [409, 400, 62, 'Cash Counts'],
  [406, 400, 63, 'Approval Bands'],
  [416, 400, 70, 'Reports'],

  // Settings children (parentId=417)
  [401, 417, 10, 'Cash Books'],
  [403, 417, 11, 'Expense Categories'],
  [405, 417, 12, 'Parameters'],

  // Reports children (parentId=416)
  [413, 416, 20, 'Party Outstanding'],
  [414, 416, 21, 'Cash Book Balances'],
  [412, 416, 22, 'IOU Aging'],
  [411, 416, 23, 'IOU Register'],
];

const GRANT_ROLES = [1, 2];

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

  // 1. Insert the new Settings group
  const existing = await knex('sec_menu').where({ ...scope, id: 417 }).first();
  if (!existing) {
    await knex('sec_menu').insert({
      ...scope,
      id: 417,
      parentId: NEW_SETTINGS_GROUP.parentId,
      route: NEW_SETTINGS_GROUP.route,
      displayName: NEW_SETTINGS_GROUP.name,
      icon: NEW_SETTINGS_GROUP.icon,
      order: NEW_SETTINGS_GROUP.id,
      isGroup: true,
      isActive: true,
      updatedBy,
      updatedAt: now,
    });
    // Grant to roles
    const grants = GRANT_ROLES.map((roleId) => ({ ...scope, id: 417, roleId, isCategory: 0, updatedBy, updatedAt: now }));
    await knex('sec_userMenu').insert(grants);
  }

  // 2. Reorder all items — update parentId + order for each
  for (const [id, parentId, order] of REORDER) {
    await knex('sec_menu').where({ ...scope, id }).update({ parentId, order, updatedBy, updatedAt: now });
  }
};

exports.down = async function (knex) {
  const scope = await scopeFor(knex);
  if (!scope) return;
  const admin = await knex('mas_users').where({ userName: 'admin' }).first();
  const updatedBy = admin ? admin.userId : null;
  const now = new Date();

  // Restore original parentIds and order=id
  const RESTORE = [
    [401, 400], [403, 400], [405, 400],  // move back under Petty Cash
    [410, 400], [415, 400], [404, 400], [407, 400],
    [402, 400], [408, 400], [409, 400], [406, 400],
    [416, 400],
    [411, 400], [412, 400], [413, 400], [414, 400],  // reports originally under 400
  ];

  for (const [id, parentId] of RESTORE) {
    await knex('sec_menu').where({ ...scope, id }).update({ parentId, order: id, updatedBy, updatedAt: now });
  }

  // Remove the Settings group (417)
  await knex('sec_userMenu').where({ ...scope, id: 417 }).del();
  await knex('sec_menu').where({ ...scope, id: 417 }).del();
};
