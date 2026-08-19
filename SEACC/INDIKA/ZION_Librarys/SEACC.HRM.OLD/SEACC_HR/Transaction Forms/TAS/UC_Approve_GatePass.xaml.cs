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
using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System.Windows.Controls.Primitives;

namespace Digiteq
{
    public partial class UC_Approve_GatePass : UserControl
    {
        #region Class variable
        DataTable dtMain = new DataTable();
        DataTable dtMain1 = new DataTable();

        bool bSwitch;
        string GridID;
        #endregion

        #region Form Load
        public UC_Approve_GatePass()
        {
            #region Form Initialization
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Approve_GatePass;
            SEACC_Form.Initialize(); 
            #endregion

            #region Data Table Column Initialize Leave
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "✔", "Approve", 20, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "✘", "Reject", 20, true, false);
            dgr_Main.Add_DatagridColoumn("Type", "LeaveType", 70);
            dgr_Main.Add_DatagridColoumn("GP #", "gatePass_ID", 70);
            dgr_Main.Add_DatagridColoumn("Emp. NO.", "employee_ID", 70);
            dgr_Main.Add_DatagridColoumn("Name", "fullName", 150);
            dgr_Main.Add_DatagridColoumn("Date And  Time", "gatePass_DateTime", 150);
            dgr_Main.Add_DatagridColoumn("Hours", "leave_Hours", 70);
            dgr_Main.Add_DatagridColoumn("Reason", "reason", 500);
            dgr_Main.Add_DatagridColoumn("RowBackColor", "RowBackColor", 0, false);
            #endregion

            #region Action Button Initialize
            SEACC_Form.SetVisibility_ActionButons(false, false, false, false); 
            #endregion

            dgr_Main.dt = DBHandling.ExecQuery("Exec sp_tasEmployeeLeave_PendingApproval_GatePass '" + clsSecurity.EmployeeIDLoged+ "'").Tables[0]; //
            
            dgr_Main.RefreshGrid();
            ClearFields(); 
        }
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(470);
        } 
        #endregion

        #region Action Buttons
        #region Button Check GatePass
        private void btn_gp_Check_Click(object sender, RoutedEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            SEACC_Button btn = sender as SEACC_Button;

            if (btn.Tag.ToString() == "0")
            {
                btn.Tag = 1;

                if (btn.Name == "btn_lv_Checking")
                {
                    btn.Background = (Brush)bc.ConvertFrom("#66b2ff");
                }
                else if (btn.Name == "btn_lv_Approve")
                {
                    btn.Background = (Brush)bc.ConvertFrom("#d24dff");
                }
                else if (btn.Name == "btn_lv_Covering")
                {
                    btn.Background = (Brush)bc.ConvertFrom("#00b2b3");
                    //sfilter = "And LeaveType Like " + "'%" + CP + "%'";
                    //RefreshGrid_WithFilter("CP");
                }
                else if (btn.Name == "btn_gp_Check")
                {
                    btn.Background = (Brush)bc.ConvertFrom("#66b2ff");
                }
                else if (btn.Name == "btn_gp_Approve")
                {
                    btn.Background = (Brush)bc.ConvertFrom("#ff5050");
                }
            }
            else
            {
                btn.Tag = 0;
                btn.Background = (Brush)bc.ConvertFrom("#FF555555");
                var dv = dgr_Main.dt.DefaultView;
                dv.RowFilter = "";
            }
            string sfilter = "";

            if (btn_gp_Check.Tag.ToString() != "0")
            {
                sfilter += (sfilter == "" ? "" : "OR ") + "LeaveType = " + "'" + "CB" + "'";
            }
            if (btn_gp_Approve.Tag.ToString() != "0")
            {
                sfilter += (sfilter == "" ? "" : "OR ") + "LeaveType = " + "'" + "AB" + "'";
            }
            // var dv = grd_Main.dt.DefaultView;
            dgr_Main.dt.DefaultView.RowFilter = sfilter;
        }
        #endregion

        #region Button Approve GatePass - Submit button
        private void btn_Approve_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool bLoopSwitch = false;
                var vDG_Cell = dgr_Main.GetCurrentCell();
                int irowID = dgr_Main.SelectedIndex;
                string sComments = string.Empty;
                bool bMessegeBoxResult = SEACCMessageBox.Show("Are You Sure? Do You Want to Approve Selected Request(s)", "", MessageBoxButton.YesNo);
                if (bMessegeBoxResult)
                {
                    foreach (DataRow row in dgr_Main.dt.Rows)
                    {
                        bool isApproved = bool.Parse(row["Approve"].ToString());
                        bool isRejected = bool.Parse(row["Reject"].ToString());
                        string sGP_ID = row["gatePass_ID"].ToString();
                        string sPersontype = string.Empty;
                        if (isApproved && isRejected)
                        {
                            SEACCMessageBox.Show("Oops...", "You Cannot Approve and Reject Gate Pass at Once ! (GP# NO : '" + sGP_ID + ")", MessageBoxButton.OK);
                        }

                        else if (isApproved || isRejected)
                        {
                            if (isApproved)
                            {
                                tbl_tasTxGatePass oLeaveCard = tbl_tasTxGatePass.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sGP_ID);
                                if (oLeaveCard != null)
                                {
                                    if (oLeaveCard.UserID_Supevisor == clsSecurity.EmployeeIDLoged)
                                    {
                                        oLeaveCard.ApprovalStatus_Supevosior = 1;
                                        sPersontype = "By Supervisor";
                                    }
                                    if (oLeaveCard.UserID_Manager == clsSecurity.EmployeeIDLoged)
                                    {
                                        oLeaveCard.ApprovalStatus_Manager = 1;
                                        sPersontype = "By Manager";
                                    }
                                    oLeaveCard.Update();
                                    clsAlerts_Email.CreateEmail_GatePass(enum_Alerts.GatePass_Approved, sGP_ID, sPersontype);

                                }
                            }
                            if (isRejected)
                            {
                                tbl_tasTxGatePass oLeaveCard = tbl_tasTxGatePass.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sGP_ID);
                                if (oLeaveCard != null)
                                {

                                    if (oLeaveCard.UserID_Supevisor == clsSecurity.EmployeeIDLoged)
                                    {
                                        oLeaveCard.ApprovalStatus_Supevosior = 2;
                                        sPersontype = "By Supervisor";
                                    }
                                    if (oLeaveCard.UserID_Manager == clsSecurity.EmployeeIDLoged)
                                    {
                                        oLeaveCard.ApprovalStatus_Manager = 2;
                                        sPersontype = "By Manager";
                                    }
                                    oLeaveCard.Update();
                                    clsAlerts_Email.CreateEmail_GatePass(enum_Alerts.GatePass_Rejected, sGP_ID, sPersontype);
                                }
                            }
                        }
                    }
                    //Reject
                    if (bLoopSwitch)
                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Approved);
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
            finally
            {
                //In here, employeeId is considered as 'userID_Supevisor' or 'userID_Manager'
                dgr_Main.dt = DBHandling.ExecQuery("sp_tasEmployeeLeave_PendingApproval_GatePass '" + clsSecurity.EmployeeIDLoged + "'").Tables[0];
                dgr_Main.RefreshGrid();
            }
        }
        #endregion 
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            exp_History.IsExpanded = false;
            exp_EmpDetails.IsExpanded = false;
        }
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

        #region Grid Event
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {    
            int irowID = dgr_Main.SelectedIndex;
            var vDG_Cell = dgr_Main.GetCurrentCell();

            try
            {
                if (vDG_Cell.Column.SortMemberPath == "Approve")
                {
                    dgr_Main.dt.Rows[irowID]["Approve"] = dgr_Main.dt.Rows[irowID]["Approve"].ToString() == "True" ? false : true;
                }

                if (vDG_Cell.Column.SortMemberPath == "Reject")
                {
                    dgr_Main.dt.Rows[irowID]["Reject"] = dgr_Main.dt.Rows[irowID]["Reject"].ToString() == "True" ? false : true;
                }
            }
            catch (Exception)
            { }
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string emp_ID = (dgr_Main.grdMain.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                    Vw_EmpDetails.setEmployeeDetail(emp_ID);
                    Vw_History.Refresh(emp_ID);
                    exp_History.IsExpanded = true;
                    exp_EmpDetails.IsExpanded = true;
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion


        //private void btn_Reject_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        string sComments = string.Empty;
        //        bool bMessegeBoxResult = SEACCMessageBox.Show("Are You Sure? Do You Want to Reject Selectd Request(s)", "", MessageBoxButton.YesNo);
        //        if (bMessegeBoxResult)
        //        {
        //            var vDG_Cell = dgr_Main.GetCurrentCell();
        //            int irowID = dgr_Main.SelectedIndex;

        //            foreach (DataRow row in dgr_Main.dt.Rows)
        //            {
        //                bool isApproved = bool.Parse(row["Reject"].ToString());
        //                string sLeave_Id = row["gatePass_ID"].ToString();
        //                string sPersontype = string.Empty;
        //                if (isApproved)
        //                {
        //                    tbl_tasTxGatePass oLeaveCard = tbl_tasTxGatePass.Select(sLeave_Id);
        //                    if (oLeaveCard != null)
        //                    {

        //                        if (oLeaveCard.UserID_Checked_By == clsSecurity.EmployeeIDLoged)
        //                        {
        //                            oLeaveCard.IsChecked = false;
        //                            sPersontype = "By Supervisor";
        //                        }
        //                        if (oLeaveCard.UserID_Approved_By == clsSecurity.EmployeeIDLoged)
        //                        {
        //                            oLeaveCard.IsApproved = false;
        //                            sPersontype = "By Manager";
        //                        }
        //                        oLeaveCard.Update();
        //                        clsAlerts_Email.RejectEmail_GatePass_insert(sLeave_Id, sPersontype);


        //                    }
        //                }
        //            }
        //            SEACCMessageBox.Show("Successfully Rejected", "", MessageBoxButton.OK);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
        //    }
        //    finally
        //    {
        //        dgr_Main.dt = DBHandling.ExecQuery("sp_tasEmployeeLeave_PendingApproval_GatePass '" + clsSecurity.EmployeeIDLoged + "'").Tables[0];
        //        dgr_Main.RefreshGrid();
        //    }
        //}
    }
}