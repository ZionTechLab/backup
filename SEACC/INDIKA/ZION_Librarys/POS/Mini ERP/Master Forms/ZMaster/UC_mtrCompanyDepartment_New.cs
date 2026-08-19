using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Digiteq_Logic;
using DataTire;

namespace Digiteq
{
    public partial class UC_mtrCompanyDepartment_New : SEACC_Form
    {       
        #region Form Load
        public UC_mtrCompanyDepartment_New(FormName _enmForm)
        {           
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }

        private void UC_mtrCompanyDepartment_New_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            CusDataGridViewFormat();
            ClearFields();
        }

        #endregion

        #region Btn New
        private void UC_mtrCompanyDepartment_New_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void UC_mtrCompanyDepartment_New_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCompanyDepatmentID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_genDepartmentMaster detail = tbl_genDepartmentMaster.Select(txtCompanyDepatmentID.Text.Trim());
                        if (detail != null)
                        {
                            detail.Delete();
                            clsHelpMethods.InsertTransactionHistory(iFormID, txtCompanyDepatmentID.Text, TxnActivity.Cancel);
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
        private void UC_mtrCompanyDepartment_New_SF_saveButton_Click(object sender, EventArgs e)
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
                            if (txtCompanyDepatmentID.TextLength > 0)
                            {
                                if (IsUpdate)  //update records
                                {

                                    tbl_genDepartmentMaster oldRecord = tbl_genDepartmentMaster.Select(txtCompanyDepatmentID.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        tbl_genStoreMaster oldStore = tbl_genStoreMaster.Select(txtCompanyDepatmentID.Text.Trim());
                                        if (oldStore != null)
                                        {
                                            tbl_genStoreMaster detailStore = new tbl_genStoreMaster(1, txtCompanyDepatmentID.Text.Trim(), txtCompanyDepatmentName.Text.Trim(), txtAddress.Text.Trim(), txtTelephone.Text.Trim(), txtFax.Text.Trim(), txtContactPerson.Text.Trim(),
                                            oldStore.IsDamagedStore, oldStore.IsSingleItemStockStore, oldStore.IsMainStore, oldStore.IsTradingStore, oldStore.IsSalesRepStore, oldStore.IsShowRoom, oldStore.IsDepartment, oldStore.IsDeleted, oldStore.CompanyID, oldStore.CompanyBranch_ID, oldStore.IsAllowMinusStock , oldStore.IsSubContractorStore);
                                            detailStore.Update();
                                        }
                                        else
                                        {
                                            tbl_genStoreMaster detailStore = new tbl_genStoreMaster(1, txtCompanyDepatmentID.Text.Trim(), txtCompanyDepatmentName.Text.Trim(), txtAddress.Text.Trim(), txtTelephone.Text.Trim(), txtFax.Text.Trim(), txtContactPerson.Text.Trim(),
                                            false, false, false, false, false, false, true, false, clsSecurity.CompanyID, clsSecurity.BranchID, false , false);
                                            detailStore.Insert();
                                        }

                                        //Country Header
                                        tbl_genDepartmentMaster detail = new tbl_genDepartmentMaster(txtCompanyDepatmentID.Text.Trim(), txtCompanyDepatmentName.Text.Trim(), txtCompanyDiviton.Tag.ToString(), txtCompanyDepatmentID.Text.Trim(),
                                        txtAddress.Text.Trim(), txtTelephone.Text.Trim(), txtFax.Text.Trim(), txtContactPerson.Text.Trim());
                                        detail.Update();

                                        clsHelpMethods.InsertTransactionHistory(iFormID, txtCompanyDepatmentID.Text, TxnActivity.Update);
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else  //insert records
                                {
                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                        txtCompanyDepatmentID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                    // For fixed assets
                                    tbl_genStoreMaster detailStore = new tbl_genStoreMaster(1, txtCompanyDepatmentID.Text.Trim(), txtCompanyDepatmentName.Text.Trim(), txtAddress.Text.Trim(), txtTelephone.Text.Trim(), txtFax.Text.Trim(), txtContactPerson.Text.Trim(),
                                        false, false, false, false, false, false, true, false, clsSecurity.CompanyID, clsSecurity.BranchID, false , false);
                                    detailStore.Insert();

                                    //Inquiry Header
                                    tbl_genDepartmentMaster detail = new tbl_genDepartmentMaster(txtCompanyDepatmentID.Text.Trim(), txtCompanyDepatmentName.Text.Trim(), txtCompanyDiviton.Tag.ToString(), txtCompanyDepatmentID.Text.Trim(),
                                       txtAddress.Text.Trim(), txtTelephone.Text.Trim(), txtFax.Text.Trim(), txtContactPerson.Text.Trim());
                                    detail.Insert();
                                    clsHelpMethods.InsertTransactionHistory(iFormID, txtCompanyDepatmentID.Text, TxnActivity.Insert);
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show(" Division " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCompanyDepatmentID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblBranchD, true);

            txtCompanyDiviton.Tag = null;
            txtCompanyDepatmentID.Clear();
            txtCompanyDiviton.Clear();
            txtCompanyDepatmentName.Clear();
            txtAddress.Clear();
            txtTelephone.Clear();
            txtFax.Clear();
            txtContactPerson.Clear();

            #region Button Hide
            btnChecked.Visible = false;
            btnApproved.Visible = false;
            btnPrint.Visible = false;
            btnUserDetails.Visible = false;
            Attachments.Visible = false;
            #endregion

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtCompanyDepatmentID.Text = "<Auto Generate>";
            else
                txtCompanyDepatmentID.Clear();
            if (txtCompanyDepatmentID.Enabled)
            {
                txtCompanyDepatmentID.SelectAll();
                txtCompanyDepatmentID.Focus();
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
                List<tbl_genDepartmentMaster> details = tbl_genDepartmentMaster.SelectAll();
                foreach (tbl_genDepartmentMaster detail in details)
                {
                    if (detail.Department_ID.Trim() != "default")
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["DepartmentID", iRow].Value = detail.Department_ID;
                        dgvDetail["DepartmentName", iRow].Value = detail.DepartmentName;
                        dgvDetail["DivisionName", iRow].Value = clsGenaralName.getName_CompanyDivision(detail.Division_ID);
                        dgvDetail["Telephone", iRow].Value = detail.Telephone;
                        dgvDetail["Fax", iRow].Value = detail.Fax;
                        dgvDetail["ContactPerson", iRow].Value = detail.ContactPerson;
                        dgvDetail["Address", iRow].Value = detail.Adress;
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
                    tbl_genDepartmentMaster detail = tbl_genDepartmentMaster.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCompanyDepatmentID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblBranchD, false);

                        //asign values
                        txtCompanyDiviton.Tag = detail.Division_ID;
                        txtCompanyDiviton.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_CompanyDivision(detail.Division_ID));
                        txtCompanyDepatmentID.Text = detail.Department_ID;
                        txtCompanyDepatmentName.Text = detail.DepartmentName;
                        txtAddress.Text = detail.Adress;
                        txtTelephone.Text = detail.Telephone;
                        txtFax.Text = detail.Fax;
                        txtContactPerson.Text = detail.ContactPerson;
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
                if (txtCompanyDiviton.TextLength == 0)
                {
                    strMessage += "\n" + "Company Division ";
                    bStatus = false;
                }
                if (txtCompanyDepatmentName.TextLength == 0)
                {
                    strMessage += "\n" + "Department Name ";
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
        private void txtCompanyDepatmentID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_DepatmentID();
            } 
        }

        private void txtCompanyDiviton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CompanyDivision();
            } 
        }

        private void UC_mtrCompanyDepartment_New_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtCompanyDepatmentID_DoubleClick(object sender, EventArgs e)
        {
            Search_DepatmentID();
        }

        private void txtCompanyDiviton_DoubleClick(object sender, EventArgs e)
        {
            Search_CompanyDivision();
        }

        private void txtTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowIntegerAndPlus(e);
        }

        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowIntegerAndPlus(e);
        }
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvDetail["DepartmentID", e.RowIndex].Value.ToString();
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
        private void Search_CompanyDivision()
        {
            #region Old
            //try
            //{
            //    Form frmhelpsearch = new frmSearchMaster();
            //    clsSearch.passValue_CompanyDivision();
            //    frmhelpsearch.ShowDialog();

            //    if (frmSearchMaster.s_SearchID.Length > 0)
            //    {
            //        if (frmSearchMaster.s_SearchText.Length > 0)
            //            txtCompanyDiviton.Text = frmSearchMaster.s_SearchText;
            //        if (frmSearchMaster.s_SearchID.Length > 0)
            //            txtCompanyDiviton.Tag = frmSearchMaster.s_SearchID;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    clsValidate.WriteErrorLog("", iFormID,ex);
            //    SEACCException.Show(ex);
            //} 
            #endregion

            clsSearch.Search_MasterDivision(ref txtCompanyDiviton);
        }
        private void Search_DepatmentID()
        {
            #region Old
            //try
            //{
            //    Form frmhelpsearch = new frmSearchMaster();
            //    clsSearch.passValue_CompanyDepartment();
            //    frmhelpsearch.ShowDialog();

            //    if (frmSearchMaster.s_SearchID.Length > 0)
            //    {
            //        txtCompanyDepatmentID.Text = frmSearchMaster.s_SearchID;
            //        FillDetails(frmSearchMaster.s_SearchID);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    clsValidate.WriteErrorLog("", iFormID,ex);
            //    SEACCException.Show(ex);
            //} 
            #endregion

            clsSearch.Search_MasterStoreDepartment(ref txtCompanyDepatmentID);
        }
        #endregion
    }
}
