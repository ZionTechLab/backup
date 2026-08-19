using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;


namespace Digiteq
{
    public partial class frmSecurityConfigStatus : Form
    {
        
        //to manage update and insert
        static bool IsUpdate = false;

        //to keep form detail       
        string sFormConfigCode;
           public int iFormID;
        public bool bNoAccess;
 

        #region Form Load
        public frmSecurityConfigStatus()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.SecurityConfigStatus);
            iFormID = clsSecurity.getFormID(FormName.SecurityConfigStatus);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }

            InitializeComponent();
        }

        private void frm_mtr_SecurityConfigStatus_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Security Configeration Value", 2, iFormID);
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
                if (txtValueID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record

                        Cursor = Cursors.WaitCursor;
                        tbl_securityConfigStatus detail = tbl_securityConfigStatus.Select(Convert.ToInt32(txtValueID.Text.Trim()));
                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " Security Configeration Status " + detail.ValueName), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
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
                            if (txtValueID.TextLength > 0)
                            {
                                if (IsUpdate)  //update records
                                {
                                    ValidateEmptyForeignKey();
                                    tbl_securityConfigStatus oldRecord = tbl_securityConfigStatus.Select(Convert.ToInt32(txtValueID.Text.Trim()));
                                    if (oldRecord != null)
                                    {
                                        //Country Header
                                        tbl_securityConfigStatus detail = new tbl_securityConfigStatus(Convert.ToInt32(txtValueID.Text.Trim()), txtValueName.Text.Trim(),Convert.ToBoolean(txtConfigValue.Text.Trim()),txtStatusType.Tag.ToString());
                                        detail.Update();
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                //else  //insert records
                                //{
                                //    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                //        txtValueID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                //    //Inquiry Header
                                //    tbl_securityConfigValue detail = new tbl_securityConfigValue(Convert.ToInt32(txtValueID.Text.Trim()), txtValueName.Text.Trim(), txtConfigValue.Text.Trim(), txtTypeValueID.Text.Trim());
                                //    detail.Insert();
                                //    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //}
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


        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtValueID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblValueID, true);

            txtValueName.Clear();
            txtStatusType.Clear();
            txtConfigValue.Clear();


            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtValueID.Text = "<Auto Generate>";
            else
                txtValueID.Clear();
            if (txtValueID.Enabled)
            {
                txtValueID.SelectAll();
                txtValueID.Focus();
                txtValueName.SelectAll();
                txtValueName.Focus();

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
                List<tbl_securityConfigStatus> details = tbl_securityConfigStatus.SelectAll();
                foreach (tbl_securityConfigStatus detail in details)
                {
                    if (detail.ValueID.ToString().Trim() != "default")
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["ConfigValueID", iRow].Value = detail.ValueID;
                        dgvDetail["ConfigValueName", iRow].Value = detail.ValueName;
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
        private void FillDetails(int iID)
        {
            try
            {
                if (iID > 0)
                {
                    tbl_securityConfigStatus detail = tbl_securityConfigStatus.Select(iID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtValueID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblValueID, false);

                        //asign values
                       txtStatusType.Tag = detail.ConfigTypeStatus_ID;
                       txtStatusType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SecurityConfigType_Status(detail.ConfigTypeStatus_ID));

                        txtValueID.Text = Convert.ToString(detail.ValueID);
                        txtValueName.Text = detail.ValueName;
                        txtConfigValue.Text =Convert.ToString(detail.ConfigValue);
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

            if (txtValueName.TextLength == 0)
            {
                strMessage += "\n" + "Configuration Status Values Name ";
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
        private void txtValueID_KeyDown(object sender, KeyEventArgs e)
        {
            Search_ConfigValue();
        }
        private void txtTypeValueID_KeyDown(object sender, KeyEventArgs e)
        {
            Search_ConfigValueType();
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
        private void txtValueID_DoubleClick(object sender, EventArgs e)
        {
            Search_ConfigValue();
        }

        private void txtTypeValueID_DoubleClick(object sender, EventArgs e)
        {
            Search_ConfigValueType();
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetail);
        }
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = clsValidate.ValidateGridValue(dgvDetail, "ConfigValueID", e.RowIndex, "");
                    if (sID.ToString().Length > 0)
                        FillDetails(int.Parse(sID));
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

        #region Search Methods
        private void Search_ConfigValue()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.Search_MasterSecurityConfigStatus(ref txtValueID);
                if (txtValueID.Tag != null && txtValueID.Tag.ToString().Trim().Length > 0)
                {
                    FillDetails(int.Parse(txtValueID.Tag.ToString().Trim()));
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_ConfigValueType()
        {
            try
            {
                clsSearch.Search_MasterSecurityConfigType_Status(ref txtStatusType);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtStatusType);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion       
    }
}
