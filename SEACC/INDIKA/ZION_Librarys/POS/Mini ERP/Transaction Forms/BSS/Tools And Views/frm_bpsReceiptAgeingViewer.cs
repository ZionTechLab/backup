using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Digiteq
{
    public partial class frm_bpsReceiptAgeingViewer : Form
    {

        #region Variables

           public int iFormID;
        public bool bNoAccess;
        public string glbReceiptID = "";
        #endregion

        #region Form Load
        public frm_bpsReceiptAgeingViewer()
        {
            iFormID = clsSecurity.getFormID(FormName.ViewerCustomer);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_bpsChequeViewer_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "", 2, iFormID);
            btnRefresh_Click(sender, new EventArgs());           
        } 
        #endregion

        #region Btn Refresh
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearFields();
            if (glbReceiptID.Length > 0)
            {
                FillDetails(glbReceiptID);
            }
        }
        #endregion

        #region Btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Btn Print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //if (lblReceiptID.Text.Length > 0 && lblReceiptID.Text != "<Auto Generate>")
                //{
                //    Cursor = Cursors.WaitCursor;
                //    string s_Path = "", sHeaderTitle = "Flow Stock Balance";
                //    ReportDocument RD = new ReportDocument();
                //    s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                //    s_Path += "\\reports\\SAS\\Commen\\rpt_sas_Invoice_Settlement_Customer.rpt";

                //    frm_ReportViewer viewer = new frm_ReportViewer();
                //    RD.Load(s_Path);
                //    clsSecurity.LogonServer(ref RD);
                //    RD.Refresh();

                //    RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                //    RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring("Customer Outstandings");
                //    RD.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                //    RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                //    RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                //    RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                //    RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                //    RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);


                //    string sFormula = "{vw_rpt_sasInvoice.customer_ID} = '" + lblReceiptID.Text.Trim() + "'";
                //    sFormula += " and {vw_rpt_sasInvoice.isSeattled} = false";

                //    viewer.crystalReportViewer1.ReportSource = RD;
                //    viewer.crystalReportViewer1.SelectionFormula = sFormula;
                //    viewer.crystalReportViewer1.Visible = true;
                //    viewer.crystalReportViewer1.DisplayToolbar = true;
                //    viewer.crystalReportViewer1.CloseView(false);
                //    viewer.WindowState = FormWindowState.Maximized;

                //    viewer.ShowDialog();

                //    RD.Close();
                //    RD.Dispose();
                //}
                //else
                //    MessageBox.Show("Please Select the Invoice To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion


        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvInvoice, clsFormatter.colorDigiteqTheamColor1, clsFormatter.colorDigiteqTheamColorSales1ForColour);           
            clsFormatter.ApplyGridFormat(dgvAllocation, clsFormatter.colorDigiteqTheamColor1, clsFormatter.colorDigiteqTheamColorSales1ForColour);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {

            //lblCreditPeriod.Text = "";
            lblReceiptID.Text = "";
            lblCustomerName.Text = "";
            lblDepositAmount.Text = "";

            lblReceiptDate.Text = "";

        }
        #endregion

        #region  Fill Details
        private void FillDetails(string sItemCode)
        {
            tbl_bpsReceipt detail = tbl_bpsReceipt.Select(glbReceiptID);
            if (detail != null)
            {
                lblReceiptID.Text = detail.Receipt_ID;
                lblReceiptDate.Text = detail.ReceiptDate.ToShortDateString();
                lblCustomerName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));

                RefreshGrid_Invoice(detail.Receipt_ID);
                RefreshGrid_Ageing(detail.Receipt_ID);
                CusDataGridViewFormat();
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid_Invoice(string sReceiptID)
        {
            try
            {
                int iRow, iRecords = 0;
                dgvInvoice.Rows.Clear();
                decimal dInvoiceTotal = 0, dInvoiceAgeing = 0, dDueDateAgeing = 0;
                tbl_bpsReceipt objReceipt = tbl_bpsReceipt.Select(sReceiptID);
                if (objReceipt != null)
                {
                    List<tbl_bpsReceipt_Invoice> details = tbl_bpsReceipt_Invoice.SelectAllByReceipt_ID(sReceiptID);
                    foreach (tbl_bpsReceipt_Invoice detail in details)
                    {
                        tbl_sasInvoice objInvoice = tbl_sasInvoice.Select(detail.Invoice_ID);
                        if (objInvoice != null)
                        {
                            iRecords++;
                            dgvInvoice.Rows.Add();
                            iRow = dgvInvoice.Rows.Count - 1;
                            dgvInvoice["InvoiceID", iRow].Value = objInvoice.Invoice_ID;
                            dgvInvoice["OrderRefNo", iRow].Value = clsGenaralName.getName_OrderRefNo(objInvoice.OrderRefNo_ID);
                            dgvInvoice["InvoiceAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(objInvoice.GrandTotal);
                            dgvInvoice["ReceiptDate1", iRow].Value = String.Format("{0:MM/dd/yyyy}", objReceipt.ReceiptDate);
                            dgvInvoice["InvoiceDate", iRow].Value = String.Format("{0:MM/dd/yyyy}", objInvoice.InvoiceDate);
                            dgvInvoice["InvoiceAgeing", iRow].Value = clsCommon.getDays(objInvoice.InvoiceDate, objReceipt.ReceiptDate);
                            dgvInvoice["ReceiptDate2", iRow].Value = String.Format("{0:MM/dd/yyyy}", objReceipt.ReceiptDate);
                            dgvInvoice["InvoiceDueDate", iRow].Value = String.Format("{0:MM/dd/yyyy}", objInvoice.PaymentDueDate);
                            dgvInvoice["InvoiceDueDateAgeing", iRow].Value = clsCommon.getDays(objInvoice.PaymentDueDate, objReceipt.ReceiptDate);

                            dInvoiceTotal += objInvoice.GrandTotal;
                            dInvoiceAgeing += clsCommon.getDays(objInvoice.InvoiceDate, objReceipt.ReceiptDate);
                            dDueDateAgeing += clsCommon.getDays(objInvoice.PaymentDueDate, objReceipt.ReceiptDate);
                        }
                    }
                }
                if (iRecords > 5)
                {
                    dgvInvoice.Columns["ReceiptDate1"].Width -= 6;
                    dgvInvoice.Columns["InvoiceDate"].Width -= 6;
                    dgvInvoice.Columns["ReceiptDate2"].Width -= 4;
                   // dgvInvoice.Columns["InvoiceDueDate"].Width -= 4;
                }
                lblInvoiceTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(dInvoiceTotal);
                lblInvoiceAgeing.Text = clsFormatter.FormatToNumberNoDecimal(dInvoiceAgeing);
                lblDueDateAgeing.Text = clsFormatter.FormatToNumberNoDecimal(dDueDateAgeing);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }

        private void RefreshGrid_Ageing(string sReceiptID)
        {
            try
            {
                int iRow, iRecords = 0, iColur = 0;
                List<Color> LColours = new List<Color>();
                LColours.Add(Color.Red);
                LColours.Add(Color.Blue);               

                dgvAllocation.Rows.Clear();
                decimal dChequeTotal = 0, dInvoiceTotal = 0, dAgeingTotal = 0;

                tbl_bpsReceipt objReceipt = tbl_bpsReceipt.Select(sReceiptID);
                if (objReceipt != null)
                {
                    //For Cash
                    if (objReceipt.CashAmount > 0)
                    {
                        iRecords++;
                        iColur++;
                        dgvAllocation.Rows.Add();
                        iRow = dgvAllocation.Rows.Count - 1;
                        dgvAllocation.Rows[iRow].DefaultCellStyle.ForeColor = LColours[iColur - 1];                       
                        dgvAllocation["BankName", iRow].Value = "Cash";
                        dgvAllocation["Remark", iRow].Value = "Cash";
                        dgvAllocation["ChequeNo", iRow].Value = "Cash";
                        dgvAllocation["ChequeAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(objReceipt.CashAmount);
                        dgvAllocation["ChequeDate", iRow].Value = String.Format("{0:MM/dd/yyyy}", objReceipt.ReceiptDate);
                        int iAllocation = 0, iRuning = 0;

                        List<tbl_sasInvoice_Sattled> details = tbl_sasInvoice_Sattled.SelectAllByReceipt_ID(objReceipt.Receipt_ID);
                        foreach (tbl_sasInvoice_Sattled detail in details)
                        {
                            if (detail.ChequeRegister_ID == "default")
                            {
                                tbl_sasInvoice objInvoice = tbl_sasInvoice.Select(detail.Invoice_ID);
                                if (objInvoice != null)
                                {
                                    if (iAllocation < iRuning)
                                    {
                                        iRecords++;
                                        dgvAllocation.Rows.Add();
                                        iRow = dgvAllocation.Rows.Count - 1;
                                        dgvAllocation.Rows[iRow].DefaultCellStyle.ForeColor = LColours[iColur - 1];
                                        iAllocation++;
                                    }
                                    iRuning++;
                                    dgvAllocation["BankName", iRow].Value = "Cash";
                                    dgvAllocation["Remark", iRow].Value = "Cash";
                                    dgvAllocation["ChequeNo", iRow].Value = "Cash";
                                    dgvAllocation["ChequeAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(objReceipt.CashAmount);
                                    dgvAllocation["ChequeDate", iRow].Value = String.Format("{0:MM/dd/yyyy}", objReceipt.ReceiptDate);
                                    dgvAllocation["CInvoiceID", iRow].Value = objInvoice.Invoice_ID;
                                    dgvAllocation["CInvoiceDate", iRow].Value = String.Format("{0:MM/dd/yyyy}", objInvoice.InvoiceDate);
                                    dgvAllocation["ChequeAgeing", iRow].Value = clsCommon.getDays(objInvoice.InvoiceDate, objReceipt.ReceiptDate);
                                    dgvAllocation["AllocatedAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(detail.SattledAmount);

                                    dInvoiceTotal += detail.SattledAmount;
                                    dAgeingTotal += clsCommon.getDays(objInvoice.PaymentDueDate, objReceipt.ReceiptDate);
                                }
                            }
                        }
                        if (iColur == 2)
                            iColur = 0;
                    }

                    //For Cheques
                    List<tbl_bpsChequeRegister> objCheques = tbl_bpsChequeRegister.SelectAllByReceipt_ID(sReceiptID);
                    foreach (tbl_bpsChequeRegister objCheque in objCheques)
                    {
                        if (!objCheque.IsDeleted && objCheque.ChequeRegister_ID != "default")
                        {
                            iRecords++;
                            iColur++;
                            dgvAllocation.Rows.Add();
                            iRow = dgvAllocation.Rows.Count - 1;
                            dgvAllocation.Rows[iRow].DefaultCellStyle.ForeColor = LColours[iColur - 1];
                            dChequeTotal += objCheque.Amount;
                            dgvAllocation["BankName", iRow].Value = clsGenaralName.getName_Bank(objCheque.Bank_ID);
                            dgvAllocation["Remark", iRow].Value = clsGenaralName.getName_ChequeStatus(objCheque.ChequeStatus_ID);
                            dgvAllocation["ChequeNo", iRow].Value = objCheque.ChequeNumber;
                            dgvAllocation["ChequeAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(objCheque.Amount);
                            dgvAllocation["ChequeDate", iRow].Value = String.Format("{0:MM/dd/yyyy}", objCheque.DateCheque);

                            int iAllocation = 0, iRuning = 0;
                            List<tbl_sasInvoice_Sattled> details = tbl_sasInvoice_Sattled.SelectAllByChequeRegister_ID(objCheque.ChequeRegister_ID);
                            foreach (tbl_sasInvoice_Sattled detail in details)
                            {
                                tbl_sasInvoice objInvoice = tbl_sasInvoice.Select(detail.Invoice_ID);
                                if (objInvoice != null)
                                {
                                    if (iAllocation < iRuning)
                                    {
                                        iRecords++;
                                        dgvAllocation.Rows.Add();
                                        iRow = dgvAllocation.Rows.Count - 1;
                                        dgvAllocation.Rows[iRow].DefaultCellStyle.ForeColor = LColours[iColur - 1];
                                        iAllocation++;
                                    }
                                    iRuning++;
                                    dgvAllocation["BankName", iRow].Value = clsGenaralName.getName_Bank(objCheque.Bank_ID);
                                    dgvAllocation["Remark", iRow].Value = clsGenaralName.getName_ChequeStatus(objCheque.ChequeStatus_ID);
                                    dgvAllocation["ChequeNo", iRow].Value = objCheque.ChequeNumber;
                                    dgvAllocation["ChequeAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(objCheque.Amount);
                                    dgvAllocation["ChequeDate", iRow].Value = String.Format("{0:MM/dd/yyyy}", objCheque.DateCheque);
                                    dgvAllocation["CInvoiceID", iRow].Value = objInvoice.Invoice_ID;
                                    dgvAllocation["CInvoiceDate", iRow].Value = String.Format("{0:MM/dd/yyyy}", objInvoice.InvoiceDate);
                                    dgvAllocation["ChequeAgeing", iRow].Value = clsCommon.getDays(objInvoice.InvoiceDate, objCheque.DateCheque);
                                    dgvAllocation["AllocatedAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(detail.SattledAmount);

                                    dInvoiceTotal += detail.SattledAmount;
                                    dAgeingTotal += clsCommon.getDays(objInvoice.PaymentDueDate, objCheque.DateCheque);

                                }

                            }
                            if (iColur == 2)
                                iColur = 0;
                        }
                    }
                }
                if (iRecords > 13)
                {
                    dgvAllocation.Columns["ChequeDate"].Width -= 3;
                    dgvAllocation.Columns["CInvoiceDate"].Width -= 3;
                    dgvAllocation.Columns["BankName"].Width -= 10;
                }
                
                lblTotalAllocatedAmount.Text = clsFormatter.FormatToNumberNoDecimal(dInvoiceTotal);
                lblTotalChequeAge.Text = clsFormatter.FormatToNumberNoDecimal(dAgeingTotal);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        } 
        #endregion

        #region Calculation
        private void CalculateTotal()
        {
            try
            {
                //decimal dTotalIncome = decimal.Parse(lblDepositAmount.Text.Trim()) + decimal.Parse(lblCreditLimit.Text.Trim());
                //decimal dTotalDues = decimal.Parse(lblOpeningBalance.Text.Trim()) + decimal.Parse(lblSalseDues.Text.Trim());
                //decimal dBalance = dTotalIncome - dTotalDues;

                
                //lblTotalDues.Text = clsFormatter.FormatToCurrecyWithThousendSep(dTotalDues);
                //lblTotalBalance.Text = clsFormatter.FormatToCurrecyWithThousendSep(dBalance);
                
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        
        #endregion

        private void x5_Paint(object sender, PaintEventArgs e)
        {

        }

      
    }



}
