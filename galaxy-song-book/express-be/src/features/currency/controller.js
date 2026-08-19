const { updateSchema, deleteSchema } = require('./validation');
const repo = require('./repository');
const asyncHandler = require('../../middleware/asyncHandler');
const { AppError } = require('../../middleware/errorHandler');

exports.getAll = asyncHandler(async (req, res) => {
  const currencies = await repo.getAll();
  res.json(currencies);
});

exports.get = asyncHandler(async (req, res) => {
  const filters = Object.keys(req.query || {}).length ? req.query : (req.body || {});
  const currency = await repo.get(filters);
  if (!currency) throw new AppError('Not found', 404);
  res.json(currency);
});

exports.update = asyncHandler(async (req, res) => {
  const payload = req.body.header ? { ...req.body.header, isUpdate: req.body.isUpdate } : req.body;
  const data = await updateSchema.validate(payload, { abortEarly: false, stripUnknown: true });
  const currency = await repo.update(data);
  res.status(201).json(currency);
});

exports.delete = asyncHandler(async (req, res) => {
  const data = await deleteSchema.validate(req.body, { abortEarly: false, stripUnknown: true });
  await repo.delete(data);
  res.json({ success: true });
});
