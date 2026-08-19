using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;

namespace Digiteq
{
    public partial class frm_bpsPettyCashIOU : Form
    {

        #region Variable
        //to manage update and insert
        static bool IsUpdate = false;

        //to keep form detail       
           public int iFormID;
        string sFormConfigCode;

        int iRow = 0;
        int iline = -1;

        public bool bNoAccess;
        public string gblPettyCash;
        public string gblPettyCashName;
        public string gblIOUID;
        public decimal gblIoubalnce;


        //for security handle
        public bool bHasChecked;
        public bool bHasApproved;
        DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        DateTime glbCheckedDate = clsSecurity.getServerDateTime();
        bool bUpdateIOUName = false;

        List<tbl_bpsPettyCashAccount_IOU_Detail> list = new List<tbl_bpsPettyCashAccount_IOU_Detail>();
        #endregion

        #region Form Load
        public frm_bpsPettyCashIOU()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.UpdatePettyCashAccounts);
            iFormID = clsSecurity.getFormID(FormName.UpdatePettyCashAccounts);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_bpsPettyCash_IncomeAndExpenditure_Load(object sender, EventArgs e)
        {
            //clsFormatter.setFormatForm(this, "Petty Cash IOU Entries", 2);
            CusDataGridViewFormat();
            RefreshGrid();
        } 
        #endregion


        #region Btn Delete
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (clsSecurity.PermissionToDeletePettyCash(gblPettyCash, clsSecurity.UserIDLoged))
                {

                    //delete one record
                    string strMessage = "";
                    Cursor = Cursors.WaitCursor;
                    if (iline >= 0)
                    {
                        //tbl_bpsPettyCashAccount_IOU detail = tbl_bpsPettyCashAccount_IOU.Select(int.Parse(txtRowNo.Text), gblPettyCash);
                        //if (detail != null)
                        //{
                        //    DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, ""), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        //    if (msgResult == DialogResult.Yes)
                        //    {
                        //        detail.IsDeleted = true;
                        //detail.DateModified = clsSecurity.getServerDateTime();
                        //detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                        //        detail.Update();
                        //        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        ClearFields();
                        //        RefreshGrid();
                        //    }
                        //    //else if (msgResult == DialogResult.No)
                        //    //{
                        //    //    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyCancel), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    //}
                        //}
                    }
                    else
                    {
                        strMessage += "\n" + "Plase select the recode ";
                        MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
               
                RefreshGrid();
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
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Creat IOU
        private void btnCreatIou_Click(object sender, EventArgs e)
        {
            if(!IsUpdate)
            {
                //Creat new Iou 
                if (txtIouName.TextLength > 0 && txtIOUManager.TextLength > 0)
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;

                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    {
                        gblIOUID = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                        dgvDetail["IOUID", iRow].Value = gblIOUID;
                        dgvDetail["LineNumber", iRow].Value = iRow;
                        dgvDetail["Balance", iRow].Value = 0;
                        dgvDetail["DateCreated", iRow].Value = dtpIOUCreatDate.Value.ToShortDateString();
                        dgvDetail["DateCreated", iRow].Tag = dtpIOUCreatDate.Value;
                        dgvDetail["IOUName", iRow].Value = txtIouName.Text;
                        dgvDetail["AssingedUser", iRow].Value = txtIOUManager.Text;
                        dgvDetail["IOUName", iRow].Tag = txtIouName.Text;
                        dgvDetail["Insert", iRow].Value = "true";
                        txtIouName.Clear();
                        txtIOUManager.Clear();
                    }
                }
            }
            else
            {
                //Update Iou
                clsCommon.SetEnableDisable_NormalTextbox(txtIOUManager, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtIouName, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpIOUCreatDate, true);
                clsCommon.SetEnableDisable_NormalLabel(lblUser, true);
                clsCommon.SetEnableDisable_NormalLabel(lblIouName, true);
                clsCommon.SetEnableDisable_NormalLabel(lblIouCreatDate, true);

                if (bUpdateIOUName)
                {
                    if (txtIouName.TextLength > 0 && txtIOUManager.TextLength > 0 && txtRowNo.TextLength > 0)
                    {
                        int iRow;
                        iRow = int.Parse(txtRowNo.Text.Trim());

                        dgvDetail["DateCreated", iRow].Value = dtpIOUCreatDate.Value.ToShortDateString();
                        dgvDetail["DateCreated", iRow].Tag = dtpIOUCreatDate.Value;
                        dgvDetail["IOUName", iRow].Value = txtIouName.Text;
                        dgvDetail["AssingedUser", iRow].Value = txtIOUManager.Text;
                        txtIouName.Clear();
                        txtIOUManager.Clear();
                        bUpdateIOUName = false;
                        IsUpdate = false;
                    }
                }
                bUpdateIOUName = true;
            }
        }
        #endregion

        #region Btn Add Income
        private void btnAddIncome_Click(object sender, EventArgs e)
        {
            decimal dbalance = 0;
            decimal dReturn = 0;
            decimal dExpenditure = 0;
            decimal damount = 0;

            if (IsUpdate)
            {
                bool bInsret = bool.Parse(clsValidate.ValidateGridValue(dgvDetail, "Insert", int.Parse(txtRowNo.Text), ""));

                if (!bInsret)
                {
                    if (txtAmount.TextLength > 0)
                    {
                        dbalance = decimal.Parse(dgvDetail["Balance", int.Parse(txtRowNo.Text)].Value.ToString());
                        damount = decimal.Parse(txtAmount.Text);
                    }
                    if (rdoReturn.Checked && (damount + dbalance > 0))
                    {
                        string strMessage = "You cannot settled more than Remaining Balance";
                        MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (CheckNumberValidity())
                        {

                            #region Send IOU Details to List
                            List<tbl_bpsPettyCashAccount_IOU_Detail> details = tbl_bpsPettyCashAccount_IOU_Detail.SelectAllByIouAccount_ID(gblIOUID);

                            int icount = 0;
                            foreach (tbl_bpsPettyCashAccount_IOU_Detail detail in list)
                            {
                                if (detail.IouAccount_ID == gblIOUID)
                                    ++icount;
                            }
                            // icount = list iou details Count
                            tbl_bpsPettyCashAccount_IOU_Detail IOUObject = new tbl_bpsPettyCashAccount_IOU_Detail((details.Count+icount)+1 , gblIOUID, dtpIouDate.Value, txtNaration.Text, "", decimal.Parse(txtAmount.Text), rdoReturn.Checked, rdoExpenditure.Checked);
                            list.Add(IOUObject);
                            #endregion

                            dbalance = decimal.Parse(dgvDetail["Balance", int.Parse(txtRowNo.Text)].Value.ToString());
                            if (rdoReturn.Checked)
                            {
                                if (txtAmount.TextLength > 0)
                                {
                                    dReturn = decimal.Parse(txtAmount.Text);
                                    dgvDetail["Return", int.Parse(txtRowNo.Text)].Value = clsFormatter.FormatToCurrecyWithThousendSep(dbalance);
                                    dgvDetail["Expenditure", int.Parse(txtRowNo.Text)].Value = 0;
                                }
                            }
                            else if (rdoExpenditure.Checked)
                            {
                                if (txtAmount.TextLength > 0)
                                {
                                    dExpenditure = -decimal.Parse(txtAmount.Text);
                                    dgvDetail["Expenditure", int.Parse(txtRowNo.Text)].Value = clsFormatter.FormatToCurrecyWithThousendSep(dbalance);
                                    dgvDetail["Return", int.Parse(txtRowNo.Text)].Value = 0;
                                }
                            }
                            dbalance = dExpenditure + dReturn + dbalance;
                            dgvDetail["Balance", int.Parse(txtRowNo.Text)].Value = clsFormatter.FormatToCurrecyWithThousendSep(dbalance);
                            ClearFieldContact();
                        }
                    }
                }
                else
                {
                    string strMessage = "Please Save The New IOU";
                    MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string strMessage = "Please select the IOU";
                MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        } 
        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
            {
                ValidateEmptyForeignKey();
                try
                {
                    Cursor = Cursors.WaitCursor;
                    foreach (DataGridViewRow row in dgvDetail.Rows)
                    {
                        string sIOUName = "", sAssingedUser = "";
                        decimal dBalance = 0;
                        DateTime dDateCreated;
                        bool bInsret;

                        dBalance = clsValidate.ValidateGridValue(dgvDetail, "Balance", row.Index, decimal.Parse("0.00"));
                        dDateCreated = DateTime.Parse(dgvDetail["DateCreated", row.Index].Tag.ToString());
                        sIOUName = clsValidate.ValidateGridValue(dgvDetail, "IOUName", row.Index, "");
                        sAssingedUser = clsValidate.ValidateGridValue(dgvDetail, "AssingedUser", row.Index, "");
                        bInsret = bool.Parse(clsValidate.ValidateGridValue(dgvDetail, "Insert", row.Index, ""));
                        gblIOUID = clsValidate.ValidateGridValue(dgvDetail, "IOUID", row.Index, "");

                        //row.Index

                        tbl_bpsPettyCashAccount_IOU Gride = new tbl_bpsPettyCashAccount_IOU(gblIOUID, gblPettyCash,
                            dDateCreated, sIOUName, dBalance, sAssingedUser,
                            clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, txtCheckedBy.Tag.ToString(), txtApprovedBy.Tag.ToString(), clsSecurity.getServerDateTime(),
                            clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, bHasChecked, bHasApproved, false, false, false, false);

                        if (bInsret)
                            Gride.Insert();
                        else
                            Gride.Update();

                        #region Insert IOU Detail
                        foreach (tbl_bpsPettyCashAccount_IOU_Detail detail in list)
                        {
                            detail.Insert();
                        }
                        list.Clear();
                        #endregion
                    }
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID,ex);
                    SEACCException.Show(ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                    ClearFields();
                    RefreshGrid();
                }
            }
            else //if no permission to write
            {
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToWrite), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion


        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetail);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            txtAmount.Clear();
            txtIouName.Clear();
            txtIouName.Clear();
            txtIOUManager.Clear();
            txtNaration.Clear();
            clsCommon.SetEnableDisable_NormalTextbox(txtIOUManager, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtIouName, true);
            clsCommon.SetEnableDisable_NormalDateTimePicker(dtpIOUCreatDate, true);
            clsCommon.SetEnableDisable_NormalLabel(lblUser, true);
            clsCommon.SetEnableDisable_NormalLabel(lblIouName, true);
            clsCommon.SetEnableDisable_NormalLabel(lblIouCreatDate, true);
            IsUpdate = false;
        }
        #endregion

        #region Clear Field Contact
        private void ClearFieldContact()
        {
            //set the flag and enble the id
            txtAmount.Clear();
            txtNaration.Clear();
        }
        #endregion

        #region Fill Details
        private void FillDetails(int iID)
        {
            try
            {
                if (iID >= 0)
                {
                        //set the update flag and Locked
                        IsUpdate = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtIOUManager, false);
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtIouName, false);
                        clsCommon.SetEnableDisable_NormalDateTimePicker(dtpIOUCreatDate, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblUser, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblIouName, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblIouCreatDate, false);
                        //asign values
                        gblIOUID = dgvDetail["IOUID", iID].Value.ToString();
                        txtIOUManager.Text = dgvDetail["AssingedUser", iID].Value.ToString();
                        txtIouName.Text = dgvDetail["IOUName", iID].Value.ToString();
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
        private void RefreshGrid()
        {           
            int iRownew;
            dgvDetail.Rows.Clear();
          //  decimal dBalance = 0;

            List<tbl_bpsPettyCashAccount_IOU> details = tbl_bpsPettyCashAccount_IOU.SelectAllByPettyCashAccount_ID(gblPettyCash);

            foreach (tbl_bpsPettyCashAccount_IOU detail in details)
            {
                if (detail.IouAccount_ID != "default")
                {
                    dgvDetail.Rows.Add();
                    iRownew = dgvDetail.Rows.Count - 1;

                    dgvDetail["DateCreated", iRownew].Tag = detail.IouDate;
                    dgvDetail["DateCreated", iRownew].Value = detail.IouDate.ToShortDateString();
                    dgvDetail["AssingedUser", iRownew].Value = detail.IouMangerName;
                    dgvDetail["IOUID", iRownew].Value = detail.IouAccount_ID;
                    dgvDetail["IOUName", iRownew].Value = detail.Remark;
                    dgvDetail["Balance", iRownew].Value = clsFormatter.FormatToCurrecyWithThousendSep(detail.BalanceAmount);
                    dgvDetail["Insert", iRownew].Value = "false";
                    gblIoubalnce = detail.BalanceAmount;
                }
            }
        } 
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    txtRowNo.Text = e.RowIndex.ToString();
                    FillDetails(e.RowIndex);
                    bUpdateIOUName = false;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail_CellClick(sender, e);
        }
        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    frm_bpsPettyCashIOUDetails detail = new frm_bpsPettyCashIOUDetails();
                    detail.gbllineNumber = e.RowIndex;
                    detail.gblPettyCash = gblPettyCash;
                    detail.gblIOUID = gblIOUID;
                    detail.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Event Double Click
        private void txtCheckedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }
        private void txtApprovedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }
        #endregion

        #region Key Down
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

        #region Key Press
        private void txtIncome_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimal(txtAmount.Text, e);
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
                SEACCException.Show(ex);
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
                SEACCException.Show(ex);
            }
        }
        #endregion


        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;
           
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }

        private bool CheckNumberValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (txtIouName.TextLength == 0)
                {
                    strMessage += "\n" + "Iou Name ";
                    bStatus = false;
                }
                if (txtAmount.TextLength == 0)
                {
                    strMessage += "\n" + "Amount";
                    bStatus = false;
                }
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
            clsCommon.ValidateForeignKey(ref txtCheckedBy);
            clsCommon.ValidateForeignKey(ref txtApprovedBy);
        }
        #endregion   

    }
}
