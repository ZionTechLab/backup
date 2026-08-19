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
    public partial class frm_mtrEmpOperator : Form
    {
        
        //to manage update and insert
        static bool IsUpdate = false;

        //to keep form detail       
        string sFormConfigCode;
           public int iFormID;
        public bool bNoAccess;


        #region Form Load
        public frm_mtrEmpOperator()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.zEmpOperator);
            iFormID = clsSecurity.getFormID(FormName.zEmpOperator);
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
                if (txtOperatorID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_zEmpOperator detail = tbl_zEmpOperator.Select(txtOperatorID.Text.Trim());
                        tbl_genEmployeeMaster EmpMasterdetail = tbl_genEmployeeMaster.Select(txtOperatorID.Text.Trim());

                        if (detail != null && EmpMasterdetail != null)
                        {
                            detail.Delete();
                            EmpMasterdetail.Delete();
                            clsHelpMethods.InsertTransactionHistory(iFormID, txtOperatorID.Text, TxnActivity.Cancel);
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
                            if (txtOperatorID.TextLength > 0)
                            {
                                if (IsUpdate)  //update records
                                {

                                    tbl_zEmpOperator oldRecord = tbl_zEmpOperator.Select(txtOperatorID.Text.Trim());
                                    tbl_genEmployeeMaster oldRecordEmp = tbl_genEmployeeMaster.Select(txtOperatorID.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        //Country Header  
                                        if (oldRecordEmp != null)
                                        {
                                            tbl_genEmployeeMaster detailEmp = new tbl_genEmployeeMaster(txtOperatorID.Text.Trim(), txtOperatorName.Text.Trim(), "", "", "", "", "", "", "", oldRecordEmp.Gl_ID, clsSecurity.getServerDateTime(), oldRecordEmp.IsSalesManager, oldRecordEmp.IsAreaManager, oldRecordEmp.IsSelesRep, oldRecordEmp.IsSalesExecutive, oldRecordEmp.IsDriver, oldRecordEmp.IsAssistant, oldRecordEmp.IsDelete, oldRecordEmp.EmployeeCostPerHour, oldRecordEmp.IsOperator, oldRecordEmp.SalesTarget, oldRecordEmp.CommisionPersentage_Normal, oldRecordEmp.CommisionPersentage_Bones,0);
                                            detailEmp.Update();
                                        }
                                        tbl_zEmpOperator detail = new tbl_zEmpOperator(txtOperatorID.Text.Trim(), txtOperatorName.Text.Trim(), txtSupervisorName.Tag.ToString());
                                        detail.Update();
                                        clsHelpMethods.InsertTransactionHistory(iFormID, txtOperatorID.Text, TxnActivity.Update);
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else  //insert records
                                {
                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                        txtOperatorID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                    //Inquiry Header
                                    tbl_genEmployeeMaster detailEmp = new tbl_genEmployeeMaster(txtOperatorID.Text.Trim(), txtOperatorName.Text.Trim(), "", "", "", "", "", "", "", "default", clsSecurity.getServerDateTime(), false, true, false, false, false, false, false, 0,true,0,0,0,0);
                                    detailEmp.Insert();
                                    tbl_zEmpOperator detail = new tbl_zEmpOperator(txtOperatorID.Text.Trim(), txtOperatorName.Text.Trim(), txtSupervisorName.Tag.ToString());
                                    detail.Insert();
                                    clsHelpMethods.InsertTransactionHistory(iFormID, txtOperatorID.Text, TxnActivity.Insert);
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
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtOperatorID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblOperatorID, true);

            txtSupervisorName.Tag = null;
            txtSupervisorName.Clear();
            txtOperatorName.Clear();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtOperatorID.Text = "<Auto Generate>";
            else
                txtOperatorID.Clear();
            if (txtOperatorID.Enabled)
            {
                txtOperatorID.SelectAll();
                txtOperatorID.Focus();
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
                List<tbl_zEmpOperator> details = tbl_zEmpOperator.SelectAll();
                foreach (tbl_zEmpOperator detail in details)
                {
                    if (detail.Operator_ID != "default")
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["ManagerID", iRow].Value = detail.Operator_ID;
                        dgvDetail["ManagerName", iRow].Value = detail.OperatorName;
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
                    tbl_zEmpOperator detail = tbl_zEmpOperator.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtOperatorID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblOperatorID, false);

                        //asign values
                        txtSupervisorName.Tag = detail.Supervisor_ID;
                        txtSupervisorName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_EmpSupervisorName(detail.Supervisor_ID));
                        txtOperatorID.Text = detail.Operator_ID;
                        txtOperatorName.Text = detail.OperatorName;
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
                if (txtSupervisorName.TextLength == 0)
                {
                    strMessage += "\n" + "Supervisor Name ";
                    bStatus = false;
                }
                if (txtOperatorName.TextLength == 0)
                {
                    strMessage += "\n" + "Operator Name ";
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
                clsSearch.Search_MasterEmpOperator(ref txtOperatorID);
                if (txtOperatorID.Tag != null)
                    FillDetails(txtOperatorID.Tag.ToString());
            }   
        }
        private void txtBankName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterEmpSupervisor(ref txtSupervisorName);
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
            clsSearch.Search_MasterEmpOperator(ref txtOperatorID);
            if (txtOperatorID.Tag != null)
                FillDetails(txtOperatorID.Tag.ToString());
        }
        private void txtBankName_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterEmpSupervisor(ref txtSupervisorName);
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
   
        
    }
}
