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
    public partial class frm_CommissionSlabSetting : MettroForm
    {
        #region Variables
        //to manage update and insert
        static bool IsUpdate = false;

        //to keep form detail       
        string sFormConfigCode;
           public int iFormID;
        public bool bNoAccess;
        #endregion

        #region Form Load
        public frm_CommissionSlabSetting()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.zCommissionSlabSetting);
            iFormID = clsSecurity.getFormID(FormName.zCommissionSlabSetting);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_mtrBranch_Load(object sender, EventArgs e)
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
                if (txtSlabID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_zCommissionSlabSetting oSlab = tbl_zCommissionSlabSetting.Select(txtSlabID.Tag.ToString());
                        if (oSlab != null && oSlab.SlabID != "default")
                        {
                            oSlab.IsDeleted = true;
                           
                            oSlab.Update();
                            clsHelpMethods.InsertTransactionHistory(iFormID, txtSlabID.Text.ToString(), TxnActivity.Update);

                        }

                        Cursor = Cursors.Default;
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        RefreshGrid();
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
                            if (txtSlabID.TextLength > 0)
                            {
                                tbl_zCommissionSlabSetting oSlab = tbl_zCommissionSlabSetting.Select(txtSlabID.Tag.ToString());
                                if (oSlab != null && oSlab.SlabID != "default")
                                {
                                    oSlab.SlabName = txtSlabName.Text;
                                    oSlab.DateRange = decimal.Parse(txtDateRange.Text.Trim());
                                    oSlab.CommissionPercentage=decimal.Parse(txtCommissionPersentage.Text.Trim());                                   
                                    oSlab.Update();
                                    clsHelpMethods.InsertTransactionHistory(iFormID, txtSlabID.Text.ToString(), TxnActivity.Update);
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
            //set the flag and enble the id
            IsUpdate = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtSlabID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblBranchD, true);

            txtSlabID.Tag = null;
            txtSlabID.Clear();
            txtSlabName.Clear();
            txtDateRange.Clear();
            txtCommissionPersentage.Clear();           
            

        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                List<tbl_zCommissionSlabSetting> details = tbl_zCommissionSlabSetting.SelectAll();
                foreach (tbl_zCommissionSlabSetting detail in details)
                {
                    if (detail.SlabID.Trim() != "default")
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["SlabID", iRow].Value = detail.SlabID;
                        dgvDetail["SlabName", iRow].Value = detail.SlabName;
                        dgvDetail["DateRange", iRow].Value = clsFormatter.FormatToNumberNoDecimal(detail.DateRange);
                        dgvDetail["CommissionPersentage", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.CommissionPercentage);
                        dgvDetail["IsCancel", iRow].Value = detail.IsDeleted;
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
                    tbl_zCommissionSlabSetting detail = tbl_zCommissionSlabSetting.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtSlabID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblBranchD, false);

                        //asign values
                        txtSlabID.Text = detail.SlabID; 
                        txtSlabID.Tag = detail.SlabID;
                        txtSlabName.Text = detail.SlabName ;
                        txtDateRange.Text = clsFormatter.FormatToNumberNoDecimal(detail.DateRange);
                        txtCommissionPersentage.Text = clsFormatter.FormatDecimalPlaces_Price(detail.CommissionPercentage);
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
                if (txtSlabID.TextLength == 0)
                {
                    strMessage += "\n" + "Slab ID ";
                    bStatus = false;
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
        private void txtCompanyBranchID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_SlabID();
            }   
        }
       
        #endregion

        #region Events DoubleClick
        private void txtCompanyBranchID_DoubleClick(object sender, EventArgs e)
        {
            Search_SlabID();
        }
       
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvDetail["SlabID", e.RowIndex].Value.ToString();
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

        #region Event KeyPress
        private void txtTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowIntegerAndPlus(e);
        }

        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowIntegerAndPlus(e);
        }
        #endregion

        #region Search Methods
        
        private void Search_SlabID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_CommissionSlabSetting();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    txtSlabID.Text = frmSearchMaster.s_SearchID;
                    FillDetails(frmSearchMaster.s_SearchID);
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
