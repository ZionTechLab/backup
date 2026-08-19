const { updateSchema, deleteSchema, uploadSchema } = require('./validation');
const repo = require('./repository');
const asyncHandler = require('../../middleware/asyncHandler');
const { AppError } = require('../../middleware/errorHandler');
const { VALIDATE_OPTS } = require('../../middleware/validation');

// All business columns are nullable in the schema; validate types only.

exports.getUi = asyncHandler(async (req, res) => {
  const logs = await repo.getUi();
  res.json(logs);
});

exports.getAll = asyncHandler(async (req, res) => {
  const filters = Object.keys(req.query || {}).length ? req.query : (req.body || {});
  const txns = await repo.getAll(filters);
  res.json(txns);
});

exports.get = asyncHandler(async (req, res) => {
  const filters = Object.keys(req.query || {}).length ? req.query : (req.body || {});
  const txn = await repo.get(filters);
  if (!txn) throw new AppError('Not found', 404);
  if (txn.image) {
    const filename = (typeof txn.image === 'string') ? require('path').basename(txn.image) : null;
    if (filename) {
      txn.image = `${filename}`;
    }
  }
  res.json(txn);
});

exports.update = asyncHandler(async (req, res) => {
  const data = await updateSchema.validate(req.body, VALIDATE_OPTS);
  const newTxn = await repo.update({ ...data, userId: req.userId, tenantId: req.tenantId, companyId: req.companyId });
  res.status(201).json(newTxn);
});

exports.delete = asyncHandler(async (req, res) => {
  const data = await deleteSchema.validate(req.body, VALIDATE_OPTS);
  const newTxn = await repo.delete(data);
  res.status(201).json(newTxn);
});

exports.uploadImage = asyncHandler(async (req, res) => {
  const data = await uploadSchema.validate(req.body, VALIDATE_OPTS);
  const payload = { id: data.id, userId: req.userId };
  payload.images = (req.files || []).map(file => file.filename);
  const newLog = await repo.uploadImage(payload);
  
  res.status(201).json(newLog);
});

