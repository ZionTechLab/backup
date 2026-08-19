using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;
using System.Reflection;
using Digiteq;
using Digiteq_Logic;
using System.Threading;
using System.Diagnostics;
using SEACC_Report;

namespace Digiteq
{
    public partial class frmMainNew : Form
    {
        bool bIsmaximized = false;
        string ctrl2 = "";

        #region Form Load
        public frmMainNew()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            MenuResize();
            toolLoginUser.Text = clsSecurity.UserNameLoged;

            if (!clsSecurity.bIsLive)
            {
                ucTittleBar_Main1.BackColor= System.Drawing.Color.FromArgb(127, 140, 141);
                panel5.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            }

            clsBackProcess.AutoAssignCompanyValue();

            if (clsFormatter.DigiteqTitle != "")
                ucTittleBar_Main1.SeaccType = clsFormatter.DigiteqTitle.Substring(5);
            else
                ucTittleBar_Main1.SeaccType = "";

            ucTittleBar_Main1.CompanyName = "  LICENSED USER  :  " + clsSecurity.CompanyName + "  [--" + clsGenaralName.getName_CompanyBranchMaster(clsSecurity.BranchID) + "--]";

            Image img = Digiteq.Properties.Resources.no_image;

            try
            {
                MemoryStream ms = new MemoryStream(clsCommon.getCompanyImage());
                img = Image.FromStream(ms);
            }
            catch (Exception)
            {
            }

            if (img.Height < img.Width)
                picUsersCompanyImage.Height = picUsersCompanyImage.Height / 2;

            picUsersCompanyImage.Image = img;

            lblTest.Visible = (clsConfig.bIsTestLabelVisibleInMainForm) ? true : false;
            clsConfig.bIsTestLabelVisibleInMainForm = false;

            LoadCategory();
            FillProfileDetail();

            btnMIS.FlatAppearance.MouseOverBackColor = ControlPaint.Light(Color.FromArgb(44, 62, 80));
            btnMIS.FlatAppearance.MouseDownBackColor = ControlPaint.Light(Color.FromArgb(44, 62, 80));

            #region Check for Sub Folders
            string sBaseDirectory = Path.GetDirectoryName(Application.ExecutablePath);
          //  string sExeLocation = sBaseDirectory + "\\" + clsGenaralName.getLocation_ModuleExe(iModule_index);

            string path1 = sBaseDirectory+ @"\ReportExportTemp";
            if (!System.IO.Directory.Exists(path1))
                System.IO.Directory.CreateDirectory(path1);

            string path2 = sBaseDirectory + @"\Attachments";
            if (!System.IO.Directory.Exists(path2))
                System.IO.Directory.CreateDirectory(path2);

            string path3 = @"C:\digiteq\";
            if (!System.IO.Directory.Exists(path3))
                System.IO.Directory.CreateDirectory(path3);

            string path4 = sBaseDirectory + @"\Excel_Reports";
            if (!System.IO.Directory.Exists(path4))
                System.IO.Directory.CreateDirectory(path4);
            #endregion

            if (backgroundWorker1.IsBusy != true)
                backgroundWorker1.RunWorkerAsync();

            timer1.Start();
            btn_Size_Click(null, null);
        }
        #endregion

        #region Load Category
        private void LoadCategory()
        {
            pnlCategory.Controls.Clear();

            foreach (tbl_securityFormCategory detail in tbl_securityFormCategory.SelectAll())
            {
                if (detail != null && detail.IsVisible)
                {
                    Button btnCategory = new Button();
                    FillCategory(detail, btnCategory);
                    btnCategory.Click += new EventHandler(CategoryClick);
                    btnCategory.MouseLeave += new EventHandler(Text_MouseLeave);
                    btnCategory.MouseMove += new MouseEventHandler(Text_MouseMove);
                    btnCategory.MouseHover += new EventHandler(Category_MouseHover);
                }
            }
        }
        #endregion

        #region Fill Category
        private void FillCategory(tbl_securityFormCategory Category, Button btnCategory)
        {
            try
            {
                btnCategory.Name = Category.FormCategory_ID;
                btnCategory.Text = Category.DisplayName;
                btnCategory.Tag = Category.FormCategory_ID;
                btnCategory.Image = getCategoryImage(Category.FormCategory_ID);

                btnCategory.Size = new Size(55, 52);
                btnCategory.FlatStyle = FlatStyle.Flat;
                btnCategory.FlatAppearance.BorderSize = 0;
                btnCategory.FlatAppearance.MouseOverBackColor = ControlPaint.Light(Color.FromArgb(44, 62, 80));
                btnCategory.FlatAppearance.MouseDownBackColor = ControlPaint.Light(Color.FromArgb(44, 62, 80));
                btnCategory.BackColor = System.Drawing.Color.Transparent;
                btnCategory.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                btnCategory.ImageAlign = ContentAlignment.TopCenter;
                btnCategory.TextAlign = ContentAlignment.BottomCenter;
                btnCategory.ForeColor = Color.WhiteSmoke;
                btnCategory.AutoSize = false;

                if (!Category.IsEnable)
                    btnCategory.Enabled = false;

                pnlCategory.Controls.Add(btnCategory);
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region Click on Category
        private void CategoryClick(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                string ctrl = ((Control)sender).Name;
                string s = ((Control)sender).Tag.ToString().Trim();

                foreach (Control con in pnlCategory.Controls)
                {
                    con.BackColor = Color.Transparent;
                }
                ((Control)sender).BackColor = ControlPaint.Light(Color.FromArgb(44, 62, 80));

                FillForm(s);
                FillViewer(s);

                if (ctrl2 == ctrl)
                {
                    MenuResize();
                }
                else
                {
                    ctrl2 = ((Control)sender).Name;
                    pnlDock.Width = 260;
                }

                #region Check Expiration Date
                if (clsConfig.dtmDateExpiration < DateTime.Now)
                {
                    MessageBox.Show("Product has been Expired....." + Keys.Return + "Please contact Digiteq for more details");
                    Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Fill Form
        private void FillForm(string sCategoryID)
        {
            try
            {
                tbl_securityFormCategory category = tbl_securityFormCategory.Select(sCategoryID);
                if (category != null)
                {
                    bool bPass = false;
                    if (category.FormCategory_ID == clsConfig.sAdminCategoryID)
                    {
                        if (clsSecurity.UserIDLoged.Trim().ToUpper() == "ADMIN" || clsSecurity.UserIDLoged.Trim().ToUpper() == "DIGITEQ")
                            bPass = true;
                    }
                    else
                    {
                        if (clsSecurity.UserIDLoged.Trim().ToUpper() != "ADMIN")
                            bPass = true;
                    }

                    if (bPass)
                    {
                        dgrForm.DataSource = tbl_securityFormMaster.SelectAllbyFormCategory_ID_DataTable(sCategoryID, false);
                    }
                    else
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Fill Viewer
        private void FillViewer(string sCategoryID)
        {
            tbl_securityFormCategory category = tbl_securityFormCategory.Select(sCategoryID);
            if (category != null)
            {
                bool bPass = false;
                if (category.FormCategory_ID == clsConfig.sAdminCategoryID)
                {
                    if (clsSecurity.UserIDLoged.Trim().ToUpper() == "ADMIN" || clsSecurity.UserIDLoged.Trim().ToUpper() == "DIGITEQ")
                        bPass = true;
                }
                else
                {
                    if (clsSecurity.UserIDLoged.Trim().ToUpper() != "ADMIN")
                        bPass = true;
                }

                if (bPass)
                {
                    dgrViwer.DataSource = tbl_securityFormMaster.SelectAllbyFormCategory_ID_DataTable(sCategoryID, true);
                }
                else
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Get Image
        private Image getCategoryImage(string sCategoryID)
        {
            Image image = Digiteq.Properties.Resources.accept;
            tbl_securityFormCategory detail = tbl_securityFormCategory.Select(sCategoryID);
            if (detail != null && detail.Image != null)
            {
                if (detail.Image.Length > 0)
                {
                    MemoryStream ms = new MemoryStream(detail.Image);
                    image = Image.FromStream(ms);
                }
            }
            return image;
        }
        #endregion

        #region Get Call Form ID
        private string getCallForm(int iFormID)
        {
            string sConfigFormID = "";
            switch (iFormID)
            {
                case 1:
                    DisplayItemMaster(FormName.ItemMaster);
                    break;
                case 2:
                    DisplayCustomerMaster(FormName.CustomerMaster);
                    break;
                case 3:
                    DisplaySupplierMaster(FormName.SupplierMaster);
                    break;
                case 9:
                    DisplayCustomerOrder(FormName.CustomerOrder);
                    break;
                case 10:
                    DisplayCustomerInvoice(FormName.VATInvoice);
                    break;
                case 610:
                    DisplayCustomerInvoice(FormName.Invoice_TAXReverced);
                    break;
                case 11:
                    DisplayCustomerDO(FormName.CusDeliveryOrder);
                    break;
                case 15:
                    DisplayLoanIn();
                    break;
                case 16:
                    DisplayLoanOut();
                    break;
                case 20:
                    DisplayChequeManagement();
                    break;
                case 23:
                    DisplayCustomerQuotation(FormName.CusQuotation);
                    break;
                case 24:
                    DisplayProformaInvoice(FormName.CusProformaInvoice);
                    break;
                case 25:
                    DisplayCompanyInfor(FormName.CompanyInfor);
                    break;
                case 26:
                    DisplayUserMaster();
                    break;
                case 27:
                    DisplayUserPermission();
                    break;
                case 29:
                    DisplayReportMaster();
                    break;
                case 33:
                    DisplayMasterOther();
                    break;
                case 45:
                    DisplayDatabaseBackup();
                    break;
                case 53:
                    DisplayEmployeeMaster();
                    break;
                case 60:
                    DisplayChequetracer();
                    break;
                case 62:
                    DisplaysasGRNTradingStock();
                    break;
                case 63:
                    DisplaysasGINTradingStock();
                    break;
                case 64:
                    DisplaysasSRNTradingStock();
                    break;
                case 65:
                    DisplayReportChequeRegister();
                    break;
                case 66:
                    DisplayReportChequeStanded();
                    break;
                case 67:
                    DisplayReportSalesStanded();
                    break;
                case 68:
                    DisplayPreCosting();
                    break;
                //case 69:
                //    DisplayMachineMaster();
                //    break;
                case 80:
                    DisplayBillsRegister();
                    break;
                case 81:
                    DisplayCustomizedReports();
                    break;
                case 82:
                    DisplayJobViewer();
                    break;
                case 94:
                    DisplayCompanyMaster();
                    break;
                case 98:
                    DisplayReceipt_Account();
                    break;
                case 102:
                    PettyCashAccount();
                    break;
                case 103:
                    UpdatePettyCashAccounts();
                    break;
                case 105:
                    masPettyCash();
                    break;
                case 106:
                    securityPettyCash();
                    break;
                case 107:
                    ViewerFinishedGood();
                    break;
                case 108:
                    ViewerRawMaterial();
                    break;
                case 109:
                    ViewerLaminatedMaterial();
                    break;
                //case 110:
                //    ItemCreationSemiFinished();
                //    break;
                case 111:
                    ViewerSection();
                    break;
                case 112:
                    ViewerMachine();
                    break;
                case 113:
                    SectionGRN();
                    break;
                case 114:
                    SectionGIN();
                    break;
                case 115:
                    SectionSR(FormName.scsSRNSectionStock);
                    break;
                //case 116:
                //    ItemMasterHome();
                //    break;
                case 117:
                    PettyCashAccountr();
                    break;
                case 118:
                    ReportItemSummery();
                    break;
                case 119:
                    //ReportFlowStock();
                    break;
                case 120:
                    OffcutEntry();
                    break;
                case 14:
                    scsGoodTransferNote();
                    break;
                case 127:
                    QuotaionRequest();
                    break;
                case 128:
                    SupplierPO(FormName.scsPOSupplier);
                    break;
                case 129:
                    SupplierGRN();
                    break;
                case 130:
                    SupplierPRN();
                    break;
                case 131:
                    ExternalGIN();
                    break;
                case 132:
                    DamageGoodsNote();
                    break;
                case 133:
                    DiscardedGoodsNote();
                    break;
                case 135:
                    CreditNote(FormName.bssCreditNote);
                    break;
                case 136:
                    InvoiceSettlement(FormName.bssInvoiceSettlement);
                    break;
                case 137:
                    CashPayment();
                    break;
                case 138:
                    ChequePayment();
                    break;
                case 139:
                    ChequeReturn();
                    break;
                case 140:
                    DebitNote(FormName.bssDebitNote);
                    break;
                case 141:
                    GRNSettlement();
                    break;
                case 152:
                    PaymentAdvice();
                    break;
                case 154:
                    CompanyEmployeeMaster();
                    break;
                case 155:
                    Inquiry(FormName.sasInquiry);
                    break;
                case 156:
                    StockAdjusment();
                    break;
                case 159:
                    StockAdd();
                    break;
                case 160:
                    TradingGoodReceiveNote();
                    break;
                case 169:
                    SalesPendingOrder();
                    break;
                case 170:
                    SalesRegistry();
                    break;
                case 174:
                    ManageRoute();
                    break;
                case 175:
                    RouteMaster();
                    break;
                case 176:
                    SalesReturnNote(FormName.sasSalesReturenNote);
                    break;
                case 177:
                    ProductionJobClose();
                    break;
                case 195:
                    ReportPermission();
                    break;
                case 192:
                    StoreProduction();
                    break;
                case 194:
                    PrinterMaster();
                    break;
                case 196:
                    ItemSpred();
                    break;
                case 197:
                    StockStandedReport();
                    break;
                case 205:
                    UserControl();
                    break;
                case 208:
                    AccountReceivableReports();
                    break;
                case 378:
                    AccountPayableReports();
                    break;
                case 210:
                    StockRegisterReport();
                    break;
                case 211:
                    CustomerOrderEdit();
                    break;
                case 212:
                    PendingApproval();
                    break;
                case 214:
                    UserPermission_PendingApproval();
                    break;
                case 215:
                    UserPermission_PendingChecking();
                    break;
                case 219:
                    UserPermission_PendingAudit();
                    break;
                case 220:
                    SectionCloser();
                    break;
                case 227:
                    DeliveryOrderPlan();
                    break;
                case 232:
                    MasterPettyCachReport();
                    break;
                case 233:
                    ReportSetting();
                    break;
                case 234:
                    AutoGenareteNumberSetting();
                    break;
                case 235:
                    MasterPettyCachBasicReport();
                    break;
                case 237:
                    JobMarckupPrecentage();
                    break;
                case 240:
                    DeliveryOrderManualSettle();
                    break;
                case 241:
                    EmailConfig();
                    break;
                case 245:
                    AccountRegisterReport();
                    break;
                case 246:
                    SalesTools();
                    break;
                case 247:
                    DisplayFinanceMaster();
                    break;
                case 249:
                    //CustomReportSummary();
                    break;
                case 252:
                    StockControl();
                    break;
                case 253:
                    PurchaseRequisition();
                    break;
                case 254:
                    DisplayItemMasterFinance();
                    break;
                case 255:
                    DisplayReceipt_Account();
                    break;
                case 257:
                    DisplayCustomerMasterReport();
                    break;
                case 263:
                    DispalyDetailsStockStatement();
                    break;
                case 399:
                    DisplayAdminRegisterReport();
                    break;
                case 271:
                    DisplayReimbursement();
                    break;
                case 272:
                    DisplayAdminStandardReport();
                    break;
                case 275:
                    DisplayAlertSetting();
                    break;
                case 441:
                    CustomerRefundNote(FormName.bssCustomerRefundableNote);
                    break;
                case 282:
                    DisplayPurgeTool();
                    break;
                case 295:
                    BillsTools();
                    break;
                case 380:
                    DisplaySalesCommission();
                    break;
                case 381:
                    DisplayEmployeeCommissionRates();
                    break;
                case 400:
                    FinancialYear();
                    break;
                case 401:
                    ChartOfAccount();
                    break;
                case 405:
                    ChartOfAccountReport();
                    break;
                case 406:
                    ReceiptVoucher(FormName.accReceiptVoucher);
                    break;
                case 407:
                    DoubleEntrySlotAccount();
                    break;
                case 409:
                    JournalEntry2(FormName.accJournalEntry_Standard);
                    break;
                case 410:
                    DisplayPaymentVoucher(FormName.accPaymentVoucher);
                    break;
                case 411:
                    DisplayAccountNoteMaster();
                    break;
                case 414:
                    DisplayAccountMaster();
                    break;
                case 415:
                    DisplayAccountPayableNote(FormName.accAccountpayableNote);
                    break;
                case 416:
                    DisplayAccountRegisterReport();
                    break;
                case 418:
                    JournalEntry2(FormName.accJournalEntry_Bank);
                    break;
                case 419:
                    DisplayOpeningBalance();
                    break;
                case 437:
                    DisplayAccountDebitNote(FormName.accDebitNote);
                    break;
                case 438:
                    //DisplayGTNSummaryReport();
                    break;
                case 514:
                    DisplayBudgetPlanning();
                    break;
                case 516:
                    DisplayStoreWisePermission();
                    break;
                case 607:
                    ChequeSetting();
                    break;
                case 453:
                    DisplayAPNSettlementViewer();
                    break;
                case 454:
                    DisplaySupplierJournalViewer();
                    break;
                case 617:
                    DisplayCOManuallySettleTool();
                    break;
                case 350:
                    CreditorSettlement(FormName.accCreditorSettlement);
                    break;
                case 461:
                    DisplayNotPosted_Transactions();
                    break;
                case 613:
                    DisplayItemMasterCustomerWiseSalesCode();
                    break;
                case 618:
                    ChequeToNewMode_PV();
                    break;
                case 620:
                    SalesInvoice2(FormName.SalesInvoice2);
                    break;
                case 621:
                    DisplayUC_ReceiptSales(FormName.UCReceipt);
                    break;
                case 628:
                    DisplaySalesCustom();
                    break;
                case 629:
                    DisplayStockCustom();
                    break;
                case 630:
                    JournalEntry2(FormName.accJournalEntry_Creditor);
                    break;
                case 631:
                    JournalEntry2(FormName.accJournalEntry_Debtor);
                    break;
                case 637:
                    JournalEntry2(FormName.accJournalEntry_Advance);
                    break;
                case 661:
                    DisplayAccountPayableNote_Allocation(FormName.accAccountpayableNote_Allocation);
                    break;
                case 632:
                    FixedAssetRegistration(FormName.accFixedAssetRegistration);
                    break;
                case 633:
                    AssetsTransferNote(FormName.accAssetTransferNote);
                    break;
                case 634:
                    DisplaySupplierOpeningBalance(FormName.accSupplierOB);
                    break;
                case 635:
                    DisplayCustomerOpeningBalance(FormName.accCustomerOB);
                    break;
                case 636:
                    Display_AttachmentConfiguration(FormName.AttachmentsConfiguration);
                    break;
                case 664:
                    DepositCheques(FormName.ChequeDeposit);
                    break;
                case 665:
                    DepositCash(FormName.CashDepositeCode);
                    break;
                case 666:
                    BankReconcilation(FormName.BankReconcilation);
                    break;
                case 669:
                    BarcodePrint(FormName.scsBarcodePrint);
                    break;
                case 670:
                    POS_Transaction_LedgerPosting();
                    break;
                case 671:
                    CreditNoteOld(FormName.bssCreditNote_TW);
                    break;
                case 1437:
                    DisplayAccountDebitNoteNew(FormName.accDebitNote_New);
                    break;
                case 638:
                    DebitNoteNew(FormName.bssDebitNoteNew);
                    break;
                case 680:
                    CreditNoteOld(FormName.bssCreditNote_TW);
                    break;

                case 1200:
                    DisplayTaxReport();
                    break;
                case 1208:
                    AccountReceivableReports_NewUI();
                    break;
            }
            return sConfigFormID;
        }
        #endregion

        #region Display Form
        #region Old Methods

        #region Masters
        //private void DisplayMachineMaster()
        //{
        //    frm_masMachineMaster frm = new frm_masMachineMaster();
        //    frm.MdiParent = this;
        //    if (frm.bNoAccess)
        //        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    else
        //        frm.Show();
        //}

        private void DisplayUserMaster()
        {
            frm_masUserMaster frm = new frm_masUserMaster();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayEmployeeMaster()
        {
            frm_masEmployeeMaster frm = new frm_masEmployeeMaster();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayCompanyMaster()
        {
            frm_masCompanyMaster frm = new frm_masCompanyMaster();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #region Loan In Out
        private void DisplayLoanIn()
        {
            frm_scsLoan frm = new frm_scsLoan();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayLoanOut()
        {
            frm_scsLoan frm = new frm_scsLoan();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #region MyRegion
        private void DisplayReportMaster()
        {
            frm_rpt_MasterReport frm = new frm_rpt_MasterReport();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }

        private void DisplayMasterOther()
        {
            frmMasterNew frm = new frmMasterNew();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }

        private void DisplayReportChequeStanded()
        {
            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
            {
                frm_rpt_ChequeStanded_APL frm = new frm_rpt_ChequeStanded_APL();
                frm.MdiParent = this;
                if (frm.bNoAccess)
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    frm.Show();
            }
            else
            {
                frm_rpt_ChequeStanded frm = new frm_rpt_ChequeStanded();
                frm.MdiParent = this;
                if (frm.bNoAccess)
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    frm.Show();
            }
        }
        private void DisplayPreCosting()
        {
            frm_sasPreCosting frm = new frm_sasPreCosting();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion
        #region MyRegion

        private void DisplayDatabaseBackup()
        {
            frmDatabaseBackup frm = new frmDatabaseBackup();
            frm.MdiParent = this;

            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), frm.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();

        }
        private void DisplayJobViewer()
        {
            frm_sasJobViewer frm = new frm_sasJobViewer();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void PettyCashAccount()
        {
            frm_bpsPettyCashAccount frm = new frm_bpsPettyCashAccount();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void securityPettyCash()
        {
            frm_bpsPettyCashPermission frm = new frm_bpsPettyCashPermission(true);
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void UpdatePettyCashAccounts()
        {
            frm_bpsUpdatePettyCashAccounts frm = new frm_bpsUpdatePettyCashAccounts();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void SectionGRN()
        {
            frm_scsSectionGoodReceiveNote frm = new frm_scsSectionGoodReceiveNote();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void SectionGIN()
        {
            frm_scsSectionGoodIssueNote frm = new frm_scsSectionGoodIssueNote();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }

        private void ViewerCombinationMaterial()
        {
            frm_scsItemViewer_CombinationMaterial frm = new frm_scsItemViewer_CombinationMaterial();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void ViewerRawMaterial()
        {
            frm_scsItemViewer_RawMaterial frm = new frm_scsItemViewer_RawMaterial();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion
        #region MyRegion
        private void ViewerFinishedGood()
        {
            frm_scsItemViewer_FinishedGood frm = new frm_scsItemViewer_FinishedGood();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void ViewerLaminatedMaterial()
        {
            frm_scsItemViewer_LaminatedMaterial frm = new frm_scsItemViewer_LaminatedMaterial();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        //private void ItemCreationSemiFinished()
        //{
        //    frm_masItemCreation_SemiFinishedGood frm = new frm_masItemCreation_SemiFinishedGood();
        //    frm.MdiParent = this;
        //    if (frm.bNoAccess)
        //        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    else
        //        frm.Show();
        //}
        private void ViewerSection()
        {
            frm_pmsSectionViwer frm = new frm_pmsSectionViwer();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void ViewerMachine()
        {
            frm_pmsMachineLineViwer frm = new frm_pmsMachineLineViwer();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        // private void ItemMasterHome()
        //{
        //    frm_masItemMasterHome frm = new frm_masItemMasterHome();
        //    frm.MdiParent = this;
        //    if (frm.bNoAccess)
        //        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    else
        //        frm.Show();
        //}
        private void PettyCashAccountr()
        {
            frm_rpt_PettyCashAccountr frm = new frm_rpt_PettyCashAccountr();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }

        //private void ReportFlowStock()
        //{
        //    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
        //    {
        //        frm_rpt_FlowStock_APL frm = new frm_rpt_FlowStock_APL();
        //        frm.MdiParent = this;
        //        if (frm.bNoAccess)
        //            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        else
        //            frm.Show();
        //    }

        //    else
        //    {
        //        //frm_rpt_FlowStock frm = new frm_rpt_FlowStock();
        //        //frm.MdiParent = this;
        //        //if (frm.bNoAccess)
        //        //    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        //else
        //        //    frm.Show();
        //    }
        //}
        private void OffcutEntry()
        {
            frm_pmsOffcutEntry frm = new frm_pmsOffcutEntry();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }

        #endregion
        #region MyRegion
        private void QuotaionRequest()
        {
            frm_scsQuotaionRequest frm = new frm_scsQuotaionRequest();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void CashPayment()
        {
            frm_scsQuotaionRequest frm = new frm_scsQuotaionRequest();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void ChequePayment()
        {
            frm_scsQuotaionRequest frm = new frm_scsQuotaionRequest();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void ChequeReturn()
        {
            frm_scsQuotaionRequest frm = new frm_scsQuotaionRequest();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void GRNSettlement()
        {
            frm_scsQuotaionRequest frm = new frm_scsQuotaionRequest();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }

        private void PaymentAdvice()
        {
            frm_rpt_PaymentAdvicer frm = new frm_rpt_PaymentAdvicer();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void StockAdd()
        {
            frm_scsStockAdd frm = new frm_scsStockAdd();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion
        #region MyRegion
        private void SalesPendingOrder()
        {
            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
            {
                frm_rpt_SalesPendingOrder_APL frm = new frm_rpt_SalesPendingOrder_APL();
                frm.MdiParent = this;
                if (frm.bNoAccess)
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    frm.Show();
            }
            else
            {
                frm_rpt_SalesPendingDelivaryOrder frm = new frm_rpt_SalesPendingDelivaryOrder();
                frm.MdiParent = this;
                if (frm.bNoAccess)
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    frm.Show();
            }
        }

        private void ManageRoute()
        {
            frmManageRoute frm = new frmManageRoute();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }

        private void ProductionJobClose()
        {
            frm_pmsProductionJobClose frm = new frm_pmsProductionJobClose();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }

        #endregion
        #region MyRegion
        private void CustomerOrderEdit()
        {
            frm_sasCustomerOrder_Edit frm = new frm_sasCustomerOrder_Edit();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void PendingApproval()
        {
            frmDocumentApproval frm = new frmDocumentApproval();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }

        private void UserPermission_PendingApproval()
        {
            frmApprovalPermission frm = new frmApprovalPermission();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), frm.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();

        }
        private void UserPermission_PendingChecking()
        {
            frmCheckingPermission frm = new frmCheckingPermission();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), frm.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();

        }
        #endregion
        #region MyRegion
        private void UserPermission_PendingAudit()
        {
            frmAuditPermission frm = new frmAuditPermission();
            frm.MdiParent = this;
            frm.Show();
        }
        private void SectionCloser()
        {
            frm_pmsSectionCloser frm = new frm_pmsSectionCloser();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void masPettyCash()
        {
            frm_masPettyExpenditureType frm = new frm_masPettyExpenditureType();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }

        private void DeliveryOrderPlan()
        {
            frm_sasDeliveryPlan frm = new frm_sasDeliveryPlan();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void MasterPettyCachReport()
        {
            frm_rpt_MasterPettyCashAccount frm = new frm_rpt_MasterPettyCashAccount();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void PrinterMaster()
        {
            frm_masPrinterMaster frm = new frm_masPrinterMaster();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void ReportSetting()
        {
            frmReportSetting frm = new frmReportSetting();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion
        #region MyRegion       
        private void MasterPettyCachBasicReport()
        {
            frm_rpt_PettyCashAccountBasic frm = new frm_rpt_PettyCashAccountBasic();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void JobMarckupPrecentage()
        {
            mtrJobMarkupPrecentage frm = new mtrJobMarkupPrecentage();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DeliveryOrderManualSettle()
        {
            frm_sasDeliveryOrderManuslSettle frm = new frm_sasDeliveryOrderManuslSettle();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void EmailConfig()
        {
            frm_Alert_EmailConfig frm = new frm_Alert_EmailConfig();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }

        private void DisplayAccountNoteMaster()
        {
            frm_mtrAccountGLNote frm = new frm_mtrAccountGLNote();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion
        #region MyRegion
        //private void CustomReportSummary()
        //{
        //    //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithDimension.ToString())
        //    //{
        //    //    frm_rpt_CustomReport_PolyPS frm = new frm_rpt_CustomReport_PolyPS();
        //    //    frm.MdiParent = this;
        //    //    if (frm.bNoAccess)
        //    //        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //    else
        //    //        frm.Show();
        //    //}
        //    //else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ceilingAndWallPanal.ToString())
        //    //{
        //    //    frm_rpt_CustomReport_CWP frm = new frm_rpt_CustomReport_CWP();
        //    //    frm.MdiParent = this;
        //    //    if (frm.bNoAccess)
        //    //        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //    else
        //    //        frm.Show();
        //    //}
        //}
        private void DispalyDetailsStockStatement()
        {
            if ((clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString()))
            {
                //frm_rpt_StockStatement_APL frm = new frm_rpt_StockStatement_APL();
                //frm.MdiParent = this;
                //if (frm.bNoAccess)
                //    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //else
                //    frm.Show();
            }
            else
            {
                //frm_rpt_StockStatement frm = new frm_rpt_StockStatement();
                //frm.MdiParent = this;
                //if (frm.bNoAccess)
                //    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //else
                //    frm.Show();
            }
        }
        private void DispalyMatforHome()
        {
            frm_scsMetfor_Home frm = new frm_scsMetfor_Home();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayAdminRegisterReport()
        {
            frm_rpt_AdminRegiser frm = new frm_rpt_AdminRegiser();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayReimbursement()
        {
            frm_bpsPettyCashReimbursement frm = new frm_bpsPettyCashReimbursement();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayAdminStandardReport()
        {
            frm_rpt_AdminStandardReport frm = new frm_rpt_AdminStandardReport();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayAlertSetting()
        {
            frm_Alert_Configuration frm = new frm_Alert_Configuration();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayPurgeTool()
        {
            //frm_toolRecordPurge frm = new frm_toolRecordPurge();
         //   frm.MdiParent = this;
         //   if (frm.bNoAccess)
          //      MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
          //  else
          //      frm.Show();
        }

        //private void DisplayGTNSummaryReport()
        //{
        //    frm_rpt_GTNSummaryReport frm = new frm_rpt_GTNSummaryReport();
        //    frm.MdiParent = this;
        //    if (frm.bNoAccess)
        //        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    else
        //        frm.Show();
        //}
        private void DisplaySalesCommission()
        {
            frm_bpsSalesCommission frm = new frm_bpsSalesCommission();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayEmployeeCommissionRates()
        {
            frm_mtrEmployeeSlabSettings frm = new frm_mtrEmployeeSlabSettings();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }

        private void ChequeSetting()
        {
            frm_bpsChequeSetting frm = new frm_bpsChequeSetting();
            frm.MdiParent = this;
            frm.Show();
        }
        #endregion

        #endregion

        #region Metro Forms Methods
        #region Masters
        private void DisplayItemMasterFinance()
        {
            frm_masItemMasterFinance frm = new frm_masItemMasterFinance();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void CompanyEmployeeMaster()
        {
            frm_masEmployeeMaster frm = new frm_masEmployeeMaster();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayAccountMaster()
        {
            frm_masAccountsMaster frm = new frm_masAccountsMaster();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayFinanceMaster()
        {
            frm_masFinanceMaster frm = new frm_masFinanceMaster();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayItemMasterCustomerWiseSalesCode()
        {
            frm_masItemMasterCustomerWiseSalesCode frm = new frm_masItemMasterCustomerWiseSalesCode();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #region Accounts
        private void FinancialYear()
        {
            frm_masAccFinancialYear_New frm = new frm_masAccFinancialYear_New();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();

        }
        private void DoubleEntrySlotAccount()
        {
            frm_AccPostingConfigaration frm = new frm_AccPostingConfigaration();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayNotPosted_Transactions()
        {
            frm_accNotPostedTransactions frm = new frm_accNotPostedTransactions();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayOpeningBalance()
        {
            frm_AccountsOpeningBalance frm = new frm_AccountsOpeningBalance();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayBudgetPlanning()
        {
            frm_accBudget frm = new frm_accBudget();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayAPNSettlementViewer()
        {
            frm_accAPNSettlementViewer frm = new frm_accAPNSettlementViewer();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplaySupplierJournalViewer()
        {
            frm_accSupplierJournalViewer2 frm = new frm_accSupplierJournalViewer2();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void POS_Transaction_LedgerPosting()
        {
            frm_accPointOfSale_Posting frm = new frm_accPointOfSale_Posting();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void ChartOfAccount()
        {
            frm_masAccChartOfAccount frm = new frm_masAccChartOfAccount();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormIDGL + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void ChequeToNewMode_PV()
        {
            frm_accChequeToNewMode_PV frm = new frm_accChequeToNewMode_PV();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }

        #endregion

        #region Bills
        private void BillsTools()
        {
            frm_bpsTools frm = new frm_bpsTools();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayChequeManagement()
        {
            frm_bpsChequeManagement frm = new frm_bpsChequeManagement();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), frm.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayChequetracer()
        {
            frm_bpsChequeTracer frm = new frm_bpsChequeTracer();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #region Sales
        private void DisplayCOManuallySettleTool()
        {
            frm_sasCustomerOrderManuallySettleTool frm = new frm_sasCustomerOrderManuallySettleTool();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void SalesTools()
        {
            frm_sasTools frm = new frm_sasTools();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #region Stock
        private void StockControl()
        {
            frm_scsStockControl frm = new frm_scsStockControl();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #region Admin
        private void DisplayUserPermission()
        {
            frmUserPermission frm = new frmUserPermission();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), frm.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void ReportPermission()
        {
            frmReportPermission frm = new frmReportPermission();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), frm.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void UserControl()
        {
            frmUserRemove frm = new frmUserRemove();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), frm.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void AutoGenareteNumberSetting()
        {
            frmAutoFormNumber frm = new frmAutoFormNumber();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), frm.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayStoreWisePermission()
        {
            frmUserPermission_StorWise frm = new frmUserPermission_StorWise();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), frm.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #region Reports
        #region Masters
        private void ReportItemSummery()
        {
            frm_rpt_ItemMasterReport frm = new frm_rpt_ItemMasterReport();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #region Accounts Reports
        private void DisplayAccountRegisterReport()
        {
            frm_rpt_AccountRegisterReport frm = new frm_rpt_AccountRegisterReport();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void AccountReceivableReports()
        {
            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
            {
                //frm_rpt_AccountReceivableReports_APL frm = new frm_rpt_AccountReceivableReports_APL();
                //frm.MdiParent = this;
                //if (frm.bNoAccess)
                //    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //else
                //    frm.Show();
            }

            else
            {
                frm_rpt_AccountReceivableReports frm = new frm_rpt_AccountReceivableReports();
                frm.MdiParent = this;
                if (frm.bNoAccess)
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    frm.Show();
            }
        }
        private void AccountPayableReports()
        {
            frm_rpt_AccountPayableReports frm = new frm_rpt_AccountPayableReports();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void AccountReceivableReports_NewUI()
        {
            frm_rpt_AccountReceivableReports_New frm = new frm_rpt_AccountReceivableReports_New();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void ChartOfAccountReport()
        {
            frm_rpt_ChartOfAccount frm = new frm_rpt_ChartOfAccount();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void AccountRegisterReport()
        {
            frm_rpt_AccountStandardReport frm = new frm_rpt_AccountStandardReport();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #region Bills Reports
        private void DisplayCustomizedReports()
        {
            frm_rpt_BillsCustomizedReports frm = new frm_rpt_BillsCustomizedReports();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayBillsRegister()
        {
            frm_rpt_BillsRegisterReports frm = new frm_rpt_BillsRegisterReports();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), frm.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayReportChequeRegister()
        {
            frm_rpt_BankManagementReports frm = new frm_rpt_BankManagementReports();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayTaxReport()
        {
            Reports.BSS.frm_rpt_TaxReports frm = new Reports.BSS.frm_rpt_TaxReports();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #region Stock Reports
        private void StockStandedReport()
        {
            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
            {
                frm_rpt_StockStandedReport_APL frm = new frm_rpt_StockStandedReport_APL();
                frm.MdiParent = this;
                if (frm.bNoAccess)
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    frm.Show();
            }
            else
            {
                frm_rpt_StockStandedReport frm = new frm_rpt_StockStandedReport();
                frm.MdiParent = this;
                if (frm.bNoAccess)
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    frm.Show();
            }
        }
        private void StockRegisterReport()
        {
            frm_rpt_StockRegister frm = new frm_rpt_StockRegister();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayStockCustom()
        {
            frm_rpt_StockCustom_Reports frm = new frm_rpt_StockCustom_Reports();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), frm.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #region Sales Reports
        private void RouteMaster()
        {
            frm_rpt_SalesStrandedReprots frm = new frm_rpt_SalesStrandedReprots();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplaySalesCustom()
        {
            frm_rpt_SalesCustom_Reports frm = new frm_rpt_SalesCustom_Reports();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), frm.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayReportSalesStanded()
        {
            frm_rpt_SalesStrandedReprots frm = new frm_rpt_SalesStrandedReprots();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void SalesRegistry()
        {
            frm_rpt_SalesRegister frm = new frm_rpt_SalesRegister();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayCustomerMasterReport()
        {
            frm_rpt_CustomerMasterReport frm = new frm_rpt_CustomerMasterReport();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion
        #endregion

        #endregion

        #region SEACC Form Methods

        #region Masters
        private void DisplayItemMaster(FormName _enmForm)
        {
            frm_masItemMaster frm = new frm_masItemMaster(_enmForm);
            DisplayForm(frm, clsFormatter.colorMasters);
        }
        private void DisplayCustomerMaster(FormName _enmForm)
        {
            frm_masCustomerMaster frm = new frm_masCustomerMaster(_enmForm);
            DisplayForm(frm, clsFormatter.colorMasters);
        }
        private void DisplaySupplierMaster(FormName _enmForm)
        {
            frmSupplierMaster frm = new frmSupplierMaster(_enmForm);
            DisplayForm(frm, clsFormatter.colorMasters);
        }
        private void Display_AttachmentConfiguration(FormName _enmForm)
        {
            frmAttachmentConfiguration frm = new frmAttachmentConfiguration(_enmForm);
            DisplayForm(frm, Color.Empty);
        }

        private void DisplayCompanyInfor(FormName _enmForm)
        {
            frmCompanyInfor frm = new frmCompanyInfor(_enmForm);
            DisplayForm(frm, Color.Empty);
        }
        #endregion

        #region Bills
        private void CustomerRefundNote(FormName _enmForm)
        {
            frm_bpsDebitNote frm = new frm_bpsDebitNote(_enmForm);
            DisplayForm(frm, clsFormatter.colorBills);
        }
        private void DebitNote(FormName _enmForm)
        {
            frm_bpsDebitNote_New frm = new frm_bpsDebitNote_New(_enmForm);
            DisplayForm(frm, clsFormatter.colorBills);
        }
        private void DebitNoteNew(FormName _enmForm)
        {
            frm_bpsDebitNote frm = new frm_bpsDebitNote(_enmForm);
            DisplayForm(frm, clsFormatter.colorBills);
        }
        private void DepositCheques(FormName _enmForm)
        {
            frm_bpsChequeDeposit frm = new frm_bpsChequeDeposit(_enmForm);
            DisplayForm(frm, clsFormatter.colorBills);
        }

        private void DepositCash(FormName _enmForm)
        {
            frm_bpsCashDeposit frm = new frm_bpsCashDeposit(_enmForm);
            DisplayForm(frm, clsFormatter.colorBills);
        }

        private void BankReconcilation(FormName _enmForm)
        {
            frm_bpsBankReconcilation frm = new frm_bpsBankReconcilation(_enmForm);
            DisplayForm(frm, clsFormatter.colorBills);
        }
        private void CreditNote(FormName _enmForm)
        {
            frm_bpsCreditNote2 frm = new frm_bpsCreditNote2(_enmForm);
            DisplayForm(frm, clsFormatter.colorBills);
        }
        private void CreditNoteOld(FormName _enmForm)
        {
            frm_bpsCreditNote frm = new frm_bpsCreditNote(_enmForm);
            DisplayForm(frm, clsFormatter.colorBills);
        }
        private void CreditorSettlement(FormName _enmForm)
        {
            frm_accCreditorSettlement frm = new frm_accCreditorSettlement(_enmForm);
            DisplayForm(frm, clsFormatter.colorAccounts);
        }
        private void InvoiceSettlement(FormName _enmForm)
        {
            frm_bpsInvoiceSettlement frm = new frm_bpsInvoiceSettlement(_enmForm);
            DisplayForm(frm, clsFormatter.colorAccounts);
        }
        private void DisplayReceipt_Account()
        {
            UC_bpsReceiptSales frm = new UC_bpsReceiptSales(FormName.InterimReceipt);
            DisplayForm(frm, clsFormatter.colorSales);
        }
        #endregion

        #region Stock
        private void DisplaysasGRNTradingStock()
        {
            frm_scsStoreGoodReceiveNote frm = new frm_scsStoreGoodReceiveNote(FormName.sasGRNTradingStock);
            DisplayForm(frm, clsFormatter.colorStock);
        }
        private void DisplaysasGINTradingStock()
        {
            frm_scsStoreGoodIssueNote frm = new frm_scsStoreGoodIssueNote(FormName.sasGINTradingStock);
            DisplayForm(frm, clsFormatter.colorStock);
        }
        private void DisplaysasSRNTradingStock()
        {
            frm_scsStoreRequisitionNote frm = new frm_scsStoreRequisitionNote(FormName.sasSRNTradingStock);
            DisplayForm(frm, clsFormatter.colorStock);
        }
        private void SupplierPO(FormName _enmForm)
        {
            frm_scsPurchaseOrder frm = new frm_scsPurchaseOrder(_enmForm);
            DisplayForm(frm, clsFormatter.colorStock);
        }
        private void scsGoodTransferNote()
        {
            frm_scsGoodTransferNote_new frm = new frm_scsGoodTransferNote_new(FormName.scsGoodTransferNote);
            DisplayForm(frm, clsFormatter.colorStock);
        }
        private void SupplierGRN()
        {
            frm_scsExternalGoodReceiveNote frm = new frm_scsExternalGoodReceiveNote(FormName.scsGRNSupplier);
            DisplayForm(frm, clsFormatter.colorStock);
        }
        private void SupplierPRN()
        {
            frm_scsPurchaseReturnNote frm = new frm_scsPurchaseReturnNote(FormName.scsPRNSupplier);
            DisplayForm(frm, clsFormatter.colorStock);
        }
        private void ExternalGIN()
        {
            frm_scsExternalGoodIssueNote frm = new frm_scsExternalGoodIssueNote(FormName.scsGINExternal);
            DisplayForm(frm, clsFormatter.colorStock);
        }
        private void DamageGoodsNote()
        {
            frm_scsDamageGoodsNote frm = new frm_scsDamageGoodsNote(FormName.scsDamagedGoodsNote);
            DisplayForm(frm, clsFormatter.colorStock);
        }
        private void DiscardedGoodsNote()
        {
            frm_scsDiscardedGoodNote frm = new frm_scsDiscardedGoodNote(FormName.scsDiscardedGoodsNote);
            DisplayForm(frm, clsFormatter.colorStock);
        }
        private void StockAdjusment()
        {
            frm_scsStockAdjustment frm = new frm_scsStockAdjustment(FormName.scsStockAdjusment);
            DisplayForm(frm, clsFormatter.colorStock);
        }
        private void TradingGoodReceiveNote()
        {
            frm_scsStoreProduction frm = new frm_scsStoreProduction(FormName.scsStoreProduction);
            DisplayForm(frm, clsFormatter.colorStock);
        }
        private void StoreProduction()
        {
            frm_scsStoreProduction frm = new frm_scsStoreProduction(FormName.scsStoreProduction);
            DisplayForm(frm, clsFormatter.colorStock);
        }
        private void ItemSpred()
        {
            frm_sasItemSpradeNote frm = new frm_sasItemSpradeNote(FormName.sasItemSparadeNote);
            DisplayForm(frm, clsFormatter.colorStock);
        }
        private void PurchaseRequisition()
        {
            frm_scsPurchaseRequisitionNote frm = new frm_scsPurchaseRequisitionNote(FormName.PurchaseRequisition);
            DisplayForm(frm, clsFormatter.colorStock);
        }
        private void SectionSR(FormName _enmForm)
        {
            frm_scsSectionRequisitionNote frm = new frm_scsSectionRequisitionNote(_enmForm);
            DisplayForm(frm, clsFormatter.colorStock);
        }
        private void BarcodePrint(FormName _enmForm)
        {
            UC_scsBarcodePrint frm = new UC_scsBarcodePrint(_enmForm);
            DisplayForm(frm, clsFormatter.colorStock);
        }
        #endregion

        #region Accounts
        private void DisplayAccountPayableNote_Allocation(FormName _enmForm)
        {
            frm_accSupplierAccountpayableNote frm = new frm_accSupplierAccountpayableNote(_enmForm);
            DisplayForm(frm, clsFormatter.colorAccounts);
        }

        private void DisplayAccountPayableNote(FormName _enmForm)
        {
            frm_accAccountpayableNote_NEW frm = new frm_accAccountpayableNote_NEW(_enmForm);
            DisplayForm(frm, clsFormatter.colorAccounts);
        }
        private void DisplayAccountDebitNote(FormName _enmForm)
        {
            frm_AccDebitNote frm = new frm_AccDebitNote(_enmForm);
            DisplayForm(frm, clsFormatter.colorAccounts);
        }
        private void DisplayAccountDebitNoteNew(FormName _enmForm)
        {
            frm_AccDebitNote_New frm = new frm_AccDebitNote_New(_enmForm);
            DisplayForm(frm, clsFormatter.colorAccounts);
        }
        private void ReceiptVoucher(FormName _enmForm)
        {
            frm_accAccountReceipt frm = new frm_accAccountReceipt(_enmForm);
            DisplayForm(frm, clsFormatter.colorAccounts);
        }
        private void DisplayPaymentVoucher(FormName _enmForm)
        {
            frm_accPaymentVoucher frm = new frm_accPaymentVoucher(_enmForm);
            DisplayForm(frm, clsFormatter.colorAccounts);
        }
        private void DisplayCustomerOpeningBalance(FormName _enmForm)
        {
            UC_AccCustomerOpeningBalance frm = new UC_AccCustomerOpeningBalance(_enmForm);
            DisplayForm(frm, clsFormatter.colorAccounts);
        }
        private void DisplaySupplierOpeningBalance(FormName _enmForm)
        {
            UC_AccSupplierOpeningBalance frm = new UC_AccSupplierOpeningBalance(_enmForm);
            DisplayForm(frm, clsFormatter.colorAccounts);
        }
        private void JournalEntry2(FormName _enmForm)
        {
            UC_AccJournalEntry frm = new UC_AccJournalEntry(_enmForm);
            DisplayForm(frm, clsFormatter.colorAccounts);
        }
        private void FixedAssetRegistration(FormName _enmForm)
        {
            UC_AccFixedAssetRegistration frm = new UC_AccFixedAssetRegistration(_enmForm);
            DisplayForm(frm, clsFormatter.colorAccounts);
        }
        private void AssetsTransferNote(FormName _enmForm)
        {
            UC_AccAssetTransferNote frm = new UC_AccAssetTransferNote(_enmForm);
            DisplayForm(frm, clsFormatter.colorAccounts);
        }
        #endregion

        #region Sales
        private void SalesReturnNote(FormName _enmForm)
        {
            frm_sasSalseReturnNote frm = new frm_sasSalseReturnNote(_enmForm);
            DisplayForm(frm, clsFormatter.colorSales);
        }
        private void DisplayCustomerOrder(FormName _enmForm)
        {
            frm_sasCustomerOrder frm = new frm_sasCustomerOrder(_enmForm);
            DisplayForm(frm, clsFormatter.colorSales);
        }
        private void DisplayCustomerDO(FormName _enmForm)
        {
            frm_sasDeliveryOrder frm = new frm_sasDeliveryOrder(_enmForm);
            DisplayForm(frm, clsFormatter.colorSales);
        }
        private void DisplayCustomerInvoice(FormName _enmForm)
        {
            frm_sasInvoice frm = new frm_sasInvoice(_enmForm);
            DisplayForm(frm, clsFormatter.colorSales);
        }
        private void DisplayCustomerQuotation(FormName _enmForm)
        {
            frm_sasQuotation frm = new frm_sasQuotation(_enmForm);
            DisplayForm(frm, clsFormatter.colorSales);
        }
        private void DisplayProformaInvoice(FormName _enmForm)
        {
            frm_sasProformaInvoice frm = new frm_sasProformaInvoice(_enmForm);
            DisplayForm(frm, clsFormatter.colorSales);
        }
        private void Inquiry(FormName _enmForm)
        {
            frm_sasInquiry frm = new frm_sasInquiry(_enmForm);
            DisplayForm(frm, clsFormatter.colorSales);
        }
        private void SalesInvoice2(FormName _enmForm)
        {
            frm_sasInvoice2 frm = new frm_sasInvoice2(_enmForm);
            DisplayForm(frm, clsFormatter.colorSales);
        }
        private void DisplayUC_ReceiptSales(FormName _enmForm)
        {
            UC_bpsReceiptSales frm = new UC_bpsReceiptSales(_enmForm);
            DisplayForm(frm, clsFormatter.colorSales);
        }
        #endregion

        #endregion
        #endregion

        #region Display Form Method
        public void DisplayForm(SEACC_Form frm, Color color)
        {
            if (!frm.bNoAccess)
            {
                MettroForm mf = new MettroForm() { };
                mf.Settings_Click += delegate (object sender, EventArgs e)
                {
                    frm.SettingsClick();
                };
                mf.DefaultHight = frm.Height + 35;
                mf.DefaultWidth = frm.Width + 10;
                mf.Width = mf.DefaultWidth;
                mf.Height = mf.DefaultHight;
                mf.Controls.Add(frm);
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                mf.Text = frm.Name;

                if (color != Color.Empty)
                {
                    mf.ThemeColor = color;
                    frm.UI_Color = color;
                }

                frm.BringToFront();
                mf.MdiParent = this;
                mf.Show();
            }
            else
                frm.Dispose();
        }
        #endregion

        #region Get Call Viewer ID
        private string getCallFormViewer(int iFormID)
        {
            string sConfigFormID = "";
            switch (iFormID)
            {
                case 9:
                    DisplayViewerCustomerOrder();
                    break;
                case 10:
                    DisplayViewerInvoice();
                    break;
                case 11:
                    DisplayViewerDeliveryOrder();
                    break;
                case 21:
                    DisplayViewerReceipt();
                    break;
                case 22:
                    DisplayViewerInquiry();
                    break;
                case 155:
                    DisplayViewerInquiry();
                    break;
            }
            return sConfigFormID;
        }
        #endregion

        #region Display Viewer

        #region SAS Viewer - Inquiry
        private void DisplayViewerInquiry()
        {
            frm_sasInquiryViewer frm = new frm_sasInquiryViewer();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #region SAS Viewer - Customer Order
        private void DisplayViewerCustomerOrder()
        {
            frm_sasCustomerOrderViewer frm = new frm_sasCustomerOrderViewer();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #region SAS Viewer - Delivery Order
        private void DisplayViewerDeliveryOrder()
        {
            frm_sasDeliveryOrderViewer frm = new frm_sasDeliveryOrderViewer();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #region SAS Viewer - Invoice
        private void DisplayViewerInvoice()
        {
            frm_sasInvoiceViewer frm = new frm_sasInvoiceViewer();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #region BSS Viewer - Receipt
        private void DisplayViewerReceipt()
        {
            frm_bpsReceiptTracer frm = new frm_bpsReceiptTracer();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion
        #endregion

        #region Events FormClosing
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //tbl_utlUserPool uPool = tbl_utlUserPool.Select(clsSecurity.UserIDLoged, clsSecurity.TerminalID);
            //if (uPool != null)
            //    uPool.Delete();
        }
        #endregion

        #region Btn MIS
        private void btnMIS_Click(object sender, EventArgs e)
        {
            frm_dashBord frm = new frm_dashBord();
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.ShowDialog();
        }
        #endregion

        #region Btn Pending Approval
        private void tslPendingApproval_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                frmPendingApprovals frm = new frmPendingApprovals(FormName.PendingApproval);
                DisplayForm(frm, clsFormatter.colorAdmin);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Background Workers
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                clsBackProcess.AutoAssignConfigStatus();
                clsBackProcess.AutoAssignConfigValue();
                clsBackProcess.AutoAssignGLCodes();

                if (clsSecurity.CheckExpireDate())
                {
                    Application.Exit();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", -1, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Timter Tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                pnlNetwork.Visible = false;
                if (clsSecurity.UserIDLoged.Trim().ToUpper() != "DIGITEQ")
                {
                    tbl_utlUserPool oUpool = tbl_utlUserPool.Select(clsSecurity.iLoginSession_Index, clsSecurity.UserIDLoged, clsSecurity.TerminalID);
                    if (oUpool == null)
                    {
                        Application.Exit();
                    }
                }
                //Force ShoutDown
                if (clsBackProcess.IsForceShutDown())
                {
                    MessageBox.Show("Code : IsForceShutDown");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                pnlNetwork.Visible = true;
            }
        }
        #endregion

        #region Events MouseLeave
        private void Text_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
        #endregion

        #region Events MouseMove
        private void Text_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }
        #endregion

        #region Chat Event and Method
        private void btnChat_Click(object sender, EventArgs e)
        {
            ChatMethod();
        }

        public void ChatMethod()
        {
            //if (bChatShow)
            //{
            //    obj_frmChat.MdiParent = this;
            //    if (obj_frmChat.bNoAccess)
            //        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    else
            //        obj_frmChat.Show();

            //    bChatShow = false;
            //}
            //else
            //{
            //    obj_frmChat.Hide();
            //    bChatShow = true;
            //}
        }
        #endregion

        #region Menu
        #region Event Data Grid
        private void dgrForm_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int iFormID = 0;
                    try
                    {
                        iFormID = int.Parse(clsValidate.ValidateGridValue(dgrForm, "form_ID", e.RowIndex, ""));
                    }
                    catch (Exception) { }
                    if (iFormID != 0)
                    {
                        MenuResize();
                        getCallForm(iFormID);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgrViwer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int iFormID = 0;
                    try
                    {
                        iFormID = int.Parse(clsValidate.ValidateGridValue(dgrViwer, "formID", e.RowIndex, ""));
                    }
                    catch (Exception ex) { }
                    if (iFormID != 0)
                        getCallForm(iFormID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Menu Resize
        private void MenuResize()
        {
            if (pnlDock.Width > 65)
                pnlDock.Width = 65;
            else
                pnlDock.Width = 260;
        }
        #endregion

        #region Event MouseHover
        private void Category_MouseHover(object sender, EventArgs e)
        {
            string s_CateogryID = ((Control)sender).Name.ToString().Trim();
            tbl_securityFormCategory detail = tbl_securityFormCategory.Select(s_CateogryID);
            if (detail != null)
                this.tslStatus.Text = detail.CategoryName;
        }
        #endregion
        #endregion

        #region Contral Box
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Size_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            System.Windows.Forms.Screen Scr = System.Windows.Forms.Screen.FromPoint(System.Windows.Forms.Cursor.Position);

            if (!bIsmaximized)
            {
                this.FormBorderStyle = FormBorderStyle.None;



                this.Width = Scr.WorkingArea.Width;
                this.Height = Scr.WorkingArea.Height;
                this.Left = Scr.Bounds.Location.X;
                this.Top = Scr.Bounds.Location.Y;

                bIsmaximized = true;
                btn_Size.Text = "";
            }
            else
            {
                this.Width = Scr.WorkingArea.Width / 3 * 2;
                this.Height = Scr.WorkingArea.Height / 3 * 2;
                this.Left = Scr.Bounds.Location.X + Scr.Bounds.Width / 4; ;
                this.Top = Scr.Bounds.Location.Y + Scr.WorkingArea.Height / 4;

                bIsmaximized = false;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                btn_Size.Text = "";
            }
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frmMain_ResizeEnd(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                if (bIsmaximized)
                    btn_Size_Click(null, null);
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                bIsmaximized = false;
                btn_Size_Click(null, null);
                MenuResize();
            }
        }
        #endregion

        #region Fill Profile Detail
        private void FillProfileDetail()
        {
            tbl_securityUserMaster detail = tbl_securityUserMaster.Select(clsSecurity.UserIDLoged);
            if (detail != null)
            {
                clsSecurity.UserNameLoged = detail.UserName;
                clsSecurity.UserGroupIDLoged = detail.Group_ID;
                clsSecurity.UserGroupLoged = clsGenaralName.getName_Group(detail.Group_ID);

                ucUserIndicator1.DisplayName = clsSecurity.UserNameLoged;
                ucUserIndicator1.UserDesc = clsSecurity.UserGroupLoged;

                if (detail.Image != null)
                {
                    if (detail.Image.Length > 0)
                    {
                        MemoryStream ms = new MemoryStream(detail.Image);
                        ucUserIndicator1.Picture = Image.FromStream(ms);
                    }
                    else
                        ucUserIndicator1.Picture = Digiteq.Properties.Resources.no_image;
                }
                else
                    ucUserIndicator1.Picture = Digiteq.Properties.Resources.no_image;
            }
        }
        #endregion

        #region User Indicator Selections
        private void ucUserIndicator1_Selection(string sResult)
        {
            switch (sResult)
            {
                #region Close
                case "Close":
                    this.Close();
                    break;
                #endregion
                #region personalize
                case "personalize":
                    {
                        frmDigiteqLogin login = new frmDigiteqLogin();
                        login.ShowDialog();
                        if (frmDigiteqLogin.bLoged)
                        {
                            frmDigiteqPannel item = new frmDigiteqPannel();
                            item.MdiParent = this;
                            item.Show();
                        }
                    }
                    break;
                #endregion
                #region myportal
                case "myportal":
                    {
                        this.tslStatus.Text = "My Portal";
                        frmMyPortal frm = new frmMyPortal();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;
                #endregion
                #region myportal
                case "var":
                    {
                        this.tslStatus.Text = "My Portal";
                        frm_VersionInfo frm = new frm_VersionInfo(clsConfig.tblVersion);
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;
                    #endregion
            }
        }
        #endregion
    }
}

//private void button1_Click(object sender, EventArgs e)
//{
//    StringBuilder sb = new StringBuilder();
//    StringBuilder sbInvList = new StringBuilder();
//    foreach (tbl_sasInvoice oInv in tbl_sasInvoice.SelectAll())
//    {
//        if (sbInvList.Length > 0)
//            sbInvList.Append(",");

//        sbInvList.AppendLine("'" + oInv.Invoice_ID + "'");

//        List<tbl_accGLPosting_Detail> oPost = tbl_accGLPosting_Detail.SelectAllByTransaction_ID(oInv.Invoice_ID);
//        if (oInv.IsOpeningBalance)
//        {
//            if (oPost.Count != 0)
//                sb.AppendLine(oInv.Invoice_ID + " posted OPBL");
//        }
//        else if (oInv.IsDeleted)
//        {
//            if (oPost.Count != 0)
//                sb.AppendLine(oInv.Invoice_ID + " posted Deleted Note");
//        }
//        else if (oInv.IsReturnedCheque)
//        {
//            if (oPost.Count != 0)
//                sb.AppendLine(oInv.Invoice_ID + " posted Returned chq");
//        }
//        else if (oInv.Invoice_ID == "default")
//        {
//            if (oPost.Count != 0)
//                sb.AppendLine(oInv.Invoice_ID + " posted Default record");
//        }
//        else
//        {
//            if (oPost.Count == 0)
//                sb.AppendLine(oInv.Invoice_ID + " Not Posted");
//            else
//            {
//                decimal dCr = 0, dDr = 0;
//                foreach (tbl_accGLPosting_Detail oPosti in oPost)
//                {
//                    if (oPosti.IsCredit)
//                        dCr += oPosti.Amount;
//                    else
//                        dDr += oPosti.Amount;
//                }

//                if (dDr != oInv.GrandTotal)
//                    sb.AppendLine(oInv.Invoice_ID + " Grand total mismatch");

//                if ((oInv.NbtTotal + oInv.VatTotal + oInv.SubTotal - oInv.DiscountTotal - oInv.DiscountTotal1 - oInv.DiscountTotal2 - oInv.DiscountTotal3) != dCr)
//                    sb.AppendLine(oInv.Invoice_ID + " CR mismatch");
//            }

//        }
//    }
//    textBox2.Text = sb.ToString();
//    string Q1 = "select* from[dbo].[tbl_accGLPosting_Detail]        where[slot_ID] in(1,2,31,35,36) and[transaction_ID] not in (" + sbInvList.ToString() + ")";
//    DataTable dt = DBHandling.ExecQuery(Q1).Tables[0];
//    dataGridView1.DataSource = dt.DefaultView;
//    MessageBox.Show("done");
//}

#region Check Product expire date
//DateTime dtmProductExpire = clsSecurity.GetSystemExpireDate();

//if (clsConfig.bProductActivated == true && clsSecurity.getServerDateTime().Date >= dtmProductExpire.Date.AddDays(-7).Date && clsSecurity.getServerDateTime().Date < dtmProductExpire.Date)
//{
//    MessageBox.Show("Please contact 'hepldesk@digiteq.biz'", "Software will be expired on " + clsFormatter.FormatDate_Short(dtmProductExpire), MessageBoxButtons.OK, MessageBoxIcon.Information);
//}
//else if (clsSecurity.getServerDateTime().Date >= dtmProductExpire.Date && clsSecurity.getServerDateTime().Date < dtmProductExpire.AddDays(7))
//{
//    MessageBox.Show("Please contact 'hepldesk@digiteq.biz' Unless the product will be stopped on " + clsFormatter.FormatDate_Short(dtmProductExpire.AddDays(7)), "Software has been expired on " + clsFormatter.FormatDate_Short(dtmProductExpire), MessageBoxButtons.OK, MessageBoxIcon.Warning);
//    RemoveUsersAfterProductExpired();
//}
//else if (clsSecurity.getServerDateTime().Date >= dtmProductExpire.AddDays(7))
//{
//    MessageBox.Show("Please contact 'hepldesk@digiteq.biz'", "Software has been expired on " + clsFormatter.FormatDate_Short(dtmProductExpire), MessageBoxButtons.OK, MessageBoxIcon.Stop);
//    RemoveUsersAfterProductExpired();

//    Application.Exit();
//    this.Dispose();
//}
//else if (clsConfig.bProductActivated == false)
//{
//    MessageBox.Show("Please contact 'hepldesk@digiteq.biz'", "Software has been expired", MessageBoxButtons.OK, MessageBoxIcon.Stop);

//    Application.Exit();
//    this.Dispose();
//}
#endregion