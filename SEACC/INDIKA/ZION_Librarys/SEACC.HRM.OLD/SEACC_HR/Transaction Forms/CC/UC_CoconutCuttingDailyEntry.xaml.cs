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

namespace Digiteq.Transaction_Forms.CoconutCuting
{
    public partial class UC_CoconutCuttingDailyEntry : UserControl
    {
        #region Intialize Form
        public UC_CoconutCuttingDailyEntry()
        {
            #region Initialize User control
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.CoconutCuttingDailyEntry;
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

            dgr_Main.dt.Columns.Add("Qty_Grade1");
            dgr_Main.dt.Columns.Add("Qty_Grade2");
            dgr_Main.dt.Columns.Add("Qty_Grade1_nyt");
            dgr_Main.dt.Columns.Add("Qty_Grade2_nyt");

            dgr_Main.dt.Columns.Add("travel_Allowance");
            dgr_Main.dt.Columns.Add("attandance_Allowance");

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
            dgr_Main.Add_DatagridColoumn("Day", "day", 80, false);
            dgr_Main.Add_DatagridColoumn("Emp No.", "employee_ID", 60);
            dgr_Main.Add_DatagridColoumn("Name", "employee_Name", 140);

            dgr_Main.Add_DatagridColoumn("department_ID", "department_ID", 110, false);
            dgr_Main.Add_DatagridColoumn("shift_ID", "shift_ID", 100, false);
            dgr_Main.Add_DatagridColoumn("Shift", "ShiftName", 120, false);
            dgr_Main.Add_DatagridColoumn("Shift Days", "ShiftDay", 20, false);
            dgr_Main.Add_DatagridColoumn("Shift Start", "Shift_StartTime", 50, false);
            dgr_Main.Add_DatagridColoumn("Shift End", "Shift_EndTime", 50, false);

            dgr_Main.Add_DatagridColoumn("InDateTime_ID", "inDateTime_ID_E", 80, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "In Time", "inTime_E", 50, true, true);
            dgr_Main.Add_DatagridColoumn("OutDateTime_ID", "outDateTime_ID_E", 80, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Out Time", "outTime_E", 50, true, true);
            dgr_Main.Add_DatagridColoumn("Attendence", "attendence", 70, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Good N.", "Qty_Grade1", 55, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Bad N.", "Qty_Grade2", 55, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Nyt GN.", "Qty_Grade1_nyt", 55, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Nyt BN.", "Qty_Grade2_nyt", 55, false, false);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Travel All.", "travel_Allowance", 75, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Attend. All.", "attandance_Allowance", 75, true, false);
            #endregion

            dgr_Main.RefreshGrid();
            ClearFields();
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //SEACC_Form.IsUpdateMode = false;
            dgr_Main.dt.Clear();

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmpNo, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDesignation, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDivision, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDepartment, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSubSection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmpCategory1, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmpCategory2, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmpCategory3, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtWeek, true, false, false);

            //Configuration Details
            cls_Formater.SetEnableDisable_LableTextbox(txtCutoffNutsWeekday, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCutoffNutsSatureday, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCutoffNutsHoliday, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRateWeekDay, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRateSatureday, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRateHoliday, true, true, false);

            txtEmpNo.Tag = null;
            txtDesignation.Tag = null;
            txtDivision.Tag = null;
            txtDepartment.Tag = null;
            txtSection.Tag = null;
            txtSubSection.Tag = null;
            txtEmpCategory1.Tag = null;
            txtEmpCategory2.Tag = null;
            txtEmpCategory3.Tag = null;
            txtWeek.Tag = null;

            txtEmpNo.Text = "<All Employees>";
            txtDesignation.Text = "<All Designations>";
            txtDivision.Text = "<All Divisions>";
            txtDepartment.Text = "<All Departments>";
            txtSection.Text = "<All Sections>";
            txtSubSection.Text = "<All Sub Sections>";
            txtEmpCategory1.Text = "<All Categories [1])>";
            txtEmpCategory2.Text = "<All Categories [2])>";
            txtEmpCategory3.Text = "<All Categories [3])>";
            txtWeek.Text = "-";

            //Configuration Details
            txtCutoffNutsWeekday.Text = cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(clsConfig.sCC_CutoffNutsWeekDay), 0);
            txtCutoffNutsSatureday.Text = cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(clsConfig.sCC_CutoffNutsSatureday), 0);
            txtCutoffNutsHoliday.Text = cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(clsConfig.sCC_CutoffNutsHoliday), 0);
            txtRateWeekDay.Text = cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(clsConfig.sCC_RateWeekDay), 2);
            txtRateSatureday.Text = cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(clsConfig.sCC_RateSatureday), 2);
            txtRateHoliday.Text = cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(clsConfig.sCC_RateHoliday), 2);

            dtp_FromDate.IsEnabled = true;
            dtp_toDate.IsEnabled = true;
            dtp_FromDate.SetTime(DateTime.Now);
            dtp_toDate.SetTime(DateTime.Now);

            cmbPayPeriod.comboBox.ItemsSource = clsCommon.GetEnumDescription(typeof(Digiteq_Logic.CC_PaymentPeriod));
            cmbPayPeriod.SetSelectedIndex((int)CC_PaymentPeriod.Weekly);
            //Style style = new Style(typeof(TextBlock));
            //style.Setters.Add(new Setter(TextBlock.ForegroundProperty, Brushes.Green));
            //style.Setters.Add(new Setter(TextBlock.TextProperty, "Green"));
            //dgr_Main.grdMain.Columns[8].HeaderStyle = style;
            //dgr_Main.grdMain.Columns[1].Header = "Last Name";
        }
        #endregion

        #region Action Buttons
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
            if (txtWeek.ToolTip != null && txtWeek.Tag != null)
            {
                if (dgr_Main.dt.Select("attendence = 'Not Saved'").Count() == 0)
                {

                    frm_WaitingMessege FrmWaiting = new frm_WaitingMessege();
                    try
                    {
                        this.Cursor = Cursors.Wait;
                        bool bInsert = false;
                        bool bDelete = true;//207-03-16 Gayan

                        string sMessage_Subject = "", sMessage_Body = "", sMessage_Foter = "";

                        List<ProcessRecord_DailyRates> oRateDailyRecords = new List<ProcessRecord_DailyRates>();
                        List<ProcessRecord_Week> oWeeklyRecords = new List<ProcessRecord_Week>();

                        #region Check and Get the Data of EOW Process 
                        foreach (DataRow row in dgr_Main.dt.Rows)
                        {
                            DateTime dtmAttendanceDate = clsValidation.Validate_DateTime(row["attendenceDate"].ToString());
                            string sEmployee_ID = row["employee_ID"].ToString();
                            string sEmployee_Name = row["employee_Name"].ToString();

                            //Main Payroll Employees
                            DataTable dtPayrollRawData = DBHandling.ExecQuery("sp_getPayrollRawData_fromEmployeeWise_GivenDate '" + sEmployee_ID + "' , '" + dtmAttendanceDate.Date + "'").Tables[0];
                            if (dtPayrollRawData.Rows.Count > 0)
                            {
                                bInsert = false;
                                bDelete = false;
                                SEACCMessageBox.Show("Payroll Processed...", sEmployee_ID + " - " + sEmployee_Name + " 's Salary has been already processed. You can not change the entered data", MessageBoxButton.OK, "Red");
                                break;
                            }

                            foreach (tbl_ccTxDailyWorkingProgress_Rate oRate_row in tbl_ccTxDailyWorkingProgress_Rate.SelectAll_DateRange(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployee_ID, dtmAttendanceDate.Date, dtmAttendanceDate.Date))
                            {
                                ProcessRecord_DailyRates r = new ProcessRecord_DailyRates();
                                r.iAttendanceIndex = oRate_row.Attendance_index;
                                r.sActivityId = oRate_row.Activity_ID;
                                r.iGradeId = oRate_row.Grade_ID;
                                r.iDay_DayType = oRate_row.DayType;
                                r.iWeektargetStatus = oRate_row.WeekTargertStatus;
                                r.iRateSlab = oRate_row.RateSlab;
                                oRateDailyRecords.Add(r);
                                sMessage_Body = sMessage_Body + "\nFound salary records for Enp - " + sEmployee_ID + ", " + sEmployee_Name + " on - " + dtmAttendanceDate.ToString(clsConfig.Format_Date);
                            }

                            //tbl_hrPeriod_Week oProcessPerid = tbl_hrPeriod_Week.SelectAll().Where(d => d.StartDate.Date <= dtmAttendanceDate.Date && d.EndDate.Date >= dtmAttendanceDate.Date).OrderBy(d => d.StartDate).FirstOrDefault();
                            tbl_hrPeriod_Week oProcessPerid = tbl_hrPeriod_Week.Select(clsSecurity.CompanyID, clsSecurity.BranchID, int.Parse(txtWeek.ToolTip.ToString()), int.Parse(txtWeek.Tag.ToString()));

                            ProcessRecord_Week w = new ProcessRecord_Week();
                            w.iYearId = oProcessPerid.Year_ID;
                            w.iWeekId = oProcessPerid.Week_ID;
                            w.sEmployeeId = sEmployee_ID;
                            oWeeklyRecords.Add(w);
                        }
                        #endregion

                        #region Delete Confirmation and Delete Process (EOW)
                        if (bDelete)
                        {
                            if (oRateDailyRecords != null && (oRateDailyRecords.Count > 0 || oWeeklyRecords.Count > 0))
                            {
                                sMessage_Subject = "Already Processed Data Available";
                                sMessage_Foter = "\nCoconut Cutting and Cocount Washing Data Will be deleted for the week\nDelete and Continue Existing Data ?";
                                bool bMessegeBoxResult = SEACCMessageBox.Show(sMessage_Subject, sMessage_Body + sMessage_Foter, MessageBoxButton.YesNo);
                                if (bMessegeBoxResult)
                                {
                                    bInsert = true;
                                    foreach (ProcessRecord_DailyRates oRateRecord in oRateDailyRecords)
                                    {
                                        tbl_ccTxDailyWorkingProgress_Rate oDailyRecord = tbl_ccTxDailyWorkingProgress_Rate.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oRateRecord.iAttendanceIndex, oRateRecord.sActivityId, oRateRecord.iGradeId, oRateRecord.iDay_DayType, oRateRecord.iWeektargetStatus, oRateRecord.iRateSlab);
                                        if (oDailyRecord != null)
                                            oDailyRecord.Delete();
                                    }
                                    foreach (ProcessRecord_Week oRateWeekRecord in oWeeklyRecords)
                                    {
                                        tbl_ccTxEndOfWeekProgress oEoDRecord = tbl_ccTxEndOfWeekProgress.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oRateWeekRecord.sEmployeeId, oRateWeekRecord.iYearId, oRateWeekRecord.iWeekId);
                                        if (oEoDRecord != null)
                                            oEoDRecord.Delete();

                                        foreach (tbl_ccTxEndOfWeekProgress_rate oWeekRecord in tbl_ccTxEndOfWeekProgress_rate.SelectAll().Where(p => p.Company_ID == clsSecurity.CompanyID && p.CompanyBranch_ID == clsSecurity.BranchID && p.Year_ID == oRateWeekRecord.iYearId && p.Week_ID == oRateWeekRecord.iWeekId && p.Employee_ID == oRateWeekRecord.sEmployeeId))
                                            oWeekRecord.Delete();

                                        #region Coconut Washing Reset
                                        foreach (tbl_ccTxEndOfWeekWashingProgress rec in tbl_ccTxEndOfWeekWashingProgress.SelectAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID(clsSecurity.CompanyID, clsSecurity.BranchID, oRateWeekRecord.iYearId, oRateWeekRecord.iWeekId))
                                            rec.Delete();
                                        foreach (tbl_ccTxDailyWashingProgress oDrec in tbl_ccTxDailyWashingProgress.SelectAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID(clsSecurity.CompanyID, clsSecurity.BranchID, oRateWeekRecord.iYearId, oRateWeekRecord.iWeekId))
                                        {
                                            oDrec.Qty_Total = 0;
                                            oDrec.Employee_Count_Total = 0;
                                            oDrec.Rate = 0;
                                            oDrec.Earn_Total = 0;
                                            oDrec.Update();
                                        }
                                        #endregion
                                    }
                                }
                                else
                                    bInsert = false;
                            }
                            else
                                bInsert = true;
                        }
                        #endregion

                        #region Add Data
                        if (bInsert)
                        {
                            foreach (DataRow row in dgr_Main.dt.Rows)
                            {
                                #region get values from table
                                DateTime dtmAttendanceDate = clsValidation.Validate_DateTime(row["attendenceDate"].ToString());
                                string sEmployee_ID = row["employee_ID"].ToString();
                                string sDepartment_ID = row["department_ID"].ToString();

                                string sDayType = row["Day"].ToString();
                                int iDayType = 0;
                                switch (sDayType)
                                {
                                    case "Working Day":
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

                                decimal dQty_Grade1 = clsValidation.Validate_DecimalNumber(row["Qty_Grade1"].ToString());
                                decimal dQty_Grade2 = clsValidation.Validate_DecimalNumber(row["Qty_Grade2"].ToString());
                                decimal dQty_Grade1_nyt = clsValidation.Validate_DecimalNumber(row["Qty_Grade1_nyt"].ToString());
                                decimal dQty_Grade2_nyt = clsValidation.Validate_DecimalNumber(row["Qty_Grade2_nyt"].ToString());

                                decimal dTravel_Allow = clsValidation.Validate_DecimalNumber(row["travel_Allowance"].ToString());
                                decimal dAttendance_Allow = clsValidation.Validate_DecimalNumber(row["attandance_Allowance"].ToString());

                                #region Daily Payment Claculations (Daily Payment and Monthly Payment Workers Only)
                                decimal dAmountDaily = 0;
                                if (cmbPayPeriod.GetSelectedIndex() == (int)CC_PaymentPeriod.Daily)
                                {
                                    dAmountDaily = (dQty_Grade1 + 2 * dQty_Grade2);
                                }
                                else if (cmbPayPeriod.GetSelectedIndex() == (int)CC_PaymentPeriod.Monthly)
                                {
                                    decimal dCutoffNuts_WeekDay = clsValidation.Validate_DecimalNumber(txtCutoffNutsWeekday.Text);  //1000;
                                    decimal dCutoffNuts_Satureday = clsValidation.Validate_DecimalNumber(txtCutoffNutsSatureday.Text); //500;
                                    decimal dCutoffNuts_Other = clsValidation.Validate_DecimalNumber(txtCutoffNutsHoliday.Text); //500;

                                    decimal dCutoffNuts_WeekDay_Rate = clsValidation.Validate_DecimalNumber(txtRateWeekDay.Text); // 0.8m;
                                    decimal dCutoffNuts_Satureday_Rate = clsValidation.Validate_DecimalNumber(txtRateSatureday.Text); // 1.2m;
                                    decimal dCutoffNuts_Other_Rate = clsValidation.Validate_DecimalNumber(txtRateHoliday.Text); // 1.6m;

                                    switch (sDayType)
                                    {
                                        case "Working Day":
                                            dAmountDaily = ((dQty_Grade1 + 2 * dQty_Grade2) - dCutoffNuts_WeekDay) * dCutoffNuts_WeekDay_Rate;
                                            break;
                                        case "Saturday":
                                            dAmountDaily = ((dQty_Grade1 + 2 * dQty_Grade2) - dCutoffNuts_Satureday) * dCutoffNuts_Satureday_Rate;
                                            break;
                                        case "Sunday":
                                            dAmountDaily = ((dQty_Grade1 + 2 * dQty_Grade2) - dCutoffNuts_Other) * dCutoffNuts_Other_Rate;
                                            break;
                                        case "Poyaday":
                                            dAmountDaily = ((dQty_Grade1 + 2 * dQty_Grade2) - dCutoffNuts_Other) * dCutoffNuts_Other_Rate;
                                            break;
                                    }
                                }
                                else
                                {
                                    dAmountDaily = 0;
                                }
                                #endregion

                                #endregion

                                #region Update/Insert record
                                tbl_ccTxDailyWorkingProgress oOldRecord = tbl_ccTxDailyWorkingProgress.SelectAllBy_DateRange(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployee_ID, dtmAttendanceDate.Date, dtmAttendanceDate.Date).FirstOrDefault();
                                if (oOldRecord != null)
                                {
                                    tbl_ccTxDailyWorkingProgress detail = new tbl_ccTxDailyWorkingProgress(oOldRecord.Company_ID, oOldRecord.CompanyBranch_ID, oOldRecord.Attendance_index, dtmAttendanceDate.Date, int.Parse(txtWeek.ToolTip.ToString()), int.Parse(txtWeek.Tag.ToString()), sEmployee_ID, sDepartment_ID, iDayType, sShift_ID, iShiftDay, dtmShiftStartTime, dtmShiftEndTime, iInDateTime_ID_E, dtmInTime_E, iOutDateTime_ID_E, dtmOutTime_E, iAttendanceStatus, dQty_Grade1, dQty_Grade2, dQty_Grade1_nyt, dQty_Grade2_nyt, 0, oOldRecord.IsCanceled, oOldRecord.UserID_Created, clsSecurity.UserIDLoged, oOldRecord.UserID_Canceled, oOldRecord.TerminalID_Created, clsSecurity.TerminalID, oOldRecord.TerminalID_Canceled, oOldRecord.Date_Created, clsSecurity.getServerDateTime(), oOldRecord.Date_Canceled, cmbPayPeriod.GetSelectedIndex(), dAmountDaily > 0 ? dAmountDaily : 0, 0, 0, 0, 0, 0, dTravel_Allow, dAttendance_Allow, 0, 0, 0, 0, 0, 0);
                                    detail.Update();
                                }
                                else
                                {
                                    tbl_ccTxDailyWorkingProgress detail = new tbl_ccTxDailyWorkingProgress(clsSecurity.CompanyID, clsSecurity.BranchID, 0, dtmAttendanceDate.Date, int.Parse(txtWeek.ToolTip.ToString()), int.Parse(txtWeek.Tag.ToString()), sEmployee_ID, sDepartment_ID, iDayType, sShift_ID, iShiftDay, dtmShiftStartTime, dtmShiftEndTime, iInDateTime_ID_E, dtmInTime_E, iOutDateTime_ID_E, dtmOutTime_E, iAttendanceStatus, dQty_Grade1, dQty_Grade2, dQty_Grade1_nyt, dQty_Grade2_nyt, 0, false, clsSecurity.UserIDLoged, "default", "default", clsSecurity.TerminalID, "default", "default", clsSecurity.getServerDateTime(), clsConfig.defaultDateTime, clsConfig.defaultDateTime, cmbPayPeriod.GetSelectedIndex(), dAmountDaily > 0 ? dAmountDaily : 0, 0, 0, 0, 0, 0, dTravel_Allow, dAttendance_Allow, 0, 0, 0, 0, 0, 0);
                                    detail.Insert();
                                }
                                #endregion
                            }
                            SEACCMessageBox.Show("Saved succesfully...!", "", MessageBoxButton.OK);
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        SEACCExeption.Show(ex);
                    }
                    finally
                    {
                        dgr_Main.dt.Clear();
                        dgr_Main.RefreshGrid();
                        btnLoad.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                        FrmWaiting.Close();
                        this.Cursor = Cursors.Arrow;
                    }
                }
                else
                {
                    SEACCMessageBox.Show("Time Attendance Not Saved!!!", "Please save the time attendance in Attendance Control Pannel", MessageBoxButton.OK, "Red");
                }
            }
            else
            {
                SEACCMessageBox.Show("Please Select a Week", "", MessageBoxButton.OK, "Red");
            }

        }
        void SEACC_Load_Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtWeek.ToolTip != null && txtWeek.Tag != null)
            {

                frm_WaitingMessege FrmWaiting = new frm_WaitingMessege();
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

                    if (txtDesignation.Tag != null)
                        oEmployees = oEmployees.Where(p => p.Designation_ID == txtDesignation.Tag.ToString()).ToList();

                    if (txtDivision.Tag != null)
                        oEmployees = oEmployees.Where(p => p.Division_ID == txtDivision.Tag.ToString()).ToList();

                    if (txtDepartment.Tag != null)
                        oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();

                    if (txtSection.Tag != null)
                        oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();

                    if (txtSubSection.Tag != null)
                        oEmployees = oEmployees.Where(p => p.SubSectionID == txtSubSection.Tag.ToString()).ToList();

                    if (txtEmpCategory1.Tag != null)
                        oEmployees = oEmployees.Where(p => p.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();

                    if (txtEmpCategory2.Tag != null)
                        oEmployees = oEmployees.Where(p => p.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();

                    if (txtEmpCategory3.Tag != null)
                        oEmployees = oEmployees.Where(p => p.EmpCatagory2_ID == txtEmpCategory3.Tag.ToString()).ToList();
                    #endregion

                    #region Create datasets - DeviceRawData & Holidays
                    List<sp_tasDevice_RawData> oDeviceRawData = sp_tasDevice_RawData.SelectAll("%", "%", dtmFromDate.Date, dtmToDate.Date).ToList();
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

                            bool bShiftSpecialParameeter1 = false, bShiftSpecialParameeter2 = false;

                            TimeSpan tsLeaveHours = TimeSpan.FromMinutes(0);
                            TimeSpan tsGPHours = TimeSpan.FromMinutes(0);

                            String sRowBackColor = "#FF34495E";
                            String sDayType = "Working Day";

                            string sShiftStart = "-", sShiftEnd = "-";
                            string sShiftId = "", sShiftName = "";
                            string sAttendanceStatus = "Not Saved";
                            ShiftTypes enmShiftType = ShiftTypes.OneDayShift;

                            holidayDurationType hdt = holidayDurationType.N_A;

                            //string attendenceStatus = "0";
                            string foreground = "white";
                            bool bIsAttendancerecord = false;

                            decimal dQty_Grade1 = 0, dQty_Grade2 = 0, dQty_Grade1_nyt = 0, dQty_Grade2_nyt = 0;

                            string sTravel_Allowance = "0.00";
                            string sAttendance_Allowance = "0.00";

                            #endregion

                            #region get Holydays And format rows
                            foreach (tbl_tasHolidayCalander oCal in oHolidays.Where(p => p.Holiday_Date.Date == dDate.Date && !p.IsCanceled))
                            {
                                sRowBackColor = "#FF345A5E";
                                sDayType = "Holiday";
                                hdt = (holidayDurationType)oCal.HolidayDurationType;
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

                            //clsHelpMethods.GetShift(dDate, oEmployee.Employee_ID, hdt, ref sShiftId, ref sShiftName, ref enmShiftType, ref iShiftDay, ref sPriviusShift, ref bShiftSpecialParameeter1, ref bShiftSpecialParameeter2, ref iShiftMinutes, ref iShiftMinutes_Min, ref iNextShift_Minutes, ref iShiftGracePeriod, ref dtmShiftStart, ref dtmShiftEnd, ref sShiftStart, ref sShiftEnd);

                            #region Add Exixting data
                            List<tbl_ccTxDailyWorkingProgress> oOldRecords = tbl_ccTxDailyWorkingProgress.SelectAllBy_DateRange(clsSecurity.CompanyID, clsSecurity.BranchID, oEmployee.Employee_ID, dDate.Date, dDate.Date);
                            if (oOldRecords != null && oOldRecords.Count > 0)
                            {
                                bIsAttendancerecord = true;
                                iAttendanceIndex = oOldRecords.First().Attendance_index;
                                sShiftId = oOldRecords.First().Shift_ID;
                                sShiftName = clsRef_Name.get_Shift_Name(sShiftId);
                                dtmShiftStart = oOldRecords.First().ShiftStartTime;
                                sShiftStart = oOldRecords.First().ShiftStartTime.ToString();
                                dtmShiftEnd = oOldRecords.First().ShiftEndTime;
                                sShiftEnd = oOldRecords.First().ShiftEndTime.ToString();
                                iInDateTime_ID = oOldRecords.First().TimeIn_ID;
                                dtmTimeIn = oOldRecords.First().TimeIn_DateTime;
                                iOutDateTime_ID = oOldRecords.First().TimeOut_ID;
                                dtmTimeOut = oOldRecords.First().TimeOut_DateTime;
                                sAttendanceStatus = "Saved";

                                //iInDateTime_ID = oOldRecords.First().TimeIn_ID;
                                //dtmTimeIn = oOldRecords.First().TimeIn_DateTime;
                                //iOutDateTime_ID = oOldRecords.First().TimeOut_ID;
                                //dtmTimeOut = oOldRecords.First().TimeOut_DateTime;

                                dQty_Grade1 = oOldRecords.First().Qty_Grade1;
                                dQty_Grade2 = oOldRecords.First().Qty_Grade2;
                                dQty_Grade1_nyt = oOldRecords.First().Qty_Grade1_Night;
                                dQty_Grade2_nyt = oOldRecords.First().Qty_Grade2_Night;

                                sTravel_Allowance = cls_Formater.FormatDecimal(oOldRecords.First().Travel_Allowance, 2);
                                sAttendance_Allowance = cls_Formater.FormatDecimal(oOldRecords.First().Attendace_Allowance, 2);
                            }
                            #endregion

                            #region Add new data
                            else
                            {
                                /*
                                foreach (sp_tasDevice_RawData odetails in oDeviceRawData.Where(p => p.Device_empID == oEmployee.Employee_ID2 && p.Device_DateTime.Date == dDate.Date))
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
                                        string[] shiftDetails = clsCommon.getEmpShiftDetails(oEmployee.Employee_ID, dtmTimeOut);
                                        if (shiftDetails[(int)ShiftDetails.shiftStartTime] != "")
                                        {
                                            TimeSpan ts1 = (clsValidation.CombineDateAndTime(dDate, DateTime.Parse(shiftDetails[(int)ShiftDetails.shiftStartTime])) - dtmTimeIn).Duration();
                                            TimeSpan ts2 = (clsValidation.CombineDateAndTime(dDate, DateTime.Parse(shiftDetails[(int)ShiftDetails.shiftStartTime]).AddMinutes(int.Parse(shiftDetails[(int)ShiftDetails.ShiftMins]))) - dtmTimeOut).Duration();

                                            if (ts1 < ts2)
                                                dtmTimeOut = clsConfig.defaultDateTime;
                                            else
                                                dtmTimeIn = clsConfig.defaultDateTime;
                                        }

                                    }
                                }
                                */
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
                            dr["ShiftDay"] = 0;

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
                            dr["Qty_Grade1"] = cls_Formater.FormatDecimal(dQty_Grade1, 0);
                            dr["Qty_Grade2"] = cls_Formater.FormatDecimal(dQty_Grade2, 0);
                            dr["Qty_Grade1_nyt"] = cls_Formater.FormatDecimal(dQty_Grade1_nyt, 0);
                            dr["Qty_Grade2_nyt"] = cls_Formater.FormatDecimal(dQty_Grade2_nyt, 0);
                            dr["attendence"] = sAttendanceStatus;

                            dr["travel_Allowance"] = sTravel_Allowance;
                            dr["attandance_Allowance"] = sAttendance_Allowance;

                            dr["rowBackColor"] = sRowBackColor;
                            dr["foreground"] = foreground;
                            dgr_Main.dt.Rows.Add(dr);

                            //updateRow(true, (dgr_Main.dt.Rows.Count - 1), dtmTimeIn, dtmTimeOut, dtmShiftStart);
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
                    dgr_Main.RefreshGrid();
                    FrmWaiting.Close();
                    this.Cursor = Cursors.Arrow;
                }
            }
            else
            {
                SEACCMessageBox.Show("Please Select a Week", "", MessageBoxButton.OK, "Red");
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

        #region Grid Events

        private void grd_Main_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int iColumnIndex = e.Column.DisplayIndex;
            int irowID = dgr_Main.SelectedIndex;
            TextBox t;

            #region Format DateTime
            DateTime dtTemp = clsConfig.defaultDateTime;
            if (iColumnIndex == 11 || iColumnIndex == 13)
            {
                t = e.EditingElement as TextBox;

                DateTime dtDate = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["attendenceDate"].ToString());
                DateTime IN_Time = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["InTime_E"].ToString());
                DateTime Out_Time = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["OutTime_E"].ToString());
                DateTime ShiftStartTime = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["Shift_StartTime"].ToString());

                if (t.Text.Length == 0)
                    t.Text = "-";

                if (t.Text != "-" || t.Text.Length == 0)
                {
                    #region Validate Time in
                    if (iColumnIndex == 11)
                    {
                        try
                        {
                            dtTemp = DateTime.Parse(t.Text);
                            IN_Time = dtTemp;
                            t.Text = dtTemp.ToString(clsConfig.Format_Time);
                            dgr_Main.dt.Rows[irowID]["inDateTime_ID_E"] = 1;
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
                            dtTemp = DateTime.Parse(t.Text);
                            Out_Time = dtTemp;
                            t.Text = dtTemp.ToString(clsConfig.Format_Time);
                            dgr_Main.dt.Rows[irowID]["outDateTime_ID_E"] = 1;
                        }
                        catch (Exception)
                        {
                            SEACCMessageBox.Show("Oops..!", "Unsupported Date Time Format", MessageBoxButton.OK);
                            t.Text = (Out_Time == clsConfig.defaultDateTime) ? "-" : Out_Time.ToString(clsConfig.Format_Time);
                        }
                    }
                    #endregion
                }
                //updateRow(false, irowID, IN_Time, Out_Time, ShiftStartTime);

            }
            #endregion

            #region Validate Nuts counts & Travelling Allowance 
            if (iColumnIndex == 15 || iColumnIndex == 16 || iColumnIndex == 17 || iColumnIndex == 18 || iColumnIndex == 19 || iColumnIndex == 20)
            {
                t = e.EditingElement as TextBox;
                //decimal nuts = clsValidation.Validate_DecimalNumber(dgr_Main.dt.Rows[irowID][iColumnIndex].ToString());
                decimal nuts = 0m;

                try
                {
                    nuts = decimal.Parse(t.Text);
                }
                catch (Exception)
                {
                    SEACCMessageBox.Show("Oops..!", "Please enter numeric value", MessageBoxButton.OK);
                }

                if (iColumnIndex == 19 || iColumnIndex == 20)
                    t.Text = cls_Formater.FormatDecimal(nuts, 2);
                else
                    t.Text = cls_Formater.FormatDecimal(nuts, 0);
            }
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
                            dgr_Main.dt.Rows[irowID]["InDate_E"] = "-";

                        else if (sColumn == "OutDate_E")
                            dgr_Main.dt.Rows[irowID]["OutDate_E"] = "-";

                        else if (sColumn == "InTime_E")
                            dgr_Main.dt.Rows[irowID]["InTime_E"] = "-";

                        else if (sColumn == "OutTime_E")
                            dgr_Main.dt.Rows[irowID]["OutTime_E"] = "-";
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
                    //uc_AttendenceRev.RefreshGrid(sEmployeeID, dtmAttendenceDate);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            #endregion
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
                    txtSection.Text = oEmployee.SectionID + " - " + oEmployee.Section_Name;

                }
            }
        }

        private void txtDesignation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Designations);
            if (RowDataSearch.DialogResult == true)
            {
                txtDesignation.Text = lstResult[0] + "-" + lstResult[1];
                txtDesignation.Tag = lstResult[0];
            }
        }

        private void txtDivision_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Division);
            if (RowDataSearch.DialogResult == true)
            {
                txtDivision.Text = lstResult[0] + "-" + lstResult[1];
                txtDivision.Tag = lstResult[0];
            }
        }

        private void txtDepartment_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Departments);
            if (RowDataSearch.DialogResult == true)
            {
                txtDepartment.Text = lstResult[0] + "-" + lstResult[1];
                txtDepartment.Tag = lstResult[0];
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

        private void txtSubSection_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.SubSections);
            if (RowDataSearch.DialogResult == true)
            {
                txtSubSection.Text = lstResult[0] + "-" + lstResult[1];
                txtSubSection.Tag = lstResult[0];
            }
        }

        private void txtEmpCategory1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.EmployeeCategory);
            if (RowDataSearch.DialogResult == true)
            {
                txtEmpCategory1.Text = lstResult[0] + "-" + lstResult[1];
                txtEmpCategory1.Tag = lstResult[0];
            }
        }

        private void txtEmpCategory2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.EmployeeCategory2);
            if (RowDataSearch.DialogResult == true)
            {
                txtEmpCategory2.Text = lstResult[0] + "-" + lstResult[1];
                txtEmpCategory2.Tag = lstResult[0];
            }
        }

        private void txtEmpCategory3_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.EmployeeCategory3);
            if (RowDataSearch.DialogResult == true)
            {
                txtEmpCategory3.Text = lstResult[0] + "-" + lstResult[1];
                txtEmpCategory3.Tag = lstResult[0];
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
                txtWeek.Text = lstResult[0] + "- Week " + lstResult[1];

                dtp_FromDate.SetTime(DateTime.Parse(lstResult[2]).Date);
                dtp_toDate.SetTime(DateTime.Parse(lstResult[3]).Date);

                dtp_FromDate.IsEnabled = false;
                dtp_toDate.IsEnabled = false;
            }
        }

        #endregion

        //private void updateRow(bool isInitialization, int irowID, DateTime dtmTimeIn, DateTime dtmTimeOut, DateTime dtmShiftStart)
        //{
        //    string sAttendanceStatus = "-";

        //    dtmTimeIn = clsValidation.Merge_DateAndTime(dtmShiftStart, dtmTimeIn);
        //    dtmTimeOut = clsValidation.Merge_DateAndTime(dtmShiftStart, dtmTimeOut);

        //    #region Shift Working Hours
        //    if (dtmTimeOut == clsConfig.defaultDateTime && dtmTimeIn == clsConfig.defaultDateTime)
        //    {
        //        //both times missing
        //        sAttendanceStatus = "Absent";
        //    }
        //    else if (dtmTimeOut == clsConfig.defaultDateTime || dtmTimeIn == clsConfig.defaultDateTime)
        //    {
        //        //only one time missing
        //        sAttendanceStatus = "ERROR";
        //    }
        //    else
        //    {
        //        if (dtmTimeIn <= dtmShiftStart)
        //            sAttendanceStatus = "Present";
        //        else
        //            sAttendanceStatus = "Late";
        //    }
        //    #endregion

        //    dgr_Main.dt.Rows[irowID]["attendence"] = sAttendanceStatus;
        //}

    }

    class ProcessRecord_DailyRates
    {
        public int iAttendanceIndex;
        public string sActivityId;
        public int iGradeId;
        public int iDay_DayType;
        public int iWeektargetStatus;
        public int iRateSlab;
    }

    class ProcessRecord_Week
    {
        public int iWeekId;
        public int iYearId;
        public string sEmployeeId;
    }
}