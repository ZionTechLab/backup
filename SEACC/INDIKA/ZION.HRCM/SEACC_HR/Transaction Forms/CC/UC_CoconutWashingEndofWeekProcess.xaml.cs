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
    /// Interaction logic for UC_CoconutWashingEndofWeekProcess.xaml
    /// </summary>
    public partial class UC_CoconutWashingEndofWeekProcess : UserControl
    {
        int iCurrentHRYear_ID = 0;
        string sCurrentYearName = "";

        #region Form Loading
        public UC_CoconutWashingEndofWeekProcess()
        {
            #region Initialize Usercontrol            
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.CoconutWashingEndofWeekProcess;
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
            dgr_Main_Week.Add_DatagridColoumn("Week Status", "weekStatus", 75, false);
            #endregion

            #region Initialize DataGrid - Employees
            dgr_Main_Employees.Add_DatagridColoumn("ID", "empID", 70);
            dgr_Main_Employees.Add_DatagridColoumn("Name", "empName", 175);
            dgr_Main_Employees.Add_DatagridColoumn(ColoumnType.CheckBox, "Process", "empStatus", 50, true, true);
            dgr_Main_Employees.Add_DatagridColoumn(ColoumnType.Numaric, "Loan Ded.", "loanDeduct", 80, false, false);
            dgr_Main_Employees.Add_DatagridColoumn(ColoumnType.Numaric, "Festival Ded.", "festDeduct", 80, false, false);
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
            //FillEmployeeGrid();
        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            int iWeekId = 0;
            int iYearId = 0;
            frm_WaitingMessege FrmWaiting = new frm_WaitingMessege();
            int empCount = 0;
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
                        //decimal dLoanDeduct = clsValidation.Validate_DecimalNumber(raw["loanDeduct"].ToString());
                        //decimal dFestivalDeduct = clsValidation.Validate_DecimalNumber(raw["festDeduct"].ToString());
                        decimal dWash_tot = 0, dAtten_tot = 0, dBudgetary_tot = 0, dEarn_tot = 0;
                        int iWorkDays = 0;
                        decimal dQtyWeek_Nuts = 0;
                        decimal dRate = 0.15m;

                        if (!empStatus) //Check status
                            continue;

                        tbl_ccTxEndOfWeekWashingProgress oEOW_Rec = tbl_ccTxEndOfWeekWashingProgress.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oWeek.Year_ID, oWeek.Week_ID, sEmployee_ID);
                        if (oEOW_Rec != null)
                        {
                            SEACCMessageBox.Show("Already Processed!", "Employee : " + sEmployee_ID + " - " + clsRef_Name.get_EmployeeShortName(sEmployee_ID) + " \nhas already been processed for the week " + oWeek.Week_ID, MessageBoxButton.OK);
                            continue;
                        }

                        foreach (tbl_ccTxDailyWashingProgress oDailyRecord in tbl_ccTxDailyWashingProgress.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployee_ID).Where(r => r.Week_ID == oWeek.Week_ID && r.Year_ID == oWeek.Year_ID && r.IsCoconutWashed))
                        {
                            #region Check Daytype and Set the dRate
                            if (oDailyRecord.DayType == 1) //SatureDay
                                dRate = dRate * 1.5m;
                            else if (oDailyRecord.DayType == 2 || oDailyRecord.DayType == 3) //Sunday & Poyaday
                                dRate = dRate * 2.0m;
                            #endregion

                            //string sQuary = "SELECT SUM(qty_Grade1) AS qtyG1, SUM(qty_Grade2) AS qtyG2, SUM(qty_Grade1_Night) AS qtyGN1, SUM(qty_Grade2_Night) AS qtyGN2" +
                            //                    " FROM tbl_ccTxDailyWorkingProgress " +
                            //                        "WHERE attendenceDate = '" + oDailyRecord.AttendenceDate.Date + "'";

                            //decimal dGoodNuts = 0;
                            //decimal dDamageNuts = 0;
                            //decimal dGoodNuts_Night = 0;
                            //decimal dDamageNuts_Night = 0;

                            //DataTable dt_result_qty = DBHandling.ExecQuery(sQuary).Tables[0];
                            //if (dt_result_qty != null && dt_result_qty.Rows.Count > 0)
                            //{
                            //    dGoodNuts = clsValidation.Validate_DecimalNumber(dt_result_qty.Rows[0]["qtyG1"].ToString());
                            //    dDamageNuts = clsValidation.Validate_DecimalNumber(dt_result_qty.Rows[0]["qtyG2"].ToString());
                            //    dGoodNuts_Night = clsValidation.Validate_DecimalNumber(dt_result_qty.Rows[0]["qtyGN1"].ToString());
                            //    dDamageNuts_Night = clsValidation.Validate_DecimalNumber(dt_result_qty.Rows[0]["qtyG2"].ToString());
                            //}

                            //decimal dTot_nuts = dGoodNuts + dDamageNuts; //dGoodNuts_Night + dDamageNuts_Night
                            decimal dTot_nuts = oDailyRecord.Qty_Total;
                            int iEmp_Count = (tbl_ccTxDailyWashingProgress.SelectAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID(clsSecurity.CompanyID, clsSecurity.BranchID, oWeek.Year_ID, oWeek.Week_ID).Where(r => r.AttendenceDate.Date == oDailyRecord.AttendenceDate.Date && r.IsCoconutWashed && !r.IsCanceled)).Count();

                            iWorkDays++;
                            oDailyRecord.Qty_Total = dTot_nuts;
                            oDailyRecord.Employee_Count_Total = iEmp_Count;
                            oDailyRecord.Rate = dRate;
                            //oDailyRecord.Earn_Total = (dTot_nuts * oDailyRecord.Rate) / iEmp_Count;
                            oDailyRecord.Earn_Total = (dTot_nuts * oDailyRecord.Rate);
                            oDailyRecord.IsLocked = true;
                            oDailyRecord.Update();

                            dWash_tot += oDailyRecord.Washing_Allo;
                            dAtten_tot += oDailyRecord.Attendance_Allo;
                            dBudgetary_tot += oDailyRecord.Budgetary_Allo;
                            dEarn_tot += oDailyRecord.Earn_Total;
                            dQtyWeek_Nuts += oDailyRecord.Qty_Total;
                        }

                        tbl_ccTxEndOfWeekWashingProgress oEOW = new tbl_ccTxEndOfWeekWashingProgress(clsSecurity.CompanyID, clsSecurity.BranchID, oWeek.Year_ID, oWeek.Week_ID, sEmployee_ID, oWeek.WerkingDays_Mandatory, iWorkDays, dQtyWeek_Nuts, dQtyWeek_Nuts, (dWash_tot + dAtten_tot + dBudgetary_tot + dEarn_tot), clsSecurity.UserIDLoged, "default", "default", clsSecurity.TerminalID, "default", "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime);
                        oEOW.Insert();

                        empCount++;
                    }
                }
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
                //clsHelpMethods.SetSelectedIndexUsingCellValue(dgr_Main_Week.grdMain, 1, iWeekId.ToString());
                dgr_Main_Week_MouseLeftButtonUp1(sender, e);
                FrmWaiting.Close();
                this.Cursor = Cursors.Arrow;
            }
        }

        #endregion

        #region Grid Events
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

                if (txtSection.Tag != null)
                    oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();

                #endregion

                foreach (tbl_genMasEmployee oEmployee in oEmployees)
                {
                    dgr_Main_Employees.dt.Rows.Add(oEmployee.Employee_ID, oEmployee.SurName + " , " + oEmployee.Initails, GetEmployee_isProcessInEOW(sYearId, sWeekId, oEmployee.Employee_ID), "00.00", "00.00");
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
            tbl_ccTxEndOfWeekWashingProgress oEOW_record = tbl_ccTxEndOfWeekWashingProgress.Select(clsSecurity.CompanyID, clsSecurity.BranchID, yearID, weekID, employeeID);
            if (oEOW_record != null)
                status = true;
            return status;
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
