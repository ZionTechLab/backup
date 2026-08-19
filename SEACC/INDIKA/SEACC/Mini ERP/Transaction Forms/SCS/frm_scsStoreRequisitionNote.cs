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
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using Zion.ERP.Reports.DataSets;
using Zion.ERP.Reports.DataSets.SCS;

namespace Digiteq
{
    public partial class frm_scsStoreRequisitionNote : SEACC_Form
    {
        
        //to manage update and insert
        //static bool IsUpdate = false;

        //form manage
        //string sFormConfigCode;
        //   public int iFormID;

        //to keep glob ref no        
        public string glbSRNo = "";

        //for security handle
        //public bool bNoAccess;
        //public bool bHasChecked;
        //public bool bHasApproved;
        ////    DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        //   DateTime glbCheckedDate = clsSecurity.getServerDateTime();

        dts_scsStoreRequisitionNote glb_dtsScsStoreRequisitionNote = new dts_scsStoreRequisitionNote();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
      

        #region Form Load
        public frm_scsStoreRequisitionNote(FormName _enmForm)
        {
            //sFormConfigCode = clsAutocode.getFormConfigCode(FormName.sasSRNTradingStock);
            //iFormID = clsSecurity.getFormID(FormName.sasSRNTradingStock);
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

            SetVisibility_ActionButons(true, true, true, true, false, true, true, true, true);
            clsFill.Fill_ItemPrices(ref cmbItemPrice);
            CusDataGridViewFormat();
            ClearFields();

            if (glbSRNo.Length > 0)
                FillDetails(glbSRNo);
        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void frm_scsStoreRequisitionNote_SF_newButton_Click(object sender, EventArgs e)
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
        private void frm_scsStoreRequisitionNote_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity_EmptyField())
            {
                if (CheckNumberValidity())
                {
                    if (clsValidate.CheckGridCountValidity(dgvDetail.RowCount, iFormID))
                    {
                        if (CheckStockValidity())
                        {
                            if (CheckValidity_Customer())
                            {
                                if (clsMethods_GL.CheckValidity_FinancialYear(dtpSRNDate.Value.Date))
                                {
                                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                                    {
                                        try
                                        {
                                            Cursor = Cursors.WaitCursor;
                                            ValidateEmptyForeignKey();

                                            if (IsUpdate)//update records
                                            {
                                                #region Update
                                                tbl_scsStoreReqositionNote oldRecord = tbl_scsStoreReqositionNote.Select(txtStoreRequisitionNoteID.Text.Trim());
                                                if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                                                {
                                                    if (ValidateForDependancies(oldRecord.StoreRecositionNote_ID))
                                                    {
                                                        //if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted && !oldRecord.IsChecked)
                                                        if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                                                        {
                                                            if (!oldRecord.IsChecked ||
                                                                (oldRecord.IsChecked &&
                                                                 clsSecurity.PermissionToApproved(
                                                                     clsSecurity.UserIDLoged, iFormID)))
                                                            {
                                                                if (clsValidate.CheckValidity_TransactionCodeLength(txtStoreRequisitionNoteID.Text))
                                                                {
                                                                    #region Delete old Items

                                                                    List<tbl_scsStoreReqositionNote_Detail>
                                                                        oldSRNDetails =
                                                                            tbl_scsStoreReqositionNote_Detail
                                                                                .SelectAllByStoreRecositionNote_ID(
                                                                                    oldRecord.StoreRecositionNote_ID);
                                                                    foreach (tbl_scsStoreReqositionNote_Detail
                                                                        oldSRNDetail in oldSRNDetails)
                                                                    {
                                                                        oldSRNDetail.Delete();
                                                                    }

                                                                    #endregion

                                                                    #region Update Items

                                                                    foreach (DataGridViewRow row in dgvDetail.Rows)
                                                                    {
                                                                        string sItemCode = "",
                                                                            sUom = "default",
                                                                            sJobCode = "",
                                                                            sSelectArea_ID = "",
                                                                            sDepartment_ID = "",
                                                                            sSection_ID = "",
                                                                            sStore_ID = "",
                                                                            sItemSubCategoryID1 = "",
                                                                            sItemSubCategoryID2 = "",
                                                                            sItemSerialNo1 = "",
                                                                            sItemSerialNo2 = "";
                                                                        decimal dWeight = 0,
                                                                            dQuantitiy = 0,
                                                                            dUnitPrice = 0,
                                                                            dWeightPrice = 0,
                                                                            dTotalAmount = 0;
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
                                                                        dUnitPrice =
                                                                            clsValidate.ValidateGridValue(dgvDetail,
                                                                                "ItemUnitPrice", row.Index,
                                                                                decimal.Parse("0.00"));
                                                                        dTotalAmount =
                                                                            clsValidate.ValidateGridValue(dgvDetail,
                                                                                "ItemTotalValue", row.Index,
                                                                                decimal.Parse("0.00"));

                                                                        tbl_scsStoreReqositionNote_Detail items =
                                                                            new tbl_scsStoreReqositionNote_Detail(
                                                                                iLineNo,
                                                                                txtStoreRequisitionNoteID.Text.Trim(),
                                                                                sItemCode, sItemSubCategoryID1,
                                                                                sItemSubCategoryID2, sItemSerialNo1,
                                                                                sItemSerialNo2, sJobCode,
                                                                                txtLocationID.Tag.ToString(),
                                                                                sSelectArea_ID, sDepartment_ID,
                                                                                sSection_ID, sStore_ID, sUom,
                                                                                dQuantitiy, 0, dWeight, 0, 0, 0, "",
                                                                                false, dUnitPrice, dWeightPrice,
                                                                                dTotalAmount);
                                                                        items.Insert();

                                                                    }

                                                                    #endregion

                                                                    #region Update SRN Header

                                                                    tbl_scsStoreReqositionNote detail =
                                                                        new tbl_scsStoreReqositionNote(
                                                                            txtStoreRequisitionNoteID.Text.Trim(),
                                                                            dtpSRNDate.Value, txtRemark.Text.Trim(),
                                                                            txtjobID.Tag.ToString(),
                                                                            txtLocationID.Tag.ToString(),
                                                                            getSelectAriaID(),
                                                                            txtDepartmentID.Tag.ToString(),
                                                                            txtSectionID.Tag.ToString(),
                                                                            txtStoreID.Tag.ToString(),
                                                                            txtOrderRefNo.Tag.ToString(),
                                                                            oldRecord.PurchaseRequisitionNote_ID,
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
                                                                            oldRecord.DatePrinted, oldRecord.IsChecked,
                                                                            oldRecord.IsApproved, oldRecord.IsFinished,
                                                                            oldRecord.IsDeleted, oldRecord.IsLocked,
                                                                            oldRecord.PrintCount, oldRecord.IsSeattled,
                                                                            oldRecord.IsPRdone,
                                                                            ((ComboBoxItem)cmbItemPrice.SelectedItem)
                                                                            .Value, oldRecord.CompanyID,
                                                                            oldRecord.CompanyBranch_ID);
                                                                    detail.Update();

                                                                    #endregion

                                                                    //Attachments.Remove(iFormID, oldRecord.StoreRecositionNote_ID);
                                                                    //Attachments.Insert(iFormID, oldRecord.StoreRecositionNote_ID);

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
                                                    txtStoreRequisitionNoteID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                                //create order ref number
                                                if (txtOrderRefNo.Tag == null || txtOrderRefNo.Tag.ToString().Trim() == "default")
                                                {
                                                    txtOrderRefNo.Tag = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.zIssuedRefNo));
                                                    tbl_zIssuedRefNo orf = new tbl_zIssuedRefNo(txtOrderRefNo.Tag.ToString().Trim(), txtOrderRefNo.Text != "" ? txtOrderRefNo.Text.Trim() : "-");
                                                    orf.Insert();
                                                }

                                                if (clsValidate.CheckValidity_TransactionCodeLength(txtStoreRequisitionNoteID.Text)) //if (txtStoreRequisitionNoteID.Text.Trim().Length > 0)
                                                {
                                                    #region SRN Header
                                                    tbl_scsStoreReqositionNote detail = new tbl_scsStoreReqositionNote(txtStoreRequisitionNoteID.Text.Trim(), dtpSRNDate.Value, txtRemark.Text.Trim(),
                                                        txtjobID.Tag.ToString(), txtLocationID.Tag.ToString(), getSelectAriaID(), txtDepartmentID.Tag.ToString(), txtSectionID.Tag.ToString(), txtStoreID.Tag.ToString(), txtOrderRefNo.Tag.ToString(), "default",
                                                        clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default",
                                                        clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                        clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                        bHasChecked, bHasApproved, false, false, false, 0, false, false, ((ComboBoxItem)cmbItemPrice.SelectedItem).Value, clsSecurity.CompanyID, clsSecurity.BranchID);
                                                    detail.Insert();
                                                    #endregion

                                                    //GRN Detail                                
                                                    #region SRN Detail
                                                    foreach (DataGridViewRow row in dgvDetail.Rows)
                                                    {
                                                        try
                                                        {
                                                            string sItemCode = "", sUom = "default", sJobCode = "", sSelectArea_ID = "", sDepartment_ID = "",
                                                            sSection_ID = "", sStore_ID = "",// sDepartmentNote_ID = "", sSectionNote_ID = "", sStoreNote_ID = "",
                                                            sItemSubCategoryID1 = "", sItemSubCategoryID2 = "", sItemSerialNo1 = "", sItemSerialNo2 = "";
                                                            decimal dWeight = 0, dQuantitiy = 0, dUnitPrice = 0, dWeightPrice = 0, dTotalAmount = 0;
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

                                                            //  sDepartmentNote_ID = "default";
                                                            //  sSectionNote_ID = "default";
                                                            // sStoreNote_ID = "default";
                                                            sItemSubCategoryID1 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                                                            sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                                            sItemSerialNo1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                                                            sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                                            dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "ItemUnitPrice", row.Index, decimal.Parse("0.00"));
                                                            //dWeight = clsValidate.ValidateGridValue(dgvDetail, "ItemUnitPrice", row.Index, decimal.Parse("0.00"));
                                                            dTotalAmount = clsValidate.ValidateGridValue(dgvDetail, "ItemTotalValue", row.Index, decimal.Parse("0.00"));

                                                            if (sItemCode.Length > 0)
                                                            {
                                                                tbl_scsStoreReqositionNote_Detail items = new tbl_scsStoreReqositionNote_Detail(iLineNo, txtStoreRequisitionNoteID.Text.Trim(),
                                                                    sItemCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, sJobCode, txtLocationID.Tag.ToString(),
                                                                    sSelectArea_ID, sDepartment_ID, sSection_ID, sStore_ID, sUom, dQuantitiy, 0, dWeight, 0, 0, 0, "", false, dUnitPrice, dWeightPrice, dTotalAmount);
                                                                items.Insert();
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            clsValidate.WriteErrorLog("", iFormID, ex);
                                                            SEACCException.Show(ex);
                                                        }
                                                    }
                                                    #endregion

                                                    Attachments.Insert(txtStoreRequisitionNoteID.Text.ToString());

                                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                //else
                                                //{
                                                //    MessageBox.Show("Store Requisition Note " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                            FillDetails(txtStoreRequisitionNoteID.Text.Trim());
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
        private void frm_scsStoreRequisitionNote_SF_printButton_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_scsStoreRequisitionNote_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region Btn Job
        private void BtnJob_Click(object sender, EventArgs e)
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
        #endregion

        #region Btn Add Item
        private void btnAddItem_Click(object sender, EventArgs e)
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
        #endregion

        #region Btn IGIN
        private void btnIGIN_Click(object sender, EventArgs e)
        {
            if (txtStoreRequisitionNoteID.Text != "default" && txtStoreRequisitionNoteID.Text.Trim().Length > 0 && txtStoreRequisitionNoteID.Text != "<Auto Generate>")
            {
                tbl_scsStoreReqositionNote detail = tbl_scsStoreReqositionNote.Select(txtStoreRequisitionNoteID.Text.ToString());
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
                                message = "APPROVAL NEEDED \n\nUser has to Approve the Internal Stock Requisition Note Before Create an Internal Goods Issue Note";
                            }
                        }

                        if (bAllowDetail)
                        {
                            if (detail.ToSelectArea_ID == clsAutocode.getSelectAreaCode(SelectArea.Store))
                            {
                                //frm_scsStoreGoodIssueNote frm = new frm_scsStoreGoodIssueNote();
                                //if (frm.bNoAccess)
                                //   MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption()+" ["+frm.iFormID+"]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //else
                                //{
                                //    frm.glbSRNo = detail.StoreRecositionNote_ID;
                                //    frm.MdiParent = this.MdiParent;
                                //    frm.Show();
                                //}

                                frm_scsStoreGoodIssueNote frm = new frm_scsStoreGoodIssueNote(FormName.sasGINTradingStock);
                                frm.glbSRNo = detail.StoreRecositionNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, (this.Parent as Form).MdiParent);
                            }
                            else if (detail.ToSelectArea_ID == clsAutocode.getSelectAreaCode(SelectArea.Section))
                            {
                                //frm_scsSectionGoodIssueNote frm = new frm_scsSectionGoodIssueNote();
                                //if (frm.bNoAccess)
                                //   MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption()+" ["+frm.iFormID+"]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //else
                                //{
                                //    frm.glbSRNo = detail.StoreRecositionNote_ID;
                                //    frm.MdiParent = this.MdiParent;
                                //    frm.Show();
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
                        MessageBox.Show("Already Issued \n\nThis Store Requisition Quantity has already being issued by Good Issue Note(s)", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        #region Btn Pending Quantity Info
        private void btnPendingQtyInfo_Click(object sender, EventArgs e)
        {
            if (dgvDetail.Rows.Count > 0 && txtStoreRequisitionNoteID.Text != "<Auto Generate>" && txtStoreRequisitionNoteID.Text != "")
            {
                RefreshGrid_PendingQty(txtStoreRequisitionNoteID.Text.ToString());
            }
        }
        #endregion

        #region Btn Temp
        private void frm_scsStoreRequisitionNote_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtStoreRequisitionNoteID.TextLength > 0 && txtStoreRequisitionNoteID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtStoreRequisitionNoteID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtLocationID, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, true);
                setEnableItems(true);
                clsCommon.SetEnableDisable_NormalLabel(lblGoodreceivedNoteID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblLocationID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, true);
                btnAddItem.Enabled = false;

                txtStoreRequisitionNoteID.Tag = null;
                dtpSRNDate.Value = clsSecurity.getServerDateTime();

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Order Ref No
                txtOrderRefNo.Tag = null;
                txtOrderRefNo.Clear();

                //Reset Primary Key
                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtStoreRequisitionNoteID.Text = "<Auto Generate>";
                else
                    txtStoreRequisitionNoteID.Clear();
                if (txtStoreRequisitionNoteID.Enabled)
                {
                    txtStoreRequisitionNoteID.SelectAll();
                    txtStoreRequisitionNoteID.Focus();
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
            dgvDetail.Columns["GoodsFrom"].HeaderText = "Requested From";
            dgvDetail.Columns["Note_ID"].HeaderText = "iSR Number";

            dgvDetail.Columns["Weight"].Visible = !clsConfig.bHide_GridViewColumn_Stock_Weight;
            dgvDetail.Columns["GoodsFrom"].Visible = !clsConfig.bHide_GridViewColumn_Stock_GoodsFrom;
            dgvDetail.Columns["Note_ID"].Visible = !clsConfig.bHide_GridViewColumn_Stock_NoteID;

            //edit by janith
            dgvDetail.Columns["CostPrice"].Visible = !clsConfig.bHide_GridViewColumn_Stock_CostPrice;
            dgvDetail.Columns["TotalCostPrice"].Visible = !clsConfig.bHide_GridViewColumn_Stock_TotalCostPrice;

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
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtStoreRequisitionNoteID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtLocationID, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, true);
            setEnableItems(false);
            clsCommon.SetEnableDisable_NormalLabel(lblGoodreceivedNoteID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblLocationID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, true);
            btnAddItem.Enabled = false;

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
            txtjobID.Tag = null;
            txtItemID.Tag = null;
            txtItemSubCategory.Tag = null;
            txtItemSerialNo.Tag = null;
            txtOrderRefNo.Tag = null;

            txtItemSerialNo.Clear();
            txtItemSubCategory.Clear();
            txtStoreRequisitionNoteID.Clear();
            txtRemark.Clear();
            txtLocationID.Clear();
            txtDepartmentID.Clear();
            txtSectionID.Clear();
            txtStoreID.Clear();
            txtjobID.Clear();
            txtItemID.Clear();
            txtOrderRefNo.Text = "";

            //chkSettings.Checked = true;

            bHasApproved = false;
            bHasChecked = false;
            userDetailsColorChanges();

            dtpSRNDate.Enabled = !clsConfig.bLock_TransactionDate_SCS;

            foreach (ComboBoxItem d in cmbItemPrice.Items)
            {
                if (d.Value == clsConfig.sItemUnitPriceCode_Default)
                {
                    cmbItemPrice.SelectedItem = d;
                    break;
                }
            }
            dgvDetail.Rows.Clear();

            dtpSRNDate.Value = clsSecurity.getServerDateTime();
            chkPrintOriginal.Checked = false;

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtStoreRequisitionNoteID.Text = "<Auto Generate>";
            else
                txtStoreRequisitionNoteID.Clear();
            if (txtStoreRequisitionNoteID.Enabled)
            {
                txtStoreRequisitionNoteID.SelectAll();
                txtStoreRequisitionNoteID.Focus();
            }

            chkShowSettle.Checked = false;
            ////clsFormatter.FormatProcessFlow(

            btnPendingQtyInfo.Visible = false;

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
            if (sID.Length > 0)
            {
                tbl_scsStoreReqositionNote detail = tbl_scsStoreReqositionNote.Select(sID);
                if (detail != null)
                {
                    //set the update flag and Locked
                    IsUpdate = true;
                    clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtStoreRequisitionNoteID, false);
                    //clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtLocationID, false);
                    clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, false);
                    clsCommon.SetEnableDisable_NormalLabel(lblGoodreceivedNoteID, false);
                    clsCommon.SetEnableDisable_NormalLabel(lblLocationID, false);
                    clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, false);

                    //asign values
                    txtLocationID.Tag = detail.FromStore_ID;
                    txtDepartmentID.Tag = detail.ToDepartment_ID;
                    txtSectionID.Tag = detail.ToSection_ID;
                    txtStoreID.Tag = detail.ToStore_ID;
                    txtjobID.Tag = detail.Job_ID;

                    //fill order detials
                    tbl_zIssuedRefNo order = tbl_zIssuedRefNo.Select(detail.IssuedRefNo_ID);
                    if (order != null)
                    {
                        txtOrderRefNo.Tag = order.IssuedRefNo_ID;
                        txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(order.IssuedRefNo);
                    }

                    if (detail.IsDeleted)
                        lblCancelled.Visible = true;
                    txtStoreRequisitionNoteID.Text = detail.StoreRecositionNote_ID;
                    txtRemark.Text = detail.Remark;
                    dtpSRNDate.Value = detail.StoreRecositionNoteDate;
                    txtLocationID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(detail.FromStore_ID));
                    txtDepartmentID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Department(detail.ToDepartment_ID));
                    txtSectionID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Section(detail.ToSection_ID));
                    txtStoreID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(detail.ToStore_ID));
                    txtjobID.Text = clsCommon.GetForeignKeyValue(detail.Job_ID);
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

                    if (!clsConfig.bHide_GridViewColumn_Store_PendingQty)
                        btnPendingQtyInfo.Visible = true;

                    //fill item details
                    RefreshGrid(detail.StoreRecositionNote_ID);

                    Attachments.FillAttachments(sID);

                    //Set Flow
                    clsHelpMethods_Local.SetProcessFlow_Stock_Internal(detail.IssuedRefNo_ID, txtFlowSR, txtFlowGIN, txtFlowGRN);
                }
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string sSRNID)
        {
            int iRow;
            dgvDetail.Rows.Clear();
            List<tbl_scsStoreReqositionNote_Detail> details = tbl_scsStoreReqositionNote_Detail.SelectAllByStoreRecositionNote_ID(sSRNID);
            foreach (tbl_scsStoreReqositionNote_Detail detail in details)
            {
                //decimal dPendingQty = clsHelpMethods.Get_StoreRequisition_PendingQty(sSRNID, detail.Item_ID, detail.Qty);
                //decimal dGINQty = clsHelpMethods.Get_StoreGIN_Qty(sSRNID, detail.Item_ID);
                //decimal dPendingQty = clsHelpMethods.Get_StoreRequisition_PendingQty(dGINQty, detail.Qty);

                dgvDetail.Rows.Add();
                iRow = dgvDetail.Rows.Count - 1;
                string sToLocation = clsHelpMethods_Local.getToLocationName(detail.ToSelectArea_ID, detail.ToDepartment_ID, detail.ToSection_ID, detail.ToStore_ID);
                string sNoteID = detail.StoreRecositionNote_ID;
                clsHelpMethods_Local.Fill_StockDatagrid(dgvDetail, iRow, detail.Line_No, detail.Item_ID, detail.Uom_ID, detail.Job_ID, detail.ToSelectArea_ID, detail.ToDepartment_ID, detail.ToSection_ID,
                    detail.ToStore_ID, "default", "default", "default", sToLocation, sNoteID, detail.Qty, detail.Weight, detail.ItemSubCategory_ID,
                    detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, "O", detail.UnitPrice, detail.TotalAmount, detail.Remark,0);
            }//detail.Item_ID
        }
        //private void RefreshGridByJob_ID(string sJob_ID)
        //{
        //    int iRow;
        //    List<tbl_pmsPrePlan> PrePlans = tbl_pmsPrePlan.SelectAllByProductionJob_ID(sJob_ID);
        //    foreach (tbl_pmsPrePlan PrePlan in PrePlans)
        //    {
        //        List<tbl_pmsPrePlan_SectionPath_InputItem> inputs = tbl_pmsPrePlan_SectionPath_InputItem.SelectAllByPrePlan_ID(PrePlan.PrePlan_ID);
        //        foreach (tbl_pmsPrePlan_SectionPath_InputItem input in inputs)
        //        {
        //            dgvDetail.Rows.Add();
        //            iRow = dgvDetail.Rows.Count - 1;
        //            ValidateEmptyForeignKey();
        //            string sToLocation = clsHelpMethods_Local.getToLocationName(txtDepartmentID, txtSectionID, txtStoreID);
        //            string sNoteID = "N/A";
        //            tbl_genItemMaster item = tbl_genItemMaster.Select(input.Item_ID);
        //            if (item != null)
        //            {
        //                clsHelpMethods_Local.Fill_StockDatagrid(dgvDetail, iRow, input.Line_No, item.Item_ID, item.Uom_ID, sJob_ID, getSelectAriaID(), txtDepartmentID.Tag.ToString(),
        //                     txtSectionID.Tag.ToString(), txtStoreID.Tag.ToString(), "default", "default", "default", sToLocation, sNoteID, input.Qty,
        //                     input.Weight, "default", "default", "0", "0", "N", 0, 0, "",0);
        //            }
        //        }
        //    }
        //}
        private void RefreshGridByItem_ID(string sItem_ID)
        {
            int iRow;
            string sJobID = "default";
            tbl_genItemMaster detail = tbl_genItemMaster.Select(sItem_ID);
            if (detail != null)
            {
                dgvDetail.Rows.Add();
                iRow = dgvDetail.Rows.Count - 1;
                ValidateEmptyForeignKey();
                string sToLocation = clsHelpMethods_Local.getToLocationName(txtDepartmentID, txtSectionID, txtStoreID);
                string sNoteID = "N/A";
                if (txtjobID.Tag != null && clsConfig.bJobIdRequiredGIN)
                    sJobID = txtjobID.Tag.ToString();

                decimal dUnitPrice = 0;
                string sItemPriceCategory = ((ComboBoxItem)cmbItemPrice.SelectedItem).Value;
                dUnitPrice = clsProcessMethods.GetRecommendedUnitPrice_Basic(detail.Item_ID, sItemPriceCategory);
                var maxLineNo = dgvDetail.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["LineNo"].Value));

                clsHelpMethods_Local.Fill_StockDatagrid(dgvDetail, iRow, maxLineNo + 1, detail.Item_ID, detail.Uom_ID, sJobID, getSelectAriaID(), txtDepartmentID.Tag.ToString(),
                    txtSectionID.Tag.ToString(), txtStoreID.Tag.ToString(), "default", "default", "default", sToLocation, sNoteID, 1, 0,
                    txtItemSubCategory.Tag.ToString(), txtItemSubCategory.Text.Trim(), txtItemSerialNo.Tag.ToString(), txtItemSerialNo.Text.Trim(), "N", dUnitPrice, dUnitPrice, "",0);
                dgvDetail.Focus();
            }
        }
        private void RefreshGrid_PendingQty(string sSRNID)
        {
            try
            {
                if (sSRNID != null)
                {
                    Cursor = Cursors.WaitCursor;
                    DataTable dtPendingQty = new DataTable();
                    dtPendingQty.Columns.Add("ItemCode", typeof(string));
                    dtPendingQty.Columns.Add("ItemName", typeof(string));
                    dtPendingQty.Columns.Add("Quantity", typeof(decimal));
                    dtPendingQty.Columns.Add("PendingQty", typeof(decimal));

                    dtPendingQty.Rows.Clear();
                    List<tbl_scsStoreReqositionNote_Detail> details = tbl_scsStoreReqositionNote_Detail.SelectAllByStoreRecositionNote_ID(sSRNID);
                    foreach (tbl_scsStoreReqositionNote_Detail detail in details)
                    {
                        //decimal dPendingQty = clsHelpMethods.Get_StoreRequisition_PendingQty(sSRNID, detail.Item_ID, detail.Qty);
                        dtPendingQty.Rows.Add(detail.Item_ID, clsGenaralName.getName_Item(detail.Item_ID), clsFormatter.FormatDecimalPlaces_Quantity(detail.Qty), clsFormatter.FormatDecimalPlaces_Quantity(detail.Qty - detail.QtySettle));
                    }
                    frm_iSRPendingQty_Display frm = new frm_iSRPendingQty_Display();
                    frm.ShowDetails(dtPendingQty);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Cursor = Cursors.Default;
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


                if (sColName == "ItemCode" || sColName == "ItemName" || sColName == "ItemSubCategoryID1" || sColName == "GoodsFrom" || sColName == "Note_ID" || sColName == "UOM")
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


                if (sColName == "ItemCode" || sColName == "ItemName" || sColName == "ItemSubCategoryID1" || sColName == "GoodsFrom" || sColName == "Note_ID" || sColName == "UOM")
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
            Search_StoreGoodReceiveNote();
        }

        private void txtItemID_DoubleClick(object sender, EventArgs e)
        {
            Search_ItemID(sender, new KeyEventArgs(Keys.F1));
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

        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            Search_ItemID(sender, e);
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
            else if (e.KeyCode == Keys.Tab)
            {
                txtOrderRefNo.Focus();
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
            else if (e.KeyCode == Keys.F9)
            {
                btnNew_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F10)
            {
                frm_scsStoreRequisitionNote_SF_saveButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F11)
            {
                btnRemove_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F12)
            {
                frm_scsStoreRequisitionNote_SF_printButton_Click(sender, e);
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
        private void txtOrderRefNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                cmbItemPrice.Focus();
            }
        }
        #endregion

        #region Events KeyUp
        private void dgvDetail_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                txtItemID.Focus();
            }
        }
        #endregion

        #region Print Method
        private void Print(bool bIsDraft)
        {
            try
            {
                if (txtStoreRequisitionNoteID.Text.Trim().Length > 0 && txtStoreRequisitionNoteID.Text.Trim() != "<Auto Generate>")
                {
                    
                    string sCreateUser = "", sCheckedUser = "", sApprovedUser = "", sDuplicateCopy = "";
                    bool bOkToPrint = false, bApprovalDone = false;
                    string isDraft = string.Empty;
                    #endregion

                    bool bPermissinOkToPrint = true;
                    if (chkPrintOriginal.Checked)
                        bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_iSRN));
                    if (bPermissinOkToPrint)
                    {
                        tbl_scsStoreReqositionNote oStore = tbl_scsStoreReqositionNote.Select(txtStoreRequisitionNoteID.Text.Trim());
                        if (oStore != null)
                        {
                            #region Dataset New
                            //change config
                            if (clsConfig.bPrintPreviewSetActive_StoreRequisition)
                            {
                                string sGetRptPath = clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_iSRN));
                                if (sGetRptPath != null)
                                {
                                    glb_dtsScsStoreRequisitionNote.Clear();
                                    glb_dtsReportExport.Clear();

                                    #region Store Requisition Header
                                    glb_dtsScsStoreRequisitionNote.dt_scsStoreRequisitionNote.Adddt_scsStoreRequisitionNoteRow(oStore.StoreRecositionNote_ID, oStore.PurchaseRequisitionNote_ID, oStore.StoreRecositionNoteDate, oStore.Job_ID, oStore.IssuedRefNo_ID, oStore.FromStore_ID, clsGenaralName.getName_Store(oStore.FromStore_ID), oStore.ToStore_ID, clsGenaralName.getName_Store(oStore.ToStore_ID), oStore.ToDepartment_ID, clsGenaralName.getName_Department(oStore.ToDepartment_ID), oStore.ToSection_ID, clsGenaralName.getName_Section(oStore.ToSection_ID), oStore.ToSelectArea_ID, oStore.DateCreate, oStore.Remark, oStore.IsDeleted);
                                    #endregion

                                    #region Store Requisition Detail
                                    List<tbl_scsStoreReqositionNote_Detail> oStoreDetails = tbl_scsStoreReqositionNote_Detail.SelectAllByStoreRecositionNote_ID(oStore.StoreRecositionNote_ID);
                                    foreach (tbl_scsStoreReqositionNote_Detail oDetails in oStoreDetails.OrderBy(p => p.Line_No))
                                    {
                                        glb_dtsScsStoreRequisitionNote.dt_scsStoreRequisitionNote_Detail.Adddt_scsStoreRequisitionNote_DetailRow(oDetails.StoreRecositionNote_ID, oDetails.Item_ID, clsGenaralName.getName_Item(oDetails.Item_ID), oDetails.ItemSerialNo, clsGenaralName.getName_ItemSubCategory(oDetails.ItemSubCategory_ID), clsGenaralName.getName_ItemSubCategory2(oDetails.ItemSubCategory2_ID), clsGenaralName.getName_ItemType(oDetails.Item_ID), clsGenaralName.getName_Uom(oDetails.Uom_ID), oDetails.Qty, oDetails.QtySettle, oDetails.Weight, oDetails.WeightSettle, oDetails.UnitPrice, oDetails.WeightPrice, oDetails.Remark);
                                    }
                                    #endregion

                                    #region Fill Formula Fields
                                    sCreateUser = "[ " + clsGenaralName.getName_User(oStore.CreateUser_ID) + " ] [ " + oStore.DateCreate.ToShortDateString() + " ]";
                                    if (oStore.CheckedUser_ID != "default")
                                        sCheckedUser = "[ " + clsGenaralName.getName_User(oStore.CheckedUser_ID) + " ] [ " + oStore.DateChecked.ToShortDateString() + " ]";
                                    if (oStore.IsApproved && oStore.ApprovedUser_ID != "default")
                                        sApprovedUser = "[ " + clsGenaralName.getName_User(oStore.ApprovedUser_ID) + " ] [ " + oStore.DateApproved.ToShortDateString() + " ]";
                                    #endregion

                                    #region Update Print Count
                                    if (!bIsDraft)
                                    {
                                        //if (oStore.PrintCount > 0)
                                        //    sDuplicateCopy = "Duplicate Copy " + oStore.PrintCount;

                                        if (!chkPrintOriginal.Checked)
                                            sDuplicateCopy = (oStore.PrintCount > 0) ? "Duplicate Copy " + oStore.PrintCount : "";

                                        oStore.PrintCount++;
                                        oStore.Update();
                                    }
                                    #endregion

                                    #region Report Export Parameters
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
                                        }
                                    }
                                    glb_dtsScsStoreRequisitionNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, "STORE REQUISITION NOTE [SR]", "", "", clsSecurity.UserNameLoged, "");
                                    #endregion

                                    #region Set Report Path and Datasets
                                    frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                    rpt.print(sGetRptPath, glb_dtsScsStoreRequisitionNote, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_iSRN));
                                    #endregion
                                }
                            }
                            #endregion

                            #region Views
                            else
                            {
                                bool isDuplicate = false;
                                #region Set Formula Fields
                                #region Update Print Count
                                if (!bIsDraft)
                                {
                                    //if (oStore.PrintCount > 0)
                                    //    sDuplicateCopy = "Duplicate Copy " + oStore.PrintCount;

                                    if (!chkPrintOriginal.Checked)
                                        sDuplicateCopy = (oStore.PrintCount > 0) ? "Duplicate Copy " + oStore.PrintCount : "";

                                    oStore.PrintCount++;
                                }
                                #endregion

                                sCreateUser = "[ " + clsGenaralName.getName_User(oStore.CreateUser_ID) + " ] [ " + oStore.DateCreate.ToShortDateString() + " ]";
                                if (oStore.CheckedUser_ID != "default")
                                    sCheckedUser = "[ " + clsGenaralName.getName_User(oStore.CheckedUser_ID) + " ] [ " + oStore.DateChecked.ToShortDateString() + " ]";
                                if (oStore.ApprovedUser_ID != "default")
                                    sApprovedUser = "[ " + clsGenaralName.getName_User(oStore.ApprovedUser_ID) + " ] [ " + oStore.DateApproved.ToShortDateString() + " ]";
                                oStore.Update();
                                #endregion

                                #region Set View and Path
                                Cursor = Cursors.WaitCursor;
                                string s_Path = "", sReportTitle = "STORE REQUISITION NOTE [SR]", sFormula = "";

                                sFormula = "{vw_rpt_scsStoreRequisitionNote.storeRecositionNote_ID} = '" + txtStoreRequisitionNoteID.Text.Trim() + "'";

                                ReportDocument RD = new ReportDocument();
                                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");

                                string sGetRptPath = clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_iSRN));
                                if (sGetRptPath != null && sGetRptPath.Length > 0)
                                    s_Path += sGetRptPath;
                                else
                                    s_Path += "\\reports\\rpt_scsStoreRequisitionNote.rpt";
                                #endregion

                                #region Report Display
                                frm_ReportViewer viewer = new frm_ReportViewer();
                                RD.Load(s_Path);
                             //   clsSecurity.LogonServer(ref RD);
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
                                RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                                RD.DataDefinition.FormulaFields["DupoicateCopy"].Text = clsCommon.fncsetstring(sDuplicateCopy);


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
                            #endregion
                        }
                    }
                }
                else
                    MessageBox.Show("Please Select the Store Requisition Note to Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        #region MyRegion
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

        #region Check Validity
        private bool CheckValidity_EmptyField()
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
            // string strMessage = "", sItemCode = "";
            // decimal dWeightActual = 0;
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
        private bool ValidateForDependancies(string sSRNId)
        {
            bool bValue = true;
            foreach (tbl_scsStoreGoodIssueNote oGIN in tbl_scsStoreGoodIssueNote.SelectAll().Where(p => !p.IsDeleted && p.StoreGoodIssueNote_ID != "default" && p.StoreRequisitionNote_ID == sSRNId))
            {
                bValue = false;
                MessageBox.Show("Record Is Locked! \n\n[" + oGIN.StoreGoodIssueNote_ID + "] Good Issue Note is already created for this Store Requisition Note", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                break;
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

        #region Search Methods
        private void Search_JobID()
        {
            if (CheckValidity_EmptyField())
                clsSearch.Search_MasterProductionJob(ref txtjobID);
        }

        private void Search_ItemID(object sender, KeyEventArgs e)
        {
            if (!clsConfig.bJobIdRequiredGIN)
                clearItamAndJob();

            if (CheckValidity_EmptyField() && CheckJobSelectValidity())
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
                //else if (e.KeyCode == Keys.F5)
                //{
                //    frm_sasMultipleItemSelect frm = new frm_sasMultipleItemSelect();
                //    string sItemPriceCategory = ((ComboBoxItem)cmbItemPrice.SelectedItem).Value;
                //    frm.glb_sItemPriceCategory = sItemPriceCategory;
                //    frm.glb_bStockValidate_ManuallyDisable = true; //disable stock validity function
                //    frm.ShowDialog();


                //    if (frm.lstclsTmpMultipleSelectedItems.Count > 0)
                //    {
                //        foreach (clsTmpMultipleSelectedItems oItem in frm.lstclsTmpMultipleSelectedItems)
                //        {
                //            dgvDetail.Rows.Add();
                //            int iRow = dgvDetail.Rows.Count - 1;
                //            ValidateEmptyForeignKey();
                //            string sToLocation = clsHelpMethods_Local.getToLocationName(txtDepartmentID, txtSectionID, txtStoreID);
                //            string sNoteID = "N/A";

                //            clsHelpMethods_Local.Fill_StockDatagrid(dgvDetail, iRow, dgvDetail.Rows.Count, oItem.sItemID, oItem.sUOMID, txtjobID.Text.Trim(), getSelectAriaID(), txtDepartmentID.Tag.ToString(), 
                //                txtSectionID.Tag.ToString(), txtStoreID.Tag.ToString(), "default", "default", "default", sToLocation, sNoteID, oItem.dQty, oItem.dWeight, oItem.sItemSubCategoryID, 
                //                oItem.sItemSubCategoryID2, oItem.sItemSerialNo, oItem.sItemSerialNo2, "N", oItem.dUnitPrice, oItem.dTotalAmount, "", 0);
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
        }

        private void Search_StoreGoodReceiveNote()
        {
            clsSearch.Search_TransactionStoreReqositionNote(ref txtStoreRequisitionNoteID, chkShowSettle.Checked, true, "");
            if (txtStoreRequisitionNoteID.Text.Trim().Length > 0)
            {
                FillDetails(txtStoreRequisitionNoteID.Text.Trim());
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
        private void Search_StoreTo()
        {
            clsSearch.Search_MasterStore(ref txtLocationID, true);
            txtStoreID.Focus();
        }
        #endregion

        #region Set Enable/Desable Items
        private void setEnableItems(bool Val)
        {
            clearItamAndJob();

            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemID, Val);
            clsCommon.SetEnableDisable_NormalLabel(lblItem, Val);
            btnAddItem.Enabled = Val;
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtjobID, Val);
            clsCommon.SetEnableDisable_NormalLabel(lblJob, Val);
            btnAddJob.Enabled = Val;

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

        #region Send E-Mail
        public void sendEmail()
        {
            //  frmEmail oEmail = new frmEmail();
            //  oEmail.Show();
        }
        #endregion

        #region Cancel Order
        private void cancelOrder()
        {
            try
            {
                if (txtStoreRequisitionNoteID.Text.Trim().Length > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_scsStoreReqositionNote detail = tbl_scsStoreReqositionNote.Select(txtStoreRequisitionNoteID.Text.Trim());
                        if (detail != null)
                        {
                            if (!detail.IsLocked)
                            {
                                if (!detail.IsDeleted)
                                {
                                    if (!detail.IsSeattled)
                                    {
                                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " SR : " + detail.StoreRecositionNote_ID), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                        if (msgResult == DialogResult.Yes)
                                        {
                                            detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                            detail.DateModified = clsSecurity.getServerDateTime();
                                            detail.IsDeleted = true;
                                            detail.Update();
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            ClearFields();
                                        }
                                    }
                                    else
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.GINdoneForSRN), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        private void frm_scsStoreRequisitionNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            Attachments.Close();
        }

        #region User Checked Approve Details

        private void frm_scsStoreRequisitionNote_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_scsStoreRequisitionNote_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpSRNDate.Value.Date))
                {
                    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtStoreRequisitionNoteID.Text != null && txtStoreRequisitionNoteID.TextLength > 0 && txtStoreRequisitionNoteID.Text != "<Auto Generate>")
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

                                        tbl_scsStoreReqositionNote objDO = tbl_scsStoreReqositionNote.Select(txtStoreRequisitionNoteID.Text.Trim());
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
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpSRNDate.Value.Date))
                {
                    if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtStoreRequisitionNoteID.Text != null && txtStoreRequisitionNoteID.TextLength > 0 && txtStoreRequisitionNoteID.Text != "<Auto Generate>")
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

                                        tbl_scsStoreReqositionNote objDO = tbl_scsStoreReqositionNote.Select(txtStoreRequisitionNoteID.Text.Trim());
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
        private void frm_scsStoreRequisitionNote_SF_History_Click(object sender, EventArgs e)
        {
            if (txtStoreRequisitionNoteID.Text != "" || txtStoreRequisitionNoteID.Text != "<Auto Generate>")
            {
                tbl_scsStoreReqositionNote detail = tbl_scsStoreReqositionNote.Select(txtStoreRequisitionNoteID.Text);
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

        private void btnDCP_Click(object sender, EventArgs e)
        {
            //isTemp = true;
            IsUpdate = false;
            lblCancelled.Visible = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtStoreRequisitionNoteID, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblGoodreceivedNoteID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblGoodreceivedNoteID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, true);

            txtOrderRefNo.Tag = null;
            txtOrderRefNo.Clear();
            bHasApproved = false;
            bHasChecked = false;
            //chkSettings.Checked = true;

            //Reset Order Ref No
            txtOrderRefNo.Tag = null;
            txtOrderRefNo.Clear();
            //glbOrderRefNo = "";

            //Reset Primary Key
            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtStoreRequisitionNoteID.Text = "<Auto Generate>";
            else
                txtStoreRequisitionNoteID.Clear();
            if (txtStoreRequisitionNoteID.Enabled)
            {
                txtStoreRequisitionNoteID.SelectAll();
                txtStoreRequisitionNoteID.Focus();
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
