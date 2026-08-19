// Adds a "Legacy" menu group exposing the previous product's operational
// screens (Invoice, Advance, etc.) that still have routes but were dropped from
// the current menu. Granted to Admin/User. Ids use the 360-399 range.

const MENU = [
  { id: 360, parentId: 0,   route: '#',                     name: 'Legacy',               icon: 'bi bi-archive',                group: true },
  { id: 361, parentId: 360, route: '/business-partner',     name: 'Business Partners',    icon: 'bi bi-people' },
  { id: 362, parentId: 360, route: '/inquiry',              name: 'Inquiry',              icon: 'bi bi-question-circle' },
  { id: 363, parentId: 360, route: '/invoice',              name: 'Invoice',              icon: 'bi bi-receipt' },
  { id: 364, parentId: 360, route: '/tax-invoice',          name: 'Tax Invoice',          icon: 'bi bi-receipt-cutoff' },
  { id: 365, parentId: 360, route: '/advance',              name: 'Advance',              icon: 'bi bi-cash-coin' },
  { id: 366, parentId: 360, route: '/payment',              name: 'Payment',              icon: 'bi bi-credit-card' },
  { id: 367, parentId: 360, route: '/daily-report',         name: 'Daily Report',         icon: 'bi bi-journal-text' },
  { id: 368, parentId: 360, route: '/vehicle-confirmation', name: 'Vehicle Confirmation', icon: 'bi bi-truck' },
  { id: 369, parentId: 360, route: '/item-master',          name: 'Item Master',          icon: 'bi bi-box' },
  { id: 370, parentId: 360, route: '/uom-master',           name: 'UOM Master',           icon: 'bi bi-rulers' },
  { id: 371, parentId: 360, route: '/job-registration',     name: 'Job Registration',     icon: 'bi bi-clipboard-check' },
  { id: 372, parentId: 360, route: '/reports',              name: 'Reports (legacy)',     icon: 'bi bi-file-earmark-bar-graph' },
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

  // Idempotent: clear any prior run of this id range.
  await knex('sec_userMenu').where(scope).whereBetween('id', [360, 399]).del();
  await knex('sec_menu').where(scope).whereBetween('id', [360, 399]).del();

  await knex('sec_menu').insert(
    MENU.map((m, i) => ({
      ...scope,
      id: m.id,
      parentId: m.parentId,
      route: m.route,
      displayName: m.name,
      icon: m.icon,
      order: 360 + i,
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
  await knex('sec_userMenu').where(scope).whereBetween('id', [360, 399]).del();
  await knex('sec_menu').where(scope).whereBetween('id', [360, 399]).del();
};
