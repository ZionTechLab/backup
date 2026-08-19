const crypto = require('crypto');
const db = require('../../database');

// Hash function for storing refresh tokens (not reversible)
function hashToken(token) {
  return crypto.createHash('sha256').update(token).digest('hex');
}

// Generate a secure random token string
function generateRefreshTokenString() {
  return crypto.randomBytes(48).toString('base64url');
}

const TokenRepo = {
  generate() {
    const token = generateRefreshTokenString();
    const tokenHash = hashToken(token);
    return { token, tokenHash };
  },

  async save({ userId, tokenHash, expiresAt, userAgent, ip }) {
    const [index] = await db('sec_refreshTokens').insert({
      userId,
      tokenHash,
      expiresAt,
      userAgent,
      ip,
    });
    return db('sec_refreshTokens').where({ index }).first();
  },

  async findValid(token) {
    const tokenHash = hashToken(token);
    const row = await db('sec_refreshTokens')
      .where({ tokenHash, revoked: false })
      .andWhere('expiresAt', '>', new Date())
      .first();
    return row || null;
  },

  async revokeByHash(tokenHash, replacedByHash = null) {
    return db('sec_refreshTokens')
      .where({ tokenHash })
      .update({ revoked: true, revokedAt: new Date(), replacedByHash });
  },

  async revokeAllForUser(userId) {
    return db('sec_refreshTokens')
      .where({ userId, revoked: false })
      .update({ revoked: true, revokedAt: new Date() });
  },
};

module.exports = { TokenRepo, hashToken };
