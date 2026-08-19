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
using System.Data;
using DataTire;
using SEACC_WPFControls;
using Digiteq_Logic;

namespace Digiteq
{
    public partial class wj_Leave : UserControl
    {
        public delegate void delegate_ClickOnLeave(string LeaveID);
        public event delegate_ClickOnLeave LeaveSelected;

        DateTime currentHRYear_StartDate = DateTime.Now, currentHRYear_EndDate = DateTime.Now;
        int iCurrentHRYear_ID = 0;
        string sCurrentYearName = "";

        #region Class Variables
        string sEmployeeID = "default";
        DataTable dt_LeaveBalance;
        DataTable dt_LeaveHistory;
        #endregion

        #region Form Load
        public wj_Leave()
        {
            #region Initialize Usercontrol
            InitializeComponent();
            #endregion

            #region Initialize Data Tables
            dt_LeaveBalance = new DataTable();
            dt_LeaveHistory = new DataTable();

            dt_LeaveBalance.Columns.Add("LeaveTypeID");
            dt_LeaveBalance.Columns.Add("LeaveType");
            dt_LeaveBalance.Columns.Add("EntitleLeave");
            dt_LeaveBalance.Columns.Add("Utilized");
            dt_LeaveBalance.Columns.Add("Balance");
            dt_LeaveBalance.Columns.Add("Leaves");

            dt_LeaveHistory.Columns.Add("LeaveID");
            dt_LeaveHistory.Columns.Add("Status");
            dt_LeaveHistory.Columns.Add("LeaveStartDate");
            dt_LeaveHistory.Columns.Add("LeaveEndDate");
            dt_LeaveHistory.Columns.Add("NoOfDays");
            #endregion

            RefreshControl();
            // RefreshGrid_LeaveBalance(oSecurityUser.EmployeeID);
        }
        #endregion

        public void RefreshControl()
        {
            tbl_hrPeriod_Year oYear;
            if (iCurrentHRYear_ID == 0)
                oYear = tbl_hrPeriod_Year.SelectAll().Where(r => r.Year_startDate.Date <= DateTime.Now.Date && r.Year_endDate >= DateTime.Now.Date).FirstOrDefault();
            else
                oYear = tbl_hrPeriod_Year.Select(clsSecurity.CompanyID, clsSecurity.BranchID, iCurrentHRYear_ID);

            if (oYear != null)
            {
                iCurrentHRYear_ID = oYear.Year_ID;
                currentHRYear_StartDate = oYear.Year_startDate.Date;
                currentHRYear_EndDate = oYear.Year_endDate.Date;
                sCurrentYearName = oYear.Year_Name;
            }
            lblleaveYearPeroid.Content = "Entitled Leaves From " + currentHRYear_StartDate.ToString(clsConfig.Format_Date) + " To " + currentHRYear_EndDate.ToString(clsConfig.Format_Date);
        }

        public void setLeaveDetail(string employeeId)
        {
            sEmployeeID = employeeId;
            RefrshGrid_LeaveHostory(employeeId);
            RefreshGrid_LeaveBalance(employeeId);
        }

        public void RefrshGrid_LeaveHostory(string employeeId)
        {
            try
            {
                decimal Utilized = 0.00M;
                dt_LeaveHistory.Clear();
                List<tbl_tasEmployeeLeaveCard> oEmpLeaveCard_List = tbl_tasEmployeeLeaveCard.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, employeeId);
                foreach (tbl_tasEmployeeLeaveCard oEmpLeaveCard in oEmpLeaveCard_List.Where(r => !r.IsCancled && r.Leave_ID != "default" && r.LeaveType_ID != "default" && r.Leave_Start <= currentHRYear_EndDate.Date && r.Leave_End >= currentHRYear_StartDate.Date).OrderByDescending(p => p.Leave_Start))
                {
                    #region Approvel Status
                    string sSataus = string.Empty;
                    if (oEmpLeaveCard.ApprovalStatus_Manager == 1)
                        sSataus = "Approved";

                    else if (oEmpLeaveCard.ApprovalStatus_Manager == 2)
                        sSataus = "Rejected";

                    else if (oEmpLeaveCard.ApprovalStatus_Manager == 0)
                        sSataus = "Pending";
                    #endregion

                    string NoOfDays = string.Empty;
                    decimal LeaveDays = oEmpLeaveCard.Leaves_Utilized;
                    NoOfDays = LeaveDays.ToString();

                    dt_LeaveHistory.Rows.Add(oEmpLeaveCard.Leave_ID, sSataus, oEmpLeaveCard.Leave_Start.ToString(clsConfig.Format_DateTime), oEmpLeaveCard.Leave_End.ToString(clsConfig.Format_DateTime), NoOfDays);
                }
                grd_LeaveHistory.ItemsSource = dt_LeaveHistory.DefaultView;
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void RefreshGrid_LeaveBalance(string employeeId)
        {
            try
            {
                dt_LeaveBalance.Clear();

                List<tbl_tasEmployeeLeave_entitled> oLeaves_List = tbl_tasEmployeeLeave_entitled.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, employeeId);
                foreach (tbl_tasEmployeeLeave_entitled oLeaves in oLeaves_List.Where(p => p.LeaveType_ID != "default" && p.HrYear_ID == iCurrentHRYear_ID))
                {
                    dt_LeaveBalance.Rows.Add(oLeaves.LeaveType_ID, clsRef_Name.get_leaveType_Name(oLeaves.LeaveType_ID), oLeaves.Leaves_Entitled, oLeaves.Leaves_Utilized, (oLeaves.Leaves_Entitled - oLeaves.Leaves_Utilized), "0");
                }
                grdBalanceLeave.ItemsSource = dt_LeaveBalance.DefaultView;
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void grd_LeaveHistory_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            try
            {
                string g = ((System.Data.DataRowView)(e.Row.DataContext)).Row.ItemArray[1].ToString();
                if (g == "Approved")
                {
                    e.Row.Background = (Brush)bc.ConvertFrom("#2A934B");
                }
                else if (g.Trim() == "Rejected")
                {
                    e.Row.Background = (Brush)bc.ConvertFrom("#7B0000");
                }
                else
                {
                    e.Row.Background = (Brush)bc.ConvertFrom("#FF34495E"); ;
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void btnPayrollYear_Click(object sender, RoutedEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.HRYear);
            if (RowDataSearch.DialogResult == true)
            {
                iCurrentHRYear_ID = int.Parse(lstResult[0]);
                RefreshControl();
                setLeaveDetail(sEmployeeID);
            }
        }

        private void grd_LeaveHistory_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = grd_LeaveHistory.SelectedItem;
                if (item != null)
                {
                    string sLeaveID = (grd_LeaveHistory.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    LeaveSelected(sLeaveID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

    }
}
