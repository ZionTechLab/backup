// Consolidated Petty Cash menu seed — all menu items in one migration.
// Covers ids 400-415 under the demo tenant/company. Idempotent.
// Formerly split across 10 separate seed files.

const MENUS = [
  // Parent group + Cash Books
  { id: 400, parentId: 0,   route: '#',                           name: 'Petty Cash',        icon: 'bi bi-cash-stack',        group: true },
  { id: 401, parentId: 400, route: '/petty-cash/cash-book',       name: 'Cash Books',         icon: 'bi bi-wallet2' },
  // Payment Vouchers
  { id: 402, parentId: 400, route: '/petty-cash/voucher',         name: 'Payment Vouchers',   icon: 'bi bi-receipt' },
  // Expense Categories
  { id: 403, parentId: 400, route: '/petty-cash/expense-category',name: 'Expense Categories',  icon: 'bi bi-tags' },
  // IOU Advances
  { id: 404, parentId: 400, route: '/petty-cash/iou',             name: 'IOU Advances',       icon: 'bi bi-cash-coin' },
  // Settings sub-menu
  { id: 405, parentId: 400, route: '/petty-cash/param',           name: 'Parameters',         icon: 'bi bi-sliders' },
  { id: 406, parentId: 400, route: '/petty-cash/approval-band',   name: 'Approval Bands',     icon: 'bi bi-diagram-3' },
  // Settlements
  { id: 407, parentId: 400, route: '/petty-cash/settlement',      name: 'IOU Settlements',    icon: 'bi bi-check2-square' },
  // Replenishments
  { id: 408, parentId: 400, route: '/petty-cash/replenishment',   name: 'Replenishments',     icon: 'bi bi-arrow-repeat' },
  // Cash Counts
  { id: 409, parentId: 400, route: '/petty-cash/cash-count',      name: 'Cash Counts',        icon: 'bi bi-calculator' },
  // Reports
  { id: 410, parentId: 400, route: '/petty-cash/dashboard',              name: 'Dashboard',            icon: 'bi bi-speedometer2' },
  { id: 411, parentId: 400, route: '/petty-cash/reports/iou-register',    name: 'IOU Register',         icon: 'bi bi-list-ul' },
  { id: 412, parentId: 400, route: '/petty-cash/reports/iou-aging',       name: 'IOU Aging',            icon: 'bi bi-hourglass-split' },
  { id: 413, parentId: 400, route: '/petty-cash/reports/party-outstanding',name: 'Party Outstanding',    icon: 'bi bi-people' },
  { id: 414, parentId: 400, route: '/petty-cash/reports/cashbook-balances',name: 'Cash Book Balances',   icon: 'bi bi-wallet2' },
  // IOU Requests
  { id: 415, parentId: 400, route: '/petty-cash/iou-request',      name: 'IOU Requests',       icon: 'bi bi-file-earmark-text' },
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

  // Wipe all petycash menu ids (400-415) — then re-insert fresh.
  const menuIds = MENUS.map((m) => m.id);
  await knex('sec_userMenu').where(scope).whereIn('id', menuIds).del();
  await knex('sec_menu').where(scope).whereIn('id', menuIds).del();

  await knex('sec_menu').insert(
    MENUS.map((m) => ({
      ...scope,
      id: m.id,
      parentId: m.parentId,
      route: m.route,
      displayName: m.name,
      icon: m.icon,
      order: m.id,
      isGroup: !!m.group,
      isActive: true,
      updatedBy,
      updatedAt: now,
    }))
  );

  const grants = [];
  for (const roleId of GRANT_ROLES) {
    for (const m of MENUS) {
      grants.push({ ...scope, id: m.id, roleId, isCategory: 0, updatedBy, updatedAt: now });
    }
  }
  await knex('sec_userMenu').insert(grants);
};

exports.down = async function (knex) {
  const scope = await scopeFor(knex);
  if (!scope) return;
  const menuIds = MENUS.map((m) => m.id);
  await knex('sec_userMenu').where(scope).whereIn('id', menuIds).del();
  await knex('sec_menu').where(scope).whereIn('id', menuIds).del();
};
