const { saveSchema, arrangeSchema, grantsSchema } = require('./validation');
const repo = require('./repository');
const asyncHandler = require('../../middleware/asyncHandler');
const { VALIDATE_OPTS } = require('../../middleware/validation');

const ctxOf = (req) => ({ tenantId: req.tenantId, companyId: req.companyId, userId: req.userId });

exports.getAll = asyncHandler(async (req, res) => {
  res.json(await repo.getAll(ctxOf(req)));
});

exports.save = asyncHandler(async (req, res) => {
  const data = await saveSchema.validate(req.body, VALIDATE_OPTS);
  res.status(201).json(await repo.save(ctxOf(req), data));
});

exports.arrange = asyncHandler(async (req, res) => {
  const data = await arrangeSchema.validate(req.body, VALIDATE_OPTS);
  res.status(200).json(await repo.arrange(ctxOf(req), data.items));
});

exports.setGrants = asyncHandler(async (req, res) => {
  const data = await grantsSchema.validate(req.body, VALIDATE_OPTS);
  res.status(200).json(await repo.setGrants(ctxOf(req), data));
});
