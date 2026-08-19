using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DataTire;
using CrystalDecisions.CrystalReports.Engine;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using Digiteq.Transaction_Forms.SCS.Tools_And_Views;
using Zion.ERP.Reports.DataSets.SCS;
using Zion.ERP.Reports.DataSets;
using SEACC.DATA.Data.SCS;

namespace Digiteq
{
    public partial class frm_sasItemSpradeNote : SEACC_Form
    {
        
        //to manage update and insert
        //to keep glob ref no        
        public string glbOrderRefNo = "", glbInquiryID = "", glbSplitNoteID = "", glbCustomerOrderID = "";

        DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        DateTime glbCheckedDate = clsSecurity.getServerDateTime();

        public DataTable dt_ItemGrouped = new DataTable();

        dt_scsSplitNote glb_dtscsSplitNote = new dt_scsSplitNote();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();

        InventoryTxnData oData = new InventoryTxnData();
        clsAlerts_Email email = new clsAlerts_Email();

        #region From Load
        public frm_sasItemSpradeNote(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }

        private void frm_sasItemSpradeNote_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);
            CusDataGridViewFormat();
            ClearFields();
            userDetailsColorChanges();

            lblItemSubCategory.Text = clsConfig.sItemSubCategory;
            lblItemSubCategory2.Text = clsConfig.sItemSubCategory2;
            lblNewItemSubCategory.Text = clsConfig.sItemSubCategory;
            lblNewItemSubCategory2.Text = clsConfig.sItemSubCategory2;

            if (glbSplitNoteID.Length > 0)
                FillDetails(glbSplitNoteID);
        }

        #endregion

        #region btn New
        private void frm_sasItemSpradeNote_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region btn Save
        private void frm_sasItemSpradeNote_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    ValidateEmptyForeignKey();

                    #region Update
                    if (IsUpdate)//update
                    {
                        tbl_scsItemSpred oldRecord = tbl_scsItemSpred.Select(txtSpradeCode.Text.Trim());
                        if (oldRecord != null)
                        {
                            if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                            {
                                if (clsValidate.CheckValidity_TransactionCodeLength(txtSpradeCode.Text)) //if (txtSpradeCode.TextLength > 0)
                                {
                                   // List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();

                                    #region Rollback StoreStock
                                    foreach (tbl_scsItemSpred_Detail_From oUpdatedRecore in tbl_scsItemSpred_Detail_From.SelectAllByItemSpred_ID(txtSpradeCode.Text.Trim()))
                                    {
                                        decimal dWeightedAverageCostPrice = 0;
                                       // clsHelpMethods_Local.UpdateStoreStock(iFormID, oUpdatedRecore.ItemSpred_ID, oldRecord.ItemSpredDate, oUpdatedRecore.Item_ID, "0", txtFromStore.Tag.ToString(), oUpdatedRecore.Qty, oUpdatedRecore.Weight, 0, true, false, false, ref dWeightedAverageCostPrice);
                                        oUpdatedRecore.WeightedAvgCost = clsProcessMethods.GetItemWeightedAvarageCostPrice(oUpdatedRecore.Item_ID);
                                        oUpdatedRecore.Update();
                                    }
                                    foreach (tbl_scsItemSpred_Detail_To oUpdatedRecore in tbl_scsItemSpred_Detail_To.SelectAllByItemSpred_ID(txtSpradeCode.Text.Trim()))
                                    {
                                        decimal dWeightedAverageCostPrice = 0;
                                      //  clsHelpMethods_Local.UpdateStoreStock(iFormID, oUpdatedRecore.ItemSpred_ID, oldRecord.ItemSpredDate, oUpdatedRecore.Item_ID, "0", txtFromStore.Tag.ToString(), oUpdatedRecore.Qty, oUpdatedRecore.Weight, 0, true, true, false, ref dWeightedAverageCostPrice);
                                        oUpdatedRecore.WeightedAvgCost = clsProcessMethods.GetItemWeightedAvarageCostPrice(oUpdatedRecore.Item_ID);
                                        oUpdatedRecore.Update();
                                    }
                                    #endregion

                                    #region Update Header
                                    #region Check Currency
                                    decimal dTotalInputQty = clsCommon.isCurrency(txtTotalInputQty.Text.Trim()) ? decimal.Parse(txtTotalInputQty.Text.Trim()) : 0;
                                    decimal dTotalInputWeight = clsCommon.isCurrency(txtTotalInputWeight.Text.Trim()) ? decimal.Parse(txtTotalInputWeight.Text.Trim()) : 0;
                                    decimal dTotalOutputQty = clsCommon.isCurrency(txtTotalOutputQty.Text.Trim()) ? decimal.Parse(txtTotalOutputQty.Text.Trim()) : 0;
                                    decimal dTotalOutputWeight = clsCommon.isCurrency(txtTotalOutputWeight.Text.Trim()) ? decimal.Parse(txtTotalOutputWeight.Text.Trim()) : 0;
                                    #endregion

                                    #region Item Spred Details Insert
                                    tbl_scsItemSpred ItemSdetail = new tbl_scsItemSpred(txtSpradeCode.Text, dtpSplitNoteDate.Value, txtRemark.Text.Trim(),
                                                                        dTotalInputQty, dTotalOutputQty, dTotalInputWeight, dTotalOutputWeight,
                                                                        oldRecord.CreateUser_ID, clsSecurity.UserIDLoged, "default", "default", clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                                                        oldRecord.CreateTerminal_ID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                                        oldRecord.DateCreate, clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                                        bHasChecked, bHasApproved, oldRecord.IsFinished, oldRecord.IsDeleted, oldRecord.IsLocked, oldRecord.IsSeattled, oldRecord.PrintCount, oldRecord.CompanyID, oldRecord.CompanyBranch_ID);
                                    ItemSdetail.Update();
                                    #endregion

                                    #endregion

                                    #region Delete Old Records
                                    tbl_scsItemSpred_Detail_From.DeleteAllByItemSpred_ID(txtSpradeCode.Text.Trim());
                                    tbl_scsItemSpred_Detail_To.DeleteAllByItemSpred_ID(txtSpradeCode.Text.Trim());
                                    #endregion

                                    #region Update Detail

                                    
                                    int LineNO; string sItemID = "", sItemSubCategory1_ID = "", sItemSubCategory2_ID = "", sSerialNo1 = "", sSerialNo2 = "";
                                    decimal dWeightInput = 0, dQtyInput = 0, dWeightOutput = 0, dQtyOutput = 0;
                                    bool bIsInput = false;
                                    #endregion

                                    int iCount = 0;
                                    foreach (DataGridViewRow Row in dgvNewItem.Rows)
                                    {
                                        #region Validation
                                        LineNO = clsValidate.ValidateGridValue(dgvNewItem, "LineNo1", Row.Index, int.Parse("0"));
                                        sItemID = clsValidate.ValidateGridValue(dgvNewItem, "ItemCode", Row.Index, "");
                                        sItemSubCategory1_ID = clsValidate.ValidateGridTag(dgvNewItem, "ItemSubCategoryID", Row.Index, "default");
                                        sItemSubCategory2_ID = clsValidate.ValidateGridTag(dgvNewItem, "ItemSubCategoryID2", Row.Index, "default");
                                        sSerialNo1 = clsValidate.ValidateGridValue(dgvNewItem, "ItemSerialNo1", Row.Index, "0");
                                        sSerialNo2 = clsValidate.ValidateGridValue(dgvNewItem, "ItemSerialNo22", Row.Index, "0");
                                        dQtyInput = clsValidate.ValidateGridValue(dgvNewItem, "Quantity", Row.Index, decimal.Parse("0.00"));
                                        dWeightInput = clsValidate.ValidateGridValue(dgvNewItem, "Weight", Row.Index, decimal.Parse("0.00"));
                                        dQtyOutput = clsValidate.ValidateGridValue(dgvNewItem, "Qty1", Row.Index, decimal.Parse("0.00"));
                                        dWeightOutput = clsValidate.ValidateGridValue(dgvNewItem, "WeightKg1", Row.Index, decimal.Parse("0.00"));
                                        bIsInput = clsValidate.ValidateGridValue(dgvNewItem, "IsLocked1", Row.Index, false);
                                        #endregion

                                        if (sItemID.Length > 0)
                                        {
                                            if (bIsInput)
                                            {
                                                #region Spred Detail from Update
                                                tbl_scsItemSpred_Detail_From detail = new tbl_scsItemSpred_Detail_From(LineNO, txtSpradeCode.Tag.ToString(), sItemID,
                                                    sItemSubCategory1_ID, sItemSubCategory2_ID, sSerialNo1, sSerialNo2, txtFromStore.Tag.ToString(), dQtyInput, dWeightInput, 0, 0, 0, "", 0, clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemID));
                                                detail.Insert();
                                                #endregion

                                                #region Pass Value to Inventory Detail
                                                //tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, ++iCount, 0, txtSpradeCode.Text.Trim(), dtpSplitNoteDate.Value,
                                                //                            "", "", "", "", "default", "default", txtFromStore.Tag.ToString(),
                                                //                            sItemID, clsGenaralName.getName_ItemUOMID(sItemID), 0, dQtyInput, 0, 0, false);
                                                //oListInventory.Add(oInventoryDetail);
                                                #endregion
                                            }
                                            else
                                            {
                                                #region Spred Detail to Update
                                                tbl_scsItemSpred_Detail_To detail = new tbl_scsItemSpred_Detail_To(LineNO, txtSpradeCode.Tag.ToString(), sItemID,
                                                    sItemSubCategory1_ID, sItemSubCategory2_ID, sSerialNo1, sSerialNo2, clsConfig.bitemSplitNote_ToStoreActive ? txtToStore.Tag.ToString() : txtFromStore.Tag.ToString(), dQtyOutput, dWeightOutput, 0, 0, 0, "", clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemID));
                                                detail.Insert();
                                                #endregion

                                                #region Pass Value to Inventory Detail
                                                //tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, ++iCount, 0,  txtSpradeCode.Text.Trim(), dtpSplitNoteDate.Value,
                                                //                            "", "", "", "", "default", "default", txtToStore.Tag.ToString(),
                                                //                            sItemID, clsGenaralName.getName_ItemUOMID(sItemID), dQtyOutput, 0, 0, 0, false);
                                                //oListInventory.Add(oInventoryDetail);
                                                #endregion
                                            }
                                        }
                                    }
                                    #endregion

                                    #region Update Store Stock
                                    foreach (tbl_scsItemSpred_Detail_From oUpdatedRecord in tbl_scsItemSpred_Detail_From.SelectAllByItemSpred_ID(txtSpradeCode.Text.Trim()))
                                    {
                                        decimal dWeightedAverageCostPrice = 0;
                                      //  decimal dCostFifo = clsHelpMethods_Local.UpdateStoreStock(iFormID, ItemSdetail.ItemSpred_ID, ItemSdetail.ItemSpredDate, oUpdatedRecord.Item_ID, "0", txtFromStore.Tag.ToString(), oUpdatedRecord.Qty, oUpdatedRecord.Weight, 0, false, false, false, ref dWeightedAverageCostPrice);
                                      //  oUpdatedRecord.Cost_FIFO = dCostFifo;
                                        oUpdatedRecord.Update();
                                    }
                                    foreach (tbl_scsItemSpred_Detail_To oUpdatedRecord in tbl_scsItemSpred_Detail_To.SelectAllByItemSpred_ID(txtSpradeCode.Text.Trim()))
                                    {
                                        decimal dWeightedAverageCostPrice = 0;
                                   //     clsHelpMethods_Local.UpdateStoreStock(iFormID, ItemSdetail.ItemSpred_ID, ItemSdetail.ItemSpredDate, oUpdatedRecord.Item_ID, "0", clsConfig.bitemSplitNote_ToStoreActive ? txtToStore.Tag.ToString() : txtFromStore.Tag.ToString(), oUpdatedRecord.Qty, oUpdatedRecord.Weight, 0, false, true, false, ref dWeightedAverageCostPrice);                                       
                                    }
                                    #endregion

                                    #region Update Inventory
                                    //tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtSpradeCode.Text.Trim(), dtpSplitNoteDate.Value, txtRemark.Text.Trim(),
                                    //    "default", "default", "default", -1, 0,
                                    //    "", "", "", "", false, clsSecurity.UserIDLoged);

                                    //clsHelpMethods.Update_Inventory(oHeader, oListInventory);

                                    var responce = oData.Update_InventoryTxn(iFormID, txtSpradeCode.Text.Trim());
                                    if (!responce.IsSuccess)
                                    {
                                        clsValidate.WriteErrorLog(txtSpradeCode.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
                                    }
                                    #endregion

                                    email.createEmail_IS(txtSpradeCode.Text.Trim(), enum_Alerts.ItemSpliteCreate);
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    #endregion

                    #region Insert
                    else
                    {

                        if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                        {
                            txtSpradeCode.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);
                            txtSpradeCode.Tag = txtSpradeCode.Text;
                        }

                        if (clsValidate.CheckValidity_TransactionCodeLength(txtSpradeCode.Text)) // (txtSpradeCode.TextLength > 0)
                        {
                       //     List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();

                            decimal dTotalInputQty = clsCommon.isCurrency(txtTotalInputQty.Text.Trim()) ? decimal.Parse(txtTotalInputQty.Text.Trim()) : 0;
                            decimal dTotalInputWeight = clsCommon.isCurrency(txtTotalInputWeight.Text.Trim()) ? decimal.Parse(txtTotalInputWeight.Text.Trim()) : 0;
                            decimal dTotalOutputQty = clsCommon.isCurrency(txtTotalOutputQty.Text.Trim()) ? decimal.Parse(txtTotalOutputQty.Text.Trim()) : 0;
                            decimal dTotalOutputWeight = clsCommon.isCurrency(txtTotalOutputWeight.Text.Trim()) ? decimal.Parse(txtTotalOutputWeight.Text.Trim()) : 0;

                            #region Insert Header
                            tbl_scsItemSpred ItemSdetail = new tbl_scsItemSpred(txtSpradeCode.Text, dtpSplitNoteDate.Value, txtRemark.Text.Trim(),
                                dTotalInputQty, dTotalOutputQty, dTotalInputWeight, dTotalOutputWeight,
                                clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default", clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                bHasChecked, bHasApproved, false, false, false, false, 0, clsSecurity.CompanyID, clsSecurity.BranchID);
                            ItemSdetail.Insert();
                            #endregion

                            #region insert Detail
                            int LineNO; string sItemID = "", sItemSubCategory1_ID = "", sItemSubCategory2_ID = "", sSerialNo1 = "", sSerialNo2 = "";
                            decimal dWeightInput = 0, dQtyInput = 0, dWeightOutput = 0, dQtyOutput = 0;
                            bool bIsInput = false;
                            int iCount = 0;

                            foreach (DataGridViewRow Row in dgvNewItem.Rows)
                            {
                                LineNO = clsValidate.ValidateGridValue(dgvNewItem, "LineNo1", Row.Index, int.Parse("0"));
                                sItemID = clsValidate.ValidateGridValue(dgvNewItem, "ItemCode", Row.Index, "");
                                sItemSubCategory1_ID = clsValidate.ValidateGridTag(dgvNewItem, "ItemSubCategoryID", Row.Index, "default");
                                sItemSubCategory2_ID = clsValidate.ValidateGridTag(dgvNewItem, "ItemSubCategoryID2", Row.Index, "default");
                                sSerialNo1 = clsValidate.ValidateGridValue(dgvNewItem, "ItemSerialNo1", Row.Index, "0");
                                sSerialNo2 = clsValidate.ValidateGridValue(dgvNewItem, "ItemSerialNo22", Row.Index, "0");
                                dQtyInput = clsValidate.ValidateGridValue(dgvNewItem, "Quantity", Row.Index, decimal.Parse("0.00"));
                                dWeightInput = clsValidate.ValidateGridValue(dgvNewItem, "Weight", Row.Index, decimal.Parse("0.00"));
                                dQtyOutput = clsValidate.ValidateGridValue(dgvNewItem, "Qty1", Row.Index, decimal.Parse("0.00"));
                                dWeightOutput = clsValidate.ValidateGridValue(dgvNewItem, "WeightKg1", Row.Index, decimal.Parse("0.00"));
                                bIsInput = clsValidate.ValidateGridValue(dgvNewItem, "IsLocked1", Row.Index, false);

                                if (sItemID.Length > 0)
                                {
                                    if (bIsInput)
                                    {
                                        tbl_scsItemSpred_Detail_From detail = new tbl_scsItemSpred_Detail_From(LineNO, txtSpradeCode.Tag.ToString(), sItemID,
                                            sItemSubCategory1_ID, sItemSubCategory2_ID, sSerialNo1, sSerialNo2, txtFromStore.Tag.ToString(), dQtyInput, dWeightInput, 0, 0, 0, "", 0, clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemID));
                                        detail.Insert();

                                        #region Update Store Stock
                                        decimal dWeightedAverageCostPrice = 0;
                                      //  decimal dCostFifo = clsHelpMethods_Local.UpdateStoreStock(iFormID, ItemSdetail.ItemSpred_ID, ItemSdetail.ItemSpredDate, sItemID, "0", txtFromStore.Tag.ToString(), dQtyInput, dWeightInput, 0, false, false, false, ref dWeightedAverageCostPrice);

                                      //  detail.Cost_FIFO = dCostFifo;
                                        detail.Update();
                                        #endregion

                                        #region Pass Value to Inventory Detail
                                        //tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, ++iCount, 0,  txtSpradeCode.Text.Trim(), dtpSplitNoteDate.Value,
                                        //                            "", "", "", "", "default", "default", txtFromStore.Tag.ToString(),
                                        //                            sItemID, clsGenaralName.getName_ItemUOMID(sItemID), 0, dQtyInput, 0, 0, false);
                                        //oListInventory.Add(oInventoryDetail);
                                        #endregion
                                    }
                                    else
                                    {
                                        string sStore_ID = clsConfig.bitemSplitNote_ToStoreActive ? txtToStore.Tag.ToString() : txtFromStore.Tag.ToString();

                                        tbl_scsItemSpred_Detail_To detail = new tbl_scsItemSpred_Detail_To(LineNO, txtSpradeCode.Tag.ToString(), sItemID,
                                            sItemSubCategory1_ID, sItemSubCategory2_ID, sSerialNo1, sSerialNo2, sStore_ID, dQtyOutput, dWeightOutput, 0, 0, 0, "", clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemID));
                                        detail.Insert();

                                        #region Update Store Stock
                                        decimal dWeightedAverageCostPrice = 0;
                                     //   clsHelpMethods_Local.UpdateStoreStock(iFormID, ItemSdetail.ItemSpred_ID, ItemSdetail.ItemSpredDate, sItemID, "0", clsConfig.bitemSplitNote_ToStoreActive ? txtToStore.Tag.ToString() : txtFromStore.Tag.ToString(), dQtyOutput, dWeightInput, 0, false, true, false, ref dWeightedAverageCostPrice);
                                       
                                        #endregion

                                        #region Pass Value to Inventory Detail
                                        //tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, ++iCount,0,  txtSpradeCode.Text.Trim(), dtpSplitNoteDate.Value,
                                        //                            "", "", "", "", "default", "default", sStore_ID,
                                        //                            sItemID, clsGenaralName.getName_ItemUOMID(sItemID), dQtyOutput, 0, 0, 0, false);
                                        //oListInventory.Add(oInventoryDetail);
                                        #endregion
                                    }
                                }
                            }
                            #endregion

                            #region Update Inventory
                            //tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtSpradeCode.Text.Trim(), dtpSplitNoteDate.Value, txtRemark.Text.Trim(),
                            //    "default", "default", "default", -1, 0,
                            //    "", "", "", "", false, clsSecurity.UserIDLoged);

                            //clsHelpMethods.Update_Inventory(oHeader, oListInventory);

                            var responce = oData.Update_InventoryTxn(iFormID, txtSpradeCode.Text.Trim());
                            if (!responce.IsSuccess)
                            {
                                clsValidate.WriteErrorLog(txtSpradeCode.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
                            }
                            #endregion
                         
                            email.createEmail_IS(txtSpradeCode.Text.Trim(), enum_Alerts.ItemSpliteCreate);
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        Attachments.Insert(txtSpradeCode.Text.ToString());
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
                    tbl_scsItemSpred oldRecord = tbl_scsItemSpred.Select(txtSpradeCode.Text.Trim());
                    ClearFields();
                    if (oldRecord != null)
                        FillDetails(oldRecord.ItemSpred_ID);
                }
            }
        }
     

        #region Btn Print
        private void frm_sasItemSpradeNote_SF_printButton_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_sasItemSpradeNote_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region Btn Cancel
        private void frm_sasItemSpradeNote_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSpradeCode.Text.Trim().Length > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtFromStore.Tag.ToString(), IsUpdate))
                        {
                            //delete one record
                            Cursor = Cursors.WaitCursor;
                            tbl_scsItemSpred detail = tbl_scsItemSpred.Select(txtSpradeCode.Text.Trim());
                            if (detail != null)
                            {
                                if (!detail.IsLocked && !detail.IsFinished && !detail.IsDeleted)
                                {
                                    DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " Splite Code : " + txtSpradeCode.Text), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (msgResult == DialogResult.Yes)
                                    {
                                        #region Update Other Tables
                                        foreach (tbl_scsItemSpred Olddetail in tbl_scsItemSpred.SelectAll().Where(p => p.ItemSpred_ID == txtSpradeCode.Text.Trim()))
                                        {
                                            if (Olddetail.ItemSpred_ID != null)
                                            {
                                                #region Update Spred Details From
                                                foreach (tbl_scsItemSpred_Detail_From oItemFrom in tbl_scsItemSpred_Detail_From.SelectAllByItemSpred_ID(Olddetail.ItemSpred_ID))
                                                {
                                                    if (oItemFrom != null)
                                                    {
                                                        #region Update Store Stock
                                                        decimal dWeightedAverageCostPrice = 0;
                                                     //   clsHelpMethods_Local.UpdateStoreStock(iFormID, oItemFrom.ItemSpred_ID, Olddetail.ItemSpredDate, oItemFrom.Item_ID, "0", txtFromStore.Tag.ToString(), oItemFrom.Qty, oItemFrom.Weight, 0, true, false, false, ref dWeightedAverageCostPrice);
                                                        oItemFrom.WeightedAvgCost = clsProcessMethods.GetItemWeightedAvarageCostPrice(oItemFrom.Item_ID);
                                                        oItemFrom.Update();
                                                        #endregion
                                                    }
                                                }
                                                #endregion

                                                #region Update Spred Details To
                                                foreach (tbl_scsItemSpred_Detail_To oItemTo in tbl_scsItemSpred_Detail_To.SelectAllByItemSpred_ID(Olddetail.ItemSpred_ID))
                                                {
                                                    if (oItemTo != null)
                                                    {
                                                        #region Update Store Stock
                                                        decimal dWeightedAverageCostPrice = 0;
                                                     //   clsHelpMethods_Local.UpdateStoreStock(iFormID, oItemTo.ItemSpred_ID, Olddetail.ItemSpredDate, oItemTo.Item_ID, "0", clsConfig.bitemSplitNote_ToStoreActive ? txtToStore.Tag.ToString() : txtFromStore.Tag.ToString(), oItemTo.Qty, oItemTo.Weight, 0, true, true, false, ref dWeightedAverageCostPrice);
                                                        oItemTo.WeightedAvgCost = clsProcessMethods.GetItemWeightedAvarageCostPrice(oItemTo.Item_ID);
                                                        oItemTo.Update();
                                                        #endregion
                                                    }
                                                }
                                                #endregion
                                            }
                                        }
                                        #endregion

                                        detail.DateModified = clsSecurity.getServerDateTime();
                                        detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                        detail.IsDeleted = true;
                                        detail.Update();

                                        //   clsHelpMethods.Delete_Inventory(iFormID, 0, txtSpradeCode.Text.Trim());
                                        var responce = oData.Delete_InventoryTxn(iFormID, txtSpradeCode.Text.Trim());
                                        if (!responce.IsSuccess)
                                        {
                                            clsValidate.WriteErrorLog(txtSpradeCode.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
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
                if (dgvNewItem.SelectedCells.Count != 0)
                {
                    if (dgvNewItem.Rows.Count > 0)
                    {
                        dgvNewItem.Rows.RemoveAt(dgvNewItem.SelectedCells[0].RowIndex);
                        CalcualteTotals();
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

        #region Btn Item Infor
        private void btnInfoInputItem_Click(object sender, EventArgs e)
        {
            clsCommon.ValidateForeignKey(ref txtSubCategory);
            clsCommon.ValidateForeignKey(ref txtSubCategory2);
            clsCommon.ValidateForeignKey(ref txtItemName);
            string sSerialNo = txtSerialNo.Text.Trim().Length > 0 ? txtSerialNo.Text.Trim() : "0";
            string SerialNo2 = txtSerialNo2.Text.Trim().Length > 0 ? txtSerialNo2.Text.Trim() : "0";
            string sItemSubCategory = txtSubCategory.Tag.ToString();
            string sItemSubCategory2_ID = txtSubCategory2.Tag.ToString();
            string sItemID = txtItemName.Tag.ToString();

            clsAlerts.DisplayItemViewer(sItemID, sItemSubCategory, sItemSubCategory2_ID, sSerialNo, SerialNo2);
        }

        private void btnViewerJobCode_Click(object sender, EventArgs e)
        {
            clsCommon.ValidateForeignKey(ref txtNewSubCategory);
            clsCommon.ValidateForeignKey(ref txtNewSubCategory2);
            clsCommon.ValidateForeignKey(ref txtNewItemName);
            string sSerialNo = txtNewSerialNo.Text.Trim().Length > 0 ? txtNewSerialNo.Text.Trim() : "0";
            string SerialNo2 = txtNewSerialNo2.Text.Trim().Length > 0 ? txtNewSerialNo2.Text.Trim() : "0";
            string sItemSubCategory = txtNewSubCategory.Tag.ToString();
            string sItemSubCategory2_ID = txtNewSubCategory2.Tag.ToString();
            string sItemID = txtNewItemName.Tag.ToString();

            clsAlerts.DisplayItemViewer(sItemID, sItemSubCategory, sItemSubCategory2_ID, sSerialNo, SerialNo2);
        }
        #endregion

        #region Btn Add Sprade Items
        private void btnAddContact_Click(object sender, EventArgs e)
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtSubCategory);
                clsCommon.ValidateForeignKey(ref txtSubCategory2);
                string sSerialNo = txtSerialNo.Text.Trim().Length > 0 ? txtSerialNo.Text.Trim() : "0";
                string SerialNo2 = txtSerialNo2.Text.Trim().Length > 0 ? txtSerialNo2.Text.Trim() : "0";
                string sItemSubCategory = txtSubCategory.Tag.ToString();
                string sItemSubCategory2_ID = txtSubCategory2.Tag.ToString();
                decimal dWeight = txtWeight.Text.Length > 0 && clsCommon.isCurrency(txtWeight.Text.Trim()) ? decimal.Parse(txtWeight.Text.Trim()) : 0;
                decimal dQty = txtQty.Text.Length > 0 && clsCommon.isCurrency(txtQty.Text.Trim()) ? decimal.Parse(txtQty.Text.Trim()) : 0;

                if (txtItemName.Tag != null && txtItemName.Tag.ToString().Trim().Length > 0)
                {
                    string itemCode = txtItemName.Tag.ToString().Trim();
                    if (!checktheSameItemInTheSplitItems(itemCode, sItemSubCategory, sItemSubCategory2_ID, sSerialNo, SerialNo2, true))
                    {
                        dgvNewItem.Rows.Add();
                        int iRow = dgvNewItem.Rows.Count - 1;
                        Fill_Datagrid(iRow, itemCode, clsGenaralName.getName_Item(itemCode), sItemSubCategory, sItemSubCategory2_ID, sSerialNo, SerialNo2, clsGenaralName.getName_ItemUOM(itemCode), dQty, dWeight, 0, 0, "", true);

                        if (txtBOM.Tag != null)
                        {
                            tbl_cfgModule oModulePhama = tbl_cfgModule.Select("PROD/018");
                            tbl_cfgModule oModuleApparel = tbl_cfgModule.Select("PROD/016");

                            if (oModuleApparel != null && oModuleApparel.IsEnable)
                            {
                                //Load output items automatically when select a BOM
                                //List<tbl_prodTxJobCard_Material> oMaterials = tbl_prodTxJobCard_Material.SelectAllByProdJob_ID(txtBOM.Tag.ToString()).Where(p => p.Line_No_Sub1 == 0 && p.Line_No_Sub2 == 0).ToList();
                                //if (oMaterials.Count > 0)
                                //{
                                //    clsCommon.ValidateForeignKey(ref txtNewSubCategory);
                                //    clsCommon.ValidateForeignKey(ref txtNewSubCategory2);
                                //    string sSerialNoOut = txtNewSerialNo.Text.Trim().Length > 0 ? txtNewSerialNo.Text.Trim() : "0";
                                //    string SerialNo2Out = txtNewSerialNo2.Text.Trim().Length > 0 ? txtNewSerialNo2.Text.Trim() : "0";
                                //    string sItemSubCategoryOut = txtNewSubCategory.Tag.ToString();
                                //    string sItemSubCategory2_IDOut = txtNewSubCategory2.Tag.ToString();

                                //    for (int i = dgvNewItem.Rows.Count; i < oMaterials.Count + 1; i++)
                                //    {
                                //        //tbl_prodTxJobCard_Material oMaterial = oMaterials.ElementAt(i - 1);
                                //        //dgvNewItem.Rows.Add();
                                //        //Fill_Datagrid(i, oMaterial.Item_ID, clsGenaralName.getName_Item(oMaterial.Item_ID), sItemSubCategoryOut, sItemSubCategory2_IDOut, sSerialNoOut, SerialNo2Out, clsGenaralName.getName_ItemUOM(oMaterial.Item_ID), 0, 0, decimal.Parse(txtQty.Text) * oMaterial.TotalInputQty, 0, "", false);
                                //    }
                                //}
                            }
                            else if (oModulePhama != null && oModulePhama.IsEnable)
                            {
                                //Load output items automatically when select a BOM
                                //List<tbl_prod_pharmaTxJobCard_Material> oMaterials = tbl_prod_pharmaTxJobCard_Material.SelectAllByProdJob_ID(txtBOM.Tag.ToString()).Where(p => p.Line_No_Sub1 == 0 && p.Line_No_Sub2 == 0).ToList();
                                //if (oMaterials.Count > 0)
                                //{
                                //    clsCommon.ValidateForeignKey(ref txtNewSubCategory);
                                //    clsCommon.ValidateForeignKey(ref txtNewSubCategory2);
                                //    string sSerialNoOut = txtNewSerialNo.Text.Trim().Length > 0 ? txtNewSerialNo.Text.Trim() : "0";
                                //    string SerialNo2Out = txtNewSerialNo2.Text.Trim().Length > 0 ? txtNewSerialNo2.Text.Trim() : "0";
                                //    string sItemSubCategoryOut = txtNewSubCategory.Tag.ToString();
                                //    string sItemSubCategory2_IDOut = txtNewSubCategory2.Tag.ToString();

                                //    for (int i = dgvNewItem.Rows.Count; i < oMaterials.Count + 1; i++)
                                //    {
                                //        tbl_prod_pharmaTxJobCard_Material oMaterial = oMaterials.ElementAt(i - 1);
                                //        dgvNewItem.Rows.Add();
                                //        Fill_Datagrid(i, oMaterial.Item_ID, clsGenaralName.getName_Item(oMaterial.Item_ID), sItemSubCategoryOut, sItemSubCategory2_IDOut, sSerialNoOut, SerialNo2Out, clsGenaralName.getName_ItemUOM(oMaterial.Item_ID), 0, 0, decimal.Parse(txtQty.Text) * oMaterial.TotalInputQty, 0, "", false);
                                //    }
                                //}
                            }
                        }
                        ClearInput();
                        CalcualteTotals();
                    }
                    else
                    {
                        MessageBox.Show("Already exists ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Please Select the Item Name First...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void btnAddContact2_Click(object sender, EventArgs e)
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtNewSubCategory);
                clsCommon.ValidateForeignKey(ref txtNewSubCategory2);
                string sSerialNo = txtNewSerialNo.Text.Trim().Length > 0 ? txtNewSerialNo.Text.Trim() : "0";
                string SerialNo2 = txtNewSerialNo2.Text.Trim().Length > 0 ? txtNewSerialNo2.Text.Trim() : "0";
                string sItemSubCategory = txtNewSubCategory.Tag.ToString();
                string sItemSubCategory2_ID = txtNewSubCategory2.Tag.ToString();
                decimal dWeight = txtNewWeight.Text.Length > 0 && clsCommon.isCurrency(txtNewWeight.Text.Trim()) ? decimal.Parse(txtNewWeight.Text.Trim()) : 0;
                decimal dQty = txtNewQty.Text.Length > 0 && clsCommon.isCurrency(txtNewQty.Text.Trim()) ? decimal.Parse(txtNewQty.Text.Trim()) : 0;

                if (txtNewItemName.Tag != null && txtNewItemName.Tag.ToString().Trim().Length > 0)
                {
                    string itemCode = txtNewItemName.Tag.ToString().Trim();
                    if (!checktheSameItemInTheSplitItems(itemCode, sItemSubCategory, sItemSubCategory2_ID, sSerialNo, SerialNo2, false))
                    {
                        dgvNewItem.Rows.Add();
                        int iRow = dgvNewItem.Rows.Count - 1;
                        Fill_Datagrid(iRow, itemCode, clsGenaralName.getName_Item(itemCode), sItemSubCategory, sItemSubCategory2_ID, sSerialNo, SerialNo2, clsGenaralName.getName_ItemUOM(itemCode), 0, 0, dQty, dWeight, "", false);
                        ClearOutput();
                        CalcualteTotals();
                    }
                    else
                        MessageBox.Show("Already exists ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Please Select the Item Name First...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        #endregion

        #region Btn Clear Spred Items
        private void btnClearContact_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void btnClearContact2_Click(object sender, EventArgs e)
        {
            ClearOutput();
        }
        #endregion

        #region Btn Remove Spred Items
        private void btnRemoveContact_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception) { }
        }

        private void btnRemoveContact2_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Btn Temp
        private void frm_sasItemSpradeNote_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtSpradeCode.TextLength > 0 && txtSpradeCode.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtSpradeCode, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtFromStore, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtToStore, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtBOM, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSpradeCode, true);
                clsCommon.SetEnableDisable_NormalLabel(lblStoreName, true);

                txtSpradeCode.Tag = null;

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                if (clsConfig.bitemSplitNote_ToStoreActive)
                {
                    txtToStore.Visible = true;
                    lblToStore.Visible = true;
                    lblStoreName.Text = "From Store Name";
                }

                //Reset Primary Key
                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtSpradeCode.Text = "<Auto Generate>";
                else
                    txtSpradeCode.Clear();
                if (txtSpradeCode.Enabled)
                {
                    txtSpradeCode.SelectAll();
                    txtSpradeCode.Focus();
                }

                Attachments.Clear();
            }
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat_New(dgvNewItem, clsFormatter.colorGrid, UI_Color);

            if (clsConfig.bWrap_ItemGrid_ItemName)
            {
                this.dgvNewItem.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvNewItem.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }
        #endregion

        #region Clear Fileds
        private void ClearFields()
        {
            IsUpdate = false;
            lblCancelled.Visible = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtSpradeCode, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtFromStore, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtToStore, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtBOM, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSpradeCode, true);
            clsCommon.SetEnableDisable_NormalLabel(lblStoreName, true);

            if (clsConfig.bShow_GridViewColumn_Remarks)
                dgvNewItem.Columns["Remark1"].Visible = true;
            else
                dgvNewItem.Columns["Remark1"].Visible = false;

            if (clsConfig.bitemSplitNote_ToStoreActive)
            {
                txtToStore.Visible = true;
                lblToStore.Visible = true;
                lblStoreName.Text = "From Store Name";
            }

            tbl_cfgModule oModule = tbl_cfgModule.Select("PROD/016");
            if (oModule != null)
            {
                if (!oModule.IsEnable)
                {
                    txtBOM.Visible = false;
                    lblBOM.Visible = false;
                }
            }

            txtSpradeCode.Tag = null;
            txtProductID.Tag = null;
            txtFromStore.Tag = null;
            txtToStore.Tag = null;
            txtBOM.Tag = null;

            label7.Visible = false;
            label10.Visible = false;
            lblSerialNo.Visible = false;
            lblSerialNo2.Visible = false;
            txtSerialNo.Visible = false;
            txtSerialNo2.Visible = false;
            txtNewSerialNo.Visible = false;
            txtNewSerialNo2.Visible = false;

            dtpSplitNoteDate.Value = clsSecurity.getServerDateTime();

            ClearInput();
            ClearOutput();

            txtProductID.Clear();
            txtFromStore.Clear();
            txtToStore.Clear();
            txtBOM.Clear();
            txtRemark.Clear();
            chkUnbrand.Checked = false;
            chkShowSettle.Checked = false;
            dgvNewItem.Rows.Clear();
            CalcualteTotals();

            chkPrintOriginal.Checked = false;

            bHasApproved = false;
            bHasChecked = false;

            dt_ItemGrouped.Clear();
            userDetailsColorChanges();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtSpradeCode.Text = "<Auto Generate>";
            else
                txtSpradeCode.Clear();
            if (txtSpradeCode.Enabled)
            {
                txtSpradeCode.SelectAll();
                txtSpradeCode.Focus();
            }

            Attachments.Clear();
        }
        private void ClearInput()
        {
            txtItemName.Text = "";
            txtItemName.Tag = null;

            txtSubCategory.Text = "";
            txtSubCategory.Tag = null;
            txtSubCategory2.Text = "";
            txtSubCategory2.Tag = null;
            txtSerialNo2.Text = "";
            txtSerialNo.Text = "";
            txtQty.Text = "0";
            txtWeight.Text = "0.0";
        }
        private void ClearOutput()
        {
            txtNewItemName.Text = "";
            txtNewItemName.Tag = null;

            txtNewSubCategory.Text = "";
            txtNewSubCategory.Tag = null;
            txtNewSubCategory2.Text = "";
            txtNewSubCategory2.Tag = null;
            txtNewSerialNo2.Text = "";
            txtNewSerialNo.Text = "";
            txtNewQty.Text = "0";
            txtNewWeight.Text = "0.0";
        }
        #endregion

        #region Fill details
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_scsItemSpred sdetail = tbl_scsItemSpred.Select(sID);
                    if (sdetail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        if (sdetail.IsDeleted)
                            lblCancelled.Visible = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtSpradeCode, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtFromStore, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtToStore, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblSpradeCode, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblStoreName, false);
                        int iRow;
                        string sFromStore = "default", sToStore = "default";
                        dgvNewItem.Rows.Clear();

                        List<tbl_scsItemSpred_Detail_From> details = tbl_scsItemSpred_Detail_From.SelectAllByItemSpred_ID(sdetail.ItemSpred_ID);
                        foreach (tbl_scsItemSpred_Detail_From detail in details)
                        {
                            if (detail != null)
                            {
                                sFromStore = detail.Store_ID;
                                dgvNewItem.Rows.Add();
                                iRow = dgvNewItem.Rows.Count - 1;
                                Fill_Datagrid(iRow, detail.Item_ID, clsGenaralName.getName_Item(detail.Item_ID), detail.ItemSubCategory_ID,
                                    detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, clsGenaralName.getName_ItemUOM(detail.Item_ID), detail.Qty, detail.Weight, 0, 0, detail.Remark, true);
                            }
                        }

                        List<tbl_scsItemSpred_Detail_To> detailsTO = tbl_scsItemSpred_Detail_To.SelectAllByItemSpred_ID(sdetail.ItemSpred_ID);
                        foreach (tbl_scsItemSpred_Detail_To detailTO in detailsTO)
                        {
                            if (detailTO != null)
                            {
                                sToStore = detailTO.Store_ID;
                                dgvNewItem.Rows.Add();
                                iRow = dgvNewItem.Rows.Count - 1;
                                Fill_Datagrid(iRow, detailTO.Item_ID, clsGenaralName.getName_Item(detailTO.Item_ID), detailTO.ItemSubCategory_ID,
                                    detailTO.ItemSubCategory2_ID, detailTO.ItemSerialNo, detailTO.ItemSerialNo2, clsGenaralName.getName_ItemUOM(detailTO.Item_ID), 0, 0, detailTO.Qty, detailTO.Weight, detailTO.Remark, false);
                            }
                        }

                        dtpSplitNoteDate.Value = sdetail.ItemSpredDate;
                        txtSpradeCode.Tag = sdetail.ItemSpred_ID;
                        txtSpradeCode.Text = sdetail.ItemSpred_ID;
                        txtFromStore.Tag = sFromStore;
                        txtToStore.Tag = sToStore;
                        txtFromStore.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(sFromStore));
                        txtToStore.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(sToStore));
                        txtRemark.Text = sdetail.Remark;
                        CalcualteTotals();

                        if (sdetail.IsApproved)
                        {
                            bHasApproved = true;
                            glbApprovedDate = sdetail.DateApproved;
                        }
                        if (sdetail.IsChecked)
                        {
                            bHasChecked = true;
                            glbCheckedDate = sdetail.DateChecked;
                        }
                        userDetailsColorChanges();

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
        private void FillDetailsRigtSide(string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, decimal qty, decimal weight)
        {
            try
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSubCategory, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSubCategory2, false);
                clsCommon.SetEnableDisable_NormalTextbox(txtSerialNo, false);
                clsCommon.SetEnableDisable_NormalTextbox(txtSerialNo2, false);
                clsCommon.SetEnableDisable_NormalTextbox(txtRemark, false);
                clsCommon.SetEnableDisable_NormalTextbox(txtItemName, false);

                clsCommon.SetEnableDisable_NormalLabel(lblItemSubCategory, false);
                clsCommon.SetEnableDisable_NormalLabel(lblItemSubCategory2, false);
                clsCommon.SetEnableDisable_NormalLabel(lblItemName, false);
                clsCommon.SetEnableDisable_NormalLabel(lblSerialNo, false);
                clsCommon.SetEnableDisable_NormalLabel(lblSerialNo2, false);
                clsCommon.SetEnableDisable_NormalLabel(lblNewItemCode, false);

                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtNewSubCategory, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtNewSubCategory2, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtNewSerialNo, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtNewSerialNo2, true);


                txtItemName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Item(item_ID));


                txtSubCategory.Tag = itemSubCategory_ID;
                txtSubCategory.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(itemSubCategory_ID));
                txtSubCategory2.Tag = itemSubCategory2_ID;
                txtSubCategory2.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory2(itemSubCategory2_ID));
                txtSerialNo.Text = itemSerialNo;
                txtSerialNo2.Text = itemSerialNo2;
                txtQty.Text = clsFormatter.FormatDecimalPlaces_Quantity(qty);
                txtWeight.Text = clsFormatter.FormatDecimalPlaces_Weight(weight);


                txtNewItemName.Clear();
                txtNewQty.Text = "0";
                txtNewWeight.Text = "0";
                txtNewSerialNo.Clear();
                txtNewSerialNo2.Clear();
                txtNewSubCategory.Clear();
                txtNewSubCategory2.Clear();

                dgvNewItem.Rows.Clear();

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

        }

        #endregion

        #region fill Data grid
        private void Fill_Datagrid(int iRow, string itemCode, string ItemName, string ItemSubCategory, string ItemSubCategory2_ID,
          string ItemSerialNo, string ItemSerialNo2, string sUMO, decimal InputQty, decimal InputWeight, decimal OutputQty, decimal OutputWeight, string Remark, bool bIsInput)
        {
            dgvNewItem["LineNo1", iRow].Value = iRow;
            dgvNewItem["ItemCode", iRow].Value = itemCode;
            dgvNewItem["ItemName1", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Item(itemCode));
            dgvNewItem["ItemSubCategoryID", iRow].Tag = ItemSubCategory;
            dgvNewItem["ItemSubCategoryID", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(ItemSubCategory));
            dgvNewItem["ItemSubCategoryID2", iRow].Tag = ItemSubCategory2_ID;
            dgvNewItem["ItemSubCategoryID2", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory2(ItemSubCategory2_ID));
            dgvNewItem["ItemSerialNo1", iRow].Value = ItemSerialNo;
            dgvNewItem["ItemSerialNo22", iRow].Value = ItemSerialNo2;
            dgvNewItem["UOM", iRow].Value = sUMO;
            dgvNewItem["Quantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(InputQty);
            dgvNewItem["Weight", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(InputWeight);
            dgvNewItem["Qty1", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(OutputQty);
            dgvNewItem["WeightKg1", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(OutputWeight);
            dgvNewItem["IsLocked1", iRow].Value = bIsInput;
            dgvNewItem["Remark1", iRow].Value = Remark;
        }
        #endregion

        #region Events Datagrid
        private void DataGrid_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";
                DataGridView dgv = (DataGridView)sender;
                if (e.ColumnIndex >= 0)
                    sColName = dgv.Columns[e.ColumnIndex].Name;

                Cursor = Cursors.Hand;
            }
        }
        private void DataGrid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";
                DataGridView dgv = (DataGridView)sender;
                if (e.ColumnIndex >= 0)
                    sColName = dgv.Columns[e.ColumnIndex].Name;

                Cursor = Cursors.Default;
            }
        }
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail_CellDoubleClick(sender, e);
        }
        private void dgvNewItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail_CellDoubleClick(sender, e);
        }
        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = dgvNewItem.Columns[e.ColumnIndex].Name;

                if (sColName == "ItemCode" || sColName == "ItemName")
                {
                    string sItemID = "", sItemSubCategory1_ID = "", sItemSubCategory2_ID = "", sSerialNo1 = "", sSerialNo2 = "";
                    sItemID = clsValidate.ValidateGridValue(dgvNewItem, "ItemCode", e.RowIndex, "");
                    sItemSubCategory1_ID = clsValidate.ValidateGridTag(dgvNewItem, "ItemSubCategoryID", e.RowIndex, "default");
                    sItemSubCategory2_ID = clsValidate.ValidateGridTag(dgvNewItem, "ItemSubCategoryID2", e.RowIndex, "default");
                    sSerialNo1 = clsValidate.ValidateGridValue(dgvNewItem, "ItemSerialNo1", e.RowIndex, "0");
                    sSerialNo2 = clsValidate.ValidateGridValue(dgvNewItem, "ItemSerialNo22", e.RowIndex, "0");

                    clsAlerts.DisplayItemViewer(sItemID, sItemSubCategory1_ID, sItemSubCategory2_ID, sSerialNo1, sSerialNo2);
                }
            }
        }

        private void dgvNewItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalcualteTotals();
        }
        #endregion

        #region Double Click Events
        private void txtStoreName_DoubleClick(object sender, EventArgs e)
        {
            ClearFields();
            Search_ProducIDbyStoreName();
        }

        private void txtToStore_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterStore(ref txtToStore, true);
        }
        private void txtSubCategory_DoubleClick(object sender, EventArgs e)
        {
            Search_Subcategory();
        }
        private void txtCheckedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void txtApprovedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        private void txtSpradeCode_DoubleClick(object sender, EventArgs e)
        {
            Search_ItemSpradeNoteID();
        }

        private void txtItemName_DoubleClick(object sender, EventArgs e)
        {
            if (CheckValidity_ForignKey())
            {
                TextBox txtCategoryBox = new TextBox();
                TextBox txtSerialBox = new TextBox();
                clsHelpMethods_Local.SearchItemAdvanceStock(ref txtItemName, ref txtCategoryBox, ref txtSerialBox, txtFromStore.Tag.ToString(), "", "");
                if (txtItemName.Tag != null && txtItemName.Tag.ToString().Trim().Length > 0) //call add button
                {
                    txtSubCategory.Tag = txtCategoryBox.Tag;
                    txtSubCategory.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(txtCategoryBox.Tag.ToString()));
                    txtSubCategory2.Tag = txtCategoryBox.Text.Trim();
                    txtSubCategory2.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(txtCategoryBox.Text.Trim()));
                    txtSerialNo.Text = txtSerialBox.Tag.ToString();
                    txtSerialNo2.Text = txtSerialBox.Text.Trim();

                    txtWeight.SelectAll();
                    txtWeight.Focus();
                }
            }
        }
        private void txtSubCategory2_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterItemSubCategory2(ref txtSubCategory2);
        }

        private void txtNewItemName_DoubleClick(object sender, EventArgs e)
        {
            if (CheckValidity_ForignKey())
            {
                TextBox txtCategoryBox = new TextBox();
                TextBox txtSerialBox = new TextBox();
                clsHelpMethods_Local.SearchItemAdvance(ref txtNewItemName, ref txtCategoryBox, ref txtSerialBox);
                if (txtNewItemName.Tag != null && txtNewItemName.Tag.ToString().Trim().Length > 0) //call add button
                {
                    txtNewSubCategory.Tag = txtCategoryBox.Tag;
                    txtNewSubCategory.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(txtCategoryBox.Tag.ToString()));
                    txtNewSubCategory2.Tag = txtCategoryBox.Text.Trim();
                    txtNewSubCategory2.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(txtCategoryBox.Text.Trim()));
                    txtNewSerialNo.Text = txtSerialBox.Tag.ToString();
                    txtNewSerialNo2.Text = txtSerialBox.Text.Trim();

                    txtNewWeight.SelectAll();
                    txtNewWeight.Focus();
                }
            }
        }

        private void txtNewSubCategory_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_MasterItemSubCategory(ref txtNewSubCategory);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void txtNewSubCategory2_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterItemSubCategory2(ref txtNewSubCategory2);
        }

        private void txtBOM_DoubleClick(object sender, EventArgs e)
        {
            Search_BOMNo();
        }

        #endregion

        #region Event Keydown
        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            Search_ItemID(sender, e, true);
        }
        private void txtNewItemName_KeyDown(object sender, KeyEventArgs e)
        {
            Search_ItemID(sender, e, false);
        }
        private void txtProductID_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void txtStoreName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                ClearFields();
                Search_ProducIDbyStoreName();
            }
        }
        private void txtSpradeCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_ItemSpradeNoteID();

        }
        private void txtSubCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Subcategory();
        }
        private void txtSubCategory2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterItemSubCategory2(ref txtSubCategory2);
        }
        #endregion

        #region Event keypress
        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength(txtQty, e, 10, 6);
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength(txtWeight, e, 10, 6);
        }
        #endregion

        #region Print Method
        private void Print(bool bIsDraft)
        {
            try
            {
                string sDuplicateCopy = "";
                if (txtSpradeCode.TextLength > 0 && txtSpradeCode.Text != "<Auto Generate>")
                {
                    //update receipt
                    string sCreateUser = "", sCheckedUser = "", sApprovedUser = "";

                    bool bPermissinOkToPrint = true;
                    if (chkPrintOriginal.Checked)
                        bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_ItemSplitNote));
                    if (bPermissinOkToPrint)
                    {
                        tbl_scsItemSpred oSplitNote = tbl_scsItemSpred.Select(txtSpradeCode.Text.Trim());
                        if (oSplitNote != null)
                        {
                            if (!bIsDraft)
                            {

                                if (!chkPrintOriginal.Checked)
                                    sDuplicateCopy = (oSplitNote.PrintCount > 0) ? "Duplicate Copy " + oSplitNote.PrintCount : "";

                                oSplitNote.PrintCount++;
                                oSplitNote.Update();
                            }

                            oSplitNote.IsLocked = true;
                            sCreateUser = "[ " + clsGenaralName.getName_User(oSplitNote.CreateUser_ID) + " ] [ " + oSplitNote.DateCreate.ToShortDateString() + " ]";
                            if (oSplitNote.CheckedUser_ID != "default")
                                sCheckedUser = "[ " + clsGenaralName.getName_User(oSplitNote.CheckedUser_ID) + " ] [ " + oSplitNote.DateChecked.ToShortDateString() + " ]";
                            if (oSplitNote.ApprovedUser_ID != "default")
                                sApprovedUser = "[ " + clsGenaralName.getName_User(oSplitNote.ApprovedUser_ID) + " ] [ " + oSplitNote.DateApproved.ToShortDateString() + " ]";

                        }

                        if (clsConfig.bDataSetActive_SplitNote)
                        {
                            #region DataSet
                            glb_dtscsSplitNote.Clear();
                            glb_dtsReportExport.Clear();
                            string sFromStore = "", sToStore = "";

                            #region Split note Header
                            glb_dtscsSplitNote.dt_SplitNote.Adddt_SplitNoteRow(oSplitNote.ItemSpred_ID, oSplitNote.ItemSpredDate, oSplitNote.Remark, "", "", 0, 0, 0, 0, oSplitNote.IsChecked, oSplitNote.IsApproved, oSplitNote.IsFinished, oSplitNote.IsDeleted, oSplitNote.IsLocked, oSplitNote.IsSeattled, oSplitNote.CreateUser_ID, clsGenaralName.getName_User(oSplitNote.CreateUser_ID));

                            #endregion

                            #region Split note Detail
                            List<tbl_scsItemSpred_Detail_From> oSplitFrom = tbl_scsItemSpred_Detail_From.SelectAllByItemSpred_ID(oSplitNote.ItemSpred_ID);
                            foreach (tbl_scsItemSpred_Detail_From detail in oSplitFrom.OrderBy(p => p.Line_No))
                            {
                                sFromStore = detail.Store_ID;
                                glb_dtscsSplitNote.dt_SplitNote_Detail.Adddt_SplitNote_DetailRow(detail.ItemSpred_ID, detail.Item_ID, clsGenaralName.getName_Item(detail.Item_ID), detail.ItemSubCategory_ID, clsGenaralName.getName_ItemSubCategory(detail.ItemSubCategory_ID), detail.ItemSubCategory2_ID, clsGenaralName.getName_ItemSubCategory(detail.ItemSubCategory2_ID), detail.ItemSerialNo, detail.ItemSerialNo2, clsGenaralName.getName_ItemUOM(detail.Item_ID), detail.Qty, detail.Weight, detail.WeightDamaged, detail.WeightRejection, detail.Meter, detail.Remark, "IN");

                            }

                            List<tbl_scsItemSpred_Detail_To> oSplitTo = tbl_scsItemSpred_Detail_To.SelectAllByItemSpred_ID(oSplitNote.ItemSpred_ID);
                            foreach (tbl_scsItemSpred_Detail_To detail in oSplitTo.OrderBy(p => p.Line_No))
                            {
                                sToStore = detail.Store_ID;
                                glb_dtscsSplitNote.dt_SplitNote_Detail.Adddt_SplitNote_DetailRow(detail.ItemSpred_ID, detail.Item_ID, clsGenaralName.getName_Item(detail.Item_ID), detail.ItemSubCategory_ID, clsGenaralName.getName_ItemSubCategory(detail.ItemSubCategory_ID), detail.ItemSubCategory2_ID, clsGenaralName.getName_ItemSubCategory(detail.ItemSubCategory2_ID), detail.ItemSerialNo, detail.ItemSerialNo2, clsGenaralName.getName_ItemUOM(detail.Item_ID), detail.Qty, detail.Weight, detail.WeightDamaged, detail.WeightRejection, detail.Meter, detail.Remark, "OUT");

                            }
                            #endregion

                            #region Report Export Parameters
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("FromStore", clsGenaralName.getName_Store(sFromStore), true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ToStore", clsGenaralName.getName_Store(sToStore), true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", clsCommon.getCompanyEmail(), true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicateCopy, true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true);
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
                            glb_dtscsSplitNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, "Item Split Note", "", "", clsSecurity.UserNameLoged, "");
                            #endregion

                            #region Set Report Path and Datasets
                            frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                            string sGetRptPath = clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_ItemSplitNote));
                            rpt.print(sGetRptPath, glb_dtscsSplitNote, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_ItemSplitNote));
                            #endregion
                            #endregion
                        }
                        else
                        {
                            #region Views
                            Cursor = Cursors.WaitCursor;
                            string s_Path = "", sReportTitle = "Item Split Note", sFormula = "";
                            if (txtSpradeCode.TextLength > 0)
                                sFormula = "{vw_rpt_scsItemSplitNote.itemSpred_ID} = '" + txtSpradeCode.Text.Trim() + "'";

                            ReportDocument RD = new ReportDocument();
                            s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                s_Path += "\\reports\\SCS\\NotePrinting\\rpt_scsItemSplitNote.rpt";
                            else
                                s_Path += "\\reports\\SCS\\NotePrinting\\rpt_scsItemSplitNote.rpt";

                            frm_ReportViewer viewer = new frm_ReportViewer();
                            RD.Load(s_Path);
                          //  clsSecurity.LogonServer(ref RD);
                            RD.Refresh();

                            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                                RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);

                            RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                            RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
                            RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
                            RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);
                            RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                            RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                            RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                            RD.DataDefinition.FormulaFields["CompanyEmail"].Text = clsCommon.fncsetstring(clsCommon.getCompanyEmail());
                            RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                            RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                            RD.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring("Duplicate Copy");
                            RD.DataDefinition.FormulaFields["IsDraft"].Text = bIsDraft ? clsCommon.fncsetstring("DRAFT") : "";

                            if (bIsDraft)
                            {
                                if (!clsConfig.isVisibleCompanyInfoInDraftPrint)
                                {
                                    RD.DataDefinition.FormulaFields["CompanyName"].Text = "";
                                    RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = "";
                                    RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = "";
                                    RD.DataDefinition.FormulaFields["CompanyEmail"].Text = "";
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
                }
                else
                    MessageBox.Show("Please Select the ItemSplitNote To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region Check Validity

        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_ForignKey())
            {
                if (CheckValidity_EmptyFeilds())
                {
                    if (checkItemGriedValidity())
                    {
                        if (checkZeroQtyItemGriedValidity())
                        {
                            if (checkInOutItemGriedValidity())
                            {
                                if (CheckStockValidity())
                                {
                                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                                    {
                                        if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtFromStore.Tag.ToString(), IsUpdate))
                                            bStatus = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return bStatus;
        }
        private bool CheckValidity_EmptyFeilds()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (clsConfig.bitemSplitNote_ToStoreActive)
                {
                    if (txtToStore.Text.Trim().Length <= 0)
                    {
                        strMessage += "\n" + "To Store Name";
                        bStatus = false;
                    }
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
        private bool CheckValidity_ForignKey()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (txtFromStore.Text.Trim().Length <= 0)
                {
                    strMessage += "\n" + "Store Name";
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

        private bool CheckStockValidity()
        {
            bool bStatus = true;
            try
            {
                dt_ItemGrouped = clsCommon.DataGridViewToDataTable_ItemGrouped(dgvNewItem);

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

                    if (dQty > 0 || dWeight > 0)
                    {
                        if (!clsHelpMethods_Local.IsNonInventoryItem(sItemCode))
                        {
                            tbl_genStore_Stock oStoreStock;
                            oStoreStock = tbl_genStore_Stock.Select(txtFromStore.Tag.ToString(), sItemCode, sJobCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                            if (oStoreStock == null)
                            {
                                oStoreStock = new tbl_genStore_Stock(txtFromStore.Tag.ToString(), sItemCode, "default", "default", "default", "0", "0", 0, 0, 0, 0, 0, 0, 0, 0);
                                oStoreStock.Insert();
                            }                        
                            
                            tbl_genStoreMaster oStore = tbl_genStoreMaster.Select(txtFromStore.Tag.ToString());
                            if (oStoreStock != null && oStore != null)
                            {
                                #region if the item is old and check stock for more than one time
                                if (sItemStatus.ToLower() == "o")
                                {
                                    decimal dOldQty = 0, dOldWeight = 0;
                                    foreach (tbl_scsItemSpred_Detail_From oDoDetail in tbl_scsItemSpred_Detail_From.SelectAllByItemSpred_ID(txtSpradeCode.Text.Trim()).Where(p => p.Item_ID == sItemCode && p.ItemSubCategory_ID == sItemSubCategoryID && p.ItemSubCategory2_ID == sItemSubCategoryID2))
                                    {
                                        dOldQty += oDoDetail.Qty;
                                        dOldWeight += oDoDetail.Weight;
                                    }

                                    #region Old Items Quantity Validation
                                    if (clsConfig.bStockValidateQty_SplitNote)
                                    {
                                        if (oStoreStock.Qty + dOldQty < dQty)
                                        {
                                            strMessage += "Required Quantity of Item: \"" + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\" is not Availabe in  store :\"" + clsGenaralName.getName_Store(txtFromStore.Tag.ToString()) + "\"\n";
                                            bStatus = false;
                                        }
                                    }
                                    #endregion
                                    #region Old Items Weight Validation
                                    if (clsConfig.bStockValidateWeight_SplitNote)
                                    {
                                        if (oStoreStock.Weight + dOldWeight < dWeight)
                                        {
                                            strMessage += " Required Weight of Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "is Not Availabe In  store :" + clsGenaralName.getName_Store(txtFromStore.Tag.ToString()) + "\n";
                                            bStatus = false;
                                        }
                                    }
                                    #endregion

                                    if (!oStore.IsAllowMinusStock)
                                    {
                                        if (oStoreStock.Qty + dOldQty - dQty < 0)
                                        {
                                            strMessage += "Minus Quantities are not allowed - " + clsGenaralName.getName_Store(txtFromStore.Tag.ToString()) + "\"" + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\"\n";
                                            bStatus = false;
                                        }
                                    }
                                }
                                #endregion
                                #region first time added item ant have to check stock
                                else
                                {
                                    #region Weight Validation
                                    if (oStoreStock.Weight < dWeight && clsConfig.bStockValidateWeight_SplitNote)
                                    {
                                        strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + " Required Weight Is Not Availabe As IT Is In  " + clsGenaralName.getName_Store(txtFromStore.Tag.ToString()) + "\n";
                                        bStatus = false;
                                    }
                                    #endregion
                                    #region New Item Quantity Validation
                                    if (oStoreStock.Qty < dQty && clsConfig.bStockValidateQty_SplitNote)
                                    {
                                        strMessage += " Required Quantity of Item: \"" + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\" is not Availabe in store :\"" + clsGenaralName.getName_Store(txtFromStore.Tag.ToString()) + "\"\n";
                                        bStatus = false;
                                    }
                                    #endregion

                                    if (!oStore.IsAllowMinusStock)
                                    {
                                        if (oStoreStock.Qty - dQty < 0)
                                        {
                                            strMessage += "Minus Quantities are not allowed - " + clsGenaralName.getName_Store(txtFromStore.Tag.ToString()) + "\"" + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\"\n";
                                            bStatus = false;
                                        }
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                                if ((clsConfig.bStockValidateQty_SplitNote || clsConfig.bStockValidateWeight_SplitNote) && !clsHelpMethods_Local.IsNonInventoryItem(sItemCode) && (clsConfig.sSoftwareModel.Trim() != SoftwareModel_Sales.akt.ToString()))
                                {
                                    strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "  Is Not Available In " + clsGenaralName.getName_Store(txtFromStore.Tag.ToString()) + " Stock\n";
                                    bStatus = false;
                                }
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
        #endregion

        #region Check Validity splitNote Item
        private bool CheckValiditySpradeItem()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (txtItemName.Text.Trim().Length <= 0)
                {
                    strMessage += "\n" + "Item Name";
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

        #region Check ItemGridValidity
        private bool checkItemGriedValidity()
        {
            bool bIsValied = false;
            if (dgvNewItem.RowCount <= 0)
            {
                MessageBox.Show("Please Add Item.....!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                bIsValied = false;
            }
            else
            {
                bIsValied = true;
            }
            return bIsValied;
        }

        private bool checkZeroQtyItemGriedValidity()
        {
            bool bIsValied = false;

            foreach (DataGridViewRow row in dgvNewItem.Rows)
            {
                decimal dInQty, dOutQty = 0;
                dInQty = clsValidate.ValidateGridValue(dgvNewItem, "Quantity", row.Index, decimal.Parse("0.00"));
                dOutQty = clsValidate.ValidateGridValue(dgvNewItem, "Qty1", row.Index, decimal.Parse("0.00"));

                if (dInQty == 0 && dOutQty == 0)
                {
                    MessageBox.Show("Input and Output quantities should be greater than 0 ..!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bIsValied = false;
                    break;
                }
                else
                {
                    bIsValied = true;
                }
            }

            return bIsValied;
        }

        private bool checkInOutItemGriedValidity()
        {
            bool bIsValied = true;
            decimal dInQty = 0;
            decimal dOutQty = 0;

            foreach (DataGridViewRow row in dgvNewItem.Rows)
            {
                dInQty += clsValidate.ValidateGridValue(dgvNewItem, "Quantity", row.Index, decimal.Parse("0.00"));
                dOutQty += clsValidate.ValidateGridValue(dgvNewItem, "Qty1", row.Index, decimal.Parse("0.00"));
            }

            if (dInQty <= 0)
            {
                MessageBox.Show("Please Add at least one Input Item.....!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                bIsValied = false;
            }
            if (dOutQty <= 0)
            {
                MessageBox.Show("Please Add at least one Output Item.....!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                bIsValied = false;
            }

            return bIsValied;
        }
        #endregion

        #region validateEmptyForignKey
        private void ValidateEmptyForeignKey()
        {
            clsCommon.ValidateForeignKey(ref txtProductID);
            clsCommon.ValidateForeignKey(ref txtRemark);
            clsCommon.ValidateForeignKey(ref txtSubCategory2);
        }
        #endregion

        #region Search Methods
        private void Search_ProducIDbyStoreName()
        {
            clsSearch.Search_MasterStore(ref txtFromStore, true);
        }
        private void Search_Subcategory()
        {
            try
            {
                clsSearch.Search_MasterItemSubCategory(ref txtSubCategory);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_ItemSpradeNoteID()
        {
            try
            {
                clsSearch.Search_TransactionItemSpradeNote(ref txtSpradeCode, chkShowSettle.Checked);
                if (txtSpradeCode.Tag != null && txtSpradeCode.Tag.ToString().Trim().Length > 0)
                    FillDetails(txtSpradeCode.Tag.ToString());

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_BOMNo()
        {
            if (CheckValidity_ForignKey())
            {
                try
                {
                    tbl_cfgModule oProdModule = tbl_cfgModule.SelectAll().Where(r => r.Module_ID.Contains("PROD/") && r.IsEnable).FirstOrDefault();

                    if (oProdModule != null && oProdModule.Module_ID == "PROD/016")
                    {
                        clsSearch.SearchProdApparel_ItemFromProdJobBom_StoreFilter(ref txtBOM, "", txtFromStore.Tag.ToString());

                        if (txtBOM.Tag != null)
                        {
                            //tbl_prodTxJobCard oProdJob = tbl_prodTxJobCard.Select(txtBOM.Tag.ToString());
                            //if (oProdJob != null)
                            //{
                            //    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oProdJob.Item_ID_FG);
                            //    if (oItem != null)
                            //    {
                            //        txtItemName.Tag = oItem.Item_ID;
                            //        txtItemName.Text = clsGenaralName.getName_Item(oItem.Item_ID);
                            //        txtSubCategory.Text = clsGenaralName.getName_Brand(oItem.Brand_ID);
                            //    }
                            //}
                        }
                    }
                    else if (oProdModule != null && oProdModule.Module_ID == "PROD/018")
                    {
                        clsSearch.SearchProdPharma_ItemFromProdJobBom_StoreFilter(ref txtBOM, "", txtFromStore.Tag.ToString());

                        if (txtBOM.Tag != null)
                        {
                            //tbl_prod_pharmaTxJobCard oProdJob = tbl_prod_pharmaTxJobCard.Select(txtBOM.Tag.ToString());
                            //if (oProdJob != null)
                            //{
                            //    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oProdJob.Item_ID_FG);
                            //    if (oItem != null)
                            //    {
                            //        txtItemName.Tag = oItem.Item_ID;
                            //        txtItemName.Text = clsGenaralName.getName_Item(oItem.Item_ID);
                            //        txtSubCategory.Text = clsGenaralName.getName_Brand(oItem.Brand_ID);
                            //    }
                            //}
                        }
                    }
                }
                catch (Exception ex)
                {
                    SEACCException.Show(ex);
                    clsValidate.WriteErrorLog("", iFormID, ex);
                }
            }
        }
        #endregion

        #region check the Same Item In The Split Items?
        private bool checktheSameItemInTheSplitItems(string itemCode, string subCategory1, string subCategory2, string serialNo1, string serialNo2, bool isInput)
        {
            bool isAvailable = false;
            try
            {
                foreach (DataGridViewRow row in dgvNewItem.Rows)
                {
                    string sitemCode = dgvNewItem["ItemCode", row.Index].Value.ToString();
                    string sSubCategory1 = dgvNewItem["ItemSubCategoryID", row.Index].Tag.ToString();
                    string sSubCategory2 = dgvNewItem["ItemSubCategoryID2", row.Index].Tag.ToString();
                    string sSerialNo1 = dgvNewItem["ItemSerialNo1", row.Index].Value.ToString();
                    string sSerialNo2 = dgvNewItem["ItemSerialNo22", row.Index].Value.ToString();
                    bool bIsInput = clsValidate.ValidateGridValue(dgvNewItem, "IsLocked1", row.Index, false);

                    if (itemCode == sitemCode && subCategory1 == sSubCategory1 && subCategory2 == sSubCategory2 && serialNo1 == sSerialNo1 && sSerialNo2 == serialNo2 && isInput == bIsInput)
                        isAvailable = true;
                    else
                        isAvailable = false;

                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            return isAvailable;
        }
        #endregion

        #region Calculate Totals
        private void CalcualteTotals()
        {
            try
            {
                decimal dWeightInput = 0, dQtyInput = 0, dWeightOutput = 0, dQtyOutput = 0, dBalanceQty = 0, dBalanceWeight = 0, dPasantageQty = 0, dPasantageWeight = 0;
                foreach (DataGridViewRow Row in dgvNewItem.Rows)
                {
                    dQtyInput += clsValidate.ValidateGridValue(dgvNewItem, "Quantity", Row.Index, decimal.Parse("0"));
                    dQtyOutput += clsValidate.ValidateGridValue(dgvNewItem, "Qty1", Row.Index, decimal.Parse("0"));
                    dWeightInput += clsValidate.ValidateGridValue(dgvNewItem, "Weight", Row.Index, decimal.Parse("0"));
                    dWeightOutput += clsValidate.ValidateGridValue(dgvNewItem, "WeightKg1", Row.Index, decimal.Parse("0"));
                }
                txtTotalInputQty.Text = clsFormatter.FormatDecimalPlaces_Quantity(dQtyInput);
                txtTotalOutputQty.Text = clsFormatter.FormatDecimalPlaces_Quantity(dQtyOutput);
                txtTotalInputWeight.Text = clsFormatter.FormatDecimalPlaces_Weight(dWeightInput);
                txtTotalOutputWeight.Text = clsFormatter.FormatDecimalPlaces_Weight(dWeightOutput);

                dBalanceQty = (dQtyInput - dQtyOutput);
                dBalanceWeight = (dWeightInput - dWeightOutput);


                txtTotalItems.Text = dgvNewItem.Rows.Count.ToString();
                txtBalanceQty.Text = clsFormatter.FormatDecimalPlaces_Quantity(dBalanceQty);
                txtBalanceWeight.Text = clsFormatter.FormatDecimalPlaces_Weight(dBalanceWeight);
                FormatTextBox(dBalanceQty, txtBalanceQty);
                FormatTextBox(dBalanceWeight, txtBalanceWeight);

                //validate values
                if (dgvNewItem.Rows.Count > 0)
                {
                    if (dBalanceQty != 0)
                    {
                        try
                        {
                            dPasantageQty = (dBalanceQty / dQtyInput * 100);
                        }
                        catch (Exception)
                        {
                            dPasantageQty = (dBalanceQty / 1 * 100);
                        }
                    }

                    if (dBalanceWeight != 0)
                    {
                        try
                        {
                            dPasantageWeight = (dBalanceWeight / dWeightInput * 100);
                        }
                        catch (Exception)
                        {
                            dPasantageWeight = (dBalanceWeight / 1 * 100);
                        }
                    }
                }
                txtBalanceQtyPasentage.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(dPasantageQty);
                txtBalanceWeightPasentage.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(dPasantageWeight);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        private void FormatTextBox(decimal dValue, TextBox txtMyBox)
        {
            if (dValue > 0)
                txtMyBox.ForeColor = Color.Red;
            else if (dValue < 0)
                txtMyBox.ForeColor = Color.Green;
            else
                txtMyBox.ForeColor = Color.Black;
        }

        private void btnF5_input_Click(object sender, EventArgs e)
        {
            Search_ItemID(sender, new KeyEventArgs(Keys.F5), true);
        }

        private void btnF5_Output_Click(object sender, EventArgs e)
        {
            Search_ItemID(sender, new KeyEventArgs(Keys.F5), false);
        }

        private void btnOption_Click(object sender, EventArgs e)
        {

        }

        private void Search_ItemID(object sender, KeyEventArgs e, bool bIsInput)
        {
            try
            {
                if (CheckValidity_ForignKey())
                {
                    if (e.KeyCode == Keys.F1)
                    {
                        TextBox txtCategoryBox = new TextBox();
                        TextBox txtSerialBox = new TextBox();
                        clsHelpMethods_Local.SearchItemAdvance(ref txtNewItemName, ref txtCategoryBox, ref txtSerialBox);
                        if (txtNewItemName.Tag != null && txtNewItemName.Tag.ToString().Trim().Length > 0) //call add button
                        {
                            txtNewSubCategory.Tag = txtCategoryBox.Tag;
                            txtNewSubCategory.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(txtCategoryBox.Tag.ToString()));
                            txtNewSubCategory2.Tag = txtCategoryBox.Text.Trim();
                            txtNewSubCategory2.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(txtCategoryBox.Text.Trim()));
                            txtNewSerialNo.Text = txtSerialBox.Tag.ToString();
                            txtNewSerialNo2.Text = txtSerialBox.Text.Trim();

                            txtNewWeight.SelectAll();
                            txtNewWeight.Focus();
                        }
                    }
                    else if (e.KeyCode == Keys.F5)
                    {
                        frm_scsMultipleItemSelect_SplitNote frm = new frm_scsMultipleItemSelect_SplitNote();
                        frm.glb_bStockValidate_ManuallyDisable = true; //disable stock validity function
                        frm.ShowDialog();

                        if (frm.lstclsTmpMultipleSelectedItems.Count > 0)
                        {
                            foreach (clsTmpMultipleSelectedItems_ItemSplit oItem in frm.lstclsTmpMultipleSelectedItems)
                            {
                                dgvNewItem.Rows.Add();
                                int iRow = dgvNewItem.Rows.Count - 1;
                                Fill_Datagrid(iRow, oItem.sItemID, "", oItem.sItemSubCategoryID, oItem.sItemSubCategoryID2, oItem.sItemSerialNo, oItem.sItemSerialNo2, oItem.sUOMID, oItem.dQty_Input, oItem.dWeight_Input, oItem.dQty_Output, oItem.dWeight_Output, "", bIsInput);
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
        }

        private void frm_sasItemSpradeNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            Attachments.Close();
        }


        #region User Checked Approve Details

        private void frm_sasItemSpradeNote_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_sasItemSpradeNote_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                {
                    if (txtSpradeCode.Text != null && txtSpradeCode.TextLength > 0 && txtSpradeCode.Text != "<Auto Generate>")
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

                                    tbl_scsItemSpred objSRN = tbl_scsItemSpred.Select(txtSpradeCode.Text.Trim());
                                    if (objSRN != null)
                                    {
                                        objSRN.IsApproved = true;
                                        objSRN.DateApproved = clsSecurity.getServerDateTime();
                                        objSRN.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                        objSRN.Update();
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
                if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                {
                    if (txtSpradeCode.Text != null && txtSpradeCode.TextLength > 0 && txtSpradeCode.Text != "<Auto Generate>")
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

                                    tbl_scsItemSpred objSRN = tbl_scsItemSpred.Select(txtSpradeCode.Text.Trim());
                                    if (objSRN != null)
                                    {
                                        objSRN.IsChecked = true;
                                        objSRN.DateChecked = clsSecurity.getServerDateTime();
                                        objSRN.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                        objSRN.Update();
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
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        private void frm_sasItemSpradeNote_SF_History_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSpradeCode.Text != "" || txtSpradeCode.Text != "<Auto Generate>")
                {
                    tbl_scsItemSpred detail = tbl_scsItemSpred.Select(txtSpradeCode.Text);
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
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
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
        private void xSetting_Leave(object sender, EventArgs e)
        {
            xSetting.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            xSetting.Visible = false;
        }
        #endregion
    }
}