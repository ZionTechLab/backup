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
using SEACC.WinFormControls.Forms;
using Zion.ERP.Reports.DataSets.SCS;
using Zion.ERP.Reports.DataSets;
using ZION.ERP.Reports.DataSets.SCS;

namespace Digiteq
{
    public partial class frm_scsPurchaseRequisitionNote : SEACC_Form
    {
        
        //to manage update and insert
        //static bool IsUpdate = false;

        //form manage
        //string sFormConfigCode;
        //   public int iFormID;

        //to keep glob ref no        
        public string glbPRNo = "";
        public List<string> glbSRs = new List<string>();

        //for security handle
        //public bool bNoAccess;
        //public bool bHasChecked;
        //public bool bHasApproved;
        //private bool isDraft = false;
        //       DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        //    DateTime glbCheckedDate = clsSecurity.getServerDateTime();
        bool isDuplicate;

        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        dts_scsPurchaseRequisitionNote glb_dtsScsPurchaseRequisitionNote = new dts_scsPurchaseRequisitionNote();
    

        #region Form Load
        public frm_scsPurchaseRequisitionNote(FormName _enmForm)
        {
            //sFormConfigCode = clsAutocode.getFormConfigCode(FormName.PurchaseRequisition);
            //iFormID = clsSecurity.getFormID(FormName.PurchaseRequisition);
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
            //add data to the datagrid and format  
            //clsFormatter.setFormatForm(this, clsHelpMethods_Local.getFormName(iFormID), 4, iFormID);

            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);
            CusDataGridViewFormat();
            ClearFields();

            if (glbPRNo.Length > 0)
                FillDetails(glbPRNo);
        }
        #endregion

        #region Btn New
        private void frm_scsPurchaseRequisitionNote_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void frm_scsPurchaseRequisitionNote_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPurchaseRequisitionNoteID.Text.Trim().Length > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpPRNDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreID.Tag.ToString(), IsUpdate))
                            {
                                //delete one record
                                Cursor = Cursors.WaitCursor;
                                tbl_scsPurchaseRequisition detail = tbl_scsPurchaseRequisition.Select(txtPurchaseRequisitionNoteID.Text.Trim());
                                if (detail != null)
                                {
                                    if (ValidateForDependancies(detail.PurchaseRequisitionNote_ID))
                                    {
                                        if (!detail.IsLocked)
                                        {
                                            if (!detail.IsDeleted)
                                            {
                                                //if (clsValidate.CheckPostingValidity(detail.PostingStatus_ID))
                                                //{
                                                DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " SR : " + detail.PurchaseRequisitionNote_ID), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                                if (msgResult == DialogResult.Yes)
                                                {
                                                    detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.DateModified = clsSecurity.getServerDateTime();
                                                    detail.IsDeleted = true;
                                                    detail.Update();
                                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    ClearFields();
                                                }
                                                //}
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
                SEACCException.Show(ex);
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
                        clsHelpMethods_Local.Grid_LineNoChange(dgvDetail);
                    }
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region Btn Save
        private void frm_scsPurchaseRequisitionNote_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity_EmptyField())
            {
                if (CheckNumberValidity())
                {
                    if (clsValidate.CheckGridCountValidity(dgvDetail.RowCount, iFormID))
                    {
                        if (CheckStockValidity())
                        {
                            if (clsMethods_GL.CheckValidity_FinancialYear(dtpPRNDate.Value.Date))
                            {
                                if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                                {
                                    if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreID.Tag.ToString(), IsUpdate))
                                    {
                                        try
                                        {
                                            Cursor = Cursors.WaitCursor;
                                            //ValidateEmptyForeignKey();

                                            if (IsUpdate)//update records
                                            {
                                                #region Update

                                                tbl_scsPurchaseRequisition oldRecord = tbl_scsPurchaseRequisition.Select(txtPurchaseRequisitionNoteID.Text.Trim());
                                                if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                                                {
                                                    if (ValidateForDependancies(oldRecord.PurchaseRequisitionNote_ID))
                                                    {
                                                        if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                                                        {
                                                            if (!oldRecord.IsChecked ||
                                                                (oldRecord.IsChecked &&
                                                                 clsSecurity.PermissionToApproved(
                                                                     clsSecurity.UserIDLoged, iFormID)))
                                                            {
                                                                if (clsValidate.CheckValidity_TransactionCodeLength(txtPurchaseRequisitionNoteID.Text))
                                                                {

                                                                    #region Delete old Items

                                                                    List<tbl_scsPurchaseRequisition_Detail>
                                                                        oldPRDetails =
                                                                            tbl_scsPurchaseRequisition_Detail
                                                                                .SelectAllByPurchaseRequisitionNote_ID(
                                                                                    oldRecord
                                                                                        .PurchaseRequisitionNote_ID);
                                                                    foreach (tbl_scsPurchaseRequisition_Detail
                                                                        oldPRDetail in oldPRDetails)
                                                                    {
                                                                        #region Update SRs

                                                                        if (glbSRs.Count > 0)
                                                                        {
                                                                            foreach (string sSR in glbSRs)
                                                                            {
                                                                                tbl_scsStoreReqositionNote oStoreSR =
                                                                                    tbl_scsStoreReqositionNote.Select(
                                                                                        sSR);
                                                                                if (oStoreSR != null)
                                                                                {
                                                                                    oStoreSR.IsPRdone = true;
                                                                                    oStoreSR.PurchaseRequisitionNote_ID
                                                                                        = txtPurchaseRequisitionNoteID
                                                                                            .Text;
                                                                                    oStoreSR.Update();
                                                                                }

                                                                                tbl_scsSectionReqositionNote
                                                                                    oSectionSR =
                                                                                        tbl_scsSectionReqositionNote
                                                                                            .Select(sSR);
                                                                                if (oSectionSR != null)
                                                                                {
                                                                                    oSectionSR.IsPRdone = true;
                                                                                    oSectionSR
                                                                                            .PurchaseRequisitionNote_ID
                                                                                        =
                                                                                        txtPurchaseRequisitionNoteID
                                                                                            .Text;
                                                                                    oSectionSR.Update();
                                                                                }

                                                                                tbl_scsDepartmentReqositionNote
                                                                                    oDepartmentSR =
                                                                                        tbl_scsDepartmentReqositionNote
                                                                                            .Select(sSR);
                                                                                if (oDepartmentSR != null)
                                                                                {
                                                                                    oDepartmentSR.IsPRdone = true;
                                                                                    oDepartmentSR
                                                                                            .PurchaseRequisitionNote_ID
                                                                                        =
                                                                                        txtPurchaseRequisitionNoteID
                                                                                            .Text;
                                                                                    oDepartmentSR.Update();
                                                                                }
                                                                            }
                                                                        }

                                                                        #endregion

                                                                        oldPRDetail.Delete();
                                                                    }

                                                                    #endregion

                                                                    #region Insert PR Detail

                                                                    foreach (DataGridViewRow row in dgvDetail.Rows)
                                                                    {
                                                                        string sItemCode = "",
                                                                            sUom = "default",
                                                                            sJobCode = "",
                                                                            sSelectArea_ID = "",
                                                                            sDepartment_ID = "",
                                                                            sSection_ID = "",
                                                                            sStore_ID =
                                                                                "", //sDepartmentNote_ID = "", sSectionNote_ID = "", sStoreNote_ID = "",
                                                                            sItemSubCategoryID1 = "",
                                                                            sItemSubCategoryID2 = "",
                                                                            sItemSerialNo1 = "",
                                                                            sItemSerialNo2 = "",
                                                                            sDepartmentRequstionNote_ID = "",
                                                                            sSectionRequstionNote_ID = "",
                                                                            sStoreRequstionNote_ID = "",
                                                                            sRemarks = "";
                                                                        decimal dWeight = 0,
                                                                            dQuantitiy = 0,
                                                                            dQtySettle = 0,
                                                                            dWeightSettle = 0,
                                                                            dTotalCost_FIFO = 0,
                                                                            dTotalCost_WA = 0;
                                                                        int iLineNo = 0;

                                                                        iLineNo = clsValidate.ValidateGridValue(
                                                                            dgvDetail, "LineNo", row.Index,
                                                                            int.Parse("0"));
                                                                        sItemCode = clsValidate.ValidateGridValue(
                                                                            dgvDetail, "ItemCode", row.Index, "");
                                                                        sUom = clsValidate.ValidateGridTag(dgvDetail,
                                                                            "UOM", row.Index, "");
                                                                        dWeight = clsValidate.ValidateGridValue(
                                                                            dgvDetail, "Weight", row.Index,
                                                                            decimal.Parse("0.00"));
                                                                        sJobCode = clsValidate.ValidateGridValue(
                                                                            dgvDetail, "JobCode", row.Index, "default");
                                                                        dQuantitiy =
                                                                            clsValidate.ValidateGridValue(dgvDetail,
                                                                                "Quantity", row.Index,
                                                                                decimal.Parse("0.00"));
                                                                        sSelectArea_ID =
                                                                            clsValidate.ValidateGridValue(dgvDetail,
                                                                                "SelectArea_ID", row.Index, "default");
                                                                        sDepartment_ID =
                                                                            clsValidate.ValidateGridValue(dgvDetail,
                                                                                "Department_ID", row.Index, "default");
                                                                        sSection_ID =
                                                                            clsValidate.ValidateGridValue(dgvDetail,
                                                                                "Section_ID", row.Index, "default");
                                                                        sStore_ID = clsValidate.ValidateGridValue(
                                                                            dgvDetail, "Store_ID", row.Index,
                                                                            "default");
                                                                        sRemarks = clsValidate.ValidateGridValue(
                                                                            dgvDetail, "Remarks", row.Index, "");

                                                                        //  sDepartmentNote_ID = "default";
                                                                        // sSectionNote_ID = "default";
                                                                        // sStoreNote_ID = "default";
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
                                                                        sDepartmentRequstionNote_ID =
                                                                            clsValidate.ValidateGridValue(dgvDetail,
                                                                                "DepartmentReqositionNote_ID",
                                                                                row.Index, "default");
                                                                        sSectionRequstionNote_ID =
                                                                            clsValidate.ValidateGridValue(dgvDetail,
                                                                                "SectionReqositionNote_ID", row.Index,
                                                                                "default");
                                                                        sStoreRequstionNote_ID =
                                                                            clsValidate.ValidateGridValue(dgvDetail,
                                                                                "StoreRecositionNote_ID", row.Index,
                                                                                "default");
                                                                        dQtySettle =
                                                                            clsValidate.ValidateGridValue(dgvDetail,
                                                                                "QtySettle", row.Index,
                                                                                decimal.Parse("0.00"));
                                                                        dWeightSettle =
                                                                            clsValidate.ValidateGridValue(dgvDetail,
                                                                                "WeightSettle", row.Index,
                                                                                decimal.Parse("0.00"));
                                                                        dTotalCost_FIFO =
                                                                            clsValidate.ValidateGridValue(dgvDetail,
                                                                                "TotalCost_FIFO", row.Index,
                                                                                decimal.Parse("0.00"));
                                                                        dTotalCost_WA =
                                                                            clsValidate.ValidateGridValue(dgvDetail,
                                                                                "TotalCost_WA", row.Index,
                                                                                decimal.Parse("0.00"));

                                                                        if (sItemCode.Length > 0)
                                                                        {
                                                                            tbl_scsPurchaseRequisition_Detail items =
                                                                                new tbl_scsPurchaseRequisition_Detail(
                                                                                    iLineNo,
                                                                                    txtPurchaseRequisitionNoteID.Text
                                                                                        .Trim(), sItemCode,
                                                                                    sItemSubCategoryID1,
                                                                                    sItemSubCategoryID2, sItemSerialNo1,
                                                                                    sItemSerialNo2, "default", sJobCode,
                                                                                    sSelectArea_ID, sDepartment_ID,
                                                                                    sSection_ID, sStore_ID,
                                                                                    sDepartmentRequstionNote_ID,
                                                                                    sSectionRequstionNote_ID,
                                                                                    sStoreRequstionNote_ID, sUom,
                                                                                    dQuantitiy, dQtySettle, dWeight,
                                                                                    dWeightSettle, dTotalCost_FIFO,
                                                                                    dTotalCost_WA, sRemarks, false);
                                                                            items.Insert();
                                                                        }
                                                                    }

                                                                    #endregion

                                                                    #region Update SRs

                                                                    if (glbSRs.Count > 0)
                                                                    {
                                                                        foreach (string sSR in glbSRs)
                                                                        {
                                                                            tbl_scsStoreReqositionNote oStoreSR =
                                                                                tbl_scsStoreReqositionNote.Select(sSR);
                                                                            if (oStoreSR != null)
                                                                            {
                                                                                oStoreSR.IsPRdone = true;
                                                                                oStoreSR.PurchaseRequisitionNote_ID =
                                                                                    txtPurchaseRequisitionNoteID.Text;
                                                                                oStoreSR.Update();
                                                                            }

                                                                            tbl_scsSectionReqositionNote oSectionSR =
                                                                                tbl_scsSectionReqositionNote
                                                                                    .Select(sSR);
                                                                            if (oSectionSR != null)
                                                                            {
                                                                                oSectionSR.IsPRdone = true;
                                                                                oSectionSR.PurchaseRequisitionNote_ID =
                                                                                    txtPurchaseRequisitionNoteID.Text;
                                                                                oSectionSR.Update();
                                                                            }

                                                                            tbl_scsDepartmentReqositionNote
                                                                                oDepartmentSR =
                                                                                    tbl_scsDepartmentReqositionNote
                                                                                        .Select(sSR);
                                                                            if (oDepartmentSR != null)
                                                                            {
                                                                                oDepartmentSR.IsPRdone = true;
                                                                                oDepartmentSR.PurchaseRequisitionNote_ID
                                                                                    = txtPurchaseRequisitionNoteID.Text;
                                                                                oDepartmentSR.Update();
                                                                            }
                                                                        }
                                                                    }

                                                                    #endregion

                                                                    #region Update PRN Header

                                                                    tbl_scsPurchaseRequisition detail =
                                                                        new tbl_scsPurchaseRequisition(
                                                                            txtPurchaseRequisitionNoteID.Text.Trim(),
                                                                            dtpPRNDate.Value,
                                                                            txtOrderRefNo.Tag.ToString(),
                                                                            txtRequsetedBy.Text.Trim(),
                                                                            txtRemark.Text.Trim(), oldRecord.Matfor_ID,
                                                                            txtjobID.Tag.ToString(), getSelectAriaID(),
                                                                            getToDepartment(), getToSection(),
                                                                            getToStore(),
                                                                            txtStockNoteType.Tag.ToString(),
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
                                                                            oldRecord.IsChecked, oldRecord.IsApproved,
                                                                            oldRecord.IsFinished, oldRecord.IsDeleted,
                                                                            oldRecord.IsLocked, oldRecord.PrintCount,
                                                                            oldRecord.IsSeattled, oldRecord.CompanyID,
                                                                            oldRecord.CompanyBranch_ID);
                                                                    detail.Update();

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
                                                }

                                                //MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordUpdateIsBlock), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                #endregion
                                            }
                                            else  //insert records
                                            {
                                                #region Insert
                                                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                                {
                                                    /*  if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                                      {
                                                      }
                                                     * */

                                                    if (clsConfig.bStockNoteType_SerialNoActiveFor_PurchaseRequisitionNote)
                                                    {
                                                        if (txtStockNoteType.Tag != null && txtStockNoteType.Tag.ToString().Trim().Length > 0 && txtStockNoteType.Tag.ToString().Trim() != "default")
                                                            txtPurchaseRequisitionNoteID.Text = clsAutocode.getAutoGeneratedCode_PurchaseRequisition(txtStockNoteType.Tag.ToString());
                                                        else
                                                            MessageBox.Show("Please select the Stock Note Type before you save the record. " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }

                                                    else
                                                        txtPurchaseRequisitionNoteID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);
                                                }

                                                //create order ref number
                                                if (txtOrderRefNo.Tag == null || txtOrderRefNo.Tag.ToString().Trim().Length == 0 || txtOrderRefNo.Tag.ToString() == "default")
                                                {
                                                    txtOrderRefNo.Tag = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.zIssuedRefNo));
                                                    tbl_zIssuedRefNo orf = new tbl_zIssuedRefNo(txtOrderRefNo.Tag.ToString(), txtOrderRefNo.Text != "" ? txtOrderRefNo.Text.Trim() : "-");
                                                    orf.Insert();
                                                }

                                                if (clsValidate.CheckValidity_TransactionCodeLength(txtPurchaseRequisitionNoteID.Text)) //if (txtPurchaseRequisitionNoteID.Text.Trim().Length > 0)
                                                {
                                                    #region PRN Header
                                                    tbl_scsPurchaseRequisition detail = new tbl_scsPurchaseRequisition(txtPurchaseRequisitionNoteID.Text.Trim(), dtpPRNDate.Value, txtOrderRefNo.Tag.ToString(),
                                                        txtRequsetedBy.Text.Trim(), txtRemark.Text.Trim(), "default", txtjobID.Tag.ToString(), getSelectAriaID(), getToDepartment(), getToSection(), getToStore(), txtStockNoteType.Tag.ToString(),
                                                        clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default", clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                                        clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                        glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), bHasChecked, bHasApproved, false, false, false, 0, false, clsSecurity.CompanyID, clsSecurity.BranchID);
                                                    detail.Insert();
                                                    #endregion

                                                    #region PRN Detail
                                                    foreach (DataGridViewRow row in dgvDetail.Rows)
                                                    {
                                                        string sItemCode = "", sUom = "default", sJobCode = "", sSelectArea_ID = "", sDepartment_ID = "",
                                                        sSection_ID = "", sStore_ID = "", //sDepartmentNote_ID = "", sSectionNote_ID = "", sStoreNote_ID = "",
                                                        sItemSubCategoryID1 = "", sItemSubCategoryID2 = "", sItemSerialNo1 = "", sItemSerialNo2 = "",
                                                        sDepartmentRequstionNote_ID = "", sSectionRequstionNote_ID = "", sStoreRequstionNote_ID = "", sRemarks = "";
                                                        decimal dWeight = 0, dQuantitiy = 0, dQtySettle = 0, dWeightSettle = 0, dTotalCost_FIFO = 0, dTotalCost_WA = 0;
                                                        int iLineNo = 0;

                                                        iLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, int.Parse("0"));
                                                        sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                                        sUom = clsValidate.ValidateGridTag(dgvDetail, "UOM", row.Index, "");
                                                        dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                                        sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
                                                        dQuantitiy = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                                        sSelectArea_ID = clsValidate.ValidateGridValue(dgvDetail, "SelectArea_ID", row.Index, "default");
                                                        sDepartment_ID = clsValidate.ValidateGridValue(dgvDetail, "Department_ID", row.Index, "default");
                                                        sSection_ID = clsValidate.ValidateGridValue(dgvDetail, "Section_ID", row.Index, "default");
                                                        sStore_ID = clsValidate.ValidateGridValue(dgvDetail, "Store_ID", row.Index, "default");
                                                        sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");


                                                        //  sDepartmentNote_ID = "default";
                                                        // sSectionNote_ID = "default";
                                                        // sStoreNote_ID = "default";
                                                        sItemSubCategoryID1 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                                                        sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                                        sItemSerialNo1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                                                        sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                                        sDepartmentRequstionNote_ID = clsValidate.ValidateGridValue(dgvDetail, "DepartmentReqositionNote_ID", row.Index, "default");
                                                        sSectionRequstionNote_ID = clsValidate.ValidateGridValue(dgvDetail, "SectionReqositionNote_ID", row.Index, "default");
                                                        sStoreRequstionNote_ID = clsValidate.ValidateGridValue(dgvDetail, "StoreRecositionNote_ID", row.Index, "default");
                                                        dQtySettle = clsValidate.ValidateGridValue(dgvDetail, "QtySettle", row.Index, decimal.Parse("0.00"));
                                                        dWeightSettle = clsValidate.ValidateGridValue(dgvDetail, "WeightSettle", row.Index, decimal.Parse("0.00"));
                                                        dTotalCost_FIFO = clsValidate.ValidateGridValue(dgvDetail, "TotalCost_FIFO", row.Index, decimal.Parse("0.00"));
                                                        dTotalCost_WA = clsValidate.ValidateGridValue(dgvDetail, "TotalCost_WA", row.Index, decimal.Parse("0.00"));

                                                        if (sItemCode.Length > 0)
                                                        {
                                                            tbl_scsPurchaseRequisition_Detail items = new tbl_scsPurchaseRequisition_Detail(iLineNo, txtPurchaseRequisitionNoteID.Text.Trim(), sItemCode,
                                                                sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, "default", sJobCode,
                                                                sSelectArea_ID, sDepartment_ID, sSection_ID, sStore_ID, sDepartmentRequstionNote_ID, sSectionRequstionNote_ID,
                                                                sStoreRequstionNote_ID, sUom, dQuantitiy, dQtySettle, dWeight, dWeightSettle, dTotalCost_FIFO, dTotalCost_WA, sRemarks, false);
                                                            items.Insert();
                                                        }
                                                    }
                                                    #endregion

                                                    #region Update SRs
                                                    if (glbSRs.Count > 0)
                                                    {
                                                        foreach (string sSR in glbSRs)
                                                        {
                                                            tbl_scsStoreReqositionNote oStoreSR = tbl_scsStoreReqositionNote.Select(sSR);
                                                            if (oStoreSR != null)
                                                            {
                                                                oStoreSR.IsPRdone = true;
                                                                oStoreSR.PurchaseRequisitionNote_ID = txtPurchaseRequisitionNoteID.Text;
                                                                oStoreSR.Update();
                                                            }

                                                            tbl_scsSectionReqositionNote oSectionSR = tbl_scsSectionReqositionNote.Select(sSR);
                                                            if (oSectionSR != null)
                                                            {
                                                                oSectionSR.IsPRdone = true;
                                                                oSectionSR.PurchaseRequisitionNote_ID = txtPurchaseRequisitionNoteID.Text;
                                                                oSectionSR.Update();
                                                            }

                                                            tbl_scsDepartmentReqositionNote oDepartmentSR = tbl_scsDepartmentReqositionNote.Select(sSR);
                                                            if (oDepartmentSR != null)
                                                            {
                                                                oDepartmentSR.IsPRdone = true;
                                                                oDepartmentSR.PurchaseRequisitionNote_ID = txtPurchaseRequisitionNoteID.Text;
                                                                oDepartmentSR.Update();
                                                            }
                                                        }
                                                    }
                                                    #endregion

                                                    Attachments.Insert(txtPurchaseRequisitionNoteID.Text.ToString());

                                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                //else
                                                //{
                                                //    MessageBox.Show("Purchase Requisition Note " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                            FillDetails(txtPurchaseRequisitionNoteID.Text.Trim());
                                        }
                                    }
                                }
                            }
                        }
                    }//Check detail count validity
                }

            }
        }
        #endregion

        #region Btn Draft
        private void frm_scsPurchaseRequisitionNote_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region Btn Print
        private void frm_scsPurchaseRequisitionNote_SF_printButton_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        #endregion

        #region Btn Add Job
        private void BtnJob_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtjobID.Text.Trim().Length > 0)
                {
                    //tbl_pmsProductionJobRegister detail = tbl_pmsProductionJobRegister.Select(txtjobID.Text.Trim());
                    //if (detail != null)
                    //{
                    //    RefreshGridByJob_ID(detail.ProductionJob_ID);
                    //}
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Add SR
        private void btnAddStoreRequestion_Click(object sender, EventArgs e)
        {
            if (txtSRNo.Text.Trim().Length > 0)
            {
                FillDetailsFromSR(txtSRNo.Text.Trim());
            }
        }
        #endregion

        #region Btn Add Item
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0)
                {
                    tbl_genItemMaster detail = tbl_genItemMaster.Select(txtItemID.Tag.ToString());
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
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn PO
        private void btnPO_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPurchaseRequisitionNoteID.TextLength > 0 && txtPurchaseRequisitionNoteID.Text.Trim() != "default")
                {
                    tbl_scsPurchaseRequisition detail = tbl_scsPurchaseRequisition.Select(txtPurchaseRequisitionNoteID.Text.Trim());
                    if (detail != null && detail.PurchaseRequisitionNote_ID != "default" && !detail.IsDeleted)
                    {
                        bool bAllowDetail = true;
                        string message = "";
                        //if (clsConfig.bApprovalEnabledCustomerOrder)
                        //{
                        //    if (!detail.IsApproved)
                        //    {
                        //        bAllowDetail = false;
                        //        message = "APPROVAL NEEDED \n\nUser has to Approve the Customer Order Before Creating a Delivery Order";
                        //    }
                        //}
                        //if (clsConfig.bSettleEnabledCustomerOrder)
                        //{
                        //    if (detail.IsSeattled)
                        //    {
                        //        bAllowDetail = false;
                        //        if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                        //            message = "ALREADY INVOICED \n\nInvoice(s) have been already Generated to this Customer Order";
                        //        else
                        //            message = "ALREADY DELIVERED \n\nThis Customer Order Quantity has already being issued by Delivery Order(s)";
                        //    }
                        //}

                        if (bAllowDetail)
                        {
                            //  frm_scsPurchaseOrder frm = new frm_scsPurchaseOrder();

                            //frm.MdiParent = this.MdiParent;
                            //  frm.Show();

                            frm_scsPurchaseOrder frm = new frm_scsPurchaseOrder(FormName.scsPOSupplier);
                            frm.glbPurchaseRequistionID = detail.PurchaseRequisitionNote_ID;
                            frm.glbOrderRefNo = detail.IssuedRefNo_ID;
                            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, (this.Parent as Form).MdiParent);

                        }
                        else
                            MessageBox.Show(message, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        #region Btn Temp
        private void frm_scsPurchaseRequisitionNote_SF_tempButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPurchaseRequisitionNoteID.TextLength > 0 && txtPurchaseRequisitionNoteID.Text != "<Auto Generate>")
                {
                    //set the flag and enble the id
                    IsUpdate = false;
                    lblCancelled.Visible = false;

                    clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPurchaseRequisitionNoteID, true);
                    clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStockNoteType, true);
                    clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, true);

                    clsCommon.SetEnableDisable_NormalLabel(lblGoodreceivedNoteID, true);
                    clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, true);
                    clsCommon.SetEnableDisable_NormalLabel(lblStockNoteType, true);

                    setEnableItems(false);

                    txtPurchaseRequisitionNoteID.Tag = null;
                    dtpPRNDate.Value = clsSecurity.getServerDateTime();

                    txtStockNoteType.Tag = null;
                    txtStockNoteType.Clear();

                    bHasApproved = false;
                    bHasChecked = false;
                    userDetailsColorChanges();

                    //Reset Order Ref No
                    txtOrderRefNo.Tag = null;
                    txtOrderRefNo.Clear();

                    //Reset Primary Key
                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                        txtPurchaseRequisitionNoteID.Text = "<Auto Generate>";
                    else
                        txtPurchaseRequisitionNoteID.Clear();
                    if (txtPurchaseRequisitionNoteID.Enabled)
                    {
                        txtPurchaseRequisitionNoteID.SelectAll();
                        txtPurchaseRequisitionNoteID.Focus();
                    }

                    Attachments.Clear();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
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
            dgvDetail.Columns["GoodsFrom"].HeaderText = "Requested By";
            dgvDetail.Columns["Note_ID"].HeaderText = "Re-Order Status";
            dgvDetail.Columns["ItemSubCategoryID1"].HeaderText = clsConfig.sItemSubCategory;
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            lblCancelled.Visible = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPurchaseRequisitionNoteID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStockNoteType, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, true);
            setEnableItems(false);
            clsCommon.SetEnableDisable_NormalLabel(lblGoodreceivedNoteID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblStockNoteType, true);

            if (clsConfig.bShow_GridViewColumn_Remarks)
                dgvDetail.Columns["Remarks"].Visible = true;
            else
                dgvDetail.Columns["Remarks"].Visible = false;

            btnAddItem.Enabled = false;
            txtDepartmentID.Tag = null;
            txtSectionID.Tag = null;
            txtStoreID.Tag = null;
            txtjobID.Tag = null;
            txtItemID.Tag = null;
            txtItemSubCategory.Tag = null;
            txtItemSerialNo.Tag = null;
            txtOrderRefNo.Tag = null;
            txtStockNoteType.Tag = null;

            txtItemSerialNo.Clear();
            txtItemSubCategory.Clear();
            txtPurchaseRequisitionNoteID.Clear();
            txtRemark.Clear();
            txtDepartmentID.Clear();
            txtSectionID.Clear();
            txtStoreID.Clear();
            txtjobID.Clear();
            txtItemID.Clear();
            txtSRNo.Clear();
            txtOrderRefNo.Clear();
            txtStockNoteType.Clear();
            chkPrintOriginal.Checked = false;

            bHasApproved = false;
            bHasChecked = false;
            userDetailsColorChanges();

            //chkSettings.Checked = true;
            dgvDetail.Rows.Clear();
            dtpPRNDate.Value = clsSecurity.getServerDateTime();
            glbSRs.Clear();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtPurchaseRequisitionNoteID.Text = "<Auto Generate>";
            else
                txtPurchaseRequisitionNoteID.Clear();
            if (txtPurchaseRequisitionNoteID.Enabled)
            {
                txtPurchaseRequisitionNoteID.SelectAll();
                txtPurchaseRequisitionNoteID.Focus();
            }

            chkShowSettle.Checked = false;

            Attachments.Clear();
        }
        #endregion

        #region Clear Items and Jobs
        private void clearItamAndJob()
        {
            txtItemID.Tag = null;
            txtjobID.Tag = null;
            txtItemID.Clear();
            txtjobID.Clear();
        }
        #endregion

        #region Clear Location Field
        private void clearLocationFields()
        {
            txtDepartmentID.Tag = null;
            txtSectionID.Tag = null;
            txtStoreID.Tag = null;
            txtjobID.Tag = null;
            txtItemID.Tag = null;
            txtDepartmentID.Clear();
            txtSectionID.Clear();
            txtStoreID.Clear();
            txtjobID.Clear();
            txtItemID.Clear();
            setEnableItems(false);
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (sID.Length > 0)
                {
                    tbl_scsPurchaseRequisition detail = tbl_scsPurchaseRequisition.Select(sID);
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

                            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPurchaseRequisitionNoteID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStockNoteType, false);
                        clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblGoodreceivedNoteID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblStockNoteType, false);

                        //asign values                    
                        txtDepartmentID.Tag = detail.FromDepartment_ID;
                        txtSectionID.Tag = detail.FromSection_ID;
                        txtStoreID.Tag = detail.FromStore_ID;
                        txtStockNoteType.Tag = detail.StockNoteType_ID;

                        //fill order detials
                        tbl_zIssuedRefNo order = tbl_zIssuedRefNo.Select(detail.IssuedRefNo_ID);
                        if (order != null)
                        {
                            txtOrderRefNo.Tag = order.IssuedRefNo_ID;
                            txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(order.IssuedRefNo);
                        }


                        txtPurchaseRequisitionNoteID.Text = detail.PurchaseRequisitionNote_ID;
                        txtRemark.Text = detail.Remark;
                        dtpPRNDate.Value = detail.PurchaseRequisitionNoteDate;
                        txtDepartmentID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Department(detail.FromDepartment_ID));
                        txtSectionID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Section(detail.FromSection_ID));
                        txtStoreID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(detail.FromStore_ID));
                        txtStockNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_StockNoteType(detail.StockNoteType_ID));

                        //chkSettings.Checked = false;


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
                        RefreshGrid(detail.PurchaseRequisitionNote_ID);

                        //Fill Process Flow
                        clsHelpMethods_Local.SetProcessFlow_Stock_External(detail.IssuedRefNo_ID, txtFlowPR, txtFlowPO, txtFlowGRN, txtFlowPRN);

                        Attachments.FillAttachments(sID);
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
        private void FillDetailsFromSR(string sSR_ID)
        {
            try
            {
                tbl_scsDepartmentReqositionNote oSR_Department = tbl_scsDepartmentReqositionNote.Select(txtSRNo.Text.Trim());
                if (oSR_Department != null)
                {
                    //Pls Do
                }

                tbl_scsSectionReqositionNote oSR_Section = tbl_scsSectionReqositionNote.Select(txtSRNo.Text.Trim());
                if (oSR_Section != null)
                {
                    glbSRs.Add(oSR_Section.SectionReqositionNote_ID);
                    FillDetailsTextBoxes("default", oSR_Section.FromSection_ID, "default", oSR_Section.ToStore_ID, sSR_ID, oSR_Section.IssuedRefNo_ID);
                    RefreshGridBySectionSRN_ID(oSR_Section.SectionReqositionNote_ID);
                }

                tbl_scsStoreReqositionNote oSR_Store = tbl_scsStoreReqositionNote.Select(txtSRNo.Text.Trim());
                if (oSR_Store != null)
                {
                    glbSRs.Add(oSR_Store.StoreRecositionNote_ID);
                    FillDetailsTextBoxes("default", "default", oSR_Store.FromStore_ID, oSR_Store.ToStore_ID, sSR_ID, oSR_Store.IssuedRefNo_ID);
                    RefreshGridByStoreSRN_ID(oSR_Store.StoreRecositionNote_ID);
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void FillDetailsTextBoxes(string sDepartmentID, string sSectionID, string sStoreID, string sLocationID, string sRequisitionID, string sIssueRefID)
        {
            try
            {
                txtDepartmentID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Department(sDepartmentID));
                txtSectionID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Section(sSectionID));
                txtStoreID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(sStoreID));


                txtDepartmentID.Tag = sDepartmentID;
                txtSectionID.Tag = sSectionID;
                txtStoreID.Tag = sStoreID;


                txtSRNo.Text = sRequisitionID;
                txtSRNo.Tag = sRequisitionID;

                //add order ref detail           
                txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_IssuedRefNo(sIssueRefID));
                txtOrderRefNo.Tag = sIssueRefID;
                clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, false);
                clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, false);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Stock Datagrid
        public void Fill_StockDatagrid(DataGridView dgvDetail, int iRow, int iLineNo, string sItemID, string sUom_ID,
           string sJobCode, string sSelectArea_ID, string sDepartment_ID, string sSection_ID, string sStore_ID,
           string sDepartmentNote_ID, string sSectionNote_ID, string sStoreNote_ID, string sGoodsFrom,
           string sNoteID, decimal dQuantity, decimal dWeight, string sItemSubCategory1, string sItemSubCategory2,
           string sSerial1, string sSerial2, string sItemStatus, string sRemarks)
        {
            try
            {
                //  bool bItemExist = false;
                //foreach (DataGridViewRow row in dgvDetail.Rows)
                //{
                //    string sTmpItemID = "", sTmpItemSub = "", sTmpItemSub2 = "", sTmpSerial = "", sTmpSerial2 = "";
                //    sTmpItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                //    sTmpItemSub = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                //    sTmpItemSub2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                //    sTmpSerial = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                //    sTmpSerial2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");

                //    if (sItemID == sTmpItemID && sItemSubCategory1 == sTmpItemSub && sItemSubCategory2 == sTmpItemSub2 && sSerial1 == sTmpSerial && sSerial2 == sTmpSerial2)
                //    {
                //        dgvDetail.Rows.RemoveAt(iRow);
                //        dQuantity += clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                //        dWeight += clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                //        iRow = row.Index;
                //        break;
                //    }
                //}
                decimal UnitPrice = 0, WeightAvg = 0;
                clsHelpMethods_Local.AddMultipleItems_Grid(dgvDetail, sItemID, ref iRow, ref iLineNo, ref dQuantity, ref UnitPrice, ref dWeight, ref WeightAvg);

                dgvDetail["LineNo", iRow].Value = iLineNo;
                dgvDetail["ItemCode", iRow].Value = sItemID;
                dgvDetail["ItemName", iRow].Value = clsGenaralName.getName_Item(sItemID);
                dgvDetail["UOM", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Uom(sUom_ID));
                dgvDetail["UOM", iRow].Tag = sUom_ID;
                dgvDetail["ItemStatus", iRow].Value = sItemStatus;

                dgvDetail["SelectArea_ID", iRow].Value = sSelectArea_ID;
                dgvDetail["Department_ID", iRow].Value = sDepartment_ID;
                dgvDetail["Section_ID", iRow].Value = sSection_ID;
                dgvDetail["Store_ID", iRow].Value = sStore_ID;
                dgvDetail["DepartmentNote_ID", iRow].Value = sDepartmentNote_ID;
                dgvDetail["SectionNote_ID", iRow].Value = sSectionNote_ID;
                dgvDetail["StoreNote_ID", iRow].Value = sStoreNote_ID;
                dgvDetail["JobCode", iRow].Value = clsCommon.GetForeignKeyValue(sJobCode);
                dgvDetail["GoodsFrom", iRow].Value = clsCommon.GetForeignKeyValue(sGoodsFrom);
                dgvDetail["Note_ID", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(clsHelpMethods_Local.GetQty_MinimumPR(sItemID, sItemSubCategory1, sItemSubCategory2, sSerial1, sSerial2));  //clsCommon.GetForeignKeyValue(sNoteID);


                dgvDetail["ItemSubCategoryID1", iRow].Tag = sItemSubCategory1;
                dgvDetail["ItemSubCategoryID1", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(sItemSubCategory1));
                dgvDetail["ItemSubCategoryID2", iRow].Tag = sItemSubCategory2;
                dgvDetail["ItemSubCategoryID2", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory2(sItemSubCategory2));
                dgvDetail["ItemSerialNo1", iRow].Value = sSerial1;
                dgvDetail["ItemSerialNo2", iRow].Value = sSerial2;

                dgvDetail["Quantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(dQuantity);
                dgvDetail["Weight", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(dWeight);

                dgvDetail["Remarks", iRow].Value = sRemarks;

                #region Set Row Count
                dgvDetail["RowCount", iRow].Value = iRow + 1;
                #endregion

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string sSRNID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                List<tbl_scsPurchaseRequisition_Detail> details = tbl_scsPurchaseRequisition_Detail.SelectAllByPurchaseRequisitionNote_ID(sSRNID).OrderBy(p => p.Line_No).ToList();
                foreach (tbl_scsPurchaseRequisition_Detail detail in details)
                {

                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    string sToLocation = clsHelpMethods_Local.getToLocationName(detail.FromSelectArea_ID, detail.FromDepartment_ID, detail.FromSection_ID, detail.FromStore_ID);
                    string sNoteID = clsHelpMethods_Local.GetSelectAreaNoteID(detail.FromSelectArea_ID, detail.DepartmentReqositionNote_ID, detail.SectionReqositionNote_ID, detail.StoreRecositionNote_ID);

                    Fill_StockDatagrid(dgvDetail, iRow, detail.Line_No, detail.Item_ID, detail.Uom_ID, detail.Job_ID, detail.FromSelectArea_ID, detail.FromDepartment_ID, detail.FromSection_ID,
                        detail.FromStore_ID, detail.DepartmentReqositionNote_ID, detail.SectionReqositionNote_ID, detail.StoreRecositionNote_ID, sToLocation, sNoteID, detail.Qty, detail.Weight, detail.ItemSubCategory_ID,
                        detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, "O", detail.Remark);


                    if (detail.IsLocked)
                        dgvDetail.Rows[iRow].DefaultCellStyle.ForeColor = clsCommon.ColourForLockedRecord;
                }
                //dgvDetail.Rows.Add();

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridByJob_ID(string sJob_ID)
        {
            try
            {
                int iRow;
                //List<tbl_pmsPrePlan> PrePlans = tbl_pmsPrePlan.SelectAllByProductionJob_ID(sJob_ID);
                //foreach (tbl_pmsPrePlan PrePlan in PrePlans)
                //{
                //    List<tbl_pmsPrePlan_SectionPath_InputItem> inputs = tbl_pmsPrePlan_SectionPath_InputItem.SelectAllByPrePlan_ID(PrePlan.PrePlan_ID);
                //    foreach (tbl_pmsPrePlan_SectionPath_InputItem input in inputs)
                //    {
                //        dgvDetail.Rows.Add();
                //        iRow = dgvDetail.Rows.Count - 1;
                //        ValidateEmptyForeignKey();
                //        string sFromLocation = clsHelpMethods_Local.getToLocationName(txtDepartmentID, txtSectionID, txtStoreID);
                //        string sNoteID = "N/A";

                //        tbl_genItemMaster item = tbl_genItemMaster.Select(input.Item_ID);
                //        if (item != null)
                //        {
                //            Fill_StockDatagrid(dgvDetail, iRow, input.Line_No, item.Item_ID, item.Uom_ID, sJob_ID, getSelectAriaID(), getToDepartment(),
                //                 getToSection(), getToStore(), "default", "default", "default", sFromLocation, sNoteID, input.Qty,
                //                 input.Weight, "default", "default", "0", "0", "N", "");
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridBySectionSRN_ID(string sGIN_ID)
        {
            try
            {
                int iRow;
                List<tbl_scsSectionReqositionNote_Detail> details = tbl_scsSectionReqositionNote_Detail.SelectAllBySectionReqositionNote_ID(sGIN_ID).OrderBy(p => p.Line_No).ToList();
                foreach (tbl_scsSectionReqositionNote_Detail detail in details)
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    ValidateEmptyForeignKey();
                    string sFromLocation = clsGenaralName.getName_Section(detail.FromSection_ID);
                    string sFromNoteID = detail.SectionReqositionNote_ID;
                    decimal dQty = detail.Qty - detail.QtySettle, dWeight = detail.Weight - detail.WeightSettle;

                    Fill_StockDatagrid(dgvDetail, iRow, detail.Line_No, detail.Item_ID, detail.Uom_ID, detail.Job_ID, getSelectAriaID(), "default",
                        detail.FromSection_ID, "default", "default", sFromNoteID, "default", sFromLocation, sFromNoteID, dQty, dWeight,
                        detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, "N", detail.Remark);
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridByDepartmentSRN_ID(string sGIN_ID)
        {
            //Pls Do
        }
        private void RefreshGridByStoreSRN_ID(string sSRN_No)
        {
            try
            {
                int iRow;
                List<tbl_scsStoreReqositionNote_Detail> details = tbl_scsStoreReqositionNote_Detail.SelectAllByStoreRecositionNote_ID(sSRN_No).OrderBy(p => p.Line_No).ToList();
                int a = details.Count;
                foreach (tbl_scsStoreReqositionNote_Detail detail in details)
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    ValidateEmptyForeignKey();
                    string sFromLocation = clsGenaralName.getName_Store(detail.FromStore_ID);
                    string sFromNoteID = detail.StoreRecositionNote_ID;
                    decimal dQty = detail.Qty - detail.QtySettle, dWeight = detail.Weight - detail.WeightSettle;

                    Fill_StockDatagrid(dgvDetail, iRow, detail.Line_No, detail.Item_ID, detail.Uom_ID, detail.Job_ID, detail.ToSelectArea_ID, "default", "default", detail.FromStore_ID,
                        "default", "default", sFromNoteID, sFromLocation, sFromNoteID, dQty, dWeight,
                       detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, "N", detail.Remark);
                }

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
                string sJobID = "default";
                tbl_genItemMaster detail = tbl_genItemMaster.Select(sItem_ID);
                if (detail != null)
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    if (txtjobID.Tag != null && clsConfig.bJobIdRequiredGIN)
                        sJobID = txtjobID.Tag.ToString();

                    var maxLineNo = dgvDetail.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["LineNo"].Value));
                    Fill_StockDatagrid(dgvDetail, iRow, maxLineNo + 1, detail.Item_ID, detail.Uom_ID, sJobID, getSelectAriaID(), getToDepartment(),
                        getToSection(), getToStore(), "default", "default", "default", getSelectToLocationID(), "N/A", 0, 0,
                        txtItemSubCategory.Tag.ToString(), txtItemSubCategory.Text.Trim(), txtItemSerialNo.Tag.ToString(), txtItemSerialNo.Text.Trim(), "N", detail.Remark);
                }
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
        private void txtjobID_DoubleClick(object sender, EventArgs e)
        {
            clearItamAndJob();
            Search_JobID();
        }
        private void txtGoodreceivedNoteID_DoubleClick(object sender, EventArgs e)
        {
            Search_PurchaseRequestionNote();
        }
        private void txtItemID_DoubleClick(object sender, EventArgs e)
        {
            if (!clsConfig.bJobIdRequiredGIN)
                clearItamAndJob();
            Search_ItemID();
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
        private void txtLocationID_DoubleClick(object sender, EventArgs e)
        {
            Search_StoreTo();
        }
        private void txtStockNoteType_DoubleClick(object sender, EventArgs e)
        {
            Search_StockNoteType();
        }
        private void txtCheckedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }
        private void txtApprovedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }
        private void txtSRNo_DoubleClick(object sender, EventArgs e)
        {
            loadSRNnumber();
        }
        #endregion

        #region Events KeyDown
        private void txtGoodreceivedNoteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_PurchaseRequestionNote();
            }
        }
        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (!clsConfig.bJobIdRequiredGIN)
                    clearItamAndJob();
                Search_ItemID();
            }
        }
        private void txtSRNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                loadSRNnumber();
            }
        }
        private void txtjobID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clearItamAndJob();
                Search_JobID();
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
        private void txtStockNoteType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_StockNoteType();
            }
        }
        private void txtLocationID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_StoreTo();
            }
        }
        private void txtApprovedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_ApprovedBy();
            }
        }
        private void txtCheckedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CheckedBy();
            }
        }
        private void frm_sasStoreGoodReceiveNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;
            //if (clsValidate.ValidateTextBox_EmptyValue(txtOrderRefNo, "Tracking No"))
            //{
            if (clsValidate.ValidateTextBox_EmptyValue(txtStockNoteType, "Stock Note Type"))
            {
                bStatus = true;
            }
            //}            

            ValidateEmptyForeignKey();

            return bStatus;
        }
        private bool CheckJobSelectValidity()
        {
            string strMessage = "";
            bool bStatus = true;
            if (clsConfig.bJobIdRequiredGIN)
            {
                if (txtjobID.Tag == null || txtjobID.Tag.ToString().ToLower() == "default")
                {
                    strMessage += "Job Order ";
                    bStatus = false;
                }
                if (bStatus == false)
                {
                    MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return bStatus;
        }
        private bool CheckStockValidity()
        {
            //   string strMessage = "", sItemCode = "";
            //  decimal dWeightActual = 0;
            bool bStatus = true;
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
        private bool ValidateForDependancies(string sPRId)
        {
            bool bValue = true;
            try
            {
                foreach (tbl_scsPurchaseOrder oPO in tbl_scsPurchaseOrder.SelectAll().Where(p => p.PurchaseRequisitionNote_ID == sPRId))
                {
                    if (oPO.PurchaseOrder_ID != "default" && !oPO.IsDeleted)
                    {
                        bValue = false;
                        MessageBox.Show("Record Is Locked! \n\n[" + oPO.PurchaseOrder_ID + "] Purchase Order is already created for this Purchase Return Note", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            clsCommon.ValidateForeignKey(ref txtDepartmentID);
            clsCommon.ValidateForeignKey(ref txtSectionID);
            clsCommon.ValidateForeignKey(ref txtStoreID);
            clsCommon.ValidateForeignKey(ref txtItemID);
            clsCommon.ValidateForeignKey(ref txtjobID);
        }
        #endregion

        #region Load SRN Number
        private void loadSRNnumber()
        {
            if (clsValidate.ValidateTextBox_EmptyValue(txtStoreID, "Store Name"))
            {
                if (txtDepartmentID.Tag != null && txtDepartmentID.Tag.ToString().Trim() != "default")
                    Search_DepartmentStoreReqositionNote();
                else if (txtSectionID.Tag != null && txtSectionID.Tag.ToString().Trim() != "default")
                    Search_SectionStoreReqositionNote();
                else if (txtStoreID.Tag != null && txtStoreID.Tag.ToString().Trim() != "default")
                    Search_StoreGoodReqositionNote();
            }
        }
        #endregion

        #region Search Methods
        private void Search_JobID()
        {
            clsSearch.Search_MasterProductionJob(ref txtjobID);
        }
        private void Search_ItemID()
        {
            clsHelpMethods_Local.SearchItemAdvance(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo);
            if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                btnAddItem_Click(btnAddItem, new EventArgs());
        }
        private void Search_DepartmentStoreReqositionNote()
        {
            clsSearch.Search_TransactionDepartmentStoreReqositionNote_Use(ref txtSRNo, txtDepartmentID.Tag.ToString());
            if (txtSRNo.Text.Trim().Length > 0)
                btnAddStoreRequestion_Click(null, null);
        }
        private void Search_SectionStoreReqositionNote()
        {
            clsSearch.Search_TransactionSectionStoreReqositionNote_Use(ref txtSRNo, txtSectionID.Tag.ToString(), true);
            if (txtSRNo.Text.Trim().Length > 0)
                btnAddStoreRequestion_Click(null, null);
        }
        private void Search_StoreGoodReqositionNote()
        {
            clsSearch.Search_TransactionStoreStoreReqositionNote_Use(ref txtSRNo, txtStoreID.Tag.ToString(), true);
            if (txtSRNo.Text.Trim().Length > 0)
                btnAddStoreRequestion_Click(null, null);
        }
        private void Search_PurchaseRequestionNote()
        {
            if (txtStockNoteType.Tag != null)
                clsSearch.Search_TransactionPurchaseReqositionNote_Direct(ref txtPurchaseRequisitionNoteID, chkShowSettle.Checked, txtStockNoteType.Tag.ToString());
            else
                clsSearch.Search_TransactionPurchaseReqositionNote_Direct(ref txtPurchaseRequisitionNoteID, chkShowSettle.Checked);

            if (txtPurchaseRequisitionNoteID.Tag != null && txtPurchaseRequisitionNoteID.Tag.ToString().Trim() != "default")
            {
                txtPurchaseRequisitionNoteID.Text = txtPurchaseRequisitionNoteID.Tag.ToString();
                FillDetails(txtPurchaseRequisitionNoteID.Text.Trim());
            }
        }
        private void Search_StoreGoodReceiveNote()
        {
            clsSearch.Search_TransactionStoreReqositionNote_Use(ref txtSRNo);
            if (txtSRNo.Text.Trim().Length > 0 && txtSRNo.Text.Trim() == "default")
            {
                btnAddStoreRequestion_Click(null, new EventArgs());
            }
        }
        private void Search_Department()
        {
            clsSearch.Search_MasterDepartment(ref txtDepartmentID);
            if (txtDepartmentID.Tag != null)
                setEnableItems(true);
        }
        private void Search_Section()
        {
            clsSearch.Search_MasterSection(ref txtSectionID);
            if (txtSectionID.Tag != null)
                setEnableItems(true);
        }
        private void Search_Store()
        {
            clsSearch.Search_MasterStore(ref txtStoreID, true);
            if (txtStoreID.Tag != null)
                setEnableItems(true);
        }
        private void Search_StockNoteType()
        {
            clsSearch.Search_MasterStockNoteType(ref txtStockNoteType);
        }
        private void Search_StoreTo()
        {
            //clsSearch.Search_MasterStore(ref txtLocationID);
        }


        private void fillDataGrid(DataGridView dgvDetail, int iRow, string sItemID, string sItemSubCategory1, string sItemSubCategory2, string sSerial1, string sSerial2,
        string sJobCode, string sGoodsFrom, string sNoteID, decimal dQuantity, string sUom_ID, decimal dWeight, string sSelectArea_ID, string sDepartment_ID,
        string sSection_ID, string sStore_ID, string sDepartmentNote_ID, string sSectionNote_ID, string sStoreNote_ID, decimal dQtySettle,
        decimal dWeightSettle, decimal dTotalCostFIFO, decimal dTotalCostWA)
        {
            try
            {
                bool bItemExist = false;
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    string sTmpItemID = "", sTmpItemSub = "", sTmpItemSub2 = "", sTmpSerial = "", sTmpSerial2 = "";
                    sTmpItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                    sTmpItemSub = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                    sTmpItemSub2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                    sTmpSerial = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
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
                    //dgvDetail["ItemStatus", iRow].Value = sItemStatus;

                    dgvDetail["SelectArea_ID", iRow].Value = sSelectArea_ID;
                    dgvDetail["Department_ID", iRow].Value = sDepartment_ID;
                    dgvDetail["Section_ID", iRow].Value = sSection_ID;
                    dgvDetail["Store_ID", iRow].Value = sStore_ID;
                    dgvDetail["DepartmentNote_ID", iRow].Value = sDepartmentNote_ID;
                    dgvDetail["SectionNote_ID", iRow].Value = sSectionNote_ID;
                    dgvDetail["StoreNote_ID", iRow].Value = sStoreNote_ID;
                    dgvDetail["JobCode", iRow].Value = clsCommon.GetForeignKeyValue(sJobCode);
                    dgvDetail["GoodsFrom", iRow].Value = clsCommon.GetForeignKeyValue(sGoodsFrom);
                    dgvDetail["Note_ID", iRow].Value = clsCommon.GetForeignKeyValue(sNoteID);


                    dgvDetail["ItemSubCategoryID1", iRow].Tag = sItemSubCategory1;
                    dgvDetail["ItemSubCategoryID1", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(sItemSubCategory1));
                    dgvDetail["ItemSubCategoryID2", iRow].Tag = sItemSubCategory2;
                    dgvDetail["ItemSubCategoryID2", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory2(sItemSubCategory2));
                    dgvDetail["ItemSerialNo1", iRow].Value = sSerial1;
                    dgvDetail["ItemSerialNo2", iRow].Value = sSerial2;

                    dgvDetail["Quantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(dQuantity);
                    dgvDetail["Weight", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(dWeight);
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

        #region Set Enable/Desable Items
        private void setEnableItems(bool Val)
        {
            clearItamAndJob();
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSRNo, Val);
            clsCommon.SetEnableDisable_NormalLabel(lblSRNo, Val);
            btnAddStoreRequestion.Enabled = Val;
        }
        #endregion

        #region Get Select Aria ID
        private string getSelectAriaID()
        {
            string rtn = "";
            if (txtDepartmentID.Tag != null && txtDepartmentID.Tag.ToString().Trim() != "default")
                rtn = clsAutocode.getSelectAreaCode(SelectArea.Department);
            else if (txtSectionID.Tag != null && txtSectionID.Tag.ToString().Trim() != "default")
                rtn = clsAutocode.getSelectAreaCode(SelectArea.Section);
            else if (txtStoreID.Tag != null && txtStoreID.Tag.ToString().Trim() != "default")
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

        #region Print Method
        private void Print(bool bIsDraft)
        {
            try
            {
                if (txtPurchaseRequisitionNoteID.Text.Trim().Length > 0 && txtPurchaseRequisitionNoteID.Text.Trim() != "<Auto Generate>")
                {
                    if (!clsConfig.bDataSetActive_PurchseRequision)
                    {
                        #region views
                        //update receipt
                        string sCreateUser = "", sCheckedUser = "", sApprovedUser = "", sDuplicate = "", sGraft = "";

                        bool bPermissinOkToPrint = true;
                        if (chkPrintOriginal.Checked)
                            bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_PurchaseRequisitionNote));
                        if (bPermissinOkToPrint)
                        {
                            tbl_scsPurchaseRequisition sr = tbl_scsPurchaseRequisition.Select(txtPurchaseRequisitionNoteID.Text.ToString().Trim());
                            if (sr != null)
                            {
                                if (!bIsDraft)
                                {
                                    //sDuplicate = sr.PrintCount > 0 ? "Duplicate Copy " + sr.PrintCount : "";

                                    if (!chkPrintOriginal.Checked)
                                        sDuplicate = (sr.PrintCount > 0) ? "Duplicate Copy " + sr.PrintCount : "";

                                    sr.PrintCount++;
                                    sr.Update();
                                }

                                if (sr.IsDeleted)
                                    sDuplicate = "";

                                sCreateUser = "[ " + clsGenaralName.getName_User(sr.CreateUser_ID) + " ] [ " + sr.DateCreate.ToShortDateString() + " ]";
                                if (sr.IsChecked && sr.CheckedUser_ID != "default")
                                    sCheckedUser = "[ " + clsGenaralName.getName_User(sr.CheckedUser_ID) + " ] [ " + sr.DateChecked.ToShortDateString() + " ]";
                                if (sr.IsApproved && sr.ApprovedUser_ID != "default")
                                    sApprovedUser = "[ " + clsGenaralName.getName_User(sr.ApprovedUser_ID) + " ] [ " + sr.DateApproved.ToShortDateString() + " ]";

                            }

                            Cursor = Cursors.WaitCursor;
                            string s_Path = "", sReportTitle = "PURCHASE REQUISITION NOTE", sFormula = "";
                            sFormula = "{vw_rpt_scsPurchaseRequisition.purchaseRequisitionNote_ID} = '" + txtPurchaseRequisitionNoteID.Text.Trim() + "'";

                            ReportDocument RD = new ReportDocument();
                            s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");

                            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                s_Path += "\\reports\\SCS\\NotePrinting\\rpt_sasPurchaseRequisition_AKT.rpt";
                            else
                                s_Path += "\\reports\\SCS\\NotePrinting\\rpt_sasPurchaseRequisition.rpt";

                            frm_ReportViewer viewer = new frm_ReportViewer();
                            RD.Load(s_Path);
                          //  clsSecurity.LogonServer(ref RD);
                            RD.Refresh();

                            //RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                            RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                            RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToShortDateString());
                            RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
                            RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
                            RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);
                            RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                            RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                            RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                            RD.DataDefinition.FormulaFields["CompanyEmail"].Text = clsCommon.fncsetstring(clsCommon.getCompanyEmail());
                            RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                            RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                            //RD.DataDefinition.FormulaFields["isDel"].Text = clsCommon.fncsetstring(isDeleted ? "Canceled" : "");
                            sGraft = bIsDraft ? "Draft" : "";
                            RD.DataDefinition.FormulaFields["isDraft"].Text = clsCommon.fncsetstring(sGraft);
                            RD.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring(sDuplicate);

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
                        #endregion
                    }
                    else
                    {
                        #region dataset
                        try
                        {
                            string sDraft = "", sDeleted = "", sDuplicate = "";
                            string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                            if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_PurchaseRequisitionNote), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                            {
                                glb_dtsScsPurchaseRequisitionNote.Clear();
                                glb_dtsReportExport.Clear();
                                Cursor = Cursors.WaitCursor;

                                string sCreateUser = "", sCheckedUser = "", sApprovedUser = "";
                                bool bPermissinOkToPrint = true;
                                if (chkPrintOriginal.Checked)
                                    bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_PurchaseRequisitionNote));
                                if (bPermissinOkToPrint)
                                {
                                    tbl_scsPurchaseRequisition oPurchaseReq = tbl_scsPurchaseRequisition.Select(txtPurchaseRequisitionNoteID.Text);
                                    if (oPurchaseReq != null)
                                    {
                                        if (!bIsDraft)
                                        {
                                            //sDuplicate = oPurchaseReq.PrintCount > 0 ? "Duplicate Copy " + oPurchaseReq.PrintCount : "";

                                            if (!chkPrintOriginal.Checked)
                                                sDuplicate = (oPurchaseReq.PrintCount > 0) ? "Duplicate Copy " + oPurchaseReq.PrintCount : "";

                                            oPurchaseReq.PrintCount++;
                                            oPurchaseReq.DatePrinted = clsSecurity.getServerDateTime();
                                            oPurchaseReq.PrintedTerminal_ID = clsSecurity.TerminalID;
                                            oPurchaseReq.PrintedUser_ID = clsSecurity.UserIDLoged;

                                            oPurchaseReq.Update();
                                        }

                                        if (oPurchaseReq.IsDeleted)
                                        {
                                            sDeleted = "Deleted";
                                            sDuplicate = "";
                                        }

                                        sCreateUser = "[ " + clsGenaralName.getName_User(oPurchaseReq.CreateUser_ID) + " ] [ " + oPurchaseReq.DateCreate.ToShortDateString() + " ]";
                                        if (oPurchaseReq.CheckedUser_ID != "default")
                                            sCheckedUser = "[ " + clsGenaralName.getName_User(oPurchaseReq.CheckedUser_ID) + " ] [ " + oPurchaseReq.DateChecked.ToShortDateString() + " ]";
                                        if (oPurchaseReq.ApprovedUser_ID != "default")
                                            sApprovedUser = "[ " + clsGenaralName.getName_User(oPurchaseReq.ApprovedUser_ID) + " ] [ " + oPurchaseReq.DateApproved.ToShortDateString() + " ]";

                                        glb_dtsScsPurchaseRequisitionNote.dt_PurchaseRequisitionNote.Adddt_PurchaseRequisitionNoteRow(oPurchaseReq.PurchaseRequisitionNote_ID,
                                              oPurchaseReq.PurchaseRequisitionNoteDate, clsGenaralName.getName_Department(oPurchaseReq.FromDepartment_ID), clsGenaralName.getName_Section(oPurchaseReq.FromSection_ID), clsGenaralName.getName_Store(oPurchaseReq.FromStore_ID), clsGenaralName.getName_Area(oPurchaseReq.FromSelectArea_ID),
                                              oPurchaseReq.FromSelectArea_ID, oPurchaseReq.FromDepartment_ID, oPurchaseReq.FromStore_ID, oPurchaseReq.Remark, oPurchaseReq.Job_ID,
                                              oPurchaseReq.RequestedBy, oPurchaseReq.DateCreate, oPurchaseReq.IsDeleted, 0);

                                        foreach (tbl_scsPurchaseRequisition_Detail oDetails_PR in tbl_scsPurchaseRequisition_Detail.SelectAllByPurchaseRequisitionNote_ID(oPurchaseReq.PurchaseRequisitionNote_ID))
                                        {
                                            glb_dtsScsPurchaseRequisitionNote.dt_PurchaseRequisitionNoteDetail.Adddt_PurchaseRequisitionNoteDetailRow(oDetails_PR.PurchaseRequisitionNote_ID, oDetails_PR.Item_ID,
                                                "", oDetails_PR.ItemSerialNo, "", "", "", "", "", "",
                                                oDetails_PR.Qty, 0, oDetails_PR.Weight, oDetails_PR.Uom_ID, clsGenaralName.getName_Item(oDetails_PR.Item_ID),
                                                clsGenaralName.getName_Uom(oDetails_PR.Uom_ID), oDetails_PR.Remark);
                                        }
                                    }

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreatedUser", sCreateUser, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApprovedUser", sApprovedUser, true);

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true);
                                    //glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? clsCommon.fncsetstring("DRAFT") : "", true);

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DupicateCopy", sDuplicate, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("isDel", sDeleted, true);

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
                                        }
                                    }
                                    glb_dtsScsPurchaseRequisitionNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, sReportTitle_Main, sReportTitle_Sub, "", clsSecurity.UserNameLoged, "");
                                    #endregion

                                    frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                    rpt.print(sReportPath, glb_dtsScsPurchaseRequisitionNote, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_PurchaseRequisitionNote));
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
                            glb_dtsScsPurchaseRequisitionNote.Clear();
                            glb_dtsReportExport.Clear();
                            Cursor = Cursors.Default;
                        }
                        #endregion

                        //  glb_dtsScsPurchaseRequisitionNote.Clear();
                        ////  glb_dtsScsPurchaseRequisitionNote.dt_PurchaseRequisitionNoteDetail.Rows.Clear();

                        //  //fill Header
                        //  tbl_scsPurchaseRequisition detail = tbl_scsPurchaseRequisition.Select(txtPurchaseRequisitionNoteID.Text);
                        //  if (detail != null && detail.PurchaseRequisitionNote_ID != "default")
                        //  {
                        //      if (detail.PrintCount > 0)
                        //          isDuplicate = true;

                        //      detail.PrintCount++;
                        //      glb_dtsScsPurchaseRequisitionNote.dt_PurchaseRequisitionNote.Adddt_PurchaseRequisitionNoteRow(detail.PurchaseRequisitionNote_ID,
                        //          detail.PurchaseRequisitionNoteDate, clsGenaralName.getName_Department(detail.FromDepartment_ID), clsGenaralName.getName_Section(detail.FromSection_ID), clsGenaralName.getName_Store(detail.FromStore_ID), clsGenaralName.getName_Area(detail.FromSelectArea_ID),
                        //          detail.FromSelectArea_ID, detail.FromDepartment_ID, detail.FromStore_ID, detail.Remark, detail.Job_ID,
                        //          detail.RequestedBy, detail.DateCreate, detail.IsDeleted);

                        //      //fill invoice details
                        //      long LineNo = 1;
                        //      //foreach (tbl_scsPurchaseReturnedNote_Detail oDetail in tbl_scsPurchaseReturnedNote_Detail.SelectAllByPurchaseReturnedNote_ID(detail.PurchaseReturnedNote_ID))
                        //      //{
                        //      //    glb_dtsScsPurchaseRetNote.dt_PurchaseReturnNoteDetail.Adddt_PurchaseReturnNoteDetailRow(LineNo, oDetail.PurchaseReturnedNote_ID, oDetail.Item_ID, clsGenaralName.getName_Item(oDetail.Item_ID),
                        //      //        oDetail.ItemSubCategory_ID, oDetail.ItemSubCategory2_ID, oDetail.ItemSerialNo, oDetail.ItemSerialNo2, oDetail.Qty, oDetail.Weight, oDetail.KiloPrice, oDetail.UnitPrice, oDetail.UnitDiscount,
                        //      //        oDetail.TotalDiscount, oDetail.TatalAmount, oDetail.Remark,clsGenaralName.getName_ItemUOM(oDetail.Item_ID));
                        //      //    LineNo++;
                        //      //}
                        //      detail.Update();
                        //  }
                        ////  print("\\Reports\\SCS\\NotePrinting\\rpt_scsPurchaseReturnedNote.rpt", " Purchase Return Note ", glb_dtsScsPurchaseRetNote, detail.Supplier_ID);

                    }
                }
                else
                    MessageBox.Show("Please Select the Store Requisition Note To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            finally
            {
                glb_dtsScsPurchaseRequisitionNote.dt_PurchaseRequisitionNote.Rows.Clear();
                glb_dtsScsPurchaseRequisitionNote.dt_PurchaseRequisitionNoteDetail.Rows.Clear();
                Cursor = Cursors.Default;
            }

            #region Old code with views
            //try
            //{
            //    if (txtPurchaseRequisitionNoteID.Text.Trim().Length > 0 && txtPurchaseRequisitionNoteID.Text.Trim() != "<Auto Generate>")
            //    {
            //        //update receipt
            //        string sCreateUser = "", sCheckedUser = "", sApprovedUser = "";
            //        bool bIsDuplicate = false;
            //        tbl_scsPurchaseRequisition sr = tbl_scsPurchaseRequisition.Select(txtPurchaseRequisitionNoteID.Tag.ToString().Trim());
            //        if (sr != null)
            //        {
            //            //sr.PrintCount = sr.PrintCount + 1;
            //            //order.IsLocked = true;
            //            sCreateUser = "[ " + clsGenaralName.getName_User(sr.CreateUser_ID) + " ] [ " + sr.DateCreate.ToShortDateString() + " ]";
            //            if (sr.IsChecked && sr.CheckedUser_ID != "default")
            //                sCheckedUser = "[ " + clsGenaralName.getName_User(sr.CheckedUser_ID) + " ] [ " + sr.DateChecked.ToShortDateString() + " ]";
            //            if (sr.IsApproved && sr.ApprovedUser_ID != "default")
            //                sApprovedUser = "[ " + clsGenaralName.getName_User(sr.ApprovedUser_ID) + " ] [ " + sr.DateApproved.ToShortDateString() + " ]";
            //            if (sr.PrintCount > 0)
            //                bIsDuplicate = true;
            //            sr.PrintCount++;
            //            sr.Update();
            //        }

            //        Cursor = Cursors.WaitCursor;
            //        string s_Path = "", sReportTitle = "PURCHASE REQUISITION NOTE", sFormula = "";

            //        sFormula = "{vw_rpt_scsPurchaseRequisition.purchaseRequisitionNote_ID} = '" + txtPurchaseRequisitionNoteID.Text.Trim() + "'";

            //        ReportDocument RD = new ReportDocument();
            //        s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");


            //        if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
            //            s_Path += "\\reports\\SCS\\NotePrinting\\rpt_sasPurchaseRequisition_AKT.rpt";
            //        else
            //            s_Path += "\\reports\\SCS\\NotePrinting\\rpt_sasPurchaseRequisition.rpt";

            //        frm_ReportViewer viewer = new frm_ReportViewer();
            //        RD.Load(s_Path);
            //        clsSecurity.LogonServer(ref RD);
            //        RD.Refresh();

            //        //RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
            //        RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
            //        RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToShortDateString());
            //        RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
            //        RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
            //        RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);
            //        RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
            //        RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
            //        RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
            //        RD.DataDefinition.FormulaFields["CompanyEmail"].Text = clsCommon.fncsetstring(clsCommon.getCompanyEmail());
            //        RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
            //        RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

            //        if (bIsDuplicate)
            //            RD.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring("Duplicate Copy");

            //        viewer.crystalReportViewer1.ReportSource = RD;
            //        viewer.crystalReportViewer1.SelectionFormula = sFormula;
            //        viewer.crystalReportViewer1.Visible = true;
            //        viewer.crystalReportViewer1.DisplayToolbar = true;
            //        viewer.crystalReportViewer1.CloseView(false);
            //        viewer.WindowState = FormWindowState.Maximized;

            //        viewer.ShowDialog();

            //        RD.Close();
            //        RD.Dispose();
            //    }
            //    else
            //        MessageBox.Show("Please Select the Store Requisition Note To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //catch (Exception ex)
            //{
            //    SEACCException.Show(ex);
            //    clsValidate.WriteErrorLog("", iFormID,ex);
            //}
            //finally
            //{
            //    Cursor = Cursors.Default;
            //}
            #endregion
        }
        #endregion

        private void frm_scsPurchaseRequisitionNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            Attachments.Close();
        }

        #region User Checked Approve Details
        private void frm_scsPurchaseRequisitionNote_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_scsPurchaseRequisitionNote_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpPRNDate.Value.Date))
                {
                    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtPurchaseRequisitionNoteID.Text != null && txtPurchaseRequisitionNoteID.TextLength > 0 && txtPurchaseRequisitionNoteID.Text != "<Auto Generate>")
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

                                        tbl_scsPurchaseRequisition objPRN = tbl_scsPurchaseRequisition.Select(txtPurchaseRequisitionNoteID.Text.Trim());
                                        if (objPRN != null)
                                        {
                                            objPRN.IsApproved = true;
                                            objPRN.DateApproved = clsSecurity.getServerDateTime();
                                            objPRN.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                            objPRN.Update();
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
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpPRNDate.Value.Date))
                {
                    if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtPurchaseRequisitionNoteID.Text != null && txtPurchaseRequisitionNoteID.TextLength > 0 && txtPurchaseRequisitionNoteID.Text != "<Auto Generate>")
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

                                        tbl_scsPurchaseRequisition objPRN = tbl_scsPurchaseRequisition.Select(txtPurchaseRequisitionNoteID.Text.Trim());
                                        if (objPRN != null)
                                        {
                                            objPRN.IsChecked = true;
                                            objPRN.DateChecked = clsSecurity.getServerDateTime();
                                            objPRN.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objPRN.Update();
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

        private void frm_scsPurchaseRequisitionNote_SF_History_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPurchaseRequisitionNoteID.Text != "" || txtPurchaseRequisitionNoteID.Text != "<Auto Generate>")
                {
                    tbl_scsPurchaseRequisition detail = tbl_scsPurchaseRequisition.Select(txtPurchaseRequisitionNoteID.Text.Trim());
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
