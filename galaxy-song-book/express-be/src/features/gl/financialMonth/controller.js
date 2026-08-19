const { updateSchema } = require('./validation');
const repo  = require('./repository');
const asyncHandler  = require('../../../middleware/asyncHandler');
const { AppError }  = require('../../../middleware/errorHandler');

exports.getAll = asyncHandler(async (req, res) => {
  const filters = Object.keys(req.query || {}).length ? req.query : (req.body || {});
  filters.companyId = req.companyId;
  if (!filters.companyId) throw new AppError('companyId is required', 400);
  const rows = await repo.getAll(filters);
  res.json(rows);
});

exports.update = asyncHandler(async (req, res) => {
  const src = { ...req.body, companyId: req.companyId, tenantId: req.tenantId };
  const data = await updateSchema.validate(src, { abortEarly: false, stripUnknown: true });
  data.userId = req.userId;
  const result = await repo.update(data);
  res.json(result);
});
