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
using Digiteq_Logic;
using SEACC_WPFControls;
using System.Data;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_GatePass.xaml
    /// </summary>
    public partial class UC_GatePass : UserControl
    {
        #region Class variable
        DataTable dtMain = new DataTable();
        DateTime currentHRYear_StartDate = DateTime.Now, currentHRYear_EndDate = DateTime.Now;
        int iCurrentHRYear_ID = 0;
        #endregion

        #region Form Load
        public UC_GatePass()
        {
            #region Initialize User Control
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.GatePass_Official_Leave;
            SEACC_Form.Initialize();

            tbl_hrPeriod_Year oYear = tbl_hrPeriod_Year.SelectAll().Where(r => r.Year_startDate.Date <= DateTime.Now.Date && r.Year_endDate >= DateTime.Now.Date).FirstOrDefault();
            if (oYear != null)
            {
                iCurrentHRYear_ID = oYear.Year_ID;
                currentHRYear_StartDate = oYear.Year_startDate.Date;
                currentHRYear_EndDate = oYear.Year_endDate.Date;
            }
            #endregion

            // grd_Gatepass.dt.Columns
            #region Initialize Data Table
            dtMain.Columns.Add("GPNO");
            dtMain.Columns.Add("Status");
            dtMain.Columns.Add("EmpNO");
            dtMain.Columns.Add("Name");
            dtMain.Columns.Add("Division");
            dtMain.Columns.Add("Department");
            dtMain.Columns.Add("Section");
            dtMain.Columns.Add("SubSection");
            dtMain.Columns.Add("DateTime");
            dtMain.Columns.Add("LeaveHours");
            dtMain.Columns.Add("Reason");
            dtMain.Columns.Add("BataPayable");
            dtMain.Columns.Add("Amount");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Print.Click += btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            ClearFields();
            EmployeeLogin();
        }
        #endregion

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(650);
        }
        #endregion

        #region Action Buttons
        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtGatePassNo.Tag.ToString().Length > 0 && txtGatePassNo.Text != "<Auto Generate>")
                    {
                        if (SEACC_Form.CheckPermisshion_ToCancel())
                        {
                            Cursor = Cursors.Wait;
                            tbl_tasTxGatePass detail = tbl_tasTxGatePass.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtGatePassNo.Tag.ToString());
                            if (detail != null && detail.GatePass_ID != "default")
                            {
                                if (!detail.IsCanceled)
                                {
                                    if (detail.ApprovalStatus_Manager != 1)
                                    {
                                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                                        if (bMessegeBoxResult)
                                        {
                                            detail.IsCanceled = true;
                                            detail.Date_Canceled = clsSecurity.getServerDateTime();
                                            detail.TerminalID_Canceled = clsSecurity.TerminalID;
                                            detail.UserID_Canceled = clsSecurity.UserIDLoged;
                                            detail.Update();

                                            clsAlerts_Email.CreateEmail_GatePass(enum_Alerts.GatePass_Canceled, txtGatePassNo.Tag.ToString(), "");
                                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                            ClearFields();
                                            RefreshGrid();
                                        }
                                    }
                                    else
                                        SEACCMessageBox.Show(MessegeBoxType.CannotCancel_AlreadyApproved);
                                }
                                else
                                    SEACCMessageBox.Show(MessegeBoxType.CannotCancel_AlreadyCanceled);
                            }
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
                Cursor = Cursors.Arrow;
            }
        }

        void btn_Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtGatePassNo.Tag.ToString().Length > 0 && txtGatePassNo.Text != "<Auto Generate>")
                {
                    if (SEACC_Form.CheckPermisshion_ToCancel())
                    {

                    }
                }
                //tbl_securityReportMaster oReports = tbl_securityReportMaster.Select(((int)enum_ReportName.GatePassList));
                // if (oReports != null)
                {
                    string sFilter = "";

                    DataSets.dts_TAS glb_dts_TAS = new DataSets.dts_TAS();

                    //Company table filling
                    //  glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReports.DisplayName, oReports.DisplayName2, "", clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);

                    DataSets.dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();

                    //Bank table filling
                    foreach (tbl_tasTxGatePass detail in tbl_tasTxGatePass.SelectAll().Where(p => p.IsCanceled == false && p.GatePass_ID == txtGatePassNo.Text))
                    {
                        glb_dts_TAS.dt_tas_GatePass.Adddt_tas_GatePassRow(detail.GatePass_ID, detail.Employee_ID, clsRef_Name.get_EmployeeName(detail.Employee_ID), detail.GatePass_DateTime.ToString(), detail.Leave_Hours, detail.Reason, detail.Date_Checked_Supevisor.ToString(), detail.Date_Checked_Manager.ToString() , detail.GatePass_DateTime.Date);
                    }
                    frm_ReportViwer CRViwer = new frm_ReportViwer();
                    //   CRViwer.Print(oReports.ReportPath, glb_dts_TAS, glb_dts_ExportReport.dt_rptParameter);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    bool bBataPayable = false;
                    if (chk_BataPayable.IsChecked == true)
                    {
                        bBataPayable = true;
                    }
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {
                            if (ChecckValidity_ConflictFields())
                            {
                                tbl_tasTxGatePass oldRecord = tbl_tasTxGatePass.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtGatePassNo.Text.Trim());
                                if (oldRecord != null)
                                {
                                    tbl_tasTxGatePass detail = new tbl_tasTxGatePass(clsSecurity.CompanyID, clsSecurity.BranchID, txtGatePassNo.Text, txtEmployeeNo.Tag.ToString(), Vw_EmployeeDemography.Employee.Division_ID, Vw_EmployeeDemography.Employee.Department_ID, Vw_EmployeeDemography.Employee.SectionID, Vw_EmployeeDemography.Employee.SubSectionID, int.Parse(clsCommon.GetHRyear_ID(dtp_GatePassDateTime.GetDateTime())), dtp_GatePassDateTime.GetDateTime(), ts_LeaveHours.GetMinutes(), txtReason.Text, bBataPayable, Decimal.Parse(txtrate.Text), oldRecord.IsCanceled, oldRecord.ApprovalStatus_Supevosior, oldRecord.ApprovalStatus_Manager, oldRecord.UserID_Created, clsSecurity.UserIDLoged, oldRecord.UserID_Canceled, oldRecord.UserID_Supevisor, oldRecord.UserID_Manager, clsSecurity.UserGroupIDLoged, oldRecord.TerminalID_Created, clsSecurity.TerminalID, oldRecord.TerminalID_Canceled, oldRecord.TerminalID_Supevisor, oldRecord.TerminalID_Manager, clsSecurity.TerminalID, oldRecord.Date_Created, clsSecurity.getServerDateTime(), oldRecord.Date_Canceled, oldRecord.Date_Checked_Supevisor, oldRecord.Date_Checked_Manager, clsSecurity.getServerDateTime());
                                    detail.Update();
                                    clsAlerts_Email.CreateEmail_GatePass(enum_Alerts.GatePass_updated, txtGatePassNo.Text, "");
                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                }
                            }
                        }
                    }
                    #endregion

                    #region Save
                    else
                    {
                        if (SEACC_Form.isAutoGenaratedCode)
                            txtGatePassNo.Text = SEACC_Form.getAutoGeneratedCode();

                        tbl_tasTxGatePass detail = new tbl_tasTxGatePass(clsSecurity.CompanyID, clsSecurity.BranchID, txtGatePassNo.Text, txtEmployeeNo.Tag.ToString(), Vw_EmployeeDemography.Employee.Division_ID, Vw_EmployeeDemography.Employee.Department_ID, Vw_EmployeeDemography.Employee.SectionID, Vw_EmployeeDemography.Employee.SubSectionID, int.Parse(clsCommon.GetHRyear_ID(dtp_GatePassDateTime.GetDateTime())), dtp_GatePassDateTime.GetDateTime(), ts_LeaveHours.GetMinutes(), txtReason.Text, bBataPayable, decimal.Parse(txtrate.Text), false, 0, 0, clsSecurity.UserIDLoged, "Default", "Default", Wusr_Checked.GetEmpID(), Wusr_Approved.GetEmpID(), clsSecurity.UserIDLoged, clsSecurity.TerminalID, "Default", "Default", "Default", "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                        detail.Insert();
                        clsAlerts_Email.CreateEmail_GatePass(enum_Alerts.GatePass_Applied, txtGatePassNo.Text, "");
                        SEACCMessageBox.Show("Gate Pass applied successfully", "", MessageBoxButton.OK);
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }

                finally
                {
                    RefreshGrid();
                    ClearFields();
                }
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtGatePassNo, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmployeeNo, true, false, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtp_GatePassDateTime, true, false);
            cls_Formater.SetEnableDisable_LableTimeSpan(ts_LeaveHours, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtEmployeeNo, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtReason, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtrate, true, true, true);

            txtGatePassNo.Text = "";
            txtGatePassNo.Tag = null;
            txtEmployeeNo.Text = "";
            txtEmployeeNo.Tag = null;
            dtp_GatePassDateTime.SetTime(DateTime.Now);
            ts_LeaveHours.setMinutes(0);
            txtReason.Text = "";
            txtrate.Text = "0.00";
            txtrate.IsEnabled = false;
            chk_BataPayable.IsChecked = false;

            #region Set Auto Genarate Key fields
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtGatePassNo.setReadOnlyStatus(true);
                txtGatePassNo.Text = "<Auto Generate>";
            }
            else
                txtGatePassNo.setReadOnlyStatus(false);
            #endregion

            this.SEACC_Form.btn_Save.Visibility = Visibility.Visible;
            this.SEACC_Form.btn_Cancel.Visibility = Visibility.Visible;

            Vw_EmployeeDemography.ClearFields();
            EmployeeLogin();

            if (clsSecurity.UserGroupIDLoged == "6")
                txtEmployeeNo.Visibility = Visibility.Collapsed;
            else
                txtEmployeeNo.Visibility = Visibility.Visible;
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dtMain.Clear();
                tbl_securityUserMaster oUser = tbl_securityUserMaster.Select(clsSecurity.UserIDLoged);
                if (oUser != null)
                {
                    DateTime HRYearStartDate = currentHRYear_StartDate.Date;
                    DateTime HRYearEndData = currentHRYear_EndDate.Date;

                    string empID = oUser.EmployeeID;
                    if (oUser.Group_ID != "6")
                    {
                        foreach (tbl_tasTxGatePass detail in tbl_tasTxGatePass.SelectAll().Where(p => p.IsCanceled == false && p.GatePass_ID != "default" && p.Employee_ID == txtEmployeeNo.Tag.ToString() && p.GatePass_DateTime.Date >= HRYearStartDate && p.GatePass_DateTime.Date <= HRYearEndData).OrderByDescending(o => o.GatePass_DateTime))
                        {
                            string iStatus;
                            if (detail.ApprovalStatus_Manager == 1 && detail.ApprovalStatus_Supevosior == 1)
                                iStatus = "Approved";

                            else
                                iStatus = "Pending";
                            string sBataStatus = "No";
                            if (detail.IsBataPayable == true)
                                sBataStatus = "Yes";


                            dtMain.Rows.Add(detail.GatePass_ID, iStatus, detail.Employee_ID, clsRef_Name.get_EmployeeAliasName(detail.Employee_ID), clsRef_Name.get_Division_Name(detail.Division_ID), clsRef_Name.get_Department_Name(detail.Department_ID), clsRef_Name.get_Section_Name(detail.Section_ID), clsRef_Name.get_SubSection_Name(detail.SubSection_ID), detail.GatePass_DateTime.ToString(clsConfig.Format_Date), (detail.Leave_Hours / 60).ToString("00.00"), detail.Reason, sBataStatus, detail.BataAmount);
                        }
                    }
                    else
                    {
                        foreach (tbl_tasTxGatePass detail in tbl_tasTxGatePass.SelectAll().Where(p => p.IsCanceled == false && p.GatePass_ID != "default" && p.Employee_ID == empID && p.GatePass_DateTime.Date >= currentHRYear_StartDate.Date && p.GatePass_DateTime.Date <= currentHRYear_EndDate.Date))
                        {
                            string iStatus;
                            if (detail.ApprovalStatus_Manager == 1 && detail.ApprovalStatus_Supevosior == 1)
                                iStatus = "Approved";

                            else
                                iStatus = "Pending";
                            string sBataStatus = "No";
                            if (detail.IsBataPayable == true)
                                sBataStatus = "Yes";

                            dtMain.Rows.Add(detail.GatePass_ID, iStatus, detail.Employee_ID, clsRef_Name.get_EmployeeAliasName(detail.Employee_ID), clsRef_Name.get_Division_Name(detail.Division_ID), clsRef_Name.get_Department_Name(detail.Department_ID), clsRef_Name.get_Section_Name(detail.Section_ID), clsRef_Name.get_SubSection_Name(detail.SubSection_ID), detail.GatePass_DateTime.ToString(clsConfig.Format_Date), (detail.Leave_Hours / 60).ToString("00.00"), detail.Reason, sBataStatus, detail.BataAmount);
                        }
                    }

                    grd_Gatepass.ItemsSource = dtMain.DefaultView;
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        public void RefreshGrid(string sEmpID)
        {
            try
            {
                dtMain.Clear();
                tbl_genMasEmployee oUser = tbl_genMasEmployee.Select(sEmpID, clsSecurity.CompanyID, clsSecurity.BranchID);
                if (oUser != null)
                {
                    DateTime HRYearStartDate = currentHRYear_StartDate.Date;
                    DateTime HRYearEndData = currentHRYear_EndDate.Date;

                    string empID = oUser.Employee_ID;

                    foreach (tbl_tasTxGatePass detail in tbl_tasTxGatePass.SelectAll().Where(p => p.IsCanceled == false && p.GatePass_ID != "default" && p.Employee_ID == empID && p.GatePass_DateTime.Date >= currentHRYear_StartDate.Date && p.GatePass_DateTime.Date <= currentHRYear_EndDate.Date))
                    {
                        string iStatus;
                        if (detail.ApprovalStatus_Manager == 1 && detail.ApprovalStatus_Supevosior == 1)
                            iStatus = "Approved";

                        else
                            iStatus = "Pending";
                        string sBataStatus = "No";
                        if (detail.IsBataPayable == true)
                            sBataStatus = "Yes";

                        dtMain.Rows.Add(detail.GatePass_ID, iStatus, detail.Employee_ID, clsRef_Name.get_EmployeeAliasName(detail.Employee_ID), clsRef_Name.get_Division_Name(detail.Division_ID), clsRef_Name.get_Department_Name(detail.Department_ID), clsRef_Name.get_Section_Name(detail.Section_ID), clsRef_Name.get_SubSection_Name(detail.SubSection_ID), detail.GatePass_DateTime.ToString(clsConfig.Format_Date), (detail.Leave_Hours / 60).ToString("00.00"), detail.Reason, sBataStatus, detail.BataAmount);
                    }

                    txtEmployeeNo.Text = oUser.FullName;
                    txtEmployeeNo.Tag = oUser.Employee_ID;
                    txtEmployeeNo.IsEnabled = false;
                    Vw_EmployeeDemography.setEmployeeDetail(oUser.Employee_ID);
                    Set_UserIndicator(ref Wusr_Checked, Vw_EmployeeDemography.Employee.SupevisorID);
                    Set_UserIndicator(ref Wusr_Approved, Vw_EmployeeDemography.Employee.ManagerID);

                    grd_Gatepass.ItemsSource = dtMain.DefaultView;
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        #endregion

        #region Check validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_DuplicateFiled())
                    bStatus = true;
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (SEACC_Form.IsUpdateMode)
            {
                if (!clsValidation.Validate_EmptyValue(txtGatePassNo))
                    bStatus = false;
            }

            if (!clsValidation.Validate_EmptyValue(txtEmployeeNo))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtReason))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_tasTxGatePass detail = tbl_tasTxGatePass.Select(txtGatePassNo.Text, clsSecurity.CompanyID, clsSecurity.BranchID);
                if (detail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        public bool ChecckValidity_ConflictFields()
        {
            bool bStatus = true;
            tbl_tasTxGatePass detail = tbl_tasTxGatePass.Select(txtGatePassNo.Text.Trim(), clsSecurity.CompanyID, clsSecurity.BranchID);
            if (detail != null)
            {
                string sMessege = "";
                if (Vw_EmployeeDemography.Employee.Division_ID != detail.Division_ID)
                    sMessege = "Division";
                if (Vw_EmployeeDemography.Employee.Department_ID != detail.Department_ID)
                    sMessege += " , Department";
                if (Vw_EmployeeDemography.Employee.SectionID != detail.Section_ID)
                    sMessege += " , Section";
                if (Vw_EmployeeDemography.Employee.SubSectionID != detail.SubSection_ID)
                    sMessege += " ,Sub Section";
                if (sMessege != "")
                {
                    bool bMessegeBoxResult = SEACCMessageBox.Show("Oops...", sMessege + " you enterd does not math with the values in employee profile.Do you want to override with new values ?");
                    if (!bMessegeBoxResult)
                    {
                        bStatus = false;
                    }
                }

            }


            return bStatus;
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                tbl_tasTxGatePass detail = tbl_tasTxGatePass.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sID);
                if (detail != null)
                {
                    SEACC_Form.IsUpdateMode = true;
                    txtGatePassNo.Text = detail.GatePass_ID;
                    txtGatePassNo.Tag = detail.GatePass_ID;
                    txtGatePassNo.IsEnabled = false;
                    txtEmployeeNo.Text = detail.Employee_ID + "-" + clsRef_Name.get_EmployeeName(detail.Employee_ID);
                    txtEmployeeNo.IsEnabled = false;
                    txtEmployeeNo.Tag = detail.Employee_ID;

                    Vw_EmployeeDemography.setEmployeeDetail(detail.Employee_ID);

                    dtp_GatePassDateTime.SetTime(detail.GatePass_DateTime);
                    ts_LeaveHours.setMinutes(Convert.ToInt32(detail.Leave_Hours));
                    txtReason.Text = detail.Reason;

                    tbl_genMasEmployee oEmployeeChecked = tbl_genMasEmployee.Select(detail.UserID_Supevisor, clsSecurity.CompanyID, clsSecurity.BranchID);
                    if (oEmployeeChecked != null)
                    {
                        Set_UserIndicator(ref Wusr_Checked, oEmployeeChecked.Employee_ID);
                    }
                    tbl_genMasEmployee oEmployeeApproved = tbl_genMasEmployee.Select(detail.UserID_Manager, clsSecurity.CompanyID, clsSecurity.BranchID);
                    if (oEmployeeApproved != null)
                    {
                        Set_UserIndicator(ref Wusr_Approved, oEmployeeApproved.Employee_ID);
                    }
                    if (Vw_EmployeeDemography.Employee.SupevisorID == clsSecurity.EmployeeIDLoged)
                    {
                        cbx_Checked.IsEnabled = true;
                    }
                    if (Vw_EmployeeDemography.Employee.ManagerID == clsSecurity.EmployeeIDLoged)
                    {
                        cbx_Approved.IsEnabled = true;
                    }
                    if (detail.IsBataPayable)
                    {
                        chk_BataPayable.IsChecked = true;
                    }
                    else
                    {
                        chk_BataPayable.IsChecked = false;
                    }
                    txtrate.Text = detail.BataAmount.ToString();
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Grid Event
        private void grd_Gatepass_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = grd_Gatepass.SelectedItem;
                if (item != null)
                {
                    string GridID = (grd_Gatepass.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    ClearFields();
                    FillDetails(GridID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Event
        private void txtEmployeeNo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                frmSearch RowDataSearch = new frmSearch();
                List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
                if (RowDataSearch.DialogResult == true)
                {
                    ClearFields();
                    txtEmployeeNo.Text = lstResult[1] + "-" + clsRef_Name.get_EmployeeName(lstResult[0]);
                    txtEmployeeNo.Tag = lstResult[0];
                    Vw_EmployeeDemography.setEmployeeDetail(lstResult[0]);

                    Set_UserIndicator(ref Wusr_Checked, Vw_EmployeeDemography.Employee.SupevisorID);
                    Set_UserIndicator(ref Wusr_Approved, Vw_EmployeeDemography.Employee.ManagerID);
                    RefreshGrid();

                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void txtGatePassNo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.GatePass);
            if (RowDataSearch.DialogResult == true)
            {
                txtGatePassNo.Text = lstResult[0];
                FillDetails(lstResult[0]);
            }
        }
        #endregion

        #region Row Color Change Event
        private void grd_Gatepass_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            try
            {
                string g = ((System.Data.DataRowView)(e.Row.DataContext)).Row.ItemArray[1].ToString();
                if (g == "Approved")
                {
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#2A934B");// new SolidColorBrush(Colors.Green);
                }
                else if (g.Trim() == "Rejected")
                {
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#7B0000");// new SolidColorBrush();
                }
                else
                {
                    e.Row.Background = (Brush)bc.ConvertFrom("#FF34495E"); ;
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
                // MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region CheckBox Event
        private void cbx_Approved_Checked(object sender, RoutedEventArgs e)
        {
            bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Approval_Confirmation);
            if (bMessegeBoxResult)
            {
                tbl_tasTxGatePass detail = tbl_tasTxGatePass.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtGatePassNo.Text.Trim());
                if (detail != null)
                {
                    //detail.IsApproved = true;
                    //detail.Date_Approved = clsSecurity.getServerDateTime();
                    //detail.TerminalID_Checked = clsSecurity.TerminalID;
                    //detail.UserID_Checked_By = clsSecurity.UserIDLoged;
                    //detail.Update();
                    //// usr_Approved.Set(clsSecurity.UserNameLoged, clsSecurity.UserImageLoged);
                    //SEACCMessageBox.Show(MessegeBoxType.Successfully_Approved);
                }
            }
            else
            {
                cbx_Approved.IsChecked = false;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Checked_Confirmation);
            if (bMessegeBoxResult)
            {
                tbl_tasTxGatePass detail = tbl_tasTxGatePass.Select(txtGatePassNo.Text.Trim(), clsSecurity.CompanyID, clsSecurity.BranchID);
                if (detail != null)
                {
                    //detail.IsCanceled = true;
                    //detail.Date_Canceled = clsSecurity.getServerDateTime();
                    //detail.TerminalID_Canceled = clsSecurity.TerminalID;
                    //detail.UserID_Canceled = clsSecurity.UserIDLoged;
                    //detail.Update();
                    ////usr_Checked.Set(clsSecurity.UserNameLoged, clsSecurity.UserImageLoged);
                    //SEACCMessageBox.Show(MessegeBoxType.Successfully_Checked);
                }
            }
            else
            {
                cbx_Checked.IsChecked = false;
            }
        }

        private void chk_BataPayable_checkBox_Checked(object sender, EventArgs e)
        {
            if (!txtrate.IsEnabled)
            {
                txtrate.IsEnabled = true;
            }
        }

        private void chk_BataPayable_checkBox_Unchecked(object sender, EventArgs e)
        {
            txtrate.Text = "0.00";
            txtrate.IsEnabled = false;
        }
        #endregion

        private void EmployeeLogin()
        {
            tbl_securityUserMaster oSecurityUser = tbl_securityUserMaster.Select(clsSecurity.UserIDLoged);
            if (oSecurityUser != null && oSecurityUser.Group_ID == "6")
            {
                BrushConverter bc = new BrushConverter();
                txtEmployeeNo.Text = oSecurityUser.EmployeeID + "-" + clsRef_Name.get_EmployeeName(oSecurityUser.EmployeeID);
                txtEmployeeNo.Tag = oSecurityUser.EmployeeID;
                txtEmployeeNo.IsEnabled = false;
                txtEmployeeNo.Foreground = (Brush)bc.ConvertFrom("#000000");
                Vw_EmployeeDemography.setEmployeeDetail(oSecurityUser.EmployeeID);
                clsCommon.Set_UserIndicator(ref Wusr_Checked, Vw_EmployeeDemography.Employee.SupevisorID);
                clsCommon.Set_UserIndicator(ref Wusr_Approved, Vw_EmployeeDemography.Employee.ManagerID);
                RefreshGrid();
            }
        }

        void Set_UserIndicator(ref SEACC_UserIndicator_Small userIndicator, string UserID)
        {
            if (UserID != "default")
            {
                tbl_genMasEmployee oEmployee = tbl_genMasEmployee.Select(UserID, clsSecurity.CompanyID, clsSecurity.BranchID);
                if (oEmployee != null)
                {
                    userIndicator.Set(UserID, oEmployee.FullName, clsCommon.Convert_ByteToBitMap(oEmployee.Employee_Image));
                }
            }
        }

        private void Wusr_Checked_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                tbl_genMasEmployee detail = tbl_genMasEmployee.Select(lstResult[0], clsSecurity.CompanyID, clsSecurity.BranchID);
                if (detail != null)
                {
                    Set_UserIndicator(ref Wusr_Checked, lstResult[0]);
                }
            }
        }

        private void Wusr_Approved_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                tbl_genMasEmployee detail = tbl_genMasEmployee.Select(lstResult[0], clsSecurity.CompanyID, clsSecurity.BranchID);
                if (detail != null)
                {
                    Set_UserIndicator(ref Wusr_Approved, lstResult[0]);
                }
            }
        }

        private void dtp_GatePassDateTime_DateTimeChanged(object sender, EventArgs e)
        {
            this.SEACC_Form.btn_Save.Visibility = Visibility.Visible;
            this.SEACC_Form.btn_Cancel.Visibility = Visibility.Visible;
            if (txtEmployeeNo.Tag != null && txtEmployeeNo.Tag.ToString() != "0")
            {
                if (this.SEACC_Form.btn_Save.Visibility == Visibility.Visible)
                {

                    DataTable dtPayrollRawData = DBHandling.ExecQuery("sp_getPayrollRawData_fromEmployeeWise_GivenDate '" + txtEmployeeNo.Tag.ToString() + "' , '" + dtp_GatePassDateTime.GetDateTime().Date + "'").Tables[0];
                    if (dtPayrollRawData.Rows.Count > 0)
                    {
                        this.SEACC_Form.btn_Save.Visibility = Visibility.Collapsed;
                        this.SEACC_Form.btn_Cancel.Visibility = Visibility.Collapsed;
                    }
                }

                dtp_GatePassDateTime.SetTime(clsValidation.Merge_DateAndTime(dtp_GatePassDateTime.GetDateTime(), dtp_GatePassDateTime.GetDateTime()));
            }
            else
            {
                SEACCMessageBox.Show("Employee should be selected first", "", MessageBoxButton.OK);
                dtp_GatePassDateTime.SetTime(DateTime.Now);
            }
        }

    }
}