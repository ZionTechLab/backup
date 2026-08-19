using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DataTire;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using CrystalDecisions.CrystalReports.Engine;
using System.IO.Ports;
using System.Threading;
using System.Text.RegularExpressions;
using Digiteq_Logic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using SEACC_WPFControls;
using System.Reflection;

namespace Digiteq
{
    class clsHelpMethods
    {
        #region Security Help Methods

        #region Get Host Name
        public static string GetHostName()
        {
            string macAddresses = Dns.GetHostName();
            return macAddresses;
        }
        #endregion

        #region Get Mac Address
        public static string GetMacAddress()
        {
            string macAddresses = "";

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            return macAddresses;
        }
        #endregion

        #region Get IP Address
        public static string GetIPAddress()
        {
            string sIPAddress = "";
            try
            {
                System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();

                // Get server related information.
                IPHostEntry heserver = Dns.GetHostEntry(GetHostName());

                // Loop on the AddressList
                foreach (IPAddress curAdd in heserver.AddressList)
                {
                    if (CheckValidityIPAddress(curAdd.ToString()))
                    {
                        sIPAddress = curAdd.ToString();
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[DoResolve] Exception: " + e.ToString());
            }
            return sIPAddress;
        }

        public static bool CheckValidityIPAddress(string sIPAddress)
        {
            //create our match pattern
            string pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
            //create our Regular Expression object
            Regex check = new Regex(pattern);
            //boolean variable to hold the status
            bool valid = false;
            //check to make sure an ip address was provided
            if (sIPAddress == "")
            {
                //no address provided so return false
                valid = false;
            }
            else
            {
                //address provided so use the IsMatch Method
                //of the Regular Expression object
                valid = check.IsMatch(sIPAddress, 0);
            }
            //return the results
            return valid;
        }
        #endregion

        #endregion

        #region User Interfaces, Grids Help Methods

        public static void SetSelectedIndexUsingCellValue(DataGrid dgGrid, int icolumn, string sValue)
        {
            for (int i = 0; i < dgGrid.Items.Count; i++)
            {
                dgGrid.ScrollIntoView(dgGrid.Items[i]);
                DataGridRow row = (DataGridRow)dgGrid.ItemContainerGenerator.ContainerFromIndex(i);
                TextBlock cellContent = dgGrid.Columns[icolumn].GetCellContent(row) as TextBlock;
                if (cellContent != null && cellContent.Text.Trim().Equals(sValue))
                {
                    object item = dgGrid.Items[i];
                    dgGrid.SelectedItem = item;
                    dgGrid.ScrollIntoView(item);
                    row.MoveFocus(new System.Windows.Input.TraversalRequest(System.Windows.Input.FocusNavigationDirection.Next));
                    break;
                }
            }
        }

        public static DateTime Merge_DateAndTime(DateTime Date, DateTime Time)
        {
            DateTime Value = clsConfig.defaultDateTime;
            try
            {
                if (Date != clsConfig.defaultDateTime && Time != clsConfig.defaultDateTime)
                    Value = new DateTime(Date.Year, Date.Month, Date.Day, Time.Hour, Time.Minute, Time.Second);
            }
            catch (Exception)
            {
            }
            return Value;
        }

        #endregion

        #region Employee Shift
        public static void GetShift(DateTime dDate, string Employee_ID, bool isRosterBasedEmployee, holidayDurationType hdt, ref string sShiftId, ref string sShiftName, ref ShiftTypes enmShiftType, ref int iShiftDay, ref string sPriviusShift, ref bool bShiftSpecialParameeter1, ref bool bShiftSpecialParameeter2, ref int iShiftMinutes, ref int iShiftMinutes_Min, ref int iNextShift_Minutes, ref int iShiftGracePeriod, ref DateTime dtmShiftStart, ref DateTime dtmShiftEnd, ref string sShiftStart, ref string sShiftEnd)
        {
            #region Shift
            DataTable dtResult_Table = new DataTable();
            if (isRosterBasedEmployee)
                dtResult_Table = DBHandling.ExecQuery("SELECT TOP (1) r.employee_ID, r.rosterDate, r.shift_ID, s.shift_Name, s.shiftStartTime, s.shiftMinutes FROM tbl_tasTxEmployeeRoster AS r LEFT OUTER JOIN tbl_tasShiftMaster AS s ON r.shift_ID = s.shift_ID WHERE (r.rosterDate <= '" + dDate.Date.ToString("yyyy-MM-dd") + "') AND (r.employee_ID = '" + Employee_ID + "') AND (r.isCanceled = 0) ORDER BY r.rosterDate DESC").Tables[0];
            else
                dtResult_Table = DBHandling.ExecQuery("SELECT TOP 1 ES.employee_ID, ES.effectiveFrom_Date, ES.shift_ID, S.shift_Name, S.shiftStartTime, S.shiftMinutes FROM tbl_tasMasEmployeeShift AS ES LEFT OUTER JOIN tbl_tasShiftMaster AS S ON ES.shift_ID = S.shift_ID  where ES.effectiveFrom_Date<='" + dDate.Date.ToString("yyyy-MM-dd") + "' AND ES.employee_ID = '" + Employee_ID + "' AND ES.isCanceled = 0 order by ES.effectiveFrom_Date DESC").Tables[0];

            if (dtResult_Table != null && dtResult_Table.Rows.Count > 0)
            {
                sShiftId = dtResult_Table.Rows[0]["shift_ID"].ToString();

                tbl_tasShiftMaster oShift = tbl_tasShiftMaster.Select(sShiftId, clsSecurity.CompanyID, clsSecurity.BranchID);
                if (oShift != null)
                    if (oShift.Shift_ID != "default")
                    {
                        sShiftName = oShift.Shift_Name;
                        enmShiftType = (ShiftTypes)oShift.ShiftType;

                        #region Update Shift day
                        switch ((ShiftTypes)oShift.ShiftType)
                        {
                            case ShiftTypes.MidnightCross:
                            case ShiftTypes.OneDayShift:
                                iShiftDay = 1;
                                break;
                            case ShiftTypes.TwoDayShift:
                                {
                                    if (sPriviusShift != sShiftId)
                                        iShiftDay = 1;
                                    else
                                    {
                                        if (iShiftDay == 1)
                                            iShiftDay = 2;
                                        else
                                            iShiftDay = 1;
                                    }
                                }
                                break;
                            case ShiftTypes.FlexibalShift:
                                break;
                            default:
                                break;
                        }
                        sPriviusShift = sShiftId;
                        #endregion

                        #region shift rules
                        bShiftSpecialParameeter1 = false; bShiftSpecialParameeter2 = false;
                        iShiftMinutes = oShift.ShiftMinutes;
                        iShiftMinutes_Min = oShift.ShiftMinutesMin;
                        iNextShift_Minutes = oShift.NextShiftMinutes;
                        iShiftGracePeriod = oShift.ShiftGracePeriod;

                        #region shift rules - Day Of Week

                        #region Monday

                        if (dDate.DayOfWeek == DayOfWeek.Monday && oShift.IsMondaySpecialWH)
                        {
                            iShiftMinutes = oShift.ShiftMinutes_Monday;
                            iShiftMinutes_Min = oShift.ShiftMinutesMin_Monday;
                            iNextShift_Minutes = oShift.NextShiftMinutes_Monday;
                            iShiftGracePeriod = oShift.ShiftMinutesMin_Monday;
                            bShiftSpecialParameeter1 = oShift.BSpecialParameter1_Monday;
                            bShiftSpecialParameeter2 = oShift.BSpecialParameter2_Monday;
                        }
                        #endregion

                        #region Tuesday
                        else if (dDate.DayOfWeek == DayOfWeek.Tuesday && oShift.IsTuesdaySpecialWH)
                        {
                            iShiftMinutes = oShift.ShiftMinutes_Tuesday;
                            iShiftMinutes_Min = oShift.ShiftMinutesMin_Tuesday;
                            iNextShift_Minutes = oShift.NextShiftMinutes_Tuesday;
                            iShiftGracePeriod = oShift.ShiftMinutesMin_Tuesday;
                            bShiftSpecialParameeter1 = oShift.BSpecialParameter1_Tuesday;
                            bShiftSpecialParameeter2 = oShift.BSpecialParameter2_Tuesday;
                        }
                        #endregion

                        #region Wednesday
                        else if (dDate.DayOfWeek == DayOfWeek.Wednesday && oShift.IsWednesdaySpecialWH)
                        {
                            iShiftMinutes = oShift.ShiftMinutes_Wednesday;
                            iShiftMinutes_Min = oShift.ShiftMinutesMin_Wednesday;
                            iNextShift_Minutes = oShift.NextShiftMinutes_Wednesday;
                            iShiftGracePeriod = oShift.ShiftMinutesMin_Wednesday;
                            bShiftSpecialParameeter1 = oShift.BSpecialParameter1_Wednesday;
                            bShiftSpecialParameeter2 = oShift.BSpecialParameter2_Wednesday;
                        }
                        #endregion

                        #region Thursday
                        else if (dDate.DayOfWeek == DayOfWeek.Thursday && oShift.IsThursdaySpecialWH)
                        {
                            iShiftMinutes = oShift.ShiftMinutes_Thursday;
                            iShiftMinutes_Min = oShift.ShiftMinutesMin_Thursday;
                            iNextShift_Minutes = oShift.NextShiftMinutes_Thursday;
                            iShiftGracePeriod = oShift.ShiftMinutesMin_Thursday;
                            bShiftSpecialParameeter1 = oShift.BSpecialParameter1_Thursday;
                            bShiftSpecialParameeter2 = oShift.BSpecialParameter2_Thursday;
                        }
                        #endregion

                        #region Friday
                        else if (dDate.DayOfWeek == DayOfWeek.Friday && oShift.IsFridaySpecialWH)
                        {
                            iShiftMinutes = oShift.ShiftMinutes_Friday;
                            iShiftMinutes_Min = oShift.ShiftMinutesMin_Friday;
                            iNextShift_Minutes = oShift.NextShiftMinutes_Friday;
                            iShiftGracePeriod = oShift.ShiftMinutesMin_Friday;
                            bShiftSpecialParameeter1 = oShift.BSpecialParameter1_Friday;
                            bShiftSpecialParameeter2 = oShift.BSpecialParameter2_Friday;
                        }
                        #endregion

                        #region Saturday
                        else if (dDate.DayOfWeek == DayOfWeek.Saturday && oShift.IsSaturdaySpecialWH)
                        {
                            iShiftMinutes = oShift.ShiftMinutes_Saturday;
                            iShiftMinutes_Min = oShift.ShiftMinutesMin_Saturday;
                            iNextShift_Minutes = oShift.NextShiftMinutes_Saturday;
                            iShiftGracePeriod = oShift.ShiftMinutesMin_Saturday;
                            bShiftSpecialParameeter1 = oShift.BSpecialParameter1_Saturday;
                            bShiftSpecialParameeter2 = oShift.BSpecialParameter2_Saturday;
                        }
                        #endregion

                        #region Sunday

                        else if (dDate.DayOfWeek == DayOfWeek.Sunday && oShift.IsSundaySpecialWH)
                        {
                            iShiftMinutes = oShift.ShiftMinutes_Sunday;
                            iShiftMinutes_Min = oShift.ShiftMinutesMin_Sunday;
                            iNextShift_Minutes = oShift.NextShiftMinutes_Sunday;
                            iShiftGracePeriod = oShift.ShiftMinutesMin_Sunday;
                            bShiftSpecialParameeter1 = oShift.BSpecialParameter1_Sunday;
                            bShiftSpecialParameeter2 = oShift.BSpecialParameter2_Sunday;
                        }
                        #endregion

                        #endregion

                        if (iShiftDay != 1)
                            dtmShiftStart = Merge_DateAndTime(dDate.AddDays(-iShiftDay + 1), oShift.ShiftStartTime);
                        else
                            dtmShiftStart = Merge_DateAndTime(dDate, oShift.ShiftStartTime);

                        #region shift rules - holiday
                        switch (hdt)
                        {
                            case holidayDurationType.N_A:
                                break;
                            case holidayDurationType.FullDay:
                                {
                                    iShiftMinutes = 0;
                                    iShiftMinutes_Min = 0;
                                    iShiftGracePeriod = 0;
                                }
                                break;
                            case holidayDurationType.HalfDay_Morning:
                                {
                                    dtmShiftStart = dtmShiftStart.AddMinutes(270);
                                    iShiftMinutes -= 270;
                                    iShiftMinutes_Min -= 270;
                                }
                                break;
                            case holidayDurationType.HalfDay_Evening:
                                {
                                    iShiftMinutes -= 270;
                                    iShiftMinutes_Min -= 270;
                                    // iShiftGracePeriod = 0;
                                }
                                break;
                            case holidayDurationType.ShortHoliday:
                                break;
                            case holidayDurationType.Other:
                                break;
                        }
                        #endregion

                        if (iShiftMinutes > 0)
                            dtmShiftEnd = dtmShiftStart.AddMinutes(iShiftMinutes);

                        #region shift rules - set Start date / End date
                        switch ((ShiftTypes)oShift.ShiftType)
                        {
                            case ShiftTypes.MidnightCross:
                            case ShiftTypes.OneDayShift:
                                {
                                    sShiftStart = iShiftMinutes == 0 ? "N/A" : dtmShiftStart.ToString(clsConfig.Format_DateTime);
                                    sShiftEnd = iShiftMinutes == 0 ? "N/A" : dtmShiftEnd.ToString(clsConfig.Format_DateTime);
                                }
                                break;
                            case ShiftTypes.TwoDayShift:
                                {
                                    if (iShiftDay == 1)
                                    {
                                        sShiftStart = dtmShiftStart.ToString(clsConfig.Format_DateTime);
                                        sShiftEnd = "~";
                                        dtmShiftEnd = clsConfig.defaultDateTime;

                                        //TimeSpan tsShiftMinutes = dtmShiftStart.Date.AddHours(24) - dtmShiftStart;
                                        //iShiftMinutes = (int)tsShiftMinutes.TotalMinutes;
                                    }
                                    else
                                    {
                                        sShiftStart = "~";
                                        sShiftEnd = dtmShiftStart.AddMinutes(oShift.ShiftMinutes).ToString(clsConfig.Format_DateTime);   // dtmShiftEnd.ToString(clsConfig.Format_DateTime);
                                        dtmShiftStart = clsConfig.defaultDateTime;

                                        //TimeSpan tsShiftMinutes = dtmShiftEnd - dtmShiftEnd.Date; 
                                        //iShiftMinutes = (int)tsShiftMinutes.TotalMinutes;
                                    }
                                }
                                break;
                            case ShiftTypes.FlexibalShift:
                                {
                                    sShiftStart = "~";
                                    sShiftEnd = "~";
                                }
                                break;
                            default:
                                break;
                        }
                        #endregion
                        #endregion
                    }
            }
            #endregion
        }

        public static string GetShift(DateTime dDate, string Employee_ID, bool isRosterBasedEmployee)
        {
            #region Variables for Shift
            DateTime dtmMissPunchDateTime = clsConfig.defaultDateTime;
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
            #endregion

            int iYear = dDate.Year;
            DateTime dtmFromDate = new DateTime(iYear, 1, 1);
            DateTime dtmToDate = new DateTime(iYear, 12, 31);
            List<tbl_tasHolidayCalander> oHolidays = tbl_tasHolidayCalander.SelectAllByHolyday_Date(dtmFromDate.Date, dtmToDate.Date).Where(p => p.Holiday_Status).ToList();
            foreach (tbl_tasHolidayCalander oCal in oHolidays.Where(p => p.Holiday_Date.Date == dDate.Date && !p.IsCanceled))
            {
                hdt = (holidayDurationType)oCal.HolidayDurationType;
            }
            clsHelpMethods.GetShift(dDate, Employee_ID, isRosterBasedEmployee,  hdt, ref sShiftId, ref sShiftName, ref enmShiftType, ref iShiftDay, ref sPriviusShift, ref bShiftSpecialParameeter1, ref bShiftSpecialParameeter2, ref iShiftMinutes, ref iShiftMinutes_Min, ref iNextShift_Minutes, ref iShiftGracePeriod, ref dtmShiftStart, ref dtmShiftEnd, ref sShiftStart, ref sShiftEnd);

            return sShiftId;
        }
        public static string[] getEmpShiftDetails(string emp_ID, DateTime considerableDate, bool isRosterBasedEmployee)
        {
            string[] shiftDetails = new string[5] { "", "", "", "0", "0" };
            DataTable dtResult_Table = new DataTable();
            if (isRosterBasedEmployee)
                dtResult_Table = DBHandling.ExecQuery("SELECT TOP (1) r.shift_ID, s.shift_Name, s.shiftStartTime, s.shiftMinutes, s.shiftMinutesMin FROM tbl_tasTxEmployeeRoster AS r LEFT OUTER JOIN tbl_tasShiftMaster AS s ON r.shift_ID = s.shift_ID WHERE (r.rosterDate <= '" + considerableDate.Date.ToString("yyyy-MM-dd") + "') AND (r.employee_ID = '" + emp_ID + "') AND (r.isCanceled = 0) ORDER BY r.rosterDate DESC").Tables[0];
            else
                dtResult_Table = DBHandling.ExecQuery("SELECT TOP 1 ES.shift_ID, S.shift_Name, S.shiftStartTime, S.shiftMinutes, s.shiftMinutesMin FROM tbl_tasMasEmployeeShift AS ES LEFT OUTER JOIN tbl_tasShiftMaster AS S ON ES.shift_ID = S.shift_ID  where ES.effectiveFrom_Date<='" + considerableDate.Date.ToString("yyyy-MM-dd") + "' AND ES.employee_ID = '" + emp_ID + "' AND ES.isCanceled = 0 order by ES.effectiveFrom_Date DESC").Tables[0];

            if (dtResult_Table != null && dtResult_Table.Rows.Count > 0)
            {
                shiftDetails[0] = dtResult_Table.Rows[0]["shift_ID"].ToString();

                if (shiftDetails[0] != "" && dtResult_Table.Rows[0]["shiftMinutes"].ToString() != "")
                {
                    shiftDetails[1] = dtResult_Table.Rows[0]["shift_Name"].ToString();
                    shiftDetails[2] = dtResult_Table.Rows[0]["shiftStartTime"].ToString();
                    shiftDetails[3] = dtResult_Table.Rows[0]["shiftMinutes"].ToString();
                    shiftDetails[4] = dtResult_Table.Rows[0]["shiftMinutesMin"].ToString();
                }
            }
            return shiftDetails;
        }
        #endregion

        #region Employee Attendance
        public static decimal[] GetAttendanceDetails(string sEmployee_ID, DateTime startDate, DateTime endDate)
        {
            decimal[] dAttendanceData = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            DataTable dtResult_Table = DBHandling.ExecQuery("sp_getAttendanceData_DateRange '" + sEmployee_ID + "' , '" + startDate.Date.ToString() + "' , '" + endDate.Date.ToString() + "'").Tables[0];
            if (dtResult_Table != null && dtResult_Table.Rows.Count > 0)
            {
                dAttendanceData[0] = decimal.Parse(dtResult_Table.Rows[0]["shiftMinutes"].ToString());
                dAttendanceData[1] = decimal.Parse(dtResult_Table.Rows[0]["workedMinutes"].ToString());
                dAttendanceData[2] = decimal.Parse(dtResult_Table.Rows[0]["lateMinutesApproved"].ToString());
                dAttendanceData[3] = decimal.Parse(dtResult_Table.Rows[0]["noPayMinutesApproved"].ToString());
                dAttendanceData[4] = decimal.Parse(dtResult_Table.Rows[0]["oTMinutesApproved"].ToString());
                dAttendanceData[5] = decimal.Parse(dtResult_Table.Rows[0]["dOTMinutesApproved"].ToString());
                dAttendanceData[6] = decimal.Parse(dtResult_Table.Rows[0]["leaveMinutes"].ToString());
                dAttendanceData[7] = decimal.Parse(dtResult_Table.Rows[0]["gpMinutes"].ToString());

                //Newly Addred 0n 2017-08-28 by Gayan
                dAttendanceData[8] = decimal.Parse(dtResult_Table.Rows[0]["tOTMinutesApproved"].ToString());
            }
            return dAttendanceData;
        }
        public static decimal UpdateLates(string sEmpId, DateTime startDate, DateTime endDate)
        {
            int iPayrollPeriod_LateDays = 0;
            foreach (tbl_tasTxDailyAttendance attens in tbl_tasTxDailyAttendance.SelectAllBy_EmployeeIDWithDateRange(sEmpId, startDate.Date, endDate.Date).OrderBy(o => o.AttendenceDate))//Where(r => r.AttendenceDate.Date >= periodStartDate.Date && r.AttendenceDate <= periodEndDate.Date && r.Employee_ID == sEmpId)
            {
                if (attens.LateMinutesApproved > 0)
                {
                    iPayrollPeriod_LateDays++;
                }
            }

            return (decimal)iPayrollPeriod_LateDays;
        }

        public static void Validate_InOutTime_DataTable(ref DataTable dt)
        {
            if (dt.Rows.Count > 1)
            {
                int row_prv = 0;
                int row_count = 1;

                while (row_count < dt.Rows.Count)
                {
                    DateTime dtm_PrvRec = DateTime.Parse(dt.Rows[row_prv]["device_DateTime"].ToString());
                    DateTime dtm_Rec = DateTime.Parse(dt.Rows[row_count]["device_DateTime"].ToString());

                    TimeSpan tsDiff = dtm_Rec - dtm_PrvRec;
                    if (tsDiff.TotalMinutes < 2) //Check Finger print touch within 2 mins and keep one of them
                    {
                        dt.Rows[row_count].Delete();
                        dt.AcceptChanges();
                    }
                    else
                    {
                        row_prv++;
                        row_count++;
                    }
                }
            }
        }

        public static int GetYearID_ForGivenDate(DateTime dtmDate)
        {
            int iCurrentHRYear_ID = 0;
            tbl_hrPeriod_Year oYear = tbl_hrPeriod_Year.SelectAll().Where(r => r.Year_startDate.Date <= dtmDate.Date && r.Year_endDate >= dtmDate.Date).FirstOrDefault();
            if (oYear != null)
            {
                iCurrentHRYear_ID = oYear.Year_ID;
            }

            return iCurrentHRYear_ID;
        }

        public static decimal GetUtilized_Leave_Days(string sEmployee_ID, int iYear_ID, string sLeaveType, DateTime endDate)
        {
            decimal dUtilizedDays = 0;
            foreach (tbl_tasEmployeeLeaveCard oLeaveEntitle in tbl_tasEmployeeLeaveCard.SelectAll().Where(p => p.Employee_ID == sEmployee_ID && p.Year_ID == iYear_ID && p.LeaveType_ID == sLeaveType && p.Leave_Start <= endDate.Date))
            {
                dUtilizedDays += oLeaveEntitle.Leaves_Utilized;
            }
            return dUtilizedDays;
        }

        public static decimal GetLadiesNightShiftsDays(string sEmployee_ID, DateTime fromDate, DateTime toDate)
        {
            decimal dShiftDays = 0m;
            foreach (tbl_tasTxDailyAttendance oAttendance in tbl_tasTxDailyAttendance.SelectAllBy_EmployeeIDWithDateRange(sEmployee_ID, fromDate, toDate).Where(p => p.Shift_ID == clsConfig.sLadiesNightShift))
            {
                if (oAttendance.TimeIn_DateTime != clsConfig.defaultDateTime || oAttendance.TimeIn_DateTime != clsConfig.defaultDateTime)
                {
                    DateTime dtDay = oAttendance.TimeIn_DateTime.Date;
                    DateTime dtMidNight = dtDay.AddHours(24);
                    if (oAttendance.TimeOut_DateTime > dtMidNight)
                    {
                        dShiftDays++;
                    }
                }
            }
            return dShiftDays;
        }

        public static void GetNightShiftsDays(string sEmployee_ID, DateTime fromDate, DateTime toDate, ref decimal s24NightShiftsDays, ref decimal sNightShiftsDays)
        {
            string[] s24NightShifts = clsConfig.s24NightShifts.Trim().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] sNightShifts = clsConfig.sNightShifts.Trim().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (tbl_tasTxDailyAttendance oAttendance in tbl_tasTxDailyAttendance.SelectAllBy_EmployeeIDWithDateRange(sEmployee_ID, fromDate, toDate))
            {
                if (s24NightShifts.Contains(oAttendance.Shift_ID) && oAttendance.TimeIn_DateTime < oAttendance.ShiftStartTime.AddHours(24) && oAttendance.TimeIn_DateTime != clsConfig.defaultDateTime)
                {
                    s24NightShiftsDays++;
                }
                if (sNightShifts.Contains(oAttendance.Shift_ID))
                {
                    sNightShiftsDays++;
                }
            }
        }
        #endregion

        #region Payroll Help Methods

        #region From Master Tables
        //From Master Tables
        //These methods are useded before inserting data to transaction tables.

        #region Base Salary
        public static decimal GetBaseSalaryForNopay_FromMas(string empID)
        {
            decimal dBS = 0;

            //Nopay Applicable Salary Items are used to get base salary
            foreach (tbl_payMas_PaySlipItems oPSI in tbl_payMas_PaySlipItems.SelectAll().Where(p => p.IsNoPayable))
            {
                tbl_genMasEmployee_PaySlipItems oPobj_BS = tbl_genMasEmployee_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, empID, oPSI.PayItem_ID);
                if (oPobj_BS != null)
                    dBS += oPobj_BS.Rate;
            }
            return dBS;
        }

        public static decimal GetBaseSalary_FromMas(string empID)
        {
            decimal dBS = 0;
            foreach (tbl_genMasEmployee_PaySlipItems oPayItems in tbl_genMasEmployee_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, empID).Where(
                                                                                                                                                                                    r => r.PayItem_ID == clsConfig.sBasicSalary ||
                                                                                                                                                                                         r.PayItem_ID == clsConfig.sBasicSalaryIncrement1 ||
                                                                                                                                                                                         r.PayItem_ID == clsConfig.sBRA1 ||
                                                                                                                                                                                         r.PayItem_ID == clsConfig.sBRA2 ||
                                                                                                                                                                                         r.PayItem_ID == clsConfig.sBRA3)
                )
            {
                dBS += oPayItems.Rate;
            }

            return dBS;
        }

        #endregion

        #region Gross Salary
        public static decimal GetGrossSalary_FromMas(string empID)
        {
            decimal dGS = 0;
            foreach (tbl_genMasEmployee_PaySlipItems oItem in tbl_genMasEmployee_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, empID))
            {
                tbl_payMas_PaySlipItems oMItem = tbl_payMas_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oItem.PayItem_ID);
                if (oMItem != null && oMItem.IsEarning && !oMItem.IsCanceled)
                    dGS += oItem.Rate;
            }

            tbl_genMasEmployee_PaySlipItems pobj_NoPay = tbl_genMasEmployee_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, empID, clsConfig.sNopay);
            if (pobj_NoPay != null)
                dGS += pobj_NoPay.Rate;

            return dGS > 0 ? dGS : 0;
        }
        #endregion

        #region Payslip Item Amounts
        public static decimal GetPaySlipItemAmount_FromMas(string empID, string sPayslipItem_ID)
        {
            decimal dAllo = 0;
            tbl_genMasEmployee_PaySlipItems pobj_All1 = tbl_genMasEmployee_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, empID, sPayslipItem_ID);
            if (pobj_All1 != null)
                dAllo += pobj_All1.Rate;
            return dAllo;
        }
        #endregion

        #region PAYEE Amount Calculation
        public static decimal GetPAYE_Amout_FromMas(string empID)
        {
            decimal dPAYE_Amount = 0;
            decimal dGross_Salary = GetGrossSalary_FromMas(empID);
            tbl_payMas_PAYE_TaxTable_1 oTax = tbl_payMas_PAYE_TaxTable_1.SelectAll().Where(r => r.Tax_StartRange <= dGross_Salary && r.Tax_EndRange > dGross_Salary && !r.IsCanceled && r.Status == (int)PAYE_Status.Active).FirstOrDefault();
            if (oTax != null)
                dPAYE_Amount = decimal.Round((dGross_Salary * (oTax.Tax_Rate / 100)) - oTax.Cola_Amt, 2);

            return dPAYE_Amount > 0 ? dPAYE_Amount : 0;
        }
        #endregion

        #endregion

        #region Admin Methods
        #region Payroll Roll Back
        public static void RollBack_Payroll(string sGroupID, DateTime dtmStartDate, DateTime dtmEndDate)
        {
            foreach (tbl_genMasEmployee oEmp in tbl_genMasEmployee.SelectAllByCompany_ID_CompanyBranch_ID_Payroll_ProcessGroupID(clsSecurity.CompanyID, clsSecurity.BranchID, sGroupID))
            {
                tbl_genMasEmployee_PaySlipItems oMasEmpPayItem_Current = tbl_genMasEmployee_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oEmp.Employee_ID, clsConfig.sCurrentMonthCoinage);
                tbl_genMasEmployee_PaySlipItems oMasEmpPayItem_Last = tbl_genMasEmployee_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oEmp.Employee_ID, clsConfig.sLastMonthCoinage);
                if (oMasEmpPayItem_Current != null && oMasEmpPayItem_Last != null)
                {
                    oMasEmpPayItem_Current.Rate = clsHelpMethods.GetPayslipItemAmt_Previous(oEmp.Employee_ID, clsConfig.sCurrentMonthCoinage, dtmStartDate, dtmEndDate);
                    oMasEmpPayItem_Last.Rate = clsHelpMethods.GetPayslipItemAmt_Previous(oEmp.Employee_ID, clsConfig.sLastMonthCoinage, dtmStartDate, dtmEndDate);
                    oMasEmpPayItem_Current.Update();
                    oMasEmpPayItem_Last.Update();
                }
            }
            DBHandling.ExecQuery("exec payrollFlushGroup '" + dtmStartDate + "', '" + dtmEndDate + "', '" + sGroupID + "'");
        }

        #endregion
        #endregion

        #region From Transaction Tables
        //From Transaction Tables
        //These methods are useded after inserting data to transaction tables.

        #region Is Payslip Print - Previous
        public static bool IsPayslipPrint_Prevois(string sEmpID, DateTime dtmFromDate_current, DateTime dtmToDate_current)
        {
            bool bPrint = false;
            tbl_payTxSIPRawData oRawData_Previous = tbl_payTxSIPRawData.SelectAll().Where(r => r.Employee_ID == sEmpID && r.ProcessPeriod_Sub_startDate.Date < dtmFromDate_current.Date && r.ProcessPeriod_Sub_endDate.Date < dtmToDate_current.Date).OrderByDescending(r => r.ProcessPeriod_Sub_startDate).FirstOrDefault();
            if (oRawData_Previous != null)
                bPrint = oRawData_Previous.IsPayslip_Print;
            return bPrint;
        }
        #endregion

        #region Payslip Item Amounts - Previous
        public static decimal GetPayslipItemAmt_Previous(string sEmpID, string sPayslipItemID, DateTime dtmFromDate_current, DateTime dtmToDate_current)
        {
            decimal dAmount = 0;
            tbl_payTxSIPRawData oRawData_Previous = tbl_payTxSIPRawData.SelectAll().Where(r => r.Employee_ID == sEmpID && r.ProcessPeriod_Sub_startDate.Date < dtmFromDate_current.Date && r.ProcessPeriod_Sub_endDate.Date < dtmToDate_current.Date).OrderByDescending(r => r.ProcessPeriod_Sub_startDate).FirstOrDefault();
            int iSIP_Previous = oRawData_Previous == null ? 0 : oRawData_Previous.SIP_ID;
            tbl_payTxSIPRawData_PaySlipItems oPaySlipItem = tbl_payTxSIPRawData_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, iSIP_Previous, sPayslipItemID);
            if (oPaySlipItem != null)
                dAmount = oPaySlipItem.Amount;

            return dAmount;
        }
        #endregion


        #region Payroll Summary Report Methods
        public static decimal GetTotalBasicSalaryAmt(string sCompanyID, string sCompanyBranchID, int sSIP_ID, ref int iCount)
        {
            decimal dValue = 0;
            foreach (tbl_payTxSIPRawData_PaySlipItems oPaySlipItem in tbl_payTxSIPRawData_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(sCompanyID, sCompanyBranchID, sSIP_ID).Where(
            r => r.PayItem_ID == clsConfig.sBasicSalary ||
                    r.PayItem_ID == clsConfig.sBasicSalaryIncrement1 ||
                    r.PayItem_ID == clsConfig.sBRA1 ||
                    r.PayItem_ID == clsConfig.sBRA2 ||
                    r.PayItem_ID == clsConfig.sBRA3))
            {
                dValue += oPaySlipItem.Amount;
            }
            if (dValue > 0)
                iCount++;

            return dValue;
        }

        public static decimal GetTotalBasicSalaryAmt_Resigned(string sCompanyID, string sCompanyBranchID, int sSIP_ID, ref int iCount)
        {
            decimal dValue = 0;
            foreach (tbl_payTxSIPRawData_PaySlipItems oPaySlipItem in
                tbl_payTxSIPRawData_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID
                (sCompanyID, sCompanyBranchID, sSIP_ID).Where(
                r => r.PayItem_ID == clsConfig.sBasicSalary ||
                        r.PayItem_ID == clsConfig.sBasicSalaryIncrement1 ||
                        r.PayItem_ID == clsConfig.sBRA1 ||
                        r.PayItem_ID == clsConfig.sBRA2 ||
                        r.PayItem_ID == clsConfig.sBRA3))
            {
                dValue += oPaySlipItem.Amount;
            }
            if (dValue > 0)
                iCount++;

            return dValue;
        }

        public static decimal GetTotalIncrementAmt(string sCompanyID, string sCompanyBranchID, int sSIP_ID, ref int iCount)
        {
            decimal dValue = 0;
            foreach (tbl_payTxSIPRawData_PaySlipItems oPaySlipItem in
                tbl_payTxSIPRawData_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID
                (sCompanyID, sCompanyBranchID, sSIP_ID).Where(
                r => r.PayItem_ID == clsConfig.sBasicSalaryIncrement1))
            {
                dValue += oPaySlipItem.Amount;
            }
            if (dValue > 0)
                iCount++;

            return dValue;
        }

        public static decimal GetTotalBasicSalaryAmt_CassualTransfer(string sCompanyID, string sCompanyBranchID, int sSIP_ID, ref int iCount)
        {
            decimal dValue = 0;
            foreach (tbl_payTxSIPRawData_PaySlipItems oPaySlipItem in
                tbl_payTxSIPRawData_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID
                (sCompanyID, sCompanyBranchID, sSIP_ID).Where(
                r => r.PayItem_ID == clsConfig.sBasicSalary ||
                        r.PayItem_ID == clsConfig.sBRA1 ||
                        r.PayItem_ID == clsConfig.sBRA2 ||
                        r.PayItem_ID == clsConfig.sBRA3))
            {
                dValue += oPaySlipItem.Amount;
            }
            if (dValue > 0)
                iCount++;

            return dValue;
        }

        public static decimal GetTotalBasicSalaryAmt_Recruit(string sCompanyID, string sCompanyBranchID, int sSIP_ID, ref int iCount)
        {
            decimal dValue = 0;
            foreach (tbl_payTxSIPRawData_PaySlipItems oPaySlipItem in
                tbl_payTxSIPRawData_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID
                (sCompanyID, sCompanyBranchID, sSIP_ID).Where(
                r => r.PayItem_ID == clsConfig.sBasicSalary ||
                        r.PayItem_ID == clsConfig.sBRA1 ||
                        r.PayItem_ID == clsConfig.sBRA2 ||
                        r.PayItem_ID == clsConfig.sBRA3))
            {
                dValue += oPaySlipItem.Amount;
            }
            if (dValue > 0)
                iCount++;

            return dValue;
        }

        public static decimal GetTotalBasicSalaryAmt_Transfers(string sDivisionID, string sEmpID, string sCompanyID, string sCompanyBranchID, int sSIP_ID, DateTime dtmFromDate, DateTime dtmToDate, ref int iCount)
        {
            decimal dValue = 0;
            string sPrevDivisionID = "";

            tbl_payTxSIPRawData oRawItem = tbl_payTxSIPRawData.SelectPeriod_ByDateRange(dtmFromDate.AddMonths(-1).Date, dtmToDate.AddDays(-1).Date).Where(r => r.Employee_ID == sEmpID).FirstOrDefault();
            if (oRawItem != null)
            {
                if (sDivisionID != oRawItem.Division_ID)
                {
                    foreach (tbl_payTxSIPRawData_PaySlipItems oPaySlipItem in
                        tbl_payTxSIPRawData_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID
                        (sCompanyID, sCompanyBranchID, sSIP_ID).Where(
                            r => r.PayItem_ID == clsConfig.sBasicSalary ||
                                r.PayItem_ID == clsConfig.sBRA1 ||
                                r.PayItem_ID == clsConfig.sBRA2 ||
                                r.PayItem_ID == clsConfig.sBRA3))
                    {
                        dValue += oPaySlipItem.Amount;
                    }
                    if (dValue > 0)
                        iCount++;
                }
            }

            return dValue;
        }
        #endregion

        #region Earnings and Deduction Totals - Latest and Previous
        public static decimal GetEarningTotal_Previous(string sEmpID, DateTime dtmFromDate_current, DateTime dtmToDate_current)
        {
            decimal dAmount = 0;
            tbl_payTxSIPRawData oRawData_Previous = tbl_payTxSIPRawData.SelectAll().Where(r => r.Employee_ID == sEmpID && r.ProcessPeriod_Sub_startDate.Date < dtmFromDate_current.Date && r.ProcessPeriod_Sub_endDate.Date < dtmToDate_current.Date).OrderByDescending(r => r.ProcessPeriod_Sub_startDate).FirstOrDefault();
            int iSIP_Previous = oRawData_Previous == null ? 0 : oRawData_Previous.SIP_ID;

            foreach (tbl_payTxSIPRawData_PaySlipItems oPaySlipItem in tbl_payTxSIPRawData_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(clsSecurity.CompanyID, clsSecurity.BranchID, iSIP_Previous))
            {
                if (oPaySlipItem.IsEarning)
                    dAmount += oPaySlipItem.Amount;
            }
            return dAmount;
        }

        public static decimal GetDeductionTotal_Previous(string sEmpID, DateTime dtmFromDate_current, DateTime dtmToDate_current)
        {
            decimal dAmount = 0;
            tbl_payTxSIPRawData oRawData_previous = tbl_payTxSIPRawData.SelectAll().Where(r => r.Employee_ID == sEmpID && r.ProcessPeriod_Sub_startDate.Date < dtmFromDate_current.Date && r.ProcessPeriod_Sub_endDate.Date < dtmToDate_current.Date).OrderByDescending(r => r.ProcessPeriod_Sub_startDate).FirstOrDefault();
            int iSIP_previous = oRawData_previous == null ? 0 : oRawData_previous.SIP_ID;

            foreach (tbl_payTxSIPRawData_PaySlipItems oPaySlipItem in tbl_payTxSIPRawData_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(clsSecurity.CompanyID, clsSecurity.BranchID, iSIP_previous))
            {
                if (!oPaySlipItem.IsEarning)
                    dAmount += oPaySlipItem.Amount;
            }

            //EPF 8%
            foreach (tbl_payTxSIPRawData_PaySlipItems_Statutary oStatItem in tbl_payTxSIPRawData_PaySlipItems_Statutary.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(clsSecurity.CompanyID, clsSecurity.BranchID, iSIP_previous).Where(r => r.StatutaryPayItem_ID == clsConfig.sEPF_Employee))
                dAmount += oStatItem.Amount;

            return dAmount;
        }

        public static decimal GetEarningTotal(string sEmpID, DateTime dtmFromDate, DateTime dtmToDate)
        {
            decimal dAmount = 0;
            tbl_payTxSIPRawData oRawData = tbl_payTxSIPRawData.SelectPeriod_ByDateRange(dtmFromDate.Date, dtmToDate.Date).Where(p => p.Employee_ID == sEmpID).FirstOrDefault();
            int iSIP = oRawData == null ? 0 : oRawData.SIP_ID;

            foreach (tbl_payTxSIPRawData_PaySlipItems oPaySlipItem in tbl_payTxSIPRawData_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(clsSecurity.CompanyID, clsSecurity.BranchID, iSIP))
            {
                if (oPaySlipItem.IsEarning)
                    dAmount += oPaySlipItem.Amount;

            }
            return dAmount;
        }

        public static decimal GetDeductionTotal(string sEmpID, DateTime dtmFromDate, DateTime dtmToDate)
        {
            decimal dAmount = 0;
            tbl_payTxSIPRawData oRawData = tbl_payTxSIPRawData.SelectPeriod_ByDateRange(dtmFromDate.Date, dtmToDate.Date).Where(p => p.Employee_ID == sEmpID).FirstOrDefault();
            int iSIP = oRawData == null ? 0 : oRawData.SIP_ID;

            foreach (tbl_payTxSIPRawData_PaySlipItems oPaySlipItem in tbl_payTxSIPRawData_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(clsSecurity.CompanyID, clsSecurity.BranchID, iSIP))
            {
                if (!oPaySlipItem.IsEarning)
                    dAmount += oPaySlipItem.Amount;

            }

            //EPF 8%
            foreach (tbl_payTxSIPRawData_PaySlipItems_Statutary oStatItem in tbl_payTxSIPRawData_PaySlipItems_Statutary.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(clsSecurity.CompanyID, clsSecurity.BranchID, iSIP).Where(r => r.StatutaryPayItem_ID == clsConfig.sEPF_Employee))
                dAmount += oStatItem.Amount;

            return dAmount;
        }
        #endregion

        #region Base Salary
        public static decimal GetBaseSalaryForStatutory_FromTX(string sEmpID, string sStatutoryID, DateTime dtmFromDate, DateTime dtmToDate)
        {
            decimal dAmount = 0;
            tbl_payTxSIPRawData oRawData = tbl_payTxSIPRawData.SelectPeriod_ByDateRange(dtmFromDate.Date, dtmToDate.Date).Where(p => p.Employee_ID == sEmpID).FirstOrDefault();
            int iSIP = oRawData == null ? 0 : oRawData.SIP_ID;

            foreach (var vStatutory in tbl_payTxSIPRawData_PaySlipItems_Statutary.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(clsSecurity.CompanyID, clsSecurity.BranchID, iSIP).Where(r => r.StatutaryPayItem_ID == sStatutoryID))
            {
                tbl_payTxSIPRawData_PaySlipItems detail = tbl_payTxSIPRawData_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, iSIP, vStatutory.PayItem_ID);
                if (detail != null)
                    dAmount += detail.Amount;

            }

            return dAmount;
        }

        public static decimal GetBaseSalaryForStatutory_FromTX(string sStatutoryID, int iSIP)
        {
            decimal dAmount = 0;

            foreach (var vStatutory in tbl_payTxSIPRawData_PaySlipItems_Statutary.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(clsSecurity.CompanyID, clsSecurity.BranchID, iSIP).Where(r => r.StatutaryPayItem_ID == sStatutoryID))
            {
                tbl_payTxSIPRawData_PaySlipItems detail = tbl_payTxSIPRawData_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, iSIP, vStatutory.PayItem_ID);
                if (detail != null)
                    dAmount += detail.Amount;

            }

            return decimal.Round(dAmount, 2);
        }


        public static decimal GetBaseSalary_FromTX(string empID, DateTime fromDate, DateTime toDate)
        {
            //Nopay Applicabe Pay Items are used to Calculate for Base Salary
            decimal dAmount = 0;
            tbl_payTxSIPRawData oRawData = tbl_payTxSIPRawData.SelectPeriod_ByDateRange(fromDate.Date, toDate.Date).Where(p => p.Employee_ID == empID).FirstOrDefault();
            int iSIP = oRawData == null ? 0 : oRawData.SIP_ID;

            foreach (var vPaySlipItem in tbl_payTxSIPRawData_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(clsSecurity.CompanyID, clsSecurity.BranchID, iSIP))
            {
                tbl_payMas_PaySlipItems oPayItem = tbl_payMas_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, vPaySlipItem.PayItem_ID);
                if (oPayItem.IsNoPayable)
                {
                    dAmount += vPaySlipItem.Amount;
                }
            }

            return dAmount;
        }
        #endregion

        #region Payslip Item Amount
        public static decimal GetPayItemAmount_FromTX(int iRawDataTxID, string sPayItemID)
        {
            decimal dItemAmt = 0;
            tbl_payTxSIPRawData_PaySlipItems oPayItems = tbl_payTxSIPRawData_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, iRawDataTxID, sPayItemID);
            if (oPayItems != null)
                dItemAmt = oPayItems.Amount;

            return dItemAmt;
        }

        #endregion

        #region Statutory Item Amount
        public static decimal GetStatutaryItemAmount_FromTx(int iRawDataTxID, string sPaySatutoryID)
        {
            decimal dItemAmt = 0;
            foreach (tbl_payTxSIPRawData_PaySlipItems_Statutary oStat in tbl_payTxSIPRawData_PaySlipItems_Statutary.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(clsSecurity.CompanyID, clsSecurity.BranchID, iRawDataTxID).Where(p => p.StatutaryPayItem_ID == sPaySatutoryID))
                dItemAmt += oStat.Amount;

            return decimal.Round(dItemAmt, 2);
        }

        public static decimal GetTotAmountRegrdingStatutoryItem_FromTx(int iRawDataTxID, string sPaySatutoryID)
        {
            decimal dAmt = 0;
            foreach (tbl_payTxSIPRawData_PaySlipItems_Statutary oStat in tbl_payTxSIPRawData_PaySlipItems_Statutary.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(clsSecurity.CompanyID, clsSecurity.BranchID, iRawDataTxID).Where(p => p.StatutaryPayItem_ID == sPaySatutoryID))
            {
                tbl_payTxSIPRawData_PaySlipItems oItem = tbl_payTxSIPRawData_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oStat.SIP_ID, oStat.PayItem_ID);
                dAmt += oItem.Amount;
            }

            return dAmt;
        }
        #endregion

        #region Net Salary
        public static decimal GetNetSalary_FromTX(string sEmployeeID, DateTime dtmPeriodStartDate, DateTime dtmPeriodEndDate)
        {
            decimal dNetSal = 0;
            tbl_payTxSIPRawData oPayTX_Raw = tbl_payTxSIPRawData.SelectPeriod_ByDateRange(dtmPeriodStartDate.Date, dtmPeriodEndDate.Date).Where(r => r.Employee_ID == sEmployeeID).FirstOrDefault();
            if (oPayTX_Raw != null)
            {
                foreach (tbl_payTxSIPRawData_PaySlipItems oItem in tbl_payTxSIPRawData_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(oPayTX_Raw.Company_ID, oPayTX_Raw.CompanyBranch_ID, oPayTX_Raw.SIP_ID))
                    dNetSal += oItem.Amount;

                //EPF 8%
                foreach (tbl_payTxSIPRawData_PaySlipItems_Statutary oStatItem in tbl_payTxSIPRawData_PaySlipItems_Statutary.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(oPayTX_Raw.Company_ID, oPayTX_Raw.CompanyBranch_ID, oPayTX_Raw.SIP_ID).Where(r => r.StatutaryPayItem_ID == clsConfig.sEPF_Employee))
                    dNetSal -= oStatItem.Amount;
            }

            return dNetSal;
        }

        public static decimal GetNetSalary_FromTX(int iSIP_ID)
        {
            decimal dNetSal = 0;
            foreach (tbl_payTxSIPRawData_PaySlipItems oItem in tbl_payTxSIPRawData_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(clsSecurity.CompanyID, clsSecurity.BranchID, iSIP_ID))
                dNetSal += oItem.Amount;

            //EPF 8%
            foreach (tbl_payTxSIPRawData_PaySlipItems_Statutary oStatItem in tbl_payTxSIPRawData_PaySlipItems_Statutary.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(clsSecurity.CompanyID, clsSecurity.BranchID, iSIP_ID).Where(r => r.StatutaryPayItem_ID == clsConfig.sEPF_Employee))
                dNetSal -= oStatItem.Amount;

            return dNetSal;
        }
        #endregion

        #region Gross Salary
        public static decimal GetGrossSalary_FromTX(int iSIP_ID)
        {
            decimal dGross_Sal = 0;
            foreach (tbl_payTxSIPRawData_PaySlipItems oItem in tbl_payTxSIPRawData_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(clsSecurity.CompanyID, clsSecurity.BranchID, iSIP_ID).Where(r => r.IsEarning))
                dGross_Sal += oItem.Amount;

            //No Pay Deduction
            dGross_Sal = dGross_Sal + GetPayItemAmount_FromTX(iSIP_ID, clsConfig.sNopay);

            return dGross_Sal;
        }
        #endregion

        #endregion

        #endregion

        #region Get Enum Description
        public static string GetEnumDescription(Enum value)
        {
            // Get the Description attribute value for the enum value
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }
        #endregion/

        #region Format Decimal Places
        public static string FormatDecimalPlaces_Price(decimal dCurrency)
        {
            string value = "0.00";
            value = String.Format("{0:#,0.00}", dCurrency);
            return value;
        }
        public static decimal RoundDecimalPlaces(decimal dCurrency)
        {
            dCurrency = Math.Round(dCurrency, 2);
            return dCurrency;
        }
        #endregion
    }
}
