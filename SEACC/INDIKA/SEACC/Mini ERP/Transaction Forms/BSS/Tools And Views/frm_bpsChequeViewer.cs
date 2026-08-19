using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;

namespace Digiteq
{
    public partial class frm_bpsChequeViewer : Form
    {
        public string glbChequeRegisterID = "";

        #region Form Load
        public frm_bpsChequeViewer()
        {
            InitializeComponent();
            //FillDetails(detail.RegisterID);
        }

        private void frm_bpsChequeViewer_Load(object sender, EventArgs e)
        {
            ClearFields();
            if (glbChequeRegisterID.Length > 0)
                FillDetails(glbChequeRegisterID);
        } 
        #endregion

        #region  Fill Details
        private void FillDetails(string sChequeRegisterID)
        {

            tbl_bpsChequeRegister ChequeRegister = tbl_bpsChequeRegister.Select(sChequeRegisterID);
            if (ChequeRegister != null)
            {
                #region Header
                lblChequeNo.Text = ChequeRegister.ChequeNumber;
                lblChequeDate.Text = ChequeRegister.DateCheque.ToString("dd MMM yyyy");
                lblChequeAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(ChequeRegister.Amount);
                lblAccouNo.Text = ChequeRegister.AccountNumber;
            //    lblChequeStatus.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ChequeStatus(ChequeRegister.ChequeStatus_ID));
                lblBankName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Bank(ChequeRegister.Bank_ID));
            //    lblBranchName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_BankBranch(ChequeRegister.Branch_ID));
                #endregion

                #region Cheque Register
                lblRegisterCode.Text = ChequeRegister.ChequeRegister_ID;
            //    lblRegisterDate.Text = ChequeRegister.DateRegister.ToString("dd MMM yyyy"); 
                lblReceiptNo.Text = ChequeRegister.Receipt_ID;
                tbl_bpsReceipt Receipt = tbl_bpsReceipt.Select(ChequeRegister.Receipt_ID);
                if (Receipt != null)
                    lblReceiptDate.Text = Receipt.ReceiptDate.ToString("dd MMM yyyy");

                lblCustomerName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(ChequeRegister.Customer_ID));
             //   lblCreateUser.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(ChequeRegister.CreateUser_ID));
             //   lblInvoiceNo.Text = clsCommon.GetForeignKeyValue(ChequeRegister.Invoice_ID);
                tbl_sasInvoice Invoice = tbl_sasInvoice.Select(ChequeRegister.Invoice_ID);
                if (Invoice != null)
                {
               //     lblInvoiceDate.Text = Invoice.InvoiceDate.ToString("dd MMM yyyy");
                //    lblQuotationNo.Text = clsCommon.GetForeignKeyValue(Invoice.Quotation_ID);
                }
                tbl_sasQuotation Quotation = tbl_sasQuotation.Select(Invoice.Quotation_ID);
                //    if (Quotation != null)
                //  lblQuotationDate.Text = Quotation.QuotationDate.ToString("dd MMM yyyy");

                #endregion

                dataGridView1 .DataSource = DBHandling.ExecQuery("Exec sp_ChequeViewer '"+ ChequeRegister.ChequeRegister_ID+"'").Tables[0];



                #region Cheque Deposit
                string sDepositID = "", sDepositDate = "", sAccountNo = "", sDepositBankName = "", sDepositBranchName = "", sDepositCreateUser = "";
                List<tbl_bpsChequeDeposit_Detail> Depositdetails = tbl_bpsChequeDeposit_Detail.SelectAllByChequeRegister_ID(sChequeRegisterID);
                foreach (tbl_bpsChequeDeposit_Detail Depositdetail in Depositdetails)
                {
                    tbl_bpsChequeDeposit Deposit = tbl_bpsChequeDeposit.Select(Depositdetail.ChequeDeposit_ID);
                    if (Deposit != null)
                    {
                        sDepositID = clsCommon.GetForeignKeyValue(Deposit.ChequeDeposit_ID);
                        sDepositDate = Deposit.DateDeposit.ToString("dd MMM yyyy");
                        sAccountNo = Deposit.AccountNumber.ToString();
                        sDepositBankName = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Bank(Deposit.Bank_ID));
                        sDepositBranchName = clsCommon.GetForeignKeyValue(clsGenaralName.getName_BankBranch(Deposit.Branch_ID));
                        sDepositCreateUser = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(Deposit.CreateUser_ID));
                    }
                }

              //  lblDepositID.Text = sDepositID;
              //  lblDepositDate.Text = sDepositDate;
            //    lblAccountNo.Text = sAccountNo;
            //   lblDepositBankName.Text = sDepositBankName;
             //   lblDepositBranchName.Text = sDepositBranchName;
             //   lblDepositCreateUser.Text = sDepositCreateUser;
                #endregion

                #region Cheque Reconcilate
                string sReconcilateID = "", sReconcilateDate = "", sReconsilationCreateUser = "";
                List<tbl_bpsChequeReconciliation_Detail> Reconciliation_Details = tbl_bpsChequeReconciliation_Detail.SelectAllByChequeRegister_ID(sChequeRegisterID);
                foreach (tbl_bpsChequeReconciliation_Detail Reconciliation_Detail in Reconciliation_Details)
                {
                    tbl_bpsChequeReconciliation Reconciliation = tbl_bpsChequeReconciliation.Select(Reconciliation_Detail.Reconciliation_ID);
                    if (Reconciliation != null)
                    {
                        sReconcilateID = clsCommon.GetForeignKeyValue(Reconciliation.Reconciliation_ID);
                        sReconcilateDate = Reconciliation.DateReconciliation.ToString("dd MMM yyyy");
                        sReconsilationCreateUser = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(Reconciliation.CreateUser_ID));
                    }
                }
             //   lblReconcilateID.Text = sReconcilateID;
             //   lblReconcilateDate.Text = sReconcilateDate;
             //   lblReconsilationCreateUser.Text = sReconsilationCreateUser;
             //   lblPanaltyAmt.Text = clsFormatter.FormatToCurrecyWithThousendSep(ChequeRegister.PaneltyAmount);
            //    lblReconsilationChequeStatus.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ChequeStatus(ChequeRegister.ChequeStatus_ID));
                #endregion

            }
        }
        #endregion

        #region Btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            lblRegisterCode.Text = "";
        //    lblRegisterDate.Text = "";
            lblReceiptNo.Text = "";
            lblReceiptDate.Text = "";
         //   lblQuotationNo.Text = "";
          //  lblQuotationDate.Text = "";
            lblCustomerName.Text = "";
          //  lblCreateUser.Text = "";
          //  lblInvoiceNo.Text = "";
          //  lblInvoiceDate.Text = "";
            lblChequeDate.Text = "";
            lblChequeAmount.Text = "";
            lblAccouNo.Text = "";
         //   lblChequeStatus.Text = "";
            lblBankName.Text = "";
          //  lblDepositID.Text = "";
          //  lblDepositDate.Text = "";
          //  lblAccountNo.Text = "";
          //  lblDepositBankName.Text = "";
          //  lblDepositBranchName.Text = "";
           // lblReconcilateID.Text = "";
          //  lblReconcilateDate.Text = "";
          //  lblReconsilationChequeStatus.Text = "";
          //  lblReconsilationCreateUser.Text = "";
         //   lblPanaltyAmt.Text = "";
         //   lblBranchName.Text = "";
         //   lblSettalment.Text = "";
          //  lblDepositCreateUser.Text = "";
        }
        #endregion

        #region Btn Refresh
        private void Refresh_Click(object sender, EventArgs e)
        {
            ClearFields();
            if (glbChequeRegisterID.Length > 0)
                FillDetails(glbChequeRegisterID);
        } 
        #endregion

    }
}
