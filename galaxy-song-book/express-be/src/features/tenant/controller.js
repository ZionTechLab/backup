const { updateSchema, deleteSchema, settingsSchema, addUserSchema, removeUserSchema, setDefaultSchema, listUsersSchema } = require('./validation');
const repo = require('./repository');
const db = require('../../database');
const asyncHandler = require('../../middleware/asyncHandler');
const { AppError } = require('../../middleware/errorHandler');
const { VALIDATE_OPTS } = require('../../middleware/validation');

exports.getAll = asyncHandler(async (req, res) => {
  const filters = Object.keys(req.query || {}).length ? req.query : (req.body || {});
  const tenants = await repo.getAll(filters);
  res.json(tenants);
});

exports.get = asyncHandler(async (req, res) => {
  const filters = Object.keys(req.query || {}).length ? req.query : (req.body || {});
  const tenant = await repo.get(filters);
  if (!tenant) throw new AppError('Not found', 404);
  res.json(tenant);
});

exports.update = asyncHandler(async (req, res) => {
  const data = await updateSchema.validate(req.body, VALIDATE_OPTS);
  const tenant = await repo.update({ ...data, userId: req.userId });
  res.status(201).json(tenant);
});

exports.delete = asyncHandler(async (req, res) => {
  const data = await deleteSchema.validate(req.body, VALIDATE_OPTS);
  await repo.delete({ ...data, userId: req.userId });
  res.json({ success: true });
});

exports.getSettings = asyncHandler(async (req, res) => {
  const tenantId = (req.query.tenantId || '').toString().trim();
  if (!tenantId) throw new AppError('tenantId is required', 400);
  if (!(await repo.isMember(tenantId, req.userId))) throw new AppError('Forbidden: tenant not allowed', 403);
  const settings = await repo.getSettings(tenantId);
  res.json(settings);
});

exports.updateSettings = asyncHandler(async (req, res) => {
  const data = await settingsSchema.validate(req.body, VALIDATE_OPTS);
  if (!(await repo.isMember(data.tenantId, req.userId))) throw new AppError('Forbidden: tenant not allowed', 403);
  const settings = await repo.updateSettings({ ...data, userId: req.userId });
  res.status(201).json(settings);
});

// --- Tenant user membership ---

exports.listUsers = asyncHandler(async (req, res) => {
  const { tenantId } = await listUsersSchema.validate(req.query, VALIDATE_OPTS);
  const users = await repo.listUsers(tenantId);
  res.json(users);
});

exports.addUser = asyncHandler(async (req, res) => {
  const data = await addUserSchema.validate(req.body, VALIDATE_OPTS);
  const row = await repo.addUser({ tenantId: data.tenantId, userId: data.userId, updatedBy: req.userId });
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

exports.countOtherTenants = asyncHandler(async (req, res) => {
  const { id } = req.query;
  if (!id) throw new AppError('id is required', 400);
  const membership = await db('sec_userTenants').where({ id }).first();
  if (!membership) throw new AppError('Not found', 404);
  const count = await repo.countOtherActiveTenants(membership.userId, Number(id));
  res.json({ count });
});

// Self-service: a user sets their own default tenant (no admin permission needed)
exports.setMyDefault = asyncHandler(async (req, res) => {
  const { tenantId } = req.body;
  if (!tenantId) throw new AppError('tenantId is required', 400);

  const membership = await db('sec_userTenants')
    .where({ tenantId, userId: req.userId, isActive: true, isDeleted: false })
    .first();
  if (!membership) throw new AppError('You do not have access to this tenant', 403);

  await repo.setDefault({ id: membership.id, userId: req.userId });
  res.status(201).json({ success: true });
});
