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
using Zion.ERP.Reports.DataSets.SCS;
using Zion.ERP.Reports.DataSets;
using SEACC.DATA.Data.SCS;
using ZION.ERP.Reports.DataSets.SCS;

namespace Digiteq
{
    public partial class frm_scsDiscardedGoodNote : SEACC_Form
    {
        
        //to manage update and insert
        //static bool IsUpdate = false;

        //form manage
        //string sFormConfigCode;
        //   public int iFormID;

        public string glbDisGnNo = "";
        //for security handle
        //public bool bNoAccess;
        //public bool bHasChecked;
        //public bool bHasApproved;
        //    DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        //    DateTime glbCheckedDate = clsSecurity.getServerDateTime();

        dts_scsDiscardedItemNote glb_dts_scsDiscardedItemNote = new dts_scsDiscardedItemNote();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();

        InventoryTxnData oData = new InventoryTxnData();


        #region Form Load
        public frm_scsDiscardedGoodNote(FormName _enmForm)
        {
            //sFormConfigCode = clsAutocode.getFormConfigCode(FormName.scsDiscardedGoodsNote);
            //iFormID = clsSecurity.getFormID(FormName.scsDiscardedGoodsNote);
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
            //clsFormatter.setFormatForm(this, "Discarded Item Note [DIN]", 4, iFormID);

            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);
            CusDataGridViewFormat();

            ClearFields();
            chkUnitPricing.Checked = true;

            if (glbDisGnNo.Length > 0)
            {
                FillDetails(glbDisGnNo);
            }
        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void frm_scsDiscardedGoodNote_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void frm_scsDiscardedGoodNote_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDINID.Text.Trim().Length > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpDGNDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreID.Tag.ToString(), IsUpdate))
                            {
                                Cursor = Cursors.WaitCursor;
                                tbl_scsDiscardedGoodNote detail = tbl_scsDiscardedGoodNote.Select(txtDINID.Text.Trim());
                                if (detail != null)
                                {
                                    if (!detail.IsLocked && !detail.IsFinished && !detail.IsDeleted)
                                    {
                                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " DIN : " + txtDINID.Text), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (msgResult == DialogResult.Yes)
                                        {
                                            #region Update Other Tables
                                            foreach (tbl_scsDiscardedGoodNote_Detail Olddetail in tbl_scsDiscardedGoodNote_Detail.SelectAllByDiscardedGoodNote_ID(txtDINID.Text.Trim()))
                                            {
                                                if (Olddetail.Item_ID != null)
                                                {
                                                    #region Update Store Stock
                                                    decimal dWeightedAverageCostPrice = 0;
                                                 //   clsHelpMethods_Local.UpdateStoreStock(iFormID, Olddetail.DiscardedGoodNote_ID, detail.DiscardedGoodNoteDate, Olddetail.Item_ID, "0", txtStoreID.Tag.ToString(), Olddetail.DiscardingQty, Olddetail.DiscardingWeight, Olddetail.SalvageValue, true, false, true, ref dWeightedAverageCostPrice);
                                                    Olddetail.WeightedAvgCost = dWeightedAverageCostPrice;
                                                    Olddetail.Update();
                                                    //   clsHelpMethods_Local.RollBackFifo_Stock(iFormID, Olddetail.DiscardedGoodNote_ID,Olddetail.DiscardingQty);
                                                    #endregion
                                                }
                                            }
                                            #endregion

                                            detail.DateModified = clsSecurity.getServerDateTime();
                                            detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                            detail.IsDeleted = true;
                                            detail.Update();

                                            // clsHelpMethods.Delete_Inventory(iFormID, 0, txtDINID.Text.Trim());
                                            var responce = oData.Delete_InventoryTxn(iFormID, txtDINID.Text.Trim());
                                            if (!responce.IsSuccess)
                                            {
                                                clsValidate.WriteErrorLog(txtDINID.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
                                            }


                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            ClearFields();
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
        private void frm_scsDiscardedGoodNote_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity_EmptyField())
            {
                if (CheckNumberValidity())
                {
                    if (clsValidate.CheckGridCountValidity(dgvDetail.RowCount, iFormID))
                    {
                        if (ValidateDiscardingQty())
                        {
                            if (CheckStockValidity())
                            {
                                if (clsMethods_GL.CheckValidity_FinancialYear(dtpDGNDate.Value.Date))
                                {
                                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                                    {
                                        if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreID.Tag.ToString(), IsUpdate))
                                        {
                                            try
                                            {
                                                Cursor = Cursors.WaitCursor;
                                                ValidateEmptyForeignKey();

                                                #region Update DIN
                                                if (IsUpdate)
                                                {
                                                    tbl_scsDiscardedGoodNote oldRecord = tbl_scsDiscardedGoodNote.Select(txtDINID.Text.Trim());
                                                    if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                                                    {
                                                        if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                                                        {
                                                            if (!oldRecord.IsChecked ||
                                                                (oldRecord.IsChecked &&
                                                                 clsSecurity.PermissionToApproved(
                                                                     clsSecurity.UserIDLoged, iFormID)))
                                                            {
                                                                if (clsValidate.CheckValidity_TransactionCodeLength(txtDINID.Text))
                                                                {
                                                                  //  List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();

                                                                    #region Rollback StoreStock

                                                                    foreach (
                                                                        tbl_scsDiscardedGoodNote_Detail oUpdatedRecord
                                                                        in tbl_scsDiscardedGoodNote_Detail
                                                                            .SelectAllByDiscardedGoodNote_ID(
                                                                                txtDINID.Text.Trim()))
                                                                    {
                                                                        decimal dWeightedAverageCostPrice = 0;
                                                                        //clsHelpMethods_Local.UpdateStoreStock(iFormID,
                                                                        //    oldRecord.DiscardedGoodNote_ID,
                                                                        //    oldRecord.DiscardedGoodNoteDate,
                                                                        //    oUpdatedRecord.Item_ID, "0",
                                                                        //    txtStoreID.Tag.ToString(),
                                                                        //    oUpdatedRecord.DiscardingQty,
                                                                        //    oUpdatedRecord.DiscardingWeight,
                                                                        //    oUpdatedRecord.SalvageValue, true, false,
                                                                        //    true, ref dWeightedAverageCostPrice);

                                                                        oUpdatedRecord.WeightedAvgCost = dWeightedAverageCostPrice;
                                                                        oUpdatedRecord.Update();
                                                                        // clsHelpMethods_Local.RollBackFifo_Stock(iFormID, oUpdatedRecord.DiscardedGoodNote_ID, oUpdatedRecord.DiscardingQty);
                                                                    }

                                                                    #endregion

                                                                    //Update DIN Detail

                                                                    #region Update Old DIN Items
                                                                    int iCount = 1;
                                                                    List<tbl_scsDiscardedGoodNote_Detail> oldDetails =
                                                                        tbl_scsDiscardedGoodNote_Detail
                                                                            .SelectAllByDiscardedGoodNote_ID(
                                                                                txtDINID.Text.Trim());
                                                                    foreach (tbl_scsDiscardedGoodNote_Detail oldDetail
                                                                        in oldDetails)
                                                                    {
                                                                        string sJobCode = "default",
                                                                            sItemCode = "",
                                                                            sItemSubCategoryID1 = "",
                                                                            sItemSubCategoryID2 = "",
                                                                            sItemSerialNo1 = "",
                                                                            sItemSerialNo2 = "",
                                                                            sRemarks = "";
                                                                        decimal dDamagedQty = 0,
                                                                            dDiscardingQty = 0,
                                                                            dDamagedWeight = 0,
                                                                            dSalvageValue = 0,
                                                                            dDiscardingWeight = 0;
                                                                        bool bHasItemInDB = false;

                                                                        foreach (DataGridViewRow row in dgvDetail.Rows)
                                                                        {
                                                                            //*******************************           VERY IMPORTANT      ***************************************
                                                                            //In this grid we didn't change the column names as we use common grid for all stock notes
                                                                            //so we have some global method manipulate according to this column names 
                                                                            //              SO DON'T CONFUSE WITH THE GRID COLUMN NAMES CONSIDER ONLY THE VERIABLE NAMES
                                                                            sItemCode = clsValidate.ValidateGridValue(
                                                                                dgvDetail, "ItemCode", row.Index, "");
                                                                            sItemSubCategoryID1 =
                                                                                clsValidate.ValidateGridTag(dgvDetail,
                                                                                    "ItemSubCategoryID1", row.Index,
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
                                                                            dDamagedQty =
                                                                                clsValidate.ValidateGridValue(dgvDetail,
                                                                                    "Quantity", row.Index,
                                                                                    decimal.Parse("0.00"));
                                                                            dDiscardingQty =
                                                                                clsValidate.ValidateGridValue(dgvDetail,
                                                                                    "UnitPrice", row.Index,
                                                                                    decimal.Parse("0.00"));
                                                                            dDiscardingWeight =
                                                                                clsValidate.ValidateGridValue(dgvDetail,
                                                                                    "WeightPrice", row.Index,
                                                                                    decimal.Parse("0.00"));
                                                                            dDamagedWeight =
                                                                                clsValidate.ValidateGridValue(dgvDetail,
                                                                                    "Weight", row.Index,
                                                                                    decimal.Parse("0.00"));
                                                                            dSalvageValue =
                                                                                clsValidate.ValidateGridValue(dgvDetail,
                                                                                    "Amount", row.Index,
                                                                                    decimal.Parse("0.00"));
                                                                            sRemarks = clsValidate.ValidateGridValue(
                                                                                dgvDetail, "Remarks", row.Index, "");

                                                                            if (oldDetail.DiscardedGoodNote_ID ==
                                                                                txtDINID.Text.Trim() &&
                                                                                oldDetail.Item_ID == sItemCode &&
                                                                                oldDetail.ItemSubCategory_ID ==
                                                                                sItemSubCategoryID1 &&
                                                                                oldDetail.ItemSubCategory2_ID ==
                                                                                sItemSubCategoryID2 &&
                                                                                oldDetail.ItemSerialNo ==
                                                                                sItemSerialNo1 &&
                                                                                oldDetail.ItemSerialNo2 ==
                                                                                sItemSerialNo2)
                                                                            {
                                                                                bHasItemInDB = true;
                                                                                dgvDetail.Rows.RemoveAt(row.Index);
                                                                                break; //database contain this item
                                                                            }
                                                                        }

                                                                        if (bHasItemInDB)
                                                                        {
                                                                            #region Update old item detailsk

                                                                            //Update store stock when user modify the old recode
                                                                            //Don't put this region below update 

                                                                            #region Update Store Stock

                                                                            if (clsConfig.bStockValidateQty_DIN)
                                                                            {
                                                                                //   if (clsHelpMethods_Local.Store_StockQuantityIncrease(txtStoreID.Tag.ToString(), sItemCode, sJobCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, oldDetail.DiscardingQty))
                                                                                //       clsHelpMethods_Local.Store_StockQuantityDecrease(txtStoreID.Tag.ToString(), sItemCode, sJobCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, dDiscardingQty);
                                                                            }

                                                                            if (clsConfig.bStockValidateWeight_DIN)
                                                                            {
                                                                                //    if (clsHelpMethods_Local.Store_StockWeightIncrease(txtStoreID.Tag.ToString(), sItemCode, sJobCode, oldDetail.ItemSubCategory_ID, oldDetail.ItemSubCategory2_ID, oldDetail.ItemSerialNo, oldDetail.ItemSerialNo2, oldDetail.DiscardingWeight))
                                                                                //         clsHelpMethods_Local.Store_StockWeightDecrease(txtStoreID.Tag.ToString(), sItemCode, sJobCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, dDiscardingWeight);
                                                                            }

                                                                            #endregion

                                                                            oldDetail.Item_ID = sItemCode;
                                                                            oldDetail.ItemSubCategory_ID =
                                                                                sItemSubCategoryID1;
                                                                            oldDetail.ItemSubCategory2_ID =
                                                                                sItemSubCategoryID2;
                                                                            oldDetail.ItemSerialNo = sItemSerialNo1;
                                                                            oldDetail.ItemSerialNo2 = sItemSerialNo2;
                                                                            oldDetail.DamagedQty = dDamagedQty;
                                                                            oldDetail.DamagedWeight = dDamagedWeight;
                                                                            oldDetail.DiscardingWeight =
                                                                                dDiscardingWeight;
                                                                            oldDetail.DiscardingQty = dDiscardingQty;
                                                                            oldDetail.SalvageValue = dSalvageValue;
                                                                            oldDetail.Remark = sRemarks;

                                                                            oldDetail.Update();

                                                                            #endregion

                                                                            #region Pass Value to Inventory Detail
                                                                            //tbl_scsInventoryTxnDetail oInventoryDetail_From = new tbl_scsInventoryTxnDetail(iFormID, iCount,0,  txtDINID.Text.Trim(), dtpDGNDate.Value,
                                                                            //                            "", "", "", "", "default", "default", txtStoreID.Tag.ToString(),
                                                                            //                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), 0, dDiscardingQty, 0, 0, false);
                                                                            //oListInventory.Add(oInventoryDetail_From);
                                                                            #endregion

                                                                            iCount++;
                                                                        }
                                                                        else
                                                                        {
                                                                            #region Delete old item detail

                                                                            //Update Store Stock if user delete old inserted item

                                                                            #region Update Store Stock If User Delete the old Input

                                                                            if (clsHelpMethods_Local
                                                                                .isStore_StockAvailabel(
                                                                                    txtStoreID.Tag.ToString(),
                                                                                    oldDetail.Item_ID, sJobCode,
                                                                                    oldDetail.ItemSubCategory_ID,
                                                                                    oldDetail.ItemSubCategory2_ID,
                                                                                    oldDetail.ItemSerialNo,
                                                                                    oldDetail.ItemSerialNo2))
                                                                            {
                                                                                //  if (clsConfig.bStockValidateQty_DIN)
                                                                                //      clsHelpMethods_Local.Store_StockQuantityIncrease(txtStoreID.Tag.ToString(), oldDetail.Item_ID, sJobCode, oldDetail.ItemSubCategory_ID, oldDetail.ItemSubCategory2_ID, oldDetail.ItemSerialNo, oldDetail.ItemSerialNo2, oldDetail.DiscardingQty);
                                                                                //  if (clsConfig.bStockValidateWeight_DIN)
                                                                                //      clsHelpMethods_Local.Store_StockWeightIncrease(txtStoreID.Tag.ToString(), oldDetail.Item_ID, sJobCode, oldDetail.ItemSubCategory_ID, oldDetail.ItemSubCategory2_ID, oldDetail.ItemSerialNo, oldDetail.ItemSerialNo2, oldDetail.DiscardingWeight);
                                                                            }
                                                                            else
                                                                            {
                                                                                //   clsHelpMethods_Local.Store_NewStock(txtStoreID.Tag.ToString(), oldDetail.Item_ID, sJobCode, oldDetail.ItemSubCategory_ID, oldDetail.ItemSubCategory2_ID, oldDetail.ItemSerialNo, oldDetail.ItemSerialNo2, oldDetail.DiscardingWeight, 0, oldDetail.DiscardingQty, 0, 0, 0, 0, 0);
                                                                            }

                                                                            #endregion

                                                                            oldDetail.Delete();

                                                                            #endregion
                                                                        }                                                                        
                                                                    }

                                                                    #endregion

                                                                    #region Insert Newly Added Items

                                                                    foreach (DataGridViewRow row in dgvDetail.Rows)
                                                                    {
                                                                        string sJobCode = "default",
                                                                            sItemCode = "",
                                                                            sItemSubCategoryID1 = "",
                                                                            sItemSubCategoryID2 = "",
                                                                            sItemSerialNo1 = "",
                                                                            sItemSerialNo2 = "",
                                                                            sRemarks = "";
                                                                        decimal dDamagedQty = 0,
                                                                            dDiscardingQty = 0,
                                                                            dDamagedWeight = 0,
                                                                            dSalvageValue = 0,
                                                                            dDiscardingWeight = 0;

                                                                        //*******************************           VERY IMPORTANT      ***************************************
                                                                        //In this grid we didn't change the column names as we use common grid for all stock notes
                                                                        //so we have some global method manipulate according to this column names 
                                                                        //              SO DON'T CONFUSE WITH THE GRID COLUMN NAMES CONSIDER ONLY THE VERIABLE NAMES
                                                                        sItemCode = clsValidate.ValidateGridValue(
                                                                            dgvDetail, "ItemCode", row.Index, "");
                                                                        sItemSubCategoryID1 =
                                                                            clsValidate.ValidateGridTag(dgvDetail,
                                                                                "ItemSubCategoryID1", row.Index,
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
                                                                        dDamagedQty =
                                                                            clsValidate.ValidateGridValue(dgvDetail,
                                                                                "Quantity", row.Index,
                                                                                decimal.Parse("0.00"));
                                                                        dDiscardingQty =
                                                                            clsValidate.ValidateGridValue(dgvDetail,
                                                                                "UnitPrice", row.Index,
                                                                                decimal.Parse("0.00"));
                                                                        dDiscardingWeight =
                                                                            clsValidate.ValidateGridValue(dgvDetail,
                                                                                "WeightPrice", row.Index,
                                                                                decimal.Parse("0.00"));
                                                                        dDamagedWeight =
                                                                            clsValidate.ValidateGridValue(dgvDetail,
                                                                                "Weight", row.Index,
                                                                                decimal.Parse("0.00"));
                                                                        dSalvageValue =
                                                                            clsValidate.ValidateGridValue(dgvDetail,
                                                                                "Amount", row.Index,
                                                                                decimal.Parse("0.00"));
                                                                        sRemarks = clsValidate.ValidateGridValue(
                                                                            dgvDetail, "Remarks", row.Index, "");

                                                                        tbl_scsDiscardedGoodNote_Detail DINdetail =
                                                                            new tbl_scsDiscardedGoodNote_Detail(
                                                                                clsHelpMethods_Local
                                                                                    .GetMaxzimumLineNoDiscardedGoodNote(
                                                                                        txtDINID.Text.Trim()),
                                                                                txtDINID.Text.Trim(), sItemCode,
                                                                                sItemSubCategoryID1,
                                                                                sItemSubCategoryID2, sItemSerialNo1,
                                                                                sItemSerialNo2, dDamagedQty,
                                                                                dDamagedWeight, dDiscardingWeight,
                                                                                dDiscardingQty, dSalvageValue, sRemarks,
                                                                                0, 0);
                                                                        DINdetail.Insert();

                                                                        #region Pass Value to Inventory Detail
                                                                        //tbl_scsInventoryTxnDetail oInventoryDetail_From = new tbl_scsInventoryTxnDetail(iFormID, iCount,0,  txtDINID.Text.Trim(), dtpDGNDate.Value,
                                                                        //                            "", "", "", "", "default", "default", txtStoreID.Tag.ToString(),
                                                                        //                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), 0, dDiscardingQty, 0, 0, false);
                                                                        //oListInventory.Add(oInventoryDetail_From);
                                                                        #endregion

                                                                        iCount++;
                                                                    }

                                                                    #endregion

                                                                    //Update DIN Header

                                                                    #region Update DIN Header

                                                                    tbl_scsDiscardedGoodNote DGN =
                                                                        new tbl_scsDiscardedGoodNote(
                                                                            txtDINID.Text.Trim(), dtpDGNDate.Value,
                                                                            txtRemark.Text.Trim(),
                                                                            txtStoreID.Tag.ToString(), 0, 0, 0, 0, 0, 0,
                                                                            0, 0, 0,
                                                                            decimal.Parse(txtGrandTotal.Text.Trim()),
                                                                            oldRecord.CreateUser_ID,
                                                                            clsSecurity.UserIDLoged,
                                                                            oldRecord.CheckedUser_ID,
                                                                            oldRecord.ApprovedUser_ID,
                                                                            oldRecord.DateCreate,
                                                                            clsSecurity.getServerDateTime(),
                                                                            glbCheckedDate, glbApprovedDate,
                                                                            bHasChecked, bHasApproved,
                                                                            oldRecord.IsFinished, oldRecord.IsDeleted,
                                                                            oldRecord.IsLocked, oldRecord.SeattleAmount,
                                                                            oldRecord.IsSeattled, oldRecord.PrintCount,
                                                                            !chkUnitPricing.Checked,
                                                                            oldRecord.CompanyID,
                                                                            oldRecord.CompanyBranch_ID);

                                                                    DGN.Update();

                                                                    #endregion

                                                                    #region Update Store Stock

                                                                    foreach (
                                                                        tbl_scsDiscardedGoodNote_Detail oUpdatedRecord
                                                                        in tbl_scsDiscardedGoodNote_Detail
                                                                            .SelectAllByDiscardedGoodNote_ID(
                                                                                txtDINID.Text.Trim()))
                                                                    {
                                                                        //  decimal dCostFifo = clsHelpMethods_Local.GetFifoCost(oUpdatedRecord.Item_ID , 0);

                                                                        decimal dWeightedAverageCostPrice = 0;
                                                                        decimal dCostFifo =
                                                                            //clsHelpMethods_Local.UpdateStoreStock(
                                                                            //    iFormID, DGN.DiscardedGoodNote_ID,
                                                                            //    DGN.DiscardedGoodNoteDate,
                                                                            //    oUpdatedRecord.Item_ID, "0",
                                                                            //    txtStoreID.Tag.ToString(),
                                                                            //    oUpdatedRecord.DiscardingQty,
                                                                            //    oUpdatedRecord.DiscardingWeight,
                                                                            //    oUpdatedRecord.SalvageValue, false,
                                                                            //    false, true, ref dWeightedAverageCostPrice);
                                                                        //  clsHelpMethods_Local.UpdateFifo_Stock(iFormID, DGN.DiscardedGoodNote_ID, DGN.DiscardedGoodNoteDate, DGN.Store_ID, oUpdatedRecord.Item_ID, oUpdatedRecord.ItemSerialNo, oUpdatedRecord.DiscardingQty, 0, false, dCostFifo);

                                                                  //      oUpdatedRecord.Cost_FIFO = dCostFifo;
                                                                        oUpdatedRecord.WeightedAvgCost = dWeightedAverageCostPrice;
                                                                        oUpdatedRecord.Update();
                                                                    }

                                                                    #endregion

                                                                    //Attachments.Insert(iFormID, oldRecord.DiscardedGoodNote_ID);
                                                                    //Attachments.Remove(iFormID, oldRecord.DiscardedGoodNote_ID);

                                                                    #region Update Inventory
                                                                    //tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtDINID.Text.Trim(), dtpDGNDate.Value, txtRemark.Text.Trim(),
                                                                    //    "default", "default", "default", -1, 0,
                                                                    //    "", "", "", "", false, clsSecurity.UserIDLoged);

                                                                    //clsHelpMethods.Update_Inventory(oHeader, oListInventory);


                                                                    var responce = oData.Update_InventoryTxn(iFormID, txtDINID.Text.Trim());
                                                                    if (!responce.IsSuccess)
                                                                    {
                                                                        clsValidate.WriteErrorLog(txtDINID.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
                                                                    }
                                                                    #endregion

                                                                    MessageBox.Show(
                                                                        clsFormatter.GetMessageFrom(MessageType
                                                                            .ModifyDone),
                                                                        clsFormatter.GetMessageCaption(),
                                                                        MessageBoxButtons.OK,
                                                                        MessageBoxIcon.Information);
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

                                                #region Insert DIN
                                                else
                                                {
                                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                                        txtDINID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                                    if (clsValidate.CheckValidity_TransactionCodeLength(txtDINID.Text))// if (txtDINID.Text.Trim().Length > 0)
                                                    {
                                                    //    List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();
                                                        
                                                        #region Insert Header
                                                        tbl_scsDiscardedGoodNote DIN = new tbl_scsDiscardedGoodNote(txtDINID.Text.Trim(), dtpDGNDate.Value, txtRemark.Text.Trim(),
                                                            txtStoreID.Tag.ToString(), 0, 0, 0, 0, 0, 0, 0, 0, 0, decimal.Parse(txtGrandTotal.Text.Trim()), clsSecurity.UserIDLoged,
                                                            clsSecurity.UserIDLoged, "default", "default", clsSecurity.getServerDateTime(),
                                                            clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, bHasChecked, bHasApproved, false, false, false, 0, false, 0, !chkUnitPricing.Checked, clsSecurity.CompanyID, clsSecurity.BranchID);

                                                        DIN.Insert();
                                                        #endregion

                                                        #region Insert Detail
                                                        int iCount = 1;
                                                        foreach (DataGridViewRow row in dgvDetail.Rows)
                                                        {
                                                            string sJobCode = "default", sItemCode = "", sItemSubCategoryID1 = "", sItemSubCategoryID2 = "", sItemSerialNo1 = "", sItemSerialNo2 = "", sRemarks = "";
                                                            decimal dDamagedQty = 0, dDiscardingQty = 0, dDamagedWeight = 0, dSalvageValue = 0, dDiscardingWeight = 0;

                                                            //*******************************           VERY IMPORTANT      ***************************************
                                                            //In this grid we didn't change the column names as we use common grid for all stock notes
                                                            //so we have some global method manipulate according to this column names 
                                                            //              SO DON'T CONFUSE WITH THE GRID COLUMN NAMES CONSIDER ONLY THE VERIABLE NAMES
                                                            sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                                            sItemSubCategoryID1 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                                                            sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                                            sItemSerialNo1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                                                            sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                                            dDamagedQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                                            dDiscardingQty = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                                                            dDiscardingWeight = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                                                            dDamagedWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                                            dSalvageValue = clsValidate.ValidateGridValue(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                                                            sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");

                                                            // decimal dCostFifo = clsHelpMethods_Local.GetFifoCost(sItemCode , dDamagedQty);

                                                            tbl_scsDiscardedGoodNote_Detail DINdetail = new tbl_scsDiscardedGoodNote_Detail(clsHelpMethods_Local.GetMaxzimumLineNoDiscardedGoodNote(txtDINID.Text.Trim()), txtDINID.Text.Trim(), sItemCode, sItemSubCategoryID1,
                                                                sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, dDamagedQty, dDamagedWeight, dDiscardingWeight, dDiscardingQty, dSalvageValue, sRemarks, 0, 0);
                                                            DINdetail.Insert();

                                                            #region Update Store Stock
                                                            //     clsHelpMethods_Local.UpdateStoreStock(sItemCode, txtStoreID.Tag.ToString(), dDiscardingQty, dDiscardingWeight, false, false);
                                                            //  clsHelpMethods_Local.UpdateFifo_Stock(iFormID, DIN.DiscardedGoodNote_ID, DIN.DiscardedGoodNoteDate, DIN.Store_ID, DINdetail.Item_ID, DINdetail.ItemSerialNo, DINdetail.DiscardingQty, 0, false, dCostFifo);

                                                            decimal dWeightedAverageCostPrice = 0;
                                                         //   decimal dCostFifo = clsHelpMethods_Local.UpdateStoreStock(iFormID, DIN.DiscardedGoodNote_ID, DIN.DiscardedGoodNoteDate, DINdetail.Item_ID, "0", txtStoreID.Tag.ToString(), DINdetail.DiscardingQty, DINdetail.DiscardingWeight, DINdetail.SalvageValue, false, false, true, ref dWeightedAverageCostPrice);
                                                          //  DINdetail.Cost_FIFO = dCostFifo;
                                                            DINdetail.WeightedAvgCost = dWeightedAverageCostPrice;
                                                            DINdetail.Update();
                                                            #endregion

                                                            #region Pass Value to Inventory Detail
                                                            //tbl_scsInventoryTxnDetail oInventoryDetail_From = new tbl_scsInventoryTxnDetail(iFormID, iCount,0,  txtDINID.Text.Trim(), dtpDGNDate.Value,
                                                            //                            "", "", "", "", "default", "default", txtStoreID.Tag.ToString(),
                                                            //                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), 0, dDiscardingQty, 0, 0, false);
                                                            //oListInventory.Add(oInventoryDetail_From);
                                                            #endregion

                                                            iCount++;
                                                        }
                                                        #endregion

                                                        Attachments.Insert(txtDINID.Text);

                                                        #region Update Inventory
                                                        //tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtDINID.Text.Trim(), dtpDGNDate.Value, txtRemark.Text.Trim(),
                                                        //    "default", "default", "default", -1, 0,
                                                        //    "", "", "", "", false, clsSecurity.UserIDLoged);

                                                        //clsHelpMethods.Update_Inventory(oHeader, oListInventory);

                                                        var responce = oData.Update_InventoryTxn(iFormID, txtDINID.Text.Trim());
                                                        if (!responce.IsSuccess)
                                                        {
                                                            clsValidate.WriteErrorLog(txtDINID.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
                                                        }
                                                        #endregion

                                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                                    //else
                                                    // MessageBox.Show("DIN " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                                tbl_scsDiscardedGoodNote oldRecord = tbl_scsDiscardedGoodNote.Select(txtDINID.Text.Trim());
                                                ClearFields();
                                                if (oldRecord != null)
                                                    FillDetails(oldRecord.DiscardedGoodNote_ID);
                                            }
                                        }
                                    }//check user permission
                                }
                            }//check stock validity
                        }//Discarding Amount Validity
                    }//Cheque Grid Count Validity
                }//check number validity
            }//check validity
        }
        #endregion

        #region Btn Print
        private void frm_scsDiscardedGoodNote_SF_printButton_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_scsDiscardedGoodNote_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region Btn Temp
        private void frm_scsDiscardedGoodNote_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtDINID.TextLength > 0 && txtDINID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDINID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblStore, true);

                txtDINID.Tag = null;
                dtpDGNDate.Value = clsSecurity.getServerDateTime();

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Primary Key
                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtDINID.Text = "<Auto Generate>";
                else
                    txtDINID.Clear();
                if (txtDINID.Enabled)
                {
                    txtDINID.SelectAll();
                    txtDINID.Focus();
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
            clsHelpMethods_Local.FormatGrid_Stock_External(dgvDetail);

            if (clsConfig.bWrap_ItemGrid_ItemName)
            {
                this.dgvDetail.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            dgvDetail.Columns["ItemSubCategoryID1"].HeaderText = clsConfig.sItemSubCategory;
        }

        private void CusDataGirdViewFormatForCalucation(DataGridView dgv, bool bWeightCalculation)
        {
            if (bWeightCalculation)
            {
                dgv.Columns["Weight"].Visible = true;
                dgv.Columns["WeightPrice"].Visible = true;
                dgv.Columns["Quantity"].Visible = false;
                dgv.Columns["UnitPrice"].Visible = false;

            }
            else if (!bWeightCalculation)
            {
                dgv.Columns["Weight"].Visible = false;
                dgv.Columns["WeightPrice"].Visible = false;
                dgv.Columns["Quantity"].Visible = true;
                dgv.Columns["UnitPrice"].Visible = true;
            }
            dgv.Rows.Clear();
            if (txtStoreID.Tag != null)
                RefreshGridByStoreID(txtStoreID.Tag.ToString());
        }

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enable the id
            IsUpdate = false;
            lblCancelled.Visible = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDINID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblStore, true);

            if (clsConfig.bShow_GridViewColumn_Remarks)
                dgvDetail.Columns["Remarks"].Visible = true;
            else
                dgvDetail.Columns["Remarks"].Visible = false;

            //txtSupplierID.Tag = null;

            txtDINID.Tag = null;
            txtStoreID.Tag = null;

            chkUnitPricing.Checked = true;
            chkShowSettle.Checked = false;
            chkPrintOriginal.Checked = false;

            txtStoreID.Clear();
            txtRemark.Clear();

            dtpDGNDate.Value = clsSecurity.getServerDateTime();
            txtGrandTotal.Text = "0";

            bHasApproved = false;
            bHasChecked = false;
            dgvDetail.Rows.Clear();
            userDetailsColorChanges();

            dgvDetail.Columns["ItemCode"].Width = 95;
            dgvDetail.Columns["ItemName"].Width = 245;

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtDINID.Text = "<Auto Generate>";
            else
                txtDINID.Clear();
            if (txtDINID.Enabled)
            {
                txtDINID.SelectAll();
                txtDINID.Focus();
            }

            Attachments.Clear();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string sDgnID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();

                dgvDetail.Columns["ItemCode"].Width = 95;
                dgvDetail.Columns["ItemName"].Width = 245;
                List<tbl_scsDiscardedGoodNote_Detail> details = tbl_scsDiscardedGoodNote_Detail.SelectAllByDiscardedGoodNote_ID(sDgnID);
                foreach (tbl_scsDiscardedGoodNote_Detail detail in details)
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (detail != null)
                    {
                        decimal dExRate = 0;
                        dExRate = clsCommon.getCurrencyRate(clsConfig.sLocalCurrencyCode);
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        Fill_Datagrid(iRow, detail.Item_ID, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, "default",
                            "default", "", item.IsTIEPItem, detail.DamagedQty, detail.DiscardingQty, detail.DiscardingWeight, detail.DamagedWeight, detail.SalvageValue, 0, detail.Remark, dExRate, "o");
                    }
                }
                if (dgvDetail.Rows.Count > 13)
                {
                    dgvDetail.Columns["ItemCode"].Width -= 6;
                    dgvDetail.Columns["ItemName"].Width -= 10;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridByStoreID(string sStoreID)
        {
            try
            {
                int iRow;

                dgvDetail.Columns["ItemCode"].Width = 95;
                dgvDetail.Columns["ItemName"].Width = 245;
                List<tbl_genStore_Stock> details = tbl_genStore_Stock.SelectAllByStore_ID(sStoreID);
                foreach (tbl_genStore_Stock detail in details)
                {
                    if (chkUnitPricing.Checked)
                    {
                        if (detail.Qty > 0)
                        {
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            Fill_Datagrid(iRow, detail.Item_ID, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, "default", "default", "", false, detail.Qty, 0, 0, detail.Weight, 0, 0, "", 1, "n");
                        }
                    }
                    else
                    {
                        if (detail.Weight > 0)
                        {
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            Fill_Datagrid(iRow, detail.Item_ID, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, "default", "default", "", false, detail.Qty, 0, 0, detail.Weight, 0, 0, "", 1, "n");
                        }
                    }
                }
                CalcualteGrandTotal();
                if (dgvDetail.Rows.Count > 13)
                {
                    dgvDetail.Columns["ItemCode"].Width -= 6;
                    dgvDetail.Columns["ItemName"].Width -= 10;
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_scsDiscardedGoodNote detail = tbl_scsDiscardedGoodNote.Select(sID);
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

                            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDINID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblStore, false);


                        //assign values
                        txtStoreID.Tag = detail.Store_ID;
                        txtStoreID.Text = clsGenaralName.getName_Store(detail.Store_ID);

                        txtDINID.Text = detail.DiscardedGoodNote_ID;
                        dtpDGNDate.Value = detail.DiscardedGoodNoteDate;
                        chkUnitPricing.Checked = !detail.IsWeightCalculation;
                        txtRemark.Text = detail.Remark;

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
                        RefreshGrid(detail.DiscardedGoodNote_ID);
                        txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);

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

        #region Check Validity
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtStoreID, "Store Name"))
            {
                bStatus = true;
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

        private bool CheckStockValidity()
        {

            bool bStatus = true;

            try
            {
                string strMessage = "", sOriginalItemCode = "", sItemCode = "", sItemStatus = "", sSubCategoryID1 = "", sSubCategoryID2 = "", sSerialNo1 = "", sSerialNo2 = "", sJobCode = "default";
                decimal dDiscardingWeight = 0;
                decimal dDiscardingQty = 0;
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    //*******************************           VERY IMPORTANT      ***************************************
                    //In this grid we didn't change the column names as we use common grid for all stock notes
                    //so we have some global method manipulate according to this column names 
                    //              SO DON'T CONFUSE WITH THE GRID COLUMN NAMES CONSIDER ONLY THE VERIABLE NAMES                                                
                    sOriginalItemCode = sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                    dDiscardingWeight = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                    dDiscardingQty = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                    sSubCategoryID1 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                    sSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                    sSerialNo1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                    sSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                    sItemStatus = clsValidate.ValidateGridValue(dgvDetail, "ItemStatus", row.Index, "");

                    if (!clsConfig.bStoreStockWithJobID)
                        sJobCode = "default";

                    //validate stock detail
                    #region Validate Stock Details
                    tbl_genStore_Stock stock = tbl_genStore_Stock.Select(txtStoreID.Tag.ToString(), sItemCode, sJobCode, sSubCategoryID1, sSubCategoryID2, sSerialNo1, sSerialNo2);
                    if (stock != null)
                    {
                        if (sItemStatus.ToLower() == "o") //new item
                        {
                            #region Old Items Stock Validation
                            List<tbl_scsDiscardedGoodNote_Detail> oldDetails = tbl_scsDiscardedGoodNote_Detail.SelectAllByDiscardedGoodNote_ID(txtDINID.Text.Trim());
                            foreach (tbl_scsDiscardedGoodNote_Detail oldDetail in oldDetails)
                            {
                                if (oldDetail.Item_ID == sOriginalItemCode && oldDetail.ItemSubCategory_ID == sSubCategoryID1 && oldDetail.ItemSubCategory2_ID == sSubCategoryID2 && oldDetail.ItemSerialNo == sSerialNo1 && oldDetail.ItemSerialNo2 == sSerialNo2)
                                {
                                    decimal dVeriance = 0;
                                    if (clsConfig.bStockValidateQty_DIN) //check whether stock enabled - qty
                                    {
                                        #region Old Items Quantity Validation
                                        if (oldDetail.DiscardingQty < dDiscardingQty)
                                            dVeriance = dDiscardingQty - oldDetail.DiscardingQty;

                                        if (stock.Qty < dVeriance)
                                        {
                                            strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\" in store : " + clsGenaralName.getName_Item(sItemCode) + " Required Quantity Is Not Available As IT Is In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                                            bStatus = false;
                                        }
                                        #endregion
                                    }
                                    if (clsConfig.bStockValidateWeight_DIN) //check whether stock enabled - qty
                                    {
                                        #region Old Items Weight Validation
                                        dVeriance = 0;
                                        if (oldDetail.DiscardingWeight < dDiscardingWeight)
                                            dVeriance = dDiscardingWeight - oldDetail.DiscardingWeight;

                                        if (stock.Weight < dVeriance)
                                        {
                                            strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\" in store : " + clsGenaralName.getName_Item(sItemCode) + " Required Weight Is Not Available As IT Is In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                                            bStatus = false;
                                        }
                                        #endregion
                                    }
                                }
                            }
                            #endregion
                        }
                        else //old item
                        {
                            #region New Item Stock Validation
                            if (stock.Weight < dDiscardingWeight && clsConfig.bStockValidateWeight_DIN)
                            {
                                strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\" in store : " + clsGenaralName.getName_Item(sItemCode) + " Required Weight Is Not Available As IT Is In  " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                                bStatus = false;
                            }
                            if (stock.Qty < dDiscardingQty && clsConfig.bStockValidateQty_DIN)
                            {
                                strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\" in store : " + clsGenaralName.getName_Item(sItemCode) + "  Required Quantity Is Not Available As IT Is In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                                bStatus = false;
                            }
                            #endregion
                        }
                    }
                    else //No stock in selected store
                    {
                        strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\" in store : " + clsGenaralName.getName_Item(sItemCode) + " Is Not Available In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + " Stock\n";
                        bStatus = false;
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

        private bool ValidateDiscardingQty()
        {
            bool rtn = true;
            try
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    decimal dDiscardingWeight = 0;
                    decimal dDiscardingQty = 0;

                    dDiscardingWeight = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                    dDiscardingQty = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                    if (chkUnitPricing.Checked)
                    {
                        if (dDiscardingQty <= 0)
                        {
                            MessageBox.Show("Discarding Quantity Can not be Zero or Empty!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            rtn = false;
                            break;
                        }
                    }
                    else
                    {
                        if (dDiscardingWeight <= 0)
                        {
                            MessageBox.Show("Discarding Weight Can not be Zero or Empty!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Events KeyDown
        private void txtDINID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_DiscardedGoodsNoteID();
        }
        private void txtStoreID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Store();
        }
        private void txtCheckedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CheckedBy();
            }
        }
        private void txtApprovedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_ApprovedBy();
            }
        }
        private void frm_sasCustomerInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Events Double Click
        private void txtStoreID_DoubleClick(object sender, EventArgs e)
        {
            Search_Store();
        }
        private void txtCheckedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void txtApprovedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }
        private void txtDINID_DoubleClick(object sender, EventArgs e)
        {
            Search_DiscardedGoodsNoteID();
        }
        #endregion

        #region Events CheckedChanged
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
            //clsEvent.StockGrid_External_CellEndEdit(sender, e, dgvDetail, !chkUnitPricing.Checked);
            CalcualteGrandTotal();
        }

        private void dgvDetail_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            clsEvent.SalesGrid_CellParsing(sender, e, dgvDetail);
        }
        #endregion

        #region Search Methods
        private void Search_DiscardedGoodsNoteID()
        {
            try
            {
                clsSearch.Search_TransactionDiscardedDoodNote_Direct(ref txtDINID, chkShowSettle.Checked);
                if (txtDINID.Tag != null && txtDINID.Tag.ToString().Trim().Length > 0)
                    FillDetails(txtDINID.Tag.ToString());

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_Store()
        {
            try
            {
                dgvDetail.Rows.Clear();
                clsSearch.Search_MasterStore_DamagedStore(ref txtStoreID, clsConfig.enableBranchWiseFilterOnSearch ? true : false);
                if (txtStoreID.Tag != null)
                    RefreshGridByStoreID(txtStoreID.Tag.ToString());

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Calcualte Values
        private void CalcualteGrandTotal()
        {
            try
            {
                decimal Amount = 0;
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                {
                    if (dgvDetail["Amount", x].Value != null && dgvDetail["Amount", x].Value.ToString().Length > 0)
                    {
                        if (clsCommon.isCurrency(dgvDetail["Amount", x].Value.ToString()))
                            Amount += decimal.Parse(dgvDetail["Amount", x].Value.ToString());
                    }
                }
                txtGrandTotal.Text = Amount.ToString();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private decimal GetTotalPrice(decimal dPrice, decimal dQuantity)
        {
            decimal dTotalPrice = 0;
            dTotalPrice = dPrice * dQuantity;
            return dTotalPrice;
        }
        #endregion

        #region Fill Datagrid
        private void Fill_Datagrid(int iRow, string ItemID, string ItemSubCategoryID1, string ItemSubCategoryID2, string ItemSerialNo1, string ItemSerialNo2, string PurchaseOrderID, string sPRNID, string sBatch, bool bIsTiep, decimal DamagedQty, decimal DiscardingQty, decimal DiscardingWeight, decimal DamagedWeight,
        decimal SalvageValue, decimal dWarranty, string Remark, decimal dExRate, string sItemStatus)
        {
            try
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    string sItemID = "", sItemSub = "", sItemSub2 = "", sSerial = "", sSerial2 = "";
                    sItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                    sItemSub = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                    sItemSub2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                    sSerial = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                    sSerial2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");

                    if (ItemID == sItemID && ItemSubCategoryID1 == sItemSub && ItemSubCategoryID2 == sItemSub2 && ItemSerialNo1 == sSerial && ItemSerialNo2 == sSerial2)
                    {
                        dgvDetail.Rows.RemoveAt(iRow);
                        DiscardingWeight += clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                        DiscardingQty += clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                        iRow = row.Index;
                    }
                }

                dgvDetail["ItemCode", iRow].Value = ItemID;
                dgvDetail["ItemName", iRow].Value = clsGenaralName.getName_Item(ItemID);
                //
                dgvDetail["ItemSubCategoryID1", iRow].Tag = ItemSubCategoryID1;
                dgvDetail["ItemSubCategoryID1", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(ItemSubCategoryID1));
                dgvDetail["ItemSubCategoryID2", iRow].Tag = ItemSubCategoryID2;
                dgvDetail["ItemSubCategoryID2", iRow].Value = ItemSubCategoryID2;
                //
                dgvDetail["ItemSerialNo1", iRow].Value = ItemSerialNo1;
                dgvDetail["ItemSerialNo2", iRow].Value = ItemSerialNo2;
                dgvDetail["POID", iRow].Value = PurchaseOrderID;//add by thilina
                dgvDetail["PRNID", iRow].Value = sPRNID;
                dgvDetail["Batch", iRow].Value = sBatch;
                dgvDetail["IsTiep", iRow].Value = bIsTiep;
                dgvDetail["Warranty", iRow].Value = clsFormatter.FormatToNumberWithOneDecimalPlaces(dWarranty);
                dgvDetail["UOM", iRow].Value = clsGenaralName.getName_ItemUOM(ItemID);
                dgvDetail["Remarks", iRow].Value = Remark;
                dgvDetail["ItemStatus", iRow].Value = sItemStatus;

                if (clsCommon.IsCustomerizedGrid())
                {
                    dgvDetail["Quantity", iRow].Value = clsFormatter.FormatToNumberWithOneDecimalPlaces(DamagedQty);
                    dgvDetail["Weight", iRow].Value = clsFormatter.FormatToNumberWithOneDecimalPlaces(DamagedWeight);
                    dgvDetail["Amount", iRow].Value = clsFormatter.FormatToNumberWithTwoDecimalPlaces(SalvageValue);
                    dgvDetail["Amount", iRow].Tag = SalvageValue;

                    dgvDetail["UnitPrice", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(DiscardingQty);
                    dgvDetail["UnitPrice", iRow].Tag = DiscardingQty;
                    dgvDetail["WeightPrice", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(DiscardingWeight);
                    dgvDetail["WeightPrice", iRow].Tag = DiscardingWeight;
                }
                else
                {
                    dgvDetail["Quantity", iRow].Value = DamagedQty.ToString();
                    dgvDetail["UnitPrice", iRow].Value = DiscardingQty.ToString();
                    dgvDetail["UnitPrice", iRow].Tag = DiscardingQty;
                    dgvDetail["Weight", iRow].Value = DamagedWeight.ToString();
                    dgvDetail["WeightPrice", iRow].Value = DiscardingWeight.ToString();
                    dgvDetail["WeightPrice", iRow].Tag = DiscardingWeight;
                    dgvDetail["Amount", iRow].Value = SalvageValue.ToString();
                    dgvDetail["Amount", iRow].Tag = SalvageValue;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Print Method
        private void Print(bool bIsDraft)
        {
            try
            {
                if (txtDINID.TextLength > 0 && txtDINID.Text != "<Auto Generate>")
                {
                    //update receipt
                    Cursor = Cursors.WaitCursor;
                    
                    string sCreateUser = "", sCheckedUser = "", sApprovedUser = "", sDuplicateCopy = "";
                    bool bOkToPrint = false, bApprovalDone = true, bCheckingDone = true;
                    #endregion

                    bool bPermissinOkToPrint = true;
                    if (chkPrintOriginal.Checked)
                        bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_DiscardedItemNote));
                    if (bPermissinOkToPrint)
                    {
                        tbl_scsDiscardedGoodNote oDisGN = tbl_scsDiscardedGoodNote.Select(txtDINID.Text.Trim());
                        if (oDisGN != null)
                        {
                            if (!bIsDraft)
                            {
                                #region Validate Checking \ Approval
                                //if (clsConfig.bApprovalNeedToPrint)
                                //{
                                //    if (!order.IsApproved)
                                //    {
                                //        bApprovalDone = false;
                                //        MessageBox.Show("Please Approve the PO Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //    }
                                //}

                                //if (clsConfig.bCheckingNeedToPrintPO)
                                //{
                                //    if (!order.IsChecked)
                                //    {
                                //        bCheckingDone = false;
                                //        MessageBox.Show("Please Check the PO Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //    }
                                //}
                                #endregion
                            }

                            #region Validate Original Print and Duplicate Print
                            if (!bIsDraft)
                            {
                                bOkToPrint = true;

                                //if (oDisGN.PrintCount > 0)
                                //    sDuplicateCopy = "Duplicate Copy " + (oDisGN.PrintCount--);

                                if (!chkPrintOriginal.Checked)
                                    sDuplicateCopy = (oDisGN.PrintCount > 0) ? "Duplicate Copy " + (oDisGN.PrintCount--) : "";

                                oDisGN.PrintCount++;
                                oDisGN.Update();
                            }

                            if (oDisGN.IsDeleted)
                            {
                                bOkToPrint = true;
                                sDuplicateCopy = "";
                            }
                            #endregion

                            clsLog.Process_Print(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.DisGoodNote), oDisGN.DiscardedGoodNote_ID);

                            #region Checked users
                            sCreateUser = "[ " + clsGenaralName.getName_User(oDisGN.CreateUser_ID) + " ] [ " + oDisGN.DateCreate.ToShortDateString() + " ]";
                            if (oDisGN.IsChecked && oDisGN.CheckedUser_ID != "default")
                                sCheckedUser = "[ " + clsGenaralName.getName_User(oDisGN.CheckedUser_ID) + " ] [ " + oDisGN.DateChecked.ToShortDateString() + " ]";
                            if (oDisGN.IsApproved && oDisGN.ApprovedUser_ID != "default")
                                sApprovedUser = "[ " + clsGenaralName.getName_User(oDisGN.ApprovedUser_ID) + " ] [ " + oDisGN.DateApproved.ToShortDateString() + " ]";

                            #endregion

                            if (bApprovalDone && bCheckingDone)
                            {
                                #region DataSet
                                glb_dts_scsDiscardedItemNote.Clear();

                                #region DIN Header

                                glb_dts_scsDiscardedItemNote.dt_DIN.Adddt_DINRow(oDisGN.DiscardedGoodNote_ID, oDisGN.DiscardedGoodNoteDate, oDisGN.Store_ID, clsGenaralName.getName_Store(oDisGN.Store_ID), oDisGN.GrandTotal, oDisGN.Remark, oDisGN.IsDeleted);

                                #endregion

                                #region Purchase Order Detail
                                List<tbl_scsDiscardedGoodNote_Detail> oDisGNDetails = tbl_scsDiscardedGoodNote_Detail.SelectAllByDiscardedGoodNote_ID(oDisGN.DiscardedGoodNote_ID);
                                foreach (tbl_scsDiscardedGoodNote_Detail Details in oDisGNDetails.OrderBy(p => p.Line_No))
                                {
                                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(Details.Item_ID);
                                    tbl_zUom oUOM = tbl_zUom.Select(oItem.Uom_ID);
                                    if (oItem != null && oUOM != null)
                                    {
                                        glb_dts_scsDiscardedItemNote.dt_DIN_Details.Adddt_DIN_DetailsRow(Details.DiscardedGoodNote_ID, Details.Item_ID, oItem.ItemName, Details.ItemSubCategory_ID, clsGenaralName.getName_ItemSubCategory(Details.ItemSubCategory_ID), Details.ItemSubCategory2_ID, Details.ItemSerialNo, Details.ItemSerialNo2, oUOM.UomCode, Details.DiscardingQty, Details.DamagedQty, Details.DiscardingWeight, Details.SalvageValue, Details.Remark, 0, 0);
                                    }
                                }
                                #endregion

                                #region Report Export Parameters
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", clsCommon.getCompanyEmail(), true);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicateCopy, true);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true);
                                //glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDel", isDel, true);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUser, true);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sCheckedUser, true);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUser, true);
                                #endregion

                                #region Company Details Fill
                                string sCompanyName = clsSecurity.CompanyName, sCompanyAddress1 = clsSecurity.CompanyAddress1, sCompanyAddress2 = clsSecurity.CompanyAddress2;
                                byte[] bCompanyImage = clsCommon.getCompanyImage();
                                string sCompanyVAT = clsCommon.getCompanyVAT(), sCompanySVAT = clsCommon.getCompanySVAT(), sCompanyBRNo = clsCommon.getCompanyBusinessRegisterNo();
                                if (bIsDraft)
                                {
                                    if (!clsConfig.isVisibleCompanyInfoInDraftPrint)
                                    {
                                        sCompanyName = "";
                                        sCompanyAddress1 = "";
                                        sCompanyAddress2 = "";
                                        bCompanyImage = null;

                                        sCompanyVAT = "";
                                        sCompanySVAT = "";
                                        sCompanyBRNo = "";

                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", "", true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", "", true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", "", true);

                                    }
                                }
                                glb_dts_scsDiscardedItemNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, "Discarded Item Note", "", "", "", "", "", "");
                                #endregion

                                #region Set Report Path and Datasets
                                frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                string sGetRptPath = clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_DiscardedItemNote));
                                rpt.print(sGetRptPath, glb_dts_scsDiscardedItemNote, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_DiscardedItemNote));
                                #endregion
                                #endregion
                            }
                        }
                    }

                    #region Views
                    //string sDuplicate = "";
                    //string sCreateUser = "", sCheckedUser = "", sApprovedUser = "";
                    //tbl_scsExternalGoodReceivedNote order = tbl_scsExternalGoodReceivedNote.Select(txtDINID.Text.Trim());
                    //if (order != null)
                    //{
                    //    if (!bIsDraft)
                    //    {
                    //        sDuplicate = order.PrintCount > 0 ? "Duplicate Copy " + order.PrintCount : "";
                    //        order.PrintCount++;
                    //        order.Update();
                    //    }

                    //    if (order.IsDeleted)
                    //        sDuplicate = "";

                    //    order.IsLocked = true;
                    //    sCreateUser = "[ " + clsGenaralName.getName_User(order.CreateUser_ID) + " ] [ " + order.DateCreate.ToShortDateString() + " ]";
                    //    if (order.CheckedUser_ID != "default")
                    //        sCheckedUser = "[ " + clsGenaralName.getName_User(order.CheckedUser_ID) + " ] [ " + order.DateChecked.ToShortDateString() + " ]";
                    //    if (order.ApprovedUser_ID != "default")
                    //        sApprovedUser = "[ " + clsGenaralName.getName_User(order.ApprovedUser_ID) + " ] [ " + order.DateApproved.ToShortDateString() + " ]";

                    //}

                    //tbl_scsDiscardedGoodNote oDisItem = tbl_scsDiscardedGoodNote.Select(txtDINID.Text.Trim());
                    //if (oDisItem != null && oDisItem.DiscardedGoodNote_ID != "default")
                    //{
                    //    oDisItem.PrintCount++;
                    //    oDisItem.Update();
                    //}


                    //Cursor = Cursors.WaitCursor;
                    //string s_Path = "", sReportTitle = "Discarded Item Note", sFormula = ""; string isRemark = "";
                    //if (txtDINID.TextLength > 0)
                    //    sFormula = "{vw_rpt_scsDiscardedGoodNote.discardedGoodNote_ID}= '" + txtDINID.Text.Trim() + "'";

                    //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithDimension.ToString())
                    //    isRemark = "r";
                    //else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                    //    isRemark = "r";
                    //else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithoutDimension.ToString())
                    //    isRemark = "r";
                    //else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                    //    isRemark = "s";
                    //else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithRemark.ToString())
                    //    isRemark = "r";

                    //ReportDocument RD = new ReportDocument();
                    //s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                    //string sGetRptPath = clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_DiscardedItemNote));

                    //if (sGetRptPath != null && sGetRptPath.Length > 0)
                    //    s_Path += sGetRptPath;
                    //else
                    //{

                    //    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                    //        s_Path += "\\Reports\\SCS\\NotePrinting\\rpt_sasDiscardedGoodNote.rpt";
                    //    else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                    //        s_Path += "\\Reports\\SCS\\NotePrinting\\rpt_sasDiscardedGoodNote.rpt";
                    //    else
                    //        s_Path += "\\Reports\\SCS\\NotePrinting\\rpt_sasDiscardedGoodNote.rpt";

                    //}

                    //frm_ReportViewer viewer = new frm_ReportViewer();
                    //RD.Load(s_Path);
                    //clsSecurity.LogonServer(ref RD);
                    //RD.Refresh();

                    //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())// && !chkPrintWithAmounts.Checked && !chkPrintWithBreakdown.Checked)
                    //    RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);
                    //else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())// && !chkPrintWithAmounts.Checked && !chkPrintWithBreakdown.Checked)
                    //    RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);

                    ////RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                    //RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                    ////RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToShortDateString());
                    //RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
                    //RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
                    //RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);
                    //RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    //RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                    //RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                    //RD.DataDefinition.FormulaFields["CompanyEmail"].Text = clsCommon.fncsetstring(clsCommon.getCompanyEmail());
                    //RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                    //RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                    //RD.DataDefinition.FormulaFields["DuplicateCopy"].Text = sDuplicate;
                    //RD.DataDefinition.FormulaFields["IsDraft"].Text = bIsDraft ? "DRAFT" : "";

                    //#region Company Details Fill
                    //if (bIsDraft)
                    //{
                    //    if (!clsConfig.isVisibleCompanyInfoInDraftPrint)
                    //    {
                    //        RD.DataDefinition.FormulaFields["CompanyName"].Text = "";
                    //        RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = "";
                    //        RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = "";
                    //        RD.DataDefinition.FormulaFields["CompanyEmail"].Text = "";
                    //    }
                    //}
                    //#endregion

                    //viewer.crystalReportViewer1.ReportSource = RD;
                    //viewer.crystalReportViewer1.SelectionFormula = sFormula;
                    //viewer.crystalReportViewer1.Visible = true;
                    //viewer.crystalReportViewer1.DisplayToolbar = true;
                    //viewer.crystalReportViewer1.CloseView(false);
                    //viewer.WindowState = FormWindowState.Maximized;

                    //viewer.ShowDialog();

                    //RD.Close();
                    //RD.Dispose(); 
                    #endregion
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
        }


        private void frm_scsDiscardedGoodNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            Attachments.Close();
        }

        #region User Checked Approve Details
        private void frm_scsDiscardedGoodNote_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_scsDiscardedGoodNote_SF_approveButton_Click(object sender, EventArgs e)
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
                        if (txtDINID.Text != null && txtDINID.TextLength > 0 && txtDINID.Text != "<Auto Generate>")
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

                                        tbl_scsDiscardedGoodNote objDiGN = tbl_scsDiscardedGoodNote.Select(txtDINID.Text.Trim());
                                        if (objDiGN != null)
                                        {
                                            objDiGN.IsApproved = true;
                                            objDiGN.DateApproved = clsSecurity.getServerDateTime();
                                            objDiGN.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                            objDiGN.Update();
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
                        if (txtDINID.Text != null && txtDINID.TextLength > 0 && txtDINID.Text != "<Auto Generate>")
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

                                        tbl_scsDiscardedGoodNote objDiGN = tbl_scsDiscardedGoodNote.Select(txtDINID.Text.Trim());
                                        if (objDiGN != null)
                                        {
                                            objDiGN.IsChecked = true;
                                            objDiGN.DateChecked = clsSecurity.getServerDateTime();
                                            objDiGN.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objDiGN.Update();
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

        private void frm_scsDiscardedGoodNote_SF_History_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDINID.Text != "" || txtDINID.Text != "<Auto Generate>")
                {
                    tbl_scsDiscardedGoodNote detail = tbl_scsDiscardedGoodNote.Select(txtDINID.Text.Trim());
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
        public override void SettingsClick()
        {
            xSetting.Visible = true;
            xSetting.Focus();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            xSetting.Visible = false;
        }

        private void xSetting_Leave(object sender, EventArgs e)
        {
            xSetting.Visible = false;
        }

        #endregion


    }
}
