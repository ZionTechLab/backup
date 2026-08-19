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
using System.Data;
//using System.Data.SqlClient;

namespace Digiteq
{
    public partial class UC_Approvals : UserControl
    {
        #region Class Variables
        //DataTable dtMain = new DataTable();
        #endregion

        #region Form Load
        public UC_Approvals()
        {
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Approvals;
            SEACC_Form.Initialize();

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(false, false, false, false);
            #endregion

            #region Data Grid Colums Initilize
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "✔", "Approve", 20, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "✘", "Reject", 20, true, true);
            dgr_Main.Add_DatagridColoumn("Type", "LeaveType", 0);
            dgr_Main.Add_DatagridColoumn("LeaveID", "leave_ID", 70);
            dgr_Main.Add_DatagridColoumn("Emp. #", "employee_ID", 70);
            dgr_Main.Add_DatagridColoumn("Name", "fullName", 150);
            dgr_Main.Add_DatagridColoumn("Leave Start", "leave_Start", 150);
            dgr_Main.Add_DatagridColoumn("Leave End", "leave_End", 150);
            dgr_Main.Add_DatagridColoumn("Reason", "reason", 200);
            dgr_Main.Add_DatagridColoumn("Approval Status CP1", "AppCP1", 0, false);
            dgr_Main.Add_DatagridColoumn("Approval Status CP2", "AppCP2", 0, false);
            dgr_Main.Add_DatagridColoumn("Approval Status Supevisor", "AppSup", 0, false);
            dgr_Main.Add_DatagridColoumn("Approval Status Manager", "AppMgr", 0, false);
            dgr_Main.Add_DatagridColoumn("RowBackColor", "RowBackColor", 0, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text,"Comments","commnet",200,true,false);
            #endregion

            dgr_Main.dt = DBHandling.ExecQuery("sp_tasEmployeeLeave_PendingApproval '" + clsSecurity.EmployeeIDLoged + "'").Tables[0];
            dgr_Main.RefreshGrid();
        }
        #endregion

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(410);
            else
                coloumnA.Width = new GridLength(800);
        }
        #endregion

        #region Action Buttons

        #region Approval Type
        private void btn_AppravalTypes_Click(object sender, MouseButtonEventArgs e)
        {
            SEACC_ToggleButton btn = sender as SEACC_ToggleButton;

            string sfilter = "";

            sfilter = btn_lv_Checking.bBtnStatus ? ("LeaveType = " + "'" + "CB" + "'") : ("LeaveType = " + "'" + "-" + "'");
            sfilter += btn_lv_Approve.bBtnStatus ? ((sfilter == "" ? "" : "OR ") + "LeaveType = " + "'" + "AB" + "'") : "";
            sfilter += btn_lv_Covering.bBtnStatus ? ((sfilter == "" ? "" : "OR ") + "LeaveType = " + "'" + "CP" + "'") : "";
            
            dgr_Main.dt.DefaultView.RowFilter = sfilter;
        }

        private void btn_AppravalTypes_Click(object sender, RoutedEventArgs e)
        {
            
        }
        #endregion

        #region Approve
        private void SEACC_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool bLoopSwitch = false;            
                var vDG_Cell = dgr_Main.GetCurrentCell();
                int irowID = dgr_Main.SelectedIndex;
                bool bMessegeBoxResult = SEACCMessageBox.Show("Are You Sure? Do You Want to Approve Selectd Request(s)", "", MessageBoxButton.YesNo);
                if (bMessegeBoxResult)
                {
                    foreach (DataRow row in dgr_Main.dt.Rows)
                    {
                        bool isApproved = bool.Parse(row["Approve"].ToString());
                        bool isRejected = bool.Parse(row["Reject"].ToString());
                        string sLeave_Id = row["leave_ID"].ToString();
                        string sComments = string.Empty;
                        string sPersontype = string.Empty;

                        if (isApproved && isRejected)
                        {
                            SEACCMessageBox.Show("Oops...", "You Cannot Approve and Reject Leave at Once ! (Leave NO : '" + sLeave_Id + ")", MessageBoxButton.OK);
                        }

                        else if (isApproved || isRejected)
                        {

                            if (isApproved)
                            {
                                tbl_tasEmployeeLeaveCard oLeaveCard = tbl_tasEmployeeLeaveCard.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sLeave_Id);
                                if (oLeaveCard != null)
                                {
                                    if (oLeaveCard.UserID_CP1 == clsSecurity.EmployeeIDLoged)
                                    {
                                        oLeaveCard.ApprovalStatus_CP1 = 1;
                                        oLeaveCard.Comments_CP1 = sComments;
                                        sPersontype = "By Covering Person 1";
                                    }
                                    if (oLeaveCard.UserID_CP2 == clsSecurity.EmployeeIDLoged)
                                    {
                                        oLeaveCard.ApprovalStatus_CP2 = 1;
                                        oLeaveCard.Comments_CP2 = sComments;
                                        sPersontype = "By Covering Person 2";
                                    }
                                    if (oLeaveCard.UserID_Supevisor == clsSecurity.EmployeeIDLoged)
                                    {
                                        oLeaveCard.ApprovalStatus_Supevosior = 1;
                                        oLeaveCard.Comments_Supevisor = sComments;
                                        sPersontype = "By Supervisor";
                                    }
                                    if (oLeaveCard.UserID_Manager == clsSecurity.EmployeeIDLoged)
                                    {
                                        oLeaveCard.ApprovalStatus_Manager = 1;
                                        oLeaveCard.Comments_Manager = sComments;
                                        sPersontype = "By Manager";
                                    }
                                    oLeaveCard.Update();
                                    clsAlerts_Email.CreateEmail_LeaveApplication(enum_Alerts.LeaveApproved,sLeave_Id, sPersontype);
                                }
                                bLoopSwitch = true;
                            }
                            if (isRejected)
                            {
                                tbl_tasEmployeeLeaveCard oLeaveCard = tbl_tasEmployeeLeaveCard.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sLeave_Id);
                                if (oLeaveCard != null)
                                {
                                    if (oLeaveCard.UserID_CP1 == clsSecurity.EmployeeIDLoged)
                                    {
                                        oLeaveCard.ApprovalStatus_CP1 = 2;
                                        oLeaveCard.Comments_CP1 = sComments;
                                        sPersontype = "By Covering Person 1";
                                    }
                                    if (oLeaveCard.UserID_CP2 == clsSecurity.EmployeeIDLoged)
                                    {
                                        oLeaveCard.ApprovalStatus_CP2 = 2;
                                        oLeaveCard.Comments_CP2 = sComments;
                                        sPersontype = "By Covering Person 2";
                                    }
                                    if (oLeaveCard.UserID_Supevisor == clsSecurity.EmployeeIDLoged)
                                    {
                                        oLeaveCard.ApprovalStatus_Supevosior = 2;
                                        oLeaveCard.Comments_Supevisor = sComments;
                                        sPersontype = "By Supervisor";
                                    }
                                    if (oLeaveCard.UserID_Manager == clsSecurity.EmployeeIDLoged)
                                    {
                                        oLeaveCard.ApprovalStatus_Manager = 2;
                                        oLeaveCard.Comments_Manager = sComments;
                                        sPersontype = "By Manager";
                                    }
                                    oLeaveCard.Update();
                                    clsAlerts_Email.CreateEmail_LeaveApplication(enum_Alerts.LeaveReject,sLeave_Id, sPersontype);
                                }
                                bLoopSwitch = true;
                            }
                        }
                    }
                }
                if (bLoopSwitch)
                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Approved);
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
            finally
            {
                dgr_Main.dt = DBHandling.ExecQuery("sp_tasEmployeeLeave_PendingApproval '" + clsSecurity.EmployeeIDLoged + "'").Tables[0];
                dgr_Main.RefreshGrid();
            }
        }
        #endregion

        #endregion

        #region Refresh Grid
        public void RefreshGrid_WithFilter(string Type1)
        {
            if (Type1 != null)
            {
                string sfilter = "LeaveType Like " + "'%" + Type1 + "%'";
                var dv = dgr_Main.dt.DefaultView;
                dv.RowFilter = sfilter;
            }
        }
        #endregion

        #region Grid Events
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            int irowID = dgr_Main.SelectedIndex;
            var vDG_Cell = dgr_Main.GetCurrentCell();
            try
            {
                if (vDG_Cell.Column.SortMemberPath == "Approve")
                {
                    dgr_Main.dt.Rows[irowID]["Approve"] = true;
                    dgr_Main.dt.Rows[irowID]["Reject"] = false;
                }
                else if (vDG_Cell.Column.SortMemberPath == "Reject")
                {
                    dgr_Main.dt.Rows[irowID]["Approve"] = false;
                    dgr_Main.dt.Rows[irowID]["Reject"] = true;
                }
            }
            catch (Exception)
            {
                
             
            }
           

            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgr_Main.grdMain.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                    Vw_EmpDetails.setEmployeeDetail(GridID);
                    Vw_History.Refresh(GridID);
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion

    }
}