using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;
using Digiteq_Logic;

namespace Digiteq
{
    public partial class frmSecurityType_Status : Form
    {
        #region Variables
        //to manage update and insert
        static bool IsUpdate = false;

        //to keep form detail       
        string sFormConfigCode;
           public int iFormID;
        public bool bNoAccess;
        #endregion

        #region Fromload
        public frmSecurityType_Status()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.SecurityConfigType_Status);
            iFormID = clsSecurity.getFormID(FormName.SecurityConfigType_Status );
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }

            InitializeComponent();
        }        
        private void frm_mtrSecurityConfigType_Status_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Security Configeration Type Status", 2, iFormID);
            RefreshGrid();
            CusDataGridViewFormat();
            ClearFields();
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
                if (txtConfigTypeStatusID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        
                            Cursor = Cursors.WaitCursor;
                            tbl_securityConfigType_Status detail = tbl_securityConfigType_Status.Select(txtConfigTypeStatusID.Text.Trim());
                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " Customer Order : " + detail.ConfigTypeStatus), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                            if (msgResult == DialogResult.Yes)
                            {
                                if (detail != null)
                                {
                                    detail.Delete();
                                }

                                Cursor = Cursors.Default;
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearFields();
                                RefreshGrid();
                            }
                    }
                    else //if no permission to delete
                    {
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
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
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            if (txtConfigTypeStatusID.TextLength > 0)
                            {
                                if (IsUpdate)  //update records
                                {
                                    tbl_securityConfigType_Status oldRecord = tbl_securityConfigType_Status.Select(txtConfigTypeStatusID.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        //Country Header
                                        tbl_securityConfigType_Status detail = new tbl_securityConfigType_Status(txtConfigTypeStatusID.Text.Trim(), txtConfigTypeStatus.Text.Trim(), txtRemark.Text.Trim());
                                        detail.Update();
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else  //insert records
                                {
                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                        txtConfigTypeStatusID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                    //Inquiry Header
                                    tbl_securityConfigType_Status detail = new tbl_securityConfigType_Status(txtConfigTypeStatusID.Text.Trim(), txtConfigTypeStatus.Text.Trim(), txtRemark.Text.Trim());
                                    detail.Insert();
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Type " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            RefreshGrid();
                        }
                    }
                }
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                List<tbl_securityConfigType_Status > details = tbl_securityConfigType_Status . SelectAll();
                foreach (tbl_securityConfigType_Status  detail in details)
                {
                    if (detail.ConfigTypeStatus_ID  != "default")
                    {

                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["ConfigStatusID", iRow].Value = detail.ConfigTypeStatus_ID;
                        dgvDetail["ConfigStatus", iRow].Value = detail.ConfigTypeStatus;
                        dgvDetail["Remark", iRow].Value = detail.Remark;
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

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_securityConfigType_Status detail = tbl_securityConfigType_Status.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox( txtConfigTypeStatusID , false);
                        clsCommon.SetEnableDisable_NormalLabel(lblConfigTypeStatusID , false);

                        //asign values
                         txtConfigTypeStatusID.Text = detail.ConfigTypeStatus_ID;
                         txtConfigTypeStatus.Text = detail.ConfigTypeStatus ;
                         txtRemark.Text = detail.Remark;
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

            if ( txtConfigTypeStatus . TextLength == 0)
            {
                strMessage += "\n" + "Configuration type Status ";
                bStatus = false;
            }
            
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
        private void txtConfigTypeStatusID_KeyDown(object sender, KeyEventArgs e)
        {
            clsSearch.Search_MasterSecurityConfigType_Status (ref txtConfigTypeStatusID);
            if (txtConfigTypeStatusID.Tag != null)
                FillDetails(txtConfigTypeStatusID.Tag.ToString());
        }
        private void frm_mtrSecurityConfigType_Status_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtConfigTypeStatusID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterSecurityConfigType_Status (ref txtConfigTypeStatusID);
            if (txtConfigTypeStatusID.Tag != null)
                FillDetails(txtConfigTypeStatusID.Tag.ToString());
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
            //set the flag and enble the id
            IsUpdate = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtConfigTypeStatusID  , true);
            clsCommon.SetEnableDisable_NormalLabel(lblConfigTypeStatusID , true);

            txtConfigTypeStatus.Clear();
            txtRemark.Clear();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtConfigTypeStatusID.Text   = "<Auto Generate>";
            else
               txtConfigTypeStatusID . Clear();
            if (txtConfigTypeStatusID.Enabled)
            {
                txtConfigTypeStatusID.SelectAll();
                txtConfigTypeStatusID.Focus();
                txtConfigTypeStatus.SelectAll();
                txtConfigTypeStatus.Focus();
           
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
                    string sID = dgvDetail["ConfigStatusID", e.RowIndex].Value.ToString();
                    if (sID.Length > 0)
                    {
                        //fills the values to controls
                        FillDetails(sID.Trim());
                    }
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
