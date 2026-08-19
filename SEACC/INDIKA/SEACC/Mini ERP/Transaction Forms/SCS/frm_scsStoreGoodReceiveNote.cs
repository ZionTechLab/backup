using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Zion.ERP.Reports.DataSets.SCS;
using Zion.ERP.Reports.DataSets;
using SEACC.DATA.Data.SCS;
using ZION.ERP.Reports.DataSets.SCS;

namespace Digiteq
{
    public partial class frm_scsStoreGoodReceiveNote : SEACC_Form
    {
        
        //to manage update and insert
        //static bool IsUpdate = false;
        bool isDuplicate = false;
        //form manage
        //string sFormConfigCode;
        //   public int iFormID;

        //to keep glob ref no        
        public string glbGRNNo = "", glbGINNo = "";

        //for security handle
        //public bool bNoAccess;
        //public bool bHasChecked;
        //public bool bHasApproved;
        //  DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        //   DateTime glbCheckedDate = clsSecurity.getServerDateTime();

        dts_scsStoreGoodsReceiveNote glb_dtsScsStoreGoodsReceivedNote = new dts_scsStoreGoodsReceiveNote();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();

        InventoryTxnData oData = new InventoryTxnData();
    

        #region Form Load
        public frm_scsStoreGoodReceiveNote(FormName _enmForm)
        {
            //sFormConfigCode = clsAutocode.getFormConfigCode(FormName.sasGRNTradingStock);
            //iFormID = clsSecurity.getFormID(FormName.sasGRNTradingStock);
            //if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            //{
            //    bNoAccess = true;
            //}
            //InitializeComponent();         

            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }
        private void frmCustomerOrder_Load(object sender, EventArgs e)
        {
            ////add data to the datagrid and format
            //clsFormatter.setFormatForm(this, clsHelpMethods_Local.getFormName(iFormID), 4, iFormID);

            SetVisibility_ActionButons(true, true, true, true, false, true, true, true, true);
            clsFill.Fill_ItemPrices(ref cmbItemPrice);
            CusDataGridViewFormat();
            ClearFields();

            if (glbGRNNo.Length > 0)
                FillDetails(glbGRNNo);

            //if the SRN fired by GIN
            if (glbGINNo.Length > 0)
            {
                txtGinID.Text = glbGINNo;
                FillDetailsFromGIN(txtGinID.Text.Trim());
            }

        }
        #endregion

        #region Btn New
        private void frm_scsStoreGoodReceiveNote_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
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
                        clsHelpMethods_Local.Grid_LineNoChange(dgvDetail);
                    }
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region Btn Save
        private void frm_scsStoreGoodReceiveNote_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (CheckNumberValidity())
                {
                    if (clsValidate.CheckGridCountValidity(dgvDetail.RowCount, iFormID))
                    {
                        if (CheckJobNoValidity_Emptyfield())
                        {
                            if (CheckValidity_Customer())
                            {
                                if (clsMethods_GL.CheckValidity_FinancialYear(dtpGRNDate.Value.Date))
                                {
                                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                                    {
                                        if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtLocationID.Tag.ToString(), IsUpdate))
                                        {
                                            if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreID.Tag.ToString(), IsUpdate))
                                            {
                                                try
                                                {
                                                    Cursor = Cursors.WaitCursor;
                                                    ValidateEmptyForeignKey();

                                                    if (IsUpdate)  //update records
                                                    {
                                                        #region Update Code
                                                        tbl_scsStoreGoodReceiveNote oldRecord = tbl_scsStoreGoodReceiveNote.Select(txtGoodreceivedNoteID.Text.Trim());
                                                        if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                                                        {
                                                            //if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted && !oldRecord.IsChecked)
                                                            if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                                                            {
                                                                if (!oldRecord.IsChecked ||
                                                                    (oldRecord.IsChecked &&
                                                                     clsSecurity.PermissionToApproved(
                                                                         clsSecurity.UserIDLoged, iFormID)))
                                                                {
                                                                    if (clsValidate.CheckValidity_TransactionCodeLength(txtGoodreceivedNoteID.Text))
                                                                    {
                                                                    //    List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();

                                                                        #region Rollback Store Stock

                                                                        foreach (
                                                                            tbl_scsStoreGoodReceiveNote_Detail
                                                                                oUpdatedRecord in
                                                                            tbl_scsStoreGoodReceiveNote_Detail
                                                                                .SelectAllByStoreGoodReceiveNote_ID(
                                                                                    txtGoodreceivedNoteID.Text.Trim()))
                                                                        {
                                                                            decimal dWeightedAverageCostPrice = 0;
                                                                            //clsHelpMethods_Local.UpdateStoreStock(
                                                                            //    iFormID,
                                                                            //    oUpdatedRecord.StoreGoodReceiveNote_ID,
                                                                            //    oldRecord.StoreGoodReceiveNoteDate,
                                                                            //    oUpdatedRecord.Item_ID, "0",
                                                                            //    txtStoreID.Tag.ToString(),
                                                                            //    oUpdatedRecord.Qty,
                                                                            //    oUpdatedRecord.Weight,
                                                                            //    oUpdatedRecord.TotalAmount, true, true,
                                                                            //    false, ref dWeightedAverageCostPrice);
                                                                            //   clsHelpMethods_Local.RollBackFifo_Stock(iFormID, oUpdatedRecord.StoreGoodReceiveNote_ID);
                                                                            oUpdatedRecord.WeightedAvgCost = clsProcessMethods.GetItemWeightedAvarageCostPrice(oUpdatedRecord.Item_ID);
                                                                            oUpdatedRecord.Update();
                                                                        }

                                                                        #endregion

                                                                        #region Delete old Items

                                                                        List<tbl_scsStoreGoodReceiveNote_Detail>
                                                                            oldGRNDetails =
                                                                                tbl_scsStoreGoodReceiveNote_Detail
                                                                                    .SelectAllByStoreGoodReceiveNote_ID(
                                                                                        oldRecord
                                                                                            .StoreGoodReceiveNote_ID);
                                                                        foreach (tbl_scsStoreGoodReceiveNote_Detail
                                                                            oldGRNDetail in oldGRNDetails)
                                                                        {
                                                                            #region Update GIN Status

                                                                            string sGinID =
                                                                                clsHelpMethods_Local
                                                                                    .GetSelectAreaNoteID(
                                                                                        oldGRNDetail.FromSelectArea_ID,
                                                                                        oldGRNDetail
                                                                                            .DepartmentGoodIssueNote_ID,
                                                                                        oldGRNDetail
                                                                                            .SectionGoodIssueNote_ID,
                                                                                        oldGRNDetail
                                                                                            .StoreGoodIssueNote_ID);
                                                                            if (clsAutocode.getSelectAreaCode(
                                                                                    SelectArea.Department) ==
                                                                                oldGRNDetail.FromSelectArea_ID)
                                                                            {
                                                                                //Pls Do
                                                                            }
                                                                            else if (clsAutocode.getSelectAreaCode(
                                                                                         SelectArea.Section) ==
                                                                                     oldGRNDetail.FromSelectArea_ID)
                                                                            {
                                                                                tbl_scsSectionGoodIssueNote_Detail GIN =
                                                                                    tbl_scsSectionGoodIssueNote_Detail
                                                                                        .Select(sGinID,
                                                                                            oldGRNDetail.Item_ID,
                                                                                            oldGRNDetail
                                                                                                .ItemSubCategory_ID,
                                                                                            oldGRNDetail
                                                                                                .ItemSubCategory2_ID,
                                                                                            oldGRNDetail.ItemSerialNo,
                                                                                            oldGRNDetail.ItemSerialNo2);
                                                                                if (GIN != null)
                                                                                {
                                                                                    GIN.QtySettle -= oldGRNDetail.Qty;
                                                                                    GIN.WeightSettle -=
                                                                                        oldGRNDetail.Weight;
                                                                                    GIN.Update();
                                                                                    clsProcessMethods
                                                                                        .SetSettle_SectionGIN(sGinID);
                                                                                }
                                                                            }
                                                                            else if (clsAutocode.getSelectAreaCode(
                                                                                         SelectArea.Store) ==
                                                                                     oldGRNDetail.FromSelectArea_ID)
                                                                            {
                                                                                List<tbl_scsStoreGoodIssueNote_Detail>
                                                                                    GINDetails =
                                                                                        tbl_scsStoreGoodIssueNote_Detail
                                                                                            .SelectAllByStoreGoodIssueNote_ID(
                                                                                                sGinID).Where(p =>
                                                                                                p.Item_ID ==
                                                                                                oldGRNDetail.Item_ID)
                                                                                            .ToList();
                                                                                foreach (
                                                                                    tbl_scsStoreGoodIssueNote_Detail
                                                                                        details in GINDetails)
                                                                                {
                                                                                    details.QtySettle -=
                                                                                        oldGRNDetail.Qty;
                                                                                    details.WeightSettle -=
                                                                                        oldGRNDetail.Weight;
                                                                                    details.Update();
                                                                                    clsProcessMethods
                                                                                        .SetSettle_StoreGIN(sGinID);
                                                                                }
                                                                            }

                                                                            #endregion

                                                                            oldGRNDetail.Delete();
                                                                        }

                                                                        #endregion

                                                                        #region Update Items

                                                                        foreach (DataGridViewRow row in dgvDetail.Rows)
                                                                        {
                                                                            try
                                                                            {
                                                                                #region Initialize Variables and Set Values
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
                                                                                    dUnitPrice = 0,
                                                                                    dWeightPrice = 0,
                                                                                    dTotalAmount = 0;
                                                                                int iLineNo = 0;

                                                                                iLineNo = clsValidate.ValidateGridValue(
                                                                                    dgvDetail, "LineNo", row.Index,
                                                                                    int.Parse("0"));
                                                                                sItemCode = clsValidate
                                                                                    .ValidateGridValue(dgvDetail,
                                                                                        "ItemCode", row.Index, "");
                                                                                sJobCode =
                                                                                    clsValidate.ValidateGridValue(
                                                                                        dgvDetail, "JobCode", row.Index,
                                                                                        "default");
                                                                                sUom = clsValidate.ValidateGridTag(
                                                                                    dgvDetail, "UOM", row.Index,
                                                                                    "default");
                                                                                dWeight = clsValidate.ValidateGridValue(
                                                                                    dgvDetail, "Weight", row.Index,
                                                                                    decimal.Parse("0.00"));
                                                                                dQuantity =
                                                                                    clsValidate.ValidateGridValue(
                                                                                        dgvDetail, "Quantity",
                                                                                        row.Index,
                                                                                        decimal.Parse("0.00"));
                                                                                sSelectArea_ID =
                                                                                    clsValidate.ValidateGridValue(
                                                                                        dgvDetail, "SelectArea_ID",
                                                                                        row.Index, "");
                                                                                sDepartment_ID =
                                                                                    clsValidate.ValidateGridValue(
                                                                                        dgvDetail, "Department_ID",
                                                                                        row.Index, "");
                                                                                sSection_ID =
                                                                                    clsValidate.ValidateGridValue(
                                                                                        dgvDetail, "Section_ID",
                                                                                        row.Index, "");
                                                                                sStore_ID = clsValidate
                                                                                    .ValidateGridValue(dgvDetail,
                                                                                        "Store_ID", row.Index, "");
                                                                                sDepartmentNote_ID =
                                                                                    clsValidate.ValidateGridValue(
                                                                                        dgvDetail, "DepartmentNote_ID",
                                                                                        row.Index, "");
                                                                                sSectionNote_ID =
                                                                                    clsValidate.ValidateGridValue(
                                                                                        dgvDetail, "SectionNote_ID",
                                                                                        row.Index, "");
                                                                                sStoreNote_ID =
                                                                                    clsValidate.ValidateGridValue(
                                                                                        dgvDetail, "StoreNote_ID",
                                                                                        row.Index, "");
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
                                                                                dUnitPrice =
                                                                                    clsValidate.ValidateGridValue(
                                                                                        dgvDetail, "ItemUnitPrice",
                                                                                        row.Index,
                                                                                        decimal.Parse("0.00"));
                                                                                dTotalAmount =
                                                                                    clsValidate.ValidateGridValue(
                                                                                        dgvDetail, "ItemTotalValue",
                                                                                        row.Index,
                                                                                        decimal.Parse("0.00")); 
                                                                                #endregion

                                                                                if (sItemCode.Length > 0)
                                                                                {
                                                                                    tbl_scsStoreGoodReceiveNote_Detail
                                                                                        items =
                                                                                            new
                                                                                                tbl_scsStoreGoodReceiveNote_Detail(
                                                                                                    iLineNo,
                                                                                                    txtGoodreceivedNoteID
                                                                                                        .Text.Trim(),
                                                                                                    sItemCode,
                                                                                                    sItemSubCategoryID1,
                                                                                                    sItemSubCategoryID2,
                                                                                                    sItemSerialNo1,
                                                                                                    sItemSerialNo2,
                                                                                                    sJobCode,
                                                                                                    sSelectArea_ID,
                                                                                                    sDepartment_ID,
                                                                                                    sSection_ID,
                                                                                                    sStore_ID,
                                                                                                    txtLocationID.Tag
                                                                                                        .ToString(),
                                                                                                    sDepartmentNote_ID,
                                                                                                    sSectionNote_ID,
                                                                                                    sStoreNote_ID, sUom,
                                                                                                    dQuantity, 0,
                                                                                                    dWeight, 0, 0, 0,
                                                                                                    "", false,
                                                                                                    dUnitPrice,
                                                                                                    dWeightPrice,
                                                                                                    dTotalAmount, clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemCode));
                                                                                    items.Insert();

                                                                                    //Update Store Stock                                                           
                                                                                    //clsHelpMethods_Local.UpdateOrInsertStoreStock(clsConfig.bStockValidateQty_iGRN, clsConfig.bStockValidateWeight_iGRN, sItemCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2,
                                                                                    //   sJobCode, txtLocationID.Tag.ToString(), dQuantity, dWeight, 0, 0, false, true, true);

                                                                                    #region Update GIN Status

                                                                                    string sGinID =
                                                                                        clsHelpMethods_Local
                                                                                            .GetSelectAreaNoteID(
                                                                                                sSelectArea_ID,
                                                                                                sDepartmentNote_ID,
                                                                                                sSectionNote_ID,
                                                                                                sStoreNote_ID);
                                                                                    if (clsAutocode.getSelectAreaCode(
                                                                                            SelectArea.Department) ==
                                                                                        sSelectArea_ID)
                                                                                    {
                                                                                        //Pls Do
                                                                                    }
                                                                                    else if (clsAutocode
                                                                                                 .getSelectAreaCode(
                                                                                                     SelectArea
                                                                                                         .Section) ==
                                                                                             sSelectArea_ID)
                                                                                    {
                                                                                        tbl_scsSectionGoodIssueNote_Detail
                                                                                            GIN =
                                                                                                tbl_scsSectionGoodIssueNote_Detail
                                                                                                    .Select(sGinID,
                                                                                                        sItemCode,
                                                                                                        sItemSubCategoryID1,
                                                                                                        sItemSubCategoryID2,
                                                                                                        sItemSerialNo1,
                                                                                                        sItemSerialNo2);
                                                                                        if (GIN != null)
                                                                                        {
                                                                                            GIN.QtySettle += dQuantity;
                                                                                            GIN.WeightSettle += dWeight;
                                                                                            GIN.Update();
                                                                                            clsProcessMethods
                                                                                                .SetSettle_SectionGIN(
                                                                                                    sGinID);
                                                                                        }
                                                                                    }
                                                                                    else if (clsAutocode
                                                                                                 .getSelectAreaCode(
                                                                                                     SelectArea
                                                                                                         .Store) ==
                                                                                             sSelectArea_ID)
                                                                                    {
                                                                                        foreach (
                                                                                            tbl_scsStoreGoodIssueNote_Detail
                                                                                                GIN in
                                                                                            tbl_scsStoreGoodIssueNote_Detail
                                                                                                .SelectAllByStoreGoodIssueNote_ID(
                                                                                                    sGinID).Where(p =>
                                                                                                    p.Item_ID ==
                                                                                                    sItemCode))
                                                                                        {
                                                                                            GIN.QtySettle += dQuantity;
                                                                                            GIN.WeightSettle += dWeight;
                                                                                            GIN.Update();
                                                                                            clsProcessMethods
                                                                                                .SetSettle_StoreGIN(
                                                                                                    sGinID);
                                                                                        }
                                                                                    }

                                                                                    #endregion

                                                                                    #region Pass Value to Inventory Detail
                                                                                    //tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, iLineNo, 0, txtGoodreceivedNoteID.Text.Trim(), dtpGRNDate.Value,
                                                                                    //                            "", "", "", "", "default", "default", txtStoreID.Tag.ToString(),
                                                                                    //                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), dQuantity, 0, dUnitPrice, 0, false);
                                                                                    //oListInventory.Add(oInventoryDetail);
                                                                                    #endregion
                                                                                }
                                                                            }
                                                                            catch (Exception ex)
                                                                            {
                                                                                clsValidate.WriteErrorLog("", iFormID,
                                                                                    ex);
                                                                                SEACCException.Show(ex);
                                                                            }
                                                                        }

                                                                        #endregion

                                                                        #region Update GRN Header

                                                                        tbl_scsStoreGoodReceiveNote detail =
                                                                            new tbl_scsStoreGoodReceiveNote(
                                                                                txtGoodreceivedNoteID.Text.Trim(),
                                                                                dtpGRNDate.Value, txtRemark.Text.Trim(),
                                                                                oldRecord.Job_ID, getSelectAriaID(),
                                                                                txtDepartmentID.Tag.ToString(),
                                                                                txtSectionID.Tag.ToString(),
                                                                                txtStoreID.Tag.ToString(),
                                                                                txtLocationID.Tag.ToString(),
                                                                                getDepartmentGIN(), getSectionGIN(),
                                                                                getStoreGIN(),
                                                                                txtOrderRefNo.Tag.ToString(),
                                                                                oldRecord.CreateUser_ID,
                                                                                clsSecurity.UserIDLoged,
                                                                                oldRecord.CheckedUser_ID,
                                                                                oldRecord.ApprovedUser_ID,
                                                                                oldRecord.DateCreate,
                                                                                clsSecurity.getServerDateTime(),
                                                                                oldRecord.DateChecked,
                                                                                oldRecord.DateApproved,
                                                                                oldRecord.IsChecked,
                                                                                oldRecord.IsApproved,
                                                                                oldRecord.IsFinished,
                                                                                oldRecord.IsDeleted, oldRecord.IsLocked,
                                                                                oldRecord.PrintCount,
                                                                                ((ComboBoxItem)cmbItemPrice
                                                                                    .SelectedItem).Value,
                                                                                oldRecord.CompanyID,
                                                                                oldRecord.CompanyBranch_ID);
                                                                        detail.Update();

                                                                        #endregion

                                                                        #region Update Store Stock

                                                                        foreach (
                                                                            tbl_scsStoreGoodReceiveNote_Detail
                                                                                oUpdatedRecord in
                                                                            tbl_scsStoreGoodReceiveNote_Detail
                                                                                .SelectAllByStoreGoodReceiveNote_ID(
                                                                                    txtGoodreceivedNoteID.Text.Trim()))
                                                                        {
                                                                            decimal dWeightedAverageCostPrice = 0;
                                                                            //clsHelpMethods_Local.UpdateStoreStock(
                                                                            //    iFormID, detail.StoreGoodReceiveNote_ID,
                                                                            //    detail.StoreGoodReceiveNoteDate,
                                                                            //    oUpdatedRecord.Item_ID, "0",
                                                                            //    txtStoreID.Tag.ToString(),
                                                                            //    oUpdatedRecord.Qty,
                                                                            //    oUpdatedRecord.Weight,
                                                                            //    oUpdatedRecord.TotalAmount, false, true,
                                                                            //    false, ref dWeightedAverageCostPrice);
                                                                            //    clsHelpMethods_Local.UpdateFifo_Stock(iFormID, detail.StoreGoodReceiveNote_ID, detail.StoreGoodReceiveNoteDate, txtStoreID.Tag.ToString(), oUpdatedRecord.Item_ID, oUpdatedRecord.ItemSerialNo, oUpdatedRecord.Qty, oUpdatedRecord.UnitPrice, true);
                                                                        }

                                                                        #endregion

                                                                        //Attachments.Remove(iFormID, oldRecord.StoreGoodIssueNote_ID);
                                                                        //Attachments.Insert(iFormID, oldRecord.StoreGoodIssueNote_ID);

                                                                        #region Pass Values to Inventory Header and Update Inventory
                                                                        //tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtGoodreceivedNoteID.Text.Trim(), dtpGRNDate.Value, txtRemark.Text.Trim(),
                                                                        //        "default", "default", "default", -1, 0,
                                                                        //        "", "", "", "", false, clsSecurity.UserIDLoged);

                                                                        //clsHelpMethods.Update_Inventory(oHeader, oListInventory);

                                                                        var responce = oData.Update_InventoryTxn(iFormID, txtGoodreceivedNoteID.Text.Trim());
                                                                        if (!responce.IsSuccess)
                                                                        {
                                                                            clsValidate.WriteErrorLog(txtGoodreceivedNoteID.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
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
                                                        //MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordUpdateIsBlock), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        #endregion
                                                    }
                                                    else  //insert records
                                                    {
                                                        #region Insert
                                                        //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.gem.ToString())
                                                        //    txtGoodreceivedNoteID.Text = clsAutocode.getAutoGeneratedCode_FromBranch_iGRN(txtLocationID.Tag.ToString().Trim(), txtStoreID.Tag.ToString().Trim());
                                                        //else
                                                        {
                                                            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                                                txtGoodreceivedNoteID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);
                                                        }

                                                        if (clsValidate.CheckValidity_TransactionCodeLength(txtGoodreceivedNoteID.Text)) //if (txtGoodreceivedNoteID.TextLength > 0)
                                                        {
                                                         //   List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();

                                                            //create order ref number
                                                            if (txtOrderRefNo.Tag == null || txtOrderRefNo.Tag.ToString() == "default")
                                                            {
                                                                txtOrderRefNo.Tag = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.zIssuedRefNo));
                                                                tbl_zIssuedRefNo orf = new tbl_zIssuedRefNo(txtOrderRefNo.Tag.ToString(), txtOrderRefNo.Text != "" ? txtOrderRefNo.Text.Trim() : "-");
                                                                orf.Insert();
                                                            }

                                                            //GRN Header
                                                            #region Header
                                                            tbl_scsStoreGoodReceiveNote detail = new tbl_scsStoreGoodReceiveNote(txtGoodreceivedNoteID.Text.Trim(), dtpGRNDate.Value, txtRemark.Text.Trim(), "default", getSelectAriaID(), txtDepartmentID.Tag.ToString(), txtSectionID.Tag.ToString(),
                                                                                                            txtStoreID.Tag.ToString(), txtLocationID.Tag.ToString(), getDepartmentGIN(), getSectionGIN(), getStoreGIN(), txtOrderRefNo.Tag.ToString(), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                                                                            glbCheckedDate, glbApprovedDate, bHasChecked, bHasApproved, false, false, false, 0, ((ComboBoxItem)cmbItemPrice.SelectedItem).Value, clsSecurity.CompanyID, clsSecurity.BranchID);
                                                            detail.Insert();
                                                            #endregion

                                                            //GRN Detail                                
                                                            #region Details Grid
                                                            foreach (DataGridViewRow row in dgvDetail.Rows)
                                                            {
                                                                try
                                                                {
                                                                    #region Intialize Variables and Set Grid Values
                                                                    string sItemCode = "", sUom = "default", sJobCode = "", sSelectArea_ID = "", sDepartment_ID = "",
                                                                                                                                    sSection_ID = "", sStore_ID = "", sDepartmentNote_ID = "", sSectionNote_ID = "", sStoreNote_ID = "", sItemSubCategoryID1 = "", sItemSubCategoryID2 = "", sItemSerialNo1 = "", sItemSerialNo2 = "", sRemarks = "";
                                                                    decimal dWeight = 0, dQuantity = 0, dUnitPrice = 0, dWeightPrice = 0, dTotalAmount = 0;
                                                                    int iLineNo = 0;

                                                                    iLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, int.Parse("0"));
                                                                    sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                                                    sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
                                                                    sUom = clsValidate.ValidateGridTag(dgvDetail, "UOM", row.Index, "default");
                                                                    dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                                                    dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                                                    sSelectArea_ID = clsValidate.ValidateGridValue(dgvDetail, "SelectArea_ID", row.Index, "");
                                                                    sDepartment_ID = clsValidate.ValidateGridValue(dgvDetail, "Department_ID", row.Index, "");
                                                                    sSection_ID = clsValidate.ValidateGridValue(dgvDetail, "Section_ID", row.Index, "");
                                                                    sStore_ID = clsValidate.ValidateGridValue(dgvDetail, "Store_ID", row.Index, "");
                                                                    sDepartmentNote_ID = clsValidate.ValidateGridValue(dgvDetail, "DepartmentNote_ID", row.Index, "");
                                                                    sSectionNote_ID = clsValidate.ValidateGridValue(dgvDetail, "SectionNote_ID", row.Index, "");
                                                                    sStoreNote_ID = clsValidate.ValidateGridValue(dgvDetail, "StoreNote_ID", row.Index, "");
                                                                    sItemSubCategoryID1 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                                                                    sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                                                    sItemSerialNo1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                                                                    sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                                                    dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "ItemUnitPrice", row.Index, decimal.Parse("0.00"));
                                                                    //dWeight = clsValidate.ValidateGridValue(dgvDetail, "ItemUnitPrice", row.Index, decimal.Parse("0.00"));
                                                                    dTotalAmount = clsValidate.ValidateGridValue(dgvDetail, "ItemTotalValue", row.Index, decimal.Parse("0.00"));
                                                                    sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                                                                    #endregion

                                                                    if (sItemCode.Length > 0)
                                                                    {
                                                                        tbl_scsStoreGoodReceiveNote_Detail items = new tbl_scsStoreGoodReceiveNote_Detail(iLineNo, txtGoodreceivedNoteID.Text.Trim(), sItemCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, sJobCode, sSelectArea_ID,
                                                                           sDepartment_ID, sSection_ID, sStore_ID, txtLocationID.Tag.ToString(), sDepartmentNote_ID, sSectionNote_ID, sStoreNote_ID, sUom, dQuantity, 0, dWeight, 0, 0, 0, sRemarks, false, dUnitPrice, dWeightPrice, dTotalAmount, clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemCode));
                                                                        items.Insert();

                                                                        #region Update Store Stock
                                                                        decimal dWeightedAverageCostPrice = 0;
                                                                    //    clsHelpMethods_Local.UpdateStoreStock(iFormID, detail.StoreGoodReceiveNote_ID, detail.StoreGoodReceiveNoteDate, sItemCode, "0", txtLocationID.Tag.ToString(), dQuantity, dWeight, items.TotalAmount, false, true, false, ref dWeightedAverageCostPrice);
                                                                        //    clsHelpMethods_Local.UpdateFifo_Stock(iFormID, detail.StoreGoodReceiveNote_ID, detail.StoreGoodReceiveNoteDate, detail.ToStore_ID, items.Item_ID, items.ItemSerialNo, items.Qty, items.UnitPrice, true);
                                                                      
                                                                        #endregion

                                                                        //update GIN 
                                                                        #region Update GIN Status
                                                                        string sGinID = clsHelpMethods_Local.GetSelectAreaNoteID(sSelectArea_ID, sDepartmentNote_ID, sSectionNote_ID, sStoreNote_ID);
                                                                        if (clsAutocode.getSelectAreaCode(SelectArea.Department) == sSelectArea_ID)
                                                                        {
                                                                            //Pls Do
                                                                        }
                                                                        else if (clsAutocode.getSelectAreaCode(SelectArea.Section) == sSelectArea_ID)
                                                                        {
                                                                            tbl_scsSectionGoodIssueNote_Detail GIN = tbl_scsSectionGoodIssueNote_Detail.Select(sGinID, sItemCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2);
                                                                            if (GIN != null)
                                                                            {
                                                                                GIN.QtySettle += dQuantity;
                                                                                GIN.WeightSettle += dWeight;
                                                                                GIN.Update();
                                                                                clsProcessMethods.SetSettle_SectionGIN(sGinID);
                                                                            }
                                                                        }
                                                                        else if (clsAutocode.getSelectAreaCode(SelectArea.Store) == sSelectArea_ID)
                                                                        {
                                                                            foreach (tbl_scsStoreGoodIssueNote_Detail GIN in tbl_scsStoreGoodIssueNote_Detail.SelectAllByStoreGoodIssueNote_ID(sGinID).Where(p => p.Item_ID == sItemCode))
                                                                            {
                                                                                GIN.QtySettle += dQuantity;
                                                                                GIN.WeightSettle += dWeight;
                                                                                GIN.Update();
                                                                                clsProcessMethods.SetSettle_StoreGIN(sGinID);
                                                                            }
                                                                        }
                                                                        #endregion

                                                                        #region Pass Value to Inventory Detail
                                                                        //tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, iLineNo, 0, txtGoodreceivedNoteID.Text.Trim(), dtpGRNDate.Value,
                                                                        //                            "", "", "", "", "default", "default", txtStoreID.Tag.ToString(),
                                                                        //                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), dQuantity, 0, dUnitPrice, 0, false);
                                                                        //oListInventory.Add(oInventoryDetail);
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

                                                            Attachments.Insert(txtGoodreceivedNoteID.Text.ToString());

                                                            #region Pass Values to Inventory Header and Update Inventory
                                                            //tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtGoodreceivedNoteID.Text.Trim(), dtpGRNDate.Value, txtRemark.Text.Trim(),
                                                            //        "default", "default", "default", -1, 0,
                                                            //        "", "", "", "", false, clsSecurity.UserIDLoged);

                                                            //clsHelpMethods.Update_Inventory(oHeader, oListInventory);
                                                            var responce = oData.Update_InventoryTxn(iFormID, txtGoodreceivedNoteID.Text.Trim());
                                                            if (!responce.IsSuccess)
                                                            {
                                                                clsValidate.WriteErrorLog(txtGoodreceivedNoteID.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
                                                            }



                                                            #endregion

                                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        }
                                                        //else
                                                        //{
                                                        //    MessageBox.Show("Good Receive Note " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        //}
                                                        #endregion
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
                                                    tbl_scsStoreGoodReceiveNote oldRecord = tbl_scsStoreGoodReceiveNote.Select(txtGoodreceivedNoteID.Text.Trim());
                                                    if (oldRecord != null)
                                                        FillDetails(txtGoodreceivedNoteID.Text.Trim());
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
        #endregion

        #region Btn Print
        private void frm_scsStoreGoodReceiveNote_SF_printButton_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_scsStoreGoodReceiveNote_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region Print Method
        private void Print(bool bIsDraft)
        {
            try
            {
                string sDuplicateCopy = "";
                if (txtGoodreceivedNoteID.Text.Trim().Length > 0 && txtGoodreceivedNoteID.Text.Trim() != "<Auto Generate>")
                {
                    #region Old Method
                    //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.gem.ToString())
                    //{
                    //    #region Gem Only
                    //    try
                    //    {
                    //        Cursor = Cursors.WaitCursor;
                    //        glb_dtsScsStoreGoodsReceivedNote.dt_scsStoreGoodsReceiveNote.Clear();
                    //        glb_dtsScsStoreGoodsReceivedNote.dt_scsStoreGoodsReceiveNote_Detail.Clear();

                    //        tbl_scsStoreGoodReceiveNote oGRN = tbl_scsStoreGoodReceiveNote.Select(txtGoodreceivedNoteID.Text.Trim());
                    //        string sCreateUserAndDate = "", sApprovedUserAndDate = "", sCheckedUserAndDate = "";
                    //        if (oGRN != null && oGRN.StoreGoodReceiveNote_ID != "default")
                    //        {
                    //            string sFromLocationID = "", sFromLocationName = "";
                    //            clsHelpMethods_Local.getLocationNameAndID_FromDeptSecStore(oGRN.FromDepartment_ID, oGRN.FromSection_ID, oGRN.FromStore_ID, ref sFromLocationID, ref sFromLocationName);
                    //            sCreateUserAndDate = clsGenaralName.getName_User(oGRN.CreateUser_ID) + " - " + clsFormatter.FormatDate_Short(oGRN.DateCreate);
                    //            sApprovedUserAndDate = clsGenaralName.getName_User(oGRN.ApprovedUser_ID) + " - " + clsFormatter.FormatDate_Short(oGRN.DateApproved);
                    //            sCheckedUserAndDate = clsGenaralName.getName_User(oGRN.CheckedUser_ID) + " - " + clsFormatter.FormatDate_Short(oGRN.DateChecked);
                    //            if (oGRN.PrintCount > 0)
                    //                isDuplicate = true;
                    //            oGRN.PrintCount++;

                    //            glb_dtsScsStoreGoodsReceivedNote.dt_scsStoreGoodsReceiveNote.Adddt_scsStoreGoodsReceiveNoteRow(oGRN.StoreGoodReceiveNote_ID, oGRN.StoreGoodReceiveNoteDate,
                    //                clsGenaralName.getName_Store(oGRN.ToStore_ID), sFromLocationName, oGRN.IsDeleted, oGRN.DateCreate, oGRN.Remark);

                    //            foreach (tbl_scsStoreGoodReceiveNote_Detail detail in tbl_scsStoreGoodReceiveNote_Detail.SelectAllByStoreGoodReceiveNote_ID(oGRN.StoreGoodReceiveNote_ID))
                    //            {
                    //                string sGemInfor = "", sMetalInfor = "", sRefNo = "", sItemType = "", sItemName = "", sToStoreName = "";// sItemBrandModel = "";
                    //                decimal dSellingPrice = 0;// dQty = 0;
                    //                tbl_genItemMaster_Gem oItem = tbl_genItemMaster_Gem.Select(detail.Item_ID);
                    //                if (oItem != null && oItem.Item_ID != "default")
                    //                {
                    //                    sGemInfor = oItem.GemDetail;
                    //                    sMetalInfor = oItem.MetalDetail;
                    //                    sRefNo = oItem.RefNo;
                    //                    sItemType = clsGenaralName.getName_ItemType(oItem.ItemType_ID);
                    //                    sItemName = clsGenaralName.getName_Item(oItem.Item_ID);
                    //                }
                    //                tbl_zItemSerialNo oSerial = tbl_zItemSerialNo.Select(detail.ItemSerialNo);
                    //                if (oSerial != null && oSerial.Item_ID != "default")
                    //                {
                    //                    dSellingPrice = oSerial.SellingPrice;
                    //                }
                    //                glb_dtsScsStoreGoodsReceivedNote.dt_scsStoreGoodsReceiveNote_Detail.Adddt_scsStoreGoodsReceiveNote_DetailRow(oGRN.StoreGoodReceiveNote_ID, (oGRN.StoreGoodIssueNote_ID) == "default" ? "" : (oGRN.StoreGoodIssueNote_ID), sRefNo, oItem.Item_ID, sItemName,
                    //                detail.ItemSerialNo, "default", sItemType, sFromLocationName, detail.Qty, detail.Weight, sMetalInfor, sGemInfor, detail.ToStore_ID, sToStoreName, dSellingPrice, detail.Remark,detail.Job_ID, oGRN.StoreGoodReceiveNoteDate);
                    //            }
                    //            oGRN.Update();

                    //        }
                    //        print("\\Reports\\SCS\\NotePrinting\\rpt_scsStoreGoodReceiveNote.rpt", " Store Good Received Note (Detail) ", glb_dtsScsStoreGoodsReceivedNote, sCreateUserAndDate, sCheckedUserAndDate, sApprovedUserAndDate, "");

                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        SEACCException.Show(ex);
                    //    }
                    //    finally
                    //    {
                    //        Cursor = Cursors.Default;
                    //        glb_dtsScsStoreGoodsReceivedNote.dt_scsStoreGoodsReceiveNote.Clear();
                    //        glb_dtsScsStoreGoodsReceivedNote.dt_scsStoreGoodsReceiveNote_Detail.Clear();
                    //    }
                    //    #endregion
                    //} 
                    #endregion

                    //else
                    //    {
                    #region Other Models(Customers)
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        glb_dtsScsStoreGoodsReceivedNote.Clear();
                        glb_dtsReportExport.Clear();
                        bool bPermissinOkToPrint = true;

                        if (chkPrintOriginal.Checked)
                            bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_iGrn));
                        if (bPermissinOkToPrint)
                        {
                            tbl_scsStoreGoodReceiveNote oGRN = tbl_scsStoreGoodReceiveNote.Select(txtGoodreceivedNoteID.Text.Trim());
                            string sCreateUserAndDate = "", sApprovedUserAndDate = "", sCheckedUserAndDate = "", sModelRemark = "", sCreateUserCel = "", sCheckedUserCel = "", sApprovedUserCel = "", sCreatedate = "", sChequeDate = "", sApprovedDate = "", sISRNo = "";
                            if (oGRN != null && oGRN.StoreGoodReceiveNote_ID != "default")
                            {
                                string sFromLocationID = "", sFromLocationName = "";
                                clsHelpMethods_Local.getLocationNameAndID_FromDeptSecStore(oGRN.FromDepartment_ID, oGRN.FromSection_ID, oGRN.FromStore_ID, ref sFromLocationID, ref sFromLocationName);

                                sCreateUserAndDate = clsGenaralName.getName_User(oGRN.CreateUser_ID) + " - " + clsFormatter.FormatDate_Short(oGRN.DateCreate);
                                sApprovedUserAndDate = oGRN.IsApproved ? clsGenaralName.getName_User(oGRN.ApprovedUser_ID) + " - " + clsFormatter.FormatDate_Short(oGRN.DateApproved) : "";
                                sCheckedUserAndDate = oGRN.IsChecked ? clsGenaralName.getName_User(oGRN.CheckedUser_ID) + " - " + clsFormatter.FormatDate_Short(oGRN.DateChecked) : "";

                                #region Set User Details(For Cellcius)
                                sCreateUserCel = "[ " + clsGenaralName.getName_User(oGRN.CreateUser_ID) + " ] ";
                                sCreatedate = "[" + oGRN.DateCreate + "]";
                                if (oGRN.CheckedUser_ID != "default")
                                    sCheckedUserCel = "[ " + clsGenaralName.getName_User(oGRN.CheckedUser_ID) + " ] ";
                                sChequeDate = "[" + oGRN.DateChecked + "]";
                                if (oGRN.ApprovedUser_ID != "default")
                                    sApprovedUserCel = "[ " + clsGenaralName.getName_User(oGRN.ApprovedUser_ID) + " ] ";
                                sApprovedDate = "[" + oGRN.DateApproved + "]";
                                #endregion

                                if (!bIsDraft)
                                {
                                    //if (oGRN.PrintCount > 0)
                                    //    sDuplicateCopy = "Duplicate Copy " + oGRN.PrintCount;

                                    if (!chkPrintOriginal.Checked)
                                        sDuplicateCopy = (oGRN.PrintCount > 0) ? "Duplicate Copy " + oGRN.PrintCount : "";

                                    oGRN.PrintCount++;
                                }

                                tbl_scsStoreGoodIssueNote oGIN = tbl_scsStoreGoodIssueNote.Select(oGRN.StoreGoodIssueNote_ID);
                                if (oGIN != null)
                                {
                                    sISRNo = oGIN.StoreRequisitionNote_ID;
                                }

                                #region Fill Header
                                glb_dtsScsStoreGoodsReceivedNote.dt_scsStoreGoodsReceiveNote.Adddt_scsStoreGoodsReceiveNoteRow(oGRN.StoreGoodReceiveNote_ID, oGRN.StoreGoodReceiveNoteDate,
                                                        clsGenaralName.getName_Store(oGRN.ToStore_ID), sFromLocationName, oGRN.IsDeleted, oGRN.DateCreate, oGRN.Remark, sISRNo, oGRN.StoreGoodIssueNote_ID);
                                #endregion

                                #region Fill Details
                                foreach (tbl_scsStoreGoodReceiveNote_Detail detail in tbl_scsStoreGoodReceiveNote_Detail.SelectAllByStoreGoodReceiveNote_ID(oGRN.StoreGoodReceiveNote_ID))
                                {
                                    string sGemInfor = "", sMetalInfor = "", sRefNo = "", sItemType = "", sItemName = "", sToStoreName = "", sJobNo = "";// sItemBrandModel = "",
                                    decimal dSellingPrice = 0, dGINQty = 0, dGINQtySettle = 0; //, dQty = 0
                                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(detail.Item_ID);
                                    if (oItem != null && oItem.Item_ID != "default")
                                    {
                                        sItemType = clsGenaralName.getName_ItemType(oItem.ItemType_ID);
                                        sItemName = clsGenaralName.getName_Item(oItem.Item_ID);
                                    }
                                    tbl_zItemSerialNo oSerial = tbl_zItemSerialNo.Select(detail.ItemSerialNo);
                                    if (oSerial != null && oSerial.Item_ID != "default")
                                    {
                                        dSellingPrice = oSerial.SellingPrice;
                                    }
                                    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                    {
                                        sModelRemark = "Job Code";
                                        sJobNo = detail.Job_ID;
                                    }
                                    else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                                    {
                                        sModelRemark = "Brand Name";
                                        sJobNo = clsGenaralName.getCategoryID_ItemSubCategory(detail.ItemSubCategory_ID);
                                    }
                                    else
                                    {
                                        sModelRemark = "Remark";
                                        sJobNo = detail.Remark;
                                    }

                                    #region Set GoodIssuNote Qty                                          
                                    tbl_scsStoreGoodIssueNote_Detail oSettle = tbl_scsStoreGoodIssueNote_Detail.SelectAllByStoreGoodIssueNote_ID(detail.StoreGoodIssueNote_ID).Where(p => p.Item_ID == detail.Item_ID).FirstOrDefault();
                                    if (oSettle != null)
                                    {
                                        dGINQty = oSettle.Qty;
                                        dGINQtySettle = oSettle.QtySettle;
                                    }
                                    #endregion

                                    glb_dtsScsStoreGoodsReceivedNote.dt_scsStoreGoodsReceiveNote_Detail.Adddt_scsStoreGoodsReceiveNote_DetailRow(oGRN.StoreGoodReceiveNote_ID, (oGRN.StoreGoodIssueNote_ID) == "default" ? "" : (oGRN.StoreGoodIssueNote_ID), sRefNo, oItem.Item_ID, sItemName,
                                    detail.ItemSerialNo, sJobNo, sItemType, sFromLocationName, detail.Qty, detail.Weight, sMetalInfor, sGemInfor, detail.ToStore_ID, sToStoreName, dSellingPrice, detail.Remark, "default", oGRN.StoreGoodReceiveNoteDate, clsGenaralName.getName_Uom(detail.Uom_ID), dGINQty, dGINQtySettle);
                                }
                                oGRN.Update();
                                #endregion
                            }

                            string sGetRptPath = clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_iGrn));
                            string sGetRptDisplayName = clsHelpMethods_Local.GetReportDisplayName(clsAutocode.getReportID(enum_ReportName.NP_iGrn));
                            string s_Path = "";
                            if (sGetRptPath != null && sGetRptPath.Length > 0)
                                s_Path += sGetRptPath;
                            else
                                s_Path = "\\Reports\\SCS\\NotePrinting\\rpt_scsStoreGoodReceiveNote_AKT.rpt";

                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUserAndDate, true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sCheckedUserAndDate, true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUserAndDate, true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ModelRemark", sModelRemark, true);

                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", clsCommon.getCompanyEmail(), true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("SVAT", clsCommon.getCompanySVAT(), true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("BisRegNo", clsCommon.getCompanyBusinessRegisterNo(), true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVAT", clsCommon.getCompanyVAT(), true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyWebSite", clsCommon.getCompanyWeb(), true);

                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicateCopy, true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("isDel", oGRN.IsDeleted ? "CANCELLED" : "", true);

                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUser", sCreateUserCel, true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUser", sCheckedUserCel, true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApprovedUser", sApprovedUserCel, true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApprovedDate", sApprovedDate, true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateDate", sCreatedate, true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckedDate", sChequeDate, true);

                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle", sGetRptDisplayName, true);

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
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("BisRegNo", "", true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVAT", "", true);

                                }
                            }
                            glb_dtsScsStoreGoodsReceivedNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, "STORE GOODS RECEIVED NOTE [GRN]", "", "", clsSecurity.UserNameLoged, "");
                            #endregion

                            frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
                            ReportViewer.print(s_Path, glb_dtsScsStoreGoodsReceivedNote, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_iGrn));
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
                        glb_dtsScsStoreGoodsReceivedNote.Clear();
                        glb_dtsReportExport.Clear();
                    }
                    #endregion
                    //  }

                    #region Using Views (Old Method - Don't use)
                    //{
                    //    
                    //    //update receipt
                    //    string sCreateUser = "", sCheckedUser = "", sApprovedUser = "";
                    //    tbl_scsStoreGoodReceiveNote grn = tbl_scsStoreGoodReceiveNote.Select(txtGoodreceivedNoteID.Text.Trim());
                    //    if (grn != null)
                    //    {
                    //        if (grn.PrintCount > 0)
                    //            isDuplicate = true;
                    //        grn.PrintCount ++;
                    //        //order.IsLocked = true;
                    //        sCreateUser = "[ " + clsGenaralName.getName_User(grn.CreateUser_ID) + " ] [ " + grn.DateCreate.ToShortDateString() + " ]";
                    //        if (grn.CheckedUser_ID != "default")
                    //            sCheckedUser = "[ " + clsGenaralName.getName_User(grn.CheckedUser_ID) + " ] [ " + grn.DateChecked.ToShortDateString() + " ]";
                    //        if (grn.ApprovedUser_ID != "default")
                    //            sApprovedUser = "[ " + clsGenaralName.getName_User(grn.ApprovedUser_ID) + " ] [ " + grn.DateApproved.ToShortDateString() + " ]";
                    //        grn.Update();
                    //    }

                    //    Cursor = Cursors.WaitCursor;
                    //    string s_Path = "", sReportTitle = "GOODS RECEIVED NOTE [GRN]", sFormula = "";

                    //    sFormula = "{vw_rpt_scsStoreGoodReceiveNote.storeGoodReceiveNote_ID} = '" + txtGoodreceivedNoteID.Text.Trim() + "'";

                    //    ReportDocument RD = new ReportDocument();
                    //    s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                    //    s_Path += "\\reports\\rpt_scsStoreGoodReceiveNote.rpt";

                    //    frm_ReportViewer viewer = new frm_ReportViewer();
                    //    RD.Load(s_Path);
                    //    clsSecurity.LogonServer(ref RD);
                    //    RD.Refresh();

                    //    //RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                    //    RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                    //    RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToShortDateString());
                    //    RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
                    //    RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
                    //    RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);
                    //    RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    //    RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                    //    RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                    //    RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                    //    RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                    //    if(isDuplicate)
                    //        RD.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring("Duplicate Copy");


                    //    viewer.crystalReportViewer1.ReportSource = RD;
                    //    viewer.crystalReportViewer1.SelectionFormula = sFormula;
                    //    viewer.crystalReportViewer1.Visible = true;
                    //    viewer.crystalReportViewer1.DisplayToolbar = true;
                    //    viewer.crystalReportViewer1.CloseView(false);
                    //    viewer.WindowState = FormWindowState.Maximized;

                    //    viewer.ShowDialog();

                    //    RD.Close();
                    //    RD.Dispose();
                    //    
                    //}
                    #endregion
                }
                else
                    MessageBox.Show("Please Select the Goods Received Note To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region Print report
        private void print(string path, string sReportTitle, DataSet ojbDataSet, string sCreateUserNameAndDate, string sCheckedUserNameAndDate, string sApprovedUserNameAndDate, string sModelRemark)
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


                objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUserNameAndDate);
                objRpt.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUserNameAndDate);
                objRpt.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUserNameAndDate);
                objRpt.DataDefinition.FormulaFields["ModelRemark"].Text = clsCommon.fncsetstring(sModelRemark);
                if (isDuplicate)
                    objRpt.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring("Duplicate Copy");


                try
                {
                    objRpt.DataDefinition.FormulaFields["CompanyEmail"].Text = clsCommon.fncsetstring(clsCommon.getCompanyEmail());
                    objRpt.DataDefinition.FormulaFields["BisRegNo"].Text = clsCommon.fncsetstring(clsCommon.getCompanyBusinessRegisterNo());
                    objRpt.DataDefinition.FormulaFields["CompanyVAT"].Text = clsCommon.fncsetstring(clsCommon.getCompanyVAT());
                }
                catch (Exception ex) { }

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

        #region Btn Add GIN
        private void btnAddStore_Click(object sender, EventArgs e)
        {
            if (txtGinID.Text.Trim().Length > 0)
            {
                FillDetailsFromGIN(txtGinID.Text.Trim());
            }
        }
        #endregion

        #region Btn Option
        private void btnOption_Click(object sender, EventArgs e)
        {
            frmOption op = new frmOption();
            op.ShowDialog();

            if (frmOption.bEMail)
            {
                sendEmail();
            }
            else if (frmOption.bSMS)
            {

            }
            else if (frmOption.bCancel)
            {
                cancelOrder();
            }
            else if (frmOption.bPrint)
            {

            }
            else
            {

            }
        }
        #endregion

        #region Btn Temp
        private void frm_scsStoreGoodReceiveNote_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtGoodreceivedNoteID.TextLength > 0 && txtGoodreceivedNoteID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtGoodreceivedNoteID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtLocationID, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, true);
                clsCommon.SetEnableDisable_NormalLabel(lblGoodreceivedNoteID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblLocationID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, true);
                setEnableItems(true);

                txtGoodreceivedNoteID.Tag = null;
                dtpGRNDate.Value = clsSecurity.getServerDateTime();

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Order Ref No
                txtOrderRefNo.Tag = null;
                txtOrderRefNo.Clear();

                //Reset Primary Key
                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtGoodreceivedNoteID.Text = "<Auto Generate>";
                else
                    txtGoodreceivedNoteID.Clear();
                if (txtGoodreceivedNoteID.Enabled)
                {
                    txtGoodreceivedNoteID.SelectAll();
                    txtGoodreceivedNoteID.Focus();
                }

                Attachments.Clear();
            }
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat_New(dgvDetail, clsFormatter.colorGrid, UI_Color);
            //clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorStock1, clsFormatter.colorDigiteqTheamColorStockForColour, clsFormatter.colorDigiteqTheamColorStockBackColour);
            clsHelpMethods_Local.FormatGrid_Stock(dgvDetail);

            if (clsConfig.bWrap_ItemGrid_ItemName)
            {
                this.dgvDetail.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            //Change Grid Headers
            dgvDetail.Columns["ItemSubCategoryID1"].HeaderText = clsConfig.sItemSubCategory;
            dgvDetail.Columns["GoodsFrom"].HeaderText = "Issued From";
            dgvDetail.Columns["Note_ID"].HeaderText = "iGIN Number";

            dgvDetail.Columns["Weight"].Visible = !clsConfig.bHide_GridViewColumn_Stock_Weight;
            dgvDetail.Columns["GoodsFrom"].Visible = !clsConfig.bHide_GridViewColumn_Stock_GoodsFrom;
            dgvDetail.Columns["Note_ID"].Visible = !clsConfig.bHide_GridViewColumn_Stock_NoteID;

            //edit by janith
            //dgvDetail.Columns["ItemUnitPrice"].Visible = clsConfig.bSellingPrice_GridViewColumn;
            //dgvDetail.Columns["ItemTotalValue"].Visible = clsConfig.bSellingPrice_GridViewColumn;

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
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtGoodreceivedNoteID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtLocationID, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblGoodreceivedNoteID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblLocationID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, true);
            setEnableItems(false);

            cmbItemPrice.Visible = clsConfig.bDisplay_ItemUnitPrice_StoreTransferNotes;
            lblPriceCategory.Visible = clsConfig.bDisplay_ItemUnitPrice_StoreTransferNotes;

            if (clsConfig.bShow_GridViewColumn_Remarks)
                dgvDetail.Columns["Remarks"].Visible = true;
            else
                dgvDetail.Columns["Remarks"].Visible = false;

            txtLocationID.Tag = null;
            txtDepartmentID.Tag = null;
            txtSectionID.Tag = null;
            txtStoreID.Tag = null;
            txtGinID.Tag = null;
            txtOrderRefNo.Tag = null;
            clearLocationFields();

            txtGoodreceivedNoteID.Clear();
            txtRemark.Clear();
            txtLocationID.Clear();
            txtDepartmentID.Clear();
            txtSectionID.Clear();
            txtStoreID.Clear();
            txtGinID.Clear();
            txtOrderRefNo.Text = "";

            bHasApproved = false;
            bHasChecked = false;
            userDetailsColorChanges();

            //chkSettings.Checked = true;
            chkShowSettle.Checked = false;
            dgvDetail.Rows.Clear();
            dtpGRNDate.Value = clsSecurity.getServerDateTime();
            chkPrintOriginal.Checked = false;

            dtpGRNDate.Enabled = !clsConfig.bLock_TransactionDate_SCS;

            foreach (ComboBoxItem d in cmbItemPrice.Items)
            {
                if (d.Value == clsConfig.sItemUnitPriceCode_Default)
                {
                    cmbItemPrice.SelectedItem = d;
                    break;
                }
            }

            string sTmpStoreID = "", sTmpStoreName = "";
            if (clsProcessMethods.getStore_TradingStore_ByBranchID(clsSecurity.BranchID, ref sTmpStoreID, ref sTmpStoreName))
            {
                txtStoreID.Tag = sTmpStoreID;
                txtStoreID.Text = sTmpStoreName;
            }

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtGoodreceivedNoteID.Text = "<Auto Generate>";
            else
                txtGoodreceivedNoteID.Clear();
            if (txtGoodreceivedNoteID.Enabled)
            {
                txtGoodreceivedNoteID.SelectAll();
                txtGoodreceivedNoteID.Focus();
            }

            Attachments.Clear();
            ////clsFormatter.FormatProcessFlow(
        }
        #endregion

        #region Clear Location Field
        private void clearLocationFields()
        {
            txtDepartmentID.Tag = null;
            txtSectionID.Tag = null;
            txtStoreID.Tag = null;
            txtGinID.Tag = null;
            txtDepartmentID.Clear();
            txtSectionID.Clear();
            txtStoreID.Clear();
            txtGinID.Clear();
            setEnableItems(false);
        }
        #endregion

        #region Clear Items and Jobs
        private void clearItamAndJob()
        {
            txtGinID.Tag = null;
            txtGinID.Clear();
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            if (sID.Length > 0)
            {
                tbl_scsStoreGoodReceiveNote detail = tbl_scsStoreGoodReceiveNote.Select(sID);
                if (detail != null)
                {
                    //set the update flag and Locked
                    IsUpdate = true;
                    if (detail.IsDeleted)
                        lblCancelled.Visible = true;
                    clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtGoodreceivedNoteID, false);
                    clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtLocationID, false);
                    clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, false);
                    clsCommon.SetEnableDisable_NormalLabel(lblGoodreceivedNoteID, false);
                    clsCommon.SetEnableDisable_NormalLabel(lblLocationID, false);
                    clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, false);

                    //asign values
                    txtLocationID.Tag = detail.ToStore_ID;
                    txtDepartmentID.Tag = detail.FromDepartment_ID;
                    txtSectionID.Tag = detail.FromSection_ID;
                    txtStoreID.Tag = detail.FromStore_ID;
                    txtGinID.Tag = detail.StoreGoodIssueNote_ID;
                    txtJobIDTemp.Tag = detail.Job_ID;

                    //fill order detials
                    tbl_zIssuedRefNo order = tbl_zIssuedRefNo.Select(detail.IssuedRefNo_ID);
                    if (order != null)
                    {
                        txtOrderRefNo.Tag = order.IssuedRefNo_ID;
                        txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(order.IssuedRefNo);
                    }

                    txtGoodreceivedNoteID.Text = detail.StoreGoodReceiveNote_ID;
                    txtRemark.Text = detail.Remark;
                    dtpGRNDate.Value = detail.StoreGoodReceiveNoteDate;
                    txtLocationID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(detail.ToStore_ID));
                    txtDepartmentID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Department(detail.FromDepartment_ID));
                    txtSectionID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Section(detail.FromSection_ID));
                    txtStoreID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(detail.FromStore_ID));
                    txtGinID.Text = clsCommon.GetForeignKeyValue(detail.StoreGoodIssueNote_ID);
                    txtJobIDTemp.Text = clsCommon.GetForeignKeyValue(detail.Job_ID);
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

                    //fill item details
                    RefreshGrid(detail.StoreGoodReceiveNote_ID);

                    Attachments.FillAttachments(sID);
                    //Set Flow
                    clsHelpMethods_Local.SetProcessFlow_Stock_Internal(detail.IssuedRefNo_ID, txtFlowSR, txtFlowGIN, txtFlowGRN);
                }
            }
        }
        private void FillDetailsFromGIN(string sGIN_ID)
        {
            tbl_scsDepartmentGoodIssueNote oSR_Department = tbl_scsDepartmentGoodIssueNote.Select(sGIN_ID);
            if (oSR_Department != null)
            {
                //FillDetailsTextBoxes(oSR_Department.FromDepartment_ID, "default", "default", oSR_Department.ToStore_ID, glbSRNo, oSR_Department.IssuedRefNo_ID);
                //RefreshGridByDepartmentSRN_ID(oSR_Department.DepartmentReqositionNote_ID);
            }

            tbl_scsSectionGoodIssueNote oGIN_Section = tbl_scsSectionGoodIssueNote.Select(sGIN_ID);
            if (oGIN_Section != null)
            {
                FillDetailsTextBoxes("default", oGIN_Section.FromSection_ID, "default", oGIN_Section.ToStore_ID, sGIN_ID, oGIN_Section.IssuedRefNo_ID, "default");
                RefreshGridBySectionGIN_ID(oGIN_Section.SectionGoodIssueNote_ID);
            }

            tbl_scsStoreGoodIssueNote oGIN_Store = tbl_scsStoreGoodIssueNote.Select(txtGinID.Text.Trim());
            if (oGIN_Store != null)
            {
                FillDetailsTextBoxes("default", "default", oGIN_Store.FromStore_ID, oGIN_Store.ToStore_ID, sGIN_ID, oGIN_Store.IssuedRefNo_ID, oGIN_Store.ItemPriceCategory);
                RefreshGridByStoreGIN_ID(oGIN_Store.StoreGoodIssueNote_ID);
            }
        }
        private void FillDetailsTextBoxes(string sDepartmentID, string sSectionID, string sStoreID, string sLocationID, string sGIN_ID, string sIssueRefID, string sItemPriceCategory)
        {
            txtDepartmentID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Department(sDepartmentID));
            txtSectionID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Section(sSectionID));
            txtStoreID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(sStoreID));
            txtLocationID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(sLocationID));

            txtDepartmentID.Tag = sDepartmentID;
            txtSectionID.Tag = sSectionID;
            txtStoreID.Tag = sStoreID;
            txtLocationID.Tag = sLocationID;

            txtGinID.Text = sGIN_ID;
            txtGinID.Tag = sGIN_ID;

            if (sItemPriceCategory.Length > 0 && sItemPriceCategory != "default")
            {
                foreach (ComboBoxItem d in cmbItemPrice.Items)
                {
                    if (d.Value == sItemPriceCategory)
                    {
                        cmbItemPrice.SelectedItem = d;
                        break;
                    }
                }
            }

            //add order ref detail           
            txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_IssuedRefNo(sIssueRefID));
            txtOrderRefNo.Tag = sIssueRefID;
            clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, false);
            clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, false);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string sGRNID)
        {
            int iRow;
            dgvDetail.Rows.Clear();

            List<tbl_scsStoreGoodReceiveNote_Detail> details = tbl_scsStoreGoodReceiveNote_Detail.SelectAllByStoreGoodReceiveNote_ID(sGRNID).OrderBy(p => p.Line_No).ToList();
            foreach (tbl_scsStoreGoodReceiveNote_Detail detail in details)
            {
                dgvDetail.Rows.Add();
                iRow = dgvDetail.Rows.Count - 1;
                string sFromLocation = clsHelpMethods_Local.getToLocationName(detail.FromSelectArea_ID, detail.FromDepartment_ID, detail.FromSection_ID, detail.FromStore_ID);
                string sFromNoteID = clsHelpMethods_Local.GetSelectAreaNoteID(detail.FromSelectArea_ID, detail.DepartmentGoodIssueNote_ID, detail.SectionGoodIssueNote_ID, detail.StoreGoodIssueNote_ID);

                clsHelpMethods_Local.Fill_StockDatagrid(dgvDetail, iRow, detail.Line_No, detail.Item_ID, detail.Uom_ID, detail.Job_ID, detail.FromSelectArea_ID,
                    detail.FromDepartment_ID, detail.FromSection_ID, detail.FromStore_ID, detail.DepartmentGoodIssueNote_ID,
                    detail.SectionGoodIssueNote_ID, detail.StoreGoodIssueNote_ID, sFromLocation, sFromNoteID, detail.Qty, detail.Weight,
                    detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, "O", detail.UnitPrice, detail.TotalAmount, detail.Remark,0);
            }
        }
        private void RefreshGridByDepartmentGIN_ID(string sGIN_ID)
        {
            //Pls Do
        }
        private void RefreshGridBySectionGIN_ID(string sGIN_ID)
        {
            int iRow;
            List<tbl_scsSectionGoodIssueNote_Detail> details = tbl_scsSectionGoodIssueNote_Detail.SelectAllBySectionGoodIssueNote_ID(sGIN_ID).OrderBy(p => p.Line_No).ToList();
            foreach (tbl_scsSectionGoodIssueNote_Detail detail in details)
            {
                ValidateEmptyForeignKey();
                string sFromLocation = clsGenaralName.getName_Section(detail.FromSection_ID);
                string sFromNoteID = detail.SectionGoodIssueNote_ID;
                decimal dQty = detail.Qty - detail.QtySettle, dWeight = detail.Weight - detail.WeightSettle;

                if (dQty > 0 || dWeight > 0)//didnot display zero qty item
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;

                    clsHelpMethods_Local.Fill_StockDatagrid(dgvDetail, iRow, detail.Line_No, detail.Item_ID, detail.Uom_ID, detail.Job_ID,
                    clsAutocode.getSelectAreaCode(SelectArea.Section), "default", detail.FromSection_ID,
                    "default", "default", detail.SectionGoodIssueNote_ID, "default", sFromLocation, sFromNoteID, dQty, dWeight,
                    detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, "N", 0, 0, "",0);
                }
            }
        }
        private void RefreshGridByStoreGIN_ID(string sGIN_ID)
        {
            int iRow;
            List<tbl_scsStoreGoodIssueNote_Detail> details = tbl_scsStoreGoodIssueNote_Detail.SelectAllByStoreGoodIssueNote_ID(sGIN_ID).OrderBy(p => p.Line_No).ToList();
            foreach (tbl_scsStoreGoodIssueNote_Detail detail in details)
            {
                ValidateEmptyForeignKey();
                string sFromLocation = clsGenaralName.getName_Section(detail.FromStore_ID);
                string sFromNoteID = detail.StoreGoodIssueNote_ID;
                decimal dQty = detail.Qty - detail.QtySettle, dWeight = detail.Weight - detail.WeightSettle;

                if (dQty > 0 || dWeight > 0)//didnot display zero qty item
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;

                    clsHelpMethods_Local.Fill_StockDatagrid(dgvDetail, iRow, detail.Line_No, detail.Item_ID, detail.Uom_ID, detail.Job_ID,
                        clsAutocode.getSelectAreaCode(SelectArea.Store), "default", "default", detail.FromStore_ID, "default",
                        "default", detail.StoreGoodIssueNote_ID, sFromLocation, sFromNoteID, dQty, dWeight,
                        detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, "N", detail.UnitPrice, detail.TotalAmount, "",0);
                }
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
            clsEvent.StockGrid_CellDoubleClick(sender, e, dgvDetail);
        }
        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            clsEvent.StockGrid_CellEndEdit(sender, e, dgvDetail);
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


                if (sColName == "ItemCode" || sColName == "ItemName" || sColName == "ItemSubCategoryID1" || sColName == "GoodsFrom" || sColName == "Note_ID" || sColName == "UOM" || sColName == "ItemSerialNo1")
                {
                    Cursor = Cursors.Hand;
                }
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


                if (sColName == "ItemCode" || sColName == "ItemName" || sColName == "ItemSubCategoryID1" || sColName == "GoodsFrom" || sColName == "Note_ID" || sColName == "UOM" || sColName == "ItemSerialNo1")
                {
                    Cursor = Cursors.Default;
                }
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtGoodreceivedNoteID_DoubleClick(object sender, EventArgs e)
        {
            Search_StoreGoodReceiveNote();
        }
        private void txtDepartmentID_DoubleClick(object sender, EventArgs e)
        {
            clearLocationFields();
            Search_Department();
        }
        private void txtSectionID_DoubleClick(object sender, EventArgs e)
        {
            clearLocationFields();
            Search_Section();
        }
        private void txtStoreID_DoubleClick(object sender, EventArgs e)
        {
            clearLocationFields();
            Search_Store();
        }
        private void txtGINNoStore_DoubleClick(object sender, EventArgs e)
        {
            clearItamAndJob();
            loadGINnumber();
        }
        private void txtLocationID_DoubleClick(object sender, EventArgs e)
        {
            Search_StoreTo();
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
        private void txtGoodreceivedNoteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_StoreGoodReceiveNote();
            }
        }
        private void txtDepartmentID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clearLocationFields();
                Search_Department();
            }
        }
        private void txtSectionID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clearLocationFields();
                Search_Section();
            }
        }
        private void txtStoreID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clearLocationFields();
                Search_Store();
            }
        }
        private void txtGINNoStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clearItamAndJob();
                loadGINnumber();
            }
        }
        private void txtLocationID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_StoreTo();
            }
        }
        private void frm_sasStoreGoodReceiveNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyCode == Keys.F9)
            {
                frm_scsStoreGoodReceiveNote_SF_newButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F10)
            {
                frm_scsStoreGoodReceiveNote_SF_saveButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F11)
            {
                btnRemove_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F12)
            {
                frm_scsStoreGoodReceiveNote_SF_printButton_Click(sender, e);
            }
        }
        #endregion

        #region Events KeyUp

        #endregion

        #region Events CheckedChanged
        private void chkSettings_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkSettings.Checked)
            //{
            //    xFlow.SendToBack();
            //    chkSettings.Image = Digiteq.Properties.Resources.security;
            //}
            //else
            //{
            //    xSetting.SendToBack();
            //    chkSettings.Image = Digiteq.Properties.Resources.settings;
            //}
        }
        #endregion

        #region Calcualte Values
        private decimal GetTotalPrice(decimal dPrice, decimal dQuantity)
        {
            decimal dTotalPrice = 0;
            dTotalPrice = dPrice * dQuantity;
            return dTotalPrice;
        }
        #endregion

        #region Check Validity
        private bool CheckJobNoValidity_Emptyfield()
        {
            string sJobNo = "";//strMessage = "",
            bool bStatus = true;
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                sJobNo = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
                if (!clsValidate.GetProductionJobPrePlanValidation(sJobNo))
                {
                    bStatus = false;
                    break;
                }
            }
            if (bStatus == false)
            {
                MessageBox.Show("Job No. " + sJobNo + " should be planned atleast " + clsConfig.sProductionJobPrePlanDates + " days before to proceed.", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bStatus;
        }
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtLocationID, "Issuer"))
            {
                //if (clsValidate.ValidateTextBox_EmptyValue(txtOrderRefNo, "Issue Ref No"))
                //{
                bStatus = true;
                //}
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
            //string strMessage = "", sOriginalItemCode = "", sItemCode = "", sJobCode = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "";
            //decimal dWeight = 0;
            //decimal dQty = 0;


            //foreach (DataGridViewRow row in dgvDetail.Rows)
            //{
            //    #region Stock Validation                
            //   // sItemStatus = clsValidate.ValidateGridValue(dgvDetail, "ItemStatus", row.Index, "");


            //    sOriginalItemCode = sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
            //    sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
            //    sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
            //    sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
            //    sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
            //    sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");

            //    dWeight = clsValidate.ValidateGridValue(dgvDetail, "WeightActual", row.Index, decimal.Parse("0.00"));
            //    dQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));


            //    if (!clsConfig.bStoreStockWithJobID)
            //        sJobCode = "default";

            //    //check whether single item stock enabled - qty
            //    if (clsConfig.bSingleItemStockEnabled)
            //    {
            //        if (!clsHelpMethods.IsItemRawMaterial(sItemCode))
            //            clsHelpMethods.AssignSingleStockItemDetail(ref sItemCode, ref sItemSubCategoryID, ref sItemSubCategoryID2, ref sItemSerialNo, ref sItemSerialNo2);
            //    }

            //    tbl_genStore_Stock stock = tbl_genStore_Stock.Select(txtStoreID.Tag.ToString(), sItemCode, sJobCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
            //    if (stock != null)
            //    {


            //        #region New Item Weight Validation
            //        if (stock.Weight < dWeight && clsConfig.bStockValidateWeight_iGRN && !clsHelpMethods.IsNonInventoryItem(sItemCode))
            //        {
            //            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required Weight Is Not Availabe As IT Is In  " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
            //            bStatus = false;
            //        }
            //        #endregion

            //        #region New Item Quantity Validation
            //        if (stock.Qty < dQty && clsConfig.bStockValidateQty_iGRN && !clsHelpMethods.IsNonInventoryItem(sItemCode))
            //        {
            //            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + "  Required Quantity Is Not Availabe As IT Is In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
            //            bStatus = false;
            //        }
            //        #endregion


            //    }
            //    else
            //    {
            //        if ((clsConfig.bStockValidateQty_iGRN || clsConfig.bStockValidateWeight_iGRN) && !clsHelpMethods.IsNonInventoryItem(sItemCode))
            //        {
            //            //No stock in selected store
            //            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + "  Is Not Available In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + " Stock\n";
            //            bStatus = false;
            //        }
            //    }
            //    #endregion
            //}
            //if (bStatus == false)
            //{
            //    MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

            return bStatus;
        }
        private bool CheckItemSettleValidity()
        {
            bool rtn = true;
            //string sItemCode = "", sCoCode = "", strMessage = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "";
            //decimal dQuantity = 0, dWeight = 0;

            //if ((!clsAutocode.getItemExceed(ConfigItemExceedLock.DeliveryOrder)) && (!IsUpdate))
            //{
            //    foreach (DataGridViewRow row in dgvDetail.Rows)
            //    {
            //        try
            //        {
            //            sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");                        
            //            sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
            //            sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
            //            sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
            //            sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");

            //            dWeight = clsValidate.ValidateGridValue(dgvDetail, "WeightActual", row.Index, decimal.Parse("0.00"));
            //            dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));

            //            if (getDepartmentGIN() != "default")
            //            {
            //                tbl_scsSectionGoodIssueNote_Detail detail = tbl_scsSectionGoodIssueNote_Detail.Select(
            //            }

            //            tbl_sasCustomerOrder_Detail CoDetail = tbl_sasCustomerOrder_Detail.Select(sCoCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
            //            if (CoDetail != null)
            //            {
            //                if (chkUnitPricing.Checked)
            //                {
            //                    if (IsUpdate)
            //                    {
            //                        if (CoDetail.Qty < dQuantity)
            //                        {
            //                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Quantity cannot Exceed the Ordered Quantity  \n";
            //                            rtn = false;
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (CoDetail.Qty < (CoDetail.QtySettle_DeliveryOrder + dQuantity))
            //                        {
            //                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Quantity cannot Exceed the Ordered Quantity  \n";
            //                            rtn = false;
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    if (IsUpdate)
            //                    {
            //                        if (CoDetail.Weight < dWeight)
            //                        {
            //                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Weight cannot Exceed the Ordered Weightt \n";
            //                            rtn = false;
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (CoDetail.Weight < (CoDetail.WeightSettle_DeliveryOrder + dWeight))
            //                        {
            //                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Weight cannot Exceed the Ordered Weight \n";
            //                            rtn = false;
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            clsValidate.WriteErrorLog("", iFormID,ex);
            //            SEACCException.Show(ex);
            //        }
            //    }
            //    if (!rtn)
            //    {
            //        MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            return rtn;
        }
        private bool CheckValidity_Customer()
        {
            bool bStatus = true;
            try
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    string sJobID = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
                    if (sJobID.Length > 0)
                    {
                        //tbl_pmsProductionJobRegister job = tbl_pmsProductionJobRegister.Select(sJobID);
                        //if (job != null && job.ProductionJob_ID != "default")
                        //{
                        //    tbl_genCustomerMaster customer = tbl_genCustomerMaster.Select(job.Customer_ID);
                        //    if (customer != null && customer.Customer_ID != "default")
                        //    {
                        //        if (customer.IsBlacklisted)
                        //        {
                        //            bStatus = false;
                        //            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.CustomerIsBlackListed), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        //        }
                        //    }
                        //}
                    }
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
            clsCommon.ValidateForeignKey(ref txtDepartmentID);
            clsCommon.ValidateForeignKey(ref txtSectionID);
            clsCommon.ValidateForeignKey(ref txtStoreID);
            clsCommon.ValidateForeignKey(ref txtGinID);
        }
        #endregion

        #region Search Methods
        private void Search_StoreGoodReceiveNote()
        {
            try
            {
                clsSearch.Search_TransactionStoreGoodsReceiveNote_Direct(ref txtGoodreceivedNoteID, chkShowSettle.Checked);
                if (txtGoodreceivedNoteID.Text.Trim().Length > 0)
                {
                    FillDetails(txtGoodreceivedNoteID.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void Search_Department()
        {
            clsSearch.Search_MasterDepartment(ref txtDepartmentID);
            if (txtDepartmentID.Tag != null)
                setEnableItems(true);
        }
        private void Search_DepartmentGoodIssueNote()
        {
            clsSearch.Search_TransactionDepartmentGoodIssueNoteByDepartmentID(ref txtGinID, txtDepartmentID.Tag.ToString(), txtLocationID.Tag.ToString());
        }
        private void Search_Section()
        {
            clsSearch.Search_MasterSection(ref txtSectionID);
            if (txtSectionID.Tag != null)
                setEnableItems(true);
        }

        private void Search_SectionGoodIssueNote()
        {
            clsSearch.Search_TransactionSectionGoodIssueNoteByStoreID(ref txtGinID, txtSectionID.Tag.ToString(), txtLocationID.Tag.ToString());
        }

        private void Search_Store()
        {
            clsSearch.Search_MasterStore(ref txtStoreID, clsConfig.enableBranchWiseFilterOnSearch ? true : false);
            if (txtStoreID.Tag != null)
                setEnableItems(true);
        }
        private void Search_StoreTo()
        {
            clsSearch.Search_MasterStore(ref txtLocationID, clsConfig.enableBranchWiseFilterOnSearch ? true : false);
        }

        private void Search_StoreGoodIssueNote()
        {
            //clsSearch.Search_TransactionStoreGoodIssueNoteByStoreID(ref txtGinID, txtStoreID.Tag.ToString(), txtLocationID.Tag.ToString());

            clsSearch.Search_TransactionStoreGoodsIssueNote(ref txtGinID, chkShowSettle.Checked, false, txtStoreID.Tag.ToString(), txtLocationID.Tag.ToString());
        }
        #endregion

        #region Set Enable/Desable Items
        private void setEnableItems(bool Val)
        {
            clearItamAndJob();
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemIDTemp, false);
            clsCommon.SetEnableDisable_NormalLabel(lblItemTemp, false);
            btnAddItemTemp.Enabled = false;
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtJobIDTemp, false);
            clsCommon.SetEnableDisable_NormalLabel(lblJobTemp, false);
            btnAddJobTemp.Enabled = false;
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtGinID, Val);
            clsCommon.SetEnableDisable_NormalLabel(lblGIN, Val);
            btnAddGIN.Enabled = Val;
        }
        #endregion

        #region Get Select Aria ID
        private string getSelectAriaID()
        {
            string rtn = "";
            if (txtDepartmentID.Tag != null && txtDepartmentID.Tag.ToString() != "default")
                rtn = clsAutocode.getSelectAreaCode(SelectArea.Department);
            else if (txtSectionID.Tag != null && txtSectionID.Tag.ToString() != "default")
                rtn = clsAutocode.getSelectAreaCode(SelectArea.Section);
            else if (txtStoreID.Tag != null && txtStoreID.Tag.ToString() != "default")
                rtn = clsAutocode.getSelectAreaCode(SelectArea.Store);
            else
                rtn = clsAutocode.getSelectAreaCode(SelectArea.Default);
            return rtn;
        }
        #endregion                  

        #region Get Location GIN Number
        private string getDepartmentGIN()
        {
            string rtn = "";
            if (txtDepartmentID.Tag != null && txtDepartmentID.Tag.ToString() != "default" && txtGinID.Text.Trim().Length > 0)
                rtn = txtGinID.Text.Trim();
            else
                rtn = "default";
            return rtn;
        }
        private string getSectionGIN()
        {
            string rtn = "";
            if (txtSectionID.Tag != null && txtSectionID.Tag.ToString() != "default" && txtGinID.Text.Trim().Length > 0)
                rtn = txtGinID.Text.Trim();
            else
                rtn = "default";
            return rtn;
        }
        private string getStoreGIN()
        {
            string rtn = "";
            if (txtStoreID.Tag != null && txtStoreID.Tag.ToString() != "default" && txtGinID.Text.Trim().Length > 0)
                rtn = txtGinID.Text.Trim();
            else
                rtn = "default";
            return rtn;
        }
        #endregion

        #region Load GIN Number
        private void loadGINnumber()
        {
            if (txtLocationID.Tag != null && txtLocationID.Tag.ToString().Length > 0)
            {
                if (txtDepartmentID.Tag != null)
                    Search_DepartmentGoodIssueNote();
                else if (txtSectionID.Tag != null)
                    Search_SectionGoodIssueNote();
                else if (txtStoreID.Tag != null)
                    Search_StoreGoodIssueNote();
            }
            else
            {
                MessageBox.Show("Please Enter Select Receiver..........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLocationID.Focus();
            }
        }
        #endregion

        #region Send E-Mail
        public void sendEmail()
        {
            //   frmEmail oEmail = new frmEmail();
            //   oEmail.Show();
        }
        #endregion

        #region Cancel Order
        private void cancelOrder()
        {
            try
            {
                if (txtGoodreceivedNoteID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreID.Tag.ToString(), IsUpdate))
                        {
                            if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtLocationID.Tag.ToString(), IsUpdate))
                            {
                                //delete one record
                                Cursor = Cursors.WaitCursor;
                                tbl_scsStoreGoodReceiveNote detail = tbl_scsStoreGoodReceiveNote.Select(txtGoodreceivedNoteID.Text.Trim());
                                if (detail != null)
                                {
                                    if (!detail.IsLocked)
                                    {
                                        if (!detail.IsDeleted)
                                        {
                                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " GRN : " + detail.StoreGoodReceiveNote_ID), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                            if (msgResult == DialogResult.Yes)
                                            {
                                                detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                detail.DateModified = clsSecurity.getServerDateTime();
                                                detail.IsDeleted = true;
                                                detail.Update();

                                                #region Update Other Tables
                                                List<tbl_scsStoreGoodReceiveNote_Detail> details = tbl_scsStoreGoodReceiveNote_Detail.SelectAllByStoreGoodReceiveNote_ID(detail.StoreGoodReceiveNote_ID);
                                                foreach (tbl_scsStoreGoodReceiveNote_Detail GRNdetail in details)
                                                {
                                                    decimal dWeightedAverageCostPrice = 0;
                                                    //clsHelpMethods_Local.UpdateStoreStock(GRNdetail.Item_ID, txtStoreID.Tag.ToString(), GRNdetail.Qty, GRNdetail.Weight, true, true);
                                                    //  clsHelpMethods_Local.RollBackFifo_Stock(iFormID, GRNdetail.StoreGoodReceiveNote_ID);
                                                  //  clsHelpMethods_Local.UpdateStoreStock(iFormID, GRNdetail.StoreGoodReceiveNote_ID, detail.StoreGoodReceiveNoteDate, GRNdetail.Item_ID, "0", txtStoreID.Tag.ToString(), GRNdetail.Qty, GRNdetail.Weight, GRNdetail.TotalAmount, true, true, false, ref dWeightedAverageCostPrice);
                                                    GRNdetail.WeightedAvgCost = clsProcessMethods.GetItemWeightedAvarageCostPrice(GRNdetail.Item_ID);
                                                    GRNdetail.Update();

                                                    ///Unsettle GIN - Store
                                                    foreach (tbl_scsStoreGoodIssueNote_Detail oStoreGIN in tbl_scsStoreGoodIssueNote_Detail.SelectAllByStoreGoodIssueNote_ID(GRNdetail.StoreGoodIssueNote_ID).Where(p => p.Item_ID == GRNdetail.Item_ID))
                                                    {
                                                        oStoreGIN.QtySettle = oStoreGIN.QtySettle - GRNdetail.Qty;
                                                        oStoreGIN.WeightSettle = oStoreGIN.WeightSettle - GRNdetail.Weight;
                                                        oStoreGIN.Update();
                                                        clsProcessMethods.SetSettle_StoreGIN(GRNdetail.StoreGoodIssueNote_ID);
                                                    }
                                                    ///Unsettle GIN - Section
                                                    tbl_scsSectionGoodIssueNote_Detail oSectionGIN = tbl_scsSectionGoodIssueNote_Detail.Select(GRNdetail.SectionGoodIssueNote_ID, GRNdetail.Item_ID, GRNdetail.ItemSubCategory_ID, GRNdetail.ItemSubCategory2_ID, GRNdetail.ItemSerialNo, GRNdetail.ItemSerialNo2);
                                                    if (oSectionGIN != null)
                                                    {
                                                        oSectionGIN.QtySettle = oSectionGIN.QtySettle - GRNdetail.Qty;
                                                        oSectionGIN.WeightSettle = oSectionGIN.WeightSettle - GRNdetail.Weight;
                                                        oSectionGIN.Update();
                                                        clsProcessMethods.SetSettle_SectionGIN(GRNdetail.SectionGoodIssueNote_ID);
                                                    }
                                                    ///Unsettle GIN - Department
                                                    ///Pls Do
                                                }
                                                #endregion

                                                // clsHelpMethods.Delete_Inventory(iFormID, 0, txtGoodreceivedNoteID.Text.Trim());
                                                var responce = oData.Delete_InventoryTxn(iFormID, txtGoodreceivedNoteID.Text.Trim());
                                                if (!responce.IsSuccess)
                                                {
                                                    clsValidate.WriteErrorLog(txtGoodreceivedNoteID.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
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

        private void btnAddItemTemp_Click(object sender, EventArgs e)
        {

        }

        private void btnAddJobTemp_Click(object sender, EventArgs e)
        {

        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frm_scsStoreGoodReceiveNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            Attachments.Close();
        }


        #region User Checked Approve Details
        private void frm_scsStoreGoodReceiveNote_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }
        private void frm_scsStoreGoodReceiveNote_SF_approveButton_Click(object sender, EventArgs e)
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
                        if (txtGoodreceivedNoteID.Text != null && txtGoodreceivedNoteID.TextLength > 0 && txtGoodreceivedNoteID.Text != "<Auto Generate>")
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

                                        tbl_scsStoreGoodReceiveNote objDO = tbl_scsStoreGoodReceiveNote.Select(txtGoodreceivedNoteID.Text.Trim());
                                        if (objDO != null)
                                        {
                                            objDO.IsApproved = true;
                                            objDO.DateApproved = clsSecurity.getServerDateTime();
                                            objDO.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                            objDO.Update();
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
                        if (txtGoodreceivedNoteID.Text != null && txtGoodreceivedNoteID.TextLength > 0 && txtGoodreceivedNoteID.Text != "<Auto Generate>")
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

                                        tbl_scsStoreGoodReceiveNote objDO = tbl_scsStoreGoodReceiveNote.Select(txtGoodreceivedNoteID.Text.Trim());
                                        if (objDO != null)
                                        {
                                            objDO.IsChecked = true;
                                            objDO.DateChecked = clsSecurity.getServerDateTime();
                                            objDO.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objDO.Update();
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
        private void frm_scsStoreGoodReceiveNote_SF_History_Click(object sender, EventArgs e)
        {
            if (txtGoodreceivedNoteID.Text != "" || txtGoodreceivedNoteID.Text != "<Auto Generate>")
            {
                tbl_scsStoreGoodReceiveNote detail = tbl_scsStoreGoodReceiveNote.Select(txtGoodreceivedNoteID.Text);
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
