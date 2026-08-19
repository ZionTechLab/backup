using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using DataTire;

namespace Digiteq
{
    public partial class UC_AccAssetTransferNote : SEACC_Form
    {
        


        #region Form Load
        public UC_AccAssetTransferNote(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }         
        private void UC_AccAssetTransferNote_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, false, false, true, true, false, false, false, false);
            ClearFields();
        }
        #endregion

        #region Btn New Load
        private void UC_AccAssetTransferNote_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Button Save
        private void UC_AccAssetTransferNote_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    ValidateEmptyForeignKey();

                    if (IsUpdate)
                    {
                        #region Update
                        if (txtTransferCode.Text.Trim().Length > 0)
                        {
                            tbl_scsAssetsTransferNote oldRecord = tbl_scsAssetsTransferNote.Select(txtTransferCode.Text.Trim());
                            if (oldRecord != null)
                            {
                                if (!oldRecord.IsApproved && !oldRecord.IsDeleted && !oldRecord.IsInitialisation)
                                {
                                    if (clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                                    {
                                        if (CheckValidity_Dependencies())
                                        {
                                            if (clsValidate.CheckValidity_TransactionCodeLength(txtTransferCode.Text))
                                            {
                                               // List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();

                                                #region Header

                                                tbl_scsAssetsTransferNote detail = new tbl_scsAssetsTransferNote(
                                                    txtTransferCode.Text.Trim(), dtpTransferDate.Value, "",
                                                    txtDepFrom.Tag.ToString().Trim(), txtDepTo.Tag.ToString().Trim(),
                                                    oldRecord.CreateUser_ID, clsSecurity.UserIDLoged,
                                                    oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID,
                                                    oldRecord.DeletedUser_ID, oldRecord.PrintedUser_ID,
                                                    oldRecord.CreateTerminal_ID, clsSecurity.TerminalID,
                                                    oldRecord.DeletedTerminal_ID, oldRecord.PrintedTerminal_ID,
                                                    oldRecord.DateCreate, clsSecurity.getServerDateTime(),
                                                    glbCheckedDate, glbApprovedDate, oldRecord.DateDeleted,
                                                    oldRecord.DatePrinted,
                                                    bHasChecked, bHasApproved, oldRecord.IsDeleted,
                                                    oldRecord.IsInitialisation, oldRecord.PrintCount,
                                                    oldRecord.CompanyID, oldRecord.CompanyBranch_ID);
                                                detail.Update();

                                                #endregion

                                                #region Rollback Store Stock

                                                foreach (tbl_scsAssetsTransferNote_Detail oUpdatedRecore in
                                                    tbl_scsAssetsTransferNote_Detail.SelectAllByAssetsTransferNote_ID(
                                                        txtTransferCode.Text.Trim()))
                                                {
                                                    decimal dWeightedAverageCostPrice = 0;
                                                    //clsHelpMethods_Local.UpdateStoreStock(iFormID,
                                                    //    detail.AssetTransferNote_ID, detail.AssetTransferNoteDate,
                                                    //    oUpdatedRecore.Item_ID, "0", txtDepFrom.Tag.ToString(), 1, 0, 0,
                                                    //    true, false, false, ref dWeightedAverageCostPrice);
                                                    //clsHelpMethods_Local.UpdateStoreStock(iFormID,
                                                    //    detail.AssetTransferNote_ID, detail.AssetTransferNoteDate,
                                                    //    oUpdatedRecore.Item_ID, "0", txtDepTo.Tag.ToString(), 1, 0, 0,
                                                    //    true, true, false, ref dWeightedAverageCostPrice);

                                                    oUpdatedRecore.WeightedAvgCost = dWeightedAverageCostPrice;
                                                    oUpdatedRecore.Update();
                                                }

                                                #endregion

                                                #region Delete Old Records

                                                tbl_scsAssetsTransferNote_Detail.DeleteAllByAssetsTransferNote_ID(
                                                    txtTransferCode.Text.Trim());

                                                #endregion

                                                #region Detail

                                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                                {
                                                    try
                                                    {
                                                        

                                                        string sItemCode = "", sFixedAsetCode = "", sLineNo = "";

                                                        #endregion

                                                        #region Grid Validation

                                                        sLineNo = clsValidate.ValidateGridValue(dgvDetail, "RowCount",
                                                            row.Index, "0");
                                                        sItemCode = clsValidate.ValidateGridValue(dgvDetail, "itemID",
                                                            row.Index, "default");
                                                        sFixedAsetCode = clsValidate.ValidateGridValue(dgvDetail,
                                                            "assetCode", row.Index, "default");

                                                        #endregion

                                                        if (sItemCode.Length > 0)
                                                        {
                                                            tbl_scsAssetsTransferNote_Detail items =
                                                                new tbl_scsAssetsTransferNote_Detail(int.Parse(sLineNo),
                                                                    txtTransferCode.Text.Trim(), sItemCode,
                                                                    sFixedAsetCode, "", 0, 0);
                                                            items.Insert();

                                                            #region Pass Value to Inventory Detail - From Dep
                                                            //tbl_scsInventoryTxnDetail oInventoryDetail_From = new tbl_scsInventoryTxnDetail(iFormID, int.Parse(sLineNo), 0, txtTransferCode.Text.Trim(), dtpTransferDate.Value,
                                                            //                            "", "", "", "", "default", "default", txtDepFrom.Tag.ToString(),
                                                            //                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), 0, 1, 0, 0, false);
                                                            //oListInventory.Add(oInventoryDetail_From);
                                                            #endregion

                                                            #region Pass Value to Inventory Detail - To Dep
                                                            //tbl_scsInventoryTxnDetail oInventoryDetail_To = new tbl_scsInventoryTxnDetail(iFormID, int.Parse(sLineNo), 0, txtTransferCode.Text.Trim(), dtpTransferDate.Value,
                                                            //                            "", "", "", "", "default", "default", txtDepTo.Tag.ToString(),
                                                            //                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), 1, 0, 0, 0, false);
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

                                                #region Update Store Stock

                                                foreach (tbl_scsAssetsTransferNote_Detail oUpdatedRecord in
                                                    tbl_scsAssetsTransferNote_Detail.SelectAllByAssetsTransferNote_ID(
                                                        txtTransferCode.Text.Trim()))
                                                {
                                                    decimal dWeightedAverageCostPrice = 0;
                                                    //clsHelpMethods_Local.UpdateStoreStock(iFormID,
                                                    //    detail.AssetTransferNote_ID, detail.AssetTransferNoteDate,
                                                    //    oUpdatedRecord.Item_ID, "0", txtDepFrom.Tag.ToString(), 1, 0, 0,
                                                    //    false, false, false, ref dWeightedAverageCostPrice);
                                                    //clsHelpMethods_Local.UpdateStoreStock(iFormID,
                                                    //    detail.AssetTransferNote_ID, detail.AssetTransferNoteDate,
                                                    //    oUpdatedRecord.Item_ID, "0", txtDepTo.Tag.ToString(), 1, 0, 0,
                                                    //    false, true, false, ref dWeightedAverageCostPrice);

                                                    oUpdatedRecord.WeightedAvgCost = dWeightedAverageCostPrice;
                                                    oUpdatedRecord.Update();
                                                }

                                                #endregion

                                                #region Update Inventory
                                                //tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtTransferCode.Text.Trim(), dtpTransferDate.Value, "",
                                                //    "default", "default", "default", -1, 0,
                                                //    "", "", "", "", false, clsSecurity.UserIDLoged);

                                                //clsHelpMethods.Update_Inventory(oHeader, oListInventory);
                                                #endregion

                                                //Attachments.Insert(txtTransferCode.Text.ToString());
                                                if (detail != null)
                                                    FillDetails(detail.AssetTransferNote_ID);

                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone),
                                                    clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                                else
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("This ID is Empty!!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Assets Transfer Note " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                        #endregion
                    }
                    else
                    {
                        #region Insert
                        if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                            txtTransferCode.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                        if (clsValidate.CheckValidity_TransactionCodeLength(txtTransferCode.Text)) //if (txtTransferCode.Text.Trim().Length > 0)
                        {
                            tbl_scsAssetsTransferNote oATN = tbl_scsAssetsTransferNote.Select(txtTransferCode.Text.Trim());
                            if (oATN == null)
                            {
                           //     List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();

                                #region Header
                                tbl_scsAssetsTransferNote detail = new tbl_scsAssetsTransferNote(txtTransferCode.Text.Trim(), dtpTransferDate.Value, "", txtDepFrom.Tag.ToString().Trim(), txtDepTo.Tag.ToString().Trim(),
                                                     clsSecurity.UserIDLoged, "default", "default", "default", "default", "default",
                                                     clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                     clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                     bHasChecked, bHasApproved, false, false, 0, clsSecurity.CompanyID, clsSecurity.BranchID);
                                detail.Insert();
                                #endregion

                                #region Detail
                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                {
                                    try
                                    {
                                        
                                        string sItemCode = "", sFixedAsetCode = "", sLineNo = "";
                                        #endregion

                                        #region Grid Validation
                                        sLineNo = clsValidate.ValidateGridValue(dgvDetail, "RowCount", row.Index, "0");
                                        sItemCode = clsValidate.ValidateGridValue(dgvDetail, "itemID", row.Index, "default");
                                        sFixedAsetCode = clsValidate.ValidateGridValue(dgvDetail, "assetCode", row.Index, "default");
                                        #endregion

                                        if (sItemCode.Length > 0)
                                        {
                                            tbl_scsAssetsTransferNote_Detail items = new tbl_scsAssetsTransferNote_Detail(int.Parse(sLineNo), txtTransferCode.Text.Trim(),
                                                sItemCode, sFixedAsetCode, "", 0, 0);
                                            items.Insert();

                                            decimal dWeightedAverageCostPrice = 0;
                                        //    clsHelpMethods_Local.UpdateStoreStock(iFormID, detail.AssetTransferNote_ID, detail.AssetTransferNoteDate, sItemCode, "0",txtDepFrom.Tag.ToString(), 1, 0, 0, false, false, false, ref dWeightedAverageCostPrice);
                                        //    clsHelpMethods_Local.UpdateStoreStock(iFormID, detail.AssetTransferNote_ID, detail.AssetTransferNoteDate, sItemCode, "0",txtDepTo.Tag.ToString(), 1, 0, 0, false, true, false, ref dWeightedAverageCostPrice);

                                            items.WeightedAvgCost = dWeightedAverageCostPrice;
                                            items.Update();

                                            #region Pass Value to Inventory Detail - From Dep
                                            //tbl_scsInventoryTxnDetail oInventoryDetail_From = new tbl_scsInventoryTxnDetail(iFormID, int.Parse(sLineNo), 0, txtTransferCode.Text.Trim(), dtpTransferDate.Value,
                                            //                            "", "", "", "", "default", "default", txtDepFrom.Tag.ToString(),
                                            //                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), 0, 1, 0, 0, false);
                                            //oListInventory.Add(oInventoryDetail_From);
                                            #endregion

                                            #region Pass Value to Inventory Detail - To Dep
                                            //tbl_scsInventoryTxnDetail oInventoryDetail_To = new tbl_scsInventoryTxnDetail(iFormID, int.Parse(sLineNo), 0, txtTransferCode.Text.Trim(), dtpTransferDate.Value,
                                            //                            "", "", "", "", "default", "default", txtDepTo.Tag.ToString(),
                                            //                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), 1, 0, 0, 0, false);
                                            //oListInventory.Add(oInventoryDetail_To);
                                            #endregion
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                        SEACCException.Show(ex);
                                    }
                                }
                                #endregion

                                #region Update Inventory
                                //tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtTransferCode.Text.Trim(), dtpTransferDate.Value, "",
                                //    "default", "default", "default", -1, 0,
                                //    "", "", "", "", false, clsSecurity.UserIDLoged);

                                //clsHelpMethods.Update_Inventory(oHeader, oListInventory);
                                #endregion

                                Attachments.Insert(txtTransferCode.Text.ToString());
                                if (detail != null)
                                    FillDetails(detail.AssetTransferNote_ID);

                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("This ID is already added!!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //else
                        //    MessageBox.Show("Assets Transfer Note " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    }
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID,ex);
                    SEACCException.Show(ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }
    

        #region Button Delete
        private void UC_AccAssetTransferNote_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTransferCode.TextLength > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpTransferDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            Cursor = Cursors.WaitCursor;
                            tbl_scsAssetsTransferNote detail = tbl_scsAssetsTransferNote.Select(txtTransferCode.Text.Trim());
                            if (detail != null)
                            {
                                if (!detail.IsDeleted)
                                {
                                    if (!detail.IsInitialisation)
                                    {
                                        if (CheckValidity_Dependencies())
                                        {
                                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " ATN : " + detail.AssetTransferNote_ID), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                            if (msgResult == DialogResult.Yes)
                                            {
                                                detail.DeletedTerminal_ID = clsSecurity.TerminalID;
                                                detail.DeletedUser_ID = clsSecurity.UserIDLoged;
                                                detail.DateDeleted = clsSecurity.getServerDateTime();
                                                detail.IsDeleted = true;
                                                detail.Update();
                                             
                                                #region Rollback Store Stock
                                                foreach (tbl_scsAssetsTransferNote_Detail oUpdatedRecore in tbl_scsAssetsTransferNote_Detail.SelectAllByAssetsTransferNote_ID(txtTransferCode.Text.Trim()))
                                                {
                                                    decimal dWeightedAverageCostPrice = 0;

                                                //    clsHelpMethods_Local.UpdateStoreStock(iFormID, detail.AssetTransferNote_ID, detail.AssetTransferNoteDate, oUpdatedRecore.Item_ID, "0", txtDepFrom.Tag.ToString(), 1, 0, 0, true, false, false, ref dWeightedAverageCostPrice);
                                                 //   clsHelpMethods_Local.UpdateStoreStock(iFormID, detail.AssetTransferNote_ID, detail.AssetTransferNoteDate, oUpdatedRecore.Item_ID, "0", txtDepTo.Tag.ToString(), 1, 0, 0, true, true, false, ref dWeightedAverageCostPrice);

                                                    oUpdatedRecore.WeightedAvgCost = dWeightedAverageCostPrice;
                                                    oUpdatedRecore.Update();
                                                }
                                                #endregion

                                                //clsHelpMethods.Delete_Inventory(iFormID, 0, txtTransferCode.Text.Trim());

                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                ClearFields();
                                            }
                                        }
                                    }
                                    else
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                else
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyDeleted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Button Print
        private void UC_AccAssetTransferNote_SF_printButton_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Clear Field
        private void ClearFields()
        {
            IsUpdate = false;

            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtTransferCode, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtDepFrom, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtDepTo, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtAsset, true);

            txtTransferCode.Tag = null;
            txtDepFrom.Tag = null;
            txtDepTo.Tag = null;
            txtAsset.Tag = null;

            txtDepFrom.Text = "";
            txtDepTo.Text = "";
            txtAsset.Text = "";

            dtpTransferDate.Value = clsSecurity.getServerDateTime();

            //bHasApproved = false;
            //bHasChecked = false;

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtTransferCode.Text = "<Auto Generate>";
            else
                txtTransferCode.Clear();

            if (txtTransferCode.Enabled)
            {
                txtTransferCode.SelectAll();
                txtTransferCode.Focus();
            }

            dgvDetail.Rows.Clear();
            //dt_GLP.Rows.Clear();
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            if (sID.Length > 0)
            {
                ClearFields();
                tbl_scsAssetsTransferNote detail = tbl_scsAssetsTransferNote.Select(sID);
                if (detail != null)
                {
                    //set the update flag and Locked
                    IsUpdate = true;
                    
                    clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtTransferCode, false);
                                       
                    txtDepFrom.Tag = detail.FromStore_ID;
                    txtDepTo.Tag = detail.ToStore_ID;

                    foreach(tbl_scsAssetsTransferNote_Detail oDeatail in tbl_scsAssetsTransferNote_Detail.SelectAll().Where(p=> p.AssetsTransferNote_ID == sID))
                    {
                        txtAsset.Tag = oDeatail.FixedAsset_Code;
                        txtAsset.Text = oDeatail.FixedAsset_Code;
                    }

                    txtTransferCode.Text = detail.AssetTransferNote_ID;
                    txtTransferCode.Tag = detail.AssetTransferNote_ID;
                    
                    dtpTransferDate.Value = detail.AssetTransferNoteDate;
                    txtDepFrom.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(detail.FromStore_ID));
                    txtDepTo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(detail.ToStore_ID));
                    clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtAsset, false);
                                      
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
                    
                    RefreshGrid(detail.AssetTransferNote_ID);

                    Attachments.FillAttachments( sID);
                }
               
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string sATNID)
        {
            int iRow;
            dgvDetail.Rows.Clear();

            tbl_scsAssetsTransferNote oATN = tbl_scsAssetsTransferNote.Select(sATNID);
            if (oATN != null)
            {
                foreach (tbl_scsAssetsTransferNote_Detail detail in tbl_scsAssetsTransferNote_Detail.SelectAll().Where(p => p.AssetsTransferNote_ID == oATN.AssetTransferNote_ID))
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;

                    foreach (DataGridViewRow row in dgvDetail.Rows)
                    {
                        List<tbl_scsFixedAsset> detailBC = tbl_scsFixedAsset.SelectAll().Where(p=> p.FixedAsset_Code == detail.FixedAsset_Code).ToList();

                        dgvDetail["RowCount", iRow].Value = detail.Line_No;
                        dgvDetail["assetCode", iRow].Value = detail.FixedAsset_Code;
                        dgvDetail["barcode", iRow].Value = detailBC.FirstOrDefault().Barcode_ID;
                        dgvDetail["itemID", iRow].Value = detail.Item_ID;
                        dgvDetail["itemName", iRow].Value = clsGenaralName.getName_Item(detail.Item_ID);
                        dgvDetail["itemDes", iRow].Value = clsGenaralName.getDescription_Item(detail.Item_ID);
                    }
                }
            }           
        }
        private void RefreshGridByAsset(string sAssetsCode, string iBarcode)
        {
            try
            {
                int iRow;
                bool dIsAdd = true;
                
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    if (sAssetsCode == clsValidate.ValidateGridValue(dgvDetail, "assetCode", row.Index, "") && iBarcode == clsValidate.ValidateGridValue(dgvDetail, "barcode", row.Index, ""))
                    {
                        dIsAdd = false;
                        break;
                    }                        
                }
                if (dIsAdd)
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;

                    tbl_genItemMaster_Barcode detail = tbl_genItemMaster_Barcode.Select(int.Parse(iBarcode));
                    dgvDetail["RowCount", iRow].Value = iRow;
                    dgvDetail["assetCode", iRow].Value = sAssetsCode;
                    dgvDetail["barcode", iRow].Value = iBarcode;
                    dgvDetail["itemID", iRow].Value = detail.Item_ID;
                    dgvDetail["itemName", iRow].Value = clsGenaralName.getName_Item(detail.Item_ID);
                    dgvDetail["itemDes", iRow].Value = clsGenaralName.getDescription_Item(detail.Item_ID);
                                                            
                    string sQuary = "exec [sp_GetFAFromStore] '" + sAssetsCode + "'";
                    string sFromStoreID = DBHandling.ExecQuery_ReturnString(sQuary);

                    txtDepFrom.Tag = sFromStoreID;
                    txtDepFrom.Text = clsGenaralName.getName_Department(sFromStoreID);

                    clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtAsset, false);

                }
                else
                    MessageBox.Show("This Asset is already added \nCan not add same Asset!!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }

        #endregion
                
        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyValue())
            {
                if (CheckValidity_Stores())
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpTransferDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                        {
                            if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtDepFrom.Tag.ToString(), IsUpdate))
                            {
                                if (CheckValidity_ATNDate())
                                {
                                    bStatus = true;
                                }
                            }
                        }
                    }
                }
            }
            return bStatus;
        }
        private bool CheckValidity_Stores()
        {
            bool bStatus = true;

            if (txtDepFrom.Tag.ToString() == txtDepTo.Tag.ToString())
            {
                bStatus = false;
                MessageBox.Show("From Department and To Department should NOT be same.. ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            return bStatus;
        }
        private bool CheckValidity_EmptyValue()
        {
            bool bStatus = true;

            if (!clsValidate.ValidateTextBox_EmptyValue(txtDepFrom, "From Department"))
                bStatus = false;

            if (!clsValidate.ValidateTextBox_EmptyValue(txtDepTo, "To Department"))
                bStatus = false;

            if (dgvDetail.Rows.Count == 0)
            {
                bStatus = false;
                MessageBox.Show("Please Add one or more Assets..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return bStatus;
        }
        private bool CheckValidity_ATNDate()
        {
            bool bStatus = true;// bNoUpdate = false;

            foreach (tbl_scsAssetsTransferNote_Detail oATNDetail in tbl_scsAssetsTransferNote_Detail.SelectAll().Where(p => p.FixedAsset_Code == txtAsset.Tag.ToString()))
            {
                tbl_scsAssetsTransferNote oATN = tbl_scsAssetsTransferNote.Select(oATNDetail.AssetsTransferNote_ID);
                if (oATN != null)
                {
                    if (oATN.AssetTransferNoteDate.Date == dtpTransferDate.Value.Date)
                    {
                        if (!IsUpdate)
                        {
                            bStatus = false;
                            break;
                        }
                        else
                        {
                            if (txtTransferCode.Tag.ToString() != oATN.AssetTransferNote_ID)
                            {
                                bStatus = false;
                                break;
                            }
                        }
                    }
                }
            }

            if (!bStatus)
                MessageBox.Show("This Asset is already transfered on this Date..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return bStatus;
        }

        private bool CheckValidity_Dependencies()
        {
            bool bStatus = true;

            string sQuary = "SELECT dbo.GetLastATN('" + txtAsset.Tag.ToString() + "')";
            string sLastATNID = DBHandling.ExecQuery_ReturnString(sQuary);

            if (sLastATNID != txtTransferCode.Tag.ToString())
            {
                bStatus = false;
                MessageBox.Show("Can not Update.. \nChanges are allow only for last added ATN from this Fixed Asset", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return bStatus;
        }

        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            //clsCommon.ValidateForeignKey(ref txtDepFrom);
        }
        #endregion

        #region Event Double Click
        private void txtDepFrom_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterStoreDepartment(ref txtDepFrom);
        }

        private void txtDepTo_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterStoreDepartment(ref txtDepTo);
        }

        private void txtAsset_DoubleClick(object sender, EventArgs e)
        {
            //if (txtDepFrom.Tag != null)
            //{
                List<string> lstParameeters = new List<string>();
                frmSearch RowDataSearch = null;

                //lstParameeters.Add(txtDepFrom.Tag.ToString());
                lstParameeters.Add("");

                RowDataSearch = new frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.FixedAssets);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtAsset.Tag = lstResult[0];
                    txtAsset.Text = lstResult[0];

                    if (lstResult.Count > 0)
                        RefreshGridByAsset(lstResult[0], lstResult[1]);
                }
                
            //}
            //else
            //    MessageBox.Show("Please select the From Department before select an Asset", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtTransferCode_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_AssetsTransferNote(ref txtTransferCode);
            if (txtTransferCode.Tag != null)
                FillDetails(txtTransferCode.Tag.ToString());
        }

        #endregion
    }
}