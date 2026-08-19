const { loginSchema, refreshSchema, changePasswordSchema } = require('./validation');
const crypto = require('crypto');
const repo = require('./repository');
const asyncHandler = require('../../middleware/asyncHandler');
const { AppError } = require('../../middleware/errorHandler');
const UserRepo = require('../user/repository');
const { generateToken } = require('../../middleware/auth');
const { TokenRepo } = require('./tokenRepository');
const { VALIDATE_OPTS } = require('../../middleware/validation');
const { logAuthEvent } = require('../../repository/auditHistory');

const reqMeta = (req) => ({
  ip: req.ip || req.connection?.remoteAddress || null,
  userAgent: req.headers['user-agent'] || null,
});

exports.init = asyncHandler(async (req, res) => {
    const filters = Object.keys(req.query || {}).length ? req.query : (req.body || {});
    const ui = await repo.init(filters);
    if (!ui) throw new AppError('Not found', 404);
    res.json(ui);
});


// New: POST /auth/login -> issues JWT
exports.login = asyncHandler(async (req, res) => {
    const { userName, password } = await loginSchema.validate(req.body, VALIDATE_OPTS);

    const user = await UserRepo.verifyCredentials({ userName, password });
    if (!user) {
        await logAuthEvent({ recordId: userName, changeType: 'F', meta: { userName, ...reqMeta(req) } });
        throw new AppError('Invalid credentials', 401);
    }

    const token = generateToken(user);

    // Issue refresh token (httpOnly cookie optional; for now return in body for API usage)
    const { token: refreshToken, tokenHash } = TokenRepo.generate();
    const ttlDays = Number(process.env.REFRESH_TOKEN_DAYS || 7);
    const expiresAt = new Date(Date.now() + ttlDays * 86_400_000);
    await TokenRepo.save({
        userId: user.userId,
        tokenHash,
        expiresAt,
        userAgent: req.headers['user-agent'] || null,
        ip: req.ip || req.connection?.remoteAddress || null,
    });

    await logAuthEvent({ userId: user.userId, changeType: 'L', meta: { userName, ...reqMeta(req) } });

    res.json({ token, expiresAt, refreshToken, user });
});

// POST /auth/refresh { refreshToken }
exports.refresh = asyncHandler(async (req, res) => {
    const { refreshToken } = await refreshSchema.validate(req.body, VALIDATE_OPTS);
    const existing = await TokenRepo.findValid(refreshToken);
    if (!existing) throw new AppError('Invalid refresh token', 401);

    // Load user for payload
    const userRow = await UserRepo.get({ userId: existing.userId });
    if (!userRow?.userId) throw new AppError('User not found', 404);

    const token = generateToken({
        userId: userRow.userId,
        userName: userRow.userName,
        roleId: userRow.roleId,
    });

    // Rotate refresh token
    const { token: newRefresh, tokenHash: newHash } = TokenRepo.generate();
    await TokenRepo.save({
        userId: userRow.userId,
        tokenHash: newHash,
        expiresAt: new Date(Date.now() + Number(process.env.REFRESH_TOKEN_DAYS || 7) * 86400000),
        userAgent: req.headers['user-agent'] || null,
        ip: req.ip || req.connection?.remoteAddress || null,
    });
    // Revoke the old token by hash
    const oldHash = crypto.createHash('sha256').update(refreshToken).digest('hex');
    await TokenRepo.revokeByHash(oldHash, newHash);
    const expiresAt = new Date(Date.now() + Number(process.env.REFRESH_TOKEN_DAYS || 7) * 86_400_000);
    await logAuthEvent({ userId: userRow.userId, changeType: 'R', meta: { ...reqMeta(req) } });
    res.json({ token, expiresAt, refreshToken: newRefresh });
});

// POST /auth/logout { refreshToken } -> revoke single, or none to revoke all for user if authenticated
exports.logout = asyncHandler(async (req, res) => {
    if (req.user?.sub) {
        await logAuthEvent({ userId: req.user.sub, changeType: 'O', meta: { ...reqMeta(req) } });
    }
    const { refreshToken } = req.body || {};
    if (refreshToken) {
        const hash = crypto.createHash('sha256').update(refreshToken).digest('hex');
        await TokenRepo.revokeByHash(hash);
        return res.json({ success: true });
    }
    // If no token provided but user context exists, revoke all for user
    if (req.user?.sub) {
        await TokenRepo.revokeAllForUser(req.user.sub);
        return res.json({ success: true });
    }
    res.json({ success: true });
});

// POST /auth/change-password — authenticated user changes their own password
exports.changePassword = asyncHandler(async (req, res) => {
    const { currentPassword, newPassword } = await changePasswordSchema.validate(req.body, VALIDATE_OPTS);
    const userId = req.user?.sub;
    if (!userId) throw new AppError('Not authenticated', 401);

    const user = await UserRepo.get({ userId });
    if (!user) throw new AppError('User not found', 404);

    const valid = await UserRepo.verifyCredentials({ userName: user.userName, password: currentPassword });
    if (!valid) throw new AppError('Current password is incorrect', 401);

    await UserRepo.changePassword(userId, newPassword);

    await logAuthEvent({ userId, changeType: 'P', meta: reqMeta(req) });
    res.json({ success: true });
});
