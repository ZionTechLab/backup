const db = require('../db/knex');

const findUserByUsername = async (username) => {
  const result = await db.raw(
    'SELECT * FROM users WHERE username = ? LIMIT 1',
    [username]
  );
  return result[0][0]; // for mysql2 driver
};

const saveRefreshToken = async (userId, refreshToken, dt, refreshTokenExpiration) => {
  const trx = await db.transaction();

  try {
    // Delete existing tokens for this user
    await trx.raw(
      `DELETE FROM user_tokens WHERE user_id = ?`,
      [userId]
    );

    // Insert new token
    await trx.raw(
      `INSERT INTO user_tokens (user_id, refresh_token, created_at, expires_at) VALUES (?, ?, ?, ?)`,
      [userId, refreshToken, dt, refreshTokenExpiration]
    );

    await trx.commit();
  } catch (err) {
    await trx.rollback();
    throw err; // bubble up to catch in login
  }
};


module.exports = {
  findUserByUsername,
  saveRefreshToken
};