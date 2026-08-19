const { updateSchema, idSchema, actSchema, auditSchema } = require('./validation');
const repo = require('./repository');
const asyncHandler = require('../../../middleware/asyncHandler');
const { AppError } = require('../../../middleware/errorHandler');
const { VALIDATE_OPTS } = require('../../../middleware/validation');

const PAYMENT_MODES = ['PettyCash', 'BankTransfer', 'Cheque', 'Cash'];

exports.getUi = asyncHandler(async (req, res) => {
  const data = await repo.getUi({ tenantId: req.tenantId, companyId: req.companyId });
  res.json(data);
});

exports.getAll = asyncHandler(async (req, res) => {
  const rows = await repo.getAll({ tenantId: req.tenantId, companyId: req.companyId });
  res.json(rows);
});

// Approved IOU requests not yet converted to an IOU, for the form picker.
exports.getApprovedRequests = asyncHandler(async (req, res) => {
  const rows = await repo.getApprovedRequests({ tenantId: req.tenantId, companyId: req.companyId });
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

exports.certify = asyncHandler(async (req, res) => {
  const data = await idSchema.validate(req.body, VALIDATE_OPTS);
  const row = await repo.certify({ ...data, userId: req.userId });
  res.status(200).json(row);
});

exports.approve = asyncHandler(async (req, res) => {
  const data = await idSchema.validate(req.body, VALIDATE_OPTS);
  const row = await repo.approve({ ...data, userId: req.userId });
  res.status(200).json(row);
});

exports.act = asyncHandler(async (req, res) => {
  const data = await actSchema.validate(req.body, VALIDATE_OPTS);
  const row = await repo.act({ ...data, userId: req.userId });
  res.status(200).json(row);
});

exports.pay = asyncHandler(async (req, res) => {
  const data = await idSchema.validate(req.body, VALIDATE_OPTS);
  const row = await repo.pay({ ...data, userId: req.userId });
  res.status(200).json(row);
});

exports.cancel = asyncHandler(async (req, res) => {
  const data = await idSchema.validate(req.body, VALIDATE_OPTS);
  const result = await repo.cancel({ ...data, userId: req.userId });
  res.status(200).json(result);
});

exports.addAudit = asyncHandler(async (req, res) => {
  const data = await auditSchema.validate(req.body, VALIDATE_OPTS);
  const row = await repo.addAudit({ ...data, userId: req.userId, tenantId: req.tenantId, companyId: req.companyId });
  res.status(201).json(row);
});
