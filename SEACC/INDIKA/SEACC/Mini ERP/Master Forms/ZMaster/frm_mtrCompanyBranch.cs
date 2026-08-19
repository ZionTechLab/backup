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
    public partial class frm_mtrCompanyBranch : SEACC_Form
    {
        



        #region Form Load
        public frm_mtrCompanyBranch(FormName _enmForm)
        {
            //sFormConfigCode = clsAutocode.getFormConfigCode(FormName.CompanyBranchMaster);
            //iFormID = clsSecurity.getFormID(FormName.CompanyBranchMaster);
            //if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            //{
            //    bNoAccess = true;
            //}
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }

        private void frm_mtrBranch_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(false, false, false, true, false, false, false, false, false);

            //add data to the datagrid and format
            RefreshGrid();
            CusDataGridViewFormat();
            ClearFields();
        }
        #endregion

        #region Btn New
        private void frm_mtrCompanyBranch_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void frm_mtrCompanyBranch_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCompanyBranchID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_genCompanyBranchMaster detail = tbl_genCompanyBranchMaster.Select(txtCompanyBranchID.Text.Trim());
                        if (detail != null)
                        {
                            detail.Delete();
                            clsHelpMethods.InsertTransactionHistory(iFormID, txtCompanyBranchID.Text, TxnActivity.Cancel);
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
        private void frm_mtrCompanyBranch_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (CheckNumberValidity())
                {
                   if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                    {
                        try
                        {
                            int lineNo = int.Parse( txtLineNo.Text.Trim());
                            int iShortOrder = txtShortOrder.Text.Length > 0 ?int.Parse(txtShortOrder.Text.Trim()):0;
                            Cursor = Cursors.WaitCursor;
                            if (txtCompanyBranchID.TextLength > 0)
                            {
                                if (IsUpdate)  //update records
                                {
                                    
                                    tbl_genCompanyBranchMaster oldRecord = tbl_genCompanyBranchMaster.Select(txtCompanyBranchID.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        //Country Header
                                        tbl_genCompanyBranchMaster detail = new tbl_genCompanyBranchMaster(lineNo, txtCompanyBranchID.Text.Trim(), txtBranchName.Text.Trim(), txtCompanyCountry.Tag.ToString(),
                                        txtAddress.Text.Trim(), txtTelephone.Text.Trim(), txtFax.Text.Trim(), txtHotline.Text.Trim(), txtEmail.Text.Trim(), txtWebSite.Text.Trim(), txtContactPerson.Text.Trim(), iShortOrder,
                                        oldRecord.Prefix, oldRecord.Counter, oldRecord.Length,
                                        oldRecord.COprefix, oldRecord.COcounter, oldRecord.COlength, oldRecord.DOprefix, oldRecord.DOcounter, oldRecord.DOlength, oldRecord.Invprefix, oldRecord.Invcounter, oldRecord.Invlength,
                                        oldRecord.CRprefix, oldRecord.CRcounter, oldRecord.CRlength, oldRecord.DRprefix, oldRecord.DRcounter, oldRecord.DRlength, oldRecord.SRprefix, oldRecord.SRcounter, oldRecord.SRlength,
                                        oldRecord.CUSprefix, oldRecord.CUScounter, oldRecord.CUSlength, oldRecord.SUPprefix, oldRecord.SUPcounter, oldRecord.SUPlength, oldRecord.SRTprefix, oldRecord.SRTcounter, oldRecord.SRTlength,
                                        oldRecord.IGRNprefix, oldRecord.IGRNcounter, oldRecord.IGRNlength, oldRecord.IGINprefix, oldRecord.IGINcounter, oldRecord.IGINlength, oldRecord.ReceiptPrefix, oldRecord.ReceiptCounter, oldRecord.ReceiptLength, oldRecord.PosPrefix, oldRecord.PosCounter, oldRecord.PosLength,oldRecord.PosReciptPrefix,oldRecord.PosReciptCounter,oldRecord.PosReciptLength, chkIsHeadOffice.Checked);
                                        detail.Update();
                                        clsHelpMethods.InsertTransactionHistory(iFormID, txtCompanyBranchID.Text, TxnActivity.Update);
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else  //insert records
                                {
                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                        txtCompanyBranchID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                    //Inquiry Header
                                    tbl_genCompanyBranchMaster detail = new tbl_genCompanyBranchMaster(lineNo, txtCompanyBranchID.Text.Trim(), txtBranchName.Text.Trim(), txtCompanyCountry.Tag.ToString(),
                                       txtAddress.Text.Trim(), txtTelephone.Text.Trim(), txtFax.Text.Trim(), txtHotline.Text.Trim(), txtEmail.Text.Trim(), txtWebSite.Text.Trim(), txtContactPerson.Text.Trim(), iShortOrder,
                                       "GIN/", 1, 5, "CO", 1, 6, "DO", 1, 6, "IN", 1, 6, "CR", 1, 6, "DR", 1, 6,
                                       "SR", 1, 6, "CU", 1, 6, "SU", 1, 6, "SRT", 1, 6, "IGRN", 1, 6, "IGIN", 1, 6, "RC/", 1, 5, "POS/", 1, 6, "POSRCT/",1,6 ,chkIsHeadOffice.Checked);
                                    detail.Insert();
                                    clsHelpMethods.InsertTransactionHistory(iFormID, txtCompanyBranchID.Text, TxnActivity.Insert);
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
            clsFormatter.ApplyGridFormat_New(dgvDetail, clsFormatter.colorGrid, UI_Color);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCompanyBranchID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblBranchD, true);

            txtCompanyCountry.Tag = null;
            txtCompanyBranchID.Clear();
            txtCompanyCountry.Clear();
            txtBranchName.Clear();
            txtAddress.Clear();
            txtTelephone.Clear();
            txtFax.Clear();
            txtContactPerson.Clear();
            txtLineNo.Clear();
            txtShortOrder.Clear();
            txtHotline.Clear();
            txtEmail.Clear();
            txtWebSite.Clear();

            chkIsHeadOffice.Checked = false;

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtCompanyBranchID.Text = "<Auto Generate>";
            else
                txtCompanyBranchID.Clear();
            if (txtCompanyBranchID.Enabled)
            {
                txtCompanyBranchID.SelectAll();
                txtCompanyBranchID.Focus();
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
                List<tbl_genCompanyBranchMaster> details = tbl_genCompanyBranchMaster.SelectAll();
                foreach (tbl_genCompanyBranchMaster detail in details)
                {
                    if (detail.CompanyBranch_ID.Trim() != "default")
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["CompanyBranchID", iRow].Value = detail.CompanyBranch_ID;
                        dgvDetail["BranchName", iRow].Value = detail.BranchName;
                        dgvDetail["CompanyCountryID", iRow].Value = clsGenaralName.getName_CompanyCountry(detail.CompanyCountry_ID);
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
                    tbl_genCompanyBranchMaster detail = tbl_genCompanyBranchMaster.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCompanyBranchID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblBranchD, false);

                        //asign values
                        txtCompanyCountry.Tag = detail.CompanyCountry_ID;
                        txtCompanyCountry.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_CompanyCountry(detail.CompanyCountry_ID));
                        txtCompanyBranchID.Text = detail.CompanyBranch_ID;
                        txtBranchName.Text = detail.BranchName;
                        txtAddress.Text = detail.Adress;
                        txtTelephone.Text = detail.Telephone;
                        txtFax.Text = detail.Fax;
                        txtContactPerson.Text = detail.ContactPerson;
                        txtLineNo.Text = detail.LineNO.ToString();
                        txtShortOrder.Text = detail.Shortorder.ToString();
                        txtHotline.Text = detail.Hotline.ToString();
                        txtEmail.Text = detail.Email.ToString();
                        txtWebSite.Text = detail.Website.ToString();

                        chkIsHeadOffice.Checked = detail.IsHeadOffice;
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
                if (txtCompanyCountry.TextLength == 0)
                {
                    strMessage += "\n" + " Company Country";
                    bStatus = false;
                }
                if (txtBranchName.TextLength == 0)
                {
                    strMessage += "\n" + " Company Branch ";
                    bStatus = false;
                }
                if (txtLineNo.TextLength == 0)
                {
                    strMessage += "\n" + " Line Number ";
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
                Search_BranchID();
            }   
        }
        private void txtCompanyCountryName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CompanyCountryID();
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
            Search_BranchID();
        }
        private void txtCountryName_DoubleClick(object sender, EventArgs e)
        {
            Search_CompanyCountryID();
        }
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvDetail["CompanyBranchID", e.RowIndex].Value.ToString();
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

        #region  Event KeyPress
        private void txtTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowIntegerAndPlus(e);
        }

        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowIntegerAndPlus(e);
        }
        #endregion

        #region Search Methods
        private void Search_CompanyCountryID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_CompanyCountry();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    if (frmSearchMaster.s_SearchText.Length > 0)
                        txtCompanyCountry.Text = frmSearchMaster.s_SearchText;
                    if (frmSearchMaster.s_SearchID.Length > 0)
                        txtCompanyCountry.Tag = frmSearchMaster.s_SearchID;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_BranchID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_CompanyBranch();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    txtCompanyBranchID.Text = frmSearchMaster.s_SearchID;
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

        private void txtLineNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowInteger(e);
        }

        private void txtShortOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowInteger(e);
        }
        
    }
}
