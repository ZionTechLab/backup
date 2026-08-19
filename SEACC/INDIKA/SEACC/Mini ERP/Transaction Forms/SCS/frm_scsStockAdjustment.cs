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
using Zion.ERP.Reports.DataSets;
using SEACC.DATA.Data.SCS;
using SEACC.DATA.Domain;

namespace Digiteq
{
    public partial class frm_scsStockAdjustment : SEACC_Form
    {
        
        static bool IsUpdateAdjustment = false;
        public static decimal glbnewPrice = 0;
        public string glbStockAdjustmentNo = "";

        private dts_Stock glbdts_Stock = new dts_Stock();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();

        InventoryTxnData oData = new InventoryTxnData();
        clsAlerts_Email email = new clsAlerts_Email();

        #region Form Load
        public frm_scsStockAdjustment(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }
        private void frm_scsStockAdjustment_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);
            CusDataGridViewFormat();
            ClearFields();

            if (glbStockAdjustmentNo.Length > 0)
                FillDetails(glbStockAdjustmentNo);
        }
        #endregion

        #region Btn Save
        private void frm_scsStockAdjustment_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    ValidateEmptyForeignKey();

                    #region update records
                    if (IsUpdate)
                    {
                        tbl_scsStockAdjustment oldRecord = tbl_scsStockAdjustment.Select(txtSANID.Text.Trim());
                        if (oldRecord != null && oldRecord.StockAdjustment_ID != "default")
                        {
                            if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                            {
                                if (!oldRecord.IsChecked ||
                                    (oldRecord.IsChecked &&
                                     clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID)))
                                {
                                    if (clsValidate.CheckValidity_TransactionCodeLength(txtSANID.Text))
                                    {
                                   //     List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();

                                        #region Stock Adjustmen Header

                                        tbl_scsStockAdjustment detail = new tbl_scsStockAdjustment(
                                            oldRecord.StockAdjustment_ID, dtpAdjustmentDate.Value,
                                            txtRemark.Text.ToString(),
                                            "default", "default", txtStoreID.Tag.ToString(), oldRecord.CreateUser_ID,
                                            clsSecurity.UserIDLoged,
                                            oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID, oldRecord.DateCreate,
                                            clsSecurity.getServerDateTime(),
                                            glbCheckedDate, glbApprovedDate, bHasChecked, bHasApproved,
                                            oldRecord.IsFinished, oldRecord.IsDeleted, oldRecord.IsLocked,
                                            oldRecord.PrintCount, oldRecord.CompanyID, oldRecord.CompanyBranch_ID);
                                        detail.Update();

                                        #endregion

                                        #region Rollback Store Stock

                                        foreach (tbl_scsStockAdjustment_Detail oUpdatedRecord in
                                            tbl_scsStockAdjustment_Detail.SelectAllByStockAdjustment_ID(
                                                txtSANID.Text.Trim()))
                                        {
                                            //  decimal dNewQty = oUpdatedRecord.Qty - oUpdatedRecord.OldQty;
                                            //   decimal dNewWeight = oUpdatedRecord.Weight - oUpdatedRecord.OldWeight;
                                            //bool bIsStockIn = (oUpdatedRecord.Qty < 0) ? false : true;

                                            decimal dWeightedAverageCostPrice = 0;
                                            //clsHelpMethods_Local.UpdateStoreStock(iFormID,
                                            //    oUpdatedRecord.StockAdjustment_ID, detail.StockAdjustmentDate,
                                            //    oUpdatedRecord.Item_ID, "0", txtStoreID.Tag.ToString(),
                                            //    oUpdatedRecord.Qty, oUpdatedRecord.Weight,
                                            //    oUpdatedRecord.Qty * oUpdatedRecord.UnitPrice, true, true, true, ref dWeightedAverageCostPrice);

                                            oUpdatedRecord.WeightedAvgCost = dWeightedAverageCostPrice;
                                            oUpdatedRecord.Update();

                                            oUpdatedRecord.Delete();
                                        }

                                        #endregion

                                        #region Insert Newly added items
                                        int iCount = 1;
                                        foreach (DataGridViewRow row in dgvDetail.Rows)
                                        {
                                            try
                                            {
                                                

                                                string sItemCode = "",
                                                    sItemName = "default",
                                                    sUOM = "",
                                                    sWeight = "",
                                                    sRemark = string.Empty,
                                                    sItemSubCategoryID1 = "",
                                                    sItemSubCategoryID2 = "",
                                                    sItemSerialNo1 = "",
                                                    sItemSerialNo2 = "";
                                                decimal dWeight = 0, dQuantity = 0, dUnitPrice = 0, dWeidhtPrice = 0;

                                                #endregion

                                                #region Grid Details Validation

                                                sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode",
                                                    row.Index, "default");
                                                sItemName = clsValidate.ValidateGridValue(dgvDetail, "ItemName",
                                                    row.Index, "");
                                                sUOM = clsValidate.ValidateGridValue(dgvDetail, "UOM", row.Index,
                                                    "default");
                                                sWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index,
                                                    "");
                                                dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity",
                                                    row.Index, decimal.Parse("0.00"));
                                                dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice",
                                                    row.Index, decimal.Parse("0.00"));
                                                dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index,
                                                    decimal.Parse("0.00"));
                                                dWeidhtPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice",
                                                    row.Index, decimal.Parse("0.00"));
                                                sItemSubCategoryID1 = clsValidate.ValidateGridTag(dgvDetail,
                                                    "ItemSubCategoryID", row.Index, "default");
                                                sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail,
                                                    "ItemSubCategoryID2", row.Index, "default");
                                                sItemSerialNo1 = clsValidate.ValidateGridValue(dgvDetail,
                                                    "ItemSerialNo", row.Index, "0");
                                                sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail,
                                                    "ItemSerialNo2", row.Index, "0");
                                                sRemark = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index,
                                                    "-");

                                                #endregion

                                                #region Stock Adjustmen Detail
                                                if (sItemCode.Length > 0)
                                                {
                                                    #region insert adjustment

                                                    tbl_scsStockAdjustment_Detail STAdetail =
                                                        new tbl_scsStockAdjustment_Detail(txtSANID.Text.ToString(),
                                                            sItemCode, sItemSubCategoryID1,
                                                            sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2,
                                                            dQuantity, dWeight, 0, 0, dUnitPrice, dWeidhtPrice, 0, 0,
                                                            sRemark, 0);
                                                    STAdetail.Insert();
                                                    #endregion

                                                    #region Update Store Stock
                                                    //bool bIsStockIn = (dQuantity < 0) ? false : true;

                                                    decimal dWeightedAverageCostPrice = 0;
                                                    //clsHelpMethods_Local.UpdateStoreStock(iFormID,
                                                    //    detail.StockAdjustment_ID, detail.StockAdjustmentDate,
                                                    //    sItemCode, "0", txtStoreID.Tag.ToString(), dQuantity, dWeight,
                                                    //    dQuantity * dUnitPrice, false, true, true, ref dWeightedAverageCostPrice);

                                                    STAdetail.WeightedAvgCost = dWeightedAverageCostPrice;
                                                    STAdetail.Update();
                                                    #endregion

                                                    #region Pass Value to Inventory Detail
                                                    //tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, iCount, 0, txtSANID.Text.Trim(), dtpAdjustmentDate.Value,
                                                    //                            "", "", "", "", "default", "default", txtStoreID.Tag.ToString(),
                                                    //                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), 0, dQuantity, dUnitPrice, 0, false);
                                                    //oListInventory.Add(oInventoryDetail);
                                                    #endregion

                                                    iCount++;
                                                }

                                                #endregion
                                            }
                                            catch (Exception ex)
                                            {
                                                clsValidate.WriteErrorLog("", iFormID, ex);
                                                SEACCException.Show(ex);
                                            } //error may come because last row of the grid may not have information 
                                        }

                                        #endregion

                                        #region Attachments

                                        //Attachments.Remove(iFormID, txtSANID.Text.ToString());
                                        //Attachments.Insert(iFormID, txtSANID.Text.ToString());

                                        #endregion

                                        #region Update Inventory
                                        //tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtSANID.Text.Trim(), dtpAdjustmentDate.Value, txtRemark.Text.Trim(),
                                        //    "default", "default", "default", -1, 0,
                                        //    "", "", "", "", false, clsSecurity.UserIDLoged);

                                        //clsHelpMethods.Update_Inventory(oHeader, oListInventory);

                                        var responce = oData.Update_InventoryTxn(iFormID, txtSANID.Text.Trim(),IsUpdate);
                                        if (!responce.IsSuccess)
                                        {
                                            clsValidate.WriteErrorLog(txtSANID.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
                                            MessageBox.Show(responce.OutMsg);
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
                            else
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    #endregion

                    #region insert records
                    else
                    {
                        if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                            txtSANID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                        if (clsValidate.CheckValidity_TransactionCodeLength(txtSANID.Text)) //if (txtSANID.TextLength > 0)
                        {
                         //   List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();

                            #region Stock Adjustmen Header
                            tbl_scsStockAdjustment detail = new tbl_scsStockAdjustment(txtSANID.Text.ToString(), dtpAdjustmentDate.Value, txtRemark.Text.ToString(),
                                                                "default", "default", txtStoreID.Tag.ToString(), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                                                "default", "default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                                glbCheckedDate, glbApprovedDate, bHasChecked, bHasApproved, false, false, false, 0, clsSecurity.CompanyID, clsSecurity.BranchID);
                            detail.Insert();
                            #endregion

                            #region Details
                            int iCount = 1;
                            foreach (DataGridViewRow row in dgvDetail.Rows)
                            {
                                try
                                {
                                    
                                    string sItemCode = "", sItemName = "default", sUOM = "", sWeight = "", sRemark = string.Empty, sItemSubCategoryID1 = "", sItemSubCategoryID2 = "", sItemSerialNo1 = "", sItemSerialNo2 = "";
                                    decimal dWeight = 0, dQuantity = 0, dUnitPrice = 0, dWeidhtPrice = 0;
                                    #endregion

                                    #region Grid Details Validation
                                    sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                                    sItemName = clsValidate.ValidateGridValue(dgvDetail, "ItemName", row.Index, "");
                                    sUOM = clsValidate.ValidateGridValue(dgvDetail, "UOM", row.Index, "default");
                                    sWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, "");
                                    dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                    dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                                    dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                    dWeidhtPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                                    sItemSubCategoryID1 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                                    sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                    sItemSerialNo1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                                    sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                    sRemark = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "-");
                                    #endregion

                                    #region Stock Adjustmen Detail
                                    if (sItemCode.Length > 0)
                                    {
                                        #region insert adjustment
                                        tbl_scsStockAdjustment_Detail STAdetail = new tbl_scsStockAdjustment_Detail(txtSANID.Text.ToString(), sItemCode, sItemSubCategoryID1,
                                                                                      sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, dQuantity, dWeight, 0, 0, dUnitPrice, dWeidhtPrice, 0, 0, sRemark, 0);
                                        STAdetail.Insert();
                                        #endregion

                                        #region Update Store Stock
                                        //bool bIsStockIn = (dQuantity < 0) ? false : true;
                                        decimal dWeightedAverageCostPrice = 0;
                                      //  clsHelpMethods_Local.UpdateStoreStock(iFormID, detail.StockAdjustment_ID, detail.StockAdjustmentDate, sItemCode, "0", txtStoreID.Tag.ToString(), dQuantity, dWeight, dQuantity * dUnitPrice, false, true, true, ref dWeightedAverageCostPrice);
                                        STAdetail.WeightedAvgCost = dWeightedAverageCostPrice;
                                        STAdetail.Update();
                                        #endregion

                                        #region Pass Value to Inventory Detail
                                        //tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, iCount, 0, txtSANID.Text.Trim(), dtpAdjustmentDate.Value,
                                        //                            "", "", "", "", "default", "default", txtStoreID.Tag.ToString(),
                                        //                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), 0, dQuantity, dUnitPrice, 0, false);
                                        //oListInventory.Add(oInventoryDetail);
                                        #endregion

                                        iCount++;
                                    }
                                    #endregion
                                }
                                catch (Exception ex)
                                {
                                    clsValidate.WriteErrorLog("", iFormID, ex);
                                    SEACCException.Show(ex);
                                }//error may come because last row of the grid may not have information
                            }
                            #endregion

                            #region Attachments
                            Attachments.Insert(txtSANID.Text.ToString());
                            #endregion

                            #region Update Inventory
                            //tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtSANID.Text.Trim(), dtpAdjustmentDate.Value, txtRemark.Text.Trim(),
                            //    "default", "default", "default", -1, 0,
                            //    "", "", "", "", false, clsSecurity.UserIDLoged);

                            //clsHelpMethods.Update_Inventory(oHeader, oListInventory);

                            var responce = oData.Update_InventoryTxn(iFormID, txtSANID.Text.Trim(),IsUpdate);
                            if (!responce.IsSuccess)
                            {
                                clsValidate.WriteErrorLog(txtSANID.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
                                MessageBox.Show(responce.OutMsg);
                            }
                            #endregion
                  
                            email.createEmail_SAN(txtSANID.Text.Trim(), enum_Alerts.StockAdjustmentCreate);
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    tbl_scsStockAdjustment oldRecord = tbl_scsStockAdjustment.Select(txtSANID.Text.Trim());
                    if (oldRecord != null)
                        FillDetails(txtSANID.Text.Trim());
                }
            }
        }
 

        #region Btn New
        private void frm_scsStockAdjustment_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void frm_scsStockAdjustment_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                {
                    if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreID.Tag.ToString(), IsUpdate))
                    {
                        //delete one record
                        string strMessage = "";
                        Cursor = Cursors.WaitCursor;
                        if (txtSANID.TextLength > 0)
                        {
                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, ""), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (msgResult == DialogResult.Yes)
                            {
                                tbl_scsStockAdjustment detail = tbl_scsStockAdjustment.Select(txtSANID.Text.ToString());

                                if (detail != null)
                                {
                                    if (CheckCancelValidity_WATollarance())
                                    {

                                        #region Update Other Tables

                                        foreach (tbl_scsStockAdjustment_Detail oUpdatedRecord in tbl_scsStockAdjustment_Detail.SelectAllByStockAdjustment_ID(txtSANID.Text.Trim()))
                                        {
                                            if (oUpdatedRecord.Item_ID != null)
                                            {
                                                //   decimal dNewQty = oUpdatedRecord.Qty - oUpdatedRecord.OldQty;
                                                //  decimal dNewWeight = oUpdatedRecord.Weight - oUpdatedRecord.OldWeight;
                                                //bool bIsStockIn = (oUpdatedRecord.Qty < 0) ? false : true;

                                                decimal dWeightedAverageCostPrice = 0;
                                            //    clsHelpMethods_Local.UpdateStoreStock(iFormID, oUpdatedRecord.StockAdjustment_ID, detail.StockAdjustmentDate, oUpdatedRecord.Item_ID, "0", txtStoreID.Tag.ToString(), oUpdatedRecord.Qty, oUpdatedRecord.Weight, oUpdatedRecord.Qty * oUpdatedRecord.UnitPrice, true, true, true, ref dWeightedAverageCostPrice);
                                                oUpdatedRecord.WeightedAvgCost = dWeightedAverageCostPrice;
                                                oUpdatedRecord.Update();
                                                //   clsHelpMethods_Local.UpdateStoreStock(iFormID, oUpdatedRecord.StockAdjustment_ID, detail.StockAdjustmentDate, oUpdatedRecord.Item_ID, "0", txtStoreID.Tag.ToString(), dNewQty, dNewWeight, dNewQty * oUpdatedRecord.UnitPrice, (oUpdatedRecord.Qty < 0) ? false : true, true, true);
                                            }
                                        }
                                        #endregion

                                        detail.IsDeleted = true;
                                        detail.DateModified = clsSecurity.getServerDateTime();
                                        detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                        detail.Update();

                                      //  clsHelpMethods.Delete_Inventory(iFormID, 0, txtSANID.Text.Trim());
                                        var responce = oData.Delete_InventoryTxn(iFormID, txtSANID.Text.Trim());
                                        if (!responce.IsSuccess)
                                        {
                                            clsValidate.WriteErrorLog(txtSANID.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
                                        }
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        ClearFields();
                                    }
                                }
                            }
                        }
                        else
                        {
                            strMessage += "\n" + "Plase select the recode ";
                            MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
        }
        #endregion

        #region Btn Print
        private void frm_scsStockAdjustment_SF_printButton_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_scsStockAdjustment_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
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
            catch (Exception) { }
        }
        #endregion

        #region btn Add
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (AddCheckValidity())
                {
                    if (AddCheckNumberValidity())
                    {
                        int iRow;
                        decimal dQtyCurrent = 0;
                        clsCommon.ValidateForeignKey(ref txtItemSubCategory);
                        clsCommon.ValidateForeignKey(ref txtItemSerialNo, "0");
                        if (IsUpdateAdjustment)
                            iRow = int.Parse(txtRowNo.Text.Trim());
                        else
                        {
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                        }
                        dgvDetail["ItemCode", iRow].Value = txtInputMaterialID.Tag.ToString().Trim();
                        dgvDetail["ItemName", iRow].Value = txtInputMaterialID.Text.Trim();

                        tbl_genItemMaster detail = tbl_genItemMaster.Select(txtInputMaterialID.Tag.ToString());
                        if (detail != null)
                        {
                            tbl_zUom Uomdetail = tbl_zUom.Select(detail.Uom_ID);
                            if (Uomdetail != null)
                                dgvDetail["UOM", iRow].Value = Uomdetail.UomCode;
                        }

                        List<tbl_genStore_Stock> oStock = tbl_genStore_Stock.SelectAllByStore_ID(txtStoreID.Tag.ToString()).Where(p => p.Item_ID == txtInputMaterialID.Tag.ToString()).ToList();
                        if (oStock.Count > 0)
                            dQtyCurrent = oStock.FirstOrDefault().Qty;

                        if (clsConfig.bShowSystemQty)
                            dgvDetail.Columns["QtyCurrent"].Visible = true;

                        dgvDetail["Weight", iRow].Value = "0";
                        dgvDetail["QtyCurrent", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dQtyCurrent);
                        dgvDetail["Quantity", iRow].Value = "0";
                        // dgvDetail["Department_ID", iRow].Value = txtDepartmentID.Text.Trim();
                        //  dgvDetail["Section_ID", iRow].Value = txtSectionID.Text.Trim();
                        dgvDetail["Store_ID", iRow].Value = txtStoreID.Text.Trim();
                        dgvDetail["ItemSubCategoryID", iRow].Tag = txtItemSubCategory.Tag.ToString();
                        dgvDetail["ItemSubCategoryID", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(txtItemSubCategory.Tag.ToString()));
                        dgvDetail["ItemSubCategoryID2", iRow].Tag = txtItemSubCategory.Text.Trim();
                        dgvDetail["ItemSubCategoryID2", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory2(txtItemSubCategory.Text.Trim()));
                        dgvDetail["ItemSerialNo", iRow].Value = txtItemSerialNo.Tag.ToString();
                        dgvDetail["ItemSerialNo2", iRow].Value = txtItemSerialNo.Text.Trim();

                        tbl_genItemMaster_Pricing itemFinace = tbl_genItemMaster_Pricing.Select(txtInputMaterialID.Tag.ToString());
                        if (itemFinace != null)
                        {
                            dgvDetail["UnitPrice", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(itemFinace.LifoCostPrice);
                            dgvDetail["WACurrent", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(itemFinace.WeightedAverageCostPrice);
                        }
                        else
                        {
                            dgvDetail["UnitPrice", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                            dgvDetail["WACurrent", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                        }

                        dgvDetail["WAEstimated", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);

                        ClearFieldContact();
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

        #region Btn Info Input Item
        private void btnInfoInputItem_Click(object sender, EventArgs e)
        {
            //if (txtInputMaterialID.Tag != null && txtInputMaterialID.Tag.ToString().Trim().Length > 0)
            //{
            //    clsHelpMethods.ItemViewerByItemTypeID(txtInputMaterialID.Tag.ToString(), iFormID);
            //}
        }
        #endregion

        #region Btn Temp
        private void frm_scsStockAdjustment_SF_tempButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSANID.TextLength > 0 && txtSANID.Text != "<Auto Generate>")
                {
                    //set the flag and enble the id
                    IsUpdate = false;
                    lblCancelled.Visible = false;

                    clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtSANID, true);
                    clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, true);
                    clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtInputMaterialID, true);
                    clsCommon.SetEnableDisable_NormalTextbox(txtMaterialQty, true);
                    clsCommon.SetEnableDisable_NormalTextbox(txtWeight, true);
                    clsCommon.SetEnableDisable_NormalLabel(lblSANCode, true);

                    txtSANID.Tag = null;
                    dtpAdjustmentDate.Value = clsSecurity.getServerDateTime();

                    bHasApproved = false;
                    bHasChecked = false;
                    userDetailsColorChanges();

                    //Reset Primary Key
                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                        txtSANID.Text = "<Auto Generate>";
                    else
                        txtSANID.Clear();
                    if (txtSANID.Enabled)
                    {
                        txtSANID.SelectAll();
                        txtSANID.Focus();
                    }

                    Attachments.Clear();
                }

            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat_New(dgvDetail, clsFormatter.colorGrid, UI_Color);
            //clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);
            clsHelpMethods_Local.FormatGrid_Sales(dgvDetail);

            if (clsConfig.bWrap_ItemGrid_ItemName)
            {
                dgvDetail.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            //Change Grid Headers
            dgvDetail.Columns["ItemSubCategoryID"].HeaderText = clsConfig.sItemSubCategory;
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtSANID, true);
            //   clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSectionID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, true);
            //  clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtDepartmentID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtInputMaterialID, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtMaterialQty, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtWeight, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSANCode, true);
            chkUnitPricing.Checked = true;

            dtpAdjustmentDate.Value = clsSecurity.getServerDateTime();

            txtSANID.Tag = null;
            //   txtDepartmentID.Tag = null;
            //  txtSectionID.Tag = null;
            txtStoreID.Tag = null;
            txtInputMaterialID.Tag = null;

            txtRemark.Clear();
            txtSANID.Clear();
            txtInputMaterialID.Clear();
            txtMaterialQty.Clear();
            txtWeight.Clear();
            txtRemark.Clear();
            //txtDepartmentID.Clear();
            // txtSectionID.Clear();
            txtStoreID.Clear();

            chkShowSettle.Checked = false;
            lblCancelled.Visible = false;
            dgvDetail.Columns["QtyCurrent"].Visible = false;
            chkPrintOriginal.Checked = false;

            bHasApproved = false;
            bHasChecked = false;
            userDetailsColorChanges();

            dgvDetail.Rows.Clear();

            dtpAdjustmentDate.Enabled = !clsConfig.bLock_TransactionDate_SCS;

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtSANID.Text = "<Auto Generate>";
            else
                txtSANID.Clear();
            if (txtSANID.Enabled)
            {
                txtSANID.SelectAll();
                txtSANID.Focus();
            }

            Attachments.Clear();
        }
        #endregion

        #region Clear Stoke Contact
        private void ClearStokeContact()
        {
            txtStoreID.Clear();
            txtStoreID.Tag = null;
        }
        #endregion

        #region Clear Field Contact
        private void ClearFieldContact()
        {
            //set the flag and enble the id
            IsUpdateAdjustment = false;
            txtInputMaterialID.Clear();
            txtMaterialQty.Clear();
            txtWeight.Clear();
            txtRemark.Clear();
        }
        #endregion

        #region Fill Details Input Products
        private void FillDetailsInputProduct(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_genItemMaster detail = tbl_genItemMaster.Select(sID);
                    if (detail != null)
                    {
                        txtInputMaterialID.Tag = detail.Item_ID;
                        txtInputMaterialID.Text = detail.ItemName;
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

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_scsStockAdjustment detail = tbl_scsStockAdjustment.Select(sID);
                    if (detail != null)
                    {
                        IsUpdate = true;

                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;
                        else
                            lblCancelled.Visible = false;

                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtSANID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtInputMaterialID, true);
                        clsCommon.SetEnableDisable_NormalTextbox(txtMaterialQty, false);
                        clsCommon.SetEnableDisable_NormalTextbox(txtWeight, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblSANCode, false);

                        //asign values

                        txtStoreID.Tag = detail.Store_ID;

                        txtRemark.Text = detail.Remark;
                        //   txtDepartmentID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Department(detail.Department_ID));
                        //    txtSectionID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Section(detail.Section_ID));
                        txtStoreID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(detail.Store_ID));
                        txtSANID.Text = clsCommon.GetForeignKeyValue(detail.StockAdjustment_ID);

                        dtpAdjustmentDate.Value = detail.StockAdjustmentDate;

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
                        RefreshGrid(detail.StockAdjustment_ID);

                        Attachments.FillAttachments(sID);
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

        #region Refresh Grid
        private void RefreshGrid(string StockAdjustmentID)
        {
            try
            {
                //   int iRow;
                decimal dQtyCurrent = 0;
                dgvDetail.Rows.Clear();
                List<tbl_scsStockAdjustment_Detail> details = tbl_scsStockAdjustment_Detail.SelectAllByStockAdjustment_ID(StockAdjustmentID);
                foreach (tbl_scsStockAdjustment_Detail detail in details)
                {
                    if (detail.StockAdjustment_ID != "default")
                    {
                        dgvDetail.Rows.Add();
                        int iRow = dgvDetail.Rows.Count - 1;

                        if (txtStoreID.Tag != null && txtInputMaterialID.Tag != null)
                        {
                            List<tbl_genStore_Stock> oStock = tbl_genStore_Stock.SelectAllByStore_ID(txtStoreID.Tag.ToString()).Where(p => p.Item_ID == txtInputMaterialID.Tag.ToString()).ToList();
                            if (oStock.Count > 0)
                                dQtyCurrent = oStock.FirstOrDefault().Qty;
                        }

                        dgvDetail.Columns["QtyCurrent"].Visible = false;

                        dgvDetail["ItemCode", iRow].Value = detail.Item_ID;
                        dgvDetail["ItemSubCategoryID", iRow].Value = clsGenaralName.getName_ItemSubCategory(detail.ItemSubCategory_ID);
                        dgvDetail["Weight", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(detail.Weight);
                        dgvDetail["QtyCurrent", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(dQtyCurrent);
                        //dgvDetail["Quantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(detail.Qty);
                        dgvDetail["Quantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(detail.Qty - detail.OldQty);
                        dgvDetail["UnitPrice", iRow].Value = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.UnitPrice);
                        dgvDetail["WeightPrice", iRow].Value = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.WeightPrice);

                        dgvDetail["ItemSubCategoryID", iRow].Tag = detail.ItemSubCategory_ID;
                        dgvDetail["ItemSubCategoryID2", iRow].Tag = detail.ItemSubCategory2_ID;
                        dgvDetail["ItemSerialNo", iRow].Value = detail.ItemSerialNo;
                        dgvDetail["ItemSerialNo2", iRow].Value = detail.ItemSerialNo2;
                        dgvDetail["Remarks", iRow].Value = detail.Remark;

                        tbl_genItemMaster Itemdetail = tbl_genItemMaster.Select(detail.Item_ID);
                        if (Itemdetail != null)
                        {
                            tbl_zUom Uomdetail = tbl_zUom.Select(Itemdetail.Uom_ID);
                            if (Uomdetail != null)
                                dgvDetail["UOM", iRow].Value = Uomdetail.UomCode;
                            dgvDetail["ItemName", iRow].Value = Itemdetail.ItemName;
                        }

                        tbl_genItemMaster_Pricing itemFinace = tbl_genItemMaster_Pricing.Select(detail.Item_ID);
                        if (itemFinace != null)
                            dgvDetail["WACurrent", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(itemFinace.WeightedAverageCostPrice);
                        else
                            dgvDetail["WACurrent", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);

                        dgvDetail["WAEstimated", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);

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

        #region Evenst Double Click
        private void txtInputMaterialID_DoubleClick(object sender, EventArgs e)
        {
            Search_ItemID(sender, new KeyEventArgs(Keys.F1));
        }

        private void txtStoreID_DoubleClick(object sender, EventArgs e)
        {
            ClearStokeContact();
            clsSearch.Search_MasterStore(ref txtStoreID, clsConfig.enableBranchWiseFilterOnSearch ? true : false);
        }

        private void txtSANID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_TransactionStockAdjustment(ref txtSANID, chkShowSettle.Checked);
            if (txtSANID.Tag != null && txtSANID.Tag.ToString().Trim().Length > 0)
                FillDetails(txtSANID.Tag.ToString());
        }
        #endregion

        #region Events key Press
        private void txtMaterialQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }
        #endregion

        #region Grid Events
        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;
                if (sColName != "UOM" && sColName != "Quantity" && sColName != "Weight" && sColName != "UnitPrice" && sColName != "WeightPrice" && sColName != "Remarks")
                {
                    clsAlerts.DisplayItemViewer(dgvDetail["ItemCode", e.RowIndex].Value.ToString(),
                        dgvDetail["ItemSubCategoryID", e.RowIndex].Tag.ToString(), dgvDetail["ItemSubCategoryID2", e.RowIndex].Tag.ToString(),
                        dgvDetail["ItemSerialNo", e.RowIndex].Value.ToString(), dgvDetail["ItemSerialNo2", e.RowIndex].Value.ToString());
                }
            }
        }
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail_CellDoubleClick(sender, e);
        }
        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                decimal dQuantity;
                dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", e.RowIndex, decimal.Parse("0.00"));
                dgvDetail["Quantity", e.RowIndex].Value = dQuantity;

                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                #region for W/A changes
                //if (sColName == "Quantity")
                //{
                //    string sItemCode = "", sItemName = "default", sUOM = "", sWeight = "",// sSelectArea_ID = "", sDepartment_ID = "default", sSection_ID = "", sStore_ID = "",
                //    sItemSubCategoryID1 = "", sItemSubCategoryID2 = "", sItemSerialNo1 = "", sItemSerialNo2 = "";
                //    decimal dWeight = 0, stockQTY = 0; ;

                //    sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", e.RowIndex, "default");
                //    sItemName = clsValidate.ValidateGridValue(dgvDetail, "ItemName", e.RowIndex, "");
                //    sUOM = clsValidate.ValidateGridValue(dgvDetail, "UOM", e.RowIndex, "default");
                //    sWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", e.RowIndex, "");
                //    dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", e.RowIndex, decimal.Parse("0.00"));
                //    dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", e.RowIndex, decimal.Parse("0.00"));
                //    sItemSubCategoryID1 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", e.RowIndex, "default");
                //    sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", e.RowIndex, "default");
                //    sItemSerialNo1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", e.RowIndex, "0");
                //    sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", e.RowIndex, "0");

                //    if (txtStoreID.Tag != null && txtStoreID.Tag.ToString().Length > 0)
                //    {
                //        tbl_genStore_Stock stock = tbl_genStore_Stock.Select(txtStoreID.Tag.ToString(), sItemCode, "default", sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2);
                //        if (stock != null)
                //        {
                //            stockQTY = stock.Qty;
                //        }
                //        // if (dQuantity > stockQTY)
                //        //{
                //        clsAlerts.DisplayItemPriceViewer(sItemCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2);
                //        dgvDetail["UnitPrice", e.RowIndex].Value = glbnewPrice;
                //        // }
                //    }
                //} 
                #endregion
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        #endregion

        #region Event KeyDown

        private void txtSANID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_TransactionStockAdjustment(ref txtSANID, chkShowSettle.Checked);
                FillDetails(txtSANID.Text);
            }
        }

        private void txtInputMaterialID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsHelpMethods_Local.SearchItemAdvance(ref txtInputMaterialID, ref txtItemSubCategory, ref txtItemSerialNo);
            else
                clsHelpMethods_Local.SearchItemAdvanceByKeyPress(ref txtInputMaterialID, ref txtItemSubCategory, ref txtItemSerialNo, e);
        }

        private void txtStoreID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                ClearStokeContact();
                clsSearch.Search_MasterStore(ref txtStoreID, clsConfig.enableBranchWiseFilterOnSearch ? true : false);
            }
        }
        #endregion

        #region Button F5
        private void btnF5_Click(object sender, EventArgs e)
        {
            if (clsConfig.bEnableF5_StockAdjustment)
            {
                txtInputMaterialID.Tag = null;
                txtInputMaterialID.Clear();
                Search_ItemID(sender, new KeyEventArgs(Keys.F5));
            }

        }
        #endregion

        #region Search_ItemID
        private void Search_ItemID(object sender, KeyEventArgs e)
        {
            try
            {
                if (CheckValidity_Emptyfield())
                {
                    string sStoreID = "", sSectionID = "", sDepartmentID = "";
                    if (txtStoreID.Tag != null && txtStoreID.Tag.ToString().Trim().Length > 0)
                        sStoreID = txtStoreID.Tag.ToString();

                    if (e.KeyCode == Keys.F1)
                    {
                        clsHelpMethods_Local.SearchItemAdvance(ref txtInputMaterialID, ref txtItemSubCategory, ref txtItemSerialNo);
                        if (txtInputMaterialID.Tag != null && txtInputMaterialID.Tag.ToString().Trim().Length > 0) //call add button
                            btnAdd_Click(sender, new EventArgs());
                    }

                    //else if (e.KeyCode == Keys.F5)
                    //{
                    //    frm_sasMultipleItemSelect frm = new frm_sasMultipleItemSelect();
                    //    //string sItemPriceCategory = ((ComboBoxItem)cmbItemPrice.SelectedItem).Value;
                    //    //frm.glb_sItemPriceCategory = sItemPriceCategory;
                    //    frm.glb_sItemPriceCategory = "";
                    //    frm.glb_sStoreID = sStoreID;
                    //    frm.glb_bStockValidate_ManuallyDisable = true; //disable stock validity functionfrm.glb_bStAdj = true;
                    //    frm.ShowDialog();


                    //    if (frm.lstclsTmpMultipleSelectedItems.Count > 0)
                    //    {
                    //        foreach (clsTmpMultipleSelectedItems oItem in frm.lstclsTmpMultipleSelectedItems)
                    //        {
                    //            dgvDetail.Rows.Add();
                    //            int iRow = dgvDetail.Rows.Count - 1;
                    //            string sToLocation = clsHelpMethods_Local.getToLocationName(txtStoreID, txtStoreID, txtStoreID);
                    //            string sNoteID = "N/A";

                    //            Fill_StockDatagrid(dgvDetail, iRow, oItem.sItemID, oItem.sUOMID, "", "", "", sToLocation, sNoteID, oItem.dQty, oItem.dWeight, oItem.sItemSubCategoryID, oItem.sItemSubCategoryID2, oItem.sItemSerialNo, oItem.sItemSerialNo2, "N", oItem.dUnitPrice, oItem.dTotalAmount);
                    //        }
                    //    }
                    //}
                    else if (e.KeyCode == Keys.Enter)
                    {
                        if (clsValidate.Validate_ItemCode(ref txtInputMaterialID, ref txtItemSubCategory, ref txtItemSerialNo))
                        {
                            if (txtInputMaterialID.Tag != null && txtInputMaterialID.Tag.ToString().Trim().Length > 0) //call add button
                                btnAdd_Click(sender, new EventArgs());
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
        #endregion

        #region Fill Datagrid
        public static void Fill_StockDatagrid(DataGridView dgvDetail, int iRow, string sItemID, string sUom_ID,
           //string sJobCode, 
           string sSelectArea_ID, string sDepartment_ID, string sSection_ID, string sStore_ID,
           //string sDepartmentNote_ID, string sSectionNote_ID, string sStoreNote_ID, string sGoodsFrom,
           string sNoteID, decimal dQuantity, decimal dWeight, string sItemSubCategory1, string sItemSubCategory2,
           string sSerial1, string sSerial2, string sItemStatus, decimal dUnitPrice, decimal dTotalAmount)
        {
            bool bItemExist = false;

            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                string sTmpItemID = "", sTmpItemSub = "", sTmpItemSub2 = "", sTmpSerial = "", sTmpSerial2 = "";
                sTmpItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                sTmpItemSub = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                sTmpItemSub2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                sTmpSerial = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                sTmpSerial2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");

                if (sItemID == sTmpItemID && sItemSubCategory1 == sTmpItemSub && sItemSubCategory2 == sTmpItemSub2 && sSerial1 == sTmpSerial && sSerial2 == sTmpSerial2)
                {
                    bItemExist = true;
                    dgvDetail.Rows.RemoveAt(iRow);
                    iRow = row.Index;
                    break;
                }
            }

            if (!bItemExist)
            {
                dgvDetail["ItemCode", iRow].Value = sItemID;
                dgvDetail["ItemName", iRow].Value = clsGenaralName.getName_Item(sItemID);
                dgvDetail["UOM", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Uom(sUom_ID));
                dgvDetail["UOM", iRow].Tag = sUom_ID;
                dgvDetail["ItemStatus", iRow].Value = sItemStatus;

                dgvDetail["SelectArea_ID", iRow].Value = sSelectArea_ID;
                dgvDetail["Department_ID", iRow].Value = sDepartment_ID;
                dgvDetail["Section_ID", iRow].Value = sSection_ID;
                dgvDetail["Store_ID", iRow].Value = sStore_ID;
                //dgvDetail["DepartmentNote_ID", iRow].Value = sDepartmentNote_ID;
                //dgvDetail["SectionNote_ID", iRow].Value = sSectionNote_ID;
                //dgvDetail["StoreNote_ID", iRow].Value = sStoreNote_ID;
                //dgvDetail["JobCode", iRow].Value = clsCommon.GetForeignKeyValue(sJobCode);
                //dgvDetail["GoodsFrom", iRow].Value = clsCommon.GetForeignKeyValue(sGoodsFrom);
                dgvDetail["Note_ID", iRow].Value = clsCommon.GetForeignKeyValue(sNoteID);


                dgvDetail["ItemSubCategoryID", iRow].Tag = sItemSubCategory1;
                dgvDetail["ItemSubCategoryID", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(sItemSubCategory1));
                dgvDetail["ItemSubCategoryID2", iRow].Tag = sItemSubCategory2;
                dgvDetail["ItemSubCategoryID2", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory2(sItemSubCategory2));
                dgvDetail["ItemSerialNo", iRow].Value = sSerial1;
                dgvDetail["ItemSerialNo2", iRow].Value = sSerial2;

                dgvDetail["Quantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(dQuantity);
                dgvDetail["Weight", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(dWeight);

                dgvDetail["UnitPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(dUnitPrice);
                dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(dTotalAmount);

                dgvDetail["Quantity", iRow].Selected = true;
            }
            else
                MessageBox.Show("User is not allowed to add same item again...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        #endregion

        #region Check Add Validity
        private bool AddCheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtInputMaterialID.TextLength == 0)
            {
                strMessage += "\n" + "Material Name";
                bStatus = false;
            }
            if (txtStoreID.TextLength == 0)//&& txtSectionID.TextLength == 0 && txtDepartmentID.TextLength == 0)
            {
                strMessage += "\n" + "Location Name";
                bStatus = false;
            }
            //if (txtMaterialQty.TextLength == 0 )
            //{
            //    strMessage += "\n" + "Material Quantity";
            //    bStatus = false;
            //}
            //if (txtWeight.TextLength == 0)
            //{
            //    strMessage += "\n" + "Material Weight";
            //    bStatus = false;
            //}
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }

        private bool AddCheckNumberValidity()
        {
            string strMessage = "Please do not enter same Item to Datagrid";
            bool bStatus = true;

            try
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    if (txtInputMaterialID.Tag.ToString() == clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "") && txtItemSubCategory.Tag.ToString() == clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, ""))
                    {
                        bStatus = false;
                    }
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
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_Emptyfield())
            {
                if (CheckNumberValidity())
                {
                    //if (clsValidate.CheckFinancialYearValidity(clsSecurity.FinancialYearID, dtpAdjustmentDate.Value))
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpAdjustmentDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                        {
                            if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreID.Tag.ToString(), IsUpdate))
                            {
                                if (CheckStock_Validate())
                                {
                                    if (CheckValidity_WATollarance())
                                    {
                                        if (CheckValidity_Posting())
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

            return bStatus;
        }

        private bool CheckValidity_Posting()
        {
            bool bStatus = false;
            if (clsConfig.bAutoPostingEnable)
            {
                var Items = new List<StringArray>();
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    string sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");

                    Items.Add(new StringArray { S = sItemCode });
                }

                var responce = oData.Validate_Ledger_PurchaceAcc(Items);
                if (!responce.IsSuccess)
                {
                    MessageBox.Show(responce.OutMsg, clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    bStatus = false;
                }
                else
                    bStatus = true;
            }
            return bStatus;
        }
        private bool CheckValidity_WATollarance()
        {
            
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
                int iLineNo = 0;
                string sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                decimal dQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                decimal dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));

                dtGrid.Rows.Add(iLineNo, sItemCode, dQty, dUnitPrice);
            }
            #endregion

            #region Copy Saved value
            foreach (tbl_scsStockAdjustment_Detail oDetail in tbl_scsStockAdjustment_Detail.SelectAllByStockAdjustment_ID(txtSANID.Text.Trim()))
            {
                DB.Add(new tbl_Detail(0, oDetail.Item_ID, oDetail.Qty, oDetail.UnitPrice));
            }
            #endregion

            return clsHelpMethods.CheckValidity_WATollarance(dtGrid, DB);
        }


        private bool CheckValidity_Emptyfield()
        {
            bool bStatus = false;
            if (txtStoreID.TextLength > 0)
                bStatus = true;

            else
                clsValidate.ValidateTextBox_EmptyValue(txtStoreID, "Stock");
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
        private bool CheckStock_Validate()
        {
            bool bStatus = true;
            try
            {
                List<string> oList = new List<string>();

                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    try
                    {
                        string sItemCode = "", sItemName = "";
                        decimal dQuantity = 0, dActualQty = 0;

                        sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                        sItemName = clsValidate.ValidateGridValue(dgvDetail, "ItemName", row.Index, "default");
                        dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));

                        #region Stock Adjustment Detail
                        if (sItemCode.Length > 0)
                        {
                            tbl_genStore_Stock stock;
                            stock = tbl_genStore_Stock.Select(txtStoreID.Tag.ToString(), sItemCode, "default", "default", "default", "0", "0");
                            if (stock == null)
                            {
                                stock = new tbl_genStore_Stock(txtStoreID.Tag.ToString(), sItemCode, "default", "default", "default", "0", "0", 0, 0, 0, 0, 0, 0, 0, 0);
                                stock.Insert();
                            }
                            
                            if (stock != null)
                            {
                                if (IsUpdate)
                                {
                                    dActualQty = stock.Qty + dQuantity;
                                    if (dActualQty < 0)
                                    {
                                        bStatus = false;
                                        oList.Add(sItemCode + " / " + sItemName + " / " + clsFormatter.FormatDecimalPlaces_Quantity(dActualQty));
                                    }
                                }
                                else
                                {
                                    dActualQty = stock.Qty + dQuantity;
                                    if (dActualQty < 0)
                                    {
                                        bStatus = false;
                                        oList.Add(sItemCode + " / " + sItemName + " / " + clsFormatter.FormatDecimalPlaces_Quantity(dActualQty));
                                    }
                                }
                            }
                        }
                        #endregion

                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID, ex);
                        SEACCException.Show(ex);
                    }
                }

                if (!bStatus)
                {
                    string sDisplayItems = string.Join(", " + Environment.NewLine, oList);
                    DialogResult dr = MessageBox.Show("Following store's items quantity getting minus,\n\n " + sDisplayItems + " \n\nDo you want to proceed?", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (DialogResult.Yes == dr)
                        bStatus = true;
                    else
                        bStatus = false;
                }

            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            return bStatus;
        }

        private bool CheckCancelValidity_WATollarance()
        {
            List<tbl_Detail> DB = new List<tbl_Detail>();
            foreach (tbl_scsStockAdjustment_Detail oDetail in tbl_scsStockAdjustment_Detail.SelectAllByStockAdjustment_ID(txtSANID.Text.Trim()))
            {
                DB.Add(new tbl_Detail(0, oDetail.Item_ID, oDetail.Qty, oDetail.UnitPrice));
            }
            return clsHelpMethods.CheckCancelValidity_WATollarance(DB);
        }
    

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            clsCommon.ValidateForeignKey(ref txtStoreID);
        }
        #endregion

        #region Set Item Financel Details
        //private void SetItemFinanceDetails(string sItemID, decimal dUnitPrice, decimal dGRNqty, string sSubCategogry1, string sSubCategogry2, string sSerial1, string sSerial2)
        //{
        //    decimal dFIFO = 0, dLIFO = 0, dWAvgCost = 0, dLPCost = 0, dHPCost = 0;
        //  //  dFIFO = clsProcessMethods.GetFIFOCostPrice(sItemID, dUnitPrice, sSubCategogry1, sSubCategogry2, sSerial1, sSerial2);
        //  //  dLIFO = clsProcessMethods.GetLIFOCostPrice(sItemID, dUnitPrice);
        //    dWAvgCost = clsProcessMethods.GetWeightedAverageCostPrice(sItemID, dUnitPrice, dGRNqty, sSubCategogry1, sSubCategogry2, sSerial1, sSerial2);
        //    dLPCost = clsProcessMethods.GetLovesetPurchaseCostPrice(sItemID, dUnitPrice, sSubCategogry1, sSubCategogry2, sSerial1, sSerial2);
        //    dHPCost = clsProcessMethods.GetHighestPurchaseCostPrice(sItemID, dUnitPrice, sSubCategogry1, sSubCategogry2, sSerial1, sSerial2);

        //    tbl_genItemMaster_Pricing item = tbl_genItemMaster_Pricing.Select(sItemID, sSubCategogry1, sSubCategogry2, sSerial1, sSerial2);
        //    if (item != null)
        //    {
        //        item.LIFOCostPrice = dLIFO;
        //        item.FIFOCostPrice = dFIFO;
        //        item.WeightedAverageCostPrice = dWAvgCost;
        //        item.HighestPurchaseCostPrice = dHPCost;
        //        item.LovesetPurchaseCostPrice = dLPCost;
        //        item.Update();
        //    }
        //    else
        //    {
        //        tbl_genItemMaster_Pricing newItem = new tbl_genItemMaster_Pricing(sItemID, sSubCategogry1, sSubCategogry2, sSerial1, sSerial2, dLIFO, dFIFO, dWAvgCost, dHPCost, dLPCost, 0, 0, 0, 0, false, false);
        //        newItem.Insert();
        //    }
        //}
        #endregion

        #region get Total Qty
        private decimal getTotalQty(string sItemCode, string sItemSubCategoryID1, string sItemSubCategoryID2, string sItemSerialNo1, string sItemSerialNo2)
        {
            decimal TotalQty = 0;
            try
            {
                List<tbl_genStore_Stock> Stockdetails = tbl_genStore_Stock.SelectAllByItem_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2(sItemCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2);
                foreach (tbl_genStore_Stock Stockdetail in Stockdetails)
                {
                    TotalQty += Stockdetail.Qty;
                }

            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            return TotalQty;
        }
        #endregion

        #region Print Method
        private void Print(bool bIsDraft)
        {
            try
            {
                glbdts_Stock.Clear();
                bool isDuplicate = false;
                if (txtSANID.TextLength > 0 && txtSANID.Text != "<Auto Generate>")
                {
                    //update receipt
                    string sCreateUser = "[ None ]", sCheckedUser = "[ None ]", sApprovedUser = "[ None ]", sDuplicateCopy = "";
                    bool bPermissinOkToPrint = true;
                    if (chkPrintOriginal.Checked)
                        bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_StockAdjustment));
                    if (bPermissinOkToPrint)
                    {
                        tbl_scsStockAdjustment oAdj = tbl_scsStockAdjustment.Select(txtSANID.Text.Trim());
                        if (oAdj != null && oAdj.StockAdjustment_ID != "default")
                        {
                            if (!bIsDraft)
                            {
                                if (oAdj.PrintCount > 0)
                                {
                                    isDuplicate = true;

                                    if (!chkPrintOriginal.Checked)
                                        sDuplicateCopy = "Duplicate Copy " + oAdj.PrintCount;
                                }

                                oAdj.PrintCount++;
                            }

                            //Write Audit Trial Log
                            clsLog.Process_Print(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.StockAdjustment), oAdj.StockAdjustment_ID);

                            //order.PrintCount++;
                            //oAdj.IsLocked = true;
                            sCreateUser = clsGenaralName.getName_User(oAdj.CreateUser_ID);
                            if (oAdj.CheckedUser_ID != "default")
                                sCheckedUser = "[ " + clsGenaralName.getName_User(oAdj.CheckedUser_ID) + " ] [ " + oAdj.DateChecked.ToShortDateString() + " ]";
                            if (oAdj.ApprovedUser_ID != "default")
                                sApprovedUser = "[ " + clsGenaralName.getName_User(oAdj.ApprovedUser_ID) + " ] [ " + oAdj.DateApproved.ToShortDateString() + " ]";
                            oAdj.Update();

                            glbdts_Stock.dt_StockAjustment.Adddt_StockAjustmentRow(oAdj.StockAdjustment_ID, oAdj.StockAdjustmentDate, oAdj.Store_ID, clsGenaralName.getName_Store(oAdj.Store_ID), oAdj.Department_ID, clsGenaralName.getName_Department(oAdj.Department_ID), oAdj.Section_ID, clsGenaralName.getName_Section(oAdj.Section_ID), oAdj.Remark, clsGenaralName.getName_User(oAdj.CreateUser_ID), clsGenaralName.getName_User(oAdj.CheckedUser_ID), clsGenaralName.getName_User(oAdj.ApprovedUser_ID), oAdj.IsDeleted);
                            foreach (tbl_scsStockAdjustment_Detail oItem in tbl_scsStockAdjustment_Detail.SelectAllByStockAdjustment_ID(oAdj.StockAdjustment_ID).Where(p => p.StockAdjustment_ID != "default"))
                            {
                                glbdts_Stock.dt_StockAjustmentDetail.Adddt_StockAjustmentDetailRow(oItem.StockAdjustment_ID, oItem.Weight, (oItem.Qty - oItem.OldQty), clsGenaralName.getName_Item(oItem.Item_ID), oItem.Item_ID, oItem.ItemSubCategory_ID != "default" ? oItem.ItemSubCategory_ID : "-");
                            }
                        }

                        string sGetRptPath = clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_StockAdjustment));
                        string s_Path = "";
                        if (sGetRptPath != null && sGetRptPath.Length > 0)
                            s_Path += sGetRptPath;
                        else
                            s_Path += "\\reports\\SCS\\NotePrinting\\rpt_scsStockAdjustment_DataSet.rpt";

                        //glbdts_Stock.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "Stock Adjustment", "", "", clsSecurity.UserNameLoged, "");

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
                        glbdts_Stock.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, "Stock Adjustment", "", "", clsSecurity.UserNameLoged, "");
                        #endregion

                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicateCopy, true);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUser, true);

                        frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
                        ReportViewer.print(s_Path, glbdts_Stock, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_StockAdjustment));
                    }
                }
                else
                    MessageBox.Show("Please Select the Stock Adjustment Note To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
                glbdts_Stock.Clear();
            }
        }

        private void print(string path, string sReportTitle1, string sReportTitle2, string sReportTitle3, DataSet ojbDataSet, bool isDuplicate)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Standed Reports";
                //   CrystalDecisions.CrystalReports.Engine.ReportDocument objRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                ReportDocument objRpt = new ReportDocument();

                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(ojbDataSet); //(glbDtsBills);

                objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle1);
                objRpt.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["CompanyEmail"].Text = clsCommon.fncsetstring(clsCommon.getCompanyEmail());
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                objRpt.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToShortDateString());
                if (isDuplicate)
                    objRpt.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring("Duplicate Copy");

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

        #region User Checked Approve Details
        private void frm_scsStockAdjustment_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_scsStockAdjustment_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpAdjustmentDate.Value.Date))
                {
                    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtSANID.Text != null && txtSANID.TextLength > 0 && txtSANID.Text != "<Auto Generate>")
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

                                        tbl_scsStockAdjustment objSAN = tbl_scsStockAdjustment.Select(txtSANID.Text.Trim());
                                        if (objSAN != null)
                                        {
                                            objSAN.IsApproved = true;
                                            objSAN.DateApproved = clsSecurity.getServerDateTime();
                                            objSAN.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                            objSAN.Update();
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
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpAdjustmentDate.Value.Date))
                {
                    if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtSANID.Text != null && txtSANID.TextLength > 0 && txtSANID.Text != "<Auto Generate>")
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

                                        tbl_scsStockAdjustment objSAN = tbl_scsStockAdjustment.Select(txtSANID.Text.Trim());
                                        if (objSAN != null)
                                        {
                                            objSAN.IsChecked = true;
                                            objSAN.DateChecked = clsSecurity.getServerDateTime();
                                            objSAN.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objSAN.Update();
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

        private void frm_scsStockAdjustment_SF_History_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSANID.Text != "" || txtSANID.Text != "<Auto Generate>")
                {
                    tbl_scsStockAdjustment detail = tbl_scsStockAdjustment.Select(txtSANID.Text);
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

        #region old
        //         try
        //            {
        //                glbdts_Stock.Clear();
        //                bool isDuplicate = false;
        //                if (txtSANID.TextLength > 0 && txtSANID.Text != "<Auto Generate>")
        //                {
        //                    //update receipt
        //                    string sCreateUser = "[ None ]", sCheckedUser = "[ None ]", sApprovedUser = "[ None ]", sDuplicateCopy = "";
        //        tbl_scsStockAdjustment order = tbl_scsStockAdjustment.Select(txtSANID.Text.Trim());
        //                    if (order != null && order.StockAdjustment_ID != "default")
        //                    {
        //                        if (order.PrintCount > 0)
        //                        {
        //                            isDuplicate = true;
        //                            sDuplicateCopy = "Duplicate Copy " + order.PrintCount;
        //                        }
        //    order.PrintCount++;

        //                        //Write Audit Trial Log
        //                        clsLog.Process_Print(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.StockAdjustment), order.StockAdjustment_ID);

        //                        //order.PrintCount++;
        //                        order.IsLocked = true;
        //                        sCreateUser = clsGenaralName.getName_User(order.CreateUser_ID);
        //                        if (order.CheckedUser_ID != "default")
        //                            sCheckedUser = "[ " + clsGenaralName.getName_User(order.CheckedUser_ID) + " ] [ " + order.DateChecked.ToShortDateString() + " ]";
        //                        if (order.ApprovedUser_ID != "default")
        //                            sApprovedUser = "[ " + clsGenaralName.getName_User(order.ApprovedUser_ID) + " ] [ " + order.DateApproved.ToShortDateString() + " ]";
        //                        order.Update();

        //                        glbdts_Stock.dt_StockAjustment.Adddt_StockAjustmentRow(order.StockAdjustment_ID, order.StockAdjustmentDate, order.Store_ID, clsGenaralName.getName_Store(order.Store_ID), order.Department_ID, clsGenaralName.getName_Department(order.Department_ID), order.Section_ID, clsGenaralName.getName_Section(order.Section_ID), order.Remark, clsGenaralName.getName_User(order.CreateUser_ID), clsGenaralName.getName_User(order.CheckedUser_ID), clsGenaralName.getName_User(order.ApprovedUser_ID), order.IsDeleted);
        //                        foreach (tbl_scsStockAdjustment_Detail oItem in tbl_scsStockAdjustment_Detail.SelectAllByStockAdjustment_ID(order.StockAdjustment_ID).Where(p => p.StockAdjustment_ID != "default"))
        //                        {
        //                            //glbdts_Stock.dt_StockAjustmentDetail.Adddt_StockAjustmentDetailRow(oItem.StockAdjustment_ID, oItem.Weight, oItem.Qty, clsGenaralName.getName_Item(oItem.Item_ID), oItem.Item_ID, oItem.ItemSubCategory_ID != "default" ? oItem.ItemSubCategory_ID : "-");
        //                            glbdts_Stock.dt_StockAjustmentDetail.Adddt_StockAjustmentDetailRow(oItem.StockAdjustment_ID, oItem.Weight, (oItem.Qty - oItem.OldQty), clsGenaralName.getName_Item(oItem.Item_ID), oItem.Item_ID, oItem.ItemSubCategory_ID != "default" ? oItem.ItemSubCategory_ID : "-");
        //}
        //                    }

        //                    string sGetRptPath = clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_StockAdjustment));
        //string s_Path = "";
        //                    if (sGetRptPath != null && sGetRptPath.Length > 0)
        //                        s_Path += sGetRptPath;
        //                    else
        //                        s_Path += "\\reports\\SCS\\NotePrinting\\rpt_scsStockAdjustment_DataSet.rpt";

        //                    glbdts_Stock.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "Stock Adjustment", "", "", clsSecurity.UserNameLoged, "");

        //                    //print(s_Path, "Stock Adjustment  ", "", "", glbdts_Stock, isDuplicate);
        //                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicateCopy, true);
        //                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUser, true);

        //                    frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
        //ReportViewer.print(s_Path, glbdts_Stock, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_StockAdjustment));

        //                    #region Old Print
        //                    //Cursor = Cursors.WaitCursor;
        //                    //string s_Path = "", sReportTitle = "Stock Adjustment Note", sFormula = "";
        //                    //if (txtSANID.TextLength > 0)
        //                    //    sFormula = "{vw_rpt_scsStockAdjustment.stockAdjustment_ID} = '" + txtSANID.Text.Trim() + "'";

        //                    //ReportDocument RD = new ReportDocument();
        //                    //s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
        //                    //s_Path += "\\reports\\SCS\\NotePrinting\\rpt_scsStockAdjustment1.rpt";


        //                    //frm_ReportViewer viewer = new frm_ReportViewer();
        //                    //RD.Load(s_Path);
        //                    //clsSecurity.LogonServer(ref RD);
        //                    //RD.Refresh();
        //                    //if ((clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString() || clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString()))
        //                    //    RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);

        //                    //RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
        //                    ////RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToShortDateString());
        //                    //RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
        //                    //RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
        //                    //RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);
        //                    //RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
        //                    //RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
        //                    //RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
        //                    //RD.DataDefinition.FormulaFields["CompanyEmail"].Text = clsCommon.fncsetstring(clsCommon.getCompanyEmail());
        //                    //RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
        //                    //RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
        //                    //if (isDuplicate)
        //                    //    RD.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring("Duplicate Copy");

        //                    //viewer.crystalReportViewer1.ReportSource = RD;
        //                    //viewer.crystalReportViewer1.SelectionFormula = sFormula;
        //                    //viewer.crystalReportViewer1.Visible = true;
        //                    //viewer.crystalReportViewer1.DisplayToolbar = true;
        //                    //viewer.crystalReportViewer1.CloseView(false);
        //                    //viewer.WindowState = FormWindowState.Maximized;

        //                    //viewer.ShowDialog();

        //                    //RD.Close();
        //                    //RD.Dispose(); 
        //                    #endregion
        //                }
        //                else
        //                    MessageBox.Show("Please Select the Stock Adjustment Note To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //            catch (Exception ex)
        //            {
        //                SEACCException.Show(ex);
        //                clsValidate.WriteErrorLog("", iFormID,ex);
        //            }
        //            finally
        //            {
        //                Cursor = Cursors.Default;
        //                glbdts_Stock.Clear();
        //            } 
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