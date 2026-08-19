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
using DataTire;
using SEACC_servii.Reports;
using SEACC_servii.Search_Forms;

namespace SEACC_servii
{
    /// <summary>
    /// Interaction logic for UC_Report.xaml
    /// </summary>
    public partial class UC_Report : UserControl
    {
        #region Class variables
        DataTable tbl_Reports = new DataTable();
        DataSets.dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();
        #endregion

        #region Form Load
        public UC_Report()
        {           
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Report;
            SEACC_Form.Initialize();

            #region  #region Initialize Data Table
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

        #region Form Responsive        
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomer, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtStore, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtItem, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtGrn, true, false, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtp_FromDate, true, true);
            cls_Formater.SetEnableDisable_LableTimePicker(dtp_ToDate, true, true);

            txtCustomer.Tag = null;
            txtStore.Tag = null;
            txtItem.Tag = null;
            txtGrn.Tag = null;

            txtCustomer.Text = "<All Customers>";
            txtStore.Text = "<All Stores>";
            txtItem.Text = "<All Items>";
            txtGrn.Text = "<All GRNs>";

            dtp_FromDate.SetTime(DateTime.Now);
            dtp_ToDate.SetTime(DateTime.Now);

        }
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
               
                int irowID = dgv_Reports.SelectedIndex;
                if (irowID >= 0)
                {
                    int iReportID = int.Parse(tbl_Reports.Rows[irowID]["ReportID"].ToString());
                    enum_ReportName Report = (enum_ReportName)iReportID;
                    tbl_securityFunctionMaster_Report oReports = tbl_securityFunctionMaster_Report.Select((iReportID));
                    if (oReports != null)
                    {
                        glb_dts_ExportReport.dt_rptParameter.Clear();

                        string sFilter = string.Empty;
                            bool bCustomerSelected= false;
                            bool bStoreSelected = false;
                            bool bItemSelected = false;
                            bool bGrnSelected = false;

                        DateTime dtmFromDate = dtp_FromDate.GetDateTime();
                        DateTime dtmToDate = dtp_ToDate.GetDateTime();

                        #region Filters
                        if (txtCustomer.Tag != null)
                        {
                            bCustomerSelected = true;
                            sFilter += "Customer : " + txtCustomer.Text.ToString();
                        }

                        if (txtStore.Tag != null)
                        {
                            bStoreSelected = true;
                            sFilter += "Store : " + txtStore.Text.ToString();
                        }

                        if (txtItem.Tag != null)
                        {
                            bItemSelected = true;
                            sFilter += "Item : " + txtItem.Text.ToString();
                        }

                        if (txtGrn.Tag != null)
                        {
                            bGrnSelected = true;
                            sFilter += "GRN : " + txtGrn.Text.ToString();
                        }
                        #endregion

                                                
                        #region GRN Summery     
                        if (Report == enum_ReportName.GRNSummary)
                        {
                            DataSets.dts_GRN dts_Grn = new DataSets.dts_GRN();
                            dts_Grn.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReports.DisplayName, oReports.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date), clsSecurity.UserNameLoged, sFilter);


                            #region Filters
                                                       
                            #region Store Filter
                            List<tbl_genStoreMaster> oStore;
                            if (bStoreSelected)
                            {
                                oStore = new List<tbl_genStoreMaster>();
                                oStore.Add(tbl_genStoreMaster.Select(txtStore.Tag.ToString()));
                            }
                            else
                                oStore = tbl_genStoreMaster.SelectAll().ToList();
                            #endregion

                            #endregion

                            foreach (tbl_genStoreMaster oSt in oStore)
                            {
                                foreach (tbl_whTxn_GoodReceivedNote oGRN in tbl_whTxn_GoodReceivedNote.SelectAllByStore_ID(oSt.Store_ID).Where(d => d.GoodReceivedNote_Date.Date >= dtmFromDate.Date && d.GoodReceivedNote_Date.Date <= dtmToDate.Date).ToList())
                                {
                                    tbl_whTxn_VehicleTracker veh = tbl_whTxn_VehicleTracker.Select(oGRN.VehicleTracking_ID);

                                    List<tbl_whTxn_GoodReceivedNote_Detail> oGRN_Det = tbl_whTxn_GoodReceivedNote_Detail.SelectAllByGoodReceivedNote_ID(oGRN.GoodReceivedNote_ID);
                                    if (bItemSelected)
                                        oGRN_Det = oGRN_Det.Where(p => p.Item_ID == txtItem.Tag.ToString()).ToList();

                                    foreach (tbl_whTxn_GoodReceivedNote_Detail oGrnDetail in oGRN_Det)
                                    {                                      
                                        dts_Grn.dt_Grn_Register.Adddt_Grn_RegisterRow(oGrnDetail.GoodReceivedNote_ID, oGRN.GoodReceivedNote_Date, oGRN.Estimation_ID, oGRN.Customer_ID, clsRef_Name.get_Customer_Name(oGRN.Customer_ID), clsRef_Name.get_Customer_Address(oGRN.Customer_ID), clsCommon.getStoragePeriod(((StoragePeriod)oGRN.Storage_Period)), oGRN.Remarks, oGrnDetail.Item_ID, clsRef_Name.get_Item_Name(oGrnDetail.Item_ID), oGrnDetail.Qty, oGrnDetail.UnitWeight, oGrnDetail.GrossWeight, veh.Vehicle_No,veh.CheckinTime, veh.CheckoutTime, veh.Container_No, oGRN.UserID_Created, oGrnDetail.Qty-oGrnDetail.QtySettle, oSt.Store_ID, clsRef_Name.get_Store_Name(oSt.Store_ID), int.Parse(((clsSecurity.getServerDateTime().Date - oGRN.GoodReceivedNote_Date.Date).TotalDays).ToString()), oGrnDetail.QtySettle );
                                    }                                   
                                }
                            }

                            frm_ReportViwer CRViwer = new frm_ReportViwer();
                            CRViwer.Print(oReports.ReportPath, dts_Grn, glb_dts_ExportReport.dt_rptParameter);
                        }

                        #endregion

                        #region GRN Summery Customer Wise   
                        if (Report == enum_ReportName.GRNSummaryCustomerWise)
                        {
                            DataSets.dts_GRN dts_Grn = new DataSets.dts_GRN();
                            dts_Grn.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReports.DisplayName, oReports.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date), clsSecurity.UserNameLoged, sFilter);


                            #region Filters

                            #region Customer Filter
                            List<tbl_genCustomerMaster> oCustomer;
                            if (bCustomerSelected)
                            {
                                oCustomer = new List<tbl_genCustomerMaster>();
                                oCustomer.Add(tbl_genCustomerMaster.Select(txtCustomer.Tag.ToString()));
                            }
                            else
                                oCustomer = tbl_genCustomerMaster.SelectAll().ToList();
                            #endregion
                                                        
                            #endregion

                            foreach (tbl_genCustomerMaster oCust in oCustomer)
                            {                                                                                                                       
                                foreach (tbl_whTxn_GoodReceivedNote oGRN in tbl_whTxn_GoodReceivedNote.SelectAllByCustomer_ID(oCust.Customer_ID).Where(d => d.GoodReceivedNote_Date.Date >= dtmFromDate.Date && d.GoodReceivedNote_Date.Date <= dtmToDate.Date).ToList())
                                {
                                    tbl_whTxn_VehicleTracker veh = tbl_whTxn_VehicleTracker.Select(oGRN.VehicleTracking_ID);

                                    List<tbl_whTxn_GoodReceivedNote_Detail> oGRN_Det = tbl_whTxn_GoodReceivedNote_Detail.SelectAllByGoodReceivedNote_ID(oGRN.GoodReceivedNote_ID);
                                    if (bItemSelected)
                                        oGRN_Det = oGRN_Det.Where(p => p.Item_ID == txtItem.Tag.ToString()).ToList();

                                    foreach (tbl_whTxn_GoodReceivedNote_Detail oGrnDetail in oGRN_Det)
                                    {
                                        dts_Grn.dt_Grn_Register.Adddt_Grn_RegisterRow(oGrnDetail.GoodReceivedNote_ID, oGRN.GoodReceivedNote_Date, oGRN.Estimation_ID, oGRN.Customer_ID, clsRef_Name.get_Customer_Name(oGRN.Customer_ID), clsRef_Name.get_Customer_Address(oGRN.Customer_ID), clsCommon.getStoragePeriod(((StoragePeriod)oGRN.Storage_Period)), oGRN.Remarks, oGrnDetail.Item_ID, clsRef_Name.get_Item_Name(oGrnDetail.Item_ID), oGrnDetail.Qty, oGrnDetail.UnitWeight, oGrnDetail.GrossWeight, veh.Vehicle_No, veh.CheckinTime, veh.CheckoutTime, veh.Container_No, oGRN.UserID_Created, oGrnDetail.Qty - oGrnDetail.QtySettle, oGRN.Store_ID, clsRef_Name.get_Store_Name(oGRN.Store_ID), int.Parse(((clsSecurity.getServerDateTime().Date - oGRN.GoodReceivedNote_Date.Date).TotalDays).ToString()), oGrnDetail.QtySettle);
                                    }
                                }
                            }

                            frm_ReportViwer CRViwer = new frm_ReportViwer();
                            CRViwer.Print(oReports.ReportPath, dts_Grn, glb_dts_ExportReport.dt_rptParameter);
                        }

                        #endregion

                        #region GIN  Summery    
                        if (Report == enum_ReportName.GINSummary)
                        {
                            DataSets.dts_GIN dts_Gin = new DataSets.dts_GIN();
                            dts_Gin.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReports.DisplayName, oReports.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date), clsSecurity.UserNameLoged, sFilter);
                                                        
                            List<tbl_whTxn_GoodIssueNote> oGINs = tbl_whTxn_GoodIssueNote.SelectAll().Where(d=>d.GoodIssueNote_Date.Date >= dtmFromDate.Date && d.GoodIssueNote_Date.Date <= dtmToDate.Date).ToList();
                            if (bStoreSelected)
                                oGINs = oGINs.Where(p => p.Store_ID == txtStore.Tag.ToString()).ToList();
                            
                            foreach (tbl_whTxn_GoodIssueNote oGIN in oGINs)
                            {
                                tbl_whTxn_VehicleTracker oveh = tbl_whTxn_VehicleTracker.Select(oGIN.VehicleTracking_ID);
                                
                                List<tbl_whTxn_GoodIssueNote_Detail> oGIN_Details = tbl_whTxn_GoodIssueNote_Detail.SelectAllByGoodIssueNote_ID(oGIN.GoodIssueNote_ID);
                                if (bItemSelected)
                                    oGIN_Details = oGIN_Details.Where(p => p.Item_ID == txtItem.Tag.ToString()).ToList();

                                foreach (tbl_whTxn_GoodIssueNote_Detail oGinDetail in oGIN_Details)
                                {
                                    tbl_whTxn_GoodReceivedNote ogrn = tbl_whTxn_GoodReceivedNote.Select(oGinDetail.GoodReceivedNote_ID);

                                    tbl_whTxn_GoodReceivedNote_Detail oGRN_details = tbl_whTxn_GoodReceivedNote_Detail.SelectAllByGoodReceivedNote_ID(oGinDetail.GoodReceivedNote_ID).Where(p=> p.Item_ID==oGinDetail.Item_ID).FirstOrDefault();
                                    dts_Gin.dt_Gin_Register.Adddt_Gin_RegisterRow(oGIN.GoodIssueNote_ID, oGIN.GoodIssueNote_Date, oGIN.Estimation_ID, oGIN.Customer_ID, clsRef_Name.get_Customer_Name(oGIN.Customer_ID), clsRef_Name.get_Customer_Address(oGIN.Customer_ID), ogrn.GoodReceivedNote_Date, oGinDetail.GoodReceivedNote_ID, clsCommon.getStoragePeriod(((StoragePeriod)ogrn.Storage_Period)), oGIN.Remarks, oGinDetail.Item_ID, clsRef_Name.get_Item_Name(oGinDetail.Item_ID), oGinDetail.Qty, oGIN.Store_ID, clsRef_Name.get_Store_Name(oGIN.Store_ID), oveh.Vehicle_No, oveh.CheckinTime, oveh.CheckoutTime, oveh.Container_No, oGIN.UserID_Created, oGRN_details.Qty, oGRN_details.Qty- oGRN_details.QtySettle);
                                }
                            }
                            frm_ReportViwer CRViwer = new frm_ReportViwer();
                            CRViwer.Print(oReports.ReportPath, dts_Gin, glb_dts_ExportReport.dt_rptParameter);

                                                        
                            //#region Filters
                            //#region Employee Filter
                            //List<tbl_genCustomerMaster> oCustomer;
                            //if (bCustomerSelected)
                            //{
                            //    oCustomer = new List<tbl_genCustomerMaster>();
                            //    oCustomer.Add(tbl_genCustomerMaster.Select(txtCustomer.Tag.ToString()));
                            //}
                            //else
                            //    oCustomer = tbl_genCustomerMaster.SelectAll().ToList();
                            //#endregion
                            //#region Store Filter
                            //List<tbl_genStoreMaster> oStore;
                            //if (bStoreSelected)
                            //{
                            //    oStore = new List<tbl_genStoreMaster>();
                            //    oStore.Add(tbl_genStoreMaster.Select(txtStore.Tag.ToString()));
                            //}
                            //else
                            //    oStore = tbl_genStoreMaster.SelectAll().ToList();
                            //#endregion
                            //#endregion

                            //foreach (tbl_genCustomerMaster oCust in oCustomer)
                            //{
                            //    foreach (tbl_whTxn_GoodIssueNote oGIN in tbl_whTxn_GoodIssueNote.SelectAllByCustomer_ID(oCust.Customer_ID))
                            //    {
                            //        tbl_whTxn_VehicleTracker veh = tbl_whTxn_VehicleTracker.Select(oGIN.VehicleTracking_ID);
                            //        tbl_whTxn_GoodReceivedNote grn = tbl_whTxn_GoodReceivedNote.Select(oGIN.GoodReceivedNote_ID);

                            //        foreach (tbl_whTxn_GoodIssueNote_Detail oGinDetail in tbl_whTxn_GoodIssueNote_Detail.SelectAllByGoodIssueNote_ID(oGIN.GoodIssueNote_ID))
                            //        {
                            //            dts_Gin.dt_Gin_Register.Adddt_Gin_RegisterRow(oGIN.GoodIssueNote_ID, oGIN.GoodIssueNote_Date, oGIN.Estimation_ID, oGIN.Customer_ID, oGIN.Customer_ID, oGIN.Customer_ID, grn.GoodReceivedNote_Date, oGIN.GoodReceivedNote_ID, ((StoragePeriod)oGIN.Storage_Period).ToString(), oGIN.Remarks, oGinDetail.Item_ID, clsRef_Name.get_Item_Name(oGinDetail.Item_ID), oGinDetail.Qty, oGIN.Store_ID, clsRef_Name.get_Store_Name(oGIN.Store_ID), veh.Vehicle_No, veh.CheckinTime, veh.CheckoutTime, veh.Container_No, oGIN.UserID_Created, oGinDetail.Qty);
                            //        }

                            //    }
                            //}

                            //frm_ReportViwer CRViwer = new frm_ReportViwer();
                            //CRViwer.Print(oReports.ReportPath, dts_Gin, glb_dts_ExportReport.dt_rptParameter);

                        }
                        #endregion

                        #region GIN  Summery Customer Wise   
                        if (Report == enum_ReportName.GINSummaryCustomerWise)
                        {
                            DataSets.dts_GIN dts_Gin = new DataSets.dts_GIN();
                            dts_Gin.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReports.DisplayName, oReports.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date), clsSecurity.UserNameLoged, sFilter);

                            List<tbl_whTxn_GoodIssueNote> oGINs = tbl_whTxn_GoodIssueNote.SelectAll().Where(d => d.GoodIssueNote_Date.Date >= dtmFromDate.Date && d.GoodIssueNote_Date.Date <= dtmToDate.Date).ToList();
                            if (bCustomerSelected)
                                oGINs = oGINs.Where(p => p.Customer_ID == txtCustomer.Tag.ToString()).ToList();

                            foreach (tbl_whTxn_GoodIssueNote oGIN in oGINs)
                            {
                                tbl_whTxn_VehicleTracker oveh = tbl_whTxn_VehicleTracker.Select(oGIN.VehicleTracking_ID);

                                List<tbl_whTxn_GoodIssueNote_Detail> oGIN_Details = tbl_whTxn_GoodIssueNote_Detail.SelectAllByGoodIssueNote_ID(oGIN.GoodIssueNote_ID);
                                //if (bItemSelected)
                                //    oGIN_Details = oGIN_Details.Where(p => p.Item_ID == txtItem.Tag.ToString()).ToList();

                                foreach (tbl_whTxn_GoodIssueNote_Detail oGinDetail in oGIN_Details)
                                {
                                    tbl_whTxn_GoodReceivedNote ogrn = tbl_whTxn_GoodReceivedNote.Select(oGinDetail.GoodReceivedNote_ID);

                                    tbl_whTxn_GoodReceivedNote_Detail oGRN_details = tbl_whTxn_GoodReceivedNote_Detail.SelectAllByGoodReceivedNote_ID(oGinDetail.GoodReceivedNote_ID).Where(p => p.Item_ID == oGinDetail.Item_ID).FirstOrDefault();
                                    dts_Gin.dt_Gin_Register.Adddt_Gin_RegisterRow(oGIN.GoodIssueNote_ID, oGIN.GoodIssueNote_Date, oGIN.Estimation_ID, oGIN.Customer_ID, clsRef_Name.get_Customer_Name(oGIN.Customer_ID), clsRef_Name.get_Customer_Address(oGIN.Customer_ID), ogrn.GoodReceivedNote_Date, oGinDetail.GoodReceivedNote_ID, clsCommon.getStoragePeriod(((StoragePeriod)ogrn.Storage_Period)), oGIN.Remarks, oGinDetail.Item_ID, clsRef_Name.get_Item_Name(oGinDetail.Item_ID), oGinDetail.Qty, oGIN.Store_ID, clsRef_Name.get_Store_Name(oGIN.Store_ID), oveh.Vehicle_No, oveh.CheckinTime, oveh.CheckoutTime, oveh.Container_No, oGIN.UserID_Created, oGRN_details.Qty, oGRN_details.Qty - oGRN_details.QtySettle);
                                }
                            }
                            frm_ReportViwer CRViwer = new frm_ReportViwer();
                            CRViwer.Print(oReports.ReportPath, dts_Gin, glb_dts_ExportReport.dt_rptParameter);
                                                        
                        }
                        #endregion

                        #region GRN Stock Summery 
                        if (Report == enum_ReportName.GRNStockSummery)
                        {
                            DataSets.dts_GRN dts_Grn = new DataSets.dts_GRN();
                            dts_Grn.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReports.DisplayName, oReports.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date), clsSecurity.UserNameLoged, sFilter);
                            
                            List<tbl_whTxn_GoodReceivedNote> oGRNs = tbl_whTxn_GoodReceivedNote.SelectAll().Where(d => d.GoodReceivedNote_Date.Date >= dtmFromDate.Date && d.GoodReceivedNote_Date.Date <= dtmToDate.Date).ToList();
                            if (bCustomerSelected)
                                oGRNs = oGRNs.Where(p => p.Customer_ID == txtCustomer.Tag.ToString()).ToList();
                            if (bStoreSelected)
                                oGRNs = oGRNs.Where(p => p.Store_ID == txtStore.Tag.ToString()).ToList();                            
                            if (bGrnSelected)
                                oGRNs = oGRNs.Where(p => p.GoodReceivedNote_ID == txtGrn.Tag.ToString()).ToList();

                            foreach (tbl_whTxn_GoodReceivedNote oGRN in oGRNs)
                            {                               
                                List<tbl_whTxn_GoodReceivedNote_Detail> oGRN_Details = tbl_whTxn_GoodReceivedNote_Detail.SelectAllByGoodReceivedNote_ID(oGRN.GoodReceivedNote_ID);
                                if (bItemSelected)
                                    oGRN_Details = oGRN_Details.Where(p => p.Item_ID == txtItem.Tag.ToString()).ToList();

                                foreach (tbl_whTxn_GoodReceivedNote_Detail oGrnDetail in oGRN_Details)
                                {
                                    tbl_whTxn_GoodReceivedNote_Detail oGRN_details = tbl_whTxn_GoodReceivedNote_Detail.SelectAllByGoodReceivedNote_ID(oGrnDetail.GoodReceivedNote_ID).Where(p => p.Item_ID == oGrnDetail.Item_ID).FirstOrDefault();
                                    dts_Grn.dt_Floor_Stock.Adddt_Floor_StockRow(oGRN.GoodReceivedNote_Date, oGRN.GoodReceivedNote_ID, oGRN.Customer_ID, clsRef_Name.get_Customer_Name(oGRN.Customer_ID), oGRN.Store_ID, clsRef_Name.get_Store_Name(oGRN.Store_ID), oGRN_details.Item_ID, clsRef_Name.get_Item_Name(oGRN_details.Item_ID), oGRN_details.Qty, oGRN_details.QtySettle, oGRN_details.Qty-oGRN_details.QtySettle, clsCommon.getStoragePeriod(((StoragePeriod)oGRN.Storage_Period)), int.Parse(((clsSecurity.getServerDateTime().Date - oGRN.GoodReceivedNote_Date.Date).TotalDays).ToString()), oGRN.UserID_Created);
                                }
                            }
                            frm_ReportViwer CRViwer = new frm_ReportViwer();
                            CRViwer.Print(oReports.ReportPath, dts_Grn, glb_dts_ExportReport.dt_rptParameter);                                                      

                        }
                        #endregion

                        #region Vehicle detail     
                        if (Report == enum_ReportName.VehicleDetail)
                        {
                            DataSets.dts_VehicleTracker dts_VehicleDetail = new DataSets.dts_VehicleTracker();
                            dts_VehicleDetail.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReports.DisplayName, oReports.DisplayName2, "Date Range : From  " + dtmFromDate.ToString(clsConfig.Format_Date) + "  To  " + dtmToDate.ToString(clsConfig.Format_Date), clsSecurity.UserNameLoged, sFilter);
                            
                            #region Filters

                            #region Customer Filter
                            List<tbl_genCustomerMaster> oCustomer;
                            if (bCustomerSelected)
                            {
                                oCustomer = new List<tbl_genCustomerMaster>();
                                oCustomer.Add(tbl_genCustomerMaster.Select(txtCustomer.Tag.ToString()));
                            }
                            else
                                oCustomer = tbl_genCustomerMaster.SelectAll().ToList();
                            #endregion

                            #endregion

                            foreach (tbl_genCustomerMaster oCust in oCustomer)
                            {
                                foreach (tbl_whTxn_VehicleTracker oVeh in tbl_whTxn_VehicleTracker.SelectAllByCustomer_ID(oCust.Customer_ID).Where(v => v.VehicleTracking_ID != "default" && v.CheckinTime.Date >= dtmFromDate.Date && v.CheckinTime.Date <= dtmToDate.Date))
                                {                                    
                                        dts_VehicleDetail.dt_Vehicle_Detail.Adddt_Vehicle_DetailRow( oVeh.VehicleTracking_ID, oVeh.Vehicle_No, ((CheckingType)oVeh.Purpose).ToString(), oVeh.Customer_ID, clsRef_Name.get_Customer_Name(oVeh.Customer_ID), oVeh.Container_No, oVeh.DriverName, oVeh.DriverNic, oVeh.CheckinTime, oVeh.CheckoutTime, oVeh.UserID_Created);                                   
                                }
                           }

                            frm_ReportViwer CRViwer = new frm_ReportViwer();
                            CRViwer.Print(oReports.ReportPath, dts_VehicleDetail, glb_dts_ExportReport.dt_rptParameter);
                        }
                        #endregion

                    }
                }
                else
                {
                    SEACCMessageBox.Show("Oops....", " Please select a report you need ", MessageBoxButton.OK);
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

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_CustomerID())
            {
                if (CheckValidityDateRange())
                    bStatus = true;
            }

            return bStatus;
        }
        
        private bool CheckValidity_CustomerID()
        {
            bool bStatus = true;
            if (!clsValidation.Validate_EmptyTag(txtCustomer))
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

        #region Grid Events
        private void dgv_Reports_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DataRowView item = (sender as DataGrid).SelectedItem as DataRowView;
                if (item != null)
                {
                    object[] obj = item.Row.ItemArray;
                    int iReportID = int.Parse(obj[0].ToString());

                    enum_ReportName Report = (enum_ReportName)iReportID;
                    if (iReportID == 30)
                    {
                        txtCustomer.Visibility = System.Windows.Visibility.Collapsed;
                        txtStore.Visibility = System.Windows.Visibility.Visible;
                        txtItem.Visibility = System.Windows.Visibility.Visible;
                        txtGrn.Visibility = System.Windows.Visibility.Collapsed;                        
                    }
                    if (iReportID == 31)
                    {
                        txtCustomer.Visibility = System.Windows.Visibility.Visible;
                        txtStore.Visibility = System.Windows.Visibility.Collapsed;
                        txtItem.Visibility = System.Windows.Visibility.Collapsed;
                        txtGrn.Visibility = System.Windows.Visibility.Collapsed;
                    }
                    if (iReportID == 32)
                    {
                        txtCustomer.Visibility = System.Windows.Visibility.Collapsed;
                        txtStore.Visibility = System.Windows.Visibility.Visible;
                        txtItem.Visibility = System.Windows.Visibility.Visible;
                        txtGrn.Visibility = System.Windows.Visibility.Collapsed;
                    }
                    if (iReportID == 33)
                    {
                        txtCustomer.Visibility = System.Windows.Visibility.Visible;
                        txtStore.Visibility = System.Windows.Visibility.Collapsed;
                        txtItem.Visibility = System.Windows.Visibility.Collapsed;
                        txtGrn.Visibility = System.Windows.Visibility.Collapsed;
                    }
                    if (iReportID == 34)
                    {
                        txtCustomer.Visibility = System.Windows.Visibility.Visible;
                        txtStore.Visibility = System.Windows.Visibility.Visible;
                        txtItem.Visibility = System.Windows.Visibility.Visible;
                        txtGrn.Visibility = System.Windows.Visibility.Visible;
                    }
                    if (iReportID == 35)
                    {
                        txtCustomer.Visibility = System.Windows.Visibility.Visible;
                        txtStore.Visibility = System.Windows.Visibility.Collapsed;
                        txtItem.Visibility = System.Windows.Visibility.Collapsed;
                        txtGrn.Visibility = System.Windows.Visibility.Collapsed;
                    }
                    
                    //else
                    //{
                    //    VisibleAllControllers();
                    //}

                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Refresh Grid
        public void RefreshGrid()
        {
            try
            {
                foreach (tbl_securityFunctionMaster oReports in tbl_securityFunctionMaster.SelectAll().Where(p => p.IsReport && p.IsEnable))
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

        private void txtCustomer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Customers);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomer.Text = lstResult[1];
                txtCustomer.Tag = lstResult[0];
            }
        }
              
        private void txtItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Items);
            if (RowDataSearch.DialogResult == true)
            {
                txtItem.Text = lstResult[1];
                txtItem.Tag = lstResult[0];
            }
        }

        private void txtStore_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Store);
            if (RowDataSearch.DialogResult == true)
            {
                txtStore.Text = lstResult[1];
                txtStore.Tag = lstResult[0];
            }
        }

        private void txtGrn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Grn);
            if (RowDataSearch.DialogResult == true)
            {
                txtGrn.Text = lstResult[0];
                txtGrn.Tag = lstResult[0];
            }
        }

        public void VisibleAllControllers()
        {
            txtCustomer.Visibility = System.Windows.Visibility.Visible;
            txtStore.Visibility = System.Windows.Visibility.Visible;
            txtItem.Visibility = System.Windows.Visibility.Visible;
            txtGrn.Visibility = System.Windows.Visibility.Visible;
        }

        
    }
}
