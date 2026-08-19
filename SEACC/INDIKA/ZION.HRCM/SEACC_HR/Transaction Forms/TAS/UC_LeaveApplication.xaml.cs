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
using System.IO;

namespace Digiteq
{
    public partial class UC_LeaveApplication : UserControl
    {
        #region Class Variable
        DateTime currentHRYear_StartDate = DateTime.Now, currentHRYear_EndDate = DateTime.Now;
        int iCurrentHRYear_ID = 0;
        #endregion

        #region Form Load
        public UC_LeaveApplication()
        {
            #region Initialize Usercontroller
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Personal_Leave;
            SEACC_Form.Initialize();

            tbl_hrPeriod_Year oYear = tbl_hrPeriod_Year.SelectAll().Where(r => r.Year_startDate.Date <= DateTime.Now.Date && r.Year_endDate >= DateTime.Now.Date).FirstOrDefault();
            if (oYear != null)
            {
                iCurrentHRYear_ID = oYear.Year_ID;
                currentHRYear_StartDate = oYear.Year_startDate.Date;
                currentHRYear_EndDate = oYear.Year_endDate.Date;
            }
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            SEACC_Form.btn_Save.Click += btn_Save_Click;
            SEACC_Form.btn_New.Click += btn_New_Click;
            SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            #endregion

            clearFields();
            EmployeeDashBoardLogin();
        }
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(550);
        }
        #endregion

        #region Form Action Buttons
        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            clearFields();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            //to do validate Approvals
            try
            {
                bool MessageBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                if (MessageBoxResult)
                {
                    if (SEACC_Form.IsUpdateMode)
                    {
                        tbl_tasEmployeeLeaveCard detail = tbl_tasEmployeeLeaveCard.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtLeaveID.Tag.ToString().Trim());
                        if (detail != null)
                        {
                            #region Roalback Utilized leaves
                            tbl_tasEmployeeLeave_entitled oLeaveUti = tbl_tasEmployeeLeave_entitled.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtEmployeeNo.Tag.ToString(), iCurrentHRYear_ID, detail.LeaveType_ID);
                            if (oLeaveUti != null)
                            {
                                oLeaveUti.Leaves_Utilized -= detail.Leaves_Utilized;
                                oLeaveUti.Update();
                            }

                            #endregion

                            detail.IsCancled = true;
                            detail.Date_Canceled = clsSecurity.getServerDateTime();
                            detail.TerminalID_Canceled = clsSecurity.TerminalID;
                            detail.UserID_Canceled = clsSecurity.UserIDLoged;
                            detail.Update();

                            clsAlerts_Email.CreateEmail_LeaveApplication(enum_Alerts.LeaveCancel, txtLeaveID.Tag.ToString().Trim(), "");
                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message);
            }
            finally
            {
                //RefrehGrid_LeaveBreakdown();
                //RefreshGrid_LeaveBalance();
                //RefrshGrid_LeaveHostory();
                clearFields();
            }
        }

        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (txtLeaveType.Tag != null)
            {
                try
                {
                    string sLeaveTypeID = txtLeaveType.Tag.ToString();
                    tbl_hrMasLeaveTypes oLtype = tbl_hrMasLeaveTypes.Select(sLeaveTypeID, clsSecurity.CompanyID, clsSecurity.BranchID);
                    if (oLtype != null)
                    {
                        if (CheckValidity(oLtype.IsDaysLimit))
                        {
                            int cp1State = 0;
                            int cp2State = 0;
                            int cbCheckedState = 0;
                            int cbApprovedState = 0;

                            string sYearID = clsCommon.GetHRyear_ID(dtp_LeaveStart.GetDateTime());

                            #region Method Variable setting
                            if (cnx_CoveringP1.IsChecked.Value)
                                cp1State = 1;
                            if (cnx_CoveringP2.IsChecked.Value)
                                cp2State = 1;
                            if (cbx_Checked.IsChecked.Value)
                                cbCheckedState = 1;
                            if (cbx_Approved.IsChecked.Value)
                                cbApprovedState = 1;

                            tbl_genMasEmployee oEmployee = tbl_genMasEmployee.Select(txtEmployeeNo.Tag.ToString(), clsSecurity.CompanyID, clsSecurity.BranchID);
                            string[] empShiftDetails = clsHelpMethods.getEmpShiftDetails(txtEmployeeNo.Tag.ToString(), dtp_LeaveStart.GetDateTime(), oEmployee.IsRosterBasedEmployee);
                            decimal leaveDuration = decimal.Parse(txtDuration.Text);
                            #endregion

                            #region Update
                            if (SEACC_Form.IsUpdateMode)
                            {
                                if (SEACC_Form.CheckPermisshion_ToUpdate())
                                {
                                    tbl_tasEmployeeLeaveCard oldRecord = tbl_tasEmployeeLeaveCard.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtLeaveID.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        tbl_tasEmployeeLeave_entitled oEntitledLeave = tbl_tasEmployeeLeave_entitled.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtEmployeeNo.Tag.ToString(), iCurrentHRYear_ID, oldRecord.LeaveType_ID);
                                        if (oEntitledLeave != null)
                                        {
                                            #region Roalback Entitled Leave
                                            if (oLtype.IsDaysLimit)
                                            {
                                                oEntitledLeave.Leaves_Utilized -= oldRecord.Leaves_Utilized;
                                                oEntitledLeave.Update();
                                            }
                                            #endregion

                                            #region Update Leave Card
                                            tbl_tasEmployeeLeaveCard oLeaveCard = new tbl_tasEmployeeLeaveCard(clsSecurity.CompanyID, clsSecurity.BranchID, oldRecord.Leave_ID, oldRecord.Employee_ID, int.Parse(sYearID), dtp_LeaveStart.GetDateTime(), dtp_LeaveEnd.GetDateTime(), txtLeaveType.Tag.ToString(),
                                                leaveDuration, txtReason.Text, cp1State, cp2State, cbCheckedState, cbApprovedState, oldRecord.Comments_CP1, oldRecord.Comments_CP2, oldRecord.Comments_Supevisor, oldRecord.Comments_Manager, oldRecord.IsCancled, oldRecord.UserID_Created,
                                                clsSecurity.UserGroupIDLoged, oldRecord.UserID_Canceled, Wusr_CoveringP1.GetEmpID(), Wusr_CoveringP2.GetEmpID(), Wusr_Checked.GetEmpID(), Wusr_Approved.GetEmpID(), oldRecord.TerminalID_Created, clsSecurity.TerminalID, oldRecord.TerminalID_Canceled,
                                                oldRecord.TerminalID_CP1, oldRecord.TerminalID_CP2, oldRecord.TerminalID_Supevisor, oldRecord.TerminalID_Manager, oldRecord.Date_Created, clsSecurity.getServerDateTime(), oldRecord.Date_Canceled, oldRecord.Date_Checked_CP1, oldRecord.Date_Checked_CP2,
                                                oldRecord.Date_Checked_Supevisor, oldRecord.Date_Checked_Manager);
                                            oLeaveCard.Update();

                                            oEntitledLeave.Leaves_Utilized += leaveDuration;
                                            oEntitledLeave.Update();
                                            #endregion

                                            #region Leave Card Details
                                            tbl_tasEmployeeLeaveCard_Detail.DeleteAllByCompany_ID_CompanyBranch_ID_Leave_ID(oLeaveCard.Company_ID, oLeaveCard.CompanyBranch_ID, oLeaveCard.Leave_ID);
                                            Leave_BreakDownIntoDays(leaveDuration, dtp_LeaveStart.GetDateTime(), dtp_LeaveEnd.GetDateTime());
                                            #endregion

                                            clsAlerts_Email.CreateEmail_LeaveApplication(enum_Alerts.LeaveUpdated, txtLeaveID.Text.Trim(), "");
                                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                        }
                                    }
                                }
                            }
                            #endregion

                            #region Save
                            else
                            {
                                #region Get AutoGenarate Code
                                if (SEACC_Form.isAutoGenaratedCode)
                                    txtLeaveID.Text = SEACC_Form.getAutoGeneratedCode();
                                #endregion

                                if (txtLeaveID.Text.Length != 0)
                                {
                                    if (Check_ShortLeaves(txtEmployeeNo.Tag.ToString()))
                                    {
                                        tbl_tasEmployeeLeave_entitled oEntitledLeave = tbl_tasEmployeeLeave_entitled.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtEmployeeNo.Tag.ToString(), int.Parse(sYearID), txtLeaveType.Tag.ToString());
                                        if (oEntitledLeave != null || !oLtype.IsDaysLimit)
                                        {
                                            #region update entitle leave
                                            if (oLtype.IsDaysLimit)
                                            {
                                                oEntitledLeave.Leaves_Utilized += leaveDuration;
                                                oEntitledLeave.Update();
                                            }
                                            #endregion

                                            #region Leave Card
                                            tbl_tasEmployeeLeaveCard detail = new tbl_tasEmployeeLeaveCard(clsSecurity.CompanyID, clsSecurity.BranchID, txtLeaveID.Text.Trim(), txtEmployeeNo.Tag.ToString(), int.Parse(sYearID), dtp_LeaveStart.GetDateTime(), dtp_LeaveEnd.GetDateTime(), txtLeaveType.Tag.ToString(), leaveDuration, txtReason.Text, cp1State, cp2State, cbCheckedState, cbApprovedState, "", "", "", "", false,
                                                clsSecurity.UserIDLoged, "default", "default", Wusr_CoveringP1.GetEmpID(), Wusr_CoveringP2.GetEmpID(), Wusr_Checked.GetEmpID(), Wusr_Approved.GetEmpID(),
                                                clsSecurity.TerminalID, "default", "default", "default", "default", "default", "default",
                                                clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                                            detail.Insert();
                                            #endregion

                                            #region Leave Card Details
                                            Leave_BreakDownIntoDays(leaveDuration, dtp_LeaveStart.GetDateTime(), dtp_LeaveEnd.GetDateTime());
                                            #endregion

                                            clsAlerts_Email.CreateEmail_LeaveApplication(enum_Alerts.LeaveApplied, txtLeaveID.Text.Trim(), "");
                                            SEACCMessageBox.Show("Leave applied successfully", "", MessageBoxButton.OK);
                                        }
                                    }
                                }
                            }
                            #endregion

                        }
                    }
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
                finally
                {
                    Vw_EmployeeDemography.setEmployeeDetail(txtEmployeeNo.Tag.ToString());
                    wjLeave.setLeaveDetail(txtEmployeeNo.Tag.ToString());
                }
            }
            else
            {
                SEACCMessageBox.Show("Leave Type Not Selected", "", MessageBoxButton.OK, "Red");
            }
        }
        #endregion

        #region Clear Fields
        private void clearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtLeaveID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmployeeNo, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtLeaveType, true, false, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtp_LeaveStart, true, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtp_LeaveEnd, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtReason, true, false, true);

            txtLeaveID.Tag = null;
            txtEmployeeNo.Tag = 0;

            txtLeaveID.Text = "";
            txtEmployeeNo.Text = "";

            txtLeaveType.Tag = null;
            txtLeaveType.Text = "<Select Leave Type...>";
            txtLeaveType.IsEnabled = true;

            tbl_genMasEmployee oEmployee = tbl_genMasEmployee.Select(clsSecurity.EmployeeIDLoged, clsSecurity.CompanyID, clsSecurity.BranchID);
            string[] empShiftDetails = null;
            if (oEmployee != null)
                empShiftDetails = clsHelpMethods.getEmpShiftDetails(clsSecurity.EmployeeIDLoged, DateTime.Today, oEmployee.IsRosterBasedEmployee);

            if (empShiftDetails != null && empShiftDetails[(int)ShiftDetails.shiftStartTime] != "")
            {
                dtp_LeaveStart.SetTime(clsValidation.Merge_DateAndTime(DateTime.Now, DateTime.Parse(empShiftDetails[(int)ShiftDetails.shiftStartTime])));
                dtp_LeaveEnd.SetTime(clsValidation.Merge_DateAndTime(DateTime.Now, DateTime.Parse(empShiftDetails[(int)ShiftDetails.shiftStartTime]).AddMinutes(double.Parse(empShiftDetails[(int)ShiftDetails.ShiftMins]))));
            }
            else
            {
                dtp_LeaveStart.SetTime(DateTime.Now);
                dtp_LeaveEnd.SetTime(DateTime.Now.AddDays(1));
            }

            txtReason.Text = "";
            txtDuration.Text = "0.00";

            txtReason.Text = "";

            this.SEACC_Form.btn_Save.Visibility = Visibility.Visible;
            this.SEACC_Form.btn_Cancel.Visibility = Visibility.Visible;

            Wusr_Checked.Clear();
            Wusr_Approved.Clear();
            Wusr_CoveringP1.Clear();
            Wusr_CoveringP2.Clear();

            Vw_EmployeeDemography.ClearFields();

            #region Set Auto Genarate Key fields
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtLeaveID.Text = "<Auto Generate>";
                txtLeaveID.setReadOnlyStatus(true);
            }
            else
                txtLeaveID.setReadOnlyStatus(false);
            #endregion

            wjLeave.setLeaveDetail("");

            EmployeeDashBoardLogin();
        }
        #endregion

        #region Check Validity
        private bool CheckValidity(bool bDaysLimit)
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_DuplicateRecords())
                {
                    if (CheckValidity_Date())
                    {
                        if (CheckValidity_LeaveBalance(bDaysLimit))
                        {
                            if (CheckValidity_Act_as_CoveingPerson())
                            {
                                if (Checkvalidity_isCoveringPerson_Leave())
                                {
                                    if (CheckValidity_DateRange())
                                    {
                                        if (CheckTimeValidity())
                                        {
                                            if (CheckValidity_isApprovedLeave())
                                            {
                                                if (CheckShortLeaveTimeValidity())
                                                {
                                                    bStatus = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return bStatus;
        }
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtLeaveID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyTag(txtEmployeeNo))
                bStatus = false;
            if (!clsValidation.Validate_EmptyTag(txtLeaveType))
                bStatus = false;
            if (!clsValidation.Validate_SEACC_UserIndicator_Small_EmptyValue(Wusr_Approved))
                bStatus = false;
            if (!clsValidation.Validate_SEACC_UserIndicator_Small_EmptyValue(Wusr_Checked))
                bStatus = false;

            return bStatus;
        }
        public bool CheckValidity_DuplicateRecords()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_tasEmployeeLeaveCard oDetail = tbl_tasEmployeeLeaveCard.Select(txtLeaveID.Text, clsSecurity.CompanyID, clsSecurity.BranchID);
                if (oDetail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }
        private bool CheckValidity_Date()
        {
            bool bStatus = true;
            double iLeaveTotal = 0.00;

            /*
             * Commented by Gayan 2016.05.24
             * 
            foreach (System.Data.DataRowView row in grd_LeaveBreakDown.ItemsSource)
            {
                string a = row[2].ToString();
                double b = double.Parse(a);
                iLeaveTotal = iLeaveTotal + b;
            }
             */

            if (decimal.Parse(txtDuration.Text) <= 0)
            {
                bStatus = false;
                SEACCMessageBox.Show("Oops....", "You going to applly levave for 0 ,minutes. ", MessageBoxButton.OK);
            }

            /*
             * Commented by Gayan 2016.05.24
             * 
            else if (iLeaveTotal == 0)
            {
                bStatus = false;
                SEACCMessageBox.Show("Oops....", "Please enter leave breakdown", MessageBoxButton.OK);
            }
             */

            //else if (iLeaveTotal != double.Parse(txtNoOFLeaveDays.Text))
            //{
            //    bStatus = false;
            //    SEACCMessageBox.Show("Oops....", "The date range you selected not tally with days you going to apply. ", MessageBoxButton.OK);
            //}
            return bStatus;
        }
        private bool CheckValidity_LeaveBalance(bool bDaysLimit)
        {
            bool bStatus = true;

            string sLeaveTypeID = txtLeaveType.Tag.ToString();
            decimal dLeaveDays = decimal.Parse(txtDuration.Text);

            if (bDaysLimit)
            {
                //need to check
                string sYearID = clsCommon.GetHRyear_ID(dtp_LeaveStart.GetDateTime());

                if (dLeaveDays > 0)
                {
                    decimal dBalanceLeaves = 0;

                    tbl_tasEmployeeLeave_entitled oLeaveEntitled = tbl_tasEmployeeLeave_entitled.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtEmployeeNo.Tag.ToString().Trim(), int.Parse(sYearID), sLeaveTypeID);
                    if (oLeaveEntitled != null)
                    {
                        dBalanceLeaves = oLeaveEntitled.Leaves_Entitled - oLeaveEntitled.Leaves_Utilized;
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_tasEmployeeLeaveCard oELCdetail = tbl_tasEmployeeLeaveCard.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtLeaveID.Text);
                            if (oELCdetail != null)
                                dBalanceLeaves += oELCdetail.Leaves_Utilized;
                        }
                    }

                    if (dBalanceLeaves < dLeaveDays)
                    {
                        bStatus = false;
                        SEACCMessageBox.Show("Oops....", "You haven't enough'" + clsRef_Name.get_leaveType_Name(sLeaveTypeID) + "' leaves to apply", MessageBoxButton.OK);
                    }
                }
            }
            return bStatus;
        }
        private bool CheckValidity_Act_as_CoveingPerson()
        {
            bool bStatus = true;
            foreach (tbl_tasEmployeeLeaveCard detail in tbl_tasEmployeeLeaveCard.SelectAll().Where(p => (p.UserID_CP1 == txtEmployeeNo.Tag.ToString() || p.UserID_CP2 == txtEmployeeNo.Tag.ToString()) && p.Leave_Start.ToString(clsConfig.Format_Date) == dtp_LeaveStart.GetDateTime().ToString(clsConfig.Format_Date)))
            {
                bStatus = false;
                SEACCMessageBox.Show("Oops....", "You have been assigned as a covering person of " + clsRef_Name.get_EmployeeName(detail.Employee_ID) + "'s Leave from '" + detail.Leave_Start.ToString(clsConfig.Format_Date) + "' to '" + detail.Leave_End.ToString(clsConfig.Format_Date) + "'", MessageBoxButton.OK);
                break;
            }
            return bStatus;
        }
        private bool Checkvalidity_isCoveringPerson_Leave()
        {
            bool bStatus = true;
            foreach (tbl_tasEmployeeLeaveCard detail in tbl_tasEmployeeLeaveCard.SelectAll().Where(p => (p.Employee_ID == Wusr_CoveringP1.GetEmpID() || p.Employee_ID == Wusr_CoveringP2.GetEmpID()) && (p.Leave_Start.ToString(clsConfig.Format_Date) == dtp_LeaveStart.GetDateTime().ToString(clsConfig.Format_Date) || p.Leave_End.ToString(clsConfig.Format_Date) == dtp_LeaveEnd.GetDateTime().ToString(clsConfig.Format_Date))))
            {
                bStatus = false;
                SEACCMessageBox.Show("Oops....", "The  employee # - '" + detail.Employee_ID + "' you selectd as covering person already applied leave from '" + dtp_LeaveStart.GetDateTime() + "' tO '" + dtp_LeaveEnd.GetDateTime() + "'", MessageBoxButton.OK);
                break;
            }
            return bStatus;
        }
        private bool CheckValidity_DateRange()
        {
            bool bStatus = true;
            if (dtp_LeaveEnd.GetDateTime().Date < dtp_LeaveStart.GetDateTime().Date)
            {
                bStatus = false;
                SEACCMessageBox.Show("Oops....", "Date Range is Incorrect", MessageBoxButton.OK);
            }
            return bStatus;
        }
        private bool CheckTimeValidity()
        {
            bool bStatus = true;
            DateTime fromTime = dtp_LeaveStart.GetDateTime();
            DateTime ToTime = dtp_LeaveEnd.GetDateTime();
            if (fromTime >= ToTime)
            {
                bStatus = false;
                SEACCMessageBox.Show("Warning !", "Invalied Time Selection.Please select from and to time correctly", MessageBoxButton.OK);

            }

            return bStatus;
        }
        private bool CheckValidity_isApprovedLeave()
        {
            bool bStatus = true;
            tbl_tasEmployeeLeaveCard oEmployeeLeave = tbl_tasEmployeeLeaveCard.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtLeaveID.Text.Trim());
            if (oEmployeeLeave != null && clsSecurity.UserGroupIDLoged == "6")
            {
                if (oEmployeeLeave.ApprovalStatus_Manager == 1)
                {
                    SEACCMessageBox.Show("Warning !", "This Leave is already approved or rejected by authorized person.You cannot Edit or Cancel this leave.Please Contect HR Department to Edit or Cancle", MessageBoxButton.OK);
                    bStatus = false;
                }
            }

            return bStatus;
        }
        private bool chek_Leaves(string EmpNo)
        {
            bool bStatus = true;
            foreach (tbl_tasEmployeeLeaveCard detail in tbl_tasEmployeeLeaveCard.SelectAll().Where(p => p.Employee_ID == EmpNo && p.Leave_Start >= dtp_LeaveStart.GetDateTime() && p.Leave_Start <= dtp_LeaveEnd.GetDateTime()))
            {
                if (detail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show("Oops..", "The person you selected applied leave from '" + dtp_LeaveStart.GetDateTime().ToString(clsConfig.Format_Date) + "' to '" + dtp_LeaveEnd.GetDateTime().ToString(clsConfig.Format_Date) + "' ", MessageBoxButton.OK);
                    break;
                }
            }
            return bStatus;
        }
        private bool Check_ShortLeaves(string sEmployee)
        {
            bool bStatus = true;

            if (txtLeaveType.Tag.ToString() == clsConfig.sShortLeaveID)
            {
                DateTime dtDate = dtp_LeaveStart.GetDateTime();
                DateTime dtFromDate = new DateTime(dtDate.Year, dtDate.Month, 1);
                DateTime dtToDate = dtFromDate.AddMonths(1).AddDays(-1);

                List<tbl_tasEmployeeLeaveCard> oLeave = tbl_tasEmployeeLeaveCard.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID,
                                                                                                                                        clsSecurity.BranchID,
                                                                                                                                        sEmployee).Where(p => p.Leave_Start >= dtFromDate.Date
                                                                                                                                                            && p.Leave_End <= dtToDate.Date
                                                                                                                                                            && p.LeaveType_ID == txtLeaveType.Tag.ToString() && !p.IsCancled).ToList();

                if (oLeave.Count >= 2)
                {
                    bStatus = false;
                    SEACCMessageBox.Show("Warning..!", "Short leave can add 2 days per month....", MessageBoxButton.OK);
                }
            }

            return bStatus;
        }        
        private bool CheckShortLeaveTimeValidity() //this validation is set for roster enable customers only
        {
            bool bStatus = true;

            //if (txtLeaveType.Tag.ToString() == clsConfig.sShortLeaveID)
            //{
            //    TimeSpan tsFromTime = dtp_LeaveStart.GetDateTime().TimeOfDay;
            //    TimeSpan tsToTime = dtp_LeaveEnd.GetDateTime().TimeOfDay;
            //    TimeSpan tsTimePeriod = tsToTime - tsFromTime;
            //    TimeSpan tsMinPeriod = new TimeSpan(0, 30, 0);
            //    TimeSpan tsMaxPeriod = new TimeSpan(2, 0, 0);

            //    if (clsConfig.bEnable_Roster)
            //    {
            //        if (tsTimePeriod.TotalMinutes <= tsMinPeriod.TotalMinutes)
            //        {
            //            bStatus = false;
            //            SEACCMessageBox.Show("Invalid Time Selection...!", "Minimum " + txtLeaveType.Text + " time is 30 Minutes...", MessageBoxButton.OK);
            //        }
            //        else if (tsTimePeriod.TotalMinutes >= tsMaxPeriod.TotalMinutes)
            //        {
            //            bStatus = false;
            //            SEACCMessageBox.Show("Invalid Time Selection...!", "Maximum " + txtLeaveType.Text + " time is 02 Hours...", MessageBoxButton.OK);
            //        }
            //    }
            //}

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
                    Wusr_Checked.Clear();
                    Wusr_Approved.Clear();
                    Wusr_CoveringP1.Clear();
                    Wusr_CoveringP2.Clear();

                    SEACC_Form.IsUpdateMode = true;
                    tbl_tasEmployeeLeaveCard detail = tbl_tasEmployeeLeaveCard.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sID);
                    if (detail != null)
                    {
                        txtLeaveID.IsEnabled = false;
                        txtEmployeeNo.IsEnabled = false;

                        Vw_EmployeeDemography.setEmployeeDetail(detail.Employee_ID);

                        txtLeaveID.Tag = detail.Leave_ID;
                        txtEmployeeNo.Tag = detail.Employee_ID;

                        txtLeaveID.Text = detail.Leave_ID;
                        txtEmployeeNo.Text = detail.Employee_ID + " - " + Vw_EmployeeDemography.Employee.FullName;
                        txtReason.Text = detail.Reason;

                        dtp_LeaveStart.SetTime(detail.Leave_Start);
                        dtp_LeaveEnd.SetTime(detail.Leave_End);

                        txtLeaveType.Tag = detail.LeaveType_ID;
                        txtLeaveType.Text = clsRef_Name.get_leaveType_Name(detail.LeaveType_ID);
                        txtLeaveType.IsEnabled = false;

                        txtDuration.Text = cls_Formater.FormatDecimal(detail.Leaves_Utilized, 2);

                        //    txtNoOFLeaveDays.setMinutes(int.Parse(Math.Truncate(detail.Leaves_Utilized).ToString()));

                        clsCommon.Set_UserIndicator(ref Wusr_Checked, detail.UserID_Supevisor);
                        clsCommon.Set_UserIndicator(ref Wusr_Approved, detail.UserID_Manager);
                        clsCommon.Set_UserIndicator(ref Wusr_CoveringP1, detail.UserID_CP1);
                        clsCommon.Set_UserIndicator(ref Wusr_CoveringP2, detail.UserID_CP2);

                        if (detail.ApprovalStatus_CP1 == 1)
                            cnx_CoveringP1.IsChecked = true;
                        else
                            cnx_CoveringP1.IsChecked = false;

                        if (detail.ApprovalStatus_CP2 == 1)
                            cnx_CoveringP2.IsChecked = true;
                        else
                            cnx_CoveringP2.IsChecked = false;

                        if (detail.ApprovalStatus_Supevosior == 1)
                            cbx_Checked.IsChecked = true;
                        else
                            cbx_Checked.IsChecked = false;

                        if (detail.ApprovalStatus_Manager == 1)
                            cbx_Approved.IsChecked = true;
                        else
                            cbx_Approved.IsChecked = false;
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
        private void wjLeave_LeaveSelected(string LeaveID)
        {
            try
            {
                if (LeaveID != null)
                {
                    decimal Utilized = 0.00M;

                    fillDetails(LeaveID);
                    #region Grid Fill Event
                    //dt_LeaveBreakdown.Clear();
                    //foreach (tbl_tasEmployeeLeave_entitled detail_Entitle in tbl_tasEmployeeLeave_entitled.SelectAll().Where(p => p.Employee_ID == txtEmployeeNo.Tag.ToString() && p.HrYear_ID == clsConfig.CurrentHRYearID))
                    //{
                    //    tbl_tasEmployeeLeaveCard_detail detail_card = tbl_tasEmployeeLeaveCard_detail.Select(clsSecurity.CompanyID, clsSecurity.BranchID, LeaveID, detail_Entitle.LeaveType_ID);
                    //    if (detail_card != null)
                    //    {
                    //        Utilized = detail_card.Leaves_Utilized;
                    //        Utilized = Utilized * 9 * 60;
                    //        txtNoOFLeaveDays.setMinutes(Convert.ToInt32(Utilized));
                    //        Utilized = detail_card.Leaves_Utilized;
                    //    }
                    //    else
                    //    {
                    //        Utilized = 0.00m;
                    //    }
                    //    dt_LeaveBreakdown.Rows.Add(detail_Entitle.LeaveType_ID, clsRef_Name.get_leaveType_Name(detail_Entitle.LeaveType_ID), Utilized, detail_Entitle.Leaves_Entitled, detail_Entitle.Leaves_Utilized, "");
                    //}

                    //grd_LeaveBreakDown.ItemsSource = dt_LeaveBreakdown.DefaultView;
                    #endregion
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Event
        private void txtLeaveID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            //  List<string> lstResult = RowDataSearch.Show(Search.Leave);
            if (RowDataSearch.DialogResult == true)
            {
                //    fillDetails(lstResult[0]);
            }
        }

        private void txtEmployeeNo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                frmSearch RowDataSearch = new frmSearch();
                List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);

                if (RowDataSearch.DialogResult == true)
                {
                    clearFields();
                    txtEmployeeNo.Text = lstResult[1] + " - " + lstResult[2];
                    txtEmployeeNo.Tag = lstResult[0];

                    Vw_EmployeeDemography.setEmployeeDetail(lstResult[0]);

                    clsCommon.Set_UserIndicator(ref Wusr_Checked, Vw_EmployeeDemography.Employee.SupevisorID);
                    clsCommon.Set_UserIndicator(ref Wusr_Approved, Vw_EmployeeDemography.Employee.ManagerID);

                    wjLeave.setLeaveDetail(lstResult[0]);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void txtLeaveType_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                frmSearch Srh = new frmSearch();
                List<string> lstResult = Srh.Show(Search.LeaveTypes);
                if (Srh.DialogResult == true)
                {
                    txtLeaveType.Text = lstResult[1];
                    txtLeaveType.Tag = lstResult[0];
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        private void usr_CoveringP1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                tbl_genMasEmployee detail = tbl_genMasEmployee.Select(lstResult[0], clsSecurity.CompanyID, clsSecurity.BranchID);
                if (detail != null)
                    clsCommon.Set_UserIndicator(ref Wusr_CoveringP1, lstResult[0]);
            }
        }

        private void usr_CoveringP2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                tbl_genMasEmployee detail = tbl_genMasEmployee.Select(lstResult[0], clsSecurity.CompanyID, clsSecurity.BranchID);
                if (detail != null)
                    clsCommon.Set_UserIndicator(ref Wusr_CoveringP2, lstResult[0]);
            }
        }
        #endregion

        #region Employee DashBoardLogin
        private void EmployeeDashBoardLogin()
        {
            tbl_securityUserMaster oSecurityUser = tbl_securityUserMaster.Select(clsSecurity.UserIDLoged);

            if (oSecurityUser != null && oSecurityUser.Group_ID == "6" && oSecurityUser.EmployeeID != "default")
            {
                txtEmployeeNo.IsEnabled = false;
                txtEmployeeNo.Text = oSecurityUser.EmployeeID + "-" + clsRef_Name.get_EmployeeName(oSecurityUser.EmployeeID);
                txtEmployeeNo.Tag = oSecurityUser.EmployeeID;

                Vw_EmployeeDemography.setEmployeeDetail(oSecurityUser.EmployeeID);

                clsCommon.Set_UserIndicator(ref Wusr_Checked, Vw_EmployeeDemography.Employee.SupevisorID);
                clsCommon.Set_UserIndicator(ref Wusr_Approved, Vw_EmployeeDemography.Employee.ManagerID);

                wjLeave.setLeaveDetail(clsSecurity.EmployeeIDLoged);
            }
        }
        #endregion

        #region Refresh
        public void RefreshGrid(string sEmpID)
        {
            tbl_genMasEmployee oEmployee = tbl_genMasEmployee.Select(sEmpID, clsSecurity.CompanyID, clsSecurity.BranchID);

            txtEmployeeNo.IsEnabled = false;
            txtEmployeeNo.Text = oEmployee.Employee_ID + "-" + clsRef_Name.get_EmployeeName(oEmployee.Employee_ID);
            txtEmployeeNo.Tag = oEmployee.Employee_ID;

            Vw_EmployeeDemography.setEmployeeDetail(oEmployee.Employee_ID);

            clsCommon.Set_UserIndicator(ref Wusr_Checked, Vw_EmployeeDemography.Employee.SupevisorID);
            clsCommon.Set_UserIndicator(ref Wusr_Approved, Vw_EmployeeDemography.Employee.ManagerID);

            wjLeave.setLeaveDetail(sEmpID);

        }
        #endregion

        #region Date Time Picker , txtNoOFLeaveDays value change
        void updateLeaveHours()
        {
            //to do

            //short leave/ halfday rounding mode
            if (dtp_LeaveEnd.GetDateTime() <= dtp_LeaveStart.GetDateTime())
            {
                lblDateTimeValidation.Text = "Invalied Leave end time";
                lblDateTimeValidation.Visibility = Visibility.Visible;
            }
            else
            {
                lblDateTimeValidation.Visibility = Visibility.Collapsed;

                TimeSpan tsLeaveHours = dtp_LeaveEnd.GetDateTime() - dtp_LeaveStart.GetDateTime();
                decimal dDays = tsLeaveHours.Days;
                decimal dBalance = tsLeaveHours.Hours * 60 + tsLeaveHours.Minutes;

                tbl_genMasEmployee oEmployee = tbl_genMasEmployee.Select(txtEmployeeNo.Tag.ToString(), clsSecurity.CompanyID, clsSecurity.BranchID);
                string[] empShiftDetails = clsHelpMethods.getEmpShiftDetails(txtEmployeeNo.Tag.ToString(), dtp_LeaveStart.GetDateTime(), oEmployee.IsRosterBasedEmployee);
                int iShiftMiniths = int.Parse(empShiftDetails[4]);

                if (dBalance >= int.Parse(empShiftDetails[4]))
                {
                    dDays += 1;
                    dBalance -= iShiftMiniths;
                }
                dBalance = dBalance / iShiftMiniths;
                dDays += dBalance;
                txtDuration.Text = cls_Formater.FormatDecimal(dDays, 2);
            }
        }

        private void dtp_LeaveEnd_DateTimeChanged_1(object sender, EventArgs e)
        {
            updateLeaveHours();
        }

        private void dtp_LeaveStart_DateTimeChanged(object sender, EventArgs e)
        {
            //Payroll Status
            //Added by Gayan
            //2016-11-16
            this.SEACC_Form.btn_Save.Visibility = Visibility.Visible;
            this.SEACC_Form.btn_Cancel.Visibility = Visibility.Visible;
            if (txtEmployeeNo.Tag != null && txtEmployeeNo.Tag.ToString() != "0")
            {
                if (this.SEACC_Form.btn_Save.Visibility == Visibility.Visible)
                {

                    DataTable dtPayrollRawData = DBHandling.ExecQuery("sp_getPayrollRawData_fromEmployeeWise_GivenDate '" + txtEmployeeNo.Tag.ToString() + "' , '" + dtp_LeaveStart.GetDateTime().Date + "'").Tables[0];
                    if (dtPayrollRawData.Rows.Count > 0)
                    {
                        this.SEACC_Form.btn_Save.Visibility = Visibility.Collapsed;
                        this.SEACC_Form.btn_Cancel.Visibility = Visibility.Collapsed;
                    }
                }

                dtp_LeaveEnd.SetTime(clsValidation.Merge_DateAndTime(dtp_LeaveStart.GetDateTime(), dtp_LeaveEnd.GetDateTime()));
                updateLeaveHours();
            }
            else
            {
                SEACCMessageBox.Show("Employee should be selected first", "", MessageBoxButton.OK);
                dtp_LeaveStart.SetTime(DateTime.Now);
            }
        }
        #endregion

        #region Leave Break Down Day Wise
        private void Leave_BreakDownIntoDays(decimal leaveDuration, DateTime dtmLeaveStart, DateTime dtmLeaveEnd)
        {
            List<LeaveData_DayWise> lstLeaveData_DayWise = new List<LeaveData_DayWise>();

            for (DateTime dtmDate = dtmLeaveStart; dtmDate.Date <= dtmLeaveEnd.Date; dtmDate = dtmDate.AddDays(1))
            {
                if (dtmLeaveStart.Date == dtmLeaveEnd.Date)
                {
                    tbl_tasEmployeeLeaveCard_Detail oLeave_Detail = new tbl_tasEmployeeLeaveCard_Detail(1, clsSecurity.CompanyID, clsSecurity.BranchID, txtLeaveID.Text.Trim(), dtmLeaveStart, dtmLeaveEnd);
                    oLeave_Detail.Insert();
                    break;
                }

                #region Variables for Shift
                string sShiftId = "default";
                string sShiftName = "";
                ShiftTypes enmShiftType = ShiftTypes.OneDayShift;
                int iShiftDay = 0;
                string sPriviusShift = "";
                bool bShiftSpecialParameeter1 = false;
                bool bShiftSpecialParameeter2 = false;
                int iShiftMinutes = 0;
                int iShiftMinutes_Min = 0;
                int iNextShift_Minutes = 0;
                int iShiftGracePeriod = 0;
                DateTime dtmShiftStart = clsValidation.defaultDateTime;
                DateTime dtmShiftEnd = clsValidation.defaultDateTime;
                string sShiftStart = "";
                string sShiftEnd = "";

                holidayDurationType hdt = holidayDurationType.N_A;
                tbl_tasHolidayCalander oHoliday = tbl_tasHolidayCalander.SelectByHolidayDate(dtmDate.Date);
                if (oHoliday != null && !oHoliday.IsCanceled)
                    hdt = (holidayDurationType)oHoliday.HolidayDurationType;
                #endregion

                tbl_genMasEmployee oEmployee = tbl_genMasEmployee.Select(txtEmployeeNo.Tag.ToString(), clsSecurity.CompanyID, clsSecurity.BranchID);
                clsHelpMethods.GetShift(dtmDate.Date, txtEmployeeNo.Tag.ToString(), oEmployee.IsRosterBasedEmployee, hdt, ref sShiftId, ref sShiftName, ref enmShiftType, ref iShiftDay, ref sPriviusShift, ref bShiftSpecialParameeter1, ref bShiftSpecialParameeter2, ref iShiftMinutes, ref iShiftMinutes_Min, ref iNextShift_Minutes, ref iShiftGracePeriod, ref dtmShiftStart, ref dtmShiftEnd, ref sShiftStart, ref sShiftEnd);

                double dubMins = 0d;
                if (dtmDate.Date == dtmLeaveStart.Date)
                {
                    dubMins = (dtmShiftEnd - dtmLeaveStart).TotalMinutes;
                    lstLeaveData_DayWise.Add(new LeaveData_DayWise(dtmLeaveStart, dtmShiftEnd, dubMins));
                }
                else if (dtmDate.Date == dtmLeaveEnd.Date)
                {
                    dubMins = (dtmLeaveEnd - dtmShiftStart).TotalMinutes;
                    lstLeaveData_DayWise.Add(new LeaveData_DayWise(dtmShiftStart, dtmLeaveEnd, dubMins));
                }
                else
                {
                    dubMins = (dtmShiftEnd - dtmShiftStart).TotalMinutes;
                    lstLeaveData_DayWise.Add(new LeaveData_DayWise(dtmShiftStart, dtmShiftEnd, dubMins));
                }
            }

            int iCount = 0;
            foreach (LeaveData_DayWise oLeaveData_DayWise in lstLeaveData_DayWise)
            {
                tbl_tasEmployeeLeaveCard_Detail oLeave_Detail = new tbl_tasEmployeeLeaveCard_Detail(++iCount, clsSecurity.CompanyID, clsSecurity.BranchID, txtLeaveID.Text.Trim(), oLeaveData_DayWise.dtmDayDate_Starting, oLeaveData_DayWise.dtmDayDate_Ending);
                oLeave_Detail.Insert();
            }

        }

        struct LeaveData_DayWise
        {
            public LeaveData_DayWise(DateTime dtmDate_Starting, DateTime dtmDate_Ending, double dMins)
                : this()
            {
                dtmDayDate_Starting = dtmDate_Starting;
                dtmDayDate_Ending = dtmDate_Ending;
                dDayMins = dMins;
            }
            public DateTime dtmDayDate_Starting { get; private set; }
            public DateTime dtmDayDate_Ending { get; private set; }
            public double dDayMins { get; private set; }
        }
        #endregion

    }
}