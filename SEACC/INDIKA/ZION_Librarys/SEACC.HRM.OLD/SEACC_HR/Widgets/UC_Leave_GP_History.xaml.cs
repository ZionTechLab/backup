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
using System.IO;
using System.Data;

namespace Digiteq
{
    public partial class UC_Leave_GP_History : UserControl
    {
        #region Class Variables
        DataTable dt_Leave = new DataTable();
        DataTable dt_GatePass = new DataTable();
        public string sEmpID = "";

        public event EventHandler GatePassGrid_MouseLeftButtonUp;
        public event EventHandler LeaveGrid_MouseLeftButtonUp;
        #endregion

        #region Load
        public UC_Leave_GP_History()
        {
            InitializeComponent();

            #region Initialize Data Tables
            dt_Leave.Columns.Add("LeaveID");
            dt_Leave.Columns.Add("LeavePeriod");
            dt_Leave.Columns.Add("Reason");
            dt_Leave.Columns.Add("LeaveHours"); //added by Gayan 2016.07.20
            dt_Leave.Columns.Add("CheckedBy");
            dt_Leave.Columns.Add("ApprovedBy");

            dt_GatePass.Columns.Add("GPID");
            dt_GatePass.Columns.Add("Date");
            dt_GatePass.Columns.Add("Reason");
            dt_GatePass.Columns.Add("Hours");
            dt_GatePass.Columns.Add("CheckedBy");
            dt_GatePass.Columns.Add("ApprovedBy");
            #endregion
        }
        #endregion

        #region Clear Fields
        public void ClearFields()
        {
            dt_Leave.Clear();
            dt_GatePass.Clear();
        }
        #endregion

        #region Refresh
        public void Refresh(string EmpID, DateTime Date)
        {
            sEmpID = EmpID;
            try
            {
                #region leave
                foreach (tbl_tasEmployeeLeaveCard oLeave in tbl_tasEmployeeLeaveCard.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, EmpID).Where(p => !p.IsCancled && p.Leave_Start.Date >= Date && p.Leave_End.Date <= Date))
                {
                    string oEmpNameChecked = "-";
                    string oEmpNameApproved = "-";

                    if (oLeave.ApprovalStatus_Supevosior == (int)ApprovalStatus.Approved)
                    {
                        tbl_genMasEmployee oEmpChecked = tbl_genMasEmployee.Select(oLeave.UserID_Supevisor, clsSecurity.CompanyID, clsSecurity.BranchID);
                        if (oEmpChecked != null)
                        {
                            oEmpNameChecked = oEmpChecked.Initails + " " + oEmpChecked.SurName;
                        }
                    }

                    if (oLeave.ApprovalStatus_Manager == (int)ApprovalStatus.Approved)
                    {
                        tbl_genMasEmployee oEmpApproved = tbl_genMasEmployee.Select(oLeave.UserID_Manager, clsSecurity.CompanyID, clsSecurity.BranchID);
                        if (oEmpApproved != null)
                        {
                            oEmpNameApproved = oEmpApproved.Initails + " " + oEmpApproved.SurName;
                        }
                    }

                    //dt_Leave.Rows.Add(oLeave.Leave_ID, oLeave.Leave_Start.ToString(clsConfig.Format_Date) + " To " + oLeave.Leave_End.ToString(clsConfig.Format_Date), oLeave.Reason, (oLeave.Leaves_Utilized / 60).ToString("00.00"), oEmpNameChecked, oEmpNameApproved);
                    dt_Leave.Rows.Add(oLeave.Leave_ID, oLeave.Leave_Start.ToString(clsConfig.Format_Date) + " To " + oLeave.Leave_End.ToString(clsConfig.Format_Date), oLeave.Reason, (oLeave.Leaves_Utilized), oEmpNameChecked, oEmpNameApproved);
                }
                grd_LeaveDetails.ItemsSource = dt_Leave.DefaultView;
                if (dt_Leave.Rows.Count > 0)
                {
                    grd_LeaveDetails.Visibility = Visibility.Visible;
                    tbx_Leave.Visibility = Visibility.Visible;
                }
                else
                {
                    grd_LeaveDetails.Visibility = Visibility.Collapsed;
                    tbx_Leave.Visibility = Visibility.Collapsed;
                }
                #endregion

                #region GP
                foreach (tbl_tasTxGatePass oGatePass in tbl_tasTxGatePass.SelectAll().Where(p => !p.IsCanceled && p.GatePass_DateTime.Date == Date && p.Employee_ID == EmpID))
                {
                    dt_GatePass.Rows.Add(oGatePass.GatePass_ID, oGatePass.GatePass_DateTime.ToString(clsConfig.Format_Date), oGatePass.Reason, (oGatePass.Leave_Hours / 60).ToString("00.00"), clsRef_Name.get_EmployeeName(oGatePass.UserID_Supevisor), clsRef_Name.get_EmployeeName(oGatePass.UserID_Manager));
                }
                grd_GatePass.ItemsSource = dt_GatePass.DefaultView;
                if (dt_GatePass.Rows.Count > 0)
                {
                    grd_GatePass.Visibility = Visibility.Visible;
                    tbx_GatePass.Visibility = Visibility.Visible;
                }
                else
                {
                    grd_GatePass.Visibility = Visibility.Collapsed;
                    tbx_GatePass.Visibility = Visibility.Collapsed;
                }
                #endregion
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        public void Refresh(string EmpID)
        {
            sEmpID = EmpID;
            try
            {
                ClearFields();
               
                //foreach (tbl_tasEmployeeLeaveCard oLeave in tbl_tasEmployeeLeaveCard.SelectAllByEmployee_ID(EmpID).Where(p => p.ApprovalStatus_Manager == 1))
                foreach (tbl_tasEmployeeLeaveCard oLeave in tbl_tasEmployeeLeaveCard.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, EmpID).Where(p => !p.IsCancled)) //Changed by 2016.07.20 - Gayan
                {
                    string oEmpNameChecked = "-";
                    string oEmpNameApproved = "-";

                    if (oLeave.ApprovalStatus_Supevosior == (int)ApprovalStatus.Approved)
                    {
                        tbl_genMasEmployee oEmpChecked = tbl_genMasEmployee.Select(oLeave.UserID_Supevisor, clsSecurity.CompanyID, clsSecurity.BranchID);
                        if (oEmpChecked != null)
                        {
                            oEmpNameChecked = oEmpChecked.Initails + " " + oEmpChecked.SurName;
                        }
                    }

                    if (oLeave.ApprovalStatus_Manager == (int)ApprovalStatus.Approved)
                    {
                        tbl_genMasEmployee oEmpApproved = tbl_genMasEmployee.Select(oLeave.UserID_Manager, clsSecurity.CompanyID, clsSecurity.BranchID);
                        if (oEmpApproved != null)
                        {
                            oEmpNameApproved = oEmpApproved.Initails + " " + oEmpApproved.SurName;
                        }
                    }

                    dt_Leave.Rows.Add(oLeave.Leave_ID, oLeave.Leave_Start.ToString(clsConfig.Format_Date) + " To " + oLeave.Leave_End.ToString(clsConfig.Format_Date), oLeave.Reason, (oLeave.Leaves_Utilized / 60).ToString("00.00"), oEmpNameChecked, oEmpNameApproved);
                }
                grd_LeaveDetails.ItemsSource = dt_Leave.DefaultView;
                if (dt_Leave.Rows.Count > 0)
                {
                    grd_LeaveDetails.Visibility = Visibility.Visible;
                    tbx_Leave.Visibility = Visibility.Visible;
                }
                else
                {
                    grd_LeaveDetails.Visibility = Visibility.Collapsed;
                    tbx_Leave.Visibility = Visibility.Collapsed;
                }

                foreach (tbl_tasTxGatePass oGatePass in tbl_tasTxGatePass.SelectAll().Where(p => p.Employee_ID == EmpID && p.IsCanceled == false))
                {
                    string oEmpNameChecked = "-";
                    string oEmpNameApproved = "-";

                    if (oGatePass.ApprovalStatus_Supevosior == 1)
                    {
                        tbl_genMasEmployee oEmpChecked = tbl_genMasEmployee.Select(oGatePass.UserID_Supevisor, clsSecurity.CompanyID, clsSecurity.BranchID);
                        if (oEmpChecked != null)
                        {
                            oEmpNameChecked = (oEmpChecked.Initails + " " + oEmpChecked.SurName);
                        }
                    }

                    if (oGatePass.ApprovalStatus_Manager == 1)
                    {
                        tbl_genMasEmployee oEmpApproved = tbl_genMasEmployee.Select(oGatePass.UserID_Manager, clsSecurity.CompanyID, clsSecurity.BranchID);
                        if (oEmpApproved != null)
                        {
                            oEmpNameApproved = (oEmpApproved.Initails + " " + oEmpApproved.SurName);
                        }
                    }

                    dt_GatePass.Rows.Add(oGatePass.GatePass_ID, oGatePass.GatePass_DateTime.ToString(clsConfig.Format_Date), oGatePass.Reason, (oGatePass.Leave_Hours / 60).ToString("00.00"), oEmpNameChecked, oEmpNameApproved);
                }
                grd_GatePass.ItemsSource = dt_GatePass.DefaultView;

                if (dt_GatePass.Rows.Count > 0)
                {
                    grd_GatePass.Visibility = Visibility.Visible;
                    tbx_GatePass.Visibility = Visibility.Visible;
                }
                else
                {
                    grd_GatePass.Visibility = Visibility.Collapsed;
                    tbx_GatePass.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        public static DependencyProperty Show_LeavePeriod_Property = DependencyProperty.Register("DependencyProperty", typeof(Visibility), typeof(UC_Leave_GP_History));
        public Visibility Show_LeavePeriod
        {
            get
            {
                return (Visibility)GetValue(Show_LeavePeriod_Property);
            }
            set
            {
                SetValue(Show_LeavePeriod_Property, value);
            }
        }

        public static DependencyProperty Show_Date_Property = DependencyProperty.Register("Show_Date", typeof(Visibility), typeof(UC_Leave_GP_History));
        public Visibility Show_Date
        {
            get
            {
                return (Visibility)GetValue(Show_Date_Property);
            }
            set
            {
                SetValue(Show_Date_Property, value);
            }
        }

        private void grd_LeaveDetails_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            LeaveGrid_MouseLeftButtonUp(sender, e);
        }

        private void grd_GatePass_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GatePassGrid_MouseLeftButtonUp(sender, e);
        }
    }
}
