const { saveSchema } = require('./validation');
const repo = require('./repository');
const asyncHandler = require('../../middleware/asyncHandler');
const { AppError } = require('../../middleware/errorHandler');
const { VALIDATE_OPTS } = require('../../middleware/validation');

exports.getAll = asyncHandler(async (req, res) => {
  res.json(await repo.getAll({ tenantId: req.tenantId }));
});

exports.get = asyncHandler(async (req, res) => {
  const id = Number(req.query.id);
  if (!id) throw new AppError('id is required', 400);
  const row = await repo.get({ tenantId: req.tenantId }, id);
  if (!row) throw new AppError('Not found', 404);
  res.json(row);
});

exports.save = asyncHandler(async (req, res) => {
  const data = await saveSchema.validate(req.body, VALIDATE_OPTS);
  const result = await repo.save({ tenantId: req.tenantId, userId: req.userId }, data);
  res.status(201).json(result);
});

exports.delete = asyncHandler(async (req, res) => {
  const id = Number(req.body.id);
  if (!id) throw new AppError('id is required', 400);
  const result = await repo.delete({ tenantId: req.tenantId, userId: req.userId }, id);
  res.status(200).json(result);
});
