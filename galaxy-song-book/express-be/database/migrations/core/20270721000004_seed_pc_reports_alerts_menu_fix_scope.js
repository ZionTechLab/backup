// 20270721000003 silently no-op'd: its scopeFor() looked up tenant 'demo' +
// a company literally named 'Demo Company', which no longer exists (that
// company was renamed/reassigned earlier this session — see
// 20270720000002_fix_stale_tenant_refs_for_reassigned_company.js). The
// migration recorded as "applied" but inserted nothing.
//
// Fix: target every (tenantId, companyId) pair that already has real
// sec_menu rows — i.e. every scope actually in live use — instead of a
// brittle hardcoded name lookup. Idempotent against 20270721000003 (skips
// any route that's already present in a given scope).

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

async function liveScopes(knex) {
  return knex('sec_menu').select('tenantId', 'companyId').distinct();
}

exports.up = async function (knex) {
  const scopes = await liveScopes(knex);
  if (!scopes.length) return;

  const admin = await knex('mas_users').where({ userName: 'admin' }).first();
  const updatedBy = admin ? admin.userId : null;
  const now = new Date();

  for (const scope of scopes) {
    for (const m of NEW_REPORTS) {
      const existing = await knex('sec_menu').where({ ...scope, route: m.route }).first();
      if (existing) continue;
      const idTaken = await knex('sec_menu').where({ ...scope, id: m.id }).first();
      if (idTaken) continue;
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
      const idTaken = await knex('sec_menu').where({ ...scope, id: m.id }).first();
      if (idTaken) continue;
      await knex('sec_menu').insert({
        ...scope, id: m.id, parentId: m.parentId, route: m.route, displayName: m.name,
        icon: m.icon, order: m.order, isGroup: false, isActive: true, updatedBy, updatedAt: now,
      });
      await knex('sec_userMenu').insert(
        GRANT_ROLES.map((roleId) => ({ ...scope, id: m.id, roleId, isCategory: 0, updatedBy, updatedAt: now }))
      );
    }
  }
};

exports.down = async function (knex) {
  const scopes = await liveScopes(knex);
  const allIds = [...NEW_REPORTS, ALERTS_GROUP, ...NEW_ALERTS].map((m) => m.id);
  for (const scope of scopes) {
    await knex('sec_userMenu').where(scope).whereIn('id', allIds).del();
    await knex('sec_menu').where(scope).whereIn('id', allIds).del();
  }
};
