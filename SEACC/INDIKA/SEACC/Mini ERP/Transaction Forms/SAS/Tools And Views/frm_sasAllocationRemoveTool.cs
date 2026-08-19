using DataTire;
using Digiteq_Logic;
using SEACC.DATA.Data.BSS;
using SEACC.WinFormControls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Digiteq
{
    public partial class frm_sasAllocationRemoveTool : MettroForm
    {
        public int iFormID = 0;
        public bool bNoAccess = false;

        DebterSettlement odata = new DebterSettlement();
        DataTable dt = new DataTable();

        public frm_sasAllocationRemoveTool()
        {
            iFormID = clsSecurity.getFormID(FormName.sasAllocationRemove);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();

            dt.Columns.Add("settled_ID");
            dt.Columns.Add("SettledDate");
            dt.Columns.Add("settledAmount");
            dt.Columns.Add("invoice_ID");
            dt.Columns.Add("receipt_ID");
            dt.Columns.Add("creditNote_ID");
            dt.Columns.Add("journalEntry_ID_CR");
            dt.Columns.Add("journalEntry_ID_DR");   
            dt.Columns.Add("chequeNumber");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult msgResult = MessageBox.Show("Do You Want To Remove selected Settlement? ", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msgResult == DialogResult.Yes)
            {
                try
                {
                    if (dgvDetail.SelectedRows.Count > 0)
                    {
                        var settled_ID = dgvDetail.SelectedRows[0].Cells["settled_ID"].Value.ToString();
                        if (settled_ID != "default")
                        {
                            var result = odata.Remove_DebterSettlemet(settled_ID);
                            if (result.IsSuccess)
                            {
                                if (result.ReturnValue != null && result.ReturnValue != "default")
                                    clsMethods_GL.GLPosting_Delete(result.ReturnValue);

                                MessageBox.Show("The settlements has been removed successfully......!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Cursor = Cursors.Default;
                                ClearFields();
                            }
                            else
                                MessageBox.Show(result.OutMsg);
                        }
                    }
                    else
                        MessageBox.Show("Please Select a record to  Remove", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID, ex);
                    SEACCException.Show(ex);
                }
            }

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void frm_sasAllocationRemoveTool_Load(object sender, EventArgs e)
        {
            ClearFields();
            clsFormatter.ApplyGridFormat(dgvDetail);
            dgvDetail.ScrollBars = ScrollBars.Both;
        }


        #region Field Clear
        private void ClearFields()
        {
            txtReceiptID.Text = "";
            txtReceiptID.Tag = null;
            txtInvoiceNo.Text = "";
            txtInvoiceNo.Tag = null;
            txtCreaditNoteNo.Text = "";
            txtCreaditNoteNo.Tag = null;
            txtJE_CR.Text = "";
            txtJE_CR.Tag = null;
            txtJE_DR.Text = "";
            txtJE_DR.Tag = null;

            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtReceiptID, true);
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtInvoiceNo, true);
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCreaditNoteNo, true);
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtJE_CR, true);
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtJE_DR, true);

            dgvDetail.DataSource = dt;
        }
        #endregion

        #region Fill Grids
        private void RefreshGrid()
        {
            string invoice_ID = txtInvoiceNo.Tag != null ? txtInvoiceNo.Tag.ToString() : "";
            string journalEntry_ID_DR = txtJE_DR.Tag != null ? txtJE_DR.Tag.ToString() : "";
            string receipt_ID = txtReceiptID.Tag != null ? txtReceiptID.Tag.ToString() : "";
            string creditNote_ID = txtCreaditNoteNo.Tag != null ? txtCreaditNoteNo.Tag.ToString() : "";
            string journalEntry_ID_CR = txtJE_CR.Tag != null ? txtJE_CR.Tag.ToString() : "";
            string Cheque = textBox1.Tag != null ? textBox1.Tag.ToString() : "";

            var result = odata.Get_DebterSettlemet(invoice_ID, journalEntry_ID_DR, receipt_ID, creditNote_ID, journalEntry_ID_CR, Cheque);
            if (result != null)
                dgvDetail.DataSource = Cast.ToDataTables(result);
            else
                dgvDetail.DataSource = dt;
        }

        #endregion
        private void txtReceiptID_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            clsSearch.Search_TransactionReceipt_Direct(ref txtReceiptID, false,rdoSales.Checked, false, clsConfig.bEnableReceiptSort_ByReceiptID);
            if (txtReceiptID.TextLength > 0)
                RefreshGrid();

        }
        private void txtCreaditNoteNo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            clsSearch.Search_TransactionCreditNote_Direct(ref txtCreaditNoteNo, true);
            if (txtCreaditNoteNo.TextLength > 0)
                RefreshGrid();

        }

        private void txtInvoiceNo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            clsSearch.Search_TransactionInvoice_Direct(ref txtInvoiceNo, true, false, false);
            if (txtInvoiceNo.TextLength > 0)
                RefreshGrid();

        }

        private void txtJE_DR_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            clsSearch.Search_TransactionJournalVoucher_Direct(ref txtJE_DR, true);
            if (txtJE_DR.TextLength > 0)
                RefreshGrid();
        }

        private void txtJE_CR_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            clsSearch.Search_TransactionJournalVoucher_Direct(ref txtJE_CR, true);
            if (txtJE_CR.TextLength > 0)
                RefreshGrid();

        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            clsSearch.Search_TransactionCheque_Direct(ref textBox1, true);
            if (textBox1.TextLength > 0)
                RefreshGrid();
        }
    }
}