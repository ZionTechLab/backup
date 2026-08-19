using Digiteq_Logic;
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
using DataTire;
using SEACC_WPFControls;
using System.Data;

namespace Digiteq
{
    public partial class UC_EmpShiftAdjustment : UserControl
    {
        #region Class Variable
        DateTime dtmFromDate = DateTime.Now;
        DateTime dtmToDate = DateTime.Now;
        string infiniteToDate_Status = "0";

        string lastShiftName = "";
        string lastShiftID = "";
        //int affectedRowCount = 0;
        #endregion

        #region Form Load
        public UC_EmpShiftAdjustment()
        {
            #region Initialize User Control
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Employee_Shift_Adjustment;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table for Individual Shift Adj
            dgr_Main.dt.Columns.Add("attendenceDate");
            dgr_Main.dt.Columns.Add("employee_ID");
            dgr_Main.dt.Columns.Add("EmpName");
            dgr_Main.dt.Columns.Add("shift_ID");
            dgr_Main.dt.Columns.Add("o_shift_ID");
            dgr_Main.dt.Columns.Add("ShiftName");
            dgr_Main.dt.Columns.Add("Shift_StartTime");
            dgr_Main.dt.Columns.Add("Shift_EndTime");
            #endregion

            #region Initialize Data Table for Group Shift Adj
            dgr_Main_group.dt.Columns.Add("employee_ID");
            dgr_Main_group.dt.Columns.Add("EmpName");
            dgr_Main_group.dt.Columns.Add("attendenceDateFrom");
            dgr_Main_group.dt.Columns.Add("attendenceDateTo");
            dgr_Main_group.dt.Columns.Add("Lastshift_ID");
            dgr_Main_group.dt.Columns.Add("LastShift");
            dgr_Main_group.dt.Columns.Add("NewShift_ID");
            dgr_Main_group.dt.Columns.Add("NewShift");
            dgr_Main_group.dt.Columns.Add("Days#", typeof(int));
            #endregion

            #region Initialize Action Buttons
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Print.Click += btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize Data Grid for Individual
            dgr_Main.Add_DatagridColoumn("Date", "attendenceDate", 75);
            dgr_Main.Add_DatagridColoumn("Emp No.", "employee_ID", 55);
            dgr_Main.Add_DatagridColoumn("Name", "EmpName", 120);
            dgr_Main.Add_DatagridColoumn("shift_ID", "shift_ID", 60, false);
            dgr_Main.Add_DatagridColoumn("o_shift_ID", "o_shift_ID", 60,false);
            dgr_Main.Add_DatagridColoumn("Shift", "ShiftName", 130);
            dgr_Main.Add_DatagridColoumn("Shift Start", "Shift_StartTime", 100);
            dgr_Main.Add_DatagridColoumn("Shift End", "Shift_EndTime", 100);
            #endregion

            #region Initialize Data Grid for Group
            dgr_Main_group.Add_DatagridColoumn("Emp No.", "employee_ID", 55);
            dgr_Main_group.Add_DatagridColoumn("Name", "EmpName", 120);
            dgr_Main_group.Add_DatagridColoumn("From Date", "attendenceDateFrom", 75);
            dgr_Main_group.Add_DatagridColoumn("To Date", "attendenceDateTo", 75);
            dgr_Main_group.Add_DatagridColoumn("Lastshift_ID", "Lastshift_ID", 60, false);
            dgr_Main_group.Add_DatagridColoumn("Last Shift", "LastShift", 130);
            dgr_Main_group.Add_DatagridColoumn("NewShift_ID", "NewShift_ID", 60 , false);
            dgr_Main_group.Add_DatagridColoumn("New Shift", "NewShift", 130);
            dgr_Main_group.Add_DatagridColoumn("Days#", "Days#", 55 , false);
            #endregion

            ClearFields();
        }
        #endregion

        #region Action Button
        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        void btn_Print_Click(object sender, RoutedEventArgs e)
        {

        }

        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            #region Save Individual (dgr_Main)
            if (dgr_Main.Visibility == Visibility.Visible)
            {
                try
                {
                    //DateTime O_dtmAttendanceDate = clsConfig.defaultDateTime;
                    //string O_sShift_ID = "";

                    //foreach (DataRow row in dgr_Main.dt.Rows)
                    //{
                    //    bool bIsInsertable = false;

                    //    #region get values from table
                    //    DateTime dtmAttendanceDate = clsValidation.Validate_DateTime(row["attendenceDate"].ToString());
                    //    string sEmployee_ID = row["employee_ID"].ToString();
                    //    string sShift_ID = row["shift_ID"].ToString();
                    //    DateTime dtmShiftStartTime = clsValidation.Validate_DateTime(row["Shift_StartTime"].ToString());
                    //    DateTime dtmShiftEndTime = clsValidation.Validate_DateTime(row["Shift_EndTime"].ToString());
                    //    #endregion

                    //    if (dtmAttendanceDate.Date == dtpFromDate.GetDateTime().Date)
                    //        bIsInsertable = true;

                    //    if (O_sShift_ID != sShift_ID)
                    //        bIsInsertable = true;

                    //    if (bIsInsertable)
                    //    {
                    //        //   tbl_tasMasEmployeeShift oOld in tbl_tasMasEmployeeShift.sel
                    //        foreach (tbl_tasMasEmployeeShift oOld in tbl_tasMasEmployeeShift.SelectAllByEmployee_ID_EffectiveDate(sEmployee_ID, dtmAttendanceDate))
                    //        {
                    //            oOld.IsCanceled = true;
                    //            // oOld.EmployeeShift_ID = oOld.EmployeeShift_ID;
                    //            oOld.Update();
                    //        }
                    //        tbl_tasMasEmployeeShift oEmpShift = new tbl_tasMasEmployeeShift(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployee_ID, sShift_ID, dtmAttendanceDate,
                    //                                 false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                    //        oEmpShift.Insert();

                    //    }
                    //    O_sShift_ID = sShift_ID;
                    //}
                    bool insertable = false;
                    foreach (DataRow row in dgr_Main.dt.Rows)
                    {
                        #region get values from table
                        DateTime dtmAttendanceDate = clsValidation.Validate_DateTime(row["attendenceDate"].ToString());
                        string sEmployee_ID = row["employee_ID"].ToString();

                        string sShift_ID = row["shift_ID"].ToString();
                        string oShift_ID = row["o_shift_ID"].ToString();
                        #endregion

                        if (sShift_ID == oShift_ID)
                        {
                            if (insertable)
                            {
                                foreach (tbl_tasMasEmployeeShift oOld in tbl_tasMasEmployeeShift.SelectAllByEmployee_ID_EffectiveDate(sEmployee_ID, dtmAttendanceDate))
                                {
                                    if (oShift_ID == oOld.Shift_ID.ToString())
                                    {
                                        oOld.IsCanceled = true;
                                        oOld.Update();
                                    }
                                }
                                tbl_tasMasEmployeeShift oEmpShift = new tbl_tasMasEmployeeShift(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployee_ID, sShift_ID, dtmAttendanceDate,
                                                         false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                                oEmpShift.Insert();
                                insertable = false;
                            }
                        }

                        if (sShift_ID != oShift_ID)
                        {
                            if (infiniteToDate_Status == "1")
                            {
                                insertable = false;
                                //DBHandling.ExecQuery("UPDATE [tbl_tasMasEmployeeShift] SET [isCanceled] = '1' WHERE [effectiveFrom_Date] >='" + dtmAttendanceDate + "'");
                                DBHandling.ExecQuery("UPDATE [tbl_tasMasEmployeeShift] SET [isCanceled] = '1' WHERE [effectiveFrom_Date] >='" + dtmAttendanceDate + "' AND [employee_ID] = '" +sEmployee_ID+ "'");
                            }
                            else
                                insertable = true;

                            foreach (tbl_tasMasEmployeeShift oOld in tbl_tasMasEmployeeShift.SelectAllByEmployee_ID_EffectiveDate(sEmployee_ID, dtmAttendanceDate))
                            {
                                if (oShift_ID == oOld.Shift_ID.ToString())
                                {
                                    oOld.IsCanceled = true;
                                    oOld.Update();
                                }
                            }
                            tbl_tasMasEmployeeShift oEmpShift = new tbl_tasMasEmployeeShift(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployee_ID, sShift_ID, dtmAttendanceDate,
                                                     false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                            oEmpShift.Insert();
                        }

                    }
                    SEACCMessageBox.Show("Attendance Saved succesfully...!", "");
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
            } 
            #endregion

            #region Save Group (dgr_Main_group)
            if (dgr_Main_group.Visibility == Visibility.Visible)
            {
                try
                {
                    String msg = "You haven't select New Shift...";

                    foreach (DataRow row in dgr_Main_group.dt.Rows)
                    {
                        #region get values from table
                        DateTime dtmAttendanceDateFrom = clsValidation.Validate_DateTime(row["attendenceDateFrom"].ToString());
                        DateTime dtmAttendanceDateTo = clsValidation.Validate_DateTime(row["attendenceDateTo"].ToString());
                        string sEmployee_ID = row["employee_ID"].ToString();
                        string sNewShift_ID = row["NewShift_ID"].ToString();
                        string oLastShift_ID = row["Lastshift_ID"].ToString();
                        #endregion

                        if (sNewShift_ID != null && sNewShift_ID != "")
                        {

                            DBHandling.ExecQuery("UPDATE [dbo].[tbl_tasMasEmployeeShift] SET [isCanceled] = '1' WHERE [effectiveFrom_Date] >='" + dtmAttendanceDateFrom + "' AND [effectiveFrom_Date] <= '" + dtmAttendanceDateTo + "' AND [employee_ID] = '" + sEmployee_ID + "'");

                            //Insert a recored for from date
                            tbl_tasMasEmployeeShift oEmpShift = new tbl_tasMasEmployeeShift(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployee_ID, sNewShift_ID, dtmAttendanceDateFrom,
                                                             false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                            oEmpShift.Insert();


                            //Insert a record for to date
                            tbl_tasMasEmployeeShift nEmpShift = new tbl_tasMasEmployeeShift(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployee_ID, oLastShift_ID, dtmAttendanceDateTo.AddDays(1),
                                                             false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                            nEmpShift.Insert();

                            msg = "Attendance Saved succesfully...!";
                        }
                    }
                    SEACCMessageBox.Show(msg, "");
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
            } 
            #endregion
        }

        private void btn_load_Click(object sender, RoutedEventArgs e)
        {
            DateTime dtmFromDate = dtpFromDate.GetDateTime();
            DateTime dtmToDate = dtpToDate.GetDateTime();

            List<tbl_genMasEmployee> oEmployees = new List<tbl_genMasEmployee>();

            #region Filters
            #region Filter - Employee
            if (txtEmpNo.Tag != null)
                oEmployees = tbl_genMasEmployee.SelectAll().Where(p => p.Employee_ID == txtEmpNo.Tag.ToString() && p.Employee_ID != "default" ).ToList();
            else
                oEmployees = tbl_genMasEmployee.SelectAll().Where(p => p.Employee_ID != "default").ToList();

            #endregion

            #region Filter - Shift

            //if (txtShift.Tag != null)
            //    oEmployees = oEmployees.Where(p => p.Shift_ID == txtShift.Tag.ToString()).ToList();

            #endregion

            #region Filter - Department

            if (txtDepartment.Tag != null)
                oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();

            #endregion

            #region Filter-Section

            if (txtSection.Tag != null)
                oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();

            #endregion

            #region Filter-Subsection

            if (txtSubSection.Tag != null)
                oEmployees = oEmployees.Where(p => p.SubSectionID == txtSubSection.Tag.ToString()).ToList();

            #endregion

            #region Filter-Category

            if (txtCategory.Tag != null)
                oEmployees = oEmployees.Where(p => p.EmpCatagory1_ID == txtCategory.Tag.ToString()).ToList();

            #endregion
            #endregion

            dgr_Main.SetFilterValue("Emp No.", "employee_ID", null);
            dgr_Main.dt.Clear();
            dgr_Main_group.dt.Clear();
            string a = ((int)EmployeeStatus.Resigned).ToString();
            foreach (tbl_genMasEmployee oEmployee in oEmployees.Where(p=>p.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString() ))
            {
                for (DateTime dDate = dtmFromDate.Date; dDate.Date <= dtmToDate.Date; dDate = dDate.AddDays(1))
                {
                    string sShiftId = "";
                    string sShiftName = "";
                    DateTime dtmShiftStartTime = clsConfig.defaultDateTime;
                    int iShiftEndTime = 0;

                    DataTable dtResult_Table = DBHandling.ExecQuery("SELECT TOP 1 ES.employee_ID, ES.effectiveFrom_Date, ES.shift_ID, S.shift_Name, S.shiftStartTime, S.shiftMinutes FROM tbl_tasMasEmployeeShift AS ES LEFT OUTER JOIN tbl_tasShiftMaster AS S ON ES.shift_ID = S.shift_ID  where ES.effectiveFrom_Date<='" + dDate.Date.ToString("yyyy-MM-dd") + "' AND ES.employee_ID = '" + oEmployee.Employee_ID + "' AND ES.isCanceled = 0 order by ES.effectiveFrom_Date DESC").Tables[0];
                    if (dtResult_Table != null && dtResult_Table.Rows.Count > 0)
                    {
                        lastShiftID = sShiftId = dtResult_Table.Rows[0]["shift_ID"].ToString();
                        if (sShiftId != "")
                        {
                            lastShiftName = sShiftName = dtResult_Table.Rows[0]["shift_Name"].ToString();
                            dtmShiftStartTime = clsValidation.Validate_DateTime(dtResult_Table.Rows[0]["shiftStartTime"].ToString());
                            iShiftEndTime = int.Parse(dtResult_Table.Rows[0]["shiftMinutes"].ToString());
                        }
                    }
                    dgr_Main.dt.Rows.Add(dDate.ToString(clsConfig.Format_Date), oEmployee.Employee_ID, oEmployee.Initails + " " + oEmployee.SurName, sShiftId, sShiftId, sShiftName, dtmShiftStartTime.ToString(clsConfig.Format_Time), dtmShiftStartTime.AddMinutes(iShiftEndTime).ToString(clsConfig.Format_Time));
                }
            }
            dgr_Main_group.dt.Merge(GroupBy("employee_ID", "attendenceDate", dgr_Main.dt));
            dgr_Main.RefreshGrid();
            dgr_Main_group.RefreshGrid();
        }

        private void btn_MainButtons(object sender, RoutedEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            btnIndividual.Foreground = (Brush)bc.ConvertFrom("Silver");
            btnGroup.Foreground = (Brush)bc.ConvertFrom("Silver");
            btnDivDept.Foreground = (Brush)bc.ConvertFrom("Silver"); 

            SEACC_Button btn = sender as SEACC_Button;
            btn.Foreground = (Brush)bc.ConvertFrom("Black");

            dgr_Main.Visibility = Visibility.Collapsed;
            dgr_Main_group.Visibility = Visibility.Collapsed;
            txtEmpNo.IsEnabled = false;
            txtShiftToBeAssign.Visibility = Visibility.Collapsed;

            if (btn.Name == "btnIndividual")
            {
                dgr_Main.Visibility = Visibility.Visible;
                txtEmpNo.IsEnabled = true;
            }
            else if (btn.Name == "btnGroup")
            {
                dgr_Main_group.Visibility = Visibility.Visible;
                txtShiftToBeAssign.Visibility = Visibility.Visible;
            }
            else if (btn.Name == "btnDivDept")
            {
                txtEmpNo.IsEnabled = true;
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            dgr_Main.dt.Clear();
            dgr_Main_group.dt.Clear();
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmpNo, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtShiftToBeAssign, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDepartment, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSubSection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCategory, true, false, false);
            //  clsCommon.SetEnableDisable_LabelDateSelector(dtpFromDate, true);
            // clsCommon.SetEnableDisable_LabelDateSelector(dtpToDate, true);

            txtEmpNo.Tag = null;
            txtShiftToBeAssign.Tag = null;
            txtDepartment.Tag = null;
            txtSection.Tag = null;
            txtSubSection.Tag = null;
            txtCategory.Tag = null;

            txtEmpNo.Text = "<All Employees>";
            txtDepartment.Text = "<All Departments>";
            txtSection.Text = "<All Sections>";
            txtSubSection.Text = "<All Sub Sections>";
            txtCategory.Text = "<All Categories>";
            txtShiftToBeAssign.Text = "";

            dtpFromDate.SetTime(DateTime.Now);
            dtpToDate.SetTime(DateTime.Now);

            if (dgr_Main_group.Visibility == Visibility.Visible)
                txtEmpNo.IsEnabled = false;
            if (dgr_Main.Visibility == Visibility.Visible)
                txtEmpNo.IsEnabled = true;
            
            txtDepartment.IsEnabled = true;
            txtShiftToBeAssign.IsEnabled = true;
            txtSection.IsEnabled = true;
            txtSubSection.IsEnabled = true;
            txtCategory.IsEnabled = true;

            EmployeeViewer.ClearFields();
        }
        #endregion

        #region Grid Events
        private void dgr_Main_DG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var vDG_Cell = dgr_Main.GetCurrentCell();
                int irowID = dgr_Main.SelectedIndex;

                
                #region Shift
                if (vDG_Cell.Column.SortMemberPath == "ShiftName")
                {
                    string sEmployeeID = dgr_Main.dt.Rows[irowID]["employee_ID"].ToString();
                    dtmFromDate = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["attendenceDate"].ToString());
                    dtmToDate = dtmFromDate;
                    if (sEmployeeID != "")
                    {
                        frmSearch_ShiftAdv frmSearch = new frmSearch_ShiftAdv();
                        frmSearch.Show(dtmFromDate);
                        if (frmSearch.DialogResult == true)
                        {
                            dtmToDate = clsValidation.Validate_DateTime(frmSearch.lstReturn[4].ToString());
                            int i1 = 0;
                            for (DateTime i = dtmFromDate; i <= dtmToDate; i = i.AddDays(1))
                            {
                                dgr_Main.dt.Rows[irowID + i1]["shift_ID"] = frmSearch.lstReturn[0].ToString();
                                dgr_Main.dt.Rows[irowID + i1]["ShiftName"] = frmSearch.lstReturn[1].ToString();
                                dgr_Main.dt.Rows[irowID + i1]["Shift_StartTime"] = frmSearch.lstReturn[2].ToString();
                                dgr_Main.dt.Rows[irowID + i1]["Shift_EndTime"] = frmSearch.lstReturn[3].ToString();
                                i1++;
                                // affectedRowCount++;
                            }
                            infiniteToDate_Status = frmSearch.lstReturn[5].ToString();
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgr_Main_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (dgr_Main.dt.Rows.Count != 0)
                {
                    int irowID = dgr_Main.SelectedIndex;
                    var vDG_Cell = dgr_Main.GetCurrentCell();
                    EmployeeViewer.ClearFields();
                    string sEmployeeid = dgr_Main.dt.Rows[irowID]["employee_ID"].ToString();
                    EmployeeViewer.setEmployeeDetail(sEmployeeid);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void dgr_Main_group_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (dgr_Main_group.dt.Rows.Count != 0)
                {
                    int irowID = dgr_Main_group.SelectedIndex;
                    var vDG_Cell = dgr_Main_group.GetCurrentCell();
                    EmployeeViewer.ClearFields();
                    string sEmployeeid = dgr_Main_group.dt.Rows[irowID]["employee_ID"].ToString();
                    EmployeeViewer.setEmployeeDetail(sEmployeeid);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void dgr_Main_group_DG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var vDG_Cell = dgr_Main_group.GetCurrentCell();
                int irowID = dgr_Main_group.SelectedIndex;
                string sEmployeeid = dgr_Main_group.dt.Rows[irowID]["employee_ID"].ToString();

                if (vDG_Cell.Column.SortMemberPath == "employee_ID")
                {
                    dgr_Main.SetFilterValue("Emp No.", "employee_ID", sEmployeeid);
                    dgr_Main_group.Visibility = Visibility.Collapsed;
                    dgr_Main.Visibility = Visibility.Visible;
                    BrushConverter bc = new BrushConverter();
                    btnGroup.Foreground = (Brush)bc.ConvertFrom("Silver");
                    btnIndividual.Foreground = (Brush)bc.ConvertFrom("Black");
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
                string GridID = ((System.Data.DataRowView)(e.Row.DataContext)).Row.ItemArray[0].ToString();
                if (DateTime.Parse(GridID).DayOfWeek == DayOfWeek.Saturday)
                {
                    e.Row.Background = (Brush)bc.ConvertFrom("#f6e8e9");
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#000000");
                }
                if (DateTime.Parse(GridID).DayOfWeek == DayOfWeek.Sunday)
                {
                    e.Row.Background = (Brush)bc.ConvertFrom("#edd1d4");
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#000000");
                }
            }
            catch
            {
            }
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

                    txtDepartment.Tag = oEmployee.Department_ID;
                    txtDepartment.Text = oEmployee.DepartmentName;
                    txtDepartment.IsEnabled = false;

                    txtShiftToBeAssign.Tag = oEmployee.Shift_ID;
                    txtShiftToBeAssign.Text = oEmployee.Shift_Name;
                    txtShiftToBeAssign.IsEnabled = false;

                    txtSection.Tag = oEmployee.SectionID;
                    txtSection.Text = oEmployee.Section_Name;
                    txtSection.IsEnabled = false;

                    txtSubSection.Tag = oEmployee.SubSectionID;
                    txtSubSection.Text = oEmployee.SubSectionName;
                    txtSubSection.IsEnabled = false;

                    txtCategory.Tag = oEmployee.EmpCatagory1_ID;
                    txtCategory.Text = oEmployee.EmpCatagory1_Name;
                    txtCategory.IsEnabled = false;

                    EmployeeViewer.setEmployeeDetail(oEmployee.Employee_ID);
                }
            }
        }

        private void txtShift_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Shift);
            if (RowDataSearch.DialogResult == true)
            {
                txtShiftToBeAssign.Text = lstResult[1];
                txtShiftToBeAssign.Tag = lstResult[0];
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
                txtCategory.Text = lstResult[1];
                txtCategory.Tag = lstResult[0];
            }
        }
        #endregion

        public DataTable GroupBy(string i_sGroupByColumn, string i_sAggregateColumn, DataTable i_dSourceTable)
        {
            DataView dv = new DataView(i_dSourceTable);

            //getting distinct values for group column
            DataTable dtGroup = dv.ToTable(true, new string[] { i_sGroupByColumn, "EmpName" });

            //adding column for the row count
            dtGroup.Columns.Add("attendenceDateFrom");
            dtGroup.Columns.Add("attendenceDateTo");
            dtGroup.Columns.Add("Lastshift_ID");
            dtGroup.Columns.Add("LastShift");
            dtGroup.Columns.Add("NewShift_ID");
            dtGroup.Columns.Add("NewShift");
            dtGroup.Columns.Add("Days#", typeof(int));

            //looping thru distinct values for the group, counting
            foreach (DataRow dr in dtGroup.Rows)
            {
                dr["attendenceDateFrom"] = dtpFromDate.GetDateTime().ToShortDateString();
                dr["attendenceDateTo"] = dtpToDate.GetDateTime().ToShortDateString();
                dr["Lastshift_ID"] = lastShiftID;
                dr["LastShift"] = lastShiftName;
                if (txtShiftToBeAssign.Tag != null)
                {
                    dr["NewShift_ID"] = txtShiftToBeAssign.Tag.ToString();
                    dr["NewShift"] = txtShiftToBeAssign.Text;
                }
                dr["Days#"] = i_dSourceTable.Compute("Count(" + i_sAggregateColumn + ")", i_sGroupByColumn + " = '" + dr[i_sGroupByColumn] + "'");
            }

            //returning grouped/counted result
            return dtGroup;
        }

    }
}