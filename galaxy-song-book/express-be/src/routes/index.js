const { authenticate } = require('../middleware/auth');
const { tenantContext } = require('../middleware/headerContext');
const db = require('../database');

// Import feature routers
const userRoutes = require('../features/user/routes');
const businessPartnerRoutes = require('../features/businessPartner/routes');
const debtorRoutes = require('../features/debtor/routes');
const authRoutes = require('../features/auth/routes');
const activityLogRoutes = require('../features/activityLog/routes');
const vehicleConfirmationRoutes = require('../features/vehicleConfirmation/routes');
const refCategoryRoutes = require('../features/category/routes');
const reportsRoutes = require('../features/reports/routes');
const itemRoutes = require('../features/item/routes');
const uomRoutes = require('../features/uom/routes');
const jobRoutes = require('../features/job/routes');
const jollySnapRoutes = require('../features/jolly-snap/routes');
const songRoutes = require('../features/songBook/routes');
const employeeRoutes = require('../features/hrm/employee_temp/routes');
const companyRoutes = require('../features/company/routes');
const currencyRoutes = require('../features/currency/routes');
const exchangeRateRoutes = require('../features/exchangeRate/routes');
const accountTypeRoutes = require('../features/gl/accountType/routes');
const chartOfAccountsRoutes = require('../features/gl/chartOfAccounts/routes');
const ledgerRoutes = require('../features/gl/ledger/routes');
const tenantRoutes = require('../features/tenant/routes');
const groupRoutes = require('../features/group/routes');
const glFinancialMonthRoutes = require('../features/gl/financialMonth/routes');
const glReportsRoutes = require('../features/gl/reports/routes');
const auditHistoryRoutes = require('../features/auditHistory/routes');
const permissionGroupRoutes = require('../features/permissionGroup/routes');
const filesRoutes = require('../features/files/routes');
const workflowRoutes = require('../features/workflow/routes');
const menuRoutes = require('../features/menu/routes');
const backupRoutes = require('../features/backup/routes');
const pcCashBookRoutes = require('../features/pettyCash/cashBook/routes');
const pcVoucherRoutes = require('../features/pettyCash/voucher/routes');
const pcExpenseCategoryRoutes = require('../features/pettyCash/expenseCategory/routes');
const pcIouRoutes = require('../features/pettyCash/iou/routes');
const pcIouRequestRoutes = require('../features/pettyCash/iouRequest/routes');
const pcSettlementRoutes = require('../features/pettyCash/settlement/routes');
const pcParamRoutes = require('../features/pettyCash/param/routes');
const pcApprovalBandRoutes = require('../features/pettyCash/approvalBand/routes');
const pcReplenishmentRoutes = require('../features/pettyCash/replenishment/routes');
const pcCashCountRoutes = require('../features/pettyCash/cashCount/routes');
const pcReportsRoutes = require('../features/pettyCash/reports/routes');
const orgUnitRoutes = require('../features/orgUnit/routes');

const uploadRoutes = require('./upload');

module.exports = function setupRoutes(app) {
  // Health check
  app.get('/api/health', async (req, res) => {
    try {
      await db.select(db.raw('1')).first();
      res.json({
        status: 'OK',
        message: 'Service Plus API is running',
        timestamp: new Date().toISOString()
      });
    } catch {
      res.status(503).json({
        status: 'ERROR',
        message: 'Database unavailable',
        timestamp: new Date().toISOString()
      });
    }
  });

  // Root
  app.get('/api', (req, res) => {
    res.json({
      message: 'Welcome to Service Plus API',
      version: '1.0.0'
    });
  });

  // Public auth routes (login, etc.)
  app.use('/api', authRoutes);

  // Public upload route (serve files from /uploads)
  // Mount the upload router before protected routes so its handlers match first
  app.use('/api', uploadRoutes);

  // === Auth boundary ===
  // Everything mounted below requires a valid JWT. `authenticate` verifies the
  // token; `tenantContext` then sets a trusted userId from the token and checks
  // that any claimed tenant/company belongs to the user (blocks header spoofing).
  // Default-deny: no protected route can be exposed by forgetting `authenticate`.
  app.use('/api', authenticate);
  app.use('/api', tenantContext);

  // Protected routes
  app.use('/api/users', userRoutes);
  app.use('/api/business-partners', businessPartnerRoutes);
  app.use('/api/invoice', debtorRoutes);
  app.use('/api/activitylogs', activityLogRoutes);
  app.use('/api/vehicle-confirmation', vehicleConfirmationRoutes);
  app.use('/api/ref-category', refCategoryRoutes);
  app.use('/api/item', itemRoutes);
  app.use('/api/uom', uomRoutes);
  app.use('/api/job', jobRoutes);
  app.use('/api/reports', reportsRoutes);
  app.use('/api/hrm/employee', employeeRoutes);
  app.use('/api/company', companyRoutes);
  app.use('/api/currency', currencyRoutes);
  app.use('/api/exchange-rate', exchangeRateRoutes);
  app.use('/api/gl/account-type', accountTypeRoutes);
  app.use('/api/gl/chart-of-accounts', chartOfAccountsRoutes);
  app.use('/api/gl/ledger', ledgerRoutes);
  app.use('/api/tenant', tenantRoutes);
  app.use('/api/group', groupRoutes);
  app.use('/api/gl/financial-month', glFinancialMonthRoutes);
  app.use('/api/gl/reports', glReportsRoutes);
  app.use('/api/audit', auditHistoryRoutes);
  app.use('/api/files', filesRoutes);
  app.use('/api/workflow', workflowRoutes);
  app.use('/api/menu', menuRoutes);
  app.use('/api/backup', backupRoutes);
  app.use('/api/permission-group', permissionGroupRoutes);
  app.use('/api/petty-cash/cash-book', pcCashBookRoutes);
  app.use('/api/petty-cash/voucher', pcVoucherRoutes);
  app.use('/api/petty-cash/expense-category', pcExpenseCategoryRoutes);
  app.use('/api/petty-cash/iou', pcIouRoutes);
  app.use('/api/petty-cash/iou-request', pcIouRequestRoutes);
  app.use('/api/petty-cash/settlement', pcSettlementRoutes);
  app.use('/api/petty-cash/param', pcParamRoutes);
  app.use('/api/petty-cash/approval-band', pcApprovalBandRoutes);
  app.use('/api/petty-cash/replenishment', pcReplenishmentRoutes);
  app.use('/api/petty-cash/cash-count', pcCashCountRoutes);
  app.use('/api/petty-cash/reports', pcReportsRoutes);
  app.use('/api/org-unit', orgUnitRoutes);
  app.use('/api/jolly-snap', jollySnapRoutes);
  app.use('/api/song-book', authenticate, songRoutes);
  // 404 handler
  app.use('*', (req, res) => {
    res.status(404).json({
      error: 'Route not found',
      message: `Cannot ${req.method} ${req.originalUrl}`
    });
  });

  // Error handler is registered globally in app.js
};
