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
    public partial class frm_scsExternalGoodReceiveNote : SEACC_Form
    {
        #region Variables
        //to manage update and insert
        //static bool IsUpdate = false;

        public string glbOrderRefNo = "", glbGoodReceiveNote = "", glbPurchaseOrderID = "";
        string sCreateUser = "", sCheckedUser = "", sApprovedUser = "", sDuplicateCopy = "", sIsDraft = "";

        dts_scsExternalGoodReceivedNote glb_dtsGRN = new dts_scsExternalGoodReceivedNote();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        #endregion

        #region Form Load
        public frm_scsExternalGoodReceiveNote(FormName _enmForm)
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
            FillDetailsCurrency(clsConfig.sLocalCurrencyCode);

            if (glbPurchaseOrderID.Length > 0)
            {
                tbl_scsPurchaseOrder detail = tbl_scsPurchaseOrder.Select(glbPurchaseOrderID);
                if (detail != null)
                {
                    txtPoID.Tag = detail.PurchaseOrder_ID;
                    btnAddPurchaseOrder_Click(sender, e);
                }
            }
            else if (glbGoodReceiveNote.Length > 0)
                FillDetails(glbGoodReceiveNote);
        }
        #endregion

        #region Btn New
        private void frm_scsExternalGoodReceiveNote_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void frm_scsExternalGoodReceiveNote_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGRNID.Text.Trim().Length > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpGRNDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreID.Tag.ToString(), IsUpdate))
                            {
                                Cursor = Cursors.WaitCursor;
                                tbl_scsExternalGoodReceivedNote detail = tbl_scsExternalGoodReceivedNote.Select(txtGRNID.Text.Trim());
                                if (detail != null)
                                {
                                    if (ValidateForDependancies(detail.ExternalGoodReceivedNote_ID))
                                    {
                                        if (!detail.IsLocked && !detail.IsFinished && !detail.IsDeleted)
                                        {
                                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " GRN : " + txtGRNID.Text), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                            if (msgResult == DialogResult.Yes)
                                            {
                                                if (CheckSupplierSaveValidity(detail.Supplier_ID))
                                                {
                                                    if (CheckStockValidity(detail.ExternalGoodReceivedNote_ID, false))
                                                    {
                                                        if (CheckCancelValidity_WATollarance())
                                                        {
                                                            #region Update Other Tables
                                                            foreach (tbl_scsExternalGoodReceivedNote_Detail Olddetail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(txtGRNID.Text.Trim()))
                                                            {
                                                                if (Olddetail.Item_ID != null)
                                                                {
                                                                    decimal dWeightedAverageCostPrice = 0;
                                                                    clsHelpMethods.UpdateStoreStock(iFormID, Olddetail.ExternalGoodReceivedNote_ID, detail.ExternalGoodReceivedNoteDate, Olddetail.Item_ID, "0", txtStoreID.Tag.ToString(), Olddetail.Qty, Olddetail.Weight, Olddetail.TatalAmount, true, true, true, ref dWeightedAverageCostPrice);

                                                                    Olddetail.WeightedAvgCost = clsProcessMethods.GetItemWeightedAvarageCostPrice(Olddetail.Item_ID);
                                                                    Olddetail.Update();

                                                                    #region Unsettle PO
                                                                    foreach (tbl_scsPurchaseOrder_Detail oPOD in tbl_scsPurchaseOrder_Detail.SelectAllByPurchaseOrder_ID(Olddetail.PurchaseOrder_ID).Where(p => p.Line_No == Olddetail.Line_No))
                                                                    {
                                                                        oPOD.WeightSettle -= Olddetail.Weight;
                                                                        oPOD.QtySettle -= Olddetail.Qty;
                                                                        oPOD.Update();
                                                                    }
                                                                    #endregion
                                                                }
                                                            }
                                                            #endregion

                                                            tbl_scsPurchaseOrder opo = tbl_scsPurchaseOrder.Select(detail.PurchaseOrder_ID);
                                                            if (opo != null && opo.PurchaseOrder_ID != "default")
                                                            {
                                                                opo.IsSeattled = false;
                                                                opo.Update();
                                                            }

                                                            #region Delete Barcode
                                                            foreach (tbl_scsDocument_Barcode DocBarcode in tbl_scsDocument_Barcode.SelectAll().Where(p => p.Transaction_ID == txtGRNID.Text.Trim()))
                                                            {
                                                                DocBarcode.Delete();

                                                                foreach (tbl_genItemMaster_Barcode itemBarcode in tbl_genItemMaster_Barcode.SelectAll().Where(p => p.Barcode_ID == DocBarcode.Barcode_ID))
                                                                {
                                                                    itemBarcode.Delete();
                                                                }
                                                            }
                                                            #endregion

                                                            detail.DateModified = clsSecurity.getServerDateTime();
                                                            detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                            detail.IsDeleted = true;
                                                            detail.Update();

                                                            clsHelpMethods.Delete_Inventory(iFormID, 0, txtGRNID.Text.Trim());

                                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            clsAlerts_Email.createEmail_GRN(txtGRNID.Text.Trim(), enum_Alerts.Good_RecivedNote_Cancel);
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
                if (tbcItems.SelectedTab == tbpBreakdown)
                {
                    if (dgvBreakdown.SelectedCells.Count != 0)
                    {
                        if (dgvBreakdown.Rows.Count > 0)
                            dgvBreakdown.Rows.RemoveAt(dgvBreakdown.SelectedCells[0].RowIndex);
                    }
                }
                else if (tbcItems.SelectedTab == tbpGenaral)
                {
                    if (dgvDetail.SelectedCells.Count != 0)
                    {
                        if (dgvDetail.Rows.Count > 0)
                            dgvDetail.Rows.RemoveAt(dgvDetail.SelectedCells[0].RowIndex);

                        clsHelpMethods.Grid_LineNoChange(dgvDetail);
                        CalcualteSubTotal();
                        CalculateTaxesAndGrandTotal();
                        CusDataGridView_formatSrollBar_Main();
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
        private void frm_scsExternalGoodReceiveNote_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    if (glbOrderRefNo.Length <= 0)
                        glbOrderRefNo = "default";

                    #region Update EGRN
                    if (IsUpdate)
                    {
                        tbl_scsExternalGoodReceivedNote oldRecord = tbl_scsExternalGoodReceivedNote.Select(txtGRNID.Text.Trim());
                        if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                        {
                            if (ValidateForDependancies(oldRecord.ExternalGoodReceivedNote_ID))
                            {
                                if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                                {
                                    if (!oldRecord.IsChecked || (oldRecord.IsChecked && clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID)))
                                    {
                                        if (clsValidate.CheckValidity_TransactionCodeLength(txtGRNID.Text))
                                        {
                                            List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();
                                            #region Update EGRN Breakdown Detail

                                            {
                                                int Gen_LineNo = -1;
                                                string sItemID = "default", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "";
                                                string sSerialNo = "", sRemark = "", sJobCode = "default";
                                                decimal dQuantity = 0, dWeight = 0;

                                                #region Rollback Store Stock in Breakdown

                                                foreach (tbl_scsExternalGoodReceivedNote_DetailBreakdown oUpdatedRecord in tbl_scsExternalGoodReceivedNote_DetailBreakdown.SelectAllByExternalGoodReceivedNote_ID(txtGRNID.Text.Trim()))
                                                {
                                                    //  clsHelpMethods.UpdateStoreStock(oUpdatedRecord.Item_ID, txtStoreID.Tag.ToString(), oUpdatedRecord.Qty, oUpdatedRecord.Weight, true, true);
                                                }

                                                #endregion

                                                if (dgvGenaral.SelectedRows.Count > 0)
                                                {
                                                    int sRow = dgvGenaral.SelectedRows[0].Index;
                                                    Gen_LineNo = clsValidate.ValidateGridValue(dgvGenaral, "GenLineNo", sRow, -1);
                                                    sItemID = clsValidate.ValidateGridValue(dgvGenaral, "GenItemCode", sRow, "default");
                                                    sItemSubCategoryID = clsValidate.ValidateGridTag(dgvGenaral, "gItemSubCategoryID", sRow, "default");
                                                    sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvGenaral, "gItemSubCategoryID2", sRow, "default");
                                                    sItemSerialNo = clsValidate.ValidateGridValue(dgvGenaral, "gItemSerialNo", sRow, "0");
                                                    sItemSerialNo2 = clsValidate.ValidateGridValue(dgvGenaral, "gItemSerialNo2", sRow, "0");
                                                }

                                                #region Update Old Records

                                                foreach (tbl_scsExternalGoodReceivedNote_DetailBreakdown oldDetail in tbl_scsExternalGoodReceivedNote_DetailBreakdown.SelectAllByExternalGoodReceivedNote_ID(oldRecord.ExternalGoodReceivedNote_ID).Where(p => p.Item_ID == sItemID && p.ItemSubCategory_ID == sItemSubCategoryID && p.ItemSubCategory2_ID == sItemSubCategoryID2 && p.ItemSerialNo2 == sItemSerialNo2)) //don't add serialNo1 validation
                                                {
                                                    bool Gen_HasABreakdown = false;
                                                    foreach (DataGridViewRow row in dgvBreakdown.Rows)
                                                    {
                                                        sSerialNo = clsValidate.ValidateGridValue(dgvBreakdown, "BrkSerialNo", row.Index, "");
                                                        dQuantity = clsValidate.ValidateGridValue(dgvBreakdown, "BrkQuantity", row.Index, decimal.Parse("0.00"));
                                                        dWeight = clsValidate.ValidateGridValue(dgvBreakdown, "BrkWeight", row.Index, decimal.Parse("0.00"));
                                                        sRemark = clsValidate.ValidateGridValue(dgvBreakdown, "BrkRemarks", row.Index, "");

                                                        if (oldDetail.ExternalGoodReceivedNote_ID ==
                                                            txtGRNID.Text.Trim() && oldDetail.SerialNo == sSerialNo)
                                                        {
                                                            Gen_HasABreakdown = true;
                                                            dgvBreakdown.Rows.RemoveAt(row.Index);
                                                            break; //database contain this item
                                                        }
                                                    }

                                                    if (Gen_HasABreakdown)
                                                    {
                                                        oldDetail.Qty = dQuantity;
                                                        oldDetail.Weight = dWeight;
                                                        oldDetail.Remark = sRemark;
                                                        oldDetail.Update();
                                                    }
                                                    else
                                                        oldDetail.Delete();
                                                }

                                                #endregion

                                                #region Insert Newly Added Record

                                                foreach (DataGridViewRow row in dgvBreakdown.Rows)
                                                {
                                                    sSerialNo = clsValidate.ValidateGridValue(dgvBreakdown, "BrkSerialNo", row.Index, "");
                                                    dQuantity = clsValidate.ValidateGridValue(dgvBreakdown, "BrkQuantity", row.Index, decimal.Parse("0.00"));
                                                    dWeight = clsValidate.ValidateGridValue(dgvBreakdown, "BrkWeight", row.Index, decimal.Parse("0.00"));
                                                    sRemark = clsValidate.ValidateGridValue(dgvBreakdown, "BrkRemarks", row.Index, "");

                                                    if (sSerialNo.Length > 0)
                                                    {
                                                        tbl_genItemSerialNoMaster oSerial = tbl_genItemSerialNoMaster.Select(sSerialNo);
                                                        if (oSerial == null)
                                                        {
                                                            tbl_genItemSerialNoMaster oNewSerial = new tbl_genItemSerialNoMaster(sSerialNo, sItemID, sRemark, dtpGRNDate.Value, dtpGRNDate.Value, oldRecord.ExternalGoodReceivedNote_ID, oldRecord.ExternalGoodReceivedNoteDate, false, false, false, false, "default", "default", "default");
                                                            oNewSerial.Insert();
                                                        }

                                                        tbl_scsExternalGoodReceivedNote_DetailBreakdown oBRDetails = new tbl_scsExternalGoodReceivedNote_DetailBreakdown(row.Index, Gen_LineNo, oldRecord.ExternalGoodReceivedNote_ID, sItemID, sItemSubCategoryID, sItemSubCategoryID2, sSerialNo, sItemSerialNo2, sSerialNo, dQuantity, dWeight, sRemark);
                                                        oBRDetails.Insert();

                                                        //lock the Item
                                                        foreach (tbl_scsExternalGoodReceivedNote_Detail oGRNItem in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(oldRecord.ExternalGoodReceivedNote_ID).Where(p => p.Item_ID == sItemID))
                                                        {
                                                            oGRNItem.BHasBreakDown = true;
                                                            oGRNItem.Update();
                                                        }
                                                    }
                                                }

                                                #endregion

                                                #region Update Store Stock in Breakdown

                                                foreach (tbl_scsExternalGoodReceivedNote_DetailBreakdown oUpdatedRecord in tbl_scsExternalGoodReceivedNote_DetailBreakdown.SelectAllByExternalGoodReceivedNote_ID(txtGRNID.Text.Trim()))
                                                {
                                                    //   clsHelpMethods.UpdateStoreStock(oUpdatedRecord.Item_ID, txtStoreID.Tag.ToString(), oUpdatedRecord.Qty, oUpdatedRecord.Weight, false, true);
                                                }

                                                #endregion
                                            }

                                            #endregion

                                            #region Rollback Store Stock

                                            foreach (tbl_scsExternalGoodReceivedNote_Detail oUpdatedRecord in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(txtGRNID.Text.Trim()))
                                            {
                                                decimal dWeightedAverageCostPrice = 0;
                                                clsHelpMethods.UpdateStoreStock(iFormID, oUpdatedRecord.ExternalGoodReceivedNote_ID, oldRecord.ExternalGoodReceivedNoteDate, oUpdatedRecord.Item_ID, "0", txtStoreID.Tag.ToString(), oUpdatedRecord.Qty, oUpdatedRecord.Weight, oUpdatedRecord.TatalAmount, true, true, true, ref dWeightedAverageCostPrice);
                                                oUpdatedRecord.WeightedAvgCost = dWeightedAverageCostPrice;
                                                oUpdatedRecord.Update();
                                            }

                                            #endregion

                                            #region Update EGRN Detail                      
                                            #region Update Old EGRN Items

                                            foreach (tbl_scsExternalGoodReceivedNote_Detail oldDetail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(txtGRNID.Text.Trim()))
                                            {
                                                #region Unsettle PO

                                                foreach (tbl_scsPurchaseOrder_Detail oPOD in tbl_scsPurchaseOrder_Detail.SelectAllByPurchaseOrder_ID(oldDetail.PurchaseOrder_ID)
                                                        .Where(p => p.Item_ID == oldDetail.Item_ID && p.Line_No == oldDetail.Line_No))
                                                {
                                                    oPOD.WeightSettle -= oldDetail.Weight;
                                                    oPOD.QtySettle -= oldDetail.Qty;
                                                    oPOD.Update();
                                                }

                                                #endregion

                                                #region Detail Variables
                                                string sJobCode = "default", sItemCode = "", sItemSubCategoryID1 = "", sItemSubCategoryID2 = "", sItemSerialNo1 = "", sItemSerialNo2 = "", sPOID = "", sPRNID = "", sBatch = "", sUom = "", sRemarks = "";
                                                decimal dQty = 0, dUnitPrice = 0, dWeight = 0, dAmount = 0, dWaranty = 0, dWeidhtPrice = 0;
                                                bool bHasItemInDB = false;
                                                int iLineNo = 0;
                                                #endregion

                                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                                {
                                                    #region Fill Grid Vales to Variables
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
                                                    dQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                                    dUnitPrice = clsValidate.ValidateGridTag(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                                                    dWeidhtPrice = clsValidate.ValidateGridTag(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                                                    dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                                    dAmount = clsValidate.ValidateGridTag(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                                                    dWaranty = clsValidate.ValidateGridValue(dgvDetail, "Warranty", row.Index, decimal.Parse("0.00"));
                                                    sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                                                    #endregion

                                                    #region Check Existing Record in Data Grid
                                                    if (oldDetail.ExternalGoodReceivedNote_ID == txtGRNID.Text.Trim() && oldDetail.Line_No == iLineNo && oldDetail.Item_ID == sItemCode && oldDetail.ItemSubCategory_ID == sItemSubCategoryID1 && oldDetail.ItemSubCategory2_ID == sItemSubCategoryID2 && oldDetail.ItemSerialNo == sItemSerialNo1 && oldDetail.ItemSerialNo2 == sItemSerialNo2)
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
                                                    if (!oldDetail.BHasBreakDown)
                                                    {
                                                        //Get Unit Price with Exchange rate to save
                                                        dUnitPrice = getSavePrice(dUnitPrice);
                                                        dWeidhtPrice = getSavePrice(dWeidhtPrice);
                                                        dAmount = getSavePrice(dAmount);

                                                        oldDetail.Item_ID = sItemCode;
                                                        oldDetail.ItemSubCategory_ID = sItemSubCategoryID1;
                                                        oldDetail.ItemSubCategory2_ID = sItemSubCategoryID2;
                                                        oldDetail.ItemSerialNo = sItemSerialNo1;
                                                        oldDetail.ItemSerialNo2 = sItemSerialNo2;
                                                        oldDetail.PurchaseOrder_ID = sPOID;
                                                        oldDetail.PurchaseReturnedNote_ID = sPRNID;
                                                        oldDetail.BatchNo = sBatch;
                                                        oldDetail.Qty = dQty;
                                                        oldDetail.UnitPrice = dUnitPrice;
                                                        oldDetail.KiloPrice = dWeidhtPrice;
                                                        oldDetail.Weight = dWeight;
                                                        oldDetail.TatalAmount = dAmount;
                                                        oldDetail.Warranty = dWaranty;
                                                        oldDetail.Remark = sRemarks;
                                                        oldDetail.Update();
                                                    }

                                                    #endregion

                                                    #region Pass Value to Inventory Detail
                                                    tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, iLineNo, 0, txtGRNID.Text.Trim(), dtpGRNDate.Value,
                                                        "", "", "", "", "default", txtSupplierID.Tag.ToString(), txtStoreID.Tag.ToString(), sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), dQty, 0, dUnitPrice, 0, false);
                                                    oListInventory.Add(oInventoryDetail);
                                                    #endregion
                                                }
                                                else
                                                {
                                                    #region Delete old item detail

                                                    ////update item finance

                                                    #region Update Item Finance

                                                    tbl_genItemMaster_Pricing item = tbl_genItemMaster_Pricing.Select(oldDetail.Item_ID);
                                                    if (item != null)
                                                    {
                                                        item.Update();
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
                                                #region Detail Variables
                                                string sJobCode = "default", sItemCode = "", sItemSubCategoryID1 = "", sItemSubCategoryID2 = "", sItemSerialNo1 = "", sItemSerialNo2 = "", sPOID = "", sPRNID = "", sBatch = "", sUom = "", sRemarks = "";
                                                decimal dQty = 0, dUnitPrice = 0, dWeight = 0, dAmount = 0, dWaranty = 0, dWeidhtPrice = 0;
                                                int iLineNo = 0;
                                                #endregion

                                                #region Fill Grid Values to Variables
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
                                                dQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                                dUnitPrice = clsValidate.ValidateGridTag(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                                                dWeidhtPrice = clsValidate.ValidateGridTag(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                                                dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                                dAmount = clsValidate.ValidateGridTag(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                                                dWaranty = clsValidate.ValidateGridValue(dgvDetail, "Warranty", row.Index, decimal.Parse("0.00"));
                                                sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");

                                                //Get Unit & Weight Price with Exchange rate to save
                                                dUnitPrice = getSavePrice(dUnitPrice);
                                                dWeidhtPrice = getSavePrice(dWeidhtPrice);
                                                dAmount = getSavePrice(dAmount);
                                                #endregion

                                                tbl_scsExternalGoodReceivedNote_Detail EGRNdetail = new tbl_scsExternalGoodReceivedNote_Detail(iLineNo, txtGRNID.Text.Trim(), sItemCode,
                                                        sPOID, sPRNID, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, dQty, 0, dWeight, 0,
                                                        dWaranty, sBatch, dWeidhtPrice, dUnitPrice, 0, 0, dAmount, sRemarks, false, clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemCode));
                                                EGRNdetail.Insert();

                                                #region Pass Value to Inventory Detail

                                                tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, iLineNo, 0, txtGRNID.Text.Trim(), dtpGRNDate.Value,
                                                            "", "", "", "", "default", txtSupplierID.Tag.ToString(), txtStoreID.Tag.ToString(),
                                                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), 0, 0, dUnitPrice, 0, false);
                                                oListInventory.Add(oInventoryDetail);
                                                #endregion
                                            }
                                            #endregion
                                            #endregion

                                            #region Update EGRN Header

                                            tbl_scsExternalGoodReceivedNote EGRN = new tbl_scsExternalGoodReceivedNote(txtGRNID.Text.Trim(), dtpGRNDate.Value, txtRemark.Text.Trim(), txtSupplierID.Tag.ToString(), txtPoID.Tag.ToString(), txtStoreID.Tag.ToString(), glbOrderRefNo, txtCurrencyID.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text.Trim()), txtPaymentMode.Tag.ToString(), txtPaymentTerms.Text.Trim(), "", txtCreditPeriod.Text.Trim(), dtpDueDate.Value, txtManualNo.Text.Trim(), txtInvoiceNo.Text.Trim(),
                                                txtStockNoteType.Tag.ToString(), oldRecord.GlPosting_ID, txtCostCenter.Tag.ToString(), oldRecord.PostingStatus_ID, oldRecord.FinancialYear_ID, decimal.Parse(txtPercentageDiscount.Text.Trim()), decimal.Parse(txtPercentageNBT.Text.Trim()), decimal.Parse(txtPercentageVat.Text.Trim()), decimal.Parse(txtPercentageOtherTax.Text.Trim()), getSavePrice(decimal.Parse(txtSubTotal.Tag.ToString().Trim())),
                                                getSavePrice(decimal.Parse(txtDiscount.Tag.ToString().Trim())), getSavePrice(decimal.Parse(txtNBT.Tag.ToString().Trim())), getSavePrice(decimal.Parse(txtVat.Tag.ToString().Trim())), getSavePrice(decimal.Parse(txtOtherTax.Tag.ToString().Trim())), getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim())), oldRecord.CreateUser_ID, clsSecurity.UserIDLoged, oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID, oldRecord.DeletedUser_ID, oldRecord.PrintedUser_ID,
                                                oldRecord.CreateTerminal_ID, clsSecurity.TerminalID, oldRecord.DeletedTerminal_ID, oldRecord.PrintedTerminal_ID, oldRecord.DateCreate, clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), bHasChecked, bHasApproved, oldRecord.IsFinished, oldRecord.IsDeleted, oldRecord.IsLocked, oldRecord.SeattleAmount, oldRecord.IsSeattled, oldRecord.PrintCount, !chkUnitPricing.Checked, clsHelpMethods.isTaxActiveNote(txtVat), clsHelpMethods.isTaxActiveNote(txtOtherTax), oldRecord.CompanyID, oldRecord.CompanyBranch_ID);
                                            EGRN.Update();

                                            #endregion

                                            #region Pass Values to Inventory Header and Update Inventory
                                            tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtGRNID.Text.Trim(), dtpGRNDate.Value, txtRemark.Text.Trim(),
                                                    "default", txtSupplierID.Tag.ToString(), "default", -1, decimal.Parse(txtGrandTotal.Text.Trim()), "", "", "", "", false, clsSecurity.UserIDLoged);

                                            clsHelpMethods.Update_Inventory(oHeader, oListInventory);
                                            #endregion

                                            #region Update Store Stock

                                            foreach (tbl_scsExternalGoodReceivedNote_Detail oUpdatedRecord in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(txtGRNID.Text.Trim()))
                                            {
                                                decimal dWeightedAverageCostPrice = 0;
                                                clsHelpMethods.UpdateStoreStock(iFormID, EGRN.ExternalGoodReceivedNote_ID, EGRN.ExternalGoodReceivedNoteDate, oUpdatedRecord.Item_ID, "0", txtStoreID.Tag.ToString(), oUpdatedRecord.Qty, oUpdatedRecord.Weight, oUpdatedRecord.TatalAmount, false, true, true, ref dWeightedAverageCostPrice);
                                                oUpdatedRecord.WeightedAvgCost = dWeightedAverageCostPrice;
                                                oUpdatedRecord.Update();
                                            }

                                            #endregion

                                            #region Update PO
                                            UpdatePO(txtGRNID.Text.Trim());
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

                    #region Insert EGRN
                    else
                    {
                        #region Genarate Serial no
                        if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                        {
                            if (clsConfig.bStockNoteType_SerialNoActiveFor_GoodsReceivedNote)
                            {
                                if (txtStockNoteType.Tag != null && txtStockNoteType.Tag.ToString().Trim().Length > 0 && txtStockNoteType.Tag.ToString().Trim() != "default")
                                    txtGRNID.Text = clsAutocode.getAutoGeneratedCode_GoodReceiveNote(txtStockNoteType.Tag.ToString());
                                else
                                    MessageBox.Show("Please select the Stock Note Type before you save the record. " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                txtGRNID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);
                        }
                        #endregion

                        #region create order ref number
                        if (glbOrderRefNo.Length <= 0 || glbOrderRefNo == "default")
                        {
                            glbOrderRefNo = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.zIssuedRefNo));
                            tbl_zIssuedRefNo orf = new tbl_zIssuedRefNo(glbOrderRefNo, txtSupplierRefNo.Text != "" ? txtSupplierRefNo.Text.Trim() : "-");
                            orf.Insert();
                        }
                        #endregion

                        if (clsValidate.CheckValidity_TransactionCodeLength(txtGRNID.Text)) //if (txtGRNID.Text.Trim().Length > 0)
                        {
                            List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();

                            #region Insert Header
                            tbl_scsExternalGoodReceivedNote EGRN = new tbl_scsExternalGoodReceivedNote(txtGRNID.Text.Trim(), dtpGRNDate.Value, txtRemark.Text.Trim(), txtSupplierID.Tag.ToString(),
                                txtPoID.Tag.ToString(), txtStoreID.Tag.ToString(), glbOrderRefNo, txtCurrencyID.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text.Trim()), txtPaymentMode.Tag.ToString(), txtPaymentTerms.Text.Trim(), "",
                                txtCreditPeriod.Text.Trim(), dtpDueDate.Value, txtManualNo.Text.Trim(), txtInvoiceNo.Text.Trim(), txtStockNoteType.Tag.ToString(),
                                "default", txtCostCenter.Tag.ToString(), clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID,
                                decimal.Parse(txtPercentageDiscount.Text.Trim()), decimal.Parse(txtPercentageNBT.Text.Trim()), decimal.Parse(txtPercentageVat.Text.Trim()), decimal.Parse(txtPercentageOtherTax.Text.Trim()), getSavePrice(decimal.Parse(txtSubTotal.Tag.ToString().Trim())),
                                getSavePrice(decimal.Parse(txtDiscount.Tag.ToString().Trim())), getSavePrice(decimal.Parse(txtNBT.Tag.ToString().Trim())), getSavePrice(decimal.Parse(txtVat.Tag.ToString().Trim())), getSavePrice(decimal.Parse(txtOtherTax.Tag.ToString().Trim())),
                                getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim())), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default", clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), bHasChecked, bHasApproved, false, false, false, 0, false, 0, !chkUnitPricing.Checked, clsHelpMethods.isTaxActiveNote(txtVat), clsHelpMethods.isTaxActiveNote(txtOtherTax), clsSecurity.CompanyID, clsSecurity.BranchID);
                            EGRN.Insert();
                            #endregion

                            #region Insert Detail
                            foreach (DataGridViewRow row in dgvDetail.Rows)
                            {
                                #region Grid Variables
                                string sJobCode = "default", sItemCode = "", sItemSubCategoryID1 = "", sItemSubCategoryID2 = "", sItemSerialNo1 = "", sItemSerialNo2 = "",
                                    sPOID = "", sPRNID = "", sBatch = "", sUom = "", sUomID = "", sRemarks = "";
                                decimal dQuantity = 0, dUnitPrice = 0, dWeight = 0, dAmount = 0, dWaranty = 0, dWeidhtPrice = 0;
                                int iLineNo = 0;
                                #endregion

                                #region Value Pass to Variables
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
                                sUomID = clsValidate.ValidateGridTag(dgvDetail, "UOM", row.Index, "default");
                                dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
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
                                #endregion

                                tbl_scsExternalGoodReceivedNote_Detail EGRNdetail = new tbl_scsExternalGoodReceivedNote_Detail(iLineNo, txtGRNID.Text.Trim(), sItemCode,
                                    sPOID, sPRNID, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, dQuantity, 0, dWeight, 0, dWaranty, sBatch, dWeidhtPrice, dUnitPrice, 0, 0, dAmount, sRemarks, false, 0);
                                EGRNdetail.Insert();

                                #region Update Store Stock And FIFO
                                decimal dWeightedAverageCostPrice = 0;
                                clsHelpMethods.UpdateStoreStock(iFormID, EGRN.ExternalGoodReceivedNote_ID, EGRN.ExternalGoodReceivedNoteDate, sItemCode, "0", txtStoreID.Tag.ToString(), dQuantity, dWeight, EGRNdetail.TatalAmount, false, true, true, ref dWeightedAverageCostPrice);
                                EGRNdetail.WeightedAvgCost = dWeightedAverageCostPrice;
                                EGRNdetail.Update();
                                #endregion

                                #region Pass Value to Inventory Detail
                                tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, iLineNo, 0, txtGRNID.Text.Trim(), dtpGRNDate.Value,
                                                            "", "", "", "", "default", txtSupplierID.Tag.ToString(), txtStoreID.Tag.ToString(),
                                                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), dQuantity, 0, dUnitPrice, 0, false);
                                oListInventory.Add(oInventoryDetail);
                                #endregion
                            }
                            #endregion

                            #region Update PO &  Insert Attachment
                            Attachments.Insert(txtGRNID.Text.ToString());

                            UpdatePO(txtGRNID.Text.Trim());
                            #endregion

                            #region Update Inventory
                            tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtGRNID.Text.Trim(), dtpGRNDate.Value, txtRemark.Text.Trim(),
                                "default", txtSupplierID.Tag.ToString(), "default", -1, decimal.Parse(txtGrandTotal.Text.Trim()),
                                "", "", "", "", false, clsSecurity.UserIDLoged);

                            clsHelpMethods.Update_Inventory(oHeader, oListInventory);
                            #endregion

                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clsAlerts_Email.createEmail_GRN(txtGRNID.Text.Trim(), enum_Alerts.Good_RecivedNote_Created);
                        }
                        //else
                        //MessageBox.Show("GRN " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    tbl_scsExternalGoodReceivedNote oldRecord = tbl_scsExternalGoodReceivedNote.Select(txtGRNID.Text.Trim());
                    if (oldRecord != null)
                    {
                        ClearFields();
                        FillDetails(oldRecord.ExternalGoodReceivedNote_ID);
                    }
                }
            }
        }
        #endregion

        #region Btn Print
        private void frm_scsExternalGoodReceiveNote_SF_printButton_Click(object sender, EventArgs e)
        {
            PrintDataset(false);
            clsAlerts_Email.createEmail_GRN(txtGRNID.Text.Trim(), enum_Alerts.Good_RecivedNote_Print);
        }
        #endregion

        #region Btn Draft
        private void frm_scsExternalGoodReceiveNote_SF_draftButton_Click(object sender, EventArgs e)
        {
            PrintDataset(true);
        }
        #endregion

        #region Btn Add Purchase Order
        private void btnAddPurchaseOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPoID.Tag != null && txtPoID.Tag.ToString().Length > 0)
                {
                    tbl_scsPurchaseOrder detail = tbl_scsPurchaseOrder.Select(txtPoID.Tag.ToString());
                    if (detail != null)
                    {
                        bool isItemsOk = false;
                        foreach (tbl_scsPurchaseOrder_Detail oItem in tbl_scsPurchaseOrder_Detail.SelectAllByPurchaseOrder_ID(detail.PurchaseOrder_ID))
                        {
                            if (detail.IsWeightCalculation)
                                isItemsOk = (oItem.WeightSettle < oItem.Weight) ? true : isItemsOk;
                            else
                                isItemsOk = (oItem.QtySettle < oItem.Qty) ? true : isItemsOk;
                        }
                        if (isItemsOk)
                        {
                            txtPoID.Tag = detail.PurchaseOrder_ID;
                            txtPoID.Text = detail.PurchaseOrder_ID;
                            txtSupplierID.Tag = detail.Supplier_ID;
                            txtSupplierID.Text = clsGenaralName.getName_Supplier(detail.Supplier_ID);
                            txtStockNoteType.Tag = detail.StockNoteType_ID;
                            txtStockNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_StockNoteType(detail.StockNoteType_ID));
                            chkUnitPricing.Checked = !detail.IsWeightCalculation;
                            txtCostCenter.Tag = detail.CostCenter;
                            txtCostCenter.Text = clsGenaralName.getName_AccCostCenter1(detail.CostCenter);
                            txtPaymentMode.Tag = detail.PaymentMethod_ID;
                            txtPaymentMode.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_PaymentMethod(detail.PaymentMethod_ID));
                            txtCreditPeriod.Text = detail.BalanceDays.ToString();
                            //add order ref detail
                            glbOrderRefNo = detail.IssuedRefNo_ID;
                            txtSupplierRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_IssuedRefNo(detail.IssuedRefNo_ID));
                            txtSupplierRefNo.Tag = detail.IssuedRefNo_ID;
                            clsCommon.SetEnableDisable_NormalTextbox(txtSupplierRefNo, false);
                            clsCommon.SetEnableDisable_NormalLabel(lblIssuedRefNo, false);

                            //add currency detail
                            FillTaxDetailByPO(detail.PurchaseOrder_ID);

                            RefreshGridByPurchaseOrderID(detail.PurchaseOrder_ID, detail.IsWeightCalculation);

                            setEnableArea_PO(false);
                            setEnableArea_Item(false);
                            setEnableArea_Supplier(false);
                            setEnableArea_StockNoteType(false);
                        }
                        else
                        {
                            MessageBox.Show("Selected PO already settled...!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPoID.Tag = null;
                            txtPoID.Text = null;
                        }
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

        #region Btn Add Item
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (txtItemID.Tag != null && txtItemID.Tag.ToString().Length > 0)
                RefreshGridByItemID(txtItemID.Tag.ToString());

            setEnableArea_PO(false);
        }
        #endregion

        #region Btn Temp
        private void frm_scsExternalGoodReceiveNote_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtGRNID.TextLength > 0 && txtGRNID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtGRNID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStockNoteType, true);
                clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblStoreID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblStockNoteType, true);

                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCurrencyCode, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtSupplierRefNo, true);

                setEnableArea_Supplier(true);
                if (clsConfig.bEnableMandatory_PONo_for_GRN)
                {
                    clsCommon.SetEnableDisable_NormalLabel(lblIssuedRefNo, false);
                    setEnableArea_Item(false);
                    setEnableArea_StockNoteType(false);
                }
                else
                {
                    clsCommon.SetEnableDisable_NormalLabel(lblIssuedRefNo, true);
                    setEnableArea_Item(true);
                }
                setEnableArea_PO(true);

                txtGRNID.Tag = null;
                txtPoID.Tag = null;
                txtPoID.Text = "";
                dtpGRNDate.Value = clsSecurity.getServerDateTime();

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Order Ref No
                txtSupplierRefNo.Tag = null;
                txtSupplierRefNo.Clear();

                //Reset Primary Key
                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtGRNID.Text = "<Auto Generate>";
                else
                    txtGRNID.Clear();
                if (txtGRNID.Enabled)
                {
                    txtGRNID.SelectAll();
                    txtGRNID.Focus();
                }

                Attachments.Clear();
            }
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat_New(dgvDetail, clsFormatter.colorGrid, UI_Color);
            clsFormatter.ApplyGridFormat_New(dgvBreakdown, clsFormatter.colorGrid, UI_Color);
            clsFormatter.ApplyGridFormat_New(dgvGenaral, clsFormatter.colorGrid, UI_Color);

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
        private void CusDataGridView_formatSrollBar_Main()
        {
            //format grid acording to scroll bar 
            dgvDetail.Columns["ItemName"].Width = 237;
            if (dgvDetail.Rows.Count > 9)
                dgvDetail.Columns["ItemName"].Width -= 12;
        }
        private void CusDataGridView_FormatScrollBar_General()
        {
            //format grid acording to scroll bar 
            dgvGenaral.Columns["GenItemName"].Width = 265;
            if (dgvGenaral.Rows.Count > 9)
                dgvGenaral.Columns["GenItemName"].Width -= 12;
        }
        private void CusDataGridView_FormatScrollBar_BreakDown()
        {
            //format grid acording to scroll bar 
            dgvBreakdown.Columns["BrkSerialNo"].Width = 195;
            if (dgvBreakdown.Rows.Count > 8)
                dgvBreakdown.Columns["BrkSerialNo"].Width -= 12;
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            lblCancelled.Visible = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtGRNID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStockNoteType, true);
            clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblStoreID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblStockNoteType, true);

            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCurrencyCode, true);

            clsCommon.SetEnableDisable_NormalTextbox(txtSupplierRefNo, true);

            if (clsConfig.bShow_GridViewColumn_Remarks)
                dgvDetail.Columns["Remarks"].Visible = true;
            else
                dgvDetail.Columns["Remarks"].Visible = false;

            setEnableArea_Supplier(true);
            if (clsConfig.bEnableMandatory_PONo_for_GRN)
            {
                clsCommon.SetEnableDisable_NormalLabel(lblIssuedRefNo, false);

                setEnableArea_Item(false);
                setEnableArea_StockNoteType(false);
            }

            else
            {
                clsCommon.SetEnableDisable_NormalLabel(lblIssuedRefNo, true);
                setEnableArea_Item(true);
            }
            setEnableArea_PO(true);

            txtGRNID.Tag = null;
            txtSupplierID.Tag = null;
            txtPoID.Tag = null;
            txtItemID.Tag = null;
            txtStoreID.Tag = null;

            txtPRNID.Tag = null;
            txtSupplierRefNo.Tag = null;
            txtItemSubCategory.Tag = null;
            txtItemSerialNo.Tag = null;
            txtCurrencyID.Tag = null;
            txtStockNoteType.Tag = null;
            txtCostCenter.Tag = null;
            txtPaymentMode.Tag = null;

            txtItemSubCategory.Clear();
            txtItemSerialNo.Clear();
            txtSupplierID.Clear();
            txtPoID.Clear();
            txtItemID.Clear();
            txtStoreID.Clear();
            glbOrderRefNo = "";
            txtRemark.Clear();
            txtManualNo.Clear();
            txtPRNID.Clear();
            txtSupplierRefNo.Clear();
            txtCurrencyID.Clear();
            txtCurrencyCode.Clear();
            txtCurrencyRate.Clear();
            txtPaymentMode.Clear();
            txtPaymentTerms.Clear();
            txtCreditPeriod.Clear();
            txtStockNoteType.Clear();
            txtCostCenter.Clear();
            dtpDueDate.Value = clsSecurity.getServerDateTime();
            dtpGRNDate.Value = clsSecurity.getServerDateTime();

            chkUnitPricing.Checked = true;
            chkReverseCalculation.Checked = false;
            chkReverseCalculation.Enabled = true;
            //chkSettings.Checked = true;

            chkShowSettle.Checked = false;

            txtDiscount.Text = "0";
            txtGrandTotal.Text = "0";
            txtNBT.Text = "0";
            txtOtherTax.Text = "0";
            txtPercentageDiscount.Text = "0";
            txtSubTotal.Text = "0";
            txtVat.Text = "0";
            txtCurrencyRate.Text = "0.00";

            txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageOtherTax());
            txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageVAT());
            txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageNBT());

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
            dgvGenaral.Rows.Clear();
            dgvBreakdown.Rows.Clear();

            DisableMoneyControls();
            ClearFieldBreakdown();
            tbcItems.SelectedTab = tbpGenaral;

            FillDetailsCurrency(clsConfig.sLocalCurrencyCode);

            dtpGRNDate.Enabled = !clsConfig.bLock_TransactionDate_SCS;

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtGRNID.Text = "<Auto Generate>";
            else
                txtGRNID.Clear();
            if (txtGRNID.Enabled)
            {
                txtGRNID.SelectAll();
                txtGRNID.Focus();
            }

            tbcItems.TabPages.Remove(tbpBreakdown);

            Attachments.Clear();
        }
        #endregion

        #region Clear Fields Breakdown
        private void ClearFieldBreakdown()
        {
            txtbrk_QtyBreakdown.Clear();
            txtbrk_WeightBreakdown.Clear();

            dgvBreakdown.Rows.Clear();
            dgvBreakdown.Rows.Add();
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_scsExternalGoodReceivedNote detail = tbl_scsExternalGoodReceivedNote.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        if (detail.IsDeleted)
                        {
                            lblCancelled.Visible = true;
                        }
                        else
                        {
                            lblCancelled.Visible = false;
                        }

                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtGRNID, false);

                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, false);
                        clsCommon.SetEnableDisable_NormalTextbox(txtSupplierRefNo, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStockNoteType, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblIssuedRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblStoreID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblStockNoteType, false);

                        setEnableArea_PO(false);
                        setEnableArea_Supplier(false);
                        setEnableArea_StockNoteType(false);
                        if (detail.PurchaseOrder_ID.Length > 0 && detail.PurchaseOrder_ID != "default")
                            setEnableArea_Item(false);


                        //fill order detials
                        tbl_zIssuedRefNo Issued = tbl_zIssuedRefNo.Select(detail.IssuedRefNo_ID);
                        if (Issued != null)
                        {
                            txtSupplierRefNo.Tag = detail.IssuedRefNo_ID;
                            txtSupplierRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_IssuedRefNo(detail.IssuedRefNo_ID));
                        }

                        //asign values
                        txtSupplierID.Tag = detail.Supplier_ID;
                        txtManualNo.Text = detail.DeliveryOrderNumber;
                        txtStoreID.Tag = detail.Store_ID;
                        txtPoID.Tag = detail.PurchaseOrder_ID;
                        txtStockNoteType.Tag = detail.StockNoteType_ID;
                        txtCostCenter.Tag = detail.CostCenter;
                        txtGRNID.Tag = detail.ExternalGoodReceivedNote_ID;
                        txtPaymentMode.Tag = detail.PaymentMethod_ID;

                        txtSupplierID.Text = clsGenaralName.getName_Supplier(detail.Supplier_ID);
                        txtInvoiceNo.Text = detail.InvoiceNo;
                        txtStoreID.Text = clsGenaralName.getName_Store(detail.Store_ID);
                        txtPoID.Text = detail.PurchaseOrder_ID;
                        txtStockNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_StockNoteType(detail.StockNoteType_ID));
                        glbOrderRefNo = detail.IssuedRefNo_ID;
                        txtGRNID.Text = detail.ExternalGoodReceivedNote_ID;
                        dtpGRNDate.Value = detail.ExternalGoodReceivedNoteDate;

                        txtPaymentMode.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_PaymentMethod(detail.PaymentMethod_ID));
                        txtPaymentTerms.Text = detail.PaymentTerms;
                        txtCreditPeriod.Text = detail.CreditPeriod;
                        dtpDueDate.Value = detail.PaymentDueDate;
                        chkUnitPricing.Checked = !detail.IsWeightCalculation;
                        //chkSettings.Checked = false;

                        FillDetailsCurrency(detail.Currency_ID);
                        txtCurrencyRate.Text = detail.CurrencyRate.ToString();
                        txtCostCenter.Text = clsGenaralName.getName_AccCostCenter1(detail.CostCenter);

                        txtRemark.Text = detail.Remark;
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
                        RefreshGrid(detail.ExternalGoodReceivedNote_ID);

                        //Fill Process Flow
                        clsHelpMethods.SetProcessFlow_Stock_External(detail.IssuedRefNo_ID, txtFlowSR, txtFlowPO, txtFlowGRN, txtFlowPRN);

                        //Asign tax values after all calculation
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
                    }

                    Attachments.FillAttachments(sID);
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

        #region Fill Tax Detail By PO
        private void FillTaxDetailByPO(string sPurchaseOrderID)
        {
            try
            {
                tbl_scsPurchaseOrder detail = tbl_scsPurchaseOrder.Select(sPurchaseOrderID);
                if (detail != null)
                {
                    txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.DiscountPercentage);
                    txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                    txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);
                    txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);
                    txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.SubTotal, detail.ForexRate));
                    txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.DiscountTotal, detail.ForexRate));
                    txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.NbtTotal, detail.ForexRate));
                    txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.OtherTaxTotal, detail.ForexRate));
                    txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.VatTotal, detail.ForexRate));
                    txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.GrandTotal, detail.ForexRate));

                    chkDiscount.Checked = (detail.DiscountTotal > 0) ? true : false;
                    chkNBT.Checked = (detail.NbtTotal > 0) ? true : false;
                    chkVat.Checked = (detail.VatTotal > 0) ? true : false;
                    chkOtherTax.Checked = (detail.OtherTaxTotal > 0) ? true : false;

                    CalcualteSubTotal();
                    CalculateTaxesAndGrandTotal();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Breakdown Details
        private void FillDetailBreakdown_General(DataGridView dgvMyDatagrid)
        {
            try
            {
                ClearFieldBreakdown();

                string slineNo = dgvMyDatagrid["GenLineNo", dgvMyDatagrid.SelectedRows[0].Index].Value.ToString();
                string sItemID = dgvMyDatagrid["GenItemCode", dgvMyDatagrid.SelectedRows[0].Index].Value.ToString();
                string sItemSubCategoryID = dgvMyDatagrid["gItemSubCategoryID", dgvMyDatagrid.SelectedCells[0].RowIndex].Tag.ToString();
                string sItemSubCategoryID2 = dgvMyDatagrid["gItemSubCategoryID2", dgvMyDatagrid.SelectedCells[0].RowIndex].Tag.ToString();
                string sItemSerialNo = dgvMyDatagrid["gItemSerialNo", dgvMyDatagrid.SelectedCells[0].RowIndex].Value.ToString();
                string sItemSerialNo2 = dgvMyDatagrid["gItemSerialNo2", dgvMyDatagrid.SelectedCells[0].RowIndex].Value.ToString();

                int iLineNo = -1;
                if (int.TryParse(slineNo, out iLineNo))
                    iLineNo = int.Parse(slineNo);
                else
                    iLineNo = -1;

                RefreshGridBreakdownDetail(txtGRNID.Text.Trim(), iLineNo, sItemID, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                FillDetailBreakdown_Breakdown(dgvBreakdown);

                txtbrk_WeightGeneral.Text = dgvMyDatagrid["GenWeight", dgvGenaral.SelectedRows[0].Index].Value.ToString();
                txtbrk_QtyGeneral.Text = dgvMyDatagrid["GenQuantity", dgvGenaral.SelectedRows[0].Index].Value.ToString();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void FillDetailBreakdown_Breakdown(DataGridView dDataGrid)
        {
            try
            {
                decimal dQty = 0, dWeight = 0, dCount = 0;
                foreach (DataGridViewRow row in dDataGrid.Rows)
                {
                    dQty += clsValidate.ValidateGridValue(dDataGrid, "BrkQuantity", row.Index, decimal.Parse("0.00"));
                    dWeight += clsValidate.ValidateGridValue(dDataGrid, "BrkWeight", row.Index, decimal.Parse("0.00"));
                    dCount++;
                }

                txtbrk_WeightBreakdown.Text = clsFormatter.FormatDecimalPlaces_Weight(dWeight);
                txtbrk_QtyBreakdown.Text = clsFormatter.FormatDecimalPlaces_Quantity(dQty);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
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

                foreach (tbl_scsExternalGoodReceivedNote_Detail detail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(sGrnID).OrderBy(p => p.Line_No).ToList())
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    tbl_genItemMaster_Pricing oItem = tbl_genItemMaster_Pricing.Select(detail.Item_ID);
                    if (detail != null && oItem != null)
                    {
                        decimal dExRate = 0;
                        if (txtCurrencyRate.Text.Trim().Length > 0)
                            dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        Color cFontColor = detail.BHasBreakDown ? clsConfig.Font_Grid_Locked : clsConfig.Font_Grid_Active;
                        Fill_Datagrid(iRow, detail.Line_No, detail.Item_ID, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.PurchaseOrder_ID,
                           detail.PurchaseReturnedNote_ID, detail.BatchNo, item.IsTIEPItem, detail.Qty, detail.UnitPrice, detail.KiloPrice, detail.Weight, oItem.WeightedAverageCostPrice, detail.TatalAmount, detail.Warranty, detail.Remark, dExRate, cFontColor);
                    }
                }
                CusDataGridView_formatSrollBar_Main();
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
                tbl_genItemMaster_Pricing oItem = tbl_genItemMaster_Pricing.Select(sItemrID);
                if (detail != null && oItem != null)
                {
                    decimal dExRate = 0;
                    if (txtCurrencyRate.Text.Trim().Length > 0)
                        dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    clsCommon.ValidateForeignKey(ref txtItemSubCategory);
                    clsCommon.ValidateForeignKey(ref txtItemSerialNo, "0");

                    var maxLineNo = dgvDetail.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["LineNo"].Value));
                    Fill_Datagrid(iRow, maxLineNo, detail.Item_ID, txtItemSubCategory.Tag.ToString(), txtItemSubCategory.Text.Trim(), txtItemSerialNo.Tag.ToString(), txtItemSerialNo.Text.Trim(),
                        "default", "default", "", detail.IsTIEPItem, 0, oItem.CostPrice1, oItem.SellingPrice6, 0, oItem.WeightedAverageCostPrice, 0, 0, detail.Description, dExRate, clsConfig.Font_Grid_Active);
                }
                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();
                CusDataGridView_formatSrollBar_Main();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void RefreshGridByPurchaseOrderID(string sPurchaseOrder, bool bIsWaightCalculation)
        {
            try
            {
                int iRow;
                foreach (tbl_scsPurchaseOrder_Detail detail in tbl_scsPurchaseOrder_Detail.SelectAllByPurchaseOrder_ID(sPurchaseOrder).OrderBy(p => p.Line_No).ToList())
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    tbl_genItemMaster_Pricing oItem = tbl_genItemMaster_Pricing.Select(detail.Item_ID);
                    if (item != null & oItem != null)
                    {
                        decimal dExRate = 0;
                        if (txtCurrencyRate.Text.Trim().Length > 0)
                            dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());

                        if (clsConfig.bRemove_alreadyGRNitems_from_PO)
                        {
                            if (detail.Qty - detail.QtySettle > 0)
                            {
                                dgvDetail.Rows.Add();
                                iRow = dgvDetail.Rows.Count - 1;
                                Fill_Datagrid(iRow, detail.Line_No, item.Item_ID, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.PurchaseOrder_ID, "default", "",
                                    item.IsTIEPItem, detail.Qty - detail.QtySettle, detail.UnitPrice, detail.KiloPrice, detail.Weight - detail.WeightSettle, oItem.WeightedAverageCostPrice,
                                    bIsWaightCalculation ? ((detail.Weight - detail.WeightSettle) * detail.KiloPrice) : ((detail.Qty - detail.QtySettle) * detail.UnitPrice),
                                    0, detail.Remark, dExRate, clsConfig.Font_Grid_Active);
                            }
                        }
                        else
                        {
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            Fill_Datagrid(iRow, detail.Line_No, item.Item_ID, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.PurchaseOrder_ID, "default", "",
                                item.IsTIEPItem, detail.Qty - detail.QtySettle, detail.UnitPrice, detail.KiloPrice, detail.Weight - detail.WeightSettle, oItem.WeightedAverageCostPrice,
                                bIsWaightCalculation ? ((detail.Weight - detail.WeightSettle) * detail.KiloPrice) : ((detail.Qty - detail.QtySettle) * detail.UnitPrice),
                                0, detail.Remark, dExRate, clsConfig.Font_Grid_Active);
                        }
                    }
                }
                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();
                CusDataGridView_formatSrollBar_Main();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void RefreshGridBreakdownGenaral(string sGRNCode, string sItemID_ToBeSelected)
        {
            try
            {
                int iRow;
                dgvGenaral.Rows.Clear();

                foreach (tbl_scsExternalGoodReceivedNote_Detail detail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(sGRNCode).OrderBy(p => p.Line_No))
                {
                    dgvGenaral.Rows.Add();
                    iRow = dgvGenaral.Rows.Count - 1;
                    dgvGenaral["GenLineNo", iRow].Value = detail.Line_No.ToString();
                    dgvGenaral["GenItemCode", iRow].Value = detail.Item_ID;
                    dgvGenaral["GenItemName", iRow].Value = clsGenaralName.getName_Item(detail.Item_ID);
                    dgvGenaral["GenWeight", iRow].Value = clsFormatter.FormatToNumberWithFourDecimalPlaces(detail.Weight);
                    dgvGenaral["GenQuantity", iRow].Value = clsFormatter.FormatToNumberNoDecimal(detail.Qty);

                    dgvGenaral["gItemSubCategoryID", iRow].Tag = detail.ItemSubCategory_ID;
                    dgvGenaral["gItemSubCategoryID", iRow].Value = clsGenaralName.getName_ItemSubCategory(detail.ItemSubCategory_ID);
                    dgvGenaral["gItemSubCategoryID2", iRow].Tag = detail.ItemSubCategory2_ID;
                    dgvGenaral["gItemSubCategoryID2", iRow].Value = clsGenaralName.getName_ItemSubCategory2(detail.ItemSubCategory2_ID);
                    dgvGenaral["gItemSerialNo", iRow].Value = detail.ItemSerialNo;
                    dgvGenaral["gItemSerialNo2", iRow].Value = detail.ItemSerialNo2;

                    if (sItemID_ToBeSelected == detail.Item_ID)
                        dgvGenaral.Rows[iRow].Selected = true;
                }
                CusDataGridView_FormatScrollBar_General();

                if (dgvGenaral.SelectedRows.Count > 0)
                    FillDetailBreakdown_General(dgvGenaral);


                dgvBreakdown.Select();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridBreakdownDetail(string sGRNCode, int iLineNo, string sItemID, string sItemSubCategoryID, string sItemSubCategoryID2, string sItemSerialNo, string sItemSerialNo2)
        {
            try
            {
                int iRow;
                dgvBreakdown.Rows.Clear();

                foreach (tbl_scsExternalGoodReceivedNote_DetailBreakdown detail in tbl_scsExternalGoodReceivedNote_DetailBreakdown.SelectAllByExternalGoodReceivedNote_ID(sGRNCode).Where(p => p.Item_ID == sItemID && p.ItemSubCategory_ID == sItemSubCategoryID && p.ItemSubCategory2_ID == sItemSubCategoryID2 && p.ItemSerialNo2 == sItemSerialNo2).OrderBy(p => p.Line_No))
                {
                    if (detail.Line_No == iLineNo && detail.Item_ID == sItemID)
                    {
                        dgvBreakdown.Rows.Add();
                        iRow = dgvBreakdown.Rows.Count - 1;
                        dgvBreakdown["BrkLineNo", iRow].Value = detail.Line_No.ToString();
                        dgvBreakdown["BrkSerialNo", iRow].Value = detail.SerialNo;
                        dgvBreakdown["BrkRemarks", iRow].Value = detail.Remark;
                        dgvBreakdown["BrkItemCode", iRow].Value = detail.Item_ID;
                        dgvBreakdown["BrkWeight", iRow].Value = clsFormatter.FormatToNumberWithFourDecimalPlaces(detail.Weight);
                        dgvBreakdown["BrkQuantity", iRow].Value = clsFormatter.FormatToNumberNoDecimal(detail.Qty);
                    }
                }
                dgvBreakdown.Rows.Add();
                iRow = dgvBreakdown.Rows.Count - 1;
                dgvBreakdown["BrkLineNo", iRow].Value = iRow + 1;
                dgvBreakdown["BrkSerialNo", iRow].Selected = true;

                CusDataGridView_FormatScrollBar_BreakDown();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Events KeyDown
        private void txtInvoiceID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtInvoiceID_DoubleClick(null, null);
        }

        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Supplier();
        }

        private void txtDeliveryOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_PurchesOrder();
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

        private void txtPRNID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_PurchesReturnNote();
        }
        private void txtStockNoteType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_StockNoteType();
        }

        private void txtCurrencyID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Currency();
        }

        private void txtSubAccount1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtSubAccount1_DoubleClick(null, null);
        }
        #endregion

        #region Event Key Press
        private void txtCurrencyRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength(txtCurrencyRate, e, 18, 6);
        }
        #endregion

        #region Event Button Leave
        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            if (txtDiscount.TextLength > 0 && clsCommon.isCurrency(txtDiscount.Text.Trim()) && decimal.Parse(txtDiscount.Text.Trim()) > 0)
            {
                txtDiscount.Tag = txtDiscount.Text.Trim();
                txtPercentageDiscount.Text = "0";
            }
            else
                txtDiscount.Tag = "0";

            CalculateTaxesAndGrandTotal();
        }
        #endregion

        #region Events Double Click
        private void txtInvoiceID_DoubleClick(object sender, EventArgs e)
        {
            Search_ExternalGoodReceivedNoteID();
        }

        private void txtCustomerID_DoubleClick(object sender, EventArgs e)
        {
            Search_Supplier();
        }

        private void txtDeliveryOrder_DoubleClick(object sender, EventArgs e)
        {
            Search_PurchesOrder();
        }

        private void txtItemID_DoubleClick(object sender, EventArgs e)
        {
            Search_Item();
        }

        private void txtStoreID_DoubleClick(object sender, EventArgs e)
        {
            Search_Store();
        }
        private void txtStockNoteType_DoubleClick(object sender, EventArgs e)
        {
            Search_StockNoteType();
        }
        private void txtPRNID_DoubleClick(object sender, EventArgs e)
        {
            Search_PurchesReturnNote();
        }

        private void txtCurrencyID_DoubleClick(object sender, EventArgs e)
        {
            Search_Currency();
        }

        private void txtSubAccount1_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_costCenter1(ref txtCostCenter);
        }

        private void txtPaymentMode_DoubleClick_1(object sender, EventArgs e)
        {
            clsSearch.Search_MasterPaymentMethod(ref txtPaymentMode);
        }
        #endregion

        #region Events KeyUp
        private void txtPercentageOtherTax_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }
        private void txtPercentageDiscount_KeyUp(object sender, KeyEventArgs e)
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
                txtDiscount.Text = "0.00";
                txtDiscount.Tag = "0";
                CalculateTaxesAndGrandTotal();
            }
        }
        private void chkNBT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNBT.Checked)
            {
                txtPercentageNBT.Enabled = true;
                chkVat.Checked = true;
            }
            else
                txtPercentageNBT.Enabled = false;

            CalculateTaxesAndGrandTotal();
        }
        private void chkVat_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVat.Checked)
            {
                chkOtherTax.Checked = false;

                if (clsConfig.bEnable_TAX_ManualMode)
                    txtPercentageVat.Enabled = true;
            }
            else
                txtPercentageVat.Enabled = false;

            CalculateTaxesAndGrandTotal();
        }
        private void chkOtherTax_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOtherTax.Checked)
            {
                chkVat.Checked = false;

                if (clsConfig.bEnable_TAX_ManualMode)
                    txtPercentageOtherTax.Enabled = true;
            }
            else
                txtPercentageOtherTax.Enabled = false;

            CalculateTaxesAndGrandTotal();
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
        private void txtPercentageNBT_TextChanged(object sender, EventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }
        private void txtPercentageVat_TextChanged(object sender, EventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }
        private void txtPercentageOtherTax_TextChanged(object sender, EventArgs e)
        {
            CalculateTaxesAndGrandTotal();
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
        private void dgvBreakdown_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (dgvGenaral.SelectedRows.Count > 0)
                    {
                        string sColName = "";
                        if (e.ColumnIndex >= 0)
                            sColName = dgvBreakdown.Columns[e.ColumnIndex].Name;

                        if (sColName == "BrkSerialNo") //Serial No  
                        {
                            dgvBreakdown["BrkQuantity", e.RowIndex].Value = 1;
                            dgvBreakdown["BrkWeight", e.RowIndex].Value = 0;

                            //validate same serial No                        
                            if (CheckValidity_SerialNo(e))
                            {
                                dgvBreakdown.Rows.Add();
                                try { dgvBreakdown["BrkSerialNo", e.RowIndex + 1].Selected = true; }
                                catch (Exception) { }
                            }
                        }
                    }
                    FillDetailBreakdown_Breakdown(dgvBreakdown);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void dgvGenaral_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillDetailBreakdown_General(dgvGenaral);
        }
        private void dgvGenaral_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvGenaral_CellClick(sender, e);
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
        private void Search_ExternalGoodReceivedNoteID()
        {
            try
            {
                if (txtStockNoteType.Tag != null)
                    clsSearch.Search_TransactionExternalGoodReceivedNote_Direct(ref txtGRNID, chkShowSettle.Checked, txtStockNoteType.Tag.ToString());
                else
                    clsSearch.Search_TransactionExternalGoodReceivedNote_Direct(ref txtGRNID, chkShowSettle.Checked, false, txtSupplierID.Tag != null ? txtSupplierID.Tag.ToString() : "", "");

                if (txtGRNID.Tag != null && txtGRNID.Tag.ToString().Trim().Length > 0)
                    FillDetails(txtGRNID.Tag.ToString());

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_Item()
        {
            if (CheckValiditySupplier())
            {
                clsHelpMethods.SearchItemAdvance(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo);
                if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0)
                    btnAddItem_Click(btnAddItem, new EventArgs());
            }
        }
        private void Search_Store()
        {
            clsSearch.Search_MasterStore(ref txtStoreID, true);
        }
        private void Search_PurchesOrder()
        {
            if (txtStockNoteType.Tag != null)
                clsSearch.Search_TransactionPurchaseOrder_Direct(ref txtPoID, txtSupplierID.Tag.ToString(), false, true);
            else
                clsSearch.Search_TransactionPurchaseOrder_Direct(ref txtPoID, "", false, true);

            if (txtPoID.Tag != null && txtPoID.Tag.ToString().Trim() != "default")
                btnAddPurchaseOrder_Click(null, null);
        }
        private void Search_PurchesReturnNote()
        {
            if (CheckValidity_EmptyField())
                clsSearch.Search_MasterPurchaseReturnNote(ref txtPRNID);
        }
        private void Search_Supplier()
        {
            clsSearch.Search_MasterSupplier(ref txtSupplierID);
        }
        private void Search_Currency()
        {
            clsSearch.Search_MasterCurrency(ref txtCurrencyID);
            if (txtCurrencyID.Tag != null)
                FillDetailsCurrency(txtCurrencyID.Tag.ToString());
            else
                FillDetailsCurrency(clsConfig.sLocalCurrencyCode);
        }
        private void Search_StockNoteType()
        {
            clsSearch.Search_MasterStockNoteType(ref txtStockNoteType);
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField_PONo())
            {
                if (CheckValidity_EmptyField())
                {
                    if (CheckNumberValidity())
                    {
                        if (clsValidate.CheckGridCountValidity(dgvDetail.RowCount, iFormID))
                        {
                            if (CheckValidityQty(IsUpdate))
                            {
                                if (CheckStockValidity(txtGRNID.Text.Trim(), IsUpdate))
                                {
                                    if (CheckSupplierSaveValidity(txtSupplierID.Tag.ToString()))
                                    {
                                        if (ValidityFIFOQty())
                                        {
                                            if (clsMethods_GL.CheckValidity_FinancialYear(dtpGRNDate.Value.Date))
                                            {
                                                if (CheckValidity_SerialNo_Duplication())
                                                {
                                                    if (CheckValidity_SerialNo_QtyValidation())
                                                    {
                                                        if (CheckValidity_CostPrice())
                                                        {
                                                            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                                                            {
                                                                if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreID.Tag.ToString(), IsUpdate))
                                                                {
                                                                    if (CheckValidity_WATollarance())
                                                                    {
                                                                        if (CheckValidity_Posting())
                                                                        {
                                                                            ValidateEmptyForeignKey();
                                                                            validateAccountCode2();

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
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return bStatus;
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

                dtGrid.Rows.Add(iLineNo, sItemCode, dQty, dUnitPrice);
            }
            #endregion

            #region Copy Saved value
            foreach (tbl_scsExternalGoodReceivedNote_Detail oDetail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(txtGRNID.Text.Trim()))
            {
                DB.Add(new tbl_Detail(oDetail.Line_No, oDetail.Item_ID, oDetail.Qty, oDetail.UnitPrice));
            }
            #endregion

            return clsHelpMethods.CheckValidity_WATollarance(dtGrid, DB);
        }

        private bool CheckValidity_Posting()
        {
            bool bStatus = false;
            if (clsConfig.bAutoPostingEnable && clsConfig.bAutoPostingEnable_Stock)
            {
                bool bSlotStatus_Inventry = clsMethods_GL.CheckAccountLink(AccSlot.GoodReceivedNote, true);
                bool bSlotStatus_ClosingStock = clsMethods_GL.CheckAccountLink(AccSlot.Customer_DebitNote, true);

                if (bSlotStatus_Inventry && bSlotStatus_ClosingStock)
                    bStatus = true;
            }
            else
                bStatus = true;

            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtStoreID, "Store Name"))
            {
                if (clsValidate.ValidateTextBox_EmptyValue(txtSupplierID, "Supplier Name"))
                {
                    if (clsValidate.ValidateTextBox_EmptyValue(txtCurrencyRate, "Currency Rate"))
                    {
                        if (clsValidate.ValidateTextBox_EmptyValue(txtStockNoteType, "Note Type"))
                        {
                            bStatus = true;
                        }
                    }
                }
            }
            return bStatus;
        }

        private bool CheckValidity_CostPrice()
        {
            bool bStatus = true, bShowMessage = false;
            try
            {
                string strMessage = "";
                string sItem = "";

                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    string sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                    string sItemName = clsValidate.ValidateGridValue(dgvDetail, "ItemName", row.Index, "");
                    decimal dCostPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                    decimal dWeightedAvg = clsValidate.ValidateGridValue(dgvDetail, "WeightAvg", row.Index, decimal.Parse("0.00"));

                    if (dWeightedAvg > 0)
                    {
                        decimal dWeightedAvgPer = dWeightedAvg + ((dWeightedAvg * decimal.Parse(clsConfig.sWeightedAvg_Percentage)) / 100);

                        if (dCostPrice > dWeightedAvgPer)
                        {
                            sItem += sItemCode + " - " + sItemName + "\n";
                            bShowMessage = true;
                            continue;
                        }
                    }
                }

                if (bShowMessage == true)
                {
                    strMessage = "Entered Cost Price is greater than the previous Weighted Average \nfor following Items. \nDo you want to continue? \n";

                    DialogResult msgResult = MessageBox.Show(strMessage + sItem, clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msgResult == DialogResult.Yes)
                        bStatus = true;
                    else
                        bStatus = false;
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

            return bStatus;
        }
        private bool CheckValidity_EmptyField_PONo()
        {
            bool bStatus = false;

            if (clsConfig.bEnableMandatory_PONo_for_GRN)
            {
                if (clsValidate.ValidateTextBox_EmptyValue(txtPoID, "Purchase Order No."))
                    bStatus = true;
            }
            else
                bStatus = true;

            return bStatus;
        }
        private bool CheckValiditySupplier()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (txtSupplierID.Tag == null)
                {
                    strMessage += "\n" + "Supplier Name ";
                    bStatus = false;
                }

                if (bStatus == false)
                    MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
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
        private void validateAccountCode2()
        {
            if (txtCostCenter.Tag == null)
            {
                txtCostCenter.Tag = "default";
                txtCostCenter.Text = "default";
            }
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
                    strMessage += "\n Discount Pasentage";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtVat.Text.Trim()))
                {
                    strMessage += "\n VAT Total";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtPercentageVat.Text.Trim()))
                {
                    strMessage += "\n VAT pacentage";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtNBT.Text.Trim()))
                {
                    strMessage += "\n NBT Total";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtPercentageVat.Text.Trim()))
                {
                    strMessage += "\n NBT pacentage";
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
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return bStatus;
        }
        private bool CheckValidityQty(bool IsUpdate)
        {
            bool bStatus = true;//bOk = true,
            string strMessage = "";

            try
            {
                #region Check QTY Validity

                if (clsConfig.isEnable_QuantityExceedPercentageLock_GRN)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add(new DataColumn("po_id", typeof(string)));
                    dt.Columns.Add(new DataColumn("itemID", typeof(string)));
                    dt.Columns.Add(new DataColumn("qty", typeof(decimal)));
                    dt.Columns.Add(new DataColumn("subCat1", typeof(string)));
                    dt.Columns.Add(new DataColumn("subCat2", typeof(string)));
                    dt.Columns.Add(new DataColumn("serial1", typeof(string)));
                    dt.Columns.Add(new DataColumn("serial2", typeof(string)));

                    foreach (DataGridViewRow row in dgvDetail.Rows)
                    {
                        string sPurchaceOrder_o = clsValidate.ValidateGridValue(dgvDetail, "POID", row.Index, "");
                        string sItemCode_o = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                        decimal dQty_o = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                        //decimal dWeight_o = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                        string sItemSubCategoryID1_o = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                        string sItemSubCategoryID2_o = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                        string sItemSerialNo1_o = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                        string sItemSerialNo2_o = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                        //string sPOID_o = clsValidate.ValidateGridValue(dgvDetail, "POID", row.Index, "default");
                        //string sPRNID_o = clsValidate.ValidateGridValue(dgvDetail, "PRNID", row.Index, "default");
                        //string sBatch_o = clsValidate.ValidateGridValue(dgvDetail, "Batch", row.Index, "");
                        //string sUom_o = clsValidate.ValidateGridValue(dgvDetail, "UOM", row.Index, "default");

                        DataRow dr = dt.NewRow();
                        dr["po_id"] = sPurchaceOrder_o;
                        dr["itemID"] = sItemCode_o;
                        dr["qty"] = dQty_o;
                        dr["subCat1"] = sItemSubCategoryID1_o;
                        dr["subCat2"] = sItemSubCategoryID2_o;
                        dr["serial1"] = sItemSerialNo1_o;
                        dr["serial2"] = sItemSerialNo2_o;

                        dt.Rows.Add(dr);

                    }

                    dt = dt.AsEnumerable()
              .GroupBy(r => r["itemID"])
              .Select(g =>
              {
                  var row = dt.NewRow();

                  row["itemID"] = g.Key;
                  row["qty"] = g.Sum(r => r.Field<decimal>("qty"));

                  return row;
              }).CopyToDataTable();


                    string sItemCode = "", sItemSubCategoryID1 = "", sItemSubCategoryID2 = "", sItemSerialNo1 = "", sItemSerialNo2 = "";
                    decimal dQty = 0;

                    foreach (DataRow row2 in dt.Rows)
                    {
                        sItemCode = clsValidate.ValidateRowValue(row2, "itemID", "");
                        dQty = clsValidate.ValidateRowValue(row2, "qty", decimal.Parse("0.00"));
                        //decimal dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                        sItemSubCategoryID1 = clsValidate.ValidateRowValue(row2, "subCat1", "default");
                        sItemSubCategoryID2 = clsValidate.ValidateRowValue(row2, "subCat2", "default");
                        sItemSerialNo1 = clsValidate.ValidateRowValue(row2, "serial1", "0");
                        sItemSerialNo2 = clsValidate.ValidateRowValue(row2, "serial2", "0");
                        //}

                        decimal dExceedPacentage = 0;
                        if (txtSupplierID.Tag != null && txtSupplierID.Tag.ToString().Length > 0)
                            dExceedPacentage = (clsCommon.isLocalSupplier(txtSupplierID.Tag.ToString()) ? decimal.Parse(clsConfig.sMaximumQuntityExceededPercentage_localOrders) : decimal.Parse(clsConfig.sMaximumQuntityExceededPercentage_ExportOrders));

                        if (IsUpdate)
                        {
                            #region Old Record
                            if (chkUnitPricing.Checked)  // Qty
                            {
                                decimal dOldPOQty = 0, dOldPOQty_Settled = 0;
                                List<tbl_scsPurchaseOrder_Detail> oldPoDetails = tbl_scsPurchaseOrder_Detail.SelectAllByPurchaseOrder_ID(txtPoID.Text.Trim());
                                //foreach (tbl_scsPurchaseOrder_Detail oldPoDetail in oldPoDetails)
                                var oPO = oldPoDetails.GroupBy(cm => new { cm.Item_ID, cm.ItemSubCategory_ID, cm.ItemSubCategory2_ID, cm.ItemSerialNo, cm.ItemSerialNo2 }, (key, group) => new { itemId = key.Item_ID, subCat1 = key.ItemSubCategory_ID, subCat2 = key.ItemSubCategory2_ID, serial1 = key.ItemSerialNo, serial2 = key.ItemSerialNo2, qty = group.Sum(p => p.Qty), qtySettles = group.Sum(p => p.QtySettle) });
                                foreach (var oldPoDetail in oPO.OrderBy(p => (p.itemId)))
                                {
                                    if (oldPoDetail.itemId == sItemCode && oldPoDetail.subCat1 == sItemSubCategoryID1 && oldPoDetail.subCat2 == sItemSubCategoryID2 && oldPoDetail.serial1 == sItemSerialNo1 && oldPoDetail.serial2 == sItemSerialNo2)
                                    {
                                        dOldPOQty = oldPoDetail.qty;
                                        dOldPOQty_Settled = oldPoDetail.qtySettles;
                                    }
                                }

                                List<tbl_scsExternalGoodReceivedNote_Detail> oldGrnDetails = tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(txtGRNID.Text.Trim());
                                //foreach (tbl_scsExternalGoodReceivedNote_Detail oldGrnDetail in oldGrnDetails)
                                var oGRN = oldGrnDetails.GroupBy(cm => new { cm.Item_ID, cm.ItemSubCategory_ID, cm.ItemSubCategory2_ID, cm.ItemSerialNo, cm.ItemSerialNo2 }, (key, group) => new { itemId = key.Item_ID, subCat1 = key.ItemSubCategory_ID, subCat2 = key.ItemSubCategory2_ID, serial1 = key.ItemSerialNo, serial2 = key.ItemSerialNo2, qty = group.Sum(p => p.Qty), qtySettles = group.Sum(p => p.QtySettle) });
                                foreach (var oldGrnDetail in oGRN.OrderBy(p => (p.itemId)))
                                {
                                    //if (oldGrnDetail.Item_ID == sItemCode && oldGrnDetail.ItemSubCategory_ID == sItemSubCategoryID1 && oldGrnDetail.ItemSubCategory2_ID == sItemSubCategoryID2 && oldGrnDetail.ItemSerialNo == sItemSerialNo1 && oldGrnDetail.ItemSerialNo2 == sItemSerialNo2)
                                    if (oldGrnDetail.itemId == sItemCode)
                                    {
                                        //decimal dDeliveryQty = (oldGrnDetail.QtySettle - dOldPOQty) + dQty;
                                        decimal dDeliveryQty = (dOldPOQty_Settled - oldGrnDetail.qty) + dQty;
                                        //if (dDeliveryQty > oldGrnDetail.Qty) //qty is exceeding the order qty
                                        if (dDeliveryQty > dOldPOQty) //qty is exceeding the order qty
                                        {
                                            decimal dMaxValue = ((dExceedPacentage + 100) / 100) * oldGrnDetail.qty;
                                            if (dMaxValue < dDeliveryQty)
                                            {
                                                bStatus = false;
                                                strMessage = "Delivery Qty Can't Exceed the the Ordered QTY....!";
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                #region weight
                                decimal dOldPoWeight = 0;
                                List<tbl_scsPurchaseOrder_Detail> oldPoDetails = tbl_scsPurchaseOrder_Detail.SelectAllByPurchaseOrder_ID(txtPoID.Text.Trim());
                                foreach (tbl_scsPurchaseOrder_Detail oldPoDetail in oldPoDetails)
                                {
                                    if (oldPoDetail.Item_ID == sItemCode && oldPoDetail.ItemSubCategory_ID == sItemSubCategoryID1 && oldPoDetail.ItemSubCategory2_ID == sItemSubCategoryID2 && oldPoDetail.ItemSerialNo == sItemSerialNo1 && oldPoDetail.ItemSerialNo2 == sItemSerialNo2)
                                    {
                                        dOldPoWeight = oldPoDetail.Weight;
                                    }
                                }

                                List<tbl_scsExternalGoodReceivedNote_Detail> oldPrnDetails = tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(txtGRNID.Text.Trim());
                                foreach (tbl_scsExternalGoodReceivedNote_Detail oldPrnDetail in oldPrnDetails)
                                {
                                    if (oldPrnDetail.Item_ID == sItemCode && oldPrnDetail.ItemSubCategory_ID == sItemSubCategoryID1 && oldPrnDetail.ItemSubCategory2_ID == sItemSubCategoryID2 && oldPrnDetail.ItemSerialNo == sItemSerialNo1 && oldPrnDetail.ItemSerialNo2 == sItemSerialNo2)
                                    {
                                        decimal dDeliveryWeight = (oldPrnDetail.WeightSettle - dOldPoWeight) + dQty;
                                        if (dDeliveryWeight > oldPrnDetail.Weight) //qty is exceeding the order qty
                                        {
                                            decimal dMaxValue = ((dExceedPacentage + 100) / 100) * oldPrnDetail.Weight;
                                            if (dMaxValue < dDeliveryWeight)
                                            {
                                                bStatus = false;
                                                strMessage = "Delivery Qty Can't Exceed the the Ordered QTY....!";
                                            }
                                        }
                                    }
                                }
                                #endregion
                            }
                            #endregion
                        }
                        else // insert
                        {
                            #region New Record
                            if (chkUnitPricing.Checked)  // Qty
                            {
                                List<tbl_scsPurchaseOrder_Detail> oldPoDetails = tbl_scsPurchaseOrder_Detail.SelectAllByPurchaseOrder_ID(txtPoID.Text.Trim()).ToList();
                                //foreach (tbl_scsPurchaseOrder_Detail oldPoDetail in oldPoDetails)

                                var oPO = oldPoDetails.GroupBy(cm => new { cm.Item_ID, cm.ItemSubCategory_ID, cm.ItemSubCategory2_ID, cm.ItemSerialNo, cm.ItemSerialNo2 }, (key, group) => new { itemId = key.Item_ID, subCat1 = key.ItemSubCategory_ID, subCat2 = key.ItemSubCategory2_ID, serial1 = key.ItemSerialNo, serial2 = key.ItemSerialNo2, qty = group.Sum(p => p.Qty), qtySettles = group.Sum(p => p.QtySettle) });

                                foreach (var oldPoDetail in oPO.OrderBy(p => (p.itemId)))
                                {
                                    //if (oldPoDetail.itemId == sItemCode && oldPoDetail.subCat1 == sItemSubCategoryID1 && oldPoDetail.subCat2 == sItemSubCategoryID2 && oldPoDetail.serial1 == sItemSerialNo1 && oldPoDetail.serial2 == sItemSerialNo2)
                                    if (oldPoDetail.itemId == sItemCode)
                                    {
                                        decimal dDeliveryQty = dQty + oldPoDetail.qtySettles;
                                        if (dDeliveryQty > oldPoDetail.qty) //qty is exceeding the order qty
                                        {
                                            decimal dMaxValue = ((dExceedPacentage + 100) / 100) * oldPoDetail.qty;
                                            if (dMaxValue < dDeliveryQty)
                                            {
                                                bStatus = false;
                                                strMessage = "Delivery Qty Can't Exceed the the Ordered QTY....!";
                                            }
                                        }
                                    }
                                }
                            }
                            else   // weight
                            {
                                List<tbl_scsExternalGoodReceivedNote_Detail> oldPrnDetails = tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(txtGRNID.Text.Trim());
                                foreach (tbl_scsExternalGoodReceivedNote_Detail oldPrnDetail in oldPrnDetails)
                                {
                                    if (oldPrnDetail.Item_ID == sItemCode && oldPrnDetail.ItemSubCategory_ID == sItemSubCategoryID1 && oldPrnDetail.ItemSubCategory2_ID == sItemSubCategoryID2 && oldPrnDetail.ItemSerialNo == sItemSerialNo1 && oldPrnDetail.ItemSerialNo2 == sItemSerialNo2)
                                    {
                                        decimal dDeliveryWeight = dQty + oldPrnDetail.WeightSettle;
                                        if (dDeliveryWeight > oldPrnDetail.Weight) //Weight is exceeding the order qty
                                        {
                                            decimal dMaxValue = ((dExceedPacentage + 100) / 100) * oldPrnDetail.Weight;
                                            if (dMaxValue < dDeliveryWeight)
                                            {
                                                bStatus = false;
                                                strMessage = "Delivery Qty Can't Exceed the the Ordered QTY....!";
                                            }
                                        }

                                    }
                                }
                            }
                            #endregion
                        }

                        //if (bStatus == false)
                        //    MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //}

                    if (bStatus == false)
                        MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                #endregion

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

            return bStatus;
        }
        private bool CheckStockValidity(string sNoteID, bool bIsUpdate)
        {
            bool bStatus = true;


            try
            {
                string strMessage = "", sItemCode = "", sJobCode = "", sSubcategory1 = "", sSubcategory2 = "", sSerial1 = "", sSerial2 = "", sMsg = "";
                decimal dWeightActual = 0;
                decimal dQty = 0;
                if (bIsUpdate)
                    sMsg = "Modify";
                else
                    sMsg = "Cancel";

                foreach (tbl_scsExternalGoodReceivedNote_Detail GRNdetail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(sNoteID))
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

                    tbl_genStore_Stock stock = tbl_genStore_Stock.Select(txtStoreID.Tag.ToString(), sItemCode, sJobCode, sSubcategory1, sSubcategory2, sSerial1, sSerial2);
                    if (stock != null)
                    {
                        if (stock.Weight < dWeightActual)
                        {
                            strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + " Stocks-in-hand is Not Sufficient Weight to " + sMsg + " this note \n";
                            bStatus = false;
                        }
                        if (stock.Qty < dQty)
                        {
                            strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + " Stocks-in-hand is Not Sufficient Quantity to " + sMsg + " this note \n";
                            bStatus = false;
                        }
                    }
                    else
                    {
                        strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + " Is Not Available In " + clsGenaralName.getName_Section(txtStoreID.Tag.ToString()) + " Stock\n";
                        bStatus = false;
                    }
                }

                if (bStatus == false)
                    MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bStatus;
        }
        private bool ValidateForDependancies(string sGRNId)
        {
            bool bValue = true;
            try
            {
                foreach (tbl_accAccountPayableNote oAPN in tbl_accAccountPayableNote.SelectAllByExternalGoodReceivedNote_ID(sGRNId).Where(p => !p.IsDeleted && p.AccountPayableNote_ID != "default"))
                {
                    bValue = false;
                    MessageBox.Show("Record Is Locked! \n\n[" + oAPN.AccountPayableNote_ID + "] GRN is already created for this APN", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                if (bValue)
                {
                    foreach (tbl_scsPurchaseReturnedNote_Detail oPRN in tbl_scsPurchaseReturnedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(sGRNId))
                    {
                        tbl_scsPurchaseReturnedNote detail = tbl_scsPurchaseReturnedNote.Select(oPRN.PurchaseReturnedNote_ID);
                        if (detail != null && detail.PurchaseReturnedNote_ID != "default" && !detail.IsDeleted)
                        {
                            bValue = false;
                            MessageBox.Show("Record Is Locked! \n\n[" + detail.PurchaseReturnedNote_ID + "] Purchase Returned Note is already created for this GRN", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }
                }

                if (bValue)
                {
                    foreach (tbl_scsDocument_Barcode oBarcode in tbl_scsDocument_Barcode.SelectAll().Where(p => p.Transaction_ID == sGRNId))
                    {
                        foreach (tbl_scsFixedAsset oFA in tbl_scsFixedAsset.SelectAllByBarcode_ID(oBarcode.Barcode_ID))
                        {
                            bValue = false;
                            MessageBox.Show("Record Is Locked! \n\n A Fixed Asset is already registered for this GRN", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                        if (!bValue)
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bValue;
        }
        private bool CheckValidity_SerialNo(DataGridViewCellEventArgs e)
        {
            bool bValue = true;

            try
            {
                if (!clsConfig.bItemSerialNo_EnableDuplication_GRN)
                {
                    foreach (DataGridViewRow row in dgvBreakdown.Rows)
                    {
                        if (e.RowIndex != row.Index)
                        {
                            string sSerialNo_Grid = clsValidate.ValidateGridValue(dgvBreakdown, "BrkSerialNo", row.Index, "");
                            string sSerialNo_Current = clsValidate.ValidateGridValue(dgvBreakdown, "BrkSerialNo", e.RowIndex, "");
                            if (sSerialNo_Current == "")
                            {
                                MessageBox.Show("Serial Number cannot be Empty", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bValue = false;
                                break;
                            }
                            else if (sSerialNo_Current == sSerialNo_Grid)
                            {
                                MessageBox.Show("Serial Number cannot be Duplicated", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bValue = false;
                                break;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bValue;
        }
        private bool CheckValidity_SerialNo_Duplication()
        {
            bool bValue = true;
            try
            {
                if (!clsConfig.bItemSerialNo_EnableDuplication_GRN)
                {
                    foreach (DataGridViewRow row in dgvBreakdown.Rows)
                    {
                        string sSerialNo_Grid = clsValidate.ValidateGridValue(dgvBreakdown, "BrkSerialNo", row.Index, "");
                        if (sSerialNo_Grid.Length > 0)
                        {
                            foreach (DataGridViewRow row2 in dgvBreakdown.Rows)
                            {
                                if (row2.Index != row.Index)
                                {
                                    string sSerialNo_Current = clsValidate.ValidateGridValue(dgvBreakdown, "BrkSerialNo", row2.Index, "");
                                    if (sSerialNo_Current == sSerialNo_Grid)
                                    {
                                        MessageBox.Show("Serial Number cannot be Duplicated", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        bValue = false;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bValue;
        }
        private bool CheckValidity_SerialNo_QtyValidation()
        {
            bool bValue = true;
            try
            {
                if (clsConfig.bItemSerialNo_EnableQtyValidation_GRNDetailvsSerial)
                {
                    if (dgvBreakdown.Rows.Count > 0 && dgvGenaral.Rows.Count > 0)
                    {
                        decimal dQty_Detail = clsValidate.ValidateGridValue(dgvGenaral, "GenQuantity", dgvGenaral.SelectedRows[0].Index, 0);
                        decimal dQty_Breakdown = 0;
                        foreach (DataGridViewRow row in dgvBreakdown.Rows)
                            dQty_Breakdown += clsValidate.ValidateGridValue(dgvBreakdown, "BrkQuantity", row.Index, 0);

                        if (dQty_Detail != dQty_Breakdown)
                        {
                            MessageBox.Show("Item Qunatity and Serial Numbers are not Tallying", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bValue = false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bValue;
        }

        private bool CheckCancelValidity_WATollarance()
        {
            List<tbl_Detail> DB = new List<tbl_Detail>();
            foreach (tbl_scsExternalGoodReceivedNote_Detail oDetail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(txtGRNID.Text.Trim()))
            {
                DB.Add(new tbl_Detail(oDetail.Line_No, oDetail.Item_ID, oDetail.Qty, oDetail.UnitPrice));
            }
            return clsHelpMethods.CheckCancelValidity_WATollarance(DB);
        }
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtItemID);
                clsCommon.ValidateForeignKey(ref txtStoreID);
                clsCommon.ValidateForeignKey(ref txtSupplierID);
                clsCommon.ValidateForeignKey(ref txtPoID);
                clsCommon.ValidateForeignKey(ref txtPRNID);
                clsCommon.ValidateForeignKey(ref txtItemSubCategory);
                clsCommon.ValidateForeignKey(ref txtItemSerialNo);
                clsCommon.ValidateForeignKey(ref txtCurrencyID);
                clsCommon.ValidateForeignKey(ref txtPaymentMode);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
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
                txtSubTotal.Tag = clsFormatter.FormatToCurrecyWithThousendSep(Amount); //Amount;
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

        #region Calculate Taxes and GrandTotal
        private void CalculateTaxesAndGrandTotal()
        {
            txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.CalculateGrandTotalAdvance_Round(txtSubTotal, txtDiscount, txtPercentageDiscount, chkDiscount,
                txtNBT, txtPercentageNBT, chkNBT, txtVat, txtPercentageVat, chkVat, txtOtherTax, txtPercentageOtherTax, chkOtherTax));
        }
        #endregion

        #region Fill Datagrid
        private void Fill_Datagrid(int iRow, int iLineNo, string ItemID, string ItemSubCategoryID1, string ItemSubCategoryID2, string ItemSerialNo1, string ItemSerialNo2, string PurchaseOrderID, string sPRNID, string sBatch, bool bIsTiep, decimal Quantity, decimal UnitPrice, decimal WeightPrice, decimal Weight, decimal WeightAvg,
        decimal Amount, decimal dWarranty, string Remark, decimal dExRate, Color cFontColor)
        {
            try
            {
                clsHelpMethods.AddMultipleItems_Grid(dgvDetail, ItemID, ref iRow, ref iLineNo, ref Quantity, ref UnitPrice, ref Weight, ref WeightAvg);

                //Get Unit Price with Exchange rate to save
                UnitPrice = getDisplayUnitPrice(UnitPrice, dExRate);
                WeightPrice = getDisplayUnitPrice(WeightPrice, dExRate);
                Amount = getDisplayUnitPrice(Amount, dExRate);
                WeightAvg = getDisplayUnitPrice(WeightAvg, dExRate);

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

                if (clsCommon.IsCustomerizedGrid())
                {
                    dgvDetail["Quantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(Quantity);
                    dgvDetail["Weight", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(Weight);
                    dgvDetail["Amount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(Amount);
                    dgvDetail["Amount", iRow].Tag = Amount;

                    dgvDetail["UnitPrice", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(UnitPrice);
                    dgvDetail["UnitPrice", iRow].Tag = UnitPrice;
                    dgvDetail["WeightPrice", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(WeightPrice);
                    dgvDetail["WeightPrice", iRow].Tag = WeightPrice;
                    dgvDetail["WeightAvg", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(WeightAvg);
                }
                else
                {
                    dgvDetail["Quantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(System.Convert.ToDecimal(Quantity.ToString()));
                    dgvDetail["UnitPrice", iRow].Value = UnitPrice.ToString();
                    dgvDetail["UnitPrice", iRow].Tag = UnitPrice;
                    dgvDetail["Weight", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(System.Convert.ToDecimal(Weight.ToString()));
                    dgvDetail["WeightPrice", iRow].Value = WeightPrice.ToString();
                    dgvDetail["WeightPrice", iRow].Tag = WeightPrice;
                    dgvDetail["WeightAvg", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(WeightAvg);
                    dgvDetail["Amount", iRow].Value = Amount.ToString();
                    dgvDetail["Amount", iRow].Tag = Amount;
                }

                #region Set Row Count
                dgvDetail["RowCount", iRow].Value = iRow + 1;
                #endregion

                //Grid Locks
                dgvDetail.Columns["UnitPrice"].ReadOnly = clsConfig.bEnableGridLock_Price_GRN ? true : false;

                dgvDetail["View", iRow].Value = "";
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Update PO
        public void UpdatePO(string sGrnID)
        {
            try
            {
                foreach (var oGRND in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(sGrnID)
                    .Where(p => p.ExternalGoodReceivedNote_ID != "default")
                    .GroupBy(cm => new { cm.ExternalGoodReceivedNote_ID, cm.PurchaseOrder_ID }, (key, group) => new { po = key.PurchaseOrder_ID }))
                {
                    tbl_scsPurchaseOrder oPO = tbl_scsPurchaseOrder.Select(oGRND.po);
                    if (oPO != null && oPO.PurchaseOrder_ID != "default")
                    {
                        bool bIsPoSettled = true;
                        foreach (tbl_scsPurchaseOrder_Detail oPOD in tbl_scsPurchaseOrder_Detail.SelectAllByPurchaseOrder_ID(oGRND.po))
                        {
                            foreach (tbl_scsExternalGoodReceivedNote_Detail oGRNDetail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(sGrnID).Where(p => p.Line_No == oPOD.Line_No))
                            {
                                if (oPO.IsWeightCalculation)
                                    oPOD.WeightSettle += oGRNDetail.Weight;
                                else
                                    oPOD.QtySettle += oGRNDetail.Qty;
                                oPOD.Update();
                            }

                            if (oPO.IsWeightCalculation)
                                bIsPoSettled = oPOD.WeightSettle >= oPOD.Weight ? bIsPoSettled : false;
                            else
                                bIsPoSettled = oPOD.QtySettle >= oPOD.Qty ? bIsPoSettled : false;
                        }
                        oPO.IsSeattled = bIsPoSettled;
                        oPO.Update();
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

        #region Validity FIFO Qty
        public bool ValidityFIFOQty()
        {
            bool bStatus = true;
            if (IsUpdate)
            {
            }
            return bStatus;
        }
        #endregion

        #region Set Enable/Disable Area
        private void setEnableArea_PO(bool bActive)
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtPoID, bActive);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtPRNID, bActive);
            clsCommon.SetEnableDisable_NormalLabel(lblPoID, bActive);
            clsCommon.SetEnableDisable_NormalLabel(lblPRNID, bActive);
            btnAddPRN.Enabled = bActive;
            btnAddPurchaseOrder.Enabled = bActive;
        }

        private void setEnableArea_Item(bool bActive)
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemID, bActive);
            clsCommon.SetEnableDisable_NormalLabel(lblItemID, bActive);
            btnAddItem.Enabled = bActive;
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            if (txtGRNID.Tag == null && (txtGRNID.Text == "<Auto Generate>" || txtGRNID.Text == ""))
                MessageBox.Show("Please select a GRN", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                frm_scsAddNewBarcode bc = new frm_scsAddNewBarcode();
                bc.show(txtGRNID.Text.ToString(), iFormID);
            }
        }

        private void btnCreateDeliveryOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGRNID.Text.Length > 0 && txtGRNID.Text.Trim() != "default")
                {
                    tbl_scsExternalGoodReceivedNote detail = tbl_scsExternalGoodReceivedNote.Select(txtGRNID.Text.Trim());
                    if (detail != null && detail.ExternalGoodReceivedNote_ID != "default" && !detail.IsDeleted)
                    {
                        bool bAllowDetail = true;
                        string message = "";

                        if (bAllowDetail)
                        {
                            frm_scsPurchaseReturnNote frm = new frm_scsPurchaseReturnNote(FormName.scsPRNSupplier);
                            frm.glbGoodReceivedNoteID = txtGRNID.Tag.ToString();
                            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, (this.Parent as Form).MdiParent);
                        }
                        else
                            MessageBox.Show(message, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void setEnableArea_Supplier(bool bActive)
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSupplierID, bActive);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, bActive);
        }
        private void setEnableArea_StockNoteType(bool bActive)
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStockNoteType, bActive);
            clsCommon.SetEnableDisable_NormalLabel(lblStockNoteType, bActive);
        }
        #endregion

        #region Events SelectedIndexChanged
        private void tbcItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcItems.SelectedTab == tbpBreakdown)
            {
                if (IsUpdate)
                {
                    if (clsConfig.bItemSerialNo_Active)
                        RefreshGridBreakdownGenaral(txtGRNID.Text.Trim(), "");
                    else
                        tbcItems.SelectedTab = tbpGenaral;
                }
                else
                    tbcItems.SelectedTab = tbpGenaral;

            }
        }
        #endregion

        #region Print Method
        private void PrintDataset(bool bIsDraft)
        {
            if (clsConfig.sSoftwareModel.Trim() != SoftwareModel_Sales.ePackWithSubCategory.ToString() && clsConfig.sSoftwareModel.Trim() != SoftwareModel_Sales.idealWheels.ToString())
            {
                if (txtGRNID.TextLength > 0 && txtGRNID.Text != "<Auto Generate>")
                {
                    try
                    {
                        glb_dtsGRN.dt_scsExternalGoodsReceiveNote.Clear();
                        glb_dtsGRN.dt_scsExternalGoodsReceiveNoteDetail.Clear();
                        glb_dtsGRN.dt_Company.Rows.Clear();
                        glb_dtsReportExport.dt_rptParameter.Rows.Clear();

                        string sDuplicateCopy = "";

                        tbl_scsExternalGoodReceivedNote detail = tbl_scsExternalGoodReceivedNote.Select(txtGRNID.Tag.ToString());
                        if (detail != null && detail.ExternalGoodReceivedNote_ID != "default")
                        {
                            bool bApprovalDone = true, bCheckDone = true;
                            if (!bIsDraft)
                            {
                                #region Validate Approval
                                if (clsConfig.bApprovalNeedToPrintGRN)
                                {
                                    if (!detail.IsApproved)
                                    {
                                        MessageBox.Show("Please Approve the GRN Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        bApprovalDone = false;
                                    }
                                }
                                #endregion
                                #region Validate Checking
                                if (clsConfig.bCheckingNeedToPrintGRN)
                                {
                                    if (!detail.IsChecked)
                                    {
                                        MessageBox.Show("Please Check the GRN Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        bCheckDone = false;
                                    }
                                }
                                #endregion
                            }
                            if (detail.IsDeleted)
                                sDuplicateCopy = "";

                            if (bApprovalDone && bCheckDone)
                            {
                                if (!bIsDraft)
                                {
                                    if (!chkPrintOriginal.Checked)
                                        sDuplicateCopy = (detail.PrintCount > 0) ? "Duplicate Copy " + detail.PrintCount : "";

                                    detail.PrintCount++;
                                    detail.DatePrinted = clsSecurity.getServerDateTime();
                                    detail.PrintedTerminal_ID = clsSecurity.TerminalID;
                                    detail.PrintedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }

                                int iCreditPeriod = int.Parse(detail.CreditPeriod == "" ? "0" : detail.CreditPeriod);

                                tbl_scsPurchaseOrder order = tbl_scsPurchaseOrder.Select(detail.PurchaseOrder_ID);
                                #region Fill Header
                                glb_dtsGRN.dt_scsExternalGoodsReceiveNote.Adddt_scsExternalGoodsReceiveNoteRow(detail.ExternalGoodReceivedNote_ID, detail.ExternalGoodReceivedNoteDate, detail.Store_ID,
                                                        clsGenaralName.getName_Store(detail.Store_ID), detail.IssuedRefNo_ID, detail.PurchaseOrder_ID + " / " + clsFormatter.FormatDate_Short(order.PurchaseOrderDate), detail.DeliveryOrderNumber, detail.Remark, detail.Supplier_ID,
                                                        clsGenaralName.getName_Supplier(detail.Supplier_ID), clsGenaralName.getSupplierAddressRegister(detail.Supplier_ID), clsCommon.getSupplerTelephoneAndFax(detail.Supplier_ID), detail.SubTotal / detail.CurrencyRate, detail.GrandTotal / detail.CurrencyRate, detail.NbtPercentage, detail.OtherTaxPercentage,
                                                        detail.VatPercentage, detail.DiscountPercentage, detail.NbtTotal / detail.CurrencyRate, detail.OtherTaxTotal / detail.CurrencyRate, detail.VatTotal / detail.CurrencyRate, detail.DiscountTotal / detail.CurrencyRate, detail.IsWeightCalculation, detail.IsDeleted, detail.CurrencyRate,
                                                        clsGenaralName.getName_Currency(detail.Currency_ID), detail.PaymentMode, detail.PaymentTerms, iCreditPeriod,
                                                        detail.ExternalGoodReceivedNoteDate.AddDays(iCreditPeriod), detail.CreateUser_ID);

                                #endregion

                                #region Fill Details
                                foreach (tbl_scsExternalGoodReceivedNote_Detail oGRNDetail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(detail.ExternalGoodReceivedNote_ID).OrderBy(p => p.Line_No))
                                {
                                    glb_dtsGRN.dt_scsExternalGoodsReceiveNoteDetail.Adddt_scsExternalGoodsReceiveNoteDetailRow(oGRNDetail.Line_No, oGRNDetail.ExternalGoodReceivedNote_ID, oGRNDetail.Item_ID, clsGenaralName.getName_Item(oGRNDetail.Item_ID),
                                          detail.IsWeightCalculation ? oGRNDetail.Weight : oGRNDetail.Qty, detail.IsWeightCalculation ? oGRNDetail.KiloPrice / detail.CurrencyRate : oGRNDetail.UnitPrice / detail.CurrencyRate, oGRNDetail.TatalAmount / detail.CurrencyRate, clsGenaralName.getDescription_Item(oGRNDetail.Item_ID), clsGenaralName.getName_ItemBrandID(oGRNDetail.Item_ID), clsGenaralName.getName_ItemBrand(oGRNDetail.Item_ID), clsGenaralName.getName_ItemUOMID(oGRNDetail.Item_ID), clsGenaralName.getName_ItemUOMName(oGRNDetail.Item_ID));
                                }
                                #endregion

                                sCreateUser = "[ " + clsGenaralName.getName_User(detail.CreateUser_ID) + " ] [ " + detail.DateCreate.ToShortDateString() + " ]";
                                if (detail.IsChecked && detail.CheckedUser_ID != "default")
                                    sCheckedUser = "[ " + clsGenaralName.getName_User(detail.CheckedUser_ID) + " ] [ " + detail.DateChecked.ToShortDateString() + " ]";
                                if (detail.IsApproved && detail.ApprovedUser_ID != "default")
                                    sApprovedUser = "[ " + clsGenaralName.getName_User(detail.ApprovedUser_ID) + " ] [ " + detail.DateApproved.ToShortDateString() + " ]";

                                #region Parameter
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle", "Good Received Note", true,false);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", clsSecurity.CompanyName, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", clsSecurity.CompanyAddress1, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", clsSecurity.CompanyAddress2, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqName", clsSecurity.DigiteqName, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", clsCommon.getCompanyEmail(), true,false);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicateCopy, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "Draft" : "", true,false);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUser, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sCheckedUser, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUser, true,false);
                                #endregion

                                string s_Path = clsHelpMethods.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_GoodsReceivedNote));

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

                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", "", true,false);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", "", true,false);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", "", true,false);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", "", true,false);
                                    }
                                }
                                glb_dtsGRN.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, "GOODS RECEIVED NOTE", "Goods Received Note", "", clsSecurity.UserNameLoged, "");
                                #endregion

                                frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                rpt.print(s_Path, glb_dtsGRN, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_GoodsReceivedNote));
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
                        glb_dtsGRN.dt_scsExternalGoodsReceiveNote.Clear();
                        glb_dtsGRN.dt_scsExternalGoodsReceiveNoteDetail.Clear();
                        glb_dtsGRN.dt_Company.Rows.Clear();
                        glb_dtsReportExport.dt_rptParameter.Rows.Clear();
                    }
                }
                else
                    MessageBox.Show("Please Select the GRN To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail_CellContentDoubleClick(sender, e);
        }

        private void dgvDetail_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsUpdate)
            {
                if (clsConfig.bItemSerialNo_Active)
                {
                    tbcItems.SelectedTab = tbpBreakdown;
                    string sItemID_ToBeSelected = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", e.RowIndex, "");
                    RefreshGridBreakdownGenaral(txtGRNID.Text.Trim(), sItemID_ToBeSelected);
                    dgvGenaral_CellClick(sender, new DataGridViewCellEventArgs(0, 0));
                }
            }
        }

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                if (sColName == "View")
                {
                 //   frmComponentList frm = new frmComponentList();
                  //  frm.MdiParent = this.ParentForm.MdiParent;
                  //  frm.Show();
                }
            }
        }

        #region User Checked Approve Details
        private void frm_scsExternalGoodReceiveNote_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_scsExternalGoodReceiveNote_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpGRNDate.Value.Date))
                {
                    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtGRNID.Text != null && txtGRNID.TextLength > 0 && txtGRNID.Text != "<Auto Generate>")
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

                                        tbl_scsExternalGoodReceivedNote objGRN = tbl_scsExternalGoodReceivedNote.Select(txtGRNID.Text.Trim());
                                        if (objGRN != null)
                                        {
                                            objGRN.IsApproved = true;
                                            objGRN.DateApproved = clsSecurity.getServerDateTime();
                                            objGRN.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                            objGRN.Update();
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
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpGRNDate.Value.Date))
                {
                    if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtGRNID.Text != null && txtGRNID.TextLength > 0 && txtGRNID.Text != "<Auto Generate>")
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

                                        tbl_scsExternalGoodReceivedNote objGRN = tbl_scsExternalGoodReceivedNote.Select(txtGRNID.Text.Trim());
                                        if (objGRN != null)
                                        {
                                            objGRN.IsChecked = true;
                                            objGRN.DateChecked = clsSecurity.getServerDateTime();
                                            objGRN.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objGRN.Update();
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

        private void frm_scsExternalGoodReceiveNote_SF_History_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGRNID.Text != "" || txtGRNID.Text != "<Auto Generate>")
                {
                    tbl_scsExternalGoodReceivedNote detail = tbl_scsExternalGoodReceivedNote.Select(txtGRNID.Text.Trim());
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

                        if (detail.IsDeleted)
                            dt_UserDetails.Rows.Add("Cancelled by", ":", clsGenaralName.getName_User(detail.DeletedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateDeleted));

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

