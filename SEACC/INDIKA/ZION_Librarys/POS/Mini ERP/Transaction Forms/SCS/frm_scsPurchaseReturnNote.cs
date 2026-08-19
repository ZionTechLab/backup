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
using Digiteq.DataSets.SCS;
using Digiteq.DataSets;


namespace Digiteq
{
    public partial class frm_scsPurchaseReturnNote : SEACC_Form
    {
        #region Variables
        //to manage update and insert
        //static bool IsUpdate = false;

        //form manage
        //string sFormConfigCode;
        //public int iFormID;

        public string glbOrderRefNo = "", glbPRNNo = "", glbGoodReceivedNoteID = "";

        //for security handle
        //public bool bNoAccess;
        //public bool bHasChecked;
        //public bool bHasApproved;
        //   DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        //   DateTime glbCheckedDate = clsSecurity.getServerDateTime();
        bool isDuplicate = false, isCanceled = false;
        dts_scs_PurchaseRetNote glb_dtsScsPurchaseRetNote = new dts_scs_PurchaseRetNote();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        #endregion

        #region Form Load
        public frm_scsPurchaseReturnNote(FormName _enmForm)
        {
            //sFormConfigCode = clsAutocode.getFormConfigCode(FormName.scsPRNSupplier);
            //iFormID = clsSecurity.getFormID(FormName.scsPRNSupplier);
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
            //clsFormatter.setFormatForm(this, "Purchase Return Note - [PRN]", 4, iFormID);
            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);
            CusDataGridViewFormat();

            ClearFields();

            if (glbGoodReceivedNoteID.Length > 0)
            {
                //tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(glbGoodReceivedNoteID);
                //if (detail != null)
                //{
                txtEGRNID.Tag = glbGoodReceivedNoteID;
                txtEGRNID.Text = glbGoodReceivedNoteID;
                btnAddGRN_Click(sender, new EventArgs());
                //}
            }
            else if (glbPRNNo.Length > 0)
            {
                FillDetails(glbPRNNo);
            }

            CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);
            FillDetailsCurrency(clsConfig.sLocalCurrencyCode);
        }
        #endregion

        #region Btn New
        private void frm_scsPurchaseReturnNote_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void frm_scsPurchaseReturnNote_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPRNID.Text.Trim().Length > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpPRNDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreID.Tag.ToString(), IsUpdate))
                            {
                                Cursor = Cursors.WaitCursor;

                                #region Delete one PRN
                                tbl_scsPurchaseReturnedNote detail = tbl_scsPurchaseReturnedNote.Select(txtPRNID.Text.Trim());
                                if (detail != null)
                                {
                                    if (ValidateForDependancies(detail.PurchaseReturnedNote_ID))
                                    {
                                        if (!detail.IsLocked && !detail.IsFinished && !detail.IsDeleted)
                                        {
                                            if (CheckSupplierSaveValidity(detail.Supplier_ID))//Check Supplier Validity
                                            {
                                                // if (clsValidate.CheckPostingValidity(detail.PostingStatus_ID))
                                                {
                                                    DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " PRN : " + txtPRNID.Text), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                    if (msgResult == DialogResult.Yes)
                                                    {
                                                        if (CheckCancelValidity_WATollarance())
                                                        {
                                                            ////Update Other Tables 
                                                            #region Update Other Tables
                                                            foreach (tbl_scsPurchaseReturnedNote_Detail Olddetail in tbl_scsPurchaseReturnedNote_Detail.SelectAllByPurchaseReturnedNote_ID(txtPRNID.Text.Trim()))
                                                            {
                                                                if (Olddetail.Item_ID != null)
                                                                {
                                                                    #region Update Store Stock
                                                                    // clsHelpMethods.UpdateStoreStock(Olddetail.Item_ID, txtStoreID.Tag.ToString(), Olddetail.Qty, Olddetail.Weight, true, false);
                                                                    //   clsHelpMethods_Local.RollBackFifo_Stock(iFormID, Olddetail.PurchaseReturnedNote_ID, Olddetail.Qty);
                                                                    decimal dWeightedAverageCostPrice = 0;
                                                                    clsHelpMethods.UpdateStoreStock(iFormID, Olddetail.PurchaseReturnedNote_ID, detail.PurchaseReturnedNoteDate, Olddetail.Item_ID, "0", txtStoreID.Tag.ToString(), Olddetail.Qty, Olddetail.Weight, Olddetail.TatalAmount, true, false, true, ref dWeightedAverageCostPrice);
                                                                    Olddetail.WeightedAvgCost = dWeightedAverageCostPrice;
                                                                    Olddetail.Update();
                                                                    #endregion
                                                                }
                                                            }
                                                            #endregion

                                                            detail.DateModified = clsSecurity.getServerDateTime();
                                                            detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                            detail.IsDeleted = true;
                                                            detail.Update();

                                                            clsHelpMethods.Delete_Inventory(iFormID, 0, txtPRNID.Text.Trim());

                                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            ClearFields();
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                #endregion
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
                    {
                        dgvDetail.Rows.RemoveAt(dgvDetail.SelectedCells[0].RowIndex);
                        clsHelpMethods.Grid_LineNoChange(dgvDetail);
                        CalcualteSubTotal();
                        CalculateTaxesAndGrandTotal();
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

        #region Btn Save
        private void frm_scsPurchaseReturnNote_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    ValidateEmptyForeignKey();
                    if (glbOrderRefNo.Length <= 0)
                        glbOrderRefNo = "default";

                    #region Update PRN
                    if (IsUpdate)  //update records
                    {

                        tbl_scsPurchaseReturnedNote oldRecord = tbl_scsPurchaseReturnedNote.Select(txtPRNID.Text.Trim());
                        if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount) //&& clsValidate.CheckPostingValidity(oldRecord.PostingStatus_ID)
                            )
                        {
                            if (ValidateForDependancies(oldRecord.PurchaseReturnedNote_ID))
                            {
                                if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted //&& clsValidate.CheckPostingValidity(oldRecord.PostingStatus_ID)
                                    )
                                {
                                    if (!oldRecord.IsChecked ||
                                        (oldRecord.IsChecked &&
                                         clsSecurity.PermissionToApproved(
                                             clsSecurity.UserIDLoged, iFormID)))
                                    {
                                        if (clsValidate.CheckValidity_TransactionCodeLength(txtPRNID.Text))
                                        {
                                            List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();

                                            #region Rollback StoreStock

                                            foreach (
                                                tbl_scsPurchaseReturnedNote_Detail
                                                    oUpdatedRecord in
                                                tbl_scsPurchaseReturnedNote_Detail
                                                    .SelectAllByPurchaseReturnedNote_ID(
                                                        txtPRNID.Text.Trim()))
                                            {
                                                decimal dWeightedAverageCostPrice = 0;
                                                clsHelpMethods.UpdateStoreStock(
                                                    iFormID,
                                                    oUpdatedRecord.PurchaseReturnedNote_ID,
                                                    oldRecord.PurchaseReturnedNoteDate,
                                                    oUpdatedRecord.Item_ID, "0",
                                                    txtStoreID.Tag.ToString(),
                                                    oUpdatedRecord.Qty,
                                                    oUpdatedRecord.Weight,
                                                    oUpdatedRecord.TatalAmount, true, false,
                                                    true, ref dWeightedAverageCostPrice);
                                                oUpdatedRecord.WeightedAvgCost = dWeightedAverageCostPrice;
                                                oUpdatedRecord.Update();
                                                //     clsHelpMethods_Local.RollBackFifo_Stock(iFormID, oUpdatedRecord.PurchaseReturnedNote_ID, oUpdatedRecord.Qty);
                                            }

                                            #endregion

                                            #region Update Old PRN Items
                                            List<tbl_scsPurchaseReturnedNote_Detail> oldDetails = tbl_scsPurchaseReturnedNote_Detail.SelectAllByPurchaseReturnedNote_ID(txtPRNID.Text.Trim());
                                            foreach (tbl_scsPurchaseReturnedNote_Detail oldDetail in oldDetails)
                                            {
                                                #region Initialize Variables
                                                string sJobCode = "default",
                                                                                                                        sItemCode = "",
                                                                                                                        sItemSubCategoryID1 = "",
                                                                                                                        sItemSubCategoryID2 = "",
                                                                                                                        sItemSerialNo1 = "",
                                                                                                                        sItemSerialNo2 = "",
                                                                                                                        sGRNID = "",
                                                                                                                        sPRNID = "",
                                                                                                                        sBatch = "",
                                                                                                                        sUom = "",
                                                                                                                        sRemarks = "";
                                                decimal dQty = 0,
                                                    dUnitPrice = 0,
                                                    dWeight = 0,
                                                    dAmount = 0,
                                                    dWaranty = 0,
                                                    dWeidhtPrice = 0;
                                                bool bHasItemInDB = false;
                                                int iLineNo = 0;
                                                //*******************************           VERY IMPORTANT      ***************************************
                                                //In this grid we didn't change the column names as we use common grid for all stock notes
                                                //so we have some global method manipulate according to this column names 
                                                //              SO DON'T CONFUSE WITH THE GRID COLUMN NAMES CONSIDER ONLY THE VERIABLE NAMES
                                                #endregion


                                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                                {
                                                    #region Set Grid Values to Variable
                                                    iLineNo = clsValidate.ValidateGridValue(
                                                        dgvDetail, "LineNo", row.Index,
                                                        int.Parse("0"));
                                                    sItemCode = clsValidate
                                                        .ValidateGridValue(dgvDetail,
                                                            "ItemCode", row.Index, "");
                                                    sItemSubCategoryID1 =
                                                        clsValidate.ValidateGridTag(
                                                            dgvDetail, "ItemSubCategoryID1",
                                                            row.Index, "default");
                                                    sItemSubCategoryID2 =
                                                        clsValidate.ValidateGridTag(
                                                            dgvDetail, "ItemSubCategoryID2",
                                                            row.Index, "default");
                                                    sItemSerialNo1 =
                                                        clsValidate.ValidateGridValue(
                                                            dgvDetail, "ItemSerialNo1",
                                                            row.Index, "0");
                                                    sItemSerialNo2 =
                                                        clsValidate.ValidateGridValue(
                                                            dgvDetail, "ItemSerialNo2",
                                                            row.Index, "0");
                                                    sGRNID = clsValidate.ValidateGridValue(
                                                        dgvDetail, "POID", row.Index,
                                                        "default");
                                                    sPRNID = clsValidate.ValidateGridValue(
                                                        dgvDetail, "PRNID", row.Index,
                                                        "default");
                                                    sBatch = clsValidate.ValidateGridValue(
                                                        dgvDetail, "Batch", row.Index, "");
                                                    sUom = clsValidate.ValidateGridValue(
                                                        dgvDetail, "UOM", row.Index,
                                                        "default");
                                                    dQty = clsValidate.ValidateGridValue(
                                                        dgvDetail, "Quantity", row.Index,
                                                        decimal.Parse("0.00"));
                                                    dUnitPrice =
                                                        clsValidate.ValidateGridTag(
                                                            dgvDetail, "UnitPrice",
                                                            row.Index,
                                                            decimal.Parse("0.00"));
                                                    dWeidhtPrice =
                                                        clsValidate.ValidateGridTag(
                                                            dgvDetail, "WeightPrice",
                                                            row.Index,
                                                            decimal.Parse("0.00"));
                                                    dWeight = clsValidate.ValidateGridValue(
                                                        dgvDetail, "Weight", row.Index,
                                                        decimal.Parse("0.00"));
                                                    dAmount = clsValidate.ValidateGridTag(
                                                        dgvDetail, "Amount", row.Index,
                                                        decimal.Parse("0.00"));
                                                    dWaranty =
                                                        clsValidate.ValidateGridValue(
                                                            dgvDetail, "Warranty",
                                                            row.Index,
                                                            decimal.Parse("0.00"));
                                                    sRemarks =
                                                        clsValidate.ValidateGridValue(
                                                            dgvDetail, "Remarks", row.Index,
                                                            "");
                                                    #endregion

                                                    #region Check Existing Records
                                                    if (oldDetail.PurchaseReturnedNote_ID ==
                                                                                                                                txtPRNID.Text.Trim() &&
                                                                                                                                oldDetail.Line_No == iLineNo &&
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
                                                    #endregion
                                                }

                                                if (bHasItemInDB)
                                                {
                                                    #region Update old item detailsk

                                                    //Get Unit Price with Exchange rate to save
                                                    dUnitPrice = getSavePrice(dUnitPrice);
                                                    dWeidhtPrice =
                                                        getSavePrice(dWeidhtPrice);
                                                    dAmount = getSavePrice(dAmount);

                                                    //Update store stock when user modify the old recode
                                                    //Don't put this region below update 

                                                    #region Update Store Stock

                                                    if (clsConfig.bStockValidateQty_PRN)
                                                    {
                                                        //      if (clsHelpMethods_Local.Store_StockQuantityIncrease(txtStoreID.Tag.ToString(), sItemCode, sJobCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, oldDetail.Qty))
                                                        //         clsHelpMethods_Local.Store_StockQuantityDecrease(txtStoreID.Tag.ToString(), sItemCode, sJobCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, dQty);
                                                    }

                                                    if (clsConfig.bStockValidateWeight_PRN)
                                                    {
                                                        //    if (clsHelpMethods_Local.Store_StockWeightIncrease(txtStoreID.Tag.ToString(), sItemCode, sJobCode, oldDetail.ItemSubCategory_ID, oldDetail.ItemSubCategory2_ID, oldDetail.ItemSerialNo, oldDetail.ItemSerialNo2, oldDetail.Weight))
                                                        //        clsHelpMethods_Local.Store_StockWeightDecrease(txtStoreID.Tag.ToString(), sItemCode, sJobCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, dWeight);
                                                    }

                                                    #endregion

                                                    oldDetail.Item_ID = sItemCode;
                                                    oldDetail.ItemSubCategory_ID =
                                                        sItemSubCategoryID1;
                                                    oldDetail.ItemSubCategory2_ID =
                                                        sItemSubCategoryID2;
                                                    oldDetail.ItemSerialNo = sItemSerialNo1;
                                                    oldDetail.ItemSerialNo2 =
                                                        sItemSerialNo2;
                                                    oldDetail.ExternalGoodReceivedNote_ID =
                                                        sGRNID;
                                                    oldDetail.Qty = dQty;
                                                    oldDetail.Weight = dWeight;
                                                    oldDetail.KiloPrice = dWeidhtPrice;
                                                    oldDetail.UnitPrice = dUnitPrice;
                                                    oldDetail.TatalAmount = dAmount;
                                                    oldDetail.Remark = sRemarks;

                                                    oldDetail.Update();

                                                    #endregion

                                                    #region Pass Value to Inventory Detail
                                                    tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, iLineNo, 0, txtPRNID.Text.Trim(), dtpPRNDate.Value,
                                                                                "", "", "", "", "default", txtSupplierID.Tag.ToString(), txtStoreID.Tag.ToString(),
                                                                                sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), 0, dQty, dUnitPrice, 0, false);
                                                    oListInventory.Add(oInventoryDetail);
                                                    #endregion
                                                }
                                                else
                                                {
                                                    #region Delete old item detail

                                                    //Update Store Stock if user delete old inserted item

                                                    #region Update Store Stock If User Delete the old Input

                                                    if (clsHelpMethods
                                                        .isStore_StockAvailabel(
                                                            txtStoreID.Tag.ToString(),
                                                            oldDetail.Item_ID, sJobCode,
                                                            oldDetail.ItemSubCategory_ID,
                                                            oldDetail.ItemSubCategory2_ID,
                                                            oldDetail.ItemSerialNo,
                                                            oldDetail.ItemSerialNo2))
                                                    {
                                                        //  if (clsConfig.bStockValidateQty_PRN)
                                                        //      clsHelpMethods_Local.Store_StockQuantityIncrease(txtStoreID.Tag.ToString(), oldDetail.Item_ID, sJobCode, oldDetail.ItemSubCategory_ID, oldDetail.ItemSubCategory2_ID, oldDetail.ItemSerialNo, oldDetail.ItemSerialNo2, oldDetail.Qty);
                                                        //  if (clsConfig.bStockValidateWeight_PRN)
                                                        //       clsHelpMethods_Local.Store_StockWeightIncrease(txtStoreID.Tag.ToString(), oldDetail.Item_ID, sJobCode, oldDetail.ItemSubCategory_ID, oldDetail.ItemSubCategory2_ID, oldDetail.ItemSerialNo, oldDetail.ItemSerialNo2, oldDetail.Weight);
                                                    }
                                                    else
                                                    {
                                                        //       clsHelpMethods_Local.Store_NewStock(txtStoreID.Tag.ToString(), oldDetail.Item_ID, sJobCode, oldDetail.ItemSubCategory_ID, oldDetail.ItemSubCategory2_ID, oldDetail.ItemSerialNo, oldDetail.ItemSerialNo2, oldDetail.Weight, 0, oldDetail.Qty, 0, 0, 0, 0, 0);
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
                                                #region Initialize Variables and Set Grid Values the Pass Values to Object
                                                string sJobCode = "default",
                                                                                                                        sItemCode = "",
                                                                                                                        sItemSubCategoryID1 = "",
                                                                                                                        sItemSubCategoryID2 = "",
                                                                                                                        sItemSerialNo1 = "",
                                                                                                                        sItemSerialNo2 = "",
                                                                                                                        sGRNID = "",
                                                                                                                        sPRNID = "",
                                                                                                                        sBatch = "",
                                                                                                                        sUom = "",
                                                                                                                        sRemarks = "";
                                                decimal dQty = 0,
                                                    dUnitPrice = 0,
                                                    dWeight = 0,
                                                    dAmount = 0,
                                                    dWaranty = 0,
                                                    dWeidhtPrice = 0;
                                                int iLineNo = 0;
                                                //*******************************           VERY IMPORTANT      ***************************************
                                                //In this grid we didn't change the column names as we use common grid for all stock notes
                                                //so we have some global method manipulate according to this column names 
                                                //              SO DON'T CONFUSE WITH THE GRID COLUMN NAMES CONSIDER ONLY THE VERIABLE NAMES

                                                iLineNo = clsValidate.ValidateGridValue(
                                                    dgvDetail, "LineNo", row.Index,
                                                    int.Parse("0"));
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
                                                sGRNID = clsValidate.ValidateGridValue(
                                                    dgvDetail, "POID", row.Index,
                                                    "default");
                                                sPRNID = clsValidate.ValidateGridValue(
                                                    dgvDetail, "PRNID", row.Index,
                                                    "default");
                                                sBatch = clsValidate.ValidateGridValue(
                                                    dgvDetail, "Batch", row.Index, "");
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


                                                //Get Unit Price with Exchange rate to save
                                                dUnitPrice = getSavePrice(dUnitPrice);
                                                dWeidhtPrice = getSavePrice(dWeidhtPrice);
                                                dAmount = getSavePrice(dAmount);

                                                tbl_scsPurchaseReturnedNote_Detail PRNDetail
                                                    = new
                                                        tbl_scsPurchaseReturnedNote_Detail(
                                                            iLineNo, txtPRNID.Text.Trim(),
                                                            sItemCode,
                                                            sItemSubCategoryID1,
                                                            sItemSubCategoryID2,
                                                            sItemSerialNo1, sItemSerialNo2,
                                                            sGRNID, dQty, 0, dWeight, 0,
                                                            dWaranty, dWeidhtPrice,
                                                            dUnitPrice, 0, 0, dAmount,
                                                            sRemarks, 0, 0);
                                                PRNDetail.Insert();
                                                #endregion

                                                #region Pass Value to Inventory Detail
                                                tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, 0, iLineNo, txtPRNID.Text.Trim(), dtpPRNDate.Value,
                                                                            "", "", "", "", "default", txtSupplierID.Tag.ToString(), txtStoreID.Tag.ToString(),
                                                                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), 0, dQty, dUnitPrice, 0, false);
                                                oListInventory.Add(oInventoryDetail);
                                                #endregion
                                            }
                                            #endregion

                                            #region Update Header

                                            tbl_scsPurchaseReturnedNote PRN =
                                                new tbl_scsPurchaseReturnedNote(
                                                    txtPRNID.Text.Trim(), dtpPRNDate.Value,
                                                    txtSupplierID.Tag.ToString(),
                                                    txtEGRNID.Tag.ToString(),
                                                    txtStoreID.Tag.ToString(),
                                                    glbOrderRefNo,
                                                    txtCurrencyID.Tag.ToString(),
                                                    decimal.Parse(
                                                        txtCurrencyRate.Text.Trim()),
                                                    txtRemark.Text.Trim(),
                                                    txtDONo.Text.Trim(), "",
                                                    txtStockNoteType.Tag.ToString(),
                                                    oldRecord.GlPosting_ID,
                                                    txtCostCenter.Tag.ToString(),
                                                    oldRecord.PostingStatus_ID,
                                                    oldRecord.FinancialYear_ID,
                                                    decimal.Parse(txtPercentageDiscount.Text
                                                        .Trim()),
                                                    decimal.Parse(
                                                        txtPercentageNBT.Text.Trim()),
                                                    decimal.Parse(
                                                        txtPercentageVat.Text.Trim()),
                                                    decimal.Parse(txtPercentageOtherTax.Text
                                                        .Trim()),
                                                    getSavePrice(
                                                        decimal.Parse(txtSubTotal.Tag
                                                            .ToString().Trim())),
                                                    getSavePrice(
                                                        decimal.Parse(txtDiscount.Tag
                                                            .ToString().Trim())),
                                                    getSavePrice(
                                                        decimal.Parse(txtNBT.Tag.ToString()
                                                            .Trim())),
                                                    getSavePrice(
                                                        decimal.Parse(txtVat.Tag.ToString()
                                                            .Trim())),
                                                    getSavePrice(
                                                        decimal.Parse(txtOtherTax.Tag
                                                            .ToString().Trim())),
                                                    getSavePrice(
                                                        decimal.Parse(txtGrandTotal.Text
                                                            .Trim())),
                                                    oldRecord.CreateUser_ID,
                                                    clsSecurity.UserIDLoged, "default",
                                                    "default",
                                                    oldRecord.DateCreate,
                                                    clsSecurity.getServerDateTime(),
                                                    glbCheckedDate, glbApprovedDate,
                                                    bHasChecked, bHasApproved,
                                                    oldRecord.IsFinished,
                                                    oldRecord.IsDeleted, oldRecord.IsLocked,
                                                    oldRecord.SeattleAmount,
                                                    chkIsReturnbale.Checked,
                                                    oldRecord.IsSeattled,
                                                    oldRecord.PrintCount,
                                                    !chkUnitPricing.Checked,
                                                    clsHelpMethods.isTaxActiveNote(txtVat),
                                                    clsHelpMethods.isTaxActiveNote(
                                                        txtOtherTax), oldRecord.CompanyID,
                                                    oldRecord.CompanyBranch_ID);
                                            PRN.Update();

                                            #endregion

                                            #region Update Store Stock

                                            foreach (
                                                tbl_scsPurchaseReturnedNote_Detail
                                                    oUpdatedRecord in
                                                tbl_scsPurchaseReturnedNote_Detail
                                                    .SelectAllByPurchaseReturnedNote_ID(
                                                        txtPRNID.Text.Trim()))
                                            {
                                                //   decimal dCostFifo = clsHelpMethods.GetFifoCost(oUpdatedRecord.Item_ID , 0);
                                                decimal dWeightedAverageCostPrice = 0;
                                                decimal dCostFifo =
                                                    clsHelpMethods.UpdateStoreStock(
                                                        iFormID,
                                                        PRN.PurchaseReturnedNote_ID,
                                                        PRN.PurchaseReturnedNoteDate,
                                                        oUpdatedRecord.Item_ID, "0",
                                                        txtStoreID.Tag.ToString(),
                                                        oUpdatedRecord.Qty,
                                                        oUpdatedRecord.Weight,
                                                        oUpdatedRecord.TatalAmount, false,
                                                        false, true, ref dWeightedAverageCostPrice);
                                                //   clsHelpMethods.UpdateFifo_Stock(iFormID, PRN.PurchaseReturnedNote_ID, PRN.PurchaseReturnedNoteDate, PRN.Store_ID, oUpdatedRecord.Item_ID, oUpdatedRecord.ItemSerialNo, oUpdatedRecord.Qty, oUpdatedRecord.UnitPrice, false, dCostFifo);

                                                oUpdatedRecord.Cost_FIFO = dCostFifo;
                                                oUpdatedRecord.WeightedAvgCost = dWeightedAverageCostPrice;
                                                oUpdatedRecord.Update();
                                            }

                                            #endregion

                                            //Attachments.Insert(iFormID, oldRecord.PurchaseReturnedNote_ID);
                                            //Attachments.Remove(iFormID, oldRecord.PurchaseReturnedNote_ID);

                                            #region Update Inventory
                                            tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtPRNID.Text.Trim(), dtpPRNDate.Value, txtRemark.Text.Trim(),
                                                "default", txtSupplierID.Tag.ToString(), "default", -1, decimal.Parse(txtGrandTotal.Text.Trim()),
                                                "", "", "", "", false, clsSecurity.UserIDLoged);

                                            clsHelpMethods.Update_Inventory(oHeader, oListInventory);
                                            #endregion

                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                    }
                    #endregion

                    #region Insert PRN
                    else //insert recode
                    {
                        if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                            txtPRNID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                        //create order ref number
                        if (glbOrderRefNo.Length <= 0 || glbOrderRefNo == "default")
                        {
                            glbOrderRefNo = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.zIssuedRefNo));
                            tbl_zIssuedRefNo orf = new tbl_zIssuedRefNo(glbOrderRefNo, txtSupplierRefNo.Text != "" ? txtSupplierRefNo.Text.Trim() : "-");
                            orf.Insert();
                        }

                        if (clsValidate.CheckValidity_TransactionCodeLength(txtPRNID.Text))// if (txtPRNID.Text.Trim().Length > 0)
                        {
                            List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();

                            //insert PRN Header
                            #region Insert Header
                            tbl_scsPurchaseReturnedNote PRN = new tbl_scsPurchaseReturnedNote(txtPRNID.Text.Trim(), dtpPRNDate.Value, txtSupplierID.Tag.ToString(), txtEGRNID.Tag.ToString(), txtStoreID.Tag.ToString(),
                                glbOrderRefNo, txtCurrencyID.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text.Trim()), txtRemark.Text.Trim(), txtDONo.Text.Trim(), "",
                                txtStockNoteType.Tag.ToString(), "default", txtCostCenter.Tag.ToString(), clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, decimal.Parse(txtPercentageDiscount.Text.Trim()),
                                decimal.Parse(txtPercentageNBT.Text.Trim()), decimal.Parse(txtPercentageVat.Text.Trim()), decimal.Parse(txtPercentageOtherTax.Text.Trim()), getSavePrice(decimal.Parse(txtSubTotal.Tag.ToString().Trim())),
                                getSavePrice(decimal.Parse(txtDiscount.Tag.ToString().Trim())), getSavePrice(decimal.Parse(txtNBT.Tag.ToString().Trim())), getSavePrice(decimal.Parse(txtVat.Tag.ToString().Trim())),
                                getSavePrice(decimal.Parse(txtOtherTax.Tag.ToString().Trim())), getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim())), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default",
                                clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, bHasChecked, bHasApproved, false, false, false, 0, chkIsReturnbale.Checked, false, 0, !chkUnitPricing.Checked,
                                clsHelpMethods.isTaxActiveNote(txtVat), clsHelpMethods.isTaxActiveNote(txtOtherTax), clsSecurity.CompanyID, clsSecurity.BranchID);
                            PRN.Insert();
                            #endregion

                            #region Insert Detail
                            foreach (DataGridViewRow row in dgvDetail.Rows)
                            {
                                #region Initialize Variables and Set Grid Values then Pass Values to Object
                                string sJobCode = "default", sItemCode = "", sItemSubCategoryID1 = "", sItemSubCategoryID2 = "", sItemSerialNo1 = "", sItemSerialNo2 = "", sGRNID = "", sPRNID = "", sBatch = "", sUom = "", sRemarks = "";
                                decimal dQty = 0, dUnitPrice = 0, dWeight = 0, dAmount = 0, dWaranty = 0, dWeidhtPrice = 0;
                                int iLineNo = 0;
                                //*******************************           VERY IMPORTANT      ***************************************
                                //In this grid we didn't change the column names as we use common grid for all stock notes
                                //so we have some global method manipulate according to this column names 
                                //              SO DON'T CONFUSE WITH THE GRID COLUMN NAMES CONSIDER ONLY THE VERIABLE NAMES

                                iLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, int.Parse("0"));
                                sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                sItemSubCategoryID1 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                                sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                sItemSerialNo1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                                sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                sGRNID = clsValidate.ValidateGridValue(dgvDetail, "POID", row.Index, "default");
                                sPRNID = clsValidate.ValidateGridValue(dgvDetail, "PRNID", row.Index, "default");
                                sBatch = clsValidate.ValidateGridValue(dgvDetail, "Batch", row.Index, "");
                                sUom = clsValidate.ValidateGridValue(dgvDetail, "UOM", row.Index, "default");
                                dQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                dUnitPrice = clsValidate.ValidateGridTag(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                                dWeidhtPrice = clsValidate.ValidateGridTag(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                                dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                dAmount = clsValidate.ValidateGridTag(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                                dWaranty = clsValidate.ValidateGridValue(dgvDetail, "Warranty", row.Index, decimal.Parse("0.00"));
                                sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");

                                //Get Unit Price with Exchange rate to save
                                dUnitPrice = getSavePrice(dUnitPrice);
                                dWeidhtPrice = getSavePrice(dWeidhtPrice);
                                dAmount = getSavePrice(dAmount);

                                //  decimal dCostFifo = clsHelpMethods.GetFifoCost(sItemCode , dQty);

                                tbl_scsPurchaseReturnedNote_Detail PRNDetail = new tbl_scsPurchaseReturnedNote_Detail(iLineNo, txtPRNID.Text.Trim(), sItemCode,
                                    sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, sGRNID, dQty, 0, dWeight, 0, dWaranty, dWeidhtPrice, dUnitPrice, 0, 0, dAmount, sRemarks, 0, 0);
                                PRNDetail.Insert();
                                #endregion

                                #region Update Store Stock
                                decimal dWeightedAverageCostPrice = 0;
                                decimal dCostFifo = clsHelpMethods.UpdateStoreStock(iFormID, PRN.PurchaseReturnedNote_ID, PRN.PurchaseReturnedNoteDate, sItemCode, "0", txtStoreID.Tag.ToString(), dQty, dWeight, PRNDetail.TatalAmount, false, false, true, ref dWeightedAverageCostPrice);
                                //   clsHelpMethods.UpdateFifo_Stock(iFormID, PRN.PurchaseReturnedNote_ID, PRN.PurchaseReturnedNoteDate, PRN.Store_ID, PRNDetail.Item_ID, PRNDetail.ItemSerialNo, PRNDetail.Qty, PRNDetail.UnitPrice, false, dCostFifo);
                                PRNDetail.Cost_FIFO = dCostFifo;
                                PRNDetail.WeightedAvgCost = dWeightedAverageCostPrice;
                                PRNDetail.Update();
                                #endregion

                                #region Pass Value to Inventory Detail
                                tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, iLineNo, 0, txtPRNID.Text.Trim(), dtpPRNDate.Value,
                                                            "", "", "", "", "default", txtSupplierID.Tag.ToString(), txtStoreID.Tag.ToString(),
                                                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), 0, dQty, dUnitPrice, 0, false);
                                oListInventory.Add(oInventoryDetail);
                                #endregion
                            }
                            #endregion

                            Attachments.Insert(txtPRNID.Text.ToString());

                            #region Update Inventory
                            tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtPRNID.Text.Trim(), dtpPRNDate.Value, txtRemark.Text.Trim(),
                                "default", txtSupplierID.Tag.ToString(), "default", -1, decimal.Parse(txtGrandTotal.Text.Trim()),
                                "", "", "", "", false, clsSecurity.UserIDLoged);

                            clsHelpMethods.Update_Inventory(oHeader, oListInventory);
                            #endregion

                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //else
                        //    MessageBox.Show("PRN " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    tbl_scsPurchaseReturnedNote oldRecord = tbl_scsPurchaseReturnedNote.Select(txtPRNID.Text.Trim());
                    ClearFields();
                    if (oldRecord != null)
                        FillDetails(oldRecord.PurchaseReturnedNote_ID);
                }
            }
        }
        #endregion

        #region Btn Print
        private void frm_scsPurchaseReturnNote_SF_printButton_Click(object sender, EventArgs e)
        {
            tbl_scsPurchaseReturnedNote detail = tbl_scsPurchaseReturnedNote.Select(txtPRNID.Text.Trim());
            if (detail != null && detail.IsApproved)
            {
                Print(false);
            }
            else
            {
                MessageBox.Show("Please Approve the Transaction Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Btn Draft
        private void frm_scsPurchaseReturnNote_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region Btn Add GRN
        private void btnAddGRN_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEGRNID.Tag != null && txtEGRNID.Tag.ToString().Length > 0)
                {
                    tbl_scsExternalGoodReceivedNote detail = tbl_scsExternalGoodReceivedNote.Select(txtEGRNID.Tag.ToString());
                    if (detail != null)
                    {
                        chkUnitPricing.Checked = !detail.IsWeightCalculation;

                        //add order ref detail
                        glbOrderRefNo = detail.IssuedRefNo_ID;
                        txtSupplierRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_IssuedRefNo(detail.IssuedRefNo_ID));
                        txtSupplierRefNo.Tag = detail.IssuedRefNo_ID;
                        txtCostCenter.Tag = detail.CostCenter;

                        txtStockNoteType.Tag = detail.StockNoteType_ID;
                        txtStockNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_StockNoteType(detail.StockNoteType_ID));
                        txtSupplierID.Tag = detail.Supplier_ID;
                        txtSupplierID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Supplier(detail.Supplier_ID));
                        txtCostCenter.Text = clsGenaralName.getName_AccCostCenter1(detail.CostCenter);
                        txtStoreID.Tag = detail.Store_ID;
                        txtStoreID.Text = clsGenaralName.getName_Store(detail.Store_ID);

                        clsCommon.SetEnableDisable_NormalTextbox(txtSupplierRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblIssuedRefNo, false);

                        //add currency detail
                        FillDetailsCurrency(detail.Currency_ID);
                        txtCurrencyRate.Text = detail.CurrencyRate.ToString();
                        FillTaxDetailByGRN(glbGoodReceivedNoteID);

                        RefreshGridByGRNID(detail.ExternalGoodReceivedNote_ID);

                        #region Asign tax values

                        if (detail.DiscountTotal > 0)
                        {
                            chkDiscount.Checked = true;
                            txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.DiscountPercentage);
                        }
                        if (detail.NbtTotal > 0)
                            chkNBT.Checked = true;
                        else
                            chkNBT.Checked = false;
                        if (detail.VatTotal > 0)
                            chkVat.Checked = true;
                        else
                            chkVat.Checked = false;
                        if (detail.OtherTaxTotal > 0)
                            chkOtherTax.Checked = true;
                        else
                            chkOtherTax.Checked = false;

                        txtSubTotal.Tag = clsHelpMethods.getDisplayPrice(detail.SubTotal, detail.CurrencyRate);
                        txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));

                        txtDiscount.Tag = clsHelpMethods.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate);
                        txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate));

                        txtNBT.Tag = clsHelpMethods.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate);
                        txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate));

                        txtVat.Tag = clsHelpMethods.getDisplayPrice(detail.VatTotal, detail.CurrencyRate);
                        txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.VatTotal, detail.CurrencyRate));

                        txtOtherTax.Tag = clsHelpMethods.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate);
                        txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate));

                        txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.GrandTotal, detail.CurrencyRate));

                        #endregion
                    }
                }
                txtEGRNID.Enabled = false;
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        #endregion

        #region Btn Add Items
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (txtItemID.Tag != null && txtItemID.Tag.ToString().Length > 0)
                RefreshGridByItemID(txtItemID.Tag.ToString().Trim());
        }
        #endregion

        #region Btn Temp
        private void frm_scsPurchaseReturnNote_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtPRNID.TextLength > 0 && txtPRNID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPRNID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSupplierID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStockNoteType, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtSupplierRefNo, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, true);

                clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblIssuedRefNo, true);
                clsCommon.SetEnableDisable_NormalLabel(lblLocationID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblStockNoteType, true);

                txtPRNID.Tag = null;
                dtpPRNDate.Value = clsSecurity.getServerDateTime();

                txtStockNoteType.Tag = null;
                txtStockNoteType.Clear();

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Order Ref No
                txtSupplierRefNo.Tag = null;
                txtSupplierRefNo.Clear();

                //Reset Primary Key
                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtPRNID.Text = "<Auto Generate>";
                else
                    txtPRNID.Clear();
                if (txtPRNID.Enabled)
                {
                    txtPRNID.SelectAll();
                    txtPRNID.Focus();
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
            clsHelpMethods.FormatGrid_Stock_External(dgvDetail);

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
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enable the id
            IsUpdate = false;
            lblCancelled.Visible = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPRNID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSupplierID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStockNoteType, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtSupplierRefNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblIssuedRefNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblLocationID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblStockNoteType, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, true);

            if (clsConfig.bShow_GridViewColumn_Remarks)
                dgvDetail.Columns["Remarks"].Visible = true;
            else
                dgvDetail.Columns["Remarks"].Visible = false;

            txtPRNID.Tag = null;
            txtSupplierID.Tag = null;
            txtEGRNID.Tag = null;
            //txtItemID.Tag = null;
            txtStoreID.Tag = null;
            txtItemID.Tag = null;
            txtSupplierRefNo.Tag = null;
            txtItemSubCategory.Tag = null;
            txtItemSerialNo.Tag = null;
            txtCurrencyID.Tag = null;
            txtStockNoteType.Tag = null;
            txtCostCenter.Tag = null;

            txtSupplierID.Clear();
            txtEGRNID.Clear();
            glbOrderRefNo = "";
            txtCurrencyID.Clear();
            txtCurrencyCode.Clear();
            txtCurrencyRate.Clear();
            txtStoreID.Clear();
            txtItemID.Clear();
            txtRemark.Clear();
            txtDONo.Clear();
            txtStockNoteType.Clear();
            txtSupplierRefNo.Clear();
            txtItemSubCategory.Clear();
            txtItemSerialNo.Clear();
            txtCostCenter.Clear();


            dtpPRNDate.Value = clsSecurity.getServerDateTime();
            chkIsReturnbale.Checked = false;
            chkUnitPricing.Checked = true;
            chkShowSettle.Checked = false;

            txtDiscount.Text = "0";
            txtGrandTotal.Text = "0";
            txtNBT.Text = "0";
            txtOtherTax.Text = "0";
            txtPercentageDiscount.Text = "0";
            txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageNBT());
            txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageOtherTax());
            txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageVAT());
            txtSubTotal.Text = "0";
            txtVat.Text = "0";

            txtDiscount.Tag = 0;
            txtNBT.Tag = 0;
            txtVat.Tag = 0;
            txtOtherTax.Tag = 0;
            txtSubTotal.Tag = 0;

            bHasApproved = false;
            bHasChecked = false;
            userDetailsColorChanges();

            chkDiscount.Checked = false;
            chkNBT.Checked = false;
            chkOtherTax.Checked = false;
            chkVat.Checked = false;
            dgvDetail.Rows.Clear();
            DisableMoneyControls();

            chkPrintOriginal.Checked = false;

            txtEGRNID.Enabled = true;

            dtpPRNDate.Enabled = !clsConfig.bLock_TransactionDate_SCS;

            FillDetailsCurrency(clsConfig.sLocalCurrencyCode);

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtPRNID.Text = "<Auto Generate>";
            else
                txtPRNID.Clear();
            if (txtPRNID.Enabled)
            {
                txtPRNID.SelectAll();
                txtPRNID.Focus();
            }

            Attachments.Clear();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string sPrnID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();

                List<tbl_scsPurchaseReturnedNote_Detail> details = tbl_scsPurchaseReturnedNote_Detail.SelectAllByPurchaseReturnedNote_ID(sPrnID).OrderBy(p => p.Line_No).ToList();
                foreach (tbl_scsPurchaseReturnedNote_Detail detail in details)
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (detail != null)
                    {
                        decimal dExRate = 0;
                        if (txtCurrencyRate.Text.Trim().Length > 0)
                            dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        Fill_Datagrid(iRow, detail.Line_No, detail.Item_ID, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.ExternalGoodReceivedNote_ID, "default", "",
                            item.IsTIEPItem, detail.Qty, detail.UnitPrice, detail.KiloPrice, detail.Weight, detail.TatalAmount, detail.Warranty, detail.Remark, dExRate, "o");
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridByGRNID(string sGRN)
        {
            try
            {
                int iRow;
                //dgvDetail.Rows.Clear();
                List<tbl_scsExternalGoodReceivedNote_Detail> details = tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(sGRN).OrderBy(p => p.Line_No).ToList();
                foreach (tbl_scsExternalGoodReceivedNote_Detail detail in details)
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (item != null)
                    {
                        decimal dExRate = 0;
                        if (txtCurrencyRate.Text.Trim().Length > 0)
                            dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        Fill_Datagrid(iRow, detail.Line_No, detail.Item_ID, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.ExternalGoodReceivedNote_ID, "default", "", item.IsTIEPItem,
                            detail.Qty, detail.UnitPrice, detail.KiloPrice, detail.Weight, detail.TatalAmount, detail.Warranty, detail.Remark, dExRate, "n");
                    }
                }
                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void RefreshGridByItemID(string sItemID)
        {
            try
            {
                int iRow;
                tbl_genItemMaster detail = tbl_genItemMaster.Select(sItemID);
                tbl_genItemMaster_Pricing oItemF = tbl_genItemMaster_Pricing.Select(sItemID);
                if (detail != null && oItemF != null)
                {
                    decimal dExRate = 0;
                    if (txtCurrencyRate.Text.Trim().Length > 0)
                        dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    clsCommon.ValidateForeignKey(ref txtItemSubCategory);
                    clsCommon.ValidateForeignKey(ref txtItemSerialNo, "0");

                    var maxLineNo = dgvDetail.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["LineNo"].Value));
                    Fill_Datagrid(iRow, maxLineNo + 1, detail.Item_ID, txtItemSubCategory.Tag.ToString(), txtItemSubCategory.Text.Trim(), txtItemSerialNo.Tag.ToString(), txtItemSerialNo.Text.Trim(),
                        "default", "default", "", detail.IsTIEPItem, 0, oItemF.CostPrice1, oItemF.SellingPrice6, 0, 0, 0, "", dExRate, "n");
                }
                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();
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
                    tbl_scsPurchaseReturnedNote detail = tbl_scsPurchaseReturnedNote.Select(sID);
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

                            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPRNID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSupplierID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStockNoteType, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblLocationID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, false);
                        clsCommon.SetEnableDisable_NormalTextbox(txtSupplierRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblIssuedRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblStockNoteType, false);

                        //fill order details
                        tbl_zIssuedRefNo Issued = tbl_zIssuedRefNo.Select(detail.IssuedRefNo_ID);
                        if (Issued != null)
                        {
                            txtSupplierRefNo.Tag = detail.IssuedRefNo_ID;
                            txtSupplierRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_IssuedRefNo(detail.IssuedRefNo_ID));
                        }

                        //assign values
                        txtSupplierID.Tag = detail.Supplier_ID;
                        txtStoreID.Tag = detail.Store_ID;
                        txtEGRNID.Tag = detail.ExternalGoodReceivedNote_ID;
                        txtStockNoteType.Tag = detail.StockNoteType_ID;
                        txtDONo.Text = detail.DeliveryOrderNo;
                        glbOrderRefNo = detail.IssuedRefNo_ID;

                        txtStoreID.Text = clsGenaralName.getName_Store(detail.Store_ID);
                        txtSupplierID.Text = clsGenaralName.getName_Supplier(detail.Supplier_ID);

                        txtEGRNID.Text = clsCommon.GetForeignKeyValue(detail.ExternalGoodReceivedNote_ID);
                        txtStockNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_StockNoteType(detail.StockNoteType_ID));

                        txtPRNID.Text = detail.PurchaseReturnedNote_ID;
                        dtpPRNDate.Value = detail.PurchaseReturnedNoteDate;
                        txtRemark.Text = detail.Remark;
                        chkUnitPricing.Checked = !detail.IsWeightCalculation;
                        chkIsReturnbale.Checked = detail.IsReturnable;
                        FillDetailsCurrency(detail.Currency_ID);
                        txtCurrencyRate.Text = detail.CurrencyRate.ToString();
                        txtCostCenter.Tag = detail.CostCenter;
                        txtCostCenter.Text = clsGenaralName.getName_AccCostCenter1(detail.CostCenter);

                        txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.DiscountPercentage);
                        txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                        txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);
                        txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);


                        if (detail.DiscountTotal > 0)
                            chkDiscount.Checked = true;
                        else
                            chkDiscount.Checked = false;
                        if (detail.NbtTotal > 0)
                            chkNBT.Checked = true;
                        else
                            chkNBT.Checked = false;
                        if (detail.VatTotal > 0)
                            chkVat.Checked = true;
                        else
                            chkVat.Checked = false;
                        if (detail.OtherTaxTotal > 0)
                            chkOtherTax.Checked = true;
                        else
                            chkOtherTax.Checked = false;

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
                        RefreshGrid(detail.PurchaseReturnedNote_ID);

                        //Assign tax values after all calculation
                        txtSubTotal.Tag = getDisplayUnitPrice(detail.SubTotal, detail.CurrencyRate);
                        txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(getDisplayUnitPrice(detail.SubTotal, detail.CurrencyRate));
                        txtDiscount.Tag = getDisplayUnitPrice(detail.DiscountTotal, detail.CurrencyRate);
                        txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(getDisplayUnitPrice(detail.DiscountTotal, detail.CurrencyRate));
                        txtNBT.Tag = getDisplayUnitPrice(detail.NbtTotal, detail.CurrencyRate);
                        txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(getDisplayUnitPrice(detail.NbtTotal, detail.CurrencyRate));
                        txtVat.Tag = getDisplayUnitPrice(detail.VatTotal, detail.CurrencyRate);
                        txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(getDisplayUnitPrice(detail.VatTotal, detail.CurrencyRate));
                        txtOtherTax.Tag = getDisplayUnitPrice(detail.OtherTaxTotal, detail.CurrencyRate);
                        txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(getDisplayUnitPrice(detail.OtherTaxTotal, detail.CurrencyRate));
                        txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(getDisplayUnitPrice(detail.GrandTotal, detail.CurrencyRate));

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

        #region Fill Currency Detials
        private void FillDetailsCurrency(string sCurrencyID)
        {
            try
            {
                txtCurrencyID.Tag = null;
                txtCurrencyID.Clear();

                if (sCurrencyID.Length > 0)
                {
                    tbl_zCurrency currency = tbl_zCurrency.Select(sCurrencyID);
                    if (currency != null)
                    {
                        txtCurrencyID.Tag = currency.Currency_ID;
                        txtCurrencyID.Text = currency.CurrencyName;
                        txtCurrencyRate.Text = currency.CurrencyRate.ToString();
                        txtCurrencyCode.Text = currency.CurrencyCode;
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

        #region Fill Tax Detail By GRN
        private void FillTaxDetailByGRN(string sGRNID)
        {
            try
            {
                tbl_scsExternalGoodReceivedNote detail = tbl_scsExternalGoodReceivedNote.Select(sGRNID);
                if (detail != null)
                {
                    txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.DiscountPercentage);
                    txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                    txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);
                    txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);
                    txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));
                    txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate));
                    txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate));
                    txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate));
                    txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.VatTotal, detail.CurrencyRate));
                    txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.GrandTotal, detail.CurrencyRate));

                    chkDiscount.Checked = (detail.DiscountTotal > 0) ? true : false;
                    chkNBT.Checked = (detail.NbtTotal > 0) ? true : false;
                    chkVat.Checked = (detail.VatTotal > 0) ? true : false;
                    chkOtherTax.Checked = (detail.OtherTaxTotal > 0) ? true : false;

                    CalcualteSubTotal();
                    CalculateTaxesAndGrandTotal();

                    txtRemark.Text = detail.Remark;
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmpyyField())
            {
                if (CheckNumberValidity())
                {
                    if (clsValidate.CheckGridCountValidity(dgvDetail.RowCount, iFormID))
                    {
                        if (CheckStockValidity())
                        {
                            if (CheckSupplierSaveValidity(txtSupplierID.Tag.ToString()))
                            {
                                if (clsMethods_GL.CheckValidity_FinancialYear(dtpPRNDate.Value.Date))
                                {
                                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                                    {
                                        if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreID.Tag.ToString(), IsUpdate))
                                        {
                                            if (CheckValidity_WATollarance())
                                            {
                                                bStatus = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return bStatus;
        }
        private bool CheckValidity_EmpyyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtSupplierID, "Supplier Name"))
            {
                if (clsValidate.ValidateTextBox_EmptyValue(txtStoreID, "Issued From"))
                {
                    if (clsValidate.ValidateTextBox_EmptyValue(txtStockNoteType, "Stock Note Type"))
                    {
                        //if (clsValidate.ValidateTextBox_EmptyValue(txtSupplierRefNo, "Tracking No"))
                        //{
                        if (clsValidate.ValidateTextBox_EmptyValue(txtCurrencyID, "Currency"))
                        {
                            if (clsValidate.ValidateTextBox_EmptyValue(txtCurrencyRate, "Currency Rate"))
                            {
                                bStatus = true;
                            }
                        }
                        //}
                    }
                }
            }
            return bStatus;
        }
        private bool CheckSupplierSaveValidity(string sSupplierID)
        {
            bool rtn = true;
            if (clsValidate.isSupplierBlackListed(sSupplierID))
                rtn = false;
            else if (clsValidate.isSupplierSuspended(sSupplierID))
                rtn = false;
            return rtn;
        }
        private bool CheckNumberValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (!clsCommon.isCurrency(txtSubTotal.Text.Trim()))
                {
                    strMessage += "\n Sub Total";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtDiscount.Text.Trim()))
                {
                    strMessage += "\n Discount Total";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtPercentageDiscount.Text.Trim()))
                {
                    strMessage += "\n Discount Percentage";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtVat.Text.Trim()))
                {
                    strMessage += "\n VAT Total";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtPercentageVat.Text.Trim()))
                {
                    strMessage += "\n VAT Percentage";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtNBT.Text.Trim()))
                {
                    strMessage += "\n NBT Total";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtPercentageVat.Text.Trim()))
                {
                    strMessage += "\n NBT Percentage";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtGrandTotal.Text.Trim()))
                {
                    strMessage += "\n Grand Total";
                    bStatus = false;
                }

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
                decimal dWeightActual = 0;
                decimal dQty = 0;
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    sOriginalItemCode = sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                    dWeightActual = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                    dQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                    //sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
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
                        if (sItemStatus.ToLower() == "o") //old item
                        {
                            #region Old Items Stock Validation
                            List<tbl_scsPurchaseReturnedNote_Detail> oldDetails = tbl_scsPurchaseReturnedNote_Detail.SelectAllByPurchaseReturnedNote_ID(txtPRNID.Text.Trim());
                            foreach (tbl_scsPurchaseReturnedNote_Detail oldDetail in oldDetails)
                            {
                                if (oldDetail.Item_ID == sOriginalItemCode && oldDetail.ItemSubCategory_ID == sSubCategoryID1 && oldDetail.ItemSubCategory2_ID == sSubCategoryID2 && oldDetail.ItemSerialNo == sSerialNo1 && oldDetail.ItemSerialNo2 == sSerialNo2)
                                {
                                    decimal dVeriance = 0;
                                    if (clsConfig.bStockValidateQty_PRN) //check whether stock enabled - qty
                                    {
                                        #region Old Items Quantity Validation
                                        if (oldDetail.Qty < dQty)
                                            dVeriance = dQty - oldDetail.Qty;

                                        if (stock.Qty < dVeriance)
                                        {
                                            strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + " Required Quantity Is Not Available As IT Is In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                                            bStatus = false;
                                        }
                                        #endregion
                                    }
                                    if (clsConfig.bStockValidateWeight_PRN) //check whether stock enabled - weight
                                    {
                                        ////weight part
                                        dVeriance = 0;
                                        #region Old Items Weight Validation
                                        if (oldDetail.Weight < dWeightActual)
                                            dVeriance = dWeightActual - oldDetail.Weight;

                                        if (stock.Weight < dVeriance)
                                        {
                                            strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + " Required Weight Is Not Available As IT Is In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                                            bStatus = false;
                                        }
                                        #endregion
                                    }
                                }
                            }
                            #endregion
                        }
                        else //new item
                        {
                            #region New Item Stock Validation
                            if (stock.Weight < dWeightActual && clsConfig.bStockValidateWeight_PRN) //check whether stock enabled - Weight
                            {
                                strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + " Required Weight Is Not Available As IT Is In  " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                                bStatus = false;
                            }
                            if (stock.Qty < dQty && clsConfig.bStockValidateQty_PRN) //check whether stock enabled - Qty
                            {
                                strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "  Required Quantity Is Not Available As IT Is In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                                bStatus = false;
                            }
                            #endregion
                        }
                    }
                    else //No stock in selected store
                    {
                        strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + " Is Not Available In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + " Stock\n";
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
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }

            return bStatus;
        }
        private bool ValidateForDependancies(string sPRNId)
        {
            bool bValue = true;

            //foreach (tbl_accDebitNote_Detail oDBN_Detail in tbl_accDebitNote_Detail.SelectAllByPurchaseReturnedNote_ID(sPRNId))
            //{
            //    tbl_accDebitNote detail = tbl_accDebitNote.Select(oDBN_Detail.DebitNote_ID);
            //    if (detail != null && detail.DebitNote_ID != "default" && !detail.IsDeleted)
            //    {
            //        bValue = false;
            //        MessageBox.Show("Record Is Locked! \n\n[" + detail.DebitNote_ID + "] SRN is already created for this PRN", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        break;
            //    }
            //}


            //foreach (tbl_bpsCreditNote_Detail oPR in tbl_bpsCreditNote_Detail.selecAllByPurchaseReturnNoteID(sPRNId))
            //{
            //    tbl_bpsCreditNote detail = tbl_bpsCreditNote.Select(oPR.CreditNote_ID);
            //    if (detail != null && detail.CreditNote_ID != "default" && !detail.IsDeleted)
            //    {
            //        bValue = false;
            //        MessageBox.Show("Record Is Locked! \n\n[" + detail.CreditNote_ID + "] CreditNote is already created for this Purchase Return Note", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        break;
            //    }

            //}
            return bValue;
        }
        private bool CheckValidity_WATollarance()
        {
            #region Variables
            DataTable dtGrid = new DataTable();
            dtGrid.Columns.Add("LineNo");
            dtGrid.Columns.Add("ItemCode");
            dtGrid.Columns.Add("Quantity");
            dtGrid.Columns.Add("UnitPrice");

            List<tbl_Detail> DB = new List<tbl_Detail>();
            #endregion

            #region Copy grid
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                int iLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, int.Parse("0"));
                string sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                decimal dQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                decimal dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));

                dtGrid.Rows.Add(iLineNo, sItemCode, -dQty, dUnitPrice);
            }
            #endregion

            #region Copy Saved value
            foreach (tbl_scsPurchaseReturnedNote_Detail oDetail in tbl_scsPurchaseReturnedNote_Detail.SelectAllByPurchaseReturnedNote_ID(txtPRNID.Text.Trim()))
            {
                DB.Add(new tbl_Detail(oDetail.Line_No, oDetail.Item_ID, -oDetail.Qty, oDetail.UnitPrice));
            }
            #endregion

            return clsHelpMethods.CheckValidity_WATollarance(dtGrid, DB);
        }

        private bool CheckCancelValidity_WATollarance()
        {
            List<tbl_Detail> DB = new List<tbl_Detail>();
            foreach (tbl_scsPurchaseReturnedNote_Detail oDetail in tbl_scsPurchaseReturnedNote_Detail.SelectAllByPurchaseReturnedNote_ID(txtPRNID.Text.Trim()))
            {
                DB.Add(new tbl_Detail(oDetail.Line_No, oDetail.Item_ID, -oDetail.Qty, oDetail.UnitPrice));
            }
            return clsHelpMethods.CheckCancelValidity_WATollarance(DB);
        }
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtStoreID);
                clsCommon.ValidateForeignKey(ref txtEGRNID);
                clsCommon.ValidateForeignKey(ref txtItemID);
                clsCommon.ValidateForeignKey(ref txtItemSubCategory);
                clsCommon.ValidateForeignKey(ref txtItemSerialNo);
                clsCommon.ValidateForeignKey(ref txtCurrencyID);
                clsCommon.ValidateForeignKey(ref txtCostCenter);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Events KeyDown
        private void txtPRNID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_PRNID();
        }
        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SupplierID();
        }
        private void txtGRNID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_GoodsRecivedNote();
        }
        private void txtStoreID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Store();
        }
        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Item();
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
        private void txtCurrencyID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Currency();
        }
        private void txtStockNoteType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_StockNoteType();
            }
        }
        private void frm_sasCustomerInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSubAccount2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtSubAccount2_DoubleClick(null, null);
        }
        #endregion

        #region Events Double Click
        private void txtPRNID_DoubleClick(object sender, EventArgs e)
        {
            Search_PRNID();
        }
        private void txtItemID_DoubleClick(object sender, EventArgs e)
        {
            Search_Item();
        }
        private void txtStoreID_DoubleClick(object sender, EventArgs e)
        {
            Search_Store();
        }
        private void txtGRNID_DoubleClick(object sender, EventArgs e)
        {
            Search_GoodsRecivedNote();
        }
        private void txtCustomerID_DoubleClick(object sender, EventArgs e)
        {
            Search_SupplierID();
        }
        private void txtCheckedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }
        private void txtApprovedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }
        private void txtStockNoteType_DoubleClick(object sender, EventArgs e)
        {
            Search_StockNoteType();
        }
        private void txtCurrencyID_DoubleClick(object sender, EventArgs e)
        {
            Search_Currency();
        }

        private void txtSubAccount2_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_costCenter1(ref txtCostCenter);
        }
        #endregion

        #region Events KeyUp
        private void txtPercentageOtherTax_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }
        private void txtDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }
        #endregion

        #region Events CheckedChanged
        private void chkDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiscount.Checked)
            {
                txtPercentageDiscount.Enabled = true;
                txtDiscount.Enabled = true;
                CalculateTaxesAndGrandTotal();
            }
            else
            {
                txtPercentageDiscount.Enabled = false;
                txtDiscount.Enabled = false;
                txtPercentageDiscount.Text = "0";
                txtDiscount.Text = "0";
                CalculateTaxesAndGrandTotal();
            }
        }
        private void chkNBT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNBT.Checked)
            {
                CalculateTaxesAndGrandTotal();
                chkVat.Checked = true;
            }
            else
                CalculateTaxesAndGrandTotal();
        }
        private void chkVat_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVat.Checked)
            {
                chkOtherTax.Checked = false;
                CalculateTaxesAndGrandTotal();
            }
            else
                CalculateTaxesAndGrandTotal();
        }
        private void chkOtherTax_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOtherTax.Checked)
            {
                chkVat.Checked = false;
                CalculateTaxesAndGrandTotal();
            }
            else
                CalculateTaxesAndGrandTotal();
        }
        private void chkUnitPricing_CheckedChanged(object sender, EventArgs e)
        {
            CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);
        }
        #endregion

        #region Events Datagried
        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            clsEvent.StockGrid_External_CellEndEdit(sender, e, dgvDetail, !chkUnitPricing.Checked);
            CalcualteSubTotal();
            CalculateTaxesAndGrandTotal();
        }
        private void dgvDetail_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            clsEvent.SalesGrid_CellParsing(sender, e, dgvDetail);
        }
        #endregion

        #region Disable Money Controls
        private void DisableMoneyControls()
        {
            txtDiscount.Enabled = false;
            txtPercentageDiscount.Enabled = false;
            txtPercentageVat.Enabled = false;
            txtPercentageNBT.Enabled = false;
            txtPercentageOtherTax.Enabled = false;
            txtOtherTax.Enabled = false;
        }
        #endregion

        #region Search Methods
        private void Search_PRNID()
        {
            if (txtStockNoteType.Tag != null)
                clsSearch.Search_TransactionPurchaseReturnNote_Direct(ref txtPRNID, chkShowSettle.Checked, txtStockNoteType.Tag.ToString());
            else
                clsSearch.Search_TransactionPurchaseReturnNote_Direct(ref txtPRNID, "default", chkShowSettle.Checked);

            if (txtPRNID.Tag != null && txtPRNID.Tag.ToString().Trim().Length > 0)
                FillDetails(txtPRNID.Tag.ToString());
        }
        private void Search_Item()
        {
            clsHelpMethods.SearchItemAdvance(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo);
            if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                btnAddItem_Click(btnAddItem, new EventArgs());
        }
        private void Search_Store()
        {
            clsSearch.Search_MasterStore(ref txtStoreID, true);
        }
        private void Search_StockNoteType()
        {
            clsSearch.Search_MasterStockNoteType(ref txtStockNoteType);
        }
        private void Search_GoodsRecivedNote()
        {
            bool hasOrderRefNo = false;
            if (glbOrderRefNo.Length > 0)
                hasOrderRefNo = true;
            clsSearch.Search_TransactionExternalGoodReceivedNote_Use(ref txtEGRNID, hasOrderRefNo, glbOrderRefNo);
            if (txtEGRNID.Tag != null && txtEGRNID.Tag.ToString().Trim().Length > 0) //call add button
                btnAddGRN_Click(btnAddGRN, new EventArgs());
        }
        private void Search_Currency()
        {
            clsSearch.Search_MasterCurrency(ref txtCurrencyID);
            if (txtCurrencyID.Tag != null)
                FillDetailsCurrency(txtCurrencyID.Tag.ToString());
            else
                FillDetailsCurrency(clsConfig.sLocalCurrencyCode);
        }
        private void Search_SupplierID()
        {
            clsSearch.Search_MasterSupplier(ref txtSupplierID);
        }
        #endregion

        #region Calcualte Values
        private void CalcualteSubTotal()
        {
            try
            {
                decimal Amount = 0;
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                {
                    if (dgvDetail["Amount", x].Tag != null && dgvDetail["Amount", x].Tag.ToString().Length > 0)
                    {
                        if (clsCommon.isCurrency(dgvDetail["Amount", x].Tag.ToString()))
                            Amount += decimal.Parse(dgvDetail["Amount", x].Tag.ToString());
                    }
                }
                txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(Amount);
                txtSubTotal.Tag = Amount;
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

        #region Calculate Taxes and GrandTotal
        private void CalculateTaxesAndGrandTotal()
        {
            txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.CalculateGrandTotalAdvance_Round(txtSubTotal, txtDiscount, txtPercentageDiscount, chkDiscount,
                txtNBT, txtPercentageNBT, chkNBT, txtVat, txtPercentageVat, chkVat, txtOtherTax, txtPercentageOtherTax, chkOtherTax));
        }
        #endregion

        #region Price Convertion
        public decimal getSavePrice(decimal dEnteredPrice)
        {
            decimal dUnitPrice = 0, dExRate = 0;
            if (txtCurrencyRate.Text.Trim().Length > 0)
                dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());

            dUnitPrice = dEnteredPrice * dExRate;
            return dUnitPrice;
        }

        public decimal getDisplayUnitPrice(decimal dEnteredUnitPrice, decimal dExRate)
        {
            decimal dUnitPrice = 0;
            if (dExRate > 0)
                dUnitPrice = dEnteredUnitPrice / dExRate;
            return dUnitPrice;
        }
        #endregion

        #region Fill Datagrid
        private void Fill_Datagrid(int iRow, int iLineNo, string ItemID, string ItemSubCategoryID1, string ItemSubCategoryID2, string ItemSerialNo1, string ItemSerialNo2, string EGRNID, string sPRNID, string sBatch, bool bIsTiep, decimal Quantity, decimal UnitPrice, decimal WeightPrice, decimal Weight,
        decimal Amount, decimal dWarranty, string Remark, decimal dExRate, string sItemStatus)
        {
            try
            {
                //foreach (DataGridViewRow row in dgvDetail.Rows)
                //{
                //    string sItemID = "", sItemSub = "", sItemSub2 = "", sSerial = "", sSerial2 = "";
                //    sItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                //    sItemSub = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                //    sItemSub2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                //    sSerial = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                //    sSerial2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");

                //    if (ItemID == sItemID && ItemSubCategoryID1 == sItemSub && ItemSubCategoryID2 == sItemSub2 && ItemSerialNo1 == sSerial && ItemSerialNo2 == sSerial2)
                //    {
                //        dgvDetail.Rows.RemoveAt(iRow);
                //        Weight += clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                //        Quantity += clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                //        iRow = row.Index;
                //    }
                //}

                decimal WeightAvg = 0;
                clsHelpMethods.AddMultipleItems_Grid(dgvDetail, ItemID, ref iRow, ref iLineNo, ref Quantity, ref UnitPrice, ref Weight, ref WeightAvg);

                //Get Unit Price with Exchange rate to save
                UnitPrice = getDisplayUnitPrice(UnitPrice, dExRate);
                WeightPrice = getDisplayUnitPrice(WeightPrice, dExRate);
                Amount = getDisplayUnitPrice(Amount, dExRate);

                //*******************************       VERY IMPORTANT      ***************************************
                //In this grid we didn't change the column names as we use common grid for all stock notes
                //so we have some global method manipulate according to this column names 
                //              SO DON'T CONFUSE WITH THE GRID COLUMN NAMES CONSIDER ONLY THE VERIABLE NAMES

                dgvDetail["LineNo", iRow].Value = iLineNo;
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
                dgvDetail["POID", iRow].Value = EGRNID;//Column Name Doesn't change coz all Stock Note Use Common Grid
                dgvDetail["PRNID", iRow].Value = sPRNID;
                dgvDetail["Batch", iRow].Value = sBatch;
                dgvDetail["IsTiep", iRow].Value = bIsTiep;
                dgvDetail["Warranty", iRow].Value = clsFormatter.FormatToNumberWithOneDecimalPlaces(dWarranty);
                dgvDetail["UOM", iRow].Value = clsGenaralName.getName_ItemUOM(ItemID);
                dgvDetail["Remarks", iRow].Value = Remark;
                dgvDetail["ItemStatus", iRow].Value = sItemStatus;

                if (clsCommon.IsCustomerizedGrid())
                {
                    dgvDetail["Quantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(Quantity);
                    dgvDetail["Weight", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(Weight);
                    dgvDetail["Amount", iRow].Value = clsFormatter.FormatToNumberWithTwoDecimalPlaces(Amount);
                    dgvDetail["Amount", iRow].Tag = Amount;

                    dgvDetail["UnitPrice", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(UnitPrice);
                    dgvDetail["UnitPrice", iRow].Tag = UnitPrice;
                    dgvDetail["WeightPrice", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(WeightPrice);
                    dgvDetail["WeightPrice", iRow].Tag = WeightPrice;
                }
                else
                {
                    dgvDetail["Quantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(System.Convert.ToDecimal(Quantity.ToString()));
                    dgvDetail["UnitPrice", iRow].Value = UnitPrice.ToString();
                    dgvDetail["UnitPrice", iRow].Tag = UnitPrice;
                    dgvDetail["Weight", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(System.Convert.ToDecimal(Weight.ToString()));
                    dgvDetail["WeightPrice", iRow].Value = WeightPrice.ToString();
                    dgvDetail["WeightPrice", iRow].Tag = WeightPrice;
                    dgvDetail["Amount", iRow].Value = Amount.ToString();
                    dgvDetail["Amount", iRow].Tag = Amount;
                }

                #region Set Row Count
                dgvDetail["RowCount", iRow].Value = iRow + 1;
                #endregion
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
                Cursor = Cursors.WaitCursor;
                string sCreateUser = "[ None ]", sCheckedUser = "[ None ]", sApprovedUser = "[ None ]";
                string sBranchId = "";
                bool bApprovalDone = true, bCheckingDone = true;
                string sDuplicate = "";

                if (txtPRNID.TextLength > 0 && txtPRNID.Text != "<Auto Generate>")
                {

                    bool bPermissinOkToPrint = true;
                    if (chkPrintOriginal.Checked)
                        bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_PurchaseReturnNote));
                    if (bPermissinOkToPrint)
                    {
                        tbl_scsPurchaseReturnedNote detail = tbl_scsPurchaseReturnedNote.Select(txtPRNID.Text);
                        if (detail != null && detail.PurchaseReturnedNote_ID != "default")
                        {
                            if (!bIsDraft)
                            {
                                #region Validate Approval
                                if (clsConfig.bApprovalNeedToPrintPRN)
                                {
                                    if (!detail.IsApproved)
                                    {
                                        bApprovalDone = false;
                                        MessageBox.Show("Please Approve the Purchase Return Note Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                #endregion
                                #region Validate Checking
                                if (clsConfig.bCheckingNeedToPrintPRN)
                                {
                                    if (!detail.IsChecked)
                                    {
                                        bCheckingDone = false;
                                        MessageBox.Show("Please Check the Purchase Return Note Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                #endregion
                            }

                            if (bApprovalDone && bCheckingDone)
                            {
                                if (!bIsDraft)
                                {
                                    //sDuplicate = detail.PrintCount > 0 ? "Duplicate Copy " + detail.PrintCount : "";

                                    if (!chkPrintOriginal.Checked)
                                        sDuplicate = (detail.PrintCount > 0) ? "Duplicate Copy " + detail.PrintCount : "";

                                    detail.PrintCount++;
                                    detail.Update();
                                }

                                if (detail.IsDeleted)
                                    sDuplicate = "";

                                glb_dtsScsPurchaseRetNote.dt_scsPurchaseRetNote.Rows.Clear();
                                glb_dtsScsPurchaseRetNote.dt_PurchaseReturnNoteDetail.Rows.Clear();
                                glb_dtsScsPurchaseRetNote.Clear();

                                //fill Header
                                sCreateUser = clsGenaralName.getName_User(detail.CreateUser_ID);
                                if (detail.CheckedUser_ID != "default")
                                    sCheckedUser = "[ " + clsGenaralName.getName_User(detail.CheckedUser_ID) + " ] [ " + detail.DateChecked.ToShortDateString() + " ]";
                                if (detail.ApprovedUser_ID != "default")
                                    sApprovedUser = "[ " + clsGenaralName.getName_User(detail.ApprovedUser_ID) + " ] [ " + detail.DateApproved.ToShortDateString() + " ]";

                                #region fill header
                                tbl_scsExternalGoodReceivedNote oGRN = tbl_scsExternalGoodReceivedNote.Select(detail.ExternalGoodReceivedNote_ID);
                                string sPONo = "-";
                                if (oGRN != null && oGRN.ExternalGoodReceivedNote_ID != "default")
                                {
                                    sPONo = oGRN.PurchaseOrder_ID;
                                }

                                glb_dtsScsPurchaseRetNote.dt_scsPurchaseRetNote.Adddt_scsPurchaseRetNoteRow(detail.PurchaseReturnedNote_ID, detail.PurchaseReturnedNoteDate,
                                    detail.Supplier_ID, clsGenaralName.getName_Supplier(detail.Supplier_ID), detail.ExternalGoodReceivedNote_ID, sPONo, detail.Store_ID, detail.Currency_ID,
                                    detail.CurrencyRate, detail.Remark, detail.CostCenter, detail.DeliveryOrderNo, detail.InvoiceNo, detail.SubTotal, detail.DiscountTotal, detail.GrandTotal,
                                  detail.CreateUser_ID, "", clsGenaralName.getName_Store(detail.Store_ID), detail.VatTotal, detail.NbtTotal, detail.IsWeightCalculation, detail.IsDeleted, 0);
                                #endregion

                                #region fill details
                                long LineNo = 1;
                                foreach (tbl_scsPurchaseReturnedNote_Detail oDetail in tbl_scsPurchaseReturnedNote_Detail.SelectAllByPurchaseReturnedNote_ID(detail.PurchaseReturnedNote_ID))
                                {
                                    glb_dtsScsPurchaseRetNote.dt_PurchaseReturnNoteDetail.Adddt_PurchaseReturnNoteDetailRow(oDetail.Line_No, oDetail.PurchaseReturnedNote_ID, oDetail.Item_ID, clsGenaralName.getName_Item(oDetail.Item_ID),
                                        oDetail.ItemSubCategory_ID, oDetail.ItemSubCategory2_ID, oDetail.ItemSerialNo, oDetail.ItemSerialNo2, oDetail.Qty, oDetail.Weight, oDetail.KiloPrice, oDetail.UnitPrice, oDetail.UnitDiscount,
                                        oDetail.TotalDiscount, oDetail.TatalAmount, oDetail.Remark, clsGenaralName.getName_Brand(oDetail.Item_ID), clsGenaralName.getName_ItemUOMName(oDetail.Item_ID));
                                    LineNo++;
                                }
                                #endregion

                                string s_Path = "";
                                string sGetRptPath = clsHelpMethods.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_PurchaseReturnNote));
                                if (sGetRptPath != null && sGetRptPath.Length > 0)
                                    s_Path += sGetRptPath;
                                else
                                {
                                    s_Path = "\\Reports\\SCS\\NotePrinting\\rpt_scsPurchaseReturnedNote.rpt";
                                }

                                //glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("TelphoneFax", detail.Supplier_ID, true);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("SupplierAddressRegister", clsGenaralName.getSupplierAddressRegister(detail.Supplier_ID), true, false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("TrackingNo", txtSupplierRefNo.Text, true, false);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUser, true, false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sCheckedUser, true, false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUser, true, false);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", clsSecurity.CompanyName, true, false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", clsSecurity.CompanyAddress1, true, false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", clsSecurity.CompanyAddress2, true, false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle", "Purchase Return Note", true, false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("TelphoneFax", clsCommon.getSupplerTelephoneAndFax(detail.Supplier_ID), true, false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("SupplierAddressRegister", clsGenaralName.getSupplierAddressRegister(detail.Supplier_ID), true, false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqName", clsSecurity.DigiteqName, true, false);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicate, true, false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("isDraft", bIsDraft ? "Draft" : "", true, false);

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

                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", "", true, false);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", "", true, false);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", "", true, false);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", "", true, false);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("TelphoneFax", "", true, false);

                                    }
                                }
                                glb_dtsScsPurchaseRetNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, "Purchase Returned Note", "", "", clsSecurity.UserNameLoged, "");
                                #endregion

                                frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
                                ReportViewer.print(s_Path, glb_dtsScsPurchaseRetNote, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_PurchaseReturnNote));
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Please Select the Invoice To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            finally
            {
                glb_dtsScsPurchaseRetNote.dt_scsPurchaseRetNote.Rows.Clear();
                glb_dtsScsPurchaseRetNote.dt_PurchaseReturnNoteDetail.Rows.Clear();
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Print report
        private void print(string path, string sReportTitle, DataSet ojbDataSet, string sSuplierId, bool bIsDraft)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "";// sHeaderTitle = "Standed Reports", sReportFilter = "";
                ReportDocument objRpt = new ReportDocument();

                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(ojbDataSet); //(glbDtsBills);

                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                objRpt.DataDefinition.FormulaFields["TelphoneFax"].Text = clsCommon.fncsetstring(clsCommon.getSupplerTelephoneAndFax(sSuplierId));
                objRpt.DataDefinition.FormulaFields["SupplierAddressRegister"].Text = clsCommon.fncsetstring(clsGenaralName.getSupplierAddressRegister(sSuplierId));
                objRpt.DataDefinition.FormulaFields["TrackingNo"].Text = clsCommon.fncsetstring(txtSupplierRefNo.Text);
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);

                if (isDuplicate && !bIsDraft)
                    objRpt.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring("Duplicate Copy");
                if (isCanceled)
                    objRpt.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring("");
                if (bIsDraft)
                    objRpt.DataDefinition.FormulaFields["isDraft"].Text = clsCommon.fncsetstring("Draft");

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

        private void frm_scsPurchaseReturnNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            Attachments.Close();
        }

        #region User Checked Approve Details
        private void frm_scsPurchaseReturnNote_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_scsPurchaseReturnNote_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpPRNDate.Value.Date))
                {
                    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtPRNID.Text != null && txtPRNID.TextLength > 0 && txtPRNID.Text != "<Auto Generate>")
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

                                        tbl_scsPurchaseReturnedNote objPRN = tbl_scsPurchaseReturnedNote.Select(txtPRNID.Text.Trim());
                                        if (objPRN != null)
                                        {
                                            objPRN.IsApproved = true;
                                            objPRN.DateApproved = clsSecurity.getServerDateTime();
                                            objPRN.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                            objPRN.Update();
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
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpPRNDate.Value.Date))
                {
                    if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtPRNID.Text != null && txtPRNID.TextLength > 0 && txtPRNID.Text != "<Auto Generate>")
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

                                        tbl_scsPurchaseReturnedNote objPRN = tbl_scsPurchaseReturnedNote.Select(txtPRNID.Text.Trim());
                                        if (objPRN != null)
                                        {
                                            objPRN.IsChecked = true;
                                            objPRN.DateChecked = clsSecurity.getServerDateTime();
                                            objPRN.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objPRN.Update();
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

        private void frm_scsPurchaseReturnNote_SF_History_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPRNID.Text != "" || txtPRNID.Text != "<Auto Generate>")
                {
                    tbl_scsPurchaseReturnedNote detail = tbl_scsPurchaseReturnedNote.Select(txtPRNID.Text.Trim());
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
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
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

        private void xSetting_Leave(object sender, EventArgs e)
        {
            xSetting.Visible = false;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            xSetting.Visible = false;
        }
        #endregion

    }
}
