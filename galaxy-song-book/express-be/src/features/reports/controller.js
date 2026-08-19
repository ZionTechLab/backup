const { reportSchema } = require('./validation');
const repo = require('./repository');
const asyncHandler = require('../../middleware/asyncHandler');
const { AppError } = require('../../middleware/errorHandler');
const { VALIDATE_OPTS } = require('../../middleware/validation');

exports.getUi = asyncHandler(async (req, res) => {
  const logs = await repo.getUi();
  res.json(logs);
});

exports.getReport = asyncHandler(async (req, res) => {
  const data = await reportSchema.validate(req.body, VALIDATE_OPTS);
  const newTxn = await repo.getReport(data);
  res.status(201).json(newTxn);
});