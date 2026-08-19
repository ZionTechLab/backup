const { dateOnly, reportSchema, trialBalanceSchema, balanceSheetSchema } = require('./validation');
const repo = require('./repository');
const asyncHandler = require('../../../middleware/asyncHandler');
const { AppError } = require('../../../middleware/errorHandler');

// P&L reuses the trial-balance date-range rules.
const pnlSchema = trialBalanceSchema;

exports.getUi = asyncHandler(async (req, res) => {
  const result = await repo.getUi();
  res.json(result);
});

exports.getAccounts = asyncHandler(async (req, res) => {
  const accounts = await repo.getAccounts();
  res.json(accounts);
});

exports.getReport = asyncHandler(async (req, res) => {
  const data = await reportSchema.validate(req.body, { abortEarly: false, stripUnknown: true });
  if (!req.companyId) throw new AppError('companyId is required', 400);
  const result = await repo.getReport({ ...data, tenantId: req.tenantId, companyId: req.companyId });
  res.json(result);
});

exports.getTrialBalance = asyncHandler(async (req, res) => {
  const data = await trialBalanceSchema.validate(req.body, { abortEarly: false, stripUnknown: true });
  if (!req.companyId) throw new AppError('companyId is required', 400);
  const result = await repo.getTrialBalance({ ...data, tenantId: req.tenantId, companyId: req.companyId });
  res.json(result);
});

exports.getPnl = asyncHandler(async (req, res) => {
  const data = await pnlSchema.validate(req.body, { abortEarly: false, stripUnknown: true });
  if (!req.companyId) throw new AppError('companyId is required', 400);
  const result = await repo.getPnl({ ...data, tenantId: req.tenantId, companyId: req.companyId });
  res.json(result);
});

exports.getBalanceSheet = asyncHandler(async (req, res) => {
  const data = await balanceSheetSchema.validate(req.body, { abortEarly: false, stripUnknown: true });
  if (!req.companyId) throw new AppError('companyId is required', 400);
  const result = await repo.getBalanceSheet({ ...data, tenantId: req.tenantId, companyId: req.companyId });
  res.json(result);
});
