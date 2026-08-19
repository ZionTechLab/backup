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
using SEACC_WPFControls;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Globalization;

namespace SEACC_FACTORING
{
    /// <summary>
    /// Interaction logic for UC_Report.xaml
    /// </summary>
    public partial class UC_Report : UserControl
    {
        #region Class variables
        DataTable tbl_Reports = new DataTable();
        #endregion

        #region Form Load
        public UC_Report()
        {
            InitializeComponent();

            #region Form Initialize
            SEACC_Form.enmFormName = FormName.Report;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            tbl_Reports.Columns.Add("ReportID", typeof(string));
            tbl_Reports.Columns.Add("ReportName", typeof(string));
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(false, false, false, false);
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        #region Clear Fields
        public void ClearFields()
        {
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFactAccNo, true, false, false);

            txtFactAccNo.Tag = null;

            txtFactAccNo.Text = "<All Factoring Account No.>";

            dtpFromDate.SetTime(DateTime.Now);
            dtpToDate.SetTime(DateTime.Now);
        }
        #endregion

        #region Refresh Grid
        public void RefreshGrid()
        {
            try
            {
                foreach (tbl_securityFunctionMaster oReports in tbl_securityFunctionMaster.SelectAll().Where(p => p.IsReport && p.IsEnable).GroupBy(g => g.FunctionCategory_ID).SelectMany(g => g.OrderBy(o => o.Function_Code)))
                {
                    try
                    {
                        #region Check Permission to View and Add to Grid
                        tbl_securityFunctionMaster_Permission detail = tbl_securityFunctionMaster_Permission.Select(Digiteq_Logic.clsSecurity.UserIDLoged, oReports.Function_ID);
                        if (detail != null)
                        {
                            if (detail.AllowView)
                                tbl_Reports.Rows.Add(oReports.Function_ID, oReports.FunctionName);
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                dgv_Reports.ItemsSource = tbl_Reports.DefaultView;
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion

        #region Grid Event
        private void dgv_Reports_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DataRowView view = (sender as DataGrid).SelectedItem as DataRowView;
            if (view != null)
            {
                object[] obj = view.Row.ItemArray;
                int iReportID = int.Parse(obj[0].ToString());

                enum_ReportName Report = (enum_ReportName)iReportID;
                tbl_securityFunctionMaster oFunction = tbl_securityFunctionMaster.Select(iReportID);

                VisibleAllControllers();

                if (Report == enum_ReportName.FactoringDetailsReport || Report == enum_ReportName.FactoringSummaryReport)
                {
                    //txtFactAccNo.Visibility = Visibility.Collapsed;
                    //dtpFromDate.Visibility = Visibility.Collapsed;
                    //dtpToDate.Visibility = Visibility.Collapsed;
                }
                if (Report == enum_ReportName.MarginReport || Report == enum_ReportName.PendingMarginReport || Report == enum_ReportName.FactoringReconcilationReport)
                {
                    txtFactAccNo.Visibility = Visibility.Collapsed;
                    //dtpFromDate.Visibility = Visibility.Collapsed;
                    //dtpToDate.Visibility = Visibility.Collapsed;
                }
            }
        }
        #endregion

        #region Action Button
        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cursor = Cursors.Wait;
                int dgvRowID = dgv_Reports.SelectedIndex;
                if (dgvRowID >= 0)
                {
                    int iReportID = int.Parse(tbl_Reports.Rows[dgvRowID]["ReportID"].ToString());
                    enum_ReportName Report = (enum_ReportName)iReportID;
                    tbl_securityFunctionMaster oFunction = tbl_securityFunctionMaster.Select(iReportID);
                    tbl_securityFunctionMaster_Report oReport = tbl_securityFunctionMaster_Report.Select(iReportID);
                    if (oFunction != null && oReport != null)
                    {
                        DataSets.dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();

                        string sFilter = string.Empty;
                        bool bAccNoSelected = false;
                        DateTime dtFrom = dtpFromDate.GetDateTime();
                        DateTime dtTo = dtpToDate.GetDateTime();

                        #region Filters
                        if (txtFactAccNo.Tag != null)
                        {
                            bAccNoSelected = true;
                            sFilter = "Factoring Account Number :" + txtFactAccNo.Text.ToString();
                        }
                        #endregion

                        #region Factoring Reports
                        if (Report == enum_ReportName.FactoringDetailsReport || Report == enum_ReportName.FactoringSummaryReport)
                        {
                            DataSets.dts_FactoringSchedule glb_dts_FactoringSchedule = new DataSets.dts_FactoringSchedule();
                            glb_dts_FactoringSchedule.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsCript.Decrypt(clsCommon.getComName()), clsCript.Decrypt(clsCommon.getCompanyAddress1()), clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From : " + dtpFromDate.GetDateTime().ToShortDateString() + " To : " + dtpToDate.GetDateTime().ToShortDateString(), clsSecurity.UserNameLoged, "Filter : " + sFilter == "" ? "-" : sFilter);
                            glb_dts_ExportReport.dt_rptParameter.Clear();

                            List<tbl_bpsFactoringAgreement> oAgrement;
                            List<tbl_bpsFactoringSchedule> oSchedule = tbl_bpsFactoringSchedule.SelectAll().Where(p => p.FactoringSeheduleDate >= dtpFromDate.GetDateTime().Date && p.FactoringSeheduleDate <= dtpToDate.GetDateTime().Date && p.IsDeleted == false && p.FactoringSehedule_ID != "Default").ToList();

                            #region Account Filter
                            if (bAccNoSelected)
                                oAgrement = tbl_bpsFactoringAgreement.SelectAll().Where(p => p.AccountNumber_Factoring == txtFactAccNo.Tag.ToString()).ToList();
                            else
                                oAgrement = tbl_bpsFactoringAgreement.SelectAll().ToList();
                            #endregion

                            foreach (tbl_bpsFactoringAgreement oAgrements in oAgrement)
                            {
                                tbl_bpsFactoringInterest oInterest = tbl_bpsFactoringInterest.Select(oAgrements.FactoringInterest_ID);
                                if (oInterest != null)
                                {
                                    foreach (tbl_bpsFactoringSchedule oSchedules in oSchedule.Where(p => p.FactoringAgreement_ID == oAgrements.FactoringAgreement_ID && p.FactoringAgreement_Revision == oAgrements.FactoringAgreement_Revision))
                                    {
                                        glb_dts_FactoringSchedule.dt_FactoringShedule.Adddt_FactoringSheduleRow(oSchedules.FactoringSehedule_ID, oSchedules.FactoringSeheduleDate, oSchedules.Remark, "", "", "", "", "", oSchedules.FaceAmount, oSchedules.FactoringAmount, oSchedules.ServiceCharges, 0, 0, 0, oSchedules.VatTotal, oSchedules.GrossFactoringAmount, oSchedules.PendingAmount, oInterest.Interest_Credit, 0);

                                        foreach (tbl_bpsFactoringSchedule_detail scheDetails in tbl_bpsFactoringSchedule_detail.SelectAllByFactoringSehedule_ID(oSchedules.FactoringSehedule_ID))
                                        {
                                            tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(scheDetails.ChequeRegister_ID);
                                            if (oCheque != null)
                                            {
                                                glb_dts_FactoringSchedule.dt_FactoringShedule_Detail.Adddt_FactoringShedule_DetailRow(scheDetails.FactoringSehedule_ID, scheDetails.ChequeRegister_ID, "", "", "", "", "", "", "", oCheque.ChequeNumber, oCheque.DateCheque,
                                                   scheDetails.NofDays.ToString(), "", scheDetails.ChequeAmount, scheDetails.FactoringRate, scheDetails.FactoringAmount, scheDetails.ServiceCharges, scheDetails.InterestAmount);
                                            }
                                        }
                                    }
                                }
                            }
                            frm_ReportViwer rptViwer = new frm_ReportViwer();
                            rptViwer.Print(oReport.ReportPath, glb_dts_FactoringSchedule, glb_dts_ExportReport.dt_rptParameter);
                        }
                        #endregion

                        #region Factoring Summary Report
                        //if (Report == enum_ReportName.FactoringSummaryReport)
                        //{
                        //    DataSets.dts_FactoringSchedule glb_dts_FactoringSchedule = new DataSets.dts_FactoringSchedule();
                        //    glb_dts_FactoringSchedule.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsCript.Decrypt(clsCommon.getComName()), clsCript.Decrypt(clsCommon.getCompanyAddress1()), clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From : " + dtpFromDate.GetDateTime().ToShortDateString() + " To : " + dtpToDate.GetDateTime().ToShortDateString(), clsSecurity.UserNameLoged, "Filter : " + sFilter == "" ? "-" : sFilter);
                        //    glb_dts_ExportReport.dt_rptParameter.Clear();

                        //    List<tbl_bpsFactoringAgreement> oAgrement;
                        //    List<tbl_bpsFactoringSchedule> oSchedule = tbl_bpsFactoringSchedule.SelectAll().Where(p => p.FactoringSeheduleDate >= dtpFromDate.GetDateTime().Date && p.FactoringSeheduleDate <= dtpToDate.GetDateTime().Date && p.IsDeleted == false && p.FactoringSehedule_ID != "Default").ToList();

                        //    #region Account Filter
                        //    if (bAccNoSelected)
                        //        oAgrement = tbl_bpsFactoringAgreement.SelectAll().Where(p => p.AccountNumber_Factoring == txtFactAccNo.Tag.ToString()).ToList();
                        //    else
                        //        oAgrement = tbl_bpsFactoringAgreement.SelectAll().ToList();
                        //    #endregion

                        //    foreach (tbl_bpsFactoringAgreement oAgrements in oAgrement)
                        //    {
                        //        tbl_bpsFactoringInterest oInterest = tbl_bpsFactoringInterest.Select(oAgrements.FactoringInterest_ID);
                        //        if (oInterest != null)
                        //        {
                        //            foreach (tbl_bpsFactoringSchedule oSchedules in oSchedule.Where(p => p.FactoringAgreement_ID == oAgrements.FactoringAgreement_ID && p.FactoringAgreement_Revision == oAgrements.FactoringAgreement_Revision))
                        //            {
                        //                //glb_dts_FactoringSchedule.dt_FactoringShedule.Adddt_FactoringSheduleRow(oSchedules.FactoringSehedule_ID, oSchedules.FactoringSeheduleDate, oSchedules.Remark, "", "", "", "", "", oSchedules.FaceAmount, oSchedules.FactoringAmount, oSchedules.ServiceCharges, 0, 0, 0, oSchedules.VatTotal, oSchedules.GrossFactoringAmount, oSchedules.PendingAmount, oInterest.Interest_Credit);
                        //            }
                        //        }
                        //    }

                        //    frm_ReportViwer rptViwer = new frm_ReportViwer();
                        //    rptViwer.Print(oReport.ReportPath, glb_dts_FactoringSchedule, glb_dts_ExportReport.dt_rptParameter);
                        //}
                        #endregion

                        #region Margin Report
                        if (Report == enum_ReportName.MarginReport)
                        {
                            DataSets.dts_FactoringSchedule glb_dts_FactoringSchedule = new DataSets.dts_FactoringSchedule();
                            glb_dts_FactoringSchedule.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsCript.Decrypt(clsCommon.getComName()), clsCript.Decrypt(clsCommon.getCompanyAddress1()), clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From : " + dtpFromDate.GetDateTime().ToShortDateString() + " To : " + dtpToDate.GetDateTime().ToShortDateString(), clsSecurity.UserNameLoged, "Filter : " + sFilter == "" ? "-" : sFilter);
                            glb_dts_ExportReport.dt_rptParameter.Clear();

                            List<tbl_bpsFactoringSchedule> oSchedule = tbl_bpsFactoringSchedule.SelectAll().Where(p => p.FactoringSeheduleDate >= dtpFromDate.GetDateTime().Date && p.FactoringSeheduleDate <= dtpToDate.GetDateTime().Date && p.IsDeleted == false && p.FactoringSehedule_ID != "Default").ToList();

                            foreach (tbl_bpsFactoringSchedule oSchedules in oSchedule)
                            {
                                glb_dts_FactoringSchedule.dt_FactoringShedule.Adddt_FactoringSheduleRow(oSchedules.FactoringSehedule_ID, oSchedules.FactoringSeheduleDate, oSchedules.Remark, "", "", "", "", "", oSchedules.FaceAmount, oSchedules.FactoringAmount, oSchedules.ServiceCharges, 0, 0, 0, oSchedules.VatTotal, oSchedules.GrossFactoringAmount, oSchedules.PendingAmount, 0, 0);
                                foreach (tbl_bpsFactoringSchedule_detail scheDetails in tbl_bpsFactoringSchedule_detail.SelectAllByFactoringSehedule_ID(oSchedules.FactoringSehedule_ID))
                                {
                                    tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(scheDetails.ChequeRegister_ID);
                                    if (oCheque != null)
                                    {
                                        glb_dts_FactoringSchedule.dt_FactoringShedule_Detail.Adddt_FactoringShedule_DetailRow(scheDetails.FactoringSehedule_ID, scheDetails.ChequeRegister_ID, "", "", "", "", "", "", "", oCheque.ChequeNumber, oCheque.DateCheque, scheDetails.NofDays.ToString(), "", scheDetails.ChequeAmount, scheDetails.FactoringRate, scheDetails.FactoringAmount, scheDetails.ServiceCharges, scheDetails.InterestAmount);
                                    }
                                }
                            }

                            frm_ReportViwer rptViwer = new frm_ReportViwer();
                            rptViwer.Print(oReport.ReportPath, glb_dts_FactoringSchedule, glb_dts_ExportReport.dt_rptParameter);
                        }
                        #endregion

                        #region Pending Margin Report
                        if (Report == enum_ReportName.PendingMarginReport)
                        {
                            DataSets.dts_FactoringSchedule glb_dts_FactoringSchedule = new DataSets.dts_FactoringSchedule();
                            glb_dts_FactoringSchedule.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsCript.Decrypt(clsCommon.getComName()), clsCript.Decrypt(clsCommon.getCompanyAddress1()), clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From : " + dtpFromDate.GetDateTime().ToShortDateString() + " To : " + dtpToDate.GetDateTime().ToShortDateString(), clsSecurity.UserNameLoged, "Filter : " + sFilter == "" ? "-" : sFilter);
                            glb_dts_ExportReport.dt_rptParameter.Clear();

                            List<tbl_bpsFactoringSchedule> oSchedule = tbl_bpsFactoringSchedule.SelectAll().Where(p => p.FactoringSeheduleDate >= dtpFromDate.GetDateTime().Date && p.FactoringSeheduleDate <= dtpToDate.GetDateTime().Date && p.IsDeleted == false && p.FactoringSehedule_ID != "Default").ToList();

                            foreach (tbl_bpsFactoringSchedule oSchedules in oSchedule)
                            {
                                glb_dts_FactoringSchedule.dt_FactoringShedule.Adddt_FactoringSheduleRow(oSchedules.FactoringSehedule_ID, oSchedules.FactoringSeheduleDate, oSchedules.Remark, "", "", "", "", "", oSchedules.FaceAmount, oSchedules.FactoringAmount, oSchedules.ServiceCharges, 0, 0, 0, oSchedules.VatTotal, oSchedules.GrossFactoringAmount, oSchedules.PendingAmount, 0, 0);

                                foreach (tbl_bpsFactoringSchedule_detail scheDetails in tbl_bpsFactoringSchedule_detail.SelectAllByFactoringSehedule_ID(oSchedules.FactoringSehedule_ID))
                                {
                                    tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(scheDetails.ChequeRegister_ID);
                                    if (oCheque != null)
                                    {
                                        glb_dts_FactoringSchedule.dt_FactoringShedule_Detail.Adddt_FactoringShedule_DetailRow(scheDetails.FactoringSehedule_ID, scheDetails.ChequeRegister_ID, "", "", "", "", "", "", "", oCheque.ChequeNumber, oCheque.DateCheque, scheDetails.NofDays.ToString(), "", scheDetails.ChequeAmount, scheDetails.FactoringRate, scheDetails.FactoringAmount, scheDetails.ServiceCharges, scheDetails.InterestAmount);
                                    }
                                }
                            }

                            frm_ReportViwer rptViwer = new frm_ReportViwer();
                            rptViwer.Print(oReport.ReportPath, glb_dts_FactoringSchedule, glb_dts_ExportReport.dt_rptParameter);
                        }
                        #endregion

                        #region Factoring Reconciliation Report
                        if (Report == enum_ReportName.FactoringReconcilationReport)
                        {
                            DataSets.dts_FactoringSchedule glb_dts_FactoringSchedule = new DataSets.dts_FactoringSchedule();
                            glb_dts_FactoringSchedule.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsCript.Decrypt(clsCommon.getComName()), clsCript.Decrypt(clsCommon.getCompanyAddress1()), clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "Date Range : From : " + dtpFromDate.GetDateTime().ToShortDateString() + " To : " + dtpToDate.GetDateTime().ToShortDateString(), clsSecurity.UserNameLoged, "Filter : " + sFilter == "" ? "-" : sFilter);
                            glb_dts_ExportReport.dt_rptParameter.Clear();

                            List<tbl_bpsFactoringSchedule> oSchedule = tbl_bpsFactoringSchedule.SelectAll().Where(p => p.FactoringSeheduleDate >= dtpFromDate.GetDateTime().Date && p.FactoringSeheduleDate <= dtpToDate.GetDateTime().Date && p.IsDeleted == false && p.FactoringSehedule_ID != "Default").ToList();

                            foreach (tbl_bpsFactoringSchedule oSchedules in oSchedule)
                            {
                                tbl_bpsFactoringAgreement oAgrement = tbl_bpsFactoringAgreement.Select(oSchedules.FactoringAgreement_ID, oSchedules.FactoringAgreement_Revision);
                                tbl_bpsFactoringInterest oInterest = tbl_bpsFactoringInterest.Select(oAgrement.FactoringInterest_ID);
                                tbl_bpsFactoringSchedule_detail oScheDetails = tbl_bpsFactoringSchedule_detail.Select(oSchedules.FactoringAgreement_ID, oSchedules.FactoringAgreement_Revision);
                                if (oScheDetails != null)
                                {
                                    glb_dts_FactoringSchedule.dt_FactoringShedule.Adddt_FactoringSheduleRow(oSchedules.FactoringSehedule_ID, oSchedules.FactoringSeheduleDate, oSchedules.Remark, "", "", "", "", "", oSchedules.FaceAmount, oSchedules.FactoringAmount, oSchedules.ServiceCharges, 0, 0, 0, 0, oSchedules.GrossFactoringAmount, oSchedules.PendingAmount, 0, oScheDetails.InterestAmount);
                                }
                            }
                            frm_ReportViwer rptViwer = new frm_ReportViwer();
                            rptViwer.Print(oReport.ReportPath, glb_dts_FactoringSchedule, glb_dts_ExportReport.dt_rptParameter);
                        }
                        #endregion
                    }
                }
                else
                {
                    SEACCMessageBox.Show("Oops.... ", "Please Select a Report You Need", MessageBoxButton.OKCancel);
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

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        } 
        #endregion
                    
        #region Search
        private void txtFactAccNo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch frm = new Search_Forms.frmSearch();
            List<string> lstResult = frm.Show(Search.CompanyAccount);
            if (frm.DialogResult == true)
            {
                txtFactAccNo.Text = lstResult[0];
                txtFactAccNo.Tag = lstResult[0];
            }
        }
        #endregion

        #region Help
        public void VisibleAllControllers()
        {
            txtFactAccNo.Visibility = Visibility.Visible;
            dtpFromDate.Visibility = Visibility.Visible;
            dtpToDate.Visibility = Visibility.Visible;
        } 
        #endregion
    }
}