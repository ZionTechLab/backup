using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataTire;
using Digiteq_Logic;
using System.Data;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_LeaveTypesMaster.xaml
    /// </summary>
    public partial class UC_LeaveTypesMaster : UserControl
    {
        #region Form Load
        public UC_LeaveTypesMaster()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Leave_Types_Creation;
            SEACC_Form.Initialize(); 
            #endregion

            #region Initialize DataTable
            dgr_Main.dt.Columns.Add("LTCode");
            dgr_Main.dt.Columns.Add("LTName");
            dgr_Main.dt.Columns.Add("Days");
            dgr_Main.dt.Columns.Add("Status"); 
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click; 
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Code", "LTCode", 70);
            dgr_Main.Add_DatagridColoumn("Type", "LTName", 120);
            dgr_Main.Add_DatagridColoumn("Days", "Days", 100);
            dgr_Main.Add_DatagridColoumn("Status", "Status", 100); 
            #endregion

            clearFields();
            RefreshGrid();
        }
        #endregion

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(470);
        }
        #endregion

        #region Action Buttons
        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            clearFields();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtLeaveTypeCode.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_hrMasLeaveTypes detail = tbl_hrMasLeaveTypes.Select(txtLeaveTypeCode.Text.Trim(),clsSecurity.CompanyID,clsSecurity.BranchID);
                            if (detail != null)
                            {
                                detail.IsCanceled = true;
                                detail.UserID_Canceled = clsSecurity.UserIDLoged;
                                detail.Date_Canceled = clsSecurity.getServerDateTime();
                                detail.TerminalID_Canceled = clsSecurity.TerminalID;
                                detail.Update();

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                clearFields();
                                RefreshGrid();
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

        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {
                            tbl_hrMasLeaveTypes oOldRecord = tbl_hrMasLeaveTypes.Select(txtLeaveTypeCode.Text.Trim(),clsSecurity.CompanyID,clsSecurity.BranchID);
                            if (oOldRecord != null)
                            {
                                tbl_hrMasLeaveTypes oLeaveType = new tbl_hrMasLeaveTypes(clsSecurity.CompanyID, clsSecurity.BranchID, txtLeaveTypeCode.Text.Trim(), txtLeaveName.Text, chkStatus.IsChecked, chkDatLimit.IsChecked, int.Parse(txtNoOfDays.Text), oOldRecord.IsCanceled, oOldRecord.UserID_Created, clsSecurity.UserIDLoged, oOldRecord.UserID_Canceled, oOldRecord.TerminalID_Created, clsSecurity.TerminalID, oOldRecord.TerminalID_Canceled, oOldRecord.Date_Created, clsSecurity.getServerDateTime(), oOldRecord.Date_Canceled);
                                oLeaveType.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.isAutoGenaratedCode)
                            txtLeaveTypeCode.Text = SEACC_Form.getAutoGeneratedCode();

                        tbl_hrMasLeaveTypes oLeaveType = new tbl_hrMasLeaveTypes(clsSecurity.CompanyID, clsSecurity.BranchID,txtLeaveTypeCode.Text, txtLeaveName.Text,chkStatus.IsChecked, chkDatLimit.IsChecked, int.Parse(txtNoOfDays.Text), false, clsSecurity.UserIDLoged, "default", "default", clsSecurity.TerminalID, "default", "default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                        oLeaveType.Insert();
                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
                finally
                {
                    clearFields();
                    RefreshGrid();
                }
            }
        }
        #endregion

        #region Clear fields
        private void clearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtLeaveTypeCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtLeaveName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtNoOfDays, true, true, false);

            txtLeaveTypeCode.Tag = null;

            txtLeaveTypeCode.Text = "";
            txtLeaveName.Text = "";
            txtNoOfDays.Text = "00";

            chkDatLimit.IsChecked = true;
            chkStatus.IsChecked = false;

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtLeaveTypeCode.setReadOnlyStatus(true);
                txtLeaveTypeCode.Text = "<Auto Generate>";
            }
            else
                txtLeaveTypeCode.setReadOnlyStatus(false);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_hrMasLeaveTypes oLeaveType in tbl_hrMasLeaveTypes.SelectAll().Where(p => p.LeaveType_ID != "default" && p.IsCanceled == false))
                {
                    dgr_Main.dt.Rows.Add(oLeaveType.LeaveType_ID, oLeaveType.LeaveType_Name, oLeaveType.Std_NoOfDays.ToString("00"), (oLeaveType.LeaveType_Status == true) ? "Active" : "Inactive");
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_DuplicateFiled())
                    bStatus = true;
            }
            if (!ChekValidity_DuplicateNames())
                bStatus = false;
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtLeaveName))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_hrMasLeaveTypes oDetail = tbl_hrMasLeaveTypes.Select(txtLeaveTypeCode.Text, clsSecurity.CompanyID, clsSecurity.BranchID);
                if (oDetail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        public bool ChekValidity_DuplicateNames()
        {
            bool bStatus = true;
            foreach (tbl_hrMasLeaveTypes detail1 in tbl_hrMasLeaveTypes.SelectAll().Where(p => p.LeaveType_Name == txtLeaveName.Text && p.IsCanceled == false && p.LeaveType_ID != txtLeaveTypeCode.Text))
            {
                if (detail1 != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist);
                    break;
                }
            }
            return bStatus;
        }
        #endregion

        #region Fill Details
        private void fillDetails(string sID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_hrMasLeaveTypes oLaeveType = tbl_hrMasLeaveTypes.Select(sID, clsSecurity.CompanyID, clsSecurity.BranchID);
                    if (oLaeveType != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtLeaveTypeCode.IsEnabled = false;
                        txtLeaveTypeCode.Text = oLaeveType.LeaveType_ID;
                        txtLeaveTypeCode.Tag = oLaeveType.LeaveType_ID;
                        txtLeaveName.Text = oLaeveType.LeaveType_Name;
                        txtNoOfDays.Text = oLaeveType.Std_NoOfDays.ToString();

                        chkStatus.IsChecked = oLaeveType.LeaveType_Status;
                        chkDatLimit.IsChecked = oLaeveType.IsDaysLimit;

                        if (oLaeveType.IsDaysLimit)
                            txtNoOfDays.Visibility = Visibility.Visible;
                        else
                            txtNoOfDays.Visibility = Visibility.Collapsed;
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Grid Event
        private void grd_LeaveTypes_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    fillDetails(GridID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Event
        private void txtLeaveTypeCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.LeaveTypes);
            if (RowDataSearch.DialogResult == true)
            {
                clearFields();
                txtLeaveTypeCode.Text = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }
        #endregion

        private void chkDatLimit_checkBox_Checked(object sender, EventArgs e)
        {
            txtNoOfDays.Visibility = Visibility.Visible;
        }

        private void chkDatLimit_checkBox_Unchecked(object sender, EventArgs e)
        {
            txtNoOfDays.Visibility = Visibility.Collapsed;
        }
    }
}