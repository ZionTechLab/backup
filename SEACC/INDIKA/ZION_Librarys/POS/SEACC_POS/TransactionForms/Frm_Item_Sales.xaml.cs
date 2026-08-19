using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using DataTire;
using System.Data;
using SEACC_WPFControls;
using Digiteq_Logic;
using SEACC_POS.Search_Forms;
using SEACC_POS.DataSet;
using SEACC_POS.Reports;
using SEACC_POS.Controls;
using Ext_Digiteq_Logic;
using Digiteq_Logic_POS;
using SEACC_POS.Common;

namespace SEACC_POS
{
    public partial class Frm_Item_Sales : Window
    {
        #region Class Variables 
        //Gift Voucher Sales Mode
        private bool bGiftVoucher_SalesMode = false;

        //PoS Session Index
        private int iPoS_session_dayDetail_Index;

        //Validation Variables
        private string sField_ValidityMsg = "";
        private string sPrevCellVal = "";

        private string sPOS_Store_ID = string.Empty;

        //Sales Item Table
        private DataTable dt_Item = new DataTable();

        //Payment Window (This is completely tightly coupled with POS Sales Window)
        private Frm_PosPayment_Sales ofrmPosPayment = new Frm_PosPayment_Sales();

        //Cash Customer ID
        private string sBranch_CashCustomer = "default";
        #endregion

        #region Form Load
        public Frm_Item_Sales(int iSession_dayDetail_Index)
        {
            #region Initialize Form
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.POS_Transaction;
            SEACC_Form.Initialize();

            //Sesion Initialization
            this.iPoS_session_dayDetail_Index = iSession_dayDetail_Index;

            //Permission Check
            if (!SEACC_Form.PermissionTO_Read)
                return;

            //Load POS Main Store For Logged Branch
            tbl_genStoreMaster oBranchMainStore = tbl_genStoreMaster.SelectAllByCompanyBranch_ID(clsSecurity.BranchID).Where(p => !p.IsDeleted && p.IsMainStore).ToList().FirstOrDefault();
            if (oBranchMainStore != null)
            {
                sPOS_Store_ID = oBranchMainStore.Store_ID;
                ucItemSearch.lstItemFilterParameter.Add(sPOS_Store_ID);
            }

            //Hide 0 Qty Item - Celcius
            if (clsConfig_POS.bHide_ZeroQty_Items)
                ucItemSearch.lstItemFilterParameter.Add("S.qty > 0");
            else
                ucItemSearch.lstItemFilterParameter.Add("S.qty < 1000000");

            //Load Gift Vouchers for logged branch
            ucGiftVoucherSearch.lstItemFilterParameter.Add(clsSecurity.BranchID);

            #region Search Initialize
            ucItemSearch.Refresh_Search(Search.Pos_ItemSearch_Main);

            ucGiftVoucherSearch.Refresh_Search(Search.Pos_GiftVouchers_NotIssued);
            ucGiftVoucherSearch.pbxImage.Visibility = Visibility.Collapsed;
            #endregion

            //Set Cashier 
            usrIndicator.UserName = clsSecurity.UserNameLoged;
            R2logoSoftware.lblsoftwareName.Content = clsConfig.sPoS_SystemName;

            if (clsConfig_POS.bSalesReturn_Hide_POSTx_Window)
            {
                dgrItems.Columns[11].Visibility = Visibility.Collapsed;
                dgrItems.Columns[12].Visibility = Visibility.Collapsed;
            }
            #endregion

            #region Initialize Data Table
            dt_Item.Columns.Add("LineNo");
            dt_Item.Columns.Add("ItemCode");
            dt_Item.Columns.Add("Desc");
            dt_Item.Columns.Add("UOM");
            dt_Item.Columns.Add("Qty", typeof(string));
            dt_Item.Columns.Add("Weight", typeof(decimal));
            dt_Item.Columns.Add("IsFreeItem", typeof(string));
            dt_Item.Columns.Add("UnitPrice", typeof(decimal));
            dt_Item.Columns.Add("UnitPrice_Display", typeof(string));
            dt_Item.Columns.Add("WeightPrice", typeof(decimal));
            dt_Item.Columns.Add("WeightPrice_Display", typeof(string));
            dt_Item.Columns.Add("NetAmount", typeof(decimal));
            dt_Item.Columns.Add("NetAmount_Display", typeof(string));
            dt_Item.Columns.Add("LineDiscPresent", typeof(decimal));
            dt_Item.Columns.Add("LineDiscPresent_Display", typeof(decimal));
            dt_Item.Columns.Add("LineDiscAmount", typeof(decimal));
            dt_Item.Columns.Add("LineDiscAmount_Display", typeof(decimal));
            dt_Item.Columns.Add("AccumulatedAmount", typeof(decimal));
            dt_Item.Columns.Add("AccumulatedAmount_Display", typeof(string));
            dt_Item.Columns.Add("BilledOrRefund", typeof(string));
            dt_Item.Columns.Add("IsRefund", typeof(bool));
            dt_Item.Columns.Add("Remarks", typeof(string));
            dt_Item.Columns.Add("GiftVoucherID", typeof(int));
            dt_Item.Columns.Add("PreviousTrans_Index", typeof(string));//For Identifying Sales Return Transaction
            dt_Item.Columns.Add("PreviousTrans_Detail_LineNo", typeof(string));//For Identifying Sales Returns Transaction Item
            dt_Item.Columns.Add("PreviousTrans_ID_Dispaly", typeof(string));//For Diaplaying Purpose
            #endregion

            #region Transaction Action Buttons
            ofrmPosPayment.TransactionEnterAndTender += btnPaymentEnterTender_Click;
            ofrmPosPayment.TransactionSave += btnSave_Click;
            ofrmPosPayment.TransactionPrint += btnPrint_Click;
            ofrmPosPayment.PaymentSave += btnPosPayment_ReceiptSave_Click;
            ofrmPosPayment.MallRewards += btnMallRewardSend_Click;
            #endregion

            ClearFields();
        }
        #endregion

        #region Main Window Events

        private void GRD_Titlebar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                System.Windows.Forms.Screen Scr = System.Windows.Forms.Screen.FromPoint(System.Windows.Forms.Cursor.Position);

                WindowState = WindowState.Normal;
                Height = Scr.WorkingArea.Height;
                Width = Scr.WorkingArea.Width;

                Left = Scr.Bounds.Location.X;
                Top = Scr.Bounds.Location.Y;
                btnRestore.Content = "";
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            btnRestore.Content = "";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                System.Windows.Forms.Screen Scr = System.Windows.Forms.Screen.FromPoint(System.Windows.Forms.Cursor.Position);
                Height = Scr.WorkingArea.Height / 2;
                Width = Scr.WorkingArea.Width / 2;
                Left = Scr.Bounds.Location.X + Scr.Bounds.Width / 4;
                Top = Scr.Bounds.Location.Y + Scr.WorkingArea.Height / 4;
            }
            else
                WindowState = WindowState.Maximized;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        #region Window Key Press Events

        private void window_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F12)
            {
                if (ucItemSearch.IsEnabled)
                    ucItemSearch.txtFillter.Focus();
                else if (ucGiftVoucherSearch.IsEnabled)
                    ucGiftVoucherSearch.txtFillter.Focus();
            }
            else if (e.Key == Key.F11)
            {
                if (rdoItemSearch.IsChecked.Value)
                {
                    rdoGiftVoucherSearch.IsChecked = true;
                }
                else if (rdoGiftVoucherSearch.IsChecked.Value)
                {
                    rdoItemSearch.IsChecked = true;
                }
            }
            else if (e.Key == Key.F5)
            {
                btnClear_Click(null, null);
            }
            else if (e.Key == Key.Q && Keyboard.Modifiers == ModifierKeys.Control)
            {
                btnClose_Click(null, null);
            }
            else if (e.Key == Key.D && Keyboard.Modifiers == ModifierKeys.Control)
            {
                DiscountGrid_MouseLeftButtonUp(null, null);
                chkDisc1.IsChecked = true;
                txtDisc1Amount.Focus();
            }
            else if (e.Key == Key.E && Keyboard.Modifiers == ModifierKeys.Control)
            {
                ServiceChargeGrid_MouseLeftButtonUp(null, null);
                chkServiceCharge.IsChecked = true;
                txtServiceChargeAmount.Focus();
            }
            else if (e.Key == Key.A && Keyboard.Modifiers == ModifierKeys.Control)
            {
                grdPaymentsRow_MouseLeftButtonUp(null, null);
            }
            else if (e.Key == Key.S && Keyboard.Modifiers == ModifierKeys.Control)
            {
                dgrItems.CommitEdit(DataGridEditingUnit.Row, true);
                btnSave_Click(null, null);
            }
            else if (e.Key == Key.R && Keyboard.Modifiers == ModifierKeys.Control)
            {
                grd_Transaction_MouseDown(null, null);
            }
            else if (e.Key == Key.Escape)
            {
                pop_Discount.IsOpen = false;
                pop_ServiceCharges.IsOpen = false;
                ucItemSearch.pop_Detail.IsOpen = false;
                ucGiftVoucherSearch.pop_Detail.IsOpen = false;
            }
            else if (e.Key == Key.Delete)
            {
                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();
                CauculateNoOfItemsAndTotalQuantity();
            }
        }

        #endregion

        #endregion

        #region Action Buttons
        // New Button Click Event
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        // Delete / Cancel Transaction
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtTransactionID.Tag != null && txtTransactionID.Text != "<<Auto Generated>>")
                {
                    //cancel one record
                    Cursor = Cursors.Wait;
                    tbl_posTransaction oPosTrans = tbl_posTransaction.Select(int.Parse(txtTransactionID.Tag.ToString().Trim()));
                    if (oPosTrans != null)
                    {
                        tbl_posDayStartAndEnd_Detail oPos_Session = tbl_posDayStartAndEnd_Detail.Select(oPosTrans.DayDetail_Index);
                        tbl_posDayStartAndEnd oPos_Day = tbl_posDayStartAndEnd.Select(oPos_Session.DayIndex);
                        if (oPos_Day != null && !oPos_Day.IsApproved)
                        {
                            bool bNo_Return = true;
                            foreach (tbl_posTransaction_Detail oPOS_Detail in tbl_posTransaction_Detail.SelectAll().Where(r => r.PrevPosTx_Index == oPosTrans.PosTransaction_Index))
                            {
                                tbl_posTransaction oPosReturn = tbl_posTransaction.Select(oPOS_Detail.PrevPosTx_Index);
                                if (oPosReturn != null && !oPosReturn.IsDeleted)
                                {
                                    if (oPosReturn.IsReturnedPOS_Invoice)
                                    {
                                        bNo_Return = false;
                                        break;
                                    }
                                }
                            }

                            if (bNo_Return)
                            {
                                //tbl_posDayStartAndEnd_Detail oPos_Session = tbl_posDayStartAndEnd_Detail.Select(oPosTrans.DayDetail_Index);
                                //tbl_posDayStartAndEnd oPos_Day = tbl_posDayStartAndEnd.Select(oPos_Session.DayIndex);
                                if (oPos_Day != null && !oPos_Day.IsApproved)
                                {
                                    if (!oPosTrans.IsDeleted)
                                    {
                                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                                        if (bMessegeBoxResult)
                                        {
                                            frm_TwoStepVerification_UserChange frmTwoStepVerify = new frm_TwoStepVerification_UserChange((int)SEACC_Form.enmFormName, false, false, true);
                                            frmTwoStepVerify.ShowDialog();
                                            if (frmTwoStepVerify.bVerified)
                                            {
                                                foreach (tbl_posTransaction_Detail oDetail in tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(oPosTrans.PosTransaction_Index))
                                                    clsHelpMethods_POS.UpdateStock(sPOS_Store_ID, oDetail.Item_ID, oDetail.Qty);

                                                oPosTrans.DeletedUser_ID = frmTwoStepVerify.txtUsername.Tag.ToString();
                                                oPosTrans.DateDeleted = clsSecurity.getServerDateTime();
                                                oPosTrans.DeletedTerminal_ID = clsSecurity.TerminalID;
                                                oPosTrans.IsDeleted = true;
                                                oPosTrans.Update();

                                                foreach (tbl_posReceipt oReceipt in tbl_posReceipt.SelectAllByPosTransaction_Index(oPosTrans.PosTransaction_Index))
                                                {
                                                    foreach (tbl_bpsChequeRegister oPaymentReg in tbl_bpsChequeRegister.SelectAllByPosReceipt_ID(oReceipt.PosReceipt_ID))
                                                    {
                                                        oPaymentReg.IsDeleted = true;
                                                        oPaymentReg.DateModified = clsSecurity.getServerDateTime();
                                                        oPaymentReg.Update();

                                                        if (oPaymentReg.PaymentMethod_ID == (int)PaymentMethod.Gift_Voucher)
                                                        {
                                                            tbl_bpsGiftVoucher oGV = tbl_bpsGiftVoucher.Select(oPaymentReg.GiftVoucherID);
                                                            if (oGV != null)
                                                            {
                                                                oGV.IsRedeemed = false;
                                                                oGV.Update();
                                                            }
                                                        }
                                                        if (oPaymentReg.PaymentMethod_ID == (int)PaymentMethod.Credit_Note)
                                                        {
                                                            tbl_posTransaction oPOS_SRN = tbl_posTransaction.Select(oPaymentReg.PosReturnTransaction_Index);
                                                            if (oPOS_SRN != null)
                                                            {
                                                                foreach (tbl_bpsCreditNote oCRN in tbl_bpsCreditNote.SelectAllByPosReturnTransaction_Index(oPOS_SRN.PosTransaction_Index))
                                                                {
                                                                    oCRN.IsSeattled = false;
                                                                    oCRN.SeattleAmount = 0;
                                                                    oCRN.Update();
                                                                }

                                                                oPOS_SRN.IsSeattled = false;
                                                                oPOS_SRN.SeattleAmount = 0;
                                                                oPOS_SRN.Update();
                                                            }
                                                        }
                                                        if (oPaymentReg.PaymentMethod_ID == (int)PaymentMethod.Advance_Receive)
                                                        {
                                                            tbl_posAdvanceReceived oPOS_Advance = tbl_posAdvanceReceived.Select(oPaymentReg.AdvanceReceived_Index);
                                                            if (oPOS_Advance != null)
                                                            {
                                                                foreach (tbl_bpsCreditNote oCRN in tbl_bpsCreditNote.SelectAllByAdvanceReceived_Index(oPOS_Advance.AdvanceReceived_Index))
                                                                {
                                                                    oCRN.IsSeattled = false;
                                                                    oCRN.SeattleAmount = 0;
                                                                    oCRN.Update();
                                                                }

                                                                oPOS_Advance.IsSetteled = false;
                                                                oPOS_Advance.SetteledAmount = 0;
                                                                oPOS_Advance.Update();
                                                            }
                                                        }
                                                    }

                                                    oReceipt.IsDeleted = true;
                                                    oReceipt.DateModified = clsSecurity.getServerDateTime();
                                                    oReceipt.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                    oReceipt.Update();

                                                }

                                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                                ClearFields();
                                            }
                                        }
                                    }
                                    else
                                        SEACCMessageBox.Show(MessegeBoxType.CannotCancel_AlreadyCanceled);
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Can not Cancel..!", "Branch Day End has already been finished and approved", MessageBoxButton.OK, "Red");
                                }
                            }
                            else
                            {
                                SEACCMessageBox.Show("Can not Canceled..!", "POS Sales Return has been attached", MessageBoxButton.OK, "Red");
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

        // Bill Print
        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            Print(true);
        }

        // Save or Update Button Click
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SavePosHeader(false);
        }

        // Hold the Bill
        private void btnHold_Click(object sender, RoutedEventArgs e)
        {
            SavePosHeader(true);
        }

        // Enter & Tender Button Click
        private void btnPaymentEnterTender_Click(object sender, RoutedEventArgs e)
        {
            btnSave_Click(sender, e);
            if (txtTransactionID.Text.Length > 0 && txtTransactionID.Text != "<<Auto Generated>>")
                Print(false);
        }

        //One Galleface Mall Rewards
        private void btnMallRewardSend_Click(object sender, RoutedEventArgs e)
        {
            if (txtTransactionID.Tag != null)
            {
                tbl_posTransaction oTx = tbl_posTransaction.Select(int.Parse(txtTransactionID.Tag.ToString()));
                if (oTx != null)
                    clsOneGalleFaceUpload.SendTxDataforMallRewards(oTx.PosTransaction_ID, oTx.PosTransactiondate, oTx.GrandTotal);
            }
        }

        // POS Payment Saving
        private void btnPosPayment_ReceiptSave_Click(object sender, RoutedEventArgs e)
        {
            tbl_posTransaction oPosTransaction = tbl_posTransaction.Select(txtTransactionID.Text.Trim());
            string sPosReceiptId = "";

            if (ofrmPosPayment.txtReceipt_ID.TextBox1.Text != "")
            {
                tbl_posReceipt oReceipt = tbl_posReceipt.Select(ofrmPosPayment.txtReceipt_ID.TextBox1.Text);
                if (oReceipt != null)
                {
                    tbl_sasInvoice_Sattled.DeleteAllByPosReceipt_ID(oReceipt.PosReceipt_ID);
                    tbl_bpsChequeRegister.DeleteAllByPosReceipt_ID(oReceipt.PosReceipt_ID);
                    oReceipt.Delete();

                    sPosReceiptId = ofrmPosPayment.txtReceipt_ID.TextBox1.Text;
                }
            }
            else
            {
                int iPosReceiptCount = ofrmPosPayment.dgrPayment_Receipts.dt.Rows.Count;
                sPosReceiptId = "RCP/" + oPosTransaction.PosTransaction_Index.ToString("D8") + "/" + iPosReceiptCount;
            }

            //Balance Amount
            decimal dPosReceiptTenderedAmount = clsValidation.Validate_DecimalNumber(ofrmPosPayment.txtReceiptTenderedTotal.TextBox1.Text);
            decimal dPosTxBalanceAmount = clsValidation.Validate_DecimalNumber(ofrmPosPayment.txtReceiptBalance.TextBox1.Text);
            decimal dPosReceiptAmount = clsValidation.Validate_DecimalNumber(ofrmPosPayment.txtReceiptTenderedTotal.TextBox1.Text);
            decimal dChangeAmount = 0;
            if (dPosTxBalanceAmount > 0)
                dChangeAmount = dPosTxBalanceAmount;
            dPosReceiptAmount = dPosReceiptAmount - dChangeAmount;

            tbl_posReceipt oPosReceipt = new tbl_posReceipt(sPosReceiptId, clsSecurity.getServerDateTime(),
                oPosTransaction.PosTransaction_Index, "",
                ofrmPosPayment.txtCustomerName.Tag.ToString(), "default", "default", "default",
                clsSecurity.FinancialYearID, "default", lblCurrencyCode.Tag.ToString(),
                clsValidation.Validate_DecimalNumber(lblCurrencyRate.Text.Trim()),
                (clsValidation.Validate_DecimalNumber(ofrmPosPayment.txtCashPaymentstotal.TextBox1.Text) - dChangeAmount),
                clsValidation.Validate_DecimalNumber(ofrmPosPayment.txtChequesAmountTotal.TextBox1.Text),
                dPosReceiptAmount,
                clsCommon.CurrencyToWord(dPosReceiptAmount),
                dPosReceiptTenderedAmount,
                dPosTxBalanceAmount,
                dChangeAmount,
                clsSecurity.UserIDLoged,
                "default",
                "default",
                "default",
                "default",
                clsSecurity.getServerDateTime(),
                clsValidation.defaultDateTime,
                clsValidation.defaultDateTime,
                clsValidation.defaultDateTime,
                clsValidation.defaultDateTime,
                false,
                false,
                false,
                false,
                false,
                0, //Print Count
                ofrmPosPayment.rdoPartPayment.IsChecked == true,
                ofrmPosPayment.rdoFullPayment.IsChecked == true,
                ofrmPosPayment.rdoAdavancePayment.IsChecked == true,
                false, 0, false,
                clsSecurity.CompanyID, clsSecurity.BranchID, (-1));
            oPosReceipt.Insert();

            SavePosPaymentRegisterDetails_Receipt(oPosReceipt);

            #region Settlement Update
            var vPosTXs = tbl_posReceipt.SelectAllByPosTransaction_Index(oPosTransaction.PosTransaction_Index);
            decimal dSettledAmount = 0;
            foreach (var vReceipt in vPosTXs)
            {
                if (vReceipt != null && !vReceipt.IsDeleted)
                    dSettledAmount += vReceipt.TotalAmount;
            }
            oPosTransaction.SeattleAmount = dSettledAmount;
            oPosTransaction.Update();
            #endregion

            ofrmPosPayment.FillDetails_PosReceipts(oPosTransaction);
        }

        private void Print(bool bPrintPreview_Display)
        {
            BillPrint glb_dtsBillPrinting = new BillPrint();

            if (!clsConfig_POS.bPOSBillPrint_UsingReportWriter)
            {
                #region Crystal Report Bill
                try
                {
                    string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";

                    if (clsHelpMethods_POS.GetReportPath((int)enum_ReportName.POS_Bill_NotePrint, ofrmPosPayment.chkDefaultReportPrint.IsChecked.Value, ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                    {
                        glb_dtsBillPrinting.dt_Company.Rows.Clear();
                        glb_dtsBillPrinting.dt_pos_transaction.Rows.Clear();
                        glb_dtsBillPrinting.dt_pos_transation_details.Rows.Clear();
                        glb_dtsBillPrinting.dt_pos_receipt.Rows.Clear();

                        string sDuplicateCopy = "";

                        if (sReportPath.Length == 3)
                            return;


                        tbl_genCompanyBranchMaster oBranch = tbl_genCompanyBranchMaster.Select(clsSecurity.BranchID);
                        tbl_posTransaction oPosTrans = tbl_posTransaction.Select(txtTransactionID.Text);
                        CompanyImages oComImages = clsCommon_POS.getCompanyImages();
                        if (oPosTrans != null && oBranch != null)
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

                            #region Fill posTransaction_Detail
                            List<tbl_posTransaction_Detail> details = tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(oPosTrans.PosTransaction_Index).OrderBy(p => p.Line_No).ToList();
                            foreach (tbl_posTransaction_Detail detail in details)
                            {
                                glb_dtsBillPrinting.dt_pos_transation_details.Adddt_pos_transation_detailsRow(detail.Line_No,
                                    clsGenaralName_POS.getPoS_ID_From_PoS_Index(detail.PosTransaction_Index),
                                    detail.Item_ID,
                                    clsGenaralName.getName_ItemBrand(detail.Item_ID),
                                    "default",
                                    "default",
                                    "0",
                                    "0",
                                    clsGenaralName.getName_Item(detail.Item_ID),
                                    clsGenaralName_POS.getDescription2_Item(detail.Item_ID),
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

                            #region Update Print Count and check whether it is duplicate copy or not
                            sDuplicateCopy = (oPosTrans.PrintedUser_ID != "default") ? "Reprint" : "";
                            oPosTrans.PrintCount += 1;
                            oPosTrans.PrintedUser_ID = clsSecurity.UserIDLoged;
                            oPosTrans.DatePrinted = clsSecurity.getServerDateTime();
                            oPosTrans.PrintedTerminal_ID = clsSecurity.TerminalID;
                            oPosTrans.Update();
                            #endregion

                            #region Fill POS Transaction Header
                            glb_dtsBillPrinting.dt_pos_transaction.Adddt_pos_transactionRow(oPosTrans.PosTransaction_ID,
                                        oPosTrans.PosTransactiondate,
                                        oPosTrans.Remark,
                                        oPosTrans.Customer_ID,
                                        clsGenaralName.getName_Store(oPosTrans.Store_ID),
                                        oPosTrans.ItemPriceCategory,
                                        clsGenaralName.getName_CurrencyCode(oPosTrans.Currency_ID),
                                        oPosTrans.CurrencyRate,
                                        oPosTrans.DiscountPercentage,
                                        oPosTrans.NbtPercentage,
                                        oPosTrans.VatPercentage,
                                        oPosTrans.OtherTaxPercentage,
                                        oPosTrans.SubTotal,
                                        "Return Receipt No",
                                        0, //return receipt amount
                                        oPosTrans.DiscountTotal,
                                        oPosTrans.NbtTotal,
                                        oPosTrans.VatTotal,
                                        oPosTrans.OtherTaxTotal,
                                        oPosTrans.GrandTotal,
                                        oPosTrans.CreateUser_ID,
                                        oPosTrans.ModifiedUser_ID,
                                        oPosTrans.IsChecked,
                                        oPosTrans.IsApproved,
                                        oPosTrans.IsFinished,
                                        oPosTrans.IsDeleted,
                                        oPosTrans.IsWeightCalculation,
                                        oPosTrans.SeattleAmount,
                                        oPosTrans.IsSeattled,
                                        clsGenaralName.getName_Customer(oPosTrans.Customer_ID),
                                        clsGenaralName.getName_CustomerRegisterAddress(oPosTrans.Customer_ID),
                                        clsGenaralName.getName_CustomerTelephone(oPosTrans.Customer_ID),
                                        clsGenaralName.getVATRegNo_Customer(oPosTrans.Customer_ID),
                                         clsGenaralName.getName_CompanyBranchMaster(oPosTrans.CompanyBranch_ID), //Branch
                                         oPosTrans.CreateTerminal_ID, //Terminal
                                        clsGenaralName.getName_User(oPosTrans.CreateUser_ID),  // Cashier
                                        sDuplicateCopy, clsHelpMethods_POS.GetAdavanceTotal(oPosTrans.PosTransaction_Index), oPosTrans.GreetingDescription, oPosTrans.CreditPeriod_Days
                                        );
                            #endregion

                            #region Fill POS Receipt & Payments
                            var vPoSReceipts = tbl_posReceipt.SelectAllByPosTransaction_Index(oPosTrans.PosTransaction_Index);
                            decimal dTotalCashTendered = 0;
                            if (vPoSReceipts.Any())
                                dTotalCashTendered = vPoSReceipts.Sum(r => r.TenderedAmount);

                            foreach (tbl_posReceipt oReceipt in vPoSReceipts)
                            {
                                //Fill Receipt Payments
                                foreach (tbl_bpsChequeRegister oPayReg in tbl_bpsChequeRegister.SelectAllByPosReceipt_ID(oReceipt.PosReceipt_ID).Where(r => !r.IsDeleted))
                                {
                                    tbl_posTransaction oPos = tbl_posTransaction.Select(int.Parse(oPayReg.PosTransaction_ID));
                                    if (oPos != null && oPos.PosTransaction_ID.Trim() != "" && oPos.PosTransaction_ID != "default")
                                    {
                                        glb_dtsBillPrinting.dt_pos_receipt_payment.Adddt_pos_receipt_paymentRow(
                                            oPos.PosTransaction_ID, oPayReg.PosReceipt_ID, oPayReg.ChequeRegister_ID,
                                            ((PaymentMethod)oPayReg.PaymentMethod_ID).ToString() +
                                            (oPayReg.Amount > 0 ? " Paid" : " Balance"),
                                            ((BankTransferTypes)oPayReg.TransferType).ToString(),
                                            oPayReg.TransferRefNo,
                                            ((PaymentCardTypes)oPayReg.CardType).ToString(),
                                            oPayReg.Amount);
                                    }
                                }

                                //Fill POS Receipt 
                                glb_dtsBillPrinting.dt_pos_receipt.Adddt_pos_receiptRow(oPosTrans.PosTransaction_ID, oReceipt.PosReceipt_ID, oReceipt.PosReceiptDate, dTotalCashTendered, oReceipt.ChangeAmount, oReceipt.TotalAmount);
                            }
                            #endregion

                            #region Print Bill
                            frm_ReportViewer rpt = new frm_ReportViewer();
                            if (clsConfig_POS.bDirect_Print_R2_Pos_Invoice && !bPrintPreview_Display)
                            {
                                //Crystak Report Direct Print
                                rpt.print(sReportPath, glb_dtsBillPrinting, new DataTable(), null, false, false);
                            }
                            else
                            {
                                //Crystal Report Viewer
                                rpt.print(sReportPath, glb_dtsBillPrinting, new DataTable(), null, false, true);
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
                }
                #endregion
            }
            else
            {
                #region Report Writer Bill
                //Report Write Bill Print
                if (txtTransactionID.Text.Length > 0)
                {
                    clsReport_writer oPrintNoteOject = new clsReport_writer(txtTransactionID.Text);
                    oPrintNoteOject.printDocumnet();
                }
                else
                {
                    SEACCMessageBox.Show("Transaction Not Selected....",
                        "Please select valid transaction for printing", MessageBoxButton.OK, "Red");
                }
                #endregion
            }
            ofrmPosPayment.Hide();
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            //Gift Voucher Search Mode Disable
            bGiftVoucher_SalesMode = false;

            //Set Item Search As Default
            SetEnableDisable_UC_Search("ITEM_Mode");
            rdoGiftVoucherSearch.IsChecked = false;
            rdoItemSearch.IsChecked = true;

            //POS Transaction ID
            txtTransactionID.TextBox1.VerticalContentAlignment = VerticalAlignment.Center;
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtTransactionID, true, false, false);
            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtTransactionID.setReadOnlyStatus(true);
                txtTransactionID.Text = "<Auto Generate>";
            }
            else
                txtTransactionID.setReadOnlyStatus(false);
            #endregion

            //Amount Text Blocks
            tbSubTotal.Tag = 0;
            tbDiscount.Tag = 0;
            tbAccumilatedTotal.Tag = 0;
            tbNBT.Tag = 0;
            tbVAT.Tag = 0;
            tbOtherTax.Tag = 0;
            tbGrandTotal.Tag = 0;

            tbSubTotal.Text = "00.00";
            tbDiscount.Text = "00.00";
            tbAccumilatedTotal.Text = "00.00";
            tbNBT.Text = "00.00";
            tbVAT.Text = "00.00";
            tbOtherTax.Text = "00.00";
            tbGrandTotal.Text = "00.00";
            tbNBTPresentage.Text = cls_Formater.FormatDecimal(clsCommon.getPesentageNBT(), clsConfig.sPOSBillDecimalPoint);
            tbVATPresentage.Text = cls_Formater.FormatDecimal(clsCommon.getPesentageVAT(), clsConfig.sPOSBillDecimalPoint);
            tbOtherTaxPresentage.Text = cls_Formater.FormatDecimal(clsCommon.getPesentageOtherTax(), clsConfig.sPOSBillDecimalPoint);
            tbNoOfItems.Text = "0";

            //Tax Check Boxes
            chkNBT.IsChecked = false;
            chkVAT.IsChecked = false;
            chkOtherTax.IsChecked = false;

            //Delete Button Formatting
            btnDelete.Background = (Brush)(new BrushConverter().ConvertFrom("#FF394264"));//#FF0091EA
            btnDelete.Content = "CANCEL";
            btnDelete.IsEnabled = true;

            #region Clear Fields in Discount Popup
            txtDisc1Amount.Tag = 0;
            txtDisc2Amount.Tag = 0;
            txtDisc3Amount.Tag = 0;

            txtDisc1Pct.Tag = 0;
            txtDisc2Pct.Tag = 0;
            txtDisc3Pct.Tag = 0;

            txtDisc1Pct.Text = "0";
            txtDisc2Pct.Text = "0";
            txtDisc3Pct.Text = "0";

            txtDisc1Amount.Text = "0.00";
            txtDisc2Amount.Text = "0.00";
            txtDisc3Amount.Text = "0.00";

            txtDisc1Pct.IsEnabled = false;
            txtDisc2Pct.IsEnabled = false;
            txtDisc3Pct.IsEnabled = false;

            txtDisc1Amount.IsEnabled = false;
            txtDisc2Amount.IsEnabled = false;
            txtDisc3Amount.IsEnabled = false;

            chkDisc1.IsChecked = false;
            chkDisc2.IsChecked = false;
            chkDisc3.IsChecked = false;
            #endregion

            #region Clear Fields in Service Charges Popup
            txtServiceChargeAmount.Text = "00.00";
            txtServiceChargePct.Text = "00.00";

            txtServiceChargeAmount.Tag = 0;
            txtServiceChargePct.Tag = 0;

            chkServiceCharge.IsChecked = false;
            #endregion

            //Fill Currecncy Details
            FillDetailsCurrency(clsConfig.sLocalCurrencyCode);

            //Pop up Window Fiels
            SetEnabledDisablePopUpFields();

            //Sales Item Datatable Initialize
            dgrItems.ItemsSource = null;
            dt_Item.Clear();
            dgrItems.Items.Clear();
            dgrItems.ItemsSource = dt_Item.DefaultView;

            //Cash Customer Set
            sBranch_CashCustomer = clsHelpMethods_POS.Get_BranchCashCustomer_ID(clsSecurity.BranchID);


            //POS Payment Window 
            ofrmPosPayment.ClearFields_forReceiptDetails();
            ofrmPosPayment.btnNewReceipt.Visibility = Visibility.Hidden;
            ofrmPosPayment.btnSaveReceipt.Visibility = Visibility.Hidden;
            ofrmPosPayment.dgrPayment_Receipts.dt.Clear();
            ofrmPosPayment.Refresh_SelectedPosReceiptDetails();
        }

        #region PopUp Fields
        private void SetEnabledDisablePopUpFields()
        {
            txtDisc1Pct.IsEnabled = false;
            txtDisc2Pct.IsEnabled = false;
            txtDisc3Pct.IsEnabled = false;

            txtDisc1Amount.IsEnabled = false;
            txtDisc2Amount.IsEnabled = false;
            txtDisc3Amount.IsEnabled = false;

            txtServiceChargePct.IsEnabled = false;
            txtServiceChargeAmount.IsEnabled = false;

            #region Load Discount names
            foreach (tbl_zDiscount oDiscount in tbl_zDiscount.SelectAll())
            {
                switch (oDiscount.Discount_Id)
                {
                    case "D001":
                        chkDisc1.Content = oDiscount.DiscountName;
                        break;
                    case "D002":
                        chkDisc2.Content = oDiscount.DiscountName;
                        break;
                    case "D003":
                        chkDisc3.Content = oDiscount.DiscountName;
                        break;
                    default:
                        break;
                }
            }
            #endregion

            if (chkDisc1.IsChecked != null && chkDisc1.IsChecked.Value)
            {
                txtDisc1Pct.IsEnabled = true;
                txtDisc1Amount.IsEnabled = true;
            }
            if (chkDisc2.IsChecked != null && chkDisc2.IsChecked.Value)
            {
                txtDisc2Pct.IsEnabled = true;
                txtDisc2Amount.IsEnabled = true;
            }
            if (chkDisc3.IsChecked != null && chkDisc3.IsChecked.Value)
            {
                txtDisc3Pct.IsEnabled = true;
                txtDisc3Amount.IsEnabled = true;
            }
            if (chkServiceCharge.IsChecked != null && chkServiceCharge.IsChecked.Value)
            {
                txtServiceChargePct.IsEnabled = true;
                txtServiceChargeAmount.IsEnabled = true;
            }
        }
        #endregion

        #endregion

        #region Refresh Grid

        //Add Item Issuing
        private void RefreshGridByItemID(string sItemID)
        {
            try
            {

                tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItemID);
                if (oItem != null)
                {
                    //decimal dUnitPrice = clsProcessMethods.GetRecommendedUnitPrice_Advance(sItemID, "default", "default", "0", "0", "default");
                    decimal dUnitPrice = clsProcessMethods.GetRecommendedUnitPrice_Basic(sItemID, clsConfig_POS.sItemUnitPriceCode_Default_POS);
                    decimal defaultQty = 1m;
                    decimal dQty = Math.Round(defaultQty, 2);
                    decimal dNetAmount = dUnitPrice * dQty;
                    decimal dDiscount = 0;
                    decimal dDiscountPct = 0;
                    decimal dAmount = dNetAmount - dDiscount;

                    DataRow dr = dt_Item.NewRow();

                    dr["ItemCode"] = oItem.Item_ID;
                    dr["Desc"] = oItem.ItemName;
                    dr["UOM"] = clsGenaralName.getName_Uom(oItem.Uom_ID);
                    dr["Qty"] = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
                    dr["Weight"] = 0;
                    dr["IsFreeItem"] = "\uE003";
                    dr["UnitPrice"] = dUnitPrice;
                    dr["UnitPrice_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dUnitPrice);
                    dr["WeightPrice"] = 0;
                    dr["WeightPrice_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(0);
                    dr["NetAmount"] = dNetAmount;
                    dr["NetAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dNetAmount);
                    dr["LineDiscPresent"] = dDiscountPct;
                    dr["LineDiscPresent_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dDiscountPct);
                    dr["LineDiscAmount"] = dDiscount;
                    dr["LineDiscAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dDiscount);
                    dr["AccumulatedAmount"] = dAmount;
                    dr["AccumulatedAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dAmount);
                    dr["BilledOrRefund"] = "\uE109";
                    dr["IsRefund"] = false;
                    dr["Remarks"] = "";
                    dr["GiftVoucherID"] = -1;
                    dr["PreviousTrans_Index"] = -1;
                    dr["PreviousTrans_Detail_LineNo"] = -1;
                    dr["PreviousTrans_ID_Dispaly"] = "";

                    dt_Item.Rows.Add(dr);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        //Add Gift Voucher For Issuing
        private void RefreshGridByGiftVoucherID(int iVoucher_ID)
        {
            tbl_bpsGiftVoucher oVoucher = tbl_bpsGiftVoucher.Select(iVoucher_ID);
            if (oVoucher != null)
            {
                if (!oVoucher.IsIssued)
                {
                    decimal dUnitPrice = oVoucher.VoucherAmount;
                    decimal defaultQty = 1m;
                    decimal dQty = Math.Round(defaultQty, 2);
                    decimal dNetAmount = dUnitPrice * dQty;
                    decimal dDiscount = 0;
                    decimal dDiscountPct = 0;
                    decimal dAmount = dNetAmount - dDiscount;

                    DataRow dr = dt_Item.NewRow();

                    dr["ItemCode"] = oVoucher.Item_ID;
                    dr["Desc"] = clsGenaralName.getName_Item(oVoucher.Item_ID) + " (" + oVoucher.SerialNo + ")";
                    dr["UOM"] = "-";
                    dr["Qty"] = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity); // dQty;
                    dr["Weight"] = 0;
                    dr["IsFreeItem"] = "\uE003";
                    dr["UnitPrice"] = dUnitPrice;
                    dr["UnitPrice_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dUnitPrice);
                    dr["WeightPrice"] = 0;
                    dr["WeightPrice_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(0);
                    dr["NetAmount"] = dNetAmount;
                    dr["NetAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dNetAmount);
                    dr["LineDiscPresent"] = dDiscountPct;
                    dr["LineDiscPresent_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dDiscountPct);
                    dr["LineDiscAmount"] = dDiscount;
                    dr["LineDiscAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dDiscount);
                    dr["AccumulatedAmount"] = dAmount;
                    dr["AccumulatedAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dAmount);
                    dr["BilledOrRefund"] = "\uE109";
                    dr["IsRefund"] = false;
                    dr["Remarks"] = "";
                    dr["GiftVoucherID"] = oVoucher.GiftVoucherID;
                    dr["PreviousTrans_Index"] = -1;
                    dr["PreviousTrans_Detail_LineNo"] = -1;
                    dr["PreviousTrans_ID_Dispaly"] = "";

                    dt_Item.Rows.Add(dr);
                }
            }
            else
            {
                SEACCMessageBox.Show("Already Issued Gift Voucher..", "This gift voucher has already been issued...", MessageBoxButton.OK, "Red");
            }
        }


        private void RefreshGridByPreviousPOS_TxIndex(int sPOS_Tx_Index)
        {
            List<tbl_posTransaction_Detail> details = tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(sPOS_Tx_Index).Where(r => r.Qty > 0).OrderBy(p => p.Line_No).ToList();
            foreach (tbl_posTransaction_Detail detail in details)
            {
                tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                if (item != null)
                {
                    decimal dExRate = 0;
                    if (lblCurrencyRate.Text.Trim().Length > 0)
                        dExRate = clsValidation.Validate_DecimalNumber(lblCurrencyRate.Text.Trim());

                    decimal dUnitPrice = detail.UnitPrice;
                    decimal dQty = Math.Round(detail.Qty, 2);
                    decimal dNetAmount = detail.NetAmount;
                    decimal dDiscount = detail.LineDiscountTotal;
                    decimal dDiscountPct = detail.LineDiscountPresentage;
                    decimal dAmount = detail.GrossAmount;

                    DataRow dr = dt_Item.NewRow();

                    dr["ItemCode"] = detail.Item_ID;
                    dr["Desc"] = item.ItemName;
                    dr["UOM"] = clsGenaralName.getName_Uom(item.Uom_ID);
                    dr["Qty"] = -dQty;
                    dr["Weight"] = 0;
                    dr["IsFreeItem"] = detail.BIsFreeItem ? "\uE0A2" : "\uE003";
                    dr["UnitPrice"] = dUnitPrice;
                    dr["UnitPrice_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dUnitPrice);
                    dr["WeightPrice"] = 0;
                    dr["WeightPrice_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(0);
                    dr["NetAmount"] = -dNetAmount;
                    dr["NetAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(-dNetAmount);
                    dr["LineDiscPresent"] = dDiscountPct;
                    dr["LineDiscPresent_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dDiscountPct);
                    dr["LineDiscAmount"] = dDiscount;
                    dr["LineDiscAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dDiscount);
                    dr["AccumulatedAmount"] = -dAmount;
                    dr["AccumulatedAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(-dAmount);
                    dr["BilledOrRefund"] = "\uE108";
                    dr["IsRefund"] = true;
                    dr["Remarks"] = detail.Remark;
                    dr["GiftVoucherID"] = detail.GiftVoucherID;
                    dr["PreviousTrans_Index"] = detail.PosTransaction_Index;
                    dr["PreviousTrans_Detail_LineNo"] = detail.Line_No;
                    dr["PreviousTrans_ID_Dispaly"] = clsGenaralName_POS.getPoS_ID_From_PoS_Index(detail.PosTransaction_Index);

                    dt_Item.Rows.Add(dr);
                }
            }
        }

        #endregion

        #region Check Validity

        private bool CheckValidity(bool bHold_Bill)
        {
            bool bStatus = false;
            if (CheckValidity_NotManagerSignOff())
                if (CheckValidity_EmptyField())
                    if (CheckValidity_EmptyGrid())
                        if (CheckValidity_QtyZero())
                            if (CheckValidity_PaymentOption())
                                if (CheckFull_Payment(bHold_Bill))
                                    if (CheckFloorStock())
                                        if (CheckValidity_DuplicateFiled())
                                            if (CheckValidity_CusTelephoneNo())
                                                if (Check_Transaction_ID())
                                                    bStatus = true;

            return bStatus;
        }

        //Check Empty Field
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;
            sField_ValidityMsg = "";

            if (!SEACC_Form.isAutoGenaratedCode)
            {
                txtTransactionID.Tag = txtTransactionID.Text;
                if (!clsValidation.Validate_EmptyValue(txtTransactionID))
                    bStatus = false;
            }

            if (!bStatus)
                SEACCMessageBox.Show("Something Went Wrong..!", sField_ValidityMsg, MessageBoxButton.OK, "Red");

            return bStatus;
        }

        private bool Check_Transaction_ID()
        {
            bool bStatus = false;
            if (!SEACC_Form.isAutoGenaratedCode)
            {
                if (clsValidate.CheckValidity_TransactionCodeLength(txtTransactionID.Text))
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

        //Check Transaction ID Duplicated or Not
        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode && !SEACC_Form.isAutoGenaratedCode)
            {
                tbl_posTransaction oPosTransaction = tbl_posTransaction.Select(txtTransactionID.Text);
                if (oPosTransaction != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        //Check Grid is empty or Not
        private bool CheckValidity_EmptyGrid()
        {
            bool bStatus = true;
            if (dt_Item.Rows.Count == 0)
            {
                bStatus = false;
                SEACCMessageBox.Show("Item Grid is Empty..!", "Please add items to Item Grid", MessageBoxButton.OK, "Red");
            }
            return bStatus;
        }

        //Check Payment Option Validation (Full/Advance/Part)
        private bool CheckValidity_PaymentOption()
        {
            bool bStatus = true;
            if (!ofrmPosPayment.rdoAdavancePayment.IsChecked.Value && !ofrmPosPayment.rdoFullPayment.IsChecked.Value && !ofrmPosPayment.rdoPartPayment.IsChecked.Value)
            {
                bStatus = false;
                SEACCMessageBox.Show("Payment Option Not Selected...", "Please select payment option before saving", MessageBoxButton.OK, "Red");
            }
            return bStatus;
        }

        //Full Payment Option Validation
        private bool CheckFull_Payment(bool bHold_Bill)
        {
            bool bReturn = true;
            if (!bHold_Bill)
            {
                if (ofrmPosPayment.rdoFullPayment.IsChecked.Value)
                {
                    decimal dReceiptAmount = clsValidation.Validate_DecimalNumber(ofrmPosPayment.txtReceiptTenderedTotal.TextBox1.Text);
                    decimal dTxTotal = clsValidation.Validate_DecimalNumber(ofrmPosPayment.tbGrandtotal.Text);

                    if (dReceiptAmount < dTxTotal)
                    {
                        bReturn = false;
                        SEACCMessageBox.Show("Please Do The Full Payment", "You have already selected Full Payment Option \n Therefore, Please do the full payment", MessageBoxButton.OK, "Red");
                    }
                }
            }
            return bReturn;
        }

        //Check Store Stock
        private bool CheckFloorStock()
        {
            if (!clsConfig.bMinusQtyEnable_DO)
            {
                DataTable dtFloorStock = clsHelpMethods_POS.GetItemGroupedItemFloorstockTable(dt_Item, "ItemCode", "Qty", sPOS_Store_ID);
                if (SEACC_Form.IsUpdateMode)
                {
                    foreach (DataRow dr in dtFloorStock.Rows)
                    {
                        string sItemId = clsValidate.ValidateRowValue(dr, "Item_ID", "default");
                        dr["IssuedQty"] = cls_Formater.FormatDecimal(tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(int.Parse(txtTransactionID.Tag.ToString())).Where(r => r.Item_ID == sItemId).Sum(x => x.Qty), clsConfig.sDecimalPlaces_Quantity);
                    }
                }
                return clsHelpMethods_POS.CheckItemFloorStockTable(dtFloorStock);
            }
            else
                return true;
        }

        //Validate Zero Quantity for Sales Items
        private bool CheckValidity_QtyZero()
        {
            bool bStatus = true;

            var vResult = dt_Item.Select().Where(r => clsValidation.Validate_DecimalNumber(r.Field<string>("Qty")) == 0m);
            if (vResult.Count() > 0)
            {
                bStatus = false;
                string sMsg = "";
                foreach (DataRow dr in vResult)
                {
                    sMsg += dr["ItemCode"].ToString() + " - " + dr["Desc"].ToString() + "\n";
                }
                SEACCMessageBox.Show("Zero Qty..",
                    "Following Items have zero qyantities :\n" + sMsg, MessageBoxButton.OK, "Red");
            }

            return bStatus;
        }

        //Check Customer Telephone
        private bool CheckValidity_CusTelephoneNo()
        {
            bool bStatus = true;
            string sTelNo = ofrmPosPayment.txtCustomerTelphone.TextBox1.Text.Trim();
            if (sTelNo.Length > 0 && sTelNo != "-")
            {
                if (sTelNo.Length != 10)
                {
                    bStatus = false;

                    SEACCMessageBox.Show("Invalid Customer Telephone Number...",
                    "Entered Telephone Number has " + sTelNo.Length + " Digits. \nPlease Enter 10 Digits Valid Telephone Number...",
                    MessageBoxButton.OK, "Red");
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

        #region Fill Detail

        //When Recall Previously Saved Transaction 
        private void FillDetail_RefreshGridByTransactionID(string sPosTransactionID)
        {
            try
            {
                ClearFields();

                SEACC_Form.IsUpdateMode = true;

                //POS Transaction
                tbl_posTransaction oPoSTrans = tbl_posTransaction.Select(sPosTransactionID);
                if (oPoSTrans != null)
                {
                    txtTransactionID.Text = oPoSTrans.PosTransaction_ID;
                    txtTransactionID.Tag = oPoSTrans.PosTransaction_Index;
                    if (oPoSTrans.IsDeleted)
                    {
                        //Delete Button Formatting
                        btnDelete.Background = Brushes.Red;
                        btnDelete.Content = "CANCEL";
                        btnDelete.IsEnabled = false;
                    }

                    //Payment Detail Set Up (Part 01)
                    ofrmPosPayment.txtCustomerName.Tag = oPoSTrans.Customer_ID;
                    ofrmPosPayment.txtCustomerName.TextBox1.Text = clsGenaralName.getName_Customer(oPoSTrans.Customer_ID);
                    ofrmPosPayment.txtCustomerAddress.TextBox1.Text = clsGenaralName.getName_CustomerRegisterAddress(oPoSTrans.Customer_ID);
                    ofrmPosPayment.txtCustomerTelphone.TextBox1.Text = clsGenaralName.getName_CustomerTelephone(oPoSTrans.Customer_ID);
                    ofrmPosPayment.txtWarrantyDescription.TextBox1.Text = oPoSTrans.Remark;
                    ofrmPosPayment.txtGreetngDescription.TextBox1.Text = oPoSTrans.GreetingDescription;
                    ofrmPosPayment.txtCreditPeriod.TextBox1.Text = cls_Formater.FormatDecimal(oPoSTrans.CreditPeriod_Days, 0);


                    #region Transaction Details (items fill)
                    List<tbl_posTransaction_Detail> details = tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(oPoSTrans.PosTransaction_Index).OrderBy(p => p.Line_No).ToList();
                    foreach (tbl_posTransaction_Detail detail in details)
                    {
                        tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                        if (item != null)
                        {
                            decimal dExRate = 0;
                            if (lblCurrencyRate.Text.Trim().Length > 0)
                                dExRate = clsValidation.Validate_DecimalNumber(lblCurrencyRate.Text.Trim());

                            decimal dUnitPrice = detail.UnitPrice;
                            decimal dQty = Math.Round(detail.Qty, 2);
                            decimal dNetAmount = detail.NetAmount;
                            decimal dDiscount = detail.LineDiscountTotal;
                            decimal dDiscountPct = detail.LineDiscountPresentage;
                            decimal dAmount = detail.GrossAmount;

                            DataRow dr = dt_Item.NewRow();

                            dr["ItemCode"] = detail.Item_ID;
                            dr["Desc"] = item.ItemName;
                            dr["UOM"] = clsGenaralName.getName_Uom(item.Uom_ID);
                            dr["Qty"] = dQty;
                            dr["Weight"] = 0;
                            dr["IsFreeItem"] = detail.BIsFreeItem ? "\uE0A2" : "\uE003";
                            dr["UnitPrice"] = dUnitPrice;
                            dr["UnitPrice_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dUnitPrice);
                            dr["WeightPrice"] = 0;
                            dr["WeightPrice_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(0);
                            dr["NetAmount"] = dNetAmount;
                            dr["NetAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dNetAmount);
                            dr["LineDiscPresent"] = dDiscountPct;
                            dr["LineDiscPresent_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dDiscountPct);
                            dr["LineDiscAmount"] = dDiscount;
                            dr["LineDiscAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dDiscount);
                            dr["AccumulatedAmount"] = dAmount;
                            dr["AccumulatedAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dAmount);
                            dr["BilledOrRefund"] = "\uE109";
                            dr["IsRefund"] = false;
                            if (dQty < 0)
                            {
                                dr["BilledOrRefund"] = "\uE108";
                                dr["IsRefund"] = true;
                            }
                            dr["Remarks"] = detail.Remark;
                            dr["GiftVoucherID"] = detail.GiftVoucherID;
                            dr["PreviousTrans_Index"] = detail.PrevPosTx_Index;
                            dr["PreviousTrans_Detail_LineNo"] = detail.PrevPosTx_LineNo;
                            dr["PreviousTrans_ID_Dispaly"] = detail.PrevPosTx_Index < 1 ? "" : clsGenaralName_POS.getPoS_ID_From_PoS_Index(detail.PrevPosTx_Index);

                            dt_Item.Rows.Add(dr);
                        }
                    }
                    dgrItems.ItemsSource = dt_Item.DefaultView;
                    #endregion

                    //Sub Total
                    tbSubTotal.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(oPoSTrans.SubTotal);
                    tbSubTotal.Tag = oPoSTrans.SubTotal;

                    #region Transaction Bulk Discount
                    txtDisc1Pct.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(oPoSTrans.DiscountPercentage);
                    txtDisc1Pct.Tag = oPoSTrans.DiscountPercentage;
                    txtDisc1Amount.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(oPoSTrans.DiscountTotal);
                    txtDisc1Amount.Tag = oPoSTrans.DiscountTotal;
                    if (oPoSTrans.DiscountTotal != 0)
                        chkDisc1.IsChecked = true;

                    tbDiscount.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(oPoSTrans.DiscountTotal);
                    tbDiscount.Tag = oPoSTrans.DiscountTotal;

                    #region Transaction Discuont
                    txtDisc1Pct.Text = cls_Formater.FormatDecimal(oPoSTrans.DiscountPercentage1, clsConfig.sPOSBillDecimalPoint);
                    txtDisc2Pct.Text = cls_Formater.FormatDecimal(oPoSTrans.DiscountPercentage2, clsConfig.sPOSBillDecimalPoint);
                    txtDisc3Pct.Text = cls_Formater.FormatDecimal(oPoSTrans.DiscountPercentage3, clsConfig.sPOSBillDecimalPoint);
                    txtDisc1Amount.Text = cls_Formater.FormatDecimal(oPoSTrans.DiscountTotal1, clsConfig.sPOSBillDecimalPoint);
                    txtDisc2Amount.Text = cls_Formater.FormatDecimal(oPoSTrans.DiscountTotal2, clsConfig.sPOSBillDecimalPoint);
                    txtDisc3Amount.Text = cls_Formater.FormatDecimal(oPoSTrans.DiscountTotal3, clsConfig.sPOSBillDecimalPoint);
                    if (oPoSTrans.DiscountTotal1 != 0)
                        chkDisc1.IsChecked = true;
                    if (oPoSTrans.DiscountTotal2 != 0)
                        chkDisc2.IsChecked = true;
                    if (oPoSTrans.DiscountTotal3 != 0)
                        chkDisc3.IsChecked = true;
                    #endregion

                    #endregion

                    //Accumilated Total
                    tbAccumilatedTotal.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(oPoSTrans.SubTotal - (oPoSTrans.DiscountTotal));//+ oPoSTrans.Discount2Total + oPoSTrans.Discount3Total
                    tbAccumilatedTotal.Tag = oPoSTrans.SubTotal - (oPoSTrans.DiscountTotal);//+ oPoSTrans.Discount2Total + oPoSTrans.Discount3Total

                    #region Service Charge Set Up
                    //txtServiceChargeAmount.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(oPoSTrans.ServiceChargeTotal);
                    //txtServiceChargeAmount.Tag = oPoSTrans.ServiceChargeTotal;
                    //txtServiceChargePct.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(oPoSTrans.ServiceChargePercentage);
                    //txtServiceChargePct.Tag = oPoSTrans.ServiceChargePercentage;
                    //if (oPoSTrans.ServiceChargeTotal != 0)
                    //    chkServiceCharge.IsChecked = true; 
                    #endregion

                    #region Tax Set Up
                    tbNBT.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(oPoSTrans.NbtTotal);
                    tbNBT.Tag = oPoSTrans.NbtTotal;
                    tbNBTPresentage.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(oPoSTrans.NbtPercentage);
                    tbNBTPresentage.Tag = oPoSTrans.NbtPercentage;
                    if (oPoSTrans.NbtTotal != 0)
                        chkNBT.IsChecked = true;

                    tbVAT.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(oPoSTrans.VatTotal);
                    tbVAT.Tag = oPoSTrans.VatTotal;
                    tbVATPresentage.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(oPoSTrans.VatPercentage);
                    tbVATPresentage.Tag = oPoSTrans.VatPercentage;
                    if (oPoSTrans.VatTotal != 0)
                        chkVAT.IsChecked = true;

                    tbOtherTax.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(oPoSTrans.OtherTaxTotal);
                    tbOtherTax.Tag = oPoSTrans.OtherTaxTotal;
                    tbOtherTaxPresentage.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(oPoSTrans.OtherTaxPercentage);
                    tbOtherTaxPresentage.Tag = oPoSTrans.OtherTaxPercentage;
                    if (oPoSTrans.OtherTaxTotal != 0)
                        chkOtherTax.IsChecked = true;
                    #endregion

                    //Grand Total Set Up
                    tbGrandTotal.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(oPoSTrans.GrandTotal);
                    tbGrandTotal.Tag = oPoSTrans.GrandTotal;

                    //Finalize the Grid Set Up
                    tbNoOfItems.Text = dt_Item.Rows.Count.ToString();
                    dgrItems.UnselectAll();

                    //Payment Detail Set Up (Part 02)
                    ofrmPosPayment.ClearFields_forReceiptDetails();
                    ofrmPosPayment.FillDetails_PosReceipts(oPoSTrans);
                    ofrmPosPayment.txtSalesRep.Tag = oPoSTrans.SalesRep_ID;
                    ofrmPosPayment.txtSalesRep.TextBox1.Text = clsGenaralName.getName_SalesRep(oPoSTrans.SalesRep_ID);
                    if (clsHelpMethods_POS.Is_CashCustomer(oPoSTrans.Customer_ID))
                        ofrmPosPayment.rdoFullPayment.IsChecked = true;
                }
                else
                {
                    SEACCMessageBox.Show("Invalid Transaction", "Please select the valid transaction", MessageBoxButton.OK, "Red");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Events - Item Grid 

        //Item Grid Loading
        private void dgItems_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_POS.OrderBy_DataGrid(dt_Item);
            e.Row.Loaded += Row_Loaded;
        }

        //Item Grid Row Loaded
        private void Row_Loaded(object sender, RoutedEventArgs e)
        {
            var row = (DataGridRow)sender;
            row.Loaded -= Row_Loaded;

            row.IsSelected = true;
            DataGridCell cell = clsHelpMethods_POS.GetCell(dgrItems, row, 3); //Qty Column
            if (cell != null) cell.Focus();
            //dgrItems.BeginEdit();
        }

        //Cell Edit In Selected Row
        private void dgItems_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                //object item = dgrItems.SelectedItem;
                object item = e.Row.Item;
                if (item != null)
                {
                    if (dgrItems.SelectedCells.Count > 0)
                    {
                        string sItem_LineNo = (dgrItems.SelectedCells[0].Column.GetCellContent(item) as TextBlock)?.Text;

                        if (sItem_LineNo != null)
                        {
                            string sSortMemberName = e.Column.SortMemberPath;
                            switch (sSortMemberName)
                            {
                                case "":
                                case null:
                                case "Remarks":
                                case "ItemCode":
                                case "Desc":
                                    break;
                                default:
                                    #region Cell Content Validation
                                    switch (sSortMemberName)
                                    {
                                        case "Qty":
                                        case "UnitPrice_Display":
                                        case "LineDiscPresent_Display":
                                        case "LineDiscAmount_Display":
                                            TextBox vEditBox = e.EditingElement as TextBox;
                                            var dQty = 0m;
                                            try
                                            {
                                                if (vEditBox != null) dQty = decimal.Parse(vEditBox.Text);

                                                string sItem_ID = (dgrItems.SelectedCells[1].Column.GetCellContent(item) as TextBlock)?.Text;

                                                if (sItem_ID != null)
                                                {
                                                    #region Gift Voucher Validation
                                                    bool bIsGrftVoucher = false;
                                                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItem_ID);
                                                    if (oItem != null)
                                                        bIsGrftVoucher = oItem.IsGiftVoucher;
                                                    #endregion

                                                    if (sSortMemberName == "UnitPrice_Display" && (dQty < 0 || bIsGrftVoucher))
                                                    {
                                                        if (bIsGrftVoucher)
                                                            SEACCMessageBox.Show("Oops..!", "Unit price can not be changed in Gift Vouchers", MessageBoxButton.OK, "Red");
                                                        else
                                                            SEACCMessageBox.Show("Oops..!", "Unit price can not be negative value", MessageBoxButton.OK, "Red");

                                                        dQty = clsValidation.Validate_DecimalNumber(sPrevCellVal);
                                                    }

                                                    if (sSortMemberName == "Qty" && dQty > 1 && bIsGrftVoucher)
                                                    {
                                                        SEACCMessageBox.Show("Oops..!", "Qty can not be changed", MessageBoxButton.OK, "Red");
                                                        dQty = 1;
                                                    }
                                                }
                                            }
                                            catch
                                            {
                                                SEACCMessageBox.Show("Oops..!", "Please enter numeric value", MessageBoxButton.OK, "Red");
                                            }

                                            if (vEditBox != null)
                                                vEditBox.Text = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);

                                            if (sSortMemberName == "Qty")
                                            {
                                                DataRow dr = dt_Item.Select("LineNo ='" + sItem_LineNo + "'").FirstOrDefault();
                                                if (dr != null)
                                                {
                                                    dr["Qty"] = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
                                                }
                                            }
                                            if (sSortMemberName == "LineDiscAmount_Display")
                                            {
                                                DataRow dr = dt_Item.Select("LineNo ='" + sItem_LineNo + "'").FirstOrDefault();
                                                if (dr != null)
                                                {
                                                    dr["LineDiscAmount"] = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
                                                    dr["LineDiscAmount_Display"] = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
                                                }
                                            }

                                            {
                                                DataRow dr = dt_Item.Select("LineNo ='" + sItem_LineNo + "'").FirstOrDefault();
                                                if (dr != null)
                                                {
                                                    string sItemQty = (dgrItems.SelectedCells[4].Column.GetCellContent(item) as TextBlock)?.Text;
                                                    string sUnitPrice = (dgrItems.SelectedCells[5].Column.GetCellContent(item) as TextBlock)?.Text;
                                                    string sLine_disc = dr["LineDiscAmount"].ToString();

                                                    decimal dUnitPrice = clsValidation.Validate_DecimalNumber(sUnitPrice);
                                                    decimal dLine_disc = clsValidation.Validate_DecimalNumber(sLine_disc);
                                                    decimal dItemQty = clsValidation.Validate_DecimalNumber(sItemQty);

                                                    decimal dNetAmount = dItemQty * dUnitPrice;
                                                    decimal dAccumulatedAmount = dQty * (dUnitPrice - dLine_disc);

                                                    DataRow row = dt_Item.Select("LineNo ='" + sItem_LineNo + "'").FirstOrDefault();
                                                    if (row != null)
                                                    {
                                                        row["NetAmount"] = dNetAmount;
                                                        row["NetAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dNetAmount);
                                                        row["LineDiscAmount"] = dLine_disc;
                                                        row["LineDiscAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dLine_disc);
                                                        row["AccumulatedAmount"] = dAccumulatedAmount;
                                                        row["AccumulatedAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dAccumulatedAmount);

                                                        dt_Item.AcceptChanges();
                                                    }
                                                }
                                            }

                                            break;
                                    }
                                    #endregion


                                    CalculateLineAmount(e.Column.Header.ToString(), sItem_LineNo, e.EditingElement as TextBox);
                                    CalcualteSubTotal();
                                    CalculateTaxesAndGrandTotal();
                                    CauculateNoOfItemsAndTotalQuantity();
                                    break;
                            }
                        }
                    }
                }
                Calculate_WholeGrid_Claculations();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        //Cell Edit Begining
        private void dgItems_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            try
            {
                //int irowId = dgrItems.SelectedIndex;
                string sSortMemberName = e.Column.SortMemberPath;
                //object item = dgrItems.SelectedItem;

                object item = e.Row.Item;

                if (item != null)
                {
                    if (dgrItems.SelectedCells.Count > 0)
                    {
                        string sItem_LineNo = (dgrItems.SelectedCells[0].Column.GetCellContent(item) as TextBlock)?.Text;
                        if (sItem_LineNo != null)
                        {
                            switch (sSortMemberName)
                            {
                                case "UnitPrice_Display":
                                    DataRow dr = dt_Item.Select("LineNo ='" + sItem_LineNo + "'").FirstOrDefault();
                                    if (dr != null)
                                    {
                                        dr["IsFreeItem"] = "\uE003";
                                        sPrevCellVal = dr["UnitPrice_Display"].ToString();
                                    }
                                    break;
                                case "Qty":
                                    DataRow dr_Qty = dt_Item.Select("LineNo ='" + sItem_LineNo + "'").FirstOrDefault();
                                    if (dr_Qty != null)
                                    {
                                        dr_Qty["IsFreeItem"] = "\uE003";
                                    }
                                    break;
                                default:
                                    sPrevCellVal = "";
                                    break;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        //Row, Cell Single Click
        private void dgItems_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;

            //int irowId = dgrItems.SelectedIndex;
            var vDgCell = dgrItems.CurrentCell;

            object item = dgrItems.SelectedItem;
            if (item != null)
            {
                try
                {
                    string sItem_LineNo = (dgrItems.SelectedCells[0].Column.GetCellContent(item) as TextBlock)?.Text;
                    DataRow dr = dt_Item.Select("LineNo ='" + sItem_LineNo + "'").FirstOrDefault();
                    if (dr != null)
                    {
                        int iColumn_Id = vDgCell.Column.DisplayIndex;
                        switch (iColumn_Id)
                        {
                            case 7://Free Item
                                string a = dr["IsFreeItem"].ToString();
                                if (dr["IsFreeItem"].ToString() == "\uE0A2")//If True
                                {
                                    dr["IsFreeItem"] = "\uE003";//Std. Disc %
                                    dr["LineDiscPresent"] = 0;
                                    dr["LineDiscPresent_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(0);
                                }
                                else
                                {
                                    dr["IsFreeItem"] = "\uE0A2";
                                    dr["LineDiscPresent"] = 100;
                                    dr["LineDiscPresent_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(100);
                                }
                                CalculateLineAmount("Std. Disc %", sItem_LineNo, null);
                                dgrItems.UnselectAll();
                                dt_Item.AcceptChanges();
                                break;

                            case 11: //Remove Item
                                dr.Delete();
                                dt_Item.AcceptChanges();
                                //dt_Item.Rows.RemoveAt(irowId);
                                break;

                            case 12: // Billed or Return Item
                                if (dr["BilledOrRefund"].ToString() == "\uE108")
                                {
                                    dr["BilledOrRefund"] = "\uE109";
                                    dr["IsRefund"] = false;
                                    if (clsValidation.Validate_DecimalNumber((dr["Qty"]).ToString()) < 0)
                                        dr["Qty"] = (clsValidation.Validate_DecimalNumber((dr["Qty"]).ToString()) * -1);
                                    dt_Item.AcceptChanges();
                                }
                                else
                                {
                                    dr["BilledOrRefund"] = "\uE108";
                                    dr["IsRefund"] = true;
                                    if (clsValidation.Validate_DecimalNumber((dr["Qty"]).ToString()) > 0)
                                    {
                                        dr["Qty"] = (clsValidation.Validate_DecimalNumber((dr["Qty"]).ToString()) * -1);
                                        dt_Item.AcceptChanges();
                                    }
                                }
                                CalculateLineAmount("Quantity", sItem_LineNo, null);
                                dgrItems.UnselectAll();
                                break;

                            default:
                                break;
                        }


                    }
                }
                catch
                {
                    // ignored
                }

                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();
                CauculateNoOfItemsAndTotalQuantity();


            }
        }

        //Row, Cell Double Click
        private void dgItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //int irowID = dgrItems.SelectedIndex;
            var vDG_Cell = dgrItems.CurrentCell;

            object item = dgrItems.SelectedItem;

            try
            {
                string sItem_LineNo = (dgrItems.SelectedCells[0].Column.GetCellContent(item) as TextBlock)?.Text;
                DataRow dr = dt_Item.Select("LineNo ='" + sItem_LineNo + "'").FirstOrDefault();
                if (dr != null)
                {
                    if (vDG_Cell.Column.SortMemberPath == "Remarks")
                    {
                        frmSearchForm RowDataSearch = new frmSearchForm();
                        List<string> lstResult = RowDataSearch.Show(Search.Pos_ItemRemarks);

                        if (RowDataSearch.DialogResult == true)
                        {
                            dr["Remarks"] = lstResult[1];
                        }
                    }

                    else if (vDG_Cell.Column.SortMemberPath == "PreviousTrans_ID_Dispaly")
                    {
                        if (dr["BilledOrRefund"].ToString() == "\uE108")
                        {
                            List<string> lstParameeters = new List<string>();
                            if (clsSecurity.BranchID != "")
                                lstParameeters.Add(clsSecurity.BranchID);

                            string sItem_ID = dr["ItemCode"].ToString();
                            lstParameeters.Add(sItem_ID);

                            frmSearchForm RowDataSearch = new frmSearchForm(lstParameeters);
                            List<string> lstResult = RowDataSearch.Show(Search.Pos_SoldItems);

                            if (RowDataSearch.DialogResult == true)
                            {
                                dr["PreviousTrans_Detail_LineNo"] = lstResult[0];
                                dr["PreviousTrans_Index"] = lstResult[1];
                                dr["PreviousTrans_ID_Dispaly"] = lstResult[2];

                                string sQty = dr["Qty"].ToString();
                                decimal dQty = clsValidation.Validate_DecimalNumber(sQty);

                                tbl_posTransaction_Detail vTxn_Item = tbl_posTransaction_Detail.Select(int.Parse(lstResult[0]), int.Parse(lstResult[1]));
                                if (vTxn_Item != null)
                                {
                                    dr["Qty"] = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
                                    dr["Weight"] = 0;

                                    decimal lQty = 0, lUnitPrice = 0, lStdDisc = 0, lStdDiscPct = 0, lNetAmount = 0, lAmount = 0;
                                    lUnitPrice = vTxn_Item.UnitPrice;
                                    lStdDisc = vTxn_Item.LineDiscountTotal;
                                    lStdDiscPct = vTxn_Item.LineDiscountPresentage;
                                    lQty = dQty;
                                    lStdDisc = vTxn_Item.LineDiscountTotal * lQty;
                                    lNetAmount = lQty * lUnitPrice;
                                    if (lNetAmount != 0)
                                        lStdDiscPct = clsValidation.Validate_DecimalNumber((lStdDisc * 100 / lNetAmount).ToString());
                                    else
                                        lStdDiscPct = 0;
                                    lAmount = lNetAmount - lStdDisc;
                                    dr["UnitPrice"] = lUnitPrice;
                                    dr["UnitPrice_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(lUnitPrice);
                                    dr["NetAmount"] = lNetAmount;
                                    dr["NetAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(lNetAmount);
                                    dr["LineDiscPresent"] = Math.Round(lStdDiscPct, 2);
                                    dr["LineDiscPresent_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(Math.Round(lStdDiscPct, 2));
                                    dr["LineDiscAmount"] = lQty != 0 ? Math.Round(lStdDisc / lQty, 2) : 0;
                                    dr["LineDiscAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(lQty != 0 ? Math.Round(lStdDisc / lQty, 2) : 0);
                                    dr["AccumulatedAmount"] = lAmount;
                                    dr["AccumulatedAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(lAmount);

                                    CalcualteSubTotal();
                                    CalculateTaxesAndGrandTotal();
                                    CauculateNoOfItemsAndTotalQuantity();

                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        #region Key Press Events in Grid
        private void dgItems_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            var vDgCell = dgrItems.CurrentCell;
            var uiElement = e.OriginalSource as UIElement;
            if (e.Key == Key.Enter)
            {
                if (dgrItems.SelectedIndex == -1 || uiElement == null) return;
                e.Handled = true;
                uiElement.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
            else if (e.Key == Key.Tab)
            {
                dgrItems.CommitEdit(DataGridEditingUnit.Row, true);
            }
            else if (e.Key == Key.S && Keyboard.Modifiers == ModifierKeys.Control)
            {
                dgrItems.CommitEdit(DataGridEditingUnit.Row, true);
                btnSave_Click(null, null);
            }
            else if (e.Key == Key.OemMinus && vDgCell.Column.SortMemberPath == "BilledOrRefund")
            {
                dgrItems.CommitEdit(DataGridEditingUnit.Row, true);
                dgItems_MouseLeftButtonUp(null, null);
                dgrItems.SelectedItem = vDgCell.Item;
            }
            else if (e.Key == Key.Delete)
            {
                var selectedItem = dgrItems.SelectedItem;
                if (selectedItem != null)
                {
                    string sItem_LineNo = (dgrItems.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock)?.Text;
                    DataRow dr = dt_Item.Select("LineNo ='" + sItem_LineNo + "'").FirstOrDefault();
                    dt_Item.Rows.Remove(dr);
                    dt_Item.AcceptChanges();

                    CalcualteSubTotal();
                    CalculateTaxesAndGrandTotal();
                    CauculateNoOfItemsAndTotalQuantity();
                }
            }
        }
        #endregion

        #endregion

        #region Events - Search Text Boxes

        #region Main Item Search Usercontroller Events

        //Key Press Down & Barcode Enter
        private void Srh_Items_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                dgrItems.UnselectAll();
                if (e.Key == Key.Enter)
                {
                    //RefreshGridByItemID(ucItemSearch.txtFillter.Text);

                    CalcualteSubTotal();
                    CalculateTaxesAndGrandTotal();
                    CauculateNoOfItemsAndTotalQuantity();
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        //Item Selection From Search
        private void Srh_Items_SelectionOK(List<string> sender)
        {
            try
            {
                if (sender.Count > 0)
                {
                    var vGVs = dt_Item.Select("GiftVoucherID <> '-1' ");
                    if (vGVs.Length == 0)
                    {
                        bGiftVoucher_SalesMode = false;

                        RefreshGridByItemID(sender[0]);

                        CalcualteSubTotal();
                        CalculateTaxesAndGrandTotal();
                        CauculateNoOfItemsAndTotalQuantity();
                    }
                    else
                    {
                        SEACCMessageBox.Show("Cannot Add Items..", "This is Gift Voucher Sale. You can not add items to it.", MessageBoxButton.OK, "Red");
                    }
                }
                frmPosSalesWindow.Effect = null;

                if (dgrItems.Items.Count > 0)
                {
                    var border = VisualTreeHelper.GetChild(dgrItems, 0) as Decorator;
                    if (border != null)
                    {
                        var scroll = border.Child as ScrollViewer;
                        if (scroll != null) scroll.ScrollToEnd();
                    }

                    dgrItems.CurrentCell = new DataGridCellInfo(dgrItems.Items[dgrItems.Items.Count - 1], dgrItems.Columns[4]);
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        dgrItems.BeginEdit();
                    }), System.Windows.Threading.DispatcherPriority.Background);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Gift Voucher Search Usercontroller Events

        //Gift Voucher Search Grid Key Down
        private void UcGiftVoucherSearch_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            dgrItems.UnselectAll();
            if (e.Key == Key.Enter)
            {
                try
                {
                    //RefreshGridByGiftVoucherID(int.Parse(ucGiftVoucherSearch.txtFillter.Text));

                    CalcualteSubTotal();
                    CalculateTaxesAndGrandTotal();
                    CauculateNoOfItemsAndTotalQuantity();
                }
                catch { }
            }
        }

        //Gift Voucher Selection and Add to Grid
        private void UcGiftVoucherSearch_OnSelectionOK(List<string> sender)
        {
            if (sender.Count > 0)
            {
                var vItems = dt_Item.Select("GiftVoucherID = '-1' ");
                if (vItems.Length == 0 || dt_Item.Rows.Count == 0)
                {
                    bGiftVoucher_SalesMode = true;

                    RefreshGridByGiftVoucherID(int.Parse(sender[0]));

                    CalcualteSubTotal();
                    CalculateTaxesAndGrandTotal();
                    CauculateNoOfItemsAndTotalQuantity();
                }
                else
                {
                    SEACCMessageBox.Show("Cannot Add Gift Vouchers..", "This is in Item Sale Mode. You can not add Gift Vouchers to it.", MessageBoxButton.OK, "Red");
                }
            }
            frmPosSalesWindow.Effect = null;

            if (dgrItems.Items.Count > 0)
            {
                var border = VisualTreeHelper.GetChild(dgrItems, 0) as Decorator;
                if (border != null)
                {
                    var scroll = border.Child as ScrollViewer;
                    if (scroll != null) scroll.ScrollToEnd();
                }

                dgrItems.CurrentCell = new DataGridCellInfo(dgrItems.Items[dgrItems.Items.Count - 1], dgrItems.Columns[4]);
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    dgrItems.BeginEdit();
                }), System.Windows.Threading.DispatcherPriority.Background);
            }
        }

        #endregion

        #region Shift Between Item Search & Gift Voucher Search

        //Gift Voucher Serch
        private void rdoGiftVoucherSearch_Checked(object sender, RoutedEventArgs e)
        {
            SetEnableDisable_UC_Search("GV_Mode");
        }

        //Item Search
        private void rdoItemSearch_Checked(object sender, RoutedEventArgs e)
        {
            SetEnableDisable_UC_Search("ITEM_Mode");
        }

        #endregion

        private void grd_Transaction_MouseDown(object sender, MouseButtonEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            if (clsSecurity.BranchID != "")
                lstParameeters.Add(clsSecurity.BranchID);

            frmSearchForm RowDataSearch = new frmSearchForm(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.Pos_Transactions);

            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                txtTransactionID.Text = lstResult[0];
                txtTransactionID.Tag = lstResult[0];
                FillDetail_RefreshGridByTransactionID(lstResult[0]);
            }
        }

        private void grdCurrency_MouseDown(object sender, MouseButtonEventArgs e)
        {
            frmSearchForm RowDataSearch = new frmSearchForm();
            List<string> lstResult = RowDataSearch.Show(Search.Currency);

            if (RowDataSearch.DialogResult == true)
            {
                FillDetailsCurrency(lstResult[0]);
                //todo 
                //develop currency change
            }
        }

        #endregion

        #region Events - Checkbox in Transaction Window
        private void chk_Ammounts(object sender, RoutedEventArgs e)
        {
            SetEnabledDisablePopUpFields();
            txtDiscAmount_LostFocus(null, null);
            CalculateTaxesAndGrandTotal();
        }
        #endregion

        #region Events - PoP Ups
        #region Service charges Popup Events
        private void ServiceChargeGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            pop_ServiceCharges.IsOpen = true;
            pop_Discount.IsOpen = false;
            ucItemSearch.pop_Detail.IsOpen = false;
            ucGiftVoucherSearch.pop_Detail.IsOpen = false;
        }

        private void btnServiceChargeOk_Click(object sender, RoutedEventArgs e)
        {
            pop_ServiceCharges.IsOpen = false;
        }

        private void btnServiceChargePopClose_Click(object sender, RoutedEventArgs e)
        {
            pop_ServiceCharges.IsOpen = false;
        }

        private void pop_ServiceCharges_PreviewKeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtServiceChargePct_LostFocus(object sender, RoutedEventArgs e)
        {
            decimal dAccumilatedTotal = clsValidation.Validate_DecimalNumber(tbAccumilatedTotal.Text);
            if (dAccumilatedTotal != 0)
            {
                decimal dServiceChargePecentage = clsValidation.Validate_DecimalNumber(txtServiceChargePct.Text);
                txtServiceChargePct.Tag = GetSavePrice(dServiceChargePecentage, lblCurrencyRate);
                txtServiceChargePct.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(dServiceChargePecentage);
                decimal dServiceChargeAmount = Math.Round(dAccumilatedTotal * dServiceChargePecentage / 100, 2);
                txtServiceChargeAmount.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(dServiceChargeAmount);
                txtServiceChargeAmount.Tag = dServiceChargeAmount;

                SetEnabledDisablePopUpFields();
                CalculateTaxesAndGrandTotal();
            }
        }

        private void txtServiceChargeAmount_LostFocus(object sender, RoutedEventArgs e)
        {
            decimal dAccumilatedTotal = clsValidation.Validate_DecimalNumber(tbAccumilatedTotal.Text);
            if (dAccumilatedTotal != 0)
            {
                decimal dServiceCharge = clsValidation.Validate_DecimalNumber(txtServiceChargeAmount.Text);
                decimal dServiceChargePresentage = dServiceCharge * 100 / dAccumilatedTotal;
                txtServiceChargePct.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(GetSavePrice(dServiceChargePresentage, lblCurrencyRate));
                txtServiceChargePct.Tag = dServiceChargePresentage;
                txtDisc1Amount.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(dServiceCharge);
                txtDisc1Amount.Tag = dServiceCharge;

                SetEnabledDisablePopUpFields();
                CalculateTaxesAndGrandTotal();
            }
        }
        #endregion

        #region Discount PopUp Events

        private void txtDiscPct_LostFocus(object sender, RoutedEventArgs e)
        {
            decimal dSubTotal = clsValidation.Validate_DecimalNumber(tbSubTotal.Text);
            if (dSubTotal != 0)
            {
                decimal dDiscountPresentage1 = 0;
                decimal dDiscountAmount1 = 0;
                if (chkDisc1.IsChecked.Value)
                {
                    dDiscountPresentage1 = clsValidation.Validate_DecimalNumber(txtDisc1Pct.Text);
                    dDiscountAmount1 = Math.Round(dSubTotal * dDiscountPresentage1 / 100, 2);
                }
                txtDisc1Pct.Tag = GetSavePrice(dDiscountPresentage1, lblCurrencyRate);
                txtDisc1Pct.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(dDiscountPresentage1);
                txtDisc1Amount.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(dDiscountAmount1);
                txtDisc1Amount.Tag = dDiscountAmount1;

                decimal dDiscountPresentage2 = 0;
                decimal dDiscountAmount2 = 0;
                if (chkDisc2.IsChecked.Value)
                {
                    dDiscountPresentage2 = clsValidation.Validate_DecimalNumber(txtDisc2Pct.Text);
                    dDiscountAmount2 = Math.Round((dSubTotal - dDiscountAmount1) * dDiscountPresentage2 / 100, 2);
                }
                txtDisc2Pct.Tag = GetSavePrice(dDiscountPresentage2, lblCurrencyRate);
                txtDisc2Pct.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(dDiscountPresentage2);
                txtDisc2Amount.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(dDiscountAmount2);
                txtDisc2Amount.Tag = dDiscountAmount2;

                decimal dDiscountPresentage3 = 0;
                decimal dDiscountAmount3 = 0;
                if (chkDisc3.IsChecked.Value)
                {
                    dDiscountPresentage3 = clsValidation.Validate_DecimalNumber(txtDisc3Pct.Text);
                    dDiscountAmount3 = Math.Round((dSubTotal - dDiscountAmount1 - dDiscountAmount2) * dDiscountPresentage3 / 100, 2);
                }
                txtDisc3Pct.Tag = GetSavePrice(dDiscountPresentage3, lblCurrencyRate);
                txtDisc3Pct.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(dDiscountPresentage3);
                txtDisc3Amount.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(dDiscountAmount3);
                txtDisc3Amount.Tag = dDiscountAmount3;

                SetEnabledDisablePopUpFields();
                CalculateTaxesAndGrandTotal();
            }
        }

        private void txtDiscAmount_LostFocus(object sender, RoutedEventArgs e)
        {
            decimal dSubTotal = clsValidation.Validate_DecimalNumber(tbSubTotal.Text);
            if (dSubTotal != 0)
            {
                decimal dDisount1 = 0;
                decimal discountPresentage1 = 0;
                if (chkDisc1.IsChecked.Value)
                {
                    dDisount1 = clsValidation.Validate_DecimalNumber(txtDisc1Amount.Text);
                    discountPresentage1 = dDisount1 * 100 / dSubTotal;
                    txtDisc1Pct.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(GetSavePrice(discountPresentage1, lblCurrencyRate));
                }
                txtDisc1Pct.Tag = discountPresentage1;
                txtDisc1Amount.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(dDisount1);
                txtDisc1Amount.Tag = dDisount1;

                decimal dDisount2 = 0;
                decimal discountPresentage2 = 0;
                if (chkDisc2.IsChecked.Value)
                {
                    dDisount2 = clsValidation.Validate_DecimalNumber(txtDisc2Amount.Text);
                    if ((dSubTotal - dDisount1) != 0)
                        discountPresentage2 = dDisount2 * 100 / (dSubTotal - dDisount1);
                    txtDisc2Pct.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(GetSavePrice(discountPresentage2, lblCurrencyRate));
                }
                txtDisc2Pct.Tag = discountPresentage2;
                txtDisc2Amount.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(dDisount2);
                txtDisc2Amount.Tag = dDisount2;

                decimal dDisount3 = 0;
                decimal discountPresentage3 = 0;
                if (chkDisc3.IsChecked.Value)
                {
                    dDisount3 = clsValidation.Validate_DecimalNumber(txtDisc3Amount.Text);
                    if ((dSubTotal - dDisount1 - dDisount2) != 0)
                        discountPresentage3 = dDisount3 * 100 / (dSubTotal - dDisount1 - dDisount2);
                    txtDisc3Pct.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(GetSavePrice(discountPresentage3, lblCurrencyRate));
                }
                txtDisc3Pct.Tag = discountPresentage3;
                txtDisc3Amount.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(dDisount3);
                txtDisc3Amount.Tag = dDisount3;

                SetEnabledDisablePopUpFields();
                CalculateTaxesAndGrandTotal();
            }
        }

        private void DiscountGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            pop_Discount.IsOpen = true;
            pop_ServiceCharges.IsOpen = false;
            ucItemSearch.pop_Detail.IsOpen = false;
            ucGiftVoucherSearch.pop_Detail.IsOpen = false;
        }

        private void btnDiscoutPopClose_Click(object sender, RoutedEventArgs e)
        {
            pop_Discount.IsOpen = false;
        }

        private void btnDiscountOk_Click(object sender, RoutedEventArgs e)
        {
            pop_Discount.IsOpen = false;
        }

        private void pop_Discount_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            var uiElement = e.OriginalSource as UIElement;
            if (e.Key == Key.Enter && uiElement != null)
            {
                e.Handled = true;
                btnDiscountOk_Click(null, null);
            }
        }
        #endregion
        #endregion

        #region Events - Payments Dialog Box 
        private void btnPosPayment_Click(object sender, RoutedEventArgs e)
        {
            ofrmPosPayment.tbGrandtotal.Text = tbGrandTotal.Text;
            ofrmPosPayment.tbGrandtotal.Text = tbGrandTotal.Text;
            ofrmPosPayment.dTransactionGrandTotal = clsValidation.Validate_DecimalNumber(tbGrandTotal.Text);
            ofrmPosPayment.Refresh_SelectedPosReceiptDetails();
            ofrmPosPayment.ShowDialog();
        }

        private void grdPaymentsRow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            pop_Discount.IsOpen = false;
            pop_ServiceCharges.IsOpen = false;
            ucItemSearch.pop_Detail.IsOpen = false;
            ucGiftVoucherSearch.pop_Detail.IsOpen = false;

            btnPosPayment_Click(sender, null);
        }

        #endregion

        #region Help Methods - POS Transaction

        //Fill Currency Detials
        private void FillDetailsCurrency(string sCurrencyID)
        {
            try
            {
                lblCurrencyCode.Tag = null;
                lblCurrencyCode.Text = "-";

                if (sCurrencyID.Length > 0)
                {
                    tbl_zCurrency currency = tbl_zCurrency.Select(sCurrencyID);
                    if (currency != null)
                    {
                        lblCurrencyCode.Tag = currency.Currency_ID;
                        lblCurrencyCode.Text = currency.CurrencyCode;
                        lblCurrencyRate.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(currency.CurrencyRate);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", SEACC_Form.Function_ID, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption());
            }
        }

        //Item Grid Total No of Item Set Up
        private void CauculateNoOfItemsAndTotalQuantity()
        {
            tbNoOfItems.Text = dgrItems.Items.Count.ToString();
        }

        //Grid Line (Row) Calculation
        private void CalculateLineAmount(string sColoumn_headerName, string sItem_LineNo, TextBox t)
        {
            decimal lQty = 0, lUnitPrice = 0, lStdDisc = 0, lStdDiscPct = 0, lNetAmount = 0, lAmount = 0;

            DataRow dr = dt_Item.Select("LineNo ='" + sItem_LineNo + "'").FirstOrDefault();
            if (dr != null)
            {
                lUnitPrice = clsValidation.Validate_DecimalNumber(dr["UnitPrice"].ToString());
                lStdDisc = clsValidation.Validate_DecimalNumber(dr["LineDiscAmount_Display"].ToString());
                lStdDiscPct = clsValidation.Validate_DecimalNumber(dr["LineDiscPresent_Display"].ToString());

                switch (sColoumn_headerName)
                {
                    case "Quantity":
                        lQty = clsValidation.Validate_DecimalNumber(dr["Qty"].ToString());
                        if (t != null)
                            lQty = clsValidation.Validate_DecimalNumber(t.Text);
                        lNetAmount = lQty * lUnitPrice;
                        lStdDisc = 0;
                        lStdDiscPct = 0;
                        break;

                    case "Unit Price":
                        lQty = clsValidation.Validate_DecimalNumber(dr["Qty"].ToString());
                        if (t != null)
                            lUnitPrice = clsValidation.Validate_DecimalNumber(t.Text);
                        lNetAmount = lQty * lUnitPrice;
                        lStdDisc = 0;
                        lStdDiscPct = 0;
                        break;

                    case "Std. Disc":
                        lQty = clsValidation.Validate_DecimalNumber(dr["Qty"].ToString());
                        if (t != null)
                            lStdDisc = clsValidation.Validate_DecimalNumber(t.Text) * lQty;
                        lNetAmount = lQty * lUnitPrice;
                        if (lNetAmount != 0)
                            lStdDiscPct = clsValidation.Validate_DecimalNumber((lStdDisc * 100 / lNetAmount).ToString());
                        else
                            lStdDiscPct = 0;
                        break;

                    case "Std. Disc %":
                        lQty = clsValidation.Validate_DecimalNumber(dr["Qty"].ToString());
                        if (t != null)
                            lStdDiscPct = clsValidation.Validate_DecimalNumber(t.Text);
                        lNetAmount = lQty * lUnitPrice;
                        lStdDisc = clsValidation.Validate_DecimalNumber(((lUnitPrice * lStdDiscPct / 100) * lQty).ToString());
                        break;
                }

                lAmount = lNetAmount - lStdDisc;

                dr["UnitPrice"] = lUnitPrice;
                dr["UnitPrice_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(lUnitPrice);
                dr["NetAmount"] = lNetAmount;
                dr["NetAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(lNetAmount);
                dr["LineDiscPresent"] = Math.Round(lStdDiscPct, 2);
                dr["LineDiscPresent_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(Math.Round(lStdDiscPct, 2));
                dr["LineDiscAmount"] = lQty != 0 ? Math.Round(lStdDisc / lQty, clsConfig_POS.iCurrencyDecimalPalces_PoS_Discount) : 0;
                dr["LineDiscAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(lQty != 0 ? Math.Round(lStdDisc / lQty, clsConfig_POS.iCurrencyDecimalPalces_PoS_Discount) : 0);

                dr["IsFreeItem"] = ((lStdDisc == (lUnitPrice * lQty)) && (lUnitPrice != 0)) ? "\uE0A2" : "\uE003";

                dr["AccumulatedAmount"] = lAmount;
                dr["AccumulatedAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(lAmount);
            }
        }

        //Sub Total Calculation
        private void CalcualteSubTotal()
        {
            try
            {
                decimal Amount = 0;
                foreach (DataRow row in dt_Item.Rows)
                {
                    if (row["AccumulatedAmount"] != null && row["AccumulatedAmount"].ToString().Length > 0)
                    {
                        if (clsCommon.isCurrency(row["AccumulatedAmount"].ToString()))
                            Amount += clsValidation.Validate_DecimalNumber(row["AccumulatedAmount"].ToString());
                    }
                }
                tbSubTotal.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(Amount);
                tbSubTotal.Tag = Amount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Taxes Calculation
        private void CalculateTaxesAndGrandTotal()
        {
            tbGrandTotal.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(CalculateGrandTotalBasic(tbSubTotal, txtDisc1Amount, chkDisc1, txtDisc2Amount, chkDisc2, txtDisc3Amount, chkDisc3, tbDiscount, tbAccumilatedTotal, txtServiceChargeAmount, chkServiceCharge,
                tbNBT, tbNBTPresentage, chkNBT, tbVAT, tbVATPresentage, chkVAT, tbOtherTax, tbOtherTaxPresentage, chkOtherTax));
        }

        //Grand Total Calculation
        private decimal CalculateGrandTotalBasic(TextBlock lblSubTotal, TextBox txtDiscount1, CheckBox chkDiscount1, TextBox txtDiscount2, CheckBox chkDiscount2, TextBox txtDiscount3, CheckBox chkDiscount3, TextBlock lblTotalDiscount, TextBlock lblAccuTotal, TextBox txtServiCharges, CheckBox chkServiCharges, TextBlock lblNbt, TextBlock lblNbtRate, CheckBox chkNbt, TextBlock lblVat, TextBlock lblVatRate, CheckBox chkVat, TextBlock lblOtherTax, TextBlock lblOtherTaxRate, CheckBox chkOtherTax)
        {
            decimal dGrandTotal = 0, dSubTotalRunning = 0, dSubTotal = 0, dDiscount1 = 0, dDiscount2 = 0, dDiscount3 = 0, dServiceCharges = 0, dNbt = 0, dNbtRate = 0, dVat = 0, dVatRate = 0, dOtherTax = 0, dOtherTaxRate = 0;

            if (lblSubTotal.Tag != null && lblSubTotal.Tag.ToString().Trim().Length > 0 && clsCommon.isCurrency(lblSubTotal.Tag.ToString().Trim()))
                dSubTotal = dSubTotalRunning = clsValidation.Validate_DecimalNumber(lblSubTotal.Tag.ToString().Trim());

            //Discount Calculation
            #region Discount
            dDiscount1 = clsValidation.Validate_DecimalNumber(txtDiscount1.Text);
            if (chkDiscount1.IsChecked != null && !chkDiscount1.IsChecked.Value)
                dDiscount1 = 0;
            txtDiscount1.Tag = dDiscount1;
            txtDiscount1.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(dDiscount1);
            dSubTotalRunning = (dSubTotalRunning - dDiscount1);

            dDiscount2 = clsValidation.Validate_DecimalNumber(txtDiscount2.Text);
            txtDiscount2.Tag = dDiscount2;
            txtDiscount2.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(dDiscount2);
            if (chkDiscount2.IsChecked != null && !chkDiscount2.IsChecked.Value)
                dDiscount2 = 0;
            dSubTotalRunning = (dSubTotalRunning - dDiscount2);

            dDiscount3 = clsValidation.Validate_DecimalNumber(txtDiscount3.Text);
            txtDiscount3.Tag = dDiscount3;
            txtDiscount3.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(dDiscount3);
            if (chkDiscount3.IsChecked != null && !chkDiscount3.IsChecked.Value)
                dDiscount3 = 0;
            dSubTotalRunning = (dSubTotalRunning - dDiscount3);

            lblTotalDiscount.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(dDiscount1 + dDiscount2 + dDiscount3);
            lblAccuTotal.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(dSubTotalRunning);
            #endregion

            //Service Charge
            #region Service Charges
            dServiceCharges = clsValidation.Validate_DecimalNumber(txtServiCharges.Text);
            if (!chkServiCharges.IsChecked.Value)
                dServiceCharges = 0;
            txtServiCharges.Tag = dServiceCharges;
            txtServiCharges.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(dServiceCharges);
            dSubTotalRunning = (dSubTotalRunning + dServiceCharges);
            #endregion

            //NBT Calculation
            #region NBT
            if (chkNbt.IsChecked.Value)
            {
                if (lblNbtRate.Text != "" && clsCommon.isCurrency(lblNbtRate.Text.Trim()))
                    dNbtRate = clsValidation.Validate_DecimalNumber(lblNbtRate.Text.Trim());


                if (dNbtRate > 0)
                    dNbt = ((dSubTotalRunning * dNbtRate) / 100);

                if (dSubTotalRunning > 0 && dNbt >= 0)
                {
                    dSubTotalRunning = (dSubTotalRunning + dNbt);
                }

                //Assign Values
                lblNbt.Tag = dNbt;
                lblNbt.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(dNbt);
            }
            else
            {
                //Assign Values
                lblNbt.Tag = dNbt;
                lblNbt.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(dNbt);
            }
            #endregion

            //VAT Calculation
            #region VAT
            if (chkVat.IsChecked.Value)
            {
                if (lblVatRate.Text != "" && clsCommon.isCurrency(lblVatRate.Text.Trim()))
                    dVatRate = clsValidation.Validate_DecimalNumber(lblVatRate.Text.Trim());


                if (dVatRate > 0)
                    dVat = ((dSubTotalRunning * dVatRate) / 100);

                if (dSubTotalRunning > 0 && dVat >= 0)
                {
                    dSubTotalRunning = (dSubTotalRunning + dVat);
                }

                //Assign Values
                lblVat.Tag = dVat;
                lblVat.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(dVat);
            }
            else
            {
                //Assign Values
                lblVat.Tag = dVat;
                lblVat.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(dVat);
            }
            #endregion-

            //Other Tax Calculation
            #region Other Tax
            if (chkOtherTax.IsChecked.Value)
            {
                if (lblOtherTaxRate.Text != "" && clsCommon.isCurrency(lblOtherTaxRate.Text.Trim()))
                    dOtherTaxRate = clsValidation.Validate_DecimalNumber(lblOtherTaxRate.Text.Trim());


                if (dOtherTaxRate > 0)
                    dOtherTax = ((dSubTotalRunning * dOtherTaxRate) / 100);

                //if (dSubTotalRunning > 0 && dOtherTax > 0)
                //{
                //    dSubTotalRunning = (dSubTotalRunning + dOtherTax);
                //}

                //Assign Values
                lblOtherTax.Tag = dOtherTax;
                lblOtherTax.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(dOtherTax);
            }
            else
            {
                //Assign Values
                lblOtherTax.Tag = dOtherTax;
                lblOtherTax.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(dOtherTax);
            }
            #endregion

            //Calculate Grand Total
            #region Grand Total
            dGrandTotal = (dSubTotal - dDiscount1 - dDiscount2 - dDiscount3 + dServiceCharges + dNbt + dVat);
            #endregion

            return dGrandTotal;
        }

        //Get The Price with respect to currency rate
        private decimal GetSavePrice(decimal dPrice, TextBlock txtCurrencyRate)
        {
            decimal dUnitPrice = 0, dExRate = 0;
            if (txtCurrencyRate.Text.Trim().Length > 0)
                dExRate = clsValidation.Validate_DecimalNumber(txtCurrencyRate.Text.Trim());

            dUnitPrice = dPrice * dExRate;
            return dUnitPrice;
        }

        //Get Highest Line No with respect to a POS Transaction
        private int GetMaxzimumLineNo_Invoice(int iIndex)
        {
            int iMaxNo = 0;
            foreach (tbl_posTransaction_Detail detail in tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(iIndex))
            {
                if (detail.Line_No > iMaxNo)
                    iMaxNo = detail.Line_No;
            }
            return iMaxNo + 1;
        }


        //Save Method (POS Header Table)
        private void SavePosHeader(bool bIsHold_Bill)
        {
            if (CheckValidity(bIsHold_Bill))
            {
                if (ofrmPosPayment.txtCustomerName.Tag != null || sBranch_CashCustomer != "default")
                {
                    //Incompleted Status
                    bool bIncompletedTx = true;
                    bool bFinalStateSkip = false;

                    try
                    {
                        Cursor = Cursors.Wait;
                        //Update records
                        if (SEACC_Form.IsUpdateMode)
                        {
                            #region Update
                            if (SEACC_Form.PermissionTO_Update)
                            {
                                decimal dSubTotal = GetSavePrice(clsValidation.Validate_DecimalNumber(tbSubTotal.Tag.ToString()), lblCurrencyRate);

                                //Discounts
                                decimal dDiscount_1 = 0;
                                decimal dDiscount_1_pct = 0;
                                if (chkDisc1.IsChecked.Value)
                                {
                                    dDiscount_1 =
                                        GetSavePrice(clsValidation.Validate_DecimalNumber(txtDisc1Amount.Text),
                                            lblCurrencyRate);
                                    if (dSubTotal != 0)
                                        dDiscount_1_pct = decimal.Round((dDiscount_1 * 100 / dSubTotal),
                                            clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                                }

                                decimal dDiscount_2 = 0;
                                decimal dDiscount_2_pct = 0;
                                if (chkDisc2.IsChecked.Value)
                                {
                                    dDiscount_2 =
                                        GetSavePrice(clsValidation.Validate_DecimalNumber(txtDisc2Amount.Text),
                                            lblCurrencyRate);
                                    if ((dSubTotal - dDiscount_1) != 0)
                                        dDiscount_2_pct = decimal.Round((dDiscount_2 * 100 / (dSubTotal - dDiscount_1)),
                                            clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                                }


                                decimal dDiscount_3 = 0;
                                decimal dDiscount_3_pct = 0;
                                if (chkDisc3.IsChecked.Value)
                                {
                                    dDiscount_3 =
                                        GetSavePrice(clsValidation.Validate_DecimalNumber(txtDisc3Amount.Text),
                                            lblCurrencyRate);
                                    if ((dSubTotal - dDiscount_1 - dDiscount_2) != 0)
                                        dDiscount_3_pct =
                                            decimal.Round((dDiscount_3 * 100 / (dSubTotal - dDiscount_1 - dDiscount_2)),
                                                clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                                }

                                //Total Discount
                                decimal dTotalDisc = GetSavePrice(clsValidation.Validate_DecimalNumber(tbDiscount.Text), lblCurrencyRate);
                                decimal dTotalDiscPct = 0;
                                if (dSubTotal != 0)
                                    dTotalDiscPct = decimal.Round((dTotalDisc * 100 / dSubTotal), 2);

                                tbl_posTransaction oPosTrans = tbl_posTransaction.Select(txtTransactionID.Text);

                                #region Check Sales Returns
                                bool bNo_Return = true;
                                foreach (tbl_posTransaction_Detail oPoSReturn_Detail in tbl_posTransaction_Detail.SelectAll().Where(r => r.PrevPosTx_Index == oPosTrans.PosTransaction_Index))
                                {
                                    tbl_posTransaction oCRN = tbl_posTransaction.Select(oPoSReturn_Detail.PosTransaction_Index);
                                    if (oCRN != null && !oCRN.IsDeleted)
                                    {
                                        if (oCRN.IsReturnedPOS_Invoice)
                                        {
                                            bNo_Return = false;
                                            break;
                                        }
                                    }
                                }
                                #endregion

                                if (bNo_Return)
                                {
                                    bool bDayEndCompleted = clsHelpMethods_POS.Check_DayEndComplted_PosTransactionUpdate(oPosTrans);
                                    if (!bDayEndCompleted && oPosTrans != null && !oPosTrans.IsDeleted && !oPosTrans.IsApproved && (oPosTrans.PrintedUser_ID == "default" || oPosTrans.PosTransaction_ID.Contains("HOLD/")))
                                    {
                                        List<tbl_posReceipt> oPosReceipts = tbl_posReceipt.SelectAllByPosTransaction_Index(oPosTrans.PosTransaction_Index);
                                        bool bMessegeBoxResult = true;
                                        if (oPosReceipts.Count > 0)
                                            bMessegeBoxResult = SEACCMessageBox.Show("Transation has more than one receipts", "When you are updating this transaction , all previous payment receipts data will be lost \n Are you sure to continue?", MessageBoxButton.YesNo, "Red");

                                        if (bMessegeBoxResult)
                                        {
                                            #region Get pos transaction ID Auto Gen
                                            if (SEACC_Form.isAutoGenaratedCode)
                                            {
                                                if (!bIsHold_Bill && txtTransactionID.Text.Contains("HOLD/"))
                                                    txtTransactionID.Text = SEACC_Form.getAutoGeneratedCode();
                                                txtTransactionID.Tag = txtTransactionID.Text;
                                            }
                                            #endregion

                                            tbl_posTransaction oPosTransaction_Header = new tbl_posTransaction(
                                                oPosTrans.PosTransaction_Index,
                                                txtTransactionID.Text.Trim(),
                                                clsSecurity.getServerDateTime(),
                                                ofrmPosPayment.txtWarrantyDescription.TextBox1.Text,
                                                ofrmPosPayment.txtCustomerName.Tag != null && ofrmPosPayment.txtCustomerName.Tag.ToString() != "default" ? ofrmPosPayment.txtCustomerName.Tag.ToString() : sBranch_CashCustomer,
                                                ofrmPosPayment.txtCustomerName.TextBox1.Text,
                                                oPosTrans.SalesRep_ID,
                                                sPOS_Store_ID,
                                                oPosTrans.OrderRefNo_ID,
                                                oPosTrans.ItemPriceCategory,
                                                clsConfig.sDefaultSalesNoteTypeID,
                                                lblCurrencyCode.Tag.ToString(),
                                                clsValidation.Validate_DecimalNumber(lblCurrencyRate.Text.Trim()),
                                                dTotalDiscPct,
                                                dDiscount_1_pct,
                                                dDiscount_2_pct,
                                                dDiscount_3_pct,
                                                clsValidation.Validate_DecimalNumber(tbNBTPresentage.Text.Trim()),
                                                clsValidation.Validate_DecimalNumber(tbVATPresentage.Text.Trim()),
                                                clsValidation.Validate_DecimalNumber(tbOtherTaxPresentage.Text.Trim()),
                                                dSubTotal,
                                                dTotalDisc,
                                                dDiscount_1,
                                                dDiscount_2,
                                                dDiscount_3,
                                                GetSavePrice(clsValidation.Validate_DecimalNumber(tbNBT.Tag.ToString()), lblCurrencyRate),
                                                GetSavePrice(clsValidation.Validate_DecimalNumber(tbVAT.Tag.ToString()), lblCurrencyRate),
                                                GetSavePrice(clsValidation.Validate_DecimalNumber(tbOtherTax.Tag.ToString()), lblCurrencyRate),
                                                GetSavePrice(clsValidation.Validate_DecimalNumber(tbGrandTotal.Text.Trim()), lblCurrencyRate),
                                                oPosTrans.CreateUser_ID,
                                                clsSecurity.UserIDLoged,
                                                oPosTrans.CheckedUser_ID,
                                                oPosTrans.ApprovedUser_ID,
                                                oPosTrans.DeletedUser_ID,
                                                oPosTrans.PrintedUser_ID,
                                                oPosTrans.CreateTerminal_ID,
                                                clsSecurity.TerminalID,
                                                oPosTrans.DeletedTerminal_ID,
                                                oPosTrans.PrintedTerminal_ID,
                                                oPosTrans.DateCreate,
                                                clsSecurity.getServerDateTime(),
                                                oPosTrans.DateChecked,
                                                oPosTrans.DateApproved,
                                                oPosTrans.DateDeleted,
                                                oPosTrans.DatePrinted,
                                                oPosTrans.PrintCount,
                                                oPosTrans.IsChecked,
                                                oPosTrans.IsApproved,
                                                bIsHold_Bill,
                                                oPosTrans.IsFinished,
                                                oPosTrans.IsDeleted,
                                                oPosTrans.IsWeightCalculation,
                                                oPosTrans.SeattleAmount,
                                                ofrmPosPayment.rdoFullPayment.IsChecked.Value,
                                                clsSecurity.CompanyID, clsSecurity.BranchID,
                                                int.Parse(ofrmPosPayment.txtCreditPeriod.TextBox1.Text),
                                                ofrmPosPayment.txtGreetngDescription.TextBox1.Text,
                                                iPoS_session_dayDetail_Index, oPosTrans.GlPosting_ID, oPosTrans.PostingStatus_ID, oPosTrans.FinancialYear_ID, false, bGiftVoucher_SalesMode, true
                                                );
                                            oPosTransaction_Header.Update();


                                            foreach (tbl_posTransaction_Detail oDetail in tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(oPosTrans.PosTransaction_Index))
                                            {
                                                clsHelpMethods_POS.UpdateStock(sPOS_Store_ID, oDetail.Item_ID, oDetail.Qty);
                                                oDetail.Delete();
                                            }

                                            foreach (tbl_posReceipt oPosTx_Receipt in tbl_posReceipt.SelectAllByPosTransaction_Index(oPosTrans.PosTransaction_Index))
                                            {
                                                #region Payment Regs
                                                foreach (tbl_bpsChequeRegister oPaymentReg in tbl_bpsChequeRegister.SelectAllByPosReceipt_ID(oPosTx_Receipt.PosReceipt_ID))
                                                {
                                                    tbl_sasInvoice_Sattled.DeleteAllByPosReceipt_ID(oPosTx_Receipt.PosReceipt_ID);

                                                    oPaymentReg.IsDeleted = true;
                                                    oPaymentReg.DateModified = clsSecurity.getServerDateTime();
                                                    oPosTrans.Update();

                                                    if (oPaymentReg.PaymentMethod_ID == (int)PaymentMethod.Gift_Voucher)
                                                    {
                                                        tbl_bpsGiftVoucher oGV = tbl_bpsGiftVoucher.Select(oPaymentReg.GiftVoucherID);
                                                        if (oGV != null)
                                                        {
                                                            oGV.IsRedeemed = false;
                                                            oGV.Update();
                                                        }
                                                    }
                                                    if (oPaymentReg.PaymentMethod_ID == (int)PaymentMethod.Credit_Note)
                                                    {
                                                        tbl_posTransaction oPOS_SRN = tbl_posTransaction.Select(oPaymentReg.PosReturnTransaction_Index);
                                                        if (oPOS_SRN != null)
                                                        {
                                                            foreach (tbl_bpsCreditNote oCRN in tbl_bpsCreditNote.SelectAllByPosReturnTransaction_Index(oPOS_SRN.PosTransaction_Index))
                                                            {
                                                                oCRN.IsSeattled = false;
                                                                oCRN.SeattleAmount = 0;
                                                                oCRN.Update();
                                                            }

                                                            oPOS_SRN.IsSeattled = false;
                                                            oPOS_SRN.SeattleAmount = 0;
                                                            oPOS_SRN.Update();
                                                        }
                                                    }
                                                    if (oPaymentReg.PaymentMethod_ID == (int)PaymentMethod.Advance_Receive)
                                                    {
                                                        tbl_posAdvanceReceived oPOS_Advance = tbl_posAdvanceReceived.Select(oPaymentReg.AdvanceReceived_Index);
                                                        if (oPOS_Advance != null)
                                                        {
                                                            foreach (tbl_bpsCreditNote oCRN in tbl_bpsCreditNote.SelectAllByAdvanceReceived_Index(oPOS_Advance.AdvanceReceived_Index))
                                                            {
                                                                oCRN.IsSeattled = false;
                                                                oCRN.SeattleAmount = 0;
                                                                oCRN.Update();
                                                            }

                                                            oPOS_Advance.IsSetteled = false;
                                                            oPOS_Advance.SetteledAmount = 0;
                                                            oPOS_Advance.Update();
                                                        }
                                                    }

                                                    oPaymentReg.Delete();

                                                }
                                                #endregion

                                                oPosTx_Receipt.Delete();
                                            }

                                            SavePosDetails(oPosTrans.PosTransaction_Index);
                                            SavePosReceipt(bIsHold_Bill, oPosTrans.PosTransaction_Index);

                                            #region Settlement Update
                                            var vPosTXs = tbl_posReceipt.SelectAllByPosTransaction_Index(oPosTrans.PosTransaction_Index);
                                            decimal dSettledAmount = 0;
                                            foreach (var vReceipt in vPosTXs)
                                            {
                                                if (vReceipt != null && !vReceipt.IsDeleted)
                                                    dSettledAmount += vReceipt.TotalAmount;
                                            }
                                            oPosTransaction_Header.SeattleAmount = dSettledAmount;
                                            oPosTransaction_Header.Update();
                                            #endregion

                                            bIncompletedTx = false;
                                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                        }
                                        else
                                        {
                                            bFinalStateSkip = true;
                                        }
                                    }
                                    else
                                    {
                                        if (oPosTrans != null && oPosTrans.IsApproved)
                                        {
                                            bFinalStateSkip = true;
                                            SEACCMessageBox.Show("Cannot Update..", "Selected Transaction has been approved", MessageBoxButton.OK, "Red");
                                        }
                                        else if (bDayEndCompleted)
                                        {
                                            bFinalStateSkip = true;
                                            SEACCMessageBox.Show("Cannot Update..", "Branch Day End has already been completed and approved.", MessageBoxButton.OK, "Red");
                                        }
                                        else if (oPosTrans != null && oPosTrans.IsDeleted)
                                        {
                                            bFinalStateSkip = true;
                                            SEACCMessageBox.Show("Cannot Update..", "Selected Transaction has been cancelled", MessageBoxButton.OK, "Red");
                                        }
                                        else if (oPosTrans != null && oPosTrans.PrintedUser_ID != "default")
                                        {
                                            bFinalStateSkip = true;
                                            SEACCMessageBox.Show("Cannot Update..", "Selected Transaction Bill has already been printed", MessageBoxButton.OK, "Red");
                                        }
                                        else
                                        {
                                            bFinalStateSkip = true;
                                            SEACCMessageBox.Show("Cannot Update..", "", MessageBoxButton.OK, "Red");
                                        }
                                    }

                                }
                                else
                                {
                                    bFinalStateSkip = true;
                                    SEACCMessageBox.Show("Cannot Update..",
                                               "Sales Retun has already been attached to this Transaction Bill", MessageBoxButton.OK, "Red");
                                }
                            }
                            else
                            {
                                bFinalStateSkip = true;
                                SEACCMessageBox.Show("Can not Update..!", "You don't have permission to update", MessageBoxButton.OK, "Red");
                            }
                            #endregion
                        }
                        //Insert records
                        else
                        {
                            if (SEACC_Form.PermissionTO_Write)
                            {
                                #region Insert New POS Customer
                                if (ofrmPosPayment.txtCustomerTelphone.TextBox1.Text.Trim().Length > 5)
                                {
                                    tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.SelectAll().FirstOrDefault(r => r.Telephone.Trim() == ofrmPosPayment.txtCustomerTelphone.TextBox1.Text.Trim());
                                    if (oCustomer == null)
                                    {
                                        string sNextCustomer_ID = clsAutocode.getAutoGeneratedCode("CON/003");//Customer Master
                                        tbl_genCustomerMaster oNewCustomer = new tbl_genCustomerMaster(
                                            sNextCustomer_ID, "",
                                            ofrmPosPayment.txtCustomerName.TextBox1.Text,
                                            ofrmPosPayment.txtCustomerAddress.TextBox1.Text, "",
                                            ofrmPosPayment.txtCustomerTelphone.TextBox1.Text,
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

                                        ofrmPosPayment.txtCustomerName.Tag = oNewCustomer.Customer_ID;
                                    }
                                    else
                                    {
                                        ofrmPosPayment.txtCustomerName.Tag = oCustomer.Customer_ID;
                                    }
                                }
                                #endregion

                                #region Get pos transaction Index Auto Gen
                                int iPK_POSTx = tbl_posTransaction.SelectAll().Max(r => r.PosTransaction_Index) + 1;
                                txtTransactionID.Tag = iPK_POSTx;
                                #endregion

                                #region Insert

                                decimal dSubTotal = GetSavePrice(clsValidation.Validate_DecimalNumber(tbSubTotal.Tag.ToString()), lblCurrencyRate);

                                #region Discounts
                                //Discounts
                                decimal dDiscount_1 = 0;
                                decimal dDiscount_1_pct = 0;
                                if (chkDisc1.IsChecked.Value)
                                {
                                    dDiscount_1 = GetSavePrice(clsValidation.Validate_DecimalNumber(txtDisc1Amount.Text), lblCurrencyRate);
                                    if (dSubTotal != 0)
                                        dDiscount_1_pct = decimal.Round((dDiscount_1 * 100 / dSubTotal), clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                                }

                                decimal dDiscount_2 = 0;
                                decimal dDiscount_2_pct = 0;
                                if (chkDisc2.IsChecked.Value)
                                {
                                    dDiscount_2 =
                                        GetSavePrice(clsValidation.Validate_DecimalNumber(txtDisc2Amount.Text),
                                            lblCurrencyRate);
                                    if ((dSubTotal - dDiscount_1) != 0)
                                        dDiscount_2_pct = decimal.Round((dDiscount_2 * 100 / (dSubTotal - dDiscount_1)),
                                            clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                                }

                                decimal dDiscount_3 = 0;
                                decimal dDiscount_3_pct = 0;
                                if (chkDisc3.IsChecked.Value)
                                {
                                    dDiscount_3 =
                                        GetSavePrice(clsValidation.Validate_DecimalNumber(txtDisc3Amount.Text),
                                            lblCurrencyRate);
                                    if ((dSubTotal - dDiscount_1 - dDiscount_2) != 0)
                                        dDiscount_3_pct =
                                            decimal.Round((dDiscount_3 * 100 / (dSubTotal - dDiscount_1 - dDiscount_2)),
                                                clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                                }

                                //Total Discount
                                decimal dTotalDisc = GetSavePrice(clsValidation.Validate_DecimalNumber(tbDiscount.Text), lblCurrencyRate);
                                decimal dTotalDiscPct = 0;
                                if (dSubTotal != 0)
                                    dTotalDiscPct = decimal.Round((dTotalDisc * 100 / dSubTotal), 2);
                                #endregion

                                #region Insert POS Header
                                tbl_posTransaction oPosTx = new tbl_posTransaction(
                                    iPK_POSTx,
                                    !SEACC_Form.isAutoGenaratedCode ? txtTransactionID.Text.Trim() : iPK_POSTx.ToString("D8"),
                                    clsSecurity.getServerDateTime(),
                                    ofrmPosPayment.txtWarrantyDescription.TextBox1.Text,
                                    ofrmPosPayment.txtCustomerName.Tag != null && ofrmPosPayment.txtCustomerName.Tag.ToString() != "default" ? ofrmPosPayment.txtCustomerName.Tag.ToString() : sBranch_CashCustomer,
                                    ofrmPosPayment.txtCustomerName.TextBox1.Text,
                                    ofrmPosPayment.txtSalesRep.Tag != null ? ofrmPosPayment.txtSalesRep.Tag.ToString() : "default",
                                    sPOS_Store_ID,
                                    "default",
                                    "default",
                                    clsConfig.sDefaultSalesNoteTypeID,
                                    lblCurrencyCode.Tag.ToString(),
                                    clsValidation.Validate_DecimalNumber(lblCurrencyRate.Text.Trim()),
                                    dTotalDiscPct,
                                    dDiscount_1_pct,
                                    dDiscount_2_pct,
                                    dDiscount_3_pct,
                                    clsValidation.Validate_DecimalNumber(tbNBTPresentage.Text.Trim()),
                                    clsValidation.Validate_DecimalNumber(tbVATPresentage.Text.Trim()),
                                    clsValidation.Validate_DecimalNumber(tbOtherTaxPresentage.Text.Trim()),
                                    dSubTotal,
                                    dTotalDisc,
                                    dDiscount_1,
                                    dDiscount_2,
                                    dDiscount_3,
                                    GetSavePrice(clsValidation.Validate_DecimalNumber(tbNBT.Tag.ToString()), lblCurrencyRate),
                                    GetSavePrice(clsValidation.Validate_DecimalNumber(tbVAT.Tag.ToString()), lblCurrencyRate),
                                    GetSavePrice(clsValidation.Validate_DecimalNumber(tbOtherTax.Tag.ToString()), lblCurrencyRate),
                                    GetSavePrice(clsValidation.Validate_DecimalNumber(tbGrandTotal.Text.Trim()), lblCurrencyRate),
                                    clsSecurity.UserIDLoged,
                                    "default",
                                    "default",
                                    "default",
                                    "default",
                                    "default",
                                    clsSecurity.TerminalID,
                                    "default",
                                    "default",
                                    "default",
                                    clsSecurity.getServerDateTime(),
                                    clsValidation.defaultDateTime,
                                    clsValidation.defaultDateTime,
                                    clsValidation.defaultDateTime,
                                    clsValidation.defaultDateTime,
                                    clsValidation.defaultDateTime,
                                    0,
                                    false,
                                    false,
                                    bIsHold_Bill,
                                    false,
                                    false,
                                    0,
                                    0,
                                    ofrmPosPayment.rdoFullPayment.IsChecked.Value,
                                    clsSecurity.CompanyID, clsSecurity.BranchID,
                                    int.Parse(ofrmPosPayment.txtCreditPeriod.TextBox1.Text),
                                    ofrmPosPayment.txtGreetngDescription.TextBox1.Text,
                                    iPoS_session_dayDetail_Index,
                                    "default",
                                    clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction),
                                    clsSecurity.FinancialYearID, false, bGiftVoucher_SalesMode, true
                                    );
                                oPosTx.Insert();

                                txtTransactionID.Text = oPosTx.PosTransaction_ID;
                                txtTransactionID.Tag = oPosTx.PosTransaction_Index;
                                #endregion

                                SavePosDetails(oPosTx.PosTransaction_Index);
                                SavePosReceipt(bIsHold_Bill, oPosTx.PosTransaction_Index);

                                #region Settlement Update
                                var vPosTXs = tbl_posReceipt.SelectAllByPosTransaction_Index(oPosTx.PosTransaction_Index);
                                decimal dSettledAmount = 0;
                                foreach (var vReceipt in vPosTXs)
                                {
                                    if (vReceipt != null && !vReceipt.IsDeleted)
                                        dSettledAmount += vReceipt.TotalAmount;
                                }
                                oPosTx.SeattleAmount = dSettledAmount;
                                oPosTx.Update();
                                #endregion


                                bIncompletedTx = false;
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                                #endregion
                            }
                            else
                            {
                                SEACCMessageBox.Show("Can not Insert..!", "You don't have permission to insert", MessageBoxButton.OK, "Red");
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
                        if (!bFinalStateSkip)
                        {
                            try
                            {
                                Cursor = Cursors.Wait;

                                if (!bIncompletedTx)
                                {
                                    tbl_posTransaction detail = tbl_posTransaction.Select(txtTransactionID.Text.Trim());
                                    if (detail != null)
                                    {
                                        #region Auto Generate Transaction ID

                                        if (SEACC_Form.isAutoGenaratedCode && !SEACC_Form.IsUpdateMode)
                                        {
                                            if (!bIsHold_Bill)
                                                txtTransactionID.Text = SEACC_Form.getAutoGeneratedCode();
                                            else
                                                txtTransactionID.Text =
                                                    "HOLD/" + detail.PosTransaction_Index.ToString("D8");

                                            detail.PosTransaction_ID = txtTransactionID.Text;
                                        }

                                        txtTransactionID.Tag = txtTransactionID.Text;

                                        #endregion

                                        if (clsValidate.CheckValidity_TransactionCodeLength(txtTransactionID.Text))
                                        {
                                            detail.IsIncompleted = false;
                                            detail.Update();

                                            FillDetail_RefreshGridByTransactionID(detail.PosTransaction_ID);
                                        }
                                        else
                                        {
                                            bIncompletedTx = true;
                                        }
                                    }
                                }

                                if (bIncompletedTx)
                                {
                                    //btnDelete_Click(null, null);

                                    Cursor = Cursors.Wait;
                                    tbl_posTransaction oPosTrans =
                                        tbl_posTransaction.Select(int.Parse(txtTransactionID.Tag.ToString()));
                                    if (oPosTrans != null)
                                    {
                                        foreach (tbl_posTransaction_Detail oDetail in tbl_posTransaction_Detail
                                            .SelectAllByPosTransaction_Index(oPosTrans.PosTransaction_Index))
                                            clsHelpMethods_POS.UpdateStock(sPOS_Store_ID, oDetail.Item_ID, oDetail.Qty);

                                        oPosTrans.DeletedUser_ID = clsSecurity.UserIDLoged;
                                        oPosTrans.DateDeleted = clsSecurity.getServerDateTime();
                                        oPosTrans.DeletedTerminal_ID = clsSecurity.TerminalID;
                                        oPosTrans.IsDeleted = true;
                                        oPosTrans.Update();

                                        #region Receipt cancelation

                                        foreach (tbl_posReceipt oReceipt in tbl_posReceipt
                                            .SelectAllByPosTransaction_Index(
                                                oPosTrans.PosTransaction_Index))
                                        {
                                            #region Payment Methods Cancelation

                                            foreach (tbl_bpsChequeRegister oPaymentReg in tbl_bpsChequeRegister
                                                .SelectAllByPosReceipt_ID(oReceipt.PosReceipt_ID))
                                            {
                                                oPaymentReg.IsDeleted = true;
                                                oPaymentReg.DateModified = clsSecurity.getServerDateTime();
                                                oPosTrans.Update();

                                                if (oPaymentReg.PaymentMethod_ID == (int)PaymentMethod.Gift_Voucher)
                                                {
                                                    tbl_bpsGiftVoucher oGV =
                                                        tbl_bpsGiftVoucher.Select(oPaymentReg.GiftVoucherID);
                                                    if (oGV != null)
                                                    {
                                                        oGV.IsRedeemed = false;
                                                        oGV.Update();
                                                    }
                                                }

                                                if (oPaymentReg.PaymentMethod_ID == (int)PaymentMethod.Credit_Note)
                                                {
                                                    tbl_posTransaction oPOS_SRN =
                                                        tbl_posTransaction.Select(
                                                            oPaymentReg.PosReturnTransaction_Index);
                                                    if (oPOS_SRN != null)
                                                    {
                                                        foreach (tbl_bpsCreditNote oCRN in tbl_bpsCreditNote
                                                            .SelectAllByPosReturnTransaction_Index(oPOS_SRN
                                                                .PosTransaction_Index))
                                                        {
                                                            oCRN.IsSeattled = false;
                                                            oCRN.SeattleAmount = 0;
                                                            oCRN.Update();
                                                        }

                                                        oPOS_SRN.IsSeattled = false;
                                                        oPOS_SRN.SeattleAmount = 0;
                                                        oPOS_SRN.Update();
                                                    }
                                                }

                                                if (oPaymentReg.PaymentMethod_ID == (int)PaymentMethod.Advance_Receive)
                                                {
                                                    tbl_posAdvanceReceived oPOS_Advance =
                                                        tbl_posAdvanceReceived.Select(oPaymentReg
                                                            .AdvanceReceived_Index);
                                                    if (oPOS_Advance != null)
                                                    {
                                                        foreach (tbl_bpsCreditNote oCRN in tbl_bpsCreditNote
                                                            .SelectAllByAdvanceReceived_Index(oPOS_Advance
                                                                .AdvanceReceived_Index))
                                                        {
                                                            oCRN.IsSeattled = false;
                                                            oCRN.SeattleAmount = 0;
                                                            oCRN.Update();
                                                        }

                                                        oPOS_Advance.IsSetteled = false;
                                                        oPOS_Advance.SetteledAmount = 0;
                                                        oPOS_Advance.Update();
                                                    }
                                                }
                                            }

                                            #endregion

                                            oReceipt.IsDeleted = true;
                                            oReceipt.DateModified = clsSecurity.getServerDateTime();
                                            oReceipt.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                            oReceipt.Update();
                                        }

                                        #endregion

                                        ClearFields();
                                    }

                                    SEACCMessageBox.Show("Something Went Wrong...!",
                                        "Please Save the Transaction Again...",
                                        MessageBoxButton.OK, "Red");
                                }
                            }
                            catch (Exception e)
                            {
                                SEACCExeption.Show(e);
                            }
                            finally
                            {
                                Cursor = Cursors.Arrow;
                            }
                        }
                        else
                        {
                            Cursor = Cursors.Arrow;
                        }
                    }
                }
                else
                {
                    SEACCMessageBox.Show("Can not Insert..!", "You haven't selected valid customer...", MessageBoxButton.OK, "Red");
                }
            }
        }

        //Save Method (POS Detail Table)
        private void SavePosDetails(int iPosTx_Index)
        {
            foreach (DataRow row in dt_Item.Rows)
            {
                try
                {
                    #region Variable Initialization

                    string sItemID = "default",
                        sRemarks = "";

                    decimal dWeightPrice = 0,
                        dUnitPrice = 0,
                        dQuantity = 0,
                        dWeight = 0,
                        dNetAmount = 0,
                        dDiscountPresentage = 0,
                        dDiscountValue = 0,
                        dAmount = 0;

                    int iGiftVoucherID = -1,
                        iPreviousTrans_ID = -1,
                        iPreviousTrans_ID_LineNo = -1,
                        iItem_Line_No = 0;


                    bool bIsFreeItem = false;

                    //POS Details
                    iItem_Line_No = int.Parse(row["LineNo"].ToString());
                    sItemID = row["ItemCode"].ToString();
                    dUnitPrice = clsValidation.Validate_DecimalNumber(row["UnitPrice"].ToString());
                    dWeightPrice = clsValidation.Validate_DecimalNumber(row["WeightPrice"].ToString());
                    bIsFreeItem = (row["IsFreeItem"].ToString() == "\uE0A2");
                    dQuantity = clsValidation.Validate_DecimalNumber(row["Qty"].ToString());
                    dWeight = clsValidation.Validate_DecimalNumber(row["Weight"].ToString());
                    dNetAmount = clsValidation.Validate_DecimalNumber(row["NetAmount"].ToString());
                    dDiscountPresentage = clsValidation.Validate_DecimalNumber(row["LineDiscPresent"].ToString());
                    dDiscountValue = clsValidation.Validate_DecimalNumber(row["LineDiscAmount"].ToString());
                    dAmount = clsValidation.Validate_DecimalNumber(row["AccumulatedAmount"].ToString());
                    sRemarks = row["Remarks"].ToString();
                    iGiftVoucherID = int.Parse(row["GiftVoucherID"].ToString());
                    iPreviousTrans_ID = int.Parse(row["PreviousTrans_Index"].ToString());
                    iPreviousTrans_ID_LineNo = int.Parse(row["PreviousTrans_Detail_LineNo"].ToString());

                    //Get Unit Price with Exchange rate to save
                    dUnitPrice = GetSavePrice(dUnitPrice, lblCurrencyRate);
                    dWeightPrice = GetSavePrice(dWeightPrice, lblCurrencyRate);
                    dAmount = GetSavePrice(dAmount, lblCurrencyRate);

                    //Validate the Free Item
                    if (dDiscountPresentage == 100m)
                        bIsFreeItem = true;
                    else
                        bIsFreeItem = false;



                    #endregion

                    tbl_genItemMaster oItemMaster = tbl_genItemMaster.Select(sItemID);

                    //tbl_posTransaction Details
                    tbl_posTransaction_Detail oPosDetail = new tbl_posTransaction_Detail(
                        iItem_Line_No, iPosTx_Index,
                        oItemMaster.Item_ID, iGiftVoucherID,
                        sRemarks, dQuantity, dWeight, dUnitPrice, dWeightPrice, bIsFreeItem, dNetAmount,
                        dDiscountPresentage, dDiscountValue, dAmount, iPreviousTrans_ID, iPreviousTrans_ID_LineNo);
                    oPosDetail.Insert();

                    if (!oItemMaster.IsGiftVoucher)
                    {
                        clsHelpMethods_POS.UpdateStock(sPOS_Store_ID, oItemMaster.Item_ID, -dQuantity);
                    }
                    else
                    {
                        tbl_bpsGiftVoucher oGV = tbl_bpsGiftVoucher.Select(iGiftVoucherID);
                        if (oGV != null)
                        {
                            oGV.IsIssued = true;
                            oGV.DateIssued = clsSecurity.getServerDateTime();
                            oGV.DateValidFrom = clsSecurity.getServerDateTime();

                            if (oGV.ValidityDays > 1)
                                oGV.ExpiryDate = oGV.DateIssued.AddDays(oGV.ValidityDays);
                            else
                                oGV.ExpiryDate = clsValidation.defaultDateTime;

                            oGV.Update();
                        }

                        tbl_genItemMaster_Barcode oItem_serial = tbl_genItemMaster_Barcode.Select(oGV.Item_ID, oGV.SerialNo);
                        if (oItem_serial != null)
                        {
                            oItem_serial.IsDelivered = true;
                            oItem_serial.Update();
                        }
                    }
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
            }
        }

        //Save Method (POS Receipt Table)
        private void SavePosReceipt(bool bIsHold_Bill, int iPosTx_Index)
        {

            if (!bIsHold_Bill)
            {
                decimal dPosReceiptTenderedAmount = clsValidation.Validate_DecimalNumber(ofrmPosPayment.txtReceiptTenderedTotal.TextBox1.Text);
                decimal dPosTxBalanceAmount = clsValidation.Validate_DecimalNumber(ofrmPosPayment.txtReceiptBalance.TextBox1.Text);
                decimal dPosReceiptAmount = clsValidation.Validate_DecimalNumber(ofrmPosPayment.txtReceiptTenderedTotal.TextBox1.Text);
                decimal dChangeAmount = 0;
                if (dPosTxBalanceAmount > 0)
                    dChangeAmount = dPosTxBalanceAmount;
                dPosReceiptAmount = dPosReceiptAmount - dChangeAmount;

                tbl_posReceipt oPosReceipt = new tbl_posReceipt("RCP/" + iPosTx_Index.ToString("D8") + "/0",
                                    clsSecurity.getServerDateTime(), iPosTx_Index, "",
                                    ofrmPosPayment.txtCustomerName.Tag != null && ofrmPosPayment.txtCustomerName.Tag.ToString() != "default" ? ofrmPosPayment.txtCustomerName.Tag.ToString() : sBranch_CashCustomer,
                                    "default", "default", "default", clsSecurity.FinancialYearID, "default",
                                    lblCurrencyCode.Tag.ToString(), clsValidation.Validate_DecimalNumber(lblCurrencyRate.Text.Trim()),
                                    clsValidation.Validate_DecimalNumber(ofrmPosPayment.txtCashPaymentstotal.TextBox1.Text),
                                    clsValidation.Validate_DecimalNumber(ofrmPosPayment.txtChequesAmountTotal.TextBox1.Text),
                                    dPosReceiptAmount,
                                    clsCommon.CurrencyToWord(dPosReceiptAmount),
                                    dPosReceiptTenderedAmount,
                                    dPosTxBalanceAmount,
                                    dChangeAmount,
                                    clsSecurity.UserIDLoged,
                                    "default",
                                    "default",
                                    "default",
                                    "default",
                                    clsSecurity.getServerDateTime(),
                                    clsValidation.defaultDateTime,
                                    clsValidation.defaultDateTime,
                                    clsValidation.defaultDateTime,
                                    clsValidation.defaultDateTime,
                                    false,
                                    false,
                                    false,
                                    false,
                                    false,
                                    0, //Print Count
                                    ofrmPosPayment.rdoPartPayment.IsChecked == true,
                                    ofrmPosPayment.rdoFullPayment.IsChecked == true,
                                    ofrmPosPayment.rdoAdavancePayment.IsChecked == true,
                                    false, 0, false, clsSecurity.CompanyID, clsSecurity.BranchID, (-1));
                oPosReceipt.Insert();
                
                SavePosPaymentRegisterDetails_Receipt(oPosReceipt);
            }
        }

        //Save Method (Payment Register Table)
        private void SavePosPaymentRegisterDetails_Receipt(tbl_posReceipt oPosReceipt)
        {
            string sCustomerTx = ofrmPosPayment.txtCustomerName.Tag != null && ofrmPosPayment.txtCustomerName.Tag.ToString() != "default"
                  ? ofrmPosPayment.txtCustomerName.Tag.ToString()
                  : sBranch_CashCustomer;

            #region Card Payments
            foreach (DataRow row in ofrmPosPayment.dtCardPayment.Rows)
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
                    (ofrmPosPayment.txtMerchantDevice.Tag != null ? (int.Parse(ofrmPosPayment.txtMerchantDevice.Tag.ToString())) : (-1)),
                    sEnctyptLastFourDigits
                    , sEnctyptNameOnCard, iCardTypeID, (-1), clsValidation.defaultDateTime, sCustomerTx, "", "", -1, sBankID, "default", "default", "default", "default", "default", "default", oPosReceipt.PosTransaction_Index.ToString(), "default", oPosReceipt.PosReceipt_ID, "default", "default", "", "default", "default", "default", clsSecurity.FinancialYearID, dAmount, false, false, false, false, false, false, false, clsSecurity.UserIDLoged, "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, false, false, 0, 0, 0, 0, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.CompanyID, clsSecurity.BranchID, (-1), (-1), (-1));
                oPayReg.Insert();

                //POS Transaction Settlement
                SavePosTransaction_Settlement(oPosReceipt.PosReceipt_ID, sPayRegCode, dAmount);
            }
            #endregion

            #region Gift Vouchers
            foreach (DataRow row in ofrmPosPayment.dtGiftVoucherPayment.Rows)
            {
                int iGiftVoucherID = Convert.ToInt16(clsValidate.ValidateRowValue(row, "VoucherID", -1));
                decimal dVoucherAmount = clsValidate.ValidateRowValue(row, "VoucherAmount", 0m);

                string sPayRegCode = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.ChequeRegister));

                //Gift voucher Redeem
                tbl_bpsGiftVoucher oGiftVoucher = tbl_bpsGiftVoucher.Select(iGiftVoucherID);
                if (oGiftVoucher != null)
                {
                    oGiftVoucher.IsRedeemed = true;
                    oGiftVoucher.PosTransaction_ID = txtTransactionID.Text;
                    oGiftVoucher.SetteledAmount = oGiftVoucher.VoucherAmount;
                    oGiftVoucher.Update();
                }

                tbl_bpsChequeRegister oPayReg = new tbl_bpsChequeRegister(sPayRegCode, "", clsSecurity.getServerDateTime(), (int)PaymentMethod.Gift_Voucher, (-1), "", iGiftVoucherID, (-1), "", "", (-1), (-1), clsValidation.defaultDateTime, sCustomerTx, "", "", -1, "default", "default", "default", "default", "default", "default", "default", oPosReceipt.PosTransaction_Index.ToString(), "default", oPosReceipt.PosReceipt_ID, "default", "default", "", "default", "default", "default", clsSecurity.FinancialYearID, dVoucherAmount, false, false, false, false, false, false, false, clsSecurity.UserIDLoged, "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, false, false, 0, 0, 0, 0, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.CompanyID, clsSecurity.BranchID, (-1), (-1), (-1));
                oPayReg.Insert();

                //POS Transaction Settlement
                SavePosTransaction_Settlement(oPosReceipt.PosReceipt_ID, sPayRegCode, dVoucherAmount);
            }
            #endregion

            #region CRNs - Sales Return
            foreach (DataRow row in ofrmPosPayment.dtCRN_SalesReturn.Rows)
            {
                int iPosReturnTransaction_Index = Convert.ToInt16(clsValidate.ValidateRowValue(row, "CRN_Index", -1));
                decimal dVoucherAmount = clsValidate.ValidateRowValue(row, "CRN_Amount", 0m);

                string sPayRegCode = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.ChequeRegister));

                //CRN Settled
                tbl_posTransaction oPosReturn = tbl_posTransaction.Select(iPosReturnTransaction_Index);
                if (oPosReturn != null)
                {
                    oPosReturn.IsSeattled = true;
                    oPosReturn.SeattleAmount = dVoucherAmount;
                    oPosReturn.Update();

                    tbl_bpsCreditNote oCRN = tbl_bpsCreditNote.SelectAllByPosReturnTransaction_Index(oPosReturn.PosTransaction_Index).FirstOrDefault();
                    if (oCRN != null)
                    {
                        oCRN.SeattleAmount = dVoucherAmount;
                        oCRN.IsSeattled = true;
                        oCRN.Update();
                    }
                }

                tbl_bpsChequeRegister oPayReg = new tbl_bpsChequeRegister(sPayRegCode, "", clsSecurity.getServerDateTime(), (int)PaymentMethod.Credit_Note, (-1), "", (-1), (-1), "", "", (-1), (-1), clsValidation.defaultDateTime, sCustomerTx, "", "", -1, "default", "default", "default", "default", "default", "default", "default", oPosReceipt.PosTransaction_Index.ToString(), "default", oPosReceipt.PosReceipt_ID, "default", "default", "", "default", "default", "default", clsSecurity.FinancialYearID, dVoucherAmount, false, false, false, false, false, false, false, clsSecurity.UserIDLoged, "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, false, false, 0, 0, 0, 0, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.CompanyID, clsSecurity.BranchID, iPosReturnTransaction_Index, (-1), (-1));
                oPayReg.Insert();

                //POS Transaction Settlement
                SavePosTransaction_Settlement(oPosReceipt.PosReceipt_ID, sPayRegCode, dVoucherAmount);
            }
            #endregion

            #region Advance
            foreach (DataRow row in ofrmPosPayment.dtAdvance.Rows)
            {
                int iPosAdvance_Index = Convert.ToInt16(clsValidate.ValidateRowValue(row, "Advance_Index", -1m));
                decimal dAdvanceAmount = clsValidate.ValidateRowValue(row, "Advance_Amount", 0m);
                string sPayRegCode = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.ChequeRegister));

                //Advance Settled
                tbl_posAdvanceReceived oAdavnce = tbl_posAdvanceReceived.Select(iPosAdvance_Index);
                if (oAdavnce != null)
                {
                    oAdavnce.IsSetteled = true;
                    oAdavnce.SetteledAmount = dAdvanceAmount;
                    oAdavnce.Update();

                    tbl_bpsCreditNote oCRN = tbl_bpsCreditNote.SelectAllByAdvanceReceived_Index(oAdavnce.AdvanceReceived_Index).FirstOrDefault();
                    if (oCRN != null)
                    {
                        oCRN.SeattleAmount = dAdvanceAmount;
                        oCRN.IsSeattled = true;
                        oCRN.Update();
                    }
                }

                tbl_bpsChequeRegister oPayReg = new tbl_bpsChequeRegister(sPayRegCode, "", clsSecurity.getServerDateTime(), (int)PaymentMethod.Advance_Receive, (-1), "", (-1), (-1), "", "", (-1), (-1), clsValidation.defaultDateTime, sCustomerTx, "", "", -1, "default", "default", "default", "default", "default", "default", "default", oPosReceipt.PosTransaction_Index.ToString(), "default", oPosReceipt.PosReceipt_ID, "default", "default", "", "default", "default", "default", clsSecurity.FinancialYearID, dAdvanceAmount, false, false, false, false, false, false, false, clsSecurity.UserIDLoged, "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, false, false, 0, 0, 0, 0, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.CompanyID, clsSecurity.BranchID, (-1), iPosAdvance_Index, (-1));
                oPayReg.Insert();

                //POS Transaction Settlement
                SavePosTransaction_Settlement(oPosReceipt.PosReceipt_ID, sPayRegCode, dAdvanceAmount);
            }
            #endregion

            #region Cheque Payments
            foreach (DataRow row in ofrmPosPayment.dtChequePayment.Rows)
            {
                string sAccount_No = clsValidate.ValidateRowValue(row, "Account_No", ""); //Customer's Accout No
                string sBankID = clsValidate.ValidateRowValue(row, "BankID", ""); // Customer's Bank
                string sBankBranchID = clsValidate.ValidateRowValue(row, "BankBranchID", ""); // Customer's Bank Branch
                string sChequeNo = clsValidate.ValidateRowValue(row, "ChequeNo", "");
                DateTime dtmChequeDate = clsValidate.ValidateRowValue(row, "ChequeDate", clsValidation.defaultDateTime);
                decimal dChequeAmount = clsValidate.ValidateRowValue(row, "ChequeAmount", 0m);

                string sPayRegCode = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.ChequeRegister));

                tbl_bpsChequeRegister oPayReg = new tbl_bpsChequeRegister(sPayRegCode, "", clsSecurity.getServerDateTime(), (int)PaymentMethod.Cheque, (-1), "", (-1), (-1), "", "", (-1), (-1), dtmChequeDate, sCustomerTx, sAccount_No, "", -1, sBankID, "default", sBankBranchID, "default", ((int)ChequeStatus.New).ToString(), "0", "default", oPosReceipt.PosTransaction_Index.ToString(), "default", oPosReceipt.PosReceipt_ID, "default", "default", sChequeNo, "default", "default", "default", clsSecurity.FinancialYearID, dChequeAmount, false, false, false, false, false, false, false, clsSecurity.UserIDLoged, "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, false, false, 0, 0, 0, 0, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.CompanyID, clsSecurity.BranchID, (-1), (-1), (-1));
                oPayReg.Insert();

                //POS Transaction Settlement
                SavePosTransaction_Settlement(oPosReceipt.PosReceipt_ID, sPayRegCode, dChequeAmount);
            }
            #endregion

            #region Cash Payment
            string sCashPayRegCode = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.ChequeRegister));
            string sCashCustomerName = ofrmPosPayment.txtWarrantyDescription.TextBox1.Text;
            decimal dCashAmount = oPosReceipt.CashAmount;
            if (dCashAmount != 0)
            {
                tbl_bpsChequeRegister oCashPayReg = new tbl_bpsChequeRegister(sCashPayRegCode, "", clsSecurity.getServerDateTime(), (int)PaymentMethod.Cash, (-1), "", (-1), (-1), "", sCashCustomerName, (-1), (-1), clsValidation.defaultDateTime, sCustomerTx, "", "", -1, "default", "default", "default", "default", "default", "default", "default", oPosReceipt.PosTransaction_Index.ToString(), "default", oPosReceipt.PosReceipt_ID, "default", "default", "", "default", "default", "default", clsSecurity.FinancialYearID, dCashAmount, false, false, false, false, false, false, false, clsSecurity.UserIDLoged, "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, false, false, 0, 0, 0, 0, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.CompanyID, clsSecurity.BranchID, (-1), (-1), (-1));
                oCashPayReg.Insert();

                //POS Transaction Settlement
                SavePosTransaction_Settlement(oPosReceipt.PosReceipt_ID, sCashPayRegCode, oCashPayReg.Amount);
            }
            #endregion

            #region Cash Payment
            string sRewardPayRegCode = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.ChequeRegister));
            string sRewardCustomerName = ofrmPosPayment.txtWarrantyDescription.TextBox1.Text;
            decimal dRewardAmount = clsValidation.Validate_DecimalNumber(ofrmPosPayment.txtRewardTotal.TextBox1.Text);
            if (dRewardAmount != 0)
            {
                tbl_bpsChequeRegister oRewardReg = new tbl_bpsChequeRegister(sRewardPayRegCode, "", clsSecurity.getServerDateTime(), (int)PaymentMethod.OneGalleFaceRwards, (-1), "", (-1), (-1), "", sRewardCustomerName, (-1), (-1), clsValidation.defaultDateTime, sCustomerTx, "", "", -1, "default", "default", "default", "default", "default", "default", "default", oPosReceipt.PosTransaction_Index.ToString(), "default", oPosReceipt.PosReceipt_ID, "default", "default", "", "default", "default", "default", clsSecurity.FinancialYearID, dRewardAmount, false, false, false, false, false, false, false, clsSecurity.UserIDLoged, "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, false, false, 0, 0, 0, 0, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.CompanyID, clsSecurity.BranchID, (-1), (-1), (-1));
                oRewardReg.Insert();

                //POS Transaction Settlement
                SavePosTransaction_Settlement(oPosReceipt.PosReceipt_ID, sRewardPayRegCode, oRewardReg.Amount);
            }
            #endregion

            #region Cash Change Amount
            string sCashChangeRegCode = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.ChequeRegister));
            string sCashChangeustomerName = ofrmPosPayment.txtWarrantyDescription.TextBox1.Text;
            decimal dCashChangeAmount = -oPosReceipt.ChangeAmount;
            if (dCashChangeAmount != 0)
            {
                tbl_bpsChequeRegister oCashChangeReg = new tbl_bpsChequeRegister(sCashChangeRegCode, "", clsSecurity.getServerDateTime(), (int)PaymentMethod.Cash, (-1), "", (-1), (-1), "", sCashChangeustomerName, (-1), (-1), clsValidation.defaultDateTime, sCustomerTx, "", "", -1, "default", "default", "default", "default", "default", "default", "default", oPosReceipt.PosTransaction_Index.ToString(), "default", oPosReceipt.PosReceipt_ID, "default", "default", "", "default", "default", "default", clsSecurity.FinancialYearID, dCashChangeAmount, false, false, true, false, false, false, false, clsSecurity.UserIDLoged, "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, false, false, 0, 0, 0, dCashChangeAmount, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.CompanyID, clsSecurity.BranchID, (-1), (-1), (-1));
                oCashChangeReg.Insert();

                tbl_bpsChequeRegister oCashPayment = tbl_bpsChequeRegister.SelectAllByPosReceipt_ID(oPosReceipt.PosReceipt_ID).Where(r => r.Amount > 0).OrderBy(o => o.PaymentMethod_ID).FirstOrDefault();
                if (oCashPayment != null)
                {
                    oCashPayment.DepositedCashAmount = -dCashChangeAmount;
                    oCashPayment.Update();
                }

                //POS Transaction Settlement
                SavePosTransaction_Settlement(oPosReceipt.PosReceipt_ID, sCashChangeRegCode, oCashChangeReg.Amount);
            }
            #endregion
        }

        //Save Method (Settlements)
        private void SavePosTransaction_Settlement(string sPosReceipt_ID, string sPaymentRegister_ID, decimal dPaymentAmount)
        {
            try
            {
                string sSettleCode = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.bssInvoiceSettlement));
                tbl_sasInvoice_Sattled oPosSettled = new tbl_sasInvoice_Sattled(sSettleCode, "default", "default", -1, txtTransactionID.Text.Trim(), "default", sPosReceipt_ID, sPaymentRegister_ID, "default", "default", "default", -1, "default", "default", clsSecurity.getServerDateTime(), dPaymentAmount, true, clsValidation.defaultDateTime, "default", false, false, "default", "default");
                oPosSettled.Insert();
            }
            catch (Exception e)
            {
                SEACCExeption.Show(e);
            }
        }

        //Item & Gift Voucher Search Enable, Disable
        private void SetEnableDisable_UC_Search(string sSearchSelectMode)
        {
            switch (sSearchSelectMode)
            {
                case "ITEM_Mode":
                    stpSellingModeRadioButtons.Visibility = Visibility.Visible;

                    ucGiftVoucherSearch.IsEnabled = false;
                    ucGiftVoucherSearch.Visibility = Visibility.Hidden;
                    ucGiftVoucherSearch.pop_Detail.IsOpen = false;

                    ucItemSearch.IsEnabled = true;
                    ucItemSearch.Visibility = Visibility.Visible;
                    ucItemSearch.txtFillter.Focus();
                    break;

                case "GV_Mode":
                    stpSellingModeRadioButtons.Visibility = Visibility.Visible;

                    ucGiftVoucherSearch.IsEnabled = true;
                    ucGiftVoucherSearch.Visibility = Visibility.Visible;
                    ucGiftVoucherSearch.txtFillter.Focus();

                    ucItemSearch.IsEnabled = false;
                    ucItemSearch.Visibility = Visibility.Hidden;
                    ucItemSearch.pop_Detail.IsOpen = false;
                    break;
            }
        }

        #endregion

        private void Calculate_WholeGrid_Claculations()
        {
            foreach (DataRow row in dt_Item.Rows)
            {
                decimal dQty = clsValidate.ValidateRowValue(row, "Qty", 0m);
                decimal dUnit_Price = clsValidate.ValidateRowValue(row, "UnitPrice", 0m);
                decimal dLineDiscount = clsValidate.ValidateRowValue(row, "LineDiscAmount", 0m);

                decimal dNetAmount = dQty * dUnit_Price;
                decimal dAccumulatedAmount = dQty * (dUnit_Price - dLineDiscount);

                row["Qty"] = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
                row["NetAmount"] = dNetAmount;
                row["NetAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dNetAmount);
                row["LineDiscAmount"] = dLineDiscount;
                row["LineDiscAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dLineDiscount);
                row["AccumulatedAmount"] = dAccumulatedAmount;
                row["AccumulatedAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dAccumulatedAmount);
            }

            CalcualteSubTotal();
            CalculateTaxesAndGrandTotal();
            CauculateNoOfItemsAndTotalQuantity();
        }

    }
}
