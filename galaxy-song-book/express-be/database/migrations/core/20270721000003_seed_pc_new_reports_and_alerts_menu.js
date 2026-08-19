// Demo-only report/alert screens (Summary, Detailed, Tracking, Analytical
// reports; Age-Analysis and Daily-Payments alerts). All render mock sample
// data client-side — see my-app/src/features/PettyCash/Reports/mockReportData.js
// — so no backend routes are needed yet, just menu entries.
//
// New reports go under the existing Reports group (id 416). New "Alerts"
// group is created under Petty Cash (id 400), granted the same roles as the
// other Petty Cash report/menu items in this stream.

const NEW_REPORTS = [
  { id: 480, parentId: 416, route: '/petty-cash/reports/summary', name: 'Summary Report', icon: 'bi bi-file-earmark-bar-graph', order: 30 },
  { id: 481, parentId: 416, route: '/petty-cash/reports/detailed', name: 'Detailed Report', icon: 'bi bi-file-earmark-text', order: 31 },
  { id: 482, parentId: 416, route: '/petty-cash/reports/tracking', name: 'Tracking Report', icon: 'bi bi-arrow-left-right', order: 32 },
  { id: 483, parentId: 416, route: '/petty-cash/reports/analytical', name: 'Analytical Report', icon: 'bi bi-graph-up', order: 33 },
];

const ALERTS_GROUP = { id: 484, parentId: 400, route: '#', name: 'Alerts', icon: 'bi bi-bell', order: 80 };

const NEW_ALERTS = [
  { id: 485, parentId: 484, route: '/petty-cash/alerts/age-analysis', name: 'Age-Analysis Alerts', icon: 'bi bi-hourglass-split', order: 1 },
  { id: 486, parentId: 484, route: '/petty-cash/alerts/daily-payments', name: 'Daily Payments Alert', icon: 'bi bi-envelope', order: 2 },
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

  for (const m of NEW_REPORTS) {
    const existing = await knex('sec_menu').where({ ...scope, route: m.route }).first();
    if (existing) continue;
    await knex('sec_menu').insert({
      ...scope, id: m.id, parentId: m.parentId, route: m.route, displayName: m.name,
      icon: m.icon, order: m.order, isGroup: false, isActive: true, updatedBy, updatedAt: now,
    });
    await knex('sec_userMenu').insert(
      GRANT_ROLES.map((roleId) => ({ ...scope, id: m.id, roleId, isCategory: 0, updatedBy, updatedAt: now }))
    );
  }

  const groupExisting = await knex('sec_menu').where({ ...scope, id: ALERTS_GROUP.id }).first();
  if (!groupExisting) {
    await knex('sec_menu').insert({
      ...scope, id: ALERTS_GROUP.id, parentId: ALERTS_GROUP.parentId, route: ALERTS_GROUP.route,
      displayName: ALERTS_GROUP.name, icon: ALERTS_GROUP.icon, order: ALERTS_GROUP.order,
      isGroup: true, isActive: true, updatedBy, updatedAt: now,
    });
    await knex('sec_userMenu').insert(
      GRANT_ROLES.map((roleId) => ({ ...scope, id: ALERTS_GROUP.id, roleId, isCategory: 0, updatedBy, updatedAt: now }))
    );
  }

  for (const m of NEW_ALERTS) {
    const existing = await knex('sec_menu').where({ ...scope, route: m.route }).first();
    if (existing) continue;
    await knex('sec_menu').insert({
      ...scope, id: m.id, parentId: m.parentId, route: m.route, displayName: m.name,
      icon: m.icon, order: m.order, isGroup: false, isActive: true, updatedBy, updatedAt: now,
    });
    await knex('sec_userMenu').insert(
      GRANT_ROLES.map((roleId) => ({ ...scope, id: m.id, roleId, isCategory: 0, updatedBy, updatedAt: now }))
    );
  }
};

exports.down = async function (knex) {
  const scope = await scopeFor(knex);
  if (!scope) return;
  const allIds = [...NEW_REPORTS, ALERTS_GROUP, ...NEW_ALERTS].map((m) => m.id);
  await knex('sec_userMenu').where(scope).whereIn('id', allIds).del();
  await knex('sec_menu').where(scope).whereIn('id', allIds).del();
};
