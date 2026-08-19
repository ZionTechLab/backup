using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataTire;
using Zion.ERP.Reports.DataSets.SCS;
using Zion.ERP.Reports.DataSets;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;
using System.Linq;
using System.Data;
using System.Drawing;
using SEACC.DATA.Data.SCS;
using ZION.ERP.Reports.DataSets.SCS;

namespace Digiteq
{
    public partial class frm_scsGoodTransferNote_new : SEACC_Form
    {
        
        // static bool IsUpdate = false;

        //string sFormConfigCode;
        //public int iFormID;

        public string glbGTNNo = "";

        //public bool bNoAccess;
        //public bool bHasChecked;
        //public bool bHasApproved;
        //    DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        //    DateTime glbCheckedDate = clsSecurity.getServerDateTime();

        dts_scsGoodTransferNote glb_dtsGoodTransferNote = new dts_scsGoodTransferNote();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();

        //for handle Duplicate Item  Validations
        public DataTable dt_ItemGrouped = new DataTable();

        InventoryTxnData oData = new InventoryTxnData();


        #region Form Load
        public frm_scsGoodTransferNote_new(FormName _enmForm)
        {
            //sFormConfigCode = clsAutocode.getFormConfigCode(FormName.scsGoodTransferNote);
            //iFormID = clsSecurity.getFormID(FormName.scsGoodTransferNote);

            //if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            //    bNoAccess = true;

            //InitializeComponent();

            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }

        private void frmCustomerOrder_Load(object sender, EventArgs e)
        {
            //clsFormatter.setFormatForm(this, clsHelpMethods_Local.getFormName(iFormID), 4, iFormID);

            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);
            clsFormatter.ApplyGridFormat_New(dgvDetail, clsFormatter.colorGrid, UI_Color);

            clsFill.Fill_StockNoteTypes(ref cmbStockNoteType);
            clsFill.Fill_ItemPrices(ref cmbItemPrice);

            if (clsConfig.bWrap_ItemGrid_ItemName)
            {
                dgvDetail.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            ClearFields();

            if (glbGTNNo.Length > 0)
                FillDetails(glbGTNNo);

            clsFormatter.ApplyGridFormat_New(dgvDetail, clsFormatter.colorGrid, UI_Color);
            // CusDataGridViewFormat();
            //  
        }
        #endregion

        #region Btn New
        private void frm_scsGoodTransferNote_new_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Grid delete
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                //if (dgvDetail.SelectedCells.Count != 0)
                //{
                //    if (dgvDetail.Rows.Count > 0)
                //    {
                //        dgvDetail.Rows.RemoveAt(dgvDetail.SelectedCells[0].RowIndex);
                //        clsHelpMethods_Local.Grid_LineNoChange(dgvDetail);
                //    }
                //}

                if (dgvDetail.SelectedCells.Count != 0)
                {
                    if (dgvDetail.Rows.Count > 0)
                    {

                        dgvDetail.Rows.RemoveAt(dgvDetail.SelectedCells[0].RowIndex);


                    }
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region Btn Save
        private void frm_scsGoodTransferNote_new_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    ValidateEmptyForeignKey();

                    #region Update
                    if (IsUpdate)
                    {
                        if (txtGTNID.Text.Trim().Length > 0)
                        {
                            tbl_scsGoodTransferNote oldRecord = tbl_scsGoodTransferNote.Select(txtGTNID.Text.Trim());
                            if (oldRecord != null)
                            {
                                if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished &&
                                    !oldRecord.IsDeleted && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                                {
                                    if (clsValidate.CheckValidity_TransactionCodeLength(txtGTNID.Text))
                                    {
                                      //  List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();

                                        #region Update Order Ref No

                                        if (txtOrderRefNo.Tag == null || txtOrderRefNo.Tag.ToString() == "default")
                                        {
                                            //txtOrderRefNo.Tag = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.zIssuedRefNo));
                                            tbl_zIssuedRefNo orf = new tbl_zIssuedRefNo(oldRecord.IssuedRefNo_ID,
                                                txtOrderRefNo.Text.Trim());
                                            orf.Update();
                                        }

                                        #endregion

                                        #region Update Header

                                        tbl_scsGoodTransferNote detail = new tbl_scsGoodTransferNote(txtGTNID.Text.Trim(),
                                            dtpGTNDate.Value, txtRemark.Text.Trim(), txtStoreFrom.Tag.ToString().Trim(),
                                            txtStoreTo.Tag.ToString().Trim(), "default", txtOrderRefNo.Tag.ToString(),
                                            oldRecord.CreateUser_ID, clsSecurity.UserIDLoged, oldRecord.CheckedUser_ID,
                                            oldRecord.ApprovedUser_ID, oldRecord.DeletedUser_ID, oldRecord.PrintedUser_ID,
                                            oldRecord.CreateTerminal_ID, clsSecurity.TerminalID,
                                            oldRecord.DeletedTerminal_ID, oldRecord.PrintedTerminal_ID,
                                            oldRecord.DateCreate, clsSecurity.getServerDateTime(), glbCheckedDate,
                                            glbApprovedDate, oldRecord.DateDeleted, oldRecord.DatePrinted,
                                            bHasChecked, bHasApproved, oldRecord.IsDeleted, oldRecord.IsLocked,
                                            oldRecord.IsFinished, chkUnitPricing.Checked, oldRecord.PrintCount,
                                            ((ComboBoxItem)cmbItemPrice.SelectedItem).Value,
                                            clsSecurity.CompanyID, clsSecurity.BranchID);
                                        detail.Update();

                                        #endregion

                                        #region Rollback Store Stock
                                        foreach (tbl_scsGoodTransferNote_Detail oUpdatedRecore in
                                            tbl_scsGoodTransferNote_Detail.SelectAllByGoodTransferNote_ID(
                                                txtGTNID.Text.Trim()))
                                        {
                                            decimal dWeightedAverageCostPrice = 0;
                                            //clsHelpMethods_Local.UpdateStoreStock(iFormID, detail.GoodTransferNote_ID,
                                            //    detail.GoodTransferNoteDate, oUpdatedRecore.Item_Code, "0",
                                            //    txtStoreFrom.Tag.ToString(), oUpdatedRecore.Qty, oUpdatedRecore.Weight,
                                            //    oUpdatedRecore.TatalAmount, true, false, false, ref dWeightedAverageCostPrice);
                                            //clsHelpMethods_Local.UpdateStoreStock(iFormID, detail.GoodTransferNote_ID,
                                            //    detail.GoodTransferNoteDate, oUpdatedRecore.Item_Code, "0",
                                            //    txtStoreTo.Tag.ToString(), oUpdatedRecore.Qty, oUpdatedRecore.Weight,
                                            //    oUpdatedRecore.TatalAmount, true, true, false, ref dWeightedAverageCostPrice);

                                            oUpdatedRecore.WeightedAvgCost = clsProcessMethods.GetItemWeightedAvarageCostPrice(oUpdatedRecore.Item_Code);
                                            oUpdatedRecore.Update();
                                        }

                                        #endregion

                                        #region Delete Old Records
                                        tbl_scsGoodTransferNote_Detail.DeleteAllByGoodTransferNote_ID(txtGTNID.Text.Trim());
                                        #endregion

                                        #region Update Detail
                                        int iCount = 0;
                                        foreach (DataGridViewRow row in dgvDetail.Rows)
                                        {
                                            try
                                            {
                                                
                                                string sItemCode = "",
                                                    sUom = "default",
                                                    sJobCode = "",
                                                    sSelectArea_ID = "",
                                                    sDepartment_ID = "",
                                                    sSection_ID = "",
                                                    sStore_ID = "",
                                                    sDepartmentNote_ID = "",
                                                    sSectionNote_ID = "",
                                                    sStoreNote_ID = "",
                                                    sItemSubCategoryID1 = "",
                                                    sItemSubCategoryID2 = "",
                                                    sItemSerialNo1 = "",
                                                    sItemSerialNo2 = "";
                                                decimal dWeight = 0,
                                                    dQuantity = 0,
                                                    dTotalCost_FIFO = 0,
                                                    dUnitPrice = 0,
                                                    dWeightPrice = 0,
                                                    dTotalAmount = 0;
                                                int iLineNo = 0;
                                                #endregion

                                                #region Grid Validation
                                                iLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, 0);
                                                sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                                sUom = clsValidate.ValidateGridTag(dgvDetail, "UOM", row.Index, "default");
                                                dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                                dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                                sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
                                                sSelectArea_ID = clsValidate.ValidateGridValue(dgvDetail, "SelectArea_ID", row.Index, "default");
                                                sDepartment_ID = clsValidate.ValidateGridValue(dgvDetail, "Department_ID", row.Index, "default");
                                                sSection_ID = clsValidate.ValidateGridValue(dgvDetail, "Section_ID",  row.Index, "default");
                                                sStore_ID = clsValidate.ValidateGridValue(dgvDetail, "Store_ID", row.Index, "default");
                                                sDepartmentNote_ID = clsValidate.ValidateGridValue(dgvDetail, "DepartmentNote_ID", row.Index, "default");
                                                sSectionNote_ID = clsValidate.ValidateGridValue(dgvDetail, "SectionNote_ID", row.Index, "default");
                                                sStoreNote_ID = clsValidate.ValidateGridValue(dgvDetail, "StoreNote_ID", row.Index, "default");
                                                sItemSubCategoryID1 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                                                sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                                sItemSerialNo1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                                                sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                                dTotalCost_FIFO = clsValidate.ValidateGridValue(dgvDetail, "CostPrice", row.Index, decimal.Parse("0.00"));
                                                dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "ItemUnitPrice", row.Index, decimal.Parse("0.00"));
                                                dTotalAmount = clsValidate.ValidateGridValue(dgvDetail, "ItemTotalValue", row.Index, decimal.Parse("0.00"));
                                                #endregion

                                                #region Insert Details

                                                if (sItemCode.Length > 0)
                                                {
                                                    //clsHelpMethods.GetMaxzimumLineNoGoodsTransferNote(txtGTNID.Text.Trim())
                                                    tbl_scsGoodTransferNote_Detail items = new tbl_scsGoodTransferNote_Detail(iLineNo, txtGTNID.Text.Trim(),
                                                            sItemCode, sItemSubCategoryID1, sItemSubCategoryID2,
                                                            sItemSerialNo1, sItemSerialNo2, sUom, dQuantity, dWeight, dUnitPrice, dTotalAmount, "", clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemCode));
                                                    items.Insert();

                                                    //  clsHelpMethods_Local.UpdateOrInsertStoreStock(true, true, sItemCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, sJobCode, txtStoreFrom.Tag.ToString(), dQuantity, dWeight, 0, 0, false, false, true);
                                                    //   clsHelpMethods_Local.UpdateOrInsertStoreStock(true, true, sItemCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, sJobCode, txtStoreTo.Tag.ToString(), dQuantity, dWeight, 0, 0, false, true, true);

                                                    #region Pass Value to Inventory Detail - From Store
                                                    //tbl_scsInventoryTxnDetail oInventoryDetail_From = new tbl_scsInventoryTxnDetail(iFormID, ++iCount, 0, txtGTNID.Text.Trim(), dtpGTNDate.Value,
                                                    //                            "", "", "", "", "default", "default", txtStoreFrom.Tag.ToString(),
                                                    //                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), 0, dQuantity, dUnitPrice, 0, false);
                                                    //oListInventory.Add(oInventoryDetail_From);
                                                    //#endregion

                                                    //#region Pass Value to Inventory Detail - To Store
                                                    //tbl_scsInventoryTxnDetail oInventoryDetail_To = new tbl_scsInventoryTxnDetail(iFormID, ++iCount, 0, txtGTNID.Text.Trim(), dtpGTNDate.Value,
                                                    //                            "", "", "", "", "default", "default", txtStoreTo.Tag.ToString(),
                                                    //                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), dQuantity, 0, dUnitPrice, 0, false);
                                                    //oListInventory.Add(oInventoryDetail_To);
                                                    #endregion
                                                }

                                                #endregion
                                            }
                                            catch (Exception ex)
                                            {
                                                clsValidate.WriteErrorLog("", iFormID, ex);
                                                SEACCException.Show(ex);
                                            }
                                        }
                                        #endregion

                                        #region Update Store Stock
                                        foreach (tbl_scsGoodTransferNote_Detail oUpdatedRecord in tbl_scsGoodTransferNote_Detail.SelectAllByGoodTransferNote_ID(txtGTNID.Text.Trim()))
                                        {
                                            decimal dWeightedAverageCostPrice = 0;

                                            //clsHelpMethods_Local.UpdateStoreStock(iFormID, detail.GoodTransferNote_ID,
                                            //    detail.GoodTransferNoteDate, oUpdatedRecord.Item_Code, "0",
                                            //    txtStoreFrom.Tag.ToString(), oUpdatedRecord.Qty, oUpdatedRecord.Weight,
                                            //    oUpdatedRecord.TatalAmount, false, false, false, ref dWeightedAverageCostPrice);
                                            //clsHelpMethods_Local.UpdateStoreStock(iFormID, detail.GoodTransferNote_ID,
                                            //    detail.GoodTransferNoteDate, oUpdatedRecord.Item_Code, "0",
                                            //    txtStoreTo.Tag.ToString(), oUpdatedRecord.Qty, oUpdatedRecord.Weight,
                                            //    oUpdatedRecord.TatalAmount, false, true, false, ref dWeightedAverageCostPrice);

                                            // clsHelpMethods_Local.UpdateFifo_Stock(iFormID, detail.GoodTransferNote_ID, detail.GoodTransferNoteDate, detail.StoreID_From, oUpdatedRecord.Item_Code, oUpdatedRecord.ItemSerialNo, oUpdatedRecord.Qty, oUpdatedRecord.UnitPrice, false);
                                            //   clsHelpMethods_Local.UpdateFifo_Stock(iFormID, detail.GoodTransferNote_ID, detail.GoodTransferNoteDate, detail.StoreID_To, oUpdatedRecord.Item_Code, oUpdatedRecord.ItemSerialNo, oUpdatedRecord.Qty, oUpdatedRecord.UnitPrice, true);
                                        }
                                        #endregion

                                        #region Update Inventory
                                        //tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtGTNID.Text.Trim(), dtpGTNDate.Value, txtRemark.Text.Trim(),
                                        //    "default", "default", "default", -1, decimal.Parse(txtTotAmount.Text.Trim()),
                                        //    "", "", "", "", false, clsSecurity.UserIDLoged);

                                        //clsHelpMethods.Update_Inventory(oHeader, oListInventory);

                                        var responce = oData.Update_InventoryTxn(iFormID, txtGTNID.Text.Trim());
                                        if (!responce.IsSuccess)
                                        {
                                            clsValidate.WriteErrorLog(txtGTNID.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
                                        }
                                        #endregion

                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("This ID is Empty!!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Good Transfer Note " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordUpdateIsBlock), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    #endregion

                    #region Insert Data
                    else
                    {
                        if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                            txtGTNID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                        if (clsValidate.CheckValidity_TransactionCodeLength(txtGTNID.Text)) // if (txtGTNID.Text.Trim().Length > 0)
                        {
                            tbl_scsGoodTransferNote oGTN = tbl_scsGoodTransferNote.Select(txtGTNID.Text.Trim());
                            if (oGTN == null)
                            {
                              //  List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();

                                #region Insert Order Ref No
                                if (txtOrderRefNo.Tag == null || txtOrderRefNo.Tag.ToString() == "default")
                                {
                                    txtOrderRefNo.Tag = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.zIssuedRefNo));
                                    tbl_zIssuedRefNo orf = new tbl_zIssuedRefNo(txtOrderRefNo.Tag.ToString(), txtOrderRefNo.Text.Trim());
                                    orf.Insert();
                                }
                                #endregion

                                #region Header
                                tbl_scsGoodTransferNote detail = new tbl_scsGoodTransferNote(txtGTNID.Text.Trim(), dtpGTNDate.Value, txtRemark.Text.Trim(), txtStoreFrom.Tag.ToString().Trim(), txtStoreTo.Tag.ToString().Trim(),
                                                     "default", txtOrderRefNo.Tag.ToString(), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default", clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                                     clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                     glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                     bHasChecked, bHasApproved, false, false, false, chkUnitPricing.Checked, 0, ((ComboBoxItem)cmbItemPrice.SelectedItem).Value, clsSecurity.CompanyID, clsSecurity.BranchID);
                                detail.Insert();
                                #endregion

                                #region Detail
                                int iCount = 0;
                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                {
                                    try
                                    {
                                        
                                        string sItemCode = "", sUom = "default", sJobCode = "", sSelectArea_ID = "", sDepartment_ID = "",
                                                                        sSection_ID = "", sStore_ID = "", sDepartmentNote_ID = "", sSectionNote_ID = "", sStoreNote_ID = "",
                                                                        sItemSubCategoryID1 = "", sItemSubCategoryID2 = "", sItemSerialNo1 = "", sItemSerialNo2 = "";
                                        decimal dWeight = 0, dQuantity = 0, dTotalCost_FIFO = 0, dUnitPrice = 0, dWeightPrice = 0, dTotalAmount = 0;
                                        int iLineNo = 0;
                                        #endregion

                                        #region Grid Validation
                                        iLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, 0);
                                        sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                        sUom = clsValidate.ValidateGridTag(dgvDetail, "UOM", row.Index, "default");
                                        dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                        dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                        sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
                                        sSelectArea_ID = clsValidate.ValidateGridValue(dgvDetail, "SelectArea_ID", row.Index, "default");
                                        sDepartment_ID = clsValidate.ValidateGridValue(dgvDetail, "Department_ID", row.Index, "default");
                                        sSection_ID = clsValidate.ValidateGridValue(dgvDetail, "Section_ID", row.Index, "default");
                                        sStore_ID = clsValidate.ValidateGridValue(dgvDetail, "Store_ID", row.Index, "default");
                                        sDepartmentNote_ID = clsValidate.ValidateGridValue(dgvDetail, "DepartmentNote_ID", row.Index, "default");
                                        sSectionNote_ID = clsValidate.ValidateGridValue(dgvDetail, "SectionNote_ID", row.Index, "default");
                                        sStoreNote_ID = clsValidate.ValidateGridValue(dgvDetail, "StoreNote_ID", row.Index, "default");
                                        sItemSubCategoryID1 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                                        sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                        sItemSerialNo1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                                        sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                        dTotalCost_FIFO = clsValidate.ValidateGridValue(dgvDetail, "CostPrice", row.Index, decimal.Parse("0.00"));
                                        dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "ItemUnitPrice", row.Index, decimal.Parse("0.00"));
                                        dTotalAmount = clsValidate.ValidateGridValue(dgvDetail, "ItemTotalValue", row.Index, decimal.Parse("0.00"));
                                        #endregion

                                        if (sItemCode.Length > 0)
                                        {
                                            decimal dWeightedAverageCostPrice = 0;
                                            //clsHelpMethods.GetMaxzimumLineNoGoodsTransferNote(txtGTNID.Text.Trim())
                                            tbl_scsGoodTransferNote_Detail items = new tbl_scsGoodTransferNote_Detail(iLineNo, txtGTNID.Text.Trim(),
                                                sItemCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, sUom,
                                                dQuantity, dWeight, dUnitPrice, dTotalAmount, "", clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemCode));
                                            items.Insert();

                                         //   clsHelpMethods_Local.UpdateStoreStock(iFormID, detail.GoodTransferNote_ID, detail.GoodTransferNoteDate, sItemCode, "0", txtStoreFrom.Tag.ToString(), dQuantity, dWeight, dTotalAmount, false, false, false, ref dWeightedAverageCostPrice);
                                         //   clsHelpMethods_Local.UpdateStoreStock(iFormID, detail.GoodTransferNote_ID, detail.GoodTransferNoteDate, sItemCode, "0", txtStoreTo.Tag.ToString(), dQuantity, dWeight, dTotalAmount, false, true, false, ref dWeightedAverageCostPrice);
                                            
                                            //   clsHelpMethods_Local.UpdateFifo_Stock(iFormID, detail.GoodTransferNote_ID, detail.GoodTransferNoteDate, txtStoreFrom.Tag.ToString(), items.Item_Code, items.ItemSerialNo, items.Qty, items.UnitPrice, false);
                                            //     clsHelpMethods_Local.UpdateFifo_Stock(iFormID, detail.GoodTransferNote_ID, detail.GoodTransferNoteDate, txtStoreTo.Tag.ToString(), items.Item_Code, items.ItemSerialNo, items.Qty, items.UnitPrice, true);
                                            
                                            #region Pass Value to Inventory Detail - From Store
                                            //tbl_scsInventoryTxnDetail oInventoryDetail_From = new tbl_scsInventoryTxnDetail(iFormID, ++iCount, 0, txtGTNID.Text.Trim(), dtpGTNDate.Value,
                                            //                            "", "", "", "", "default", "default", txtStoreFrom.Tag.ToString(),
                                            //                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), 0, dQuantity, dUnitPrice, 0, false);
                                            //oListInventory.Add(oInventoryDetail_From);
                                            //#endregion

                                            //#region Pass Value to Inventory Detail - To Store
                                            //tbl_scsInventoryTxnDetail oInventoryDetail_To = new tbl_scsInventoryTxnDetail(iFormID, ++iCount, 0, txtGTNID.Text.Trim(), dtpGTNDate.Value,
                                            //                            "", "", "", "", "default", "default", txtStoreTo.Tag.ToString(),
                                            //                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), dQuantity, 0, dUnitPrice, 0, false);
                                            //oListInventory.Add(oInventoryDetail_To);
                                            #endregion
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                }
                                #endregion

                                #region Attachments
                                Attachments.Insert(txtGTNID.Text.ToString());
                                #endregion

                                #region Update Inventory
                                //tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtGTNID.Text.Trim(), dtpGTNDate.Value, txtRemark.Text.Trim(),
                                //    "default", "default", "default", -1, decimal.Parse(txtTotAmount.Text.Trim()),
                                //    "", "", "", "", false, clsSecurity.UserIDLoged);

                                //clsHelpMethods.Update_Inventory(oHeader, oListInventory);

                                var responce = oData.Update_InventoryTxn(iFormID, txtGTNID.Text.Trim());
                                if (!responce.IsSuccess)
                                {
                                    clsValidate.WriteErrorLog(txtGTNID.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
                                }
                                #endregion

                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("This ID is already added!!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //else
                        //    MessageBox.Show("Good Transfer Note " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID, ex);
                    SEACCException.Show(ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                    tbl_scsGoodTransferNote oldRecord = tbl_scsGoodTransferNote.Select(txtGTNID.Text.Trim());
                    ClearFields();
                    if (oldRecord != null)
                        FillDetails(oldRecord.GoodTransferNote_ID);
                }
            }
        }


        #region Btn Print
        private void frm_scsGoodTransferNote_new_SF_printButton_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_scsGoodTransferNote_new_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region Btn add Item
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0)
            {
                tbl_genItemMaster detail = tbl_genItemMaster.Select(txtItemID.Tag.ToString().Trim());
                if (detail != null)
                {
                    clsCommon.ValidateForeignKey(ref txtItemSubCategory);
                    clsCommon.ValidateForeignKey(ref txtItemSerialNo, "0");
                    RefreshGridByItem_ID(detail.Item_ID);
                }
            }
        }
        #endregion

        #region Btn cancel
        private void frm_scsGoodTransferNote_new_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGTNID.TextLength > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpGTNDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreFrom.Tag.ToString(), IsUpdate))
                            {
                                if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreTo.Tag.ToString(), IsUpdate))
                                {
                                    Cursor = Cursors.WaitCursor;
                                    tbl_scsGoodTransferNote detail = tbl_scsGoodTransferNote.Select(txtGTNID.Text.Trim());
                                    if (detail != null)
                                    {
                                        if (!detail.IsLocked)
                                        {
                                            if (!detail.IsDeleted)
                                            {
                                                DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " GTN : " + detail.GoodTransferNote_ID), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                                if (msgResult == DialogResult.Yes)
                                                {
                                                    #region Update Other Tables
                                                    List<tbl_scsGoodTransferNote_Detail> Olddetails = tbl_scsGoodTransferNote_Detail.SelectAllByGoodTransferNote_ID(txtGTNID.Text.Trim());
                                                    foreach (tbl_scsGoodTransferNote_Detail Olddetail in Olddetails)
                                                    {
                                                        if (Olddetail.Item_Code != null)
                                                        {
                                                            #region Update Store Stock
                                                            decimal dWeightedAverageCostPrice = 0;

                                                       //     clsHelpMethods_Local.UpdateStoreStock(iFormID, detail.GoodTransferNote_ID, detail.GoodTransferNoteDate, Olddetail.Item_Code, "0", txtStoreFrom.Tag.ToString(), Olddetail.Qty, Olddetail.Weight, Olddetail.TatalAmount, true, false, false, ref dWeightedAverageCostPrice);
                                                       //     clsHelpMethods_Local.UpdateStoreStock(iFormID, detail.GoodTransferNote_ID, detail.GoodTransferNoteDate, Olddetail.Item_Code, "0", txtStoreTo.Tag.ToString(), Olddetail.Qty, Olddetail.Weight, Olddetail.TatalAmount, true, true, false, ref dWeightedAverageCostPrice);

                                                            Olddetail.WeightedAvgCost = clsProcessMethods.GetItemWeightedAvarageCostPrice(Olddetail.Item_Code);
                                                            Olddetail.Update();

                                                            //  clsHelpMethods_Local.RollBackFifo_Stock(iFormID, Olddetail.GoodTransferNote_ID);
                                                            #endregion
                                                        }
                                                    }
                                                    #endregion

                                                    detail.DeletedTerminal_ID = clsSecurity.TerminalID;
                                                    detail.DeletedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.DateDeleted = clsSecurity.getServerDateTime();

                                                    detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.DateModified = clsSecurity.getServerDateTime();
                                                    detail.IsDeleted = true;
                                                    detail.Update();

                                                    //    clsHelpMethods.Delete_Inventory(iFormID, 0, txtGTNID.Text.Trim());
                                                    var responce = oData.Delete_InventoryTxn(iFormID, txtGTNID.Text.Trim());
                                                    if (!responce.IsSuccess)
                                                    {
                                                        clsValidate.WriteErrorLog(txtGTNID.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
                                                    }
                                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    ClearFields();
                                                }
                                            }
                                            else
                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyDeleted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        }
                                        else
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLockedCantDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Btn Item F5
        private void btnItemF5_Click(object sender, EventArgs e)
        {
            Search_ItemID(sender, new KeyEventArgs(Keys.F5));
        }
        #endregion

        #region Btn Temp
        private void frm_scsGoodTransferNote_new_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtGTNID.TextLength > 0 && txtGTNID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtGTNID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreFrom, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreTo, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, true);

                setEnableItems();

                clsCommon.SetEnableDisable_NormalLabel(lblGTNID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblFromStore, true);
                clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, true);

                txtGTNID.Tag = null;
                dtpGTNDate.Value = clsSecurity.getServerDateTime();

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Primary Key
                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtGTNID.Text = "<Auto Generate>";
                else
                    txtGTNID.Clear();
                if (txtGTNID.Enabled)
                {
                    txtGTNID.SelectAll();
                    txtGTNID.Focus();
                }

                Attachments.Clear();
            }
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            //clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorStock1, clsFormatter.colorDigiteqTheamColorStockForColour, clsFormatter.colorDigiteqTheamColorStockBackColour);
            clsHelpMethods_Local.FormatGrid_Stock(dgvDetail);

            //Change Grid Headers
            dgvDetail.Columns["ItemSubCategoryID"].HeaderText = clsConfig.sItemSubCategory;
            dgvDetail.Columns["GoodsFrom"].HeaderText = "From Store";
            dgvDetail.Columns["Note_ID"].HeaderText = "GTN Number";

            dgvDetail.Columns["Weight"].Visible = !clsConfig.bHide_GridViewColumn_Stock_Weight;
            dgvDetail.Columns["GoodsFrom"].Visible = !clsConfig.bHide_GridViewColumn_Stock_GoodsFrom;
            dgvDetail.Columns["Note_ID"].Visible = !clsConfig.bHide_GridViewColumn_Stock_NoteID;

            if (clsConfig.bDisplay_ItemUnitPrice_StoreTransferNotes)
            {
                dgvDetail.Columns["ItemUnitPrice"].Visible = true;
                dgvDetail.Columns["ItemTotalValue"].Visible = true;
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            lblCancelled.Visible = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtGTNID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreFrom, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreTo, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, true);
            setEnableItems();
            clsCommon.SetEnableDisable_NormalLabel(lblGTNID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblFromStore, true);
            clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, true);

            txtStoreFrom.Tag = null;
            txtStoreTo.Tag = null;
            txtItemSubCategory.Tag = null;
            txtItemSerialNo.Tag = null;
            txtOrderRefNo.Tag = null;
            txtItemID.Tag = null;

            txtItemSerialNo.Clear();
            txtItemSubCategory.Clear();
            txtGTNID.Clear();
            txtRemark.Clear();
            txtStoreFrom.Clear();
            txtStoreTo.Clear();
            //  clearLocationFields();
            txtOrderRefNo.Text = "-";

            txtItemID.Clear();

            bHasApproved = false;
            bHasChecked = false;
            userDetailsColorChanges();

            //chkSettings.Checked = true;
            dgvDetail.Rows.Clear();
            dtpGTNDate.Value = clsSecurity.getServerDateTime();

            dtpGTNDate.Enabled = !clsConfig.bLock_TransactionDate_SCS;

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtGTNID.Text = "<Auto Generate>";
            else
                txtGTNID.Clear();
            if (txtGTNID.Enabled)
            {
                txtGTNID.SelectAll();
                txtGTNID.Focus();
            }

            chkShowSettle.Checked = false;
            cmbStockNoteType.SelectedIndex = (cmbStockNoteType.Items.Count > 0) ? 0 : -1;
            foreach (ComboBoxItem d in cmbItemPrice.Items)
            {
                if (d.Value == clsConfig.sItemUnitPriceCode_Default)
                {
                    cmbItemPrice.SelectedItem = d;
                    break;
                }
            }
            chkPrintOriginal.Checked = false;

            txtTotQty.Clear();
            txtTotAmount.Clear();

            //string sTmpStoreID = "", sTmpStoreName = "";
            //if (clsProcessMethods.getStore_MainStore_ByBranchID(clsSecurity.BranchID, ref sTmpStoreID, ref sTmpStoreName))
            //{
            //    txtStoreFrom.Tag = sTmpStoreID;
            //    txtStoreFrom.Text = sTmpStoreName;
            //}

            dt_ItemGrouped.Clear();

            Attachments.Clear();
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    ClearFields();
                    tbl_scsGoodTransferNote detail = tbl_scsGoodTransferNote.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtGTNID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreFrom, false);
                        clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblGTNID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblFromStore, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, false);

                        //asign values
                        txtStoreFrom.Tag = detail.StoreID_From;
                        txtStoreTo.Tag = detail.StoreID_To;

                        //fill order detials
                        tbl_zIssuedRefNo order = tbl_zIssuedRefNo.Select(detail.IssuedRefNo_ID);
                        if (order != null)
                        {
                            txtOrderRefNo.Tag = order.IssuedRefNo_ID;
                            txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(order.IssuedRefNo);
                        }

                        txtGTNID.Text = detail.GoodTransferNote_ID;
                        txtRemark.Text = detail.Remark;
                        dtpGTNDate.Value = detail.GoodTransferNoteDate;
                        txtStoreFrom.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(detail.StoreID_From));
                        txtStoreTo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(detail.StoreID_To));
                        //chkSettings.Checked = false;

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

                        RefreshGrid(detail.GoodTransferNote_ID);


                        Attachments.FillAttachments(sID);
                    }
                    setEnableItems();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string sGTNID)
        {
            try
            {
                int iRow;
                decimal dTotQty = 0, dTotAmount = 0;
                dgvDetail.Rows.Clear();

                tbl_scsGoodTransferNote oGTN = tbl_scsGoodTransferNote.Select(sGTNID);
                if (oGTN != null)
                {
                    foreach (tbl_scsGoodTransferNote_Detail detail in tbl_scsGoodTransferNote_Detail.SelectAllByGoodTransferNote_ID(sGTNID))
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;

                        //clsHelpMethods.Fill_StockDatagrid - Earlier Method - Replaced by Gayan 2016-12-03
                        clsHelpMethods_Local.Fill_StockDatagrid_GTN(dgvDetail, iRow, detail.Line_No, detail.Item_Code, detail.Uom, oGTN.Job_ID, "", "", "",
                            oGTN.StoreID_To, "", "", "",
                           oGTN.StoreID_From, "", detail.Qty, detail.Weight, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, "O", detail.UnitPrice, detail.TatalAmount);

                        dTotQty += detail.Qty;
                        dTotAmount += detail.TatalAmount;
                    }
                }
                txtTotQty.Text = clsFormatter.FormatDecimalPlaces_Quantity(dTotQty);
                txtTotAmount.Text = clsFormatter.FormatDecimalPlaces_Weight(dTotAmount);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridByItem_ID(string sItem_ID)
        {
            try
            {
                int iRow;
                tbl_genItemMaster detail = tbl_genItemMaster.Select(sItem_ID);
                tbl_genItemMaster_Pricing oItemF = tbl_genItemMaster_Pricing.Select(sItem_ID);
                if (detail != null)
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;

                    string sNoteID = "N/A", sMettle = "N/A", sGem = "N/A";
                    decimal dSellingPrice = oItemF.SellingPrice1;
                    decimal dCostPrice = oItemF.CostPrice1;
                    //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.gem.ToString())
                    //{
                    //    tbl_genItemMaster_Gem oIGem = tbl_genItemMaster_Gem.Select(detail.Item_ID);
                    //    if (oIGem != null)
                    //    {
                    //        sMettle = oIGem.MetalDetail;
                    //        sGem = oIGem.GemDetail;
                    //        dSellingPrice = oIGem.SellingPrice;
                    //        dCostPrice = oIGem.CostPrice;
                    //    }

                    //    clsHelpMethods_Local.Fill_StockDatagridItemGem(dgvDetail, iRow, detail.Item_ID, detail.Uom_ID, "default", "default", "default", "default",
                    //       txtStoreTo.Tag.ToString(), "default", "default", "default", "default", sNoteID, 0, 0,
                    //        txtItemSubCategory.Tag.ToString(), txtItemSubCategory.Text.Trim(), txtItemSerialNo.Tag.ToString(), txtItemSerialNo.Text.Trim(), "N", sMettle, sGem, dSellingPrice, dCostPrice);
                    //}
                    //else
                    {
                        decimal dUnitPrice = 0;
                        string sItemPriceCategory = ((ComboBoxItem)cmbItemPrice.SelectedItem).Value;
                        dUnitPrice = clsProcessMethods.GetRecommendedUnitPrice_Basic(detail.Item_ID, sItemPriceCategory);

                        var maxLineNo = dgvDetail.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["LineNo"].Value));

                        clsHelpMethods_Local.Fill_StockDatagrid_GTN(dgvDetail, iRow, maxLineNo + 1, detail.Item_ID, detail.Uom_ID, "default", "default", "default", "default",
                           txtStoreTo.Tag.ToString(), "default", "default", "default", "default", sNoteID, 1, 0,
                            txtItemSubCategory.Tag.ToString(), txtItemSubCategory.Text.Trim(), txtItemSerialNo.Tag.ToString(), txtItemSerialNo.Text.Trim(), "N", dUnitPrice, dUnitPrice);
                        dgvDetail.Focus();
                    }
                    //  dTotQty++;
                    //  dTotWeight += oGRNGem.MetalWeight;

                }

                //  txtTotQty.Text = clsFormatter.FormatDecimalPlaces_Quantity(dTotQty);
                //  txtTotAmount.Text = clsFormatter.FormatDecimalPlaces_Weight(dTotWeight);
                // 

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Events Datagried
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail_CellDoubleClick(sender, e);
        }
        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    clsEvent.StockGrid_GTN_CellDoubleClick(sender, e, dgvDetail);
                    string sItemCode = dgvDetail["ItemCode", e.RowIndex].Value.ToString();
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
        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            clsEvent.StockGrid_CellEndEdit(sender, e, dgvDetail);
            UpdateTotalQty_Amount();
        }
        private void dgvDetail_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            clsEvent.StockGrid_CellParsing(sender, e, dgvDetail);
        }
        private void DataGrid_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";
                DataGridView dgv = (DataGridView)sender;
                if (e.ColumnIndex >= 0)
                    sColName = dgv.Columns[e.ColumnIndex].Name;

                if (sColName == "ItemCode" || sColName == "ItemName" || sColName == "ItemSubCategoryID" || sColName == "GoodsFrom" || sColName == "Note_ID" || sColName == "UOM" || sColName == "ItemSerialNo")
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


                if (sColName == "ItemCode" || sColName == "ItemName" || sColName == "ItemSubCategoryID" || sColName == "GoodsFrom" || sColName == "Note_ID" || sColName == "UOM" || sColName == "ItemSerialNo")
                    Cursor = Cursors.Default;
            }
        }
        private void dgvDetail_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                // if (e.KeyData == Keys.Up || e.KeyData == Keys.Down || e.KeyData == Keys.Left || e.KeyData == Keys.Right)
                //      string sItemCode = dgvDetail["ItemCode", dgvDetail.SelectedCells[0].RowIndex].Value.ToString();

                // else if (e.KeyData == Keys.F1)
                //   txtItemID.Focus();
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

        #region Events DoubleClick
        private void txtGTNID_DoubleClick(object sender, EventArgs e)
        {
            //clsSearch.Search_TransactionGoodTransferNote(ref txtGTNID, chkShowSettle.Checked, txtStoreFrom.Tag, txtStoreTo.Tag);
            clsSearch.Search_TransactionGoodsTransferNote_Direct(ref txtGTNID, chkShowSettle.Checked, txtStoreFrom.Tag, txtStoreTo.Tag);

            if (txtGTNID.Text.Trim().Length > 0)
                FillDetails(txtGTNID.Text.Trim());
        }
        private void txtStoreFrom_DoubleClick(object sender, EventArgs e)
        {
            Search_StoreFrom();
        }
        private void txtCheckedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }
        private void txtApprovedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }
        private void txtStoreTo_DoubleClick(object sender, EventArgs e)
        {
            Search_Store();
        }
        private void txtItemID_DoubleClick(object sender, EventArgs e)
        {
            Search_ItemID(sender, new KeyEventArgs(Keys.F1));
        }
        #endregion

        #region Events KeyDown
        private void txtGTNID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtGTNID_DoubleClick(null, null);
        }
        private void txtStoreFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_StoreFrom();
            else if (e.KeyCode == Keys.Tab)
                txtStoreTo.Focus();
        }
        private void txtApprovedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_ApprovedBy();
        }
        private void txtCheckedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CheckedBy();
        }
        private void frm_sasStoreGoodReceiveNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
            else if (e.KeyCode == Keys.F9)
                frm_scsGoodTransferNote_new_SF_newButton_Click(sender, e);
            //  else if (e.KeyCode == Keys.F10)
            //    btnSave_Click(sender, e);
            //  else if (e.KeyCode == Keys.F11)
            //     btnRemove_Click(sender, e);
            else if (e.KeyCode == Keys.F12)
                frm_scsGoodTransferNote_new_SF_printButton_Click(sender, e);
        }
        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            Search_ItemID(sender, e);
        }
        private void txtOrderRefNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                cmbStockNoteType.Focus();
        }
        private void cmbStockNoteType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                cmbItemPrice.Focus();
        }
        private void cmbItemPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                txtItemID.Focus();
            if (e.KeyCode == Keys.F1)
                txtItemID.Focus();
        }
        #endregion

        #region Events CheckedChanged
        private void chkSettings_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkSettings.Checked)
            //    chkSettings.Image = Digiteq.Properties.Resources.security;
            //else
            //{
            //    xSetting.SendToBack();
            //    chkSettings.Image = Digiteq.Properties.Resources.settings;
            //}
        }
        #endregion

        #region Events KeyPress
        private void cmbStockNoteType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            dt_ItemGrouped = clsCommon.DataGridViewToDataTable_ItemGrouped(dgvDetail);

            bool bStatus = false;
            if (CheckValidity_EmptyValue())
            {
                if (CheckStockValidity())
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpGTNDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                        {
                            if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreFrom.Tag.ToString(), IsUpdate))
                            {
                                if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreTo.Tag.ToString(), IsUpdate))
                                    bStatus = true;
                            }
                        }
                    }
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyValue()
        {
            bool bStatus = true;

            if (!clsValidate.ValidateTextBox_EmptyValue(txtStoreFrom, "From Store"))
                bStatus = false;

            if (!clsValidate.ValidateTextBox_EmptyValue(txtStoreTo, "To Store"))
                bStatus = false;

            return bStatus;
        }

        #region Old method CheckStockValidity
        //private bool CheckStockValidity()
        //{
        //    string strMessage = "", sOriginalItemCode = "", sItemCode = "", sItemStatus = "", sSubCategoryID1 = "", sSubCategoryID2 = "", sSerialNo1 = "", sSerialNo2 = "", sJobCode = "";
        //    decimal dWeight = 0;
        //    decimal dQty = 0;
        //    bool bStatus = true;

        //    // foreach (DataGridViewRow row in dgvDetail.Rows)
        //    foreach (DataRow row in dt_ItemGrouped.Rows)
        //    {
        //        //sOriginalItemCode = sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
        //        //dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
        //        //dQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
        //        //sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
        //        //sSubCategoryID1 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
        //        //sSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
        //        //sSerialNo1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
        //        //sSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
        //        //sItemStatus = clsValidate.ValidateGridValue(dgvDetail, "ItemStatus", row.Index, "");

        //        sOriginalItemCode = sItemCode = clsValidate.ValidateRowValue(row, "ItemCode", "default");
        //        dWeight = clsValidate.ValidateRowValue(row, "Weight", decimal.Parse("0.00"));
        //        dQty = clsValidate.ValidateRowValue(row, "Quantity", decimal.Parse("0.00"));
        //        sItemStatus = clsValidate.ValidateRowValue(row, "ItemStatus", "");
        //        sJobCode = clsValidate.ValidateRowValue(row, "JobCode", "default");
        //        sSubCategoryID1 = clsValidate.ValidateRowValue(row, "ItemSubCategoryID", "default");
        //        sSubCategoryID2 = clsValidate.ValidateRowValue(row, "ItemSubCategoryID2", "default");
        //        sSerialNo1 = clsValidate.ValidateRowValue(row, "ItemSerialNo", "0");
        //        sSerialNo2 = clsValidate.ValidateRowValue(row, "ItemSerialNo2", "0");

        //        if (dWeight <= 0 && dQty <= 0)
        //        {
        //            bStatus = false;
        //            strMessage = "item " + sOriginalItemCode + " Qty and Weight are Incorrect.";
        //            break;
        //        }

        //        if (!clsConfig.bStoreStockWithJobID)
        //            sJobCode = "default";

        //        if (clsConfig.bSingleItemStockEnabled)
        //        {
        //            if (!clsHelpMethods_Local.IsItemRawMaterial(sItemCode))
        //                clsHelpMethods_Local.AssignSingleStockItemDetail(ref sItemCode, ref sSubCategoryID1, ref sSubCategoryID2, ref sSerialNo1, ref sSerialNo2);
        //        }

        //        //validate stock detail
        //        #region Validate Stock Details
        //        tbl_genStore_Stock stock = tbl_genStore_Stock.Select(txtStoreFrom.Tag.ToString(), sItemCode, sJobCode, sSubCategoryID1, sSubCategoryID2, sSerialNo1, sSerialNo2);
        //        if (stock != null)
        //        {
        //            if (sItemStatus.ToLower() == "o") //new item
        //            {
        //                #region Old Items Stock Validation
        //                List<tbl_scsStoreGoodIssueNote_Detail> oldDetails = tbl_scsStoreGoodIssueNote_Detail.SelectAllByStoreGoodIssueNote_ID(txtGTNID.Text.Trim());
        //                foreach (tbl_scsStoreGoodIssueNote_Detail oldDetail in oldDetails)
        //                {
        //                    if (oldDetail.Item_ID == sOriginalItemCode)
        //                    {
        //                        decimal dVeriance = 0;
        //                        if (clsConfig.bStockValidateQty_iGIN) //check whether stock enabled - qty
        //                        {
        //                            #region Old Items Quantity Validation
        //                            if (oldDetail.Qty < dQty)
        //                                dVeriance = dQty - oldDetail.Qty;

        //                            if (stock.Qty < dVeriance)
        //                            {
        //                                strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required Quantity Is Not Availabe As IT Is In " + clsGenaralName.getName_Store(txtStoreFrom.Tag.ToString()) + "\n";
        //                                bStatus = false;
        //                            }
        //                            #endregion
        //                        }
        //                        if (clsConfig.bStockValidateWeight_iGIN) //check whether stock enabled - weight
        //                        {
        //                            ////weight part
        //                            #region Old Items Weight Validation
        //                            if (oldDetail.Weight < dWeight)
        //                                dVeriance = dWeight - oldDetail.Weight;

        //                            if (stock.Weight < dVeriance)
        //                            {
        //                                strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required Weight Is Not Availabe As IT Is In " + clsGenaralName.getName_Store(txtStoreFrom.Tag.ToString()) + "\n";
        //                                bStatus = false;
        //                            }
        //                            #endregion
        //                        }

        //                    }
        //                }
        //                #endregion
        //            }
        //            else //old item
        //            {
        //                #region New Item Stock Validation
        //                if (stock.Weight >= 0 && stock.Weight < dWeight && clsConfig.bStockValidateWeight_GTN) //check whether stock enabled - qty
        //                {
        //                    strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required Weight Is Not Availabe As IT Is In  " + clsGenaralName.getName_Store(txtStoreFrom.Tag.ToString()) + "\n";
        //                    bStatus = false;
        //                }
        //                if (stock.Qty >= 0 && stock.Qty < dQty && clsConfig.bStockValidateQty_GTN) //check whether stock enabled - weight
        //                {
        //                    strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + "  Required Quantity Is Not Availabe As IT Is In " + clsGenaralName.getName_Store(txtStoreFrom.Tag.ToString()) + "\n";
        //                    bStatus = false;
        //                }
        //                #endregion
        //            }
        //        }
        //        else //No stock in selected store
        //        {
        //            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Is Not Available In " + clsGenaralName.getName_Store(txtStoreFrom.Tag.ToString()) + " Stock\n";
        //            bStatus = false;
        //        }
        //        #endregion
        //    }
        //    if (bStatus == false)
        //        MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        oStoreStock = oStoreStock = tbl_genStore_Stock.Select(txtStoreFrom.Tag.ToString(), sItemCode, sJobCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                        if (oStoreStock == null)
                        {
                            oStoreStock = new tbl_genStore_Stock(txtStoreFrom.Tag.ToString(), sItemCode, "default", "default", "default", "0", "0", 0, 0, 0, 0, 0, 0, 0, 0);
                            oStoreStock.Insert();
                        }
 
                        tbl_genStoreMaster oStore = tbl_genStoreMaster.Select(txtStoreFrom.Tag.ToString());
                        if (oStoreStock != null && oStore != null)
                        {
                            #region if the item is old and check stock for more than one time
                            if (sItemStatus.ToLower() == "o")
                            {
                                decimal dOldQty = 0, dOldWeight = 0;
                                foreach (tbl_scsGoodTransferNote_Detail oGTNDetail in tbl_scsGoodTransferNote_Detail.SelectAllByGoodTransferNote_ID(txtGTNID.Text.Trim()).Where(p => p.Item_Code == sItemCode && p.ItemSubCategory_ID == sItemSubCategoryID && p.ItemSubCategory2_ID == sItemSubCategoryID2))
                                {
                                    dOldQty += oGTNDetail.Qty;
                                    dOldWeight += oGTNDetail.Weight;
                                }

                                #region Old Items Quantity Validation
                                if (clsConfig.bStockValidateQty_GTN)
                                {
                                    if (oStoreStock.Qty + dOldQty < dQty)
                                    {
                                        strMessage += " Required Quantity of Item: \"" + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\" is not Availabe in  store :\"" + clsGenaralName.getName_Store(txtStoreFrom.Tag.ToString()) + "\"\n";
                                        bStatus = false;
                                    }
                                }
                                #endregion

                                #region Old Items Weight Validation
                                if (clsConfig.bStockValidateWeight_GTN)
                                {
                                    if (oStoreStock.Weight + dOldWeight < dWeight)
                                    {
                                        strMessage += " Required Weight of Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "is Not Availabe In  store :" + clsGenaralName.getName_Store(txtStoreFrom.Tag.ToString()) + "\n";
                                        bStatus = false;
                                    }
                                }
                                #endregion

                                if (!oStore.IsAllowMinusStock)
                                {
                                    if (oStoreStock.Qty + dOldQty - dQty < 0)
                                    {
                                        strMessage += "Minus Quantities are not allowed - " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\" in store : " + clsGenaralName.getName_Store(txtStoreFrom.Tag.ToString()) + "\"\n";
                                        bStatus = false;
                                    }
                                }
                            }
                            #endregion

                            #region first time added item ant have to check stock
                            else
                            {
                                #region Weight Validation
                                if (oStoreStock.Weight < dWeight && clsConfig.bStockValidateWeight_GTN)
                                {
                                    strMessage += "Item: " + sItemCode + " | " + clsGenaralName.getName_Item(sItemCode) + " Required Weight Is Not Availabe As IT Is In  " + clsGenaralName.getName_Store(txtStoreFrom.Tag.ToString()) + "\n";
                                    bStatus = false;
                                }
                                #endregion

                                #region New Item Quantity Validation
                                if (oStoreStock.Qty < dQty && clsConfig.bStockValidateQty_GTN)
                                {
                                    strMessage += "Required Quantity of Item: \"" + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\" is not Availabe in stock :\"" + clsGenaralName.getName_Store(txtStoreFrom.Tag.ToString()) + "\"\n";
                                    bStatus = false;
                                }
                                #endregion

                                if (!oStore.IsAllowMinusStock)
                                {
                                    if (oStoreStock.Qty - dQty < 0)
                                    {
                                        strMessage += "Minus Quantities are not allowed - " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\" in store : " + clsGenaralName.getName_Store(txtStoreFrom.Tag.ToString()) + "\"\n";
                                        bStatus = false;
                                    }
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            if ((clsConfig.bStockValidateQty_GTN || clsConfig.bStockValidateWeight_GTN) && !clsHelpMethods_Local.IsNonInventoryItem(sItemCode) && (clsConfig.sSoftwareModel.Trim() != SoftwareModel_Sales.akt.ToString()))
                            {
                                strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "  Is Not Available In " + clsGenaralName.getName_Store(txtStoreFrom.Tag.ToString()) + " Stock\n";
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

        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            clsCommon.ValidateForeignKey(ref txtStoreTo);
            clsCommon.ValidateForeignKey(ref txtItemID);
        }
        #endregion

        #region Search Methods
        private void Search_Store()
        {
            //clsSearch.Search_MasterStore(ref txtStoreTo);
            clsSearch.Search_MasterStore_GTN(ref txtStoreTo, clsConfig.enableBranchWiseFilterOnSearch ? true : false);
            if (txtStoreFrom.Tag != null && txtStoreTo.Tag != null)
            {
                //    setEnableItems();
                //    txtOrderRefNo.Focus();
                //}

                //clsSearch.Search_MasterStore(ref txtStoreTo);

                if (txtStoreFrom.Tag.ToString() == txtStoreTo.Tag.ToString())
                {
                    txtStoreTo.Tag = null;
                    txtStoreTo.Clear();
                    MessageBox.Show("From Store and To Store should not be same.. \nPlease select another store", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    setEnableItems();
                    txtOrderRefNo.Focus();
                }
            }
        }

        private void Search_StoreFrom()
        {
            //clsSearch.Search_MasterStore(ref txtStoreFrom);
            clsSearch.Search_MasterStore_GTN(ref txtStoreFrom, clsConfig.enableBranchWiseFilterOnSearch ? true : false);
            if (txtStoreFrom.Tag != null && txtStoreTo.Tag != null)
            {

                if (txtStoreTo.Tag != null && txtStoreFrom.Tag.ToString() == txtStoreTo.Tag.ToString())
                {
                    txtStoreFrom.Tag = null;
                    txtStoreFrom.Clear();
                    MessageBox.Show("From Store and To Store should not be same .. \nPlease select another Store .", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    txtStoreTo.Focus();
            }
        }

        private void Search_ItemID(object sender, KeyEventArgs e)
        {
            try
            {
                if (CheckValidity_EmptyValue())
                {
                    string sStoreID = "", sSectionID = "", sDepartmentID = "";
                    if (txtStoreFrom.Tag != null && txtStoreFrom.Tag.ToString().Trim().Length > 0)
                        sStoreID = txtStoreFrom.Tag.ToString();

                    if (e.KeyCode == Keys.F1)
                    {
                        //clsHelpMethods_Local.SearchItemAdvanceStock(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo, sStoreID, sSectionID, sDepartmentID);
                        clsSearch.Search_TransactionItemMasterByStore(ref txtItemID, sStoreID);
                        if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                            btnAddItem_Click(null, new EventArgs());
                    }
                    else if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4)
                    {
                        // clsHelpMethods.SearchItemAdvanceByKeyPress(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo, e);
                        //if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                        //   btnAddItem_Click(sender, new EventArgs());
                    }
                    //else if (e.KeyCode == Keys.F5)
                    //{
                    //    frm_sasMultipleItemSelect frm = new frm_sasMultipleItemSelect();
                    //    string sItemPriceCategory = ((ComboBoxItem)cmbItemPrice.SelectedItem).Value;
                    //    frm.glb_sItemPriceCategory = sItemPriceCategory;
                    //    frm.glb_sStoreID = sStoreID;
                    //    frm.ShowDialog();


                    //    if (frm.lstclsTmpMultipleSelectedItems.Count > 0)
                    //    {
                    //        foreach (clsTmpMultipleSelectedItems oItem in frm.lstclsTmpMultipleSelectedItems)
                    //        {
                    //            dgvDetail.Rows.Add();
                    //            int iRow = dgvDetail.Rows.Count - 1;
                    //            string sNoteID = "N/A";

                    //            var maxLineNo = dgvDetail.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["LineNo"].Value));
                    //            clsHelpMethods_Local.Fill_StockDatagrid_GTN(dgvDetail, iRow, maxLineNo + 1, oItem.sItemID, oItem.sUOMID, "default", "default", "default", "default", txtStoreTo.Tag.ToString(), "default", "default", "default", "default", sNoteID, oItem.dQty, oItem.dWeight, oItem.sItemSubCategoryID, oItem.sItemSubCategoryID2, oItem.sItemSerialNo, oItem.sItemSerialNo2, "N", oItem.dUnitPrice, oItem.dTotalAmount);
                    //        }
                    //    }
                    //}
                    else if (e.KeyCode == Keys.Enter)
                    {
                        if (clsValidate.Validate_ItemCode(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo))
                        {
                            // if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                            //     btnAddItem_Click(sender, new EventArgs());
                        }
                    }
                }
                UpdateTotalQty_Amount();

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void UpdateTotalQty_Amount()
        {
            decimal dQuantity = 0, dAmmount = 0;
            if (dgvDetail.RowCount > 0)
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    dQuantity += clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                    dAmmount += clsValidate.ValidateGridValue(dgvDetail, "ItemTotalValue", row.Index, decimal.Parse("0.00"));
                }
            }
            txtTotQty.Text = clsFormatter.FormatDecimalPlaces_Quantity(dQuantity);
            txtTotAmount.Text = clsFormatter.FormatDecimalPlaces_Quantity(dAmmount);
        }

        #endregion

        #region Print Method
        private void Print(bool bIsDraft)
        {
            try
            {
                string sDuplicate = "";
                bool bApprovalDone = true, bCheckingDone = true;
                if (txtGTNID.Text.Trim().Length > 0 && txtGTNID.Text.Trim() != "<Auto Generate>")
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        glb_dtsGoodTransferNote.Clear();
                        string sCreateUserAndDate = "", sApprovedUserAndDate = "", sCheckedUserAndDate = "";

                        bool bPermissinOkToPrint = true;
                        if (chkPrintOriginal.Checked)
                            bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_GoodsTransferNote));
                        if (bPermissinOkToPrint)
                        {
                            tbl_scsGoodTransferNote oGTN = tbl_scsGoodTransferNote.Select(txtGTNID.Text.Trim());
                            if (oGTN != null && oGTN.GoodTransferNote_ID != "default")
                            {
                                if (!bIsDraft)
                                {
                                    #region Validate Approval
                                    if (clsConfig.bApprovalNeedToPrintGTN)
                                    {
                                        if (!oGTN.IsApproved)
                                        {
                                            bApprovalDone = false;
                                            MessageBox.Show("Please Approve the Goods Transfer Note Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    #endregion
                                    #region Validate Checking
                                    if (clsConfig.bCheckingNeedToPrintGTN)
                                    {
                                        if (!oGTN.IsChecked)
                                        {
                                            bCheckingDone = false;
                                            MessageBox.Show("Please Check the Goods Transfer Note Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    #endregion
                                }

                                if (bApprovalDone && bCheckingDone)
                                {
                                    #region Fill Header
                                    glb_dtsGoodTransferNote.dt_scsGoodTransferNote.Adddt_scsGoodTransferNoteRow(oGTN.GoodTransferNote_ID, oGTN.GoodTransferNoteDate, clsGenaralName.getName_Store(oGTN.StoreID_From), clsGenaralName.getName_Store(oGTN.StoreID_To), "", (oGTN.IsDeleted ? "Deleted" : ""), oGTN.Remark, 0, 0, oGTN.IsDeleted, clsFill.GetItemPriceName(oGTN.ItemPriceCategory));
                                    #endregion

                                    #region Fill Details
                                    foreach (tbl_scsGoodTransferNote_Detail detail in tbl_scsGoodTransferNote_Detail.SelectAllByGoodTransferNote_ID(oGTN.GoodTransferNote_ID))
                                    {
                                        decimal dSellingPrice = 0;

                                        tbl_zItemSerialNo oSerial = tbl_zItemSerialNo.Select(detail.ItemSerialNo);
                                        if (oSerial != null && oSerial.Item_ID != "default")
                                        {
                                            dSellingPrice = oSerial.SellingPrice;
                                        }
                                        glb_dtsGoodTransferNote.dt_scsGoodTransferNote_Detail.Adddt_scsGoodTransferNote_DetailRow(detail.GoodTransferNote_ID, detail.Item_Code, detail.ItemSerialNo, "", "",
                                           clsGenaralName.getName_Item(detail.Item_Code), clsGenaralName.getName_Uom(detail.Uom), detail.Qty, detail.Weight,
                                           dSellingPrice, "", detail.UnitPrice);
                                    }
                                    #endregion

                                    if (!bIsDraft)
                                    {
                                        //if (oGTN.PrintCount > 0)
                                        //    sDuplicate = "Duplicate Copy " + oGTN.PrintCount;

                                        if (!chkPrintOriginal.Checked)
                                            sDuplicate = (oGTN.PrintCount > 0) ? "Duplicate Copy " + oGTN.PrintCount : "";

                                        oGTN.PrintCount++;
                                        oGTN.Update();
                                    }

                                    #region Checked users
                                    sCreateUserAndDate = clsGenaralName.getName_User(oGTN.CreateUser_ID) + " - " + clsFormatter.FormatDate_Short(oGTN.DateCreate);
                                    sApprovedUserAndDate = clsGenaralName.getName_User(oGTN.ApprovedUser_ID) + " - " + clsFormatter.FormatDate_Short(oGTN.DateApproved);
                                    sCheckedUserAndDate = clsGenaralName.getName_User(oGTN.CheckedUser_ID) + " - " + clsFormatter.FormatDate_Short(oGTN.DateChecked);
                                    #endregion

                                    #region Report Formula
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DupicateCopy", sDuplicate, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true);

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUserAndDate, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sCheckedUserAndDate, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUserAndDate, true);
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
                                        }
                                    }
                                    glb_dtsGoodTransferNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, "GOOD TRANSFER NOTE", "", "", clsSecurity.UserNameLoged, "");
                                    #endregion

                                    #region Print Report
                                    string s_Path = clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_GoodsTransferNote));
                                    if (s_Path != null)
                                    {
                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(s_Path, glb_dtsGoodTransferNote, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_GoodsTransferNote));
                                    }
                                    #endregion
                                }
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
                        Cursor = Cursors.Default;
                        glb_dtsGoodTransferNote.Clear();
                    }
                }
                else
                    MessageBox.Show("Please Select the Goods Issue Note To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region Set Enable/Desable Items
        private void setEnableItems()
        {
            bool Val = false;
            if (txtStoreTo.Tag != null && txtStoreFrom.Tag != null)
                Val = true;

            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemID, Val);
            clsCommon.SetEnableDisable_NormalLabel(lblItem, Val);
        }
        #endregion

        private void btnF5_Click(object sender, EventArgs e)
        {
            Search_ItemID(sender, new KeyEventArgs(Keys.F5));
        }

        private void frm_scsGoodTransferNote_new_FormClosing(object sender, FormClosingEventArgs e)
        {
            Attachments.Close();
        }

        #region User Checked Approve Details

        private void frm_scsGoodTransferNote_new_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_scsGoodTransferNote_new_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpGTNDate.Value.Date))
                {
                    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtGTNID.Text != null && txtGTNID.TextLength > 0 && txtGTNID.Text != "<Auto Generate>")
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

                                        tbl_scsGoodTransferNote objGTN = tbl_scsGoodTransferNote.Select(txtGTNID.Text.Trim());
                                        if (objGTN != null)
                                        {
                                            objGTN.IsApproved = true;
                                            objGTN.DateApproved = clsSecurity.getServerDateTime();
                                            objGTN.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                            objGTN.Update();
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
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpGTNDate.Value.Date))
                {
                    if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtGTNID.Text != null && txtGTNID.TextLength > 0 && txtGTNID.Text != "<Auto Generate>")
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

                                        tbl_scsGoodTransferNote objGTN = tbl_scsGoodTransferNote.Select(txtGTNID.Text.Trim());
                                        if (objGTN != null)
                                        {
                                            objGTN.IsChecked = true;
                                            objGTN.DateChecked = clsSecurity.getServerDateTime();
                                            objGTN.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objGTN.Update();
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

        private void frm_scsGoodTransferNote_new_SF_History_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGTNID.Text != "" || txtGTNID.Text != "<Auto Generate>")
                {
                    tbl_scsGoodTransferNote detail = tbl_scsGoodTransferNote.Select(txtGTNID.Text.Trim());
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