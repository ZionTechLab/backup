const db = require('../database');
const { AppError } = require('./errorHandler');

// Legacy middleware: reads context purely from client headers WITHOUT validation.
// Kept only for backward compatibility. Do not mount on protected routes — it
// trusts X-User-Id / X-Tenant-Id / X-Company-Id, which a client can spoof.
function headerContext(req, res, next) {
  const tenantId = (req.headers['x-tenant-id'] || '').toString().trim();
  const companyId = (req.headers['x-company-id'] || '').toString().trim();
  const userId = (req.headers['x-user-id'] || '').toString().trim();
  if (tenantId) req.tenantId = tenantId;
  if (companyId) req.companyId = companyId;
  if (userId) req.userId = userId;
  next();
}

// Secure context middleware. MUST run after `authenticate` so req.user is set.
// - userId is taken from the verified JWT, never from a client header.
// - Any claimed tenantId / companyId is validated against the user's memberships
//   (sec_userTenants / sec_userCompanies). A mismatch is rejected with 403,
//   preventing a logged-in user from reading or writing another tenant's data.
async function tenantContext(req, res, next) {
  try {
    if (!req.user || !req.user.sub) {
      return next(new AppError('Unauthorized', 401));
    }

    // Identity always comes from the token.
    req.userId = req.user.sub;

    const tenantId = (req.headers['x-tenant-id'] || '').toString().trim();
    const companyId = (req.headers['x-company-id'] || '').toString().trim();

    if (tenantId) {
      const member = await db('sec_userTenants')
        .where({ userId: req.userId, tenantId })
        .first();
      if (!member) return next(new AppError('Forbidden: tenant not allowed', 403));
      req.tenantId = tenantId;
    }

    if (companyId) {
      const member = await db('sec_userCompanies')
        .where({ userId: req.userId, companyId })
        .first();
      if (!member) return next(new AppError('Forbidden: company not allowed', 403));
      req.companyId = companyId;
    }

    next();
  } catch (err) {
    next(err);
  }
}

module.exports = { headerContext, tenantContext };
