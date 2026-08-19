const fs = require('fs');
const { exportSchema, restorePreviewSchema, restoreApplySchema } = require('./validation');
const repo = require('./repository');
const { tokenToPath, sweepStale } = require('./restoreUpload');
const asyncHandler = require('../../middleware/asyncHandler');
const { VALIDATE_OPTS } = require('../../middleware/validation');
const { AppError } = require('../../middleware/errorHandler');

const ctxOf = (req) => ({ tenantId: req.tenantId, companyId: req.companyId, userId: req.userId });

// A whole-database export/restore crosses every tenant, so it needs the
// stronger permission specifically — route-level requirePermission only
// guarantees the user holds at least one of the pair.
function assertFullScopeAllowed(req, data, permCode) {
  if (data.scope === 'full' && !req._permissions.includes(permCode)) {
    throw new AppError(`Forbidden: full database scope requires ${permCode}`, 403);
  }
}

const parseModuleCodes = (raw) => {
  if (Array.isArray(raw)) return raw;
  if (!raw) return [];
  try {
    const parsed = JSON.parse(raw);
    return Array.isArray(parsed) ? parsed : [];
  } catch {
    return [];
  }
};

exports.getModules = asyncHandler(async (req, res) => {
  res.json(await repo.getModules());
});

exports.export = asyncHandler(async (req, res) => {
  const data = await exportSchema.validate(req.body, VALIDATE_OPTS);
  assertFullScopeAllowed(req, data, 'backup-export-full');

  const filename = `backup-${data.scope}-${new Date().toISOString().slice(0, 10)}.zip`;
  res.setHeader('Content-Type', 'application/zip');
  res.setHeader('Content-Disposition', `attachment; filename="${filename}"`);

  await repo.streamExport(ctxOf(req), data, res);
});

exports.previewRestore = asyncHandler(async (req, res) => {
  sweepStale();
  if (!req.file) throw new AppError('No file uploaded', 400);

  let data;
  try {
    data = await restorePreviewSchema.validate(
      { scope: req.body.scope, moduleCodes: parseModuleCodes(req.body.moduleCodes) },
      VALIDATE_OPTS
    );
  } catch (err) {
    fs.unlink(req.file.path, () => {});
    throw err;
  }
  assertFullScopeAllowed(req, data, 'backup-restore-full');

  try {
    const result = await repo.previewRestore(ctxOf(req), { filePath: req.file.path, ...data });
    res.json({ token: req.file.filename, ...result });
  } catch (err) {
    fs.unlink(req.file.path, () => {});
    throw err;
  }
});

exports.applyRestore = asyncHandler(async (req, res) => {
  const data = await restoreApplySchema.validate(req.body, VALIDATE_OPTS);
  assertFullScopeAllowed(req, data, 'backup-restore-full');

  const filePath = tokenToPath(data.token);
  if (!filePath || !fs.existsSync(filePath)) {
    throw new AppError('Upload expired or not found — re-upload the backup file', 400);
  }

  try {
    const result = await repo.applyRestore(ctxOf(req), { filePath, scope: data.scope, moduleCodes: data.moduleCodes });
    res.json(result);
  } finally {
    fs.unlink(filePath, () => {});
  }
});
