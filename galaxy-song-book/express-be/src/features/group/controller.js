const { updateSchema, deleteSchema } = require('./validation');
const repo = require('./repository');
const asyncHandler = require('../../middleware/asyncHandler');
const { AppError } = require('../../middleware/errorHandler');

exports.getAll = asyncHandler(async (req, res) => {
  const filters = Object.keys(req.query || {}).length ? req.query : (req.body || {});
  const groups = await repo.getAll(filters);
  res.json(groups);
});

exports.get = asyncHandler(async (req, res) => {
  const filters = Object.keys(req.query || {}).length ? req.query : (req.body || {});
  const group = await repo.get(filters);
  if (!group) throw new AppError('Not found', 404);
  res.json(group);
});

exports.update = asyncHandler(async (req, res) => {
  const src = { ...req.body, tenantId: req.tenantId };
  const data = await updateSchema.validate(src, { abortEarly: false, stripUnknown: true });
  const group = await repo.update({ ...data, userId: req.userId });
  res.status(201).json(group);
});

exports.delete = asyncHandler(async (req, res) => {
  const data = await deleteSchema.validate(req.body, { abortEarly: false, stripUnknown: true });
  await repo.delete({ ...data, userId: req.userId });
  res.json({ success: true });
});
