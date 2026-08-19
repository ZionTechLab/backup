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
    public partial class frm_mtrEmployeeSlabSettings : MettroForm
    {
        #region Variables
        //to manage update and insert

        string strMessage = "";

        public string sEmployeeID = "default";
        #endregion

        #region Form Load
        public frm_mtrEmployeeSlabSettings()
        {
            iFormID = clsSecurity.getFormID(FormName.EmployeeSlabSettings);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_mtrEmployeeSlabSettings_Load(object sender, EventArgs e)
        {
            //add data to the datagrid and format
            RefreshGrid_ForAll();
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
                if (txtEmployeeID.TextLength > 0)
                {
                    if (ValidateForDependancies())
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            //delete one record
                            Cursor = Cursors.WaitCursor;
                            tbl_zEmployeeSlabSettings detail = tbl_zEmployeeSlabSettings.Select(txtEmployeeID.Tag.ToString(), int.Parse(txtSlabID.Text));
                            if (detail != null)
                            {
                                detail.Delete();
                                clsHelpMethods.InsertTransactionHistory(iFormID, txtEmployeeID.Text, TxnActivity.Cancel);
                            }

                            Cursor = Cursors.Default;
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                            RefreshGrid_ForAll();
                        }
                        else
                        {
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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

                            if (IsUpdate)  //update records
                            {
                                if (txtSlabID.TextLength > 0)
                                {
                                    tbl_zEmployeeSlabSettings oldRecord = tbl_zEmployeeSlabSettings.Select(txtEmployeeID.Tag.ToString(), int.Parse(txtSlabID.Text.Trim()));
                                    if (oldRecord != null)
                                    {
                                        //Country Header
                                        tbl_zEmployeeSlabSettings detail = new tbl_zEmployeeSlabSettings(oldRecord.Employee_ID, oldRecord.SlabID, decimal.Parse(txtFromAmount.Text.Trim()), decimal.Parse(txtToAmount.Text.Trim()), decimal.Parse(txtCommissionPercentage.Text.Trim()));
                                        detail.Update();
                                        clsHelpMethods.InsertTransactionHistory(iFormID, txtEmployeeID.Text, TxnActivity.Update);
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                    MessageBox.Show("Slab ID can not be empty ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);


                            }
                            else  //insert records
                            {
                                int iSlabID = 1;

                                if (tbl_zEmployeeSlabSettings.SelectAllByEmployee_ID(txtEmployeeID.Tag.ToString()).Count > 0)
                                    iSlabID = tbl_zEmployeeSlabSettings.SelectAllByEmployee_ID(txtEmployeeID.Tag.ToString()).Max(p => p.SlabID) + 1;

                                tbl_zEmployeeSlabSettings detail = new tbl_zEmployeeSlabSettings(txtEmployeeID.Tag.ToString(), iSlabID, decimal.Parse(txtFromAmount.Text.Trim()), decimal.Parse(txtToAmount.Text.Trim()), decimal.Parse(txtCommissionPercentage.Text.Trim()));
                                detail.Insert();
                                clsHelpMethods.InsertTransactionHistory(iFormID, txtEmployeeID.Text, TxnActivity.Insert);
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            RefreshGrid_ForAll();
                        }
                    }//
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
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtEmployeeID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblEmployeeID, true);

            txtEmployeeID.Clear();
            txtEmployeeID.Tag = null;

            txtSlabID.Clear();

            txtFromAmount.Text = "0";
            txtToAmount.Text = "0";
            txtCommissionPercentage.Text = "0";

            if (txtEmployeeID.Enabled)
            {
                txtEmployeeID.SelectAll();
                txtEmployeeID.Focus();
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid_ForAll()
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                List<tbl_zEmployeeSlabSettings> details = tbl_zEmployeeSlabSettings.SelectAll();
                foreach (tbl_zEmployeeSlabSettings detail in details)
                {
                    if (detail.Employee_ID != "default")
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["EmployeeID", iRow].Value = detail.Employee_ID;//
                        dgvDetail["EmployeeName", iRow].Value = clsGenaralName.getName_Employee(detail.Employee_ID);
                        dgvDetail["SlabID", iRow].Value = detail.SlabID;
                        dgvDetail["FromAmount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price( detail.FromAmount);
                        dgvDetail["ToAmount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.ToAmount);
                        dgvDetail["CommissionPercentage", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.CommissionPercentage);
                    }
                }
                dgvDetail.Columns["CommissionPercentage"].Width = 98;
                if (dgvDetail.RowCount > 12)
                {
                    dgvDetail.Columns["CommissionPercentage"].Width -= 12;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGrid_ForSelectedEmployee(string sEmployeeID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                List<tbl_zEmployeeSlabSettings> details = tbl_zEmployeeSlabSettings.SelectAllByEmployee_ID(sEmployeeID);
                foreach (tbl_zEmployeeSlabSettings detail in details)
                {
                    if (detail.Employee_ID != "default")
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["EmployeeID", iRow].Value = detail.Employee_ID;//
                        dgvDetail["EmployeeName", iRow].Value = clsGenaralName.getName_Employee(detail.Employee_ID);
                        dgvDetail["SlabID", iRow].Value = detail.SlabID;
                        dgvDetail["FromAmount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.FromAmount);
                        dgvDetail["ToAmount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.ToAmount);
                        dgvDetail["CommissionPercentage", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.CommissionPercentage);
                    }
                }

                dgvDetail.Columns["CommissionPercentage"].Width = 98;
                if (dgvDetail.RowCount > 12)
                {
                    dgvDetail.Columns["CommissionPercentage"].Width -= 12;                    
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
        private void FillDetails(string sID, int sSlabID)
        {
            try
            {
                if (sID.Length > 0 && sSlabID >= 0)
                {
                    tbl_zEmployeeSlabSettings detail = tbl_zEmployeeSlabSettings.Select(sID, sSlabID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtEmployeeID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblEmployeeID, false);

                        //assign values
                        txtEmployeeID.Text = clsGenaralName.getName_Employee(detail.Employee_ID);
                        txtEmployeeID.Tag = detail.Employee_ID;
                        txtSlabID.Text = detail.SlabID.ToString();
                        txtFromAmount.Text = clsFormatter.FormatDecimalPlaces_Price(detail.FromAmount);
                        txtToAmount.Text = clsFormatter.FormatDecimalPlaces_Price(detail.ToAmount);
                        txtCommissionPercentage.Text = clsFormatter.FormatDecimalPlaces_Price(detail.CommissionPercentage);
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

            if (txtEmployeeID.TextLength == 0)
            {
                strMessage += "\n" + "Employee Name ";
                bStatus = false;
            }
            if (txtFromAmount.TextLength == 0)
            {
                strMessage += "\n" + "From Amount ";
                bStatus = false;
            }
            if (txtToAmount.TextLength == 0)
            {
                strMessage += "\n" + "To Amount ";
                bStatus = false;
            }
            if (txtCommissionPercentage.TextLength == 0)
            {
                strMessage += "\n" + "Commission Percentage ";
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
        private void txtBankID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_Employee();
            }   
        }        
        private void frm_mtrBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtBankID_DoubleClick(object sender, EventArgs e)
        {
            Search_Employee();
        }
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {                   
                    string sID = clsValidate.ValidateGridValue(dgvDetail, "EmployeeID", e.RowIndex, "default");
                    string sSlabID = clsValidate.ValidateGridValue(dgvDetail, "SlabID", e.RowIndex, "default");

                    if (sID.Length > 0)
                    {
                        //fills the values to controls
                        FillDetails(sID.Trim(), int.Parse(sSlabID.Trim()));
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
        private void Search_Employee()
        {
            try
            {
                clsSearch.Search_MasterEmployee(ref txtEmployeeID);
                if (txtEmployeeID.Tag != null && txtEmployeeID.Tag.ToString().Length > 0 && txtEmployeeID.Text != "default")
                {
                    RefreshGrid_ForSelectedEmployee(txtEmployeeID.Tag.ToString());                   
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        #region Events Key Press
        private void txtFromAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }

        private void txtToAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }

        private void txtCommissionPercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        } 
        #endregion

        #region Events TextChanged
        private void txtEmployeeID_TextChanged(object sender, EventArgs e)
        {
            if (txtEmployeeID.Tag != null)
                sEmployeeID = sEmployeeID.ToString();
        }
        #endregion

        private bool ValidateForDependancies()
        {            
            bool bStatus = true;

            if (txtSlabID.Text.Length > 0)
            {
                if (tbl_sasSalesCommission_Slab.SelectAll().Where(p => p.Employee_ID == sEmployeeID && p.SlabID == int.Parse(txtSlabID.Text)).Count() > 0)
                {
                    bStatus = false;
                    MessageBox.Show("Record Is Locked! \n\n[" + txtSlabID.Text + "] Commission(s) is/are already created for this Commission Slab", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            return bStatus;
        }
    }
}
