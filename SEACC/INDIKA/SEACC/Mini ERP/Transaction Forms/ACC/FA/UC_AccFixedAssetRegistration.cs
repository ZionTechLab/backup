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
    public partial class UC_AccFixedAssetRegistration : SEACC_Form
    {
        
        public DataTable dtFixedAssets = new DataTable();
 

        #region Form Load
        public UC_AccFixedAssetRegistration(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }

        private void UC_AccFixedAssetRegistration_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, false, false, true, true, false, false, false, false);
            ClearFields();
        }
        #endregion

        #region Btn New
        private void UC_AccFixedAssetRegistration_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Save
        private void UC_AccFixedAssetRegistration_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    tbl_scsDocument_Barcode oBarcode = tbl_scsDocument_Barcode.SelectAllByBarcode_ID(int.Parse(txtBarcodeNo.Tag.ToString())).FirstOrDefault();
                    if (oBarcode != null)
                    {
                        tbl_scsExternalGoodReceivedNote_Detail oGRNDetail = tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(oBarcode.Transaction_ID).Where(p => p.Item_ID == oBarcode.Item_ID).FirstOrDefault();
                        if (oGRNDetail != null)
                        {
                            tbl_scsExternalGoodReceivedNote oGRN = tbl_scsExternalGoodReceivedNote.Select(oGRNDetail.ExternalGoodReceivedNote_ID);
                            if (oGRN != null)
                            {
                                Cursor = Cursors.WaitCursor;

                                #region Update
                                if (IsUpdate)
                                {
                                    tbl_scsFixedAsset oldRecord = tbl_scsFixedAsset.Select(int.Parse(txtBarcodeNo.Tag.ToString()));
                                    if (oldRecord != null)
                                    {
                                        if (!oldRecord.IsDeleted)
                                        {
                                            if (CheckValidity_UpdateATN(oldRecord.FixedAsset_Code))
                                            {
                                                if (clsValidate.CheckValidity_TransactionCodeLength(txtFixedAssetD.Text))
                                                {

                                                    tbl_scsFixedAsset detail = new tbl_scsFixedAsset(
                                                        int.Parse(txtBarcodeNo.Tag.ToString()),
                                                        txtFixedAssetD.Text.ToString(), oldRecord.AssetTransferNote_ID,
                                                        "default", dtpAquisitionDate.Value,
                                                        decimal.Parse(txtLifeTime.Text), decimal.Parse(txtDepRate.Text),
                                                        oldRecord.Cost, oldRecord.TotalAccumulatedDepreciation,
                                                        oldRecord.WriteDownValue, oldRecord.IsDepreciated,
                                                        oldRecord.IsDeleted, clsSecurity.UserIDLoged, "default",
                                                        "default", clsSecurity.TerminalID, "default", "default",
                                                        clsSecurity.getServerDateTime(),
                                                        clsSecurity.getServerDateTime(),
                                                        clsSecurity.getServerDateTime(), oldRecord.LastFinancialYear_ID,
                                                        oldRecord.LastMonth_ID);
                                                    detail.Update();
                                                    
                                                    #region Update ATN

                                                    tbl_scsAssetsTransferNote oldRecordATN =
                                                        tbl_scsAssetsTransferNote.Select(oldRecord
                                                            .AssetTransferNote_ID);
                                                    tbl_scsAssetsTransferNote_Detail oldATNDetails =
                                                        tbl_scsAssetsTransferNote_Detail.Select(0,
                                                            oldRecord.AssetTransferNote_ID);
                                                    if (oldRecordATN != null && oldATNDetails != null)
                                                    {
                                                        #region Update ATN Header

                                                        tbl_scsAssetsTransferNote detailATN =
                                                            new tbl_scsAssetsTransferNote(
                                                                oldRecord.AssetTransferNote_ID, dtpAquisitionDate.Value,
                                                                "", oGRN.Store_ID, clsConfig.sFixedAsset_MainStore,
                                                                oldRecordATN.CreateUser_ID, clsSecurity.UserIDLoged,
                                                                oldRecordATN.CheckedUser_ID,
                                                                oldRecordATN.ApprovedUser_ID,
                                                                oldRecordATN.DeletedUser_ID,
                                                                oldRecordATN.PrintedUser_ID,
                                                                oldRecordATN.CreateTerminal_ID, clsSecurity.TerminalID,
                                                                oldRecordATN.DeletedTerminal_ID,
                                                                oldRecordATN.PrintedTerminal_ID,
                                                                oldRecordATN.DateCreate,
                                                                clsSecurity.getServerDateTime(),
                                                                oldRecordATN.DateChecked, oldRecordATN.DateApproved,
                                                                oldRecord.DateDeleted, oldRecordATN.DatePrinted,
                                                                oldRecordATN.IsChecked, oldRecordATN.IsApproved,
                                                                oldRecord.IsDeleted, oldRecordATN.IsInitialisation,
                                                                oldRecordATN.PrintCount, oldRecordATN.CompanyID,
                                                                oldRecordATN.CompanyBranch_ID);
                                                        detailATN.Update();

                                                        #endregion

                                                        #region Rollback Store Stock

                                                        foreach (tbl_scsAssetsTransferNote_Detail oUpdatedRecore in
                                                            tbl_scsAssetsTransferNote_Detail
                                                                .SelectAllByAssetsTransferNote_ID(oldRecord
                                                                    .AssetTransferNote_ID))
                                                        {
                                                            decimal dWeightedAverageCostPrice = 0;
                                                            //clsHelpMethods_Local.UpdateStoreStock(iFormID,
                                                            //    detail.AssetTransferNote_ID,
                                                            //    detailATN.AssetTransferNoteDate, oUpdatedRecore.Item_ID,
                                                            //    "0", oGRN.Store_ID, 1, 0, 0, true, false, false, ref dWeightedAverageCostPrice);
                                                            //clsHelpMethods_Local.UpdateStoreStock(iFormID,
                                                            //    detail.AssetTransferNote_ID,
                                                            //    detailATN.AssetTransferNoteDate, oUpdatedRecore.Item_ID,
                                                            //    "0", clsConfig.sFixedAsset_MainStore, 1, 0, 0, true,
                                                            //    true, false, ref dWeightedAverageCostPrice);

                                                            oUpdatedRecore.WeightedAvgCost = dWeightedAverageCostPrice;
                                                            oUpdatedRecore.Update();
                                                        }

                                                        #endregion

                                                        #region Delete Old Records

                                                        tbl_scsAssetsTransferNote_Detail
                                                            .DeleteAllByAssetsTransferNote_ID(oldRecord
                                                                .AssetTransferNote_ID);

                                                        #endregion

                                                        #region ATN Detail

                                                        tbl_scsAssetsTransferNote_Detail ATNDetails =
                                                            new tbl_scsAssetsTransferNote_Detail(0,
                                                                oldRecord.AssetTransferNote_ID, lblItemID.Text,
                                                                txtFixedAssetD.Text.ToString(), "", 0, 0);
                                                        ATNDetails.Insert();

                                                        #endregion

                                                        #region Update Store Stock

                                                        foreach (tbl_scsAssetsTransferNote_Detail oUpdatedRecord in
                                                            tbl_scsAssetsTransferNote_Detail
                                                                .SelectAllByAssetsTransferNote_ID(oldRecord
                                                                    .AssetTransferNote_ID))
                                                        {
                                                            decimal dWeightedAverageCostPrice = 0;

                                                            //clsHelpMethods_Local.UpdateStoreStock(iFormID,
                                                            //    detail.AssetTransferNote_ID,
                                                            //    detailATN.AssetTransferNoteDate, oUpdatedRecord.Item_ID,
                                                            //    "0", oGRN.Store_ID, 1, 0, 0, false, false, false, ref dWeightedAverageCostPrice);
                                                            //clsHelpMethods_Local.UpdateStoreStock(iFormID,
                                                            //    detail.AssetTransferNote_ID,
                                                            //    detailATN.AssetTransferNoteDate, oUpdatedRecord.Item_ID,
                                                            //    "0", clsConfig.sFixedAsset_MainStore, 1, 0, 0, false,
                                                            //    true, false, ref dWeightedAverageCostPrice);

                                                            oUpdatedRecord.WeightedAvgCost = dWeightedAverageCostPrice;
                                                            oUpdatedRecord.Update();
                                                        }

                                                        #endregion
                                                    }

                                                    #endregion

                                                    //Attachments.Insert(iFormID, oldRecord.Barcode_ID.ToString());
                                                    //Attachments.Remove(iFormID, oldRecord.Barcode_ID.ToString());

                                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone),
                                                        clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                                                        MessageBoxIcon.Information);
                                                }
                                            }
                                            else
                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyDeleted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                #endregion

                                #region Insert
                                else
                                {
                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                        txtFixedAssetD.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                    if (clsValidate.CheckValidity_TransactionCodeLength(txtFixedAssetD.Text))// if (txtFixedAssetD.Text.Length > 0)
                                    {
                                        #region  Insert Fixed Asset
                                        tbl_scsFixedAsset detail = new tbl_scsFixedAsset(int.Parse(txtBarcodeNo.Tag.ToString()), txtFixedAssetD.Text.ToString(), "default", "default", dtpAquisitionDate.Value, decimal.Parse(txtLifeTime.Text), decimal.Parse(txtDepRate.Text), oGRNDetail.UnitPrice, 0, oGRNDetail.UnitPrice, true,
                                                                   false, clsSecurity.UserIDLoged, "default", "default", clsSecurity.TerminalID, "default", "default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), "default", "default");
                                        detail.Insert();
                                        #endregion

                                        #region Insert ATN
                                        string sATNCode = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.accAssetTransferNote));
                                        tbl_scsAssetsTransferNote detailATN = new tbl_scsAssetsTransferNote(sATNCode, dtpAquisitionDate.Value, "", oGRN.Store_ID, clsConfig.sFixedAsset_MainStore,
                                                                             clsSecurity.UserIDLoged, "default", "default", "default", "default", "default",
                                                                             clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                                             clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                                             false, false, false, true, 0, clsSecurity.CompanyID, clsSecurity.BranchID);
                                        detailATN.Insert();

                                        tbl_scsAssetsTransferNote_Detail ATNDetails = new tbl_scsAssetsTransferNote_Detail(0, sATNCode, lblItemID.Text, txtFixedAssetD.Text.ToString(), "", 0, 0);
                                        ATNDetails.Insert();

                                        detail.AssetTransferNote_ID = sATNCode;
                                        detail.Update();

                                        decimal dWeightedAverageCostPrice = 0;
                                      //  clsHelpMethods_Local.UpdateStoreStock(iFormID, detail.AssetTransferNote_ID, detailATN.AssetTransferNoteDate, lblItemID.Text, "0", oGRN.Store_ID, 1, 0, 0, false, false, false, ref dWeightedAverageCostPrice);
                                     //   clsHelpMethods_Local.UpdateStoreStock(iFormID, detail.AssetTransferNote_ID, detailATN.AssetTransferNoteDate, lblItemID.Text, "0", clsConfig.sFixedAsset_MainStore, 1, 0, 0, false, true, false, ref dWeightedAverageCostPrice);

                                        ATNDetails.WeightedAvgCost = dWeightedAverageCostPrice;
                                        ATNDetails.Update();
                                        #endregion

                                        Attachments.Insert(txtBarcodeNo.Text);
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    //else
                                    //    MessageBox.Show("Asset Code " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    tbl_scsFixedAsset Fdetail = tbl_scsFixedAsset.Select(int.Parse(txtBarcodeNo.Text.ToString()));
                    if (Fdetail != null)
                    {
                        FillDetails(int.Parse(txtBarcodeNo.Tag.ToString()));
                        RefreshGrid();
                        IsUpdate = true;
                    }
                }
            }
        }
        #endregion

        #region Btn Cancel
        private void UC_AccFixedAssetRegistration_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFixedAssetD.Text.Trim().Length > 0)
                {
                    //if (clsMethods_GL.CheckValidity_FinancialYear(dtpDabitNoteDate.Value.Date))
                    //{
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtBarcodeNo.Text != "")
                        {
                            tbl_scsFixedAsset detail = tbl_scsFixedAsset.Select(int.Parse(txtBarcodeNo.Text));
                            if (detail != null)
                            {
                                if (!detail.IsDeleted)
                                {
                                    if (CheckValidity_UpdateATN(detail.FixedAsset_Code))
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, "" + txtFixedAssetD.Text), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                        if (msgResult == DialogResult.Yes)
                                        {
                                            tbl_scsAssetsTransferNote_Detail oATNDetail = tbl_scsAssetsTransferNote_Detail.Select(0, detail.AssetTransferNote_ID);
                                            if (oATNDetail != null)
                                                oATNDetail.Delete();

                                            tbl_scsAssetsTransferNote oATN = tbl_scsAssetsTransferNote.Select(detail.AssetTransferNote_ID);
                                            if (oATN != null)
                                                //if (oATN != null && oATN.IsInitialisation)
                                                //{
                                                //oATN.IsDeleted = true;
                                                //oATN.DateModified = clsSecurity.getServerDateTime();
                                                //oATN.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                //oATN.Update();
                                                oATN.Delete();
                                            //}

                                            //detail.IsDeleted = true;
                                            //detail.DateModified = clsSecurity.getServerDateTime();
                                            //detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                            //detail.Update();  
                                            detail.Delete();

                                            #region Rollback Store Stock
                                            //foreach (tbl_scsAssetsTransferNote_Detail oUpdatedRecore in tbl_scsAssetsTransferNote_Detail.SelectAllByAssetsTransferNote_ID(txtf  txtTransferCode.Text.Trim()))
                                            //{
                                            //    clsHelpMethods_Local.UpdateStoreStock(iFormID, detail.AssetTransferNote_ID, detail.AssetTransferNoteDate, oUpdatedRecore.Item_ID, "0", txtDepFrom.Tag.ToString(), 1, 0, 0, true, false, false);
                                            //    clsHelpMethods_Local.UpdateStoreStock(iFormID, detail.AssetTransferNote_ID, detail.AssetTransferNoteDate, oUpdatedRecore.Item_ID, "0", txtDepTo.Tag.ToString(), 1, 0, 0, true, true, false);
                                            //}
                                            #endregion

                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            ClearFields();
                                            RefreshGrid();
                                        }
                                    }
                                    else
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }//deleted
                                else
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyDeleted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                            else // not found
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ItemNotFound), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        #region Clear Field
        private void ClearFields()
        {
            IsUpdate = false;

            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtFixedAssetD, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtBarcodeNo, true);
            // clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtDepartment, true);

            txtFixedAssetD.Tag = null;
            txtBarcodeNo.Tag = null;
            //   txtDepartment.Tag = null;

            txtBarcodeNo.Text = "";
            // txtDepartment.Text = "";
            txtLifeTime.Text = "0";
            txtDepRate.Text = "0";
            lblSerialNo.Text = "";
            lblItemID.Text = "";
            lblItemName.Text = "";
            lblItemDescription.Text = "";
            lblSupplier.Text = "";

            dtpAquisitionDate.Value = clsSecurity.getServerDateTime();

            //bHasApproved = false;
            //bHasChecked = false;

            #region Button Hide
            //btnChecked.Visible = false;
            //btnApproved.Visible = false;
            //btnPrint.Visible = false;
            //btnUserDetails.Visible = false;
            #endregion

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtFixedAssetD.Text = "<Auto Generate>";
            else
                txtFixedAssetD.Clear();

            if (txtFixedAssetD.Enabled)
            {
                txtFixedAssetD.SelectAll();
                txtFixedAssetD.Focus();
            }

            dtFixedAssets.Rows.Clear();

            RefreshGrid();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                //    sourceFixedAssets.Filter = "";
                dtFixedAssets.Rows.Clear();
                dtFixedAssets.Merge(DBHandling.ExecQuery("exec [dbo].[sp_GetFixedAssets]").Tables[0]);

                // sourceFixedAssets.DataSource = dtFixedAssets;
                dgvDetail.DataSource = dtFixedAssets;
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }

        }
        #endregion

        #region Fill Details
        private void FillDetails(int iID)
        {
            if (iID > 0)
            {
                tbl_scsFixedAsset detail = tbl_scsFixedAsset.Select(iID);
                if (detail != null)
                {
                    //set the update flag and Locked
                    IsUpdate = true;

                    clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtFixedAssetD, false);
                    clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtBarcodeNo, false);

                    txtFixedAssetD.Tag = detail.FixedAsset_Code;
                    txtFixedAssetD.Text = detail.FixedAsset_Code;

                    txtBarcodeNo.Tag = detail.Barcode_ID;
                    txtBarcodeNo.Text = detail.Barcode_ID.ToString();
                    //   txtDepartment.Tag = detail.Store_ID;
                    //  txtDepartment.Text = clsGenaralName.getName_CompanyDepartment(detail.Store_ID);
                    dtpAquisitionDate.Value = detail.Acquisition_date;

                    string[] sLifeTime = detail.LifeTime.ToString().Split('.');
                    txtLifeTime.Text = sLifeTime[0];
                    string[] sDepRate = detail.DepreciationRate.ToString().Split('.');
                    txtDepRate.Text = sDepRate[0];

                    FillDetailsBarcode(iID);

                    //RefreshGrid();                    

                    //Attachments.FillAttachments(iFormID, iID);                    
                }
            }
        }
        private void FillDetailsBarcode(int iID)
        {
            if (iID > 0)
            {
                tbl_genItemMaster_Barcode detail = tbl_genItemMaster_Barcode.Select(iID);
                if (detail != null)
                {
                    lblSerialNo.Text = detail.SerialNo1;
                    lblItemID.Text = detail.Item_ID;
                    lblItemName.Text = clsGenaralName.getName_Item(detail.Item_ID);
                    lblItemDescription.Text = clsGenaralName.getDescription_Item(detail.Item_ID);

                    List<tbl_scsDocument_Barcode> detailBarcode = tbl_scsDocument_Barcode.SelectAllByBarcode_ID(iID).ToList();
                    if (detailBarcode.Count > 0)
                    {
                        tbl_scsExternalGoodReceivedNote detGRN = tbl_scsExternalGoodReceivedNote.Select(detailBarcode.FirstOrDefault().Transaction_ID);
                        lblSupplier.Text = clsGenaralName.getName_Supplier(detGRN.Supplier_ID);
                    }
                }
            }
        }
        #endregion

        #region Event Double Click
        private void txtBarcodeNo_DoubleClick(object sender, EventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();

            List<string> lstResult = RowDataSearch.Show(Search.Barcode);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBarcodeNo.Tag = lstResult[0];
                txtBarcodeNo.Text = lstResult[0];

                lblSerialNo.Text = lstResult[1];
                lblItemID.Text = lstResult[3];
                lblItemName.Text = lstResult[4];
                lblItemDescription.Text = lstResult[5];
                //  sGRNID = lstResult[6];
                lblSupplier.Text = lstResult[9];
                dtpAquisitionDate.Value = DateTime.Parse(lstResult[7]);
            }
        }
        private void txtFixedAssetD_DoubleClick(object sender, EventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            frmSearch RowDataSearch = null;

            lstParameeters.Add("");

            RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.FixedAssets);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBarcodeNo.Tag = lstResult[1];
                txtBarcodeNo.Text = lstResult[1];
            }

            if (txtBarcodeNo.Tag != null)
                FillDetails(int.Parse(txtBarcodeNo.Tag.ToString()));
        }
        //private void txtDepartment_DoubleClick_1(object sender, EventArgs e)
        //{
        //    clsSearch.Search_MasterStoreDepartment(ref txtDepartment);
        //}

        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bIsOk = false;

            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
            {
                //if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtDepartment.Tag.ToString(), IsUpdate))
                //{
                if (CheckValidity_EmptyValue())
                {
                    if (CheckValidity_Rate())
                    {
                        //if (CheckValidity_DepRate())
                        //{
                        bIsOk = true;
                        //}
                    }
                }
                //}
            }
            return bIsOk;
        }
        private bool CheckValidity_EmptyValue()
        {
            bool bStatus = true;

            if (!clsValidate.ValidateTextBox_EmptyValue(txtBarcodeNo, "Barcode No."))
                bStatus = false;

            //if (!clsValidate.ValidateTextBox_EmptyValue(txtDepartment, "Department"))
            //    bStatus = false;

            return bStatus;
        }
        private bool CheckValidity_Rate()
        {
            bool bIsValid = true;
            decimal dLifeTime = decimal.Parse(txtLifeTime.Text.ToString());
            decimal dDepRate = decimal.Parse(txtDepRate.Text.ToString());

            if (dLifeTime <= 0 || dDepRate <= 0)
            {
                bIsValid = false;
                MessageBox.Show("Life Time and Depreciation Rate should be greater than 0....! ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //if (dDepRate <= 0)
            //{
            //    bIsValid = false;
            //    MessageBox.Show("Depreciation Rate should be greater than 0....! ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}            
            return bIsValid;
        }
        private bool CheckValidity_DepRate()
        {
            bool bIsValid = true;
            decimal dDepRate = decimal.Parse(txtDepRate.Text.ToString());
            if (dDepRate > 0)
            {
                bIsValid = true;
            }
            else
            {
                bIsValid = false;
                MessageBox.Show("Depreciation Rate should be greater than 0....! ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bIsValid;
        }
        private bool CheckValidity_UpdateATN(string sAssetCode)
        {
            bool bStatus = true;

            foreach (tbl_scsAssetsTransferNote_Detail oATNDetail in tbl_scsAssetsTransferNote_Detail.SelectAll().Where(p => p.FixedAsset_Code == sAssetCode).ToList())
            {
                tbl_scsAssetsTransferNote oATN = tbl_scsAssetsTransferNote.Select(oATNDetail.AssetsTransferNote_ID);
                if (oATN != null)
                {
                    if (!oATN.IsInitialisation)
                    {
                        bStatus = false;
                        break;
                    }
                }
            }
            return bStatus;
        }
        #endregion

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                string sFixedAssetCode = dgvDetail["fixedAssetCode", e.RowIndex].Value.ToString();
                if (sFixedAssetCode != "" && sFixedAssetCode.Length > 0)
                {
                    int iBarcode = int.Parse(dgvDetail["barcodeNo", e.RowIndex].Value.ToString());
                    FillDetails(iBarcode);
                }
            }
        }

        private void txtLifeTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowInteger(e);
        }

        private void txtDepRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowInteger(e);
        }
    }
}