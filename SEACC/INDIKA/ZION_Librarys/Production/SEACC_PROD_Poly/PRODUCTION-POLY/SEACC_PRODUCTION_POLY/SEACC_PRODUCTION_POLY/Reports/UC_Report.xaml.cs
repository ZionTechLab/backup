using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_POLY.DataSets;
using SEACC_PRODUCTION_POLY.Common;
using SEACC_PRODUCTION_POLY.Search;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SEACC_PRODUCTION_POLY.Reports
{
    /// <summary>
    /// Interaction logic for UC_Report.xaml
    /// </summary>
    public partial class UC_Report : UserControl
    {
        #region Class variables
        DataTable dt_Reports = new DataTable();
        dts_BoM glb_dtsBoMs = new dts_BoM();
        dts_WIP glb_dtsWIP = new dts_WIP();
        dts_ReportExport glb_dts_ExportReport = new dts_ReportExport();
        #endregion

        #region Form Load
        public UC_Report()
        {
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Report;
            SEACC_Form.Initialize();

            #region  #region Initialize Data Table
            dt_Reports.Columns.Add("ReportID", typeof(string));
            dt_Reports.Columns.Add("ReportName", typeof(string));
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(false, false, false, false, false, false);
            #endregion

            ClearFields();
            RefreshGrid();

        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBoMJob, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCutomer, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomerInquiry, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomerOrder, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtJobTypes, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProdSection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProRange, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProdCategory, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProdSize, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishedGood, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtRawMeterial, true, false, false);

            txtBoMJob.Tag = null;
            txtCutomer.Tag = null;
            txtCustomerInquiry.Tag = null;
            txtCustomerOrder.Tag = null;
            txtJobTypes.Tag = null;
            txtProdSection.Tag = null;
            txtProRange.Tag = null;
            txtProdCategory.Tag = null;
            txtProdSize.Tag = null;
            txtFinishedGood.Tag = null;
            txtRawMeterial.Tag = null;

            txtBoMJob.Text = "<All BoM/JOB>";
            txtCutomer.Text = "<All Customers>";
            txtCustomerInquiry.Text = "<All Customer Inquiries>";
            txtCustomerOrder.Text = "<All  Customer Orders>";
            txtJobTypes.Text = "<All Job Types>";
            txtProdSection.Text = "<All Production Sections>";
            txtProRange.Text = "<All Product Ranges>";
            txtProdCategory.Text = "<All Product Categories>";
            txtProdSize.Text = "<All Product Sizes>";
            txtFinishedGood.Text = "<All Finished Goods>";
            txtRawMeterial.Text = "<All Raw Materials>";

            msbProdJob_Status.ClearData();
            foreach (prod_JobStatus pjs in Enum.GetValues(typeof(prod_JobStatus)))
                msbProdJob_Status.SetData(true, ((int)pjs).ToString(), pjs.ToString());

            dtp_FromDate.SetTime(DateTime.Now);
            dtp_ToDate.SetTime(DateTime.Now);

        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dt_Reports.Clear();
                foreach (tbl_securityFunctionMaster oReports in tbl_securityFunctionMaster.SelectAll().Where(p => p.FunctionCategory_ID == "PROD/016"))
                {
                    tbl_securityFunctionMaster_Permission oPermission = tbl_securityFunctionMaster_Permission.Select(clsSecurity.UserIDLoged, oReports.Function_ID);
                    if (oPermission != null && oPermission.AllowView)
                    {
                        try
                        {
                            dt_Reports.Rows.Add(oReports.Function_ID, oReports.FunctionName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
                dgv_Reports.ItemsSource = dt_Reports.DefaultView;
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
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

                #region Get report and Permissions
                int irowID = dgv_Reports.SelectedIndex;
                string sReportID = dt_Reports.Rows[irowID]["ReportID"].ToString();

                tbl_securityFunctionMaster oFunction = tbl_securityFunctionMaster.Select(int.Parse(sReportID));
                tbl_securityFunctionMaster_Report oReport = tbl_securityFunctionMaster_Report.Select(int.Parse(sReportID));
                tbl_securityFunctionMaster_Permission oUserPermission = tbl_securityFunctionMaster_Permission.Select(clsSecurity.UserIDLoged, oReport.Function_ID);
                #endregion

                glb_dtsBoMs.Clear();
                glb_dtsWIP.Clear();
                if (oFunction != null && oReport != null)
                {
                    #region Filters
                    string sFilter = "";
                    bool bSelectProdJobBoM = false, bSelectCustomer = false, bSelectProdSection = false, bSelectProdJobStatus = false, bSelectRawMaterial = false, bSelectFinishedGood = false;

                    var vProdJobStatus = msbProdJob_Status.GetData().Rows.Count > 0 ? msbProdJob_Status.GetData().AsEnumerable().ToList() : null;


                    if (txtBoMJob.Tag != null && txtBoMJob.Tag.ToString() != "default")
                    {
                        bSelectProdJobBoM = true;
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "BoM/JOB# : " + txtBoMJob.Text.Trim();
                    }
                    else
                    {
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "BoM/JOB# : All " ;
                    }

                    if (txtCutomer.Tag != null && txtCutomer.Tag.ToString() != "default")
                    {
                        bSelectCustomer = true;
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Customer : " + txtCutomer.Text.Trim();
                    }
                    else
                    {
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Customer : All ";
                    }

                    if (txtProdSection.Tag != null && txtProdSection.Tag.ToString() != "default")
                    {
                        bSelectProdSection = true;
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Production Section : " + txtProdSection.Text.Trim();
                    }
                    else
                    {
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Production Section : All ";
                    }

                    //if (!msbProdJob_Status.IsSelectAll() && vProdJobStatus != null) // Prod Job Status Selection
                    //{
                    //    bSelectProdJobStatus = true;
                    //    sFilter += (sFilter != "" ? "  |  " : "") + "Division : ";
                    //    vProdJobStatus.ForEach(r => sFilter += r.Field<string>("name") + ",");
                    //}
                    //else
                    //{
                    //    sFilter += (sFilter != "" ? "  |  " : "") + "Division : All ";
                    //}

                    if (txtRawMeterial.Tag != null && txtRawMeterial.Tag.ToString() != "default")
                    {
                        bSelectRawMaterial = true;
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Input Item (Raw Material) : " + txtRawMeterial.Text.Trim();
                    }
                    else
                    {
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Input Item (Raw Material) : All ";
                    }

                    if (txtFinishedGood.Tag != null && txtFinishedGood.Tag.ToString() != "default")
                    {
                        bSelectFinishedGood = true;
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Finished Good Item : " + txtFinishedGood.Text.Trim();
                    }
                    else
                    {
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Finished Good Item : All ";
                    }

                    string sDateRange = "Report Period - " + dtp_FromDate.GetDateTime().ToString("yyyy/MMM/dd") + "  to  " + dtp_ToDate.GetDateTime().ToString("yyyy/MMM/dd");
                    #endregion

                    #region 17000 - Production Input Materials Movement Report
                    if (oReport.Function_ID == 17000)
                    {
                        foreach (tbl_prod_polyTxJobCard oProdJobBom in tbl_prod_polyTxJobCard.SelectAll().Where(r => r.ProdJob_ID != "default" && 
                                                                                                      r.ProdJobStatus != (int)prod_JobStatus.Obsolete && 
                                                                                                      r.ProdStartDate.Date >= dtp_FromDate.GetDateTime().Date && 
                                                                                                      r.ProdStartDate.Date <= dtp_ToDate.GetDateTime().Date))
                        {
                            #region Selected Filters
                            if (bSelectProdJobBoM)
                            {
                                if (txtBoMJob.Tag.ToString() != oProdJobBom.ProdJob_ID)
                                    continue;
                            }
                            if (bSelectCustomer)
                            {
                                if (txtCutomer.Tag.ToString() != oProdJobBom.Customer_ID)
                                    continue;
                            }
                            if (bSelectProdJobStatus)
                            {
                                if (vProdJobStatus.Any(r2 => r2.Field<string>("id") != oProdJobBom.ProdJobStatus.ToString()))
                                    continue;
                            }
                            if (bSelectFinishedGood)
                            {
                                if (txtFinishedGood.Tag.ToString() != oProdJobBom.Item_ID_FG)
                                    continue;
                            }
                            #endregion

                            #region Fill Header

                            glb_dtsBoMs.dt_prodJob.Adddt_prodJobRow(oProdJobBom.ProdJob_ID, oProdJobBom.ProdJobDate, clsHelpMethods_Prod.GetEnumDescription((prod_JobStatus)oProdJobBom.ProdJobStatus),
                                               oProdJobBom.Salesman_ID, oProdJobBom.Customer_ID, clsGenaralName.getName_Customer(oProdJobBom.Customer_ID), oProdJobBom.CustomerOrder_ID,
                                               oProdJobBom.Item_ID_FG, clsGenaralName.getName_Item(oProdJobBom.Item_ID_FG), clsGenaralName.getDescription_Item(oProdJobBom.Item_ID_FG), clsGenaralName.getCode_Item(oProdJobBom.Item_ID_FG),
                                               oProdJobBom.ProdStartDate, oProdJobBom.ExfactoryDate, oProdJobBom.FGoodQty, oProdJobBom.Uom_ID, oProdJobBom.IsApproved1, oProdJobBom.IsApproved2, oProdJobBom.IsApproved3, oProdJobBom.IsLocked , "","","","",0,"",0,"");

                            #endregion

                            #region Fill Job Material Details
                            decimal dCustomerOrderQty = clsHelpMethods_Prod.GetItemQtyInCustomerOrder_FromJob(oProdJobBom.ProdJob_ID);
                            foreach (tbl_prod_polyTxJobCard_Material oProdJobBom_Material in tbl_prod_polyTxJobCard_Material.SelectAllByProdJob_ID(oProdJobBom.ProdJob_ID))
                            {
                                #region Selected Detail Filters
                                if (bSelectProdSection)
                                {
                                    if (txtProdSection.Tag.ToString() != oProdJobBom_Material.Section_ID)
                                        continue;
                                }
                                if (bSelectRawMaterial)
                                {
                                    if (txtRawMeterial.Tag.ToString() != oProdJobBom_Material.Item_ID)
                                        continue;
                                }
                                #endregion

                                decimal dMR_MeterialQty = clsHelpMethods_Prod.AlreadyIssuedQty_formMRs(oProdJobBom.ProdJob_ID, oProdJobBom_Material.Item_ID);
                                decimal dpGIN_MeterialQty = clsHelpMethods_Prod.AlreadyIssuedQty_formPGINs(oProdJobBom.ProdJob_ID, oProdJobBom_Material.Item_ID);
                                decimal dpGRN_MeterialQty = clsHelpMethods_Prod.AlreadyIssuedQty_formPGRNs(oProdJobBom.ProdJob_ID, oProdJobBom_Material.Item_ID);
                                decimal dWIP_MeterialQty = clsHelpMethods_Prod.AlreadyIssuedQty_formWIPs(oProdJobBom.ProdJob_ID, oProdJobBom_Material.Item_ID);

                                glb_dtsBoMs.dt_prodJob_material.Adddt_prodJob_materialRow(oProdJobBom_Material.ProdJob_ID, oProdJobBom_Material.IsSemiFinishItem, clsGenaralName.getName_Item(oProdJobBom_Material.Item_ID), clsGenaralName.getDescription_Item(oProdJobBom.Item_ID_FG), oProdJobBom_Material.Uom_ID,
                                    clsGenaralName.getName_Uom(oProdJobBom_Material.Uom_ID), oProdJobBom_Material.Consumption, oProdJobBom_Material.Section_ID, clsGenaralName.getName_Section(oProdJobBom_Material.Section_ID),
                                    "",
                                    (oProdJobBom_Material.TotalInputQty * dCustomerOrderQty),//Planned Qty
                                    dMR_MeterialQty, //MR Qty
                                    dpGIN_MeterialQty, //pGIN Qty
                                    dpGRN_MeterialQty, //pGRN Qty
                                    dWIP_MeterialQty, //WIP Qty
                                    (dpGIN_MeterialQty - dpGRN_MeterialQty - dWIP_MeterialQty),  //Balance
                                     0 );
                            }
                            #endregion
                        }

                        #region Set company Details
                        glb_dtsBoMs.dt_company.Adddt_companyRow(clsSecurity.DigiteqName,
                            clsSecurity.DigiteqEmail,
                            clsCript.Decrypt(clsCommon.getComName()),
                            clsCript.Decrypt(clsCommon.getCompanyAddress1()),
                            clsCommon.getCompanyAddress2_DAPL(),
                            clsCommon.getCompanyImage(),
                            oReport.DisplayName,
                            oReport.DisplayName2,
                            sDateRange,
                            clsSecurity.UserNameLoged,
                            sFilter.Length > 2 ? sFilter : "-");
                        #endregion

                        frm_ReportViewer frmViewer = new frm_ReportViewer();
                        frmViewer.print(oReport.ReportPath, glb_dtsBoMs, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                    }
                    #endregion

                    #region 17001 - Work In Progress Summary Report
                    if (oReport.Function_ID == 17001)
                    {
                        foreach (tbl_prod_polyTxWorkInProgress oProdWIP in tbl_prod_polyTxWorkInProgress.SelectAll().Where(r => !r.IsCanceled && r.Wip_Date.Date >= dtp_FromDate.GetDateTime().Date && r.Wip_Date.Date <= dtp_ToDate.GetDateTime().Date))
                        {
                            #region Prod Job BoM
                            tbl_prod_polyTxJobCard oProdJobBom = tbl_prod_polyTxJobCard.Select(oProdWIP.ProdJob_ID);
                            if (oProdJobBom == null)
                                continue;
                            #endregion

                            #region Selected Header Filters
                            if (bSelectProdJobBoM)
                            {
                                if (txtBoMJob.Tag.ToString() != oProdWIP.ProdJob_ID)
                                    continue;
                            }
                            if (bSelectCustomer)
                            {
                                if (txtCutomer.Tag.ToString() != oProdJobBom.Customer_ID)
                                    continue;
                            }
                            if (bSelectProdSection)
                            {
                                if (txtProdSection.Tag.ToString() != oProdWIP.Section_ID)
                                    continue;
                            }
                            if (bSelectProdJobStatus)
                            {
                                if (vProdJobStatus.Any(r2 => r2.Field<string>("id") != oProdJobBom.ProdJobStatus.ToString()))
                                    continue;
                            }
                            if (bSelectFinishedGood)
                            {
                                if (txtFinishedGood.Tag.ToString() != oProdWIP.Item_ID_FG)
                                    continue;
                            }
                            #endregion

                            #region Fill Header
                            glb_dtsWIP.dt_prodWorkInProgress.Adddt_prodWorkInProgressRow(oProdWIP.ProdJob_ID, oProdJobBom.ProdJobDate, oProdJobBom.Item_ID_FG, clsGenaralName.getName_Item(oProdJobBom.Item_ID_FG), clsGenaralName.getDescription_Item(oProdJobBom.Item_ID_FG), clsGenaralName.getCode_Item(oProdJobBom.Item_ID_FG),
                            oProdWIP.Wip_ID, oProdWIP.Wip_Date, oProdWIP.Section_ID, clsGenaralName.getName_Section(oProdWIP.Section_ID), oProdWIP.CreateUser_ID, oProdWIP.CreateUser_ID);

                            #endregion

                            #region Fill Details
                            foreach (tbl_prod_polyTxWorkInProgress_Material oProdWIPDetails in tbl_prod_polyTxWorkInProgress_Material.SelectAllByWip_ID(oProdWIP.Wip_ID))
                            {
                                #region Selected Detail Filters
                                if (bSelectRawMaterial)
                                {
                                    if (txtRawMeterial.Tag.ToString() != oProdWIPDetails.Item_ID)
                                        continue;
                                }
                                #endregion

                                glb_dtsWIP.dt_prodWorkInProgress_Details.Adddt_prodWorkInProgress_DetailsRow(oProdWIP.ProdJob_ID, oProdWIPDetails.Item_ID, clsGenaralName.getName_Item(oProdWIPDetails.Item_ID), oProdWIPDetails.Uom_ID, clsGenaralName.getName_Uom(oProdWIPDetails.Uom_ID), oProdWIPDetails.InputOutput_Qty, oProdWIPDetails.Is_Output,
                                oProdWIPDetails.Output_Section_ID, clsGenaralName.getName_Section(oProdWIPDetails.Output_Section_ID));
                            }
                            #endregion
                        }

                        #region Set company Details
                        glb_dtsWIP.dt_company.Adddt_companyRow(clsSecurity.DigiteqName,
                            clsSecurity.DigiteqEmail,
                            clsCript.Decrypt(clsCommon.getComName()),
                            clsCript.Decrypt(clsCommon.getCompanyAddress1()),
                            clsCommon.getCompanyAddress2_DAPL(),
                            clsCommon.getCompanyImage(),
                            oReport.DisplayName,
                            oReport.DisplayName2,
                            sDateRange,
                            clsSecurity.UserNameLoged,
                            sFilter.Length > 2 ? sFilter : "-");
                        #endregion

                        frm_ReportViewer frmViewer = new frm_ReportViewer();
                        frmViewer.print(oReport.ReportPath, glb_dtsWIP, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                    }
                    #endregion

                    #region 17002 - Production Job Sheet
                    if (oReport.Function_ID == 17002)
                    {
                        foreach (tbl_prod_polyTxJobCard oProdJobBom in tbl_prod_polyTxJobCard.SelectAll().Where(r => r.ProdJob_ID != "default" && r.ProdJobStatus != (int)prod_JobStatus.Obsolete && r.ProdStartDate.Date >= dtp_FromDate.GetDateTime().Date && r.ProdStartDate.Date <= dtp_ToDate.GetDateTime().Date))
                        {
                            #region Selected Filters
                            if (bSelectProdJobBoM)
                            {
                                if (txtBoMJob.Tag.ToString() != oProdJobBom.ProdJob_ID)
                                    continue;
                            }
                            if (bSelectCustomer)
                            {
                                if (txtCutomer.Tag.ToString() != oProdJobBom.Customer_ID)
                                    continue;
                            }
                            if (bSelectProdJobStatus)
                            {
                                if (vProdJobStatus.Any(r2 => r2.Field<string>("id") != oProdJobBom.ProdJobStatus.ToString()))
                                    continue;
                            }
                            if (bSelectFinishedGood)
                            {
                                if (txtFinishedGood.Tag.ToString() != oProdJobBom.Item_ID_FG)
                                    continue;
                            }
                            #endregion

                            #region Fill Header

                            glb_dtsBoMs.dt_prodJob.Adddt_prodJobRow(oProdJobBom.ProdJob_ID, oProdJobBom.ProdJobDate, clsHelpMethods_Prod.GetEnumDescription((prod_JobStatus)oProdJobBom.ProdJobStatus),
                                               oProdJobBom.Salesman_ID, oProdJobBom.Customer_ID, clsGenaralName.getName_Customer(oProdJobBom.Customer_ID), oProdJobBom.CustomerOrder_ID,
                                               oProdJobBom.Item_ID_FG, clsGenaralName.getName_Item(oProdJobBom.Item_ID_FG), clsGenaralName.getDescription_Item(oProdJobBom.Item_ID_FG), clsGenaralName.getCode_Item(oProdJobBom.Item_ID_FG),
                                               oProdJobBom.ProdStartDate, oProdJobBom.ExfactoryDate, oProdJobBom.FGoodQty, oProdJobBom.Uom_ID, oProdJobBom.IsApproved1, oProdJobBom.IsApproved2, oProdJobBom.IsApproved3, oProdJobBom.IsLocked, oProdJobBom.ProdRange_ID, oProdJobBom.ProdCategory_ID, oProdJobBom.ProdSize_ID, oProdJobBom.Colour_ID, 0, oProdJobBom.Remarks, 0, oProdJobBom.JobType_ID);

                            #endregion

                            foreach (tbl_prod_polyTxJobCard_Delivery oProdJobDelivery in tbl_prod_polyTxJobCard_Delivery.SelectAllByProdJob_ID(oProdJobBom.ProdJob_ID))
                            {
                                glb_dtsBoMs.dt_prodDelivery.Adddt_prodDeliveryRow(oProdJobBom.ProdJob_ID, oProdJobDelivery.DeliverDateTime, oProdJobDelivery.DeliverQty, oProdJobDelivery.Uom_Qty, oProdJobDelivery.DeliverAddress);
                            }

                            #region Fill Job Material Details
                            decimal dCustomerOrderQty = clsHelpMethods_Prod.GetItemQtyInCustomerOrder_FromJob(oProdJobBom.ProdJob_ID);
                            foreach (tbl_prod_polyTxJobCard_Material oProdJobBom_Material in tbl_prod_polyTxJobCard_Material.SelectAllByProdJob_ID(oProdJobBom.ProdJob_ID))
                            {
                                #region Selected Detail Filters
                                if (bSelectProdSection)
                                {
                                    if (txtProdSection.Tag.ToString() != oProdJobBom_Material.Section_ID)
                                        continue;
                                }
                                if (bSelectRawMaterial)
                                {
                                    if (txtRawMeterial.Tag.ToString() != oProdJobBom_Material.Item_ID)
                                        continue;
                                }
                                #endregion

                                decimal dMR_MeterialQty = clsHelpMethods_Prod.AlreadyIssuedQty_formMRs(oProdJobBom.ProdJob_ID, oProdJobBom_Material.Item_ID);
                                decimal dpGIN_MeterialQty = clsHelpMethods_Prod.AlreadyIssuedQty_formPGINs(oProdJobBom.ProdJob_ID, oProdJobBom_Material.Item_ID);
                                decimal dpGRN_MeterialQty = clsHelpMethods_Prod.AlreadyIssuedQty_formPGRNs(oProdJobBom.ProdJob_ID, oProdJobBom_Material.Item_ID);
                                decimal dWIP_MeterialQty = clsHelpMethods_Prod.AlreadyIssuedQty_formWIPs(oProdJobBom.ProdJob_ID, oProdJobBom_Material.Item_ID);

                                glb_dtsBoMs.dt_prodJob_material.Adddt_prodJob_materialRow(oProdJobBom_Material.ProdJob_ID, oProdJobBom_Material.IsSemiFinishItem, oProdJobBom_Material.Item_ID, clsGenaralName.getDescription_Item(oProdJobBom_Material.Item_ID), oProdJobBom_Material.Uom_ID,
                                    clsGenaralName.getName_Uom(oProdJobBom_Material.Uom_ID), oProdJobBom_Material.Consumption, oProdJobBom_Material.Section_ID, clsGenaralName.getName_Section(oProdJobBom_Material.Section_ID), "",
                                    (oProdJobBom_Material.TotalInputQty * dCustomerOrderQty),//Planned Qty
                                    dMR_MeterialQty, //MR Qty
                                    dpGIN_MeterialQty, //pGIN Qty
                                    dpGRN_MeterialQty, //pGRN Qty
                                    dWIP_MeterialQty, //WIP Qty
                                    (dpGIN_MeterialQty - dpGRN_MeterialQty - dWIP_MeterialQty),
                                    oProdJobBom_Material.Smv_TimeMinutes
                                );
                            }
                            #endregion
                        }

                        #region Set company Details
                        glb_dtsBoMs.dt_company.Adddt_companyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsCript.Decrypt(clsCommon.getComName()), clsCript.Decrypt(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2_DAPL(), clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, sDateRange, clsSecurity.UserNameLoged, sFilter.Length > 2 ? sFilter : "-");
                        #endregion

                        frm_ReportViewer frmViewer = new frm_ReportViewer();
                        frmViewer.print(oReport.ReportPath, glb_dtsBoMs, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                    }
                    #endregion
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

        #region Search Events

        private void txtCutomer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.CustomerList);
            if (RowDataSearch.DialogResult == true)
            {
                txtCutomer.Tag = lstResult[0];
                txtCutomer.Text = lstResult[1];
            }
        }

        private void txtProdSection_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProcductionSections);
            if (RowDataSearch.DialogResult == true)
            {
                txtProdSection.Tag = (lstResult[0]);
                txtProdSection.Text = (lstResult[1]);
            }
        }

        private void txtRawMeterial_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_PolyProductionMaterials);
            if (RowDataSearch.DialogResult == true)
            {
                txtRawMeterial.Tag = lstResult[0];
                txtRawMeterial.Text = lstResult[2];
            }
        }

        private void txtFinishedGood_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_PolyProductionFinishedGoods);
            if (RowDataSearch.DialogResult == true)
            {
                txtFinishedGood.Tag = lstResult[0];
                txtFinishedGood.Text = lstResult[3];

            }
        }


        #endregion

        #region Key Events
        private void SEACC_Form_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                ClearFields();
                RefreshGrid();
            }
        }
        #endregion

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
                    tbl_securityFunctionMaster oFunction = tbl_securityFunctionMaster.Select(iReportID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
    }
}
