const { updateSchema, deleteSchema, reportSchema } = require('./validation');
const repo = require('./repository');
const asyncHandler = require('../../../middleware/asyncHandler');
const { AppError } = require('../../../middleware/errorHandler');

exports.getAll = asyncHandler(async (req, res) => {
  const records = await repo.getAll(req.tenantId,req.companyId);
  res.json(records);
});

exports.get = asyncHandler(async (req, res) => {
  const filters = Object.keys(req.query || {}).length ? req.query : (req.body || {});
  const record = await repo.get(filters);
  if (!record) throw new AppError('Not found', 404);
  res.json(record);
});

exports.update = asyncHandler(async (req, res) => {
  const data = await updateSchema.validate(req.body, { abortEarly: false, stripUnknown: true });
  const record = await repo.update({ ...data, tenantId: req.tenantId, companyId: req.companyId, userId: req.userId });
  res.status(201).json(record);
});

exports.getAccounts = asyncHandler(async (req, res) => {
  const accounts = await repo.getAccounts();
  res.json(accounts);
});

exports.getReport = asyncHandler(async (req, res) => {
  const data = await reportSchema.validate(req.body, { abortEarly: false, stripUnknown: true });
  const result = await repo.getReport(data);
  res.json(result);
});

exports.delete = asyncHandler(async (req, res) => {
  const data = await deleteSchema.validate(req.body, { abortEarly: false, stripUnknown: true });
  await repo.delete({ ...data, userId: req.userId });
  res.json({ success: true });
});
