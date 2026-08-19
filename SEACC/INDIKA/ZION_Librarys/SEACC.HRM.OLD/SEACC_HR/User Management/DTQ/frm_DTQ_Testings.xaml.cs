using DataTire;
using Digiteq_Logic;
using SEACC_Alert_Engine;
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

namespace Digiteq.User_Management.DTQ
{
    /// <summary>
    /// Interaction logic for frm_DTQ_Testings.xaml
    /// </summary>
    public partial class frm_DTQ_Testings : Window
    {
        public frm_DTQ_Testings()
        {
            InitializeComponent();

            dp_DtqTest.SelectedDate = DateTime.Now;
        }

        private void btn_HeadCountAlert_Click(object sender, RoutedEventArgs e)
        {
            //clsAlerts_Email.CreateEmail_DailyHeadCount(dp_DtqTest.SelectedDate.Value.Date, "", "", SendMailTypes.To);
            clsAlerts_Email.CreateEmail_DailyHeadCount(dp_DtqTest.SelectedDate.Value.Date);
        }

        private void btn_PresenceAlert_Click(object sender, RoutedEventArgs e)
        {
            //clsAlerts_Email.CreateEmail_DailyPresentEmployees_DeptWise(dp_DtqTest.SelectedDate.Value, clsConfig.sAlert_Designation, clsConfig.sAlert_Email_MD , SendMailTypes.To);
            clsAlerts_Email.CreateEmail_DailyPresentEmployees_DeptWise(dp_DtqTest.SelectedDate.Value);
        }

        private void btn_PayrollProcessAlert_Click(object sender, RoutedEventArgs e)
        {
            //clsAlerts_Email.CReateEmail_PayrollProcessed(dp_DtqTest.SelectedDate.Value.Date, "Gayan", "pd_engineer2@digiteq.biz", SendMailTypes.To);
            clsAlerts_Email.CreateEmail_PayrollProcessed(dp_DtqTest.SelectedDate.Value.Date);
        }

        private void btn_EntitleLaveSetUp_Click(object sender, RoutedEventArgs e)
        {

            int iCurrentHRYear_ID = 0;
            DateTime dtmCurrentHRYear_StartDate = clsValidation.defaultDateTime;
            DateTime dtmCurrentHRYear_EndDate = clsValidation.defaultDateTime;

            tbl_hrPeriod_Year oYear = tbl_hrPeriod_Year.SelectAll().Where(r => r.Year_startDate.Date <= DateTime.Now.Date && r.Year_endDate >= DateTime.Now.Date).FirstOrDefault();
            if (oYear != null)
            {
                iCurrentHRYear_ID = oYear.Year_ID;
                dtmCurrentHRYear_StartDate = oYear.Year_startDate.Date;
                dtmCurrentHRYear_EndDate = oYear.Year_endDate.Date;
            }

            
        }

        private void btn_CrossTab_Click(object sender, RoutedEventArgs e)
        {
            DataSets.dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();
            DataSets.dts_PAY glb_dts_PAY = new DataSets.dts_PAY();

            DateTime dtFrom = new DateTime(2018, 01, 01);
            DateTime dtTo = new DateTime(2018, 01, 31);
            List<tbl_payTxSIPRawData> oTxSIP_PayDataRows = tbl_payTxSIPRawData.SelectAllPeriods_ByDateRange(dtFrom.Date, dtTo.Date).Where(r => r.IsPayslip_Print).ToList(); // && r.Department_ID == "DEP/008"

            string sEPF_No = "-";
            foreach (tbl_payTxSIPRawData oPayDataRow in oTxSIP_PayDataRows.OrderBy(o => o.EpfNo.PadLeft(4, '0')))
            {
                sEPF_No = (oPayDataRow.EpfNo == "" || oPayDataRow.EpfNo == "0") ? "-" : oPayDataRow.EpfNo.PadLeft(4, '0');


                tbl_genMasEmployee oEmp = tbl_genMasEmployee.Select(oPayDataRow.Employee_ID, clsSecurity.CompanyID, clsSecurity.BranchID);
                if (oEmp.LastWorkingDate.Date <= dtFrom.Date && oEmp.LastWorkingDate.Date != clsConfig.defaultDateTime.Date)
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
                    oPayDataRow.LateMinutes / 60,
                    clsHelpMethods.GetBaseSalaryForNopay_FromMas(oPayDataRow.Employee_ID) * oPayDataRow.BaseRate_OT / oPayDataRow.DivRate_OT,
                    oPayDataRow.WorkingMinutesAct_OT / 60,
                    clsHelpMethods.GetBaseSalaryForNopay_FromMas(oPayDataRow.Employee_ID) * oPayDataRow.BaseRate_DOT / oPayDataRow.DivRate_DOT,
                    oPayDataRow.WorkingMinutesAct_OT_Dub / 60,
                     clsHelpMethods.GetBaseSalaryForNopay_FromMas(oPayDataRow.Employee_ID) * oPayDataRow.BaseRate_TOT / oPayDataRow.DivRate_TOT,
                    oPayDataRow.WorkingMinutesAct_OT_Trpl / 60,
                    clsRef_Name.get_EmployeeAliasName(oPayDataRow.Employee_ID), clsRef_Name.get_EmployeeName(oPayDataRow.Employee_ID),
                    oPayDataRow.ProcessPeriod_Sub_startDate, oPayDataRow.ProcessPeriod_Sub_endDate);

                    List<tbl_payTxSIPRawData_PaySlipItems> oPayItems = tbl_payTxSIPRawData_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(oPayDataRow.Company_ID, oPayDataRow.CompanyBranch_ID, oPayDataRow.SIP_ID).OrderBy(o => o.LineNo).ToList();
                    oPayItems.ForEach((oPayItem) => glb_dts_PAY.dt_EmpSalaryData_PayslipItems.Rows.Add(oPayItem.SIP_ID, oPayItem.PayItem_ID, clsRef_Name.get_PaySlipItem_Title(oPayItem.PayItem_ID), oPayItem.PayItem_Code, oPayItem.IsEarning, oPayItem.Amount));

                    List<tbl_payTxSIPRawData_PaySlipItems_Statutary> oPayStats = tbl_payTxSIPRawData_PaySlipItems_Statutary.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(oPayDataRow.Company_ID, oPayDataRow.CompanyBranch_ID, oPayDataRow.SIP_ID).Where(r1 => oPayItems.Any(r2 => r2.Company_ID == r1.Company_ID && r2.CompanyBranch_ID == r1.CompanyBranch_ID && r2.SIP_ID == r1.SIP_ID && r2.PayItem_ID == r1.PayItem_ID)).ToList();
                    oPayStats.ForEach((oPayStat) => glb_dts_PAY.dt_EmpSalaryData_PayslipItems_Statutatry.Rows.Add(oPayStat.SIP_ID, oPayStat.PayItem_ID, clsRef_Name.get_PaySlipItems_Statutary_Title(oPayStat.StatutaryPayItem_ID), oPayStat.Percentage, oPayStat.Amount));
                }
            }

            tbl_genCompanyInfo oCompany = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
            glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oCompany.Epf_RegNo, oCompany.Etf_RegNo, oCompany.Payee_RegNo, oCompany.Tax_IdentityNo, "Salary Register Detail", ""
                                  , dtFrom.ToString("MMMM yyyy") , clsSecurity.UserNameLoged, "");

            frm_ReportViwerTest frmViewer = new frm_ReportViwerTest();
            frmViewer.Print("\\Reports\\rpt_SalaryRegisterSummary_AKT_Test.rpt", glb_dts_PAY, glb_dts_ExportReport.dt_rptParameter);

        }
    }
}
