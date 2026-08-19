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
    public partial class frm_mtrCompanySection : MettroForm
    {

        #region Variables
        //to manage update and insert

        #endregion

        #region Form Load
        public frm_mtrCompanySection()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.CompanySectionMaster);
            iFormID = clsSecurity.getFormID(FormName.CompanySectionMaster);
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
                if (txtCompanySectionID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_genSectionMaster detail = tbl_genSectionMaster.Select(txtCompanySectionID.Text.Trim());
                        if (detail != null)
                        {
                            //detail.Delete();
                            detail.IsDeleted = true;
                            if(detail.Store_ID != null && detail.Store_ID != "default")
                            {
                                tbl_genStoreMaster oSectionStock = tbl_genStoreMaster.Select(detail.Store_ID);
                                if (oSectionStock != null && oSectionStock.Store_ID != "default")
                                    oSectionStock.IsDeleted = true;
                            }
                            clsHelpMethods.InsertTransactionHistory(iFormID, txtCompanySectionID.Text, TxnActivity.Cancel);
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
                            //decimal dSectionCost=0;
                            if (txtCompanySectionID.TextLength > 0)
                            {
                                if (IsUpdate)  //update records
                                {

                                    tbl_genSectionMaster oldRecord = tbl_genSectionMaster.Select(txtCompanySectionID.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        //Country Header
                                        tbl_genSectionMaster detail = new tbl_genSectionMaster(oldRecord.Line_No, txtCompanySectionID.Text.Trim(), txtCompanySectionName.Text.Trim(), txtCompanySection.Tag.ToString(),
                                        txtAddress.Text.Trim(), txtTelephone.Text.Trim(), txtFax.Text.Trim(), txtContactPerson.Text.Trim(), decimal.Parse(txtSectionCost.Text.Trim()), decimal.Parse(txtSectionOverheadRate.Text.Trim()), decimal.Parse(txtSectionCapacity.Text.Trim()), oldRecord.Remark, oldRecord.IsExtrusion, oldRecord.IsBinSection, oldRecord.IsDeleted , oldRecord.Store_ID);
                                        detail.Update();
                                        clsHelpMethods.InsertTransactionHistory(iFormID, txtCompanySectionID.Text, TxnActivity.Update);
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else  //insert records
                                {
                                    //if (txtSectionCost.Text =="" && txtSectionOverheadRate.Text=="" && txtSectionCapacity.Text=="")
                                    //    dSectionCost = 0;
                                    //else
                                    //    dSectionCost = decimal.Parse(txtSectionCost.Text.Trim());
                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                        txtCompanySectionID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                    //Inquiry Header
                                    tbl_genSectionMaster detail = new tbl_genSectionMaster(1, txtCompanySectionID.Text.Trim(), txtCompanySectionName.Text.Trim(), txtCompanySection.Tag.ToString(),
                                       txtAddress.Text.Trim(), txtTelephone.Text.Trim(), txtFax.Text.Trim(), txtContactPerson.Text.Trim(), decimal.Parse(txtSectionCost.Text.Trim()), decimal.Parse(txtSectionOverheadRate.Text.Trim()), decimal.Parse(txtSectionCapacity.Text.Trim()), "", false, false, false , "default");
                                    detail.Insert();
                                    clsHelpMethods.InsertTransactionHistory(iFormID, txtCompanySectionID.Text, TxnActivity.Insert);
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
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCompanySectionID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblBranchD, true);

            txtCompanySection.Tag = null;
            txtCompanySectionID.Clear();
            txtCompanySection.Clear();
            txtCompanySectionName.Clear();
            txtAddress.Clear();
            txtTelephone.Clear();
            txtFax.Clear();
            txtContactPerson.Clear();
            txtSectionCost.Clear();
            txtSectionOverheadRate.Clear();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtCompanySectionID.Text = "<Auto Generate>";
            else
                txtCompanySectionID.Clear();
            if (txtCompanySectionID.Enabled)
            {
                txtCompanySectionID.SelectAll();
                txtCompanySectionID.Focus();
            }
            txtSectionCapacity.Clear();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                List<tbl_genSectionMaster> details = tbl_genSectionMaster.SelectAll();
                foreach (tbl_genSectionMaster detail in details)
                {
                    if (detail.Section_ID.Trim() != "default")
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["CompanySectionID", iRow].Value = detail.Section_ID;
                        dgvDetail["SectionName", iRow].Value = detail.SectionName;
                        dgvDetail["Section", iRow].Value = clsGenaralName.getName_Department(detail.Department_ID);
                        dgvDetail["Telephone", iRow].Value = detail.Telephone;
                        dgvDetail["Fax", iRow].Value = detail.Fax;
                        dgvDetail["ContactPerson", iRow].Value = detail.ContactPerson;
                        dgvDetail["Address", iRow].Value = detail.Adress;
                        dgvDetail["SectionCost", iRow].Value = detail.SectionCost;
                        dgvDetail["OverheadRate", iRow].Value = detail.OverheadRate;
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
                    tbl_genSectionMaster detail = tbl_genSectionMaster.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCompanySectionID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblBranchD, false);
                        //asign values
                        txtCompanySection.Tag = detail.Department_ID;
                        txtCompanySection.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Department(detail.Department_ID));
                        txtCompanySectionID.Text = detail.Section_ID;
                        txtCompanySectionName.Text = detail.SectionName;
                        txtAddress.Text = detail.Adress;
                        txtTelephone.Text = detail.Telephone;
                        txtFax.Text = detail.Fax;
                        txtContactPerson.Text = detail.ContactPerson;
                        txtSectionCost.Text = detail.SectionCost.ToString("0");
                        txtSectionOverheadRate.Text = detail.OverheadRate.ToString("0.00");
                        txtSectionCapacity.Text = detail.Sectioncapacity.ToString("0");
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
                if (txtCompanySection.TextLength == 0)
                {
                    strMessage += "\n" + "Department ID ";
                    bStatus = false;
                }
                if (txtCompanySectionName.TextLength == 0)
                {
                    strMessage += "\n" + "Section Name ";
                    bStatus = false;
                }
                if(txtSectionCost.TextLength==0)
                {
                    strMessage += "\n" + "Section Cost ";
                    bStatus = false;
                }
                if (txtSectionCapacity.TextLength == 0)
                {
                    strMessage += "\n" + "Section Capacity ";
                    bStatus = false;
                }
                if (txtSectionOverheadRate.TextLength == 0)
                {
                    strMessage += "\n" + "Overhead Rate ";
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
                Search_SectionID();
            }
        }
        private void txtCompanyCountryName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_DepatmentID();
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
        private void txtCompanyBranchID_DoubleClick(object sender, EventArgs e)
        {
            Search_SectionID();
        }
        private void txtCountryName_DoubleClick(object sender, EventArgs e)
        {
            Search_DepatmentID();
        }
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0)
                {
                    string sID = dgvDetail["CompanySectionID", e.RowIndex].Value.ToString();
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
        private void txtSectionCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimal(txtSectionCost.Text, e);
        }
        private void txtSectionOverheadRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowInteger(e);
        }
        private void txtSectionCapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimal(txtSectionCapacity.Text, e);
        }

        #endregion

        #region Search Methods
        private void Search_DepatmentID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_CompanyDepartment();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    if (frmSearchMaster.s_SearchText.Length > 0)
                        txtCompanySection.Text = frmSearchMaster.s_SearchText;
                    if (frmSearchMaster.s_SearchID.Length > 0)
                        txtCompanySection.Tag = frmSearchMaster.s_SearchID;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_SectionID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_CompanySection();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    txtCompanySectionID.Text = frmSearchMaster.s_SearchID;
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
