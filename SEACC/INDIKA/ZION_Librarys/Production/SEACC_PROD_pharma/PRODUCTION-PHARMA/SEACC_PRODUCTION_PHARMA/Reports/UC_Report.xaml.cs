using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SEACC_PRODUCTION_PHARMA.DataSets;
using SEACC_PRODUCTION_PHARMA.Common;
using SEACC_PRODUCTION_PHARMA.Search;

namespace SEACC_PRODUCTION_PHARMA.Reports
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
        dts_FGTN glb_dtsFGTN = new dts_FGTN();
        dts_ProdCosting glb_dtsProdCost = new dts_ProdCosting();
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
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBatch, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCutomer, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProdSection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishedGood, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFG_Class, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFG_Type, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFG_Category, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtRawMeterial, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFromStore, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtToStore, true, false, false);

            txtBoMJob.Tag = null;
            txtBatch.Tag = null;
            txtCutomer.Tag = null;
            txtProdSection.Tag = null;
            txtFinishedGood.Tag = null;
            txtFG_Class.Tag = null;
            txtFG_Type.Tag = null;
            txtFG_Category.Tag = null;
            txtRawMeterial.Tag = null;
            txtFromStore.Tag = null;
            txtToStore.Tag = null;

            txtBoMJob.Text = "<All BoM>";
            txtBatch.Text = "<All Jobs>";
            txtCutomer.Text = "<All Customers>";
            txtProdSection.Text = "<All Production Sections>";
            txtFinishedGood.Text = "<All Finished Goods>";
            txtFG_Class.Text = "<All FG Item Class>";
            txtFG_Type.Text = "<All FG Item Types>";
            txtFG_Category.Text = "<All FG Categories>";
            txtRawMeterial.Text = "<All Raw Materials>";
            txtFromStore.Text = "<All Stores>";
            txtToStore.Text = "<All Stores>";

            msbProdBatch_Status.ClearData();
            foreach (prod_Batch_Status pjs in Enum.GetValues(typeof(prod_Batch_Status)))
                msbProdBatch_Status.SetData(true, ((int)pjs).ToString(), pjs.ToString());

            dtp_FromDate.SetTime(DateTime.Now);
            dtp_ToDate.SetTime(DateTime.Now);

            if (chkActiveRecords != null)
                chkActiveRecords.IsChecked = false;

            if (chkDeletedRecords != null)
                chkDeletedRecords.IsChecked = false;


            txtBoMJob.Visibility = Visibility.Collapsed;
            txtBatch.Visibility = Visibility.Collapsed;
            txtCutomer.Visibility = Visibility.Collapsed;
            txtProdSection.Visibility = Visibility.Collapsed;
            txtFinishedGood.Visibility = Visibility.Collapsed;
            txtFG_Class.Visibility = Visibility.Collapsed;
            txtFG_Type.Visibility = Visibility.Collapsed;
            txtFG_Category.Visibility = Visibility.Collapsed;
            txtRawMeterial.Visibility = Visibility.Collapsed;
            txtFromStore.Visibility = Visibility.Collapsed;
            txtToStore.Visibility = Visibility.Collapsed;
            msbProdBatch_Status.Visibility = Visibility.Collapsed;
            if (chkDeletedRecords != null)
                chkDeletedRecords.Visibility = Visibility.Collapsed;
            if (chkActiveRecords != null)
                chkActiveRecords.Visibility = Visibility.Collapsed;

        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dt_Reports.Clear();
                foreach (tbl_securityFunctionMaster oReports in tbl_securityFunctionMaster.SelectAll().Where(p => p.IsVisible && p.IsReport && p.FunctionCategory_ID == "PROD/018"))
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
                tbl_securityFunctionMaster_Permission oUserPermission = tbl_securityFunctionMaster_Permission.Select(clsSecurity.BranchID, clsSecurity.UserIDLoged, oReport.Function_ID);
                #endregion

                glb_dtsBoMs.Clear();
                glb_dtsWIP.Clear();
                glb_dtsFGTN.Clear();
                glb_dtsProdCost.Clear();

                if (oFunction != null && oReport != null)
                {
                    #region Filter Definitions
                    string sFilter = "";
                    bool bSelectProdJobBoM = false, bSelectCustomer = false, bSelectProdSection = false, bSelectProdBatch = false, bSelectProdJobStatus = false,
                        bSelectRawMaterial = false, bSelectFinishedGood = false, bSelectItemClass = false, bSelectItemType = false, bSelectItemCategory = false, bSelectFromStore = false, bSelectToStore = false;
                    var vBatchStatus = msbProdBatch_Status.GetData().Rows.Count > 0 ? msbProdBatch_Status.GetData().AsEnumerable().ToList() : null;

                    if (txtBoMJob.Tag != null && txtBoMJob.Tag.ToString() != "default")
                    {
                        bSelectProdJobBoM = true;
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "BoM # : " + txtBoMJob.Text.Trim();
                    }
                    else
                    {
                        if (oReport.Function_ID != 17202)
                            sFilter += (sFilter.Length != 0 ? " | " : "") + "BoM # : All ";
                    }

                    if (txtFinishedGood.Tag != null && txtFinishedGood.Tag.ToString() != "default")
                    {
                        bSelectFinishedGood = true;
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "FG Sales Name : " + txtFinishedGood.Text.Trim();
                    }
                    else
                    {
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "FG Sales Name : All ";
                    }

                    if (txtFG_Class.Tag != null && txtFG_Class.Tag.ToString() != "default")
                    {
                        bSelectItemClass = true;
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "FG Item Class : " + txtFG_Class.Text.Trim();
                    }
                    else
                    {
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "FG Item Class : All ";
                    }

                    if (txtFG_Type.Tag != null && txtFG_Type.Tag.ToString() != "default")
                    {
                        bSelectItemType = true;
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "FG Item Type : " + txtFG_Type.Text.Trim();
                    }
                    else
                    {
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "FG Item Type : All ";
                    }

                    if (txtFG_Category.Tag != null && txtFG_Category.Tag.ToString() != "default")
                    {
                        bSelectItemType = true;
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "FG Item Category : " + txtFG_Category.Text.Trim();
                    }
                    else
                    {
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "FG Item Category : All ";
                    }

                    if (txtCutomer.Tag != null && txtCutomer.Tag.ToString() != "default")
                    {
                        bSelectCustomer = true;
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Customer : " + txtCutomer.Text.Trim();
                    }
                    else
                    {
                        if (oReport.Function_ID != 17202)
                            sFilter += (sFilter.Length != 0 ? " | " : "") + "Customer : All ";
                    }

                    if (txtBatch.Tag != null && txtBatch.Tag.ToString() != "default")
                    {
                        bSelectProdBatch = true;
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Job/Batch # : " + txtBatch.Text.Trim();
                    }
                    else
                    {
                        if (oReport.Function_ID != 17202)
                            sFilter += (sFilter.Length != 0 ? " | " : "") + "Job/Batch # : All ";
                    }

                    if (txtProdSection.Tag != null && txtProdSection.Tag.ToString() != "default")
                    {
                        bSelectProdSection = true;
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Production Section : " + txtProdSection.Text.Trim();
                    }
                    else
                    {
                        if (oReport.Function_ID != 17202)
                            sFilter += (sFilter.Length != 0 ? " | " : "") + "Production Section : All ";
                    }

                    if (txtRawMeterial.Tag != null && txtRawMeterial.Tag.ToString() != "default")
                    {
                        bSelectRawMaterial = true;
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Raw Material : " + txtRawMeterial.Text.Trim();
                    }
                    else
                    {
                        if (oReport.Function_ID != 17202)
                            sFilter += (sFilter.Length != 0 ? " | " : "") + "Raw Materials : All ";
                    }

                    if (txtFromStore.Tag != null && txtFromStore.Tag.ToString() != "default")
                    {
                        bSelectFromStore = true;
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Issued From : " + txtFromStore.Text.Trim();
                    }
                    else
                    {
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Issued From : All ";
                    }

                    if (txtToStore.Tag != null && txtToStore.Tag.ToString() != "default")
                    {
                        bSelectToStore = true;
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Issued To : " + txtToStore.Text.Trim();
                    }
                    else
                    {
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Issued To : All ";
                    }

                    if (chkDeletedRecords.IsChecked)
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Deleted Records Included ";

                    if (chkActiveRecords.IsChecked)
                        sFilter += (sFilter.Length != 0 ? " | " : "") + "Active Records Included ";

                    string sDateRange = "Report Period - " + dtp_FromDate.GetDateTime().ToString("yyyy/MMM/dd") + "  to  " + dtp_ToDate.GetDateTime().ToString("yyyy/MMM/dd");
                    #endregion

                    #region Production Input Materials Movement Report
                    if (oReport.Function_ID == (int)enum_ReportName.ProdPharma_InputMaterialsMovement)
                    {
                        foreach (tbl_prod_pharmaTxJobCard oProdJobBom in tbl_prod_pharmaTxJobCard.SelectAll().Where(r => r.ProdJob_ID != "default" &&
                                                                                                      r.ProdJobStatus != (int)prod_BoM_Status.Obsolete &&
                                                                                                      r.ProdStartDate.Date >= dtp_FromDate.GetDateTime().Date &&
                                                                                                      r.ProdStartDate.Date <= dtp_ToDate.GetDateTime().Date))
                        {
                            foreach (tbl_prod_pharmaTxBatch oBatch in tbl_prod_pharmaTxBatch.SelectAllByProdJob_ID(oProdJobBom.ProdJob_ID))
                            {
                                #region Selected Filters
                                if (bSelectProdJobBoM)
                                {
                                    if (txtBoMJob.Tag.ToString() != oBatch.ProdJob_ID)
                                        continue;
                                }
                                if (bSelectFinishedGood)
                                {
                                    if (txtFinishedGood.Tag.ToString() != oBatch.Item_ID)
                                        continue;
                                }
                                if (bSelectCustomer)
                                {
                                    if (txtCutomer.Tag.ToString() != clsGenaralName.getCustomerID_FromCO(oBatch.CustomerOrder_ID))
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
                                                   oProdJobBom.ProdStartDate, oProdJobBom.ExfactoryDate, oProdJobBom.FGoodQty, oProdJobBom.Uom_ID, oProdJobBom.IsApproved1, oProdJobBom.IsApproved2, oProdJobBom.IsApproved3, oProdJobBom.IsLocked, oBatch.ProdBatch_ID, oBatch.BatchStatus);

                                #endregion

                                #region Fill Job Material Details
                                foreach (tbl_prod_pharmaTxBatch_Material oProdJobBom_Material in tbl_prod_pharmaTxBatch_Material.SelectAllByProdBatch_ID(oBatch.ProdBatch_ID))
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

                                    decimal dMR_MeterialQty = clsHelpMethods_Prod.AlreadyRequestedQty_formMRs(oProdJobBom.ProdJob_ID, oBatch.ProdBatch_ID, oProdJobBom_Material.Item_ID, oProdJobBom_Material.Section_ID);
                                    decimal dpGIN_MeterialQty = clsHelpMethods_Prod.AlreadyIssuedQty_formPGINs(oProdJobBom.ProdJob_ID, oBatch.ProdBatch_ID, oProdJobBom_Material.Item_ID);
                                    decimal dpGRN_MeterialQty = clsHelpMethods_Prod.AlreadyReturnedQty_formPGRNs(oProdJobBom.ProdJob_ID, oBatch.ProdBatch_ID, oProdJobBom_Material.Item_ID);
                                    decimal dWIP_MeterialQty = clsHelpMethods_Prod.AlreadyConsumedQty_formWIPs(oProdJobBom.ProdJob_ID, oBatch.ProdBatch_ID, oProdJobBom_Material.Item_ID);

                                    glb_dtsBoMs.dt_prodJob_material.Adddt_prodJob_materialRow(
                                        oProdJobBom_Material.ProdJob_ID,
                                        oProdJobBom_Material.IsSemiFinishItem,
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
                                        (dpGIN_MeterialQty - dpGRN_MeterialQty - dWIP_MeterialQty), //Balance
                                        oBatch.ProdBatch_ID);
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
                    else if (oReport.Function_ID == (int)enum_ReportName.ProdPharma_WorkInProgressSummary)
                    {
                        foreach (tbl_prod_pharmaTxWorkInProgress oProdWIP in tbl_prod_pharmaTxWorkInProgress.SelectAll().Where(r => !r.IsCanceled && r.Wip_Date.Date >= dtp_FromDate.GetDateTime().Date && r.Wip_Date.Date <= dtp_ToDate.GetDateTime().Date))
                        {
                            #region Prod Job BoM
                            tbl_prod_pharmaTxJobCard oProdJobBom = tbl_prod_pharmaTxJobCard.Select(oProdWIP.ProdJob_ID);
                            if (oProdJobBom == null)
                                continue;
                            #endregion

                            #region Prod Batch
                            tbl_prod_pharmaTxBatch oBatch = tbl_prod_pharmaTxBatch.Select(oProdWIP.ProdBatch_ID);
                            if (oBatch == null)
                                continue;
                            #endregion

                            #region Selected Header Filters
                            if (bSelectProdJobBoM)
                            {
                                if (txtBoMJob.Tag.ToString() != oProdWIP.ProdJob_ID)
                                    continue;
                            }
                            if (bSelectFinishedGood)
                            {
                                if (txtFinishedGood.Tag.ToString() != oProdWIP.Item_ID_FG)
                                    continue;
                            }
                            if (bSelectCustomer)
                            {
                                if (txtCutomer.Tag.ToString() != oProdJobBom.Customer_ID)
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
                            foreach (tbl_prod_pharmaTxWorkInProgress_Material oProdWIPDetails in tbl_prod_pharmaTxWorkInProgress_Material.SelectAllByWip_ID(oProdWIP.Wip_ID))
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
                                    clsGenaralName.getName_Section(oProdWIPDetails.Output_Section_ID), oProdWIPDetails.Wip_ID);
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

                    #region Finished Good Transfer Report
                    else if (oReport.Function_ID == 17203)
                    {
                        var vFGTNs = tbl_prod_pharmaTxFinishedGoodTransferNote.SelectAll().Where(r =>
                            r.Fgtn_Date.Date >= dtp_FromDate.GetDateTime().Date &&
                            r.Fgtn_Date.Date <= dtp_ToDate.GetDateTime().Date);

                        if (!chkDeletedRecords.IsChecked)
                            vFGTNs = vFGTNs.Where(r => !r.IsCanceled);
                        if (!chkActiveRecords.IsChecked)
                            vFGTNs = vFGTNs.Where(r => r.IsCanceled);

                        foreach (tbl_prod_pharmaTxFinishedGoodTransferNote oFGTN in vFGTNs)
                        {
                            if (bSelectFinishedGood)
                                if (oFGTN.Item_ID_FG != txtFinishedGood.Tag.ToString())
                                    continue;
                            if (bSelectFromStore)
                                if (oFGTN.From_Store_ID != txtFromStore.Tag.ToString())
                                    continue;
                            if (bSelectToStore)
                                if (oFGTN.To_Store_ID != txtToStore.Tag.ToString())
                                    continue;

                            tbl_genItemMaster oItemMaster = tbl_genItemMaster.Select(oFGTN.Item_ID_FG);
                            if (oItemMaster != null)
                            {
                                glb_dtsFGTN.dt_FGTN.Adddt_FGTNRow(oFGTN.Fgtn_ID, oFGTN.Fgtn_Date,
                                    oFGTN.Item_ID_FG, clsGenaralName.getName_Item(oFGTN.Item_ID_FG),
                                    oItemMaster.ItemClass_ID, clsGenaralName.getName_ItemClass(oItemMaster.ItemClass_ID),
                                    oItemMaster.ItemType_ID, clsGenaralName.getName_ItemType(oItemMaster.ItemType_ID),
                                    oItemMaster.ItemCategory_ID, clsGenaralName.getName_ItemCategory(oItemMaster.ItemCategory_ID),
                                        clsGenaralName.getName_Uom(oFGTN.Uom_ID), 0m, oFGTN.ProdJob_ID, oFGTN.ProdBatch_ID, oFGTN.BatchQty, oFGTN.PreviousIssuedQty, oFGTN.FgtnQty, oFGTN.TotalAmount < 0 ? 0 : oFGTN.TotalAmount, oFGTN.FgtnQty <= 0 || oFGTN.UnitPrice < 0 ? 0m : oFGTN.UnitPrice,
                                    oFGTN.From_Store_ID, clsGenaralName.getName_Store(oFGTN.From_Store_ID),
                                    oFGTN.To_Store_ID, clsGenaralName.getName_Store(oFGTN.To_Store_ID), oFGTN.Remark, oFGTN.IsCanceled);
                            }
                        }

                        #region Set company Details
                        glb_dtsFGTN.dt_company.Adddt_companyRow(clsSecurity.DigiteqName,
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
                        frmViewer.print(oReport.ReportPath, glb_dtsFGTN, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                    }
                    #endregion

                    else if (oReport.Function_ID == 17204)
                    {
                        #region Fill Coil Data
                        //Fill Coil
                        foreach (tbl_genItemMaster oCoil in tbl_genItemMaster.SelectAllByItemCategory_ID("ICT/006").Where(r => !r.IsDeleted))
                        {
                            glb_dtsProdCost.dt_coil.Adddt_coilRow(oCoil.Item_ID, oCoil.ItemName);
                        }
                        #endregion

                        #region Fill Batch Data
                        foreach (tbl_prod_pharmaTxBatch oBatch in tbl_prod_pharmaTxBatch.SelectAll().Where(r => !r.IsCanceled && r.BatchDate.Date >= dtp_FromDate.GetDateTime().Date && r.BatchDate.Date <= dtp_ToDate.GetDateTime().Date))
                        {
                            tbl_genItemMaster oFG = tbl_genItemMaster.Select(oBatch.Item_ID);

                            if (bSelectProdJobBoM)
                            {
                                if (oBatch.ProdJob_ID != txtBoMJob.Tag.ToString())
                                {
                                    continue;
                                }
                            }
                            if (bSelectProdBatch)
                            {
                                if (oBatch.ProdBatch_ID != txtBatch.Tag.ToString())
                                {
                                    continue;
                                }
                            }
                            if (bSelectFinishedGood)
                            {
                                if (oBatch.Item_ID != txtFinishedGood.Tag.ToString())
                                {
                                    continue;
                                }
                            }
                            if (bSelectItemClass)
                            {
                                if (oFG == null || oFG.ItemClass_ID != txtFG_Class.Tag.ToString())
                                {
                                    continue;
                                }
                            }
                            if (bSelectItemType)
                            {
                                if (oFG == null || oFG.ItemType_ID != txtFG_Type.Tag.ToString())
                                {
                                    continue;
                                }
                            }
                            if (bSelectItemCategory)
                            {
                                if (oFG == null || oFG.ItemCategory_ID != txtFG_Category.Tag.ToString())
                                {
                                    continue;
                                }
                            }

                            decimal dInputKg = 0m;
                            decimal dOutputKg = 0m;
                            decimal dWastageKg = 0m;
                            decimal dInputCostPerKg = 0m;
                            decimal dInput_cost = 0m;

                            decimal dHeadingOutput_cost_PerGram = 0m;

                            decimal dStd_HeadingWeight = 0m;
                            decimal dStd_FinalWeight = 0m;

                            decimal dFinalOutput_cost_PerGram = 0m;

                            decimal dCost100_Heading = 0m;
                            decimal dCost100_Final = 0m;

                            string sCoil_ID = "";

                            bool bScrewNail = false;

                            decimal dBatchQty = clsHelpMethods_Prod.AlreadyMadeFG_formWIPs(oBatch.ProdJob_ID, oBatch.ProdBatch_ID);


                            foreach (tbl_prod_pharmaTxWorkInProgress oWIP in tbl_prod_pharmaTxWorkInProgress.SelectAllByProdBatch_ID(oBatch.ProdBatch_ID).Where(r => !r.IsCanceled))
                            {
                                decimal dPacks = clsHelpMethods_Prod.GetScrewNail_100PcksCountFromBatch(oWIP.ProdBatch_ID);

                                #region Heading Section Calculations
                                if (oWIP.Section_ID == "SECT/00002")
                                {
                                    foreach (tbl_prod_pharmaTxWorkInProgress_Material oWIP_Detail in tbl_prod_pharmaTxWorkInProgress_Material.SelectAllByWip_ID(oWIP.Wip_ID))
                                    {
                                        tbl_genItemMaster oWIP_Item = tbl_genItemMaster.Select(oWIP_Detail.Item_ID);

                                        //Identify the Coil
                                        if (oWIP_Item != null && oWIP_Item.ItemCategory_ID == "ICT/006")
                                        {
                                            sCoil_ID = oWIP_Item.Item_ID;

                                            dInputKg = (oWIP_Detail.InputOutput_Qty / 1000m);
                                            dInput_cost = oWIP_Detail.TotalAmount;

                                            dWastageKg = (oWIP_Detail.Waste_Qty / 1000m);

                                            dHeadingOutput_cost_PerGram = oWIP_Detail.UnitPrice;
                                            dInputCostPerKg = oWIP_Detail.UnitPrice * 1000m;
                                        }

                                        if (oWIP_Item != null && oWIP_Detail.Is_Output)
                                        {
                                            
                                            
                                            dCost100_Heading = (dPacks != 0 ?  (oWIP_Detail.InputOutput_Qty / dPacks) : 0);
                                        }
                                    }
                                }
                                #endregion

                                #region Final Section - Packing Section Calculations
                                if (oWIP.Section_ID == "SECT/00004")
                                {
                                    foreach (tbl_prod_pharmaTxWorkInProgress_Material oWIP_Detail in tbl_prod_pharmaTxWorkInProgress_Material.SelectAllByWip_ID(oWIP.Wip_ID))
                                    {
                                        //Pannel PIN
                                        if (oWIP_Detail.Item_ID.Trim().Contains("HSF"))
                                        {
                                            dOutputKg = (oWIP_Detail.InputOutput_Qty / 1000m);

                                            dFinalOutput_cost_PerGram = oWIP_Detail.UnitPrice;
                                            dStd_FinalWeight = oWIP_Detail.InputOutput_Qty;

                                            dCost100_Heading = 0m;
                                            dCost100_Final = 0m;

                                            bScrewNail = false;
                                        }

                                        //Screw Nail
                                        if (oWIP_Detail.Item_ID.Trim().Contains("TSF"))
                                        {
                                            dOutputKg = (oWIP_Detail.InputOutput_Qty / 1000m);

                                            dStd_FinalWeight = oWIP_Detail.InputOutput_Qty;

                                            dFinalOutput_cost_PerGram = oWIP_Detail.UnitPrice;
                                            dCost100_Final = dPacks != 0 ? (oWIP_Detail.TotalAmount / dPacks) : 0;

                                            bScrewNail = true;
                                        }
                                    }
                                }
                                #endregion
                            }

                            tbl_prod_pharmaTxJobCard oBoM = tbl_prod_pharmaTxJobCard.Select(oBatch.ProdJob_ID);
                            tbl_prod_pharmaTxJobCard_CostFooter oBoM_SellingPrice = tbl_prod_pharmaTxJobCard_CostFooter.Select(oBoM.ProdJob_ID, "PCF/013");//Selling Price Before Tax
                            tbl_prod_pharmaTxJobCard_CostFooter oBoM_NBT = tbl_prod_pharmaTxJobCard_CostFooter.Select(oBoM.ProdJob_ID, "PCF/014");//NBT
                            tbl_prod_pharmaTxJobCard_CostFooter oBoM_VAT = tbl_prod_pharmaTxJobCard_CostFooter.Select(oBoM.ProdJob_ID, "PCF/016");//VAT
                            tbl_prod_pharmaTxJobCard_CostFooter oBoM_SellingPriceNBT = tbl_prod_pharmaTxJobCard_CostFooter.Select(oBoM.ProdJob_ID, "PCF/015");//Selling Price With NBT
                            tbl_prod_pharmaTxJobCard_CostFooter oBoM_SellingPriceWithTax = tbl_prod_pharmaTxJobCard_CostFooter.Select(oBoM.ProdJob_ID, "PCF/017");//Selling Price With Taxes
                            tbl_prod_pharmaTxJobCard_CostFooter oBoM_Profit = tbl_prod_pharmaTxJobCard_CostFooter.Select(oBoM.ProdJob_ID, "PCF/007");//Profit
                            tbl_prod_pharmaTxJobCard_CostFooter oBoM_ProfitPct = tbl_prod_pharmaTxJobCard_CostFooter.Select(oBoM.ProdJob_ID, "PCF/006");//Profit Pct

                            if (oBoM != null)
                            {
                                dStd_HeadingWeight = ((dInputKg + dWastageKg) * 1000m);

                                glb_dtsProdCost.dt_jobCost.Adddt_jobCostRow(
                                    oBoM.ProdJob_ID,
                                    oBatch.ProdBatch_ID,
                                    dBatchQty,
                                    oBoM.Item_ID_FG, clsGenaralName.getName_Item(oBoM.Item_ID_FG),
                                    (dInputKg + dWastageKg),
                                    dInputCostPerKg,
                                    (dInputKg + dWastageKg) * dInputCostPerKg,
                                    dOutputKg,
                                    dWastageKg,
                                    (dOutputKg != 0 ? (dWastageKg * 100 / dOutputKg) : 0),// Wastage Pct
                                    dHeadingOutput_cost_PerGram, // Heading Cost Per gram
                                    dFinalOutput_cost_PerGram, // Final Cost Per gram
                                    dStd_HeadingWeight,
                                    dStd_FinalWeight,
                                    (dStd_HeadingWeight != 0 ? (dStd_FinalWeight * 100 / dStd_HeadingWeight) : 0),
                                    dCost100_Heading, dCost100_Final, oBoM_SellingPriceWithTax.Amount,
                                    0, (oBoM_VAT.Amount + oBoM_NBT.Amount), oBoM_NBT.Amount, oBoM_VAT.Amount,
                                    oBoM_SellingPrice.Amount, oBoM_Profit.Amount, oBoM_ProfitPct.Amount, sCoil_ID, bScrewNail);
                            }
                        }
                        #endregion

                        #region Fill company Details
                        glb_dtsProdCost.dt_company.Adddt_companyRow(clsSecurity.DigiteqName,
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
                        frmViewer.print(oReport.ReportPath, glb_dtsProdCost, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                    }

                    #region Production Cost for Screw Pin & Pannel Pin
                    else if (oReport.Function_ID == 17205)
                    {
                        #region Fill BOM Data
                        foreach (tbl_prod_pharmaTxJobCard oBoM in tbl_prod_pharmaTxJobCard.SelectAll().Where(r => !r.IsCanceled && r.ProdStartDate.Date >= dtp_FromDate.GetDateTime().Date && r.ProdStartDate.Date <= dtp_ToDate.GetDateTime().Date))
                        {
                            tbl_genItemMaster oFG = tbl_genItemMaster.Select(oBoM.Item_ID_FG);

                            if (bSelectProdJobBoM)
                            {
                                if (oBoM.ProdJob_ID != txtBoMJob.Tag.ToString())
                                {
                                    continue;
                                }
                            }
                            if (bSelectFinishedGood)
                            {
                                if (oBoM.Item_ID_FG != txtFinishedGood.Tag.ToString())
                                {
                                    continue;
                                }
                            }
                            if (bSelectItemClass)
                            {
                                if (oFG == null || oFG.ItemClass_ID != txtFG_Class.Tag.ToString())
                                {
                                    continue;
                                }
                            }
                            if (bSelectItemType)
                            {
                                if (oFG == null || oFG.ItemType_ID != txtFG_Type.Tag.ToString())
                                {
                                    continue;
                                }
                            }
                            if (bSelectItemCategory)
                            {
                                if (oFG == null || oFG.ItemCategory_ID != txtFG_Category.Tag.ToString())
                                {
                                    continue;
                                }
                            }

                            decimal dHeadingWeight = 0m;

                            decimal dCoil_Cost = 0m;
                            decimal dBox_cost = 0m;
                            decimal dLabel_cost = 0m;

                            foreach (tbl_prod_pharmaTxJobCard_Material oMaterial in tbl_prod_pharmaTxJobCard_Material.SelectAllByProdJob_ID(oBoM.ProdJob_ID))
                            {
                                tbl_genItemMaster oItem = tbl_genItemMaster.Select(oMaterial.Item_ID);

                                if (oItem != null && oItem.ItemCategory_ID.Trim() == "ICT/006")
                                {
                                    dHeadingWeight = oMaterial.TotalInputQty;//Heading Weight
                                    dCoil_Cost = oMaterial.EditedCost; // Raw Material Cost
                                }

                                else if (oMaterial.Item_ID.Contains("CB"))
                                {
                                    dBox_cost = oMaterial.EditedCost; // Box Cost
                                }

                                else if (oMaterial.Item_ID.Contains("LB"))
                                {
                                    dLabel_cost = oMaterial.EditedCost; // Label Cost
                                }
                            }
                            tbl_prod_pharmaTxJobCard_CostFooter oBoM_WrapPaper = tbl_prod_pharmaTxJobCard_CostFooter.Select(oBoM.ProdJob_ID, "PCF/004"); //Wrap Paper Cost
                            tbl_prod_pharmaTxJobCard_CostFooter oBoM_TotalCost = tbl_prod_pharmaTxJobCard_CostFooter.Select(oBoM.ProdJob_ID, "PCF/005"); //Other OH
                            tbl_prod_pharmaTxJobCard_CostFooter oBoM_OtherOH = tbl_prod_pharmaTxJobCard_CostFooter.Select(oBoM.ProdJob_ID, "PCF/011"); //Other OH                            
                            tbl_prod_pharmaTxJobCard_CostFooter oBoM_SellingPrice = tbl_prod_pharmaTxJobCard_CostFooter.Select(oBoM.ProdJob_ID, "PCF/013");//Selling Price Before Tax
                            tbl_prod_pharmaTxJobCard_CostFooter oBoM_NBT = tbl_prod_pharmaTxJobCard_CostFooter.Select(oBoM.ProdJob_ID, "PCF/014");//NBT
                            tbl_prod_pharmaTxJobCard_CostFooter oBoM_SellingPriceNBT = tbl_prod_pharmaTxJobCard_CostFooter.Select(oBoM.ProdJob_ID, "PCF/015");//Selling Price With NBT
                            tbl_prod_pharmaTxJobCard_CostFooter oBoM_VAT = tbl_prod_pharmaTxJobCard_CostFooter.Select(oBoM.ProdJob_ID, "PCF/016");//VAT
                            tbl_prod_pharmaTxJobCard_CostFooter oBoM_SellngPriceWithVAT = tbl_prod_pharmaTxJobCard_CostFooter.Select(oBoM.ProdJob_ID, "PCF/017");//Selling Price with VAT

                            tbl_prod_pharmaTxJobCard_CostFooter oBoM_Profit = tbl_prod_pharmaTxJobCard_CostFooter.Select(oBoM.ProdJob_ID, "PCF/007");//Margin
                            tbl_prod_pharmaTxJobCard_CostFooter oBoM_ProfitPct = tbl_prod_pharmaTxJobCard_CostFooter.Select(oBoM.ProdJob_ID, "PCF/006");//Markup

                            if (oBoM != null && oBoM_WrapPaper != null && oBoM_TotalCost != null && oBoM_OtherOH != null && oBoM_SellingPrice != null && oBoM_NBT != null && oBoM_SellingPriceNBT != null && oBoM_VAT != null && oBoM_SellngPriceWithVAT != null && oBoM_Profit != null && oBoM_ProfitPct != null)
                            {
                                glb_dtsProdCost.dt_BOM_CostFooter.Adddt_BOM_CostFooterRow(
                                    oBoM.ProdJob_ID, "", oBoM.Item_ID_FG, clsGenaralName.getName_Item(oBoM.Item_ID_FG), dHeadingWeight, dCoil_Cost, dLabel_cost, dBox_cost,
                                    oBoM_WrapPaper.Amount, oBoM_OtherOH.Amount, oBoM_NBT.Amount, oBoM_TotalCost.Amount, oBoM_SellingPrice.Amount,
                                    oBoM_SellingPrice.Amount, (oBoM_NBT.Amount + oBoM_VAT.Amount), oBoM_SellngPriceWithVAT.Amount, oBoM_Profit.Amount, oBoM_ProfitPct.Amount);
                            }
                        }
                        #endregion

                        #region Fill company Details
                        glb_dtsProdCost.dt_company.Adddt_companyRow(clsSecurity.DigiteqName,
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
                        frmViewer.print(oReport.ReportPath, glb_dtsProdCost, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
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
            try
            {
                DataRowView item = (sender as DataGrid)?.SelectedItem as DataRowView;
                if (item != null)
                {
                    object[] obj = item.Row.ItemArray;
                    int iReportId = int.Parse(obj[0].ToString());

                    enum_ReportName EnumReport = (enum_ReportName)iReportId;
                    tbl_securityFunctionMaster oFunction = tbl_securityFunctionMaster.Select(iReportId);
                    if (oFunction != null)
                    {
                        if (oFunction.Function_ID == 17203)
                        {
                            txtBoMJob.Visibility = Visibility.Collapsed;
                            txtBatch.Visibility = Visibility.Collapsed;
                            txtCutomer.Visibility = Visibility.Collapsed;
                            txtProdSection.Visibility = Visibility.Collapsed;
                            txtFinishedGood.Visibility = Visibility.Visible;
                            txtFG_Class.Visibility = Visibility.Collapsed;
                            txtFG_Type.Visibility = Visibility.Collapsed;
                            txtFG_Category.Visibility = Visibility.Collapsed;
                            txtRawMeterial.Visibility = Visibility.Collapsed;
                            txtFromStore.Visibility = Visibility.Visible;
                            txtToStore.Visibility = Visibility.Visible;
                            chkDeletedRecords.Visibility = Visibility.Visible;
                            chkActiveRecords.Visibility = Visibility.Visible;
                            msbProdBatch_Status.Visibility = Visibility.Collapsed;

                            chkActiveRecords.IsChecked = true;
                            chkDeletedRecords.IsChecked = false;
                        }
                        else if (oFunction.Function_ID == 17204 || oFunction.Function_ID == 17205)
                        {
                            txtBoMJob.Visibility = Visibility.Visible;
                            txtBatch.Visibility = Visibility.Collapsed;
                            txtCutomer.Visibility = Visibility.Collapsed;
                            txtProdSection.Visibility = Visibility.Collapsed;
                            txtFinishedGood.Visibility = Visibility.Visible;
                            txtFG_Class.Visibility = Visibility.Visible;
                            txtFG_Type.Visibility = Visibility.Visible;
                            txtFG_Category.Visibility = Visibility.Visible;
                            txtRawMeterial.Visibility = Visibility.Collapsed;
                            txtFromStore.Visibility = Visibility.Collapsed;
                            txtToStore.Visibility = Visibility.Collapsed;
                            chkDeletedRecords.Visibility = Visibility.Collapsed;
                            chkActiveRecords.Visibility = Visibility.Collapsed;
                            msbProdBatch_Status.Visibility = Visibility.Collapsed;

                            if (oFunction.Function_ID == 17204)
                            {
                                txtBatch.Visibility = Visibility.Visible;
                            }
                        }
                        else
                        {
                            txtBoMJob.Visibility = Visibility.Visible;
                            txtBatch.Visibility = Visibility.Visible;
                            txtCutomer.Visibility = Visibility.Visible;
                            txtProdSection.Visibility = Visibility.Visible;
                            txtFinishedGood.Visibility = Visibility.Visible;
                            txtFG_Class.Visibility = Visibility.Collapsed;
                            txtFG_Type.Visibility = Visibility.Collapsed;
                            txtFG_Category.Visibility = Visibility.Collapsed;
                            txtRawMeterial.Visibility = Visibility.Visible;
                            txtFromStore.Visibility = Visibility.Collapsed;
                            txtToStore.Visibility = Visibility.Collapsed;
                            chkDeletedRecords.Visibility = Visibility.Collapsed;
                            chkActiveRecords.Visibility = Visibility.Collapsed;
                            msbProdBatch_Status.Visibility = Visibility.Visible;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Events

        private void txtFinishedGood_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            try
            {
                DataRowView item = dgv_Reports.SelectedItem as DataRowView;
                if (item != null)
                {
                    object[] obj = item.Row.ItemArray;
                    int iReportId = int.Parse(obj[0].ToString());

                    enum_ReportName EnumReport = (enum_ReportName)iReportId;
                    tbl_securityFunctionMaster oFunction = tbl_securityFunctionMaster.Select(iReportId);
                    if (oFunction != null)
                    {
                        if (oFunction.Function_ID == 17202)
                        {
                            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_SemiFiniseds_FinishedGoods);
                            if (RowDataSearch.DialogResult == true)
                            {
                                txtFinishedGood.Tag = lstResult[0];
                                txtFinishedGood.Text = lstResult[2];
                            }
                        }
                        else
                        {
                            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionBoMJobs);
                            if (RowDataSearch.DialogResult == true)
                            {
                                txtBoMJob.Tag = lstResult[0];
                                txtBoMJob.Text = lstResult[0];

                                txtFinishedGood.Tag = lstResult[2];
                                txtFinishedGood.Text = lstResult[3];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }

        }

        private void TxtBoMJob_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionBoMJobs);
            if (RowDataSearch.DialogResult == true)
            {
                txtBoMJob.Tag = lstResult[0];
                txtBoMJob.Text = lstResult[0];

                txtFinishedGood.Tag = lstResult[2];
                txtFinishedGood.Text = lstResult[3];
            }
        }

        private void txtCutomer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Customer);
            if (RowDataSearch.DialogResult == true)
            {
                txtCutomer.Tag = lstResult[0];
                txtCutomer.Text = lstResult[1];
            }
        }

        private void TxtBatch_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            if (txtBoMJob.Tag != null)
                lstParameeters.Add(txtBoMJob.Tag.ToString());

            frm_search RowDataSearch = new frm_search(lstParameeters);
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ClosedBatches);
            if (RowDataSearch.DialogResult == true)
            {
                txtBatch.Tag = lstResult[0];
                txtBatch.Text = lstResult[0];

                tbl_prod_pharmaTxBatch oBatch = tbl_prod_pharmaTxBatch.Select(lstResult[0]);
                if (oBatch != null)
                {
                    txtBoMJob.Tag = oBatch.ProdJob_ID;
                    txtBoMJob.Text = oBatch.ProdJob_ID;

                    txtFinishedGood.Tag = oBatch.Item_ID;
                    txtFinishedGood.Text = clsGenaralName.getName_Item(oBatch.Item_ID);

                    txtCutomer.Tag = clsGenaralName.getCustomerID_FromCO(oBatch.CustomerOrder_ID);
                    txtCutomer.Text = clsGenaralName.getName_Customer(txtCutomer.Tag.ToString());
                }
            }
        }

        private void txtProdSection_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProcductionSections);
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
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionMaterials);
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

        private void TxtFromStore_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.StoresList);
            if (RowDataSearch.DialogResult == true)
            {
                txtFromStore.Tag = lstResult[0];
                txtFromStore.Text = lstResult[1];
            }
        }

        private void TxtToStore_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.StoresList);
            if (RowDataSearch.DialogResult == true)
            {
                txtToStore.Tag = lstResult[0];
                txtToStore.Text = lstResult[1];
            }
        }

        private void txtFG_Category_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ItemCategory);
            if (RowDataSearch.DialogResult == true)
            {
                txtFG_Category.Tag = lstResult[0];
                txtFG_Category.Text = lstResult[1];
            }
        }

        private void txtFG_Type_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ItemType);
            if (RowDataSearch.DialogResult == true)
            {
                txtFG_Type.Tag = lstResult[0];
                txtFG_Type.Text = lstResult[1];
            }
        }

        private void txtFG_Class_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ItemClass);
            if (RowDataSearch.DialogResult == true)
            {
                txtFG_Class.Tag = lstResult[0];
                txtFG_Class.Text = lstResult[1];
            }
        }
    }
}
