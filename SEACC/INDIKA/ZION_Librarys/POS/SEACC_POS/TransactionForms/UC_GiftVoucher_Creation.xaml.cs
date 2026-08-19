using DataTire;
using Digiteq_Logic;
using Microsoft.Win32;
using SEACC_POS.Controls;
using SEACC_WPFControls;
using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SEACC_POS
{
    public partial class UC_GiftVoucher_Creation : UserControl
    {
        #region Class Variables
        BrushConverter bc = new BrushConverter();
        DataTable dtExcelData_ForGrid = new DataTable();
        #endregion

        #region Form Load
        public UC_GiftVoucher_Creation()
        {
            #region Form Initialize
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.POS_GiftVoucherCreation;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Tables

            #region Excel Data Insertion Table
            dtExcelData_ForGrid.Columns.Add("LineNo");
            dtExcelData_ForGrid.Columns.Add("VoucherSerial");
            dtExcelData_ForGrid.Columns.Add("Amount");
            dtExcelData_ForGrid.Columns.Add("VoucherDate");
            dtExcelData_ForGrid.Columns.Add("ValidDays");
            dtExcelData_ForGrid.Columns.Add("ExpiryDate");
            #endregion

            #region Main Table
            dgr_Main.dt.Columns.Add("LineNo");
            dgr_Main.dt.Columns.Add("VoucherID");
            dgr_Main.dt.Columns.Add("VoucherSerial");
            dgr_Main.dt.Columns.Add("Amount");
            dgr_Main.dt.Columns.Add("VoucherDate");
            dgr_Main.dt.Columns.Add("ValidDays");
            dgr_Main.dt.Columns.Add("ExpiryDate");
            dgr_Main.dt.Columns.Add("Prepared_By");
            dgr_Main.dt.Columns.Add("Checked_By");
            dgr_Main.dt.Columns.Add("Approved_By");
            dgr_Main.dt.Columns.Add("IsCancelled");
            #endregion

            #endregion

            #region Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false, true, true);
            SEACC_Form.btn_New.Click += btn_New_Click;
            SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            SEACC_Form.btn_Print.Click += btn_Print_Click;
            SEACC_Form.btn_Save.Click += btn_Save_Click;
            SEACC_Form.btn_Checked.Click += btn_Checked_Click;
            SEACC_Form.btn_Approved.Click += btn_Approved_Click;
            #endregion

            #region Initialize Grid 

            #region Main Grid
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "##", "LineNo", 25, true, true);
            dgr_Main.Add_DatagridColoumn("Voucher ID", "VoucherID", 100, false);
            dgr_Main.Add_DatagridColoumn("Voucher Serial", "VoucherSerial", 120);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Amount", "Amount", 85, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Valid Days", "ValidDays", 85, true, true);
            dgr_Main.Add_DatagridColoumn("Issued Date", "VoucherDate", 85);
            dgr_Main.Add_DatagridColoumn("Expiry Date", "ExpiryDate", 85 , false);
            dgr_Main.Add_DatagridColoumn("Prepared By", "Prepared_By", 120, false);
            dgr_Main.Add_DatagridColoumn("Checked By", "Checked_By", 120, false);
            dgr_Main.Add_DatagridColoumn("Approved By", "Approved_By", 120);
            dgr_Main.Add_DatagridColoumn("Is Cancelled", "IsCancelled", 120, false);
            #endregion

            #region Excel Data Insertion Grid
            dgrExcelData.ItemsSource = dtExcelData_ForGrid.DefaultView;
            #endregion

            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region From Responsiveness 
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

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.CheckPermission_ToCancel())
                {
                    if (txtVoucherSerial.Tag != null)
                    {
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_bpsGiftVoucher oGiftVoucher = tbl_bpsGiftVoucher.Select(int.Parse(txtVoucherSerial.Tag.ToString()));
                            if (oGiftVoucher != null)
                            {
                                if (!oGiftVoucher.IsApproved)
                                {
                                    if (!oGiftVoucher.IsCanceled)
                                    {
                                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                                        if (bMessegeBoxResult)
                                        {
                                            frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                            frmTwoStepVerify.ShowDialog();
                                            if (frmTwoStepVerify.bVerified)
                                            {
                                                oGiftVoucher.IsCanceled = true;
                                                oGiftVoucher.DateCanceled = clsSecurity.getServerDateTime();
                                                oGiftVoucher.CanceldUser_ID = clsSecurity.UserIDLoged;
                                                oGiftVoucher.CanceledUserTerminal_ID = clsSecurity.TerminalID;
                                                oGiftVoucher.Update();
                                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                            }
                                            frmTwoStepVerify.Close();
                                        }
                                        ClearFields();
                                        RefreshGrid();
                                    }
                                    else
                                    {
                                        SEACCMessageBox.Show(MessegeBoxType.CannotCancel_AlreadyCanceled);
                                    }
                                }
                                else
                                {
                                    SEACCMessageBox.Show(MessegeBoxType.CannotCancel_AlreadyApproved);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }

        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {
            //To do
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            int iGiftVoucher_ID = -1;
            if (CheckValidity() || txtExcelFilePath.IsChecked)
            {
                bool bSaving = true;
                try
                {
                    Cursor = Cursors.Wait;

                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            if (CheckValidity())
                            {
                                tbl_bpsGiftVoucher oOldGiftVoucher = tbl_bpsGiftVoucher.Select(int.Parse(txtVoucherSerial.Tag.ToString()));
                                if (oOldGiftVoucher != null)
                                {
                                    if (!oOldGiftVoucher.IsApproved && !oOldGiftVoucher.IsCanceled)
                                    {
                                        if (clsValidate.CheckValidity_TransactionCodeLength(txtVoucherSerial.Text))
                                        {

                                            string sGiftVoucher_ItemID = "default";
                                            decimal dGiftVoucher_Amount =
                                                clsValidation.Validate_DecimalNumber(txtAmount.Text);
                                            GiftVoucherItemSave(ref sGiftVoucher_ItemID, dGiftVoucher_Amount);

                                            tbl_bpsGiftVoucher oUpdateBatch = new tbl_bpsGiftVoucher(
                                                int.Parse(txtVoucherSerial.Tag.ToString()),
                                                txtVoucherSerial.Text,
                                                txtRemarks.Text,
                                                dtpVoucherDate.GetDateTime(),
                                                oOldGiftVoucher.DateIssued,
                                                oOldGiftVoucher.DateValidFrom,
                                                dtpExpiryDate.GetDateTime(),
                                                int.Parse(txtValidityDays.Text),
                                                oOldGiftVoucher.Invoice_ID, oOldGiftVoucher.PosTransaction_ID,
                                                oOldGiftVoucher.FinancialYear_ID,
                                                clsValidation.Validate_DecimalNumber(txtAmount.Text),
                                                oOldGiftVoucher.SetteledAmount, oOldGiftVoucher.IsSetteled,
                                                oOldGiftVoucher.IsChecked, oOldGiftVoucher.IsApproved,
                                                oOldGiftVoucher.IsIssued, chkRedeemed.IsChecked,
                                                oOldGiftVoucher.IsCanceled,
                                                oOldGiftVoucher.CreateUser_ID, clsSecurity.UserIDLoged,
                                                oOldGiftVoucher.CheckedUser_ID, oOldGiftVoucher.ApprovedUser_ID,
                                                oOldGiftVoucher.CanceldUser_ID,
                                                oOldGiftVoucher.DateCreate, clsSecurity.getServerDateTime(),
                                                oOldGiftVoucher.DateChecked, oOldGiftVoucher.DateApproved,
                                                oOldGiftVoucher.DateCanceled,
                                                oOldGiftVoucher.CreateUserTerminal_ID, clsSecurity.TerminalID,
                                                oOldGiftVoucher.CheckedUserTerminal_ID,
                                                oOldGiftVoucher.ApprovedUserTerminal_ID,
                                                oOldGiftVoucher.CanceledUserTerminal_ID,
                                                oOldGiftVoucher.CompanyID, oOldGiftVoucher.CompanyBranchID,
                                                sGiftVoucher_ItemID
                                            );
                                            oUpdateBatch.Update();

                                            var oSerial =
                                                tbl_genItemMaster_Barcode.Select(
                                                    int.Parse(txtVoucherSerial.Tag.ToString()));
                                            if (oSerial != null)
                                                oSerial.Delete();
                                            tbl_genItemMaster_Barcode oNew_GV_Serial = new tbl_genItemMaster_Barcode(
                                                int.Parse(txtVoucherSerial.Tag.ToString()), sGiftVoucher_ItemID,
                                                txtVoucherSerial.Text, "", "", dtpExpiryDate.GetDateTime(),
                                                clsSecurity.getServerDateTime(), false, false, "");
                                            oNew_GV_Serial.Insert();

                                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                        }
                                    }
                                    else
                                    {
                                        if (oOldGiftVoucher.IsApproved)
                                            SEACCMessageBox.Show("Cannot Update..",
                                                "Selected Gift Voucher has been approved", MessageBoxButton.OK, "Red");
                                        else if (oOldGiftVoucher.IsCanceled)
                                            SEACCMessageBox.Show("Cannot Update..",
                                                "Selected Gift Voucher has been cancelled", MessageBoxButton.OK, "Red");
                                        else
                                            SEACCMessageBox.Show("Cannot Update..", "", MessageBoxButton.OK, "Red");
                                    }
                                }
                                if (oOldGiftVoucher != null) iGiftVoucher_ID = oOldGiftVoucher.GiftVoucherID;
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.CheckPermission_ToSave(false))
                        {
                            if (!txtExcelFilePath.IsChecked)
                            {
                                if (CheckValidity())
                                {
                                    txtVoucherSerial.Tag = tbl_bpsGiftVoucher.SelectAll().Max(r => r.GiftVoucherID) + 1;
                                    if (SEACC_Form.isAutoGenaratedCode)
                                        txtVoucherSerial.Text = SEACC_Form.getAutoGeneratedCode();

                                    if (clsValidate.CheckValidity_TransactionCodeLength(txtVoucherSerial.Text))
                                    {

                                        string sGiftVoucher_ItemID = "default";
                                        decimal dGiftVoucher_Amount =
                                            clsValidation.Validate_DecimalNumber(txtAmount.Text);
                                        GiftVoucherItemSave(ref sGiftVoucher_ItemID, dGiftVoucher_Amount);

                                        tbl_bpsGiftVoucher oGiftVoucher = new tbl_bpsGiftVoucher(
                                            int.Parse(txtVoucherSerial.Tag.ToString()),
                                            txtVoucherSerial.Text, txtRemarks.Text,
                                            dtpVoucherDate.GetDateTime(),
                                            clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                            dtpExpiryDate.GetDateTime(),
                                            int.Parse(txtValidityDays.Text),
                                            "default", "default", clsSecurity.FinancialYearID,
                                            clsValidation.Validate_DecimalNumber(txtAmount.Text), 0, false, false,
                                            false,
                                            false, chkRedeemed.IsChecked, false,
                                            clsSecurity.UserIDLoged, "default", "default", "default", "default",
                                            clsSecurity.getServerDateTime(), clsValidation.defaultDateTime,
                                            clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                            clsValidation.defaultDateTime,
                                            clsSecurity.TerminalID, "default", "default", "default", "default",
                                            clsSecurity.CompanyID, clsSecurity.BranchID, sGiftVoucher_ItemID
                                        );
                                        oGiftVoucher.Insert();
                                        iGiftVoucher_ID = oGiftVoucher.GiftVoucherID;

                                        tbl_genItemMaster_Barcode oNew_GV_Serial = new tbl_genItemMaster_Barcode(
                                            int.Parse(txtVoucherSerial.Tag.ToString()), sGiftVoucher_ItemID,
                                            txtVoucherSerial.Text, "", "", dtpExpiryDate.GetDateTime(),
                                            clsSecurity.getServerDateTime(), false, false, "");
                                        oNew_GV_Serial.Insert();

                                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                                    }
                                }
                            }
                            else if (dtExcelData_ForGrid.Rows.Count > 0)
                            {
                                bool bApprove = false;
                                DateTime dtmApprove = clsValidation.defaultDateTime;
                                string sApprovedUser = "default";
                                string sApprovedTerminal = "default";

                                if (chkApprovedExcel.IsChecked)
                                {
                                    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Approval_Confirmation);
                                    if (bMessegeBoxResult)
                                    {
                                        frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                        frmTwoStepVerify.ShowDialog();
                                        if (frmTwoStepVerify.bVerified)
                                        {
                                            bApprove = true;
                                            dtmApprove = clsSecurity.getServerDateTime();
                                            sApprovedUser = clsSecurity.UserIDLoged;
                                            sApprovedTerminal = clsSecurity.TerminalID;
                                        }
                                        else
                                        {
                                            bSaving = false;
                                        }

                                        frmTwoStepVerify.Close();
                                    }
                                    else
                                    {
                                        bSaving = false;
                                    }
                                }

                                if (bSaving)
                                {
                                    var vPrimaryKey = tbl_bpsGiftVoucher.SelectAll().Max(r => r.GiftVoucherID) + 1;
                                    foreach (DataRow row in dtExcelData_ForGrid.Rows)
                                    {
                                        int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0m));
                                        string sVoucherSerial = clsValidate.ValidateRowValue(row, "VoucherSerial", "");
                                        decimal dGiftVoucher_Amount = clsValidate.ValidateRowValue(row, "Amount", 0m);
                                        int iValidDays = Convert.ToInt32(clsValidate.ValidateRowValue(row, "ValidDays", 0m));
                                        DateTime dtmVoucherDate = clsValidate.ValidateRowValue(row, "VoucherDate", clsValidation.defaultDateTime);
                                        DateTime dtmExpiryDate = clsValidate.ValidateRowValue(row, "ExpiryDate", clsValidation.defaultDateTime);

                                        if (SEACC_Form.isAutoGenaratedCode)
                                            sVoucherSerial = SEACC_Form.getAutoGeneratedCode();

                                        string sGiftVoucher_ItemID = "default";
                                        GiftVoucherItemSave(ref sGiftVoucher_ItemID, dGiftVoucher_Amount);

                                        tbl_bpsGiftVoucher oGiftVoucher = new tbl_bpsGiftVoucher(
                                            vPrimaryKey,
                                            sVoucherSerial, "",
                                            dtmVoucherDate,
                                            clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                            dtmExpiryDate,
                                            iValidDays,
                                            "default", "default", clsSecurity.FinancialYearID,
                                            dGiftVoucher_Amount, 0, false, false, bApprove, false, false, false,
                                            clsSecurity.UserIDLoged, "default", "default", sApprovedUser, "default",
                                            clsSecurity.getServerDateTime(), clsValidation.defaultDateTime,
                                            clsValidation.defaultDateTime, dtmApprove,
                                            clsValidation.defaultDateTime,
                                            clsSecurity.TerminalID, "default", "default", sApprovedTerminal, "default",
                                            clsSecurity.CompanyID, clsSecurity.BranchID, sGiftVoucher_ItemID
                                        );
                                        oGiftVoucher.Insert();
                                        vPrimaryKey++;

                                        iGiftVoucher_ID = oGiftVoucher.GiftVoucherID;
                                    }
                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                                }
                            }
                        }
                    }
                    #endregion
                }

                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
                finally
                {
                    if (bSaving)
                    {
                        ClearFields();
                        RefreshGrid();
                        FillDetails(iGiftVoucher_ID);
                    }
                    Cursor = Cursors.Arrow;
                }
            }
        }

        private void btn_Checked_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.CheckPermission_ToChecked())
                {
                    if (txtVoucherSerial.Tag != null)
                    {
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_bpsGiftVoucher oGiftVoucher = tbl_bpsGiftVoucher.Select(int.Parse(txtVoucherSerial.Tag.ToString()));
                            if (oGiftVoucher != null)
                            {
                                if (!oGiftVoucher.IsChecked)
                                {
                                    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Checked_Confirmation);
                                    if (bMessegeBoxResult)
                                    {
                                        frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                        frmTwoStepVerify.ShowDialog();
                                        if (frmTwoStepVerify.bVerified)
                                        {
                                            oGiftVoucher.IsChecked = true;
                                            oGiftVoucher.DateChecked = clsSecurity.getServerDateTime();
                                            oGiftVoucher.CheckedUser_ID = clsSecurity.UserIDLoged;
                                            oGiftVoucher.CheckedUserTerminal_ID = clsSecurity.TerminalID;
                                            oGiftVoucher.Update();
                                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Checked);
                                        }
                                        frmTwoStepVerify.Close();
                                    }
                                    ClearFields();
                                    RefreshGrid();
                                    FillDetails(oGiftVoucher.GiftVoucherID);
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Alreay Checked", "Selected Gift Voucher has already been checked", MessageBoxButton.OK, "Red");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }

        private void btn_Approved_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.CheckPermission_ToApproved())
                {
                    if (CheckValidity())
                    {
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_bpsGiftVoucher oGiftVoucher = tbl_bpsGiftVoucher.Select(int.Parse(txtVoucherSerial.Tag.ToString()));
                            if (oGiftVoucher != null)
                            {
                                if (!oGiftVoucher.IsApproved)
                                {
                                    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Approval_Confirmation);
                                    if (bMessegeBoxResult)
                                    {
                                        frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                        frmTwoStepVerify.ShowDialog();
                                        if (frmTwoStepVerify.bVerified)
                                        {
                                            oGiftVoucher.IsApproved = true;
                                            oGiftVoucher.DateApproved = clsSecurity.getServerDateTime();
                                            oGiftVoucher.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                            oGiftVoucher.ApprovedUserTerminal_ID = clsSecurity.TerminalID;
                                            oGiftVoucher.Update();
                                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Approved);
                                        }
                                        frmTwoStepVerify.Close();
                                    }
                                    ClearFields();
                                    RefreshGrid();
                                    FillDetails(oGiftVoucher.GiftVoucherID);
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Alreay Approved", "Selected Gift Voucher has already been approved", MessageBoxButton.OK, "Red");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtVoucherSerial, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAmount, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtValidityDays, true, true, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBoxWithCheckBox(txtExcelFilePath, true, false, true);

            txtVoucherSerial.Tag = null;

            txtVoucherSerial.Text = "";
            txtAmount.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            txtValidityDays.Text = cls_Formater.FormatDecimal(0, 0);
            txtRemarks.Text = "";
            txtExcelFilePath.Text = "";

            dtpVoucherDate.SetTime(DateTime.Now);
            dtpExpiryDate.SetTime(clsValidation.defaultDateTime);

            chkRedeemed.IsChecked = false;
            chkApprovedExcel.IsChecked = false;

            SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#FF6161");
            SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#FF6161");

            #region Set Auto Genarate Key fields
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtVoucherSerial.setReadOnlyStatus(true);
                txtVoucherSerial.Text = "<Auto Generate>";
            }
            else
                txtVoucherSerial.setReadOnlyStatus(false);
            #endregion

            txtVoucherSerial.IsEnabled = true;
            txtAmount.IsEnabled = true;
            txtValidityDays.IsEnabled = true;
            txtRemarks.IsEnabled = true;
            dtpVoucherDate.IsEnabled = true;
            dtpExpiryDate.IsEnabled = true;
            chkRedeemed.IsEnabled = false;
            txtExcelFilePath.TextBox1.IsEnabled = false;

            dtExcelData_ForGrid.Rows.Clear();

        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_bpsGiftVoucher oGiftVoucher in tbl_bpsGiftVoucher.SelectAll().Where(r => !r.IsCanceled && r.GiftVoucherID > 0).OrderByDescending(o => o.DateCreate))
                {
                    dgr_Main.dt.Rows.Add("0", oGiftVoucher.GiftVoucherID, oGiftVoucher.SerialNo,
                        cls_Formater.FormatDecimal(oGiftVoucher.VoucherAmount, clsConfig.sPOSBillDecimalPoint),
                        (oGiftVoucher.DateIssued != clsValidation.defaultDateTime ? oGiftVoucher.DateIssued.ToString(cls_Formater.Format_Date2) : "-"),
                        cls_Formater.FormatDecimal(180m, 0),
                        (oGiftVoucher.ExpiryDate != clsValidation.defaultDateTime ? oGiftVoucher.ExpiryDate.ToString(cls_Formater.Format_Date2) : "-"),
                        clsGenaralName.getName_User(oGiftVoucher.CreateUser_ID), clsGenaralName.getName_User(oGiftVoucher.CheckedUser_ID),
                        clsGenaralName.getName_User(oGiftVoucher.ApprovedUser_ID), oGiftVoucher.IsCanceled);
                }
                clsHelpMethods_POS.OrderBy_DataGrid(dgr_Main.dt);
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Check validity

        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_DuplicateFiled())
                {
                    bStatus = true;
                }
            }

            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtVoucherSerial) && !SEACC_Form.isAutoGenaratedCode)
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtAmount) || clsValidation.Validate_DecimalNumber(txtAmount.Text) <= 0)
                bStatus = false;

            return bStatus;
        }

        private bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode && !SEACC_Form.isAutoGenaratedCode)
            {
                tbl_bpsGiftVoucher oGiftvoucher = tbl_bpsGiftVoucher.SelectAll().Where(r => r.SerialNo == txtVoucherSerial.Text.Trim()).FirstOrDefault();
                if (oGiftvoucher != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        #endregion

        #region Fill Details
        private void FillDetails(int sID)
        {
            try
            {

                tbl_bpsGiftVoucher oGiftVoucher = tbl_bpsGiftVoucher.Select(sID);
                if (oGiftVoucher != null)
                {
                    ClearFields();

                    SEACC_Form.IsUpdateMode = true;

                    txtVoucherSerial.Tag = oGiftVoucher.GiftVoucherID;

                    txtVoucherSerial.Text = oGiftVoucher.SerialNo;
                    txtAmount.Text = cls_Formater.FormatDecimal(oGiftVoucher.VoucherAmount, clsConfig.sPOSBillDecimalPoint);
                    txtValidityDays.Text = cls_Formater.FormatDecimal(oGiftVoucher.ValidityDays, 0);
                    txtRemarks.Text = oGiftVoucher.Remark;
                    dtpVoucherDate.SetTime(oGiftVoucher.VoucherDate);
                    dtpExpiryDate.SetTime(oGiftVoucher.ExpiryDate);

                    chkRedeemed.IsEnabled = false;
                    chkRedeemed.IsChecked = oGiftVoucher.IsRedeemed;

                    if (oGiftVoucher.IsChecked)
                        SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                    if (oGiftVoucher.IsApproved)
                        SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Grid Events

        #region Main Grid Events
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string sID = (dgr_Main.grdMain.SelectedCells[1].Column.GetCellContent(item) as TextBlock)?.Text;
                    FillDetails(int.Parse(sID));
                }
            }
            catch
            { }
        }

        private void dgr_Main_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(((DataRowView)(e.Row.DataContext)).Row.ItemArray[10].ToString()))
                {
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#FFA0A0");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Excel Data Grid Event
        private void DgrExcelData_OnLoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_POS.OrderBy_DataGrid(dtExcelData_ForGrid);
        }
        #endregion

        #endregion

        #region Search Events
        private void txtVoucherSerial_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //To do

            //frmSearchForm RowDataSearch = new frmSearchForm();
            //List<string> lstResult = RowDataSearch.Show(Search.Pos_GiftVouchers_NotIssued);

            //if (RowDataSearch.DialogResult == true)
            //{
            //    try
            //    {
            //        FillDetails(int.Parse(lstResult[0]));
            //    }
            //    catch (Exception ex)
            //    {
            //        SEACCExeption.Show(ex);
            //    }
            //}
        }
        #endregion

        #region Excel File Data Uploading Events

        private void txtExcelPath_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtExcelFilePath.IsChecked)
                {
                    OpenFileDialog openfile = new OpenFileDialog();
                    openfile.DefaultExt = ".xlsx";
                    openfile.Filter = "(.xlsx)|*.xlsx";
                    var browsefile = openfile.ShowDialog();
                    if (browsefile == true)
                    {
                        txtExcelFilePath.Text = openfile.FileName;
                        MakeDataTable(openfile.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }


        }

        private void txtExcelFilePath_TextBox_CheckedUnChecked(object sender, EventArgs e)
        {
            ClearFields();

            if (txtExcelFilePath.IsChecked)
            {
                txtVoucherSerial.IsEnabled = false;
                txtAmount.IsEnabled = false;
                txtValidityDays.IsEnabled = false;
                txtRemarks.IsEnabled = false;
                dtpVoucherDate.IsEnabled = false;
                dtpExpiryDate.IsEnabled = false;
                chkRedeemed.IsEnabled = false;
                txtExcelFilePath.TextBox1.IsEnabled = true;
            }
        }
        #endregion

        #region Help Methods

        //Check Whether Item Master Record relavant to Gift Voucher
        private void GiftVoucherItemSave(ref string sGiftVoucher_ItemID, decimal dGiftVoucher_Amount)
        {
            tbl_genItemMaster oGiftVoucherItem = tbl_genItemMaster.SelectAll()
                .Where(r => r.IsGiftVoucher && tbl_genItemMaster_Pricing.Select(r.Item_ID).SellingPrice1 == clsValidation.Validate_DecimalNumber(txtAmount.Text)).FirstOrDefault();
            if (oGiftVoucherItem != null)
            {
                sGiftVoucher_ItemID = oGiftVoucherItem.Item_ID;
            }
            else
            {
                sGiftVoucher_ItemID = clsAutocode.getAutoGeneratedCode("CON/001");//Item Master Next Item ID 
                tbl_genItemMaster oNew_GV_Item = new tbl_genItemMaster(sGiftVoucher_ItemID, "", "Gift Voucher - Rs. " + cls_Formater.FormatDecimal(dGiftVoucher_Amount, 2), "", "", "", "", "default", 0, 0, 0, 0, false, false, false, false, false, "default", "default", "default", "default", "default", "default", "default", "default", 0, 0, 0, 0, 0, 0, 0, "default", false, false, false, false, false, "", false, false, clsSecurity.CompanyID, clsSecurity.BranchID, "default", "default", false, false, false, false, false, false, true, false, true, false, "default", "", 0, "default");
                oNew_GV_Item.Insert();

                tbl_genItemMaster_Pricing oNew_GV_ItemFin = new tbl_genItemMaster_Pricing(sGiftVoucher_ItemID, 0, 0, 0, 0, 0, 0, 0, dGiftVoucher_Amount, 0, 0, 0, 0, 0, true, true);
                oNew_GV_ItemFin.Insert();
            }
        }

        //Transfer Excel Sheet Data to Data Table
        private void MakeDataTable(string path)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(path, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.ActiveSheet;

            int index = 0;
            object rowIndex = 2;

            DataRow row;
            string sMessage = "";

            while (((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 1]).Value2 != null)
            {
                rowIndex = 3 + index;
                row = dtExcelData_ForGrid.NewRow();
                try
                {
                    row[0] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 1]).Value2);//LineNo
                    row[1] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 2]).Value2);//VoucherSerial
                    row[2] = cls_Formater.FormatDecimal(Convert.ToDecimal(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 3]).Value2), clsConfig.sPOSBillDecimalPoint);//Amount
                    row[3] = (DateTime.FromOADate(Convert.ToDouble(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 4]).Value2))).ToString(cls_Formater.Format_Date2);//VoucherDate
                    row[4] = cls_Formater.FormatDecimal(Convert.ToDecimal(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 5]).Value2), 0);//ValidDays
                    row[5] = (DateTime.FromOADate(Convert.ToDouble(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 6]).Value2))).ToString(cls_Formater.Format_Date2);//ExpiryDate
                    index++;
                    dtExcelData_ForGrid.Rows.Add(row);
                }
                catch (Exception)
                {
                    sMessage += "Excel Row " + rowIndex + "\n";
                    index++;
                }
            }

            if (sMessage.Length > 1)
                SEACCMessageBox.Show("Something Went Wrong..", "Following Rows were not added...\n" + sMessage, MessageBoxButton.OK, "Red");

            if (dtExcelData_ForGrid.Rows.Count > 0)
                dtExcelData_ForGrid.Rows.RemoveAt(dtExcelData_ForGrid.Rows.Count - 1);

            app.Workbooks.Close();
        }

        #endregion
    }
}
