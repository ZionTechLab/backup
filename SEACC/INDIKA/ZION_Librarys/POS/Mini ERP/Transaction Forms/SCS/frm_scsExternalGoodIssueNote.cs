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
using Digiteq.DataSets;
using Digiteq.DataSets.SCS;

namespace Digiteq
{
    public partial class frm_scsExternalGoodIssueNote : SEACC_Form
    {
        #region Variables
        //to manage update and insert
        //static bool IsUpdate = false;
        //to keep glob ref no        
        public string glbOrderRefNo = "", glbGINNo = "";
        public DataTable dt_ItemGrouped = new DataTable();

        dts_scsExternalGoodIssueNote glb_dtsscsExternalGoodIssueNote = new dts_scsExternalGoodIssueNote();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        #endregion

        #region Form Load
        public frm_scsExternalGoodIssueNote(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }

        private void frmInvoice_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);
            ClearFields();
            CusDataGridViewFormat();
            CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);

            if (glbGINNo.Length > 0)
                FillDetails(glbGINNo);

        }
        #endregion

        #region Enable Reciver
        private void EnableReciver()
        {
            clearReciver();
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSupplierID, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtOther, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtDepartmentID, false);

            if (rdoDepartment.Checked)
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtDepartmentID, true);

            if (rdoCustomer.Checked)
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);

            if (rdoSupplier.Checked)
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSupplierID, true);

            if (rdoOther.Checked)
                clsCommon.SetEnableDisable_NormalTextbox(txtOther, true);
        }
        #endregion

        #region Enable/Desable All Reciver
        private void EnableDesableAllReciver(bool bArg)
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, bArg);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSupplierID, bArg);
            clsCommon.SetEnableDisable_NormalTextbox(txtOther, bArg);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtDepartmentID, bArg);

            rdoCustomer.Enabled = bArg;
            rdoSupplier.Enabled = bArg;
            rdoDepartment.Enabled = bArg;
            rdoOther.Enabled = bArg;
        }
        #endregion

        #region Btn New
        private void frm_scsExternalGoodIssueNote_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete

        private void frm_scsExternalGoodIssueNote_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGINID.Text.Trim().Length > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpGINDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreID.Tag.ToString(), IsUpdate))
                            {
                                Cursor = Cursors.WaitCursor;
                                tbl_scsExternalGoodIssueNote detail = tbl_scsExternalGoodIssueNote.Select(txtGINID.Text.Trim());
                                if (detail != null)
                                {
                                    if (!detail.IsLocked && !detail.IsFinished && !detail.IsDeleted)
                                    {
                                        if (CheckSupplierSaveValidity())
                                        {
                                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " GIN : " + txtGINID.Text), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                            if (msgResult == DialogResult.Yes)
                                            {
                                                #region Update Other Tables
                                                foreach (tbl_scsExternalGoodIssueNote_Detail Olddetail in tbl_scsExternalGoodIssueNote_Detail.SelectAllByExternalGoodIssueNote_ID(txtGINID.Text.Trim()))
                                                {
                                                    if (Olddetail.Item_ID != null)
                                                    {
                                                        #region Update Store Stock
                                                        decimal dWeightedAverageCostPrice = 0;
                                                        clsHelpMethods.UpdateStoreStock(iFormID, Olddetail.ExternalGoodIssueNote_ID, detail.ExternalGoodIssueNoteDate, Olddetail.Item_ID, "0", txtStoreID.Tag.ToString(), Olddetail.Qty, Olddetail.Weight, Olddetail.TatalAmount, true, false, false, ref dWeightedAverageCostPrice);

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

                                                clsHelpMethods.Delete_Inventory(iFormID, 0, txtGINID.Text.Trim());

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
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
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
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Save
        private void frm_scsExternalGoodIssueNote_SF_saveButton_Click(object sender, EventArgs e)
        {
            dt_ItemGrouped = clsCommon.DataGridViewToDataTable_ItemGrouped_CategoryID1(dgvDetail);

            if (CheckValidity_EmptyField())
            {
                if (CheckNumberValidity())
                {
                    if (CheckSupplierSaveValidity())
                    {
                        if (clsValidate.CheckGridCountValidity(dgvDetail.RowCount, iFormID))
                        {
                            if (CheckStockValidity())
                            {
                                if (clsMethods_GL.CheckValidity_FinancialYear(dtpGINDate.Value.Date))
                                {
                                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                                    {
                                        if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreID.Tag.ToString(), IsUpdate))
                                        {
                                            try
                                            {
                                                Cursor = Cursors.WaitCursor;
                                                ValidateEmptyForeignKey();
                                                if (glbOrderRefNo.Length <= 0)
                                                    glbOrderRefNo = "default";

                                                #region Update EGIN
                                                if (IsUpdate)
                                                {
                                                    tbl_scsExternalGoodIssueNote oldRecord = tbl_scsExternalGoodIssueNote.Select(txtGINID.Text.Trim());
                                                    if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                                                    {
                                                        if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                                                        {
                                                            if (!oldRecord.IsChecked ||  (oldRecord.IsChecked && clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID)))
                                                            {
                                                                if (clsValidate.CheckValidity_TransactionCodeLength(txtGINID.Text))
                                                                {
                                                                    List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();
                                                                    #region Rollback StoreStock

                                                                    foreach (
                                                                        tbl_scsExternalGoodIssueNote_Detail
                                                                            oUpdatedRecord in
                                                                        tbl_scsExternalGoodIssueNote_Detail
                                                                            .SelectAllByExternalGoodIssueNote_ID(
                                                                                txtGINID.Text.Trim()))
                                                                    {
                                                                        decimal dWeightedAverageCostPrice = 0;
                                                                        clsHelpMethods.UpdateStoreStock(iFormID,
                                                                            oUpdatedRecord.ExternalGoodIssueNote_ID,
                                                                            oldRecord.ExternalGoodIssueNoteDate,
                                                                            oUpdatedRecord.Item_ID, "0",
                                                                            txtStoreID.Tag.ToString(),
                                                                            oUpdatedRecord.Qty, oUpdatedRecord.Weight,
                                                                            oUpdatedRecord.TatalAmount, true, false,
                                                                            false, ref dWeightedAverageCostPrice);

                                                                        oUpdatedRecord.WeightedAvgCost = clsProcessMethods.GetItemWeightedAvarageCostPrice(oUpdatedRecord.Item_ID);
                                                                        oUpdatedRecord.Update();
                                                                    }

                                                                    #endregion

                                                                    #region Update Old EGIN Items
                                                                    List<tbl_scsExternalGoodIssueNote_Detail> oldDetails = tbl_scsExternalGoodIssueNote_Detail.SelectAllByExternalGoodIssueNote_ID(txtGINID.Text.Trim());
                                                                    foreach (tbl_scsExternalGoodIssueNote_Detail oldDetail in oldDetails)
                                                                    {
                                                                        #region Detail Variables
                                                                        string sJobCode = "default",
                                                                                                                                            sItemCode = "",
                                                                                                                                            sItemSubCategoryID1 = "",
                                                                                                                                            sItemSubCategoryID2 = "",
                                                                                                                                            sItemSerialNo1 = "",
                                                                                                                                            sItemSerialNo2 = "",
                                                                                                                                            sPOID = "",
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
                                                                        #endregion

                                                                        foreach (DataGridViewRow row in dgvDetail.Rows)
                                                                        {
                                                                            #region Set Grid Values to Variables
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
                                                                            sPOID = clsValidate.ValidateGridValue(
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
                                                                            #endregion

                                                                            #region Check Existing Records
                                                                            if (oldDetail.ExternalGoodIssueNote_ID ==
                                                                                                                                                    txtGINID.Text.Trim() &&
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
                                                                            #region Update old item details

                                                                            //Get Unit Price as weighted avarage cost

                                                                            #region Get weight avarage cost as unit price

                                                                            if (!chkUnitPricing.Checked)
                                                                            {
                                                                                dWeidhtPrice =
                                                                                    clsProcessMethods
                                                                                        .GetItemWeightedAvarageCostPrice(                                                                                            sItemCode                                                                                           );
                                                                                dAmount = dWeidhtPrice * dWeight;
                                                                            }
                                                                            else
                                                                            {
                                                                                dUnitPrice =
                                                                                    clsProcessMethods
                                                                                        .GetItemWeightedAvarageCostPrice(                                                                                            sItemCode);
                                                                                dAmount = dUnitPrice * dQty;
                                                                            }

                                                                            #endregion


                                                                            #region Update Store Stock


                                                                            #endregion

                                                                            oldDetail.Item_ID = sItemCode;
                                                                            oldDetail.ItemSubCategory_ID =                                                                                sItemSubCategoryID1;
                                                                            oldDetail.ItemSubCategory2_ID =                                                                                sItemSubCategoryID2;
                                                                            oldDetail.ItemSerialNo = sItemSerialNo1;
                                                                            oldDetail.ItemSerialNo2 = sItemSerialNo2;
                                                                            oldDetail.Qty = dQty;
                                                                            oldDetail.Weight = dWeight;
                                                                            oldDetail.KiloPrice = dWeidhtPrice;
                                                                            oldDetail.UnitPrice = dUnitPrice;
                                                                            oldDetail.TatalAmount = dAmount;
                                                                            oldDetail.Remark = sRemarks;

                                                                            oldDetail.Update();

                                                                            #endregion

                                                                            #region Pass Value to Inventory Detail
                                                                            tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, iLineNo, 0, txtGINID.Text.Trim(), dtpGINDate.Value,
                                                                                                        "", "", "", "", txtCustomerID.Tag.ToString(), txtSupplierID.Tag.ToString(), txtStoreID.Tag.ToString(),
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
                                                                                //  if (clsConfig.bStockValidateQty_eGIN)
                                                                                //      clsHelpMethods_Local.Store_StockQuantityIncrease(txtStoreID.Tag.ToString(), oldDetail.Item_ID, sJobCode, oldDetail.ItemSubCategory_ID, oldDetail.ItemSubCategory2_ID, oldDetail.ItemSerialNo, oldDetail.ItemSerialNo2, oldDetail.Qty);
                                                                                //  if (clsConfig.bStockValidateWeight_eGIN)
                                                                                //      clsHelpMethods_Local.Store_StockWeightIncrease(txtStoreID.Tag.ToString(), oldDetail.Item_ID, sJobCode, oldDetail.ItemSubCategory_ID, oldDetail.ItemSubCategory2_ID, oldDetail.ItemSerialNo, oldDetail.ItemSerialNo2, oldDetail.Weight);
                                                                            }
                                                                            else
                                                                            {
                                                                                //   clsHelpMethods_Local.Store_NewStock(txtStoreID.Tag.ToString(), oldDetail.Item_ID, sJobCode, oldDetail.ItemSubCategory_ID, oldDetail.ItemSubCategory2_ID, oldDetail.ItemSerialNo, oldDetail.ItemSerialNo2, oldDetail.Weight, 0, oldDetail.Qty, 0, 0, 0, 0, 0);
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
                                                                        #region Inialize Variables and Set Grid Values then Values Pass to Object
                                                                        string sJobCode = "default",
                                                                                                                                            sItemCode = "",
                                                                                                                                            sItemSubCategoryID1 = "",
                                                                                                                                            sItemSubCategoryID2 = "",
                                                                                                                                            sItemSerialNo1 = "",
                                                                                                                                            sItemSerialNo2 = "",
                                                                                                                                            sPOID = "",
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
                                                                        sPOID = clsValidate.ValidateGridValue(dgvDetail,
                                                                            "POID", row.Index, "default");
                                                                        sPRNID = clsValidate.ValidateGridValue(
                                                                            dgvDetail, "PRNID", row.Index, "default");
                                                                        sBatch = clsValidate.ValidateGridValue(
                                                                            dgvDetail, "Batch", row.Index, "");
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
                                                                        

                                                                        //Get Unit Price as weighted avarage cost

                                                                        #region Get weight avarage cost as unit price

                                                                        if (!chkUnitPricing.Checked)
                                                                        {
                                                                            dWeidhtPrice =                                                                                clsProcessMethods                                                                                    .GetItemWeightedAvarageCostPrice(                                                                                        sItemCode);
                                                                            dAmount = dWeidhtPrice * dWeight;
                                                                        }
                                                                        else
                                                                        {
                                                                            dUnitPrice =                                                                                clsProcessMethods                                                                                    .GetItemWeightedAvarageCostPrice(                                                                                        sItemCode);
                                                                            dAmount = dUnitPrice * dQty;
                                                                        }

                                                                        #endregion

                                                                        tbl_scsExternalGoodIssueNote_Detail EGINdetail =
                                                                            new tbl_scsExternalGoodIssueNote_Detail(
                                                                                iLineNo, txtGINID.Text.Trim(),
                                                                                sItemCode, sItemSubCategoryID1,
                                                                                sItemSubCategoryID2, sItemSerialNo1,
                                                                                sItemSerialNo2, dQty, dWeight,
                                                                                dWeidhtPrice, dUnitPrice, 0, 0, dAmount,
                                                                                sRemarks, 0, clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemCode));
                                                                        EGINdetail.Insert();
                                                                        #endregion

                                                                        #region Pass Value to Inventory Detail
                                                                        tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, iLineNo, 0, txtGINID.Text.Trim(), dtpGINDate.Value,
                                                                                                    "", "", "", "", txtCustomerID.Tag.ToString(), txtSupplierID.Tag.ToString(), txtStoreID.Tag.ToString(),
                                                                                                    sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), 0, dQty, dUnitPrice, 0, false);
                                                                        oListInventory.Add(oInventoryDetail);
                                                                        #endregion
                                                                    }
                                                                    #endregion

                                                                    #region Update EGIN Header

                                                                    tbl_scsExternalGoodIssueNote EGIN =
                                                                        new tbl_scsExternalGoodIssueNote(
                                                                            txtGINID.Text.Trim(), dtpGINDate.Value,
                                                                            txtRemark.Text.Trim(), getReciverName(),
                                                                            glbOrderRefNo, txtStoreID.Tag.ToString(),
                                                                            txtSupplierID.Tag.ToString(),
                                                                            txtDepartmentID.Tag.ToString(),
                                                                            txtCustomerID.Tag.ToString(), 0, 0, 0, 0, 0,
                                                                            0, 0, 0, 0, 0, oldRecord.CreateUser_ID,
                                                                            clsSecurity.UserIDLoged,
                                                                            oldRecord.CheckedUser_ID,
                                                                            oldRecord.ApprovedUser_ID,
                                                                            oldRecord.DateCreate,
                                                                            clsSecurity.getServerDateTime(),
                                                                            glbCheckedDate, glbApprovedDate,
                                                                            bHasChecked, bHasApproved,
                                                                            oldRecord.IsFinished, oldRecord.IsDeleted,
                                                                            oldRecord.IsLocked, 0, oldRecord.IsSeattled,
                                                                            0, oldRecord.IsForSupplier,
                                                                            oldRecord.IsForDepartment,
                                                                            oldRecord.IsForOther,
                                                                            oldRecord.IsForCustomer,
                                                                            !chkUnitPricing.Checked,
                                                                            rdoSampleIssued.Checked,
                                                                            oldRecord.CompanyID,
                                                                            oldRecord.CompanyBranch_ID);

                                                                    EGIN.Update();

                                                                    #endregion

                                                                    #region Update Store Stock

                                                                    foreach (
                                                                        tbl_scsExternalGoodIssueNote_Detail
                                                                            oUpdatedRecord in
                                                                        tbl_scsExternalGoodIssueNote_Detail
                                                                            .SelectAllByExternalGoodIssueNote_ID(
                                                                                txtGINID.Text.Trim()))
                                                                    {
                                                                        decimal dWeightedAverageCostPrice = 0;
                                                                        decimal dCostFifo =
                                                                            clsHelpMethods.UpdateStoreStock(
                                                                                iFormID, EGIN.ExternalGoodIssueNote_ID,
                                                                                EGIN.ExternalGoodIssueNoteDate,
                                                                                oUpdatedRecord.Item_ID, "0",
                                                                                txtStoreID.Tag.ToString(),
                                                                                oUpdatedRecord.Qty,
                                                                                oUpdatedRecord.Weight,
                                                                                oUpdatedRecord.TatalAmount, false,
                                                                                false, false, ref dWeightedAverageCostPrice);

                                                                        oUpdatedRecord.Cost_FIFO = dCostFifo;
                                                                        oUpdatedRecord.Update();
                                                                    }

                                                                    #endregion

                                                                    #region Update Inventory
                                                                    tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtGINID.Text.Trim(), dtpGINDate.Value, txtRemark.Text.Trim(),
                                                                        txtCustomerID.Tag.ToString(), txtSupplierID.Tag.ToString(), "default", -1, 0,
                                                                        "", "", "", "", false, clsSecurity.UserIDLoged);

                                                                    clsHelpMethods.Update_Inventory(oHeader, oListInventory);
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

                                                #region Insert EGIN
                                                else
                                                {
                                                    if (rdoSampleIssued.Checked)
                                                        txtGINID.Text = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.SampleIssued));
                                                    else
                                                    {
                                                        if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                                            txtGINID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);
                                                    }
                                                    //create order ref number
                                                    if (glbOrderRefNo.Length <= 0 || glbOrderRefNo == "default")
                                                    {
                                                        glbOrderRefNo = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.zIssuedRefNo));
                                                        tbl_zIssuedRefNo orf = new tbl_zIssuedRefNo(glbOrderRefNo, txtSupplierRefNo.Text != "" ? txtSupplierRefNo.Text.Trim() : "-");
                                                        orf.Insert();
                                                    }

                                                    if (clsValidate.CheckValidity_TransactionCodeLength(txtGINID.Text)) //if (txtGINID.Text.Trim().Length > 0)
                                                    {
                                                        List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();
                                                        
                                                        #region Insert Header
                                                        tbl_scsExternalGoodIssueNote EGIN = new tbl_scsExternalGoodIssueNote(txtGINID.Text.Trim(), dtpGINDate.Value, txtRemark.Text.Trim(), getReciverName(), glbOrderRefNo, txtStoreID.Tag.ToString(),
                                                            txtSupplierID.Tag.ToString(), txtDepartmentID.Tag.ToString(), txtCustomerID.Tag.ToString(), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default",
                                                            clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, bHasChecked, bHasApproved, false, false, false, 0, false, 0, rdoSupplier.Checked, rdoDepartment.Checked, rdoOther.Checked,
                                                            rdoCustomer.Checked, !chkUnitPricing.Checked, rdoSampleIssued.Checked, clsSecurity.CompanyID, clsSecurity.BranchID);
                                                        EGIN.Insert();
                                                        #endregion
                                                        
                                                        #region Insert Detail
                                                        foreach (DataGridViewRow row in dgvDetail.Rows)
                                                        {
                                                            #region Intialize Variables and Set Grid Values then Pass Values to Object
                                                            string sJobCode = "default", sItemCode = "", sItemSubCategoryID1 = "", sItemSubCategoryID2 = "", sItemSerialNo1 = "", sItemSerialNo2 = "", sPOID = "", sPRNID = "", sBatch = "", sUom = "", sRemarks = "";
                                                            decimal dQuantity = 0, dUnitPrice = 0, dWeight = 0, dAmount = 0, dWaranty = 0, dWeidhtPrice = 0;
                                                            int iLineNo = 0;

                                                            iLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, int.Parse("0"));
                                                            sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                                            sItemSubCategoryID1 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                                                            sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                                            sItemSerialNo1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                                                            sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                                            sPOID = clsValidate.ValidateGridValue(dgvDetail, "POID", row.Index, "default");
                                                            sPRNID = clsValidate.ValidateGridValue(dgvDetail, "PRNID", row.Index, "default");
                                                            sBatch = clsValidate.ValidateGridValue(dgvDetail, "Batch", row.Index, "");
                                                            sUom = clsValidate.ValidateGridValue(dgvDetail, "UOM", row.Index, "default");
                                                            dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                                            dUnitPrice = clsValidate.ValidateGridTag(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                                                            dWeidhtPrice = clsValidate.ValidateGridTag(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                                                            dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                                            dAmount = clsValidate.ValidateGridTag(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                                                            dWaranty = clsValidate.ValidateGridValue(dgvDetail, "Warranty", row.Index, decimal.Parse("0.00"));
                                                            sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, ""); 
                                                            
                                                            //Get Unit Price as weighted avarage cost
                                                            #region Get weight avarage cost as unit price
                                                            if (!chkUnitPricing.Checked)
                                                            {
                                                                dWeidhtPrice = clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemCode);
                                                                dAmount = dWeidhtPrice * dWeight;
                                                            }
                                                            else
                                                            {
                                                                dUnitPrice = clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemCode);
                                                                dAmount = dUnitPrice * dQuantity;
                                                            }
                                                            #endregion

                                                            tbl_scsExternalGoodIssueNote_Detail EGINdetail = new tbl_scsExternalGoodIssueNote_Detail(iLineNo, txtGINID.Text.Trim(), sItemCode, sItemSubCategoryID1,
                                                                sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, dQuantity, dWeight, dWeidhtPrice, dUnitPrice, 0, 0, dAmount, sRemarks, 0, clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemCode));
                                                            EGINdetail.Insert();
                                                            #endregion

                                                            #region Update Store Stock
                                                            decimal dWeightedAverageCostPrice = 0;
                                                            decimal dCostFifo = clsHelpMethods.UpdateStoreStock(iFormID, EGIN.ExternalGoodIssueNote_ID, EGIN.ExternalGoodIssueNoteDate, EGINdetail.Item_ID, "0", txtStoreID.Tag.ToString(), EGINdetail.Qty, EGINdetail.Weight, EGINdetail.TatalAmount, false, false, false, ref dWeightedAverageCostPrice);
                                                            EGINdetail.Cost_FIFO = dCostFifo;
                                                            EGINdetail.Update();
                                                            #endregion

                                                            #region Pass Value to Inventory Detail
                                                            tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, iLineNo, 0, txtGINID.Text.Trim(), dtpGINDate.Value,
                                                                                        "", "", "", "", txtCustomerID.Tag.ToString(), txtSupplierID.Tag.ToString(), txtStoreID.Tag.ToString(),
                                                                                        sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), 0, dQuantity, dUnitPrice, 0, false);
                                                            oListInventory.Add(oInventoryDetail);
                                                            #endregion
                                                        }
                                                        #endregion

                                                        Attachments.Insert(txtGINID.Text.ToString());

                                                        #region Update Inventory
                                                        tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtGINID.Text.Trim(), dtpGINDate.Value, txtRemark.Text.Trim(),
                                                            txtCustomerID.Tag.ToString(), txtSupplierID.Tag.ToString(), "default", -1, 0,
                                                            "", "", "", "", false, clsSecurity.UserIDLoged);

                                                        clsHelpMethods.Update_Inventory(oHeader, oListInventory);
                                                        #endregion

                                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                                    //else
                                                       // MessageBox.Show("GIN " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                #endregion
                                            }
                                            catch (Exception ex)
                                            {
                                                SEACCException.Show(ex);
                                                clsValidate.WriteErrorLog("", iFormID,ex);
                                            }
                                            finally
                                            {
                                                Cursor = Cursors.Default;
                                                tbl_scsExternalGoodIssueNote oldRecord = tbl_scsExternalGoodIssueNote.Select(txtGINID.Text.Trim());
                                                ClearFields();
                                                if (oldRecord != null)
                                                    FillDetails(oldRecord.ExternalGoodIssueNote_ID);
                                            }
                                        }
                                    }
                                }
                            }//Check Stock Validity
                        }//check grid empty 
                    }//check supplier save validity
                }//check number validity
            }//check validity
        }
        #endregion

        #region Btn Print
        private void frm_scsExternalGoodIssueNote_SF_printButton_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_scsExternalGoodIssueNote_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region Btn Add Item
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (txtItemID.Tag != null && txtItemID.Tag.ToString().Length > 0)
                RefreshGridByItemID(txtItemID.Tag.ToString());

        }
        #endregion

        #region Btn Temp
        private void frm_scsExternalGoodIssueNote_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtGINID.TextLength > 0 && txtGINID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtGINID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtSupplierRefNo, true);
                clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblIssuedRefNo, true);
                clsCommon.SetEnableDisable_NormalLabel(lblStoreID, true);

                txtGINID.Tag = null;
                dtpGINDate.Value = clsSecurity.getServerDateTime();

                EnableDesableAllReciver(true);

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Order Ref No
                txtSupplierRefNo.Tag = null;
                txtSupplierRefNo.Clear();

                //Reset Primary Key
                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtGINID.Text = "<Auto Generate>";
                else
                    txtGINID.Clear();
                if (txtGINID.Enabled)
                {
                    txtGINID.SelectAll();
                    txtGINID.Focus();
                }

                Attachments.Clear();
            }
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat_New(dgvDetail, clsFormatter.colorGrid, UI_Color);

            clsHelpMethods.FormatGrid_Stock_External(dgvDetail);

            if (clsConfig.bWrap_ItemGrid_ItemName)
            {
                this.dgvDetail.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            //Change Grid Headers
            dgvDetail.Columns["ItemSubCategoryID1"].HeaderText = clsConfig.sItemSubCategory;
            dgvDetail.Columns["ItemName"].Width = 420;
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
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            lblCancelled.Visible = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtGINID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtSupplierRefNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblIssuedRefNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblStoreID, true);

            if (clsConfig.bShow_GridViewColumn_Remarks)
                dgvDetail.Columns["Remarks"].Visible = true;
            else
                dgvDetail.Columns["Remarks"].Visible = false;

            txtGINID.Tag = null;
            txtItemID.Tag = null;
            txtStoreID.Tag = null;
            txtSupplierRefNo.Tag = null;
            txtItemSubCategory.Tag = null;
            txtItemSerialNo.Tag = null;

            clearReciver();
            EnableDesableAllReciver(true);
            dt_ItemGrouped.Clear();

            txtItemSubCategory.Clear();
            txtItemSerialNo.Clear();
            txtItemID.Clear();
            txtStoreID.Clear();
            glbOrderRefNo = "";
            txtRemark.Clear();
            txtSupplierRefNo.Clear();
            dtpGINDate.Value = clsSecurity.getServerDateTime();

            chkUnitPricing.Checked = true;
            chkReverseCalculation.Checked = false;
            chkReverseCalculation.Enabled = true;
            //chkSettings.Checked = true;
            chkShowSettle.Checked = false;
            rdoGeneralIssued.Checked = true;
            rdoSampleIssued.Checked = false;

            chkPrintOriginal.Checked = false;

            bHasApproved = false;
            bHasChecked = false;
            dgvDetail.Rows.Clear();

            userDetailsColorChanges();
            dtpGINDate.Enabled = !clsConfig.bLock_TransactionDate_SCS;

            rdoOther.Checked = true;

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtGINID.Text = "<Auto Generate>";
            else
                txtGINID.Clear();
            if (txtGINID.Enabled)
            {
                txtGINID.SelectAll();
                txtGINID.Focus();
            }

            Attachments.Clear();
        }
        #endregion

        #region Clear Reciver
        private void clearReciver()
        {
            txtDepartmentID.Tag = null;
            txtCustomerID.Tag = null;
            txtSupplierID.Tag = null;

            txtDepartmentID.Clear();
            txtCustomerID.Clear();
            txtSupplierID.Clear();
            txtOther.Clear();
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_scsExternalGoodIssueNote detail = tbl_scsExternalGoodIssueNote.Select(sID);
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

                            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtGINID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, false);
                        clsCommon.SetEnableDisable_NormalTextbox(txtSupplierRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblIssuedRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblStoreID, false);


                        //fill order detials
                        tbl_zIssuedRefNo Issued = tbl_zIssuedRefNo.Select(detail.IssuedRefNo_ID);
                        if (Issued != null)
                        {
                            txtSupplierRefNo.Tag = detail.IssuedRefNo_ID;
                            txtSupplierRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_IssuedRefNo(detail.IssuedRefNo_ID));
                        }

                        //asign values
                        txtStoreID.Tag = detail.Store_ID;
                        txtStoreID.Text = clsGenaralName.getName_Store(detail.Store_ID);
                        glbOrderRefNo = detail.IssuedRefNo_ID;

                        txtGINID.Text = detail.ExternalGoodIssueNote_ID;
                        dtpGINDate.Value = detail.ExternalGoodIssueNoteDate;
                        chkUnitPricing.Checked = !detail.IsWeightCalculation;
                        txtRemark.Text = detail.Remark;

                        //Assign Reciver
                        if (detail.IsForCustomer)
                        {
                            rdoCustomer.Checked = true;
                            txtCustomerID.Tag = detail.Customer_ID;
                            txtCustomerID.Text = clsGenaralName.getName_Customer(detail.Customer_ID);
                        }
                        if (detail.IsForDepartment)
                        {
                            rdoDepartment.Checked = true;
                            txtDepartmentID.Tag = detail.Department_ID;
                            txtDepartmentID.Text = clsGenaralName.getName_Department(detail.Department_ID);
                        }
                        if (detail.IsForSupplier)
                        {
                            rdoSupplier.Checked = true;
                            txtSupplierID.Tag = detail.Supplier_ID;
                            txtSupplierID.Text = clsGenaralName.getName_Supplier(detail.Supplier_ID);
                        }
                        if (detail.IsForOther)
                        {
                            rdoOther.Checked = true;
                            txtOther.Text = detail.ReceiverName;
                        }
                        rdoSampleIssued.Checked = detail.IsSampleIssued;
                        rdoGeneralIssued.Checked = !detail.IsSampleIssued;

                        EnableDesableAllReciver(false);

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
                        RefreshGrid(detail.ExternalGoodIssueNote_ID);

                        Attachments.FillAttachments(sID);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string sGrnID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();

                List<tbl_scsExternalGoodIssueNote_Detail> details = tbl_scsExternalGoodIssueNote_Detail.SelectAllByExternalGoodIssueNote_ID(sGrnID);
                foreach (tbl_scsExternalGoodIssueNote_Detail detail in details)
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (detail != null)
                    {
                        decimal dExRate = 0;
                        dExRate = clsCommon.getCurrencyRate(clsConfig.sLocalCurrencyCode);
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        Fill_Datagrid(iRow, detail.Line_No, detail.Item_ID, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, "default",
                            "default", "", item.IsTIEPItem, detail.Qty, detail.UnitPrice, detail.KiloPrice, detail.Weight, detail.TatalAmount, 0, detail.Remark, dExRate, "o");
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
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
                    decimal dExRate = 0;
                    dExRate = clsCommon.getCurrencyRate(clsConfig.sLocalCurrencyCode);
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    clsCommon.ValidateForeignKey(ref txtItemSubCategory);
                    clsCommon.ValidateForeignKey(ref txtItemSerialNo, "0");

                    var maxLineNo = dgvDetail.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["LineNo"].Value));
                    Fill_Datagrid(iRow, maxLineNo + 1, detail.Item_ID, txtItemSubCategory.Tag.ToString(), txtItemSubCategory.Text.Trim(), txtItemSerialNo.Tag.ToString(), txtItemSerialNo.Text.Trim(),
                        "default", "default", "", detail.IsTIEPItem, 0, oItemF.SellingPrice1, oItemF.SellingPrice6, 0, 0, 0, detail.Description, dExRate, "n");
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }
        #endregion

        #region Events KeyDown
        private void txtInvoiceID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_ExternalGoodIssuedNoteID();
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
                SendKeys.Send("{TAB}");
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
        private void txtDepartmentID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Department();
        }

        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Customer();
        }

        private void txtSupplierID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Supplier();
        }
        #endregion

        #region Events Double Click
        private void txtInvoiceID_DoubleClick(object sender, EventArgs e)
        {
            Search_ExternalGoodIssuedNoteID();
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
        private void txtDepartmentID_DoubleClick(object sender, EventArgs e)
        {
            Search_Department();
        }

        private void txtCustomerID_DoubleClick(object sender, EventArgs e)
        {
            Search_Customer();
        }

        private void txtSupplierID_DoubleClick(object sender, EventArgs e)
        {
            Search_Supplier();
        }
        #endregion

        #region Events CheckedChanged
        private void chkSettings_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void chkUnitPricing_CheckedChanged(object sender, EventArgs e)
        {
            CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);

            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                DataGridViewCellEventArgs ar = new DataGridViewCellEventArgs(0, row.Index);
                dgvDetail_CellEndEdit(sender, ar);
            }
        }

        private void rdoDepartment_CheckedChanged(object sender, EventArgs e)
        {
            EnableReciver();
        }

        private void rdoCustomer_CheckedChanged(object sender, EventArgs e)
        {
            EnableReciver();
        }

        private void rdoSupplier_CheckedChanged(object sender, EventArgs e)
        {
            EnableReciver();
        }

        private void rdoOther_CheckedChanged(object sender, EventArgs e)
        {
            EnableReciver();
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
        #endregion

        #region Search Methods
        private void Search_ExternalGoodIssuedNoteID()
        {
            clsSearch.Search_TransactionExternalGoodIssuedNote_Direct(ref txtGINID, chkShowSettle.Checked);
            if (txtGINID.Tag != null && txtGINID.Tag.ToString().Trim().Length > 0)
                FillDetails(txtGINID.Tag.ToString());
        }
        private void Search_Item()
        {
            if (txtStoreID.Tag != null && txtStoreID.Tag.ToString() != "default")
            {
                string sStoreID = "", sSectionID = "", sDepartmentID = "";
                if (txtStoreID.Tag != null && txtStoreID.Tag.ToString().Trim().Length > 0)
                    sStoreID = txtStoreID.Tag.ToString();

                clsHelpMethods.SearchItemAdvanceStock(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo, sStoreID, sSectionID, sDepartmentID);
                if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                    btnAddItem_Click(btnAddItem, new EventArgs());
            }
            else
            {
                MessageBox.Show("Please seclect store first!!!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStoreID.Focus();
            }
        }
        private void Search_Department()
        {
            clsSearch.Search_MasterDepartment(ref txtDepartmentID);
        }
        private void Search_Customer()
        {
            clsSearch.Search_MasterCustomer(ref txtCustomerID, false);
        }
        private void Search_Supplier()
        {
            clsSearch.Search_MasterSupplier(ref txtSupplierID);
        }
        private void Search_Store()
        {
            clsSearch.Search_MasterStore(ref txtStoreID, true);
        }
        #endregion

        #region Check Validity
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtStoreID, "Store Name"))
            {

                if (rdoDepartment.Checked)
                {
                    if (clsValidate.ValidateTextBox_EmptyValue(txtDepartmentID, "Department"))
                        bStatus = true;
                }
                if (rdoCustomer.Checked)
                {
                    if (clsValidate.ValidateTextBox_EmptyValue(txtCustomerID, "Customer"))
                        bStatus = true;
                }
                if (rdoSupplier.Checked)
                {
                    if (clsValidate.ValidateTextBox_EmptyValue(txtSupplierID, "Supplier"))
                    { bStatus = true; }
                }
                if (rdoOther.Checked)
                {
                    if (clsValidate.ValidateTextBox_EmptyValue(txtOther, "Other"))
                        bStatus = true;
                }
            }

            return bStatus;
        }

        private bool CheckSupplierSaveValidity()
        {
            bool rtn = true;
            if (rdoSupplier.Checked)
            {
                if (txtSupplierID.Tag != null)
                {
                    if (clsValidate.isSupplierBlackListed(txtSupplierID.Tag.ToString()))
                        rtn = false;
                    else if (clsValidate.isSupplierSuspended(txtSupplierID.Tag.ToString()))
                        rtn = false;
                }
            }
            return rtn;
        }

        private bool CheckNumberValidity()
        {
            // string strMessage = "";
            bool bStatus = true;

            return bStatus;
        }

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
                    sItemSubCategoryID = clsValidate.ValidateRowValue(row, "ItemSubCategoryID1", "default");
                    sItemSubCategoryID2 = clsValidate.ValidateRowValue(row, "ItemSubCategoryID2", "default");
                    sItemSerialNo = clsValidate.ValidateRowValue(row, "ItemSerialNo", "0");
                    sItemSerialNo2 = clsValidate.ValidateRowValue(row, "ItemSerialNo2", "0");

                    if (!clsHelpMethods.IsNonInventoryItem(sItemCode))
                    {
                        tbl_genStore_Stock oStoreStock;
                        oStoreStock = oStoreStock = tbl_genStore_Stock.Select(txtStoreID.Tag.ToString(), sItemCode, sJobCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
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
                                foreach (tbl_scsExternalGoodIssueNote_Detail oGINDetail in tbl_scsExternalGoodIssueNote_Detail.SelectAllByExternalGoodIssueNote_ID(txtGINID.Text.Trim()).Where(p => p.Item_ID == sItemCode && p.ItemSubCategory_ID == sItemSubCategoryID && p.ItemSubCategory2_ID == sItemSubCategoryID2))
                                {
                                    dOldQty += oGINDetail.Qty;
                                    dOldWeight += oGINDetail.Weight;
                                }

                                #region Old Items Quantity Validation
                                if (clsConfig.bStockValidateQty_eGIN)
                                {
                                    if (oStoreStock.Qty + dOldQty < dQty)
                                    {
                                        strMessage += "Required Quantity of Item: \"" + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\" is not Availabe in  store :\"" + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\"\n";
                                        bStatus = false;
                                    }
                                }
                                #endregion

                                #region Old Items Weight Validation
                                if (clsConfig.bStockValidateWeight_eGIN)
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
                                        strMessage += "Minus Quantities are not allowed - " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\"" + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\"\n";
                                        bStatus = false;
                                    }
                                }
                            }
                            #endregion
                            #region first time added item ant have to check stock
                            else
                            {
                                #region Weight Validation
                                if (oStoreStock.Weight < dWeight && clsConfig.bStockValidateWeight_eGIN)
                                {
                                    strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + " Required Weight Is Not Availabe As IT Is In  " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                                    bStatus = false;
                                }
                                #endregion

                                #region New Item Quantity Validation
                                if (oStoreStock.Qty < dQty && clsConfig.bStockValidateQty_eGIN)
                                {
                                    strMessage += " Required Quantity of Item: \"" + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\" is not Availabe in store :\"" + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\"\n";
                                    bStatus = false;
                                }
                                #endregion

                                if (!oStore.IsAllowMinusStock)
                                {
                                    if (oStoreStock.Qty - dQty < 0)
                                    {
                                        strMessage += "Minus Quantities are not allowed - " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\"" + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\"\n";
                                        bStatus = false;
                                    }
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            if ((clsConfig.bStockValidateQty_eGIN || clsConfig.bStockValidateWeight_eGIN) && !clsHelpMethods.IsNonInventoryItem(sItemCode) && (clsConfig.sSoftwareModel.Trim() != SoftwareModel_Sales.akt.ToString()))
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
                clsValidate.WriteErrorLog("", iFormID,ex);
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
                clsCommon.ValidateForeignKey(ref txtDepartmentID);
                clsCommon.ValidateForeignKey(ref txtSupplierID);
                clsCommon.ValidateForeignKey(ref txtCustomerID);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Datagrid
        private void Fill_Datagrid(int iRow, int iLineNo, string ItemID, string ItemSubCategoryID1, string ItemSubCategoryID2, string ItemSerialNo1, string ItemSerialNo2, string PurchaseOrderID, string sPRNID, string sBatch, bool bIsTiep, decimal Quantity, decimal UnitPrice, decimal WeightPrice, decimal Weight,
        decimal Amount, decimal dWarranty, string Remark, decimal dExRate, string sItemStatus)
        {
            try
            {
                decimal WeightAvg = 0;
                clsHelpMethods.AddMultipleItems_Grid(dgvDetail, ItemID, ref iRow, ref iLineNo, ref Quantity, ref UnitPrice, ref Weight, ref WeightAvg);

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
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Get Reciver Name
        private string getReciverName()
        {
            string rtn = "";
            if (rdoCustomer.Checked)
                rtn = clsGenaralName.getName_Customer(txtCustomerID.Tag.ToString());
            if (rdoSupplier.Checked)
                rtn = clsGenaralName.getName_Supplier(txtSupplierID.Tag.ToString());
            if (rdoDepartment.Checked)
                rtn = clsGenaralName.getName_Department(txtDepartmentID.Tag.ToString());
            if (rdoOther.Checked)
                rtn = txtOther.Text.Trim();
            return rtn;
        }
        #endregion

        #region Print Method
        private void Print(bool bIsDraft)
        {
            try
            {
                if (txtGINID.TextLength > 0 && txtGINID.Text != "<Auto Generate>")
                {
                    //update receipt
                    string sCreateUser = "", sCheckedUser = "", sApprovedUser = "", sDuplicate = "";
                    bool bZeroQtyValidate = true;

                    bool bPermissinOkToPrint = true;
                    if (chkPrintOriginal.Checked)
                        bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_eGIN));
                    if (bPermissinOkToPrint)
                    {
                        tbl_scsExternalGoodIssueNote oGIN = tbl_scsExternalGoodIssueNote.Select(txtGINID.Text.Trim());
                    if (oGIN != null && oGIN.ExternalGoodIssueNote_ID != "default")
                    {
                        #region Item Zero Quentity Validity
                        if (clsConfig.bIsEnableZeroItemQuentityValidate_GIN)
                        {
                            bool bZeroQtyItemAvailable = false;
                            foreach (DataGridViewRow row in dgvDetail.Rows)
                            {
                                decimal dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                decimal dQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                if (oGIN.IsWeightCalculation)
                                {
                                    if (dWeight <= 0)
                                    {
                                        bZeroQtyItemAvailable = true;
                                        break;
                                    }
                                }
                                else
                                {
                                    if (dQty <= 0)
                                    {
                                        bZeroQtyItemAvailable = true;
                                        break;
                                    }
                                }
                            }

                            if (bZeroQtyItemAvailable)
                            {
                                if (!oGIN.IsApproved)
                                {
                                    bZeroQtyValidate = false;
                                    MessageBox.Show("Please Approve the Document, In Order to Print Zero Item(s) Quentity Goods Issue Note", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        #endregion

                        #region Print Doc
                        if (bZeroQtyValidate)
                        {
                                if (!bIsDraft)
                                {
                                    //sDuplicate = oGIN.PrintCount > 0 ? "Duplicate Copy " + oGIN.PrintCount : "";

                                    if (!chkPrintOriginal.Checked)
                                        sDuplicate = (oGIN.PrintCount > 0) ? "Duplicate Copy " + oGIN.PrintCount : "";

                                    oGIN.PrintCount++;
                                    oGIN.Update();
                                }

                            if (oGIN.IsDeleted)
                                sDuplicate = "";

                            sCreateUser = "[ " + clsGenaralName.getName_User(oGIN.CreateUser_ID) + " ] [ " + oGIN.DateCreate.ToShortDateString() + " ]";
                            if (oGIN.CheckedUser_ID != "default")
                                sCheckedUser = "[ " + clsGenaralName.getName_User(oGIN.CheckedUser_ID) + " ] [ " + oGIN.DateChecked.ToShortDateString() + " ]";
                            if (oGIN.ApprovedUser_ID != "default")
                                sApprovedUser = "[ " + clsGenaralName.getName_User(oGIN.ApprovedUser_ID) + " ] [ " + oGIN.DateApproved.ToShortDateString() + " ]";

                            if (clsConfig.bDataSetActive_GIN)
                            {
                                #region DataSet
                                glb_dtsscsExternalGoodIssueNote.Clear();

                                #region GIN Header
                                glb_dtsscsExternalGoodIssueNote.dt_scsExternalGoodsIssueNote.Adddt_scsExternalGoodsIssueNoteRow(oGIN.ExternalGoodIssueNote_ID, oGIN.ExternalGoodIssueNoteDate, oGIN.ReceiverName,
                                    clsGenaralName.getName_OrderRefNo(oGIN.IssuedRefNo_ID), oGIN.Store_ID, clsGenaralName.getName_Store(oGIN.Store_ID), oGIN.Remark, oGIN.IsWeightCalculation, oGIN.IsDeleted, clsGenaralName.getName_User(oGIN.CreateUser_ID));

                                #endregion

                                #region GIN Detail
                                List<tbl_scsExternalGoodIssueNote_Detail> oGINDetails = tbl_scsExternalGoodIssueNote_Detail.SelectAllByExternalGoodIssueNote_ID(oGIN.ExternalGoodIssueNote_ID);
                                foreach (tbl_scsExternalGoodIssueNote_Detail detail in oGINDetails.OrderBy(p => p.Line_No))
                                {
                                    glb_dtsscsExternalGoodIssueNote.dt_scsExternalGoodsIssueNoteDetail.Adddt_scsExternalGoodsIssueNoteDetailRow(detail.ExternalGoodIssueNote_ID, detail.Item_ID,
                                        clsGenaralName.getName_Item(detail.Item_ID), detail.Qty, detail.Weight, detail.KiloPrice, detail.Remark);

                                }
                                #endregion

                                #region Report Export Parameters
                                string sSample = rdoSampleIssued.Checked ? "SAMPLE" : "";

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", clsCommon.getCompanyEmail(), true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicate, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsSample", sSample, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUser, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sCheckedUser, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUser, true,false);
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

                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", "", true,false);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", "", true,false);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", "", true,false);

                                    }
                                }
                                glb_dtsscsExternalGoodIssueNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, "External Goods Issued Note", "", "", clsSecurity.UserNameLoged, "");
                                #endregion

                                #region Set Report Path and Datasets
                                frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                string sGetRptPath = clsHelpMethods.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_eGIN));
                                rpt.print(sGetRptPath, glb_dtsscsExternalGoodIssueNote, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_eGIN));
                                #endregion
                                #endregion
                            }
                            else
                            {
                                #region View
                                Cursor = Cursors.WaitCursor;
                                string s_Path = "", sReportTitle = "External Goods Issued Note", sFormula = ""; string isRemark = "";
                                if (txtGINID.TextLength > 0)
                                    sFormula = "{vw_rpt_scsExternalGoodIssuedNote.externalGoodIssueNote_ID}= '" + txtGINID.Text.Trim() + "'";

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

                                string sGetRptPath = clsHelpMethods.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_eGIN));
                                if (sGetRptPath != null && sGetRptPath.Length > 0)
                                    s_Path += sGetRptPath;
                                else
                                {
                                    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                                        s_Path += "\\Reports\\SCS\\NotePrinting\\rpt_sasExtranalGoodIssueeNote_WSC.rpt";
                                    else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ceilingAndWallPanal.ToString())
                                        s_Path += "\\Reports\\SCS\\NotePrinting\\rpt_sasExtranalGoodIssueeNote_ITC.rpt";
                                    else
                                        s_Path += "\\Reports\\SCS\\NotePrinting\\rpt_sasExtranalGoodIssueeNote.rpt";
                                }

                                frm_ReportViewer viewer = new frm_ReportViewer();
                                RD.Load(s_Path);
                                clsSecurity.LogonServer(ref RD);
                                RD.Refresh();

                                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())// && !chkPrintWithAmounts.Checked && !chkPrintWithBreakdown.Checked)
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
                                RD.DataDefinition.FormulaFields["TelphoneFax"].Text = clsCommon.fncsetstring(clsCommon.getSupplerTelephoneAndFax(oGIN.Supplier_ID));

                                string sSample = rdoSampleIssued.Checked ? "SAMPLE" : "";

                                RD.DataDefinition.FormulaFields["IsSample"].Text = clsCommon.fncsetstring(sSample);
                                RD.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring(sDuplicate);
                                RD.DataDefinition.FormulaFields["isDraft"].Text = bIsDraft ? clsCommon.fncsetstring("DRAFT") : "";

                                if (bIsDraft)
                                {
                                    if (!clsConfig.isVisibleCompanyInfoInDraftPrint)
                                    {
                                        RD.DataDefinition.FormulaFields["CompanyName"].Text = "";
                                        RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = "";
                                        RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = "";
                                        RD.DataDefinition.FormulaFields["CompanyEmail"].Text = "";
                                        RD.DataDefinition.FormulaFields["TelphoneFax"].Text = "";
                                    }
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
                                #endregion
                            }
                        }
                        #endregion
                    }
                }
                }
                else
                    MessageBox.Show("Please Select the GIN To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        private void frm_scsExternalGoodIssueNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            Attachments.Close();
        }

        #region User Checked Approve Details
        private void frm_scsExternalGoodIssueNote_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }
        private void frm_scsExternalGoodIssueNote_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpGINDate.Value.Date))
                {
                    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtGINID.Text != null && txtGINID.TextLength > 0 && txtGINID.Text != "<Auto Generate>")
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

                                        tbl_scsExternalGoodIssueNote objGIN = tbl_scsExternalGoodIssueNote.Select(txtGINID.Text.Trim());
                                        if (objGIN != null)
                                        {
                                            objGIN.IsApproved = true;
                                            objGIN.DateApproved = clsSecurity.getServerDateTime();
                                            objGIN.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                            objGIN.Update();
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
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CheckedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpGINDate.Value.Date))
                {
                    if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtGINID.Text != null && txtGINID.TextLength > 0 && txtGINID.Text != "<Auto Generate>")
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

                                        tbl_scsExternalGoodIssueNote objGIN = tbl_scsExternalGoodIssueNote.Select(txtGINID.Text.Trim());
                                        if (objGIN != null)
                                        {
                                            objGIN.IsChecked = true;
                                            objGIN.DateChecked = clsSecurity.getServerDateTime();
                                            objGIN.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objGIN.Update();
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
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion
        private void frm_scsExternalGoodIssueNote_SF_History_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGINID.Text != "" || txtGINID.Text != "<Auto Generate>")
                {
                    tbl_scsExternalGoodIssueNote detail = tbl_scsExternalGoodIssueNote.Select(txtGINID.Text.Trim());
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
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

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