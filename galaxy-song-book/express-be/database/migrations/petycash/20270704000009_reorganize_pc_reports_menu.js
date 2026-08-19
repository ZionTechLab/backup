// Reorganize PC Reports: add a "Reports" group (id=416) under Petty Cash
// and re-parent existing report items (411-414) under the new group.
// This enables 3-level menu nesting: Petty Cash → Reports → (individual reports)

const REPORTS_GROUP = { id: 416, parentId: 400, route: '#', name: 'Reports', icon: 'bi bi-bar-chart', group: true };

const REPARENTED = [
  { id: 411, parentId: 416, route: '/petty-cash/reports/iou-register',     name: 'IOU Register',       icon: 'bi bi-list-ul' },
  { id: 412, parentId: 416, route: '/petty-cash/reports/iou-aging',        name: 'IOU Aging',          icon: 'bi bi-hourglass-split' },
  { id: 413, parentId: 416, route: '/petty-cash/reports/party-outstanding', name: 'Party Outstanding',  icon: 'bi bi-people' },
  { id: 414, parentId: 416, route: '/petty-cash/reports/cashbook-balances', name: 'Cash Book Balances', icon: 'bi bi-wallet2' },
];

const ALL_IDS = [416, 411, 412, 413, 414];
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

  // 1. Wipe existing entries for affected ids
  await knex('sec_userMenu').where(scope).whereIn('id', ALL_IDS).del();
  await knex('sec_menu').where(scope).whereIn('id', ALL_IDS).del();

  // 2. Insert the new Reports group
  await knex('sec_menu').insert({
    ...scope,
    id: REPORTS_GROUP.id,
    parentId: REPORTS_GROUP.parentId,
    route: REPORTS_GROUP.route,
    displayName: REPORTS_GROUP.name,
    icon: REPORTS_GROUP.icon,
    order: REPORTS_GROUP.id,
    isGroup: true,
    isActive: true,
    updatedBy,
    updatedAt: now,
  });

  // 3. Insert re-parented report items (now under Reports group)
  await knex('sec_menu').insert(
    REPARENTED.map((m) => ({
      ...scope,
      id: m.id,
      parentId: m.parentId,
      route: m.route,
      displayName: m.name,
      icon: m.icon,
      order: m.id,
      isGroup: false,
      isActive: true,
      updatedBy,
      updatedAt: now,
    }))
  );

  // 4. Grant all to relevant roles
  const allMenus = [REPORTS_GROUP, ...REPARENTED];
  const grants = [];
  for (const roleId of GRANT_ROLES) {
    for (const m of allMenus) {
      grants.push({ ...scope, id: m.id, roleId, isCategory: 0, updatedBy, updatedAt: now });
    }
  }
  await knex('sec_userMenu').insert(grants);
};

exports.down = async function (knex) {
  const scope = await scopeFor(knex);
  if (!scope) return;

  // Restore 411-414 back under parentId=400
  const restored = [
    { id: 411, parentId: 400, route: '/petty-cash/reports/iou-register',     name: 'IOU Register',       icon: 'bi bi-list-ul' },
    { id: 412, parentId: 400, route: '/petty-cash/reports/iou-aging',        name: 'IOU Aging',          icon: 'bi bi-hourglass-split' },
    { id: 413, parentId: 400, route: '/petty-cash/reports/party-outstanding', name: 'Party Outstanding',  icon: 'bi bi-people' },
    { id: 414, parentId: 400, route: '/petty-cash/reports/cashbook-balances', name: 'Cash Book Balances', icon: 'bi bi-wallet2' },
  ];

  await knex('sec_userMenu').where(scope).whereIn('id', ALL_IDS).del();
  await knex('sec_menu').where(scope).whereIn('id', ALL_IDS).del();

  const admin = await knex('mas_users').where({ userName: 'admin' }).first();
  const updatedBy = admin ? admin.userId : null;
  const now = new Date();

  await knex('sec_menu').insert(
    restored.map((m) => ({
      ...scope,
      id: m.id,
      parentId: m.parentId,
      route: m.route,
      displayName: m.name,
      icon: m.icon,
      order: m.id,
      isGroup: false,
      isActive: true,
      updatedBy,
      updatedAt: now,
    }))
  );

  const grants = [];
  for (const roleId of GRANT_ROLES) {
    for (const m of restored) {
      grants.push({ ...scope, id: m.id, roleId, isCategory: 0, updatedBy, updatedAt: now });
    }
  }
  await knex('sec_userMenu').insert(grants);
};
