using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;

namespace Digiteq
{
    public partial class frmSecurityType_Value : Form
    {
        #region Variables
        //to manage update and insert
        static bool IsUpdate = false;

        //to keep form detail       
        string sFormConfigCode;
           public int iFormID;
        public bool bNoAccess;
        #endregion

        public frmSecurityType_Value()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.SecurityConfigTypeValue );
            iFormID = clsSecurity.getFormID(FormName.SecurityConfigTypeValue );
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }

            InitializeComponent();
        }

        #region frm load
        private void frm_mtrSecurityConfigTypeValue_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Security Configeration Type Value", 2, iFormID);
            RefreshGrid();
            CusDataGridViewFormat();
            ClearFields();
        }
        #endregion

        # region btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        # region Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtConfigTypeValueID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record

                        Cursor = Cursors.WaitCursor;
                        tbl_securityConfigType_Value  detail = tbl_securityConfigType_Value.Select(txtConfigTypeValueID.Text.Trim());
                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " Security Configeration Type Value " + detail.ConfigTypeValue ), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
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
            finally
            {
                Cursor = Cursors.Default;
                ClearFields();
                RefreshGrid();
            }
        }

        #endregion

        #region btn save
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
                            if (txtConfigTypeValueID.TextLength > 0)
                            {
                                if (IsUpdate)  //update records
                                {
                                    tbl_securityConfigType_Value  oldRecord = tbl_securityConfigType_Value.Select(txtConfigTypeValueID.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        //Country Header
                                        tbl_securityConfigType_Value  detail = new tbl_securityConfigType_Value(txtConfigTypeValueID.Text.Trim(), txtConfigTypeValue.Text.Trim(), txtRemark.Text.Trim());
                                        detail.Update();
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else  //insert records
                                {
                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                        txtConfigTypeValueID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                    //Inquiry Header
                                    tbl_securityConfigType_Value  detail = new tbl_securityConfigType_Value(txtConfigTypeValueID.Text.Trim(), txtConfigTypeValue.Text.Trim(), txtRemark.Text.Trim());
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
                List<tbl_securityConfigType_Value> details = tbl_securityConfigType_Value.SelectAll();
                foreach (tbl_securityConfigType_Value detail in details)
                {
                    if (detail.ConfigTypeValue_ID != "default")
                    {

                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["ConfigTypeValue_ID", iRow].Value = detail.ConfigTypeValue_ID;
                        dgvDetail["ConfigconfigTypeValue", iRow].Value = detail.ConfigTypeValue;
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
                    tbl_securityConfigType_Value detail = tbl_securityConfigType_Value.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtConfigTypeValueID,false);
                        clsCommon.SetEnableDisable_NormalLabel(lblConfigTypeValue_ID,false);

                        //asign values
                        txtConfigTypeValueID.Text = detail.ConfigTypeValue_ID ;
                        txtConfigTypeValue.Text = detail.ConfigTypeValue;
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

            if (txtConfigTypeValue.TextLength == 0)
            {
                strMessage += "\n" + "Configuration type Values ";
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
            clsSearch.Search_MasterSecurityConfigType_Status(ref txtConfigTypeValueID);
            if (txtConfigTypeValueID.Tag != null)
                FillDetails(txtConfigTypeValueID.Tag.ToString());
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
        private void txtConfigTypeValueID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterSecurityConfigType_Value (ref txtConfigTypeValueID);
            if (txtConfigTypeValueID.Tag != null)
                FillDetails(txtConfigTypeValueID.Tag.ToString());
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
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtConfigTypeValueID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblConfigTypeValue_ID ,true);

            txtConfigTypeValue.Clear();
            txtRemark.Clear();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtConfigTypeValueID.Text = "<Auto Generate>";
            else
                txtConfigTypeValueID.Clear();
            if (txtConfigTypeValueID.Enabled)
            {
                txtConfigTypeValueID.SelectAll();
                txtConfigTypeValueID.Focus();
                txtConfigTypeValue.SelectAll();
                txtConfigTypeValue.Focus();

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
                    string sID = dgvDetail["ConfigTypeValue_ID", e.RowIndex].Value.ToString();
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
