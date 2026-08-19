using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_APPAREL.Common;
using SEACC_PRODUCTION_APPAREL.Search;
using SEACC_PRODUCTION_APPAREL.DataSets;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SEACC_PRODUCTION_APPAREL.Reports
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
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtJobName, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBatch, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomer, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProdSection, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtRawMeterial, true, false, true);

            txtBoMJob.Tag = null;
            txtJobName.Tag = null;
            txtBatch.Tag = null;
            txtCustomer.Tag = null;
            txtProdSection.Tag = null;
            txtRawMeterial.Tag = null;

            txtBoMJob.Text = "<All BoM>";
            txtJobName.Text = "<All Job Names>";
            txtBatch.Text = "<All Jobs>";
            txtCustomer.Text = "<All Customers>";
            txtProdSection.Text = "<All Production Sections>";
            txtRawMeterial.Text = "<All Raw Materials>";

            msbProdBatch_Status.ClearData();
            foreach (prod_Batch_Status pjs in Enum.GetValues(typeof(prod_Batch_Status)))
                msbProdBatch_Status.SetData(true, ((int)pjs).ToString(), pjs.ToString());

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
                foreach (tbl_securityFunctionMaster oReports in tbl_securityFunctionMaster.SelectAll().Where(p => p.IsReport && p.FunctionCategory_ID == "PROD/016"))
                {
                    tbl_securityFunctionMaster_Permission oPermission = tbl_securityFunctionMaster_Permission.Select(clsSecurity.BranchID, clsSecurity.UserIDLoged, oReports.Function_ID);
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
                var item = dgv_Reports.SelectedItem;
                var sReportId = (dgv_Reports.SelectedCells[0].Column.GetCellContent(item) as TextBlock)?.Text;

                tbl_securityFunctionMaster oFunction = tbl_securityFunctionMaster.Select(int.Parse(sReportId));
                tbl_securityFunctionMaster_Report oReport = tbl_securityFunctionMaster_Report.Select(int.Parse(sReportId));
                tbl_securityFunctionMaster_Permission oUserPermission = tbl_securityFunctionMaster_Permission.Select(clsSecurity.BranchID,clsSecurity.UserIDLoged, oReport.Function_ID);
                #endregion

                glb_dtsBoMs.Clear();
                glb_dtsWIP.Clear();
                if (oFunction != null && oReport != null)
                {
                    #region Filter Definitions
                    string sFilter = "";
                    bool bSelectProdJobBoM = false, bSelectJobName = false, bSelectCustomer = false, bSelectProdSection = false, bSelectProdBatch = false, bSelectProdJobStatus = false, bSelectRawMaterial = false;
                    var vBatchStatus = msbProdBatch_Status.GetData().Rows.Count > 0 ? msbProdBatch_Status.GetData().AsEnumerable().ToList() : null;

                    if (txtBoMJob.Tag != null && txtBoMJob.Tag.ToString() != "default")
                    {
                        bSelectProdJobBoM = true;
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "BoM # : " + txtBoMJob.Text.Trim();
                    }
                    else
                    {
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "BoM # : All ";
                    }

                    if (txtJobName.Tag != null && txtJobName.Tag.ToString() != "default")
                    {
                        bSelectJobName = true;
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Job Name # : " + txtJobName.Text.Trim();
                    }
                    else
                    {
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Job Name # : All ";
                    }

                    if (txtCustomer.Tag != null && txtCustomer.Tag.ToString() != "default")
                    {
                        bSelectCustomer = true;
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Customer : " + txtCustomer.Text.Trim();
                    }
                    else
                    {
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Customer : All ";
                    }

                    if (txtBatch.Tag != null && txtBatch.Tag.ToString() != "default")
                    {
                        bSelectProdBatch = true;
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Job/Batch # : " + txtBatch.Text.Trim();
                    }
                    else
                    {
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Job/Batch # : All ";
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

                    if (txtRawMeterial.Tag != null && txtRawMeterial.Tag.ToString() != "default")
                    {
                        bSelectRawMaterial = true;
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Raw Material : " + txtRawMeterial.Text.Trim();
                    }
                    else
                    {
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Raw Materials : All ";
                    }

                    string sDateRange = "Report Period - " + dtp_FromDate.GetDateTime().ToString("yyyy/MMM/dd") + "  to  " + dtp_ToDate.GetDateTime().ToString("yyyy/MMM/dd");
                    #endregion

                    #region Production Input Materials Movement Report
                    if (oReport.Function_ID == (int)enum_ReportName.ProdApparel_InputMaterialsMovement)
                    {
                        foreach (tbl_prodTxJobCard oProdJobBom in tbl_prodTxJobCard.SelectAll().Where(r => r.ProdJob_ID != "default" &&
                                                                                                      r.ProdJobStatus != (int)prod_BoM_Status.Obsolete &&
                                                                                                      r.ProdJobDate.Date >= dtp_FromDate.GetDateTime().Date &&
                                                                                                      r.ProdJobDate.Date <= dtp_ToDate.GetDateTime().Date))
                        {
                            foreach (tbl_prodTxBatch oBatch in tbl_prodTxBatch.SelectAllByProdJob_ID(oProdJobBom.ProdJob_ID))
                            {
                                #region Selected Filters
                                if (bSelectProdJobBoM)
                                {
                                    if (txtBoMJob.Tag.ToString() != oBatch.ProdJob_ID)
                                        continue;
                                }
                                if (bSelectJobName)
                                {
                                    if (txtJobName.Tag.ToString() != oProdJobBom.JobType_ID)
                                        continue;
                                }
                                if (bSelectCustomer)
                                {
                                    if (txtCustomer.Tag.ToString() != oProdJobBom.Customer_ID)
                                        continue;
                                }
                                if (bSelectProdBatch)
                                {
                                    if (txtBatch.Tag.ToString() != oBatch.ProdBatch_ID)
                                        continue;
                                }
                                if (bSelectProdJobStatus)
                                {
                                    if (vBatchStatus.Any(r2 => r2.Field<string>("id") != oBatch.BatchStatus.ToString()))
                                        continue;
                                }
                                #endregion

                                #region Fill Header

                                glb_dtsBoMs.dt_prodJob.Adddt_prodJobRow(oProdJobBom.ProdJob_ID, oProdJobBom.ProdJobDate, clsHelpMethods_Prod.GetEnumDescription((prod_Batch_Status)oBatch.BatchStatus),
                                                   oProdJobBom.Salesman_ID, oProdJobBom.Customer_ID, clsGenaralName.getName_Customer(oProdJobBom.Customer_ID), oProdJobBom.CustomerOrder_ID,
                                                   oProdJobBom.Item_ID_FG, clsGenaralName.getName_Item(oProdJobBom.Item_ID_FG), clsGenaralName.getDescription_Item(oProdJobBom.Item_ID_FG), clsGenaralName.getCode_Item(oProdJobBom.Item_ID_FG),
                                                   oProdJobBom.ProdStartDate, oProdJobBom.ExfactoryDate, oProdJobBom.FGoodQty, oProdJobBom.Uom_ID, oProdJobBom.IsApproved1, oProdJobBom.IsApproved2, oProdJobBom.IsApproved3, oProdJobBom.IsLocked, 
                                                   oBatch.ProdBatch_ID, oBatch.BatchStatus, "", "", "", "", "", "", "", "", 0, "",
                                                   "","","","","","","","","");

                                #endregion

                                #region Fill Job Material Details
                                foreach (tbl_prodTxBatch_Material oProdJobBom_Material in tbl_prodTxBatch_Material.SelectAllByProdBatch_ID(oBatch.ProdBatch_ID))
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

                                    decimal dMR_MeterialQty = clsHelpMethods_Prod.AlreadyRequestedQty_formMRs(oProdJobBom.ProdJob_ID, oBatch.ProdBatch_ID, oProdJobBom_Material.Item_ID);
                                    decimal dpGIN_MeterialQty = clsHelpMethods_Prod.AlreadyIssuedQty_formPGINs(oProdJobBom.ProdJob_ID, oBatch.ProdBatch_ID, oProdJobBom_Material.Item_ID);
                                    decimal dpGRN_MeterialQty = clsHelpMethods_Prod.AlreadyReturnedQty_formPGRNs(oProdJobBom.ProdJob_ID, oBatch.ProdBatch_ID, oProdJobBom_Material.Item_ID);
                                    decimal dWIP_MeterialQty = clsHelpMethods_Prod.AlreadyConsumedQty_formWIPs(oProdJobBom.ProdJob_ID, oBatch.ProdBatch_ID, oProdJobBom_Material.Item_ID);

                                    glb_dtsBoMs.dt_prodJob_material.Adddt_prodJob_materialRow(
                                        oProdJobBom_Material.Line_No,
                                        oProdJobBom_Material.ProdJob_ID,
                                        oProdJobBom_Material.IsSemiFinishItem,
                                        clsGenaralName.getName_Item(oProdJobBom_Material.Item_ID),
                                        clsGenaralName.getName_Item(oProdJobBom_Material.Item_ID),
                                        oProdJobBom_Material.Uom_ID,
                                        clsGenaralName.getName_Uom(oProdJobBom_Material.Uom_ID),
                                        oProdJobBom_Material.InputQty,
                                        oProdJobBom_Material.Section_ID,
                                        clsGenaralName.getName_Section(oProdJobBom_Material.Section_ID),
                                        "",
                                        (oProdJobBom_Material.TotalInputQty * oBatch.BatchQty),//Planned Qty
                                        dMR_MeterialQty,   //MR Qty
                                        dpGIN_MeterialQty, //pGIN Qty
                                        dpGRN_MeterialQty, //pGRN Qty
                                        dWIP_MeterialQty,  //WIP Qty
                                        oProdJobBom_Material.Line_No_Sub1 > 0 ? (dpGIN_MeterialQty - dpGRN_MeterialQty) : oProdJobBom_Material.IsSemiFinishItem ? 0m : (dpGIN_MeterialQty - dpGRN_MeterialQty - dWIP_MeterialQty), //Balance
                                        oBatch.ProdBatch_ID, oProdJobBom_Material.Smv_TimeMinutes, "");
                                }
                                #endregion
                            }
                        }

                        #region Set company Details
                        glb_dtsBoMs.dt_company.Adddt_companyRow(clsSecurity.DigiteqName,
                            clsSecurity.DigiteqEmail,
                            clsSecurity.CompanyName,
                           clsSecurity.CompanyAddress1,
                            clsSecurity.CompanyAddress2,
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

                    #region Work In Progress Summary Report
                    else if (oReport.Function_ID == (int)enum_ReportName.ProdApparel_WorkInProgressSummary)
                    {
                        foreach (tbl_prodTxWorkInProgress oProdWIP in tbl_prodTxWorkInProgress.SelectAll().Where(r => !r.IsCanceled && r.Wip_Date.Date >= dtp_FromDate.GetDateTime().Date && r.Wip_Date.Date <= dtp_ToDate.GetDateTime().Date))
                        {
                            #region Prod Job BoM
                            tbl_prodTxJobCard oProdJobBom = tbl_prodTxJobCard.Select(oProdWIP.ProdJob_ID);
                            if (oProdJobBom == null)
                                continue;
                            else if (oProdJobBom.ProdJobStatus == (int)prod_BoM_Status.Obsolete)
                                continue;
                            #endregion

                            #region Prod Batch
                            tbl_prodTxBatch oBatch = tbl_prodTxBatch.Select(oProdWIP.ProdBatch_ID);
                            if (oBatch == null)
                                continue;
                            #endregion

                            #region Selected Header Filters
                            if (bSelectProdJobBoM)
                            {
                                if (txtBoMJob.Tag.ToString() != oProdWIP.ProdJob_ID)
                                    continue;
                            }
                            if (bSelectJobName)
                            {
                                if (txtJobName.Tag.ToString() != oProdJobBom.JobType_ID)
                                    continue;
                            }
                            if (bSelectCustomer)
                            {
                                if (txtCustomer.Tag.ToString() != oProdJobBom.Customer_ID)
                                    continue;
                            }
                            if (bSelectProdJobStatus)
                            {
                                if (vBatchStatus.Any(r2 => r2.Field<string>("id") != oBatch.BatchStatus.ToString()))
                                    continue;
                            }
                            if (bSelectProdSection)
                            {
                                if (txtProdSection.Tag.ToString() != oProdWIP.Section_ID)
                                    continue;
                            }


                            #endregion

                            #region Fill Header
                            glb_dtsWIP.dt_prodWorkInProgress.Adddt_prodWorkInProgressRow(
                                oProdWIP.ProdJob_ID,
                                oBatch.ProdBatch_ID,
                                oProdJobBom.ProdJobDate,
                                oProdJobBom.Item_ID_FG,
                                clsGenaralName.getName_Item(oProdJobBom.Item_ID_FG),
                                clsGenaralName.getName_Item(oProdJobBom.Item_ID_FG),
                                clsGenaralName.getCode_Item(oProdJobBom.Item_ID_FG),
                                oProdWIP.Wip_ID,
                                oProdWIP.Wip_Date,
                                oProdWIP.Section_ID,
                                clsGenaralName.getName_Section(oProdWIP.Section_ID),
                                oProdWIP.CreateUser_ID,
                                oProdWIP.CreateUser_ID);
                            #endregion

                            #region Fill Details
                            foreach (tbl_prodTxWorkInProgress_Material oProdWIPDetails in tbl_prodTxWorkInProgress_Material.SelectAllByWip_ID(oProdWIP.Wip_ID))
                            {
                                #region Selected Detail Filters
                                if (bSelectRawMaterial)
                                {
                                    if (txtRawMeterial.Tag.ToString() != oProdWIPDetails.Item_ID)
                                        continue;
                                }
                                #endregion

                                glb_dtsWIP.dt_prodWorkInProgress_Details.Adddt_prodWorkInProgress_DetailsRow(
                                    oProdWIP.ProdJob_ID,
                                    oProdWIPDetails.Item_ID,
                                    clsGenaralName.getName_Item(oProdWIPDetails.Item_ID),
                                    oProdWIPDetails.Uom_ID,
                                    clsGenaralName.getName_Uom(oProdWIPDetails.Uom_ID),
                                    oProdWIPDetails.InputOutput_Qty,
                                    oProdWIPDetails.Is_Output,
                                    oProdWIPDetails.Output_Section_ID,
                                    clsGenaralName.getName_Section(oProdWIPDetails.Output_Section_ID),
                                    oProdWIPDetails.UnitPrice, oProdWIPDetails.TotalAmount,
                                    oProdWIPDetails.Wip_ID
                                    );
                            }
                            #endregion
                        }

                        #region Set company Details
                        glb_dtsWIP.dt_company.Adddt_companyRow(clsSecurity.DigiteqName,
                            clsSecurity.DigiteqEmail,
                            clsSecurity.CompanyName,
                           clsSecurity.CompanyAddress1,
                            clsSecurity.CompanyAddress2,
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

                    #region Production BoM/Job Sheet
                    else if (oReport.Function_ID == (int)enum_ReportName.ProdApparel_BoMSheet)
                    {
                        foreach (tbl_prodTxJobCard oProdJobBom in tbl_prodTxJobCard.SelectAll().Where(r =>
                            r.ProdJob_ID != "default" &&
                            r.ProdJobStatus != (int)prod_BoM_Status.Obsolete &&
                            r.ProdJobDate.Date >= dtp_FromDate.GetDateTime().Date &&
                            r.ProdJobDate.Date <= dtp_ToDate.GetDateTime().Date))
                        {
                            #region Slected BoM Filters
                            if (bSelectProdJobBoM)
                            {
                                if (txtBoMJob.Tag.ToString() != oProdJobBom.ProdJob_ID)
                                    continue;
                            }
                            if (bSelectJobName)
                            {
                                if (txtJobName.Tag.ToString() != oProdJobBom.JobType_ID)
                                    continue;
                            }
                            if (bSelectCustomer)
                            {
                                if (txtCustomer.Tag.ToString() != oProdJobBom.Customer_ID)
                                    continue;
                            }
                            #endregion

                            int iNoOfAttachments = tbl_prodAttachments.SelectAll().Count(r => r.Transaction_ID == oProdJobBom.ProdJob_ID);
                            List<tbl_prodTxBatch> lstBatch = tbl_prodTxBatch.SelectAllByProdJob_ID(oProdJobBom.ProdJob_ID).Where(r => !r.IsCanceled).ToList();

                            if (lstBatch.Count > 0)
                            {
                                foreach (tbl_prodTxBatch oBatch in lstBatch)
                                {
                                    #region Selected Batch/Job Filters                              

                                    if (bSelectProdBatch)
                                    {
                                        if (txtBatch.Tag.ToString() != oBatch.ProdBatch_ID)
                                            continue;
                                    }

                                    if (bSelectProdJobStatus)
                                    {
                                        if (vBatchStatus.Any(r2 =>
                                            r2.Field<string>("id") != oBatch.BatchStatus.ToString()))
                                            continue;
                                    }

                                    #endregion

                                    #region Fill Job Material Details

                                    int iRowMatCount = 0;
                                    foreach (tbl_prodTxBatch_Material oProdJobBomMaterial in tbl_prodTxBatch_Material.SelectAllByProdBatch_ID(oBatch.ProdBatch_ID))
                                    {
                                        #region Selected Detail Filters

                                        if (bSelectProdSection)
                                        {
                                            if (txtProdSection.Tag.ToString() != oProdJobBomMaterial.Section_ID)
                                                continue;
                                        }

                                        if (bSelectRawMaterial)
                                        {
                                            if (txtRawMeterial.Tag.ToString() != oProdJobBomMaterial.Item_ID)
                                                continue;
                                        }

                                        #endregion

                                        decimal dMR_MeterialQty =
                                            clsHelpMethods_Prod.AlreadyRequestedQty_formMRs(oProdJobBom.ProdJob_ID,
                                                oBatch.ProdBatch_ID, oProdJobBomMaterial.Item_ID);
                                        decimal dpGIN_MeterialQty =
                                            clsHelpMethods_Prod.AlreadyIssuedQty_formPGINs(oProdJobBom.ProdJob_ID,
                                                oBatch.ProdBatch_ID, oProdJobBomMaterial.Item_ID);
                                        decimal dpGRN_MeterialQty =
                                            clsHelpMethods_Prod.AlreadyReturnedQty_formPGRNs(oProdJobBom.ProdJob_ID,
                                                oBatch.ProdBatch_ID, oProdJobBomMaterial.Item_ID);
                                        decimal dWIP_MeterialQty =
                                            clsHelpMethods_Prod.AlreadyConsumedQty_formWIPs(oProdJobBom.ProdJob_ID,
                                                oBatch.ProdBatch_ID, oProdJobBomMaterial.Item_ID);

                                        glb_dtsBoMs.dt_prodJob_material.Adddt_prodJob_materialRow(
                                            oProdJobBomMaterial.Line_No,
                                            oProdJobBomMaterial.ProdJob_ID,
                                            oProdJobBomMaterial.IsSemiFinishItem,
                                            clsGenaralName.getName_Item(oProdJobBomMaterial.Item_ID),
                                            clsGenaralName.getName_Item(oProdJobBomMaterial.Item_ID),
                                            oProdJobBomMaterial.Uom_ID,
                                            clsGenaralName.getName_Uom(oProdJobBomMaterial.Uom_ID),
                                            oProdJobBomMaterial.InputQty,
                                            oProdJobBomMaterial.Section_ID,
                                            clsGenaralName.getName_Section(oProdJobBomMaterial.Section_ID),
                                            "", (oProdJobBomMaterial.TotalInputQty * oBatch.BatchQty), //Planned Qty
                                            dMR_MeterialQty, //MR Qty
                                            dpGIN_MeterialQty, //pGIN Qty
                                            dpGRN_MeterialQty, //pGRN Qty
                                            dWIP_MeterialQty, //WIP Qty
                                            oProdJobBomMaterial.Line_No_Sub1 > 0 ? (dpGIN_MeterialQty - dpGRN_MeterialQty) : oProdJobBomMaterial.IsSemiFinishItem ? 0m : (dpGIN_MeterialQty - dpGRN_MeterialQty - dWIP_MeterialQty), //Balance
                                            oBatch.ProdBatch_ID, oProdJobBomMaterial.Smv_TimeMinutes, "");

                                        iRowMatCount++;
                                    }

                                    #endregion

                                    #region Fill Header

                                    if (iRowMatCount > 0)
                                    {
                                        glb_dtsBoMs.dt_prodJob.Adddt_prodJobRow(
                                            oProdJobBom.ProdJob_ID, oProdJobBom.ProdJobDate,
                                            clsHelpMethods_Prod.GetEnumDescription(
                                                (prod_Batch_Status)oBatch.BatchStatus),
                                            oProdJobBom.Salesman_ID, oProdJobBom.Customer_ID,
                                            clsGenaralName.getName_Customer(oProdJobBom.Customer_ID),
                                            oProdJobBom.CustomerOrder_ID,
                                            oProdJobBom.Item_ID_FG, clsGenaralName.getName_Item(oProdJobBom.Item_ID_FG),
                                            clsGenaralName.getDescription_Item(oProdJobBom.Item_ID_FG),
                                            clsGenaralName.getCode_Item(oProdJobBom.Item_ID_FG),
                                            oProdJobBom.ProdStartDate, oProdJobBom.ExfactoryDate, oProdJobBom.FGoodQty,
                                            oProdJobBom.Uom_ID, oProdJobBom.IsApproved1, oProdJobBom.IsApproved2,
                                            oProdJobBom.IsApproved3, oProdJobBom.IsLocked, oBatch.ProdBatch_ID,
                                            oBatch.BatchStatus,
                                            "", clsGenaralName.getName_ItemClass(oProdJobBom.JobType_ID),
                                            clsGenaralName.getName_ItemType(oProdJobBom.ProdRange_ID),
                                            clsGenaralName.getName_ItemCategory(oProdJobBom.ProdCategory_ID),
                                            clsGenaralName.getName_Tag3(oProdJobBom.ProdSize_ID),
                                            clsGenaralName.getName_Colour(oProdJobBom.Colour_ID),
                                            iNoOfAttachments.ToString(),
                                            oProdJobBom.Remarks + " " + oProdJobBom.Remarks2,
                                            oProdJobBom.CustomerOrder_Qty, "",
                                            "", "", "", "", "", "", "", "", "");
                                    }

                                    #endregion
                                }
                            }
                            else
                            {
                                glb_dtsBoMs.dt_prodJob.Adddt_prodJobRow(
                                            oProdJobBom.ProdJob_ID,
                                            oProdJobBom.ProdJobDate, "No Prodction Job/Batch",
                                            oProdJobBom.Salesman_ID, oProdJobBom.Customer_ID,
                                            clsGenaralName.getName_Customer(oProdJobBom.Customer_ID),
                                            oProdJobBom.CustomerOrder_ID,
                                            oProdJobBom.Item_ID_FG,
                                            clsGenaralName.getName_Item(oProdJobBom.Item_ID_FG),
                                            clsGenaralName.getDescription_Item(oProdJobBom.Item_ID_FG),
                                            clsGenaralName.getCode_Item(oProdJobBom.Item_ID_FG),
                                            oProdJobBom.ProdStartDate, oProdJobBom.ExfactoryDate, oProdJobBom.FGoodQty,
                                            oProdJobBom.Uom_ID, oProdJobBom.IsApproved1, oProdJobBom.IsApproved2,
                                            oProdJobBom.IsApproved3, oProdJobBom.IsLocked, "-",
                                            0, "No Prodction Job/Batch",
                                            clsGenaralName.getName_ItemClass(oProdJobBom.JobType_ID),
                                            clsGenaralName.getName_ItemType(oProdJobBom.ProdRange_ID),
                                            clsGenaralName.getName_ItemCategory(oProdJobBom.ProdCategory_ID),
                                            clsGenaralName.getName_Tag3(oProdJobBom.ProdSize_ID),
                                            clsGenaralName.getName_Colour(oProdJobBom.Colour_ID),
                                            iNoOfAttachments.ToString(),
                                            oProdJobBom.Remarks + " " + oProdJobBom.Remarks2,
                                            oProdJobBom.CustomerOrder_Qty, "",
                                            "", "", "", "", "", "", "", "", "");
                            }

                            #region Fill Delivery Details
                            foreach (tbl_prodTxJobCard_Delivery oDelivery in tbl_prodTxJobCard_Delivery.SelectAllByProdJob_ID(oProdJobBom.ProdJob_ID))
                            {
                                glb_dtsBoMs.dt_prodJob_delivery.Adddt_prodJob_deliveryRow(oDelivery.Line_No,
                                    oDelivery.ProdJob_ID, oDelivery.DeliverDateTime, oDelivery.DeliverQty,
                                    oDelivery.DeliverUoM, clsGenaralName.getName_UomAndCode(oDelivery.DeliverUoM),
                                    oDelivery.DeliverTerms, oDelivery.Remarks, oDelivery.DeliverAddress);
                            }
                            #endregion
                        }

                        #region Set company Details
                        glb_dtsBoMs.dt_company.Adddt_companyRow(clsSecurity.DigiteqName,
                            clsSecurity.DigiteqEmail,
                            clsSecurity.CompanyName,
                           clsSecurity.CompanyAddress1,
                            clsSecurity.CompanyAddress2,
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

        #region Grid Events
        private void dgv_Reports_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //try
            //{
            //    DataRowView item = (sender as DataGrid)?.SelectedItem as DataRowView;
            //    if (item != null)
            //    {
            //        object[] obj = item.Row.ItemArray;
            //        int iReportId = int.Parse(obj[0].ToString());

            //        enum_ReportName EnumReport = (enum_ReportName)iReportId;
            //        tbl_securityFunctionMaster oFunction = tbl_securityFunctionMaster.Select(iReportId);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    SEACCExeption.Show(ex);
            //}
        }
        #endregion

        #region Search Events

        private void TxtBoMJob_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionBoMJobs);
            if (RowDataSearch.DialogResult == true)
            {
                txtBoMJob.Tag = lstResult[0];
                txtBoMJob.Text = lstResult[0] + " - " + lstResult[3];

                tbl_prodTxJobCard oBoM = tbl_prodTxJobCard.Select(lstResult[0]);

                txtJobName.Tag = oBoM.JobType_ID;
                txtJobName.Text = clsGenaralName.getName_ItemClass(oBoM.JobType_ID);

                txtCustomer.Tag = oBoM.Customer_ID;
                txtCustomer.Text = clsGenaralName.getName_Customer(oBoM.Customer_ID);
            }
        }

        private void txtJobName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
            RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionJobName);
            if (RowDataSearch.DialogResult == true)
            {
                txtJobName.Tag = lstResult[0];
                txtJobName.Text = lstResult[1] + " - " + lstResult[3];

                if (clsHelpMethods_Prod.IsJobType_MakeToSupply(lstResult[0]))
                {
                    txtCustomer.Tag = "CUS/00000";
                    txtCustomer.Text = clsGenaralName.getName_Customer(txtCustomer.Tag.ToString());
                }

            }
        }

        private void txtCutomer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Customer);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomer.Tag = lstResult[0];
                txtCustomer.Text = lstResult[1];
            }
        }

        private void TxtBatch_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            if (txtBoMJob.Tag != null)
                lstParameeters.Add(txtBoMJob.Tag.ToString());

            frm_search RowDataSearch = new frm_search(lstParameeters);
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_AllBatches);
            if (RowDataSearch.DialogResult == true)
            {
                txtBatch.Tag = lstResult[0];
                txtBatch.Text = lstResult[0];

                tbl_prodTxBatch oBatch = tbl_prodTxBatch.Select(lstResult[0]);
                if (oBatch != null)
                {
                    txtBoMJob.Tag = oBatch.ProdJob_ID;
                    txtBoMJob.Text = oBatch.ProdJob_ID + "  - " + clsGenaralName.getName_Item(oBatch.Item_ID);

                    tbl_prodTxJobCard oBoM = tbl_prodTxJobCard.Select(oBatch.ProdJob_ID);

                    txtJobName.Tag = oBoM.JobType_ID;
                    txtJobName.Text = clsGenaralName.getName_ItemClass(oBoM.JobType_ID);

                    txtCustomer.Tag = oBoM.Customer_ID;
                    txtCustomer.Text = clsGenaralName.getName_Customer(oBoM.Customer_ID);
                }
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
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionMaterials);
            if (RowDataSearch.DialogResult == true)
            {
                txtRawMeterial.Tag = lstResult[0];
                txtRawMeterial.Text = lstResult[2];
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
    }

}
