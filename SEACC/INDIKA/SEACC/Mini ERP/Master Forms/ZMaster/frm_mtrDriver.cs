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
    public partial class frm_mtrDriver : MettroForm
    {


        #region Form Load
        public frm_mtrDriver()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.ZDriver);
            iFormID = clsSecurity.getFormID(FormName.ZDriver);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frmItemMaster_Load(object sender, EventArgs e)
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
                if (txtDriverID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_zDriver detail = tbl_zDriver.Select(txtDriverID.Text.Trim());
                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " Driver Master " + detail.DriverName), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                        if (msgResult == DialogResult.Yes)
                        {

                            if (detail != null)
                            {
                                detail.Delete();
                                clsHelpMethods.InsertTransactionHistory(iFormID, txtDriverID.Text, TxnActivity.Cancel);
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
                clsValidate.WriteErrorLog("", iFormID,ex);
                Cursor = Cursors.Default;
               SEACCException.Show(ex);
            }
            finally 
            {
                ClearFields();
                RefreshGrid();
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Btn Remove
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetail.SelectedCells.Count != 0)
                {
                    if (dgvDetail.Rows.Count > 1)
                        dgvDetail.Rows.RemoveAt(dgvDetail.SelectedCells[0].RowIndex);
                }
            }
            catch (Exception ex)
            {
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
                            if (txtDriverID.TextLength > 0)
                            {                               
                                if (IsUpdate)  //update records
                                {
                                    tbl_zDriver oldRecord = tbl_zDriver.Select(txtDriverID.Text.Trim());
                                    tbl_genEmployeeMaster oldRecordEmp = tbl_genEmployeeMaster.Select(txtDriverID.Text.Trim());
                                    if (oldRecord != null)
                                    {   
                                        //if (oldRecordEmp != null)
                                        //{
                                        //    tbl_genEmployeeMaster detailEmp = new tbl_genEmployeeMaster(txtDriverID.Text.Trim(), txtDriverName.Text.Trim(), "", "", "", "", "", "", "", clsSecurity.getServerDateTime(), oldRecordEmp.IsSalesManager, oldRecordEmp.IsAreaManager, oldRecordEmp.IsSelesRep, oldRecordEmp.IsSalesExecutive, oldRecordEmp.IsDriver, oldRecordEmp.IsAssistant, oldRecordEmp.IsDelete, oldRecordEmp.EmployeeCostPerHour);
                                        //    detailEmp.Update();
                                        //}
                                        tbl_zDriver detail = new tbl_zDriver(txtDriverID.Text.Trim(), txtDriverName.Text.Trim(), txtNIC.Text.Trim());
                                        detail.Update();
                                        clsHelpMethods.InsertTransactionHistory(iFormID, txtDriverID.Text, TxnActivity.Update);
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else  //insert records
                                {
                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                        txtDriverID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                    tbl_zDriver detail = new tbl_zDriver(txtDriverID.Text.Trim(), txtDriverName.Text.Trim(),txtNIC.Text.Trim());
                                    detail.Insert();
                                    clsHelpMethods.InsertTransactionHistory(iFormID, txtDriverID.Text, TxnActivity.Insert);
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show(" Driver " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDriverID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblDriverID, true);           
           
            txtDriverName.Clear();
            txtNIC.Clear();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtDriverID.Text = "<Auto Generate>";
            else
                txtDriverID.Clear();
            if (txtDriverID.Enabled)
            {
                txtDriverID.SelectAll();
                txtDriverID.Focus();
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

                List<tbl_zDriver> details = tbl_zDriver.SelectAll();
                foreach (tbl_zDriver detail in details)
                {
                    if (detail.Driver_ID.Trim() != "default")
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["CountryID", iRow].Value = detail.Driver_ID;
                        dgvDetail["CountryName", iRow].Value = detail.DriverName;
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
            if (sID.Length > 0)
            {
                tbl_zDriver detail = tbl_zDriver.Select(sID);
                if (detail != null)
                {
                    //set the update flag and Locked
                    IsUpdate = true;
                    clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDriverID, false);                    
                    clsCommon.SetEnableDisable_NormalLabel(lblDriverID, false);                    

                    //asign values
                    txtDriverID.Text = detail.Driver_ID;
                    txtDriverName.Text = detail.DriverName;
                    txtNIC.Text = detail.NicNo;
                }
            }
        }
        #endregion


        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtDriverName.TextLength == 0)
            {
                strMessage += "\n" + "Driver Name ";
                bStatus = false;
            }
            if (txtNIC.TextLength == 0)
            {
                strMessage += "\n" + "NIC No ";
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
        private void txtCountryID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CountryID();
            }   
        }

        private void frm_mtrCountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        } 
        #endregion

        #region Events DoubleClick
        private void txtCountryID_DoubleClick(object sender, EventArgs e)
        {
            Search_CountryID();
        } 
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvDetail["CountryID", e.RowIndex].Value.ToString();
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

        #region Search Methods
        private void Search_CountryID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_DriverID();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    txtDriverID.Text = frmSearchMaster.s_SearchID;
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
