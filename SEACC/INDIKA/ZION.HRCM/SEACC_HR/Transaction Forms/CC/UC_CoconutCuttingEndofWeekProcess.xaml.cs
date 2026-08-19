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

namespace Digiteq.Transaction_Forms.CoconutCuting
{
    public partial class UC_CoconutCuttingEndofWeekProcess : UserControl
    {
        int iCurrentHRYear_ID = 0;
        string sCurrentYearName = "";

        #region Form Loading
        public UC_CoconutCuttingEndofWeekProcess()
        {
            #region Initialize Usercontrol
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.CoconutCuttingEndofWeekProcess;
            SEACC_Form.Initialize();

            tbl_hrPeriod_Year oYear = tbl_hrPeriod_Year.SelectAll().Where(r => r.Year_startDate.Date <= DateTime.Now.Date && r.Year_endDate >= DateTime.Now.Date).FirstOrDefault();
            if (oYear != null)
            {
                iCurrentHRYear_ID = oYear.Year_ID;
                sCurrentYearName = oYear.Year_Name;
            }
            #endregion

            #region Initialize Data Table - Week
            dgr_Main_Week.dt.Columns.Add("yearId");
            dgr_Main_Week.dt.Columns.Add("weekNo");
            dgr_Main_Week.dt.Columns.Add("weekStartDate");
            dgr_Main_Week.dt.Columns.Add("noOfWorkingDays");
            dgr_Main_Week.dt.Columns.Add("weekStatus");
            #endregion

            #region Initialize Data Table - Employees
            dgr_Main_Employees.dt.Columns.Add("empID");
            dgr_Main_Employees.dt.Columns.Add("empName");
            dgr_Main_Employees.dt.Columns.Add("empStatus", typeof(bool));
            dgr_Main_Employees.dt.Columns.Add("loanDeduct");
            dgr_Main_Employees.dt.Columns.Add("festDeduct");

            #endregion

            #region Acction Button
            SEACC_Form.SetVisibility_ActionButons(true, false, false, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            #endregion

            #region Initialize DataGrid - Week
            //dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "DGN", "day_goodNuts_count", 55, true, false);
            dgr_Main_Week.Add_DatagridColoumn(ColoumnType.Numaric, "Year", "yearId", 35, true, true);
            dgr_Main_Week.Add_DatagridColoumn(ColoumnType.Numaric, "Week", "weekNo", 40, true, true);
            dgr_Main_Week.Add_DatagridColoumn("Start Date", "weekStartDate", 65);
            dgr_Main_Week.Add_DatagridColoumn(ColoumnType.Numaric, "Days", "noOfWorkingDays", 40, true, true);
            dgr_Main_Week.Add_DatagridColoumn("Week Status", "weekStatus", 75);
            #endregion

            #region Initialize DataGrid - Employees
            dgr_Main_Employees.Add_DatagridColoumn("ID", "empID", 50);
            dgr_Main_Employees.Add_DatagridColoumn("Name", "empName", 175);
            dgr_Main_Employees.Add_DatagridColoumn(ColoumnType.CheckBox, "Process", "empStatus", 50, true, true);
            dgr_Main_Employees.Add_DatagridColoumn(ColoumnType.Numaric, "Loan Ded.", "loanDeduct", 80, true, false);
            dgr_Main_Employees.Add_DatagridColoumn(ColoumnType.Numaric, "Festival Ded.", "festDeduct", 80, true, false);
            #endregion


            ClearFields();
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //SEACC_Form.IsUpdateMode = false;
            dgr_Main_Week.dt.Clear();
            dgr_Main_Employees.dt.Clear();

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmpNo, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDesignation, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDivision, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDepartment, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSubSection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmpCategory1, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmpCategory2, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmpCategory3, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtYearID, true, false, false);

            //Configuration Details
            cls_Formater.SetEnableDisable_LableTextbox(txtDailyTargetNuts, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDailyMarginNuts, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtIncreRatePerNut, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtSalaryGenRate, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBRA1Amount, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBRA2Amount, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBRA3Amount, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAtteandaceAllowanceAmount, true, true, false);

            txtEmpNo.Tag = null;
            txtDesignation.Tag = null;
            txtDivision.Tag = null;
            txtDepartment.Tag = null;
            txtSection.Tag = null;
            txtSubSection.Tag = null;
            txtEmpCategory1.Tag = null;
            txtEmpCategory2.Tag = null;
            txtEmpCategory3.Tag = null;
            txtYearID.Tag = iCurrentHRYear_ID;

            txtEmpNo.Text = "<All Employees>";
            txtDesignation.Text = "<All Designations>";
            txtDivision.Text = "<All Divisions>";
            txtDepartment.Text = "<All Departments>";
            txtSection.Text = "<All Sections>";
            txtSubSection.Text = "<All Sub Sections>";
            txtEmpCategory1.Text = "<All Categories [1])>";
            txtEmpCategory2.Text = "<All Categories [2])>";
            txtEmpCategory3.Text = "<All Categories [3])>";
            txtYearID.Text = sCurrentYearName;

            chkWeekProcessCompleted.IsChecked = false;

            //Configuration Settings Initialization
            txtDailyTargetNuts.Text = cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(clsConfig.sCC_DailyTargetNuts), 0);
            txtDailyMarginNuts.Text = cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(clsConfig.sCC_DailyMarginNuts), 0);
            txtIncreRatePerNut.Text = cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(clsConfig.sCC_IncrementRatePerNut), 2);
            txtSalaryGenRate.Text = clsConfig.sCC_SalaryGereratingRate;
            txtBRA1Amount.Text = cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(clsConfig.sCC_BRA1Amount), 2);
            txtBRA2Amount.Text = cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(clsConfig.sCC_BRA2Amount), 2);
            txtBRA3Amount.Text = cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(clsConfig.sCC_BRA3Amount), 2);
            txtAtteandaceAllowanceAmount.Text = cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(clsConfig.sCC_AttendanceAllowanceAmount), 2);
        }
        #endregion

        #region Action Buttons
        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            #region Load Week Grid
            this.Cursor = Cursors.Wait;
            dgr_Main_Week.dt.Clear();
            foreach (tbl_hrPeriod_Week week in tbl_hrPeriod_Week.SelectAll().Where(r => r.Year_ID == int.Parse(txtYearID.Tag.ToString())))
                dgr_Main_Week.dt.Rows.Add(week.Year_ID, week.Week_ID, week.StartDate.Date.ToString(clsConfig.Format_Date), week.WerkingDays_Mandatory, Enum.GetName(typeof(CC_WeekStatus), week.WeekStatus_ID));
            dgr_Main_Week.RefreshGrid();
            this.Cursor = Cursors.Arrow;
            #endregion

            dgr_Main_Week.grdMain.SelectedIndex = 0;
            //dgr_Main_Week.SetFilterValue("Year", "yearId", iCurrentHRYear_ID.ToString());
            //   FillEmployeeGrid();

        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            frm_WaitingMessege FrmWaiting = new frm_WaitingMessege();
            int empCount = 0;
            int iWeekId = 0;
            int iYearId = 0;
            try
            {
                this.Cursor = Cursors.Wait;

                int irowID = dgr_Main_Week.SelectedIndex;
                iYearId = int.Parse(dgr_Main_Week.dt.Rows[irowID]["yearId"].ToString());
                iWeekId = int.Parse(dgr_Main_Week.dt.Rows[irowID]["weekNo"].ToString());

                tbl_hrPeriod_Week oWeek = tbl_hrPeriod_Week.Select(clsSecurity.CompanyID, clsSecurity.BranchID, iYearId, iWeekId);
                if (oWeek != null)
                {
                    foreach (DataRow raw in dgr_Main_Employees.dt.Select())
                    {
                        string sEmployee_ID = raw["empID"].ToString();
                        bool empStatus = bool.Parse(raw["empStatus"].ToString());
                        decimal dLoanDeduct = clsValidation.Validate_DecimalNumber(raw["loanDeduct"].ToString());
                        decimal dFestivalDeduct = clsValidation.Validate_DecimalNumber(raw["festDeduct"].ToString());

                        if (!empStatus) //Check status
                            continue;

                        if (GetEmployee_isProcessInEOW(iYearId, iWeekId, sEmployee_ID)) //Check Already Calculated or not
                        {
                            SEACCMessageBox.Show("Attention!", "'" + sEmployee_ID + " - " + clsRef_Name.get_EmployeeShortName(sEmployee_ID) + "' salary has already been calculated.", MessageBoxButton.OK);
                            continue;
                        }

                        decimal dDaylyTarget_Margin = clsValidation.Validate_DecimalNumber(txtDailyMarginNuts.Text); // 3000; // setup daily traget
                        decimal dDaylyTarget_Calculations = clsValidation.Validate_DecimalNumber(txtDailyTargetNuts.Text);// 2500;

                        decimal init_Rate_Good = 0;
                        decimal init_Rate_Damage = 0;
                        decimal increase_Rate_Good = clsValidation.Validate_DecimalNumber(txtIncreRatePerNut.Text);  //  0.05m;
                        decimal increase_Rate_Damage = increase_Rate_Good * 2.0m;

                        Target enmTarget = Target.notAchived;
                        decimal dWK_Qty_G1_Good = 0, dWK_Qty_G2_Damage = 0;
                        decimal dWK_Qty_G1_Good_Night = 0, dWK_G2_Damage_Night = 0;
                        decimal dActualWorkedDays = 0;
                        //decimal dAttendanceBonusDays = 0;

                        decimal dBasicSalary_Weekly = 0, dBasicSalary_Weekly_PS = 0, dAllowance_budgetory1_weekly = 0, dAllowance_budgetory2_weekly = 0, dAllowance_budgetory3_weekly = 0, dAllowance_Attendenc_weekly = 0, dAllowance_Traveling_weekly = 0, dSalaryGross = 0, dSalaryGross_PS = 0, dEPF_8 = 0, dEPF_12 = 0, dETF_3 = 0, dSalaryNet, dSalaryNet_PS, dNightTimeEarning_weekly = 0;
                        decimal dSalaryParameeter = clsValidation.Validate_DecimalNumber(txtSalaryGenRate.Text);// 351.67m / 1000m;
                        decimal dBudgetoryAllowanceDayRate1 = clsValidation.Validate_DecimalNumber(txtBRA1Amount.Text);// 40;
                        decimal dBudgetoryAllowanceDayRate2 = clsValidation.Validate_DecimalNumber(txtBRA2Amount.Text);// 60;
                        decimal dBudgetoryAllowanceDayRate3 = clsValidation.Validate_DecimalNumber(txtBRA3Amount.Text);// 40;
                        decimal dAttendenceAllowanceDayrate = clsValidation.Validate_DecimalNumber(txtAtteandaceAllowanceAmount.Text);// 100;

                        #region Get weekly Actual Qty
                        foreach (tbl_ccTxDailyWorkingProgress detail in tbl_ccTxDailyWorkingProgress.SelectAllBy_DateRange(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployee_ID, oWeek.StartDate.Date, oWeek.EndDate.Date).Where(r => r.PaymentPeriod == (int)CC_PaymentPeriod.Weekly))
                        {
                            dWK_Qty_G1_Good += detail.Qty_Grade1;
                            dWK_Qty_G2_Damage += detail.Qty_Grade2;

                            dWK_Qty_G1_Good_Night += detail.Qty_Grade1_Night;
                            dWK_G2_Damage_Night += detail.Qty_Grade2_Night;

                            if (detail.Qty_Grade1 > 0 || detail.Qty_Grade1_Night > 0 || detail.Qty_Grade2 > 0 || detail.Qty_Grade2_Night > 0)
                            {
                                dActualWorkedDays++;
                                //if (detail.TimeIn_DateTime <= detail.ShiftStartTime && detail.ShiftStartTime.Date != clsValidation.defaultDateTime.Date)
                                //    dAttendanceBonusDays++;
                            }
                        }

                        decimal dWK_Target = (dWK_Qty_G1_Good + dWK_Qty_G2_Damage * 2);
                        if (dWK_Target >= oWeek.Target)
                        {
                            enmTarget = Target.acived;
                            init_Rate_Good = clsValidation.Validate_DecimalNumber(clsConfig.sCC_RateWeekDay);
                        }
                        else
                        {
                            init_Rate_Good = clsValidation.Validate_DecimalNumber(clsConfig.sCC_RateWeekDay);
                        }
                        init_Rate_Damage = init_Rate_Good * 2.0m;
                        #endregion

                        foreach (tbl_ccTxDailyWorkingProgress detail in tbl_ccTxDailyWorkingProgress.SelectAllBy_DateRange(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployee_ID, oWeek.StartDate.Date, oWeek.EndDate.Date).Where(r => r.PaymentPeriod == (int)CC_PaymentPeriod.Weekly))
                        {
                            DataTable dt_Amts_Good = new DataTable();
                            DataTable dt_Amts_Damage = new DataTable();
                            DataTable dt_Amts_Good_Night = new DataTable();
                            DataTable dt_Amts_Damage_Night = new DataTable();
                            decimal dTotalEarningForTheDay = 0, dTotalEarningForTheNight = 0;

                            if (detail.DayType == (int)DayTypes.WorkingDay)
                            {
                                dt_Amts_Good = GetDailyAmount(dDaylyTarget_Margin, dDaylyTarget_Calculations, 500, detail.Qty_Grade1, init_Rate_Good, increase_Rate_Good);
                                dt_Amts_Damage = GetDailyAmount(dDaylyTarget_Margin, dDaylyTarget_Calculations, 500, detail.Qty_Grade2, init_Rate_Damage, increase_Rate_Damage);
                            }
                            else if (detail.DayType == (int)DayTypes.Saturday)
                            {
                                dt_Amts_Good = GetDailyAmount(dDaylyTarget_Margin, dDaylyTarget_Calculations, 500, detail.Qty_Grade1, init_Rate_Good * 1.5m, increase_Rate_Good * 1.5m);
                                dt_Amts_Damage = GetDailyAmount(dDaylyTarget_Margin, dDaylyTarget_Calculations, 500, detail.Qty_Grade2, init_Rate_Damage * 1.5m, increase_Rate_Damage * 1.5m);
                            }
                            else
                            {
                                dt_Amts_Good = GetDailyAmount(dDaylyTarget_Margin, dDaylyTarget_Calculations, 500, detail.Qty_Grade1, init_Rate_Good * 2.0m, increase_Rate_Good * 2.0m);
                                dt_Amts_Damage = GetDailyAmount(dDaylyTarget_Margin, dDaylyTarget_Calculations, 500, detail.Qty_Grade2, init_Rate_Damage * 2.0m, increase_Rate_Damage * 2.0m);
                            }
                            dt_Amts_Good_Night = GetDailyAmount(50000, 50000, 50000, detail.Qty_Grade1_Night, 1.10m, 0);
                            dt_Amts_Damage_Night = GetDailyAmount(50000, 50000, 50000, detail.Qty_Grade2_Night, 2.20m, 0);

                            #region Insert Good Nuts records - Day Time
                            int iLineNo = 0;
                            foreach (DataRow rawWIP in dt_Amts_Good.Rows)
                            {
                                tbl_ccTxDailyWorkingProgress_Rate oRecord = new tbl_ccTxDailyWorkingProgress_Rate(detail.Company_ID, detail.CompanyBranch_ID, detail.Attendance_index, "default", (int)Grade.Good, detail.DayType, (int)enmTarget, iLineNo, decimal.Parse(rawWIP["Quantity"].ToString()), decimal.Parse(rawWIP["Rate"].ToString()), decimal.Parse(rawWIP["Amount"].ToString()), false);
                                oRecord.Insert();
                                dTotalEarningForTheDay += oRecord.Amount;
                                iLineNo++;
                            }
                            #endregion

                            #region Insert Damage Nuts Records - Day Time
                            foreach (DataRow rawWIP in dt_Amts_Damage.Rows)
                            {
                                tbl_ccTxDailyWorkingProgress_Rate oRecord = new tbl_ccTxDailyWorkingProgress_Rate(detail.Company_ID, detail.CompanyBranch_ID, detail.Attendance_index, "default", (int)Grade.Damage, detail.DayType, (int)enmTarget, iLineNo, decimal.Parse(rawWIP["Quantity"].ToString()), decimal.Parse(rawWIP["Rate"].ToString()), decimal.Parse(rawWIP["Amount"].ToString()), false);
                                oRecord.Insert();
                                dTotalEarningForTheDay += oRecord.Amount;
                                iLineNo++;
                            }
                            #endregion

                            #region Insert Good Nuts Records - Night Time
                            foreach (DataRow rawWIP in dt_Amts_Good_Night.Rows)
                            {
                                tbl_ccTxDailyWorkingProgress_Rate oRecord = new tbl_ccTxDailyWorkingProgress_Rate(detail.Company_ID, detail.CompanyBranch_ID, detail.Attendance_index, "default", (int)Grade.Good, detail.DayType, (int)enmTarget, iLineNo, decimal.Parse(rawWIP["Quantity"].ToString()), decimal.Parse(rawWIP["Rate"].ToString()), decimal.Parse(rawWIP["Amount"].ToString()), true);
                                oRecord.Insert();
                                dTotalEarningForTheNight += oRecord.Amount;
                                iLineNo++;
                            }
                            #endregion

                            #region Insert Damage Nuts Records - Night Time
                            foreach (DataRow rawWIP in dt_Amts_Damage_Night.Rows)
                            {
                                tbl_ccTxDailyWorkingProgress_Rate oRecord = new tbl_ccTxDailyWorkingProgress_Rate(detail.Company_ID, detail.CompanyBranch_ID, detail.Attendance_index, "default", (int)Grade.Damage, detail.DayType, (int)enmTarget, iLineNo, decimal.Parse(rawWIP["Quantity"].ToString()), decimal.Parse(rawWIP["Rate"].ToString()), decimal.Parse(rawWIP["Amount"].ToString()), true);
                                oRecord.Insert();
                                dTotalEarningForTheNight += oRecord.Amount;
                                iLineNo++;
                            }
                            #endregion

                            detail.Amount_Total = dTotalEarningForTheDay; // Day Time Amount Only
                            detail.Amount_Total_Night = dTotalEarningForTheNight; //Night Time Amount Only
                            if (detail.Qty_Grade1 > 0 || detail.Qty_Grade1_Night > 0 || detail.Qty_Grade2 > 0 || detail.Qty_Grade2_Night > 0)
                            {
                                detail.Budgetary_Allowance1 = dBudgetoryAllowanceDayRate1;
                                detail.Budgetary_Allowance2 = dBudgetoryAllowanceDayRate2;
                                detail.Budgetary_Allowance3 = dBudgetoryAllowanceDayRate3;

                                /*
                                 * Commented by Gayan 2017-05-16
                                 * Requested from Hero Nature
                                 * Need to enter manually 
                                 * Like travelling allowance
                                 * 
                                if (detail.TimeIn_DateTime <= detail.ShiftStartTime && detail.ShiftStartTime.Date != clsValidation.defaultDateTime.Date)
                                {
                                    if (detail.DayType == (int)DayTypes.WorkingDay || detail.DayType == (int)DayTypes.Saturday)
                                        detail.Attendace_Allowance = dAttendenceAllowanceDayrate;
                                }
                                */
                            }
                            detail.Amount_Payslip = (detail.Qty_Grade1 + detail.Qty_Grade2) * dSalaryParameeter;
                            decimal dTotal = detail.Budgetary_Allowance1 + detail.Budgetary_Allowance2 + detail.Budgetary_Allowance3 + detail.Amount_Payslip;
                            detail.Epf_8 = dTotal * 8 / 100;
                            detail.Epf_12 = dTotal * 12 / 100;
                            detail.Etf_3 = dTotal * 3 / 100;

                            detail.Update();

                            dBasicSalary_Weekly += detail.Amount_Total;
                            dAllowance_Traveling_weekly += detail.Travel_Allowance;
                            dNightTimeEarning_weekly += detail.Amount_Total_Night;
                            dAllowance_budgetory1_weekly += detail.Budgetary_Allowance1;
                            dAllowance_budgetory2_weekly += detail.Budgetary_Allowance2;
                            dAllowance_budgetory3_weekly += detail.Budgetary_Allowance3;
                            dAllowance_Attendenc_weekly += detail.Attendace_Allowance;

                            dEPF_8 += detail.Epf_8;
                            dEPF_12 += detail.Epf_12;
                            dETF_3 += detail.Etf_3;
                        }

                        dBasicSalary_Weekly_PS = (dWK_Qty_G1_Good + dWK_Qty_G2_Damage) * dSalaryParameeter;
                        dSalaryGross = dBasicSalary_Weekly + dAllowance_budgetory1_weekly + dAllowance_Attendenc_weekly + dAllowance_Traveling_weekly;
                        dSalaryGross_PS = dBasicSalary_Weekly_PS + dAllowance_budgetory1_weekly + dAllowance_budgetory2_weekly + dAllowance_budgetory3_weekly;
                        dSalaryNet = dSalaryGross - dEPF_8 - dLoanDeduct - dFestivalDeduct;
                        dSalaryNet_PS = dSalaryGross_PS - dEPF_8;

                        tbl_ccTxEndOfWeekProgress nEOW_record = new tbl_ccTxEndOfWeekProgress(clsSecurity.CompanyID, clsSecurity.BranchID, iYearId, iWeekId, sEmployee_ID, oWeek.WerkingDays_Mandatory, dActualWorkedDays, oWeek.Target, (dWK_Qty_G1_Good + dWK_Qty_G2_Damage), ((enmTarget == Target.acived) ? true : false), dBasicSalary_Weekly, dBasicSalary_Weekly_PS, dAllowance_budgetory1_weekly, dAllowance_budgetory2_weekly, dAllowance_budgetory3_weekly, dAllowance_Attendenc_weekly, dAllowance_Traveling_weekly, dSalaryGross, dSalaryGross_PS,
                                dEPF_8, dEPF_12, dETF_3, dLoanDeduct, dFestivalDeduct, 0, dSalaryNet, dSalaryNet_PS, true, false, false, clsSecurity.UserIDLoged, "default", "default", clsSecurity.TerminalID, "default", "default", clsSecurity.getServerDateTime(), clsConfig.defaultDateTime, clsConfig.defaultDateTime, dNightTimeEarning_weekly);
                        nEOW_record.Insert();

                        empCount++;
                    }
                }

                #region Update  Week Status in the Table

                tbl_hrPeriod_Week oPeriod = tbl_hrPeriod_Week.Select(clsSecurity.CompanyID, clsSecurity.BranchID, iYearId, iWeekId);
                oPeriod.WeekStatus_ID = 1;
                if (chkWeekProcessCompleted.IsChecked.Value)
                    oPeriod.WeekStatus_ID = 2;
                oPeriod.Update();
                #endregion

                SEACCMessageBox.Show("Completed...! ", empCount.ToString() + " employees' salaries have been processed.", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            finally
            {
                dgr_Main_Week.dt.Clear();
                dgr_Main_Employees.dt.Clear();
                btnLoad.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                setSelectedIndexUsingCellValue(iYearId.ToString(), iWeekId.ToString());
                dgr_Main_Week_MouseLeftButtonUp1(sender, e);
                FrmWaiting.Close();
                this.Cursor = Cursors.Arrow;
            }
        }
        #endregion

        #region Grid Events
        private void dgr_Main_Employees_MouseLeftButtonUp1(object sender, EventArgs e)
        {

        }

        private void dgr_Main_Week_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            FillEmployeeGrid();
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

        private void txtYearID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.HRYear);
            if (RowDataSearch.DialogResult == true)
            {
                txtYearID.Text = lstResult[1];
                txtYearID.Tag = lstResult[0];
            }
        }
        #endregion

        #region Checkbox Events
        private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
        {
            foreach (DataRow row in dgr_Main_Employees.dt.Rows)
            {
                bool isProcess = bool.Parse(row["empStatus"].ToString());
                if (!isProcess)
                    row["empStatus"] = true;
            }
        }

        private void chkSelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (DataRow row in dgr_Main_Employees.dt.Rows)
            {
                bool isProcess = bool.Parse(row["empStatus"].ToString());
                if (isProcess)
                    row["empStatus"] = false;
            }
        }
        #endregion

        #region CC Help Methods

        public void FillEmployeeGrid()
        {
            try
            {
                this.Cursor = Cursors.Wait;
                int irowID = dgr_Main_Week.SelectedIndex;
                var vDG_Cell = dgr_Main_Week.GetCurrentCell();

                int sYearId = int.Parse(dgr_Main_Week.dt.Rows[irowID]["yearId"].ToString());
                int sWeekId = int.Parse(dgr_Main_Week.dt.Rows[irowID]["weekNo"].ToString());


                #region Load Employee Grid
                dgr_Main_Employees.dt.Clear();

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

                foreach (tbl_genMasEmployee oEmployee in oEmployees)
                {
                    dgr_Main_Employees.dt.Rows.Add(oEmployee.Employee_ID, oEmployee.SurName + " , " + oEmployee.Initails, GetEmployee_isProcessInEOW(sYearId, sWeekId, oEmployee.Employee_ID), GetEmployee_LoanInEOW(sYearId, sWeekId, oEmployee.Employee_ID), GetEmployee_FestivalInEOW(sYearId, sWeekId, oEmployee.Employee_ID));
                }
                dgr_Main_Employees.RefreshGrid();

                #endregion
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        public bool GetEmployee_isProcessInEOW(int yearID, int weekID, string employeeID)
        {
            bool status = false;
            tbl_ccTxEndOfWeekProgress oEOW_record = tbl_ccTxEndOfWeekProgress.Select(clsSecurity.CompanyID, clsSecurity.BranchID, employeeID, yearID, weekID);
            if (oEOW_record != null)
                status = oEOW_record.IsProcessed;
            return status;
        }

        public string GetEmployee_LoanInEOW(int yearID, int weekID, string employeeID)
        {
            decimal value = 0;
            tbl_ccTxEndOfWeekProgress oEOW_record = tbl_ccTxEndOfWeekProgress.Select(clsSecurity.CompanyID, clsSecurity.BranchID, employeeID, yearID, weekID);
            if (oEOW_record != null)
                value = oEOW_record.Deduction_Loan;
            return cls_Formater.FormatDecimal(value, 2);
        }

        public string GetEmployee_FestivalInEOW(int yearID, int weekID, string employeeID)
        {
            decimal value = 0;
            tbl_ccTxEndOfWeekProgress oEOW_record = tbl_ccTxEndOfWeekProgress.Select(clsSecurity.CompanyID, clsSecurity.BranchID, employeeID, yearID, weekID);
            if (oEOW_record != null)
                value = oEOW_record.Deduction_Festival;
            return cls_Formater.FormatDecimal(value, 2);
        }

        public DataTable GetDailyAmount(decimal dailyTargetQty_Margin, decimal dailyTargetQty_Calc, decimal balanceQty, decimal actualQty, decimal init_rate, decimal rateIncreasingFactor)
        {
            decimal remaider_qty = 0;
            DataTable dtQty = new DataTable();
            dtQty.Columns.Add("Quantity", typeof(decimal));
            dtQty.Columns.Add("Rate", typeof(decimal));
            dtQty.Columns.Add("Amount", typeof(decimal));

            if (actualQty > 0)
            {
                if (actualQty < dailyTargetQty_Margin)
                    dtQty.Rows.Add(actualQty, init_rate, actualQty * init_rate);
                else
                {
                    remaider_qty = actualQty - dailyTargetQty_Calc;
                    dtQty.Rows.Add(dailyTargetQty_Calc, init_rate, dailyTargetQty_Calc * init_rate);

                    /*
                    while (remaider_qty > 0)
                    {
                        init_rate = init_rate + rateIncreasingFactor;

                        if (remaider_qty <= balanceQty)
                            dtQty.Rows.Add(remaider_qty, init_rate, remaider_qty * init_rate);
                        else
                            dtQty.Rows.Add(balanceQty, init_rate, balanceQty * init_rate);

                        remaider_qty = remaider_qty - balanceQty;
                    }
                    */

                    //This change was happen on 9th January 2017 - According to the requesting from Thanuja - She said that not increase init_rate after every 500 nuts.
                    if (remaider_qty > 0)
                    {
                        init_rate = init_rate + rateIncreasingFactor;
                        dtQty.Rows.Add(remaider_qty, init_rate, remaider_qty * init_rate);
                    }

                }
            }
            return dtQty;
        }

        public void setSelectedIndexUsingCellValue(string value_year, string value_week)
        {
            for (int i = 0; i < dgr_Main_Week.grdMain.Items.Count; i++)
            {
                dgr_Main_Week.grdMain.ScrollIntoView(dgr_Main_Week.grdMain.Items[i]);
                DataGridRow row = (DataGridRow)dgr_Main_Week.grdMain.ItemContainerGenerator.ContainerFromIndex(i);

                TextBlock cellContent_year = dgr_Main_Week.grdMain.Columns[0].GetCellContent(row) as TextBlock;
                TextBlock cellContent_week = dgr_Main_Week.grdMain.Columns[1].GetCellContent(row) as TextBlock;
                if (cellContent_week != null && cellContent_year != null)
                {
                    if (cellContent_year.Text.Trim().Equals(value_year) && cellContent_week.Text.Trim().Equals(value_week))
                    {
                        object item = dgr_Main_Week.grdMain.Items[i];
                        dgr_Main_Week.grdMain.SelectedItem = item;
                        dgr_Main_Week.grdMain.ScrollIntoView(item);
                        row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                        break;
                    }
                }
            }
        }

        #endregion
    }


}