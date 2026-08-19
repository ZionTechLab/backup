const jwt = require('jsonwebtoken');

// Mint a valid access token for protected-route tests.
// Payload shape matches middleware/auth.generateToken (sub/userName/roleId).
function makeToken(overrides = {}) {
  const payload = {
    sub: '00000000-0000-0000-0000-000000000000',
    userName: 'tester',
    roleId: 1,
    ...overrides,
  };
  return jwt.sign(payload, process.env.JWT_SECRET, { expiresIn: '5m' });
}

module.exports = { makeToken };
