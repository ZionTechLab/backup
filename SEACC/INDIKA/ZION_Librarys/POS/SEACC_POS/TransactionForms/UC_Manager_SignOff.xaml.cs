using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Digiteq_Logic;
using SEACC_WPFControls;
using DataTire;
using System.Data;
using SEACC_POS.Controls;

namespace SEACC_POS.TransactionForms
{
    public partial class UC_Manager_SignOff : UserControl
    {
        #region Class Variable
        BrushConverter bc = new BrushConverter();
        #endregion

        #region Form Load
        public UC_Manager_SignOff()
        {
            #region Form Initialize
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.POS_ManagerSignOff;
            SEACC_Form.Initialize();
            #endregion

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
            #endregion

            #region Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false, true, false);
            SEACC_Form.btn_New.Click += btn_New_Click;
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
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Sign Off Float", "DayEndFloatInAmt", 100, true, true);
            dgr_Main.Add_DatagridColoumn("Manager Sign Off", "IsManagerSignOff", 120, false);
            dgr_Main.Add_DatagridColoumn("Approved Manager", "MangerSignOffApproved_By", 120);
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
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }

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
                            tbl_posDayStartAndEnd_Detail oMgrSignOff = tbl_posDayStartAndEnd_Detail.Select(int.Parse(dtpTxDate.Tag.ToString()));
                            if (oMgrSignOff != null)
                            {
                                if (!oMgrSignOff.IsMgtSignOffApproved && !oMgrSignOff.IsMgtSignOffCanceled)
                                {
                                    tbl_posDayStartAndEnd_Detail oUpdateMgrSignOff = new tbl_posDayStartAndEnd_Detail(
                                        int.Parse(dtpTxDate.Tag.ToString()),
                                        oMgrSignOff.DayIndex,
                                        dtpTxDate.GetDateTime(),
                                        txtTerminal_ID.Text,
                                        txtCashier.Tag.ToString(),
                                        oMgrSignOff.SignInFloatAmt, oMgrSignOff.SignInotherAmt,
                                        oMgrSignOff.IsChecked, oMgrSignOff.IsApproved, oMgrSignOff.IsCanceled, oMgrSignOff.CreateUser_ID,
                                        oMgrSignOff.ModifiedUser_ID, oMgrSignOff.CheckedUser_ID, oMgrSignOff.ApprovedUser_ID, oMgrSignOff.CanceledUser_ID,
                                        oMgrSignOff.DateCreated, oMgrSignOff.DateModified, oMgrSignOff.DateChecked, oMgrSignOff.DateApproved,
                                        oMgrSignOff.DateCanceled,
                                        clsValidation.Validate_DecimalNumber(txtFloatOutAmount.Text),
                                        oMgrSignOff.DayEndOtherAmt,
                                        oMgrSignOff.DayEndVarienceAmt,
                                        true,
                                        oMgrSignOff.IsMgtSignOffChecked,
                                        oMgrSignOff.IsMgtSignOffApproved,
                                        oMgrSignOff.IsMgtSignOffCanceled,
                                        oMgrSignOff.MgtSignOffCreateUser_ID != "default" ? oMgrSignOff.MgtSignOffCreateUser_ID : clsSecurity.UserIDLoged,
                                        oMgrSignOff.MgtSignOffCreateUser_ID != "default" ? clsSecurity.UserIDLoged : oMgrSignOff.MgtSignOffModifiedUser_ID,
                                        oMgrSignOff.MgtSignOffCheckedUser_ID,
                                        oMgrSignOff.MgtSignOffApprovedUser_ID,
                                        oMgrSignOff.MgtSignOffCanceledUser_ID,
                                        oMgrSignOff.MgtSignOffCreateUser_ID != "default" ? oMgrSignOff.MgtSignOffCreateTime : clsSecurity.getServerDateTime(),
                                        oMgrSignOff.MgtSignOffCreateUser_ID != "default" ? clsSecurity.getServerDateTime() : oMgrSignOff.MgtSignOffModifiedTime,
                                        oMgrSignOff.MgtSignOffCheckedTime, oMgrSignOff.MgtSignOffApprovedTime, oMgrSignOff.MgtSignOffCanceledTime);

                                    oUpdateMgrSignOff.Update();
                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                }
                                else
                                {
                                    if (oMgrSignOff.IsMgtSignOffApproved)
                                        SEACCMessageBox.Show("Cannot Update..",
                                            "Selected Day End has been approved", MessageBoxButton.OK, "Red");
                                    else if (oMgrSignOff.IsMgtSignOffCanceled)
                                        SEACCMessageBox.Show("Cannot Update..",
                                            "Selected Day End has been cancelled", MessageBoxButton.OK, "Red");
                                    else
                                        SEACCMessageBox.Show("Cannot Update..", "", MessageBoxButton.OK, "Red");
                                }
                            }
                            if (oMgrSignOff != null) iDayDetail_ID = oMgrSignOff.DayDetail_Index;
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.CheckPermission_ToSave(false))
                        {
                            //No Development
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
                            tbl_posDayStartAndEnd_Detail oMgrSignOff = tbl_posDayStartAndEnd_Detail.Select(int.Parse(dtpTxDate.Tag.ToString()));
                            if (oMgrSignOff != null)
                            {
                                if (!oMgrSignOff.IsMgtSignOffApproved)
                                {
                                    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Approval_Confirmation);
                                    if (bMessegeBoxResult)
                                    {
                                        frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                        frmTwoStepVerify.ShowDialog();
                                        if (frmTwoStepVerify.bVerified)
                                        {
                                            oMgrSignOff.IsMgtSignOffApproved = true;
                                            oMgrSignOff.MgtSignOffApprovedTime = clsSecurity.getServerDateTime();
                                            oMgrSignOff.MgtSignOffApprovedUser_ID = clsSecurity.UserIDLoged;
                                            oMgrSignOff.Update();
                                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Approved);
                                        }
                                        frmTwoStepVerify.Close();
                                    }
                                    ClearFields();
                                    RefreshGrid();
                                    FillDetails(oMgrSignOff.DayIndex);
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
        #endregion

        #region Clear Field
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtTerminal_ID, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCashier, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtFloatOutAmount, true, true, false);

            dtpTxDate.Tag = null;
            txtTerminal_ID.Tag = null;
            txtCashier.Tag = null;

            txtTerminal_ID.Text = "";
            txtCashier.Text = "";
            txtFloatOutAmount.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);

            dtpTxDate.SetTime(DateTime.Now);

            SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#FF6161");
            SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#FF6161");

        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_posDayStartAndEnd_Detail oCashierSignIN in tbl_posDayStartAndEnd_Detail.SelectAll().Where(r => !r.IsCanceled && !r.IsMgtSignOffApproved).OrderByDescending(o => o.DateCreated))
                {
                    tbl_posDayStartAndEnd oDayStart = tbl_posDayStartAndEnd.Select(oCashierSignIN.DayIndex);
                    if (oDayStart != null)
                    {
                        if (oDayStart.CompanyBranch_ID == clsSecurity.BranchID)
                        {
                            dgr_Main.dt.Rows.Add
                                (
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
                                clsGenaralName.getName_User(oCashierSignIN.MgtSignOffApprovedUser_ID)//MangerSignOffApproved_By
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
                bStatus = true;
            }

            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtTerminal_ID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCashier))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFloatOutAmount) || clsValidation.Validate_DecimalNumber(txtFloatOutAmount.Text) < 0)
                bStatus = false;

            return bStatus;
        }

        #endregion

        #region Fill Details
        private void FillDetails(int sID)
        {
            try
            {
                tbl_posDayStartAndEnd_Detail oTxDay = tbl_posDayStartAndEnd_Detail.Select(sID);
                if (oTxDay != null)
                {
                    ClearFields();

                    SEACC_Form.IsUpdateMode = true;

                    dtpTxDate.Tag = oTxDay.DayDetail_Index;
                    txtTerminal_ID.Tag = oTxDay.PosTerminal_ID;
                    txtCashier.Tag = oTxDay.SignInCashier_ID;

                    txtTerminal_ID.Text = oTxDay.PosTerminal_ID;
                    txtCashier.Text = clsGenaralName.getName_User(oTxDay.SignInCashier_ID);
                    txtFloatOutAmount.Text = cls_Formater.FormatDecimal(oTxDay.DayEndCashAmt, clsConfig.sPOSBillDecimalPoint);

                    dtpTxDate.SetTime(oTxDay.PosDate);

                    if (oTxDay.IsMgtSignOffChecked)
                        SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                    if (oTxDay.IsMgtSignOffApproved)
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
            //try
            //{
            //    if (Convert.ToBoolean(((DataRowView)(e.Row.DataContext)).Row.ItemArray[17].ToString()))
            //    {
            //        e.Row.Foreground = (Brush)bc.ConvertFrom("#FFA0A0");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    SEACCExeption.Show(ex);
            //}
        }
        #endregion
    }
}
