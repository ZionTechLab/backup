const { AppError } = require('./errorHandler');
const { getEffectivePermissions } = require('../repository/permissions');

// Route guard. Allows the request only if the user holds at least one of the
// required permission codes. OR semantics, mirroring the UI gate. Loads the
// user's effective codes once per request and caches them on req.
//
//   router.get('/x', requirePermission('feature-view'), handler)
//   router.post('/y', requirePermission('feature-new', 'feature-save'), handler)
function requirePermission(...required) {
  const need = required.flat().filter(Boolean);
  return async function (req, res, next) {
    try {
      if (!req.userId) return next(new AppError('Unauthenticated', 401));
      if (!req._permissions) {
        req._permissions = await getEffectivePermissions(req.userId, { companyId: req.companyId });
      }
      const ok = need.length === 0 || need.some((c) => req._permissions.includes(c));
      if (!ok) return next(new AppError('Forbidden: missing permission', 403));
      return next();
    } catch (err) {
      return next(err);
    }
  };
}

module.exports = { requirePermission };
