using DataTire;
using Digiteq_Logic;
using Digiteq_Logic_POS;
using SEACC_POS.Controls;
using SEACC_POS.DataSet;
using SEACC_POS.Reports;
using SEACC_POS.Search_Forms;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SEACC_POS.TransactionForms
{
    /// <summary>
    /// Interaction logic for UC_AdavacePayment.xaml
    /// </summary>
    public partial class UC_AdavaceReceive : UserControl
    {
        #region Class Variables
        //PoS Session Index
        private int iPoS_session_dayDetail_Index;

        BrushConverter bc = new BrushConverter();

        public DataTable dtCardPayment = new DataTable();
        public DataTable dtGiftVoucherPayment = new DataTable();
        public DataTable dtChequePayment = new DataTable();
        public DataTable dtCRN = new DataTable();
        #endregion

        #region Form Load
        public UC_AdavaceReceive(int idayDetail_Index)
        {
            #region User Control Initialization
            InitializeComponent();
            iPoS_session_dayDetail_Index = idayDetail_Index;
            SEACC_Form.enmFormName = FormName.POS_AdvancePayment;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Tables
            //Advance Payment History (Main Grid)
            dgr_Main.dt.Columns.Add("LineNo");
            dgr_Main.dt.Columns.Add("AdvanceIndex");
            dgr_Main.dt.Columns.Add("AdvanceID");
            dgr_Main.dt.Columns.Add("Date");
            dgr_Main.dt.Columns.Add("Customer");
            dgr_Main.dt.Columns.Add("TotalAmount");
            dgr_Main.dt.Columns.Add("IsSettled");
            dgr_Main.dt.Columns.Add("IsCancelled");

            //Card Payment
            dtCardPayment.Columns.Add("LineNo");
            dtCardPayment.Columns.Add("CardTypeID");
            dtCardPayment.Columns.Add("CardType");
            dtCardPayment.Columns.Add("NameOnCard");
            dtCardPayment.Columns.Add("LastFourDigits");
            dtCardPayment.Columns.Add("BankID");
            dtCardPayment.Columns.Add("Bank");
            dtCardPayment.Columns.Add("Amount", typeof(decimal));

            //Gift Voucher Payments
            dtGiftVoucherPayment.Columns.Add("LineNo");
            dtGiftVoucherPayment.Columns.Add("VoucherID");
            dtGiftVoucherPayment.Columns.Add("VoucherNo");//Serial No
            dtGiftVoucherPayment.Columns.Add("DateValidFrom");
            dtGiftVoucherPayment.Columns.Add("DateValidTo");
            dtGiftVoucherPayment.Columns.Add("VoucherAmount", typeof(decimal));

            //Cheque Payments
            dtChequePayment.Columns.Add("LineNo");
            dtChequePayment.Columns.Add("Account_No");
            dtChequePayment.Columns.Add("BankID");
            dtChequePayment.Columns.Add("Bank");
            dtChequePayment.Columns.Add("BankBranchID");
            dtChequePayment.Columns.Add("BankBranch");
            dtChequePayment.Columns.Add("ChequeNo");
            dtChequePayment.Columns.Add("ChequeDate");
            dtChequePayment.Columns.Add("ChequeAmount", typeof(decimal));

            //CRNs
            dtCRN.Columns.Add("LineNo");
            dtCRN.Columns.Add("CRN_Index");
            dtCRN.Columns.Add("CRN_ID");
            dtCRN.Columns.Add("CRN_Amount", typeof(decimal));

            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, false, false, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Print.Click += btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            #endregion

            #region Initialize Data Grids
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "##", "LineNo", 25, true, true);
            dgr_Main.Add_DatagridColoumn("Adv. Index", "AdvanceIndex", 50, false);
            dgr_Main.Add_DatagridColoumn("ID", "AdvanceID", 85);
            dgr_Main.Add_DatagridColoumn("Date", "Date", 85);
            dgr_Main.Add_DatagridColoumn("Customer", "Customer", 250);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Amount", "TotalAmount", 85, true, true);
            dgr_Main.Add_DatagridColoumn("Is Settled", "IsSettled", 120, false);
            dgr_Main.Add_DatagridColoumn("Is Cancelled", "IsCancelled", 120, false);

            //Initialize Payment Data Grids
            dgrCardPays.ItemsSource = dtCardPayment.DefaultView;
            dgrGiftVoucher.ItemsSource = dtGiftVoucherPayment.DefaultView;
            dgrCheques.ItemsSource = dtChequePayment.DefaultView;
            dgrCRN.ItemsSource = dtCRN.DefaultView;
            #endregion

            ClearFields();
            RefreshGrid();
        }


        #endregion

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(670);

        }
        #endregion

        #region Action Buttons
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }

        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {
            BillPrint glb_dtsBillPrinting = new BillPrint();

            #region Crystal Report Bill
            try
            {
                Cursor = Cursors.Wait;
                string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";

                if (clsHelpMethods_POS.GetReportPath((int)enum_ReportName.POS_Advance_NotePrint, true, ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                {
                    glb_dtsBillPrinting.dt_Company.Rows.Clear();
                    glb_dtsBillPrinting.dt_pos_transaction.Rows.Clear();
                    glb_dtsBillPrinting.dt_pos_transation_details.Rows.Clear();
                    glb_dtsBillPrinting.dt_pos_receipt.Rows.Clear();

                    string sDuplicateCopy = "";

                    if (sReportPath.Length == 3)
                        return;


                    tbl_genCompanyBranchMaster oBranch = tbl_genCompanyBranchMaster.Select(clsSecurity.BranchID);
                    tbl_posAdvanceReceived oPos_Adavnce = tbl_posAdvanceReceived.Select(int.Parse(txtAdvanceReceive_ID.Tag.ToString()));
                    Common.CompanyImages oComImages = Common.clsCommon_POS.getCompanyImages();
                    if (oPos_Adavnce != null && oBranch != null)
                    {
                        #region Fill company Details
                        glb_dtsBillPrinting.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName,
                            clsSecurity.DigiteqEmail,
                            clsSecurity.CompanyName,
                            clsSecurity.CompanyAddress1,
                            clsSecurity.CompanyAddress2,
                            oComImages.CompanyImage1,
                            oComImages.CompanyImage2,
                            oComImages.CompanyImage3,
                            sReportTitle_Main,
                            sReportTitle_Sub,
                            "Date Renage",
                            clsSecurity.UserNameLoged,
                            "Filter",
                            clsCommon.getCompanyBusinessRegisterNo(),
                            clsCommon.getCompanyVAT(),
                            oBranch.BranchName.ToUpper(),
                            oBranch.Adress.ToUpper(),
                            ("TEL: " + oBranch.Telephone.ToUpper() + ", FAX: " + oBranch.Fax.ToUpper()),
                            oBranch.Hotline,
                            oBranch.Telephone,
                            oBranch.Website,
                            oBranch.Email,
                            oBranch.Fax
                            );
                        #endregion

                        #region Update Print Count and check whether it is duplicate copy or not
                        sDuplicateCopy = (oPos_Adavnce.PrintedUser_ID != "default") ? "Reprint" : "";
                        oPos_Adavnce.PrintCount += 1;
                        oPos_Adavnce.PrintedUser_ID = clsSecurity.UserIDLoged;
                        oPos_Adavnce.DatePrinted = clsSecurity.getServerDateTime();
                        oPos_Adavnce.PrintedTerminal_ID = clsSecurity.TerminalID;
                        oPos_Adavnce.Update();
                        #endregion

                        #region Fill POS Transaction Header
                        glb_dtsBillPrinting.dt_pos_transaction.Adddt_pos_transactionRow(
                            oPos_Adavnce.AdvanceReceived_ID,
                                    oPos_Adavnce.PaymentDate,
                                    oPos_Adavnce.Remark,
                                    oPos_Adavnce.Customer_ID,
                                    "",
                                    "",
                                    "",
                                    1,
                                    0,
                                    0,
                                    0,
                                    0,
                                    0,
                                    "Advance Receipt No",
                                    0,
                                    0,
                                    0,
                                    0,
                                    0,
                                    oPos_Adavnce.AdvanceAmount,
                                    oPos_Adavnce.CreateUser_ID,
                                    oPos_Adavnce.ModifiedUser_ID,
                                    oPos_Adavnce.IsChecked,
                                    oPos_Adavnce.IsApproved,
                                    false,
                                    oPos_Adavnce.IsCanceled,
                                    0,
                                    oPos_Adavnce.SetteledAmount,
                                    oPos_Adavnce.IsSetteled,
                                    clsGenaralName.getName_Customer(oPos_Adavnce.Customer_ID),
                                    clsGenaralName.getName_CustomerRegisterAddress(oPos_Adavnce.Customer_ID),
                                    clsGenaralName.getName_CustomerTelephone(oPos_Adavnce.Customer_ID),
                                    clsGenaralName.getVATRegNo_Customer(oPos_Adavnce.Customer_ID),
                                     clsGenaralName.getName_CompanyBranchMaster(oPos_Adavnce.CompanyBranchID), //Branch
                                     oPos_Adavnce.CreateUserTerminal_ID, //Terminal
                                    clsGenaralName.getName_User(oPos_Adavnce.CreateUser_ID),  // Cashier
                                    sDuplicateCopy, 0, "", 0
                                    );
                        #endregion

                        #region Fill POS Receipt & Payments
                        var vPoSReceipts = tbl_posReceipt.SelectAllByAdvanceReceived_Index(oPos_Adavnce.AdvanceReceived_Index);
                        decimal dTotalCashTendered = 0;
                        if (vPoSReceipts.Any())
                            dTotalCashTendered = vPoSReceipts.Sum(r => r.TenderedAmount);

                        foreach (tbl_posReceipt oReceipt in vPoSReceipts)
                        {
                            //Fill Receipt Payments
                            foreach (tbl_bpsChequeRegister oPayReg in tbl_bpsChequeRegister.SelectAllByPosReceipt_ID(oReceipt.PosReceipt_ID).Where(r => !r.IsDeleted))
                            {
                                tbl_posAdvanceReceived oAdavance = tbl_posAdvanceReceived.Select(oPayReg.AdvanceReceived_Index);

                                glb_dtsBillPrinting.dt_pos_receipt_payment.Adddt_pos_receipt_paymentRow(
                                    oAdavance.AdvanceReceived_ID, oPayReg.PosReceipt_ID, oPayReg.ChequeRegister_ID,
                                    ((PaymentMethod)oPayReg.PaymentMethod_ID).ToString() + (oPayReg.Amount > 0 ? " Paid" : " Balance"),
                                    ((BankTransferTypes)oPayReg.TransferType).ToString(), oPayReg.TransferRefNo,
                                    ((PaymentCardTypes)oPayReg.CardType).ToString(),
                                    oPayReg.Amount);
                            }

                            //Fill POS Receipt 
                            glb_dtsBillPrinting.dt_pos_receipt.Adddt_pos_receiptRow(oPos_Adavnce.AdvanceReceived_ID, oReceipt.PosReceipt_ID, oReceipt.PosReceiptDate, dTotalCashTendered, oReceipt.ChangeAmount, oReceipt.TotalAmount);
                        }
                        #endregion

                        #region Print Bill
                        frm_ReportViewer rpt = new frm_ReportViewer();
                        if (clsConfig_POS.bDirect_Print_R2_Pos_Invoice)
                        {
                            //Crystak Report Direct Print
                            rpt.DirectPrint(sReportPath, glb_dtsBillPrinting, new DataTable(), null);
                        }
                        else
                        {
                            //Crystal Report Viewer
                            rpt.print(sReportPath, glb_dtsBillPrinting, new DataTable(), null);
                        }
                        #endregion
                    }
                    else
                    {
                        SEACCMessageBox.Show("Transaction Not Selected....", "Please select valid transaction for printing", MessageBoxButton.OK, "Red");
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            finally
            {
                glb_dtsBillPrinting.dt_Company.Rows.Clear();
                glb_dtsBillPrinting.dt_pos_transaction.Rows.Clear();
                glb_dtsBillPrinting.dt_pos_transation_details.Rows.Clear();

                Cursor = Cursors.Arrow;
            }

            #endregion

        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtAdvanceReceive_ID.Tag != null && txtAdvanceReceive_ID.Text != "<<Auto Generated>>")
                {
                    //cancel one record
                    Cursor = Cursors.Wait;
                    tbl_posAdvanceReceived oAdv = tbl_posAdvanceReceived.Select(int.Parse(txtAdvanceReceive_ID.Tag.ToString().Trim()));
                    if (oAdv != null)
                    {
                        tbl_posDayStartAndEnd oPos_Day = tbl_posDayStartAndEnd.SelectAllByCompanyBranch_ID(oAdv.CompanyBranchID).FirstOrDefault(r => r.DateCreated.Date == oAdv.PaymentDate.Date);
                        if (oPos_Day != null)
                        {
                            if (!oAdv.IsCanceled && !oAdv.IsSetteled && !oPos_Day.IsApproved)
                            {
                                bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                                if (bMessegeBoxResult)
                                {
                                    frm_TwoStepVerification_UserChange frmTwoStepVerify = new frm_TwoStepVerification_UserChange((int)SEACC_Form.enmFormName, false, false, true);
                                    frmTwoStepVerify.ShowDialog();
                                    if (frmTwoStepVerify.bVerified)
                                    {
                                        foreach (tbl_posReceipt oRcept in tbl_posReceipt.SelectAllByAdvanceReceived_Index(oAdv.AdvanceReceived_Index))
                                        {
                                            foreach (tbl_bpsChequeRegister oPayReg in tbl_bpsChequeRegister.SelectAllByCompanyBranch_ID(oAdv.CompanyBranchID).Where(r => r.AdvanceReceived_Index == oAdv.AdvanceReceived_Index && r.PosReceipt_ID == oRcept.PosReceipt_ID))//tbl_bpsChequeRegister.SelectAllByAdvanceReceived_Index(oAdv.AdvanceReceived_Index).Where(r => r.PosReceipt_ID == oRcept.PosReceipt_ID)
                                            {
                                                oPayReg.IsDeleted = true;
                                                oPayReg.Update();
                                            }

                                            oRcept.IsDeleted = true;
                                            oRcept.Update();
                                        }


                                        foreach (tbl_bpsCreditNote oCRN in tbl_bpsCreditNote.SelectAllByAdvanceReceived_Index(oAdv.AdvanceReceived_Index))
                                        {
                                            oCRN.IsDeleted = true;
                                            oCRN.DeletedTerminal_ID = clsSecurity.TerminalID;
                                            oCRN.Update();
                                        }

                                        oAdv.IsCanceled = true;
                                        oAdv.CanceldUser_ID = clsSecurity.UserIDLoged;
                                        oAdv.CanceledUserTerminal_ID = clsSecurity.TerminalID;
                                        oAdv.DateCanceled = clsSecurity.getServerDateTime();
                                        oAdv.Update();

                                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                        ClearFields();
                                    }
                                }
                            }
                            else
                            {
                                if (oAdv != null && oAdv.IsApproved)
                                    SEACCMessageBox.Show("Cannot Cancel..",
                                        "Selected Advance has been approved", MessageBoxButton.OK, "Red");
                                else if (oAdv != null && oAdv.IsCanceled)
                                    SEACCMessageBox.Show("Cannot Cancel..",
                                        "Selected Advance has already been cancelled", MessageBoxButton.OK, "Red");
                                else if (oAdv != null && oAdv.IsSetteled)
                                    SEACCMessageBox.Show("Cannot Cancel..",
                                        "Selected Advance has already been settled", MessageBoxButton.OK, "Red");
                                else
                                    SEACCMessageBox.Show("Cannot Update..", "", MessageBoxButton.OK, "Red");
                            }
                        }
                        else
                        {
                            SEACCMessageBox.Show("Can not Cancel..!", "Branch Day End has already been finished and approved", MessageBoxButton.OK, "Red");
                        }
                    }
                }

                else
                {
                    SEACCMessageBox.Show("Transaction Not Selected..!",
                        "Please select the transaction, you need to cancel ", MessageBoxButton.OK, "Red");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            int iAdvCRN_Index = -1;
            if (CheckValidity())
            {
                //Incompleted Status
                bool bIncompletedTx = true;

                try
                {
                    Cursor = Cursors.Wait;

                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            iAdvCRN_Index = int.Parse(txtAdvanceReceive_ID.Tag.ToString());
                            tbl_posAdvanceReceived oOld_Adv = tbl_posAdvanceReceived.Select(iAdvCRN_Index);

                            #region Day End Checking
                            bool bDayEndCompleted = false;
                            if (oOld_Adv != null)
                            {
                                foreach (tbl_posDayStartAndEnd oDayEnd in tbl_posDayStartAndEnd.SelectAllByCompanyBranch_ID(oOld_Adv.CompanyBranchID).Where(r => r.DateCreated.Date == oOld_Adv.PaymentDate.Date))
                                {
                                    if (oDayEnd.IsApproved)
                                        bDayEndCompleted = true;
                                }
                            }
                            #endregion

                            if (oOld_Adv != null && !oOld_Adv.IsCanceled && !oOld_Adv.IsApproved && !oOld_Adv.IsChecked && !oOld_Adv.IsSetteled && (oOld_Adv.PrintedUser_ID == "default") && !bDayEndCompleted)
                            {
                                tbl_bpsCreditNote.DeleteAllByAdvanceReceived_Index(oOld_Adv.AdvanceReceived_Index);

                                foreach (tbl_posReceipt oReceipt in tbl_posReceipt.SelectAllByAdvanceReceived_Index(oOld_Adv.AdvanceReceived_Index))
                                {
                                    foreach (tbl_sasInvoice_Sattled oSettled in tbl_sasInvoice_Sattled.SelectAllByPosReceipt_ID(oReceipt.PosReceipt_ID))
                                    {
                                        oSettled.Delete();
                                    }

                                    foreach (tbl_bpsChequeRegister oPayReg in tbl_bpsChequeRegister.SelectAllByCompanyBranch_ID(oOld_Adv.CompanyBranchID).Where(r => r.PosReceipt_ID == oReceipt.PosReceipt_ID))
                                    {
                                        oPayReg.Delete();
                                    }

                                    oReceipt.Delete();
                                }

                                decimal dTotal_Amount = clsValidation.Validate_DecimalNumber(txtAdvanceTotal.TextBox1.Text);
                                tbl_posAdvanceReceived oAdvance = new tbl_posAdvanceReceived(oOld_Adv.AdvanceReceived_Index, oOld_Adv.AdvanceReceived_Index.ToString("D8"),
                                   txtCustomerName.Tag != null ? txtCustomerName.Tag.ToString() : "default",
                                   txtRemark.Text, clsSecurity.FinancialYearID,
                                   dtpAdvPay_Date.GetDateTime(), dTotal_Amount,
                                   oOld_Adv.SetteledAmount, oOld_Adv.IsSetteled, oOld_Adv.IsChecked, oOld_Adv.IsApproved, oOld_Adv.IsCanceled, oOld_Adv.CreateUser_ID, clsSecurity.UserIDLoged,
                                   oOld_Adv.CheckedUser_ID, oOld_Adv.ApprovedUser_ID, oOld_Adv.CanceldUser_ID, oOld_Adv.PrintedUser_ID,
                                   oOld_Adv.DateCreate, clsSecurity.getServerDateTime(), oOld_Adv.DateChecked, oOld_Adv.DateApproved, oOld_Adv.DateCanceled, oOld_Adv.DatePrinted, oOld_Adv.PrintCount, oOld_Adv.CreateUserTerminal_ID, clsSecurity.TerminalID, oOld_Adv.CheckedUserTerminal_ID, oOld_Adv.ApprovedUserTerminal_ID, oOld_Adv.CanceledUserTerminal_ID, oOld_Adv.PrintedTerminal_ID, clsSecurity.CompanyID, clsSecurity.BranchID, iPoS_session_dayDetail_Index, oOld_Adv.GlPosting_ID, oOld_Adv.PostingStatus_ID, true);
                                oAdvance.Update();

                                txtAdvanceReceive_ID.Tag = oAdvance.AdvanceReceived_Index;
                                txtAdvanceReceive_ID.Text = oAdvance.AdvanceReceived_ID;

                                tbl_zCurrency currency = tbl_zCurrency.Select(clsConfig.sLocalCurrencyCode);
                                tbl_posReceipt oPoS_Receipt = new tbl_posReceipt("RCP/" + txtAdvanceReceive_ID.Text,
                                    dtpAdvPay_Date.GetDateTime(), (-1), txtRemark.Text,
                                    txtCustomerName.Tag != null ? txtCustomerName.Tag.ToString() : "default",
                                    "default", "default", "default",
                                    clsSecurity.FinancialYearID,
                                    clsConfig.sDefaultSalesNoteTypeID,
                                    currency != null ? currency.Currency_ID : "default",
                                    currency != null ? currency.CurrencyRate : 0m,
                                    clsValidation.Validate_DecimalNumber(txtAdvancCashAmount.Text),
                                    0, dTotal_Amount, clsCommon.CurrencyToWord(dTotal_Amount), dTotal_Amount, 0, 0,
                                    clsSecurity.UserIDLoged, "default", "default", "default", "default",
                                    clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                    clsValidation.defaultDateTime, false, false, false, false, false, 0,
                                    false, false, true, false, oAdvance.AdvanceAmount, true,
                                    clsSecurity.CompanyID, clsSecurity.BranchID, oAdvance.AdvanceReceived_Index);
                                oPoS_Receipt.Insert();

                                Save_AdvancePayment_Registers(oAdvance.AdvanceReceived_Index, oPoS_Receipt.PosReceipt_ID);

                                tbl_bpsCreditNote oCRN = new tbl_bpsCreditNote("CRN/" + txtAdvanceReceive_ID.Text, dtpAdvPay_Date.GetDateTime(),
                                    txtRemark.Text, "default", "default", oAdvance.Customer_ID, "default", "default",
                                    "default", "TP/002", "default", "default", clsSecurity.FinancialYearID, oAdvance.Customer_ID,
                                    "default", oPoS_Receipt.CurrencyRate, 0, 0, 0, 0, oPoS_Receipt.TotalAmount, 0, 0, 0, 0,
                                    oPoS_Receipt.TotalAmount, clsSecurity.UserIDLoged, "default", "default", "default",
                                    clsSecurity.TerminalID, "default", "default", "default", clsSecurity.getServerDateTime(),
                                    clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                    false, false, false, false, false, false, 0, false, 0, clsSecurity.CompanyID, clsSecurity.BranchID,
                                    false, (-1), oAdvance.AdvanceReceived_Index);
                                oCRN.Insert();

                                bIncompletedTx = false;
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                            else
                            {
                                if (oOld_Adv != null && oOld_Adv.IsApproved)
                                    SEACCMessageBox.Show("Cannot Update..",
                                        "Selected Advance has been approved", MessageBoxButton.OK, "Red");
                                else if (oOld_Adv != null && oOld_Adv.IsChecked)
                                    SEACCMessageBox.Show("Cannot Update..",
                                        "Selected Advance has been checked", MessageBoxButton.OK, "Red");
                                else if (bDayEndCompleted)
                                    SEACCMessageBox.Show("Cannot Update..",
                                        "Branch Day End has already been completed and approved.", MessageBoxButton.OK, "Red");
                                else if (oOld_Adv != null && oOld_Adv.IsCanceled)
                                    SEACCMessageBox.Show("Cannot Update..",
                                        "Selected Advance has been cancelled", MessageBoxButton.OK, "Red");
                                else if (oOld_Adv != null && oOld_Adv.IsSetteled)
                                    SEACCMessageBox.Show("Cannot Update..",
                                        "Selected Advance has already been settled", MessageBoxButton.OK, "Red");
                                else if (oOld_Adv != null && oOld_Adv.PrintedUser_ID != "default")
                                    SEACCMessageBox.Show("Cannot Update..",
                                        "Selected Advance has already been printed", MessageBoxButton.OK, "Red");
                                else
                                    SEACCMessageBox.Show("Cannot Update..", "", MessageBoxButton.OK, "Red");
                            }
                        }
                    }
                    else
                    {
                        if (SEACC_Form.CheckPermission_ToSave(false))
                        {
                            if (SEACC_Form.PermissionTO_Write)
                            {
                                #region Insert New POS Customer
                                if ((txtCustomerName.Tag == null || txtCustomerName.Tag.ToString() == "default")
                                    && txtCustomerTelphone.TextBox1.Text.Trim().Length > 0)
                                {
                                    tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.SelectAll()
                                        .FirstOrDefault(r => r.Telephone.Trim() == txtCustomerTelphone.TextBox1.Text.Trim());
                                    if (oCustomer == null)
                                    {
                                        string sNextCustomer_ID = clsAutocode.getAutoGeneratedCode("CON/003");//Customer Master
                                        tbl_genCustomerMaster oNewCustomer = new tbl_genCustomerMaster(
                                            sNextCustomer_ID, "",
                                            txtCustomerName.TextBox1.Text,
                                            txtCustomerAddress.TextBox1.Text, "",
                                            txtCustomerTelphone.TextBox1.Text,
                                            "", "", "", "", "", "", "", "", "", false, false, false,
                                            "default", "default", "default", "default", "default", "default",
                                            "default", "default", "default", "default", "default", "default",
                                            "default", "default", "default", "", false, false, false, false, false,
                                            "", "", clsValidation.defaultDateTime, "default", false, false,
                                            "default", false, clsSecurity.CompanyID, clsSecurity.BranchID, -1,
                                            "default", clsSecurity.UserIDLoged, "default", "default", clsSecurity.TerminalID,
                                            "default", "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime,
                                            clsValidation.defaultDateTime, "default", true, false, 0);
                                        oNewCustomer.Insert();

                                        tbl_accGLMaster_Customer oGL_Customer = new tbl_accGLMaster_Customer(oNewCustomer.Customer_ID, clsConfig_POS.sPos_Customer_Default_GLAccount, true);
                                        oGL_Customer.Insert();

                                        txtCustomerName.Tag = oNewCustomer.Customer_ID;
                                    }
                                    else
                                    {
                                        txtCustomerName.Tag = oCustomer.Customer_ID;
                                    }
                                }
                                #endregion

                                #region Get Advance Receive transaction Index Auto Gen
                                int iPK_AdvanceReceivedTx = 1;
                                var vAdvanceReciveds = tbl_posAdvanceReceived.SelectAll();
                                if (vAdvanceReciveds != null && vAdvanceReciveds.Count > 0)
                                {
                                    iPK_AdvanceReceivedTx = tbl_posAdvanceReceived.SelectAll().Max(r => r.AdvanceReceived_Index) + 1;
                                    txtAdvanceReceive_ID.Tag = iPK_AdvanceReceivedTx;
                                }
                                #endregion

                                decimal dTotal_Amount = clsValidation.Validate_DecimalNumber(txtAdvanceTotal.TextBox1.Text);

                                tbl_posAdvanceReceived oAdvance = new tbl_posAdvanceReceived(iPK_AdvanceReceivedTx, iPK_AdvanceReceivedTx.ToString("D8"),
                                   txtCustomerName.Tag != null ? txtCustomerName.Tag.ToString() : "default",
                                   txtRemark.Text, clsSecurity.FinancialYearID,
                                   dtpAdvPay_Date.GetDateTime(), dTotal_Amount,
                                   0m, false, false, false, false, clsSecurity.UserIDLoged,
                                   "default", "default", "default", "default", "default",
                                   clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, 0, clsSecurity.TerminalID, "default", "default", "default", "default", "default", clsSecurity.CompanyID,
                                   clsSecurity.BranchID, iPoS_session_dayDetail_Index, "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), true);
                                oAdvance.Insert();

                                txtAdvanceReceive_ID.Tag = oAdvance.AdvanceReceived_Index;
                                txtAdvanceReceive_ID.Text = oAdvance.AdvanceReceived_ID;

                                tbl_zCurrency currency = tbl_zCurrency.Select(clsConfig.sLocalCurrencyCode);
                                tbl_posReceipt oPoS_Receipt = new tbl_posReceipt("RCP/" + txtAdvanceReceive_ID.Text,
                                    dtpAdvPay_Date.GetDateTime(), (-1), txtRemark.Text,
                                    txtCustomerName.Tag != null ? txtCustomerName.Tag.ToString() : "default",
                                    "default", "default", "default",
                                    clsSecurity.FinancialYearID,
                                    clsConfig.sDefaultSalesNoteTypeID,
                                    currency != null ? currency.Currency_ID : "default",
                                    currency != null ? currency.CurrencyRate : 0m,
                                    clsValidation.Validate_DecimalNumber(txtAdvancCashAmount.Text),
                                    0, dTotal_Amount, clsCommon.CurrencyToWord(dTotal_Amount), dTotal_Amount, 0, 0,
                                    clsSecurity.UserIDLoged, "default", "default", "default", "default",
                                    clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                    clsValidation.defaultDateTime, false, false, false, false, false, 0,
                                    false, false, true, false, oAdvance.AdvanceAmount, true,
                                    clsSecurity.CompanyID, clsSecurity.BranchID, oAdvance.AdvanceReceived_Index);
                                oPoS_Receipt.Insert();

                                Save_AdvancePayment_Registers(oAdvance.AdvanceReceived_Index, oPoS_Receipt.PosReceipt_ID);

                                tbl_bpsCreditNote oCRN = new tbl_bpsCreditNote("CRN/" + txtAdvanceReceive_ID.Text, dtpAdvPay_Date.GetDateTime(),
                                    txtRemark.Text, "default", "default", oAdvance.Customer_ID, "default", "default",
                                    "default", "TP/002", "default", "default", clsSecurity.FinancialYearID, oAdvance.Customer_ID,
                                    "default", oPoS_Receipt.CurrencyRate, 0, 0, 0, 0, oPoS_Receipt.TotalAmount, 0, 0, 0, 0,
                                    oPoS_Receipt.TotalAmount, clsSecurity.UserIDLoged, "default", "default", "default",
                                    clsSecurity.TerminalID, "default", "default", "default", clsSecurity.getServerDateTime(),
                                    clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                    false, false, false, false, false, false, 0, false, 0, clsSecurity.CompanyID, clsSecurity.BranchID,
                                    false, (-1), oAdvance.AdvanceReceived_Index);
                                oCRN.Insert();

                                iAdvCRN_Index = oAdvance.AdvanceReceived_Index;
                                bIncompletedTx = false;
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                            }
                            else
                            {
                                SEACCMessageBox.Show("Can not Insert..!", "You don't have permission to insert", MessageBoxButton.OK, "Red");
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    bIncompletedTx = true;
                    SEACCExeption.Show(ex);
                }
                finally
                {
                    Cursor = Cursors.Arrow;
                    tbl_posAdvanceReceived oAdvance = tbl_posAdvanceReceived.Select(int.Parse(txtAdvanceReceive_ID.Tag.ToString()));
                    if (oAdvance != null)
                    {
                        if (!bIncompletedTx)
                        {


                            #region Get Advance Receive transaction ID Auto Gen

                            if (SEACC_Form.isAutoGenaratedCode)
                            {
                                txtAdvanceReceive_ID.Text = SEACC_Form.getAutoGeneratedCode();
                                oAdvance.AdvanceReceived_ID = txtAdvanceReceive_ID.Text;
                                oAdvance.Update();
                            }

                            #endregion

                            if (clsValidate.CheckValidity_TransactionCodeLength(txtAdvanceReceive_ID.Text))
                            {
                                oAdvance.IsIncompleted = false;
                                oAdvance.Update();

                                ClearFields();
                                RefreshGrid();
                                FillDetails(iAdvCRN_Index);
                            }
                            else
                            {
                                bIncompletedTx = true;
                            }

                        }

                        if (bIncompletedTx)
                        {

                            foreach (tbl_posReceipt oRcept in tbl_posReceipt.SelectAllByAdvanceReceived_Index(
                                oAdvance.AdvanceReceived_Index))
                            {
                                foreach (tbl_bpsChequeRegister oPayReg in tbl_bpsChequeRegister
                                    .SelectAllByCompanyBranch_ID(oAdvance.CompanyBranchID)
                                    .Where(r => r.AdvanceReceived_Index == oAdvance.AdvanceReceived_Index &&
                                                r.PosReceipt_ID == oRcept.PosReceipt_ID))
                                {
                                    oPayReg.IsDeleted = true;
                                    oPayReg.Update();
                                }

                                oRcept.IsDeleted = true;
                                oRcept.Update();
                            }


                            foreach (tbl_bpsCreditNote oCRN in tbl_bpsCreditNote.SelectAllByAdvanceReceived_Index(
                                oAdvance.AdvanceReceived_Index))
                            {
                                oCRN.IsDeleted = true;
                                oCRN.DeletedTerminal_ID = clsSecurity.TerminalID;
                                oCRN.Update();
                            }

                            oAdvance.IsCanceled = true;
                            oAdvance.CanceldUser_ID = clsSecurity.UserIDLoged;
                            oAdvance.CanceledUserTerminal_ID = clsSecurity.TerminalID;
                            oAdvance.DateCanceled = clsSecurity.getServerDateTime();
                            oAdvance.Update();

                            SEACCMessageBox.Show("Something Went Wrong...!", "Please Save the Transaction Again...",
                                MessageBoxButton.OK, "Red");
                        }
                    }

                    Cursor = Cursors.Arrow;
                }
            }
        }

        #region Check validity

        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_NotManagerSignOff())
            {
                if (CheckValidity_EmptyField())
                {
                    if (CheckValidity_DuplicateFiled())
                    {
                        if (Check_Transaction_ID())
                        {
                            bStatus = true;
                        }
                    }
                }
            }

            return bStatus;
        }

        private bool Check_Transaction_ID()
        {
            bool bStatus = false;
            if (!SEACC_Form.isAutoGenaratedCode)
            {
                if (clsValidate.CheckValidity_TransactionCodeLength(txtAdvanceReceive_ID.Text))
                {
                    bStatus = true;
                }
            }
            else
            {
                bStatus = true;
            }

            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtAdvanceReceive_ID) && !SEACC_Form.isAutoGenaratedCode)
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtAdvanceTotal) || clsValidation.Validate_DecimalNumber(txtAdvanceTotal.TextBox1.Text) <= 0)
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCustomerName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCustomerTelphone))
                bStatus = false;

            return bStatus;
        }

        private bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode && !SEACC_Form.isAutoGenaratedCode)
            {
                tbl_posAdvanceReceived oCRN = tbl_posAdvanceReceived.SelectAllByCompanyBranchID(clsSecurity.BranchID).FirstOrDefault(r => r.AdvanceReceived_ID == txtAdvanceReceive_ID.Text.Trim());
                if (oCRN != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }


        //Check Manager Sign Off
        private bool CheckValidity_NotManagerSignOff()
        {
            bool bStatus = clsHelpMethods_POS.Check_ManagerSignOff_Created(iPoS_session_dayDetail_Index);

            if (bStatus)
            {
                SEACCMessageBox.Show("Manager Signed Off...",
                    "Terminal session has been signed off. No longer save any transactions...",
                    MessageBoxButton.OK, "Red");
            }

            return !bStatus;
        }

        #endregion

        #region Card Payment Grid Buttons
        private void btnCardPaymentAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity_CardPayment())
                dtCardPayment.Rows.Add("0", cmbCardType.GetSelectedIndex(), cmbCardType.GetSelectedValue(),
                    txtNameOnCard.Text, txtCardLast4Digits.Text, txtCardBank.Tag.ToString(), txtCardBank.Text,
                    cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(txtCardPayAmount.Text), clsConfig.sPOSBillDecimalPoint));

            CardPayment_ClearFields();
            Refresh_PaymentGridDetails();
        }

        private void btnCardPaymentDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgrCardPays.SelectedItem;
            if (selectedItem != null)
            {
                string sLineNo = (dgrCardPays.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock)?.Text;
                DataRow[] items = dtCardPayment.Select("LineNo ='" + sLineNo + "'");
                if (items.Length > 0)
                {
                    foreach (DataRow item in items)
                        dtCardPayment.Rows.Remove(item);
                }
                clsHelpMethods_POS.OrderBy_DataGrid(dtCardPayment);
            }

            CardPayment_ClearFields();
            Refresh_PaymentGridDetails();
        }
        #endregion

        #region Cheque Payment Grid Buttons
        private void btnChequePaymentAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity_EmptyField_PDCheque())
            {
                dtChequePayment.Rows.Add("0", txtChequeAccoutNo.Text, txtChequeBankName.Tag.ToString(), txtChequeBankName.Text,
                    txtChequeBankBranch.Tag.ToString(), txtChequeBankBranch.Text, txtChequeNo.Text, dtpChequeDate.GetDateTime().ToString(cls_Formater.Format_Date2),
                    cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(txtChequeAmount.Text), clsConfig.sPOSBillDecimalPoint));
            }

            ChequePayment_ClearFields();
            Refresh_PaymentGridDetails();
        }

        private void btnChequePaymentDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgrCheques.SelectedItem;
            if (selectedItem != null)
            {
                string sLineNo = (dgrCheques.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock)?.Text;
                DataRow[] items = dtChequePayment.Select("LineNo ='" + sLineNo + "'");
                if (items.Length > 0)
                {
                    foreach (DataRow item in items)
                        dtChequePayment.Rows.Remove(item);
                }
                clsHelpMethods_POS.OrderBy_DataGrid(dtChequePayment);
                Refresh_PaymentGridDetails();
            }
            ChequePayment_ClearFields();
        }
        #endregion

        #region Gift Voucher Grid Buttons
        private void btnGiftVoucherAdd_Click(object sender, RoutedEventArgs e)
        {
            frmSearchForm rowDataSearch = new frmSearchForm();
            List<string> lstResult = rowDataSearch.Show(Search.Pos_GiftVouchers_Issued);

            if (rowDataSearch.DialogResult == true)
            {
                DataRow[] items = dtGiftVoucherPayment.Select("VoucherID ='" + lstResult[0] + "'");
                if (items.Length == 0)
                {
                    dtGiftVoucherPayment.Rows.Add("0", lstResult[0], lstResult[1], "", "",
                        cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(lstResult[4]),
                            clsConfig.sPOSBillDecimalPoint));
                }
                else
                {
                    SEACCMessageBox.Show("Gift Voucher Already Exist",
                        "", MessageBoxButton.OK, "Red");
                }
            }
            Refresh_PaymentGridDetails();
        }

        private void btnGiftVoucherDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgrGiftVoucher.SelectedItem;
            if (selectedItem != null)
            {
                string sLineNo = (dgrGiftVoucher.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock)?.Text;
                DataRow[] items = dtGiftVoucherPayment.Select("LineNo ='" + sLineNo + "'");
                if (items.Length > 0)
                {
                    foreach (DataRow item in items)
                        dtGiftVoucherPayment.Rows.Remove(item);
                }
                clsHelpMethods_POS.OrderBy_DataGrid(dtGiftVoucherPayment);
                Refresh_PaymentGridDetails();
            }
        }
        #endregion

        #region Credit Note Grid Buttons
        private void btnCRNAdd_Click(object sender, RoutedEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            if (clsSecurity.BranchID != "")
                lstParameeters.Add(clsSecurity.BranchID);

            frmSearchForm RowDataSearch = new frmSearchForm(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.POS_CRNs_NotRedeem);

            if (RowDataSearch.DialogResult == true)
            {
                try
                {
                    DataRow[] items = dtCRN.Select("CRN_Index ='" + lstResult[0] + "'");
                    if (items.Length == 0)
                        dtCRN.Rows.Add("0", lstResult[0], lstResult[1], cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(lstResult[3]), clsConfig.sPOSBillDecimalPoint));
                    else
                        SEACCMessageBox.Show("CRN Already Exist", "", MessageBoxButton.OK, "Red");
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
            }
            Refresh_PaymentGridDetails();
        }

        private void btnCRNDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgrCRN.SelectedItem;
            if (selectedItem != null)
            {
                string sLineNo = (dgrCRN.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock)?.Text;
                DataRow[] items = dtCRN.Select("LineNo ='" + sLineNo + "'");
                if (items.Length > 0)
                {
                    foreach (DataRow item in items)
                        dtCRN.Rows.Remove(item);
                }
                clsHelpMethods_POS.OrderBy_DataGrid(dtCRN);
            }
            Refresh_PaymentGridDetails();
        }
        #endregion

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtAdvanceReceive_ID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCustomerName, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtCustomerAddress, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtCustomerTelphone, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemark, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtAdvancCashAmount, true, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtAdvanceTotal, true, true, false);

            txtAdvanceReceive_ID.Tag = null;
            txtCustomerName.Tag = null;

            txtAdvanceReceive_ID.Text = "";
            txtCustomerName.Text = "";
            txtCustomerAddress.Text = "";
            txtCustomerTelphone.Text = "";
            txtRemark.Text = "";
            txtAdvancCashAmount.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            txtAdvanceTotal.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);

            dtpAdvPay_Date.IsEnabled = false;
            dtpAdvPay_Date.SetTime(clsSecurity.getServerDateTime());

            expCardPayments.Header = "Card Payments: " + cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            expChequePayments.Header = "Cheque Payments: " + cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            expGiftVoucherPayments.Header = "Gift Vouchers: " + cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            expCreditNotePayments.Header = "Credit Notes: " + cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);

            #region Set Auto Genarate Key fields
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtAdvanceReceive_ID.setReadOnlyStatus(true);
                txtAdvanceReceive_ID.Text = "<Auto Generate>";
            }
            else
                txtAdvanceReceive_ID.setReadOnlyStatus(false);
            #endregion

            CardPayment_ClearFields();
            ChequePayment_ClearFields();

            dtCardPayment.Rows.Clear();
            dtChequePayment.Rows.Clear();
            dtGiftVoucherPayment.Rows.Clear();
            dtCRN.Rows.Clear();
        }

        private void CardPayment_ClearFields()
        {
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtMerchantDevice, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtNameOnCard, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtCardLast4Digits, true, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCardBank, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCardPayAmount, true, true, false);

            txtMerchantDevice.Tag = null;
            txtNameOnCard.Tag = null;
            txtCardLast4Digits.Tag = null;
            txtCardBank.Tag = null;
            txtCardPayAmount.Tag = null;

            txtMerchantDevice.TextBox1.Text = "";
            txtNameOnCard.TextBox1.Text = "";
            txtCardBank.TextBox1.Text = "<Select Bank>";
            txtCardPayAmount.TextBox1.Text = "";
            txtCardLast4Digits.TextBox1.Text = "";
            txtCardPayAmount.TextBox1.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);

            txtCardLast4Digits.TextBox1.MaxLength = 4;

            cmbCardType.comboBox.ItemsSource = clsHelpMethods_POS.GetEnumDescription_List(typeof(PaymentCardTypes));
            cmbCardType.SetSelectedIndex((int)PaymentCardTypes.Visa);

            tbl_genMerchantDeviceMaster oDefaultDevice = tbl_genMerchantDeviceMaster.SelectAllByCompanyBranch_ID(clsSecurity.BranchID).FirstOrDefault(r => r.IsActive && r.IsDefaultMachine && !r.IsCanceled);
            if (oDefaultDevice != null)
            {
                txtMerchantDevice.Tag = oDefaultDevice.Merchant_DeviceID;
                txtMerchantDevice.TextBox1.Text = oDefaultDevice.Device_Name;
            }
        }

        private void ChequePayment_ClearFields()
        {
            cls_Formater.SetEnableDisable_LableTextbox(txtChequeAccoutNo, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtChequeBankName, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtChequeBankBranch, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtChequeNo, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtChequeAmount, true, true, false);

            txtChequeAccoutNo.Tag = null;
            txtChequeBankName.Tag = null;
            txtChequeBankBranch.Tag = null;
            txtChequeNo.Tag = null;
            txtChequeAmount.Tag = null;

            txtChequeAccoutNo.TextBox1.Text = "";
            txtChequeBankName.TextBox1.Text = "<Select Bank>";
            txtChequeBankBranch.TextBox1.Text = "<Select Bank Branch>";
            txtChequeNo.TextBox1.Text = "";
            txtChequeAmount.TextBox1.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);

            dtpChequeDate.SetTime(clsSecurity.getServerDateTime());
        }

        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_posAdvanceReceived oAdvCRN in tbl_posAdvanceReceived.SelectAllByCompanyBranchID(clsSecurity.BranchID).OrderByDescending(r => r.DateCreate))
                {
                    dgr_Main.dt.Rows.Add(
                        "0",
                        oAdvCRN.AdvanceReceived_Index,
                        oAdvCRN.AdvanceReceived_ID,
                        oAdvCRN.PaymentDate.ToString(cls_Formater.Format_Date2),
                        clsGenaralName.getName_Customer(oAdvCRN.Customer_ID),
                        cls_Formater.FormatDecimal(oAdvCRN.AdvanceAmount, clsConfig.sPOSBillDecimalPoint),
                        oAdvCRN.IsSetteled, oAdvCRN.IsCanceled
                        );
                }
                clsHelpMethods_POS.OrderBy_DataGrid(dgr_Main.dt);
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }

        }

        #region Refresh Payment Grids
        public void Refresh_PaymentGridDetails()
        {
            decimal dCashPaymentstotal = clsValidation.Validate_DecimalNumber(txtAdvancCashAmount.TextBox1.Text);
            decimal dCardPaymentsTotal = clsValidation.Validate_DecimalNumber(dtCardPayment.Compute("SUM(Amount)", "").ToString());
            decimal dChequesTotal = clsValidation.Validate_DecimalNumber(dtChequePayment.Compute("SUM(ChequeAmount)", "").ToString());
            decimal dGiftVoucherTotal = clsValidation.Validate_DecimalNumber(dtGiftVoucherPayment.Compute("SUM(VoucherAmount)", "").ToString());
            decimal dCRNTotal = clsValidation.Validate_DecimalNumber(dtCRN.Compute("SUM(CRN_Amount)", "").ToString());

            expCardPayments.Header = "Card Payments: " + cls_Formater.FormatDecimal(dCardPaymentsTotal, clsConfig.sPOSBillDecimalPoint);
            expChequePayments.Header = "Cheque Payments: " + cls_Formater.FormatDecimal(dChequesTotal, clsConfig.sPOSBillDecimalPoint);
            expGiftVoucherPayments.Header = "Gift Vouchers: " + cls_Formater.FormatDecimal(dGiftVoucherTotal, clsConfig.sPOSBillDecimalPoint);
            expCreditNotePayments.Header = "Credit Notes: " + cls_Formater.FormatDecimal(dCRNTotal, clsConfig.sPOSBillDecimalPoint);

            decimal dReceiptTotal = dCashPaymentstotal + dCardPaymentsTotal + dChequesTotal + dGiftVoucherTotal + dCRNTotal;
            txtAdvanceTotal.TextBox1.Text = cls_Formater.FormatDecimal(dReceiptTotal, clsConfig.sPOSBillDecimalPoint);
        }
        #endregion

        #endregion

        private void FillDetails(int iAdvReceive_Index)
        {
            SEACC_Form.IsUpdateMode = true;

            tbl_posAdvanceReceived oAdv_Received = tbl_posAdvanceReceived.Select(iAdvReceive_Index);
            if (oAdv_Received != null && oAdv_Received.AdvanceReceived_Index > 0)
            {
                txtAdvanceReceive_ID.Tag = oAdv_Received.AdvanceReceived_Index;
                txtCustomerName.Tag = oAdv_Received.Customer_ID;

                txtAdvanceReceive_ID.Text = oAdv_Received.AdvanceReceived_ID;
                txtCustomerName.Text = clsGenaralName.getName_Customer(oAdv_Received.Customer_ID);
                txtCustomerAddress.Text = clsGenaralName.getName_CustomerRegisterAddress(oAdv_Received.Customer_ID);
                txtCustomerTelphone.Text = clsGenaralName.getName_CustomerTelephone(oAdv_Received.Customer_ID);
                txtRemark.Text = oAdv_Received.Remark;
                txtAdvanceTotal.Text = cls_Formater.FormatDecimal(oAdv_Received.AdvanceAmount, clsConfig.sPOSBillDecimalPoint);

                tbl_posReceipt oPosReceipt = tbl_posReceipt.SelectAllByAdvanceReceived_Index(oAdv_Received.AdvanceReceived_Index).FirstOrDefault();
                if (oPosReceipt != null)
                {
                    //Cash Payments
                    decimal dCashTotal = 0;
                    var vCashPays = tbl_bpsChequeRegister.SelectAllByPosReceipt_ID(oPosReceipt.PosReceipt_ID).Where(r => !r.IsDeleted && r.PaymentMethod_ID == (int)PaymentMethod.Cash);
                    if (vCashPays != null && vCashPays.Count() > 0)
                        dCashTotal = vCashPays.Sum(r => r.Amount);
                    txtAdvancCashAmount.Text = cls_Formater.FormatDecimal(dCashTotal, clsConfig.sPOSBillDecimalPoint);

                    //Card Payments
                    CardPayment_ClearFields();
                    dtCardPayment.Rows.Clear();
                    var vCardPays = tbl_bpsChequeRegister.SelectAllByPosReceipt_ID(oPosReceipt.PosReceipt_ID).Where(r => !r.IsDeleted && r.PaymentMethod_ID == (int)PaymentMethod.Card);
                    foreach (var vCardPay in vCardPays)
                    {
                        string sCardOwnerName = !string.IsNullOrEmpty(vCardPay.CardOwnerName) ? clsSecurity.decryptPassword(vCardPay.CardOwnerName) : vCardPay.CardOwnerName;
                        string sLastFourDigits = !string.IsNullOrEmpty(vCardPay.LastFourDigits) ? clsSecurity.decryptPassword(vCardPay.LastFourDigits) : vCardPay.LastFourDigits;

                        dtCardPayment.Rows.Add("0", vCardPay.CardType,
                            clsHelpMethods_POS.GetEnumDescription((PaymentCardTypes)vCardPay.CardType),
                            sCardOwnerName,
                            sLastFourDigits,
                            vCardPay.Bank_ID,
                            clsGenaralName.getShortName_Bank(vCardPay.Bank_ID), cls_Formater.FormatDecimal(vCardPay.Amount, clsConfig.sPOSBillDecimalPoint));
                    }

                    //Cheque Payments
                    dtChequePayment.Rows.Clear();
                    foreach (tbl_bpsChequeRegister oCheqPaymentReg in tbl_bpsChequeRegister.SelectAllByPosReceipt_ID(oPosReceipt.PosReceipt_ID).Where(r => !r.IsDeleted && r.PaymentMethod_ID == (int)PaymentMethod.Cheque))
                    {
                        dtChequePayment.Rows.Add("0",
                            oCheqPaymentReg.AccountNumber,
                            oCheqPaymentReg.Bank_ID,
                            clsGenaralName.getShortName_Bank(oCheqPaymentReg.Bank_ID),
                            oCheqPaymentReg.Branch_ID,
                            clsGenaralName.getName_BankBranch(oCheqPaymentReg.Branch_ID),
                            oCheqPaymentReg.ChequeNumber,
                            oCheqPaymentReg.DateCheque.ToString(cls_Formater.Format_Date2),
                            cls_Formater.FormatDecimal(oCheqPaymentReg.Amount, clsConfig.sPOSBillDecimalPoint));


                    }

                    //Gift Voucher Payments
                    dtGiftVoucherPayment.Rows.Clear();
                    foreach (tbl_bpsChequeRegister oPaymentReg in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oPosReceipt.PosReceipt_ID).Where(r => !r.IsDeleted && r.PaymentMethod_ID == (int)PaymentMethod.Gift_Voucher))
                    {
                        tbl_bpsGiftVoucher oGiftVoucher = tbl_bpsGiftVoucher.Select(oPaymentReg.GiftVoucherID);
                        if (oGiftVoucher != null)
                            dtGiftVoucherPayment.Rows.Add("0", oPaymentReg.GiftVoucherID, oGiftVoucher.SerialNo,
                                oGiftVoucher.DateValidFrom.ToString(cls_Formater.Format_Date2),
                                oGiftVoucher.ExpiryDate.ToString(cls_Formater.Format_Date2),
                                cls_Formater.FormatDecimal(oGiftVoucher.VoucherAmount, clsConfig.sPOSBillDecimalPoint));
                    }

                    //Credit Note Payments - Sales Return
                    dtCRN.Rows.Clear();
                    foreach (tbl_bpsChequeRegister oPCRN_Payment in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oPosReceipt.PosReceipt_ID).Where(r => !r.IsDeleted && r.PaymentMethod_ID == (int)PaymentMethod.Credit_Note))
                    {
                        tbl_posTransaction oPosRetrun = tbl_posTransaction.Select(oPCRN_Payment.PosReturnTransaction_Index);
                        if (oPosRetrun != null)
                        {
                            //CRNs
                            dtCRN.Rows.Add("0",
                                oPosRetrun.PosTransaction_Index,
                                oPosRetrun.PosTransaction_ID,
                                cls_Formater.FormatDecimal(oPosRetrun.GrandTotal, clsConfig.sPOSBillDecimalPoint));
                        }
                    }
                }
                Refresh_PaymentGridDetails();
            }
        }

        #region Card Payment Validity
        private bool CheckValidity_CardPayment()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField_Card())
            {
                if (CheckValidity_CardNuumber())
                {
                    bStatus = true;
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField_Card()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtCardLast4Digits))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCardBank) || txtCardBank.Tag == null)
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCardPayAmount))
                bStatus = false;

            return bStatus;
        }

        private bool CheckValidity_CardNuumber()
        {
            bool bStatus = true;

            if (txtCardLast4Digits.TextBox1.Text.Length != 4)
            {
                SEACCMessageBox.Show("Ops..!", "Last 4 digites of card are not valid...", MessageBoxButton.OK, "Red");
                bStatus = false;
            }

            return bStatus;
        }
        #endregion

        #region Cheque Payment Validity
        private bool CheckValidity_EmptyField_PDCheque()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtChequeBankName) || txtChequeBankName.Tag == null)
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtChequeBankBranch) || txtChequeBankBranch.Tag == null)
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtChequeNo))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtChequeAmount))
                bStatus = false;

            return bStatus;
        }
        #endregion

        #region Grid Events
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgr_Main.grdMain.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                    ClearFields();
                    FillDetails(int.Parse(GridID));
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }

        private void dgr_Main_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                //Settled Advance
                if (Convert.ToBoolean(((DataRowView)(e.Row.DataContext)).Row.ItemArray[6].ToString()))
                {
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#a0ffa0");
                }

                //Canceled Advance
                if (Convert.ToBoolean(((DataRowView)(e.Row.DataContext)).Row.ItemArray[7].ToString()))
                {
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#FFA0A0");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void dgrCardPays_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_POS.OrderBy_DataGrid(dtCardPayment);
        }

        private void dgrCheques_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_POS.OrderBy_DataGrid(dtChequePayment);
        }

        private void dgrCRN_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_POS.OrderBy_DataGrid(dtCRN);
        }

        private void dgrGiftVoucher_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_POS.OrderBy_DataGrid(dtGiftVoucherPayment);
        }

        #endregion

        #region Search Events - Common

        private void txtCustomerName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearchForm RowDataSearch = new frmSearchForm();
            List<string> lstResult = RowDataSearch.Show(Search.Pos_CustomersWithBranches);

            if (RowDataSearch.DialogResult == true)
            {
                txtCustomerName.Tag = lstResult[0];
                txtCustomerName.Text = lstResult[2];
                txtCustomerTelphone.Text = lstResult[5];
                txtCustomerAddress.Text = lstResult[6];
            }
        }

        #endregion

        #region Search Events - Card Payments
        private void txtMerchantDevice_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearchForm RowDataSearch = new frmSearchForm();
            List<string> lstResult = RowDataSearch.Show(Search.Pos_Merchant_Device);

            if (RowDataSearch.DialogResult == true)
            {
                txtMerchantDevice.Tag = lstResult[0];
                txtMerchantDevice.TextBox1.Text = lstResult[2];
            }
        }

        private void txtCardBank_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearchForm rowDataSearch = new frmSearchForm();
            List<string> lstResult = rowDataSearch.Show(Search.Banks);

            if (rowDataSearch.DialogResult == true)
            {
                txtCardBank.Tag = lstResult[0];
                txtCardBank.Text = lstResult[1] + " - " + lstResult[2];
            }
        }
        #endregion

        #region Search Events - Cheque Payments

        private void txtChequeBankName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearchForm rowDataSearch = new frmSearchForm();
            List<string> lstResult = rowDataSearch.Show(Search.Banks);

            if (rowDataSearch.DialogResult == true)
            {
                txtChequeBankName.Tag = lstResult[0];
                txtChequeBankName.Text = lstResult[1] + " - " + lstResult[2];

                txtChequeBankBranch.Tag = null;
                txtChequeBankBranch.Text = "<Select Bank Branch>";
            }
        }

        private void txtChequeBankBranch_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            if (txtChequeBankName.Tag != null && txtChequeBankName.Text != "")
                lstParameeters.Add(txtChequeBankName.Tag.ToString());

            frmSearchForm rowDataSearch = new frmSearchForm(lstParameeters);
            List<string> lstResult = rowDataSearch.Show(Search.BankBranch);

            if (rowDataSearch.DialogResult == true)
            {
                txtChequeBankName.Tag = lstResult[0];
                txtChequeBankName.Text = lstResult[1];

                txtChequeBankBranch.Tag = lstResult[2];
                txtChequeBankBranch.Text = lstResult[3];
            }
        }

        #endregion

        #region Other Textbox Events
        private void txtAdvancCashAmount_TextBox_TextChanged(object sender, EventArgs e)
        {
            Refresh_PaymentGridDetails();
        }
        #endregion

        #region Key Press Events
        private void SEACC_Form_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                btn_New_Click(sender, e);
            }
        }

        private void txtCustomerTelphone_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return")
            {
                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.SelectAll().FirstOrDefault(r => r.Telephone == txtCustomerTelphone.TextBox1.Text);
                if (oCustomer != null)
                {
                    txtCustomerName.Tag = oCustomer.Customer_ID;
                    txtCustomerName.Text = oCustomer.CustomerName;
                    txtCustomerTelphone.Text = oCustomer.Telephone;
                    txtCustomerAddress.Text = oCustomer.AddressRegister;
                }
                else
                {
                    txtCustomerName.Tag = null;
                    txtCustomerName.Text = "";
                    txtCustomerAddress.Text = "";

                    SEACCMessageBox.Show("Not Found...", "Customer details can not be found in the system.\nPlease enter new customer details here...", MessageBoxButton.OK);

                }
            }
        }
        #endregion

        private void Save_AdvancePayment_Registers(int iPOS_AdvanceReceived_Index, string sPOS_Receipt_ID)
        {
            #region Card Payments
            foreach (DataRow row in dtCardPayment.Rows)
            {
                int iCardTypeID = Convert.ToInt16(clsValidate.ValidateRowValue(row, "CardTypeID", -1m));
                string sNameOnCard = clsValidate.ValidateRowValue(row, "NameOnCard", "");
                string sLastFourDigits = clsValidate.ValidateRowValue(row, "LastFourDigits", "");
                string sBankID = clsValidate.ValidateRowValue(row, "BankID", "");
                decimal dAmount = clsValidate.ValidateRowValue(row, "Amount", 0m);

                string sPayRegCode = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.ChequeRegister));
                string sEnctyptLastFourDigits = clsSecurity.encryptPassword(sLastFourDigits); //clsCript.Encrypt(sLastFourDigits);
                string sEnctyptNameOnCard = clsSecurity.encryptPassword(sNameOnCard); // clsCript.Encrypt(sNameOnCard);

                tbl_bpsChequeRegister oPayReg = new tbl_bpsChequeRegister(sPayRegCode, "", clsSecurity.getServerDateTime(), (int)PaymentMethod.Card, (-1), "", (-1),
                    (txtMerchantDevice.Tag != null ? (int.Parse(txtMerchantDevice.Tag.ToString())) : (-1)),
                    sEnctyptLastFourDigits
                    , sEnctyptNameOnCard, iCardTypeID,
                    (-1), clsValidation.defaultDateTime,
                    txtCustomerName.Tag.ToString(), "", "", -1,
                    sBankID, "default", "default", "default",
                    "default", "default", "default", "default",
                    "default", sPOS_Receipt_ID, "default", "default", "",
                    "default", "default", "default", clsSecurity.FinancialYearID,
                    dAmount, false, false, false, false, false, false, false,
                    clsSecurity.UserIDLoged, "default", clsSecurity.getServerDateTime(),
                    clsValidation.defaultDateTime, false, false, 0, 0, 0, 0,
                    clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                    clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                    clsSecurity.CompanyID, clsSecurity.BranchID, (-1), iPOS_AdvanceReceived_Index, (-1));
                oPayReg.Insert();

                SavePosAdavcne_Settlement(sPOS_Receipt_ID, sPayRegCode, dAmount);
            }
            #endregion

            #region Gift Vouchers
            foreach (DataRow row in dtGiftVoucherPayment.Rows)
            {
                int iGiftVoucherID = Convert.ToInt16(clsValidate.ValidateRowValue(row, "VoucherID", -1m));
                decimal dVoucherAmount = clsValidate.ValidateRowValue(row, "VoucherAmount", 0m);

                string sPayRegCode = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.ChequeRegister));

                //Gift voucher Redeem
                tbl_bpsGiftVoucher oGiftVoucher = tbl_bpsGiftVoucher.Select(iGiftVoucherID);
                if (oGiftVoucher != null)
                {
                    oGiftVoucher.IsRedeemed = true;
                    oGiftVoucher.SetteledAmount = oGiftVoucher.VoucherAmount;
                    oGiftVoucher.Update();
                }

                tbl_bpsChequeRegister oPayReg = new tbl_bpsChequeRegister(sPayRegCode, "", clsSecurity.getServerDateTime(),
                    (int)PaymentMethod.Gift_Voucher, (-1), "", iGiftVoucherID, (-1), "", "", (-1), (-1),
                    clsValidation.defaultDateTime, txtCustomerName.Tag.ToString(), "", "", -1,
                    "default", "default", "default", "default", "default", "default", "default",
                    "default", "default", sPOS_Receipt_ID, "default", "default", "", "default", "default",
                    "default", clsSecurity.FinancialYearID, dVoucherAmount,
                    false, false, false, false, false, false, false, clsSecurity.UserIDLoged,
                    "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime,
                    false, false, 0, 0, 0, 0, clsValidation.defaultDateTime,
                    clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                    clsValidation.defaultDateTime, clsSecurity.CompanyID, clsSecurity.BranchID, (-1), iPOS_AdvanceReceived_Index, (-1));
                oPayReg.Insert();

                SavePosAdavcne_Settlement(sPOS_Receipt_ID, sPayRegCode, dVoucherAmount);
            }
            #endregion

            #region CRNs
            foreach (DataRow row in dtCRN.Rows)
            {
                int iPOS_ReturnTransactionIndex = Convert.ToInt16(clsValidate.ValidateRowValue(row, "CRN_Index", -1m));
                decimal dCRN_Amount = clsValidate.ValidateRowValue(row, "CRN_Amount", 0m);

                string sPayRegCode = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.ChequeRegister));

                //CRN Settled
                tbl_posTransaction oPosReturn = tbl_posTransaction.Select(iPOS_ReturnTransactionIndex);
                if (oPosReturn != null)
                {
                    oPosReturn.IsSeattled = true;
                    oPosReturn.SeattleAmount = dCRN_Amount;
                    oPosReturn.Update();

                    tbl_bpsCreditNote oCRN = tbl_bpsCreditNote.SelectAllByPosReturnTransaction_Index(oPosReturn.PosTransaction_Index).FirstOrDefault();
                    if (oCRN != null)
                    {
                        oCRN.SeattleAmount = dCRN_Amount;
                        oCRN.IsSeattled = true;
                        oCRN.Update();
                    }
                }

                tbl_bpsChequeRegister oPayReg = new tbl_bpsChequeRegister(sPayRegCode, "", clsSecurity.getServerDateTime(),
                    (int)PaymentMethod.Credit_Note, (-1), "", (-1), (-1), "", "", (-1), (-1),
                    clsValidation.defaultDateTime, txtCustomerName.Tag.ToString(), "", "", -1, "default", "default",
                    "default", "default", "default", "default", "default", "default", "default", sPOS_Receipt_ID,
                    "default", "default", "", "default", "default", "default", clsSecurity.FinancialYearID,
                    dCRN_Amount, false, false, false, false, false, false, false, clsSecurity.UserIDLoged,
                    "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, false, false,
                    0, 0, 0, 0, clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                    clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.CompanyID, clsSecurity.BranchID,
                    (-1), iPOS_AdvanceReceived_Index, (-1));
                oPayReg.Insert();

                SavePosAdavcne_Settlement(sPOS_Receipt_ID, sPayRegCode, dCRN_Amount);
            }
            #endregion

            #region Cheque Payments
            foreach (DataRow row in dtChequePayment.Rows)
            {
                string sAccount_No = clsValidate.ValidateRowValue(row, "Account_No", ""); //Customer's Accout No
                string sBankID = clsValidate.ValidateRowValue(row, "BankID", ""); // Customer's Bank
                string sBankBranchID = clsValidate.ValidateRowValue(row, "BankBranchID", ""); // Customer's Bank Branch
                string sChequeNo = clsValidate.ValidateRowValue(row, "ChequeNo", "");
                DateTime dtmChequeDate = clsValidate.ValidateRowValue(row, "ChequeDate", clsValidation.defaultDateTime);
                decimal dChequeAmount = clsValidate.ValidateRowValue(row, "ChequeAmount", 0m);

                string sPayRegCode = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.ChequeRegister));

                tbl_bpsChequeRegister oPayReg = new tbl_bpsChequeRegister(sPayRegCode, "",
                    clsSecurity.getServerDateTime(), (int)PaymentMethod.Cheque,
                    (-1), "", (-1), (-1), "", "", (-1), (-1),
                    dtmChequeDate,
                    txtCustomerName.Tag != null ? txtCustomerName.Tag.ToString() : "default",
                    sAccount_No, "", -1, sBankID, "default", sBankBranchID, "default",
                    ((int)ChequeStatus.New).ToString(), "0", "default", "default",
                    "default", sPOS_Receipt_ID, "default", "default", sChequeNo, "default",
                    "default", "default", clsSecurity.FinancialYearID, dChequeAmount,
                    false, false, false, false, false, false, false, clsSecurity.UserIDLoged,
                    "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime,
                    false, false, 0, 0, 0, 0, clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                    clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                    clsSecurity.CompanyID, clsSecurity.BranchID, (-1), iPOS_AdvanceReceived_Index, (-1));
                oPayReg.Insert();

                SavePosAdavcne_Settlement(sPOS_Receipt_ID, sPayRegCode, dChequeAmount);
            }
            #endregion

            #region Cash Payment
            string sCashPayRegCode = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.ChequeRegister));
            decimal dCashAmount = clsValidation.Validate_DecimalNumber(txtAdvancCashAmount.TextBox1.Text);
            if (dCashAmount != 0)
            {
                tbl_bpsChequeRegister oCashPayReg = new tbl_bpsChequeRegister(sCashPayRegCode, "", clsSecurity.getServerDateTime(),
                    (int)PaymentMethod.Cash, (-1), "", (-1), (-1), "",
                    txtCustomerName.Text, (-1), (-1), clsValidation.defaultDateTime,
                    txtCustomerName.Tag.ToString(), "", "", -1, "default", "default", "default",
                    "default", "default", "default", "default", "default", "default", sPOS_Receipt_ID,
                    "default", "default", "", "default", "default", "default",
                    clsSecurity.FinancialYearID, dCashAmount, false, false, false, false,
                    false, false, false, clsSecurity.UserIDLoged, "default",
                    clsSecurity.getServerDateTime(), clsValidation.defaultDateTime,
                    false, false, 0, 0, 0, 0, clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                    clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.CompanyID,
                    clsSecurity.BranchID, (-1), iPOS_AdvanceReceived_Index, (-1));
                oCashPayReg.Insert();

                SavePosAdavcne_Settlement(sPOS_Receipt_ID, sCashPayRegCode, dCashAmount);
            }
            #endregion
        }

        private void SavePosAdavcne_Settlement(string sPosReceipt_ID, string sPaymentRegister_ID, decimal dPaymentAmount)
        {
            string sSettleCode = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.bssInvoiceSettlement));
            tbl_sasInvoice_Sattled oPosSettled = new tbl_sasInvoice_Sattled(sSettleCode, "default", "defasult", -1, "default", "default", sPosReceipt_ID, sPaymentRegister_ID, "default", "default", "default", -1, "default", "default", clsSecurity.getServerDateTime(), dPaymentAmount, true, clsValidation.defaultDateTime, "default", true, false, "default", "default");
            oPosSettled.Insert();
        }
    }
}
