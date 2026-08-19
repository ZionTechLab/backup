const repo = require('./repository');
const asyncHandler = require('../../../middleware/asyncHandler');
const { AppError } = require('../../../middleware/errorHandler');

exports.getAll = asyncHandler(async (req, res) => {
    const txns = await repo.getAll();
    res.json(txns);
});

exports.getUi = asyncHandler(async (req, res) => {
    const txns = await repo.getUi();
    res.json(txns);
});

exports.get = asyncHandler(async (req, res) => {
    const filters = Object.keys(req.query || {}).length ? req.query : (req.body || {});
    const txn = await repo.get(filters);
    if (!txn) throw new AppError('Not found', 404);
    res.json(txn);
});

exports.update = asyncHandler(async (req, res) => {
    const newTxn = await repo.update(req.body);
    res.status(201).json(newTxn);
});

exports.delete = asyncHandler(async (req, res) => {
  const newTxn = await repo.delete(req.body);
  res.status(201).json(newTxn);
});