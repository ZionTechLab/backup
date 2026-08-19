using DataTire;
using Digiteq_Logic;
using ZION.PCB.Common;
using ZION.PCB.Search;
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
using ZION.PCB.Reports;
using ZION.PCB;
namespace SEACC_PCB.Reports
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
            SEACC_Form.enmFormName = FormName.pcb_Reports;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            tbl_Reports.Columns.Add("ReportID", typeof(string));
            tbl_Reports.Columns.Add("ReportName", typeof(string));
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(false, false, false, false, false, false);
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
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtPCAccNo, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtUser, true, false, false);

            txtPCAccNo.Tag = null;
            txtUser.Tag = null;

            txtPCAccNo.Text = "<All Petty cash Account No.>";
            txtUser.Text = "<All Users>";

            //dtpFromDate.SetTime(DateTime.Now);
            //dtpToDate.SetTime(DateTime.Now);
                        
            cmbStatus.comboBox.ItemsSource = clsHelpMethods_PCB.GetEnumDescription_List(typeof(ZION.PCB.Common.clsHelpMethods_PCB.pcb_IOUStatus));
            cmbStatus.SetSelectedIndex((int)ZION.PCB.Common.clsHelpMethods_PCB.pcb_IOUStatus.IOUAll);
        }
        #endregion

        #region Refresh Grid
        public void RefreshGrid()
        {
            try
            {
                foreach (tbl_securityFunctionMaster oReports in tbl_securityFunctionMaster.SelectAll().Where(p => p.IsReport && p.IsEnable && p.FunctionCategory_ID == "PCB/025").GroupBy(g => g.FunctionCategory_ID).SelectMany(g => g.OrderBy(o => o.Function_Code)))
                {
                    try
                    {
                        #region Check Permission to View and Add to Grid
                        tbl_securityFunctionMaster_Permission detail = tbl_securityFunctionMaster_Permission.Select(clsSecurity.BranchID, Digiteq_Logic.clsSecurity.UserIDLoged, oReports.Function_ID);
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

                if (Report == enum_ReportName.pcb_ExpenditureSummary)
                {
                    txtPCAccNo.Visibility = Visibility.Visible;
                    txtUser.Visibility = Visibility.Visible;
                    cmbStatus.Visibility = Visibility.Collapsed;
                }
                if (Report == enum_ReportName.pcb_ExpenditureDetails)
                {
                    txtPCAccNo.Visibility = Visibility.Visible;
                    txtUser.Visibility = Visibility.Visible;
                    cmbStatus.Visibility = Visibility.Collapsed;
                }
                if (Report == enum_ReportName.pcb_IOURequstSummary) 
                {
                    txtPCAccNo.Visibility = Visibility.Collapsed;
                    txtUser.Visibility = Visibility.Visible;
                    cmbStatus.Visibility = Visibility.Collapsed;
                }
                if (Report == enum_ReportName.pcb_IOUSummary)
                {
                    txtPCAccNo.Visibility = Visibility.Visible;
                    txtUser.Visibility = Visibility.Visible;
                    cmbStatus.Visibility = Visibility.Visible;
                }
                if (iReportID == 860)
                {
                    txtPCAccNo.Visibility = Visibility.Visible;
                    txtUser.Visibility = Visibility.Collapsed;
                    cmbStatus.Visibility = Visibility.Collapsed;
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

                    tbl_securityFunctionMaster_Permission oRepPermission = tbl_securityFunctionMaster_Permission.Select(clsSecurity.BranchID, clsSecurity.UserIDLoged, iReportID);
                    tbl_securityFunctionMaster_Report oReports = tbl_securityFunctionMaster_Report.Select(iReportID);

                    if (oRepPermission != null && oReports != null)
                    {
                        ZION.PCB.Reports.DataSets.dts_ReportExport glb_dts_ExportReport = new ZION.PCB.Reports.DataSets.dts_ReportExport();

                        string sFilter = string.Empty;
                        bool bPCAccNoSelected = false;
                        bool bUserSelected = false;
                        DateTime dtFrom = dtpFromDate.GetDateTime();
                        DateTime dtTo = dtpToDate.GetDateTime();

                        #region Filters
                        //if (txtPCAccNo.Tag != null)
                        //{
                        //    bPCAccNoSelected = true;
                        //    sFilter = "Petty Cash Account :" + txtPCAccNo.Text.ToString();
                        //}
                        if (txtUser.Tag != null)
                        {
                            bUserSelected = true;
                            sFilter += " Spent By :" + txtUser.Text.ToString();
                        }
                        #endregion

                        #region PCB Reports

                        #region Expenditure Summary
                        if (Report == enum_ReportName.pcb_ExpenditureSummary)
                        {
                            if (txtPCAccNo.Tag != null)
                            {
                                List<tbl_pcbTxExpenditure> oExpenditure;

                                if (bUserSelected)
                                    oExpenditure = tbl_pcbTxExpenditure.SelectAll().Where(p => p.SpentUser_ID == txtUser.Tag.ToString() && p.PcbAccount_ID == txtPCAccNo.Tag.ToString() && p.ExpenditureDate >= dtpFromDate.GetDateTime().Date && p.ExpenditureDate <= dtpToDate.GetDateTime().Date && !p.IsCanceled).ToList();
                                else
                                    oExpenditure = tbl_pcbTxExpenditure.SelectAll().Where(p => p.PcbAccount_ID == txtPCAccNo.Tag.ToString() && p.ExpenditureDate >= dtpFromDate.GetDateTime().Date && p.ExpenditureDate <= dtpToDate.GetDateTime().Date && !p.IsCanceled).ToList();

                                ZION.PCB.Reports.DataSets.dts_PettyCash glb_dts_PettyCash = new ZION.PCB.Reports.DataSets.dts_PettyCash();
                                glb_dts_ExportReport.dt_rptParameter.Clear();
                                string sPCBAccount = "";
                                                                                                
                                foreach (tbl_pcbTxExpenditure oExp in oExpenditure)
                                {
                                    string sIOUID = "";

                                    foreach (tbl_pcbTxIOUSettlement oIOUSet in tbl_pcbTxIOUSettlement.SelectAllByExpenditure_ID(oExp.Expenditure_ID))
                                    {
                                        sIOUID += oIOUSet.Iou_ID + ", ";                                                                          
                                    }
                                    sPCBAccount = clsGenaralName.getName_PCAccount(oExp.PcbAccount_ID);
                                    //glb_dts_PettyCash.dt_Expenditure.Adddt_ExpenditureRow(oExp.Expenditure_ID, oExp.ExpenditureDate, oExp.PcbAccount_ID, clsGenaralName.getName_PCAccount(oExp.PcbAccount_ID),
                                    //    oExp.PcbExpenditureCategory_ID, clsGenaralName.getName_ExpenditureCategory(oExp.PcbExpenditureCategory_ID), oExp.SpentUser_ID, clsGenaralName.getName_User(oExp.SpentUser_ID), oExp.Cost_Center_ID, "", oExp.Amount, oExp.Remarks, sIOUID);
                                    glb_dts_PettyCash.dt_Expenditure.Adddt_ExpenditureRow(oExp.Expenditure_ID, oExp.ExpenditureDate, oExp.PcbAccount_ID, clsGenaralName.getName_PCAccount(oExp.PcbAccount_ID),"","",
                                        oExp.SpentUser_ID, clsGenaralName.getName_User(oExp.SpentUser_ID), oExp.Cost_Center_ID, clsGenaralName.getName_CostCenter1(oExp.Cost_Center_ID), oExp.TotalAmount, oExp.Remarks, sIOUID);
                                }
                                
                                tbl_pcbMasAccount oPCAccount = tbl_pcbMasAccount.Select(txtPCAccNo.Tag.ToString());
                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("FloatAmount", clsFormatter.FormatDecimalPlaces_Price(oPCAccount.FloatAmount), true);

                                decimal UnSetdIOUAmount = 0;
                                foreach (tbl_pcbTxIOU detail in tbl_pcbTxIOU.SelectAll().Where(p => p.Iou_ID != "default" && !p.IsCanceled && !p.IsSettled && p.IouDate >= dtpFromDate.GetDateTime().Date && p.IouDate <= dtpToDate.GetDateTime().Date && p.PcbAccount_ID == txtPCAccNo.Tag.ToString()))
                                {
                                    //UnSetdIOUAmount += detail.IouAmount;
                                    UnSetdIOUAmount += (detail.IouAmount - detail.SettledAmount );
                                }

                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("UnsettledIOUAmount", UnSetdIOUAmount.ToString(), true);

                                glb_dts_PettyCash.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), oReports.DisplayName, sPCBAccount,
                                    "Date Range : From : " + dtpFromDate.GetDateTime().ToShortDateString() + " To : " + dtpToDate.GetDateTime().ToShortDateString(), clsSecurity.UserNameLoged, "Filter : " + sFilter == "" ? "-" : sFilter);

                                frm_ReportViewer rptViwer = new frm_ReportViewer();
                                rptViwer.print(oReports.ReportPath, glb_dts_PettyCash, glb_dts_ExportReport.dt_rptParameter);
                            }
                            else
                                SEACCMessageBox.Show("Oops.... ", "Please Select a Petty Cash Account", MessageBoxButton.OK);
                        }
                        #endregion

                        #region Expenditure Details
                        if (Report == enum_ReportName.pcb_ExpenditureDetails)
                        {
                            if (txtPCAccNo.Tag != null)
                            {
                                List<tbl_pcbTxExpenditure> oExpenditure;

                                if (bUserSelected)
                                    oExpenditure = tbl_pcbTxExpenditure.SelectAll().Where(p => p.SpentUser_ID == txtUser.Tag.ToString() && p.PcbAccount_ID == txtPCAccNo.Tag.ToString() && p.ExpenditureDate >= dtpFromDate.GetDateTime().Date && p.ExpenditureDate <= dtpToDate.GetDateTime().Date && !p.IsCanceled).ToList();
                                else
                                    oExpenditure = tbl_pcbTxExpenditure.SelectAll().Where(p => p.PcbAccount_ID == txtPCAccNo.Tag.ToString() && p.ExpenditureDate >= dtpFromDate.GetDateTime().Date && p.ExpenditureDate <= dtpToDate.GetDateTime().Date && !p.IsCanceled).ToList();

                                ZION.PCB.Reports.DataSets.dts_PettyCash glb_dts_PettyCash = new ZION.PCB.Reports.DataSets.dts_PettyCash();
                                glb_dts_ExportReport.dt_rptParameter.Clear();
                                string sPCBAccount = "";

                                foreach (tbl_pcbTxExpenditure oExp in oExpenditure)
                                {
                                    string sIOUID = "";

                                    foreach (tbl_pcbTxIOUSettlement oIOUSet in tbl_pcbTxIOUSettlement.SelectAllByExpenditure_ID(oExp.Expenditure_ID))
                                    {
                                        sIOUID += oIOUSet.Iou_ID + ", ";
                                    }

                                    foreach (tbl_pcbTxExpenditure_Detail oExpDetails in tbl_pcbTxExpenditure_Detail.SelectAllByExpenditure_ID(oExp.Expenditure_ID))
                                    {
                                        glb_dts_PettyCash.dt_ExpenditureDetail.Adddt_ExpenditureDetailRow(oExp.Expenditure_ID, oExpDetails.PcbExpenditureCategory_ID, clsGenaralName.getName_ExpenditureCategory(oExpDetails.PcbExpenditureCategory_ID), oExpDetails.Remarks, oExpDetails.Amount );
                                    }

                                        sPCBAccount = clsGenaralName.getName_PCAccount(oExp.PcbAccount_ID);

                                    glb_dts_PettyCash.dt_Expenditure.Adddt_ExpenditureRow(oExp.Expenditure_ID, oExp.ExpenditureDate, oExp.PcbAccount_ID, clsGenaralName.getName_PCAccount(oExp.PcbAccount_ID),"","",
                                        oExp.SpentUser_ID, clsGenaralName.getName_User(oExp.SpentUser_ID), oExp.Cost_Center_ID, clsGenaralName.getName_CostCenter1(oExp.Cost_Center_ID), oExp.TotalAmount, oExp.Remarks, sIOUID);
                                }

                                tbl_pcbMasAccount oPCAccount = tbl_pcbMasAccount.Select(txtPCAccNo.Tag.ToString());
                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("FloatAmount", clsFormatter.FormatDecimalPlaces_Price(oPCAccount.FloatAmount), true);

                                decimal UnSetdIOUAmount = 0;
                                foreach (tbl_pcbTxIOU detail in tbl_pcbTxIOU.SelectAll().Where(p => p.Iou_ID != "default" && !p.IsCanceled && !p.IsSettled && p.IouDate >= dtpFromDate.GetDateTime().Date && p.IouDate <= dtpToDate.GetDateTime().Date && p.PcbAccount_ID == txtPCAccNo.Tag.ToString()))
                                {
                                    UnSetdIOUAmount += detail.IouAmount;
                                }

                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("UnsettledIOUAmount", UnSetdIOUAmount.ToString(), true);

                                glb_dts_PettyCash.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), oReports.DisplayName, sPCBAccount,
                                    "Date Range : From : " + dtpFromDate.GetDateTime().ToShortDateString() + " To : " + dtpToDate.GetDateTime().ToShortDateString(), clsSecurity.UserNameLoged, "Filter : " + sFilter == "" ? "-" : sFilter);

                                frm_ReportViewer rptViwer = new frm_ReportViewer();
                                rptViwer.print(oReports.ReportPath, glb_dts_PettyCash, glb_dts_ExportReport.dt_rptParameter);
                            }
                            else
                                SEACCMessageBox.Show("Oops.... ", "Please Select a Petty Cash Account", MessageBoxButton.OK);
                        }
                        #endregion

                        #region IOU Refund Summary
                        if (Report == enum_ReportName.pcb_RefundSummery)
                        {
                            if (txtPCAccNo.Tag != null)
                            {
                                List<tbl_pcbTxIOURefund> oRefund;

                                if (bUserSelected)
                                    oRefund = tbl_pcbTxIOURefund.SelectAll().Where(p => p.User_ID == txtUser.Tag.ToString() && p.PcbAccount_ID == txtPCAccNo.Tag.ToString() && p.RefundDate >= dtpFromDate.GetDateTime().Date && p.RefundDate <= dtpToDate.GetDateTime().Date && !p.IsCanceled).ToList();

                                else
                                    oRefund = tbl_pcbTxIOURefund.SelectAll().Where(p => p.PcbAccount_ID == txtPCAccNo.Tag.ToString() && p.RefundDate >= dtpFromDate.GetDateTime().Date && p.RefundDate <= dtpToDate.GetDateTime().Date && !p.IsCanceled).ToList();

                                ZION.PCB.Reports.DataSets.dts_PettyCash glb_dts_PettyCash = new ZION.PCB.Reports.DataSets.dts_PettyCash();
                                glb_dts_ExportReport.dt_rptParameter.Clear();
                                string sPCBAccount = "";

                                foreach (tbl_pcbTxIOURefund oRef in oRefund)
                                {
                                    string sIOUID = "";

                                    foreach (tbl_pcbTxIOUSettlement oIOUSet in tbl_pcbTxIOUSettlement.SelectAllByRefund_ID(oRef.Refund_ID))
                                    {
                                        sIOUID += oIOUSet.Iou_ID + ", ";
                                    }
                                    sPCBAccount = clsGenaralName.getName_PCAccount(oRef.PcbAccount_ID);

                                    glb_dts_PettyCash.dt_IOURefund.Adddt_IOURefundRow(oRef.Refund_ID, oRef.RefundDate, oRef.PcbAccount_ID, clsGenaralName.getName_PCAccount(oRef.PcbAccount_ID),
                                       oRef.User_ID, clsGenaralName.getName_User(oRef.User_ID), oRef.Amount, oRef.Remarks, sIOUID);
                                }

                                tbl_pcbMasAccount oPCAccount = tbl_pcbMasAccount.Select(txtPCAccNo.Tag.ToString());
                                //glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("FloatAmount", clsFormatter.FormatDecimalPlaces_Price(oPCAccount.FloatAmount), true);

                                decimal UnSetdIOUAmount = 0;
                                foreach (tbl_pcbTxIOU detail in tbl_pcbTxIOU.SelectAll().Where(p => p.Iou_ID != "default" && !p.IsCanceled && !p.IsSettled && p.IouDate >= dtpFromDate.GetDateTime().Date && p.IouDate <= dtpToDate.GetDateTime().Date && p.PcbAccount_ID == txtPCAccNo.Tag.ToString()))
                                {
                                    UnSetdIOUAmount += detail.IouAmount;
                                }

                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("UnsettledIOUAmount", UnSetdIOUAmount.ToString(), true);
                                glb_dts_PettyCash.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), 
                                    oReports.DisplayName, sPCBAccount, "Date Range : From : " + dtpFromDate.GetDateTime().ToShortDateString() + " To : " + dtpToDate.GetDateTime().ToShortDateString(), clsSecurity.UserNameLoged, "Filter : " + sFilter == "" ? "-" : sFilter);

                                frm_ReportViewer rptViwer = new frm_ReportViewer();
                                rptViwer.print(oReports.ReportPath, glb_dts_PettyCash, glb_dts_ExportReport.dt_rptParameter);
                            }
                            else
                                SEACCMessageBox.Show("Oops.... ", "Please Select a Petty Cash Account", MessageBoxButton.OK);
                        }
                        #endregion

                        #region IOU Summary
                        if (Report == enum_ReportName.pcb_IOUSummary)
                        {
                            if (txtPCAccNo.Tag != null)
                            {
                                List<tbl_pcbTxIOU> oIOUs = tbl_pcbTxIOU.SelectAll().Where(p => p.PcbAccount_ID == txtPCAccNo.Tag.ToString() && p.IouDate >= dtpFromDate.GetDateTime().Date && p.IouDate <= dtpToDate.GetDateTime().Date && !p.IsCanceled).ToList();

                                ZION.PCB.Reports.DataSets.dts_PettyCash glb_dts_PettyCash = new ZION.PCB.Reports.DataSets.dts_PettyCash();                                
                                glb_dts_ExportReport.dt_rptParameter.Clear();
                                string sPCBAccount = "";

                                foreach (tbl_pcbTxIOU oIOU in oIOUs)
                                {
                                    #region Filter

                                    if (bUserSelected)
                                    {
                                        if (txtUser.Tag.ToString() != oIOU.IouUser_ID)
                                            continue;
                                    }
                                    if (cmbStatus.GetSelectedIndex() == 1 && !oIOU.IsSettled)
                                        continue;
                                    else if (cmbStatus.GetSelectedIndex() == 2 && oIOU.IsSettled)
                                        continue;

                                    #endregion

                                    //glb_dts_PettyCash.dt_IOU.Adddt_IOURow(oIOU.Iou_ID, oIOU.IouDate, oIOU.PcbAccount_ID, clsGenaralName.getName_PCAccount(oIOU.PcbAccount_ID), oIOU.IouUser_ID, clsGenaralName.getName_User(oIOU.IouUser_ID), "", "", oIOU.IouAmount, oIOU.SettledAmount, oIOU.Remarks, oIOU.IsSettled, "", oIOU.IouDate, "", "", "", "", "", 0, "");
                                    sPCBAccount = clsGenaralName.getName_PCAccount(oIOU.PcbAccount_ID);
                                    glb_dts_PettyCash.dt_IOU.Adddt_IOURow(oIOU.Iou_ID, oIOU.IouDate, oIOU.PcbAccount_ID, clsGenaralName.getName_PCAccount(oIOU.PcbAccount_ID), oIOU.IouUser_ID, clsGenaralName.getName_User(oIOU.IouUser_ID), "", "", oIOU.IouAmount, oIOU.SettledAmount, oIOU.Remarks, oIOU.IsSettled, oIOU.IouRequest_ID);                                       
                                }

                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("Settled", cmbStatus.GetSelectedValue(), true);
                                glb_dts_PettyCash.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), 
                                    oReports.DisplayName, sPCBAccount, "Date Range : From : " + dtpFromDate.GetDateTime().ToShortDateString() + " To : " + dtpToDate.GetDateTime().ToShortDateString(), clsSecurity.UserNameLoged, "Filter : " + sFilter == "" ? "-" : sFilter);

                                frm_ReportViewer rptViwer = new frm_ReportViewer();
                                rptViwer.print(oReports.ReportPath, glb_dts_PettyCash, glb_dts_ExportReport.dt_rptParameter);
                            }
                            else
                                SEACCMessageBox.Show("Oops.... ", "Please Select a Petty Cash Account", MessageBoxButton.OK);
                        }
                        #endregion

                        #region IOU Request Summary
                        if (Report == enum_ReportName.pcb_IOURequstSummary)
                        {
                            List<tbl_pcbTxIOURequest> oRequest;
                            
                            #region Filter                            

                            if (bUserSelected)
                                oRequest = tbl_pcbTxIOURequest.SelectAll().Where(p => p.IouRequestDate >= dtpFromDate.GetDateTime().Date && p.IouRequestDate <= dtpToDate.GetDateTime().Date && !p.IsCanceled && p.IouRequestedUser_ID == txtUser.Tag.ToString()).ToList();
                            else
                                oRequest = tbl_pcbTxIOURequest.SelectAll().Where(p => p.IouRequestDate >= dtpFromDate.GetDateTime().Date && p.IouRequestDate <= dtpToDate.GetDateTime().Date && !p.IsCanceled).ToList();

                            #endregion

                            ZION.PCB.Reports.DataSets.dts_PettyCash glb_dts_PettyCash = new ZION.PCB.Reports.DataSets.dts_PettyCash();
                            glb_dts_PettyCash.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), oReports.DisplayName, oReports.DisplayName2, "Date Range : From : " + dtpFromDate.GetDateTime().ToShortDateString() + " To : " + dtpToDate.GetDateTime().ToShortDateString(), clsSecurity.UserNameLoged, "Filter : " + sFilter == "" ? "-" : sFilter);
                            glb_dts_ExportReport.dt_rptParameter.Clear();

                            foreach (tbl_pcbTxIOURequest oReq in oRequest)
                            {        
                                string sIOUID = "";
                                List<tbl_pcbTxIOU> oIOU = tbl_pcbTxIOU.SelectAllByIouRequest_ID(oReq.IouRequest_ID).ToList();
                                if(oIOU.Count > 0)
                                    sIOUID = oIOU.FirstOrDefault().Iou_ID;

                                //glb_dts_PettyCash.dt_IOU.Adddt_IOURow(sIOUID, oReq.IouRequestDate, "", "", "", "", "", "", 0, 0, "", false, oReq.IouRequest_ID, oReq.IouRequestDate, oReq.IouRequestedUser_ID, clsGenaralName.getName_User(oReq.IouRequestedUser_ID), "", "", oReq.Remarks, oReq.RequestAmount, oReq.IsSettled ? "Settled" : "UnSettled");
                                glb_dts_PettyCash.dt_IOURequest.Adddt_IOURequestRow(oReq.IouRequest_ID, oReq.IouRequestDate, oReq.IouRequestedUser_ID, clsGenaralName.getName_User(oReq.IouRequestedUser_ID), "", "", oReq.Remarks, oReq.RequestAmount, oReq.IsSettled ? "Settled" : "UnSettled", sIOUID);
                            }

                            frm_ReportViewer rptViwer = new frm_ReportViewer();
                            rptViwer.print(oReports.ReportPath, glb_dts_PettyCash, glb_dts_ExportReport.dt_rptParameter);
                        }
                        #endregion


                        if (iReportID == 860)
                        {
                            string sQry = "exec [dbo].[sp_GetRpt_ExpenditureSummary_AccWise] '" + dtpFromDate.GetDateTime().Date + "','" + dtpToDate.GetDateTime().Date + "','"+ txtPCAccNo.Tag.ToString()+"'";
                            DataTable dt_result = DBHandling.ExecQuery(sQry).Tables[0];

                            var ExcelReport = new ExcelReports();
                            ExcelReport.GenerateReport(dt_result, "Expenditure Summary Account Wise", "Date Range : From : " + dtpFromDate.GetDateTime().ToShortDateString() + " To : " + dtpToDate.GetDateTime().ToShortDateString());
                        }
                        #endregion
                    }
                }
                else
                {
                    SEACCMessageBox.Show("Oops.... ", "Please Select a Report You Need", MessageBoxButton.OK);
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
        private void txtPCAccNo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search(false);
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.PCB_PCAccount);
            if (RowDataSearch.DialogResult == true)
            {
                txtPCAccNo.Tag = lstResult[0];
                txtPCAccNo.Text = lstResult[1];
            }
        }

        private void txtUser_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search(false);
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Users);
            if (RowDataSearch.DialogResult == true)
            {
                txtUser.Tag = lstResult[0];
                txtUser.Text = lstResult[1];
            }
        }
        #endregion

        #region Help
        public void VisibleAllControllers()
        {
            txtPCAccNo.Visibility = Visibility.Visible;
            dtpFromDate.Visibility = Visibility.Visible;
            dtpToDate.Visibility = Visibility.Visible;
        }
        #endregion

        

    }
}
