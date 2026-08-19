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
    public partial class Frm_Item_Returns : Window
    {
        #region Class Variables 
        //PoS Session Index
        private int iPoS_session_dayDetail_Index;

        //Validation Variables
        private string sField_ValidityMsg = "";
        private string sPrevCellVal = "";

        private string sPOS_Store_ID = string.Empty;

        //Sales Item Table
        private DataTable dt_Item = new DataTable();

        //Payment Window (This is completely tightly coupled with POS Sales Window)
        private Frm_PosPayment_Returns ofrmPosReturnAmount = new Frm_PosPayment_Returns();

        public object lblCurrencyRate { get; private set; }

        #endregion

        #region Form Load
        public Frm_Item_Returns(int iSession_dayDetail_Index)
        {
            #region Initialize Form
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.POS_SalesReturn;
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


            #region Search Initialize
            ucItemSearch.Refresh_Search(Search.Pos_ItemSearch_Main);

            ucPreTransactionSearch.Refresh_Search(Search.Pos_Transactions_CancelFilter);
            ucPreTransactionSearch.pbxImage.Visibility = Visibility.Collapsed;

            #endregion

            //Set Cashier 
            usrIndicator.UserName = clsSecurity.UserNameLoged;
            R2logoSoftware.lblsoftwareName.Content = clsConfig.sPoS_SystemName;

            #endregion

            #region Initialize Data Table
            dt_Item.Columns.Add("ItemCode");
            dt_Item.Columns.Add("Desc");
            dt_Item.Columns.Add("UOM");
            dt_Item.Columns.Add("QTY", typeof(string));
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
            dt_Item.Columns.Add("Remarks", typeof(string));
            dt_Item.Columns.Add("GiftVoucherID", typeof(int));
            dt_Item.Columns.Add("PreviousTrans_Index", typeof(string));//For Identifying Sales Return Transaction
            dt_Item.Columns.Add("PreviousTrans_Detail_LineNo", typeof(string));//For Identifying Sales Returns Transaction Item
            dt_Item.Columns.Add("PreviousTrans_ID_Dispaly", typeof(string));//For Diaplaying Purpose
            #endregion

            #region Transaction Action Buttons
            ofrmPosReturnAmount.TransactionEnterAndTender += btnPaymentEnterTender_Click;
            ofrmPosReturnAmount.TransactionSave += btnSave_Click;
            ofrmPosReturnAmount.TransactionPrint += btnPrint_Click;
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
                else if (ucPreTransactionSearch.IsEnabled)
                    ucPreTransactionSearch.txtFillter.Focus();
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
                ucPreTransactionSearch.pop_Detail.IsOpen = false;
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
                    tbl_posTransaction oPos_Return = tbl_posTransaction.Select(int.Parse(txtTransactionID.Tag.ToString().Trim()));
                    if (oPos_Return != null)
                    {
                        var oCRN_Prv = tbl_bpsCreditNote.SelectAllByPosReturnTransaction_Index(oPos_Return.PosTransaction_Index).Where(r => r.IsSeattled);
                        if (oCRN_Prv == null || oCRN_Prv.Count() <= 0)
                        {
                            tbl_posDayStartAndEnd_Detail oPos_Session = tbl_posDayStartAndEnd_Detail.Select(oPos_Return.DayDetail_Index);
                            tbl_posDayStartAndEnd oPos_Day = tbl_posDayStartAndEnd.Select(oPos_Session.DayIndex);
                            if (oPos_Day != null && !oPos_Day.IsApproved)
                            {
                                if (!oPos_Return.IsDeleted)
                                {
                                    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                                    if (bMessegeBoxResult)
                                    {
                                        frm_TwoStepVerification_UserChange frmTwoStepVerify = new frm_TwoStepVerification_UserChange((int)SEACC_Form.enmFormName, false, false, true);
                                        frmTwoStepVerify.ShowDialog();
                                        if (frmTwoStepVerify.bVerified)
                                        {
                                            foreach (tbl_posTransaction_Detail oDetail in tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(oPos_Return.PosTransaction_Index))
                                                clsHelpMethods_POS.UpdateStock(sPOS_Store_ID, oDetail.Item_ID, -oDetail.Qty);

                                            foreach (tbl_bpsCreditNote oCRN in tbl_bpsCreditNote.SelectAllByPosReturnTransaction_Index(oPos_Return.PosTransaction_Index))
                                            {
                                                oCRN.IsDeleted = true;
                                                oCRN.DeletedTerminal_ID = clsSecurity.TerminalID;
                                                oCRN.DateModified = clsSecurity.getServerDateTime();
                                                oCRN.Update();
                                            }

                                            oPos_Return.IsDeleted = true;
                                            oPos_Return.Update();

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
                            SEACCMessageBox.Show("Cannot Update..", "Credit Note has already settled", MessageBoxButton.OK, "Red");
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
            try
            {
                Cursor = Cursors.Wait;
                BillPrint glb_dtsBillPrinting = new BillPrint();
                if (!clsConfig_POS.bPOSBillPrint_UsingReportWriter)
                {
                    #region Crystal Report Bill
                    try
                    {
                        string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";

                        if (clsHelpMethods_POS.GetReportPath((int)enum_ReportName.POS_Return_NotePrint, true, ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                        {
                            glb_dtsBillPrinting.dt_Company.Rows.Clear();
                            glb_dtsBillPrinting.dt_pos_transaction.Rows.Clear();
                            glb_dtsBillPrinting.dt_pos_transation_details.Rows.Clear();
                            glb_dtsBillPrinting.dt_pos_receipt.Rows.Clear();

                            string sDuplicateCopy = "";

                            if (sReportPath.Length == 3)
                                return;


                            tbl_genCompanyBranchMaster oBranch = tbl_genCompanyBranchMaster.Select(clsSecurity.BranchID);
                            tbl_posTransaction oPosTx_Return = tbl_posTransaction.Select(int.Parse(txtTransactionID.Tag.ToString()));
                            CompanyImages oComImages = clsCommon_POS.getCompanyImages();
                            if (oPosTx_Return != null && oBranch != null)
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
                                List<tbl_posTransaction_Detail> details = tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(oPosTx_Return.PosTransaction_Index).OrderBy(p => p.Line_No).ToList();
                                foreach (tbl_posTransaction_Detail detail in details)
                                {
                                    glb_dtsBillPrinting.dt_pos_transation_details.Adddt_pos_transation_detailsRow(
                                        detail.Line_No,
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
                                        -detail.Qty,
                                        detail.Weight,
                                        detail.UnitPrice,
                                        detail.WeightPrice,
                                        -detail.NetAmount,
                                        detail.LineDiscountPresentage,
                                        detail.LineDiscountTotal,
                                        -detail.GrossAmount);
                                }
                                #endregion

                                #region Update Print Count and check whether it is duplicate copy or not
                                sDuplicateCopy = (oPosTx_Return.PrintCount > 1) ? "Reprint" : "";
                                oPosTx_Return.PrintCount += 1;
                                oPosTx_Return.PrintedUser_ID = clsSecurity.UserIDLoged;
                                oPosTx_Return.DatePrinted = clsSecurity.getServerDateTime();
                                oPosTx_Return.PrintedTerminal_ID = clsSecurity.TerminalID;
                                oPosTx_Return.Update();
                                #endregion

                                #region Fill POS Transaction Header
                                glb_dtsBillPrinting.dt_pos_transaction.Adddt_pos_transactionRow(oPosTx_Return.PosTransaction_ID,
                                            oPosTx_Return.PosTransactiondate,
                                            oPosTx_Return.Remark,
                                            oPosTx_Return.Customer_ID,
                                            "",
                                            "",
                                            clsGenaralName.getName_CurrencyCode(oPosTx_Return.Currency_ID),
                                            oPosTx_Return.CurrencyRate,
                                            oPosTx_Return.DiscountPercentage,
                                            oPosTx_Return.NbtPercentage,
                                            oPosTx_Return.VatPercentage,
                                            oPosTx_Return.OtherTaxPercentage,
                                            oPosTx_Return.SubTotal,
                                            "Return Receipt No",
                                            0, //return receipt amount
                                            oPosTx_Return.DiscountTotal,
                                            oPosTx_Return.NbtTotal,
                                            oPosTx_Return.VatTotal,
                                            oPosTx_Return.OtherTaxTotal,
                                            oPosTx_Return.GrandTotal,
                                            oPosTx_Return.CreateUser_ID,
                                            oPosTx_Return.ModifiedUser_ID,
                                            oPosTx_Return.IsChecked,
                                            oPosTx_Return.IsApproved,
                                            false,
                                            oPosTx_Return.IsDeleted,
                                            0,
                                            0,
                                            oPosTx_Return.IsSeattled,
                                            clsGenaralName.getName_Customer(oPosTx_Return.Customer_ID),
                                            clsGenaralName.getName_CustomerRegisterAddress(oPosTx_Return.Customer_ID),
                                            clsGenaralName.getName_CustomerTelephone(oPosTx_Return.Customer_ID),
                                            clsGenaralName.getVATRegNo_Customer(oPosTx_Return.Customer_ID),
                                             clsGenaralName.getName_CompanyBranchMaster(oPosTx_Return.CompanyBranch_ID), //Branch
                                             "", //Terminal
                                            clsGenaralName.getName_User(oPosTx_Return.CreateUser_ID),  // Cashier
                                            sDuplicateCopy, 0, "", 0
                                            );
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
                ofrmPosReturnAmount.Hide();
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

        // Save or Update Button Click
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SavePosHeader(false);
        }

        // Enter & Tender Button Click
        private void btnPaymentEnterTender_Click(object sender, RoutedEventArgs e)
        {
            btnSave_Click(sender, e);
            if (txtTransactionID.Text.Length > 0 && txtTransactionID.Text != "<<Auto Generated>>")
                btnPrint_Click(sender, e);
        }

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;


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
            btnDelete.Background = (Brush)(new BrushConverter().ConvertFrom("#FF431621"));//#FF0091EA
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

            //#region Load Discount names
            //foreach (tbl_zDiscount oDiscount in tbl_zDiscount.SelectAll())
            //{
            //    switch (oDiscount.Discount_Id)
            //    {
            //        case "D001":
            //            chkDisc1.Content = oDiscount.DiscountName;
            //            break;
            //        case "D002":
            //            chkDisc2.Content = oDiscount.DiscountName;
            //            break;
            //        case "D003":
            //            chkDisc3.Content = oDiscount.DiscountName;
            //            break;
            //        default:
            //            break;
            //    }
            //}
            //#endregion

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
            tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItemID);
            if (oItem != null)
            {
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
                dr["QTY"] = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
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
                dr["Remarks"] = "";
                dr["GiftVoucherID"] = -1;
                dr["PreviousTrans_Index"] = -1;
                dr["PreviousTrans_Detail_LineNo"] = -1;
                dr["PreviousTrans_ID_Dispaly"] = "";

                dt_Item.Rows.Add(dr);
            }
        }

        private void RefreshGridByPreviousPOS_TxIndex(int iPOS_Tx_Index)
        {
            List<tbl_posTransaction_Detail> details = tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(iPOS_Tx_Index).Where(r => r.Qty > 0).OrderBy(p => p.Line_No).ToList();
            foreach (tbl_posTransaction_Detail detail in details)
            {
                tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                if (item != null)
                {
                    decimal dQty = Math.Round(clsHelpMethods_POS.Get_PendingReturn_Qty(detail.Line_No, detail.PosTransaction_Index, !SEACC_Form.IsUpdateMode ? -1 : int.Parse( txtTransactionID.Tag.ToString()) ), 2);
                    if (dQty > 0)
                    {
                        decimal dExRate = 0;
                        if (lblCurrencyRate.Text.Trim().Length > 0)
                            dExRate = clsValidation.Validate_DecimalNumber(lblCurrencyRate.Text.Trim());
                        decimal dUnitPrice = detail.UnitPrice;
                        decimal dNetAmount = detail.NetAmount;
                        decimal dDiscount = detail.LineDiscountTotal;
                        decimal dDiscountPct = detail.LineDiscountPresentage;
                        decimal dAmount = detail.GrossAmount;

                        DataRow dr = dt_Item.NewRow();

                        dr["ItemCode"] = detail.Item_ID;
                        dr["Desc"] = item.ItemName;
                        dr["UOM"] = clsGenaralName.getName_Uom(item.Uom_ID);
                        dr["QTY"] = cls_Formater.FormatDecimal(dQty, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
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
                        dr["Remarks"] = detail.Remark;
                        dr["GiftVoucherID"] = detail.GiftVoucherID;
                        dr["PreviousTrans_Index"] = detail.PosTransaction_Index;
                        dr["PreviousTrans_Detail_LineNo"] = detail.Line_No;
                        dr["PreviousTrans_ID_Dispaly"] = (clsGenaralName_POS.getPoS_ID_From_PoS_Index(detail.PosTransaction_Index));

                        dt_Item.Rows.Add(dr);
                    }
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
                            if (CheckValidity_DuplicateFiled())
                                if (CheckValidity_CusTelephoneNo())
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

        //Validate Zero Quantity for Sales Items
        private bool CheckValidity_QtyZero()
        {
            bool bStatus = true;
            var vResult = dt_Item.Select().Where(r => clsValidation.Validate_DecimalNumber(r.Field<string>("QTY")) == 0m);
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
            string sTelNo = ofrmPosReturnAmount.txtCustomerTelphone.TextBox1.Text.Trim();
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
        private void FillDetail_ByTransactionID(int iPOSReturn_Tx)
        {
            try
            {
                ClearFields();

                SEACC_Form.IsUpdateMode = true;

                //POS Transaction
                tbl_posTransaction oPos_Return = tbl_posTransaction.Select(iPOSReturn_Tx);
                if (oPos_Return != null)
                {
                    txtTransactionID.Text = oPos_Return.PosTransaction_ID;
                    txtTransactionID.Tag = oPos_Return.PosTransaction_Index;
                    if (oPos_Return.IsDeleted)
                    {
                        //Delete Button Formatting
                        btnDelete.Background = Brushes.Red;
                        btnDelete.Content = "CANCEL";
                        btnDelete.IsEnabled = false;
                    }

                    #region Transaction Details (items fill)
                    List<tbl_posTransaction_Detail> oPoS_Return_Items = tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(iPOSReturn_Tx).OrderBy(p => p.Line_No).ToList();
                    foreach (tbl_posTransaction_Detail oPoS_Return_Item in oPoS_Return_Items)
                    {
                        tbl_genItemMaster item = tbl_genItemMaster.Select(oPoS_Return_Item.Item_ID);
                        if (item != null)
                        {
                            decimal dExRate = 0;
                            if (lblCurrencyRate.Text.Trim().Length > 0)
                                dExRate = clsValidation.Validate_DecimalNumber(lblCurrencyRate.Text.Trim());

                            decimal dUnitPrice = oPoS_Return_Item.UnitPrice;
                            decimal dQty = -Math.Round(oPoS_Return_Item.Qty, 2);
                            decimal dNetAmount = -oPoS_Return_Item.NetAmount;
                            decimal dDiscount = oPoS_Return_Item.LineDiscountTotal;
                            decimal dDiscountPct = oPoS_Return_Item.LineDiscountPresentage;
                            decimal dAmount = -oPoS_Return_Item.GrossAmount;

                            DataRow dr = dt_Item.NewRow();

                            dr["ItemCode"] = oPoS_Return_Item.Item_ID;
                            dr["Desc"] = item.ItemName;
                            dr["UOM"] = clsGenaralName.getName_Uom(item.Uom_ID);
                            dr["QTY"] = dQty;
                            dr["Weight"] = 0;
                            dr["IsFreeItem"] = oPoS_Return_Item.BIsFreeItem ? "\uE0A2" : "\uE003";
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
                            dr["Remarks"] = oPoS_Return_Item.Remark;
                            dr["GiftVoucherID"] = (-1);
                            dr["PreviousTrans_Index"] = oPoS_Return_Item.PrevPosTx_Index;
                            dr["PreviousTrans_Detail_LineNo"] = oPoS_Return_Item.PrevPosTx_LineNo;
                            dr["PreviousTrans_ID_Dispaly"] = oPoS_Return_Item.PrevPosTx_Index < 1 ? "" : clsGenaralName_POS.getPoS_ID_From_PoS_Index(oPoS_Return_Item.PrevPosTx_Index);

                            dt_Item.Rows.Add(dr);
                        }
                    }
                    dgrItems.ItemsSource = dt_Item.DefaultView;
                    #endregion

                    //Sub Total
                    tbSubTotal.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(-oPos_Return.SubTotal);
                    tbSubTotal.Tag = -oPos_Return.SubTotal;

                    #region Transaction Bulk Discount
                    txtDisc1Pct.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(oPos_Return.DiscountPercentage);
                    txtDisc1Pct.Tag = oPos_Return.DiscountPercentage;
                    txtDisc1Amount.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(oPos_Return.DiscountTotal);
                    txtDisc1Amount.Tag = oPos_Return.DiscountTotal;
                    if (oPos_Return.DiscountTotal != 0)
                        chkDisc1.IsChecked = true;

                    tbDiscount.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(oPos_Return.DiscountTotal);
                    tbDiscount.Tag = oPos_Return.DiscountTotal;

                    #region Transaction Discuont
                    txtDisc1Pct.Text = cls_Formater.FormatDecimal(oPos_Return.DiscountPercentage, clsConfig.sPOSBillDecimalPoint);
                    txtDisc2Pct.Text = cls_Formater.FormatDecimal(oPos_Return.DiscountPercentage2, clsConfig.sPOSBillDecimalPoint);
                    txtDisc3Pct.Text = cls_Formater.FormatDecimal(oPos_Return.DiscountPercentage3, clsConfig.sPOSBillDecimalPoint);
                    txtDisc1Amount.Text = cls_Formater.FormatDecimal(oPos_Return.DiscountTotal, clsConfig.sPOSBillDecimalPoint);
                    txtDisc2Amount.Text = cls_Formater.FormatDecimal(oPos_Return.DiscountTotal2, clsConfig.sPOSBillDecimalPoint);
                    txtDisc3Amount.Text = cls_Formater.FormatDecimal(oPos_Return.DiscountTotal3, clsConfig.sPOSBillDecimalPoint);
                    if (oPos_Return.DiscountTotal != 0)
                        chkDisc1.IsChecked = true;
                    if (oPos_Return.DiscountTotal2 != 0)
                        chkDisc2.IsChecked = true;
                    if (oPos_Return.DiscountTotal3 != 0)
                        chkDisc3.IsChecked = true;
                    #endregion

                    #endregion

                    //Accumilated Total
                    tbAccumilatedTotal.Text = clsCommon_POS.FormatToCurrecyWithThousendSep((-oPos_Return.SubTotal) - (oPos_Return.DiscountTotal));
                    tbAccumilatedTotal.Tag = (-oPos_Return.SubTotal) - (oPos_Return.DiscountTotal);

                    #region Service Charge Set Up
                    //txtServiceChargeAmount.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(oPoSTrans.ServiceChargeTotal);
                    //txtServiceChargeAmount.Tag = oPoSTrans.ServiceChargeTotal;
                    //txtServiceChargePct.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(oPoSTrans.ServiceChargePercentage);
                    //txtServiceChargePct.Tag = oPoSTrans.ServiceChargePercentage;
                    //if (oPoSTrans.ServiceChargeTotal != 0)
                    //    chkServiceCharge.IsChecked = true; 
                    #endregion

                    #region Tax Set Up
                    tbNBT.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(oPos_Return.NbtTotal);
                    tbNBT.Tag = oPos_Return.NbtTotal;
                    tbNBTPresentage.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(oPos_Return.NbtPercentage);
                    tbNBTPresentage.Tag = oPos_Return.NbtPercentage;
                    if (oPos_Return.NbtTotal != 0)
                        chkNBT.IsChecked = true;

                    tbVAT.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(oPos_Return.VatTotal);
                    tbVAT.Tag = oPos_Return.VatTotal;
                    tbVATPresentage.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(oPos_Return.VatPercentage);
                    tbVATPresentage.Tag = oPos_Return.VatPercentage;
                    if (oPos_Return.VatTotal != 0)
                        chkVAT.IsChecked = true;

                    tbOtherTax.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(oPos_Return.OtherTaxTotal);
                    tbOtherTax.Tag = oPos_Return.OtherTaxTotal;
                    tbOtherTaxPresentage.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(oPos_Return.OtherTaxPercentage);
                    tbOtherTaxPresentage.Tag = oPos_Return.OtherTaxPercentage;
                    if (oPos_Return.OtherTaxTotal != 0)
                        chkOtherTax.IsChecked = true;
                    #endregion

                    //Grand Total Set Up
                    tbGrandTotal.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(-oPos_Return.GrandTotal);

                    //Finalize the Grid Set Up
                    tbNoOfItems.Text = dt_Item.Rows.Count.ToString();
                    dgrItems.UnselectAll();

                    //Amount Detail Set Up
                    ofrmPosReturnAmount.txtCustomerName.Tag = oPos_Return.Customer_ID;
                    ofrmPosReturnAmount.txtCustomerName.TextBox1.Text = clsGenaralName.getName_Customer(oPos_Return.Customer_ID);
                    ofrmPosReturnAmount.txtCustomerAddress.TextBox1.Text = clsGenaralName.getName_CustomerRegisterAddress(oPos_Return.Customer_ID);
                    ofrmPosReturnAmount.txtCustomerTelphone.TextBox1.Text = clsGenaralName.getName_CustomerTelephone(oPos_Return.Customer_ID);
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
                int iRowIndex = e.Row.GetIndex();

                if (item != null && iRowIndex > -1)
                {
                    if (dgrItems.SelectedCells.Count > 0)
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
                                    case "QTY":
                                    case "UnitPrice_Display":
                                    case "LineDiscPresent_Display":
                                    case "LineDiscAmount_Display":
                                        var vEditBox = e.EditingElement as TextBox;
                                        var dQty = 0m;
                                        try
                                        {
                                            if (vEditBox != null) dQty = decimal.Parse(vEditBox.Text);

                                            string sItem_ID = (dgrItems.SelectedCells[0].Column.GetCellContent(item) as TextBlock)?.Text;

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

                                            if (sSortMemberName == "QTY" && dQty > 1 && bIsGrftVoucher)
                                            {
                                                SEACCMessageBox.Show("Oops..!", "Qty can not be changed", MessageBoxButton.OK, "Red");
                                                dQty = 1;
                                            }

                                            //if (sSortMemberName == "QTY" && dQty < 0)
                                            //{
                                            //    SEACCMessageBox.Show("Oops..!", "Qty can not be negative value", MessageBoxButton.OK, "Red");
                                            //    dQty = 0;
                                            //}
                                        }
                                        catch
                                        {
                                            SEACCMessageBox.Show("Oops..!", "Please enter numeric value", MessageBoxButton.OK, "Red");
                                        }

                                        if (vEditBox != null)
                                        {
                                            vEditBox.Text = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
                                        }


                                        if (sSortMemberName == "QTY")
                                        {
                                            DataRow dr = dt_Item.Rows[iRowIndex];
                                            if (dr != null)
                                            {
                                                dr["QTY"] = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
                                            }
                                        }
                                        if (sSortMemberName == "UnitPrice_Display")
                                        {
                                            DataRow dr = dt_Item.Rows[iRowIndex];
                                            if (dr != null)
                                            {
                                                dr["UnitPrice_Display"] = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
                                            }
                                        }
                                        if (sSortMemberName == "LineDiscAmount_Display")
                                        {
                                            DataRow dr = dt_Item.Rows[iRowIndex];
                                            if (dr != null)
                                            {
                                                dr["LineDiscAmount"] = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
                                                dr["LineDiscAmount_Display"] = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
                                            }
                                        }

                                        {
                                            string sItemQty = dt_Item.Rows[e.Row.GetIndex()]["QTY"].ToString();
                                            string sUnitPrice = dt_Item.Rows[e.Row.GetIndex()]["UnitPrice_Display"].ToString();
                                            string sLine_disc = dt_Item.Rows[e.Row.GetIndex()]["LineDiscAmount_Display"].ToString();

                                            decimal dUnitPrice = clsValidation.Validate_DecimalNumber(sUnitPrice);
                                            decimal dLine_disc = clsValidation.Validate_DecimalNumber(sLine_disc);
                                            decimal dItemQty = clsValidation.Validate_DecimalNumber(sItemQty);

                                            decimal dNetAmount = dItemQty * dUnitPrice;
                                            decimal dAccumulatedAmount = dItemQty * (dUnitPrice - dLine_disc);

                                            DataRow row = dt_Item.Rows[iRowIndex];
                                            if (row != null)
                                            {
                                                row["UnitPrice"] = cls_Formater.FormatDecimal(dUnitPrice, clsConfig.sDecimalPlaces_Quantity);
                                                row["UnitPrice_Display"] = cls_Formater.FormatDecimal(dUnitPrice, clsConfig.sDecimalPlaces_Quantity);
                                                row["NetAmount"] = dNetAmount;
                                                row["NetAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dNetAmount);
                                                row["LineDiscAmount"] = dLine_disc;
                                                row["LineDiscAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dLine_disc);
                                                row["AccumulatedAmount"] = dAccumulatedAmount;
                                                row["AccumulatedAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(dAccumulatedAmount);
                                                dt_Item.AcceptChanges();
                                            }
                                        }

                                        break;
                                }
                                #endregion
                                CalculateLineAmount(e.Column.Header.ToString(), iRowIndex, e.EditingElement as TextBox);
                                CalcualteSubTotal();
                                CalculateTaxesAndGrandTotal();
                                CauculateNoOfItemsAndTotalQuantity();
                                break;
                        }
                    }
                    Calculate_WholeGrid_Claculations();
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        //Cell Edit Begining
        private void dgItems_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {

            int irowId = e.Row.GetIndex();
            if (irowId > -1)
            {
                string sSortMemberName = e.Column.SortMemberPath;
                switch (sSortMemberName)
                {
                    case "UnitPrice_Display":
                        sPrevCellVal = dt_Item.Rows[irowId]["UnitPrice_Display"].ToString();
                        break;
                    default:
                        sPrevCellVal = "";
                        break;

                }
            }
        }

        //Row, Cell Single Click
        private void dgItems_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int irowId = dgrItems.SelectedIndex;
            var vDgCell = dgrItems.CurrentCell;

            try
            {
                int iColumn_Id = vDgCell.Column.DisplayIndex;
                switch (iColumn_Id)
                {
                    case 6://Free Item
                        if (dt_Item.Rows[irowId]["IsFreeItem"].ToString() == "\uE0A2")//If True
                        {
                            dt_Item.Rows[irowId]["IsFreeItem"] = "\uE003";//Std. Disc %
                            dt_Item.Rows[irowId]["LineDiscPresent"] = 0;
                            dt_Item.Rows[irowId]["LineDiscPresent_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(0);

                        }
                        else
                        {
                            dt_Item.Rows[irowId]["IsFreeItem"] = "\uE0A2";
                            dt_Item.Rows[irowId]["LineDiscPresent"] = 100;
                            dt_Item.Rows[irowId]["LineDiscPresent_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(100);
                        }
                        CalculateLineAmount("Std. Disc %", irowId, null);
                        dgrItems.UnselectAll();
                        break;

                    case 10: //Remove Item
                        dt_Item.Rows.RemoveAt(irowId);
                        break;

                    case 11: // Billed or Return Item
                        if (dt_Item.Rows[irowId]["BilledOrRefund"].ToString() == "\uE108")
                        {
                            dt_Item.Rows[irowId]["BilledOrRefund"] = "\uE109";
                            dt_Item.Rows[irowId]["IsRefund"] = false;
                            if (clsValidation.Validate_DecimalNumber((dt_Item.Rows[irowId]["QTY"]).ToString()) < 0)
                                dt_Item.Rows[irowId]["QTY"] = (clsValidation.Validate_DecimalNumber((dt_Item.Rows[irowId]["QTY"]).ToString()) * -1);
                        }
                        else
                        {
                            dt_Item.Rows[irowId]["BilledOrRefund"] = "\uE108";
                            dt_Item.Rows[irowId]["IsRefund"] = true;
                            if (clsValidation.Validate_DecimalNumber((dt_Item.Rows[irowId]["QTY"]).ToString()) > 0)
                            {
                                dt_Item.Rows[irowId]["QTY"] = (clsValidation.Validate_DecimalNumber((dt_Item.Rows[irowId]["QTY"]).ToString()) * -1);
                            }
                        }
                        CalculateLineAmount("Qty.", irowId, null);
                        dgrItems.UnselectAll();
                        break;

                    default:
                        break;
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

        //Row, Cell Double Click
        private void dgItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int irowID = dgrItems.SelectedIndex;
            var vDG_Cell = dgrItems.CurrentCell;
            try
            {
                if (vDG_Cell.Column.SortMemberPath == "Remarks")
                {
                    frmSearchForm RowDataSearch = new frmSearchForm();
                    List<string> lstResult = RowDataSearch.Show(Search.Pos_ItemRemarks);

                    if (RowDataSearch.DialogResult == true)
                    {
                        dt_Item.Rows[irowID]["Remarks"] = lstResult[1];
                    }
                }

                else if (vDG_Cell.Column.SortMemberPath == "PreviousTrans_ID_Dispaly")
                {
                    List<string> lstParameeters = new List<string>();
                    if (clsSecurity.BranchID != "")
                        lstParameeters.Add(clsSecurity.BranchID);

                    string sItem_ID = dt_Item.Rows[irowID]["ItemCode"].ToString();
                    lstParameeters.Add(sItem_ID);

                    frmSearchForm RowDataSearch = new frmSearchForm(lstParameeters);
                    List<string> lstResult = RowDataSearch.Show(Search.Pos_SoldItems);

                    if (RowDataSearch.DialogResult == true)
                    {
                        dt_Item.Rows[irowID]["PreviousTrans_Detail_LineNo"] = lstResult[0];
                        dt_Item.Rows[irowID]["PreviousTrans_Index"] = lstResult[1];
                        dt_Item.Rows[irowID]["PreviousTrans_ID_Dispaly"] = lstResult[2];

                        string sQty = dt_Item.Rows[irowID]["QTY"].ToString();
                        decimal dQty = clsValidation.Validate_DecimalNumber(sQty);

                        tbl_posTransaction_Detail vTxn_Item = tbl_posTransaction_Detail.Select(int.Parse(lstResult[0]), int.Parse(lstResult[1]));
                        if (vTxn_Item != null)
                        {
                            dt_Item.Rows[irowID]["QTY"] = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
                            dt_Item.Rows[irowID]["Weight"] = 0;

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
                            dt_Item.Rows[irowID]["UnitPrice"] = lUnitPrice;
                            dt_Item.Rows[irowID]["UnitPrice_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(lUnitPrice);
                            dt_Item.Rows[irowID]["NetAmount"] = lNetAmount;
                            dt_Item.Rows[irowID]["NetAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(lNetAmount);
                            dt_Item.Rows[irowID]["LineDiscPresent"] = Math.Round(lStdDiscPct, 2);
                            dt_Item.Rows[irowID]["LineDiscPresent_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(Math.Round(lStdDiscPct, 2));
                            dt_Item.Rows[irowID]["LineDiscAmount"] = lQty != 0 ? Math.Round(lStdDisc / lQty, 2) : 0;
                            dt_Item.Rows[irowID]["LineDiscAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(lQty != 0 ? Math.Round(lStdDisc / lQty, 2) : 0);
                            dt_Item.Rows[irowID]["AccumulatedAmount"] = lAmount;
                            dt_Item.Rows[irowID]["AccumulatedAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(lAmount);

                            CalcualteSubTotal();
                            CalculateTaxesAndGrandTotal();
                            CauculateNoOfItemsAndTotalQuantity();

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
        }
        #endregion

        #endregion

        #region Events - Search Text Boxes

        #region Main Item Search Usercontroller Events

        //Key Press Down & Barcode Enter
        private void Srh_Items_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            dgrItems.UnselectAll();
            if (e.Key == Key.Enter)
            {
                RefreshGridByItemID(ucItemSearch.txtFillter.Text);

                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();
                CauculateNoOfItemsAndTotalQuantity();
            }
        }

        //Item Selection From Search
        private void Srh_Items_SelectionOK(List<string> sender)
        {
            if (sender.Count > 0)
            {
                RefreshGridByItemID(sender[0]);

                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();
                CauculateNoOfItemsAndTotalQuantity();

            }
            frmPosReturnsWindow.Effect = null;

            if (dgrItems.Items.Count > 0)
            {
                var border = VisualTreeHelper.GetChild(dgrItems, 0) as Decorator;
                if (border != null)
                {
                    var scroll = border.Child as ScrollViewer;
                    if (scroll != null) scroll.ScrollToEnd();
                }

                dgrItems.CurrentCell = new DataGridCellInfo(dgrItems.Items[dgrItems.Items.Count - 1], dgrItems.Columns[3]);
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    dgrItems.BeginEdit();
                }), System.Windows.Threading.DispatcherPriority.Background);
            }
        }
        #endregion

        #region Previous Transaction Search Usercontroller Events
        private void ucPreviousTxSearch_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            dgrItems.UnselectAll();
            if (e.Key == Key.Enter)
            {
                RefreshGridByItemID(ucItemSearch.txtFillter.Text);
                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();
                CauculateNoOfItemsAndTotalQuantity();
            }
        }

        private void ucPreviousTxSearch_SelectionOK(List<string> sender)
        {
            if (sender.Count > 0)
            {
                try
                {

                    RefreshGridByPreviousPOS_TxIndex(int.Parse(sender[0]));
                    CalcualteSubTotal();
                    CalculateTaxesAndGrandTotal();
                    CauculateNoOfItemsAndTotalQuantity();

                    tbl_posTransaction oPOS_Tx = tbl_posTransaction.Select(int.Parse(sender[0]));
                    if (oPOS_Tx != null)
                    {
                        ofrmPosReturnAmount.txtCustomerName.Tag = oPOS_Tx.Customer_ID;

                        ofrmPosReturnAmount.txtCustomerTelphone.TextBox1.Text = clsGenaralName.getName_CustomerTelephone(oPOS_Tx.Customer_ID);
                        ofrmPosReturnAmount.txtCustomerName.TextBox1.Text = oPOS_Tx.CustomerName;
                        ofrmPosReturnAmount.txtCustomerAddress.TextBox1.Text = clsGenaralName.getName_CustomerRegisterAddress(oPOS_Tx.Customer_ID);
                        ofrmPosReturnAmount.txtSalesRep.TextBox1.Text = clsGenaralName.getName_SalesRep(oPOS_Tx.SalesRep_ID);
                        ofrmPosReturnAmount.txtCreditPeriod.TextBox1.Text = oPOS_Tx.CreditPeriod_Days.ToString();
                    }

                    if (dgrItems.Items.Count > 0)
                    {
                        var border = VisualTreeHelper.GetChild(dgrItems, 0) as Decorator;
                        if (border != null)
                        {
                            var scroll = border.Child as ScrollViewer;
                            if (scroll != null) scroll.ScrollToEnd();
                        }

                        dgrItems.CurrentCell = new DataGridCellInfo(dgrItems.Items[0], dgrItems.Columns[3]);
                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            dgrItems.BeginEdit();
                        }), System.Windows.Threading.DispatcherPriority.Background);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            frmPosReturnsWindow.Effect = null;
        }
        #endregion

        #region Shift Between Item Search & Prevoius Transation Search

        //Gift Voucher Serch
        private void rdoPreTransactionSearch_Checked(object sender, RoutedEventArgs e)
        {
            SetEnableDisable_UC_Search("Previous_Tx");
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
            List<string> lstResult = RowDataSearch.Show(Search.POS_CRNs);

            if (RowDataSearch.DialogResult == true)
            {
                try
                {
                    ClearFields();
                    txtTransactionID.Text = lstResult[0];
                    txtTransactionID.Tag = lstResult[0];
                    FillDetail_ByTransactionID(int.Parse(lstResult[0]));
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
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
            ucPreTransactionSearch.pop_Detail.IsOpen = false;
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
            ucPreTransactionSearch.pop_Detail.IsOpen = false;
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
            ofrmPosReturnAmount.tbGrandtotal.Text = tbGrandTotal.Text;
            ofrmPosReturnAmount.tbGrandtotal.Text = tbGrandTotal.Text;
            ofrmPosReturnAmount.dTransactionGrandTotal = clsValidation.Validate_DecimalNumber(tbGrandTotal.Text);
            ofrmPosReturnAmount.ShowDialog();
        }

        private void grdPaymentsRow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            pop_Discount.IsOpen = false;
            pop_ServiceCharges.IsOpen = false;
            ucItemSearch.pop_Detail.IsOpen = false;
            ucPreTransactionSearch.pop_Detail.IsOpen = false;

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
        private void CalculateLineAmount(string sColoumn_headerName, int irowId, TextBox t)
        {
            if (irowId > -1 && dt_Item.Rows.Count > 0)
            {
                decimal lQty = 0, lUnitPrice = 0, lStdDisc = 0, lStdDiscPct = 0, lNetAmount = 0, lAmount = 0;

                lUnitPrice = clsValidation.Validate_DecimalNumber(dt_Item.Rows[irowId]["UnitPrice"].ToString());
                lStdDisc = clsValidation.Validate_DecimalNumber(dt_Item.Rows[irowId]["LineDiscAmount_Display"].ToString());
                lStdDiscPct = clsValidation.Validate_DecimalNumber(dt_Item.Rows[irowId]["LineDiscPresent_Display"].ToString());

                switch (sColoumn_headerName)
                {
                    case "Qty.":
                        lQty = clsValidation.Validate_DecimalNumber(dt_Item.Rows[irowId]["QTY"].ToString());
                        if (t != null)
                            lQty = clsValidation.Validate_DecimalNumber(t.Text);
                        lNetAmount = lQty * lUnitPrice;
                        lStdDisc = 0;
                        lStdDiscPct = 0;
                        break;

                    case "Unit Price":
                        lQty = clsValidation.Validate_DecimalNumber(dt_Item.Rows[irowId]["QTY"].ToString());
                        if (t != null)
                            lUnitPrice = clsValidation.Validate_DecimalNumber(t.Text);
                        lNetAmount = lQty * lUnitPrice;
                        lStdDisc = 0;
                        lStdDiscPct = 0;
                        break;

                    case "Std. Disc":
                        lQty = clsValidation.Validate_DecimalNumber(dt_Item.Rows[irowId]["QTY"].ToString());
                        if (t != null)
                            lStdDisc = clsValidation.Validate_DecimalNumber(t.Text) * lQty;
                        lNetAmount = lQty * lUnitPrice;
                        if (lNetAmount != 0)
                            lStdDiscPct = clsValidation.Validate_DecimalNumber((lStdDisc * 100 / lNetAmount).ToString());
                        else
                            lStdDiscPct = 0;
                        break;

                    case "Std. Disc %":
                        lQty = clsValidation.Validate_DecimalNumber(dt_Item.Rows[irowId]["QTY"].ToString());
                        if (t != null)
                            lStdDiscPct = clsValidation.Validate_DecimalNumber(t.Text);
                        lNetAmount = lQty * lUnitPrice;
                        lStdDisc = clsValidation.Validate_DecimalNumber(((lUnitPrice * lStdDiscPct / 100) * lQty).ToString());
                        break;
                }


                lAmount = lNetAmount - lStdDisc;

                dt_Item.Rows[irowId]["UnitPrice"] = lUnitPrice;
                dt_Item.Rows[irowId]["UnitPrice_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(lUnitPrice);
                dt_Item.Rows[irowId]["NetAmount"] = lNetAmount;
                dt_Item.Rows[irowId]["NetAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(lNetAmount);
                dt_Item.Rows[irowId]["LineDiscPresent"] = Math.Round(lStdDiscPct, 2);
                dt_Item.Rows[irowId]["LineDiscPresent_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(Math.Round(lStdDiscPct, 2));
                dt_Item.Rows[irowId]["LineDiscAmount"] = lQty != 0 ? Math.Round(lStdDisc / lQty, clsConfig_POS.iCurrencyDecimalPalces_PoS_Discount) : 0;
                dt_Item.Rows[irowId]["LineDiscAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(lQty != 0 ? Math.Round(lStdDisc / lQty, clsConfig_POS.iCurrencyDecimalPalces_PoS_Discount) : 0);
                dt_Item.Rows[irowId]["AccumulatedAmount"] = lAmount;
                dt_Item.Rows[irowId]["AccumulatedAmount_Display"] = clsCommon_POS.FormatToCurrecyWithThousendSep(lAmount);

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
            decimal dGrandTotal = 0, dSubTotalRunning = 0, dSubTotal = 0, dReturnReceipt = 0, dDiscount1 = 0, dDiscount2 = 0, dDiscount3 = 0, dServiceCharges = 0, dNbt = 0, dNbtRate = 0, dVat = 0, dVatRate = 0, dOtherTax = 0, dOtherTaxRate = 0;

            if (lblSubTotal.Tag != null && lblSubTotal.Tag.ToString().Trim().Length > 0 && clsCommon.isCurrency(lblSubTotal.Tag.ToString().Trim()))
                dSubTotal = dSubTotalRunning = clsValidation.Validate_DecimalNumber(lblSubTotal.Tag.ToString().Trim());

            //Bulk Return Receipt Calculation
            //Line Wise Item Return has been developped
            //Not Developped
            #region Return Receipt
            //if (clsValidation.Validate_DecimalNumber(lblReturnRept.Tag.ToString()) <= 0)
            //    dReturnReceipt = clsValidation.Validate_DecimalNumber(lblReturnRept.Text.ToString());
            //lblReturnRept.Text = clsCommon_POS.FormatToCurrecyWithThousendSep(dReturnReceipt);
            //if (chkReturnRept.IsChecked != null && !chkReturnRept.IsChecked.Value)
            //    dReturnReceipt = 0;
            dSubTotalRunning = (dSubTotalRunning + dReturnReceipt);
            #endregion

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
            dGrandTotal = (dSubTotal - dDiscount1 - dDiscount2 - dDiscount3 + dServiceCharges + dNbt + dVat + dReturnReceipt);
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
                bool bIncompletedTx = true;

                try
                {
                    Cursor = Cursors.Wait;
                    //Update records
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.PermissionTO_Update)
                        {
                            #region Update

                            decimal dSubTotal = GetSavePrice(clsValidation.Validate_DecimalNumber(tbSubTotal.Tag.ToString()), lblCurrencyRate);

                            #region Discount 
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
                            #endregion

                            tbl_posTransaction oPosTrans = tbl_posTransaction.Select(txtTransactionID.Text);
                            var oCRN = tbl_bpsCreditNote.SelectAllByPosReturnTransaction_Index(oPosTrans.PosTransaction_Index).Where(r => r.IsSeattled);

                            if (oCRN == null || oCRN.Count() <= 0)
                            {
                                bool bDayEndCompleted = clsHelpMethods_POS.Check_DayEndComplted_PosTransactionUpdate(oPosTrans);
                                if (!bDayEndCompleted && oPosTrans != null &&
                                    !oPosTrans.IsDeleted && !oPosTrans.IsApproved &&
                                    (oPosTrans.PrintedUser_ID == "default" || oPosTrans.PosTransaction_ID.Contains("HOLD/")))
                                {
                                    #region Get pos transaction ID Auto Gen
                                    if (SEACC_Form.isAutoGenaratedCode)
                                    {
                                        if (!bIsHold_Bill && txtTransactionID.Text.Contains("HOLD/"))
                                            txtTransactionID.Text = SEACC_Form.getAutoGeneratedCode();
                                    }
                                    txtTransactionID.Tag = oPosTrans.PosTransaction_Index;
                                    #endregion

                                    if (clsValidate.CheckValidity_TransactionCodeLength(txtTransactionID.Text))
                                    {
                                        tbl_posTransaction oPosTx_Header = new tbl_posTransaction(
                                            oPosTrans.PosTransaction_Index,
                                            txtTransactionID.Text.Trim(),
                                            clsSecurity.getServerDateTime(),
                                            oPosTrans.Remark,
                                            ofrmPosReturnAmount.txtCustomerName.Tag != null ? ofrmPosReturnAmount.txtCustomerName.Tag.ToString() : "default",
                                            ofrmPosReturnAmount.txtCustomerName.TextBox1.Text,
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
                                            -dSubTotal,
                                            dTotalDisc,
                                            dDiscount_1,
                                            dDiscount_2,
                                            dDiscount_3,
                                            GetSavePrice(clsValidation.Validate_DecimalNumber(tbNBT.Tag.ToString()),
                                                lblCurrencyRate),
                                            GetSavePrice(clsValidation.Validate_DecimalNumber(tbVAT.Tag.ToString()),
                                                lblCurrencyRate),
                                            GetSavePrice(
                                                clsValidation.Validate_DecimalNumber(tbOtherTax.Tag.ToString()),
                                                lblCurrencyRate),
                                            -GetSavePrice(
                                                clsValidation.Validate_DecimalNumber(tbGrandTotal.Text.Trim()),
                                                lblCurrencyRate),
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
                                            oPosTrans.IsSeattled,
                                            clsSecurity.CompanyID, clsSecurity.BranchID,
                                            oPosTrans.CreditPeriod_Days,
                                            oPosTrans.GreetingDescription,
                                            iPoS_session_dayDetail_Index, oPosTrans.GlPosting_ID,
                                            oPosTrans.PostingStatus_ID, oPosTrans.FinancialYear_ID, true, false, true
                                        );
                                        oPosTx_Header.Update();

                                        tbl_bpsCreditNote.DeleteAllByPosReturnTransaction_Index(oPosTrans
                                            .PosTransaction_Index);

                                        foreach (tbl_posTransaction_Detail oDetail in tbl_posTransaction_Detail
                                            .SelectAllByPosTransaction_Index(oPosTrans.PosTransaction_Index)
                                            .Where(r => r.GiftVoucherID < 1))
                                        {
                                            clsHelpMethods_POS.UpdateStock(sPOS_Store_ID, oDetail.Item_ID, oDetail.Qty);
                                            oDetail.Delete();
                                        }

                                        foreach (tbl_posReceipt oPosTx in
                                            tbl_posReceipt.SelectAllByPosTransaction_Index(oPosTrans
                                                .PosTransaction_Index))
                                        {
                                            tbl_sasInvoice_Sattled.DeleteAllByPosReceipt_ID(oPosTx.PosReceipt_ID);
                                            tbl_bpsChequeRegister.DeleteAllByPosReceipt_ID(oPosTx.PosReceipt_ID);
                                            oPosTx.Delete();
                                        }

                                        txtTransactionID.Text = oPosTx_Header.PosTransaction_ID;
                                        txtTransactionID.Tag = oPosTx_Header.PosTransaction_Index;

                                        SavePosReturnDetails(oPosTx_Header.PosTransaction_Index, oPosTx_Header.PosTransaction_ID);
                                        Save_RetunForCreditNote(oPosTx_Header);

                                        bIncompletedTx = false;
                                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                    }
                                }
                                else
                                {
                                    if (oPosTrans != null && oPosTrans.IsApproved)
                                        SEACCMessageBox.Show("Cannot Update..",
                                            "Selected Transaction has been approved", MessageBoxButton.OK, "Red");
                                    else if (bDayEndCompleted)
                                        SEACCMessageBox.Show("Cannot Update..",
                                            "Branch Day End has already been completed and approved.", MessageBoxButton.OK, "Red");
                                    else if (oPosTrans != null && oPosTrans.IsDeleted)
                                        SEACCMessageBox.Show("Cannot Update..",
                                            "Selected Transaction has been cancelled", MessageBoxButton.OK, "Red");
                                    else if (oPosTrans != null && oPosTrans.PrintedUser_ID != "default")
                                        SEACCMessageBox.Show("Cannot Update..",
                                            "Selected Transaction Bill has already been printed", MessageBoxButton.OK, "Red");
                                    else
                                        SEACCMessageBox.Show("Cannot Update..", "", MessageBoxButton.OK, "Red");
                                }
                            }
                            else
                            {
                                SEACCMessageBox.Show("Cannot Update..", "Credit Note has already settled", MessageBoxButton.OK, "Red");
                            }
                            #endregion
                        }
                        else
                        {
                            SEACCMessageBox.Show("Can not Update..!", "You don't have permission to update", MessageBoxButton.OK, "Red");
                        }
                    }
                    //Insert records
                    else
                    {
                        if (SEACC_Form.PermissionTO_Write)
                        {
                            int iPK_POSTx = tbl_posTransaction.SelectAll().Max(r => r.PosTransaction_Index) + 1;

                            #region Insert

                            decimal dSubTotal = GetSavePrice(clsValidation.Validate_DecimalNumber(tbSubTotal.Tag.ToString()), lblCurrencyRate);

                            #region Discounts
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
                                dTotalDiscPct = decimal.Round((dTotalDisc * 100 / dSubTotal), clsConfig.sCurrencyDecimalPlaces_UnitPrice);

                            #endregion

                            #region Insert POS Header

                            tbl_posTransaction oPosTx_Header = new tbl_posTransaction(
                                iPK_POSTx,
                                !SEACC_Form.isAutoGenaratedCode ? txtTransactionID.Text.Trim() : iPK_POSTx.ToString("D8"),
                                clsSecurity.getServerDateTime(), "",
                                ofrmPosReturnAmount.txtCustomerName.Tag != null ? ofrmPosReturnAmount.txtCustomerName.Tag.ToString() : "default",
                                ofrmPosReturnAmount.txtCustomerName.TextBox1.Text,
                                ofrmPosReturnAmount.txtSalesRep.Tag != null ? ofrmPosReturnAmount.txtSalesRep.Tag.ToString() : "default",
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
                                -dSubTotal,
                                dTotalDisc,
                                dDiscount_1,
                                dDiscount_2,
                                dDiscount_3,
                                GetSavePrice(clsValidation.Validate_DecimalNumber(tbNBT.Tag.ToString()), lblCurrencyRate),
                                GetSavePrice(clsValidation.Validate_DecimalNumber(tbVAT.Tag.ToString()), lblCurrencyRate),
                                GetSavePrice(clsValidation.Validate_DecimalNumber(tbOtherTax.Tag.ToString()), lblCurrencyRate),
                                -GetSavePrice(clsValidation.Validate_DecimalNumber(tbGrandTotal.Text.Trim()), lblCurrencyRate),
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
                                false,
                                clsSecurity.CompanyID, clsSecurity.BranchID,
                                -1,
                                "",
                                iPoS_session_dayDetail_Index,
                                "default",
                                clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction),
                                clsSecurity.FinancialYearID, true, false, true
                            );
                            oPosTx_Header.Insert();

                            txtTransactionID.Text = oPosTx_Header.PosTransaction_ID;
                            txtTransactionID.Tag = oPosTx_Header.PosTransaction_Index;
                            #endregion

                            SavePosReturnDetails(oPosTx_Header.PosTransaction_Index, oPosTx_Header.PosTransaction_ID);
                            Save_RetunForCreditNote(oPosTx_Header);

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
                    SEACCExeption.Show(ex);
                }
                finally
                {
                    Cursor = Cursors.Arrow;
                    if (!bIncompletedTx)
                    {
                        if (txtTransactionID.Tag != null)
                        {
                            tbl_posTransaction oDetail = tbl_posTransaction.Select(int.Parse(txtTransactionID.Tag.ToString()));
                            if (oDetail != null)
                            {
                                #region Get pos transaction ID Auto Gen

                                if (SEACC_Form.isAutoGenaratedCode && !SEACC_Form.IsUpdateMode)
                                {
                                    if (!bIsHold_Bill)
                                        txtTransactionID.Text = SEACC_Form.getAutoGeneratedCode();
                                    else
                                        txtTransactionID.Text = "HOLD/" + oDetail.PosTransaction_Index.ToString("D4");

                                    oDetail.PosTransaction_ID = txtTransactionID.Text;
                                }

                                #endregion

                                txtTransactionID.Tag = oDetail.PosTransaction_Index;

                                if (clsValidate.CheckValidity_TransactionCodeLength(txtTransactionID.Text))
                                {
                                    oDetail.IsIncompleted = bIncompletedTx;
                                    oDetail.Update();

                                    FillDetail_ByTransactionID(int.Parse(txtTransactionID.Tag.ToString()));
                                }
                                else
                                {
                                    bIncompletedTx = true;
                                }
                            }
                        }
                    }

                    if (bIncompletedTx)
                    {
                        btnDelete_Click(null, null);
                        SEACCMessageBox.Show("Something Went Wrong...!", "Please Save the Transaction Again...", MessageBoxButton.OK, "Red");
                    }
                }
            }
        }

        //Save Method (POS Detail Table)
        private void SavePosReturnDetails(int iPTx_Index, string sPTx_ID)
        {
            int iLineNo = 0;
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
                        iPreviousTrans_ID_LineNo = -1;

                    bool bIsFreeItem = false;

                    //POS Details
                    sItemID = row["ItemCode"].ToString();
                    dUnitPrice = clsValidation.Validate_DecimalNumber(row["UnitPrice"].ToString());
                    dWeightPrice = clsValidation.Validate_DecimalNumber(row["WeightPrice"].ToString());
                    bIsFreeItem = (row["IsFreeItem"].ToString() == "\uE0A2");
                    dQuantity = clsValidation.Validate_DecimalNumber(row["QTY"].ToString());
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

                    #endregion

                    tbl_genItemMaster oItemMaster = tbl_genItemMaster.Select(sItemID);

                    //tbl_posTransaction Details
                    tbl_posTransaction_Detail oPosDetail = new tbl_posTransaction_Detail(
                            ++iLineNo,
                            iPTx_Index,
                            oItemMaster.Item_ID,
                            iGiftVoucherID,
                            sRemarks,
                            -dQuantity,
                            dWeight,
                            dUnitPrice,
                            dWeightPrice,
                            bIsFreeItem,
                            -dNetAmount,
                            dDiscountPresentage,
                            dDiscountValue,
                            -dAmount,
                            iPreviousTrans_ID,
                            iPreviousTrans_ID_LineNo);
                    oPosDetail.Insert();

                    if (!oItemMaster.IsGiftVoucher)
                    {
                        clsHelpMethods_POS.UpdateStock(sPOS_Store_ID, oItemMaster.Item_ID, dQuantity);
                    }
                    else
                    {
                        tbl_bpsGiftVoucher oGV = tbl_bpsGiftVoucher.Select(iGiftVoucherID);
                        if (oGV != null)
                        {
                            oGV.IsIssued = false;
                            oGV.Update();
                        }

                        tbl_genItemMaster_Barcode oItem_serial = tbl_genItemMaster_Barcode.Select(oGV.Item_ID, oGV.SerialNo);
                        if (oItem_serial != null)
                        {
                            oItem_serial.IsDelivered = false;
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

        //Enable Disable Main Search
        private void SetEnableDisable_UC_Search(string sSearchSelectMode)
        {
            switch (sSearchSelectMode)
            {
                case "ITEM_Mode":
                    ucPreTransactionSearch.IsEnabled = false;
                    ucPreTransactionSearch.Visibility = Visibility.Hidden;
                    ucPreTransactionSearch.pop_Detail.IsOpen = false;

                    ucItemSearch.IsEnabled = true;
                    ucItemSearch.Visibility = Visibility.Visible;
                    ucItemSearch.txtFillter.Focus();

                    break;

                case "Previous_Tx":
                    ucPreTransactionSearch.IsEnabled = true;
                    ucPreTransactionSearch.Visibility = Visibility.Visible;
                    ucPreTransactionSearch.txtFillter.Focus();

                    ucItemSearch.IsEnabled = false;
                    ucItemSearch.Visibility = Visibility.Hidden;
                    ucItemSearch.pop_Detail.IsOpen = false;
                    break;

            }
        }

        //Credit Note Save Method
        private void Save_RetunForCreditNote(tbl_posTransaction oPOS_Return)
        {
            //string sNext_CRN = clsAutocode.getAutoGeneratedCode("CON/092");//Credit Note
            string sNext_CRN = "CRN/" + oPOS_Return.PosTransaction_Index.ToString("D8");
            tbl_bpsCreditNote oPOS_Return_CRN = new tbl_bpsCreditNote(sNext_CRN,
                oPOS_Return.PosTransactiondate, oPOS_Return.Remark,
                "default", "default", oPOS_Return.Customer_ID, "default",
                oPOS_Return.OrderRefNo_ID, "default", "TP/002", "default", "default",
                clsSecurity.FinancialYearID, oPOS_Return.Currency_ID,
                oPOS_Return.SalesNoteType_ID, oPOS_Return.CurrencyRate,
                oPOS_Return.DiscountPercentage, oPOS_Return.NbtPercentage,
                oPOS_Return.VatPercentage, oPOS_Return.OtherTaxPercentage,
                oPOS_Return.SubTotal, oPOS_Return.DiscountTotal,
                oPOS_Return.NbtTotal, oPOS_Return.VatTotal, oPOS_Return.OtherTaxTotal,
                oPOS_Return.GrandTotal, clsSecurity.UserIDLoged,
                "default", "default", "default", clsSecurity.TerminalID,
                "default", "default", "default", clsSecurity.getServerDateTime(),
                clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                clsValidation.defaultDateTime, false, false, false, false, false, false,
                0, false, 0, clsSecurity.CompanyID, clsSecurity.BranchID, false,
                oPOS_Return.PosTransaction_Index, (-1));
            oPOS_Return_CRN.Insert();
        }

        #endregion

        private void Calculate_WholeGrid_Claculations()
        {
            foreach (DataRow row in dt_Item.Rows)
            {
                decimal dQty = clsValidate.ValidateRowValue(row, "QTY", 0m);
                decimal dUnit_Price = clsValidate.ValidateRowValue(row, "UnitPrice", 0m);
                decimal dLineDiscount = clsValidate.ValidateRowValue(row, "LineDiscAmount", 0m);

                decimal dNetAmount = dQty * dUnit_Price;
                decimal dAccumulatedAmount = dQty * (dUnit_Price - dLineDiscount);

                row["QTY"] = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
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
