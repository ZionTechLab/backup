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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Digiteq_Logic;

namespace Digiteq
{
    public partial class frm_sasViewerCustomer : Form
    {

        #region Variables

           public int iFormID;
        public bool bNoAccess;
        public string glbCustomerID = "";
        #endregion

        #region Form Load
        public frm_sasViewerCustomer()
        {
            iFormID = clsSecurity.getFormID(FormName.ViewerCustomer);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }
        private void frm_bpsChequeViewer_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "", 2, iFormID);
            btnRefresh_Click(sender, new EventArgs());
            TabPage page = tbcCustomerInvoices.TabPages[2];
            page.Visible = false;
        } 
        #endregion

        #region Btn Refresh
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearFields();
            if (glbCustomerID.Length > 0)
                FillDetails(glbCustomerID);              
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
                if (lblCustomerID.Text.Length > 0 && lblCustomerID.Text != "<Auto Generate>")
                {
                    Cursor = Cursors.WaitCursor;
                    string s_Path = "", sHeaderTitle = "Flow Stock Balance";
                    ReportDocument RD = new ReportDocument();
                    s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                    s_Path += "\\reports\\SAS\\Commen\\rpt_sas_Invoice_Settlement_Customer.rpt";

                    frm_ReportViewer viewer = new frm_ReportViewer();
                    RD.Load(s_Path);
                    clsSecurity.LogonServer(ref RD);
                    RD.Refresh();

                    RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                    RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring("Customer Outstandings");
                    RD.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                    RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                    RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                    RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                    RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                    RD.DataDefinition.FormulaFields["CreditLimit"].Text = clsCommon.fncsetstring(lblCreditLimit.Text);
                    RD.DataDefinition.FormulaFields["TotalSalesDues"].Text = clsCommon.fncsetstring(lblTotalDues.Text);
                    RD.DataDefinition.FormulaFields["Cheques-In-Hand"].Text = clsCommon.fncsetstring(lblChequesInHand.Text);
                    RD.DataDefinition.FormulaFields["CreditBalance"].Text = clsCommon.fncsetstring(lblTotalBalance.Text);

                    string sFormula = "{vw_rpt_sasInvoice.customer_ID} = '" + lblCustomerID.Text.Trim() + "'";
                    sFormula += " and {vw_rpt_sasInvoice.isSeattled} = false";

                    viewer.crystalReportViewer1.ReportSource = RD;
                    viewer.crystalReportViewer1.SelectionFormula = sFormula;
                    viewer.crystalReportViewer1.Visible = true;
                    viewer.crystalReportViewer1.DisplayToolbar = true;
                    viewer.crystalReportViewer1.CloseView(false);
                    viewer.WindowState = FormWindowState.Maximized;

                    viewer.ShowDialog();

                    RD.Close();
                    RD.Dispose();
                }
                else
                    MessageBox.Show("Please Select the Invoice To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            clsFormatter.ApplyGridFormat(dgvDetail, clsFormatter.colorDigiteqTheamColor1, clsFormatter.colorDigiteqTheamColorSales1ForColour);           
            clsFormatter.ApplyGridFormat(dgvChequesInHand, clsFormatter.colorDigiteqTheamColor1, clsFormatter.colorDigiteqTheamColorSales1ForColour);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            lblCreditLimit.Text = "";
            //lblCreditPeriod.Text = "";
            lblCustomerID.Text = "";
            lblCustomerName.Text = "";
            lblDepositAmount.Text = "";
            lblEmail.Text = "";
            lblFax.Text = "";
            lblSalseDues.Text = "";
            lblTelephone.Text = "";            
            lblCustomerType.Text = "";
            lblCustomerCategory.Text = "";
            lblCustomerClass.Text = "";
            lblRCOutstandings.Text = "";
        }
        #endregion

        #region  Fill Details
        private void FillDetails(string sItemCode)
        {
            tbl_genCustomerMaster detail = tbl_genCustomerMaster.Select(glbCustomerID);
            if (detail != null)
            {
                tbl_genCustomerFinance Financedetail = tbl_genCustomerFinance.Select(glbCustomerID);
                if (Financedetail != null)
                {
                    lblCreditLimit.Text = clsFormatter.FormatToCurrecyWithThousendSep(Financedetail.CreditLimit);
                    lblCreditperiod.Text = Financedetail.CreditPeriod.ToString() + " Days";
                }
                else
                {
                    lblCreditLimit.Text = clsFormatter.FormatToCurrecyWithThousendSep(0);
                    lblCreditperiod.Text = "0 Days";
                }

                lblCustomerID.Text = detail.Customer_ID;
                lblCustomerName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));
                lblEmail.Text = detail.Email;
                lblFax.Text = detail.Fax;
                lblTelephone.Text = detail.Telephone;
                lblCustomerType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_CustomerType(detail.CustomerType_ID));
                lblCustomerCategory.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_CustomerCategory(detail.CustomerCategory_ID));
                lblCustomerClass.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_CustomerClass(detail.CustomerClass_ID));
                lblSaleRep.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesRep(detail.SalesRep_ID));

                lblBusinessRegNo.Text = detail.BusinessRegistraionNo;
                lblVATRegNo.Text = detail.VatRegistrationNo;
                lblSVATRegNo.Text = detail.SvatRegistrationNo;

                RefreshGrid_Account();
                RefreshGrid_Ageing();
                RefreshGrid_ChequesInHand();

                lblOpeningBalance.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.GetCustomerTotalDues_OpeningBalance(detail.Customer_ID));
                lblRCOutstandings.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.GetCustomerTotalDues_ReturnedCheque(detail.Customer_ID));
                lblSalseDues.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.GetCustomerTotalDues_Invoice(detail.Customer_ID));
                lblOverPayments.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.GetCustomerTotal_UnsettledPayements(detail.Customer_ID));
                lblTotalDues.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.GetCustomerTotalDues_All(detail.Customer_ID));
                lblTotalBalance.Text = clsFormatter.FormatToCurrecyWithThousendSep(decimal.Parse(lblCreditLimit.Text.Trim()) - clsHelpMethods.GetCustomerTotalDues_All(detail.Customer_ID) - clsHelpMethods.GetCustomerChequesInHand(detail.Customer_ID));

                CusDataGridViewFormat();
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid_Account()
        {           
            decimal dDeposit = 0, dRetuend = 0, dRealized = 0;           
            List<tbl_genCustomerAccount> details = tbl_genCustomerAccount.SelectAllByCustomer_ID(glbCustomerID);
            foreach (tbl_genCustomerAccount detail in details)
            {
                if (detail.Bank_ID != "default")
                {
                  
                    dDeposit += detail.DeposittedCount;
                    dRealized += detail.RealizedCount;
                    dRetuend += detail.ReturnedCount;
                }
            }
            lblDepositTotal.Text = clsFormatter.FormatToNumberNoDecimal(dDeposit);
            lblRealizedTotal.Text = clsFormatter.FormatToNumberNoDecimal(dRealized);
            lblReturnedTotal.Text = clsFormatter.FormatToNumberNoDecimal(dRetuend);
        }

        private void RefreshGrid_ChequesInHand()
        {
            int iRow, iRecords = 0;
            decimal dTotalAmount = 0;
            dgvChequesInHand.Rows.Clear();
            List<tbl_bpsChequeRegister> details = tbl_bpsChequeRegister.SelectAllByCustomer_ID(glbCustomerID);
            foreach (tbl_bpsChequeRegister detail in details)
            {
                if (detail.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                {
                    if (!detail.IsReconcilied && !detail.IsDeleted && !detail.IsReIssued)
                    {
                        iRecords++;
                        dgvChequesInHand.Rows.Add();
                        decimal dAmount = detail.Amount; //detail.ChequeAmount - detail.SetteledAmount;
                        dTotalAmount += dAmount;
                        iRow = dgvChequesInHand.Rows.Count - 1;
                        dgvChequesInHand["ChequeNo", iRow].Value = detail.ChequeNumber;
                        dgvChequesInHand["ChequeDate", iRow].Value = detail.DateCheque.GetDateTimeFormats()[3];
                        dgvChequesInHand["ChequeAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
                    }
                }
            }
            if (iRecords > 11)
            {
                dgvChequesInHand.Columns["ChequeNo"].Width -= 6;
                dgvChequesInHand.Columns["ChequeDate"].Width -= 10;
            }

            lblChequesInHand.Text = clsFormatter.FormatToCurrecyWithThousendSep(dTotalAmount);
            lblChequeTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(dTotalAmount);
        }

        private void RefreshGrid_Ageing()
        {
            int iRow, iRecords = 0; ;
            decimal dAmount30 = 0, dAmount60 = 0, dAmount90 = 0, dAmount90Plus = 0, dInvoiceAmount = 0, dSalesOutstanding = 0;
            dgvDetail.Rows.Clear();

            tbl_genCustomerFinance customer1 = tbl_genCustomerFinance.Select(glbCustomerID);
            if (customer1 != null)
            {
                var oDetails = srh_bssCustomerOutstanding.SelectAllByCustomerId(customer1.Customer_ID, "", Convert.ToDateTime("01/01/2000"), DateTime.Now.Date, true);
                foreach (srh_bssCustomerOutstanding oDetail in oDetails.Where(p => p.TransactionType !=5 ))
                {
                    iRecords++;
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    dgvDetail["InvoiceNo", iRow].Value = oDetail.Transaction_ID;
                    dgvDetail["InvoiceAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(oDetail.Outstanding);
                    dgvDetail["day30", iRow].Value = "0.00";
                    dgvDetail["day60", iRow].Value = "0.00";
                    dgvDetail["day90", iRow].Value = "0.00";
                    dgvDetail["Morethan90Days", iRow].Value = "0.00";

                    int days = clsCommon.getDaysUptoDate(oDetail.TransactionDate);
                    decimal dAmount = oDetail.Outstanding;

                    dInvoiceAmount += oDetail.Outstanding;
                    if (customer1.CreditPeriod <= days)
                        dSalesOutstanding += dAmount;

                    if (days <= 30)
                    {
                        dAmount30 += dAmount;
                        dgvDetail["day30", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
                    }
                    else if (days > 30 && days <= 60)
                    {
                        dAmount60 += dAmount;
                        dgvDetail["day60", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
                    }
                    else if (days > 60 && days <= 90)
                    {
                        dAmount90 += dAmount;
                        dgvDetail["day90", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
                    }
                    else if (days > 90)
                    {
                        dAmount90Plus += dAmount;
                        dgvDetail["Morethan90Days", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
                    }
                }
            }
            lblOverDues.Text = clsFormatter.FormatToCurrecyWithThousendSep((dSalesOutstanding - clsHelpMethods.GetCustomerTotal_UnsettledPayements(glbCustomerID)));
            lbl1to30.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount30);
            lbl31to60.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount60);
            lbl61to90.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount90);
            lbl91plus.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount90Plus);
            lblInvoiceAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dInvoiceAmount);
          
            //tbl_genCustomerFinance customer = tbl_genCustomerFinance.Select(glbCustomerID);
            //if (customer != null)
            //{
            //    List<tbl_sasInvoice> details = tbl_sasInvoice.SelectAllByCustomer_ID(glbCustomerID);
            //    foreach (tbl_sasInvoice detail in details)
            //    {                   
            //        if (!detail.IsSeattled && !detail.IsDeleted)
            //        {
            //            iRecords++;
            //            dgvDetail.Rows.Add();
            //            iRow = dgvDetail.Rows.Count - 1;
            //            dgvDetail["InvoiceNo", iRow].Value = detail.Invoice_ID;
            //            dgvDetail["InvoiceAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);
            //            dgvDetail["day30", iRow].Value = "0.00";
            //            dgvDetail["day60", iRow].Value = "0.00";
            //            dgvDetail["day90", iRow].Value = "0.00";
            //            dgvDetail["Morethan90Days", iRow].Value = "0.00";

            //            int days = clsCommon.getDaysUptoDate(detail.InvoiceDate);
            //            decimal dAmount = detail.GrandTotal - detail.SeattleAmount;
                        
            //            dInvoiceAmount += detail.GrandTotal;
            //            if (customer.CreditPeriod <= days)
            //                dSalesOutstanding += dAmount;

            //            if (days <= 30)
            //            {
            //                dAmount30 += dAmount;                            
            //                dgvDetail["day30", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
            //            }
            //            else if (days > 30 && days <= 60)
            //            {
            //                dAmount60 += dAmount;
            //                dgvDetail["day60", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
            //            }
            //            else if (days > 60 && days <= 90)
            //            {
            //                dAmount90 += dAmount;
            //                dgvDetail["day90", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
            //            }
            //            else if (days > 90)
            //            {
            //                dAmount90Plus += dAmount;
            //                dgvDetail["Morethan90Days", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
            //            }
            //        }
            //    }
            //    if (iRecords > 11)
            //        dgvDetail.Columns["InvoiceNo"].Width -= 16;
            //}

            //lblOverDues.Text = clsFormatter.FormatToCurrecyWithThousendSep((dSalesOutstanding - clsHelpMethods.GetCustomerTotal_UnsettledPayements(glbCustomerID)));
            //lbl1to30.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount30);
            //lbl31to60.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount60);
            //lbl61to90.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount90);
            //lbl91plus.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount90Plus);
            //lblInvoiceAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dInvoiceAmount);
        }

        private void RefreshdGrid_InvoiceHistory()
        {
            if (dgvInvoiceHistory.Rows.Count == 0)
            {
                dgvInvoiceHistory.Rows.Clear();
                foreach (tbl_sasInvoice oInvoice in tbl_sasInvoice.SelectAllByCustomer_ID(lblCustomerID.Text).Where(p => p.Invoice_ID != "default" && !p.IsDeleted))
                {
                    dgvInvoiceHistory.Rows.Add(oInvoice.Invoice_ID, clsFormatter.FormatDate_Short(oInvoice.InvoiceDate), clsGenaralName.getName_CompanyBranchMaster(oInvoice.Branch_ID), clsFormatter.FormatDecimalPlaces_Price(oInvoice.SeattleAmount), clsFormatter.FormatDecimalPlaces_Price(oInvoice.GrandTotal), oInvoice.IsSeattled);
                }
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

       

        #region Grid Events
        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string sInvoiceID = "";
            sInvoiceID = dgvDetail["InvoiceNo", e.RowIndex].Value.ToString();

            if (sInvoiceID.Length > 0)
            {
                frm_sasInvoice frm = new frm_sasInvoice(FormName.VATInvoice);
                frm.glbInvoiceID = sInvoiceID;
                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, this.MdiParent);
            }
        }
        #endregion

        #region Tab Event
        private void tbcCustomerInvoices_Click(object sender, EventArgs e)
        {
            switch (tbcCustomerInvoices.SelectedIndex)
            {
                case 1: RefreshdGrid_InvoiceHistory();
                    break;
                //case 2: Selet;
                //    break;
            }
        }

        private void tbcCustomerInvoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcCustomerInvoices.SelectedIndex == 2)
            {
                tbcCustomerInvoices.SelectedIndex = 0;
            }

        } 
        #endregion
    
      
    }
}
