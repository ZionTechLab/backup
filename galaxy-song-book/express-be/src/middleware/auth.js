const jwt = require('jsonwebtoken');
const { AppError } = require('./errorHandler');

// Config
const JWT_SECRET = process.env.JWT_SECRET || 'dev-insecure-secret-change-me';
const JWT_EXPIRES_IN = process.env.JWT_EXPIRES_IN || '1h';

// Create a signed access token from a user object
function generateToken(user, options = {}) {
  if (!user || !user.userId) {
    throw new AppError('Cannot generate token: missing user or user.userId', 500);
  }
  const payload = {
    sub: user.userId,
    userName: user.userName,
    roleId: user.roleId,
  };
  const token = jwt.sign(payload, JWT_SECRET, {
    algorithm: 'HS256',
    expiresIn: options.expiresIn || JWT_EXPIRES_IN,
  });
  return token;
}

// Express middleware to verify Bearer token and attach req.user
function authenticate(req, res, next) {
  try {
    // Try standard Authorization header first (Bearer <token>)
    const authHeader = req.headers['authorization'] || req.headers['Authorization'] || '';
    let token = '';
    if (authHeader) {
      // Support: 'Bearer <token>' or just '<token>'
      if (authHeader.toLowerCase().startsWith('bearer ')) {
        token = authHeader.slice(7).trim();
      } else {
        token = authHeader.trim();
      }
    }

    // Fallback: x-access-token header only. Query-string and body tokens are
    // intentionally not accepted — query tokens leak into access logs and
    // browser history, and body tokens are easy to forward unintentionally.
    if (!token) token = (req.headers['x-access-token'] || req.headers['X-Access-Token'] || '').trim();

    if (!token) throw new AppError('Missing access token', 401);
    const decoded = jwt.verify(token, JWT_SECRET);
    req.user = decoded;
    next();
  } catch (err) {
    // Propagate clearer errors for common JWT issues
    if (err && err.name === 'TokenExpiredError') return next(new AppError('Token expired', 401));
    return next(new AppError('Unauthorized', 401));
  }
}

// Role check middleware; accepts numeric roleIds or strings (role names if present in token)
function authorizeRoles(...allowed) {
  return (req, res, next) => {
    if (!req.user) return next(new AppError('Unauthorized', 401));
    if (!allowed || allowed.length === 0) return next();

    const has = allowed.some((role) => {
      if (typeof role === 'number') return req.user.roleId === role;
      if (typeof role === 'string') return req.user.roleName === role;
      return false;
    });
    if (!has) return next(new AppError('Forbidden', 403));
    next();
  };
}

module.exports = { authenticate, authorizeRoles, generateToken };
