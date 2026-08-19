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
    public partial class frm_mtrItemClass : MettroForm
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
        public frm_mtrItemClass()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.ZItemClass);
            iFormID = clsSecurity.getFormID(FormName.ZItemClass);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_mtrCustomerClass_Load(object sender, EventArgs e)
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
                        tbl_zItemClass detail = tbl_zItemClass.Select(txtClassID.Text.Trim());
                        if (detail != null)
                        {
                            detail.Delete();
                            clsHelpMethods.InsertTransactionHistory(iFormID, txtClassID.Text, TxnActivity.Cancel);
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
                    clsValidate.WriteErrorLog(sqlException.Message, iFormID, null);
                    SEACCException.Show(sqlException);
                }
            }
            catch (Exception ex)
            {

                SEACCException.Show(ex);
            }
            finally { Cursor = Cursors.Default; }
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
                            if (txtClassID.TextLength > 0)
                            {
                                if (IsUpdate)  //update records
                                {
                                    tbl_zItemClass oldRecord = tbl_zItemClass.Select(txtClassID.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        //Country Header
                                        tbl_zItemClass detail = new tbl_zItemClass(txtClassID.Text.Trim(), txtClassName.Text.Trim(), txtPrifix.Text.Trim().ToUpper(), oldRecord.Prefrix2, oldRecord.Remark , oldRecord.IsProd_Class);
                                        detail.Update();
                                        clsHelpMethods.InsertTransactionHistory(iFormID, txtClassID.Text, TxnActivity.Update);
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else  //insert records
                                {
                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                        txtClassID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                    //Inquiry Header
                                    tbl_zItemClass detail = new tbl_zItemClass(txtClassID.Text.Trim(), txtClassName.Text.Trim(), txtPrifix.Text.Trim().ToUpper(), "", "" , false);
                                    detail.Insert();
                                    clsHelpMethods.InsertTransactionHistory(iFormID, txtClassID.Text, TxnActivity.Insert);
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Item Class " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtClassID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblClassID, true);

            txtClassName.Clear();
            txtPrifix.Clear();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtClassID.Text = "<Auto Generate>";
            else
                txtClassID.Clear();

            if (txtClassID.Enabled)
            {
                txtClassID.SelectAll();
                txtClassID.Focus();
            }
            //txtClassID.Text = "ok";
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            int iRow;
            dgvDetail.Rows.Clear();
            List<tbl_zItemClass> details = tbl_zItemClass.SelectAll();
            foreach (tbl_zItemClass detail in details)
            {
                if (detail.ItemClass_ID.Trim() != "default")
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    dgvDetail["CategoryID", iRow].Value = detail.ItemClass_ID;
                    dgvDetail["CategoryName", iRow].Value = detail.ClassName;
                    dgvDetail["Prifix", iRow].Value = detail.Prefrix;
                }
            }
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            if (sID.Length > 0)
            {
                tbl_zItemClass detail = tbl_zItemClass.Select(sID);
                if (detail != null)
                {
                    //set the update flag and Locked
                    IsUpdate = true;
                    clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtClassID, false);
                    clsCommon.SetEnableDisable_NormalLabel(lblClassID, false);

                    //asign values
                    txtClassID.Text = detail.ItemClass_ID;
                    txtClassName.Text = detail.ClassName;
                    txtPrifix.Text = detail.Prefrix;
                }
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtClassName.TextLength == 0)
            {
                strMessage += "\n" + "Class Name ";
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
        private void txtClassID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_ItemID();
            }
        }
        private void frm_mtrItemClass_KeyDown(object sender, KeyEventArgs e)
        {

        }
        #endregion

        #region Events DoubleClick
        private void txtClassID_DoubleClick(object sender, EventArgs e)
        {
            Search_ItemID();
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
        private void Search_ItemID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_ItemClass();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    txtClassID.Text = frmSearchMaster.s_SearchID;
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
