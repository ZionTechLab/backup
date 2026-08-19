using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Zion.ERP.Reports.DataSets;
using DataTire;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;
using System.IO;
using Zion.ERP.Reports.DataSets.SCS;
using ZION.ERP.Reports.DataSets.SCS;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using OfficeOpenXml.Style;
using Digiteq.Classes;

namespace Digiteq
{
    public partial class frm_rpt_StockStandedReport : MettroForm
    {
        
        //form manage
        public int iFormID;

        //for security handle
        public bool bNoAccess;

        DataTable glb_dtItemTracking;
        private dts_scsLoanInLoanOut glb_dts_scsLoanInLoanOut = new dts_scsLoanInLoanOut();
        //objects from datasets        
        dts_Stock glbDtsStock = new dts_Stock();
        dts_scsStockMovementReport_TW glb_dts_scsStockMovementReport_TW = new dts_scsStockMovementReport_TW();
        dts_scsItemList glbDtsItemList = new dts_scsItemList();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        public DataTable dtSelectedRecords = new DataTable();
        public List<string> SelectedRecordsList = new List<string>();

        bool bRouteSelected=false,  bStoreSelected = false, bItemSelected = false, bItemTypeSelected = false, bItemCategorySelected = false, bItemClassSelected = false, bPoNoSelected = false, bItemCostBy = false, bCostCenterSelected = false, bJobCategorySelected = false, bSupplierSelected = false;
        private bool bCompanyBranchSelected;

        enum_ReportName Report;
   

        #region Form Load
        public frm_rpt_StockStandedReport()
        {
            iFormID = clsSecurity.getFormID(FormName.scsStockStandedReport);
            CreateDataTable();
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();

            clsFill.Fill_ItemPrices(ref cmbItemPrice);
        }

        private void frmReportChequeDeposit_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "Stock Standard Report", 2, iFormID);
            ThemeColor = clsFormatter.colorStock;

            clearField();
            DisplayReports();

            //ReportPermitionOnRaioButton(ref flowLayoutPanel1);
        }

        public static void ReportPermitionOnRaioButton(ref FlowLayoutPanel pnl)
        {
            foreach (Control rb in pnl.Controls)
            {
                if (rb is RadioButton)
                {
                    rb.Enabled = false;
                    rb.Visible = false;

                    if (rb.Tag != null)
                    {
                        if (rb.Tag.ToString() != "")
                        {
                            //  enum_ReportName rptEnum = (enum_ReportName)(int.Parse(rb.Tag.ToString()));
                            // string sReport_ID = clsAutocode.getReportID(rb.Tag.ToString());
                            tbl_securityReportMaster oRptMaster = tbl_securityReportMaster.Select(rb.Tag.ToString());
                            if (oRptMaster != null && oRptMaster.IsEnable)
                            {
                                rb.Visible = true;
                                rb.Text = oRptMaster.DisplayName;

                                tbl_securityReportPermission oPermitions = tbl_securityReportPermission.Select(clsSecurity.UserIDLoged, oRptMaster.Report_ID, clsSecurity.CompanyID, clsSecurity.BranchID);
                                {
                                    if (oPermitions != null)
                                    {
                                        if (oPermitions.AllowView)
                                            rb.Enabled = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Display Reports
        private void DisplayReports()
        {
            try
            {
                dgvReports.Rows.Clear();
                dgvReports.DataSource = DBHandling.ExecQuery("EXEC sp_Reports '" + 12 + "'").Tables[0];
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearField();
        }
        #endregion

        #region Print Btn
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvReports.SelectedCells.Count != 0)
            {
                if (dgvReports.Rows.Count > 0)
                {
                    try
                    {
                        int iRow = dgvReports.SelectedCells[0].RowIndex;
                        int iReport = int.Parse(dgvReports.Rows[iRow].Cells[0].Value.ToString());

                        Report = (enum_ReportName)iReport;

                        if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(Report)))
                        {
                            string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                            if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(Report), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                            {
                                ProgressBar.Value = 0;
                                string sFilterOld = "", sFilter = "";
                                string sDaterange = "From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "  To : " + dtpTo.Value.ToString("dd MMM yyyy");

                                bRouteSelected = false; bStoreSelected = false; bItemSelected = false; bItemTypeSelected = false; bItemCategorySelected = false; bPoNoSelected = false; bCostCenterSelected = false;

                                #region Filters
                                if (txtStore.Tag != null && txtStore.Tag.ToString().Trim().Length > 0 && txtStore.Tag.ToString().Trim() != "default")
                                {
                                    bStoreSelected = true;
                                    sFilterOld += " | Store Name:" + txtStore.Tag.ToString();
                                    sFilter += "Store Name : " + txtStore.Text;
                                }
                                if (txtItemName.Tag != null && txtItemName.Tag.ToString().Trim().Length > 0 && txtItemName.Tag.ToString().Trim() != "default")
                                    bItemSelected = true;
                                if ((txtItemType.Tag != null && txtItemType.Tag.ToString().Trim().Length > 0 && txtItemType.Tag.ToString().Trim() != "default") || dtSelectedRecords.Rows.Count > 0)
                                {
                                    bItemTypeSelected = true;
                                    sFilter += (sFilter != "" ? " | " : "") + "Item Type : " + txtItemType.Text;
                                }
                                if (txtItemCategory.Tag != null && txtItemCategory.Tag.ToString().Trim().Length > 0 && txtItemCategory.Tag.ToString().Trim() != "default")
                                {
                                    bItemCategorySelected = true;
                                    sFilter += (sFilter != "" ? " | " : "") + "Item Category : " + txtItemCategory.Text;
                                }
                                if (txtItemClass.Tag != null && txtItemClass.Tag.ToString().Trim().Length > 0 && txtItemClass.Tag.ToString().Trim() != "default")
                                {
                                    bItemClassSelected = true;
                                    sFilter += (sFilter != "" ? " | " : "") + "Item Class : " + txtItemClass.Text;
                                }
                                if (txtRoute.Tag != null)
                                {
                                    bRouteSelected = true;
                                    sFilter += (sFilter != "" ? " | " : "") + "Route : " + txtRoute.Text;
                                }
                                if (txtPoNo.Tag != null && txtPoNo.Tag.ToString().Trim().Length > 0 && txtPoNo.Tag.ToString().Trim() != "default")
                                    bPoNoSelected = true;
                                if (cmbItemCostBy.Tag != null && cmbItemCostBy.Tag.ToString().Trim().Length > 0 && cmbItemCostBy.Tag.ToString().Trim() != "default")
                                    bItemCostBy = true;
                                if (txtCostCenter.Tag != null && txtCostCenter.Tag.ToString().Trim().Length > 0 && txtCostCenter.Tag.ToString().Trim() != "default")
                                    bCostCenterSelected = true;
                                if (txtJobCategory.Tag != null && txtJobCategory.Tag.ToString().Trim().Length > 0 && txtJobCategory.Tag.ToString().Trim() != "default")
                                    bJobCategorySelected = true;
                                if (txtSupplier.Tag != null && txtSupplier.Tag.ToString().Trim().Length > 0 && txtSupplier.Tag.ToString().Trim() != "default")
                                {
                                    bSupplierSelected = true;
                                    sFilterOld += " | Supplier Name:" + txtSupplier.Tag.ToString();
                                }
                                if (chkShowDeactivate.Checked)
                                {
                                    sFilter += (sFilter != "" ? " | " : "") + "All Items ";
                                }
                                #endregion

                                #region Stocks MOVEMENT REPORT
                                if (Report == enum_ReportName.ST_Stocks_MovementReport)
                                {
                                    #region Back date report
                                    Cursor = Cursors.WaitCursor;
                                    Stockreports oStockreport = new Stockreports(bStoreSelected, bItemCategorySelected, bItemTypeSelected, txtStore, txtItemName, txtItemCategory, SelectedRecordsList, dtpFrom.Value.Date, dtpTo.Value.Date, enum_CostPriceType.CostPrice2, chkShowDeactivate.Checked);
                                    oStockreport.GenarateFloorStockReport(Report, ref ProgressBar, chkTransactionValidateEnable.Checked, "Stock Movement Report (BIN Card)", "", txtCompanyBranch.Tag.ToString());

                                    oStockreport = null;
                                    Cursor = Cursors.Default;
                                    #endregion
                                }
                                #endregion

                                #region ITEM MOVEMENT REPORT Detail
                                if (Report == enum_ReportName.ST_Stocks_MovementReport_Detail)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dts_scsStockMovementReport_TW.Clear();
                                        glb_dtsReportExport.Clear();

                                        glb_dts_scsStockMovementReport_TW.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "Stocks Movement Report", "", sDaterange, clsSecurity.UserNameLoged, sFilter);

                                        string storeCode = bStoreSelected ? txtStore.Tag.ToString() : "%";
                                        string sItemCat = bItemCategorySelected ? txtItemCategory.Tag.ToString() : "%";
                                        string sItemType = bItemTypeSelected ? txtItemType.Tag.ToString() : "%";
                                        string sItemPriceCategory = ((ComboBoxItem)cmbItemPrice.SelectedItem).Value;

                                        string sQuary = "exec [srh_scsStockMovementReport] '" + dtpTo.Value.Date.ToString("yyyy-MM-dd") + "' , '" + dtpFrom.Value.Date.ToString("yyyy-MM-dd") + "' , '" + storeCode + "' , '" + sItemCat + "' , '" + sItemType + "' , '" + txtCompanyBranch.Tag.ToString() + "' , '" + sItemPriceCategory + "'";

                                        glb_dts_scsStockMovementReport_TW.dt_StockMovement.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                                        frm_ReportViewer_New CRViwer = new frm_ReportViewer_New();
                                        CRViwer.print("\\reports\\SCS\\BackDateReports\\rpt_scs_StockMovementReport_TW.rpt", glb_dts_scsStockMovementReport_TW, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                        //Stockreports oStockreport = new Stockreports(bStoreSelected, bItemCategorySelected, bItemTypeSelected, txtStore, txtItemName, txtItemCategory,SelectedRecordsList, dtpFrom.Value.Date, dtpTo.Value.Date, enum_CostPriceType.CostPrice2, chkShowDeactivate.Checked);
                                        //oStockreport.GenarateFloorStockReport(enum_ReportName.ST_Stocks_MovementReport_Detail, ref ProgressBar, chkTransactionValidateEnable.Checked, "Stock Movement Report", "");
                                        //oStockreport = null;

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Stock Statement - (ITEMS CARD)
                                if (Report == enum_ReportName.ST_Items_Card)
                                {
                                    #region Back date report
                                    Cursor = Cursors.WaitCursor;

                                    Stockreports oStockreport = new Stockreports(bStoreSelected, bItemCategorySelected, bItemTypeSelected, txtStore, txtItemName, txtItemCategory, SelectedRecordsList, dtpFrom.Value.Date, dtpTo.Value.Date, enum_CostPriceType.CostPrice2, chkShowDeactivate.Checked);
                                    oStockreport.GenarateFloorStockReport(Report, ref ProgressBar, chkTransactionValidateEnable.Checked, "Stock Statement", "", txtCompanyBranch.Tag.ToString());

                                    oStockreport = null;
                                    Cursor = Cursors.Default;
                                    #endregion
                                }
                                #endregion

                                #region Stock Statement
                                if (Report == enum_ReportName.ST_Stock_Statement)
                                {
                                    #region Back date report
                                    Cursor = Cursors.WaitCursor;

                                    Stockreports oStockreport = new Stockreports(bStoreSelected, bItemCategorySelected, bItemTypeSelected, txtStore, txtItemName, txtItemCategory, SelectedRecordsList, dtpFrom.Value.Date, dtpTo.Value.Date, enum_CostPriceType.CostPrice2, chkShowDeactivate.Checked);
                                    oStockreport.GenarateFloorStockReport(Report, ref ProgressBar, chkTransactionValidateEnable.Checked, "Stock Statement", "", txtCompanyBranch.Tag.ToString());

                                    oStockreport = null;
                                    Cursor = Cursors.Default;
                                    #endregion
                                }
                                #endregion

                                #region STOCKS TRACKING REPORT - QTY
                                if (Report == enum_ReportName.ST_Stocks_TrackingReport_Qty)
                                {
                                    Cursor = Cursors.WaitCursor;
                                    Stockreports oStockreport = new Stockreports(bStoreSelected, bItemCategorySelected, bItemTypeSelected, txtStore, txtItemName, txtItemCategory, SelectedRecordsList, dtpFrom.Value.Date, dtpTo.Value.Date, enum_CostPriceType.CostPrice2, chkShowDeactivate.Checked);
                                    oStockreport.GenarateFloorStockReport(Report, ref ProgressBar, chkTransactionValidateEnable.Checked, "Stocks Tracking Report - [Qty wise]", "", txtCompanyBranch.Tag.ToString());

                                    oStockreport = null;
                                    Cursor = Cursors.Default;
                                }
                                #endregion

                                #region STOCKS TRACKING REPORT - WEIGHT
                                if (Report == enum_ReportName.ST_Stocks_TrackingReport_Weight)
                                {
                                    Cursor = Cursors.WaitCursor;
                                    Stockreports oStockreport = new Stockreports(bStoreSelected, bItemCategorySelected, bItemTypeSelected, txtStore, txtItemName, txtItemCategory, SelectedRecordsList, dtpFrom.Value.Date, dtpTo.Value.Date, enum_CostPriceType.CostPrice2, chkShowDeactivate.Checked);
                                    oStockreport.GenarateFloorStockReport(Report, ref ProgressBar, chkTransactionValidateEnable.Checked, "Stocks Tracking Report - [Weight wise] ", "", txtCompanyBranch.Tag.ToString());

                                    oStockreport = null;
                                    Cursor = Cursors.Default;
                                }
                                #endregion

                                #region OPENING STOCKS REPORT
                                //if (rdoStockTake.Checked)
                                //{
                                //    //if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Opening_StockReport)))
                                //    //{
                                //    //    string sFormula = " {vw_scsWeeklyStockTake.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_scsWeeklyStockTake.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                //    //    if (txtItemName.Tag != null && txtItemName.Tag.ToString().Trim().Length > 0)
                                //    //        sFormula += " and {vw_scsWeeklyStockTake.item_ID} = '" + txtItemName.Tag.ToString().Trim() + "'";
                                //    //    if (txtStore.Tag != null && txtStore.Tag.ToString().Trim().Length > 0)
                                //    //        sFormula += " and {vw_scsWeeklyStockTake.store_ID} = '" + txtStore.Tag.ToString().Trim() + "'";

                                //    //    print("\\reports\\SCS\\Registry\\rpt_scs_WeeklyStockTake.rpt", "Openning Stocks Report", "", "", sFormula);
                                //    //}
                                //}
                                #endregion

                                #region PENDING PURCHASE ORDERS
                                if (Report == enum_ReportName.ST_Purchase_Order_Tracking_Report)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glbDtsStock.dt_scsPendingPurcheseOrder.Rows.Clear();
                                        List<tbl_scsPurchaseOrder> oPos = tbl_scsPurchaseOrder.SelectAll().Where(p => p.CompanyBranch_ID == txtCompanyBranch.Tag.ToString() && !p.IsDeleted && !p.IsSeattled && p.PurchaseOrder_ID != "default" && p.PurchaseOrderDate.Date >= dtpFrom.Value.Date && p.PurchaseOrderDate.Date <= dtpTo.Value.Date).ToList();
                                        foreach (tbl_scsPurchaseOrder oPO in oPos)
                                        {
                                            int iAgeing = clsCommon.getDaysUptoDate(oPO.PurchaseOrderDate);
                                            decimal dPendingAmount = 0;
                                            foreach (tbl_scsPurchaseOrder_Detail oPODetails in tbl_scsPurchaseOrder_Detail.SelectAllByPurchaseOrder_ID(oPO.PurchaseOrder_ID))
                                            {
                                                dPendingAmount += (oPODetails.Qty - oPODetails.QtySettle) * oPODetails.UnitPrice;
                                            }
                                            glbDtsStock.dt_scsPendingPurcheseOrder.Adddt_scsPendingPurcheseOrderRow(oPO.PurchaseOrder_ID, oPO.PurchaseOrderDate, clsGenaralName.getName_Supplier(oPO.Supplier_ID), iAgeing, dPendingAmount);

                                            clsHelpMethods_Local.startProgressBar(0, oPos.Count + 2, 1, ProgressBar);
                                            ProgressBar.Value = 0;
                                        }

                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle1", sReportTitle_Main, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", clsSecurity.CompanyName, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", clsSecurity.CompanyAddress1, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", clsSecurity.CompanyAddress2, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqName", clsSecurity.DigiteqName, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqEmail", clsCommon.getCompanyEmail(), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DateRange", "From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("UserName", clsSecurity.UserNameLoged, true);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glbDtsStock, glb_dtsReportExport.dt_rptParameter, false, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        glbDtsStock.dt_scsPendingPurcheseOrder.Rows.Clear();
                                    }
                                }
                                //}
                                #endregion

                                #region Item Split Note - Delta Report
                                if (Report == enum_ReportName.ST_Item_SplitNote_DeltaReport)
                                {
                                    string sFormula = "{vw_rpt_scsItemSplitNote.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_scsItemSplitNote.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                                    sFormula += " and {vw_rpt_scsItemSplitNote.isDeleted} = False";

                                    if (txtStore.Tag != null && txtStore.Tag.ToString().Trim().Length > 0)
                                        sFormula += " and {vw_rpt_scsItemSplitNote.store_ID} = '" + txtStore.Tag.ToString().Trim() + "'";

                                    print("\\reports\\SCS\\Standard\\rpt_scs_ItemSplitNote_Delta.rpt", "ST Item SplitNote DeltaReport", "", "", sFormula);
                                }
                                #endregion

                                #region Pending Loan-IN
                                //Removed
                                //if (rdoPendingLoanIn.Checked)
                                //{
                                //    /* 
                                //     if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Pending_LoanIn)))
                                //      {
                                //          string sFormula = "{vw_rpt_scsLoanOut.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_scsLoanOut.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                                //          sFormula += " and {vw_rpt_scsLoanOut.isDeleted} = False and {vw_rpt_scsLoanOut.isSeattled} = False";

                                //          print("\\reports\\SCS\\Standard\\rpt_scs_PendingLoanIn.rpt", "Pending Loan-IN Report", "", "", sFormula);

                                //      }
                                //     */
                                //}
                                #endregion

                                #region Store Requests vs Issues
                                if (Report == enum_ReportName.ST_Store_Requests_vs_Issues)
                                {
                                    string sFormula = " {vw_rpt_scsSRvsGIN.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_scsSRvsGIN.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                    if (txtItemName.Tag != null && txtItemName.Tag.ToString().Trim().Length > 0)
                                        sFormula += " and {vw_rpt_scsSRvsGIN.item_ID} = '" + txtItemName.Tag.ToString().Trim() + "'";
                                    if (txtStore.Tag != null && txtStore.Tag.ToString().Trim().Length > 0)
                                        sFormula += " and {vw_rpt_scsSRvsGIN.store_ID} = '" + txtStore.Tag.ToString().Trim() + "'";
                                    if (txtItemCategory.Tag != null && txtItemCategory.Tag.ToString().Trim().Length > 0)
                                        sFormula += " and {vw_rpt_scsSRvsGIN.itemCategory_ID} = '" + txtItemCategory.Tag.ToString().Trim() + "'";
                                    if (txtItemType.Tag != null && txtItemType.Tag.ToString().Trim().Length > 0)
                                        sFormula += " and {vw_rpt_scsSRvsGIN.itemType_ID} = '" + txtItemType.Tag.ToString().Trim() + "'";

                                    print("\\reports\\SCS\\Standard\\rpt_scs_SRvsGIN.rpt", "Store Requests vs Issues", "[SR vs GIN]", "", sFormula);
                                }
                                #endregion

                                #region Stock Value Report
                                //else if (rdoStockValueReport.Checked || rdoStoreValueItemTypeWise.Checked || rdoStockValueReport_Qty.Checked || rdoStockValueReport_Weight.Checked)
                                if (Report == enum_ReportName.ST_Stock_Value_Report || Report == enum_ReportName.ST_Stock_Value_Report_Item_Type_Wice ||
                                    //Report == enum_ReportName.ST_Stock_Value_Report_Qty_Detail || 
                                    Report == enum_ReportName.ST_Stock_Value_Report_Qty ||
                                    //Report == enum_ReportName.ST_Stock_Value_Report_Waight_Detail || 
                                    Report == enum_ReportName.ST_Stock_Value_Report_Waight)
                                {
                                    Cursor = Cursors.WaitCursor;

                                    #region Item Cost Type
                                    enum_CostPriceType eCostType = enum_CostPriceType.CostPrice2;
                                    if (cmbItemCostBy.SelectedIndex == 0)
                                        eCostType = enum_CostPriceType.WeightedAverage;
                                    if (cmbItemCostBy.SelectedIndex == 1)
                                        eCostType = enum_CostPriceType.LIFO;
                                    if (cmbItemCostBy.SelectedIndex == 2)
                                        eCostType = enum_CostPriceType.FIFO;
                                    if (cmbItemCostBy.SelectedIndex == 3)
                                        eCostType = enum_CostPriceType.HighestPurchaseCost;
                                    if (cmbItemCostBy.SelectedIndex == 4)
                                        eCostType = enum_CostPriceType.LovestPurchaseCost;
                                    if (cmbItemCostBy.SelectedIndex == 5)
                                        eCostType = enum_CostPriceType.CostPrice1;
                                    if (cmbItemCostBy.SelectedIndex == 6)
                                        eCostType = enum_CostPriceType.CostPrice2;
                                    #endregion

                                    Stockreports oStockreport = new Stockreports(bStoreSelected, bItemCategorySelected, bItemTypeSelected, txtStore, txtItemName, txtItemCategory, SelectedRecordsList, dtpTo.Value.Date.AddDays(1), dtpTo.Value.Date.AddDays(1), eCostType, chkShowDeactivate.Checked);

                                    #region Report Selector                                                                 

                                    if (Report == enum_ReportName.ST_Stock_Value_Report_Qty)
                                    {
                                        if (!ChkSummary.Checked)
                                            Report = enum_ReportName.ST_Stock_Value_Report_Qty_Detail;
                                        else
                                            Report = enum_ReportName.ST_Stock_Value_Report_Qty;
                                    }
                                    else if (Report == enum_ReportName.ST_Stock_Value_Report_Waight)
                                    {
                                        if (!ChkSummary.Checked)
                                            Report = enum_ReportName.ST_Stock_Value_Report_Waight_Detail;
                                        else
                                            Report = enum_ReportName.ST_Stock_Value_Report_Waight;
                                    }
                                    #endregion

                                    oStockreport.GenarateFloorStockReport(Report, ref ProgressBar, false, "Stock Value Report", " - Qty ", txtCompanyBranch.Tag.ToString());

                                    oStockreport = null;
                                    Cursor = Cursors.Default;
                                }
                                #endregion

                                #region Flow Stock Report
                                else if (Report == enum_ReportName.ST_FloorStockReport)
                                {
                                    Cursor = Cursors.WaitCursor;
                                    List<string> lstItemType = new List<string>();

                                    if (bItemTypeSelected)
                                        lstItemType.Add(txtItemType.Tag.ToString());

                                    //Stockreports oStockreport = new Stockreports(bStoreSelected, bItemCategorySelected, bItemTypeSelected, txtStore, txtItemName, txtItemCategory, lstItemType, dtpTo.Value.Date.AddDays(1), dtpTo.Value.Date.AddDays(1), enum_CostPriceType.CostPrice1, chkShowDeactivate.Checked);
                                    Stockreports oStockreport = new Stockreports(bStoreSelected, bItemCategorySelected, bItemTypeSelected, txtStore, txtItemName, txtItemCategory, lstItemType, dtpTo.Value.Date.AddDays(1), dtpTo.Value.Date, enum_CostPriceType.CostPrice1, chkShowDeactivate.Checked);
                                    if (!chkHideZeroQty.Checked)
                                        oStockreport.bShowAllItems = true;

                                    oStockreport.GenarateFloorStockReport(Report, ref ProgressBar, false, "Floor Stock Report", "", txtCompanyBranch.Tag.ToString());

                                    oStockreport = null;
                                    Cursor = Cursors.Default;
                                }
                                #endregion

                                #region PO Item Cost History
                                else if (Report == enum_ReportName.ST_Purchase_Order_Item_Cost_History)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glbDtsStock.Clear();

                                        if (txtPoNo.Text != "")
                                        {
                                            tbl_scsPurchaseOrder oPurchaseOrder = tbl_scsPurchaseOrder.Select(txtPoNo.Text);
                                            if (oPurchaseOrder != null)
                                            {
                                                List<tbl_scsPurchaseOrder_Detail> oDetails = tbl_scsPurchaseOrder_Detail.SelectAllByPurchaseOrder_ID(oPurchaseOrder.PurchaseOrder_ID).ToList();
                                                foreach (tbl_scsPurchaseOrder_Detail oPurchaseOrderDetail in oDetails)
                                                {
                                                    decimal dHeaderUnitPrice = oPurchaseOrder.IsWeightCalculation ? oPurchaseOrderDetail.KiloPrice : oPurchaseOrderDetail.UnitPrice;
                                                    decimal dHeaderQty = oPurchaseOrder.IsWeightCalculation ? oPurchaseOrderDetail.Weight : oPurchaseOrderDetail.Qty;

                                                    foreach (tbl_scsPurchaseOrder_Detail oPurchaseOrderDetailForItem in tbl_scsPurchaseOrder_Detail.SelectAllByItem_ID(oPurchaseOrderDetail.Item_ID))
                                                    {
                                                        tbl_scsPurchaseOrder oInnerPurchaseOrder = tbl_scsPurchaseOrder.Select(oPurchaseOrderDetailForItem.PurchaseOrder_ID); // p >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date
                                                        if (oInnerPurchaseOrder != null)
                                                        {
                                                            if (oInnerPurchaseOrder.PurchaseOrderDate >= dtpFrom.Value.Date && oInnerPurchaseOrder.PurchaseOrderDate <= dtpTo.Value.Date)
                                                            {
                                                                decimal dUnitPrice = oInnerPurchaseOrder.IsWeightCalculation ? oPurchaseOrderDetailForItem.KiloPrice : oPurchaseOrderDetailForItem.UnitPrice;
                                                                decimal dQty = oInnerPurchaseOrder.IsWeightCalculation ? oPurchaseOrderDetailForItem.Weight : oPurchaseOrderDetailForItem.Qty;

                                                                if (oPurchaseOrderDetailForItem.PurchaseOrder_ID == txtPoNo.Text)
                                                                {
                                                                    glbDtsStock.dt_scsPOItemCostHistory.Adddt_scsPOItemCostHistoryRow(oPurchaseOrder.PurchaseOrder_ID, clsGenaralName.getName_Supplier(oPurchaseOrder.Supplier_ID),
                                                                    clsGenaralName.getName_CurrencyCode(oPurchaseOrder.Currency_ID), oPurchaseOrder.ForexRate, dHeaderQty, dHeaderUnitPrice,
                                                                    oInnerPurchaseOrder.PurchaseOrder_ID, oInnerPurchaseOrder.PurchaseOrderDate, clsGenaralName.getName_Supplier(oInnerPurchaseOrder.Supplier_ID),
                                                                    clsGenaralName.getName_CurrencyCode(oInnerPurchaseOrder.Currency_ID), oInnerPurchaseOrder.ForexRate, dQty,
                                                                    dUnitPrice, oPurchaseOrderDetailForItem.Item_ID, clsGenaralName.getName_Item(oPurchaseOrderDetailForItem.Item_ID));
                                                                }
                                                            }
                                                        }
                                                    }
                                                    clsHelpMethods_Local.startProgressBar(0, oDetails.Count + 2, 1, ProgressBar);
                                                }
                                                glbDtsStock.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "Purchase  Order Report [Item Cost History]", "", sDaterange, clsSecurity.UserNameLoged, sFilter);
                                            }
                                            // frm_ReportViewer_New rpt = new Digiteq.frm_ReportViewer_New();
                                            //rpt.print("\\Reports\\SCS\\Standard\\rpt_scs_PurchaseOderItemCostHistory.rpt", glbDtsStock, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.ST_Purchase_Order_Item_Cost_History));
                                            ProgressBar.Value = 0;
                                            //print the report                                            
                                            print("\\Reports\\SCS\\Standard\\rpt_scs_PurchaseOderItemCostHistory.rpt", "Purchase  Order Report", "Purchase Order Item Cost History", "", glbDtsStock, "", clsAutocode.getReportID(Report));
                                        }
                                        else
                                            MessageBox.Show("Please Select PO No...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glbDtsStock.dt_scsPOItemCostHistory.Rows.Clear();
                                    }
                                }
                                #endregion

                                #region Re Order Leval Exceed Items
                                else if (Report == enum_ReportName.ST_ReOrder_Leval_Exceed_Items)
                                {
                                    try
                                    {
                                        bool blItemType_Selected = false, bIStoreName_Selected = false, bItemCategory_Selected = false, bItemName_Selected = false;

                                        #region Selected Filters
                                        if (txtItemType.Tag != null && txtItemType.Tag.ToString().Trim().Length > 0)
                                            blItemType_Selected = true;
                                        if (txtItemCategory.Tag != null && txtItemCategory.Tag.ToString().Trim().Length > 0)
                                            bItemCategory_Selected = true;
                                        if (txtItemName.Tag != null && txtItemName.Tag.ToString().Trim().Length > 0)
                                            bItemName_Selected = true;
                                        if (txtStore.Tag != null && txtStore.Tag.ToString().Trim().Length > 0)
                                            bIStoreName_Selected = true;
                                        #endregion

                                        Cursor = Cursors.WaitCursor;
                                        glbDtsStock.Clear();
                                        List<tbl_genItemMaster> oItems = new List<tbl_genItemMaster>();

                                        #region Filter Table
                                        if (bItemName_Selected)
                                            oItems.Add(tbl_genItemMaster.Select(txtItemName.Tag.ToString()));
                                        else if (bItemCategory_Selected)
                                            oItems = tbl_genItemMaster.SelectAllByItemCategory_ID(txtItemCategory.Tag.ToString().Trim()).Where(p => p.Item_ID != "default" && !p.IsDeleted && !p.IsServiceItem).ToList();
                                        else if (blItemType_Selected)
                                            oItems = tbl_genItemMaster.SelectAllByItemType_ID(txtItemType.Tag.ToString().Trim()).Where(p => p.Item_ID != "default" && !p.IsDeleted && !p.IsServiceItem).ToList();
                                        else
                                            oItems = tbl_genItemMaster.SelectAll().Where(p => p.Item_ID != "default" && !p.IsDeleted && !p.IsServiceItem).ToList();
                                        #endregion

                                        foreach (tbl_genItemMaster oItem in oItems)
                                        {
                                            if (oItem.ReReoverLevel != 0)
                                                foreach (tbl_genStore_Stock oStock in tbl_genStore_Stock.SelectAllByItem_ID(oItem.Item_ID))
                                                {
                                                    bool bIStoreNameOK = true, bIsQtyOK = true;
                                                    decimal dBalanceQty = oItem.IsWeightCalculation_Sales ? oStock.Weight : oStock.Qty;
                                                    if (bIStoreName_Selected)
                                                        bIStoreNameOK = txtStore.Tag.ToString().Trim() == oStock.Store_ID ? true : false;
                                                    //bIsQtyOK = oItem.ReReoverLevel != 0 && oItem.ReReoverLevel >= dBalanceQty ? true : false;
                                                    bIsQtyOK = oItem.ReReoverLevel >= dBalanceQty ? true : false;

                                                    if (bIStoreNameOK && bIsQtyOK)
                                                    {
                                                        string sBrandModel = clsGenaralName.getName_ItemSubCategory(oStock.ItemSubCategory_ID);
                                                        string sUOM = clsGenaralName.getName_Uom(oItem.Uom_ID);
                                                        glbDtsStock.dt_scsReOrderLevel_ExceedItems.Adddt_scsReOrderLevel_ExceedItemsRow(oItem.Item_ID, oItem.ItemName, sBrandModel, oItem.MinStockLevel, oItem.ReReoverLevel, oItem.ReOrderQty, dBalanceQty, sUOM, clsGenaralName.getName_Store(oStock.Store_ID));
                                                    }
                                                }
                                            clsHelpMethods_Local.startProgressBar(0, oItems.Count + 2, 1, ProgressBar);
                                            ProgressBar.Value = 0;
                                        }

                                        glbDtsStock.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDaterange, clsSecurity.UserNameLoged, sFilter);
                                        //print the report                                            
                                        print(sReportPath, "Re-Order Level Report", "[Stocks Shortage]", "Replenishment", glbDtsStock, "", clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glbDtsStock.dt_scsReOrderLevel_ExceedItems.Rows.Clear();
                                    }
                                }
                                #endregion

                                #region Re Order Level - Items Wise
                                else if (Report == enum_ReportName.ST_ReOrder_Level_ItemsWise)
                                {
                                    string sReportID = clsAutocode.getReportID(Report);
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glbDtsStock.dt_scsReOrderLevel_ExceedItems.Rows.Clear();
                                        glbDtsStock.dt_Company.Rows.Clear();
                                        List<tbl_genItemMaster> oItems = new List<tbl_genItemMaster>();

                                        #region Filter Table
                                        if (bItemSelected)
                                            oItems.Add(tbl_genItemMaster.Select(txtItemName.Tag.ToString()));
                                        else if (bItemCategorySelected)
                                            oItems = tbl_genItemMaster.SelectAllByItemCategory_ID(txtItemCategory.Tag.ToString().Trim()).Where(p => p.Item_ID != "default" && !p.IsDeleted && !p.IsServiceItem).ToList();
                                        else if (bItemTypeSelected)
                                            oItems = tbl_genItemMaster.SelectAllByItemType_ID(txtItemType.Tag.ToString().Trim()).Where(p => p.Item_ID != "default" && !p.IsDeleted && !p.IsServiceItem).ToList();
                                        else
                                            oItems = tbl_genItemMaster.SelectAll().Where(p => p.Item_ID != "default" && !p.IsDeleted && !p.IsServiceItem).ToList();
                                        #endregion

                                        foreach (tbl_genItemMaster oItem in oItems)
                                        {
                                            foreach (tbl_genStore_Stock oStock in tbl_genStore_Stock.SelectAllByItem_ID(oItem.Item_ID))
                                            {
                                                if (bStoreSelected)
                                                    if (txtStore.Tag.ToString().Trim() != oStock.Store_ID)
                                                        continue;

                                                decimal dBalanceQty = oItem.IsWeightCalculation_Sales ? oStock.Weight : oStock.Qty;

                                                //bool bIsQtyOK = true;
                                                //bIsQtyOK = oItem.ReReoverLevel != 0 && oItem.ReReoverLevel >= dBalanceQty ? true : false;

                                                //if (bIsQtyOK)
                                                //{
                                                glbDtsStock.dt_scsReOrderLevel_ExceedItems.Adddt_scsReOrderLevel_ExceedItemsRow(oItem.Item_ID, oItem.ItemName,
                                                    clsGenaralName.getName_ItemSubCategory(oStock.ItemSubCategory_ID), oItem.MinStockLevel, oItem.ReReoverLevel, oItem.ReOrderQty, dBalanceQty,
                                                    clsGenaralName.getName_Uom(oItem.Uom_ID), clsGenaralName.getName_Store(oStock.Store_ID));
                                                //}
                                            }
                                            clsHelpMethods_Local.startProgressBar(0, oItems.Count + 2, 1, ProgressBar);
                                            ProgressBar.Value = 0;
                                        }

                                        glbDtsStock.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                                        //print the report  
                                        frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
                                        ReportViewer.print(sReportPath, glbDtsStock, glb_dtsReportExport.dt_rptParameter, sReportID);
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glbDtsStock.dt_scsReOrderLevel_ExceedItems.Rows.Clear();
                                        glbDtsStock.dt_Company.Rows.Clear();
                                    }
                                }
                                #endregion

                                #region Cost Center Wise Item Tracking Report
                                else if (Report == enum_ReportName.ST_CostCenterWiseItemTracking)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glbDtsStock.dt_scsCostCenterWiseItemTracking.Rows.Clear();

                                        List<ItmTracking> items = new List<ItmTracking>();

                                        ProgressBar.Value = 0;
                                        List<tbl_scsExternalGoodReceivedNote> oEGNs = tbl_scsExternalGoodReceivedNote.SelectAll().Where(p => p.CompanyBranch_ID == txtCompanyBranch.Tag.ToString() && p.ExternalGoodReceivedNote_ID != "default" && p.CostCenter != "default").ToList();
                                        foreach (tbl_scsExternalGoodReceivedNote oEGN in oEGNs)
                                        {
                                            if (!chkShowDeactivate.Checked && oEGN.IsDeleted)
                                                continue;

                                            if (bCostCenterSelected)
                                            {
                                                if (oEGN.CostCenter != txtCostCenter.Tag.ToString().Trim())
                                                    continue;
                                            }

                                            foreach (tbl_scsExternalGoodReceivedNote_Detail EGNdetail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(oEGN.ExternalGoodReceivedNote_ID))
                                            {
                                                items.Add(new ItmTracking(EGNdetail.Item_ID, oEGN.CostCenter, "GRN", EGNdetail.Qty));
                                            }
                                            clsHelpMethods_Local.startProgressBar(0, oEGNs.Count + 2, 1, ProgressBar);

                                        }

                                        ProgressBar.Value = 0;
                                        List<tbl_scsPurchaseReturnedNote> oPRNs = tbl_scsPurchaseReturnedNote.SelectAll().Where(p => p.CompanyBranch_ID == txtCompanyBranch.Tag.ToString() && p.PurchaseReturnedNote_ID != "default" && p.CostCenter != "default").ToList();
                                        foreach (tbl_scsPurchaseReturnedNote oPRN in oPRNs)
                                        {
                                            if (!chkShowDeactivate.Checked && oPRN.IsDeleted)
                                                continue;
                                            if (bCostCenterSelected)
                                            {
                                                if (oPRN.CostCenter != txtCostCenter.Tag.ToString().Trim())
                                                    continue;
                                            }

                                            foreach (tbl_scsPurchaseReturnedNote_Detail PRNdetail in tbl_scsPurchaseReturnedNote_Detail.SelectAllByPurchaseReturnedNote_ID(oPRN.PurchaseReturnedNote_ID))
                                            {
                                                items.Add(new ItmTracking(PRNdetail.Item_ID, oPRN.CostCenter, "PRN", PRNdetail.Qty));
                                            }
                                            clsHelpMethods_Local.startProgressBar(0, oPRNs.Count + 2, 1, ProgressBar);
                                        }

                                        ProgressBar.Value = 0;
                                        foreach (var item in items.GroupBy(cm => new { cm.sItem_ID, cm.sNoteType, cm.sCostCenter }, (key, group) => new { itemId = key.sItem_ID, NoteType = key.sNoteType, CostCenter = key.sCostCenter, qty = group.Sum(p => p.dQty) }).ToList())
                                        {
                                            glbDtsStock.dt_scsCostCenterWiseItemTracking.Adddt_scsCostCenterWiseItemTrackingRow(item.itemId, clsGenaralName.getName_Item(item.itemId),
                                                (item.NoteType == "GRN") ? item.qty : 0,
                                                (item.NoteType == "PRN") ? item.qty : 0, clsGenaralName.getName_AccCostCenter1(item.CostCenter));
                                            clsHelpMethods_Local.startProgressBar(0, items.Count + 2, 1, ProgressBar);
                                        }
                                        ProgressBar.Value = 0;

                                        print("\\Reports\\SCS\\Standard\\rpt_scs_CostCenterWiseItemTracking.rpt", " Item Tracking Report", "Cost Center Wise Item Tracking", "", glbDtsStock, "", clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        glbDtsStock.dt_scsCostCenterWiseItemTracking.Rows.Clear();
                                    }
                                }
                                #endregion

                                #region Purchase Return Note Tracking
                                else if (Report == enum_ReportName.ST_PRNTracking)
                                {
                                    //bool bIsDetail = false, bIsShow = true;
                                    //if (rdbGTND.Checked)
                                    //    bIsDetail = true;                                   
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glbDtsStock.dt_scsPRNTracking.Clear();

                                        //foreach (tbl_scsPurchaseRetur oGTN in tbl_scsGoodTransferNote.SelectAll().Where(p => p.GoodTransferNote_ID != "default" && p.GoodTransferNoteDate >= dtpFrom.Value.Date && p.GoodTransferNoteDate <= dtpFrom.Value.Date))
                                        //{
                                        //    //if (rdoActual.Checked) { if (oGTN.IsDeleted)  bIsShow = false; }
                                        //    //else if (rdoDeleted.Checked) { if (!oGTN.IsDeleted) bIsShow = false; }

                                        //    //if (bIsShow)
                                        //    //{
                                        //        glbDtsStock.dt_scsPRNTracking.Adddt_scsPRNTrackingRow(oGTN.GoodTransferNote_ID, oGTN.GoodTransferNoteDate, oGTN.StoreID_From, oGTN.StoreID_To, oGTN.Job_ID, oGTN.IsDeleted ? "Deleted" : "Active", oGTN.Remark);
                                        //        if (bIsDetail)
                                        //        {
                                        //            foreach (tbl_scsGoodTransferNote_Detail detail in tbl_scsGoodTransferNote_Detail.SelectAllByGoodTransferNote_ID(oGTN.GoodTransferNote_ID))
                                        //            {
                                        //                tbl_genItemMaster oItem = tbl_genItemMaster.Select(detail.Item_Code);
                                        //                glb_dtsScsGoodTransferNote.dt_scsGoodTransferNote_Detail.Adddt_scsGoodTransferNote_DetailRow(detail.GoodTransferNote_ID, detail.Item_Code, oItem.ItemName, detail.Uom, detail.Qty, detail.Weight);
                                        //            }
                                        //        }
                                        //    //}
                                        //}
                                        //if (bIsDetail)
                                        //    print("\\Reports\\SCS\\Registry\\rpt_scs_GoodTransferNote_Detail.rpt", "Good Transfer Note Detail", glb_dtsScsGoodTransferNote);
                                        //else
                                        print("\\Reports\\SCS\\rpt_scs_PRNTracking.rpt", "Purchase Order Tracking Report", "", "", glbDtsStock, "", clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        SEACCException.Show(ex);
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                    }
                                    finally
                                    {
                                        glbDtsStock.dt_scsPRNTracking.Clear();

                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Purchase Summary Tracking Report
                                //else if (rdoPurchaseSummaryTrackingReport.Checked || rdoPurchaseSummaryTrackingReport_SupplierWise.Checked)
                                else if (Report == enum_ReportName.ST_PurchaseOrderSummaryReport || Report == enum_ReportName.ST_PurchaseOrderSummaryReport_SupplierWise)
                                {
                                    string sReportID = "";

                                    if (Report == enum_ReportName.ST_PurchaseOrderSummaryReport && rdoAll.Checked || rdoLocal.Checked)
                                        sReportID = clsAutocode.getReportID(Report);
                                    if (Report == enum_ReportName.ST_PurchaseOrderSummaryReport && rdoForeign.Checked)
                                        sReportID = clsAutocode.getReportID(enum_ReportName.ST_PurchaseOrderSummaryReport_Foreign);

                                    if (Report == enum_ReportName.ST_PurchaseOrderSummaryReport_SupplierWise && rdoForeign.Checked)
                                        sReportID = clsAutocode.getReportID(enum_ReportName.ST_PurchaseOrderSummaryReport_Foreign);
                                    if (Report == enum_ReportName.ST_PurchaseOrderSummaryReport_SupplierWise)
                                        sReportID = clsAutocode.getReportID(Report);

                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glbDtsStock.dt_scsPurchaseSummaryTracking.Clear();

                                        // string sGRNNo = "";
                                        DateTime dtPRDate = DateTime.MinValue, dtPODate = DateTime.MinValue, dtGRNDate = DateTime.MinValue;
                                        bool bHasPO = false;
                                        foreach (tbl_scsPurchaseRequisition oPR in tbl_scsPurchaseRequisition.SelectAll().Where(p => p.CompanyBranch_ID == txtCompanyBranch.Tag.ToString() && !p.IsDeleted && p.PurchaseRequisitionNote_ID != "default" && p.PurchaseRequisitionNoteDate.Date >= dtpFrom.Value.Date && p.PurchaseRequisitionNoteDate.Date <= dtpTo.Value.Date).OrderBy(p => p.PurchaseRequisitionNote_ID))
                                        {
                                            bHasPO = false;

                                            #region po
                                            foreach (tbl_scsPurchaseOrder oPO in tbl_scsPurchaseOrder.SelectAllByPurchaseRequisitionNote_ID(oPR.PurchaseRequisitionNote_ID).Where(p => p.PurchaseOrder_ID != "default" && !p.IsDeleted).OrderBy(p => p.PurchaseOrder_ID))
                                            {
                                                tbl_genSupplierMaster oSupplier = tbl_genSupplierMaster.Select(oPO.Supplier_ID);
                                                if (oSupplier != null)
                                                {
                                                    if (bSupplierSelected)
                                                    {
                                                        if (txtSupplier.Tag.ToString().Trim() != oSupplier.Supplier_ID)
                                                            break;
                                                    }

                                                    if (rdoForeign.Checked)
                                                    {
                                                        if ("2" != oSupplier.SupplierType_ID)
                                                            break;
                                                    }
                                                    else if (rdoLocal.Checked)
                                                    {
                                                        if ("1" != oSupplier.SupplierType_ID)
                                                            continue;
                                                    }
                                                }

                                                decimal dTotalAmount = 0, dAmountWithNBT = 0, dAmountSubTotal = 0, dAmountNBT = 0, dAmountVat = 0, dPOSVAT = 0;

                                                foreach (tbl_scsPurchaseOrder_Detail oPODetail in tbl_scsPurchaseOrder_Detail.SelectAllByPurchaseOrder_ID(oPO.PurchaseOrder_ID).OrderBy(p => p.Line_No))
                                                {
                                                    if (bItemSelected)
                                                    {
                                                        if (txtItemName.Tag.ToString().Trim() != oPODetail.Item_ID)
                                                            continue;
                                                    }

                                                    #region filters
                                                    if (bItemTypeSelected || bItemCategorySelected)
                                                    {
                                                        tbl_genItemMaster oItem = tbl_genItemMaster.Select(oPODetail.Item_ID);
                                                        if (oItem != null && oItem.Item_ID != "default")
                                                        {
                                                            if (bItemTypeSelected)
                                                            {
                                                                if (txtItemType.Tag.ToString().Trim() != oItem.ItemType_ID)
                                                                    continue;
                                                            }
                                                            if (bItemCategorySelected)
                                                            {
                                                                if (txtItemCategory.Tag.ToString().Trim() != oItem.ItemCategory_ID)
                                                                    continue;
                                                            }
                                                        }
                                                    }
                                                    #endregion

                                                    bHasPO = true;
                                                    //sGRNNo = "";
                                                    dtGRNDate = DateTime.MinValue;

                                                    dTotalAmount = oPODetail.TatalAmount;
                                                    if (oPO.NbtTotal != 0)
                                                        dTotalAmount = dTotalAmount * (100 + oPO.NbtPercentage) / 100;
                                                    if (oPO.VatTotal != 0)
                                                        dTotalAmount = dTotalAmount * (100 + oPO.VatPercentage) / 100;

                                                    clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dTotalAmount, (oPO.VatTotal != 0 ? oPO.VatPercentage : 0), (oPO.NbtTotal != 0 ? oPO.NbtPercentage : 0), ref dAmountWithNBT, ref dAmountSubTotal, ref dAmountNBT, ref dAmountVat);

                                                    if (oPO.IsSVAT)
                                                        dPOSVAT = (oPO.OtherTaxTotal != 0 ? oPO.OtherTaxPercentage / 100 : 0) * oPODetail.TatalAmount;

                                                    if (rdoForeign.Checked || rdoLocal.Checked) { }

                                                    int iGrnCount = 0;
                                                    decimal dDollorPrice = 0;

                                                    dDollorPrice = dAmountSubTotal / clsCommon.getCurrencyRate(oPO.Currency_ID);
                                                    foreach (tbl_scsExternalGoodReceivedNote oGRN in tbl_scsExternalGoodReceivedNote.SelectAllByPurchaseOrder_ID(oPO.PurchaseOrder_ID).Where(p => p.ExternalGoodReceivedNote_ID != "default" && !p.IsDeleted).OrderBy(p => p.ExternalGoodReceivedNote_ID))
                                                    {
                                                        foreach (tbl_scsExternalGoodReceivedNote_Detail oGrnDetail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(oGRN.ExternalGoodReceivedNote_ID).Where(p => p.Item_ID == oPODetail.Item_ID))
                                                        {
                                                            iGrnCount++;
                                                            glbDtsStock.dt_scsPurchaseSummaryTracking.Adddt_scsPurchaseSummaryTrackingRow(oPR.PurchaseRequisitionNote_ID, oPR.PurchaseRequisitionNoteDate, oPO.PurchaseOrder_ID,
                                                                oPO.PurchaseOrderDate, clsGenaralName.getName_Item(oPODetail.Item_ID), oPO.IsWeightCalculation ? oPODetail.Weight : oPODetail.Qty, clsGenaralName.getName_ItemUOM(oPODetail.Item_ID), dTotalAmount, dDollorPrice, dAmountNBT, dAmountVat, dPOSVAT, clsGenaralName.getName_Supplier(oPO.Supplier_ID), oGRN.ExternalGoodReceivedNote_ID, oGRN.ExternalGoodReceivedNoteDate, (oPO.Remark.Trim() != "" ? oPO.Remark : oPR.Remark));
                                                        }
                                                    }

                                                    if (iGrnCount == 0)
                                                    {
                                                        glbDtsStock.dt_scsPurchaseSummaryTracking.Adddt_scsPurchaseSummaryTrackingRow(oPR.PurchaseRequisitionNote_ID, oPR.PurchaseRequisitionNoteDate, oPO.PurchaseOrder_ID,
                                                            oPO.PurchaseOrderDate, clsGenaralName.getName_Item(oPODetail.Item_ID), oPO.IsWeightCalculation ? oPODetail.Weight : oPODetail.Qty, clsGenaralName.getName_ItemUOM(oPODetail.Item_ID), dTotalAmount, dDollorPrice, dAmountNBT, dAmountVat, dPOSVAT, clsGenaralName.getName_Supplier(oPO.Supplier_ID), "", DateTime.MinValue, (oPO.Remark.Trim() != "" ? oPO.Remark : oPR.Remark));
                                                    }
                                                }
                                            }
                                            if (!bHasPO)
                                            {
                                                if (chkShowAllItems.Checked)
                                                    glbDtsStock.dt_scsPurchaseSummaryTracking.Adddt_scsPurchaseSummaryTrackingRow(oPR.PurchaseRequisitionNote_ID, oPR.PurchaseRequisitionNoteDate, "", DateTime.MinValue, "", 0, "", 0, 0, 0, 0, 0, "", "", DateTime.MinValue, "");
                                            }
                                            #endregion
                                        }

                                        //if (rdoPurchaseSummaryTrackingReport_SupplierWise.Checked)
                                        //    print(sReportPath, sReportTitle_Main, sReportTitle_Sub, "", glbDtsStock.dt_scsPurchaseSummaryTracking, "");
                                        //else if (rdoAll.Checked || rdoLocal.Checked)
                                        //    print(sReportPath, sReportTitle_Main, sReportTitle_Sub, "", glbDtsStock.dt_scsPurchaseSummaryTracking, "");
                                        //else if (rdoForeign.Checked)
                                        print(sReportPath, sReportTitle_Main, sReportTitle_Sub, "", glbDtsStock, "", sReportID);

                                        //if (rdoPurchaseSummaryTrackingReport_SupplierWise.Checked)
                                        //    print("\\Reports\\SCS\\rpt_scs_PurchaseSummaryTracking_SupplierWise.rpt", "Purchase Summary", "[Tracking Report]", "", glbDtsStock.dt_scsPurchaseSummaryTracking, "");
                                        //else if (rdoAll.Checked || rdoLocal.Checked)
                                        //    print("\\Reports\\SCS\\rpt_scs_PurchaseSummaryTracking.rpt", "Purchase Summary", "[Tracking Report]", "", glbDtsStock.dt_scsPurchaseSummaryTracking, "");
                                        //else if (rdoForeign.Checked)
                                        //    print("\\Reports\\SCS\\rpt_scs_PurchaseSummaryTrackingForign.rpt", "Purchase Summary", "[Tracking Report]", "", glbDtsStock.dt_scsPurchaseSummaryTracking, "");

                                    }
                                    catch (Exception ex)
                                    {
                                        SEACCException.Show(ex);
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                    }
                                    finally
                                    {
                                        glbDtsStock.dt_scsPurchaseSummaryTracking.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Monthly Usage Tracking Report
                                else if (Report == enum_ReportName.ST_MonthlyUsageTrackingReport)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glbDtsStock.dt_psmMonthlyMaterialUsage.Clear();

                                        // string ItemID = "", ItemName = "", sTypeName = "", sCategoryName = "", JobID = "", JobtypeID = "", JobTypeName = "";
                                        //  decimal Issueweight = 0, ReceivedWeight = 0, dNetUsage = 0;
                                        string sMainStoreID = "";
                                        foreach (tbl_genStoreMaster oStore in tbl_genStoreMaster.SelectAll())
                                        {
                                            if (oStore.IsMainStore)
                                                sMainStoreID = oStore.Store_ID;
                                        }

                                        if (sMainStoreID.Length > 0)
                                        {
                                            string sCategoryID = "";
                                            sFilterOld = txtJobCategory.Text;

                                            if (txtItemCategory.Tag != null && txtItemCategory.Tag.ToString().Length > 0 && txtItemCategory.Tag.ToString() != "default")
                                                sCategoryID = txtItemCategory.Tag.ToString();

                                            List<srh_SCS_MonthlyMaterialUsage_Issues> oIssues = new List<srh_SCS_MonthlyMaterialUsage_Issues>();
                                            List<srh_SCS_MonthlyMaterialUsage_Receive> oReceives = new List<srh_SCS_MonthlyMaterialUsage_Receive>();
                                            if (txtJobCategory.Tag != null && txtJobCategory.Tag.ToString().Length > 0 && txtJobCategory.Tag.ToString() != "default")
                                            {
                                                oIssues = srh_SCS_MonthlyMaterialUsage_Issues.SelectAllByProductionJobType_ID(txtJobCategory.Tag.ToString(), dtpFrom.Value.Date, dtpTo.Value.Date);
                                                oReceives = srh_SCS_MonthlyMaterialUsage_Receive.SelectAllByProductionJobType_ID(txtJobCategory.Tag.ToString(), dtpFrom.Value.Date, dtpTo.Value.Date);
                                            }
                                            else if (sCategoryID.Length > 0)
                                            {
                                                oIssues = srh_SCS_MonthlyMaterialUsage_Issues.SelectAllByItemCategory_ID(txtItemCategory.Tag.ToString(), dtpFrom.Value.Date, dtpTo.Value.Date);
                                                oReceives = srh_SCS_MonthlyMaterialUsage_Receive.SelectAllByItemCategory_ID(txtItemCategory.Tag.ToString(), dtpFrom.Value.Date, dtpTo.Value.Date);
                                            }
                                            else
                                            {
                                                oIssues = srh_SCS_MonthlyMaterialUsage_Issues.SelectAll(dtpFrom.Value.Date, dtpTo.Value.Date);
                                                oReceives = srh_SCS_MonthlyMaterialUsage_Receive.SelectAll(dtpFrom.Value.Date, dtpTo.Value.Date);
                                            }

                                            foreach (srh_SCS_MonthlyMaterialUsage_Issues oIssue in oIssues.Where(p => p.ProductionJob_ID != "GE00000001" && p.ProductionJobType_ID != null && p.ProductionJobType_ID != "default"))
                                            {
                                                if (sCategoryID.Trim().Length > 0 && sCategoryID != "default")
                                                {
                                                    if (oIssue.ItemCategory_ID != sCategoryID)
                                                        continue;
                                                }
                                                glbDtsStock.dt_psmMonthlyMaterialUsage.Adddt_psmMonthlyMaterialUsageRow(oIssue.Item_ID, oIssue.ItemName, oIssue.TypeName, oIssue.CategoryName, oIssue.ProductionJob_ID, oIssue.ProductionJobType_ID, oIssue.ProductionJobTypeName, oIssue.Weight, 0, oIssue.Weight);
                                            }
                                            foreach (srh_SCS_MonthlyMaterialUsage_Receive oReceive in oReceives.Where(p => p.ProductionJob_ID != "GE00000001" && p.ProductionJobType_ID != null && p.ProductionJobType_ID != "default"))
                                            {
                                                if (sCategoryID.Trim().Length > 0 && sCategoryID != "default")
                                                {
                                                    if (oReceive.ItemCategory_ID != sCategoryID)
                                                        continue;
                                                }
                                                glbDtsStock.dt_psmMonthlyMaterialUsage.Adddt_psmMonthlyMaterialUsageRow(oReceive.Item_ID, oReceive.ItemName, oReceive.TypeName, oReceive.CategoryName, oReceive.ProductionJob_ID, oReceive.ProductionJobType_ID, oReceive.ProductionJobTypeName, 0, oReceive.Weight, (-oReceive.Weight));
                                            }


                                            print("\\Reports\\SCS\\Standard\\rpt_scs_StockMonthlyMaterialUsage.rpt", "Monthly Material Usage", "[Tracking Report]", "", glbDtsStock, "", clsAutocode.getReportID(Report));
                                        }
                                        else
                                            MessageBox.Show("Invalid main store! Please contact admin or Digiteq Help Desk team. ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    }
                                    catch (Exception ex)
                                    {
                                        SEACCException.Show(ex);
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                    }
                                    finally
                                    {
                                        glbDtsStock.dt_psmMonthlyMaterialUsage.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Loan In / Out / Settlement Reports
                                else if (Report == enum_ReportName.ST_LoanOut || Report == enum_ReportName.ST_LoanIN || Report == enum_ReportName.ST_Pending_LoanOut || Report == enum_ReportName.ST_Pending_LoanIn)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dts_scsLoanInLoanOut.Clear();
                                        string sTitle = "";
                                        sDaterange = clsFormatter.FormatDate_Short(dtpFrom.Value) + " - " + clsFormatter.FormatDate_Short(dtpFrom.Value);

                                        #region Loan IN Report
                                        if (Report == enum_ReportName.ST_LoanIN || Report == enum_ReportName.ST_Pending_LoanIn)
                                        {
                                            #region Report-Filter Option
                                            //if (txtSupplier.Tag != null && txtSupplier.Tag.ToString().Length > 0)
                                            //{
                                            //    sFilter += " Supplier Name:" + txtSupplier.Tag.ToString();
                                            //}
                                            //if (txtStore.Tag != null && txtStore.Tag.ToString().Length > 0)
                                            //{
                                            //    sFilter += " ||Store Name:" + txtStore.Tag.ToString();
                                            //}

                                            sTitle = Report == enum_ReportName.ST_Pending_LoanIn ? "Pending Loan In " : "Loan In Based Settlement";
                                            #endregion

                                            #region Loan IN Settlement

                                            foreach (tbl_scsLoanIn oLoanIN in tbl_scsLoanIn.SelectAll().Where(p => p.CompanyBranch_ID == txtCompanyBranch.Tag.ToString() && p.LoanInDate.Date >= dtpFrom.Value.Date && p.LoanInDate.Date <= dtpTo.Value.Date))
                                            {
                                                #region Filter
                                                if (Report == enum_ReportName.ST_Pending_LoanIn)
                                                {
                                                    if (!oLoanIN.IsFirstDocument)
                                                        continue;
                                                    if (oLoanIN.IsSeattled)
                                                        continue;
                                                }
                                                else if (Report == enum_ReportName.ST_LoanIN)
                                                {
                                                    if (!oLoanIN.IsSeattled)
                                                        continue;
                                                }

                                                if (txtSupplier.Tag != null && txtSupplier.Tag.ToString().Length > 0)
                                                {
                                                    if (txtSupplier.Tag.ToString() != oLoanIN.Supplier_ID)
                                                    {
                                                        // sFilter = " Supplier Name:" + clsGenaralName.getName_Supplier(txtSupplier.Tag.ToString());
                                                        continue;
                                                    }
                                                }
                                                if (txtStore.Tag != null && txtStore.Tag.ToString().Length > 0)
                                                {
                                                    if (txtStore.Tag.ToString() != oLoanIN.Store_ID)
                                                    {
                                                        // sFilter = " Store Name:" + clsGenaralName.getName_Store(txtStore.Tag.ToString());
                                                        continue;
                                                    }
                                                }
                                                if (!chkShowAllItems.Checked)
                                                {
                                                    if (!oLoanIN.IsFirstDocument)
                                                        continue;
                                                }
                                                #endregion

                                                #region Add Loan In
                                                string sCustomerName_In = "";
                                                if (oLoanIN.IsForCustomer)
                                                    sCustomerName_In = clsGenaralName.getName_Customer(oLoanIN.Customer_ID);
                                                else if (oLoanIN.IsForSupplier)
                                                    sCustomerName_In = clsGenaralName.getName_Supplier(oLoanIN.Supplier_ID);
                                                else if (oLoanIN.IsForOther)
                                                    sCustomerName_In = oLoanIN.ReceiverName;
                                                foreach (tbl_scsLoanIn_Detail oItem in tbl_scsLoanIn_Detail.SelectAllByLoanIn_ID(oLoanIN.LoanIn_ID).Where(p => p.LoanIn_ID != "default"))
                                                {
                                                    glb_dts_scsLoanInLoanOut.dt_LoanDetail.Adddt_LoanDetailRow(oLoanIN.LoanIn_ID, oLoanIN.LoanInDate, oItem.Item_ID, clsGenaralName.getName_Item(oItem.Item_ID), oItem.Qty, oItem.Weight, clsGenaralName.getName_ItemUOM(oItem.Item_ID), oItem.TotalAmount, oLoanIN.IsWeightCalculation, true, oLoanIN.LoanIn_ID, sCustomerName_In, oLoanIN.IsFirstDocument);
                                                }
                                                #endregion

                                                #region Add Loan Out
                                                foreach (tbl_scsLoanSettle oSettle in tbl_scsLoanSettle.SelectAllByLoanIn_ID(oLoanIN.LoanIn_ID).OrderBy(o => o.LoanIn_ID))//Where(p => p.IsLoanInBase).
                                                {
                                                    tbl_scsLoanOut oLoanOut = tbl_scsLoanOut.Select(oSettle.LoanOut_ID);
                                                    if (oLoanOut != null && oLoanOut.LoanOut_ID != "default" && !oLoanOut.IsDeleted)
                                                    {
                                                        #region Set Customer Name
                                                        string sCustomerName_Out = "";
                                                        if (oLoanIN.IsForCustomer)
                                                            sCustomerName_Out = clsGenaralName.getName_Customer(oLoanOut.Customer_ID);
                                                        else if (oLoanIN.IsForSupplier)
                                                            sCustomerName_Out = clsGenaralName.getName_Supplier(oLoanOut.Supplier_ID);
                                                        else if (oLoanIN.IsForOther)
                                                            sCustomerName_Out = oLoanOut.ReceiverName;
                                                        #endregion

                                                        foreach (tbl_scsLoanOut_Detail oItem in tbl_scsLoanOut_Detail.SelectAllByLoanOut_ID(oLoanOut.LoanOut_ID).Where(p => p.LoanOut_ID != "default"))
                                                        {
                                                            glb_dts_scsLoanInLoanOut.dt_LoanDetail.Adddt_LoanDetailRow(oLoanOut.LoanOut_ID, oLoanOut.LoanOutDate, oItem.Item_ID, clsGenaralName.getName_Item(oItem.Item_ID), oItem.Qty, oItem.Weight, clsGenaralName.getName_ItemUOM(oItem.Item_ID), oItem.TotalAmount, oLoanOut.IsWeightCalculation, false, oLoanIN.LoanIn_ID, sCustomerName_Out, oLoanOut.IsFirstDocument);
                                                        }
                                                    }
                                                }

                                                //if(bIsHasSettlement)
                                                //    glb_dts_scsLoanInLoanOut.dt_LoanDetail.Select(
                                                //drr.Rows.Remove(dr); 

                                                #endregion
                                            }
                                            #endregion
                                        }
                                        #endregion

                                        #region Loan Out Report
                                        else
                                        {
                                            #region Report-Filter Option
                                            //if (txtSupplier.Tag != null && txtSupplier.Tag.ToString().Length > 0)
                                            //{
                                            //    sFilter += " Supplier Name:" + txtSupplier.Tag.ToString();
                                            //}
                                            //if (txtStore.Tag != null && txtStore.Tag.ToString().Length > 0)
                                            //{
                                            //    sFilter += " ||Store Name:" + txtStore.Tag.ToString();
                                            //}

                                            sTitle = Report == enum_ReportName.ST_Pending_LoanOut ? "Pending Loan Out " : "Loan Out Based Settlement";
                                            #endregion

                                            #region Loan Out Settlement

                                            foreach (tbl_scsLoanOut oLoan_Out in tbl_scsLoanOut.SelectAll().Where(p => p.CompanyBranch_ID == txtCompanyBranch.Tag.ToString() && p.LoanOutDate.Date >= dtpFrom.Value.Date && p.LoanOutDate.Date <= dtpTo.Value.Date))
                                            {
                                                #region Filter
                                                if (Report == enum_ReportName.ST_Pending_LoanOut)
                                                {
                                                    if (!oLoan_Out.IsFirstDocument)
                                                        continue;
                                                    if (oLoan_Out.IsSeattled)
                                                        continue;
                                                }
                                                if (Report == enum_ReportName.ST_LoanOut)
                                                {
                                                    if (!oLoan_Out.IsSeattled)
                                                        continue;
                                                }

                                                if (txtSupplier.Tag != null && txtSupplier.Tag.ToString().Length > 0)
                                                {
                                                    if (txtSupplier.Tag.ToString() != oLoan_Out.Supplier_ID)
                                                    {
                                                        // sFilter = " Supplier Name:" + clsGenaralName.getName_Supplier(txtSupplier.Tag.ToString());
                                                        continue;
                                                    }
                                                }
                                                if (txtStore.Tag != null && txtStore.Tag.ToString().Length > 0)
                                                {
                                                    if (txtStore.Tag.ToString() != oLoan_Out.Store_ID)
                                                    {
                                                        // sFilter = " Store Name:" + clsGenaralName.getName_Store(txtStore.Tag.ToString());
                                                        continue;
                                                    }
                                                }
                                                if (!chkShowAllItems.Checked)
                                                {
                                                    if (!oLoan_Out.IsFirstDocument)
                                                        continue;
                                                }
                                                #endregion

                                                #region Add Out In
                                                string sCustomerName_In = "";
                                                if (oLoan_Out.IsForCustomer)
                                                    sCustomerName_In = clsGenaralName.getName_Customer(oLoan_Out.Customer_ID);
                                                else if (oLoan_Out.IsForSupplier)
                                                    sCustomerName_In = clsGenaralName.getName_Supplier(oLoan_Out.Supplier_ID);
                                                else if (oLoan_Out.IsForOther)
                                                    sCustomerName_In = oLoan_Out.ReceiverName;
                                                foreach (tbl_scsLoanOut_Detail oItem in tbl_scsLoanOut_Detail.SelectAllByLoanOut_ID(oLoan_Out.LoanOut_ID).Where(p => p.LoanOut_ID != "default"))
                                                {
                                                    glb_dts_scsLoanInLoanOut.dt_LoanDetail.Adddt_LoanDetailRow(oLoan_Out.LoanOut_ID, oLoan_Out.LoanOutDate, oItem.Item_ID, clsGenaralName.getName_Item(oItem.Item_ID), oItem.Qty, oItem.Weight, clsGenaralName.getName_ItemUOM(oItem.Item_ID), oItem.TotalAmount, oLoan_Out.IsWeightCalculation, false, oLoan_Out.LoanOut_ID, sCustomerName_In, oLoan_Out.IsFirstDocument);
                                                }
                                                #endregion

                                                #region Add Loan IN
                                                foreach (tbl_scsLoanSettle oSettle in tbl_scsLoanSettle.SelectAllByLoanOut_ID(oLoan_Out.LoanOut_ID).OrderBy(o => o.LoanOut_ID))//.Where(p => !p.IsLoanInBase)
                                                {
                                                    tbl_scsLoanIn oLoan_In = tbl_scsLoanIn.Select(oSettle.LoanIn_ID);
                                                    if (oLoan_In != null && oLoan_In.LoanIn_ID != "default" && !oLoan_In.IsDeleted)
                                                    {
                                                        #region Set Customer Name
                                                        string sCustomerName_Out = "";
                                                        if (oLoan_Out.IsForCustomer)
                                                            sCustomerName_Out = clsGenaralName.getName_Customer(oLoan_In.Customer_ID);
                                                        else if (oLoan_Out.IsForSupplier)
                                                            sCustomerName_Out = clsGenaralName.getName_Supplier(oLoan_In.Supplier_ID);
                                                        else if (oLoan_Out.IsForOther)
                                                            sCustomerName_Out = oLoan_In.ReceiverName;
                                                        #endregion

                                                        foreach (tbl_scsLoanIn_Detail oItem in tbl_scsLoanIn_Detail.SelectAllByLoanIn_ID(oLoan_In.LoanIn_ID).Where(p => p.LoanIn_ID != "default"))
                                                        {
                                                            glb_dts_scsLoanInLoanOut.dt_LoanDetail.Adddt_LoanDetailRow(oLoan_In.LoanIn_ID, oLoan_In.LoanInDate, oItem.Item_ID, clsGenaralName.getName_Item(oItem.Item_ID), oItem.Qty, oItem.Weight, clsGenaralName.getName_ItemUOM(oItem.Item_ID), oItem.TotalAmount, oLoan_In.IsWeightCalculation, true, oLoan_Out.LoanOut_ID, sCustomerName_Out, oLoan_In.IsFirstDocument);
                                                        }
                                                    }
                                                }
                                                #endregion
                                            }
                                            #endregion
                                        }
                                        #endregion

                                        glb_dts_scsLoanInLoanOut.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sTitle, sTitle, sDaterange, clsSecurity.UserNameLoged, sFilterOld);

                                        //print(sReportPath, sTitle, "", "", glb_dts_scsLoanInLoanOut, sFilterOld);
                                        frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
                                        ReportViewer.print(sReportPath, glb_dts_scsLoanInLoanOut, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    { clsValidate.WriteErrorLog("", iFormID, ex); SEACCException.Show(ex); }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glb_dts_scsLoanInLoanOut.Clear();
                                    }
                                }
                                #endregion

                                #region Fast Moving Items / Slow Moving Items
                                else if (Report == enum_ReportName.ST_Fast_Moving_Items || Report == enum_ReportName.ST_Slow_Moving_Items)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glbDtsStock.Clear();

                                        #region Filters - Item
                                        List<tbl_genItemMaster> oItems = new List<tbl_genItemMaster>();

                                        if (bItemSelected)
                                            oItems.Add(tbl_genItemMaster.Select(txtItemName.Tag.ToString()));
                                        else
                                            oItems = tbl_genItemMaster.SelectAll();
                                        #endregion
                                        int iRouteId = 0;
                                        if (bRouteSelected)
                                            iRouteId = int.Parse(txtRoute.Tag.ToString());

                                        string sQuary = "exec [sp_FastnSlowMoving_ItemsReport] '" + dtpFrom.Value.Date.ToString("yyyy-MM-dd") + "','" + dtpTo.Value.Date.ToString("yyyy-MM-dd") + "','" + clsSecurity.CompanyID + "','" + txtCompanyBranch.Tag.ToString() + "', " + iRouteId;
                                        if (bStoreSelected)
                                            sQuary = "exec [sp_FastnSlowMoving_StoreItemsReport] '" + dtpFrom.Value.Date.ToString("yyyy-MM-dd") + "','" + dtpTo.Value.Date.ToString("yyyy-MM-dd") + "','" + clsSecurity.CompanyID + "','" + txtCompanyBranch.Tag.ToString() + "','" + txtStore.Tag.ToString() + "', " + iRouteId;

                                        DataTable table = DBHandling.ExecQuery(sQuary).Tables[0];

                                        foreach (tbl_genItemMaster oItem in oItems)
                                        {
                                            #region Filters
                                            #region Item Type
                                            if (bItemTypeSelected)
                                            {
                                                if (txtItemType.Tag.ToString() != oItem.ItemType_ID)
                                                    continue;
                                            }
                                            #endregion

                                            #region Item Catagory
                                            if (bItemCategorySelected)
                                            {
                                                if (txtItemCategory.Tag.ToString() != oItem.ItemCategory_ID)
                                                    continue;
                                            }
                                            #endregion

                                            #region Item Class
                                            if (bItemClassSelected)
                                            {
                                                if (txtItemClass.Tag.ToString() != oItem.ItemClass_ID)
                                                    continue;
                                            }
                                            #endregion
                                            #endregion

                                            if (bStoreSelected)
                                            {
                                                decimal dQtyInHand = 0;
                                                //  string sStore_ID = "";
                                                foreach (tbl_genStore_Stock oStock in tbl_genStore_Stock.SelectAllByItem_ID(oItem.Item_ID).Where(p => p.Store_ID == txtStore.Tag.ToString() && p.Store_ID != "default"))
                                                {
                                                    dQtyInHand += oStock.Qty;
                                                    // sStore_ID = oStock.Store_ID;
                                                }
                                                decimal dDoQty = 0, dSrnQty = 0;
                                                DataRow[] rows = table.Select("item_ID = '" + oItem.Item_ID + "' ");//and store_ID = '" + txtStore.Tag.ToString() + "'");
                                                if (rows.Length > 0)
                                                {
                                                    dDoQty = decimal.Parse(rows[0]["DOQty"].ToString());
                                                    dSrnQty = decimal.Parse(rows[0]["SRNQty"].ToString());
                                                    glbDtsStock.dt_FastMovingItems.Adddt_FastMovingItemsRow("", "", oItem.Item_ID, oItem.ItemName, clsGenaralName.getName_Uom(oItem.Uom_ID), dQtyInHand, dDoQty, dSrnQty);
                                                }

                                                //fill uom code
                                                //glbDtsStock.dt_FastMovingItems.Adddt_FastMovingItemsRow("", "", oItem.Item_ID, oItem.ItemName, clsGenaralName.getName_Uom(oItem.Uom_ID), dQtyInHand, dDoQty, dSrnQty);
                                            }
                                            else
                                            {
                                                decimal dQtyInHand = 0;
                                                foreach (tbl_genStore_Stock oStock in tbl_genStore_Stock.SelectAllByItem_ID(oItem.Item_ID).Where(p => p.Store_ID != "default"))
                                                {
                                                    dQtyInHand += oStock.Qty;
                                                }
                                                decimal dDoQty = 0, dSrnQty = 0;
                                                DataRow[] rows = table.Select("item_ID = '" + oItem.Item_ID + "'");
                                                if (rows.Length > 0)
                                                {
                                                    dDoQty = decimal.Parse(rows[0]["DOQty"].ToString());
                                                    dSrnQty = decimal.Parse(rows[0]["SRNQty"].ToString());

                                                    glbDtsStock.dt_FastMovingItems.Adddt_FastMovingItemsRow("", "", oItem.Item_ID, oItem.ItemName, clsGenaralName.getName_Uom(oItem.Uom_ID), dQtyInHand, dDoQty, dSrnQty);
                                                }

                                                //fill uom code
                                                //glbDtsStock.dt_FastMovingItems.Adddt_FastMovingItemsRow("", "", oItem.Item_ID, oItem.ItemName, clsGenaralName.getName_Uom(oItem.Uom_ID), dQtyInHand, dDoQty, dSrnQty);

                                            }
                                        }

                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("SuppresWithoutSales", chkHideZeroQty.Checked ? "1" : "0", true);

                                        //Fill Company Data set
                                        //Print
                                        glbDtsStock.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDaterange, clsSecurity.UserNameLoged, sFilter);
                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glbDtsStock, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                        #region Old Methods
                                        //sDaterange = clsFormatter.FormatDate_Short(dtpFrom.Value.Date) + " - " + clsFormatter.FormatDate_Short(dtpTo.Value.Date);

                                        //List<tbl_genStoreMaster> oStocks = tbl_genStoreMaster.SelectAll().Where(p => !p.IsDeleted && p.Store_ID != "default").ToList();

                                        #region Filters
                                        //if (bStoreSelected)
                                        //    oStocks = oStocks.Where(p => p.Store_ID == txtStore.Tag.ToString()).ToList();

                                        #endregion

                                        #region Old
                                        //foreach (tbl_genStoreMaster oStock in oStocks)
                                        //{
                                        //    foreach (tbl_genStore_Stock oStoreStocks in tbl_genStore_Stock.SelectAllByStore_ID(oStock.Store_ID).Where(p => p.Item_ID != "default"))
                                        //    {
                                        //        tbl_genItemMaster oItem = tbl_genItemMaster.Select(oStoreStocks.Item_ID);
                                        //        if (oItem != null && oItem.Item_ID != "default")
                                        //        {
                                        //            #region Filters
                                        //            //if (!chkShowDeactivate.Checked && oItem.IsDeleted)
                                        //            //    continue;

                                        //            //if (bItemTypeSelected)
                                        //            //{
                                        //            //    if (oItem.ItemType_ID != txtItemType.Tag.ToString())
                                        //            //        continue;
                                        //            //}
                                        //            //if (bItemCategorySelected)
                                        //            //{
                                        //            //    if (oItem.ItemCategory_ID != txtItemCategory.Tag.ToString())
                                        //            //        continue;
                                        //            //}
                                        //            #endregion

                                        //            decimal dQty = 0, dReturnQty = 0;
                                        //            foreach (tbl_sasDeliveryOrder oDo in tbl_sasDeliveryOrder.SelectAll().Where(p => p.DeliveryOrderDate.Date >= dtpFrom.Value.Date && p.DeliveryOrderDate.Date <= dtpTo.Value.Date && !p.IsDeleted))
                                        //            {
                                        //                foreach (tbl_sasDeliveryOrder_Detail oDoDetail in tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(oDo.DeliveryOrder_ID).Where(p => p.Item_ID == oItem.Item_ID))
                                        //                {
                                        //                    dQty += oDoDetail.Qty;
                                        //                }
                                        //            }

                                        //            foreach (tbl_sasSalesReturnedNote oSrn in tbl_sasSalesReturnedNote.SelectAll().Where(p => p.SalesReturnedNoteDate.Date >= dtpFrom.Value.Date && p.SalesReturnedNoteDate.Date <= dtpTo.Value.Date && !p.IsDeleted))
                                        //            {
                                        //                foreach (tbl_sasSalesReturnedNote_Detail oSrnDetail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSrn.SalesReturnedNote_ID).Where(p => p.Item_ID == oItem.Item_ID))
                                        //                {
                                        //                    dReturnQty += oSrnDetail.Qty;
                                        //                }
                                        //            }

                                        //            glbDtsStock.dt_FastMovingItems.Adddt_FastMovingItemsRow(oStock.Store_ID, oStock.StoreName, oItem.Item_ID, oItem.ItemName, clsGenaralName.getName_ItemUOM(oItem.Uom_ID), oStoreStocks.Qty, dQty, dReturnQty);
                                        //        }
                                        //    }
                                        //} 
                                        #endregion

                                        //glbDtsStock.dt_FastMovingItems.Rows.Clear();
                                        //string sStore_ID = bStoreSelected ? txtStore.Tag.ToString() : "%";
                                        //string sItem_ID = bItemSelected ? txtItemName.Tag.ToString() : "%";
                                        //string sItem_Category = bItemCategorySelected ? txtItemCategory.Tag.ToString() : "%";
                                        //string sItem_Type = bItemTypeSelected ? txtItemType.Tag.ToString() : "%";

                                        //glbDtsStock.dt_FastMovingItems.Merge(DBHandling.ExecQuery("exec [sp_FastnSlowMoving_Items] '" + dtpFrom.Value.Date.ToString("MM-dd-yyyy") + "','" + dtpTo.Value.Date.ToString("MM-dd-yyyy") + "','" + sStore_ID +"','" + sItem_ID +"'").Tables[0]);

                                        //glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("SuppresWithoutSales", chkSales.Checked ? "1" : "0", true);

                                        //glbDtsStock.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportName, "", sDaterange, clsSecurity.UserNameLoged, sFilter);
                                        //frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        //rpt.print(sReportPath, glbDtsStock, glb_dtsReportExport.dt_rptParameter);
                                        #endregion
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glbDtsStock.Clear();
                                    }
                                }
                                #endregion

                                #region Item Price List
                                else if (Report == enum_ReportName.ST_Item_Price_List)
                                {
                                    try
                                    {
                                        glbDtsItemList.Clear();
                                        glb_dtsReportExport.Clear();
                                        Cursor = Cursors.WaitCursor;

                                        List<tbl_genItemMaster> oItems;

                                        #region Filter
                                        if (!bItemSelected)
                                            oItems = tbl_genItemMaster.SelectAll().ToList();
                                        else
                                        {
                                            oItems = new List<tbl_genItemMaster>();
                                            oItems.Add(tbl_genItemMaster.Select(txtItemName.Tag.ToString()));
                                        }

                                        if (bItemTypeSelected)
                                            oItems = oItems.Where(p => p.ItemType_ID == txtItemType.Tag.ToString()).ToList();

                                        if (bItemCategorySelected)
                                            oItems = oItems.Where(p => p.ItemCategory_ID == txtItemCategory.Tag.ToString()).ToList();

                                        if (bItemClassSelected)
                                            oItems = oItems.Where(p => p.ItemClass_ID == txtItemClass.Tag.ToString()).ToList();

                                        #endregion

                                        foreach (tbl_genItemMaster oItem in oItems.Where(p => p.Item_ID != "default"))
                                        {
                                            tbl_genItemMaster_Pricing detail = tbl_genItemMaster_Pricing.Select(oItem.Item_ID); //.SelectAll().Where(p => p.Item_ID != "default" && p.Item_ID == oItem.Item_ID))
                                            if (detail != null)
                                            {
                                                glbDtsItemList.Item_List_Details.AddItem_List_DetailsRow(detail.Item_ID, clsGenaralName.getName_Item(detail.Item_ID), oItem.ItemClass_ID, clsGenaralName.getName_ItemClass(oItem.ItemClass_ID), oItem.ItemType_ID, clsGenaralName.getName_ItemType(oItem.ItemType_ID), oItem.ItemCategory_ID, clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID), detail.WeightedAverageCostPrice, detail.HighestPurchaseCostPrice, detail.LowestPurchaseCostPrice, detail.SellingPrice1, detail.SellingPrice2, detail.SellingPrice3, detail.SellingPrice4, detail.SellingPrice5, detail.CostPrice1);
                                            }
                                        }

                                        glbDtsItemList.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("WholeSalePrice", "WholeSale Price", true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("LPCOstPrice", "Lowest Cost", true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("WACostPrice", "Weighted Avg Cost", true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("HPCostPrice", "Highest Cost", true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("SellingPrice1", clsConfig.sItemPrice1_Name, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("SellingPrice2", clsConfig.sItemPrice2_Name, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("SellingPrice3", clsConfig.sItemPrice3_Name, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("SellingPrice4", clsConfig.sItemPrice4_Name, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CostPrice", "Cost Price", true);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glbDtsItemList, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.ST_Item_Price_List));

                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        glbDtsItemList.Clear();
                                        glb_dtsReportExport.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region IGIN vs IGRN Report
                                else if (Report == enum_ReportName.ST_iGIN_vs_iGRN_Report)
                                {
                                    string sReportID = clsAutocode.getReportID(Report);
                                    try
                                    {
                                        glbDtsStock.Clear();
                                        glb_dtsReportExport.Clear();
                                        Cursor = Cursors.WaitCursor;

                                        List<tbl_scsStoreGoodIssueNote> oiGINList = tbl_scsStoreGoodIssueNote.SelectAll().Where(p => p.CompanyBranch_ID == txtCompanyBranch.Tag.ToString() && p.StoreGoodIssueNote_ID != "default" && p.StoreGoodIssueNoteDate.Date >= dtpFrom.Value.Date && p.StoreGoodIssueNoteDate.Date <= dtpTo.Value.Date).ToList();

                                        //if (bCompanyBranchSelected)
                                        //    oiGINList = tbl_scsStoreGoodIssueNote.SelectAll().Where(p => p.StoreGoodIssueNote_ID != "default" && p.CompanyBranch_ID == txtCompanyBranch.Tag.ToString() && p.StoreGoodIssueNoteDate.Date >= dtpFrom.Value.Date && p.StoreGoodIssueNoteDate.Date <= dtpTo.Value.Date).ToList();
                                        //else
                                        //oiGINList = tbl_scsStoreGoodIssueNote.SelectAll().Where(p => p.StoreGoodIssueNote_ID != "default" && p.StoreGoodIssueNoteDate.Date >= dtpFrom.Value.Date && p.StoreGoodIssueNoteDate.Date <= dtpTo.Value.Date).ToList();

                                        foreach (tbl_scsStoreGoodIssueNote oIGIN in oiGINList)
                                        {
                                            if (bStoreSelected)
                                                if (oIGIN.FromStore_ID != txtStore.Tag.ToString())
                                                    continue;

                                            foreach (tbl_scsStoreGoodReceiveNote oIGRN in tbl_scsStoreGoodReceiveNote.SelectAll().Where(p => p.StoreGoodIssueNote_ID == oIGIN.StoreGoodIssueNote_ID && p.StoreGoodReceiveNote_ID != "default"))
                                            {
                                                foreach (tbl_scsStoreGoodIssueNote_Detail oIGIN_D in tbl_scsStoreGoodIssueNote_Detail.SelectAllByStoreGoodIssueNote_ID(oIGIN.StoreGoodIssueNote_ID))
                                                {
                                                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oIGIN_D.Item_ID);
                                                    if (bItemSelected)
                                                        if (oItem.Item_ID != txtItemName.Tag.ToString())
                                                            continue;
                                                    if (bItemClassSelected)
                                                        if (oItem.ItemClass_ID != txtItemClass.Tag.ToString())
                                                            continue;
                                                    if (bItemTypeSelected)
                                                        if (oItem.ItemType_ID != txtItemType.Tag.ToString())
                                                            continue;
                                                    if (bItemCategorySelected)
                                                        if (oItem.ItemCategory_ID != txtItemCategory.Tag.ToString())
                                                            continue;

                                                    foreach (tbl_scsStoreGoodReceiveNote_Detail oIGRN_D in tbl_scsStoreGoodReceiveNote_Detail.SelectAllByStoreGoodReceiveNote_ID(oIGRN.StoreGoodReceiveNote_ID).Where(p => p.Item_ID == oIGIN_D.Item_ID))
                                                    {
                                                        glbDtsStock.dt_iGIN_vs_iGRN.Adddt_iGIN_vs_iGRNRow(oIGRN_D.StoreGoodIssueNote_ID, oIGIN.StoreGoodIssueNoteDate, oIGIN_D.Qty,
                                                            oIGIN.FromStore_ID, clsGenaralName.getName_Store(oIGIN.FromStore_ID),
                                                            oIGRN_D.Item_ID, clsGenaralName.getName_Item(oIGRN_D.Item_ID),
                                                            clsGenaralName.getName_ItemClass(oItem.ItemClass_ID),
                                                            clsGenaralName.getName_ItemType(oItem.ItemType_ID),
                                                            clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID),
                                                            oIGRN.StoreGoodReceiveNote_ID, oIGRN.StoreGoodReceiveNoteDate, oIGRN_D.Qty,
                                                            oIGRN.ToStore_ID, clsGenaralName.getName_Store(oIGRN.ToStore_ID),
                                                            oIGIN.CompanyBranch_ID, clsGenaralName.getName_CompanyBranchMaster(oIGIN.CompanyBranch_ID));
                                                    }
                                                }
                                            }
                                        }

                                        glbDtsStock.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glbDtsStock, glb_dtsReportExport.dt_rptParameter, sReportID);
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        glbDtsStock.Clear();
                                        glb_dtsReportExport.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Stock Age Analysis Report
                                else if (Report == enum_ReportName.ST_StockAging)
                                {
                                    string sQry = "exec [dbo].[sp_GetRpt_StockAging] ";
                                    DataTable dt_result = DBHandling.ExecQuery(sQry).Tables[0];

                                    var ExcelReport = new ExcelReports();
                                    ExcelReport.GenerateReport(dt_result, sReportTitle_Main, sFilter);
                                }
                                #endregion

                                #region Stock Movement And Reorder Level
                                else if (Report == enum_ReportName.ST_StockMovementAndReOrderLevel)
                                {
                                    string sQry = "exec [dbo].[sp_GetRpt_StockMovement_And_ReOrderLevel] '" + dtpFrom.Value.Date.ToString("dd-MMM-yyyy") + "','" + dtpTo.Value.ToString("dd-MMM-yyyy")+"'";
                                    DataTable dt_result = DBHandling.ExecQuery(sQry).Tables[0];

                                    var ExcelReport = new ExcelReports();
                                    ExcelReport.GenerateReport(dt_result, sReportTitle_Main, sDaterange);
                                }
                                #endregion
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID, ex);
                        SEACCException.Show(ex);
                    }
                }
            }
        }
        #endregion

        #region ClearField
        private void clearField()
        {
            txtStore.Tag = null;
            txtItemCategory.Tag = null;
            txtItemName.Tag = null;
            txtItemType.Tag = null;
            txtPoNo.Tag = null;
            txtCostCenter.Tag = null;
            txtJobCategory.Tag = null;
            txtSupplier.Tag = null;
            txtItemClass.Tag = null;
            txtCompanyBranch.Tag = clsSecurity.BranchID;
            txtRoute.Tag = null;
            txtRoute.Clear();

            txtStore.Text = "<All Stores>";
            txtItemCategory.Text = "<All Categories>";
            txtItemName.Text = "<All Items>";
            txtItemType.Text = "<All Types>";
            txtCostCenter.Text = "<All Cost Centers>";
            txtJobCategory.Text = "<All Job Categories>";
            txtPoNo.Text = "";
            txtSupplier.Text = "<Supplier Name>";
            txtItemClass.Text = "<All Classes>";
            txtCompanyBranch.Text = clsGenaralName.getName_CompanyBranchMaster(clsSecurity.BranchID);

            cmbItemCostBy.SelectedIndex = 0;
            cmbItemPrice.SelectedIndex = 0;

            chkShowAllItems.Checked = false;
            chkShowDeactivate.Checked = false;
            //   chkBackdate.Checked = true;
            chkTransactionValidateEnable.Checked = true;

            #region old
            //clsCommon.SetEnableDisable_NormalLabel(lblCostCenter, false);
            //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCostCenter, false);
            //clsCommon.SetEnableDisable_NormalCheckBox(chkShowAllItems, false);
            //clsCommon.SetEnableDisable_NormalLabel(lblJobCategory, false);
            //clsCommon.SetEnableDisable_NormalCheckBox(chkShowDeactivate, false);
            //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtJobCategory, false);
            //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtPoNo, false);
            //clsCommon.SetEnableDisable_NormalLabel(lblPONo, false);
            //clsCommon.SetEnableDisable_NormalComboBox(cmbItemCostBy, false);
            //clsCommon.SetEnableDisable_NormalLabel(lblItemCostBy, false);

            //clsCommon.SetEnableDisable_NormalComboBox(cmbItemPrice, false);
            //clsCommon.SetEnableDisable_NormalLabel(lblItemPriceCatagory, false);

            //clsCommon.SetEnableDisable_NormalLabel(lblSupplierType, false);

            //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemClass, false);
            //clsCommon.SetEnableDisable_NormalLabel(lblItemClass, false);
            //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemCategory, false);
            //clsCommon.SetEnableDisable_NormalLabel(lblItemCategory, false);
            //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemType, false);
            //clsCommon.SetEnableDisable_NormalLabel(lblItemType, false);
            //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSupplier, false);
            //clsCommon.SetEnableDisable_NormalLabel(lblSupplier, false);

            //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtStore, true);
            //clsCommon.SetEnableDisable_NormalLabel(lblStore, true);
            //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemName, false);
            //clsCommon.SetEnableDisable_NormalLabel(lblItemName, false); 
            #endregion
      clsCommon.SetVisibility_Panel(pnlRoute, false);
            clsCommon.SetVisibility_Panel(pnlCostCentre, false);
            clsCommon.SetVisibility_Panel(pnlShowAll, false);
            clsCommon.SetVisibility_Panel(pnlJobCat, false);
            clsCommon.SetVisibility_Panel(pnlDeactivatedItem, false);
            clsCommon.SetVisibility_Panel(pnlPONo, false);
            clsCommon.SetVisibility_Panel(pnlCostBy, false);

            clsCommon.SetVisibility_Panel(pnlPriceCat, false);
            clsCommon.SetVisibility_Panel(pnlSupType, false);

            clsCommon.SetVisibility_Panel(pnlItemClass, false);
            clsCommon.SetVisibility_Panel(pnlItemCat, false);
            clsCommon.SetVisibility_Panel(pnlItemType, false);
            clsCommon.SetVisibility_Panel(pnlSupplier, false);

            clsCommon.SetVisibility_Panel(pnlStore, false);
            clsCommon.SetVisibility_Panel(pnlItemName, false);
            clsCommon.SetVisibility_Panel(pnlDate, false);

            clsCommon.SetVisibility_Panel(pnlShowAll, false);
            clsCommon.SetVisibility_Panel(pnlDeactivatedItem, false);
            clsCommon.SetVisibility_Panel(pnlUsedItem, false);
            clsCommon.SetVisibility_Panel(pnlZeroItems, false);

            tbl_genCompanyBranchMaster oBranch = tbl_genCompanyBranchMaster.Select(clsSecurity.BranchID);
            if (oBranch != null)
            {
                if (!oBranch.IsHeadOffice)
                {
                    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCompanyBranch, false);
                    clsCommon.SetEnableDisable_NormalLabel(lblCompanyBranch, false);
                }
            }

            //ChkSummary.Visible = false;
            clsCommon.SetVisibility_Panel(pnlSupplier, false);

            //    clsCommon.SetEnableDisable_NormalCheckBox(chkBackdate, false);

            clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, false);
            clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, false);

            SetEnableDisableCheckBox();

            SelectedRecordsList.Clear();
            dtSelectedRecords.Clear();

            pnlPriceCat.Visible = false;

            chkHideZeroQty.Checked = false;
            //chkHideZeroQty.Enabled = false;

        }
        #endregion

        #region Print Method
        #region report Print Method
        private void print(string path, string sReportTitle1, string sReportTitle2, string sReportTitle3, string sFormula)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Flow Stock Balance";
                ReportDocument RD = new ReportDocument();
                s_Path = Application.StartupPath.Replace("\\Mini ERP\\bin\\Debug", "\\ZION.ERP.Reports");
                s_Path += path;

                frm_ReportViewer viewer = new frm_ReportViewer();
                RD.Load(s_Path); Digiteq.Classes.ReportHelper.LogonServer(ref RD);
                //clsSecurity.LogonServer(ref RD);
                RD.Refresh();

                RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                RD.DataDefinition.FormulaFields["ReportTitle1"].Text = clsCommon.fncsetstring(sReportTitle1);
                RD.DataDefinition.FormulaFields["ReportTitle2"].Text = clsCommon.fncsetstring(sReportTitle2);
                RD.DataDefinition.FormulaFields["ReportTitle3"].Text = clsCommon.fncsetstring(sReportTitle3);
                RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + " To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                RD.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                //    RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);

                //if (rdoStockTake.Checked)
                //    RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);

                string sFilter = "";
                if (txtItemName.Tag != null && txtItemName.Tag.ToString().Length > 0)
                {
                    sFilter += txtItemName.Text.Trim() + " , ";
                    RD.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sFilter);
                }

                if (txtStore.Tag != null && txtStore.Tag.ToString().Trim().Length > 0)
                {
                    sFilter += txtStore.Text.Trim();
                    RD.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sFilter);
                }

                viewer.crystalReportViewer1.ReportSource = RD;
                viewer.crystalReportViewer1.SelectionFormula = sFormula;
                viewer.crystalReportViewer1.Visible = true;
                viewer.crystalReportViewer1.DisplayToolbar = true;
                viewer.crystalReportViewer1.CloseView(false);
                viewer.WindowState = FormWindowState.Maximized;

                viewer.ShowDialog();

                RD.Close();
                RD.Dispose();
            }
            catch (Exception ex)
            {

                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Data set Print method
        private void print(string path, string sReportTitle1, string sReportTitle2, string sReportTitle3, DataSet ojbDataSet, string sFilter, string sReportID)
        {
            try
            {
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle", sReportTitle1, true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle2", sReportTitle2, true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle3", sReportTitle3, true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", clsSecurity.CompanyName, true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", clsSecurity.CompanyAddress1, true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", clsSecurity.CompanyAddress2, true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqName", clsSecurity.DigiteqName, true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqEmail", clsCommon.getCompanyEmail(), true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DateRange", "From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"), true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("UserName", clsSecurity.UserNameLoged, true);

                if (Report == enum_ReportName.ST_Stock_Value_Report || Report == enum_ReportName.ST_Stock_Value_Report_Qty || Report == enum_ReportName.ST_Stock_Value_Report_Waight || Report == enum_ReportName.ST_Stock_Value_Report_Item_Type_Wice || Report == enum_ReportName.ST_PurchaseOrderSummaryReport || Report == enum_ReportName.ST_MonthlyUsageTrackingReport)
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Filter", sFilter, true);

                if (Report == enum_ReportName.ST_Stock_Value_Report_Item_Type_Wice)
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CostBasedOn", cmbItemCostBy.Text, true);

                string sSeperator = "";
                sFilter = "";
                sFilter += (bItemTypeSelected) ? "Item Type : " + txtItemType.Text.Trim() : "";

                sSeperator = sFilter.Length > 0 ? " / " : "";
                sFilter += (bStoreSelected) ? sSeperator + "Item Store : " + txtStore.Text.Trim() : "";

                sSeperator = sFilter.Length > 0 ? " / " : "";
                sFilter += (bItemCategorySelected) ? sSeperator + "Item Category : " + txtItemCategory.Text.Trim() : "";

                sSeperator = sFilter.Length > 0 ? " / " : "";
                sFilter += (bItemClassSelected) ? sSeperator + "Item Class : " + txtItemClass.Text.Trim() : "";

                sSeperator = sFilter.Length > 0 ? " / " : "";
                sFilter += (bPoNoSelected) ? sSeperator + "Po No : " + txtPoNo.Text.Trim() : "";

                sSeperator = sFilter.Length > 0 ? " / " : "";
                sFilter += (bItemSelected) ? sSeperator + "Item Name : " + txtItemName.Text.Trim() : "";

                sFilter += (bItemCostBy) ? sSeperator + "Item Cost By : " + cmbItemCostBy.Text.Trim() : "";

                sFilter += (bCostCenterSelected) ? sSeperator + "Cost Center : " + txtCostCenter.Text.Trim() : "";

                sFilter += (bJobCategorySelected) ? sSeperator + "Job Category : " + txtJobCategory.Text.Trim() : "";

                if (rdoLocal.Checked)
                    sFilter += " Supplier Type : Local";
                else if (rdoForeign.Checked)
                    sFilter += " Supplier Type : Foreign";

                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Filter", sFilter, true);

                frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
                ReportViewer.print(path, ojbDataSet, glb_dtsReportExport.dt_rptParameter, sReportID);
            }
            catch (Exception ex)
            {

                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void print(string path, string sReportTitle1, string sReportTitle2, string sReportTitle3, DataSet objDataSet, string sFilter)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "";// sHeaderTitle = "Standard Reports";
                CrystalDecisions.CrystalReports.Engine.ReportDocument objRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                s_Path = Application.StartupPath.Replace("\\Mini ERP\\bin\\Debug", "\\ZION.ERP.Reports");
                s_Path += path;

                objRpt.Load(s_Path);//glbDtsStock
                objRpt.SetDataSource(objDataSet); //(glbDtsSales)

                //objRpt.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                objRpt.DataDefinition.FormulaFields["ReportTitle1"].Text = clsCommon.fncsetstring(sReportTitle1);
                objRpt.DataDefinition.FormulaFields["ReportTitle2"].Text = clsCommon.fncsetstring(sReportTitle2);
                objRpt.DataDefinition.FormulaFields["ReportTitle3"].Text = clsCommon.fncsetstring(sReportTitle3);
                objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                objRpt.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                //BalanceAmount
                if (Report == enum_ReportName.ST_Stock_Value_Report || Report == enum_ReportName.ST_Stock_Value_Report_Qty || Report == enum_ReportName.ST_Stock_Value_Report_Waight || Report == enum_ReportName.ST_Stock_Value_Report_Item_Type_Wice || Report == enum_ReportName.ST_PurchaseOrderSummaryReport || Report == enum_ReportName.ST_MonthlyUsageTrackingReport)
                    objRpt.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sFilter);
                if (Report == enum_ReportName.ST_LoanOut || Report == enum_ReportName.ST_LoanIN || Report == enum_ReportName.ST_Pending_LoanOut || Report == enum_ReportName.ST_Pending_LoanIn)
                    objRpt.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sFilter);

                if (Report == enum_ReportName.ST_Stock_Value_Report)
                    objRpt.DataDefinition.FormulaFields["CostBasedOn"].Text = clsCommon.fncsetstring(cmbItemCostBy.Text);

                #region Loan In out Report
                if (Report == enum_ReportName.ST_Pending_LoanIn || Report == enum_ReportName.ST_LoanIN)
                {
                    objRpt.DataDefinition.FormulaFields["isLoanInBased"].Text = clsCommon.fncsetstring("Y");
                    //isLoanInBased
                }
                else if (Report == enum_ReportName.ST_LoanOut || Report == enum_ReportName.ST_Pending_LoanOut)
                {
                    objRpt.DataDefinition.FormulaFields["isLoanInBased"].Text = clsCommon.fncsetstring("N");
                }
                #endregion

                string sSeperator = "";
                sFilter = "";
                sFilter += (bItemTypeSelected) ? "Item Type : " + txtItemType.Text.Trim() : "";

                sSeperator = sFilter.Length > 0 ? " / " : "";
                sFilter += (bStoreSelected) ? sSeperator + "Item Store : " + txtStore.Text.Trim() : "";

                sSeperator = sFilter.Length > 0 ? " / " : "";
                sFilter += (bItemCategorySelected) ? sSeperator + "Item Category : " + txtItemCategory.Text.Trim() : "";

                sSeperator = sFilter.Length > 0 ? " / " : "";
                sFilter += (bPoNoSelected) ? sSeperator + "Po No : " + txtPoNo.Text.Trim() : "";

                sSeperator = sFilter.Length > 0 ? " / " : "";
                sFilter += (bItemSelected) ? sSeperator + "Item Name : " + txtItemName.Text.Trim() : "";

                sFilter += (bItemCostBy) ? sSeperator + "Item Cost By : " + cmbItemCostBy.Text.Trim() : "";

                sFilter += (bCostCenterSelected) ? sSeperator + "Cost Center : " + txtCostCenter.Text.Trim() : "";

                sFilter += (bJobCategorySelected) ? sSeperator + "Job Category : " + txtJobCategory.Text.Trim() : "";

                if (rdoLocal.Checked)
                    sFilter += " Supplier Type : Local";
                else if (rdoForeign.Checked)
                    sFilter += " Supplier Type : Foreign";

                objRpt.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sFilter);


                //if (rdoLoanInLoanOut.Checked)
                //{
                //    if (chkShowAllItems.Checked && !chkLoanInBased.Enabled)
                //    {
                //        objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("");
                //    }
                //}



                frm_ReportViewer ReportViewer = new frm_ReportViewer();
                ReportViewer.crystalReportViewer1.ReportSource = objRpt;
                ReportViewer.crystalReportViewer1.Refresh();
                ReportViewer.crystalReportViewer1.DisplayToolbar = true;
                ReportViewer.crystalReportViewer1.CloseView(false);
                ReportViewer.WindowState = FormWindowState.Maximized;
                ReportViewer.ShowDialog();

                objRpt.Close();
                objRpt.Dispose();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #endregion

        #region KeyDown Events
        private void frm_rpt_ChequeManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void txtStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterStore(ref txtStore, true);
        }
        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterItemType(ref txtItemType);
        }
        private void txtItemType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtItemType_DoubleClick(null, null);
        }
        private void txtItemCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterItemCategory(ref txtItemCategory);
        }
        private void txtPoNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_TransactionPurchaseOrder_Use(ref txtPoNo);
        }
        private void txtJobCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterProductionJobType(ref txtJobCategory);
        }
        private void txtCostCenter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtCostCenter_DoubleClick(null, null);
        }
        private void txtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterSupplier(ref txtSupplier);
        }
        private void txtCompanyBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_CompanyBranch(ref txtCompanyBranch);
        }
        #endregion

        #region Events DoublClick
        private void txtStoreStock_DoubleClick(object sender, EventArgs e)
        {
            if (clsConfig.bShowAll_branches_storeSearch)
                clsSearch.Search_MasterStore(ref txtStore, false);
            else
                clsSearch.Search_MasterStore(ref txtStore, true);
        }
        private void txtCostCenter_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_costCenter1(ref txtCostCenter);
        }
        private void txtSupplier_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterSupplier(ref txtSupplier);
        }
        private void txtItemName_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_ItemMaster(ref txtItemName, null, null, null, chkShowDeactivate.Checked);
        }
        private void txtItemType_DoubleClick(object sender, EventArgs e)
        {
            if (Report == enum_ReportName.ST_Stock_Value_Report_Qty || Report == enum_ReportName.ST_Stock_Value_Report_Waight)
            {
                frmSearchMaster_ItemType frm = new frmSearchMaster_ItemType();
                frm.Search(ref dtSelectedRecords);

                txtItemType.Clear();
                txtItemType.Tag = null;
                SelectedRecordsList.Clear();

                foreach (DataRow row in dtSelectedRecords.Rows)
                {
                    if (bool.Parse(row["IsSelect"].ToString()))
                    {
                        SelectedRecordsList.Clear();
                        SelectedRecordsList.Add(row["TypeCode"].ToString());
                        txtItemType.Text += row["TypeName"].ToString() + " | ";
                    }
                }
            }
            else
            {
                clsSearch.Search_MasterItemType(ref txtItemType);

                if (txtItemType.Tag != null)
                    SelectedRecordsList.Add(txtItemType.Tag.ToString());
            }
        }
        private void txtItemCategory_DoubleClick(object sender, EventArgs e)
        {
            //clsSearch.Search_MasterItemCategory(ref txtItemCategory);
            List<string> lstParameeters = new List<string>();
            frmSearch RowDataSearch = null;

            RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ItemCategory);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtItemCategory.Tag = lstResult[0];
                txtItemCategory.Text = lstResult[1];
            }
        }

        private void txtItemClass_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            frmSearch RowDataSearch = null;

            RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ItemClass);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtItemClass.Tag = lstResult[0];
                txtItemClass.Text = lstResult[1];
            }
        }

        private void txtPoNo_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_TransactionPurchaseOrder_Use(ref txtPoNo);
        }
        private void txtJobCategory_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterProductionJobType(ref txtJobCategory);
        }

        private void dgvReports_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int iReportID = clsValidate.ValidateGridValue(dgvReports, "report_ID", e.RowIndex, 0);
                setEnableDisableConctrol(iReportID);
            }
        }

        private void dgvReports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvReports_CellClick(sender, e);
        }

        private void txtRoute_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterRoute(ref txtRoute);
        }

        private void txtCompanyBranch_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_CompanyBranch(ref txtCompanyBranch);
        }
        #endregion

        #region Events CheckedChanged

        #region MyRegion
        //private void rdo_FlowStock_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoStoreStock_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdo_TrackingReport_Weight_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoStockTrackingReport_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoStockMovementReport_detail_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoItemsCard_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoStockBalanceVsPending_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoStockTake_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoItemSplitNoteDelta_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //} 
        #endregion
        private void ChkSummary_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSummary.Checked)
                ChkSummary.Text = "Summary";
            else
                ChkSummary.Text = "Detail";
        }

        #region MyRegion
        //private void rdoLoanInLoanOut_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoSRvsGIN_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoPendingLoanIn_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoPendingLoanOut_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoPOItemCostHistory_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoReOrderLevelExceed_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoReOrderItemWise_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoStockValueReport_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoStockValueReport_Qty_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoStockValueReport_Weight_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}

        //private void rdoItemTypeWise_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoStoreValueItemTypeWise_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoCostCenterWiseItemTracking_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoDesignCategory_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoMonthlyUsageTrackingReport_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoPurchaseSummaryTrackingReport_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoLoanTracking_LoanIN_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //    //rdoLoanTracking_LoanIN
        //} 
        #endregion

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlFilters_Paint(object sender, PaintEventArgs e)
        {

        }

        #region MyRegion
        //private void rdoStockStatement_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}

        //private void rdoIPriceList_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}

        //private void rdoFastMovingItems_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}

        //private void rdoSlowMovingItems_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //} 
        #endregion
        #endregion

        #region Set Enable/Disable Controls
        private void setEnableDisableConctrol(int iReportID)
        {
            clearField();

            if (iReportID == (int)enum_ReportName.ST_Store_Requests_vs_Issues)
            {
                clsCommon.SetVisibility_Panel(pnlStore, true);
                clsCommon.SetVisibility_Panel(pnlItemCat, true);
                clsCommon.SetVisibility_Panel(pnlItemType, true);
                clsCommon.SetVisibility_Panel(pnlItemName, true);
                clsCommon.SetVisibility_Panel(pnlDate, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);

                rdoForeign.Enabled = false;
                rdoLocal.Enabled = false;
                rdoAll.Enabled = false;
            }

            else if (iReportID == (int)enum_ReportName.ST_FloorStockReport)
            {
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);

                clsCommon.SetVisibility_Panel(pnlStore, true);
                clsCommon.SetVisibility_Panel(pnlItemCat, true);
                clsCommon.SetVisibility_Panel(pnlItemType, true);
                clsCommon.SetVisibility_Panel(pnlItemName, true);
                clsCommon.SetVisibility_Panel(pnlDate, true);

                clsCommon.SetVisibility_Panel(pnlZeroItems, true);
                clsCommon.SetVisibility_Panel(pnlDeactivatedItem, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_Item_SplitNote_DeltaReport)
            {
                clsCommon.SetVisibility_Panel(pnlItemName, true);
                clsCommon.SetVisibility_Panel(pnlStore, true);
                clsCommon.SetVisibility_Panel(pnlDate, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);

                rdoForeign.Enabled = false;
                rdoLocal.Enabled = false;
                rdoAll.Enabled = false;
            }
            else if (iReportID == (int)enum_ReportName.ST_Pending_LoanOut ||
                iReportID == (int)enum_ReportName.ST_Pending_LoanIn || 
                iReportID == (int)enum_ReportName.ST_LoanOut || iReportID == (int)enum_ReportName.ST_LoanIN)
            {
                clsCommon.SetVisibility_Panel(pnlDate, true);

                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);

                rdoForeign.Enabled = false;
                rdoLocal.Enabled = false;
                rdoAll.Enabled = false;
                //chkTransactionValidateEnable.Enabled = false;
                clsCommon.SetVisibility_Panel(pnlShowAll, true);
                //chkHideZeroQty.Enabled = false;
            }
            else if (iReportID == (int)enum_ReportName.ST_Stocks_MovementReport || 
                iReportID == (int)enum_ReportName.ST_Items_Card || 
                iReportID == (int)enum_ReportName.ST_Stock_Statement)
            {
                clsCommon.SetVisibility_Panel(pnlDeactivatedItem, true);
                clsCommon.SetVisibility_Panel(pnlItemName, true);
                clsCommon.SetVisibility_Panel(pnlItemCat, true);
                clsCommon.SetVisibility_Panel(pnlStore, true);
                clsCommon.SetVisibility_Panel(pnlDate, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);

                rdoForeign.Enabled = false;
                rdoLocal.Enabled = false;
                rdoAll.Enabled = false;
                clsCommon.SetVisibility_Panel(pnlUsedItem, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_Stocks_MovementReport_Detail)
            {
                clsCommon.SetVisibility_Panel(pnlCostBy, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
                clsCommon.SetVisibility_Panel(pnlItemCat, true);
                clsCommon.SetVisibility_Panel(pnlStore, true);
                clsCommon.SetVisibility_Panel(pnlDate, true);
                clsCommon.SetVisibility_Panel(pnlItemType, true);
                clsCommon.SetVisibility_Panel(pnlPriceCat, true);
                //chkHideZeroQty.Enabled = false;
                clsCommon.SetVisibility_Panel(pnlUsedItem, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_Stocks_TrackingReport_Qty)
            {
                clsCommon.SetVisibility_Panel(pnlStore, true);
                clsCommon.SetVisibility_Panel(pnlDeactivatedItem, true);
                clsCommon.SetVisibility_Panel(pnlItemName, true);
                clsCommon.SetVisibility_Panel(pnlItemCat, true);
                clsCommon.SetVisibility_Panel(pnlDate, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);

                rdoForeign.Enabled = false;
                rdoLocal.Enabled = false;
                rdoAll.Enabled = false;
                clsCommon.SetVisibility_Panel(pnlUsedItem, true);
                chkTransactionValidateEnable.Checked = false;
                //   clsCommon.SetEnableDisable_NormalCheckBox(chkBackdate, true);
                //chkHideZeroQty.Enabled = false;
            }
            else if (iReportID == (int)enum_ReportName.ST_Stocks_TrackingReport_Weight)
            {
                clsCommon.SetVisibility_Panel(pnlStore, true);
                clsCommon.SetVisibility_Panel(pnlDeactivatedItem, true);
                clsCommon.SetVisibility_Panel(pnlItemName, true);
                clsCommon.SetVisibility_Panel(pnlDate, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);

                rdoForeign.Enabled = false;
                rdoLocal.Enabled = false;
                rdoAll.Enabled = false;
                clsCommon.SetVisibility_Panel(pnlUsedItem, true);
                //      clsCommon.SetEnableDisable_NormalCheckBox(chkBackdate, true);
                //chkHideZeroQty.Enabled = false;
            }
            else if (iReportID == (int)enum_ReportName.ST_Purchase_Order_Item_Cost_History)
            {
                clsCommon.SetVisibility_Panel(pnlStore, true);
                clsCommon.SetVisibility_Panel(pnlPONo, true);
                clsCommon.SetVisibility_Panel(pnlDate, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);

                rdoForeign.Enabled = false;
                rdoLocal.Enabled = false;
                rdoAll.Enabled = false;
            }
            else if (iReportID == (int)enum_ReportName.ST_ReOrder_Leval_Exceed_Items 
                || iReportID == (int)enum_ReportName.ST_ReOrder_Level_ItemsWise)
            {
                clsCommon.SetVisibility_Panel(pnlStore, true);
                clsCommon.SetVisibility_Panel(pnlItemName, true);
                clsCommon.SetVisibility_Panel(pnlItemCat, true);
                clsCommon.SetVisibility_Panel(pnlItemType, true);

                rdoForeign.Enabled = false;
                rdoLocal.Enabled = false;
                rdoAll.Enabled = false;

            }
            else if (iReportID == (int)enum_ReportName.ST_Stock_Value_Report || 
                iReportID == (int)enum_ReportName.ST_Stock_Value_Report_Qty || 
                iReportID == (int)enum_ReportName.ST_Stock_Value_Report_Waight)
            {
                clsCommon.SetVisibility_Panel(pnlStore, true);
                clsCommon.SetVisibility_Panel(pnlDeactivatedItem, true);
                clsCommon.SetVisibility_Panel(pnlItemName, true);
                clsCommon.SetVisibility_Panel(pnlItemCat, true);
                clsCommon.SetVisibility_Panel(pnlItemType, true);
                clsCommon.SetVisibility_Panel(pnlCostBy, true);
                clsCommon.SetVisibility_Panel(pnlShowAll, true);
                clsCommon.SetVisibility_Panel(pnlDate, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);

                rdoForeign.Enabled = false;
                rdoLocal.Enabled = false;
                rdoAll.Enabled = false;

                chkHideZeroQty.Enabled = false;
                if (iReportID == (int)enum_ReportName.ST_Stock_Value_Report_Qty || 
                    iReportID == (int)enum_ReportName.ST_Stock_Value_Report_Waight)
                {
                    clsCommon.SetVisibility_Panel(pnlSupplier, true);
                    ChkSummary.Visible = true;
                    ChkSummary.Checked = false;
                }
            }
            else if (iReportID == (int)enum_ReportName.ST_Stock_Value_Report_Item_Type_Wice)
            {
                clsCommon.SetVisibility_Panel(pnlItemName, true);
                clsCommon.SetVisibility_Panel(pnlItemCat, true);
                clsCommon.SetVisibility_Panel(pnlItemType, true);
                clsCommon.SetVisibility_Panel(pnlCostBy, true);
                clsCommon.SetVisibility_Panel(pnlShowAll, true);

                rdoForeign.Enabled = false;
                rdoLocal.Enabled = false;
                rdoAll.Enabled = false;
            }
            else if (iReportID == (int)enum_ReportName.ST_CostCenterWiseItemTracking)
            {
                clsCommon.SetVisibility_Panel(pnlCostCentre, true);
                clsCommon.SetVisibility_Panel(pnlDeactivatedItem, true);

                rdoForeign.Enabled = false;
                rdoLocal.Enabled = false;
                rdoAll.Enabled = false;
            }
            else if (iReportID == (int)enum_ReportName.ST_PurchaseOrderSummaryReport)
            {
                clsCommon.SetVisibility_Panel(pnlCostCentre, true);
                clsCommon.SetVisibility_Panel(pnlStore, true);
                clsCommon.SetVisibility_Panel(pnlItemCat, true);
                clsCommon.SetVisibility_Panel(pnlItemType, true);
                clsCommon.SetVisibility_Panel(pnlDeactivatedItem, true);
                clsCommon.SetVisibility_Panel(pnlShowAll, true);
                clsCommon.SetVisibility_Panel(pnlJobCat, true);
                clsCommon.SetVisibility_Panel(pnlItemName, true);
                clsCommon.SetVisibility_Panel(pnlDate, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);

                rdoForeign.Enabled = true;
                rdoLocal.Enabled = true;
                rdoAll.Enabled = true;
            }
            else if (iReportID == (int)enum_ReportName.ST_MonthlyUsageTrackingReport)
            {
                clsCommon.SetVisibility_Panel(pnlItemCat, true);
                clsCommon.SetVisibility_Panel(pnlJobCat, true);

                clsCommon.SetVisibility_Panel(pnlDate, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);

                rdoForeign.Enabled = false;
                rdoLocal.Enabled = false;
                rdoAll.Enabled = false;
            }
            else if (iReportID == (int)enum_ReportName.ST_Fast_Moving_Items || 
                iReportID == (int)enum_ReportName.ST_Slow_Moving_Items)
            {
                clsCommon.SetVisibility_Panel(pnlStore, true);
                clsCommon.SetVisibility_Panel(pnlItemName, true);
                clsCommon.SetVisibility_Panel(pnlItemClass, true);
                clsCommon.SetVisibility_Panel(pnlItemCat, true);
                clsCommon.SetVisibility_Panel(pnlItemType, true);
                clsCommon.SetVisibility_Panel(pnlDate, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetVisibility_Panel(pnlZeroItems, true);
            }
           
            else if (iReportID == (int)enum_ReportName.ST_Item_Price_List)
            {
                clsCommon.SetVisibility_Panel(pnlItemName, true);
                clsCommon.SetVisibility_Panel(pnlItemClass, true);
                clsCommon.SetVisibility_Panel(pnlItemCat, true);
                clsCommon.SetVisibility_Panel(pnlItemType, true);

                rdoForeign.Enabled = false;
                rdoLocal.Enabled = false;
                rdoAll.Enabled = false;
                //chkTransactionValidateEnable.Enabled = false;
                //clsCommon.SetEnableDisable_NormalCheckBox(chkShowAllItems, false);
                //chkHideZeroQty.Enabled = false;
            }
            else if (iReportID == (int)enum_ReportName.ST_iGIN_vs_iGRN_Report)
            {
                clsCommon.SetVisibility_Panel(pnlStore, true);
                clsCommon.SetVisibility_Panel(pnlItemName, true);
                clsCommon.SetVisibility_Panel(pnlItemClass, true);
                clsCommon.SetVisibility_Panel(pnlItemCat, true);
                clsCommon.SetVisibility_Panel(pnlItemType, true);
                clsCommon.SetVisibility_Panel(pnlComBranch, true);
                clsCommon.SetVisibility_Panel(pnlDate, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
            }

            else if (iReportID == (int)enum_ReportName.ST_Purchase_Order_Tracking_Report)
            {
                clsCommon.SetVisibility_Panel(pnlDate, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);

                rdoForeign.Enabled = false;
                rdoLocal.Enabled = false;
                rdoAll.Enabled = false;
                //chkTransactionValidateEnable.Enabled = false;
                clsCommon.SetVisibility_Panel(pnlShowAll, true);
                //chkHideZeroQty.Enabled = false;
            }
            else if (iReportID == (int)enum_ReportName.ST_StockMovementAndReOrderLevel)
            {
                clsCommon.SetVisibility_Panel(pnlDate, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, false);
                dtpTo.Value = DateTime.Now;
            }
        }
        #endregion

        #region Get CostPrice
        //private decimal getCostPrice(string sItemCode, string sSubCategory1, string sSubCategory2, string sSerial1, string sSerial2)
        //{
        //    decimal dValue = 0;
        //    if (cmbItemCostBy.SelectedIndex == 1)
        //        dValue = clsProcessMethods.GetCostPrice_ByCostType(sItemCode, sSubCategory1, sSubCategory2, sSerial1, sSerial2, enum_CostPriceType.WeightedAverage);
        //    if (cmbItemCostBy.SelectedIndex == 2)
        //        dValue = clsProcessMethods.GetCostPrice_ByCostType(sItemCode, sSubCategory1, sSubCategory2, sSerial1, sSerial2, enum_CostPriceType.LIFO);
        //    if (cmbItemCostBy.SelectedIndex == 3)
        //        dValue = clsProcessMethods.GetCostPrice_ByCostType(sItemCode, sSubCategory1, sSubCategory2, sSerial1, sSerial2, enum_CostPriceType.FIFO);
        //    if (cmbItemCostBy.SelectedIndex == 4)
        //        dValue = clsProcessMethods.GetCostPrice_ByCostType(sItemCode, sSubCategory1, sSubCategory2, sSerial1, sSerial2, enum_CostPriceType.HighestPurchaseCost);
        //    if (cmbItemCostBy.SelectedIndex == 5)
        //        dValue = clsProcessMethods.GetCostPrice_ByCostType(sItemCode, sSubCategory1, sSubCategory2, sSerial1, sSerial2, enum_CostPriceType.LovestPurchaseCost);
        //    if (cmbItemCostBy.SelectedIndex == 6)
        //        dValue = clsProcessMethods.GetCostPrice_ByCostType(sItemCode, sSubCategory1, sSubCategory2, sSerial1, sSerial2, enum_CostPriceType.CostPrice1);
        //    if (cmbItemCostBy.SelectedIndex == 7)
        //        dValue = clsProcessMethods.GetCostPrice_ByCostType(sItemCode, sSubCategory1, sSubCategory2, sSerial1, sSerial2, enum_CostPriceType.CostPrice2);

        //    return dValue;
        //}
        #endregion

        #region Check Validity Empty Fields
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;
            try
            {
                if (txtItemName.Text.Trim().Length <= 0)
                {
                    strMessage += "\n" + "Item Name ";
                    bStatus = false;
                }
                if (txtStore.Text.Trim().Length <= 0)
                {
                    strMessage += "\n" + "Store Name";
                    bStatus = false;
                }
                if (bStatus == false)
                {
                    MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bStatus;
        }
        #endregion

        #region Enable Disable CheckBox
        private void SetEnableDisableCheckBox()
        {
            if (clsConfig.bIsUserWise_EnableDisableReport)//Disable Report for specific User
            {
                #region MyRegion
                //rdo_FlowStock.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_FloorStockReport);
                //rdoStockMovementReport.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_Stocks_MovementReport);
                //rdo_TrackingReport_Qty.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_Stocks_TrackingReport_Qty);
                //rdo_TrackingReport_Weight.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_Stocks_TrackingReport_Weight);
                //rdoCostCenterWiseItemTracking.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_CostCenterWiseItemTracking);
                //rdoMonthlyUsageTrackingReport.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_MonthlyUsageTrackingReport);
                //rdoStockTake.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_Opening_StockReport);
                ////rdoStockAgeAnalysis.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_Stock_Age_Analysis_Report);
                ////   rdoStockAgeAnalysis_CostWise.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_Stock_Age_Analysis_Report);
                //rdoItemSplitNoteDelta.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_Item_SplitNote_DeltaReport);
                //rdoSRvsGIN.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_Store_Requests_vs_Issues);
                //rdoPurchaseSummaryTrackingReport.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_PurchaseOrderSummaryReport);
                //rdoPurchaseSummaryTrackingReport_SupplierWise.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_PurchaseOrderSummaryReport);

                ////Not Set Permissions//
                ////rdoReOrderLevelExceed.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_Stocks_TrackingReport_Qty);
                ////No Report For This//
                ////rdoStockBalanceVsPending.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_Stocks_TrackingReport_Qty);

                //rdoPRNTracking.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_PRNTracking);
                //rdoStockValueReport.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_Stock_Value_Report);
                //rdoStockValueReport_Qty.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_Stock_Value_Report_Qty);
                //rdoStockValueReport_Weight.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_Stock_Value_Report_Waight);
                //rdoStoreValueItemTypeWise.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_Stock_Value_Report_Item_Type_Wice);
                //rdoPOItemCostHistory.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_Purchase_Order_Item_Cost_History);
                //rdoPendingPO.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_Purchase_Order_Tracking_Report);
                //rdoPendingLoanOut.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_Pending_LoanOut);
                //rdoPendingLoanIn.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_Pending_LoanIn);
                //rdoLoanTracking_LoanOut.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_LoanIN); 
                #endregion
            }
            else//Disable Report for entire Solution
            {
                #region MyRegion
                //rdo_FlowStock.Enabled = clsSecurity.isEnableReportRadioButton(enum_ReportName.ST_FloorStockReport);
                //rdoStockMovementReport.Enabled = clsSecurity.isEnableReportRadioButton(enum_ReportName.ST_Stocks_MovementReport);
                //rdo_TrackingReport_Qty.Enabled = clsSecurity.isEnableReportRadioButton(enum_ReportName.ST_Stocks_TrackingReport_Qty);
                //rdo_TrackingReport_Weight.Enabled = clsSecurity.isEnableReportRadioButton(enum_ReportName.ST_Stocks_TrackingReport_Weight);
                //rdoCostCenterWiseItemTracking.Enabled = clsSecurity.isEnableReportRadioButton(enum_ReportName.ST_CostCenterWiseItemTracking);
                //rdoMonthlyUsageTrackingReport.Enabled = clsSecurity.isEnableReportRadioButton(enum_ReportName.ST_MonthlyUsageTrackingReport);
                //rdoStockTake.Enabled = clsSecurity.isEnableReportRadioButton(enum_ReportName.ST_Opening_StockReport);
                ////rdoStockAgeAnalysis.Enabled = clsSecurity.isEnableReportRadioButton(enum_ReportName.ST_Stock_Age_Analysis_Report);
                ////  rdoStockAgeAnalysis_CostWise.Enabled = clsSecurity.isEnableReportRadioButton(enum_ReportName.ST_Stock_Age_Analysis_Report);
                //rdoItemSplitNoteDelta.Enabled = clsSecurity.isEnableReportRadioButton(enum_ReportName.ST_Item_SplitNote_DeltaReport);
                //rdoSRvsGIN.Enabled = clsSecurity.isEnableReportRadioButton(enum_ReportName.ST_Store_Requests_vs_Issues);
                //rdoPurchaseSummaryTrackingReport.Enabled = clsSecurity.isEnableReportRadioButton(enum_ReportName.ST_PurchaseOrderSummaryReport);
                //rdoPurchaseSummaryTrackingReport_SupplierWise.Enabled = clsSecurity.isEnableReportRadioButton(enum_ReportName.ST_PurchaseOrderSummaryReport);

                ////Not Set Permissions//
                ////rdoReOrderLevelExceed.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_Stocks_TrackingReport_Qty);
                ////No Report For This//
                ////rdoStockBalanceVsPending.Enabled = clsSecurity.isEnableReportRadioButton(clsSecurity.UserName, enum_ReportName.ST_Stocks_TrackingReport_Qty);

                //rdoPRNTracking.Enabled = clsSecurity.isEnableReportRadioButton(enum_ReportName.ST_PRNTracking);
                //rdoStockValueReport.Enabled = clsSecurity.isEnableReportRadioButton(enum_ReportName.ST_Stock_Value_Report);
                //rdoStockValueReport_Qty.Enabled = clsSecurity.isEnableReportRadioButton(enum_ReportName.ST_Stock_Value_Report_Qty);
                //rdoStockValueReport_Weight.Enabled = clsSecurity.isEnableReportRadioButton(enum_ReportName.ST_Stock_Value_Report_Waight);
                //rdoStoreValueItemTypeWise.Enabled = clsSecurity.isEnableReportRadioButton(enum_ReportName.ST_Stock_Value_Report_Item_Type_Wice);
                //rdoPOItemCostHistory.Enabled = clsSecurity.isEnableReportRadioButton(enum_ReportName.ST_Purchase_Order_Item_Cost_History);
                //rdoPendingPO.Enabled = clsSecurity.isEnableReportRadioButton(enum_ReportName.ST_Purchase_Order_Tracking_Report);
                //rdoPendingLoanOut.Enabled = clsSecurity.isEnableReportRadioButton(enum_ReportName.ST_Pending_LoanOut);
                //rdoPendingLoanIn.Enabled = clsSecurity.isEnableReportRadioButton(enum_ReportName.ST_Pending_LoanIn);
                //rdoLoanTracking_LoanOut.Enabled = clsSecurity.isEnableReportRadioButton(enum_ReportName.ST_LoanIN); 
                #endregion

            }
        }
        #endregion

        private void CreateDataTable()
        {
            glb_dtItemTracking = new DataTable();
            glb_dtItemTracking.Columns.Add("ItemCode", typeof(string));
            glb_dtItemTracking.Columns.Add("SubCategoryID", typeof(string));
            glb_dtItemTracking.Columns.Add("QTY", typeof(int));
        }

    }


    public class Stockreports
    {
        dts_Stock glb_dtsStock = new dts_Stock();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        DateTime dtmToDate = DateTime.Now.Date, dtmfromDate = DateTime.Now.Date;
        enum_CostPriceType enCostType = enum_CostPriceType.CostPrice1;


        bool bIsShowDeactivated = false, bItemName_Selected = false, bStore_Selected = false, bItemCategory_Selected = false, bItemType_Selected = false;
        TextBox txtStore, txtItemName, txtItemCategory;
        int iRptType = 0;
        List<string> lstItemType = new List<string>();
        string sDaterange = "";
        string sRptName = "", sRptName2 = "", sRptPath = "";
        string sDateRange = "";
        bool bIsSummaryReport = false;
        public bool bShowAllItems = false;

        public Stockreports(bool Store_Selected, bool ItemCategory_Selected, bool ItemType_Selected, TextBox TxtStore, TextBox TxtItemName, TextBox TxtItemCategory, List<string> LstItemType, DateTime fromDate, DateTime toDate, enum_CostPriceType eCostType, bool isShowDeactivated)
        {
            bIsShowDeactivated = isShowDeactivated;
            bItemName_Selected = TxtItemName.Tag != null ? true : false;
            bStore_Selected = Store_Selected;
            bItemCategory_Selected = ItemCategory_Selected;
            bItemType_Selected = ItemType_Selected;

            txtStore = TxtStore;
            txtItemName = TxtItemName;
            txtItemCategory = TxtItemCategory;
            lstItemType = LstItemType;

            dtmfromDate = fromDate;
            dtmToDate = toDate;
            enCostType = eCostType;
            sDaterange = "As at :" + clsFormatter.FormatDate_Short(toDate);
        }


        public void GenarateFloorStockReport(enum_ReportName eRPTname, ref ProgressBar pb1, bool bTransactionValidateEnable, string sReportTitle_Main, string sReportTitle_Sub, string sCompanyBranchID)
        {
            #region Check Permissions
            //bool bIsauthenticated = false;
            //if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(eRPTname)))
            //    bIsauthenticated = true;
            #endregion

            //if (bIsauthenticated)
            //{
            //to do
            //optimize branch name get method
            //optimice single store
            //optimaize singal catagory
            //optimize singal type
            //
            pb1.Value = 0;
            string sFilter = "";
            string sReportPath = "";
            if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(eRPTname), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
            {
                List<string> sItemList = new List<string>();
                glb_dtsStock.Clear();
                try
                {
                    #region Fill reference data and string Filter
                    foreach (tbl_genStoreMaster oStore in tbl_genStoreMaster.SelectAll())
                    {
                        glb_dtsStock.dt_Store.Adddt_StoreRow(oStore.Store_ID, oStore.StoreName);
                    }
                    foreach (tbl_zItemClass oItemClass in tbl_zItemClass.SelectAll())
                    {
                        glb_dtsStock.dt_ItemClass.Adddt_ItemClassRow(oItemClass.ItemClass_ID, oItemClass.ClassName);
                    }
                    foreach (tbl_zItemType oItemType in tbl_zItemType.SelectAll())
                    {
                        glb_dtsStock.dt_ItemType.Adddt_ItemTypeRow(oItemType.ItemType_ID, oItemType.TypeName);
                    }
                    foreach (tbl_zItemCategory oitemCat in tbl_zItemCategory.SelectAll())
                    {
                        glb_dtsStock.dt_ItemCategory.Adddt_ItemCategoryRow(oitemCat.ItemCategory_ID, oitemCat.CategoryName);
                    }
                    foreach (tbl_zItemCategory_Sub oItemCatSub in tbl_zItemCategory_Sub.SelectAll())
                    {
                        glb_dtsStock.dt_ItemSubCategory.Adddt_ItemSubCategoryRow(oItemCatSub.ItemCategorySub_ID, oItemCatSub.CategorySubName);
                    }
                    if (eRPTname == enum_ReportName.ST_Stocks_MovementReport_Detail || eRPTname == enum_ReportName.ST_Items_Card || eRPTname == enum_ReportName.ST_Stock_Statement || eRPTname == enum_ReportName.ST_FloorStockReport)
                    {
                        foreach (tbl_genItemMaster oItem in tbl_genItemMaster.SelectAll())
                        {
                            tbl_genItemMaster_Pricing oItemF = tbl_genItemMaster_Pricing.Select(oItem.Item_ID);
                            if (oItemF != null)
                            {
                                glb_dtsStock.dt_ItemMaster.Adddt_ItemMasterRow(oItem.Item_ID, oItem.ItemName, oItem.Description, oItem.IsWeightCalculation_Purchase, oItem.Brand_ID, oItemF.SellingPrice1, oItemF.SellingPrice2);
                            }
                        }
                    }

                    if (bStore_Selected)
                        sFilter += "Item Store : " + txtStore.Text;
                    if (bItemName_Selected)
                        sFilter += "Item : " + txtItemName.Text;
                    if (bItemCategory_Selected)
                        sFilter += "Item Category : " + txtItemCategory.Text;
                    if (bItemType_Selected)
                    {
                        sFilter += "Item type : ";
                        foreach (string sItemType in lstItemType)
                        {
                            sFilter += clsGenaralName.getName_ItemType(sItemType) + ",";
                        }
                    }
                    if (sFilter == "")
                        sFilter = "-";
                    #endregion

                    #region Report Filter
                    decimal dCostPriceValue = 0;
                    if (eRPTname == enum_ReportName.ST_FloorStockReport || eRPTname == enum_ReportName.ST_Stock_Value_Report)
                        iRptType = 0;
                    else
                    {
                        if (eRPTname == enum_ReportName.ST_Stock_Value_Report_Qty || eRPTname == enum_ReportName.ST_Stock_Value_Report_Qty_Detail)
                            iRptType = 1;
                    }
                    if (eRPTname == enum_ReportName.ST_Stock_Value_Report_Qty || eRPTname == enum_ReportName.ST_Stock_Value_Report_Waight)
                        bIsSummaryReport = true;
                    #endregion

                    List<srh_scsFlowStock> oDetail;
                    if (bItemName_Selected)
                        oDetail = srh_scsFlowStock.Select(dtmfromDate.AddDays(-1), txtItemName.Tag.ToString().Trim(), bIsShowDeactivated ? "%" : "0", sCompanyBranchID);
                    else
                        oDetail = srh_scsFlowStock.Select(dtmfromDate.AddDays(-1), "%", bIsShowDeactivated ? "%" : "0", sCompanyBranchID);

                    #region Detail report only
                    if (eRPTname == enum_ReportName.ST_Stocks_MovementReport || eRPTname == enum_ReportName.ST_Stocks_MovementReport_Detail || eRPTname == enum_ReportName.ST_Stocks_TrackingReport_Qty || eRPTname == enum_ReportName.ST_Stocks_TrackingReport_Weight || eRPTname == enum_ReportName.ST_Items_Card || eRPTname == enum_ReportName.ST_Stock_Statement)
                    {
                        sDaterange = clsFormatter.FormatDate_Short(dtmfromDate.Date) + " To " + clsFormatter.FormatDate_Short(dtmToDate.Date);

                        if (eRPTname == enum_ReportName.ST_Stocks_TrackingReport_Qty)
                            iRptType = 1;


                        #region filter - Item

                        string sItem_ID_ForDetail = "%%";
                        string sStore_ID_ForDetail = "%%";
                        if (bItemName_Selected)
                        {
                            sItem_ID_ForDetail = txtItemName.Tag.ToString().Trim();
                        }
                        #endregion

                        #region Filter - Store
                        if (bStore_Selected)
                        {
                            sStore_ID_ForDetail = txtStore.Tag.ToString().Trim();
                        }
                        #endregion

                        foreach (srh_scsFlowStock_detail oStocktxn in srh_scsFlowStock_detail.Select(dtmfromDate.AddDays(-1), dtmToDate, sCompanyBranchID, sItem_ID_ForDetail, sStore_ID_ForDetail))
                        {
                            //oStocktxn.NoteType;

                            #region Filter - Catagory
                            if (bItemCategory_Selected)
                            {
                                if (txtItemCategory.Tag.ToString().Trim() != oStocktxn.ItemCategory_ID)
                                    continue;
                            }
                            #endregion

                            #region Filter - Type
                            if (bItemType_Selected)
                            {
                                if (!lstItemType.Contains(oStocktxn.ItemType_ID))
                                    continue;
                            }
                            #endregion

                            glb_dtsStock.dt_scsFloorStock.Adddt_scsFloorStockRow(oStocktxn.Store_ID, oStocktxn.Item_ID, oStocktxn.ItemName, oStocktxn.Brand_ID, oStocktxn.ItemSerialNo, oStocktxn.ItemType_ID, oStocktxn.ItemCategory_ID, "-", oStocktxn.Uom, oStocktxn.Weight_issued, oStocktxn.Weight_received, oStocktxn.Qty_issued, oStocktxn.Qty_received, dCostPriceValue, 0, oStocktxn.TxnID, oStocktxn.TxnDate, oStocktxn.Remarks, oStocktxn.CreateUser_ID, oStocktxn.IsWeightCalculation, oStocktxn.NoteType);

                            #region Transaction Validation
                            if (bTransactionValidateEnable)
                            {
                                if (!sItemList.Contains(oStocktxn.Item_ID))
                                    sItemList.Add(oStocktxn.Item_ID);
                            }
                            #endregion
                        }
                    }
                    #endregion

                    #region Openning Balance
                    foreach (var oStock in oDetail.GroupBy(cm => new { cm.Item_ID, cm.ItemName, cm.Brand_ID, cm.Store_ID, cm.ItemCategory_ID, cm.ItemCategorySub_ID, cm.ItemSubCategory2_ID, cm.ItemSerialNo, cm.ItemSerialNo2, cm.ItemType_ID, cm.Uom, cm.IsWeightCalculation }, (key, group) => new { itemId = key.Item_ID, itemName = key.ItemName, brandId = key.Brand_ID, storeID = key.Store_ID, itemCatID = key.ItemCategory_ID, itemSubcat1 = key.ItemCategorySub_ID, itemSubcat2 = key.ItemSubCategory2_ID, itemSerialNo1 = key.ItemSerialNo, itemSerialNo2 = key.ItemSerialNo2, typeId = key.ItemType_ID, uom = key.Uom, qty = group.Sum(p => p.Qty), waight = group.Sum(p => p.Weight), isWaight = key.IsWeightCalculation }).ToList())
                    {
                        clsHelpMethods_Local.startProgressBar(0, oDetail.Count + 1, 1, pb1);
                        dCostPriceValue = 0;

                        if (!bShowAllItems)
                        {
                            if (oStock.waight == 0 && oStock.qty == 0)
                                continue;
                        }

                        #region Transaction Validation
                        if (bTransactionValidateEnable)
                        {
                            if (!sItemList.Contains(oStock.itemId))
                                continue;
                        }
                        #endregion

                        #region filter - Item
                        if (bItemName_Selected)
                        {
                            if (txtItemName.Tag.ToString().Trim() != oStock.itemId)
                                continue;
                        }
                        #endregion

                        #region Filter - Store
                        if (bStore_Selected)
                        {
                            if (txtStore.Tag.ToString().Trim() != oStock.storeID)
                                continue;
                        }
                        #endregion

                        #region Filter - Catagory
                        if (bItemCategory_Selected)
                        {
                            if (txtItemCategory.Tag.ToString().Trim() != oStock.itemCatID)
                                continue;
                        }
                        #endregion

                        #region Filter - Type
                        if (bItemType_Selected)
                        {
                            if (!lstItemType.Contains(oStock.typeId))
                                continue;
                        }
                        #endregion

                        if (eRPTname != enum_ReportName.ST_FloorStockReport)
                            dCostPriceValue = clsProcessMethods.GetCostPrice_ByCostType(oStock.itemId, enCostType);

                        glb_dtsStock.dt_scsFloorStock.Adddt_scsFloorStockRow(oStock.storeID, oStock.itemId, oStock.itemName, oStock.brandId, "-", oStock.typeId, oStock.itemCatID, oStock.itemSerialNo1, oStock.uom, 0, oStock.waight, 0, clsFormatter.RoundDecimalPlaces_Quantity(oStock.qty), clsFormatter.RoundDecimalPlaces_UnitPrice(dCostPriceValue), 0, "-", dtmfromDate.AddDays(-1), "Opening Balance", "-", oStock.isWaight, 0);
                    }
                    #endregion

                    glb_dtsStock.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Filter", sFilter, true);

                    frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                    //if (eRPTname == enum_ReportName.ST_FloorStockReport)
                    //    rpt.print(sReportPath, glb_dtsStock, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(eRPTname));
                    //else
                    print(sReportPath, glb_dtsStock);

                    pb1.Value = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    glb_dtsStock.Clear();
                }
            }
            //}
        }

        private void print(string path, DataSet ojbDataSet)
        {
            try
            {
                string s_Path = "", sReportFilter = "";
                ReportDocument objRpt = new ReportDocument();

        
            //    s_Path += path;
                s_Path = Application.StartupPath.Replace("\\Mini ERP\\bin\\Debug", "\\ZION.ERP.Reports");
                s_Path += path;
                objRpt.Load(s_Path);
                objRpt.SetDataSource(ojbDataSet); //(glbDtsBills);

                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sRptName);
                objRpt.DataDefinition.FormulaFields["ReportTitle2"].Text = clsCommon.fncsetstring(sRptName2);

                objRpt.DataDefinition.FormulaFields["ToDate"].Text = clsCommon.fncsetstring(sDaterange == "" ? "As At " + dtmToDate.Date.ToString("dd-MMM-yyyy") : sDaterange);
                objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);

                objRpt.DataDefinition.FormulaFields["ReportType"].Text = clsCommon.fncsetstring(iRptType.ToString());
                objRpt.DataDefinition.FormulaFields["isSummaryReport"].Text = clsCommon.fncsetstring(bIsSummaryReport ? "1" : "0");

                objRpt.SetParameterValue("NoOfDecimalPlaces", clsConfig.sDecimalPlaces_Quantity);

                string sLCostByValue = "";

                if (enCostType == enum_CostPriceType.WeightedAverage)
                    sLCostByValue = "Weighted Average";
                if (enCostType == enum_CostPriceType.LIFO)
                    sLCostByValue = "LIFO";
                if (enCostType == enum_CostPriceType.FIFO)
                    sLCostByValue = "FIFO";
                if (enCostType == enum_CostPriceType.HighestPurchaseCost)
                    sLCostByValue = "Highest Purchase Cost";
                if (enCostType == enum_CostPriceType.LovestPurchaseCost)
                    sLCostByValue = "Lovest Purchase Cost";
                if (enCostType == enum_CostPriceType.CostPrice1)
                    sLCostByValue = "Cost Price 1";
                if (enCostType == enum_CostPriceType.CostPrice2)
                    sLCostByValue = "Cost Price 2";

                objRpt.DataDefinition.FormulaFields["CostType"].Text = clsCommon.fncsetstring(sLCostByValue);

                if (bStore_Selected)
                    sReportFilter += "  Item Store : " + txtStore.Text;
                if (bItemName_Selected)
                    sReportFilter += "  Item : " + txtItemName.Text;
                if (bItemCategory_Selected)
                    sReportFilter += "  Item Category : " + txtItemCategory.Text;
                if (bItemType_Selected)
                {
                    sReportFilter += "  Item type : ";
                    foreach (string sItemType in lstItemType)
                    {
                        sReportFilter += clsGenaralName.getName_ItemType(sItemType) + ",";
                    }
                }

                if (sReportFilter == "")
                    sReportFilter = "-";

                objRpt.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sReportFilter);

                frm_ReportViewer ReportViewer = new frm_ReportViewer();
                ReportViewer.crystalReportViewer1.ReportSource = objRpt;
                ReportViewer.crystalReportViewer1.Refresh();
                ReportViewer.crystalReportViewer1.DisplayToolbar = true;
                ReportViewer.crystalReportViewer1.CloseView(false);
                ReportViewer.WindowState = FormWindowState.Maximized;
                ReportViewer.ShowDialog();

                objRpt.Close();
                objRpt.Dispose();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", -1, ex);
                SEACCException.Show(ex);
            }
            finally
            {
            }
        }
    }

    class ItemTracking
    {
        public string sItemCode = "";
        public string sSubCatergoryID = "";
        public int iQty = 0;
    }

    static class ItemInfo
    {
        public static string sBrandtxt, sItemId, sSub1, sSub2, sSerial1, sSerial2;
        public static decimal dQty = 0, dWeight = 0;
        public static DateTime dtDateVal, dtLastCreateDate;

        public static decimal dQtyBalance;
        public static decimal dWeightBalance;

        public static void setQtySign(bool IsReceved)
        {
            dQtyBalance = dQty;
            dWeightBalance = dWeight;
            if (!IsReceved)
            {
                dQtyBalance *= -1;
                dWeightBalance *= -1;
            }
        }
    }

    class ItmTracking
    {
        public string sItem_ID = "";
        public string sCostCenter = "";
        public string sNoteType = "";
        public decimal dQty = 0;

        public ItmTracking(string Item_ID, string costCenter, String NoteType, decimal qty)
        {
            sItem_ID = Item_ID;
            sCostCenter = costCenter;
            sNoteType = NoteType;
            dQty = qty;
        }
    }
}

#region old report STOCKS TRACKING REPORT - QTY
//if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Stocks_TrackingReport_Qty)))
//{
//    if (txtStore.Text.Trim() == "<All Stores>")
//        txtStore.Text = "";

//    else if (txtItemName.Text.Trim() == "<All Items>")
//        txtItemName.Text = "";

//    if (CheckValidity())
//    {
//        try
//        {
//            bool bIsWaightCalculation = false;
//            string sItemCode = txtItemName.Tag.ToString();
//            string sStoreCode = txtStore.Tag.ToString();
//            string sItemCategory = "default";

//            if (txtItemCategory.Tag != null)
//                sItemCategory = txtItemCategory.Tag.ToString();

//            glbDtsStock.dt_scsStockTracking.Clear();
//            Cursor = Cursors.WaitCursor;
//            List<ItemTracking> sItemTracking = new List<ItemTracking>();

//            decimal dQtyBalane = 0, dWeightBalane = 0;
//            DateTime firstDateOfTheMonth = clsSecurity.FirstDayOfMonthFromDateTime(dtpFrom.Value.Date);
//            string sFDate = clsFormatter.FormatDate_Short(firstDateOfTheMonth);
//            tbl_scsWeeklyStockTake oWeeklyStockTake = tbl_scsWeeklyStockTake.Select(sFDate);
//            bool bIsDamagedStore = false;

//            tbl_genStoreMaster oStore = tbl_genStoreMaster.Select(sStoreCode);
//            if (oStore != null && oStore.Store_ID != "default")
//            {
//                if (oStore.IsDamagedStore)
//                    bIsDamagedStore = true;
//            }

//            #region Old Way - Using Data Tables
//            #region Month Opening Balance DO
//            ItemInfo.dQty = 0;
//            ItemInfo.dWeight = 0;
//            //int iDoCount = 0;
//            int recCount = 0;


//            foreach (tbl_sasDeliveryOrder oDO in tbl_sasDeliveryOrder.SelectAll().Where(p => !p.IsDeleted && p.DeliveryOrder_ID != "default" && p.DateCreate.Date >= firstDateOfTheMonth && p.DateCreate.Date < dtpFrom.Value.Date && p.Store_ID == sStoreCode))
//            {
//                foreach (tbl_sasDeliveryOrder_Detail oDODetails in tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(oDO.DeliveryOrder_ID).Where(p => p.Item_ID == sItemCode))
//                {
//                    glb_dtItemTracking.Rows.Add(oDODetails.Item_ID, oDODetails.ItemSubCategory_ID, oDODetails.Qty);

//                    ItemInfo.sBrandtxt = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oDODetails.ItemSubCategory_ID));
//                    ItemInfo.sItemId = oDODetails.Item_ID;
//                    ItemInfo.sSub1 = oDODetails.ItemSubCategory_ID;
//                    ItemInfo.sSub2 = oDODetails.ItemSubCategory2_ID;
//                    ItemInfo.sSerial1 = oDODetails.ItemSerialNo;
//                    ItemInfo.sSerial2 = oDODetails.ItemSerialNo2;
//                    ItemInfo.dQty += oDODetails.Qty;
//                    ItemInfo.dWeight += oDODetails.Weight;
//                    ItemInfo.dtDateVal = oDO.DeliveryOrderDate;
//                    ItemInfo.dtLastCreateDate = oDO.DateCreate;
//                }
//                //iDoCount = oDO.PrintCount;
//                //clsHelpMethods.startProgressBar(0, iDoCount + 2, 1, ProgressBar);
//                //ProgressBar.Value = 0;
//            }
//            recCount = recCount + 1;
//            if (ItemInfo.dQty != 0 || ItemInfo.dWeight != 0)
//            {
//                ItemInfo.setQtySign(false);
//                dQtyBalane += ItemInfo.dQtyBalance;
//                dWeightBalane += ItemInfo.dWeightBalance;

//                //glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow("-", ItemInfo.dtDateVal, ItemInfo.sItemId, ItemInfo.sSub1, ItemInfo.sSub2, ItemInfo.sSerial1,
//                //   ItemInfo.sSerial2, "Sales Return Note Opening Balance", "-", ItemInfo.dtLastCreateDate, "-", ItemInfo.dQty, ItemInfo.dWeight, true,
//                //   clsGenaralName.getName_Store(sStoreCode), clsGenaralName.getName_Item(ItemInfo.sItemId), ItemInfo.sBrandtxt);
//            }
//            #endregion

//            #region Month Opening Balance SRN
//            ItemInfo.dQty = 0;
//            ItemInfo.dWeight = 0;
//            foreach (tbl_sasSalesReturnedNote oSRN in tbl_sasSalesReturnedNote.SelectAll().Where(p => !p.IsDeleted && p.SalesReturnedNote_ID != "default" && p.DateCreate.Date >= firstDateOfTheMonth && p.DateCreate.Date < dtpFrom.Value.Date && p.Store_ID == sStoreCode))
//            {
//                foreach (tbl_sasSalesReturnedNote_Detail oSRNDetails in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSRN.SalesReturnedNote_ID).Where(p => p.Item_ID == sItemCode))
//                {
//                    glb_dtItemTracking.Rows.Add(oSRNDetails.Item_ID, oSRNDetails.ItemSubCategory_ID, oSRNDetails.Qty);

//                    ItemInfo.sBrandtxt = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oSRNDetails.ItemSubCategory_ID));
//                    ItemInfo.sItemId = oSRNDetails.Item_ID;
//                    ItemInfo.sSub1 = oSRNDetails.ItemSubCategory_ID;
//                    ItemInfo.sSub2 = oSRNDetails.ItemSubCategory2_ID;
//                    ItemInfo.sSerial1 = oSRNDetails.ItemSerialNo;
//                    ItemInfo.sSerial2 = oSRNDetails.ItemSerialNo2;
//                    ItemInfo.dQty += oSRNDetails.Qty;
//                    ItemInfo.dWeight += oSRNDetails.Weight;
//                    ItemInfo.dtDateVal = oSRN.SalesReturnedNoteDate;
//                    ItemInfo.dtLastCreateDate = oSRN.DateCreate;
//                }
//            }
//            recCount = recCount + 1;
//            if (ItemInfo.dQty != 0 || ItemInfo.dWeight != 0)
//            {
//                ItemInfo.setQtySign(true);
//                dQtyBalane += ItemInfo.dQtyBalance;
//                dWeightBalane += ItemInfo.dWeightBalance;

//                //glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow("-", ItemInfo.dtDateVal, ItemInfo.sItemId, ItemInfo.sSub1, ItemInfo.sSub2, ItemInfo.sSerial1,
//                //    ItemInfo.sSerial2, "Sales Return Note Opening Balance", "-", ItemInfo.dtLastCreateDate, "-", ItemInfo.dQty, ItemInfo.dWeight, true,
//                //    clsGenaralName.getName_Store(sStoreCode), clsGenaralName.getName_Item(ItemInfo.sItemId), ItemInfo.sBrandtxt);
//            }
//            #endregion

//            #region Month Opening Balance GRN
//            ItemInfo.dQty = 0;
//            ItemInfo.dWeight = 0;
//            foreach (tbl_scsExternalGoodReceivedNote oGRN in tbl_scsExternalGoodReceivedNote.SelectAll().Where(p => !p.IsDeleted && p.ExternalGoodReceivedNote_ID != "default" && p.DateCreate.Date >= firstDateOfTheMonth && p.DateCreate.Date < dtpFrom.Value.Date && p.Store_ID == sStoreCode))
//            {
//                foreach (tbl_scsExternalGoodReceivedNote_Detail oGRNDetails in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(oGRN.ExternalGoodReceivedNote_ID).Where(p => p.Item_ID == sItemCode))
//                {
//                    glb_dtItemTracking.Rows.Add(oGRNDetails.Item_ID, oGRNDetails.ItemSubCategory_ID, oGRNDetails.Qty);

//                    ItemInfo.sBrandtxt = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oGRNDetails.ItemSubCategory_ID));
//                    ItemInfo.sItemId = oGRNDetails.Item_ID;
//                    ItemInfo.sSub1 = oGRNDetails.ItemSubCategory_ID;
//                    ItemInfo.sSub2 = oGRNDetails.ItemSubCategory2_ID;
//                    ItemInfo.sSerial1 = oGRNDetails.ItemSerialNo;
//                    ItemInfo.sSerial2 = oGRNDetails.ItemSerialNo2;
//                    ItemInfo.dQty += oGRNDetails.Qty;
//                    ItemInfo.dWeight += oGRNDetails.Weight;
//                    ItemInfo.dtDateVal = oGRN.ExternalGoodReceivedNoteDate;
//                    ItemInfo.dtLastCreateDate = oGRN.DateCreate;
//                }
//            }
//            recCount = recCount + 1;
//            if (ItemInfo.dQty != 0 || ItemInfo.dWeight != 0)
//            {
//                ItemInfo.setQtySign(true);
//                dQtyBalane += ItemInfo.dQtyBalance;
//                dWeightBalane += ItemInfo.dWeightBalance;

//                //glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow("-", ItemInfo.dtDateVal, ItemInfo.sItemId, ItemInfo.sSub1, ItemInfo.sSub2, ItemInfo.sSerial1,
//                //    ItemInfo.sSerial2, "Good Received Note Opening Balance", "-", ItemInfo.dtLastCreateDate, "-", ItemInfo.dQty, ItemInfo.dWeight, true,
//                //    clsGenaralName.getName_Store(sStoreCode), clsGenaralName.getName_Item(ItemInfo.sItemId), ItemInfo.sBrandtxt);
//            }
//            #endregion

//            #region Month Opening Balance GIN
//            ItemInfo.dQty = 0;
//            ItemInfo.dWeight = 0;
//            foreach (tbl_scsExternalGoodIssueNote oGIN in tbl_scsExternalGoodIssueNote.SelectAll().Where(p => !p.IsDeleted && p.ExternalGoodIssueNote_ID != "default" && p.DateCreate.Date >= firstDateOfTheMonth && p.DateCreate.Date < dtpFrom.Value.Date && p.Store_ID == sStoreCode))
//            {
//                foreach (tbl_scsExternalGoodIssueNote_Detail oGINDetails in tbl_scsExternalGoodIssueNote_Detail.SelectAllByExternalGoodIssueNote_ID(oGIN.ExternalGoodIssueNote_ID).Where(p => p.Item_ID == sItemCode))
//                {
//                    glb_dtItemTracking.Rows.Add(oGINDetails.Item_ID, oGINDetails.ItemSubCategory_ID, oGINDetails.Qty);

//                    ItemInfo.sBrandtxt = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oGINDetails.ItemSubCategory_ID));
//                    ItemInfo.sItemId = oGINDetails.Item_ID;
//                    ItemInfo.sSub1 = oGINDetails.ItemSubCategory_ID;
//                    ItemInfo.sSub2 = oGINDetails.ItemSubCategory2_ID;
//                    ItemInfo.sSerial1 = oGINDetails.ItemSerialNo;
//                    ItemInfo.sSerial2 = oGINDetails.ItemSerialNo2;
//                    ItemInfo.dQty += oGINDetails.Qty;
//                    ItemInfo.dWeight += oGINDetails.Weight;
//                    ItemInfo.dtDateVal = oGIN.ExternalGoodIssueNoteDate;
//                    ItemInfo.dtLastCreateDate = oGIN.DateCreate;
//                }
//            }
//            recCount = recCount + 1;
//            if (ItemInfo.dQty != 0 || ItemInfo.dWeight != 0)
//            {
//                ItemInfo.setQtySign(false);
//                dQtyBalane += ItemInfo.dQtyBalance;
//                dWeightBalane += ItemInfo.dWeightBalance;
//            }
//            #endregion

//            #region Month Opening Balance iGRN
//            ItemInfo.dQty = 0;
//            ItemInfo.dWeight = 0;
//            foreach (tbl_scsStoreGoodReceiveNote oGRN in tbl_scsStoreGoodReceiveNote.SelectAll().Where(p => !p.IsDeleted && p.StoreGoodReceiveNote_ID != "default" && p.DateCreate.Date >= firstDateOfTheMonth && p.DateCreate.Date < dtpFrom.Value.Date && p.ToStore_ID == sStoreCode))
//            {
//                foreach (tbl_scsStoreGoodReceiveNote_Detail oGRNDetails in tbl_scsStoreGoodReceiveNote_Detail.SelectAllByStoreGoodReceiveNote_ID(oGRN.StoreGoodReceiveNote_ID).Where(p => p.Item_ID == sItemCode))
//                {
//                    glb_dtItemTracking.Rows.Add(oGRNDetails.Item_ID, oGRNDetails.ItemSubCategory_ID, oGRNDetails.Qty);

//                    ItemInfo.sBrandtxt = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oGRNDetails.ItemSubCategory_ID));
//                    ItemInfo.sItemId = oGRNDetails.Item_ID;
//                    ItemInfo.sSub1 = oGRNDetails.ItemSubCategory_ID;
//                    ItemInfo.sSub2 = oGRNDetails.ItemSubCategory2_ID;
//                    ItemInfo.sSerial1 = oGRNDetails.ItemSerialNo;
//                    ItemInfo.sSerial2 = oGRNDetails.ItemSerialNo2;
//                    ItemInfo.dQty += oGRNDetails.Qty;
//                    ItemInfo.dWeight += oGRNDetails.Weight;
//                    ItemInfo.dtDateVal = oGRN.StoreGoodReceiveNoteDate;
//                    ItemInfo.dtLastCreateDate = oGRN.DateCreate;
//                }
//            }
//            recCount = recCount + 1;
//            if (ItemInfo.dQty != 0 || ItemInfo.dWeight != 0)
//            {
//                ItemInfo.setQtySign(true);
//                dQtyBalane += ItemInfo.dQtyBalance;
//                dWeightBalane += ItemInfo.dWeightBalance;
//            }
//            #endregion

//            #region Month Opening Balance iGIN
//            ItemInfo.dQty = 0;
//            ItemInfo.dWeight = 0;
//            foreach (tbl_scsStoreGoodIssueNote oGIN in tbl_scsStoreGoodIssueNote.SelectAll().Where(p => !p.IsDeleted && p.StoreGoodIssueNote_ID != "default" && p.DateCreate.Date >= firstDateOfTheMonth && p.DateCreate.Date < dtpFrom.Value.Date && p.FromStore_ID == sStoreCode))
//            {
//                foreach (tbl_scsStoreGoodIssueNote_Detail oGINDetails in tbl_scsStoreGoodIssueNote_Detail.SelectAllByStoreGoodIssueNote_ID(oGIN.StoreGoodIssueNote_ID).Where(p => p.Item_ID == sItemCode))
//                {
//                    glb_dtItemTracking.Rows.Add(oGINDetails.Item_ID, oGINDetails.ItemSubCategory_ID, oGINDetails.Qty);

//                    ItemInfo.sBrandtxt = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oGINDetails.ItemSubCategory_ID));
//                    ItemInfo.sItemId = oGINDetails.Item_ID;
//                    ItemInfo.sSub1 = oGINDetails.ItemSubCategory_ID;
//                    ItemInfo.sSub2 = oGINDetails.ItemSubCategory2_ID;
//                    ItemInfo.sSerial1 = oGINDetails.ItemSerialNo;
//                    ItemInfo.sSerial2 = oGINDetails.ItemSerialNo2;
//                    ItemInfo.dQty += oGINDetails.Qty;
//                    ItemInfo.dWeight += oGINDetails.Weight;
//                    ItemInfo.dtDateVal = oGIN.StoreGoodIssueNoteDate;
//                    ItemInfo.dtLastCreateDate = oGIN.DateCreate;
//                }
//            }
//            recCount = recCount + 1;
//            if (ItemInfo.dQty != 0 || ItemInfo.dWeight != 0)
//            {
//                ItemInfo.setQtySign(false);
//                dQtyBalane += ItemInfo.dQtyBalance;
//                dWeightBalane += ItemInfo.dWeightBalance;
//            }
//            #endregion

//            #region Month Opening Balance DGN
//            //ItemInfo.dQty = 0;
//            //ItemInfo.dWeight = 0;
//            //foreach (tbl_scsDamagedGoodNote oDGN in tbl_scsDamagedGoodNote.SelectAll().Where(p => !p.IsDeleted && p.DamagedGoodNote_ID != "default" && p.DateCreate.Date >= firstDateOfTheMonth && p.DateCreate.Date < dtpFrom.Value.Date && p.Store_ID == sStoreCode))
//            //{
//            //    foreach (tbl_scsDamagedGoodNote_Detail oDGNDetails in tbl_scsDamagedGoodNote_Detail.SelectAllByDamagedGoodNote_ID(oDGN.DamagedGoodNote_ID).Where(p => p.Item_ID == sItemCode))
//            //    {
//            //        glb_dtItemTracking.Rows.Add(oDGNDetails.Item_ID, oDGNDetails.ItemSubCategory_ID, oDGNDetails.Qty);

//            //        ItemInfo.sBrandtxt = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oDGNDetails.ItemSubCategory_ID));
//            //        ItemInfo.sItemId = oDGNDetails.Item_ID;
//            //        ItemInfo.sSub1 = oDGNDetails.ItemSubCategory_ID;
//            //        ItemInfo.sSub2 = oDGNDetails.ItemSubCategory2_ID;
//            //        ItemInfo.sSerial1 = oDGNDetails.ItemSerialNo;
//            //        ItemInfo.sSerial2 = oDGNDetails.ItemSerialNo2;
//            //        ItemInfo.dQty += oDGNDetails.Qty;
//            //        ItemInfo.dWeight += oDGNDetails.Weight;
//            //        ItemInfo.dtDateVal = oDGN.DamagedGoodNoteDate;
//            //        ItemInfo.dtLastCreateDate = oDGN.DateCreate;
//            //    }
//            //}
//            //recCount = recCount + 1;
//            //if (ItemInfo.dQty != 0 || ItemInfo.dWeight != 0)
//            //{
//            //    ItemInfo.setQtySign(false);
//            //    dQtyBalane += ItemInfo.dQtyBalance;
//            //    dWeightBalane += ItemInfo.dWeightBalance;
//            //}
//            #endregion

//            #region Month Opening Balance PRN
//            ItemInfo.dQty = 0;
//            ItemInfo.dWeight = 0;
//            foreach (tbl_scsPurchaseReturnedNote oPRN in tbl_scsPurchaseReturnedNote.SelectAll().Where(p => !p.IsDeleted && p.PurchaseReturnedNote_ID != "default" && p.DateCreate.Date >= firstDateOfTheMonth && p.DateCreate.Date < dtpFrom.Value.Date && p.Store_ID == sStoreCode))
//            {
//                foreach (tbl_scsPurchaseReturnedNote_Detail oPRNDetails in tbl_scsPurchaseReturnedNote_Detail.SelectAllByPurchaseReturnedNote_ID(oPRN.PurchaseReturnedNote_ID).Where(p => p.Item_ID == sItemCode))
//                {
//                    glb_dtItemTracking.Rows.Add(oPRNDetails.Item_ID, oPRNDetails.ItemSubCategory_ID, oPRNDetails.Qty);

//                    ItemInfo.sBrandtxt = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oPRNDetails.ItemSubCategory_ID));
//                    ItemInfo.sItemId = oPRNDetails.Item_ID;
//                    ItemInfo.sSub1 = oPRNDetails.ItemSubCategory_ID;
//                    ItemInfo.sSub2 = oPRNDetails.ItemSubCategory2_ID;
//                    ItemInfo.sSerial1 = oPRNDetails.ItemSerialNo;
//                    ItemInfo.sSerial2 = oPRNDetails.ItemSerialNo2;
//                    ItemInfo.dQty += oPRNDetails.Qty;
//                    ItemInfo.dWeight += oPRNDetails.Weight;
//                    ItemInfo.dtDateVal = oPRN.PurchaseReturnedNoteDate;
//                    ItemInfo.dtLastCreateDate = oPRN.DateCreate;
//                }
//            }
//            recCount = recCount + 1;
//            if (ItemInfo.dQty != 0 || ItemInfo.dWeight != 0)
//            {
//                ItemInfo.setQtySign(false);
//                dQtyBalane += ItemInfo.dQtyBalance;
//                dWeightBalane += ItemInfo.dWeightBalance;
//            }
//            #endregion

//            #region Month Opening Balance SAN
//            ItemInfo.dQty = 0;
//            ItemInfo.dWeight = 0;
//            foreach (tbl_scsStockAdjustment oSAN in tbl_scsStockAdjustment.SelectAll().Where(p => !p.IsDeleted && p.StockAdjustment_ID != "default" && p.DateCreate.Date >= firstDateOfTheMonth && p.DateCreate.Date < dtpFrom.Value.Date && p.Store_ID == sStoreCode))
//            {
//                foreach (tbl_scsStockAdjustment_Detail oSANDetails in tbl_scsStockAdjustment_Detail.SelectAllByStockAdjustment_ID(oSAN.StockAdjustment_ID).Where(p => p.Item_ID == sItemCode))
//                {
//                    glb_dtItemTracking.Rows.Add(oSANDetails.Item_ID, oSANDetails.ItemSubCategory_ID, oSANDetails.Qty);

//                    decimal dAdjestQty = oSANDetails.Qty - oSANDetails.OldQty;
//                    decimal dAdjestWeight = oSANDetails.Weight - oSANDetails.OldWeight;

//                    ItemInfo.sBrandtxt = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oSANDetails.ItemSubCategory_ID));
//                    ItemInfo.sItemId = oSANDetails.Item_ID;
//                    ItemInfo.sSub1 = oSANDetails.ItemSubCategory_ID;
//                    ItemInfo.sSub2 = oSANDetails.ItemSubCategory2_ID;
//                    ItemInfo.sSerial1 = oSANDetails.ItemSerialNo;
//                    ItemInfo.sSerial2 = oSANDetails.ItemSerialNo2;
//                    ItemInfo.dQty += dAdjestQty;
//                    ItemInfo.dWeight += dAdjestWeight;
//                    ItemInfo.dtDateVal = oSAN.StockAdjustmentDate;
//                    ItemInfo.dtLastCreateDate = oSAN.DateCreate;
//                }
//            }
//            recCount = recCount + 1;
//            if (ItemInfo.dQty != 0 || ItemInfo.dWeight != 0)
//            {
//                ItemInfo.setQtySign(true);
//                dQtyBalane += ItemInfo.dQtyBalance;
//                dWeightBalane += ItemInfo.dWeightBalance;

//                //glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow("-", ItemInfo.dtDateVal, ItemInfo.sItemId, ItemInfo.sSub1, ItemInfo.sSub2, ItemInfo.sSerial1,
//                //    ItemInfo.sSerial2, "Stock Adjustment Opening Balance", "-", ItemInfo.dtLastCreateDate, "-", ItemInfo.dQty, ItemInfo.dWeight, true,
//                //    clsGenaralName.getName_Store(sStoreCode), clsGenaralName.getName_Item(ItemInfo.sItemId), ItemInfo.sBrandtxt);
//            }
//            #endregion

//            #region Month Opening Balance SPLI From
//            ItemInfo.dQty = 0;
//            ItemInfo.dWeight = 0;
//            foreach (tbl_scsItemSpred oSPLI in tbl_scsItemSpred.SelectAll().Where(p => !p.IsDeleted && p.ItemSpred_ID != "default" && p.DateCreate.Date >= firstDateOfTheMonth && p.DateCreate.Date < dtpFrom.Value.Date && p.Store_ID == sStoreCode))
//            {
//                foreach (tbl_scsItemSpred_Detail_From oSPLIDetails in tbl_scsItemSpred_Detail_From.SelectAllByItemSpred_ID(oSPLI.ItemSpred_ID).Where(p => p.Item_ID == sItemCode))
//                {
//                    glb_dtItemTracking.Rows.Add(oSPLIDetails.Item_ID, oSPLIDetails.ItemSubCategory_ID, oSPLIDetails.Qty);

//                    ItemInfo.sBrandtxt = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oSPLIDetails.ItemSubCategory_ID));
//                    ItemInfo.sItemId = oSPLIDetails.Item_ID;
//                    ItemInfo.sSub1 = oSPLIDetails.ItemSubCategory_ID;
//                    ItemInfo.sSub2 = oSPLIDetails.ItemSubCategory2_ID;
//                    ItemInfo.sSerial1 = oSPLIDetails.ItemSerialNo;
//                    ItemInfo.sSerial2 = oSPLIDetails.ItemSerialNo2;
//                    ItemInfo.dQty += oSPLIDetails.Qty;
//                    ItemInfo.dWeight += oSPLIDetails.Weight;
//                    ItemInfo.dtDateVal = oSPLI.ItemSpredDate;
//                    ItemInfo.dtLastCreateDate = oSPLI.DateCreate;
//                }
//            }

//            recCount = recCount + 1;

//            if (ItemInfo.dQty != 0 || ItemInfo.dWeight != 0)
//            {
//                ItemInfo.setQtySign(false);
//                dQtyBalane += ItemInfo.dQtyBalance;
//                dWeightBalane += ItemInfo.dWeightBalance;

//                //glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow("-", ItemInfo.dtDateVal, ItemInfo.sItemId, ItemInfo.sSub1, ItemInfo.sSub2, ItemInfo.sSerial1,
//                //    ItemInfo.sSerial2, "Stock Adjustment Opening Balance", "-", ItemInfo.dtLastCreateDate, "-", ItemInfo.dQty, ItemInfo.dWeight, true,
//                //    clsGenaralName.getName_Store(sStoreCode), clsGenaralName.getName_Item(ItemInfo.sItemId), ItemInfo.sBrandtxt);
//            }
//            #endregion

//            #region Month Opening Balance SPLI To
//            ItemInfo.dQty = 0;
//            ItemInfo.dWeight = 0;
//            foreach (tbl_scsItemSpred oSPLI in tbl_scsItemSpred.SelectAll().Where(p => !p.IsDeleted && p.ItemSpred_ID != "default" && p.DateCreate.Date >= firstDateOfTheMonth && p.DateCreate.Date < dtpFrom.Value.Date && p.Store_ID == sStoreCode))
//            {
//                foreach (tbl_scsItemSpred_Detail_To oSPLIDetails in tbl_scsItemSpred_Detail_To.SelectAllByItemSpred_ID(oSPLI.ItemSpred_ID).Where(p => p.Item_ID == sItemCode))
//                {
//                    glb_dtItemTracking.Rows.Add(oSPLIDetails.Item_ID, oSPLIDetails.ItemSubCategory_ID, oSPLIDetails.Qty);

//                    ItemInfo.sBrandtxt = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oSPLIDetails.ItemSubCategory_ID));
//                    ItemInfo.sItemId = oSPLIDetails.Item_ID;
//                    ItemInfo.sSub1 = oSPLIDetails.ItemSubCategory_ID;
//                    ItemInfo.sSub2 = oSPLIDetails.ItemSubCategory2_ID;
//                    ItemInfo.sSerial1 = oSPLIDetails.ItemSerialNo;
//                    ItemInfo.sSerial2 = oSPLIDetails.ItemSerialNo2;
//                    ItemInfo.dQty += oSPLIDetails.Qty;
//                    ItemInfo.dWeight += oSPLIDetails.Weight;
//                    ItemInfo.dtDateVal = oSPLI.ItemSpredDate;
//                    ItemInfo.dtLastCreateDate = oSPLI.DateCreate;
//                }
//            }

//            recCount = recCount + 1;

//            if (ItemInfo.dQty != 0 || ItemInfo.dWeight != 0)
//            {
//                ItemInfo.setQtySign(true);
//                dQtyBalane += ItemInfo.dQtyBalance;
//                dWeightBalane += ItemInfo.dWeightBalance;

//                //glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow("-", ItemInfo.dtDateVal, ItemInfo.sItemId, ItemInfo.sSub1, ItemInfo.sSub2, ItemInfo.sSerial1,
//                //    ItemInfo.sSerial2, "Stock Adjustment Opening Balance", "-", ItemInfo.dtLastCreateDate, "-", ItemInfo.dQty, ItemInfo.dWeight, true,
//                //    clsGenaralName.getName_Store(sStoreCode), clsGenaralName.getName_Item(ItemInfo.sItemId), ItemInfo.sBrandtxt);
//            }
//            #endregion


//            #region Month Opening Balance Damage Goods
//            List<tbl_scsDamagedGoodNote> oOpenningDG;

//            if (bIsDamagedStore)
//                oOpenningDG = tbl_scsDamagedGoodNote.SelectAll().Where(p => !p.IsDeleted && p.DamagedGoodNote_ID != "default" && p.DateCreate.Date >= firstDateOfTheMonth && p.DateCreate.Date <= dtpFrom.Value.Date).ToList();
//            else
//                oOpenningDG = tbl_scsDamagedGoodNote.SelectAll().Where(p => !p.IsDeleted && p.DamagedGoodNote_ID != "default" && p.DateCreate.Date >= firstDateOfTheMonth && p.DateCreate.Date <= dtpFrom.Value.Date && p.Store_ID == sStoreCode).ToList();

//            foreach (tbl_scsDamagedGoodNote oDamegGood in oOpenningDG)
//            {
//                foreach (tbl_scsDamagedGoodNote_Detail oDGDetails in tbl_scsDamagedGoodNote_Detail.SelectAllByDamagedGoodNote_ID(oDamegGood.DamagedGoodNote_ID).Where(p => p.Item_ID == sItemCode))
//                {

//                    glb_dtItemTracking.Rows.Add(oDGDetails.Item_ID, oDGDetails.ItemSubCategory_ID, oDGDetails.Qty);

//                    ItemInfo.sBrandtxt = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oDGDetails.ItemSubCategory_ID));
//                    ItemInfo.sItemId = oDGDetails.Item_ID;
//                    ItemInfo.sSub1 = oDGDetails.ItemSubCategory_ID;
//                    ItemInfo.sSub2 = oDGDetails.ItemSubCategory2_ID;
//                    ItemInfo.sSerial1 = oDGDetails.ItemSerialNo;
//                    ItemInfo.sSerial2 = oDGDetails.ItemSerialNo2;
//                    ItemInfo.dQty += oDGDetails.Qty;
//                    ItemInfo.dWeight += oDGDetails.Weight;
//                    ItemInfo.dtDateVal = oDamegGood.DamagedGoodNoteDate;
//                    ItemInfo.dtLastCreateDate = oDamegGood.DateCreate;
//                }
//            }

//            recCount = recCount + 1;
//            if ((ItemInfo.dQty != 0 || ItemInfo.dWeight != 0) && bIsDamagedStore)
//            {
//                ItemInfo.setQtySign(false);
//                dQtyBalane += ItemInfo.dQtyBalance;
//                dWeightBalane += ItemInfo.dWeightBalance;
//            }
//            #endregion

//            #region Month Opening Balance tbl_scsWeeklyStockTake
//            if (oWeeklyStockTake != null)
//            {
//                bool isHasRecord = false;
//                foreach (tbl_scsWeeklyStockTake_Detail oWeeklyStockTakeDetails in tbl_scsWeeklyStockTake_Detail.SelectAllByWeeklyStockTake_ID(oWeeklyStockTake.WeeklyStockTake_ID).Where(p => p.Item_ID == sItemCode && p.Store_ID == sStoreCode))
//                {
//                    isHasRecord = true;
//                    ItemTracking itemTrack = new ItemTracking();
//                    itemTrack.sItemCode = oWeeklyStockTakeDetails.Item_ID;
//                    itemTrack.sSubCatergoryID = oWeeklyStockTakeDetails.ItemSubCategory_ID;
//                    itemTrack.iQty = Convert.ToInt32(oWeeklyStockTakeDetails.Qty);
//                    sItemTracking.Add(itemTrack);

//                    string sBrand = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oWeeklyStockTakeDetails.ItemSubCategory_ID));
//                    glb_dtItemTracking.Rows.Add(oWeeklyStockTakeDetails.Item_ID, oWeeklyStockTakeDetails.ItemSubCategory_ID, oWeeklyStockTakeDetails.Qty);

//                    glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow("-", oWeeklyStockTake.WeeklyStockTakeDate, oWeeklyStockTakeDetails.Item_ID, oWeeklyStockTakeDetails.ItemSubCategory_ID,
//                        oWeeklyStockTakeDetails.ItemSubCategory2_ID, oWeeklyStockTakeDetails.ItemSerialNo, oWeeklyStockTakeDetails.ItemSerialNo2, "Opening Balance", "-", clsSecurity.getServerDateTime(), "Opening Balance", oWeeklyStockTakeDetails.Qty + dQtyBalane,
//                        oWeeklyStockTakeDetails.Weight + dWeightBalane, true, clsGenaralName.getName_Store(oWeeklyStockTakeDetails.Store_ID), clsGenaralName.getName_Item(oWeeklyStockTakeDetails.Item_ID), sBrand);
//                }

//                recCount = recCount + 1;

//                if (!isHasRecord && ItemInfo.sItemId != null)
//                {
//                    //glb_dtItemTracking.Rows.Add(ItemInfo.sItemId, ItemInfo.sSub1, dQtyBalane);
//                    glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow("-", dtpFrom.Value.Date, ItemInfo.sItemId, ItemInfo.sSub1, ItemInfo.sSub2, ItemInfo.sSerial1,
//                        ItemInfo.sSerial2, "Opening Balance", "-", dtpFrom.Value.Date, "Opening Balance", dQtyBalane, dWeightBalane, true,
//                        clsGenaralName.getName_Store(sStoreCode), clsGenaralName.getName_Item(ItemInfo.sItemId), ItemInfo.sBrandtxt);
//                }
//            }
//            #endregion


//            #region DO Transaction
//            foreach (tbl_sasDeliveryOrder oDO in tbl_sasDeliveryOrder.SelectAll().Where(p => p.DeliveryOrder_ID != "default" && p.DateCreate.Date >= dtpFrom.Value.Date && p.DateCreate.Date <= dtpTo.Value.Date && p.Store_ID == sStoreCode))
//            {
//                foreach (tbl_sasDeliveryOrder_Detail oDODetails in tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(oDO.DeliveryOrder_ID).Where(p => p.Item_ID == sItemCode))
//                {
//                    string sBrand = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oDODetails.ItemSubCategory_ID));
//                    glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oDO.DeliveryOrder_ID, oDO.DeliveryOrderDate, oDODetails.Item_ID, oDODetails.ItemSubCategory_ID, oDODetails.ItemSubCategory2_ID, oDODetails.ItemSerialNo,
//                        oDODetails.ItemSerialNo2, "Delivery Order", oDO.CreateUser_ID, oDO.DateCreate, oDO.ApprovedUser_ID, oDODetails.Qty, oDODetails.Weight, false,
//                        clsGenaralName.getName_Store(oDO.Store_ID), clsGenaralName.getName_Item(oDODetails.Item_ID), sBrand);
//                    if (oDO.IsDeleted)
//                    {
//                        glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oDO.DeliveryOrder_ID, oDO.DeliveryOrderDate, oDODetails.Item_ID, oDODetails.ItemSubCategory_ID, oDODetails.ItemSubCategory2_ID, oDODetails.ItemSerialNo,
//                            oDODetails.ItemSerialNo2, "Delivery Order Cancel", oDO.ModifiedUser_ID, oDO.DateModified, oDO.ApprovedUser_ID, oDODetails.Qty, oDODetails.Weight, true,
//                            clsGenaralName.getName_Store(oDO.Store_ID), clsGenaralName.getName_Item(oDODetails.Item_ID), sBrand);
//                    }
//                }
//            }

//            recCount = recCount + 1;

//            #endregion

//            #region SRN Transaction
//            foreach (tbl_sasSalesReturnedNote oSRN in tbl_sasSalesReturnedNote.SelectAll().Where(p => p.SalesReturnedNote_ID != "default" && p.DateCreate.Date >= dtpFrom.Value.Date && p.DateCreate.Date <= dtpTo.Value.Date && p.Store_ID == sStoreCode))
//            {
//                foreach (tbl_sasSalesReturnedNote_Detail oSRNDetails in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSRN.SalesReturnedNote_ID).Where(p => p.Item_ID == sItemCode))
//                {
//                    string sBrand = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oSRNDetails.ItemSubCategory_ID));
//                    glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oSRN.SalesReturnedNote_ID, oSRN.SalesReturnedNoteDate, oSRNDetails.Item_ID, oSRNDetails.ItemSubCategory_ID, oSRNDetails.ItemSubCategory2_ID, oSRNDetails.ItemSerialNo,
//                        oSRNDetails.ItemSerialNo2, "Sales Return Note", oSRN.CreateUser_ID, oSRN.DateCreate, oSRN.ApprovedUser_ID, oSRNDetails.Qty, oSRNDetails.Weight, true,
//                        clsGenaralName.getName_Store(oSRN.Store_ID), clsGenaralName.getName_Item(oSRNDetails.Item_ID), sBrand);
//                    if (oSRN.IsDeleted)
//                    {
//                        glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oSRN.SalesReturnedNote_ID, oSRN.SalesReturnedNoteDate, oSRNDetails.Item_ID, oSRNDetails.ItemSubCategory_ID, oSRNDetails.ItemSubCategory2_ID, oSRNDetails.ItemSerialNo,
//                            oSRNDetails.ItemSerialNo2, "Sales Return Note Cancel", oSRN.ModifiedUser_ID, oSRN.DateModified, oSRN.ApprovedUser_ID, oSRNDetails.Qty, oSRNDetails.Weight, false,
//                            clsGenaralName.getName_Store(oSRN.Store_ID), clsGenaralName.getName_Item(oSRNDetails.Item_ID), sBrand);
//                    }
//                }
//            }

//            recCount = recCount + 1;

//            #endregion

//            #region GRN Transaction
//            foreach (tbl_scsExternalGoodReceivedNote oGRN in tbl_scsExternalGoodReceivedNote.SelectAll().Where(p => p.ExternalGoodReceivedNote_ID != "default" && p.DateCreate.Date >= dtpFrom.Value.Date && p.DateCreate.Date <= dtpTo.Value.Date && p.Store_ID == sStoreCode))
//            {
//                foreach (tbl_scsExternalGoodReceivedNote_Detail oGRNDetails in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(oGRN.ExternalGoodReceivedNote_ID).Where(p => p.Item_ID == sItemCode))
//                {
//                    string sBrand = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oGRNDetails.ItemSubCategory_ID));
//                    glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oGRN.ExternalGoodReceivedNote_ID, oGRN.ExternalGoodReceivedNoteDate, oGRNDetails.Item_ID, oGRNDetails.ItemSubCategory_ID, oGRNDetails.ItemSubCategory2_ID, oGRNDetails.ItemSerialNo,
//                        oGRNDetails.ItemSerialNo2, "Good Received Note", oGRN.CreateUser_ID, oGRN.DateCreate, oGRN.ApprovedUser_ID, oGRNDetails.Qty, oGRNDetails.Weight, true,
//                        clsGenaralName.getName_Store(oGRN.Store_ID), clsGenaralName.getName_Item(oGRNDetails.Item_ID), sBrand);
//                    if (oGRN.IsDeleted)
//                    {
//                        glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oGRN.ExternalGoodReceivedNote_ID, oGRN.ExternalGoodReceivedNoteDate, oGRNDetails.Item_ID, oGRNDetails.ItemSubCategory_ID, oGRNDetails.ItemSubCategory2_ID, oGRNDetails.ItemSerialNo,
//                            oGRNDetails.ItemSerialNo2, "Good Received Note Cancel", oGRN.ModifiedUser_ID, oGRN.DateModified, oGRN.ApprovedUser_ID, oGRNDetails.Qty, oGRNDetails.Weight, false,
//                            clsGenaralName.getName_Store(oGRN.Store_ID), clsGenaralName.getName_Item(oGRNDetails.Item_ID), sBrand);
//                    }
//                }
//            }

//            recCount = recCount + 1;

//            #endregion

//            #region GIN Transaction
//            foreach (tbl_scsExternalGoodIssueNote oGIN in tbl_scsExternalGoodIssueNote.SelectAll().Where(p => p.ExternalGoodIssueNote_ID != "default" && p.DateCreate.Date >= dtpFrom.Value.Date && p.DateCreate.Date <= dtpTo.Value.Date && p.Store_ID == sStoreCode))
//            {
//                foreach (tbl_scsExternalGoodIssueNote_Detail oGINDetails in tbl_scsExternalGoodIssueNote_Detail.SelectAllByExternalGoodIssueNote_ID(oGIN.ExternalGoodIssueNote_ID).Where(p => p.Item_ID == sItemCode))
//                {
//                    string sBrand = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oGINDetails.ItemSubCategory_ID));
//                    glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oGIN.ExternalGoodIssueNote_ID, oGIN.ExternalGoodIssueNoteDate, oGINDetails.Item_ID, oGINDetails.ItemSubCategory_ID, oGINDetails.ItemSubCategory2_ID, oGINDetails.ItemSerialNo,
//                        oGINDetails.ItemSerialNo2, "Good Issue Note", oGIN.CreateUser_ID, oGIN.DateCreate, oGIN.ApprovedUser_ID, oGINDetails.Qty, oGINDetails.Weight, false,
//                        clsGenaralName.getName_Store(oGIN.Store_ID), clsGenaralName.getName_Item(oGINDetails.Item_ID), sBrand);
//                    if (oGIN.IsDeleted)
//                    {
//                        glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oGIN.ExternalGoodIssueNote_ID, oGIN.ExternalGoodIssueNoteDate, oGINDetails.Item_ID, oGINDetails.ItemSubCategory_ID, oGINDetails.ItemSubCategory2_ID, oGINDetails.ItemSerialNo,
//                            oGINDetails.ItemSerialNo2, "Good Issue Note Cancel", oGIN.ModifiedUser_ID, oGIN.DateModified, oGIN.ApprovedUser_ID, oGINDetails.Qty, oGINDetails.Weight, true,
//                            clsGenaralName.getName_Store(oGIN.Store_ID), clsGenaralName.getName_Item(oGINDetails.Item_ID), sBrand);
//                    }
//                }
//            }
//            recCount = recCount + 1;
//            #endregion

//            #region iGRN Transaction
//            var grns = tbl_scsStoreGoodReceiveNote.SelectAll().Where(p => p.StoreGoodReceiveNote_ID != "default" && p.DateCreate.Date >= dtpFrom.Value.Date && p.DateCreate.Date <= dtpTo.Value.Date && p.ToStore_ID == sStoreCode);
//            foreach (tbl_scsStoreGoodReceiveNote oGRN in grns)
//            {
//                var items = tbl_scsStoreGoodReceiveNote_Detail.SelectAllByStoreGoodReceiveNote_ID(oGRN.StoreGoodReceiveNote_ID).Where(p => p.Item_ID == sItemCode);
//                foreach (tbl_scsStoreGoodReceiveNote_Detail oGRNDetails in items)
//                {
//                    string sBrand = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oGRNDetails.ItemSubCategory_ID));
//                    glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oGRN.StoreGoodReceiveNote_ID, oGRN.StoreGoodReceiveNoteDate, oGRNDetails.Item_ID, oGRNDetails.ItemSubCategory_ID, oGRNDetails.ItemSubCategory2_ID, oGRNDetails.ItemSerialNo,
//                        oGRNDetails.ItemSerialNo2, "Internal Good Receive Note", oGRN.CreateUser_ID, oGRN.DateCreate, oGRN.ApprovedUser_ID, oGRNDetails.Qty, oGRNDetails.Weight, true,
//                        clsGenaralName.getName_Store(oGRN.ToStore_ID), clsGenaralName.getName_Item(oGRNDetails.Item_ID), sBrand);
//                    if (oGRN.IsDeleted)
//                    {
//                        glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oGRN.StoreGoodReceiveNote_ID, oGRN.StoreGoodReceiveNoteDate, oGRNDetails.Item_ID, oGRNDetails.ItemSubCategory_ID, oGRNDetails.ItemSubCategory2_ID, oGRNDetails.ItemSerialNo,
//                            oGRNDetails.ItemSerialNo2, "Internal Good Receive Note Cancel", oGRN.ModifiedUser_ID, oGRN.DateModified, oGRN.ApprovedUser_ID, oGRNDetails.Qty, oGRNDetails.Weight, false,
//                            clsGenaralName.getName_Store(oGRN.ToStore_ID), clsGenaralName.getName_Item(oGRNDetails.Item_ID), sBrand);
//                    }
//                }
//            }

//            recCount = recCount + 1;

//            #endregion

//            #region iGIN Transaction
//            foreach (tbl_scsStoreGoodIssueNote oGIN in tbl_scsStoreGoodIssueNote.SelectAll().Where(p => p.StoreGoodIssueNote_ID != "default" && p.DateCreate.Date >= dtpFrom.Value.Date && p.DateCreate.Date <= dtpTo.Value.Date && p.FromStore_ID == sStoreCode))
//            {
//                foreach (tbl_scsStoreGoodIssueNote_Detail oGINDetails in tbl_scsStoreGoodIssueNote_Detail.SelectAllByStoreGoodIssueNote_ID(oGIN.StoreGoodIssueNote_ID).Where(p => p.Item_ID == sItemCode))
//                {
//                    string sBrand = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oGINDetails.ItemSubCategory_ID));
//                    glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oGIN.StoreGoodIssueNote_ID, oGIN.StoreGoodIssueNoteDate, oGINDetails.Item_ID, oGINDetails.ItemSubCategory_ID, oGINDetails.ItemSubCategory2_ID, oGINDetails.ItemSerialNo,
//                        oGINDetails.ItemSerialNo2, "Internal Good Issue Note", oGIN.CreateUser_ID, oGIN.DateCreate, oGIN.ApprovedUser_ID, oGINDetails.Qty, oGINDetails.Weight, false,
//                        clsGenaralName.getName_Store(oGIN.FromStore_ID), clsGenaralName.getName_Item(oGINDetails.Item_ID), sBrand);
//                    if (oGIN.IsDeleted)
//                    {
//                        glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oGIN.StoreGoodIssueNote_ID, oGIN.StoreGoodIssueNoteDate, oGINDetails.Item_ID, oGINDetails.ItemSubCategory_ID, oGINDetails.ItemSubCategory2_ID, oGINDetails.ItemSerialNo,
//                            oGINDetails.ItemSerialNo2, "Internal Good Issue Note Cancel", oGIN.ModifiedUser_ID, oGIN.DateModified, oGIN.ApprovedUser_ID, oGINDetails.Qty, oGINDetails.Weight, true,
//                            clsGenaralName.getName_Store(oGIN.FromStore_ID), clsGenaralName.getName_Item(oGINDetails.Item_ID), sBrand);
//                    }
//                }
//                clsHelpMethods_Local.startProgressBar(0, oGIN.PrintCount + 2, 1, ProgressBar);
//                ProgressBar.Value = 0;
//            }
//            #endregion

//            #region DGN Transaction

//            //foreach (tbl_scsDamagedGoodNote oDGN in tbl_scsDamagedGoodNote.SelectAll().Where(p => p.DamagedGoodNote_ID != "default" && p.DateCreate.Date >= dtpFrom.Value.Date && p.DateCreate.Date <= dtpTo.Value.Date && p.Store_ID == sStoreCode))
//            //{
//            //    foreach (tbl_scsDamagedGoodNote_Detail oDGNDetails in tbl_scsDamagedGoodNote_Detail.SelectAllByDamagedGoodNote_ID(oDGN.DamagedGoodNote_ID).Where(p => p.Item_ID == sItemCode))
//            //    {
//            //        string sBrand = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oDGNDetails.ItemSubCategory_ID));
//            //        glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oDGN.DamagedGoodNote_ID, oDGN.DamagedGoodNoteDate, oDGNDetails.Item_ID, oDGNDetails.ItemSubCategory_ID, oDGNDetails.ItemSubCategory2_ID, oDGNDetails.ItemSerialNo,
//            //            oDGNDetails.ItemSerialNo2, "Damaged Good", oDGN.CreateUser_ID, oDGN.DateCreate, oDGN.ApprovedUser_ID, oDGNDetails.Qty, oDGNDetails.Weight, false,
//            //            clsGenaralName.getName_Store(oDGN.Store_ID), clsGenaralName.getName_Item(oDGNDetails.Item_ID), sBrand);
//            //        if (oDGN.IsDeleted)
//            //        {
//            //            glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oDGN.DamagedGoodNote_ID, oDGN.DamagedGoodNoteDate, oDGNDetails.Item_ID, oDGNDetails.ItemSubCategory_ID, oDGNDetails.ItemSubCategory2_ID, oDGNDetails.ItemSerialNo,
//            //                oDGNDetails.ItemSerialNo2, "Damaged Good Cancel", oDGN.ModifiedUser_ID, oDGN.DateModified, oDGN.ApprovedUser_ID, oDGNDetails.Qty, oDGNDetails.Weight, true,
//            //                clsGenaralName.getName_Store(oDGN.Store_ID), clsGenaralName.getName_Item(oDGNDetails.Item_ID), sBrand);
//            //        }
//            //    }
//            //}

//            //recCount = recCount + 1;

//            #endregion

//            #region PRN Transaction
//            foreach (tbl_scsPurchaseReturnedNote oPRN in tbl_scsPurchaseReturnedNote.SelectAll().Where(p => p.PurchaseReturnedNote_ID != "default" && p.DateCreate.Date >= dtpFrom.Value.Date && p.DateCreate.Date <= dtpTo.Value.Date && p.Store_ID == sStoreCode))
//            {
//                foreach (tbl_scsPurchaseReturnedNote_Detail oPRNDetails in tbl_scsPurchaseReturnedNote_Detail.SelectAllByPurchaseReturnedNote_ID(oPRN.PurchaseReturnedNote_ID).Where(p => p.Item_ID == sItemCode))
//                {
//                    string sBrand = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oPRNDetails.ItemSubCategory_ID));
//                    glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oPRN.PurchaseReturnedNote_ID, oPRN.PurchaseReturnedNoteDate, oPRNDetails.Item_ID, oPRNDetails.ItemSubCategory_ID, oPRNDetails.ItemSubCategory2_ID, oPRNDetails.ItemSerialNo,
//                        oPRNDetails.ItemSerialNo2, "Purchase Returned Note", oPRN.CreateUser_ID, oPRN.DateCreate, oPRN.ApprovedUser_ID, oPRNDetails.Qty, oPRNDetails.Weight, false,
//                        clsGenaralName.getName_Store(oPRN.Store_ID), clsGenaralName.getName_Item(oPRNDetails.Item_ID), sBrand);
//                    if (oPRN.IsDeleted)
//                    {
//                        glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oPRN.PurchaseReturnedNote_ID, oPRN.PurchaseReturnedNoteDate, oPRNDetails.Item_ID, oPRNDetails.ItemSubCategory_ID, oPRNDetails.ItemSubCategory2_ID, oPRNDetails.ItemSerialNo,
//                            oPRNDetails.ItemSerialNo2, "Purchase Returned Note Cancel", oPRN.ModifiedUser_ID, oPRN.DateModified, oPRN.ApprovedUser_ID, oPRNDetails.Qty, oPRNDetails.Weight, true,
//                            clsGenaralName.getName_Store(oPRN.Store_ID), clsGenaralName.getName_Item(oPRNDetails.Item_ID), sBrand);
//                    }
//                }
//            }
//            recCount = recCount + 1;
//            #endregion

//            #region SAN Transaction
//            foreach (tbl_scsStockAdjustment oSAN in tbl_scsStockAdjustment.SelectAll().Where(p => !p.IsDeleted && p.StockAdjustment_ID != "default" && p.DateCreate.Date >= dtpFrom.Value.Date && p.DateCreate.Date <= dtpTo.Value.Date && p.Store_ID == sStoreCode))
//            {
//                foreach (tbl_scsStockAdjustment_Detail oSANDetails in tbl_scsStockAdjustment_Detail.SelectAllByStockAdjustment_ID(oSAN.StockAdjustment_ID).Where(p => p.Item_ID == sItemCode))
//                {

//                    decimal dAdjestQty = oSANDetails.Qty - oSANDetails.OldQty;
//                    decimal dAdjestWeight = oSANDetails.Weight - oSANDetails.OldWeight;
//                    string sBrand = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oSANDetails.ItemSubCategory_ID));

//                    if (bIsWaightCalculation)
//                    {
//                        if (0 < dAdjestWeight)
//                        {
//                            glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oSAN.StockAdjustment_ID, oSAN.StockAdjustmentDate, oSANDetails.Item_ID, oSANDetails.ItemSubCategory_ID, oSANDetails.ItemSubCategory2_ID, oSANDetails.ItemSerialNo,
//                                oSANDetails.ItemSerialNo2, "Stock Adjustment - Stock Add", oSAN.CreateUser_ID, oSAN.DateCreate, oSAN.ApprovedUser_ID, dAdjestQty, dAdjestWeight, true,
//                                clsGenaralName.getName_Store(oSAN.Store_ID), clsGenaralName.getName_Item(oSANDetails.Item_ID), sBrand);
//                        }
//                        if (0 > dAdjestWeight)
//                        {
//                            #region Set Value Sign
//                            ItemInfo.dQty = dAdjestQty;
//                            ItemInfo.dWeight = dAdjestWeight;
//                            ItemInfo.setQtySign(false);
//                            #endregion

//                            glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oSAN.StockAdjustment_ID, oSAN.StockAdjustmentDate, oSANDetails.Item_ID, oSANDetails.ItemSubCategory_ID, oSANDetails.ItemSubCategory2_ID, oSANDetails.ItemSerialNo,
//                                oSANDetails.ItemSerialNo2, "Stock Adjustment - Stock Deduct", oSAN.ModifiedUser_ID, oSAN.DateModified, oSAN.ApprovedUser_ID, ItemInfo.dQtyBalance, ItemInfo.dWeightBalance, false,
//                                clsGenaralName.getName_Store(oSAN.Store_ID), clsGenaralName.getName_Item(oSANDetails.Item_ID), sBrand);
//                        }
//                    }
//                    else
//                    {
//                        if (0 < dAdjestQty)
//                        {
//                            glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oSAN.StockAdjustment_ID, oSAN.StockAdjustmentDate, oSANDetails.Item_ID, oSANDetails.ItemSubCategory_ID, oSANDetails.ItemSubCategory2_ID, oSANDetails.ItemSerialNo,
//                                oSANDetails.ItemSerialNo2, "Stock Adjustment - Stock Add", oSAN.CreateUser_ID, oSAN.DateCreate, oSAN.ApprovedUser_ID, dAdjestQty, dAdjestWeight, true,
//                                clsGenaralName.getName_Store(oSAN.Store_ID), clsGenaralName.getName_Item(oSANDetails.Item_ID), sBrand);
//                        }
//                        if (0 > dAdjestQty)
//                        {
//                            #region Set Value Sign
//                            ItemInfo.dQty = dAdjestQty;
//                            ItemInfo.dWeight = dAdjestWeight;
//                            ItemInfo.setQtySign(false);
//                            #endregion

//                            glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oSAN.StockAdjustment_ID, oSAN.StockAdjustmentDate, oSANDetails.Item_ID, oSANDetails.ItemSubCategory_ID, oSANDetails.ItemSubCategory2_ID, oSANDetails.ItemSerialNo,
//                                oSANDetails.ItemSerialNo2, "Stock Adjustment - Stock Deduct", oSAN.ModifiedUser_ID, oSAN.DateModified, oSAN.ApprovedUser_ID, ItemInfo.dQtyBalance, ItemInfo.dWeightBalance, false,
//                                clsGenaralName.getName_Store(oSAN.Store_ID), clsGenaralName.getName_Item(oSANDetails.Item_ID), sBrand);
//                        }
//                    }
//                }
//            }
//            recCount = recCount + 1;
//            #endregion

//            #region SPLI From Transaction
//            foreach (tbl_scsItemSpred oSPLI in tbl_scsItemSpred.SelectAll().Where(p => !p.IsDeleted && p.ItemSpred_ID != "default" && p.DateCreate.Date >= dtpFrom.Value.Date && p.DateCreate.Date <= dtpTo.Value.Date && p.Store_ID == sStoreCode))
//            {
//                bool IsQtyWeightChange = false;
//                #region Item Spred Detail Spred to Qty - Weight
//                foreach (tbl_scsItemSpred_Detail_From oSLPIDetails in tbl_scsItemSpred_Detail_From.SelectAllByItemSpred_ID(oSPLI.ItemSpred_ID).Where(p => p.Item_ID == sItemCode))
//                {
//                    tbl_scsItemSpred_Detail_To oSLPITo = tbl_scsItemSpred_Detail_To.Select(oSPLI.ItemSpred_ID, oSLPIDetails.Item_ID, oSLPIDetails.ItemSubCategory_ID, oSLPIDetails.ItemSubCategory2_ID, oSLPIDetails.ItemSerialNo, oSLPIDetails.ItemSerialNo2);
//                    if (oSLPITo != null)
//                    {
//                        //decimal SpredValFrom = 0, SpredValTo = 0;
//                        string sBrand = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oSLPIDetails.ItemSubCategory_ID));
//                        //if (oSLPIDetails.Qty > 0 && oSLPITo.Weight > 0)
//                        //{
//                        //    IsQtyWeightChange = true;
//                        //    SpredValFrom = oSLPIDetails.Qty;
//                        //    SpredValTo = oSLPITo.Weight;
//                        //}
//                        //else 
//                        if (oSLPIDetails.Weight > 0 && oSLPITo.Qty > 0)
//                        {
//                            IsQtyWeightChange = true;
//                            //SpredValFrom = oSLPIDetails.Weight;
//                            //SpredValTo = oSLPITo.Qty;
//                        }
//                        if (IsQtyWeightChange)
//                        {
//                            //tbl_scsItemSpred_Detail_From - Use Weight to Qty field
//                            glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oSPLI.ItemSpred_ID, oSPLI.ItemSpredDate, oSLPIDetails.Item_ID, oSLPIDetails.ItemSubCategory_ID, oSLPIDetails.ItemSubCategory2_ID, oSLPIDetails.ItemSerialNo,
//                                oSLPIDetails.ItemSerialNo2, "Item Spred From Weight Type", oSPLI.CreateUser_ID, oSPLI.DateCreate, oSPLI.ApprovedUser_ID, oSLPIDetails.Weight, oSLPIDetails.Weight, false,
//                                clsGenaralName.getName_Store(oSPLI.Store_ID), clsGenaralName.getName_Item(oSLPIDetails.Item_ID), sBrand);

//                            //tbl_scsItemSpred_Detail_To
//                            glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oSPLI.ItemSpred_ID, oSPLI.ItemSpredDate, oSLPITo.Item_ID, oSLPITo.ItemSubCategory_ID, oSLPITo.ItemSubCategory2_ID, oSLPITo.ItemSerialNo,
//                                oSLPITo.ItemSerialNo2, "Item Spred to Qty Type", oSPLI.CreateUser_ID, oSPLI.DateCreate, oSPLI.ApprovedUser_ID, oSLPITo.Qty, oSLPITo.Weight, true,
//                                clsGenaralName.getName_Store(oSPLI.Store_ID), clsGenaralName.getName_Item(oSLPITo.Item_ID), sBrand);
//                        }
//                    }
//                }

//                recCount = recCount + 1;

//                #endregion

//                #region Item Spred With Another Item
//                if (!IsQtyWeightChange)
//                {
//                    #region Item Spred Detail From
//                    foreach (tbl_scsItemSpred_Detail_From oSLPIDetails in tbl_scsItemSpred_Detail_From.SelectAllByItemSpred_ID(oSPLI.ItemSpred_ID).Where(p => p.Item_ID == sItemCode))
//                    {
//                        string sBrand = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oSLPIDetails.ItemSubCategory_ID));
//                        glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oSPLI.ItemSpred_ID, oSPLI.ItemSpredDate, oSLPIDetails.Item_ID, oSLPIDetails.ItemSubCategory_ID, oSLPIDetails.ItemSubCategory2_ID, oSLPIDetails.ItemSerialNo,
//                            oSLPIDetails.ItemSerialNo2, "Item Spred From", oSPLI.CreateUser_ID, oSPLI.DateCreate, oSPLI.ApprovedUser_ID, oSLPIDetails.Qty, oSLPIDetails.Weight, false,
//                            clsGenaralName.getName_Store(oSPLI.Store_ID), clsGenaralName.getName_Item(oSLPIDetails.Item_ID), sBrand);
//                        //if (oSPLI.IsDeleted)
//                        //{
//                        //    glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oSPLI.ItemSpred_ID, oSPLI.ItemSpredDate, oSLPIDetails.Item_ID, oSLPIDetails.ItemSubCategory_ID, oSLPIDetails.ItemSubCategory2_ID, oSLPIDetails.ItemSerialNo,
//                        //        oSLPIDetails.ItemSerialNo2, "Purchase Returned Note Cancel", oSPLI.ModifiedUser_ID, oSPLI.DateModified, oSPLI.ApprovedUser_ID, oSLPIDetails.Qty, oSLPIDetails.Weight, true,
//                        //        clsGenaralName.getName_Store(oSPLI.Store_ID), clsGenaralName.getName_Item(oSLPIDetails.Item_ID), sBrand);
//                        //}
//                    }

//                    recCount = recCount + 1;

//                    #endregion

//                    #region Item Spred Detail To
//                    foreach (tbl_scsItemSpred_Detail_To oSLPIDetails in tbl_scsItemSpred_Detail_To.SelectAllByItemSpred_ID(oSPLI.ItemSpred_ID).Where(p => p.Item_ID == sItemCode))
//                    {
//                        string sBrand = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oSLPIDetails.ItemSubCategory_ID));
//                        glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oSPLI.ItemSpred_ID, oSPLI.ItemSpredDate, oSLPIDetails.Item_ID, oSLPIDetails.ItemSubCategory_ID, oSLPIDetails.ItemSubCategory2_ID, oSLPIDetails.ItemSerialNo,
//                            oSLPIDetails.ItemSerialNo2, "Item Spred To", oSPLI.CreateUser_ID, oSPLI.DateCreate, oSPLI.ApprovedUser_ID, oSLPIDetails.Qty, oSLPIDetails.Weight, true,
//                            clsGenaralName.getName_Store(oSPLI.Store_ID), clsGenaralName.getName_Item(oSLPIDetails.Item_ID), sBrand);
//                        //if (oSPLI.IsDeleted)
//                        //{
//                        //    glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oSPLI.ItemSpred_ID, oSPLI.ItemSpredDate, oSLPIDetails.Item_ID, oSLPIDetails.ItemSubCategory_ID, oSLPIDetails.ItemSubCategory2_ID, oSLPIDetails.ItemSerialNo,
//                        //        oSLPIDetails.ItemSerialNo2, "Purchase Returned Note Cancel", oSPLI.ModifiedUser_ID, oSPLI.DateModified, oSPLI.ApprovedUser_ID, oSLPIDetails.Qty, oSLPIDetails.Weight, true,
//                        //        clsGenaralName.getName_Store(oSPLI.Store_ID), clsGenaralName.getName_Item(oSLPIDetails.Item_ID), sBrand);
//                        //}
//                    }

//                    recCount = recCount + 1;

//                    #endregion
//                }
//                #endregion
//            }
//            #endregion

//            #region Damage Goods
//            ItemInfo.dQty = 0;
//            ItemInfo.dWeight = 0;
//            List<tbl_scsDamagedGoodNote> oDG;

//            if (bIsDamagedStore)
//                oDG = tbl_scsDamagedGoodNote.SelectAll().Where(p => !p.IsDeleted && p.DamagedGoodNote_ID != "default" && p.DateCreate.Date >= dtpFrom.Value.Date && p.DateCreate.Date <= dtpTo.Value.Date).ToList();
//            else
//                oDG = tbl_scsDamagedGoodNote.SelectAll().Where(p => !p.IsDeleted && p.DamagedGoodNote_ID != "default" && p.DateCreate.Date >= dtpFrom.Value.Date && p.DateCreate.Date <= dtpTo.Value.Date && p.Store_ID == sStoreCode).ToList();

//            foreach (tbl_scsDamagedGoodNote oDamegGood in oDG)
//            {
//                foreach (tbl_scsDamagedGoodNote_Detail oDGDetails in tbl_scsDamagedGoodNote_Detail.SelectAllByDamagedGoodNote_ID(oDamegGood.DamagedGoodNote_ID).Where(p => p.Item_ID == sItemCode))
//                {

//                    string sBrand = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oDGDetails.ItemSubCategory_ID));
//                    glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oDamegGood.DamagedGoodNote_ID, oDamegGood.DamagedGoodNoteDate, oDGDetails.Item_ID, oDGDetails.ItemSubCategory_ID, oDGDetails.ItemSubCategory2_ID, oDGDetails.ItemSerialNo,
//                        oDGDetails.ItemSerialNo2, "Damaged Good", oDamegGood.CreateUser_ID, oDamegGood.DateCreate, oDamegGood.ApprovedUser_ID, oDGDetails.Qty, oDGDetails.Weight, bIsDamagedStore,
//                        clsGenaralName.getName_Store(sStoreCode), clsGenaralName.getName_Item(oDGDetails.Item_ID), sBrand);
//                }
//            }
//            recCount = recCount + 1;

//            #endregion

//            #region Discard Goods
//            if (bIsDamagedStore)
//            {
//                ItemInfo.dQty = 0;
//                ItemInfo.dWeight = 0;
//                foreach (tbl_scsDiscardedGoodNote oDIN in tbl_scsDiscardedGoodNote.SelectAll().Where(p => !p.IsDeleted && p.DiscardedGoodNote_ID != "default" && p.DateCreate.Date >= dtpFrom.Value.Date && p.DateCreate.Date <= dtpTo.Value.Date))
//                {
//                    foreach (tbl_scsDiscardedGoodNote_Detail oDINDetails in tbl_scsDiscardedGoodNote_Detail.SelectAllByDiscardedGoodNote_ID(oDIN.DiscardedGoodNote_ID).Where(p => p.Item_ID == sItemCode))
//                    {

//                        string sBrand = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oDINDetails.ItemSubCategory_ID));
//                        glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oDIN.DiscardedGoodNote_ID, oDIN.DiscardedGoodNoteDate, oDINDetails.Item_ID, oDINDetails.ItemSubCategory_ID, oDINDetails.ItemSubCategory2_ID, oDINDetails.ItemSerialNo,
//                            oDINDetails.ItemSerialNo2, "Discarded Good", oDIN.CreateUser_ID, oDIN.DateCreate, oDIN.ApprovedUser_ID, oDINDetails.DiscardingQty, oDINDetails.DiscardingWeight, false,
//                            clsGenaralName.getName_Store(sStoreCode), clsGenaralName.getName_Item(oDINDetails.Item_ID), sBrand);

//                    }
//                }
//                recCount = recCount + 1;
//            }
//            #endregion

//            #region Finished Good Transfer Note
//            foreach (tbl_scsStoreProduction oFGN in tbl_scsStoreProduction.SelectAll().Where(p => p.StoreProduction_ID != "default" && p.StoreProductionDate.Date >= dtpFrom.Value.Date && p.StoreProductionDate.Date <= dtpTo.Value.Date && p.Store_ID == sStoreCode))
//            {
//                foreach (tbl_scsStoreProduction_Detail oFGNDetails in tbl_scsStoreProduction_Detail.SelectAllByStoreProduction_ID(oFGN.StoreProduction_ID).Where(p => p.Item_ID == sItemCode))
//                {
//                    string sBrand = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(oFGNDetails.ItemSubCategory_ID));
//                    glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oFGN.StoreProduction_ID, oFGN.StoreProductionDate, oFGNDetails.Item_ID, oFGNDetails.ItemSubCategory_ID, oFGNDetails.ItemSubCategory2_ID, oFGNDetails.ItemSerialNo,
//                        oFGNDetails.ItemSerialNo2, "Finished Good Transfer Note", oFGN.CreateUser_ID, oFGN.DateCreate, oFGN.ApprovedUser_ID, oFGNDetails.Qty, oFGNDetails.Weight, true,
//                        clsGenaralName.getName_Store(oFGN.Store_ID), clsGenaralName.getName_Item(oFGNDetails.Item_ID), sBrand);
//                    if (oFGN.IsDeleted)
//                    {
//                        glbDtsStock.dt_scsStockTracking.Adddt_scsStockTrackingRow(oFGN.StoreProduction_ID, oFGN.StoreProductionDate, oFGNDetails.Item_ID, oFGNDetails.ItemSubCategory_ID, oFGNDetails.ItemSubCategory2_ID, oFGNDetails.ItemSerialNo,
//                            oFGNDetails.ItemSerialNo2, "Finished Good Transfer Note Cancel", oFGN.ModifiedUser_ID, oFGN.DateModified, oFGN.ApprovedUser_ID, oFGNDetails.Qty, oFGNDetails.Weight, false,
//                            clsGenaralName.getName_Store(oFGN.Store_ID), clsGenaralName.getName_Item(oFGNDetails.Item_ID), sBrand);
//                    }
//                }
//            }
//            #endregion
//            recCount = recCount + 1;

//            clsHelpMethods_Local.startProgressBar(0, recCount + 2, 1, ProgressBar);
//            ProgressBar.Value = 0;
//            print("\\reports\\SCS\\Commen\\rpt_scs_StockTracking_Qty.rpt", "Stocks Tracking Report", "[Qty wise]", "", glbDtsStock.dt_scsStockTracking, "");

//            #endregion
//        }
//        catch (Exception)
//        {
//        }
//        finally
//        {
//            Cursor = Cursors.Default;
//            glbDtsStock.dt_scsStockTracking.Clear();
//        }
//    }
//}
#endregion

#region old report STOCKS TRACKING REPORT - WEIGHT
//if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Stocks_TrackingReport_Weight)))
//{
//    string sFormula = " {vw_rpt_scsLedger.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_scsLedger.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

//    if (txtItemName.Tag != null && txtItemName.Tag.ToString().Trim().Length > 0)
//        sFormula += " and {vw_rpt_scsLedger.item_ID} = '" + txtItemName.Tag.ToString().Trim() + "'";
//    if (txtStore.Tag != null && txtStore.Tag.ToString().Trim().Length > 0)
//        sFormula += " and {vw_rpt_scsLedger.store_ID} = '" + txtStore.Tag.ToString().Trim() + "'";
//    if (!chkShowDeactivate.Checked)
//        sFormula += " and {vw_rpt_scsLedger.isDeleted} = " + (bool)chkShowDeactivate.Checked + "";
//    print("\\reports\\SCS\\Commen\\rpt_scs_Ledger_Weight.rpt", "Stocks Tracking Report", "[Weight wise]", "", sFormula);
//}
#endregion