using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Digiteq_Logic;
using DataTire;
using SEACC_WPFControls;
using System.Data;

namespace Digiteq
{
    public partial class UC_DailyAttendanceControlPanel : UserControl
    {
        //- Double OT Breakdown 
        //- Late Nopay Breakdown 
        //- These can be activated using Configs 
        //- 2016-11-02 by Gayan

        //- Triple OT Breakdown
        //- 2017-08-25 by Gayan

        //- SELMO Changes
        //- Girls Midnight OT
        //- Shift from Roster
        //- 2018-05 by Janith


        #region Form Load
        public UC_DailyAttendanceControlPanel()
        {
            #region Initialize UserComponent
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Attendance_Control_Panel;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("attendenceDate");
            dgr_Main.dt.Columns.Add("Day");
            dgr_Main.dt.Columns.Add("employee_ID");
            dgr_Main.dt.Columns.Add("EmpName");
            dgr_Main.dt.Columns.Add("department_ID");
            dgr_Main.dt.Columns.Add("shift_ID");
            dgr_Main.dt.Columns.Add("ShiftName");
            dgr_Main.dt.Columns.Add("ShiftDay");
            dgr_Main.dt.Columns.Add("Shift_StartTime");
            dgr_Main.dt.Columns.Add("Shift_EndTime");
            dgr_Main.dt.Columns.Add("shiftMinutes");
            dgr_Main.dt.Columns.Add("shiftMinutesMin");
            dgr_Main.dt.Columns.Add("nextShiftMinutes");
            dgr_Main.dt.Columns.Add("shiftGracePeriod");
            dgr_Main.dt.Columns.Add("ShiftSpecialParameeter1");
            dgr_Main.dt.Columns.Add("ShiftSpecialParameeter2");
            dgr_Main.dt.Columns.Add("InDateTime_ID_O");
            dgr_Main.dt.Columns.Add("InDateTime_ID_E");
            dgr_Main.dt.Columns.Add("InDate_O");
            dgr_Main.dt.Columns.Add("InDate_E");
            dgr_Main.dt.Columns.Add("InTime_O");
            dgr_Main.dt.Columns.Add("InTime_E");
            dgr_Main.dt.Columns.Add("OutDateTime_ID_O");
            dgr_Main.dt.Columns.Add("OutDateTime_ID_E");
            dgr_Main.dt.Columns.Add("OutDate_O");
            dgr_Main.dt.Columns.Add("OutDate_E");
            dgr_Main.dt.Columns.Add("OutTime_O");
            dgr_Main.dt.Columns.Add("OutTime_E");
            dgr_Main.dt.Columns.Add("TotalHours_Display_O");
            dgr_Main.dt.Columns.Add("TotalHours_Display_E");
            dgr_Main.dt.Columns.Add("WorkedHours_Display_O");
            dgr_Main.dt.Columns.Add("WorkedHours_Display_E");

            dgr_Main.dt.Columns.Add("OTHours_Display_O");
            dgr_Main.dt.Columns.Add("OTHours_Display_E");

            dgr_Main.dt.Columns.Add("DoubleOTHours_Display_O"); //Double OT
            dgr_Main.dt.Columns.Add("DoubleOTHours_Display_E"); //Double OT

            dgr_Main.dt.Columns.Add("TripleOTHours_Display_O"); //Triple OT
            dgr_Main.dt.Columns.Add("TripleOTHours_Display_E"); //Triple OT

            dgr_Main.dt.Columns.Add("OT_O");
            dgr_Main.dt.Columns.Add("OT_E");

            dgr_Main.dt.Columns.Add("OTApproved_Display_O");
            dgr_Main.dt.Columns.Add("OTApproved_Display_E");

            dgr_Main.dt.Columns.Add("DoubleOTApproved_Display_O");//Double OT
            dgr_Main.dt.Columns.Add("DoubleOTApproved_Display_E");//Double OT

            dgr_Main.dt.Columns.Add("TripleOTApproved_Display_O");//Triple OT
            dgr_Main.dt.Columns.Add("TripleOTApproved_Display_E");//Triple OT

            dgr_Main.dt.Columns.Add("LateHours_Display_O"); //Late
            dgr_Main.dt.Columns.Add("LateHours_Display_E");
            dgr_Main.dt.Columns.Add("LateApproved_Display_O");
            dgr_Main.dt.Columns.Add("LateApproved_Display_E");

            dgr_Main.dt.Columns.Add("NoPayHours_Display_O"); //Nopay
            dgr_Main.dt.Columns.Add("NoPayHours_Display_E");
            dgr_Main.dt.Columns.Add("NoPayApproved_Display_O");
            dgr_Main.dt.Columns.Add("NoPayApproved_Display_E");

            dgr_Main.dt.Columns.Add("AttendenceStatus");

            dgr_Main.dt.Columns.Add("LeaveHours");
            dgr_Main.dt.Columns.Add("GPHours");
            dgr_Main.dt.Columns.Add("RowBackColor");
            dgr_Main.dt.Columns.Add("foreground");
            #endregion

            #region Acction Button
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Date", "attendenceDate", 75);
            dgr_Main.Add_DatagridColoumn("Emp No.", "employee_ID", 55);
            dgr_Main.Add_DatagridColoumn("Name", "EmpName", 120);
            dgr_Main.Add_DatagridColoumn("shift_ID", "shift_ID", 110, false);
            dgr_Main.Add_DatagridColoumn("Shift", "ShiftName", 130);
            dgr_Main.Add_DatagridColoumn("Shift Days", "ShiftDay", 20);
            dgr_Main.Add_DatagridColoumn("Shift Start", "Shift_StartTime", 130);
            dgr_Main.Add_DatagridColoumn("Shift End", "Shift_EndTime", 130);
            dgr_Main.Add_DatagridColoumn("InDateTime_ID", "InDateTime_ID_E", 80, false);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "In Date", "InDate_E", 80, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "In Time", "InTime_E", 80, true, false);
            dgr_Main.Add_DatagridColoumn("OutDateTime_ID", "OutDateTime_ID_E", 80, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Out Date", "OutDate_E", 80, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Out Time", "OutTime_E", 80, true, false);

            dgr_Main.Add_DatagridColoumn("Hrs Tot.", "TotalHours_Display_E", 80);
            dgr_Main.Add_DatagridColoumn("Hrs Wkd.", "WorkedHours_Display_E", 80);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Hrs OT", "OTHours_Display_E", 80, true, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Hrs Dub.OT", "DoubleOTHours_Display_E", 80, clsConfig.bEnableDoubleOT, true);//Double OT
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Hrs Trpl.OT", "TripleOTHours_Display_E", 80, clsConfig.bEnableDoubleOT, true);//Triple OT

            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "OT", "OT_E", 25, true, true); //19
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Hrs OT Aprd.", "OTApproved_Display_E", 80, true, false); //20

            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Hrs Dub.OT Aprd.", "DoubleOTApproved_Display_E", 100, clsConfig.bEnableDoubleOT, false);//Double OT 21
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Hrs Trpl.OT Aprd.", "TripleOTApproved_Display_E", 100, clsConfig.bEnableDoubleOT, false);//Triple OT 22

            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Hrs Late", "LateHours_Display_E", 80, clsConfig.bEnableLateNopayBreakDown, clsConfig.bEnableLateHrs_Edit);// Late 23
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Hrs Late Aprd.", "LateApproved_Display_E", 100, clsConfig.bEnableLateNopayBreakDown, false);//Late Approved 24

            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Hrs Nopay", "NoPayHours_Display_E", 80, true, true);// Nopay 25
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Hrs Nopay Aprd.", "NoPayApproved_Display_E", 100, true, false);//Nopay Approved 26

            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Leave Hours", "LeaveHours", 80, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "GP Hours", "GPHours", 80, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Status", "Status", 80, true, false);
            dgr_Main.Add_DatagridColoumn("Leave Coverd Date", "LeaveCoverdDate", 80);
            #endregion

            ClearFields();
        }
        #endregion

        #region Action Button
        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkGridSaveValidity())
                {
                    foreach (DataRow row in dgr_Main.dt.Rows)
                    {
                        #region get values from table
                        DateTime dtmAttendanceDate = clsValidation.Validate_DateTime(row["attendenceDate"].ToString());
                        string sEmployee_ID = row["employee_ID"].ToString();
                        string sDepartment_ID = row["department_ID"].ToString();
                        string sShift_ID = row["shift_ID"].ToString();
                        int iShiftDay = int.Parse(row["ShiftDay"].ToString());
                        DateTime dtmShiftStartTime = clsValidation.Validate_DateTime(row["Shift_StartTime"].ToString());
                        DateTime dtmShiftEndTime = clsValidation.Validate_DateTime(row["Shift_EndTime"].ToString());
                        int iShiftMinutes = int.Parse(row["shiftMinutes"].ToString());
                        int iShiftMinutesMin = int.Parse(row["shiftMinutesMin"].ToString());
                        int iNextShiftMinutes = int.Parse(row["nextShiftMinutes"].ToString());
                        int iShiftGracePeriod = int.Parse(row["shiftGracePeriod"].ToString());
                        int iInDateTime_ID = int.Parse(row["InDateTime_ID_O"].ToString());
                        int iInDateTime_ID_E = int.Parse(row["InDateTime_ID_E"].ToString());
                        DateTime dtmInTime = clsValidation.Merge_DateAndTime(clsValidation.Validate_DateTime(row["InDate_O"].ToString()), clsValidation.Validate_DateTime(row["InTime_O"].ToString()));
                        DateTime dtmInTime_E = clsValidation.Merge_DateAndTime(clsValidation.Validate_DateTime(row["InDate_E"].ToString()), clsValidation.Validate_DateTime(row["InTime_E"].ToString()));
                        int iOutDateTime_ID = int.Parse(row["OutDateTime_ID_O"].ToString());
                        int iOutDateTime_ID_E = int.Parse(row["OutDateTime_ID_E"].ToString());
                        DateTime dtmOutTime = clsValidation.Merge_DateAndTime(clsValidation.Validate_DateTime(row["OutDate_O"].ToString()), clsValidation.Validate_DateTime(row["OutTime_O"].ToString()));
                        DateTime dtmOutTime_E = clsValidation.Merge_DateAndTime(clsValidation.Validate_DateTime(row["OutDate_E"].ToString()), clsValidation.Validate_DateTime(row["OutTime_E"].ToString()));
                        int iTotalMinutes = clsValidation.GetMinutes(row["TotalHours_Display_O"].ToString());
                        int iWorkedMinutes = clsValidation.GetMinutes(row["WorkedHours_Display_O"].ToString());
                        int iWorkedMinutes_E = clsValidation.GetMinutes(row["WorkedHours_Display_E"].ToString());
                        int iOTMinutes = clsValidation.GetMinutes(row["OTHours_Display_O"].ToString());
                        int iOTMinutes_E = clsValidation.GetMinutes(row["OTHours_Display_E"].ToString());
                        int iDoubleOTMinutes = clsValidation.GetMinutes(row["DoubleOTHours_Display_O"].ToString()); //Double OT
                        int iDoubleOTMinutes_E = clsValidation.GetMinutes(row["DoubleOTHours_Display_E"].ToString());//Double OT
                        int iTripleOTMinutes = clsValidation.GetMinutes(row["TripleOTHours_Display_O"].ToString()); //Triple OT
                        int iTripleOTMinutes_E = clsValidation.GetMinutes(row["TripleOTHours_Display_E"].ToString());//Triple OT
                        bool bOTApplicable = bool.Parse(row["OT_O"].ToString());
                        bool bOTApplicable_E = bool.Parse(row["OT_E"].ToString());
                        int iOTApprovedMinutes = clsValidation.GetMinutes(row["OTApproved_Display_O"].ToString());
                        int iOTApprovedMinutes_E = clsValidation.GetMinutes(row["OTApproved_Display_E"].ToString());
                        int iDoubleOTApprovedMinutes = clsValidation.GetMinutes(row["DoubleOTApproved_Display_O"].ToString());//Double OT
                        int iDoubleOTApprovedMinutes_E = clsValidation.GetMinutes(row["DoubleOTApproved_Display_E"].ToString());//Double OT
                        int iTripleOTApprovedMinutes = clsValidation.GetMinutes(row["TripleOTApproved_Display_O"].ToString());//Triple OT
                        int iTripleOTApprovedMinutes_E = clsValidation.GetMinutes(row["TripleOTApproved_Display_E"].ToString());//Triple OT

                        int iLateMinutes = clsValidation.GetMinutes(row["LateHours_Display_O"].ToString());  //Late
                        int iLateMinutes_E = clsValidation.GetMinutes(row["LateHours_Display_E"].ToString());
                        int iLateMinutesApproved = clsValidation.GetMinutes(row["LateApproved_Display_O"].ToString());
                        int iLateMinutesApproved_E = clsValidation.GetMinutes(row["LateApproved_Display_E"].ToString());

                        int iNoPayHoursMinutes = clsValidation.GetMinutes(row["NoPayHours_Display_O"].ToString()); //Nopay
                        int iNoPayHoursMinutes_E = clsValidation.GetMinutes(row["NoPayHours_Display_E"].ToString());
                        int iNoPayHoursMinutesApproved = clsValidation.GetMinutes(row["NoPayApproved_Display_O"].ToString());
                        int iNoPayHoursMinutesApproved_E = clsValidation.GetMinutes(row["NoPayApproved_Display_E"].ToString());

                        int iLeaveMiniths = clsValidation.GetMinutes(row["LeaveHours"].ToString());
                        int iGPMiniths = clsValidation.GetMinutes(row["GPHours"].ToString());
                        int iDayType = 0;// to do
                        #endregion

                        #region Insert record
                        tbl_tasTxDailyAttendance oOldRecord = tbl_tasTxDailyAttendance.Select_Advanced(dtmAttendanceDate, sEmployee_ID);
                        if (oOldRecord != null)
                        {
                            #region Reverce Device rawdata
                            if (oOldRecord.TimeIn_ID != 0 && oOldRecord.TimeIn_ID != 1)
                            {
                                tbl_tasTxDeviceRawData oDRD_in = tbl_tasTxDeviceRawData.Select(oOldRecord.TimeIn_ID);
                                if (oDRD_in != null)
                                {
                                    oDRD_in.IsSelected = false;
                                    oDRD_in.Update();
                                }
                            }
                            if (oOldRecord.TimeIn_ID != 0 && oOldRecord.TimeIn_ID != 1)
                            {
                                tbl_tasTxDeviceRawData oDRD_out = tbl_tasTxDeviceRawData.Select(oOldRecord.TimeOut_ID);
                                if (oDRD_out != null)
                                {
                                    oDRD_out.IsSelected = false;
                                    oDRD_out.Update();
                                }
                            }
                            #endregion

                            tbl_tasTxDailyAttendance oDetail = new tbl_tasTxDailyAttendance(clsSecurity.CompanyID, clsSecurity.BranchID, oOldRecord.Attendance_index, dtmAttendanceDate, sEmployee_ID, sDepartment_ID, iDayType, sShift_ID, iShiftDay, dtmShiftStartTime, dtmShiftEndTime,
                                                   iShiftMinutes, iShiftMinutesMin, iNextShiftMinutes, iShiftGracePeriod, iInDateTime_ID, dtmInTime, iOutDateTime_ID, dtmOutTime, iTotalMinutes, iWorkedMinutes,
                                                   1.5m, 2.0m, 3.0m,
                                                   iOTMinutes, iDoubleOTMinutes, iTripleOTMinutes,
                                                   bOTApplicable,
                                                   iOTApprovedMinutes, iDoubleOTApprovedMinutes, iTripleOTApprovedMinutes,
                                                   iLateMinutes, iLateMinutesApproved, iNoPayHoursMinutes, iNoPayHoursMinutesApproved, iLeaveMiniths, iGPMiniths, 0, "Default", "Default",
                                                   oOldRecord.IsCanceled, oOldRecord.UserID_Created, clsSecurity.UserIDLoged, oOldRecord.UserID_Canceled, oOldRecord.TerminalID_Created, clsSecurity.TerminalID, oOldRecord.TerminalID_Canceled, oOldRecord.Date_Created, clsSecurity.getServerDateTime(), oOldRecord.Date_Canceled);
                            oDetail.Update();
                        }
                        else
                        {
                            tbl_tasTxDailyAttendance oDetail = new tbl_tasTxDailyAttendance(clsSecurity.CompanyID, clsSecurity.BranchID, dtmAttendanceDate, sEmployee_ID, sDepartment_ID, iDayType, sShift_ID, iShiftDay, dtmShiftStartTime, dtmShiftEndTime,
                                                  iShiftMinutes, iShiftMinutesMin, iNextShiftMinutes, iShiftGracePeriod, iInDateTime_ID, dtmInTime, iOutDateTime_ID, dtmOutTime, iTotalMinutes, iWorkedMinutes,
                                                  1.5m, 2.0m, 3.0m,
                                                  iOTMinutes, iDoubleOTMinutes, iTripleOTMinutes,
                                                  bOTApplicable,
                                                  iOTApprovedMinutes, iDoubleOTApprovedMinutes, iTripleOTApprovedMinutes,
                                                  iLateMinutes, iLateMinutesApproved, iNoPayHoursMinutes, iNoPayHoursMinutesApproved, iLeaveMiniths, iGPMiniths, 0, "Default", "Default",
                                                  false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                            oDetail.Insert();


                        }

                        if ((iInDateTime_ID != iInDateTime_ID_E) || (iOutDateTime_ID != iOutDateTime_ID_E) || (iWorkedMinutes != iWorkedMinutes_E) ||
                            (iOTMinutes != iOTMinutes_E) || (iDoubleOTMinutes != iDoubleOTMinutes_E) || (iTripleOTMinutes != iTripleOTMinutes_E) ||
                            (bOTApplicable != bOTApplicable_E) ||
                            (iOTApprovedMinutes != iOTApprovedMinutes_E) || (iDoubleOTApprovedMinutes != iDoubleOTApprovedMinutes_E) || (iTripleOTApprovedMinutes != iTripleOTApprovedMinutes_E) ||
                            (iLateMinutes != iLateMinutes_E) || (iLateMinutesApproved != iLateMinutesApproved_E) || (iNoPayHoursMinutes != iNoPayHoursMinutes_E) || (iNoPayHoursMinutesApproved != iNoPayHoursMinutesApproved_E))
                        {
                            foreach (tbl_tasTxDailyAttendance_revision oRevOldrecord in tbl_tasTxDailyAttendance_revision.SelectAll_Advanced(dtmAttendanceDate, sEmployee_ID).Where(p => !p.IsCanceled && !p.IsOverride))
                            {
                                oRevOldrecord.IsOverride = true;
                                oRevOldrecord.Update();
                            }

                            tbl_tasTxDailyAttendance_revision oRev = new tbl_tasTxDailyAttendance_revision(clsSecurity.CompanyID, clsSecurity.BranchID, dtmAttendanceDate, sEmployee_ID, sDepartment_ID, iDayType, sShift_ID, iShiftDay, dtmShiftStartTime, dtmShiftEndTime,
                                                   iShiftMinutes, iShiftMinutesMin, iNextShiftMinutes, iShiftGracePeriod, iInDateTime_ID_E, dtmInTime_E, iOutDateTime_ID_E, dtmOutTime_E, iTotalMinutes, iWorkedMinutes_E,
                                                   1.5m, 2.0m, 3.0m,
                                                   iOTMinutes_E, iDoubleOTMinutes_E, iTripleOTMinutes_E,
                                                   bOTApplicable_E,
                                                   iOTApprovedMinutes_E, iDoubleOTApprovedMinutes_E, iTripleOTApprovedMinutes_E,
                                                   iLateMinutes_E, iLateMinutesApproved_E, iNoPayHoursMinutes_E, iNoPayHoursMinutesApproved_E, iLeaveMiniths, iGPMiniths, false, false, 0,
                                clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                            oRev.Insert();
                        }
                        #endregion

                        #region Update Device rawdata
                        if (iInDateTime_ID != 0 && iInDateTime_ID != 1)
                        {
                            tbl_tasTxDeviceRawData oDRD_in = tbl_tasTxDeviceRawData.Select(iInDateTime_ID);
                            oDRD_in.IsSelected = true;
                            oDRD_in.Update();
                        }
                        if (iOutDateTime_ID != 0 && iOutDateTime_ID != 1)
                        {
                            tbl_tasTxDeviceRawData oDRD_out = tbl_tasTxDeviceRawData.Select(iOutDateTime_ID);
                            oDRD_out.IsSelected = true;
                            oDRD_out.Update();
                        }
                        #endregion
                    }
                    SEACCMessageBox.Show("Attendance Saved succesfully...!", "", MessageBoxButton.OK);
                }
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

                DateTime dtmFromDate = dtp_FromDate.GetDateTime();
                DateTime dtmToDate = dtptoDate.GetDateTime();
                this.SEACC_Form.btn_Save.Visibility = Visibility.Visible;
                this.SEACC_Form.btn_Cancel.Visibility = Visibility.Visible;

                int iShiftDay = 0;
                string sPriviusShift = "";
                #endregion

                #region Filters

                #region Filter - Employee

                List<tbl_genMasEmployee> oEmployees;
                if (txtEmpNo.Tag != null)
                    oEmployees = tbl_genMasEmployee.SelectAll().Where(p => p.Employee_ID == txtEmpNo.Tag.ToString() && p.Employee_ID != "default").ToList();
                else
                    oEmployees = tbl_genMasEmployee.SelectAll().Where(p => p.Employee_ID != "default").ToList();

                #endregion

                #region Filter - Shift

                //  if (txtShift.Tag != null)
                // oEmployees = oEmployees.Where(p => p.Shift_ID == txtShift.Tag.ToString()).ToList();

                #endregion

                #region Filter - Division

                if (txtDivision.Tag != null)
                    oEmployees = oEmployees.Where(p => p.Division_ID == txtDivision.Tag.ToString()).ToList();

                #endregion

                #region Filter - Department

                if (txtDepartment.Tag != null)
                    oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();

                #endregion

                #region Filter - Section
                if (txtsection.Tag != null)
                    oEmployees = oEmployees.Where(p => p.SectionID == txtsection.Tag.ToString()).ToList();
                #endregion

                #region Filter - Attendance Group
                if (txtAttendanceGroup1.Tag != null)
                    oEmployees = oEmployees.Where(p => p.AttendanceGroup1_ID == txtAttendanceGroup1.Tag.ToString()).ToList();
                #endregion
                #endregion

                #region Create datasets - DeviceRawData & Holidays
                List<sp_tasDevice_RawData> oDeviceRawData = sp_tasDevice_RawData.SelectAll("%", "%", dtmFromDate.Date, dtmToDate.Date).ToList();
                List<tbl_tasHolidayCalander> oHolidays = tbl_tasHolidayCalander.SelectAllByHolyday_Date(dtmFromDate.Date, dtmToDate.Date).Where(p => p.Holiday_Status).ToList();
                #endregion

                foreach (tbl_genMasEmployee oEmployee in oEmployees.Where(p => p.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString()))
                {
                    //Payroll Status
                    //Added by Gayan
                    //2016-11-16
                    if (this.SEACC_Form.btn_Save.Visibility == Visibility.Visible)
                    {
                        DataTable dtPayrollRawData = DBHandling.ExecQuery("sp_getPayrollRawData_fromEmployeeWise_GivenDate '" + oEmployee.Employee_ID + "' , '" + dtmFromDate.Date + "'").Tables[0];
                        if (dtPayrollRawData.Rows.Count > 0)
                        {
                            this.SEACC_Form.btn_Save.Visibility = Visibility.Collapsed;
                            this.SEACC_Form.btn_Cancel.Visibility = Visibility.Collapsed;
                        }
                    }

                    //TimeSpan tsMargin = dtmToDate.Date.AddHours(24) - dtmFromDate.Date;
                    #region Shift Issue Message
                    //if (clsConfig.bEnable_Roster)
                    //{
                    //    bool bShiftIssue = false;
                    //    List<tbl_tasTxEmployeeRoster> oRoster = tbl_tasTxEmployeeRoster.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, oEmployee.Employee_ID).Where(p => p.RosterDate >= dtmFromDate.Date && p.RosterDate <= dtmToDate.Date).ToList();
                    //    if (oRoster.Count <= 0)
                    //    {
                    //        bShiftIssue = true;
                    //    }
                    //    else if (oRoster.Count > 0 && (tsMargin.Days != oRoster.Count))
                    //    {
                    //        bShiftIssue = true;
                    //    }

                    //    if (bShiftIssue)
                    //    {
                    //        if (SEACCMessageBox.Show("Employee Shift Issue...!", "Employee : '" + oEmployee.Employee_ID + " - " + oEmployee.Initails + " " + oEmployee.SurName + "' has a shift Issue. \n\nDo you want to continue the process without this Employee?", MessageBoxButton.YesNo, "#FF5B6B76"))
                    //            continue;
                    //        else
                    //            return;
                    //    }
                    //}
                    #endregion

                    List<tbl_tasTxDailyAttendance> oDailyAttendance = tbl_tasTxDailyAttendance.SelectAllBy_EmployeeIDWithDateRange(oEmployee.Employee_ID, dtmFromDate.Date, dtmToDate.Date).Where(p => !p.IsCanceled).ToList();

                    for (DateTime dDate = dtmFromDate.Date; dDate.Date <= dtmToDate.Date; dDate = dDate.AddDays(1))
                    {
                        #region Variable
                        DateTime dtmShiftStart = clsConfig.defaultDateTime;
                        DateTime dtmShiftEnd = clsConfig.defaultDateTime;
                        DateTime dtmTimeIn = clsConfig.defaultDateTime;
                        DateTime dtmTimeOut = clsConfig.defaultDateTime;

                        int iShiftMinutes = 0, iShiftMinutes_Min = 0, iNextShift_Minutes = 0, iShiftGracePeriod = 0;
                        int iInDateTime_ID = 0, iOutDateTime_ID = 0;

                        bool bShiftSpecialParameeter1 = false, bShiftSpecialParameeter2 = false;

                        TimeSpan tsLeaveHours = TimeSpan.FromMinutes(0);
                        TimeSpan tsGPHours = TimeSpan.FromMinutes(0);

                        String sRowBackColor = "#FF34495E";
                        String sDayType = "Working Day";

                        string sShiftStart = "-", sShiftEnd = "-";
                        string sShiftId = "", sShiftName = "";
                        string sPrevShiftID = "";
                        ShiftTypes enmShiftType = ShiftTypes.OneDayShift;

                        holidayDurationType hdt = holidayDurationType.N_A;
                        #endregion

                        #region Holydays And format rows
                        foreach (tbl_tasHolidayCalander oCal in oHolidays.Where(p => p.Holiday_Date.Date == dDate.Date && !p.IsCanceled))
                        {
                            sRowBackColor = "#FF345A5E";
                            sDayType = "HoliDay";
                            hdt = (holidayDurationType)oCal.HolidayDurationType;

                            if (oCal.HolydayType_ID == clsConfig.sPoyaDay)
                                sDayType = "Poyaday";
                        }

                        if (sDayType == "Working Day")
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

                        #region Leave
                        foreach (tbl_tasEmployeeLeaveCard_Detail oLeave in tbl_tasEmployeeLeaveCard_Detail.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, oEmployee.Employee_ID, clsConfig.sNoPayLeaveID).Where(p => p.Start_DateTime.Date == dDate && p.End_DateTime.Date == dDate))
                        {
                            TimeSpan tsTemp = oLeave.End_DateTime - oLeave.Start_DateTime;
                            tsLeaveHours += tsTemp;
                        }
                        #endregion

                        #region Gatepass
                        //- uncomented by Gayan 2016-06-16
                        foreach (tbl_tasTxGatePass oGatePass in tbl_tasTxGatePass.SelectAll().Where(p => !p.IsCanceled && p.GatePass_DateTime.Date == dDate && p.Employee_ID == oEmployee.Employee_ID))
                        {
                            TimeSpan tsTemp = TimeSpan.FromMinutes(double.Parse(oGatePass.Leave_Hours.ToString()));
                            tsGPHours += tsTemp;
                            //     dt_GatePass.Rows.Add(oGatePass.GatePass_ID, oGatePass.GatePass_DateTime.ToString(clsConfig.Format_Date), oGatePass.Reason, oGatePass.Leave_Hours.ToString("00.00"), clsRef_Name.get_EmployeeName(oGatePass.UserID_Supevisor), clsRef_Name.get_EmployeeName(oGatePass.UserID_Manager));
                        }
                        #endregion

                        #region Get Shift based on Roster or Shift Adjustment
                        clsHelpMethods.GetShift(dDate, oEmployee.Employee_ID, oEmployee.IsRosterBasedEmployee, hdt, ref sShiftId, ref sShiftName, ref enmShiftType, ref iShiftDay, ref sPriviusShift, ref bShiftSpecialParameeter1, ref bShiftSpecialParameeter2, ref iShiftMinutes, ref iShiftMinutes_Min, ref iNextShift_Minutes, ref iShiftGracePeriod, ref dtmShiftStart, ref dtmShiftEnd, ref sShiftStart, ref sShiftEnd);
                        #endregion

                        #region Shift Issues Employees
                        //if (clsConfig.bEnable_Roster)
                        //    if (sShiftId == "")
                        //        continue; 
                        #endregion

                        #region Get Exist Record
                        bool bIsRecordExist = false;
                        bool bIsShiftError = false;
                        foreach (tbl_tasTxDailyAttendance oOldRecord in oDailyAttendance.Where(p => p.AttendenceDate.Date == dDate))
                        {
                            bIsRecordExist = true;

                            if (sShiftId != oOldRecord.Shift_ID)
                                bIsShiftError = true;

                            bShiftSpecialParameeter1 = false; bShiftSpecialParameeter2 = false;

                            iInDateTime_ID = oOldRecord.TimeIn_ID;
                            dtmTimeIn = oOldRecord.TimeIn_DateTime;
                            iOutDateTime_ID = oOldRecord.TimeOut_ID;
                            dtmTimeOut = oOldRecord.TimeOut_DateTime;
                        }
                        #endregion

                        if (!bIsRecordExist)
                        {
                            #region New Record

                            #region Get Time In/out -Method old
                            if (clsConfig.bEnableGetInOutTimeMethod_Old)
                            {
                                foreach (sp_tasDevice_RawData odetails in oDeviceRawData.Where(p => p.Device_empID == oEmployee.Employee_ID2 && p.Device_DateTime.Date == dDate.Date))
                                {
                                    switch (enmShiftType)
                                    {
                                        case ShiftTypes.OneDayShift:
                                            #region Single day Shift
                                            {
                                                if (false)
                                                {

                                                    if (dtmTimeIn == clsConfig.defaultDateTime)
                                                    {
                                                        dtmTimeIn = odetails.Device_DateTime;
                                                        dtmTimeOut = odetails.Device_DateTime;

                                                        iInDateTime_ID = odetails.RawData_Index;
                                                        iOutDateTime_ID = odetails.RawData_Index;
                                                    }
                                                    else
                                                    {
                                                        if (odetails.Device_DateTime < dtmTimeIn)
                                                        {
                                                            dtmTimeIn = odetails.Device_DateTime;
                                                            iInDateTime_ID = odetails.RawData_Index;
                                                        }
                                                        if (odetails.Device_DateTime > dtmTimeOut)
                                                        {
                                                            dtmTimeOut = odetails.Device_DateTime;
                                                            iOutDateTime_ID = odetails.RawData_Index;
                                                        }
                                                    }

                                                    if (dtmTimeOut == dtmTimeIn)
                                                    {
                                                        TimeSpan ts1 = (clsValidation.CombineDateAndTime(dDate, dtmShiftStart) - dtmTimeIn).Duration();
                                                        TimeSpan ts2 = (clsValidation.CombineDateAndTime(dDate, dtmShiftStart.AddMinutes(iShiftMinutes)) - dtmTimeOut).Duration();

                                                        if (ts1 < ts2)
                                                            dtmTimeOut = clsConfig.defaultDateTime;
                                                        else
                                                            dtmTimeIn = clsConfig.defaultDateTime;
                                                    }

                                                }
                                            }
                                            break;
                                        #endregion
                                        case ShiftTypes.TwoDayShift:
                                            #region 24 hr Shift
                                            {
                                                if (iShiftDay == 1)
                                                {
                                                    if (dtmTimeIn == clsConfig.defaultDateTime)
                                                    {
                                                        dtmTimeIn = odetails.Device_DateTime;
                                                        iInDateTime_ID = odetails.RawData_Index;
                                                    }
                                                    else if (odetails.Device_DateTime < dtmTimeIn)
                                                    {
                                                        dtmTimeIn = odetails.Device_DateTime;
                                                        iInDateTime_ID = odetails.RawData_Index;
                                                    }
                                                }
                                                else
                                                {
                                                    if (dtmTimeOut == clsConfig.defaultDateTime)
                                                    {
                                                        dtmTimeOut = odetails.Device_DateTime;
                                                        iOutDateTime_ID = odetails.RawData_Index;
                                                    }
                                                    else if (odetails.Device_DateTime > dtmTimeOut)
                                                    {
                                                        dtmTimeOut = odetails.Device_DateTime;
                                                        iOutDateTime_ID = odetails.RawData_Index;
                                                    }
                                                }

                                            }
                                            break;
                                        #endregion
                                        case ShiftTypes.FlexibalShift:
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                            #endregion

                            #region Get Time In/Out Method new
                            //- Change 01 :
                            //- Not more validations
                            //- Just show first come first
                            //- 2016-11-02 by Gayan
                            //---------------------------------
                            //- Change 02 :
                            //- In Time => Set First finger Print touch in relavant Day
                            //- Out Time => Set Last finger Print touch in relavant Day
                            //- 2017-04-05 by Gayan
                            //- Suggested by Kaushalya & Anoj
                            else
                            {
                                #region Shifts
                                switch (enmShiftType)
                                {
                                    #region Midnight Cross Shift
                                    case ShiftTypes.MidnightCross:
                                        {
                                            /* This is midnidht cross shift
                                             * Developped by Gayan
                                             * Task No : 4803
                                             * Initially Requested by Hero Group
                                             * 2017-05-17
                                             */
                                            DataTable dtResult_MidnightCrossShift = DBHandling.ExecQuery("sp_GetInOutTimeFromDate '" + oEmployee.Employee_ID2 + "' , '" + dDate.Date.AddHours(12) + "' , '" + dDate.Date.AddHours(36) + "'").Tables[0];
                                            clsHelpMethods.Validate_InOutTime_DataTable(ref dtResult_MidnightCrossShift);
                                            if (dtResult_MidnightCrossShift != null && dtResult_MidnightCrossShift.Rows.Count > 0)
                                            {
                                                if (dtResult_MidnightCrossShift.Rows.Count == 1)
                                                {
                                                    DateTime dtm_firstRec = DateTime.Parse(dtResult_MidnightCrossShift.Rows[0]["device_DateTime"].ToString());
                                                    if (dtm_firstRec.Date == dDate)
                                                        dtmTimeIn = dtm_firstRec;
                                                    else
                                                        dtmTimeOut = dtm_firstRec;
                                                }
                                                else if (dtResult_MidnightCrossShift.Rows.Count > 1)
                                                {
                                                    int iLastRowNo = dtResult_MidnightCrossShift.Rows.Count - 1;
                                                    dtmTimeIn = DateTime.Parse(dtResult_MidnightCrossShift.Rows[0]["device_DateTime"].ToString());
                                                    iInDateTime_ID = int.Parse(dtResult_MidnightCrossShift.Rows[0]["rawData_Index"].ToString());
                                                    dtmTimeOut = DateTime.Parse(dtResult_MidnightCrossShift.Rows[iLastRowNo]["device_DateTime"].ToString());
                                                    iOutDateTime_ID = int.Parse(dtResult_MidnightCrossShift.Rows[iLastRowNo]["rawData_Index"].ToString());
                                                }
                                            }
                                        }
                                        break;
                                    #endregion

                                    #region Other Shifts
                                    default:
                                        {
                                            DataTable dtResults = DBHandling.ExecQuery("sp_GetInOutTimeFromDate '" + oEmployee.Employee_ID2 + "' , '" + dDate.Date + "' , '" + dDate.Date.AddDays(1).Date + "'").Tables[0];
                                            clsHelpMethods.Validate_InOutTime_DataTable(ref dtResults);
                                            if (dtResults != null && dtResults.Rows.Count > 0)
                                            {
                                                int iLastRowNo = dtResults.Rows.Count - 1;
                                                int iLastRowNo_Main = dgr_Main.dt.Rows.Count - 1;
                                                bool bNotMidNightCrossShift = false;

                                                switch (enmShiftType)
                                                {
                                                    #region Flexible
                                                    case ShiftTypes.FlexibalShift:
                                                        dtmTimeIn = DateTime.Parse(dtResults.Rows[0]["device_DateTime"].ToString());
                                                        iInDateTime_ID = int.Parse(dtResults.Rows[0]["rawData_Index"].ToString());

                                                        if (dtResults.Rows.Count > 1)
                                                        {
                                                            dtmTimeOut = DateTime.Parse(dtResults.Rows[iLastRowNo]["device_DateTime"].ToString());
                                                            iOutDateTime_ID = int.Parse(dtResults.Rows[iLastRowNo]["rawData_Index"].ToString());
                                                        }
                                                        break;
                                                    #endregion

                                                    #region One Day Shift
                                                    case ShiftTypes.OneDayShift:
                                                        if (dgr_Main.dt.Rows.Count > 0)
                                                            sPrevShiftID = dgr_Main.dt.Rows[iLastRowNo_Main]["shift_ID"].ToString();

                                                        if (sPrevShiftID != "")
                                                        {
                                                            tbl_tasShiftMaster oShift = tbl_tasShiftMaster.Select(sPrevShiftID, clsSecurity.CompanyID, clsSecurity.BranchID);
                                                            if (oShift.ShiftType == (int)ShiftTypes.MidnightCross)
                                                            {
                                                                dtmTimeIn = clsConfig.defaultDateTime;
                                                                iInDateTime_ID = 0;

                                                                dtmTimeOut = clsConfig.defaultDateTime;
                                                                iOutDateTime_ID = 0;

                                                                bNotMidNightCrossShift = true;
                                                            }
                                                        }

                                                        if (!bNotMidNightCrossShift)
                                                        {
                                                            //Need to Implement compatible with shift
                                                            dtmTimeIn = DateTime.Parse(dtResults.Rows[0]["device_DateTime"].ToString());
                                                            iInDateTime_ID = int.Parse(dtResults.Rows[0]["rawData_Index"].ToString());

                                                            if (dtResults.Rows.Count > 1)
                                                            {
                                                                dtmTimeOut = DateTime.Parse(dtResults.Rows[iLastRowNo]["device_DateTime"].ToString());
                                                                iOutDateTime_ID = int.Parse(dtResults.Rows[iLastRowNo]["rawData_Index"].ToString());
                                                            }
                                                        }
                                                        break;
                                                    #endregion

                                                    #region Two Day
                                                    case ShiftTypes.TwoDayShift:
                                                        if (iShiftDay == 1)
                                                        {
                                                            dtmTimeIn = DateTime.Parse(dtResults.Rows[0]["device_DateTime"].ToString());
                                                            iInDateTime_ID = int.Parse(dtResults.Rows[0]["rawData_Index"].ToString());
                                                        }
                                                        else
                                                        {
                                                            dtmTimeOut = DateTime.Parse(dtResults.Rows[iLastRowNo]["device_DateTime"].ToString());
                                                            iOutDateTime_ID = int.Parse(dtResults.Rows[iLastRowNo]["rawData_Index"].ToString());
                                                        }
                                                        break;
                                                    #endregion
                                                }

                                            }
                                        }
                                        break;
                                        #endregion
                                }
                                #endregion
                            }
                            #endregion

                            #endregion
                        }

                        #region Add new Row
                        DataRow dr = dgr_Main.dt.NewRow();

                        dr["attendenceDate"] = dDate.ToString(clsConfig.Format_Date);
                        dr["Day"] = sDayType;
                        dr["employee_ID"] = oEmployee.Employee_ID;
                        dr["EmpName"] = oEmployee.Initails + oEmployee.SurName;
                        dr["department_ID"] = oEmployee.Department_ID;
                        dr["shift_ID"] = sShiftId;
                        dr["ShiftName"] = sShiftName;
                        dr["ShiftDay"] = iShiftDay;
                        dr["Shift_StartTime"] = sShiftStart;
                        dr["Shift_EndTime"] = sShiftEnd;
                        dr["shiftMinutes"] = iShiftMinutes;
                        dr["shiftMinutesMin"] = iShiftMinutes_Min;
                        dr["nextShiftMinutes"] = iNextShift_Minutes;
                        dr["shiftGracePeriod"] = iShiftGracePeriod;
                        dr["ShiftSpecialParameeter1"] = bShiftSpecialParameeter1;
                        dr["ShiftSpecialParameeter2"] = bShiftSpecialParameeter2;
                        dr["InDateTime_ID_O"] = iInDateTime_ID;
                        dr["InDateTime_ID_E"] = iInDateTime_ID;
                        dr["InDate_O"] = clsValidation.GetDisplayValue_Date(dtmTimeIn);
                        dr["InDate_E"] = clsValidation.GetDisplayValue_Date(dtmTimeIn);
                        dr["InTime_O"] = clsValidation.GetDisplayValue_Time(dtmTimeIn);
                        dr["InTime_E"] = clsValidation.GetDisplayValue_Time(dtmTimeIn);
                        dr["OutDateTime_ID_O"] = iOutDateTime_ID;
                        dr["OutDateTime_ID_E"] = iOutDateTime_ID;
                        dr["OutDate_O"] = clsValidation.GetDisplayValue_Date(dtmTimeOut);
                        dr["OutDate_E"] = clsValidation.GetDisplayValue_Date(dtmTimeOut);
                        dr["OutTime_O"] = clsValidation.GetDisplayValue_Time(dtmTimeOut);
                        dr["OutTime_E"] = clsValidation.GetDisplayValue_Time(dtmTimeOut);
                        dr["WorkedHours_Display_O"] = 0;
                        dr["WorkedHours_Display_E"] = 0;
                        dr["OTHours_Display_O"] = 0;
                        dr["OTHours_Display_E"] = 0;

                        dr["DoubleOTHours_Display_O"] = 0;//Double OT
                        dr["DoubleOTHours_Display_E"] = 0;//Double OT
                        dr["TripleOTHours_Display_O"] = 0;//Triple OT
                        dr["TripleOTHours_Display_E"] = 0;//Triple OT
                        dr["OT_O"] = false;
                        dr["OT_E"] = false;
                        dr["OTApproved_Display_O"] = 0;
                        dr["OTApproved_Display_E"] = 0;
                        dr["DoubleOTApproved_Display_O"] = 0;//Double OT
                        dr["DoubleOTApproved_Display_E"] = 0;//Double OT
                        dr["TripleOTApproved_Display_O"] = 0;//Triple OT
                        dr["TripleOTApproved_Display_E"] = 0;//Triple OT

                        dr["LateHours_Display_O"] = 0;//Late
                        dr["LateHours_Display_E"] = 0;//Late
                        dr["LateApproved_Display_O"] = 0;//Late
                        dr["LateApproved_Display_E"] = 0;//Late

                        dr["NoPayHours_Display_O"] = 0;//Nopay
                        dr["NoPayHours_Display_E"] = 0;//Nopay
                        dr["NoPayApproved_Display_O"] = 0;//Nopay
                        dr["NoPayApproved_Display_E"] = 0;//Nopay

                        dr["AttendenceStatus"] = 0;
                        dr["LeaveHours"] = clsValidation.GetDisplayValue_Hours(tsLeaveHours);
                        dr["GPHours"] = clsValidation.GetDisplayValue_Hours(tsGPHours);
                        dr["RowBackColor"] = sRowBackColor;
                        dr["foreground"] = bIsShiftError ? "red" : (bIsRecordExist ? "#E1FD7C" : "white");

                        dgr_Main.dt.Rows.Add(dr);
                        #endregion

                        updateRow(true, (dgr_Main.dt.Rows.Count - 1), dtmTimeIn, dtmTimeOut);
                    }
                }
            }
            catch (Exception ex)
            {
                dgr_Main.dt.Clear();
                //SEACCMessageBox.Show("oops", ex.Message, MessageBoxButton.OK);
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

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDivision, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDepartment, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtsection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtShift, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtAttendanceGroup1, true, false, false);
            //cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtWeek, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmpNo, true, false, false);

            txtEmpNo.Tag = null;
            txtDivision.Tag = null;
            txtDepartment.Tag = null;
            txtsection.Tag = null;
            txtShift.Tag = null;
            txtAttendanceGroup1.Tag = null;
            //txtWeek.Tag = null;

            txtEmpNo.Text = "<All Employees>";
            txtDivision.Text = "<All Divisions>";
            txtDepartment.Text = "<All Departments>";
            txtsection.Text = "<All Sections>";
            txtShift.Text = "<All Shifts>";
            txtAttendanceGroup1.Text = "<All Attendance Groups>";
            //txtWeek.Text = "<All Weeks>";

            dtp_FromDate.SetTime(DateTime.Now);
            dtptoDate.SetTime(DateTime.Now);

            txtEmpNo.IsEnabled = true;
            txtDivision.IsEnabled = clsConfig.bEnableDivision;
            txtDepartment.IsEnabled = clsConfig.bEnableDepartment;
            txtsection.IsEnabled = clsConfig.bEnableSection;
            txtShift.IsEnabled = true;

            if (!clsConfig.bEnableDivision)
                txtDivision.Visibility = Visibility.Collapsed;
            else
                txtDivision.Visibility = Visibility.Visible;

            if (!clsConfig.bEnableDepartment)
                txtDepartment.Visibility = Visibility.Collapsed;
            else
                txtDepartment.Visibility = Visibility.Visible;

            if (!clsConfig.bEnableSection)
                txtsection.Visibility = Visibility.Collapsed;
            else
                txtsection.Visibility = Visibility.Visible;

            //if (!clsConfig.bEnableAttendanceGroup1)
            //{
            //    txtAttendanceGroup1.Visibility = Visibility.Collapsed;
            //    txtWeek.Visibility = Visibility.Collapsed;
            //}
            //else
            //{
            //    txtAttendanceGroup1.Visibility = Visibility.Visible;
            //    txtWeek.Visibility = Visibility.Visible;
            //}

            chkHideAttendanceRevision.IsChecked = false;

            WJDate.SetTime(DateTime.Now, "");
            UC_Devicerawdata.ClearData();
            EmployeeViewer.ClearFields();
            LeaveViewer.ClearFields();

            foreach (DataGridTextColumn dd in LeaveViewer.grd_LeaveDetails.Columns)
            {
                switch (dd.Header.ToString())
                {
                    case "Leave Period":
                        dd.Visibility = System.Windows.Visibility.Collapsed;
                        break;
                    default:
                        break;
                }
            }

            foreach (DataGridTextColumn dd in LeaveViewer.grd_GatePass.Columns)
            {
                switch (dd.Header.ToString())
                {
                    case "Date":
                        dd.Visibility = System.Windows.Visibility.Collapsed;
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        #region Check validity
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;
            if (!clsValidation.Validate_EmptyValue(txtEmpNo))
            {
                bStatus = false;
            }
            return bStatus;
        }

        private bool checkGridSaveValidity()
        {
            bool bStatus = true;
            //if (grd_AttendanceEntry.Items.Count > 0)
            //{
            //    bStatus = true;
            //}

            return bStatus;
        }

        #endregion

        #region Search Event
        private void txtEmpNo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                EmployeeSelecttion(lstResult[0]);
            }
        }

        private void txtDevision_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Division);
            if (RowDataSearch.DialogResult == true)
            {
                txtDivision.Text = lstResult[1];
                txtDivision.Tag = lstResult[0];

                txtEmpNo.IsEnabled = false;
                txtShift.IsEnabled = false;
            }
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
                txtShift.IsEnabled = false;
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
                txtShift.IsEnabled = false;
            }
        }

        private void txtShift_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Shift);
            if (RowDataSearch.DialogResult == true)
            {
                txtShift.Text = lstResult[1];
                txtShift.Tag = lstResult[0];

                txtShift.IsEnabled = false;
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
                txtShift.IsEnabled = false;
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
                dtptoDate.SetTime(DateTime.Parse(lstResult[3]).Date);
            }
        }
        #endregion

        #region Grid Event
        private void grd_Main_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int iColumnIndex = e.Column.DisplayIndex;
            int irowID = dgr_Main.SelectedIndex;

            #region In Out Time Change
            if (iColumnIndex == 9 || iColumnIndex == 10 || iColumnIndex == 12 || iColumnIndex == 13)
            {
                DateTime dtDate = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["attendenceDate"].ToString());
                string sShiftID = dgr_Main.dt.Rows[irowID]["shift_ID"].ToString();

                DateTime IN_Date = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["InDate_E"].ToString());
                DateTime IN_Time = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["InTime_E"].ToString());
                DateTime Out_Date = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["OutDate_E"].ToString());
                DateTime Out_Time = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["OutTime_E"].ToString());

                #region Format DateTime
                DateTime dtTemp = clsConfig.defaultDateTime;
                TextBox t = e.EditingElement as TextBox;

                if (t.Text.Length == 0)
                    t.Text = "-";

                if (t.Text != "-" || t.Text.Length == 0)
                {
                    #region Validate Date In
                    if (iColumnIndex == 9)
                    {
                        try
                        {
                            dtTemp = DateTime.Parse(t.Text);
                            IN_Date = dtTemp;
                            t.Text = dtTemp.ToString(clsConfig.Format_Date);
                            dgr_Main.dt.Rows[irowID]["InDateTime_ID_E"] = 1;
                        }
                        catch (Exception)
                        {
                            SEACCMessageBox.Show("Oops..!", "Unsupported Date Time Format", MessageBoxButton.OK);
                            t.Text = (IN_Date == clsConfig.defaultDateTime) ? "-" : IN_Date.ToString(clsConfig.Format_Date);
                        }
                    }
                    #endregion

                    #region Validate Date out
                    else if (iColumnIndex == 12)
                    {
                        try
                        {
                            dtTemp = DateTime.Parse(t.Text);
                            Out_Date = dtTemp;
                            t.Text = dtTemp.ToString(clsConfig.Format_Date);
                            dgr_Main.dt.Rows[irowID]["OutDateTime_ID_E"] = 1;
                        }
                        catch (Exception)
                        {
                            SEACCMessageBox.Show("Oops..!", "Unsupported Date Time Format", MessageBoxButton.OK);
                            t.Text = (Out_Date == clsConfig.defaultDateTime) ? "-" : Out_Date.ToString(clsConfig.Format_Date);
                        }
                    }
                    #endregion

                    #region Validate Time in
                    else if (iColumnIndex == 10)
                    {
                        try
                        {
                            if (t.Text.Length > 2)
                            {
                                if (t.Text.Contains("-") == true)
                                {
                                    dtTemp = DateTime.Parse(t.Text.Replace('-', ':'));
                                }
                                else if (t.Text.Contains(".") == true)
                                {
                                    dtTemp = DateTime.Parse(t.Text.Replace('.', ':'));
                                }
                                else if (t.Text.Contains(":") == true)
                                {
                                    dtTemp = DateTime.Parse(t.Text);
                                }
                            }
                            else
                            {
                                dtTemp = DateTime.Parse(t.Text + ":00");
                            }
                            IN_Time = dtTemp;
                            t.Text = dtTemp.ToString(clsConfig.Format_Time);
                            dgr_Main.dt.Rows[irowID]["InDateTime_ID_E"] = 1;
                        }
                        catch (Exception)
                        {
                            SEACCMessageBox.Show("Oops..!", "Unsupported Date Time Format", MessageBoxButton.OK);
                            t.Text = (IN_Time == clsConfig.defaultDateTime) ? "-" : IN_Time.ToString(clsConfig.Format_Time);
                        }
                    }
                    #endregion

                    #region Validate Time out
                    else if (iColumnIndex == 13)
                    {
                        try
                        {
                            if (t.Text.Length > 2)
                            {
                                if (t.Text.Contains("-") == true)
                                {
                                    dtTemp = DateTime.Parse(t.Text.Replace('-', ':'));
                                }
                                else if (t.Text.Contains(".") == true)
                                {
                                    dtTemp = DateTime.Parse(t.Text.Replace('.', ':'));
                                }
                                else if (t.Text.Contains(":") == true)
                                {
                                    dtTemp = DateTime.Parse(t.Text);
                                }
                            }
                            else
                            {
                                dtTemp = DateTime.Parse(t.Text + ":00");
                            }

                            Out_Time = dtTemp;
                            t.Text = dtTemp.ToString(clsConfig.Format_Time);
                            dgr_Main.dt.Rows[irowID]["OutDateTime_ID_E"] = 1;
                        }
                        catch (Exception)
                        {
                            SEACCMessageBox.Show("Oops..!", "Unsupported Date Time Format", MessageBoxButton.OK);
                            t.Text = (Out_Time == clsConfig.defaultDateTime) ? "-" : Out_Time.ToString(clsConfig.Format_Time);
                        }
                    }
                    #endregion
                }
                #endregion

                #region Update hors wkd & ot

                DateTime dtmTimeIn = clsValidation.Merge_DateAndTime(IN_Date, IN_Time);
                DateTime dtmOutTime = clsValidation.Merge_DateAndTime(Out_Date, Out_Time);

                //clsValidation.GetMinutes(dgr_Main.dt.Rows[irowID]["OTApproved_Display_O"].ToString());
                updateRow(false, e.Row.GetIndex(), dtmTimeIn, dtmOutTime);
                #endregion
            }
            #endregion

            #region Validate OT Approved , NoPay Approved, Late
            #region Nopay, Late
            if (iColumnIndex == 23 || iColumnIndex == 24 || iColumnIndex == 26)
            {

                DateTime dtTemp = clsConfig.defaultDateTime;
                TextBox t = e.EditingElement as TextBox;

                if (t.Text == "0" || t.Text == "-" || t.Text == "00")
                {
                    t.Text = "00:00";
                }
                if (t.Text != "-" || t.Text.Length != 0)
                {
                    try
                    {
                        if (t.Text.Length > 2)
                        {
                            if (t.Text.Contains("-") == true)
                            {
                                dtTemp = DateTime.Parse(t.Text.Replace('-', ':'));
                            }
                            else if (t.Text.Contains(".") == true)
                            {
                                dtTemp = DateTime.Parse(t.Text.Replace('.', ':'));
                            }
                            else if (t.Text.Contains(":") == true)
                            {
                                dtTemp = DateTime.Parse(t.Text);
                            }
                        }
                        else
                        {
                            dtTemp = DateTime.Parse(t.Text + ":00");
                        }

                        t.Text = dtTemp.ToString(clsConfig.Format_Time);

                    }
                    catch (Exception)
                    {
                        SEACCMessageBox.Show("Oops..!", "Unsupported Date Time Format", MessageBoxButton.OK);
                        t.Text = (dtTemp == clsConfig.defaultDateTime) ? "00:00" : dtTemp.ToString(clsConfig.Format_Time);
                    }
                }
            }
            #endregion

            #region Normal OT,  Double OT, Triple OT
            if (iColumnIndex == 20 || iColumnIndex == 21 || iColumnIndex == 22)
            {
                string sTempTime = "";
                string sFinalTime = "";

                TextBox t = e.EditingElement as TextBox;
                TimeSpan tsTimeSpan = TimeSpan.Zero;

                if (t.Text == "0" || t.Text == "-" || t.Text == "00")
                {
                    t.Text = "00:00";
                }
                if (t.Text != "-" || t.Text.Length != 0)
                {
                    try
                    {
                        if (t.Text.Length > 2)
                        {
                            if (t.Text.Contains("-") == true)
                            {
                                sTempTime = t.Text.Replace('-', ':');
                                tsTimeSpan = clsValidation.SetTimeSpan(sTempTime);
                            }
                            else if (t.Text.Contains(".") == true)
                            {
                                sTempTime = t.Text.Replace('.', ':');
                                tsTimeSpan = clsValidation.SetTimeSpan(sTempTime);
                            }
                            else if (t.Text.Contains(":") == true)
                            {
                                sTempTime = t.Text;
                                tsTimeSpan = clsValidation.SetTimeSpan(sTempTime);
                            }
                        }
                        else
                        {
                            sTempTime = t.Text + ":00";
                            tsTimeSpan = clsValidation.SetTimeSpan(sTempTime);
                        }
                        sFinalTime = String.Format("{0:00}", tsTimeSpan.Hours + tsTimeSpan.Days * 24) + ":" + String.Format("{0:00}", tsTimeSpan.Minutes);
                        t.Text = sFinalTime.ToString();

                    }
                    catch (Exception)
                    {
                        SEACCMessageBox.Show("Oops..!", "Unsupported Date Time Format", MessageBoxButton.OK);
                        t.Text = (sFinalTime == clsConfig.defaultDateTime.ToString()) ? "00:00" : sFinalTime.ToString();
                    }
                }
            }
            #endregion
            #endregion
        }

        private void grd_Main_DG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var vDG_Cell = dgr_Main.GetCurrentCell();
                int irowID = dgr_Main.SelectedIndex;

                #region Shift
                if (vDG_Cell.Column.SortMemberPath == "ShiftName")
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
                            string sShiftName = "";
                            int iInDateTime_Id = 0, iOutDateTime_ID = 0;
                            DateTime dtDate = DateTime.Parse(dgr_Main.dt.Rows[irowID]["attendenceDate"].ToString());

                            iInDateTime_Id = int.Parse(dgr_Main.dt.Rows[irowID]["InDateTime_ID_E"].ToString());
                            iOutDateTime_ID = int.Parse(dgr_Main.dt.Rows[irowID]["OutDateTime_ID_E"].ToString());

                            DateTime IN_Date = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["InDate_E"].ToString());
                            DateTime IN_Time = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["InTime_E"].ToString());
                            DateTime Out_Date = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["OutDate_E"].ToString());
                            DateTime Out_Time = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["OutTime_E"].ToString());

                            DateTime dtmTimeIn = clsValidation.Merge_DateAndTime(IN_Date, IN_Time);
                            DateTime dtmOutTime = clsValidation.Merge_DateAndTime(Out_Date, Out_Time);

                            // updateRow(false, irowID, dtDate, dtmTimeIn, dtmOutTime, lstResult[0]);
                        }
                    }
                }
                #endregion

                else if (vDG_Cell.Column.SortMemberPath == "InDate_E")
                {
                    string sOldDate = dgr_Main.dt.Rows[irowID]["InDate_E"].ToString();
                    if (sOldDate == "-")
                    {
                        string sDate = dgr_Main.dt.Rows[irowID]["Shift_StartTime"].ToString();
                        if (sDate == "N/A")
                            sDate = dgr_Main.dt.Rows[irowID]["attendenceDate"].ToString();
                        else
                            sDate = dgr_Main.dt.Rows[irowID]["attendenceDate"].ToString();

                        DateTime dtmShiftIn = clsValidation.Validate_DateTime(sDate);
                        dgr_Main.dt.Rows[irowID]["InDate_E"] = clsValidation.GetDisplayValue_Date(dtmShiftIn);
                    }
                }
                else if (vDG_Cell.Column.SortMemberPath == "OutDate_E")
                {
                    string sOldDate = dgr_Main.dt.Rows[irowID]["OutDate_E"].ToString();
                    if (sOldDate == "-")
                    {
                        string sDate = dgr_Main.dt.Rows[irowID]["Shift_EndTime"].ToString();
                        if (sDate == "N/A")
                            sDate = dgr_Main.dt.Rows[irowID]["attendenceDate"].ToString();
                        else
                            sDate = dgr_Main.dt.Rows[irowID]["attendenceDate"].ToString();

                        DateTime dtmShiftIn = clsValidation.Validate_DateTime(sDate);
                        dgr_Main.dt.Rows[irowID]["OutDate_E"] = clsValidation.GetDisplayValue_Date(dtmShiftIn);
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void dgr_Main_DG_MouseRightClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                //var vDG_Cell = dgr_Main.GetCurrentCell();
                //int irowID = dgr_Main.SelectedIndex;
                //if (vDG_Cell.Column.SortMemberPath == "InDate_E" || vDG_Cell.Column.SortMemberPath == "InTime_E" || vDG_Cell.Column.SortMemberPath == "OutDate_E" || vDG_Cell.Column.SortMemberPath == "OutTime_E")
                //{
                //    DateTime dtmAttendenceDate = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["attendenceDate"].ToString());
                //    string sEmployeeID = dgr_Main.dt.Rows[irowID]["employee_ID"].ToString();
                //    UC_Devicerawdata.RefrshGrid(sEmployeeID, dtmAttendenceDate);
                //}
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
                //throw;
            }
        }

        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            int irowID = dgr_Main.SelectedIndex;
            var vDG_Cell = dgr_Main.GetCurrentCell();

            #region OT Applicable Checkbox update
            try
            {
                if (vDG_Cell.Column.SortMemberPath == "OT_E")
                {
                    bool bOtApplicable = false;
                    string sOtHours = "00:00";
                    bOtApplicable = dgr_Main.dt.Rows[irowID]["OT_E"].ToString() == "True" ? true : false;

                    if (!bOtApplicable)
                    {
                        sOtHours = dgr_Main.dt.Rows[irowID]["OTHours_Display_E"].ToString();
                    }
                    dgr_Main.dt.Rows[irowID]["OT_E"] = bOtApplicable ? false : true;
                    dgr_Main.dt.Rows[irowID]["OTApproved_Display_E"] = sOtHours;
                }
            }
            catch (Exception) { }
            #endregion

            #region Update Employee Viewer
            try
            {
                exp_More.IsExpanded = true;
                exp_Selection.IsExpanded = false;

                EmployeeViewer.ClearFields();
                LeaveViewer.ClearFields();

                string sEmployeeid = dgr_Main.dt.Rows[irowID]["employee_ID"].ToString();
                string sDayType = dgr_Main.dt.Rows[irowID]["Day"].ToString();
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
                    uc_AttendenceRev.RefreshGrid(sEmployeeID, dtmAttendenceDate);
                }
            }
            catch (Exception) { }
            #endregion
        }

        private void dgr_Main_DG_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Delete)
                {
                    string sColumn = dgr_Main.GetCurrentCell().Column.SortMemberPath;
                    if (sColumn == "InDate_E" || sColumn == "OutDate_E" || sColumn == "InTime_E" || sColumn == "OutTime_E")
                    {
                        int irowID = dgr_Main.SelectedIndex;

                        if (sColumn == "InDate_E")
                        {
                            dgr_Main.dt.Rows[irowID]["InDate_E"] = "-";

                        }
                        else if (sColumn == "OutDate_E")
                        {
                            dgr_Main.dt.Rows[irowID]["OutDate_E"] = "-";
                        }
                        else if (sColumn == "InTime_E")
                        {
                            dgr_Main.dt.Rows[irowID]["InTime_E"] = "-";
                        }
                        else if (sColumn == "OutTime_E")
                        {
                            dgr_Main.dt.Rows[irowID]["OutTime_E"] = "-";
                        }

                        updateRow(false, irowID, clsConfig.defaultDateTime, clsConfig.defaultDateTime);
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
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
        #endregion

        #region Date Selection Event
        private void dtp_FromDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dtptoDate.SetTime(dtp_FromDate.GetDateTime());
        }
        #endregion

        #region Show/Hide Attendance Revisions Check box Event
        private void chkHideAttendanceRevision_checkBox_Checked(object sender, EventArgs e)
        {
            uc_AttendenceRev.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void chkHideAttendanceRevision_checkBox_Unchecked(object sender, EventArgs e)
        {
            uc_AttendenceRev.Visibility = System.Windows.Visibility.Visible;
        }
        #endregion

        private void updateRow(bool isInitialization, int irowID, DateTime dtmTimeIn, DateTime dtmTimeOut)
        {
            AttendenceRecord firstDay = new AttendenceRecord(dgr_Main.dt.Rows[irowID]);
            firstDay.dtmTimeIn = dtmTimeIn;
            firstDay.dtmTimeOut = dtmTimeOut;

            if (firstDay.oShift != null) //Added this line only on 2016-09-27
            {
                switch (firstDay.ShiftType)
                {
                    #region OneDayShift and Midnight Cross shift
                    case ShiftTypes.MidnightCross:
                    case ShiftTypes.OneDayShift:
                        {
                            #region Shift Working Hours
                            if (firstDay.dtmTimeOut == clsConfig.defaultDateTime && firstDay.dtmTimeIn == clsConfig.defaultDateTime)
                            {
                                //both times missing
                                firstDay.sTotalHours = "00:00";
                            }
                            else if (firstDay.dtmTimeOut == clsConfig.defaultDateTime || firstDay.dtmTimeIn == clsConfig.defaultDateTime)
                            {
                                //only one time missing
                                firstDay.sTotalHours = "ERROR";
                            }
                            else
                            {
                                //ok
                                TimeSpan TsTotalWorkedHours = (firstDay.dtmTimeOut - firstDay.dtmTimeIn);
                                firstDay.sTotalHours = clsValidation.GetDisplayValue_Hours(TsTotalWorkedHours);

                                firstDay.sWorkedHours = firstDay.sTotalHours;
                                if ((!firstDay.oShift.IsEarlyOtApplicable) && firstDay.dtmShiftStart != clsConfig.defaultDateTime && firstDay.dtmTimeIn < firstDay.dtmShiftStart)
                                {
                                    TimeSpan TsWorkedHours = (firstDay.dtmTimeOut - firstDay.dtmShiftStart);
                                    firstDay.sWorkedHours = clsValidation.GetDisplayValue_Hours(TsWorkedHours);
                                }

                                //if (true && firstDay.dtmShiftStart != clsConfig.defaultDateTime && firstDay.dtmTimeOut < firstDay.dtmShiftStart)
                                //{
                                //    TimeSpan TsWorkedHours = (firstDay.dtmTimeOut - firstDay.dtmShiftStart);
                                //    firstDay.sWorkedHours = clsValidation.GetDisplayValue_Hours(TsWorkedHours);
                                //}
                                //else
                                //    firstDay.sWorkedHours = firstDay.sTotalHours;
                            }
                            #endregion

                            #region Shift OT
                            DateTime dtmTimein_Temp = firstDay.dtmTimeIn;
                            DateTime dtmTimeOut_Temp = firstDay.dtmTimeOut;

                            #region early OT
                            if (firstDay.oShift.IsEarlyOtApplicable && firstDay.dtmShiftStart != clsConfig.defaultDateTime)
                            {
                                if (firstDay.dtmTimeIn > firstDay.dtmShiftStart)
                                    dtmTimein_Temp = firstDay.dtmShiftStart;
                            }
                            else
                            {
                                if (firstDay.dtmShiftStart != clsConfig.defaultDateTime)
                                    dtmTimein_Temp = firstDay.dtmShiftStart;
                            }
                            #endregion

                            #region early ot grace period
                            if (firstDay.dtmShiftStart != clsConfig.defaultDateTime && firstDay.dtmShiftStart > firstDay.dtmTimeIn)
                            {
                                TimeSpan Tstemp = (firstDay.dtmShiftStart - firstDay.dtmTimeIn);
                                int iTemp = Tstemp.Minutes + Tstemp.Hours * 60 + Tstemp.Days * 24 * 60;

                                if (iTemp < firstDay.oShift.Shift_EarlyOTGracePeroiod)
                                    dtmTimein_Temp = firstDay.dtmShiftStart;
                            }
                            #endregion

                            #region OT grase period
                            if (firstDay.dtmShiftEnd_minimum != clsConfig.defaultDateTime && firstDay.dtmTimeOut != clsConfig.defaultDateTime)
                            {
                                TimeSpan Tstemp = (firstDay.dtmTimeOut - firstDay.dtmShiftEnd_Actual);
                                int iTemp = Tstemp.Minutes + Tstemp.Hours * 60 + Tstemp.Days * 24 * 60;

                                if (iTemp < firstDay.oShift.Shift_OTGracePeroiod)
                                    dtmTimeOut_Temp = firstDay.dtmShiftEnd_Actual;
                            }
                            #endregion

                            #region OT Initialize - with early ot and grase period
                            TimeSpan TsOThours = (dtmTimeOut_Temp - dtmTimein_Temp).Add(-(firstDay.dtmShiftEnd_Actual - firstDay.dtmShiftStart));
                            int iOTHors = (TsOThours.Hours < 0 || TsOThours.Minutes < 0) ? 0 : clsValidation.GetMinutes(TsOThours); //TsOThours.Hours * 60 + TsOThours.Days * 24 * 60 + TsOThours.Minutes;
                            #endregion

                            #region OT Round
                            #region Shift Grace Period
                            //- Only Develop for Satureday - This is AKTHARI Requirement
                            //- 2016-11-08 by Gayan
                            if (clsConfig.bEnable_ShiftGracePeriod_Deduction)
                            {
                                if (firstDay.dtDate.DayOfWeek == DayOfWeek.Saturday && firstDay.oShift.IsSaturdaySpecialWH)
                                {
                                    if (firstDay.oShift.ShiftGracePeriod_Saturday < iOTHors)
                                    {
                                        iOTHors -= firstDay.oShift.ShiftGracePeriod_Saturday;
                                        TsOThours -= TimeSpan.FromMinutes(firstDay.oShift.ShiftGracePeriod_Saturday);
                                    }
                                }
                            }
                            #endregion

                            int iRemainder = 0;
                            OTRoundingMode enm_OTRoundMode = (OTRoundingMode)firstDay.oShift.Shift_OTRoundMode;
                            if (firstDay.oShift.Shift_OTRoundMinutes != 0)
                                switch (enm_OTRoundMode)
                                {
                                    case OTRoundingMode.Disable:
                                        break;
                                    case OTRoundingMode.Round:
                                        {
                                            iRemainder = (iOTHors % firstDay.oShift.Shift_OTRoundMinutes);
                                            if (iRemainder <= firstDay.oShift.Shift_OTRoundMinutes / 2)
                                                iRemainder = -iRemainder;
                                            else
                                                iRemainder = firstDay.oShift.Shift_OTRoundMinutes - iRemainder;
                                        }
                                        break;
                                    case OTRoundingMode.RoundUp:
                                        {
                                            iRemainder = (iOTHors % firstDay.oShift.Shift_OTRoundMinutes);
                                            if (iRemainder > 0)
                                                iRemainder = firstDay.oShift.Shift_OTRoundMinutes - iRemainder;
                                        }
                                        break;
                                    case OTRoundingMode.RoundDown:
                                        iRemainder = -(iOTHors % firstDay.oShift.Shift_OTRoundMinutes);
                                        break;
                                }

                            TsOThours = TsOThours + TimeSpan.FromMinutes(iRemainder);
                            #endregion

                            #region Lunch Duration Deduction from OT
                            DateTime dtmLunchTime = clsValidation.Merge_DateAndTime(firstDay.dtDate, firstDay.oShift.LunchStartTime);
                            if ((!(firstDay.dtmShiftEnd_Actual >= dtmLunchTime)) && firstDay.dtmTimeIn < dtmLunchTime)
                            {
                                TimeSpan TsLunchDuration = TimeSpan.FromMinutes(firstDay.oShift.LunchDurationMins);
                                switch (firstDay.sDayType)
                                {
                                    case "Working Day":
                                        if (firstDay.oShift.IsOTLunchDeduction_Weekday)
                                            TsOThours -= TsLunchDuration;
                                        break;
                                    case "Saturday":
                                        if (firstDay.oShift.IsOTLunchDeduction_Saturday)
                                            TsOThours -= TsLunchDuration;
                                        break;
                                    case "Sunday":
                                        if (firstDay.oShift.IsOTLunchDeduction_Sundy)
                                            TsOThours -= TsLunchDuration;
                                        break;
                                    case "HoliDay":
                                        if (firstDay.oShift.IsOTLunchDeduction_CompanyHoliday)
                                            TsOThours -= TsLunchDuration;
                                        break;
                                    case "Poyaday":
                                        if (firstDay.oShift.IsOTLunchDeduction_Poyaday)
                                            TsOThours -= TsLunchDuration;
                                        break;
                                }
                            }
                            #endregion


                            TimeSpan tsOTHours_Temp = TsOThours;
                            #region OT - Double OT Breakdown
                            if (clsConfig.bEnableDoubleOT && (firstDay.dtDate.DayOfWeek == DayOfWeek.Sunday || (clsConfig.bEnableDoubleOT_Holidays && (firstDay.sDayType == "Poyaday" || firstDay.sDayType == "HoliDay"))))
                                firstDay.sDoubleOTHours = GetDisplayValue_Hours(TsOThours);
                            else
                            {
                                TimeSpan ts_DubOT = TimeSpan.Zero;
                                if (clsConfig.bEnableDoubleOT && clsConfig.bEnableDoubleOT_InWorkingDays && firstDay.dtmShiftEnd_Actual != clsValidation.defaultDateTime && firstDay.dtmTimeOut > firstDay.dtmShiftEnd_Actual.AddMinutes(firstDay.oShift.Shift_OTMinuteMax))
                                {
                                    ts_DubOT = firstDay.dtmTimeOut - firstDay.dtmShiftEnd_Actual.AddMinutes(firstDay.oShift.Shift_OTMinuteMax);
                                    firstDay.sDoubleOTHours = GetDisplayValue_Hours(ts_DubOT);

                                    TsOThours -= ts_DubOT;
                                }
                                else if (clsConfig.bEnableDoubleOT && clsConfig.bEnableDoubleOT_InWorkingDays && firstDay.dtmShiftEnd_Actual == clsValidation.defaultDateTime)
                                {
                                    DateTime dtm_OT_EndTime = clsValidation.Merge_DateAndTime(firstDay.dtDate, firstDay.oShift.ShiftStartTime).AddMinutes(firstDay.oShift.ShiftMinutes + firstDay.oShift.Shift_OTMinuteMax);
                                    ts_DubOT = firstDay.dtmTimeOut - dtm_OT_EndTime;
                                    firstDay.sDoubleOTHours = GetDisplayValue_Hours(ts_DubOT);

                                    if (ts_DubOT > TimeSpan.Zero)
                                        TsOThours -= ts_DubOT;
                                }

                                firstDay.sOTHours = GetDisplayValue_Hours(TsOThours);
                            }


                            //if (clsConfig.bEnableShiftRules_Selmo)
                            //{
                            //    //female ot calculation
                            //    tbl_genMasEmployee oEmp = tbl_genMasEmployee.Select(firstDay.empID, clsSecurity.CompanyID, clsSecurity.BranchID);
                            //    if (oEmp.Gender == (int)Gender.Female)
                            //    {
                            //        if (clsConfig.bEnableDoubleOT && clsConfig.bEnableDoubleOT_InWorkingDays && (firstDay.dtDate.DayOfWeek != DayOfWeek.Sunday && (firstDay.sDayType != "Poyaday" || firstDay.sDayType != "HoliDay")))
                            //        {
                            //            TimeSpan ts_DubOT = TimeSpan.Zero;
                            //            DateTime dtDay = firstDay.dtmTimeIn.Date;
                            //            DateTime dtMidNight = dtDay.AddHours(24);
                            //            if (firstDay.dtmTimeOut > dtMidNight)
                            //            {
                            //                ts_DubOT = firstDay.dtmTimeOut - dtMidNight;
                            //                firstDay.sDoubleOTHours = GetDisplayValue_Hours(ts_DubOT);
                            //                tsOTHours_Temp -= ts_DubOT;
                            //            }
                            //            firstDay.sOTHours = GetDisplayValue_Hours(tsOTHours_Temp);
                            //        }
                            //    }
                            //}
                            #endregion
                            #endregion

                            #region No Pay
                            if (firstDay.dtmShiftStart != clsConfig.defaultDateTime && firstDay.dtmShiftEnd_minimum != clsConfig.defaultDateTime)
                            {
                                TimeSpan TsNonWorkingHours = new TimeSpan();
                                if (firstDay.dtmTimeOut != clsConfig.defaultDateTime && firstDay.dtmTimeIn != clsConfig.defaultDateTime)
                                {
                                    #region Nopay-Early
                                    DateTime dtmTimein_Temp2 = firstDay.dtmTimeIn;
                                    TimeSpan Tstemp2 = firstDay.dtmTimeIn - firstDay.dtmShiftStart;
                                    int iTemp2 = Tstemp2.Minutes + Tstemp2.Hours * 60 + Tstemp2.Days * 24 * 60;

                                    if (iTemp2 <= firstDay.oShift.ShiftGracePeriod)
                                    {
                                        dtmTimein_Temp2 = firstDay.dtmShiftStart;
                                    }
                                    Tstemp2 = dtmTimein_Temp2 - firstDay.dtmShiftStart;
                                    #endregion

                                    #region Nopay-later
                                    /* Early exit time calculation
                                     * Hero Group takes "Actual ShiftEnd Time"
                                     * Others takes "ShiftEnd Minimum Time"
                                     * Config "bEnableShiftEnd_Actual_forEarlyExit" added by Gayan
                                     * On 2017-05-16 
                                     */
                                    TimeSpan Tstemp3;
                                    if (clsConfig.bEnableShiftEnd_Actual_forEarlyExit)
                                        Tstemp3 = firstDay.dtmShiftEnd_Actual - firstDay.dtmTimeOut;
                                    else
                                        Tstemp3 = firstDay.dtmShiftEnd_minimum - firstDay.dtmTimeOut;

                                    int iTemp3 = Tstemp3.Minutes + Tstemp3.Hours * 60 + Tstemp3.Days * 24 * 60;
                                    if (iTemp3 < 0)
                                    {
                                        Tstemp3 = TimeSpan.FromTicks(0);
                                    }
                                    #endregion

                                    TsNonWorkingHours = Tstemp2 + Tstemp3;
                                }
                                else
                                {
                                    TsNonWorkingHours = firstDay.dtmShiftEnd_minimum - firstDay.dtmShiftStart;
                                }
                                firstDay.sNonWorkingMins = (TsNonWorkingHours.Hours < 0 || TsNonWorkingHours.Minutes < 0) ? "0:00" : String.Format("{0:00}", TsNonWorkingHours.Hours + TsNonWorkingHours.Days * 24) + ":" + String.Format("{0:00}", TsNonWorkingHours.Minutes);
                            }
                            else
                                firstDay.sNonWorkingMins = "00:00";
                            #endregion
                        }
                        break;
                    #endregion

                    #region TwoDayShift
                    case ShiftTypes.TwoDayShift:
                        {
                            if (firstDay.iShiftDay == 1)
                            {
                                if (!isInitialization)
                                {
                                    AttendenceRecord NextDay = new AttendenceRecord(dgr_Main.dt.Rows[irowID + 1]);

                                    #region Shift Working Hours
                                    if (firstDay.dtmTimeIn == clsConfig.defaultDateTime && NextDay.dtmTimeOut == clsConfig.defaultDateTime)
                                    {
                                        //both times missing
                                        firstDay.sTotalHours = "0:00";
                                    }
                                    else if (firstDay.dtmTimeIn == clsConfig.defaultDateTime || NextDay.dtmTimeOut == clsConfig.defaultDateTime)
                                    {
                                        //only one time missing
                                        firstDay.sTotalHours = "ERROR";
                                    }
                                    else
                                    {
                                        //ok
                                        TimeSpan TsWorkedHours = (NextDay.dtmTimeOut - firstDay.dtmTimeIn);
                                        firstDay.sTotalHours = (TsWorkedHours.Hours < 0 || TsWorkedHours.Minutes < 0) ? "ERROR" : String.Format("{0:00}", TsWorkedHours.Hours + TsWorkedHours.Days * 24) + ":" + String.Format("{0:00}", TsWorkedHours.Minutes);
                                    }
                                    #endregion
                                }
                            }
                            else if (firstDay.iShiftDay == 2)
                            {
                                AttendenceRecord PreviusDay = new AttendenceRecord(dgr_Main.dt.Rows[irowID - 1]);

                                DateTime dtmTimeIN = PreviusDay.dtmTimeIn;
                                DateTime dtmTimeOUT = firstDay.dtmTimeOut;

                                TimeSpan TsWorkedHours_Day1 = new TimeSpan();
                                TimeSpan TsWorkedHours_Day2 = new TimeSpan();

                                #region Error Initialize Data and Time
                                if (PreviusDay.dtmTimeIn == clsConfig.defaultDateTime && firstDay.dtmTimeOut == clsConfig.defaultDateTime)
                                {
                                    //both times missing
                                    PreviusDay.sTotalHours = "0:00";
                                    firstDay.sTotalHours = "0:00";
                                }
                                else if (PreviusDay.dtmTimeIn == clsConfig.defaultDateTime || firstDay.dtmTimeOut == clsConfig.defaultDateTime)
                                {
                                    //only one time missing
                                    PreviusDay.sTotalHours = "ERROR";
                                    firstDay.sTotalHours = "ERROR";
                                }
                                #endregion

                                else
                                {
                                    //ok
                                    #region No Pay

                                    int iLateMinutes_Early = 0, iLateMinutes_Later = 0;

                                    #region Nopay-Early

                                    if (dtmTimeIN != clsConfig.defaultDateTime)
                                    {
                                        TimeSpan Tstemp = dtmTimeIN - PreviusDay.dtmShiftStart;
                                        iLateMinutes_Early = clsValidation.GetMinutes(Tstemp);

                                        if (iLateMinutes_Early <= PreviusDay.oShift.ShiftGracePeriod)
                                            iLateMinutes_Early = 0;
                                    }

                                    #endregion

                                    #region Nopay-later

                                    if (dtmTimeOUT != clsConfig.defaultDateTime)
                                    {
                                        TimeSpan Tstemp = firstDay.dtmShiftEnd_minimum - dtmTimeOUT;
                                        iLateMinutes_Later = clsValidation.GetMinutes(Tstemp);

                                        if (iLateMinutes_Later < 0)
                                            iLateMinutes_Later = 0;

                                    }

                                    #endregion

                                    PreviusDay.sNonWorkingMins = clsValidation.GetDisplayValue_Hours(iLateMinutes_Early + iLateMinutes_Later);
                                    firstDay.sNonWorkingMins = "N/A";
                                    #endregion

                                    #region OT
                                    int iOTHours_Later = 0, iOTHours_Early = 0;

                                    #region Early OT
                                    TimeSpan Tstemp1 = PreviusDay.dtmShiftStart - dtmTimeIN;
                                    iOTHours_Early = clsValidation.GetMinutes(Tstemp1);
                                    if (PreviusDay.oShift.IsEarlyOtApplicable)
                                    {
                                        if (PreviusDay.dtmTimeIn > PreviusDay.dtmShiftStart)
                                            dtmTimeIN = PreviusDay.dtmShiftStart;

                                        iOTHours_Early = 0;
                                    }
                                    else
                                    {
                                        if (iOTHours_Early > 0)
                                            dtmTimeIN = PreviusDay.dtmShiftStart;

                                        iOTHours_Early = 0;
                                    }
                                    #endregion

                                    #region early ot grace period
                                    if (PreviusDay.dtmShiftStart != clsConfig.defaultDateTime && PreviusDay.dtmShiftStart > PreviusDay.dtmTimeIn)
                                    {
                                        TimeSpan Tstemp = (PreviusDay.dtmShiftStart - PreviusDay.dtmTimeIn);
                                        int iTemp = Tstemp.Minutes + Tstemp.Hours * 60 + Tstemp.Days * 24 * 60;

                                        if (iTemp < PreviusDay.oShift.Shift_EarlyOTGracePeroiod)
                                            dtmTimeIN = PreviusDay.dtmShiftStart;
                                    }
                                    #endregion

                                    #region OT grase period
                                    TimeSpan TsTimeDiff_Out = dtmTimeOUT - firstDay.dtmShiftEnd_Actual;
                                    int iTimeDiff_Out = clsValidation.GetMinutes(TsTimeDiff_Out);

                                    if (iTimeDiff_Out > 0 && iTimeDiff_Out < firstDay.oShift.Shift_OTGracePeroiod)
                                        dtmTimeOUT = firstDay.dtmShiftEnd_Actual;
                                    #endregion

                                    #region Get OT Hours with early ot and grase period
                                    OTRoundingMode enm_OTRoundMode = (OTRoundingMode)firstDay.oShift.Shift_OTRoundMode;

                                    TimeSpan tsOTHours = (dtmTimeOUT - dtmTimeIN).Add(-(TimeSpan.FromMinutes(PreviusDay.ishiftMinutes)));
                                    iOTHours_Later = (tsOTHours.Hours < 0 || tsOTHours.Minutes < 0) ? 0 : clsValidation.GetMinutes(tsOTHours);
                                    #endregion

                                    #region OT Round
                                    if (iOTHours_Later > 0)
                                    {
                                        int iRemainder = 0;
                                        switch (enm_OTRoundMode)
                                        {
                                            case OTRoundingMode.Disable:
                                                break;
                                            case OTRoundingMode.Round:
                                                {
                                                    if (firstDay.oShift.Shift_OTRoundMinutes == 0)
                                                    {
                                                        iRemainder = 0;
                                                    }
                                                    else
                                                        iRemainder = (iOTHours_Later % firstDay.oShift.Shift_OTRoundMinutes);

                                                    if (iRemainder <= firstDay.oShift.Shift_OTRoundMinutes / 2)
                                                        iRemainder = -iRemainder;
                                                    else
                                                        iRemainder = firstDay.oShift.Shift_OTRoundMinutes - iRemainder;
                                                }
                                                break;
                                            case OTRoundingMode.RoundUp:
                                                {
                                                    iRemainder = (iOTHours_Later % firstDay.oShift.Shift_OTRoundMinutes);
                                                    if (iRemainder > 0)
                                                        iRemainder = firstDay.oShift.Shift_OTRoundMinutes - iRemainder;
                                                }
                                                break;
                                            case OTRoundingMode.RoundDown:

                                                iRemainder = -(iOTHours_Later % firstDay.oShift.Shift_OTRoundMinutes);
                                                break;
                                        }
                                        tsOTHours = tsOTHours + TimeSpan.FromMinutes(iRemainder);
                                        //iOTHours_Later = iOTHours_Later + iRemainder;
                                    }
                                    #endregion

                                    //add Double OT for Sunday is Shiftday only first day
                                    #region Double OT
                                    if (clsConfig.bEnableDoubleOT && (PreviusDay.dtDate.DayOfWeek == DayOfWeek.Sunday || (clsConfig.bEnableDoubleOT_Holidays && (PreviusDay.sDayType == "Poyaday" || PreviusDay.sDayType == "HoliDay"))))
                                    {
                                        if (tsOTHours <= TimeSpan.FromMinutes(1430))
                                        {
                                            PreviusDay.sDoubleOTHours = GetDisplayValue_Hours(tsOTHours);
                                            firstDay.sDoubleOTHours = "N/A";

                                            tsOTHours -= tsOTHours;
                                        }
                                        else
                                        {
                                            PreviusDay.sDoubleOTHours = GetDisplayValue_Hours(TimeSpan.FromMinutes(900));
                                            firstDay.sDoubleOTHours = GetDisplayValue_Hours(tsOTHours - TimeSpan.FromMinutes(900));

                                            tsOTHours -= tsOTHours;
                                        }
                                    }
                                    //else
                                    //{
                                    //    TimeSpan ts_DubOT = TimeSpan.Zero;
                                    //    if (clsConfig.bEnableDoubleOT && clsConfig.bEnableDoubleOT_InWorkingDays && firstDay.dtmShiftEnd_Actual != clsValidation.defaultDateTime && firstDay.dtmTimeOut > firstDay.dtmShiftEnd_Actual.AddMinutes(firstDay.oShift.Shift_OTMinuteMax))
                                    //    {
                                    //        ts_DubOT = firstDay.dtmTimeOut - firstDay.dtmShiftEnd_Actual.AddMinutes(firstDay.oShift.Shift_OTMinuteMax);

                                    //        PreviusDay.sDoubleOTHours = GetDisplayValue_Hours(tsOTHours);
                                    //        if (ts_DubOT > TimeSpan.Zero)
                                    //            tsOTHours -= ts_DubOT;
                                    //    }
                                    //    else if (clsConfig.bEnableDoubleOT && clsConfig.bEnableDoubleOT_InWorkingDays && firstDay.dtmShiftEnd_Actual == clsValidation.defaultDateTime)
                                    //    {
                                    //        DateTime dtm_OT_EndTime = clsValidation.Merge_DateAndTime(firstDay.dtDate, firstDay.oShift.ShiftStartTime).AddMinutes(firstDay.oShift.ShiftMinutes + firstDay.oShift.Shift_OTMinuteMax);
                                    //        ts_DubOT = firstDay.dtmTimeOut - dtm_OT_EndTime;

                                    //        PreviusDay.sDoubleOTHours = GetDisplayValue_Hours(tsOTHours);
                                    //        if (ts_DubOT > TimeSpan.Zero)
                                    //            tsOTHours -= ts_DubOT;
                                    //    }

                                    //    PreviusDay.sOTHours = GetDisplayValue_Hours(tsOTHours);
                                    //}
                                    #endregion

                                    //OT Hrs Divide in to Two days
                                    #region Single OT
                                    if (tsOTHours <= TimeSpan.FromMinutes(1430))
                                    {
                                        PreviusDay.sOTHours = clsValidation.GetDisplayValue_Hours(tsOTHours);
                                        firstDay.sOTHours = "N/A";
                                    }
                                    else
                                    {
                                        PreviusDay.sOTHours = clsValidation.GetDisplayValue_Hours(TimeSpan.FromMinutes(900));
                                        firstDay.sOTHours = clsValidation.GetDisplayValue_Hours(tsOTHours - TimeSpan.FromMinutes(900));
                                    }
                                    #endregion

                                    #endregion

                                    #region Total Hours
                                    TimeSpan TsTotalHours = (firstDay.dtmTimeOut - PreviusDay.dtmTimeIn);
                                    PreviusDay.sTotalHours = clsValidation.GetDisplayValue_Hours(TsTotalHours);
                                    firstDay.sTotalHours = "N/A";
                                    #endregion

                                    #region Worked Hours
                                    TimeSpan TsWorkedHours = (dtmTimeOUT - dtmTimeIN);
                                    PreviusDay.sWorkedHours = clsValidation.GetDisplayValue_Hours(TsWorkedHours);
                                    firstDay.sWorkedHours = "N/A";
                                    #endregion
                                }

                                PreviusDay.UpdateRDataTable(isInitialization, dgr_Main.dt.Rows[irowID - 1]);
                            }
                        }
                        break;
                    #endregion

                    #region FlexibalShift
                    case ShiftTypes.FlexibalShift:
                        {
                            #region Shift Working Hours
                            if (firstDay.dtmTimeOut == clsConfig.defaultDateTime && firstDay.dtmTimeIn == clsConfig.defaultDateTime)
                            {
                                //both times missing
                                firstDay.sTotalHours = "00:00";
                            }
                            else if (firstDay.dtmTimeOut == clsConfig.defaultDateTime || firstDay.dtmTimeIn == clsConfig.defaultDateTime)
                            {
                                //only one time missing
                                firstDay.sTotalHours = "ERROR";
                            }
                            else
                            {
                                //ok
                                TimeSpan TsTotalWorkedHours = (firstDay.dtmTimeOut - firstDay.dtmTimeIn);
                                firstDay.sTotalHours = clsValidation.GetDisplayValue_Hours(TsTotalWorkedHours);
                                firstDay.sWorkedHours = clsValidation.GetDisplayValue_Hours(TsTotalWorkedHours);

                            }
                            #endregion

                            #region OT
                            int iOT_Mins = clsValidation.GetMinutes(firstDay.sWorkedHours) - firstDay.ishiftMinutes;
                            TimeSpan TsOThours_Flexi = TimeSpan.Zero;
                            if (iOT_Mins > 0)
                                TsOThours_Flexi = TimeSpan.FromMinutes(iOT_Mins);

                            OTRoundingMode enm_OTRoundMode_Flexi = (OTRoundingMode)firstDay.oShift.Shift_OTRoundMode;
                            int iOTHors_Flexi = (TsOThours_Flexi.Hours < 0 || TsOThours_Flexi.Minutes < 0) ? 0 : TsOThours_Flexi.Hours * 60 + TsOThours_Flexi.Days * 24 * 60 + TsOThours_Flexi.Minutes;

                            #region OT Round Down
                            int iRemainder_Flexi = 0;
                            if (firstDay.oShift.Shift_OTRoundMinutes != 0)
                                switch (enm_OTRoundMode_Flexi)
                                {
                                    case OTRoundingMode.Disable:
                                        break;
                                    case OTRoundingMode.Round:
                                        {
                                            iRemainder_Flexi = (iOTHors_Flexi % firstDay.oShift.Shift_OTRoundMinutes);
                                            if (iRemainder_Flexi <= firstDay.oShift.Shift_OTRoundMinutes / 2)
                                                iRemainder_Flexi = -iRemainder_Flexi;
                                            else
                                                iRemainder_Flexi = firstDay.oShift.Shift_OTRoundMinutes - iRemainder_Flexi;
                                        }
                                        break;
                                    case OTRoundingMode.RoundUp:
                                        {
                                            iRemainder_Flexi = (iOTHors_Flexi % firstDay.oShift.Shift_OTRoundMinutes);
                                            if (iRemainder_Flexi > 0)
                                                iRemainder_Flexi = firstDay.oShift.Shift_OTRoundMinutes - iRemainder_Flexi;
                                        }
                                        break;
                                    case OTRoundingMode.RoundDown:
                                        iRemainder_Flexi = -(iOTHors_Flexi % firstDay.oShift.Shift_OTRoundMinutes);
                                        break;
                                }
                            TsOThours_Flexi = TsOThours_Flexi + TimeSpan.FromMinutes(iRemainder_Flexi);
                            #endregion

                            //firstDay.sOTHours = (TsOThours_Flexi.Hours < 0 || TsOThours_Flexi.Minutes < 0 || TsOThours_Flexi.Days > 50) ? "00:00" : String.Format("{0:00}", TsOThours_Flexi.Hours + TsOThours_Flexi.Days * 24) + ":" + String.Format("{0:00}", TsOThours_Flexi.Minutes);
                            #endregion

                            #region Double OT Breakdown
                            if (clsConfig.bEnableDoubleOT && (firstDay.dtDate.DayOfWeek == DayOfWeek.Sunday || clsConfig.bEnableDoubleOT_Holidays && (firstDay.sDayType == "HoliDay" || firstDay.sDayType == "Poyaday")))//add config for holidays double ot applicable - janith
                                firstDay.sDoubleOTHours = (TsOThours_Flexi.Hours < 0 || TsOThours_Flexi.Minutes < 0 || TsOThours_Flexi.Days > 50) ? "00:00" : String.Format("{0:00}", TsOThours_Flexi.Hours + TsOThours_Flexi.Days * 24) + ":" + String.Format("{0:00}", TsOThours_Flexi.Minutes);
                            else
                            {
                                TimeSpan ts_DubOT = TimeSpan.Zero;
                                DateTime dtShiftMinutes = firstDay.dtmTimeIn.AddMinutes(firstDay.oShift.ShiftMinutes).AddMinutes(firstDay.oShift.Shift_OTMinuteMax);

                                if (clsConfig.bEnableDoubleOT && clsConfig.bEnableDoubleOT_InWorkingDays && firstDay.dtmShiftEnd_Actual == clsValidation.defaultDateTime && firstDay.dtmTimeOut > dtShiftMinutes)
                                {
                                    ts_DubOT = firstDay.dtmTimeOut - dtShiftMinutes;
                                    firstDay.sDoubleOTHours = (ts_DubOT.Hours < 0 || ts_DubOT.Minutes < 0 || ts_DubOT.Days > 50) ? "00:00" : String.Format("{0:00}", ts_DubOT.Hours + ts_DubOT.Days * 24) + ":" + String.Format("{0:00}", ts_DubOT.Minutes);
                                    TsOThours_Flexi -= ts_DubOT;
                                }

                                firstDay.sOTHours = (TsOThours_Flexi.Hours < 0 || TsOThours_Flexi.Minutes < 0 || TsOThours_Flexi.Days > 50) ? "00:00" : String.Format("{0:00}", TsOThours_Flexi.Hours + TsOThours_Flexi.Days * 24) + ":" + String.Format("{0:00}", TsOThours_Flexi.Minutes);
                            }
                            #endregion

                            #region No Pay
                            int iNoPay_Mins = firstDay.ishiftMinutes - clsValidation.GetMinutes(firstDay.sWorkedHours);
                            if (iNoPay_Mins > 0)
                            {
                                TimeSpan TsNotWorkingHours_Flexi = TimeSpan.FromMinutes(iNoPay_Mins);
                                firstDay.sNonWorkingMins = (TsNotWorkingHours_Flexi.Hours < 0 || TsNotWorkingHours_Flexi.Minutes < 0) ? "0:00" : String.Format("{0:00}", TsNotWorkingHours_Flexi.Hours + TsNotWorkingHours_Flexi.Days * 24) + ":" + String.Format("{0:00}", TsNotWorkingHours_Flexi.Minutes);
                            }
                            else
                                firstDay.sNonWorkingMins = "00:00";
                            #endregion

                            break;
                        }
                        #endregion
                }

                firstDay.UpdateRDataTable(isInitialization, dgr_Main.dt.Rows[irowID]);
            }

            //firstDay.NopaySettleWithLeaveGatePass(dgr_Main.dt.Rows[irowID]);
        }

        #region Fill Employee
        private void EmployeeSelecttion(string empID)
        {
            sp_genMasEmployee oEmployee = sp_genMasEmployee.Select(empID);
            if (oEmployee != null)
            {
                txtEmpNo.Tag = oEmployee.Employee_ID;
                txtEmpNo.Text = oEmployee.EpfNo + " - " + oEmployee.FullName;

                txtDivision.Tag = oEmployee.Division_ID;
                txtDivision.Text = oEmployee.DivisionName;
                txtDivision.IsEnabled = false;

                txtDepartment.Tag = oEmployee.Department_ID;
                txtDepartment.Text = oEmployee.DepartmentName;
                txtDepartment.IsEnabled = false;

                txtsection.Tag = oEmployee.SectionID;
                txtsection.Text = oEmployee.Section_Name;
                txtsection.IsEnabled = false;

                txtShift.Tag = oEmployee.Shift_ID;
                txtShift.Text = oEmployee.Shift_Name;
                txtShift.IsEnabled = false;

                tbl_genMasEmployee oEmp = tbl_genMasEmployee.Select(oEmployee.Employee_ID, clsSecurity.CompanyID, clsSecurity.BranchID);
                if (oEmp != null)
                {
                    txtAttendanceGroup1.Tag = oEmp.AttendanceGroup1_ID;
                    txtAttendanceGroup1.Text = clsRef_Name.get_Attendance_ProcessGroup1(oEmp.AttendanceGroup1_ID);
                    txtAttendanceGroup1.IsEnabled = false;
                }
            }
        }
        #endregion

        public void EmployeeWithDurationSelect(string empID, DateTime dtmTimeFrom, DateTime dtmTimeTo)
        {
            ClearFields();
            EmployeeSelecttion(empID);
            dtp_FromDate.SetTime(dtmTimeFrom);
            dtptoDate.SetTime(dtmTimeTo);
            btnLoad.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
        }

        #region Left Button Up Events
        private void LeaveViewer_GatePassGrid_MouseLeftButtonUp(object sender, EventArgs e)
        {
            UC_GatePass UC = new UC_GatePass();
            frm_SEACC_Window SW = new frm_SEACC_Window(UC, UC.SEACC_Form.FormName);
            UC.RefreshGrid(LeaveViewer.sEmpID);
            SW.ShowDialog();
        }

        private void LeaveViewer_LeaveGrid_MouseLeftButtonUp(object sender, EventArgs e)
        {
            UC_LeaveApplication UC = new UC_LeaveApplication();
            frm_SEACC_Window SW = new frm_SEACC_Window(UC, UC.SEACC_Form.FormName);
            UC.RefreshGrid(LeaveViewer.sEmpID);
            SW.ShowDialog();
        }
        #endregion

        private string GetDisplayValue_Hours(TimeSpan TsOThours)
        {
            return (TsOThours.Hours < 0 || TsOThours.Minutes < 0) ? "00:00" : String.Format("{0:00}", TsOThours.Hours + TsOThours.Days * 24) + ":" + String.Format("{0:00}", TsOThours.Minutes); ;
        }

    }

    public class AttendenceRecord
    {
        #region Variables
        public string empID = "default";

        public tbl_tasShiftMaster oShift;

        public DateTime dtDate = clsConfig.defaultDateTime;
        public string sShiftID = "default";
        public int iShiftDay = 0;
        public ShiftTypes ShiftType;
        public int ishiftMinutes = 0;

        public bool bShiftSpecialParameeter1 = false;
        public bool bShiftSpecialParameeter2 = false;
        public bool bOTApplicable = false;

        public DateTime dtmTimeIn = clsConfig.defaultDateTime;
        public DateTime dtmTimeOut = clsConfig.defaultDateTime;

        public DateTime dtmShiftStart = clsConfig.defaultDateTime;
        public DateTime dtmShiftEnd_minimum = clsConfig.defaultDateTime;
        public DateTime dtmShiftEnd_Actual = clsConfig.defaultDateTime;

        public string sTotalHours = "00:00", sWorkedHours = "00:00", sOTHours = "00:00", sOTApprovedHours = "-";
        public string sDoubleOTHours = "00:00", sDoubleOTApprovedHours = "-", sTripleOTHours = "00:00", sTripleOTApprovedHours = "-";

        public string sNonWorkingMins = "00:00", sNoPayHours = "00:00", sNoPayApprovedHours = "00:00";
        public string sLateHours = "00:00", sLateApprovedHours = "00:00";

        public string sLeaveHours = "00:00";

        public string sDayType = "Working Day";

        public int iShiftMiniths_Minimum = 0;

        #endregion

        public AttendenceRecord(DataRow datarow)
        {

            empID = datarow["employee_ID"].ToString();

            dtDate = clsValidation.Validate_DateTime(datarow["attendenceDate"].ToString());
            sShiftID = datarow["shift_ID"].ToString();
            iShiftDay = int.Parse(datarow["ShiftDay"].ToString());
            ishiftMinutes = int.Parse(datarow["shiftMinutes"].ToString());

            bShiftSpecialParameeter1 = datarow["ShiftSpecialParameeter1"].ToString() == "True" ? true : false;
            bShiftSpecialParameeter2 = datarow["ShiftSpecialParameeter2"].ToString() == "True" ? true : false;

            dtmTimeIn = clsValidation.Merge_DateAndTime(clsValidation.Validate_DateTime(datarow["InDate_E"].ToString()), clsValidation.Validate_DateTime(datarow["InTime_E"].ToString()));
            dtmTimeOut = clsValidation.Merge_DateAndTime(clsValidation.Validate_DateTime(datarow["OutDate_E"].ToString()), clsValidation.Validate_DateTime(datarow["OutTime_E"].ToString()));

            sDayType = datarow["Day"].ToString();

            oShift = tbl_tasShiftMaster.Select(sShiftID, clsSecurity.CompanyID, clsSecurity.BranchID);
            if (oShift != null)
            {
                iShiftMiniths_Minimum = int.Parse(datarow["shiftMinutesMin"].ToString());
                string sShiftStart = datarow["Shift_StartTime"].ToString();
                dtmShiftStart = clsValidation.Validate_DateTime(datarow["Shift_StartTime"].ToString());
                dtmShiftEnd_minimum = dtmShiftStart.AddMinutes(iShiftMiniths_Minimum);
                dtmShiftEnd_Actual = clsValidation.Validate_DateTime(datarow["Shift_EndTime"].ToString());
                ShiftType = (ShiftTypes)oShift.ShiftType;
            }
        }

        public void UpdateRDataTable(bool isInitialization, DataRow datarow)
        {
            tbl_tasTxDailyAttendance_revision oAttendanceRevision = (tbl_tasTxDailyAttendance_revision.SelectAll().Where(p => (p.AttendenceDate == dtDate && p.Employee_ID == empID && !p.IsCanceled && !p.IsOverride)).OrderByDescending(c => c.Date_Created)).FirstOrDefault();
            if (oAttendanceRevision != null && oAttendanceRevision.ApprovalStatus == (int)ApprovalStatus.Approved)
            {
                bOTApplicable = oAttendanceRevision.IsOT_Applicable;
                sOTApprovedHours = TimeSpan.FromMinutes(oAttendanceRevision.OTMinutesApproved).ToString(@"hh\:mm");
                sDoubleOTApprovedHours = TimeSpan.FromMinutes(oAttendanceRevision.DOTMinutesApproved).ToString(@"hh\:mm");
                sTripleOTApprovedHours = TimeSpan.FromMinutes(oAttendanceRevision.TOTMinutesApproved).ToString(@"hh\:mm");
                sLateHours = TimeSpan.FromMinutes(oAttendanceRevision.LateMinutes).ToString(@"hh\:mm");
                sLateApprovedHours = TimeSpan.FromMinutes(oAttendanceRevision.LateMinutesApproved).ToString(@"hh\:mm");
                sNoPayHours = TimeSpan.FromMinutes(oAttendanceRevision.NoPayMinutes).ToString(@"hh\:mm");
                sNoPayApprovedHours = TimeSpan.FromMinutes(oAttendanceRevision.NoPayMinutesApproved).ToString(@"hh\:mm");
            }
            else
            {
                sOTApprovedHours = oShift.IsOT_Applicable ? sOTHours : "-";
                sDoubleOTApprovedHours = oShift.IsOT_Applicable ? sDoubleOTHours : "-";
                sTripleOTApprovedHours = oShift.IsOT_Applicable ? sTripleOTHours : "-";
                bOTApplicable = oShift.IsOT_Applicable;

                //nopay breakdown
                if (clsConfig.bEnableLateNopayBreakDown)
                {
                    decimal dMaxLateMins = clsConfig.dMaximumLateMins_Office_PerDay;
                    decimal dMaxLateGracePeriodMins = decimal.Parse(clsConfig.sLateGracePeriodPerDay_Office);

                    tbl_genMasEmployee oEmp = tbl_genMasEmployee.Select(empID, clsSecurity.CompanyID, clsSecurity.BranchID);
                    tbl_payMas_ProcessGroup oEmpSalProcessGroup = tbl_payMas_ProcessGroup.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oEmp.Payroll_ProcessGroupID);
                    if (oEmpSalProcessGroup != null)
                    {
                        dMaxLateMins = oEmpSalProcessGroup.MaxMins_Late > 0 ? oEmpSalProcessGroup.MaxMins_Late : dMaxLateMins;
                        dMaxLateGracePeriodMins = oEmpSalProcessGroup.GraceMins_Late > 0 ? oEmpSalProcessGroup.GraceMins_Late : dMaxLateGracePeriodMins;
                    }

                    //Early Exit
                    int iNonWorkingMins = clsValidation.GetMinutes(sNonWorkingMins);
                    int iEarlyExitMins = 0;
                    if (dtmTimeOut < dtmShiftEnd_minimum && dtmTimeOut != clsValidation.defaultDateTime)//&& clsConfig.bLateCalculate_EndOfPayrollPeriod
                    {
                        TimeSpan TsEarlyExit = dtmShiftEnd_minimum - dtmTimeOut;
                        iEarlyExitMins = TsEarlyExit.Minutes + TsEarlyExit.Hours * 60 + TsEarlyExit.Days * 24 * 60;
                        iNonWorkingMins -= iEarlyExitMins;
                    }

                    //Leave & Gate pass
                    int iLeaveMiniths = clsValidation.GetMinutes(datarow["LeaveHours"].ToString());
                    int iGPMiniths = clsValidation.GetMinutes(datarow["GPHours"].ToString());
                    iNonWorkingMins -= (iGPMiniths + iLeaveMiniths);
                    if (iNonWorkingMins < 0)
                        iNonWorkingMins = 0;

                    if (iNonWorkingMins == 0 && (iGPMiniths + iLeaveMiniths) > 0 && iEarlyExitMins > 0)
                        iEarlyExitMins -= (iGPMiniths + iLeaveMiniths);

                    if (iEarlyExitMins < 0)
                        iEarlyExitMins = 0;

                    if (iNonWorkingMins <= (dMaxLateMins + dMaxLateGracePeriodMins) && ShiftType != ShiftTypes.FlexibalShift)
                    {
                        sLateHours = TimeSpan.FromMinutes(iNonWorkingMins).ToString(@"hh\:mm");
                        sLateApprovedHours = sLateHours;
                    }
                    else
                    {
                        sNoPayHours = TimeSpan.FromMinutes(iNonWorkingMins).ToString(@"hh\:mm");
                        if (!clsConfig.bLateCalculate_EndOfPayrollPeriod)
                        {
                            if ((iNonWorkingMins >= iShiftMiniths_Minimum))
                            {
                                sNoPayHours = TimeSpan.FromMinutes(iShiftMiniths_Minimum).ToString(@"hh\:mm");
                            }
                            else if ((iNonWorkingMins >= (iShiftMiniths_Minimum / 2)) && ShiftType != ShiftTypes.FlexibalShift)
                            {
                                if (clsConfig.bEnable_DivideLateNopay)
                                {
                                    sNoPayHours = TimeSpan.FromMinutes((iShiftMiniths_Minimum / 2)).ToString(@"hh\:mm");

                                    sLateHours = TimeSpan.FromMinutes(iNonWorkingMins - (iShiftMiniths_Minimum / 2)).ToString(@"hh\:mm");
                                    sLateApprovedHours = sLateHours;
                                }
                                else
                                {
                                    sNoPayHours = TimeSpan.FromMinutes(iNonWorkingMins).ToString(@"hh\:mm");
                                }
                            }
                            else if (ShiftType != ShiftTypes.FlexibalShift)
                            {
                                if (clsConfig.bEnable_DivideLateNopay)
                                {
                                    sNoPayHours = TimeSpan.FromMinutes(0).ToString(@"hh\:mm");

                                    sLateHours = TimeSpan.FromMinutes(iNonWorkingMins).ToString(@"hh\:mm");
                                    sLateApprovedHours = sLateHours;
                                }
                                else
                                {
                                    sNoPayHours = TimeSpan.FromMinutes(iNonWorkingMins).ToString(@"hh\:mm");

                                    sLateHours = TimeSpan.FromMinutes(0).ToString(@"hh\:mm");
                                    sLateApprovedHours = sLateHours;
                                }
                            }

                            sNoPayApprovedHours = sNoPayHours;
                        }

                        #region AKT
                        else // This is for AKT Only 2017-02-17
                        {
                            int iNpayMins = iNonWorkingMins;
                            if (iNpayMins == 0)
                                sNoPayApprovedHours = "00:00";
                            else if (iNpayMins > (dMaxLateMins + dMaxLateGracePeriodMins) && iNpayMins <= 120)
                                sNoPayApprovedHours = "02:00";
                            else if (iNpayMins > 120 && iNpayMins <= (iShiftMiniths_Minimum / 2))
                                sNoPayApprovedHours = TimeSpan.FromMinutes(iShiftMiniths_Minimum / 2).ToString(@"hh\:mm");
                            else
                                sNoPayApprovedHours = TimeSpan.FromMinutes(clsValidation.GetMinutes(sNoPayHours) - 60).ToString(@"hh\:mm");
                        }
                        #endregion
                    }
                    if (iEarlyExitMins > 0)
                    {
                        sNoPayHours = TimeSpan.FromMinutes(clsValidation.GetMinutes(sNoPayHours) + iEarlyExitMins).ToString(@"hh\:mm");
                        sNoPayApprovedHours = TimeSpan.FromMinutes(clsValidation.GetMinutes(sNoPayApprovedHours) + iEarlyExitMins).ToString(@"hh\:mm");
                    }
                }
                else
                {
                    sNoPayHours = sNonWorkingMins;
                    sNoPayApprovedHours = sNonWorkingMins;
                }
            }

            if (isInitialization)
            {
                datarow["TotalHours_Display_O"] = sTotalHours;
                datarow["WorkedHours_Display_O"] = sWorkedHours;
                datarow["OTHours_Display_O"] = sOTHours;
                datarow["DoubleOTHours_Display_O"] = sDoubleOTHours; //Double OT
                datarow["TripleOTHours_Display_O"] = sTripleOTHours; //Triple OT
                datarow["OT_O"] = bOTApplicable;
                datarow["OTApproved_Display_O"] = sOTApprovedHours;
                datarow["DoubleOTApproved_Display_O"] = sDoubleOTApprovedHours;//Double OT
                datarow["TripleOTApproved_Display_O"] = sTripleOTApprovedHours;//Triple OT

                datarow["LateHours_Display_O"] = sLateHours;
                datarow["LateApproved_Display_O"] = sLateApprovedHours;
                datarow["NoPayHours_Display_O"] = sNoPayHours;
                datarow["NoPayApproved_Display_O"] = sNoPayApprovedHours;
            }

            datarow["TotalHours_Display_E"] = sTotalHours;
            datarow["WorkedHours_Display_E"] = sWorkedHours;
            datarow["OTHours_Display_E"] = sOTHours;
            datarow["DoubleOTHours_Display_E"] = sDoubleOTHours; //Double OT
            datarow["TripleOTHours_Display_E"] = sTripleOTHours; //Triple OT
            datarow["OT_E"] = bOTApplicable;
            datarow["OTApproved_Display_E"] = sOTApprovedHours;
            datarow["DoubleOTApproved_Display_E"] = sDoubleOTApprovedHours; //Double OT
            datarow["TripleOTApproved_Display_E"] = sTripleOTApprovedHours; //Triple OT

            datarow["LateHours_Display_E"] = sLateHours;
            datarow["LateApproved_Display_E"] = sLateApprovedHours;

            datarow["NoPayHours_Display_E"] = sNoPayHours;
            datarow["NoPayApproved_Display_E"] = sNoPayApprovedHours;
        }
    }
}


#region 24 Hours Shift OT Calculations
//TimeSpan tstotalShiftMins = (firstDay.dtmShiftEnd_Actual - PreviusDay.dtmShiftStart);
//TimeSpan tsOTHours = (dtmTimeOUT - dtmTimeIN).Add(-(tstotalShiftMins));
//iOTHours_Later = (tsOTHours.Hours < 0 || tsOTHours.Minutes < 0) ? 0 : clsValidation.GetMinutes(tsOTHours);

//int itotalShiftMins = (PreviusDay.ishiftMinutes + firstDay.ishiftMinutes);
//TimeSpan tsOTHours = (dtmTimeOUT - dtmTimeIN).Add(-(TimeSpan.FromMinutes(PreviusDay.ishiftMinutes)));
//iOTHours_Later = (tsOTHours.Hours < 0 || tsOTHours.Minutes < 0) ? 0 : clsValidation.GetMinutes(tsOTHours);

//int itotalShiftMins = PreviusDay.ishiftMinutes + (PreviusDay.bShiftSpecialParameeter1 ? PreviusDay.ishiftMinutes : firstDay.ishiftMinutes);
//TimeSpan tsOTHours = (dtmTimeOUT - PreviusDay.dtmShiftStart.AddMinutes(itotalShiftMins));
//iOTHours_Later = (tsOTHours.Hours < 0 || tsOTHours.Minutes < 0) ? 0 : clsValidation.GetMinutes(tsOTHours);
//iOTHours_Later = clsValidation.GetMinutes(tsOTHours); 
#endregion