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
using Zion.ERP.Reports.DataSets.SCS;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;
using System.IO;
using Zion.ERP.Reports.DataSets;
using SEACC.DATA.Data.SCS;
using ZION.ERP.Reports.DataSets.SCS;

namespace Digiteq
{
    public partial class frm_scsStoreGoodIssueNote : SEACC_Form
    {
        
        //to manage update and insert
        //static bool IsUpdate = false;
        bool isDuplicate = false;

        //form manage
        string sFormConfigCodeUPL;// sDepartmentID = "default", sSectionID = "default", sStoreID = "default",
        // sSRNNoDepartment = "default", sSRNNoSection = "default", sSRNNoStore = "default";
        //public int iFormID;
        //string sFormConfigCode, 
        //to keep glob ref no        
        public string glbGINNo = "", glbSRNo = "";

        //for security handle
        //public bool bNoAccess;
        //public bool bHasChecked;
        //public bool bHasApproved;
        //   DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        //  DateTime glbCheckedDate = clsSecurity.getServerDateTime();

        __dts_scsStoreGoodsIssueNote glb_dtsStoreGoodsIssueNote = new __dts_scsStoreGoodsIssueNote();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();

        public DataTable dt_ItemGrouped = new DataTable();

        InventoryTxnData oData = new InventoryTxnData();
    

        #region Form Load
        public frm_scsStoreGoodIssueNote(FormName _enmForm)
        {
            //sFormConfigCode = clsAutocode.getFormConfigCode(FormName.sasGINTradingStock);
            //sFormConfigCodeUPL = clsAutocode.getFormConfigCode(FormName.sasGINTradingStockUPL);

            //iFormID = clsSecurity.getFormID(FormName.sasGINTradingStock);

            //if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            //    bNoAccess = true;

            //InitializeComponent();

            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }
        private void frmCustomerOrder_Load(object sender, EventArgs e)
        {
            //add data to the datagrid and format  
            //clsFormatter.setFormatForm(this, clsHelpMethods_Local.getFormName(iFormID), 4, iFormID);

            SetVisibility_ActionButons(true, true, true, true, false, true, true, true, true);
            clsFill.Fill_StockNoteTypes(ref cmbStockNoteType);
            clsFill.Fill_ItemPrices(ref cmbItemPrice);
            CusDataGridViewFormat();
            ClearFields();

            if (glbGINNo.Length > 0)
                FillDetails(glbGINNo);

            //if the GIN fired by SR   
            if (glbSRNo.Length > 0)
            {
                txtSRNID.Text = glbSRNo;
                FillDetailsFromSR(txtSRNID.Text.Trim());
            }
        }
        #endregion

        #region Btn New
        private void frm_scsStoreGoodIssueNote_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Remove
        private void btnRemove_Click(object sender, EventArgs e)
        {
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
        }
        #endregion

        #region Btn Save
        private void frm_scsStoreGoodIssueNote_SF_saveButton_Click(object sender, EventArgs e)
        {
            dt_ItemGrouped = clsCommon.DataGridViewToDataTable_ItemGrouped_CategoryID1(dgvDetail);

            if (CheckValidity_EmptyValue())
            {
                if (CheckNumberValidity())
                {
                    if (clsValidate.CheckGridCountValidity(dgvDetail.RowCount, iFormID))
                    {
                        if (CheckStockValidity())
                        {
                            if (CheckJobNoValidity())
                            {
                                if (CheckValidity_Customer())
                                {
                                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpGINDate.Value.Date))
                                    {
                                        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                                        {
                                            if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreID.Tag.ToString(), IsUpdate))
                                            {
                                                if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtLocationID.Tag.ToString(), IsUpdate))
                                                {
                                                    bool bFillDetails = false;
                                                    try
                                                    {
                                                        Cursor = Cursors.WaitCursor;
                                                        ValidateEmptyForeignKey();

                                                        if (IsUpdate)  //update records
                                                        {
                                                            #region Update Code
                                                            tbl_scsStoreGoodIssueNote oldRecord = tbl_scsStoreGoodIssueNote.Select(txtGoodIssueNoteID.Text.Trim());
                                                            if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                                                            {
                                                                if (ValidateForDependancies(oldRecord.StoreGoodIssueNote_ID))
                                                                {
                                                                    //if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted && !oldRecord.IsChecked)
                                                                    if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                                                                    {
                                                                        if (!oldRecord.IsChecked || (oldRecord.IsChecked && clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID)))
                                                                        {
                                                                            if (clsValidate.CheckValidity_TransactionCodeLength(txtGoodIssueNoteID.Text))
                                                                            {
                                                                              //  List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();

                                                                                #region Rollback StoreStock

                                                                                foreach (
                                                                                    tbl_scsStoreGoodIssueNote_Detail
                                                                                        oUpdatedRecord in
                                                                                    tbl_scsStoreGoodIssueNote_Detail
                                                                                        .SelectAllByStoreGoodIssueNote_ID(
                                                                                            txtGoodIssueNoteID.Text
                                                                                                .Trim()))
                                                                                {
                                                                                    decimal dWeightedAverageCostPrice = 0;
                                                                                    //clsHelpMethods_Local
                                                                                    //    .UpdateStoreStock(iFormID,
                                                                                    //        oUpdatedRecord
                                                                                    //            .StoreGoodIssueNote_ID,
                                                                                    //        oldRecord
                                                                                    //            .StoreGoodIssueNoteDate,
                                                                                    //        oUpdatedRecord.Item_ID, "0",
                                                                                    //        txtLocationID.Tag
                                                                                    //            .ToString(),
                                                                                    //        oUpdatedRecord.Qty,
                                                                                    //        oUpdatedRecord.Weight,
                                                                                    //        oUpdatedRecord.TotalAmount,
                                                                                    //        true, false, false, ref dWeightedAverageCostPrice);
                                                                                    //  clsHelpMethods_Local.RollBackFifo_Stock(iFormID, oUpdatedRecord.StoreGoodIssueNote_ID);
                                                                                    oUpdatedRecord.WeightedAvgCost = clsProcessMethods.GetItemWeightedAvarageCostPrice(oUpdatedRecord.Item_ID);
                                                                                    oUpdatedRecord.Update();
                                                                                }

                                                                                #endregion

                                                                                #region Delete old Items
                                                                                List<tbl_scsStoreGoodIssueNote_Detail> oldGINDetails = tbl_scsStoreGoodIssueNote_Detail.SelectAllByStoreGoodIssueNote_ID(oldRecord.StoreGoodIssueNote_ID);
                                                                                foreach (tbl_scsStoreGoodIssueNote_Detail oldGINDetail in oldGINDetails)
                                                                                {
                                                                                    #region Update SR Status

                                                                                    string sSrnID =
                                                                                        clsHelpMethods_Local
                                                                                            .GetSelectAreaNoteID(
                                                                                                oldGINDetail
                                                                                                    .ToSelectArea_ID,
                                                                                                oldGINDetail
                                                                                                    .DepartmentReqositionNote_ID,
                                                                                                oldGINDetail
                                                                                                    .SectionRequisitionNote_ID,
                                                                                                oldGINDetail
                                                                                                    .StoreRequisitionNote_ID);
                                                                                    if (sSrnID.Trim().Length > 0 &&
                                                                                        sSrnID.Trim().ToLower() !=
                                                                                        "default")
                                                                                    {
                                                                                        if (clsAutocode
                                                                                                .getSelectAreaCode(
                                                                                                    SelectArea
                                                                                                        .Department) ==
                                                                                            oldGINDetail
                                                                                                .ToSelectArea_ID)
                                                                                        {
                                                                                            foreach (
                                                                                                tbl_scsDepartmentReqositionNote_Detail
                                                                                                    SR in
                                                                                                tbl_scsDepartmentReqositionNote_Detail
                                                                                                    .SelectAllByDepartmentReqositionNote_ID(
                                                                                                        sSrnID).Where(
                                                                                                        p =>
                                                                                                            p.Item_ID ==
                                                                                                            oldGINDetail
                                                                                                                .Item_ID)
                                                                                            )
                                                                                            {
                                                                                                SR.QtySettle -=
                                                                                                    oldGINDetail.Qty;
                                                                                                SR.WeightSettle -=
                                                                                                    oldGINDetail.Weight;
                                                                                                SR.Update();
                                                                                                clsProcessMethods
                                                                                                    .SetSettle_DepartmentSR(
                                                                                                        sSrnID);
                                                                                            }
                                                                                        }
                                                                                        else if (clsAutocode
                                                                                                     .getSelectAreaCode(
                                                                                                         SelectArea
                                                                                                             .Section) ==
                                                                                                 oldGINDetail
                                                                                                     .ToSelectArea_ID)
                                                                                        {
                                                                                            foreach (
                                                                                                tbl_scsSectionReqositionNote_Detail
                                                                                                    SR in
                                                                                                tbl_scsSectionReqositionNote_Detail
                                                                                                    .SelectAllBySectionReqositionNote_ID(
                                                                                                        sSrnID).Where(
                                                                                                        p =>
                                                                                                            p.Item_ID ==
                                                                                                            oldGINDetail
                                                                                                                .Item_ID)
                                                                                            )
                                                                                            {
                                                                                                SR.QtySettle -=
                                                                                                    oldGINDetail.Qty;
                                                                                                SR.WeightSettle -=
                                                                                                    oldGINDetail.Weight;
                                                                                                SR.Update();
                                                                                                clsProcessMethods
                                                                                                    .SetSettle_SectionSR(
                                                                                                        sSrnID);
                                                                                            }
                                                                                        }
                                                                                        else if (clsAutocode
                                                                                                     .getSelectAreaCode(
                                                                                                         SelectArea
                                                                                                             .Store) ==
                                                                                                 oldGINDetail
                                                                                                     .ToSelectArea_ID)
                                                                                        {
                                                                                            foreach (
                                                                                                tbl_scsStoreReqositionNote_Detail
                                                                                                    SR in
                                                                                                tbl_scsStoreReqositionNote_Detail
                                                                                                    .SelectAllByStoreRecositionNote_ID(
                                                                                                        sSrnID).Where(
                                                                                                        p =>
                                                                                                            p.Item_ID ==
                                                                                                            oldGINDetail
                                                                                                                .Item_ID)
                                                                                            )
                                                                                            {
                                                                                                SR.QtySettle -=
                                                                                                    oldGINDetail.Qty;
                                                                                                SR.WeightSettle -=
                                                                                                    oldGINDetail.Weight;
                                                                                                SR.Update();
                                                                                                clsProcessMethods
                                                                                                    .SetSettle_StoreSR(
                                                                                                        sSrnID);
                                                                                            }
                                                                                        }
                                                                                    }

                                                                                    #endregion

                                                                                    oldGINDetail.Delete();
                                                                                }
                                                                                #endregion

                                                                                #region Update Items

                                                                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                                                                {
                                                                                    #region Initialize Variables and Set Grid Values
                                                                                    string sItemCode = "", sUom = "default", sJobCode = "",
                                                                                                                                                                    sSelectArea_ID = "", sDepartment_ID = "", sSection_ID = "", sStore_ID = "",
                                                                                                                                                                    sDepartmentNote_ID = "", sSectionNote_ID = "", sStoreNote_ID = "", sItemSubCategoryID1 = "",
                                                                                                                                                                    sItemSubCategoryID2 = "", sItemSerialNo1 = "", sItemSerialNo2 = "", sRemarks = "";
                                                                                    decimal dWeight = 0, dQuantity = 0, dTotalCost_FIFO = 0, dUnitPrice = 0, dWeightPrice = 0, dTotalAmount = 0;
                                                                                    int iLineNo = 0;

                                                                                    iLineNo = clsValidate
                                                                                        .ValidateGridValue(dgvDetail, "LineNo", row.Index, int.Parse("0"));
                                                                                    sItemCode = clsValidate
                                                                                        .ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                                                                    sUom = clsValidate.ValidateGridTag(
                                                                                        dgvDetail, "UOM", row.Index, "default");
                                                                                    dWeight = clsValidate
                                                                                        .ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                                                                    dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                                                                    sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
                                                                                    sSelectArea_ID = clsValidate.ValidateGridValue(dgvDetail, "SelectArea_ID", row.Index, "default");
                                                                                    sDepartment_ID = clsValidate.ValidateGridValue(dgvDetail, "Department_ID", row.Index, "default");
                                                                                    sSection_ID = clsValidate.ValidateGridValue(dgvDetail, "Section_ID", row.Index, "default");
                                                                                    sStore_ID = clsValidate.ValidateGridValue(dgvDetail, "Store_ID", row.Index, "default");
                                                                                    sDepartmentNote_ID = clsValidate.ValidateGridValue(dgvDetail, "DepartmentNote_ID", row.Index, "default");
                                                                                    sSectionNote_ID = clsValidate.ValidateGridValue(dgvDetail, "SectionNote_ID", row.Index, "default");
                                                                                    sStoreNote_ID = clsValidate.ValidateGridValue(dgvDetail, "StoreNote_ID", row.Index, "default");
                                                                                    sItemSubCategoryID1 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                                                                                    sItemSubCategoryID2 =
                                                                                        clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                                                                    sItemSerialNo1 =
                                                                                        clsValidate.ValidateGridValue(
                                                                                            dgvDetail, "ItemSerialNo1",
                                                                                            row.Index, "0");
                                                                                    sItemSerialNo2 =
                                                                                        clsValidate.ValidateGridValue(
                                                                                            dgvDetail, "ItemSerialNo2",
                                                                                            row.Index, "0");
                                                                                    dTotalCost_FIFO =
                                                                                        clsValidate.ValidateGridValue(
                                                                                            dgvDetail, "CostPrice",
                                                                                            row.Index,
                                                                                            decimal.Parse("0.00"));
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
                                                                                    sRemarks = clsValidate
                                                                                        .ValidateGridValue(dgvDetail,
                                                                                            "Remarks", row.Index, "");
                                                                                    #endregion

                                                                                    if (sItemCode.Length > 0)
                                                                                    {
                                                                                        tbl_scsStoreGoodIssueNote_Detail
                                                                                            items =
                                                                                                new
                                                                                                    tbl_scsStoreGoodIssueNote_Detail(
                                                                                                        iLineNo,
                                                                                                        txtGoodIssueNoteID
                                                                                                            .Text
                                                                                                            .Trim(),
                                                                                                        sItemCode,
                                                                                                        sItemSubCategoryID1,
                                                                                                        sItemSubCategoryID2,
                                                                                                        sItemSerialNo1,
                                                                                                        sItemSerialNo2,
                                                                                                        sJobCode,
                                                                                                        txtLocationID
                                                                                                            .Tag
                                                                                                            .ToString(),
                                                                                                        sSelectArea_ID,
                                                                                                        sDepartment_ID,
                                                                                                        sSection_ID,
                                                                                                        sStore_ID,
                                                                                                        sDepartmentNote_ID,
                                                                                                        sSectionNote_ID,
                                                                                                        sStoreNote_ID,
                                                                                                        sUom, dQuantity,
                                                                                                        0, dWeight, 0,
                                                                                                        dTotalCost_FIFO,
                                                                                                        0, sRemarks,
                                                                                                        false,
                                                                                                        dUnitPrice,
                                                                                                        dWeightPrice,
                                                                                                        dTotalAmount, clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemCode));
                                                                                        items.Insert();

                                                                                        //Update Store Stock                                                           
                                                                                        //clsHelpMethods_Local.UpdateOrInsertStoreStock(clsConfig.bStockValidateQty_iGIN, clsConfig.bStockValidateWeight_iGIN, sItemCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2,
                                                                                        //   sJobCode, txtLocationID.Tag.ToString(), dQuantity, dWeight, 0, 0, false, false, true);

                                                                                        #region Update SR Status

                                                                                        string sSrnID =
                                                                                            clsHelpMethods_Local
                                                                                                .GetSelectAreaNoteID(
                                                                                                    sSelectArea_ID,
                                                                                                    sDepartmentNote_ID,
                                                                                                    sSectionNote_ID,
                                                                                                    sStoreNote_ID);
                                                                                        if (sSrnID.Trim().Length > 0 &&
                                                                                            sSrnID.Trim().ToLower() !=
                                                                                            "default")
                                                                                        {
                                                                                            if (clsAutocode
                                                                                                    .getSelectAreaCode(
                                                                                                        SelectArea
                                                                                                            .Department) ==
                                                                                                sSelectArea_ID)
                                                                                            {
                                                                                                foreach (
                                                                                                    tbl_scsDepartmentReqositionNote_Detail
                                                                                                        SR in
                                                                                                    tbl_scsDepartmentReqositionNote_Detail
                                                                                                        .SelectAllByDepartmentReqositionNote_ID(
                                                                                                            sSrnID)
                                                                                                        .Where(p =>
                                                                                                            p.Item_ID ==
                                                                                                            sItemCode))
                                                                                                {
                                                                                                    SR.QtySettle +=
                                                                                                        dQuantity;
                                                                                                    SR.WeightSettle +=
                                                                                                        dWeight;
                                                                                                    SR.Update();
                                                                                                    clsProcessMethods
                                                                                                        .SetSettle_DepartmentSR(
                                                                                                            sSrnID);
                                                                                                }
                                                                                            }
                                                                                            else if (clsAutocode
                                                                                                         .getSelectAreaCode(
                                                                                                             SelectArea
                                                                                                                 .Section) ==
                                                                                                     sSelectArea_ID)
                                                                                            {
                                                                                                foreach (
                                                                                                    tbl_scsSectionReqositionNote_Detail
                                                                                                        SR in
                                                                                                    tbl_scsSectionReqositionNote_Detail
                                                                                                        .SelectAllBySectionReqositionNote_ID(
                                                                                                            sSrnID)
                                                                                                        .Where(p =>
                                                                                                            p.Item_ID ==
                                                                                                            sItemCode))
                                                                                                {
                                                                                                    SR.QtySettle +=
                                                                                                        dQuantity;
                                                                                                    SR.WeightSettle +=
                                                                                                        dWeight;
                                                                                                    SR.Update();
                                                                                                    clsProcessMethods
                                                                                                        .SetSettle_SectionSR(
                                                                                                            sSrnID);
                                                                                                }
                                                                                            }
                                                                                            else if (clsAutocode
                                                                                                         .getSelectAreaCode(
                                                                                                             SelectArea
                                                                                                                 .Store) ==
                                                                                                     sSelectArea_ID)
                                                                                            {
                                                                                                foreach (
                                                                                                    tbl_scsStoreReqositionNote_Detail
                                                                                                        SR in
                                                                                                    tbl_scsStoreReqositionNote_Detail
                                                                                                        .SelectAllByStoreRecositionNote_ID(
                                                                                                            sSrnID)
                                                                                                        .Where(p =>
                                                                                                            p.Item_ID ==
                                                                                                            sItemCode))
                                                                                                {
                                                                                                    SR.QtySettle +=
                                                                                                        dQuantity;
                                                                                                    SR.WeightSettle +=
                                                                                                        dWeight;
                                                                                                    SR.Update();
                                                                                                    clsProcessMethods
                                                                                                        .SetSettle_StoreSR(
                                                                                                            sSrnID);
                                                                                                }
                                                                                            }
                                                                                        }

                                                                                        #endregion

                                                                                        #region Pass Value to Inventory Detail
                                                                                        //tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, iLineNo, 0, txtGoodIssueNoteID.Text.Trim(), dtpGINDate.Value,
                                                                                        //                            "", "", "", "", "default", "default", txtStoreID.Tag.ToString(),
                                                                                        //                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), 0, dQuantity, dUnitPrice, 0, false);
                                                                                        //oListInventory.Add(oInventoryDetail);
                                                                                        #endregion
                                                                                    }
                                                                                }
                                                                                #endregion

                                                                                #region Update GIN Header

                                                                                tbl_scsStoreGoodIssueNote detail =
                                                                                    new tbl_scsStoreGoodIssueNote(
                                                                                        txtGoodIssueNoteID.Text.Trim(),
                                                                                        dtpGINDate.Value,
                                                                                        txtRemark.Text.Trim(),
                                                                                        txtJobID.Tag.ToString(),
                                                                                        txtLocationID.Tag.ToString(),
                                                                                        getSelectAriaID(),
                                                                                        getToDepartment(),
                                                                                        getToSection(), getToStore(),
                                                                                        getDepartmentSRN(),
                                                                                        getSectionSRN(), getStoreSRN(),
                                                                                        txtOrderRefNo.Tag.ToString(),
                                                                                        oldRecord.CreateUser_ID,
                                                                                        clsSecurity.UserIDLoged,
                                                                                        oldRecord.CheckedUser_ID,
                                                                                        oldRecord.ApprovedUser_ID,
                                                                                        oldRecord.DeletedUser_ID,
                                                                                        oldRecord.PrintedUser_ID,
                                                                                        oldRecord.CreateTerminal_ID,
                                                                                        clsSecurity.TerminalID,
                                                                                        oldRecord.DeletedTerminal_ID,
                                                                                        oldRecord.PrintedTerminal_ID,
                                                                                        oldRecord.DateCreate,
                                                                                        clsSecurity.getServerDateTime(),
                                                                                        oldRecord.DateChecked,
                                                                                        oldRecord.DateApproved,
                                                                                        oldRecord.DateDeleted,
                                                                                        oldRecord.DatePrinted,
                                                                                        oldRecord.IsChecked,
                                                                                        oldRecord.IsApproved,
                                                                                        oldRecord.IsFinished,
                                                                                        oldRecord.IsDeleted,
                                                                                        oldRecord.IsLocked,
                                                                                        oldRecord.PrintCount,
                                                                                        oldRecord.IsSeattled,
                                                                                        ((ComboBoxItem)cmbItemPrice
                                                                                            .SelectedItem).Value,
                                                                                        oldRecord.CompanyID,
                                                                                        oldRecord.CompanyBranch_ID);
                                                                                detail.Update();

                                                                                #endregion

                                                                                #region Update Store Stock
                                                                                foreach (tbl_scsStoreGoodIssueNote_Detail oUpdatedRecord in tbl_scsStoreGoodIssueNote_Detail.SelectAllByStoreGoodIssueNote_ID(txtGoodIssueNoteID.Text.Trim()))
                                                                                {
                                                                                    decimal dWeightedAverageCostPrice = 0;
                                                                                    //clsHelpMethods_Local.UpdateStoreStock(iFormID, detail.StoreGoodIssueNote_ID,
                                                                                    //        detail.StoreGoodIssueNoteDate, oUpdatedRecord.Item_ID, "0", txtLocationID.Tag.ToString(),
                                                                                    //        oUpdatedRecord.Qty, oUpdatedRecord.Weight, oUpdatedRecord.TotalAmount, false, false, false, ref dWeightedAverageCostPrice);
                                                                                    //  clsHelpMethods_Local.UpdateFifo_Stock(iFormID, detail.StoreGoodIssueNote_ID, detail.StoreGoodIssueNoteDate, txtLocationID.Tag.ToString(), oUpdatedRecord.Item_ID, oUpdatedRecord.ItemSerialNo, oUpdatedRecord.Qty, oUpdatedRecord.UnitPrice, false);
                                                                                  
                                                                                }
                                                                                #endregion

                                                                                #region Pass Values to Inventory Header and Update Inventory
                                                                                //tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtGoodIssueNoteID.Text.Trim(), dtpGINDate.Value, txtRemark.Text.Trim(),
                                                                                //        "default", "default", "default", -1, 0,
                                                                                //        "", "", "", "", false, clsSecurity.UserIDLoged);

                                                                                //clsHelpMethods.Update_Inventory(oHeader, oListInventory);

                                                                                var responce = oData.Update_InventoryTxn(iFormID, txtGoodIssueNoteID.Text.Trim());
                                                                                if (!responce.IsSuccess)
                                                                                {
                                                                                    clsValidate.WriteErrorLog(txtGoodIssueNoteID.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
                                                                                }
                                                                                #endregion

                                                                                bFillDetails = true;

                                                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(),
                                                                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                            }
                                                                        }
                                                                        else
                                                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                    }
                                                                    else
                                                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                }
                                                            }

                                                            //MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordUpdateIsBlock), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            #endregion
                                                        }
                                                        else  //insert records
                                                        {
                                                            #region Insert Data
                                                            //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.gem.ToString())
                                                            //    txtGoodIssueNoteID.Text = clsAutocode.getAutoGeneratedCode_FromBranch_iGIN(txtLocationID.Tag.ToString().Trim(), txtStoreID.Tag.ToString().Trim());
                                                            //else
                                                            {
                                                                if (chkUPLTransfer.Checked)
                                                                {
                                                                    if (clsAutocode.IsAutoGenerated(sFormConfigCodeUPL))
                                                                        txtGoodIssueNoteID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCodeUPL);
                                                                }
                                                                else
                                                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                                                    txtGoodIssueNoteID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);
                                                            }

                                                            //create order ref number
                                                            if (txtOrderRefNo.Tag == null || txtOrderRefNo.Tag.ToString() == "default")
                                                            {
                                                                txtOrderRefNo.Tag = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.zIssuedRefNo));
                                                                tbl_zIssuedRefNo orf = new tbl_zIssuedRefNo(txtOrderRefNo.Tag.ToString(), txtOrderRefNo.Text != "" ? txtOrderRefNo.Text.Trim() : "-");
                                                                orf.Insert();
                                                            }

                                                            if (clsValidate.CheckValidity_TransactionCodeLength(txtGoodIssueNoteID.Text)) //if (txtGoodIssueNoteID.Text.Trim().Length > 0)
                                                            {
                                                                tbl_scsStoreGoodIssueNote oIGIN = tbl_scsStoreGoodIssueNote.Select(txtGoodIssueNoteID.Text.Trim());
                                                                if (oIGIN == null)
                                                                {
                                                                 //   List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();

                                                                    #region Insert Header
                                                                    tbl_scsStoreGoodIssueNote detail = new tbl_scsStoreGoodIssueNote(txtGoodIssueNoteID.Text.Trim(), dtpGINDate.Value, txtRemark.Text.Trim(),
                                                                            txtJobID.Tag.ToString(), txtLocationID.Tag.ToString(), getSelectAriaID(), getToDepartment(), getToSection(), getToStore(), getDepartmentSRN(), getSectionSRN(), getStoreSRN(),
                                                                            txtOrderRefNo.Tag.ToString(), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default", clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                                                            clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                                            glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                                            bHasChecked, bHasApproved, false, false, false, 0, false, ((ComboBoxItem)cmbItemPrice.SelectedItem).Value, clsSecurity.CompanyID, clsSecurity.BranchID);
                                                                    detail.Insert();
                                                                    #endregion

                                                                    #region Insert Details
                                                                    foreach (DataGridViewRow row in dgvDetail.Rows)
                                                                    {
                                                                        try
                                                                        {
                                                                            #region Initialize Variables then Set Values
                                                                            string sItemCode = "", sUom = "default", sJobCode = "", sSelectArea_ID = "", sDepartment_ID = "",
                                                                                    sSection_ID = "", sStore_ID = "", sDepartmentNote_ID = "", sSectionNote_ID = "", sStoreNote_ID = "",
                                                                                    sItemSubCategoryID1 = "", sItemSubCategoryID2 = "", sItemSerialNo1 = "", sItemSerialNo2 = "", sRemarks = "";
                                                                            decimal dWeight = 0, dQuantity = 0, dTotalCost_FIFO = 0, dUnitPrice = 0, dWeightPrice = 0, dTotalAmount = 0;
                                                                            int iLineNo = 0;

                                                                            iLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, int.Parse("0"));
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
                                                                            sItemSubCategoryID1 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                                                                            sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                                                            sItemSerialNo1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                                                                            sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                                                            dTotalCost_FIFO = clsValidate.ValidateGridValue(dgvDetail, "CostPrice", row.Index, decimal.Parse("0.00"));
                                                                            dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "ItemUnitPrice", row.Index, decimal.Parse("0.00"));
                                                                            //dWeight = clsValidate.ValidateGridValue(dgvDetail, "ItemUnitPrice", row.Index, decimal.Parse("0.00"));
                                                                            dTotalAmount = clsValidate.ValidateGridValue(dgvDetail, "ItemTotalValue", row.Index, decimal.Parse("0.00"));
                                                                            sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                                                                            #endregion

                                                                            if (sItemCode.Length > 0)
                                                                            {
                                                                                tbl_scsStoreGoodIssueNote_Detail items = new tbl_scsStoreGoodIssueNote_Detail(iLineNo, txtGoodIssueNoteID.Text.Trim(),
                                                                                    sItemCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, sJobCode,
                                                                                    txtLocationID.Tag.ToString(), sSelectArea_ID, sDepartment_ID, sSection_ID, sStore_ID, sDepartmentNote_ID, sSectionNote_ID, sStoreNote_ID,
                                                                                    sUom, dQuantity, 0, dWeight, 0, dTotalCost_FIFO, 0, sRemarks, false, dUnitPrice, dWeightPrice, dTotalAmount, clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemCode));
                                                                                items.Insert();

                                                                                decimal dWeightedAverageCostPrice = 0;
                                                                            //    clsHelpMethods_Local.UpdateStoreStock(iFormID, detail.StoreGoodIssueNote_ID, detail.StoreGoodIssueNoteDate, sItemCode, "0", txtLocationID.Tag.ToString(), dQuantity, dWeight, dTotalAmount, false, false, false, ref dWeightedAverageCostPrice);
                                                                                //   clsHelpMethods_Local.UpdateFifo_Stock(iFormID, detail.StoreGoodIssueNote_ID, detail.StoreGoodIssueNoteDate, detail.FromStore_ID, items.Item_ID, items.ItemSerialNo, items.Qty, items.UnitPrice, false);
                                                                               
                                                                                //update SR 
                                                                                #region Update SR Status
                                                                                string sSrnID = clsHelpMethods_Local.GetSelectAreaNoteID(sSelectArea_ID, sDepartmentNote_ID, sSectionNote_ID, sStoreNote_ID);
                                                                                if (sSrnID.Trim().Length > 0 && sSrnID.Trim().ToLower() != "default")
                                                                                {
                                                                                    if (clsAutocode.getSelectAreaCode(SelectArea.Department) == sSelectArea_ID)
                                                                                    {
                                                                                        foreach (tbl_scsDepartmentReqositionNote_Detail SR in tbl_scsDepartmentReqositionNote_Detail.SelectAllByDepartmentReqositionNote_ID(sSrnID).Where(p => p.Item_ID == sItemCode))
                                                                                            if (SR != null)
                                                                                            {
                                                                                                SR.QtySettle += dQuantity;
                                                                                                SR.WeightSettle += dWeight;
                                                                                                SR.Update();
                                                                                                clsProcessMethods.SetSettle_DepartmentSR(sSrnID);
                                                                                            }
                                                                                    }
                                                                                    else if (clsAutocode.getSelectAreaCode(SelectArea.Section) == sSelectArea_ID)
                                                                                    {
                                                                                        foreach (tbl_scsSectionReqositionNote_Detail SR in tbl_scsSectionReqositionNote_Detail.SelectAllBySectionReqositionNote_ID(sSrnID).Where(p => p.Item_ID == sItemCode))
                                                                                        {
                                                                                            SR.QtySettle += dQuantity;
                                                                                            SR.WeightSettle += dWeight;
                                                                                            SR.Update();
                                                                                            clsProcessMethods.SetSettle_SectionSR(sSrnID);
                                                                                        }
                                                                                    }
                                                                                    else if (clsAutocode.getSelectAreaCode(SelectArea.Store) == sSelectArea_ID)
                                                                                    {
                                                                                        foreach (tbl_scsStoreReqositionNote_Detail SR in tbl_scsStoreReqositionNote_Detail.SelectAllByStoreRecositionNote_ID(sSrnID).Where(p => p.Item_ID == sItemCode))
                                                                                        {
                                                                                            SR.QtySettle += dQuantity;
                                                                                            SR.WeightSettle += dWeight;
                                                                                            SR.Update();
                                                                                            clsProcessMethods.SetSettle_StoreSR(sSrnID);
                                                                                        }
                                                                                    }
                                                                                }
                                                                                #endregion

                                                                                LockGemItem(sStoreNote_ID, sItemCode, sItemSerialNo1);

                                                                                #region Pass Value to Inventory Detail
                                                                                //tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, iLineNo, 0, txtGoodIssueNoteID.Text.Trim(), dtpGINDate.Value,
                                                                                //                            "", "", "", "", "default", "default", txtStoreID.Tag.ToString(),
                                                                                //                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), 0, dQuantity, dUnitPrice, 0, false);
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

                                                                    Attachments.Insert(txtGoodIssueNoteID.Text.ToString());

                                                                    #region Pass Values to Inventory Header and Update Inventory
                                                                    //tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtGoodIssueNoteID.Text.Trim(), dtpGINDate.Value, txtRemark.Text.Trim(),
                                                                    //        "default", "default", "default", -1, 0,
                                                                    //        "", "", "", "", false, clsSecurity.UserIDLoged);

                                                                    //clsHelpMethods.Update_Inventory(oHeader, oListInventory);

                                                                    var responce = oData.Update_InventoryTxn(iFormID, txtGoodIssueNoteID.Text.Trim());
                                                                    if (!responce.IsSuccess)
                                                                    {
                                                                        clsValidate.WriteErrorLog(txtGoodIssueNoteID.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
                                                                    }

                                                                    #endregion

                                                                    bFillDetails = true;
                                                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                }
                                                                else
                                                                    MessageBox.Show("This ID is alredy added", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            }
                                                            //else
                                                            //{
                                                            //    MessageBox.Show("Good Issue Note " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                                        if (bFillDetails)
                                                        {
                                                            tbl_scsStoreGoodIssueNote detail = tbl_scsStoreGoodIssueNote.Select(txtGoodIssueNoteID.Text.Trim());
                                                            if (detail != null)
                                                                FillDetails(detail.StoreGoodIssueNote_ID);
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
        #endregion

        #region Btn Print
        private void frm_scsStoreGoodIssueNote_SF_printButton_Click(object sender, EventArgs e)
        {
            print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_scsStoreGoodIssueNote_SF_draftButton_Click(object sender, EventArgs e)
        {
            print(true);
        }
        #endregion

        #region Btn Add SRN
        private void btnAddStore_Click(object sender, EventArgs e)
        {
            if (txtSRNID.Text.Trim().Length > 0)
            {
                FillDetailsFromSR(txtSRNID.Text.Trim());
            }
        }
        #endregion

        #region Btn add Item
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        #endregion

        #region Btn Add JobOder
        private void btnJobOder_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txtJobID.Text.Trim().Length > 0)
                //{
                //    tbl_pmsProductionJobRegister detail = tbl_pmsProductionJobRegister.Select(txtJobID.Text.Trim());
                //    if (detail != null)
                //    {
                //        RefreshGridByJob_ID(detail.ProductionJob_ID);
                //    }
                //}
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        #endregion

        #region Btn IGRN
        private void btnIGRN_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGoodIssueNoteID.Text != "default" && txtGoodIssueNoteID.Text.Trim().Length > 0 && txtGoodIssueNoteID.Text != "<Auto Generate>")
                {
                    tbl_scsStoreGoodIssueNote detail = tbl_scsStoreGoodIssueNote.Select(txtGoodIssueNoteID.Text.ToString());
                    if (detail != null)
                    {
                        if (!detail.IsSeattled)
                        {
                            bool bAllowDetail = true;
                            string message = "";

                            if (clsConfig.bApprovalNeedForInternalTransferNoteSearch)
                            {
                                if (!detail.IsApproved)
                                {
                                    bAllowDetail = false;
                                    message = "APPROVAL NEEDED \n\nUser has to Approve the Internal Goods Issue Note Before Create an Internal Goods Received Note";
                                }
                            }

                            if (bAllowDetail)
                            {
                                if (detail.ToSelectArea_ID == clsAutocode.getSelectAreaCode(SelectArea.Store))
                                {
                                    //frm_scsStoreGoodReceiveNote frmGIN = new frm_scsStoreGoodReceiveNote();
                                    //if (frmGIN.bNoAccess)
                                    //    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frmGIN.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //else
                                    //{
                                    //    frmGIN.glbGINNo = detail.StoreGoodIssueNote_ID;
                                    //    frmGIN.MdiParent = this.MdiParent;
                                    //    frmGIN.Show();
                                    //}

                                    frm_scsStoreGoodReceiveNote frm = new frm_scsStoreGoodReceiveNote(FormName.sasGRNTradingStock);
                                    frm.glbGINNo = detail.StoreGoodIssueNote_ID;
                                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, (this.Parent as Form).MdiParent);
                                }
                                else if (detail.ToSelectArea_ID == clsAutocode.getSelectAreaCode(SelectArea.Section))
                                {
                                    //frm_scsSectionGoodReceiveNote frmGIN = new frm_scsSectionGoodReceiveNote();
                                    //if (frmGIN.bNoAccess)
                                    //    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frmGIN.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //else
                                    //{
                                    //    frmGIN.glbGINNo = detail.StoreGoodIssueNote_ID;
                                    //    frmGIN.MdiParent = this.MdiParent;
                                    //    frmGIN.Show();
                                    //}
                                }
                                else if (detail.ToSelectArea_ID == clsAutocode.getSelectAreaCode(SelectArea.Department))
                                {
                                    //Pls Do
                                }
                            }
                            else
                                MessageBox.Show(message, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Already Issued \n\nThis GIN Quantity has already being issued by Good Requisition Note(s)", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region btn LoadGRNs
        private void btnLoadGRNs_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (clsValidate.ValidateTextBox_Tag_CannotBeEmptyOrDefault(txtLocationID, "Issue From"))
                    if (clsValidate.ValidateTextBox_Tag_CannotBeEmptyOrDefault(txtStoreID, "Store Name"))
                        if (clsValidate.ValidateComboBox_Value_CannotBeEmptyOrDefault(cmbStockNoteType, "Stock Note Type"))
                            RefreshGridByGRN();
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

        #region Btn Item F5
        private void btnItemF5_Click(object sender, EventArgs e)
        {
            clearItamAndJob();
            Search_ItemID(sender, new KeyEventArgs(Keys.F5));
        }
        #endregion

        #region Btn Temp
        private void frm_scsStoreGoodIssueNote_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtGoodIssueNoteID.TextLength > 0 && txtGoodIssueNoteID.Text != "<Auto Generate>")
            {
                //isTemp = true;
                IsUpdate = false;
                lblCancelled.Visible = false;

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtGoodIssueNoteID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtLocationID, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, true);
                setEnableItems(true);
                clsCommon.SetEnableDisable_NormalLabel(lblGoodreceivedNoteID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblLocationID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, true);

                txtGoodIssueNoteID.Tag = null;
                dtpGINDate.Value = clsSecurity.getServerDateTime();

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Order Ref No
                txtOrderRefNo.Tag = null;
                txtOrderRefNo.Clear();

                //Reset Primary Key
                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtGoodIssueNoteID.Text = "<Auto Generate>";
                else
                    txtGoodIssueNoteID.Clear();
                if (txtGoodIssueNoteID.Enabled)
                {
                    txtGoodIssueNoteID.SelectAll();
                    txtGoodIssueNoteID.Focus();
                }
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
                dgvDetail.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            //Change Grid Headers
            dgvDetail.Columns["ItemSubCategoryID1"].HeaderText = clsConfig.sItemSubCategory;
            dgvDetail.Columns["GoodsFrom"].HeaderText = "Requested By";
            dgvDetail.Columns["Note_ID"].HeaderText = "iSR Number";

            dgvDetail.Columns["MettleDetail"].Visible = clsConfig.bMettleDetail_GridViewColumn;
            dgvDetail.Columns["GemDetail"].Visible = clsConfig.bGemDetail_GridViewColumn;

            dgvDetail.Columns["SellingPrice"].Visible = !clsConfig.bHide_GridViewColumn_Stock_SellingPrice;
            dgvDetail.Columns["CostPrice"].Visible = !clsConfig.bHide_GridViewColumn_Stock_CostPrice;
            dgvDetail.Columns["TotalCostPrice"].Visible = !clsConfig.bHide_GridViewColumn_Stock_TotalCostPrice;

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
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtGoodIssueNoteID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtLocationID, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, true);
            setEnableItems(false);
            clsCommon.SetEnableDisable_NormalLabel(lblGoodreceivedNoteID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblLocationID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, true);

            cmbItemPrice.Visible = clsConfig.bDisplay_ItemUnitPrice_StoreTransferNotes;
            lblPriceCategory.Visible = clsConfig.bDisplay_ItemUnitPrice_StoreTransferNotes;

            if (clsConfig.bShow_GridViewColumn_Remarks)
                dgvDetail.Columns["Remarks"].Visible = true;
            else
                dgvDetail.Columns["Remarks"].Visible = false;

            txtLocationID.Tag = null;
            txtItemSubCategory.Tag = null;
            txtItemSerialNo.Tag = null;
            txtOrderRefNo.Tag = null;

            txtItemSerialNo.Clear();
            txtItemSubCategory.Clear();
            txtGoodIssueNoteID.Clear();
            txtRemark.Clear();
            txtLocationID.Clear();
            clearLocationFields();
            txtOrderRefNo.Text = "";

            bHasApproved = false;
            bHasChecked = false;
            userDetailsColorChanges();

            //chkSettings.Checked = true;
            dgvDetail.Rows.Clear();
            dt_ItemGrouped.Clear();
            dtpGINDate.Value = clsSecurity.getServerDateTime();

            dtpGINDate.Enabled = !clsConfig.bLock_TransactionDate_SCS;

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtGoodIssueNoteID.Text = "<Auto Generate>";
            else
                txtGoodIssueNoteID.Clear();
            if (txtGoodIssueNoteID.Enabled)
            {
                txtGoodIssueNoteID.SelectAll();
                txtGoodIssueNoteID.Focus();
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
            txtTotWeight.Clear();
            clsHelpMethods_Local.SetItemImage("NoImage", ref pbxImage);

            string sTmpStoreID = "", sTmpStoreName = "";
            if (clsProcessMethods.getStore_MainStore_ByBranchID(clsSecurity.BranchID, ref sTmpStoreID, ref sTmpStoreName))
            {
                txtLocationID.Tag = sTmpStoreID;
                txtLocationID.Text = sTmpStoreName;
            }

            Attachments.Clear();
        }
        #endregion

        #region Clear Items and Jobs
        private void clearItamAndJob()
        {
            txtItemID.Tag = null;
            txtJobID.Clear();
            txtJobID.Tag = null;
            txtSRNID.Tag = null;
            txtItemID.Clear();
            txtSRNID.Clear();

        }
        #endregion

        #region Clear Location Field
        private void clearLocationFields()
        {
            txtDepartmentID.Tag = null;
            txtSectionID.Tag = null;
            txtStoreID.Tag = null;
            txtJobID.Tag = null;
            txtSRNID.Tag = null;
            txtItemID.Tag = null;
            txtDepartmentID.Clear();
            txtSectionID.Clear();
            txtStoreID.Clear();
            txtJobID.Clear();
            txtSRNID.Clear();
            txtItemID.Clear();
            setEnableItems(false);
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_scsStoreGoodIssueNote detail = tbl_scsStoreGoodIssueNote.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtGoodIssueNoteID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtLocationID, false);
                        clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblGoodreceivedNoteID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblLocationID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, false);

                        //asign values
                        txtLocationID.Tag = detail.FromStore_ID;
                        txtDepartmentID.Tag = detail.ToDepartment_ID;
                        txtSectionID.Tag = detail.ToSection_ID;
                        txtStoreID.Tag = detail.ToStore_ID;
                        txtSRNID.Tag = detail.SectionRequisitionNote_ID;
                        txtJobID.Tag = detail.Job_ID;

                        //fill order detials
                        tbl_zIssuedRefNo order = tbl_zIssuedRefNo.Select(detail.IssuedRefNo_ID);
                        if (order != null)
                        {
                            txtOrderRefNo.Tag = order.IssuedRefNo_ID;
                            txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(order.IssuedRefNo);
                        }

                        txtGoodIssueNoteID.Text = detail.StoreGoodIssueNote_ID;
                        txtRemark.Text = detail.Remark;
                        dtpGINDate.Value = detail.StoreGoodIssueNoteDate;
                        txtLocationID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(detail.FromStore_ID));
                        txtDepartmentID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Department(detail.ToDepartment_ID));
                        txtSectionID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Section(detail.ToSection_ID));
                        txtStoreID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(detail.ToStore_ID));
                        //txtToLocationID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(detail.ToStore_ID));
                        txtSRNID.Text = clsCommon.GetForeignKeyValue(detail.StoreRequisitionNote_ID);
                        txtJobID.Text = clsCommon.GetForeignKeyValue(detail.Job_ID);
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

                        if (txtDepartmentID.Tag != null || txtSectionID.Tag != null || txtStoreID.Tag != null)
                            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtItemID, true);

                        //fill item details
                        RefreshGrid(detail.StoreGoodIssueNote_ID);

                        Attachments.FillAttachments(sID);

                        //Set Flow
                        clsHelpMethods_Local.SetProcessFlow_Stock_Internal(detail.IssuedRefNo_ID, txtFlowSR, txtFlowGIN, txtFlowGRN);
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void FillDetailsFromSR(string sSR_ID)
        {
            tbl_scsDepartmentReqositionNote oSR_Department = tbl_scsDepartmentReqositionNote.Select(txtSRNID.Text.Trim());
            if (oSR_Department != null)
            {
                FillDetailsTextBoxes(oSR_Department.FromDepartment_ID, "default", "default", oSR_Department.ToStore_ID, sSR_ID, oSR_Department.IssuedRefNo_ID, "default");
                RefreshGridByDepartmentSRN_ID(oSR_Department.DepartmentReqositionNote_ID);
            }

            tbl_scsSectionReqositionNote oSR_Section = tbl_scsSectionReqositionNote.Select(txtSRNID.Text.Trim());
            if (oSR_Section != null)
            {
                FillDetailsTextBoxes("default", oSR_Section.FromSection_ID, "default", oSR_Section.ToStore_ID, sSR_ID, oSR_Section.IssuedRefNo_ID, "default");
                RefreshGridBySectionSRN_ID(oSR_Section.SectionReqositionNote_ID);
            }

            tbl_scsStoreReqositionNote oSR_Store = tbl_scsStoreReqositionNote.Select(txtSRNID.Text.Trim());
            if (oSR_Store != null)
            {
                FillDetailsTextBoxes("default", "default", oSR_Store.FromStore_ID, oSR_Store.ToStore_ID, sSR_ID, oSR_Store.IssuedRefNo_ID, oSR_Store.ItemPriceCategory);
                RefreshGridByStoreSRN_ID(oSR_Store.StoreRecositionNote_ID);
            }
        }
        private void FillDetailsTextBoxes(string sDepartmentID, string sSectionID, string sStoreID, string sLocationID, string sRequisitionID, string sIssueRefID, string sItemPriceCategory)
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemID, false);
            clsCommon.SetEnableDisable_NormalLabel(lblItem, false);
            btnF5.Enabled = false;

            txtDepartmentID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Department(sDepartmentID));
            txtSectionID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Section(sSectionID));
            txtStoreID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(sStoreID));
            txtLocationID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(sLocationID));

            txtDepartmentID.Tag = sDepartmentID;
            txtSectionID.Tag = sSectionID;
            txtStoreID.Tag = sStoreID;
            txtLocationID.Tag = sLocationID;

            txtSRNID.Text = sRequisitionID;
            txtSRNID.Tag = sRequisitionID;

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
        private void RefreshGrid(string sGINID)
        {
            try
            {
                int iRow;
                decimal dTotQty = 0, dTotWeight = 0;
                dgvDetail.Rows.Clear();

                List<tbl_scsStoreGoodIssueNote_Detail> details = tbl_scsStoreGoodIssueNote_Detail.SelectAllByStoreGoodIssueNote_ID(sGINID).OrderBy(p => p.Line_No).ToList();
                foreach (tbl_scsStoreGoodIssueNote_Detail detail in details)
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    string sMettle = "N/A", sGem = "N/A";
                    string sToLocation = clsHelpMethods_Local.getToLocationName(detail.ToSelectArea_ID, detail.ToDepartment_ID, detail.ToSection_ID, detail.ToStore_ID);
                    string sNoteID = clsHelpMethods_Local.GetSelectAreaNoteID(detail.ToSelectArea_ID, detail.DepartmentReqositionNote_ID, detail.SectionRequisitionNote_ID, detail.StoreRequisitionNote_ID);
                    decimal dSellingPrice = 0, dCostPrice = 0;
                    decimal dFloorStockQty = clsHelpMethods_Local.GetFlowStock_Qty(dtpGINDate.Value.Date, detail.Item_ID, detail.FromStore_ID);

                    //dTotQty = 0, dTotWeight = 0, 
                    //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.gem.ToString())
                    //{
                    //    tbl_zItemSerialNo oIGem = tbl_zItemSerialNo.Select(detail.ItemSerialNo);
                    //    if (oIGem != null)
                    //    {
                    //        sMettle = oIGem.MetalDetail;
                    //        sGem = oIGem.GemDetail;
                    //        dSellingPrice = oIGem.SellingPrice;
                    //        dCostPrice = oIGem.CostPrice;
                    //    }
                    //    clsHelpMethods_Local.Fill_StockDatagridItemGem(dgvDetail, iRow, detail.Item_ID, detail.Uom_ID, detail.Job_ID, detail.ToSelectArea_ID, detail.ToDepartment_ID, detail.ToSection_ID,
                    //        detail.ToStore_ID, detail.DepartmentReqositionNote_ID, detail.SectionRequisitionNote_ID, detail.StoreRequisitionNote_ID,
                    //       sToLocation, sNoteID, detail.Qty, detail.Weight, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, "N", sMettle, sGem, dSellingPrice, dCostPrice);
                    //}
                    //else
                    {
                        clsHelpMethods_Local.Fill_StockDatagrid(dgvDetail, iRow, detail.Line_No, detail.Item_ID, detail.Uom_ID, detail.Job_ID, detail.ToSelectArea_ID, detail.ToDepartment_ID, detail.ToSection_ID,
                            detail.ToStore_ID, detail.DepartmentReqositionNote_ID, detail.SectionRequisitionNote_ID, detail.StoreRequisitionNote_ID,
                           sToLocation, sNoteID, detail.Qty, detail.Weight, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, 
                           detail.ItemSerialNo2, "O", detail.UnitPrice, detail.TotalAmount, detail.Remark, dFloorStockQty);
                    }

                    dTotQty += detail.Qty;
                    dTotWeight += detail.Weight;
                }//detail.Item_ID
                txtTotQty.Text = clsFormatter.FormatDecimalPlaces_Quantity(dTotQty);
                txtTotWeight.Text = clsFormatter.FormatDecimalPlaces_Weight(dTotWeight);

            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        //private void RefreshGridByJob_ID(string sJob_ID)
        //{
        //    try
        //    {

        //        int iRow;
        //        List<tbl_pmsPrePlan> PrePlans = tbl_pmsPrePlan.SelectAllByProductionJob_ID(sJob_ID);
        //        foreach (tbl_pmsPrePlan PrePlan in PrePlans)
        //        {
        //            List<tbl_pmsPrePlan_SectionPath_InputItem> inputs = tbl_pmsPrePlan_SectionPath_InputItem.SelectAllByPrePlan_ID(PrePlan.PrePlan_ID);
        //            foreach (tbl_pmsPrePlan_SectionPath_InputItem input in inputs)
        //            {
        //                dgvDetail.Rows.Add();
        //                iRow = dgvDetail.Rows.Count - 1;
        //                ValidateEmptyForeignKey();
        //                string sToLocation = clsHelpMethods_Local.getToLocationName(txtDepartmentID, txtSectionID, txtStoreID);
        //                string sNoteID = "N/A";

        //                tbl_genItemMaster item = tbl_genItemMaster.Select(input.Item_ID);
        //                if (item != null)
        //                {
        //                    clsHelpMethods_Local.Fill_StockDatagrid(dgvDetail, iRow, input.Line_No, item.Item_ID, item.Uom_ID, sJob_ID, getSelectAriaID(), getToDepartment(), getToSection(),
        //                        getToStore(), getDepartmentSRN(), getSectionSRN(), getStoreSRN(), sToLocation, sNoteID, input.Qty, input.Weight,
        //                        "default", "default", "0", "0", "N", 0, 0, "", 0);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        SEACCException.Show(ex);
        //        clsValidate.WriteErrorLog("", iFormID, ex);
        //    }
        //}
        private void RefreshGridBySectionSRN_ID(string sGIN_ID)
        {
            try
            {
                int iRow;
                List<tbl_scsSectionReqositionNote_Detail> details = tbl_scsSectionReqositionNote_Detail.SelectAllBySectionReqositionNote_ID(sGIN_ID);
                foreach (tbl_scsSectionReqositionNote_Detail detail in details)
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    ValidateEmptyForeignKey();
                    string sFromLocation = clsGenaralName.getName_Section(detail.FromSection_ID);
                    string sFromNoteID = detail.SectionReqositionNote_ID;
                    decimal dFloorStockQty = clsHelpMethods_Local.GetFlowStock_Qty(dtpGINDate.Value.Date, detail.Item_ID, detail.ToSection_ID);

                    clsHelpMethods_Local.Fill_StockDatagrid(dgvDetail, iRow, detail.Line_No, detail.Item_ID, detail.Uom_ID, detail.Job_ID, getSelectAriaID(), getToDepartment(),
                    getToSection(), getToStore(), "default", detail.SectionReqositionNote_ID, "default", sFromLocation, sFromNoteID, detail.Qty, detail.Weight,
                    detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, "N", 0, 0, "", dFloorStockQty);

                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void RefreshGridByStoreSRN_ID(string sGIN_ID) // -K- Changed
        {
            try
            {
                int iRow;
                List<tbl_scsStoreReqositionNote_Detail> details = tbl_scsStoreReqositionNote_Detail.SelectAllByStoreRecositionNote_ID(sGIN_ID);
                foreach (tbl_scsStoreReqositionNote_Detail detail in details)
                {
                    string sFromLocation = clsGenaralName.getName_Store(detail.FromStore_ID);
                    string sFromNoteID = detail.StoreRecositionNote_ID;
                    decimal dQty = detail.Qty - detail.QtySettle, dWeight = detail.Weight - detail.WeightSettle;

                    if (dQty > 0 || dWeight > 0)//didnot display zero qty item
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        decimal dFloorStockQty = clsHelpMethods_Local.GetFlowStock_Qty(dtpGINDate.Value.Date, detail.Item_ID, detail.ToStore_ID);

                        clsHelpMethods_Local.Fill_StockDatagrid(dgvDetail, iRow, detail.Line_No, detail.Item_ID, detail.Uom_ID, detail.Job_ID, detail.ToSelectArea_ID, detail.ToDepartment_ID,
                        detail.ToSection_ID, detail.ToStore_ID, "default", "default", detail.StoreRecositionNote_ID, sFromLocation, sFromNoteID, dQty, dWeight,
                        detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, "N", detail.UnitPrice, detail.TotalAmount, "", dFloorStockQty);
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void RefreshGridByDepartmentSRN_ID(string sGIN_ID)
        {
            try
            {
                int iRow;
                List<tbl_scsDepartmentReqositionNote_Detail> details = tbl_scsDepartmentReqositionNote_Detail.SelectAllByDepartmentReqositionNote_ID(sGIN_ID);
                foreach (tbl_scsDepartmentReqositionNote_Detail detail in details)
                {
                    string sFromLocation = clsGenaralName.getName_Department(detail.FromStore_ID);
                    string sFromNoteID = detail.DepartmentReqositionNote_ID;
                    decimal dQty = detail.Qty - detail.QtySettle, dWeight = detail.Weight - detail.WeightSettle;

                    if (dQty > 0 || dWeight > 0)//didnot display zero qty item
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        decimal dFloorStockQty = clsHelpMethods_Local.GetFlowStock_Qty(dtpGINDate.Value.Date, detail.Item_ID, detail.ToDepartment_ID);

                        clsHelpMethods_Local.Fill_StockDatagrid(dgvDetail, iRow, detail.Line_No, detail.Item_ID, detail.Uom_ID, detail.Job_ID, getSelectAriaID(), detail.ToDepartment_ID,
                        detail.ToSection_ID, detail.ToStore_ID, detail.DepartmentReqositionNote_ID, "default", "default", sFromLocation, sFromNoteID, dQty, dWeight,
                        detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, "N", 0, 0, "", dFloorStockQty);
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void RefreshGridByItem_ID(string sItem_ID)
        {
            try
            {
                int iRow;
                string sJobID = "default";
                decimal dTotQty = 0, dTotWeight = 0;
                tbl_genItemMaster detail = tbl_genItemMaster.Select(sItem_ID);
                tbl_genItemMaster_Pricing oItemF = tbl_genItemMaster_Pricing.Select(sItem_ID);
                if (detail != null && oItemF != null)
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    if (txtJobID.Tag != null && clsConfig.bJobIdRequiredGIN)
                        sJobID = txtJobID.Tag.ToString();
                    string sToLocation = clsHelpMethods_Local.getToLocationName(txtDepartmentID, txtSectionID, txtStoreID);
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
                    //    clsHelpMethods_Local.Fill_StockDatagridItemGem(dgvDetail, iRow, detail.Item_ID, detail.Uom_ID, sJobID, getSelectAriaID(), getToDepartment(), getToSection(),
                    //        getToStore(), getDepartmentSRN(), getSectionSRN(), getStoreSRN(), sToLocation, sNoteID, 0, 0,
                    //        txtItemSubCategory.Tag.ToString(), txtItemSubCategory.Text.Trim(), txtItemSerialNo.Tag.ToString(), txtItemSerialNo.Text.Trim(), "N", sMettle, sGem, dSellingPrice, dCostPrice);
                    //}
                    //else
                    //   {
                    decimal dUnitPrice = 0;
                    string sItemPriceCategory = ((ComboBoxItem)cmbItemPrice.SelectedItem).Value;
                    dUnitPrice = clsProcessMethods.GetRecommendedUnitPrice_Basic(detail.Item_ID, sItemPriceCategory);
                    var maxLineNo = dgvDetail.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["LineNo"].Value));
                    decimal dFloorStockQty = clsHelpMethods_Local.GetFlowStock_Qty(dtpGINDate.Value.Date, sItem_ID, txtLocationID.Tag.ToString());


                    clsHelpMethods_Local.Fill_StockDatagrid(dgvDetail, iRow, maxLineNo + 1, detail.Item_ID, detail.Uom_ID, sJobID, getSelectAriaID(), getToDepartment(), getToSection(),
                    getToStore(), getDepartmentSRN(), getSectionSRN(), getStoreSRN(), sToLocation, sNoteID, 1, 0,
                    txtItemSubCategory.Tag.ToString(), txtItemSubCategory.Text.Trim(), txtItemSerialNo.Tag.ToString(), txtItemSerialNo.Text.Trim(), "N", dUnitPrice, dUnitPrice, "", dFloorStockQty);
                    dgvDetail.Focus();
                    //    }
                    // dTotQty++;
                    //  dTotWeight += oGRNGem.MetalWeight;

                }

                txtTotQty.Text = clsFormatter.FormatDecimalPlaces_Quantity(dTotQty);
                txtTotWeight.Text = clsFormatter.FormatDecimalPlaces_Weight(dTotWeight);
                // 

            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void RefreshGridByGRN()
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                string sBranchID = "default";// sMettle = "N/A", sGem = "N/A";sUMO = "default",
                decimal dTotQty = 0, dTotWeight = 0;// dSellingPrice = 0, dCostPrice = 0;
                tbl_genStoreMaster oStore = tbl_genStoreMaster.Select(txtStoreID.Tag.ToString().Trim());
                if (oStore != null)
                    sBranchID = oStore.CompanyBranch_ID;


                foreach (tbl_scsExternalGoodReceivedNote detail in tbl_scsExternalGoodReceivedNote.SelectAll().Where(p => p.ExternalGoodReceivedNote_ID != "default" && !p.IsDeleted && p.Store_ID == txtLocationID.Tag.ToString().Trim() && p.StockNoteType_ID == ((ComboBoxItem)cmbStockNoteType.SelectedItem).Value && p.IsApproved))
                {
                    //foreach (tbl_scsExternalGoodReceivedNote_Detail_Gem oGRNGem in tbl_scsExternalGoodReceivedNote_Detail_Gem.SelectAllByCompanyBranch_ID(sBranchID).Where(p => !p.IsTransferred && !p.IsLocked && p.ExternalGoodReceivedNote_ID == detail.ExternalGoodReceivedNote_ID))
                    //{
                    //    dgvDetail.Rows.Add();
                    //    iRow = dgvDetail.Rows.Count - 1;

                    //    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oGRNGem.Item_ID);
                    //    if (oItem != null)
                    //    {
                    //        sUMO = oItem.Uom_ID;                      
                    //        dCostPrice = oItem.CostPrice;
                    //    }
                    //    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.gem.ToString())
                    //    {                       
                    //        sMettle = oGRNGem.MetalDetail;
                    //        sGem = oGRNGem.GemDetail;
                    //        dSellingPrice = oGRNGem.SellingPrice;
                    //        dCostPrice = oGRNGem.SellingPrice;

                    //        clsHelpMethods.Fill_StockDatagridItemGem(dgvDetail, iRow, oGRNGem.Item_ID, sUMO, "default", clsAutocode.getSelectAreaCode(SelectArea.Store), "default", "default", txtStoreID.Tag.ToString().Trim(),
                    //            "default", "default", detail.ExternalGoodReceivedNote_ID, txtLocationID.Text, detail.ExternalGoodReceivedNote_ID, 1, oGRNGem.MetalWeight, oGRNGem.ItemSubCategory_ID,
                    //            oGRNGem.ItemSubCategory2_ID, oGRNGem.ItemSerialNo, oGRNGem.ItemSerialNo2, "O", sMettle, sGem, dSellingPrice, dCostPrice);
                    //    }
                    //    else
                    //    {
                    //        clsHelpMethods.Fill_StockDatagrid(dgvDetail, iRow, oGRNGem.Item_ID, sUMO, "default", clsAutocode.getSelectAreaCode(SelectArea.Store), "default", "default", txtStoreID.Tag.ToString().Trim(),
                    //            "default", "default", detail.ExternalGoodReceivedNote_ID, txtLocationID.Text, detail.ExternalGoodReceivedNote_ID, 1, oGRNGem.MetalWeight, oGRNGem.ItemSubCategory_ID,
                    //            oGRNGem.ItemSubCategory2_ID, oGRNGem.ItemSerialNo, oGRNGem.ItemSerialNo2, "O", 0, 0);
                    //    }
                    //    dTotQty++;
                    //    dTotWeight += oGRNGem.MetalWeight;
                    //}
                }

                txtTotQty.Text = clsFormatter.FormatDecimalPlaces_Quantity(dTotQty);
                txtTotWeight.Text = clsFormatter.FormatDecimalPlaces_Weight(dTotWeight);

            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
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
                    clsEvent.StockGrid_CellDoubleClick(sender, e, dgvDetail);
                    string sItemCode = dgvDetail["ItemCode", e.RowIndex].Value.ToString();
                    clsHelpMethods_Local.SetItemImage(sItemCode, ref pbxImage);
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
            UpdateTotalQty();
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
        private void dgvDetail_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Up || e.KeyData == Keys.Down || e.KeyData == Keys.Left || e.KeyData == Keys.Right)
                {
                    string sItemCode = dgvDetail["ItemCode", dgvDetail.SelectedCells[0].RowIndex].Value.ToString();
                    clsHelpMethods_Local.SetItemImage(sItemCode, ref pbxImage);
                }
                else if (e.KeyData == Keys.F1)
                {
                    txtItemID.Focus();
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

        #region Events DoubleClick
        private void txtGoodreceivedNoteID_DoubleClick(object sender, EventArgs e)
        {
            Search_StoreGoodIssuneNote();
        }
        private void txtJobOder_DoubleClick(object sender, EventArgs e)
        {
            clearItamAndJob();
            Search_JobID();
        }
        private void txtGINNoStore_DoubleClick(object sender, EventArgs e)
        {
            clearItamAndJob();
            loadSRNnumber();
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
        private void txtDepartmentID_DoubleClick(object sender, EventArgs e)
        {
            clearLocationFields();
            Search_Department();
        }
        private void txtSectionID_DoubleClick_1(object sender, EventArgs e)
        {
            clearLocationFields();
            Search_Section();
        }
        private void txtStoreID_DoubleClick_1(object sender, EventArgs e)
        {
            clearLocationFields();
            Search_Store();
        }
        private void txtItemID_DoubleClick(object sender, EventArgs e)
        {
            clearItamAndJob();
            Search_ItemID(sender, new KeyEventArgs(Keys.F1));
        }

        #endregion

        #region Events KeyDown
        private void txtGoodreceivedNoteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_StoreGoodIssuneNote();
            }
        }
        private void txtGINNoSection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_SectionStoreReqositionNote();
            }
        }
        private void txtGINNoStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clearItamAndJob();
                loadSRNnumber();
            }
        }
        private void txtLocationID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_StoreTo();
            }
            else if (e.KeyCode == Keys.Tab)
            {
                txtStoreID.Focus();
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
                frm_scsStoreGoodIssueNote_SF_newButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F10)
            {
                frm_scsStoreGoodIssueNote_SF_saveButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F11)
            {
                btnRemove_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F12)
            {
                frm_scsStoreGoodIssueNote_SF_printButton_Click(sender, e);
            }
        }
        private void txtJobOder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clearItamAndJob();
                Search_JobID();
            }
        }
        private void txtDepartmentID_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clearLocationFields();
                Search_Department();
            }
        }
        private void txtSectionID_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clearLocationFields();
                Search_Section();
            }
        }
        private void txtStoreID_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clearLocationFields();
                Search_Store();
            }
            else if (e.KeyCode == Keys.Tab)
            {
                txtOrderRefNo.Focus();
            }
        }
        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            Search_ItemID(sender, e);
        }
        private void txtOrderRefNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                cmbStockNoteType.Focus();
            }
        }
        private void cmbStockNoteType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                cmbItemPrice.Focus();
            }
        }

        private void cmbItemPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtItemID.Focus();
            }
            if (e.KeyCode == Keys.F1)
            {
                txtItemID.Focus();
            }
        }
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

        #region Events KeyPress
        private void cmbStockNoteType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

        #region Check Validity
        private bool CheckJobNoValidity()
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
        private bool CheckValidity_EmptyValue()
        {
            bool bStatus = true;
            if (!clsValidate.ValidateTextBox_EmptyValue(txtLocationID, "Issuer"))
                bStatus = false;

            if (clsConfig.bMandatoryFieldEnable_iGIN_RefNo)
            {
                //if (!clsValidate.ValidateTextBox_EmptyValue(txtOrderRefNo, "Issue Ref No"))
                //    bStatus = true;
            }

            if (!bStatus && clsConfig.bMandatoryFieldEnable_iGIN_JobNo)
            {
                if (!clsValidate.ValidateTextBox_EmptyValue(txtJobID, "Job Order"))
                    bStatus = true;
            }

            return bStatus;
        }
        #region Old CheckStockValidity
        //private bool CheckStockValidity()
        //{

        //    string strMessage = "", sOriginalItemCode = "", sItemCode = "", sItemStatus = "", sSubCategoryID1 = "", sSubCategoryID2 = "", sSerialNo1 = "", sSerialNo2 = "", sJobCode = "";
        //    decimal dWeight = 0;
        //    decimal dQty = 0;
        //    bool bStatus = true;
        //    //if (clsConfig.bStockExceedLock_iGIN)
        //    //{
        //    foreach (DataGridViewRow row in dgvDetail.Rows)
        //    {
        //        sOriginalItemCode = sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
        //        dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
        //        dQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
        //        sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
        //        sSubCategoryID1 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
        //        sSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
        //        sSerialNo1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
        //        sSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
        //        sItemStatus = clsValidate.ValidateGridValue(dgvDetail, "ItemStatus", row.Index, "");

        //        if (dWeight <= 0 && dQty <= 0)
        //        {
        //            bStatus = false;
        //            strMessage = "item " + sOriginalItemCode + " Qty and Weight are Incorrect.";
        //            break;
        //        }

        //        if (!clsConfig.bStoreStockWithJobID)
        //            sJobCode = "default";

        //        //check whether single item stock enabled
        //        if (clsConfig.bSingleItemStockEnabled)
        //        {
        //            if (!clsHelpMethods_Local.IsItemRawMaterial(sItemCode))
        //                clsHelpMethods_Local.AssignSingleStockItemDetail(ref sItemCode, ref sSubCategoryID1, ref sSubCategoryID2, ref sSerialNo1, ref sSerialNo2);
        //        }

        //        //validate stock detail
        //        #region Validate Stock Details
        //        tbl_genStore_Stock stock = tbl_genStore_Stock.Select(txtLocationID.Tag.ToString(), sItemCode, sJobCode, sSubCategoryID1, sSubCategoryID2, sSerialNo1, sSerialNo2);
        //        if (stock != null)
        //        {
        //            if (sItemStatus.ToLower() == "o") //new item
        //            {
        //                #region Old Items Stock Validation
        //                List<tbl_scsStoreGoodIssueNote_Detail> oldDetails = tbl_scsStoreGoodIssueNote_Detail.SelectAllByStoreGoodIssueNote_ID(txtGoodIssueNoteID.Text.Trim());
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
        //                                strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required Quantity Is Not Availabe As IT Is In " + clsGenaralName.getName_Store(txtLocationID.Tag.ToString()) + "\n";
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
        //                                strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required Weight Is Not Availabe As IT Is In " + clsGenaralName.getName_Store(txtLocationID.Tag.ToString()) + "\n";
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
        //                if (stock.Weight >= 0 && stock.Weight < dWeight && clsConfig.bStockValidateWeight_iGIN) //check whether stock enabled - qty
        //                {
        //                    strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required Weight Is Not Availabe As IT Is In  " + clsGenaralName.getName_Store(txtLocationID.Tag.ToString()) + "\n";
        //                    bStatus = false;
        //                }
        //                if (stock.Qty >= 0 && stock.Qty < dQty && clsConfig.bStockValidateQty_iGIN) //check whether stock enabled - weight
        //                {
        //                    strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + "  Required Quantity Is Not Availabe As IT Is In " + clsGenaralName.getName_Store(txtLocationID.Tag.ToString()) + "\n";
        //                    bStatus = false;
        //                }
        //                #endregion
        //            }
        //        }
        //        else //No stock in selected store
        //        {
        //            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Is Not Available In " + clsGenaralName.getName_Store(txtLocationID.Tag.ToString()) + " Stock\n";
        //            bStatus = false;
        //        }
        //        #endregion
        //    }

        //    if (bStatus == false)
        //    {
        //        MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    //}
        //    return bStatus;
        //}
        #endregion

        private bool CheckStockValidity()
        {
            string strMessage = "", sItemCode = "", sItemStatus = "", sJobCode = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "";
            decimal dWeight = 0;
            decimal dQty = 0;
            bool bStatus = true;

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

                if (!clsHelpMethods_Local.IsNonInventoryItem(sItemCode))
                {
                    tbl_genStore_Stock oStoreStock;
                    oStoreStock = tbl_genStore_Stock.Select(txtLocationID.Tag.ToString(), sItemCode, sJobCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                    if (oStoreStock == null)
                    {
                        oStoreStock = new tbl_genStore_Stock(txtLocationID.Tag.ToString(), sItemCode, "default", "default", "default", "0", "0", 0, 0, 0, 0, 0, 0, 0, 0);
                        oStoreStock.Insert();
                    }
                                        
                    tbl_genStoreMaster oStore = tbl_genStoreMaster.Select(txtLocationID.Tag.ToString());
                    if (oStoreStock != null && oStore != null)
                    {
                        #region if the item is old and check stock for more than one time
                        if (sItemStatus.ToLower() == "o")
                        {
                            decimal dOldQty = 0, dOldWeight = 0;
                            foreach (tbl_scsStoreGoodIssueNote_Detail oIGINDetail in tbl_scsStoreGoodIssueNote_Detail.SelectAllByStoreGoodIssueNote_ID(txtGoodIssueNoteID.Text.Trim()).Where(p => p.Item_ID == sItemCode && p.ItemSubCategory_ID == sItemSubCategoryID && p.ItemSubCategory2_ID == sItemSubCategoryID2))
                            {
                                dOldQty += oIGINDetail.Qty;
                                dOldWeight += oIGINDetail.Weight;
                            }

                            #region Old Items Quantity Validation
                            if (clsConfig.bStockValidateQty_iGIN)
                            {
                                if (oStoreStock.Qty + dOldQty < dQty)
                                {
                                    strMessage += "Required Quantity of Item: \"" + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\" is not Availabe in  store :\"" + clsGenaralName.getName_Store(txtLocationID.Tag.ToString()) + "\"\n";
                                    bStatus = false;
                                }
                            }
                            #endregion

                            #region Old Items Weight Validation
                            if (clsConfig.bStockValidateWeight_iGIN)
                            {
                                if (oStoreStock.Weight + dOldWeight < dWeight)
                                {
                                    strMessage += " Required Weight of Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "is Not Availabe In  store :" + clsGenaralName.getName_Store(txtLocationID.Tag.ToString()) + "\n";
                                    bStatus = false;
                                }
                            }
                            #endregion

                            if (!oStore.IsAllowMinusStock)
                            {
                                if (oStoreStock.Qty + dOldQty - dQty < 0)
                                {
                                    strMessage += "Minus Quantities are not allowed - " + clsGenaralName.getName_Store(txtLocationID.Tag.ToString()) + "\"" + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\"\n";
                                    bStatus = false;
                                }
                            }
                        }
                        #endregion

                        #region first time added item ant have to check stock
                        else
                        {
                            #region Weight Validation
                            if (oStoreStock.Weight < dWeight && clsConfig.bStockValidateWeight_iGIN)
                            {
                                strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + " Required Weight Is Not Availabe As IT Is In  " + clsGenaralName.getName_Store(txtLocationID.Tag.ToString()) + "\n";
                                bStatus = false;
                            }
                            #endregion

                            #region New Item Quantity Validation
                            if (oStoreStock.Qty < dQty && clsConfig.bStockValidateQty_iGIN)
                            {
                                strMessage += "Required Quantity of Item: \"" + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\" is not Availabe in store :\"" + clsGenaralName.getName_Store(txtLocationID.Tag.ToString()) + "\"\n";
                                bStatus = false;
                            }
                            #endregion

                            if (!oStore.IsAllowMinusStock)
                            {
                                if (oStoreStock.Qty - dQty < 0)
                                {
                                    strMessage += "Minus Quantities are not allowed - " + clsGenaralName.getName_Store(txtLocationID.Tag.ToString()) + "\"" + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\"\n";
                                    bStatus = false;
                                }
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        if ((clsConfig.bStockValidateQty_iGIN || clsConfig.bStockValidateWeight_iGIN) && !clsHelpMethods_Local.IsNonInventoryItem(sItemCode) && (clsConfig.sSoftwareModel.Trim() != SoftwareModel_Sales.akt.ToString()))
                        {
                            strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "  Is Not Available In " + clsGenaralName.getName_Store(txtLocationID.Tag.ToString()) + " Stock\n";
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
                     //   tbl_pmsProductionJobRegister job = tbl_pmsProductionJobRegister.Select(sJobID);
                      ////  if (job != null && job.ProductionJob_ID != "default")
                      //  {
                      //      tbl_genCustomerMaster customer = tbl_genCustomerMaster.Select(job.Customer_ID);
                      //      if (customer != null && customer.Customer_ID != "default")
                      //      {
                      //          if (customer.IsBlacklisted)
                      //          {
                      //              bStatus = false;
                      //              MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.CustomerIsBlackListed), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                      //          }
                      //      }
                      //  }
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
        private bool ValidateForDependancies(string sGINId)
        {
            bool bValue = true;
            try
            {
                foreach (tbl_scsStoreGoodReceiveNote oGRN in tbl_scsStoreGoodReceiveNote.SelectAll().Where(p => !p.IsDeleted && p.StoreGoodReceiveNote_ID != "default" && p.StoreGoodIssueNote_ID == sGINId))
                {
                    bValue = false;
                    MessageBox.Show("Record Is Locked! \n\n[" + oGRN.StoreGoodReceiveNote_ID + "] Good Receive Note is already created for this Good Issue Note", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            return bValue;
        }
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            clsCommon.ValidateForeignKey(ref txtDepartmentID);
            clsCommon.ValidateForeignKey(ref txtSectionID);
            clsCommon.ValidateForeignKey(ref txtStoreID);
            clsCommon.ValidateForeignKey(ref txtJobID);
            clsCommon.ValidateForeignKey(ref txtItemID);
            clsCommon.ValidateForeignKey(ref txtSRNID);
        }
        #endregion

        #region Search Methods
        private void Search_StoreGoodIssuneNote()
        {
            if (txtLocationID.Tag != null && txtStoreID.Tag != null)
                clsSearch.Search_TransactionStoreGoodsIssueNote(ref txtGoodIssueNoteID, chkShowSettle.Checked, true, txtLocationID.Tag.ToString().Trim(), txtStoreID.Tag.ToString().Trim());
            else
                clsSearch.Search_TransactionStoreGoodsIssueNote(ref txtGoodIssueNoteID, chkShowSettle.Checked, true, "", "");

            if (txtGoodIssueNoteID.Text.Trim().Length > 0)
            {
                FillDetails(txtGoodIssueNoteID.Text.Trim());
            }
        }
        private void Search_DepartmentStoreReqositionNote()
        {
            clsSearch.Search_TransactionDepartmentStoreReqositionNote_Use(ref txtSRNID, txtDepartmentID.Tag.ToString());
        }
        private void Search_SectionStoreReqositionNote()
        {
            clsSearch.Search_TransactionSectionStoreReqositionNote_Use(ref txtSRNID, txtSectionID.Tag.ToString());
        }
        private void Search_StoreGoodReqositionNote()
        {
            //clsSearch.Search_TransactionStoreStoreReqositionNote_Use(ref txtSRNID, txtStoreID.Tag.ToString());
            clsSearch.Search_TransactionStoreReqositionNote(ref txtSRNID, false, false, txtStoreID.Tag.ToString());
            if (txtSRNID.Text.Trim().Length > 0)
                btnAddStore_Click(null, null);
        }
        private void Search_Section()
        {
            clsSearch.Search_MasterSection(ref txtSectionID);
            if (txtSectionID.Tag != null)
                setEnableItems(true);
        }
        private void Search_Store()
        {
            clsSearch.Search_MasterStore(ref txtStoreID, clsConfig.enableBranchWiseFilterOnSearch ? true : false);
            if (txtStoreID.Tag != null)
            {
                setEnableItems(true);
                txtOrderRefNo.Focus();
            }
        }
        private void Search_Department()
        {
            clsSearch.Search_MasterDepartment(ref txtDepartmentID);
            if (txtDepartmentID.Tag != null)
                setEnableItems(true);
        }
        private void Search_StoreTo()
        {
            clsSearch.Search_MasterStore(ref txtLocationID, clsConfig.enableBranchWiseFilterOnSearch ? true : false);
            if (txtLocationID.Tag != null)
            {
                //setEnableItems(true);
                txtStoreID.Focus();
            }
        }
        private void Search_JobID()
        {
            clsSearch.Search_TransactionProductionJobRegister(ref txtJobID);

            if (txtJobID.Text.Trim().Length > 0)
                btnJobOder_Click(null, null);
        }
        private void Search_ItemID(object sender, KeyEventArgs e)
        {
            if (CheckValidity_EmptyValue())
            {
                if (!clsConfig.bJobIdRequiredGIN)
                    clearItamAndJob();

                string sStoreID = "", sSectionID = "", sDepartmentID = "";
                if (txtLocationID.Tag != null && txtLocationID.Tag.ToString().Trim().Length > 0)
                    sStoreID = txtLocationID.Tag.ToString();

                if (e.KeyCode == Keys.F1)
                {
                    //clsHelpMethods_Local.SearchItemAdvanceStock(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo, sStoreID, sSectionID, sDepartmentID);
                    clsSearch.Search_TransactionItemMasterByStore2(ref txtItemID, sStoreID);
                    if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                        btnAddItem_Click(btnAddItem, new EventArgs());
                }
                else if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4)
                {
                    clsHelpMethods_Local.SearchItemAdvanceByKeyPress(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo, e);
                    if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                        btnAddItem_Click(sender, new EventArgs());
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
                //            string sToLocation = clsHelpMethods_Local.getToLocationName(txtDepartmentID, txtSectionID, txtStoreID);
                //            string sNoteID = "N/A";
                //            decimal dFlowStockQty = clsHelpMethods_Local.GetFlowStock_Qty(dtpGINDate.Value.Date, oItem.sItemID, txtLocationID.Tag.ToString());

                //            clsHelpMethods_Local.Fill_StockDatagrid(dgvDetail, iRow, dgvDetail.Rows.Count, oItem.sItemID, oItem.sUOMID, txtJobID.Text.Trim(), getSelectAriaID(), 
                //                getToDepartment(), getToSection(), getToStore(), getDepartmentSRN(), getSectionSRN(), getStoreSRN(), sToLocation, sNoteID, oItem.dQty, oItem.dWeight, 
                //                oItem.sItemSubCategoryID, oItem.sItemSubCategoryID2, oItem.sItemSerialNo, oItem.sItemSerialNo2, "N", oItem.dUnitPrice, oItem.dTotalAmount, "", dFlowStockQty);
                //        }
                //    }
                //}
                else if (e.KeyCode == Keys.Enter)
                {
                    if (clsValidate.Validate_ItemCode(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo))
                    {
                        if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                            btnAddItem_Click(sender, new EventArgs());
                    }
                }
            }

            UpdateTotalQty();
        }
        private void UpdateTotalQty()
        {
            decimal dQuantity = 0, dAmmount = 0;
            if (dgvDetail.RowCount > 0)
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    dQuantity += clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                }
            }
            txtTotQty.Text = clsFormatter.FormatDecimalPlaces_Quantity(dQuantity);
        }
        #endregion

        #region Set Enable/Desable Items
        private void setEnableItems(bool Val)
        {
            clearItamAndJob();
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemID, Val);
            clsCommon.SetEnableDisable_NormalLabel(lblItem, Val);
            btnAddItem.Enabled = Val;
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtJobID, Val);
            clsCommon.SetEnableDisable_NormalLabel(lblJob, Val);
            btnAddJob.Enabled = Val;
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSRNID, Val);
            clsCommon.SetEnableDisable_NormalLabel(lblSRN, Val);
            btnAddSRN.Enabled = Val;
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

        #region Get Select To Location
        private string getSelectToLocationID()
        {
            string rtn = "";
            if (txtDepartmentID.Tag != null)
                rtn = clsGenaralName.getName_Department(txtDepartmentID.Tag.ToString());
            else if (txtSectionID.Tag != null)
                rtn = clsGenaralName.getName_Section(txtSectionID.Tag.ToString());
            else if (txtStoreID.Tag != null)
                rtn = clsGenaralName.getName_Store(txtStoreID.Tag.ToString());
            else
                rtn = "default";
            return rtn;
        }
        #endregion

        #region Get To Location
        private string getToDepartment()
        {
            string rtn = "";
            if (txtDepartmentID.Tag != null)
                rtn = txtDepartmentID.Tag.ToString();
            else
                rtn = "default";
            return rtn;
        }
        private string getToSection()
        {
            string rtn = "";
            if (txtSectionID.Tag != null)
                rtn = txtSectionID.Tag.ToString();
            else
                rtn = "default";
            return rtn;
        }
        private string getToStore()
        {
            string rtn = "";
            if (txtStoreID.Tag != null)
                rtn = txtStoreID.Tag.ToString();
            else
                rtn = "default";
            return rtn;
        }
        #endregion

        #region Get Location SRN Number
        private string getDepartmentSRN()
        {
            string rtn = "";
            if (txtDepartmentID.Tag != null && txtDepartmentID.Tag.ToString() != "default" && txtSRNID.Tag != null)
                rtn = txtSRNID.Tag.ToString();
            else
                rtn = "default";
            return rtn;
        }
        private string getSectionSRN()
        {
            string rtn = "";
            if (txtSectionID.Tag != null && txtSectionID.Tag.ToString() != "default" && txtSRNID.Tag != null)
                rtn = txtSRNID.Tag.ToString();
            else
                rtn = "default";
            return rtn;
        }
        private string getStoreSRN()
        {
            string rtn = "";
            if (txtStoreID.Tag != null && txtStoreID.Tag.ToString() != "default" && txtSRNID.Tag != null)
                rtn = txtSRNID.Tag.ToString();
            else
                rtn = "default";
            return rtn;
        }
        #endregion

        #region Load SRN Number
        private void loadSRNnumber()
        {
            if (txtDepartmentID.Tag != null && txtDepartmentID.Tag.ToString().Trim() != "default")
                Search_DepartmentStoreReqositionNote();
            else if (txtSectionID.Tag != null && txtSectionID.Tag.ToString().Trim() != "default")
                Search_SectionStoreReqositionNote();
            else if (txtStoreID.Tag != null && txtStoreID.Tag.ToString().Trim() != "default")
                Search_StoreGoodReqositionNote();
        }
        #endregion

        #region Send E-Mail
        public void sendEmail()
        {
            //    frmEmail oEmail = new frmEmail();
            //oEmail.Show();
        }
        #endregion

        #region Cancel Order
        private void cancelOrder()
        {
            try
            {
                if (txtGoodIssueNoteID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreID.Tag.ToString(), IsUpdate))
                        {
                            if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtLocationID.Tag.ToString(), IsUpdate))
                            {
                                //delete one record
                                Cursor = Cursors.WaitCursor;
                                tbl_scsStoreGoodIssueNote detail = tbl_scsStoreGoodIssueNote.Select(txtGoodIssueNoteID.Text.Trim());
                                if (detail != null)
                                {
                                    if (!detail.IsLocked)
                                    {
                                        if (!detail.IsDeleted)
                                        {
                                            if (!detail.IsSeattled)
                                            {
                                                DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " GIN : " + detail.StoreGoodIssueNote_ID), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                                if (msgResult == DialogResult.Yes)
                                                {
                                                    detail.DeletedTerminal_ID = clsSecurity.TerminalID;
                                                    detail.DeletedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.DateDeleted = clsSecurity.getServerDateTime();

                                                    detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.DateModified = clsSecurity.getServerDateTime();
                                                    detail.IsDeleted = true;
                                                    detail.Update();

                                                    //Update Other Tables
                                                    #region Update Other Tables
                                                    List<tbl_scsStoreGoodIssueNote_Detail> details = tbl_scsStoreGoodIssueNote_Detail.SelectAllByStoreGoodIssueNote_ID(detail.StoreGoodIssueNote_ID);
                                                    foreach (tbl_scsStoreGoodIssueNote_Detail GINdetail in details)
                                                    {
                                                        #region Update Store Stock
                                                        decimal dWeightedAverageCostPrice = 0;
                                                     //   clsHelpMethods_Local.UpdateStoreStock(iFormID, detail.StoreGoodIssueNote_ID, detail.StoreGoodIssueNoteDate, GINdetail.Item_ID, "0", txtLocationID.Tag.ToString(), GINdetail.Qty, GINdetail.Weight, GINdetail.TotalAmount, true, false, false, ref dWeightedAverageCostPrice);
                                                        //     clsHelpMethods_Local.RollBackFifo_Stock(iFormID, GINdetail.StoreGoodIssueNote_ID);
                                                        GINdetail.WeightedAvgCost = clsProcessMethods.GetItemWeightedAvarageCostPrice(GINdetail.Item_ID);
                                                        GINdetail.Update();

                                                        #endregion

                                                        ///Unsettle SR - Store
                                                        foreach (tbl_scsStoreReqositionNote_Detail oStoreSR in tbl_scsStoreReqositionNote_Detail.SelectAllByStoreRecositionNote_ID(GINdetail.StoreRequisitionNote_ID).Where(p => p.Item_ID == GINdetail.Item_ID))
                                                        {
                                                            oStoreSR.QtySettle = oStoreSR.QtySettle - GINdetail.Qty;
                                                            oStoreSR.WeightSettle = oStoreSR.WeightSettle - GINdetail.Weight;
                                                            oStoreSR.Update();
                                                            clsProcessMethods.SetSettle_StoreSR(GINdetail.StoreRequisitionNote_ID);
                                                        }
                                                        ///Unsettle GIN - Section
                                                        foreach (tbl_scsSectionReqositionNote_Detail oSectionSR in tbl_scsSectionReqositionNote_Detail.SelectAllBySectionReqositionNote_ID(GINdetail.SectionRequisitionNote_ID).Where(p => p.Item_ID == GINdetail.Item_ID))
                                                        {
                                                            oSectionSR.QtySettle = oSectionSR.QtySettle - GINdetail.Qty;
                                                            oSectionSR.WeightSettle = oSectionSR.WeightSettle - GINdetail.Weight;
                                                            oSectionSR.Update();
                                                            clsProcessMethods.SetSettle_SectionSR(GINdetail.SectionRequisitionNote_ID);
                                                        }
                                                        ///Unsettle GIN - Department
                                                        ///Pls Do
                                                    }
                                                    #endregion

                                                    //     clsHelpMethods.Delete_Inventory(iFormID, 0, txtGoodIssueNoteID.Text.Trim());
                                                    var responce = oData.Delete_InventoryTxn(iFormID, txtGoodIssueNoteID.Text.Trim());
                                                    if (!responce.IsSuccess)
                                                    {
                                                        clsValidate.WriteErrorLog(txtGoodIssueNoteID.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
                                                    }


                                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    ClearFields();
                                                }
                                            }
                                            else
                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.GRNdoneForGIN), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        #region print method
        private void print(bool bIsDraft)
        {
            try
            {
                if (txtGoodIssueNoteID.Text.Trim().Length > 0 && txtGoodIssueNoteID.Text.Trim() != "<Auto Generate>")
                {
                    if (clsConfig.bDataSetActive_iGIN)
                    {
                        #region Using Dataset
                        try
                        {
                            string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                            string sCreateUser = "", sCheckedUser = "", sApprovedUser = "", sDuplicate = "", sCreateUserCel = "", sCheckedUserCel = "", sApprovedUserCel = "", sCreatedate = "", sChequeDate = "", sApprovedDate = "", sStoreRequisitionId = "";
                            DateTime dtStoreRequisitionDate = DateTime.MinValue;
                            decimal dQtySettle = 0, dRequisitionQty = 0;
                            if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_GoodsIssuedNote), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                            {
                                Cursor = Cursors.WaitCursor;
                                glb_dtsStoreGoodsIssueNote.Clear();
                                glb_dtsReportExport.Clear();

                                string sCreateUserAndDate = "", sApprovedUserAndDate = "", sCheckedUserAndDate = "";
                                bool bPermissinOkToPrint = true;

                                if (chkPrintOriginal.Checked)
                                    bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_GoodsIssuedNote));
                                if (bPermissinOkToPrint)
                                {
                                    tbl_scsStoreGoodIssueNote oIGIN = tbl_scsStoreGoodIssueNote.Select(txtGoodIssueNoteID.Text.Trim());
                                    if (oIGIN != null && oIGIN.StoreGoodIssueNote_ID != "default")
                                    {
                                        if (!bIsDraft)
                                        {
                                            //sDuplicate = oIGIN.PrintCount > 0 ? "Duplicate Copy " + oIGIN.PrintCount : "";

                                            if (!chkPrintOriginal.Checked)
                                                sDuplicate = (oIGIN.PrintCount > 0) ? "Duplicate Copy " + oIGIN.PrintCount : "";

                                            oIGIN.PrintCount++;
                                            oIGIN.DatePrinted = clsSecurity.getServerDateTime();
                                            oIGIN.PrintedTerminal_ID = clsSecurity.TerminalID;
                                            oIGIN.PrintedUser_ID = clsSecurity.UserIDLoged;

                                            oIGIN.Update();
                                        }
                                        #region Set Store Requisition ID & Date
                                        tbl_scsStoreReqositionNote oStore = tbl_scsStoreReqositionNote.Select(oIGIN.StoreRequisitionNote_ID);
                                        if (oStore != null)
                                        {
                                            sStoreRequisitionId = oStore.StoreRecositionNote_ID;
                                            dtStoreRequisitionDate = oStore.StoreRecositionNoteDate;
                                        }
                                        #endregion

                                        if (oIGIN.IsDeleted)
                                            sDuplicate = "";

                                        string sFromLocationID = "", sFromLocationName = "";
                                        clsHelpMethods_Local.getLocationNameAndID_FromDeptSecStore(oIGIN.ToDepartment_ID, oIGIN.ToDepartment_ID, oIGIN.ToStore_ID, ref sFromLocationID, ref sFromLocationName);

                                        //sCreateUserAndDate = clsGenaralName.getName_User(oIGIN.CreateUser_ID) + " - " + clsFormatter.FormatDate_Short(oIGIN.DateCreate);
                                        //sApprovedUserAndDate = clsGenaralName.getName_User(oIGIN.ApprovedUser_ID) + " - " + clsFormatter.FormatDate_Short(oIGIN.DateApproved);
                                        //sCheckedUserAndDate = clsGenaralName.getName_User(oIGIN.CheckedUser_ID) + " - " + clsFormatter.FormatDate_Short(oIGIN.DateChecked);

                                        sCreateUser = "[ " + clsGenaralName.getName_User(oIGIN.CreateUser_ID) + " ] [ " + oIGIN.DateCreate.ToShortDateString() + " ]";
                                        if (oIGIN.CheckedUser_ID != "default")
                                            sCheckedUser = "[ " + clsGenaralName.getName_User(oIGIN.CheckedUser_ID) + " ] [ " + oIGIN.DateChecked.ToShortDateString() + " ]";
                                        if (oIGIN.ApprovedUser_ID != "default")
                                            sApprovedUser = "[ " + clsGenaralName.getName_User(oIGIN.ApprovedUser_ID) + " ] [ " + oIGIN.DateApproved.ToShortDateString() + " ]";

                                        #region Set User Details(For Cellcius)
                                        sCreateUserCel = "[ " + clsGenaralName.getName_User(oIGIN.CreateUser_ID) + " ] ";
                                        sCreatedate = "[" + oIGIN.DateCreate + "]";
                                        if (oIGIN.CheckedUser_ID != "default")
                                            sCheckedUserCel = "[ " + clsGenaralName.getName_User(oIGIN.CheckedUser_ID) + " ] ";
                                        sChequeDate = "[" + oIGIN.DateChecked + "]";
                                        if (oIGIN.ApprovedUser_ID != "default")
                                            sApprovedUserCel = "[ " + clsGenaralName.getName_User(oIGIN.ApprovedUser_ID) + " ] ";
                                        sApprovedDate = "[" + oIGIN.DateApproved + "]";
                                        #endregion

                                        glb_dtsStoreGoodsIssueNote.dt_scsStoreGoodsIssueNote.Adddt_scsStoreGoodsIssueNoteRow(oIGIN.StoreGoodIssueNote_ID, oIGIN.FromStore_ID, oIGIN.Remark, oIGIN.IsDeleted,
                                            oIGIN.StoreGoodIssueNoteDate, oIGIN.DateCreate, sFromLocationID, sFromLocationName, oIGIN.FromStore_ID, clsGenaralName.getName_Store(oIGIN.FromStore_ID), sStoreRequisitionId, dtStoreRequisitionDate);

                                        foreach (tbl_scsStoreGoodIssueNote_Detail detail in tbl_scsStoreGoodIssueNote_Detail.SelectAllByStoreGoodIssueNote_ID(oIGIN.StoreGoodIssueNote_ID))
                                        {
                                            tbl_genItemMaster oItem = tbl_genItemMaster.Select(detail.Item_ID);
                                            if (oItem != null)
                                            {
                                                tbl_genItemMaster_Pricing oItemFin = tbl_genItemMaster_Pricing.Select(oItem.Item_ID);
                                                clsHelpMethods_Local.getLocationNameAndID_FromDeptSecStore(detail.ToDepartment_ID, detail.ToSection_ID, detail.ToStore_ID, ref sFromLocationID, ref sFromLocationName);

                                                #region Set CustomerOrder Qty                                          
                                                tbl_scsStoreReqositionNote_Detail oSettle = tbl_scsStoreReqositionNote_Detail.SelectAllByStoreRecositionNote_ID(detail.StoreRequisitionNote_ID).Where(p => p.Item_ID == detail.Item_ID).FirstOrDefault();
                                                if (oSettle != null)
                                                {
                                                    dQtySettle = oSettle.QtySettle;
                                                    dRequisitionQty = oSettle.Qty;
                                                }

                                                #endregion

                                                glb_dtsStoreGoodsIssueNote.dt_scsStoreGoodsIssueNote_Detail.Adddt_scsStoreGoodsIssueNote_DetailRow(detail.StoreGoodIssueNote_ID, "", detail.Item_ID,
                                                    clsGenaralName.getName_Item(detail.Item_ID), "", clsGenaralName.getName_ItemSubCategory(detail.ItemSubCategory_ID), detail.ItemSerialNo,
                                                    detail.Qty, detail.Weight,
                                                    oItemFin.SellingPrice1, oItemFin.SellingPrice2, detail.UnitPrice,
                                                    detail.Remark, "", "",
                                                    detail.FromStore_ID, detail.Job_ID, sFromLocationID, sFromLocationName, "default", clsGenaralName.getName_Store(detail.FromStore_ID), "", detail.Uom_ID, clsGenaralName.getName_Uom(detail.Uom_ID), dQtySettle, dRequisitionQty);
                                            }
                                        }
                                    }

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DupicateCopy", sDuplicate, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("isDel", oIGIN.IsDeleted ? "CANCELLED" : "", true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUser, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sCheckedUser, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUser, true);

                                    #region Set User Details(For Celcius)
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUser", sCreateUserCel, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUser", sCheckedUserCel, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApprovedUser", sApprovedUserCel, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApprovedDate", sApprovedDate, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateDate", sCreatedate, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckedDate", sChequeDate, true);
                                    #endregion

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", clsCommon.getCompanyEmail(), true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVAT", clsCommon.getCompanyVAT(), true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("SVAT", clsCommon.getCompanySVAT(), true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyWebSite", clsCommon.getCompanyWeb(), true);

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
                                    glb_dtsStoreGoodsIssueNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, sReportTitle_Main, "", "", clsSecurity.UserNameLoged, "");
                                    #endregion

                                    frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                    rpt.print(sReportPath, glb_dtsStoreGoodsIssueNote, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_GoodsIssuedNote));
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            SEACCException.Show(ex);
                        }
                        finally
                        {
                            Cursor = Cursors.Default;
                            glb_dtsStoreGoodsIssueNote.Clear();
                        }
                        #endregion
                    }
                    else
                    {
                        #region Using Views (Old Method)
                        string sCreateUser = "", sCheckedUser = "", sApprovedUser = "";
                        string sDuplicate = "";
                        bool bPermissinOkToPrint = true;

                        if (chkPrintOriginal.Checked)
                            bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_GoodsIssuedNote));
                        if (bPermissinOkToPrint)
                        {
                            tbl_scsStoreGoodIssueNote gin = tbl_scsStoreGoodIssueNote.Select(txtGoodIssueNoteID.Text.Trim());
                            if (gin != null)
                            {
                                if (!bIsDraft)
                                {
                                    //sDuplicate = gin.PrintCount > 0 ? "Duplicate Copy " + gin.PrintCount : "";

                                    if (!chkPrintOriginal.Checked)
                                        sDuplicate = (gin.PrintCount > 0) ? "Duplicate Copy " + gin.PrintCount : "";

                                    gin.PrintCount++;
                                    gin.DatePrinted = clsSecurity.getServerDateTime();
                                    gin.PrintedTerminal_ID = clsSecurity.TerminalID;
                                    gin.PrintedUser_ID = clsSecurity.UserIDLoged;
                                    gin.Update();

                                }
                                //order.IsLocked = true;
                                sCreateUser = "[ " + clsGenaralName.getName_User(gin.CreateUser_ID) + " ] [ " + gin.DateCreate.ToShortDateString() + " ]";
                                if (gin.CheckedUser_ID != "default")
                                    sCheckedUser = "[ " + clsGenaralName.getName_User(gin.CheckedUser_ID) + " ] [ " + gin.DateChecked.ToShortDateString() + " ]";
                                if (gin.ApprovedUser_ID != "default")
                                    sApprovedUser = "[ " + clsGenaralName.getName_User(gin.ApprovedUser_ID) + " ] [ " + gin.DateApproved.ToShortDateString() + " ]";
                            }

                            Cursor = Cursors.WaitCursor;
                            string s_Path = "", sReportTitle = "STORE GOODS ISSUED NOTE [GIN]", sFormula = "";
                            sFormula = "{vw_rpt_scsStoreGoodIssueNote.storeGoodIssueNote_ID} = '" + txtGoodIssueNoteID.Text.Trim() + "'";

                            ReportDocument RD = new ReportDocument();
                            s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                            string sGetRptPath = clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_GoodsIssuedNote));
                            if (sGetRptPath != null && sGetRptPath.Length > 0)
                                s_Path += sGetRptPath;
                            else
                                s_Path += "\\reports\\rpt_scsStoreGoodIssueNote.rpt";

                            frm_ReportViewer viewer = new frm_ReportViewer();
                            RD.Load(s_Path);
                         //   clsSecurity.LogonServer(ref RD);
                            RD.Refresh();

                            RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                            RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToShortDateString());
                            RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
                            RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
                            RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);
                            RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                            RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                            RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                            RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                            RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                            try
                            {
                                RD.DataDefinition.FormulaFields["CompanyEmail"].Text = clsCommon.fncsetstring(clsCommon.getCompanyEmail());
                                RD.DataDefinition.FormulaFields["BisRegNo"].Text = clsCommon.fncsetstring(clsCommon.getCompanyBusinessRegisterNo());
                                RD.DataDefinition.FormulaFields["CompanyVAT"].Text = clsCommon.fncsetstring(clsCommon.getCompanyVAT());
                            }
                            catch (Exception e) { }

                            RD.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring(sDuplicate);
                            RD.DataDefinition.FormulaFields["IsDraft"].Text = bIsDraft ? clsCommon.fncsetstring("DRAFT") : "";

                            #region Company Details Fill
                            if (bIsDraft)
                            {
                                if (!clsConfig.isVisibleCompanyInfoInDraftPrint)
                                {
                                    RD.DataDefinition.FormulaFields["CompanyName"].Text = "";
                                    RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = "";
                                    RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = "";
                                    RD.DataDefinition.FormulaFields["CompanyEmail"].Text = "";
                                    RD.DataDefinition.FormulaFields["BisRegNo"].Text = "";
                                    RD.DataDefinition.FormulaFields["CompanyVAT"].Text = "";
                                }
                            }
                            #endregion

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

        #region Print report
        private void print(string path, string sReportTitle, DataSet ojbDataSet, string sCreateUserNameAndDate, string sChekcedUserNameAndDate, string sApprovedUserNameAndDate)
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
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                objRpt.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUserNameAndDate);
                objRpt.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sChekcedUserNameAndDate);
                objRpt.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUserNameAndDate);
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

        private void TransferGemItem()
        {
            string sBranchID = "default", sGRNNo = "", sItemCode = "", sSerial1 = "";
            tbl_genStoreMaster oStore = tbl_genStoreMaster.Select(txtStoreID.Tag.ToString().Trim());
            if (oStore != null)
                sBranchID = oStore.CompanyBranch_ID;
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                sGRNNo = row.Cells["Note_ID"].Value.ToString(); sItemCode = row.Cells["ItemCode"].Value.ToString();
                sSerial1 = row.Cells["ItemSerialNo1"].Value.ToString();

                //foreach (tbl_scsExternalGoodReceivedNote_Detail_Gem oDetail in tbl_scsExternalGoodReceivedNote_Detail_Gem.SelectAllByExternalGoodReceivedNote_ID(sGRNNo).Where(p => p.CompanyBranch_ID == sBranchID && p.Item_ID == sItemCode && p.ItemSerialNo == sSerial1))
                //{
                //    oDetail.IsTransferred = true;
                //    oDetail.Update();
                //    break;
                //}
            }
        }
        private void LockGemItem(string sGRNNo, string sItemCode, string sSerial1)
        {
            string sBranchID = "default";
            tbl_genStoreMaster oStore = tbl_genStoreMaster.Select(txtStoreID.Tag.ToString().Trim());
            if (oStore != null)
                sBranchID = oStore.CompanyBranch_ID;

            //foreach (tbl_scsExternalGoodReceivedNote_Detail_Gem oDetail in tbl_scsExternalGoodReceivedNote_Detail_Gem.SelectAllByExternalGoodReceivedNote_ID(sGRNNo).Where(p => p.CompanyBranch_ID == sBranchID && p.Item_ID == sItemCode && p.ItemSerialNo == sSerial1))
            //{
            //    oDetail.IsLocked = true;
            //    oDetail.Update();
            //    break;
            //}

        }
        private void btnF5_Click(object sender, EventArgs e)
        {
            clearItamAndJob();
            Search_ItemID(sender, new KeyEventArgs(Keys.F5));
        }
        private void frm_scsStoreGoodIssueNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            Attachments.Close();
        }

        #region User Checked Approve Details

        private void frm_scsStoreGoodIssueNote_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_scsStoreGoodIssueNote_SF_approveButton_Click(object sender, EventArgs e)
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
                        if (txtGoodIssueNoteID.Text != null && txtGoodIssueNoteID.TextLength > 0 && txtGoodIssueNoteID.Text != "<Auto Generate>")
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

                                        tbl_scsStoreGoodIssueNote objGIN = tbl_scsStoreGoodIssueNote.Select(txtGoodIssueNoteID.Text.Trim());
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
                clsValidate.WriteErrorLog("", iFormID, ex);
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
                        if (txtGoodIssueNoteID.Text != null && txtGoodIssueNoteID.TextLength > 0 && txtGoodIssueNoteID.Text != "<Auto Generate>")
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

                                        tbl_scsStoreGoodIssueNote objGIN = tbl_scsStoreGoodIssueNote.Select(txtGoodIssueNoteID.Text.Trim());
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
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        private void frm_scsStoreGoodIssueNote_SF_History_Click(object sender, EventArgs e)
        {
            if (txtGoodIssueNoteID.Text != "" || txtGoodIssueNoteID.Text != "<Auto Generate>")
            {
                tbl_scsStoreGoodIssueNote detail = tbl_scsStoreGoodIssueNote.Select(txtGoodIssueNoteID.Text);
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