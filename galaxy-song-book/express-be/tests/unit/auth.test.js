const jwt = require('jsonwebtoken');
const { generateToken, authenticate } = require('../../src/middleware/auth');

describe('generateToken', () => {
  test('signs a verifiable token carrying sub/userName/roleId', () => {
    const token = generateToken({ userId: 'u1', userName: 'bob', roleId: 2 });
    const decoded = jwt.verify(token, process.env.JWT_SECRET);
    expect(decoded.sub).toBe('u1');
    expect(decoded.userName).toBe('bob');
    expect(decoded.roleId).toBe(2);
  });

  test('throws when userId is missing', () => {
    expect(() => generateToken({ userName: 'nope' })).toThrow();
  });
});

// authenticate is Express middleware: it calls next() on success, or
// next(AppError) on failure. Drive it with a fake req and capture the next arg.
describe('authenticate', () => {
  const run = (headers = {}) =>
    new Promise((resolve) => {
      const req = { headers };
      authenticate(req, {}, (err) => resolve({ err, req }));
    });

  test('rejects a missing token with 401', async () => {
    const { err } = await run();
    expect(err).toBeTruthy();
    expect(err.statusCode).toBe(401);
  });

  test('accepts a valid Bearer token and attaches req.user', async () => {
    const token = generateToken({ userId: 'u9', userName: 'z', roleId: 1 });
    const { err, req } = await run({ authorization: `Bearer ${token}` });
    expect(err).toBeFalsy();
    expect(req.user.sub).toBe('u9');
  });

  test('rejects an expired token with 401', async () => {
    const expired = jwt.sign({ sub: 'u1' }, process.env.JWT_SECRET, { expiresIn: -10 });
    const { err } = await run({ authorization: `Bearer ${expired}` });
    expect(err.statusCode).toBe(401);
  });
});
