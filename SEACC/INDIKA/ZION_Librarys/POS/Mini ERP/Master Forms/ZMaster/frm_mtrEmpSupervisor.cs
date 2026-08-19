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
    public partial class frm_mtrEmpSupervisor : Form
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
        public frm_mtrEmpSupervisor()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.zEmpSupervisor);
            iFormID = clsSecurity.getFormID(FormName.zEmpSupervisor);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_mtrBank_Load(object sender, EventArgs e)
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
                if (txtSupervisorID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_zEmpSupervisor detail = tbl_zEmpSupervisor.Select(txtSupervisorID.Text.Trim());
                        tbl_genEmployeeMaster EmpMasterdetail = tbl_genEmployeeMaster.Select(txtSupervisorID.Text.Trim());

                        if (detail != null && EmpMasterdetail != null)
                        {
                            //detail.Delete();
                            EmpMasterdetail.IsDelete = true;
                            EmpMasterdetail.Update();
                            clsHelpMethods.InsertTransactionHistory(iFormID, txtSupervisorID.Text, TxnActivity.Cancel);
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
                            if (txtSupervisorID.TextLength > 0)
                            {
                                if (IsUpdate)  //update records
                                {
                                    tbl_zEmpSupervisor oldRecord = tbl_zEmpSupervisor.Select(txtSupervisorID.Text.Trim());
                                    tbl_genEmployeeMaster oldRecordEmp = tbl_genEmployeeMaster.Select(txtSupervisorID.Text.Trim());
                                    if (oldRecord != null && oldRecordEmp != null)
                                    {
                                        if (!oldRecordEmp.IsDelete)
                                        {
                                            //if (oldRecordEmp != null)
                                            //{
                                            tbl_genEmployeeMaster detailEmp = new tbl_genEmployeeMaster(txtSupervisorID.Text.Trim(), txtSupervisorName.Text.Trim(), "", "", "", "", "", "", "", oldRecordEmp.Gl_ID, clsSecurity.getServerDateTime(), oldRecordEmp.IsSalesManager, oldRecordEmp.IsAreaManager, oldRecordEmp.IsSelesRep, oldRecordEmp.IsSalesExecutive, oldRecordEmp.IsDriver, oldRecordEmp.IsAssistant, oldRecordEmp.IsDelete, oldRecordEmp.EmployeeCostPerHour, oldRecordEmp.IsOperator, oldRecordEmp.SalesTarget, oldRecordEmp.CommisionPersentage_Normal, oldRecordEmp.CommisionPersentage_Bones, 0);
                                            detailEmp.Update();
                                            //}
                                            tbl_zEmpSupervisor detail = new tbl_zEmpSupervisor(txtSupervisorID.Text.Trim(), txtSupervisorName.Text.Trim());
                                            detail.Update();
                                            clsHelpMethods.InsertTransactionHistory(iFormID, txtSupervisorID.Text, TxnActivity.Update);
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyDeleted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else  //insert records
                                {
                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                        txtSupervisorID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                    //Inquiry Header
                                    tbl_genEmployeeMaster detailEmp = new tbl_genEmployeeMaster(txtSupervisorID.Text.Trim(), txtSupervisorName.Text.Trim(), "", "", "", "", "", "", "", "default", clsSecurity.getServerDateTime(), true, false, false, false, false, false, false, 0, false, 0, 0, 0, 0);
                                    detailEmp.Insert();
                                    tbl_zEmpSupervisor detail = new tbl_zEmpSupervisor(txtSupervisorID.Text.Trim(), txtSupervisorName.Text.Trim());
                                    detail.Insert();
                                    clsHelpMethods.InsertTransactionHistory(iFormID, txtSupervisorID.Text, TxnActivity.Insert);
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show(" Supervisor " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtSupervisorID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblBankID, true);

            txtSupervisorName.Clear();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtSupervisorID.Text = "<Auto Generate>";
            else
                txtSupervisorID.Clear();
            if (txtSupervisorID.Enabled)
            {
                txtSupervisorID.SelectAll();
                txtSupervisorID.Focus();
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
                List<tbl_zEmpSupervisor> details = tbl_zEmpSupervisor.SelectAll();
                foreach (tbl_zEmpSupervisor detail in details)
                {
                    if (detail.Supervisor_ID != "default")
                    {
                        tbl_genEmployeeMaster oldRecordEmp = tbl_genEmployeeMaster.Select(detail.Supervisor_ID);
                        if (oldRecordEmp != null)
                        {
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            dgvDetail["BankID", iRow].Value = detail.Supervisor_ID;
                            dgvDetail["BankName", iRow].Value = detail.SupervisorName;
                            dgvDetail["Cancelled", iRow].Value = oldRecordEmp.IsDelete;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
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
                    tbl_zEmpSupervisor detail = tbl_zEmpSupervisor.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtSupervisorID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblBankID, false);

                        //asign values
                        txtSupervisorID.Text = detail.Supervisor_ID;
                        txtSupervisorName.Text = detail.SupervisorName;
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

            if (txtSupervisorName.TextLength == 0)
            {
                strMessage += "\n" + "Supervisor Name ";
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
        private void txtSupervisorID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterEmpSupervisor(ref txtSupervisorID);
                if (txtSupervisorID.Tag != null)
                    FillDetails(txtSupervisorID.Tag.ToString());
            }   
        }
        private void frm_mtrSupervisor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtSupervisorID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterEmpSupervisor(ref txtSupervisorID);
            if (txtSupervisorID.Tag != null)
                FillDetails(txtSupervisorID.Tag.ToString());
        }
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvDetail["BankID", e.RowIndex].Value.ToString();
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

        private void dgvDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (bool.Parse(dgvDetail.Rows[e.RowIndex].Cells[2].Value.ToString()))
            {
                dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = new DataGridViewCellStyle { ForeColor = Color.Red };
            }
            else
            {
                dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = dgvDetail.DefaultCellStyle;
            }
        }
    }
}
