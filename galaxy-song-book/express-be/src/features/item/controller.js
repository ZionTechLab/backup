const { updateSchema, deleteSchema } = require('./validation');
const repo = require('./repository');
const asyncHandler = require('../../middleware/asyncHandler');
const { AppError } = require('../../middleware/errorHandler');
const { VALIDATE_OPTS } = require('../../middleware/validation');

exports.getUi = asyncHandler(async (req, res) => {
  const data = await repo.getUi();
  res.json(data);
});

exports.getAll = asyncHandler(async (req, res) => {
  const filters = Object.keys(req.query || {}).length ? req.query : (req.body || {});
  const rows = await repo.getAll(filters);
  res.json(rows);
});

exports.get = asyncHandler(async (req, res) => {
  const filters = Object.keys(req.query || {}).length ? req.query : (req.body || {});
  const row = await repo.get(filters);
  if (!row) throw new AppError('Not found', 404);
  res.json(row);
});

exports.getPrint = asyncHandler(async (req, res) => {
  const filters = Object.keys(req.query || {}).length ? req.query : (req.body || {});
  const row = await repo.getPrint(filters);
  if (!row) throw new AppError('Not found', 404);
  res.json(row);
});

exports.update = asyncHandler(async (req, res) => {
  const data = await updateSchema.validate(req.body, VALIDATE_OPTS);
  const newRow = await repo.update({ ...data, userId: req.userId, tenantId: req.tenantId, companyId: req.companyId });
  res.status(201).json(newRow);
});

exports.delete = asyncHandler(async (req, res) => {
  const data = await deleteSchema.validate(req.body, VALIDATE_OPTS);
  const result = await repo.delete({ ...data, userId: req.userId });
  res.status(201).json(result);
});
