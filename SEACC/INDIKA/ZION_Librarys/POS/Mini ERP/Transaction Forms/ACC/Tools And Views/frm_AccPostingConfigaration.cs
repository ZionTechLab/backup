using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Digiteq_Logic;
using DataTire;

namespace Digiteq
{
    public partial class frm_AccPostingConfigaration : MettroForm
    {
        #region Variables     
        static bool IsUpdate = false;
        string sFormConfigCode;
        public int iFormID;

        public bool bNoAccess;
        #endregion

        #region Form Load
        public frm_AccPostingConfigaration()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.accDoubleEntrySlot);
            iFormID = clsSecurity.getFormID(FormName.accDoubleEntrySlot);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }
        private void frm_AccPostingConfigaration_Load(object sender, EventArgs e)
        {
            ThemeColor = clsFormatter.colorAccounts;

            Ex_Invoice_Refresh_Click(null, null);
            Ex_Receipt_Refresh_Click(null, null);
            Ex_DebitNote_Refresh_Click(null, null);
            Ex_CreditNote_Refresh_Click(null, null);
            Ex_CashDeposite_Refresh_Click(null, null);
            Ex_ChequeDeposite_Refresh_Click(null, null);
            Ex_ChequeReturn_Refresh_Click(null, null);
            Ex_ChequeRedeposite_Refresh_Click(null, null);
            Ex_ICT_Refresh_Click(null, null);
            Ex_SRN_Refresh_Click(null, null);
            Ex_POS_Refresh_Click(null, null);

            Ex_Invoice.InitializeSize();
            Ex_Receipt.InitializeSize();
            Ex_DebitNote.InitializeSize();
            Ex_CreditNote.InitializeSize();
            Ex_CashDeposite.InitializeSize();
            Ex_ChequeDeposite.InitializeSize();
            Ex_ChequeReturn.InitializeSize();
            Ex_ChequeRedeposite.InitializeSize();
            Ex_ICT.InitializeSize();
            Ex_SRN.InitializeSize();
            Ex_POS.InitializeSize();
        }
        #endregion

        #region Save
        private void Ex_Invoice_Update_Click(object sender, EventArgs e)
        {
            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
            {
                try
                {
                    bool bIsUpdateValidationOk = false;
                    if (chkEnable.Checked)
                    {
                        if (txtDiscount.Tag != null && txtDiscount.Tag != "default")
                            bIsUpdateValidationOk = true;
                        else
                            MessageBox.Show("Please select the Discount Account Code..", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK);
                    }
                    else
                        bIsUpdateValidationOk = true;

                    if (bIsUpdateValidationOk)
                    {
                        if (rdoNoteType.Checked)
                        {
                            #region Update SalesNote Type
                            foreach (DataGridViewRow row in dgvDetail.Rows)
                            {
                                string sNoteTypeID = "", sNoteTypeName = "", sGLID = "", sGLName = "";
                                sNoteTypeID = clsValidate.ValidateGridValue(dgvDetail, "NoteTypeID", row.Index, "0");
                                sNoteTypeName = clsValidate.ValidateGridValue(dgvDetail, "NoteTypeName", row.Index, "default");
                                sGLID = clsValidate.ValidateGridValue(dgvDetail, "GL_ID", row.Index, "default");
                                sGLName = clsValidate.ValidateGridValue(dgvDetail, "GLName", row.Index, "default");

                                tbl_zSalesNoteType oNoteType = tbl_zSalesNoteType.Select(sNoteTypeID);
                                if (oNoteType != null)
                                {
                                    oNoteType.Gl_ID = sGLID;
                                    oNoteType.Update();
                                }
                            }
                            #endregion
                        }
                        //   if (rdoNoteType.Checked == true)
                        //  {
                        clsConfig.sInvoice_SalesAccount_Type = (rdoNoteType.Checked == true) ? "1" : "2";
                        clsSecurity.SetCofigValue(254, clsConfig.sInvoice_SalesAccount_Type);
                        //}



                        #region Update Discount Acc. Code
                        clsSecurity.SetCofigValue(241, txtDiscount.Tag.ToString());
                        clsConfig.sAccountCode_Discount = txtDiscount.Tag.ToString();
                        //tbl_securityConfigValue oValue = tbl_securityConfigValue.Select(241);
                        //if (oValue != null)
                        //{
                        //    oValue.ConfigValue = txtDiscount.Tag.ToString();
                        //    oValue.Update();
                        //    clsConfig.sAccountCode_Discount = txtDiscount.Tag.ToString();
                        //}
                        #endregion
                        MessageBox.Show("Succesfully Updated", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID,ex);
                    SEACCException.Show(ex);
                }

            }
        }

        private void Ex_Receipt_Update_Click(object sender, EventArgs e)
        {
            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
            {
                if (txt_ReceiptCash.Tag != null && txt_ReceiptCheque.Tag != null && txt_ReceiptCashAdv.Tag != null && txt_ReceiptChequeAdv.Tag != null)
                {
                    clsMethods_GL.SetAccountCode(AccSlot.PartPaymentReceipt_Cash, txt_ReceiptCash.Tag.ToString());
                    clsMethods_GL.SetAccountCode(AccSlot.PartPaymentReceipt_Cheque, txt_ReceiptCheque.Tag.ToString());
                    clsMethods_GL.SetAccountCode(AccSlot.AdvanceReceipt_Cash, txt_ReceiptCashAdv.Tag.ToString());
                    clsMethods_GL.SetAccountCode(AccSlot.AdvanceReceipt_Cheque, txt_ReceiptChequeAdv.Tag.ToString());
                    clsMethods_GL.SetAccountCode(AccSlot.Receipt_CreditCard, txt_ReceiptCard.Tag.ToString());
                    MessageBox.Show("Succesfully Updated", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK);

                    Ex_Receipt_Refresh_Click(null, null);
                }
                else
                    MessageBox.Show("Invalied Account Code", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK);
            }
        }

        private void Ex_DebitNote_Update_Click(object sender, EventArgs e)
        {
            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
            {
                if (txt_DBNGT.Tag != null && txt_DBNST.Tag != null)
                {
                    clsMethods_GL.SetAccountCode(AccSlot.Customer_DebitNote, txt_DBNGT.Tag.ToString());
                    clsMethods_GL.SetAccountCode(AccSlot.Customer_CreditNote, txt_DBNST.Tag.ToString());
                    MessageBox.Show("Succesfully Updated", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK);

                    Ex_DebitNote_Refresh_Click(null, null);
                }
                else
                    MessageBox.Show("Invalied Account Code", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK);
            }
        }

        private void Ex_CreditNote_Update_Click(object sender, EventArgs e)
        {
            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
            {
                if (txt_CRNGT.Tag != null)
                {
                    clsMethods_GL.SetAccountCode(AccSlot.Customer_CreditNote, txt_CRNGT.Tag.ToString());
                    //clsMethods_GL.SetAccountCode(AccSlot.Customer_CreditNote, txt_CRNST.Tag.ToString());
                    MessageBox.Show("Succesfully Updated", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK);

                    Ex_CreditNote_Refresh_Click(null, null);
                }
                else
                    MessageBox.Show("Invalied Account Code", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK);
            }
        }

        private void Ex_CashDeposite_Update_Click(object sender, EventArgs e)
        {
            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
            {
                if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                {
                    if (txt_CashDepCrAcc.Tag != null)
                    {
                        clsMethods_GL.SetAccountCode(AccSlot.CashDeposit, txt_CashDepCrAcc.Tag.ToString());
                        //clsMethods_GL.SetAccountCode(AccSlot.Customer_CreditNote, txt_CashDepDrAcc.Tag.ToString());
                        MessageBox.Show("Succesfully Updated", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK);

                        Ex_CashDeposite_Refresh_Click(null, null);
                    }
                    else
                        MessageBox.Show("Invalied Account Code", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK);
                }
            }
        }

        private void Ex_ChequeDeposite_Update_Click(object sender, EventArgs e)
        {
            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
            {
                if (txt_ChequeDepCrAcc.Tag != null && txt_CashDepositeAccount.Tag != null)
                {
                    //clsMethods_GL.SetAccountCode(AccSlot.ChequeDeposit, txt_ChequeDepCrAcc.Tag.ToString());
                    //clsMethods_GL.SetAccountCode(AccSlot.Customer_CreditNote, txt_ChequeDepDrAcc.Tag.ToString());

                    clsMethods_GL.SetChequeControlAccountCode(txt_ChequeDepCrAcc.Tag.ToString());
                    clsMethods_GL.SetCashControlAccountCode(txt_CashDepositeAccount.Tag.ToString());

                    MessageBox.Show("Succesfully Updated", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK);

                    Ex_ChequeDeposite_Refresh_Click(null, null);
                }
                else
                    MessageBox.Show("Invalied Account Code", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK);
            }
        }

        private void Ex_ChequeReturn_Update_Click(object sender, EventArgs e)
        {
            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
            {
                if (txt_ChequeRetDrAcc.Tag != null)
                {
                    clsMethods_GL.SetAccountCode(AccSlot.ChequeReturned, txt_ChequeRetDrAcc.Tag.ToString());
                    //clsMethods_GL.SetAccountCode(AccSlot.Customer_CreditNote, txt_ChequeRetCrAcc.Tag.ToString());
                    MessageBox.Show("Succesfully Updated", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK);

                    Ex_ChequeReturn_Refresh_Click(null, null);
                }
                else
                    MessageBox.Show("Invalied Account Code", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK);
            }
        }

        private void Ex_ChequeRedeposite_Update_Click(object sender, EventArgs e)
        {
            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
            {
                if (txt_ChequeReDepCrAcc.Tag != null)
                {
                    clsMethods_GL.SetAccountCode(AccSlot.ChequeReDeposit, txt_ChequeReDepCrAcc.Tag.ToString());
                    //clsMethods_GL.SetAccountCode(AccSlot.Customer_CreditNote, txt_ChequeReDepDrAcc.Tag.ToString());
                    MessageBox.Show("Succesfully Updated", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK);

                    Ex_ChequeRedeposite_Refresh_Click(null, null);
                }
                else
                    MessageBox.Show("Invalied Account Code", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK);
            }
        }

        private void Ex_ICT_Update_Click(object sender, EventArgs e)
        {
            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
            {
                if (txt_ICTGT.Tag != null && txt_ICTST.Tag != null)
                {
                    clsMethods_GL.SetAccountCode(AccSlot.Customer_CreditNote, txt_ICTST.Tag.ToString());

                    clsSecurity.SetCofigValue(253, txt_ICTGT.Tag.ToString());
                    clsConfig.accType_InterCompany = txt_ICTGT.Tag.ToString();

                    //tbl_securityConfigValue oValue = tbl_securityConfigValue.Select(253);
                    //if (oValue != null)
                    //{
                    //    oValue.ConfigValue = txt_ICTGT.Tag.ToString();
                    //    oValue.Update();
                    //    clsConfig.accType_InterCompany = txt_ICTGT.Tag.ToString();
                    //}

                    MessageBox.Show("Succesfully Updated", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK);

                    Ex_ICT_Refresh_Click(null, null);
                }
                else
                    MessageBox.Show("Invalied Account Code", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK);
            }
        }

        private void Ex_SRN_Update_Click(object sender, EventArgs e)
        {
            clsConfig.bEnableSalesReturn_DirectPosting = chkEnableSRNDirectPosting.Checked;
            clsSecurity.SetConfigStatus(427, chkEnableSRNDirectPosting.Checked);
        }

        private void Ex_Inventry_Refresh_Click(object sender, EventArgs e)
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtInventry, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtStock, true);

            clsMethods_GL.GetAccountCode(AccSlot.GoodReceivedNote, ref txtInventry);
            txtStock.Tag = clsConfig.sGl_id_ClosingStock;
            txtStock.Text = clsGenaralName.getName_AccountName(clsConfig.sGl_id_ClosingStock);
        }

        private void Ex_Inventry_Update_Click(object sender, EventArgs e)
        {
            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
            {
                if (txtInventry.Tag != null && txtStock.Tag != null)
                {
                    clsMethods_GL.SetAccountCode(AccSlot.GoodReceivedNote, txtInventry.Tag.ToString());

                    clsSecurity.SetCofigValue(255, txtStock.Tag.ToString());
                    clsConfig.sGl_id_ClosingStock = txtStock.Tag.ToString();
                    MessageBox.Show("Succesfully Updated", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK);

                    Ex_ChequeRedeposite_Refresh_Click(null, null);
                }
                else
                    MessageBox.Show("Invalied Account Code", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK);
            }
        }


        private void Ex_POS_Update_Click(object sender, EventArgs e)
        {
            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
            {
                try
                {
                    #region Update SalesNote Type
                    foreach (DataGridViewRow row in dgvCompanyBranch.Rows)
                    {
                        string sBranchID = "", sSalesGL_ID = "", sCardGL_ID = "", sCashGL_ID = "", sChqGL_ID = "", sAdvGL_ID = "", sCRN_ID = "";

                        sBranchID = clsValidate.ValidateGridValue(dgvCompanyBranch, "BranchID", row.Index, "0");
                        sSalesGL_ID = clsValidate.ValidateGridValue(dgvCompanyBranch, "SalesAccGL_Id", row.Index, "default");
                        sCardGL_ID = clsValidate.ValidateGridValue(dgvCompanyBranch, "CardGL_ID", row.Index, "default");
                        sCashGL_ID = clsValidate.ValidateGridValue(dgvCompanyBranch, "CashGL_ID", row.Index, "default");
                        sChqGL_ID = clsValidate.ValidateGridValue(dgvCompanyBranch, "ChqGL_ID", row.Index, "default");
                        sAdvGL_ID = clsValidate.ValidateGridValue(dgvCompanyBranch, "AdvGL_ID", row.Index, "default");
                        sCRN_ID = clsValidate.ValidateGridValue(dgvCompanyBranch, "CRN_GL_ID", row.Index, "default");

                        tbl_accGLMaster_CompanyBranch oBranch_GL = tbl_accGLMaster_CompanyBranch.Select(sBranchID);
                        if (oBranch_GL != null)
                        {
                            oBranch_GL.Sales_Acc = sSalesGL_ID;
                            oBranch_GL.CreditCard_ControlAcc = sCardGL_ID;
                            oBranch_GL.CashInHand_Acc = sCashGL_ID;
                            oBranch_GL.ChequeInHand_Acc = sChqGL_ID;
                            oBranch_GL.Advance_ControlAcc = sAdvGL_ID;
                            oBranch_GL.CreditNote_ControlAcc = sCRN_ID;
                            oBranch_GL.Update();
                        }
                        else
                        {
                            tbl_accGLMaster_CompanyBranch oBranch_GL_New = new tbl_accGLMaster_CompanyBranch(sBranchID, sCardGL_ID, sCashGL_ID, sChqGL_ID, sAdvGL_ID, sSalesGL_ID, sCRN_ID);
                            oBranch_GL_New.Insert();
                        }
                    }
                    MessageBox.Show("Succesfully Updated", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK);
                    #endregion


                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID,ex);
                    SEACCException.Show(ex);
                }
            }
        }
        #endregion

        #region Refresh
        private void Ex_Invoice_Refresh_Click(object sender, EventArgs e)
        {
            if (clsConfig.sInvoice_SalesAccount_Type == "1")
            {
                rdoNoteType.Checked = true;
                dgvDetail.Enabled = true;
                RefreshGridInvoice();
                rdoCustomer.Checked = false;
            }
            else
            {
                rdoNoteType.Checked = false;
                dgvDetail.Enabled = false;
                rdoCustomer.Checked = true;
            }
            if (clsConfig.sAccountCode_Discount == "default")
            {
                chkEnable.Checked = false;
                txtDiscount.Enabled = false;
                txtDiscount.Tag = "default";
                txtDiscount.Text = "<<All Account>>";
            }
            else
            {
                chkEnable.Checked = true;
                txtDiscount.Enabled = true;
                txtDiscount.Tag = clsConfig.sAccountCode_Discount;
                txtDiscount.Text = clsGenaralName.getName_AccountName(clsConfig.sAccountCode_Discount);
            }
        }
        private void Ex_Receipt_Refresh_Click(object sender, EventArgs e)
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txt_ReceiptGT, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txt_ReceiptCash, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txt_ReceiptCheque, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txt_ReceiptCashAdv, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txt_ReceiptChequeAdv, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txt_ReceiptCard, true);

            clsMethods_GL.GetAccountCode(AccSlot.PartPaymentReceipt_Cash, ref txt_ReceiptCash);
            clsMethods_GL.GetAccountCode(AccSlot.PartPaymentReceipt_Cheque, ref txt_ReceiptCheque);
            clsMethods_GL.GetAccountCode(AccSlot.AdvanceReceipt_Cash, ref txt_ReceiptCashAdv);
            clsMethods_GL.GetAccountCode(AccSlot.AdvanceReceipt_Cheque, ref txt_ReceiptChequeAdv);
            clsMethods_GL.GetAccountCode(AccSlot.Receipt_CreditCard, ref txt_ReceiptCard);
            txt_ReceiptGT.Text = "<<Customer Contral Acc.>>";
        }
        private void Ex_DebitNote_Refresh_Click(object sender, EventArgs e)
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txt_DBNST, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txt_DBNGT, true);

            clsMethods_GL.GetAccountCode(AccSlot.Customer_CreditNote, ref txt_DBNST);
            clsMethods_GL.GetAccountCode(AccSlot.Customer_DebitNote, ref txt_DBNGT);
            txt_DBNST.Text = "<<Debtor Contral Acc.>>";
        }
        private void Ex_CreditNote_Refresh_Click(object sender, EventArgs e)
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txt_CRNST, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txt_CRNGT, true);

            clsMethods_GL.GetAccountCode(AccSlot.Customer_CreditNote, ref txt_CRNGT);
            //clsMethods_GL.GetAccountCode(AccSlot.Customer_DebitNote, ref txt_DBNGT);
            txt_CRNST.Text = "<<Debtor Contral Acc.>>";
        }
        private void Ex_CashDeposite_Refresh_Click(object sender, EventArgs e)
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txt_CashDepDrAcc, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txt_CashDepCrAcc, true);

            //clsMethods_GL.GetAccountCode(AccSlot.Customer_CreditNote, ref txt_DBNST);
            clsMethods_GL.GetAccountCode(AccSlot.CashDeposit, ref txt_CashDepCrAcc);
            txt_CashDepDrAcc.Text = "<<Bank Acc.>>";
        }
        private void Ex_ChequeDeposite_Refresh_Click(object sender, EventArgs e)
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txt_CashDepositeAccount, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txt_ChequeDepCrAcc, true);

            //clsMethods_GL.GetAccountCode(AccSlot.Customer_CreditNote, ref txt_DBNST);
            //clsMethods_GL.GetAccountCode(AccSlot.ChequeDeposit, ref txt_ChequeDepCrAcc);

            clsMethods_GL.GetChequeControlAccountCode(ref txt_ChequeDepCrAcc);
            clsMethods_GL.GetCashControlAccountCode(ref txt_CashDepositeAccount);
            //txt_ChequeDepDrAcc.Text = "<<Bank Acc.>>";
        }
        private void Ex_ChequeReturn_Refresh_Click(object sender, EventArgs e)
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txt_ChequeRetCrAcc, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txt_ChequeRetDrAcc, true);

            //clsMethods_GL.GetAccountCode(AccSlot.Customer_CreditNote, ref txt_DBNST);
            clsMethods_GL.GetAccountCode(AccSlot.ChequeReturned, ref txt_ChequeRetDrAcc);
            txt_ChequeRetCrAcc.Text = "<<Bank Acc.>>";
        }
        private void Ex_ChequeRedeposite_Refresh_Click(object sender, EventArgs e)
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txt_ChequeReDepDrAcc, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txt_ChequeReDepCrAcc, true);

            //clsMethods_GL.GetAccountCode(AccSlot.Customer_CreditNote, ref txt_DBNST);
            clsMethods_GL.GetAccountCode(AccSlot.ChequeReDeposit, ref txt_ChequeReDepCrAcc);
            txt_ChequeReDepDrAcc.Text = "<<Bank Acc.>>";
        }
        private void Ex_ICT_Refresh_Click(object sender, EventArgs e)
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txt_ICTST, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txt_ICTGT, true);

            clsMethods_GL.GetAccountCode(AccSlot.Customer_CreditNote, ref txt_ICTST);
            txt_ICTGT.Text = clsGenaralName.getName_GlAccountType1(clsConfig.accType_InterCompany);
            txt_ICTGT.Tag = clsConfig.accType_InterCompany;
            //   clsMethods_GL.GetAccountCode(AccSlot.Inter_Company_Transfer, ref txt_ICTGT);
            txt_ICTST.Text = "<<Debtor Contral Acc.>>";
        }
        private void Ex_SRN_Refresh_Click(object sender, EventArgs e)
        {
            chkEnableSRNDirectPosting.Checked = clsConfig.bEnableSalesReturn_DirectPosting;
        }
        private void Ex_POS_Refresh_Click(object sender, EventArgs e)
        {
            int iRow;
            dgvCompanyBranch.Rows.Clear();

            foreach (tbl_genCompanyBranchMaster oBranch in tbl_genCompanyBranchMaster.SelectAll().Where(p => p.CompanyBranch_ID != "default" && !p.IsHeadOffice))
            {
                dgvCompanyBranch.Rows.Add();
                iRow = dgvCompanyBranch.Rows.Count - 1;

                foreach (DataGridViewRow row in dgvCompanyBranch.Rows)
                {
                    dgvCompanyBranch["BranchID", iRow].Value = oBranch.CompanyBranch_ID;
                    dgvCompanyBranch["BranchName", iRow].Value = oBranch.BranchName;

                    tbl_accGLMaster_CompanyBranch oGL_Company = tbl_accGLMaster_CompanyBranch.Select(oBranch.CompanyBranch_ID);
                    if (oGL_Company != null)
                    {
                        dgvCompanyBranch["SalesAccGL_Id", iRow].Value = oGL_Company.Sales_Acc;
                        dgvCompanyBranch["SalesAccGL", iRow].Value = clsGenaralName.getName_AccountName(oGL_Company.Sales_Acc);

                        dgvCompanyBranch["CardGL_ID", iRow].Value = oGL_Company.CreditCard_ControlAcc;
                        dgvCompanyBranch["CardGL", iRow].Value = clsGenaralName.getName_AccountName(oGL_Company.CreditCard_ControlAcc);

                        dgvCompanyBranch["CashGL_ID", iRow].Value = oGL_Company.CashInHand_Acc;
                        dgvCompanyBranch["CashGL", iRow].Value = clsGenaralName.getName_AccountName(oGL_Company.CashInHand_Acc);

                        dgvCompanyBranch["ChqGL_ID", iRow].Value = oGL_Company.ChequeInHand_Acc;
                        dgvCompanyBranch["ChequeGL", iRow].Value = clsGenaralName.getName_AccountName(oGL_Company.ChequeInHand_Acc);

                        dgvCompanyBranch["AdvGL_ID", iRow].Value = oGL_Company.Advance_ControlAcc;
                        dgvCompanyBranch["AdvGL", iRow].Value = clsGenaralName.getName_AccountName(oGL_Company.Advance_ControlAcc);

                        dgvCompanyBranch["CRN_GL_ID", iRow].Value = oGL_Company.CreditNote_ControlAcc;
                        dgvCompanyBranch["CRN_GL", iRow].Value = clsGenaralName.getName_AccountName(oGL_Company.CreditNote_ControlAcc);
                    }
                    else
                    {
                        dgvCompanyBranch["SalesAccGL_Id", iRow].Value = "";
                        dgvCompanyBranch["SalesAccGL", iRow].Value = "";

                        dgvCompanyBranch["CardGL_ID", iRow].Value = "";
                        dgvCompanyBranch["CardGL", iRow].Value = "";

                        dgvCompanyBranch["CashGL_ID", iRow].Value = "";
                        dgvCompanyBranch["CashGL", iRow].Value = "";

                        dgvCompanyBranch["ChqGL_ID", iRow].Value = "";
                        dgvCompanyBranch["ChequeGL", iRow].Value = "";

                        dgvCompanyBranch["AdvGL_ID", iRow].Value = "";
                        dgvCompanyBranch["AdvGL", iRow].Value = "";

                        dgvCompanyBranch["CRN_GL_ID", iRow].Value = "";
                        dgvCompanyBranch["CRN_GL", iRow].Value = "";
                    }
                }
            }
        }

        #endregion

        #region Refresh Grid Invoice
        private void RefreshGridInvoice()
        {
            int iRow;
            dgvDetail.Rows.Clear();

            foreach (tbl_zSalesNoteType detail in tbl_zSalesNoteType.SelectAllByCompanyBranch_ID(clsSecurity.BranchID).Where(p => p.SalesNoteType_ID != "default"))
            {
                dgvDetail.Rows.Add();
                iRow = dgvDetail.Rows.Count - 1;

                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    dgvDetail["NoteTypeID", iRow].Value = detail.SalesNoteType_ID;
                    dgvDetail["NoteTypeName", iRow].Value = detail.SalesNoteName;
                    dgvDetail["GL_ID", iRow].Value = detail.Gl_ID;
                    dgvDetail["GLName", iRow].Value = clsGenaralName.getName_AccountName(detail.Gl_ID);
                }
            }
        }
        #endregion

        #region Search Methods
        private void txt_Acc_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                lstParameeters.Add("%");
                lstParameeters.Add("");
                lstParameeters.Add("-");

                frmSearch RowDataSearch = new frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.AccName);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    (sender as TextBox).Tag = lstResult[0];
                    (sender as TextBox).Text = lstResult[1];
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
                //MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";

                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                if (sColName == "GLName")
                {
                    List<string> lstParameeters = new List<string>();
                    lstParameeters.Add("%");
                    lstParameeters.Add("");
                    lstParameeters.Add("-");

                    frmSearch RowDataSearch = new frmSearch(lstParameeters);
                    List<string> lstResult = RowDataSearch.Show(Search.AccName);
                    if (RowDataSearch.DialogResult == DialogResult.OK)
                    {
                        dgvDetail["GL_ID", e.RowIndex].Value = lstResult[0];
                        dgvDetail["GLName", e.RowIndex].Value = lstResult[1];
                    }
                }
            }
        }

        private void dgvCompanyBranch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";

                if (e.ColumnIndex >= 0)
                    sColName = dgvCompanyBranch.Columns[e.ColumnIndex].Name;

                if (sColName == "SalesAccGL" || sColName == "CashGL" || sColName == "CardGL" || sColName == "ChequeGL" || sColName == "AdvGL" || sColName == "CRN_GL")
                {
                    List<string> lstParameeters = new List<string>();
                    lstParameeters.Add("%");
                    lstParameeters.Add("");
                    lstParameeters.Add("-");

                    frmSearch RowDataSearch = new frmSearch(lstParameeters);
                    List<string> lstResult = RowDataSearch.Show(Search.AccName);
                    if (RowDataSearch.DialogResult == DialogResult.OK)
                    {
                        if (sColName == "SalesAccGL")
                        {
                            dgvCompanyBranch["SalesAccGL_Id", e.RowIndex].Value = lstResult[0];
                            dgvCompanyBranch["SalesAccGL", e.RowIndex].Value = lstResult[1];
                        }
                        if (sColName == "CashGL")
                        {
                            dgvCompanyBranch["CashGL_ID", e.RowIndex].Value = lstResult[0];
                            dgvCompanyBranch["CashGL", e.RowIndex].Value = lstResult[1];
                        }
                        if (sColName == "CardGL")
                        {
                            dgvCompanyBranch["CardGL_ID", e.RowIndex].Value = lstResult[0];
                            dgvCompanyBranch["CardGL", e.RowIndex].Value = lstResult[1];
                        }
                        if (sColName == "ChequeGL")
                        {
                            dgvCompanyBranch["ChqGL_ID", e.RowIndex].Value = lstResult[0];
                            dgvCompanyBranch["ChequeGL", e.RowIndex].Value = lstResult[1];
                        }
                        if (sColName == "AdvGL")
                        {
                            dgvCompanyBranch["AdvGL_ID", e.RowIndex].Value = lstResult[0];
                            dgvCompanyBranch["AdvGL", e.RowIndex].Value = lstResult[1];
                        }
                        if (sColName == "CRN_GL")
                        {
                            dgvCompanyBranch["CRN_GL_ID", e.RowIndex].Value = lstResult[0];
                            dgvCompanyBranch["CRN_GL", e.RowIndex].Value = lstResult[1];
                        }
                    }
                }
            }
        }

        private void txt_ICTGT_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_AccountType2(txt_ICTGT, null, "", false);
        }

        #endregion

        #region Check box event
        private void chkEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnable.Checked)
                txtDiscount.Enabled = true;
            else
            {
                txtDiscount.Enabled = false;
                txtDiscount.Tag = "default";
                txtDiscount.Text = "<<All Account>>";
            }
        }
        #endregion

        private void rdoNoteType_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNoteType.Checked)
            {
                pnlSalesNote.Visible = true;
                dgvDetail.Enabled = true;
                RefreshGridInvoice();
            }
            else
            {
                pnlSalesNote.Visible = false;
                dgvDetail.Enabled = false;
            }
        }
    }
}