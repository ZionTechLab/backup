const db = require('../../database');

const TYPE_LABELS = { I: 'Create', E: 'Update', D: 'Delete', L: 'Login', O: 'Logout', R: 'Refresh', F: 'Login failed' };

// changedAt is stored as epoch-ms (SQLite). Normalise either shape to ms.
function toMs(v) {
  return typeof v === 'number' ? v : Date.parse(v);
}

// Build a tenant-scoped, filtered base query. `withUser` left-joins the actor.
function buildBase(f, withUser) {
  const q = db('sec_auditHistory as a');
  if (withUser) q.leftJoin('mas_users as u', 'u.userId', 'a.changedBy');

  q.where('a.tenantId', f.tenantId);
  if (f.tableName)  q.andWhere('a.tableName', f.tableName);
  if (f.changeType) q.andWhere('a.changeType', f.changeType);
  if (f.changedBy)  q.andWhere('a.changedBy', f.changedBy);
  if (f.recordId)   q.andWhere('a.recordId', f.recordId);

  const from = f.dateFrom ? Date.parse(`${f.dateFrom}T00:00:00`) : null;
  const to   = f.dateTo   ? Date.parse(`${f.dateTo}T23:59:59.999`) : null;
  if (from != null && !Number.isNaN(from)) q.andWhere('a.changedAt', '>=', from);
  if (to   != null && !Number.isNaN(to))   q.andWhere('a.changedAt', '<=', to);

  return q;
}

const repo = {
  // Aggregations for the dashboard. Done in JS so it stays dialect-agnostic;
  // audit volume is low. Push to SQL if it grows large.
  async getSummary(f) {
    const rows = await buildBase(f, true)
      .select('a.changeType', 'a.tableName', 'a.changedBy', 'a.changedAt', 'u.fullName');

    const byType = {}, byTable = {}, byUser = {}, byDay = {};
    for (const r of rows) {
      byType[r.changeType] = (byType[r.changeType] || 0) + 1;
      byTable[r.tableName] = (byTable[r.tableName] || 0) + 1;

      const uk = r.changedBy || 'unknown';
      byUser[uk] = byUser[uk] || { changedBy: r.changedBy, fullName: r.fullName || 'Unknown', count: 0 };
      byUser[uk].count += 1;

      const ms = toMs(r.changedAt);
      if (!Number.isNaN(ms)) {
        const day = new Date(ms).toISOString().slice(0, 10);
        byDay[day] = (byDay[day] || 0) + 1;
      }
    }

    return {
      total: rows.length,
      byType: Object.entries(byType)
        .map(([changeType, count]) => ({ changeType, label: TYPE_LABELS[changeType] || changeType, count })),
      byTable: Object.entries(byTable)
        .map(([tableName, count]) => ({ tableName, count }))
        .sort((a, b) => b.count - a.count),
      byUser: Object.values(byUser).sort((a, b) => b.count - a.count),
      byDay: Object.entries(byDay)
        .map(([day, count]) => ({ day, count }))
        .sort((a, b) => a.day.localeCompare(b.day)),
    };
  },

  // Paginated, filtered activity feed.
  async getAll(f) {
    const countRow = await buildBase(f, false).count({ n: 'a.historyId' }).first();
    const total = Number(countRow?.n || 0);

    const page = Math.max(1, Number(f.page) || 1);
    const pageSize = Math.min(200, Math.max(1, Number(f.pageSize) || 25));

    const rows = await buildBase(f, true)
      .select('a.historyId', 'a.tableName', 'a.recordId', 'a.changedBy', 'u.fullName', 'a.changedAt', 'a.changeType')
      .orderBy('a.changedAt', 'desc')
      .limit(pageSize)
      .offset((page - 1) * pageSize);

    return { rows, total, page, pageSize };
  },

  // Full change history for one record (oldest first), with snapshots for diffing.
  async getRecord(f) {
    return buildBase(f, true)
      .select('a.historyId', 'a.tableName', 'a.recordId', 'a.changedBy', 'u.fullName', 'a.changedAt', 'a.changeType', 'a.snapshot')
      .orderBy('a.changedAt', 'asc');
  },
};

module.exports = repo;
