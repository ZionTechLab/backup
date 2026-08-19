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
    public partial class frmDateSettings : Form
    {
        
        //to manage update and insert
        static bool IsUpdate = false;

        //to keep form detail       
        string sFormConfigCode;
           public int iFormID;
        public bool bNoAccess;


        #region Form Load
        public frmDateSettings()
        {
        
            iFormID = clsSecurity.getFormID(FormName.DateSettings);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frmDateSettings_Load(object sender, EventArgs e)
        {
            //add data to the datagrid and format            
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
                if (txtProcessNoteID.Tag == null || txtProcessNoteID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_securityDateSettings detail = tbl_securityDateSettings.Select(int.Parse(txtProcessNoteID.Tag.ToString().Trim()));
                        if (detail != null)
                        {
                            detail.Delete();
                        }

                        Cursor = Cursors.Default;
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        RefreshGrid();
                    }
                    else //if no permission to delete
                    {
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                Cursor = Cursors.Default;
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
                            if (txtProcessNoteID.TextLength > 0)
                            {
                                if (IsUpdate)  //update records
                                {
                                    tbl_securityDateSettings oldRecord = tbl_securityDateSettings.Select(int.Parse(txtProcessNoteID.Tag.ToString().Trim()));
                                    if (oldRecord != null)
                                    {
                                        //Country Header
                                        tbl_securityDateSettings detail = new tbl_securityDateSettings(int.Parse(txtProcessNoteID.Tag.ToString().Trim()), chkActivate.Checked, int.Parse(txtMaxBackwardDays.Text.Trim()), int.Parse(txtMaxForwardDays.Text.Trim()));
                                        detail.Update();
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else  //insert records
                                {

                                    //Inquiry Header
                                    tbl_securityDateSettings detail = new tbl_securityDateSettings(int.Parse(txtProcessNoteID.Tag.ToString().Trim()), chkActivate.Checked, int.Parse(txtMaxBackwardDays.Text.Trim()), int.Parse(txtMaxForwardDays.Text.Trim()));
                                    detail.Insert();
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Process Note " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtProcessNoteID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblProcessNoteID, true);

            txtProcessNoteID.Tag = null;

            txtMaxBackwardDays.Clear();
            txtMaxForwardDays.Clear();
            txtProcessNoteID.Clear();

        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();

                List<tbl_securityDateSettings> details = tbl_securityDateSettings.SelectAll();
                foreach (tbl_securityDateSettings detail in details)
                {
                    if (detail.ProcessNote_ID != 0)
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["ProcessNoteID", iRow].Tag = detail.ProcessNote_ID;
                        dgvDetail["ProcessNoteID", iRow].Value = clsGenaralName.getName_ProcessNote(detail.ProcessNote_ID);
                        dgvDetail["MaxFowardDays", iRow].Value = detail.MaxDaysForward.ToString();
                        dgvDetail["MaxBackwardDays", iRow].Value = detail.MaxDaysBackword.ToString();
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
                tbl_securityDateSettings detail = tbl_securityDateSettings.Select(iID);
                if (detail != null && detail.ProcessNote_ID != 0)
                {
                    //set the update flag and Locked
                    IsUpdate = true;
                    clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtProcessNoteID, false);
                    clsCommon.SetEnableDisable_NormalLabel(lblProcessNoteID, false);

                    //asign values
                    txtProcessNoteID.Tag = detail.ProcessNote_ID.ToString();
                    txtProcessNoteID.Text = clsGenaralName.getName_ProcessNote(detail.ProcessNote_ID);
                    txtMaxBackwardDays.Text = detail.MaxDaysBackword.ToString();
                    txtMaxForwardDays.Text = detail.MaxDaysForward.ToString();
                    chkActivate.Checked = detail.IsEnable;
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

            if (txtMaxBackwardDays.TextLength == 0 )
            {
                strMessage += "\n" + "BackWard Days";
                bStatus = false;
            }
            if (txtMaxForwardDays.TextLength == 0)
            {
                strMessage += "\n" + "ForWard Days";
                bStatus = false;
            }
            if (txtProcessNoteID.Tag == null || txtProcessNoteID.Tag.ToString().Trim().Length == 0)
            {

                strMessage += "\n" + "Process Notes";
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
        private void txtProcessNoteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_ProcessNoteID();
            }

        }

        private void frmDateSettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Event DoubleClick
        private void txtProcessNoteID_DoubleClick(object sender, EventArgs e)
        {
            Search_ProcessNoteID();
        } 
        #endregion

        #region Event KeyPress
        private void txtMaxForwardDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowInteger(e);

        }

        private void txtMaxBackwardDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowInteger(e);
        }
        #endregion


        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int iID = clsValidate.ValidateGridTag(dgvDetail,"ProcessNoteID",e.RowIndex,int.Parse("0"));
                    if (iID != 0)
                    {
                        //fills the values to controls
                        FillDetails(iID);
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

        #region Search Methods
        private void Search_ProcessNoteID()
        {
            try
            {
                clsSearch.passValue_ProcessMasterNoArg(txtProcessNoteID);
                if (txtProcessNoteID.Tag != null && txtProcessNoteID.Tag.ToString().Trim().Length > 0)
                {
                    FillDetails(int.Parse(txtProcessNoteID.Tag.ToString()));
                }
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
