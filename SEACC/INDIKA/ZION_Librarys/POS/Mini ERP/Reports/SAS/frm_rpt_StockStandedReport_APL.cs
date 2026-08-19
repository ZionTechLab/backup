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
using Digiteq.DataSets;
using DataTire;
using Digiteq_Logic;


namespace Digiteq
{
    public partial class frm_rpt_StockStandedReport_APL : Form
    {
        #region Variables
        //form manage
           public int iFormID;

        //for security handle
        public bool bNoAccess;

        //objects from datasets        
        dts_Stock glbDtsStock = new dts_Stock();
        #endregion

        #region Form Load
        public frm_rpt_StockStandedReport_APL()
        {
            iFormID = clsSecurity.getFormID(FormName.scsStockStandedReport);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frmReportChequeDeposit_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "Stock Analysis Report", 2, iFormID);

            clearField();           
            rdo_TrackingReport_Qty.Checked = true;
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
            string sFilter = "";
            bool bStoreSelected = false;
            if (txtStore.Tag != null && txtStore.Tag.ToString().Trim().Length > 0 && txtStore.Tag.ToString().Trim() != "default")
                bStoreSelected = true;

            #region STOCKS TRACKING REPORT - QTY
            if (rdo_TrackingReport_Qty.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Stocks_TrackingReport_Qty)))
                {
                    string sFormula = " {vw_rpt_scsLedger.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_scsLedger.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                    if (txtItemName.Tag != null && txtItemName.Tag.ToString().Trim().Length > 0)
                        sFormula += " and {vw_rpt_scsLedger.item_ID} = '" + txtItemName.Tag.ToString().Trim() + "'";
                    if (txtStore.Tag != null && txtStore.Tag.ToString().Trim().Length > 0)
                        sFormula += " and {vw_rpt_scsLedger.store_ID} = '" + txtStore.Tag.ToString().Trim() + "'";

                    print("\\reports\\SCS\\Commen\\rpt_scs_Ledger_Qty.rpt", "STOCKS TRACKING REPORT - QTY", sFormula);
                }
            } 
            #endregion

            #region STOCKS TRACKING REPORT - WEIGHT
            if (rdo_TrackingReport_Weight.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Stocks_TrackingReport_Weight)))
                {
                    string sFormula = " {vw_rpt_scsLedger.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_scsLedger.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                    if (txtItemName.Tag != null && txtItemName.Tag.ToString().Trim().Length > 0)
                        sFormula += " and {vw_rpt_scsLedger.item_ID} = '" + txtItemName.Tag.ToString().Trim() + "'";
                    if (txtStore.Tag != null && txtStore.Tag.ToString().Trim().Length > 0)
                        sFormula += " and {vw_rpt_scsLedger.store_ID} = '" + txtStore.Tag.ToString().Trim() + "'";

                    print("\\reports\\SCS\\Commen\\rpt_scs_Ledger_Weight.rpt", "STOCKS TRACKING REPORT - WEIGHT", sFormula);
                }
            } 
            #endregion

            #region OPENING STOCKS REPORT
            if (rdoStockTake.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Opening_StockReport)))
                {
                    string sFormula = " {vw_scsWeeklyStockTake.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_scsWeeklyStockTake.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                    if (txtItemName.Tag != null && txtItemName.Tag.ToString().Trim().Length > 0)
                        sFormula += " and {vw_scsWeeklyStockTake.item_ID} = '" + txtItemName.Tag.ToString().Trim() + "'";
                    if (txtStore.Tag != null && txtStore.Tag.ToString().Trim().Length > 0)
                        sFormula += " and {vw_scsWeeklyStockTake.store_ID} = '" + txtStore.Tag.ToString().Trim() + "'";

                    print("\\reports\\SCS\\Registry\\rpt_scsWeeklyStockTake.rpt", "OPENING STOCKS REPORT", sFormula);
                }
            } 
            #endregion

            #region OPENING STOCKS REPORT
            if (rdoStockTake.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Opening_StockReport)))
                {
                    string sFormula = " {vw_scsWeeklyStockTake.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_scsWeeklyStockTake.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                    if (txtItemName.Tag != null && txtItemName.Tag.ToString().Trim().Length > 0)
                        sFormula += " and {vw_scsWeeklyStockTake.item_ID} = '" + txtItemName.Tag.ToString().Trim() + "'";
                    if (txtStore.Tag != null && txtStore.Tag.ToString().Trim().Length > 0)
                        sFormula += " and {vw_scsWeeklyStockTake.store_ID} = '" + txtStore.Tag.ToString().Trim() + "'";

                    print("\\reports\\SCS\\Registry\\rpt_scsWeeklyStockTake.rpt", "OPENING STOCKS REPORT", sFormula);
                }
            } 
            #endregion

            #region Item Split Note - Delta Report
            if (rdoItemSplitNoteDelta.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Item_SplitNote_DeltaReport)))
                {
                    string sFormula = "{vw_rpt_scsItemSplitNote.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_scsItemSplitNote.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                    sFormula += " and {vw_rpt_scsItemSplitNote.isDeleted} = False";

                    if (txtStore.Tag != null && txtStore.Tag.ToString().Trim().Length > 0)
                        sFormula += " and {vw_rpt_scsItemSplitNote.store_ID} = '" + txtStore.Tag.ToString().Trim() + "'";

                    print("\\reports\\SCS\\Standard\\rpt_scs_ItemSplitNote_Delta.rpt", "Item Split Note - Delta Report", sFormula);
                }
            } 
            #endregion

            #region Pending Loan-Out
            if (rdoPendingLoanOut.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Pending_LoanOut)))
                {
                    string sFormula = "{vw_rpt_scsLoanIn.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_scsLoanIn.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                    sFormula += " and {vw_rpt_scsLoanIn.isDeleted} = False and {vw_rpt_scsLoanIn.isSeattled} = False";

                    print("\\reports\\SCS\\Standard\\rpt_scs_PendingLoanOut.rpt", "Pending Loan-Out", sFormula);

                }
            } 
            #endregion

            #region Pending Loan-IN
            if (rdoPendingLoanIn.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Pending_LoanIn)))
                {
                    string sFormula = "{vw_rpt_scsLoanOut.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_scsLoanOut.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                    sFormula += " and {vw_rpt_scsLoanOut.isDeleted} = False and {vw_rpt_scsLoanOut.isSeattled} = False";

                    print("\\reports\\SCS\\Standard\\rpt_scs_PendingLoanIn.rpt", "Pending Loan-IN", sFormula);

                }
            } 
            #endregion

            #region Store Requests vs Issues
            if (rdoSRvsGIN.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Store_Requests_vs_Issues)))
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

                    print("\\reports\\SCS\\Standard\\rpt_scs_SRvsGIN.rpt", "Store Requests vs Issues", sFormula);
                }
            } 
            #endregion

            #region PO Tracking Report
            else if (rdoPO_TrackingReport.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Collection_Report_Summary)))
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        glbDtsStock.dt_POtracking.Rows.Clear();                      

                        foreach (tbl_scsPurchaseOrder oPO in tbl_scsPurchaseOrder.SelectAll().Where(p => !p.IsDeleted && p.PurchaseOrder_ID != "default"))
                        {
                            foreach (tbl_scsPurchaseOrder_Detail detail in tbl_scsPurchaseOrder_Detail.SelectAllByPurchaseOrder_ID(oPO.PurchaseOrder_ID))
                            {
                                string sStoreID = "";
                                string sStoreName = "";
                                string sGRN_ID = "";
                                string sPRN_ID = "";
                                DateTime GRN_Date = clsSecurity.getServerDateTime();
                                DateTime PRN_Date = clsSecurity.getServerDateTime();
                                decimal dGRN_Qty = 0, dGRN_Weigh = 0, dPRN_Qty = 0, dPRN_Weigh = 0;

                                glbDtsStock.dt_POtracking.Rows.Add(detail.Item_ID, clsGenaralName.getName_Item(detail.Item_ID), clsGenaralName.getName_ItemSubCategory(detail.ItemSubCategory_ID),
                                sStoreID, sStoreName, oPO.PurchaseOrder_ID, oPO.PurchaseOrderDate, detail.Qty, detail.Weight, sGRN_ID, GRN_Date, dGRN_Qty, dGRN_Weigh, sPRN_ID, PRN_Date, dPRN_Qty, dPRN_Weigh, clsGenaralName.getName_User(oPO.CreateUser_ID));
                            }
                        }
                        //print the report                                            
                        print("\\Reports\\SCS\\Standard\\rpt_scs_PurchaseOder_TrackingReport_Summary.rpt", " Purchase  Order Tracking Report", glbDtsStock.dt_POtracking);
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID,ex);

                        SEACCException.Show(ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                        glbDtsStock.dt_POtracking.Rows.Clear();
                    }

                }
            }
            #endregion

            #region Stock Value Report
            else if (rdoStockValueReport.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Collection_Report_Summary)))
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        glbDtsStock.dt_scsFloorStock_Store.Rows.Clear();

                        foreach (tbl_genStore_Stock oStock in tbl_genStore_Stock.SelectAll().Where(p => (p.Qty > 0 || p.Weight > 0) && p.Item_ID != "default"))
                        {
                            tbl_genItemMaster oItem = tbl_genItemMaster.Select(oStock.Item_ID);
                            if (oItem != null && oItem.Item_ID != "default")
                            {
                                string sItemClass = "N/A", sItemCategory = "N/A", sItemType = "N/A", sItemUOM = "N/A";
                                bool bStoreOK = true;
                                decimal dValue = 0;
                                sFilter = "";
                                
                                if (bStoreSelected)
                                {
                                    sFilter += " Store Name : " + txtStore.Text.Trim();
                                    bStoreOK = oStock.Store_ID == txtStore.Tag.ToString() ? true : false;
                                }

                                if (bStoreOK)
                                {
                                    sItemClass = oItem.ItemClass_ID != "default" ? clsGenaralName.getName_ItemClass(oItem.ItemClass_ID) : "N/A";
                                    sItemType = oItem.ItemType_ID != "default" ? clsGenaralName.getName_ItemType(oItem.ItemType_ID) : "N/A";
                                    sItemCategory = oItem.ItemCategory_ID != "default" ? clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID) : "N/A";
                                    sItemUOM = oItem.Uom_ID != "default" ? clsGenaralName.getName_Uom(oItem.Uom_ID) : "N/A";
                                    //if (oItem.CostPrice > 0)
                                    //{
                                    //    if (oItem.IsWeightCalculation_Purchase && oStock.Weight > 0)
                                    //        dValue = oItem.CostPrice * oStock.Weight;
                                    //    else if (!oItem.IsWeightCalculation_Purchase && oStock.Qty > 0)
                                    //        dValue = oItem.CostPrice * oStock.Qty;
                                    //}

                                    //glbDtsStock.dt_scsFloorStock_Store.Adddt_scsFloorStock_StoreRow(clsGenaralName.getName_Store(oStock.Store_ID),"", oStock.Item_ID, clsGenaralName.getName_Item(oItem.Item_ID),
                                    //    sItemClass, sItemType, sItemCategory,"", "", sItemUOM, oStock.Weight, oStock.Qty, oItem.CostPrice, dValue, "", "", "", "", oStock.ItemSerialNo, "");
                                }
                            }
                        }
                        //print the report                                            
                        print("\\Reports\\SCS\\Standard\\rpt_scs_StockValueReport.rpt", " Stock Value Report", glbDtsStock.dt_scsFloorStock_Store);
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID,ex);
                        SEACCException.Show(ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                        glbDtsStock.dt_POtracking.Rows.Clear();
                    }

                }
            }
            #endregion

            #region Stock Age Analysis Report
            else if (rdoAgeAnalysis.Checked)
            {
               // if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Collection_Report_Summary)))
               // {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    glbDtsStock.dt_scsStockMoving.Rows.Clear();

                    //foreach (tbl_scsExternalGoodReceivedNote_Detail_FIFO oGRNDetailFIFO in tbl_scsExternalGoodReceivedNote_Detail_FIFO.SelectAll().Where(p => p.Item_ID != "default"))
                    //{
                    //    decimal d0to30Days = 0, d31to60Days = 0, d61to90Days = 0, dOver90Days = 0;
                    //    string sBrandModel = "";
                    //    foreach (tbl_sasInvoice_Detail_FIFO oInvoiceDetailFIFO in tbl_sasInvoice_Detail_FIFO.SelectAllByExternalGoodReceivedNote_ID(oGRNDetailFIFO.ExternalGoodReceivedNote_ID).Where(p => p.Item_ID == oGRNDetailFIFO.Item_ID))
                    //    {
                    //        tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(oInvoiceDetailFIFO.Invoice_ID);
                    //        if (oInvoice != null)
                    //        {
                    //            TimeSpan timeSpan = oGRNDetailFIFO.ExternalGoodIssueNoteDate.Date - oInvoice.InvoiceDate.Date;
                    //            double dDateCount = timeSpan.TotalDays;

                    //            //if (oInvoiceDetailFIFO.Item_ID == oGRNDetailFIFO.Item_ID)
                    //            //{
                    //                if (dDateCount <= 30)                                    
                    //                    d0to30Days += oInvoiceDetailFIFO.Qty;                                    
                    //                else if (dDateCount > 31 & dDateCount <= 60)                                   
                    //                    d31to60Days += oInvoiceDetailFIFO.Qty;                                    
                    //                else if (dDateCount > 61 & dDateCount <= 90)                                    
                    //                    d61to90Days += oInvoiceDetailFIFO.Qty;                                    
                    //                else if (dDateCount >= 91)
                    //                    dOver90Days += oInvoiceDetailFIFO.Qty;                                                                                                         
                    //            //}
                    //        }
                    //    }
                    //    //glbDtsStock.dt_scsStockMoving.Adddt_scsStockMovingRow(oGRNDetailFIFO.Item_ID, clsGenaralName.getName_Item(oGRNDetailFIFO.Item_ID),
                    //    //    clsGenaralName.getName_ItemSubCategory(oGRNDetailFIFO.Item_ID), d0to30Days, d31to60Days, d61to90Days, dOver90Days, 
                    //    //    oGRNDetailFIFO.ExternalGoodReceivedNote_ID, oGRNDetailFIFO.ExternalGoodIssueNoteDate);
                    //}

                    //print the report                                            
                   // print("\\Reports\\SCS\\Standard\\rpt_scs_StocksAgeAnalysisReport.rpt", " Stocks Age Analysis Report", glbDtsStock.dt_scsStockMoving);
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID,ex);
                    SEACCException.Show(ex);
                }
                    finally
                    {
                        Cursor = Cursors.Default;
                        glbDtsStock.dt_scsStockMoving.Rows.Clear();
                    }

                //}
            }
            #endregion

            #region PO Item Cost History
            else if (rdoPOItemCostHistory.Checked)
            {
                // if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Collection_Report_Summary)))
                // {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    glbDtsStock.dt_scsPOItemCostHistory.Rows.Clear();

                    if (txtPoNo.Text != "") 
                    {
                        tbl_scsPurchaseOrder oPurchaseOrder = tbl_scsPurchaseOrder.Select(txtPoNo.Text);
                        if(oPurchaseOrder!=null)
                        {                            
                            foreach (tbl_scsPurchaseOrder_Detail oPurchaseOrderDetail in tbl_scsPurchaseOrder_Detail.SelectAllByPurchaseOrder_ID(oPurchaseOrder.PurchaseOrder_ID))
                            {
                                foreach (tbl_scsPurchaseOrder_Detail oPurchaseOrderDetailForItem in tbl_scsPurchaseOrder_Detail.SelectAllByItem_ID(oPurchaseOrderDetail.Item_ID)) 
                                {                                    
                                    tbl_scsPurchaseOrder oInnerPurchaseOrder = tbl_scsPurchaseOrder.Select(oPurchaseOrderDetailForItem.PurchaseOrder_ID) ; // p >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date
                                    if (oInnerPurchaseOrder != null) 
                                    {
                                        decimal dUnitPrice = oInnerPurchaseOrder.IsWeightCalculation ? oPurchaseOrderDetailForItem.KiloPrice : oPurchaseOrderDetailForItem.UnitPrice;
                                        decimal dQty = oInnerPurchaseOrder.IsWeightCalculation ? oPurchaseOrderDetailForItem.Weight : oPurchaseOrderDetailForItem.Qty;

                                        //glbDtsStock.dt_scsPOItemCostHistory.Adddt_scsPOItemCostHistoryRow(oPurchaseOrder.PurchaseOrder_ID,clsGenaralName.getName_Supplier(oPurchaseOrder.Supplier_ID),
                                        //    oInnerPurchaseOrder.PurchaseOrder_ID,oInnerPurchaseOrder.PurchaseOrderDate,clsGenaralName.getName_Supplier(oInnerPurchaseOrder.Supplier_ID),
                                        //    clsGenaralName.getName_CurrencyCode(oInnerPurchaseOrder.Currency_ID), oInnerPurchaseOrder.ForexRate, dQty,
                                        //    dUnitPrice, oPurchaseOrderDetailForItem.Item_ID, clsGenaralName.getName_Item(oPurchaseOrderDetailForItem.Item_ID));
                                    }
                                }                                
                            }                            
                        }
                        //print the report                                            
                        print("\\Reports\\SCS\\Standard\\rpt_scs_PurchaseOderItemCostHistory.rpt", "Purchase Order Item Cost History Report", glbDtsStock.dt_scsPOItemCostHistory);
                    }                  
                    
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID,ex);
                    SEACCException.Show(ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                    glbDtsStock.dt_scsPOItemCostHistory.Rows.Clear();
                }

                //}
            }
            #endregion

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

            txtStore.Text = "<All Stores>";
            txtItemCategory.Text = "<All Categories>";
            txtItemName.Text = "<All Items>";
            txtItemType.Text = "<All Types>";
            txtPoNo.Text = "";

            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtStore, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemName, false);
        }
        #endregion

        #region Print Method
        #region report Print Method
        private void print(string path, string sReportTitle, string sFormula)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Flow Stock Balance";
                ReportDocument RD = new ReportDocument();
                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                frm_ReportViewer viewer = new frm_ReportViewer();
                RD.Load(s_Path);
                clsSecurity.LogonServer(ref RD);
                RD.Refresh();

                RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                RD.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                //    RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);

                if (rdoStockTake.Checked)
                    RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);

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
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        } 
        #endregion

        #region Data set Print method
        private void print(string path, string sReportTitle, DataTable objDataTable)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Standed Reports";
                ReportDocument objRpt = new ReportDocument();
                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                objRpt.Load(s_Path);//glbDtsStock
                objRpt.SetDataSource(objDataTable); //(glbDtsSales)

                objRpt.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                objRpt.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

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
                clsValidate.WriteErrorLog("", iFormID,ex);
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
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterStore(ref txtStore, true);
            }
        }
     
        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_ItemMaster(ref txtItemName, null, null, null, false);
            }
        }
        private void txtItemType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterItemType(ref txtItemType);
            }
        }
        private void txtItemCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterItemCategory(ref txtItemCategory);
            }
        }
        private void txtPoNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_TransactionPurchaseOrder_Use(ref txtPoNo);
            }
        }
        #endregion
      
        #region Events DoublClick
        private void txtStoreStock_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterStore(ref txtStore, true);
        }
      
        private void txtItemName_DoubleClick(object sender, EventArgs e)
        {
            //clsSearch.Search_ItemMaster(ref txtItemName);
            clsSearch.Search_ItemMaster(ref txtItemName, null, null, null, false);
        }
        private void txtItemType_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterItemType(ref txtItemType);
        }
        private void txtItemCategory_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterItemCategory(ref txtItemCategory);
        }
        private void txtPoNo_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_TransactionPurchaseOrder_Use(ref txtPoNo);
        }
        #endregion

        #region Events CheckedChanged
        private void rdoStoreStock_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdo_TrackingReport_Weight_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }

        private void rdoStockBalanceVsPending_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }

        private void rdoStockTake_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }

        private void rdoItemSplitNoteDelta_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }

        private void rdoSRvsGIN_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }

        private void rdoPendingLoanIn_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoPendingLoanOut_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoPOItemCostHistory_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        #endregion

        #region Set Enable/Disable Controls
        private void setEnableDisableConctrol()
        {
            if (rdoSRvsGIN.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtStore, true);
                clsCommon.SetEnableDisable_NormalLabel(lblStore, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemName, true);
                clsCommon.SetEnableDisable_NormalLabel(lblItemName, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemType, true);
                clsCommon.SetEnableDisable_NormalLabel(lblItemType, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemCategory, true);
                clsCommon.SetEnableDisable_NormalLabel(lblItemCategory, true);
            }
            else if (rdoItemSplitNoteDelta.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtStore, true);
                clsCommon.SetEnableDisable_NormalLabel(lblStore, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemName, true);
                clsCommon.SetEnableDisable_NormalLabel(lblItemName, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemType, false);
                clsCommon.SetEnableDisable_NormalLabel(lblItemType, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemCategory, false);
                clsCommon.SetEnableDisable_NormalLabel(lblItemCategory, false);
            }          
            else if (rdoPendingLoanIn.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtStore, true);
                clsCommon.SetEnableDisable_NormalLabel(lblStore, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemName, true);
                clsCommon.SetEnableDisable_NormalLabel(lblItemName, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemType, false);
                clsCommon.SetEnableDisable_NormalLabel(lblItemType, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemCategory, false);
                clsCommon.SetEnableDisable_NormalLabel(lblItemCategory, false);
            }
            else if (rdoPendingLoanOut.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtStore, true);
                clsCommon.SetEnableDisable_NormalLabel(lblStore, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemName, true);
                clsCommon.SetEnableDisable_NormalLabel(lblItemName, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemType, false);
                clsCommon.SetEnableDisable_NormalLabel(lblItemType, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemCategory, false);
                clsCommon.SetEnableDisable_NormalLabel(lblItemCategory, false);
            }
            else if (rdo_TrackingReport_Qty.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtStore, true);
                clsCommon.SetEnableDisable_NormalLabel(lblStore, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemName, true);
                clsCommon.SetEnableDisable_NormalLabel(lblItemName, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemType, false);
                clsCommon.SetEnableDisable_NormalLabel(lblItemType, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemCategory, false);
                clsCommon.SetEnableDisable_NormalLabel(lblItemCategory, false);
            }
            else if (rdo_TrackingReport_Weight.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtStore, true);
                clsCommon.SetEnableDisable_NormalLabel(lblStore, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemName, true);
                clsCommon.SetEnableDisable_NormalLabel(lblItemName, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemType, false);
                clsCommon.SetEnableDisable_NormalLabel(lblItemType, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemCategory, false);
                clsCommon.SetEnableDisable_NormalLabel(lblItemCategory, false);
            }
            else if (rdoPOItemCostHistory.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtStore, false);
                clsCommon.SetEnableDisable_NormalLabel(lblStore, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemName, false);
                clsCommon.SetEnableDisable_NormalLabel(lblItemName, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemType, false);
                clsCommon.SetEnableDisable_NormalLabel(lblItemType, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemCategory, false);
                clsCommon.SetEnableDisable_NormalLabel(lblItemCategory, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtPoNo, true);
                clsCommon.SetEnableDisable_NormalLabel(lblPONo, true);
            }
        }
        #endregion                            

           
    } 
      
}
