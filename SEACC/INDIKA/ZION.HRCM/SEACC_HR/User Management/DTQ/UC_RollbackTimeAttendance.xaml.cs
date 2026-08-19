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

namespace Digiteq.User_Management.DTQ
{
    /// <summary>
    /// Interaction logic for UC_RollbackTimeAttendance.xaml
    /// </summary>
    public partial class UC_RollbackTimeAttendance : UserControl
    {
        public UC_RollbackTimeAttendance()
        {
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.RollbackTimeAttendance;
            SEACC_Form.Initialize();

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, false, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            #endregion

            ClearFields();
        }

        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        #region Button Roll Back
        private void btn_Rollback_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime dtmStartDate = dtpStartDate.GetDateTime().Date;
                DateTime dtmEndDate = dtpEndDate.GetDateTime().Date;

                List<tbl_payMas_ProcessPeriod_Sub> oClosedPayrolls = null;
                if (txtEmployee.Tag != null && txtEmployee.Text != "")
                {
                    tbl_genMasEmployee detail = tbl_genMasEmployee.Select(txtEmployee.Tag.ToString(), clsSecurity.CompanyID, clsSecurity.BranchID);
                    tbl_payMas_ProcessPeriod_Sub oSubPeriod = tbl_payMas_ProcessPeriod_Sub.SelectAllByDateRange(dtmStartDate.Date, dtmEndDate.Date).Where(p => p.ProcessGroup_ID == detail.Payroll_ProcessGroupID).FirstOrDefault();
                    if (oSubPeriod != null)
                    {
                        oClosedPayrolls = tbl_payMas_ProcessPeriod_Sub.SelectAll().Where(r => r.StartDate.Date >= dtmStartDate && r.IsClosedPeriod && r.ProcessPeriod_Sub_ID == oSubPeriod.ProcessPeriod_Sub_ID).ToList();
                    }
                }
                else
                    oClosedPayrolls = tbl_payMas_ProcessPeriod_Sub.SelectAll().Where(r => r.StartDate.Date >= dtmStartDate && r.IsClosedPeriod).ToList();

                //List<tbl_genMasEmpAttendanceProcessPeriod> oClosedMonthlyAttendance = null;
                //if (clsConfig.bEnable_Roster)
                //{
                //    if (txtEmployee.Tag != null && txtEmployee.Text != "")
                //    {
                //        tbl_genMasEmployee detail = tbl_genMasEmployee.Select(txtEmployee.Tag.ToString(), clsSecurity.CompanyID, clsSecurity.BranchID);
                //        tbl_tasTxMonthlyAttendance oSubPeriod = tbl_tasTxMonthlyAttendance.SelectAllBy_EmployeeIDWithDateRange(txtEmployee.Tag.ToString(), dtmStartDate.Date, dtmEndDate.Date).Where(p => p.AttenProcessGroup_ID == detail.AttendanceGroup1_ID).FirstOrDefault();
                //        if (oSubPeriod != null)
                //        {
                //            oClosedMonthlyAttendance = tbl_genMasEmpAttendanceProcessPeriod.SelectAllByAttenProcessGroup_ID(detail.AttendanceGroup1_ID).Where(r => r.StartDate.Date >= dtmStartDate && r.IsComplepted && r.AttenProcessGroup_ID == oSubPeriod.AttenProcessGroup_ID).ToList();
                //        }
                //    }
                //    else
                //        oClosedMonthlyAttendance = tbl_genMasEmpAttendanceProcessPeriod.SelectAll().Where(r => r.StartDate.Date >= dtmStartDate && r.IsComplepted).ToList();
                //}

                if (oClosedPayrolls != null && oClosedPayrolls.Count > 0)
                {
                    SEACCMessageBox.Show("Can't Rollback", "Payroll has been already processed within this period", MessageBoxButton.OK, "Red");
                }
                //else if (oClosedMonthlyAttendance != null && oClosedMonthlyAttendance.Count > 0 && clsConfig.bEnable_Roster)
                //{
                //    SEACCMessageBox.Show("Can't Rollback", "Monthly Attendance has been already processed within this period", MessageBoxButton.OK, "Red");
                //}
                else
                {
                    bool bMessegeBoxResult = SEACCMessageBox.Show("Confirmation", "Are you sure to clear time attendance data?", MessageBoxButton.YesNo, "#FF5B6B76");
                    if (bMessegeBoxResult)
                    {
                        string sEmployee_ID = "%";
                        if (txtEmployee.Tag != null)
                            sEmployee_ID = txtEmployee.Tag.ToString();

                        DBHandling.ExecQuery("exec sp_attendance_flush '" + dtmStartDate + "', '" + dtmEndDate + "', '" + sEmployee_ID + "'");
                        SEACCMessageBox.Show("Successfully Rollbacked", "", MessageBoxButton.OK);
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

            //cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDivision, false, false, false);
            //cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDepartment, true, false, false);
            //cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtsection, false, false, false);
            //cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtAttendanceGroup1, false, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmployee, true, false, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpStartDate, true, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpEndDate, true, false);

            txtEmployee.Text = "<All Employees>";
            txtEmployee.Tag = null;

            //txtDivision.Text = "";
            //txtDivision.Tag = null;

            //txtDepartment.Text = "";
            //txtDepartment.Tag = null;

            //txtsection.Text = "";
            //txtsection.Tag = null;

            //txtAttendanceGroup1.Text = "";
            //txtAttendanceGroup1.Tag = null;

            dtpStartDate.SetTime(DateTime.Now);
            dtpEndDate.SetTime(DateTime.Now);

        }
        #endregion

        #region Employee Fill Details
        //private void FillDetails_Employee(string sID)
        //{
        //    try
        //    {
        //        tbl_genMasEmployee detail = tbl_genMasEmployee.Select(sID, clsSecurity.CompanyID, clsSecurity.BranchID);
        //        if (detail != null)
        //        {
        //            txtDivision.Text = clsRef_Name.get_Division_Name(detail.Division_ID);
        //            txtDivision.Tag = detail.Division_ID;

        //            txtDepartment.Text = clsRef_Name.get_Department_Name(detail.Department_ID);
        //            txtDepartment.Tag = detail.Department_ID;

        //            txtsection.Text = clsRef_Name.get_Section_Name(detail.SectionID);
        //            txtsection.Tag = detail.SectionID;

        //            txtAttendanceGroup1.Text = clsRef_Name.get_Attendance_ProcessGroup1(detail.AttendanceGroup1_ID);
        //            txtAttendanceGroup1.Tag = detail.AttendanceGroup1_ID;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
        //    }
        //}
        #endregion

        #region Double Click
        private void txtEmployee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                txtEmployee.Text = lstResult[1] + "-" + lstResult[2];
                txtEmployee.Tag = lstResult[0];
                //FillDetails_Employee(txtEmployee.Tag.ToString());
            }
        }
        #endregion

    }
}
