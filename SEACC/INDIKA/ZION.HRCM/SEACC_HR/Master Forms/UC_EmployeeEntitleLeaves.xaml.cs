using System;
using System.Collections.Generic;
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
using Digiteq_Logic;
using DataTire;
using SEACC_WPFControls;
using System.Data;
using System.Collections;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_EmployeeEntitleLeaves.xaml
    /// </summary>
    public partial class UC_EmployeeEntitleLeaves : UserControl
    {
        #region Class Variables
        DataTable dt = new DataTable();
        DateTime dtmCurrentHRYear_StartDate = DateTime.Now, dtmCurrentHRYear_EndDate = DateTime.Now;
        int iCurrentHRYear_ID = 0;
        string sCurrentYear_Name = "";
        #endregion

        #region Form Load
        public UC_EmployeeEntitleLeaves()
        {
            #region Initialize Usercontrol
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Employee_Entitle_Leaves;
            SEACC_Form.Initialize();

            tbl_hrPeriod_Year oYear = tbl_hrPeriod_Year.SelectAll().Where(r => r.Year_startDate.Date <= DateTime.Now.Date && !r.IsCanceled && r.Year_endDate >= DateTime.Now.Date).FirstOrDefault();
            if (oYear != null)
            {
                iCurrentHRYear_ID = oYear.Year_ID;
                sCurrentYear_Name = oYear.Year_Name;
                dtmCurrentHRYear_StartDate = oYear.Year_startDate.Date;
                dtmCurrentHRYear_EndDate = oYear.Year_endDate.Date;
            }
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("Emp_No");
            dgr_Main.dt.Columns.Add("EPF_No");
            dgr_Main.dt.Columns.Add("Emp_Name");
            foreach (tbl_hrMasLeaveTypes oLeave in tbl_hrMasLeaveTypes.SelectAll().OrderBy(r => r.LeaveType_ID).Where(r => !r.IsCanceled && r.IsDaysLimit && r.LeaveType_ID != "default"))
            {
                DataColumn dcLeaveType = new DataColumn(oLeave.LeaveType_ID, typeof(decimal));
                dcLeaveType.DefaultValue = cls_Formater.FormatDecimal(0, 2);
                dgr_Main.dt.Columns.Add(dcLeaveType);
            }
            #endregion

            #region Acction Button
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Employee No", "Emp_No", 100);
            dgr_Main.Add_DatagridColoumn("EPF No", "EPF_No", 100);
            dgr_Main.Add_DatagridColoumn("Employee Name", "Emp_Name", 150);
            foreach (tbl_hrMasLeaveTypes oLeave in tbl_hrMasLeaveTypes.SelectAll().OrderBy(r => r.LeaveType_ID).Where(r => !r.IsCanceled && r.IsDaysLimit && r.LeaveType_ID != "default"))
            {
                dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, oLeave.LeaveType_Name, oLeave.LeaveType_ID, 100, true, false);
            }
            #endregion

            ClearFields();
        }
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(630);
        }
        #endregion

        #region Action Buttons
        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            frm_WaitingMessege FrmWaiting = new frm_WaitingMessege();

            try
            {
                foreach (System.Data.DataRowView row in dgr_Main.grdMain.ItemsSource)
                {
                    string empID = row[0].ToString();
                    foreach (DataGridTextColumn column in dgr_Main.grdMain.Columns)
                    {
                        if (column.DisplayIndex < 3)
                            continue;

                        tbl_tasEmployeeLeave_entitled oEmpLeaveEntitle = tbl_tasEmployeeLeave_entitled.Select(clsSecurity.CompanyID, clsSecurity.BranchID, empID, int.Parse(txtPayrollYear.Tag.ToString()), column.SortMemberPath.ToString());

                        if (oEmpLeaveEntitle != null)
                        {
                            tbl_tasEmployeeLeave_entitled nEmpLeaveEntitle = new tbl_tasEmployeeLeave_entitled(
                                    clsSecurity.CompanyID, clsSecurity.BranchID, empID, int.Parse(txtPayrollYear.Tag.ToString()),
                                    oEmpLeaveEntitle.LeaveType_ID, clsValidation.Validate_DecimalNumber(row[column.DisplayIndex].ToString()), oEmpLeaveEntitle.Leaves_Utilized,
                                    false, clsSecurity.UserIDLoged, "default", "default", clsSecurity.TerminalID, "default", "default",
                                    clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                            oEmpLeaveEntitle.Delete();
                            nEmpLeaveEntitle.Insert();
                        }
                        else
                        {
                            tbl_tasEmployeeLeave_entitled nEmpLeaveEntitle = new tbl_tasEmployeeLeave_entitled(
                                    clsSecurity.CompanyID, clsSecurity.BranchID, empID, int.Parse(txtPayrollYear.Tag.ToString()),
                                    column.SortMemberPath.ToString(), clsValidation.Validate_DecimalNumber(row[column.DisplayIndex].ToString()), 0,
                                    false, clsSecurity.UserIDLoged, "default", "default", clsSecurity.TerminalID, "default", "default",
                                    clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                            nEmpLeaveEntitle.Insert();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            finally
            {
                btn_load.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                FrmWaiting.Close();
                this.Cursor = Cursors.Arrow;
            }
        }

        private void btn_load_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                if (txtPayrollYear.Tag != null)
                {
                    dgr_Main.dt.Clear();

                    foreach (tbl_genMasEmployee oEmp in tbl_genMasEmployee.SelectAll().Where(p => p.Employee_ID != "default" && p.IsCanceled != true && p.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString()))
                    {
                        if (txtEmpNo.Tag != null && txtEmpNo.Tag.ToString() != oEmp.Employee_ID)
                            continue;
                        if (txtDivision.Tag != null && txtDivision.Tag.ToString() != oEmp.Division_ID)
                            continue;
                        if (txtDepartment.Tag != null && txtDepartment.Tag.ToString() != oEmp.Department_ID)
                            continue;
                        if (txtSection.Tag != null && txtSection.Tag.ToString() != oEmp.SectionID)
                            continue;
                        if (txtSubSection.Tag != null && txtSubSection.Tag.ToString() != oEmp.SubSectionID)
                            continue;
                        if (txtCategory.Tag != null && txtCategory.Tag.ToString() != oEmp.EmpCatagory1_ID)
                            continue;

                        dgr_Main.dt.Rows.Add(oEmp.Employee_ID, oEmp.EpfNo, (oEmp.Initails + " " + oEmp.SurName));
                    }


                    if (!chkAutoCalucation.IsChecked)
                    {
                        foreach (tbl_tasEmployeeLeave_entitled oEntileLeave in tbl_tasEmployeeLeave_entitled.SelectAllByCompany_ID_CompanyBranch_ID_HrYear_ID(clsSecurity.CompanyID, clsSecurity.BranchID, int.Parse(txtPayrollYear.Tag.ToString())))
                        {
                            DataRow dr_row = dgr_Main.dt.Select("Emp_No ='" + oEntileLeave.Employee_ID + "'").FirstOrDefault();
                            if (dr_row != null)
                            {
                                if (dgr_Main.dt.Columns.Contains(oEntileLeave.LeaveType_ID))
                                    dr_row[oEntileLeave.LeaveType_ID] = cls_Formater.FormatDecimal(oEntileLeave.Leaves_Entitled, 2);
                            }
                        }
                    }
                    else
                    {
                        DataTable dt_Staff = new DataTable();
                        dt_Staff.Columns.Add("Emp_No");
                        dt_Staff.Columns.Add("LeaveType_ID");
                        dt_Staff.Columns.Add("Std_NoOf_Days", typeof(int));
                        dt_Staff.Columns.Add("ConfirmedYear_ID", typeof(int));
                        dt_Staff.Columns.Add("Confirmed_Date", typeof(DateTime));
                        dt_Staff.Columns.Add("CurrentYear_ID", typeof(int));
                        dt_Staff.Columns.Add("CurrentYearStart_Date", typeof(DateTime));
                        dt_Staff.Columns.Add("CurrentYearEnd_Date", typeof(DateTime));
                        dt_Staff.Columns.Add("Entitle_Days", typeof(decimal));
                        dt_Staff.Merge(DBHandling.ExecQuery("sp_GetEntitleLeaveData '" + txtPayrollYear.Tag.ToString() + ".01.02' ").Tables[0]);

                        var vSelections_OldStaff = dt_Staff.Select("ConfirmedYear_ID < " + txtPayrollYear.Tag.ToString() + " AND ConfirmedYear_ID <> " + clsValidation.defaultDateTime.Year + "  AND ConfirmedYear_ID <> 0 ");
                        foreach (var vRow in vSelections_OldStaff)
                            vRow["Entitle_Days"] = vRow["Std_NoOf_Days"];
                        DataTable dt_Premenent_OldStaff = vSelections_OldStaff.Count() > 0 ? vSelections_OldStaff.CopyToDataTable() : new DataTable();

                        var vSelections_NewStaff = dt_Staff.Select("ConfirmedYear_ID = " + txtPayrollYear.Tag.ToString() + " AND ConfirmedYear_ID <> " + clsValidation.defaultDateTime.Year + "  AND ConfirmedYear_ID <> 0 AND Confirmed_Date <=  #" + DateTime.Now.Date.ToString(clsValidation.Format_Date) + "#");
                        foreach (var vRow in vSelections_NewStaff)
                        {
                            DateTime dtmConfirmedDate = DateTime.Parse(vRow["Confirmed_Date"].ToString());
                            DateTime dtmHR_YearEndDate = DateTime.Parse(vRow["CurrentYearEnd_Date"].ToString());
                            double dubRemainMonths = ((dtmHR_YearEndDate - dtmConfirmedDate).TotalDays) / 30;
                            double dubStd_NoOf_Days = double.Parse(vRow["Std_NoOf_Days"].ToString());
                            decimal dubEntitle_Days = (decimal)Math.Round(((dubStd_NoOf_Days / 12) * dubRemainMonths) * 4, MidpointRounding.ToEven) / 4;
                            vRow["Entitle_Days"] = dubEntitle_Days;
                        }
                        DataTable dt_Premenent_NewStaff = vSelections_NewStaff.Count() > 0 ? vSelections_NewStaff.CopyToDataTable() : new DataTable();

                        dt_Staff.Rows.Clear();

                        if (dt_Premenent_OldStaff.Rows.Count > 0)
                            dt_Staff.Merge(dt_Premenent_OldStaff);

                        if (dt_Premenent_NewStaff.Rows.Count > 0)
                            dt_Staff.Merge(dt_Premenent_NewStaff);

                        foreach (DataRow drRow in dgr_Main.dt.Rows)
                        {
                            string sEmp_No = drRow["Emp_No"].ToString();
                            var vSelections = dt_Staff.Select("Emp_No ='" + sEmp_No + "'");
                            foreach (var vSelection in vSelections)
                                drRow[vSelection["LeaveType_ID"].ToString()] = cls_Formater.FormatDecimal(decimal.Parse(vSelection["Entitle_Days"].ToString()), 2);

                        }
                    }

                    dgr_Main.RefreshGrid();
                }
                else
                {
                    SEACCMessageBox.Show("Please select the HR Year...", "");
                }
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
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            dgr_Main.dt.Rows.Clear();

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtPayrollYear, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmpNo, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDivision, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDepartment, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSubSection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCategory, true, false, false);

            txtPayrollYear.Tag = iCurrentHRYear_ID;
            txtEmpNo.Tag = null;
            txtDivision.Tag = null;
            txtDepartment.Tag = null;
            txtSection.Tag = null;
            txtSubSection.Tag = null;
            txtCategory.Tag = null;

            txtPayrollYear.Text = sCurrentYear_Name;
            txtEmpNo.Text = "<All Employees>";
            txtDivision.Text = "<All Divisions>";
            txtDepartment.Text = "<All Departments>";
            txtSection.Text = "<All Sections>";
            txtSubSection.Text = "<All Sub Sections>";
            txtCategory.Text = "<All Categories>";

            chkAutoCalucation.IsChecked = false;
        }
        #endregion

        #region Grid Event
        private void dgr_Main_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int iColumnIndex = e.Column.DisplayIndex;
            int irowID = dgr_Main.SelectedIndex;
            TextBox t;

            if (iColumnIndex >= 2)
            {
                t = e.EditingElement as TextBox;
                decimal dNum = 0m;

                try
                {
                    dNum = decimal.Parse(t.Text);
                }
                catch (Exception)
                {
                    SEACCMessageBox.Show("Oops..!", "Please enter numeric value", MessageBoxButton.OK);
                }
                t.Text = cls_Formater.FormatDecimal(dNum, 2);
            }

        }
        #endregion

        #region Search Events
        private void txtPayrollYear_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.HRYear);
            if (RowDataSearch.DialogResult == true)
            {
                txtPayrollYear.Text = lstResult[1];
                txtPayrollYear.Tag = lstResult[0];
            }
        }

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

                    txtDivision.Tag = oEmployee.Division_ID;
                    txtDivision.Text = oEmployee.DivisionName;
                    txtDivision.IsEnabled = false;

                    txtDepartment.Tag = oEmployee.Department_ID;
                    txtDepartment.Text = oEmployee.DepartmentName;
                    txtDepartment.IsEnabled = false;

                    txtSection.Tag = oEmployee.SectionID;
                    txtSection.Text = oEmployee.Section_Name;
                    txtSection.IsEnabled = false;

                    txtSubSection.Tag = oEmployee.SubSectionID;
                    txtSubSection.Text = oEmployee.SubSectionName;
                    txtSubSection.IsEnabled = false;

                    txtCategory.Tag = oEmployee.EmpCatagory1_ID;
                    txtCategory.Text = oEmployee.EmpCatagory1_Name;
                    txtCategory.IsEnabled = false;
                }
            }
        }

        private void txtDivision_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Division);
            if (RowDataSearch.DialogResult == true)
            {
                txtDivision.Text = lstResult[1];
                txtDivision.Tag = lstResult[0];
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
            }
        }

        private void txtSection_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Sections);
            if (RowDataSearch.DialogResult == true)
            {
                txtSection.Text = lstResult[1];
                txtSection.Tag = lstResult[0];
            }
        }

        private void txtSubSection_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.SubSections);
            if (RowDataSearch.DialogResult == true)
            {
                txtSubSection.Text = lstResult[1];
                txtSubSection.Tag = lstResult[0];
            }
        }

        private void txtCategory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.EmployeeCategory);
            if (RowDataSearch.DialogResult == true)
            {
                txtSubSection.Text = lstResult[1];
                txtSubSection.Tag = lstResult[0];
            }
        }
        #endregion
    }
}

