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
using System.Data;
using DataTire;
using Digiteq_Logic;
using Digiteq.DataSets;
using SEACC_WPFControls;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Globalization;
using System.ComponentModel;
using Digiteq.Reports;
using System.Windows.Interop;
using System.Diagnostics;
using OfficeOpenXml;
using System.Xml;
using OfficeOpenXml.Style;
using ZION.HRCM.DATA.PAY;

namespace Digiteq
{
    public partial class UC_Report : UserControl
    {
        private BrushConverter bc = new BrushConverter();

        #region Form Load
        public UC_Report()
        {
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Reports;
            SEACC_Form.Initialize();

            #region  #region Initialize Data Table
            drg_Reports.dt.Columns.Add("ReportID", typeof(string));
            drg_Reports.dt.Columns.Add("ReportCatID", typeof(string));
            drg_Reports.dt.Columns.Add("ReportCatName", typeof(string));
            drg_Reports.dt.Columns.Add("ReportName", typeof(string));

            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(false, false, false, false);
            #endregion

            #region Grid Initialize
            drg_Reports.Add_DatagridColoumn("Report Id", "ReportID", 100, false);
            drg_Reports.Add_DatagridColoumn("Category Id", "ReportCatID", 80, false);
            drg_Reports.Add_DatagridColoumn("Category Name", "ReportCatName", 150, false);
            drg_Reports.Add_DatagridColoumn("Report Name", "ReportName", 400);
            #endregion

            ClearFields();
            RefreshGrid();

        }

        #endregion

        #region Form Responsive
        #endregion

        #region Action Buttons
        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cursor = Cursors.Wait;

                object item = drg_Reports.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (drg_Reports.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    int iReportID = int.Parse(GridID);
                    enum_ReportName Report = (enum_ReportName)iReportID;
                    tbl_securityFunctionMaster oFunction = tbl_securityFunctionMaster.Select(iReportID);
                    tbl_securityFunctionMaster_Report oReport = tbl_securityFunctionMaster_Report.Select((iReportID));
                    tbl_securityFunctionMaster_Permission oUserPermission = tbl_securityFunctionMaster_Permission.Select(clsSecurity.UserIDLoged, oReport.Function_ID);
                    if (oFunction != null && oReport != null)
                    {
                        DataSets.dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();
                        glb_dts_ExportReport.dt_rptParameter.Clear();

                        string sFilter = string.Empty;
                        bool bEmployeeSelected = false, bDesignationSelected = false, bDivisionSelected = false, bDepartmentSelected = false,
                            bSectionSelected = false, bSubSectionSelected = false, bEmpCategory1Selected = false, bEmpCategory2Selected = false,
                            bEmpCategory3Selected = false, bShiftSelected = false, bPayPeriodSelected = false, bPaymentMethodSelected = false,
                            bPayslipItemSelected = false, bLeaveTypeSelected = false;

                        DateTime dtmFromDate = dtp_FromDate.GetDateTime();
                        DateTime dtmToDate = dtp_ToDate.GetDateTime();

                        var vDivisions = msbDivision.GetData().Rows.Count > 0 ? msbDivision.GetData().AsEnumerable().ToList() : null;

                        #region Filters
                        if (txtEmployee.Tag != null)
                        {
                            bEmployeeSelected = true;
                            sFilter = "Employee : " + txtEmployee.Text.ToString();
                        }
                        if (txtDesignation.Tag != null)
                        {
                            bDesignationSelected = true;
                            sFilter += (sFilter != "" ? "  |  " : "") + "Designation : " + txtDesignation.Text.ToString();
                        }

                        if (txtDivision.Visibility == Visibility.Visible && txtDivision.Tag != null)
                        {
                            bDivisionSelected = true;
                            sFilter += (sFilter != "" ? "  |  " : "") + "Division : " + txtDivision.Text.ToString();
                        }
                        if (!msbDivision.IsSelectAll() && vDivisions != null && msbDivision.Visibility == Visibility.Visible) // Division Multiple Selection
                        {
                            bDivisionSelected = true;
                            sFilter += (sFilter != "" ? "  |  " : "") + "Division : ";
                            vDivisions.ForEach(r => sFilter += r.Field<string>("name") + ",");
                            txtDivision.Tag = vDivisions.FirstOrDefault().ItemArray[1];
                        }

                        if (txtDepartment.Tag != null)
                        {
                            bDepartmentSelected = true;
                            sFilter += (sFilter != "" ? "  |  " : "") + "Department : " + txtDepartment.Text.ToString();
                        }
                        if (txtSection.Tag != null)
                        {
                            bSectionSelected = true;
                            sFilter += (sFilter != "" ? "  |  " : "") + "Section : " + txtSection.Text.ToString();
                        }
                        if (txtSubSection.Tag != null)
                        {
                            bSubSectionSelected = true;
                            sFilter += (sFilter != "" ? "  |  " : "") + "Sub Section : " + txtSection.Text.ToString();
                        }
                        if (txtEmpCategory1.Tag != null)
                        {
                            bEmpCategory1Selected = true;
                            sFilter += (sFilter != "" ? "  |  " : "") + "Employee Category 1 : " + txtEmpCategory1.Text.ToString();
                        }
                        if (txtEmpCategory2.Tag != null)
                        {
                            bEmpCategory2Selected = true;
                            sFilter += (sFilter != "" ? "  |  " : "") + "Employee Category 2 : " + txtEmpCategory2.Text.ToString();
                        }
                        if (txtEmpCategory3.Tag != null)
                        {
                            bEmpCategory3Selected = true;
                            sFilter += (sFilter != "" ? "  |  " : "") + "Employee Category 3 : " + txtEmpCategory3.Text.ToString();
                        }
                        if (txtShift.Tag != null)
                        {
                            bShiftSelected = true;
                            sFilter += (sFilter != "" ? "  |  " : "") + "Shift : " + txtShift.Text.ToString();
                        }
                        if (cmb_EmpStatus.GetSelectedIndex() != -1)
                        {
                            sFilter += (sFilter != "" ? "  |  " : "") + "Employee Status : " + cmb_EmpStatus.GetSelectedValue().Replace("<", "").Replace(">", "");
                        }
                        if (txtYear.Tag != null)
                        {
                            sFilter += (sFilter != "" ? "  |  " : "") + "Year : " + txtYear.Text.ToString();
                        }
                        if (txtWeek.Tag != null)
                        {
                            sFilter += (sFilter != "" ? "  |  " : "") + "Week : " + txtWeek.Text.ToString();
                        }
                        if (txtLeaveTypes.Tag != null)
                        {
                            bLeaveTypeSelected = true;
                            sFilter += (sFilter != "" ? "  |  " : "") + "Leave Type : " + txtLeaveTypes.Text.ToString();
                        }
                        if (txtPayPeriod.Tag != null)
                        {
                            bPayPeriodSelected = true;
                            sFilter += (sFilter != "" ? "  |  " : "") + "Payroll Period Name : " + txtPayPeriod.Text.ToString();
                        }
                        if (txtPayementMethodBy.Tag != null)
                        {
                            bPaymentMethodSelected = true;
                            sFilter += (sFilter != "" ? "  |  " : "") + "Payment Method : " + txtPayementMethodBy.Text.ToString();
                        }
                        if (txtPayslipItem.Tag != null)
                        {
                            bPayslipItemSelected = true;
                            sFilter += (sFilter != "" ? "  |  " : "") + "Payslip Item : " + txtPayslipItem.Text.ToString();
                        }
                        if (rdoIsPaySlipPrint.IsChecked == true)
                        {
                            sFilter += (sFilter != "" ? "  |  " : "") + "Payslip Printed Employees ";
                        }
                        if (rdoIsNotPaySlipPrint.IsChecked == true)
                        {
                            sFilter += (sFilter != "" ? "  |  " : "") + "Payslip Not Printed Employees ";
                        }
                        #endregion

                        #region REGISTER REPORTS
                        #region Employee_Demography_Personal_Details | Employee Information Sheet | Employee_Resigned_Sheet | Employee Birthday List | Employee BirthDay Calendar
                        if (Report == enum_ReportName.Employee_Demography_Personal_Details || Report == enum_ReportName.Employee_Information_Sheet || Report == enum_ReportName.Employee_Resigned_Sheet || Report == enum_ReportName.Employee_Birthday_List)
                        {
                            DataSets.dts_Generel glb_dts_Generel = new DataSets.dts_Generel();

                            #region Company Data Set Fill
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_Generel.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "", clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                                glb_dts_Generel.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "", clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #endregion

                            #region Filters
                            #region Employee Filter
                            List<sp_genMasEmployee> oEmployees;
                            if (bEmployeeSelected)
                            {
                                oEmployees = new List<sp_genMasEmployee>();
                                oEmployees.Add(sp_genMasEmployee.Select(txtEmployee.Tag.ToString()));
                            }
                            else
                                oEmployees = sp_genMasEmployee.SelectAll().ToList();
                            #endregion

                            if (bDesignationSelected)
                                oEmployees = oEmployees.Where(p => p.Designation_ID == txtDesignation.Tag.ToString()).ToList();

                            if (bDivisionSelected)
                                oEmployees = oEmployees.Where(r => vDivisions.Any(r2 => r2.Field<string>("id") == r.Division_ID)).ToList();

                            if (bDepartmentSelected)
                                oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();

                            if (bSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();

                            if (bSubSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SubSectionID == txtSubSection.Tag.ToString()).ToList();

                            if (bEmpCategory1Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();

                            if (bEmpCategory2Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();

                            if (bEmpCategory3Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();

                            if (Report != enum_ReportName.Employee_Resigned_Sheet)
                            {
                                int iEmpStatus = cmb_EmpStatus.GetSelectedIndex();
                                if (iEmpStatus == (int)EmployeeStatus.Active ||
                                    iEmpStatus == (int)EmployeeStatus.Resigned ||
                                    iEmpStatus == (int)EmployeeStatus.Suspended_With_Pay ||
                                    iEmpStatus == (int)EmployeeStatus.Suspended_Without_Pay ||
                                    iEmpStatus == (int)EmployeeStatus.Hired ||
                                    iEmpStatus == (int)EmployeeStatus.ReHired)
                                    oEmployees = oEmployees.Where(p => p.Emp_statusID == iEmpStatus.ToString()).ToList();// p.LastWorkingDate.Date >= dtmFromDate.Date && p.LastWorkingDate <= dtmToDate.Date && 

                                else if (iEmpStatus == cmb_EmpStatus.comboBox.Items.Count - 1)
                                    oEmployees = oEmployees.Where(p => p.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString()).ToList();//p.LastWorkingDate.Date >= dtmFromDate.Date && p.LastWorkingDate <= dtmToDate.Date &&
                            }
                            else
                                oEmployees = oEmployees.Where(p => p.LastWorkingDate.Date >= dtmFromDate.Date && p.LastWorkingDate.Date <= dtmToDate.Date && p.Emp_statusID == ((int)EmployeeStatus.Resigned).ToString()).ToList();

                            //if (Report == enum_ReportName.Employee_Resigned_Sheet)
                            //    oEmployees = oEmployees.Where(p => p.Emp_statusID.Trim() == ((int)EmployeeStatus.Resigned).ToString()).ToList();

                            #endregion

                            decimal dBasicSalary = 0, dBRA1 = 0, dBRA2 = 0, dBRA3 = 0, dTravellingallowance = 0, dBR = 0, dAllowances = 0, dSpecialAllowances = 0;
                            string sEPF_No = "-";

                            foreach (sp_genMasEmployee oEmployee in oEmployees.Where(r => r.Employee_ID != "default" && r.FullName.Length > 3).OrderBy(o => o.EpfNo.PadLeft(4, '0')).ThenBy(o => o.Employee_ID.PadLeft(4, '0')))
                            {
                                if (Report == enum_ReportName.Employee_Retirement_Record)
                                    if (oEmployee.DateTerminate == clsConfig.defaultDateTime && oEmployee.DateTerminate >= dtmFromDate && oEmployee.DateTerminate <= dtmToDate)
                                        continue;

                                sEPF_No = (oEmployee.EpfNo == "" || oEmployee.EpfNo == "0") ? "-" : oEmployee.EpfNo.PadLeft(4, '0');

                                glb_dts_Generel.tbl_Employee.Addtbl_EmployeeRow(oEmployee.Employee_ID.PadLeft(4, '0'), sEPF_No, oEmployee.Employee_ID2, oEmployee.Title, oEmployee.SurName, oEmployee.Initails,
                                    oEmployee.FullName, oEmployee.AliasName, oEmployee.DivisionName, oEmployee.DepartmentName, oEmployee.Section_Name, oEmployee.SubSectionName, oEmployee.NicNo,
                                    oEmployee.DrivingLic_No, oEmployee.PassportNo, oEmployee.Nationality, oEmployee.Religion, oEmployee.DateOfBirth.ToString(clsConfig.Format_Date), ((Gender)oEmployee.Gender).ToString(),
                                    ((CivilState)oEmployee.CivilState).ToString(), oEmployee.Employee_Image, oEmployee.DateJoin.Date.ToString() == clsConfig.defaultDateTime.Date.ToString() ? "-" : oEmployee.DateJoin.Date.ToString(clsConfig.Format_Date2), oEmployee.DateConfirm.Date.ToString() == clsConfig.defaultDateTime.Date.ToString() ? "-" : oEmployee.DateConfirm.Date.ToString(clsConfig.Format_Date2),
                                    oEmployee.DateOfMerrage.Date.ToString() == clsConfig.defaultDateTime.Date.ToString() ? "-" : oEmployee.DateOfMerrage.Date.ToString(clsConfig.Format_Date),
                                    oEmployee.VisaEndDate.Date.ToString(clsConfig.Format_Date) == clsConfig.defaultDateTime.Date.ToString() ? "-" : oEmployee.VisaEndDate.Date.ToString(clsConfig.Format_Date),
                                    oEmployee.DateTerminate.ToString(clsConfig.Format_Date), oEmployee.LastWorkingDate.ToString(clsConfig.Format_Date) == clsConfig.defaultDateTime.ToString() ? "-" : oEmployee.LastWorkingDate.ToString(clsConfig.Format_Date),
                                    ((EmployeeStatus)int.Parse(oEmployee.Emp_statusID)).ToString(), oEmployee.Designation_name, oEmployee.EmpCatagory1_Name, oEmployee.EmpCatagory2_Name, oEmployee.EmpCatagory3_Name, oEmployee.RecuirtmentType, oEmployee.ManagerID,
                                    oEmployee.SupevisorID, oEmployee.Mobile_Office, oEmployee.Mobile1, oEmployee.Email_office, oEmployee.Telephone_Office, oEmployee.Telephone_Ext, oEmployee.AddressLine1, oEmployee.AddressLine2,
                                    oEmployee.AddressLine3, oEmployee.Bank_ID == "Default" ? "-" : oEmployee.Bank_ID, oEmployee.BankName == "Default" ? "-" : oEmployee.BankName, oEmployee.BankBranch_Code == "Default" ? "-" : oEmployee.BankBranch_Code,
                                    oEmployee.BranchName == "Default" ? "-" : oEmployee.BranchName, oEmployee.Employee_AccountNo, oEmployee.Employee_AccountName);

                                //if (Report == enum_ReportName.Employee_Service_Record)
                                //{
                                //    dBasicSalary = clsHelpMethods.GetPaySlipItemAmount_FromMas(oEmployee.Employee_ID, clsConfig.sBasicSalary);
                                //    dBRA1 = clsHelpMethods.GetPaySlipItemAmount_FromMas(oEmployee.Employee_ID, clsConfig.sBRA1);
                                //    dBRA2 = clsHelpMethods.GetPaySlipItemAmount_FromMas(oEmployee.Employee_ID, clsConfig.sBRA2);
                                //    dBRA3 = clsHelpMethods.GetPaySlipItemAmount_FromMas(oEmployee.Employee_ID, clsConfig.sBRA3);
                                //    dTravellingallowance = clsHelpMethods.GetPaySlipItemAmount_FromMas(oEmployee.Employee_ID, clsConfig.sTravellingAllowance);
                                //    dSpecialAllowances = clsHelpMethods.GetPaySlipItemAmount_FromMas(oEmployee.Employee_ID, clsConfig.sAllowance1);

                                //    glb_dts_Generel.tbl_Employee_ServiceDetails.Addtbl_Employee_ServiceDetailsRow(oEmployee.Employee_ID, "", dBasicSalary, dBRA1, dBRA2, dBRA3, dTravellingallowance, dSpecialAllowances, dtmToDate, oEmployee.DateJoin, oEmployee.DateJoin.Year, oEmployee.DateConfirm);
                                //}
                            }
                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_Generel, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }

                        if (Report == enum_ReportName.Employee_Birthday_Calendar)
                        {
                            DataSets.dts_Generel glb_dts_Generel = new DataSets.dts_Generel();
                            glb_dts_Generel.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "", clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);

                            #region Filters
                            #region Employee Filter
                            List<sp_genMasEmployee> oEmployees;
                            if (bEmployeeSelected)
                            {
                                oEmployees = new List<sp_genMasEmployee>();
                                oEmployees.Add(sp_genMasEmployee.Select(txtEmployee.Tag.ToString()));
                            }
                            else
                                oEmployees = sp_genMasEmployee.SelectAll().ToList();
                            #endregion

                            if (bDesignationSelected)
                                oEmployees = oEmployees.Where(p => p.Designation_ID == txtDesignation.Tag.ToString()).ToList();

                            if (bDivisionSelected)
                                oEmployees = oEmployees.Where(p => p.Division_ID == txtDivision.Tag.ToString()).ToList();

                            if (bDepartmentSelected)
                                oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();

                            if (bSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();

                            if (bSubSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SubSectionID == txtSubSection.Tag.ToString()).ToList();

                            if (bEmpCategory1Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();

                            if (bEmpCategory2Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();

                            if (bEmpCategory3Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();

                            int iEmpStatus = cmb_EmpStatus.GetSelectedIndex();
                            if (iEmpStatus == (int)EmployeeStatus.Active || iEmpStatus == (int)EmployeeStatus.Resigned || iEmpStatus == (int)EmployeeStatus.Suspended_With_Pay || iEmpStatus == (int)EmployeeStatus.Suspended_Without_Pay || iEmpStatus == (int)EmployeeStatus.Hired || iEmpStatus == (int)EmployeeStatus.ReHired)
                                oEmployees = oEmployees.Where(p => p.Emp_statusID == iEmpStatus.ToString()).ToList();

                            if (Report == enum_ReportName.Employee_Resigned_Sheet)
                                oEmployees = oEmployees.Where(p => p.Emp_statusID.Trim() == ((int)EmployeeStatus.Resigned).ToString()).ToList();


                            #endregion

                            foreach (sp_genMasEmployee oEmployee in oEmployees)
                            {
                                glb_dts_Generel.tbl_Employee_BirthDay.Addtbl_Employee_BirthDayRow(oEmployee.Employee_ID, oEmployee.FullName, oEmployee.DateOfBirth, oEmployee.DateOfBirth, oEmployee.DateOfBirth, oEmployee.DateOfBirth.Date == clsValidation.defaultDateTime.Date ? "-" : (clsSecurity.getServerDateTime().Year - oEmployee.DateOfBirth.Year).ToString());

                            }
                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_Generel, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }
                        #endregion

                        #region Employee Joining Month Listing Report (Employee Recruitments)
                        if (Report == enum_ReportName.Employee_JoingMonthListing)
                        {
                            DataSets.dts_Generel glb_dts_Generel = new DataSets.dts_Generel();

                            #region Company Data Set Fill
                            //glb_dts_Generel.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()),
                            //    clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "", clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_Generel.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "", clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                                glb_dts_Generel.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "", clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #endregion

                            #region Filters
                            #region Employee Filter
                            List<sp_genMasEmployee> oEmployees;
                            if (bEmployeeSelected)
                            {
                                oEmployees = new List<sp_genMasEmployee>();
                                oEmployees.Add(sp_genMasEmployee.Select(txtEmployee.Tag.ToString()));
                            }
                            else
                                oEmployees = sp_genMasEmployee.SelectAll().ToList();
                            #endregion

                            if (bDesignationSelected)
                                oEmployees = oEmployees.Where(p => p.Designation_ID == txtDesignation.Tag.ToString()).ToList();

                            if (bDivisionSelected)
                                oEmployees = oEmployees.Where(r => vDivisions.Any(r2 => r2.Field<string>("id") == r.Division_ID)).ToList();

                            if (bDepartmentSelected)
                                oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();

                            if (bSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();

                            if (bSubSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SubSectionID == txtSubSection.Tag.ToString()).ToList();

                            if (bEmpCategory1Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();

                            if (bEmpCategory2Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();

                            if (bEmpCategory3Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();

                            int iEmpStatus = cmb_EmpStatus.GetSelectedIndex();
                            if (iEmpStatus == (int)EmployeeStatus.Active || iEmpStatus == (int)EmployeeStatus.Resigned || iEmpStatus == (int)EmployeeStatus.Suspended_With_Pay || iEmpStatus == (int)EmployeeStatus.Suspended_Without_Pay || iEmpStatus == (int)EmployeeStatus.Hired || iEmpStatus == (int)EmployeeStatus.ReHired)
                                oEmployees = oEmployees.Where(p => p.Emp_statusID == iEmpStatus.ToString()).ToList();
                            else if (iEmpStatus == cmb_EmpStatus.comboBox.Items.Count - 1)
                                oEmployees = oEmployees.Where(p => p.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString()).ToList();

                            #endregion

                            decimal dBasicSalary = 0, dBRA1 = 0, dBRA2 = 0, dBRA3 = 0, dTravellingallowance = 0, dBR = 0, dAllowances = 0, dSpecialAllowances = 0;

                            foreach (sp_genMasEmployee oEmployee in oEmployees.Where(r => r.Employee_ID != "default" && r.DateJoin.Date >= dtmFromDate.Date && r.DateJoin.Date <= dtmToDate.Date))
                            {
                                glb_dts_Generel.tbl_Employee.Addtbl_EmployeeRow(oEmployee.Employee_ID, oEmployee.EpfNo, oEmployee.Employee_ID2, oEmployee.Title, oEmployee.SurName,
                                    oEmployee.Initails, oEmployee.FullName, oEmployee.AliasName, oEmployee.DivisionName, oEmployee.DepartmentName, oEmployee.Section_Name, oEmployee.SubSectionName,
                                    oEmployee.NicNo, oEmployee.DrivingLic_No, oEmployee.PassportNo, oEmployee.Nationality, oEmployee.Religion, oEmployee.DateOfBirth.ToString(clsConfig.Format_Date),
                                    ((Gender)oEmployee.Gender).ToString(), ((CivilState)oEmployee.CivilState).ToString(), oEmployee.Employee_Image, oEmployee.DateJoin.Date.ToString() == clsConfig.defaultDateTime.Date.ToString() ? "-" : oEmployee.DateJoin.Date.ToString(clsConfig.Format_Date2),
                                    oEmployee.DateConfirm.Date.ToString() == clsConfig.defaultDateTime.Date.ToString() ? "-" : oEmployee.DateConfirm.Date.ToString(clsConfig.Format_Date2),
                                    oEmployee.DateOfMerrage.Date.ToString() == clsConfig.defaultDateTime.Date.ToString() ? "-" : oEmployee.DateOfMerrage.Date.ToString(clsConfig.Format_Date),
                                    oEmployee.VisaEndDate.Date.ToString(clsConfig.Format_Date) == clsConfig.defaultDateTime.Date.ToString() ? "-" : oEmployee.VisaEndDate.Date.ToString(clsConfig.Format_Date2),
                                    oEmployee.RecuirtmentType, oEmployee.LastWorkingDate.ToString(clsConfig.Format_Date2) == clsConfig.defaultDateTime.ToString() ? "-" : oEmployee.LastWorkingDate.ToString(clsConfig.Format_Date), oEmployee.Emp_statusID,
                                    oEmployee.Designation_name, oEmployee.EmpCatagory1_Name, oEmployee.EmpCatagory2_Name, oEmployee.EmpCatagory3_Name, oEmployee.RecuirtmentType, oEmployee.ManagerID, oEmployee.SupevisorID, oEmployee.Mobile_Office,
                                    oEmployee.Mobile1, oEmployee.Email_office, oEmployee.Telephone_Office, oEmployee.Telephone_Ext, oEmployee.AddressLine1, oEmployee.AddressLine2, oEmployee.AddressLine3, oEmployee.Bank_ID == "Default" ? "-" : oEmployee.Bank_ID,
                                    oEmployee.BankName == "Default" ? "-" : oEmployee.BankName, oEmployee.BankBranch_Code == "Default" ? "-" : oEmployee.BankBranch_Code, oEmployee.BranchName == "Default" ? "-" : oEmployee.BranchName, oEmployee.Employee_AccountNo, oEmployee.Employee_AccountName);

                                glb_dts_Generel.tbl_Employee_ServiceDetails.Addtbl_Employee_ServiceDetailsRow(oEmployee.Employee_ID, "", 0, 0, 0, 0, 0, 0, dtmToDate, oEmployee.DateJoin, oEmployee.DateJoin.Year, oEmployee.DateConfirm);
                            }

                            while (dtmFromDate.Year <= dtmToDate.Year)
                            {
                                foreach (tbl_genMasDepartment oDept in tbl_genMasDepartment.SelectAll().Where(r => !r.IsCanceled))
                                {
                                    glb_dts_Generel.tbl_EmployeeRecruitmentDeptWise.Addtbl_EmployeeRecruitmentDeptWiseRow(oDept.Department_ID, oDept.Department_ID == "default" ? "-" : oDept.DepartmentName,
                                        oDept.Division_ID, (oDept.Division_ID == "default" ? "-" : clsRef_Name.get_Division_Name(oDept.Division_ID)),
                                        dtmFromDate.Year, dtmFromDate.Year.ToString(),
                                        GetRecruitmantCount(oDept.Department_ID, new DateTime(dtmFromDate.Year, 1, 1), new DateTime(dtmFromDate.Year, 1, 31)),
                                        GetRecruitmantCount(oDept.Department_ID, new DateTime(dtmFromDate.Year, 2, 1), new DateTime(dtmFromDate.Year, 2, 28)),
                                        GetRecruitmantCount(oDept.Department_ID, new DateTime(dtmFromDate.Year, 3, 1), new DateTime(dtmFromDate.Year, 3, 31)),
                                        GetRecruitmantCount(oDept.Department_ID, new DateTime(dtmFromDate.Year, 4, 1), new DateTime(dtmFromDate.Year, 4, 30)),
                                        GetRecruitmantCount(oDept.Department_ID, new DateTime(dtmFromDate.Year, 5, 1), new DateTime(dtmFromDate.Year, 5, 31)),
                                        GetRecruitmantCount(oDept.Department_ID, new DateTime(dtmFromDate.Year, 6, 1), new DateTime(dtmFromDate.Year, 6, 30)),
                                        GetRecruitmantCount(oDept.Department_ID, new DateTime(dtmFromDate.Year, 7, 1), new DateTime(dtmFromDate.Year, 7, 31)),
                                        GetRecruitmantCount(oDept.Department_ID, new DateTime(dtmFromDate.Year, 8, 1), new DateTime(dtmFromDate.Year, 8, 31)),
                                        GetRecruitmantCount(oDept.Department_ID, new DateTime(dtmFromDate.Year, 9, 1), new DateTime(dtmFromDate.Year, 9, 30)),
                                        GetRecruitmantCount(oDept.Department_ID, new DateTime(dtmFromDate.Year, 10, 1), new DateTime(dtmFromDate.Year, 10, 31)),
                                        GetRecruitmantCount(oDept.Department_ID, new DateTime(dtmFromDate.Year, 11, 1), new DateTime(dtmFromDate.Year, 1, 30)),
                                        GetRecruitmantCount(oDept.Department_ID, new DateTime(dtmFromDate.Year, 12, 1), new DateTime(dtmFromDate.Year, 12, 31)));
                                }
                                dtmFromDate = dtmFromDate.AddYears(1);
                            }

                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_Generel, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }
                        #endregion

                        #region Employee Service Record | Employee Retirement Record
                        if (Report == enum_ReportName.Employee_Service_Record || Report == enum_ReportName.Employee_Retirement_Record)
                        {
                            DataSets.dts_Generel glb_dts_Generel = new DataSets.dts_Generel();

                            #region Company Data Set Fill
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_Generel.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date From : " + dtmFromDate.Date + " To : " + dtmToDate.Date, clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                                glb_dts_Generel.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date From : " + dtmFromDate.Date + " To : " + dtmToDate.Date, clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #endregion

                            #region Filters
                            #region Employee Filter
                            List<sp_genMasEmployee> oEmployees;
                            if (bEmployeeSelected)
                            {
                                oEmployees = new List<sp_genMasEmployee>();
                                oEmployees.Add(sp_genMasEmployee.Select(txtEmployee.Tag.ToString()));
                            }
                            else
                                oEmployees = sp_genMasEmployee.SelectAll().Where(p => p.Employee_ID != "default" && p.Division_ID != "Default").ToList();
                            #endregion

                            if (bDesignationSelected)
                                oEmployees = oEmployees.Where(p => p.Designation_ID == txtDesignation.Tag.ToString()).ToList();

                            if (bDivisionSelected)
                                oEmployees = oEmployees.Where(r => vDivisions.Any(r2 => r2.Field<string>("id") == r.Division_ID)).ToList();

                            if (bDepartmentSelected)
                                oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();

                            if (bSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();

                            if (bSubSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SubSectionID == txtSubSection.Tag.ToString()).ToList();

                            if (bEmpCategory1Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();

                            if (bEmpCategory2Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();

                            if (bEmpCategory3Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();

                            //if (Report != enum_ReportName.Employee_Resigned_Sheet)
                            //{
                            //    int iEmpStatus = cmb_EmpStatus.GetSelectedIndex();
                            //    if (iEmpStatus == (int)EmployeeStatus.Active || iEmpStatus == (int)EmployeeStatus.Resigned || iEmpStatus == (int)EmployeeStatus.Suspended_With_Pay || iEmpStatus == (int)EmployeeStatus.Suspended_Without_Pay || iEmpStatus == (int)EmployeeStatus.Hired || iEmpStatus == (int)EmployeeStatus.ReHired)
                            //        oEmployees = oEmployees.Where(p => p.LastWorkingDate.Date >= dtmFromDate.Date && p.LastWorkingDate <= dtmToDate.Date && p.Emp_statusID == iEmpStatus.ToString()).ToList();
                            //    else if (iEmpStatus == cmb_EmpStatus.comboBox.Items.Count - 1)
                            //        oEmployees = oEmployees.Where(p => p.LastWorkingDate.Date >= dtmFromDate.Date && p.LastWorkingDate <= dtmToDate.Date && p.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString()).ToList();
                            //}
                            //else
                            //    oEmployees = oEmployees.Where(p => p.LastWorkingDate.Date >= dtmFromDate.Date && p.LastWorkingDate.Date <= dtmToDate.Date && p.Emp_statusID == ((int)EmployeeStatus.Resigned).ToString()).ToList();

                            //if (Report == enum_ReportName.Employee_Resigned_Sheet)
                            //    oEmployees = oEmployees.Where(p => p.Emp_statusID.Trim() == ((int)EmployeeStatus.Resigned).ToString()).ToList();

                            #endregion

                            decimal dBasicSalary = 0, dBRA1 = 0, dBRA2 = 0, dBRA3 = 0, dTravellingallowance = 0, dBR = 0, dAllowances = 0, dSpecialAllowances = 0;
                            string sEPF_No = "-";

                            foreach (sp_genMasEmployee oEmployee in oEmployees.Where(r => r.Employee_ID != "default" && r.FullName.Length > 3).OrderBy(o => o.EpfNo.PadLeft(4, '0')).ThenBy(o => o.Employee_ID.PadLeft(4, '0')))
                            {
                                if (Report == enum_ReportName.Employee_Retirement_Record)
                                    if (oEmployee.DateTerminate == clsConfig.defaultDateTime || oEmployee.DateTerminate <= dtmFromDate || oEmployee.DateTerminate >= dtmToDate || oEmployee.Emp_statusID == ((int)EmployeeStatus.Resigned).ToString())
                                        continue;

                                sEPF_No = (oEmployee.EpfNo == "" || oEmployee.EpfNo == "0") ? "-" : oEmployee.EpfNo.PadLeft(4, '0');

                                glb_dts_Generel.tbl_Employee.Addtbl_EmployeeRow(oEmployee.Employee_ID.PadLeft(4, '0'), sEPF_No, oEmployee.Employee_ID2, oEmployee.Title, oEmployee.SurName, oEmployee.Initails,
                                    oEmployee.FullName, oEmployee.AliasName, oEmployee.DivisionName, oEmployee.DepartmentName, oEmployee.Section_Name, oEmployee.SubSectionName, oEmployee.NicNo,
                                    oEmployee.DrivingLic_No, oEmployee.PassportNo, oEmployee.Nationality, oEmployee.Religion, oEmployee.DateOfBirth.ToString(clsConfig.Format_Date), ((Gender)oEmployee.Gender).ToString(),
                                    ((CivilState)oEmployee.CivilState).ToString(), oEmployee.Employee_Image, oEmployee.DateJoin.Date.ToString() == clsConfig.defaultDateTime.Date.ToString() ? "-" : oEmployee.DateJoin.Date.ToString(clsConfig.Format_Date2), oEmployee.DateConfirm.Date.ToString() == clsConfig.defaultDateTime.Date.ToString() ? "-" : oEmployee.DateConfirm.Date.ToString(clsConfig.Format_Date2),
                                    oEmployee.DateOfMerrage.Date.ToString() == clsConfig.defaultDateTime.Date.ToString() ? "-" : oEmployee.DateOfMerrage.Date.ToString(clsConfig.Format_Date),
                                    oEmployee.VisaEndDate.Date.ToString(clsConfig.Format_Date) == clsConfig.defaultDateTime.Date.ToString() ? "-" : oEmployee.VisaEndDate.Date.ToString(clsConfig.Format_Date),
                                    oEmployee.DateTerminate.ToString(clsConfig.Format_Date), oEmployee.LastWorkingDate.ToString(clsConfig.Format_Date) == clsConfig.defaultDateTime.ToString() ? "-" : oEmployee.LastWorkingDate.ToString(clsConfig.Format_Date),
                                    oEmployee.Emp_statusID, oEmployee.Designation_name, oEmployee.EmpCatagory1_Name, oEmployee.EmpCatagory2_Name, oEmployee.EmpCatagory3_Name, oEmployee.RecuirtmentType, oEmployee.ManagerID,
                                    oEmployee.SupevisorID, oEmployee.Mobile_Office, oEmployee.Mobile1, oEmployee.Email_office, oEmployee.Telephone_Office, oEmployee.Telephone_Ext, oEmployee.AddressLine1, oEmployee.AddressLine2,
                                    oEmployee.AddressLine3, oEmployee.Bank_ID == "Default" ? "-" : oEmployee.Bank_ID, oEmployee.BankName == "Default" ? "-" : oEmployee.BankName, oEmployee.BankBranch_Code == "Default" ? "-" : oEmployee.BankBranch_Code,
                                    oEmployee.BranchName == "Default" ? "-" : oEmployee.BranchName, oEmployee.Employee_AccountNo, oEmployee.Employee_AccountName);

                                if (Report == enum_ReportName.Employee_Service_Record)
                                {
                                    dBasicSalary = clsHelpMethods.GetPaySlipItemAmount_FromMas(oEmployee.Employee_ID, clsConfig.sBasicSalary);
                                    dBRA1 = clsHelpMethods.GetPaySlipItemAmount_FromMas(oEmployee.Employee_ID, clsConfig.sBRA1);
                                    dBRA2 = clsHelpMethods.GetPaySlipItemAmount_FromMas(oEmployee.Employee_ID, clsConfig.sBRA2);
                                    dBRA3 = clsHelpMethods.GetPaySlipItemAmount_FromMas(oEmployee.Employee_ID, clsConfig.sBRA3);
                                    dTravellingallowance = clsHelpMethods.GetPaySlipItemAmount_FromMas(oEmployee.Employee_ID, clsConfig.sTravellingAllowance);
                                    dSpecialAllowances = clsHelpMethods.GetPaySlipItemAmount_FromMas(oEmployee.Employee_ID, clsConfig.sAllowance1);

                                    glb_dts_Generel.tbl_Employee_ServiceDetails.Addtbl_Employee_ServiceDetailsRow(oEmployee.Employee_ID, "", dBasicSalary, dBRA1, dBRA2, dBRA3, dTravellingallowance, dSpecialAllowances, dtmToDate, oEmployee.DateJoin, oEmployee.DateJoin.Year, oEmployee.DateConfirm);
                                }
                            }

                            if (Report == enum_ReportName.Employee_Retirement_Record)
                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("ToDate", dtmToDate.ToShortDateString(), true);

                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_Generel, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }
                        #endregion
                        #endregion

                        #region TAS REPORTS
                        #region Device Raw Data Employee Wise
                        else if (Report == enum_ReportName.Device_Raw_Data_Employee_Wise)
                        {
                            DataSets.dts_TAS glb_dts_TAS = new DataSets.dts_TAS();
                            //glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #region Company Data Set Fill
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #endregion

                            #region Filters
                            #region Employee Filter
                            List<sp_genMasEmployee> oEmployees;
                            if (bEmployeeSelected)
                            {
                                oEmployees = new List<sp_genMasEmployee>();
                                oEmployees.Add(sp_genMasEmployee.Select(txtEmployee.Tag.ToString()));
                            }
                            else
                                oEmployees = sp_genMasEmployee.SelectAll().Where(p => p.Employee_ID != "default" && p.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString()).ToList();
                            #endregion

                            if (bDesignationSelected)
                                oEmployees = oEmployees.Where(p => p.Designation_ID == txtDesignation.Tag.ToString()).ToList();

                            if (bDivisionSelected)
                                oEmployees = oEmployees.Where(p => p.Division_ID == txtDivision.Tag.ToString()).ToList();

                            if (bDepartmentSelected)
                                oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();

                            if (bSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();

                            if (bSubSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SubSectionID == txtSubSection.Tag.ToString()).ToList();

                            if (bEmpCategory1Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();

                            if (bEmpCategory2Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();

                            if (bEmpCategory3Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();
                            #endregion

                            foreach (sp_genMasEmployee oemp in oEmployees)
                            {
                                foreach (sp_tasDevice_RawData oDRD in sp_tasDevice_RawData.SelectAll("%", oemp.Employee_ID2, dtp_FromDate.GetDateTime().Date, dtp_ToDate.GetDateTime().Date).Where(p => p.Device_empID != null && p.Device_empID != "0"))
                                {
                                    glb_dts_TAS.dt_rptDeviceRawData.Adddt_rptDeviceRawDataRow(oDRD.Device_DateTime, oDRD.Device_empID, oemp.SurName + " " + oemp.Initails, oDRD.Device_ID, oDRD.Device_Name, oemp.Department_ID, oemp.DepartmentName, oDRD.Device_DateTime.ToString(clsConfig.Format_DateTime));
                                }
                            }

                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_TAS, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }
                        #endregion

                        #region Attendance Summary Report-EmployeeWise / TW Attendance sheet - Check Roll / AttendanceSummary_EmployeeWise_Detail
                        else if (Report == enum_ReportName.AttendanceSummary_EmployeeWise || Report == enum_ReportName.CheckRoll_LabourersEmployed || Report == enum_ReportName.AttendanceSummary_EmployeeWise_Detail)
                        {
                            string sEmployeeID = "%";
                            string sDivisionID = "%";
                            string sDepatmentID = "%";
                            string sSectionID = "%";
                            string sEmpCategoryID = "%";

                            #region Filters
                            if (bEmployeeSelected)
                                sEmployeeID = txtEmployee.Tag.ToString();

                            if (bDivisionSelected)
                                sDivisionID = txtDivision.Tag.ToString();

                            if (bDepartmentSelected)
                                sDepatmentID = txtDepartment.Tag.ToString();

                            if (bSectionSelected)
                                sSectionID = txtSection.Tag.ToString();

                            if (bEmpCategory1Selected)
                                sEmpCategoryID = txtEmpCategory1.Tag.ToString();
                            #endregion

                            DataSets.dts_TAS glb_dts_TAS = new DataSets.dts_TAS();

                            #region Company Data Set Fill
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #endregion

                            string sQuary = "exec [sp_RPT_AttendanceSummary_EmployeeWise] 'Company1','default','" + dtp_FromDate.GetDateTime().Date + "','" + dtp_ToDate.GetDateTime().Date + "','" + sEmployeeID + "','" + sDivisionID + "','" + sDepatmentID + "','" + sSectionID + "', '" + sEmpCategoryID + "'";

                            #region DTQ Attendance Sheet - EmployeeWise / AttendanceSummary_EmployeeWise_Detail
                            if (Report == enum_ReportName.AttendanceSummary_EmployeeWise || Report == enum_ReportName.AttendanceSummary_EmployeeWise_Detail)
                            {
                                glb_dts_TAS.tbl_tasTxDailyAttendance.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                                if (Report == enum_ReportName.AttendanceSummary_EmployeeWise_Detail)
                                {
                                    #region Gate Pass Details
                                    foreach (tbl_tasTxGatePass oGatePass in tbl_tasTxGatePass.SelectAll().Where(p => p.GatePass_DateTime.Date >= dtp_FromDate.GetDateTime().Date && p.GatePass_DateTime.Date <= dtp_ToDate.GetDateTime().Date))
                                    {
                                        glb_dts_TAS.tbl_tasTxDailyAttendance_Detail.Addtbl_tasTxDailyAttendance_DetailRow(oGatePass.GatePass_ID, oGatePass.GatePass_DateTime.Date, "Gate Pass", oGatePass.Employee_ID, (oGatePass.Leave_Hours), oGatePass.Reason, clsRef_Name.get_EmployeeAliasName(oGatePass.UserID_Supevisor), clsRef_Name.get_EmployeeAliasName(oGatePass.UserID_Manager), "");
                                    }
                                    #endregion

                                    #region Leave Details
                                    string sLeaveStatus = "Pending";
                                    foreach (tbl_tasEmployeeLeaveCard oLeaveCard in tbl_tasEmployeeLeaveCard.SelectAll().Where(p => p.Leave_Start.Date >= dtp_FromDate.GetDateTime().Date && p.Leave_End.Date <= dtp_ToDate.GetDateTime().Date && !p.IsCancled))
                                    {
                                        if (oLeaveCard.UserID_CP1 != "" && oLeaveCard.UserID_CP2 != "")
                                        {
                                            if (oLeaveCard.ApprovalStatus_CP1 == 1 && oLeaveCard.ApprovalStatus_CP2 == 1 && oLeaveCard.ApprovalStatus_Manager == 1 && oLeaveCard.ApprovalStatus_Supevosior == 1)
                                            {
                                                sLeaveStatus = "Approved";
                                            }
                                        }
                                        else
                                        {
                                            if (oLeaveCard.ApprovalStatus_Manager == 1 && oLeaveCard.ApprovalStatus_Supevosior == 1 && (oLeaveCard.ApprovalStatus_CP1 == 1 || oLeaveCard.ApprovalStatus_CP2 == 1))
                                            {
                                                sLeaveStatus = "Approved";
                                            }
                                        }
                                        TimeSpan tsTemp = oLeaveCard.Leave_End - oLeaveCard.Leave_Start;
                                        glb_dts_TAS.tbl_tasTxDailyAttendance_Detail.Addtbl_tasTxDailyAttendance_DetailRow(oLeaveCard.Leave_ID, oLeaveCard.Leave_Start.Date, clsRef_Name.get_leaveType_Name(oLeaveCard.LeaveType_ID), oLeaveCard.Employee_ID, tsTemp.Hours * 60 + tsTemp.Minutes, oLeaveCard.Reason, clsRef_Name.get_EmployeeAliasName(oLeaveCard.UserID_Supevisor), clsRef_Name.get_EmployeeAliasName(oLeaveCard.UserID_Manager), sLeaveStatus);

                                    }
                                    #endregion
                                }

                                #region Formular Fields
                                if (clsConfig.bHideCompanyImageInReports)
                                    glb_dts_ExportReport.dt_rptParameter.Rows.Add("ShowImage", "false", true);
                                #endregion

                                //frm_ReportViwer CRViwer = new frm_ReportViwer();
                                //CRViwer.Print(oReport.ReportPath, glb_dts_TAS, glb_dts_ExportReport.dt_rptParameter);

                                frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                                frmViewer.print(oReport.ReportPath, glb_dts_TAS, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                            }
                            #endregion

                            #region TW Attendance Sheet - Checkroll - Added by Gayan 2016.06.14
                            else if (Report == enum_ReportName.CheckRoll_LabourersEmployed)
                            {
                                #region Check Roll Data table
                                DataTable dtCheckRoll = new DataTable();
                                dtCheckRoll.Columns.Add("Company_ID", typeof(string));
                                dtCheckRoll.Columns.Add("CompanyBranch_ID", typeof(string));
                                dtCheckRoll.Columns.Add("Employee_ID", typeof(string));
                                dtCheckRoll.Columns.Add("EmployeeName", typeof(string));
                                dtCheckRoll.Columns.Add("D1", typeof(string));
                                dtCheckRoll.Columns.Add("D2", typeof(string));
                                dtCheckRoll.Columns.Add("D3", typeof(string));
                                dtCheckRoll.Columns.Add("D4", typeof(string));
                                dtCheckRoll.Columns.Add("D5", typeof(string));
                                dtCheckRoll.Columns.Add("D6", typeof(string));
                                dtCheckRoll.Columns.Add("D7", typeof(string));
                                dtCheckRoll.Columns.Add("D8", typeof(string));
                                dtCheckRoll.Columns.Add("D9", typeof(string));
                                dtCheckRoll.Columns.Add("D10", typeof(string));
                                dtCheckRoll.Columns.Add("D11", typeof(string));
                                dtCheckRoll.Columns.Add("D12", typeof(string));
                                dtCheckRoll.Columns.Add("D13", typeof(string));
                                dtCheckRoll.Columns.Add("D14", typeof(string));
                                dtCheckRoll.Columns.Add("D15", typeof(string));
                                dtCheckRoll.Columns.Add("D16", typeof(string));
                                dtCheckRoll.Columns.Add("D17", typeof(string));
                                dtCheckRoll.Columns.Add("D18", typeof(string));
                                dtCheckRoll.Columns.Add("D19", typeof(string));
                                dtCheckRoll.Columns.Add("D20", typeof(string));
                                dtCheckRoll.Columns.Add("D21", typeof(string));
                                dtCheckRoll.Columns.Add("D22", typeof(string));
                                dtCheckRoll.Columns.Add("D23", typeof(string));
                                dtCheckRoll.Columns.Add("D24", typeof(string));
                                dtCheckRoll.Columns.Add("D25", typeof(string));
                                dtCheckRoll.Columns.Add("D26", typeof(string));
                                dtCheckRoll.Columns.Add("D27", typeof(string));
                                dtCheckRoll.Columns.Add("D28", typeof(string));
                                dtCheckRoll.Columns.Add("D29", typeof(string));
                                dtCheckRoll.Columns.Add("D30", typeof(string));
                                dtCheckRoll.Columns.Add("D31", typeof(string));
                                dtCheckRoll.Columns.Add("TotalWorkMins", typeof(decimal));
                                #endregion

                                DataTable dtAttendanceDetails = new DataTable();
                                dtAttendanceDetails = DBHandling.ExecQuery(sQuary).Tables[0];
                                var empNums = dtAttendanceDetails.AsEnumerable().Select(s => new { id = s.Field<string>("Employee_ID"), ename = s.Field<string>("EmployeeName") }).Distinct().ToList();
                                string dTS = TimeSpan.FromMinutes(0).ToString(@"hh\:mm");

                                foreach (var empNum in empNums)
                                {
                                    dtCheckRoll.Rows.Add("", "", empNum.id, empNum.ename, dTS, dTS, dTS, dTS, dTS, dTS, dTS, dTS, dTS, dTS, dTS, dTS, dTS, dTS, dTS, dTS, dTS, dTS, dTS, dTS, dTS, dTS, dTS, dTS, dTS, dTS, dTS, dTS, dTS, dTS, dTS, 0);
                                }

                                foreach (DataRow rowAttendanceDetails in dtAttendanceDetails.Rows)
                                {
                                    DataRow[] rowCheckRoll = dtCheckRoll.Select("Employee_ID = '" + rowAttendanceDetails["Employee_ID"].ToString() + "'");

                                    #region set worked hrs
                                    if (rowCheckRoll != null)
                                        if (rowCheckRoll.Length > 0)
                                        {
                                            int day = ((DateTime)rowAttendanceDetails["AttendenceDate"]).Day;

                                            decimal workedMins = (int)rowAttendanceDetails["WorkedMinutes"];
                                            decimal totWM = (decimal)rowCheckRoll[0]["TotalWorkMins"];
                                            totWM += workedMins;
                                            rowCheckRoll[0]["TotalWorkMins"] = totWM;

                                            string workedHrs = TimeSpan.FromMinutes((int)rowAttendanceDetails["WorkedMinutes"]).ToString(@"hh\:mm");
                                            switch (day)
                                            {
                                                case 1:
                                                    rowCheckRoll[0]["D1"] = workedHrs;
                                                    break;
                                                case 2:
                                                    rowCheckRoll[0]["D2"] = workedHrs;
                                                    break;
                                                case 3:
                                                    rowCheckRoll[0]["D3"] = workedHrs;
                                                    break;
                                                case 4:
                                                    rowCheckRoll[0]["D4"] = workedHrs;
                                                    break;
                                                case 5:
                                                    rowCheckRoll[0]["D5"] = workedHrs;
                                                    break;
                                                case 6:
                                                    rowCheckRoll[0]["D6"] = workedHrs;
                                                    break;
                                                case 7:
                                                    rowCheckRoll[0]["D7"] = workedHrs;
                                                    break;
                                                case 8:
                                                    rowCheckRoll[0]["D8"] = workedHrs;
                                                    break;
                                                case 9:
                                                    rowCheckRoll[0]["D9"] = workedHrs;
                                                    break;
                                                case 10:
                                                    rowCheckRoll[0]["D10"] = workedHrs;
                                                    break;
                                                case 11:
                                                    rowCheckRoll[0]["D11"] = workedHrs;
                                                    break;
                                                case 12:
                                                    rowCheckRoll[0]["D12"] = workedHrs;
                                                    break;
                                                case 13:
                                                    rowCheckRoll[0]["D13"] = workedHrs;
                                                    break;
                                                case 14:
                                                    rowCheckRoll[0]["D14"] = workedHrs;
                                                    break;
                                                case 15:
                                                    rowCheckRoll[0]["D15"] = workedHrs;
                                                    break;
                                                case 16:
                                                    rowCheckRoll[0]["D16"] = workedHrs;
                                                    break;
                                                case 17:
                                                    rowCheckRoll[0]["D17"] = workedHrs;
                                                    break;
                                                case 18:
                                                    rowCheckRoll[0]["D18"] = workedHrs;
                                                    break;
                                                case 19:
                                                    rowCheckRoll[0]["D19"] = workedHrs;
                                                    break;
                                                case 20:
                                                    rowCheckRoll[0]["D20"] = workedHrs;
                                                    break;
                                                case 21:
                                                    rowCheckRoll[0]["D21"] = workedHrs;
                                                    break;
                                                case 22:
                                                    rowCheckRoll[0]["D22"] = workedHrs;
                                                    break;
                                                case 23:
                                                    rowCheckRoll[0]["D23"] = workedHrs;
                                                    break;
                                                case 24:
                                                    rowCheckRoll[0]["D24"] = workedHrs;
                                                    break;
                                                case 25:
                                                    rowCheckRoll[0]["D25"] = workedHrs;
                                                    break;
                                                case 26:
                                                    rowCheckRoll[0]["D26"] = workedHrs;
                                                    break;
                                                case 27:
                                                    rowCheckRoll[0]["D27"] = workedHrs;
                                                    break;
                                                case 28:
                                                    rowCheckRoll[0]["D28"] = workedHrs;
                                                    break;
                                                case 29:
                                                    rowCheckRoll[0]["D29"] = workedHrs;
                                                    break;
                                                case 30:
                                                    rowCheckRoll[0]["D30"] = workedHrs;
                                                    break;
                                                case 31:
                                                    rowCheckRoll[0]["D31"] = workedHrs;
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                    #endregion
                                }

                                List<string> days = clsCommon.getCompanyDays(dtmFromDate, dtmToDate);
                                glb_dts_TAS.tbl_tasTxAttendanceMonthDays.Rows.Add(days.ToArray());

                                glb_dts_TAS.tbl_tasTxAttendanceCheckRoll.Merge(dtCheckRoll);

                                //frm_ReportViwer CRViwer = new frm_ReportViwer();
                                //CRViwer.Print(oReport.ReportPath, glb_dts_TAS, glb_dts_ExportReport.dt_rptParameter);

                                frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                                frmViewer.print(oReport.ReportPath, glb_dts_TAS, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                            }
                            #endregion
                        }
                        #endregion

                        #region Daily Absenteeism Report
                        else if (Report == enum_ReportName.Daily_Absenteeism_Report)
                        {
                            DataSets.dts_TAS glb_dts_TAS = new DataSets.dts_TAS();
                            //glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #region Company Data Set Fill
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #endregion

                            #region Filters
                            #region Employee Filter
                            List<tbl_genMasEmployee> oEmployees; 
                            if (bEmployeeSelected)
                            {
                                oEmployees = new List<tbl_genMasEmployee>();
                                oEmployees.Add(tbl_genMasEmployee.Select(txtEmployee.Tag.ToString(), clsSecurity.CompanyID, clsSecurity.BranchID));
                            }
                            else
                                oEmployees = tbl_genMasEmployee.SelectAll().Where(p => p.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString()).ToList();
                            #endregion

                            if (bDesignationSelected)
                                oEmployees = oEmployees.Where(p => p.Designation_ID == txtDesignation.Tag.ToString()).ToList();

                            if (bDivisionSelected)
                                oEmployees = oEmployees.Where(p => p.Division_ID == txtDivision.Tag.ToString()).ToList();

                            if (bDepartmentSelected)
                                oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();

                            if (bSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();

                            if (bSubSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SubSectionID == txtSubSection.Tag.ToString()).ToList();

                            if (bEmpCategory1Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();

                            if (bEmpCategory2Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();

                            if (bEmpCategory3Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();
                            #endregion

                            foreach (tbl_genMasEmployee oEmployee in oEmployees.Where(p => p.IsTime_Attendance == true))
                            {
                                for (DateTime date = dtmFromDate.Date; date <= dtmToDate.Date; date = date.AddDays(1))
                                {
                                    #region day type
                                    string sDaytype = "WD";
                                    if (date.DayOfWeek == DayOfWeek.Sunday)
                                        sDaytype = "SU";
                                    if (date.DayOfWeek == DayOfWeek.Saturday)
                                        sDaytype = "SA";
                                    #endregion

                                    #region Variables for Shift
                                    DateTime dDate = date.Date;
                                    string sShiftId = "";
                                    string sShiftName = "";
                                    ShiftTypes enmShiftType = ShiftTypes.OneDayShift;
                                    int iShiftDay = 0;
                                    string sPriviusShift = "";
                                    bool bShiftSpecialParameeter1 = false;
                                    bool bShiftSpecialParameeter2 = false;
                                    int iShiftMinutes = 0;
                                    int iShiftMinutes_Min = 0;
                                    int iNextShift_Minutes = 0;
                                    int iShiftGracePeriod = 0;
                                    DateTime dtmShiftStart = clsValidation.defaultDateTime;
                                    DateTime dtmShiftEnd = clsValidation.defaultDateTime;
                                    string sShiftStart = "";
                                    string sShiftEnd = "";
                                    holidayDurationType hdt = holidayDurationType.N_A;
                                    List<tbl_tasHolidayCalander> oHolidays = tbl_tasHolidayCalander.SelectAllByHolyday_Date(dtmFromDate.Date, dtmToDate.Date).Where(p => p.Holiday_Status).ToList();
                                    foreach (tbl_tasHolidayCalander oCal in oHolidays.Where(p => p.Holiday_Date.Date == dDate.Date && !p.IsCanceled))
                                    {
                                        hdt = (holidayDurationType)oCal.HolidayDurationType;
                                    }
                                    clsHelpMethods.GetShift(dDate, oEmployee.Employee_ID, oEmployee.IsRosterBasedEmployee,  hdt, ref sShiftId, ref sShiftName, ref enmShiftType, ref iShiftDay, ref sPriviusShift, ref bShiftSpecialParameeter1, ref bShiftSpecialParameeter2, ref iShiftMinutes, ref iShiftMinutes_Min, ref iNextShift_Minutes, ref iShiftGracePeriod, ref dtmShiftStart, ref dtmShiftEnd, ref sShiftStart, ref sShiftEnd);
                                    #endregion

                                    switch (enmShiftType)
                                    {
                                        #region Midnight Cross Shift
                                        case ShiftTypes.MidnightCross:
                                            {
                                                //DataTable dtResult_MidnightCrossShift = DBHandling.ExecQuery("sp_GetInOutTimeFromDate '" + oEmployee.Employee_ID2 + "' , '" + dDate.Date.AddHours(12) + "' , '" + dDate.Date.AddHours(36) + "'").Tables[0];
                                                DataTable dtResult_MidnightCrossShift = DBHandling.ExecQuery("sp_GetInOutTimeFromDate '" + oEmployee.Employee_ID2 + "' , '" + dtmShiftStart.AddHours(-2) + "' , '" + dtmShiftEnd.AddHours(9) + "'").Tables[0];
                                                clsHelpMethods.Validate_InOutTime_DataTable(ref dtResult_MidnightCrossShift);
                                                if (iShiftMinutes > 0)
                                                {
                                                    if (dtResult_MidnightCrossShift != null && dtResult_MidnightCrossShift.Rows.Count == 0)
                                                        glb_dts_TAS.dt_DailyAbsenteeism.Adddt_DailyAbsenteeismRow(date.ToString(clsConfig.Format_Date), sDaytype, date.ToString(clsConfig.Format_Time) == clsConfig.defaultDateTime.ToString(clsConfig.Format_Time) ? "-" : date.ToString(clsConfig.Format_Time), oEmployee.Employee_ID, oEmployee.EpfNo, sShiftId, "", oEmployee.SurName + " " + oEmployee.Initails, oEmployee.Initails, oEmployee.AliasName, clsRef_Name.get_Designation_Name(oEmployee.Designation_ID), oEmployee.Mobile1, oEmployee.SupevisorID == "default" ? "-" : clsRef_Name.get_EmployeeAliasName(oEmployee.SupevisorID), oEmployee.ManagerID == "default" ? "- " : clsRef_Name.get_EmployeeAliasName(oEmployee.ManagerID), oEmployee.Department_ID, clsRef_Name.get_Department_Name(oEmployee.Department_ID));
                                                }
                                            }
                                            break;
                                        #endregion

                                        #region Two Day Shift
                                        case ShiftTypes.TwoDayShift:
                                            {
                                                //DataTable dtResult_MidnightCrossShift = DBHandling.ExecQuery("sp_GetInOutTimeFromDate '" + oEmployee.Employee_ID2 + "' , '" + dDate.Date.AddHours(0) + "' , '" + dDate.Date.AddHours(48) + "'").Tables[0];
                                                DataTable dtResult_MidnightCrossShift = DBHandling.ExecQuery("sp_GetInOutTimeFromDate '" + oEmployee.Employee_ID2 + "' , '" + dtmShiftStart.AddHours(-2) + "' , '" + dtmShiftStart.AddHours(iShiftMinutes + 9) + "'").Tables[0];
                                                clsHelpMethods.Validate_InOutTime_DataTable(ref dtResult_MidnightCrossShift);

                                                if (dtResult_MidnightCrossShift != null && dtResult_MidnightCrossShift.Rows.Count == 0)
                                                    glb_dts_TAS.dt_DailyAbsenteeism.Adddt_DailyAbsenteeismRow(date.ToString(clsConfig.Format_Date), sDaytype, date.ToString(clsConfig.Format_Time) == clsConfig.defaultDateTime.ToString(clsConfig.Format_Time) ? "-" : date.ToString(clsConfig.Format_Time), oEmployee.Employee_ID, oEmployee.EpfNo, sShiftId, "", oEmployee.SurName + " " + oEmployee.Initails, oEmployee.Initails, oEmployee.AliasName, clsRef_Name.get_Designation_Name(oEmployee.Designation_ID), oEmployee.Mobile1, oEmployee.SupevisorID == "default" ? "-" : clsRef_Name.get_EmployeeAliasName(oEmployee.SupevisorID), oEmployee.ManagerID == "default" ? "- " : clsRef_Name.get_EmployeeAliasName(oEmployee.ManagerID), oEmployee.Department_ID, clsRef_Name.get_Department_Name(oEmployee.Department_ID));
                                            }
                                            break;
                                        #endregion

                                        #region One Day Shifts
                                        default:
                                            {
                                                DataTable dtResults = DBHandling.ExecQuery("sp_GetInOutTimeFromDate '" + oEmployee.Employee_ID2 + "' , '" + dtmShiftStart.Date + "' , '" + dtmShiftEnd.Date.AddDays(1).Date + "'").Tables[0];
                                                clsHelpMethods.Validate_InOutTime_DataTable(ref dtResults);
                                                if (iShiftMinutes > 0)
                                                {
                                                    if (dtResults != null && dtResults.Rows.Count == 0)
                                                    {
                                                        switch (enmShiftType)
                                                        {
                                                            #region Flexible
                                                            case ShiftTypes.FlexibalShift:
                                                            case ShiftTypes.OneDayShift:
                                                                glb_dts_TAS.dt_DailyAbsenteeism.Adddt_DailyAbsenteeismRow(date.ToString(clsConfig.Format_Date), sDaytype, date.ToString(clsConfig.Format_Time) == clsConfig.defaultDateTime.ToString(clsConfig.Format_Time) ? "-" : date.ToString(clsConfig.Format_Time), oEmployee.Employee_ID, oEmployee.EpfNo, sShiftId, "", oEmployee.SurName + " " + oEmployee.Initails, oEmployee.Initails, oEmployee.AliasName, clsRef_Name.get_Designation_Name(oEmployee.Designation_ID), oEmployee.Mobile1, oEmployee.SupevisorID == "default" ? "-" : clsRef_Name.get_EmployeeAliasName(oEmployee.SupevisorID), oEmployee.ManagerID == "default" ? "- " : clsRef_Name.get_EmployeeAliasName(oEmployee.ManagerID), oEmployee.Department_ID, clsRef_Name.get_Department_Name(oEmployee.Department_ID));
                                                                break;
                                                                #endregion
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                            #endregion
                                    }
                                }
                            }

                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_TAS, glb_dts_ExportReport.dt_rptParameter, oUserPermission);

                        }
                        #endregion

                        #region Daily Missed Punch New
                        else if (Report == enum_ReportName.Daily_MissedPunchReport_New)
                        {
                            DataSets.dts_TAS glb_dts_TAS = new DataSets.dts_TAS();
                            //glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #region Company Data Set Fill
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #endregion

                            #region Filters
                            #region Employee Filter
                            List<tbl_genMasEmployee> oEmployees;
                            if (bEmployeeSelected)
                            {
                                oEmployees = new List<tbl_genMasEmployee>();
                                oEmployees.Add(tbl_genMasEmployee.Select(txtEmployee.Tag.ToString(), clsSecurity.CompanyID, clsSecurity.BranchID));
                            }
                            else
                                oEmployees = tbl_genMasEmployee.SelectAll().Where(p => p.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString()).ToList();
                            #endregion

                            if (bDesignationSelected)
                                oEmployees = oEmployees.Where(p => p.Designation_ID == txtDesignation.Tag.ToString()).ToList();

                            if (bDivisionSelected)
                                oEmployees = oEmployees.Where(p => p.Division_ID == txtDivision.Tag.ToString()).ToList();

                            if (bDepartmentSelected)
                                oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();

                            if (bSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();

                            if (bSubSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SubSectionID == txtSubSection.Tag.ToString()).ToList();

                            if (bEmpCategory1Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();

                            if (bEmpCategory2Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();

                            if (bEmpCategory3Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();
                            #endregion

                            string sPrevShiftID = "";
                            foreach (tbl_genMasEmployee oEmployee in oEmployees.Where(p => p.IsCanceled == false && p.IsTime_Attendance == true))
                            {
                                for (DateTime date = dtmFromDate.Date; date <= dtmToDate.Date; date = date.AddDays(1))
                                {
                                    #region day type
                                    string sDaytype = "WD";
                                    if (date.DayOfWeek == DayOfWeek.Sunday)
                                        sDaytype = "SU";
                                    if (date.DayOfWeek == DayOfWeek.Saturday)
                                        sDaytype = "SA";
                                    #endregion

                                    #region Variables for Shift
                                    DateTime dtmMissPunchDateTime = clsConfig.defaultDateTime;
                                    DateTime dDate = date.Date;
                                    string sShiftId = "";
                                    string sShiftName = "";
                                    ShiftTypes enmShiftType = ShiftTypes.OneDayShift;
                                    int iShiftDay = 0;
                                    string sPriviusShift = "";
                                    bool bShiftSpecialParameeter1 = false;
                                    bool bShiftSpecialParameeter2 = false;
                                    int iShiftMinutes = 0;
                                    int iShiftMinutes_Min = 0;
                                    int iNextShift_Minutes = 0;
                                    int iShiftGracePeriod = 0;
                                    DateTime dtmShiftStart = clsValidation.defaultDateTime;
                                    DateTime dtmShiftEnd = clsValidation.defaultDateTime;
                                    string sShiftStart = "";
                                    string sShiftEnd = "";
                                    holidayDurationType hdt = holidayDurationType.N_A;
                                    List<tbl_tasHolidayCalander> oHolidays = tbl_tasHolidayCalander.SelectAllByHolyday_Date(dtmFromDate.Date, dtmToDate.Date).Where(p => p.Holiday_Status).ToList();
                                    foreach (tbl_tasHolidayCalander oCal in oHolidays.Where(p => p.Holiday_Date.Date == dDate.Date && !p.IsCanceled))
                                    {
                                        hdt = (holidayDurationType)oCal.HolidayDurationType;
                                    }
                                    #endregion

                                    #region Get Shift based on Roster or Shift Adjustment
                                    clsHelpMethods.GetShift(dDate, oEmployee.Employee_ID, oEmployee.IsRosterBasedEmployee, hdt, ref sShiftId, ref sShiftName, ref enmShiftType, ref iShiftDay, ref sPriviusShift, ref bShiftSpecialParameeter1, ref bShiftSpecialParameeter2, ref iShiftMinutes, ref iShiftMinutes_Min, ref iNextShift_Minutes, ref iShiftGracePeriod, ref dtmShiftStart, ref dtmShiftEnd, ref sShiftStart, ref sShiftEnd);
                                    #endregion

                                    bool bNotMidNightCrossShift = false;
                                    switch (enmShiftType)
                                    {
                                        #region Midnight Cross Shift
                                        case ShiftTypes.MidnightCross:
                                            {
                                                //DataTable dtResult_MidnightCrossShift = DBHandling.ExecQuery("sp_GetInOutTimeFromDate '" + oEmployee.Employee_ID2 + "' , '" + dDate.Date.AddHours(12) + "' , '" + dDate.Date.AddHours(36) + "'").Tables[0];
                                                DataTable dtResult_MidnightCrossShift = DBHandling.ExecQuery("sp_GetInOutTimeFromDate '" + oEmployee.Employee_ID2 + "' , '" + dtmShiftStart.AddHours(-2) + "' , '" + dtmShiftEnd.AddHours(9) + "'").Tables[0];
                                                clsHelpMethods.Validate_InOutTime_DataTable(ref dtResult_MidnightCrossShift);
                                                if (iShiftMinutes > 0)
                                                {
                                                    if (dtResult_MidnightCrossShift != null && dtResult_MidnightCrossShift.Rows.Count == 1)
                                                    {
                                                        DateTime dtm_firstRec = DateTime.Parse(dtResult_MidnightCrossShift.Rows[0]["device_DateTime"].ToString());
                                                        dtmMissPunchDateTime = dtm_firstRec;
                                                        glb_dts_TAS.dt_DailyAbsenteeism.Adddt_DailyAbsenteeismRow(date.ToString(clsConfig.Format_Date), sDaytype, dtmMissPunchDateTime.ToString(clsConfig.Format_Time) == clsConfig.defaultDateTime.ToString(clsConfig.Format_Time) ? "-" : dtmMissPunchDateTime.ToString(clsConfig.Format_Time), oEmployee.Employee_ID, oEmployee.EpfNo, sShiftId, "", oEmployee.SurName + " " + oEmployee.Initails, oEmployee.Initails, oEmployee.AliasName, clsRef_Name.get_Designation_Name(oEmployee.Designation_ID), oEmployee.Mobile1, oEmployee.SupevisorID == "default" ? "-" : clsRef_Name.get_EmployeeAliasName(oEmployee.SupevisorID), oEmployee.ManagerID == "default" ? "- " : clsRef_Name.get_EmployeeAliasName(oEmployee.ManagerID), oEmployee.Department_ID, clsRef_Name.get_Department_Name(oEmployee.Department_ID));
                                                    }
                                                }
                                            }
                                            break;
                                        #endregion

                                        #region Two Day Shift
                                        case ShiftTypes.TwoDayShift:
                                            {
                                                DataTable dtResult_TwoDayShift = DBHandling.ExecQuery("sp_GetInOutTimeFromDate '" + oEmployee.Employee_ID2 + "' , '" + dtmShiftStart.AddHours(-2) + "' , '" + dtmShiftStart.AddHours(iShiftMinutes + 9) + "'").Tables[0];
                                                //DataTable dtResult_MidnightCrossShift = DBHandling.ExecQuery("sp_GetInOutTimeFromDate '" + oEmployee.Employee_ID2 + "' , '" + dDate.Date.AddHours(0) + "' , '" + dDate.Date.AddHours(48) + "'").Tables[0];
                                                clsHelpMethods.Validate_InOutTime_DataTable(ref dtResult_TwoDayShift);
                                                if (dtResult_TwoDayShift != null && dtResult_TwoDayShift.Rows.Count == 1)
                                                {
                                                    DateTime dtm_firstRec = DateTime.Parse(dtResult_TwoDayShift.Rows[0]["device_DateTime"].ToString());
                                                    dtmMissPunchDateTime = dtm_firstRec;
                                                    glb_dts_TAS.dt_DailyAbsenteeism.Adddt_DailyAbsenteeismRow(date.ToString(clsConfig.Format_Date), sDaytype, dtmMissPunchDateTime.ToString(clsConfig.Format_Time) == clsConfig.defaultDateTime.ToString(clsConfig.Format_Time) ? "-" : dtmMissPunchDateTime.ToString(clsConfig.Format_Time), oEmployee.Employee_ID, oEmployee.EpfNo, sShiftId, "", oEmployee.SurName + " " + oEmployee.Initails, oEmployee.Initails, oEmployee.AliasName, clsRef_Name.get_Designation_Name(oEmployee.Designation_ID), oEmployee.Mobile1, oEmployee.SupevisorID == "default" ? "-" : clsRef_Name.get_EmployeeAliasName(oEmployee.SupevisorID), oEmployee.ManagerID == "default" ? "- " : clsRef_Name.get_EmployeeAliasName(oEmployee.ManagerID), oEmployee.Department_ID, clsRef_Name.get_Department_Name(oEmployee.Department_ID));
                                                }
                                            }
                                            break;
                                        #endregion

                                        #region One Day Shifts
                                        default:
                                            {
                                                DataTable dtResults = DBHandling.ExecQuery("sp_GetInOutTimeFromDate '" + oEmployee.Employee_ID2 + "' , '" + dtmShiftStart.Date + "' , '" + dtmShiftStart.Date.AddDays(1).Date + "'").Tables[0];
                                                clsHelpMethods.Validate_InOutTime_DataTable(ref dtResults);

                                                if (iShiftMinutes > 0)
                                                {
                                                    if (dtResults != null && dtResults.Rows.Count == 1)
                                                    {
                                                        switch (enmShiftType)
                                                        {
                                                            #region One Day, Flexible
                                                            case ShiftTypes.FlexibalShift:
                                                            case ShiftTypes.OneDayShift:
                                                                dtmMissPunchDateTime = DateTime.Parse(dtResults.Rows[0]["device_DateTime"].ToString());
                                                                glb_dts_TAS.dt_DailyAbsenteeism.Adddt_DailyAbsenteeismRow(date.ToString(clsConfig.Format_Date), sDaytype, dtmMissPunchDateTime.ToString(clsConfig.Format_Time) == clsConfig.defaultDateTime.ToString(clsConfig.Format_Time) ? "-" : dtmMissPunchDateTime.ToString(clsConfig.Format_Time), oEmployee.Employee_ID, oEmployee.EpfNo, sShiftId, "", oEmployee.SurName + " " + oEmployee.Initails, oEmployee.Initails, oEmployee.AliasName, clsRef_Name.get_Designation_Name(oEmployee.Designation_ID), oEmployee.Mobile1, oEmployee.SupevisorID == "default" ? "-" : clsRef_Name.get_EmployeeAliasName(oEmployee.SupevisorID), oEmployee.ManagerID == "default" ? "- " : clsRef_Name.get_EmployeeAliasName(oEmployee.ManagerID), oEmployee.Department_ID, clsRef_Name.get_Department_Name(oEmployee.Department_ID));
                                                                break;
                                                                #endregion
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                            #endregion
                                    }
                                }
                            }

                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_TAS, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }
                        #endregion

                        #region GatePass Details Report
                        else if (Report == enum_ReportName.GatePassDetails)
                        {
                            DataSets.dts_TAS glb_dts_TAS = new DataSets.dts_TAS();
                            //glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #region Company Data Set Fill
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #endregion

                            #region Employee Filter
                            List<tbl_genMasEmployee> oEmployees;
                            if (txtEmployee.Tag != null)
                                oEmployees = tbl_genMasEmployee.SelectAll().Where(p => p.Employee_ID == txtEmployee.Tag.ToString() && p.Employee_ID != "default").ToList();
                            else
                                oEmployees = tbl_genMasEmployee.SelectAll().Where(p => p.Employee_ID != "default").ToList();
                            #endregion

                            #region Division Filter
                            if (bDivisionSelected)
                            {
                                oEmployees = oEmployees.Where(p => p.Division_ID == txtDivision.Tag.ToString()).ToList();
                            }
                            #endregion

                            #region Department Filter
                            if (txtDepartment.Tag != null)
                                oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();
                            #endregion

                            #region Shift Filter
                            if (txtShift.Tag != null)
                                oEmployees = oEmployees.Where(p => p.Shift_ID == txtShift.Tag.ToString()).ToList();
                            #endregion

                            foreach (tbl_genMasEmployee oEmployee in oEmployees)
                            {
                                foreach (tbl_tasTxGatePass oGatePass in tbl_tasTxGatePass.SelectAll().Where(p => p.Employee_ID == oEmployee.Employee_ID && p.GatePass_DateTime.Date >= dtp_FromDate.GetDateTime().Date && p.GatePass_DateTime.Date <= dtp_ToDate.GetDateTime().Date))
                                {
                                    glb_dts_TAS.dt_tas_GatePass.Adddt_tas_GatePassRow(oGatePass.GatePass_ID, oGatePass.Employee_ID, oEmployee.Initails + " " + oEmployee.SurName, oGatePass.GatePass_DateTime.ToString(), (oGatePass.Leave_Hours / 60), oGatePass.Reason, clsRef_Name.get_EmployeeAliasName(oGatePass.UserID_Supevisor), clsRef_Name.get_EmployeeAliasName(oGatePass.UserID_Manager), oGatePass.GatePass_DateTime.Date);
                                }
                            }

                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_TAS, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }
                        #endregion

                        #region Leave Card
                        else if (Report == enum_ReportName.LeaveCard)
                        {
                            DataSets.dts_TAS glb_dts_TAS = new DataSets.dts_TAS();
                            //glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #region Company Data Set Fill
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #endregion

                            string noOfDays = string.Empty;

                            #region Filters
                            #region Employee Filter
                            List<sp_genMasEmployee> oEmployees;
                            if (bEmployeeSelected)
                            {
                                oEmployees = new List<sp_genMasEmployee>();
                                oEmployees.Add(sp_genMasEmployee.Select(txtEmployee.Tag.ToString()));
                            }
                            else
                                oEmployees = sp_genMasEmployee.SelectAll().Where(p => p.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString()).ToList();
                            #endregion

                            if (bDesignationSelected)
                                oEmployees = oEmployees.Where(p => p.Designation_ID == txtDesignation.Tag.ToString()).ToList();

                            if (bDivisionSelected)
                                oEmployees = oEmployees.Where(p => p.Division_ID == txtDivision.Tag.ToString()).ToList();

                            if (bDepartmentSelected)
                                oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();

                            if (bSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();

                            if (bSubSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SubSectionID == txtSubSection.Tag.ToString()).ToList();

                            if (bEmpCategory1Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();

                            if (bEmpCategory2Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();

                            if (bEmpCategory3Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();
                            #endregion

                            foreach (sp_genMasEmployee oEmployee in oEmployees.Where(p => p.IsTime_Attendance == true))
                            {
                                string sLeaveStatus = "Pending";
                                foreach (tbl_tasEmployeeLeaveCard oLeaveCard in tbl_tasEmployeeLeaveCard.SelectAll().Where(p => p.Employee_ID == oEmployee.Employee_ID && p.Leave_Start.Date >= dtp_FromDate.GetDateTime().Date && p.Leave_End.Date <= dtp_ToDate.GetDateTime().Date && !p.IsCancled))
                                {
                                    if (bLeaveTypeSelected)
                                        if (txtLeaveTypes.Tag.ToString() != oLeaveCard.LeaveType_ID)
                                            continue;

                                    if (oLeaveCard.UserID_CP1 != "" && oLeaveCard.UserID_CP2 != "")
                                    {
                                        if (oLeaveCard.ApprovalStatus_CP1 == 1 && oLeaveCard.ApprovalStatus_CP2 == 1 && oLeaveCard.ApprovalStatus_Manager == 1 && oLeaveCard.ApprovalStatus_Supevosior == 1)
                                        {
                                            sLeaveStatus = "Approved";
                                        }
                                    }
                                    else
                                    {
                                        if (oLeaveCard.ApprovalStatus_Manager == 1 && oLeaveCard.ApprovalStatus_Supevosior == 1 && (oLeaveCard.ApprovalStatus_CP1 == 1 || oLeaveCard.ApprovalStatus_CP2 == 1))
                                        {
                                            sLeaveStatus = "Approved";
                                        }
                                    }

                                    glb_dts_TAS.dt_EmployeeLeaveCard.Adddt_EmployeeLeaveCardRow(oLeaveCard.Leave_ID, oLeaveCard.Employee_ID, clsRef_Name.get_EmployeeName(oLeaveCard.Employee_ID), oLeaveCard.Leave_Start.ToString(clsConfig.Format_DateTime) + " To " + oLeaveCard.Leave_End.ToString(clsConfig.Format_DateTime), oLeaveCard.Reason, sLeaveStatus, clsRef_Name.get_EmployeeAliasName(oLeaveCard.UserID_Supevisor), clsRef_Name.get_EmployeeAliasName(oLeaveCard.UserID_Manager), "Covering Person 1 :" + oLeaveCard.Comments_CP1 + "\n Covering Person 2" + oLeaveCard.Comments_CP2 + "\n Supervisor :" + oLeaveCard.Comments_Supevisor + "\n Manager :" + oLeaveCard.Comments_Manager, noOfDays, oLeaveCard.Year_ID.ToString(), oLeaveCard.LeaveType_ID, clsRef_Name.get_leaveType_Name(oLeaveCard.LeaveType_ID), oLeaveCard.Leaves_Utilized, oLeaveCard.Leave_Start.Date, oLeaveCard.Leave_Start, oLeaveCard.Leave_End);
                                }
                            }

                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_TAS, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }
                        #endregion

                        #region Late Employees
                        else if (Report == enum_ReportName.LateEmployees)
                        {
                            DataSets.dts_TAS glb_dts_TAS = new DataSets.dts_TAS();
                            //glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #region Company Data Set Fill
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date To " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date To " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #endregion

                            #region Filters
                            #region Employee Filter
                            List<tbl_genMasEmployee> oEmployees;
                            if (bEmployeeSelected)
                            {
                                oEmployees = new List<tbl_genMasEmployee>();
                                oEmployees.Add(tbl_genMasEmployee.Select(txtEmployee.Tag.ToString(), clsSecurity.CompanyID, clsSecurity.BranchID));
                            }
                            else
                                oEmployees = tbl_genMasEmployee.SelectAll().Where(p => p.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString()).ToList();
                            #endregion

                            if (bDesignationSelected)
                                oEmployees = oEmployees.Where(p => p.Designation_ID == txtDesignation.Tag.ToString()).ToList();

                            if (bDivisionSelected)
                                oEmployees = oEmployees.Where(p => p.Division_ID == txtDivision.Tag.ToString()).ToList();

                            if (bDepartmentSelected)
                                oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();

                            if (bSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();

                            if (bSubSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SubSectionID == txtSubSection.Tag.ToString()).ToList();

                            if (bEmpCategory1Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();

                            if (bEmpCategory2Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();

                            if (bEmpCategory3Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();
                            #endregion

                            foreach (tbl_genMasEmployee oEmployee in oEmployees.Where(p => p.Emp_statusID != EmployeeStatus.Resigned.ToString() && p.Emp_statusID != EmployeeStatus.Suspended_With_Pay.ToString() && p.Emp_statusID != EmployeeStatus.Suspended_Without_Pay.ToString() && p.IsTime_Attendance == true))
                            {
                                string Status = "", sEmpShift_ID = "";
                                DateTime InDateTime = clsConfig.defaultDateTime;
                                DateTime ShiftStartTime = clsConfig.defaultDateTime;

                                //DateTime dtFrom = dtmFromDate.Date;
                                DateTime dtTo = dtmToDate.Date;

                                //for (DateTime date = dtmFromDate.Date; date <= dtmToDate.Date; date = date.AddDays(1))
                                //{
                                sEmpShift_ID = clsHelpMethods.GetShift(dtTo, oEmployee.Employee_ID, oEmployee.IsRosterBasedEmployee);
                                tbl_tasShiftMaster oShift = tbl_tasShiftMaster.Select(sEmpShift_ID, clsSecurity.CompanyID, clsSecurity.BranchID);
                                if (oShift != null && oShift.Shift_ID != "default")
                                {
                                    if (oShift.ShiftMinutes > 0)
                                    {
                                        ShiftStartTime = oShift.ShiftStartTime;
                                        foreach (sp_tasDevice_RawData Detail in sp_tasDevice_RawData.SelectAll("%", oEmployee.Employee_ID2, dtTo.Date, dtTo.Date.AddHours(24)))
                                        {
                                            if (InDateTime == clsConfig.defaultDateTime)
                                                InDateTime = Detail.Device_DateTime;
                                            else if (InDateTime > Detail.Device_DateTime)
                                                InDateTime = Detail.Device_DateTime;
                                        }

                                        TimeSpan tsTimeGap = InDateTime.TimeOfDay - ShiftStartTime.TimeOfDay;
                                        int iTimeGap = clsValidation.GetMinutes(tsTimeGap);

                                        if (InDateTime == clsConfig.defaultDateTime)
                                        {
                                            Status = "Not Present";
                                        }
                                        else if (iTimeGap > oShift.ShiftGracePeriod)
                                        {
                                            Status = "Late";
                                            glb_dts_TAS.dt_LateEmployees.Adddt_LateEmployeesRow(oEmployee.Department_ID, clsRef_Name.get_Department_Name(oEmployee.Department_ID), sEmpShift_ID, oShift.Shift_Name, oEmployee.Employee_ID, oEmployee.Initails + " " + oEmployee.SurName, "", oEmployee.Mobile1, Status == "Absent" ? "-" : InDateTime.ToString(clsConfig.Format_Time), Status, clsRef_Name.get_Designation_Name(oEmployee.Designation_ID), oShift.ShiftStartTime.ToString(clsConfig.Format_Time));
                                        }
                                    }
                                }
                                //}
                            }

                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_TAS, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }
                        #endregion

                        #region Head Count Summary Report
                        else if (Report == enum_ReportName.HeadCountReport)
                        {
                            DataSets.dts_TAS glb_dts_TAS = new DataSets.dts_TAS();
                            //glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date : " + dtmFromDate.ToString(clsConfig.Format_Date), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);

                            #region Company Data Set Fill
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #endregion

                            #region Old Method
                            if (false)
                            {
                                int iTotalEmployees = 0;
                                int iPresentEmployees = 0;
                                int iAbsentEmployees = 0;
                                int iApprovedLeave = 0;
                                string sDepartmentID = "";
                                string sDepartmentname = "";
                                DateTime fromDate = DateTime.Today.Date;
                                DateTime toDate = DateTime.Today.Date;
                                DateTime inDate = clsConfig.defaultDateTime;
                                DateTime OutDate = clsConfig.defaultDateTime;

                                #region Filters
                                #region Employee Filter
                                List<tbl_genMasEmployee> oEmployees;
                                if (bEmployeeSelected)
                                {
                                    oEmployees = new List<tbl_genMasEmployee>();
                                    oEmployees.Add(tbl_genMasEmployee.Select(txtEmployee.Tag.ToString(), clsSecurity.CompanyID, clsSecurity.BranchID));
                                }
                                else
                                {
                                    oEmployees = tbl_genMasEmployee.SelectAll().ToList();
                                }
                                #endregion

                                #region Division Filter
                                if (bDivisionSelected)
                                {
                                    oEmployees = oEmployees.Where(p => p.Division_ID == txtDivision.Tag.ToString()).ToList();
                                }
                                #endregion

                                #region Department Filter
                                if (bDepartmentSelected)
                                {
                                    oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();
                                }
                                #endregion

                                #region Section filter
                                if (bSectionSelected)
                                {
                                    oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();
                                }
                                #endregion
                                #endregion

                                if (!bDivisionSelected)
                                {
                                    foreach (tbl_genMasDepartment oDepartment in tbl_genMasDepartment.SelectAll().Where(p => p.IsCanceled == false && p.Department_ID != "default"))
                                    {
                                        iTotalEmployees = 0;
                                        iPresentEmployees = 0;
                                        iAbsentEmployees = 0;
                                        iApprovedLeave = 0;
                                        sDepartmentID = oDepartment.Department_ID;
                                        sDepartmentname = oDepartment.DepartmentName;

                                        foreach (tbl_genMasEmployee oEmployee in oEmployees.Where(p => p.Emp_statusID != "EST/001" && p.Emp_statusID != "EST/002" && p.Department_ID == oDepartment.Department_ID && p.IsTime_Attendance == true))
                                        {
                                            iTotalEmployees = iTotalEmployees + 1;
                                            foreach (sp_tasDevice_RawData oRowData in sp_tasDevice_RawData.SelectAll("%", oEmployee.Employee_ID2, fromDate, toDate))
                                            {
                                                iPresentEmployees = iPresentEmployees + 1;
                                                break;
                                            }
                                            tbl_tasEmployeeLeaveCard oLeaveCard = tbl_tasEmployeeLeaveCard.SelectByDateRange(fromDate, toDate, oEmployee.Employee_ID);
                                            if (oLeaveCard != null)
                                            {
                                                iApprovedLeave = iApprovedLeave + 1;
                                            }
                                        }
                                        glb_dts_TAS.dt_HeadCount.Adddt_HeadCountRow(sDepartmentID, sDepartmentname, iTotalEmployees, iPresentEmployees, iAbsentEmployees, iApprovedLeave);
                                    }
                                }
                                else if (!(bDepartmentSelected && bDepartmentSelected))
                                {
                                    foreach (tbl_genMasDepartment oDepartment in tbl_genMasDepartment.SelectAll().Where(p => p.IsCanceled == false && p.Department_ID != "default" && p.Division_ID == txtDivision.Tag.ToString()))
                                    {
                                        iTotalEmployees = 0;
                                        iPresentEmployees = 0;
                                        iAbsentEmployees = 0;
                                        iApprovedLeave = 0;


                                        foreach (tbl_genMasEmployee oEmployee in oEmployees.Where(p => p.Emp_statusID != "EST/001" && p.Emp_statusID != "EST/002" && p.Department_ID == oDepartment.Department_ID && p.IsTime_Attendance == true))
                                        {
                                            sDepartmentID = oDepartment.Department_ID;
                                            sDepartmentname = oDepartment.DepartmentName;
                                            iTotalEmployees = iTotalEmployees + 1;
                                            foreach (sp_tasDevice_RawData oRowData in sp_tasDevice_RawData.SelectAll("%", oEmployee.Employee_ID2, fromDate, toDate))
                                            {
                                                iPresentEmployees = iPresentEmployees + 1;
                                                break;
                                            }
                                            tbl_tasEmployeeLeaveCard oLeaveCard = tbl_tasEmployeeLeaveCard.SelectByDateRange(fromDate, toDate, oEmployee.Employee_ID);
                                            if (oLeaveCard != null)
                                            {
                                                iApprovedLeave = iApprovedLeave + 1;
                                            }
                                        }
                                        glb_dts_TAS.dt_HeadCount.Adddt_HeadCountRow(sDepartmentID, sDepartmentname, iTotalEmployees, iPresentEmployees, iAbsentEmployees, iApprovedLeave);
                                    }
                                }
                                else
                                {
                                    foreach (tbl_genMasEmployee oEmployee in oEmployees.Where(p => p.Emp_statusID != "EST/001" && p.Emp_statusID != "EST/002" && p.IsTime_Attendance == true && p.Department_ID == txtDepartment.Tag.ToString()))
                                    {
                                        sDepartmentID = oEmployee.Department_ID;
                                        sDepartmentname = clsRef_Name.get_Department_Name(oEmployee.Department_ID);
                                        iTotalEmployees = iTotalEmployees + 1;
                                        foreach (sp_tasDevice_RawData oRowData in sp_tasDevice_RawData.SelectAll("%", oEmployee.Employee_ID2, fromDate, toDate))
                                        {
                                            iPresentEmployees = iPresentEmployees + 1;
                                            break;
                                        }
                                        tbl_tasEmployeeLeaveCard oLeaveCard = tbl_tasEmployeeLeaveCard.SelectByDateRange(fromDate, toDate, oEmployee.Employee_ID);
                                        if (oLeaveCard != null)
                                        {
                                            iApprovedLeave = iApprovedLeave + 1;
                                        }
                                    }
                                    glb_dts_TAS.dt_HeadCount.Adddt_HeadCountRow(sDepartmentID, sDepartmentname, iTotalEmployees, iPresentEmployees, iAbsentEmployees, iApprovedLeave);
                                }
                            }
                            #endregion

                            else
                            {

                                string qry = "sp_getEmployeeHeadCount_fromRawData '" + clsSecurity.CompanyID + "', '" + clsSecurity.BranchID + "', '" + dtmFromDate + "' , '" + dtmToDate + "' , '" + dtmFromDate.Date + "', '%', '%', '%', '%', '%', '%', '%' , '%', '" + clsConfig.sEmployeeHeadCounts_MarginTime + "'";
                                DataTable dt_headCont = DBHandling.ExecQuery(qry).Tables[0];

                                foreach (tbl_genMasDepartment oDept in tbl_genMasDepartment.SelectAllByCompany_ID_CompanyBranch_ID(clsSecurity.CompanyID, clsSecurity.BranchID))
                                {
                                    if (txtDepartment.Tag != null)
                                        if (txtDepartment.Tag.ToString() != oDept.Department_ID)
                                            continue;

                                    DataRow[] records = dt_headCont.Select("DepartmentID = '" + oDept.Department_ID + "'");
                                    int iPresentRecords = records.Length;
                                    int iTotRecords = tbl_genMasEmployee.SelectAll().Where(r => r.Department_ID == oDept.Department_ID && r.Emp_statusID.Trim() != ((int)EmployeeStatus.Resigned).ToString().Trim() && r.Employee_ID != "default").Count();
                                    int iApprovedLeaves = 0;
                                    foreach (tbl_genMasEmployee record in tbl_genMasEmployee.SelectAll().Where(p => p.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString() && p.Department_ID == oDept.Department_ID))
                                    {
                                        iApprovedLeaves += tbl_tasEmployeeLeaveCard.SelectAll().Where(r => r.Leave_Start.Date == dtp_FromDate.GetDateTime().Date && r.Employee_ID == record.Employee_ID).Count();
                                    }
                                    int iAbsRecords = iTotRecords - iPresentRecords - iApprovedLeaves;

                                    glb_dts_TAS.dt_HeadCount.Adddt_HeadCountRow(oDept.Department_ID, oDept.DepartmentName, iTotRecords, iPresentRecords, iAbsRecords, iApprovedLeaves);

                                }
                            }

                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_TAS, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }
                        #endregion

                        #region Head Count Detail Report
                        else if (Report == enum_ReportName.HeadCountDetailReport)
                        {
                            DataSets.dts_TAS glb_dts_TAS = new DataSets.dts_TAS();

                            #region Variables
                            string sEmployee = "%", sDivision = "%", sDepartment = "%", sSection = "%", sSubSection = "%", sEmpCategory1 = "%", sEmpCategory2 = "%", sEmpCategory3 = "%";
                            #endregion

                            #region Selected Filters
                            if (bEmployeeSelected)
                                sEmployee = txtEmployee.Tag.ToString();
                            else if (bDivisionSelected)
                                sDivision = txtDivision.Tag.ToString();
                            else if (bDepartmentSelected)
                                sDepartment = txtDepartment.Tag.ToString();
                            else if (bSectionSelected)
                                sSection = txtSection.Tag.ToString();
                            else if (bSubSectionSelected)
                                sSubSection = txtSubSection.Tag.ToString();
                            else if (bEmpCategory1Selected)
                                sEmpCategory1 = txtEmpCategory1.Tag.ToString();
                            else if (bEmpCategory2Selected)
                                sEmpCategory2 = txtEmpCategory2.Tag.ToString();
                            else if (bEmpCategory3Selected)
                                sEmpCategory3 = txtEmpCategory2.Tag.ToString();
                            #endregion

                            #region Company Data Set Fill
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #endregion

                            #region Fill Datatable
                            string qry = "sp_getEmployeeHeadCount_fromRawData_Details '" + clsSecurity.CompanyID + "', '" + clsSecurity.BranchID + "', '" + dtmFromDate + "' , '" + dtmToDate + "', '" + dtmFromDate.Date + "', '" + sEmployee + "', '" + sDivision + "', '" + sDepartment + "', '" + sSection + "', '" + sSubSection + "', '" + sEmpCategory1 + "', '" + sEmpCategory2 + "' , '" + sEmpCategory3 + "', '" + clsConfig.sEmployeeHeadCounts_MarginTime + "'";
                            DataTable dt_headCont = DBHandling.ExecQuery(qry).Tables[0];

                            glb_dts_TAS.dt_HeadCount_Detail.Merge(dt_headCont);
                            #endregion

                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_TAS, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }
                        #endregion

                        #region Monthly Attendance Sheet Excel - Developed by Gayan 2016.04.19
                        else if (Report == enum_ReportName.MonthlyAttendanceSheetExcel)
                        {
                            #region Filters
                            string sEmployeeID = "%";
                            string sDivisionID = "%";
                            string sSectionID = "%";
                            string sDepartmentID = "%";
                            string sEmpCategoryID = "%";

                            if (bEmployeeSelected)
                                sEmployeeID = txtEmployee.Tag.ToString();

                            if (bDivisionSelected)
                                sDivisionID = txtDivision.Tag.ToString();

                            if (bDepartmentSelected)
                                sDepartmentID = txtDepartment.Tag.ToString();

                            if (bSectionSelected)
                                sSectionID = txtSection.Tag.ToString();

                            if (bEmpCategory1Selected)
                                sEmpCategoryID = txtEmpCategory1.Tag.ToString();
                            #endregion

                            #region Fill Data
                            DataSets.dts_TAS glb_dts_TAS = new DataSets.dts_TAS();
                            string sQuary = "exec [sp_RPT_AttendanceSummary_EmployeeWise] 'Company1','default','" + dtp_FromDate.GetDateTime().Date + "','" + dtp_ToDate.GetDateTime().Date + "','" + sEmployeeID + "','" + sDivisionID + "','" + sDepartmentID + "','" + sSectionID + "', '" + sEmpCategoryID + "'";
                            //Data Table for Attendance Sheet
                            DataTable dt = DBHandling.ExecQuery(sQuary).Tables[0];
                            dt.Columns.Remove("Company_ID");
                            dt.Columns.Remove("CompanyBranch_ID");
                            dt.Columns.Remove("Designation_ID");
                            dt.Columns.Remove("ShiftStartTime");
                            dt.Columns.Remove("ShiftEndTime");
                            dt.Columns.Remove("ShiftDay");
                            dt.Columns.Remove("Shift_Name");
                            dt.Columns.Remove("EmpCatagory1_ID");
                            dt.Columns.Remove("GpMinutes");
                            dt.Columns.Remove("LeaveMinutes");
                            dt.Columns.Remove("NoPayMinutes");
                            dt.Columns.Remove("OTMinutesApproved");
                            dt.Columns.Remove("TotalMinutes");
                            dt.Columns.Remove("TimeOut_DateTime");
                            dt.Columns.Remove("TimeIn_DateTime");
                            dt.Columns.Remove("Shift_ID");
                            dt.Columns.Remove("ShiftMinutes");
                            #endregion

                            //Create Excel Application to enter data
                            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                            ExcelApp.Application.Workbooks.Add(Type.Missing);

                            //Get Employee List
                            List<string> employeeIdList = new List<string>();
                            foreach (DataRow row in dt.Rows)
                            {
                                if (employeeIdList.Contains(row[2]))
                                {
                                    continue;
                                }
                                employeeIdList.Add((string)row[2]);
                            }

                            //Print Employee List
                            int k = 4;
                            foreach (string employee_ID in employeeIdList)
                            {
                                ExcelApp.Cells[k, 1] = clsRef_Name.get_EmployeeName(employee_ID);
                                ExcelApp.Cells[k, 1].Borders.Color = System.Drawing.Color.Black;

                                ExcelApp.Cells[k, 2] = employee_ID;
                                ExcelApp.Cells[k, 2].Borders.Color = System.Drawing.Color.Black;

                                k++;
                            }

                            //Print Date and Worked Hours
                            double totalHours = 0.00; // (WORKED HOURS) This is for storing total working hours with relavant to selected date range
                            int i = 3; //For Print Date     
                            int r = 0; //For Store toal no of rows in Excel Sheet
                            for (DateTime dateTime = dtmFromDate; dateTime < dtmToDate; dateTime += TimeSpan.FromDays(1))
                            {
                                if ((int)dateTime.DayOfWeek == 6) //saturday
                                {
                                    ExcelApp.Columns[i].Interior.Color = System.Drawing.Color.Yellow;
                                    totalHours = totalHours + 4.50;
                                }
                                else if ((int)dateTime.DayOfWeek == 0)//Sunday
                                {
                                    ExcelApp.Columns[i].Interior.Color = System.Drawing.Color.LightGreen;
                                    totalHours = totalHours + 0.00;
                                }
                                else //Other Days
                                {
                                    totalHours = totalHours + 9.00;
                                }

                                //Check whether the date is a holiday or not
                                foreach (tbl_tasHolidayCalander detail in tbl_tasHolidayCalander.SelectAll().Where(p => p.IsCanceled == false && p.Holiday_ID != "default" && p.Holiday_Date == dateTime.Date))
                                {
                                    ExcelApp.Cells[2, i] = clsRef_Name.get_HolidayType_Name(detail.HolydayType_ID);
                                    ExcelApp.Cells[2, i].Font.Size = 6.75;
                                    ExcelApp.Cells[2, i].Borders.Color = System.Drawing.Color.Black;
                                    ExcelApp.Columns[i].Font.Color = System.Drawing.Color.Brown;
                                }

                                ExcelApp.Cells[1, i] = totalHours;// Filling Worked Houres Cells
                                ExcelApp.Cells[1, i].Font.Color = System.Drawing.Color.White;// Worked Houres Cell fromatting

                                ExcelApp.Cells[3, i] = dateTime.ToShortDateString(); // Printing Date
                                ExcelApp.Cells[3, i].Borders.Color = System.Drawing.Color.Black;
                                ExcelApp.Columns[i].ColumnWidth = 12; // Date Cell Formatting

                                List<string> workingTime = new List<string>(); // This List is for storing the working hours of employees. (Order is equal to "employeeIdList")
                                foreach (string emp_id in employeeIdList)
                                {
                                    DataRow[] result = dt.Select("AttendenceDate = '" + dateTime.ToShortDateString() + "' AND Employee_ID = '" + emp_id + "'"); // Select Worked mins. with given EmployeeID and Relavant Date
                                    if (result.Length > 0)
                                        foreach (DataRow row in result)
                                        {
                                            workingTime.Add((string)row["WorkedMinutes"].ToString());
                                        }
                                    else
                                        workingTime.Add("0.00");
                                }

                                int m = 4;//For Print Worked hours
                                foreach (string wtime in workingTime)
                                {
                                    ExcelApp.Cells[m, i] = string.Format("{0:0.00}", (Convert.ToDouble(wtime) / 60.00)); // Worked hours are rounded to two decimal points
                                    ExcelApp.Cells[m, i].NumberFormat = "#,##0.00"; // Excel number format
                                    ExcelApp.Cells[m, i].Borders.Color = System.Drawing.Color.Black;
                                    m++;
                                }
                                r = m; // Clooect total Rows of this sheet 

                                i++;
                            }

                            string lastColumnLetter = ColumnIndexToColumnLetter(i - 1); // returns Column Letter for given column index
                            for (int q = 4; q < r; q++)
                            {
                                ExcelApp.Cells[q, i + 1].Formula = "=SUM(" + "C" + q + ":" + lastColumnLetter + q + ")"; //Print the Total Work Hours in Employee wise
                                ExcelApp.Cells[q, i + 1].Borders.Color = System.Drawing.Color.Black;
                            }

                            //Change properties of the Workbook  and  Finalize Excel Work Sheet       
                            ExcelApp.Cells[1, 1] = "Worked Hours";
                            ExcelApp.Cells[2, 1] = "Holiday Type";
                            ExcelApp.Cells[3, 1] = "EMPLOYEE NAME";
                            ExcelApp.Cells[3, 2] = "EMPLOYEE NO";
                            ExcelApp.Cells[3, i + 1] = "TOTAL WORKED HRS";

                            ExcelApp.Columns[i + 1].ColumnWidth = 18;
                            ExcelApp.Columns[1].ColumnWidth = 60;
                            ExcelApp.Columns[2].ColumnWidth = 12.5;

                            ExcelApp.Cells[3, i + 1].Interior.Color = System.Drawing.Color.Purple;
                            ExcelApp.Rows[1].Interior.Color = System.Drawing.Color.Black;
                            ExcelApp.Rows[2].Interior.Color = System.Drawing.Color.Yellow;
                            ExcelApp.Cells[2, 1].Interior.Color = System.Drawing.Color.White;
                            ExcelApp.Cells[1, 1].Interior.Color = System.Drawing.Color.White;
                            ExcelApp.Cells[1, 2].Interior.Color = System.Drawing.Color.White;
                            ExcelApp.Cells[2, 2].Interior.Color = System.Drawing.Color.White;
                            ExcelApp.Cells[3, 1].Interior.Color = System.Drawing.Color.LightGreen;
                            ExcelApp.Cells[3, 2].Interior.Color = System.Drawing.Color.LightGreen;


                            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                            dlg.DefaultExt = ".xls";
                            dlg.Filter = "Text documents (.xls)|*.xlsx";
                            if (dlg.ShowDialog() == true)
                            {
                                string filename = dlg.FileName;
                                ExcelApp.ActiveWorkbook.SaveCopyAs(filename);
                                SEACCMessageBox.Show("Successfully created", "Excel file is successfully created", MessageBoxButton.OK);
                                ExcelApp.ActiveWorkbook.Saved = true;
                                ExcelApp.Visible = true;
                            }

                            Marshal.FinalReleaseComObject(ExcelApp);
                        }
                        #endregion

                        #region Attendace Summary - Entitle Year - Hero
                        else if (Report == enum_ReportName.AttendanceReportEntitleYear)
                        {
                            dts_TAS glb_dts_TAS = new dts_TAS();
                            //glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #region Company Data Set Fill
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #endregion


                            #region Employee Filter
                            List<tbl_genMasEmployee> oEmployees;
                            if (txtEmployee.Tag != null)
                                oEmployees = tbl_genMasEmployee.SelectAll().Where(p => p.Employee_ID == txtEmployee.Tag.ToString() && p.Employee_ID != "default").ToList();
                            else
                                oEmployees = tbl_genMasEmployee.SelectAll().Where(p => p.Employee_ID != "default").ToList();
                            #endregion

                            #region Division Filter
                            if (bDivisionSelected)
                            {
                                oEmployees = oEmployees.Where(p => p.Division_ID == txtDivision.Tag.ToString()).ToList();
                            }
                            #endregion

                            #region Department Filter
                            if (txtDepartment.Tag != null)
                                oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();
                            #endregion

                            #region Shift Filter
                            if (txtShift.Tag != null)
                                oEmployees = oEmployees.Where(p => p.Shift_ID == txtShift.Tag.ToString()).ToList();
                            #endregion

                            foreach (tbl_genMasEmployee oEmployee in oEmployees)
                            {
                                foreach (tbl_tasEmployeeLeave_entitled oLeaveEntitle in tbl_tasEmployeeLeave_entitled.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, oEmployee.Employee_ID).Where(y => y.HrYear_ID == int.Parse(txtYear.Tag.ToString())))
                                {
                                    glb_dts_TAS.tbl_tasAttendanceEntireYear.Addtbl_tasAttendanceEntireYearRow(oEmployee.Employee_ID, oEmployee.EpfNo, (oEmployee.SurName + ", " + oEmployee.Initails), oEmployee.DateConfirm.Date, oLeaveEntitle.Leaves_Entitled, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                                }
                            }
                            frm_ReportViwer CRViwer = new frm_ReportViwer();
                            CRViwer.Print(oReport.ReportPath, glb_dts_TAS, glb_dts_ExportReport.dt_rptParameter);
                        }
                        #endregion

                        #region Leave Encashment Employee Wise Report
                        else if (Report == enum_ReportName.LeaveEncashment_EmployeeWise)
                        {
                            if (txtYear.Tag != null)
                            {
                                DataSets.dts_TAS glb_dts_TAS = new DataSets.dts_TAS();

                                #region Company Data Set Fill
                                if (bDivisionSelected)
                                {
                                    CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                    glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                }
                                else
                                    glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                #endregion

                                #region Filters

                                #region Employee Filter
                                List<tbl_genMasEmployee> oEmployees;
                                if (bEmployeeSelected)
                                {
                                    oEmployees = new List<tbl_genMasEmployee>();
                                    oEmployees.Add(tbl_genMasEmployee.Select(txtEmployee.Tag.ToString(), clsSecurity.CompanyID, clsSecurity.BranchID));
                                }
                                else
                                    oEmployees = tbl_genMasEmployee.SelectAll().Where(p => p.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString() && p.Employee_ID != "default" && p.Division_ID != "default").ToList();
                                #endregion

                                if (bDesignationSelected)
                                    oEmployees = oEmployees.Where(p => p.Designation_ID == txtDesignation.Tag.ToString()).ToList();

                                if (bDivisionSelected)
                                    oEmployees = oEmployees.Where(p => p.Division_ID == txtDivision.Tag.ToString()).ToList();

                                if (bDepartmentSelected)
                                    oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();

                                if (bSectionSelected)
                                    oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();

                                if (bSubSectionSelected)
                                    oEmployees = oEmployees.Where(p => p.SubSectionID == txtSubSection.Tag.ToString()).ToList();

                                if (bEmpCategory1Selected)
                                    oEmployees = oEmployees.Where(p => p.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();

                                if (bEmpCategory2Selected)
                                    oEmployees = oEmployees.Where(p => p.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();

                                if (bEmpCategory3Selected)
                                    oEmployees = oEmployees.Where(p => p.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();
                                #endregion

                                foreach (tbl_genMasEmployee oEmp in oEmployees)
                                {
                                    List<tbl_tasEmployeeLeave_entitled> oLevEintiles = tbl_tasEmployeeLeave_entitled.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, oEmp.Employee_ID).Where(r => r.HrYear_ID == int.Parse(txtYear.Tag.ToString())).ToList();

                                    decimal dBaseSalary = 0;
                                    decimal dHourRate = 0;
                                    tbl_payMas_ProcessGroup oPayrollGroup = tbl_payMas_ProcessGroup.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oEmp.Payroll_ProcessGroupID);
                                    if (oPayrollGroup != null)
                                    {
                                        dBaseSalary = clsHelpMethods.GetBaseSalary_FromMas(oEmp.Employee_ID);
                                        dHourRate = decimal.Round(dBaseSalary * 60 / oPayrollGroup.DivRate_OT, 2);
                                    }

                                    oLevEintiles.ForEach((oLevEntilte) => glb_dts_TAS.dt_EmployeeLeaveEntitle.Adddt_EmployeeLeaveEntitleRow(oLevEntilte.Employee_ID,
                                        oLevEntilte.HrYear_ID.ToString(),
                                        oLevEntilte.LeaveType_ID, clsRef_Name.get_leaveType_Name(oLevEntilte.LeaveType_ID),
                                        oLevEntilte.Leaves_Entitled, oLevEntilte.Leaves_Utilized, oEmp.EpfNo, oEmp.Department_ID,
                                        clsRef_Name.get_Department_Name(oEmp.Department_ID), clsRef_Name.get_EmployeeShortName(oLevEntilte.Employee_ID),
                                        oEmp.Division_ID, clsRef_Name.get_Division_Name(oEmp.Division_ID), (dHourRate * 8m * (oLevEntilte.Leaves_Entitled - oLevEntilte.Leaves_Utilized))));
                                }

                                frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                                frmViewer.print(oReport.ReportPath, glb_dts_TAS, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                            }
                            else
                            {
                                SEACCMessageBox.Show("Oops....", " Please select the HR Year... ", MessageBoxButton.OK);
                            }
                        }
                        #endregion

                        #region OT Report
                        else if (Report == enum_ReportName.OverTimeDetails)
                        {
                            DataSets.dts_TAS glb_dts_TAS = new DataSets.dts_TAS();
                            //glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "For the period : " + dtmFromDate.ToString(clsConfig.Format_Date2) + " to " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? " - " : sFilter);
                            #region Company Data Set Fill
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #endregion

                            #region Filters
                            #region Employee Filter
                            List<sp_genMasEmployee> oEmployees;
                            if (bEmployeeSelected)
                            {
                                oEmployees = new List<sp_genMasEmployee>();
                                oEmployees.Add(sp_genMasEmployee.Select(txtEmployee.Tag.ToString()));
                            }
                            else
                                oEmployees = sp_genMasEmployee.SelectAll().Where(p => p.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString()).ToList();
                            #endregion

                            if (bDesignationSelected)
                                oEmployees = oEmployees.Where(p => p.Designation_ID == txtDesignation.Tag.ToString()).ToList();

                            if (bDivisionSelected)
                                oEmployees = oEmployees.Where(p => p.Division_ID == txtDivision.Tag.ToString()).ToList();

                            if (bDepartmentSelected)
                                oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();

                            if (bSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();

                            if (bSubSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SubSectionID == txtSubSection.Tag.ToString()).ToList();

                            if (bEmpCategory1Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();

                            if (bEmpCategory2Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();

                            if (bEmpCategory3Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();
                            #endregion

                            foreach (sp_genMasEmployee oEmployee in oEmployees.Where(p => p.Employee_ID != "default"))
                            {
                                // if client need to add double ot to other column then need to custom this code as required

                                decimal dOT_Amount = 0, dDOT_Amount = 0;
                                tbl_payTxSIPRawData oPay_Raw = tbl_payTxSIPRawData.SelectAll().Where(r => r.ProcessPeriod_Sub_startDate.Date == dtmFromDate.Date && r.ProcessPeriod_Sub_endDate.Date == dtmToDate.Date && r.Employee_ID == oEmployee.Employee_ID).FirstOrDefault();
                                if (oPay_Raw != null)
                                {
                                    tbl_payTxSIPRawData_PaySlipItems oPay_Item_OT = tbl_payTxSIPRawData_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oPay_Raw.SIP_ID, clsConfig.sOT_Normal);
                                    if (oPay_Item_OT != null)
                                        dOT_Amount += oPay_Item_OT.Amount;

                                    tbl_payTxSIPRawData_PaySlipItems oPay_Item_DOT = tbl_payTxSIPRawData_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oPay_Raw.SIP_ID, clsConfig.sOT_Double);
                                    if (oPay_Item_DOT != null)
                                        dOT_Amount += oPay_Item_DOT.Amount;
                                }

                                decimal dOT_Mins = 0, dDOT_Mins = 0;
                                foreach (tbl_tasTxDailyAttendance oAtten in tbl_tasTxDailyAttendance.SelectAllBy_EmployeeIDWithDateRange(oEmployee.Employee_ID, dtmFromDate.Date, dtmToDate.Date))
                                {
                                    dOT_Mins += oAtten.OTMinutesApproved + oAtten.DOTMinutesApproved;
                                }

                                glb_dts_TAS.dt_OverTime.Adddt_OverTimeRow(oEmployee.Employee_ID, clsRef_Name.get_EmployeeShortName(oEmployee.Employee_ID), oEmployee.EpfNo, oEmployee.NicNo, oEmployee.Department_ID, oEmployee.DepartmentName, oEmployee.Designation_name, oEmployee.DateJoin, oEmployee.DateConfirm, dOT_Mins, dOT_Amount, dDOT_Mins, dDOT_Amount);
                            }
                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_TAS, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }
                        #endregion

                        #region Attendance Summary From Device Raw Data
                        else if (Report == enum_ReportName.AttendanceSummary_DeviceRawData || Report == enum_ReportName.AttendanceSummary_DeviceRawData_Details)
                        {
                            DataSets.dts_TAS glb_dts_TAS = new DataSets.dts_TAS();
                            //glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "For the period : " + dtmFromDate.ToString(clsConfig.Format_Date2) + " - " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? " - " : sFilter);
                            #region Company Data Set Fill
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #endregion

                            #region Filters
                            #region Employee Filter
                            List<sp_genMasEmployee> oEmployees;
                            if (bEmployeeSelected)
                            {
                                oEmployees = new List<sp_genMasEmployee>();
                                oEmployees.Add(sp_genMasEmployee.Select(txtEmployee.Tag.ToString()));
                            }
                            else
                                oEmployees = sp_genMasEmployee.SelectAll().Where(p => p.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString()).ToList();
                            #endregion

                            if (bDesignationSelected)
                                oEmployees = oEmployees.Where(p => p.Designation_ID == txtDesignation.Tag.ToString()).ToList();

                            if (bDivisionSelected)
                                oEmployees = oEmployees.Where(p => p.Division_ID == txtDivision.Tag.ToString()).ToList();

                            if (bDepartmentSelected)
                                oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();

                            if (bSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();

                            if (bSubSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SubSectionID == txtSubSection.Tag.ToString()).ToList();

                            if (bEmpCategory1Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();

                            if (bEmpCategory2Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();

                            if (bEmpCategory3Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();
                            #endregion

                            foreach (sp_genMasEmployee oEmployee in oEmployees)
                            {
                                #region Device Raw Data
                                for (DateTime dDate = dtmFromDate.Date; dDate.Date <= dtmToDate.Date; dDate = dDate.AddDays(1))
                                {
                                    DataTable dt_InOutTime = DBHandling.ExecQuery("sp_GetInOutTimeFromDate '" + oEmployee.Employee_ID2 + "' , '" + dDate.Date + "' , '" + dDate.Date.AddDays(1).Date + "'").Tables[0];
                                    DateTime dtmTimeIn = clsValidation.defaultDateTime, dtmTimeOut = clsValidation.defaultDateTime;
                                    DateTime dtmTimeIn_Valid = clsValidation.defaultDateTime, dtmTimeOut_Valid = clsValidation.defaultDateTime;
                                    if (dt_InOutTime != null && dt_InOutTime.Rows.Count > 0)
                                    {
                                        //DataView dv = dt_InOutTime.DefaultView;
                                        //dv.Sort = "device_DateTime asc";
                                        //dt_InOutTime = dv.ToTable();


                                        dtmTimeIn = DateTime.Parse(dt_InOutTime.Rows[0]["device_DateTime"].ToString());

                                        int iLastRowNo = dt_InOutTime.Rows.Count - 1;
                                        if (dt_InOutTime.Rows.Count > 1)
                                            dtmTimeOut = DateTime.Parse(dt_InOutTime.Rows[iLastRowNo]["device_DateTime"].ToString());
                                    }

                                    glb_dts_TAS.dt_AttendanceSummary_DeviceRawData.Adddt_AttendanceSummary_DeviceRawDataRow(oEmployee.Employee_ID, clsRef_Name.get_EmployeeShortName(oEmployee.Employee_ID), oEmployee.EpfNo, oEmployee.Department_ID, oEmployee.DepartmentName, oEmployee.Designation_name, dDate, dtmTimeIn, dtmTimeOut);
                                }
                                #endregion

                                #region Gate Pass
                                foreach (tbl_tasTxGatePass oGatePass in tbl_tasTxGatePass.SelectAll().Where(p => p.Employee_ID == oEmployee.Employee_ID && p.GatePass_DateTime.Date >= dtp_FromDate.GetDateTime().Date && p.GatePass_DateTime.Date <= dtp_ToDate.GetDateTime().Date))
                                {
                                    glb_dts_TAS.dt_tas_GatePass.Adddt_tas_GatePassRow(oGatePass.GatePass_ID, oGatePass.Employee_ID, oEmployee.Initails + " " + oEmployee.SurName, oGatePass.GatePass_DateTime.ToString(), (oGatePass.Leave_Hours / 60), oGatePass.Reason, clsRef_Name.get_EmployeeAliasName(oGatePass.UserID_Supevisor), clsRef_Name.get_EmployeeAliasName(oGatePass.UserID_Manager), oGatePass.GatePass_DateTime.Date);
                                }
                                #endregion

                                #region Employee Leave Details
                                string sLeaveStatus = "Pending";
                                foreach (tbl_tasEmployeeLeaveCard oLeaveCard in tbl_tasEmployeeLeaveCard.SelectAll().Where(p => p.Employee_ID == oEmployee.Employee_ID && p.Leave_Start.Date >= dtp_FromDate.GetDateTime().Date && p.Leave_End.Date <= dtp_ToDate.GetDateTime().Date && !p.IsCancled))
                                {
                                    if (oLeaveCard.UserID_CP1 != "" && oLeaveCard.UserID_CP2 != "")
                                    {
                                        if (oLeaveCard.ApprovalStatus_CP1 == 1 && oLeaveCard.ApprovalStatus_CP2 == 1 && oLeaveCard.ApprovalStatus_Manager == 1 && oLeaveCard.ApprovalStatus_Supevosior == 1)
                                        {
                                            sLeaveStatus = "Approved";
                                        }
                                    }
                                    else
                                    {
                                        if (oLeaveCard.ApprovalStatus_Manager == 1 && oLeaveCard.ApprovalStatus_Supevosior == 1 && (oLeaveCard.ApprovalStatus_CP1 == 1 || oLeaveCard.ApprovalStatus_CP2 == 1))
                                        {
                                            sLeaveStatus = "Approved";
                                        }
                                    }
                                    glb_dts_TAS.dt_EmployeeLeaveCard.Adddt_EmployeeLeaveCardRow(oLeaveCard.Leave_ID, oLeaveCard.Employee_ID, clsRef_Name.get_EmployeeName(oLeaveCard.Employee_ID), oLeaveCard.Leave_Start.ToString(clsConfig.Format_DateTime) + " To " + oLeaveCard.Leave_End.ToString(clsConfig.Format_DateTime), oLeaveCard.Reason, sLeaveStatus, clsRef_Name.get_EmployeeAliasName(oLeaveCard.UserID_Supevisor), clsRef_Name.get_EmployeeAliasName(oLeaveCard.UserID_Manager), "Covering Person 1 :" + oLeaveCard.Comments_CP1 + "\n Covering Person 2" + oLeaveCard.Comments_CP2 + "\n Supervisor :" + oLeaveCard.Comments_Supevisor + "\n Manager :" + oLeaveCard.Comments_Manager, "1", oLeaveCard.Year_ID.ToString(), oLeaveCard.LeaveType_ID, clsRef_Name.get_leaveType_Name(oLeaveCard.LeaveType_ID), oLeaveCard.Leaves_Utilized, oLeaveCard.Leave_Start.Date, oLeaveCard.Leave_Start, oLeaveCard.Leave_End);
                                }
                                #endregion
                            }

                            //glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("ShiftHours", "10",true);

                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_TAS, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }
                        #endregion

                        #region Leave Balance
                        else if (Report == enum_ReportName.LeaveBalance)
                        {
                            DataSets.dts_TAS glb_dts_TAS = new DataSets.dts_TAS();
                            //glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, " To " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #region Company Data Set Fill
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #endregion

                            #region Filters
                            #region Employee Filter
                            List<sp_genMasEmployee> oEmployees;
                            if (bEmployeeSelected)
                            {
                                oEmployees = new List<sp_genMasEmployee>();
                                oEmployees.Add(sp_genMasEmployee.Select(txtEmployee.Tag.ToString()));
                            }
                            else
                                oEmployees = sp_genMasEmployee.SelectAll().Where(p => p.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString()).ToList();
                            #endregion

                            if (bDesignationSelected)
                                oEmployees = oEmployees.Where(p => p.Designation_ID == txtDesignation.Tag.ToString()).ToList();

                            if (bDivisionSelected)
                                oEmployees = oEmployees.Where(r => vDivisions.Any(r2 => r2.Field<string>("id") == r.Division_ID)).ToList();

                            if (bDepartmentSelected)
                                oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();

                            if (bSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();

                            if (bSubSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SubSectionID == txtSubSection.Tag.ToString()).ToList();

                            if (bEmpCategory1Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();

                            if (bEmpCategory2Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();

                            if (bEmpCategory3Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();
                            #endregion

                            foreach (sp_genMasEmployee oEmployee in oEmployees.OrderBy(o => o.Employee_ID.PadLeft(5, ' ')))
                            {
                                foreach (tbl_tasEmployeeLeave_entitled oLeaveEntitle in tbl_tasEmployeeLeave_entitled.SelectAll().Where(p => p.Employee_ID == oEmployee.Employee_ID && p.HrYear_ID == dtp_ToDate.GetDateTime().Date.Year))
                                {
                                    glb_dts_TAS.dt_EmployeeLeaveEntitle.Adddt_EmployeeLeaveEntitleRow(oEmployee.Employee_ID.PadLeft(5, ' '), oLeaveEntitle.HrYear_ID.ToString(), oLeaveEntitle.LeaveType_ID, clsRef_Name.get_leaveType_Name(oLeaveEntitle.LeaveType_ID),
                                        oLeaveEntitle.Leaves_Entitled,
                                        clsHelpMethods.GetUtilized_Leave_Days(oEmployee.Employee_ID, oLeaveEntitle.HrYear_ID, oLeaveEntitle.LeaveType_ID, dtp_ToDate.GetDateTime().Date),
                                        oEmployee.EpfNo.PadLeft(4, ' '), oEmployee.Department_ID, clsRef_Name.get_Department_Name(oEmployee.Department_ID), clsRef_Name.get_EmployeeShortName(oEmployee.Employee_ID), oEmployee.Division_ID, clsRef_Name.get_Division_Name(oEmployee.Division_ID), 0);
                                }
                            }

                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_TAS, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }
                        #endregion

                        #region Finger Prints More Than Two Reports
                        else if (Report == enum_ReportName.FingerPrints_MoreThanTwo_Reports)
                        {
                            dts_TAS glb_dts_TAS = new dts_TAS();

                            #region Company Data Set Fill
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #endregion

                            #region Filters
                            #region Employee Filter
                            List<sp_genMasEmployee> oEmployees;
                            if (bEmployeeSelected)
                            {
                                oEmployees = new List<sp_genMasEmployee>();
                                oEmployees.Add(sp_genMasEmployee.Select(txtEmployee.Tag.ToString()));
                            }
                            else
                                oEmployees = sp_genMasEmployee.SelectAll().Where(p => p.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString()).ToList();
                            #endregion

                            if (bDesignationSelected)
                                oEmployees = oEmployees.Where(p => p.Designation_ID == txtDesignation.Tag.ToString()).ToList();

                            if (bDivisionSelected)
                                oEmployees = oEmployees.Where(p => p.Division_ID == txtDivision.Tag.ToString()).ToList();

                            if (bDepartmentSelected)
                                oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();

                            if (bSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();

                            if (bSubSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SubSectionID == txtSubSection.Tag.ToString()).ToList();

                            if (bEmpCategory1Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();

                            if (bEmpCategory2Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();

                            if (bEmpCategory3Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();
                            #endregion

                            for (DateTime date = dtmFromDate.Date; date <= dtmToDate.Date; date = date.AddDays(1))
                            {
                                foreach (sp_genMasEmployee oemp in oEmployees.Where(p => p.Employee_ID != "default"))
                                {
                                    List<sp_tasDevice_RawData> oDRDList = sp_tasDevice_RawData.SelectAll("%", oemp.Employee_ID2, date.Date, date.Date);
                                    if (oDRDList.Count > 2)
                                    {
                                        foreach (sp_tasDevice_RawData oDRD in oDRDList.Where(p => p.Device_empID != null && p.Device_empID != "0"))
                                        {
                                            glb_dts_TAS.dt_rptDeviceRawData.Adddt_rptDeviceRawDataRow(oDRD.Device_DateTime, oDRD.Device_empID, oemp.SurName + " " + oemp.Initails, oDRD.Device_ID, oDRD.Device_Name, oemp.Department_ID, oemp.DepartmentName, oDRD.Device_DateTime.ToString(clsConfig.Format_DateTime));
                                        }
                                    }
                                }
                            }

                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_TAS, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }
                        #endregion

                        #region Nopay Report
                        else if (Report == enum_ReportName.Nopay_Report)
                        {
                            DataSets.dts_TAS glb_dts_TAS = new DataSets.dts_TAS();

                            #region Company Data Set Fill
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date To " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date To " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #endregion

                            #region Filters
                            #region Employee Filter
                            List<sp_genMasEmployee> oEmployees;
                            if (bEmployeeSelected)
                            {
                                oEmployees = new List<sp_genMasEmployee>();
                                oEmployees.Add(sp_genMasEmployee.Select(txtEmployee.Tag.ToString()));
                            }
                            else
                                oEmployees = sp_genMasEmployee.SelectAll().Where(p => p.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString()).ToList();
                            #endregion

                            if (bDesignationSelected)
                                oEmployees = oEmployees.Where(p => p.Designation_ID == txtDesignation.Tag.ToString()).ToList();

                            if (bDivisionSelected)
                                oEmployees = oEmployees.Where(p => p.Division_ID == txtDivision.Tag.ToString()).ToList();

                            if (bDepartmentSelected)
                                oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();

                            if (bSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();

                            if (bSubSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SubSectionID == txtSubSection.Tag.ToString()).ToList();

                            if (bEmpCategory1Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();

                            if (bEmpCategory2Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();

                            if (bEmpCategory3Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();
                            #endregion

                            foreach (sp_genMasEmployee oEmployee in oEmployees.Where(p => p.Emp_statusID != EmployeeStatus.Resigned.ToString() && p.Emp_statusID != EmployeeStatus.Suspended_With_Pay.ToString() && p.Emp_statusID != EmployeeStatus.Suspended_Without_Pay.ToString() && p.IsTime_Attendance == true))
                            {
                                foreach (tbl_tasTxDailyAttendance oAtten in tbl_tasTxDailyAttendance.SelectAllBy_EmployeeIDWithDateRange(oEmployee.Employee_ID, dtmFromDate.Date, dtmToDate.Date))
                                {
                                    if (oAtten.NoPayMinutesApproved > 0)
                                    {
                                        string sIn_Out = "~";

                                        #region day type
                                        string sDaytype = "WEEK DAY";
                                        if (oAtten.AttendenceDate.DayOfWeek == DayOfWeek.Sunday)
                                            sDaytype = "SUNDAY";
                                        if (oAtten.AttendenceDate.DayOfWeek == DayOfWeek.Saturday)
                                            sDaytype = "SATURDAY";
                                        #endregion

                                        sIn_Out = oAtten.TimeIn_DateTime.ToString(clsConfig.Format_Time) + " - " + oAtten.TimeOut_DateTime.ToString(clsConfig.Format_Time);

                                        glb_dts_TAS.dt_DailyNopay.Adddt_DailyNopayRow(oAtten.AttendenceDate.ToString(clsConfig.Format_Date), sDaytype, sIn_Out,
                                            oEmployee.Employee_ID, oEmployee.EpfNo, oEmployee.SurName + " " + oEmployee.Initails, oEmployee.Initails, oEmployee.AliasName, clsRef_Name.get_Designation_Name(oEmployee.Designation_ID),
                                            oAtten.Shift_ID, clsRef_Name.get_Shift_Name(oAtten.Shift_ID), oAtten.ShiftStartTime.ToString(clsConfig.Format_Time), oAtten.ShiftEndTime.ToString(clsConfig.Format_Time), ConvertMinsToHrsMins(decimal.Parse(oAtten.NoPayMinutesApproved.ToString())));
                                    }
                                }

                                #region MyRegion
                                //for (DateTime date = dtmFromDate.Date; date <= dtmToDate.Date; date = date.AddDays(1))
                                //{
                                //    #region day type
                                //    //string sDaytype = "WD";
                                //    //if (date.DayOfWeek == DayOfWeek.Sunday)
                                //    //    sDaytype = "SU";
                                //    //if (date.DayOfWeek == DayOfWeek.Saturday)
                                //    //    sDaytype = "SA";
                                //    #endregion

                                //    #region Variables for Shift
                                //    DateTime dtmIn = clsConfig.defaultDateTime;
                                //    DateTime dtmOut = clsConfig.defaultDateTime;
                                //    string sIn_Out = "~";
                                //    DateTime dDate = date.Date;
                                //    string sShiftId = "";
                                //    string sShiftName = "";
                                //    ShiftTypes enmShiftType = ShiftTypes.OneDayShift;
                                //    int iShiftDay = 0;
                                //    string sPriviusShift = "";
                                //    bool bShiftSpecialParameeter1 = false;
                                //    bool bShiftSpecialParameeter2 = false;
                                //    int iShiftMinutes = 0;
                                //    int iShiftMinutes_Min = 0;
                                //    int iNextShift_Minutes = 0;
                                //    int iShiftGracePeriod = 0;
                                //    DateTime dtmShiftStart = clsValidation.defaultDateTime;
                                //    DateTime dtmShiftEnd = clsValidation.defaultDateTime;
                                //    string sShiftStart = "";
                                //    string sShiftEnd = "";
                                //    holidayDurationType hdt = holidayDurationType.N_A;
                                //    List<tbl_tasHolidayCalander> oHolidays = tbl_tasHolidayCalander.SelectAllByHolyday_Date(dtmFromDate.Date, dtmToDate.Date).Where(p => p.Holiday_Status).ToList();
                                //    foreach (tbl_tasHolidayCalander oCal in oHolidays.Where(p => p.Holiday_Date.Date == dDate.Date && !p.IsCanceled))
                                //    {
                                //        hdt = (holidayDurationType)oCal.HolidayDurationType;
                                //    }
                                //    #endregion

                                //    #region Get Shift based on Roster or Shift Adjustment
                                //    clsHelpMethods.GetShift(dDate, oEmployee.Employee_ID, hdt, ref sShiftId, ref sShiftName, ref enmShiftType, ref iShiftDay, ref sPriviusShift, ref bShiftSpecialParameeter1, ref bShiftSpecialParameeter2, ref iShiftMinutes, ref iShiftMinutes_Min, ref iNextShift_Minutes, ref iShiftGracePeriod, ref dtmShiftStart, ref dtmShiftEnd, ref sShiftStart, ref sShiftEnd);

                                //    if (sShiftId == "")
                                //        continue;
                                //    #endregion

                                //    bool bNotMidNightCrossShift = false;
                                //    switch (enmShiftType)
                                //    {
                                //        #region Midnight Cross Shift
                                //        case ShiftTypes.MidnightCross:
                                //            {
                                //                DataTable dtResult = DBHandling.ExecQuery("sp_GetInOutTimeFromDate '" + oEmployee.Employee_ID2 + "' , '" + dtmShiftStart.AddHours(-2) + "' , '" + dtmShiftEnd.AddHours(9) + "'").Tables[0];
                                //                clsHelpMethods.Validate_InOutTime_DataTable(ref dtResult);
                                //                if (iShiftMinutes > 0)
                                //                {
                                //                    //DataView dv = dtResult.DefaultView;
                                //                    //dv.Sort = "device_DateTime asc";
                                //                    //dtResult = dv.ToTable();

                                //                    if (dtResult.Rows.Count > 0)
                                //                    {
                                //                        TimeSpan ts = TimeSpan.Zero;
                                //                        dtmIn = DateTime.Parse(dtResult.Rows[0]["device_DateTime"].ToString());

                                //                        int iLastRowNo = dtResult.Rows.Count - 1;
                                //                        if (dtResult.Rows.Count > 1)
                                //                        {
                                //                            dtmOut = DateTime.Parse(dtResult.Rows[iLastRowNo]["device_DateTime"].ToString());

                                //                            if (dtmOut.TimeOfDay < dtmShiftEnd.TimeOfDay)
                                //                            {
                                //                                sIn_Out = dtmIn.ToString(clsConfig.Format_Time) + " - " + dtmOut.ToString(clsConfig.Format_Time);

                                //                                glb_dts_TAS.dt_DailyNopay.Adddt_DailyNopayRow(date.ToString(clsConfig.Format_Date), sDaytype, sIn_Out,
                                //                                    oEmployee.Employee_ID, oEmployee.EpfNo, oEmployee.SurName + " " + oEmployee.Initails, oEmployee.Initails, oEmployee.AliasName, clsRef_Name.get_Designation_Name(oEmployee.Designation_ID),
                                //                                    sShiftId, sShiftName, dtmShiftStart.ToString(clsConfig.Format_Time), dtmShiftEnd.ToString(clsConfig.Format_Time));
                                //                            }
                                //                            else
                                //                                continue;
                                //                        }
                                //                        else
                                //                        {
                                //                            sIn_Out = dtmIn.ToString(clsConfig.Format_Time);

                                //                            glb_dts_TAS.dt_DailyNopay.Adddt_DailyNopayRow(date.ToString(clsConfig.Format_Date), sDaytype, sIn_Out,
                                //                                oEmployee.Employee_ID, oEmployee.EpfNo, oEmployee.SurName + " " + oEmployee.Initails, oEmployee.Initails, oEmployee.AliasName, clsRef_Name.get_Designation_Name(oEmployee.Designation_ID),
                                //                                sShiftId, sShiftName, dtmShiftStart.ToString(clsConfig.Format_Time), dtmShiftEnd.ToString(clsConfig.Format_Time));
                                //                        }
                                //                    }
                                //                    else
                                //                    {
                                //                        glb_dts_TAS.dt_DailyNopay.Adddt_DailyNopayRow(date.ToString(clsConfig.Format_Date), sDaytype, sIn_Out,
                                //                                oEmployee.Employee_ID, oEmployee.EpfNo, oEmployee.SurName + " " + oEmployee.Initails, oEmployee.Initails, oEmployee.AliasName, clsRef_Name.get_Designation_Name(oEmployee.Designation_ID),
                                //                                sShiftId, sShiftName, dtmShiftStart.ToString(clsConfig.Format_Time), dtmShiftEnd.ToString(clsConfig.Format_Time));

                                //                    }
                                //                }
                                //            }
                                //            break;
                                //        #endregion

                                //        #region Two Day Shift
                                //        case ShiftTypes.TwoDayShift:
                                //            {
                                //                DataTable dtResult = DBHandling.ExecQuery("sp_GetInOutTimeFromDate '" + oEmployee.Employee_ID2 + "' , '" + dtmShiftStart.AddHours(-2) + "' , '" + dtmShiftStart.AddHours(iShiftMinutes + 9) + "'").Tables[0];
                                //                clsHelpMethods.Validate_InOutTime_DataTable(ref dtResult);
                                //                if (iShiftMinutes > 0)
                                //                {
                                //                    if (sPriviusShift != sShiftId)
                                //                    {
                                //                        if (dtResult.Rows.Count > 0)
                                //                        {
                                //                            TimeSpan ts = TimeSpan.Zero;
                                //                            dtmIn = DateTime.Parse(dtResult.Rows[0]["device_DateTime"].ToString());

                                //                            int iLastRowNo = dtResult.Rows.Count - 1;
                                //                            if (dtResult.Rows.Count > 1)
                                //                            {
                                //                                dtmOut = DateTime.Parse(dtResult.Rows[iLastRowNo]["device_DateTime"].ToString());

                                //                                if (dtmOut.TimeOfDay < dtmShiftEnd.TimeOfDay)
                                //                                {
                                //                                    sIn_Out = dtmIn.ToString(clsConfig.Format_Time) + " - " + dtmOut.ToString(clsConfig.Format_Time);

                                //                                    glb_dts_TAS.dt_DailyNopay.Adddt_DailyNopayRow(date.ToString(clsConfig.Format_Date), sDaytype, sIn_Out,
                                //                                        oEmployee.Employee_ID, oEmployee.EpfNo, oEmployee.SurName + " " + oEmployee.Initails, oEmployee.Initails, oEmployee.AliasName, clsRef_Name.get_Designation_Name(oEmployee.Designation_ID),
                                //                                        sShiftId, sShiftName, dtmShiftStart.ToString(clsConfig.Format_Time), dtmShiftEnd.ToString(clsConfig.Format_Time));
                                //                                }
                                //                                else
                                //                                    continue;
                                //                            }
                                //                            else
                                //                            {
                                //                                sIn_Out = dtmIn.ToString(clsConfig.Format_Time);

                                //                                glb_dts_TAS.dt_DailyNopay.Adddt_DailyNopayRow(date.ToString(clsConfig.Format_Date), sDaytype, sIn_Out,
                                //                                    oEmployee.Employee_ID, oEmployee.EpfNo, oEmployee.SurName + " " + oEmployee.Initails, oEmployee.Initails, oEmployee.AliasName, clsRef_Name.get_Designation_Name(oEmployee.Designation_ID),
                                //                                    sShiftId, sShiftName, dtmShiftStart.ToString(clsConfig.Format_Time), dtmShiftEnd.ToString(clsConfig.Format_Time));
                                //                            }
                                //                        }
                                //                        else
                                //                        {
                                //                            glb_dts_TAS.dt_DailyNopay.Adddt_DailyNopayRow(date.ToString(clsConfig.Format_Date), sDaytype, sIn_Out,
                                //                                    oEmployee.Employee_ID, oEmployee.EpfNo, oEmployee.SurName + " " + oEmployee.Initails, oEmployee.Initails, oEmployee.AliasName, clsRef_Name.get_Designation_Name(oEmployee.Designation_ID),
                                //                                    sShiftId, sShiftName, dtmShiftStart.ToString(clsConfig.Format_Time), dtmShiftEnd.ToString(clsConfig.Format_Time));

                                //                        }
                                //                    }
                                //                }
                                //            }
                                //            break;
                                //        #endregion

                                //        #region One Day Shifts
                                //        default:
                                //            {
                                //                DataTable dtResult = DBHandling.ExecQuery("sp_GetInOutTimeFromDate '" + oEmployee.Employee_ID2 + "' , '" + dtmShiftStart.Date + "' , '" + dtmShiftStart.Date.AddDays(1).Date + "'").Tables[0];
                                //                clsHelpMethods.Validate_InOutTime_DataTable(ref dtResult);
                                //                if (iShiftMinutes > 0)
                                //                {
                                //                    switch (enmShiftType)
                                //                    {
                                //                        #region One Day, Flexibal
                                //                        case ShiftTypes.FlexibalShift:
                                //                        case ShiftTypes.OneDayShift:
                                //                            if (dtResult.Rows.Count > 0)
                                //                            {
                                //                                TimeSpan ts = TimeSpan.Zero;
                                //                                dtmIn = DateTime.Parse(dtResult.Rows[0]["device_DateTime"].ToString());

                                //                                int iLastRowNo = dtResult.Rows.Count - 1;
                                //                                if (dtResult.Rows.Count > 1)
                                //                                {
                                //                                    dtmOut = DateTime.Parse(dtResult.Rows[iLastRowNo]["device_DateTime"].ToString());

                                //                                    if (dtmOut.TimeOfDay < dtmShiftEnd.TimeOfDay)
                                //                                    {
                                //                                        sIn_Out = dtmIn.ToString(clsConfig.Format_Time) + " - " + dtmOut.ToString(clsConfig.Format_Time);

                                //                                        //ts = dtmOut.TimeOfDay - dtmShiftEnd.TimeOfDay; //19:00 - 18-05 = 0.55
                                //                                        glb_dts_TAS.dt_DailyNopay.Adddt_DailyNopayRow(date.ToString(clsConfig.Format_Date), sDaytype, sIn_Out,
                                //                                            oEmployee.Employee_ID, oEmployee.EpfNo, oEmployee.SurName + " " + oEmployee.Initails, oEmployee.Initails, oEmployee.AliasName, clsRef_Name.get_Designation_Name(oEmployee.Designation_ID),
                                //                                            sShiftId, sShiftName, dtmShiftStart.ToString(clsConfig.Format_Time), dtmShiftEnd.ToString(clsConfig.Format_Time));
                                //                                    }
                                //                                    else
                                //                                        continue;
                                //                                }
                                //                                else
                                //                                {
                                //                                    sIn_Out = dtmIn.ToString(clsConfig.Format_Time);

                                //                                    //ts = dtmOut.TimeOfDay - dtmShiftEnd.TimeOfDay; //19:00 - 18-05 = 0.55
                                //                                    glb_dts_TAS.dt_DailyNopay.Adddt_DailyNopayRow(date.ToString(clsConfig.Format_Date), sDaytype, sIn_Out,
                                //                                        oEmployee.Employee_ID, oEmployee.EpfNo, oEmployee.SurName + " " + oEmployee.Initails, oEmployee.Initails, oEmployee.AliasName, clsRef_Name.get_Designation_Name(oEmployee.Designation_ID),
                                //                                        sShiftId, sShiftName, dtmShiftStart.ToString(clsConfig.Format_Time), dtmShiftEnd.ToString(clsConfig.Format_Time));
                                //                                }
                                //                            }
                                //                            else
                                //                            {
                                //                                glb_dts_TAS.dt_DailyNopay.Adddt_DailyNopayRow(date.ToString(clsConfig.Format_Date), sDaytype, sIn_Out,
                                //                                        oEmployee.Employee_ID, oEmployee.EpfNo, oEmployee.SurName + " " + oEmployee.Initails, oEmployee.Initails, oEmployee.AliasName, clsRef_Name.get_Designation_Name(oEmployee.Designation_ID),
                                //                                        sShiftId, sShiftName, dtmShiftStart.ToString(clsConfig.Format_Time), dtmShiftEnd.ToString(clsConfig.Format_Time));

                                //                            }
                                //                            break;
                                //                        #endregion
                                //                    }
                                //                }
                                //            }
                                //            break;
                                //        #endregion
                                //    }
                                //} 
                                #endregion
                            }

                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_TAS, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }
                        #endregion

                        #region Attendance Incentive Report
                        else if (Report == enum_ReportName.AttendanceIncentive)
                        {
                            DataSets.dts_TAS glb_dts_TAS = new DataSets.dts_TAS();

                            #region Company Data Set Fill
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date To " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                                glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date To " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #endregion

                            #region Filters
                            #region Employee Filter
                            List<sp_genMasEmployee> oEmployees;
                            if (bEmployeeSelected)
                            {
                                oEmployees = new List<sp_genMasEmployee>();
                                oEmployees.Add(sp_genMasEmployee.Select(txtEmployee.Tag.ToString()));
                            }
                            else
                                oEmployees = sp_genMasEmployee.SelectAll().Where(p => p.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString()).ToList();
                            #endregion

                            if (bDesignationSelected)
                                oEmployees = oEmployees.Where(p => p.Designation_ID == txtDesignation.Tag.ToString()).ToList();

                            if (bDivisionSelected)
                                oEmployees = oEmployees.Where(p => p.Division_ID == txtDivision.Tag.ToString()).ToList();

                            if (bDepartmentSelected)
                                oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();

                            if (bSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();

                            if (bSubSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SubSectionID == txtSubSection.Tag.ToString()).ToList();

                            if (bEmpCategory1Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();

                            if (bEmpCategory2Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();

                            if (bEmpCategory3Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();
                            #endregion

                            foreach (sp_genMasEmployee oEmployee in oEmployees.Where(p => p.Emp_statusID != EmployeeStatus.Resigned.ToString() && p.Emp_statusID != EmployeeStatus.Suspended_With_Pay.ToString() && p.Emp_statusID != EmployeeStatus.Suspended_Without_Pay.ToString() && p.IsTime_Attendance == true))
                            {
                                List<tbl_tasTxMonthlyAttendance> oMonthlyAttendance = tbl_tasTxMonthlyAttendance.SelectAllBy_EmployeeIDWithDateRange(oEmployee.Employee_ID, dtmFromDate.Date, dtmToDate.Date).ToList();
                                foreach (tbl_tasTxMonthlyAttendance oOldRecord in oMonthlyAttendance)
                                {
                                    glb_dts_TAS.dt_AttendanceIncentive.Adddt_AttendanceIncentiveRow(oEmployee.Employee_ID, clsRef_Name.get_EmployeeShortName(oEmployee.Employee_ID),
                                        oEmployee.EpfNo, oEmployee.Department_ID, oEmployee.DepartmentName, oEmployee.Designation_name, oOldRecord.AttendanceIncentive, 0m);
                                }
                            }

                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_TAS, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }
                        #endregion

                        #endregion

                        #region C.C. REPORTS - Hero Nature

                        #region DeShelling Clearing Daily Output / Shell Removing - Attendance Allowance
                        else if (Report == enum_ReportName.DeShellingClearingDailyOutput_CC || Report == enum_ReportName.ShellRemovingWorkersAttendanceAllowance_CC)
                        {
                            DataSets.dts_TAS_CC glb_dts_TAS_CC = new DataSets.dts_TAS_CC();
                            //glb_dts_TAS_CC.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #region Company Data Set Fill
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_TAS_CC.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                                glb_dts_TAS_CC.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #endregion

                            #region Filters
                            #region Employee Filter
                            List<tbl_genMasEmployee> oEmployees = new List<tbl_genMasEmployee>(); ;
                            if (bEmployeeSelected)
                            {
                                oEmployees.Add(tbl_genMasEmployee.Select(txtEmployee.Tag.ToString(), clsSecurity.CompanyID, clsSecurity.BranchID));
                            }
                            else
                            {
                                oEmployees = tbl_genMasEmployee.SelectAll().ToList();
                            }
                            #endregion

                            #region Section filter
                            if (bSectionSelected)
                            {
                                oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();
                            }
                            #endregion
                            #endregion

                            foreach (tbl_genMasEmployee oEmployee in oEmployees.Where(p => p.IsTime_Attendance == true))
                            {
                                foreach (tbl_ccTxDailyWorkingProgress oDailyWorking in tbl_ccTxDailyWorkingProgress.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, oEmployee.Employee_ID).Where(r => r.AttendenceDate >= dtmFromDate.Date && r.AttendenceDate <= dtmToDate.Date))
                                {
                                    tbl_hrPeriod_Week oWeek = tbl_hrPeriod_Week.SelectAll().Where(r => r.StartDate.Date <= oDailyWorking.AttendenceDate.Date && r.EndDate.Date >= oDailyWorking.AttendenceDate.Date).OrderByDescending(o => o.Week_ID).First();
                                    glb_dts_TAS_CC.dt_coconutcuttng_dailyEntry.Adddt_coconutcuttng_dailyEntryRow(oDailyWorking.Employee_ID, clsRef_Name.get_EmployeeEPFNo(oDailyWorking.Employee_ID), oEmployee.Initails + " , " + oEmployee.SurName, clsRef_Name.get_Section_Name(oEmployee.SectionID), oWeek.Week_ID, oWeek.StartDate.Date, oDailyWorking.AttendenceDate, CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(oDailyWorking.AttendenceDate.DayOfWeek), oDailyWorking.TimeIn_DateTime, oDailyWorking.TimeOut_DateTime, oDailyWorking.Qty_Grade1, oDailyWorking.Qty_Grade2, oDailyWorking.Qty_Grade1_Night, oDailyWorking.Qty_Grade2_Night, oDailyWorking.Attendance_index, oDailyWorking.Attendace_Allowance, oDailyWorking.Travel_Allowance);
                                }
                            }

                            #region Formular Fields
                            if (clsConfig.bHideCompanyImageInReports)
                                glb_dts_ExportReport.dt_rptParameter.Rows.Add("ShowImage", "false", true);
                            #endregion

                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_TAS_CC, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }

                        #endregion

                        #region ShellRemoving Workers' Salary_Denomination  / ShellRemoving Workers' Salary / ShellRemoving Workers Allowance /ShellRemoving Workers Travelling Allowance / CC_PaySlip
                        else if (Report == enum_ReportName.ShellRemovingWorkersSalary_Denomination_CC || Report == enum_ReportName.ShellRemovingWorkersSalary_CC || Report == enum_ReportName.ShellRemovingWorkersAllowance_CC || Report == enum_ReportName.ShellRemovingWorkersTravellingAllowance_CC || Report == enum_ReportName.EmployeePaySlip_CC)
                        {
                            DataSets.dts_TAS_CC glb_dts_TAS_CC = new DataSets.dts_TAS_CC();
                            //glb_dts_TAS_CC.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #region Company Data Set Fill
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_TAS_CC.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                                glb_dts_TAS_CC.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #endregion

                            #region Filters
                            #region Employee Filter
                            List<tbl_genMasEmployee> oEmployees = new List<tbl_genMasEmployee>(); ;
                            if (bEmployeeSelected)
                            {
                                oEmployees.Add(tbl_genMasEmployee.Select(txtEmployee.Tag.ToString(), clsSecurity.CompanyID, clsSecurity.BranchID));
                            }
                            else
                            {
                                oEmployees = tbl_genMasEmployee.SelectAll().ToList();
                            }
                            #endregion

                            #region Section filter
                            if (bSectionSelected)
                            {
                                oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();
                            }
                            #endregion
                            #endregion

                            foreach (tbl_genMasEmployee oEmployee in oEmployees.Where(p => p.IsTime_Attendance == true))
                            {
                                tbl_ccTxEndOfWeekProgress EOW_emp = tbl_ccTxEndOfWeekProgress.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oEmployee.Employee_ID, int.Parse(txtYear.Tag.ToString()), int.Parse(txtWeek.Tag.ToString()));
                                if (EOW_emp != null)
                                {
                                    tbl_hrPeriod_Week oWeek = tbl_hrPeriod_Week.Select(clsSecurity.CompanyID, clsSecurity.BranchID, EOW_emp.Year_ID, EOW_emp.Week_ID);
                                    glb_dts_TAS_CC.dt_ShellRemovingWorkersSalary.Adddt_ShellRemovingWorkersSalaryRow(EOW_emp.Week_ID, oWeek.StartDate.Date, oWeek.EndDate.Date, oEmployee.Employee_ID, oEmployee.EpfNo, (oEmployee.Initails + ", " + oEmployee.SurName), oEmployee.NicNo, oEmployee.Department_ID, clsRef_Name.get_Department_Name(oEmployee.Department_ID), oEmployee.SectionID, clsRef_Name.get_Section_Name(oEmployee.SectionID), EOW_emp.WorkingDays_Mandatory, EOW_emp.WorkingDays_Actual, EOW_emp.Qty_weeklyTarget, EOW_emp.Qty_Actual, EOW_emp.Salary_Basic, EOW_emp.Salary_Basic_PS, EOW_emp.Allowance_Budgetary1, EOW_emp.Allowance_Budgetary2, EOW_emp.Allowance_Budgetary3, EOW_emp.Allowance_Transport, EOW_emp.Allowance_Attendence, 0, EOW_emp.Salary_Gross, EOW_emp.Salary_Gross_PS, EOW_emp.Deductions_EPF_8, EOW_emp.Deductions_ETF_3, EOW_emp.Deductions_EPF_12, EOW_emp.Deduction_Loan, EOW_emp.Deduction_Festival, EOW_emp.Deduction_Other, EOW_emp.Salary_Net, GetRoudDecimalNerestTen(EOW_emp.Salary_Net), EOW_emp.Salary_Net_PS);
                                }
                            }

                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_TAS_CC, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }
                        #endregion

                        #region Shell Removing Payments Detailed - Employee Wise
                        else if (Report == enum_ReportName.ShellRemovingPayments_CC || Report == enum_ReportName.ShellRemovingPayments_NightTime_CC)
                        {
                            if (txtYear.Tag != null && txtWeek.Tag != null)
                            {
                                DataSets.dts_TAS_CC glb_dts_TAS_CC = new DataSets.dts_TAS_CC();
                                //glb_dts_TAS_CC.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                #region Company Data Set Fill
                                if (bDivisionSelected)
                                {
                                    CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                    glb_dts_TAS_CC.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                }
                                else
                                    glb_dts_TAS_CC.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                #endregion

                                int sYear = int.Parse(txtYear.Tag.ToString());
                                int iWeek = int.Parse(txtWeek.Tag.ToString());

                                #region Filters
                                #region Employee Filter
                                List<tbl_genMasEmployee> oEmployees;
                                if (bEmployeeSelected)
                                {
                                    oEmployees = new List<tbl_genMasEmployee>();
                                    oEmployees.Add(tbl_genMasEmployee.Select(txtEmployee.Tag.ToString(), clsSecurity.CompanyID, clsSecurity.BranchID));
                                }
                                else
                                {
                                    oEmployees = tbl_genMasEmployee.SelectAll().ToList();
                                }
                                #endregion

                                #region Section filter
                                if (bSectionSelected)
                                {
                                    oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();
                                }
                                #endregion
                                #endregion

                                foreach (tbl_genMasEmployee oEmployee in oEmployees.Where(p => p.IsTime_Attendance == true))
                                {
                                    tbl_ccTxEndOfWeekProgress EOW_emp = tbl_ccTxEndOfWeekProgress.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oEmployee.Employee_ID, int.Parse(txtYear.Tag.ToString()), int.Parse(txtWeek.Tag.ToString()));

                                    if (EOW_emp != null)
                                    {
                                        tbl_hrPeriod_Week oWeek = tbl_hrPeriod_Week.Select(clsSecurity.CompanyID, clsSecurity.BranchID, EOW_emp.Year_ID, EOW_emp.Week_ID);

                                        glb_dts_TAS_CC.dt_ShellRemovingWorkersSalary.Adddt_ShellRemovingWorkersSalaryRow(EOW_emp.Week_ID, oWeek.StartDate.Date, oWeek.EndDate.Date, oEmployee.Employee_ID, oEmployee.EpfNo, (oEmployee.Initails + ", " + oEmployee.SurName), oEmployee.NicNo, oEmployee.Department_ID, clsRef_Name.get_Department_Name(oEmployee.Department_ID), oEmployee.SectionID, clsRef_Name.get_Section_Name(oEmployee.SectionID), EOW_emp.WorkingDays_Mandatory, EOW_emp.WorkingDays_Actual, EOW_emp.Qty_weeklyTarget, EOW_emp.Qty_Actual, EOW_emp.Salary_Basic, EOW_emp.Salary_Basic_PS, EOW_emp.Allowance_Budgetary1, EOW_emp.Allowance_Budgetary2, EOW_emp.Allowance_Budgetary3, EOW_emp.Allowance_Transport, EOW_emp.Allowance_Attendence, 0, EOW_emp.Salary_Gross, EOW_emp.Salary_Gross_PS, EOW_emp.Deductions_EPF_8, EOW_emp.Deductions_ETF_3, EOW_emp.Deductions_EPF_12, EOW_emp.Deduction_Loan, EOW_emp.Deduction_Festival, EOW_emp.Deduction_Other, EOW_emp.Salary_Net, Math.Round(EOW_emp.Salary_Net / 100m, 0) * 100, EOW_emp.Salary_Net_PS);
                                        //#region Company Data Set Fill
                                        //if (bDivisionSelected)
                                        //{
                                        //    CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                        //    glb_dts_TAS_CC.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                        //}
                                        //else
                                        //    glb_dts_TAS_CC.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                        //#endregion

                                        foreach (tbl_ccTxDailyWorkingProgress oDailyWorking in tbl_ccTxDailyWorkingProgress.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, oEmployee.Employee_ID).Where(r => r.AttendenceDate >= dtmFromDate.Date && r.AttendenceDate <= dtmToDate.Date))
                                        {
                                            //tbl_hrPeriod_Week oWeek = tbl_hrPeriod_Week.SelectAll().Where(r => r.StartDate.Date <= oDailyWorking.AttendenceDate.Date).OrderByDescending(o => o.Week_ID).First();
                                            glb_dts_TAS_CC.dt_coconutcuttng_dailyEntry.Adddt_coconutcuttng_dailyEntryRow(oDailyWorking.Employee_ID, clsRef_Name.get_EmployeeEPFNo(oDailyWorking.Employee_ID), oEmployee.Initails + " , " + oEmployee.SurName, clsRef_Name.get_Section_Name(oEmployee.SectionID), oWeek.Week_ID, oWeek.StartDate.Date, oDailyWorking.AttendenceDate, CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(oDailyWorking.AttendenceDate.DayOfWeek), oDailyWorking.TimeIn_DateTime, oDailyWorking.TimeOut_DateTime, oDailyWorking.Qty_Grade1, oDailyWorking.Qty_Grade2, oDailyWorking.Qty_Grade1_Night, oDailyWorking.Qty_Grade2_Night, oDailyWorking.Attendance_index, oDailyWorking.Attendace_Allowance, oDailyWorking.Travel_Allowance);

                                            foreach (tbl_ccTxDailyWorkingProgress_Rate oDailyRate in tbl_ccTxDailyWorkingProgress_Rate.SelectAllByCompany_ID_CompanyBranch_ID_Attendance_index(oDailyWorking.Company_ID, oDailyWorking.CompanyBranch_ID, oDailyWorking.Attendance_index))
                                            {
                                                if (Report == enum_ReportName.ShellRemovingPayments_CC && oDailyRate.IsNightTimeWork)
                                                    continue;

                                                if (Report == enum_ReportName.ShellRemovingPayments_NightTime_CC && !oDailyRate.IsNightTimeWork)
                                                    continue;

                                                glb_dts_TAS_CC.dt_coconutcuttng_dailyEntry_rates.Adddt_coconutcuttng_dailyEntry_ratesRow(oDailyRate.Attendance_index, oDailyRate.Grade_ID, ((Grade)oDailyRate.Grade_ID).ToString() + " Nuts", oDailyRate.DayType, ((DayTypes)oDailyRate.DayType).ToString(), oDailyRate.Qty, oDailyRate.Rate, oDailyRate.Amount);
                                            }
                                        }
                                    }
                                }
                                frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                                frmViewer.print(oReport.ReportPath, glb_dts_TAS_CC, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                            }
                            else
                            {
                                SEACCMessageBox.Show("Please Select a Week", "", MessageBoxButton.OK, "Red");
                            }
                        }
                        #endregion

                        #region Coconut Washing Payments
                        else if (Report == enum_ReportName.CoconutWashingPayment_CC)
                        {
                            if (txtYear.Tag != null && txtWeek.Tag != null)
                            {

                                DataSets.dts_TAS_CC glb_dts_TAS_CC = new DataSets.dts_TAS_CC();
                                //glb_dts_TAS_CC.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                #region Company Data Set Fill
                                if (bDivisionSelected)
                                {
                                    CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                    glb_dts_TAS_CC.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                }
                                else
                                    glb_dts_TAS_CC.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                #endregion

                                int sYear = int.Parse(txtYear.Tag.ToString());
                                int iWeek = int.Parse(txtWeek.Tag.ToString());

                                #region Filters
                                #region Employee Filter
                                List<tbl_genMasEmployee> oEmployees;
                                if (bEmployeeSelected)
                                {
                                    oEmployees = new List<tbl_genMasEmployee>();
                                    oEmployees.Add(tbl_genMasEmployee.Select(txtEmployee.Tag.ToString(), clsSecurity.CompanyID, clsSecurity.BranchID));
                                }
                                else
                                {
                                    oEmployees = tbl_genMasEmployee.SelectAll().ToList();
                                }
                                #endregion

                                #region Section filter
                                if (bSectionSelected)
                                {
                                    oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();
                                }
                                #endregion
                                #endregion

                                foreach (tbl_genMasEmployee oEmployee in oEmployees.Where(p => p.IsTime_Attendance == true))
                                {
                                    tbl_ccTxEndOfWeekWashingProgress EOW_emp = tbl_ccTxEndOfWeekWashingProgress.Select(clsSecurity.CompanyID, clsSecurity.BranchID, int.Parse(txtYear.Tag.ToString()), int.Parse(txtWeek.Tag.ToString()), oEmployee.Employee_ID);
                                    if (EOW_emp != null)
                                    {
                                        tbl_hrPeriod_Week oWeek = tbl_hrPeriod_Week.Select(clsSecurity.CompanyID, clsSecurity.BranchID, EOW_emp.Year_ID, EOW_emp.Week_ID);
                                        glb_dts_TAS_CC.dt_coconutwashing_EndOfWeek.Adddt_coconutwashing_EndOfWeekRow(EOW_emp.Year_ID, EOW_emp.Week_ID, oWeek.StartDate.Date, oWeek.EndDate.Date, oEmployee.Employee_ID, oEmployee.EpfNo, (oEmployee.Initails + ", " + oEmployee.SurName), EOW_emp.WorkingDays_Mandatory, EOW_emp.WorkingDays_Actual, EOW_emp.Qty_WeekTotal, EOW_emp.Qty_WeekWashed, EOW_emp.Earn_Total);

                                        foreach (tbl_ccTxDailyWashingProgress oDailyWashing in tbl_ccTxDailyWashingProgress.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, oEmployee.Employee_ID).Where(r => r.AttendenceDate >= dtmFromDate.Date && r.AttendenceDate <= dtmToDate.Date))
                                            glb_dts_TAS_CC.dt_coconutwashing_dailyEntry.Adddt_coconutwashing_dailyEntryRow(oDailyWashing.Attendance_index, oDailyWashing.AttendenceDate, oDailyWashing.TimeIn_DateTime, oDailyWashing.TimeOut_DateTime, oDailyWashing.DayType.ToString(), oWeek.Year_ID, oWeek.Week_ID, oDailyWashing.Employee_ID, oDailyWashing.Washing_Allo, oDailyWashing.Attendance_Allo, oDailyWashing.Budgetary_Allo, oDailyWashing.Qty_Total, oDailyWashing.Rate, oDailyWashing.Earn_Total);
                                    }
                                }
                                frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                                frmViewer.print(oReport.ReportPath, glb_dts_TAS_CC, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                            }
                            else
                            {
                                SEACCMessageBox.Show("Please Select a Week", "", MessageBoxButton.OK, "Red");
                            }
                        }
                        #endregion

                        #region Coconut Temporary Workers Payments
                        else if (Report == enum_ReportName.TemporaryWorkers_CC)
                        {
                            if (txtYear.Tag != null && txtWeek.Tag != null)
                            {
                                DataSets.dts_TAS_CC glb_dts_TAS_CC = new DataSets.dts_TAS_CC();

                                #region Company Data Set Fill
                                if (bDivisionSelected)
                                {
                                    CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                    glb_dts_TAS_CC.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                }
                                else
                                    glb_dts_TAS_CC.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                #endregion

                                int iYear = int.Parse(txtYear.Tag.ToString());
                                int iWeek = int.Parse(txtWeek.Tag.ToString());

                                #region Filters
                                #region Employee Filter
                                List<tbl_genMasEmployee> oEmployees;
                                if (bEmployeeSelected)
                                {
                                    oEmployees = new List<tbl_genMasEmployee>();
                                    oEmployees.Add(tbl_genMasEmployee.Select(txtEmployee.Tag.ToString(), clsSecurity.CompanyID, clsSecurity.BranchID));
                                }
                                else
                                {
                                    oEmployees = tbl_genMasEmployee.SelectAll().ToList();
                                }
                                #endregion

                                #region Section filter
                                if (bSectionSelected)
                                {
                                    oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();
                                }
                                #endregion
                                #endregion

                                foreach (tbl_genMasEmployee oEmployee in oEmployees.Where(p => p.IsTime_Attendance == true))
                                {
                                    foreach (tbl_ccTxTemporaryWorkerDailyWage oTempWorker in tbl_ccTxTemporaryWorkerDailyWage.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, oEmployee.Employee_ID).Where(r => r.Week_ID == iWeek && r.Year_ID == iYear && !r.IsCanceled))
                                    {
                                        tbl_hrPeriod_Week oWeek = tbl_hrPeriod_Week.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oTempWorker.Year_ID, oTempWorker.Week_ID);
                                        glb_dts_TAS_CC.dt_TemporaryWorkers_dailyEntry.Adddt_TemporaryWorkers_dailyEntryRow(oTempWorker.Year_ID, oTempWorker.Week_ID, oWeek.StartDate.Date, oWeek.EndDate.Date, oTempWorker.AttendenceDate.Date, oEmployee.Employee_ID, oEmployee.EpfNo, (oEmployee.Initails + ", " + oEmployee.SurName), 0, 0, oTempWorker.Daily_Wage, oTempWorker.Meal_Allowance, oTempWorker.Other_Allowance, oTempWorker.Attendance_Allowance, oTempWorker.SOT_Amount, oTempWorker.DOT_Amount, oTempWorker.TOT_Amount);
                                    }
                                }

                                frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                                frmViewer.print(oReport.ReportPath, glb_dts_TAS_CC, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                            }
                            else
                            {
                                SEACCMessageBox.Show("Please Select a Week", "", MessageBoxButton.OK, "Red");
                            }
                        }
                        #endregion

                        #region Shell Removing Monthly Summary Sheet / EPF Summary Sheet
                        else if (Report == enum_ReportName.ShellRemovingMonthlySummary || Report == enum_ReportName.ShellRemovingEPFSummary)
                        {
                            try
                            {
                                DataSets.dts_TAS_CC glb_dts_TAS_CC = new DataSets.dts_TAS_CC();
                                //glb_dts_TAS_CC.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                #region Company Data Set Fill
                                if (bDivisionSelected)
                                {
                                    CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                    glb_dts_TAS_CC.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                }
                                else
                                    glb_dts_TAS_CC.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                #endregion

                                #region Filters
                                #region Employee Filter
                                List<tbl_genMasEmployee> oEmployees;
                                if (bEmployeeSelected)
                                {
                                    oEmployees = new List<tbl_genMasEmployee>();
                                    oEmployees.Add(tbl_genMasEmployee.Select(txtEmployee.Tag.ToString(), clsSecurity.CompanyID, clsSecurity.BranchID));
                                }
                                else
                                {
                                    oEmployees = tbl_genMasEmployee.SelectAll().ToList();
                                }
                                #endregion

                                #region Section filter
                                if (bSectionSelected)
                                {
                                    oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();
                                }
                                #endregion
                                #endregion

                                #region Weekly Payment Workers
                                //#region Rates / Parameters
                                //decimal dSalaryParameeter = 351.67m / 1000m;
                                //decimal dBudgetoryAllowanceDayRate1 = 40;
                                //decimal dBudgetoryAllowanceDayRate2 = 60;
                                //decimal dBudgetoryAllowanceDayRate3 = 40;
                                //decimal dAttendenceAllowanceDayrate = 100;
                                //#endregion

                                foreach (tbl_genMasEmployee oEmp in oEmployees)
                                {
                                    #region Variables
                                    decimal dGoodNuts_Monthly = 0;
                                    decimal dDamageNuts_Monthly = 0;

                                    decimal dBasicSalary_Monthly = 0;
                                    decimal dBasicSalary_Monthly_PS = 0;
                                    decimal dBudgetoryAllowance1_Monthly = 0;
                                    decimal dBudgetoryAllowance2_Monthly = 0;
                                    decimal dBudgetoryAllowance3_Monthly = 0;
                                    decimal dAttendenceAllowance_Monthly = 0;
                                    decimal dTravellingAllowance_Monthly = 0;
                                    decimal dTotalEarn_Monthly = 0;
                                    decimal dTotalEarn_Monthly_PS = 0;
                                    decimal dEPF_08_Monthly = 0;
                                    decimal dEPF_12_Monthly = 0;
                                    decimal dETF_03_Monthly = 0;
                                    decimal dLoanDed_Monthly = 0;
                                    decimal dFestivalDed_Monthly = 0;
                                    decimal dOtherDed_Monthly = 0;
                                    decimal dNetSalary_Monthly = 0;
                                    #endregion

                                    List<tbl_ccTxDailyWorkingProgress> oWIP_CCs = tbl_ccTxDailyWorkingProgress.SelectAllBy_DateRange(clsSecurity.CompanyID, clsSecurity.BranchID, oEmp.Employee_ID, dtmFromDate.Date, dtmToDate.Date).Where(r => r.PaymentPeriod == (int)CC_PaymentPeriod.Weekly).ToList();
                                    if (oWIP_CCs.Count == 0)
                                        continue;
                                    foreach (tbl_ccTxDailyWorkingProgress oWIP_CC in oWIP_CCs)
                                    {
                                        if (oWIP_CC.Qty_Grade1 > 0 || oWIP_CC.Qty_Grade2 > 0)
                                        {
                                            dGoodNuts_Monthly += oWIP_CC.Qty_Grade1;
                                            dDamageNuts_Monthly += oWIP_CC.Qty_Grade2;

                                            dBasicSalary_Monthly += oWIP_CC.Amount_Total;
                                            dBasicSalary_Monthly_PS += oWIP_CC.Amount_Payslip;
                                            dBudgetoryAllowance1_Monthly += oWIP_CC.Budgetary_Allowance1;
                                            dBudgetoryAllowance2_Monthly += oWIP_CC.Budgetary_Allowance2;
                                            dBudgetoryAllowance3_Monthly += oWIP_CC.Budgetary_Allowance3;
                                            dAttendenceAllowance_Monthly += oWIP_CC.Attendace_Allowance;
                                            dTravellingAllowance_Monthly += oWIP_CC.Travel_Allowance;

                                            dEPF_08_Monthly += oWIP_CC.Epf_8;
                                            dEPF_12_Monthly += oWIP_CC.Epf_12;
                                            dETF_03_Monthly += oWIP_CC.Etf_3;
                                        }
                                    }

                                    dTotalEarn_Monthly = dBasicSalary_Monthly + dBudgetoryAllowance1_Monthly + dAttendenceAllowance_Monthly + dTravellingAllowance_Monthly;
                                    dTotalEarn_Monthly_PS = dBasicSalary_Monthly_PS + dBudgetoryAllowance1_Monthly + dBudgetoryAllowance2_Monthly + dBudgetoryAllowance3_Monthly;

                                    DataTable dt_Deductions = DBHandling.ExecQuery("sp_getShellRemovingLoandDeduction_GivenPeriod 'Company1', 'default', '" + oEmp.Employee_ID + "', '" + dtmFromDate.Date + "', '" + dtmToDate.Date + "'").Tables[0];
                                    if (dt_Deductions.Rows.Count > 0)
                                    {
                                        dLoanDed_Monthly = decimal.Parse(dt_Deductions.Rows[0]["LoanDed"].ToString());
                                        dFestivalDed_Monthly = decimal.Parse(dt_Deductions.Rows[0]["FestivalDed"].ToString());
                                        dOtherDed_Monthly = decimal.Parse(dt_Deductions.Rows[0]["OtherDed"].ToString()); ;
                                    }
                                    dNetSalary_Monthly = dTotalEarn_Monthly - dEPF_08_Monthly - dLoanDed_Monthly - dFestivalDed_Monthly - dOtherDed_Monthly;
                                    glb_dts_TAS_CC.dt_ShellRemoving_MonthlySummary.Adddt_ShellRemoving_MonthlySummaryRow(oEmp.Employee_ID, oEmp.EpfNo, clsRef_Name.get_EmployeeShortName_initialsFirst(oEmp.Employee_ID), dGoodNuts_Monthly, dDamageNuts_Monthly, 0, 0, dBasicSalary_Monthly_PS, dBasicSalary_Monthly, dBudgetoryAllowance1_Monthly, dBudgetoryAllowance2_Monthly, dBudgetoryAllowance3_Monthly, dAttendenceAllowance_Monthly, dTravellingAllowance_Monthly, 0, dTotalEarn_Monthly, dLoanDed_Monthly, dFestivalDed_Monthly, dOtherDed_Monthly, 0, dEPF_08_Monthly, (dNetSalary_Monthly > 0 ? dNetSalary_Monthly : 0), dEPF_12_Monthly, dETF_03_Monthly, "Weekly Wages - Shell Removers ");
                                }
                                #endregion

                                #region Daily Payment Temporary Workers
                                foreach (tbl_genMasEmployee oEmp in oEmployees)
                                {
                                    #region Variables
                                    decimal dGoodNuts_Monthly = 0;
                                    decimal dDamageNuts_Monthly = 0;
                                    decimal dPayment_Monthly = 0;
                                    #endregion

                                    List<tbl_ccTxDailyWorkingProgress> oWIP_CCs = tbl_ccTxDailyWorkingProgress.SelectAllBy_DateRange(clsSecurity.CompanyID, clsSecurity.BranchID, oEmp.Employee_ID, dtmFromDate.Date, dtmToDate.Date).Where(r => r.PaymentPeriod == (int)CC_PaymentPeriod.Daily).ToList();
                                    if (oWIP_CCs.Count == 0)
                                        continue;
                                    foreach (tbl_ccTxDailyWorkingProgress oWIP_CC in oWIP_CCs)
                                    {
                                        if (oWIP_CC.Qty_Grade1 > 0 || oWIP_CC.Qty_Grade2 > 0)
                                        {
                                            dGoodNuts_Monthly += oWIP_CC.Qty_Grade1;
                                            dDamageNuts_Monthly += oWIP_CC.Qty_Grade2;
                                            dPayment_Monthly += oWIP_CC.Amount_Total;
                                        }
                                    }
                                    glb_dts_TAS_CC.dt_ShellRemoving_MonthlySummary.Adddt_ShellRemoving_MonthlySummaryRow(oEmp.Employee_ID, oEmp.EpfNo, clsRef_Name.get_EmployeeShortName_initialsFirst(oEmp.Employee_ID), dGoodNuts_Monthly, dDamageNuts_Monthly, 0, 0, 0, dPayment_Monthly, 0, 0, 0, 0, 0, 0, dPayment_Monthly, 0, 0, 0, 0, 0, dPayment_Monthly, 0, 0, "Tempory De-Shellers");
                                }
                                #endregion

                                frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                                frmViewer.print(oReport.ReportPath, glb_dts_TAS_CC, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                            }
                            catch (Exception ex)
                            {
                                SEACCExeption.Show(ex);
                            }
                        }
                        #endregion

                        #region Shell Removing - Permanent Workers' Allowance
                        else if (Report == enum_ReportName.ShellRemovingMonthlySummary_PermenentWorkers)
                        {
                            try
                            {
                                DataSets.dts_TAS_CC glb_dts_TAS_CC = new DataSets.dts_TAS_CC();
                                //glb_dts_TAS_CC.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                #region Company Data Set Fill
                                if (bDivisionSelected)
                                {
                                    CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                    glb_dts_TAS_CC.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                }
                                else
                                    glb_dts_TAS_CC.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date2) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                #endregion

                                #region Filters
                                #region Employee Filter
                                List<tbl_genMasEmployee> oEmployees;
                                if (bEmployeeSelected)
                                {
                                    oEmployees = new List<tbl_genMasEmployee>();
                                    oEmployees.Add(tbl_genMasEmployee.Select(txtEmployee.Tag.ToString(), clsSecurity.CompanyID, clsSecurity.BranchID));
                                }
                                else
                                {
                                    oEmployees = tbl_genMasEmployee.SelectAll().ToList();
                                }
                                #endregion

                                #region Section filter
                                if (bSectionSelected)
                                {
                                    oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();
                                }
                                #endregion
                                #endregion

                                foreach (tbl_genMasEmployee oEmp in oEmployees)
                                {
                                    #region Variables
                                    decimal dGoodNuts_Monthly = 0;
                                    decimal dDamageNuts_Monthly = 0;
                                    decimal dAllowance_Monthly = 0;
                                    #endregion

                                    List<tbl_ccTxDailyWorkingProgress> oWIP_CCs = tbl_ccTxDailyWorkingProgress.SelectAllBy_DateRange(clsSecurity.CompanyID, clsSecurity.BranchID, oEmp.Employee_ID, dtmFromDate.Date, dtmToDate.Date).Where(r => r.PaymentPeriod == (int)CC_PaymentPeriod.Monthly).ToList();
                                    if (oWIP_CCs.Count == 0)
                                        continue;
                                    foreach (tbl_ccTxDailyWorkingProgress oWIP_CC in oWIP_CCs)
                                    {
                                        if (oWIP_CC.Qty_Grade1 > 0 || oWIP_CC.Qty_Grade2 > 0)
                                        {
                                            dGoodNuts_Monthly += oWIP_CC.Qty_Grade1;
                                            dDamageNuts_Monthly += oWIP_CC.Qty_Grade2;
                                            dAllowance_Monthly += oWIP_CC.Amount_Total;
                                        }
                                    }
                                    glb_dts_TAS_CC.dt_ShellRemoving_MonthlySummary.Adddt_ShellRemoving_MonthlySummaryRow(oEmp.Employee_ID, oEmp.EpfNo, clsRef_Name.get_EmployeeShortName_initialsFirst(oEmp.Employee_ID), dGoodNuts_Monthly, dDamageNuts_Monthly, 0, 0, 0, dAllowance_Monthly, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "Permanent De-Shellers");
                                }

                                frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                                frmViewer.print(oReport.ReportPath, glb_dts_TAS_CC, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                            }
                            catch (Exception ex)
                            {
                                SEACCExeption.Show(ex);
                            }
                        }
                        #endregion

                        #endregion

                        #region PAYROLL REPORTS

                        #region Net Salary - Electronic Format
                        else if (Report == enum_ReportName.NetSalary_ElectronicFormat)
                        {
                            if (txtComBankAccount.Tag != null)
                            {
                                string filename = "";
                                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                                dlg.DefaultExt = ".Dat";
                                dlg.Filter = "Text documents (.Dat)|*.Dat|All files (*.*)|*.*";
                                if (dlg.ShowDialog() == true)
                                {
                                    #region Fill Company Data
                                    string sCompany_Name = "";
                                    if (bDivisionSelected)
                                    {
                                        CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                        sCompany_Name = sctComDetails.sCompanyName;
                                    }
                                    else
                                    {
                                        sCompany_Name = clsSecurity.CompanyName;
                                    }

                                    string sComAccountNo = txtComBankAccount.Text.PadLeft(12, '0');//pad left numberic values
                                    string sComln_AccountNo = sComAccountNo.Substring(sComAccountNo.Length - 12);//add substring to get last 12 numeric values
                                    string sComln_BankCode = txtComBankAccount.Tag.ToString().PadLeft(4, '0');
                                    string sComln_BankBranchCode = txtComBankAccount.Uid.PadLeft(3, '0');
                                    string sComln_Name = string.Format("{0,20}", sCompany_Name).Substring(0, 20);
                                    string sComln_EPF = "000000000000000";
                                    string sComln_Amount = "";
                                    #endregion

                                    #region Global Variables
                                    string sTras_ID = "0";
                                    string sTRN_Code = "23";
                                    string sReturn_Code = "0";
                                    string sReturnDate = "0";
                                    string sCurrencyCode = "SLR";
                                    string sReference = ("SAL" + dtmFromDate.ToString("MMM") + dtmFromDate.ToString("yyyy")).PadRight(15);
                                    string sValueDate = dtmFromDate.ToString("yyMMdd");
                                    string sSecurityField = "";
                                    string sFiller = "@";
                                    #endregion

                                    filename = dlg.FileName;
                                    using (StreamWriter sw = new StreamWriter(filename, false))
                                    {
                                        #region Employee Details
                                        List<tbl_payTxSIPRawData> oRawDatarecords = tbl_payTxSIPRawData.SelectPeriod_ByDateRange(dtmFromDate.Date, dtmToDate.Date);

                                        #region Selected Filters
                                        if (bEmployeeSelected)
                                            oRawDatarecords = oRawDatarecords.Where(r => r.Employee_ID == txtEmployee.Tag.ToString()).ToList();
                                        if (bDivisionSelected)
                                            oRawDatarecords = oRawDatarecords.Where(r => vDivisions.Any(r2 => r2.Field<string>("id") == r.Division_ID)).ToList();
                                        if (bDepartmentSelected)
                                            oRawDatarecords = oRawDatarecords.Where(r => r.Department_ID == txtDepartment.Tag.ToString()).ToList();
                                        if (bSectionSelected)
                                            oRawDatarecords = oRawDatarecords.Where(r => r.SectionID == txtSection.Tag.ToString()).ToList();
                                        if (bSubSectionSelected)
                                            oRawDatarecords = oRawDatarecords.Where(r => r.SubSectionID == txtSubSection.Tag.ToString()).ToList();
                                        if (bDesignationSelected)
                                            oRawDatarecords = oRawDatarecords.Where(r => r.Designation_ID == txtDesignation.Tag.ToString()).ToList();
                                        if (bEmpCategory1Selected)
                                            oRawDatarecords = oRawDatarecords.Where(r => r.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();
                                        if (bEmpCategory2Selected)
                                            oRawDatarecords = oRawDatarecords.Where(r => r.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();
                                        if (bEmpCategory3Selected)
                                            oRawDatarecords = oRawDatarecords.Where(r => r.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();
                                        if (bPayPeriodSelected)
                                            oRawDatarecords = oRawDatarecords.Where(r => r.ProcessGroup_ID == txtPayPeriod.Uid && r.ProcessPeriod_ID == int.Parse(txtPayPeriod.ToolTip.ToString()) && r.ProcessPeriod_Sub_ID == int.Parse(txtPayPeriod.Tag.ToString())).ToList();
                                        if (bPaymentMethodSelected)
                                            oRawDatarecords = oRawDatarecords.Where(r => r.PaymentMethod_ID == txtPayementMethodBy.Tag.ToString()).ToList();
                                        #endregion

                                        decimal dAccum_NetSalary = 0;
                                        foreach (tbl_payTxSIPRawData oTxPayRawRecord in oRawDatarecords.OrderBy(o => o.EpfNo.PadLeft(4, '0')))//OrderBy(o => o.EpfNo.PadLeft(4, '0')
                                        {
                                            if (oTxPayRawRecord.Bank_AccNo.Length < 4)
                                                continue;

                                            decimal dNetSalary = decimal.Round(clsHelpMethods.GetNetSalary_FromTX(oTxPayRawRecord.Employee_ID, oTxPayRawRecord.ProcessPeriod_Sub_startDate.Date, oTxPayRawRecord.ProcessPeriod_Sub_endDate.Date), 2);
                                            dAccum_NetSalary += dNetSalary;

                                            string sEmpln_BankCode = oTxPayRawRecord.Bank_ID.PadLeft(4, '0');
                                            string sEmpln_BankBranchCode = clsRef_Name.get_BankBranch_Code(oTxPayRawRecord.BankBranch_ID).PadLeft(3, '0');

                                            string sEmpAccountNo = oTxPayRawRecord.Bank_AccNo.PadLeft(12, '0');//pad left numberic values
                                            string sEmpln_AccountNo = sEmpAccountNo.Substring(sEmpAccountNo.Length - 12);//add substring to get last 12 numeric values

                                            string sEmpln_AccountName = string.Format("{0,-20}", clsRef_Name.get_EmployeeShortName_initialsFirst(oTxPayRawRecord.Employee_ID)).Substring(0, 20);
                                            string sEmpln_NetSalary = String.Format("{0:000000000000}", (dNetSalary * 100));
                                            string sEmpln_EPF_No = oTxPayRawRecord.EpfNo.PadLeft(15);//particulars
                                                                                                     //string sEmpln_EmpName = ($"{  clsRef_Name.get_EmployeeShortName_initialsFirst(oTxPayRawRecord.Employee_ID),-20}").Substring(0, 20);

                                            sw.WriteLine(sTras_ID.PadRight(4, '0') +
                                                    sEmpln_BankCode +
                                                    sEmpln_BankBranchCode +
                                                    sEmpln_AccountNo +
                                                    sEmpln_AccountName +
                                                    sTRN_Code +
                                                    sReturn_Code.PadRight(2, '0') +
                                                    "0" +
                                                    sReturnDate.PadRight(6, '0') +
                                                    sEmpln_NetSalary +
                                                    sCurrencyCode +
                                                    sComln_BankCode +
                                                    sComln_BankBranchCode +
                                                    sComln_AccountNo +
                                                    sComln_Name +
                                                    sEmpln_EPF_No +
                                                    sReference +
                                                    sValueDate +
                                                    sSecurityField.PadRight(6) +
                                                    sFiller);
                                        }

                                        #endregion

                                        #region Company Details
                                        sComln_Amount = String.Format("{0:000000000000}", (dAccum_NetSalary * 100));

                                        sw.WriteLine(sTras_ID.PadRight(4, '0') +
                                                        sComln_BankCode +
                                                        sComln_BankBranchCode +
                                                        sComln_AccountNo +
                                                        sComln_Name +
                                                        sTRN_Code +
                                                        sReturn_Code.PadRight(2, '0') +
                                                        "1" +
                                                        sReturnDate.PadRight(6, '0') +
                                                        sComln_Amount +
                                                        sCurrencyCode +
                                                        sComln_BankCode +
                                                        sComln_BankBranchCode +
                                                        sComln_AccountNo +
                                                        sComln_Name +
                                                        sComln_EPF +
                                                        sReference +
                                                        sValueDate +
                                                        sSecurityField.PadRight(6) +
                                                        sFiller);
                                        #endregion

                                        sw.Close();

                                        SEACCMessageBox.Show("Successfully Created", "File is successfully created", MessageBoxButton.OK);
                                    }
                                }
                                Process.Start(filename);
                            }
                            else
                            {
                                SEACCMessageBox.Show("Company Bank Account can not be empty", "Please select valid company bank account", MessageBoxButton.OK, "Red");
                            }
                        }
                        #endregion

                        #region Net Salary - Excel Sheet Electronic Format
                        else if (Report == enum_ReportName.NetSalary_ExcelFormat)
                        {
                            try
                            {
                                if (txtComBankAccount.Tag != null)
                                {
                                    #region Data Table Initialize
                                    DataTable dt = new DataTable();
                                    dt.Columns.Add("TranID");
                                    dt.Columns.Add("BankCode");
                                    dt.Columns.Add("BankBranchCode");
                                    dt.Columns.Add("BankAccount");
                                    dt.Columns.Add("BankAccountName");
                                    dt.Columns.Add("TRNCode");
                                    dt.Columns.Add("ReturnCode");
                                    dt.Columns.Add("CrDrCode");
                                    dt.Columns.Add("ReturnDate");
                                    dt.Columns.Add("Amount");
                                    dt.Columns.Add("CurrencyCode");
                                    dt.Columns.Add("OriginationBank");
                                    dt.Columns.Add("OriginationBankBranch");
                                    dt.Columns.Add("OriginationBankAccount");
                                    dt.Columns.Add("OriginationBankAccountName");
                                    dt.Columns.Add("Purticulars");
                                    dt.Columns.Add("Reference");
                                    dt.Columns.Add("ValueDate");
                                    dt.Columns.Add("SecurityField");
                                    dt.Columns.Add("Filler");
                                    #endregion

                                    Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                                    ExcelApp.Application.Workbooks.Add(Type.Missing);

                                    #region Fill Company Data
                                    string sCompany_Name = "";
                                    if (bDivisionSelected)
                                    {
                                        CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                        sCompany_Name = sctComDetails.sCompanyName;
                                    }
                                    else
                                    {
                                        sCompany_Name = clsSecurity.CompanyName;
                                    }

                                    string sComAccountNo = txtComBankAccount.Text.PadLeft(12, '0');//pad left numberic values
                                    string sComln_AccountNo = sComAccountNo.Substring(sComAccountNo.Length - 12);//add substring to get last 12 numeric values
                                    string sComln_BankCode = txtComBankAccount.Tag.ToString().PadLeft(4, '0');
                                    string sComln_BankBranchCode = txtComBankAccount.Uid.PadLeft(3, '0');
                                    string sComln_Name = string.Format("{0,-20}", sCompany_Name).Substring(0, 20);
                                    string sComln_EPF = "000000000000000";
                                    string sComln_Amount = "";
                                    #endregion

                                    #region Global Variables
                                    string sTras_ID = "0";
                                    string sTRN_Code = "23";
                                    string sReturn_Code = "0";
                                    string sReturnDate = "0";
                                    string sCurrencyCode = "SLR";
                                    string sReference = ("SALARY " + dtmFromDate.ToString("MMMM")).PadRight(15);
                                    string sValueDate = dtmFromDate.ToString("yyMMdd");
                                    string sSecurityField = "";
                                    string sFiller = "@";
                                    #endregion

                                    #region Fill Data Table

                                    List<tbl_payTxSIPRawData> oRawDatarecords = tbl_payTxSIPRawData.SelectPeriod_ByDateRange(dtmFromDate.Date, dtmToDate.Date);
                                    decimal dAccum_NetSalary = 0;

                                    #region Selected Filters
                                    if (bEmployeeSelected)
                                        oRawDatarecords = oRawDatarecords.Where(r => r.Employee_ID == txtEmployee.Tag.ToString()).ToList();
                                    if (bDivisionSelected)
                                        oRawDatarecords = oRawDatarecords.Where(r => vDivisions.Any(r2 => r2.Field<string>("id") == r.Division_ID)).ToList();
                                    if (bDepartmentSelected)
                                        oRawDatarecords = oRawDatarecords.Where(r => r.Department_ID == txtDepartment.Tag.ToString()).ToList();
                                    if (bSectionSelected)
                                        oRawDatarecords = oRawDatarecords.Where(r => r.SectionID == txtSection.Tag.ToString()).ToList();
                                    if (bSubSectionSelected)
                                        oRawDatarecords = oRawDatarecords.Where(r => r.SubSectionID == txtSubSection.Tag.ToString()).ToList();
                                    if (bDesignationSelected)
                                        oRawDatarecords = oRawDatarecords.Where(r => r.Designation_ID == txtDesignation.Tag.ToString()).ToList();
                                    if (bEmpCategory1Selected)
                                        oRawDatarecords = oRawDatarecords.Where(r => r.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();
                                    if (bEmpCategory2Selected)
                                        oRawDatarecords = oRawDatarecords.Where(r => r.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();
                                    if (bEmpCategory3Selected)
                                        oRawDatarecords = oRawDatarecords.Where(r => r.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();
                                    if (bPayPeriodSelected)
                                        oRawDatarecords = oRawDatarecords.Where(r => r.ProcessGroup_ID == txtPayPeriod.Uid && r.ProcessPeriod_ID == int.Parse(txtPayPeriod.ToolTip.ToString()) && r.ProcessPeriod_Sub_ID == int.Parse(txtPayPeriod.Tag.ToString())).ToList();
                                    if (bPaymentMethodSelected)
                                        oRawDatarecords = oRawDatarecords.Where(r => r.PaymentMethod_ID == txtPayementMethodBy.Tag.ToString()).ToList();
                                    #endregion

                                    foreach (tbl_payTxSIPRawData oTxPayRawRecord in oRawDatarecords.OrderBy(o => o.EpfNo.PadLeft(4, '0')))
                                    {
                                        if (oTxPayRawRecord != null && oTxPayRawRecord.Bank_AccNo.Length > 3)
                                        {
                                            tbl_genMasEmployee oEmp = tbl_genMasEmployee.Select(oTxPayRawRecord.Employee_ID, clsSecurity.CompanyID, clsSecurity.BranchID);
                                            if (oEmp != null)
                                            {
                                                decimal dNetSalary = decimal.Round(clsHelpMethods.GetNetSalary_FromTX(oTxPayRawRecord.Employee_ID, oTxPayRawRecord.ProcessPeriod_Sub_startDate.Date, oTxPayRawRecord.ProcessPeriod_Sub_endDate.Date), 2);
                                                dAccum_NetSalary += dNetSalary;

                                                string sEmpln_BankCode = oTxPayRawRecord.Bank_ID.PadLeft(4, '0');
                                                string sEmpln_BankBranchCode = clsRef_Name.get_BankBranch_Code(oTxPayRawRecord.BankBranch_ID).PadLeft(3, '0');

                                                string sEmpAccountNo = oTxPayRawRecord.Bank_AccNo.PadLeft(12, '0');//pad left numberic values
                                                string sEmpln_AccountNo = sEmpAccountNo.Substring(sEmpAccountNo.Length - 12);//add substring to get last 12 numeric values

                                                string sEmpln_AccountName = string.Format("{0,-20}", clsRef_Name.get_EmployeeShortName_initialsFirst(oTxPayRawRecord.Employee_ID)).Substring(0, 20);
                                                string sEmpln_NetSalary = String.Format("{0:000000000000}", (dNetSalary * 100));
                                                string sEmpln_EPF_No = oTxPayRawRecord.EpfNo.PadLeft(15);//particulars



                                                dt.Rows.Add(sTras_ID.PadRight(4, '0'),
                                                    sEmpln_BankCode,
                                                    sEmpln_BankBranchCode,
                                                    sEmpln_AccountNo,
                                                    sEmpln_AccountName,
                                                    sTRN_Code,
                                                    sReturn_Code.PadRight(2, '0'),
                                                    "0",
                                                    sReturnDate.PadRight(6, '0'),
                                                    sEmpln_NetSalary,
                                                    sCurrencyCode,
                                                    sComln_BankCode,
                                                    sComln_BankBranchCode,
                                                    sComln_AccountNo,
                                                    sComln_Name,
                                                    sEmpln_EPF_No,
                                                    sReference,
                                                    sValueDate,
                                                    sSecurityField.PadRight(15),
                                                    sFiller);
                                            }
                                        }
                                    }

                                    sComln_Amount = String.Format("{0:000000000000}", (dAccum_NetSalary * 100));

                                    dt.Rows.Add(sTras_ID.PadRight(4, '0'),
                                                    sComln_BankCode,
                                                    sComln_BankBranchCode,
                                                    sComln_AccountNo,
                                                    sComln_Name,
                                                    sTRN_Code,
                                                    sReturn_Code.PadRight(2, '0'),
                                                    "1",
                                                    sReturnDate.PadRight(6, '0'),
                                                    sComln_Amount,
                                                    sCurrencyCode,
                                                    sComln_BankCode,
                                                    sComln_BankBranchCode,
                                                    sComln_AccountNo,
                                                    sComln_Name,
                                                    sComln_EPF,
                                                    sReference,
                                                    sValueDate,
                                                    sSecurityField.PadRight(15),
                                                    sFiller);
                                    #endregion

                                    #region Set Header and Column Width
                                    ExcelApp.Cells[1, 1] = "Net Salary Electronic Format";
                                    ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 5]].Merge();

                                    //format orientation n alignments
                                    ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 20]].NumberFormat = "@";//set column range as text format
                                                                                                                   //ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 20]].Orientation = "90";
                                                                                                                   //ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 20]].Style.VerticalAlignment = VerticalAlignment.Center;
                                                                                                                   //ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 20]].Style.HorizontalAlignment = HorizontalAlignment.Center;
                                                                                                                   //ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 20]].RowHeight = "110";

                                    //format font style
                                    ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 20]].Style.Font.Bold = true;
                                    ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 20]].Style.Font.Name = "Calibri";
                                    ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 20]].Style.Font.Size = 9F;

                                    //format borders
                                    ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 20]].Borders.Color = System.Drawing.Color.Black;
                                    ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 20]].Interior.Color = System.Drawing.Color.LightGray;

                                    #region Column Headers
                                    ExcelApp.Cells[3, 1] = "Tran ID";
                                    ExcelApp.Cells[3, 2] = "Destination Bank";
                                    ExcelApp.Cells[3, 3] = "Destionation Bank Branch";
                                    ExcelApp.Cells[3, 4] = "Destionation Account";
                                    ExcelApp.Cells[3, 5] = "Destionation Account Name";
                                    ExcelApp.Cells[3, 6] = "TRN Code";
                                    ExcelApp.Cells[3, 7] = "Return Code";
                                    ExcelApp.Cells[3, 8] = "Cr/Dr Code";
                                    ExcelApp.Cells[3, 9] = "Return Date";
                                    ExcelApp.Cells[3, 10] = "Amount";
                                    ExcelApp.Cells[3, 11] = "Currency Code";
                                    ExcelApp.Cells[3, 12] = "Originating Bank";
                                    ExcelApp.Cells[3, 13] = "Originating Bank Branch";
                                    ExcelApp.Cells[3, 14] = "Originating Account";
                                    ExcelApp.Cells[3, 15] = "Originating Account Name";
                                    ExcelApp.Cells[3, 16] = "Purticulars";
                                    ExcelApp.Cells[3, 17] = "Reference";
                                    ExcelApp.Cells[3, 18] = "Value Date(YYMMDD)";
                                    ExcelApp.Cells[3, 19] = "Security Field";
                                    ExcelApp.Cells[3, 20] = "Filler";
                                    #endregion
                                    #endregion

                                    #region Fill Cells
                                    int c = 4;
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        ExcelApp.Range[ExcelApp.Cells[c, 1], ExcelApp.Cells[c, 20]].Style.Font.Name = "Calibri";
                                        ExcelApp.Range[ExcelApp.Cells[c, 1], ExcelApp.Cells[c, 20]].Style.Font.Size = 11F;
                                        ExcelApp.Range[ExcelApp.Cells[c, 1], ExcelApp.Cells[c, 20]].Style.Font.Bold = false;

                                        ExcelApp.Cells[c, 1] = row[0];
                                        ExcelApp.Cells[c, 2] = row[1];
                                        ExcelApp.Cells[c, 3] = row[2];
                                        ExcelApp.Cells[c, 4] = row[3];
                                        ExcelApp.Cells[c, 5] = row[4];
                                        ExcelApp.Cells[c, 6] = row[5];
                                        ExcelApp.Cells[c, 7] = row[6];
                                        ExcelApp.Cells[c, 8] = row[7];
                                        ExcelApp.Cells[c, 9] = row[8];
                                        ExcelApp.Cells[c, 10] = row[9];
                                        ExcelApp.Cells[c, 11] = row[10];
                                        ExcelApp.Cells[c, 12] = row[11];
                                        ExcelApp.Cells[c, 13] = row[12];
                                        ExcelApp.Cells[c, 14] = row[13];
                                        ExcelApp.Cells[c, 15] = row[14];
                                        ExcelApp.Cells[c, 16] = row[15];
                                        ExcelApp.Cells[c, 17] = row[16];
                                        ExcelApp.Cells[c, 18] = row[17];
                                        ExcelApp.Cells[c, 19] = row[18];
                                        ExcelApp.Cells[c, 20] = row[19];

                                        c++;
                                    }

                                    #endregion

                                    //ExcelApp.Columns.WrapText = true;
                                    ExcelApp.Columns.AutoFit();
                                    Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                                    dlg.DefaultExt = ".xls";
                                    dlg.Filter = "Excel documents (.xls)|*.xlsx";
                                    if (dlg.ShowDialog() == true)
                                    {
                                        string filename = dlg.FileName;
                                        ExcelApp.ActiveWorkbook.SaveAs(filename);

                                        SEACCMessageBox.Show("Successfully created", "Excel file is successfully created", MessageBoxButton.OK);
                                        ExcelApp.ActiveWorkbook.Saved = true;
                                        ExcelApp.Visible = true;

                                        Marshal.FinalReleaseComObject(ExcelApp);
                                    }
                                }

                                else
                                {
                                    SEACCMessageBox.Show("Company Bank Account can not be empty", "Please select valid company bank account", MessageBoxButton.OK, "Red");
                                }
                            }
                            catch (Exception ex)
                            {
                                SEACCExeption.Show(ex);
                            }
                        }
                        #endregion


                        #region Unprocessed Payslip Item Amount - Electronic Format
                        else if (Report == enum_ReportName.Unprocessed_PayslipItem_ElectronicFormat)
                        {
                            if (txtComBankAccount.Tag != null && txtPayslipItem.Tag != null)
                            {
                                string filename = "";
                                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                                dlg.DefaultExt = ".Dat";
                                dlg.Filter = "Text documents (.Dat)|*.Dat|All files (*.*)|*.*";
                                if (dlg.ShowDialog() == true)
                                {
                                    #region Fill Company Data
                                    string sCompany_Name = "";
                                    if (bDivisionSelected)
                                    {
                                        CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                        sCompany_Name = sctComDetails.sCompanyName;
                                    }
                                    else
                                    {
                                        sCompany_Name = clsSecurity.CompanyName;
                                    }

                                    string sComAccountNo = txtComBankAccount.Text.PadLeft(12, '0');//pad left numberic values
                                    string sComln_AccountNo = sComAccountNo.Substring(sComAccountNo.Length - 12);//add substring to get last 12 numeric values
                                    string sComln_BankCode = txtComBankAccount.Tag.ToString().PadLeft(4, '0');
                                    string sComln_BankBranchCode = txtComBankAccount.Uid.PadLeft(3, '0');
                                    string sComln_Name = string.Format("{0,20}", sCompany_Name).Substring(0, 20);
                                    string sComln_EPF = "000000000000000";
                                    string sComln_Amount = "";
                                    #endregion

                                    #region Global Variables
                                    string sTras_ID = "0";
                                    string sTRN_Code = "23";
                                    string sReturn_Code = "0";
                                    string sReturnDate = "0";
                                    string sCurrencyCode = "SLR";
                                    string sReference = ("SAL" + dtmFromDate.ToString("MMM") + dtmFromDate.ToString("yyyy")).PadRight(15);
                                    string sValueDate = dtmFromDate.ToString("yyMMdd");
                                    string sSecurityField = "";
                                    string sFiller = "@";
                                    #endregion

                                    filename = dlg.FileName;
                                    using (StreamWriter sw = new StreamWriter(filename, false))
                                    {
                                        #region Filters
                                        #region Employee Filter
                                        List<sp_genMasEmployee> oEmployees;
                                        if (bEmployeeSelected)
                                        {
                                            oEmployees = new List<sp_genMasEmployee>();
                                            oEmployees.Add(sp_genMasEmployee.Select(txtEmployee.Tag.ToString()));
                                        }
                                        else
                                            oEmployees = sp_genMasEmployee.SelectAll().Where(p => p.Employee_ID != "default" && p.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString()).ToList();
                                        #endregion

                                        if (bDesignationSelected)
                                            oEmployees = oEmployees.Where(p => p.Designation_ID == txtDesignation.Tag.ToString()).ToList();

                                        if (bDivisionSelected)
                                            oEmployees = oEmployees.Where(p => p.Division_ID == txtDivision.Tag.ToString()).ToList();

                                        if (bDepartmentSelected)
                                            oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();

                                        if (bSectionSelected)
                                            oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();

                                        if (bSubSectionSelected)
                                            oEmployees = oEmployees.Where(p => p.SubSectionID == txtSubSection.Tag.ToString()).ToList();

                                        if (bEmpCategory1Selected)
                                            oEmployees = oEmployees.Where(p => p.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();

                                        if (bEmpCategory2Selected)
                                            oEmployees = oEmployees.Where(p => p.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();

                                        if (bEmpCategory3Selected)
                                            oEmployees = oEmployees.Where(p => p.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();

                                        if (bPaymentMethodSelected)
                                            oEmployees = oEmployees.Where(r => r.PaymentMethod_ID == txtPayementMethodBy.Tag.ToString()).ToList();
                                        #endregion

                                        #region Fill Details
                                        decimal dAccum_Amount = 0;
                                        foreach (sp_genMasEmployee oEmp in oEmployees.OrderBy(o => o.EpfNo.PadLeft(4, '0')))
                                        {
                                            if (oEmp.Employee_AccountNo.Length < 4 || oEmp.BankBranch_ID == "Default" ||  oEmp.Bank_ID == "Default")
                                                continue;

                                            tbl_genMasEmployee_PaySlipItems oEmp_PayslipItem = tbl_genMasEmployee_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oEmp.Employee_ID, txtPayslipItem.Tag.ToString());
                                            if (oEmp_PayslipItem != null && oEmp_PayslipItem.Rate != 0)
                                            {
                                                decimal dPaslipItem_Amount = Math.Abs(decimal.Round(oEmp_PayslipItem.Rate, 2));
                                                dAccum_Amount += dPaslipItem_Amount;

                                                string sEmpln_BankCode = oEmp.Bank_ID.PadLeft(4, '0');
                                                string sEmpln_BankBranchCode = clsRef_Name.get_BankBranch_Code(oEmp.BankBranch_ID).PadLeft(3, '0');

                                                string sEmpAccountNo = oEmp.Employee_AccountNo.PadLeft(12, '0');//pad left numberic values
                                                string sEmpln_AccountNo = sEmpAccountNo.Substring(sEmpAccountNo.Length - 12);//add substring to get last 12 numeric values

                                                string sEmpln_AccountName = string.Format("{0,-20}", clsRef_Name.get_EmployeeShortName_initialsFirst(oEmp.Employee_ID)).Substring(0, 20);
                                                string sEmpln_NetSalary = String.Format("{0:000000000000}", (dAccum_Amount * 100));
                                                string sEmpln_EPF_No = oEmp.EpfNo.PadLeft(15);//particulars

                                                sw.WriteLine(sTras_ID.PadRight(4, '0') +
                                                        sEmpln_BankCode +
                                                        sEmpln_BankBranchCode +
                                                        sEmpln_AccountNo +
                                                        sEmpln_AccountName +
                                                        sTRN_Code +
                                                        sReturn_Code.PadRight(2, '0') +
                                                        "0" +
                                                        sReturnDate.PadRight(6, '0') +
                                                        sEmpln_NetSalary +
                                                        sCurrencyCode +
                                                        sComln_BankCode +
                                                        sComln_BankBranchCode +
                                                        sComln_AccountNo +
                                                        sComln_Name +
                                                        sEmpln_EPF_No +
                                                        sReference +
                                                        sValueDate +
                                                        sSecurityField.PadRight(6) +
                                                        sFiller);
                                            }
                                        }
                                        #endregion

                                        #region Company Details
                                        sComln_Amount = String.Format("{0:000000000000}", (dAccum_Amount * 100));

                                        sw.WriteLine(sTras_ID.PadRight(4, '0') +
                                                        sComln_BankCode +
                                                        sComln_BankBranchCode +
                                                        sComln_AccountNo +
                                                        sComln_Name +
                                                        sTRN_Code +
                                                        sReturn_Code.PadRight(2, '0') +
                                                        "1" +
                                                        sReturnDate.PadRight(6, '0') +
                                                        sComln_Amount +
                                                        sCurrencyCode +
                                                        sComln_BankCode +
                                                        sComln_BankBranchCode +
                                                        sComln_AccountNo +
                                                        sComln_Name +
                                                        sComln_EPF +
                                                        sReference +
                                                        sValueDate +
                                                        sSecurityField.PadRight(6) +
                                                        sFiller);
                                        #endregion

                                        sw.Close();
                                        SEACCMessageBox.Show("Successfully Created", "File is successfully created", MessageBoxButton.OK);
                                    }
                                    Process.Start(filename);
                                }
                            }
                            else
                            {
                                if (txtComBankAccount.Tag == null)
                                    SEACCMessageBox.Show("Company Bank Account can not be empty", "Please select valid company bank account", MessageBoxButton.OK, "Red");
                                else if (txtPayslipItem.Tag == null)
                                    SEACCMessageBox.Show("Payslip Item can not be empty", "Please select valid payslip", MessageBoxButton.OK, "Red");
                            }
                        }
                        #endregion

                        #region UnProcessed Payslip Item Amount - Signature Sheet
                        else if (Report == enum_ReportName.UnprocessedPayslipItems_SignatureSheet)
                        {
                            DataSets.dts_PAY glb_dts_PAY = new DataSets.dts_PAY();

                            #region Selected Filters
                            List<tbl_genMasEmployee> oEmpList = tbl_genMasEmployee.SelectAll().Where(r => r.Employee_ID != "default" && r.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString()).ToList();
                            if (bEmployeeSelected)
                                oEmpList = oEmpList.Where(r => r.Employee_ID == txtEmployee.Tag.ToString()).ToList();
                            if (bDivisionSelected)
                                oEmpList = oEmpList.Where(r => vDivisions.Any(r2 => r2.Field<string>("id") == r.Division_ID)).ToList();
                            if (bDepartmentSelected)
                                oEmpList = oEmpList.Where(r => r.Department_ID == txtDepartment.Tag.ToString()).ToList();
                            if (bSectionSelected)
                                oEmpList = oEmpList.Where(r => r.SectionID == txtSection.Tag.ToString()).ToList();
                            if (bSubSectionSelected)
                                oEmpList = oEmpList.Where(r => r.SubSectionID == txtSubSection.Tag.ToString()).ToList();
                            if (bDesignationSelected)
                                oEmpList = oEmpList.Where(r => r.Designation_ID == txtDesignation.Tag.ToString()).ToList();
                            if (bEmpCategory1Selected)
                                oEmpList = oEmpList.Where(r => r.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();
                            if (bEmpCategory2Selected)
                                oEmpList = oEmpList.Where(r => r.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();
                            if (bEmpCategory3Selected)
                                oEmpList = oEmpList.Where(r => r.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();
                            if (bPaymentMethodSelected)
                                oEmpList = oEmpList.Where(r => r.PaymentMethod_ID == txtPayementMethodBy.Tag.ToString()).ToList();
                            #endregion

                            if (bPayslipItemSelected)
                            {
                                #region Company Data Set Fill
                                if (bDivisionSelected)
                                {
                                    CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                    glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, sctComDetails.sEPF_RegNo, sctComDetails.sETF_RegNo, sctComDetails.sPayee_RegNo, sctComDetails.sTax_IdentityNo, oReport.DisplayName, oReport.DisplayName2, dtmFromDate.ToString("Y"), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                }
                                else
                                {
                                    tbl_genCompanyInfo oCompany = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
                                    glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oCompany.Epf_RegNo, oCompany.Etf_RegNo, oCompany.Payee_RegNo, oCompany.Tax_IdentityNo, oReport.DisplayName, oReport.DisplayName2, dtmFromDate.ToString("Y"), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                }
                                #endregion

                                foreach (tbl_genMasEmployee oEmp in oEmpList.OrderBy(o => o.EpfNo.PadLeft(4, '0')))
                                {
                                    tbl_securityParollGroup_UserPermission oGrpPermission = tbl_securityParollGroup_UserPermission.Select(clsSecurity.CompanyID, clsSecurity.BranchID, clsSecurity.UserIDLoged, oEmp.Payroll_ProcessGroupID);
                                    if (oGrpPermission != null && oGrpPermission.AllowEdit)
                                    {
                                        tbl_genMasEmployee_PaySlipItems oMasItem = tbl_genMasEmployee_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oEmp.Employee_ID, txtPayslipItem.Tag.ToString());
                                        if (oMasItem != null && oMasItem.Rate != 0)
                                        {
                                            tbl_payMas_PaySlipItems oItems = tbl_payMas_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oMasItem.PayItem_ID);
                                            if (oItems != null)
                                            {
                                                glb_dts_PAY.dt_MasPayslipItem.Adddt_MasPayslipItemRow(oMasItem.Employee_ID, oEmp.NicNo, clsRef_Name.get_EmployeeShortName(oMasItem.Employee_ID), clsRef_Name.get_EmployeeAliasName(oMasItem.Employee_ID), oEmp.IsEPF_ETF_Process, oEmp.EpfNo,
                                                    oEmp.Division_ID, clsRef_Name.get_Division_Name(oEmp.Division_ID),
                                                    oEmp.Department_ID, clsRef_Name.get_Department_Name(oEmp.Department_ID),
                                                    oEmp.SectionID, clsRef_Name.get_Section_Name(oEmp.SectionID), oMasItem.PayItem_ID, oItems.PayItem_Title, oEmp.PaymentMethod_ID, clsRef_Name.get_PayemntMethode_Name(oEmp.PaymentMethod_ID), oMasItem.Rate);
                                            }
                                        }
                                    }
                                }

                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("PayslipItemID", txtPayslipItem.Tag.ToString(), true);
                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("PayslipItemName", clsRef_Name.get_PaySlipItem_Title(txtPayslipItem.Tag.ToString()), true);//PayslipItemName

                                frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                                frmViewer.print(oReport.ReportPath, glb_dts_PAY, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                            }
                            else
                                SEACCMessageBox.Show("Payslip Item can not be empty", "Please select valid payslip", MessageBoxButton.OK, "Red");

                        }
                        #endregion

                        #region EPF - Excel Sheet Electronic Format
                        else if (Report == enum_ReportName.EPF_ElectronicFormat)
                        {

                            try
                            {
                                #region Data Table Initialize
                                DataTable dt = new DataTable();
                                dt.Columns.Add("NIC");
                                dt.Columns.Add("LastName");
                                dt.Columns.Add("Initials");
                                dt.Columns.Add("Account_No");
                                dt.Columns.Add("Tot_Contribution");
                                dt.Columns.Add("Employers_Contribution");
                                dt.Columns.Add("Members_Contribution");
                                dt.Columns.Add("Tot_Earnings");
                                dt.Columns.Add("Member_Status");
                                dt.Columns.Add("Zone_Code");
                                dt.Columns.Add("Employer_No");
                                dt.Columns.Add("Contribution_YearMonth");
                                dt.Columns.Add("Data_Submission_No");
                                dt.Columns.Add("NoofDays_Worked");
                                dt.Columns.Add("Occupation_Classification_Grade");
                                #endregion

                                #region Fill Data Table
                                List<tbl_payTxSIPRawData> oRawDatarecords = tbl_payTxSIPRawData.SelectPeriod_ByDateRange(dtmFromDate.Date, dtmToDate.Date);
                                foreach (tbl_payTxSIPRawData oTxPayRawRecord in oRawDatarecords.Where(p => p.IsEPF_ETF_Process && p.IsPayslip_Print).OrderBy(o => o.EpfNo))
                                {
                                    #region Filters
                                    if (bEmployeeSelected)
                                        if (txtEmployee.Tag.ToString() != oTxPayRawRecord.Employee_ID)
                                            continue;
                                    if (bDivisionSelected && !msbDivision.IsSelectAll())
                                        if (vDivisions.Exists(r => r.Field<string>("id").Trim() != oTxPayRawRecord.Division_ID.Trim()))
                                            continue;
                                    if (bDepartmentSelected)
                                        if (txtDepartment.Tag.ToString() != oTxPayRawRecord.Department_ID)
                                            continue;
                                    if (bSectionSelected)
                                        if (txtSection.Tag.ToString() != oTxPayRawRecord.SectionID)
                                            continue;
                                    if (bSubSectionSelected)
                                        if (txtSubSection.Tag.ToString() != oTxPayRawRecord.SubSectionID)
                                            continue;
                                    if (bDesignationSelected)
                                        if (txtDesignation.Tag.ToString() != oTxPayRawRecord.Designation_ID)
                                            continue;
                                    if (bEmpCategory1Selected)
                                        if (txtEmpCategory1.Tag.ToString() != oTxPayRawRecord.EmpCatagory1_ID)
                                            continue;
                                    if (bEmpCategory2Selected)
                                        if (txtEmpCategory2.Tag.ToString() != oTxPayRawRecord.EmpCatagory2_ID)
                                            continue;
                                    if (bEmpCategory3Selected)
                                        if (txtEmpCategory3.Tag.ToString() != oTxPayRawRecord.EmpCatagory3_ID)
                                            continue;
                                    if (bPaymentMethodSelected)
                                        if (txtPayementMethodBy.Tag.ToString() != oTxPayRawRecord.PaymentMethod_ID)
                                            continue;
                                    #endregion

                                    decimal dTot_Earn = clsHelpMethods.GetBaseSalaryForStatutory_FromTX(clsConfig.sEPF_Company, oTxPayRawRecord.SIP_ID);
                                    decimal dEPF_Pct_8 = clsHelpMethods.GetStatutaryItemAmount_FromTx(oTxPayRawRecord.SIP_ID, clsConfig.sEPF_Employee);//member (employee 8%)
                                    decimal dEPF_Pct_12 = clsHelpMethods.GetStatutaryItemAmount_FromTx(oTxPayRawRecord.SIP_ID, clsConfig.sEPF_Company); //employer 12%
                                    decimal dEPF_Pct_20 = dEPF_Pct_12 + dEPF_Pct_8; // member(employee) and employer total  20%

                                    #region Calculate No of Working Days
                                    decimal dTotalWorkingDays = 0;
                                    decimal dTotalNopayHrs = 0;
                                    decimal dTotalLeaveHrs = 0;
                                    foreach (tbl_tasTxDailyAttendance oAttendanceRecord in tbl_tasTxDailyAttendance.SelectAllBy_EmployeeIDWithDateRange(oTxPayRawRecord.Employee_ID, dtmFromDate.Date, dtmToDate.Date))
                                    {
                                        dTotalNopayHrs += (oAttendanceRecord.NoPayMinutesApproved / 60);
                                        dTotalLeaveHrs += (oAttendanceRecord.LeaveMinutes / 60);
                                    }

                                    tbl_payMas_ProcessGroup oProcessGroup = tbl_payMas_ProcessGroup.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oTxPayRawRecord.ProcessGroup_ID);
                                    dTotalWorkingDays = decimal.Round(((oProcessGroup.DivRate_Nopay / 60) - dTotalNopayHrs - dTotalLeaveHrs) / 8, 2);
                                    dTotalWorkingDays = dTotalWorkingDays < 0 ? 0 : dTotalWorkingDays;
                                    #endregion

                                    tbl_genMasEmployee oEmp = tbl_genMasEmployee.Select(oTxPayRawRecord.Employee_ID, clsSecurity.CompanyID, clsSecurity.BranchID);
                                    if (oEmp != null)
                                    {
                                        dt.Rows.Add(oTxPayRawRecord.NicNo, oEmp.SurName, oEmp.Initails, oEmp.EpfNo, cls_Formater.FormatDecimal(dEPF_Pct_20, 2), cls_Formater.FormatDecimal(dEPF_Pct_12, 2), cls_Formater.FormatDecimal(dEPF_Pct_8, 2), cls_Formater.FormatDecimal(dTot_Earn, 2),
                                            oEmp.Emp_statusID, "zone code", clsSecurity.CompanyEPFNo, dtp_FromDate.GetDateTime().ToString("yyyyMM"), "1", dTotalWorkingDays, "51");
                                    }

                                }
                                #endregion

                                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                                ExcelApp.Application.Workbooks.Add(Type.Missing);

                                #region Set Header and Column Width
                                ExcelApp.Cells[1, 1] = "EPF Electronic Format";
                                ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 5]].Merge();

                                ExcelApp.Cells[3, 1] = "NIC / Passport No";
                                ExcelApp.Cells[3, 2] = "Sure Name";
                                ExcelApp.Cells[3, 3] = "Initials";
                                ExcelApp.Cells[3, 4] = "Account No";
                                ExcelApp.Cells[3, 5] = "Total Contribution";
                                ExcelApp.Cells[3, 6] = "Employer's Contribution";
                                ExcelApp.Cells[3, 7] = "Member's Contribution";
                                ExcelApp.Cells[3, 8] = "Total Earnings";
                                ExcelApp.Cells[3, 9] = "Member Status";
                                ExcelApp.Cells[3, 10] = "Zone Code";
                                ExcelApp.Cells[3, 11] = "Employer's No";
                                ExcelApp.Cells[3, 12] = "Contribution Year and Month";
                                ExcelApp.Cells[3, 13] = "Data Submission No";
                                ExcelApp.Cells[3, 14] = "No of Days Worked";
                                ExcelApp.Cells[3, 15] = "Occupation Classification Grade";

                                ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 15]].Borders.Color = System.Drawing.Color.Black;
                                ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 15]].Interior.Color = System.Drawing.Color.LightGray;
                                ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 15]].ColumnWidth = 15;
                                #endregion

                                #region Fill Cells
                                int k = 4;
                                foreach (DataRow row in dt.Rows)
                                {
                                    ExcelApp.Cells[k, 1] = row[0];
                                    ExcelApp.Cells[k, 2] = row[1];
                                    ExcelApp.Cells[k, 3] = row[2];
                                    ExcelApp.Cells[k, 4] = row[3];
                                    ExcelApp.Cells[k, 5] = row[4];
                                    ExcelApp.Cells[k, 6] = row[5];
                                    ExcelApp.Cells[k, 7] = row[6];
                                    ExcelApp.Cells[k, 8] = row[7];
                                    ExcelApp.Cells[k, 9] = row[8];
                                    ExcelApp.Cells[k, 10] = row[9];
                                    ExcelApp.Cells[k, 11] = row[10];
                                    ExcelApp.Cells[k, 12] = row[11];
                                    ExcelApp.Cells[k, 13] = row[12];
                                    ExcelApp.Cells[k, 14] = row[13];
                                    ExcelApp.Cells[k, 15] = row[14];
                                    //ExcelApp.Range[ExcelApp.Cells[k, 1], ExcelApp.Cells[k, 15]].Borders.Color = System.Drawing.Color.Black;

                                    k++;
                                }

                                #endregion

                                ExcelApp.Columns.WrapText = true;
                                ExcelApp.Columns.AutoFit();

                                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                                dlg.DefaultExt = ".xls";
                                dlg.Filter = "Excel documents (.xls)|*.xlsx";
                                if (dlg.ShowDialog() == true)
                                {
                                    string filename = dlg.FileName;
                                    ExcelApp.ActiveWorkbook.SaveAs(filename);
                                    SEACCMessageBox.Show("Successfully created", "Excel file is successfully created", MessageBoxButton.OK);
                                    ExcelApp.ActiveWorkbook.Saved = true;
                                    ExcelApp.Visible = true;
                                }

                                Marshal.FinalReleaseComObject(ExcelApp);
                            }
                            catch (Exception ex)
                            {
                                SEACCExeption.Show(ex);
                            }
                        }
                        #endregion

                        #region ETF - Excel Sheet Electronic Format
                        else if (Report == enum_ReportName.ETF_ElectronicFormat)
                        {
                            try
                            {
                                #region Initialize Data Table
                                DataTable dt = new DataTable();
                                dt.Columns.Add("EPFNo");
                                dt.Columns.Add("Initials");
                                dt.Columns.Add("LastName");
                                dt.Columns.Add("NIC");
                                dt.Columns.Add("Members_Contribution");
                                #endregion

                                #region Fill Data Table
                                List<tbl_payTxSIPRawData> oRawDatarecords = tbl_payTxSIPRawData.SelectPeriod_ByDateRange(dtmFromDate.Date, dtmToDate.Date);
                                foreach (tbl_payTxSIPRawData oTxPayRawRecord in oRawDatarecords.Where(p => p.IsEPF_ETF_Process && p.IsPayslip_Print).OrderBy(o => o.EpfNo))
                                {

                                    #region Filters
                                    if (bEmployeeSelected)
                                        if (txtEmployee.Tag.ToString() != oTxPayRawRecord.Employee_ID)
                                            continue;
                                    if (bDivisionSelected && !msbDivision.IsSelectAll())
                                        if (vDivisions.Exists(r => r.Field<string>("id").Trim() != oTxPayRawRecord.Division_ID.Trim()))
                                            continue;
                                    if (bDepartmentSelected)
                                        if (txtDepartment.Tag.ToString() != oTxPayRawRecord.Department_ID)
                                            continue;
                                    if (bSectionSelected)
                                        if (txtSection.Tag.ToString() != oTxPayRawRecord.SectionID)
                                            continue;
                                    if (bSubSectionSelected)
                                        if (txtSubSection.Tag.ToString() != oTxPayRawRecord.SubSectionID)
                                            continue;
                                    if (bDesignationSelected)
                                        if (txtDesignation.Tag.ToString() != oTxPayRawRecord.Designation_ID)
                                            continue;
                                    if (bEmpCategory1Selected)
                                        if (txtEmpCategory1.Tag.ToString() != oTxPayRawRecord.EmpCatagory1_ID)
                                            continue;
                                    if (bEmpCategory2Selected)
                                        if (txtEmpCategory2.Tag.ToString() != oTxPayRawRecord.EmpCatagory2_ID)
                                            continue;
                                    if (bEmpCategory3Selected)
                                        if (txtEmpCategory3.Tag.ToString() != oTxPayRawRecord.EmpCatagory3_ID)
                                            continue;
                                    if (bPaymentMethodSelected)
                                        if (txtPayementMethodBy.Tag.ToString() != oTxPayRawRecord.PaymentMethod_ID)
                                            continue;
                                    #endregion

                                    decimal dNetSalary = decimal.Round(clsHelpMethods.GetNetSalary_FromTX(oTxPayRawRecord.Employee_ID, oTxPayRawRecord.ProcessPeriod_Sub_startDate.Date, oTxPayRawRecord.ProcessPeriod_Sub_endDate.Date), 2);
                                    decimal dETF_Pct_3 = clsHelpMethods.GetStatutaryItemAmount_FromTx(oTxPayRawRecord.SIP_ID, clsConfig.sETF);

                                    tbl_genMasEmployee oEmp = tbl_genMasEmployee.Select(oTxPayRawRecord.Employee_ID, clsSecurity.CompanyID, clsSecurity.BranchID);
                                    if (oEmp != null)
                                        dt.Rows.Add(oTxPayRawRecord.EpfNo, oEmp.Initails, oEmp.SurName, oTxPayRawRecord.NicNo, cls_Formater.FormatDecimal(dETF_Pct_3, 2));

                                }
                                #endregion

                                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                                ExcelApp.Application.Workbooks.Add(Type.Missing);

                                #region Set Header and Column Width
                                ExcelApp.Cells[1, 1] = "ETF Electronic Format";
                                ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 5]].Merge();

                                ExcelApp.Cells[3, 1] = "Member's No.";
                                ExcelApp.Cells[3, 2] = "Initials";
                                ExcelApp.Cells[3, 3] = "Sure Name";
                                ExcelApp.Cells[3, 4] = "NIC No.";
                                ExcelApp.Cells[3, 5] = "Contribution";

                                ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 5]].Borders.Color = System.Drawing.Color.Black;
                                ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 5]].Interior.Color = System.Drawing.Color.LightGray;
                                ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 5]].ColumnWidth = 20;
                                #endregion

                                #region Fill Cells
                                int k = 4;
                                foreach (DataRow row in dt.Rows)
                                {
                                    ExcelApp.Cells[k, 1] = row[0];
                                    ExcelApp.Cells[k, 2] = row[1];
                                    ExcelApp.Cells[k, 3] = row[2];
                                    ExcelApp.Cells[k, 4] = row[3];
                                    ExcelApp.Cells[k, 5] = row[4];
                                    //ExcelApp.Range[ExcelApp.Cells[k, 1], ExcelApp.Cells[k, 5]].Borders.Color = System.Drawing.Color.Black;

                                    k++;
                                }
                                #endregion

                                ExcelApp.Columns.WrapText = true;
                                ExcelApp.Columns.AutoFit();

                                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                                dlg.DefaultExt = ".xls";
                                dlg.Filter = "Excel documents (.xls)|*.xlsx";
                                if (dlg.ShowDialog() == true)
                                {
                                    string filename = dlg.FileName;
                                    ExcelApp.ActiveWorkbook.SaveAs(filename);
                                    SEACCMessageBox.Show("Successfully created", "Excel file is successfully created", MessageBoxButton.OK);
                                    ExcelApp.ActiveWorkbook.Saved = true;
                                    ExcelApp.Visible = true;
                                }

                                Marshal.FinalReleaseComObject(ExcelApp);
                            }
                            catch (Exception ex)
                            {
                                SEACCExeption.Show(ex);
                            }
                        }
                        #endregion

                        #region ETF - Return For Half Year Ending (From II Return) / Single Earning and Deduction Statement
                        else if (Report == enum_ReportName.ReturnForHalf_YearEnding || Report == enum_ReportName.SingleEarningDeductionStatement)
                        {

                            DataSets.dts_PAY glb_dts_PAY = new DataSets.dts_PAY();

                            string sAmount_ID = "";
                            if (Report == enum_ReportName.SingleEarningDeductionStatement)
                            {
                                if (!bPayslipItemSelected)
                                {
                                    SEACCMessageBox.Show("Oops....", " Please select a Payslip Item ", MessageBoxButton.OK, "Red");
                                    return;
                                }

                                sAmount_ID = txtPayslipItem.Tag.ToString();
                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("PayslipItemID", txtPayslipItem.Tag.ToString(), true);
                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("PayslipItemName", txtPayslipItem.Text, true);//PayslipItemName
                            }
                            else if (Report == enum_ReportName.ReturnForHalf_YearEnding)
                                sAmount_ID = clsConfig.sETF;

                            DateTime dtmStartDate = dtmFromDate;
                            DateTime dtmEndDate = dtmStartDate.AddMonths(5);
                            DateTime dtmMonthEndDate = dtmEndDate.AddMonths(1).AddDays(-1);
                            int iNoOfMonths = (dtmEndDate.Year - dtmStartDate.Year) * 12 + dtmEndDate.Month - dtmStartDate.Month;
                            string sMonth = "";

                            #region Fill Company Data
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, sctComDetails.sEPF_RegNo, sctComDetails.sETF_RegNo, sctComDetails.sPayee_RegNo, sctComDetails.sTax_IdentityNo, oReport.DisplayName, "", "For the period : " + dtmFromDate.ToString(clsConfig.Format_Date2) + " to " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                            {
                                tbl_genCompanyInfo oCompany = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
                                glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oCompany.Epf_RegNo, oCompany.Etf_RegNo, oCompany.Payee_RegNo, oCompany.Tax_IdentityNo, oReport.DisplayName, "", "For the period : " + dtmFromDate.ToString(clsConfig.Format_Date2) + " to " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }

                            glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("EndDate", dtmMonthEndDate.ToString("dd MMMM, yyyy"), true);
                            #endregion

                            for (int i = 0; i <= iNoOfMonths; i++)
                            {
                                #region Variable Initialize
                                dtmStartDate = dtmFromDate.AddMonths(i);
                                dtmEndDate = dtmStartDate.AddMonths(1).AddDays(-1);

                                sMonth = dtmStartDate.ToString("MMMM");
                                decimal dAmount1 = 0;
                                decimal dAmount2 = 0;
                                decimal dAmount3 = 0;
                                decimal dAmount4 = 0;
                                decimal dAmount5 = 0;
                                decimal dAmount6 = 0;

                                decimal dContribution1 = 0;
                                decimal dContribution2 = 0;
                                decimal dContribution3 = 0;
                                decimal dContribution4 = 0;
                                decimal dContribution5 = 0;
                                decimal dContribution6 = 0;
                                #endregion

                                #region Formular Fields
                                if (i == 0)
                                    glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("Month_1", sMonth, true);
                                if (i == 1)
                                    glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("Month_2", sMonth, true);
                                if (i == 2)
                                    glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("Month_3", sMonth, true);
                                if (i == 3)
                                    glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("Month_4", sMonth, true);
                                if (i == 4)
                                    glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("Month_5", sMonth, true);
                                if (i == 5)
                                    glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("Month_6", sMonth, true);
                                #endregion

                                #region Selected Filters
                                List<tbl_payTxSIPRawData> oTxSIP_PayDataRows = tbl_payTxSIPRawData.SelectPeriod_ByDateRange(dtmStartDate.Date, dtmEndDate.Date).Where(r => r.IsPayslip_Print).ToList();

                                if (bEmployeeSelected)
                                    oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.Employee_ID == txtEmployee.Tag.ToString()).ToList();
                                if (bDivisionSelected)
                                    oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => vDivisions.Any(r2 => r2.Field<string>("id") == r.Division_ID)).ToList();
                                if (bDepartmentSelected)
                                    oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.Department_ID == txtDepartment.Tag.ToString()).ToList();
                                if (bSectionSelected)
                                    oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.SectionID == txtSection.Tag.ToString()).ToList();
                                if (bSubSectionSelected)
                                    oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.SubSectionID == txtSubSection.Tag.ToString()).ToList();
                                if (bDesignationSelected)
                                    oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.Designation_ID == txtDesignation.Tag.ToString()).ToList();
                                if (bEmpCategory1Selected)
                                    oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();
                                if (bEmpCategory2Selected)
                                    oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();
                                if (bEmpCategory3Selected)
                                    oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();
                                #endregion

                                foreach (tbl_payTxSIPRawData oItem in oTxSIP_PayDataRows.OrderBy(o => o.EpfNo.PadLeft(4, ' ')))
                                {
                                    if (Report == enum_ReportName.ReturnForHalf_YearEnding && !oItem.IsEPF_ETF_Process)
                                        continue;

                                    #region ETF - Return For Half Year Ending
                                    if (Report == enum_ReportName.ReturnForHalf_YearEnding)
                                    {
                                        if (i == 0)
                                        {
                                            dAmount1 = clsHelpMethods.GetBaseSalaryForStatutory_FromTX(sAmount_ID, oItem.SIP_ID);
                                            dContribution1 = clsHelpMethods.GetStatutaryItemAmount_FromTx(oItem.SIP_ID, sAmount_ID);
                                        }
                                        if (i == 1)
                                        {
                                            dAmount2 = clsHelpMethods.GetBaseSalaryForStatutory_FromTX(sAmount_ID, oItem.SIP_ID);
                                            dContribution2 = clsHelpMethods.GetStatutaryItemAmount_FromTx(oItem.SIP_ID, sAmount_ID);
                                        }
                                        if (i == 2)
                                        {
                                            dAmount3 = clsHelpMethods.GetBaseSalaryForStatutory_FromTX(sAmount_ID, oItem.SIP_ID);
                                            dContribution3 = clsHelpMethods.GetStatutaryItemAmount_FromTx(oItem.SIP_ID, sAmount_ID);
                                        }
                                        if (i == 3)
                                        {
                                            dAmount4 = clsHelpMethods.GetBaseSalaryForStatutory_FromTX(sAmount_ID, oItem.SIP_ID);
                                            dContribution4 = clsHelpMethods.GetStatutaryItemAmount_FromTx(oItem.SIP_ID, sAmount_ID);
                                        }
                                        if (i == 4)
                                        {
                                            dAmount5 = clsHelpMethods.GetBaseSalaryForStatutory_FromTX(sAmount_ID, oItem.SIP_ID);
                                            dContribution5 = clsHelpMethods.GetStatutaryItemAmount_FromTx(oItem.SIP_ID, sAmount_ID);
                                        }
                                        if (i == 5)
                                        {
                                            dAmount6 = clsHelpMethods.GetBaseSalaryForStatutory_FromTX(sAmount_ID, oItem.SIP_ID);
                                            dContribution6 = clsHelpMethods.GetStatutaryItemAmount_FromTx(oItem.SIP_ID, sAmount_ID);
                                        }
                                    }
                                    #endregion

                                    #region Payslip Item Amount For Six Months
                                    else
                                    {
                                        if (i == 0)
                                        {
                                            dAmount1 = clsHelpMethods.GetNetSalary_FromTX(oItem.SIP_ID);
                                            dContribution1 = clsHelpMethods.GetPayItemAmount_FromTX(oItem.SIP_ID, sAmount_ID);
                                        }
                                        if (i == 1)
                                        {
                                            dAmount2 = clsHelpMethods.GetNetSalary_FromTX(oItem.SIP_ID);
                                            dContribution2 = clsHelpMethods.GetPayItemAmount_FromTX(oItem.SIP_ID, sAmount_ID);
                                        }
                                        if (i == 2)
                                        {
                                            dAmount3 = clsHelpMethods.GetNetSalary_FromTX(oItem.SIP_ID);
                                            dContribution3 = clsHelpMethods.GetPayItemAmount_FromTX(oItem.SIP_ID, sAmount_ID);
                                        }
                                        if (i == 3)
                                        {
                                            dAmount4 = clsHelpMethods.GetNetSalary_FromTX(oItem.SIP_ID);
                                            dContribution4 = clsHelpMethods.GetPayItemAmount_FromTX(oItem.SIP_ID, sAmount_ID);
                                        }
                                        if (i == 4)
                                        {
                                            dAmount5 = clsHelpMethods.GetNetSalary_FromTX(oItem.SIP_ID);
                                            dContribution5 = clsHelpMethods.GetPayItemAmount_FromTX(oItem.SIP_ID, sAmount_ID);
                                        }
                                        if (i == 5)
                                        {
                                            dAmount6 = clsHelpMethods.GetNetSalary_FromTX(oItem.SIP_ID);
                                            dContribution6 = clsHelpMethods.GetPayItemAmount_FromTX(oItem.SIP_ID, sAmount_ID);
                                        }
                                    }
                                    #endregion


                                    if (dContribution1 == 0 && dContribution2 == 0 && dContribution3 == 0 && dContribution4 == 0 && dContribution5 == 0 && dContribution6 == 0)
                                        continue;

                                    #region Fill Data Table
                                    glb_dts_PAY.dt_ReturnForHalfYearEnding.Adddt_ReturnForHalfYearEndingRow(oItem.Employee_ID.PadLeft(4, ' '), clsRef_Name.get_EmployeeShortName(oItem.Employee_ID), clsRef_Name.get_EmployeeNICNo(oItem.Employee_ID), clsRef_Name.get_EmployeeEPFNo(oItem.Employee_ID).PadLeft(4, ' '),
                                                                    oItem.Division_ID, clsRef_Name.get_Division_Name(oItem.Division_ID),
                                                                    oItem.Department_ID, clsRef_Name.get_Department_Name(oItem.Department_ID),
                                                                    oItem.SectionID, clsRef_Name.get_Section_Name(oItem.SectionID),
                                                                    oItem.SubSectionID, clsRef_Name.get_SubSection_Name(oItem.SubSectionID),
                                                                    oItem.EmpCatagory1_ID, clsRef_Name.get_EmployeeCategory1_Name(oItem.EmpCatagory1_ID),
                                                                    oItem.EmpCatagory2_ID, clsRef_Name.get_EmployeeCategory2_Name(oItem.EmpCatagory2_ID),
                                                                    oItem.EmpCatagory3_ID, clsRef_Name.get_EmployeeCategory3_Name(oItem.EmpCatagory3_ID),
                                                                    dAmount1, dContribution1,
                                                                    dAmount2, dContribution2,
                                                                    dAmount3, dContribution3,
                                                                    dAmount4, dContribution4,
                                                                    dAmount5, dContribution5,
                                                                    dAmount6, dContribution6,
                                                                    sMonth);
                                    #endregion
                                }
                            }

                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_PAY, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }
                        #endregion

                        #region Paid Employee List
                        else if (Report == enum_ReportName.PaidEmployeeList)
                        {
                            tbl_genCompanyInfo oCompany = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
                            DataSets.dts_PAY glb_dts_PAY = new DataSets.dts_PAY();
                            //glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oCompany.Epf_RegNo, oCompany.Etf_RegNo, oCompany.Payee_RegNo, oCompany.Tax_IdentityNo, oReport.DisplayName, "", dtmFromDate.ToString("Y"), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #region Company Data Set Fill
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, sctComDetails.sEPF_RegNo, sctComDetails.sETF_RegNo, sctComDetails.sPayee_RegNo, sctComDetails.sTax_IdentityNo, oReport.DisplayName, "", dtmFromDate.ToString("Y"), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                                glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oCompany.Epf_RegNo, oCompany.Etf_RegNo, oCompany.Payee_RegNo, oCompany.Tax_IdentityNo, oReport.DisplayName, "", dtmFromDate.ToString("Y"), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            #endregion

                            #region Filters
                            #region Employee Filter
                            List<tbl_genMasEmployee> oEmployees;
                            if (bEmployeeSelected)
                            {
                                oEmployees = new List<tbl_genMasEmployee>();
                                oEmployees.Add(tbl_genMasEmployee.Select(txtEmployee.Tag.ToString(), clsSecurity.CompanyID, clsSecurity.BranchID));
                            }
                            else
                                oEmployees = tbl_genMasEmployee.SelectAll().ToList();
                            #endregion

                            if (bDesignationSelected)
                                oEmployees = oEmployees.Where(p => p.Designation_ID == txtDesignation.Tag.ToString()).ToList();

                            if (bDivisionSelected)
                                oEmployees = oEmployees.Where(r => vDivisions.Any(r2 => r2.Field<string>("id") == r.Division_ID)).ToList();

                            if (bDepartmentSelected)
                                oEmployees = oEmployees.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();

                            if (bSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();

                            if (bSubSectionSelected)
                                oEmployees = oEmployees.Where(p => p.SubSectionID == txtSubSection.Tag.ToString()).ToList();

                            if (bEmpCategory1Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();

                            if (bEmpCategory2Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();

                            if (bEmpCategory3Selected)
                                oEmployees = oEmployees.Where(p => p.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();

                            #endregion

                            foreach (tbl_genMasEmployee oEmp in oEmployees.Where(r => r.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString()))
                            {
                                tbl_payTxSIPRawData oRawItem = tbl_payTxSIPRawData.SelectPeriod_ByDateRange(dtmFromDate.Date, dtmToDate.Date).Where(r => r.Employee_ID == oEmp.Employee_ID).FirstOrDefault();
                                if (oRawItem != null)
                                {
                                    #region Payslip Print Filters
                                    if (bPayPeriodSelected)
                                    {
                                        if (oRawItem.ProcessPeriod_Sub_ID.ToString() != txtPayPeriod.Tag.ToString())
                                            continue;
                                    }
                                    if (bPaymentMethodSelected)
                                    {
                                        if (oRawItem.PaymentMethod_ID.ToString() != txtPayementMethodBy.Tag.ToString())
                                            continue;
                                    }
                                    if (rdoIsPaySlipPrint.IsChecked.Value)
                                    {
                                        if (oRawItem.IsPayslip_Print == false)
                                            continue;
                                    }
                                    if (rdoIsNotPaySlipPrint.IsChecked.Value)
                                    {
                                        if (oRawItem.IsPayslip_Print == true)
                                            continue;
                                    }
                                    #endregion

                                    tbl_payMas_ProcessPeriod_Sub oPayroll_Period = tbl_payMas_ProcessPeriod_Sub.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oRawItem.ProcessGroup_ID, oRawItem.ProcessPeriod_ID, oRawItem.ProcessPeriod_Sub_ID);
                                    glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("Draft", "DRAFT", !oPayroll_Period.IsClosedPeriod);
                                    if (!oPayroll_Period.IsClosedPeriod && Report == enum_ReportName.EmployeePayslip)
                                        continue;

                                    tbl_securityParollGroup_UserPermission oGrpPermission = tbl_securityParollGroup_UserPermission.Select(clsSecurity.CompanyID, clsSecurity.BranchID, clsSecurity.UserIDLoged, oRawItem.ProcessGroup_ID);
                                    if (oGrpPermission != null && oGrpPermission.AllowView)
                                    {
                                        glb_dts_PAY.dt_UnpaidEmployee_List.Adddt_UnpaidEmployee_ListRow(oRawItem.Employee_ID, clsRef_Name.get_EmployeeShortName(oRawItem.Employee_ID), oRawItem.NicNo, oRawItem.IsEPF_ETF_Process, oRawItem.EpfNo.PadLeft(4, '0'),
                                        oRawItem.Division_ID, clsRef_Name.get_Division_Name(oRawItem.Division_ID),
                                        oRawItem.Department_ID, clsRef_Name.get_Department_Name(oRawItem.Department_ID),
                                        oRawItem.SectionID, clsRef_Name.get_Section_Name(oRawItem.SectionID),
                                        clsHelpMethods.GetEarningTotal_Previous(oRawItem.Employee_ID, dtmFromDate.Date, dtmToDate.Date),
                                        clsHelpMethods.GetDeductionTotal_Previous(oRawItem.Employee_ID, dtmFromDate.Date, dtmToDate.Date),
                                        clsHelpMethods.IsPayslipPrint_Prevois(oRawItem.Employee_ID, oRawItem.ProcessPeriod_Sub_startDate.Date, oRawItem.ProcessPeriod_Sub_endDate),
                                        clsHelpMethods.GetEarningTotal(oRawItem.Employee_ID, dtmFromDate.Date, dtmToDate.Date),
                                        clsHelpMethods.GetDeductionTotal(oRawItem.Employee_ID, dtmFromDate.Date, dtmToDate.Date),
                                        oRawItem.IsPayslip_Print);
                                    }
                                }
                            }

                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_PAY, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }
                        #endregion

                        #region PAYE - Employee List
                        else if (Report == enum_ReportName.EmployeePAYE_Deduction)
                        {

                            DataSets.dts_PAY glb_dts_PAY = new DataSets.dts_PAY();

                            #region Company Data Set Fill
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, sctComDetails.sEPF_RegNo, sctComDetails.sETF_RegNo, sctComDetails.sPayee_RegNo, sctComDetails.sTax_IdentityNo, oReport.DisplayName, "", "For the period : " + dtmFromDate.ToString(clsConfig.Format_Date2) + " to " + dtmToDate.ToString(clsConfig.Format_Date2), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                            {
                                tbl_genCompanyInfo oCompany = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
                                glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oCompany.Epf_RegNo, oCompany.Etf_RegNo, oCompany.Payee_RegNo, oCompany.Tax_IdentityNo, oReport.DisplayName, "", dtmFromDate.ToString("Y"), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            #endregion

                            List<tbl_payTxSIPRawData> oTxSIP_RawData = tbl_payTxSIPRawData.SelectAllPeriods_ByDateRange(dtmFromDate.Date, dtmToDate.Date).Where(r => r.Is_PayeeProcess && r.IsPayslip_Print).ToList();

                            #region Selected Filters
                            if (bEmployeeSelected)
                                oTxSIP_RawData = oTxSIP_RawData.Where(r => r.Employee_ID == txtEmployee.Tag.ToString()).ToList();
                            if (bDivisionSelected)
                                oTxSIP_RawData = oTxSIP_RawData.Where(r => vDivisions.Any(r2 => r2.Field<string>("id") == r.Division_ID)).ToList();
                            if (bDepartmentSelected)
                                oTxSIP_RawData = oTxSIP_RawData.Where(r => r.Department_ID == txtDepartment.Tag.ToString()).ToList();
                            if (bSectionSelected)
                                oTxSIP_RawData = oTxSIP_RawData.Where(r => r.SectionID == txtSection.Tag.ToString()).ToList();
                            if (bSubSectionSelected)
                                oTxSIP_RawData = oTxSIP_RawData.Where(r => r.SubSectionID == txtSubSection.Tag.ToString()).ToList();
                            if (bDesignationSelected)
                                oTxSIP_RawData = oTxSIP_RawData.Where(r => r.Designation_ID == txtDesignation.Tag.ToString()).ToList();
                            if (bEmpCategory1Selected)
                                oTxSIP_RawData = oTxSIP_RawData.Where(r => r.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();
                            if (bEmpCategory2Selected)
                                oTxSIP_RawData = oTxSIP_RawData.Where(r => r.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();
                            if (bEmpCategory3Selected)
                                oTxSIP_RawData = oTxSIP_RawData.Where(r => r.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();
                            if (bPayPeriodSelected)
                                oTxSIP_RawData = oTxSIP_RawData.Where(r => r.ProcessGroup_ID == txtPayPeriod.Uid && r.ProcessPeriod_ID == int.Parse(txtPayPeriod.ToolTip.ToString()) && r.ProcessPeriod_Sub_ID == int.Parse(txtPayPeriod.Tag.ToString())).ToList();
                            if (bPaymentMethodSelected)
                                oTxSIP_RawData = oTxSIP_RawData.Where(r => r.PaymentMethod_ID == txtPayementMethodBy.Tag.ToString()).ToList();
                            #endregion

                            foreach (tbl_payTxSIPRawData oRawItem in oTxSIP_RawData.OrderBy(o => o.EpfNo.PadLeft(4, '0')))
                            {
                                tbl_payMas_ProcessPeriod_Sub oPayroll_Period = tbl_payMas_ProcessPeriod_Sub.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oRawItem.ProcessGroup_ID, oRawItem.ProcessPeriod_ID, oRawItem.ProcessPeriod_Sub_ID);
                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("Draft", "DRAFT", !oPayroll_Period.IsClosedPeriod);
                                if (!oPayroll_Period.IsClosedPeriod && Report == enum_ReportName.EmployeePayslip)
                                    continue;

                                tbl_securityParollGroup_UserPermission oGrpPermission = tbl_securityParollGroup_UserPermission.Select(clsSecurity.CompanyID, clsSecurity.BranchID, clsSecurity.UserIDLoged, oRawItem.ProcessGroup_ID);
                                if (oGrpPermission != null && oGrpPermission.AllowView)
                                {
                                    glb_dts_PAY.dt_EmpSalaryData.Adddt_EmpSalaryDataRow(oRawItem.Employee_ID, oRawItem.NicNo, clsRef_Name.get_EmployeeShortName(oRawItem.Employee_ID),
                                        oRawItem.Division_ID, clsRef_Name.get_Division_Name(oRawItem.Division_ID),
                                        oRawItem.Department_ID, clsRef_Name.get_Department_Name(oRawItem.Department_ID),
                                        oRawItem.SectionID, clsRef_Name.get_Section_Name(oRawItem.SectionID),
                                        oRawItem.SubSectionID, clsRef_Name.get_SubSection_Name(oRawItem.SubSectionID),
                                        oRawItem.EmpCatagory1_ID, clsRef_Name.get_EmployeeCategory1_Name(oRawItem.EmpCatagory1_ID),
                                        oRawItem.EmpCatagory2_ID, clsRef_Name.get_EmployeeCategory2_Name(oRawItem.EmpCatagory2_ID),
                                        oRawItem.EmpCatagory3_ID, clsRef_Name.get_EmployeeCategory3_Name(oRawItem.EmpCatagory3_ID),
                                        clsRef_Name.get_Designation_Name(oRawItem.Designation_ID), oRawItem.EmpDateConfirmed,
                                        oRawItem.ProcessGroup_ID, clsRef_Name.get_processGroup_Name(oRawItem.ProcessGroup_ID),
                                        oRawItem.ProcessPeriod_ID.ToString(), "-", oRawItem.ProcessPeriod_Sub_ID.ToString(), "-",
                                        oRawItem.IsEPF_ETF_Process, oRawItem.EpfNo, oRawItem.Is_PayeeProcess, oRawItem.PayeeNo,
                                        "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                        clsRef_Name.get_EmployeeAliasName(oRawItem.Employee_ID), clsRef_Name.get_EmployeeName(oRawItem.Employee_ID),
                                        oRawItem.ProcessPeriod_Sub_startDate, oRawItem.ProcessPeriod_Sub_endDate);

                                    glb_dts_PAY.dt_PAYE_Deduction.Adddt_PAYE_DeductionRow(oRawItem.Employee_ID, clsHelpMethods.GetGrossSalary_FromTX(oRawItem.SIP_ID), clsHelpMethods.GetPayItemAmount_FromTX(oRawItem.SIP_ID, clsConfig.sPAYE), 0, 0, 0, 0);

                                }
                            }

                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_PAY, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }


                        #endregion

                        #region UnProcessed - Coin Analysis Report
                        else if (Report == enum_ReportName.UnprocessedCoinAnalysisReport)
                        {
                            DataSets.dts_PAY glb_dts_PAY = new DataSets.dts_PAY();

                            #region Selected Filters
                            List<tbl_genMasEmployee> oEmpList = tbl_genMasEmployee.SelectAll().Where(r => r.Employee_ID != "default" && r.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString()).ToList();
                            if (bEmployeeSelected)
                                oEmpList = oEmpList.Where(r => r.Employee_ID == txtEmployee.Tag.ToString()).ToList();
                            if (bDivisionSelected)
                                oEmpList = oEmpList.Where(r => vDivisions.Any(r2 => r2.Field<string>("id") == r.Division_ID)).ToList();
                            if (bDepartmentSelected)
                                oEmpList = oEmpList.Where(r => r.Department_ID == txtDepartment.Tag.ToString()).ToList();
                            if (bSectionSelected)
                                oEmpList = oEmpList.Where(r => r.SectionID == txtSection.Tag.ToString()).ToList();
                            if (bSubSectionSelected)
                                oEmpList = oEmpList.Where(r => r.SubSectionID == txtSubSection.Tag.ToString()).ToList();
                            if (bDesignationSelected)
                                oEmpList = oEmpList.Where(r => r.Designation_ID == txtDesignation.Tag.ToString()).ToList();
                            if (bEmpCategory1Selected)
                                oEmpList = oEmpList.Where(r => r.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();
                            if (bEmpCategory2Selected)
                                oEmpList = oEmpList.Where(r => r.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();
                            if (bEmpCategory3Selected)
                                oEmpList = oEmpList.Where(r => r.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();
                            if (bPaymentMethodSelected)
                                oEmpList = oEmpList.Where(r => r.PaymentMethod_ID == txtPayementMethodBy.Tag.ToString()).ToList();
                            #endregion

                            if (bPayslipItemSelected)
                            {
                                #region Company Data Set Fill
                                if (bDivisionSelected)
                                {
                                    CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                    glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, sctComDetails.sEPF_RegNo, sctComDetails.sETF_RegNo, sctComDetails.sPayee_RegNo, sctComDetails.sTax_IdentityNo, oReport.DisplayName, oReport.DisplayName2, dtmFromDate.ToString("Y"), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                }
                                else
                                {
                                    tbl_genCompanyInfo oCompany = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
                                    glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oCompany.Epf_RegNo, oCompany.Etf_RegNo, oCompany.Payee_RegNo, oCompany.Tax_IdentityNo, oReport.DisplayName, oReport.DisplayName2, dtmFromDate.ToString("Y"), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                }
                                #endregion

                                foreach (tbl_genMasEmployee oEmp in oEmpList.OrderBy(o => o.EpfNo.PadLeft(4, '0')))
                                {
                                    tbl_securityParollGroup_UserPermission oGrpPermission = tbl_securityParollGroup_UserPermission.Select(clsSecurity.CompanyID, clsSecurity.BranchID, clsSecurity.UserIDLoged, oEmp.Payroll_ProcessGroupID);
                                    if (oGrpPermission != null && oGrpPermission.AllowEdit)
                                    {
                                        tbl_genMasEmployee_PaySlipItems oMasItem = tbl_genMasEmployee_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oEmp.Employee_ID, txtPayslipItem.Tag.ToString());
                                        if (oMasItem != null && oMasItem.Rate != 0)
                                        {
                                            tbl_payMas_PaySlipItems oItems = tbl_payMas_PaySlipItems.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oMasItem.PayItem_ID);
                                            if (oItems != null)
                                            {
                                                glb_dts_PAY.dt_MasPayslipItem.Adddt_MasPayslipItemRow(oMasItem.Employee_ID, oEmp.NicNo, clsRef_Name.get_EmployeeShortName(oMasItem.Employee_ID), clsRef_Name.get_EmployeeAliasName(oMasItem.Employee_ID), oEmp.IsEPF_ETF_Process, oEmp.EpfNo,
                                                    oEmp.Division_ID, clsRef_Name.get_Division_Name(oEmp.Division_ID),
                                                    oEmp.Department_ID, clsRef_Name.get_Department_Name(oEmp.Department_ID),
                                                    oEmp.SectionID, clsRef_Name.get_Section_Name(oEmp.SectionID), oMasItem.PayItem_ID, oItems.PayItem_Title,
                                                    oEmp.PaymentMethod_ID, oEmp.PaymentMethod_ID != "default" ? clsRef_Name.get_PayemntMethode_Name(oEmp.PaymentMethod_ID) : "Other",
                                                    oMasItem.Rate);
                                            }
                                        }
                                    }

                                }

                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("PayslipItemID", txtPayslipItem.Tag.ToString(), true);
                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("PayslipItemName", clsRef_Name.get_PaySlipItem_Title(txtPayslipItem.Tag.ToString()), true);//PayslipItemName

                                frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                                frmViewer.print(oReport.ReportPath, glb_dts_PAY, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                            }
                            else
                                SEACCMessageBox.Show("Payslip Item can not be empty", "Please select valid payslip", MessageBoxButton.OK, "Red");

                        }
                        #endregion

                        #region Payroll Summary
                        else if (Report == enum_ReportName.PayrollSummary)
                        {

                            DataSets.dts_PAY glb_dts_PAY = new DataSets.dts_PAY();
                            glb_dts_PAY.dt_PayrollSummary.Clear();

                            #region Variables
                            decimal dPrevActiveBS = 0, dPrevResignedEmployeesBS = 0, dPrevRecruitsEmployeeBS = 0, dPrevIncrement = 0, dPrevCasualTransfer = 0, dPrevTransfer = 0;
                            decimal dActiveBS = 0, dResignedEmployeesBS = 0, dRecruitsEmployeeBS = 0, dIncrementEmp = 0, dCasualTransfer = 0, dTransfer = 0;
                            decimal dAmount = 0, dAddAmount = 0, dLessAmount = 0, dTotAmt = 0;
                            decimal dPrevAmount = 0, dPrevAddAmount = 0, dPrevLessAmount = 0, dPrevTotAmt = 0;

                            int iPrevActiveBS = 0, iPrevResignedEmployeesBS = 0, iPrevRecruitsEmployeeBS = 0, iPrevIncrement = 0, iPrevCasualTransfer = 0, iPrevTransfer = 0;
                            int iActiveBS = 0, iResignedEmployees = 0, iRecruitsEmployee = 0, iIncrementEmp = 0, iCasualTransfer = 0, iTransfer = 0;
                            int iTotNoofHeads = 0, iPrevTotNoofHeads = 0;
                            #endregion

                            DateTime dtFromDate = dtmFromDate.AddMonths(-1);
                            DateTime dtToDate = dtmToDate;
                            int iNoOfMonths = ((dtToDate.Year - dtFromDate.Year) * 12) + dtToDate.Month - dtFromDate.Month; // dtToDate.Month - dtFromDate.Month; 

                            if (iNoOfMonths <= 1)
                            {
                                #region Company Data Set Fill
                                if (bDivisionSelected)
                                {
                                    CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                    glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, sctComDetails.sEPF_RegNo, sctComDetails.sETF_RegNo, sctComDetails.sPayee_RegNo, sctComDetails.sTax_IdentityNo, oReport.DisplayName, oReport.DisplayName2, dtFromDate.ToString("Y") + " - " + dtToDate.ToString("Y"), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                }
                                else
                                {
                                    tbl_genCompanyInfo oCompany = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
                                    glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oCompany.Epf_RegNo, oCompany.Etf_RegNo, oCompany.Payee_RegNo, oCompany.Tax_IdentityNo, oReport.DisplayName, oReport.DisplayName2, dtFromDate.ToString("Y") + " - " + dtToDate.ToString("Y"), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                }
                                #endregion

                                for (int i = 0; i <= iNoOfMonths; i++)
                                {
                                    DateTime dtmStartDate = dtFromDate.AddMonths(i);
                                    DateTime dtmEndDate = dtmStartDate.AddMonths(1).AddDays(-1);

                                    List<tbl_payTxSIPRawData> oRawDataList = tbl_payTxSIPRawData.SelectAllPeriods_ByDateRange(dtmStartDate.Date, dtmEndDate.Date).Where(r => r.IsPayslip_Print).ToList();

                                    #region Filters
                                    if (bDesignationSelected)
                                        oRawDataList = oRawDataList.Where(p => p.Designation_ID == txtDesignation.Tag.ToString()).ToList();

                                    if (bDivisionSelected)
                                        oRawDataList = oRawDataList.Where(r => vDivisions.Any(r2 => r2.Field<string>("id") == r.Division_ID)).ToList();

                                    if (bDepartmentSelected)
                                        oRawDataList = oRawDataList.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();

                                    if (bSectionSelected)
                                        oRawDataList = oRawDataList.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();

                                    if (bSubSectionSelected)
                                        oRawDataList = oRawDataList.Where(p => p.SubSectionID == txtSubSection.Tag.ToString()).ToList();

                                    if (bEmpCategory1Selected)
                                        oRawDataList = oRawDataList.Where(p => p.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();

                                    if (bEmpCategory2Selected)
                                        oRawDataList = oRawDataList.Where(p => p.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();

                                    if (bEmpCategory3Selected)
                                        oRawDataList = oRawDataList.Where(p => p.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();
                                    #endregion

                                    foreach (tbl_payTxSIPRawData oRawData in oRawDataList)
                                    {
                                        tbl_genMasEmployee oEmp = tbl_genMasEmployee.Select(oRawData.Employee_ID, oRawData.Company_ID, oRawData.CompanyBranch_ID);
                                        //if (oEmp.LastWorkingDate.Date <= dtmFromDate.Date && oEmp.LastWorkingDate.Date != clsConfig.defaultDateTime.Date)
                                        //    continue;

                                        //string sPrevDivisionID = "";

                                        if (i == 0)
                                        {
                                            #region Previous Month Details
                                            int iPrevBSRow = 0, iPrevResRow = 0, iPrevRecRow = 0, iPrevCasRow = 0, iPrevIncRow = 0, iPrevTransRow = 0;
                                            if (oEmp.LastWorkingDate.Date >= dtmStartDate.Date && oEmp.LastWorkingDate.Date <= dtmEndDate.Date)
                                            {
                                                dPrevResignedEmployeesBS += clsHelpMethods.GetTotalBasicSalaryAmt_Resigned(oRawData.Company_ID, oRawData.CompanyBranch_ID, oRawData.SIP_ID, ref iPrevResRow);
                                                iPrevResignedEmployeesBS += iPrevResRow;
                                            }
                                            //else if (oRawData.Division_ID != oPrevRawData.Division_ID)
                                            //{
                                            //    dPrevTransfer += clsHelpMethods.GetTotalBasicSalaryAmt_Transfers(oRawData.Division_ID, oRawData.Employee_ID, oRawData.Company_ID, oRawData.CompanyBranch_ID, oRawData.SIP_ID, dtmStartDate, dtmToDate, ref iPrevTransRow);
                                            //    iPrevTransfer += iPrevTransRow;
                                            //}
                                            else
                                            {
                                                dPrevTotAmt += clsHelpMethods.GetTotalBasicSalaryAmt(oRawData.Company_ID, oRawData.CompanyBranch_ID, oRawData.SIP_ID, ref iPrevBSRow);
                                                iPrevTotNoofHeads += iPrevBSRow;
                                            }


                                            if (oEmp.DateJoin.Date >= dtmStartDate.Date && oEmp.DateJoin.Date <= dtmEndDate.Date)
                                            {
                                                dPrevRecruitsEmployeeBS += clsHelpMethods.GetTotalBasicSalaryAmt_Recruit(oRawData.Company_ID, oRawData.CompanyBranch_ID, oRawData.SIP_ID, ref iPrevRecRow);
                                                iPrevRecruitsEmployeeBS += iPrevRecRow;
                                            }
                                            else if (oEmp.DateConfirm.Date >= dtmStartDate.Date && oEmp.DateConfirm.Date <= dtmEndDate.Date)
                                            {
                                                dPrevCasualTransfer += clsHelpMethods.GetTotalBasicSalaryAmt_CassualTransfer(oRawData.Company_ID, oRawData.CompanyBranch_ID, oRawData.SIP_ID, ref iPrevCasRow);
                                                iPrevCasualTransfer += iPrevCasRow;
                                            }
                                            dPrevIncrement += clsHelpMethods.GetTotalIncrementAmt(oRawData.Company_ID, oRawData.CompanyBranch_ID, oRawData.SIP_ID, ref iPrevIncRow);
                                            iPrevIncrement += iPrevIncRow;
                                            #endregion
                                        }
                                        else
                                        {
                                            #region Current Month Details
                                            int iBSRow = 0, iResRow = 0, iRecRow = 0, iCasRow = 0, iIncRow = 0, iTransRow = 0;
                                            if (oEmp.LastWorkingDate.Date >= dtmStartDate.Date && oEmp.LastWorkingDate.Date <= dtmEndDate.Date)
                                            {
                                                dResignedEmployeesBS += clsHelpMethods.GetTotalBasicSalaryAmt_Resigned(oRawData.Company_ID, oRawData.CompanyBranch_ID, oRawData.SIP_ID, ref iResRow);
                                                iResignedEmployees += iResRow;
                                            }
                                            //else if (oRawData.Division_ID != oPrevRawData.Division_ID)
                                            //{
                                            //    dTransfer += clsHelpMethods.GetTotalBasicSalaryAmt_Transfers(oRawData.Division_ID, oRawData.Employee_ID, oRawData.Company_ID, oRawData.CompanyBranch_ID, oRawData.SIP_ID, dtmStartDate, dtmToDate, ref iTransRow);
                                            //    iTransfer += iTransRow;
                                            //}
                                            else
                                            {
                                                dTotAmt += clsHelpMethods.GetTotalBasicSalaryAmt(oRawData.Company_ID, oRawData.CompanyBranch_ID, oRawData.SIP_ID, ref iBSRow);
                                                iTotNoofHeads += iBSRow;
                                            }

                                            if (oEmp.DateJoin.Date >= dtmStartDate.Date && oEmp.DateJoin.Date <= dtmEndDate.Date)
                                            {
                                                dRecruitsEmployeeBS += clsHelpMethods.GetTotalBasicSalaryAmt_Recruit(oRawData.Company_ID, oRawData.CompanyBranch_ID, oRawData.SIP_ID, ref iRecRow);
                                                iRecruitsEmployee += iRecRow;
                                            }
                                            else if (oEmp.DateConfirm.Date >= dtmStartDate.Date && oEmp.DateConfirm.Date <= dtmEndDate.Date)
                                            {
                                                dCasualTransfer += clsHelpMethods.GetTotalBasicSalaryAmt_CassualTransfer(oRawData.Company_ID, oRawData.CompanyBranch_ID, oRawData.SIP_ID, ref iCasRow);
                                                iCasualTransfer += iCasRow;
                                            }
                                            dIncrementEmp += clsHelpMethods.GetTotalIncrementAmt(oRawData.Company_ID, oRawData.CompanyBranch_ID, oRawData.SIP_ID, ref iIncRow);
                                            iIncrementEmp += iIncRow;
                                            #endregion
                                        }
                                    }
                                }

                                #region Formulas
                                dAddAmount = dRecruitsEmployeeBS + dCasualTransfer + dIncrementEmp;
                                dLessAmount = dResignedEmployeesBS;

                                dPrevAddAmount = dPrevRecruitsEmployeeBS + dPrevCasualTransfer + dPrevIncrement;
                                dPrevLessAmount = dPrevResignedEmployeesBS;

                                dActiveBS = dTotAmt + dResignedEmployeesBS + dTransfer - dIncrementEmp - dCasualTransfer - dRecruitsEmployeeBS;
                                dPrevActiveBS = dPrevTotAmt + dPrevResignedEmployeesBS + dPrevTransfer - dPrevIncrement - dPrevCasualTransfer - dPrevRecruitsEmployeeBS;

                                iActiveBS = iTotNoofHeads - iRecruitsEmployee + iResignedEmployees + iTransfer; //increments are already icluded in previous no of heads
                                iPrevActiveBS = iPrevTotNoofHeads - iPrevRecruitsEmployeeBS + iPrevResignedEmployeesBS + iPrevTransfer; //increments are already icluded in previous no of heads
                                #endregion

                                //add paramter column to dataset
                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("PreviousMonth", dtFromDate.ToString("MMMM"), true);
                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("CurrentMonth", dtToDate.ToString("MMMM"), true);

                                glb_dts_PAY.dt_PayrollSummary.Adddt_PayrollSummaryRow(iActiveBS, iRecruitsEmployee, iCasualTransfer, iIncrementEmp, iResignedEmployees * -1, iTransfer * -1,
                                    dActiveBS, dRecruitsEmployeeBS, dCasualTransfer, dIncrementEmp, dResignedEmployeesBS * -1, dTransfer * -1,
                                    iPrevActiveBS, iPrevRecruitsEmployeeBS, iPrevCasualTransfer, iPrevIncrement, iPrevResignedEmployeesBS * -1, iPrevTransfer * -1,
                                    dPrevActiveBS, dPrevRecruitsEmployeeBS, dPrevCasualTransfer, dPrevIncrement, dPrevResignedEmployeesBS * -1, dPrevTransfer * -1,
                                    iTotNoofHeads, dTotAmt, iPrevTotNoofHeads, dPrevTotAmt,
                                    dAddAmount, dLessAmount * -1, dPrevAddAmount, dPrevLessAmount * -1);

                                frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                                frmViewer.print(oReport.ReportPath, glb_dts_PAY, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                            }
                            else
                                SEACCMessageBox.Show("Oops....", " Please give a valid date period within two months", MessageBoxButton.OK, "Red");
                        }
                        #endregion

                        #region Payroll Detail
                        else if (Report == enum_ReportName.PayrollDetail)
                        {
                            DataSets.dts_PAY glb_dts_PAY = new DataSets.dts_PAY();

                            DateTime dtFromDate = dtmFromDate.AddMonths(-1);
                            DateTime dtToDate = dtmToDate;
                            int iNoOfMonths = ((dtToDate.Year - dtFromDate.Year) * 12) + dtToDate.Month - dtFromDate.Month; //dtToDate.Month - dtFromDate.Month;
                            string sEPF_No = "";
                            decimal dNetSalCash = 0, dNetSalCash_Prev = 0, dNetSalBank = 0, dNetSalBank_Prev = 0, dNetSalCheque = 0, dNetSalCheque_Prev = 0;
                            //string sEmp_ID = "", sPrevEmp_ID = "";
                            //int iSIP_ID = 0, iPrevSIP_ID = 0;
                            decimal testBasicPrev = 0, testBasic = 0;

                            bool bIsPrevious = false;
                            if (iNoOfMonths <= 1)
                            {
                                #region Company Data Set Fill
                                if (bDivisionSelected)
                                {
                                    CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                    glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, sctComDetails.sEPF_RegNo, sctComDetails.sETF_RegNo, sctComDetails.sPayee_RegNo, sctComDetails.sTax_IdentityNo, oReport.DisplayName, oReport.DisplayName2, dtFromDate.ToString("Y") + " - " + dtToDate.ToString("Y"), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                }
                                else
                                {
                                    tbl_genCompanyInfo oCompany = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
                                    glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oCompany.Epf_RegNo, oCompany.Etf_RegNo, oCompany.Payee_RegNo, oCompany.Tax_IdentityNo, oReport.DisplayName, oReport.DisplayName2, dtFromDate.ToString("Y") + " - " + dtToDate.ToString("Y"), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                                }
                                #endregion

                                for (int i = 0; i <= iNoOfMonths; i++)
                                {
                                    DateTime dtmStartDate = dtFromDate.AddMonths(i);
                                    DateTime dtmEndDate = dtmStartDate.AddMonths(1).AddDays(-1);

                                    List<tbl_payTxSIPRawData> oTxSIP_PayDataRows = tbl_payTxSIPRawData.SelectAllPeriods_ByDateRange(dtmStartDate.Date, dtmEndDate.Date).Where(r => r.IsPayslip_Print).ToList();

                                    #region Selected Filters
                                    if (bEmployeeSelected)
                                        oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.Employee_ID == txtEmployee.Tag.ToString()).ToList();
                                    if (bDivisionSelected)
                                        oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => vDivisions.Any(r2 => r2.Field<string>("id") == r.Division_ID)).ToList();
                                    if (bDepartmentSelected)
                                        oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.Department_ID == txtDepartment.Tag.ToString()).ToList();
                                    if (bSectionSelected)
                                        oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.SectionID == txtSection.Tag.ToString()).ToList();
                                    if (bSubSectionSelected)
                                        oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.SubSectionID == txtSubSection.Tag.ToString()).ToList();
                                    if (bDesignationSelected)
                                        oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.Designation_ID == txtDesignation.Tag.ToString()).ToList();
                                    if (bEmpCategory1Selected)
                                        oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();
                                    if (bEmpCategory2Selected)
                                        oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();
                                    if (bEmpCategory3Selected)
                                        oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();
                                    #endregion

                                    foreach (tbl_payTxSIPRawData oPayDataRow in oTxSIP_PayDataRows)
                                    {
                                        sEPF_No = (oPayDataRow.EpfNo == "" || oPayDataRow.EpfNo == "0") ? "-" : oPayDataRow.EpfNo.PadLeft(4, '0');

                                        tbl_genMasEmployee oEmp = tbl_genMasEmployee.Select(oPayDataRow.Employee_ID, clsSecurity.CompanyID, clsSecurity.BranchID);

                                        #region Previous Month
                                        if (i == 0)
                                        {
                                            if (oEmp.LastWorkingDate.Date <= dtmStartDate.Date && oEmp.LastWorkingDate.Date != clsConfig.defaultDateTime.Date)
                                                continue;

                                            bIsPrevious = true;

                                            List<tbl_payTxSIPRawData_PaySlipItems> oPayItems = tbl_payTxSIPRawData_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(oPayDataRow.Company_ID, oPayDataRow.CompanyBranch_ID, oPayDataRow.SIP_ID).OrderBy(o => o.LineNo).ToList();
                                            oPayItems.ForEach((oPayItem) => glb_dts_PAY.dt_EmpSalaryData_PayslipItems_Previous.Rows.Add(oPayItem.SIP_ID, oPayItem.PayItem_ID, (oPayItem.PayItem_ID), oPayItem.PayItem_Code, oPayItem.IsEarning, oPayItem.Amount, bIsPrevious));

                                            List<tbl_payTxSIPRawData_PaySlipItems_Statutary> oPayStats = tbl_payTxSIPRawData_PaySlipItems_Statutary.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(oPayDataRow.Company_ID, oPayDataRow.CompanyBranch_ID, oPayDataRow.SIP_ID).Where(r1 => oPayItems.Any(r2 => r2.Company_ID == r1.Company_ID && r2.CompanyBranch_ID == r1.CompanyBranch_ID && r2.SIP_ID == r1.SIP_ID && r2.PayItem_ID == r1.PayItem_ID)).ToList();
                                            oPayStats.ForEach((oPayStat) => glb_dts_PAY.dt_EmpSalaryData_PayslipItems_Statutatry_Previous.Rows.Add(oPayStat.SIP_ID, oPayStat.PayItem_ID, oPayStat.StatutaryPayItem_ID, oPayStat.Percentage, oPayStat.Amount, bIsPrevious));

                                            if (oPayDataRow.PaymentMethod_ID == clsConfig.sCashPaymentMethod)
                                                dNetSalCash_Prev += clsHelpMethods.GetNetSalary_FromTX(oPayDataRow.SIP_ID);
                                            else if (oPayDataRow.PaymentMethod_ID == clsConfig.sBankTranferMethod)
                                                dNetSalBank_Prev += clsHelpMethods.GetNetSalary_FromTX(oPayDataRow.SIP_ID);
                                            else if (oPayDataRow.PaymentMethod_ID == clsConfig.sChequePaymentMethod)
                                                dNetSalCheque_Prev += clsHelpMethods.GetNetSalary_FromTX(oPayDataRow.SIP_ID);
                                        }
                                        #endregion

                                        #region Current Month
                                        else
                                        {
                                            if (oEmp.LastWorkingDate.Date <= dtmStartDate.Date && oEmp.LastWorkingDate.Date != clsConfig.defaultDateTime.Date)
                                                continue;

                                            bIsPrevious = false;

                                            List<tbl_payTxSIPRawData_PaySlipItems> oPayItems = tbl_payTxSIPRawData_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(oPayDataRow.Company_ID, oPayDataRow.CompanyBranch_ID, oPayDataRow.SIP_ID).OrderBy(o => o.LineNo).ToList();
                                            oPayItems.ForEach((oPayItem) => glb_dts_PAY.dt_EmpSalaryData_PayslipItems_Previous.Rows.Add(oPayItem.SIP_ID, oPayItem.PayItem_ID, (oPayItem.PayItem_ID), oPayItem.PayItem_Code, oPayItem.IsEarning, oPayItem.Amount, bIsPrevious));

                                            List<tbl_payTxSIPRawData_PaySlipItems_Statutary> oPayStats = tbl_payTxSIPRawData_PaySlipItems_Statutary.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(oPayDataRow.Company_ID, oPayDataRow.CompanyBranch_ID, oPayDataRow.SIP_ID).Where(r1 => oPayItems.Any(r2 => r2.Company_ID == r1.Company_ID && r2.CompanyBranch_ID == r1.CompanyBranch_ID && r2.SIP_ID == r1.SIP_ID && r2.PayItem_ID == r1.PayItem_ID)).ToList();
                                            oPayStats.ForEach((oPayStat) => glb_dts_PAY.dt_EmpSalaryData_PayslipItems_Statutatry_Previous.Rows.Add(oPayStat.SIP_ID, oPayStat.PayItem_ID, oPayStat.StatutaryPayItem_ID, oPayStat.Percentage, oPayStat.Amount, bIsPrevious));

                                            if (oPayDataRow.PaymentMethod_ID == clsConfig.sCashPaymentMethod)
                                                dNetSalCash += clsHelpMethods.GetNetSalary_FromTX(oPayDataRow.SIP_ID);
                                            else if (oPayDataRow.PaymentMethod_ID == clsConfig.sBankTranferMethod)
                                                dNetSalBank += clsHelpMethods.GetNetSalary_FromTX(oPayDataRow.SIP_ID);
                                            else if (oPayDataRow.PaymentMethod_ID == clsConfig.sChequePaymentMethod)
                                                dNetSalCheque += clsHelpMethods.GetNetSalary_FromTX(oPayDataRow.SIP_ID);

                                        }
                                        #endregion

                                        glb_dts_PAY.dt_EmpSalaryData_Payroll.Adddt_EmpSalaryData_PayrollRow(oPayDataRow.Employee_ID, sEPF_No, clsRef_Name.get_EmployeeShortName(oPayDataRow.Employee_ID), oPayDataRow.SIP_ID.ToString(),
                                            oPayDataRow.Division_ID, clsRef_Name.get_Division_Name(oPayDataRow.Division_ID),
                                        oPayDataRow.Department_ID, clsRef_Name.get_Department_Name(oPayDataRow.Department_ID),
                                        oPayDataRow.SectionID, clsRef_Name.get_Section_Name(oPayDataRow.SectionID),
                                        oPayDataRow.SubSectionID, clsRef_Name.get_SubSection_Name(oPayDataRow.SubSectionID),
                                        oPayDataRow.EmpCatagory1_ID, clsRef_Name.get_EmployeeCategory1_Name(oPayDataRow.EmpCatagory1_ID),
                                        oPayDataRow.EmpCatagory2_ID, clsRef_Name.get_EmployeeCategory2_Name(oPayDataRow.EmpCatagory2_ID),
                                        oPayDataRow.EmpCatagory3_ID, clsRef_Name.get_EmployeeCategory3_Name(oPayDataRow.EmpCatagory3_ID),
                                        oPayDataRow.Designation_ID, clsRef_Name.get_Designation_Name(oPayDataRow.Designation_ID),
                                        oEmp.Emp_statusID, oEmp.LastWorkingDate.Date, oEmp.DateJoin.Date, 0, 0);
                                    }
                                }

                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("NetSalCash", clsHelpMethods.FormatDecimalPlaces_Price(dNetSalCash), true);
                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("NetSalCash_Prev", clsHelpMethods.FormatDecimalPlaces_Price(dNetSalCash_Prev), true);
                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("NetSalBank", clsHelpMethods.FormatDecimalPlaces_Price(dNetSalBank), true);
                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("NetSalBank_Prev", clsHelpMethods.FormatDecimalPlaces_Price(dNetSalBank_Prev), true);
                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("NetSalCheque", clsHelpMethods.FormatDecimalPlaces_Price(dNetSalCheque), true);
                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("NetSalCheque_Prev", clsHelpMethods.FormatDecimalPlaces_Price(dNetSalCheque_Prev), true);

                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("PreviousMonth", dtFromDate.ToString("MMMM"), true);
                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("CurrentMonth", dtToDate.ToString("MMMM"), true);


                                frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                                frmViewer.print(oReport.ReportPath, glb_dts_PAY, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                            }
                            else
                                SEACCMessageBox.Show("Oops....", " Please give a valid date period ", MessageBoxButton.OK, "Red");
                        }
                        #endregion

                        #region Payroll Summary Employee Category Wise
                        else if (Report == enum_ReportName.PayrollSummary_CategoryWise)
                        {
                            DataSets.dts_PAY glb_dts_PAY = new DataSets.dts_PAY();
                            string sEPF_No = "";

                            #region Company Data Set Fill
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, sctComDetails.sEPF_RegNo, sctComDetails.sETF_RegNo, sctComDetails.sPayee_RegNo, sctComDetails.sTax_IdentityNo, oReport.DisplayName, oReport.DisplayName2, dtmToDate.ToString("MMM/yyyy"), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                            {
                                tbl_genCompanyInfo oCompany = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
                                glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oCompany.Epf_RegNo, oCompany.Etf_RegNo, oCompany.Payee_RegNo, oCompany.Tax_IdentityNo, oReport.DisplayName, oReport.DisplayName2, dtmToDate.ToString("MMM/yyyy"), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            #endregion

                            List<tbl_payTxSIPRawData> oTxSIP_PayDataRows = tbl_payTxSIPRawData.SelectAllPeriods_ByDateRange(dtmFromDate.Date, dtmToDate.Date).Where(r => r.IsPayslip_Print).ToList();

                            #region Selected Filters
                            if (bEmployeeSelected)
                                oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.Employee_ID == txtEmployee.Tag.ToString()).ToList();
                            if (bDivisionSelected)
                                oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => vDivisions.Any(r2 => r2.Field<string>("id") == r.Division_ID)).ToList();
                            if (bDepartmentSelected)
                                oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.Department_ID == txtDepartment.Tag.ToString()).ToList();
                            if (bSectionSelected)
                                oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.SectionID == txtSection.Tag.ToString()).ToList();
                            if (bSubSectionSelected)
                                oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.SubSectionID == txtSubSection.Tag.ToString()).ToList();
                            if (bDesignationSelected)
                                oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.Designation_ID == txtDesignation.Tag.ToString()).ToList();
                            if (bEmpCategory1Selected)
                                oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();
                            if (bEmpCategory2Selected)
                                oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();
                            if (bEmpCategory3Selected)
                                oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();
                            #endregion

                            foreach (tbl_payTxSIPRawData oPayDataRow in oTxSIP_PayDataRows)
                            {
                                sEPF_No = (oPayDataRow.EpfNo == "" || oPayDataRow.EpfNo == "0") ? "-" : oPayDataRow.EpfNo.PadLeft(4, '0');

                                tbl_genMasEmployee oEmp = tbl_genMasEmployee.Select(oPayDataRow.Employee_ID, clsSecurity.CompanyID, clsSecurity.BranchID);
                                if (oEmp.LastWorkingDate.Date <= dtmFromDate.Date && oEmp.LastWorkingDate.Date != clsConfig.defaultDateTime.Date)
                                    continue;

                                glb_dts_PAY.dt_EmpSalaryData_Payroll.Adddt_EmpSalaryData_PayrollRow(oPayDataRow.Employee_ID, sEPF_No, clsRef_Name.get_EmployeeShortName(oPayDataRow.Employee_ID), oPayDataRow.SIP_ID.ToString(),
                                        oPayDataRow.Division_ID, clsRef_Name.get_Division_Name(oPayDataRow.Division_ID),
                                        oPayDataRow.Department_ID, clsRef_Name.get_Department_Name(oPayDataRow.Department_ID),
                                        oPayDataRow.SectionID, clsRef_Name.get_Section_Name(oPayDataRow.SectionID),
                                        oPayDataRow.SubSectionID, clsRef_Name.get_SubSection_Name(oPayDataRow.SubSectionID),
                                        oPayDataRow.EmpCatagory1_ID, clsRef_Name.get_EmployeeCategory1_Name(oPayDataRow.EmpCatagory1_ID),
                                        oPayDataRow.EmpCatagory2_ID, clsRef_Name.get_EmployeeCategory2_Name(oPayDataRow.EmpCatagory2_ID),
                                        oPayDataRow.EmpCatagory3_ID, clsRef_Name.get_EmployeeCategory3_Name(oPayDataRow.EmpCatagory3_ID),
                                        oPayDataRow.Designation_ID, clsRef_Name.get_Designation_Name(oPayDataRow.Designation_ID),
                                        oEmp.Emp_statusID, oEmp.LastWorkingDate.Date, oEmp.DateJoin.Date, 0, 0);

                                List<tbl_payTxSIPRawData_PaySlipItems> oPayItems = tbl_payTxSIPRawData_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(oPayDataRow.Company_ID, oPayDataRow.CompanyBranch_ID, oPayDataRow.SIP_ID).OrderBy(o => o.LineNo).ToList();
                                oPayItems.ForEach((oPayItem) => glb_dts_PAY.dt_EmpSalaryData_PayslipItems_Previous.Rows.Add(oPayItem.SIP_ID, oPayItem.PayItem_ID, (oPayItem.PayItem_ID), oPayItem.PayItem_Code, oPayItem.IsEarning, oPayItem.Amount, false));

                                List<tbl_payTxSIPRawData_PaySlipItems_Statutary> oPayStats = tbl_payTxSIPRawData_PaySlipItems_Statutary.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(oPayDataRow.Company_ID, oPayDataRow.CompanyBranch_ID, oPayDataRow.SIP_ID).Where(r1 => oPayItems.Any(r2 => r2.Company_ID == r1.Company_ID && r2.CompanyBranch_ID == r1.CompanyBranch_ID && r2.SIP_ID == r1.SIP_ID && r2.PayItem_ID == r1.PayItem_ID)).ToList();
                                oPayStats.ForEach((oPayStat) => glb_dts_PAY.dt_EmpSalaryData_PayslipItems_Statutatry_Previous.Rows.Add(oPayStat.SIP_ID, oPayStat.PayItem_ID, oPayStat.StatutaryPayItem_ID, oPayStat.Percentage, oPayStat.Amount, false));
                            }

                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_PAY, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }
                        #endregion

                        #region Payroll Detail Resign and New Employee Wise
                        else if (Report == enum_ReportName.PayrollDetail_ResignNewEmployeeWise)
                        {
                            DataSets.dts_PAY glb_dts_PAY = new DataSets.dts_PAY();
                            string sEPF_No = "";

                            #region Company Data Set Fill
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, sctComDetails.sEPF_RegNo, sctComDetails.sETF_RegNo, sctComDetails.sPayee_RegNo, sctComDetails.sTax_IdentityNo, oReport.DisplayName, oReport.DisplayName2, dtmToDate.ToString("MMM/yyyy"), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                            {
                                tbl_genCompanyInfo oCompany = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
                                glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oCompany.Epf_RegNo, oCompany.Etf_RegNo, oCompany.Payee_RegNo, oCompany.Tax_IdentityNo, oReport.DisplayName, oReport.DisplayName2, dtmToDate.ToString("MMM/yyyy"), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            #endregion

                            List<tbl_payTxSIPRawData> oTxSIP_PayDataRows = tbl_payTxSIPRawData.SelectAllPeriods_ByDateRange(dtmFromDate.Date, dtmToDate.Date).Where(r => r.IsPayslip_Print).ToList();

                            #region Selected Filters
                            if (bEmployeeSelected)
                                oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.Employee_ID == txtEmployee.Tag.ToString()).ToList();
                            if (bDivisionSelected)
                                oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => vDivisions.Any(r2 => r2.Field<string>("id") == r.Division_ID)).ToList();
                            if (bDepartmentSelected)
                                oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.Department_ID == txtDepartment.Tag.ToString()).ToList();
                            if (bSectionSelected)
                                oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.SectionID == txtSection.Tag.ToString()).ToList();
                            if (bSubSectionSelected)
                                oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.SubSectionID == txtSubSection.Tag.ToString()).ToList();
                            if (bDesignationSelected)
                                oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.Designation_ID == txtDesignation.Tag.ToString()).ToList();
                            if (bEmpCategory1Selected)
                                oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();
                            if (bEmpCategory2Selected)
                                oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();
                            if (bEmpCategory3Selected)
                                oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();
                            #endregion

                            foreach (tbl_payTxSIPRawData oPayDataRow in oTxSIP_PayDataRows)
                            {
                                sEPF_No = (oPayDataRow.EpfNo == "" || oPayDataRow.EpfNo == "0") ? "-" : oPayDataRow.EpfNo.PadLeft(4, '0');

                                tbl_genMasEmployee oEmp = tbl_genMasEmployee.Select(oPayDataRow.Employee_ID, clsSecurity.CompanyID, clsSecurity.BranchID);
                                glb_dts_PAY.dt_EmpSalaryData_Payroll.Adddt_EmpSalaryData_PayrollRow(oPayDataRow.Employee_ID, sEPF_No, clsRef_Name.get_EmployeeShortName(oPayDataRow.Employee_ID), oPayDataRow.SIP_ID.ToString(),
                                        oPayDataRow.Division_ID, clsRef_Name.get_Division_Name(oPayDataRow.Division_ID),
                                        oPayDataRow.Department_ID, clsRef_Name.get_Department_Name(oPayDataRow.Department_ID),
                                        oPayDataRow.SectionID, clsRef_Name.get_Section_Name(oPayDataRow.SectionID),
                                        oPayDataRow.SubSectionID, clsRef_Name.get_SubSection_Name(oPayDataRow.SubSectionID),
                                        oPayDataRow.EmpCatagory1_ID, clsRef_Name.get_EmployeeCategory1_Name(oPayDataRow.EmpCatagory1_ID),
                                        oPayDataRow.EmpCatagory2_ID, clsRef_Name.get_EmployeeCategory2_Name(oPayDataRow.EmpCatagory2_ID),
                                        oPayDataRow.EmpCatagory3_ID, clsRef_Name.get_EmployeeCategory3_Name(oPayDataRow.EmpCatagory3_ID),
                                        oPayDataRow.Designation_ID, clsRef_Name.get_Designation_Name(oPayDataRow.Designation_ID),
                                        oEmp.Emp_statusID, oEmp.LastWorkingDate.Date, oEmp.DateJoin.Date, 0, 0);

                                List<tbl_payTxSIPRawData_PaySlipItems> oPayItems = tbl_payTxSIPRawData_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(oPayDataRow.Company_ID, oPayDataRow.CompanyBranch_ID, oPayDataRow.SIP_ID).OrderBy(o => o.LineNo).ToList();
                                oPayItems.ForEach((oPayItem) => glb_dts_PAY.dt_EmpSalaryData_PayslipItems.Rows.Add(oPayItem.SIP_ID, oPayItem.PayItem_ID, (oPayItem.PayItem_ID), oPayItem.PayItem_Code, oPayItem.IsEarning, oPayItem.Amount));

                                List<tbl_payTxSIPRawData_PaySlipItems_Statutary> oPayStats = tbl_payTxSIPRawData_PaySlipItems_Statutary.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(oPayDataRow.Company_ID, oPayDataRow.CompanyBranch_ID, oPayDataRow.SIP_ID).Where(r1 => oPayItems.Any(r2 => r2.Company_ID == r1.Company_ID && r2.CompanyBranch_ID == r1.CompanyBranch_ID && r2.SIP_ID == r1.SIP_ID && r2.PayItem_ID == r1.PayItem_ID)).ToList();
                                oPayStats.ForEach((oPayStat) => glb_dts_PAY.dt_EmpSalaryData_PayslipItems_Statutatry.Rows.Add(oPayStat.SIP_ID, oPayStat.PayItem_ID, oPayStat.StatutaryPayItem_ID, oPayStat.Percentage, oPayStat.Amount));

                            }

                            glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("FromDate", dtmFromDate.Date.ToString(), true);
                            glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("ToDate", dtmToDate.Date.ToString(), true);


                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_PAY, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }
                        #endregion

                        #region Signature Sheet Salary Payable
                        else if (Report == enum_ReportName.SignatureSheet_SalaryPayable)
                        {
                            DataSets.dts_PAY glb_dts_PAY = new DataSets.dts_PAY();
                            glb_dts_PAY.dt_EmpSalaryData.Clear();
                            glb_dts_PAY.dt_EmpSalaryData_PayslipItems.Clear();

                            #region Company Data Set Fill
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, sctComDetails.sEPF_RegNo, sctComDetails.sETF_RegNo, sctComDetails.sPayee_RegNo, sctComDetails.sTax_IdentityNo, oReport.DisplayName, oReport.DisplayName2, dtmFromDate.ToString("Y"), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                            {
                                tbl_genCompanyInfo oCompany = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
                                glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oCompany.Epf_RegNo, oCompany.Etf_RegNo, oCompany.Payee_RegNo, oCompany.Tax_IdentityNo, oReport.DisplayName, oReport.DisplayName2, dtmFromDate.ToString("Y"), clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            #endregion

                            List<tbl_payTxSIPRawData> oRawDataList = tbl_payTxSIPRawData.SelectAllPeriods_ByDateRange(dtmFromDate.Date, dtmToDate.Date).Where(r => r.IsPayslip_Print).ToList();

                            #region Filters
                            if (bEmployeeSelected)
                                oRawDataList = oRawDataList.Where(r => r.Employee_ID == txtEmployee.Tag.ToString()).ToList();
                            if (bDesignationSelected)
                                oRawDataList = oRawDataList.Where(p => p.Designation_ID == txtDesignation.Tag.ToString()).ToList();
                            if (bDivisionSelected)
                                oRawDataList = oRawDataList.Where(r => vDivisions.Any(r2 => r2.Field<string>("id") == r.Division_ID)).ToList();
                            if (bDepartmentSelected)
                                oRawDataList = oRawDataList.Where(p => p.Department_ID == txtDepartment.Tag.ToString()).ToList();
                            if (bSectionSelected)
                                oRawDataList = oRawDataList.Where(p => p.SectionID == txtSection.Tag.ToString()).ToList();
                            if (bSubSectionSelected)
                                oRawDataList = oRawDataList.Where(p => p.SubSectionID == txtSubSection.Tag.ToString()).ToList();
                            if (bEmpCategory1Selected)
                                oRawDataList = oRawDataList.Where(p => p.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();
                            if (bEmpCategory2Selected)
                                oRawDataList = oRawDataList.Where(p => p.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();
                            if (bEmpCategory3Selected)
                                oRawDataList = oRawDataList.Where(p => p.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();
                            if (bPayPeriodSelected)
                                oRawDataList = oRawDataList.Where(r => r.ProcessGroup_ID == txtPayPeriod.Uid && r.ProcessPeriod_ID == int.Parse(txtPayPeriod.ToolTip.ToString()) && r.ProcessPeriod_Sub_ID == int.Parse(txtPayPeriod.Tag.ToString())).ToList();

                            #endregion

                            foreach (tbl_payTxSIPRawData oPayDataRow in oRawDataList)
                            {
                                decimal dNetSalary = 0;
                                string sEPF_No = (oPayDataRow.EpfNo == "" || oPayDataRow.EpfNo == "0") ? "-" : oPayDataRow.EpfNo.PadLeft(4, '0');
                                tbl_genMasEmployee oEmp = tbl_genMasEmployee.Select(oPayDataRow.Employee_ID, oPayDataRow.Company_ID, oPayDataRow.CompanyBranch_ID);
                                if (oEmp.LastWorkingDate.Date <= dtmFromDate.Date && oEmp.LastWorkingDate.Date != clsConfig.defaultDateTime.Date)
                                    continue;

                                dNetSalary = clsHelpMethods.GetNetSalary_FromTX(oPayDataRow.SIP_ID);
                                glb_dts_PAY.dt_EmpSalaryData_Payroll.Adddt_EmpSalaryData_PayrollRow(oPayDataRow.Employee_ID, sEPF_No,
                                    clsRef_Name.get_EmployeeShortName(oPayDataRow.Employee_ID), oPayDataRow.SIP_ID.ToString(),
                                    oPayDataRow.Division_ID, clsRef_Name.get_Division_Name(oPayDataRow.Division_ID),
                                        oPayDataRow.Department_ID, clsRef_Name.get_Department_Name(oPayDataRow.Department_ID),
                                        oPayDataRow.SectionID, clsRef_Name.get_Section_Name(oPayDataRow.SectionID),
                                        oPayDataRow.SubSectionID, clsRef_Name.get_SubSection_Name(oPayDataRow.SubSectionID),
                                        oPayDataRow.EmpCatagory1_ID, clsRef_Name.get_EmployeeCategory1_Name(oPayDataRow.EmpCatagory1_ID),
                                        oPayDataRow.EmpCatagory2_ID, clsRef_Name.get_EmployeeCategory2_Name(oPayDataRow.EmpCatagory2_ID),
                                        oPayDataRow.EmpCatagory3_ID, clsRef_Name.get_EmployeeCategory3_Name(oPayDataRow.EmpCatagory3_ID),
                                        oPayDataRow.Designation_ID, clsRef_Name.get_Designation_Name(oPayDataRow.Designation_ID),
                                        "", oEmp.LastWorkingDate.Date, oEmp.DateJoin, 0, dNetSalary);

                            }

                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_PAY, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }
                        #endregion


                        #region R&D Excel Report Generation - Gayan
                        //else if (iReportID == 10000)
                        //{
                        //    //Set the output directory to the SampleApp folder where the app is running from. 
                        //    cls_ReportUtils.OutputDir = new DirectoryInfo($"{AppDomain.CurrentDomain.BaseDirectory}SampleApp");
                        //    cls_SalaryRegister.Run_SalaryRegister_New(dtp_FromDate.GetDateTime(), dtp_ToDate.GetDateTime());
                        //}
                        #endregion

                        #region Other Payroll Reports
                        else if (oFunction.FunctionCategory_ID == "FCAT/070")
                        {
                            DataSets.dts_PAY glb_dts_PAY = new DataSets.dts_PAY();
                            #region Fill Company Data
                            if (bDivisionSelected)
                            {
                                CompanyDetails sctComDetails = clsCommon.getCompanyDetail_FromDivision(txtDivision.Tag.ToString());
                                glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sctComDetails.sCompanyName, sctComDetails.sAddress1, sctComDetails.sAddress2, sctComDetails.bCompanyImage, sctComDetails.sEPF_RegNo, sctComDetails.sETF_RegNo, sctComDetails.sPayee_RegNo, sctComDetails.sTax_IdentityNo, oReport.DisplayName, oReport.DisplayName2,
                                     dtmFromDate.ToString("Y"),//"For the period : " + dtmFromDate.ToString(clsConfig.Format_Date2) + " to " + dtmToDate.ToString(clsConfig.Format_Date2),
                                    clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            else
                            {
                                tbl_genCompanyInfo oCompany = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
                                glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oCompany.Epf_RegNo, oCompany.Etf_RegNo, oCompany.Payee_RegNo, oCompany.Tax_IdentityNo, oReport.DisplayName, oReport.DisplayName2
                                                      , dtmFromDate.ToString("Y") //"For the period : " + dtmFromDate.ToString(clsConfig.Format_Date2) + " to " + dtmToDate.ToString(clsConfig.Format_Date2) 
                                                      , clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);
                            }
                            #endregion

                            #region OLD METHOD
                            if ((clsConfig.bPayrollReports_OldMethodActive &&
                                Report != enum_ReportName.ETF_R1_Form &&
                                Report != enum_ReportName.PayslipItemAmount_SignatureSheet &&
                                Report != enum_ReportName.PayslipItemAmount_EmployeeWise) || Report == enum_ReportName.EPF_ETFSheet)
                            {
                                List<tbl_payTxSIPRawData> oTxRawDataRecords;
                                if (Report == enum_ReportName.EPF_ETFSheet)
                                    oTxRawDataRecords = tbl_payTxSIPRawData.SelectAllPeriods_ByDateRange(dtmFromDate.Date, dtmToDate.Date).Where(r => r.IsPayslip_Print).ToList();
                                else
                                    oTxRawDataRecords = tbl_payTxSIPRawData.SelectPeriod_ByDateRange(dtmFromDate.Date, dtmToDate.Date).Where(r => r.IsPayslip_Print).ToList();

                                #region Selected Filters
                                if (bEmployeeSelected)
                                    oTxRawDataRecords = oTxRawDataRecords.Where(r => r.Employee_ID == txtEmployee.Tag.ToString()).ToList();
                                if (bDivisionSelected)
                                    oTxRawDataRecords = oTxRawDataRecords.Where(r => vDivisions.Any(r2 => r2.Field<string>("id") == r.Division_ID)).ToList();
                                if (bDepartmentSelected)
                                    oTxRawDataRecords = oTxRawDataRecords.Where(r => r.Department_ID == txtDepartment.Tag.ToString()).ToList();
                                if (bSectionSelected)
                                    oTxRawDataRecords = oTxRawDataRecords.Where(r => r.SectionID == txtSection.Tag.ToString()).ToList();
                                if (bSubSectionSelected)
                                    oTxRawDataRecords = oTxRawDataRecords.Where(r => r.SubSectionID == txtSubSection.Tag.ToString()).ToList();
                                if (bDesignationSelected)
                                    oTxRawDataRecords = oTxRawDataRecords.Where(r => r.Designation_ID == txtDesignation.Tag.ToString()).ToList();
                                if (bEmpCategory1Selected)
                                    oTxRawDataRecords = oTxRawDataRecords.Where(r => r.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();
                                if (bEmpCategory2Selected)
                                    oTxRawDataRecords = oTxRawDataRecords.Where(r => r.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();
                                if (bEmpCategory3Selected)
                                    oTxRawDataRecords = oTxRawDataRecords.Where(r => r.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();
                                if (bPayPeriodSelected)
                                    oTxRawDataRecords = oTxRawDataRecords.Where(r => r.ProcessGroup_ID == txtPayPeriod.Uid && r.ProcessPeriod_ID == int.Parse(txtPayPeriod.ToolTip.ToString()) && r.ProcessPeriod_Sub_ID == int.Parse(txtPayPeriod.Tag.ToString())).ToList();
                                if (bPaymentMethodSelected)
                                    oTxRawDataRecords = oTxRawDataRecords.Where(r => r.PaymentMethod_ID == txtPayementMethodBy.Tag.ToString()).ToList();
                                #endregion

                                string sEPF_No = "-";
                                if (oTxRawDataRecords.Count > 0)
                                    foreach (tbl_payTxSIPRawData oTxPayRawRecord in oTxRawDataRecords.OrderBy(o => o.EpfNo.PadLeft(4, '0')))
                                    {
                                        if (oTxPayRawRecord != null)
                                        {
                                            sEPF_No = (oTxPayRawRecord.EpfNo == "" || oTxPayRawRecord.EpfNo == "0") ? "-" : oTxPayRawRecord.EpfNo.PadLeft(4, '0');

                                            tbl_payMas_ProcessPeriod_Sub oPayroll_Period = tbl_payMas_ProcessPeriod_Sub.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oTxPayRawRecord.ProcessGroup_ID, oTxPayRawRecord.ProcessPeriod_ID, oTxPayRawRecord.ProcessPeriod_Sub_ID);
                                            glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("Draft", "DRAFT", !oPayroll_Period.IsClosedPeriod);
                                            if (!oPayroll_Period.IsClosedPeriod && Report == enum_ReportName.EmployeePayslip)
                                                continue;

                                            #region Filters
                                            if (Report == enum_ReportName.SalaryBankTranfer)
                                                if (oTxPayRawRecord.PaymentMethod_ID != clsConfig.sBankTranferMethod)
                                                    continue;
                                            #endregion

                                            tbl_securityParollGroup_UserPermission oGrpPermission = tbl_securityParollGroup_UserPermission.Select(clsSecurity.CompanyID, clsSecurity.BranchID, clsSecurity.UserIDLoged, oTxPayRawRecord.ProcessGroup_ID);
                                            if (oGrpPermission != null && oGrpPermission.AllowView)
                                            {
                                                #region Variables - Salary Items , Rates
                                                decimal dBasicSalary = 0, dIncrement1 = 0, dAjustment_Amount = 0, dNoPayAmt = 0, dLateAmt = 0, dBRA1 = 0, dBRA2 = 0, dBRA3 = 0,
                                                        dOT_Normal = 0, dOT_Double = 0, dOT_Triple = 0, dAttendance = 0,
                                                        dSavings = 0, dAdvances = 0, dLoan = 0, dPAYE = 0,
                                                        dEPF_Pct_8 = 0, dEPF_Pct_12 = 0, dETF_Pct_3 = 0, dEPF_Pct_20 = 0,
                                                        dAllowance1 = 0, dIncrementAllowance = 0, dSlugRemoveAllowance = 0, dFoodAllowance = 0, dTeaMakingAllowance = 0, dMobileAllowance = 0, dTeleAllowance = 0, dBordingAllowance = 0, dHeatingAllowance = 0, dNightAllowance = 0,

                                                        //--------Hero-Nature--------
                                                        dCoconutAllowance = 0, dCoconutLoardingAllowance = 0, dLineLeaderAllowance = 0, dFilterClothAllowance = 0,
                                                        dCleaningsalary = 0, dShellRemovingAllowance = 0, dTravellingallowance = 0, dStroresAllowance = 0, dDryrerAllowance = 0,

                                                        dAllowance1_Deduction = 0, dIncrementAllowance_Deduction = 0, dTeaMakingAllowance_Deduction = 0, dBordingAllowance_Deduction = 0,

                                                        //--------Hero-Nature--------
                                                        dCoconutAllowance_Deduction = 0, dStoresallowance_Deduction = 0, dDryrerAllowance_Deduction = 0,

                                                        dNoOfWorkingHrs = 0, dEPF_Salary = 0;
                                                #endregion

                                                List<tbl_payTxSIPRawData_PaySlipItems> oData_payslipItems = tbl_payTxSIPRawData_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(clsSecurity.CompanyID, clsSecurity.BranchID, oTxPayRawRecord.SIP_ID);
                                                if (Report == enum_ReportName.SalaryRegisterReport || Report == enum_ReportName.EPF_ETFSheet || Report == enum_ReportName.EmployeePayslip || Report == enum_ReportName.SalaryDenomination || Report == enum_ReportName.SalaryBankTranfer || Report == enum_ReportName.TotalEarningsLabour || Report == enum_ReportName.SalaryIncrementReport || Report == enum_ReportName.PaidEmployeeList)
                                                {
                                                    #region Assign Payslip Item Amount
                                                    foreach (tbl_payTxSIPRawData_PaySlipItems oData_payslipItem in oData_payslipItems)
                                                    {

                                                        string sSalaryItem_configs = oData_payslipItem.PayItem_ID;
                                                        if (sSalaryItem_configs == clsConfig.sBasicSalary)
                                                        {
                                                            dBasicSalary = oData_payslipItem.Amount;//HeroZIP, HeroHNP, PPS
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sBasicSalaryIncrement1)
                                                        {
                                                            dIncrement1 = oData_payslipItem.Amount;
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sBRA1)
                                                        {
                                                            dBRA1 = oData_payslipItem.Amount;  //HeroZIP, HeroHNP, PPS
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sBRA2)
                                                        {
                                                            dBRA2 = oData_payslipItem.Amount; //HeroZIP, HeroHNP, PPS
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sBRA3)
                                                        {
                                                            dBRA3 = oData_payslipItem.Amount; //HeroZIP, HeroHNP
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sNopay)
                                                        {
                                                            dNoPayAmt = oData_payslipItem.Amount; //HeroZIP, HeroHNP, PPS
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sLate)
                                                        {
                                                            dLateAmt = oData_payslipItem.Amount; //HeroZIP, HeroHNP
                                                        }

                                                        else if (sSalaryItem_configs == clsConfig.sAttendance)
                                                        {
                                                            dAttendance = oData_payslipItem.Amount; //HeroZIP, HeroHNP, PPS 
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sOT_Normal)
                                                        {
                                                            dOT_Normal = oData_payslipItem.Amount; //HeroZIP, HeroHNP, PPS
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sOT_Double)
                                                        {
                                                            dOT_Double = oData_payslipItem.Amount; //HeroZIP, HeroHNP, PPS
                                                        }

                                                        else if (sSalaryItem_configs == clsConfig.sSaving)
                                                        {
                                                            dSavings = oData_payslipItem.Amount;  //HeroZIP, HeroHNP
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sAdvance)
                                                        {
                                                            dAdvances = oData_payslipItem.Amount; //HeroZIP, HeroHNP, PPS
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sLoan)
                                                        {
                                                            dLoan = oData_payslipItem.Amount;//HeroZIP, HeroHNP, PPS
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sPAYE)
                                                        {
                                                            dPAYE = oData_payslipItem.Amount; //HeroZIP, HeroHNP
                                                        }
                                                    }
                                                    #endregion

                                                    //dBasicSalary = clsHelpMethods.GetGivenAllowance_FromMas("empId", clsConfig.sBasicSalary); //HeroZIP, HeroHNP, PPS
                                                    //dIncrement1 = clsHelpMethods.GetPayItemAmount_FromTX(oTxPayRawRecord.SIP_ID, clsConfig.sIncrement1);
                                                    decimal dGross_Amount = dBasicSalary + dIncrement1 + dAjustment_Amount + dBRA1 + dBRA2 + dBRA3 + dNoPayAmt + dLateAmt;//HeroZIP, HeroHNP, PPS
                                                    decimal dTotEarn = dOT_Normal + dOT_Double + dOT_Triple + dAttendance;
                                                    dEPF_Pct_8 = clsHelpMethods.GetStatutaryItemAmount_FromTx(oTxPayRawRecord.SIP_ID, clsConfig.sEPF_Employee); //HeroZIP, HeroHNP, PPS
                                                    decimal dTotDeduction = dSavings + dAdvances - dEPF_Pct_8 + dLoan + dPAYE; //HeroZIP, HeroHNP, PPS
                                                    decimal dSalary_Payable = dGross_Amount + dTotEarn + dTotDeduction; //HeroZIP, HeroHNP
                                                    dEPF_Pct_12 = clsHelpMethods.GetStatutaryItemAmount_FromTx(oTxPayRawRecord.SIP_ID, clsConfig.sEPF_Company); //HeroZIP, HeroHNP, PPS
                                                    dETF_Pct_3 = clsHelpMethods.GetStatutaryItemAmount_FromTx(oTxPayRawRecord.SIP_ID, clsConfig.sETF); //HeroZIP, HeroHNP, PPS
                                                    dEPF_Pct_20 = dEPF_Pct_12 + dEPF_Pct_8;

                                                    dNoOfWorkingHrs = oTxPayRawRecord.WorkingMinutesAct_Nomal / 60; //HeroZIP, HeroHNP
                                                    dEPF_Salary = clsHelpMethods.GetTotAmountRegrdingStatutoryItem_FromTx(oTxPayRawRecord.SIP_ID, clsConfig.sEPF_Employee); //HeroZIP, HeroHNP, PPS

                                                    decimal dOT_Normal_Rate = 0;
                                                    if (oTxPayRawRecord.DivRate_OT > 0)
                                                        dOT_Normal_Rate = clsHelpMethods.GetBaseSalary_FromMas(oTxPayRawRecord.Employee_ID) * oTxPayRawRecord.BaseRate_OT / oTxPayRawRecord.DivRate_OT;

                                                    decimal dOT_Double_Rate = 0;
                                                    if (oTxPayRawRecord.DivRate_DOT > 0)
                                                        dOT_Double_Rate = clsHelpMethods.GetBaseSalary_FromMas(oTxPayRawRecord.Employee_ID) * oTxPayRawRecord.BaseRate_DOT / oTxPayRawRecord.DivRate_DOT;

                                                    decimal dOT_Triple_Rate = 0;
                                                    if (oTxPayRawRecord.DivRate_TOT > 0)
                                                        dOT_Triple_Rate = clsHelpMethods.GetBaseSalary_FromMas(oTxPayRawRecord.Employee_ID) * oTxPayRawRecord.BaseRate_TOT / oTxPayRawRecord.DivRate_TOT;




                                                    glb_dts_PAY.dt_Wages.Adddt_WagesRow(oTxPayRawRecord.Employee_ID, clsRef_Name.get_EmployeeShortName_initialsFirst(oTxPayRawRecord.Employee_ID), clsRef_Name.get_Designation_Name(oTxPayRawRecord.Designation_ID), oTxPayRawRecord.NicNo, clsRef_Name.get_PayemntMethode_Name(oTxPayRawRecord.PaymentMethod_ID),
                                                        clsRef_Name.get_Bank_Name(oTxPayRawRecord.Bank_ID), clsRef_Name.get_BankBranch_Name(oTxPayRawRecord.BankBranch_ID), oTxPayRawRecord.Bank_AccNo,
                                                        oTxPayRawRecord.IsEPF_ETF_Process, sEPF_No, oTxPayRawRecord.Is_PayeeProcess, "-", oTxPayRawRecord.EmpDateConfirmed.Date, oTxPayRawRecord.Division_ID, clsRef_Name.get_Division_Name(oTxPayRawRecord.Division_ID), oTxPayRawRecord.Department_ID, clsRef_Name.get_Department_Name(oTxPayRawRecord.Department_ID),
                                                        oTxPayRawRecord.EmpCatagory1_ID, clsRef_Name.get_EmployeeCategory1_Name(oTxPayRawRecord.EmpCatagory1_ID), oTxPayRawRecord.EmpCatagory2_ID, clsRef_Name.get_EmployeeCategory2_Name(oTxPayRawRecord.EmpCatagory2_ID), oTxPayRawRecord.ProcessGroup_ID, clsRef_Name.get_processGroup_Name(oTxPayRawRecord.ProcessGroup_ID),
                                                        dBasicSalary, dIncrement1, dAjustment_Amount, dBRA1, dBRA2, dBRA3, oTxPayRawRecord.NoPayMinutes / 60, dNoPayAmt * -1, oTxPayRawRecord.LateMinutes / 60, dLateAmt * -1,
                                                        (dGross_Amount >= 0 ? dGross_Amount : 0), dAttendance, dOT_Normal_Rate, oTxPayRawRecord.WorkingMinutesAct_OT / 60, dOT_Normal, dOT_Double_Rate, oTxPayRawRecord.WorkingMinutesAct_OT_Dub / 60, dOT_Double, dOT_Triple_Rate, oTxPayRawRecord.WorkingMinutesAct_OT_Trpl / 60, dOT_Triple,
                                                        (dTotEarn >= 0 ? dTotEarn : 0), (dEPF_Pct_8 >= 0 ? dEPF_Pct_8 : 0), dSavings * -1, dAdvances * -1, dLoan * -1, dPAYE * -1,
                                                        (dTotDeduction * -1), (dSalary_Payable >= 0 ? dSalary_Payable : 0),
                                                        (dEPF_Pct_12 >= 0 ? dEPF_Pct_12 : 0), (dETF_Pct_3 >= 0 ? dETF_Pct_3 : 0), (dEPF_Pct_20 >= 0 ? dEPF_Pct_20 : 0),
                                                        (dEPF_Salary >= 0 ? dEPF_Salary : 0), dNoOfWorkingHrs,
                                                        oTxPayRawRecord.ProcessPeriod_Sub_startDate, oTxPayRawRecord.ProcessPeriod_Sub_endDate);

                                                    #region Salary Denomination Report Only
                                                    if (Report == enum_ReportName.SalaryDenomination)
                                                        if (oTxPayRawRecord.PaymentMethod_ID.Trim() == clsConfig.sCashPaymentMethod.Trim() || oTxPayRawRecord.PaymentMethod_ID.ToLower() == "default")
                                                        {
                                                            decimal[] odeno;
                                                            odeno = GetDenomination((dSalary_Payable >= 0 ? dSalary_Payable : 0));
                                                            glb_dts_PAY.dt_Denomination.Adddt_DenominationRow(oTxPayRawRecord.Employee_ID, odeno[0], odeno[1], odeno[2], odeno[3], odeno[4], odeno[5], odeno[6], odeno[7], odeno[8], odeno[9], odeno[10], odeno[11]);
                                                        }
                                                    #endregion
                                                }

                                                if (Report == enum_ReportName.AllowanceSheet || Report == enum_ReportName.SalaryDenomination_Allowance || Report == enum_ReportName.TotalEarningsLabour || Report == enum_ReportName.SalaryIncrementReport || Report == enum_ReportName.EmployeePayslip)
                                                {
                                                    #region Assign Payslip Item Amounts
                                                    foreach (tbl_payTxSIPRawData_PaySlipItems oData_payslipItem in oData_payslipItems)
                                                    {
                                                        string sSalaryItem_configs = oData_payslipItem.PayItem_ID;
                                                        if (sSalaryItem_configs == clsConfig.sAllowance1)
                                                        {
                                                            dAllowance1 = oData_payslipItem.Amount; //HeroZIP, HeroHNP
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sIncrementAllowance)
                                                        {
                                                            dIncrementAllowance = oData_payslipItem.Amount; //HeroZIP, HeroHNP
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sFoodAllowance)
                                                        {
                                                            dFoodAllowance = oData_payslipItem.Amount; //HeroZIP, HeroHNP
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sSlugRemoveAllowance)
                                                        {
                                                            dSlugRemoveAllowance = oData_payslipItem.Amount; //HeroZIP, HeroHNP
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sTeaMakingAllowance)
                                                        {
                                                            dTeaMakingAllowance = oData_payslipItem.Amount; //HeroZIP, HeroHNP
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sMobileAllowance)
                                                        {
                                                            dMobileAllowance = oData_payslipItem.Amount; //HeroZIP, HeroHNP
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sTeleAllowance)
                                                        {
                                                            dTeleAllowance = oData_payslipItem.Amount;//HeroZIP, HeroHNP
                                                        }

                                                        else if (sSalaryItem_configs == clsConfig.sBordingAllowance)
                                                        {
                                                            dBordingAllowance = oData_payslipItem.Amount; //HeroZIP, HeroHNP
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sHeatingAllowance)
                                                        {
                                                            dHeatingAllowance = oData_payslipItem.Amount; //HeroZIP, HeroHNP
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sNightAllowance)
                                                        {
                                                            dNightAllowance = oData_payslipItem.Amount; //HeroZIP, HeroHNP
                                                        }

                                                        else if (sSalaryItem_configs == clsConfig.sCocuntAllowance)
                                                        {
                                                            dCoconutAllowance = oData_payslipItem.Amount; //HeroHNP
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sCocountLoadingAllowance)
                                                        {
                                                            dCoconutLoardingAllowance = oData_payslipItem.Amount; //HeroHNP
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sLineLeaderAllowance)
                                                        {
                                                            dLineLeaderAllowance = oData_payslipItem.Amount; //HeroHNP
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sFilterClothAllowance)
                                                        {
                                                            dFilterClothAllowance = oData_payslipItem.Amount; //HeroHNP
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sCleaningSalary)
                                                        {
                                                            dCleaningsalary = oData_payslipItem.Amount; //HeroHNP
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sShellremovingAllowance)
                                                        {
                                                            dShellRemovingAllowance = oData_payslipItem.Amount; //HeroHNP
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sTravellingAllowance)
                                                        {
                                                            dTravellingallowance = oData_payslipItem.Amount; //HeroHNP, PPS
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sStoresAllowance)
                                                        {
                                                            dStroresAllowance = oData_payslipItem.Amount; //HeroHNP
                                                        }

                                                        else if (sSalaryItem_configs == clsConfig.sAllowance1_Deduction)
                                                        {
                                                            dAllowance1_Deduction = oData_payslipItem.Amount; //HeroZIP, HeroHNP
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sIncrementAllowance_Deduction)
                                                        {
                                                            dIncrementAllowance_Deduction = oData_payslipItem.Amount; //HeroZIP, HeroHNP
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sTeaMakingAllowance_Deduction)
                                                        {
                                                            dTeaMakingAllowance_Deduction = oData_payslipItem.Amount; //HeroZIP, HeroHNP
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sBordingAllowance_Deduction)
                                                        {
                                                            dBordingAllowance_Deduction = oData_payslipItem.Amount; //HeroZIP, HeroHNP
                                                        }

                                                        else if (sSalaryItem_configs == clsConfig.sCocuntAllowance_Deduction)
                                                        {
                                                            dCoconutAllowance_Deduction = oData_payslipItem.Amount; //HeroHNP
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sStoresAllowance_Deduction)
                                                        {
                                                            dStoresallowance_Deduction = oData_payslipItem.Amount; //HeroHNP
                                                        }

                                                        else if (sSalaryItem_configs == clsConfig.sDryerAllowance)
                                                        {
                                                            dDryrerAllowance = oData_payslipItem.Amount; //HeroHNP
                                                        }
                                                        else if (sSalaryItem_configs == clsConfig.sDryerAllowance_Deduction)
                                                        {
                                                            dDryrerAllowance_Deduction = oData_payslipItem.Amount; //HeroHNP
                                                        }
                                                    }
                                                    #endregion

                                                    decimal dTotal = (dAllowance1 + dAllowance1_Deduction) + (dIncrementAllowance + dIncrementAllowance_Deduction) + dFoodAllowance + dSlugRemoveAllowance + (dTeaMakingAllowance + dTeaMakingAllowance_Deduction) + dMobileAllowance + dTeleAllowance + (dBordingAllowance + dBordingAllowance_Deduction) + dNightAllowance + (dDryrerAllowance + dDryrerAllowance_Deduction) + dHeatingAllowance
                                                        + (dCoconutAllowance + dCoconutAllowance_Deduction) + dCoconutLoardingAllowance + dLineLeaderAllowance + dFilterClothAllowance + dCleaningsalary + dShellRemovingAllowance + dTravellingallowance + (dStroresAllowance + dStoresallowance_Deduction);

                                                    glb_dts_PAY.dt_Allowance.Adddt_AllowanceRow(oTxPayRawRecord.Employee_ID, clsRef_Name.get_EmployeeShortName_initialsFirst(oTxPayRawRecord.Employee_ID), oTxPayRawRecord.EmpCatagory1_ID, clsRef_Name.get_EmployeeCategory1_Name(oTxPayRawRecord.EmpCatagory1_ID), oTxPayRawRecord.EmpCatagory2_ID, clsRef_Name.get_EmployeeCategory2_Name(oTxPayRawRecord.EmpCatagory2_ID), oTxPayRawRecord.ProcessGroup_ID, clsRef_Name.get_processGroup_Name(oTxPayRawRecord.ProcessGroup_ID),
                                                        (dAllowance1 + dAllowance1_Deduction), (dIncrementAllowance + dIncrementAllowance_Deduction),
                                                        dFoodAllowance, dSlugRemoveAllowance, (dTeaMakingAllowance + dTeaMakingAllowance_Deduction),
                                                        dMobileAllowance, dTeleAllowance, (dBordingAllowance + dBordingAllowance_Deduction),
                                                        dHeatingAllowance, dNightAllowance, (dDryrerAllowance + dDryrerAllowance_Deduction),
                                                        (dCoconutAllowance + dCoconutAllowance_Deduction), dCoconutLoardingAllowance, dLineLeaderAllowance,
                                                        dFilterClothAllowance, dCleaningsalary, dShellRemovingAllowance, dTravellingallowance, (dStroresAllowance + dStoresallowance_Deduction), 0, dTotal);

                                                    #region Allowance Denomination Report Only
                                                    if (Report == enum_ReportName.SalaryDenomination_Allowance)
                                                    {
                                                        decimal[] odeno;
                                                        odeno = GetDenomination(dTotal);
                                                        glb_dts_PAY.dt_Denomination.Adddt_DenominationRow(oTxPayRawRecord.Employee_ID, odeno[0], odeno[1], odeno[2], odeno[3], odeno[4], odeno[5], odeno[6], odeno[7], odeno[8], odeno[9], odeno[10], odeno[11]);
                                                    }
                                                    #endregion
                                                }
                                            }
                                        }
                                    }
                            }

                            #endregion

                            #region NEW METHOD
                            else
                            {
                              

                                if (bPayslipItemSelected)
                                {
                                    glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("PayslipItemID", txtPayslipItem.Tag.ToString(), true);
                                    glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("PayslipItemName", txtPayslipItem.Text, true);//PayslipItemName
                                }

                                if (Report == enum_ReportName.PayslipItemAmount_SignatureSheet && (txtPayslipItem.Tag == null))
                                {
                                    SEACCMessageBox.Show("Payslip Item can not be empty", "Please select valid payslip", MessageBoxButton.OK, "Red");
                                    return;
                                }

                                List<tbl_payTxSIPRawData> oTxSIP_PayDataRows = tbl_payTxSIPRawData.SelectAllPeriods_ByDateRange(dtmFromDate.Date, dtmToDate.Date).Where(r => r.IsPayslip_Print).ToList();

                                #region Selected Filters
                                if (bEmployeeSelected)
                                    oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.Employee_ID == txtEmployee.Tag.ToString()).ToList();
                                if (bDivisionSelected)
                                    oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => vDivisions.Any(r2 => r2.Field<string>("id") == r.Division_ID)).ToList();
                                if (bDepartmentSelected)
                                    oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.Department_ID == txtDepartment.Tag.ToString()).ToList();
                                if (bSectionSelected)
                                    oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.SectionID == txtSection.Tag.ToString()).ToList();
                                if (bSubSectionSelected)
                                    oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.SubSectionID == txtSubSection.Tag.ToString()).ToList();
                                if (bDesignationSelected)
                                    oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.Designation_ID == txtDesignation.Tag.ToString()).ToList();
                                if (bEmpCategory1Selected)
                                    oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.EmpCatagory1_ID == txtEmpCategory1.Tag.ToString()).ToList();
                                if (bEmpCategory2Selected)
                                    oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.EmpCatagory2_ID == txtEmpCategory2.Tag.ToString()).ToList();
                                if (bEmpCategory3Selected)
                                    oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.EmpCatagory3_ID == txtEmpCategory3.Tag.ToString()).ToList();
                                if (bPayPeriodSelected)
                                    oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.ProcessGroup_ID == txtPayPeriod.Uid && r.ProcessPeriod_ID == int.Parse(txtPayPeriod.ToolTip.ToString()) && r.ProcessPeriod_Sub_ID == int.Parse(txtPayPeriod.Tag.ToString())).ToList();
                                if (bPaymentMethodSelected)
                                    oTxSIP_PayDataRows = oTxSIP_PayDataRows.Where(r => r.PaymentMethod_ID == txtPayementMethodBy.Tag.ToString()).ToList();
                                #endregion

                                string sEPF_No = "-";
                                foreach (tbl_payTxSIPRawData oPayDataRow in oTxSIP_PayDataRows.OrderBy(o => o.EpfNo.PadLeft(4, '0')))
                                {
                                    sEPF_No = (oPayDataRow.EpfNo == "" || oPayDataRow.EpfNo == "0") ? "-" : oPayDataRow.EpfNo.PadLeft(4, '0');

                                    tbl_payMas_ProcessPeriod_Sub oPayroll_Period = tbl_payMas_ProcessPeriod_Sub.Select(clsSecurity.CompanyID, clsSecurity.BranchID, oPayDataRow.ProcessGroup_ID, oPayDataRow.ProcessPeriod_ID, oPayDataRow.ProcessPeriod_Sub_ID);
                                    glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("Draft", "DRAFT", !oPayroll_Period.IsClosedPeriod);

                                    if (!oPayroll_Period.IsClosedPeriod && (Report == enum_ReportName.EmployeePayslip || Report == enum_ReportName.EmployeePayslip_Allowance|| Report == enum_ReportName.EmployeePayslip_Basic))
                                        continue;

                                    tbl_genMasEmployee oEmp = tbl_genMasEmployee.Select(oPayDataRow.Employee_ID, clsSecurity.CompanyID, clsSecurity.BranchID);
                                    if (oEmp.LastWorkingDate.Date <= dtmFromDate.Date && oEmp.LastWorkingDate.Date != clsConfig.defaultDateTime.Date)
                                        continue;

                                    tbl_securityParollGroup_UserPermission oGrpPermission = tbl_securityParollGroup_UserPermission.Select(clsSecurity.CompanyID, clsSecurity.BranchID, clsSecurity.UserIDLoged, oPayDataRow.ProcessGroup_ID);
                                    if (oGrpPermission != null && oGrpPermission.AllowView)
                                    {
                                        glb_dts_PAY.dt_EmpSalaryData.Adddt_EmpSalaryDataRow(oPayDataRow.Employee_ID, oPayDataRow.NicNo, clsRef_Name.get_EmployeeShortName(oPayDataRow.Employee_ID),
                                        oPayDataRow.Division_ID, clsRef_Name.get_Division_Name(oPayDataRow.Division_ID),
                                        oPayDataRow.Department_ID, clsRef_Name.get_Department_Name(oPayDataRow.Department_ID),
                                        oPayDataRow.SectionID, clsRef_Name.get_Section_Name(oPayDataRow.SectionID),
                                        oPayDataRow.SubSectionID, clsRef_Name.get_SubSection_Name(oPayDataRow.SubSectionID),
                                        oPayDataRow.EmpCatagory1_ID, clsRef_Name.get_EmployeeCategory1_Name(oPayDataRow.EmpCatagory1_ID),
                                        oPayDataRow.EmpCatagory2_ID, clsRef_Name.get_EmployeeCategory2_Name(oPayDataRow.EmpCatagory2_ID),
                                        oPayDataRow.EmpCatagory3_ID, clsRef_Name.get_EmployeeCategory3_Name(oPayDataRow.EmpCatagory3_ID),
                                        clsRef_Name.get_Designation_Name(oPayDataRow.Designation_ID), oPayDataRow.EmpDateConfirmed,
                                        oPayDataRow.ProcessGroup_ID, clsRef_Name.get_processGroup_Name(oPayDataRow.ProcessGroup_ID),
                                        oPayDataRow.ProcessPeriod_ID.ToString(), "-", oPayDataRow.ProcessPeriod_Sub_ID.ToString(), "-",
                                        oPayDataRow.IsEPF_ETF_Process, sEPF_No, oPayDataRow.Is_PayeeProcess, oPayDataRow.PayeeNo, clsRef_Name.get_PayemntMethode_Name(oPayDataRow.PaymentMethod_ID),
                                        clsRef_Name.get_Bank_Name(oPayDataRow.Bank_ID), clsRef_Name.get_BankBranch_Name(oPayDataRow.BankBranch_ID), oPayDataRow.Bank_AccNo,
                                        oPayDataRow.SIP_ID.ToString(), oPayDataRow.WorkingMinutes_Mand / 60, oPayDataRow.WorkingMinutesAct_Nomal / 60,
                                        clsHelpMethods.GetBaseSalaryForNopay_FromMas(oPayDataRow.Employee_ID) / ((oPayDataRow.EmpCatagory2_ID == clsConfig.sFactory_Employees_Category2_ID_ii.Trim()) ? int.Parse(clsConfig.sDivisionRate_OTimeClaculation_Factory) : int.Parse(clsConfig.sDivisionRate_OTimeClaculation_Office)),
                                        oPayDataRow.NoPayMinutes / 60,
                                        oPayDataRow.LateMinutes / 60,0,
                                    //    clsHelpMethods.GetBaseSalaryForNopay_FromMas(oPayDataRow.Employee_ID) * oPayDataRow.BaseRate_OT / oPayDataRow.DivRate_OT,
                                        oPayDataRow.WorkingMinutesAct_OT / 60,0,
                                       // clsHelpMethods.GetBaseSalaryForNopay_FromMas(oPayDataRow.Employee_ID) * oPayDataRow.BaseRate_DOT / oPayDataRow.DivRate_DOT,
                                        oPayDataRow.WorkingMinutesAct_OT_Dub / 60,0,
                                       //  clsHelpMethods.GetBaseSalaryForNopay_FromMas(oPayDataRow.Employee_ID) * oPayDataRow.BaseRate_TOT / oPayDataRow.DivRate_TOT,
                                        oPayDataRow.WorkingMinutesAct_OT_Trpl / 60,
                                       clsRef_Name.get_EmployeeAliasName(oPayDataRow.Employee_ID), clsRef_Name.get_EmployeeName(oPayDataRow.Employee_ID),
                                        oPayDataRow.ProcessPeriod_Sub_startDate, oPayDataRow.ProcessPeriod_Sub_endDate);

                                        #region Attendance and Leave Details
                                        if (clsConfig.bEnableAttendanceData_Payslip)//Enable to Indika - Janith (2018-11-02)
                                        {
                                            decimal LeaveBalance = 0, Leaves_Entitled = 0, Leaves_Utilized = 0;
                                            int iCurrentHRYear_ID = 0;
                                            decimal dLateDays = clsHelpMethods.UpdateLates(oPayDataRow.Employee_ID, dtmFromDate.Date, dtmToDate.Date);
                                            decimal dLateHrs = oPayDataRow.LateMinutes / 60;

                                            tbl_hrPeriod_Year oYear = tbl_hrPeriod_Year.SelectAll().Where(r => r.Year_startDate.Date <= dtmFromDate.Date && r.Year_endDate >= dtmToDate.Date).FirstOrDefault();
                                            if (oYear != null)
                                            {
                                                iCurrentHRYear_ID = oYear.Year_ID;
                                            }

                                            string[] sLeaveTypes_List = clsConfig.sLeaveTypes.Trim().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                                            List<tbl_tasEmployeeLeave_entitled> oLeaves_List = tbl_tasEmployeeLeave_entitled.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, oPayDataRow.Employee_ID);
                                            foreach (tbl_tasEmployeeLeave_entitled oLeaves in oLeaves_List.Where(p => p.LeaveType_ID != "default" && p.HrYear_ID == iCurrentHRYear_ID && sLeaveTypes_List.Contains(p.LeaveType_ID.Trim())))
                                            {
                                                Leaves_Entitled += oLeaves.Leaves_Entitled;
                                                Leaves_Utilized += oLeaves.Leaves_Utilized;
                                                LeaveBalance += (oLeaves.Leaves_Entitled - oLeaves.Leaves_Utilized);
                                            }

                                            glb_dts_PAY.dt_EmpSalaryData_AttnDetails.Adddt_EmpSalaryData_AttnDetailsRow(oPayDataRow.Employee_ID,
                                               clsRef_Name.get_EmployeeShortName(oPayDataRow.Employee_ID),
                                               oPayDataRow.SIP_ID.ToString(),
                                               oPayDataRow.WorkingDays_Mand, oPayDataRow.WorkingDays_Act,
                                               dLateHrs, dLateDays,
                                               Leaves_Entitled, Leaves_Utilized, LeaveBalance);
                                        }
                                        #endregion

                                        List<tbl_payTxSIPRawData_PaySlipItems> oPayItems = tbl_payTxSIPRawData_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(oPayDataRow.Company_ID, oPayDataRow.CompanyBranch_ID, oPayDataRow.SIP_ID).OrderBy(o => o.LineNo).ToList();
                                        oPayItems.ForEach((oPayItem) => glb_dts_PAY.dt_EmpSalaryData_PayslipItems.Rows.Add(oPayItem.SIP_ID, oPayItem.PayItem_ID, (oPayItem.PayItem_ID), oPayItem.PayItem_Code, oPayItem.IsEarning, oPayItem.Amount));

                                        List<tbl_payTxSIPRawData_PaySlipItems_Statutary> oPayStats = tbl_payTxSIPRawData_PaySlipItems_Statutary.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(oPayDataRow.Company_ID, oPayDataRow.CompanyBranch_ID, oPayDataRow.SIP_ID).Where(r1 => oPayItems.Any(r2 => r2.Company_ID == r1.Company_ID && r2.CompanyBranch_ID == r1.CompanyBranch_ID && r2.SIP_ID == r1.SIP_ID && r2.PayItem_ID == r1.PayItem_ID)).ToList();
                                        oPayStats.ForEach((oPayStat) => glb_dts_PAY.dt_EmpSalaryData_PayslipItems_Statutatry.Rows.Add(oPayStat.SIP_ID, oPayStat.PayItem_ID, oPayStat.StatutaryPayItem_ID, oPayStat.Percentage, oPayStat.Amount));
                                    }
                                }
                            }
                            #endregion

                            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                            frmViewer.print(oReport.ReportPath, glb_dts_PAY, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                        }
                        #endregion
                        #endregion
                    }
                }
                else
                {
                    SEACCMessageBox.Show("Oops....", " Please select a report you need ", MessageBoxButton.OK, "Red");
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
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmployee, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDesignation, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDivision, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDepartment, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSubSection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmpCategory1, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmpCategory2, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmpCategory3, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtShift, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtYear, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtWeek, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtPayPeriod, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtPayementMethodBy, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtPayslipItem, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtComBankAccount, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtLeaveTypes, true, false, false);
            cls_Formater.SetEnableDisable_MultipleSelectBox(msbDivision, true);

            txtEmployee.Tag = null;
            txtDesignation.Tag = null;
            txtDivision.Tag = null;
            txtDepartment.Tag = null;
            txtSection.Tag = null;
            txtSubSection.Tag = null;
            txtEmpCategory1.Tag = null;
            txtEmpCategory2.Tag = null;
            txtEmpCategory3.Tag = null;
            txtShift.Tag = null;
            txtYear.Tag = null;
            txtWeek.Tag = null;
            txtPayPeriod.Tag = null;
            txtPayementMethodBy.Tag = null;
            txtPayslipItem.Tag = null;
            txtComBankAccount.Tag = null;
            txtLeaveTypes.Tag = null;

            txtEmployee.Text = "<All Employees>";
            txtDesignation.Text = "<All Designations>";
            txtDivision.Text = "<All Divisions>";
            txtDepartment.Text = "<All Departments>";
            txtSection.Text = "<All Sections>";
            txtSubSection.Text = "<All Sub Sections>";
            txtEmpCategory1.Text = "<All Categories [1])>";
            txtEmpCategory2.Text = "<All Categories [2])>";
            txtEmpCategory3.Text = "<All Categories [3])>";
            txtShift.Text = "<All Shifts>";
            txtYear.Text = "<All Years>";
            txtWeek.Text = "<All Weeks>";
            txtPayPeriod.Text = "<Select a Process Period>";
            txtPayementMethodBy.Text = "<All Payment Methods>";
            txtPayslipItem.Text = "<All Payslip Items>";
            txtComBankAccount.Text = "<Select a Bank Account>";
            txtLeaveTypes.Text = "< All Leave Types>";

            cmb_EmpStatus.comboBox.ItemsSource = GetEnumDescription(typeof(EmployeeStatus));
            cmb_EmpStatus.SetSelectedIndex(cmb_EmpStatus.comboBox.Items.Count - 1);

            dtp_FromDate.SetTime(DateTime.Now);
            dtp_ToDate.SetTime(DateTime.Now);

            msbDivision.ClearData();
            List<tbl_genMasDivision> oDivs = tbl_genMasDivision.SelectAll().Where(r => r.Company_ID.ToLower() == clsSecurity.CompanyID.ToLower() && r.CompanyBranch_ID.ToLower() == clsSecurity.BranchID.ToLower() && !r.IsCanceled).ToList();
            oDivs.ForEach((o) => msbDivision.SetData(true, o.Division_ID, o.DivisionName));

            drg_Reports.grdMain.RowHeight = 30;
            drg_Reports.grdMain.CanUserResizeColumns = true;
            drg_Reports.grdMain.HeadersVisibility = DataGridHeadersVisibility.None;
            drg_Reports.grdMain.AlternatingRowBackground = (Brush)bc.ConvertFrom("#FF2D3E4F");
        }

        #region Clear Fields Methods Wise
        private void ClearRegisterReports_Filters()
        {
            txtDivision.Text = "<All Divisions>";
            txtShift.Text = "<All Shifts>";
            txtYear.Text = "<All Years>";
            txtWeek.Text = "<All Weeks>";
            txtPayPeriod.Text = "<Select a Process Period>";
            txtPayementMethodBy.Text = "<All Payment Methods>";
            txtComBankAccount.Text = "<Select a Bank Account>";
            txtPayslipItem.Text = "<All Payslip Items>";

            cmb_EmpStatus.SetSelectedIndex(cmb_EmpStatus.comboBox.Items.Count - 1);

            rdoAll.IsChecked = true;
            rdoIsPaySlipPrint.IsChecked = false;
            rdoIsNotPaySlipPrint.IsChecked = false;

            dtp_FromDate.SetTime(DateTime.Now);
            dtp_ToDate.SetTime(DateTime.Now);

            txtDivision.Tag = null;
            txtShift.Tag = null;
            txtYear.Tag = null;
            txtWeek.Tag = null;
            txtPayPeriod.Tag = null;
            txtPayementMethodBy.Tag = null;
            txtComBankAccount.Tag = null;
            txtPayslipItem.Tag = null;
        }

        private void ClearTASReports_Filters()
        {
            msbDivision.ClearData();
            List<tbl_genMasDivision> oDivs = tbl_genMasDivision.SelectAll().Where(r => r.Company_ID.ToLower() == clsSecurity.CompanyID.ToLower() && r.CompanyBranch_ID.ToLower() == clsSecurity.BranchID.ToLower() && !r.IsCanceled).ToList();
            oDivs.ForEach((o) => msbDivision.SetData(true, o.Division_ID, o.DivisionName));

            txtShift.Text = "<All Shifts>";
            txtYear.Text = "<All Years>";
            txtWeek.Text = "<All Weeks>";
            txtPayPeriod.Text = "<Select a Process Period>";
            txtPayementMethodBy.Text = "<All Payment Methods>";
            txtComBankAccount.Text = "<Select a Bank Account>";
            txtPayslipItem.Text = "<All Payslip Items>";

            cmb_EmpStatus.SetSelectedIndex(cmb_EmpStatus.comboBox.Items.Count - 1);

            rdoAll.IsChecked = true;
            rdoIsPaySlipPrint.IsChecked = false;
            rdoIsNotPaySlipPrint.IsChecked = false;

            txtShift.Tag = null;
            txtYear.Tag = null;
            txtWeek.Tag = null;
            txtPayPeriod.Tag = null;
            txtPayementMethodBy.Tag = null;
            txtComBankAccount.Tag = null;
            txtPayslipItem.Tag = null;
        }

        private void ClearCCReports_Filters()
        {
            txtDesignation.Visibility = System.Windows.Visibility.Collapsed;

            msbDivision.ClearData();
            List<tbl_genMasDivision> oDivs = tbl_genMasDivision.SelectAll().Where(r => r.Company_ID.ToLower() == clsSecurity.CompanyID.ToLower() && r.CompanyBranch_ID.ToLower() == clsSecurity.BranchID.ToLower() && !r.IsCanceled).ToList();
            oDivs.ForEach((o) => msbDivision.SetData(true, o.Division_ID, o.DivisionName));

            txtDesignation.Text = "<All Designations>";
            txtShift.Text = "<All Shifts>";
            txtYear.Text = "<All Years>";
            txtWeek.Text = "<All Weeks>";
            txtPayPeriod.Text = "<Select a Process Period>";
            txtPayementMethodBy.Text = "<All Payment Methods>";
            txtComBankAccount.Text = "<Select a Bank Account>";
            txtPayslipItem.Text = "<All Payslip Items>";

            cmb_EmpStatus.SetSelectedIndex(cmb_EmpStatus.comboBox.Items.Count - 1);

            rdoAll.IsChecked = true;
            rdoIsPaySlipPrint.IsChecked = false;
            rdoIsNotPaySlipPrint.IsChecked = false;

            txtDesignation.Tag = null;
            txtShift.Tag = null;
            txtYear.Tag = null;
            txtWeek.Tag = null;
            txtPayPeriod.Tag = null;
            txtPayementMethodBy.Tag = null;
            txtComBankAccount.Tag = null;
            txtPayslipItem.Tag = null;
        }

        private void ClearPAYROLLReports_Filters()
        {
            txtDivision.Text = "<All Divisions>";
            txtShift.Text = "<All Shifts>";
            txtYear.Text = "<All Years>";
            txtWeek.Text = "<All Weeks>";
            txtPayementMethodBy.Text = "<All Payment Methods>";
            txtComBankAccount.Text = "<Select a Bank Account>";
            txtPayslipItem.Text = "<All Payslip Items>";

            cmb_EmpStatus.SetSelectedIndex(cmb_EmpStatus.comboBox.Items.Count - 1);

            rdoAll.IsChecked = true;
            rdoIsPaySlipPrint.IsChecked = false;
            rdoIsNotPaySlipPrint.IsChecked = false;

            txtDivision.Tag = null;
            txtShift.Tag = null;
            txtYear.Tag = null;
            txtWeek.Tag = null;
            txtPayementMethodBy.Tag = null;
            txtComBankAccount.Tag = null;
            txtPayslipItem.Tag = null;
        }
        #endregion
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmployeeID())
            {
                if (CheckValidityDateRange())
                    bStatus = true;
            }

            return bStatus;
        }
        private bool CheckValidity_Department()
        {
            bool bStatus = true;
            if (!clsValidation.Validate_EmptyTag(txtDepartment))
            {
                if (CheckValidityDateRange())
                    bStatus = false;
            }

            return bStatus;
        }
        private bool CheckValidity_EmployeeID()
        {
            bool bStatus = true;
            if (!clsValidation.Validate_EmptyTag(txtEmployee))
                bStatus = false;
            return bStatus;
        }
        private bool CheckValidityDateRange()
        {
            bool bStatus = true;
            if (dtp_FromDate.GetDateTime() > dtp_ToDate.GetDateTime())
            {
                SEACCMessageBox.Show("Oops", "Invalid Date Range", MessageBoxButton.OK);
                bStatus = false;
            }
            return bStatus;
        }
        #endregion

        #region Refresh Grid
        public void RefreshGrid()
        {
            try
            {
                drg_Reports.dt.Rows.Clear();
                foreach (tbl_securityFunctionMaster oReports in tbl_securityFunctionMaster.SelectAll().Where(p => p.IsReport && p.IsEnable).GroupBy(g => g.FunctionCategory_ID).SelectMany(g => g.OrderBy(o => o.Function_Code)))
                {
                    try
                    {
                        #region Check Permission to View and Add to Grid
                        tbl_securityFunctionMaster_Permission detail = tbl_securityFunctionMaster_Permission.Select(Digiteq_Logic.clsSecurity.UserIDLoged, oReports.Function_ID);
                        if (detail != null)
                        {
                            if (detail.AllowView)
                                drg_Reports.dt.Rows.Add(
                                    oReports.Function_ID,
                                    oReports.FunctionCategory_ID,
                                    clsRef_Name.get_FunctionCategory_Name(oReports.FunctionCategory_ID),
                                    oReports.FunctionName);
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                drg_Reports.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion

        #region Grid Events
        private void drg_Reports_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                if ((((DataRowView)(e.Row.DataContext)).Row.ItemArray[1].ToString()) == "FCAT/030")
                {
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#cce4ff");
                }

                if ((((DataRowView)(e.Row.DataContext)).Row.ItemArray[1].ToString()) == "FCAT/040")
                {
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#ffcccc");
                }

                if ((((DataRowView)(e.Row.DataContext)).Row.ItemArray[1].ToString()) == "FCAT/070")
                {
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#FFC7D5C6");
                }

                if ((((DataRowView)(e.Row.DataContext)).Row.ItemArray[1].ToString()) == "FCAT/200")
                {
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#FFc8d3e5");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void dgv_Reports_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = drg_Reports.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (drg_Reports.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    int iReportID = int.Parse(GridID);

                    enum_ReportName Report = (enum_ReportName)iReportID;
                    tbl_securityFunctionMaster oFunction = tbl_securityFunctionMaster.Select(iReportID);

                    VisibleAllControllers();

                    #region Register Reports
                    if (Report == enum_ReportName.Employee_Demography_Personal_Details || Report == enum_ReportName.Employee_Information_Sheet || Report == enum_ReportName.Employee_Resigned_Sheet || Report == enum_ReportName.Employee_Birthday_List || Report == enum_ReportName.Employee_Birthday_Calendar ||
                        Report == enum_ReportName.Employee_Service_Record || Report == enum_ReportName.Employee_JoingMonthListing || Report == enum_ReportName.Employee_Retirement_Record)
                    {
                        ClearRegisterReports_Filters();

                        txtDivision.Visibility = Visibility.Collapsed;
                        txtShift.Visibility = System.Windows.Visibility.Collapsed;
                        txtYear.Visibility = System.Windows.Visibility.Collapsed;
                        txtWeek.Visibility = System.Windows.Visibility.Collapsed;
                        txtPayPeriod.Visibility = System.Windows.Visibility.Collapsed;
                        dtp_FromDate.Visibility = Visibility.Collapsed;
                        dtp_ToDate.Visibility = Visibility.Collapsed;
                        txtPayementMethodBy.Visibility = Visibility.Collapsed;
                        txtComBankAccount.Visibility = Visibility.Collapsed;
                        txtPayslipItem.Visibility = Visibility.Collapsed;
                        stkPayslipPrint.Visibility = Visibility.Collapsed;
                        txtLeaveTypes.Visibility = Visibility.Collapsed;

                        if (Report == enum_ReportName.Employee_Service_Record)
                        {
                            dtp_ToDate.Visibility = Visibility.Visible;
                        }
                        else if (Report == enum_ReportName.Employee_Resigned_Sheet)
                        {
                            cmb_EmpStatus.Visibility = Visibility.Collapsed;
                            cmb_EmpStatus.SetSelectedIndex((int)EmployeeStatus.Resigned);
                            dtp_FromDate.Visibility = Visibility.Visible;
                            dtp_ToDate.Visibility = Visibility.Visible;
                        }
                        else if (Report == enum_ReportName.Employee_JoingMonthListing)
                        {
                            dtp_FromDate.Visibility = Visibility.Visible;
                            dtp_ToDate.Visibility = Visibility.Visible;
                        }
                        else if (Report == enum_ReportName.Employee_Retirement_Record)
                        {
                            cmb_EmpStatus.Visibility = Visibility.Collapsed;
                            //cmb_EmpStatus.SetSelectedIndex(cmb_EmpStatus.comboBox.Items.Count - 1);

                            dtp_FromDate.Visibility = Visibility.Visible;
                            dtp_ToDate.Visibility = Visibility.Visible;
                        }
                    }
                    #endregion

                    #region Attendance Reports
                    if (Report == enum_ReportName.AttendanceSummary_EmployeeWise || Report == enum_ReportName.AttendanceSummary_DeviceRawData ||
                        Report == enum_ReportName.AttendanceSummary_EmployeeWise_Detail || Report == enum_ReportName.CheckRoll_LabourersEmployed ||
                        Report == enum_ReportName.MonthlyAttendanceSheetExcel || Report == enum_ReportName.HeadCountReport ||
                        Report == enum_ReportName.HeadCountDetailReport ||
                        Report == enum_ReportName.Daily_MissedPunchReport_New || Report == enum_ReportName.Daily_Absenteeism_Report ||
                        Report == enum_ReportName.Device_Raw_Data_Employee_Wise || Report == enum_ReportName.Device_Detail ||
                        Report == enum_ReportName.LateEmployees || Report == enum_ReportName.LeaveCard || Report == enum_ReportName.GatePassDetails ||
                        Report == enum_ReportName.LeaveBalance ||
                        Report == enum_ReportName.OverTimeDetails || Report == enum_ReportName.LeaveEncashment_EmployeeWise ||
                        Report == enum_ReportName.AttendanceSummary_DeviceRawData_Details || Report == enum_ReportName.FingerPrints_MoreThanTwo_Reports ||
                        Report == enum_ReportName.Nopay_Report || Report == enum_ReportName.AttendanceIncentive)
                    {
                        ClearTASReports_Filters();

                        msbDivision.Visibility = Visibility.Collapsed;
                        txtPayPeriod.Visibility = System.Windows.Visibility.Collapsed;
                        txtShift.Visibility = System.Windows.Visibility.Collapsed;
                        cmb_EmpStatus.Visibility = Visibility.Collapsed;
                        txtYear.Visibility = System.Windows.Visibility.Collapsed;
                        txtWeek.Visibility = System.Windows.Visibility.Collapsed;
                        txtPayementMethodBy.Visibility = Visibility.Collapsed;
                        txtComBankAccount.Visibility = Visibility.Collapsed;
                        txtPayslipItem.Visibility = Visibility.Collapsed;
                        stkPayslipPrint.Visibility = Visibility.Collapsed;
                        txtLeaveTypes.Visibility = Visibility.Collapsed;

                        if (Report == enum_ReportName.LeaveEncashment_EmployeeWise)
                        {
                            txtYear.Visibility = System.Windows.Visibility.Visible;
                            dtp_FromDate.Visibility = System.Windows.Visibility.Collapsed;
                            dtp_ToDate.Visibility = System.Windows.Visibility.Collapsed;
                        }

                        if (Report == enum_ReportName.LeaveBalance || Report == enum_ReportName.LateEmployees)
                            dtp_FromDate.Visibility = System.Windows.Visibility.Collapsed;

                        if (Report == enum_ReportName.HeadCountReport || Report == enum_ReportName.HeadCountDetailReport)
                        {
                            dtp_FromDate.Visibility = System.Windows.Visibility.Collapsed;
                            dtp_ToDate.Visibility = System.Windows.Visibility.Collapsed;
                        }
                        if (Report == enum_ReportName.LeaveCard)
                            txtLeaveTypes.Visibility = Visibility.Visible;
                    }
                    #endregion

                    #region CC Reports - Hero Nature
                    if (oFunction.FunctionCategory_ID == "FCAT/200")
                    {
                        ClearCCReports_Filters();

                        msbDivision.Visibility = Visibility.Collapsed;
                        txtDesignation.Visibility = System.Windows.Visibility.Collapsed;
                        txtShift.Visibility = System.Windows.Visibility.Collapsed;
                        cmb_EmpStatus.Visibility = Visibility.Collapsed;
                        txtPayPeriod.Visibility = System.Windows.Visibility.Collapsed;
                        txtPayementMethodBy.Visibility = Visibility.Collapsed;
                        txtComBankAccount.Visibility = Visibility.Collapsed;
                        txtPayslipItem.Visibility = Visibility.Collapsed;
                        stkPayslipPrint.Visibility = Visibility.Collapsed;
                        txtLeaveTypes.Visibility = Visibility.Collapsed;
                    }
                    #endregion

                    #region PAYROLL Reports
                    if (oFunction.FunctionCategory_ID == "FCAT/070")
                    {
                        ClearPAYROLLReports_Filters();

                        txtDivision.Visibility = Visibility.Collapsed;
                        txtShift.Visibility = System.Windows.Visibility.Collapsed;
                        cmb_EmpStatus.Visibility = Visibility.Collapsed;
                        txtYear.Visibility = System.Windows.Visibility.Collapsed;
                        txtWeek.Visibility = System.Windows.Visibility.Collapsed;
                        txtPayPeriod.Visibility = Visibility.Collapsed;
                        stkPayslipPrint.Visibility = Visibility.Collapsed;
                        txtLeaveTypes.Visibility = Visibility.Collapsed;

                        if (Report != enum_ReportName.NetSalary_ElectronicFormat &&
                            Report != enum_ReportName.Unprocessed_PayslipItem_ElectronicFormat &&
                            Report != enum_ReportName.NetSalary_ExcelFormat)
                        {
                            txtComBankAccount.Visibility = Visibility.Collapsed;
                        }

                        if (Report == enum_ReportName.CoinAnalysisReport_SalaryPayable ||
                            Report == enum_ReportName.ReturnForHalf_YearEnding ||
                            Report == enum_ReportName.EPF_C_Form ||
                            Report == enum_ReportName.EPF_ElectronicFormat ||
                            Report == enum_ReportName.ETF_R1_Form ||
                            Report == enum_ReportName.ETF_ElectronicFormat ||
                            Report == enum_ReportName.EPF_ETFSheet ||
                            Report == enum_ReportName.PayrollDetail ||
                            Report == enum_ReportName.PayrollSummary ||
                            Report == enum_ReportName.OverTimeAmount_Details ||
                            Report == enum_ReportName.OverTimeAmount_Summary
                            )
                        {
                            txtPayementMethodBy.Visibility = Visibility.Collapsed;
                            txtPayslipItem.Visibility = Visibility.Collapsed;
                            txtPayPeriod.Visibility = Visibility.Collapsed;
                        }
                        if (Report == enum_ReportName.EmployeePayslip||
                            Report == enum_ReportName.EmployeePayslip_Basic || Report == enum_ReportName.EmployeePayslip_Allowance)
                        {
                            txtPayslipItem.Visibility = Visibility.Collapsed;
                            txtPayementMethodBy.Visibility = Visibility.Visible;
                            txtPayPeriod.Visibility = Visibility.Visible;
                        }
                        if (Report == enum_ReportName.NetSalary_ElectronicFormat ||
                            Report == enum_ReportName.NetSalary_ExcelFormat ||
                  
                            Report == enum_ReportName.SalaryRegisterReport ||
                            Report == enum_ReportName.SalaryRegisterdetail ||
                            Report == enum_ReportName.SalaryRegisterSummary ||
                            Report == enum_ReportName.SignatureSheet_SalaryPayable ||
                            Report == enum_ReportName.PaidEmployeeList ||
                            Report == enum_ReportName.EmployeePAYE_Deduction)
                        {
                            txtPayslipItem.Visibility = Visibility.Collapsed;
                            txtPayementMethodBy.Visibility = Visibility.Visible;
                            txtPayPeriod.Visibility = Visibility.Visible;
                        }

                        if (Report == enum_ReportName.CoinAnalysisReport_SalaryAdvance || Report == enum_ReportName.SignatureSheet_SalaryPayable)
                        {
                            txtPayementMethodBy.Visibility = Visibility.Collapsed;
                        }

                        if (Report == enum_ReportName.ReturnForHalf_YearEnding ||
                            Report == enum_ReportName.SingleEarningDeductionStatement)
                        {
                            dtp_ToDate.Visibility = Visibility.Collapsed;
                            txtPayPeriod.Visibility = Visibility.Visible;
                        }

                        if (Report == enum_ReportName.PaidEmployeeList)
                        {
                            stkPayslipPrint.Visibility = Visibility.Visible;
                            txtPayPeriod.Visibility = Visibility.Visible;
                        }

                        if (Report == enum_ReportName.UnprocessedCoinAnalysisReport || Report == enum_ReportName.UnprocessedPayslipItems_SignatureSheet)
                        {
                            dtp_FromDate.Visibility = Visibility.Collapsed;
                            dtp_ToDate.Visibility = Visibility.Collapsed;
                            dtp_FromDate.SetTime(DateTime.Now);
                            dtp_ToDate.SetTime(DateTime.Now);
                        }
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Event
        private void txtEmployeeID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                txtEmployee.Text = lstResult[0] + "-" + lstResult[2];
                txtEmployee.Tag = lstResult[0];
                sp_genMasEmployee oEmployee = sp_genMasEmployee.Select(lstResult[0]);
                if (oEmployee != null)
                {
                    txtDivision.Text = oEmployee.Division_ID + " - " + oEmployee.DivisionName;
                    txtDivision.Tag = oEmployee.Division_ID;

                    txtDepartment.Text = oEmployee.Department_ID + "-" + oEmployee.DepartmentName;
                    txtDepartment.Tag = oEmployee.Department_ID;

                    txtSection.Text = oEmployee.SectionID + "-" + oEmployee.Section_Name;
                    txtSection.Tag = oEmployee.SectionID;

                    txtSubSection.Text = oEmployee.SubSectionName;
                    txtSubSection.Tag = oEmployee.SubSectionID;

                    txtEmpCategory1.Text = oEmployee.EmpCatagory1_Name;
                    txtEmpCategory1.Tag = oEmployee.EmpCatagory1_ID;

                    txtEmpCategory2.Text = oEmployee.EmpCatagory2_Name;
                    txtEmpCategory2.Tag = oEmployee.EmpCatagory2_ID;

                    txtEmpCategory3.Text = oEmployee.EmpCatagory3_Name;
                    txtEmpCategory3.Tag = oEmployee.EmpCatagory3_ID;

                    txtDesignation.Text = oEmployee.Designation_name;
                    txtDesignation.Tag = oEmployee.Designation_ID;

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

        private void txtShift_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Shift);
            if (RowDataSearch.DialogResult == true)
            {
                txtShift.Text = lstResult[0] + "-" + lstResult[1];
                txtShift.Tag = lstResult[0];
            }
        }

        private void txtWeak_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.HRWeek);
            if (RowDataSearch.DialogResult == true)
            {
                txtYear.Tag = lstResult[0];
                txtWeek.Tag = lstResult[1];

                txtYear.Text = clsRef_Name.get_YearName(lstResult[0]);
                txtWeek.Text = "Week " + lstResult[1];

                dtp_FromDate.SetTime(DateTime.Parse(lstResult[2]).Date);
                dtp_ToDate.SetTime(DateTime.Parse(lstResult[3]).Date);
            }
        }

        private void txtYear_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.HRYear);
            if (RowDataSearch.DialogResult == true)
            {
                txtYear.Text = lstResult[1];
                txtYear.Tag = lstResult[0];
            }
        }

        private void txtPayPeriod_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.PayrollProcessPeriodSub);
            if (RowDataSearch.DialogResult == true)
            {
                txtPayPeriod.Uid = lstResult[0]; //Process Group Id
                txtPayPeriod.ToolTip = lstResult[2]; //Main Period Id
                txtPayPeriod.Tag = lstResult[4]; // Sub Period ID
                txtPayPeriod.Text = lstResult[1] + " - " + lstResult[5];

                tbl_payMas_ProcessPeriod_Sub oPeriod = tbl_payMas_ProcessPeriod_Sub.Select(clsSecurity.CompanyID, clsSecurity.BranchID, lstResult[0], int.Parse(lstResult[2]), int.Parse(lstResult[4]));
                dtp_FromDate.SetTime(oPeriod.StartDate.Date);
                dtp_ToDate.SetTime(oPeriod.EndDate.Date);
            }
        }

        private void txtPayementBy_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.PayemntTypes);
            if (RowDataSearch.DialogResult == true)
            {

                txtPayementMethodBy.Text = lstResult[1];
                txtPayementMethodBy.Tag = lstResult[0];
            }
        }

        private void txtComBankAccount_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CompanyAccount);
            if (RowDataSearch.DialogResult == true)
            {
                txtComBankAccount.Text = lstResult[0].PadLeft(15, '0');
                txtComBankAccount.Tag = lstResult[6];//Bank Code
                txtComBankAccount.Uid = lstResult[3];//Bank Branch Code
            }
        }

        private void txtPayslipItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.PayslipItems);
            if (RowDataSearch.DialogResult == true)
            {
                txtPayslipItem.Tag = lstResult[0];
                txtPayslipItem.Text = lstResult[2];
            }
        }
        private void txtLeaveTypes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.LeaveTypes);
            if (RowDataSearch.DialogResult == true)
            {
                txtLeaveTypes.Tag = lstResult[0];
                txtLeaveTypes.Text = lstResult[1];
            }
        }

        #endregion

        #region Help Methods
        public void VisibleAllControllers()
        {
            txtEmployee.Visibility = System.Windows.Visibility.Visible;
            txtDivision.Visibility = System.Windows.Visibility.Visible;
            msbDivision.Visibility = Visibility.Visible;
            txtDesignation.Visibility = System.Windows.Visibility.Visible;
            txtDepartment.Visibility = System.Windows.Visibility.Visible;
            txtSection.Visibility = System.Windows.Visibility.Visible;
            txtSubSection.Visibility = System.Windows.Visibility.Visible;
            txtEmpCategory1.Visibility = System.Windows.Visibility.Visible;
            txtEmpCategory2.Visibility = System.Windows.Visibility.Visible;
            txtEmpCategory3.Visibility = System.Windows.Visibility.Visible;
            txtShift.Visibility = System.Windows.Visibility.Visible;
            txtYear.Visibility = System.Windows.Visibility.Visible;
            txtWeek.Visibility = System.Windows.Visibility.Visible;
            txtPayPeriod.Visibility = System.Windows.Visibility.Visible;
            txtPayementMethodBy.Visibility = Visibility.Visible;
            txtComBankAccount.Visibility = Visibility.Visible;
            txtPayslipItem.Visibility = Visibility.Visible;
            stkPayslipPrint.Visibility = Visibility.Visible;
            txtLeaveTypes.Visibility = Visibility.Visible;

            dtp_FromDate.Visibility = System.Windows.Visibility.Visible;
            dtp_ToDate.Visibility = System.Windows.Visibility.Visible;
            cmb_EmpStatus.Visibility = System.Windows.Visibility.Visible;
            cmb_EmpStatus.SetSelectedIndex(cmb_EmpStatus.comboBox.Items.Count - 1);
        }

        public decimal[] GetDenomination(decimal dSalary_Payable)
        {

            decimal dSalary = 0;

            int d5000 = (int)dSalary_Payable / 5000;
            decimal r5000 = dSalary_Payable % 5000;
            dSalary += (d5000 * 5000);

            int d1000 = (int)r5000 / 1000;
            decimal r1000 = r5000 % 1000;
            dSalary += (d1000 * 1000);

            int d500 = (int)r1000 / 500;
            decimal r500 = r1000 % 500;
            dSalary += (d500 * 500);

            int d100 = (int)r500 / 100;
            decimal r100 = r500 % 100;
            dSalary += (d100 * 100);

            int d50 = (int)r100 / 50;
            decimal r50 = r100 % 50;
            dSalary += (d50 * 50);

            int d20 = (int)r50 / 20;
            decimal r20 = r50 % 20;
            dSalary += (d20 * 20);

            int d10 = (int)r20 / 10;
            decimal r10 = r20 % 10;
            dSalary += (d10 * 10);

            int d5 = (int)r10 / 5;
            decimal r5 = r10 % 5;
            dSalary += (d5 * 5);

            int d2 = (int)r5 / 2;
            decimal r2 = r5 % 2;
            dSalary += (d2 * 2);

            int d1 = (int)r2 / 1;
            decimal r1 = r2 % 1;
            dSalary += (d1 * 1);

            int dcent50 = (int)(r1 / 0.5m);
            dSalary += (dcent50 * 0.5m);
            //decimal rCent50 = (r1 % 0.5m);

            decimal[] dnm = { d5000, d1000, d500, d100, d50, d20, d10, d5, d2, d1, dcent50, dSalary };

            return dnm;
        }

        public static List<string> GetEnumDescription(Type enumType)
        {
            List<string> lPeriod = new List<string>();

            foreach (var record in Enum.GetValues(enumType).Cast<Enum>().Select(value => new
            {
                (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                value
            })
        .OrderBy(item => item.value)
        .ToList())
            {
                lPeriod.Add(record.Description);
            }

            lPeriod.Add("<All Status>");
            lPeriod.Add("<All Status Except Resigned>");
            return lPeriod;
        }

        public decimal GetRoudDecimalNerestTen(decimal dNum)
        {
            decimal dNumber = dNum - dNum % 10;
            if (dNum % 10 >= 5)
                dNumber += 10;
            return dNumber;
        }

        private decimal GetRecruitmantCount(string sDepartmant_ID, DateTime dtmDateFrom, DateTime dtmDateTo)
        {
            string sValue = "0";
            try
            {
                sValue = DBHandling.ExecQuery_ReturnStringValue("SELECT count(employee_ID) FROM[tbl_genMasEmployee] where employee_ID <> 'default' and  department_ID ='" + sDepartmant_ID + "' and dateJoin >= '" + dtmDateFrom.Date + "' and dateJoin <= '" + dtmDateTo.Date + "'");
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            return clsValidation.Validate_DecimalNumber(sValue);
        }

        #region Getting column letter in Excel a worksheet
        static string ColumnIndexToColumnLetter(int colIndex)
        {
            int div = colIndex;
            string colLetter = String.Empty;
            int mod = 0;

            while (div > 0)
            {
                mod = (div - 1) % 26;
                colLetter = (char)(65 + mod) + colLetter;
                div = (int)((div - mod) / 26);
            }
            return colLetter;
        }
        #endregion

        private string ConvertMinsToHrsMins(decimal dTotMins)
        {
            decimal dMins = dTotMins % 60;
            decimal dHrs = (dTotMins - dMins) / 60;
            return dHrs.ToString("00") + ":" + dMins.ToString("00");
        }
        #endregion

        #region Date Changed
        private void dtp_FromDate_DateTimeChanged(object sender, EventArgs e)
        {
            if (clsConfig.bEnable_MonthPayrollPeriod)
            {
                DateTime dtFromDate = dtp_FromDate.GetDateTime();
                DateTime dtFirstDate = new DateTime(dtFromDate.Year, dtFromDate.Month, 1);
                DateTime dtLastDate = dtFirstDate.AddMonths(1).AddDays(-1);

                if (dtp_FromDate.GetDateTime().Date == dtFirstDate.Date)
                    dtp_ToDate.SetTime(dtLastDate.Date);
            }
        }

        private void dtp_ToDate_DateTimeChanged(object sender, EventArgs e)
        {
            if (clsConfig.bEnable_MonthPayrollPeriod)
            {
                DateTime dtToDate = dtp_ToDate.GetDateTime();
                DateTime dtFirstDate = new DateTime(dtToDate.Year, dtToDate.Month, 1);
                DateTime dtLastDate = dtFirstDate.AddMonths(1).AddDays(-1);

                if (dtp_ToDate.GetDateTime().Date == dtLastDate.Date)
                    dtp_FromDate.SetTime(dtFirstDate.Date);
            }
        }
        #endregion

    }
}



#region Old Payroll Reports Filters
//		if (bEmployeeSelected)
//    if (txtEmployee.Tag.ToString() != oTxPayRawRecord.Employee_ID)
//        continue;
//if (bDivisionSelected && !msbDivision.IsSelectAll())
//    if (vDivisions.Exists(r => r.Field<string>("id").Trim() != oTxPayRawRecord.Division_ID.Trim()))
//        continue;
//if (bDepartmentSelected)
//    if (txtDepartment.Tag.ToString() != oTxPayRawRecord.Department_ID)
//        continue;
//if (bSectionSelected)
//    if (txtSection.Tag.ToString() != oTxPayRawRecord.SectionID)
//        continue;
//if (bSubSectionSelected)
//    if (txtSubSection.Tag.ToString() != oTxPayRawRecord.SubSectionID)
//        continue;
//if (bDesignationSelected)
//    if (txtDesignation.Tag.ToString() != oTxPayRawRecord.Designation_ID)
//        continue;
//if (bEmpCategory1Selected)
//    if (txtEmpCategory1.Tag.ToString() != oTxPayRawRecord.EmpCatagory1_ID)
//        continue;
//if (bEmpCategory2Selected)
//    if (txtEmpCategory2.Tag.ToString() != oTxPayRawRecord.EmpCatagory2_ID)
//        continue;
//if (bEmpCategory3Selected)
//    if (txtEmpCategory3.Tag.ToString() != oTxPayRawRecord.EmpCatagory3_ID)
//        continue; 
#endregion