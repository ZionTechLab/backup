const { updateSchema, deleteSchema } = require('./validation');
const repo = require('./repository');
const asyncHandler = require('../../middleware/asyncHandler');
const { AppError } = require('../../middleware/errorHandler');
const { VALIDATE_OPTS } = require('../../middleware/validation');

exports.getAll = asyncHandler(async (req, res) => {
    const txns = await repo.getAll();
    res.json(txns);
});
exports.getUi = asyncHandler(async (req, res) => {
    const data = await repo.getUi();
    res.json(data);
});
exports.get = asyncHandler(async (req, res) => {
    const filters = Object.keys(req.query || {}).length ? req.query : (req.body || {});
    const txn = await repo.get(filters);
    if (!txn) throw new AppError('Not found', 404);
    res.json(txn);
});

exports.update = asyncHandler(async (req, res) => {
    const data = await updateSchema.validate(req.body, VALIDATE_OPTS);
    const newTxn = await repo.update(data);
    res.status(201).json(newTxn);
});

exports.delete = asyncHandler(async (req, res) => {
    const data = await deleteSchema.validate(req.body, VALIDATE_OPTS);
    const newTxn = await repo.delete(data);
    res.status(201).json(newTxn);
});
