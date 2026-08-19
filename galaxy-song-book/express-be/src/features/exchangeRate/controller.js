const { updateSchema } = require('./validation');
const repo = require('./repository');
const asyncHandler = require('../../middleware/asyncHandler');
const { AppError } = require('../../middleware/errorHandler');

exports.getAll = asyncHandler(async (req, res) => {
  const rates = await repo.getAll();
  res.json(rates);
});

exports.get = asyncHandler(async (req, res) => {
  const filters = Object.keys(req.query || {}).length ? req.query : (req.body || {});
  const rate = await repo.get(filters);
  if (!rate) throw new AppError('Not found', 404);
  res.json(rate);
});

exports.getUi = asyncHandler(async (req, res) => {
  const ui = await repo.getUi();
  res.json(ui);
});

exports.update = asyncHandler(async (req, res) => {
  const payload = req.body.header ? { ...req.body.header, isUpdate: req.body.isUpdate } : req.body;
  const data = await updateSchema.validate(payload, { abortEarly: false, stripUnknown: true });
  const rate = await repo.update({ ...data, userId: req.userId });
  res.status(201).json(rate);
});
