using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
    /// <summary>
    /// Interaction logic for UC_Roster.xaml
    /// </summary>
    public partial class UC_Roster : UserControl
    {

        #region Form Load
        public UC_Roster()
        {
            #region Form Initialize
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Roster_ControlPanel;
            SEACC_Form.Initialize();
            #endregion

            #region Action Button
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("employee_ID");
            dgr_Main.dt.Columns.Add("EmpName");

            dgr_Main.dt.Columns.Add("division_ID");
            dgr_Main.dt.Columns.Add("divisionName");

            dgr_Main.dt.Columns.Add("department_ID");
            dgr_Main.dt.Columns.Add("departmentName");

            dgr_Main.dt.Columns.Add("section_ID");
            dgr_Main.dt.Columns.Add("sectionName");

            dgr_Main.dt.Columns.Add("day1_ID");
            dgr_Main.dt.Columns.Add("day1");
            dgr_Main.dt.Columns.Add("day2_ID");
            dgr_Main.dt.Columns.Add("day2");
            dgr_Main.dt.Columns.Add("day3_ID");
            dgr_Main.dt.Columns.Add("day3");
            dgr_Main.dt.Columns.Add("day4_ID");
            dgr_Main.dt.Columns.Add("day4");
            dgr_Main.dt.Columns.Add("day5_ID");
            dgr_Main.dt.Columns.Add("day5");

            dgr_Main.dt.Columns.Add("day6_ID");
            dgr_Main.dt.Columns.Add("day6");
            dgr_Main.dt.Columns.Add("day7_ID");
            dgr_Main.dt.Columns.Add("day7");
            dgr_Main.dt.Columns.Add("day8_ID");
            dgr_Main.dt.Columns.Add("day8");
            dgr_Main.dt.Columns.Add("day9_ID");
            dgr_Main.dt.Columns.Add("day9");
            dgr_Main.dt.Columns.Add("day10_ID");
            dgr_Main.dt.Columns.Add("day10");

            dgr_Main.dt.Columns.Add("day11_ID");
            dgr_Main.dt.Columns.Add("day11");
            dgr_Main.dt.Columns.Add("day12_ID");
            dgr_Main.dt.Columns.Add("day12");
            dgr_Main.dt.Columns.Add("day13_ID");
            dgr_Main.dt.Columns.Add("day13");
            dgr_Main.dt.Columns.Add("day14_ID");
            dgr_Main.dt.Columns.Add("day14");
            dgr_Main.dt.Columns.Add("day15_ID");
            dgr_Main.dt.Columns.Add("day15");

            dgr_Main.dt.Columns.Add("day16_ID");
            dgr_Main.dt.Columns.Add("day16");
            dgr_Main.dt.Columns.Add("day17_ID");
            dgr_Main.dt.Columns.Add("day17");
            dgr_Main.dt.Columns.Add("day18_ID");
            dgr_Main.dt.Columns.Add("day18");
            dgr_Main.dt.Columns.Add("day19_ID");
            dgr_Main.dt.Columns.Add("day19");
            dgr_Main.dt.Columns.Add("day20_ID");
            dgr_Main.dt.Columns.Add("day20");

            dgr_Main.dt.Columns.Add("day21_ID");
            dgr_Main.dt.Columns.Add("day21");
            dgr_Main.dt.Columns.Add("day22_ID");
            dgr_Main.dt.Columns.Add("day22");
            dgr_Main.dt.Columns.Add("day23_ID");
            dgr_Main.dt.Columns.Add("day23");
            dgr_Main.dt.Columns.Add("day24_ID");
            dgr_Main.dt.Columns.Add("day24");
            dgr_Main.dt.Columns.Add("day25_ID");
            dgr_Main.dt.Columns.Add("day25");

            dgr_Main.dt.Columns.Add("day26_ID");
            dgr_Main.dt.Columns.Add("day26");
            dgr_Main.dt.Columns.Add("day27_ID");
            dgr_Main.dt.Columns.Add("day27");
            dgr_Main.dt.Columns.Add("day28_ID");
            dgr_Main.dt.Columns.Add("day28");
            dgr_Main.dt.Columns.Add("day29_ID");
            dgr_Main.dt.Columns.Add("day29");
            dgr_Main.dt.Columns.Add("day30_ID");
            dgr_Main.dt.Columns.Add("day30");

            dgr_Main.dt.Columns.Add("day31_ID");
            dgr_Main.dt.Columns.Add("day31");
            #endregion

            #region Data Grid Initialize
            dgr_Main.Add_DatagridColoumn("Emp No.", "employee_ID", 55, false);
            dgr_Main.Add_DatagridColoumn("Name", "EmpName", 120);

            dgr_Main.Add_DatagridColoumn("Div. No.", "division_ID", 55, false);
            dgr_Main.Add_DatagridColoumn("Division", "divisionName", 120);

            dgr_Main.Add_DatagridColoumn("Dep. No.", "department_ID", 55, false);
            dgr_Main.Add_DatagridColoumn("Department", "departmentName", 120);

            dgr_Main.Add_DatagridColoumn("Sec. No.", "section_ID", 55, false);
            dgr_Main.Add_DatagridColoumn("Section", "sectionName", 120);

            dgr_Main.Add_DatagridColoumn("Day 1 ID", "day1_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 1", "day1", 70);
            dgr_Main.Add_DatagridColoumn("Day 2 ID", "day2_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 2", "day2", 70);
            dgr_Main.Add_DatagridColoumn("Day 3 ID", "day3_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 3", "day3", 70);
            dgr_Main.Add_DatagridColoumn("Day 4 ID", "day4_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 4", "day4", 70);
            dgr_Main.Add_DatagridColoumn("Day 5 ID", "day5_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 5", "day5", 70);

            dgr_Main.Add_DatagridColoumn("Day 6 ID", "day6_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 6", "day6", 70);
            dgr_Main.Add_DatagridColoumn("Day 7 ID", "day7_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 7", "day7", 70);
            dgr_Main.Add_DatagridColoumn("Day 8 ID", "day8_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 8", "day8", 70);
            dgr_Main.Add_DatagridColoumn("Day 9 ID", "day9_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 9", "day9", 70);
            dgr_Main.Add_DatagridColoumn("Day 10 ID", "day10_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 10", "day10", 70);

            dgr_Main.Add_DatagridColoumn("Day 11 ID", "day11_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 11", "day11", 70);
            dgr_Main.Add_DatagridColoumn("Day 12 ID", "day12_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 12", "day12", 70);
            dgr_Main.Add_DatagridColoumn("Day 13 ID", "day13_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 13", "day13", 70);
            dgr_Main.Add_DatagridColoumn("Day 14 ID", "day14_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 14", "day14", 70);
            dgr_Main.Add_DatagridColoumn("Day 15 ID", "day15_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 15", "day15", 70);

            dgr_Main.Add_DatagridColoumn("Day 16 ID", "day16_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 16", "day16", 70);
            dgr_Main.Add_DatagridColoumn("Day 17 ID", "day17_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 17", "day17", 70);
            dgr_Main.Add_DatagridColoumn("Day 18 ID", "day18_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 18", "day18", 70);
            dgr_Main.Add_DatagridColoumn("Day 19 ID", "day19_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 19", "day19", 70);
            dgr_Main.Add_DatagridColoumn("Day 20 ID", "day20_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 20", "day20", 70);

            dgr_Main.Add_DatagridColoumn("Day 21 ID", "day21_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 21", "day21", 70);
            dgr_Main.Add_DatagridColoumn("Day 22 ID", "day22_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 22", "day22", 70);
            dgr_Main.Add_DatagridColoumn("Day 23 ID", "day23_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 23", "day23", 70);
            dgr_Main.Add_DatagridColoumn("Day 24 ID", "day24_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 24", "day24", 70);
            dgr_Main.Add_DatagridColoumn("Day 25 ID", "day25_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 25", "day25", 70);

            dgr_Main.Add_DatagridColoumn("Day 26 ID", "day26_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 26", "day26", 70);
            dgr_Main.Add_DatagridColoumn("Day 27 ID", "day27_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 27", "day27", 70);
            dgr_Main.Add_DatagridColoumn("Day 28 ID", "day28_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 28", "day28", 70);
            dgr_Main.Add_DatagridColoumn("Day 29 ID", "day29_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 29", "day29", 70);
            dgr_Main.Add_DatagridColoumn("Day 30 ID", "day30_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 30", "day30", 70);

            dgr_Main.Add_DatagridColoumn("Day 31 ID", "day31_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Day 31", "day31", 70);
            #endregion

            ClearFields();
        }
        #endregion

        #region Action Buttons
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> lsEmployees_AttenIssues = new List<string>();

                DateTime dtmFromDate = dtp_FromDate.GetDateTime();
                DateTime dtmToDate = dtptoDate.GetDateTime();
                bool bInserted = false;

                List<tbl_tasHolidayCalander> oHolidays = tbl_tasHolidayCalander.SelectAllByHolyday_Date(dtmFromDate.Date, dtmToDate.Date).Where(p => p.Holiday_Status).ToList();

                int iRow = 0;
                foreach (DataRow row in dgr_Main.dt.Rows)
                {
                    string sEmployee_ID = row["employee_ID"].ToString();
                    string sDep_ID = row["department_ID"].ToString();
                    int iColumnID = 8;

                    for (DateTime dDate = dtmFromDate.Date; dDate.Date <= dtmToDate.Date; dDate = dDate.AddDays(1))
                    {
                        if (CheckAttendance(sEmployee_ID, dDate.Date, dDate.Date))
                        {
                            //lsEmployees_AttenIssues.Add(sEmployee_ID + " - " + clsRef_Name.get_EmployeeName(sEmployee_ID));
                            continue;
                        }

                        string sRosterDate = dgr_Main.grdMain.Columns[iColumnID].Header.ToString();
                        DateTime dtRosterDate = DateTime.Parse(sRosterDate);
                        string sShift_ID = dgr_Main.dt.Rows[iRow][iColumnID].ToString();
                        if (sShift_ID == "")
                        {
                            iColumnID += 2;
                            continue;
                        }

                        #region Day type Intialize
                        int sDayType = (int)DayTypes.WorkingDay;
                        foreach (tbl_tasHolidayCalander oCal in oHolidays.Where(p => p.Holiday_Date.Date == dDate.Date && !p.IsCanceled))
                        {
                            sDayType = (int)DayTypes.Holiday;
                            if (oCal.HolydayType_ID == clsConfig.sCompany)
                                sDayType = (int)DayTypes.CompanyHoliday;
                        }

                        if (dDate.DayOfWeek == DayOfWeek.Sunday)
                        {
                            sDayType = (int)DayTypes.Sunday;
                        }
                        else if (dDate.DayOfWeek == DayOfWeek.Saturday)
                        {
                            sDayType = (int)DayTypes.Saturday;
                        }
                        #endregion

                        #region Saved Raw Data
                        tbl_tasTxEmployeeRoster oList = tbl_tasTxEmployeeRoster.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployee_ID).Where(p => p.RosterDate.Date == dtRosterDate.Date).FirstOrDefault();
                        tbl_tasShiftMaster oMasShift = tbl_tasShiftMaster.Select(sShift_ID, clsSecurity.CompanyID, clsSecurity.BranchID);
                        if (oList != null)
                        {
                            DateTime dtStartTime = dtRosterDate.AddHours(oMasShift.ShiftStartTime.Hour);
                            DateTime dtEndTime = dtStartTime.AddMinutes(oMasShift.ShiftMinutesMin);

                            tbl_tasTxEmployeeRoster oEmpShift = new tbl_tasTxEmployeeRoster(oList.Company_ID, oList.CompanyBranch_ID, oList.Roster_index, oList.RosterDate,
                            oList.Employee_ID, sDep_ID, sDayType, sShift_ID, -1, dtStartTime, dtEndTime,
                            oMasShift.ShiftMinutes, oMasShift.ShiftMinutesMin, oMasShift.NextShiftMinutes, oMasShift.ShiftGracePeriod,
                            oMasShift.IsOT_Applicable, oMasShift.Shift_OTMinuteMin, oMasShift.Shift_OTMinuteMax, oMasShift.Shift_OTGracePeroiod,
                            false,
                            oList.UserID_Created, clsSecurity.UserIDLoged, "Default",
                            oList.TerminalID_Created, clsSecurity.TerminalID, "Default",
                            clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());

                            oEmpShift.Update();
                        }
                        else
                        {
                            DateTime dtStartTime = dtRosterDate.AddHours(oMasShift.ShiftStartTime.Hour);
                            DateTime dtEndTime = dtStartTime.AddMinutes(oMasShift.ShiftMinutesMin);

                            tbl_tasTxEmployeeRoster oEmpShift = new tbl_tasTxEmployeeRoster(clsSecurity.CompanyID, clsSecurity.BranchID, dtRosterDate.Date,
                            sEmployee_ID, sDep_ID, sDayType, sShift_ID, -1, dtStartTime, dtEndTime,
                            oMasShift.ShiftMinutes, oMasShift.ShiftMinutesMin, oMasShift.NextShiftMinutes, oMasShift.ShiftGracePeriod,
                            oMasShift.IsOT_Applicable, oMasShift.Shift_OTMinuteMin, oMasShift.Shift_OTMinuteMax, oMasShift.Shift_OTGracePeroiod,
                            false,
                            clsSecurity.UserIDLoged, "Default", "Default",
                            clsSecurity.TerminalID, "Default", "Default",
                            clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());

                            oEmpShift.Insert();
                        }
                        #endregion

                        bInserted = true;
                        iColumnID += 2;
                    }
                    iRow++;
                }

                //if (lsEmployees_AttenIssues.Count > 0)
                //{
                //    string sMessageBody_ShiftErrorEmployees = "";
                //    foreach (string sEmp in lsEmployees_AttenIssues)
                //        sMessageBody_ShiftErrorEmployees += sEmp + " \n";

                //    SEACCMessageBox.Show("Employee(s) Roster Not Saved...!", sMessageBody_ShiftErrorEmployees + "", MessageBoxButton.OK);
                //}

                if (bInserted)
                    SEACCMessageBox.Show("Employee(s) Roster Saved Succesfully...!", "", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Load Button
        private void SEACC_Load_Button_Click(object sender, RoutedEventArgs e)
        {
            frm_WaitingMessege FrmWaiting = new frm_WaitingMessege();
            try
            {
                this.Cursor = Cursors.Wait;

                #region Variables
                dgr_Main.dt.Clear();

                DataTable dtNew = new DataTable();
                DateTime dtmFromDate = dtp_FromDate.GetDateTime();
                DateTime dtmToDate = dtptoDate.GetDateTime();

                string sShift_Day = clsConfig.sShift_Day_Configuration;
                string sShift_Night = clsConfig.sShift_Night_Configuration;
                string sShift_Off = clsConfig.sShift_Off_Configuration;

                string sShift24_Hrs = clsConfig.sShift24_Configuration;
                #endregion

                #region Visible all columns
                for (int i = 0; i < dgr_Main.grdMain.Columns.Count; i++)
                {
                    dgr_Main.grdMain.Columns[i].Visibility = Visibility.Visible;
                }
                #endregion

                #region Filters
                string sEmployee = "%", sDivision = "%", sDepartment = "%", sSection = "%", sAttendanceGroup = "%";
                #region Filter - Employee
                if (txtEmpNo.Tag != null)
                    sEmployee = txtEmpNo.Tag.ToString();
                #endregion

                #region Filter - Division
                //if (txtDivision.Tag != null)
                //    sDivision = txtDivision.Tag.ToString();
                #endregion

                #region Filter - Department
                if (txtDepartment.Tag != null)
                    sDepartment = txtDepartment.Tag.ToString();
                #endregion

                #region Filter - Section
                if (txtsection.Tag != null)
                    sSection = txtsection.Tag.ToString();
                #endregion

                #region Filter - Attendance Group
                if (txtAttendanceGroup1.Tag != null)
                    sAttendanceGroup = txtAttendanceGroup1.Tag.ToString();
                #endregion
                #endregion


                DataTable dtEmployee_Table = DBHandling.ExecQuery("exec [sp_genMasEmployees] '" + sEmployee + "','" + sDivision + "','" + sDepartment + "','" + sSection + "','" + sAttendanceGroup + "'").Tables[0];
                foreach (DataRow oEmployee in dtEmployee_Table.Rows)
                {
                    string sShiftID = "", sShiftID_Roster = "";
                    string sEmployee_ID = oEmployee["employee_ID"].ToString();

                    #region Add new Row
                    DataRow dr = dgr_Main.dt.NewRow();

                    dr["employee_ID"] = sEmployee_ID;
                    dr["EmpName"] = oEmployee["initails"].ToString() + oEmployee["surName"].ToString();

                    dr["department_ID"] = oEmployee["department_ID"].ToString();
                    dr["departmentName"] = clsRef_Name.get_Department_Name(oEmployee["department_ID"].ToString());

                    dr["division_ID"] = oEmployee["division_ID"].ToString();
                    dr["divisionName"] = clsRef_Name.get_Division_Name(oEmployee["division_ID"].ToString());

                    dr["section_ID"] = oEmployee["sectionID"].ToString();
                    dr["sectionName"] = clsRef_Name.get_Section_Name(oEmployee["sectionID"].ToString());

                    #region blank columns
                    dr["day1_ID"] = "";
                    dr["day1"] = "";
                    dr["day2_ID"] = "";
                    dr["day2"] = "";
                    dr["day3_ID"] = "";
                    dr["day3"] = "";
                    dr["day4_ID"] = "";
                    dr["day4"] = "";
                    dr["day5_ID"] = "";
                    dr["day5"] = "";

                    dr["day6_ID"] = "";
                    dr["day6"] = "";
                    dr["day7_ID"] = "";
                    dr["day7"] = "";
                    dr["day8_ID"] = "";
                    dr["day8"] = "";
                    dr["day9_ID"] = "";
                    dr["day9"] = "";
                    dr["day10_ID"] = "";
                    dr["day10"] = "";

                    dr["day11_ID"] = "";
                    dr["day11"] = "";
                    dr["day12_ID"] = "";
                    dr["day12"] = "";
                    dr["day13_ID"] = "";
                    dr["day13"] = "";
                    dr["day14_ID"] = "";
                    dr["day14"] = "";
                    dr["day15_ID"] = "";
                    dr["day15"] = "";

                    dr["day16_ID"] = "";
                    dr["day16"] = "";
                    dr["day17_ID"] = "";
                    dr["day17"] = "";
                    dr["day18_ID"] = "";
                    dr["day18"] = "";
                    dr["day19_ID"] = "";
                    dr["day19"] = "";
                    dr["day20_ID"] = "";
                    dr["day20"] = "";

                    dr["day21_ID"] = "";
                    dr["day21"] = "";
                    dr["day22_ID"] = "";
                    dr["day22"] = "";
                    dr["day23_ID"] = "";
                    dr["day23"] = "";
                    dr["day24_ID"] = "";
                    dr["day24"] = "";
                    dr["day25_ID"] = "";
                    dr["day25"] = "";

                    dr["day26_ID"] = "";
                    dr["day26"] = "";
                    dr["day27_ID"] = "";
                    dr["day27"] = "";
                    dr["day28_ID"] = "";
                    dr["day28"] = "";
                    dr["day29_ID"] = "";
                    dr["day29"] = "";
                    dr["day30_ID"] = "";
                    dr["day30"] = "";

                    dr["day31_ID"] = "";
                    dr["day31"] = "";
                    #endregion

                    dgr_Main.dt.Rows.Add(dr);

                    #endregion

                    #region Checked Previous Record (2018-05-28) - Janith
                    bool bHasPreviousRecord = false;
                    tbl_tasTxEmployeeRoster oPreviousRecord = tbl_tasTxEmployeeRoster.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployee_ID).Where(p => p.RosterDate.Date < dtmFromDate.Date).OrderByDescending(p => p.RosterDate).FirstOrDefault();
                    if (oPreviousRecord != null)
                    {
                        bHasPreviousRecord = true;
                        sShiftID = oPreviousRecord.Shift_ID;
                    }
                    #endregion

                    #region Intialize Rotated Variable
                    int iColumn = 9, iColumnID = 8;
                    int iRow = dgr_Main.dt.Rows.Count - 1;
                    #endregion

                    #region Fill Shift
                    for (DateTime dDate = dtmFromDate.Date; dDate.Date <= dtmToDate.Date; dDate = dDate.AddDays(1))
                    {
                        dgr_Main.grdMain.Columns[iColumnID].Header = dDate.Date.ToShortDateString();
                        dgr_Main.grdMain.Columns[iColumn].Header = dDate.Date.ToShortDateString() + "\n" + dDate.DayOfWeek;

                        #region Shift n Roster
                        //if (!bHasPreviousRecord)
                        //{
                        //    DataTable dtShift_Table = DBHandling.ExecQuery("SELECT TOP (1) ES.employee_ID, ES.effectiveFrom_Date, ES.shift_ID, S.shift_Name, S.shiftStartTime, S.shiftMinutes FROM tbl_tasMasEmployeeShift AS ES LEFT OUTER JOIN tbl_tasShiftMaster AS S ON ES.shift_ID = S.shift_ID  where ES.effectiveFrom_Date<='" + dDate.Date.ToString("yyyy-MM-dd") + "' AND ES.employee_ID = '" + sEmployee_ID + "' AND ES.isCanceled = 0 order by ES.effectiveFrom_Date DESC").Tables[0];
                        //    if (dtShift_Table != null && dtShift_Table.Rows.Count > 0)
                        //    {
                        //        sShiftID = dtShift_Table.Rows[0]["shift_ID"].ToString();
                        //    }
                        //}

                        DataTable dtRoster_Table = DBHandling.ExecQuery("SELECT TOP (1) r.employee_ID, r.rosterDate, r.shift_ID, s.shift_Name, s.shiftStartTime, s.shiftMinutes FROM tbl_tasTxEmployeeRoster AS r LEFT OUTER JOIN tbl_tasShiftMaster AS s ON r.shift_ID = s.shift_ID WHERE (r.rosterDate = '" + dDate.Date.ToString("yyyy-MM-dd") + "') AND (r.employee_ID = '" + sEmployee_ID + "') AND (r.isCanceled = 0) ORDER BY r.rosterDate DESC").Tables[0];
                        if (dtRoster_Table != null && dtRoster_Table.Rows.Count > 0)
                        {
                            sShiftID_Roster = dtRoster_Table.Rows[0]["shift_ID"].ToString();
                        }
                        #endregion

                        if (dtRoster_Table != null && dtRoster_Table.Rows.Count > 0)
                        {
                            if (dDate.DayOfWeek == DayOfWeek.Sunday)
                            {
                                dgr_Main.dt.Rows[iRow][iColumnID] = sShift_Off;
                                dgr_Main.dt.Rows[iRow][iColumn] = clsRef_Name.get_Shift_Name(sShift_Off);
                            }
                            else
                            {
                                #region Existings Rows
                                dgr_Main.dt.Rows[iRow][iColumnID] = sShiftID_Roster;
                                dgr_Main.dt.Rows[iRow][iColumn] = clsRef_Name.get_Shift_Name(sShiftID_Roster);
                                #endregion
                            }
                        }
                        else
                        {
                            if (bHasPreviousRecord)
                            {

                                #region Shifts Auto Generate
                                if ((sShiftID == sShift_Day) || (sShiftID == sShift_Night) || (sShiftID == sShift_Off))//check looping shift or not
                                {
                                    #region Shift Generate
                                    if (sShiftID == sShift_Day)
                                    {
                                        sShiftID = sShift_Night;
                                    }
                                    else if (sShiftID == sShift_Night)
                                    {
                                        sShiftID = sShift_Off;
                                    }
                                    else if (sShiftID == sShift_Off)
                                    {
                                        sShiftID = sShift_Day;
                                    }
                                    #endregion

                                    if (dDate.DayOfWeek == DayOfWeek.Sunday)
                                    {
                                        dgr_Main.dt.Rows[iRow][iColumnID] = sShift_Off;
                                        dgr_Main.dt.Rows[iRow][iColumn] = clsRef_Name.get_Shift_Name(sShift_Off);
                                    }
                                    else
                                    {
                                        dgr_Main.dt.Rows[iRow][iColumnID] = sShiftID;
                                        dgr_Main.dt.Rows[iRow][iColumn] = clsRef_Name.get_Shift_Name(sShiftID);
                                    }
                                }
                                //else if (sShiftID == sShift24_Hrs)
                                //{
                                //    dgr_Main.dt.Rows[iRow][iColumnID] = sShiftID;
                                //    dgr_Main.dt.Rows[iRow][iColumn] = clsRef_Name.get_Shift_Name(sShiftID);
                                //}
                                #endregion
                            }
                            else
                            {
                                #region New Rows
                                dgr_Main.dt.Rows[iRow][iColumnID] = sShiftID;
                                dgr_Main.dt.Rows[iRow][iColumn] = clsRef_Name.get_Shift_Name(sShiftID);
                                #endregion
                            }
                        }

                        iColumn += 2;
                        iColumnID += 2;
                    } 
                    #endregion

                    #region Hide Not Activate Columns
                    for (int i = iColumn; i < dgr_Main.grdMain.Columns.Count; i++)
                    {
                        dgr_Main.grdMain.Columns[i].Visibility = Visibility.Collapsed;
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                dgr_Main.dt.Clear();
                SEACCExeption.Show(ex);
            }
            finally
            {
                dgr_Main.RefreshGrid();
                FrmWaiting.Close();
                this.Cursor = Cursors.Arrow;
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            dgr_Main.dt.Clear();

            #region Visible all columns
            for (int i = 0; i < dgr_Main.grdMain.Columns.Count; i++)
            {
                dgr_Main.grdMain.Columns[i].Visibility = Visibility.Visible;
            }
            #endregion

            #region Change Headers all columns
            int iDay = 1, iDayID = 1;
            for (int i = 8; i < dgr_Main.grdMain.Columns.Count; i += 2)
            {
                dgr_Main.grdMain.Columns[i].Header = "Day " + iDayID + " ID";
                dgr_Main.grdMain.Columns[i + iDay].Header = "Day " + iDayID;

                iDayID++;
            }
            #endregion
            
            dgr_Main.grdMain.HideContextMenu = true;
            
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDepartment, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtsection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmpNo, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtAttendanceGroup1, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtMonth, true, false, false);


            txtEmpNo.Tag = null;
            txtDepartment.Tag = null;
            txtsection.Tag = null;
            txtAttendanceGroup1.Tag = null;
            txtMonth.Tag = null;

            txtEmpNo.Text = "<All Employees>";
            txtDepartment.Text = "<All Departments>";
            txtsection.Text = "<All Sections>";
            txtAttendanceGroup1.Text = "<All Attendance Groups>";
            txtMonth.Text = "All Months";

            if (!clsConfig.bEnableAttendanceGroup1)
                txtAttendanceGroup1.Visibility = Visibility.Collapsed;

            dtp_FromDate.SetTime(DateTime.Now);
            dtptoDate.SetTime(DateTime.Now);

            chkAutoShifts.IsChecked = true;
        }
        #endregion

        #region Fill Employee
        private void FillEmployee(string empID)
        {
            tbl_genMasEmployee oEmployee = tbl_genMasEmployee.Select(empID, clsSecurity.CompanyID, clsSecurity.BranchID);
            if (oEmployee != null)
            {
                txtEmpNo.Tag = oEmployee.Employee_ID;
                txtEmpNo.Text = oEmployee.EpfNo + " - " + oEmployee.FullName;

                //txtDivision.Tag = oEmployee.Division_ID;
                //txtDivision.Text = oEmployee.DivisionName;
                //txtDivision.IsEnabled = false;

                txtDepartment.Tag = oEmployee.Department_ID;
                txtDepartment.Text = clsRef_Name.get_Department_Name(oEmployee.Department_ID);
                txtDepartment.IsEnabled = false;

                txtsection.Tag = oEmployee.SectionID;
                txtsection.Text = clsRef_Name.get_Section_Name(oEmployee.SectionID);
                txtsection.IsEnabled = false;
            }
        }
        #endregion

        #region Data Grid Event
        private void grd_Main_DG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var vDG_Cell = dgr_Main.GetCurrentCell();
                int irowID = dgr_Main.SelectedIndex;
                string sColumn = vDG_Cell.Column.SortMemberPath;
                int iColumn = vDG_Cell.Column.DisplayIndex;

                DateTime dtmFromDate = dtp_FromDate.GetDateTime();
                DateTime dtmToDate = dtptoDate.GetDateTime();


                if (sColumn != "employee_ID" && sColumn != "division_ID" && sColumn != "department_ID" && sColumn != "section_ID"
                    && sColumn != "EmpName" && sColumn != "divisionName" && sColumn != "departmentName" && sColumn != "sectionName" && sColumn != "actionButton")
                {
                    string sEmployeeID = "";
                    try
                    {
                        sEmployeeID = dgr_Main.dt.Rows[irowID]["employee_ID"].ToString();
                    }
                    catch (Exception) { }

                    if (sEmployeeID != "")
                    {
                        frmSearch RowDataSearch = new frmSearch();
                        List<string> lstResult = RowDataSearch.Show(Search.Shift);
                        if (RowDataSearch.DialogResult == true)
                        {
                            string sShift_Day = clsConfig.sShift_Day_Configuration;
                            string sShift_Night = clsConfig.sShift_Night_Configuration;
                            string sShift_Off = clsConfig.sShift_Off_Configuration;

                            //string sShift24_Hrs = clsConfig.sShift24_Configuration;

                            #region Auto Generated Shifts
                            if (chkAutoShifts.IsChecked == true)
                            {
                                //intialize first column that user selected
                                dgr_Main.dt.Rows[irowID][iColumn - 1] = lstResult[0];
                                dgr_Main.dt.Rows[irowID][iColumn] = clsRef_Name.get_Shift_Name(lstResult[0]);

                                string sShift = dgr_Main.dt.Rows[irowID][iColumn - 1].ToString();
                                iColumn += 2;//then user selected column is fill and starting to loop all column in next column

                                string sDate = dgr_Main.grdMain.Columns[iColumn - 1].Header.ToString();//get shift date using user selected date
                                DateTime dDay = DateTime.Parse(sDate);

                                #region Shifts Auto Generate
                                if ((sShift == sShift_Day) || (sShift == sShift_Night) || (sShift == sShift_Off))//check looping shift or not
                                {
                                    for (DateTime dDate = dDay.Date; dDate.Date <= dtmToDate.Date; dDate = dDate.AddDays(1))
                                    {
                                        #region Shift Generate
                                        if (sShift == sShift_Day)
                                        {
                                            sShift = sShift_Night;
                                        }
                                        else if (sShift == sShift_Night)
                                        {
                                            sShift = sShift_Off;
                                        }
                                        else if (sShift == sShift_Off)
                                        {
                                            sShift = sShift_Day;
                                        }
                                        #endregion

                                        if (dDate.DayOfWeek == DayOfWeek.Sunday)
                                        {
                                            #region Set Shifts to Columns
                                            dgr_Main.dt.Rows[irowID][iColumn - 1] = sShift_Off;
                                            dgr_Main.dt.Rows[irowID][iColumn] = clsRef_Name.get_Shift_Name(sShift_Off);
                                            #endregion
                                        }
                                        else
                                        {
                                            #region Set Shifts to Columns
                                            dgr_Main.dt.Rows[irowID][iColumn - 1] = sShift;
                                            dgr_Main.dt.Rows[irowID][iColumn] = clsRef_Name.get_Shift_Name(sShift);
                                            #endregion
                                        }

                                        iColumn += 2;
                                    }
                                }
                                //else if (sShift == sShift24_Hrs)
                                //{
                                //    for (DateTime dDate = dDay.Date; dDate.Date <= dtmToDate.Date; dDate = dDate.AddDays(1))
                                //    {
                                //        dgr_Main.dt.Rows[irowID][iColumn - 1] = sShift;
                                //        dgr_Main.dt.Rows[irowID][iColumn] = clsRef_Name.get_Shift_Name(sShift);
                                //        iColumn += 2;
                                //    }
                                //}
                                #endregion
                            }
                            #endregion

                            #region other Shifts
                            else
                            {
                                dgr_Main.dt.Rows[irowID][(iColumn - 1)] = lstResult[0];
                                dgr_Main.dt.Rows[irowID][iColumn] = clsRef_Name.get_Shift_Name(lstResult[0]);
                            }
                            #endregion
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search
        private void txtEmpNo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                FillEmployee(lstResult[0]);
            }
        }
        private void txtDevision_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //frmSearch RowDataSearch = new frmSearch();
            //List<string> lstResult = RowDataSearch.Show(Search.Division);
            //if (RowDataSearch.DialogResult == true)
            //{
            //    txtDivision.Text = lstResult[1];
            //    txtDivision.Tag = lstResult[0];

            //    txtEmpNo.IsEnabled = false;
            //}
        }
        private void txtDepartment_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Departments);
            if (RowDataSearch.DialogResult == true)
            {
                txtDepartment.Text = lstResult[1];
                txtDepartment.Tag = lstResult[0];

                txtEmpNo.IsEnabled = false;
            }
        }
        private void txtsection_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Sections);
            if (RowDataSearch.DialogResult == true)
            {
                txtsection.Text = lstResult[1];
                txtsection.Tag = lstResult[0];

                txtEmpNo.IsEnabled = false;
            }
        }
        private void txtAttendanceGroup1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.AttendanceProcessGroup1);
            if (RowDataSearch.DialogResult == true)
            {
                txtAttendanceGroup1.Text = lstResult[1];
                txtAttendanceGroup1.Tag = lstResult[0];

                txtEmpNo.IsEnabled = false;
            }
        }
        private void txtMonth_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.HRMonth);
            if (RowDataSearch.DialogResult == true)
            {
                txtMonth.Tag = lstResult[0];
                txtMonth.Text = "Month " + lstResult[0];

                dtp_FromDate.SetTime(DateTime.Parse(lstResult[3]));
                dtptoDate.SetTime(DateTime.Parse(lstResult[4]));

            }
        }
        #endregion

        #region Check Validity
        private bool CheckAttendance(string sEmployee, DateTime dtFromDate, DateTime dtToDate)
        {
            bool bStatus = false;
            List<tbl_tasTxDailyAttendance> oDailyAtten = tbl_tasTxDailyAttendance.SelectAllBy_EmployeeIDWithDateRange(sEmployee, dtFromDate.Date, dtToDate.Date);
            if (oDailyAtten.Count > 0)
            {
                bStatus = true;
            }
            return bStatus;
        }
        #endregion

    }
}


#region Auto generated When Load Button click
//if (chkAutoShifts.IsChecked == true)
//{
//}
//else
//{
//    #region Shift Generate
//    if (sShiftID == sShift_Day)
//    {
//        sShiftID = sShift_Night;
//    }
//    else if (sShiftID == sShift_Night)
//    {
//        sShiftID = sShift_Off;
//    }
//    else if (sShiftID == sShift_Off)
//    {
//        sShiftID = sShift_Day;
//    }
//    #endregion

//    dgr_Main.dt.Rows[iRow][iColumnID] = sShiftID;
//    dgr_Main.dt.Rows[iRow][iColumn] = clsRef_Name.get_Shift_Name(sShiftID);
//} 
#endregion

#region Auto generate after select cell


//dgr_Main.dt.Rows[irowID][iColumn - 1] = sShift;
//dgr_Main.dt.Rows[irowID][iColumn] = clsRef_Name.get_Shift_Name(lstResult[0]);

//String sDayType = "Working Day";

#region Get Holidays
//foreach (tbl_tasHolidayCalander oCal in oHolidays.Where(p => p.Holiday_Date.Date == dDate.Date && !p.IsCanceled))
//{
//    sDayType = "HoliDay";
//    if (oCal.HolydayType_ID == clsConfig.sPoyaDay)
//        sDayType = "Poyaday";
//}
#endregion

//for (DateTime dDate = dtmFromDate.Date; dDate.Date <= dtmToDate.Date; dDate = dDate.AddDays(1))
//{
//    if (sShift == sShiftOne && dDate.DayOfWeek != DayOfWeek.Sunday)
//    {
//        sShift = sShiftTwo;
//    }
//    else if (sShift == sShiftTwo && dDate.DayOfWeek != DayOfWeek.Sunday)
//    {
//        sShift = sShiftThree;
//    }
//    else if (sShift == sShiftThree && dDate.DayOfWeek != DayOfWeek.Sunday)
//    {
//        sShift = sShiftOne;
//    }

//    if (dDate.DayOfWeek == DayOfWeek.Sunday)
//        dgr_Main.dt.Rows[irowID][iColumn] = sShiftThree;
//    else
//        dgr_Main.dt.Rows[irowID][iColumn] = sShift;

//    iColumn++;
//}


//if (sShift == sShiftOne && dDate.DayOfWeek != DayOfWeek.Sunday && (sDayType != "HoliDay" || sDayType != "Poyaday"))
//{
//    sShift = sShiftTwo;
//}
//else if (sShift == sShiftTwo && dDate.DayOfWeek != DayOfWeek.Sunday && (sDayType != "HoliDay" || sDayType != "Poyaday"))
//{
//    sShift = sShiftThree;
//}
//else if (sShift == sShiftThree && dDate.DayOfWeek != DayOfWeek.Sunday && (sDayType != "HoliDay" || sDayType != "Poyaday"))
//{
//    sShift = sShiftOne;
//} 
#endregion

#region Remove Data table columns
//int iDays = 1;
//DataColumnCollection columns = dgr_Main.dt.Columns;

//if (columns.Count > 8)
//{
//    for (int i = 8; i < columns.Count; i++)
//    {
//        if (columns.Contains("day" + iDays + "_ID"))
//            if (columns.CanRemove(columns["day" + iDays + "_ID"]))
//                columns.Remove("day" + iDays + "_ID");

//        if (columns.Contains("day" + iDays))
//            if (columns.CanRemove(columns["day" + iDays]))
//                columns.Remove("day" + iDays);

//        iDays++;
//    }
//}

//if (dgr_Main.dt.Columns.Count >= 8)
//{
//    for (int i = 8; i < dgr_Main.dt.Columns.Count; i++)
//        dgr_Main.dt.Columns.RemoveAt(i);

//    //for (int i = dgr_Main.dt.Columns.Count - 1; i >= 8; i--)
//    //    dgr_Main.dt.Columns.RemoveAt(i);
//} 
#endregion

#region intialize Date Columns belong to date period
//int iDay = 1;
//for (DateTime dDate = dtmFromDate.Date; dDate.Date <= dtmToDate.Date; dDate = dDate.AddDays(1))
//{
//    dgr_Main.dt.Columns.Add("day" + iDay + "_ID");
//    dgr_Main.dt.Columns.Add("day" + iDay);
//    dgr_Main.Add_DatagridColoumn(dDate.Date.ToShortDateString(), "day" + iDay + "_ID", 70, false);
//    dgr_Main.Add_DatagridColoumn(dDate.Date.ToShortDateString() + "\n" + dDate.DayOfWeek, "day" + iDay, 70);

//if (!dgr_Main.dt.Columns.Contains("day" + iDay + "_ID"))
//{
//    dgr_Main.dt.Columns.Add("day" + iDay + "_ID");
//    dgr_Main.Add_DatagridColoumn(dDate.Date.ToShortDateString(), "day" + iDay + "_ID", 70, false);
//}


//if (!dgr_Main.dt.Columns.Contains("day" + iDay))
//{
//    dgr_Main.dt.Columns.Add("day" + iDay);
//    dgr_Main.Add_DatagridColoumn(dDate.Date.ToShortDateString() + "\n" + dDate.DayOfWeek, "day" + iDay, 70);
//}

//    iDay++;
//}
#endregion

#region Filters
//#region Filter - Employee
//List<tbl_genMasEmployee> oEmployees;
//if (txtEmpNo.Tag != null)
//    oEmployees = tbl_genMasEmployee.SelectAll().Where(p => p.Employee_ID == txtEmpNo.Tag.ToString() && p.Employee_ID != "default").ToList();
//else
//    oEmployees = tbl_genMasEmployee.SelectAll().Where(p => p.Employee_ID != "default").ToList();
//#endregion

//#region Filter - Division
//if (txtDivision.Tag != null)
//    oEmployees = oEmployees.Where(p => p.Division_ID == txtDivision.Tag.ToString()).ToList();
//#endregion

//#region Filter - Department
//if (txtDepartment.Tag != null)
//    oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();
//#endregion

//#region Filter - Section
//if (txtsection.Tag != null)
//    oEmployees = oEmployees.Where(p => p.SectionID == txtsection.Tag.ToString()).ToList();
//#endregion 
#endregion