using DataTire;
using Digiteq_Logic;
using SEACC_POS.DataSet;
using SEACC_POS.Search_Forms;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SEACC_POS.Reports;
using SEACC_POS.Common;
using Ext_Digiteq_Logic;

namespace SEACC_POS
{
    public partial class UC_Reports : UserControl
    {
        #region Class variables
        DataTable dt_Reports = new DataTable();
        dts_posStd glb_dtsPosStd = new dts_posStd();
        dts_posDailySales glb_dtsDailySales = new dts_posDailySales();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        #endregion

        #region Form Load
        public UC_Reports()
        {
            #region Initialize User Control
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.POS_Reports;
            SEACC_Form.Initialize();
            #endregion

            #region  Initialize Data Table
            dt_Reports.Columns.Add("ReportID", typeof(string));
            dt_Reports.Columns.Add("ReportName", typeof(string));
            #endregion

            #region Action Buttons - Hide
            SEACC_Form.SetVisibility_ActionButons(false, false, false, false, false, false);
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBranch, false, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCounter, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCashier, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomer, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSalesRep, true, false, false);

            txtBranch.Tag = clsSecurity.BranchID;
            txtCounter.Tag = null;
            txtCashier.Tag = null;
            txtCustomer.Tag = null;
            txtSalesRep.Tag = null;

            txtBranch.Text = clsGenaralName.getName_CompanyBranchMaster(clsSecurity.BranchID);
            txtCounter.Text = "<All Counters>";
            txtCashier.Text = "<All Cashiers>";
            txtCustomer.Text = "<All Cutomers>";
            txtSalesRep.Text = "<All Sales Reps>";

            dtp_FromDate.SetTime(DateTime.Now);
            dtp_ToDate.SetTime(DateTime.Now);

            stkPOSTx_Types.Visibility = Visibility.Collapsed;
            txtSalesRep.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region Refresh Grid
        public void RefreshGrid()
        {
            try
            {
                foreach (tbl_securityFunctionMaster oReports in tbl_securityFunctionMaster.SelectAll().Where(p => p.FunctionCategory_ID == "FCT/013" && p.Function_ID != 9510 && p.IsVisible && p.IsEnable && p.IsReport))
                {
                    try
                    {
                        //Permited Reports are only shown to the logged user
                        tbl_securityFunctionMaster_Permission oPermission = tbl_securityFunctionMaster_Permission.Select(clsSecurity.BranchID, clsSecurity.UserIDLoged, oReports.Function_ID);
                        if (oPermission != null && oPermission.AllowView)
                            dt_Reports.Rows.Add(oReports.Function_ID, oReports.FunctionName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                dgv_Reports.ItemsSource = dt_Reports.DefaultView;
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Action Buttons
        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int irowID = dgv_Reports.SelectedIndex;
                if (irowID >= 0)
                {
                    Cursor = Cursors.Wait;

                    //Clear Data Sets
                    glb_dtsPosStd.Clear();
                    glb_dtsDailySales.Clear();
                    glb_dtsReportExport.Clear();

                    #region Get report ID
                    string sReportID = dt_Reports.Rows[irowID]["ReportID"].ToString();
                    int iReportID = int.Parse(sReportID);
                    #endregion

                    tbl_securityFunctionMaster_Report oReport = tbl_securityFunctionMaster_Report.Select(iReportID);
                    tbl_securityFunctionMaster_Permission oPermission = tbl_securityFunctionMaster_Permission.Select(clsSecurity.BranchID, clsSecurity.UserIDLoged, oReport.Function_ID);
                    if (oReport != null && oPermission != null)
                    {
                        #region Variables
                        string sFilter = string.Empty;
                        bool bCompanyBranchSelected = false, bCounterSelected = false, bCashierSelected = false, bCustomerSelected = false, bSalesRepSelected = false;
                        #endregion

                        #region From Date - To Date
                        DateTime dtmFromDate = dtp_FromDate.GetDateTime().Date;
                        DateTime dtmToDate = dtp_ToDate.GetDateTime().Date;
                        string sDaterange = "From  : " + dtmFromDate.Date.ToString(cls_Formater.Format_Date2) + " To : " + dtmToDate.Date.ToString(cls_Formater.Format_Date2);
                        #endregion

                        #region Filters
                        if (txtBranch.Tag != null && txtBranch.Tag.ToString().Trim().Length > 0)
                        {
                            bCompanyBranchSelected = true;
                            sFilter = "Branch : " + txtBranch.Text.ToString();
                        }
                        if (txtCounter.Tag != null && txtCounter.Tag.ToString().Trim().Length > 0)
                        {
                            bCounterSelected = true;
                            sFilter += (sFilter != "" ? "  |  " : "") + "Counter : " + txtCounter.Text.ToString();
                        }
                        if (txtCashier.Tag != null && txtCashier.Tag.ToString().Trim().Length > 0)
                        {
                            bCashierSelected = true;
                            sFilter += (sFilter != "" ? "  |  " : "") + "Cashier : " + txtCashier.Text.ToString();
                        }
                        if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Trim().Length > 0)
                        {
                            bCustomerSelected = true;
                            sFilter += (sFilter != "" ? "  |  " : "") + "Customer : " + txtCustomer.Text.ToString();
                        }
                        if (txtSalesRep.Tag != null && txtSalesRep.Tag.ToString().Trim().Length > 0)
                        {
                            bSalesRepSelected = true;
                            sFilter += (sFilter != "" ? "  |  " : "") + "Sales Rep : " + txtSalesRep.Text.ToString();
                        }

                        if (rdoHold.IsChecked.Value)
                        {
                            sFilter += (sFilter != "" ? "  |  " : "") + "POS Transactions : Hold Transactions Only";
                        }
                        if (rdoCompleted.IsChecked.Value)
                        {
                            sFilter += (sFilter != "" ? "  |  " : "") + "POS Transactions : Completed Transactions Only";
                        }
                        if (rdoCancelled.IsChecked.Value)
                        {
                            sFilter += (sFilter != "" ? "  |  " : "") + "POS Transactions : Cancelled Transactions Only";
                        }
                        #endregion

                        #region Standard Report

                        #region Daily Cash colletion Report
                        if (iReportID == (int)(enum_ReportName.POS_DailyCollectionReport))
                        {
                            #region Set company Details
                            tbl_genCompanyBranchMaster oBranchMaster = tbl_genCompanyBranchMaster.Select(txtBranch.Tag.ToString());
                            CompanyImages oComImages = clsCommon_POS.getCompanyImages();
                            glb_dtsPosStd.dt_Company.Adddt_CompanyRow(
                                clsSecurity.DigiteqName,
                                clsSecurity.DigiteqEmail,
                                clsSecurity.CompanyName,
                                clsSecurity.CompanyAddress1,
                                clsSecurity.CompanyAddress2,
                                oComImages.CompanyImage1,
                                oComImages.CompanyImage2,
                                oComImages.CompanyImage3,
                                oReport.DisplayName,
                                oReport.DisplayName2,
                                sDaterange,
                                clsSecurity.UserNameLoged,
                                sFilter,
                                clsCommon.getCompanyBusinessRegisterNo(),
                                clsCommon.getCompanyVAT(),
                                ("BRANCH :" + oBranchMaster.BranchName.ToUpper()),
                                oBranchMaster.Adress.ToUpper(),
                                ("TEL: " + oBranchMaster.Telephone.ToUpper() + " FAX: " + oBranchMaster.Fax.ToUpper())
                                );
                            #endregion

                            #region Fill Detail
                            for (DateTime dtmDate = dtmFromDate.Date; dtmDate.Date <= dtmToDate.Date; dtmDate = dtmDate.AddDays(1))
                            {
                                foreach (tbl_posDayStartAndEnd oBranchDayEnd in tbl_posDayStartAndEnd.SelectAllByCompanyBranch_ID(oBranchMaster.CompanyBranch_ID).Where(r => r.DateCreated.Date == dtmDate.Date))
                                {
                                    foreach (tbl_posDayStartAndEnd_Detail oCashierSignIn_ManagerSignOff in tbl_posDayStartAndEnd_Detail.SelectAllByDayIndex(oBranchDayEnd.DayIndex))
                                    {
                                        if (bCounterSelected && oCashierSignIn_ManagerSignOff.PosTerminal_ID != txtCounter.Tag.ToString())
                                            continue;

                                        if (bCashierSelected && oCashierSignIn_ManagerSignOff.SignInCashier_ID != txtCashier.Tag.ToString())
                                            continue;

                                        decimal dCashCollection = 0, dChequeCollection = 0, dCreditCardCollection = 0, dGiftVoucherCollection = 0, dTotCollection = 0, cashReturned = 0, cashInHand = 0, floatBalance = 0, floatInHand = 0, floatReturned = 0, cashWithCashier = 0;
                                        decimal dCRN_fromReturn_Collection = 0, dAdvance_Collection = 0;
                                        string cashReceivedBy = "", floatreceivedBy = "";

                                        /* To Do : Session Management
                                         * No session management yet
                                         * Assume One Treminal has one cashier per day
                                         */
                                        #region POS Transactions
                                        var vPoSTxs = tbl_posTransaction.SelectAllByDayDetail_Index(oCashierSignIn_ManagerSignOff.DayDetail_Index).Where(r => !r.IsIncompleted && !r.IsDeleted);
                                        if (vPoSTxs.Count() < 1)
                                            continue;

                                        foreach (tbl_posTransaction oPoSTx in vPoSTxs)
                                        {
                                            if (bCustomerSelected && oPoSTx.Customer_ID != txtCustomer.Tag.ToString())
                                                continue;

                                            foreach (var oPaymentReg in tbl_bpsChequeRegister.SelectAll().Where(r => r.PosTransaction_ID == oPoSTx.PosTransaction_Index.ToString() && r.DateRegister.Date == dtmDate.Date))
                                            {
                                                switch (oPaymentReg.PaymentMethod_ID)
                                                {
                                                    case ((int)PaymentMethod.Cash):
                                                        dCashCollection += oPaymentReg.Amount;        //Cash Collection  
                                                        break;
                                                    case ((int)PaymentMethod.Gift_Voucher):
                                                        dGiftVoucherCollection += oPaymentReg.Amount; //Gift Voucher Collection  
                                                        break;
                                                    case ((int)PaymentMethod.Card):
                                                        dCreditCardCollection += oPaymentReg.Amount;  //Card Collection  
                                                        break;
                                                    case ((int)PaymentMethod.Cheque):
                                                        dChequeCollection += oPaymentReg.Amount;      //Cheque Collection  
                                                        break;
                                                    case ((int)PaymentMethod.Credit_Note):
                                                        dCRN_fromReturn_Collection += oPaymentReg.Amount; //Sales Return Credit Notes  
                                                        break;
                                                    case ((int)PaymentMethod.Advance_Receive):
                                                        dAdvance_Collection += oPaymentReg.Amount;         //POS Advance  
                                                        break;
                                                }
                                            }
                                        }
                                        #endregion

                                        #region POS Advance 
                                        var vPoS_Advances = tbl_posAdvanceReceived.SelectAllByCompanyBranchID(txtBranch.Tag.ToString()).Where(r => r.DateCreate.Date == oCashierSignIn_ManagerSignOff.MgtSignOffApprovedTime.Date && !r.IsCanceled && !r.IsIncompleted);
                                        foreach (tbl_posAdvanceReceived vPoS_Advance in vPoS_Advances)
                                        {
                                            if (bCustomerSelected && vPoS_Advance.Customer_ID != txtCustomer.Tag.ToString())
                                                continue;

                                            foreach (var oPaymentReg in tbl_bpsChequeRegister.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(r => r.AdvanceReceived_Index == vPoS_Advance.AdvanceReceived_Index && r.DateRegister.Date == dtmDate.Date))
                                            {
                                                switch (oPaymentReg.PaymentMethod_ID)
                                                {
                                                    case ((int)PaymentMethod.Cash):
                                                        dCashCollection += oPaymentReg.Amount;        //Cash Collection  
                                                        break;
                                                    case ((int)PaymentMethod.Gift_Voucher):
                                                        dGiftVoucherCollection += oPaymentReg.Amount; //Gift Voucher Collection  
                                                        break;
                                                    case ((int)PaymentMethod.Card):
                                                        dCreditCardCollection += oPaymentReg.Amount;  //Card Collection  
                                                        break;
                                                    case ((int)PaymentMethod.Cheque):
                                                        dChequeCollection += oPaymentReg.Amount;      //Cheque Collection  
                                                        break;
                                                    case ((int)PaymentMethod.Credit_Note):
                                                        dCRN_fromReturn_Collection += oPaymentReg.Amount; //Sales Return Credit Notes  
                                                        break;
                                                    case ((int)PaymentMethod.Advance_Receive):
                                                        dAdvance_Collection += oPaymentReg.Amount;         //POS Advance  
                                                        break;
                                                }
                                            }
                                        }
                                        #endregion

                                        dTotCollection = dCashCollection + dCreditCardCollection + dGiftVoucherCollection + dChequeCollection + dCRN_fromReturn_Collection + dAdvance_Collection; //Total Sales

                                        var dCashOuts = tbl_posDayStartAndEnd_Detail_CashWithdrawal.SelectAllByDayDetail_Index(oCashierSignIn_ManagerSignOff.DayDetail_Index);
                                        cashReturned = oCashierSignIn_ManagerSignOff.DayEndCashAmt + dCashOuts.Count > 0 ? dCashOuts.Sum(r => r.Amount) : 0;// Cash return in day end
                                        cashReceivedBy = clsGenaralName.getName_User(oCashierSignIn_ManagerSignOff.ApprovedUser_ID);// "cash received";//Person who handover the returned cash
                                        cashInHand = dCashCollection - cashReturned;

                                        floatBalance = 0;
                                        floatInHand = oCashierSignIn_ManagerSignOff.SignInFloatAmt;
                                        floatreceivedBy = clsGenaralName.getName_User(oCashierSignIn_ManagerSignOff.SignInCashier_ID); //"float received";//Person who handover the returned float
                                        floatReturned = 0;

                                        cashWithCashier = dCashCollection + floatInHand - floatReturned;

                                        glb_dtsPosStd.dt_DailyCashBalance.Adddt_DailyCashBalanceRow(
                                            oBranchMaster.CompanyBranch_ID,
                                            oCashierSignIn_ManagerSignOff.PosTerminal_ID,
                                            oCashierSignIn_ManagerSignOff.SignInCashier_ID, clsGenaralName.getName_User(oCashierSignIn_ManagerSignOff.SignInCashier_ID),
                                            oCashierSignIn_ManagerSignOff.DayDetail_Index, "From " + oCashierSignIn_ManagerSignOff.DateCreated.ToString(cls_Formater.Format_Time) + " To " + oCashierSignIn_ManagerSignOff.MgtSignOffApprovedTime.ToString(cls_Formater.Format_Time),
                                            dtmDate.Date,
                                            dCashCollection, dCreditCardCollection, dChequeCollection, dCRN_fromReturn_Collection, dAdvance_Collection, dGiftVoucherCollection, dTotCollection, cashReturned,
                                            cashReceivedBy, cashInHand, floatBalance, floatInHand, floatReturned, floatreceivedBy, cashWithCashier, oBranchMaster.BranchName,
                                            oCashierSignIn_ManagerSignOff.MgtSignOffApprovedUser_ID, clsGenaralName.getName_User(oCashierSignIn_ManagerSignOff.MgtSignOffApprovedUser_ID));
                                    }
                                }
                            }
                            #endregion

                            frm_ReportViewer rpt = new frm_ReportViewer();
                            rpt.print(oReport.ReportPath, glb_dtsPosStd, glb_dtsReportExport.dt_rptParameter, oPermission);
                        }
                        #endregion

                        #region POS_Daily Sales Detail Report
                        else if (iReportID == (int)(enum_ReportName.POS_DailySalesDetail))
                        {
                            #region Set company Details
                            tbl_genCompanyBranchMaster oBranchMaster = tbl_genCompanyBranchMaster.Select(txtBranch.Tag.ToString());
                            CompanyImages oComImages = clsCommon_POS.getCompanyImages();
                            glb_dtsDailySales.dt_company.Adddt_companyRow(
                                clsSecurity.DigiteqName,
                                clsSecurity.DigiteqEmail,
                                clsSecurity.CompanyName,
                                clsSecurity.CompanyAddress1,
                                clsSecurity.CompanyAddress2,
                                oComImages.CompanyImage1,
                                oComImages.CompanyImage2,
                                oComImages.CompanyImage3,
                                oReport.DisplayName,
                                oReport.DisplayName2,
                                sDaterange,
                                clsSecurity.UserNameLoged,
                                sFilter,
                                clsCommon.getCompanyBusinessRegisterNo(),
                                clsCommon.getCompanyVAT(),
                                ("BRANCH :" + oBranchMaster.BranchName.ToUpper()),
                                oBranchMaster.Adress.ToUpper(),
                                ("TEL: " + oBranchMaster.Telephone.ToUpper() + " FAX: " + oBranchMaster.Fax.ToUpper())
                                );
                            #endregion

                            #region Same Day Transaction
                            tbl_posDayStartAndEnd oPosDay = tbl_posDayStartAndEnd.SelectAllByCompanyBranch_ID(clsSecurity.BranchID).FirstOrDefault(r => r.IsApproved && r.DateCreated.Date == dtmToDate.Date);
                            if (oPosDay != null)
                            {
                                decimal dTotalFloat = 0m;

                                foreach (tbl_posDayStartAndEnd_Detail oPosDay_Session in tbl_posDayStartAndEnd_Detail.SelectAllByDayIndex(oPosDay.DayIndex))
                                {
                                    #region Filters
                                    if (bCounterSelected && txtCounter.Tag.ToString() != oPosDay_Session.PosTerminal_ID)
                                        continue;
                                    if (bCashierSelected && txtCashier.Tag.ToString() != oPosDay_Session.SignInCashier_ID)
                                        continue;
                                    #endregion

                                    dTotalFloat += oPosDay_Session.SignInFloatAmt;
                                    glb_dtsDailySales.dt_posDayStartEnd_detail.Adddt_posDayStartEnd_detailRow(oPosDay_Session.DayIndex, oPosDay_Session.DayDetail_Index, oPosDay_Session.PosDate, oPosDay_Session.PosTerminal_ID, oPosDay_Session.SignInCashier_ID, clsGenaralName.getName_User(oPosDay_Session.SignInCashier_ID), oPosDay_Session.SignInFloatAmt, oPosDay_Session.ApprovedUser_ID, clsGenaralName.getName_User(oPosDay_Session.ApprovedUser_ID));

                                    foreach (tbl_posDayStartAndEnd_Detail_CashWithdrawal oCashOut in tbl_posDayStartAndEnd_Detail_CashWithdrawal.SelectAllByDayDetail_Index(oPosDay_Session.DayDetail_Index))
                                    {
                                        glb_dtsDailySales.dt_posDayStartEnd_detail_cashOut.Adddt_posDayStartEnd_detail_cashOutRow(oCashOut.DayDetail_Index, oCashOut.Withdrawal_Time, oCashOut.Amount, oCashOut.Remark);
                                    }

                                    foreach (tbl_posTransaction oTx in tbl_posTransaction.SelectAllByDayDetail_Index(oPosDay_Session.DayDetail_Index).Where(r => !r.IsDeleted))
                                    {
                                        #region Filters
                                        if (bCustomerSelected && txtCustomer.Tag.ToString() != oTx.Customer_ID)
                                            continue;
                                        #endregion

                                        glb_dtsDailySales.dt_pos_transaction.Adddt_pos_transactionRow(
                                            oTx.PosTransaction_ID,
                                            oTx.PosTransactiondate,
                                            oTx.Remark,
                                            oTx.Customer_ID,
                                            clsGenaralName.getName_Customer(oTx.Customer_ID),
                                            oTx.Store_ID,
                                            clsGenaralName.getName_Store(oTx.Store_ID),
                                            "",
                                            oTx.Currency_ID,
                                            clsGenaralName.getName_CurrencyCode(oTx.Currency_ID),
                                            oTx.CurrencyRate,
                                            oTx.DiscountPercentage,
                                            oTx.NbtPercentage,
                                            oTx.VatPercentage,
                                            oTx.OtherTaxPercentage,
                                            oTx.SubTotal,
                                            oTx.DiscountTotal,
                                            oTx.NbtTotal,
                                            oTx.VatTotal,
                                            oTx.OtherTaxTotal,
                                            oTx.GrandTotal,
                                            oTx.CreateUser_ID,
                                            clsGenaralName.getName_CompanyBranchMaster(oTx.CompanyBranch_ID), //Branch
                                            oTx.CreateTerminal_ID, //Terminal
                                            clsGenaralName.getName_User(oTx.CreateUser_ID), oTx.DayDetail_Index, !oTx.IsSeattled
                                            );

                                        foreach (tbl_posTransaction_Detail oTx_detail in tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(oTx.PosTransaction_Index).OrderBy(p => p.Line_No))
                                        {
                                            glb_dtsDailySales.dt_pos_transation_details.Adddt_pos_transation_detailsRow(oTx_detail.Line_No, clsGenaralName_POS.getPoS_ID_From_PoS_Index(oTx_detail.PosTransaction_Index),
                                                oTx_detail.Item_ID, clsGenaralName.getName_Item(oTx_detail.Item_ID), oTx_detail.Remark, clsGenaralName.getName_ItemUOM(oTx_detail.Item_ID),
                                                oTx_detail.Qty, oTx_detail.Weight, oTx_detail.UnitPrice, oTx_detail.WeightPrice, oTx_detail.NetAmount, oTx_detail.LineDiscountPresentage,
                                                oTx_detail.LineDiscountTotal, oTx_detail.GrossAmount);
                                        }

                                        foreach (tbl_posReceipt oTx_Receipt in tbl_posReceipt.SelectAllByPosTransaction_Index(oTx.PosTransaction_Index))
                                        {
                                            glb_dtsDailySales.dt_pos_receipt.Adddt_pos_receiptRow(oTx.PosTransaction_ID,
                                                oTx_Receipt.PosReceipt_ID, oTx_Receipt.PosReceiptDate, oTx_Receipt.TenderedAmount,
                                                oTx_Receipt.PosTxBalanceAmount, oTx_Receipt.TotalAmount, oTx_Receipt.IsAdvance, oTx_Receipt.IsPartPayment, oTx_Receipt.IsFullPayment);

                                            foreach (tbl_bpsChequeRegister oPaymentReg in tbl_bpsChequeRegister.SelectAllByPosReceipt_ID(oTx_Receipt.PosReceipt_ID))
                                            {
                                                string sValue = "";
                                                switch (oPaymentReg.PaymentMethod_ID)
                                                {
                                                    case (int)PaymentMethod.Card:
                                                        sValue = ((PaymentMethod)oPaymentReg.PaymentMethod_ID).ToString() + (oPaymentReg.Amount > 0 ? " Paid" : " Balance") + " " + clsSecurity.decryptPassword(oPaymentReg.LastFourDigits) + " - " + clsSecurity.decryptPassword(oPaymentReg.CardOwnerName);
                                                        break;
                                                    case (int)PaymentMethod.Cheque:
                                                        sValue = ((PaymentMethod)oPaymentReg.PaymentMethod_ID).ToString() + (oPaymentReg.Amount > 0 ? " Paid" : " Balance") + " " + oPaymentReg.ChequeNumber + " - " + clsGenaralName.getName_Bank(oPaymentReg.Bank_ID);
                                                        break;
                                                    case (int)PaymentMethod.Gift_Voucher:
                                                        sValue = clsGenaralName_POS.getName_Customer(oTx.Customer_ID);
                                                        break;
                                                }

                                                glb_dtsDailySales.dt_pos_receipt_payment.Adddt_pos_receipt_paymentRow(
                                                    oPaymentReg.PosTransaction_ID,
                                                    oPaymentReg.Receipt_ID,
                                                    oPaymentReg.ChequeRegister_ID,
                                                    oPaymentReg.PaymentMethod_ID,
                                                    sValue,
                                                    ((BankTransferTypes)oPaymentReg.TransferType).ToString(),
                                                    clsGenaralName_POS.getGiftVoucherSerial_From_ID(oPaymentReg.GiftVoucherID),
                                                    ((PaymentCardTypes)oPaymentReg.CardType).ToString(),
                                                    oPaymentReg.Amount);
                                            }
                                        }
                                    }
                                }

                                glb_dtsDailySales.dt_posDayStartEnd.Adddt_posDayStartEndRow(oPosDay.DayIndex, oPosDay.DateCreated, oPosDay.CompanyBranch_ID, clsGenaralName.getName_CompanyBranchMaster(oPosDay.CompanyBranch_ID), dTotalFloat);
                            }
                            #endregion

                            #region Fill Detail
                            foreach (tbl_posReceipt oPosReceipt in tbl_posReceipt.SelectAll().Where(r => r.PosReceiptDate.Date == dtmToDate.Date))
                            {
                                tbl_posTransaction oTranx = tbl_posTransaction.Select(oPosReceipt.PosTransaction_Index);
                                if (oTranx != null && oTranx.PosTransactiondate.Date < dtmToDate.Date)
                                {
                                    foreach (tbl_bpsChequeRegister oPayReg in tbl_bpsChequeRegister.SelectAllByPosReceipt_ID(oPosReceipt.PosReceipt_ID).Where(r => !r.IsDeleted))
                                    {
                                        if (oPayReg.PaymentMethod_ID == (int)PaymentMethod.Cash)
                                        {
                                            glb_dtsDailySales.dt_pos_paymentRecived_creditInvoice.Adddt_pos_paymentRecived_creditInvoiceRow(oTranx.PosTransaction_ID,
                                                clsGenaralName.getName_Customer(oTranx.Customer_ID),
                                                oPosReceipt.PosReceipt_ID,
                                                oTranx.PosTransactiondate,
                                                oPosReceipt.PosReceiptDate,
                                                oPayReg.Amount, true);
                                        }
                                        else
                                        {
                                            glb_dtsDailySales.dt_pos_paymentRecived_creditInvoice.Adddt_pos_paymentRecived_creditInvoiceRow(oTranx.PosTransaction_ID,
                                                clsGenaralName.getName_Customer(oTranx.Customer_ID),
                                                oPosReceipt.PosReceipt_ID,
                                                oTranx.PosTransactiondate,
                                                oPosReceipt.PosReceiptDate,
                                                oPayReg.Amount, false);
                                        }
                                    }
                                }
                            }
                            #endregion

                            frm_ReportViewer rpt = new frm_ReportViewer();
                            rpt.print(oReport.ReportPath, glb_dtsDailySales, glb_dtsReportExport.dt_rptParameter, oPermission);
                        }
                        #endregion

                        #region POS Transaction Summary Sales Rep Wise
                        else if (iReportID == (int)(enum_ReportName.POS_TransactionSummary_SalesRepWise))
                        {
                            #region Fill Details
                            List<tbl_posTransaction> oPosTrans = tbl_posTransaction.SelectAll().Where(p => !p.IsIncompleted && p.PosTransactiondate.Date >= dtmFromDate.Date && p.PosTransactiondate.Date <= dtmToDate.Date).ToList();

                            if (rdoCancelled.IsChecked.Value)
                                oPosTrans = oPosTrans.Where(r => r.IsDeleted).ToList();
                            else
                                oPosTrans = oPosTrans.Where(r => !r.IsDeleted).ToList();

                            foreach (tbl_posTransaction oPosTran in oPosTrans)
                            {
                                #region Selected Filters
                                if (rdoHold.IsChecked.Value && !oPosTran.IsHold)
                                    continue;

                                if (rdoCompleted.IsChecked.Value && oPosTran.IsHold)
                                    continue;

                                if (bCustomerSelected && txtCustomer.Tag.ToString() != oPosTran.Customer_ID)
                                    continue;

                                if (bSalesRepSelected && txtSalesRep.Tag.ToString() != oPosTran.SalesRep_ID)
                                    continue;
                                #endregion

                                glb_dtsPosStd.dt_pos_transaction.Adddt_pos_transactionRow(
                                    oPosTran.PosTransaction_ID,
                                    oPosTran.PosTransactiondate,
                                    oPosTran.Remark,
                                    oPosTran.Customer_ID != "default" ? oPosTran.Customer_ID : "-",
                                    clsGenaralName.getName_Customer(oPosTran.Customer_ID),
                                    oPosTran.Store_ID,
                                    clsGenaralName.getName_Store(oPosTran.Store_ID),
                                    oPosTran.OrderRefNo_ID != "default" ? oPosTran.OrderRefNo_ID : "-",
                                    oPosTran.Currency_ID,
                                    clsGenaralName.getName_CurrencyCode(oPosTran.Currency_ID),
                                    oPosTran.CurrencyRate,
                                    oPosTran.DiscountPercentage,
                                    oPosTran.NbtPercentage,
                                    oPosTran.VatPercentage,
                                    oPosTran.OtherTaxPercentage,
                                    oPosTran.SubTotal,
                                    oPosTran.DiscountTotal,
                                    oPosTran.NbtTotal,
                                    oPosTran.VatTotal,
                                    oPosTran.OtherTaxTotal,
                                    oPosTran.GrandTotal,
                                    oPosTran.CreateUser_ID,
                                    oPosTran.CompanyBranch_ID != null ? clsGenaralName.getName_CompanyBranchMaster(oPosTran.CompanyBranch_ID) : "-",
                                    oPosTran.CreateTerminal_ID,
                                    "",
                                    oPosTran.DayDetail_Index, oPosTran.SalesRep_ID, clsGenaralName.getName_SalesRep(oPosTran.SalesRep_ID)
                                    );
                            }
                            #endregion

                            #region Set company Details
                            tbl_genCompanyBranchMaster oBranchMaster = tbl_genCompanyBranchMaster.Select(txtBranch.Tag.ToString());
                            CompanyImages oComImages = clsCommon_POS.getCompanyImages();
                            glb_dtsPosStd.dt_Company.Adddt_CompanyRow(
                                clsSecurity.DigiteqName,
                                clsSecurity.DigiteqEmail,
                                clsSecurity.CompanyName,
                                clsSecurity.CompanyAddress1,
                                clsSecurity.CompanyAddress2,
                                oComImages.CompanyImage1,
                                oComImages.CompanyImage2,
                                oComImages.CompanyImage3,
                                oReport.DisplayName,
                                oReport.DisplayName2,
                                sDaterange,
                                clsSecurity.UserNameLoged,
                                sFilter,
                                clsCommon.getCompanyBusinessRegisterNo(),
                                clsCommon.getCompanyVAT(),
                                ("BRANCH :" + oBranchMaster.BranchName.ToUpper()),
                                oBranchMaster.Adress.ToUpper(),
                                ("TEL: " + oBranchMaster.Telephone.ToUpper() + " FAX: " + oBranchMaster.Fax.ToUpper())
                                );
                            #endregion

                            frm_ReportViewer rpt = new frm_ReportViewer();
                            rpt.print(oReport.ReportPath, glb_dtsPosStd, glb_dtsReportExport.dt_rptParameter, oPermission);
                        }
                        #endregion

                        #endregion

                        #region Register Reports
                        else
                        {
                            #region Filters
                            List<tbl_posTransaction> oPosTrans = tbl_posTransaction.SelectAll().Where(r => !r.IsIncompleted).ToList();
                            if (bCompanyBranchSelected)
                            {
                                oPosTrans = oPosTrans.Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString()).ToList();
                            }
                            if (bCounterSelected)
                            {
                                oPosTrans = oPosTrans.Where(p => p.CreateTerminal_ID == txtCounter.Tag.ToString()).ToList();
                            }
                            if (bCashierSelected)
                            {
                                oPosTrans = oPosTrans.Where(p => p.CreateUser_ID == txtCashier.Tag.ToString()).ToList();
                            }
                            if (bCustomerSelected)
                            {
                                oPosTrans = oPosTrans.Where(p => p.Customer_ID == txtCustomer.Tag.ToString()).ToList();
                            }
                            #endregion

                            #region Set company Details
                            tbl_genCompanyBranchMaster oBranchMaster = tbl_genCompanyBranchMaster.Select(clsSecurity.BranchID);
                            CompanyImages oComImages = clsCommon_POS.getCompanyImages();
                            glb_dtsPosStd.dt_Company.Adddt_CompanyRow(
                                clsSecurity.DigiteqName,
                                clsSecurity.DigiteqEmail,
                                clsSecurity.CompanyName,
                                clsSecurity.CompanyAddress1,
                                clsSecurity.CompanyAddress2,
                                oComImages.CompanyImage1,
                                oComImages.CompanyImage2,
                                oComImages.CompanyImage3,
                                oReport.DisplayName,
                                oReport.DisplayName2,
                                sDaterange,
                                clsSecurity.UserNameLoged,
                                sFilter,
                                clsCommon.getCompanyBusinessRegisterNo(),
                                clsCommon.getCompanyVAT(),
                                ("BRANCH :" + oBranchMaster.BranchName.ToUpper()),
                                oBranchMaster.Adress.ToUpper(),
                                ("TEL: " + oBranchMaster.Telephone.ToUpper() + " FAX: " + oBranchMaster.Fax.ToUpper())
                                );
                            #endregion

                            #region Register Reports Summary and Detailed Reports
                            if (rdoCancelled.IsChecked.Value)
                                oPosTrans = oPosTrans.Where(r => r.IsDeleted).ToList();
                            else
                                oPosTrans = oPosTrans.Where(r => !r.IsDeleted).ToList();

                            if (iReportID == (int)(enum_ReportName.POS_TransactionSummary) || iReportID == (int)(enum_ReportName.POS_TransactionDetail))
                            {
                                #region POS Transactions
                                foreach (tbl_posTransaction oPosTran in oPosTrans.Where(p => p.PosTransactiondate >= dtmFromDate.Date && p.PosTransactiondate <= dtmToDate.Date.AddDays(1)))
                                {
                                    if (rdoHold.IsChecked.Value && !oPosTran.IsHold)
                                        continue;

                                    if (rdoCompleted.IsChecked.Value && oPosTran.IsHold)
                                        continue;

                                    if (sReportID == (clsAutocode.getReportID(enum_ReportName.POS_TransactionDetail)))
                                    {
                                        #region posTransaction_Detail
                                        List<tbl_posTransaction_Detail> details = tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(oPosTran.PosTransaction_Index).OrderBy(p => p.Line_No).ToList();
                                        foreach (tbl_posTransaction_Detail detail in details)
                                        {
                                            glb_dtsPosStd.dt_pos_transation_details.Adddt_pos_transation_detailsRow(detail.Line_No,
                                                clsGenaralName_POS.getPoS_ID_From_PoS_Index(detail.PosTransaction_Index),
                                                detail.Item_ID,
                                                "",
                                                "",
                                                "",
                                                "",
                                                "0",
                                                "0",
                                                clsGenaralName.getName_Item(detail.Item_ID),
                                                detail.Remark,
                                                clsGenaralName.getName_ItemUOM(detail.Item_ID),
                                                detail.Qty,
                                                detail.Weight,
                                                detail.UnitPrice,
                                                detail.WeightPrice,
                                                detail.NetAmount,
                                                detail.LineDiscountPresentage,
                                                detail.LineDiscountTotal,
                                                detail.GrossAmount);
                                        }
                                        #endregion
                                    }

                                    glb_dtsPosStd.dt_pos_transaction.Adddt_pos_transactionRow(
                                        oPosTran.PosTransaction_ID,
                                        oPosTran.PosTransactiondate,
                                        oPosTran.Remark,
                                        oPosTran.Customer_ID != "default" ? oPosTran.Customer_ID : "-",
                                        clsGenaralName.getName_Customer(oPosTran.Customer_ID),
                                        oPosTran.Store_ID,
                                        clsGenaralName.getName_Store(oPosTran.Store_ID),
                                        oPosTran.OrderRefNo_ID != "default" ? oPosTran.OrderRefNo_ID : "-",
                                        oPosTran.Currency_ID,
                                        clsGenaralName.getName_CurrencyCode(oPosTran.Currency_ID),
                                        oPosTran.CurrencyRate,
                                        oPosTran.DiscountPercentage,
                                        oPosTran.NbtPercentage,
                                        oPosTran.VatPercentage,
                                        oPosTran.OtherTaxPercentage,
                                        oPosTran.SubTotal,
                                        oPosTran.DiscountTotal,
                                        oPosTran.NbtTotal,
                                        oPosTran.VatTotal,
                                        oPosTran.OtherTaxTotal,
                                        oPosTran.GrandTotal,
                                        oPosTran.CreateUser_ID,
                                        oPosTran.CompanyBranch_ID != null ? clsGenaralName.getName_CompanyBranchMaster(oPosTran.CompanyBranch_ID) : "-",
                                        oPosTran.CreateTerminal_ID,
                                        "",
                                        oPosTran.DayDetail_Index, "", ""
                                        );
                                }
                                #endregion
                            }
                            #endregion

                            #region Free Item Report
                            if (iReportID == (int)(enum_ReportName.POS_FreeItemReport))
                            {
                                foreach (tbl_posTransaction oPosTran in oPosTrans.Where(p => p.PosTransactiondate >= dtmFromDate.Date && p.PosTransactiondate <= dtmToDate.Date.AddDays(1) && !p.IsDeleted))
                                {
                                    foreach (tbl_posTransaction_Detail detail in tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(oPosTran.PosTransaction_Index).Where(r => r.BIsFreeItem).OrderBy(p => p.Line_No))
                                    {
                                        glb_dtsPosStd.dt_discountedItem.Adddt_discountedItemRow(oPosTran.PosTransaction_ID, oPosTran.PosTransactiondate, oPosTran.Customer_ID, clsGenaralName.getName_Customer(oPosTran.Customer_ID), detail.Item_ID, clsGenaralName.getName_Item(detail.Item_ID), detail.Qty, clsGenaralName.getName_ItemUOM(detail.Item_ID), detail.UnitPrice, detail.LineDiscountPresentage, detail.LineDiscountTotal, detail.BIsFreeItem, detail.NetAmount);
                                    }
                                }
                            }
                            #endregion

                            frm_ReportViewer rpt = new frm_ReportViewer();
                            rpt.print(oReport.ReportPath, glb_dtsPosStd, glb_dtsReportExport.dt_rptParameter, oPermission);
                        }
                        #endregion
                    }
                }
                else
                {
                    SEACCMessageBox.Show("No Report Selected... ", "You haven't selected a report. \n Please, Select the report...", MessageBoxButton.OK, "Red");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            finally
            {
                glb_dtsPosStd.dt_Company.Rows.Clear();
                glb_dtsPosStd.dt_pos_transaction.Clear();
                Cursor = Cursors.Arrow;
            }
        }

        //Clear Button
        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            dgv_Reports.UnselectAll();
        }

        #endregion

        #region Search Events
        private void txtCustomer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearchForm RowDataSearch = new frmSearchForm();
            List<string> lstResult = RowDataSearch.Show(Search.Pos_CustomersWithBranches);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomer.Tag = lstResult[0];
                txtCustomer.Text = lstResult[2];
            }
        }

        private void txtBranch_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearchForm RowDataSearch = new frmSearchForm();
            List<string> lstResult = RowDataSearch.Show(Search.Pos_ShopBranches);

            if (RowDataSearch.DialogResult == true)
            {
                txtBranch.Text = lstResult[1];
                txtBranch.Tag = lstResult[0];
            }
        }

        private void txtCashier_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearchForm RowDataSearch = new frmSearchForm();
            List<string> lstResult = RowDataSearch.Show(Search.Users);

            if (RowDataSearch.DialogResult == true)
            {
                txtCashier.Tag = lstResult[0];
                txtCashier.Text = lstResult[1];
            }
        }

        private void txtTerminl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearchForm RowDataSearch = new frmSearchForm();
            List<string> lstResult = RowDataSearch.Show(Search.Counter);

            if (RowDataSearch.DialogResult == true)
            {
                txtCounter.Tag = lstResult[0];
                txtCounter.Text = lstResult[1];
            }
        }
        private void txtSalesRep_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearchForm RowDataSearch = new frmSearchForm();
            List<string> lstResult = RowDataSearch.Show(Search.SalesRep);

            if (RowDataSearch.DialogResult == true)
            {
                txtSalesRep.Tag = lstResult[0];
                txtSalesRep.Text = lstResult[1];
            }
        }
        #endregion

        #region Grid Event
        private void dgv_Reports_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DataRowView item = (sender as DataGrid).SelectedItem as DataRowView;
                if (item != null)
                {
                    object[] obj = item.Row.ItemArray;
                    string iReportID = (obj[0].ToString());

                    rdoCompleted.IsChecked = true;

                    #region POS_DailyCollectionReport
                    if (iReportID == (clsAutocode.getReportID(enum_ReportName.POS_DailyCollectionReport)))
                    {
                        txtCustomer.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        txtCustomer.Visibility = Visibility.Visible;
                    }
                    #endregion

                    #region POS_TransactionSummary_SalesRepWise
                    if (iReportID == (clsAutocode.getReportID(enum_ReportName.POS_TransactionSummary_SalesRepWise)))
                    {
                        txtSalesRep.Visibility = Visibility.Visible;
                        txtCustomer.Visibility = Visibility.Visible;

                        txtCounter.Visibility = Visibility.Collapsed;
                        txtCashier.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        txtSalesRep.Visibility = Visibility.Collapsed;
                        txtCounter.Visibility = Visibility.Visible;
                        txtCashier.Visibility = Visibility.Visible;
                    }
                    #endregion

                    #region POS_DailySalesDetail
                    if (iReportID == (clsAutocode.getReportID(enum_ReportName.POS_DailySalesDetail)))
                    {
                        dtp_FromDate.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        dtp_FromDate.Visibility = Visibility.Visible;
                    }
                    #endregion


                    if (iReportID == (clsAutocode.getReportID(enum_ReportName.POS_TransactionSummary)) || iReportID == (clsAutocode.getReportID(enum_ReportName.POS_TransactionDetail)) ||
                        iReportID == (clsAutocode.getReportID(enum_ReportName.POS_TransactionSummary_SalesRepWise)))
                    {
                        stkPOSTx_Types.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        stkPOSTx_Types.Visibility = Visibility.Collapsed;
                    }
                }
            }
            catch { }
        }
        #endregion
    }
}
