const { dateOnly, dateRangeSchema, iouRegisterSchema, agingSchema } = require('./validation');
const repo = require('./repository');
const asyncHandler = require('../../../middleware/asyncHandler');
const { AppError } = require('../../../middleware/errorHandler');

const resolveTenant = (req) => ({ tenantId: req.tenantId, companyId: req.companyId });

exports.iouRegister = asyncHandler(async (req, res) => {
  const data = await iouRegisterSchema.validate(req.body, { abortEarly: false, stripUnknown: true });
  if (!req.companyId) throw new AppError('companyId is required', 400);
  const result = await repo.iouRegister({ ...data, ...resolveTenant(req) });
  res.json(result);
});

exports.iouAging = asyncHandler(async (req, res) => {
  const data = await agingSchema.validate(req.body || {}, { abortEarly: false, stripUnknown: true });
  if (!req.companyId) throw new AppError('companyId is required', 400);
  const result = await repo.iouAging({ ...data, ...resolveTenant(req) });
  res.json(result);
});

exports.partyOutstanding = asyncHandler(async (req, res) => {
  if (!req.companyId) throw new AppError('companyId is required', 400);
  const result = await repo.partyOutstanding(resolveTenant(req));
  res.json(result);
});

exports.cashBookBalances = asyncHandler(async (req, res) => {
  if (!req.companyId) throw new AppError('companyId is required', 400);
  const result = await repo.cashBookBalances(resolveTenant(req));
  res.json(result);
});

exports.managerDashboard = asyncHandler(async (req, res) => {
  const data = await dateRangeSchema.validate(req.body || {}, { abortEarly: false, stripUnknown: true });
  if (!req.companyId) throw new AppError('companyId is required', 400);
  const result = await repo.managerDashboard({ ...data, ...resolveTenant(req) });
  res.json(result);
});
