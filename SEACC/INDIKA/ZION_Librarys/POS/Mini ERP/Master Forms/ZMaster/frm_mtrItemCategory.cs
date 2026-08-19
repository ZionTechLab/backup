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
    public partial class frm_mtrItemCategory : MettroForm
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
        public frm_mtrItemCategory()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.ZItemCategory);
            iFormID = clsSecurity.getFormID(FormName.ZItemCategory);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_mtrItemCategory_Load(object sender, EventArgs e)
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
                if (CheckValidity())
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_zItemCategory detail = tbl_zItemCategory.Select(txtCategoryID.Text.Trim());
                        if (detail != null)
                        {
                            detail.Delete();
                            clsHelpMethods.InsertTransactionHistory(iFormID, txtCategoryID.Text, TxnActivity.Cancel);
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
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                if (sqlException.Number == 547)
                    MessageBox.Show("Unable to delete the recode.\nPlease remove Item Master references befor delete seleted data. ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    clsValidate.WriteErrorLog("", iFormID,sqlException);
                    SEACCException.Show(sqlException);
                }
            }
            catch (Exception ex)
            {
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
                            if (txtCategoryID.TextLength > 0)
                            {
                                if (IsUpdate)  //update records
                                {
                                    tbl_zItemCategory oldRecord = tbl_zItemCategory.Select(txtCategoryID.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        tbl_zItemCategory detail = new tbl_zItemCategory(txtCategoryID.Text.Trim(), txtCategoryName.Text.Trim(), txtTypeName.Tag.ToString(), txtPrifix.Text.Trim().ToUpper(), oldRecord.Prefrix2, chkItemSubCategoryEnabled.Checked, chkItemSubCategory2Enabled.Checked, chkSerialNo.Checked, chkSerialNo2.Checked, oldRecord.CategoryCounter, oldRecord.CategoryLength, oldRecord.Remark);
                                        detail.Update();
                                        clsHelpMethods.InsertTransactionHistory(iFormID, txtCategoryID.Text, TxnActivity.Update);
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else  //insert records
                                {
                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                        txtCategoryID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                    //Inquiry Header
                                    tbl_zItemCategory detail = new tbl_zItemCategory(txtCategoryID.Text.Trim(), txtCategoryName.Text.Trim(), txtTypeName.Tag.ToString(), txtPrifix.Text.Trim().ToUpper(), "", chkItemSubCategoryEnabled.Checked, chkItemSubCategory2Enabled.Checked, chkSerialNo.Checked, chkSerialNo2.Checked, 1, 3, "");
                                    detail.Insert();
                                    clsHelpMethods.InsertTransactionHistory(iFormID, txtCategoryID.Text, TxnActivity.Insert);
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Item Category " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCategoryID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblBankID, true);

            txtTypeName.Tag = null;
            txtTypeName.Clear();
            txtCategoryName.Clear();
            txtPrifix.Clear();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtCategoryID.Text = "<Auto Generate>";
            else
                txtCategoryID.Clear();
            if (txtCategoryID.Enabled)
            {
                txtCategoryID.SelectAll();
                txtCategoryID.Focus();
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            int iRow;
            dgvDetail.Rows.Clear();
            List<tbl_zItemCategory> details = tbl_zItemCategory.SelectAll();
            foreach (tbl_zItemCategory detail in details)
            {
                if (detail.ItemCategory_ID.Trim() != "default")
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    dgvDetail["CategoryID", iRow].Value = detail.ItemCategory_ID;
                    dgvDetail["CategoryName", iRow].Value = detail.CategoryName;
                    dgvDetail["Prifix", iRow].Value = detail.Prefrix;
                    dgvDetail["SubCategory", iRow].Value = detail.IsItemSubCategoryEnabled;
                    dgvDetail["SubCategory2", iRow].Value = detail.IsItemSubCategory2Enabled;
                    dgvDetail["SerialNo", iRow].Value = detail.IsItemSerialNoEnabled;
                    dgvDetail["SerialNo2", iRow].Value = detail.IsItemSerialNo2Enabled;
                }
            }
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            if (sID.Length > 0)
            {
                tbl_zItemCategory detail = tbl_zItemCategory.Select(sID);
                if (detail != null)
                {
                    //set the update flag and Locked
                    IsUpdate = true;
                    clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCategoryID, false);
                    clsCommon.SetEnableDisable_NormalLabel(lblBankID, false);

                    //asign values
                    txtTypeName.Tag = detail.ItemType_ID;
                    txtTypeName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemType(detail.ItemType_ID));
                    txtCategoryID.Text = detail.ItemCategory_ID;
                    txtCategoryName.Text = detail.CategoryName;
                    txtPrifix.Text = detail.Prefrix;
                    chkItemSubCategoryEnabled.Checked = detail.IsItemSubCategoryEnabled;
                    chkItemSubCategory2Enabled.Checked = detail.IsItemSubCategory2Enabled;
                    chkSerialNo.Checked = detail.IsItemSerialNoEnabled;
                    chkSerialNo2.Checked = detail.IsItemSerialNo2Enabled;
                }
            }
        }
        #endregion


        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtTypeName.TextLength == 0)
            {
                strMessage += "\n" + " Type Name ";
                bStatus = false;
            }

            if (txtPrifix.TextLength == 0)
            {
                strMessage += "\n" + "Prifix Name ";
                bStatus = false;
            }
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                if (clsValidate.ValidateGridValue(dgvDetail, "Prifix", row.Index, "").ToString() == txtPrifix.Text.ToUpper() && IsUpdate == false && txtPrifix.TextLength != 0)
                {
                    strMessage += "\n" + " You Can't Enter Same Prifix Name ";
                    bStatus = false;
                    break;
                }
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
        private void txtCategoryID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_ItemCategoryID();
            }
        }
        private void frm_mtrItemCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTypeName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterItemType(ref txtTypeName);
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtCategoryID_DoubleClick(object sender, EventArgs e)
        {
            Search_ItemCategoryID();
        }

        private void txtTypeName_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterItemType(ref txtTypeName);
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

        #region Search Methods
        private void Search_ItemCategoryID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_ItemCategory();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    txtCategoryID.Text = frmSearchMaster.s_SearchID;
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
