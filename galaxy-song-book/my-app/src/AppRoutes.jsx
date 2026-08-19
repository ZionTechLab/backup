import { lazy, Suspense } from "react";
import { Routes, Route, Navigate, useParams } from "react-router-dom";

// Always-eager: structural shell and error pages
import MainLayout from "./layout/MainLayout";
import ServiceUnavailable from "./pages/ServiceUnavailable";
import NotFound from "./pages/NotFound";

// Lazy-loaded feature chunks — each becomes a separate bundle
const LoginPage          = lazy(() => import("./features/auth/LoginPage"));
const AuthCallback       = lazy(() => import("./features/auth/AuthCallback"));
const RegisterList       = lazy(() => import("./features/JollySnap/Register"));
const RegisterPage       = lazy(() => import("./features/JollySnap/Register/add"));
const SongBook           = lazy(() => import("./features/SongBook/Register"));
const SongView           = lazy(() => import("./features/SongBook/Register/view"));
const AddSong            = lazy(() => import("./features/SongBook/Register/add"));
const SongSettings       = lazy(() => import("./features/SongBook/Settings"));
const AboutUs            = lazy(() => import("./pages/AboutUs/AboutUs"));
const Dashboard          = lazy(() => import("./features/Dashboard"));
const BusinessPartner    = lazy(() => import("./features/BusinessPartners"));
const AddBusinessPartner = lazy(() => import("./features/BusinessPartners/AddBusinessPartner"));
const VehicleConfirmation = lazy(() => import("./features/VehicleConfirmation"));
const AddConfirmation    = lazy(() => import("./features/VehicleConfirmation/AddConfirmation"));
const UserMaster         = lazy(() => import("./features/UserMaster"));
const AddUser            = lazy(() => import("./features/UserMaster/AddUser"));
const Profile            = lazy(() => import("./features/UserMaster/Profile"));
const APISettings        = lazy(() => import("./features/UserMaster/APISettings"));
const NotificationSettings = lazy(() => import("./features/UserMaster/NotificationSettings"));
const Inquiry            = lazy(() => import("./features/Inquiry"));
const AddInquiry         = lazy(() => import("./features/Inquiry/AddInquiry"));
const Invoice            = lazy(() => import("./features/Invoice"));
const AddInvoice         = lazy(() => import("./features/Invoice/AddInvoice"));
const AdvanceIndex       = lazy(() => import("./features/Invoice/indexAdvance"));
const AddAdvance         = lazy(() => import("./features/Invoice/AddAdvance"));
const DailyReportIndex   = lazy(() => import("./features/DailyReport"));
const AddDailyReport     = lazy(() => import("./features/DailyReport/AddReport"));
const Reports            = lazy(() => import("./features/Reports"));
const References         = lazy(() => import("./features/References"));
const AddReferences      = lazy(() => import("./features/References/AddReferences"));
const CashBook           = lazy(() => import("./features/PettyCash/CashBook"));
const AddCashBook        = lazy(() => import("./features/PettyCash/CashBook/Add"));
const PcVoucher          = lazy(() => import("./features/PettyCash/Voucher"));
const AddPcVoucher       = lazy(() => import("./features/PettyCash/Voucher/Add"));
const ExpenseCategory    = lazy(() => import("./features/PettyCash/ExpenseCategory"));
const AddExpenseCategory = lazy(() => import("./features/PettyCash/ExpenseCategory/Add"));
const PermissionGroups   = lazy(() => import("./features/Security/PermissionGroups"));
const AddPermissionGroup = lazy(() => import("./features/Security/PermissionGroups/Add"));
const MenuArrange        = lazy(() => import("./features/MenuArrange"));
const BackupExport       = lazy(() => import("./features/Backup"));
const ApprovalLevels     = lazy(() => import("./features/Workflow/ApprovalLevels"));
const AddApprovalLevel   = lazy(() => import("./features/Workflow/ApprovalLevels/Add"));
const MyApprovals        = lazy(() => import("./features/Workflow/MyApprovals"));
const PcIou             = lazy(() => import("./features/PettyCash/Iou"));
const AddPcIou          = lazy(() => import("./features/PettyCash/Iou/Add"));
const ApprovePcIou      = lazy(() => import("./features/PettyCash/Iou/Approve"));
const PcIouRequest      = lazy(() => import("./features/PettyCash/IouRequest"));
const AddPcIouRequest   = lazy(() => import("./features/PettyCash/IouRequest/Add"));
const ApprovePcIouRequest = lazy(() => import("./features/PettyCash/IouRequest/Approve"));
const PcParam           = lazy(() => import("./features/PettyCash/Param"));
const AddPcParam        = lazy(() => import("./features/PettyCash/Param/Add"));
const PcApprovalBand    = lazy(() => import("./features/PettyCash/ApprovalBand"));
const AddPcApprovalBand = lazy(() => import("./features/PettyCash/ApprovalBand/Add"));
const PcSettlement      = lazy(() => import("./features/PettyCash/Settlement"));
const AddPcSettlement   = lazy(() => import("./features/PettyCash/Settlement/Add"));
const PcReplenishment   = lazy(() => import("./features/PettyCash/Replenishment"));
const AddPcReplenishment = lazy(() => import("./features/PettyCash/Replenishment/Add"));
const PcCashCount       = lazy(() => import("./features/PettyCash/CashCount"));
const AddPcCashCount    = lazy(() => import("./features/PettyCash/CashCount/Add"));
const PcDashboard       = lazy(() => import("./features/PettyCash/Dashboard"));
const PcIouRegister     = lazy(() => import("./features/PettyCash/Reports/IOURegister"));
const PcIouAging        = lazy(() => import("./features/PettyCash/Reports/IOUAging"));
const PcPartyOutstanding = lazy(() => import("./features/PettyCash/Reports/PartyOutstanding"));
const PcCashBookBalances = lazy(() => import("./features/PettyCash/Reports/CashBookBalances"));
const PcSummaryReport    = lazy(() => import("./features/PettyCash/Reports/SummaryReport"));
const PcDetailedReport   = lazy(() => import("./features/PettyCash/Reports/DetailedReport"));
const PcTrackingReport   = lazy(() => import("./features/PettyCash/Reports/TrackingReport"));
const PcAnalyticalReport = lazy(() => import("./features/PettyCash/Reports/AnalyticalReport"));
const PcAgeAnalysisAlert = lazy(() => import("./features/PettyCash/Alerts/AgeAnalysisAlert"));
const PcDailyPaymentsAlert = lazy(() => import("./features/PettyCash/Alerts/DailyPaymentsAlert"));
const ItemMaster         = lazy(() => import("./features/ItemMaster"));
const AddItem            = lazy(() => import("./features/ItemMaster/Add"));
const UomMaster          = lazy(() => import("./features/UomMaster"));
const AddUom             = lazy(() => import("./features/UomMaster/Add"));
const JobRegistration    = lazy(() => import("./features/JobRegistration"));
const AddJobRegistration = lazy(() => import("./features/JobRegistration/Add"));
const EmployeeMaster     = lazy(() => import("./features/HRCM/EmployeeMaster/index"));
const AddEmployee        = lazy(() => import("./features/HRCM/EmployeeMaster/Add"));
// Masters
const AccountTypes       = lazy(() => import("./features/Meridian/Masters/AccountType"));
const AddAccountType     = lazy(() => import("./features/Meridian/Masters/AccountType/AddAccountType"));
const Currencies         = lazy(() => import("./features/Meridian/Masters/Currency"));
const AddCurrency        = lazy(() => import("./features/Meridian/Masters/Currency/AddCurrency"));
const ExchangeRates      = lazy(() => import("./features/Meridian/Masters/ExchangeRate"));
const AddExchangeRate    = lazy(() => import("./features/Meridian/Masters/ExchangeRate/AddExchangeRate"));
const ChartOfAccounts    = lazy(() => import("./features/Meridian/Masters/ChartOfAccounts"));
const AddChartOfAccount  = lazy(() => import("./features/Meridian/Masters/ChartOfAccounts/AddChartOfAccount"));
const FinancialMonth     = lazy(() => import("./features/Meridian/Masters/FinancialMonth"));
const Groups             = lazy(() => import("./features/Meridian/Masters/Groups"));
const AddGroup           = lazy(() => import("./features/Meridian/Masters/Groups/AddGroup"));
const Companies          = lazy(() => import("./features/Meridian/Masters/Companies"));
const AddCompany         = lazy(() => import("./features/Meridian/Masters/Companies/AddCompany"));
const Tenants            = lazy(() => import("./features/Meridian/Masters/Tenants"));
const AddTenant          = lazy(() => import("./features/Meridian/Masters/Tenants/AddTenant"));
const TenantSettings     = lazy(() => import("./features/TenantSettings/TenantSettings"));
const WalletDashboard    = lazy(() => import("./features/Wallet"));

// Transactions
const Journals           = lazy(() => import("./features/Meridian/Transactions/Journals"));
const AddJournal         = lazy(() => import("./features/Meridian/Transactions/Journals/AddJournal"));

// Reports
const GeneralLedger      = lazy(() => import("./features/Meridian/Reports/GeneralLedger"));
const TrialBalance       = lazy(() => import("./features/Meridian/Reports/TrialBalance"));
const BalanceSheet       = lazy(() => import("./features/Meridian/Reports/BalanceSheet"));
const PnLStatement       = lazy(() => import("./features/Meridian/Reports/PnL"));
const ConsolidatedPnL    = lazy(() => import("./features/Meridian/Reports/ConsolidatedPnL"));
const FxVariance         = lazy(() => import("./features/Meridian/Reports/FxVariance"));

// Uncategorized
const Eliminations       = lazy(() => import("./features/Meridian/Eliminations"));
const AuditLog           = lazy(() => import("./features/AuditLog"));
const AuditRecordTimeline = lazy(() => import("./features/AuditLog/RecordTimeline"));
const ThemeSettings      = lazy(() => import("./pages/ThemeSettings/ThemeSettings"));
const Help               = lazy(() => import("./features/Help"));

// Organization
const BranchList         = lazy(() => import("./features/Organization/OrgUnit/screens").then(m => ({ default: m.BranchList })));
const AddBranch          = lazy(() => import("./features/Organization/OrgUnit/screens").then(m => ({ default: m.AddBranch })));
const DivisionList       = lazy(() => import("./features/Organization/OrgUnit/screens").then(m => ({ default: m.DivisionList })));
const AddDivision        = lazy(() => import("./features/Organization/OrgUnit/screens").then(m => ({ default: m.AddDivision })));
const DepartmentList     = lazy(() => import("./features/Organization/OrgUnit/screens").then(m => ({ default: m.DepartmentList })));
const AddDepartment      = lazy(() => import("./features/Organization/OrgUnit/screens").then(m => ({ default: m.AddDepartment })));
const SectionList        = lazy(() => import("./features/Organization/OrgUnit/screens").then(m => ({ default: m.SectionList })));
const AddSection         = lazy(() => import("./features/Organization/OrgUnit/screens").then(m => ({ default: m.AddSection })));

// Resolves route params in a redirect target, e.g. "/reference/:category" → "/reference/book"
const RedirectTo = ({ to }) => {
  const params = useParams();
  const resolved = Object.entries(params).reduce(
    (path, [key, val]) => path.replace(`:${key}`, val),
    to
  );
  return <Navigate to={resolved} replace />;
};

// Protected route wrapper
const ProtectedRoute = ({ isLoggedIn, children }) => {
  return isLoggedIn ? children : <Navigate to="/login" replace />;
};

// Public route wrapper
const PublicRoute = ({ isLoggedIn, children }) => {
  return isLoggedIn ? <Navigate to="/" replace /> : children;
};

const AppRoutes = ({ isLoggedIn }) => (
  <Suspense fallback={<div className="d-flex justify-content-center align-items-center app-loading-screen"><div className="spinner-border" /></div>}>
  <Routes>
    <Route
      path="/login"
      element={
        <PublicRoute isLoggedIn={isLoggedIn}>
          <LoginPage />
        </PublicRoute>
      }
    />
    <Route
      path="/register"
      element={
        <PublicRoute isLoggedIn={isLoggedIn}>
          <RegisterPage />
        </PublicRoute>
      }
    />
    {/* SSO redirect target — backend sends user here with ?code=&provider= */}
    <Route path="/auth/callback" element={<AuthCallback />} />

    {/* Public error route for network/back-end outages */}
    <Route path="/service-unavailable" element={<ServiceUnavailable />} />

    {/* Public routes with MainLayout */}
    <Route element={<MainLayout />}>
      <Route path="song-book/all" element={<SongBook />} />
      <Route path="about" element={<AboutUs />} />
      <Route path="song-book/settings" element={<SongSettings />} />
      <Route path="song-book/song/view/:id" element={<SongView />} />
      <Route path="song-book/song/add" element={<AddSong />} />
      <Route path="song-book/song/edit/:id" element={<AddSong />} />
    </Route>

    <Route
      path="/"
      element={
        <ProtectedRoute isLoggedIn={isLoggedIn}>
          <MainLayout />
        </ProtectedRoute>
      }
    >
      <Route path="employee" element={<EmployeeMaster />} />
      <Route path="employee/add" element={<AddEmployee />} />
      <Route path="employee/edit/:id" element={<AddEmployee />} />
      <Route path="jolly-snap/register" element={<RegisterList />} />
      <Route path="jolly-snap/register/add" element={<RegisterPage />} />
      <Route path="jolly-snap/register/edit/:id" element={<RegisterPage />} />
      <Route path="business-partner" element={<BusinessPartner />} />
      <Route index element={<Dashboard />} />
      <Route path="business-partner/add" element={<AddBusinessPartner />} />
      <Route
        path="business-partner/edit/:id"
        element={<AddBusinessPartner />}
      />

      <Route path="vehicle-confirmation" element={<VehicleConfirmation />} />
      <Route path="vehicle-confirmation/add" element={<AddConfirmation />} />
      <Route
        path="vehicle-confirmation/edit/:id"
        element={<AddConfirmation />}
      />
      <Route path="inquiry" element={<Inquiry />} />
      <Route path="inquiry/add" element={<AddInquiry />} />
      <Route path="inquiry/edit/:id" element={<AddInquiry />} />

      <Route path="user-master" element={<UserMaster />} />
      <Route path="user-master/add" element={<AddUser />} />
      <Route path="user-master/edit/:userId" element={<AddUser />} />

      <Route path="petty-cash/cash-book" element={<CashBook />} />
      <Route path="petty-cash/cash-book/add" element={<AddCashBook />} />
      <Route path="petty-cash/cash-book/edit/:id" element={<AddCashBook />} />
      <Route path="petty-cash/voucher" element={<PcVoucher />} />
      <Route path="petty-cash/voucher/add" element={<AddPcVoucher />} />
      <Route path="petty-cash/voucher/edit/:id" element={<AddPcVoucher />} />
      <Route path="settings/permission-groups" element={<PermissionGroups />} />
      <Route path="settings/permission-groups/add" element={<AddPermissionGroup />} />
      <Route path="settings/permission-groups/edit/:id" element={<AddPermissionGroup />} />
      <Route path="settings/approval-levels" element={<ApprovalLevels />} />
      <Route path="settings/approval-levels/add" element={<AddApprovalLevel />} />
      <Route path="settings/approval-levels/edit/:id" element={<AddApprovalLevel />} />
      <Route path="my-approvals" element={<MyApprovals />} />
      <Route path="petty-cash/expense-category" element={<ExpenseCategory />} />
      <Route path="petty-cash/expense-category/add" element={<AddExpenseCategory />} />
      <Route path="petty-cash/expense-category/edit/:id" element={<AddExpenseCategory />} />
      <Route path="petty-cash/iou" element={<PcIou />} />
      <Route path="petty-cash/iou/add" element={<AddPcIou />} />
      <Route path="petty-cash/iou/edit/:id" element={<AddPcIou />} />
      <Route path="petty-cash/iou/approve/:id" element={<ApprovePcIou />} />
      <Route path="petty-cash/iou-request" element={<PcIouRequest />} />
      <Route path="petty-cash/iou-request/add" element={<AddPcIouRequest />} />
      <Route path="petty-cash/iou-request/edit/:id" element={<AddPcIouRequest />} />
      <Route path="petty-cash/iou-request/approve/:id" element={<ApprovePcIouRequest />} />
      <Route path="petty-cash/param" element={<PcParam />} />
      <Route path="petty-cash/param/add" element={<AddPcParam />} />
      <Route path="petty-cash/param/edit/:id" element={<AddPcParam />} />
      <Route path="petty-cash/approval-band" element={<PcApprovalBand />} />
      <Route path="petty-cash/approval-band/add" element={<AddPcApprovalBand />} />
      <Route path="petty-cash/approval-band/edit/:id" element={<AddPcApprovalBand />} />
      <Route path="petty-cash/settlement" element={<PcSettlement />} />
      <Route path="petty-cash/settlement/add" element={<AddPcSettlement />} />
      <Route path="petty-cash/settlement/edit/:id" element={<AddPcSettlement />} />
      <Route path="petty-cash/replenishment" element={<PcReplenishment />} />
      <Route path="petty-cash/replenishment/add" element={<AddPcReplenishment />} />
      <Route path="petty-cash/replenishment/edit/:id" element={<AddPcReplenishment />} />
      <Route path="petty-cash/cash-count" element={<PcCashCount />} />
      <Route path="petty-cash/cash-count/add" element={<AddPcCashCount />} />
      <Route path="petty-cash/cash-count/edit/:id" element={<AddPcCashCount />} />
      <Route path="petty-cash/dashboard" element={<PcDashboard />} />
      <Route path="petty-cash/reports/iou-register" element={<PcIouRegister />} />
      <Route path="petty-cash/reports/iou-aging" element={<PcIouAging />} />
      <Route path="petty-cash/reports/party-outstanding" element={<PcPartyOutstanding />} />
      <Route path="petty-cash/reports/cashbook-balances" element={<PcCashBookBalances />} />
      <Route path="petty-cash/reports/summary" element={<PcSummaryReport />} />
      <Route path="petty-cash/reports/detailed" element={<PcDetailedReport />} />
      <Route path="petty-cash/reports/tracking" element={<PcTrackingReport />} />
      <Route path="petty-cash/reports/analytical" element={<PcAnalyticalReport />} />
      <Route path="petty-cash/alerts/age-analysis" element={<PcAgeAnalysisAlert />} />
      <Route path="petty-cash/alerts/daily-payments" element={<PcDailyPaymentsAlert />} />

      <Route path="item-master" element={<ItemMaster />} />
      <Route path="item-master/add" element={<AddItem />} />
      <Route path="item-master/edit/:id" element={<AddItem />} />
      <Route path="uom-master" element={<UomMaster />} />
      <Route path="uom-master/add" element={<AddUom />} />
      <Route path="uom-master/edit/:id" element={<AddUom />} />

      <Route path="job-registration" element={<JobRegistration />} />
      <Route path="job-registration/add" element={<AddJobRegistration />} />
      <Route
        path="job-registration/edit/:id"
        element={<AddJobRegistration />}
      />
      <Route path="profile" element={<Profile />} />
      <Route path="api-settings" element={<APISettings />} />
      <Route path="notification-settings" element={<NotificationSettings />} />

      <Route path="theme" element={<ThemeSettings />} />

      <Route path="help" element={<Help />} />

      <Route path="invoice" element={<Invoice />} />
      <Route path="invoice/add" element={<AddInvoice />} />
      <Route path="invoice/edit/:id" element={<AddInvoice />} />

      <Route path="tax-invoice" element={<Invoice />} />
      <Route path="tax-invoice/add" element={<AddInvoice />} />
      <Route path="tax-invoice/edit/:id" element={<AddInvoice />} />

      <Route path="daily-report" element={<DailyReportIndex />} />
      <Route path="daily-report/add" element={<AddDailyReport />} />
      <Route path="daily-report/edit/:id" element={<AddDailyReport />} />

      <Route path="reports" element={<Reports />} />

      <Route path="advance" element={<AdvanceIndex />} />
      <Route path="advance/add" element={<AddAdvance />} />
      <Route path="advance/edit/:id" element={<AddAdvance />} />

      <Route path="payment" element={<AdvanceIndex />} />
      <Route path="payment/add" element={<AddAdvance />} />
      <Route path="payment/edit/:id" element={<AddAdvance />} />

      {/* Redirects from old misspelled paths */}
      <Route path="refferance/:category" element={<RedirectTo to="/reference/:category" />} />
      <Route path="refferance/:category/add" element={<RedirectTo to="/reference/:category/add" />} />
      <Route path="refferance/:category/edit/:id" element={<RedirectTo to="/reference/:category/edit/:id" />} />
      <Route path="vehicale-confirmation" element={<Navigate to="/vehicle-confirmation" replace />} />
      <Route path="vehicale-confirmation/add" element={<Navigate to="/vehicle-confirmation/add" replace />} />
      <Route path="vehicale-confirmation/edit/:id" element={<RedirectTo to="/vehicle-confirmation/edit/:id" />} />
      {/* Reference routes */}
      <Route path="reference/:category" element={<References />} />
      <Route path="reference/:category/add" element={<AddReferences />} />
      <Route
        path="reference/:category/edit/:id"
        element={<AddReferences />}
      />

      <Route path="settings/companies" element={<Companies />} />
      <Route path="settings/companies/add" element={<AddCompany />} />
      <Route path="settings/companies/edit/:id" element={<AddCompany />} />

      <Route path="settings/menu" element={<MenuArrange />} />
      <Route path="settings/backup-export" element={<BackupExport />} />
      <Route path="settings/users" element={<UserMaster />} />
      <Route path="settings/users/add" element={<AddUser />} />
      <Route path="settings/users/edit/:userId" element={<AddUser />} />

      <Route path="settings/currencies" element={<Currencies />} />
      <Route path="settings/currencies/add" element={<AddCurrency />} />
      <Route path="settings/currencies/edit/:id" element={<AddCurrency />} />

      <Route path="settings/exchange-rates" element={<ExchangeRates />} />
      <Route path="settings/exchange-rates/add" element={<AddExchangeRate />} />
      <Route path="settings/exchange-rates/edit/:id" element={<AddExchangeRate />} />

      <Route path="settings/fiscal-year" element={<FinancialMonth />} />

      <Route path="settings/account-types" element={<AccountTypes />} />
      <Route path="settings/account-types/add" element={<AddAccountType />} />
      <Route path="settings/account-types/edit/:id" element={<AddAccountType />} />

      <Route path="coa" element={<ChartOfAccounts />} />
      <Route path="coa/add" element={<AddChartOfAccount />} />
      <Route path="coa/edit/:id" element={<AddChartOfAccount />} />

      <Route path="journals" element={<Journals />} />
      <Route path="journals/add" element={<AddJournal />} />
      <Route path="journals/edit/:id" element={<AddJournal />} />

      <Route path="ledger" element={<GeneralLedger />} />

      <Route path="reports/trial-balance" element={<TrialBalance />} />
      <Route path="reports/balance-sheet" element={<BalanceSheet />} />
      <Route path="reports/pnl" element={<PnLStatement />} />
      <Route path="group/pnl" element={<ConsolidatedPnL />} />
      <Route path="group/eliminations" element={<Eliminations />} />
      <Route path="group/fx-variance" element={<FxVariance />} />

      <Route path="settings/tenants" element={<Tenants />} />
      <Route path="settings/tenants/add" element={<AddTenant />} />
      <Route path="settings/tenants/edit/:id" element={<AddTenant />} />
      <Route path="settings/tenant-preferences" element={<TenantSettings />} />

      <Route path="settings/groups" element={<Groups />} />
      <Route path="settings/groups/add" element={<AddGroup />} />
      <Route path="settings/groups/edit/:id" element={<AddGroup />} />

      <Route path="audit-log" element={<AuditLog />} />
      <Route path="audit-log/record/:tableName/:recordId" element={<AuditRecordTimeline />} />

      <Route path="masters/branch" element={<BranchList />} />
      <Route path="masters/branch/add" element={<AddBranch />} />
      <Route path="masters/branch/edit/:id" element={<AddBranch />} />
      <Route path="masters/division" element={<DivisionList />} />
      <Route path="masters/division/add" element={<AddDivision />} />
      <Route path="masters/division/edit/:id" element={<AddDivision />} />
      <Route path="masters/department" element={<DepartmentList />} />
      <Route path="masters/department/add" element={<AddDepartment />} />
      <Route path="masters/department/edit/:id" element={<AddDepartment />} />
      <Route path="masters/section" element={<SectionList />} />
      <Route path="masters/section/add" element={<AddSection />} />
      <Route path="masters/section/edit/:id" element={<AddSection />} />

      <Route path="wallet" element={<WalletDashboard />} />

      <Route path="*" element={<NotFound />} />
    </Route>
    <Route path="*" element={<NotFound />} />
  </Routes>
  </Suspense>
);

export default AppRoutes;
