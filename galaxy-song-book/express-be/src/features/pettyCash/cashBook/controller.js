const { updateSchema, deleteSchema, establishSchema, idSchema } = require('./validation');
const repo = require('./repository');
const asyncHandler = require('../../../middleware/asyncHandler');
const { AppError } = require('../../../middleware/errorHandler');
const { VALIDATE_OPTS } = require('../../../middleware/validation');

exports.getUi = asyncHandler(async (req, res) => {
  const data = await repo.getUi({ tenantId: req.tenantId, companyId: req.companyId });
  res.json(data);
});

exports.getAll = asyncHandler(async (req, res) => {
  const rows = await repo.getAll({ tenantId: req.tenantId, companyId: req.companyId });
  res.json(rows);
});

exports.get = asyncHandler(async (req, res) => {
  const filters = Object.keys(req.query || {}).length ? req.query : (req.body || {});
  const row = await repo.get(filters);
  if (!row) throw new AppError('Not found', 404);
  res.json(row);
});

exports.update = asyncHandler(async (req, res) => {
  const data = await updateSchema.validate(req.body, VALIDATE_OPTS);
  const row = await repo.update({ ...data, userId: req.userId, tenantId: req.tenantId, companyId: req.companyId });
  res.status(201).json(row);
});

exports.delete = asyncHandler(async (req, res) => {
  const data = await deleteSchema.validate(req.body, VALIDATE_OPTS);
  const result = await repo.delete({ ...data, userId: req.userId });
  res.status(200).json(result);
});

exports.establishFloat = asyncHandler(async (req, res) => {
  const data = await establishSchema.validate(req.body, VALIDATE_OPTS);
  const row = await repo.establishFloat({ ...data, userId: req.userId });
  res.status(201).json(row);
});

exports.reverseFloat = asyncHandler(async (req, res) => {
  const data = await idSchema.validate(req.body, VALIDATE_OPTS);
  const result = await repo.reverseFloat({ ...data, userId: req.userId });
  res.status(200).json(result);
});
