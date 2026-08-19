using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;

namespace Digiteq
{
    public partial class frm_toolUnsetteldRecode : Form
    {        
       public int iFormID;

        public frm_toolUnsetteldRecode()
        {                  
            InitializeComponent();
        }

        #region Form Load
        private void frmQuickLogin_Load(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Login
        private void btnLogon_Click(object sender, EventArgs e)
        {
            DialogResult msgResult = MessageBox.Show("Do You Want To Remove Allocation (Tagging)? ", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msgResult == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor; 

                    #region Receipt Cash
                    if (rdoReceipt.Checked)
                    {
                        clsHelpMethods_Local.RemoveSattlementsFrom_ReceiptID_OnlyCash(txtRecodeID.Text.Trim());
                    }
                    #endregion

                    #region Receipt All
                    if (rdoReceipt_All.Checked)
                    {
                        clsHelpMethods_Local.RemoveSattlementsFrom_ReceiptID_CashAndCheque(txtRecodeID.Text.Trim());
                    }
                    #endregion

                    #region Cheque
                    if (rdoCheque.Checked)
                    {
                        clsHelpMethods_Local.RemoveSattlementsFrom_ChequeID(txtRecodeID.Text.Trim());
                    }
                    #endregion

                    #region Invoice
                    if (rdoInvoice.Checked)
                    {
                        clsHelpMethods_Local.RemoveSattlementsFrom_InvoiceID(txtRecodeID.Text.Trim());
                    }
                    #endregion

                    if (rdoCreditNote.Checked)
                    {
                        clsHelpMethods_Local.RemoveSattlementsFrom_CreditNoteID(txtRecodeID.Text.Trim());
                    }

                    ClearFields();
                    MessageBox.Show("Record Unlocked Successfully.", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID,ex);
                    SEACCException.Show(ex);
                }
                finally
                {
                    Cursor = Cursors.Default;                    
                }
            }
        } 
        #endregion

        #region Btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
        } 
        #endregion
               
        #region Btn Reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            txtRecodeID.Tag = null;
            txtRecodeID.Clear();
            rdoInvoice.Checked = true;
        }
        #endregion

        #region Event Double Click
        private void txtRecodeID_DoubleClick(object sender, EventArgs e)
        {
            if (rdoInvoice.Checked)
                clsSearch.Search_TransactionInvoice_Direct(ref txtRecodeID,true,false,false);
            if (rdoReceipt.Checked || rdoReceipt_All.Checked)
                clsSearch.Search_Receipt(ref txtRecodeID,false);
            if (rdoCheque.Checked)
                clsSearch.Search_TransactionCheque_Direct(ref txtRecodeID, true);
            if (rdoCreditNote.Checked)
                clsSearch.Search_TransactionCreditNote_Direct(ref txtRecodeID, true);
            if (rdoDebit.Checked)
                clsSearch.Search_TransactionDebitNote_Direct(ref txtRecodeID, true, false, false);
        } 
        #endregion

        #region Event KeyDown
        private void txtRecodeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (rdoInvoice.Checked)
                    clsSearch.Search_TransactionInvoice_Direct(ref txtRecodeID, true,false,false);
                if (rdoReceipt.Checked || rdoReceipt_All.Checked)
                    clsSearch.Search_Receipt(ref txtRecodeID,false);
                if (rdoCheque.Checked)
                    clsSearch.Search_TransactionCheque_Direct(ref txtRecodeID, true);
                if (rdoCreditNote.Checked)
                    clsSearch.Search_TransactionCreditNote_Direct(ref txtRecodeID, true);
                if (rdoDebit.Checked)
                    clsSearch.Search_TransactionDebitNote_Direct(ref txtRecodeID, true, false, false);
            }
        } 
        #endregion        

    }
}
