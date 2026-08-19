using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Digiteq_Logic;
using SEACC_WPFControls;
using DataTire;
using System.Data;
using System.Windows.Input;
using SEACC_POS.Controls;
using Digiteq_Logic_POS;

namespace SEACC_POS.TransactionForms
{
    public partial class UC_Cashier_SignIn : UserControl
    {
        #region Class Variable
        BrushConverter bc = new BrushConverter();
        DataTable dt_CashOut = new DataTable();
        #endregion

        #region Form Load
        public UC_Cashier_SignIn()
        {
            #region Form Initialize
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.POS_CashierSignIn;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table

            #region Main Table
            dgr_Main.dt.Columns.Add("DayDetailIndex");
            dgr_Main.dt.Columns.Add("TransactionDate");
            dgr_Main.dt.Columns.Add("Branch");
            dgr_Main.dt.Columns.Add("Terminal_ID");
            dgr_Main.dt.Columns.Add("SignInFloatInAmt");
            dgr_Main.dt.Columns.Add("SignInCashier_ID");
            dgr_Main.dt.Columns.Add("SignInCashier_Name");
            dgr_Main.dt.Columns.Add("SignInChecked_By");
            dgr_Main.dt.Columns.Add("SignInApproved_By");
            dgr_Main.dt.Columns.Add("IsManagerSignOff");
            dgr_Main.dt.Columns.Add("DayEndFloatInAmt");
            dgr_Main.dt.Columns.Add("MangerSignOffUser_ID");
            dgr_Main.dt.Columns.Add("MangerSignOffUser_Name");
            dgr_Main.dt.Columns.Add("MangerSignOffChecked_By");
            dgr_Main.dt.Columns.Add("MangerSignOffApproved_By");
            dgr_Main.dt.Columns.Add("IsCancelled", typeof(bool));
            #endregion

            #region Cash Out Table
            dt_CashOut.Columns.Add("LineNo");
            dt_CashOut.Columns.Add("Time");
            dt_CashOut.Columns.Add("Withdraw_Amount");
            dt_CashOut.Columns.Add("Remark");
            #endregion

            #endregion

            #region Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false, false, true);
            SEACC_Form.btn_New.Click += btn_New_Click;
            SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            SEACC_Form.btn_Save.Click += btn_Save_Click;
            SEACC_Form.btn_Approved.Click += btn_Approved_Click;
            #endregion

            #region Main Grid
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "##", "DayDetailIndex", 25, false, true);
            dgr_Main.Add_DatagridColoumn("Date", "TransactionDate", 100, true);
            dgr_Main.Add_DatagridColoumn("Branch", "Branch", 100, true);
            dgr_Main.Add_DatagridColoumn("Terminal ID", "Terminal_ID", 170, false);
            dgr_Main.Add_DatagridColoumn("Cashier Name", "SignInCashier_Name", 120);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Sign In Float", "SignInFloatInAmt", 100, true, true);
            dgr_Main.Add_DatagridColoumn("Manager Sign Off", "IsManagerSignOff", 120);
            dgr_Main.Add_DatagridColoumn("Checked By", "SignInChecked_By", 100, false);
            dgr_Main.Add_DatagridColoumn("Approved By", "SignInApproved_By", 100, false);
            dgr_Main.Add_DatagridColoumn("Is Cancelled", "IsCancelled", 120, false);
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(670);
        }
        #endregion

        #region Action Buttons
        //New Button
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }

        //Cancell Button
        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.CheckPermission_ToCancel())
                {
                    if (txtDayDetailIndex.Tag != null)
                    {
                        if (SEACC_Form.IsUpdateMode)
                        {
                            //if (CheckValidity_TransactionStarted())
                            {
                                tbl_posDayStartAndEnd_Detail oCashierSignOff = tbl_posDayStartAndEnd_Detail.Select(int.Parse(txtDayDetailIndex.Tag.ToString()));
                                if (oCashierSignOff != null)
                                {
                                    if (!oCashierSignOff.IsApproved)
                                    {
                                        if (!oCashierSignOff.IsCanceled)
                                        {
                                            bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                                            if (bMessegeBoxResult)
                                            {
                                                frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                                frmTwoStepVerify.ShowDialog();
                                                if (frmTwoStepVerify.bVerified)
                                                {
                                                    oCashierSignOff.IsCanceled = true;
                                                    oCashierSignOff.DateCanceled = clsSecurity.getServerDateTime();
                                                    oCashierSignOff.CanceledUser_ID = clsSecurity.UserIDLoged;
                                                    oCashierSignOff.Update();
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
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }

        //Save Button
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            int iDayDetail_ID = -1;
            if (CheckValidity())
            {
                try
                {
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            tbl_posDayStartAndEnd_Detail oCashierSignIn = tbl_posDayStartAndEnd_Detail.Select(int.Parse(txtDayDetailIndex.Tag.ToString()));
                            if (oCashierSignIn != null)
                            {
                                if (!oCashierSignIn.IsApproved && !oCashierSignIn.IsCanceled && !oCashierSignIn.IsMgtSignOffCreated)
                                {
                                    tbl_posDayStartAndEnd_Detail oDayStart = new tbl_posDayStartAndEnd_Detail(
                                        int.Parse(txtDayDetailIndex.Tag.ToString()),
                                        oCashierSignIn.DayIndex,
                                        dtpTxDate.GetDateTime(),
                                        txtTerminal_ID.Text,
                                        txtCashier.Tag.ToString(),
                                        clsValidation.Validate_DecimalNumber(txtFloatInAmount.Text), 0, oCashierSignIn.IsChecked, oCashierSignIn.IsApproved, oCashierSignIn.IsCanceled, oCashierSignIn.CreateUser_ID, clsSecurity.UserIDLoged, oCashierSignIn.CheckedUser_ID, oCashierSignIn.ApprovedUser_ID, oCashierSignIn.CanceledUser_ID,
                                        oCashierSignIn.DateCreated, clsSecurity.getServerDateTime(), oCashierSignIn.DateChecked, oCashierSignIn.DateApproved, oCashierSignIn.DateCanceled, oCashierSignIn.DayEndCashAmt, oCashierSignIn.DayEndOtherAmt, oCashierSignIn.DayEndVarienceAmt, oCashierSignIn.IsMgtSignOffCreated, oCashierSignIn.IsMgtSignOffChecked, oCashierSignIn.IsMgtSignOffApproved, oCashierSignIn.IsMgtSignOffCanceled,
                                        oCashierSignIn.MgtSignOffCreateUser_ID, oCashierSignIn.MgtSignOffModifiedUser_ID, oCashierSignIn.MgtSignOffCheckedUser_ID, oCashierSignIn.MgtSignOffApprovedUser_ID, oCashierSignIn.MgtSignOffCanceledUser_ID, oCashierSignIn.MgtSignOffCreateTime, oCashierSignIn.MgtSignOffModifiedTime, oCashierSignIn.MgtSignOffCheckedTime, oCashierSignIn.MgtSignOffApprovedTime, oCashierSignIn.MgtSignOffCanceledTime);
                                    oDayStart.Update();

                                    tbl_posDayStartAndEnd_Detail_CashWithdrawal.DeleteAllByDayDetail_Index(oDayStart.DayDetail_Index);
                                    Save_CashWithdrawals();

                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                }
                                else
                                {
                                    if (oCashierSignIn.IsApproved)
                                        SEACCMessageBox.Show("Cannot Update..",
                                            "Selected Day Start has been approved", MessageBoxButton.OK, "Red");
                                    else if (oCashierSignIn.IsMgtSignOffCreated)
                                        SEACCMessageBox.Show("Cannot Update..",
                                            "Manager Sign Off has been done", MessageBoxButton.OK, "Red");
                                    else if (oCashierSignIn.IsCanceled)
                                        SEACCMessageBox.Show("Cannot Update..",
                                            "Selected Day Start has been cancelled", MessageBoxButton.OK, "Red");
                                    else
                                        SEACCMessageBox.Show("Cannot Update..", "", MessageBoxButton.OK, "Red");
                                }
                            }
                            if (oCashierSignIn != null) iDayDetail_ID = oCashierSignIn.DayDetail_Index;
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.CheckPermission_ToSave(false))
                        {
                            tbl_posDayStartAndEnd oBranchDayStart = tbl_posDayStartAndEnd.SelectAllByCompanyBranch_ID(clsSecurity.BranchID)
                                                                                            .Where(r => r.DateCreated.Date == clsSecurity.getServerDateTime().Date).FirstOrDefault();
                            if (oBranchDayStart == null)
                            {
                                int iDayIndex = 1;
                                var vRecs = tbl_posDayStartAndEnd.SelectAll();
                                if (vRecs != null && vRecs.Count > 0)
                                    iDayIndex = vRecs.Max(r => r.DayIndex) + 1;
                                oBranchDayStart = new tbl_posDayStartAndEnd(iDayIndex, false, false, false, clsSecurity.UserIDLoged, "default", "default", "default", "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.TerminalID, "default", "default", "default", "default", clsSecurity.CompanyID, clsSecurity.BranchID, clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction));
                                oBranchDayStart.Insert();
                            }

                            var vRecods = tbl_posDayStartAndEnd_Detail.SelectAll();
                            if (vRecods != null && vRecods.Count > 0)
                                txtDayDetailIndex.Tag = vRecods.Max(r => r.DayDetail_Index) + 1;
                            else
                                txtDayDetailIndex.Tag = 1;

                            tbl_posDayStartAndEnd_Detail oDayStart = new tbl_posDayStartAndEnd_Detail(
                                int.Parse(txtDayDetailIndex.Tag.ToString()),
                                oBranchDayStart.DayIndex,
                                dtpTxDate.GetDateTime(),
                                txtTerminal_ID.Text,
                                txtCashier.Tag.ToString(),
                                clsValidation.Validate_DecimalNumber(txtFloatInAmount.Text), 0,
                                false, false, false, clsSecurity.UserIDLoged, "default", "default", "default", "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                0, 0, 0, false, false, false, false, "default", "default", "default", "default", "default", clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime
                            );

                            oDayStart.Insert();
                            iDayDetail_ID = oDayStart.DayDetail_Index;

                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
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
                    ClearFields();
                    RefreshGrid();
                    FillDetails(iDayDetail_ID);
                }
            }
        }

        //Approve Button
        private void btn_Approved_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.CheckPermission_ToApproved())
                {
                    if (CheckValidity_EmptyField())
                    {
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_posDayStartAndEnd_Detail oCashierSignIn = tbl_posDayStartAndEnd_Detail.Select(int.Parse(txtDayDetailIndex.Tag.ToString()));
                            if (oCashierSignIn != null)
                            {
                                if (!oCashierSignIn.IsApproved)
                                {
                                    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Approval_Confirmation);
                                    if (bMessegeBoxResult)
                                    {
                                        frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                        frmTwoStepVerify.ShowDialog();
                                        if (frmTwoStepVerify.bVerified)
                                        {
                                            oCashierSignIn.IsApproved = true;
                                            oCashierSignIn.DateApproved = clsSecurity.getServerDateTime();
                                            oCashierSignIn.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                            oCashierSignIn.Update();
                                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Approved);
                                        }
                                        frmTwoStepVerify.Close();
                                    }
                                    ClearFields();
                                    RefreshGrid();
                                    FillDetails(oCashierSignIn.DayIndex);
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Alreay Approved", "Selected Day Start has already been approved", MessageBoxButton.OK, "Red");
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

        //Cash Withdrawal Button
        private void btnCashWithdrawAdd_Click(object sender, RoutedEventArgs e)
        {
            bool bMessegeBoxResult = SEACCMessageBox.Show("Cash Withdrawal Confirmation...", "Are you sure to do a cash withdrawal now?", MessageBoxButton.YesNo, "#FF5B6B76");
            if (bMessegeBoxResult)
            {
                frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                frmTwoStepVerify.ShowDialog();
                if (frmTwoStepVerify.bVerified)
                {
                    dt_CashOut.Rows.Add("", clsSecurity.getServerDateTime().ToString("yyyy-MMM-dd HH:mm"), cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint), "");
                }
            }
        }

        //Cash Withdrawal Delete
        private void btnCashWithdrawDelete_Click(object sender, RoutedEventArgs e)
        {
            bool bMessegeBoxResult = SEACCMessageBox.Show("Cash Withdrawal Delete Confirmation...", "Are you sure to delete this cash withdrawal now?", MessageBoxButton.YesNo, "#FF5B6B76");
            if (bMessegeBoxResult)
            {
                frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                frmTwoStepVerify.ShowDialog();
                if (frmTwoStepVerify.bVerified)
                {
                    object selectedItem = dgr_CashOut.SelectedItem;
                    if (selectedItem != null)
                    {
                        string sLineNo = (dgr_CashOut.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock).Text;
                        DataRow[] items = dt_CashOut.Select("LineNo ='" + sLineNo + "'");
                        if (items.Length > 0)
                        {
                            foreach (DataRow item in items)
                                dt_CashOut.Rows.Remove(item);
                        }
                        clsHelpMethods_POS.OrderBy_DataGrid(dt_CashOut);
                    }
                }
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtDayDetailIndex, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtTerminal_ID, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCashier, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtFloatInAmount, true, true, false);

            txtDayDetailIndex.Tag = null;
            txtTerminal_ID.Tag = clsSecurity.TerminalID;
            txtCashier.Tag = clsSecurity.UserIDLoged;

            txtDayDetailIndex.Text = "";
            txtTerminal_ID.Text = clsSecurity.TerminalID;
            txtCashier.Text = clsGenaralName.getName_User(clsSecurity.UserIDLoged);
            txtFloatInAmount.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);

            dtpTxDate.SetTime(DateTime.Now);
            chkManagerSignOffApproved.IsChecked = false;

            #region Set Auto Genarate Key fields
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtDayDetailIndex.setReadOnlyStatus(true);
                txtDayDetailIndex.Text = "<Auto Generate>";
            }
            else
                txtDayDetailIndex.setReadOnlyStatus(false);
            #endregion

            SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#FF6161");
            SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#FF6161");

            grdCashWithdrawals.Visibility = Visibility.Collapsed;

            dt_CashOut.Clear();
            dgr_CashOut.ItemsSource = dt_CashOut.DefaultView;
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_posDayStartAndEnd_Detail oCashierSignIN in tbl_posDayStartAndEnd_Detail.SelectAll().Where(r => r.SignInCashier_ID == clsSecurity.UserIDLoged).OrderByDescending(o => o.DateCreated))
                {
                    tbl_posDayStartAndEnd oDayStart = tbl_posDayStartAndEnd.Select(oCashierSignIN.DayIndex);
                    if (oDayStart != null)
                    {
                        if (oDayStart.CompanyBranch_ID == clsSecurity.BranchID)
                        {
                            dgr_Main.dt.Rows.Add(
                                oCashierSignIN.DayDetail_Index,                             //DayDetailIndex
                                oCashierSignIN.PosDate.ToString(cls_Formater.Format_Date2), //TransactionDate
                                clsGenaralName.getName_CompanyBranchMaster(oDayStart.CompanyBranch_ID),//Branch
                                oCashierSignIN.PosTerminal_ID,                              //Terminal_ID
                                cls_Formater.FormatDecimal(oCashierSignIN.SignInFloatAmt, clsConfig.sPOSBillDecimalPoint),//SignInFloatInAmt
                                oCashierSignIN.SignInCashier_ID,                            //SignInCashier_ID
                                clsGenaralName.getName_User(oCashierSignIN.SignInCashier_ID),//SignInCashier_Name
                                clsGenaralName.getName_User(oCashierSignIN.CheckedUser_ID), //SignInChecked_By
                                clsGenaralName.getName_User(oCashierSignIN.ApprovedUser_ID),//SignInApproved_By
                                oCashierSignIN.IsMgtSignOffApproved ? "Yes" : "No",         //IsManagerSignOffApproved
                                cls_Formater.FormatDecimal(oCashierSignIN.DayEndCashAmt, clsConfig.sPOSBillDecimalPoint),//DayEndFloatInAmt
                                oCashierSignIN.MgtSignOffCreateUser_ID,                     //MangerSignOffUser_ID
                                clsGenaralName.getName_User(oCashierSignIN.MgtSignOffCreateUser_ID),//MangerSignOffUser_Name
                                clsGenaralName.getName_User(oCashierSignIN.MgtSignOffCheckedUser_ID),//MangerSignOffChecked_By
                                clsGenaralName.getName_User(oCashierSignIN.MgtSignOffApprovedUser_ID),//MangerSignOffApproved_By
                                oCashierSignIN.IsCanceled                                   //IsCancelled
                                );
                        }
                    }
                }
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
                if (CkeckValidity_PerviousDayEnd())
                {
                    if (CkeckValidity_CurrentDayEnd())
                    {
                        if (CheckValidity_DuplicateFiled())
                        {
                            bStatus = true;
                        }
                    }
                }
            }

            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtDayDetailIndex) && !SEACC_Form.isAutoGenaratedCode)
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtTerminal_ID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCashier))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFloatInAmount) || clsValidation.Validate_DecimalNumber(txtFloatInAmount.Text) <= 0)
                bStatus = false;

            return bStatus;
        }

        private bool CkeckValidity_PerviousDayEnd()
        {
            bool bStatus = true;
            tbl_posDayStartAndEnd vDayStarAndEnd = tbl_posDayStartAndEnd.SelectAllByCompanyBranch_ID(clsSecurity.BranchID).FirstOrDefault(r => r.DateCreated.Date < clsSecurity.getServerDateTime().Date && !r.IsApproved);
            if (vDayStarAndEnd != null)
            {
                bStatus = false;
                SEACCMessageBox.Show("Restricted...", "Previous Day End has been not done or approved yet", MessageBoxButton.OK, "Red");
            }
            return bStatus;
        }

        private bool CkeckValidity_CurrentDayEnd()
        {
            bool bStatus = true;
            tbl_posDayStartAndEnd vDayStarAndEnd = tbl_posDayStartAndEnd.SelectAllByCompanyBranch_ID(clsSecurity.BranchID).FirstOrDefault(r => r.DateCreated.Date == clsSecurity.getServerDateTime().Date && r.IsApproved);
            if (vDayStarAndEnd != null)
            {
                bStatus = false;
                SEACCMessageBox.Show("Restricted...", "Today Day End has been completed", MessageBoxButton.OK, "Red");
            }
            return bStatus;
        }

        private bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_posDayStartAndEnd_Detail oNotCompltedDayEnd = tbl_posDayStartAndEnd_Detail.SelectAll().FirstOrDefault(r => !r.IsCanceled && r.PosTerminal_ID == clsSecurity.TerminalID && !r.IsMgtSignOffApproved);
                if (oNotCompltedDayEnd != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show("Restricted...", "Terminal # : '" + oNotCompltedDayEnd.PosTerminal_ID + "' has a on going session now...\n It was created by " + clsGenaralName.getName_User(oNotCompltedDayEnd.SignInCashier_ID), MessageBoxButton.OK, "Red");
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
                ClearFields();

                tbl_posDayStartAndEnd_Detail oCashierSignIn = tbl_posDayStartAndEnd_Detail.Select(sID);
                if (oCashierSignIn != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtDayDetailIndex.Tag = oCashierSignIn.DayDetail_Index;
                    txtTerminal_ID.Tag = oCashierSignIn.PosTerminal_ID;
                    txtCashier.Tag = oCashierSignIn.SignInCashier_ID;

                    txtDayDetailIndex.Text = oCashierSignIn.DayDetail_Index.ToString().Trim();
                    txtTerminal_ID.Text = oCashierSignIn.PosTerminal_ID;
                    txtCashier.Text = clsGenaralName.getName_User(oCashierSignIn.SignInCashier_ID);
                    txtFloatInAmount.Text = cls_Formater.FormatDecimal(oCashierSignIn.SignInFloatAmt, clsConfig.sPOSBillDecimalPoint);

                    dtpTxDate.SetTime(oCashierSignIn.PosDate);
                    chkManagerSignOffApproved.IsChecked = oCashierSignIn.IsMgtSignOffApproved;

                    if (oCashierSignIn.IsChecked)
                        SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                    if (oCashierSignIn.IsApproved)
                        SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#3DFF3D");

                    grdCashWithdrawals.Visibility = Visibility.Visible;
                    dt_CashOut.Rows.Clear();
                    foreach (tbl_posDayStartAndEnd_Detail_CashWithdrawal oWithdrawal in tbl_posDayStartAndEnd_Detail_CashWithdrawal.SelectAllByDayDetail_Index(oCashierSignIn.DayDetail_Index))
                    {
                        dt_CashOut.Rows.Add("", oWithdrawal.Withdrawal_Time.ToString("yyyy-MMM-dd HH:mm"), cls_Formater.FormatDecimal(oWithdrawal.Amount, clsConfig.sPOSBillDecimalPoint), oWithdrawal.Remark);
                    }

                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Grid Events
        #region Main Grid
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string sID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock)?.Text;
                    ClearFields();
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
                var vData = ((DataRowView)(e.Row.DataContext)).Row.ItemArray[15].ToString();
                if (Convert.ToBoolean(vData))
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

        #region Cash Withdrawal Grid
        private void dgr_CashOut_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sColumnName = e.Column.SortMemberPath;
            int irowID = dgr_Main.SelectedIndex;
            TextBox t;
            if (sColumnName == "Withdraw_Amount")
            {
                t = e.EditingElement as TextBox;
                decimal dAmount = 0m;
                try
                {
                    dAmount = decimal.Parse(t.Text);
                }
                catch (Exception)
                {
                    SEACCMessageBox.Show("Oops..!", "Please enter numeric value", MessageBoxButton.OK);
                }
                t.Text = cls_Formater.FormatDecimal(dAmount, clsConfig.sPOSBillDecimalPoint);
            }
        }

        private void dgr_CashOut_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_POS.OrderBy_DataGrid(dt_CashOut);
        }
        #endregion
        #endregion

        #region Text Box Events
        //Cash Withrawal Grid - Remark Column Text Box
        private void OnTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (Key.Return == e.Key &&
                0 < (ModifierKeys.Shift & e.KeyboardDevice.Modifiers))
            {
                var tb = (TextBox)sender;
                var caret = tb.CaretIndex;
                tb.Text = tb.Text.Insert(caret, Environment.NewLine);
                tb.CaretIndex = caret + 1;
                e.Handled = true;
            }
        }
        #endregion

        #region Help Methods

        private void Save_CashWithdrawals()
        {
            foreach (DataRow row in dt_CashOut.Rows)
            {
                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0m));
                DateTime dtmTime = clsValidate.ValidateRowValue(row, "Time", clsValidation.defaultDateTime);
                decimal dWithdraw_Amount = clsValidate.ValidateRowValue(row, "Withdraw_Amount", 0m);
                string sRemark = clsValidate.ValidateRowValue(row, "Remark", "");

                tbl_posDayStartAndEnd_Detail_CashWithdrawal oPoSWithdrawal = new tbl_posDayStartAndEnd_Detail_CashWithdrawal(iLine_no, int.Parse(txtDayDetailIndex.Tag.ToString()), dtmTime, dWithdraw_Amount, sRemark);
                oPoSWithdrawal.Insert();
            }
        }
        #endregion
    }
}
