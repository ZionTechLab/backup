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
    public partial class frm_sasViewerInvoice : Form
    {
        

           public int iFormID;
        public bool bNoAccess;
        public string glbCustomerID = "";
 

        #region Form Load
        public frm_sasViewerInvoice()
        {
            iFormID = clsSecurity.getFormID(FormName.ViewerCombinationMaterial);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_bpsChequeViewer_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "", 2, iFormID);
            ClearFields();
        } 
        #endregion

        #region Refresh Grid
        private void RefreshReceiptGridByInvoiceID(string sinvoiceID)
        {
            try
            {
                int iRow;
                dgvAccounts.Rows.Clear();
                List<tbl_bpsReceipt> details = tbl_bpsReceipt.SelectAllByInvoice_ID(sinvoiceID);
                foreach (tbl_bpsReceipt detail in details)
                {
                    if (detail.Receipt_ID != "default")
                    {

                        dgvAccounts.Rows.Add();
                        iRow = dgvAccounts.Rows.Count - 1;
                        dgvAccounts["ReceiptDate", iRow].Value = detail.ReceiptDate.GetDateTimeFormats()[3]; ;
                        dgvAccounts["Receipt_ID", iRow].Value = detail.Receipt_ID;
                        dgvAccounts["Amount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(detail.TotalAmount);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }

        }
        private void RefreshChequeRegisterGridByInvoiceID(string sinvoiceID)
        {
            try
            {
                int iRow;
                dgvReconciliation.Rows.Clear();
                List<tbl_bpsChequeRegister> details = tbl_bpsChequeRegister.SelectAllByReceipt_ID(sinvoiceID);
                foreach (tbl_bpsChequeRegister detail in details)
                {
                    if (detail.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                    {
                        if (detail.Receipt_ID != "default")
                        {

                            dgvReconciliation.Rows.Add();
                            iRow = dgvReconciliation.Rows.Count - 1;
                            dgvReconciliation["ChequeDate", iRow].Value = detail.DateRegister.GetDateTimeFormats()[3]; ;
                            dgvReconciliation["RChequeNo", iRow].Value = detail.ChequeNumber;
                            dgvReconciliation["RAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(detail.Amount);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void InvoiceSattlementRefreshGridBy(string sinvoiceID)
        {
            try
            {
                int iRow;
                decimal dbalance = 0;
                dgvSattledmentDetail.Rows.Clear();
                List<tbl_sasInvoice_Sattled> details = tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(sinvoiceID);
                foreach (tbl_sasInvoice_Sattled detail in details)
                {
                    if (detail.Invoice_ID != "default")
                    {

                        dgvSattledmentDetail.Rows.Add();
                        iRow = dgvSattledmentDetail.Rows.Count - 1;

                        tbl_sasInvoice InvoiceDetail = tbl_sasInvoice.Select(detail.Invoice_ID);


                        dgvSattledmentDetail["SettlementDate", iRow].Value = detail.SattledDate.GetDateTimeFormats()[3]; ;
                        dgvSattledmentDetail["InvoiceAmount", iRow].Value =  clsFormatter.FormatToCurrecyWithThousendSep(InvoiceDetail.GrandTotal);
                        dgvSattledmentDetail["SatleAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(detail.SattledAmount);
                        
                        dgvSattledmentDetail["ReceiptID", iRow].Value = clsCommon.GetForeignKeyValue(detail.Receipt_ID);
                        dgvSattledmentDetail["ChequeRegister_ID", iRow].Value = clsCommon.GetForeignKeyValue(detail.ChequeRegister_ID);


                        if(detail.ChequeRegister_ID != "default")
                            dgvSattledmentDetail["SattledBy", iRow].Value = "Cheque";
                        else
                            dgvSattledmentDetail["SattledBy", iRow].Value = "Cash";
                      

                        if (iRow > 0)
                            dbalance = decimal.Parse(dgvSattledmentDetail["Balance", iRow - 1].Value.ToString()) - detail.SattledAmount;
                        else
                            dbalance = InvoiceDetail.GrandTotal - detail.SattledAmount;

                        dgvSattledmentDetail["Balance", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dbalance);
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

        #region Btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvSattledmentDetail, clsFormatter.colorDigiteqTheamColor1, clsFormatter.colorDigiteqTheamColorSales1ForColour);
            clsFormatter.ApplyGridFormat(dgvAccounts, clsFormatter.colorDigiteqTheamColor1, clsFormatter.colorDigiteqTheamColorSales1ForColour);
            clsFormatter.ApplyGridFormat(dgvReconciliation, clsFormatter.colorDigiteqTheamColor1, clsFormatter.colorDigiteqTheamColorSales1ForColour);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            lblSattledAmount.Text = "";
            //lblCreditPeriod.Text = "";
            lblCustomerName.Text = "";
            lblInvoiceAmount.Text = "";
            lblInvoiceDate.Text = "";
            lblInvoiceID.Text = "";
        }
        #endregion

        #region  Fill Details
        private void FillDetails(string sInvoice)
        {
            tbl_sasInvoice detail = tbl_sasInvoice.Select(sInvoice);
            if (detail != null)
            {
                lblCustomerName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));
                lblInvoiceDate.Text = detail.InvoiceDate.ToString("dd MMM yyyy");
                lblInvoiceID.Text = detail.Invoice_ID;
                lblSattledAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.SeattleAmount);
                lblInvoiceAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);
                lblBalance.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal - detail.SeattleAmount);
                RefreshReceiptGridByInvoiceID(sInvoice);
            
                List<tbl_bpsReceipt_Invoice> details = tbl_bpsReceipt_Invoice.SelectAllByInvoice_ID(detail.Invoice_ID);
                foreach (tbl_bpsReceipt_Invoice invoicedetail in details)
                {
                    if (invoicedetail.Receipt_ID != "default")
                    {
                        RefreshChequeRegisterGridByInvoiceID(invoicedetail.Receipt_ID);
                    }
                }
                InvoiceSattlementRefreshGridBy(sInvoice);
            }
        }
        #endregion

        #region Btn Refresh
        private void btnRefresh_Click(object sender, EventArgs e)
        {

        } 
        #endregion


        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_TransactionInvoice_Direct(ref textBox1, false,false,false);
             FillDetails(textBox1.Text);
        }
    }
}