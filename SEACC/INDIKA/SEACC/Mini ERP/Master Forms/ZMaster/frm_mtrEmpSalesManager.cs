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
    public partial class frm_mtrEmpSalesManager : MettroForm
    {


        #region Form Load
        public frm_mtrEmpSalesManager()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.ZEmpSalesManager);
            iFormID = clsSecurity.getFormID(FormName.ZEmpSalesManager);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_mtrEmpSalesManager_Load(object sender, EventArgs e)
        {
            //add data to the datagrid and format
            RefreshGrid();
            CusDataGridViewFormat();
            ClearFields();
        }

        //private void frm_mtrBank_Load(object sender, EventArgs e)
        //{
        //    //add data to the datagrid and format
        //    RefreshGrid();
        //    CusDataGridViewFormat();
        //    ClearFields();
        //}
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
                if (txtSalesManagerID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_ZEmpSalesManager detail = tbl_ZEmpSalesManager.Select(txtSalesManagerID.Text.Trim());
                        tbl_genEmployeeMaster EmpMasterdetail = tbl_genEmployeeMaster.Select(txtSalesManagerID.Text.Trim());
                        if (detail != null && EmpMasterdetail != null)
                        {
                            detail.Delete();
                            EmpMasterdetail.Delete();
                            clsHelpMethods.InsertTransactionHistory(iFormID, txtSalesManagerID.Text, TxnActivity.Cancel);
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
                            if (txtSalesManagerID.TextLength > 0)
                            {
                                if (IsUpdate)  //update records
                                {
                                    tbl_ZEmpSalesManager oldRecord = tbl_ZEmpSalesManager.Select(txtSalesManagerID.Text.Trim());
                                    tbl_genEmployeeMaster oldRecordEmp = tbl_genEmployeeMaster.Select(txtSalesManagerID.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        //Country Header
                                        if (oldRecordEmp != null)
                                        {
                                            tbl_genEmployeeMaster detailEmp = new tbl_genEmployeeMaster(txtSalesManagerID.Text.Trim(), txtManagerName.Text.Trim(), "", "", "", "", "", "", "", oldRecordEmp.Gl_ID, clsSecurity.getServerDateTime(), oldRecordEmp.IsSalesManager, oldRecordEmp.IsAreaManager, oldRecordEmp.IsSelesRep, oldRecordEmp.IsSalesExecutive, oldRecordEmp.IsDriver, oldRecordEmp.IsAssistant, oldRecordEmp.IsDelete, oldRecordEmp.EmployeeCostPerHour, oldRecordEmp.IsOperator, oldRecordEmp.SalesTarget, oldRecordEmp.CommisionPersentage_Normal, oldRecordEmp.CommisionPersentage_Bones,0);
                                            detailEmp.Update();
                                        }
                                        tbl_ZEmpSalesManager detail = new tbl_ZEmpSalesManager(txtSalesManagerID.Text.Trim(), txtManagerName.Text.Trim());
                                        detail.Update();
                                        clsHelpMethods.InsertTransactionHistory(iFormID, txtSalesManagerID.Text, TxnActivity.Update);
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else  //insert records
                                {
                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                        txtSalesManagerID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                    //Inquiry Header
                                    tbl_genEmployeeMaster detailEmp = new tbl_genEmployeeMaster(txtSalesManagerID.Text.Trim(), txtManagerName.Text.Trim(), "", "", "", "", "", "", "", "default", clsSecurity.getServerDateTime(), true, false, false, false, false, false, false, 0,false,0,0,0,0);
                                    detailEmp.Insert();
                                    tbl_ZEmpSalesManager detail = new tbl_ZEmpSalesManager(txtSalesManagerID.Text.Trim(), txtManagerName.Text.Trim());
                                    detail.Insert();
                                    clsHelpMethods.InsertTransactionHistory(iFormID, txtSalesManagerID.Text, TxnActivity.Insert);
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show(" Sales Manager " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtSalesManagerID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblBankID, true);

            txtManagerName.Clear();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtSalesManagerID.Text = "<Auto Generate>";
            else
                txtSalesManagerID.Clear();
            if (txtSalesManagerID.Enabled)
            {
                txtSalesManagerID.SelectAll();
                txtSalesManagerID.Focus();
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
                List<tbl_ZEmpSalesManager> details = tbl_ZEmpSalesManager.SelectAll();

                foreach (tbl_ZEmpSalesManager detail in details)
                {
                    if (detail.SalesManager_ID.Trim() != "default")
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["ManagerID", iRow].Value = detail.SalesManager_ID;
                        dgvDetail["ManagerName", iRow].Value = detail.SalesManagerName;
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
                    tbl_ZEmpSalesManager detail = tbl_ZEmpSalesManager.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtSalesManagerID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblBankID, false);

                        //asign values
                        txtSalesManagerID.Text = detail.SalesManager_ID;
                        txtManagerName.Text = detail.SalesManagerName;
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

            if (txtManagerName.TextLength == 0)
            {
                strMessage += "\n" + "Sales Manager Name ";
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
        private void txtSalesManagerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_SalesManagerID();
            }   
        }        
        private void frm_mtrsalesManager_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtSalesManagerID_DoubleClick(object sender, EventArgs e)
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
        private void Search_SalesManagerID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_SalesManager();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    txtSalesManagerID.Text = frmSearchMaster.s_SearchID;
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
