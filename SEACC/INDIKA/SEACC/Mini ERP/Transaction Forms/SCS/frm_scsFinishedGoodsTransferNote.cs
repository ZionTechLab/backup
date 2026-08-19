using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using SEACC.DATA.Data.SCS;

namespace Digiteq
{
    public partial class frm_scsStoreProduction : SEACC_Form
    {
        #region Variables
      
        public string glbOrderRefNo = "", glbInquiryID = "", glbFGTNID = "", glbCustomerOrderID = "";

        InventoryTxnData oData = new InventoryTxnData();
        #endregion

        #region Form Load
        public frm_scsStoreProduction(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }

        private void frm_scsStoreProduction_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);
            clsFill.Fill_ItemPrices(ref cmbItemPrice);
            CusDataGridViewFormat();

            ClearFields();

            if (glbFGTNID.Length > 0)
                FillDetails(glbFGTNID);
        }
        #endregion

        #region btn new

        private void frm_scsStoreProduction_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region btn delete

        private void frm_scsStoreProduction_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProductID.Text.Trim().Length > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpFGTNDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreName.Tag.ToString(), IsUpdate))
                            {
                                //delete one record
                                Cursor = Cursors.WaitCursor;
                                tbl_scsStoreProduction detail = tbl_scsStoreProduction.Select(txtProductID.Text.Trim());
                                if (detail != null)
                                {
                                    if (!detail.IsDeleted)
                                    {
                                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " Production ID : " + detail.StoreProduction_ID), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                        if (msgResult == DialogResult.Yes)
                                        {
                                            foreach (tbl_scsStoreProduction_Detail oItem in tbl_scsStoreProduction_Detail.SelectAllByStoreProduction_ID(detail.StoreProduction_ID).Where(p => p.Item_ID != "default"))
                                            {
                                                #region Update Store Stock
                                                decimal dWeightedAverageCostPrice = 0;
                                            //    clsHelpMethods_Local.UpdateStoreStock(iFormID, oItem.StoreProduction_ID, detail.StoreProductionDate, oItem.Item_ID, "0", txtStoreName.Tag.ToString(), oItem.Qty, oItem.Weight, oItem.TotalAmount, true, true, true, ref dWeightedAverageCostPrice);
                                                oItem.WeightedAvgCost = dWeightedAverageCostPrice;
                                                oItem.Update();
                                                #endregion
                                            }

                                            detail.IsDeleted = true;
                                            detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                            detail.DateModified = clsSecurity.getServerDateTime();
                                            detail.Update();


                                            var responce = oData.Delete_InventoryTxn(iFormID, txtProductID.Text.Trim());
                                            if (!responce.IsSuccess)
                                            {
                                                clsValidate.WriteErrorLog(txtProductID.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
                                            }


                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            ClearFields();
                                        }
                                    }
                                    else
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyDeleted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        #region btn Save
        private void frm_scsStoreProduction_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity_EmptyField())
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpFGTNDate.Value.Date))
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                    {
                        if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreName.Tag.ToString(), IsUpdate))
                        {
                            try
                            {
                                Cursor = Cursors.WaitCursor;
                                ValidateEmptyForeignKey();

                                #region update
                                if (IsUpdate)
                                {

                                    if (txtProductID.Tag != null && txtProductID.Tag.ToString().Trim().Length > 0)
                                    {
                                        tbl_scsStoreProduction oldRecord = tbl_scsStoreProduction.Select(txtProductID.Tag.ToString().Trim());
                                        if (oldRecord != null)
                                        {
                                            if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished &&
                                                !oldRecord.IsDeleted &&
                                                clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                                            {
                                                if (clsValidate.CheckValidity_TransactionCodeLength(txtProductID.Text))
                                                {
                                                    #region Rollback Store Stock

                                                    foreach (tbl_scsStoreProduction_Detail oUpdatedRecord in tbl_scsStoreProduction_Detail.SelectAllByStoreProduction_ID(
                                                            txtProductID.Tag.ToString().Trim()))
                                                    {
                                                    decimal dWeightedAverageCostPrice = 0;

                                                        //clsHelpMethods_Local.UpdateStoreStock(iFormID,
                                                        //    oldRecord.StoreProduction_ID, oldRecord.StoreProductionDate,
                                                        //    oUpdatedRecord.Item_ID, "0", txtStoreName.Tag.ToString(),
                                                        //    oUpdatedRecord.Qty, oUpdatedRecord.Weight,
                                                        //    oUpdatedRecord.TotalAmount, true, true, true, ref dWeightedAverageCostPrice);

                                                        oUpdatedRecord.WeightedAvgCost = dWeightedAverageCostPrice;
                                                        oUpdatedRecord.Update();
                                                    }

                                                    #endregion

                                                    #region Remove Old Items                                                    
                                                    List<tbl_scsStoreProduction_Detail> oldCoDetails = tbl_scsStoreProduction_Detail.SelectAllByStoreProduction_ID(txtProductID.Text.Trim());
                                                    foreach (tbl_scsStoreProduction_Detail oldCoDetail in oldCoDetails)
                                                    {
                                                        int iLineNo = 0;
                                                        string itemCode = "", ItemCategory = "", ItemSubCategory2_ID = "", ItemSerialNO = "", ItemSerialNO2 = "", UMO = "";
                                                        decimal Qty = 0, Weight = 0, WeightWestage = 0, WeightRejection = 0;
                                                        bool bHasItemInDB = false;
                                                        foreach (DataGridViewRow row in dgvDetail.Rows)
                                                        {
                                                            iLineNo = clsValidate.ValidateGridValue(dgvDetail, "Lineno",
                                                            row.Index, 0);
                                                            itemCode = clsValidate.ValidateGridValue(dgvDetail,
                                                                "ItemCode", row.Index, "");
                                                            ItemCategory = clsValidate.ValidateGridTag(dgvDetail,
                                                                "Subcategory", row.Index, "default");
                                                            ItemSubCategory2_ID = clsValidate.ValidateGridTag(dgvDetail,
                                                                "ItemSubCategory2_ID", row.Index, "default");
                                                            ItemSerialNO = clsValidate.ValidateGridTag(dgvDetail,
                                                                "ItemSerialNo", row.Index, "0");
                                                            ItemSerialNO2 = clsValidate.ValidateGridTag(dgvDetail,
                                                                "ItemSerialNo2", row.Index, "0");
                                                            UMO = clsValidate.ValidateGridValue(dgvDetail, "UOM",
                                                                row.Index, "default");
                                                            Qty = clsValidate.ValidateGridValue(dgvDetail, "QTY",
                                                                row.Index, decimal.Parse("0.00"));
                                                            Weight = clsValidate.ValidateGridValue(dgvDetail, "Weight",
                                                                row.Index, decimal.Parse("0.00"));
                                                            WeightWestage = clsValidate.ValidateGridValue(dgvDetail,
                                                                "WeightWestage", row.Index, decimal.Parse("0.00"));
                                                            WeightRejection = clsValidate.ValidateGridValue(dgvDetail,
                                                                "WeightRejection", row.Index, decimal.Parse("0.00"));

                                                            if (oldCoDetail.StoreProduction_ID ==
                                                                txtProductID.Tag.ToString() &&
                                                                oldCoDetail.Item_ID == itemCode &&
                                                                oldCoDetail.ItemSubCategory_ID == ItemCategory &&
                                                                oldCoDetail.ItemSubCategory2_ID ==
                                                                ItemSubCategory2_ID &&
                                                                oldCoDetail.ItemSerialNo == ItemSerialNO &&
                                                                oldCoDetail.ItemSerialNo2 == ItemSerialNO2)
                                                            {
                                                                bHasItemInDB = true;
                                                                dgvDetail.Rows.RemoveAt(row.Index);
                                                                break;
                                                            }

                                                        }

                                                        if (bHasItemInDB)
                                                        {
                                                            ////Update Store Stock
                                                            bool bConfigurationOK =
                                                                (clsConfig.bFGTN_StockUpdate_NeedChecking)
                                                                    ? bHasChecked
                                                                    : true;
                                                            if (bConfigurationOK)
                                                            {
                                                                //    clsHelpMethods_Local.UpdateOrInsertStoreStock(true, true, itemCode, ItemCategory, ItemSubCategory2_ID, "0", "0", "default", txtStoreName.Tag.ToString(), Qty, Weight, oldCoDetail.Qty, oldCoDetail.Weight, true, true, true);
                                                            }

                                                            oldCoDetail.Item_ID = itemCode;
                                                            oldCoDetail.ItemSubCategory_ID = ItemCategory;
                                                            oldCoDetail.ItemSubCategory2_ID = ItemSubCategory2_ID;
                                                            oldCoDetail.ItemSerialNo = ItemSerialNO;
                                                            oldCoDetail.ItemSerialNo2 = ItemSerialNO2;
                                                            oldCoDetail.Uom_ID = UMO;
                                                            oldCoDetail.Qty = Qty;
                                                            oldCoDetail.Weight = Weight;
                                                            oldCoDetail.WeightDamaged = WeightWestage;
                                                            oldCoDetail.WeightRejection = WeightRejection;

                                                            oldCoDetail.Update();

                                                            #region Pass Value to Inventory Detail
                                                            //tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, iLineNo, 0, txtProductID.Text.Trim(), dtpFGTNDate.Value,
                                                            //                            "", "", "", "", "default", "default", txtStoreName.Tag.ToString(),
                                                            //                            itemCode, clsGenaralName.getName_ItemUOMID(itemCode), Qty, 0, 0, 0, false);
                                                            //oListInventory.Add(oInventoryDetail);
                                                            #endregion
                                                        }
                                                        else
                                                        {
                                                            ////Update Store Stock
                                                            bool bConfigurationOK =
                                                                (clsConfig.bFGTN_StockUpdate_NeedChecking)
                                                                    ? bHasChecked
                                                                    : true;
                                                            if (bConfigurationOK)
                                                            {
                                                                //      clsHelpMethods_Local.UpdateOrInsertStoreStock(true, true, oldCoDetail.Item_ID, oldCoDetail.ItemSubCategory_ID, oldCoDetail.ItemSubCategory2_ID, oldCoDetail.ItemSerialNo, oldCoDetail.ItemSerialNo2, "default", txtStoreName.Tag.ToString(), oldCoDetail.Qty, oldCoDetail.Weight, 0, 0, false, false, true);
                                                            }

                                                            oldCoDetail.Delete();
                                                        }

                                                    }


                                                    #endregion

                                                    #region Update New Items
                                                    foreach (DataGridViewRow row in dgvDetail.Rows)
                                                    {
                                                        #region Variables

                                                        int iLineNo;
                                                        string itemCode = "",
                                                            ItemName = "",
                                                            ItemCategory = "",
                                                            ItemSubCategory2_ID = "",
                                                            Remark = "",
                                                            UMO = "";
                                                        decimal Qty = 0,
                                                            Weight = 0,
                                                            WeightWestage = 0,
                                                            WeightRejection = 0,
                                                            dUnitPrice = 0,
                                                            dWeightPrice = 0,
                                                            dTotalAmount = 0;

                                                        #endregion

                                                        #region Grid Validation

                                                        iLineNo = clsValidate.ValidateGridValue(dgvDetail, "Lineno",
                                                            row.Index, 0);
                                                        itemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode",
                                                            row.Index, "");
                                                        ItemName = clsValidate.ValidateGridValue(dgvDetail, "ItemName",
                                                            row.Index, "default");
                                                        ItemCategory = clsValidate.ValidateGridTag(dgvDetail,
                                                            "Subcategory", row.Index, "default");
                                                        ItemSubCategory2_ID = clsValidate.ValidateGridTag(dgvDetail,
                                                            "ItemSubCategory2_ID", row.Index, "default");
                                                        Remark = clsValidate.ValidateGridValue(dgvDetail, "Remark",
                                                            row.Index, "default");
                                                        UMO = clsValidate.ValidateGridValue(dgvDetail, "UOM", row.Index,
                                                            "default");
                                                        Qty = clsValidate.ValidateGridValue(dgvDetail, "QTY", row.Index,
                                                            decimal.Parse("0.00"));
                                                        Weight = clsValidate.ValidateGridValue(dgvDetail, "Weight",
                                                            row.Index, decimal.Parse("0.00"));
                                                        WeightWestage = clsValidate.ValidateGridValue(dgvDetail,
                                                            "WeightWestage", row.Index, decimal.Parse("0.00"));
                                                        WeightRejection = clsValidate.ValidateGridValue(dgvDetail,
                                                            "WeightRejection", row.Index, decimal.Parse("0.00"));
                                                        dUnitPrice = clsValidate.ValidateGridValue(dgvDetail,
                                                            "gUnitPrice", row.Index, decimal.Parse("0.00"));
                                                        //dWeight = clsValidate.ValidateGridValue(dgvDetail, "ItemUnitPrice", row.Index, decimal.Parse("0.00"));
                                                        dTotalAmount = clsValidate.ValidateGridValue(dgvDetail,
                                                            "gTotalAmount", row.Index, decimal.Parse("0.00"));

                                                        #endregion

                                                        #region Insert Details
                                                        if (itemCode.Length > 0)
                                                        {
                                                            tbl_scsStoreProduction_Detail detail =
                                                                new tbl_scsStoreProduction_Detail(iLineNo,
                                                                    txtProductID.Tag.ToString(), itemCode, ItemCategory,
                                                                    ItemSubCategory2_ID,
                                                                    "0", "0", UMO, Qty, Weight, WeightWestage,
                                                                    WeightRejection, Remark, true, dUnitPrice,
                                                                    dWeightPrice, dTotalAmount, 0);
                                                            detail.Insert();

                                                            ////Update Store Stock
                                                            bool bConfigurationOK =
                                                                (clsConfig.bFGTN_StockUpdate_NeedChecking)
                                                                    ? bHasChecked
                                                                    : true;
                                                            if (bConfigurationOK)
                                                            {
                                                                //     clsHelpMethods_Local.UpdateOrInsertStoreStock(true, true, itemCode, ItemCategory, ItemSubCategory2_ID, "0", "0", "default", txtStoreName.Tag.ToString(), Qty, Weight, 0, 0, false, true, true);
                                                            }

                                                            #region Pass Value to Inventory Detail
                                                            //tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, iLineNo, 0, txtProductID.Text.Trim(), dtpFGTNDate.Value,
                                                            //                            "", "", "", "", "default", "default", txtStoreName.Tag.ToString(),
                                                            //                            itemCode, clsGenaralName.getName_ItemUOMID(itemCode), Qty, 0, 0, 0, false);
                                                            //oListInventory.Add(oInventoryDetail);
                                                            #endregion
                                                        }
                                                        #endregion
                                                    }
                                                    #endregion

                                                    #region Update Header

                                                    tbl_scsStoreProduction SProduct = new tbl_scsStoreProduction(
                                                        txtProductID.Tag.ToString(), dtpFGTNDate.Value, txtRemark.Text,
                                                        txtJobCode.Tag.ToString(), txtStoreName.Tag.ToString(),
                                                        clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                                        oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID,
                                                        clsSecurity.getServerDateTime(),
                                                        clsSecurity.getServerDateTime(), glbCheckedDate,
                                                        glbApprovedDate, bHasChecked,
                                                        bHasApproved, oldRecord.IsFinished, oldRecord.IsDeleted,
                                                        oldRecord.IsLocked, oldRecord.PrintCount,
                                                        ((ComboBoxItem)cmbItemPrice.SelectedItem).Value,
                                                        oldRecord.CompanyID, oldRecord.CompanyBranch_ID);
                                                    SProduct.Update();

                                                    #endregion

                                                    #region Update Store Stock

                                                    foreach (tbl_scsStoreProduction_Detail oUpdatedRecord in
                                                        tbl_scsStoreProduction_Detail.SelectAllByStoreProduction_ID(
                                                            txtProductID.Tag.ToString().Trim()))
                                                    {
                                                        decimal dWeightedAverageCostPrice = 0;

                                                        //  decimal dCostFifo = clsHelpMethods_Local.GetFifoCost(oUpdatedRecord.Item_ID , 0);
                                                        //clsHelpMethods_Local.UpdateStoreStock(iFormID,
                                                        //    SProduct.StoreProduction_ID, SProduct.StoreProductionDate,
                                                        //    oUpdatedRecord.Item_ID, "0", txtStoreName.Tag.ToString(),
                                                        //    oUpdatedRecord.Qty, oUpdatedRecord.Weight,
                                                        //    oUpdatedRecord.TotalAmount, false, true, true, ref dWeightedAverageCostPrice);
                                                        //   clsHelpMethods_Local.UpdateFifo_Stock(iFormID, SProduct.StoreProduction_ID, SProduct.StoreProductionDate, SProduct.Store_ID, oUpdatedRecord.Item_ID, oUpdatedRecord.ItemSerialNo, oUpdatedRecord.Qty, oUpdatedRecord.UnitPrice, true, dCostFifo);
                                                        oUpdatedRecord.WeightedAvgCost = dWeightedAverageCostPrice;
                                                        oUpdatedRecord.Update();

                                                    }

                                                    #endregion

                                                    #region Update Inventory
                                                    //tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtProductID.Text.Trim(), dtpFGTNDate.Value, txtRemark.Text.Trim(),
                                                    //    "default", "default", "default", -1, 0,
                                                    //    "", "", "", "", false, clsSecurity.UserIDLoged);

                                                    //clsHelpMethods.Update_Inventory(oHeader, oListInventory);

                                                    var responce = oData.Update_InventoryTxn(iFormID, txtProductID.Text.Trim(),IsUpdate);
                                                    if (!responce.IsSuccess)
                                                    {
                                                        clsValidate.WriteErrorLog(txtProductID.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
                                                    }
                                                    #endregion

                                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone),
                                                        clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                                                        MessageBoxIcon.Information);
                                                }
                                            }
                                            else
                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                                #endregion

                                #region Insert
                                else
                                {
                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                    {
                                        txtProductID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);
                                        txtProductID.Tag = txtProductID.Text;
                                    }
                                    if (clsValidate.CheckValidity_TransactionCodeLength(txtProductID.Text)) // if (txtProductID.TextLength > 0 && txtProductID.Text != "<Auto Generate>")
                                    {
                                        tbl_scsStoreProduction oSP = tbl_scsStoreProduction.Select(txtProductID.Text.Trim());
                                        if (oSP == null)
                                        {
                                            #region Insert Header
                                            tbl_scsStoreProduction SPdetail = new tbl_scsStoreProduction(txtProductID.Text.ToString(), dtpFGTNDate.Value, txtRemark.Text, "default",
                                            txtStoreName.Tag.ToString(), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default", clsSecurity.getServerDateTime(),
                                            clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, bHasChecked, bHasApproved, false, false, false, 0,
                                            ((ComboBoxItem)cmbItemPrice.SelectedItem).Value, clsSecurity.CompanyID, clsSecurity.BranchID);
                                            SPdetail.Insert();
                                            #endregion

                                            #region Insert Detail
                                            foreach (DataGridViewRow row in dgvDetail.Rows)
                                            {
                                                int iLineNo;
                                                string itemCode = "", ItemName = "", ItemCategory = "", ItemSubCategory2_ID = "", Remark = "", UMO = "";
                                                decimal Qty = 0, Weight = 0, WeightWestage = 0, WeightRejection = 0, dUnitPrice = 0, dWeightPrice = 0, dTotalAmount = 0;

                                                iLineNo = clsValidate.ValidateGridValue(dgvDetail, "Lineno", row.Index, 0);
                                                itemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                                ItemName = clsValidate.ValidateGridValue(dgvDetail, "ItemName", row.Index, "default");
                                                ItemCategory = clsValidate.ValidateGridTag(dgvDetail, "Subcategory", row.Index, "default");
                                                ItemSubCategory2_ID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategory2_ID", row.Index, "default");
                                                Remark = clsValidate.ValidateGridValue(dgvDetail, "Remark", row.Index, "default");
                                                UMO = clsValidate.ValidateGridValue(dgvDetail, "UOM", row.Index, "default");
                                                Qty = clsValidate.ValidateGridValue(dgvDetail, "QTY", row.Index, decimal.Parse("0.00"));
                                                Weight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                                WeightWestage = clsValidate.ValidateGridValue(dgvDetail, "WeightWestage", row.Index, decimal.Parse("0.00"));
                                                WeightRejection = clsValidate.ValidateGridValue(dgvDetail, "WeightRejection", row.Index, decimal.Parse("0.00"));
                                                dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "gUnitPrice", row.Index, decimal.Parse("0.00"));
                                                //dWeight = clsValidate.ValidateGridValue(dgvDetail, "ItemUnitPrice", row.Index, decimal.Parse("0.00"));
                                                dTotalAmount = clsValidate.ValidateGridValue(dgvDetail, "gTotalAmount", row.Index, decimal.Parse("0.00"));

                                                if (itemCode.Length > 0)
                                                {
                                                    tbl_scsStoreProduction_Detail detail = new tbl_scsStoreProduction_Detail(iLineNo, txtProductID.Text.Trim(), itemCode, ItemCategory, ItemSubCategory2_ID,
                                                        "0", "0", UMO, Qty, Weight, WeightWestage, WeightRejection, Remark, false, dUnitPrice, dWeightPrice, dTotalAmount, 0);
                                                    detail.Insert();

                                                    #region Update Store Stock

                                                    // decimal dCostFifo = clsHelpMethods_Local.GetFifoCost(itemCode , Qty);
                                                    //  clsHelpMethods_Local.UpdateStoreStock(itemCode, txtStoreName.Tag.ToString(), Qty, Weight, false, true);
                                                    // clsHelpMethods_Local.UpdateFifo_Stock(iFormID, SPdetail.StoreProduction_ID, SPdetail.StoreProductionDate, SPdetail.Store_ID, detail.Item_ID, detail.ItemSerialNo, detail.Qty, detail.UnitPrice, true, dCostFifo);
                                                    decimal dWeightedAverageCostPrice = 0;
                                                //    clsHelpMethods_Local.UpdateStoreStock(iFormID, SPdetail.StoreProduction_ID, SPdetail.StoreProductionDate, detail.Item_ID, "0", txtStoreName.Tag.ToString(), detail.Qty, detail.Weight, detail.TotalAmount, false, true, true, ref dWeightedAverageCostPrice);
                                                    detail.WeightedAvgCost = dWeightedAverageCostPrice;
                                                    detail.Update();
                                                    #endregion

                                                    #region Pass Value to Inventory Detail
                                                    //tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, iLineNo, 0, txtProductID.Text.Trim(), dtpFGTNDate.Value,
                                                    //                            "", "", "", "", "default", "default", txtStoreName.Tag.ToString(),
                                                    //                            itemCode, clsGenaralName.getName_ItemUOMID(itemCode), Qty, 0, dUnitPrice, 0, false);
                                                    //oListInventory.Add(oInventoryDetail);
                                                    #endregion
                                                }
                                            }
                                            #endregion

                                            Attachments.Insert(txtProductID.Text.ToString());

                                            #region Update Inventory
                                            //tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtProductID.Text.Trim(), dtpFGTNDate.Value, txtRemark.Text.Trim(),
                                            //    "default", "default", "default", -1, 0,
                                            //    "", "", "", "", false, clsSecurity.UserIDLoged);

                                            //clsHelpMethods.Update_Inventory(oHeader, oListInventory);

                                            var responce = oData.Update_InventoryTxn(iFormID, txtProductID.Text.Trim(),IsUpdate);
                                            if (!responce.IsSuccess)
                                            {
                                                clsValidate.WriteErrorLog(txtProductID.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
                                            }
                                            #endregion

                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                            MessageBox.Show("This ID is already added", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
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
                                if (txtProductID.Tag != null && txtProductID.Tag.ToString().Trim().Length > 0)
                                    FillDetails(txtProductID.Tag.ToString());
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Btn Print
        private void frm_scsStoreProduction_SF_printButton_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_scsStoreProduction_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region  print Method
        private void Print(bool bIsDraft)
        {
            try
            {
                if (txtProductID.Text.Trim().Length > 0 && txtProductID.Text != "<Auto Generate>")
                {
                    string sCreateUser = "", sCheckedUser = "", sApprovedUser = "", sIsdeleted = "", sDuplicateCopy = "";

                    bool bPermissinOkToPrint = true;
                    if (chkPrintOriginal.Checked)
                        bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_FinishedGoodsTransferNote));
                    if (bPermissinOkToPrint)
                    {
                        tbl_scsStoreProduction oOrder = tbl_scsStoreProduction.Select(txtProductID.Text.Trim());
                        if (oOrder != null)
                        {
                            clsLog.Process_Print(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.FinishedGoodsTransferNote), oOrder.StoreProduction_ID);

                            if (!bIsDraft)
                            {
                                if (!chkPrintOriginal.Checked)
                                    sDuplicateCopy = (oOrder.PrintCount > 0) ? "Duplicate Copy " + oOrder.PrintCount : "";
                                oOrder.PrintCount++;
                            }

                            sCreateUser = "[ " + clsGenaralName.getName_User(oOrder.CreateUser_ID) + " ] [ " + oOrder.DateCreate.ToShortDateString() + " ]";
                            if (oOrder.CheckedUser_ID != "default")
                                sCheckedUser = "[ " + clsGenaralName.getName_User(oOrder.CheckedUser_ID) + " ] [ " + oOrder.DateChecked.ToShortDateString() + " ]";
                            if (oOrder.ApprovedUser_ID != "default")
                                sApprovedUser = "[ " + clsGenaralName.getName_User(oOrder.ApprovedUser_ID) + " ] [ " + oOrder.DateApproved.ToShortDateString() + " ]";
                            oOrder.Update();

                            #region Check Deleted Values or Duplicated Print
                            if (oOrder.IsDeleted)
                                sIsdeleted = "Cancelled";
                            #endregion

                            Cursor = Cursors.WaitCursor;
                            string s_Path = "", sReportTitle = "Store Production", sFormula = "";
                            sFormula = "{tbl_scsStoreProduction.storeProduction_ID}='" + txtProductID.Text.Trim() + "'";

                            #region Set Report Path
                            ReportDocument RD = new ReportDocument();
                        //    s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                            s_Path = Application.StartupPath.Replace("\\Mini ERP\\bin\\Debug", "\\ZION.ERP.Reports");
                            string sGetRptPath = clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_FinishedGoodsTransferNote));
                            if (sGetRptPath != null && sGetRptPath.Length > 0)
                                s_Path += sGetRptPath;
                            else
                            {
                                #region Set Report Path for Various Reasons
                                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithDimension.ToString())
                                    s_Path += "\\reports\\SCS\\NotePrinting\\rpt_scsStoreProduction.rpt";
                                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                    s_Path += "\\reports\\SCS\\NotePrinting\\rpt_scsStoreProduction.rpt";
                                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithoutDimension.ToString())
                                    s_Path += "\\reports\\SCS\\NotePrinting\\rpt_scsStoreProduction.rpt";
                                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                                    s_Path += "\\reports\\SCS\\NotePrinting\\rpt_scsStoreProduction.rpt";
                                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                                    s_Path += "\\reports\\SCS\\NotePrinting\\rpt_scsStoreProduction.rpt";
                                else
                                    s_Path += "\\reports\\SCS\\NotePrinting\\rpt_scsStoreProduction.rpt";
                                #endregion
                            }
                            #endregion

                            frm_ReportViewer viewer = new frm_ReportViewer();
                            RD.Load(s_Path);
                            Digiteq.Classes.ReportHelper.LogonServer(ref RD);
                      //  .LogonServer(ref RD);
                            RD.Refresh();

                            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString() || clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                                RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);

                            RD.DataDefinition.FormulaFields["Deleted"].Text = clsCommon.fncsetstring(sIsdeleted);
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
                            RD.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring(sDuplicateCopy);
                            // RD.DataDefinition.FormulaFields["TelphoneFax"].Text = clsCommon.fncsetstring(clsCommon.getCustomerTelephoneAndFax(order.Customer_ID));
                            if (bIsDraft)
                            {
                                if (!clsConfig.isVisibleCompanyInfoInDraftPrint)
                                {
                                    RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring("");
                                    RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring("");
                                    RD.DataDefinition.FormulaFields["CompanyEmail"].Text = clsCommon.fncsetstring("");
                                    RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring("");
                                }
                                RD.DataDefinition.FormulaFields["IsDraft"].Text = clsCommon.fncsetstring("DRAFT");
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
                    }
                }
                else
                    MessageBox.Show("Please Select the Store Production To Print Report!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region btnAdd Click
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (txtItemID.Tag != null && txtItemID.Tag.ToString().Length > 0)
            {
                clsCommon.ValidateForeignKey(ref txtItemSubCategory);
                clsCommon.ValidateForeignKey(ref txtItemSerialNo, "0");
                RefreshGridByItem(txtItemID.Tag.ToString(), txtItemSubCategory.Tag.ToString(), txtItemSubCategory.Text.Trim(), txtItemSerialNo.Tag.ToString(), txtItemSerialNo.Text.Trim());
            }

        }
        #endregion

        #region btn grid Remove
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

        #region Btnn Temp
        private void frm_scsStoreProduction_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtProductID.TextLength > 0 && txtProductID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtProductID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreName, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtJobCode, true);

                txtProductID.Tag = null;
                dtpFGTNDate.Value = clsSecurity.getServerDateTime();

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Primary Key
                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtProductID.Text = "<Auto Generate>";
                else
                    txtProductID.Clear();
                if (txtProductID.Enabled)
                {
                    txtProductID.SelectAll();
                    txtProductID.Focus();
                }

                Attachments.Clear();
            }
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat_New(dgvDetail, clsFormatter.colorGrid, UI_Color);

            if (clsConfig.bWrap_ItemGrid_ItemName)
            {
                this.dgvDetail.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            if (clsConfig.bDisplay_ItemUnitPrice_StoreTransferNotes)
            {
                dgvDetail.Columns["gUnitPrice"].Visible = true;
                dgvDetail.Columns["gTotalAmount"].Visible = true;

            }

        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            IsUpdate = false;

            chkShowSettle.Checked = false;
            lblCancelled.Visible = false;

            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtProductID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreName, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtJobCode, true);

            txtProductID.Tag = null;
            txtStoreName.Tag = null;
            txtRemark.Tag = null;
            txtItemID.Tag = null;
            txtJobCode.Tag = null;

            dgvDetail.Rows.Clear();
            txtProductID.Clear();
            txtStoreName.Clear();
            txtRemark.Clear();
            txtItemID.Clear();
            txtJobCode.Clear();
            dtpFGTNDate.Value = clsSecurity.getServerDateTime();

            dtpFGTNDate.Enabled = !clsConfig.bLock_TransactionDate_SCS;

            foreach (ComboBoxItem d in cmbItemPrice.Items)
            {
                if (d.Value == clsConfig.sItemUnitPriceCode_Default)
                {
                    cmbItemPrice.SelectedItem = d;
                    break;
                }
            }
            
            bHasApproved = false;
            bHasChecked = false;
            userDetailsColorChanges();

            chkPrintOriginal.Checked = false;

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtProductID.Text = "<Auto Generate>";
            else
                txtItemID.Clear();
            if (txtItemID.Enabled)
            {
                txtItemID.SelectAll();
                txtItemID.Focus();
            }

            Attachments.Clear();
        }
        #endregion

        #region fill Data grid

        private void Fill_Datagrid(int iRow, string itemCode, string ItemName, string ItemSubCategory, string ItemSubCategory2_ID,
          string ItemSerialNo, string ItemSerialNo2, string UMO, decimal Qty, decimal Weight, decimal WeightDamaged, decimal WeightRejection, string Remark, decimal dUnitPrice, decimal dTotalAmount)
        {
            try
            {
                bool bItemExist = false;

                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    string sTmpItemID = "", sTmpItemSub = "", sTmpItemSub2 = "", sTmpSerial = "", sTmpSerial2 = "";
                    sTmpItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                    sTmpItemSub = clsValidate.ValidateGridTag(dgvDetail, "Subcategory", row.Index, "default");
                    sTmpItemSub2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategory2_ID", row.Index, "default");
                    sTmpSerial = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                    sTmpSerial2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");

                    if (itemCode == sTmpItemID && ItemSubCategory == sTmpItemSub && ItemSubCategory2_ID == sTmpItemSub2 && ItemSerialNo == sTmpSerial && ItemSerialNo2 == sTmpSerial2)
                    {
                        bItemExist = true;
                        dgvDetail.Rows.RemoveAt(iRow);
                        iRow = row.Index;
                        break;
                    }
                }

                if (!bItemExist)
                {
                    dgvDetail["Lineno", iRow].Value = iRow;
                    dgvDetail["ItemCode", iRow].Value = itemCode;
                    dgvDetail["ItemName", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Item(itemCode));
                    dgvDetail["Subcategory", iRow].Tag = clsCommon.GetForeignKeyValue(ItemSubCategory);
                    dgvDetail["Subcategory", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(ItemSubCategory));
                    dgvDetail["ItemSubCategory2_ID", iRow].Tag = clsCommon.GetForeignKeyValue(ItemSubCategory2_ID);
                    dgvDetail["ItemSubCategory2_ID", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory2(ItemSubCategory2_ID));
                    dgvDetail["ItemSerialNo", iRow].Value = ItemSerialNo;
                    dgvDetail["ItemSerialNo2", iRow].Value = ItemSerialNo2;
                    dgvDetail["UOM", iRow].Value = UMO;
                    //dgvDetail["QTY", iRow].Value = clsFormatter.FormatToNumberNoDecimal(Qty);
                    dgvDetail["QTY", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(Qty);
                    dgvDetail["Weight", iRow].Value = Weight;
                    dgvDetail["WeightWestage", iRow].Value = WeightDamaged;
                    dgvDetail["WeightRejection", iRow].Value = WeightRejection;
                    dgvDetail["IsLocked", iRow].Value = IsLocked;
                    dgvDetail["Remark", iRow].Value = Remark;
                    dgvDetail["gUnitPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(dUnitPrice);
                    dgvDetail["gTotalAmount", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(dTotalAmount);
                }
                else
                    MessageBox.Show("User is not allowed to add same item again...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region fill Details
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_scsStoreProduction detail = tbl_scsStoreProduction.Select(sID);
                    if (detail != null)
                    {
                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;

                        //set the update flag and Locked
                        IsUpdate = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtProductID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblProductID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreName, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblStoreName, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtItemID, true);
                        clsCommon.SetEnableDisable_NormalLabel(lblItemName, true);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtJobCode, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblJobCode, false);

                        dtpFGTNDate.Value = detail.StoreProductionDate;
                        txtStoreName.Tag = detail.Store_ID;
                        txtJobCode.Tag = detail.Job_ID;
                        txtProductID.Tag = detail.StoreProduction_ID;

                        txtStoreName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(detail.Store_ID));
                        txtJobCode.Text = clsCommon.GetForeignKeyValue(txtJobCode.Tag.ToString());
                        txtRemark.Text = detail.Remark;
                        txtProductID.Text = detail.StoreProduction_ID;

                        if (detail.ItemPriceCategory.Length > 0 && detail.ItemPriceCategory != "default")
                        {
                            foreach (ComboBoxItem d in cmbItemPrice.Items)
                            {
                                if (d.Value == detail.ItemPriceCategory)
                                {
                                    cmbItemPrice.SelectedItem = d;
                                    break;
                                }
                            }
                        }

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

                        RefreshGrid(detail.StoreProduction_ID);


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

        #region Refresh grid
        private void RefreshGridByItem(string sItemID, string sItemSubCategoryID, string sItemSubCategoryID2, string sSerialNo, string sSerialNo2)
        {
            try
            {
                int iRow;

                tbl_genItemMaster detail = tbl_genItemMaster.Select(sItemID);
                if (detail != null)
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
               //     string sItemPriceCategory = ((ComboBoxItem)cmbItemPrice.SelectedItem).Value;
                    decimal dUnitPrice = clsProcessMethods.GetCostPrice_ByCostType(detail.Item_ID,  enum_CostPriceType.CostPrice1);//clsProcessMethods.GetRecommendedUnitPrice_Basic(detail.Item_ID, sItemPriceCategory);
                    Fill_Datagrid(iRow, detail.Item_ID, detail.ItemName, sItemSubCategoryID, sItemSubCategoryID2, sSerialNo, sSerialNo2, detail.Uom_ID, 1, 0, 0, 0, "", dUnitPrice, dUnitPrice);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void RefreshGrid(string sID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                List<tbl_scsStoreProduction_Detail> details = tbl_scsStoreProduction_Detail.SelectAllByStoreProduction_ID(sID);
                foreach (tbl_scsStoreProduction_Detail detail in details.OrderBy(p => p.Line_No))
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    Fill_Datagrid(iRow, detail.Item_ID, detail.Item_ID, detail.ItemSubCategory_ID,
                        detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Uom_ID, detail.Qty, detail.Weight, detail.WeightDamaged, detail.WeightRejection,
                        detail.Remark, detail.UnitPrice, detail.TotalAmount);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

        }
        #endregion

        #region Events Double Click
        private void txtProductID_DoubleClick(object sender, EventArgs e)
        {
            Search_StoreProduction();
        }
        private void txtStoreName_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterStore(ref txtStoreName, true);
        }

        private void txtItemID_DoubleClick(object sender, EventArgs e)
        {
            Search_ItemID(sender, new KeyEventArgs(Keys.F1));
        }
        private void txtCheckedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }
        private void txtApprovedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        #endregion

        #region Events KeyDown
        private void txtProductID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_StoreProduction();
        }

        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            Search_ItemID(sender, e);
        }

        private void frm_scsStoreProduction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        #endregion

        #region Check Validity
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtStoreName, "Store Name"))
                bStatus = true;

            return bStatus;
        }
        #endregion

        #region validateEmptyForignKey
        private void ValidateEmptyForeignKey()
        {
            clsCommon.ValidateForeignKey(ref txtStoreName);
            clsCommon.ValidateForeignKey(ref txtJobCode);
        }
        #endregion

        #region Search Methods
        private void Search_StoreProduction()
        {
            try
            {
                clsSearch.Search_TransactionStoreProduction(ref txtProductID, chkShowSettle.Checked);
                if (txtProductID.Tag != null && txtProductID.Tag.ToString().Trim().Length > 0) //call add button
                    FillDetails(txtProductID.Tag.ToString().Trim());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void Search_ItemID(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    clsHelpMethods_Local.SearchItemAdvance(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo);
                    if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                        btnAddItem_Click(btnAddItem, new EventArgs());
                }
                else if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4)
                {
                    clsHelpMethods_Local.SearchItemAdvanceByKeyPress(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo, e);
                    if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                        btnAddItem_Click(sender, new EventArgs());
                }
                
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                if (sColName == "QTY" || sColName == "gUnitPrice")
                {
                    //  string sItemCode = "";
                    decimal dQty = 0, dUnitPrice = 0;//dweightAct = 0, dCostPrice = 0,
                    dQty = clsValidate.ValidateGridValue(dgvDetail, "QTY", e.RowIndex, decimal.Parse("0.00"));
                    dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "gUnitPrice", e.RowIndex, decimal.Parse("0.00"));
                    dgvDetail["gTotalAmount", e.RowIndex].Value = clsFormatter.FormatToNumberWithTwoDecimalPlaces(dQty * dUnitPrice);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void btnF5_Click(object sender, EventArgs e)
        {
            Search_ItemID(sender, new KeyEventArgs(Keys.F5));
        }

        private void frm_scsStoreProduction_FormClosing(object sender, FormClosingEventArgs e)
        {
            Attachments.Close();
        }


        #region User Checked Approve Details

        private void frm_scsStoreProduction_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }
        private void frm_scsStoreProduction_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        
        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpFGTNDate.Value.Date))
                {
                    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtProductID.Text != null && txtProductID.TextLength > 0 && txtProductID.Text != "<Auto Generate>")
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

                                        tbl_scsStoreProduction objFGTN = tbl_scsStoreProduction.Select(txtProductID.Text.Trim());
                                        if (objFGTN != null)
                                        {
                                            objFGTN.IsApproved = true;
                                            objFGTN.DateApproved = clsSecurity.getServerDateTime();
                                            objFGTN.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                            objFGTN.Update();
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
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpFGTNDate.Value.Date))
                {
                    if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtProductID.Text != null && txtProductID.TextLength > 0 && txtProductID.Text != "<Auto Generate>")
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

                                        tbl_scsStoreProduction objFGTN = tbl_scsStoreProduction.Select(txtProductID.Text.Trim());
                                        if (objFGTN != null)
                                        {
                                            objFGTN.IsChecked = true;
                                            objFGTN.DateChecked = clsSecurity.getServerDateTime();
                                            objFGTN.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objFGTN.Update();
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

        private void frm_scsStoreProduction_SF_History_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProductID.Text != "" || txtProductID.Text != "<Auto Generate>")
                {
                    tbl_scsStoreProduction detail = tbl_scsStoreProduction.Select(txtProductID.Text.Trim());
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

        #endregion

        #region Settings Panel Events
        public override void SettingsClick()
        {
            if (xSetting.Visible == true)
                xSetting.Visible = false;
            else
            {
                xSetting.Visible = true;
                xSetting.Focus();
            }
        }
        private void button1_Click(object sender, EventArgs e)
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