const { saveSchema } = require('./validation');
const repo = require('./repository');
const asyncHandler = require('../../middleware/asyncHandler');
const { AppError } = require('../../middleware/errorHandler');
const { VALIDATE_OPTS } = require('../../middleware/validation');

exports.getAll = asyncHandler(async (req, res) => {
  const { unitType } = req.query;
  const rows = await repo.getAll(
    { tenantId: req.tenantId, companyId: req.companyId },
    unitType || undefined
  );
  res.json(rows);
});

exports.getParents = asyncHandler(async (req, res) => {
  const { unitType, companyId } = req.query;
  if (!unitType) throw new AppError('unitType query parameter is required', 400);
  const rows = await repo.getParents(
    { tenantId: req.tenantId, companyId: req.companyId },
    unitType,
    companyId || undefined
  );
  res.json(rows);
});

exports.get = asyncHandler(async (req, res) => {
  const id = req.query.id || req.body.id;
  if (!id) throw new AppError('id is required', 400);
  const row = await repo.get(
    { tenantId: req.tenantId, companyId: req.companyId },
    id
  );
  if (!row) throw new AppError('Not found', 404);
  res.json(row);
});

exports.save = asyncHandler(async (req, res) => {
  const data = await saveSchema.validate(req.body, VALIDATE_OPTS);
  const row = await repo.save(
    { userId: req.userId, tenantId: req.tenantId, companyId: req.companyId },
    data
  );
  res.status(201).json(row);
});

exports.getCompanies = asyncHandler(async (req, res) => {
  const rows = await repo.getCompanies({ tenantId: req.tenantId });
  res.json(rows);
});

exports.del = asyncHandler(async (req, res) => {
  const { id } = req.body;
  if (!id) throw new AppError('id is required', 400);
  const result = await repo.del({ userId: req.userId }, id);
  res.status(200).json(result);
});
