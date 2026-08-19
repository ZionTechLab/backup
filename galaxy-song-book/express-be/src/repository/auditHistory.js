const db = require('../database');

const TYPE_MAP = { INSERT: 'I', UPDATE: 'E', DELETE: 'D' };

// Default tenant for a user, used to scope auth events. Best-effort.
async function defaultTenantId(userId) {
  if (!userId) return null;
  const row = await db('sec_userTenants')
    .where({ userId: String(userId) })
    .orderBy('isDefault', 'desc')
    .first('tenantId');
  return row?.tenantId ?? null;
}

// Records an authentication event (login/logout/refresh/failed) into the same
// audit table, with tableName 'auth'. Never throws — auth must not break if the
// audit write fails. changeType: 'L' login, 'O' logout, 'R' refresh, 'F' failed.
async function logAuthEvent({ userId = null, recordId = null, changeType, meta = {} }) {
  try {
    const tenantId = userId ? await defaultTenantId(userId) : null;
    await db('sec_auditHistory').insert({
      tableName:  'auth',
      recordId:   String(recordId ?? userId ?? ''),
      tenantId,
      changedBy:  userId != null ? String(userId) : null,
      changedAt:  new Date(),
      changeType,
      snapshot:   JSON.stringify(meta),
    });
  } catch (e) {
    // swallow: audit logging must never block authentication
  }
}

// The audit recordId is the first non-boolean value in the where clause (the PK).
function recordIdFrom(where) {
  return String(Object.entries(where).find(([, v]) => typeof v !== 'boolean')?.[1] ?? '');
}

// Writes one audit row snapshotting `row` as JSON.
async function writeSnapshot(trx, table, recordId, row, userId, changeType) {
  await trx('sec_auditHistory').insert({
    tableName:  table,
    recordId,
    tenantId:   row.tenantId != null ? String(row.tenantId) : null,
    changedBy:  userId != null ? String(userId) : null,
    changedAt:  new Date(),
    changeType: TYPE_MAP[changeType] ?? String(changeType).charAt(0),
    snapshot:   JSON.stringify(row),
  });
}

// Before an update or delete: snapshot the current (pre-change) row.
async function snapshotBefore(trx, table, where, userId, changeType = 'UPDATE') {
  const existing = await trx(table).where(where).first();
  if (!existing) return null;
  await writeSnapshot(trx, table, recordIdFrom(where), existing, userId, changeType);
  return existing;
}

// After an insert: snapshot the newly created row as an INSERT ('I') entry.
// Call inside the same transaction, right after the insert, so creation shows in
// the audit trail. where is the new row's PK (e.g. { iouId }).
async function snapshotInsert(trx, table, where, userId) {
  const created = await trx(table).where(where).first();
  if (!created) return null;
  await writeSnapshot(trx, table, recordIdFrom(where), created, userId, 'INSERT');
  return created;
}

module.exports = { snapshotBefore, snapshotInsert, logAuthEvent };
