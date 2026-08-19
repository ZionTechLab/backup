using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;


namespace Digiteq
{
    public partial class frm_bpsPettyCashPermission : Form
    {
        
        //to manage update and insert
        static bool IsUpdate = false;

        //to keep form detail       
        //string sFormConfigCode;
        public int iFormID;
        public bool bNoAccess;
        public string glbPettyCashAccount = "";
        public string glbPettyCashAccountName = "";
        public string glbSupperUserID = "";

        //to identify initialization situation
        private bool bInitFrom_MainFrom = false;



        #region Form Load
        public frm_bpsPettyCashPermission(bool bInitMainFrom)
        {
            //sFormConfigCode = clsAutocode.getFormConfigCode(FormName.PettyCashPermission);
            iFormID = clsSecurity.getFormID(FormName.PettyCashPermission);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
            bInitFrom_MainFrom = bInitMainFrom;
        }

        private void frm_mtrBranch_Load(object sender, EventArgs e)
        {
            //add data to the datagrid and format        
            clsFormatter.setFormatForm(this, "Petty Cash Permission", 2, iFormID);
            CusDataGridViewFormat();
            ClearFields();

            txtpettyCashAccount_ID.Tag = glbPettyCashAccount;
            txtpettyCashAccount_ID.Text = glbPettyCashAccountName;
            RefreshGrid();
        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtpettyCashAccount_ID.Text.Trim().Length > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, ""), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (msgResult == DialogResult.Yes)
                        {
                            //delete one record
                            Cursor = Cursors.WaitCursor;
                            tbl_bpsPettyCashAccount_Permission detail = tbl_bpsPettyCashAccount_Permission.Select(glbPettyCashAccount, txtUserName.Tag.ToString());
                            if (detail != null)
                            {
                                detail.Delete();
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearFields();
                                RefreshGrid();
                            }
                        }
                        //else if (msgResult == DialogResult.No)
                        //{
                        //    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyCancel), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                    }
                   
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
        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (CheckNumberValidity())
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                    {
                        string sPettyCashAccount_ID = "";

                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            if (txtpettyCashAccount_ID.TextLength > 0)
                            {
                                if (IsUpdate)  //update records
                                {

                                    tbl_bpsPettyCashAccount_Permission oldRecord = tbl_bpsPettyCashAccount_Permission.Select(txtpettyCashAccount_ID.Tag.ToString(), txtUserName.Tag.ToString());
                                    if (oldRecord != null)
                                    {
                                        //Country Header
                                        tbl_bpsPettyCashAccount_Permission detail = new tbl_bpsPettyCashAccount_Permission(txtpettyCashAccount_ID.Tag.ToString(), txtUserName.Tag.ToString(), chkRed.Checked, chkWrite.Checked, chkDelete.Checked, chkApprovable.Checked, chkChekable.Checked);
                                        //oldRecord.AllowRead, oldRecord.AllowWrite, oldRecord.AllowDelete, oldRecord.AllowApprovable, oldRecord.AllowCheckable);
                                        detail.Update();

                                        sPettyCashAccount_ID = oldRecord.PettyCashAccount_ID;
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else  //insert records
                                {

                                    tbl_bpsPettyCashAccount_Permission detail = new tbl_bpsPettyCashAccount_Permission(txtpettyCashAccount_ID.Tag.ToString(), txtUserName.Tag.ToString(), chkRed.Checked, chkWrite.Checked, chkDelete.Checked, chkApprovable.Checked, chkChekable.Checked);
                                    detail.Insert();

                                    sPettyCashAccount_ID = detail.PettyCashAccount_ID;
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show(" Permission " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            ClearFields();

                            txtpettyCashAccount_ID.Tag = sPettyCashAccount_ID;
                            txtpettyCashAccount_ID.Text = sPettyCashAccount_ID;
                            RefreshGrid();
                        }
                    }
                }
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
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtpettyCashAccount_ID, bInitFrom_MainFrom);
            clsCommon.SetEnableDisable_NormalLabel(lblpettyCashAccount_ID, bInitFrom_MainFrom);

            //set the flag and enble the id
            IsUpdate = false;

            txtpettyCashAccount_ID.Tag = null;
            txtUserName.Tag = null;

            txtpettyCashAccount_ID.Text = "";
            txtUserName.Text = "";

            if (bInitFrom_MainFrom)
                txtpettyCashAccount_ID.Focus();
            else
                txtUserName.Focus();

            chkApprovable.Checked = false;
            chkChekable.Checked = false;
            chkDelete.Checked = false;
            chkRed.Checked = false;
            chkWrite.Checked = false;

            dgvDetail.Rows.Clear();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                List<tbl_bpsPettyCashAccount_Permission> details = tbl_bpsPettyCashAccount_Permission.SelectAllByPettyCashAccount_ID(txtpettyCashAccount_ID.Tag.ToString());
                foreach (tbl_bpsPettyCashAccount_Permission detail in details)
                {
                    if (detail.PettyCashAccount_ID.Trim() != "default")
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["BranchName", iRow].Value = clsGenaralName.getName_User(detail.User_ID);
                        dgvDetail["UserID", iRow].Value = detail.User_ID;
                    }
                }
                dgvDetail.ClearSelection();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
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
                    tbl_bpsPettyCashAccount_Permission detail = tbl_bpsPettyCashAccount_Permission.Select(txtpettyCashAccount_ID.Tag.ToString(), sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtpettyCashAccount_ID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblpettyCashAccount_ID, false);

                        //asign values
                        txtUserName.Tag = detail.User_ID;
                        txtUserName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.User_ID));
                        txtpettyCashAccount_ID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_PettyCashAccount(detail.PettyCashAccount_ID));
                        txtpettyCashAccount_ID.Tag = detail.PettyCashAccount_ID;

                        chkRed.Checked = detail.AllowRead;
                        chkWrite.Checked = detail.AllowWrite;
                        chkDelete.Checked = detail.AllowDelete;
                        chkApprovable.Checked = detail.AllowApprovable;
                        chkChekable.Checked = detail.AllowCheckable;
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


        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;
            try
            {
                if (txtUserName.TextLength == 0)
                {
                    strMessage += "\n" + " User Name ";
                    bStatus = false;
                }
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    if (txtUserName.TextLength != 0)
                        if (clsValidate.ValidateGridValue(dgvDetail, "UserID", row.Index, "").ToString() == txtUserName.Tag.ToString() && IsUpdate == false)
                        {
                            strMessage += "\n" + "You Cannot Create Same User again ";
                            bStatus = false;
                            break;
                        }
                }
                if (bStatus == false)
                {
                    MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
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
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion

        #region Events KeyDown
        private void txtpettyCashAccount_ID_KeyDown(object sender, KeyEventArgs e)
        {
            clsSearch.Search_TransactionPettyCashAccount(ref txtpettyCashAccount_ID);
            RefreshGrid();
        }
        #endregion

        #region Events DoubleClick
        private void txtBranchID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterUserExceptByUserID(ref txtUserName, glbSupperUserID);
        }

        private void txtpettyCashAccount_ID_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            clsSearch.Search_TransactionPettyCashAccount(ref txtpettyCashAccount_ID);
            RefreshGrid();
        }
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sID = dgvDetail["UserID", e.RowIndex].Value.ToString();
                if (sID.Length > 0)
                {
                    //fills the values to controls
                    FillDetails(sID.Trim());
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
        #endregion




    }

}
