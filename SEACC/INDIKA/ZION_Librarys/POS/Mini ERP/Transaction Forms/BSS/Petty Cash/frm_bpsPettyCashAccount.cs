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

namespace Digiteq
{
    public partial class frm_bpsPettyCashAccount : Form
    {

        #region Variables
        //to manage update and insert
        static bool IsUpdate = false;


        //form manage
        string sFormConfigCode;
        public int iFormID;

        //for security handle
        public bool bNoAccess;
        public bool bHasChecked;
        public bool bHasApproved;
        DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        DateTime glbCheckedDate = clsSecurity.getServerDateTime();
        #endregion

        #region From Load
        public frm_bpsPettyCashAccount()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.ReportPettyCashAccount);
            iFormID = clsSecurity.getFormID(FormName.PettyCashAccount);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_bpsPettyCashAccount_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Petty Cash Account Creation", 2, iFormID);
            ClearFields();
        }
        #endregion


        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsMethods_GL.CheckValidity_FinancialYear(dtpPettyCashAccountDate.Value.Date))
            {
                if (CheckValidity())
                {
                    if (CheckNumberValidity())
                    {
                        if (CheckFloatAmountValidity())
                        {
                            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                            {
                                try
                                {
                                    Cursor = Cursors.WaitCursor;
                                    ValidateEmptyForeignKey();
                                    if (IsUpdate)  //update records
                                    {
                                        if (clsSecurity.PermissionToWritePettyCash(txtPettyCashAccountID.Tag.ToString(), clsSecurity.UserIDLoged))
                                        {
                                            if (clsValidate.CheckValidity_TransactionCodeLength(txtPettyCashAccountID.Text))
                                            {
                                                tbl_bpsPettyCashAccount oldRecord =
                                                    tbl_bpsPettyCashAccount.Select(txtPettyCashAccountID.Text.Trim());
                                                if (oldRecord != null)
                                                {
                                                    tbl_bpsPettyCashAccount detail = new tbl_bpsPettyCashAccount(
                                                        txtPettyCashAccountID.Text.Trim(), txtPettyCashAccountName.Text,
                                                        oldRecord.PettyCashAccountDate,
                                                        txtRemark.Text, txtAssignedUserID.Tag.ToString(),
                                                        txtCurrency_ID.Tag.ToString(), oldRecord.ExpireDate,
                                                        oldRecord.CreateUser_ID, clsSecurity.UserIDLoged,
                                                        oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID,
                                                        oldRecord.DateCreate, clsSecurity.getServerDateTime(),
                                                        glbCheckedDate, glbApprovedDate,
                                                        bHasChecked, bHasApproved, oldRecord.IsFinished,
                                                        oldRecord.IsDeleted, oldRecord.IsLocked, oldRecord.IsClose,
                                                        clsValidate.DecimalValidate(txtFloatAmount));

                                                    detail.Update();
                                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone),
                                                        clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                                                        MessageBoxIcon.Information);
                                                }
                                            }
                                        }
                                        else //if no permission to write
                                        {
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToWrite), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else  //insert records
                                    {
                                        if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                            txtPettyCashAccountID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                        if (clsValidate.CheckValidity_TransactionCodeLength(txtPettyCashAccountID.Text))// if (txtPettyCashAccountID.TextLength > 0)
                                        {
                                            //Invoice Header
                                            tbl_bpsPettyCashAccount detail = new tbl_bpsPettyCashAccount(
                                                   txtPettyCashAccountID.Text.ToString(), txtPettyCashAccountName.Text, dtpPettyCashAccountDate.Value, txtRemark.Text, txtAssignedUserID.Tag.ToString(),
                                                   txtCurrency_ID.Tag.ToString(), dtpPettyCashExpireDate.Value, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                                   txtCheckedBy.Tag.ToString(), txtApprovedBy.Tag.ToString(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                   glbCheckedDate, glbApprovedDate, bHasChecked, bHasApproved, false, false, false, false, clsValidate.DecimalValidate(txtFloatAmount));

                                            detail.Insert();
                                            //txtPettyCashAccountID.Tag = txtPettyCashAccountID.Text;
                                            tbl_bpsPettyCashAccount_Permission PermissionDetail = new tbl_bpsPettyCashAccount_Permission(txtPettyCashAccountID.Text.Trim(), txtAssignedUserID.Tag.ToString(), true, true, true, true, true);
                                            PermissionDetail.Insert();
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        //else
                                        //{
                                        //    MessageBox.Show("Petty Cash Account " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        //}
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
                                    tbl_bpsPettyCashAccount oldRecord = tbl_bpsPettyCashAccount.Select(txtPettyCashAccountID.Text.Trim());
                                    if (oldRecord != null)
                                        FillDetails(txtPettyCashAccountID.Text.Trim());
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Btn Delete
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPettyCashAccountID.Text.Trim().Length > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpPettyCashAccountDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            if (clsSecurity.PermissionToDeletePettyCash(txtPettyCashAccountID.Tag.ToString(), clsSecurity.UserIDLoged))
                            {
                                //delete one record
                                DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, ""), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (msgResult == DialogResult.Yes)
                                {
                                    Cursor = Cursors.WaitCursor;
                                    tbl_bpsPettyCashAccount detail = tbl_bpsPettyCashAccount.Select(txtPettyCashAccountID.Text.Trim());
                                    if (detail != null)
                                    {
                                        detail.IsDeleted = true;
                                        detail.DateModified = clsSecurity.getServerDateTime();
                                        detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                        detail.Update();

                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        ClearFields();
                                    }
                                }
                                //else if (msgResult == DialogResult.No)
                                //{
                                //    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyCancel), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //}
                            }

                        }
                        else //if no permission to delete
                        {
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Permission
        private void txtPermission_Click(object sender, EventArgs e)
        {

            string strMessage = "";
            if (txtPettyCashAccountID.Text.Trim().Length > 0 && txtAssignedUserID.Tag != null && txtPettyCashAccountID.Text != "<Auto Generate>")
            {
                frm_bpsPettyCashPermission frm = new frm_bpsPettyCashPermission(false);
                if (frm.bNoAccess)
                {
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    frm.glbPettyCashAccount = txtPettyCashAccountID.Text.Trim();
                    frm.glbPettyCashAccountName = txtPettyCashAccountName.Text.ToString();
                    frm.glbSupperUserID = txtAssignedUserID.Tag.ToString();
                    frm.ShowDialog();
                }


                //if (clsSecurity.PermissionToApprovedPettyCash(txtPettyCashAccountID.Tag.ToString(), clsSecurity.UserIDLoged))
                //    if (true)
                //    {
                //        //if (txtAssignedUserID.Tag.ToString() == clsSecurity.UserIDLoged)
                //        if (true)
                //        {
                //            frm_bpsPettyCashPermission detail = new frm_bpsPettyCashPermission(false);
                //            detail.glbPettyCashAccount = txtPettyCashAccountID.Text.Trim();
                //            detail.glbPettyCashAccountName = txtPettyCashAccountName.Text.ToString();
                //            detail.glbSupperUserID = txtAssignedUserID.Tag.ToString();
                //            detail.ShowDialog();
                //        }
                //        else
                //        {
                //            strMessage += "\n" + " You are not authorised to grant permission to this Account";
                //            MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        }
                //    }
                //    else //if no permission to Approved Petty Cash Account
                //    {
                //        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
            }
            else
            {
                strMessage += "\n" + " Please Select the Petty Cash Account... ";
                MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;

            clsCommon.SetEnableDisable_NormalLabel(lblAccountID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblFloatAmount, true);

            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtPettyCashAccountID, true);
            clsCommon.SetVisible_PermissionTextBox(txtFloatAmount, true);
            clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, true);
            clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, true);
            clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, true);
            clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, true);

            txtPreparedBy.Tag = null;
            txtCheckedBy.Tag = null;
            txtApprovedBy.Tag = null;
            txtCurrency_ID.Tag = null;
            txtAssignedUserID.Tag = null;
            //txtPettyCashAccountID.Tag = null;

            txtRemark.Clear();
            txtApprovedBy.Clear();
            txtCheckedBy.Clear();
            txtPreparedBy.Clear();
            txtPettyCashAccountName.Clear();
            txtAssignedUserID.Clear();
            txtRemark.Clear();
            txtCurrency_ID.Clear();
            txtFloatAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(0);

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtPettyCashAccountID.Text = "<Auto Generate>";
            else
                txtPettyCashAccountID.Clear();
            if (txtPettyCashAccountID.Enabled)
            {
                txtPettyCashAccountID.SelectAll();
                txtPettyCashAccountID.Focus();
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
                    tbl_bpsPettyCashAccount detail = tbl_bpsPettyCashAccount.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPettyCashAccountID, false);
                        //clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtPettyCashAccountName, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblAccountID, false);

                        //asign values
                        txtPettyCashAccountID.Tag = detail.PettyCashAccount_ID;
                        txtCurrency_ID.Tag = detail.Currency_ID;
                        txtAssignedUserID.Tag = detail.AssignedUser_ID;

                        txtPettyCashAccountID.Text = detail.PettyCashAccount_ID;
                        //txtPettyCashAccountName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_PettyCashAccount(detail.PettyCashAccount_ID));
                        txtCurrency_ID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Currency(detail.Currency_ID));
                        txtAssignedUserID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.AssignedUser_ID));
                        txtApprovedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.ApprovedUser_ID));
                        txtCheckedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.CheckedUser_ID));
                        txtPreparedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.CreateUser_ID));
                        txtPettyCashAccountName.Text = detail.PettyCashAccountName;
                        txtRemark.Text = detail.Remark;
                        txtFloatAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.FloatAmount);

                        dtpPettyCashAccountDate.Value = detail.PettyCashAccountDate;
                        dtpPettyCashExpireDate.Value = detail.ExpireDate;


                        txtRemark.Text = detail.Remark;

                        if (detail.IsApproved)
                        {
                            bHasApproved = true;
                            glbApprovedDate = detail.DateApproved;
                            dtpDateApprovedBy.Value = detail.DateApproved;
                            dtpTimeApprovedBy.Value = detail.DateApproved;
                            clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, false);
                            clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, false);
                            txtApprovedBy.Tag = detail.ApprovedUser_ID;
                        }
                        if (detail.IsChecked)
                        {
                            bHasChecked = true;
                            glbCheckedDate = detail.DateChecked;
                            dtpDateCheckedBy.Value = detail.DateChecked;
                            dtpTimeCheckedBy.Value = detail.DateChecked;
                            clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, false);
                            clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, false);
                            txtCheckedBy.Tag = detail.CheckedUser_ID;
                        }

                        dtpDatePreparedBy.Value = detail.DateCreate;
                        dtpTimePreparedBy.Value = detail.DateCreate;

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

        #region Event Double Click

        private void txtPettyCashAccount_ID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_TransactionPettyCashAccount(ref txtPettyCashAccountID);
            if (txtPettyCashAccountID.Text.Trim().Length > 0)
                FillDetails(txtPettyCashAccountID.Text.Trim());
        }
        private void txtAssignedUserID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterUser(ref txtAssignedUserID);
        }

        private void txtCurrency_ID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterCurrency(ref txtCurrency_ID);
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

        #region Event key Down
        private void txtPettyCashAccount_ID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_TransactionPettyCashAccount(ref txtPettyCashAccountID);
            }
        }

        private void txtAssignedUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterUser(ref txtAssignedUserID);
            }
        }

        private void txtCurrency_ID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterCurrency(ref txtCurrency_ID);
            }
        }

        private void txtCheckedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CheckedBy();
            }
        }

        private void txtApprovedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_ApprovedBy();
            }
        }
        #endregion

        #region Event Key Press
        private void txtFloatAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimal(txtFloatAmount.Text, e);
        }
        #endregion

        #region Search Methods
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpPettyCashAccountDate.Value.Date))
                {
                    frmSetApproved login = new frmSetApproved();
                    login.iFormID = iFormID;
                    login.ShowDialog();
                    if (frmSetApproved.bChecked)
                    {
                        bHasApproved = true;
                        glbApprovedDate = clsSecurity.getServerDateTime();
                        dtpDateApprovedBy.Value = clsSecurity.getServerDateTime();
                        dtpTimeApprovedBy.Value = clsSecurity.getServerDateTime();
                        txtApprovedBy.Text = frmSetApproved.sApprovedUserName;
                        txtApprovedBy.Tag = frmSetApproved.sApprovedUserID;
                        clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, false);
                        clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, false);
                    }
                    else if (frmSetApproved.bReset)
                    {
                        txtDateApprovedBy.Visible = true;
                        txtApprovedBy.Text = "";
                        txtApprovedBy.Tag = null;
                        bHasApproved = false;
                        clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, true);
                        clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, true);
                    }
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
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpPettyCashAccountDate.Value.Date))
                {
                    frmSetChecked login = new frmSetChecked();
                    login.iFormID = iFormID;
                    login.ShowDialog();
                    if (frmSetChecked.bChecked)
                    {
                        bHasChecked = true;
                        glbCheckedDate = clsSecurity.getServerDateTime();
                        dtpDateCheckedBy.Value = clsSecurity.getServerDateTime();
                        dtpTimeCheckedBy.Value = clsSecurity.getServerDateTime();
                        txtCheckedBy.Text = frmSetChecked.sCheckedUserName;
                        txtCheckedBy.Tag = frmSetChecked.sCheckedUserID;
                        clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, false);
                        clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, false);
                    }
                    else if (frmSetChecked.bReset)
                    {
                        txtCheckedBy.Text = "";
                        txtCheckedBy.Tag = null;
                        bHasChecked = false;
                        clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, true);
                        clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, true);
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

        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;
            try
            {
                if (txtPettyCashAccountName.Text.Trim().Length == 0)
                {
                    strMessage += "\n" + "Account Name ";
                    bStatus = false;
                }
                if (txtAssignedUserID.Text.Trim().Length == 0)
                {
                    strMessage += "\n" + "Supper User ";
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

        private bool CheckFloatAmountValidity()
        {
            bool bStatus = true;
            decimal dFloatAmt = clsValidate.DecimalValidate(txtFloatAmount);
            if (dFloatAmt <= 0)
            {
                DialogResult diaResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.InvalidAmount, "Float Amount"), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (diaResult == DialogResult.Yes)
                    bStatus = true;
                else
                    bStatus = false;
            }
            return bStatus;
        }

        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            clsCommon.ValidateForeignKey(ref txtCheckedBy);
            clsCommon.ValidateForeignKey(ref txtApprovedBy);
            clsCommon.ValidateForeignKey(ref txtPettyCashAccountID);
            clsCommon.ValidateForeignKey(ref txtCurrency_ID);
            clsCommon.ValidateForeignKey(ref txtAssignedUserID);
        }
        #endregion

        private void x1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
