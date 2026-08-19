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
    public partial class frm_mtrEmpAreaManager : MettroForm
    {


        #region Form Load
        public frm_mtrEmpAreaManager()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.ZEmpAreaManager);
            iFormID = clsSecurity.getFormID(FormName.ZEmpAreaManager);
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
                if (txtAreaManagerID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_ZEmpAreaManager detail = tbl_ZEmpAreaManager.Select(txtAreaManagerID.Text.Trim());
                        tbl_genEmployeeMaster EmpMasterdetail = tbl_genEmployeeMaster.Select(txtAreaManagerID.Text.Trim());

                        if (detail != null && EmpMasterdetail != null)
                        {
                            detail.Delete();
                            EmpMasterdetail.Delete();
                            clsHelpMethods.InsertTransactionHistory(iFormID, txtAreaManagerID.Text, TxnActivity.Cancel);
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
                            if (txtAreaManagerID.TextLength > 0)
                            {
                                if (IsUpdate)  //update records
                                {

                                    tbl_ZEmpAreaManager oldRecord = tbl_ZEmpAreaManager.Select(txtAreaManagerID.Text.Trim());
                                    tbl_genEmployeeMaster oldRecordEmp = tbl_genEmployeeMaster.Select(txtAreaManagerID.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        //Country Header  
                                        if (oldRecordEmp != null)
                                        {
                                            tbl_genEmployeeMaster detailEmp = new tbl_genEmployeeMaster(txtAreaManagerID.Text.Trim(), txtAreaManagerName.Text.Trim(), "", "", "", "", "", "", "", oldRecordEmp.Gl_ID, clsSecurity.getServerDateTime(), oldRecordEmp.IsSalesManager, oldRecordEmp.IsAreaManager, oldRecordEmp.IsSelesRep, oldRecordEmp.IsSalesExecutive, oldRecordEmp.IsDriver, oldRecordEmp.IsAssistant, oldRecordEmp.IsDelete, oldRecordEmp.EmployeeCostPerHour, oldRecordEmp.IsOperator, oldRecordEmp.SalesTarget, oldRecordEmp.CommisionPersentage_Normal, oldRecordEmp.CommisionPersentage_Bones,0);
                                            detailEmp.Update();
                                        }
                                        tbl_ZEmpAreaManager detail = new tbl_ZEmpAreaManager(txtAreaManagerID.Text.Trim(), txtAreaManagerName.Text.Trim(), txtSalesManagerName.Tag.ToString());
                                        detail.Update();
                                        clsHelpMethods.InsertTransactionHistory(iFormID, txtAreaManagerID.Text, TxnActivity.Update);
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else  //insert records
                                {
                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                        txtAreaManagerID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                    //Inquiry Header
                                    tbl_genEmployeeMaster detailEmp = new tbl_genEmployeeMaster(txtAreaManagerID.Text.Trim(), txtAreaManagerName.Text.Trim(), "", "", "", "", "", "", "", "default", clsSecurity.getServerDateTime(), false, true, false, false, false, false, false, 0,false,0,0,0,0);
                                    detailEmp.Insert();
                                    tbl_ZEmpAreaManager detail = new tbl_ZEmpAreaManager(txtAreaManagerID.Text.Trim(), txtAreaManagerName.Text.Trim(), txtSalesManagerName.Tag.ToString());
                                    detail.Insert();
                                    clsHelpMethods.InsertTransactionHistory(iFormID, txtAreaManagerID.Text, TxnActivity.Insert);
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Branch " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAreaManagerID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblAreaManagerID, true);

            txtSalesManagerName.Tag = null;
            txtSalesManagerName.Clear();
            txtAreaManagerName.Clear();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtAreaManagerID.Text = "<Auto Generate>";
            else
                txtAreaManagerID.Clear();
            if (txtAreaManagerID.Enabled)
            {
                txtAreaManagerID.SelectAll();
                txtAreaManagerID.Focus();
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
                List<tbl_ZEmpAreaManager> details = tbl_ZEmpAreaManager.SelectAll();
                foreach (tbl_ZEmpAreaManager detail in details)
                {
                    if (detail.AreaManager_ID != "default")
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["ManagerID", iRow].Value = detail.AreaManager_ID;
                        dgvDetail["ManagerName", iRow].Value = detail.AreaManagerName;
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
                    tbl_ZEmpAreaManager detail = tbl_ZEmpAreaManager.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAreaManagerID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblAreaManagerID, false);

                        //asign values
                        txtSalesManagerName.Tag = detail.SalesManager_ID;
                        txtSalesManagerName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesManager(detail.SalesManager_ID));
                        txtAreaManagerID.Text = detail.AreaManager_ID;
                        txtAreaManagerName.Text = detail.AreaManagerName;
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
                if (txtSalesManagerName.TextLength == 0)
                {
                    strMessage += "\n" + "Sales Manager Name ";
                    bStatus = false;
                }
                if (txtAreaManagerName.TextLength == 0)
                {
                    strMessage += "\n" + "Area Manager Name ";
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
        private void txtBranchID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_AreaManagerID();
            }   
        }
        private void txtBankName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_SalesManagerID();
            } 
        }
        private void frm_mtrBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtBranchID_DoubleClick(object sender, EventArgs e)
        {
            Search_AreaManagerID();
        }
        private void txtBankName_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesManagerID();
        }
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvDetail["ManagerID", e.RowIndex].Value.ToString();
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
        private void Search_AreaManagerID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_AreaManager();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    txtAreaManagerID.Text = frmSearchMaster.s_SearchID;
                    FillDetails(frmSearchMaster.s_SearchID);
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_SalesManagerID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_SalesManager();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtSalesManagerName.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                    txtSalesManagerName.Tag = frmSearchMaster.s_SearchID;
            }
        }
        #endregion
        
    }
}
