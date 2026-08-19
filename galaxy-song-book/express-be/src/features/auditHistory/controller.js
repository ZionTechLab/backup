const { listSchema, recordSchema } = require('./validation');
const repo = require('./repository');
const asyncHandler = require('../../middleware/asyncHandler');
const { AppError } = require('../../middleware/errorHandler');

// Audit data is sensitive. The route guard enforces the `audit-log-view`
// permission. This only confirms an active tenant context and returns the
// tenantId all queries are scoped to.
function ensureAuditAccess(req) {
  const tenantId = req.tenantId;
  if (!tenantId) throw new AppError('Tenant context required', 400);
  return tenantId;
}

exports.getSummary = asyncHandler(async (req, res) => {
  const tenantId = await ensureAuditAccess(req);
  const f = await listSchema.validate(req.query, { abortEarly: false, stripUnknown: true });
  res.json(await repo.getSummary({ ...f, tenantId }));
});

exports.getAll = asyncHandler(async (req, res) => {
  const tenantId = await ensureAuditAccess(req);
  const f = await listSchema.validate(req.query, { abortEarly: false, stripUnknown: true });
  res.json(await repo.getAll({ ...f, tenantId }));
});

exports.getRecord = asyncHandler(async (req, res) => {
  const tenantId = await ensureAuditAccess(req);
  const f = await recordSchema.validate(req.query, { abortEarly: false, stripUnknown: true });
  res.json(await repo.getRecord({ ...f, tenantId }));
});
