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

namespace Digiteq.Transaction_Forms.CC
{
    /// <summary>
    /// Interaction logic for UC_TemporaryWorkersDailyEntry.xaml
    /// </summary>
    public partial class UC_TemporaryWorkersDailyEntry : UserControl
    {
        public UC_TemporaryWorkersDailyEntry()
        {
            #region Initialize User control
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.CoconutLoadingTemporayWorkers;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("attendenceDate");
            dgr_Main.dt.Columns.Add("day");
            dgr_Main.dt.Columns.Add("employee_ID");
            dgr_Main.dt.Columns.Add("employee_Name");

            dgr_Main.dt.Columns.Add("department_ID");
            dgr_Main.dt.Columns.Add("shift_ID");
            dgr_Main.dt.Columns.Add("ShiftName");
            dgr_Main.dt.Columns.Add("ShiftDay");
            dgr_Main.dt.Columns.Add("Shift_StartTime");
            dgr_Main.dt.Columns.Add("Shift_EndTime");
            dgr_Main.dt.Columns.Add("Shift_Minutes");
            dgr_Main.dt.Columns.Add("Worked_Minutes");
            dgr_Main.dt.Columns.Add("sOT_Minutes");
            dgr_Main.dt.Columns.Add("dOT_Minutes");
            dgr_Main.dt.Columns.Add("tOT_Minutes");

            dgr_Main.dt.Columns.Add("inDateTime_ID_O");
            dgr_Main.dt.Columns.Add("inDateTime_ID_E");
            dgr_Main.dt.Columns.Add("inTime_O");
            dgr_Main.dt.Columns.Add("inTime_E");
            dgr_Main.dt.Columns.Add("outDateTime_ID_O");
            dgr_Main.dt.Columns.Add("outDateTime_ID_E");
            dgr_Main.dt.Columns.Add("outTime_O");
            dgr_Main.dt.Columns.Add("outTime_E");
            dgr_Main.dt.Columns.Add("attendence");
            dgr_Main.dt.Columns.Add("attendence_index");

            dgr_Main.dt.Columns.Add("daily_Wage");
            dgr_Main.dt.Columns.Add("attendance_Allowance");
            dgr_Main.dt.Columns.Add("meal_Allowance");
            dgr_Main.dt.Columns.Add("other_Allowance");
            dgr_Main.dt.Columns.Add("sOT_Amount");
            dgr_Main.dt.Columns.Add("dOT_Amount");
            dgr_Main.dt.Columns.Add("tOT_Amount");

            dgr_Main.dt.Columns.Add("rowBackColor");
            dgr_Main.dt.Columns.Add("foreground");
            #endregion

            #region Acction Button
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Print.Click += btn_Print_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Date", "attendenceDate", 70);
            dgr_Main.Add_DatagridColoumn("Day", "day", 40, false);
            dgr_Main.Add_DatagridColoumn("Emp No.", "employee_ID", 60);
            dgr_Main.Add_DatagridColoumn("Name", "employee_Name", 140);

            dgr_Main.Add_DatagridColoumn("department_ID", "department_ID", 110, false);
            dgr_Main.Add_DatagridColoumn("shift_ID", "shift_ID", 100, false);
            dgr_Main.Add_DatagridColoumn("Shift", "ShiftName", 120, false);
            dgr_Main.Add_DatagridColoumn("Shift Days", "ShiftDay", 20, false);
            dgr_Main.Add_DatagridColoumn("Shift Start", "Shift_StartTime", 65, true);
            dgr_Main.Add_DatagridColoumn("Shift End", "Shift_EndTime", 65, true);
            dgr_Main.Add_DatagridColoumn("Shift Minutes", "Shift_Minutes", 50, false);

            dgr_Main.Add_DatagridColoumn("InDateTime_ID", "inDateTime_ID_E", 80, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "In Time", "inTime_E", 50, true, true);
            dgr_Main.Add_DatagridColoumn("OutDateTime_ID", "outDateTime_ID_E", 80, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Out Time", "outTime_E", 50, true, true);
            dgr_Main.Add_DatagridColoumn("Attendence", "attendence", 80);
            dgr_Main.Add_DatagridColoumn("Attendence Index", "attendence_index", 70, false);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Daily Wage", "daily_Wage", 80, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Atten. Allo.", "attendance_Allowance", 70, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Meal Allo.", "meal_Allowance", 70, false, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Other Allo.", "other_Allowance", 70, false, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Single OT", "sOT_Amount", 70, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Double OT", "dOT_Amount", 70, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Triple OT", "tOT_Amount", 70, false, false);
            #endregion

            dgr_Main.RefreshGrid();
            ClearFields();
        }

        #region Clear Fields
        private void ClearFields()
        {
            dgr_Main.dt.Clear();

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmpNo, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtWeek, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDailyWage, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAttendanceAllowance, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDailyMealAllowance, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDailyOtherAllowance, true, true, false);

            txtEmpNo.Tag = null;
            txtSection.Tag = null;
            txtWeek.Tag = null;

            txtEmpNo.Text = "<All Employees>";
            txtSection.Text = "<All Sections>";
            txtWeek.Text = "-";
            txtDailyWage.Text = "1150.00";
            txtAttendanceAllowance.Text = "100.00";
            txtDailyMealAllowance.Text = "0.00";
            txtDailyOtherAllowance.Text = "0.00";

            dtp_FromDate.SetTime(DateTime.Now);
            dtp_toDate.SetTime(DateTime.Now);
        }
        #endregion

        #region Action Buttons

        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                int iOldRecCount = 0;
                bool bMessegeBoxResult = false;
                bool bNewlyInsert = true;

                foreach (DataRow row in dgr_Main.dt.Rows)
                {
                    DateTime dtmAttendanceDate = clsValidation.Validate_DateTime(row["attendenceDate"].ToString());
                    tbl_hrPeriod_Week oWeek = tbl_hrPeriod_Week.SelectAll().Where(r => r.StartDate.Date <= dtmAttendanceDate && r.EndDate >= dtmAttendanceDate).FirstOrDefault();
                    if (oWeek != null)
                        iOldRecCount += tbl_ccTxTemporaryWorkerDailyWage.SelectAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID(clsSecurity.CompanyID, clsSecurity.BranchID, oWeek.Year_ID, oWeek.Week_ID).Count;

                    if (iOldRecCount > 0)
                        break;
                }

                if (iOldRecCount > 0)
                {
                    bNewlyInsert = false;
                    bMessegeBoxResult = SEACCMessageBox.Show(" Processed Data has been available!!!", "Are you sure to delete this processed data and continue?", MessageBoxButton.YesNo);
                }

                if (bMessegeBoxResult || bNewlyInsert)
                {
                    foreach (DataRow row in dgr_Main.dt.Rows)
                    {
                        int iAttendanceIndex = int.Parse(row["attendence_index"].ToString());
                        if (iAttendanceIndex == -1)
                            continue;

                        #region get values from table
                        DateTime dtmAttendanceDate = clsValidation.Validate_DateTime(row["attendenceDate"].ToString());
                        string sEmployee_ID = row["employee_ID"].ToString();
                        string sDepartment_ID = row["department_ID"].ToString();

                        string sDayType = row["day"].ToString();
                        int iDayType = 0;

                        switch (sDayType)
                        {
                            case "Work":
                                iDayType = 0;
                                break;
                            case "Saturday":
                                iDayType = 1;
                                break;
                            case "Sunday":
                                iDayType = 2;
                                break;
                            case "Poyaday":
                                iDayType = 3;
                                break;
                        }

                        string sShift_ID = row["shift_ID"].ToString();
                        int iShiftDay = int.Parse(row["ShiftDay"].ToString());
                        DateTime dtmShiftStartTime = clsValidation.Merge_DateAndTime(dtmAttendanceDate, clsValidation.Validate_DateTime(row["Shift_StartTime"].ToString()));
                        DateTime dtmShiftEndTime = clsValidation.Merge_DateAndTime(dtmAttendanceDate, clsValidation.Validate_DateTime(row["Shift_EndTime"].ToString()));

                        int iInDateTime_ID = int.Parse(row["InDateTime_ID_O"].ToString());
                        int iInDateTime_ID_E = int.Parse(row["InDateTime_ID_E"].ToString());
                        DateTime dtmInTime = clsValidation.Merge_DateAndTime(dtmAttendanceDate, clsValidation.Validate_DateTime(row["inTime_O"].ToString()));
                        DateTime dtmInTime_E = clsValidation.Merge_DateAndTime(dtmAttendanceDate, clsValidation.Validate_DateTime(row["InTime_E"].ToString()));
                        int iOutDateTime_ID = int.Parse(row["OutDateTime_ID_O"].ToString());
                        int iOutDateTime_ID_E = int.Parse(row["OutDateTime_ID_E"].ToString());
                        DateTime dtmOutTime = clsValidation.Merge_DateAndTime(dtmAttendanceDate, clsValidation.Validate_DateTime(row["OutTime_O"].ToString()));
                        DateTime dtmOutTime_E = clsValidation.Merge_DateAndTime(dtmAttendanceDate, clsValidation.Validate_DateTime(row["OutTime_E"].ToString()));

                        string sAttendenceStatus = row["attendence"].ToString();
                        int iAttendanceStatus = 0;
                        switch (sAttendenceStatus)
                        {
                            case "Present":
                                iAttendanceStatus = 0;
                                break;
                            case "Absent":
                                iAttendanceStatus = 1;
                                break;
                            case "Late":
                                iAttendanceStatus = 2;
                                break;
                            case "ERROR":
                                iAttendanceStatus = 3;
                                break;
                        }

                        decimal dDaily_Wage = clsValidation.Validate_DecimalNumber(row["daily_Wage"].ToString());
                        decimal dAttendance_Allowance = clsValidation.Validate_DecimalNumber(row["attendance_Allowance"].ToString());
                        decimal dMeal_Allowance = clsValidation.Validate_DecimalNumber(row["meal_Allowance"].ToString());
                        decimal dOther_Allowance = clsValidation.Validate_DecimalNumber(row["other_Allowance"].ToString());
                        decimal dSOT_Amount = clsValidation.Validate_DecimalNumber(row["sOT_Amount"].ToString());
                        decimal dDOT_Amount = clsValidation.Validate_DecimalNumber(row["dOT_Amount"].ToString());
                        decimal dTOT_Amount = clsValidation.Validate_DecimalNumber(row["tOT_Amount"].ToString());
                        #endregion

                        #region Update/Insert record
                        tbl_ccTxTemporaryWorkerDailyWage oldRecord = tbl_ccTxTemporaryWorkerDailyWage.Select(clsSecurity.CompanyID, clsSecurity.BranchID, iAttendanceIndex);
                        if (oldRecord != null)
                        {
                            tbl_ccTxTemporaryWorkerDailyWage detail = new tbl_ccTxTemporaryWorkerDailyWage(
                                oldRecord.Company_ID, //Company
                                oldRecord.CompanyBranch_ID, //Branch
                                oldRecord.Attendance_index, //attendance_index
                                dtmAttendanceDate, //attendenceDate
                                int.Parse(txtWeek.ToolTip.ToString()), //year_ID
                                int.Parse(txtWeek.Tag.ToString()), // week_ID
                                sEmployee_ID, // Employee address
                                sDepartment_ID, // department_ID
                                iDayType, // day type
                                sShift_ID, // shift id
                                iShiftDay, // shift day
                                dtmShiftStartTime, // shift strat time
                                dtmShiftEndTime, // shift end time
                                iInDateTime_ID_E, // timeIn_ID
                                dtmInTime_E, //timeIn_DateTime
                                iOutDateTime_ID_E, // timeOut_ID
                                dtmOutTime_E, //timeOut_DateTime
                                iAttendanceStatus, //attendanceStatus
                                dDaily_Wage, //daily wage
                                dAttendance_Allowance, // attendance_Allo
                                dMeal_Allowance, //meal allowance
                                dOther_Allowance, //other_Allo
                                dSOT_Amount, //Single OT
                                dDOT_Amount, //Double OT
                                dTOT_Amount, //Triple OT
                                false, // isLocked
                                false, // isCancelled
                                oldRecord.UserID_Created,
                                clsSecurity.UserIDLoged,
                                "default",
                                oldRecord.TerminalID_Created,
                                clsSecurity.TerminalID,
                                "default",
                                oldRecord.Date_Created,
                                clsSecurity.getServerDateTime(),
                                clsValidation.defaultDateTime);
                            detail.Update();
                        }
                        else
                        {
                            tbl_ccTxTemporaryWorkerDailyWage detail = new tbl_ccTxTemporaryWorkerDailyWage(
                                clsSecurity.CompanyID, //Company
                                clsSecurity.BranchID, //Branch
                                iAttendanceIndex, //attendance_index
                                dtmAttendanceDate, //attendenceDate
                                int.Parse(txtWeek.ToolTip.ToString()), //year_ID
                                int.Parse(txtWeek.Tag.ToString()), // week_ID
                                sEmployee_ID, // Employee address
                                sDepartment_ID, // department_ID
                                iDayType, // day type
                                sShift_ID, // shift id
                                iShiftDay, // shift day
                                dtmShiftStartTime, // shift strat time
                                dtmShiftEndTime, // shift end time
                                iInDateTime_ID_E, // timeIn_ID
                                dtmInTime_E, //timeIn_DateTime
                                iOutDateTime_ID_E, // timeOut_ID
                                dtmOutTime_E, //timeOut_DateTime
                                iAttendanceStatus, //attendanceStatus
                                dDaily_Wage, //daily wage
                                dAttendance_Allowance, // attendance_Allo
                                dMeal_Allowance, //meal allowance
                                dOther_Allowance, //other_Allo
                                dSOT_Amount, //Single OT
                                dDOT_Amount, //Double OT
                                dTOT_Amount, //Triple OT
                                false, // isLocked
                                false, // isCancelled
                                clsSecurity.UserIDLoged,
                                "default",
                                "default",
                                clsSecurity.TerminalID,
                                "default",
                                "default",
                                clsSecurity.getServerDateTime(),
                                clsValidation.defaultDateTime,
                                clsValidation.defaultDateTime);
                            detail.Insert();
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                dgr_Main.dt.Clear();
                SEACCExeption.Show(ex);
            }
            finally
            {
                dgr_Main.dt.Clear();
                dgr_Main.RefreshGrid();
                btnLoad.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                this.Cursor = Cursors.Arrow;
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                dgr_Main.dt.Clear();

                DateTime dtmFromDate = dtp_FromDate.GetDateTime();
                DateTime dtmToDate = dtp_toDate.GetDateTime();

                #region Employee Filter
                List<tbl_genMasEmployee> oEmployees;
                if (txtEmpNo.Tag != null)
                    oEmployees = tbl_genMasEmployee.SelectAll().Where(p => p.Employee_ID == txtEmpNo.Tag.ToString()).ToList();
                else
                    oEmployees = tbl_genMasEmployee.SelectAll().Where(p => p.Employee_ID != "default").ToList();

                if (txtSection.Tag != null)
                    oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();

                #endregion

                #region Create datasets - Holidays
                List<tbl_tasHolidayCalander> oHolidays = tbl_tasHolidayCalander.SelectAllByHolyday_Date(dtmFromDate.Date, dtmToDate.Date).ToList();
                #endregion

                int iShiftDay = 0;
                string sPriviusShift = "";
                foreach (tbl_genMasEmployee oEmployee in oEmployees)
                {
                    for (DateTime dDate = dtmFromDate.Date; dDate.Date <= dtmToDate.Date; dDate = dDate.AddDays(1))
                    {
                        #region variables
                        DateTime dtmShiftStart = clsConfig.defaultDateTime;
                        DateTime dtmShiftEnd = clsConfig.defaultDateTime;
                        DateTime dtmTimeIn = clsConfig.defaultDateTime;
                        DateTime dtmTimeOut = clsConfig.defaultDateTime;

                        int iShiftMinutes = 0, iWorkedMinutes = 0, iSOT_Minutes = 0, iDOT_Minutes = 0, iTOT_Minutes = 0;
                        int iInDateTime_ID = 0, iOutDateTime_ID = 0;
                        int iAttendanceIndex = -1;

                        decimal dDaily_Wage = 0, dAttendance_Allowance = 0, dMeal_Allowance = 0, dOther_Allowance = 0, dSOT_Amount = 0, dDOT_Amount = 0, dTOT_Amount = 0;

                        String sDayType = "Work";

                        string sShiftStart = "-", sShiftEnd = "-";
                        string sShiftId = "", sShiftName = "";
                        string sAttendanceStatus = "Not Saved";
                        ShiftTypes enmShiftType = ShiftTypes.OneDayShift;

                        holidayDurationType hdt = holidayDurationType.N_A;

                        String sRowBackColor = "#FF34495E";
                        string foreground = "white";

                        bool bDailyWorkesWageSavedRow = false;
                        bool bIsAttendancerecord = false;
                        #endregion

                        #region Get Holydays And format rows
                        foreach (tbl_tasHolidayCalander oCal in oHolidays.Where(p => p.Holiday_Date.Date == dDate.Date && !p.IsCanceled))
                        {
                            sRowBackColor = "#FF345A5E";
                            sDayType = "Holiday";
                            hdt = (holidayDurationType)oCal.HolidayDurationType;
                        }

                        if (sDayType == "Work")
                        {
                            if (dDate.DayOfWeek == DayOfWeek.Sunday)
                            {
                                sDayType = "Sunday";
                                sRowBackColor = "#FF57495E";
                            }
                            if (dDate.DayOfWeek == DayOfWeek.Saturday)
                            {
                                sDayType = "Saturday";
                                sRowBackColor = "#FF46495E";
                            }
                        }
                        #endregion

                        #region Add Exixting data
                        tbl_ccTxTemporaryWorkerDailyWage oRecod = tbl_ccTxTemporaryWorkerDailyWage.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, oEmployee.Employee_ID).Where(r => r.AttendenceDate.Date == dDate.Date).FirstOrDefault();
                        if (oRecod != null)
                        {
                            bDailyWorkesWageSavedRow = true;
                            bIsAttendancerecord = true;
                            iAttendanceIndex = oRecod.Attendance_index;
                            sShiftId = oRecod.Shift_ID;
                            sShiftName = clsRef_Name.get_Shift_Name(sShiftId);
                            dtmShiftStart = oRecod.ShiftStartTime;
                            sShiftStart = oRecod.ShiftStartTime.ToString();
                            dtmShiftEnd = oRecod.ShiftEndTime;
                            sShiftEnd = oRecod.ShiftEndTime.ToString();
                            iInDateTime_ID = oRecod.TimeIn_ID;
                            dtmTimeIn = oRecod.TimeIn_DateTime;
                            iOutDateTime_ID = oRecod.TimeOut_ID;
                            dtmTimeOut = oRecod.TimeOut_DateTime;
                            sAttendanceStatus = "Saved";

                            tbl_tasTxDailyAttendance oAtten = tbl_tasTxDailyAttendance.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oRecod.Attendance_index);
                            iShiftMinutes = oAtten.ShiftMinutes;
                            iWorkedMinutes = oAtten.WorkedMinutes;
                            iSOT_Minutes = oAtten.OTMinutesApproved;
                            iDOT_Minutes = oAtten.DOTMinutesApproved;
                            iTOT_Minutes = oAtten.TOTMinutesApproved;

                            dDaily_Wage = oRecod.Daily_Wage;
                            dAttendance_Allowance = oRecod.Attendance_Allowance;
                            dMeal_Allowance = oRecod.Meal_Allowance;
                            dOther_Allowance = oRecod.Other_Allowance;
                            dSOT_Amount = oRecod.SOT_Amount;
                            dDOT_Amount = oRecod.DOT_Amount;
                            dTOT_Amount = oRecod.TOT_Amount;

                            foreground = "yellow";
                        }
                        #endregion

                        #region Add new data
                        else
                        {
                            tbl_tasTxDailyAttendance oAtten = tbl_tasTxDailyAttendance.SelectAllBy_EmployeeIDWithDateRange(oEmployee.Employee_ID, dDate.Date, dDate.Date).FirstOrDefault();
                            if (oAtten != null)
                            {
                                bDailyWorkesWageSavedRow = false;
                                bIsAttendancerecord = true;
                                iAttendanceIndex = oAtten.Attendance_index;
                                sShiftId = oAtten.Shift_ID;
                                sShiftName = clsRef_Name.get_Shift_Name(sShiftId);
                                dtmShiftStart = oAtten.ShiftStartTime;
                                sShiftStart = oAtten.ShiftStartTime.ToString();
                                dtmShiftEnd = oAtten.ShiftEndTime;
                                sShiftEnd = oAtten.ShiftEndTime.ToString();
                                iInDateTime_ID = oAtten.TimeIn_ID;
                                dtmTimeIn = oAtten.TimeIn_DateTime;
                                iOutDateTime_ID = oAtten.TimeOut_ID;
                                dtmTimeOut = oAtten.TimeOut_DateTime;
                                sAttendanceStatus = "Saved";

                                iShiftMinutes = oAtten.ShiftMinutes;
                                iWorkedMinutes = oAtten.WorkedMinutes;
                                iSOT_Minutes = oAtten.OTMinutesApproved;
                                iDOT_Minutes = oAtten.DOTMinutesApproved;
                                iTOT_Minutes = oAtten.TOTMinutesApproved;
                            }
                        }
                        #endregion

                        #region Data Row Initialize
                        DataRow dr = dgr_Main.dt.NewRow();
                        dr["attendenceDate"] = dDate.ToString(clsConfig.Format_Date);
                        dr["day"] = sDayType;
                        dr["employee_ID"] = oEmployee.Employee_ID;
                        dr["employee_Name"] = oEmployee.Initails + " " + oEmployee.SurName;
                        dr["department_ID"] = oEmployee.Department_ID;
                        dr["shift_ID"] = sShiftId;
                        dr["ShiftName"] = sShiftName;
                        dr["attendence_index"] = iAttendanceIndex;
                        dr["ShiftDay"] = 1;// this is for one day shift only
                        dr["attendence"] = sAttendanceStatus;

                        dr["Shift_StartTime"] = clsValidation.GetDisplayValue_Time(sShiftStart);
                        dr["Shift_EndTime"] = clsValidation.GetDisplayValue_Time(sShiftEnd);
                        dr["inDateTime_ID_O"] = iInDateTime_ID;
                        dr["inDateTime_ID_E"] = iInDateTime_ID;
                        dr["inTime_O"] = clsValidation.GetDisplayValue_Time(dtmTimeIn);
                        dr["inTime_E"] = clsValidation.GetDisplayValue_Time(dtmTimeIn);
                        dr["outDateTime_ID_O"] = iOutDateTime_ID;
                        dr["outDateTime_ID_E"] = iOutDateTime_ID;
                        dr["outTime_O"] = clsValidation.GetDisplayValue_Time(dtmTimeOut);
                        dr["outTime_E"] = clsValidation.GetDisplayValue_Time(dtmTimeOut);

                        dr["Shift_Minutes"] = iShiftMinutes;
                        dr["Worked_Minutes"] = iWorkedMinutes;
                        dr["sOT_Minutes"] = iSOT_Minutes;
                        dr["dOT_Minutes"] = iDOT_Minutes;
                        dr["tOT_Minutes"] = iTOT_Minutes;

                        dr["daily_Wage"] = cls_Formater.FormatDecimal(dDaily_Wage, 2);
                        dr["attendance_Allowance"] = cls_Formater.FormatDecimal(dAttendance_Allowance, 2);
                        dr["meal_Allowance"] = cls_Formater.FormatDecimal(dMeal_Allowance, 2);
                        dr["other_Allowance"] = cls_Formater.FormatDecimal(dOther_Allowance, 2);
                        dr["sOT_Amount"] = cls_Formater.FormatDecimal(dSOT_Amount, 2);
                        dr["dOT_Amount"] = cls_Formater.FormatDecimal(dDOT_Amount, 2);
                        dr["tOT_Amount"] = cls_Formater.FormatDecimal(dTOT_Amount, 2);

                        dr["rowBackColor"] = sRowBackColor;
                        dr["foreground"] = foreground;
                        dgr_Main.dt.Rows.Add(dr);
                        #endregion

                        if (!bDailyWorkesWageSavedRow)
                            UpdateGridRow(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            finally
            {
                dgr_Main.RefreshGrid();
                this.Cursor = Cursors.Arrow;
            }
        }

        #endregion

        #region Search Events
        private void txtEmpNo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                sp_genMasEmployee oEmployee = sp_genMasEmployee.Select(lstResult[0]);
                if (oEmployee != null)
                {
                    txtEmpNo.Tag = oEmployee.Employee_ID;
                    txtEmpNo.Text = oEmployee.Employee_ID + " - " + oEmployee.FullName;

                    txtSection.Tag = oEmployee.SectionID;
                    txtSection.Text = oEmployee.Section_Name;
                }
            }
        }

        private void txtSection_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Sections);
            if (RowDataSearch.DialogResult == true)
            {
                txtSection.Text = lstResult[0] + "-" + lstResult[1];
                txtSection.Tag = lstResult[0];
            }
        }

        private void txtWeek_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.HRWeek);
            if (RowDataSearch.DialogResult == true)
            {
                txtWeek.ToolTip = lstResult[0];
                txtWeek.Tag = lstResult[1];
                txtWeek.Text = "Week " + lstResult[1];

                dtp_FromDate.SetTime(DateTime.Parse(lstResult[2]).Date);
                dtp_toDate.SetTime(DateTime.Parse(lstResult[3]).Date);
            }
        }
        #endregion

        #region Grid Events
        private void dgr_Main_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int iColumnIndex = e.Column.DisplayIndex;
            int irowID = dgr_Main.SelectedIndex;
            TextBox t;

            #region Validate Allowance 

            if (iColumnIndex >= 17)
            {
                t = e.EditingElement as TextBox;
                decimal dAmt = 0m;

                try
                {
                    dAmt = decimal.Parse(t.Text);
                }
                catch (Exception)
                {
                    SEACCMessageBox.Show("Oops..!", "Please enter numeric value", MessageBoxButton.OK);
                }
                t.Text = cls_Formater.FormatDecimal(dAmt, 2);
            }
            #endregion
        }

        private void dgr_Main_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            try
            {
                string sBackground = ((System.Data.DataRowView)(e.Row.DataContext)).Row.ItemArray[dgr_Main.dt.Columns.Count - 2].ToString();
                string sforeground = ((System.Data.DataRowView)(e.Row.DataContext)).Row.ItemArray[dgr_Main.dt.Columns.Count - 1].ToString();
                e.Row.Background = (Brush)bc.ConvertFrom(sBackground);
                e.Row.Foreground = (Brush)bc.ConvertFrom(sforeground);
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {

        }

        private void dgr_Main_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
        #endregion

        #region Help Methods
        private void UpdateGridRow(DataRow datarow)
        {
            string sDaily_Wage = "0.00", sAttendance_Allowance = "0.00", sMeal_Allowance = txtDailyMealAllowance.Text, sOther_Allowance = txtDailyOtherAllowance.Text;
            string sSOT_Amount = "0.00", sDOT_Amount = "0.00", sTOT_Amount = "0.00";

            string sDayType = datarow["day"].ToString();

            DateTime dtmShiftStart = clsValidation.Validate_DateTime(datarow["Shift_StartTime"].ToString());
            DateTime dtmShiftEnd = clsValidation.Validate_DateTime(datarow["Shift_EndTime"].ToString());
            DateTime dtmTimeIn = clsValidation.Merge_DateAndTime(clsValidation.Validate_DateTime(datarow["attendenceDate"].ToString()), clsValidation.Validate_DateTime(datarow["InTime_E"].ToString()));
            DateTime dtmTimeOut = clsValidation.Merge_DateAndTime(clsValidation.Validate_DateTime(datarow["attendenceDate"].ToString()), clsValidation.Validate_DateTime(datarow["OutTime_E"].ToString()));

            int iShiftMinutes = int.Parse(datarow["Shift_Minutes"].ToString());
            int iWorkedMinutes = int.Parse(datarow["Worked_Minutes"].ToString());
            int iSOT_Minutes = int.Parse(datarow["sOT_Minutes"].ToString());
            int iDOT_Minutes = int.Parse(datarow["dOT_Minutes"].ToString());
            int iTOT_Minutes = int.Parse(datarow["tOT_Minutes"].ToString());

            if (iWorkedMinutes > 0 && sDayType != "Sunday" && sDayType != "Holiday")
            {
                if (iShiftMinutes <= iWorkedMinutes)
                    sDaily_Wage = cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(txtDailyWage.Text), 2); ;

                if (dtmShiftStart >= dtmTimeIn)
                    sAttendance_Allowance = cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(txtAttendanceAllowance.Text), 2);
            }

            sSOT_Amount = cls_Formater.FormatDecimal((iSOT_Minutes / 15) * 25, 2);
            sDOT_Amount = cls_Formater.FormatDecimal((iDOT_Minutes / 15) * 37.5m, 2);
            sTOT_Amount = cls_Formater.FormatDecimal((iDOT_Minutes / 15) * 50, 2);

            datarow["daily_Wage"] = sDaily_Wage;
            datarow["attendance_Allowance"] = sAttendance_Allowance;
            datarow["meal_Allowance"] = sMeal_Allowance;
            datarow["other_Allowance"] = sOther_Allowance;
            datarow["sOT_Amount"] = sSOT_Amount;
            datarow["dOT_Amount"] = sDOT_Amount;
            datarow["tOT_Amount"] = sTOT_Amount;
        }
        #endregion
    }
}
