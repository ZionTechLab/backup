const fs = require('fs');
const path = require('path');
const archiver = require('archiver');
const AdmZip = require('adm-zip');
const db = require('../../database');
const { AppError } = require('../../middleware/errorHandler');

const REGISTRY_TABLE = 'conf_backupTable';
const INSERT_CHUNK = 200;

// Tables excluded from a full-database export/restore: knex's own
// bookkeeping and this registry itself add no restore value.
const SYSTEM_EXCLUDE = new Set(['sqlite_sequence']);
const isKnexTable = (name) => name.startsWith('knex_migrations');

const SAFETY_DIR = path.join(__dirname, '..', '..', '..', 'database', 'backup-restore-safety');

async function getModules() {
  const rows = await db(REGISTRY_TABLE).where({ isActive: true }).select('moduleCode').distinct();
  const codes = rows.map((r) => r.moduleCode);
  if (!codes.length) return [];
  const modules = await db('sec_module').whereIn('moduleCode', codes).select('moduleCode', 'moduleName');
  const counts = await db(REGISTRY_TABLE).where({ isActive: true }).whereIn('moduleCode', codes)
    .select('moduleCode').count('id as tableCount').groupBy('moduleCode');
  const countMap = Object.fromEntries(counts.map((c) => [c.moduleCode, Number(c.tableCount)]));
  return modules.map((m) => ({ ...m, tableCount: countMap[m.moduleCode] || 0 }));
}

// Registry rows for a scope, parents-first (ascending sortOrder). Pulls in
// a child row's parent even if the parent's own module wasn't selected, so
// the join used to scope the child can always resolve.
async function resolveRegistryPlan(scope, moduleCodes) {
  let query = db(REGISTRY_TABLE).where({ isActive: true }).orderBy('sortOrder');
  if (scope === 'module') {
    if (!moduleCodes.length) throw new AppError('Select at least one module', 400);
    query = query.whereIn('moduleCode', moduleCodes);
  }
  const registryRows = await query;
  if (!registryRows.length) throw new AppError('Nothing to export for this scope', 400);
  const registryByTable = new Map(registryRows.map((r) => [r.tableName, r]));
  for (const row of registryRows) {
    if (row.scopeType === 'child' && !registryByTable.has(row.parentTable)) {
      const parent = await db(REGISTRY_TABLE).where({ tableName: row.parentTable }).first();
      if (parent) registryByTable.set(parent.tableName, parent);
    }
  }
  return { registryRows, registryByTable };
}

// Unresolved query builder for one registry-listed table, scoped to a
// tenant/company per its scopeType. `child` tables have no tenant column of
// their own, so they're scoped by joining their parent's already-scoped id
// set. Caller terminates with .select('*'), .del(), or .count().
function scopedQuery(row, ctx, registryByTable) {
  const { tableName, scopeType, parentTable, parentKey } = row;
  if (scopeType === 'tenantCompany') return db(tableName).where({ tenantId: ctx.tenantId, companyId: ctx.companyId });
  if (scopeType === 'tenantOnly') return db(tableName).where({ tenantId: ctx.tenantId });
  if (scopeType === 'company') return db(tableName).where({ companyId: ctx.companyId });
  if (scopeType === 'child') {
    const parentRow = registryByTable.get(parentTable);
    if (!parentRow) throw new AppError(`Backup registry: parent table ${parentTable} not registered`, 500);
    const parentIds = db(parentTable).where(
      parentRow.scopeType === 'tenantCompany' ? { tenantId: ctx.tenantId, companyId: ctx.companyId }
        : parentRow.scopeType === 'tenantOnly' ? { tenantId: ctx.tenantId }
          : { companyId: ctx.companyId }
    ).select(parentKey);
    return db(tableName).whereIn(parentKey, parentIds);
  }
  throw new AppError(`Backup registry: unknown scopeType ${scopeType} for ${tableName}`, 500);
}

async function listAllTableNames() {
  const client = db.client.config.client;
  if (client === 'mysql' || client === 'mysql2') {
    const rows = await db.raw('SELECT table_name AS name FROM information_schema.tables WHERE table_schema = DATABASE()');
    return rows[0].map((r) => r.name);
  }
  const rows = await db.raw("SELECT name FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%'");
  return rows.map((r) => r.name);
}

// Writes manifest.json + tables/<name>.json into `archive` for the given
// scope. Shared by the download endpoint and the pre-restore safety
// snapshot. Returns the manifest that was written.
async function writeExportArchive(ctx, { scope, moduleCodes }, archive) {
  let tableSpecs; // [{ name, rowsFn: () => Promise<row[]> }]

  if (scope === 'full') {
    const names = (await listAllTableNames())
      .filter((n) => !isKnexTable(n) && !SYSTEM_EXCLUDE.has(n) && n !== REGISTRY_TABLE);
    tableSpecs = names.map((name) => ({ name, rowsFn: () => db(name).select('*') }));
  } else {
    const { registryRows, registryByTable } = await resolveRegistryPlan(scope, moduleCodes);
    tableSpecs = registryRows.map((row) => ({
      name: row.tableName,
      rowsFn: () => scopedQuery(row, ctx, registryByTable).select('*'),
    }));
  }

  const manifestTables = [];
  for (const spec of tableSpecs) {
    const rows = await spec.rowsFn();
    manifestTables.push({ name: spec.name, rowCount: rows.length });
    archive.append(JSON.stringify(rows, null, 2), { name: `tables/${spec.name}.json` });
  }

  const manifest = {
    exportedAt: new Date().toISOString(),
    scope,
    moduleCodes: scope === 'module' ? moduleCodes : undefined,
    tenantId: scope === 'full' ? undefined : ctx.tenantId,
    companyId: scope === 'full' ? undefined : ctx.companyId,
    tables: manifestTables,
  };
  archive.append(JSON.stringify(manifest, null, 2), { name: 'manifest.json' });
  return manifest;
}

// Streams a zip straight to the HTTP response.
async function streamExport(ctx, { scope, moduleCodes }, res) {
  const archive = archiver('zip', { zlib: { level: 9 } });
  archive.on('error', (err) => { throw err; });
  archive.pipe(res);
  await writeExportArchive(ctx, { scope, moduleCodes }, archive);
  await archive.finalize();
}

// Writes a timestamped zip to a private on-disk folder before a restore
// wipes anything — the only undo path if a restore turns out to be wrong.
async function writeSafetySnapshot(ctx, { scope, moduleCodes }) {
  if (!fs.existsSync(SAFETY_DIR)) fs.mkdirSync(SAFETY_DIR, { recursive: true });
  const filename = `pre-restore-${scope}-${Date.now()}.zip`;
  const filePath = path.join(SAFETY_DIR, filename);
  const out = fs.createWriteStream(filePath);
  const archive = archiver('zip', { zlib: { level: 9 } });
  archive.on('error', (err) => { throw err; });
  archive.pipe(out);
  await writeExportArchive(ctx, { scope, moduleCodes }, archive);
  await archive.finalize();
  await new Promise((resolve, reject) => { out.on('close', resolve); out.on('error', reject); });
  return filePath;
}

// Reads an uploaded backup zip: the manifest plus a lazy per-table row
// reader (returns null if that table wasn't included in the backup).
function loadZip(filePath) {
  let zip;
  try {
    zip = new AdmZip(filePath);
  } catch {
    throw new AppError('Could not read the uploaded file as a zip', 400);
  }
  const manifestEntry = zip.getEntry('manifest.json');
  if (!manifestEntry) throw new AppError('Not a valid backup — manifest.json is missing', 400);
  let manifest;
  try {
    manifest = JSON.parse(zip.readAsText(manifestEntry));
  } catch {
    throw new AppError('manifest.json is not valid JSON', 400);
  }
  const readTable = (name) => {
    const entry = zip.getEntry(`tables/${name}.json`);
    if (!entry) return null;
    try {
      return JSON.parse(zip.readAsText(entry));
    } catch {
      throw new AppError(`tables/${name}.json is not valid JSON`, 400);
    }
  };
  return { manifest, readTable };
}

// Resolves what a restore would touch: the manifest, the ordered list of
// tables to wipe+reinsert (parents first), and any tables skipped because
// they weren't in the backup or weren't part of the selected scope.
async function resolveRestorePlan(ctx, { filePath, scope, moduleCodes }) {
  const { manifest, readTable } = loadZip(filePath);

  if (scope === 'full') {
    if (manifest.scope !== 'full') {
      throw new AppError('This backup is not a full-database export — pick a matching restore scope', 400);
    }
    const names = manifest.tables.map((t) => t.name);
    return {
      manifest, readTable,
      plan: names.map((name) => ({ name, deleteFn: null, action: 'full' })),
      warnings: [],
    };
  }

  if (manifest.scope === 'full') {
    throw new AppError('This is a full-database backup — it cannot be restored into a single tenant/module scope', 400);
  }
  if (manifest.tenantId !== ctx.tenantId || manifest.companyId !== ctx.companyId) {
    throw new AppError('This backup belongs to a different tenant/company. Restore is only allowed back into the same tenant it was exported from.', 400);
  }

  const { registryRows, registryByTable } = await resolveRegistryPlan(scope, moduleCodes);
  const zipTableNames = new Set(manifest.tables.map((t) => t.name));
  const warnings = [];

  const plan = [];
  for (const row of registryRows) {
    if (!zipTableNames.has(row.tableName)) {
      warnings.push(`${row.tableName}: not present in this backup — left untouched`);
      continue;
    }
    plan.push({ name: row.tableName, row, action: 'scoped' });
  }
  for (const name of zipTableNames) {
    if (!registryByTable.has(name)) {
      warnings.push(`${name}: in the backup but not part of the selected scope — ignored`);
    }
  }

  return { manifest, readTable, plan, registryByTable, warnings };
}

async function previewRestore(ctx, { filePath, scope, moduleCodes }) {
  const { manifest, readTable, plan, registryByTable, warnings } = await resolveRestorePlan(ctx, { filePath, scope, moduleCodes });

  const tables = [];
  for (const item of plan) {
    const zipRows = readTable(item.name) || [];
    let currentCount;
    if (scope === 'full') {
      currentCount = Number((await db(item.name).count('* as c').first()).c);
    } else {
      currentCount = Number((await scopedQuery(item.row, ctx, registryByTable).count('* as c').first()).c);
    }
    tables.push({ name: item.name, currentCount, zipCount: zipRows.length });
  }

  return {
    manifest: { exportedAt: manifest.exportedAt, scope: manifest.scope, moduleCodes: manifest.moduleCodes },
    tables, warnings,
  };
}

async function applyRestore(ctx, { filePath, scope, moduleCodes }) {
  const { readTable, plan, registryByTable } = await resolveRestorePlan(ctx, { filePath, scope, moduleCodes });

  const safetySnapshotPath = await writeSafetySnapshot(ctx, { scope: scope === 'full' ? 'full' : 'tenant', moduleCodes: [] });

  const results = [];
  await db.transaction(async (trx) => {
    if (scope === 'full') {
      const isMysql = db.client.config.client === 'mysql' || db.client.config.client === 'mysql2';
      if (isMysql) await trx.raw('SET FOREIGN_KEY_CHECKS=0');
      for (const item of plan) {
        const deleted = await trx(item.name).del();
        const rows = readTable(item.name) || [];
        if (rows.length) await db.batchInsert(item.name, rows, INSERT_CHUNK).transacting(trx);
        results.push({ name: item.name, deleted, inserted: rows.length });
      }
      if (isMysql) await trx.raw('SET FOREIGN_KEY_CHECKS=1');
    } else {
      // Children first on delete, parents first on insert.
      const deleteOrder = [...plan].reverse();
      for (const item of deleteOrder) {
        const deleted = await scopedQuery(item.row, ctx, registryByTable).transacting(trx).del();
        results.push({ name: item.name, deleted, inserted: 0 });
      }
      const resultByName = new Map(results.map((r) => [r.name, r]));
      for (const item of plan) {
        const rows = readTable(item.name) || [];
        if (rows.length) await db.batchInsert(item.name, rows, INSERT_CHUNK).transacting(trx);
        resultByName.get(item.name).inserted = rows.length;
      }
    }
  });

  return { tables: results, safetySnapshotCreated: true, safetySnapshotPath: path.basename(safetySnapshotPath) };
}

module.exports = { getModules, streamExport, previewRestore, applyRestore };
