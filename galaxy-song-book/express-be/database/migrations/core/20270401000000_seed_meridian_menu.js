// Seeds the current (Galaxy ERP accounting) menu into sec_menu and grants it to
// the Admin/User roles in sec_userMenu, so the database-driven menu mirrors the
// static helpers/menuItems.js. Replaces the legacy menu grants for the demo
// tenant. Ids use the 300-399 range to avoid clashing with existing rows.
//
// Note: `down` removes only what this migration adds; it does not restore the
// old legacy grants (dev seed data, forward-only).

const MENU = [
  { id: 300, parentId: 0,   route: '/',                          name: 'Dashboard',                 icon: 'bi bi-grid-1x2',          group: false },

  { id: 310, parentId: 0,   route: '#',                          name: 'Accounting',                icon: 'bi bi-journal-text',      group: true  },
  { id: 311, parentId: 310, route: '/journals',                  name: 'Journal Entries',           icon: 'bi bi-journal-plus' },
  { id: 312, parentId: 310, route: '/ledger',                    name: 'General Ledger',            icon: 'bi bi-list-columns' },
  { id: 313, parentId: 310, route: '/coa',                       name: 'Chart of Accounts',         icon: 'bi bi-diagram-3' },

  { id: 320, parentId: 0,   route: '#',                          name: 'Reports',                   icon: 'bi bi-bar-chart',         group: true  },
  { id: 321, parentId: 320, route: '/reports/trial-balance',     name: 'Trial Balance',             icon: 'bi bi-table' },
  { id: 322, parentId: 320, route: '/reports/pnl',               name: 'P&L Statement',             icon: 'bi bi-graph-up' },
  { id: 323, parentId: 320, route: '/reports/balance-sheet',     name: 'Balance Sheet',             icon: 'bi bi-layout-split' },

  { id: 330, parentId: 0,   route: '#',                          name: 'Group Reports',             icon: 'bi bi-building',          group: true  },
  { id: 331, parentId: 330, route: '/group/pnl',                 name: 'Consolidated P&L',          icon: 'bi bi-graph-up-arrow' },
  { id: 332, parentId: 330, route: '/group/balance-sheet',       name: 'Consolidated Balance Sheet', icon: 'bi bi-layout-split' },
  { id: 333, parentId: 330, route: '/group/eliminations',        name: 'Elimination Report',        icon: 'bi bi-x-circle' },
  { id: 334, parentId: 330, route: '/group/fx-variance',         name: 'FX Variance',               icon: 'bi bi-currency-exchange' },

  { id: 340, parentId: 0,   route: '#',                          name: 'Settings',                  icon: 'bi bi-gear',              group: true  },
  { id: 341, parentId: 340, route: '/settings/tenants',          name: 'Tenants',                   icon: 'bi bi-buildings' },
  { id: 342, parentId: 340, route: '/settings/groups',           name: 'Groups',                    icon: 'bi bi-diagram-2' },
  { id: 343, parentId: 340, route: '/settings/companies',        name: 'Companies',                 icon: 'bi bi-building' },
  { id: 344, parentId: 340, route: '/settings/users',            name: 'Users & Roles',             icon: 'bi bi-people' },
  { id: 345, parentId: 340, route: '/settings/currencies',       name: 'Currencies',                icon: 'bi bi-currency-dollar' },
  { id: 346, parentId: 340, route: '/settings/exchange-rates',   name: 'Exchange Rates',            icon: 'bi bi-arrow-left-right' },
  { id: 347, parentId: 340, route: '/settings/account-types',    name: 'Account Types',             icon: 'bi bi-tag' },
  { id: 348, parentId: 340, route: '/settings/fiscal-year',      name: 'Fiscal Year',               icon: 'bi bi-calendar3' },
  { id: 349, parentId: 340, route: '/settings/report-templates', name: 'Report Templates',          icon: 'bi bi-file-text' },
  { id: 350, parentId: 340, route: '/audit-log',                 name: 'Audit Log',                 icon: 'bi bi-shield-lock' },
];

const GRANT_ROLES = [1, 2]; // Admin, User

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

  // init resolves the menu by roleId only (not by tenant), so legacy grants
  // under the placeholder '1'/'1' scope would still show. Clear Admin/User
  // grants across all scopes, then re-grant the current menu. Also clear any
  // prior run of this seed for idempotency.
  await knex('sec_userMenu').whereIn('roleId', GRANT_ROLES).del();
  await knex('sec_menu').where(scope).whereBetween('id', [300, 399]).del();

  await knex('sec_menu').insert(
    MENU.map((m, i) => ({
      ...scope,
      id: m.id,
      parentId: m.parentId,
      route: m.route,
      displayName: m.name,
      icon: m.icon,
      order: i,
      isGroup: !!m.group,
      isActive: true,
      updatedBy,
      updatedAt: now,
    }))
  );

  const grants = [];
  for (const roleId of GRANT_ROLES) {
    for (const m of MENU) {
      grants.push({ ...scope, id: m.id, roleId, isCategory: 0, updatedBy, updatedAt: now });
    }
  }
  await knex('sec_userMenu').insert(grants);
};

exports.down = async function (knex) {
  const scope = await scopeFor(knex);
  if (!scope) return;
  await knex('sec_userMenu').where(scope).whereBetween('id', [300, 399]).del();
  await knex('sec_menu').where(scope).whereBetween('id', [300, 399]).del();
};
