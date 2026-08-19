#region Using Derectives
using System;
using System.Linq;
using Digiteq_Logic;
using System.Collections.Generic;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using DataTire;
using Digiteq.DataSets;
using System.Data;
using Digiteq.DataSets.SAS;
using Digiteq.DataSets.BSS;

#endregion

namespace Digiteq
{
    public partial class frm_rpt_ChequeStanded : MettroForm
    {
        #region Variables
        //form manage
        public int iFormID;

        //for security handle
        public bool bNoAccess;

        //objects from datasets        
        dtsBills glbDtsBills = new dtsBills();
        dts_BSS glbDtsBSS = new dts_BSS();
        dts_Sales glbDtsSales = new dts_Sales();
        dts_bssIncentive glb_dts_bssIncentive = new dts_bssIncentive();
        dts_sasReceiptAllocation glb_dtsReceiptAllocation = new dts_sasReceiptAllocation();
        dts_bssOutstandingLedger gbl_dts_bssOutstandingLedger = new dts_bssOutstandingLedger();

        dts_bssRegister glbdts_bssRegister = new dts_bssRegister();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();

        enum_ReportName Report;

        bool bCustomerSelected = false, bCurrencySelected = false, bSelesRepSelected = false, bCollectorSelected = false;//bBankSelected = false
        #endregion

        #region Form Load
        public frm_rpt_ChequeStanded()
        {
            iFormID = clsSecurity.getFormID(FormName.ReportChequeStanded);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }

        private void frmReportChequeDeposit_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Bills Standard Reports", 2, iFormID);
            clearField();
            DisplayReports();
        }
        #endregion

        #region Display Reports
        private void DisplayReports()
        {
            try
            {
                dgvReports.Rows.Clear();
                dgvReports.DataSource = DBHandling.ExecQuery("EXEC sp_Reports '" + 13 + "'").Tables[0];
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvReports.SelectedCells.Count != 0)
            {
                if (dgvReports.Rows.Count > 0)
                {
                    try
                    {
                        int iRow = dgvReports.SelectedCells[0].RowIndex;
                        int iReport = int.Parse(dgvReports.Rows[iRow].Cells[0].Value.ToString());
                        Report = (enum_ReportName)iReport;

                        if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(Report)))
                        {
                            string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                            if (clsHelpMethods.GetReportPath(clsAutocode.getReportID(Report), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                            {
                                #region Filters
                                string sFormula = "", sFilter = "";
                                bCustomerSelected = false; bCurrencySelected = false; bSelesRepSelected = false;
                                                                                                               
                                if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Length > 0)
                                    bCustomerSelected = true;
                                if (txtSalesRep.Tag != null && txtSalesRep.Tag.ToString().Length > 0)
                                    bSelesRepSelected = true;
                                if (txtCollector.Tag != null && txtCollector.Tag.ToString().Length > 0)
                                    bCollectorSelected = true;
                                if (cmbCurrency.Tag != null && cmbCurrency.Tag.ToString().Length > 0)
                                    bCurrencySelected = true;

                                string sDateRange = "From : " + dtpFrom.Value.ToString("dd MMM  yyyy") + "  To : " + dtpTo.Value.ToString("dd MMM  yyyy");
                                #endregion


                                #region Collection Report
                                if (Report == enum_ReportName.ST_Collection_Report_Summary || Report == enum_ReportName.ST_Collection_Report_Detail)
                                {
                                    glbDtsBills.Clear();

                                    List<tbl_bpsReceipt> oReceipts = tbl_bpsReceipt.SelectAll().Where(p => !p.IsDeleted && p.Receipt_ID != "default" && p.ReceiptDate.Date >= dtpFrom.Value.Date && p.ReceiptDate.Date <= dtpTo.Value.Date).ToList();
                                    foreach (tbl_bpsReceipt oReceipt in oReceipts)
                                    {
                                        #region Filters
                                        bool bCurrencyOK = true, bSalesRepOK = true, bCollectorOK = true, bCustomerOK = true;
                                        if (cmbCurrency.Text.Trim() == "Sri Lanka Rupee (LKR)" || cmbCurrency.Text.Trim() == "American Dollar (USD)")
                                        {
                                            sFilter += "Currency : " + cmbCurrency.Text.Trim();
                                            if (cmbCurrency.Text.Trim() == "Sri Lanka Rupee (LKR)")
                                                bCurrencyOK = oReceipt.Currency_ID == "CUR/048" ? true : false;
                                            else if (cmbCurrency.Text.Trim() == "American Dollar (USD)")
                                                bCurrencyOK = oReceipt.Currency_ID != "CUR/001" ? true : false;
                                        }
                                        if (bCustomerSelected)
                                        {
                                            bCustomerOK = oReceipt.Customer_ID == txtCustomer.Tag.ToString() ? true : false;
                                        }
                                        if (bSelesRepSelected)
                                        {
                                            tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oReceipt.OrderRefNo_ID);
                                            if (oRef != null)
                                                bSalesRepOK = oRef.Employee_ID == txtSalesRep.Tag.ToString() ? true : false;
                                        }

                                        if (bCollectorSelected)
                                        {
                                            if (txtCollector.Tag != null)
                                            {
                                                bCollectorOK = oReceipt.Collector_ID == txtCollector.Tag.ToString() ? true : false;
                                            }
                                        }
                                        #endregion

                                        if (bCurrencyOK && bCustomerOK && bSalesRepOK && bCollectorOK)
                                        {
                                            string sSalesRepID = "", sSalesRepName = "";
                                            tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oReceipt.OrderRefNo_ID);
                                            if (oRef != null)
                                            {
                                                sSalesRepID = oRef.Employee_ID;
                                                sSalesRepName = clsGenaralName.getName_SalesRep(oRef.Employee_ID);
                                            }

                                            #region MyRegion
                                            //if (rdoCollectionReport_Summary.Checked)
                                            //{
                                            //    decimal dChequeAmount = 0, dTotalAmount = 0;
                                            //    foreach (tbl_bpsChequeRegister oChequeRegister in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID).Where(p => !p.IsDeleted))
                                            //        dChequeAmount += oChequeRegister.ChequeAmount;

                                            //    dTotalAmount = oReceipt.CashAmount + dChequeAmount;

                                            //    glbDtsBills.dt_bssPaymontCollectionSummary.Rows.Add(oReceipt.Receipt_ID, oReceipt.ReceiptDate, oReceipt.Customer_ID, clsGenaralName.getName_Customer(oReceipt.Customer_ID),
                                            //    clsHelpMethods.getDisplayPrice(oReceipt.CashAmount, oReceipt.CurrencyRate), clsHelpMethods.getDisplayPrice(dChequeAmount, oReceipt.CurrencyRate),
                                            //    clsHelpMethods.getDisplayPrice(dTotalAmount, oReceipt.CurrencyRate), oReceipt.DateCreate, clsGenaralName.getName_CurrencyCode(oReceipt.Currency_ID));
                                            //}

                                            //else
                                            //{
                                            //For Cash
                                            //if (rdoCollectionReport_Detail.Checked)
                                            //{
                                            //    if (oReceipt.CashAmount > 0)
                                            //    {
                                            //        }
                                            //} 
                                            #endregion

                                            //For Cheque
                                            decimal dChequeAmount = 0, dTotal = 0;
                                            string sChequeNo = "";
                                            if (Report == enum_ReportName.ST_Collection_Report_Detail)
                                            {
                                                foreach (tbl_bpsChequeRegister oChequeRegister in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID).Where(p => !p.IsDeleted))
                                                {
                                                    dChequeAmount += oChequeRegister.Amount;
                                                    dTotal = oReceipt.CashAmount + dChequeAmount;


                                                    if (oChequeRegister.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                                                    {
                                                        glbDtsBills.dt_bssPaymontCollection.Rows.Add(oReceipt.Receipt_ID, oReceipt.ReceiptDate, oReceipt.Customer_ID, clsGenaralName.getName_Customer(oReceipt.Customer_ID),
                                                            sSalesRepID, sSalesRepName, clsHelpMethods.getDisplayPrice(oChequeRegister.Amount, oReceipt.CurrencyRate), clsHelpMethods.getDisplayPrice(oReceipt.CashAmount, oReceipt.CurrencyRate), clsHelpMethods.getDisplayPrice(oChequeRegister.Amount, oReceipt.CurrencyRate), clsGenaralName.getName_CurrencyCode(oReceipt.Currency_ID), oChequeRegister.Bank_ID, clsGenaralName.getName_Bank(oChequeRegister.Bank_ID), oChequeRegister.AccountNumber,
                                                            oChequeRegister.ChequeNumber, oChequeRegister.DateCheque, oReceipt.IsAdvance, oReceipt.DateCreate);
                                                    }
                                                    else
                                                    {
                                                        glbDtsBills.dt_bssPaymontCollection.Rows.Add(oReceipt.Receipt_ID, oReceipt.ReceiptDate, oReceipt.Customer_ID, clsGenaralName.getName_Customer(oReceipt.Customer_ID),
                                                          sSalesRepID, sSalesRepName, clsHelpMethods.getDisplayPrice(oChequeRegister.Amount, oReceipt.CurrencyRate), clsHelpMethods.getDisplayPrice(oReceipt.CashAmount, oReceipt.CurrencyRate), clsHelpMethods.getDisplayPrice(oReceipt.ChequeAmount, oReceipt.CurrencyRate),
                                                          clsGenaralName.getName_CurrencyCode(oReceipt.Currency_ID), " N/A ", " N/A ", " N/A ", " N/A ", oReceipt.ReceiptDate, oReceipt.IsAdvance, oReceipt.DateCreate);
                                                    }
                                                }
                                            }

                                            if (Report == enum_ReportName.ST_Collection_Report_Summary)
                                            {
                                                decimal dChqAmount = 0, dCashAmount = 0;

                                                foreach (tbl_bpsChequeRegister oChequeRegister in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID))
                                                {
                                                    if (oChequeRegister.PaymentMethod_ID == 1)
                                                        dChqAmount += oChequeRegister.Amount;
                                                    else
                                                        dCashAmount += oChequeRegister.Amount;
                                                }
                                                dTotal = dChqAmount + dCashAmount;
                                                glbDtsBills.dt_bssPaymontCollection.Rows.Add(oReceipt.Receipt_ID, oReceipt.ReceiptDate, oReceipt.Customer_ID, clsGenaralName.getName_Customer(oReceipt.Customer_ID),
                                                            sSalesRepID, sSalesRepName, clsHelpMethods.getDisplayPrice(dTotal, oReceipt.CurrencyRate), clsHelpMethods.getDisplayPrice(dCashAmount, oReceipt.CurrencyRate), clsHelpMethods.getDisplayPrice(dChqAmount, oReceipt.CurrencyRate), clsGenaralName.getName_CurrencyCode(oReceipt.Currency_ID), "", "", "",
                                                            "", oReceipt.DateCreate, oReceipt.IsAdvance, oReceipt.DateCreate);
                                            }
                                        }
                                        clsHelpMethods.startProgressBar(0, oReceipts.Count + 2, 1, ProgressBar);

                                    }

                                    if (bCustomerSelected)
                                        sFilter += " Customer Name : " + txtCustomer.Text.Trim();
                                    if (bSelesRepSelected)
                                        sFilter += " User Name : " + txtSalesRep.Text.Trim();
                                    if (bCollectorSelected)
                                        sFilter += " Collector Name : " + txtCollector.Text.Trim();

                                    glbDtsBills.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, sFilter);
                                    frm_ReportViewer_New rpt = new Digiteq.frm_ReportViewer_New();
                                    rpt.print(sReportPath, glbDtsBills, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    ProgressBar.Value = 0;

                                    glbDtsBills.Clear();
                                }
                                #endregion

                                #region Collection Report (Age-Analysis)
                                else if (Report == enum_ReportName.ST_Collection_Report_Aging)
                                {
                                    //clear data table
                                    glbDtsBills.Clear();
                                    bool bCurrencyOK = true, bSalesRepOK = true, bCustomerOK = true;

                                    if (bCustomerSelected)
                                        sFilter += " Customer Name : " + txtCustomer.Text.Trim();

                                    if (bSelesRepSelected)
                                        sFilter += " Salesman Name : " + txtSalesRep.Text.Trim();

                                    List<tbl_bpsReceipt> oReceipts = tbl_bpsReceipt.SelectAll().Where(p => !p.IsDeleted && p.Receipt_ID != "default" && p.ReceiptDate.Date >= dtpFrom.Value.Date && p.ReceiptDate.Date <= dtpTo.Value.Date).ToList();
                                    foreach (tbl_bpsReceipt oReceipt in oReceipts)
                                    {
                                        #region Filters

                                        if (cmbCurrency.Text.Trim() == "Sri Lanka Rupee (LKR)" || cmbCurrency.Text.Trim() == "American Dollar (USD)")
                                        {
                                            sFilter += "Currency : " + cmbCurrency.Text.Trim();
                                            if (cmbCurrency.Text.Trim() == "Sri Lanka Rupee (LKR)")
                                                bCurrencyOK = oReceipt.Currency_ID == "CUR/048" ? true : false;
                                            else if (cmbCurrency.Text.Trim() == "American Dollar (USD)")
                                                bCurrencyOK = oReceipt.Currency_ID != "CUR/001" ? true : false;
                                        }
                                        if (bCustomerSelected)
                                            bCustomerOK = oReceipt.Customer_ID == txtCustomer.Tag.ToString() ? true : false;

                                        if (bSelesRepSelected)
                                        {
                                            tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oReceipt.OrderRefNo_ID);
                                            if (oRef != null)
                                                bSalesRepOK = oRef.Employee_ID == txtSalesRep.Tag.ToString() ? true : false;
                                        }
                                        #endregion

                                        if (bCurrencyOK && bCustomerOK && bSalesRepOK)
                                        {
                                            string sSalesRepID = "", sSalesRepName = "", sCurrencyCode = "";
                                            tbl_zOrderRefNo oRef1 = tbl_zOrderRefNo.Select(oReceipt.OrderRefNo_ID);
                                            if (oRef1 != null)
                                            {
                                                sSalesRepID = oRef1.Employee_ID;
                                                sSalesRepName = clsGenaralName.getName_SalesRep(oRef1.Employee_ID);
                                            }
                                            sCurrencyCode = clsGenaralName.getName_CurrencyCode(oReceipt.Currency_ID);
                                            foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID).Where(p => p.ChequeRegister_ID != "default" && !p.IsDeleted))
                                            {
                                                #region For Cheques
                                                if (oCheque.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                                                {
                                                    List<tbl_sasInvoice_Sattled> details = tbl_sasInvoice_Sattled.SelectAllByChequeRegister_ID(oCheque.ChequeRegister_ID);
                                                    foreach (tbl_sasInvoice_Sattled detail in details)
                                                    {
                                                        tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(detail.Invoice_ID);
                                                        if (oInvoice != null)
                                                        {
                                                            decimal dAgeing = clsCommon.getDays(oInvoice.InvoiceDate, oCheque.DateCheque);
                                                            glbDtsBills.dt_bssPaymentCollectionAging.Rows.Add(sSalesRepID, sSalesRepName, oInvoice.Customer_ID, clsGenaralName.getName_Customer(oInvoice.Customer_ID),
                                                                oReceipt.Receipt_ID, "Chque Payment " + oCheque.ChequeNumber, oInvoice.Invoice_ID, dAgeing, clsHelpMethods.getDisplayPrice(detail.SattledAmount, oReceipt.CurrencyRate), oInvoice.InvoiceDate, oCheque.DateCheque, sCurrencyCode);
                                                        }
                                                    }

                                                    //add unselttle cheque amount
                                                    decimal dUnSettleAmount = 0;
                                                    dUnSettleAmount = oCheque.Amount - oCheque.SetteledAmount;
                                                    if (dUnSettleAmount > 0)
                                                    {
                                                        glbDtsBills.dt_bssPaymentCollectionAging.Rows.Add(sSalesRepID, sSalesRepName, oReceipt.Customer_ID, clsGenaralName.getName_Customer(oReceipt.Customer_ID),
                                                            oReceipt.Receipt_ID, "Chque Payment Unsettled", "N/A", 0, clsHelpMethods.getDisplayPrice(dUnSettleAmount, oReceipt.CurrencyRate), oCheque.DateCheque, oCheque.DateCheque, sCurrencyCode);
                                                    }
                                                }
                                                #endregion

                                                #region For Cash
                                                else
                                                {
                                                    foreach (tbl_sasInvoice_Sattled detail in tbl_sasInvoice_Sattled.SelectAllByReceipt_ID(oReceipt.Receipt_ID).Where(p => p.ChequeRegister_ID == "default"))
                                                    {
                                                        tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(detail.Invoice_ID);
                                                        if (oInvoice != null)
                                                        {
                                                            decimal dAgeing = clsCommon.getDays(oInvoice.InvoiceDate, oReceipt.ReceiptDate);
                                                            glbDtsBills.dt_bssPaymentCollectionAging.Rows.Add(sSalesRepID, sSalesRepName, oInvoice.Customer_ID, clsGenaralName.getName_Customer(oInvoice.Customer_ID),
                                                                oReceipt.Receipt_ID, "Cash Payment", oInvoice.Invoice_ID, dAgeing, clsHelpMethods.getDisplayPrice(detail.SattledAmount, oReceipt.CurrencyRate), oInvoice.InvoiceDate, oReceipt.ReceiptDate, sCurrencyCode);
                                                        }
                                                    }

                                                    //add unselttle cheque amount
                                                    decimal dUnSettleAmount = 0;
                                                    dUnSettleAmount = oReceipt.CashAmount - oReceipt.SeattleAmount;
                                                    if (dUnSettleAmount > 0)
                                                    {
                                                        glbDtsBills.dt_bssPaymentCollectionAging.Rows.Add(sSalesRepID, sSalesRepName, oReceipt.Customer_ID, clsGenaralName.getName_Customer(oReceipt.Customer_ID),
                                                            oReceipt.Receipt_ID, "Cash Payment Unsettled", "N/A", 0, clsHelpMethods.getDisplayPrice(dUnSettleAmount, oReceipt.CurrencyRate), oReceipt.ReceiptDate, oReceipt.ReceiptDate, sCurrencyCode);

                                                    }
                                                }
                                                #endregion
                                            }

                                        }
                                        clsHelpMethods.startProgressBar(0, oReceipts.Count + 2, 1, ProgressBar);
                                    }

                                    glbDtsBills.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, sFilter);

                                    frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                    rpt.print(sReportPath, glbDtsBills, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                    ProgressBar.Value = 0;
                                     }
                                #endregion

                                #region Commission (Customer Wise)
                                else if (Report == enum_ReportName.RG_Sales_Commission_Detail)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        sFormula = " {vw_rpt_sasCommissionNormal.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasCommissionNormal.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                                        if (bSelesRepSelected)
                                            sFormula += " and {vw_rpt_sasCommissionNormal.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";
                                        if (bCustomerSelected)
                                            sFormula += " and {vw_rpt_sasCommissionNormal.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";

                                        print(sReportPath, sReportTitle_Main, sFormula);
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        ProgressBar.Value = 0;
                                        Cursor = Cursors.Default;
                                        glbDtsBills.dt_bssCommission_CustomerWise.Rows.Clear();
                                    }
                                }

                                #endregion

                                #region Commission Detail(Invoice Wise)
                                else if (Report == enum_ReportName.RG_Sales_Commision_Invoice_wise)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glbDtsSales.dt_sasCommisionDetail.Rows.Clear();
                                        List<tbl_genCustomerMaster> oCustomers = tbl_genCustomerMaster.SelectAll().Where(p => p.Customer_ID != "default" && !p.IsDeleted).ToList();
                                        foreach (tbl_genCustomerMaster oCustomer in oCustomers)
                                        {
                                            #region Filters
                                            if (bCustomerSelected)
                                            {
                                                if (txtCustomer.Tag.ToString() != oCustomer.Customer_ID.Trim())
                                                    continue;
                                            }
                                            if (bSelesRepSelected)
                                            {
                                                if (txtSalesRep.Tag.ToString() != oCustomer.SalesRep_ID.Trim())
                                                    continue;
                                            }
                                            #endregion

                                            decimal dCommissionPasantage_Original = 0;
                                            tbl_genEmployeeMaster oEmployee = tbl_genEmployeeMaster.Select(oCustomer.SalesRep_ID.Trim());
                                            if (oEmployee != null && oEmployee.Employee_ID != "default")
                                                dCommissionPasantage_Original = oEmployee.CommisionPersentage_Normal;

                                            tbl_genCustomerFinance oCusFin = tbl_genCustomerFinance.Select(oCustomer.Customer_ID);
                                            if (oCusFin != null && oCusFin.Customer_ID != "default")
                                            {
                                                #region Invoices
                                                foreach (tbl_sasInvoice detail in tbl_sasInvoice.SelectAll_ByCustomerIDandDateRange(dtpFrom.Value.Date, dtpTo.Value.Date, oCustomer.Customer_ID).Where(p => p.Invoice_ID != "default" && !p.IsDeleted && !p.IsReturnedCheque && !p.IsDebitNote))
                                                {
                                                    int iDayes = 0, iInvoiceCount = 0;
                                                    decimal dBalanceAmount = detail.GrandTotal, dInvoiceNetAmount = 0, dTempValue1 = 0, dTempNBTAmount = 0, dTempVATAmount = 0;

                                                    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                                    {
                                                        if (detail.Quotation_ID != "default" || (detail.Job_ID == "default" && detail.DeliveryOrder_ID != "default"))
                                                            continue;
                                                    }

                                                    bool bIsVatNbt_Reduce_Enable = (oCustomer.IsSVATenable) || !clsConfig.bCommission_ActivateNetValue ? true : false;
                                                    bool bIsExportVAT = (oCustomer.CustomerType_ID == "2") && oCustomer.IsVATenable ? true : false;

                                                    if (bIsVatNbt_Reduce_Enable)
                                                        dInvoiceNetAmount = detail.GrandTotal;
                                                    else
                                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(detail.GrandTotal, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dInvoiceNetAmount, ref dTempNBTAmount, ref dTempVATAmount);

                                                    if (bIsExportVAT)
                                                        dInvoiceNetAmount = detail.GrandTotal - dTempVATAmount;

                                                    #region Payment Validation
                                                    foreach (tbl_sasInvoice_Sattled oSettment in tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(detail.Invoice_ID))
                                                    {
                                                        #region Cheque
                                                        if (oSettment.ChequeRegister_ID != "default" && oSettment.Receipt_ID != "default") //Cheque
                                                        {
                                                            tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(oSettment.ChequeRegister_ID);
                                                            if (oCheque != null && oCheque.ChequeRegister_ID != "default")
                                                            {

                                                                if (oCheque.IsReconcilied || oCheque.IsReIssued)
                                                                {
                                                                    if (oCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C) && oCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_O) && oCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_R))
                                                                    {
                                                                        #region Realized Cheque
                                                                        iDayes = clsCommon.getDays(detail.InvoiceDate, oCheque.DateReconcilied);
                                                                        decimal dDaysForCommission = iDayes - oCusFin.CommissionCreditPeriod;
                                                                        decimal dAllocatedAmount = 0, dBalanceWithoutVAT = 0, dValidAmountForCommission = 0;
                                                                        decimal dRange1Value = 0, dRange2Value = 0, dRange3Value = 0, dRange4Value = 0, dRange5Value = 0;

                                                                        dBalanceAmount -= oSettment.SattledAmount;
                                                                        dValidAmountForCommission = dDaysForCommission <= 0 ? oSettment.SattledAmount : 0;
                                                                        if (bIsVatNbt_Reduce_Enable)
                                                                        {
                                                                            dAllocatedAmount = oSettment.SattledAmount;
                                                                            dBalanceWithoutVAT = dBalanceAmount;
                                                                        }
                                                                        else
                                                                        {
                                                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oSettment.SattledAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dAllocatedAmount, ref dTempNBTAmount, ref dTempVATAmount);
                                                                            dAllocatedAmount = bIsExportVAT ? (dAllocatedAmount + dTempNBTAmount) : dAllocatedAmount;
                                                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dBalanceAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dBalanceWithoutVAT, ref dTempNBTAmount, ref dTempVATAmount);
                                                                            dBalanceWithoutVAT = bIsExportVAT ? (dBalanceWithoutVAT + dTempNBTAmount) : dBalanceWithoutVAT;
                                                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dValidAmountForCommission, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dValidAmountForCommission, ref dTempNBTAmount, ref dTempVATAmount);
                                                                            dValidAmountForCommission = bIsExportVAT ? (dValidAmountForCommission + dTempNBTAmount) : dValidAmountForCommission;
                                                                        }
                                                                        clsGetValues.get_CommissionValue_FromCommissionSlabs(dDaysForCommission, oCusFin.CommissionCreditPeriod, dAllocatedAmount, ref dRange1Value, ref dRange2Value, ref dRange3Value, ref dRange4Value, ref dRange5Value);
                                                                        decimal dGrandTotal = iInvoiceCount > 0 ? 0 : detail.GrandTotal;
                                                                        dInvoiceNetAmount = iInvoiceCount > 0 ? 0 : dInvoiceNetAmount;
                                                                        glbDtsSales.dt_sasCommisionDetail.Adddt_sasCommisionDetailRow(oCustomer.CustomerName, oCustomer.Customer_ID, detail.Invoice_ID, detail.InvoiceDate, dGrandTotal, dInvoiceNetAmount, oCheque.Receipt_ID + "<" + oCheque.ChequeNumber + ">", oCheque.DateReconcilied, dAllocatedAmount, iDayes, dValidAmountForCommission, dRange1Value, dRange2Value, dRange3Value, dRange4Value, dRange5Value, dBalanceWithoutVAT, oCusFin.CommissionCreditPeriod, oCusFin.CreditPeriod);
                                                                        iInvoiceCount++;
                                                                        #endregion
                                                                    }
                                                                    else
                                                                    {
                                                                        #region Returned Cheque
                                                                        decimal dReturnedAmount = oSettment.SattledAmount, dReturnAmountPaid = 0;
                                                                        DateTime dtmPaymentDate = detail.InvoiceDate;
                                                                        string sPaymentDetail = "";
                                                                        foreach (tbl_sasInvoice oReturnedCheque in tbl_sasInvoice.SelectAllByChequeRegister_ID(oCheque.ChequeRegister_ID))
                                                                        {
                                                                            foreach (tbl_sasInvoice_Sattled oRCSettment in tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(oReturnedCheque.Invoice_ID))
                                                                            {
                                                                                #region Cheque
                                                                                if (oRCSettment.ChequeRegister_ID != "default" && oRCSettment.Receipt_ID != "default") //Cheque
                                                                                {
                                                                                    tbl_bpsChequeRegister oRCCheque = tbl_bpsChequeRegister.Select(oRCSettment.ChequeRegister_ID);
                                                                                    if (oRCCheque != null && oRCCheque.ChequeRegister_ID != "default")
                                                                                    {

                                                                                        if (oRCCheque.IsReconcilied || oRCCheque.IsReIssued)
                                                                                        {
                                                                                            if (oRCCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C) && oRCCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_O) && oRCCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_R))
                                                                                            {
                                                                                                dReturnAmountPaid += oRCSettment.SattledAmount;
                                                                                                if (dtmPaymentDate < oRCCheque.DateReconcilied)
                                                                                                {
                                                                                                    dtmPaymentDate = oRCCheque.DateReconcilied;
                                                                                                    sPaymentDetail = "RP " + oRCCheque.Receipt_ID + "<" + oRCCheque.ChequeNumber + ">";
                                                                                                }
                                                                                            }
                                                                                        }

                                                                                    }
                                                                                }
                                                                                #endregion

                                                                                #region Cash
                                                                                else if (oRCSettment.ChequeRegister_ID == "default" && oRCSettment.Receipt_ID != "default")
                                                                                {
                                                                                    tbl_bpsReceipt oRCReceipt = tbl_bpsReceipt.Select(oRCSettment.Receipt_ID);
                                                                                    if (oRCReceipt != null && oRCReceipt.Receipt_ID != "default")
                                                                                    {
                                                                                        if (oRCReceipt.CashAmount > 0)
                                                                                        {
                                                                                            dReturnAmountPaid += oRCSettment.SattledAmount;
                                                                                            if (dtmPaymentDate < oRCReceipt.ReceiptDate)
                                                                                            {
                                                                                                dtmPaymentDate = oRCReceipt.ReceiptDate;
                                                                                                sPaymentDetail = "RP " + oRCReceipt.Receipt_ID;
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                                #endregion

                                                                                #region Credit Note
                                                                                else if (oRCSettment.CreditNote_ID != "default")
                                                                                {
                                                                                    tbl_bpsCreditNote oRCCreditNote = tbl_bpsCreditNote.Select(oRCSettment.CreditNote_ID);
                                                                                    if (oRCCreditNote != null && oRCCreditNote.CreditNote_ID != "default")
                                                                                    {
                                                                                        dReturnAmountPaid += oRCSettment.SattledAmount;
                                                                                        if (dtmPaymentDate < oRCCreditNote.CreditNoteDate)
                                                                                        {
                                                                                            dtmPaymentDate = oRCCreditNote.CreditNoteDate;
                                                                                            sPaymentDetail = "RP " + oRCCreditNote.CreditNote_ID;
                                                                                        }
                                                                                    }
                                                                                }
                                                                                #endregion
                                                                            }

                                                                            if (dReturnAmountPaid >= dReturnedAmount)
                                                                            {
                                                                                iDayes = clsCommon.getDays(detail.InvoiceDate, dtmPaymentDate);
                                                                                decimal dDaysForCommission = iDayes - oCusFin.CommissionCreditPeriod;
                                                                                decimal dAllocatedAmount = 0, dBalanceWithoutVAT = 0, dValidAmountForCommission = 0;
                                                                                decimal dRange1Value = 0, dRange2Value = 0, dRange3Value = 0, dRange4Value = 0, dRange5Value = 0;

                                                                                dBalanceAmount -= oSettment.SattledAmount;
                                                                                dValidAmountForCommission = dDaysForCommission <= 0 ? oSettment.SattledAmount : 0;
                                                                                if (bIsVatNbt_Reduce_Enable)
                                                                                {
                                                                                    dAllocatedAmount = oSettment.SattledAmount;
                                                                                    dBalanceWithoutVAT = dBalanceAmount;
                                                                                }
                                                                                else
                                                                                {
                                                                                    clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oSettment.SattledAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dAllocatedAmount, ref dTempNBTAmount, ref dTempVATAmount);
                                                                                    dAllocatedAmount = bIsExportVAT ? (dAllocatedAmount + dTempNBTAmount) : dAllocatedAmount;
                                                                                    clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dBalanceAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dBalanceWithoutVAT, ref dTempNBTAmount, ref dTempVATAmount);
                                                                                    dBalanceWithoutVAT = bIsExportVAT ? (dBalanceWithoutVAT + dTempNBTAmount) : dBalanceWithoutVAT;
                                                                                    clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dValidAmountForCommission, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dValidAmountForCommission, ref dTempNBTAmount, ref dTempVATAmount);
                                                                                    dValidAmountForCommission = bIsExportVAT ? (dValidAmountForCommission + dTempNBTAmount) : dValidAmountForCommission;
                                                                                }
                                                                                clsGetValues.get_CommissionValue_FromCommissionSlabs(dDaysForCommission, oCusFin.CommissionCreditPeriod, dAllocatedAmount, ref dRange1Value, ref dRange2Value, ref dRange3Value, ref dRange4Value, ref dRange5Value);
                                                                                decimal dGrandTotal = iInvoiceCount > 0 ? 0 : detail.GrandTotal;
                                                                                dInvoiceNetAmount = iInvoiceCount > 0 ? 0 : dInvoiceNetAmount;

                                                                                glbDtsSales.dt_sasCommisionDetail.Adddt_sasCommisionDetailRow(oCustomer.CustomerName, oCustomer.Customer_ID, detail.Invoice_ID, detail.InvoiceDate, dGrandTotal, dInvoiceNetAmount, sPaymentDetail, dtmPaymentDate, dReturnedAmount, iDayes, dValidAmountForCommission, dRange1Value, dRange2Value, dRange3Value, dRange4Value, dRange5Value, dBalanceWithoutVAT, oCusFin.CommissionCreditPeriod, oCusFin.CreditPeriod);
                                                                                iInvoiceCount++;
                                                                            }
                                                                        }
                                                                        #endregion
                                                                    }
                                                                }

                                                            }
                                                        }
                                                        #endregion

                                                        #region Cash
                                                        else if (oSettment.ChequeRegister_ID == "default" && oSettment.Receipt_ID != "default")
                                                        {
                                                            tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(oSettment.Receipt_ID);
                                                            if (oReceipt != null && oReceipt.Receipt_ID != "default")
                                                            {
                                                                if (oReceipt.CashAmount > 0)
                                                                {
                                                                    iDayes = clsCommon.getDays(detail.InvoiceDate, oReceipt.ReceiptDate);
                                                                    decimal dDaysForCommission = iDayes - oCusFin.CommissionCreditPeriod;
                                                                    decimal dAllocatedAmount = 0, dBalanceWithoutVAT = 0, dValidAmountForCommission = 0;
                                                                    decimal dRange1Value = 0, dRange2Value = 0, dRange3Value = 0, dRange4Value = 0, dRange5Value = 0;

                                                                    dBalanceAmount -= oSettment.SattledAmount;
                                                                    dValidAmountForCommission = dDaysForCommission <= 0 ? oSettment.SattledAmount : 0;
                                                                    if (bIsVatNbt_Reduce_Enable)
                                                                    {
                                                                        dAllocatedAmount = oSettment.SattledAmount;
                                                                        dBalanceWithoutVAT = dBalanceAmount;
                                                                    }
                                                                    else
                                                                    {
                                                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oSettment.SattledAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dAllocatedAmount, ref dTempNBTAmount, ref dTempVATAmount);
                                                                        dAllocatedAmount = bIsExportVAT ? (dAllocatedAmount + dTempNBTAmount) : dAllocatedAmount;
                                                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dBalanceAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dBalanceWithoutVAT, ref dTempNBTAmount, ref dTempVATAmount);
                                                                        dBalanceWithoutVAT = bIsExportVAT ? (dBalanceWithoutVAT + dTempNBTAmount) : dBalanceWithoutVAT;
                                                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dValidAmountForCommission, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dValidAmountForCommission, ref dTempNBTAmount, ref dTempVATAmount);
                                                                        dValidAmountForCommission = bIsExportVAT ? (dValidAmountForCommission + dTempNBTAmount) : dValidAmountForCommission;
                                                                    }
                                                                    clsGetValues.get_CommissionValue_FromCommissionSlabs(dDaysForCommission, oCusFin.CommissionCreditPeriod, dAllocatedAmount, ref dRange1Value, ref dRange2Value, ref dRange3Value, ref dRange4Value, ref dRange5Value);
                                                                    decimal dGrandTotal = iInvoiceCount > 0 ? 0 : detail.GrandTotal;
                                                                    dInvoiceNetAmount = iInvoiceCount > 0 ? 0 : dInvoiceNetAmount;
                                                                    glbDtsSales.dt_sasCommisionDetail.Adddt_sasCommisionDetailRow(oCustomer.CustomerName, oCustomer.Customer_ID, detail.Invoice_ID, detail.InvoiceDate, dGrandTotal, dInvoiceNetAmount, oReceipt.Receipt_ID, oReceipt.ReceiptDate, dAllocatedAmount, iDayes, dValidAmountForCommission, dRange1Value, dRange2Value, dRange3Value, dRange4Value, dRange5Value, dBalanceWithoutVAT, oCusFin.CommissionCreditPeriod, oCusFin.CreditPeriod);
                                                                    iInvoiceCount++;
                                                                }
                                                            }
                                                        }
                                                        #endregion

                                                        #region Credit Note
                                                        else if (oSettment.CreditNote_ID != "default")
                                                        {
                                                            tbl_bpsCreditNote oCreditNote = tbl_bpsCreditNote.Select(oSettment.CreditNote_ID);
                                                            if (oCreditNote != null && oCreditNote.CreditNote_ID != "default")
                                                            {

                                                                iDayes = clsCommon.getDays(detail.InvoiceDate, oCreditNote.CreditNoteDate);
                                                                decimal dDaysForCommission = iDayes - oCusFin.CommissionCreditPeriod;
                                                                decimal dAllocatedAmount = 0, dBalanceWithoutVAT = 0, dValidAmountForCommission = 0;
                                                                decimal dRange1Value = 0, dRange2Value = 0, dRange3Value = 0, dRange4Value = 0, dRange5Value = 0;

                                                                dBalanceAmount -= oSettment.SattledAmount;
                                                                dValidAmountForCommission = dDaysForCommission <= 0 ? oSettment.SattledAmount : 0;
                                                                if (bIsVatNbt_Reduce_Enable)
                                                                {
                                                                    dAllocatedAmount = oSettment.SattledAmount;
                                                                    dBalanceWithoutVAT = dBalanceAmount;
                                                                }
                                                                else
                                                                {
                                                                    clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oSettment.SattledAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dAllocatedAmount, ref dTempNBTAmount, ref dTempVATAmount);
                                                                    dAllocatedAmount = bIsExportVAT ? (dAllocatedAmount + dTempNBTAmount) : dAllocatedAmount;
                                                                    clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dBalanceAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dBalanceWithoutVAT, ref dTempNBTAmount, ref dTempVATAmount);
                                                                    dBalanceWithoutVAT = bIsExportVAT ? (dBalanceWithoutVAT + dTempNBTAmount) : dBalanceWithoutVAT;
                                                                    clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dValidAmountForCommission, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dValidAmountForCommission, ref dTempNBTAmount, ref dTempVATAmount);
                                                                    dValidAmountForCommission = bIsExportVAT ? (dValidAmountForCommission + dTempNBTAmount) : dValidAmountForCommission;
                                                                }
                                                                clsGetValues.get_CommissionValue_FromCommissionSlabs(dDaysForCommission, oCusFin.CommissionCreditPeriod, dAllocatedAmount, ref dRange1Value, ref dRange2Value, ref dRange3Value, ref dRange4Value, ref dRange5Value);
                                                                decimal dGrandTotal = iInvoiceCount > 0 ? 0 : detail.GrandTotal;
                                                                dInvoiceNetAmount = iInvoiceCount > 0 ? 0 : dInvoiceNetAmount;
                                                                glbDtsSales.dt_sasCommisionDetail.Adddt_sasCommisionDetailRow(oCustomer.CustomerName, oCustomer.Customer_ID, detail.Invoice_ID, detail.InvoiceDate, dGrandTotal, dInvoiceNetAmount, oCreditNote.CreditNote_ID, oCreditNote.CreditNoteDate, dAllocatedAmount, iDayes, dValidAmountForCommission, dRange1Value, dRange2Value, dRange3Value, dRange4Value, dRange5Value, dBalanceWithoutVAT, oCusFin.CommissionCreditPeriod, oCusFin.CreditPeriod);
                                                                iInvoiceCount++;
                                                            }
                                                        }
                                                        #endregion
                                                    }
                                                    #endregion

                                                    #region Invoice Outstanding
                                                    if (dBalanceAmount > 0)
                                                    {
                                                        decimal dInvoiceOutstandingAmount = 0;
                                                        if (bIsVatNbt_Reduce_Enable)
                                                            dInvoiceOutstandingAmount = dBalanceAmount;
                                                        else
                                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dBalanceAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dInvoiceOutstandingAmount, ref dTempNBTAmount, ref dTempVATAmount);
                                                        dInvoiceOutstandingAmount = bIsExportVAT ? (dInvoiceOutstandingAmount + dTempNBTAmount) : dInvoiceOutstandingAmount;
                                                        decimal dGrandTotal = iInvoiceCount > 0 ? 0 : detail.GrandTotal;
                                                        dInvoiceNetAmount = iInvoiceCount > 0 ? 0 : dInvoiceNetAmount;
                                                        glbDtsSales.dt_sasCommisionDetail.Adddt_sasCommisionDetailRow(oCustomer.CustomerName, oCustomer.Customer_ID, detail.Invoice_ID, detail.InvoiceDate, dGrandTotal, dInvoiceNetAmount, "", detail.InvoiceDate, dInvoiceOutstandingAmount, 0, 0, 0, 0, 0, 0, 0, dInvoiceOutstandingAmount, oCusFin.CommissionCreditPeriod, oCusFin.CreditPeriod);
                                                        iInvoiceCount++;
                                                    }
                                                    #endregion
                                                }
                                                #endregion
                                            }
                                        }
                                        if (bSelesRepSelected)
                                            sFilter = txtSalesRep.Text.Trim();
                                        if (bCustomerSelected)
                                            sFilter = txtCustomer.Text.Trim();
                                        print(sReportPath, sReportTitle_Main, glbDtsSales, "", clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Commission Summary Monthwise
                                else if (Report == enum_ReportName.RG_Sales_Commission_Statement)//(rdoSalesCommissionSummary_DateWise.Checked || rdoSalescommissionStatement.Checked)
                                {                               

                                    if (txtSalesRep.Tag != null && txtSalesRep.Tag.ToString().Trim().Length > 0)
                                    {
                                        if (dtpFrom.Value.Month == dtpTo.Value.Month)
                                        {
                                            #region SalescommissionStatement
                                            try
                                            {
                                                Cursor = Cursors.WaitCursor;
                                                glbDtsSales.dt_sasSalesCommissionSummary_DateWise.Rows.Clear();

                                                List<tbl_genCustomerMaster> oCustomers = tbl_genCustomerMaster.SelectAll().Where(p => p.Customer_ID != "default" && !p.IsDeleted).ToList();
                                                foreach (tbl_genCustomerMaster oCustomer in oCustomers)
                                                {
                                                    #region Filters
                                                    if (bCustomerSelected)
                                                    {
                                                        if (txtCustomer.Tag.ToString() != oCustomer.Customer_ID.Trim())
                                                            continue;

                                                    }
                                                    if (bSelesRepSelected)
                                                    {
                                                        if (txtSalesRep.Tag.ToString() != oCustomer.SalesRep_ID.Trim())
                                                            continue;
                                                    }
                                                    #endregion

                                                    decimal dCommissionPasantage_Original = 0, dCommissionPasantage_Bonus = 0, dSalesTarget_Bonus = 0, dSalesTarget_Minimum = 0, dglbRange1_Pasantage = 0, dglbRange2_Pasantage = 0, dglbRange3_Pasantage = 0, dglbRange4_Pasantage = 0, dglbRange5_Pasantage = 0; //decimal bMinTargetReached = 0;
                                                    tbl_genEmployeeMaster oEmployee = tbl_genEmployeeMaster.Select(oCustomer.SalesRep_ID.Trim());
                                                    if (oEmployee != null && oEmployee.Employee_ID != "default")
                                                    {
                                                        dCommissionPasantage_Original = oEmployee.CommisionPersentage_Normal;
                                                        dCommissionPasantage_Bonus = oEmployee.CommisionPersentage_Bones;
                                                        dSalesTarget_Bonus = oEmployee.SalesTarget;
                                                        dSalesTarget_Minimum = oEmployee.MinimumSalesTarget;
                                                        dglbRange1_Pasantage = oEmployee.CommisionPersentage_Normal * clsConfig.dRange1_Pasantage / 100;
                                                        dglbRange2_Pasantage = oEmployee.CommisionPersentage_Normal * clsConfig.dRange2_Pasantage / 100;
                                                        dglbRange3_Pasantage = oEmployee.CommisionPersentage_Normal * clsConfig.dRange3_Pasantage / 100;
                                                        dglbRange4_Pasantage = oEmployee.CommisionPersentage_Normal * clsConfig.dRange4_Pasantage / 100;
                                                        dglbRange5_Pasantage = oEmployee.CommisionPersentage_Normal * clsConfig.dRange5_Pasantage / 100;
                                                    }

                                                    List<tmpCommissionSummary> otmpCommissionSummarys = new List<tmpCommissionSummary>();
                                                    tbl_genCustomerFinance oCusFin = tbl_genCustomerFinance.Select(oCustomer.Customer_ID);
                                                    if (oCusFin != null && oCusFin.Customer_ID != "default")
                                                    {
                                                        bool bIsVatNbt_Reduce_Enable = (oCustomer.IsSVATenable) ? true : false;
                                                        bool bIsExportVAT = (oCustomer.CustomerType_ID == "2") && oCustomer.IsVATenable ? true : false;

                                                        #region Invoices
                                                        //  decimal dValidAmount = 0, dOverDueAmount = 0, dDeductionAmount = 0;
                                                        foreach (tbl_sasInvoice detail in tbl_sasInvoice.SelectAll_ByCustomerIDandDateRange(dtpFrom.Value.Date, dtpTo.Value.Date, oCustomer.Customer_ID).Where(p => p.Invoice_ID != "default" && !p.IsDeleted && !p.IsReturnedCheque && !p.IsDebitNote))
                                                        {
                                                            int iDayes = 0;
                                                            decimal dBalanceAmount = detail.GrandTotal, dInvoiceNetAmount = 0, dTempValue1 = 0, dTempNBTAmount = 0, dTempVATAmount = 0, dSalesAmount = detail.GrandTotal;
                                                            if (detail.Quotation_ID != "default" || (detail.Job_ID == "default" && detail.DeliveryOrder_ID != "default"))
                                                                continue;

                                                            if (bIsVatNbt_Reduce_Enable)
                                                                dInvoiceNetAmount = detail.GrandTotal;
                                                            else
                                                                clsHelpMethods.SetVATandNBTValues_FromGrandTotal(detail.GrandTotal, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dInvoiceNetAmount, ref dTempNBTAmount, ref dTempVATAmount);
                                                            if (bIsExportVAT)
                                                                dInvoiceNetAmount = detail.GrandTotal - dTempVATAmount;

                                                            #region Payment Validation
                                                            foreach (tbl_sasInvoice_Sattled oSettment in tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(detail.Invoice_ID))
                                                            {
                                                                #region Cheque
                                                                if (oSettment.ChequeRegister_ID != "default" && oSettment.Receipt_ID != "default") //Cheque
                                                                {
                                                                    tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(oSettment.ChequeRegister_ID);
                                                                    if (oCheque != null && oCheque.ChequeRegister_ID != "default")
                                                                    {

                                                                        if (oCheque.IsReconcilied || oCheque.IsReIssued)
                                                                        {
                                                                            if (oCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C) && oCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_O) && oCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_R))
                                                                            {
                                                                                #region Realized Cheque
                                                                                iDayes = clsCommon.getDays(detail.InvoiceDate, oCheque.DateReconcilied);
                                                                                decimal dDaysForCommission = iDayes - oCusFin.CommissionCreditPeriod;
                                                                                decimal dAllocatedAmount = 0, dValidAmountForCommission_Over = 0;
                                                                                decimal dRange1Value = 0, dRange2Value = 0, dRange3Value = 0, dRange4Value = 0, dRange5Value = 0, dRange1Pasantage = 0, dRange2Pasantage = 0, dRange3Pasantage = 0, dRange4Pasantage = 0, dRange5Pasantage = 0, dRange1Commission = 0, dRange2Commission = 0, dRange3Commission = 0, dRange4Commission = 0, dRange5Commission = 0;

                                                                                dBalanceAmount -= oSettment.SattledAmount;
                                                                                dValidAmountForCommission_Over = dDaysForCommission <= 0 ? oSettment.SattledAmount : 0;
                                                                                if (bIsVatNbt_Reduce_Enable)
                                                                                    dAllocatedAmount = oSettment.SattledAmount;
                                                                                else
                                                                                {
                                                                                    clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oSettment.SattledAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dAllocatedAmount, ref dTempNBTAmount, ref dTempVATAmount);
                                                                                    dAllocatedAmount = bIsExportVAT ? (dAllocatedAmount + dTempNBTAmount) : dAllocatedAmount;
                                                                                    clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dValidAmountForCommission_Over, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dValidAmountForCommission_Over, ref dTempNBTAmount, ref dTempVATAmount);
                                                                                    dValidAmountForCommission_Over = bIsExportVAT ? (dValidAmountForCommission_Over + dTempNBTAmount) : dValidAmountForCommission_Over;
                                                                                }

                                                                                clsGetValues.get_CommissionValueAll_FromCommissionSlabs(dDaysForCommission, oCusFin.CommissionCreditPeriod, dAllocatedAmount, oEmployee.CommisionPersentage_Normal, ref dRange1Value, ref dRange2Value, ref dRange3Value, ref dRange4Value, ref dRange5Value, ref dRange1Pasantage, ref dRange2Pasantage, ref dRange3Pasantage, ref dRange4Pasantage, ref dRange5Pasantage, ref dRange1Commission, ref dRange2Commission, ref dRange3Commission, ref dRange4Commission, ref dRange5Commission);
                                                                                glbDtsSales.dt_sasSalesCommissionSummary_DateWise.Adddt_sasSalesCommissionSummary_DateWiseRow(detail.InvoiceDate.Month.ToString(), 0, 0, 0, 0, dCommissionPasantage_Bonus, dSalesTarget_Bonus, "Within 30 Days ", dRange1Value, dglbRange1_Pasantage, dRange1Commission,
                                                                                    "Within 45 Days ", dRange2Value, dglbRange2_Pasantage, dRange2Commission, "Within 60 Days ", dRange3Value, dglbRange3_Pasantage, dRange3Commission, "Within 60 Days", dRange4Value, dglbRange4_Pasantage, dRange4Commission, "Over 90 Days", dRange5Value, dglbRange5_Pasantage, dRange5Commission, 0, detail.InvoiceDate.Month, dSalesTarget_Minimum, dCommissionPasantage_Original, dValidAmountForCommission_Over);
                                                                                #endregion
                                                                            }
                                                                            else
                                                                            {
                                                                                #region Returned Cheque
                                                                                decimal dReturnedAmount = oSettment.SattledAmount, dReturnAmountPaid = 0;
                                                                                DateTime dtmPaymentDate = detail.InvoiceDate;
                                                                                string sPaymentDetail = "";
                                                                                foreach (tbl_sasInvoice oReturnedCheque in tbl_sasInvoice.SelectAllByChequeRegister_ID(oCheque.ChequeRegister_ID))
                                                                                {
                                                                                    foreach (tbl_sasInvoice_Sattled oRCSettment in tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(oReturnedCheque.Invoice_ID))
                                                                                    {
                                                                                        #region Cheque
                                                                                        if (oRCSettment.ChequeRegister_ID != "default" && oRCSettment.Receipt_ID != "default") //Cheque
                                                                                        {
                                                                                            tbl_bpsChequeRegister oRCCheque = tbl_bpsChequeRegister.Select(oRCSettment.ChequeRegister_ID);
                                                                                            if (oRCCheque != null && oRCCheque.ChequeRegister_ID != "default")
                                                                                            {
                                                                                                if (oRCCheque.IsReconcilied || oRCCheque.IsReIssued)
                                                                                                {
                                                                                                    if (oRCCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C) && oRCCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_O) && oRCCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_R))
                                                                                                    {
                                                                                                        dReturnAmountPaid += oRCSettment.SattledAmount;
                                                                                                        if (dtmPaymentDate < oRCCheque.DateReconcilied)
                                                                                                        {
                                                                                                            dtmPaymentDate = oRCCheque.DateReconcilied;
                                                                                                            sPaymentDetail = "RP " + oRCCheque.Receipt_ID + "<" + oRCCheque.ChequeNumber + ">";
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                        #endregion

                                                                                        #region Cash
                                                                                        else if (oRCSettment.ChequeRegister_ID == "default" && oRCSettment.Receipt_ID != "default")
                                                                                        {
                                                                                            tbl_bpsReceipt oRCReceipt = tbl_bpsReceipt.Select(oRCSettment.Receipt_ID);
                                                                                            if (oRCReceipt != null && oRCReceipt.Receipt_ID != "default")
                                                                                            {
                                                                                                if (oRCReceipt.CashAmount > 0)
                                                                                                {
                                                                                                    dReturnAmountPaid += oRCSettment.SattledAmount;
                                                                                                    if (dtmPaymentDate < oRCReceipt.ReceiptDate)
                                                                                                    {
                                                                                                        dtmPaymentDate = oRCReceipt.ReceiptDate;
                                                                                                        sPaymentDetail = "RP " + oRCReceipt.Receipt_ID;
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                        #endregion

                                                                                        #region Credit Note
                                                                                        else if (oRCSettment.CreditNote_ID != "default")
                                                                                        {
                                                                                            tbl_bpsCreditNote oRCCreditNote = tbl_bpsCreditNote.Select(oRCSettment.CreditNote_ID);
                                                                                            if (oRCCreditNote != null && oRCCreditNote.CreditNote_ID != "default")
                                                                                            {
                                                                                                dReturnAmountPaid += oRCSettment.SattledAmount;
                                                                                                if (dtmPaymentDate < oRCCreditNote.CreditNoteDate)
                                                                                                {
                                                                                                    dtmPaymentDate = oRCCreditNote.CreditNoteDate;
                                                                                                    sPaymentDetail = "RP " + oRCCreditNote.CreditNote_ID;
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                        #endregion
                                                                                    }

                                                                                    if (dReturnAmountPaid >= dReturnedAmount)
                                                                                    {
                                                                                        iDayes = clsCommon.getDays(detail.InvoiceDate, dtmPaymentDate);
                                                                                        decimal dDaysForCommission = iDayes - oCusFin.CommissionCreditPeriod;
                                                                                        decimal dAllocatedAmount = 0, dValidAmountForCommission_Over = 0; //decimal dBalanceWithoutVAT = 0;
                                                                                        decimal dRange1Value = 0, dRange2Value = 0, dRange3Value = 0, dRange4Value = 0, dRange5Value = 0, dRange1Pasantage = 0, dRange2Pasantage = 0, dRange3Pasantage = 0, dRange4Pasantage = 0, dRange5Pasantage = 0, dRange1Commission = 0, dRange2Commission = 0, dRange3Commission = 0, dRange4Commission = 0, dRange5Commission = 0;

                                                                                        dBalanceAmount -= oSettment.SattledAmount;
                                                                                        dValidAmountForCommission_Over = dDaysForCommission <= 0 ? oSettment.SattledAmount : 0;
                                                                                        if (bIsVatNbt_Reduce_Enable)
                                                                                        {
                                                                                            dAllocatedAmount = oSettment.SattledAmount;
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oSettment.SattledAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dAllocatedAmount, ref dTempNBTAmount, ref dTempVATAmount);
                                                                                            dAllocatedAmount = bIsExportVAT ? (dAllocatedAmount + dTempNBTAmount) : dAllocatedAmount;
                                                                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dValidAmountForCommission_Over, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dValidAmountForCommission_Over, ref dTempNBTAmount, ref dTempVATAmount);
                                                                                            dValidAmountForCommission_Over = bIsExportVAT ? (dValidAmountForCommission_Over + dTempNBTAmount) : dValidAmountForCommission_Over;
                                                                                        }
                                                                                        clsGetValues.get_CommissionValueAll_FromCommissionSlabs(dDaysForCommission, oCusFin.CommissionCreditPeriod, dAllocatedAmount, oEmployee.CommisionPersentage_Normal, ref dRange1Value, ref dRange2Value, ref dRange3Value, ref dRange4Value, ref dRange5Value, ref dRange1Pasantage, ref dRange2Pasantage, ref dRange3Pasantage, ref dRange4Pasantage, ref dRange5Pasantage, ref dRange1Commission, ref dRange2Commission, ref dRange3Commission, ref dRange4Commission, ref dRange5Commission);
                                                                                        decimal dTotalCommission = dRange1Commission + dRange2Commission + dRange3Commission + dRange4Commission + dRange5Commission;
                                                                                        glbDtsSales.dt_sasSalesCommissionSummary_DateWise.Adddt_sasSalesCommissionSummary_DateWiseRow(detail.InvoiceDate.Month.ToString(), 0, 0, 0, 0, dCommissionPasantage_Bonus, dSalesTarget_Bonus, "Within 30 Days ", dRange1Value, dglbRange1_Pasantage, dRange1Commission,
                                                                                       "Within 45 Days ", dRange2Value, dglbRange2_Pasantage, dRange2Commission, "Within 60 Days ", dRange3Value, dglbRange3_Pasantage, dRange3Commission, "Within 90 Days ", dRange4Value, dglbRange4_Pasantage, dRange4Commission, "Over 90 Days", dRange5Value, dglbRange5_Pasantage, dRange5Commission, 0, detail.InvoiceDate.Month, dSalesTarget_Minimum, dCommissionPasantage_Original, dValidAmountForCommission_Over);

                                                                                    }
                                                                                }
                                                                                #endregion
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                #endregion

                                                                #region Cash
                                                                else if (oSettment.ChequeRegister_ID == "default" && oSettment.Receipt_ID != "default")
                                                                {
                                                                    tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(oSettment.Receipt_ID);
                                                                    if (oReceipt != null && oReceipt.Receipt_ID != "default")
                                                                    {
                                                                        if (oReceipt.CashAmount > 0)
                                                                        {
                                                                            iDayes = clsCommon.getDays(detail.InvoiceDate, oReceipt.ReceiptDate);
                                                                            decimal dDaysForCommission = iDayes - oCusFin.CommissionCreditPeriod;
                                                                            decimal dAllocatedAmount = 0, dValidAmountForCommission = 0;
                                                                            decimal dRange1Value = 0, dRange2Value = 0, dRange3Value = 0, dRange4Value = 0, dRange5Value = 0, dRange1Pasantage = 0, dRange2Pasantage = 0, dRange3Pasantage = 0, dRange4Pasantage = 0, dRange5Pasantage = 0, dRange1Commission = 0, dRange2Commission = 0, dRange3Commission = 0, dRange4Commission = 0, dRange5Commission = 0;

                                                                            dBalanceAmount -= oSettment.SattledAmount;
                                                                            dValidAmountForCommission = dDaysForCommission <= 0 ? oSettment.SattledAmount : 0;
                                                                            if (bIsVatNbt_Reduce_Enable)
                                                                                dAllocatedAmount = oSettment.SattledAmount;
                                                                            else
                                                                            {
                                                                                clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oSettment.SattledAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dAllocatedAmount, ref dTempNBTAmount, ref dTempVATAmount);
                                                                                dAllocatedAmount = bIsExportVAT ? (dAllocatedAmount + dTempNBTAmount) : dAllocatedAmount;
                                                                                clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dValidAmountForCommission, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dValidAmountForCommission, ref dTempNBTAmount, ref dTempVATAmount);
                                                                                dValidAmountForCommission = bIsExportVAT ? (dValidAmountForCommission + dTempNBTAmount) : dValidAmountForCommission;
                                                                            }
                                                                            clsGetValues.get_CommissionValueAll_FromCommissionSlabs(dDaysForCommission, oCusFin.CommissionCreditPeriod, dAllocatedAmount, oEmployee.CommisionPersentage_Normal, ref dRange1Value, ref dRange2Value, ref dRange3Value, ref dRange4Value, ref dRange5Value, ref dRange1Pasantage, ref dRange2Pasantage, ref dRange3Pasantage, ref dRange4Pasantage, ref dRange5Pasantage, ref dRange1Commission, ref dRange2Commission, ref dRange3Commission, ref dRange4Commission, ref dRange5Commission);
                                                                            glbDtsSales.dt_sasSalesCommissionSummary_DateWise.Adddt_sasSalesCommissionSummary_DateWiseRow(detail.InvoiceDate.Month.ToString(), 0, 0, 0, 0, dCommissionPasantage_Bonus, dSalesTarget_Bonus, "Within 30 Days ", dRange1Value, dglbRange1_Pasantage, dRange1Commission,
                                                                                "Within 45 Days ", dRange2Value, dglbRange2_Pasantage, dRange2Commission, "Within 60 Days ", dRange3Value, dglbRange3_Pasantage, dRange3Commission, "Within 90 Days ", dRange4Value, dglbRange4_Pasantage, dRange4Commission, "Over 90 Days", dRange5Value, dglbRange5_Pasantage, dRange5Commission, 0, detail.InvoiceDate.Month, dSalesTarget_Minimum, dCommissionPasantage_Original, dValidAmountForCommission);
                                                                        }
                                                                    }
                                                                }
                                                                #endregion

                                                                #region Credit Note
                                                                else if (oSettment.CreditNote_ID != "default")
                                                                {
                                                                    tbl_bpsCreditNote oCreditNote = tbl_bpsCreditNote.Select(oSettment.CreditNote_ID);
                                                                    if (oCreditNote != null && oCreditNote.CreditNote_ID != "default")
                                                                    {

                                                                        iDayes = clsCommon.getDays(detail.InvoiceDate, oCreditNote.CreditNoteDate);
                                                                        decimal dDaysForCommission = iDayes - oCusFin.CommissionCreditPeriod;
                                                                        decimal dAllocatedAmount = 0, dValidAmountForCommission = 0;
                                                                        decimal dRange1Value = 0, dRange2Value = 0, dRange3Value = 0, dRange4Value = 0, dRange5Value = 0, dRange1Pasantage = 0, dRange2Pasantage = 0, dRange3Pasantage = 0, dRange4Pasantage = 0, dRange5Pasantage = 0, dRange1Commission = 0, dRange2Commission = 0, dRange3Commission = 0, dRange4Commission = 0, dRange5Commission = 0;

                                                                        dBalanceAmount -= oSettment.SattledAmount;
                                                                        dValidAmountForCommission = dDaysForCommission <= 0 ? oSettment.SattledAmount : 0;
                                                                        if (bIsVatNbt_Reduce_Enable)
                                                                            dAllocatedAmount = oSettment.SattledAmount;
                                                                        else
                                                                        {
                                                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oSettment.SattledAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dAllocatedAmount, ref dTempNBTAmount, ref dTempVATAmount);
                                                                            dAllocatedAmount = bIsExportVAT ? (dAllocatedAmount + dTempNBTAmount) : dAllocatedAmount;
                                                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dValidAmountForCommission, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dValidAmountForCommission, ref dTempNBTAmount, ref dTempVATAmount);
                                                                            dValidAmountForCommission = bIsExportVAT ? (dValidAmountForCommission + dTempNBTAmount) : dValidAmountForCommission;
                                                                        }
                                                                        clsGetValues.get_CommissionValueAll_FromCommissionSlabs(dDaysForCommission, oCusFin.CommissionCreditPeriod, dAllocatedAmount, oEmployee.CommisionPersentage_Normal, ref dRange1Value, ref dRange2Value, ref dRange3Value, ref dRange4Value, ref dRange5Value, ref dRange1Pasantage, ref dRange2Pasantage, ref dRange3Pasantage, ref dRange4Pasantage, ref dRange5Pasantage, ref dRange1Commission, ref dRange2Commission, ref dRange3Commission, ref dRange4Commission, ref dRange5Commission);
                                                                        decimal dTotalCommission = dRange1Commission + dRange2Commission + dRange3Commission + dRange4Commission;
                                                                        glbDtsSales.dt_sasSalesCommissionSummary_DateWise.Adddt_sasSalesCommissionSummary_DateWiseRow(detail.InvoiceDate.Month.ToString(), 0, 0, 0, 0, dCommissionPasantage_Bonus, dSalesTarget_Bonus, "Within 30 Days ", dRange1Value, dglbRange1_Pasantage, dRange1Commission,
                                                                            "Within 45 Days ", dRange2Value, dglbRange2_Pasantage, dRange2Commission, "Within 60 Days ", dRange3Value, dglbRange3_Pasantage, dRange3Commission, "Within 90 Days ", dRange4Value, dglbRange4_Pasantage, dRange4Commission, "Over 90 Days", dRange5Value, dglbRange5_Pasantage, dRange5Commission, 0, detail.InvoiceDate.Month, dSalesTarget_Minimum, dCommissionPasantage_Original, dValidAmountForCommission);

                                                                    }
                                                                }
                                                                #endregion
                                                            }
                                                            #endregion

                                                            #region Invoice Outstanding
                                                            if (dBalanceAmount > 0)
                                                            {
                                                                decimal dInvoiceOutstandingAmount = 0;
                                                                if (bIsVatNbt_Reduce_Enable)
                                                                    dInvoiceOutstandingAmount = dBalanceAmount;
                                                                else
                                                                    clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dBalanceAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dInvoiceOutstandingAmount, ref dTempNBTAmount, ref dTempVATAmount);
                                                                dInvoiceOutstandingAmount = bIsExportVAT ? (dInvoiceOutstandingAmount + dTempNBTAmount) : dInvoiceOutstandingAmount;
                                                                glbDtsSales.dt_sasSalesCommissionSummary_DateWise.Adddt_sasSalesCommissionSummary_DateWiseRow(detail.InvoiceDate.Month.ToString(), 0, 0, 0, 0, dCommissionPasantage_Bonus, dSalesTarget_Bonus, "Within 30 Days ", 0, dglbRange1_Pasantage, 0,
                                                                                      "Within 45 Days ", 0, dglbRange2_Pasantage, 0, "Within 60 Days ", 0, dglbRange3_Pasantage, 0, "Within 90 Days ", 0, dglbRange4_Pasantage, 0, "Over 90 Days ", dglbRange5_Pasantage, 0, 0, dInvoiceOutstandingAmount, detail.InvoiceDate.Month, dSalesTarget_Minimum, dCommissionPasantage_Original, 0);
                                                            }
                                                            #endregion

                                                            #region For Header Details
                                                            decimal dNetAmount = 0;
                                                            if (bIsVatNbt_Reduce_Enable)
                                                                dNetAmount = detail.GrandTotal;
                                                            else
                                                                clsHelpMethods.SetVATandNBTValues_FromGrandTotal(detail.GrandTotal, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dNetAmount, ref dTempNBTAmount, ref dTempVATAmount);
                                                            dNetAmount = bIsExportVAT ? (dNetAmount + dTempNBTAmount) : dNetAmount;
                                                            tmpCommissionSummary otmpCommissionSummary = new tmpCommissionSummary();
                                                            otmpCommissionSummary.dSalesValue = dNetAmount;
                                                            otmpCommissionSummary.monthID = detail.InvoiceDate.Month;
                                                            otmpCommissionSummary.dCreditNoteValue = 0;
                                                            otmpCommissionSummarys.Add(otmpCommissionSummary);
                                                            #endregion
                                                        }
                                                        #endregion

                                                        #region Credit Notes
                                                        foreach (tbl_bpsCreditNote oCreditNote in tbl_bpsCreditNote.SelectAll_ByCustomerIDandDateRange(dtpFrom.Value.Date, dtpTo.Value.Date, oCustomer.Customer_ID).Where(p => p.CreditNote_ID != "default" && !p.IsDeleted && p.CreditNoteType_ID != clsAutocode.getCreditNoteTypeID(CreditNoteType.ReturnedChequeDeposit)))
                                                        {
                                                            decimal dCreditNoteNetAmount = 0, dTempValue1 = 0, dTempNBTAmount = 0, dTempVATAmount = 0, dNonSalesCreditValues = 0;
                                                            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                                            {
                                                                foreach (tbl_sasInvoice_Sattled oAllocation in tbl_sasInvoice_Sattled.SelectAllByCreditNote_ID(oCreditNote.CreditNote_ID))
                                                                {
                                                                    tbl_sasInvoice oCRInvoice = tbl_sasInvoice.Select(oAllocation.Invoice_ID);
                                                                    if (oCRInvoice != null && oCRInvoice.Invoice_ID != "default")
                                                                    {
                                                                        if (oCRInvoice.Quotation_ID != "default") //Block Sales
                                                                            dNonSalesCreditValues += oAllocation.SattledAmount;
                                                                        else if (oCRInvoice.DeliveryOrder_ID != "default" && oCRInvoice.Job_ID == "default") //Direct Sales
                                                                            dNonSalesCreditValues += oAllocation.SattledAmount;
                                                                    }
                                                                }
                                                            }
                                                            decimal dValidCRAmount = (oCreditNote.TotalAmount - dNonSalesCreditValues);

                                                            if (bIsVatNbt_Reduce_Enable)
                                                                dCreditNoteNetAmount = dValidCRAmount;
                                                            else
                                                                clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dValidCRAmount, oCreditNote.VatPercentage, oCreditNote.NbtPercentage, ref dTempValue1, ref dCreditNoteNetAmount, ref dTempNBTAmount, ref dTempVATAmount);
                                                            dCreditNoteNetAmount = bIsExportVAT ? (dCreditNoteNetAmount + dTempNBTAmount) : dCreditNoteNetAmount;
                                                            tmpCommissionSummary otmpCommissionSummary = new tmpCommissionSummary();
                                                            otmpCommissionSummary.dSalesValue = 0;
                                                            otmpCommissionSummary.monthID = oCreditNote.CreditNoteDate.Month;
                                                            otmpCommissionSummary.dCreditNoteValue = dCreditNoteNetAmount;
                                                            otmpCommissionSummarys.Add(otmpCommissionSummary);
                                                        }
                                                        #endregion

                                                        #region Add Header Details
                                                        var oBonusCommissions = otmpCommissionSummarys.GroupBy(gb => new { gb.monthID }, (Key, group) => new { MonthID = Key.monthID, SalesValue = group.Sum(p => p.dSalesValue), CreditNoteValue = group.Sum(p => p.dCreditNoteValue) });
                                                        foreach (var oBonusCommission in oBonusCommissions.OrderBy(p => (p.MonthID)))
                                                        {
                                                            decimal dValidAmountForBonous = oBonusCommission.SalesValue - oBonusCommission.CreditNoteValue;
                                                            decimal dExceedAmountForBonus = dValidAmountForBonous - dSalesTarget_Bonus;
                                                            dExceedAmountForBonus = dExceedAmountForBonus > 0 ? dExceedAmountForBonus : 0;

                                                            glbDtsSales.dt_sasSalesCommissionSummary_DateWise.Adddt_sasSalesCommissionSummary_DateWiseRow(oBonusCommission.MonthID.ToString(), oBonusCommission.SalesValue, oBonusCommission.CreditNoteValue, dValidAmountForBonous, dExceedAmountForBonus, dCommissionPasantage_Bonus, dSalesTarget_Bonus, "Within 30 Days ", 0, dglbRange1_Pasantage, 0,
                                                                                   "Within 45 Days ", 0, dglbRange2_Pasantage, 0, "Within 60 Days ", 0, dglbRange3_Pasantage, 0, "Within 90 Days ", 0, dglbRange4_Pasantage, 0, "Over 90 Days ", 0, dglbRange5_Pasantage, 0, 0, oBonusCommission.MonthID, dSalesTarget_Minimum, dCommissionPasantage_Original, 0);

                                                        }
                                                        #endregion
                                                    }
                                                }
                                                if (bSelesRepSelected)
                                                    sFilter = txtSalesRep.Text.Trim();
                                                if (bCustomerSelected)
                                                    sFilter = txtCustomer.Text.Trim();

                                                print(sReportPath, sReportTitle_Main, glbDtsSales, "", clsAutocode.getReportID(Report));
                                            }
                                            catch (Exception ex)
                                            {
                                                clsValidate.WriteErrorLog("", iFormID, ex);
                                                SEACCException.Show(ex);
                                            }
                                            finally
                                            {
                                                glbDtsSales.dt_sasSalesCommissionSummary_DateWise.Rows.Clear();
                                                Cursor = Cursors.Default;
                                            }
                                            #endregion
                                        }
                                        else
                                            MessageBox.Show("Please Select One Month......! ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                        MessageBox.Show("Select A Saleman......!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                #endregion

                                #region Customer History Ledger
                                else if (Report == enum_ReportName.RG_Sales_Journal)
                                {
                                    sFormula = " {vw_rpt_sasLedger.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasLedger.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                                    if (bCustomerSelected)
                                        sFormula += " and {vw_rpt_sasLedger.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";

                                    //string sPath = "";
                                    if ((txtCustomer.Tag != null && txtCustomer.Tag.ToString().Trim().Length > 0))
                                        sReportPath = "\\reports\\SAS\\Finance\\rpt_sas_Ledger_SingleCustomer.rpt";
                                    else
                                        sReportPath = "\\reports\\SAS\\Commen\\rpt_sas_Ledger.rpt";

                                    print(sReportPath, sReportTitle_Main, sFormula);
                                }
                                #endregion

                                #region Invoice Wise Payment Tracking(With Deposited Detail)
                                else if (Report == enum_ReportName.RG_Invoice_wise_payment_Tracking_With_Deposited_Detail)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        gbl_dts_bssOutstandingLedger.Clear();
                                        decimal dBalanceAmount = 0;

                                        #region sFilter(Salesmen & Customer)
                                        if (bCustomerSelected)
                                            sFilter += " Customer Name : " + txtCustomer.Text.Trim();
                                        if (bSelesRepSelected)
                                            sFilter += " Salesman Name : " + txtSalesRep.Text.Trim();
                                        #endregion

                                        string sSalesmanID = "";

                                        foreach (tbl_sasInvoice oInvoice in tbl_sasInvoice.SelectAllByCompanyBranch_ID(clsSecurity.BranchID).Where(p => !p.IsDeleted && p.Invoice_ID != "default" && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date))
                                        {
                                            bool bIsSettledInvoice = false;

                                            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                            if (oCustomer != null && oCustomer.Customer_ID != "default")
                                                sSalesmanID = oCustomer.SalesRep_ID;

                                            if (bCustomerSelected)
                                            {
                                                if (txtCustomer.Tag.ToString().Trim() != oInvoice.Customer_ID)
                                                    continue;
                                            }


                                            #region Sales Rep Filter
                                            if (!chkUseCustomerMastorSaleRep.Checked)
                                            {
                                                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
                                                if (oRef != null && oRef.OrderRefNo != "default")
                                                    sSalesmanID = oRef.Employee_ID;
                                            }

                                            if (bSelesRepSelected)
                                                if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                                    continue;
                                            #endregion

                                            dBalanceAmount = oInvoice.GrandTotal;
                                            string sPoNo = oInvoice.CustomerGrnNo;
                                            int iCount = 0;
                                            foreach (tbl_sasInvoice_Sattled oInvoiceSettle in tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(oInvoice.Invoice_ID.Trim()))
                                            {
                                                bIsSettledInvoice = true;
                                                string sChequNo = "", sPaymentNo = "", sSRNNo = "", sDepositeAccNo = "";
                                                DateTime dRealizeDate = new DateTime();
                                                DateTime dtmChequeDate = new DateTime();
                                                DateTime dtmRecepitDate = new DateTime();
                                                TimeSpan tsNofDate = new TimeSpan();
                                                bool bIsCheque = false;

                                                #region Cheques
                                                if (oInvoiceSettle.ChequeRegister_ID != "default" && oInvoiceSettle.Receipt_ID != "default") //Cheque
                                                {
                                                    tbl_bpsChequeRegister oChequeRegister = tbl_bpsChequeRegister.Select(oInvoiceSettle.ChequeRegister_ID.Trim());
                                                    if (oChequeRegister != null && oChequeRegister.ChequeRegister_ID != "default")
                                                    {
                                                        if (oChequeRegister.PaymentMethod_ID == 0)
                                                        {
                                                            if (oChequeRegister.IsDepositted)
                                                                dRealizeDate = oChequeRegister.DateDeposited;

                                                            foreach (tbl_bpsCashDeposit_Detail oCashDepositeDetail in tbl_bpsCashDeposit_Detail.SelectAllByReceipt_ID(oChequeRegister.Receipt_ID))
                                                            {
                                                                tbl_bpsCashDeposit oCashDeposite = tbl_bpsCashDeposit.Select(oCashDepositeDetail.CashDeposit_ID);
                                                                if (oCashDeposite != null)
                                                                    sDepositeAccNo = oCashDeposite.AccountNumber;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (oChequeRegister.IsReconcilied)
                                                                dRealizeDate = oChequeRegister.DateReconcilied;

                                                            sDepositeAccNo = oChequeRegister.DepositedAccountNumber;
                                                        }

                                                        sPaymentNo = oInvoiceSettle.Receipt_ID;
                                                        sChequNo = oChequeRegister.ChequeNumber;
                                                        dtmChequeDate = oChequeRegister.DateCheque.Date;
                                                        dtmRecepitDate = oChequeRegister.DateRegister.Date;
                                                        tsNofDate = dtmChequeDate - oInvoice.InvoiceDate.Date;
                                                        bIsCheque = true;
                                                    }
                                                }
                                                #endregion

                                                #region Cash
                                                else if (oInvoiceSettle.ChequeRegister_ID == "default" && oInvoiceSettle.Receipt_ID != "default") //Cash
                                                {
                                                    tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(oInvoiceSettle.Receipt_ID.Trim());
                                                    if (oReceipt != null && oReceipt.Receipt_ID != "default")
                                                    {
                                                        foreach (tbl_bpsChequeRegister detail in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oInvoiceSettle.Receipt_ID.Trim()).Where(p => p.PaymentMethod_ID == 0))
                                                        {
                                                            sDepositeAccNo = detail.DepositedAccountNumber;
                                                            dRealizeDate = detail.DateDeposited;
                                                        }

                                                        sPaymentNo = oInvoiceSettle.Receipt_ID;
                                                        dtmRecepitDate = oReceipt.ReceiptDate.Date;
                                                        tsNofDate = dtmRecepitDate - oInvoice.InvoiceDate.Date;
                                                    }
                                                }
                                                #endregion

                                                #region credit Note
                                                else if (oInvoiceSettle.CreditNote_ID != "default") //Credit Note
                                                {
                                                    tbl_bpsCreditNote oCreditNote = tbl_bpsCreditNote.Select(oInvoiceSettle.CreditNote_ID.Trim());
                                                    if (oCreditNote != null && oCreditNote.CreditNote_ID != "default")
                                                    {
                                                        sPaymentNo = oInvoiceSettle.CreditNote_ID;
                                                        dtmRecepitDate = oCreditNote.CreditNoteDate.Date;
                                                        tsNofDate = dtmRecepitDate - oInvoice.InvoiceDate.Date;

                                                        List<tbl_sasSalesReturnedNote> oSRN = tbl_sasSalesReturnedNote.SelectAll().Where(p => p.CreditNote_ID == sPaymentNo).ToList();
                                                        if (oSRN.Count > 0)
                                                            sSRNNo = oSRN.FirstOrDefault().SalesReturnedNote_ID;
                                                    }
                                                }
                                                #endregion

                                                dBalanceAmount -= oInvoiceSettle.SattledAmount;
                                                gbl_dts_bssOutstandingLedger.dt_bssInvoiceWisePaymentTracking.Adddt_bssInvoiceWisePaymentTrackingRow(oInvoiceSettle.Invoice_ID, oInvoice.InvoiceDate, sPoNo, sPaymentNo, sSRNNo, dtmRecepitDate, dtmChequeDate, sChequNo, oInvoiceSettle.SattledAmount, dBalanceAmount, tsNofDate.TotalDays,
                                                    bIsCheque, iCount == 0 ? oInvoice.GrandTotal : 0, oInvoice.Customer_ID, clsGenaralName.getName_Customer(oInvoice.Customer_ID), sDepositeAccNo, dRealizeDate);
                                                iCount++;

                                            }

                                            if (!bIsSettledInvoice)
                                            {
                                                dBalanceAmount = oInvoice.GrandTotal - oInvoice.SeattleAmount;
                                                DateTime dtmNiglectDate = new DateTime(00 - 00 - 0000).Date;
                                                gbl_dts_bssOutstandingLedger.dt_bssInvoiceWisePaymentTracking.Adddt_bssInvoiceWisePaymentTrackingRow(oInvoice.Invoice_ID, oInvoice.InvoiceDate, sPoNo, "", "", dtmNiglectDate, dtmNiglectDate, "", 0, dBalanceAmount, 0, false, oInvoice.GrandTotal, oInvoice.Customer_ID, clsGenaralName.getName_Customer(oInvoice.Customer_ID), "", DateTime.MinValue);
                                            }
                                        }

                                        if (rdoDeleted.Checked)
                                            sFilter += (sFilter != "" ? " | " : "") + "Cancelled Records Only ";
                                        if (rdoActual.Checked)
                                            sFilter += (sFilter != "" ? " | " : "") + "Active records Only ";
                                        if (rdoAll.Checked)
                                            sFilter += (sFilter != "" ? " | " : "") + "All Records ";

                                        gbl_dts_bssOutstandingLedger.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, sFilter);
                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, gbl_dts_bssOutstandingLedger, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        gbl_dts_bssOutstandingLedger.Clear();
                                    }
                                }
                                #endregion

                                #region Invoice wise payment Tracking
                                else if (Report == enum_ReportName.RG_Invoice_wise_payment_Tracking || Report == enum_ReportName.RG_Customer_wise_payment_Tracking)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        gbl_dts_bssOutstandingLedger.Clear();
                                        decimal dBalanceAmount = 0;

                                        if (rdoDeleted.Checked)
                                            sFilter += (sFilter != "" ? " | " : "") + "Cancelled Records Only ";
                                        if (rdoActual.Checked)
                                            sFilter += (sFilter != "" ? " | " : "") + "Active records Only ";
                                        if (rdoAll.Checked)
                                            sFilter += (sFilter != "" ? " | " : "") + "All Records ";

                                        #region sFilter(Salesmen & Customer)
                                        if (bCustomerSelected)
                                            sFilter += " Customer Name : " + txtCustomer.Text.Trim();
                                        if (bSelesRepSelected)
                                            sFilter += " Salesman Name : " + txtSalesRep.Text.Trim();
                                        #endregion

                                        #region Customer
                                        List<tbl_genCustomerMaster> oCustomerL;

                                        #endregion

                                        string sSalesmanID = "";

                                        foreach (tbl_sasInvoice oInvoice in tbl_sasInvoice.SelectAllByCompanyBranch_ID(clsSecurity.BranchID).Where(p => !p.IsDeleted && p.Invoice_ID != "default" && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date))
                                        {
                                            bool bIsSettledInvoice = false;

                                            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                            if (oCustomer != null && oCustomer.Customer_ID != "default")
                                                sSalesmanID = oCustomer.SalesRep_ID;

                                            if (bCustomerSelected)
                                            {
                                                if (txtCustomer.Tag.ToString().Trim() != oInvoice.Customer_ID)
                                                    continue;
                                            }


                                            #region Sales Rep Filter
                                            if (!chkUseCustomerMastorSaleRep.Checked)
                                            {
                                                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
                                                if (oRef != null && oRef.OrderRefNo != "default")
                                                    sSalesmanID = oRef.Employee_ID;
                                            }

                                            if (bSelesRepSelected)
                                                if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                                    continue;
                                            #endregion

                                            dBalanceAmount = oInvoice.GrandTotal;

                                            string sCOID = "", sPoNo = "";
                                            foreach (tbl_sasInvoice_Detail oInvoiceDetail in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID))
                                            {
                                                sCOID = oInvoiceDetail.CustomerOrder_ID;
                                            }

                                            if (sCOID != null && sCOID != "default")
                                            {
                                                tbl_sasCustomerOrder oCO = tbl_sasCustomerOrder.Select(sCOID);
                                                if (oCO != null)
                                                    sPoNo = oCO.PurchaseOrder_ID;
                                            }

                                            int iCount = 0;
                                            foreach (tbl_sasInvoice_Sattled oInvoiceSettle in tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(oInvoice.Invoice_ID.Trim()))
                                            {
                                                bIsSettledInvoice = true;
                                                string sChequNo = "", sPaymentNo = "", sSRNNo = "";
                                                DateTime dtmChequeDate = new DateTime();
                                                DateTime dtmRecepitDate = new DateTime();
                                                TimeSpan tsNofDate = new TimeSpan();
                                                bool bIsCheque = false;
                                                if (oInvoiceSettle.ChequeRegister_ID != "default" && oInvoiceSettle.Receipt_ID != "default") //Cheque
                                                {
                                                    tbl_bpsChequeRegister oChequeRegister = tbl_bpsChequeRegister.Select(oInvoiceSettle.ChequeRegister_ID.Trim());
                                                    if (oChequeRegister != null && oChequeRegister.ChequeRegister_ID != "default")
                                                    {
                                                        sPaymentNo = oInvoiceSettle.Receipt_ID;
                                                        sChequNo = oChequeRegister.ChequeNumber;
                                                        dtmChequeDate = oChequeRegister.DateCheque.Date;
                                                        dtmRecepitDate = oChequeRegister.DateRegister.Date;
                                                        tsNofDate = dtmChequeDate - oInvoice.InvoiceDate.Date;
                                                        bIsCheque = true;
                                                    }
                                                }
                                                else if (oInvoiceSettle.ChequeRegister_ID == "default" && oInvoiceSettle.Receipt_ID != "default") //Cash
                                                {
                                                    tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(oInvoiceSettle.Receipt_ID.Trim());
                                                    if (oReceipt != null && oReceipt.Receipt_ID != "default")
                                                    {
                                                        sPaymentNo = oInvoiceSettle.Receipt_ID;
                                                        dtmRecepitDate = oReceipt.ReceiptDate.Date;
                                                        tsNofDate = dtmRecepitDate - oInvoice.InvoiceDate.Date;
                                                    }
                                                }
                                                else if (oInvoiceSettle.CreditNote_ID != "default") //Credit Note
                                                {
                                                    tbl_bpsCreditNote oCreditNote = tbl_bpsCreditNote.Select(oInvoiceSettle.CreditNote_ID.Trim());
                                                    if (oCreditNote != null && oCreditNote.CreditNote_ID != "default")
                                                    {
                                                        sPaymentNo = oInvoiceSettle.CreditNote_ID;
                                                        dtmRecepitDate = oCreditNote.CreditNoteDate.Date;
                                                        tsNofDate = dtmRecepitDate - oInvoice.InvoiceDate.Date;

                                                        List<tbl_sasSalesReturnedNote> oSRN = tbl_sasSalesReturnedNote.SelectAll().Where(p => p.CreditNote_ID == sPaymentNo).ToList();
                                                        if (oSRN.Count > 0)
                                                            sSRNNo = oSRN.FirstOrDefault().SalesReturnedNote_ID;
                                                    }
                                                }

                                                dBalanceAmount -= oInvoiceSettle.SattledAmount;
                                                gbl_dts_bssOutstandingLedger.dt_bssInvoiceWisePaymentTracking.Adddt_bssInvoiceWisePaymentTrackingRow(oInvoiceSettle.Invoice_ID, oInvoice.InvoiceDate, sPoNo, sPaymentNo, sSRNNo, dtmRecepitDate, dtmChequeDate, sChequNo, oInvoiceSettle.SattledAmount, dBalanceAmount, tsNofDate.TotalDays, bIsCheque, iCount == 0 ? oInvoice.GrandTotal : 0, oInvoice.Customer_ID, clsGenaralName.getName_Customer(oInvoice.Customer_ID), "", DateTime.MinValue);
                                                iCount++;
                                            }

                                            if (!bIsSettledInvoice)
                                            {
                                                dBalanceAmount = oInvoice.GrandTotal - oInvoice.SeattleAmount;
                                                DateTime dtmNiglectDate = new DateTime(00 - 00 - 0000).Date;
                                                gbl_dts_bssOutstandingLedger.dt_bssInvoiceWisePaymentTracking.Adddt_bssInvoiceWisePaymentTrackingRow(oInvoice.Invoice_ID, oInvoice.InvoiceDate, sPoNo, "", "", dtmNiglectDate, dtmNiglectDate, "", 0, dBalanceAmount, 0, false, oInvoice.GrandTotal, oInvoice.Customer_ID, clsGenaralName.getName_Customer(oInvoice.Customer_ID), "", DateTime.MinValue);
                                            }
                                        }

                                        gbl_dts_bssOutstandingLedger.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, sFilter);
                                        //}
                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, gbl_dts_bssOutstandingLedger, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        gbl_dts_bssOutstandingLedger.Clear();
                                    }
                                }
                                #endregion

                                #region Receipt Settlement Ledger
                                else if (Report == enum_ReportName.RG_Receipt_wise_Invoice_Tracking)
                                {
                                    sFormula = " {vw_rpt_bpsReceiptHeder.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsReceiptHeder.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                    if (bSelesRepSelected)
                                        sFormula += " and {vw_rpt_bpsReceiptHeder.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";
                                    if (bCustomerSelected)
                                        sFormula += " and {vw_rpt_bpsReceiptHeder.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";

                                    sFormula += " and  {vw_rpt_bpsReceiptHeder.isDeleted} = false";
                                    print(sReportPath, sReportTitle_Main, sFormula);
                                }
                                #endregion

                                #region Allocation
                                else if (Report == enum_ReportName.RG_Receipt_Allocation)
                                {
                                    if (chkAdvance.Checked || chkPartPayment.Checked || chkOverPayment.Checked)
                                    {
                                        try
                                        {
                                            DateTime dtmReceiptDate = DateTime.MaxValue;

                                            sFilter = "Allocation Type : ";
                                            if (chkAdvance.Checked)
                                                sFilter += " Advance ,";
                                            if (chkPartPayment.Checked)
                                                sFilter += " Part Payment ,";
                                            if (chkOverPayment.Checked)
                                                sFilter += " Over Payment ,";

                                            #region sFilter(Customer)
                                            if (bCustomerSelected)
                                                sFilter += " Customer Name : " + txtCustomer.Text.Trim();


                                            #endregion

                                            Cursor = Cursors.WaitCursor;
                                            glb_dtsReceiptAllocation.Clear();
                                            foreach (tbl_sasInvoice_Sattled detail in tbl_sasInvoice_Sattled.SelectAll().Where(p => p.Invoice_ID != "default" && p.AllocationDate.Date >= dtpFrom.Value.Date && p.AllocationDate.Date <= dtpTo.Value.Date).OrderBy(p => p.AllocationID))
                                            {
                                                bool bPass = false;
                                                if (chkAdvance.Checked)
                                                {
                                                    if (detail.IsAdvancePayment)
                                                        bPass = true;
                                                }
                                                if (chkPartPayment.Checked)
                                                {
                                                    if (!detail.IsAdvancePayment && !detail.IsOverPayment)
                                                        bPass = true;
                                                }
                                                if (chkOverPayment.Checked)
                                                {
                                                    if (detail.IsOverPayment)
                                                        bPass = true;
                                                }
                                                if (!bPass)
                                                    continue;

                                                tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(detail.Invoice_ID);
                                                tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(detail.Receipt_ID);

                                                #region Customer wise Fillter
                                                if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Length > 0)
                                                    if (txtCustomer.Tag.ToString() != oReceipt.Customer_ID)
                                                        continue;
                                                #endregion



                                                if (oInvoice != null && oInvoice.Invoice_ID != "default" && oReceipt != null && oReceipt.Receipt_ID != "default")
                                                {
                                                    glb_dtsReceiptAllocation.dt_sasAdvanceAllocation_Summary.Adddt_sasAdvanceAllocation_SummaryRow(detail.AllocationID, detail.AllocationDate, detail.SattledAmount, detail.Receipt_ID, oReceipt.ReceiptDate, oReceipt.TotalAmount, detail.Invoice_ID, oInvoice.InvoiceDate, clsGenaralName.getName_Customer(oReceipt.Customer_ID), detail.SattledDate);
                                                }
                                            }
                                            sReportTitle_Main = chkPartPayment.Checked ? "Part Payment Receipt Allocation Report" : (chkAdvance.Checked) ? "Advance Receipt Allocation Report" : "Over Payment Receipt Allocation Report";
                                            glb_dtsReceiptAllocation.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, sFilter);

                                            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                            {
                                                frm_ReportViewer_New rpt = new Digiteq.frm_ReportViewer_New();
                                                rpt.print(sReportPath, glb_dtsReceiptAllocation, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                            }
                                            else
                                            {
                                                print(sReportPath, sReportTitle_Main, glb_dtsReceiptAllocation, sFilter, clsAutocode.getReportID(Report));
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            clsValidate.WriteErrorLog("", iFormID, ex);
                                            SEACCException.Show(ex);
                                        }
                                        finally
                                        {
                                            Cursor = Cursors.Default;
                                            glb_dtsReceiptAllocation.Clear();
                                        }
                                    }
                                    else
                                        MessageBox.Show("Please Select Allocation Type.", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                #endregion

                                #region Advance & OverPayment Listing
                                else if (Report == enum_ReportName.RG_OverPaymentListing || Report == enum_ReportName.RG_AdvanceListing)
                                {
                                    glbDtsSales.Clear();
                                    Cursor = Cursors.WaitCursor;
                                    try
                                    {
                                        List<tbl_bpsReceipt> oReceipts = new List<tbl_bpsReceipt>();
                                        if (Report == enum_ReportName.RG_OverPaymentListing)
                                            oReceipts = tbl_bpsReceipt.SelectAllByCompanyBranch_ID(clsSecurity.BranchID).Where(p => p.Receipt_ID != "default" && !p.IsDeleted && !p.IsAdvance && p.ReceiptDate.Date >= dtpFrom.Value.Date && p.ReceiptDate.Date <= dtpTo.Value.Date).ToList();

                                        else if (Report == enum_ReportName.RG_AdvanceListing)
                                            oReceipts = tbl_bpsReceipt.SelectAllByCompanyBranch_ID(clsSecurity.BranchID).Where(p => !p.IsDeleted && p.Receipt_ID != "default" && p.IsAdvance && p.ReceiptDate.Date >= dtpFrom.Value.Date && p.ReceiptDate.Date <= dtpTo.Value.Date).ToList();

                                        string sSalesmanID = "";
                                        foreach (tbl_bpsReceipt oReceipt in oReceipts)
                                        {
                                            if (oReceipt.Receipt_ID != "default")
                                            {
                                                sSalesmanID = "";

                                                if (bCustomerSelected)
                                                {
                                                    if (txtCustomer.Tag.ToString().Trim() != oReceipt.Customer_ID)
                                                        continue;
                                                }
                                                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oReceipt.Customer_ID);
                                                if (oCustomer != null)
                                                {
                                                    decimal dOverpaymentTotal = 0, dAdvancepaymentTotal = 0, dSettleAmount = 0;
                                                    decimal dAllocatedAmount = 0;
                                                    foreach (tbl_sasInvoice_Sattled oSettle in tbl_sasInvoice_Sattled.SelectAllByReceipt_ID(oReceipt.Receipt_ID))
                                                    {
                                                        dOverpaymentTotal += oSettle.IsOverPayment ? oSettle.SattledAmount : 0;
                                                        dAdvancepaymentTotal += oSettle.IsAdvancePayment ? oSettle.SattledAmount : 0;
                                                        dSettleAmount += oSettle.SattledAmount;
                                                    }

                                                    decimal dBalanceAmount = oReceipt.TotalAmount - dSettleAmount;
                                                    if (Report == enum_ReportName.RG_OverPaymentListing)
                                                    {
                                                        if (dBalanceAmount <= 0)
                                                            continue;

                                                        dAllocatedAmount = dOverpaymentTotal;

                                                    }
                                                    else if (Report == enum_ReportName.RG_AdvanceListing)
                                                    {
                                                        dAllocatedAmount = dAdvancepaymentTotal;
                                                    }

                                                    #region Sales rep
                                                    if (!chkUseCustomerMastorSaleRep.Checked)
                                                    {
                                                        tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oReceipt.OrderRefNo_ID);
                                                        if (oRef != null && oRef.OrderRefNo != "default")
                                                            sSalesmanID = oRef.Employee_ID;
                                                    }
                                                    else
                                                        sSalesmanID = oCustomer.SalesRep_ID;

                                                    if (bSelesRepSelected)
                                                        if (txtSalesRep.Tag.ToString().Trim() != sSalesmanID)
                                                            continue;
                                                    #endregion

                                                    #region sFilter(Salesmen & Customer)



                                                    #endregion

                                                    string sChequeNo = "", sTransactionCode = oReceipt.InvoiceList;
                                                    foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID).Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default"))
                                                    {
                                                        string sSeperator = sChequeNo.Length > 0 ? " / " : "";
                                                        sChequeNo += sSeperator + oCheque.ChequeNumber;
                                                    }

                                                    glbDtsSales.dt_OverPaymentListing.Adddt_OverPaymentListingRow(oReceipt.Receipt_ID, oReceipt.ReceiptDate, oReceipt.Customer_ID, oCustomer.CustomerName, "", oReceipt.TotalAmount, dAllocatedAmount, dBalanceAmount, oReceipt.Remark, sChequeNo, sTransactionCode, clsGenaralName.getName_Employee(sSalesmanID));
                                                }
                                            }
                                        }

                                        #region Set sFilter(cancel,active,all records)
                                        if (rdoDeleted.Checked)
                                            sFilter += (sFilter != "" ? " | " : "") + "Cancelled Records Only ";
                                        if (rdoActual.Checked)
                                            sFilter += (sFilter != "" ? " | " : "") + "Active records Only ";
                                        if (rdoAll.Checked)
                                            sFilter += (sFilter != "" ? " | " : "") + "All Records ";

                                        //if (bSelesRepSelected)
                                        //    sFilter += " Salesman Name : " + txtSalesRep.Text.Trim();
                                        //if (bCustomerSelected)
                                        //    sFilter += " Customer Name : " + txtCustomer.Text.Trim();


                                        #endregion

                                        glbDtsSales.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glbDtsSales, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                          }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glbDtsSales.Clear();
                                    }
                                }
                                #endregion

                                #region Incentive Report
                                else if (Report == enum_ReportName.ST_Incentive)
                                {
                                    try
                                    {
                                        if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Incentive)))
                                        {
                                            Cursor = Cursors.WaitCursor;
                                            glb_dts_bssIncentive.dt_Incenive.Rows.Clear();
                                            sFilter = "";
                                            string sOldCOID = "";
                                            foreach (tbl_sasCustomerOrder oCustomerOrder in tbl_sasCustomerOrder.SelectAll().Where(p => p.CustomerOrder_ID != "default" && p.CustomerOrderDate.Date >= dtpFrom.Value.Date && p.CustomerOrderDate.Date <= dtpTo.Value.Date))
                                            {
                                                decimal dOrderedQty = 0;

                                                if (bCustomerSelected)
                                                    if (oCustomerOrder.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                        continue;

                                                if (bCustomerSelected)
                                                    sFilter += " Customer Name : " + txtCustomer.Text.Trim();

                                                foreach (tbl_sasCustomerOrder_Detail oCODetail in tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(oCustomerOrder.CustomerOrder_ID))
                                                    dOrderedQty = oCustomerOrder.IsWeightCalculation ? oCODetail.Weight : oCODetail.Qty;

                                                foreach (tbl_sasDeliveryOrder oDo in tbl_sasDeliveryOrder.SelectAllByCustomerOrder_ID(oCustomerOrder.CustomerOrder_ID).Where(p => !p.IsDeleted && p.DeliveryOrder_ID != "default"))
                                                {
                                                    decimal dSRNQty = 0, dDeliveryQty = 0;
                                                    foreach (tbl_sasDeliveryOrder_Detail oDoDetail in tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(oDo.DeliveryOrder_ID))
                                                    {
                                                        dDeliveryQty += oDo.IsWeightCalculation ? oDoDetail.Weight : oDoDetail.Qty;
                                                        foreach (tbl_sasSalesReturnedNote oSalesReturn in tbl_sasSalesReturnedNote.SelectAllByDeliveryOrder_ID(oDo.DeliveryOrder_ID).Where(p => !p.IsDeleted && p.SalesReturnedNote_ID != "default"))
                                                        {
                                                            foreach (tbl_sasSalesReturnedNote_Detail oSRD in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSalesReturn.SalesReturnedNote_ID))
                                                                dSRNQty += oSalesReturn.IsWeightCalculation ? oSRD.Weight : oSRD.Qty;
                                                        }
                                                    }

                                                    foreach (tbl_sasInvoice oInvoice in tbl_sasInvoice.SelectAllByDeliveryOrder_ID(oDo.DeliveryOrder_ID).Where(p => !p.IsDeleted && p.Invoice_ID != "default"))
                                                    {
                                                        decimal dCRNAmount = 0, dPaidAmount = 0, dInvQty = 0;
                                                        foreach (tbl_sasInvoice_Detail oInvDetail in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID))
                                                            dInvQty += oInvoice.IsWeightCalculation ? oInvDetail.Weight : oInvDetail.Qty;

                                                        foreach (tbl_sasInvoice_Sattled oSettment in tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(oInvoice.Invoice_ID))
                                                        {
                                                            if (oSettment.CreditNote_ID != "default")
                                                            {
                                                                tbl_bpsCreditNote oCreditNote = tbl_bpsCreditNote.Select(oSettment.CreditNote_ID);
                                                                if (oCreditNote != null && oCreditNote.CreditNote_ID != "default" && !oCreditNote.IsDeleted)
                                                                {
                                                                    dCRNAmount += oCreditNote.TotalAmount;
                                                                }
                                                            }
                                                            else
                                                                dPaidAmount += oSettment.SattledAmount;
                                                        }
                                                        decimal dBalanceAmount = oInvoice.GrandTotal - dPaidAmount - dCRNAmount;
                                                        decimal dActualQty = dInvQty - dSRNQty;
                                                        bool bSameOrder = oCustomerOrder.CustomerOrder_ID == sOldCOID ? true : false;
                                                        string sPO = bSameOrder ? "" : oCustomerOrder.PurchaseOrder_ID;
                                                        string sJobID = bSameOrder ? "" : oDo.Job_ID;
                                                        decimal dJobQty = bSameOrder ? 0 : dOrderedQty;
                                                        decimal dPaybleAmount = dActualQty * oCustomerOrder.CommissionRate;
                                                        glb_dts_bssIncentive.dt_Incenive.Adddt_InceniveRow(sPO, sJobID, dJobQty, oInvoice.InvoiceDate, oInvoice.Invoice_ID, oDo.DeliveryOrder_ID, oInvoice.GrandTotal, dPaidAmount, dCRNAmount, dBalanceAmount, dInvQty, dSRNQty, dActualQty, oCustomerOrder.CommissionRate, dPaybleAmount);
                                                        sOldCOID = oCustomerOrder.CustomerOrder_ID;
                                                    }
                                                }
                                            }

                                            glb_dts_bssIncentive.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, sFilter);

                                            frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                            rpt.print(sReportPath, glb_dts_bssIncentive, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.ST_Incentive));
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        glb_dts_bssIncentive.dt_Incenive.Rows.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }

                                #endregion

                                #region Receipt Tracer
                                if (Report == enum_ReportName.ST_ChequeTracer)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glbdts_bssRegister.Clear();
                                        decimal dCashAmount = 0, dChequeAmount = 0;
                                        decimal dTotCashAmount = 0;

                                        if (bCustomerSelected)
                                            sFilter += " Customer Name : " + txtCustomer.Text.Trim();

                                        tbl_zCustomerType oCType = null;

                                        foreach (tbl_bpsReceipt oReceipt in tbl_bpsReceipt.SelectAll().Where(p => p.Receipt_ID != "default" && p.ReceiptDate.Date >= dtpFrom.Value.Date && p.ReceiptDate.Date <= dtpTo.Value.Date))
                                        {
                                            string sSalesRepID = "", sCustomerName = "";
                                            dCashAmount = 0; dChequeAmount = 0;

                                            #region Common Filter
                                            if (bCustomerSelected)
                                            {
                                                if (oReceipt.Customer_ID != txtCustomer.Tag.ToString())
                                                    continue;
                                            }

                                            #region Set Sales rep
                                            tbl_genCustomerMaster oMaster = tbl_genCustomerMaster.Select(oReceipt.Customer_ID);
                                            if (oMaster != null)
                                            {
                                                oCType = tbl_zCustomerType.Select(oMaster.CustomerType_ID);
                                                sCustomerName = oMaster.CustomerName;
                                                sSalesRepID = oMaster.SalesRep_ID;
                                            }

                                            if (!chkUseCustomerMastorSaleRep.Checked)
                                            {
                                                tbl_zOrderRefNo oRefNo = tbl_zOrderRefNo.Select(oReceipt.OrderRefNo_ID);
                                                if (oRefNo != null)
                                                    sSalesRepID = oRefNo.Employee_ID;
                                            }
                                            #endregion

                                            if (bSelesRepSelected)
                                                if (sSalesRepID != txtSalesRep.Tag.ToString().Trim())
                                                    continue;

                                            //if (cmbReceiptType.Text == "Advanced Payment")
                                            //{
                                            //    if (oReceipt.IsAdvance != true)
                                            //        continue;
                                            //}
                                            //else if (cmbReceiptType.Text == "Part Payments")
                                            //{
                                            //    if (oReceipt.IsAdvance != false)
                                            //        continue;
                                            //}

                                            if (rdoDeleted.Checked)
                                                if (oReceipt.IsDeleted != true)
                                                    continue;

                                            if (rdoActual.Checked)
                                                if (oReceipt.IsDeleted != false)
                                                    continue;

                                            //if (cmbCustomerType.Text != "<All Customers>".Trim())
                                            //{
                                            //    if (oCType != null)
                                            //        if (oCType.TypeName != cmbCustomerType.Text.Trim())
                                            //            continue;
                                            //}
                                            #endregion


                                            foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID).Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default"))
                                            {
                                                #region Cheque / Cash filter
                                                if (chkCheque.Checked && chkCash.Checked)
                                                {
                                                    //if (oReceipt.CashAmount == 0 && oReceipt.ChequeAmount == 0)
                                                    //    continue;
                                                }
                                                else if (chkCheque.Checked)
                                                {
                                                    if (oCheque.PaymentMethod_ID != 1)
                                                        //if (oReceipt.CashAmount != 0)
                                                        continue;
                                                }
                                                else if (chkCash.Checked)
                                                {
                                                    //if (oReceipt.ChequeAmount != 0)
                                                    if (oCheque.PaymentMethod_ID == 1)
                                                        continue;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                                #endregion

                                                if (oCheque.PaymentMethod_ID != 1)
                                                {
                                                    dCashAmount += oCheque.Amount;
                                                    dTotCashAmount += dCashAmount;
                                                }
                                                else
                                                    dChequeAmount += oCheque.Amount;

                                                glbdts_bssRegister.dt_Receipt_Cheques.Adddt_Receipt_ChequesRow(oReceipt.Receipt_ID, oCheque.ChequeRegister_ID, oCheque.ChequeNumber, oCheque.DateCheque, clsGenaralName.getName_Bank(oCheque.Bank_ID), oCheque.AccountNumber, clsGenaralName.getName_ChequeStatus(oCheque.ChequeStatus_ID), oCheque.Amount);
                                            }

                                            glbdts_bssRegister.dt_Receipt.Adddt_ReceiptRow(oReceipt.Receipt_ID, oReceipt.ReceiptDate, oReceipt.Customer_ID, sCustomerName, dCashAmount, dChequeAmount, (dCashAmount + dChequeAmount), oReceipt.IsDeleted);
                                        }

                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CashTotal", clsFormatter.FormatDecimalPlaces_Price(dTotCashAmount), true,false);
                                        glbdts_bssRegister.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glbdts_bssRegister, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glbdts_bssRegister.Clear();
                                    }
                                }
                                #endregion
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID, ex);
                        SEACCException.Show(ex);
                    }
                }
            }
        }
        #endregion

        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearField();
        }
        #endregion

        #region ClearField
        private void clearField()
        {
            txtCustomer.Text = "<<ALL Customer>>";
            txtSalesRep.Text = "<<ALL Sales Rep>>";
            txtCollector.Text = "<<ALL Collector>>";
            cmbCurrency.SelectedIndex = 0;

            txtCustomer.Tag = null;
            txtSalesRep.Tag = null;
            txtCollector.Tag = null;

            dtpFrom.Value = clsSecurity.getServerDateTime();
            dtpTo.Value = clsSecurity.getServerDateTime();

            chkAdvance.Checked = false;
            chkOverPayment.Checked = false;
            chkPartPayment.Checked = false;
            chkAllocationNumberWise.Checked = false;
            chkUseCustomerMastorSaleRep.Checked = false;

            chkCash.Checked = true;
            chkCheque.Checked = true;
            rdoActual.Checked = true;
            chkShowAll.Checked = false;

            clsCommon.SetVisibility_Panel(pnlCurrency, false);
            clsCommon.SetVisibility_Panel(pnlCustomer, false);
            clsCommon.SetVisibility_Panel(pnlSalesman, false);
            clsCommon.SetVisibility_Panel(pnlCollector, false);
            clsCommon.SetVisibility_Panel(pnlUseCustomerMasterSalesPerson, false);
            clsCommon.SetVisibility_Panel(pnlAlloType, false);
            clsCommon.SetVisibility_Panel(pnlType, false);
            clsCommon.SetVisibility_Panel(pnlAllocationNumWise, false);
            clsCommon.SetVisibility_Panel(pnlAllRecords, false);
            clsCommon.SetVisibility_Panel(pnlDate, true);
        }
        #endregion

        #region Print Method
        private void print(string path, string sReportTitle, string sFormula)
        {
            try
            {
                string sFilter = "";
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Cheque Management Reports";
                ReportDocument RD = new ReportDocument();
                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                frm_ReportViewer viewer = new frm_ReportViewer();
                RD.Load(s_Path);
                clsSecurity.LogonServer(ref RD);
                RD.Refresh();

                RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                RD.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                #region Validate Single Customer Ledger
                if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Trim().Length > 0 && (Report == enum_ReportName.RG_Sales_Journal))
                {
                    decimal dBroughtForwardBalance = 0;

                    decimal dCredit = DBHandling.ExecQuery_ReturnDecimal("select [dbo].[GetCreditBroughtForwardBalance]('" + txtCustomer.Tag.ToString() + "','" + dtpFrom.Value.Date + "')");
                    decimal dDebit = DBHandling.ExecQuery_ReturnDecimal("select [dbo].[GetDebitBroughtForwardBalance]('" + txtCustomer.Tag.ToString() + "','" + dtpFrom.Value.Date + "')");
                    dBroughtForwardBalance = dCredit - dDebit;

                    RD.DataDefinition.FormulaFields["BroughtForwardAmount"].Text = dBroughtForwardBalance.ToString();// clsCommon.fncsetstring(500);
                    RD.DataDefinition.FormulaFields["BroughtForwardDate"].Text = clsCommon.fncsetstring(dtpFrom.Value.ToShortDateString());
                    RD.DataDefinition.FormulaFields["CarriedForwardDate"].Text = clsCommon.fncsetstring(dtpTo.Value.ToShortDateString());
                    RD.DataDefinition.FormulaFields["cAddress"].Text = clsCommon.RemoveNewLinestring(clsCommon.fncsetstring(clsGenaralName.getName_CustomerRegisterAddress(txtCustomer.Tag.ToString())));

                }
                #endregion

                string sSeperator = "";
                sFilter += (bCustomerSelected) ? "Customer : " + txtCustomer.Text.Trim() + sSeperator : "";

                sSeperator = sFilter.Length > 0 ? " / " : "";
                sFilter += (bSelesRepSelected) ? "Sales Rep : " + txtSalesRep.Text.Trim() + sSeperator : "";

                sSeperator = sFilter.Length > 0 ? " / " : "";
                sFilter += (bCurrencySelected) ? "Currency : " + cmbCurrency.Text.Trim() + sSeperator : "";

                sSeperator = sFilter.Length > 0 ? " / " : "";

                RD.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sFilter);
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
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                clsValidate.WriteErrorLog("", iFormID, ex); SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void print(string path, string sReportTitle, DataSet ojbDataSetTable, string sReportFilter, string sReportID)
        {
            try
            {
                string sHeaderTitle = "Standed Reports";

                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("HeaderTitle", sHeaderTitle, true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle", sReportTitle, true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", clsSecurity.CompanyName, true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", clsSecurity.CompanyAddress1, true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", clsSecurity.CompanyAddress2, true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqName", clsSecurity.DigiteqName, true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqEmail", clsCommon.getCompanyEmail(), true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DateRange", "From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"), true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("UserName", clsSecurity.UserNameLoged, true,false);

                try
                {
                    /*cry_PF.ParameterFieldName = "Group_Para";
                    cry_PV.Value = chkAllocationNumberWise.Checked ? "allocationNo" : "receipt_ID";
                    //cry_PV.Value = "xxxxxx";        // THE VALUE WHICH IS TO BE SHOWN.
                    cry_PF.CurrentValues.Add(cry_PV);
                    cry_PAF.Add(cry_PF);*/
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ToDate", "AS AT " + dtpTo.Value.ToString("dd MMM yyyy"), true,false);

                }
                catch (Exception) { }

                //if (rdoLocal.Checked)
                //    sReportFilter += " Customer Type : Local";
                //if (rdoExport.Checked)
                //    sReportFilter += "Customer Type : Export";
                if (bCustomerSelected)
                    sReportFilter += " Customer Name : " + txtCustomer.Text.Trim();
                if (bSelesRepSelected)
                    sReportFilter += " Salesman Name : " + txtSalesRep.Text.Trim();
                else
                    sReportFilter += (sReportFilter.Length > 0) ? "" : " - ";

                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Filter", sReportFilter, true,false);

                //if (rdopOutstandingStatement.Checked)
                //{
                //    objRpt.DataDefinition.FormulaFields["ContactTel"].Text = clsCommon.fncsetstring(clsConfig.sCmp_qContactTelephone);
                //    objRpt.DataDefinition.FormulaFields["ContactEmail"].Text = clsCommon.fncsetstring(clsConfig.sCmp_qContactEmail);
                //    objRpt.DataDefinition.FormulaFields["OverDueDate"].Text = clsCommon.fncsetstring(clsFormatter.FormatDate_Short(dtpOverdueDate.Value));
                //}

                frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
                ReportViewer.print(path, ojbDataSetTable, glb_dtsReportExport.dt_rptParameter, sReportID);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region KeyDown Events
        private void txt_Customer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CustomerID();
        }

        private void frm_rpt_ChequeManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        #endregion

        #region Events DoublClick
        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
        }

        private void txtSalesRep_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesRepID();
        }

        private void txtCollector_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterSalesRep(ref txtCollector);
        }

        private void dgvReports_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int iReportID = clsValidate.ValidateGridValue(dgvReports, "report_ID", e.RowIndex, 0);
                setEnableDisableConctrol(iReportID);
            }
        }

        private void dgvReports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvReports_CellClick(sender, e);
        }
        #endregion

        #region Search Methods
        private void Search_CustomerID()
        {
            clsSearch.Search_MasterCustomer(ref txtCustomer, chkShowAll.Checked);
        }

        private void Search_SalesRepID()
        {
            try
            {
                clsSearch.Search_MasterSalesRep(ref txtSalesRep);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Set Enable/Disable Controls
        private void setEnableDisableConctrol(int iReportID)
        {
            clearField();

            if (iReportID == (int)enum_ReportName.ST_Collection_Report_Summary || iReportID == (int)enum_ReportName.ST_Collection_Report_Detail)
            {
                clsCommon.SetVisibility_Panel(pnlCurrency, true);
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlCollector, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_ChequeTracer)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlType, true);
            }
            else if (iReportID == (int)enum_ReportName.RG_Sales_Journal)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_Collection_Report_Aging)
            {
                clsCommon.SetVisibility_Panel(pnlCurrency, true);
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
            }
            else if (iReportID == (int)enum_ReportName.RG_Sales_Commission_Detail || iReportID == (int)enum_ReportName.RG_Sales_Commission_Statement)
            {
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
            }
            else if (iReportID == (int)enum_ReportName.RG_Sales_Commision_Invoice_wise || iReportID == (int)enum_ReportName.ST_Incentive)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
            }
            else if (iReportID == (int)enum_ReportName.RG_Invoice_wise_payment_Tracking_With_Deposited_Detail || iReportID == (int)enum_ReportName.RG_Invoice_wise_payment_Tracking || iReportID == (int)enum_ReportName.RG_Customer_wise_payment_Tracking ||
                iReportID == (int)enum_ReportName.RG_OverPaymentListing || iReportID == (int)enum_ReportName.RG_AdvanceListing)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlUseCustomerMasterSalesPerson, true);
            }
            else if (iReportID == (int)enum_ReportName.RG_Receipt_wise_Invoice_Tracking)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlUseCustomerMasterSalesPerson, true);

                chkUseCustomerMastorSaleRep.Checked = true;
            }
            else if (iReportID == (int)enum_ReportName.RG_Receipt_Allocation)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlAlloType, true); ;
                clsCommon.SetVisibility_Panel(pnlAllocationNumWise, true);

                chkAdvance.Checked = true;
                chkOverPayment.Checked = true;
                chkPartPayment.Checked = true;
                chkAllocationNumberWise.Checked = true;
            }
        }
        #endregion                
    }
    class tmpCommissionSummary
    {
        public int monthID;
        public decimal dSalesValue, dCreditNoteValue;
    }
}