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

namespace Digiteq
{
    public partial class frm_scsDepartmentRequisitionNote : SEACC_Form
    {
        
        //to keep glob ref no        
        public string glbSRNo = "";

        //for security handle
        //public bool bNoAccess;
        //public bool bHasChecked;
        //public bool bHasApproved;
        ///    DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        //    DateTime glbCheckedDate = clsSecurity.getServerDateTime();


        #region Form Load
        public frm_scsDepartmentRequisitionNote(FormName _enmForm)
        {
            //sFormConfigCode = clsAutocode.getFormConfigCode(FormName.scsSRNDeparmentStock);
            //iFormID = clsSecurity.getFormID(FormName.scsSRNDeparmentStock);
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }
        private void frmCustomerOrder_Load(object sender, EventArgs e)
        {
            //add data to the datagrid and format  
            ///clsFormatter.setFormatForm(this, clsHelpMethods_Local.getFormName(iFormID), 7, iFormID);
            ClearFields();
            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);
            CusDataGridViewFormat();

            //if the GIN fired by SR   
            if (glbSRNo.Length > 0)
                FillDetails(glbSRNo);
        }
        #endregion

        #region Btn New
        private void frm_scsDepartmentRequisitionNote_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void frm_scsDepartmentRequisitionNote_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDepartmentRequisitionNoteID.Text.Trim().Length > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpSRNDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            //delete one record
                            Cursor = Cursors.WaitCursor;
                            tbl_scsDepartmentReqositionNote detail = tbl_scsDepartmentReqositionNote.Select(txtDepartmentRequisitionNoteID.Text.Trim());
                            if (detail != null)
                            {
                                if (!detail.IsLocked)
                                {
                                    if (!detail.IsDeleted)
                                    {
                                        if (!detail.IsSeattled)
                                        {
                                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " SR : " + detail.DepartmentReqositionNote_ID), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
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
        private void frm_scsDepartmentRequisitionNote_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity_EmptyField())
            {
                if (clsValidate.CheckGridCountValidity(dgvDetail.RowCount, iFormID))
                {
                    if (CheckNumberValidity())
                    {
                        if (CheckStockValidity())
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
                                            MessageBox.Show("This Record Cannot Be Update....", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            #endregion
                                        }
                                        else  //insert records
                                        {
                                            #region Insert
                                            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                                txtDepartmentRequisitionNoteID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                            //create order ref number
                                            if (txtDocReffNo.Tag == null || txtDocReffNo.Tag.ToString().Trim() == "default")
                                            {
                                                txtDocReffNo.Tag = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.zIssuedRefNo));
                                                tbl_zIssuedRefNo orf = new tbl_zIssuedRefNo(txtDocReffNo.Tag.ToString().Trim(), txtDocReffNo.Text.Trim());
                                                orf.Insert();
                                            }

                                            if (clsValidate.CheckValidity_TransactionCodeLength(txtDepartmentRequisitionNoteID.Text)) //if (txtDepartmentRequisitionNoteID.Text.Trim().Length > 0)
                                            {
                                                #region DRN Header
                                                tbl_scsDepartmentReqositionNote detail = new tbl_scsDepartmentReqositionNote(txtDepartmentRequisitionNoteID.Text.Trim(), dtpSRNDate.Value, txtRemark.Text.Trim(),
                                                    txtjobID.Tag.ToString(), txtLocationID.Tag.ToString(), getSelectAriaID(), getToDepartment(), getToSection(), getToStore(), txtDocReffNo.Tag.ToString(), "default",
                                                    clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default",
                                                    clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                    clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                    bHasChecked, bHasApproved, false, false, false, 0, false, false);
                                                detail.Insert();
                                                #endregion

                                                //GRN Detail                                
                                                #region SRN Detail
                                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                                {
                                                    try
                                                    {
                                                        string sItemCode = "", sUom = "default", sJobCode = "", sSelectArea_ID = "", sDepartment_ID = "",
                                                        sSection_ID = "", sStore_ID = "", //sDepartmentNote_ID = "", sSectionNote_ID = "", sStoreNote_ID = "",
                                                        sItemSubCategoryID1 = "", sItemSubCategoryID2 = "", sItemSerialNo1 = "", sItemSerialNo2 = "";
                                                        decimal dWeight = 0, dQuantitiy = 0;
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
                                                        // sSectionNote_ID = "default";
                                                        // sStoreNote_ID = "default";
                                                        sItemSubCategoryID1 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                                                        sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                                        sItemSerialNo1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                                                        sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");

                                                        if (sItemCode.Length > 0)
                                                        {
                                                            tbl_scsDepartmentReqositionNote_Detail items = new tbl_scsDepartmentReqositionNote_Detail(iLineNo, txtDepartmentRequisitionNoteID.Text.Trim(),
                                                            sItemCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, sJobCode, txtLocationID.Tag.ToString(), sSelectArea_ID,
                                                            sDepartment_ID, sSection_ID, sStore_ID, sUom, dQuantitiy, 0, dWeight, 0, 0, 0, "", false);

                                                            items.Insert();
                                                        }

                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                                        SEACCException.Show(ex);
                                                    }
                                                }
                                                #endregion

                                                Attachments.Insert(txtDepartmentRequisitionNoteID.Text.ToString());

                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            else
                                            {
                                                MessageBox.Show("Department Requisition Note " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            #endregion
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
                                        //tbl_scsDepartmentReqositionNote oldRecord = tbl_scsDepartmentReqositionNote.Select(txtDepartmentRequisitionNoteID.Text.Trim());
                                        //if (oldRecord != null)
                                        //{
                                        //    ClearFields();
                                        //FillDetails(oldRecord.DepartmentReqositionNote_ID);
                                        FillDetails(txtDepartmentRequisitionNoteID.Text.Trim());
                                        //}
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
        private void frm_scsDepartmentRequisitionNote_SF_printButton_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_scsDepartmentRequisitionNote_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region Btn Checked, Approved and User details
        private void frm_scsDepartmentRequisitionNote_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_scsDepartmentRequisitionNote_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        private void frm_scsDepartmentRequisitionNote_SF_History_Click(object sender, EventArgs e)
        {
            UserDetails();
        }
        #endregion

        #region Btn Job
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
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
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
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn IGIN
        private void btnIGIN_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDepartmentRequisitionNoteID.Text != "default" && txtDepartmentRequisitionNoteID.Text.Trim().Length > 0 && txtDepartmentRequisitionNoteID.Text != "<Auto Generate>")
                {
                    tbl_scsDepartmentReqositionNote detail = tbl_scsDepartmentReqositionNote.Select(txtDepartmentRequisitionNoteID.Text.ToString());
                    if (detail != null)
                    {
                        if (!detail.IsSeattled)
                        {
                            if (detail.ToSelectArea_ID == clsAutocode.getSelectAreaCode(SelectArea.Department))
                            {
                                frm_scsStoreGoodIssueNote frm = new frm_scsStoreGoodIssueNote(FormName.sasGINTradingStock);
                                frm.glbSRNo = detail.DepartmentReqositionNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, (this.Parent as Form).MdiParent);
                            }
                        }
                        else
                            MessageBox.Show("Already Issued \n\nThis Department Requisition Quantity has already being issued by Good Issue Note(s)", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Temp
        private void frm_scsDepartmentRequisitionNote_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtDepartmentRequisitionNoteID.TextLength > 0 && txtDepartmentRequisitionNoteID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDepartmentRequisitionNoteID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtLocationID, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtDocReffNo, true);
                setEnableItems(true);
                clsCommon.SetEnableDisable_NormalLabel(lblGoodreceivedNoteID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblLocationID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblDocReffNo, true);
                btnAddItem.Enabled = false;

                txtDepartmentRequisitionNoteID.Tag = null;
                dtpSRNDate.Value = clsSecurity.getServerDateTime();

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Order Ref No
                txtDocReffNo.Tag = null;
                txtDocReffNo.Clear();

                //Reset Primary Key
                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtDepartmentRequisitionNoteID.Text = "<Auto Generate>";
                else
                    txtDepartmentRequisitionNoteID.Clear();
                if (txtDepartmentRequisitionNoteID.Enabled)
                {
                    txtDepartmentRequisitionNoteID.SelectAll();
                    txtDepartmentRequisitionNoteID.Focus();
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

            //Change Grid Headers
            dgvDetail.Columns["ItemSubCategoryID1"].HeaderText = clsConfig.sItemSubCategory;
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            lblCancelled.Visible = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDepartmentRequisitionNoteID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtLocationID, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtDocReffNo, true);
            setEnableItems(false);
            clsCommon.SetEnableDisable_NormalLabel(lblGoodreceivedNoteID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblLocationID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblDocReffNo, true);
            btnAddItem.Enabled = false;

            txtLocationID.Tag = null;
            txtDepartmentID.Tag = null;
            txtSectionID.Tag = null;
            txtStoreID.Tag = null;
            txtjobID.Tag = null;
            txtItemID.Tag = null;
            txtItemSubCategory.Tag = null;
            txtItemSerialNo.Tag = null;
            txtItemSerialNo.Clear();
            txtItemSubCategory.Clear();
            txtDocReffNo.Tag = null;

            txtDepartmentRequisitionNoteID.Clear();
            txtDepartmentRequisitionNoteID.Tag = null;

            txtRemark.Clear();
            txtLocationID.Clear();
            txtDepartmentID.Clear();
            txtSectionID.Clear();
            txtStoreID.Clear();
            txtjobID.Clear();
            txtItemID.Clear();
            txtDocReffNo.Clear();

            bHasApproved = false;
            bHasChecked = false;
            userDetailsColorChanges();

            dgvDetail.Rows.Clear();
            dtpSRNDate.Value = clsSecurity.getServerDateTime();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtDepartmentRequisitionNoteID.Text = "<Auto Generate>";
            else
                txtDepartmentRequisitionNoteID.Clear();
            if (txtDepartmentRequisitionNoteID.Enabled)
            {
                txtDepartmentRequisitionNoteID.SelectAll();
                txtDepartmentRequisitionNoteID.Focus();
            }

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
                if (sID.Length > 0)
                {
                    tbl_scsDepartmentReqositionNote detail = tbl_scsDepartmentReqositionNote.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDepartmentRequisitionNoteID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtLocationID, false);
                        clsCommon.SetEnableDisable_NormalTextbox(txtDocReffNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblGoodreceivedNoteID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblLocationID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblDocReffNo, false);

                        //asign values                    
                        txtLocationID.Tag = detail.FromDepartment_ID;
                        txtDepartmentID.Tag = detail.ToDepartment_ID;
                        txtSectionID.Tag = detail.ToSection_ID;
                        txtStoreID.Tag = detail.ToStore_ID;
                        txtjobID.Tag = detail.Job_ID;

                        //fill order detials
                        tbl_zIssuedRefNo order = tbl_zIssuedRefNo.Select(detail.IssuedRefNo_ID);
                        if (order != null)
                        {
                            txtDocReffNo.Tag = order.IssuedRefNo_ID;
                            txtDocReffNo.Text = clsCommon.GetForeignKeyValue(order.IssuedRefNo);
                        }

                        txtDepartmentRequisitionNoteID.Text = detail.DepartmentReqositionNote_ID;
                        txtRemark.Text = detail.Remark;
                        dtpSRNDate.Value = detail.DepartmentReqositionNoteDate;
                        txtLocationID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Department(detail.FromDepartment_ID));
                        txtDepartmentID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Department(detail.ToDepartment_ID));
                        txtSectionID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Section(detail.ToSection_ID));
                        txtStoreID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(detail.ToStore_ID));
                        txtjobID.Text = clsCommon.GetForeignKeyValue(detail.Job_ID);

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
                        RefreshGrid(detail.DepartmentReqositionNote_ID);

                        //Set Flow
                        clsHelpMethods_Local.SetProcessFlow_Stock_Internal(detail.IssuedRefNo_ID, txtFlowSR, txtFlowGIN, txtFlowGRN);

                        Attachments.FillAttachments(sID);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
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

                List<tbl_scsDepartmentReqositionNote_Detail> details = tbl_scsDepartmentReqositionNote_Detail.SelectAllByDepartmentReqositionNote_ID(sSRNID).OrderBy(p => p.Line_No).ToList();
                foreach (tbl_scsDepartmentReqositionNote_Detail detail in details)
                {

                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    //clsHelpMethods.Fill_StockDatagrid(dgvDetail, iRow, detail.Item_ID, detail.Uom_ID, detail.Job_ID, detail.ToSelectArea_ID, detail.ToDepartment_ID, detail.ToSection_ID,
                    //    detail.ToStore_ID, "default", "default", "default", sToLocation, "default", detail.Qty, detail.Weight, detail.ItemSubCategory_ID,
                    //    detail.ItemSubCategory2_ID,detail.ItemSerialNo,detail.ItemSerialNo2, "O");

                    clsHelpMethods_Local.Fill_StockDatagrid(dgvDetail, iRow, detail.Line_No, detail.Item_ID, detail.Uom_ID, detail.Job_ID, detail.ToSelectArea_ID, detail.ToDepartment_ID, detail.ToSection_ID,
                        detail.ToStore_ID, "default", "default", "default", "default", "default", detail.Qty, detail.Weight, detail.ItemSubCategory_ID,
                        detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, "O", 0, 0, detail.Remark, 0);

                    if (detail.IsLocked)
                        dgvDetail.Rows[iRow].DefaultCellStyle.ForeColor = clsCommon.ColourForLockedRecord;
                }
                //dgvDetail.Rows.Add();

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
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
                //    List<tbl_pmsPrePlan_SectionPath_InputItem> inputs = tbl_pmsPrePlan_SectionPath_InputItem.SelectAllByPrePlan_ID(PrePlan.PrePlan_ID).OrderBy(p => p.Line_No).ToList();
                //    foreach (tbl_pmsPrePlan_SectionPath_InputItem input in inputs)
                //    {
                //        dgvDetail.Rows.Add();
                //        iRow = dgvDetail.Rows.Count - 1;
                //        tbl_genItemMaster item = tbl_genItemMaster.Select(input.Item_ID);
                //        if (item != null)
                //        {
                //            clsHelpMethods_Local.Fill_StockDatagrid(dgvDetail, iRow, input.Line_No, item.Item_ID, item.Uom_ID, sJob_ID, getSelectAriaID(), getToDepartment(),
                //                 getToSection(), getToStore(), "default", "default", "default", getSelectToLocationID(), "default", input.Qty,
                //                 input.Weight, "default", "default", "0", "0", "N", 0, 0, "",0);
                //        }
                //    }
                //}
                //tbl_pmsProductionJobRegister detail = tbl_pmsProductionJobRegister.Select(sJob_ID);
                ////if (!clsCommon.IsLastRawEmpty(dgvDetail, dgvDetail.Rows.GetLastRow(DataGridViewElementStates.Displayed)))
                //dgvDetail.Rows.Add();
                //iRow = dgvDetail.Rows.Count - 1;
                //clsHelpMethods.Fill_StockDatagrid(dgvDetail, iRow, detail.Item_ID, detail.Uom_ID, detail.ProductionJob_ID, getSelectAriaID(), getToDepartment(), getToSection(), getToStore(), "default", "default", "default", getSelectToLocationID(), "default", detail.Qty.ToString(), detail.Weight, detail.Weight);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
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
                    clsHelpMethods_Local.Fill_StockDatagrid(dgvDetail, iRow, dgvDetail.Rows.Count, detail.Item_ID, detail.Uom_ID, sJobID, getSelectAriaID(), getToDepartment(),
                        getToSection(), getToStore(), "default", "default", "default", getSelectToLocationID(), "default", 0, 0,
                        txtItemSubCategory.Tag.ToString(), txtItemSubCategory.Text.Trim(), txtItemSerialNo.Tag.ToString(), txtItemSerialNo.Text.Trim(), "N", 0, 0, "",0);
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        #endregion

        #region Events Datagried
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

        private void txtDepartmentRequisitionNoteID_DoubleClick(object sender, EventArgs e)
        {
            Search_DepartmentRequisitionNote();
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
            //Search_StoreTo();
            Search_DepartmentTo();
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
            if (e.KeyCode == Keys.F1)
            {
                if (!clsConfig.bJobIdRequiredGIN)
                    clearItamAndJob();
                Search_ItemID();
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
        private void txtLocationID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                //Search_StoreTo();
                Search_DepartmentTo();
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
            if (clsValidate.ValidateTextBox_EmptyValue(txtLocationID, "Issuer"))
            {
                //if (clsValidate.ValidateTextBox_EmptyValue(txtDocReffNo, "Tracking No"))
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
            //  string strMessage = "", sItemCode = "";
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
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void Search_ItemID()
        {
            if (CheckValidity_EmptyField())// && CheckJobSelectValidity())
            {
                clsHelpMethods_Local.SearchItemAdvance(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo);
                if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                    btnAddItem_Click(btnAddItem, new EventArgs());
            }
        }

        private void Search_StoreGoodReceiveNote()
        {
            try
            {
                Form frmhelpsearch = new frmSearchTransaction();
                clsSearch.passValue_DepartmentStoreReqositionNoteAll();
                frmhelpsearch.ShowDialog();

                if (frmSearchTransaction.s_SearchID.Length > 0)
                {
                    txtDepartmentRequisitionNoteID.Text = frmSearchTransaction.s_SearchID;
                    FillDetails(frmSearchTransaction.s_SearchID);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        private void Search_DepartmentRequisitionNote()
        {
            try
            {
                clsSearch.Search_TransactionDepartmentStoreReqositionNote_Direct(ref txtDepartmentRequisitionNoteID, chkShowSettle.Checked);
                if (txtDepartmentRequisitionNoteID.Tag != null && txtDepartmentRequisitionNoteID.Tag.ToString().Trim() != "default")
                {
                    txtDepartmentRequisitionNoteID.Text = txtDepartmentRequisitionNoteID.Tag.ToString().Trim();
                    FillDetails(txtDepartmentRequisitionNoteID.Tag.ToString().Trim());
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
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
        private void Search_DepartmentTo()
        {
            //clsSearch.Search_MasterStore(ref txtLocationID);
            clsSearch.Search_MasterDepartment(ref txtLocationID);
        }

        #endregion

        #region Print Method
        private void Print(bool bIsDraft)
        {
            try
            {
                string sDuplicate = "";
                if (txtDepartmentRequisitionNoteID.Text.Trim().Length > 0 && txtDepartmentRequisitionNoteID.Text.Trim() != "<Auto Generate>")
                {
                    //update receipt
                    string sCreateUser = "", sCheckedUser = "", sApprovedUser = "";
                    tbl_scsDepartmentReqositionNote sr = tbl_scsDepartmentReqositionNote.Select(txtDepartmentRequisitionNoteID.Text.Trim());
                    if (sr != null)
                    {
                        if (!bIsDraft)
                        {
                            if (sr.PrintCount > 0)
                                sDuplicate = "Duplicate Copy " + sr.PrintCount;

                            sr.PrintCount++;
                            sr.Update();
                        }
                        //order.IsLocked = true;
                        sCreateUser = "[ " + clsGenaralName.getName_User(sr.CreateUser_ID) + " ] [ " + sr.DateCreate.ToShortDateString() + " ]";
                        if (sr.CheckedUser_ID != "default")
                            sCheckedUser = "[ " + clsGenaralName.getName_User(sr.CheckedUser_ID) + " ] [ " + sr.DateChecked.ToShortDateString() + " ]";
                        if (sr.ApprovedUser_ID != "default")
                            sApprovedUser = "[ " + clsGenaralName.getName_User(sr.ApprovedUser_ID) + " ] [ " + sr.DateApproved.ToShortDateString() + " ]";
                    }

                    Cursor = Cursors.WaitCursor;
                    string s_Path = "", sReportTitle = "DEPARTMENT REQUISITION NOTE [SR]", sFormula = "";

                    sFormula = "{vw_rpt_scsDepartmentRequosition.departmentReqositionNote_ID} = '" + txtDepartmentRequisitionNoteID.Text.Trim() + "'";

                    ReportDocument RD = new ReportDocument();
                    s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                    s_Path += "\\reports\\SCS\\NotePrinting\\rpt_scsDepartmentRequisitionNote.rpt";

                    frm_ReportViewer viewer = new frm_ReportViewer();
                    RD.Load(s_Path);
                  //  clsSecurity.LogonServer(ref RD);
                    RD.Refresh();

                    RD.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsGenaralName.getName_User(clsSecurity.UserIDLoged));
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

                    RD.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring(sDuplicate);
                    RD.DataDefinition.FormulaFields["IsDraft"].Text = bIsDraft ? clsCommon.fncsetstring("DRAFT") : "";
                    RD.DataDefinition.FormulaFields["isDel"].Text = sr.IsDeleted ? clsCommon.fncsetstring("CANCELLED") : "";

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
                }
                else
                    MessageBox.Show("Please Select the Requisition Note To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
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
            if (txtDepartmentID.Tag != null)
                rtn = clsAutocode.getSelectAreaCode(SelectArea.Department);
            else if (txtSectionID.Tag != null)
                rtn = clsAutocode.getSelectAreaCode(SelectArea.Section);
            else if (txtStoreID.Tag != null)
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

        #region User Checked Approve Details
        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpSRNDate.Value.Date))
                {
                    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtDepartmentRequisitionNoteID.Text != null && txtDepartmentRequisitionNoteID.TextLength > 0 && txtDepartmentRequisitionNoteID.Text != "<Auto Generate>")
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

                                        tbl_scsDepartmentReqositionNote detail = tbl_scsDepartmentReqositionNote.Select(txtDepartmentRequisitionNoteID.Text.Trim());
                                        if (detail != null)
                                        {
                                            detail.IsApproved = true;
                                            detail.DateApproved = clsSecurity.getServerDateTime();
                                            detail.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                            detail.Update();
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
                clsValidate.WriteErrorLog("", iFormID,ex);
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
                        if (txtDepartmentRequisitionNoteID.Text != null && txtDepartmentRequisitionNoteID.TextLength > 0 && txtDepartmentRequisitionNoteID.Text != "<Auto Generate>")
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

                                        tbl_scsDepartmentReqositionNote detail = tbl_scsDepartmentReqositionNote.Select(txtDepartmentRequisitionNoteID.Text.Trim());
                                        if (detail != null)
                                        {
                                            detail.IsChecked = true;
                                            detail.DateChecked = clsSecurity.getServerDateTime();
                                            detail.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            detail.Update();
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
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion
        private void UserDetails()
        {
            try
            {
                if (txtDepartmentRequisitionNoteID.Text != "" || txtDepartmentRequisitionNoteID.Text != "<Auto Generate>")
                {
                    tbl_scsDepartmentReqositionNote detail = tbl_scsDepartmentReqositionNote.Select(txtDepartmentRequisitionNoteID.Text.Trim());
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
                clsValidate.WriteErrorLog("", iFormID,ex);
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

        private void btn_Close_Click(object sender, EventArgs e)
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
