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
    public partial class frm_mtrEmpSalesExecutivecs : MettroForm
    {


        #region Form Load
        public frm_mtrEmpSalesExecutivecs()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.ZEmpSalesExecutive);
            iFormID = clsSecurity.getFormID(FormName.ZEmpSalesExecutive);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_mtrItemType_Load(object sender, EventArgs e)
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
                if (txtExecutiveID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_ZEmpSalesExecutive detail = tbl_ZEmpSalesExecutive.Select(txtExecutiveID.Text.Trim());
                        tbl_genEmployeeMaster EmpMasterdetail = tbl_genEmployeeMaster.Select(txtExecutiveID.Text.Trim());
                        if (detail != null && EmpMasterdetail != null)
                        {
                            detail.Delete();
                            EmpMasterdetail.Delete();
                            clsHelpMethods.InsertTransactionHistory(iFormID, txtExecutiveID.Text, TxnActivity.Cancel);
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
                            if (txtExecutiveID.TextLength > 0)
                            {
                                if (IsUpdate)  //update records
                                {
                                    tbl_ZEmpSalesExecutive oldRecord = tbl_ZEmpSalesExecutive.Select(txtExecutiveID.Text.Trim());
                                    tbl_genEmployeeMaster oldRecordEmp = tbl_genEmployeeMaster.Select(txtExecutiveID.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        //Country Header 
                                        if (oldRecordEmp != null)
                                        {
                                            tbl_genEmployeeMaster detailEmp = new tbl_genEmployeeMaster(txtExecutiveID.Text.Trim(), txtExecutiveName.Text.Trim(), "", "", "", "", "", "", "", oldRecordEmp.Gl_ID, clsSecurity.getServerDateTime(), oldRecordEmp.IsSalesManager, oldRecordEmp.IsAreaManager, oldRecordEmp.IsSelesRep, oldRecordEmp.IsSalesExecutive, oldRecordEmp.IsDriver, oldRecordEmp.IsAssistant, oldRecordEmp.IsDelete, oldRecordEmp.EmployeeCostPerHour, oldRecordEmp.IsOperator, oldRecordEmp.SalesTarget,oldRecordEmp.CommisionPersentage_Normal,oldRecordEmp.CommisionPersentage_Normal,0);
                                            detailEmp.Update();
                                        }
                                        tbl_ZEmpSalesExecutive detail = new tbl_ZEmpSalesExecutive(txtExecutiveID.Text.Trim(), txtExecutiveName.Text.Trim(), txtAreaManagerName.Tag.ToString());
                                        detail.Update();
                                        clsHelpMethods.InsertTransactionHistory(iFormID, txtExecutiveID.Text, TxnActivity.Update);
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else  //insert records
                                {
                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                        txtExecutiveID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                    //Inquiry Header
                                    tbl_genEmployeeMaster detailEmp = new tbl_genEmployeeMaster(txtExecutiveID.Text.Trim(), txtExecutiveName.Text.Trim(), "", "", "", "", "", "", "", "default", clsSecurity.getServerDateTime(), false, false, false, true, false, false, false, 0, false, 0, 0, 0,0);
                                    detailEmp.Insert();
                                    tbl_ZEmpSalesExecutive detail = new tbl_ZEmpSalesExecutive(txtExecutiveID.Text.Trim(), txtExecutiveName.Text.Trim(), txtAreaManagerName.Tag.ToString());                               
                                    detail.Insert();
                                    clsHelpMethods.InsertTransactionHistory(iFormID, txtExecutiveID.Text, TxnActivity.Insert);
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show(" Sales Executive " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtExecutiveID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSupplierTypeID, true);

            txtAreaManagerName.Tag = null;
            txtAreaManagerName.Clear();
            txtExecutiveName.Clear();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtExecutiveID.Text = "<Auto Generate>";
            else
                txtExecutiveID.Clear();
              

            if (txtExecutiveID.Enabled)
            {
                txtExecutiveID.SelectAll();
                txtExecutiveID.Focus();
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
                List<tbl_ZEmpSalesExecutive> details = tbl_ZEmpSalesExecutive.SelectAll();
                foreach (tbl_ZEmpSalesExecutive detail in details)
                {
                    if (detail.SalesExecutive_ID.Trim() != "default")
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["SalesExecutiveID", iRow].Value = detail.SalesExecutive_ID;
                        dgvDetail["SalesExecutiveName", iRow].Value = detail.SalesExecutiveName;
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
                    tbl_ZEmpSalesExecutive detail = tbl_ZEmpSalesExecutive.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtExecutiveID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblSupplierTypeID, false);

                        //asign values
                        txtAreaManagerName.Tag = detail.AreaManager_ID;
                        txtAreaManagerName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_AreaManager(detail.AreaManager_ID));
                        txtExecutiveID.Text = detail.SalesExecutive_ID;
                        txtExecutiveName.Text = detail.SalesExecutiveName;
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

                if (txtAreaManagerName.TextLength == 0)
                {
                    strMessage += "\n" + " Area Manager Name ";
                    bStatus = false;
                }
                if (txtExecutiveName.TextLength == 0)
                {
                    strMessage += "\n" + "Sales Executive Name ";
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
        private void txtSalesExective_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_SalesExecutiveID();
            }   
        }
        private void frm_mtrSalesExectivee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtAreaManager_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1)
            {
                Search_AreaManagerID();
            } 
        }
        #endregion

        #region Events DoubleClick

        private void txtSalseEexcutive_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesExecutiveID();
        }

        private void txtAreaManager_DoubleClick(object sender, EventArgs e)
        {
            Search_AreaManagerID();
        }
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvDetail["SalesExecutiveID", e.RowIndex].Value.ToString();
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
        private void Search_SalesExecutiveID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_SalesExecutive();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    txtExecutiveID.Text = frmSearchMaster.s_SearchID;
                    FillDetails(frmSearchMaster.s_SearchID);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        private void Search_AreaManagerID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_AreaManager();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    if (frmSearchMaster.s_SearchText.Length > 0)
                        txtAreaManagerName.Text = frmSearchMaster.s_SearchText;
                    if (frmSearchMaster.s_SearchID.Length > 0)
                        txtAreaManagerName.Tag = frmSearchMaster.s_SearchID;
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
