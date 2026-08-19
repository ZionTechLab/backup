const { updateSchema, deleteSchema, addUserSchema, removeUserSchema, setDefaultSchema, listUsersSchema } = require('./validation');
const repo = require('./repository');
const db = require('../../database');
const asyncHandler = require('../../middleware/asyncHandler');
const { AppError } = require('../../middleware/errorHandler');
const { VALIDATE_OPTS } = require('../../middleware/validation');

exports.getAll = asyncHandler(async (req, res) => {
  const companies = await repo.getAll();
  res.json(companies);
});

exports.get = asyncHandler(async (req, res) => {
  const filters = Object.keys(req.query || {}).length ? req.query : (req.body || {});
  const company = await repo.get(filters);
  if (!company) throw new AppError('Not found', 404);
  res.json(company);
});

exports.getPrint = asyncHandler(async (req, res) => {
  if (!req.companyId) throw new AppError('Company context required', 400);
  const company = await repo.getPrint(req.companyId);
  if (!company) throw new AppError('Not found', 404);
  res.json(company);
});

exports.getUi = asyncHandler(async (req, res) => {
  const ui = await repo.getUi();
  res.json(ui);
});

exports.update = asyncHandler(async (req, res) => {
  const { isUpdate, header } = await updateSchema.validate(req.body, { abortEarly: false, stripUnknown: true });
  const companyId = isUpdate ? header.companyId : null;
  if (isUpdate && !companyId) throw new AppError('companyId is required for updates', 400);
  const company = await repo.update({ ...header, isUpdate, companyId, tenantId: header.tenantId || req.tenantId, userId: req.userId });
  res.status(201).json(company);
});

exports.delete = asyncHandler(async (req, res) => {
  const data = await deleteSchema.validate(req.body, { abortEarly: false, stripUnknown: true });
  await repo.delete({ ...data, userId: req.userId });
  res.json({ success: true });
});

// --- Company user membership ---

exports.listUsers = asyncHandler(async (req, res) => {
  const { companyId } = await listUsersSchema.validate(req.query, VALIDATE_OPTS);
  const users = await repo.listUsers(companyId);
  res.json(users);
});

exports.addUser = asyncHandler(async (req, res) => {
  const data = await addUserSchema.validate(req.body, VALIDATE_OPTS);
  const row = await repo.addUser({ companyId: data.companyId, userId: data.userId, updatedBy: req.userId });
  res.status(201).json(row);
});

exports.removeUser = asyncHandler(async (req, res) => {
  const data = await removeUserSchema.validate(req.body, VALIDATE_OPTS);
  await repo.removeUser({ ...data, userId: req.userId });
  res.json({ success: true });
});

exports.setDefault = asyncHandler(async (req, res) => {
  const data = await setDefaultSchema.validate(req.body, VALIDATE_OPTS);
  const row = await repo.setDefault({ ...data, userId: req.userId });
  res.status(201).json(row);
});

exports.countOtherCompanies = asyncHandler(async (req, res) => {
  const { id } = req.query;
  if (!id) throw new AppError('id is required', 400);
  const membership = await db('sec_userCompanies').where({ id }).first();
  if (!membership) throw new AppError('Not found', 404);
  const count = await repo.countOtherCompanies(membership.userId, Number(id));
  res.json({ count });
});

// Self-service: a user sets their own default company
exports.setMyDefault = asyncHandler(async (req, res) => {
  const { companyId } = req.body;
  if (!companyId) throw new AppError('companyId is required', 400);

  const membership = await db('sec_userCompanies')
    .where({ companyId, userId: req.userId, isActive: true, isDeleted: false })
    .first();
  if (!membership) throw new AppError('You do not have access to this company', 403);

  await repo.setDefault({ id: membership.id, userId: req.userId });
  res.status(201).json({ success: true });
});
