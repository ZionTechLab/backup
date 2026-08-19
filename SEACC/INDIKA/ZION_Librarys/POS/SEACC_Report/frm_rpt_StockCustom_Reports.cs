using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using Digiteq_Logic;
using System.Windows.Forms;
using DataTire;
using Digiteq;
using System.Reflection;
using SEACC_Report.Excel_Class;
using SEACC_Report.Excel_DataTable;

namespace SEACC_Report
{
    public partial class frm_rpt_StockCustom_Reports : MettroForm
    {
        #region Variables
        public int iFormID;
        public bool bNoAccess;
        #endregion

        #region Form Load
        public frm_rpt_StockCustom_Reports()
        {
            iFormID = clsSecurity.getFormID(FormName.ReportStockCustom);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;
            InitializeComponent();
            
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtStore, true);
            clsCommon.SetEnableDisable_NormalLabel(lblStore, true);
        }

        private void frmReportChequeDeposit_Load(object sender, EventArgs e)
        {
            ThemeColor = clsFormatter.colorSales;

            clearField();
            DisplayReports();
        }
        #endregion

        #region Display Reports
        private void DisplayReports()
        {
            try
            {
                dgvReports.Rows.Clear();
                dgvReports.DataSource = DBHandling.ExecQuery("EXEC sp_Reports '" + 49 + "'").Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Btn Print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvReports.SelectedCells.Count != 0)
            {
                if (dgvReports.Rows.Count > 0)
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        ProgressBar.Value = 0;

                        int iRow = dgvReports.SelectedCells[0].RowIndex;
                        int iReport = int.Parse(dgvReports.Rows[iRow].Cells[0].Value.ToString());
                        enum_ReportName Report = (enum_ReportName)iReport;

                        if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(Report)))
                        {
                            string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                            if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(Report), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath, true))
                            {
                                #region Filter
                                bool bStoreSelected = false, bBranchSelected = false, bItemSelected = false, bItemCategorySelected = false;
                                string sFilter = "";

                                DateTime dtFromDate = dtpFrom.Value.Date;
                                DateTime dtToDate = dtpTo.Value.Date;
                                string sDaterange = "From  : " + dtFromDate.ToString("dd-MMM-yyyy") + " To : " + dtToDate.ToString("dd-MMM-yyyy");

                                if (txtBranch.Tag != null && txtBranch.Tag.ToString().Trim().Length > 0)
                                    bBranchSelected = true;
                                if (txtStore.Tag != null && txtStore.Tag.ToString().Trim().Length > 0)
                                    bStoreSelected = true;
                                if (txtItemCategory.Tag != null && txtItemCategory.Tag.ToString().Trim().Length > 0)
                                    bItemCategorySelected = true;
                                if (txtItemName.Tag != null && txtItemName.Tag.ToString().Trim().Length > 0)
                                    bItemSelected = true;
                                #endregion

                                #region Selected Filters  
                                if (bBranchSelected)
                                    sFilter += " Company Branch : " + txtBranch.Text.Trim();
                                if (bStoreSelected)
                                    sFilter += " Store : " + txtStore.Text.Trim();
                                if (bItemSelected)
                                    sFilter += " Item Name : " + txtItemName.Text.Trim();
                                if (bItemCategorySelected)
                                    sFilter += " Item Category : " + txtItemCategory.Text.Trim();
                                #endregion

                                #region Stock Statement Reports
                                if (Report == enum_ReportName.CU_StockStatement)
                                {
                                    List<string> sItemList = new List<string>();
                                    List<cls_scsStockStatement_DTO> lstStock = new List<cls_scsStockStatement_DTO>();

                                    #region Fill Data Object List                      

                                    List<srh_scsFlowStock> oDetail;
                                    if (txtItemName.Tag != null)
                                        oDetail = srh_scsFlowStock.Select(dtpFrom.Value.Date.AddDays(-1), txtItemName.Tag.ToString().Trim(), chkShowDeactivate.Checked ? "%" : "0", txtBranch.Tag.ToString(),true);
                                    else
                                        oDetail = srh_scsFlowStock.Select(dtpFrom.Value.Date.AddDays(-1), "%", chkShowDeactivate.Checked ? "%" : "0", txtBranch.Tag.ToString(),true);

                                    #region Detail report only

                                    sDaterange = clsFormatter.FormatDate_Short(dtpFrom.Value.Date) + " To " + clsFormatter.FormatDate_Short(dtpTo.Value.Date);
                                    decimal OpeningBalance = 0;

                                    #region Filters
                                    #region filter - Item

                                    string sItem_ID_ForDetail = "%%";
                                    string sStore_ID_ForDetail = "%%";

                                    if (txtItemName.Tag != null)
                                    {
                                        sItem_ID_ForDetail = txtItemName.Tag.ToString().Trim();
                                    }
                                    #endregion

                                    #region Filter - Store
                                    if (txtStore.Tag != null)
                                    {
                                        sStore_ID_ForDetail = txtStore.Tag.ToString().Trim();
                                    }
                                    #endregion 
                                    #endregion                                                           

                                    foreach (srh_scsFlowStock_detail oStocktxn in srh_scsFlowStock_detail.Select(dtpFrom.Value.AddDays(-1), dtpTo.Value.Date, txtBranch.Tag.ToString(), sItem_ID_ForDetail, sStore_ID_ForDetail))
                                    {
                                        #region Filter - Catagory
                                        if (txtItemCategory.Tag != null)
                                        {
                                            if (txtItemCategory.Tag.ToString().Trim() != oStocktxn.ItemCategory_ID)
                                                continue;
                                        }
                                        #endregion

                                        #region Stock
                                        decimal GRNQty = oStocktxn.NoteType == 3 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal PRNQty = oStocktxn.NoteType == 7 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal GINQty = oStocktxn.NoteType == 4 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal GTNFromQty = oStocktxn.NoteType == 15 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal GTNToQty = oStocktxn.NoteType == 16 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal AdjQty = oStocktxn.NoteType == 8 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal DGNQty = oStocktxn.NoteType == 11 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal DINQty = oStocktxn.NoteType == 17 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal ISNFromQty = oStocktxn.NoteType == 10 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal IGINQty = oStocktxn.NoteType == 6 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal IGRNQty = oStocktxn.NoteType == 5 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal FGTNQty = oStocktxn.NoteType == 13 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        #endregion

                                        #region Sales
                                        decimal DOQty = oStocktxn.NoteType == 1 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal SRNQty = oStocktxn.NoteType == 2 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        #endregion

                                        #region Production
                                        decimal PGINMin = oStocktxn.NoteType == 20 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal PGINAdd = oStocktxn.NoteType == 21 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal PGRNMin = oStocktxn.NoteType == 22 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal PGRNAdd = oStocktxn.NoteType == 23 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal SubOutMin = oStocktxn.NoteType == 24 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal SubOutAdd = oStocktxn.NoteType == 25 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal SubInReturnedMin = oStocktxn.NoteType == 35 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal SubInReturnedAdd = oStocktxn.NoteType == 26 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal SubInMin = oStocktxn.NoteType == 27 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal SubInAdd = oStocktxn.NoteType == 28 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal WIP = oStocktxn.NoteType == 29 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal WIPSemiFinished = oStocktxn.NoteType == 30 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal PFGTN = oStocktxn.NoteType == 31 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal PFGTNAcceptance = oStocktxn.NoteType == 32 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal PItemSplitAdd = oStocktxn.NoteType == 34 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        decimal PItemSplitMin = oStocktxn.NoteType == 33 ? (oStocktxn.Qty_received - oStocktxn.Qty_issued) : 0;
                                        #endregion

                                        decimal sStockTot = GRNQty + PRNQty + GINQty + GTNFromQty + GTNToQty + AdjQty + DGNQty + DINQty + ISNFromQty + IGINQty + IGRNQty + FGTNQty;
                                        decimal sSalesTot = SRNQty + DOQty;
                                        decimal sProdTot = PGINAdd + PGINMin + PGRNMin + PGRNAdd + SubOutMin + SubOutAdd + SubInReturnedMin + SubInReturnedAdd + SubInMin + SubInAdd + WIP + WIPSemiFinished + PFGTN + PFGTNAcceptance + PItemSplitAdd + PItemSplitMin;

                                        #region Other column
                                        decimal Other = 0;
                                        if (!chkSales.Checked)
                                        {
                                            Other += sSalesTot;
                                        }
                                        if (!chkStock.Checked)
                                        {
                                            Other += sStockTot;
                                        }
                                        if (!chkProduction.Checked)
                                        {
                                            Other += sProdTot;
                                        }
                                        #endregion

                                        #region Fill data object
                                        lstStock.Add(new cls_scsStockStatement_DTO()
                                        {
                                            ItemID = oStocktxn.Item_ID,
                                            ItemName = oStocktxn.ItemName,
                                            StoreID = oStocktxn.Store_ID,
                                            StoreName = clsGenaralName.getName_Store(oStocktxn.Store_ID),
                                            ItemCatID = oStocktxn.ItemCategory_ID,
                                            ItemCatName = clsGenaralName.getName_ItemCategory(oStocktxn.ItemCategory_ID),

                                            OpeningBalance = OpeningBalance,
                                            ClosingBalance = sStockTot + sSalesTot + sProdTot,
                                            UtilizedQty = (oStocktxn.Qty_received - oStocktxn.Qty_issued),

                                            GRNQty = GRNQty,
                                            PRNQty = PRNQty,
                                            GINQty = GINQty,
                                            GTNFromQty = GTNFromQty,
                                            GTNToQty = GTNToQty,
                                            AdjQty = AdjQty,
                                            DGNQty = DGNQty,
                                            DINQty = DINQty,
                                            ISNFromQty = ISNFromQty,
                                            IGINQty = IGINQty,
                                            IGRNQty = IGRNQty,
                                            FGTNQty = FGTNQty,

                                            DOQty = DOQty,
                                            SRNQty = SRNQty,

                                            PGINMin = PGINMin,
                                            PGINAdd = PGINAdd,
                                            PGRNMin = PGRNMin,
                                            PGRNAdd = PGRNAdd,
                                            SubOutMin = SubOutMin,
                                            SubOutAdd = SubOutAdd,
                                            SubInReturnedMin = SubInReturnedMin,
                                            SubInReturnedAdd = SubInReturnedAdd,
                                            SubInMin = SubInMin,
                                            SubInAdd = SubInAdd,
                                            WIP = WIP,
                                            WIPSemiFinished = WIPSemiFinished,
                                            PFGTN = PFGTN,
                                            PFGTNAcceptance = PFGTNAcceptance,
                                            PItemSplitAdd = PItemSplitAdd,
                                            PItemSplitMin = PItemSplitMin,

                                            Other = Other,
                                        });
                                        #endregion

                                        #region Transaction Validation
                                        if (chkTransactionValidateEnable.Checked)
                                        {
                                            if (!sItemList.Contains(oStocktxn.Item_ID))
                                                sItemList.Add(oStocktxn.Item_ID);
                                        }
                                        #endregion
                                    }

                                    #endregion

                                    #region Openning Balance
                                    foreach (var oStock in oDetail.GroupBy(cm => new { cm.Item_ID, cm.ItemName, cm.Brand_ID, cm.Store_ID, cm.ItemCategory_ID, cm.ItemCategorySub_ID, cm.ItemSubCategory2_ID, cm.ItemSerialNo, cm.ItemSerialNo2, cm.ItemType_ID, cm.Uom, cm.IsWeightCalculation }, (key, group) => new { itemId = key.Item_ID, itemName = key.ItemName, brandId = key.Brand_ID, storeID = key.Store_ID, itemCatID = key.ItemCategory_ID, itemSubcat1 = key.ItemCategorySub_ID, itemSubcat2 = key.ItemSubCategory2_ID, itemSerialNo1 = key.ItemSerialNo, itemSerialNo2 = key.ItemSerialNo2, typeId = key.ItemType_ID, uom = key.Uom, qty = group.Sum(p => p.Qty), waight = group.Sum(p => p.Weight), isWaight = key.IsWeightCalculation }).ToList())
                                    {
                                        if (!chkShowAll.Checked)
                                        {
                                            if (oStock.waight == 0 && oStock.qty == 0)
                                                continue;
                                        }

                                        #region Transaction Validation
                                        if (chkTransactionValidateEnable.Checked)
                                        {
                                            if (!sItemList.Contains(oStock.itemId))
                                                continue;
                                        }
                                        #endregion

                                        #region Filters
                                        #region filter - Item
                                        if (txtItemName.Tag != null)
                                        {
                                            if (txtItemName.Tag.ToString().Trim() != oStock.itemId)
                                                continue;
                                        }
                                        #endregion

                                        #region Filter - Store
                                        if (txtStore.Tag != null)
                                        {
                                            if (txtStore.Tag.ToString().Trim() != oStock.storeID)
                                                continue;
                                        }
                                        #endregion

                                        #region Filter - Catagory
                                        if (txtItemCategory.Tag != null)
                                        {
                                            if (txtItemCategory.Tag.ToString().Trim() != oStock.itemCatID)
                                                continue;
                                        }
                                        #endregion
                                        #endregion

                                        #region Fill data object
                                        lstStock.Add(new cls_scsStockStatement_DTO()
                                        {
                                            ItemID = oStock.itemId,
                                            ItemName = oStock.itemName,
                                            StoreID = oStock.storeID,
                                            StoreName = clsGenaralName.getName_Store(oStock.storeID),
                                            ItemCatID = oStock.itemCatID,
                                            ItemCatName = clsGenaralName.getName_ItemCategory(oStock.itemCatID),

                                            OpeningBalance = oStock.qty,
                                            ClosingBalance = 0,
                                            UtilizedQty = 0,

                                            GRNQty = 0,
                                            PRNQty = 0,
                                            GINQty = 0,
                                            GTNFromQty = 0,
                                            GTNToQty = 0,
                                            AdjQty = 0,
                                            DGNQty = 0,
                                            DINQty = 0,
                                            ISNFromQty = 0,
                                            IGINQty = 0,
                                            IGRNQty = 0,
                                            FGTNQty = 0,

                                            DOQty = 0,
                                            SRNQty = 0,

                                            PGINMin = 0,
                                            PGINAdd = 0,
                                            PGRNMin = 0,
                                            PGRNAdd = 0,
                                            SubOutMin = 0,
                                            SubOutAdd = 0,
                                            SubInReturnedMin = 0,
                                            SubInReturnedAdd = 0,
                                            SubInMin = 0,
                                            SubInAdd = 0,
                                            WIP = 0,
                                            WIPSemiFinished = 0,
                                            PFGTN = 0,
                                            PFGTNAcceptance = 0,
                                            PItemSplitAdd = 0,
                                            PItemSplitMin = 0,

                                            Other = 0,

                                        });
                                        #endregion
                                    }

                                    #endregion
                                    
                                    ProgressBar.Value = 0;

                                    #endregion

                                    #region Print Section

                                    if (lstStock.Count > 0)
                                        cls_sasStockStatement.Run_StockStatement(lstStock, dtFromDate, dtToDate, sReportTitle_Main, !chkSales.Checked, !chkStock.Checked, !chkProduction.Checked);
                                    else
                                        MessageBox.Show("Data Not Found", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    #endregion

                                }
                                #endregion

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID, ex);
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        ProgressBar.Value = 0;
                        Cursor = Cursors.Arrow;
                    }
                }
            }
        }
        #endregion

        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearField();

            dtpFrom.Value = clsSecurity.getServerDateTime();
            dtpTo.Value = clsSecurity.getServerDateTime();
        }
        #endregion

        #region ClearField
        private void clearField()
        {
            txtBranch.Tag = clsSecurity.BranchID;
            txtStore.Tag = null;
            txtItemCategory.Tag = null;
            txtItemName.Tag = null;

            txtBranch.Text = clsSecurity.BranchName;
            txtStore.Text = "<All Stores>";
            txtItemCategory.Text = "<All Item Categories>";
            txtItemName.Text = "<All Items>";

            clsCommon.SetEnableDisable_NormalCheckBox(chkShowAll, true);
            chkTransactionValidateEnable.Checked = true;
            //clsCommon.SetVisibility_Panel(pnlStore, false);

            //clsCommon.SetVisibility_Panel(pnlFromDate, false);
            //clsCommon.SetVisibility_Panel(pnlToDate, false);

            //clsCommon.SetVisibility_Panel(pnlShowAllBranch, false);
            //clsCommon.SetVisibility_Panel(pnlBranch, false);

            //clsCommon.SetVisibility_Panel(pnlItemName, false);
            //clsCommon.SetVisibility_Panel(pnlItemCategory, false);

            chkShowAll.Checked = false;
            txtItemCategory.Enabled = true;

            tbl_genCompanyBranchMaster oBranch = tbl_genCompanyBranchMaster.Select(clsSecurity.BranchID);
            if (oBranch != null)
            {
                if (!oBranch.IsHeadOffice)
                {
                    clsCommon.SetEnableDisable_NormalLabel(lblBranch, false);
                    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtBranch, false);
                    clsCommon.SetEnableDisable_NormalCheckBox(chkShowAll, false);
                }
            }
        }
        #endregion

        #region KeyDown Events
        private void txt_Customer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CustomerID();
        }
        private void txtSalesRep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SalesRepID();
        }
        private void frm_rpt_ChequeManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void txtSalesNoteType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SalesNoteType();
        }


        private void txtRoute_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Routes();
        }
        #endregion

        #region Events DoublClick
        private void txtBranch_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_CompanyBranch(ref txtBranch);
        }
        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
        }
        private void txtSalesRep_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesRepID();
        }
        private void txtSalesNoteType_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesNoteType();
        }
        private void txtCusClass_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerClassID();
        }
        private void txtCusType_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerTypeID();
        }
        private void txtCusCategory_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerCategoryID();
        }
        private void txtRoute_DoubleClick(object sender, EventArgs e)
        {
            Search_Routes();
        }
        #endregion

        #region Search Methods
        private void Search_CustomerID()
        {
            
        }

        private void Search_SalesRepID()
        {
           
        }

        private void Search_SalesNoteType()
        {
            clsSearch.Search_MasterSalesNoteType(ref txtStore);
        }

        private void Search_CustomerClassID()
        {
           
        }

        private void Search_CustomerTypeID()
        {
           
        }

        private void Search_CustomerCategoryID()
        {
           
        }


        private void Search_Routes()
        {
           
        }

        private void txtItemCategory_DoubleClick(object sender, EventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ItemCategory);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtItemCategory.Tag = lstResult[0];
                txtItemCategory.Text = lstResult[1];
            }
        }

        private void txtItemName_DoubleClick(object sender, EventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            frmSearch RowDataSearch = null;

            lstParameeters.Add(clsSecurity.BranchID);

            lstParameeters.Add("%%");
            lstParameeters.Add("%%");
            lstParameeters.Add(txtItemCategory.Tag == null ? "%%" : txtItemCategory.Tag.ToString());

            lstParameeters.Add("0");

            RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.ItemMasterByCategories);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtItemName.Tag = lstResult[0];
                txtItemName.Text = lstResult[1];
            }

            if (txtItemName.Tag != null)
            {
                tbl_genItemMaster detail = tbl_genItemMaster.Select(txtItemName.Tag.ToString());
                if (detail != null && detail.Item_ID != "default")
                {
                    txtItemCategory.Tag = detail.ItemCategory_ID;
                    txtItemCategory.Text = clsGenaralName.getName_ItemCategory(detail.ItemCategory_ID);

                    txtItemCategory.Enabled = false;
                }
            }
        }

        private void txtStore_DoubleClick(object sender, EventArgs e)
        {
            if (clsConfig.bShowAll_branches_storeSearch)
                clsSearch.Search_MasterStore(ref txtStore, false);
            else
                clsSearch.Search_MasterStore(ref txtStore, true);
        }
        #endregion

        #region Set Enable/Disable Controls
        private void setEnableDisableConctrol(int iReportID)
        {
            clearField();

            if (iReportID == (int)enum_ReportName.CU_StockStatement)
            {
                clsCommon.SetVisibility_Panel(pnlItemName, true);
                clsCommon.SetVisibility_Panel(pnlItemCategory, true);
                clsCommon.SetVisibility_Panel(pnlFromDate, true);
                clsCommon.SetVisibility_Panel(pnlToDate, true);                
            }
        }
        #endregion

        #region Data Grid Event
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
        #endregion

        #region Checked Changes
        private void chkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowAll.Checked == true)
            {
                clsCommon.SetVisibility_Panel(pnlBranch, false);
                txtBranch.Text = "<All Company Branches>";
                txtBranch.Tag = null;
            }
            else
            {
                clsCommon.SetVisibility_Panel(pnlBranch, true);
                txtBranch.Tag = clsSecurity.BranchID;
                txtBranch.Text = clsSecurity.BranchName;
            }
        }
        #endregion

        #region Help Methods
        public List<string> GetMonthYear(DateTime dtStart, DateTime dtEnd)
        {

            List<string> monthList = new List<string>();
            for (DateTime dt = dtStart; dt <= dtEnd; dt = dt.AddMonths(1))
            {
                monthList.Add(dt.ToString("MMMM yyyy"));
            }

            return monthList;
        }

        #endregion

      
    }
}






#region Fill Data Object List
//#region Invoice
//foreach (tbl_sasInvoice oInvoice in oInvoiceList)
//{
//    string sSalesmanID = "";
//    tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oInvoice.Customer_ID).FirstOrDefault();
//    if (oCustomer != null)
//    {


//        #region Filters
//        #region Customer Filters
//        if (bCustomerClassSelected)
//            if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
//                continue;
//        if (bCustomerTypeSelected)
//            if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
//                continue;
//        if (bCustomerCategorySelected)
//            if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
//                continue;
//        #endregion

//        #region Sales Rep Filter
//        if (!chkUseCustomerMastorSaleRep.Checked)
//        {
//            tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
//            if (oRef != null && oRef.OrderRefNo_ID != "default")
//                sSalesmanID = oRef.Employee_ID;
//        }
//        else
//            sSalesmanID = oCustomer.SalesRep_ID;

//        if (bSelesRepSelected)
//            if (txtSalesRep.Tag.ToString() != sSalesmanID)
//                continue;
//        #endregion

//        #region Sales Note Filter
//        if (bSalesNoteTypeSelected)
//            if (txtSalesNoteType.Tag.ToString() != oInvoice.SalesNoteType_ID)
//                continue;
//        #endregion
//        #endregion

//        #region Tax
//        bool bVATable = false, bNBTable = false, bSVATable = false;
//        if (oInvoice.IsVatInvoice)
//        {
//            bVATable = true;
//            bNBTable = true;
//        }
//        else if (oInvoice.IsSVatInvoice)
//        {
//            bSVATable = true;
//            bNBTable = true;
//        }
//        #endregion

//        #region Detail Fill
//        decimal TotalQty = tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID).Sum(p => p.Qty);
//        decimal dNBTAmount = 0, dVATAmount = 0, dSVATAmount = 0, dSubTotal = 0, dBulkDiscount = 0;

//        clsHelpMethods.CalculateGrandTotalReverce(oInvoice.GrandTotal, ref dVATAmount, oInvoice.VatPercentage, bVATable, ref dSVATAmount, oInvoice.OtherTaxPercentage, bSVATable, ref dNBTAmount, oInvoice.NbtPercentage, bNBTable, ref dBulkDiscount, 0, ref dSubTotal);

//        lstSales.Add(new cls_sasSalesReportSummary_DTO()
//        {
//            TxType = "1-Sales",
//            Branch = clsGenaralName.getName_CompanyBranchMaster(oInvoice.CompanyBranch_ID),
//            Tx_ID = oInvoice.Invoice_ID,
//            TxDate = oInvoice.InvoiceDate.Date,
//            SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
//            Customer = clsGenaralName.getName_Customer(oInvoice.Customer_ID),
//            CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
//            CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
//            CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

//            Sale = dSubTotal,
//            SalesReturn = 0,
//            CreditNote = 0,
//            DebitNote = 0,

//            SalesQty = TotalQty,
//            ReturnQty = 0,
//        });
//        #endregion

//        clsHelpMethods_Local.startProgressBar(0, oInvoiceList.Count, 1, ProgressBar);
//    }
//}
//ProgressBar.Value = 0;
//#endregion
//#region SRN
//foreach (tbl_sasSalesReturnedNote oSrn in oSrnList.Where(p => p.IsApproved == true))
//{
//    string sSalesmanID = "";
//    tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oSrn.Customer_ID).FirstOrDefault();
//    if (oCustomer != null)
//    {
//        #region Filters
//        #region Customer Filters
//        if (bCustomerClassSelected)
//            if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
//                continue;
//        if (bCustomerTypeSelected)
//            if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
//                continue;
//        if (bCustomerCategorySelected)
//            if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
//                continue;
//        #endregion

//        #region Sales Rep Filter
//        if (!chkUseCustomerMastorSaleRep.Checked)
//        {
//            tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oSrn.OrderRefNo_ID);
//            if (oRef != null && oRef.OrderRefNo_ID != "default")
//                sSalesmanID = oRef.Employee_ID;
//        }
//        else
//            sSalesmanID = oCustomer.SalesRep_ID;


//        if (bSelesRepSelected)
//            if (txtSalesRep.Tag.ToString() != sSalesmanID)
//                continue;
//        #endregion

//        #region Sales Note Filter
//        if (bSalesNoteTypeSelected)
//            if (txtSalesNoteType.Tag.ToString() != oSrn.SalesNoteType_ID)
//                continue;
//        #endregion
//        #endregion

//        #region Tax
//        bool bVATable = false, bNBTable = false, bSVATable = false;
//        if (oSrn.VatTotal > 0)
//        {
//            bVATable = true;
//            bNBTable = true;
//        }
//        else if (oSrn.OtherTaxTotal > 0)
//        {
//            bSVATable = true;
//            bNBTable = true;
//        }
//        #endregion

//        #region Detail Fill
//        decimal TotalQty = tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSrn.SalesReturnedNote_ID).Sum(p => p.Qty);
//        decimal dNBTAmount = 0, dVATAmount = 0, dSVATAmount = 0, dSubTotal = 0, dBulkDiscount = 0;
//        clsHelpMethods.CalculateGrandTotalReverce(oSrn.GrandTotal, ref dVATAmount, oSrn.VatPercentage, bVATable, ref dSVATAmount, oSrn.OtherTaxPercentage, bSVATable, ref dNBTAmount, oSrn.NbtPercentage, bNBTable, ref dBulkDiscount, 0, ref dSubTotal);

//        lstSales.Add(new cls_sasSalesReportSummary_DTO()
//        {
//            TxType = "2-Sales Return",
//            Branch = clsGenaralName.getName_CompanyBranchMaster(oSrn.CompanyBranch_ID),
//            Tx_ID = oSrn.SalesReturnedNote_ID,
//            TxDate = oSrn.SalesReturnedNoteDate.Date,
//            SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
//            Customer = clsGenaralName.getName_Customer(oSrn.Customer_ID),
//            CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
//            CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
//            CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

//            Sale = 0,
//            SalesReturn = dSubTotal,
//            CreditNote = 0,
//            DebitNote = 0,

//            SalesQty = 0,
//            ReturnQty = TotalQty
//        });
//        #endregion

//        clsHelpMethods_Local.startProgressBar(0, oSrnList.Count, 1, ProgressBar);
//    }
//}
//ProgressBar.Value = 0;
//#endregion
//#region CRN
//foreach (tbl_bpsCreditNote oCrn in oCrnList.Where(p => p.SalesReturnedNote_ID == "default" && p.PosReturnTransaction_Index == -1 && p.AdvanceReceived_Index == -1 && p.CreditNoteType_ID == "TP/002" || p.CreditNoteType_ID == "TP/007" || p.CreditNoteType_ID == "TP/004" || p.CreditNoteType_ID == "TP/005"))
//{
//    string sSalesmanID = "";
//    tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oCrn.Customer_ID).FirstOrDefault();
//    if (oCustomer != null)
//    {
//        #region Filters
//        #region Customer Filters
//        if (bCustomerClassSelected)
//            if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
//                continue;
//        if (bCustomerTypeSelected)
//            if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
//                continue;
//        if (bCustomerCategorySelected)
//            if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
//                continue;
//        #endregion

//        #region Sales Rep Filter
//        if (!chkUseCustomerMastorSaleRep.Checked)
//        {
//            tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oCrn.OrderRefNo_ID);
//            if (oRef != null && oRef.OrderRefNo_ID != "default")
//                sSalesmanID = oRef.Employee_ID;
//        }
//        else
//            sSalesmanID = oCustomer.SalesRep_ID;


//        if (bSelesRepSelected)
//            if (txtSalesRep.Tag.ToString() != sSalesmanID)
//                continue;
//        #endregion

//        #region Sales Note Filter
//        if (bSalesNoteTypeSelected)
//            if (txtSalesNoteType.Tag.ToString() != oCrn.SalesNoteType_ID)
//                continue;
//        #endregion
//        #endregion

//        #region Tax
//        bool bVATable = false, bNBTable = false, bSVATable = false;
//        if (oCrn.VatTotal > 0)
//        {
//            bVATable = true;
//            bNBTable = true;
//        }
//        else if (oCrn.OtherTaxTotal > 0)
//        {
//            bSVATable = true;
//            bNBTable = true;
//        }
//        #endregion

//        #region Detail Fill
//        decimal dNBTAmount = 0, dVATAmount = 0, dSVATAmount = 0, dSubTotal = 0, dBulkDiscount = 0;
//        clsHelpMethods.CalculateGrandTotalReverce(oCrn.TotalAmount, ref dVATAmount, oCrn.VatPercentage, bVATable, ref dSVATAmount, oCrn.OtherTaxPercentage, bSVATable, ref dNBTAmount, oCrn.NbtPercentage, bNBTable, ref dBulkDiscount, 0, ref dSubTotal);

//        lstSales.Add(new cls_sasSalesReportSummary_DTO()
//        {
//            TxType = "3-Credit Note",
//            Branch = clsGenaralName.getName_CompanyBranchMaster(oCrn.CompanyBranch_ID),
//            Tx_ID = oCrn.CreditNote_ID,
//            TxDate = oCrn.CreditNoteDate.Date,
//            SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
//            Customer = clsGenaralName.getName_Customer(oCrn.Customer_ID),
//            CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
//            CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
//            CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

//            Sale = 0,
//            SalesReturn = 0,
//            CreditNote = dSubTotal,
//            DebitNote = 0,

//            SalesQty = 0,
//            ReturnQty = 0
//        });
//        #endregion

//        clsHelpMethods_Local.startProgressBar(0, oCrnList.Count, 1, ProgressBar);
//    }
//}
//ProgressBar.Value = 0;
//#endregion
//#region DBN
//foreach (tbl_bpsDebitNote oDbn in oDbnList.Where(p => p.DebitNoteType_ID == "TP/003"))
//{
//    string sSalesmanID = "";
//    tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oDbn.Customer_ID).FirstOrDefault();
//    if (oCustomer != null)
//    {
//        #region Filters
//        #region Customer Filters
//        if (bCustomerClassSelected)
//            if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
//                continue;
//        if (bCustomerTypeSelected)
//            if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
//                continue;
//        if (bCustomerCategorySelected)
//            if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
//                continue;
//        #endregion

//        #region Sales Rep Filter
//        if (!chkUseCustomerMastorSaleRep.Checked)
//        {
//            tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oDbn.OrderRefNo_ID);
//            if (oRef != null && oRef.OrderRefNo_ID != "default")
//                sSalesmanID = oRef.Employee_ID;
//        }
//        else
//            sSalesmanID = oCustomer.SalesRep_ID;


//        if (bSelesRepSelected)
//            if (txtSalesRep.Tag.ToString() != sSalesmanID)
//                continue;
//        #endregion

//        #region Sales Note Filter
//        if (bSalesNoteTypeSelected)
//            if (txtSalesNoteType.Tag.ToString() != oDbn.SalesNoteType_ID)
//                continue;
//        #endregion
//        #endregion

//        #region Tax
//        bool bVATable = false, bNBTable = false, bSVATable = false;
//        if (oDbn.VatTotal > 0)
//        {
//            bVATable = true;
//            bNBTable = true;
//        }
//        else if (oDbn.OtherTaxTotal > 0)
//        {
//            bSVATable = true;
//            bNBTable = true;
//        }
//        #endregion

//        #region Detail Fill
//        decimal dNBTAmount = 0, dVATAmount = 0, dSVATAmount = 0, dSubTotal = 0, dBulkDiscount = 0;
//        clsHelpMethods.CalculateGrandTotalReverce(oDbn.TotalAmount, ref dVATAmount, oDbn.VatPercentage, bVATable, ref dSVATAmount, oDbn.OtherTaxPercentage, bSVATable, ref dNBTAmount, oDbn.NbtPercentage, bNBTable, ref dBulkDiscount, 0, ref dSubTotal);

//        lstSales.Add(new cls_sasSalesReportSummary_DTO()
//        {
//            TxType = "4-Debit Note",
//            Branch = clsGenaralName.getName_CompanyBranchMaster(oDbn.CompanyBranch_ID),
//            Tx_ID = oDbn.DebitNote_ID,
//            TxDate = oDbn.DebitNoteDate.Date,
//            SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
//            Customer = clsGenaralName.getName_Customer(oDbn.Customer_ID),
//            CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
//            CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
//            CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

//            Sale = 0,
//            SalesReturn = 0,
//            CreditNote = 0,
//            DebitNote = dSubTotal,

//            SalesQty = 0,
//            ReturnQty = 0
//        });
//        #endregion

//        clsHelpMethods_Local.startProgressBar(0, oDbnList.Count, 1, ProgressBar);
//    }
//}
//ProgressBar.Value = 0;
//#endregion
//#region POS Sales & Return
//foreach (tbl_posTransaction oPOS in oPosList)
//{
//    string sSalesmanID = "";
//    tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oPOS.Customer_ID).FirstOrDefault();
//    if (oCustomer != null)
//    {
//        #region Filters
//        #region Customer Filters
//        if (bCustomerClassSelected)
//            if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
//                continue;
//        if (bCustomerTypeSelected)
//            if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
//                continue;
//        if (bCustomerCategorySelected)
//            if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
//                continue;
//        #endregion

//        #region Sales Rep Filter
//        if (!chkUseCustomerMastorSaleRep.Checked)
//        {
//            tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oPOS.OrderRefNo_ID);
//            if (oRef != null && oRef.OrderRefNo_ID != "default")
//                sSalesmanID = oRef.Employee_ID;
//        }
//        else
//            sSalesmanID = oCustomer.SalesRep_ID;


//        if (bSelesRepSelected)
//            if (txtSalesRep.Tag.ToString() != sSalesmanID)
//                continue;
//        #endregion

//        #region Sales Note Filter
//        if (bSalesNoteTypeSelected)
//            if (txtSalesNoteType.Tag.ToString() != oPOS.SalesNoteType_ID)
//                continue;
//        #endregion
//        #endregion

//        #region Tax
//        bool bVATable = false, bNBTable = false, bSVATable = false;
//        if (oPOS.VatTotal > 0)
//        {
//            bVATable = true;
//            bNBTable = true;
//        }
//        else if (oPOS.OtherTaxTotal > 0)
//        {
//            bSVATable = true;
//            bNBTable = true;
//        }
//        #endregion

//        #region Fill Detail
//        decimal TotalQty = tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(oPOS.PosTransaction_Index).Sum(p => p.Qty);
//        decimal dNBTAmount = 0, dVATAmount = 0, dSVATAmount = 0, dSubTotal = 0, dBulkDiscount = 0;
//        clsHelpMethods.CalculateGrandTotalReverce(oPOS.GrandTotal, ref dVATAmount, oPOS.VatPercentage, bVATable, ref dSVATAmount, oPOS.OtherTaxPercentage, bSVATable, ref dNBTAmount, oPOS.NbtPercentage, bNBTable, ref dBulkDiscount, 0, ref dSubTotal);

//        lstSales.Add(new cls_sasSalesReportSummary_DTO()
//        {
//            TxType = "5-POS Sales & Return",
//            Branch = clsGenaralName.getName_CompanyBranchMaster(oPOS.CompanyBranch_ID),
//            Tx_ID = oPOS.PosTransaction_ID,
//            TxDate = oPOS.PosTransactiondate.Date,
//            SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
//            Customer = clsGenaralName.getName_Customer(oPOS.Customer_ID),
//            CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
//            CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
//            CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

//            Sale = !oPOS.IsReturnedPOS_Invoice ? dSubTotal : 0,
//            SalesReturn = oPOS.IsReturnedPOS_Invoice ? dSubTotal * -1 : 0,
//            CreditNote = 0,
//            DebitNote = 0,

//            SalesQty = !oPOS.IsReturnedPOS_Invoice ? TotalQty : 0,
//            ReturnQty = oPOS.IsReturnedPOS_Invoice ? (TotalQty * -1) : 0
//        });


//        foreach (tbl_posReceipt oReceipt in tbl_posReceipt.SelectAllByPosTransaction_Index(oPOS.PosTransaction_Index))
//        {
//            foreach (tbl_bpsChequeRegister oChequeRegister in tbl_bpsChequeRegister.SelectAllByPosReceipt_ID(oReceipt.PosReceipt_ID).Where(p => p.PaymentMethod_ID == (int)PaymentMethod.Gift_Voucher))
//            {
//                decimal dNBTAmount2 = 0, dVATAmount2 = 0, dSVATAmount2 = 0, dSubTotal2 = 0, dBulkDiscount2 = 0;
//                clsHelpMethods.CalculateGrandTotalReverce(oChequeRegister.Amount, ref dVATAmount2, oPOS.VatPercentage, bVATable, ref dSVATAmount2, oPOS.OtherTaxPercentage, bSVATable, ref dNBTAmount2, oPOS.NbtPercentage, bNBTable, ref dBulkDiscount2, 0, ref dSubTotal2);

//                lstSales.Add(new cls_sasSalesReportSummary_DTO()
//                {
//                    TxType = "5-POS Sales & Return",
//                    Branch = clsGenaralName.getName_CompanyBranchMaster(oPOS.CompanyBranch_ID),
//                    Tx_ID = oPOS.PosTransaction_ID,
//                    TxDate = oPOS.PosTransactiondate.Date,
//                    SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
//                    Customer = clsGenaralName.getName_Customer(oPOS.Customer_ID),
//                    CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
//                    CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
//                    CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

//                    Sale = !oPOS.IsReturnedPOS_Invoice ? -dSubTotal2 : 0,
//                    SalesReturn = 0,
//                    CreditNote = 0,
//                    DebitNote = 0,

//                    SalesQty = 0,
//                    ReturnQty = 0
//                });
//            }
//        }
//        #endregion

//        clsHelpMethods_Local.startProgressBar(0, oPosList.Count, 1, ProgressBar);
//    }
//}
//ProgressBar.Value = 0;
//#endregion
#endregion

#region Sales Summary Report - YTD
//else if (Report == enum_ReportName.CU_SalesSummaryReport_YTD)
//{
//    //Create list of Data Ojects
//    List<cls_sasSalesReportSummaryYTD_DTO> lstSales = new List<cls_sasSalesReportSummaryYTD_DTO>();

//    #region Fill Data Object List
//    #region Invoice
//    foreach (tbl_sasInvoice oInvoice in oInvoiceList)
//    {
//        string sSalesmanID = "";
//        tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oInvoice.Customer_ID).FirstOrDefault();
//        if (oCustomer != null)
//        {
//            #region Filters
//            #region Customer Filters
//            if (bCustomerClassSelected)
//                if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
//                    continue;
//            if (bCustomerTypeSelected)
//                if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
//                    continue;
//            if (bCustomerCategorySelected)
//                if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
//                    continue;
//            #endregion

//            #region Sales Rep Filter
//            if (!chkUseCustomerMastorSaleRep.Checked)
//            {
//                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
//                if (oRef != null && oRef.OrderRefNo_ID != "default")
//                    sSalesmanID = oRef.Employee_ID;
//            }
//            else
//                sSalesmanID = oCustomer.SalesRep_ID;


//            if (bSelesRepSelected)
//                if (txtSalesRep.Tag.ToString() != sSalesmanID)
//                    continue;
//            #endregion

//            #region Sales Note Filter
//            if (bSalesNoteTypeSelected)
//                if (txtSalesNoteType.Tag.ToString() != oInvoice.SalesNoteType_ID)
//                    continue;
//            #endregion
//            #endregion

//            #region Detail Fill
//            decimal TotalQty = tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID).Sum(p => p.Qty);
//            decimal dGrandTotalWithout_Tax = oInvoice.GrandTotal - (oInvoice.VatTotal - oInvoice.NbtTotal);

//            lstSales.Add(new cls_sasSalesReportSummaryYTD_DTO()
//            {
//                TxType = "1-Sales",
//                Tx_ID = oInvoice.Invoice_ID,
//                TxDate = oInvoice.InvoiceDate.Date,
//                SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
//                Customer = clsGenaralName.getName_Customer(oInvoice.Customer_ID),
//                CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
//                CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
//                CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

//                Sales = dGrandTotalWithout_Tax,
//                SalesReturn = 0,

//                SalesQty = TotalQty,
//                ReturnQty = 0
//            });
//            #endregion

//            clsHelpMethods_Local.startProgressBar(0, oInvoiceList.Count, 1, ProgressBar);
//        }
//    }
//    ProgressBar.Value = 0;
//    #endregion

//    #region SRN
//    foreach (tbl_sasSalesReturnedNote oSrn in oSrnList)
//    {
//        string sSalesmanID = "";
//        tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oSrn.Customer_ID).FirstOrDefault();
//        if (oCustomer != null)
//        {
//            #region Filters
//            #region Customer Filters
//            if (bCustomerClassSelected)
//                if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
//                    continue;
//            if (bCustomerTypeSelected)
//                if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
//                    continue;
//            if (bCustomerCategorySelected)
//                if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
//                    continue;
//            #endregion

//            #region Sales Rep Filter
//            if (!chkUseCustomerMastorSaleRep.Checked)
//            {
//                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oSrn.OrderRefNo_ID);
//                if (oRef != null && oRef.OrderRefNo_ID != "default")
//                    sSalesmanID = oRef.Employee_ID;
//            }
//            else
//                sSalesmanID = oCustomer.SalesRep_ID;


//            if (bSelesRepSelected)
//                if (txtSalesRep.Tag.ToString() != sSalesmanID)
//                    continue;
//            #endregion

//            #region Sales Note Filter
//            if (bSalesNoteTypeSelected)
//                if (txtSalesNoteType.Tag.ToString() != oSrn.SalesNoteType_ID)
//                    continue;
//            #endregion
//            #endregion

//            #region Detail Fill
//            decimal TotalQty = tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSrn.SalesReturnedNote_ID).Sum(p => p.Qty);
//            decimal dGrandTotalWithout_Tax = oSrn.GrandTotal - (oSrn.VatTotal - oSrn.NbtTotal);

//            lstSales.Add(new cls_sasSalesReportSummaryYTD_DTO()
//            {
//                TxType = "2-Sales Return",
//                Tx_ID = oSrn.SalesReturnedNote_ID,
//                TxDate = oSrn.SalesReturnedNoteDate.Date,
//                SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
//                Customer = clsGenaralName.getName_Customer(oSrn.Customer_ID),
//                CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
//                CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
//                CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

//                Sales = 0,
//                SalesReturn = dGrandTotalWithout_Tax,

//                SalesQty = 0,
//                ReturnQty = -TotalQty

//            });
//            #endregion

//            clsHelpMethods_Local.startProgressBar(0, oSrnList.Count, 1, ProgressBar);
//        }
//    }
//    ProgressBar.Value = 0;
//    #endregion

//    #region POS Sales
//    foreach (tbl_posTransaction oPOS in oPosList)
//    {
//        string sSalesmanID = "";
//        tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oPOS.Customer_ID).FirstOrDefault();
//        if (oCustomer != null)
//        {
//            #region Filters
//            #region Customer Filters
//            if (bCustomerClassSelected)
//                if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
//                    continue;
//            if (bCustomerTypeSelected)
//                if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
//                    continue;
//            if (bCustomerCategorySelected)
//                if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
//                    continue;
//            #endregion

//            #region Sales Rep Filter
//            if (!chkUseCustomerMastorSaleRep.Checked)
//            {
//                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oPOS.OrderRefNo_ID);
//                if (oRef != null && oRef.OrderRefNo_ID != "default")
//                    sSalesmanID = oRef.Employee_ID;
//            }
//            else
//                sSalesmanID = oCustomer.SalesRep_ID;


//            if (bSelesRepSelected)
//                if (txtSalesRep.Tag.ToString() != sSalesmanID)
//                    continue;
//            #endregion

//            #region Sales Note Filter
//            if (bSalesNoteTypeSelected)
//                if (txtSalesNoteType.Tag.ToString() != oPOS.SalesNoteType_ID)
//                    continue;
//            #endregion
//            #endregion

//            #region Fill Detail
//            decimal dGrandTotalWithout_Tax = 0, BulkDiscount = oPOS.DiscountTotal;
//            decimal dWithNbtAmount = 0, dNbtAmount = 0, dVatAmount = 0;

//            decimal TotalQty = tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(oPOS.PosTransaction_Index).Sum(p => p.Qty);
//            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oPOS.GrandTotal, oPOS.VatPercentage, oPOS.NbtPercentage, ref dWithNbtAmount, ref dGrandTotalWithout_Tax, ref dNbtAmount, ref dVatAmount);

//            lstSales.Add(new cls_sasSalesReportSummaryYTD_DTO()
//            {
//                TxType = "3-POS Sales & Return",
//                Tx_ID = oPOS.PosTransaction_ID,
//                TxDate = oPOS.PosTransactiondate.Date,
//                SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
//                Customer = clsGenaralName.getName_Customer(oPOS.Customer_ID),
//                CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
//                CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
//                CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

//                Sales = !oPOS.IsReturnedPOS_Invoice ? dGrandTotalWithout_Tax : 0,
//                SalesReturn = oPOS.IsReturnedPOS_Invoice ? (dGrandTotalWithout_Tax * -1) : 0,

//                SalesQty = !oPOS.IsReturnedPOS_Invoice ? TotalQty : 0,
//                ReturnQty = oPOS.IsReturnedPOS_Invoice ? (TotalQty * -1) : 0,

//                TotalCollection = 0,
//                TotalOutstanding = 0,
//                PostDatedCheques = 0,
//                UnrealizeCheques = 0,

//                CreditRisk = 0
//            });
//            #endregion

//            clsHelpMethods_Local.startProgressBar(0, oPosList.Count, 1, ProgressBar);
//        }
//    }
//    ProgressBar.Value = 0;
//    #endregion

//    #region Grouping List
//    List<cls_sasSalesReportSummaryYTD_DTO_Temp> lstTemp = lstSales.GroupBy(r => new { r.TxDate.Month, r.SalesRep, r.CustomerClass, r.CustomerType, r.CustomerCategory })
//                                    .Select(grp => new cls_sasSalesReportSummaryYTD_DTO_Temp
//                                    {
//                                        //Month = clsFormatter.GetMonthName(grp.Key.Month),
//                                        SalesRep = grp.Key.SalesRep,
//                                        CustomerClass = grp.Key.CustomerClass,
//                                        CustomerType = grp.Key.CustomerType,
//                                        CustomerCategory = grp.Key.CustomerCategory,

//                                        //TotalSales = grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn),

//                                        April = grp.Key.Month == 4 ? grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn) : 0,
//                                        May = grp.Key.Month == 5 ? grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn) : 0,
//                                        June = grp.Key.Month == 6 ? grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn) : 0,
//                                        July = grp.Key.Month == 7 ? grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn) : 0,
//                                        August = grp.Key.Month == 8 ? grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn) : 0,
//                                        September = grp.Key.Month == 9 ? grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn) : 0,
//                                        October = grp.Key.Month == 10 ? grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn) : 0,
//                                        November = grp.Key.Month == 11 ? grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn) : 0,
//                                        December = grp.Key.Month == 12 ? grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn) : 0,
//                                        January = grp.Key.Month == 1 ? grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn) : 0,
//                                        February = grp.Key.Month == 2 ? grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn) : 0,
//                                        March = grp.Key.Month == 3 ? grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn) : 0,

//                                        TotalQty = grp.Sum(r => r.SalesQty) - grp.Sum(r => r.ReturnQty),
//                                        TotalCollection = 0,
//                                        TotalOutstanding = 0,
//                                        PostDatedCheques = 0,
//                                        UnrealizeCheques = 0,
//                                        CreditRisk = 0
//                                    }).ToList();
//    #endregion
//    #endregion

//    if (lstTemp.Count > 0)
//    {
//        cls_sasSalesReportSummary_YTD.SalesReportSummary_YTD(lstTemp, dtFromDate, dtToDate, sReportTitle_Main);
//    }
//    else
//    {
//        MessageBox.Show("Data Not Found", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
//    }
//}
#endregion

#region Sales Report - Invoice Wice
//else if (Report == enum_ReportName.CU_SalesDetailReport_InvoiceWise)
//{
//    //Create list of Data Ojects-
//    List<cls_sasSalesReportDetail_InvoiceWise_DTO> lstSales = new List<cls_sasSalesReportDetail_InvoiceWise_DTO>();

//    #region Fill Data Object List
//    #region Invoice
//    foreach (tbl_sasInvoice oInvoice in oInvoiceList)
//    {
//        string sSalesmanID = "";
//        tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oInvoice.Customer_ID).FirstOrDefault();
//        if (oCustomer != null)
//        {
//            #region Filters
//            #region Customer Filters
//            if (bCustomerClassSelected)
//                if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
//                    continue;
//            if (bCustomerTypeSelected)
//                if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
//                    continue;
//            if (bCustomerCategorySelected)
//                if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
//                    continue;
//            #endregion

//            #region Sales Rep Filter 
//            if (!chkUseCustomerMastorSaleRep.Checked)
//            {
//                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
//                if (oRef != null && oRef.OrderRefNo_ID != "default")
//                    sSalesmanID = oRef.Employee_ID;
//            }
//            else
//                sSalesmanID = oCustomer.SalesRep_ID;

//            if (bSelesRepSelected)
//                if (txtSalesRep.Tag.ToString() != sSalesmanID)
//                    continue;
//            #endregion
//            #endregion

//            #region Detail Fill
//            decimal dDiscountTotal_Flat = oInvoice.DiscountTotal + oInvoice.DiscountTotal1 + oInvoice.DiscountTotal2 + oInvoice.DiscountTotal3;

//            decimal dSubTotalWithoutDiscount = 0, dDiscountTotal = 0, dNetAmount = 0, TotalQty = 0, dLineDiscount = 0;
//            foreach (tbl_sasInvoice_Detail oDetail in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID).OrderBy(r => r.Line_No))
//            {
//                TotalQty += oDetail.Qty;

//                if (oDetail.BIsFreeItem)
//                {
//                    dSubTotalWithoutDiscount += (oDetail.UnitPrice * oDetail.Qty);
//                    dLineDiscount += dSubTotalWithoutDiscount;
//                }
//                else
//                {
//                    dSubTotalWithoutDiscount += (oDetail.UnitPrice * oDetail.Qty);
//                    dLineDiscount += (oDetail.DiscountAmount * oDetail.Qty);
//                }
//            }
//            dDiscountTotal = (dLineDiscount + dDiscountTotal_Flat);
//            dNetAmount = dSubTotalWithoutDiscount - dDiscountTotal;

//            lstSales.Add(new cls_sasSalesReportDetail_InvoiceWise_DTO()
//            {
//                TxType = "1-Sales",
//                Tx_ID = oInvoice.Invoice_ID,
//                TxDate = oInvoice.InvoiceDate,
//                SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
//                Customer = clsGenaralName.getName_Customer(oInvoice.Customer_ID),
//                CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
//                CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

//                TotalQty = TotalQty,

//                ItemAmount = dSubTotalWithoutDiscount,
//                Discount = dDiscountTotal,
//                SubTotal = dNetAmount,

//                NBTAmount = oInvoice.NbtTotal,
//                VATAmount = oInvoice.VatTotal,
//                GrandTotal = oInvoice.GrandTotal,
//                SVATAmount = oInvoice.OtherTaxTotal
//            });
//            #endregion

//            clsHelpMethods_Local.startProgressBar(0, oInvoiceList.Count, 1, ProgressBar);
//        }
//    }
//    ProgressBar.Value = 0;
//    #endregion

//    #region SRN
//    foreach (tbl_sasSalesReturnedNote oSrn in oSrnList)
//    {

//        string sSalesmanID = "";
//        tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oSrn.Customer_ID).FirstOrDefault();
//        if (oCustomer != null)
//        {
//            #region Filters
//            #region Customer Filters
//            if (bCustomerClassSelected)
//                if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
//                    continue;
//            if (bCustomerTypeSelected)
//                if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
//                    continue;
//            if (bCustomerCategorySelected)
//                if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
//                    continue;
//            #endregion

//            #region Sales Rep Filter
//            if (!chkUseCustomerMastorSaleRep.Checked)
//            {
//                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oSrn.OrderRefNo_ID);
//                if (oRef != null && oRef.OrderRefNo_ID != "default")
//                    sSalesmanID = oRef.Employee_ID;
//            }
//            else
//                sSalesmanID = oCustomer.SalesRep_ID;


//            if (bSelesRepSelected)
//                if (txtSalesRep.Tag.ToString() != sSalesmanID)
//                    continue;
//            #endregion
//            #endregion

//            #region Detail Fill
//            decimal dSubTotalWithoutDiscount = 0, dDiscountTotal = 0, dNetAmount = 0, TotalQty = 0, dLineDiscount = 0;
//            foreach (tbl_sasSalesReturnedNote_Detail oDetail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSrn.SalesReturnedNote_ID))
//            {
//                TotalQty += oDetail.Qty;
//                if (oDetail.BIsFreeItem)
//                {
//                    dSubTotalWithoutDiscount += (oDetail.UnitPrice * oDetail.Qty);
//                    dLineDiscount += dSubTotalWithoutDiscount;
//                }
//                else
//                {
//                    dSubTotalWithoutDiscount += (oDetail.UnitPrice * oDetail.Qty);
//                    dLineDiscount += (oDetail.DiscountAmount * oDetail.Qty);
//                }
//            }

//            dDiscountTotal = (dLineDiscount + oSrn.DiscountTotal);
//            dNetAmount = dSubTotalWithoutDiscount - dDiscountTotal;


//            lstSales.Add(new cls_sasSalesReportDetail_InvoiceWise_DTO()
//            {
//                TxType = "2-Sales Return",
//                Tx_ID = oSrn.SalesReturnedNote_ID,
//                TxDate = oSrn.SalesReturnedNoteDate,
//                SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
//                Customer = clsGenaralName.getName_Customer(oSrn.Customer_ID),
//                CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
//                CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

//                TotalQty = (TotalQty * -1),
//                ItemAmount = (dSubTotalWithoutDiscount * -1),
//                Discount = (dDiscountTotal * -1),
//                SubTotal = (dNetAmount * -1),

//                NBTAmount = (oSrn.NbtTotal * -1),
//                VATAmount = (oSrn.VatTotal * -1),
//                GrandTotal = (oSrn.GrandTotal * -1),
//                SVATAmount = (oSrn.OtherTaxTotal * -1)
//            });
//            #endregion

//            clsHelpMethods_Local.startProgressBar(0, oSrnList.Count, 1, ProgressBar);
//        }
//    }
//    ProgressBar.Value = 0;
//    #endregion

//    #region POS Sales
//    foreach (tbl_posTransaction oPOS in oPosList)
//    {
//        string sSalesmanID = "";
//        tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oPOS.Customer_ID).FirstOrDefault();
//        if (oCustomer != null)
//        {
//            #region Filters
//            #region Customer Filters
//            if (bCustomerClassSelected)
//                if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
//                    continue;
//            if (bCustomerTypeSelected)
//                if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
//                    continue;
//            if (bCustomerCategorySelected)
//                if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
//                    continue;
//            #endregion

//            #region Sales Rep Filter
//            if (!chkUseCustomerMastorSaleRep.Checked)
//            {
//                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oPOS.OrderRefNo_ID);
//                if (oRef != null && oRef.OrderRefNo_ID != "default")
//                    sSalesmanID = oRef.Employee_ID;
//            }
//            else
//                sSalesmanID = oCustomer.SalesRep_ID;

//            if (bSelesRepSelected)
//                if (txtSalesRep.Tag.ToString() != sSalesmanID)
//                    continue;
//            #endregion
//            #endregion

//            #region Fill Detail
//            decimal dSubTotalWithDiscount = 0, dDiscountTotal = 0, BulkDiscount = 0;
//            decimal dWithNbtAmount = 0, dNbtAmount = 0, dVatAmount = 0;

//            //if (oPOS.SubTotal < 0)
//            //    BulkDiscount *= -1;

//            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oPOS.GrandTotal, oPOS.VatPercentage, oPOS.NbtPercentage, ref dWithNbtAmount, ref dSubTotalWithDiscount, ref dNbtAmount, ref dVatAmount);

//            decimal TotalQty = 0, dTotalAmount = 0, dLineDiscount = 0;
//            foreach (tbl_posTransaction_Detail oDetail in tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(oPOS.PosTransaction_Index))
//            {
//                TotalQty += oDetail.Qty;
//                //dTotalAmount += oDetail.UnitPrice * oDetail.Qty;
//                dLineDiscount += (oDetail.LineDiscountTotal * oDetail.Qty);

//                //dAmountBeforeLineDiscount = (dAmountBeforeBulkDiscount / (100 - oDetail.LineDiscountPresentage) * 100);
//                //dLineDiscount = dAmountBeforeLineDiscount - dAmountBeforeBulkDiscount;

//            }
//            BulkDiscount = (dSubTotalWithDiscount * oPOS.DiscountPercentage) / (100 - oPOS.DiscountPercentage);
//            dDiscountTotal = dLineDiscount + BulkDiscount;

//            dTotalAmount = dSubTotalWithDiscount + dDiscountTotal;

//            lstSales.Add(new cls_sasSalesReportDetail_InvoiceWise_DTO()
//            {
//                TxType = "3-POS Sales & Return",
//                Tx_ID = oPOS.PosTransaction_ID,
//                TxDate = oPOS.PosTransactiondate,
//                SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
//                Customer = clsGenaralName.getName_Customer(oPOS.Customer_ID),
//                CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
//                CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),


//                TotalQty = TotalQty,
//                ItemAmount = dTotalAmount,
//                Discount = dDiscountTotal,
//                SubTotal = dSubTotalWithDiscount,

//                NBTAmount = dNbtAmount,
//                VATAmount = dVatAmount,
//                GrandTotal = oPOS.GrandTotal,
//                SVATAmount = oPOS.OtherTaxTotal
//            });
//            #endregion

//            clsHelpMethods_Local.startProgressBar(0, oPosList.Count, 1, ProgressBar);
//        }
//    }
//    ProgressBar.Value = 0;
//    #endregion
//    #endregion

//    if (lstSales.Count > 0)
//    {
//        cls_sasSalesReportDetail_InvoiceWise.SalesReportDetail_InvoiceWise(lstSales, dtFromDate, dtToDate, sReportTitle_Main);
//    }
//    else
//    {
//        MessageBox.Show("Data Not Found", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
//    }
//}
#endregion

#region Month Returns Against - Sales - Pure Excel
//DataTable dt = new DataTable();
//dt.Columns.Add("Route");
//                                        dt.Columns.Add("SalesRep");

//                                        dt.Columns.Add("GrossValue");
//                                        dt.Columns.Add("ReturnValue");
//                                        #endregion

//                                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
//ExcelApp.Application.Workbooks.Add(Type.Missing);
//var List = oMonthlyReturnsList
//        .GroupBy(u => new { u.Month, u.SalesRep, u.Route })
//        .Select(t => new 
//        {
//            Route = t.Key.Route,
//            SalesRep = t.Key.SalesRep,
//            Month = t.Key.Month,

//            GrossValueOne = t.Key.Month == 1 ? t.Sum(v => v.GrossValue) : 0,
//            ReturnValueOne = t.Key.Month == 1 ? t.Sum(v => v.ReturnValue) : 0,
//            GrossValueTwo = t.Key.Month == 2 ? t.Sum(v => v.GrossValue) : 0,
//            ReturnValueTwo = t.Key.Month == 2 ? t.Sum(v => v.ReturnValue) : 0,
//            GrossValueThree = t.Key.Month == 3 ? t.Sum(v => v.GrossValue) : 0,
//            ReturnValueThree = t.Key.Month == 3 ? t.Sum(v => v.ReturnValue) : 0,
//            GrossValueFour = t.Key.Month == 4 ? t.Sum(v => v.GrossValue) : 0,
//            ReturnValueFour = t.Key.Month == 4 ? t.Sum(v => v.ReturnValue) : 0,
//            GrossValueFive = t.Key.Month == 5 ? t.Sum(v => v.GrossValue) : 0,
//            ReturnValueFive = t.Key.Month == 5 ? t.Sum(v => v.ReturnValue) : 0
//        })
//        .ToList();

//DataTable tempDt = clsHelpMethods_Local.ToDataTable(List.ToList());

#region Set Header and Column Width
//ExcelApp.Cells[1, 1].Value = clsSecurity.CompanyName;
//ExcelApp.Cells[2, 1].Value = clsSecurity.CompanyAddress1;
//ExcelApp.Cells[3, 1].Value = clsSecurity.CompanyAddress2;
//ExcelApp.Cells[5, 1].Value = sReportTitle_Main;
//ExcelApp.Cells[6, 1].Value = "From : " + dtFromDate.Date.ToShortDateString() + " - To :" + dtToDate.Date.ToShortDateString();

//#region Merge Company Details
//ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 7]].Merge();
//ExcelApp.Range[ExcelApp.Cells[2, 1], ExcelApp.Cells[2, 7]].Merge();
//ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 7]].Merge();
//ExcelApp.Range[ExcelApp.Cells[5, 1], ExcelApp.Cells[5, 7]].Merge();
//ExcelApp.Range[ExcelApp.Cells[6, 1], ExcelApp.Cells[6, 7]].Merge();
//#endregion

////format orientation n alignments
////set column range as text format
////ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 20]].NumberFormat = "@";
////ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 20]].Orientation = "90";
////ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 20]].Style.VerticalAlignment = VerticalAlignment.Center;
////ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 20]].Style.HorizontalAlignment = HorizontalAlignment.Center;
//ExcelApp.Range[ExcelApp.Cells[4, 1], ExcelApp.Cells[4, 20]].RowHeight = "20";

////format font style
//ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[6, 7]].Style.Font.Bold = true;
//ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[6, 7]].Style.Font.Name = "Calibri";
//ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[6, 7]].Style.Font.Size = 9F;

//#region Column Headers
////Header Top Line
////ExcelApp.Cells[8, 1] = "Route";
////ExcelApp.Cells[8, 2] = "Sales Rep";
//ExcelApp.Cells[8, 3] = "January";
//ExcelApp.Cells[8, 7] = "February";
//ExcelApp.Cells[8, 11] = "March";
//ExcelApp.Cells[8, 15] = "April";
//ExcelApp.Cells[8, 19] = "May";

////Header Bottom Line
//ExcelApp.Cells[9, 1] = "Route";
//ExcelApp.Cells[9, 2] = "Sales Rep";

//ExcelApp.Cells[9, 3] = "Gross Value";
//ExcelApp.Cells[9, 4] = "Return Value";
//ExcelApp.Cells[9, 5] = "Net Value";
//ExcelApp.Cells[9, 6] = "Rtn %";

//ExcelApp.Cells[9, 7] = "Gross Value";
//ExcelApp.Cells[9, 8] = "Return Value";
//ExcelApp.Cells[9, 9] = "Net Value";
//ExcelApp.Cells[9, 10] = "Rtn %";

//ExcelApp.Cells[9, 11] = "Gross Value";
//ExcelApp.Cells[9, 12] = "Return Value";
//ExcelApp.Cells[9, 13] = "Net Value";
//ExcelApp.Cells[9, 14] = "Rtn %";

//ExcelApp.Cells[9, 15] = "Gross Value";
//ExcelApp.Cells[9, 16] = "Return Value";
//ExcelApp.Cells[9, 17] = "Net Value";
//ExcelApp.Cells[9, 18] = "Rtn %";

//ExcelApp.Cells[9, 19] = "Gross Value";
//ExcelApp.Cells[9, 20] = "Return Value";
//ExcelApp.Cells[9, 21] = "Net Value";
//ExcelApp.Cells[9, 22] = "Rtn %";

//#region Merge Cells
//ExcelApp.Range[ExcelApp.Cells[8, 1], ExcelApp.Cells[9, 1]].Merge();
//ExcelApp.Range[ExcelApp.Cells[8, 2], ExcelApp.Cells[9, 2]].Merge();

//ExcelApp.Range[ExcelApp.Cells[8, 3], ExcelApp.Cells[8, 5]].Merge();
//ExcelApp.Range[ExcelApp.Cells[8, 7], ExcelApp.Cells[8, 9]].Merge();
//ExcelApp.Range[ExcelApp.Cells[8, 11], ExcelApp.Cells[8, 13]].Merge();
//ExcelApp.Range[ExcelApp.Cells[8, 15], ExcelApp.Cells[8, 17]].Merge();
//ExcelApp.Range[ExcelApp.Cells[8, 19], ExcelApp.Cells[8, 21]].Merge();
//#endregion

////format header borders
//ExcelApp.Range[ExcelApp.Cells[8, 1], ExcelApp.Cells[9, 22]].Borders.Color = System.Drawing.Color.Black;
//ExcelApp.Range[ExcelApp.Cells[8, 1], ExcelApp.Cells[9, 22]].Interior.Color = System.Drawing.Color.LightGray;

////ExcelApp.Range[ExcelApp.Cells[8, 1], ExcelApp.Cells[9, 22]].Style.VerticalAlignment = VerticalAlignment.Center;
////ExcelApp.Range[ExcelApp.Cells[8, 1], ExcelApp.Cells[9, 22]].Style.HorizontalAlignment = HorizontalAlignment.Center;
//#endregion
#endregion

#region Fill Cells
//int c = 10;
//foreach (var row in List)
//{
//    ExcelApp.Range[ExcelApp.Cells[c, 1], ExcelApp.Cells[c, 20]].Style.Font.Name = "Calibri";
//    ExcelApp.Range[ExcelApp.Cells[c, 1], ExcelApp.Cells[c, 20]].Style.Font.Size = 10F;
//    ExcelApp.Range[ExcelApp.Cells[c, 1], ExcelApp.Cells[c, 20]].Style.Font.Bold = false;

//    ExcelApp.Cells[c, 1] = row.Route;
//    ExcelApp.Cells[c, 2] = row.SalesRep;

//    ExcelApp.Cells[c, 3] = clsFormatter.RoundDecimalPlaces(row.GrossValueOne);
//    ExcelApp.Cells[c, 4] = clsFormatter.RoundDecimalPlaces(row.ReturnValueOne);
//    ExcelApp.Cells[c, 5] = clsFormatter.RoundDecimalPlaces(row.GrossValueOne - row.ReturnValueOne);
//    ExcelApp.Cells[c, 6] = row.GrossValueOne > 0 && row.ReturnValueOne > 0 ? clsFormatter.RoundDecimalPlaces(row.GrossValueOne / row.ReturnValueOne) + "%" : "0";

//    ExcelApp.Cells[c, 7] = clsFormatter.RoundDecimalPlaces(row.GrossValueTwo);
//    ExcelApp.Cells[c, 8] = clsFormatter.RoundDecimalPlaces(row.ReturnValueTwo);
//    ExcelApp.Cells[c, 9] = clsFormatter.RoundDecimalPlaces(row.GrossValueTwo - row.ReturnValueTwo);
//    ExcelApp.Cells[c, 10] = row.GrossValueTwo > 0 && row.ReturnValueTwo > 0 ? clsFormatter.RoundDecimalPlaces(row.GrossValueTwo / row.ReturnValueTwo) + "%" : "0";

//    ExcelApp.Cells[c, 11] = clsFormatter.RoundDecimalPlaces(row.GrossValueThree);
//    ExcelApp.Cells[c, 12] = clsFormatter.RoundDecimalPlaces(row.ReturnValueThree);
//    ExcelApp.Cells[c, 13] = clsFormatter.RoundDecimalPlaces(row.GrossValueThree - row.ReturnValueThree);
//    ExcelApp.Cells[c, 14] = row.GrossValueThree > 0 && row.ReturnValueThree > 0 ? clsFormatter.RoundDecimalPlaces(row.GrossValueThree / row.ReturnValueThree) + "%" : "0";

//    ExcelApp.Cells[c, 15] = clsFormatter.RoundDecimalPlaces(row.GrossValueFour);
//    ExcelApp.Cells[c, 16] = clsFormatter.RoundDecimalPlaces(row.ReturnValueFour);
//    ExcelApp.Cells[c, 17] = clsFormatter.RoundDecimalPlaces(row.GrossValueFour - row.ReturnValueFour);
//    ExcelApp.Cells[c, 18] = row.GrossValueFour > 0 && row.ReturnValueFour > 0 ? clsFormatter.RoundDecimalPlaces(row.GrossValueFour / row.ReturnValueFour) + "%" : "0";

//    ExcelApp.Cells[c, 19] = clsFormatter.RoundDecimalPlaces(row.GrossValueFive);
//    ExcelApp.Cells[c, 20] = clsFormatter.RoundDecimalPlaces(row.ReturnValueFive);
//    ExcelApp.Cells[c, 21] = clsFormatter.RoundDecimalPlaces(row.GrossValueFive - row.ReturnValueFive);
//    ExcelApp.Cells[c, 22] = row.GrossValueFive > 0 && row.ReturnValueFive > 0 ? clsFormatter.RoundDecimalPlaces(row.GrossValueFive / row.ReturnValueFive) + "%" : "0";

//    c++;
//}
#endregion

//ExcelApp.Columns.WrapText = true;
//ExcelApp.Columns.AutoFit();
//SaveFileDialog dlg = new SaveFileDialog();
//dlg.DefaultExt = ".xls";
//dlg.Filter = "Excel documents (.xls)|*.xlsx";
//if (dlg.ShowDialog() == DialogResult.OK)
//{
//    string filename = dlg.FileName;
//    ExcelApp.ActiveWorkbook.SaveAs(filename);

//    MessageBox.Show("Excel file is successfully created", "Successfully created", MessageBoxButtons.OK, MessageBoxIcon.Information);
//    ExcelApp.ActiveWorkbook.Saved = true;
//    ExcelApp.Visible = true;

//    //Marshal.FinalReleaseComObject(ExcelApp);
//} 
#endregion