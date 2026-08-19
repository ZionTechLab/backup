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
using System.Windows.Shapes;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for frm_MonthlyAttendanceProcess.xaml
    /// </summary>
    public partial class Frm_EmployeeMonthlyAttendance : Window
    {
        #region Class Variables
        string sProcessGroupID;
        int iProcessPeriodID;
        DateTime dtmPeriodStartDate, dtmPeriodEndDate;
        tbl_genMasEmpAttendanceProcessPeriod oSubPeriod;
        DataTable dtDayBreakdown = new DataTable();
        #endregion

        #region Form Load
        public Frm_EmployeeMonthlyAttendance(string sGroupID, int iMainPeriodID, DateTime dtFromDate, DateTime dtToDate)
        {
            #region Initialize Usercontrol
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            SEACC_Form.enmFormName = FormName.Monthly_AttendanceControl_Panel;
            SEACC_Form.Initialize();
            #endregion

            #region Set Parameter
            sProcessGroupID = sGroupID;
            iProcessPeriodID = iMainPeriodID;
            dtmPeriodStartDate = dtFromDate.Date;
            dtmPeriodEndDate = dtToDate.Date;

            oSubPeriod = tbl_genMasEmpAttendanceProcessPeriod.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sProcessGroupID, iProcessPeriodID);

            lblAttenProcessGroup.Content = clsRef_Name.get_Attendance_ProcessGroup1(sGroupID);
            lblAttenProcessPeriod.Content = clsRef_Name.get_Attendance_ProcessPeriod(iMainPeriodID.ToString());

            lblStartDate.Content = dtFromDate.ToString(clsValidation.Format_Date);
            lblEndDate.Content = dtToDate.ToString(clsValidation.Format_Date);
            #endregion

            #region Action Button
            SEACC_Form.SetVisibility_ActionButons(false, false, true, false);
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("indexID", typeof(int));//new
            dgr_Main.dt.Columns.Add("empID");
            dgr_Main.dt.Columns.Add("empName");
            dgr_Main.dt.Columns.Add("empDivision");
            dgr_Main.dt.Columns.Add("empDepatment");
            dgr_Main.dt.Columns.Add("empSection");
            dgr_Main.dt.Columns.Add("empSubSection");
            dgr_Main.dt.Columns.Add("empAttenGroup1");
            dgr_Main.dt.Columns.Add("empAttenGroup2");

            dgr_Main.dt.Columns.Add("workHrs_Mand");
            dgr_Main.dt.Columns.Add("workHrsMins_Mand");//new
            dgr_Main.dt.Columns.Add("workHrs_Act");
            dgr_Main.dt.Columns.Add("workHrsMins_Act");//new

            dgr_Main.dt.Columns.Add("lateHrs");
            dgr_Main.dt.Columns.Add("lateHrsMins");//new
            dgr_Main.dt.Columns.Add("noPayHrs");
            dgr_Main.dt.Columns.Add("noPayHrsMins");//new

            dgr_Main.dt.Columns.Add("workHrs_OT_Normal");
            dgr_Main.dt.Columns.Add("workHrsMins_OT_Normal");//new
            dgr_Main.dt.Columns.Add("workHrs_OT_Act");
            dgr_Main.dt.Columns.Add("workHrsMins_OT_Act");//new

            dgr_Main.dt.Columns.Add("workHrs_OT_Double");
            dgr_Main.dt.Columns.Add("workHrsMins_OT_Double");//new
            dgr_Main.dt.Columns.Add("workHrs_OT_Double_Sunday");
            dgr_Main.dt.Columns.Add("workHrsMins_OT_Double_Sunday");//new

            dgr_Main.dt.Columns.Add("workHrs_OT_Triple");
            dgr_Main.dt.Columns.Add("workHrsMins_OT_Triple");//new

            dgr_Main.dt.Columns.Add("leaveHrs");
            dgr_Main.dt.Columns.Add("leaveHrsMins");//new
            dgr_Main.dt.Columns.Add("gatePassHrs");
            dgr_Main.dt.Columns.Add("gatePassHrsMins");//new

            dgr_Main.dt.Columns.Add("attenIncentive");//new

            #region day type breakdown datatable
            dtDayBreakdown.Columns.Add("empID");
            dtDayBreakdown.Columns.Add("empName");

            dtDayBreakdown.Columns.Add("dayTypeID");
            dtDayBreakdown.Columns.Add("dayType");

            dtDayBreakdown.Columns.Add("workMins_Mand", typeof(decimal));
            dtDayBreakdown.Columns.Add("workMins_Act", typeof(decimal));

            dtDayBreakdown.Columns.Add("lateHrsMins", typeof(decimal));
            dtDayBreakdown.Columns.Add("noPayHrsMins", typeof(decimal));
            dtDayBreakdown.Columns.Add("workHrsMins_OT", typeof(decimal));
            dtDayBreakdown.Columns.Add("workHrsMins_OT_Double", typeof(decimal));
            dtDayBreakdown.Columns.Add("workHrsMins_OT_Triple", typeof(decimal));
            dtDayBreakdown.Columns.Add("leaveHrsMins", typeof(decimal));
            dtDayBreakdown.Columns.Add("gatePassHrsMins", typeof(decimal)); 
            #endregion

            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Index ID", "indexID", 30, false, true);
            dgr_Main.Add_DatagridColoumn("Emp. No.", "empID", 80);
            dgr_Main.Add_DatagridColoumn("Emp. Name", "empName", 150);
            dgr_Main.Add_DatagridColoumn("Division", "empDivision", 100, false);
            dgr_Main.Add_DatagridColoumn("Department", "empDepatment", 100, false);
            dgr_Main.Add_DatagridColoumn("Section", "empSection", 180, false);
            dgr_Main.Add_DatagridColoumn("Sub Section", "empSubSection", 100, false);
            dgr_Main.Add_DatagridColoumn("Attendance Group 1", "empAttenGroup1", 100, false);
            dgr_Main.Add_DatagridColoumn("Attendance Group 2", "empAttenGroup2", 100, false);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Mand. hh.", "workHrs_Mand", 100, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Mand. hh:mm", "workHrsMins_Mand", 100, !clsConfig.bPayrollRawDataShow_HoursOnly, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Actual hh.", "workHrs_Act", 100, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Actual hh:mm", "workHrsMins_Act", 100, !clsConfig.bPayrollRawDataShow_HoursOnly, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Late hh.", "lateHrs", 80, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Late hh:mm", "lateHrsMins", 80, !clsConfig.bPayrollRawDataShow_HoursOnly, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "No Pay hh", "noPayHrs", 90, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "No Pay hh:mm", "noPayHrsMins", 90, !clsConfig.bPayrollRawDataShow_HoursOnly, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "OT Normal hh.", "workHrs_OT_Normal", 100, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "OT Normal hh:mm", "workHrsMins_OT_Normal", 115, !clsConfig.bPayrollRawDataShow_HoursOnly, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "OT Actual hh.", "workHrs_OT_Act", 100, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "OT Actual hh:mm", "workHrsMins_OT_Act", 115, !clsConfig.bPayrollRawDataShow_HoursOnly, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "OT Double hh.", "workHrs_OT_Double", 100, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "OT Double hh:mm", "workHrsMins_OT_Double", 115, !clsConfig.bPayrollRawDataShow_HoursOnly, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "OT Double Sun. hh.", "workHrs_OT_Double_Sunday", 100, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "OT Double  Sun. hh:mm", "workHrsMins_OT_Double_Sunday", 115, !clsConfig.bPayrollRawDataShow_HoursOnly, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "OT Triple hh.", "workHrs_OT_Triple", 90, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "OT Triple hh:mm", "workHrsMins_OT_Triple", 100, !clsConfig.bPayrollRawDataShow_HoursOnly, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Leave hh", "leaveHrs", 90, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Leave hh:mm", "leaveHrsMins", 90, !clsConfig.bPayrollRawDataShow_HoursOnly, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Gatepass hh.", "gatePassHrs", 100, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Gatepass hh:mm", "gatePassHrsMins", 110, !clsConfig.bPayrollRawDataShow_HoursOnly, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Attendance Incentive", "attenIncentive", 125, true, false);
            #endregion

            RefreshGrid();
        }
        #endregion

        #region Action Buttons
        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (!oSubPeriod.IsComplepted)
            {
                if (SEACCMessageBox.Show("Are you sure to start the process? '", ""))
                {
                    frm_WaitingMessege FrmWaiting = new frm_WaitingMessege();
                    try
                    {
                        foreach (DataRow row in dgr_Main.dt.Rows)
                        {
                            #region Variables Initialize
                            string sEmployee_ID = row["empID"].ToString();
                            //int iIndex = int.Parse(row["indexID"].ToString());

                            decimal dWorkMins_Mand = clsValidation.GetMinutes(row["workHrsMins_Mand"].ToString());
                            decimal dWorkMins_Act = clsValidation.GetMinutes(row["workHrsMins_Act"].ToString());

                            decimal dNoPayMins = clsValidation.GetMinutes(row["noPayHrsMins"].ToString());
                            decimal dNoPayMins_Act = clsValidation.GetMinutes(row["noPayHrsMins"].ToString());

                            decimal dLatesMins = clsValidation.GetMinutes(row["lateHrsMins"].ToString());
                            decimal dLatesMins_Act = clsValidation.GetMinutes(row["lateHrsMins"].ToString());

                            decimal dWorkMins_OT_Normal = clsValidation.GetMinutes(row["workHrsMins_OT_Normal"].ToString());
                            decimal dWorkMins_OT_Act = clsValidation.GetMinutes(row["workHrsMins_OT_Act"].ToString());

                            decimal dWorkMins_OT_Double = clsValidation.GetMinutes(row["workHrsMins_OT_Double"].ToString());
                            decimal dWorkMins_OT_Double_Act = clsValidation.GetMinutes(row["workHrsMins_OT_Double"].ToString());

                            decimal dWorkMins_OT_Triple = clsValidation.GetMinutes(row["workHrsMins_OT_Triple"].ToString());
                            decimal dWorkMins_OT_Triple_Act = clsValidation.GetMinutes(row["workHrsMins_OT_Triple"].ToString());

                            decimal dLeaveMins = clsValidation.GetMinutes(row["leaveHrsMins"].ToString());
                            decimal dLeaveMins_Act = clsValidation.GetMinutes(row["leaveHrsMins"].ToString());

                            decimal dGatePassMins = clsValidation.GetMinutes(row["gatePassHrsMins"].ToString());
                            decimal dGatePassMins_Act = clsValidation.GetMinutes(row["gatePassHrsMins"].ToString());

                            int dAttenIncentive = clsValidation.GetMinutes(row["attenIncentive"].ToString());
                            #endregion

                            #region Save Raw Data
                            tbl_genMasEmployee oEmployee = tbl_genMasEmployee.Select(sEmployee_ID, clsSecurity.CompanyID, clsSecurity.BranchID);

                            #region Flushed Data
                            tbl_tasTxMonthlyAttendance oDelete = tbl_tasTxMonthlyAttendance.SelectAllBy_EmployeeIDWithDateRange(sEmployee_ID, dtmPeriodStartDate.Date, dtmPeriodEndDate.Date).OrderByDescending(p => p.AttenProcessPeriod_startDate).FirstOrDefault();
                            if (oDelete != null)
                            {
                                List<tbl_tasTxMonthlyAttendance_DayTypeBreakdown> oDBreakdown = tbl_tasTxMonthlyAttendance_DayTypeBreakdown.SelectAll().Where(p => p.MonthlyIndex_ID == oDelete.Index_ID).ToList();
                                foreach (tbl_tasTxMonthlyAttendance_DayTypeBreakdown oDetail in oDBreakdown)
                                {
                                    oDetail.Delete();
                                }
                                oDelete.Delete();
                            }
                            #endregion

                            int iMonthIndex_ID = 0;
                            tbl_tasTxMonthlyAttendance oTxMonthlyAtten = tbl_tasTxMonthlyAttendance.SelectAll().Where(r => r.Company_ID == clsSecurity.CompanyID && r.CompanyBranch_ID == clsSecurity.BranchID).OrderByDescending(o => o.Index_ID).FirstOrDefault();
                            if (oTxMonthlyAtten != null)
                                iMonthIndex_ID = oTxMonthlyAtten.Index_ID + 1;

                            tbl_tasTxMonthlyAttendance oDetails = new tbl_tasTxMonthlyAttendance(clsSecurity.CompanyID, clsSecurity.BranchID, iMonthIndex_ID, oEmployee.AttendanceGroup1_ID, iProcessPeriodID,
                                    sEmployee_ID, oEmployee.Division_ID, oEmployee.Department_ID, oEmployee.SectionID, oEmployee.SubSectionID,
                                    dtmPeriodStartDate.Date, dtmPeriodEndDate.Date,
                                    dWorkMins_Mand, dWorkMins_Act,
                                    dNoPayMins, dNoPayMins_Act, dLatesMins, dLatesMins_Act,
                                    dWorkMins_OT_Normal, dWorkMins_OT_Act, 
                                    dWorkMins_OT_Double, dWorkMins_OT_Double_Act, 
                                    dWorkMins_OT_Triple, dWorkMins_OT_Triple_Act,
                                    dLeaveMins, dLeaveMins_Act, dGatePassMins, dGatePassMins_Act,
                                    dAttenIncentive,
                                    false, false,
                                    clsSecurity.UserIDLoged, "default", "default", "default", clsSecurity.TerminalID, "default", "default", "default",
                                    clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime);
                            oDetails.Insert();
                            #endregion

                            #region Filter Datatable
                            DataView dv = new DataView(dtDayBreakdown);
                            dv.RowFilter = " empID = '" + sEmployee_ID + "'";

                            var query = from table in dv.ToTable().AsEnumerable()
                                        group table by new { placeCol = table["dayTypeID"] } into grp
                                        orderby grp.Key.placeCol
                                        select new
                                        {
                                            dayTypeID = grp.Key.placeCol,
                                            workMins_Mand = grp.Sum(r => r.Field<decimal>("workMins_Mand")),
                                            workMins_Act = grp.Sum(r => r.Field<decimal>("workMins_Act")),
                                            lateHrsMins = grp.Sum(r => r.Field<decimal>("lateHrsMins")),
                                            noPayHrsMins = grp.Sum(r => r.Field<decimal>("noPayHrsMins")),
                                            workHrsMins_OT = grp.Sum(r => r.Field<decimal>("workHrsMins_OT")),
                                            workHrsMins_OT_Double = grp.Sum(r => r.Field<decimal>("workHrsMins_OT_Double")),
                                            workHrsMins_OT_Triple = grp.Sum(r => r.Field<decimal>("workHrsMins_OT_Triple")),
                                            leaveHrsMins = grp.Sum(r => r.Field<decimal>("leaveHrsMins")),
                                            gatePassHrsMins = grp.Sum(r => r.Field<decimal>("gatePassHrsMins"))
                                        }; 
                            #endregion

                            foreach (var data in query)
                            {
                                #region Breakdown Variable Initialize
                                //string dempID = row["empID"].ToString();
                                int idayTypeID = int.Parse(data.dayTypeID.ToString());

                                decimal dWorkingMin_Man_Breakdown = data.workMins_Mand;
                                decimal dWorkingMin_Act_Breakdown = data.workMins_Act;

                                decimal dLate_Breakdown = data.lateHrsMins;
                                decimal dNoPay_Breakdown = data.noPayHrsMins;
                                decimal dOT_Breakdown = data.workHrsMins_OT;
                                decimal dDOT_Breakdown = data.workHrsMins_OT_Double;
                                decimal dTOT_Breakdown = data.workHrsMins_OT_Triple;
                                decimal dLeave_Breakdown = data.leaveHrsMins;
                                decimal dGatePass_Breakdown = data.gatePassHrsMins; 
                                #endregion

                                #region Save Breakdown Raw Data
                                int iDayIndex_ID = 0;
                                tbl_tasTxMonthlyAttendance_DayTypeBreakdown oTxMonthlyDayBreak = tbl_tasTxMonthlyAttendance_DayTypeBreakdown.SelectAll().Where(r => r.Company_ID == clsSecurity.CompanyID && r.CompanyBranch_ID == clsSecurity.BranchID && r.MonthlyIndex_ID == iMonthIndex_ID).OrderByDescending(o => o.Index_ID).FirstOrDefault();
                                if (oTxMonthlyDayBreak != null)
                                    iDayIndex_ID = oTxMonthlyDayBreak.Index_ID + 1;

                                tbl_tasTxMonthlyAttendance_DayTypeBreakdown oBreakdown = new tbl_tasTxMonthlyAttendance_DayTypeBreakdown(clsSecurity.CompanyID, clsSecurity.BranchID,
                                    iMonthIndex_ID, iDayIndex_ID,
                                    idayTypeID,
                                    dWorkingMin_Man_Breakdown, dWorkingMin_Act_Breakdown,
                                    dNoPay_Breakdown, dLate_Breakdown,
                                    dOT_Breakdown, dDOT_Breakdown, dTOT_Breakdown,
                                    dLeave_Breakdown, dGatePass_Breakdown);
                                oBreakdown.Insert();
                                #endregion
                            }
                        }

                        SEACCMessageBox.Show("Employee(s) Attendance Saved Succesfully...!", "", MessageBoxButton.OK);
                    }
                    catch (Exception ex)
                    {
                        SEACCExeption.Show(ex);
                    }
                    finally
                    {
                        FrmWaiting.Close();
                        this.Cursor = Cursors.Arrow;
                    }
                }
            }
            else
            {
                SEACCMessageBox.Show("Process period has been already processed.", "", MessageBoxButton.OK);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            frm_WaitingMessege FrmWaiting = new frm_WaitingMessege();
            try
            {
                dgr_Main.dt.Clear();
                List<string> lsEmployees_AttenIssues = new List<string>();
                bool bMonth = true;

                if (!oSubPeriod.IsComplepted)
                {
                    #region Fill Attendance details
                    List<tbl_genMasEmployee> oEmpList = tbl_genMasEmployee.SelectAll();
                    if (sProcessGroupID != null && sProcessGroupID != "default")
                        oEmpList = oEmpList.Where(p => p.AttendanceGroup1_ID == sProcessGroupID).ToList();

                    foreach (tbl_genMasEmployee oEmployee in oEmpList.Where(p => p.Employee_ID != null && p.SurName != null && p.Department_ID != null && p.IsCanceled == false).OrderBy(o => o.EpfNo.PadLeft(4, '0')).ThenBy(o => o.Employee_ID.PadLeft(4, '0')))
                    {
                        #region Variables
                        decimal dWorkingMin_Man = 0, dWorkingMin_Act = 0;
                        decimal dOT_Normal_Min = 0, dOT_Double_Min = 0, dOT_Triple_Min = 0, dLate_Min = 0, dNoPay_Min = 0, dLeave_Min = 0, dGatePass_Min = 0;
                        decimal dOT_Normal_Min_Act = 0, dOT_Double_Min_Act = 0, dOT_Triple_Min_Act = 0, dLate_Min_Act = 0, dNoPay_Min_Act = 0, dLeave_Min_Act = 0, dGatePass_Min_Act = 0;

                        int iIndexID = -1;
                        decimal sShortLeave = 0;
                        int iIncentive = 0;
                        #endregion

                        #region Record Flushed
                        tbl_tasTxMonthlyAttendance oldRecords = tbl_tasTxMonthlyAttendance.SelectAllBy_EmployeeIDWithDateRange(oEmployee.Employee_ID, dtmPeriodStartDate.Date, dtmPeriodEndDate.Date).FirstOrDefault();
                        if (oldRecords != null)
                        {
                            List<tbl_tasTxMonthlyAttendance_DayTypeBreakdown> oldRecordsBreakdown = tbl_tasTxMonthlyAttendance_DayTypeBreakdown.SelectAll().Where(p => p.MonthlyIndex_ID == oldRecords.Index_ID).ToList();
                            foreach (tbl_tasTxMonthlyAttendance_DayTypeBreakdown detail in oldRecordsBreakdown)
                            {
                                detail.Delete();
                            }
                            oldRecords.Delete();
                        }
                        #endregion

                        #region Skip Resigned, Daily Attendance Note Saved and Full Month Daily Attendance Note Saved Employees
                        if (oEmployee.LastWorkingDate.Date != clsConfig.defaultDateTime.Date && dtmPeriodStartDate.Date > oEmployee.LastWorkingDate.Date)
                            continue;

                        decimal[] dEmployeeAttenData = clsHelpMethods.GetAttendanceDetails(oEmployee.Employee_ID, dtmPeriodStartDate.Date, dtmPeriodEndDate.Date);
                        if (dEmployeeAttenData[1] == 0)
                        {
                            lsEmployees_AttenIssues.Add(oEmployee.Employee_ID + " - " + oEmployee.Initails + " " + oEmployee.SurName);
                            continue;
                        }

                        TimeSpan tsCount = dtmPeriodEndDate.Date.AddHours(24).Subtract(dtmPeriodStartDate.Date);
                        List<tbl_tasTxDailyAttendance> oDaily = tbl_tasTxDailyAttendance.SelectAllBy_EmployeeIDWithDateRange(oEmployee.Employee_ID, dtmPeriodStartDate.Date, dtmPeriodEndDate.Date);
                        if (tsCount.TotalDays != oDaily.Count)
                        {
                            lsEmployees_AttenIssues.Add(oEmployee.Employee_ID + " - " + oEmployee.Initails + " " + oEmployee.SurName);
                            continue;
                        }
                        #endregion

                        #region New Records
                        //if (!bIsRecordExist)
                        //{
                        decimal[] dAttenData = clsHelpMethods.GetAttendanceDetails(oEmployee.Employee_ID, dtmPeriodStartDate.Date, dtmPeriodEndDate.Date);

                        #region Value Assign to Variable
                        dWorkingMin_Man = dAttenData[0];
                        dWorkingMin_Act = dAttenData[1];

                        dLate_Min = dAttenData[2];
                        dLeave_Min = dAttenData[6];
                        dGatePass_Min = dAttenData[7];
                        dNoPay_Min = dAttenData[3];

                        dOT_Normal_Min = dAttenData[4];
                        dOT_Double_Min = dAttenData[5];
                        dOT_Triple_Min = dAttenData[8];

                        dLate_Min_Act = dAttenData[2];
                        dLeave_Min_Act = dAttenData[6];
                        dGatePass_Min_Act = dAttenData[7];
                        dNoPay_Min_Act = dAttenData[3];

                        dOT_Normal_Min_Act = dAttenData[4];
                        dOT_Double_Min_Act = dAttenData[5];
                        dOT_Triple_Min_Act = dAttenData[8];
                        #endregion

                        #region Get Weekly Fixed OT
                        decimal dOT_Normal = 0;
                        List<tbl_tasTxWeeklyAttendance> oWeekList = tbl_tasTxWeeklyAttendance.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, oEmployee.Employee_ID);
                        foreach (tbl_tasTxWeeklyAttendance oWeek in oWeekList.Where(p => p.Period_EndDate >= dtmPeriodStartDate.Date && p.Period_EndDate <= dtmPeriodEndDate.Date))
                        {
                            dOT_Normal += oWeek.WeeklyFixed_OT;
                        }
                        dOT_Normal_Min += dOT_Normal;
                        dOT_Normal_Min_Act += dOT_Normal;
                        #endregion

                        #region No Pay Deduction
                        List<tbl_tasEmployeeLeaveCard> oLeaveCardList = tbl_tasEmployeeLeaveCard.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, oEmployee.Employee_ID);
                        foreach (tbl_tasEmployeeLeaveCard oLeaveCard in oLeaveCardList.Where(p => p.LeaveType_ID == clsConfig.sShortLeaveID && p.Leave_Start >= dtmPeriodStartDate.Date && p.Leave_End <= dtmPeriodEndDate.Date && !p.IsCancled))
                        {
                            //sShortLeave = oLeaveCard.Leaves_Utilized;
                            sShortLeave += (decimal)oLeaveCard.Leave_End.Subtract(oLeaveCard.Leave_Start).TotalMinutes;
                        }

                        if (sShortLeave > 0m)
                        {
                            if (dOT_Normal_Min_Act >= sShortLeave)
                            {
                                dOT_Normal_Min_Act -= sShortLeave;
                                //dNoPay_Min -= sShortLeave;
                            }
                            else if (dOT_Normal_Min_Act < sShortLeave)
                            {
                                dOT_Normal_Min_Act -= dOT_Normal_Min_Act;
                                //sShortLeave -= sShortLeave;
                            }
                        }
                        #endregion

                        #region Late Time Validation
                        if (clsConfig.bLateCalculation_DeductGivenLateMaxTime)
                            dLate_Min_Act = dLate_Min_Act - 30;
                        //else
                        //    dLate_Min = dLate_Min;

                        dLate_Min_Act = dLate_Min_Act < 0 ? 0 : dLate_Min_Act;
                        #endregion

                        #region Attendance Incentive Calculation
                        List<tbl_tasEmployeeLeaveCard> oCard_List = tbl_tasEmployeeLeaveCard.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, oEmployee.Employee_ID).Where(p => p.Leave_Start >= dtmPeriodStartDate.Date && p.Leave_End <= dtmPeriodEndDate.Date && p.LeaveType_ID != clsConfig.sShortLeaveID).ToList();
                        if (dLeave_Min_Act == 0 && dNoPay_Min_Act == 0)
                        {

                            decimal dNoPayMin_LastMonth = 0, dLeaveMin_LastMonth = 0;
                            tbl_tasTxMonthlyAttendance oMonthlyAttendance_List = tbl_tasTxMonthlyAttendance.SelectAllBy_EmployeeIDWithDateRange(oEmployee.Employee_ID, dtmPeriodStartDate.Date.AddMonths(-1), dtmPeriodStartDate.Date.AddDays(-1)).FirstOrDefault();
                            if (oMonthlyAttendance_List != null)
                            {
                                dNoPayMin_LastMonth = oMonthlyAttendance_List.NoPayMinutes;
                                dLeaveMin_LastMonth = oMonthlyAttendance_List.LeaveMinutes;
                            }

                            if (dNoPayMin_LastMonth == 0 && dLeaveMin_LastMonth == 0)
                                iIncentive = 3;
                            else
                                iIncentive = 2;
                        }
                        else if (dLeave_Min_Act > 0 || dNoPay_Min_Act > 0)
                            iIncentive = 1;
                        else if ((dLeave_Min_Act > 0 || dNoPay_Min_Act > 0) && oCard_List.Count > 1)
                            iIncentive = 0;
                        #endregion
                        //}
                        #endregion

                        #region Fill Data Grid
                        dgr_Main.dt.Rows.Add(iIndexID,
                            oEmployee.Employee_ID,
                            oEmployee.SurName + " ," + oEmployee.Initails,
                            clsRef_Name.get_Division_Name(oEmployee.Division_ID),
                            clsRef_Name.get_Department_Name(oEmployee.Department_ID),
                            clsRef_Name.get_Section_Name(oEmployee.SectionID),
                            clsRef_Name.get_SubSection_Name(oEmployee.SubSectionID),
                            clsRef_Name.get_Attendance_ProcessGroup1(oEmployee.AttendanceGroup1_ID),
                            clsRef_Name.get_Attendance_ProcessGroup1(oEmployee.AttendanceGroup1_ID),

                            cls_Formater.FormatDecimal(dWorkingMin_Man / 60, 2),//working man
                            ConvertMinsToHrsMins(dWorkingMin_Man),

                            cls_Formater.FormatDecimal(dWorkingMin_Act / 60, 2),//working act
                            ConvertMinsToHrsMins(dWorkingMin_Act),

                            cls_Formater.FormatDecimal(dLate_Min_Act / 60, 2),//late
                            ConvertMinsToHrsMins(dLate_Min_Act),

                            cls_Formater.FormatDecimal(dNoPay_Min / 60, 2),//nopay
                            ConvertMinsToHrsMins(dNoPay_Min),

                            cls_Formater.FormatDecimal(dOT_Normal_Min / 60, 2),//actual worked ot
                            ConvertMinsToHrsMins(dOT_Normal_Min),

                            cls_Formater.FormatDecimal(dOT_Normal_Min_Act / 60, 2),//actual ot
                            ConvertMinsToHrsMins(dOT_Normal_Min_Act),

                            cls_Formater.FormatDecimal(dOT_Double_Min / 60, 2),//double
                            ConvertMinsToHrsMins(dOT_Double_Min),

                            cls_Formater.FormatDecimal(dOT_Double_Min / 60, 2),//double sunday
                            ConvertMinsToHrsMins(dOT_Double_Min),

                            cls_Formater.FormatDecimal(dOT_Triple_Min / 60, 2),//triple ot
                            ConvertMinsToHrsMins(dOT_Triple_Min),

                            cls_Formater.FormatDecimal(dLeave_Min / 60, 2),//leave
                            ConvertMinsToHrsMins(dLeave_Min),

                            cls_Formater.FormatDecimal(dGatePass_Min / 60, 2),//gate pass
                            ConvertMinsToHrsMins(dGatePass_Min),

                            iIncentive

                            );
                        #endregion

                        #region Generate Day Breakdown
                        for (DateTime dDate = dtmPeriodStartDate.Date; dDate.Date <= dtmPeriodEndDate.Date; dDate = dDate.AddDays(1))
                        {
                            DateTime dtStartDate = dDate.Date;
                            DateTime dtEndDate = dDate.Date;
                            int iDayType = (int)DayTypes.WorkingDay;
                            string sDayType = DayTypes.WorkingDay.ToString();
                            decimal dFixedOT = 0;
                            if (dDate.DayOfWeek != DayOfWeek.Saturday && dDate.DayOfWeek != DayOfWeek.Sunday)
                            {
                                while (dDate.DayOfWeek != DayOfWeek.Friday)//wednesday --> //friday
                                    dDate = dDate.AddDays(1);

                                dtEndDate = dDate.Date;//(friday)

                                //DateTime weekday = dDate.Date; //wednesday
                                //while (weekday.DayOfWeek != DayOfWeek.Friday)//friday
                                //    weekday = weekday.AddDays(1);

                                //dtEndDate = weekday.Date;//(friday)
                                //dDate = weekday.Date;//set to (friday)
                            }

                            if (dDate.DayOfWeek == DayOfWeek.Saturday)
                            {
                                iDayType = (int)DayTypes.Saturday;
                                sDayType = DayTypes.Saturday.ToString();
                            }
                            else if (dDate.DayOfWeek == DayOfWeek.Sunday)
                            {
                                iDayType = (int)DayTypes.Sunday;
                                sDayType = DayTypes.Sunday.ToString();

                                foreach (tbl_tasTxWeeklyAttendance oWeek in oWeekList.Where(p => p.Period_EndDate == dDate.Date))
                                {
                                    dFixedOT += oWeek.WeeklyFixed_OT;
                                }
                            }

                            decimal[] dAttenData_Breakdown = clsHelpMethods.GetAttendanceDetails(oEmployee.Employee_ID, dtStartDate.Date, dtEndDate.Date);

                            dtDayBreakdown.Rows.Add(oEmployee.Employee_ID, oEmployee.FullName, iDayType, sDayType,
                                dAttenData_Breakdown[0], dAttenData_Breakdown[1],
                                dAttenData_Breakdown[2], dAttenData_Breakdown[3],
                                (dAttenData_Breakdown[4] + dFixedOT), dAttenData_Breakdown[5], dAttenData_Breakdown[8],
                                dAttenData_Breakdown[6], dAttenData_Breakdown[7]);

                        }
                        
                        FilterDay_Breakdown(oEmployee.Employee_ID, (dgr_Main.dt.Rows.Count - 1));
                        #endregion
                    }
                    #endregion

                    #region Show Daily Attendance Not Saved Employees
                    if (lsEmployees_AttenIssues.Count > 0)
                    {
                        string sMessageBody_ShiftErrorEmployees = "";
                        foreach (string sEmp in lsEmployees_AttenIssues)
                            sMessageBody_ShiftErrorEmployees += sEmp + " \n";

                        SEACCMessageBox.Show("Daily Attendance Not Saved...!", sMessageBody_ShiftErrorEmployees + "", MessageBoxButton.OK);
                    }
                    #endregion
                }
                else
                {
                    #region Get Existing Record
                    //bool bIsRecordExist = false;
                    List<tbl_tasTxMonthlyAttendance> oMonthlyAttendance = tbl_tasTxMonthlyAttendance.SelectAllByCompany_ID_CompanyBranch_ID_AttenProcessGroup_ID_AttenProcessPeriod_ID(clsSecurity.CompanyID, clsSecurity.BranchID, sProcessGroupID, iProcessPeriodID).Where(p => p.AttenProcessPeriod_startDate >= dtmPeriodStartDate.Date && p.AttenProcessPeriod_endDate <= dtmPeriodEndDate.Date).ToList();
                    foreach (tbl_tasTxMonthlyAttendance oOldRecord in oMonthlyAttendance)
                    {
                        decimal dSundayOT = 0;
                        tbl_tasTxMonthlyAttendance_DayTypeBreakdown oDayBreakdown = tbl_tasTxMonthlyAttendance_DayTypeBreakdown.SelectAll().Where(p => p.MonthlyIndex_ID == oOldRecord.Index_ID && p.DayType_ID == (int)DayTypes.Sunday).FirstOrDefault();
                        if (oDayBreakdown != null)
                            dSundayOT = oDayBreakdown.WorkingMinutesAct_OT_Dub;

                        #region Fill Data Grid
                        dgr_Main.dt.Rows.Add(oOldRecord.Index_ID,
                            oOldRecord.Employee_ID,
                            clsRef_Name.get_EmployeeShortName_initialsFirst(oOldRecord.Employee_ID),
                            clsRef_Name.get_Division_Name(oOldRecord.Division_ID),
                            clsRef_Name.get_Department_Name(oOldRecord.Department_ID),
                            clsRef_Name.get_Section_Name(oOldRecord.SectionID),
                            clsRef_Name.get_SubSection_Name(oOldRecord.SubSectionID),
                            clsRef_Name.get_Attendance_ProcessGroup1(oOldRecord.AttenProcessGroup_ID),
                            clsRef_Name.get_Attendance_ProcessGroup1(oOldRecord.AttenProcessGroup_ID),

                            cls_Formater.FormatDecimal(oOldRecord.WorkingMinutes_Mand / 60, 2),//working man
                            ConvertMinsToHrsMins(oOldRecord.WorkingMinutes_Mand),

                            cls_Formater.FormatDecimal(oOldRecord.WorkingMinutes_Act / 60, 2),//working act
                            ConvertMinsToHrsMins(oOldRecord.WorkingMinutes_Act),

                            cls_Formater.FormatDecimal(oOldRecord.LateMinutes / 60, 2),//late
                            ConvertMinsToHrsMins(oOldRecord.LateMinutes),

                            cls_Formater.FormatDecimal(oOldRecord.NoPayMinutes / 60, 2),//nopay
                            ConvertMinsToHrsMins(oOldRecord.NoPayMinutes),

                            cls_Formater.FormatDecimal(oOldRecord.WorkingMinutes_OT / 60, 2),//actual worked ot
                            ConvertMinsToHrsMins(oOldRecord.WorkingMinutes_OT),

                            cls_Formater.FormatDecimal(oOldRecord.WorkingMinutes_OT_Act / 60, 2),//actual ot
                            ConvertMinsToHrsMins(oOldRecord.WorkingMinutes_OT_Act),

                            cls_Formater.FormatDecimal(oOldRecord.WorkingMinutes_OT_Dub / 60, 2),//double
                            ConvertMinsToHrsMins(oOldRecord.WorkingMinutes_OT_Dub),

                            cls_Formater.FormatDecimal(dSundayOT / 60, 2),//double sunday
                            ConvertMinsToHrsMins(dSundayOT),

                            cls_Formater.FormatDecimal(oOldRecord.WorkingMinutes_OT_Trpl / 60, 2),//triple ot
                            ConvertMinsToHrsMins(oOldRecord.WorkingMinutes_OT_Trpl),

                            cls_Formater.FormatDecimal(oOldRecord.LeaveMinutes / 60, 2),//leave
                            ConvertMinsToHrsMins(oOldRecord.LeaveMinutes),

                            cls_Formater.FormatDecimal(oOldRecord.GatePassMinutes / 60, 2),//gate pass
                            ConvertMinsToHrsMins(oOldRecord.GatePassMinutes),

                            oOldRecord.AttendanceIncentive);
                        #endregion
                    }
                    #endregion
                }                
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Something went wrong...", ex.Message, MessageBoxButton.OK);
            }
            finally
            {
                dgr_Main.RefreshGrid();
                FrmWaiting.Close();
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
                string sEmployee_ID = dgr_Main.dt.Rows[irowID]["empID"].ToString();
                string sMessage = "";

                #region Filter Datatable using Linq
                DataView dv = new DataView(dtDayBreakdown);
                dv.RowFilter = " empID = '" + sEmployee_ID + "'";

                var query = from row in dv.ToTable().AsEnumerable()
                            group row by new { placeCol = row["dayTypeID"] } into grp
                            orderby grp.Key.placeCol
                            select new
                            {
                                dayTypeID = grp.Key.placeCol,
                                workMins_Mand = grp.Sum(r => r.Field<decimal>("workMins_Mand")),
                                workMins_Act = grp.Sum(r => r.Field<decimal>("workMins_Act")),
                                lateHrsMins = grp.Sum(r => r.Field<decimal>("lateHrsMins")),
                                noPayHrsMins = grp.Sum(r => r.Field<decimal>("noPayHrsMins")),
                                workHrsMins_OT = grp.Sum(r => r.Field<decimal>("workHrsMins_OT")),
                                workHrsMins_OT_Double = grp.Sum(r => r.Field<decimal>("workHrsMins_OT_Double")),
                                workHrsMins_OT_Triple = grp.Sum(r => r.Field<decimal>("workHrsMins_OT_Triple")),
                                leaveHrsMins = grp.Sum(r => r.Field<decimal>("leaveHrsMins")),
                                gatePassHrsMins = grp.Sum(r => r.Field<decimal>("gatePassHrsMins"))
                            };
                #endregion

                //var datas = query.FirstOrDefault();
                //int idayTypeID = int.Parse(datas.dayTypeID.ToString());

                //if (idayTypeID == (int)DayTypes.WorkingDay)
                //    dr["TotalHours_Display_E"] = datas.workHrsMins_OT_Double;
                //else if (idayTypeID == (int)DayTypes.Sunday)
                //    dr["TotalHours_Display_E"] = datas.workHrsMins_OT_Double;

                foreach (var data in query)
                {
                    //string dempID = row["empID"].ToString();
                    int idayTypeID = int.Parse(data.dayTypeID.ToString());

                    decimal dWorkHrsMins_Mand = data.workMins_Mand;
                    decimal dWorkHrsMins_Act = data.workMins_Act;

                    decimal dlateHrsMins = data.lateHrsMins;
                    decimal dnoPayHrsMins = data.noPayHrsMins;
                    decimal dworkHrsMins_OT = data.workHrsMins_OT;
                    decimal dworkHrsMins_OT_Double = data.workHrsMins_OT_Double;
                    decimal dworkHrsMins_OT_Triple = data.workHrsMins_OT_Triple;
                    decimal dleaveHrsMins = data.leaveHrsMins;
                    decimal dgatePassHrsMins = data.gatePassHrsMins;

                    sMessage += sEmployee_ID + " / " + idayTypeID.ToString() + " / " + ConvertMinsToHrsMins(dWorkHrsMins_Act) + " / " + ConvertMinsToHrsMins(dlateHrsMins)
                        + " / " + ConvertMinsToHrsMins(dnoPayHrsMins) + " / " + ConvertMinsToHrsMins(dworkHrsMins_OT) + " / " + ConvertMinsToHrsMins(dworkHrsMins_OT_Double) + " \n";

                }

                MessageBox.Show(sMessage);
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        private void dgr_Main_DG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var vDG_Cell = dgr_Main.GetCurrentCell();
            int irowID = dgr_Main.SelectedIndex;

            try
            {
                dgr_Main_MouseLeftButtonUp1(sender, e);
                //string sEmployeeid = dgr_Main.dt.Rows[irowID]["empID"].ToString();

                //if (vDG_Cell.Column.SortMemberPath == "workHrs_Mand" || vDG_Cell.Column.SortMemberPath == "workHrsMins_Mand" || vDG_Cell.Column.SortMemberPath == "workHrs_Act" || vDG_Cell.Column.SortMemberPath == "workHrsMins_Act")
                //{
                //    UC_AttendanceEntry UC = new UC_AttendanceEntry();
                //    if (UC.SEACC_Form.PermissionTO_Read)
                //    {
                //        UC.EmployeeWithDurationSelect(sEmployeeid, dtmPeriodStartDate, dtmPeriodEndDate);
                //        frm_SEACC_Window SW = new frm_SEACC_Window(UC, UC.SEACC_Form.FormName);

                //        SW.ShowDialog();
                //    }
                //}
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Filter Day Breakdown
        private void FilterDay_Breakdown(string sEmployee_ID, int iRowID)
        {
            string sMessage = "";

            #region Filter Datatable using Linq
            DataRow dr = dgr_Main.dt.Rows[iRowID];

            DataView dv = new DataView(dtDayBreakdown);
            dv.RowFilter = " empID = '" + sEmployee_ID + "'";

            var query = from row in dv.ToTable().AsEnumerable()
                        group row by new { placeCol = row["dayTypeID"] } into grp
                        orderby grp.Key.placeCol
                        select new
                        {
                            dayTypeID = grp.Key.placeCol,
                            workMins_Mand = grp.Sum(r => r.Field<decimal>("workMins_Mand")),
                            workMins_Act = grp.Sum(r => r.Field<decimal>("workMins_Act")),
                            workHrsMins_OT = grp.Sum(r => r.Field<decimal>("workHrsMins_OT")),
                            workHrsMins_OT_Double = grp.Sum(r => r.Field<decimal>("workHrsMins_OT_Double")),
                        };
            #endregion

            //var datas = query.FirstOrDefault();
            //int idayTypeID = int.Parse(datas.dayTypeID.ToString());

            //if (idayTypeID == (int)DayTypes.WorkingDay)
            //    dr["TotalHours_Display_E"] = datas.workHrsMins_OT_Double;
            //else if (idayTypeID == (int)DayTypes.Sunday)
            //    dr["TotalHours_Display_E"] = datas.workHrsMins_OT_Double;

            foreach (var data in query)
            {
                //string dempID = row["empID"].ToString();
                int idayTypeID = int.Parse(data.dayTypeID.ToString());

                if (idayTypeID == (int)DayTypes.WorkingDay)
                {
                    dr["workHrs_OT_Double"] = cls_Formater.FormatDecimal(data.workHrsMins_OT_Double / 60, 2);
                    dr["workHrsMins_OT_Double"] = ConvertMinsToHrsMins(data.workHrsMins_OT_Double);
                }
                else if (idayTypeID == (int)DayTypes.Sunday)
                {
                    dr["workHrs_OT_Double_Sunday"] = cls_Formater.FormatDecimal(data.workHrsMins_OT_Double / 60, 2);
                    dr["workHrsMins_OT_Double_Sunday"] = ConvertMinsToHrsMins(data.workHrsMins_OT_Double);
                }
            }
        } 
        #endregion

        #region Help Methods
        private string ConvertMinsToHrsMins(decimal dTotMins)
        {
            decimal dMins = dTotMins % 60;
            decimal dHrs = (dTotMins - dMins) / 60;
            return dHrs.ToString("00") + ":" + dMins.ToString("00");
        }
        #endregion

    }
}

#region Commented
//tbl_hrPeriod_Month oMonth = tbl_hrPeriod_Month.SelectAll().Where(p => p.Month_startDate >= dtmPeriodStartDate.Date && p.Month_endDate <= dtmPeriodEndDate.Date).FirstOrDefault();
//if (oMonth.Month_ID == null)
//{
//    bMonth = false;
//    break;
//}   

//foreach (tbl_hrPeriod_Week oWeek in tbl_hrPeriod_Week.SelectAll().Where(p => p.Month_ID == oMonth.Month_ID))
//{
//tbl_tasTxDailyAttendance oWeekly = tbl_tasTxDailyAttendance.SelectAllBy_EmployeeIDWithDateRange(detail.Employee_ID, dtmPeriodStartDate.Date, dtmPeriodEndDate.Date).FirstOrDefault();
//    if (oWeekly.Employee_ID != null)
//    {
//        dWorkingMin_Man += oWeekly.WorkingMinutes_Mand;
//        dWorkingMin_Act += oWeekly.WorkingMinutes_Act;
//        dLate_Min += oWeekly.LateMinutes;
//        dLeave_Min += oWeekly.LeaveMinutes;
//        dGatePass_Min += oWeekly.GatePassMinutes;
//        //dNopay_Act += oWeekly.NoPayMinutes; 
//        dNoPay_Min += oWeekly.NoPayMinutes; 
//        dOT_Act_Min += oWeekly.WorkingMinutesAct_OT; 
//        dOT_Normal_Min += oWeekly.WorkingMinutesAct_OT; 
//        dOT_Double_Min += oWeekly.WorkingMinutesAct_OT_Dub;
//        dOT_Triple_Min += oWeekly.WorkingMinutesAct_OT_Trpl; 
//    }
//} 
#endregion