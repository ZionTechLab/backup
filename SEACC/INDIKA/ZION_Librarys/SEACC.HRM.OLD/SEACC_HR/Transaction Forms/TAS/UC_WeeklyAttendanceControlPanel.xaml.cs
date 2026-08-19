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

namespace Digiteq
{
    /**
     * Developped by Janith 
     * On 2018-05 for SLEMO Project
     * */
    public partial class UC_WeeklyAttendanceControlPanel : UserControl
    {
        #region Form Load
        public UC_WeeklyAttendanceControlPanel()
        {
            #region Initialize Form
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Weekly_AttendanceControl_Panel;
            SEACC_Form.Initialize();
            #endregion

            #region Acction Button
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false);
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            this.SEACC_Form.btn_New.Click += btn_New_Click;
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

            dgr_Main.dt.Columns.Add("weeklyHrs_OT_Fixed");
            dgr_Main.dt.Columns.Add("weeklyHrsMins_OT_Fixed");//new
            dgr_Main.dt.Columns.Add("workHrs_OT_Normal");
            dgr_Main.dt.Columns.Add("workHrsMins_OT_Normal");//new
            dgr_Main.dt.Columns.Add("workHrs_OT_Double");
            dgr_Main.dt.Columns.Add("workHrsMins_OT_Double");//new
            dgr_Main.dt.Columns.Add("workHrs_OT_Triple");
            dgr_Main.dt.Columns.Add("workHrsMins_OT_Triple");//new

            dgr_Main.dt.Columns.Add("leaveHrs");
            dgr_Main.dt.Columns.Add("leaveHrsMins");//new
            dgr_Main.dt.Columns.Add("gatePassHrs");
            dgr_Main.dt.Columns.Add("gatePassHrsMins");//new

            dgr_Main.dt.Columns.Add("foreground");//new
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

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Fixed OT hh.", "weeklyHrs_OT_Fixed", 90, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Fixed OT hh:mm", "weeklyHrsMins_OT_Fixed", 100, !clsConfig.bPayrollRawDataShow_HoursOnly, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "OT Normal hh.", "workHrs_OT_Normal", 100, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "OT Normal hh:mm", "workHrsMins_OT_Normal", 110, !clsConfig.bPayrollRawDataShow_HoursOnly, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "OT Double hh.", "workHrs_OT_Double", 100, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "OT Double hh:mm", "workHrsMins_OT_Double", 110, !clsConfig.bPayrollRawDataShow_HoursOnly, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "OT Triple hh.", "workHrs_OT_Triple", 100, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "OT Triple hh:mm", "workHrsMins_OT_Triple", 110, !clsConfig.bPayrollRawDataShow_HoursOnly, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Leave hh", "leaveHrs", 90, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Leave hh:mm", "leaveHrsMins", 90, !clsConfig.bPayrollRawDataShow_HoursOnly, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Gatepass hh.", "gatePassHrs", 100, clsConfig.bPayrollRawDataShow_HoursOnly, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Gatepass hh:mm", "gatePassHrsMins", 110, !clsConfig.bPayrollRawDataShow_HoursOnly, true);
            #endregion

            ClearFields();
        }
        #endregion

        #region Action Buttons
        public void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                frm_WaitingMessege FrmWaiting = new frm_WaitingMessege();
                try
                {
                    DateTime dtmPeriodStartDate = dtp_FromDate.GetDateTime();
                    DateTime dtmPeriodEndDate = dtp_ToDate.GetDateTime();
                    List<string> lsEmployees_SavedMonth = new List<string>();
                    bool bInserted = false;

                    foreach (DataRow row in dgr_Main.dt.Rows)
                    {
                        #region Variables Initialize
                        string sEmployee_ID = row["empID"].ToString();
                        decimal dWorkMins_Mand = clsValidation.GetMinutes(row["workHrsMins_Mand"].ToString());
                        decimal dWorkMins_Act = clsValidation.GetMinutes(row["workHrsMins_Act"].ToString());
                        decimal dNoPayMins = clsValidation.GetMinutes(row["noPayHrsMins"].ToString());
                        decimal dLatesMins = clsValidation.GetMinutes(row["lateHrsMins"].ToString());
                        decimal dWorkMins_OT_Fixed = clsValidation.GetMinutes(row["weeklyHrsMins_OT_Fixed"].ToString());
                        decimal dWorkMins_OT_Normal = clsValidation.GetMinutes(row["workHrsMins_OT_Normal"].ToString());
                        decimal dWorkMins_OT_Double = clsValidation.GetMinutes(row["workHrsMins_OT_Double"].ToString());
                        decimal dWorkMins_OT_Triple = clsValidation.GetMinutes(row["workHrsMins_OT_Triple"].ToString());
                        decimal dLeaveMins = clsValidation.GetMinutes(row["leaveHrsMins"].ToString());
                        decimal dGatePassMins = clsValidation.GetMinutes(row["gatePassHrsMins"].ToString());
                        #endregion

                        tbl_genMasEmployee oEmployee = tbl_genMasEmployee.Select(sEmployee_ID, clsSecurity.CompanyID, clsSecurity.BranchID);

                        DateTime dtFromDate = new DateTime(dtmPeriodEndDate.Year, dtmPeriodEndDate.Month, 1);
                        DateTime dtToDate = dtFromDate.AddMonths(1).AddDays(-1);

                        tbl_tasTxMonthlyAttendance oMonthly = tbl_tasTxMonthlyAttendance.SelectAllBy_EmployeeIDWithDateRange(oEmployee.Employee_ID, dtFromDate.Date, dtToDate.Date).OrderByDescending(o => o.AttenProcessPeriod_startDate).FirstOrDefault();
                        if (oMonthly != null)
                        {
                            lsEmployees_SavedMonth.Add(oEmployee.Employee_ID + " - " + oEmployee.Initails + " " + oEmployee.SurName);
                            continue;
                        }

                        tbl_tasTxWeeklyAttendance oldRecords = tbl_tasTxWeeklyAttendance.SelectAllBy_EmployeeIDWithDateRange(sEmployee_ID, dtmPeriodStartDate.Date, dtmPeriodEndDate.Date).FirstOrDefault();
                        if (oldRecords != null)
                            oldRecords.Delete();

                        #region Insert Record
                        int iIndex_ID = 0;
                        tbl_tasTxWeeklyAttendance oTxWeeklyAtten = tbl_tasTxWeeklyAttendance.SelectAll().Where(r => r.Company_ID == clsSecurity.CompanyID && r.CompanyBranch_ID == clsSecurity.BranchID).OrderByDescending(o => o.Index_ID).FirstOrDefault();
                        if (oTxWeeklyAtten != null)
                            iIndex_ID = oTxWeeklyAtten.Index_ID + 1;

                        tbl_tasTxWeeklyAttendance oDetails = new tbl_tasTxWeeklyAttendance(clsSecurity.CompanyID, clsSecurity.BranchID, iIndex_ID, dtmPeriodStartDate.Date, dtmPeriodEndDate.Date,
                            sEmployee_ID, oEmployee.Division_ID, oEmployee.Department_ID, oEmployee.SectionID, oEmployee.SubSectionID, oEmployee.EmpCatagory1_ID, oEmployee.EmpCatagory2_ID, oEmployee.EmpCatagory3_ID,
                            oEmployee.AttendanceGroup1_ID, oEmployee.AttendanceGroup2_ID, oEmployee.IsTime_Attendance,
                            0, 0, dWorkMins_Mand, dWorkMins_Act,
                            dNoPayMins, dLatesMins,
                            dWorkMins_OT_Fixed, dWorkMins_OT_Normal, dWorkMins_OT_Double, dWorkMins_OT_Triple,
                            dLeaveMins, dGatePassMins,
                            false, false,
                            clsSecurity.UserIDLoged, "default", "default", "default", clsSecurity.TerminalID, "default", "default", "default",
                            clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime);
                        oDetails.Insert();

                        bInserted = true;
                        #endregion

                    }

                    if (lsEmployees_SavedMonth.Count > 0)
                    {
                        string sMessageBody = "";
                        foreach (string sEmp in lsEmployees_SavedMonth)
                            sMessageBody += sEmp + " \n";

                        SEACCMessageBox.Show("Something went wrong...", "Already Saved Monthly Attendance Data " + sMessageBody + " to this Month...... ", MessageBoxButton.OK);
                    }

                    if (bInserted)
                        SEACCMessageBox.Show("Employee(s) Weekly Attendance Saved Succesfully...!", "", MessageBoxButton.OK);
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
        }
        #endregion

        #region Load Button
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            if (CheckWeekSelected())
            {
                frm_WaitingMessege FrmWaiting = new frm_WaitingMessege();
                try
                {
                    DateTime dtmPeriodStartDate = dtp_FromDate.GetDateTime();
                    DateTime dtmPeriodEndDate = dtp_ToDate.GetDateTime();

                    dgr_Main.dt.Clear();
                    List<string> lsEmployees_AttenIssues = new List<string>();
                    List<string> lsEmployees_HalfAttenIssues = new List<string>();

                    #region Fill Payroll details
                    List<tbl_genMasEmployee> oEmpList = tbl_genMasEmployee.SelectAll();
                    if (txtGroup.Tag != null)
                        oEmpList = oEmpList.Where(p => p.AttendanceGroup1_ID == txtGroup.Tag.ToString()).ToList();

                    foreach (tbl_genMasEmployee detail in oEmpList.Where(p => p.Employee_ID != null && p.SurName != null && p.Department_ID != null && p.IsCanceled == false).OrderBy(o => o.EpfNo.PadLeft(4, '0')).ThenBy(o => o.Employee_ID.PadLeft(4, '0')))
                    {
                        #region Variables
                        decimal dWorkingMin_Man = 0, dWorkingMin_Act = 0;
                        decimal dOT_Fixed_Min = 0, dOT_Normal_Min = 0, dOT_Double_Min = 0, dOT_Triple_Min = 0, dLate_Min = 0, dNoPay_Min = 0, dLeave_Min = 0, dGatePass_Min = 0;
                        int iIndexID = -1;

                        decimal dOT_Actual = 0;
                        #endregion

                        if (detail.LastWorkingDate.Date != clsConfig.defaultDateTime.Date && dtmPeriodStartDate.Date > detail.LastWorkingDate.Date)
                            continue;

                        decimal[] dEmployeeAttenData = clsHelpMethods.GetAttendanceDetails(detail.Employee_ID, dtmPeriodStartDate.Date, dtmPeriodEndDate.Date);
                        if (dEmployeeAttenData[1] == 0)
                        {
                            lsEmployees_AttenIssues.Add(detail.Employee_ID + " - " + detail.Initails + " " + detail.SurName);
                            continue;
                        }

                        TimeSpan tsCount = dtmPeriodEndDate.Date.AddHours(24).Subtract(dtmPeriodStartDate.Date);
                        List<tbl_tasTxDailyAttendance> oDaily = tbl_tasTxDailyAttendance.SelectAllBy_EmployeeIDWithDateRange(detail.Employee_ID, dtmPeriodStartDate.Date, dtmPeriodEndDate.Date);
                        if (tsCount.TotalDays != oDaily.Count)
                        {
                            lsEmployees_AttenIssues.Add(detail.Employee_ID + " - " + detail.Initails + " " + detail.SurName);
                            continue;
                        }

                        List<tbl_tasTxWeeklyAttendance> oWeeklyAttendance = tbl_tasTxWeeklyAttendance.SelectAllBy_EmployeeIDWithDateRange(detail.Employee_ID, dtmPeriodStartDate.Date, dtmPeriodEndDate.Date).ToList();

                        #region Get Existing Record
                        bool bIsRecordExist = false;
                        foreach (tbl_tasTxWeeklyAttendance oOldRecord in oWeeklyAttendance)
                        {
                            bIsRecordExist = true;

                            iIndexID = oOldRecord.Index_ID;

                            dWorkingMin_Man = oOldRecord.WorkingMinutes_Mand; //workMin Man
                            dWorkingMin_Act = oOldRecord.WorkingMinutes_Act;//workMin Act
                            dOT_Fixed_Min = oOldRecord.WeeklyFixed_OT;//fixed ot
                            dOT_Normal_Min = oOldRecord.WorkingMinutesAct_OT; //OT Normal - min
                            dOT_Double_Min = oOldRecord.WorkingMinutesAct_OT_Dub; //Ot Double
                            dOT_Triple_Min = oOldRecord.WorkingMinutesAct_OT_Trpl; //OT Triple
                            dLate_Min = oOldRecord.LateMinutes; //Late
                            dNoPay_Min = oOldRecord.NoPayMinutes; //Nopay
                            dLeave_Min = oOldRecord.LeaveMinutes; //Leave
                            dGatePass_Min = oOldRecord.GatePassMinutes; //Gate Pass
                        }
                        #endregion

                        #region New Records
                        if (!bIsRecordExist)
                        {
                            decimal[] dAttenData = clsHelpMethods.GetAttendanceDetails(detail.Employee_ID, dtmPeriodStartDate.Date, dtmPeriodEndDate.Date);

                            dWorkingMin_Man = dAttenData[0]; //workMin Man
                            dWorkingMin_Act = dAttenData[1]; //workMin Act
                            dLate_Min = dAttenData[2]; //Late
                            dNoPay_Min = dAttenData[3]; //Nopay
                            dOT_Normal_Min = dAttenData[4]; //OT Normal - min
                            dOT_Double_Min = dAttenData[5]; //Ot Double
                            dLeave_Min = dAttenData[6]; //Leave
                            dGatePass_Min = dAttenData[7]; //Gate Pass
                            dOT_Triple_Min = dAttenData[8]; //OT Triple

                            TimeSpan tsMandatoryMin_Inc = new TimeSpan(45, 0, 0);
                            TimeSpan tsWorkingMin_Inc = new TimeSpan(24, 0, 0);
                            TimeSpan tsOTMin_Inc = new TimeSpan(3, 0, 0);

                            decimal dMandatoryMin_Inc = clsValidation.GetMinutes(tsMandatoryMin_Inc);
                            decimal dWorkingMin_Inc = clsValidation.GetMinutes(tsWorkingMin_Inc);
                            decimal dOTMin_Inc = clsValidation.GetMinutes(tsOTMin_Inc);

                            if (((dLeave_Min + dWorkingMin_Act) >= dMandatoryMin_Inc) && (dWorkingMin_Act >= dWorkingMin_Inc))
                            {
                                if (((dLeave_Min + dWorkingMin_Act) - dMandatoryMin_Inc) >= dOTMin_Inc) //((48.3 - 45) = 3.3) >= 3
                                    dOT_Fixed_Min = dOTMin_Inc;//2.5 + 3 = 5.5
                                //else if (dActualHrsMargin <= dOTMin_Inc && dActualHrsMargin > clsValidation.GetMinutes("0"))
                                //    dOT_Fixed_Min = dActualHrsMargin;//2.5 + 2.2 = 4.7
                            }
                            dOT_Fixed_Min = dOT_Fixed_Min < 0 ? 0 : dOT_Fixed_Min;
                        }
                        #endregion

                        #region Fill Data Grid
                        dgr_Main.dt.Rows.Add(iIndexID,
                            detail.Employee_ID,
                            detail.SurName + " ," + detail.Initails,
                            clsRef_Name.get_Division_Name(detail.Division_ID),
                            clsRef_Name.get_Department_Name(detail.Department_ID),
                            clsRef_Name.get_Section_Name(detail.SectionID),
                            clsRef_Name.get_SubSection_Name(detail.SubSectionID),
                            clsRef_Name.get_Attendance_ProcessGroup1(detail.AttendanceGroup1_ID),
                            clsRef_Name.get_Attendance_ProcessGroup1(detail.AttendanceGroup1_ID),

                             cls_Formater.FormatDecimal(dWorkingMin_Man / 60, 2),//working man
                            ConvertMinsToHrsMins(dWorkingMin_Man),

                            cls_Formater.FormatDecimal(dWorkingMin_Act / 60, 2),//working act
                            ConvertMinsToHrsMins(dWorkingMin_Act),

                            cls_Formater.FormatDecimal(dLate_Min / 60, 2),//late
                            ConvertMinsToHrsMins(dLate_Min),

                            cls_Formater.FormatDecimal(dNoPay_Min / 60, 2),//nopay
                            ConvertMinsToHrsMins(dNoPay_Min),

                            cls_Formater.FormatDecimal(dOT_Fixed_Min / 60, 2),//fixed ot
                            ConvertMinsToHrsMins(dOT_Fixed_Min),

                            cls_Formater.FormatDecimal(dOT_Normal_Min / 60, 2),//actual ot
                            ConvertMinsToHrsMins(dOT_Normal_Min),

                            cls_Formater.FormatDecimal(dOT_Double_Min / 60, 2),//double
                            ConvertMinsToHrsMins(dOT_Double_Min),

                            cls_Formater.FormatDecimal(dOT_Triple_Min / 60, 2),//triple ot
                            ConvertMinsToHrsMins(dOT_Triple_Min),

                            cls_Formater.FormatDecimal(dLeave_Min / 60, 2),//leave
                            ConvertMinsToHrsMins(dLeave_Min),

                            cls_Formater.FormatDecimal(dGatePass_Min / 60, 2),//gate pass
                            ConvertMinsToHrsMins(dGatePass_Min),

                            (bIsRecordExist ? "#E1FD7C" : "white")
                            );
                        #endregion

                    }

                    if (lsEmployees_AttenIssues.Count > 0)
                    {
                        string sMessageBody_ShiftErrorEmployees = "";
                        foreach (string sEmp in lsEmployees_AttenIssues)
                            sMessageBody_ShiftErrorEmployees += sEmp + " \n";

                        SEACCMessageBox.Show("Daily Attendance Not Saved...!", sMessageBody_ShiftErrorEmployees + "", MessageBoxButton.OK);
                    }
                    #endregion
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
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            dgr_Main.dt.Clear();

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtGroup, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtWeek, true, false, false);

            txtWeek.Tag = null;
            txtGroup.Tag = null;
            txtGroup.Text = "<All Groups>";
            txtWeek.Text = "<All Weeks>";

            dtp_FromDate.SetTime(DateTime.Now);
            dtp_ToDate.SetTime(DateTime.Now);

            dtp_FromDate.IsEnabled = false;
            dtp_ToDate.IsEnabled = false;
        }
        #endregion

        #region Mouse Double Click
        private void txtGroup_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.AttendanceProcessGroup1);
            if (RowDataSearch.DialogResult == true)
            {
                txtGroup.Text = lstResult[1];
                txtGroup.Tag = lstResult[0];
            }
        }
        private void txtWeek_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.HRWeek);
            if (RowDataSearch.DialogResult == true)
            {
                txtWeek.Tag = lstResult[1];
                txtWeek.Text = "Week " + lstResult[1];

                dtp_FromDate.SetTime(DateTime.Parse(lstResult[2]).Date);
                dtp_ToDate.SetTime(DateTime.Parse(lstResult[3]).Date);
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;

            if (CheckDatagrid())
            {
                bStatus = true;
            }

            return bStatus;
        }

        private bool CheckDatagrid()
        {
            bool bStatus = true;
            if (dgr_Main.dt.Rows.Count < 1)
            {
                bStatus = false;
            }

            if (bStatus == false)
                SEACCMessageBox.Show("Please Load Data...", "", MessageBoxButton.OK);

            return bStatus;
        }

        private bool CheckWeekSelected()
        {
            bool bStatus = true;
            if (txtWeek.Tag == null && txtWeek.Text == "<All Weeks>")
                bStatus = false;

            if (bStatus == false)
                SEACCMessageBox.Show("Select Week Before Load...", "", MessageBoxButton.OK);

            return bStatus;
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

        private void dgr_Main_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            try
            {
                string sforeground = ((System.Data.DataRowView)(e.Row.DataContext)).Row.ItemArray[dgr_Main.dt.Columns.Count - 1].ToString();
                e.Row.Foreground = (Brush)bc.ConvertFrom(sforeground);
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
    }
}
