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
    /// Interaction logic for UC_CoconutWashingDailyEntry.xaml
    /// </summary>
    public partial class UC_CoconutWashingDailyEntry : UserControl
    {
        #region Form Load
        public UC_CoconutWashingDailyEntry()
        {
            #region Initialize User control
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.CoconutWashingDailyEntry;
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

            dgr_Main.dt.Columns.Add("isCoconutWashed", typeof(bool));

            dgr_Main.dt.Columns.Add("nutCount");
            dgr_Main.dt.Columns.Add("washing_Allowance");
            dgr_Main.dt.Columns.Add("attendance_Allowance");
            dgr_Main.dt.Columns.Add("budgetary_Allowance");

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
            dgr_Main.Add_DatagridColoumn("Shift Start", "Shift_StartTime", 50, false);
            dgr_Main.Add_DatagridColoumn("Shift End", "Shift_EndTime", 50, false);

            dgr_Main.Add_DatagridColoumn("InDateTime_ID", "inDateTime_ID_E", 80, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "In Time", "inTime_E", 45, true, true);
            dgr_Main.Add_DatagridColoumn("OutDateTime_ID", "outDateTime_ID_E", 80, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Out Time", "outTime_E", 45, true, true);
            dgr_Main.Add_DatagridColoumn("Attendence", "attendence", 70);
            dgr_Main.Add_DatagridColoumn("Attendence Index", "attendence_index", 70, false);

            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Washed", "isCoconutWashed", 55, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Nuts", "nutCount", 65, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Wash Allo.", "washing_Allowance", 65, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Atten. Allo.", "attendance_Allowance", 65, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Budg. Allo.", "budgetary_Allowance", 65, true, false);
            #endregion

            dgr_Main.RefreshGrid();
            ClearFields();
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            dgr_Main.dt.Clear();

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmpNo, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtWeek, true, false, false);

            txtEmpNo.Tag = null;
            txtSection.Tag = null;
            txtWeek.Tag = null;

            txtEmpNo.Text = "<All Employees>";
            txtSection.Text = "<All Sections>";
            txtWeek.Text = "-";

            dtp_FromDate.SetTime(DateTime.Now);
            dtp_toDate.SetTime(DateTime.Now);
        }
        #endregion

        #region Action Button
        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        void btn_Print_Click(object sender, RoutedEventArgs e)
        {

        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        void btn_Save_Click(object sender, RoutedEventArgs e)
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
                    //string sEmployee_ID = row["employee_ID"].ToString();
                    //string sEmployee_Name = row["employee_Name"].ToString();
                    tbl_hrPeriod_Week oWeek = tbl_hrPeriod_Week.SelectAll().Where(r => r.StartDate.Date <= dtmAttendanceDate && r.EndDate >= dtmAttendanceDate).FirstOrDefault();
                    if (oWeek != null)
                        iOldRecCount += tbl_ccTxEndOfWeekWashingProgress.SelectAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID(clsSecurity.CompanyID, clsSecurity.BranchID, oWeek.Year_ID, oWeek.Week_ID).Count;

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
                        bool bIsWashed = bool.Parse(row["isCoconutWashed"].ToString());

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
                        decimal dWashing_Nuts = clsValidation.Validate_DecimalNumber(row["nutCount"].ToString());
                        decimal dWashing_Allo = clsValidation.Validate_DecimalNumber(row["washing_Allowance"].ToString());
                        decimal dAtten_Allo = clsValidation.Validate_DecimalNumber(row["attendance_Allowance"].ToString());
                        decimal dBudgetay_All = clsValidation.Validate_DecimalNumber(row["budgetary_Allowance"].ToString());
                        #endregion

                        #region Remove or change old data
                        tbl_hrPeriod_Week oWeek = tbl_hrPeriod_Week.SelectAll().Where(r => r.StartDate.Date <= dtmAttendanceDate && r.EndDate >= dtmAttendanceDate).FirstOrDefault();
                        foreach (tbl_ccTxEndOfWeekWashingProgress rec in tbl_ccTxEndOfWeekWashingProgress.SelectAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID(clsSecurity.CompanyID, clsSecurity.BranchID, oWeek.Year_ID, oWeek.Week_ID))
                            rec.Delete();
                        foreach (tbl_ccTxDailyWashingProgress oDrec in tbl_ccTxDailyWashingProgress.SelectAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID(clsSecurity.CompanyID, clsSecurity.BranchID, oWeek.Year_ID, oWeek.Week_ID))
                        {
                            //oDrec.Qty_Total = 0;
                            oDrec.Employee_Count_Total = 0;
                            oDrec.Rate = 0;
                            oDrec.Earn_Total = 0;
                            oDrec.Update();
                        }
                        #endregion

                        #region Update/Insert record
                        tbl_ccTxDailyWashingProgress oldRecord = tbl_ccTxDailyWashingProgress.Select(clsSecurity.CompanyID, clsSecurity.BranchID, iAttendanceIndex);
                        if (oldRecord != null)
                        {
                            //   if (!oldRecord.IsLocked) { 

                            tbl_ccTxDailyWashingProgress detail = new tbl_ccTxDailyWashingProgress(
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
                                bIsWashed, //isCoconutWashed
                                dWashing_Allo, //washing_Allo
                                dAtten_Allo, // attendance_Allo
                                dBudgetay_All, //budgetary_Allo
                                0, //other_Allo
                                dWashing_Nuts, //qty_Total
                                0, //employee_Count_Total
                                0, //rate
                                0, //earn_Total
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
                            if (!bIsWashed)
                                continue;

                            tbl_ccTxDailyWashingProgress detail = new tbl_ccTxDailyWashingProgress(
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
                                bIsWashed, //isCoconutWashed
                                dWashing_Allo, //washing_Allo
                                dAtten_Allo, // attendance_Allo
                                dBudgetay_All, //budgetary_Allo
                                0, //other_Allo
                                dWashing_Nuts, //qty_Total
                                0, //employee_Count_Total
                                0, //rate
                                0, //earn_Total
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

                #region Filter
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

                        int iShiftMinutes = 0, iShiftMinutes_Min = 0, iNextShift_Minutes = 0, iShiftGracePeriod = 0;
                        int iInDateTime_ID = 0, iOutDateTime_ID = 0;
                        int iAttendanceIndex = -1;

                        String sDayType = "Work";

                        string sShiftStart = "-", sShiftEnd = "-";
                        string sShiftId = "", sShiftName = "";
                        string sAttendanceStatus = "Not Saved";
                        ShiftTypes enmShiftType = ShiftTypes.OneDayShift;

                        holidayDurationType hdt = holidayDurationType.N_A;

                        String sRowBackColor = "#FF34495E";
                        string foreground = "white";

                        decimal dWashedNuts = 0, dWashingAllowance = 0, dAttendanceAllowance = 0, dBudgetaryAllowance = 0;
                        bool bIsAttendancerecord = false;
                        bool bWashed = false;

                        #endregion

                        #region get Holydays And format rows
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
                        tbl_ccTxDailyWashingProgress oRecod = tbl_ccTxDailyWashingProgress.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, oEmployee.Employee_ID).Where(r => r.AttendenceDate.Date == dDate.Date).FirstOrDefault();
                        if (oRecod != null)
                        {
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

                            bWashed = oRecod.IsCoconutWashed;
                            dWashedNuts = oRecod.Qty_Total;
                            dWashingAllowance = oRecod.Washing_Allo;
                            dAttendanceAllowance = oRecod.Attendance_Allo;
                            dBudgetaryAllowance = oRecod.Budgetary_Allo;
                        }
                        #endregion

                        #region Add new data
                        else
                        {
                            tbl_tasTxDailyAttendance oAtten = tbl_tasTxDailyAttendance.SelectAllBy_EmployeeIDWithDateRange(oEmployee.Employee_ID, dDate.Date, dDate.Date).FirstOrDefault();
                            if (oAtten != null)
                            {
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
                            }
                        }
                        #endregion

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

                        dr["isCoconutWashed"] = bWashed;
                        dr["nutCount"] = cls_Formater.FormatDecimal(dWashedNuts, 0);
                        dr["washing_Allowance"] = cls_Formater.FormatDecimal(dWashingAllowance, 2);
                        dr["attendance_Allowance"] = cls_Formater.FormatDecimal(dAttendanceAllowance, 2);
                        dr["budgetary_Allowance"] = cls_Formater.FormatDecimal(dBudgetaryAllowance, 2);

                        dr["rowBackColor"] = sRowBackColor;
                        dr["foreground"] = foreground;
                        dgr_Main.dt.Rows.Add(dr);
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

        #region Check validity
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;
            if (!clsValidation.Validate_EmptyValue(txtEmpNo))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtWeek))
                bStatus = false;
            return bStatus;
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
        private void dgr_Main_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //int irowID = dgr_Main.SelectedIndex;
            //var vDG_Cell = dgr_Main.GetCurrentCell();
            //if (vDG_Cell.Column.SortMemberPath == "isCoconutWashed")
            //{
            //    if (bool.Parse(dgr_Main.dt.Rows[irowID]["isCoconutWashed"].ToString()) == false)
            //    {
            //        dgr_Main.dt.Rows[irowID]["isCoconutWashed"] = true;
            //        dgr_Main.dt.Rows[irowID]["washing_Allowance"] = cls_Formater.FormatDecimal(50, 2);
            //        dgr_Main.dt.Rows[irowID]["budgetary_Allowance"] = cls_Formater.FormatDecimal(40, 2);
            //        dgr_Main.dt.Rows[irowID]["attendance_Allowance"] = cls_Formater.FormatDecimal(0, 2);

            //        string sIntime = dgr_Main.dt.Rows[irowID]["inTime_E"].ToString();
            //        if (sIntime.Trim() != "-")
            //        {
            //            DateTime dtmInTime = clsValidation.Merge_DateAndTime(clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["attendenceDate"].ToString()), clsValidation.Validate_DateTime(sIntime));
            //            DateTime dtmInTime_Cutoff = clsValidation.Merge_DateAndTime(clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["attendenceDate"].ToString()), clsValidation.Validate_DateTime("06:00"));
            //            dgr_Main.dt.Rows[irowID]["attendance_Allowance"] = dtmInTime <= dtmInTime_Cutoff ? cls_Formater.FormatDecimal(100, 2) : cls_Formater.FormatDecimal(0, 2);
            //        }
            //    }

            //}
            //dgr_Main.RefreshGrid();
        }
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            int irowID = dgr_Main.SelectedIndex;
            var vDG_Cell = dgr_Main.GetCurrentCell();

            #region Update Employee Viewer
            try
            {
                exp_More.IsExpanded = true;
                exp_Selection.IsExpanded = false;

                EmployeeViewer.ClearFields();
                LeaveViewer.ClearFields();

                string sEmployeeid = dgr_Main.dt.Rows[irowID]["employee_ID"].ToString();
                string sDayType = dgr_Main.dt.Rows[irowID]["day"].ToString();
                DateTime dtmAttendencedate = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["attendenceDate"].ToString());

                WJDate.SetTime(dtmAttendencedate, sDayType);

                if (sEmployeeid != null && sEmployeeid != "")
                {
                    EmployeeViewer.setEmployeeDetail(sEmployeeid);

                    if (dtmAttendencedate != null && dtmAttendencedate != clsConfig.defaultDateTime)
                    {
                        LeaveViewer.Refresh(sEmployeeid, dtmAttendencedate);
                    }

                    DateTime dtmAttendenceDate = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["attendenceDate"].ToString());
                    string sEmployeeID = dgr_Main.dt.Rows[irowID]["employee_ID"].ToString();
                    UC_Devicerawdata.RefrshGrid(sEmployeeID, dtmAttendenceDate);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            #endregion

            try
            {
                if (vDG_Cell.Column.SortMemberPath == "isCoconutWashed")
                {
                    if (bool.Parse(dgr_Main.dt.Rows[irowID]["isCoconutWashed"].ToString()) == false)
                    {
                        dgr_Main.dt.Rows[irowID]["isCoconutWashed"] = true;
                        dgr_Main.dt.Rows[irowID]["washing_Allowance"] = cls_Formater.FormatDecimal(50, 2);
                        dgr_Main.dt.Rows[irowID]["budgetary_Allowance"] = cls_Formater.FormatDecimal(40, 2);
                        dgr_Main.dt.Rows[irowID]["attendance_Allowance"] = cls_Formater.FormatDecimal(0, 2);

                        string sIntime = dgr_Main.dt.Rows[irowID]["inTime_E"].ToString();
                        if (sIntime.Trim() != "-")
                        {
                            DateTime dtmInTime = clsValidation.Merge_DateAndTime(clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["attendenceDate"].ToString()), clsValidation.Validate_DateTime(sIntime));
                            DateTime dtmInTime_Cutoff = clsValidation.Merge_DateAndTime(clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["attendenceDate"].ToString()), clsValidation.Validate_DateTime("06:00"));
                            dgr_Main.dt.Rows[irowID]["attendance_Allowance"] = dtmInTime <= dtmInTime_Cutoff ? cls_Formater.FormatDecimal(100, 2) : cls_Formater.FormatDecimal(0, 2);
                        }
                    }
                    else
                    {
                        dgr_Main.dt.Rows[irowID]["isCoconutWashed"] = false;
                        dgr_Main.dt.Rows[irowID]["nutCount"] = cls_Formater.FormatDecimal(0, 0);
                        dgr_Main.dt.Rows[irowID]["washing_Allowance"] = cls_Formater.FormatDecimal(0, 2);
                        dgr_Main.dt.Rows[irowID]["budgetary_Allowance"] = cls_Formater.FormatDecimal(0, 2);
                        dgr_Main.dt.Rows[irowID]["attendance_Allowance"] = cls_Formater.FormatDecimal(0, 2);
                    }
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception)
            { }
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
        private void dgr_Main_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int iColumnIndex = e.Column.DisplayIndex;
            int irowID = dgr_Main.SelectedIndex;
            TextBox t;

            #region Validate Nuts counts & Travelling Allowance 

            if (iColumnIndex == 17 || iColumnIndex == 18 || iColumnIndex == 19 || iColumnIndex == 20)
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

                if (iColumnIndex == 17)
                    t.Text = cls_Formater.FormatDecimal(dAmt, 0);
                else
                    t.Text = cls_Formater.FormatDecimal(dAmt, 2);

            }
            #endregion
        }
        #endregion

        #region Help Methods
        private void updateRow(bool isAttendaceRecord, int irowID, int intime_index, DateTime dtmTimeIn, int outTime_index, DateTime dtmTimeOut, DateTime dtmShiftStart)
        {
            string sAttendanceStatus = "-";

            if (isAttendaceRecord)
            {
                dtmTimeIn = clsValidation.Merge_DateAndTime(dtmShiftStart, dtmTimeIn);
                dtmTimeOut = clsValidation.Merge_DateAndTime(dtmShiftStart, dtmTimeOut);

                #region Shift Working Hours
                //if (dtmTimeOut == clsConfig.defaultDateTime && dtmTimeIn == clsConfig.defaultDateTime)
                if (outTime_index == 0 && intime_index == 0)
                {
                    //both times missing
                    sAttendanceStatus = "Absent";
                }
                else if (dtmTimeOut == clsConfig.defaultDateTime || dtmTimeIn == clsConfig.defaultDateTime)
                {
                    //only one time missing
                    sAttendanceStatus = "ERROR";
                }
                else
                {
                    if (dtmTimeIn <= dtmShiftStart)
                        sAttendanceStatus = "Present";
                    else
                        sAttendanceStatus = "Late";
                }
                #endregion
            }
            else
                sAttendanceStatus = "Not Save";

            dgr_Main.dt.Rows[irowID]["attendence"] = sAttendanceStatus;
        }
        #endregion

    }
}
