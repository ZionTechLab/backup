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
    public partial class frm_mtrTax : MettroForm
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
        public frm_mtrTax()
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
                if (txtTaxID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                          tbl_zTax detail =   tbl_zTax.Select(txtTaxID.Text.Trim());
                        if (detail != null)
                        {
                            detail.Delete();
                            clsHelpMethods.InsertTransactionHistory(iFormID, txtTaxID.Text, TxnActivity.Cancel);
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
                            if (txtTaxID.TextLength > 0)
                            {
                                if (IsUpdate)  //update records
                                {
                                    tbl_zTax oldRecord =   tbl_zTax.Select(txtTaxID.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        //Country Header
                                        tbl_zTax detail = new tbl_zTax(txtTaxID.Text.Trim(), txtTaxName.Text.Trim(), decimal.Parse(txtPresantage.Text),txtPaybleGlID.Tag.ToString().Trim(), txtRecivableGlID.Tag.ToString().Trim());
                                        detail.Update();
                                        clsHelpMethods.InsertTransactionHistory(iFormID, txtTaxID.Text, TxnActivity.Update);
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        if (detail.Tax_ID == "TAX/002") //NBT
                                        {
                                            clsConfig.sNBTGLCode_Payable = detail.PayableGl_ID;
                                            clsConfig.sNBTGLCode_Receivable = detail.ReceivableGl_ID;
                                        }
                                        else if (detail.Tax_ID == "TAX/001") //VAT
                                        {
                                            clsConfig.sVATGLCode_Payable = detail.PayableGl_ID;
                                            clsConfig.sVATGLCode_Receivable = detail.ReceivableGl_ID;
                                        }
                                    }
                                }
                                else  //insert records
                                {
                                    //if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                    //    txtTaxID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                    ////Inquiry Header
                                    //tbl_zTax detail = new tbl_zTax(txtTaxID.Text.Trim(), txtTaxName.Text.Trim(), decimal.Parse(txtPresantage.Text), txtPaybleGlID.Text.Trim(), txtRecivableGlID.Text.Trim());
                                    //detail.Insert();
                                    //MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtTaxID, false);
            clsCommon.SetEnableDisable_NormalLabel(lblClassID, true);
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPaybleGlID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblPaybleGlID, true);
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtRecivableGlID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblReciveableGlID, true);

            txtPaybleGlID.Tag = null;
            txtRecivableGlID.Tag = null;

            txtTaxName.Clear();
            txtPresantage.Clear();
            txtRecivableGlID.Clear();
            txtPaybleGlID.Clear();


            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
            {
                txtTaxID.Text = "<Auto Generate>";             
            }
            else
            {
                txtTaxID.Clear();                
            }

            if (txtTaxID.Enabled)
            {
                txtTaxID.SelectAll();
                txtTaxID.Focus();
            }
            //txtClassID.Text = "ok";
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            int iRow;
            dgvDetail.Rows.Clear();
            List<tbl_zTax> details = tbl_zTax.SelectAll();
            foreach (tbl_zTax detail in details)
            {
                if (detail.Tax_ID.Trim() != "default")
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    dgvDetail["CategoryID", iRow].Value = detail.Tax_ID;
                    dgvDetail["CategoryName", iRow].Value = detail.TaxName;
                    dgvDetail["Prifix", iRow].Value = detail.TaxPesentage;
                }
            }
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            if (sID.Length > 0)
            {
                  tbl_zTax detail =   tbl_zTax.Select(sID);
                if (detail != null)
                {
                    //set the update flag and Locked
                    IsUpdate = true;
                    clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtTaxID, false);
                    clsCommon.SetEnableDisable_NormalLabel(lblClassID, false);

                    //asign values
                    txtTaxID.Text = detail.Tax_ID;
                    txtTaxName.Text = detail.TaxName;
                    txtPresantage.Text = detail.TaxPesentage.ToString();
                    txtPaybleGlID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_AccountName(detail.PayableGl_ID));
                    txtRecivableGlID.Text =clsCommon.GetForeignKeyValue(clsGenaralName.getName_AccountName(detail.ReceivableGl_ID));

                    txtPaybleGlID.Tag = detail.PayableGl_ID;
                    txtRecivableGlID.Tag = detail.ReceivableGl_ID;

                }
            }
        }
        #endregion


        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtTaxName.TextLength == 0)
            {
                strMessage += "\n" + "Class Name ";
                bStatus = false;
            }
            if (txtPresantage.TextLength == 0)
            {
                strMessage += "\n" + "Prifix Name ";
                bStatus = false;
            }
            //foreach (DataGridViewRow row in dgvDetail.Rows)
            //{
            //    if (clsValidate.ValidateGridValue(dgvDetail, "Prifix", row.Index, "").ToString() == txtPrifix.Text.ToUpper() && IsUpdate == false && txtPrifix.TextLength != 0)
            //    {
            //        strMessage += "\n" + " You Can't Enter Same Prifix Name ";
            //        bStatus = false;
            //        break;
            //    }
            //}
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
                clsSearch.Search_MasterTax(ref txtTaxID);
                if (txtTaxID.Tag != null)
                    FillDetails(txtTaxID.Tag.ToString());
            }   
        }
        private void frm_mtrItemClass_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void txtPaybleGlID_KeyDown(object sender, KeyEventArgs e)
        {
            SearchAcctCode_Payble();
        }
        private void txtRecivableGlID_KeyDown(object sender, KeyEventArgs e)
        {
            SearchAcctCode_Recivable();
        }
        #endregion

        #region Event Key Press
        private void txtPrifix_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }
        #endregion

        #region Events DoubleClick
        private void txtClassID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterTax(ref txtTaxID);
            if (txtTaxID.Tag != null)
                FillDetails(txtTaxID.Tag.ToString());
        }

        private void txtPaybleGlID_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.SearchAcctCode_Payble();
        }

        private void txtRecivableGlID_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.SearchAcctCode_Recivable();
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


        #region Search Account Code
        private void SearchAcctCode_Payble()
        {
            try
            {
                clsSearch.Search_MasterAccountGLCode(ref txtPaybleGlID, "", clsAutocode.getControlAccount_Types(enum_ControlAccountType.Other));

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        } 
        private void SearchAcctCode_Recivable()
        {
            try
            {
                clsSearch.Search_MasterAccountGLCode(ref txtRecivableGlID, "", clsAutocode.getControlAccount_Types(enum_ControlAccountType.Other));

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion
    }
}
