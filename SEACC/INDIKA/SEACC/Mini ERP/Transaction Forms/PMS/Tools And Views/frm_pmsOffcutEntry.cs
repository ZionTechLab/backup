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
    public partial class frm_pmsOffcutEntry : Form
    {

        
        //to manage update and insert
        static bool IsUpdate = false;
        static bool IsUpdateAddressBook = false;

        //form manage
        string sFormConfigCode;
           public int iFormID;

        //for security handle
        public bool bNoAccess;
        public bool bHasChecked;
        public bool bHasApproved;
        DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        DateTime glbCheckedDate = clsSecurity.getServerDateTime();
    

        #region Form Load
        public frm_pmsOffcutEntry()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.OffcutEntry);
            iFormID = clsSecurity.getFormID(FormName.OffcutEntry);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_pmsOffcutEntry_Load(object sender, EventArgs e)
        {
            ClearFields();

            //format Form
            clsFormatter.setFormatForm(this, "Offcut Entry ", 3, iFormID);
        } 
        #endregion

        
        #region Btn New
        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Btn Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    //delete one record
            //    string strMessage = "";
            //    Cursor = Cursors.WaitCursor;
            //    if (txtOffcutEntryID.TextLength > 0 && txtOffcutEntryID.Tag != null)
            //    {
            //        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, ""), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //        if (msgResult == DialogResult.Yes)
            //        {
            //            tbl_bpsPettyCashAccount_Transaction detail = tbl_bpsPettyCashAccount_Transaction.Select(iline, gblPettyCashID);
            //            if (detail != null)
            //            {
            //                //detail.IsDeleted = true;
            //                detail.Delete();
            //                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                ClearFields();
            //            }
            //        }
            //        //else if (msgResult == DialogResult.No)
            //        //{
            //        //    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyCancel), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        //}
            //    }
            //    else
            //    {
            //        strMessage += "\n" + "Plase select the recode ";
            //        MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    clsValidate.WriteErrorLog("", iFormID,ex);
            //    MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //finally
            //{
            //    Cursor = Cursors.Default;
            //}
        }
        #endregion

        #region Btn AddInputMaterial
        private void btnAddInputMaterial_Click(object sender, EventArgs e)
        {
            string sItemID = "";
            if (txtInputTypeID.Tag != null && txtInputTypeID.Tag.ToString().Trim().Length > 0)
                sItemID = clsHelpMethods_Local.ItemSearchByItemTypeID(txtInputTypeID.Tag.ToString(), iFormID, true);

            FillDetailsInputProduct(sItemID);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtOffcutEntryID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblBankID, true);

            txtDamage.Clear();
            txtInputMaterialID.Clear();
            txtInputTypeID.Clear();
            txtLineMachine.Clear();
            txtOffcutEntryID.Clear();
            txtQuntity.Clear();
            txtSectionID.Clear();
            txtWastage.Clear();

            txtInputMaterialID.Tag = null;
            txtInputTypeID.Tag = null;
            txtLineMachine.Tag = null;
            txtOffcutEntryID.Tag = null;
            txtSectionID.Tag = null;

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtOffcutEntryID.Text = "<Auto Generate>";
            else
                txtOffcutEntryID.Clear();
            if (txtOffcutEntryID.Enabled)
            {
                txtOffcutEntryID.SelectAll();
                txtOffcutEntryID.Focus();
            }
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
                        txtInputTypeID.Tag = detail.ItemType_ID;
                        txtInputTypeID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemType(detail.ItemType_ID));
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            //try
            //{
            //    if (sID.Length > 0)
            //    {
            //        tbl_sasAccountReceipt detail = tbl_sasAccountReceipt.Select(sID);
            //        if (detail != null)
            //        {
            //            //set the update flag and Locked
            //            IsUpdate = true;
            //            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtOffcutEntryID, false);
            //            clsCommon.SetEnableDisable_NormalLabel(lblBankID, false);

            //            //asign values
       
            //            txtApprovedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.ApprovedUser_ID));
            //            txtCheckedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.CheckedUser_ID));
            //            txtPreparedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.CreateUser_ID));

            //            if (detail.IsApproved)
            //            {
            //                bHasApproved = true;
            //                glbApprovedDate = detail.DateApproved;
            //                dtpDateApprovedBy.Value = detail.DateApproved;
            //                dtpTimeApprovedBy.Value = detail.DateApproved;
            //                clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, false);
            //                clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, false);
            //                txtApprovedBy.Tag = detail.ApprovedUser_ID;
            //            }
            //            if (detail.IsChecked)
            //            {
            //                bHasChecked = true;
            //                glbCheckedDate = detail.DateChecked;
            //                dtpDateCheckedBy.Value = detail.DateChecked;
            //                dtpTimeCheckedBy.Value = detail.DateChecked;
            //                clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, false);
            //                clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, false);
            //                txtCheckedBy.Tag = detail.CheckedUser_ID;
            //            }

            //            dtpDatePreparedBy.Value = detail.DateCreate;
            //            dtpTimePreparedBy.Value = detail.DateCreate;

            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    clsValidate.WriteErrorLog("", iFormID,ex);
            //    MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        #endregion



        #region Double Click
        private void txtSectionID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterSection(ref txtSectionID);
            if (txtSectionID.Tag != null)
            {
                txtLineMachine.Clear();
                txtLineMachine.Tag = null;
            }
        }
        private void txtLineMachine_DoubleClick(object sender, EventArgs e)
        {
            if (txtSectionID.Tag != null && txtSectionID.Tag.ToString().Trim().Length > 0)
                clsSearch.Search_MasterMachineSectionID(ref txtLineMachine, txtSectionID.Tag.ToString());
            else
            {
                clsSearch.Search_MasterMachine(ref txtLineMachine);
                if (txtLineMachine.Tag != null)
                {
                    tbl_genMachineMaster detail = tbl_genMachineMaster.Select(txtLineMachine.Tag.ToString());
                    if (detail != null)
                    txtSectionID.Text = clsGenaralName.getName_Section(detail.Section_ID);
                }
            }
        } 
        private void txtInputTypeID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterItemType(ref txtInputTypeID);
        }
        private void txtInputMaterialID_DoubleClick(object sender, EventArgs e)
        {
            if (txtInputTypeID.Tag != null && txtInputTypeID.Tag.ToString().Trim().Length > 0)
            {
                //clsSearch.Search_MasterItemByTypeID(ref txtInputMaterialID, txtInputTypeID.Tag.ToString());
                clsSearch.Search_ItemMaster(ref txtInputMaterialID, null, txtInputTypeID.Tag.ToString(), null, false);
            }
            else
            {
                clsSearch.Search_ItemMaster(ref txtInputMaterialID, null, null, null, false);
            }
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
        private void txtSectionID_KeyDown(object sender, KeyEventArgs e)
        {
            clsSearch.Search_MasterSection(ref txtSectionID);
            if (txtSectionID.Tag != null)
            {
                txtLineMachine.Clear();
                txtLineMachine.Tag = null;
            }
        }
        private void txtLineMachine_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSectionID.Tag != null && txtSectionID.Tag.ToString().Trim().Length > 0)
                clsSearch.Search_MasterMachineSectionID(ref txtLineMachine, txtSectionID.Tag.ToString());
            else
            {
                clsSearch.Search_MasterMachine(ref txtLineMachine);
                if (txtLineMachine.Tag != null)
                {
                    tbl_genMachineMaster detail = tbl_genMachineMaster.Select(txtLineMachine.Tag.ToString());
                    if (detail != null)
                        txtSectionID.Text = clsGenaralName.getName_Section(detail.Section_ID);
                }
            }
        }
        private void txtInputTypeID_KeyDown(object sender, KeyEventArgs e)
        {
            clsSearch.Search_MasterItemType(ref txtInputTypeID);
        }
        private void txtInputMaterialID_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtInputTypeID.Tag != null && txtInputTypeID.Tag.ToString().Trim().Length > 0)
            {
                //clsSearch.Search_MasterItemByTypeID(ref txtInputMaterialID, txtInputTypeID.Tag.ToString());
                clsSearch.Search_ItemMaster(ref txtInputMaterialID, null, txtInputTypeID.Tag.ToString(), null, false);
            }
            else
            {
                clsSearch.Search_ItemMaster(ref txtInputMaterialID, null, null, null, false);
            }
        }
        private void txtCheckedBy_KeyDown(object sender, KeyEventArgs e)
        {
            Search_CheckedBy();
        }
        private void txtApprovedBy_KeyDown(object sender, KeyEventArgs e)
        {
            Search_ApprovedBy();
        }
        #endregion

        #region Event Key Press
        private void txtWastage_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimal(txtWastage.Text, e);
        }
        private void txtDamage_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimal(txtDamage.Text, e);
        }
        private void txtQuntity_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimal(txtQuntity.Text, e);
        }
        #endregion


        #region Search Methods
        private void Search_ApprovedBy()
        {
            try
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
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Search_CheckedBy()
        {
            try
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
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


    }
}
