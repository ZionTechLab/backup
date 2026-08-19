const { saveSchema } = require('./validation');
const repo = require('./repository');
const asyncHandler = require('../../middleware/asyncHandler');
const { AppError } = require('../../middleware/errorHandler');
const { VALIDATE_OPTS } = require('../../middleware/validation');
const { getEffectivePermissions } = require('../../repository/permissions');

const ctxOf = (req) => ({ tenantId: req.tenantId, companyId: req.companyId, userId: req.userId });

exports.getOptions = asyncHandler(async (req, res) => res.json(await repo.getOptions(ctxOf(req))));
exports.getAll = asyncHandler(async (req, res) => res.json(await repo.getAll(ctxOf(req))));

exports.get = asyncHandler(async (req, res) => {
  const row = await repo.get(ctxOf(req), req.query.id);
  if (!row) throw new AppError('Not found', 404);
  res.json(row);
});

exports.save = asyncHandler(async (req, res) => {
  const data = await saveSchema.validate(req.body, VALIDATE_OPTS);
  res.status(201).json(await repo.save(ctxOf(req), data));
});

exports.delete = asyncHandler(async (req, res) => {
  const id = req.body.id;
  if (!id) throw new AppError('id is required', 400);
  res.status(200).json(await repo.delete(ctxOf(req), id));
});

exports.getInbox = asyncHandler(async (req, res) => {
  const codes = await getEffectivePermissions(req.userId, { companyId: req.companyId });
  res.json(await repo.getInbox(ctxOf(req), codes));
});

exports.getDoc = asyncHandler(async (req, res) => {
  const { docType, docId } = req.query;
  if (!docType || !docId) throw new AppError('docType and docId are required', 400);
  res.json(await repo.getDoc(docType, docId));
});
