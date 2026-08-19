// Reorganize the main menu layout as per the 2026-07-06 spec:
//
//   Dashboard
//   Admin (new group)
//     Tenants, Groups, Companies, Permission Groups, Roles,
//     Users & Roles, Approval Levels, Audit Logs
//   Masters (new group)
//     Currencies, Exchange Rates, Account Types
//   Accounts (renamed from Accounting; children: Journal Entries,
//     General Ledger, Chart of Accounts)
//   Petty Cash
//     Settings → Petty Cash Accounts, Petty Cash Categories, Params
//     Reports → (as-is: Party Outstanding, Cash Book Balances,
//       IOU Aging, IOU Register)
//     IOU Request, IOU Issue, IOU Settlement
//   My Approvals
//
// All other menu items are hidden (isActive = false).
// Also removes their sec_userMenu grants so they don't leak via
// the role-based join.
//
// Idempotent — safe to re-run.

// ── New Admin & Masters groups ──────────────────────────────────────────────
const ADMIN_GROUP   = { id: 301, parentId: 0, route: '#', name: 'Admin',   icon: 'bi bi-shield-lock',   isGroup: true };
const MASTERS_GROUP = { id: 302, parentId: 0, route: '#', name: 'Masters', icon: 'bi bi-gear-wide-connected', isGroup: true };

// ── Items that move under Admin (301) ───────────────────────────────────────
const ADMIN_CHILDREN = [
  { id: 341, name: 'Tenants' },
  { id: 342, name: 'Groups' },
  { id: 343, name: 'Companies' },
  { id: 351, name: 'Permission Groups' },
  { id: 352, name: 'Roles' },
  { id: 344, name: 'Users & Roles' },
  { id: 353, name: 'Approval Levels' },
  { id: 350, name: 'Audit Logs' },
];

// ── Items that move under Masters (302) ─────────────────────────────────────
const MASTERS_CHILDREN = [
  { id: 345, name: 'Currencies' },
  { id: 346, name: 'Exchange Rates' },
  { id: 347, name: 'Account Types' },
];

// ── Items that stay under Accounting→Accounts (310) ─────────────────────────
const ACCOUNTS_CHILDREN = [
  { id: 311, name: 'Journal Entries' },
  { id: 312, name: 'General Ledger' },
  { id: 313, name: 'Chart of Accounts' },
];

// ── Petty Cash: direct-level children (not in Settings or Reports) ──────────
const PC_TOP = [
  { id: 415, name: 'IOU Request',    route: '/petty-cash/iou-request' },
  { id: 404, name: 'IOU Issue',      route: '/petty-cash/iou' },
  { id: 407, name: 'IOU Settlement', route: '/petty-cash/settlement' },
];

// ── Petty Cash: Settings children ───────────────────────────────────────────
const PC_SETTINGS = [
  { id: 401, name: 'Petty Cash Accounts',  route: '/petty-cash/cash-book' },
  { id: 403, name: 'Petty Cash Categories', route: '/petty-cash/expense-category' },
  { id: 405, name: 'Parameters',           route: '/petty-cash/param' },
];

// ── Petty Cash: Reports children (as-is) ────────────────────────────────────
const PC_REPORTS = [
  { id: 413, name: 'Party Outstanding',   route: '/petty-cash/reports/party-outstanding' },
  { id: 414, name: 'Cash Book Balances',  route: '/petty-cash/reports/cashbook-balances' },
  { id: 412, name: 'IOU Aging',           route: '/petty-cash/reports/iou-aging' },
  { id: 411, name: 'IOU Register',        route: '/petty-cash/reports/iou-register' },
];

// ── IDs to HIDE (isActive = false) ──────────────────────────────────────────
const HIDDEN_IDS = [
  // Old dashboard
  10,
  // Master Files group + children
  130, 140, 150,
  // References group
  160,
  // Employee Master (hrm)
  200,
  // Group Reports group + children
  330, 331, 332, 333, 334,
  // Old Settings parent (items moved to Admin/Masters)
  340,
  // Fiscal Year, Report Templates (removed from menu)
  348, 349,
  // Legacy group + children
  360, 361, 362, 363, 364, 365, 366, 367, 368, 369, 370, 371, 372,
  // Petty Cash: hidden items
  402, 406, 408, 409, 410,
];

// ── IDs that get sec_userMenu grants ─────────────────────────────────────────
// Group items MUST have grants too, otherwise buildMenuTree won't nest
// children under them (the parent won't appear in the flat list).
const GRANT_IDS = [
  // Top-level
  300,       // Dashboard
  301, 302,  // Admin (group), Masters (group)
  310,       // Accounts (group)
  // Admin children
  341, 342, 343, 351, 352, 344, 353, 350,
  // Masters children
  345, 346, 347,
  // Accounts children
  311, 312, 313,
  // My Approvals
  305,
  // Petty Cash group + sub-groups + children
  400,       // Petty Cash (group)
  417,       // Settings (group)
  401, 403, 405,  // Settings children
  416,       // Reports (group)
  413, 414, 412, 411,  // Reports children
  415, 404, 407,  // PC direct children
];

const GRANT_ROLES = [1, 2]; // Admin, User

// ── Helpers ─────────────────────────────────────────────────────────────────

async function scopeFor(knex) {
  const tenant = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  if (!tenant) return null;
  const company = await knex('sec_companies')
    .where({ tenantId: tenant.tenantId, companyName: 'Demo Company' })
    .first();
  if (!company) return null;
  return { tenantId: tenant.tenantId, companyId: company.companyId };
}

// ── up ──────────────────────────────────────────────────────────────────────

exports.up = async function (knex) {
  const scope = await scopeFor(knex);
  if (!scope) return;
  const admin = await knex('mas_users').where({ userName: 'admin' }).first();
  const updatedBy = admin ? admin.userId : null;
  const now = new Date();

  // 1. Insert the two new groups (idempotent)
  for (const g of [ADMIN_GROUP, MASTERS_GROUP]) {
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
    }
  }

  // 2. Reparent Admin children → 301
  for (let i = 0; i < ADMIN_CHILDREN.length; i++) {
    const m = ADMIN_CHILDREN[i];
    await knex('sec_menu').where({ ...scope, id: m.id }).update({
      parentId: 301,
      order: 10 + i,
      displayName: m.name,
      updatedBy,
      updatedAt: now,
    });
  }

  // 3. Reparent Masters children → 302
  for (let i = 0; i < MASTERS_CHILDREN.length; i++) {
    const m = MASTERS_CHILDREN[i];
    await knex('sec_menu').where({ ...scope, id: m.id }).update({
      parentId: 302,
      order: 10 + i,
      displayName: m.name,
      updatedBy,
      updatedAt: now,
    });
  }

  // 4. Rename Accounting → Accounts, keep children under it
  await knex('sec_menu').where({ ...scope, id: 310 }).update({
    displayName: 'Accounts',
    isGroup: true,
    isActive: true,
    order: 4,
    updatedBy,
    updatedAt: now,
  });
  for (let i = 0; i < ACCOUNTS_CHILDREN.length; i++) {
    const m = ACCOUNTS_CHILDREN[i];
    await knex('sec_menu').where({ ...scope, id: m.id }).update({
      parentId: 310,
      order: 10 + i,
      displayName: m.name,
      updatedBy,
      updatedAt: now,
    });
  }

  // 5. Reorder Petty Cash children
  // Settings (417) stays under 400
  await knex('sec_menu').where({ ...scope, id: 417 }).update({ parentId: 400, order: 10, updatedBy, updatedAt: now });
  // Settings children
  for (let i = 0; i < PC_SETTINGS.length; i++) {
    const m = PC_SETTINGS[i];
    await knex('sec_menu').where({ ...scope, id: m.id }).update({
      parentId: 417,
      order: 10 + i,
      displayName: m.name,
      updatedBy,
      updatedAt: now,
    });
  }

  // Reports (416) stays under 400
  await knex('sec_menu').where({ ...scope, id: 416 }).update({ parentId: 400, order: 20, updatedBy, updatedAt: now });
  // Reports children (as-is)
  for (let i = 0; i < PC_REPORTS.length; i++) {
    const m = PC_REPORTS[i];
    await knex('sec_menu').where({ ...scope, id: m.id }).update({
      parentId: 416,
      order: 20 + i,
      displayName: m.name,
      updatedBy,
      updatedAt: now,
    });
  }

  // Direct PC children: IOU Request, IOU Issue, IOU Settlement
  for (let i = 0; i < PC_TOP.length; i++) {
    const m = PC_TOP[i];
    await knex('sec_menu').where({ ...scope, id: m.id }).update({
      parentId: 400,
      order: 30 + i,
      displayName: m.name,
      updatedBy,
      updatedAt: now,
    });
  }

  // 6. Dashboard & My Approvals — keep active, set order
  await knex('sec_menu').where({ ...scope, id: 300 }).update({ order: 1, isGroup: false, isActive: true, updatedBy, updatedAt: now });
  await knex('sec_menu').where({ ...scope, id: 305 }).update({ order: 60, isActive: true, updatedBy, updatedAt: now });

  // 7. Hide everything else
  if (HIDDEN_IDS.length > 0) {
    await knex('sec_menu').where(scope).whereIn('id', HIDDEN_IDS).update({
      isActive: false,
      updatedBy,
      updatedAt: now,
    });
  }

  // 8. Wipe ALL existing grants for the demo scope and re-grant only
  //    what should be visible. This keeps the join result clean.
  await knex('sec_userMenu').where(scope).del();

  const grants = [];
  for (const roleId of GRANT_ROLES) {
    for (const id of GRANT_IDS) {
      grants.push({ ...scope, id, roleId, isCategory: 0, updatedBy, updatedAt: now });
    }
  }
  if (grants.length > 0) {
    await knex('sec_userMenu').insert(grants);
  }
};

// ── down ────────────────────────────────────────────────────────────────────

exports.down = async function (knex) {
  const scope = await scopeFor(knex);
  if (!scope) return;
  const admin = await knex('mas_users').where({ userName: 'admin' }).first();
  const updatedBy = admin ? admin.userId : null;
  const now = new Date();

  // Remove the two new groups
  await knex('sec_menu').where(scope).whereIn('id', [301, 302]).del();

  // Restore Admin children back to 340 (old Settings)
  for (const m of ADMIN_CHILDREN) {
    await knex('sec_menu').where({ ...scope, id: m.id }).update({
      parentId: 340,
      order: m.id,
      updatedBy,
      updatedAt: now,
    });
  }

  // Restore Masters children back to 340
  for (const m of MASTERS_CHILDREN) {
    await knex('sec_menu').where({ ...scope, id: m.id }).update({
      parentId: 340,
      order: m.id,
      updatedBy,
      updatedAt: now,
    });
  }

  // Restore Accounting name
  await knex('sec_menu').where({ ...scope, id: 310 }).update({
    displayName: 'Accounting',
    order: 310,
    updatedBy,
    updatedAt: now,
  });

  // Restore hidden items
  if (HIDDEN_IDS.length > 0) {
    await knex('sec_menu').where(scope).whereIn('id', HIDDEN_IDS).update({
      isActive: true,
      updatedBy,
      updatedAt: now,
    });
  }

  // Restore old Settings group
  await knex('sec_menu').where({ ...scope, id: 340 }).update({ isActive: true, isGroup: true, updatedBy, updatedAt: now });

  // Restore Petty Cash items to original names / parents
  // Settings children original names
  const PC_SETTINGS_ORIG = [
    { id: 401, name: 'Cash Books' },
    { id: 403, name: 'Expense Categories' },
    { id: 405, name: 'Parameters' },
  ];
  for (const m of PC_SETTINGS_ORIG) {
    await knex('sec_menu').where({ ...scope, id: m.id }).update({
      displayName: m.name,
      order: m.id,
      updatedBy,
      updatedAt: now,
    });
  }

  // PC top children restore
  const PC_TOP_ORIG = [
    { id: 415, name: 'IOU Requests' },
    { id: 404, name: 'IOU Issues' },
    { id: 407, name: 'IOU Settlements' },
  ];
  for (const m of PC_TOP_ORIG) {
    await knex('sec_menu').where({ ...scope, id: m.id }).update({
      displayName: m.name,
      order: m.id,
      updatedBy,
      updatedAt: now,
    });
  }

  // Note: full grant restoration would need to re-run prior seed migrations.
  // down() here just restores menu structure; re-run seeds for grants.
};
