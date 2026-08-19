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
    public partial class frm_mtrEmpSaleseRep : MettroForm
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
        public frm_mtrEmpSaleseRep()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.ZEmpSalesRep);
            iFormID = clsSecurity.getFormID(FormName.ZEmpSalesRep);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_mtrItemCategory_Load(object sender, EventArgs e)
        {
            ThemeColor = clsFormatter.colorMasters;
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
                if (txtSalesRepID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_ZEmpSalesRep detail = tbl_ZEmpSalesRep.Select(txtSalesRepID.Text.Trim());
                        tbl_genEmployeeMaster EmpMasterdetail = tbl_genEmployeeMaster.Select(txtSalesRepID.Text.Trim());
                        

                        if (detail != null && EmpMasterdetail != null)
                        {
                            detail.IsDelete = true;
                            EmpMasterdetail.IsDelete = true;

                            tbl_genStoreMaster StrMasterdetail = tbl_genStoreMaster.Select(txtSalesRepID.Text.Trim());
                            if (StrMasterdetail != null)
                            {
                                StrMasterdetail.IsDeleted = true;
                                StrMasterdetail.Update();
                            }
                            
                            detail.Update();
                            EmpMasterdetail.Update();

                            clsHelpMethods.InsertTransactionHistory(iFormID, txtSalesRepID.Text, TxnActivity.Cancel);
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
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (CheckCheckBoxValidity())
                { 
                if (CheckNumberValidity())
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            if (txtSalesRepID.TextLength > 0)
                            {
                                    if (IsUpdate)  //update records
                                    {
                                        tbl_ZEmpSalesRep oldRecord = tbl_ZEmpSalesRep.Select(txtSalesRepID.Text.Trim());
                                        tbl_genEmployeeMaster oldRecordEmp = tbl_genEmployeeMaster.Select(txtSalesRepID.Text.Trim());
                                        if (oldRecord != null)
                                        {
                                            if (!oldRecord.IsDelete)
                                            {
                                                //Country Header 
                                                if (oldRecordEmp != null)
                                                {
                                                    tbl_genEmployeeMaster detailEmp = new tbl_genEmployeeMaster(txtSalesRepID.Text.Trim(), txtSalesRepName.Text.Trim(), "", "", "", txtTelephone.Text, txtMobil.Text, txtFax.Text, txtEmail.Text, oldRecordEmp.Gl_ID, clsSecurity.getServerDateTime(), oldRecordEmp.IsSalesManager, oldRecordEmp.IsAreaManager, oldRecordEmp.IsSelesRep, oldRecordEmp.IsSalesExecutive, oldRecordEmp.IsDriver, oldRecordEmp.IsAssistant, oldRecordEmp.IsDelete, oldRecordEmp.EmployeeCostPerHour, oldRecordEmp.IsOperator, oldRecordEmp.SalesTarget, oldRecordEmp.CommisionPersentage_Normal, oldRecordEmp.CommisionPersentage_Bones, 0);
                                                    //tbl_genEmployeeMaster detailEmp = new tbl_genEmployeeMaster(txtSalesRepID.Text.Trim(), txtSalesRepName.Text.Trim(), "", "", "", "", "", "", "", oldRecordEmp.Gl_ID, clsSecurity.getServerDateTime(), oldRecordEmp.IsSalesManager, oldRecordEmp.IsAreaManager, oldRecordEmp.IsSelesRep, oldRecordEmp.IsSalesExecutive, oldRecordEmp.IsDriver, oldRecordEmp.IsAssistant, oldRecordEmp.IsDelete, oldRecordEmp.EmployeeCostPerHour, oldRecordEmp.IsOperator, oldRecordEmp.SalesTarget, oldRecordEmp.CommisionPersentage_Normal, oldRecordEmp.CommisionPersentage_Bones,0);
                                                    detailEmp.Update();
                                                }

                                                tbl_ZEmpSalesRep detail = new tbl_ZEmpSalesRep(txtSalesRepID.Text.Trim(), txtSalesRepName.Text.Trim(), txtAreaManagerName.Tag.ToString(), oldRecord.Store_ID, chkIsCollector.Checked, chkIsSalesRep.Checked, false);
                                                detail.Update();

                                                #region Create Store for SalesRep
                                                if (clsConfig.isEnable_CreateStorefor_SalesRep)
                                                {
                                                    tbl_genStoreMaster detailStore = tbl_genStoreMaster.Select(txtSalesRepID.Text.Trim());
                                                    detailStore.StoreName = txtSalesRepName.Text.Trim();
                                                    detailStore.Telephone = txtTelephone.Text.Trim();
                                                    detailStore.Fax = txtFax.Text.Trim();
                                                    detailStore.Update();
                                                }
                                                #endregion
                                                clsHelpMethods.InsertTransactionHistory(iFormID, txtSalesRepID.Text, TxnActivity.Update);
                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                                            }
                                            else
                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyDeleted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else  //insert records
                                    {
                                        if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                            txtSalesRepID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                        //Inquiry Header
                                        tbl_genEmployeeMaster detailEmp = new tbl_genEmployeeMaster(txtSalesRepID.Text.Trim(), txtSalesRepName.Text.Trim(), "", "", "", txtTelephone.Text, txtMobil.Text, txtFax.Text, txtEmail.Text, "default", clsSecurity.getServerDateTime(), false, false, true, false, false, false, false, 0, false, 0, 0, 0, 0);
                                        //tbl_genEmployeeMaster detailEmp = new tbl_genEmployeeMaster(txtSalesRepID.Text.Trim(), txtSalesRepName.Text.Trim(), "", "", "", "", "", "", "", "default", clsSecurity.getServerDateTime(), false, false, true, false, false, false, false, 0,false,0,0,0,0);
                                        detailEmp.Insert();

                                        #region Create Store for SalesRep0
                                        if (clsConfig.isEnable_CreateStorefor_SalesRep)
                                        {
                                            tbl_genStoreMaster detailStore = new tbl_genStoreMaster(1, txtSalesRepID.Text.Trim(), txtSalesRepName.Text.Trim(),
                                               "", txtTelephone.Text.Trim(), txtFax.Text.Trim(), "", false, true, false, false, true, false, false, false, clsSecurity.CompanyID, clsSecurity.BranchID, true, false);
                                            detailStore.Insert();
                                        }
                                        #endregion

                                        tbl_ZEmpSalesRep detail = new tbl_ZEmpSalesRep(txtSalesRepID.Text.Trim(), txtSalesRepName.Text.Trim(), txtAreaManagerName.Tag.ToString(), txtSalesRepID.Text.Trim(), chkIsCollector.Checked, chkIsSalesRep.Checked, false);
                                        detail.Insert();
                                        clsHelpMethods.InsertTransactionHistory(iFormID, txtSalesRepID.Text, TxnActivity.Insert);
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                            }
                            else
                            {
                                MessageBox.Show(" Sales Rep " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat_NewWithWhiteBackground(dgvDetail, clsFormatter.colorGrid, ThemeColor);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtSalesRepID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSalesRepID, true);

            txtAreaManagerName.Tag = null;
            txtAreaManagerName.Clear();
            txtSalesRepName.Clear();
            txtTelephone.Clear();
            txtMobil.Clear();
            txtFax.Clear();
            txtEmail.Clear();

            chkIsCollector.Checked = false;
            chkIsSalesRep.Checked = false;

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtSalesRepID.Text = "<Auto Generate>";
            else
                txtSalesRepID.Clear();
            if (txtSalesRepID.Enabled)
            {
                txtSalesRepID.SelectAll();
                txtSalesRepID.Focus();
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
                List<tbl_ZEmpSalesRep> details = tbl_ZEmpSalesRep.SelectAll();
                foreach (tbl_ZEmpSalesRep detail in details)
                {
                    if (detail.SelesRep_ID.Trim() != "default")
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["SalesRepID", iRow].Value = detail.SelesRep_ID;
                        dgvDetail["SalesRepName", iRow].Value = detail.SelesRepName;
                        dgvDetail["Cancelled", iRow].Value = detail.IsDelete;
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
                    tbl_ZEmpSalesRep detail = tbl_ZEmpSalesRep.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtSalesRepID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblSalesRepID, false);

                        //asign values
                        txtAreaManagerName.Tag = detail.AreaManager_ID;
                        txtAreaManagerName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_AreaManager(detail.AreaManager_ID));
                        txtSalesRepID.Text = detail.SelesRep_ID;
                        txtSalesRepName.Text = detail.SelesRepName;
                        chkIsCollector.Checked = detail.IsCollector;
                        chkIsSalesRep.Checked = detail.IsSalesRep;

                        tbl_genEmployeeMaster detailEmp = tbl_genEmployeeMaster.Select(sID);
                        txtTelephone.Text = detailEmp.Telephone;
                        txtMobil.Text = detailEmp.Mobile;
                        txtFax.Text = detailEmp.Fax;
                        txtEmail.Text = detailEmp.Email;
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

            if (txtSalesRepName.TextLength == 0)
            {
                strMessage += "\n" + "Sales Rep Name ";
                bStatus = false;
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }

        private bool CheckCheckBoxValidity()
        {
            bool bStatus = false;

            if (chkIsCollector.Checked || chkIsSalesRep.Checked)
                bStatus = true;

            if(!bStatus)
                MessageBox.Show("Please select Collector or Sales Rep..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);

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
        private void txtSalesRepID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_SalesRepID();
            }   
        }
        private void frm_mtrSalesRep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtAreaManagerName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_AreaManager();
            }   
        }
        #endregion

        #region Events DoubleClick
        private void txtSalseRepID_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesRepID();
        }

        private void txtAreaManager_DoubleClick(object sender, EventArgs e)
        {
            Search_AreaManager();
        }

        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvDetail["SalesRepID", e.RowIndex].Value.ToString();
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
        private void Search_SalesRepID()
        {
            try
            {
                clsSearch.Search_MasterSalesRep(ref txtSalesRepID);
                if (txtSalesRepID.Tag != null && txtSalesRepID.Tag.ToString().Trim().Length > 0)
                    FillDetails(txtSalesRepID.Tag.ToString());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_AreaManager()
        {
            try
            {
                clsSearch.Search_AreaManager(ref txtAreaManagerName);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
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
