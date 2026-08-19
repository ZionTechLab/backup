using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;
using Zion.ERP.Reports.DataSets;
using Zion.ERP.Reports.DataSets.SCS;
using SEACC.DATA.Data.SCS;
using ZION.ERP.Reports.DataSets.SCS;

namespace Digiteq
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frm_scsDamageGoodsNote : SEACC_Form
    {
        
        //to manage update and insert
        //static bool IsUpdate = false;

        //form manage
        //string sFormConfigCode;
        //   public int iFormID;

        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        dts_scsDamageGoods glb_dts_scsDamageGoods = new dts_scsDamageGoods();

        //to keep glob ref no        
        public string glbOrderRefNo = "", glbDGNNo = "";

        //for security handle
        //public bool bNoAccess;
        //public bool bHasChecked;
        //public bool bHasApproved;
        //  DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        //   DateTime glbCheckedDate = clsSecurity.getServerDateTime();

        public DataTable dt_ItemGrouped = new DataTable();

        InventoryTxnData oData = new InventoryTxnData();
    

        #region Form Load
        public frm_scsDamageGoodsNote(FormName _enmForm)
        {
            //sFormConfigCode = clsAutocode.getFormConfigCode(FormName.scsDamagedGoodsNote);
            //iFormID = clsSecurity.getFormID(FormName.scsDamagedGoodsNote);
            //if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            //{
            //    bNoAccess = true;
            //}
            //InitializeComponent();

            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }

        private void frmInvoice_Load(object sender, EventArgs e)
        {
            //format Form
            //clsFormatter.setFormatForm(this, "Damaged Goods Note - [DGN]", 4, iFormID);

            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);
            ClearFields();
            CusDataGridViewFormat();

            CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);

            if (glbDGNNo.Length > 0)
            {
                FillDetails(glbDGNNo);
            }
        }
        #endregion

        #region Btn New
        private void frm_scsDamageGoodsNote_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void frm_scsDamageGoodsNote_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDGNID.Text.Trim().Length > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpDGNDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreID.Tag.ToString(), IsUpdate))
                            {
                                if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtDamageGoodStore.Tag.ToString(), IsUpdate))
                                {
                                    Cursor = Cursors.WaitCursor;
                                    tbl_scsDamagedGoodNote detail = tbl_scsDamagedGoodNote.Select(txtDGNID.Text.Trim());
                                    if (detail != null)
                                    {
                                        if (!detail.IsLocked && !detail.IsFinished && !detail.IsDeleted)
                                        {
                                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " DGN : " + txtDGNID.Text), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                            if (msgResult == DialogResult.Yes)
                                            {
                                                if (CheckStockValidity(detail.DamagedGoodNote_ID))
                                                {
                                                    #region Update Other Tables
                                                    foreach (tbl_scsDamagedGoodNote_Detail Olddetail in tbl_scsDamagedGoodNote_Detail.SelectAllByDamagedGoodNote_ID(txtDGNID.Text.Trim()))
                                                    {
                                                        if (Olddetail.Item_ID != null)
                                                        {
                                                            #region Update Store Stock
                                                            decimal dWeightedAverageCostPrice = 0;
                                                          //  clsHelpMethods_Local.UpdateStoreStock(iFormID, Olddetail.DamagedGoodNote_ID, detail.DamagedGoodNoteDate, Olddetail.Item_ID, "0", txtStoreID.Tag.ToString(), Olddetail.Qty, Olddetail.Weight, Olddetail.UnitPrice, true, false, false, ref dWeightedAverageCostPrice);
                                                         //   clsHelpMethods_Local.UpdateStoreStock(iFormID, Olddetail.DamagedGoodNote_ID, detail.DamagedGoodNoteDate, Olddetail.Item_ID, "0", txtDamageGoodStore.Tag.ToString(), Olddetail.Qty, Olddetail.Weight, Olddetail.UnitPrice, true, true, false, ref dWeightedAverageCostPrice);

                                                            Olddetail.WeightedAvgCost = clsProcessMethods.GetItemWeightedAvarageCostPrice(Olddetail.Item_ID);
                                                            Olddetail.Update();
                                                            #endregion
                                                        }
                                                    }
                                                    #endregion

                                                    detail.DateModified = clsSecurity.getServerDateTime();
                                                    detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.IsDeleted = true;
                                                    detail.Update();

                                                    //clsHelpMethods.Delete_Inventory(iFormID, 0, txtDGNID.Text.Trim());
                                                    var responce = oData.Delete_InventoryTxn(iFormID, txtDGNID.Text.Trim());
                                                    if (!responce.IsSuccess)
                                                    {
                                                        clsValidate.WriteErrorLog(txtDGNID.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
                                                    }


                                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    ClearFields();
                                                }
                                            }
                                        }
                                        else
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Btn Remove
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetail.SelectedCells.Count != 0)
                {
                    if (dgvDetail.Rows.Count > 0)
                        dgvDetail.Rows.RemoveAt(dgvDetail.SelectedCells[0].RowIndex);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Save
        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void frm_scsDamageGoodsNote_SF_saveButton_Click(object sender, EventArgs e)
        {
            dt_ItemGrouped = clsCommon.DataGridViewToDataTable_ItemGrouped(dgvDetail);

            if (CheckValidity_EmptyField())
            {
                if (CheckNumberValidity())
                {
                    if (ValidateDiscardingQty())
                    {
                        //if (CheckRemarkValidity())
                        //{
                        if (clsMethods_GL.CheckValidity_FinancialYear(dtpDGNDate.Value.Date))
                        {
                            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                            {
                                if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreID.Tag.ToString(), IsUpdate))
                                {
                                    if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtDamageGoodStore.Tag.ToString(), IsUpdate))
                                    {
                                        if (CheckStockValidity())
                                        {
                                            try
                                            {
                                                Cursor = Cursors.WaitCursor;
                                                ValidateEmptyForeignKey();
                                                if (glbOrderRefNo.Length <= 0)
                                                    glbOrderRefNo = "default";

                                                #region Update DGN
                                                if (IsUpdate)  //update records
                                                {
                                                    tbl_scsDamagedGoodNote oldRecord = tbl_scsDamagedGoodNote.Select(txtDGNID.Text.Trim());
                                                    if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                                                    {
                                                        if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                                                        {
                                                            if (!oldRecord.IsChecked || (oldRecord.IsChecked && clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID)))
                                                            {
                                                                if (clsValidate.CheckValidity_TransactionCodeLength(txtDGNID.Text))
                                                                {
                                                                //    List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();

                                                                    #region Rollback Store Stock
                                                                    foreach (
                                                                        tbl_scsDamagedGoodNote_Detail oUpdatedRecore in
                                                                        tbl_scsDamagedGoodNote_Detail
                                                                            .SelectAllByDamagedGoodNote_ID(
                                                                                txtDGNID.Text.Trim()))
                                                                    {
                                                                        decimal dWeightedAverageCostPrice = 0;

                                                                        //clsHelpMethods_Local.UpdateStoreStock(iFormID,
                                                                        //    oUpdatedRecore.DamagedGoodNote_ID,
                                                                        //    oldRecord.DamagedGoodNoteDate,
                                                                        //    oUpdatedRecore.Item_ID, "0",
                                                                        //    txtStoreID.Tag.ToString(),
                                                                        //    oUpdatedRecore.Qty, oUpdatedRecore.Weight,
                                                                        //    oUpdatedRecore.UnitPrice, true, false,
                                                                        //    false, ref dWeightedAverageCostPrice);

                                                                        //clsHelpMethods_Local.UpdateStoreStock(iFormID,
                                                                        //    oUpdatedRecore.DamagedGoodNote_ID,
                                                                        //    oldRecord.DamagedGoodNoteDate,
                                                                        //    oUpdatedRecore.Item_ID, "0",
                                                                        //    txtDamageGoodStore.Tag.ToString(),
                                                                        //    oUpdatedRecore.Qty, oUpdatedRecore.Weight,
                                                                        //    oUpdatedRecore.UnitPrice, true, true,
                                                                        //    false, ref dWeightedAverageCostPrice);

                                                                        oUpdatedRecore.WeightedAvgCost = clsProcessMethods.GetItemWeightedAvarageCostPrice(oUpdatedRecore.Item_ID);
                                                                        oUpdatedRecore.Update();
                                                                    }
                                                                    #endregion

                                                                    #region Update Old DGN Items
                                                                    int iCount = 0;
                                                                    List<tbl_scsDamagedGoodNote_Detail> oldDetails =
                                                                        tbl_scsDamagedGoodNote_Detail
                                                                            .SelectAllByDamagedGoodNote_ID(
                                                                                txtDGNID.Text.Trim());
                                                                    foreach (tbl_scsDamagedGoodNote_Detail oldDetail in
                                                                        oldDetails)
                                                                    {
                                                                        #region Intialize Variables and Set Grid Values
                                                                        string sJobCode = "default",
                                                                                sItemCode = "",
                                                                                sItemSubCategoryID1 = "",
                                                                                sItemSubCategoryID2 = "",
                                                                                sItemSerialNo1 = "",
                                                                                sItemSerialNo2 = "",
                                                                                sPOID = "",
                                                                                sPRNID = "",
                                                                                sStoreID = "",
                                                                                sUom = "",
                                                                                sRemarks = "";
                                                                        decimal dQty = 0,
                                                                            dUnitPrice = 0,
                                                                            dWeight = 0,
                                                                            dAmount = 0,
                                                                            dWaranty = 0,
                                                                            dWeidhtPrice = 0;
                                                                        bool bHasItemInDB = false;

                                                                        foreach (DataGridViewRow row in dgvDetail.Rows)
                                                                        {
                                                                            sItemCode = clsValidate.ValidateGridValue(
                                                                                dgvDetail, "ItemCode", row.Index, "");
                                                                            sItemSubCategoryID1 =
                                                                                clsValidate.ValidateGridTag(dgvDetail,
                                                                                    "ItemSubCategoryID", row.Index,
                                                                                    "default");
                                                                            sItemSubCategoryID2 =
                                                                                clsValidate.ValidateGridTag(dgvDetail,
                                                                                    "ItemSubCategoryID2", row.Index,
                                                                                    "default");
                                                                            sItemSerialNo1 =
                                                                                clsValidate.ValidateGridValue(dgvDetail,
                                                                                    "ItemSerialNo1", row.Index, "0");
                                                                            sItemSerialNo2 =
                                                                                clsValidate.ValidateGridValue(dgvDetail,
                                                                                    "ItemSerialNo2", row.Index, "0");
                                                                            sPOID = clsValidate.ValidateGridValue(
                                                                                dgvDetail, "POID", row.Index,
                                                                                "default");
                                                                            sPRNID = clsValidate.ValidateGridValue(
                                                                                dgvDetail, "PRNID", row.Index,
                                                                                "default");
                                                                            sStoreID = clsValidate.ValidateGridTag(
                                                                                dgvDetail, "StoreName", row.Index,
                                                                                "default");
                                                                            sUom = clsValidate.ValidateGridValue(
                                                                                dgvDetail, "UOM", row.Index, "default");
                                                                            dQty = clsValidate.ValidateGridValue(
                                                                                dgvDetail, "Quantity", row.Index,
                                                                                decimal.Parse("0.00"));
                                                                            dUnitPrice =
                                                                                clsValidate.ValidateGridTag(dgvDetail,
                                                                                    "UnitPrice", row.Index,
                                                                                    decimal.Parse("0.00"));
                                                                            dWeidhtPrice =
                                                                                clsValidate.ValidateGridTag(dgvDetail,
                                                                                    "WeightPrice", row.Index,
                                                                                    decimal.Parse("0.00"));
                                                                            dWeight = clsValidate.ValidateGridValue(
                                                                                dgvDetail, "Weight", row.Index,
                                                                                decimal.Parse("0.00"));
                                                                            dAmount = clsValidate.ValidateGridTag(
                                                                                dgvDetail, "Amount", row.Index,
                                                                                decimal.Parse("0.00"));
                                                                            dWaranty = clsValidate.ValidateGridValue(
                                                                                dgvDetail, "Warranty", row.Index,
                                                                                decimal.Parse("0.00"));
                                                                            sRemarks = clsValidate.ValidateGridValue(
                                                                                dgvDetail, "Remarks", row.Index, "");

                                                                            #region Check Existing Records
                                                                            if (oldDetail.DamagedGoodNote_ID ==
                                                                                                                                                    txtDGNID.Text.Trim() &&
                                                                                                                                                    oldDetail.Item_ID == sItemCode &&
                                                                                                                                                    oldDetail.ItemSubCategory_ID ==
                                                                                                                                                    sItemSubCategoryID1 &&
                                                                                                                                                    oldDetail.ItemSubCategory2_ID ==
                                                                                                                                                    sItemSubCategoryID2 &&
                                                                                                                                                    oldDetail.ItemSerialNo ==
                                                                                                                                                    sItemSerialNo1 &&
                                                                                                                                                    oldDetail.ItemSerialNo2 ==
                                                                                                                                                    sItemSerialNo2 &&
                                                                                                                                                    oldDetail.Store_ID == sStoreID)
                                                                            {
                                                                                bHasItemInDB = true;
                                                                                dgvDetail.Rows.RemoveAt(row.Index);
                                                                                break; //database contain this item
                                                                            } 
                                                                            #endregion
                                                                        } 
                                                                        #endregion

                                                                        if (bHasItemInDB)
                                                                        {
                                                                            #region Update old item details

                                                                            //Update store stock when user modify the old recode
                                                                            //Don't put this region below update 

                                                                            #region Update Store Stock

                                                                            //if (clsHelpMethods_Local.Store_StockQuantityIncrease(sStoreID, sItemCode, sJobCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, oldDetail.Qty))
                                                                            //{
                                                                            //    if (clsHelpMethods_Local.Store_StockQuantityDecrease(sStoreID, sItemCode, sJobCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, dQty))
                                                                            //    {
                                                                            //        if (clsHelpMethods_Local.Store_StockQuantityDecrease(txtDamageGoodStore.Tag.ToString(), sItemCode, sJobCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, oldDetail.Qty))
                                                                            //            clsHelpMethods_Local.Store_StockQuantityIncrease(txtDamageGoodStore.Tag.ToString(), sItemCode, sJobCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, dQty);
                                                                            //    }
                                                                            //}

                                                                            //if (clsHelpMethods_Local.Store_StockWeightIncrease(sStoreID, sItemCode, sJobCode, oldDetail.ItemSubCategory_ID, oldDetail.ItemSubCategory2_ID, oldDetail.ItemSerialNo, oldDetail.ItemSerialNo2, oldDetail.Weight))
                                                                            //{
                                                                            //    if (clsHelpMethods_Local.Store_StockWeightDecrease(sStoreID, sItemCode, sJobCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, dWeight))
                                                                            //    {
                                                                            //        if (clsHelpMethods_Local.Store_StockWeightDecrease(txtDamageGoodStore.Tag.ToString(), sItemCode, sJobCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, oldDetail.Weight))
                                                                            //            clsHelpMethods_Local.Store_StockWeightIncrease(txtDamageGoodStore.Tag.ToString(), sItemCode, sJobCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, dWeight);
                                                                            //    }
                                                                            //}

                                                                            #endregion

                                                                            oldDetail.Item_ID = sItemCode;
                                                                            oldDetail.ItemSubCategory_ID =
                                                                                sItemSubCategoryID1;
                                                                            oldDetail.ItemSubCategory2_ID =
                                                                                sItemSubCategoryID2;
                                                                            oldDetail.ItemSerialNo = sItemSerialNo1;
                                                                            oldDetail.ItemSerialNo2 = sItemSerialNo2;
                                                                            oldDetail.Store_ID = sStoreID;
                                                                            oldDetail.Qty = dQty;
                                                                            oldDetail.UnitPrice = dUnitPrice;
                                                                            oldDetail.KiloPrice = dWeidhtPrice;
                                                                            oldDetail.Weight = dWeight;
                                                                            oldDetail.TatalAmount = dAmount;
                                                                            oldDetail.Remark = sRemarks;
                                                                            oldDetail.Update();

                                                                            #endregion

                                                                            #region Pass Value to Inventory Detail - Store
                                                                            //tbl_scsInventoryTxnDetail oInventoryDetail_Store = new tbl_scsInventoryTxnDetail(iFormID,  ++iCount, 0,txtDGNID.Text.Trim(), dtpDGNDate.Value,
                                                                            //                            "", "", "", "", "default", "default", txtStoreID.Tag.ToString(),
                                                                            //                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), 0, dQty, dUnitPrice, 0, false);
                                                                            //oListInventory.Add(oInventoryDetail_Store);
                                                                            #endregion

                                                                            #region Pass Value to Inventory Detail - Damage Store
                                                                            //tbl_scsInventoryTxnDetail oInventoryDetail_DamageStore = new tbl_scsInventoryTxnDetail(iFormID, ++iCount, 0,  txtDGNID.Text.Trim(), dtpDGNDate.Value,
                                                                            //                            "", "", "", "", "default", "default", txtDamageGoodStore.Tag.ToString(),
                                                                            //                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), dQty, 0, dUnitPrice, 0, false);
                                                                            //oListInventory.Add(oInventoryDetail_DamageStore);
                                                                            #endregion
                                                                        }
                                                                        else
                                                                        {
                                                                            #region Delete old item detail

                                                                            ////don't put this statement under stock update region

                                                                            //Update Store Stock if user delete old inserted item

                                                                            #region Update Store Stock If User Delete the old Input

                                                                            //if (clsHelpMethods_Local.isStore_StockAvailabel(oldDetail.Store_ID, oldDetail.Item_ID, sJobCode, oldDetail.ItemSubCategory_ID, oldDetail.ItemSubCategory2_ID, oldDetail.ItemSerialNo, oldDetail.ItemSerialNo2))
                                                                            //{
                                                                            //    if (clsHelpMethods_Local.Store_StockQuantityIncrease(oldDetail.Store_ID, oldDetail.Item_ID, sJobCode, oldDetail.ItemSubCategory_ID, oldDetail.ItemSubCategory2_ID, oldDetail.ItemSerialNo, oldDetail.ItemSerialNo2, oldDetail.Qty))
                                                                            //        clsHelpMethods_Local.Store_StockQuantityDecrease(txtDamageGoodStore.Tag.ToString(), oldDetail.Item_ID, sJobCode, oldDetail.ItemSubCategory_ID, oldDetail.ItemSubCategory2_ID, oldDetail.ItemSerialNo, oldDetail.ItemSerialNo2, oldDetail.Qty);
                                                                            //    if (clsHelpMethods_Local.Store_StockWeightIncrease(oldDetail.Store_ID, oldDetail.Item_ID, sJobCode, oldDetail.ItemSubCategory_ID, oldDetail.ItemSubCategory2_ID, oldDetail.ItemSerialNo, oldDetail.ItemSerialNo2, oldDetail.Weight))
                                                                            //        clsHelpMethods_Local.Store_StockWeightDecrease(txtDamageGoodStore.Tag.ToString(), oldDetail.Item_ID, sJobCode, oldDetail.ItemSubCategory_ID, oldDetail.ItemSubCategory2_ID, oldDetail.ItemSerialNo, oldDetail.ItemSerialNo2, oldDetail.Weight);
                                                                            //}
                                                                            //else
                                                                            //{
                                                                            //    if (clsHelpMethods_Local.Store_NewStock(oldDetail.Store_ID, oldDetail.Item_ID, sJobCode, oldDetail.ItemSubCategory_ID, oldDetail.ItemSubCategory2_ID, oldDetail.ItemSerialNo, oldDetail.ItemSerialNo2, oldDetail.Weight, 0, oldDetail.Qty, 0, 0, 0, 0, 0))
                                                                            //    {
                                                                            //        clsHelpMethods_Local.Store_StockQuantityDecrease(txtDamageGoodStore.Tag.ToString(), oldDetail.Item_ID, sJobCode, oldDetail.ItemSubCategory_ID, oldDetail.ItemSubCategory2_ID, oldDetail.ItemSerialNo, oldDetail.ItemSerialNo2, oldDetail.Qty);
                                                                            //        clsHelpMethods_Local.Store_StockWeightDecrease(txtDamageGoodStore.Tag.ToString(), oldDetail.Item_ID, sJobCode, oldDetail.ItemSubCategory_ID, oldDetail.ItemSubCategory2_ID, oldDetail.ItemSerialNo, oldDetail.ItemSerialNo2, oldDetail.Weight);
                                                                            //    }
                                                                            //}

                                                                            #endregion

                                                                            oldDetail.Delete();

                                                                            #endregion
                                                                        }                                                                                                                                                
                                                                    }
                                                                    #endregion

                                                                    #region Insert Newly Added Items
                                                                    foreach (DataGridViewRow row in dgvDetail.Rows)
                                                                    {
                                                                        #region Intialize Variables and Set Grid Values then Pass into Object
                                                                        string sJobCode = "default",
                                                                                                                                            sItemCode = "",
                                                                                                                                            sItemSubCategoryID1 = "",
                                                                                                                                            sItemSubCategoryID2 = "",
                                                                                                                                            sItemSerialNo1 = "",
                                                                                                                                            sItemSerialNo2 = "",
                                                                                                                                            sPOID = "",
                                                                                                                                            sPRNID = "",
                                                                                                                                            sStoreID = "",
                                                                                                                                            sUom = "",
                                                                                                                                            sRemarks = "";
                                                                        decimal dQty = 0,
                                                                            dUnitPrice = 0,
                                                                            dWeight = 0,
                                                                            dAmount = 0,
                                                                            dWaranty = 0,
                                                                            dWeidhtPrice = 0;

                                                                        sItemCode = clsValidate.ValidateGridValue(
                                                                            dgvDetail, "ItemCode", row.Index, "");
                                                                        sItemSubCategoryID1 =
                                                                            clsValidate.ValidateGridTag(dgvDetail,
                                                                                "ItemSubCategoryID", row.Index,
                                                                                "default");
                                                                        sItemSubCategoryID2 =
                                                                            clsValidate.ValidateGridTag(dgvDetail,
                                                                                "ItemSubCategoryID2", row.Index,
                                                                                "default");
                                                                        sItemSerialNo1 =
                                                                            clsValidate.ValidateGridValue(dgvDetail,
                                                                                "ItemSerialNo1", row.Index, "0");
                                                                        sItemSerialNo2 =
                                                                            clsValidate.ValidateGridValue(dgvDetail,
                                                                                "ItemSerialNo2", row.Index, "0");
                                                                        sPOID = clsValidate.ValidateGridValue(dgvDetail,
                                                                            "POID", row.Index, "default");
                                                                        sPRNID = clsValidate.ValidateGridValue(
                                                                            dgvDetail, "PRNID", row.Index, "default");
                                                                        sStoreID = clsValidate.ValidateGridTag(
                                                                            dgvDetail, "StoreName", row.Index,
                                                                            "default");
                                                                        sUom = clsValidate.ValidateGridValue(dgvDetail,
                                                                            "UOM", row.Index, "default");
                                                                        dQty = clsValidate.ValidateGridValue(dgvDetail,
                                                                            "Quantity", row.Index,
                                                                            decimal.Parse("0.00"));
                                                                        dUnitPrice =
                                                                            clsValidate.ValidateGridTag(dgvDetail,
                                                                                "UnitPrice", row.Index,
                                                                                decimal.Parse("0.00"));
                                                                        dWeidhtPrice =
                                                                            clsValidate.ValidateGridTag(dgvDetail,
                                                                                "WeightPrice", row.Index,
                                                                                decimal.Parse("0.00"));
                                                                        dWeight = clsValidate.ValidateGridValue(
                                                                            dgvDetail, "Weight", row.Index,
                                                                            decimal.Parse("0.00"));
                                                                        dAmount = clsValidate.ValidateGridTag(dgvDetail,
                                                                            "Amount", row.Index, decimal.Parse("0.00"));
                                                                        dWaranty = clsValidate.ValidateGridValue(
                                                                            dgvDetail, "Warranty", row.Index,
                                                                            decimal.Parse("0.00"));
                                                                        sRemarks = clsValidate.ValidateGridValue(
                                                                            dgvDetail, "Remarks", row.Index, "");

                                                                        tbl_scsDamagedGoodNote_Detail DGNDetail =
                                                                            new tbl_scsDamagedGoodNote_Detail(
                                                                                clsHelpMethods_Local
                                                                                    .GetMaxzimumLineNoDameagedGoodsNote(
                                                                                        txtDGNID.Text.Trim()),
                                                                                txtDGNID.Text.Trim(),
                                                                                sItemCode, sItemSubCategoryID1,
                                                                                sItemSubCategoryID2, sItemSerialNo1,
                                                                                sItemSerialNo2, sStoreID, dQty, dWeight,
                                                                                0, 0, 0, 0, 0, sRemarks, clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemCode));

                                                                        DGNDetail.Insert(); 
                                                                        #endregion
                                                                        
                                                                        #region Stock Update

                                                                        //if (clsHelpMethods_Local.Store_StockQuantityDecrease(sStoreID, sItemCode, sJobCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, dQty))
                                                                        //{
                                                                        //    if (clsHelpMethods_Local.isStore_StockAvailabel(txtDamageGoodStore.Tag.ToString(), sItemCode, sJobCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2))
                                                                        //        clsHelpMethods_Local.Store_StockQuantityIncrease(txtDamageGoodStore.Tag.ToString(), sItemCode, sJobCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, dQty);
                                                                        //    else
                                                                        //        clsHelpMethods_Local.Store_NewStock(txtDamageGoodStore.Tag.ToString(), sItemCode, sJobCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, dWeight, 0, dQty, 0, 0, 0, 0, 0);
                                                                        //}

                                                                        //if (clsHelpMethods_Local.Store_StockWeightDecrease(sStoreID, sItemCode, sJobCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, dWeight))
                                                                        //{
                                                                        //    if (clsHelpMethods_Local.isStore_StockAvailabel(txtDamageGoodStore.Tag.ToString(), sItemCode, sJobCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2))
                                                                        //        clsHelpMethods_Local.Store_StockWeightIncrease(txtDamageGoodStore.Tag.ToString(), sItemCode, sJobCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, dWeight);
                                                                        //    else
                                                                        //        clsHelpMethods_Local.Store_NewStock(txtDamageGoodStore.Tag.ToString(), sItemCode, sJobCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, dWeight, 0, dQty, 0, 0, 0, 0, 0);
                                                                        //}

                                                                        #endregion

                                                                        #region Pass Value to Inventory Detail - Store
                                                                        //tbl_scsInventoryTxnDetail oInventoryDetail_Store = new tbl_scsInventoryTxnDetail(iFormID, ++iCount, 0, txtDGNID.Text.Trim(), dtpDGNDate.Value,
                                                                        //                            "", "", "", "", "default", "default", txtStoreID.Tag.ToString(),
                                                                        //                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), 0, dQty, dUnitPrice, 0, false);
                                                                        //oListInventory.Add(oInventoryDetail_Store);
                                                                        #endregion

                                                                        #region Pass Value to Inventory Detail - Damage Store
                                                                        //tbl_scsInventoryTxnDetail oInventoryDetail_DamageStore = new tbl_scsInventoryTxnDetail(iFormID, ++iCount, 0, txtDGNID.Text.Trim(), dtpDGNDate.Value,
                                                                        //                            "", "", "", "", "default", "default", txtDamageGoodStore.Tag.ToString(),
                                                                        //                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), dQty, 0, dUnitPrice, 0, false);
                                                                        //oListInventory.Add(oInventoryDetail_DamageStore);
                                                                        #endregion
                                                                    }
                                                                    #endregion

                                                                    #region Update DGN Header

                                                                    tbl_scsDamagedGoodNote DGN =
                                                                        new tbl_scsDamagedGoodNote(txtDGNID.Text.Trim(),
                                                                            dtpDGNDate.Value, txtRemark.Text.Trim(),
                                                                            txtStoreID.Tag.ToString(),
                                                                            glbOrderRefNo, oldRecord.CreateUser_ID,
                                                                            clsSecurity.UserIDLoged,
                                                                            oldRecord.CheckedUser_ID,
                                                                            oldRecord.ApprovedUser_ID,
                                                                            oldRecord.DateCreate,
                                                                            clsSecurity.getServerDateTime(),
                                                                            glbCheckedDate, glbApprovedDate,
                                                                            bHasChecked, bHasApproved,
                                                                            oldRecord.IsFinished,
                                                                            oldRecord.IsDeleted, oldRecord.IsLocked,
                                                                            oldRecord.SeattleAmount,
                                                                            oldRecord.IsSeattled, oldRecord.PrintCount,
                                                                            oldRecord.IsWeightCalculation,
                                                                            txtDamageGoodStore.Tag.ToString(),
                                                                            oldRecord.CompanyID,
                                                                            oldRecord.CompanyBranch_ID);

                                                                    DGN.Update();

                                                                    #endregion

                                                                    #region Update Store Stock
                                                                    foreach(tbl_scsDamagedGoodNote_Detail oUpdatedRecord in tbl_scsDamagedGoodNote_Detail.SelectAllByDamagedGoodNote_ID(txtDGNID.Text.Trim()))
                                                                    {
                                                                        decimal dWeightedAverageCostPrice = 0;

                                                                        //clsHelpMethods_Local.UpdateStoreStock(iFormID,
                                                                        //    DGN.DamagedGoodNote_ID,
                                                                        //    DGN.DamagedGoodNoteDate,
                                                                        //    oUpdatedRecord.Item_ID, "0",
                                                                        //    txtStoreID.Tag.ToString(),
                                                                        //    oUpdatedRecord.Qty, oUpdatedRecord.Weight,
                                                                        //    oUpdatedRecord.UnitPrice, false, false,
                                                                        //    false, ref dWeightedAverageCostPrice);

                                                                        //clsHelpMethods_Local.UpdateStoreStock(iFormID,
                                                                        //    DGN.DamagedGoodNote_ID,
                                                                        //    DGN.DamagedGoodNoteDate,
                                                                        //    oUpdatedRecord.Item_ID, "0",
                                                                        //    txtDamageGoodStore.Tag.ToString(),
                                                                        //    oUpdatedRecord.Qty, oUpdatedRecord.Weight,
                                                                        //    oUpdatedRecord.UnitPrice, false, true,
                                                                        //    false, ref dWeightedAverageCostPrice);                                                                        
                                                                    }
                                                                    #endregion

                                                                    //Attachments.Insert(iFormID, oldRecord.DamagedGoodNote_ID);
                                                                    //Attachments.Remove(iFormID, oldRecord.DamagedGoodNote_ID);

                                                                    #region Update Inventory
                                                                    var responce = oData.Update_InventoryTxn(iFormID, txtDGNID.Text.Trim());
                                                                    if (!responce.IsSuccess)
                                                                    {
                                                                        clsValidate.WriteErrorLog(txtDGNID.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
                                                                    }


                                                                    //tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtDGNID.Text.Trim(), dtpDGNDate.Value, txtRemark.Text.Trim(),
                                                                    //    "default", "default", "default", -1, 0,
                                                                    //    "", "", "", "", false, clsSecurity.UserIDLoged);

                                                                    //clsHelpMethods.Update_Inventory(oHeader, oListInventory);
                                                                    #endregion

                                                                    MessageBox.Show( clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                }
                                                            }
                                                            else
                                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        }
                                                        else
                                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                                }
                                                #endregion

                                                #region Insert DGN
                                                else
                                                {
                                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                                        txtDGNID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                                    //create order ref number
                                                    if (glbOrderRefNo.Length <= 0 || glbOrderRefNo == "default")
                                                    {
                                                        glbOrderRefNo = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.zIssuedRefNo));
                                                        tbl_zIssuedRefNo orf = new tbl_zIssuedRefNo(glbOrderRefNo, txtSupplierRefNo.Text != "" ? txtSupplierRefNo.Text.Trim() : "-");
                                                        orf.Insert();
                                                    }

                                                    if (clsValidate.CheckValidity_TransactionCodeLength(txtDGNID.Text))// if (txtDGNID.Text.Trim().Length > 0)
                                                    {
                                                   //     List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();
                                                        
                                                        #region Insert Header
                                                        tbl_scsDamagedGoodNote DGN = new tbl_scsDamagedGoodNote(txtDGNID.Text.Trim(), dtpDGNDate.Value, txtRemark.Text.Trim(), txtStoreID.Tag.ToString(), glbOrderRefNo,
                                                            clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default", clsSecurity.getServerDateTime(),
                                                            clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, bHasChecked, bHasApproved, false, false, false, 0, false, 0, !chkUnitPricing.Checked, txtDamageGoodStore.Tag.ToString(), clsSecurity.CompanyID, clsSecurity.BranchID);
                                                        DGN.Insert();
                                                        #endregion

                                                        #region Insert Detail
                                                        int iCount = 0;
                                                        foreach (DataGridViewRow row in dgvDetail.Rows)
                                                        {
                                                            string sJobCode = "default", sItemCode = "", sItemSubCategoryID1 = "", sItemSubCategoryID2 = "", sItemSerialNo1 = "", sItemSerialNo2 = "", sPOID = "", sPRNID = "", sStoreID = "", sUom = "", sRemarks = "";
                                                            decimal dQty = 0, dUnitPrice = 0, dWeight = 0, dAmount = 0, dWaranty = 0, dWeidhtPrice = 0;

                                                            sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                                            sItemSubCategoryID1 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                                                            sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                                            sItemSerialNo1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                                                            sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                                            sPOID = clsValidate.ValidateGridValue(dgvDetail, "POID", row.Index, "default");
                                                            sPRNID = clsValidate.ValidateGridValue(dgvDetail, "PRNID", row.Index, "default");
                                                            sStoreID = clsValidate.ValidateGridTag(dgvDetail, "StoreName", row.Index, "default");
                                                            sUom = clsValidate.ValidateGridValue(dgvDetail, "UOM", row.Index, "default");
                                                            dQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                                            dUnitPrice = clsValidate.ValidateGridTag(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                                                            dWeidhtPrice = clsValidate.ValidateGridTag(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                                                            dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                                            dAmount = clsValidate.ValidateGridTag(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                                                            dWaranty = clsValidate.ValidateGridValue(dgvDetail, "Warranty", row.Index, decimal.Parse("0.00"));
                                                            sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");

                                                            tbl_scsDamagedGoodNote_Detail DGNDetail = new tbl_scsDamagedGoodNote_Detail(clsHelpMethods_Local.GetMaxzimumLineNoDameagedGoodsNote(txtDGNID.Text.Trim()), txtDGNID.Text.Trim(),
                                                                sItemCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, sStoreID, dQty, dWeight, 0, 0, 0, 0, 0, sRemarks, clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemCode));
                                                            DGNDetail.Insert();

                                                            decimal dWeightedAverageCostPrice = 0;
                                                         //   clsHelpMethods_Local.UpdateStoreStock(iFormID, DGN.DamagedGoodNote_ID, DGN.DamagedGoodNoteDate, sItemCode, "0", txtStoreID.Tag.ToString(), dQty, dWeight, dUnitPrice, false, false, false, ref dWeightedAverageCostPrice);
                                                         //   clsHelpMethods_Local.UpdateStoreStock(iFormID, DGN.DamagedGoodNote_ID, DGN.DamagedGoodNoteDate, sItemCode, "0", txtDamageGoodStore.Tag.ToString(), dQty, dWeight, dUnitPrice, false, true, false, ref dWeightedAverageCostPrice);
                                                           
                                                            #region Pass Value to Inventory Detail - Store
                                                            //tbl_scsInventoryTxnDetail oInventoryDetail_Store = new tbl_scsInventoryTxnDetail(iFormID, ++iCount, 0, txtDGNID.Text.Trim(), dtpDGNDate.Value,
                                                            //                            "", "", "", "", "default", "default", txtStoreID.Tag.ToString(),
                                                            //                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), 0, dQty, dUnitPrice, 0, false);
                                                            //oListInventory.Add(oInventoryDetail_Store);
                                                            #endregion

                                                            #region Pass Value to Inventory Detail - Damage Store
                                                            //tbl_scsInventoryTxnDetail oInventoryDetail_DamageStore = new tbl_scsInventoryTxnDetail(iFormID, ++iCount, 0, txtDGNID.Text.Trim(), dtpDGNDate.Value,
                                                            //                            "", "", "", "", "default", "default", txtDamageGoodStore.Tag.ToString(),
                                                            //                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), dQty, 0, dUnitPrice, 0, false);
                                                            //oListInventory.Add(oInventoryDetail_DamageStore);
                                                            #endregion
                                                        }
                                                        #endregion

                                                        #region Attachment
                                                        Attachments.Insert(txtDGNID.Text.ToString());
                                                        #endregion

                                                        #region Update Inventory
                                                        //tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtDGNID.Text.Trim(), dtpDGNDate.Value, txtRemark.Text.Trim(),
                                                        //    "default", "default", "default", -1, 0,
                                                        //    "", "", "", "", false, clsSecurity.UserIDLoged);

                                                        //clsHelpMethods.Update_Inventory(oHeader, oListInventory);

                                                        var responce = oData.Update_InventoryTxn(iFormID, txtDGNID.Text.Trim());
                                                        if (!responce.IsSuccess)
                                                        {
                                                            clsValidate.WriteErrorLog(txtDGNID.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
                                                        }
                                                        #endregion

                                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                                    //else
                                                    // MessageBox.Show("DGN " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                #endregion
                                            }
                                            catch (Exception ex)
                                            {
                                                SEACCException.Show(ex);
                                                clsValidate.WriteErrorLog("", iFormID, ex);
                                            }
                                            finally
                                            {
                                                Cursor = Cursors.Default;
                                                tbl_scsDamagedGoodNote oldRecord = tbl_scsDamagedGoodNote.Select(txtDGNID.Text.Trim());
                                                ClearFields();
                                                if (oldRecord != null)
                                                    FillDetails(oldRecord.DamagedGoodNote_ID);
                                            }
                                        }//check stock validity
                                    }
                                }
                            }//Check Permission validity
                        }
                        //}//check grid remarks validity
                    }
                }//check number validity
            }//check validity
            //}//Check Damaged goods store is available
        }
        #endregion

        #region Btn Print
        private void frm_scsDamageGoodsNote_SF_printButton_Click(object sender, EventArgs e)
        {
            print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_scsDamageGoodsNote_SF_draftButton_Click(object sender, EventArgs e)
        {
            print(true);
        }
        #endregion

        #region Btn Add Item
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (txtItemID.Tag != null && txtItemID.Tag.ToString().Length > 0)
            {
                RefreshGridByItemID(txtItemID.Tag.ToString());
            }
        }
        #endregion

        #region Btn Add PRN
        private void btnAddPRN_Click(object sender, EventArgs e)
        {
            //if (txtPRNID.Tag != null && txtPRNID.Tag.ToString().Length > 0)
            //{
            //    tbl_scsPurchaseReturnedNote detail = tbl_scsPurchaseReturnedNote.Select(txtPRNID.Tag.ToString());
            //    if (detail != null)
            //    {
            //        RefreshGridByPurchaseReturnNote(detail.PurchaseReturnedNote_ID);
            //    }
            //}
        }
        #endregion

        #region Btn Temp
        private void frm_scsDamageGoodsNote_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtDGNID.TextLength > 0 && txtDGNID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDGNID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtSupplierRefNo, true);
                clsCommon.SetEnableDisable_NormalLabel(lblIssuedRefNo, true);
                clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblStoreID, true);


                txtDGNID.Tag = null;
                dtpDGNDate.Value = clsSecurity.getServerDateTime();

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Order Ref No
                txtSupplierRefNo.Tag = null;
                txtSupplierRefNo.Clear();

                //Reset Primary Key
                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtDGNID.Text = "<Auto Generate>";
                else
                    txtDGNID.Clear();
                if (txtDGNID.Enabled)
                {
                    txtDGNID.SelectAll();
                    txtDGNID.Focus();
                }

                Attachments.Clear();
            }
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat_New(dgvDetail, clsFormatter.colorGrid, UI_Color);
            //clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);

            //clsHelpMethods.FormatGrid_Stock_External(dgvDetail);

            if (clsConfig.bWrap_ItemGrid_ItemName)
            {
                this.dgvDetail.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            //Change Grid Headers
            dgvDetail.Columns["ItemSubCategoryID"].HeaderText = clsConfig.sItemSubCategory;
        }

        private void CusDataGirdViewFormatForCalucation(DataGridView dgv, bool bWeightCalculation)
        {
            if (bWeightCalculation)
            {
                dgv.Columns["Weight"].Visible = true;
                dgv.Columns["WeightPrice"].Visible = false;
                dgv.Columns["Quantity"].Visible = false;
                dgv.Columns["UnitPrice"].Visible = false;
            }
            else if (!bWeightCalculation)
            {
                dgv.Columns["Weight"].Visible = false;
                dgv.Columns["WeightPrice"].Visible = false;
                dgv.Columns["Quantity"].Visible = true;
                dgv.Columns["UnitPrice"].Visible = false;
            }
        }
        #endregion

        #region Clear Fields
        /// <summary>
        /// Clears the fields.
        /// </summary>
        private void ClearFields()
        {
            //set the flag and enable the id
            IsUpdate = false;
            lblCancelled.Visible = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDGNID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtSupplierRefNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblIssuedRefNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblStoreID, true);

            txtDGNID.Tag = null;
            txtItemID.Tag = null;
            txtStoreID.Tag = null;
            txtItemSubCategory.Tag = null;
            txtSupplierRefNo.Tag = null;
            txtItemSerialNo.Tag = null;
            txtDamageGoodStore.Tag = null;

            txtItemSubCategory.Clear();
            txtItemSerialNo.Clear();
            txtItemID.Clear();
            txtStoreID.Clear();
            txtSupplierRefNo.Clear();
            glbOrderRefNo = "";
            txtRemark.Clear();
            txtDamageGoodStore.Clear();

            dtpDGNDate.Value = clsSecurity.getServerDateTime();

            chkUnitPricing.Checked = true;
            //chkSettings.Checked = true;
            chkShowSettle.Checked = false;
            chkPrintOriginal.Checked = false;

            bHasApproved = false;
            bHasChecked = false;
            dgvDetail.Rows.Clear();


            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtDGNID.Text = "<Auto Generate>";
            else
                txtDGNID.Clear();
            if (txtDGNID.Enabled)
            {
                txtDGNID.SelectAll();
                txtDGNID.Focus();
            }

            dt_ItemGrouped.Clear();
            Attachments.Clear();
            userDetailsColorChanges();
        }
        #endregion

        #region Fill Details
        /// <summary>
        /// Fills the details.
        /// </summary>
        /// <param name="sID">The s ID.</param>
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_scsDamagedGoodNote detail = tbl_scsDamagedGoodNote.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        if (detail.IsDeleted)
                        {
                            lblCancelled.Visible = true;
                            //btnDraft.Enabled = false;
                        }
                        else
                            //btnDraft.Enabled = true;

                            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDGNID, false);
                        //clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, false);
                        clsCommon.SetEnableDisable_NormalTextbox(txtSupplierRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblIssuedRefNo, false);
                        //clsCommon.SetEnableDisable_NormalLabel(lblStoreID, false);


                        //fill order details
                        tbl_zIssuedRefNo Issued = tbl_zIssuedRefNo.Select(detail.IssuedRefNo_ID);
                        if (Issued != null)
                        {
                            txtSupplierRefNo.Tag = detail.IssuedRefNo_ID;
                            txtSupplierRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_IssuedRefNo(detail.IssuedRefNo_ID));
                        }

                        //assign values
                        txtStoreID.Tag = detail.Store_ID;
                        txtStoreID.Text = clsGenaralName.getName_Store(detail.Store_ID);
                        txtDamageGoodStore.Tag = detail.Dg_Store_ID;
                        txtDamageGoodStore.Text = clsGenaralName.getName_Store(detail.Dg_Store_ID);
                        glbOrderRefNo = detail.IssuedRefNo_ID;

                        txtDGNID.Text = detail.DamagedGoodNote_ID;
                        dtpDGNDate.Value = detail.DamagedGoodNoteDate;

                        chkUnitPricing.Checked = !detail.IsWeightCalculation;
                        txtRemark.Text = detail.Remark;

                        //User Security

                        if (detail.IsApproved)
                        {
                            bHasApproved = true;
                            glbApprovedDate = detail.DateApproved;
                        }
                        if (detail.IsChecked)
                        {
                            bHasChecked = true;
                            glbCheckedDate = detail.DateChecked;
                        }

                        userDetailsColorChanges();

                        //fill item details
                        RefreshGrid(detail.DamagedGoodNote_ID);

                        Attachments.FillAttachments(sID);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Customer Detials
        //private void FillDetailsCustomer(string sCustomerID)
        //{
        //    try
        //    {
        //        txtSupplierID.Tag = null;
        //        txtSupplierID.Clear();
        //        txtDONo.Clear();
        //        txtCreditBalance.Clear();
        //        txtCreditLimit.Clear();
        //        txtDeposit.Clear();
        //        txtStatus.Clear();

        //        if (sCustomerID.Length > 0)
        //        {
        //            tbl_genCustomerMaster customer = tbl_genCustomerMaster.Select(sCustomerID);
        //            if (customer != null)
        //            {
        //                txtSupplierID.Tag = customer.Customer_ID;
        //                txtSupplierID.Text = customer.CustomerName;
        //                txtDONo.Text = customer.AddressDelivery;
        //                txtCreditBalance.Text = customer.OutstandingBalance.ToString();
        //                txtCreditLimit.Text = customer.CreditLimit.ToString();
        //                txtDeposit.Text = customer.DepositAmount.ToString();
        //                if (customer.IsBlacklisted)
        //                    txtStatus.Text = "Blacklisted";
        //                else
        //                    txtStatus.Text = "Not Blacklisted";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsValidate.WriteErrorLog("", iFormID,ex);
        //        SEACCException.Show(ex);
        //    }
        //}
        #endregion               

        #region Refresh Grid
        private void RefreshGrid(string sDgnID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();

                List<tbl_scsDamagedGoodNote_Detail> details = tbl_scsDamagedGoodNote_Detail.SelectAllByDamagedGoodNote_ID(sDgnID);
                foreach (tbl_scsDamagedGoodNote_Detail detail in details)
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (detail != null)
                    {
                        decimal dExRate = 1;
                        //if (txtCurrencyRate.Text.Trim().Length > 0)
                        //    dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        Fill_Datagrid(iRow, detail.Item_ID, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, "default",
                            "default", detail.Store_ID, item.IsTIEPItem, detail.Qty, detail.UnitPrice, detail.KiloPrice, detail.Weight, detail.TatalAmount, 0, detail.Remark, dExRate, "o");
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridByItemID(string sItemrID)
        {
            try
            {
                int iRow;
                tbl_genItemMaster detail = tbl_genItemMaster.Select(sItemrID);
                tbl_genItemMaster_Pricing oItemF = tbl_genItemMaster_Pricing.Select(sItemrID);
                if (detail != null && oItemF != null)
                {
                    decimal dExRate = 1;
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    clsCommon.ValidateForeignKey(ref txtItemSubCategory);
                    clsCommon.ValidateForeignKey(ref txtItemSerialNo, "0");
                    Fill_Datagrid(iRow, detail.Item_ID, txtItemSubCategory.Tag.ToString(), txtItemSubCategory.Text.Trim(), txtItemSerialNo.Tag.ToString(), txtItemSerialNo.Text.Trim(),
                        "default", "default", txtStoreID.Tag.ToString(), detail.IsTIEPItem, 0, oItemF.SellingPrice1, oItemF.SellingPrice6, 0, 0, 0, "", dExRate, "n");
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        #endregion

        #region Events KeyDown
        /// <summary>
        /// Handles the KeyDown event of the txtInvoiceID control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void txtInvoiceID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_DamagedGoodsNote();
        }
        private void txtCheckedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CheckedBy();
        }
        private void txtApprovedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_ApprovedBy();
        }
        private void frm_sasCustomerInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Item();
        }
        private void txtStoreID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Store();
        }
        #endregion

        #region Events Double Click
        private void txtInvoiceID_DoubleClick(object sender, EventArgs e)
        {
            Search_DamagedGoodsNote();
        }
        private void txtCheckedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }
        private void txtApprovedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }
        private void txtItemID_DoubleClick(object sender, EventArgs e)
        {
            Search_Item();
        }
        private void txtStoreID_DoubleClick(object sender, EventArgs e)
        {
            Search_Store();
        }
        private void txtDamageGoodStore_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            clsSearch.Search_MasterStore_DamagedStore(ref txtDamageGoodStore, clsConfig.enableBranchWiseFilterOnSearch ? true : false);
        }
        #endregion                

        #region Events CheckedChanged
        private void chkSettings_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkSettings.Checked)
            //{
            //    //xFlow.SendToBack();
            //    chkSettings.Image = Digiteq.Properties.Resources.network;
            //}
            //else
            //{
            //    xSetting.SendToBack();
            //    chkSettings.Image = Digiteq.Properties.Resources.settings;
            //}
        }
        private void chkUnitPricing_CheckedChanged(object sender, EventArgs e)
        {
            CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);

            //call cell end events for all records
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                DataGridViewCellEventArgs ar = new DataGridViewCellEventArgs(0, row.Index);
                dgvDetail_CellEndEdit(sender, ar);
            }
        }

        #endregion

        #region Events Datagried
        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            clsEvent.StockGrid_External_CellEndEdit(sender, e, dgvDetail, !chkUnitPricing.Checked);
        }
        private void dgvDetail_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            clsEvent.SalesGrid_CellParsing(sender, e, dgvDetail);
        }
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail_CellDoubleClick(sender, e);
        }
        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                if (sColName != "UOM" && sColName != "Quantity" && sColName != "Weight" && sColName != "UnitPrice" && sColName != "WeightPrice" && sColName != "Remarks" && sColName != "Warranty"
                    && sColName != "ItemStatus" && sColName != "StoreName" && sColName != "PRNID" && sColName != "POID")
                {
                    clsAlerts.DisplayItemViewer(dgvDetail["ItemCode", e.RowIndex].Value.ToString(),
                        dgvDetail["ItemSubCategoryID", e.RowIndex].Tag.ToString(), dgvDetail["ItemSubCategoryID2", e.RowIndex].Tag.ToString(),
                        dgvDetail["ItemSerialNo1", e.RowIndex].Value.ToString(), dgvDetail["ItemSerialNo2", e.RowIndex].Value.ToString());
                }
            }
        }
        #endregion

        #region Search Methods
        private void Search_DamagedGoodsNote()
        {
            try
            {
                clsSearch.Search_TransactionDamagedGoodsNote_Direct(ref txtDGNID, chkShowSettle.Checked);
                if (txtDGNID.Tag != null && txtDGNID.Tag.ToString().Trim().Length > 0)
                    FillDetails(txtDGNID.Tag.ToString());

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_Item()
        {
            //clsSearch.Search_MasterItem(ref txtItemID);
            if (CheckValidityStore())
            {
                string sStoreID = "", sSectionID = "", sDepartmentID = "";
                if (txtStoreID.Tag != null && txtStoreID.Tag.ToString().Trim().Length > 0)
                    sStoreID = txtStoreID.Tag.ToString();

                clsHelpMethods_Local.SearchItemAdvanceStock(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo, sStoreID, sSectionID, sDepartmentID);
                if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                    btnAddItem_Click(btnAddItem, new EventArgs());
            }
        }
        private void Search_Store()
        {
            clsSearch.Search_MasterStore(ref txtStoreID, clsConfig.enableBranchWiseFilterOnSearch ? true : false);
        }
        #endregion

        #region Check Validity
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtStoreID, "Store Name"))
            {
                //if (clsValidate.ValidateTextBox_EmptyValue(txtSupplierRefNo, "Internal Ref No"))
                //{
                if (clsValidate.ValidateTextBox_EmptyValue(txtDamageGoodStore, "Damage Goods Store"))
                {
                    if (clsValidate.ValidateTextBox_Tag_CannotBeEmptyOrDefault(txtDamageGoodStore, "Damage Goods Store"))
                    {

                        bStatus = true;
                    }
                }
                //}
            }
            return bStatus;
        }
        private bool CheckValidityStore()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (txtStoreID.Tag == null)
                {
                    strMessage += "\n" + "Store Name ";
                    txtStoreID.Focus();
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
        private bool CheckNumberValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        private bool ValidateDiscardingQty()
        {
            bool rtn = true;
            try
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    decimal dDamagedWeight = 0;
                    decimal dDamagedQty = 0;

                    dDamagedWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                    dDamagedQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                    if (chkUnitPricing.Checked)
                    {
                        if (dDamagedQty <= 0)
                        {
                            MessageBox.Show("Damaged Quantity Can not be Zero or Empty!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            rtn = false;
                            break;
                        }
                    }
                    else
                    {
                        if (dDamagedWeight <= 0)
                        {
                            MessageBox.Show("Damaged Weight Can not be Zero or Empty!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            rtn = false;
                            break;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return rtn;
        }
        private bool CheckRemarkValidity()
        {
            bool rtn = true;
            string sRemarks = "";
            try
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                    if (sRemarks.Trim().Length <= 0)
                    {
                        rtn = false;
                        MessageBox.Show("Reason for Damage cannot be empty !!!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return rtn;
        }
        //private bool CheckDamagedGoodsStore()
        //{
        //    bool rtn = true;
        //    tbl_genStoreMaster damagedStore = tbl_genStoreMaster.Select(clsConfig.sDamagedGoodsStore);
        //    if (damagedStore == null)
        //    {
        //        rtn = false;
        //        MessageBox.Show("You Must Configure Damaged Goods Store first  !!!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //    return rtn;
        //}

        #region Old CheckStockValidity
        //private bool CheckStockValidity()
        //{
        //    string strMessage = "", sOriginalItemCode = "", sItemCode = "", sItemStatus = "", sSubCategoryID1 = "", sSubCategoryID2 = "", sSerialNo1 = "", sSerialNo2 = "", sJobCode = "default", sStoreID = "";
        //    decimal dWeightActual = 0;
        //    decimal dQty = 0;
        //    bool bStatus = true;
        //    //if (clsConfig.bStockExceedLock_iGIN)
        //    //{
        //    foreach (DataGridViewRow row in dgvDetail.Rows)
        //    {
        //        sOriginalItemCode = sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
        //        dWeightActual = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
        //        dQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
        //        //sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
        //        sSubCategoryID1 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
        //        sSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
        //        sSerialNo1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
        //        sSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
        //        sItemStatus = clsValidate.ValidateGridValue(dgvDetail, "ItemStatus", row.Index, "");
        //        sStoreID = clsValidate.ValidateGridTag(dgvDetail, "StoreName", row.Index, "default");

        //        if (!clsConfig.bStoreStockWithJobID)
        //            sJobCode = "default";

        //        //validate stock detail
        //        #region Validate Stock Details
        //        tbl_genStore_Stock stock = tbl_genStore_Stock.Select(sStoreID, sItemCode, sJobCode, sSubCategoryID1, sSubCategoryID2, sSerialNo1, sSerialNo2);
        //        if (stock != null)
        //        {
        //            if (sItemStatus.ToLower() == "o") //new item
        //            {
        //                #region Old Items Stock Validation
        //                tbl_genStore_Stock damagedStock = tbl_genStore_Stock.Select(txtDamageGoodStore.Tag.ToString(), sItemCode, sJobCode, sSubCategoryID1, sSubCategoryID2, sSerialNo1, sSerialNo2);
        //                if (damagedStock != null)
        //                {
        //                    List<tbl_scsDamagedGoodNote_Detail> oldDetails = tbl_scsDamagedGoodNote_Detail.SelectAllByDamagedGoodNote_ID(txtDGNID.Text.Trim());
        //                    foreach (tbl_scsDamagedGoodNote_Detail oldDetail in oldDetails)
        //                    {
        //                        if (oldDetail.Item_ID == sOriginalItemCode && oldDetail.ItemSubCategory_ID == sSubCategoryID1 && oldDetail.ItemSubCategory2_ID == sSubCategoryID2 && oldDetail.ItemSerialNo == sSerialNo1 && oldDetail.ItemSerialNo2 == sSerialNo2 && oldDetail.Store_ID == sStoreID)
        //                        {
        //                            decimal dVeriance = 0;

        //                            #region Old Items Quantity Validation
        //                            if (oldDetail.Qty < dQty)
        //                                dVeriance = dQty - oldDetail.Qty;

        //                            if (stock.Qty < dVeriance)
        //                            {
        //                                strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required Quantity Is Not Available As IT Is In " + clsGenaralName.getName_Store(sStoreID) + "\n";
        //                                bStatus = false;
        //                            }
        //                            if (damagedStock.Qty < oldDetail.Qty)//validate damaged store qty
        //                            {
        //                                strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required Quantity Is Not Available As IT Is In " + clsGenaralName.getName_Store(txtDamageGoodStore.Tag.ToString()) + "\n";
        //                                bStatus = false;
        //                            }
        //                            #endregion

        //                            #region Old Items Weight Validation
        //                            decimal dVerianceWeight = 0;
        //                            if (oldDetail.Weight < dWeightActual)
        //                                dVerianceWeight = dWeightActual - oldDetail.Weight;

        //                            if (stock.Weight < dVerianceWeight)
        //                            {
        //                                strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required Weight Is Not Available As IT Is In " + clsGenaralName.getName_Store(sStoreID) + "\n";
        //                                bStatus = false;
        //                            }
        //                            if (damagedStock.Weight < oldDetail.Weight)//validate damaged store weight
        //                            {
        //                                strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required Weight Is Not Available As IT Is In " + clsGenaralName.getName_Store(txtDamageGoodStore.Tag.ToString()) + "\n";
        //                                bStatus = false;
        //                            }
        //                            #endregion
        //                        }
        //                    }
        //                }
        //                else //No stock in Damaged store
        //                {
        //                    strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Is Not Available In " + clsGenaralName.getName_Store(txtDamageGoodStore.Tag.ToString()) + " Stock\n";
        //                    bStatus = false;
        //                }
        //                #endregion
        //            }
        //            else //old item
        //            {
        //                #region New Item Stock Validation
        //                if (stock.Weight < dWeightActual) //check whether stock enabled - qty
        //                {
        //                    strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required Weight Is Not Available As IT Is In  " + clsGenaralName.getName_Store(sStoreID) + "\n";
        //                    bStatus = false;
        //                }
        //                if (stock.Qty < dQty ) //check whether stock enabled - weight
        //                {
        //                    strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + "  Required Quantity Is Not Available As IT Is In " + clsGenaralName.getName_Store(sStoreID) + "\n";
        //                    bStatus = false;
        //                }
        //                #endregion
        //            }
        //        }
        //        else //No stock in selected store
        //        {
        //            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Is Not Available In " + clsGenaralName.getName_Store(sStoreID) + " Stock\n";
        //            bStatus = false;
        //        }
        //        #endregion
        //    }

        //    if (bStatus == false)
        //    {
        //        MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    //}
        //    return bStatus;
        //}
        #endregion

        private bool CheckStockValidity()
        {
            bool bStatus = true;

            try
            {
                string strMessage = "", sItemCode = "", sItemStatus = "", sJobCode = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "";
                decimal dWeight = 0;
                decimal dQty = 0;

                foreach (DataRow row in dt_ItemGrouped.Rows)
                {
                    #region Stock Validation
                    sItemCode = clsValidate.ValidateRowValue(row, "ItemCode", "default");
                    dWeight = clsValidate.ValidateRowValue(row, "Weight", decimal.Parse("0.00"));
                    dQty = clsValidate.ValidateRowValue(row, "Quantity", decimal.Parse("0.00"));
                    sItemStatus = clsValidate.ValidateRowValue(row, "ItemStatus", "");
                    sJobCode = clsValidate.ValidateRowValue(row, "JobCode", "default");
                    sItemSubCategoryID = clsValidate.ValidateRowValue(row, "ItemSubCategoryID", "default");
                    sItemSubCategoryID2 = clsValidate.ValidateRowValue(row, "ItemSubCategoryID2", "default");
                    sItemSerialNo = clsValidate.ValidateRowValue(row, "ItemSerialNo", "0");
                    sItemSerialNo2 = clsValidate.ValidateRowValue(row, "ItemSerialNo2", "0");

                    if (!clsHelpMethods_Local.IsNonInventoryItem(sItemCode))
                    {
                        tbl_genStore_Stock oStoreStock;
                        oStoreStock = tbl_genStore_Stock.Select(txtStoreID.Tag.ToString(), sItemCode, sJobCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                        if (oStoreStock == null)
                        {
                            oStoreStock = new tbl_genStore_Stock(txtStoreID.Tag.ToString(), sItemCode, "default", "default", "default", "0", "0", 0, 0, 0, 0, 0, 0, 0, 0);
                            oStoreStock.Insert();
                        }
                        
                        tbl_genStoreMaster oStore = tbl_genStoreMaster.Select(txtStoreID.Tag.ToString());
                        if (oStoreStock != null && oStore != null)
                        {
                            #region if the item is old and check stock for more than one time
                            if (sItemStatus.ToLower() == "o")
                            {
                                decimal dOldQty = 0, dOldWeight = 0;
                                foreach (tbl_scsDamagedGoodNote_Detail oDGNDetail in tbl_scsDamagedGoodNote_Detail.SelectAllByDamagedGoodNote_ID(txtDGNID.Text.Trim()).Where(p => p.Item_ID == sItemCode && p.ItemSubCategory_ID == sItemSubCategoryID && p.ItemSubCategory2_ID == sItemSubCategoryID2))
                                {
                                    dOldQty += oDGNDetail.Qty;
                                    dOldWeight += oDGNDetail.Weight;
                                }

                                #region Old Items Quantity Validation
                                if (clsConfig.bStockValidateQty_DamageGood)
                                {
                                    if (oStoreStock.Qty + dOldQty < dQty)
                                    {
                                        strMessage += "Required Quantity of Item: \"" + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\" is not Availabe in  store :\"" + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\"\n";
                                        bStatus = false;
                                    }
                                }
                                #endregion
                                #region Old Items Weight Validation
                                if (clsConfig.bStockValidateWeight_DamageGood)
                                {
                                    if (oStoreStock.Weight + dOldWeight < dWeight)
                                    {
                                        strMessage += " Required Weight of Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "is Not Availabe In  store :" + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                                        bStatus = false;
                                    }
                                }
                                #endregion

                                if (!oStore.IsAllowMinusStock)
                                {
                                    if (oStoreStock.Qty + dOldQty - dQty < 0)
                                    {
                                        strMessage += "Minus Quantities not allowed - " + sItemCode + " \"" + clsGenaralName.getName_Item(sItemCode) + "\" in store : " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\"\n";
                                        bStatus = false;
                                    }
                                }
                            }
                            #endregion

                            #region first time added item ant have to check stock
                            else
                            {
                                #region Weight Validation
                                if (oStoreStock.Weight < dWeight && clsConfig.bStockValidateWeight_DamageGood)
                                {
                                    strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + " Required Weight Is Not Availabe As IT Is In  " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                                    bStatus = false;
                                }
                                #endregion
                                #region New Item Quantity Validation
                                if (oStoreStock.Qty < dQty && clsConfig.bStockValidateQty_DamageGood)
                                {
                                    strMessage += "Required Quantity of Item: \"" + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\" is not Availabe in store :\"" + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\"\n";
                                    bStatus = false;
                                }
                                #endregion

                                if (!oStore.IsAllowMinusStock)
                                {
                                    if (oStoreStock.Qty - dQty < 0)
                                    {
                                        strMessage += "Minus Quantities not allowed - " + sItemCode + " \"" + clsGenaralName.getName_Item(sItemCode) + "\" in store : " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\"\n";
                                        bStatus = false;
                                    }
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            if ((clsConfig.bStockValidateQty_DamageGood || clsConfig.bStockValidateWeight_DamageGood) && !clsHelpMethods_Local.IsNonInventoryItem(sItemCode) && (clsConfig.sSoftwareModel.Trim() != SoftwareModel_Sales.akt.ToString()))
                            {
                                strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "  Is Not Available In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + " Stock\n";
                                bStatus = false;
                            }
                        }
                    }
                    #endregion
                }
                if (bStatus == false)
                {
                    MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bStatus;
        }

        private bool CheckStockValidity(string sNoteID)
        {
            bool bStatus = true;
            try
            {
                string strMessage = "", sItemCode = "", sJobCode = "", sSubcategory1 = "", sSubcategory2 = "", sSerial1 = "", sSerial2 = "";
                decimal dWeightActual = 0;
                decimal dQty = 0;

                List<tbl_scsDamagedGoodNote_Detail> details = tbl_scsDamagedGoodNote_Detail.SelectAllByDamagedGoodNote_ID(sNoteID);
                foreach (tbl_scsDamagedGoodNote_Detail GRNdetail in details)
                {
                    sItemCode = GRNdetail.Item_ID;
                    sSubcategory1 = GRNdetail.ItemSubCategory_ID;
                    sSubcategory2 = GRNdetail.ItemSubCategory2_ID;
                    sSerial1 = GRNdetail.ItemSerialNo;
                    sSerial2 = GRNdetail.ItemSerialNo2;
                    dWeightActual = GRNdetail.Weight;
                    dQty = GRNdetail.Qty;
                    sJobCode = "default";

                    if (!clsConfig.bStoreStockWithJobID)
                        sJobCode = "default";

                    tbl_genStore_Stock damagedStock = tbl_genStore_Stock.Select(txtDamageGoodStore.Tag.ToString(), sItemCode, sJobCode, sSubcategory1, sSubcategory2, sSerial1, sSerial2);
                    if (damagedStock != null)
                    {
                        if (damagedStock.Weight < dWeightActual)
                        {
                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Damaged Stocks-in-hand is Not Sufficient Weight to Cancel this note \n";
                            bStatus = false;
                        }
                        if (damagedStock.Qty < dQty)
                        {
                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Damaged Stocks-in-hand is Not Sufficient Quantity to Cancel this note \n";
                            bStatus = false;
                        }
                    }
                    else
                    {
                        strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Is Not Available In " + clsGenaralName.getName_Section(txtDamageGoodStore.Tag.ToString()) + " Stock\n";
                        bStatus = false;
                    }
                }
                if (bStatus == false)
                {
                    MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtItemID);
                clsCommon.ValidateForeignKey(ref txtStoreID);
                clsCommon.ValidateForeignKey(ref txtItemSubCategory);
                clsCommon.ValidateForeignKey(ref txtItemSerialNo);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Datagrid
        private void Fill_Datagrid(int iRow, string ItemID, string ItemSubCategoryID1, string ItemSubCategoryID2, string ItemSerialNo1, string ItemSerialNo2, string PurchaseOrderID, string sPRNID, string sStoreID, bool bIsTiep, decimal Quantity, decimal UnitPrice, decimal WeightPrice, decimal Weight,
        decimal Amount, decimal dWarranty, string Remark, decimal dExRate, string sItemStatus)
        {
            try
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    string sItemID = "", sItemSub = "", sItemSub2 = "", sSerial = "", sSerial2 = "", sStore = "";
                    sItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                    sItemSub = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                    sItemSub2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                    sSerial = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                    sSerial2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                    sStore = clsValidate.ValidateGridTag(dgvDetail, "StoreName", row.Index, "default");

                    if (ItemID == sItemID && ItemSubCategoryID1 == sItemSub && ItemSubCategoryID2 == sItemSub2 && ItemSerialNo1 == sSerial && ItemSerialNo2 == sSerial2 && sStore == sStoreID)
                    {
                        dgvDetail.Rows.RemoveAt(iRow);
                        Weight += clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                        Quantity += clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                        iRow = row.Index;
                    }
                }

                dgvDetail["ItemCode", iRow].Value = ItemID;
                dgvDetail["ItemName", iRow].Value = clsGenaralName.getName_Item(ItemID);
                //
                dgvDetail["ItemSubCategoryID", iRow].Tag = ItemSubCategoryID1;
                dgvDetail["ItemSubCategoryID", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(ItemSubCategoryID1));
                dgvDetail["ItemSubCategoryID2", iRow].Tag = ItemSubCategoryID2;
                dgvDetail["ItemSubCategoryID2", iRow].Value = ItemSubCategoryID2;
                //
                dgvDetail["ItemSerialNo1", iRow].Value = ItemSerialNo1;
                dgvDetail["ItemSerialNo2", iRow].Value = ItemSerialNo2;
                dgvDetail["POID", iRow].Value = PurchaseOrderID;//add by thilina
                dgvDetail["PRNID", iRow].Value = sPRNID;
                dgvDetail["StoreName", iRow].Value = clsGenaralName.getName_Store(sStoreID);
                dgvDetail["StoreName", iRow].Tag = sStoreID;
                dgvDetail["IsTiep", iRow].Value = bIsTiep;
                dgvDetail["Warranty", iRow].Value = clsFormatter.FormatToNumberWithOneDecimalPlaces(dWarranty);
                dgvDetail["UOM", iRow].Value = clsGenaralName.getName_ItemUOM(ItemID);
                dgvDetail["Remarks", iRow].Value = Remark;
                dgvDetail["ItemStatus", iRow].Value = sItemStatus;

                if (clsCommon.IsCustomerizedGrid())
                {
                    dgvDetail["Quantity", iRow].Value = clsFormatter.FormatToNumberWithOneDecimalPlaces(Quantity);
                    dgvDetail["Weight", iRow].Value = clsFormatter.FormatToNumberWithOneDecimalPlaces(Weight);
                    dgvDetail["Amount", iRow].Value = clsFormatter.FormatToNumberWithTwoDecimalPlaces(Amount);
                    dgvDetail["Amount", iRow].Tag = Amount;

                    dgvDetail["UnitPrice", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(UnitPrice);
                    dgvDetail["UnitPrice", iRow].Tag = UnitPrice;
                    dgvDetail["WeightPrice", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(WeightPrice);
                    dgvDetail["WeightPrice", iRow].Tag = WeightPrice;
                }
                else
                {
                    dgvDetail["Quantity", iRow].Value = Quantity.ToString();
                    dgvDetail["UnitPrice", iRow].Value = UnitPrice.ToString();
                    dgvDetail["UnitPrice", iRow].Tag = UnitPrice;
                    dgvDetail["Weight", iRow].Value = Weight.ToString();
                    dgvDetail["WeightPrice", iRow].Value = WeightPrice.ToString();
                    dgvDetail["WeightPrice", iRow].Tag = WeightPrice;
                    dgvDetail["Amount", iRow].Value = Amount.ToString();
                    dgvDetail["Amount", iRow].Tag = Amount;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region print
        private void print(bool bIsDraft)
        {
            try
            {
                if (txtDGNID.TextLength > 0 && txtDGNID.Text != "<Auto Generate>")
                {
                    string sDuplicate = "";
                    if (!clsConfig.bDataSetActive_DamageGood)
                    {
                        #region View 
                        try
                        {
                            bool isDuplicate = false, isCanceled = false;
                            if (txtDGNID.TextLength > 0 && txtDGNID.Text != "<Auto Generate>")
                            {
                                //update receipt
                                string sCreateUser = "", sCheckedUser = "", sApprovedUser = "";
                                tbl_scsDamagedGoodNote order = tbl_scsDamagedGoodNote.Select(txtDGNID.Text.Trim());
                                if (order != null)
                                {
                                    if (order.PrintCount > 0)
                                        isDuplicate = true;
                                    order.PrintCount++;

                                    if (order.IsDeleted)
                                        isCanceled = true;

                                    sCreateUser = "[ " + clsGenaralName.getName_User(order.CreateUser_ID) + " ] [ " + order.DateCreate.ToShortDateString() + " ]";
                                    if (order.CheckedUser_ID != "default")
                                        sCheckedUser = "[ " + clsGenaralName.getName_User(order.CheckedUser_ID) + " ] [ " + order.DateChecked.ToShortDateString() + " ]";
                                    if (order.ApprovedUser_ID != "default")
                                        sApprovedUser = "[ " + clsGenaralName.getName_User(order.ApprovedUser_ID) + " ] [ " + order.DateApproved.ToShortDateString() + " ]";
                                    order.Update();
                                }

                                Cursor = Cursors.WaitCursor;
                                string s_Path = "", sReportTitle = "Damaged Good Note", sFormula = ""; string isRemark = "";
                                if (txtDGNID.TextLength > 0)
                                    sFormula = "{vw_rpt_scsDamagedGoodNote.DamagedGoodNote_ID}= '" + txtDGNID.Text.Trim() + "'";

                                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithDimension.ToString())
                                    isRemark = "r";
                                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                    isRemark = "r";
                                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithoutDimension.ToString())
                                    isRemark = "r";
                                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                                    isRemark = "s";
                                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithRemark.ToString())
                                    isRemark = "r";

                                ReportDocument RD = new ReportDocument();
                                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");

                                string sGetRptPath = clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_DamagedGoodsNote));

                                if (sGetRptPath != null && sGetRptPath.Length > 0)
                                    s_Path += sGetRptPath;
                                else
                                {

                                    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                                        s_Path += "\\Reports\\SCS\\NotePrinting\\rpt_scsDamagedGoodNoteWSC.rpt";
                                    else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                                        s_Path += "\\Reports\\SCS\\NotePrinting\\rpt_scsDamagedGoodNoteWSC.rpt";
                                    else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ceilingAndWallPanal.ToString())
                                        s_Path += "\\Reports\\SCS\\NotePrinting\\rpt_scsDamagedGoodNoteITc.rpt";
                                    else
                                        s_Path += "\\Reports\\SCS\\NotePrinting\\rpt_scsDamagedGoodNoteWSC.rpt";
                                }

                                frm_ReportViewer viewer = new frm_ReportViewer();
                                RD.Load(s_Path);
                              //  clsSecurity.LogonServer(ref RD);
                                RD.Refresh();

                                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())// && !chkPrintWithAmounts.Checked && !chkPrintWithBreakdown.Checked)
                                    RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);
                                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())// && !chkPrintWithAmounts.Checked && !chkPrintWithBreakdown.Checked)
                                    RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);

                                //RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                                RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                                //RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToShortDateString());
                                RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
                                RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
                                RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);
                                RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                                RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                                RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                                RD.DataDefinition.FormulaFields["CompanyEmail"].Text = clsCommon.fncsetstring(clsCommon.getCompanyEmail());
                                RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                                RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                                RD.DataDefinition.FormulaFields["Damagedstore"].Text = clsCommon.fncsetstring(clsGenaralName.getName_Store(txtDamageGoodStore.Tag.ToString()));

                                if (isDuplicate)
                                    RD.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring("Duplicate Copy");
                                if (isCanceled)
                                    RD.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring("");

                                //RD.DataDefinition.FormulaFields["TelphoneFax"].Text = "jaya";//clsCommon.fncsetstring(clsCommon.getSupplerTelephoneAndFax(order.Supplier_ID));
                                //RD.DataDefinition.FormulaFields["isRemark"].Text = clsCommon.fncsetstring(isRemark);

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
                            else
                                MessageBox.Show("Please Select the DGN To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            SEACCException.Show(ex);
                            clsValidate.WriteErrorLog("", iFormID, ex);
                        }
                        finally
                        {
                            Cursor = Cursors.Default;
                        }
                        #endregion
                    }
                    else
                    {
                        #region dataset
                        try
                        {
                            string sDraft = "", sDeleted = "";

                            string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                            if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_DamagedGoodsNote), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                            {
                                glb_dts_scsDamageGoods.Clear();
                                glb_dtsReportExport.Clear();
                                Cursor = Cursors.WaitCursor;

                                bool bPermissinOkToPrint = true;

                                if (chkPrintOriginal.Checked)
                                    bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_DamagedGoodsNote));
                                if (bPermissinOkToPrint)
                                {
                                    tbl_scsDamagedGoodNote oDGN = tbl_scsDamagedGoodNote.Select(txtDGNID.Text);
                                    if (oDGN != null)
                                    {
                                        if (!bIsDraft)
                                        {
                                            //oDGN.PrintCount++;
                                            //oDGN.Update();
                                            //if (oDGN.PrintCount > 0)
                                            //    sDuplicate = "Duplicate Copy " + (oDGN.PrintCount--);

                                            //oDGN.DatePrinted = clsSecurity.getServerDateTime();
                                            //oDGN.PrintedTerminal_ID = clsSecurity.TerminalID;
                                            //oDGN.PrintedUser_ID = clsSecurity.UserIDLoged;

                                            if (!chkPrintOriginal.Checked)
                                                sDuplicate = oDGN.PrintCount > 0 ? "Duplicate Copy " + oDGN.PrintCount : "";

                                            oDGN.PrintCount++;
                                            oDGN.Update();

                                        }
                                        else
                                            sDraft = "Draft";

                                        if (oDGN.IsDeleted)
                                            sDeleted = "Deleted";

                                        string sCreateUser = "", sCheckedUser = "", sApprovedUser = "";
                                        sCreateUser = "[ " + clsGenaralName.getName_User(oDGN.CreateUser_ID) + " ] [ " + oDGN.DateCreate.ToShortDateString() + " ]";
                                        if (oDGN.CheckedUser_ID != "default")
                                            sCheckedUser = "[ " + clsGenaralName.getName_User(oDGN.CheckedUser_ID) + " ] [ " + oDGN.DateChecked.ToShortDateString() + " ]";
                                        if (oDGN.ApprovedUser_ID != "default")
                                            sApprovedUser = "[ " + clsGenaralName.getName_User(oDGN.ApprovedUser_ID) + " ] [ " + oDGN.DateApproved.ToShortDateString() + " ]";
                                        oDGN.Update();

                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUser, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sCheckedUser, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUser, true);

                                        #region fill details
                                        glb_dts_scsDamageGoods.dt_scsDamageGood.Adddt_scsDamageGoodRow(oDGN.DamagedGoodNote_ID, oDGN.DamagedGoodNoteDate, oDGN.Store_ID, clsGenaralName.getName_Store(oDGN.Store_ID), oDGN.Remark, clsGenaralName.getName_OrderRefNo(oDGN.IssuedRefNo_ID), oDGN.CreateUser_ID, oDGN.IsSeattled, oDGN.IsDeleted);

                                        foreach (tbl_scsDamagedGoodNote_Detail oDetails_DGN in tbl_scsDamagedGoodNote_Detail.SelectAllByDamagedGoodNote_ID(oDGN.DamagedGoodNote_ID))
                                        {
                                            tbl_genItemMaster oitem = tbl_genItemMaster.Select(oDetails_DGN.Item_ID);
                                            glb_dts_scsDamageGoods.dt_scsDamageGood_Detail.Adddt_scsDamageGood_DetailRow(oDetails_DGN.DamagedGoodNote_ID, oDetails_DGN.Item_ID, clsGenaralName.getName_Item(oDetails_DGN.Item_ID), oDetails_DGN.ItemSubCategory_ID, oDetails_DGN.ItemSubCategory_ID, oDetails_DGN.Qty, oDetails_DGN.Weight, clsGenaralName.getName_ItemUOMName(oitem.Item_ID), oDetails_DGN.Remark, clsGenaralName.getName_Store(oDetails_DGN.Store_ID));
                                        }
                                        #endregion
                                    }

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", clsCommon.getCompanyEmail(), true);

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", sDraft, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DupicateCopy", sDuplicate, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("isDel", sDeleted, true);

                                    //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())// && !chkPrintWithAmounts.Checked && !chkPrintWithBreakdown.Checked)
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("SubCategory", clsConfig.sItemSubCategory, true);
                                    //else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())// && !chkPrintWithAmounts.Checked && !chkPrintWithBreakdown.Checked)
                                    //    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("SubCategory", sSubCat, true);

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Damagedstore", clsGenaralName.getName_Store(txtDamageGoodStore.Tag.ToString()), true);

                                    #region Company Details Fill
                                    string sCompanyName = clsSecurity.CompanyName, sCompanyAddress1 = clsSecurity.CompanyAddress1, sCompanyAddress2 = clsSecurity.CompanyAddress2;
                                    byte[] bCompanyImage = clsCommon.getCompanyImage();
                                    if (bIsDraft)
                                    {
                                        if (!clsConfig.isVisibleCompanyInfoInDraftPrint)
                                        {
                                            sCompanyName = "";
                                            sCompanyAddress1 = "";
                                            sCompanyAddress2 = "";
                                            bCompanyImage = null;

                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", "", true);
                                        }
                                    }
                                    glb_dts_scsDamageGoods.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, sReportTitle_Main, "", "", clsSecurity.UserNameLoged, "", "", "");
                                    #endregion

                                    frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                    rpt.print(sReportPath, glb_dts_scsDamageGoods, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_DamagedGoodsNote));
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            clsValidate.WriteErrorLog("", iFormID, ex);
                            SEACCException.Show(ex);
                        }
                        finally
                        {
                            glb_dts_scsDamageGoods.Clear();
                            glb_dtsReportExport.Clear();
                            Cursor = Cursors.Default;
                        }
                        #endregion
                    }
                }
                else
                    MessageBox.Show("Please Select the Damage Good Note To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        private void frm_scsDamageGoodsNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            Attachments.Close();
        }


        #region User Checked Approve Details
        private void frm_scsDamageGoodsNote_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }
        private void frm_scsDamageGoodsNote_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpDGNDate.Value.Date))
                {
                    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtDGNID.Text != null && txtDGNID.TextLength > 0 && txtDGNID.Text != "<Auto Generate>")
                        {
                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForApproved), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (msgResult == DialogResult.Yes)
                            {
                                frmSetApproved login = new frmSetApproved();
                                login.iFormID = iFormID;
                                login.userID = clsSecurity.UserIDLoged;
                                login.ShowDialog();
                                if (frmSetApproved.bChecked)
                                {
                                    bHasApproved = true;
                                    glbApprovedDate = clsSecurity.getServerDateTime();
                                    if (IsUpdate)
                                    {
                                        userDetailsColorChanges();

                                        tbl_scsDamagedGoodNote objDGN = tbl_scsDamagedGoodNote.Select(txtDGNID.Text.Trim());
                                        if (objDGN != null)
                                        {
                                            objDGN.IsApproved = true;
                                            objDGN.DateApproved = clsSecurity.getServerDateTime();
                                            objDGN.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                            objDGN.Update();
                                        }
                                    }
                                }
                                else if (frmSetApproved.bReset)
                                    bHasApproved = false;
                            }
                        }
                        else
                            MessageBox.Show("Please Fill Details to Approve", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToApprove), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CheckedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpDGNDate.Value.Date))
                {
                    if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtDGNID.Text != null && txtDGNID.TextLength > 0 && txtDGNID.Text != "<Auto Generate>")
                        {
                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForChecked), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (msgResult == DialogResult.Yes)
                            {
                                frmSetChecked login = new frmSetChecked();
                                login.iFormID = iFormID;
                                login.userID = clsSecurity.UserIDLoged;
                                login.ShowDialog();
                                if (frmSetChecked.bChecked)
                                {
                                    bHasChecked = true;
                                    glbCheckedDate = clsSecurity.getServerDateTime();

                                    if (IsUpdate)
                                    {
                                        userDetailsColorChanges();

                                        tbl_scsDamagedGoodNote objDGN = tbl_scsDamagedGoodNote.Select(txtDGNID.Text.Trim());
                                        if (objDGN != null)
                                        {
                                            objDGN.IsChecked = true;
                                            objDGN.DateChecked = clsSecurity.getServerDateTime();
                                            objDGN.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objDGN.Update();
                                        }
                                    }

                                }
                                else if (frmSetChecked.bReset)
                                    bHasChecked = false;
                            }
                        }
                        else
                            MessageBox.Show("Please Fill Details to Check", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToCheck), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion
        private void frm_scsDamageGoodsNote_SF_History_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDGNID.Text != "" || txtDGNID.Text != "<Auto Generate>")
                {
                    tbl_scsDamagedGoodNote detail = tbl_scsDamagedGoodNote.Select(txtDGNID.Text.Trim());
                    if (detail != null)
                    {
                        DataTable dt_UserDetails = new DataTable();
                        dt_UserDetails.Columns.Add("usertype", typeof(string));
                        dt_UserDetails.Columns.Add("Column1", typeof(string));
                        dt_UserDetails.Columns.Add("user", typeof(string));
                        dt_UserDetails.Columns.Add("Column2", typeof(string));
                        dt_UserDetails.Columns.Add("datetime", typeof(string));

                        dt_UserDetails.Rows.Add("Created By", ":", clsGenaralName.getName_User(detail.CreateUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateCreate));

                        if (detail.DateCreate != detail.DateModified)
                            dt_UserDetails.Rows.Add("Last Modified By", ":", clsGenaralName.getName_User(detail.ModifiedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateModified));

                        if (detail.IsChecked)
                            dt_UserDetails.Rows.Add("Checked By", ":", clsGenaralName.getName_User(detail.CheckedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateChecked));

                        if (detail.IsApproved)
                            dt_UserDetails.Rows.Add("Approved By", ":", clsGenaralName.getName_User(detail.ApprovedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateApproved));

                        Point startPoint = this.PointToScreen(new Point());

                        frmApprovedCheckedValidity frm = new frmApprovedCheckedValidity();
                        frm.ShowWindow(startPoint.X, (startPoint.Y + this.Size.Height), dt_UserDetails);
                    }
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        #region User Details Color Changes
        //private void userDetailsColorChanges()
        //{
        //    if (bHasApproved)
        //    {
        //        this.btnApproved.BackColor = System.Drawing.Color.FromArgb(3, 87, 11);
        //        this.btnChecked.BackColor = System.Drawing.Color.DarkGray;
        //        btnApproved.Enabled = false;
        //        btnChecked.Enabled = false;

        //    }
        //    if (bHasChecked)
        //    {
        //        this.btnChecked.BackColor = System.Drawing.Color.FromArgb(3, 87, 11);
        //        btnChecked.Enabled = false;
        //    }
        //    if (!bHasApproved && !bHasChecked)
        //    {
        //        this.btnApproved.ForeColor = System.Drawing.SystemColors.ControlText;
        //        this.btnChecked.ForeColor = System.Drawing.SystemColors.ControlText;
        //        this.btnApproved.BackColor = System.Drawing.Color.LightGray;
        //        this.btnChecked.BackColor = System.Drawing.Color.LightGray;
        //        btnApproved.Enabled = true;
        //        btnChecked.Enabled = true;
        //    }
        //}
        #endregion


        #endregion

        #region Setting Panel Events
        //public override void SettingsClick()
        //{
        //    xSetting.Visible = true;
        //    xSetting.Focus();
        //}

        private void btn_Close_Click(object sender, EventArgs e)
        {
            xSetting.Visible = false;
        }       

        private void xSetting_Leave(object sender, EventArgs e)
        {
            xSetting.Visible = false;
        }
        #endregion

        #region Settings Panel Events
        public override void SettingsClick()
        {
            if (panel2.Visible == true)
                panel2.Visible = false;
            else
            {
                panel2.Visible = true;
                panel2.Focus();
            }
        }

        private void panel2_Leave(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }
        #endregion
    }
}
