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
using Digiteq_Logic; using SEACC.WinFormControls.Forms;

namespace Digiteq
{
    public partial class frm_AccSlotChange : MettroForm
    {
        #region Variables
        //to manage update and insert

        string sLevel1ID;
        #endregion

        #region Form Load
        public frm_AccSlotChange()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.ZBank);
            iFormID = clsSecurity.getFormID(FormName.ZBank);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
           
        }
        private void frm_AccFormula_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Account Sloat Change", 3, iFormID);
            CusDataGridViewFormat();
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

                            if (txtSlotID.Tag != null )  
                            {
                                int iSlotID = int.Parse(txtSlotID.Tag.ToString());
                                tbl_accDoubleEntrySlotMaster oSlot = tbl_accDoubleEntrySlotMaster.Select(iSlotID);
                                if (oSlot != null)
                                {
                                    oSlot.IsDelete = chkIsDelete.Checked;
                                    oSlot.Update();
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtSlotID.Tag = null;
            txtSlotID.Clear();
            txtSlotName.Clear();
            chkIsDelete.Checked = false;
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgvDetail.Rows.Clear();
                foreach (tbl_accDoubleEntrySlotMaster oDetail in tbl_accDoubleEntrySlotMaster.SelectAll().Where(p => p.SlotName != "default"))
                {
                    dgvDetail.Rows.Add(oDetail.Slot_ID, oDetail.SlotName, oDetail.IsDelete);
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
        private void FillDetails(int sID)
        {
            try
            {
                tbl_accDoubleEntrySlotMaster oSlot = tbl_accDoubleEntrySlotMaster.Select(sID);
                if (sID != null)
                {
                    txtSlotID.Tag = oSlot.Slot_ID;
                    txtSlotID.Text = oSlot.Slot_ID.ToString();
                    txtSlotName.Text = oSlot.SlotName;
                    chkIsDelete.Checked = oSlot.IsDelete;
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



        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int sID = int.Parse(dgvDetail["SlotID", e.RowIndex].Value.ToString());
                    if (sID > 0)
                    {
                        //fills the values to controls
                        FillDetails(sID);
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
