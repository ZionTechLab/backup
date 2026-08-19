using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Digiteq
{
    /**
     * Developped by Janith 
     * On 2018-06 for SLEMO Project
     * */
    public partial class UC_MonthlyAttendanceControlPanel : UserControl
    {
        #region Form Load
        public UC_MonthlyAttendanceControlPanel()
        {
            #region Initialize Form
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.EmployeeAttendance_Monthly;
            SEACC_Form.Initialize();
            #endregion

            #region Acction Button
            SEACC_Form.SetVisibility_ActionButons(true, false, false, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            #endregion

            #region Initialize Data Table
            #region Attendance Group Intialize
            dgr_Main_Group.dt.Columns.Add("groupID");
            dgr_Main_Group.dt.Columns.Add("groupTitle"); 
            #endregion

            #region Attendance Group Period Intialize
            dgr_Group_Period.dt.Columns.Add("ProcessGroupID");
            dgr_Group_Period.dt.Columns.Add("ProcessGroupTitle");
            dgr_Group_Period.dt.Columns.Add("ProcessGroupPeriodID");
            dgr_Group_Period.dt.Columns.Add("ProcessGroupPeriodTitle");
            dgr_Group_Period.dt.Columns.Add("StartDate");
            dgr_Group_Period.dt.Columns.Add("EndDate");
            dgr_Group_Period.dt.Columns.Add("IsCompleted"); 
            #endregion
            #endregion

            #region Initialize Data Grid
            dgr_Main_Group.Add_DatagridColoumn("Group Code", "groupID", 80);
            dgr_Main_Group.Add_DatagridColoumn("Group Name", "groupTitle", 180);

            dgr_Group_Period.Add_DatagridColoumn("Group Code", "ProcessGroupID", 90,false);
            dgr_Group_Period.Add_DatagridColoumn("Group Name", "ProcessGroupTitle", 150);
            dgr_Group_Period.Add_DatagridColoumn("Period ID", "ProcessGroupPeriodID", 90, false);
            dgr_Group_Period.Add_DatagridColoumn("Period Name", "ProcessGroupPeriodTitle", 150);
            dgr_Group_Period.Add_DatagridColoumn("Start Date", "StartDate", 90);
            dgr_Group_Period.Add_DatagridColoumn("End Date", "EndDate", 90);
            dgr_Group_Period.Add_DatagridColoumn(ColoumnType.Text, "Segoe MDL2 Assets", "Is Completed", "IsCompleted", 90, true, true);
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Action Buttons
        public void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main_Group.dt.Clear();
                foreach (tbl_genMasEmpAttendanceProcessGroup1 detail in tbl_genMasEmpAttendanceProcessGroup1.SelectAll().Where(p => p.AttendanceGroup1_ID != "default" && !p.IsCanceled).OrderBy(r => r.AttendanceGroup1_ID))
                {
                    dgr_Main_Group.dt.Rows.Add(detail.AttendanceGroup1_ID, detail.AttendanceGroup1_Name);
                }
                dgr_Main_Group.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void RefreshGrid_Period(string sID)
        {
            try
            {
                dgr_Group_Period.dt.Clear();
                foreach (tbl_genMasEmpAttendanceProcessPeriod detail in tbl_genMasEmpAttendanceProcessPeriod.SelectAllByAttenProcessGroup_ID(sID).OrderBy(r => r.AttenProcessPeriod_ID))
                {
                    dgr_Group_Period.dt.Rows.Add(detail.AttenProcessGroup_ID, clsRef_Name.get_Attendance_ProcessGroup1(detail.AttenProcessGroup_ID),
                        detail.AttenProcessPeriod_ID, detail.AttenProcessPeriod_Title,
                        detail.StartDate.ToString(clsConfig.Format_Date), detail.EndDate.ToString(clsConfig.Format_Date), (detail.IsComplepted) ? "\uE0A2" : "\uE003");
                }
                dgr_Group_Period.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        } 
        #endregion

        #region Datagrid Events
        private void dgr_Main_Group_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main_Group.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgr_Main_Group.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    RefreshGrid_Period(GridID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        private void dgr_Group_Period_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                var vDG_Cell = dgr_Group_Period.GetCurrentCell();
                int iColumnIndex = vDG_Cell.Column.DisplayIndex;
                object item = dgr_Group_Period.grdMain.SelectedItem;
                if (item != null)
                {
                    string sGrid_GroupID = (dgr_Group_Period.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;//group id
                    string sGrid_Period_ID = (dgr_Group_Period.grdMain.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;//period id
                    DateTime sGrid_Period_StartDate = DateTime.Parse((dgr_Group_Period.grdMain.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text);//start date
                    DateTime sGrid_Period_EndDate = DateTime.Parse((dgr_Group_Period.grdMain.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text);//end adate
                    string sCompleted = (dgr_Group_Period.grdMain.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
                    bool bClosed = (sCompleted == "\uE0A2");

                    #region Check Previous Period Closed or not
                    //string sQry = "exec sp_Payroll_CheckPreviousPeriodClosed '" + clsSecurity.CompanyID + "' , '" + clsSecurity.BranchID + "' , '" + sGrid_GroupID + "' , '" + sGrid_Period_MainID + "', '" + sGrid_Period_SubID + "' ";
                    //DataTable dt_result = DBHandling.ExecQuery(sQry).Tables[0];
                    //bool bProcessed_PreviosPeriod = true;
                    //if (dt_result.Rows.Count > 0)
                    //    bProcessed_PreviosPeriod = bool.Parse(dt_result.Rows[0]["isClosedPeriod"].ToString());
                    #endregion

                    //if (bProcessed_PreviosPeriod)
                    //{
                        if ((iColumnIndex == 6) && !bClosed)
                        {
                            tbl_genMasEmpAttendanceProcessPeriod oSubPeriod = tbl_genMasEmpAttendanceProcessPeriod.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sGrid_GroupID, int.Parse(sGrid_Period_ID));
                            if (oSubPeriod != null)
                            {
                                List<tbl_tasTxMonthlyAttendance> oRawData = tbl_tasTxMonthlyAttendance.SelectAllByCompany_ID_CompanyBranch_ID_AttenProcessGroup_ID_AttenProcessPeriod_ID(clsSecurity.CompanyID, clsSecurity.BranchID, sGrid_GroupID, int.Parse(sGrid_Period_ID)).ToList();
                                if (oRawData.Count > 0)
                                {
                                    bool bMessegeBoxResult = SEACCMessageBox.Show("Confirmation", "Are you sure you want to complete this period " + oSubPeriod.AttenProcessPeriod_Title + " ?\n Once you close the period, you can not recover the attendance data", MessageBoxButton.YesNo, "#FF5B6B76");
                                    if (bMessegeBoxResult)
                                    {
                                        oSubPeriod.IsComplepted = true;
                                        oSubPeriod.Update();
                                    }
                                    dgr_Main_Group_MouseLeftButtonUp1(null, null);
                                }
                                else
                                    SEACCMessageBox.Show("Attention!!!", "Please process the period before closed the period", MessageBoxButton.OK, "Red");
                            }
                        }
                        else
                        {
                            #region Open Attendance Raw Data
                            //bool bAllowSave = false;
                            //tbl_securityParollGroup_UserPermission oGrpPermission = tbl_securityParollGroup_UserPermission.Select(clsSecurity.CompanyID, clsSecurity.BranchID, clsSecurity.UserIDLoged, sGrid_GroupID);
                            //if (oGrpPermission != null)
                            //    bAllowSave = oGrpPermission.AllowSave;

                            Frm_EmployeeMonthlyAttendance emp_PaySlipItems = new Frm_EmployeeMonthlyAttendance(sGrid_GroupID, int.Parse(sGrid_Period_ID), sGrid_Period_StartDate, sGrid_Period_EndDate);
                            if (emp_PaySlipItems.SEACC_Form.PermissionTO_Read)
                                emp_PaySlipItems.ShowDialog();

                            dgr_Group_Period.dt.Clear();
                            dgr_Main_Group_MouseLeftButtonUp1(null, null);
                            #endregion
                        }
                    //}
                    //else
                    //    SEACCMessageBox.Show("Attention!!!", "Please close the Previous Process Period", MessageBoxButton.OK, "Red");

                }
            }
            catch (Exception ex)
            {
                //SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            dgr_Group_Period.dt.Clear();
        }
        #endregion
    }
}
