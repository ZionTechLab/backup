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
using SEACC_WPFControls;

namespace Digiteq
{
    /**
     * This was developped by Janith for the purpose of SELMO Project
     * To Do :
     * Develop a method for opening Attendance Process Period Window from Attendace Process Group UI
     * Need to develop Cancel Button method with relavant validation
     * Suggested by Gayan on 2018-06-14
     * */

    public partial class UC_AttendanceProcessPeriod : UserControl
    {
        #region Class Variables
        string sAttenProcessGroup_ID = null;
        #endregion

        #region Form Load
        public UC_AttendanceProcessPeriod()
        {
            InitializeComponent();
            AppDomainInitializer(null);
        }

        public UC_AttendanceProcessPeriod(string processGroup_ID)
        {
            InitializeComponent();
            sAttenProcessGroup_ID = processGroup_ID;
            AppDomainInitializer(processGroup_ID);
        }

        private void AppDomainInitializer(string processGroup_ID)
        {
            #region Initialize Usercontrol
            SEACC_Form.enmFormName = FormName.Attendance_ProcessPeriod;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("ProcessGroupID");
            dgr_Main.dt.Columns.Add("ProcessGroupCode");
            dgr_Main.dt.Columns.Add("ProcessPeriodID");
            dgr_Main.dt.Columns.Add("ProcessPeriodTitle");
            dgr_Main.dt.Columns.Add("StartDate");
            dgr_Main.dt.Columns.Add("EndDate");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Group ID", "ProcessGroupID", 100, false);
            dgr_Main.Add_DatagridColoumn("Group Code", "ProcessGroupCode", 200);
            dgr_Main.Add_DatagridColoumn("Period ID", "ProcessPeriodID", 75, false);
            dgr_Main.Add_DatagridColoumn("Period Title", "ProcessPeriodTitle", 75);
            dgr_Main.Add_DatagridColoumn("Period Start", "StartDate", 75);
            dgr_Main.Add_DatagridColoumn("Period End", "EndDate", 75);
            #endregion

            ClearFields();
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
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    if (SEACC_Form.IsUpdateMode)
            //    {
            //        if (txtAttenProcessPeriod.Tag != null && txtAttenProcessPeriod.Tag.ToString() != "")
            //        {
            //            bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
            //            if (bMessegeBoxResult)
            //            {
            //                tbl_payMas_ProcessPeriod_Sub detail = tbl_payMas_ProcessPeriod_Sub.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtAttenProcessGroup.Tag.ToString(), int.Parse(txtAttenProcessPeriod.Tag.ToString()), txtAttenProcessPeriodTitle.Text.Trim());
            //                if (detail != null)
            //                {
            //                    //detail.IsCanceled = true;
            //                    //detail.Date_Canceled = clsSecurity.getServerDateTime();
            //                    //detail.TerminalID_Canceled = clsSecurity.TerminalID;
            //                    //detail.UserID_Canceled = clsSecurity.UserIDLoged;
            //                    detail.Update();

            //                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
            //                    ClearFields();
            //                    RefreshGrid();
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            //}
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
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
                            tbl_genMasEmpAttendanceProcessPeriod oldRecord = tbl_genMasEmpAttendanceProcessPeriod.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtAttenProcessGroup.Tag.ToString(), int.Parse(txtAttenProcessPeriod.Tag.ToString()));
                            if (oldRecord != null && !oldRecord.IsComplepted )
                            {
                                tbl_genMasEmpAttendanceProcessPeriod detail = new tbl_genMasEmpAttendanceProcessPeriod(oldRecord.Company_ID, oldRecord.CompanyBranch_ID, txtAttenProcessGroup.Tag.ToString(), int.Parse(txtAttenProcessPeriod.Tag.ToString()), txtAttenProcessPeriodTitle.Text, dtpStartDate.GetDateTime(), dtpEndDate.GetDateTime(), chkIsClosedPeriod.IsChecked);
                                detail.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                            else
                                SEACCMessageBox.Show(MessegeBoxType.AccessDenied, "Process Period Closed");
                        }
                    }
                    #endregion

                    #region Insert Data
                    else
                    {
                        if (SEACC_Form.isAutoGenaratedCode)
                            txtAttenProcessPeriod.Tag = SEACC_Form.getAutoGeneratedCode();

                        tbl_genMasEmpAttendanceProcessPeriod detail = new tbl_genMasEmpAttendanceProcessPeriod(clsSecurity.CompanyID, clsSecurity.BranchID, txtAttenProcessGroup.Tag.ToString(), int.Parse(txtAttenProcessPeriod.Tag.ToString()), txtAttenProcessPeriodTitle.Text, dtpStartDate.GetDateTime(), dtpEndDate.GetDateTime(), chkIsClosedPeriod.IsChecked);
                        detail.Insert();
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
                    ClearFields();
                    RefreshGrid();
                }
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtAttenProcessGroup, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtAttenProcessPeriod, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAttenProcessPeriodTitle, true, false, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpStartDate, true, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpEndDate, true, false);

            txtAttenProcessGroup.Tag = null;
            txtAttenProcessPeriod.Tag = null;

            txtAttenProcessGroup.Text = "";
            txtAttenProcessPeriod.Text = "";
            txtAttenProcessPeriodTitle.Text = "";

            dtpStartDate.SetTime(DateTime.Now);
            dtpEndDate.SetTime(DateTime.Now);

            chkIsClosedPeriod.IsChecked = false;

            if (SEACC_Form.isAutoGenaratedCode)
                txtAttenProcessPeriod.Text = "<Auto Generate>";
            else
                txtAttenProcessPeriod.Text = "";

            if (sAttenProcessGroup_ID != null)
            {
                txtAttenProcessGroup.Tag = sAttenProcessGroup_ID;
                txtAttenProcessGroup.Text = clsRef_Name.get_processGroup_Name(sAttenProcessGroup_ID);
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_genMasEmpAttendanceProcessPeriod detail in tbl_genMasEmpAttendanceProcessPeriod.SelectAll().OrderByDescending(r => r.StartDate.Date).ThenBy(r => r.AttenProcessGroup_ID))
                {
                    if (txtAttenProcessGroup.Tag != null)
                    {
                        if (txtAttenProcessGroup.Tag.ToString() != detail.AttenProcessGroup_ID)
                            continue;
                    }

                    dgr_Main.dt.Rows.Add(detail.AttenProcessGroup_ID, clsRef_Name.get_Attendance_ProcessGroup1(detail.AttenProcessGroup_ID), detail.AttenProcessPeriod_ID, detail.AttenProcessPeriod_Title, detail.StartDate.ToString(clsConfig.Format_Date), detail.EndDate.ToString(clsConfig.Format_Date));
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
                if (CheckValidity_DuplicateFiled())
                    bStatus = true;
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!SEACC_Form.IsUpdateMode)
            {
                if (!clsValidation.Validate_EmptyValue(txtAttenProcessGroup))
                    bStatus = false;
                if (!clsValidation.Validate_EmptyValue(txtAttenProcessPeriodTitle))
                    bStatus = false;
            }

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                    txtAttenProcessPeriod.Tag = SEACC_Form.getAutoGeneratedCode();

                tbl_genMasEmpAttendanceProcessPeriod detail = tbl_genMasEmpAttendanceProcessPeriod.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtAttenProcessGroup.Tag.ToString(), int.Parse(txtAttenProcessPeriod.Tag.ToString()));
                if (detail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }
        #endregion

        #region Fill Details
        private void fillDetails(string sID, int pID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_genMasEmpAttendanceProcessPeriod detail = tbl_genMasEmpAttendanceProcessPeriod.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sID, pID);
                    if (detail != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        
                        txtAttenProcessGroup.Tag = detail.AttenProcessGroup_ID;
                        txtAttenProcessGroup.Text = clsRef_Name.get_Attendance_ProcessGroup1(detail.AttenProcessGroup_ID);

                        txtAttenProcessPeriod.Tag = detail.AttenProcessPeriod_ID;
                        txtAttenProcessPeriod.Text = detail.AttenProcessPeriod_ID.ToString();

                        txtAttenProcessPeriodTitle.Text = detail.AttenProcessPeriod_Title;

                        dtpStartDate.SetTime(detail.StartDate);
                        dtpEndDate.SetTime(detail.EndDate);

                        chkIsClosedPeriod.IsChecked = detail.IsComplepted;
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
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string GID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    int pID = int.Parse((dgr_Main.grdMain.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);

                    fillDetails(GID, pID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Event
        private void txtAttenProcessGroup_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.AttendanceProcessGroup1);
            if (RowDataSearch.DialogResult == true)
            {
                txtAttenProcessGroup.Tag = lstResult[0];
                txtAttenProcessGroup.Text = lstResult[1];
                RefreshGrid();
            }
        }

        private void txtAttenProcessPeriod_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            if (txtAttenProcessGroup.Tag != null)
            {
                lstParameeters.Add(txtAttenProcessGroup.Tag.ToString());
            }

            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.AttendanceProcessPeriod);
            if (RowDataSearch.DialogResult == true)
            {
                txtAttenProcessGroup.Tag = lstResult[0];
                txtAttenProcessGroup.Text = lstResult[1];
                txtAttenProcessPeriod.Tag = lstResult[2];
                txtAttenProcessPeriod.Text = lstResult[3];
                RefreshGrid();
            }

        }
        #endregion       
    }
}
