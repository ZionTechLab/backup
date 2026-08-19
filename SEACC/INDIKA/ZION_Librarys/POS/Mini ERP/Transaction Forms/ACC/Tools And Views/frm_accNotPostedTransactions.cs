using DataTire;
using Digiteq_Logic;
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
    public partial class frm_accNotPostedTransactions : MettroForm
    {
        #region Variables
        //to manage update and insert
        static bool IsUpdate = false;

        //form manage
        string sFormConfigCode;
        public int iFormID;

        //for security handle
        public bool bNoAccess;
        #endregion

        #region Form Load
        public frm_accNotPostedTransactions()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.accNotPostedTransactions);
            iFormID = clsSecurity.getFormID(FormName.accNotPostedTransactions);

            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;
            InitializeComponent();
        }

        private void frm_accNotPostedTransactions_Load(object sender, EventArgs e)
        {
            ThemeColor = clsFormatter.colorAccounts;
            //format Form
            clsFormatter.setFormatForm(this, "Not Posted Transactions", 2, iFormID);
            ClearFields();
        }
        #endregion        

        #region Btn New
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Button Search Click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            lblCount.Text = "";

            if (txtNoteType.Tag != null)
            {
                string sNoteID = txtNoteType.Tag.ToString();
                RefreshGrid(int.Parse(sNoteID));
            }
            else
                RefreshGrid(0);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(int iNoteType)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                int iRow;
                dgvDetail.Rows.Clear();
                int iCount = 0;

                #region                                                          

                #region Advanced Receipt [Cash] 3
                if (iNoteType == 3 || iNoteType == 0)
                {
                    foreach (tbl_bpsReceipt detail in tbl_bpsReceipt.SelectAll().Where(p => p.ReceiptDate.Date >= dtpFrom.Value.Date && p.ReceiptDate.Date <= dtpTo.Value.Date && p.PostingStatus_ID != "PS/004" && !p.IsDeleted
                                && p.IsAdvance && p.CashAmount > 0).OrderBy(o => o.ReceiptDate))
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["NoteID", iRow].Value = 3;
                        dgvDetail["Note", iRow].Value = clsGenaralName.getName_AcctSlotName(3);
                        dgvDetail["TransactionID", iRow].Value = detail.Receipt_ID;
                        dgvDetail["Date", iRow].Value = clsFormatter.FormatDate_Short(detail.ReceiptDate);
                        dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.CashAmount);
                        dgvDetail["Status", iRow].Value = clsGenaralName.GetPostingStatusName(detail.PostingStatus_ID);

                    }
                }
                #endregion

                #region Part/Final Payment Receipt [Cash] 4
                if (iNoteType == 4 || iNoteType == 0)
                {
                    foreach (tbl_bpsReceipt detail in tbl_bpsReceipt.SelectAll().Where(p => p.ReceiptDate.Date >= dtpFrom.Value.Date && p.ReceiptDate.Date <= dtpTo.Value.Date && p.PostingStatus_ID != "PS/004" && !p.IsDeleted && !p.IsAdvance && p.CashAmount > 0).OrderBy(o => o.ReceiptDate))
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["NoteID", iRow].Value = 4;
                        dgvDetail["Note", iRow].Value = clsGenaralName.getName_AcctSlotName(4);
                        dgvDetail["TransactionID", iRow].Value = detail.Receipt_ID;
                        dgvDetail["Date", iRow].Value = clsFormatter.FormatDate_Short(detail.ReceiptDate);
                        dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.CashAmount);
                        dgvDetail["Status", iRow].Value = clsGenaralName.GetPostingStatusName(detail.PostingStatus_ID);
                    }
                }
                #endregion

                #region Advanced Receipt [Cheque] 5
                if (iNoteType == 5 || iNoteType == 0)
                {
                    //foreach (tbl_bpsChequeRegister detail in tbl_bpsChequeRegister.SelectAll().Where(p => p.DateRegister.Date >= dtpFrom.Value.Date && p.DateRegister.Date <= dtpTo.Value.Date && p.PostingStatus_ID != "PS/004" && !p.IsDeleted).OrderBy(o => o.DateRegister))
                    //{
                    //    tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(detail.Receipt_ID);
                    //    if (oReceipt != null && oReceipt.IsAdvance && oReceipt.ChequeAmount > 0)
                    //    {
                    foreach (tbl_bpsReceipt detail in tbl_bpsReceipt.SelectAll().Where(p => p.ReceiptDate.Date >= dtpFrom.Value.Date && p.ReceiptDate.Date <= dtpTo.Value.Date && p.PostingStatus_ID != "PS/004" && !p.IsDeleted
                                && p.IsAdvance && p.ChequeAmount > 0).OrderBy(o => o.ReceiptDate))
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["NoteID", iRow].Value = 5;
                        dgvDetail["Note", iRow].Value = clsGenaralName.getName_AcctSlotName(5);
                        dgvDetail["TransactionID", iRow].Value = detail.Receipt_ID;
                        dgvDetail["Date", iRow].Value = clsFormatter.FormatDate_Short(detail.ReceiptDate);
                        dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.ChequeAmount);
                        dgvDetail["Status", iRow].Value = clsGenaralName.GetPostingStatusName(detail.PostingStatus_ID);
                    }
                    //}
                }
                #endregion

                #region Part/Final Payment Receipt [Cheque] 6
                if (iNoteType == 6 || iNoteType == 0)
                {
                    //foreach (tbl_bpsChequeRegister detail in tbl_bpsChequeRegister.SelectAll().Where(p => p.DateRegister.Date >= dtpFrom.Value.Date && p.DateRegister.Date <= dtpTo.Value.Date && p.PostingStatus_ID != "PS/004" && !p.IsDeleted).OrderBy(o => o.DateRegister))
                    //{
                    //    tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(detail.Receipt_ID);
                    //    if (oReceipt != null && !oReceipt.IsAdvance && oReceipt.ChequeAmount > 0)
                    //    {

                    foreach (tbl_bpsReceipt detail in tbl_bpsReceipt.SelectAll().Where(p => p.ReceiptDate.Date >= dtpFrom.Value.Date && p.ReceiptDate.Date <= dtpTo.Value.Date && p.PostingStatus_ID != "PS/004" && !p.IsDeleted
                                && !p.IsAdvance && p.ChequeAmount > 0).OrderBy(o => o.ReceiptDate))
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["NoteID", iRow].Value = 6;
                        dgvDetail["Note", iRow].Value = clsGenaralName.getName_AcctSlotName(6);
                        dgvDetail["TransactionID", iRow].Value = detail.Receipt_ID;
                        dgvDetail["Date", iRow].Value = clsFormatter.FormatDate_Short(detail.ReceiptDate);
                        dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.ChequeAmount);
                        dgvDetail["Status", iRow].Value = clsGenaralName.GetPostingStatusName(detail.PostingStatus_ID);
                    }
                    //}
                }
                #endregion

                #region Payment Voucher 7
                if (iNoteType == 7 || iNoteType == 0)
                {
                    foreach (tbl_accPaymentVoucher detail in tbl_accPaymentVoucher.SelectAll().Where(p => p.PaymentVoucherDate.Date >= dtpFrom.Value.Date && p.PaymentVoucherDate.Date <= dtpTo.Value.Date && p.PostingStatus_ID != "PS/004" && !p.IsDeleted).OrderBy(o => o.PaymentVoucherDate))
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["NoteID", iRow].Value = 7;
                        dgvDetail["Note", iRow].Value = clsGenaralName.getName_AcctSlotName(7);
                        dgvDetail["TransactionID", iRow].Value = detail.PaymentVoucher_ID;
                        dgvDetail["Date", iRow].Value = clsFormatter.FormatDate_Short(detail.PaymentVoucherDate);
                        dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.TotalAmount);
                        dgvDetail["Status", iRow].Value = clsGenaralName.GetPostingStatusName(detail.PostingStatus_ID);
                    }
                }
                #endregion

                #region Account Receipt 8
                if (iNoteType == 8 || iNoteType == 0)
                {
                    foreach (tbl_accAccountReceipt detail in tbl_accAccountReceipt.SelectAll().Where(p => p.AccountReceiptDate.Date >= dtpFrom.Value.Date && p.AccountReceiptDate.Date <= dtpTo.Value.Date && p.PostingStatus_ID != "PS/004" && !p.IsDeleted).OrderBy(o => o.AccountReceiptDate))
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["NoteID", iRow].Value = 8;
                        dgvDetail["Note", iRow].Value = clsGenaralName.getName_AcctSlotName(8);
                        dgvDetail["TransactionID", iRow].Value = detail.AccountReceipt_ID;
                        dgvDetail["Date", iRow].Value = clsFormatter.FormatDate_Short(detail.AccountReceiptDate);
                        dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.TotalAmount);
                        dgvDetail["Status", iRow].Value = clsGenaralName.GetPostingStatusName(detail.PostingStatus_ID);
                    }
                }
                #endregion

                #region Account Payable Note 9
                if (iNoteType == 9 || iNoteType == 0)
                {
                    foreach (tbl_accAccountPayableNote detail in tbl_accAccountPayableNote.SelectAll().Where(p => p.AccountPayableNoteDate.Date >= dtpFrom.Value.Date && p.AccountPayableNoteDate.Date <= dtpTo.Value.Date && p.PostingStatus_ID != "PS/004" && !p.IsDeleted).OrderBy(o => o.AccountPayableNoteDate))
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["NoteID", iRow].Value = 9;
                        dgvDetail["Note", iRow].Value = clsGenaralName.getName_AcctSlotName(9);
                        dgvDetail["TransactionID", iRow].Value = detail.AccountPayableNote_ID;
                        dgvDetail["Date", iRow].Value = clsFormatter.FormatDate_Short(detail.AccountPayableNoteDate);
                        dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.GrandTotal);
                        dgvDetail["Status", iRow].Value = clsGenaralName.GetPostingStatusName(detail.PostingStatus_ID);
                    }
                }
                #endregion

                #region Supplier Debit Note (DBN) 29
                if (iNoteType == 29 || iNoteType == 0)
                {
                    foreach (tbl_accDebitNote detail in tbl_accDebitNote.SelectAll().Where(p => p.DebitNote_Date.Date >= dtpFrom.Value.Date && p.DebitNote_Date.Date <= dtpTo.Value.Date && p.PostingStatus_ID != "PS/004" && !p.IsDeleted).OrderBy(o => o.DebitNote_Date))
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["NoteID", iRow].Value = 29;
                        dgvDetail["Note", iRow].Value = clsGenaralName.getName_AcctSlotName(29);
                        dgvDetail["TransactionID", iRow].Value = detail.DebitNote_ID;
                        dgvDetail["Date", iRow].Value = clsFormatter.FormatDate_Short(detail.DebitNote_Date);
                        dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.GrandTotal);
                        dgvDetail["Status", iRow].Value = clsGenaralName.GetPostingStatusName(detail.PostingStatus_ID);
                    }
                }
                #endregion

                #region Debit Note (DBN) 11
                if (iNoteType == 11 || iNoteType == 0)
                {
                    foreach (tbl_bpsDebitNote detail in tbl_bpsDebitNote.SelectAll().Where(p => p.DebitNoteDate.Date >= dtpFrom.Value.Date && p.DebitNoteDate.Date <= dtpTo.Value.Date && p.PostingStatus_ID != "PS/004" && !p.IsDeleted).OrderBy(o => o.DebitNoteDate))
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["NoteID", iRow].Value = 11;
                        dgvDetail["Note", iRow].Value = clsGenaralName.getName_AcctSlotName(11);
                        dgvDetail["TransactionID", iRow].Value = detail.DebitNote_ID;
                        dgvDetail["Date", iRow].Value = clsFormatter.FormatDate_Short(detail.DebitNoteDate);
                        dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.TotalAmount);
                        dgvDetail["Status", iRow].Value = clsGenaralName.GetPostingStatusName(detail.PostingStatus_ID);
                    }
                }
                #endregion

                #region Credit Note (CRN) 12
                if (iNoteType == 12 || iNoteType == 0)
                {
                    foreach (tbl_bpsCreditNote detail in tbl_bpsCreditNote.SelectAll().Where(p => p.CreditNoteDate.Date >= dtpFrom.Value.Date && p.CreditNoteDate.Date <= dtpTo.Value.Date && p.PostingStatus_ID != "PS/004" && !p.IsDeleted ).OrderBy(o => o.CreditNoteDate))
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["NoteID", iRow].Value = 12;
                        dgvDetail["Note", iRow].Value = clsGenaralName.getName_AcctSlotName(12);
                        dgvDetail["TransactionID", iRow].Value = detail.CreditNote_ID;
                        dgvDetail["Date", iRow].Value = clsFormatter.FormatDate_Short(detail.CreditNoteDate);
                        dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.TotalAmount);
                        dgvDetail["Status", iRow].Value = clsGenaralName.GetPostingStatusName(detail.PostingStatus_ID);
                    }
                }
                #endregion

                #region Cash Deposite 25
                if (iNoteType == 25 || iNoteType == 0)
                {
                    foreach (tbl_bpsReceipt detail in tbl_bpsReceipt.SelectAll().Where(p => p.ReceiptDate.Date >= dtpFrom.Value.Date && p.ReceiptDate.Date <= dtpTo.Value.Date && p.PostingStatus_ID != "PS/004" && !p.IsDeleted
                                && p.CashAmount > 0 && p.IsCashDeposited).OrderBy(o => o.ReceiptDate))
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["NoteID", iRow].Value = 25;
                        dgvDetail["Note", iRow].Value = clsGenaralName.getName_AcctSlotName(25);
                        dgvDetail["TransactionID", iRow].Value = detail.Receipt_ID;
                        dgvDetail["Date", iRow].Value = clsFormatter.FormatDate_Short(detail.ReceiptDate);
                        dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.TotalAmount);
                        dgvDetail["Status", iRow].Value = clsGenaralName.GetPostingStatusName(detail.PostingStatus_ID);
                    }
                }
                #endregion

                #region Cheque Deposited 13
                if (iNoteType == 13 || iNoteType == 0)
                {
                    foreach (tbl_bpsChequeRegister detail in tbl_bpsChequeRegister.SelectAll().Where(p => p.DateRegister.Date >= dtpFrom.Value.Date && p.DateRegister.Date <= dtpTo.Value.Date && p.PostingStatus_ID != "PS/004" && !p.IsDeleted
                                && p.DepositCount == 1 && p.IsDepositted).OrderBy(o => o.DateRegister))
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["NoteID", iRow].Value = 13;
                        dgvDetail["Note", iRow].Value = clsGenaralName.getName_AcctSlotName(13);
                        dgvDetail["TransactionID", iRow].Value = detail.ChequeRegister_ID;
                        dgvDetail["Date", iRow].Value = clsFormatter.FormatDate_Short(detail.DateRegister);
                        dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.Amount);
                        dgvDetail["Status", iRow].Value = clsGenaralName.GetPostingStatusName(detail.PostingStatus_ID);
                    }
                }
                #endregion                             

                #region Cheque Returned 28
                if (iNoteType == 28 || iNoteType == 0)
                {
                    foreach (tbl_bpsChequeRegister detail in tbl_bpsChequeRegister.SelectAll().Where(p => p.DateRegister.Date >= dtpFrom.Value.Date && p.DateRegister.Date <= dtpTo.Value.Date && p.PostingStatus_ID != "PS/004" && !p.IsDeleted
                                && (p.ChequeStatus_ID == "4" || p.ChequeStatus_ID == "5" || p.ChequeStatus_ID == "6" || p.ChequeStatus_ID == "8") && p.IsReturned).OrderBy(o => o.DateRegister))
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["NoteID", iRow].Value = 28;
                        dgvDetail["Note", iRow].Value = clsGenaralName.getName_AcctSlotName(28);
                        dgvDetail["TransactionID", iRow].Value = detail.ChequeRegister_ID;
                        dgvDetail["Date", iRow].Value = clsFormatter.FormatDate_Short(detail.DateRegister);
                        dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.Amount);
                        dgvDetail["Status", iRow].Value = clsGenaralName.GetPostingStatusName(detail.PostingStatus_ID);
                    }
                }
                #endregion

                #region Cheque ReDeposited 34
                if (iNoteType == 34 || iNoteType == 0)
                {
                    foreach (tbl_bpsChequeRegister detail in tbl_bpsChequeRegister.SelectAll().Where(p => p.DateRegister.Date >= dtpFrom.Value.Date && p.DateRegister.Date <= dtpTo.Value.Date && p.PostingStatus_ID != "PS/004" && !p.IsDeleted
                                && p.DepositCount > 1 && p.IsDepositted).OrderBy(o => o.DateRegister))
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["NoteID", iRow].Value = 34;
                        dgvDetail["Note", iRow].Value = clsGenaralName.getName_AcctSlotName(34);
                        dgvDetail["TransactionID", iRow].Value = detail.ChequeRegister_ID;
                        dgvDetail["Date", iRow].Value = clsFormatter.FormatDate_Short(detail.DateRegister);
                        dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.Amount);
                        dgvDetail["Status", iRow].Value = clsGenaralName.GetPostingStatusName(detail.PostingStatus_ID);
                    }
                }
                #endregion

                #region Standard Journal Entry (JV) 17
                if (iNoteType == 17 || iNoteType == 0)
                {
                    foreach (tbl_accJournalEntry detail in tbl_accJournalEntry.SelectAll().Where(p => p.JournalEntryDate.Date >= dtpFrom.Value.Date && p.JournalEntryDate.Date <= dtpTo.Value.Date && p.PostingStatus_ID != "PS/004" && !p.IsDeleted
                                && p.JournalEntryType_ID == "CON/415").OrderBy(o => o.JournalEntryDate))
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["NoteID", iRow].Value = 17;
                        dgvDetail["Note", iRow].Value = clsGenaralName.getName_AcctSlotName(17);
                        dgvDetail["TransactionID", iRow].Value = detail.JournalEntry_ID;
                        dgvDetail["Date", iRow].Value = clsFormatter.FormatDate_Short(detail.JournalEntryDate);
                        dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.GrandTotal);
                        dgvDetail["Status", iRow].Value = clsGenaralName.GetPostingStatusName(detail.PostingStatus_ID);
                    }
                }
                #endregion

                #region Bank Adjustment Entries (BAE) 19
                if (iNoteType == 19 || iNoteType == 0)
                {
                    foreach (tbl_accJournalEntry detail in tbl_accJournalEntry.SelectAll().Where(p => p.JournalEntryDate.Date >= dtpFrom.Value.Date && p.JournalEntryDate.Date <= dtpTo.Value.Date && p.PostingStatus_ID != "PS/004" && !p.IsDeleted
                                && p.JournalEntryType_ID == "CON/017").OrderBy(o => o.JournalEntryDate))
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["NoteID", iRow].Value = 19;
                        dgvDetail["Note", iRow].Value = clsGenaralName.getName_AcctSlotName(19);
                        dgvDetail["TransactionID", iRow].Value = detail.JournalEntry_ID;
                        dgvDetail["Date", iRow].Value = clsFormatter.FormatDate_Short(detail.JournalEntryDate);
                        dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.GrandTotal);
                        dgvDetail["Status", iRow].Value = clsGenaralName.GetPostingStatusName(detail.PostingStatus_ID);
                    }
                }
                #endregion

                #region Invoice 35
                if (iNoteType == 35 || iNoteType == 0)
                {
                    foreach (tbl_sasInvoice detail in tbl_sasInvoice.SelectAll().Where(p => p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date && p.PostingStatus_ID != "PS/004" && !p.IsDeleted && !p.IsDebitNote && !p.IsReturnedCheque).OrderBy(o => o.InvoiceDate))
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["NoteID", iRow].Value = 35;
                        dgvDetail["Note", iRow].Value = clsGenaralName.getName_AcctSlotName(35);
                        dgvDetail["TransactionID", iRow].Value = detail.Invoice_ID;
                        dgvDetail["Date", iRow].Value = clsFormatter.FormatDate_Short(detail.InvoiceDate);
                        dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.GrandTotal);
                        dgvDetail["Status", iRow].Value = clsGenaralName.GetPostingStatusName(detail.PostingStatus_ID);
                    }
                }
                #endregion

                #region Credit Note (CRN) 12
                if (iNoteType == 42 || iNoteType == 0)
                {
                    foreach(tbl_sasInvoice_Sattled detail in tbl_sasInvoice_Sattled.SelectAll().Where(p=>p.CreditNote_ID!="default"))
                    {}

                    //foreach (tbl_bpsCreditNote detail in tbl_bpsCreditNote.SelectAll().Where(p => p.CreditNoteDate.Date >= dtpFrom.Value.Date && p.CreditNoteDate.Date <= dtpTo.Value.Date && p.PostingStatus_ID != "PS/004" && !p.IsDeleted).OrderBy(o => o.CreditNoteDate))
                    //{
                    //    dgvDetail.Rows.Add();
                    //    iRow = dgvDetail.Rows.Count - 1;
                    //    dgvDetail["NoteID", iRow].Value = 12;
                    //    dgvDetail["Note", iRow].Value = clsGenaralName.getName_AcctSlotName(12);
                    //    dgvDetail["TransactionID", iRow].Value = detail.CreditNote_ID;
                    //    dgvDetail["Date", iRow].Value = clsFormatter.FormatDate_Short(detail.CreditNoteDate);
                    //    dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.TotalAmount);
                    //    dgvDetail["Status", iRow].Value = clsGenaralName.GetPostingStatusName(detail.PostingStatus_ID);
                    //}
                }
                #endregion

                #endregion

                iCount = dgvDetail.RowCount;
                lblCount.Text = iCount.ToString();

                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Clear Method
        private void ClearFields()
        {
            txtNoteType.Tag = null;
            txtNoteType.Text = "";

            dtpFrom.Value = clsSecurity.getServerDateTime();
            dtpTo.Value = clsSecurity.getServerDateTime();

            lblCount.Text = "";
            chkSelectAll.Checked = false;

            dgvDetail.Rows.Clear();
        }
        #endregion

        #region Double Click
        private void txtNoteType_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterAccountSlot(ref txtNoteType);
        }


        #endregion

        private void btnPost_Click(object sender, EventArgs e)
        {
            DialogResult msgResult = MessageBox.Show("Do you want to post selected transactions ?", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (msgResult == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    bool bIsSelected = clsValidate.ValidateGridValue(dgvDetail, "Check", row.Index, "") == "True" ? true : false;
                    if (bIsSelected)
                    {
                        string sTxnCode = clsValidate.ValidateGridValue(dgvDetail, "TransactionID", row.Index, "");
                        int iNoteType = int.Parse(txtNoteType.Tag.ToString());

                        #region  Receipt  3 4 5 6
                        if (iNoteType == 3 || iNoteType == 4 || iNoteType == 5 || iNoteType == 6)
                        {
                            clsMethods_GL.PostTransaction_SalesReciept_Old(sTxnCode);
                            continue;
                        }
                        #endregion

                        #region  Journal  17 19
                        //if (iNoteType == 17 || iNoteType == 19)
                        //{
                        //    clsMethods_Fin.PostTransaction_Journal(sTxnCode);
                        //    break;
                        //}
                        #endregion

                        switch (iNoteType)
                        {
                            case 7:
                                clsMethods_GL.PostTransaction_PV(sTxnCode);
                                break;
                            case 8:
                                clsMethods_GL.PostTransaction_AccountsReciept(sTxnCode);
                                break;
                            case 9:
                                clsMethods_GL.PostTransaction_APN(sTxnCode);
                                break;
                            case 11:
                                clsMethods_GL.PostTransaction_CustomerDBN(sTxnCode);
                                break;
                            //case 12:
                            //    clsMethods_GL.PostTransaction_CustomerCRN(sTxnCode);
                            //    break;
                            //case 13:
                            //    clsMethods_Fin.PostTransaction_chequeDeposit(sTxnCode);
                            //    break;                           
                            //case 25:
                            //    clsMethods_Fin.PostTransaction_cashDeposit(sTxnCode);
                            //    break;
                            //case 28:
                            //    clsMethods_Fin.PostTransaction_chequeReturned(sTxnCode);
                            //    break;
                            case 29:
                                clsMethods_GL.PostTransaction_SuplierDBN(sTxnCode);
                                break;
                            //case 34:
                            //    clsMethods_Fin.PostTransaction_chequeReDeposit(sTxnCode);
                            //    break;
                            case 35:
                                clsMethods_GL.PostTransaction_Invoice(sTxnCode);
                                break;
                            default:
                                Console.WriteLine("Default case");
                                break;
                        }
                        
                    }
                }
                MessageBox.Show("done...!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.Default;
                if (chkSelectAll.Checked)
                    chkSelectAll.Checked = false;
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    chk.Value = true;
                    //chk.Value = !(chk.Value == null ? false : (bool)chk.Value);
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    chk.Value = false;
                    //chk.Value = (chk.Value == null ? false : (bool)chk.Value);
                }
            }
        }
    }
}
