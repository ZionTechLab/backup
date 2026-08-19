using DataTire;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digiteq
{
    public partial class frm_mtrItemSubCategory_New : SEACC_Form
    {
        
        //to manage update and insert
        //static bool IsUpdate = false;

        //to keep form detail       
        //string sFormConfigCode;
        //public int iFormID;
        public bool bNoAccess;


        #region Form Load
        public frm_mtrItemSubCategory_New(FormName _enmForm)
        {
            //sFormConfigCode = clsAutocode.getFormConfigCode(FormName.ZItemSubCategory);
            //iFormID = clsSecurity.getFormID(FormName.ZItemSubCategory);
            //if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            //{
            //    bNoAccess = true;
            //}

            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }

        private void frm_mtrItemSubCategory_New_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, false, false, true, true, false, false, false, false);

            RefreshGrid();
            CusDataGridViewFormat();
            ClearFields();
            //lblSubCategoryID.Text = clsConfig.sItemSubCategory + " ID"; ;
            //lblSubCategoryName.Text = clsConfig.sItemSubCategory;
            //this.Text = clsConfig.sItemSubCategory;
            //dgvDetail.Columns["CategoryID"].HeaderText = clsConfig.sItemSubCategory + " ID";
            //dgvDetail.Columns["SubCategoryName"].HeaderText = clsConfig.sItemSubCategory;
        }
        #endregion

        #region Btn New
        private void frm_mtrItemSubCategory_New_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region Btn Delete

        private void frm_mtrItemSubCategory_New_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSubCategoryID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_zItemCategory_Sub detail = tbl_zItemCategory_Sub.Select(txtSubCategoryID.Text.Trim());
                        if (detail != null)
                        {
                            detail.Delete();
                            clsHelpMethods.InsertTransactionHistory(iFormID, txtSubCategoryID.Text, TxnActivity.Cancel);
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region Btn Save

        private void frm_mtrItemSubCategory_New_SF_saveButton_Click(object sender, EventArgs e)
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
                            if (txtSubCategoryID.TextLength > 0)
                            {
                                if (IsUpdate)  //update records
                                {
                                    tbl_zItemCategory_Sub oldRecord = tbl_zItemCategory_Sub.Select(txtSubCategoryID.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        //Country Header
                                        tbl_zItemCategory_Sub detail = new tbl_zItemCategory_Sub(txtSubCategoryID.Text.Trim(), oldRecord.ItemCategory_ID, txtSubCategoryName.Text.Trim(), oldRecord.Prefrix);
                                        detail.Update();
                                        clsHelpMethods.InsertTransactionHistory(iFormID, txtSubCategoryID.Text, TxnActivity.Update);
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else  //insert records
                                {
                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                        txtSubCategoryID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                    //Inquiry Header
                                    tbl_zItemCategory_Sub detail = new tbl_zItemCategory_Sub(txtSubCategoryID.Text.Trim(), "default", txtSubCategoryName.Text.Trim(), "");
                                    detail.Insert();
                                    clsHelpMethods.InsertTransactionHistory(iFormID, txtSubCategoryID.Text, TxnActivity.Insert);
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Sub Category " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            
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
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtSubCategoryID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSubCategoryID, true);

            txtSubCategoryName.Clear();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtSubCategoryID.Text = "<Auto Generate>";
            else
                txtSubCategoryID.Clear();
            if (txtSubCategoryID.Enabled)
            {
                txtSubCategoryID.SelectAll();
                txtSubCategoryID.Focus();
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
                List<tbl_zItemCategory_Sub> details = tbl_zItemCategory_Sub.SelectAll();
                foreach (tbl_zItemCategory_Sub detail in details)
                {
                    if (detail.ItemCategorySub_ID != "default")
                    {

                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["CategoryID", iRow].Value = detail.ItemCategorySub_ID;
                        dgvDetail["SubCategoryName", iRow].Value = detail.CategorySubName;
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
                    tbl_zItemCategory_Sub detail = tbl_zItemCategory_Sub.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtSubCategoryID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblSubCategoryID, false);

                        //asign values
                        txtSubCategoryID.Text = detail.ItemCategorySub_ID;
                        txtSubCategoryName.Text = detail.CategorySubName;
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

            if (txtSubCategoryName.TextLength == 0)
            {
                strMessage += "\n" + "Bank Name ";
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
        private void frm_mtrItemSubCategory_New_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtSubCategoryID_DoubleClick(object sender, EventArgs e)
        {
            //if (e.KeyCode == Keys.F1)
            //{
                //clsSearch.Search_MasterItemSubCategory(ref txtSubCategoryID);
            //}

            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_ItemCategorySub();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtSubCategoryID.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                txtSubCategoryID.Tag = frmSearchMaster.s_SearchID;
                //GenarateReversTreeOrder(txtSubCategoryID);
            }
        }
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvDetail["CategoryID", e.RowIndex].Value.ToString();
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
