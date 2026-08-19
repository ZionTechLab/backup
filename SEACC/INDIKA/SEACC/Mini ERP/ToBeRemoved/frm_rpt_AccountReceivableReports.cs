using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using DataTire;
using Digiteq.DataSets;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using Digiteq.DataSets.BSS;

namespace Digiteq
{
    public partial class frm_rpt_AccountReceivableReports : MettroForm
    {
        #region Variables
        //form manage
        public int iFormID;

        dts_Sales glbDtsSales = new dts_Sales();
        dts_bssOutstandingLedger gbl_dts_bssOutstandingLedger = new dts_bssOutstandingLedger();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        dts_bss_OutstandingAnalysis glb_dts_bss_OutstandingAnalysis = new dts_bss_OutstandingAnalysis();

        public bool bNoAccess;
        bool bSelesRepSelected = false, bCustomerClassSelected = false, bCustomerTypeSelected = false, bCustomerCategorySelected = false, bCustomerSelected = false;
        bool isDetailReport = false;

        string sReportTitle_Main, sReportTitle_Sub, sReportPath;
        enum_ReportName Report;
        #endregion

        #region Form Load
        public frm_rpt_AccountReceivableReports()
        {
            iFormID = clsSecurity.getFormID(FormName.AccountReceivableReports);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }
        private void frm_rpt_AccountReceivableReports_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Account Receivable Reports", 2, iFormID);
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
                dgvReports.DataSource = DBHandling.ExecQuery("EXEC sp_Reports '" + 16 + "'").Tables[0];
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
                        //bool bPermission = false;
                        int iRow = dgvReports.SelectedCells[0].RowIndex;
                        int iReport = int.Parse(dgvReports.Rows[iRow].Cells[0].Value.ToString());
                        Report = (enum_ReportName)iReport;

                        if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(Report)))
                        {
                            sReportTitle_Main = ""; sReportTitle_Sub = ""; sReportPath = "";
                            if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(Report), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                            {
                                #region Filters
                                ProgressBar.Value = 0;

                                bSelesRepSelected = false; bCustomerClassSelected = false; bCustomerTypeSelected = false; bCustomerCategorySelected = false; bCustomerSelected = false;
                                string sFilter = "";

                                if (txtCustomerClassID.Tag != null && txtCustomerClassID.Tag.ToString().Trim().Length > 0)
                                    bCustomerClassSelected = true;

                                if (txtCustomerTypeID.Tag != null && txtCustomerTypeID.Tag.ToString().Trim().Length > 0)
                                    bCustomerTypeSelected = true;

                                if (txtCategoryID.Tag != null && txtCategoryID.Tag.ToString().Trim().Length > 0)
                                    bCustomerCategorySelected = true;

                                if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Trim().Length > 0)
                                    bCustomerSelected = true;

                                if (txtSalesRep.Tag != null && txtSalesRep.Tag.ToString().Trim().Length > 0)
                                    bSelesRepSelected = true;
                                #endregion

                                #region Customer Outstanding Reports

                                if (clsConfig.bBackDateEnable_CustomerOutstandingReports)
                                {
                                    #region Customer Outstandings - Invoice
                                    if (Report == enum_ReportName.RG_Outstanding_Invoice_wise_Summary)
                                    {
                                        isDetailReport = true;
                                        GenarateReport_CustomerOutstandingBackDate(Report, true);
                                    }
                                    else if (Report == enum_ReportName.RG_Outstanding_Invoice_wise_Detail)
                                    {
                                        isDetailReport = true;
                                        GenarateReport_CustomerOutstandingBackDate(Report, true);
                                    }

                                    #endregion

                                    #region Customer Outstandings Summery_Customer
                                    else if (Report == enum_ReportName.RG_Outstanding_Customer_Wise_Summary)
                                    {
                                        isDetailReport = false;
                                        GenarateReport_CustomerOutstandingBackDate(Report, false);
                                    }
                                    #endregion

                                    #region Customer Outstandings Detail-Customer
                                    else if (Report == enum_ReportName.RG_Outstanding_Customer_Wise_Detail)
                                    {
                                        isDetailReport = true;
                                        GenarateReport_CustomerOutstandingBackDate(Report, false);
                                    }
                                    #endregion

                                    #region Customer Outstandings Summery_SalesRep
                                    else if (Report == enum_ReportName.RG_Outstanding_Salesman_wise_Summary)
                                    {
                                        isDetailReport = false;
                                        GenarateReport_CustomerOutstandingBackDate(Report, true);
                                    }
                                    #endregion

                                    #region rdoCustomer Outstandings Detail_SalesRep
                                    else if (Report == enum_ReportName.RG_Outstanding_Salesman_wise_Detail)
                                    {
                                        isDetailReport = true;
                                        GenarateReport_CustomerOutstandingBackDate(Report, true);
                                    }
                                    #endregion

                                    #region rdoCustomer Outstandings Detail_SalesRep TW
                                    else if (Report == enum_ReportName.RG_Outstanding_Salesman_wise_Detail_TW)
                                    {
                                        isDetailReport = true;
                                        bool isRepWise = true;
                                        string sMessage = "";

                                        try
                                        {
                                            if (txtSlab1.Text == "")
                                                txtSlab1.Text = "0";
                                            if (txtSlab2.Text == "")
                                                txtSlab2.Text = "0";
                                            if (txtSlab3.Text == "")
                                                txtSlab3.Text = "0";
                                            if (txtSlab4.Text == "")
                                                txtSlab4.Text = "0";
                                            if (txtSlab5.Text == "")
                                                txtSlab5.Text = "0";

                                            if (int.Parse(txtSlab1.Text) < int.Parse(txtSlab2.Text) && int.Parse(txtSlab2.Text) < int.Parse(txtSlab3.Text) && int.Parse(txtSlab3.Text) < int.Parse(txtSlab4.Text) && int.Parse(txtSlab4.Text) < int.Parse(txtSlab5.Text))
                                            {
                                                gbl_dts_bssOutstandingLedger.Clear();
                                                glb_dtsReportExport.Clear();

                                                int iSalesRepShowType = 0;

                                                Cursor = Cursors.WaitCursor;
                                                #region Fill Sales rep dataset
                                                foreach (tbl_genEmployeeMaster oSalesRep in tbl_genEmployeeMaster.SelectAll().Where(p => p.IsSelesRep))
                                                {
                                                    gbl_dts_bssOutstandingLedger.genSalesRep.AddgenSalesRepRow(oSalesRep.Employee_ID, oSalesRep.EmployeeName);
                                                }
                                                #endregion

                                                #region Fill Customer Finance dataset
                                                if (Report == enum_ReportName.RG_Outstanding_Invoice_wise_Detail || Report == enum_ReportName.RG_Outstanding_Invoice_wise_Summary || Report == enum_ReportName.RG_OutstandingStatement || Report == enum_ReportName.RG_Age_Analysis_Customer_wise || Report == enum_ReportName.RG_Age_Analysis_Salesman_wise || Report == enum_ReportName.RG_OutstandingStatement_Salesman_wise || Report == enum_ReportName.RG_Outstanding_Salesman_wise_Detail_TW)
                                                {
                                                    if (bCustomerSelected)
                                                    {
                                                        tbl_genCustomerFinance oDetail =
                                                            tbl_genCustomerFinance.Select(txtCustomer.Tag.ToString().Trim());
                                                        if (oDetail != null)
                                                        {
                                                            tbl_genCustomerMaster oCustomerMaster = tbl_genCustomerMaster.Select(oDetail.Customer_ID);
                                                            if (oCustomerMaster != null)
                                                            {
                                                                gbl_dts_bssOutstandingLedger.genCustomerFinance
                                                                    .AddgenCustomerFinanceRow(oDetail.Customer_ID, oCustomerMaster.CustomerName,
                                                                        oCustomerMaster.AddressRegister, "", 0,
                                                                        oDetail.CreditPeriod, oDetail.CreditLimit, oCustomerMaster.SalesRep_ID, clsGenaralName.getName_SalesRep(oCustomerMaster.SalesRep_ID),"",-1,"","");
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        foreach (tbl_genCustomerFinance oDetail in tbl_genCustomerFinance.SelectAll().Where(p => p.Customer_ID != "default"))
                                                        {
                                                            tbl_genCustomerMaster oCustomerMaster = tbl_genCustomerMaster.Select(oDetail.Customer_ID);
                                                            if (oCustomerMaster != null)
                                                            {
                                                                gbl_dts_bssOutstandingLedger.genCustomerFinance
                                                                    .AddgenCustomerFinanceRow(oDetail.Customer_ID, oCustomerMaster.CustomerName,
                                                                        oCustomerMaster.AddressRegister, "", 0,
                                                                        oDetail.CreditPeriod, oDetail.CreditLimit, oCustomerMaster.SalesRep_ID, clsGenaralName.getName_SalesRep(oCustomerMaster.SalesRep_ID), "", -1, "", "");
                                                            }
                                                        }
                                                    }
                                                }
                                                #endregion

                                                string sSalesRep_ID = "default";

                                                List<tbl_genCustomerMaster> ocustomers;
                                                #region Customer
                                                if (bCustomerSelected)
                                                    ocustomers = tbl_genCustomerMaster.SelectAll().Where(p => p.Customer_ID == txtCustomer.Tag.ToString().Trim()).ToList();
                                                else
                                                    ocustomers = tbl_genCustomerMaster.SelectAll().Where(p => p.Customer_ID != "default" && p.CompanyBranch_ID == clsSecurity.BranchID).ToList();

                                                if (bCustomerClassSelected)
                                                    ocustomers = ocustomers.Where(p => p.CustomerClass_ID == txtCustomerClassID.Tag.ToString()).ToList();

                                                if (bCustomerTypeSelected)
                                                    ocustomers = ocustomers.Where(p => p.CustomerType_ID == txtCustomerTypeID.Tag.ToString()).ToList();

                                                if (bCustomerCategorySelected)
                                                    ocustomers = ocustomers.Where(p => p.CustomerCategory_ID == txtCategoryID.Tag.ToString()).ToList();
                                                #endregion

                                                foreach (tbl_genCustomerMaster ocustomer in ocustomers)
                                                {
                                                    if (!bCustomerSelected)
                                                        clsHelpMethods_Local.startProgressBar(0, ocustomers.Count + 2, 1, ProgressBar);


                                                    #region Sales rep filter - customer master
                                                    if (isRepWise)
                                                    {
                                                        if (chkUseCustomerMastorSaleRep.Checked)
                                                        {
                                                            sSalesRep_ID = ocustomer.SalesRep_ID;
                                                            if (bSelesRepSelected)
                                                                if (ocustomer.SalesRep_ID != txtSalesRep.Tag.ToString().Trim())
                                                                    continue;
                                                            iSalesRepShowType = 2;
                                                        }
                                                        else
                                                            iSalesRepShowType = 1;//filter by the SQL 
                                                    }
                                                    #endregion

                                                    var oDetails = srh_bssCustomerOutstanding.SelectAllByCustomerId(ocustomer.Customer_ID, clsSecurity.BranchID, Convert.ToDateTime("01/01/2001"), dtpTo.Value.Date, true);
                                                    foreach (srh_bssCustomerOutstanding oDetail in oDetails)
                                                    {
                                                        #region CASH/SP DISCOUNT
                                                        //Currency Rate Colum in DataTable was used for passing this Discount Amount
                                                        decimal dCashSP_Discount = 0;
                                                        tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(oDetail.Transaction_ID);
                                                        if (oInvoice != null)
                                                        {
                                                            dCashSP_Discount = oInvoice.DiscountTotal2;
                                                        }
                                                        #endregion

                                                        #region Sales rep filter - Others
                                                        if (iSalesRepShowType == 1)
                                                        {
                                                            if (bSelesRepSelected)
                                                                if (oDetail.Employee_ID != txtSalesRep.Tag.ToString().Trim())
                                                                    continue;
                                                            sSalesRep_ID = oDetail.Employee_ID;
                                                        }
                                                        #endregion

                                                        if (Report == enum_ReportName.RG_Outstanding_Invoice_wise_Detail)
                                                        {
                                                            if (oDetail.IsChecueInHand)
                                                            {
                                                                foreach (srh_bssCustomerOutstanding_RecieptDetail oRecipts in srh_bssCustomerOutstanding_RecieptDetail.SelectAll(oDetail.PurchaseOrder_ID, dtpTo.Value.Date))
                                                                {
                                                                  //  gbl_dts_bssOutstandingLedger.bssCustomerOutstanding.AddbssCustomerOutstandingRow(oDetail.Customer_ID, ocustomer.CustomerName, oDetail.TransactionType, oRecipts.Invoice_ID, oRecipts.InvoiceDate, oRecipts.GrandTotal, oRecipts.SattledAmount, "", oDetail.IsCredit, oDetail.IsChecueInHand, false, "", oRecipts.Age, oRecipts.DeliveryOrder_ID, oRecipts.PurchaseOrder_ID, oRecipts.Receipt_ID, oRecipts.CurrencyCode, oRecipts.CurrencyRate, oDetail.IsAdvance, oDetail.OrderRefNo, dCashSP_Discount);
                                                                }
                                                                continue;
                                                            }
                                                            if (oDetail.TransactionType == 3)
                                                            {
                                                                decimal dRCSettledAmount = oDetail.TransactionAmount - oDetail.Outstanding;

                                                                foreach (srh_bssCustomerOutstanding_RecieptDetail oRecipts in srh_bssCustomerOutstanding_RecieptDetail.SelectAll(oDetail.PurchaseOrder_ID, dtpTo.Value.Date).OrderBy(p => p.Age))
                                                                {
                                                                    if (dRCSettledAmount >= oRecipts.SattledAmount)
                                                                        dRCSettledAmount -= oRecipts.SattledAmount;
                                                                    else
                                                                    {
                                                                //        gbl_dts_bssOutstandingLedger.bssCustomerOutstanding.AddbssCustomerOutstandingRow(oDetail.Customer_ID, ocustomer.CustomerName, oDetail.TransactionType, oRecipts.Invoice_ID, oRecipts.InvoiceDate, oRecipts.GrandTotal, (oRecipts.SattledAmount - dRCSettledAmount), oDetail.Remarks, oDetail.IsCredit, false, false, "", oRecipts.Age, oRecipts.DeliveryOrder_ID, oRecipts.PurchaseOrder_ID, "", oRecipts.CurrencyCode, oRecipts.CurrencyRate, oDetail.IsAdvance, oDetail.OrderRefNo, dCashSP_Discount);
                                                                        dRCSettledAmount = 0;
                                                                    }
                                                                }
                                                                continue;
                                                            }
                                                        }
                                                        else if (Report == enum_ReportName.RG_Outstanding_Invoice_wise_Summary || Report == enum_ReportName.RG_OutstandingStatement)
                                                        {
                                                            if (oDetail.IsChecueInHand)
                                                                continue;
                                                        }

                                                        else if (Report == enum_ReportName.RG_OutstandingStatement_Salesman_wise || Report == enum_ReportName.RG_Outstanding_Salesman_wise_Detail_TW)
                                                        {
                                                            if (!(oDetail.TransactionType == 3 || oDetail.TransactionType == 1 || oDetail.TransactionType == 100 || oDetail.TransactionType == 2))
                                                                continue;
                                                        }

                                                    //    gbl_dts_bssOutstandingLedger.bssCustomerOutstanding.AddbssCustomerOutstandingRow(oDetail.Customer_ID, ocustomer.CustomerName, oDetail.TransactionType, oDetail.Transaction_ID,
                                                      //      oDetail.TransactionDate, oDetail.TransactionAmount, oDetail.Outstanding, oDetail.Remarks, oDetail.IsCredit, oDetail.IsChecueInHand, false, sSalesRep_ID, oDetail.Age, oDetail.DeliveryOrder_ID, oDetail.PurchaseOrder_ID, "", oDetail.CurrencyCode, dCashSP_Discount, oDetail.IsAdvance, oDetail.OrderRefNo, dCashSP_Discount);

                                                        if (bCustomerSelected)
                                                            clsHelpMethods_Local.startProgressBar(0, oDetails.Count + 2, 1, ProgressBar);
                                                    }
                                                }

                                                string sDateRange = "As At : " + dtpTo.Value.Date.ToString("dd/MM/yyyy");

                                                string sReportFilter = "";
                                                if (bCustomerClassSelected)
                                                    sReportFilter += " Class: " + txtCustomerClassID.Text.Trim();
                                                if (bCustomerTypeSelected)
                                                    sReportFilter += " Type: " + txtCustomerTypeID.Text.Trim();
                                                if (bCustomerCategorySelected)
                                                    sReportFilter += " Category: " + txtCategoryID.Text.Trim();
                                                if (bCustomerSelected)
                                                    sReportFilter += " Customer Name: " + txtCustomer.Text.Trim();
                                                if (bSelesRepSelected)
                                                    sReportFilter += " Salesman Name: " + txtSalesRep.Text.Trim();
                                                else
                                                    sReportFilter += (sReportFilter.Length > 0) ? "" : " - ";

                                                gbl_dts_bssOutstandingLedger.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDateRange, clsSecurity.UserNameLoged, sReportFilter);

                                                string sCompanyName = "", sCompanyTell = "", sCompanyAddress = "", sCompanyEmail = "";
                                                tbl_genCompanyInfo oInfo = tbl_genCompanyInfo.Select("Company1");
                                                if (oInfo != null && oInfo.CompanyID != "default")
                                                {
                                                    sCompanyName = clsCript.Decrypt(oInfo.CompanyName);
                                                    sCompanyTell = oInfo.Telephone1;
                                                    sCompanyTell += "," + oInfo.Telephone2 != "" ? oInfo.Telephone2 : "";
                                                    sCompanyAddress = oInfo.Address;
                                                }

                                                if (Report == enum_ReportName.RG_OutstandingStatement)
                                                {
                                                    tbl_securityCompanyValues oCompany = tbl_securityCompanyValues.Select((int)enum_CompanyValue.companyName);//7
                                                    if (oCompany != null)
                                                        sCompanyName = oCompany.CompanyValuesDetail;

                                                    oCompany = null;
                                                    oCompany = tbl_securityCompanyValues.Select((int)enum_CompanyValue.companyEmail);//6
                                                    if (oCompany != null)
                                                        sCompanyEmail = oCompany.CompanyValuesDetail;

                                                }
                                                // Slab
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Slab_1", txtSlab1.Text, true);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Slab_2", txtSlab2.Text, true);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Slab_3", txtSlab3.Text, true);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Slab_4", txtSlab4.Text, true);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Slab_5", txtSlab5.Text, true);

                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("isDetail", isDetailReport ? "1" : "0", true);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", sCompanyName, true);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ContactTel", sCompanyTell, true);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Address", sCompanyAddress, true);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ContactEmail", sCompanyEmail, true);

                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("BackDate", "As At Date : " + dtpTo.Value.Date.ToString("dd/MM/yyyy"), true);

                                                frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                                rpt.print(sReportPath, gbl_dts_bssOutstandingLedger, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                            }
                                            else
                                            {
                                                if (int.Parse(txtSlab1.Text) > int.Parse(txtSlab2.Text))
                                                    sMessage = "Slab 2 value should be greater than Slab 1 value";
                                                if (int.Parse(txtSlab2.Text) > int.Parse(txtSlab3.Text))
                                                    sMessage = "Slab 3 value should be greater than Slab 2 value";
                                                if (int.Parse(txtSlab3.Text) > int.Parse(txtSlab4.Text))
                                                    sMessage = "Slab 4 value should be greater than Slab 3 value";
                                                if (int.Parse(txtSlab4.Text) > int.Parse(txtSlab5.Text))
                                                    sMessage = "Slab 5 value should be greater than Slab 4 value";
                                                MessageBox.Show(sMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                            gbl_dts_bssOutstandingLedger.Clear();
                                            glb_dtsReportExport.Clear();
                                        }
                                    }
                                    #endregion

                                    #region rdoCustomer Outstandings Detail Ageing
                                    else if (Report == enum_ReportName.RG_Age_Analysis_Customer_wise)
                                    {
                                        GenarateReport_CustomerOutstandingBackDate(Report, false);
                                    }
                                    #endregion

                                    #region rdoCustomer Outstandings Detail Ageing - SalesRep
                                    else if (Report == enum_ReportName.RG_Age_Analysis_Salesman_wise)
                                    {
                                        GenarateReport_CustomerOutstandingBackDate(Report, true);
                                    }
                                    #endregion

                                    #region Group Outstanding
                                    else if (Report == enum_ReportName.RG_OutstandingStatement)
                                    {
                                        GenarateReport_CustomerOutstandingBackDate(Report, true);
                                    }

                                    else if (Report == enum_ReportName.RG_OutstandingStatement_Salesman_wise)
                                    {
                                        isDetailReport = true;
                                        GenarateReport_CustomerOutstandingBackDate(Report, true);
                                    }
                                    #endregion

                                    #region Outstanding Analysis Report
                                    if (Report == enum_ReportName.ST_Outstanding_Analysis)
                                    {
                                        try
                                        {
                                            Cursor = Cursors.WaitCursor;
                                            glb_dts_bss_OutstandingAnalysis.dt_OutstandingAnalysis.Clear();
                                            glb_dts_bss_OutstandingAnalysis.dt_Company.Clear();

                                            #region Customer
                                            List<tbl_genCustomerMaster> oCustomers;
                                            if (bCustomerSelected)
                                                oCustomers = tbl_genCustomerMaster.SelectAll().Where(p => p.Customer_ID == txtCustomer.Tag.ToString().Trim()).ToList();
                                            else
                                                oCustomers = tbl_genCustomerMaster.SelectAll().Where(p => p.Customer_ID != "default").ToList();
                                            #endregion

                                            foreach (tbl_genCustomerMaster oCustomer in oCustomers)
                                            {
                                                string sSalesRep_ID = oCustomer.SalesRep_ID;

                                                #region Sales rep filter - customer master
                                                if (bSelesRepSelected)
                                                    if (oCustomer.SalesRep_ID != txtSalesRep.Tag.ToString().Trim())
                                                        continue;
                                                #endregion

                                                string sSalesman_Name = clsGenaralName.getName_SalesRep(oCustomer.SalesRep_ID);
                                                decimal dOpeningBalance = 0, dInvoiceTotal = 0, dCheque = 0, dCash = 0, dCredit = 0, dDebit = 0, dClosingBalance = 0;

                                                var oDetails = srh_bssCustomerOutstanding.SelectAllByCustomerId(oCustomer.Customer_ID, "", Convert.ToDateTime("01/01/2001"), dtpFrom.Value.Date.AddDays(-1), true);
                                                foreach (srh_bssCustomerOutstanding oDetail in oDetails)
                                                    dOpeningBalance += oDetail.Outstanding;

                                                foreach (tbl_sasInvoice oInvoices in tbl_sasInvoice.SelectAllByCustomer_ID(oCustomer.Customer_ID).Where(p => !p.IsDeleted && p.Invoice_ID != "default" && p.InvoiceDate >= dtpFrom.Value.Date))
                                                {
                                                    if (oInvoices.IsDebitNote)
                                                        dDebit += oInvoices.GrandTotal;
                                                    else
                                                        dInvoiceTotal += oInvoices.GrandTotal;
                                                }

                                                foreach (tbl_bpsReceipt oReceipt in tbl_bpsReceipt.SelectAllByCustomer_ID(oCustomer.Customer_ID).Where(p => !p.IsDeleted && p.Receipt_ID != "default" && p.ReceiptDate >= dtpFrom.Value.Date))
                                                {
                                                    dCash += oReceipt.CashAmount;
                                                    foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID).Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default"))
                                                        dCheque += oCheque.Amount;
                                                }

                                                foreach (tbl_bpsCreditNote oCreditNote in tbl_bpsCreditNote.SelectAllByCustomer_ID(oCustomer.Customer_ID).Where(p => !p.IsDeleted && p.CreditNote_ID != "default" && p.CreditNoteDate >= dtpFrom.Value.Date))
                                                    dCredit += oCreditNote.TotalAmount;

                                                dClosingBalance = (dOpeningBalance + dInvoiceTotal + dDebit) - (dCash + dCheque + dCredit);
                                                if (dClosingBalance != 0)
                                                    glb_dts_bss_OutstandingAnalysis.dt_OutstandingAnalysis.Adddt_OutstandingAnalysisRow(oCustomer.Customer_ID, oCustomer.CustomerName, oCustomer.SalesRep_ID, sSalesman_Name, dOpeningBalance, dInvoiceTotal, dCash, dCheque, dCredit, dDebit, dClosingBalance);
                                            }

                                            if (bCustomerSelected)
                                                sFilter += " Customer Name: " + txtCustomer.Text.Trim();
                                            if (bSelesRepSelected)
                                                sFilter += " Salesman Name: " + txtSalesRep.Text.Trim();
                                            else
                                                sFilter += (sFilter.Length > 0) ? "" : " - ";

                                            string sDateRange = "From : " + clsFormatter.FormatDate_Short(dtpFrom.Value) + "  To : " + clsFormatter.FormatDate_Short(dtpTo.Value);
                                            glb_dts_bss_OutstandingAnalysis.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "Outstanding Analysis Report", "", sDateRange, clsSecurity.UserNameLoged, sFilter);

                                            frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                            rpt.print(sReportPath, glb_dts_bss_OutstandingAnalysis, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.ST_Outstanding_Analysis));
                                        }
                                        catch (Exception ex)
                                        {
                                            clsValidate.WriteErrorLog("", iFormID, ex);
                                            SEACCException.Show(ex);
                                        }
                                        finally
                                        {
                                            glb_dts_bss_OutstandingAnalysis.dt_OutstandingAnalysis.Clear();
                                            glb_dts_bss_OutstandingAnalysis.dt_Company.Clear();
                                            Cursor = Cursors.Default;
                                        }
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region Customer Outstandings - Invoice
                                    if (Report == enum_ReportName.RG_Outstanding_Invoice_wise_Summary)
                                    {
                                        isDetailReport = true;

                                        sFilter = CustomerOutstandings_ByCustomer(false, true);
                                        genCustomerOustanding_Fill();
                                        print("\\reports\\SAS\\Finance\\rpt_sas_Outstanding_Customer.rpt", "Customer Outstanding (Invoice Wise)", gbl_dts_bssOutstandingLedger, sFilter);
                                    }
                                    else if (Report == enum_ReportName.RG_Outstanding_Invoice_wise_Detail)
                                    {
                                        isDetailReport = false;
                                        sFilter = CustomerOutstandings_ByCustomer(bSelesRepSelected, true);
                                        print("\\reports\\SAS\\Finance\\rpt_sas_Outstanding_Customer_CHE.rpt", "Customer Outstanding (Invoice Wise)", gbl_dts_bssOutstandingLedger, sFilter);
                                    }
                                    #endregion

                                    #region Customer Outstandings Summery_Customer
                                    else if (Report == enum_ReportName.RG_Outstanding_Customer_Wise_Summary)
                                    {
                                        isDetailReport = false;
                                        sFilter = CustomerOutstandings_ByCustomer(bSelesRepSelected, false);
                                        print("\\reports\\SAS\\Finance\\rpt_sas_OutstandingSummary_Customer.rpt", " Outstanding Summary (Customer Wise)", gbl_dts_bssOutstandingLedger, sFilter);

                                    }
                                    #endregion

                                    #region Customer Outstandings Detail-Customer
                                    else if (Report == enum_ReportName.RG_Outstanding_Customer_Wise_Detail)
                                    {
                                        isDetailReport = true;
                                        sFilter = CustomerOutstandings_ByCustomer(false, false);
                                        print("\\reports\\SAS\\Finance\\rpt_sas_OutstandingDetail_Customer.rpt", " Outstanding Details (Customer-Wise)", gbl_dts_bssOutstandingLedger, sFilter);
                                    }
                                    #endregion

                                    #region Customer Outstandings Summery_SalesRep
                                    else if (Report == enum_ReportName.RG_Outstanding_Salesman_wise_Summary)
                                    {
                                        isDetailReport = false;
                                        sFilter = CustomerOutstandings_ByCustomer(true, false);
                                        print("\\reports\\SAS\\Finance\\rpt_sas_OutstandingSummary_SalesRep.rpt", " Outstanding Summary (Salesman-wise)", gbl_dts_bssOutstandingLedger, sFilter);
                                    }
                                    #endregion

                                    #region rdoCustomer Outstandings Detail_SalesRep
                                    else if (Report == enum_ReportName.RG_Outstanding_Salesman_wise_Detail)
                                    {
                                        isDetailReport = true;
                                        sFilter = CustomerOutstandings_ByCustomer(true, false);
                                        print("\\reports\\SAS\\Finance\\rpt_sas_OutstandingDetail_SalesRep.rpt", " Outstanding Detail (Salesman-wise)", gbl_dts_bssOutstandingLedger, sFilter);
                                    }
                                    #endregion

                                    #region rdoCustomer Outstandings Detail Ageing
                                    else if (Report == enum_ReportName.RG_Age_Analysis_Customer_wise)
                                    {
                                        sFilter = CustomerOutstandings_ByCustomer(false, false);
                                        print("\\reports\\SAS\\Finance\\rpt_sas_OutstandingDetail_Customer_Ageing.rpt", " Age-Analysis (Customer-wise)", gbl_dts_bssOutstandingLedger, sFilter);
                                    }
                                    #endregion

                                    #region rdoCustomer Outstandings Detail Ageing - SalesRep
                                    else if (Report == enum_ReportName.RG_Age_Analysis_Salesman_wise)
                                    {
                                        sFilter = CustomerOutstandings_ByCustomer(true, false);
                                        if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                            print("\\reports\\SAS\\Finance\\rpt_sas_OutstandingDetail_SalesRep_Ageing_AKT.rpt", " Age-Analysis (Salesman-wise)", gbl_dts_bssOutstandingLedger, sFilter);
                                        else
                                            print("\\reports\\SAS\\Finance\\rpt_sas_OutstandingDetail_Customer_Ageing.rpt", " Age-Analysis (Salesman-wise)", gbl_dts_bssOutstandingLedger, sFilter);
                                    }
                                    #endregion

                                    #region Group Outstanding
                                    else if (Report == enum_ReportName.RG_OutstandingStatement)
                                    {
                                        sFilter = CustomerOutstandings_ByCustomer(true, false);
                                        genCustomerOustanding_Fill();

                                        #region Old Report
                                        /*
                                            string sGetRptPath = ""; //clsHelpMethods.GetReportPath(clsAutocode.getReportID(enum_ReportName.RG_OutstandingStatement_AllCustomer));
                                            if (sGetRptPath != null && sGetRptPath.Length > 0)
                                                print(sGetRptPath, " Customer Outstanding Statement", gbl_dts_bssOutstandingLedger, sFilter);
                                            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                                print("\\reports\\SAS\\Finance\\rpt_sas_CustomerOutstandingStatement_AKT.rpt", " Customer Outstanding Statement", gbl_dts_bssOutstandingLedger, sFilter);


                                            else
                                                print("\\reports\\SAS\\Finance\\rpt_sas_CustomerOutstandingStatement.rpt", " Customer Outstanding Statement", gbl_dts_bssOutstandingLedger, sFilter); 
                                            */
                                        #endregion
                                        print("\\reports\\SAS\\Finance\\rpt_sas_CustomerOutstandingStatement_pps.rpt", " Customer Outstanding Statement", gbl_dts_bssOutstandingLedger, sFilter);
                                    }
                                    #endregion
                                }
                                #endregion

                                #region To Be Delete
                                #region Pending
                                //if (false)
                                //{
                                //    try
                                //    {
                                //        Cursor = Cursors.WaitCursor;
                                //        glbDtsSales.dt_sasSalesOutstanding.Rows.Clear();
                                //        string sTransactionType = "";
                                //        foreach (tbl_sasInvoice oInvoice in tbl_sasInvoice.SelectAll().Where(p => p.GrandTotal > 0 && !p.IsDeleted && (p.GrandTotal - p.SeattleAmount > 0)))
                                //        {
                                //            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                //            if (oCustomer != null)
                                //            {
                                //                //invoices
                                //                if (!oInvoice.IsOpeningBalance && !oInvoice.IsReturnedCheque && !oInvoice.IsDebitNote)
                                //                    sTransactionType = "Pending Invoice";

                                //                //Op Balnce
                                //                if (oInvoice.IsOpeningBalance && !oInvoice.IsReturnedCheque && !oInvoice.IsDebitNote)
                                //                    sTransactionType = "Opening Balance Pending";

                                //                //Returned Cheque
                                //                if (!oInvoice.IsOpeningBalance && oInvoice.IsReturnedCheque && !oInvoice.IsDebitNote)
                                //                    sTransactionType = "RTN CHQ Pending";

                                //                //Debit Note
                                //                if (!oInvoice.IsOpeningBalance && !oInvoice.IsReturnedCheque && oInvoice.IsDebitNote)
                                //                    sTransactionType = "Debit Note";

                                //                glbDtsSales.dt_sasSalesOutstanding.Adddt_sasSalesOutstandingRow(oInvoice.Customer_ID, oCustomer.CustomerName, oInvoice.Invoice_ID, oInvoice.InvoiceDate, sTransactionType, 0, (oInvoice.GrandTotal - oInvoice.SeattleAmount));
                                //            }
                                //        }
                                //        //Cheque
                                //        sTransactionType = "CHQ Recvd. - Unsettled";
                                //        foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAll().Where(p => !p.IsDeleted && (p.ChequeAmount - p.SetteledAmount > 0) && !p.IsSetteled && !p.IsReturned))
                                //        {
                                //            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oCheque.Customer_ID);
                                //            if (oCustomer != null)
                                //                glbDtsSales.dt_sasSalesOutstanding.Adddt_sasSalesOutstandingRow(oCheque.Customer_ID, oCustomer.CustomerName, oCheque.ChequeRegister_ID, oCheque.DateRegister, sTransactionType, 0, ((oCheque.ChequeAmount - oCheque.SetteledAmount) * -1));

                                //        }
                                //        //Receipt
                                //        sTransactionType = "CASH Recvd. - Unsettled";
                                //        foreach (tbl_bpsReceipt oReceipt in tbl_bpsReceipt.SelectAll().Where(p => !p.IsDeleted && !p.IsSeattled))
                                //        {
                                //            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oReceipt.Customer_ID);
                                //            if (oCustomer != null)
                                //                glbDtsSales.dt_sasSalesOutstanding.Adddt_sasSalesOutstandingRow(oReceipt.Customer_ID, oCustomer.CustomerName, oReceipt.Receipt_ID, oReceipt.ReceiptDate, sTransactionType, 0, ((oReceipt.CashAmount - oReceipt.SeattleAmount) * -1));

                                //        }
                                //        //ChequeRegister
                                //        sTransactionType = "CHQ Recvd. - Unsettled";
                                //        foreach (tbl_bpsChequeRegister oChequeRegister in tbl_bpsChequeRegister.SelectAll().Where(p => !p.IsDeleted && !p.IsDepositted && p.ChequeAmount > 0))
                                //        {
                                //            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oChequeRegister.Customer_ID);
                                //            if (oCustomer != null)
                                //                glbDtsSales.dt_sasSalesOutstanding.Adddt_sasSalesOutstandingRow(oChequeRegister.Customer_ID, oCustomer.CustomerName, oChequeRegister.ChequeRegister_ID, oChequeRegister.DateRegister, sTransactionType, ((oChequeRegister.ChequeAmount - oChequeRegister.SetteledAmount) * -1), 0);

                                //        }
                                //        //CreditNote
                                //        sTransactionType = "Credit Note - Unsettled";
                                //        foreach (tbl_bpsCreditNote OCreditNote in tbl_bpsCreditNote.SelectAll().Where(p => !p.IsDeleted && !p.IsSeattled && p.TotalAmount > 0))
                                //        {
                                //            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(OCreditNote.Customer_ID);
                                //            if (oCustomer != null)
                                //                glbDtsSales.dt_sasSalesOutstanding.Adddt_sasSalesOutstandingRow(OCreditNote.Customer_ID, oCustomer.CustomerName, OCreditNote.CreditNote_ID, OCreditNote.CreditNoteDate, sTransactionType, 0, ((OCreditNote.TotalAmount - OCreditNote.SeattleAmount) * -1));
                                //        }
                                //    }
                                //    catch (Exception ex)
                                //    {
                                //        SEACCException.Show(ex);
                                //    }
                                //    finally
                                //    {
                                //        Cursor = Cursors.Default;
                                //        glbDtsSales.dt_sasSalesOutstanding.Rows.Clear();
                                //    }
                                //}
                                #endregion

                                //#region Customer Outstandings Ledger
                                //if (rdoCustomerOutstandingsLedger.Checked)
                                //{
                                //    sFormula = " {vw_rpt_sasInvoice.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasInvoice.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                                //    sFormula += " and {vw_rpt_sasInvoice.isSeattled} = false";

                                //    if (bRoutSelected)
                                //        sFormula += " and {vw_rpt_sasInvoice.route_ID} = '" + txtRoute.Tag.ToString().Trim() + "' ";
                                //    if (bSelesRepSelected)
                                //        sFormula += " and {vw_rpt_sasInvoice.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";
                                //    if (bCustomerSelected)
                                //        sFormula += " and {vw_rpt_sasInvoice.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";

                                //    print("\\reports\\SAS\\Commen\\rpt_sas_Invoice_Settlement_Ledger.rpt", " Customer Sales Journal", sFormula);
                                //}
                                //#endregion 

                                //#region Customer History Ledger
                                //else if (rdoCustomerHistoryLedger.Checked)
                                //{
                                //    if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Sales_Journal)))
                                //    {
                                //        sFormula = " {vw_rpt_sasLedger.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasLedger.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                                //        if (bCustomerSelected)
                                //            sFormula += " and {vw_rpt_sasLedger.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";

                                //        print("\\reports\\SAS\\Commen\\rpt_sas_Ledger.rpt", " Customer Sales Journal", sFormula);
                                //    }
                                //}
                                //#endregion

                                //#region Invoice Settlement Ledger
                                //else if (rdoInvoiceSettlementLedger.Checked)
                                //{
                                //    if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Invoice_wise_payment_Tracking)))
                                //    {
                                //        try
                                //        {
                                //            Cursor = Cursors.WaitCursor;
                                //            gbl_dts_bssOutstandingLedger.dt_bssInvoiceWisePaymentTracking.Rows.Clear();
                                //            decimal dBalanceAmount = 0;

                                //            foreach (tbl_sasInvoice oInvoice in tbl_sasInvoice.SelectAll().Where(p => p.Invoice_ID != "default" && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date))
                                //            {
                                //                bool bIsSettledInvoice = false;

                                //                if (bCustomerSelected)
                                //                {
                                //                    if (txtCustomer.Tag.ToString().Trim() != oInvoice.Customer_ID)
                                //                        continue;
                                //                }
                                //                dBalanceAmount = oInvoice.GrandTotal;
                                //                string sPoNo = oInvoice.Job_ID != "default" ? oInvoice.Job_ID : clsGenaralName.getName_OrderRefNo(oInvoice.OrderRefNo_ID);
                                //                int iCount = 0;
                                //                foreach (tbl_sasInvoice_Sattled oInvoiceSettle in tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(oInvoice.Invoice_ID.Trim()))
                                //                {
                                //                    bIsSettledInvoice = true;
                                //                    string sChequNo = "", sPaymentNo = "";
                                //                    DateTime dtmChequeDate = new DateTime();
                                //                    DateTime dtmRecepitDate = new DateTime();
                                //                  //  DateTime temp = new DateTime();
                                //                    TimeSpan tsNofDate = new TimeSpan();
                                //                    bool bIsCheque = false;
                                //                    if (oInvoiceSettle.ChequeRegister_ID != "default" && oInvoiceSettle.Receipt_ID != "default") //Cheque
                                //                    {
                                //                        tbl_bpsChequeRegister oChequeRegister = tbl_bpsChequeRegister.Select(oInvoiceSettle.ChequeRegister_ID.Trim());
                                //                        if (oChequeRegister != null && oChequeRegister.ChequeRegister_ID != "default")
                                //                        {
                                //                            sPaymentNo = oInvoiceSettle.Receipt_ID;
                                //                            sChequNo = oChequeRegister.ChequeNumber;
                                //                            dtmChequeDate = oChequeRegister.DateCheque.Date;
                                //                            dtmRecepitDate = oChequeRegister.DateRegister.Date;
                                //                            tsNofDate = dtmChequeDate - oInvoice.InvoiceDate.Date;
                                //                            bIsCheque = true;
                                //                        }

                                //                    }
                                //                    else if (oInvoiceSettle.ChequeRegister_ID == "default" && oInvoiceSettle.Receipt_ID != "default") //Cash
                                //                    {
                                //                        tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(oInvoiceSettle.Receipt_ID.Trim());
                                //                        if (oReceipt != null && oReceipt.Receipt_ID != "default")
                                //                        {
                                //                            sPaymentNo = oInvoiceSettle.Receipt_ID;
                                //                            dtmRecepitDate = oReceipt.ReceiptDate.Date;
                                //                            tsNofDate = dtmRecepitDate - oInvoice.InvoiceDate.Date;

                                //                        }
                                //                    }
                                //                    else if (oInvoiceSettle.CreditNote_ID != "default") //Credit Note
                                //                    {
                                //                        tbl_bpsCreditNote oCreditNote = tbl_bpsCreditNote.Select(oInvoiceSettle.CreditNote_ID.Trim());
                                //                        if (oCreditNote != null && oCreditNote.CreditNote_ID != "default")
                                //                        {
                                //                            sPaymentNo = oInvoiceSettle.CreditNote_ID;
                                //                            dtmRecepitDate = oCreditNote.CreditNoteDate.Date;
                                //                            tsNofDate = dtmRecepitDate - oInvoice.InvoiceDate.Date;

                                //                        }
                                //                    }

                                //                    dBalanceAmount -= oInvoiceSettle.SattledAmount;
                                //                    gbl_dts_bssOutstandingLedger.dt_bssInvoiceWisePaymentTracking.Adddt_bssInvoiceWisePaymentTrackingRow(oInvoiceSettle.Invoice_ID, oInvoice.InvoiceDate, sPoNo, sPaymentNo, dtmRecepitDate, dtmChequeDate, sChequNo, oInvoiceSettle.SattledAmount, dBalanceAmount, tsNofDate.TotalDays, bIsCheque, iCount == 0 ? oInvoice.GrandTotal : 0);
                                //                    iCount++;
                                //                }

                                //                if (!bIsSettledInvoice)
                                //                {
                                //                    dBalanceAmount = oInvoice.GrandTotal - oInvoice.SeattleAmount;
                                //                    DateTime dtmNiglectDate = new DateTime(00 - 00 - 0000).Date;
                                //                    gbl_dts_bssOutstandingLedger.dt_bssInvoiceWisePaymentTracking.Adddt_bssInvoiceWisePaymentTrackingRow(oInvoice.Invoice_ID, oInvoice.InvoiceDate, sPoNo, "", dtmNiglectDate, dtmNiglectDate, "", 0, dBalanceAmount, 0, false, oInvoice.GrandTotal);

                                //                }
                                //            }
                                //        }
                                //        catch (Exception ex)
                                //        {
                                //            SEACCException.Show(ex);
                                //        }
                                //        // sFormula += " and {vw_rpt_sasInvoice.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";
                                //        // sFormula += " and  {vw_rpt_sasInvoice.isDeleted} = false";

                                //        print("\\reports\\SAS\\Finance\\rpt_sas_Settlement_Ledger_Invoice.rpt", " Invoice-Wise Payment Tracking", gbl_dts_bssOutstandingLedger, "");
                                //    }
                                //}
                                //#endregion

                                //#region Receipt Settlement Ledger
                                //else if (rdoReceiptSettlementLedger.Checked)
                                //{
                                //    if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Receipt_wise_Invoice_Tracking)))
                                //    {
                                //        sFormula = " {vw_rpt_bpsReceiptHeder.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsReceiptHeder.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                //        if (bSelesRepSelected)
                                //            sFormula += " and {vw_rpt_bpsReceiptHeder.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";
                                //        if (bCustomerSelected)
                                //            sFormula += " and {vw_rpt_bpsReceiptHeder.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";

                                //        sFormula += " and  {vw_rpt_bpsReceiptHeder.isDeleted} = false";
                                //        print("\\reports\\SAS\\Finance\\rpt_sas_Settlement_Ledger_Receipt.rpt", " Receipt-Wise      Invoice Tracking", sFormula);
                                //    }
                                //}
                                //#endregion

                                //#region Allocation
                                //else if (rdoAllocation.Checked)
                                //{
                                //    if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Receipt_wise_Invoice_Tracking)))
                                //    {
                                //        if (chkAdvance.Checked || chkPartPayment.Checked || chkOverPayment.Checked)
                                //        {
                                //            try
                                //            {
                                //                sFilter = "Allocation Type : ";
                                //                if (chkAdvance.Checked)
                                //                    sFilter += " Advance ,";
                                //                if (chkPartPayment.Checked)
                                //                    sFilter += " Part Payment ,";
                                //                if (chkOverPayment.Checked)
                                //                    sFilter += " Over Payment ,";

                                //                Cursor = Cursors.WaitCursor;
                                //                glb_dtsReceiptAllocation.dt_sasAdvanceAllocation_Summary.Rows.Clear();
                                //                foreach (tbl_sasInvoice_Sattled detail in tbl_sasInvoice_Sattled.SelectAll().Where(p => p.Invoice_ID != "default" && p.AllocationDate.Date >= dtpFrom.Value.Date && p.AllocationDate.Date <= dtpTo.Value.Date).OrderBy(p => p.AllocationID))
                                //                {
                                //                    bool bPass = false;
                                //                    if (chkAdvance.Checked)
                                //                    {
                                //                        if (detail.IsAdvancePayment)
                                //                            bPass = true;
                                //                    }
                                //                    if (chkPartPayment.Checked)
                                //                    {
                                //                        if (!detail.IsAdvancePayment && !detail.IsOverPayment)
                                //                            bPass = true;
                                //                    }
                                //                    if (chkOverPayment.Checked)
                                //                    {
                                //                        if (detail.IsOverPayment)
                                //                            bPass = true;
                                //                    }
                                //                    if (!bPass)
                                //                        continue;

                                //                    tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(detail.Invoice_ID);
                                //                    tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(detail.Receipt_ID);

                                //                    #region Customer wise Fillter
                                //                    if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Length > 0)
                                //                        if (txtCustomer.Tag.ToString() != oReceipt.Customer_ID)
                                //                            continue;
                                //                    #endregion

                                //                    if (oInvoice != null && oInvoice.Invoice_ID != "default" && oReceipt != null && oReceipt.Receipt_ID != "default")
                                //                    {
                                //                        glb_dtsReceiptAllocation.dt_sasAdvanceAllocation_Summary.Adddt_sasAdvanceAllocation_SummaryRow(detail.AllocationID, detail.AllocationDate, detail.SattledAmount, detail.Receipt_ID, oReceipt.ReceiptDate, oReceipt.TotalAmount, detail.Invoice_ID, oInvoice.InvoiceDate, clsGenaralName.getName_Customer(oReceipt.Customer_ID), detail.SattledDate);
                                //                    }


                                //                }
                                //                //sFilter += (chkAdvance.Checked && !chkPartPayment.Checked)?" Advance " :((!chkAdvance.Checked && chkPartPayment.Checked)?" Part Payment ": ((chkAdvance.Checked && chkPartPayment.Checked)?" Advance , Part Payment ": "") );
                                //                string sReportTitle = (chkPartPayment.Checked && chkAdvance.Checked) ? "Receipt Allocation Report" : (chkAdvance.Checked) ? "Advance Receipt Allocation Report" : "Receipt Allocation Report";
                                //                print("\\Reports\\SAS\\Finance\\rpt_sasAdvance.rpt", sReportTitle, glb_dtsReceiptAllocation, sFilter);
                                //            }
                                //            catch (Exception ex)
                                //            {
                                //                SEACCException.Show(ex);
                                //            }
                                //            finally
                                //            {
                                //                Cursor = Cursors.Default;
                                //                glb_dtsReceiptAllocation.dt_sasAdvanceAllocation_Summary.Rows.Clear();
                                //            }
                                //        }
                                //        else
                                //            MessageBox.Show("Please Select Allocation Type.", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                //    }
                                //}
                                //#endregion

                                //#region Commission Summary
                                //else if (rdoSalesCommisionSummary.Checked)
                                //{
                                //    if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Sales_Commission_Summary)))
                                //    {
                                //        sFormula = " {vw_rpt_sasCommissionNormal.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasCommissionNormal.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                                //        if (bSelesRepSelected)
                                //            sFormula += " and {vw_rpt_sasCommissionNormal.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";
                                //        if (bCustomerSelected)
                                //            sFormula += " and {vw_rpt_sasCommissionNormal.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";

                                //        print("\\reports\\SAS\\Finance\\rpt_sas_CommissionSummary_SalesRep.rpt", "Basic Sales Commission (Summary)", sFormula);
                                //    }
                                //}
                                //#endregion

                                //#region Commission Detail
                                //else if (rdoSalesCommisionDetail.Checked)
                                //{
                                //    if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Sales_Commission_Detail)))
                                //    {
                                //        sFormula = " {vw_rpt_sasCommissionNormal.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasCommissionNormal.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                                //        if (bSelesRepSelected)
                                //            sFormula += " and {vw_rpt_sasCommissionNormal.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";
                                //        if (bCustomerSelected)
                                //            sFormula += " and {vw_rpt_sasCommissionNormal.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";

                                //        print("\\reports\\SAS\\Finance\\rpt_sas_CommissionDetail_SalesRep.rpt", "Basic Sales Commission (Detailed)", sFormula);
                                //    }
                                //}
                                //#endregion

                                //#region Commission Detail(Invoice Wise)
                                //else if (rdoSalesCommisionInvoicewise.Checked)
                                //{
                                //    try
                                //    {
                                //        if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Sales_Commision_Invoice_wise)))
                                //        {
                                //            Cursor = Cursors.WaitCursor;
                                //            glbDtsSales.dt_sasCommisionDetail.Rows.Clear();
                                //            List<tbl_genCustomerMaster> oCustomers = tbl_genCustomerMaster.SelectAll().Where(p => p.Customer_ID != "default" && !p.IsDeleted).ToList();
                                //            foreach (tbl_genCustomerMaster oCustomer in oCustomers)
                                //            {
                                //                #region Filters
                                //                if (bCustomerSelected)
                                //                {
                                //                    if (txtCustomer.Tag.ToString() != oCustomer.Customer_ID.Trim())
                                //                        continue;
                                //                }
                                //                if (bSelesRepSelected)
                                //                {
                                //                    if (txtSalesRep.Tag.ToString() != oCustomer.SalesRep_ID.Trim())
                                //                        continue;
                                //                }
                                //                #endregion

                                //                decimal dCommissionPasantage_Original = 0;
                                //                tbl_genEmployeeMaster oEmployee = tbl_genEmployeeMaster.Select(oCustomer.SalesRep_ID.Trim());
                                //                if (oEmployee != null && oEmployee.Employee_ID != "default")
                                //                    dCommissionPasantage_Original = oEmployee.CommisionPersentage_Normal;

                                //                tbl_genCustomerFinance oCusFin = tbl_genCustomerFinance.Select(oCustomer.Customer_ID);
                                //                if (oCusFin != null && oCusFin.Customer_ID != "default")
                                //                {
                                //                    #region Invoices
                                //                  //  decimal dValidAmount = 0, dOverDueAmount = 0, dDeductionAmount = 0;
                                //                    foreach (tbl_sasInvoice detail in tbl_sasInvoice.SelectAll_ByCustomerIDandDateRange(dtpFrom.Value.Date, dtpTo.Value.Date, oCustomer.Customer_ID).Where(p => p.Invoice_ID != "default" && !p.IsDeleted && !p.IsReturnedCheque && !p.IsDebitNote))
                                //                    {
                                //                        int iDayes = 0, iInvoiceCount = 0;
                                //                        decimal dBalanceAmount = detail.GrandTotal, dInvoiceNetAmount = 0, dTempValue1 = 0, dTempValue2 = 0, dTempValue3 = 0;

                                //                        if (detail.Quotation_ID != "default" || (detail.Job_ID == "default" && detail.DeliveryOrder_ID != "default"))
                                //                            continue;

                                //                        bool bIsVatNbt_Reduce_Enable = (oCustomer.IsSVATenable) ? true : false;
                                //                        if (bIsVatNbt_Reduce_Enable)
                                //                            dInvoiceNetAmount = detail.GrandTotal;
                                //                        else
                                //                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(detail.GrandTotal, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dInvoiceNetAmount, ref dTempValue2, ref  dTempValue3);

                                //                        #region Payment Validation
                                //                        foreach (tbl_sasInvoice_Sattled oSettment in tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(detail.Invoice_ID))
                                //                        {
                                //                            #region Cheque
                                //                            if (oSettment.ChequeRegister_ID != "default" && oSettment.Receipt_ID != "default") //Cheque
                                //                            {
                                //                                tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(oSettment.ChequeRegister_ID);
                                //                                if (oCheque != null && oCheque.ChequeRegister_ID != "default")
                                //                                {

                                //                                    if (oCheque.IsReconcilied || oCheque.IsReIssued)
                                //                                    {
                                //                                        if (oCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C) && oCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_O) && oCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_R))
                                //                                        {
                                //                                            #region Realized Cheque
                                //                                            iDayes = clsCommon.getDays(detail.InvoiceDate, oCheque.DateReconcilied);
                                //                                            decimal dDaysForCommission = iDayes - oCusFin.CommissionCreditPeriod;
                                //                                            decimal dAllocatedAmount = 0, dBalanceWithoutVAT = 0, dValidAmountForCommission = 0;
                                //                                            decimal dRange1Value = 0, dRange2Value = 0, dRange3Value = 0, dRange4Value = 0, dRange5Value = 0;

                                //                                            dBalanceAmount -= oSettment.SattledAmount;
                                //                                            dValidAmountForCommission = dDaysForCommission <= 0 ? oSettment.SattledAmount : 0;
                                //                                            if (bIsVatNbt_Reduce_Enable)
                                //                                            {
                                //                                                dAllocatedAmount = oSettment.SattledAmount;
                                //                                                dBalanceWithoutVAT = dBalanceAmount;
                                //                                            }
                                //                                            else
                                //                                            {
                                //                                                clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oSettment.SattledAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dAllocatedAmount, ref dTempValue2, ref  dTempValue3);
                                //                                                clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dBalanceAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dBalanceWithoutVAT, ref dTempValue2, ref  dTempValue3);
                                //                                                clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dValidAmountForCommission, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dValidAmountForCommission, ref dTempValue2, ref  dTempValue3);
                                //                                            }
                                //                                            clsGetValues.get_CommissionValue_FromCommissionSlabs(dDaysForCommission, oCusFin.CommissionCreditPeriod, dAllocatedAmount, ref dRange1Value, ref dRange2Value, ref dRange3Value, ref dRange4Value, ref dRange5Value);
                                //                                            decimal dGrandTotal = iInvoiceCount > 0 ? 0 : detail.GrandTotal;
                                //                                            dInvoiceNetAmount = iInvoiceCount > 0 ? 0 : dInvoiceNetAmount;
                                //                                            glbDtsSales.dt_sasCommisionDetail.Adddt_sasCommisionDetailRow(oCustomer.CustomerName, oCustomer.Customer_ID, detail.Invoice_ID, detail.InvoiceDate, dGrandTotal, dInvoiceNetAmount, oCheque.Receipt_ID + "<" + oCheque.ChequeNumber + ">", oCheque.DateReconcilied, dAllocatedAmount, iDayes, dValidAmountForCommission, dRange1Value, dRange2Value, dRange3Value, dRange4Value, dRange5Value, dBalanceWithoutVAT, oCusFin.CommissionCreditPeriod, oCusFin.CreditPeriod);
                                //                                            iInvoiceCount++;
                                //                                            #endregion
                                //                                        }
                                //                                        else
                                //                                        {
                                //                                            #region Returned Cheque
                                //                                            decimal dReturnedAmount = oSettment.SattledAmount, dReturnAmountPaid = 0;
                                //                                            DateTime dtmPaymentDate = detail.InvoiceDate;
                                //                                            string sPaymentDetail = "";
                                //                                            foreach (tbl_sasInvoice oReturnedCheque in tbl_sasInvoice.SelectAllByChequeRegister_ID(oCheque.ChequeRegister_ID))
                                //                                            {
                                //                                                foreach (tbl_sasInvoice_Sattled oRCSettment in tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(oReturnedCheque.Invoice_ID))
                                //                                                {
                                //                                                    #region Cheque
                                //                                                    if (oRCSettment.ChequeRegister_ID != "default" && oRCSettment.Receipt_ID != "default") //Cheque
                                //                                                    {
                                //                                                        tbl_bpsChequeRegister oRCCheque = tbl_bpsChequeRegister.Select(oRCSettment.ChequeRegister_ID);
                                //                                                        if (oRCCheque != null && oRCCheque.ChequeRegister_ID != "default")
                                //                                                        {

                                //                                                            if (oRCCheque.IsReconcilied || oRCCheque.IsReIssued)
                                //                                                            {
                                //                                                                if (oRCCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C) && oRCCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_O) && oRCCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_R))
                                //                                                                {
                                //                                                                    dReturnAmountPaid += oRCSettment.SattledAmount;
                                //                                                                    if (dtmPaymentDate < oRCCheque.DateReconcilied)
                                //                                                                    {
                                //                                                                        dtmPaymentDate = oRCCheque.DateReconcilied;
                                //                                                                        sPaymentDetail = "RP " + oRCCheque.Receipt_ID + "<" + oRCCheque.ChequeNumber + ">";
                                //                                                                    }
                                //                                                                }
                                //                                                            }

                                //                                                        }
                                //                                                    }
                                //                                                    #endregion

                                //                                                    #region Cash
                                //                                                    else if (oRCSettment.ChequeRegister_ID == "default" && oRCSettment.Receipt_ID != "default")
                                //                                                    {
                                //                                                        tbl_bpsReceipt oRCReceipt = tbl_bpsReceipt.Select(oRCSettment.Receipt_ID);
                                //                                                        if (oRCReceipt != null && oRCReceipt.Receipt_ID != "default")
                                //                                                        {
                                //                                                            if (oRCReceipt.CashAmount > 0)
                                //                                                            {
                                //                                                                dReturnAmountPaid += oRCSettment.SattledAmount;
                                //                                                                if (dtmPaymentDate < oRCReceipt.ReceiptDate)
                                //                                                                {
                                //                                                                    dtmPaymentDate = oRCReceipt.ReceiptDate;
                                //                                                                    sPaymentDetail = "RP " + oRCReceipt.Receipt_ID;
                                //                                                                }
                                //                                                            }
                                //                                                        }
                                //                                                    }
                                //                                                    #endregion

                                //                                                    #region Credit Note
                                //                                                    else if (oRCSettment.CreditNote_ID != "default")
                                //                                                    {
                                //                                                        tbl_bpsCreditNote oRCCreditNote = tbl_bpsCreditNote.Select(oRCSettment.CreditNote_ID);
                                //                                                        if (oRCCreditNote != null && oRCCreditNote.CreditNote_ID != "default")
                                //                                                        {
                                //                                                            dReturnAmountPaid += oRCSettment.SattledAmount;
                                //                                                            if (dtmPaymentDate < oRCCreditNote.CreditNoteDate)
                                //                                                            {
                                //                                                                dtmPaymentDate = oRCCreditNote.CreditNoteDate;
                                //                                                                sPaymentDetail = "RP " + oRCCreditNote.CreditNote_ID;
                                //                                                            }
                                //                                                        }
                                //                                                    }
                                //                                                    #endregion
                                //                                                }

                                //                                                if (dReturnAmountPaid >= dReturnedAmount)
                                //                                                {
                                //                                                    iDayes = clsCommon.getDays(detail.InvoiceDate, dtmPaymentDate);
                                //                                                    decimal dDaysForCommission = iDayes - oCusFin.CommissionCreditPeriod;
                                //                                                    decimal dAllocatedAmount = 0, dBalanceWithoutVAT = 0, dValidAmountForCommission = 0;
                                //                                                    decimal dRange1Value = 0, dRange2Value = 0, dRange3Value = 0, dRange4Value = 0, dRange5Value = 0;

                                //                                                    dBalanceAmount -= oSettment.SattledAmount;
                                //                                                    dValidAmountForCommission = dDaysForCommission <= 0 ? oSettment.SattledAmount : 0;
                                //                                                    if (bIsVatNbt_Reduce_Enable)
                                //                                                    {
                                //                                                        dAllocatedAmount = oSettment.SattledAmount;
                                //                                                        dBalanceWithoutVAT = dBalanceAmount;
                                //                                                    }
                                //                                                    else
                                //                                                    {
                                //                                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oSettment.SattledAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dAllocatedAmount, ref dTempValue2, ref  dTempValue3);
                                //                                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dBalanceAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dBalanceWithoutVAT, ref dTempValue2, ref  dTempValue3);
                                //                                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dValidAmountForCommission, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dValidAmountForCommission, ref dTempValue2, ref  dTempValue3);
                                //                                                    }
                                //                                                    clsGetValues.get_CommissionValue_FromCommissionSlabs(dDaysForCommission, oCusFin.CommissionCreditPeriod, dAllocatedAmount, ref dRange1Value, ref dRange2Value, ref dRange3Value, ref dRange4Value, ref dRange5Value);
                                //                                                    decimal dGrandTotal = iInvoiceCount > 0 ? 0 : detail.GrandTotal;
                                //                                                    dInvoiceNetAmount = iInvoiceCount > 0 ? 0 : dInvoiceNetAmount;

                                //                                                    glbDtsSales.dt_sasCommisionDetail.Adddt_sasCommisionDetailRow(oCustomer.CustomerName, oCustomer.Customer_ID, detail.Invoice_ID, detail.InvoiceDate, dGrandTotal, dInvoiceNetAmount, sPaymentDetail, dtmPaymentDate, dReturnedAmount, iDayes, dValidAmountForCommission, dRange1Value, dRange2Value, dRange3Value, dRange4Value, dRange5Value, dBalanceWithoutVAT, oCusFin.CommissionCreditPeriod, oCusFin.CreditPeriod);
                                //                                                    iInvoiceCount++;
                                //                                                }
                                //                                            }
                                //                                            #endregion
                                //                                        }
                                //                                    }

                                //                                }
                                //                            }
                                //                            #endregion

                                //                            #region Cash
                                //                            else if (oSettment.ChequeRegister_ID == "default" && oSettment.Receipt_ID != "default")
                                //                            {
                                //                                tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(oSettment.Receipt_ID);
                                //                                if (oReceipt != null && oReceipt.Receipt_ID != "default")
                                //                                {
                                //                                    if (oReceipt.CashAmount > 0)
                                //                                    {
                                //                                        iDayes = clsCommon.getDays(detail.InvoiceDate, oReceipt.ReceiptDate);
                                //                                        decimal dDaysForCommission = iDayes - oCusFin.CommissionCreditPeriod;
                                //                                        decimal dAllocatedAmount = 0, dBalanceWithoutVAT = 0, dValidAmountForCommission = 0;
                                //                                        decimal dRange1Value = 0, dRange2Value = 0, dRange3Value = 0, dRange4Value = 0, dRange5Value = 0;

                                //                                        dBalanceAmount -= oSettment.SattledAmount;
                                //                                        dValidAmountForCommission = dDaysForCommission <= 0 ? oSettment.SattledAmount : 0;
                                //                                        if (bIsVatNbt_Reduce_Enable)
                                //                                        {
                                //                                            dAllocatedAmount = oSettment.SattledAmount;
                                //                                            dBalanceWithoutVAT = dBalanceAmount;
                                //                                        }
                                //                                        else
                                //                                        {
                                //                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oSettment.SattledAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dAllocatedAmount, ref dTempValue2, ref  dTempValue3);
                                //                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dBalanceAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dBalanceWithoutVAT, ref dTempValue2, ref  dTempValue3);
                                //                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dValidAmountForCommission, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dValidAmountForCommission, ref dTempValue2, ref  dTempValue3);
                                //                                        }
                                //                                        clsGetValues.get_CommissionValue_FromCommissionSlabs(dDaysForCommission, oCusFin.CommissionCreditPeriod, dAllocatedAmount, ref dRange1Value, ref dRange2Value, ref dRange3Value, ref dRange4Value, ref dRange5Value);
                                //                                        decimal dGrandTotal = iInvoiceCount > 0 ? 0 : detail.GrandTotal;
                                //                                        dInvoiceNetAmount = iInvoiceCount > 0 ? 0 : dInvoiceNetAmount;
                                //                                        glbDtsSales.dt_sasCommisionDetail.Adddt_sasCommisionDetailRow(oCustomer.CustomerName, oCustomer.Customer_ID, detail.Invoice_ID, detail.InvoiceDate, dGrandTotal, dInvoiceNetAmount, oReceipt.Receipt_ID, oReceipt.ReceiptDate, dAllocatedAmount, iDayes, dValidAmountForCommission, dRange1Value, dRange2Value, dRange3Value, dRange4Value, dRange5Value, dBalanceWithoutVAT, oCusFin.CommissionCreditPeriod, oCusFin.CreditPeriod);
                                //                                        iInvoiceCount++;
                                //                                    }
                                //                                }
                                //                            }
                                //                            #endregion

                                //                            #region Credit Note
                                //                            else if (oSettment.CreditNote_ID != "default")
                                //                            {
                                //                                tbl_bpsCreditNote oCreditNote = tbl_bpsCreditNote.Select(oSettment.CreditNote_ID);
                                //                                if (oCreditNote != null && oCreditNote.CreditNote_ID != "default")
                                //                                {

                                //                                    iDayes = clsCommon.getDays(detail.InvoiceDate, oCreditNote.CreditNoteDate);
                                //                                    decimal dDaysForCommission = iDayes - oCusFin.CommissionCreditPeriod;
                                //                                    decimal dAllocatedAmount = 0, dBalanceWithoutVAT = 0, dValidAmountForCommission = 0;
                                //                                    decimal dRange1Value = 0, dRange2Value = 0, dRange3Value = 0, dRange4Value = 0, dRange5Value = 0;

                                //                                    dBalanceAmount -= oSettment.SattledAmount;
                                //                                    dValidAmountForCommission = dDaysForCommission <= 0 ? oSettment.SattledAmount : 0;
                                //                                    if (bIsVatNbt_Reduce_Enable)
                                //                                    {
                                //                                        dAllocatedAmount = oSettment.SattledAmount;
                                //                                        dBalanceWithoutVAT = dBalanceAmount;
                                //                                    }
                                //                                    else
                                //                                    {
                                //                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oSettment.SattledAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dAllocatedAmount, ref dTempValue2, ref  dTempValue3);
                                //                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dBalanceAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dBalanceWithoutVAT, ref dTempValue2, ref  dTempValue3);
                                //                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dValidAmountForCommission, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dValidAmountForCommission, ref dTempValue2, ref  dTempValue3);
                                //                                    }
                                //                                    clsGetValues.get_CommissionValue_FromCommissionSlabs(dDaysForCommission, oCusFin.CommissionCreditPeriod, dAllocatedAmount, ref dRange1Value, ref dRange2Value, ref dRange3Value, ref dRange4Value, ref dRange5Value);
                                //                                    decimal dGrandTotal = iInvoiceCount > 0 ? 0 : detail.GrandTotal;
                                //                                    dInvoiceNetAmount = iInvoiceCount > 0 ? 0 : dInvoiceNetAmount;
                                //                                    glbDtsSales.dt_sasCommisionDetail.Adddt_sasCommisionDetailRow(oCustomer.CustomerName, oCustomer.Customer_ID, detail.Invoice_ID, detail.InvoiceDate, dGrandTotal, dInvoiceNetAmount, oCreditNote.CreditNote_ID, oCreditNote.CreditNoteDate, dAllocatedAmount, iDayes, dValidAmountForCommission, dRange1Value, dRange2Value, dRange3Value, dRange4Value, dRange5Value, dBalanceWithoutVAT, oCusFin.CommissionCreditPeriod, oCusFin.CreditPeriod);
                                //                                    iInvoiceCount++;
                                //                                }
                                //                            }
                                //                            #endregion
                                //                        }
                                //                        #endregion

                                //                        #region Invoice Outstanding
                                //                        if (dBalanceAmount > 0)
                                //                        {
                                //                            decimal dInvoiceOutstandingAmount = 0;
                                //                            if (bIsVatNbt_Reduce_Enable)
                                //                                dInvoiceOutstandingAmount = dBalanceAmount;
                                //                            else
                                //                                clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dBalanceAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dInvoiceOutstandingAmount, ref dTempValue2, ref  dTempValue3);

                                //                            decimal dGrandTotal = iInvoiceCount > 0 ? 0 : detail.GrandTotal;
                                //                            dInvoiceNetAmount = iInvoiceCount > 0 ? 0 : dInvoiceNetAmount;
                                //                            glbDtsSales.dt_sasCommisionDetail.Adddt_sasCommisionDetailRow(oCustomer.CustomerName, oCustomer.Customer_ID, detail.Invoice_ID, detail.InvoiceDate, dGrandTotal, dInvoiceNetAmount, "", detail.InvoiceDate, dInvoiceOutstandingAmount, 0, 0, 0, 0, 0, 0, 0, dInvoiceOutstandingAmount, oCusFin.CommissionCreditPeriod, oCusFin.CreditPeriod);
                                //                            iInvoiceCount++;
                                //                        }
                                //                        #endregion
                                //                    }
                                //                    #endregion

                                //                }
                                //            }
                                //            if (bSelesRepSelected)
                                //                sFilter = txtSalesRep.Text.Trim();
                                //            if (bCustomerSelected)
                                //                sFilter = txtCustomer.Text.Trim();
                                //            print("\\reports\\SAS\\Finance\\rpt_sas_CommissionDetail_SalesRep_InvoiceWise.rpt", "Sales Commission Detail(invoice Wise)", glbDtsSales, sFilter);
                                //        }

                                //    }
                                //    catch (Exception ex)
                                //    {
                                //        SEACCException.Show(ex);
                                //    }
                                //    finally
                                //    {
                                //        Cursor = Cursors.Default;
                                //    }
                                //}
                                //#endregion

                                //#region Advance & OverPayment Listing
                                //else if (rdoOverPaymentListing.Checked || rdoAdvanceListing.Checked)
                                //{
                                //    if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_OverPaymentListing)))
                                //    {
                                //        glbDtsSales.dt_OverPaymentListing.Clear();
                                //        Cursor = Cursors.WaitCursor;
                                //        try
                                //        {
                                //            string sReportTitle = "";

                                //            List<tbl_bpsReceipt> oReceipts = new List<tbl_bpsReceipt>();
                                //            if (rdoOverPaymentListing.Checked)
                                //            {
                                //                sReportTitle = "Over Payment Listing Report";
                                //                oReceipts = tbl_bpsReceipt.SelectAll().Where(p => p.Receipt_ID != "default" && p.ReceiptDate.Date >= dtpFrom.Value.Date && p.ReceiptDate.Date <= dtpTo.Value.Date).ToList();

                                //            }
                                //            else if (rdoAdvanceListing.Checked)
                                //            {
                                //                sReportTitle = "Advance Payment Listing Report";
                                //                oReceipts = tbl_bpsReceipt.SelectAll().Where(p => !p.IsDeleted && p.Receipt_ID != "default" && p.IsAdvance && p.ReceiptDate.Date >= dtpFrom.Value.Date && p.ReceiptDate.Date <= dtpTo.Value.Date).ToList();
                                //            }

                                //            foreach (tbl_bpsReceipt oReceipt in oReceipts)
                                //            {
                                //                if (oReceipt.Receipt_ID != "default")
                                //                {
                                //                    if (bCustomerSelected)
                                //                    {
                                //                        if (txtCustomer.Tag.ToString().Trim() != oReceipt.Customer_ID)
                                //                            continue;
                                //                    }

                                //                    decimal dOverpaymentTotal = 0, dAdvancepaymentTotal = 0, dSettleAmount = 0;
                                //                    decimal dAllocatedAmount = 0;
                                //                    foreach (tbl_sasInvoice_Sattled oSettle in tbl_sasInvoice_Sattled.SelectAllByReceipt_ID(oReceipt.Receipt_ID))
                                //                    {
                                //                        dOverpaymentTotal += oSettle.IsOverPayment ? oSettle.SattledAmount : 0;
                                //                        dAdvancepaymentTotal += oSettle.IsAdvancePayment ? oSettle.SattledAmount : 0;
                                //                        dSettleAmount += oSettle.SattledAmount;
                                //                    }

                                //                    if (rdoOverPaymentListing.Checked)
                                //                    {
                                //                        dAllocatedAmount = dOverpaymentTotal;
                                //                        if (dOverpaymentTotal == 0)
                                //                            continue;
                                //                    }
                                //                    else if (rdoAdvanceListing.Checked)
                                //                    {
                                //                        dAllocatedAmount = dAdvancepaymentTotal;
                                //                        //if (dAdvancepaymentTotal == 0)
                                //                        //    continue;
                                //                    }
                                //                    decimal dBalanceAmount = oReceipt.TotalAmount - dSettleAmount;
                                //                    string sChequeNo = "", sTransactionCode = oReceipt.InvoiceList;
                                //                    foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID).Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default"))
                                //                    {
                                //                        string sSeperator = sChequeNo.Length > 0 ? " / " : "";
                                //                        sChequeNo += sSeperator + oCheque.ChequeNumber;
                                //                    }
                                //                    glbDtsSales.dt_OverPaymentListing.Adddt_OverPaymentListingRow(oReceipt.Receipt_ID, oReceipt.ReceiptDate, oReceipt.Customer_ID, clsGenaralName.getName_Customer(oReceipt.Customer_ID), oReceipt.TotalAmount, dAllocatedAmount, dBalanceAmount, oReceipt.Remark, sChequeNo, sTransactionCode);
                                //                }
                                //            }
                                //            print("\\reports\\SAS\\Finance\\rpt_sas_OverPaymentListing.rpt", sReportTitle, glbDtsSales, sFilter);
                                //        }
                                //        catch (Exception ex)
                                //        {
                                //            SEACCException.Show(ex);
                                //        }
                                //        finally
                                //        {
                                //            Cursor = Cursors.Default;
                                //            glbDtsSales.dt_OverPaymentListing.Clear();
                                //        }
                                //    }
                                //}
                                //#endregion

                                //#region Commission Summary Monthwise
                                //else if (rdoSalesCommissionSummary_DateWise.Checked || rdoSalescommissionStatement.Checked)
                                //{
                                //    enum_ReportName enumReport;
                                //    if (rdoSalesCommissionSummary_DateWise.Checked)
                                //        enumReport = enum_ReportName.RG_Sales_Commission_Summary_DateWise;
                                //    else
                                //        enumReport = enum_ReportName.RG_Sales_Commission_Statement;

                                //    if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enumReport)))
                                //    {
                                //        if (txtSalesRep.Tag != null && txtSalesRep.Tag.ToString().Trim().Length > 0)
                                //        {
                                //            if (dtpFrom.Value.Month == dtpTo.Value.Month)
                                //            {
                                //                #region SalescommissionStatement
                                //                try
                                //                {
                                //                    Cursor = Cursors.WaitCursor;
                                //                    glbDtsSales.dt_sasSalesCommissionSummary_DateWise.Rows.Clear();

                                //                    List<tbl_genCustomerMaster> oCustomers = tbl_genCustomerMaster.SelectAll().Where(p => p.Customer_ID != "default" && !p.IsDeleted).ToList();
                                //                    foreach (tbl_genCustomerMaster oCustomer in oCustomers)
                                //                    {
                                //                        #region Filters
                                //                        if (bCustomerSelected)
                                //                        {
                                //                            if (txtCustomer.Tag.ToString() != oCustomer.Customer_ID.Trim())
                                //                                continue;

                                //                        }
                                //                        if (bSelesRepSelected)
                                //                        {
                                //                            if (txtSalesRep.Tag.ToString() != oCustomer.SalesRep_ID.Trim())
                                //                                continue;
                                //                        }
                                //                        #endregion

                                //                        decimal dCommissionPasantage_Original = 0, dCommissionPasantage_Bonus = 0, dSalesTarget_Bonus = 0, dSalesTarget_Minimum = 0, dglbRange1_Pasantage = 0, dglbRange2_Pasantage = 0, dglbRange3_Pasantage = 0, dglbRange4_Pasantage = 0, dglbRange5_Pasantage = 0; //decimal bMinTargetReached = 0;
                                //                        tbl_genEmployeeMaster oEmployee = tbl_genEmployeeMaster.Select(oCustomer.SalesRep_ID.Trim());
                                //                        if (oEmployee != null && oEmployee.Employee_ID != "default")
                                //                        {
                                //                            dCommissionPasantage_Original = oEmployee.CommisionPersentage_Normal;
                                //                            dCommissionPasantage_Bonus = oEmployee.CommisionPersentage_Bones;
                                //                            dSalesTarget_Bonus = oEmployee.SalesTarget;
                                //                            dSalesTarget_Minimum = oEmployee.MinimumSalesTarget;
                                //                            dglbRange1_Pasantage = oEmployee.CommisionPersentage_Normal * clsConfig.dRange1_Pasantage / 100;
                                //                            dglbRange2_Pasantage = oEmployee.CommisionPersentage_Normal * clsConfig.dRange2_Pasantage / 100;
                                //                            dglbRange3_Pasantage = oEmployee.CommisionPersentage_Normal * clsConfig.dRange3_Pasantage / 100;
                                //                            dglbRange4_Pasantage = oEmployee.CommisionPersentage_Normal * clsConfig.dRange4_Pasantage / 100;
                                //                            dglbRange5_Pasantage = oEmployee.CommisionPersentage_Normal * clsConfig.dRange5_Pasantage / 100;
                                //                        }

                                //                        List<tmpCommissionSummary> otmpCommissionSummarys = new List<tmpCommissionSummary>();
                                //                        tbl_genCustomerFinance oCusFin = tbl_genCustomerFinance.Select(oCustomer.Customer_ID);
                                //                        if (oCusFin != null && oCusFin.Customer_ID != "default")
                                //                        {
                                //                            bool bIsVatNbt_Reduce_Enable = (oCustomer.IsSVATenable) ? true : false;

                                //                            #region Invoices
                                //                          //  decimal dValidAmount = 0, dOverDueAmount = 0, dDeductionAmount = 0;
                                //                            foreach (tbl_sasInvoice detail in tbl_sasInvoice.SelectAll_ByCustomerIDandDateRange(dtpFrom.Value.Date, dtpTo.Value.Date, oCustomer.Customer_ID).Where(p => p.Invoice_ID != "default" && !p.IsDeleted && !p.IsReturnedCheque && !p.IsDebitNote))
                                //                            {
                                //                                int iDayes = 0;
                                //                                decimal dBalanceAmount = detail.GrandTotal, dInvoiceNetAmount = 0, dTempValue1 = 0, dTempValue2 = 0, dTempValue3 = 0, dSalesAmount = detail.GrandTotal;
                                //                                if (detail.Quotation_ID != "default" || (detail.Job_ID == "default" && detail.DeliveryOrder_ID != "default"))
                                //                                    continue;

                                //                                if (bIsVatNbt_Reduce_Enable)
                                //                                    dInvoiceNetAmount = detail.GrandTotal;
                                //                                else
                                //                                    clsHelpMethods.SetVATandNBTValues_FromGrandTotal(detail.GrandTotal, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dInvoiceNetAmount, ref dTempValue2, ref  dTempValue3);

                                //                                #region Payment Validation
                                //                                foreach (tbl_sasInvoice_Sattled oSettment in tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(detail.Invoice_ID))
                                //                                {
                                //                                    #region Cheque
                                //                                    if (oSettment.ChequeRegister_ID != "default" && oSettment.Receipt_ID != "default") //Cheque
                                //                                    {
                                //                                        tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(oSettment.ChequeRegister_ID);
                                //                                        if (oCheque != null && oCheque.ChequeRegister_ID != "default")
                                //                                        {

                                //                                            if (oCheque.IsReconcilied || oCheque.IsReIssued)
                                //                                            {
                                //                                                if (oCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C) && oCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_O) && oCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_R))
                                //                                                {
                                //                                                    #region Realized Cheque
                                //                                                    iDayes = clsCommon.getDays(detail.InvoiceDate, oCheque.DateReconcilied);
                                //                                                    decimal dDaysForCommission = iDayes - oCusFin.CommissionCreditPeriod;
                                //                                                    decimal dAllocatedAmount = 0, dValidAmountForCommission_Over = 0;
                                //                                                    decimal dRange1Value = 0, dRange2Value = 0, dRange3Value = 0, dRange4Value = 0, dRange5Value = 0, dRange1Pasantage = 0, dRange2Pasantage = 0, dRange3Pasantage = 0, dRange4Pasantage = 0, dRange5Pasantage = 0, dRange1Commission = 0, dRange2Commission = 0, dRange3Commission = 0, dRange4Commission = 0, dRange5Commission = 0;

                                //                                                    dBalanceAmount -= oSettment.SattledAmount;
                                //                                                    dValidAmountForCommission_Over = dDaysForCommission <= 0 ? oSettment.SattledAmount : 0;
                                //                                                    if (bIsVatNbt_Reduce_Enable)
                                //                                                        dAllocatedAmount = oSettment.SattledAmount;
                                //                                                    else
                                //                                                    {
                                //                                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oSettment.SattledAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dAllocatedAmount, ref dTempValue2, ref  dTempValue3);
                                //                                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dValidAmountForCommission_Over, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dValidAmountForCommission_Over, ref dTempValue2, ref  dTempValue3);
                                //                                                    }
                                //                                                    clsGetValues.get_CommissionValueAll_FromCommissionSlabs(dDaysForCommission, oCusFin.CommissionCreditPeriod, dAllocatedAmount, oEmployee.CommisionPersentage_Normal, ref dRange1Value, ref dRange2Value, ref dRange3Value, ref dRange4Value, ref dRange5Value, ref dRange1Pasantage, ref dRange2Pasantage, ref dRange3Pasantage, ref dRange4Pasantage, ref dRange5Pasantage, ref dRange1Commission, ref dRange2Commission, ref dRange3Commission, ref dRange4Commission, ref dRange5Commission);
                                //                                                    glbDtsSales.dt_sasSalesCommissionSummary_DateWise.Adddt_sasSalesCommissionSummary_DateWiseRow(detail.InvoiceDate.Month.ToString(), 0, 0, 0, 0, dCommissionPasantage_Bonus, dSalesTarget_Bonus, "Within 30 Days ", dRange1Value, dglbRange1_Pasantage, dRange1Commission,
                                //                                                        "Within 45 Days ", dRange2Value, dglbRange2_Pasantage, dRange2Commission, "Within 60 Days ", dRange3Value, dglbRange3_Pasantage, dRange3Commission, "Within 60 Days", dRange4Value, dglbRange4_Pasantage, dRange4Commission, "Over 90 Days", dRange5Value, dglbRange5_Pasantage, dRange5Commission, 0, detail.InvoiceDate.Month, dSalesTarget_Minimum, dCommissionPasantage_Original, dValidAmountForCommission_Over);
                                //                                                    #endregion
                                //                                                }
                                //                                                else
                                //                                                {
                                //                                                    #region Returned Cheque
                                //                                                    decimal dReturnedAmount = oSettment.SattledAmount, dReturnAmountPaid = 0;
                                //                                                    DateTime dtmPaymentDate = detail.InvoiceDate;
                                //                                                    string sPaymentDetail = "";
                                //                                                    foreach (tbl_sasInvoice oReturnedCheque in tbl_sasInvoice.SelectAllByChequeRegister_ID(oCheque.ChequeRegister_ID))
                                //                                                    {
                                //                                                        foreach (tbl_sasInvoice_Sattled oRCSettment in tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(oReturnedCheque.Invoice_ID))
                                //                                                        {
                                //                                                            #region Cheque
                                //                                                            if (oRCSettment.ChequeRegister_ID != "default" && oRCSettment.Receipt_ID != "default") //Cheque
                                //                                                            {
                                //                                                                tbl_bpsChequeRegister oRCCheque = tbl_bpsChequeRegister.Select(oRCSettment.ChequeRegister_ID);
                                //                                                                if (oRCCheque != null && oRCCheque.ChequeRegister_ID != "default")
                                //                                                                {
                                //                                                                    if (oRCCheque.IsReconcilied || oRCCheque.IsReIssued)
                                //                                                                    {
                                //                                                                        if (oRCCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C) && oRCCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_O) && oRCCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_R))
                                //                                                                        {
                                //                                                                            dReturnAmountPaid += oRCSettment.SattledAmount;
                                //                                                                            if (dtmPaymentDate < oRCCheque.DateReconcilied)
                                //                                                                            {
                                //                                                                                dtmPaymentDate = oRCCheque.DateReconcilied;
                                //                                                                                sPaymentDetail = "RP " + oRCCheque.Receipt_ID + "<" + oRCCheque.ChequeNumber + ">";
                                //                                                                            }
                                //                                                                        }
                                //                                                                    }
                                //                                                                }
                                //                                                            }
                                //                                                            #endregion

                                //                                                            #region Cash
                                //                                                            else if (oRCSettment.ChequeRegister_ID == "default" && oRCSettment.Receipt_ID != "default")
                                //                                                            {
                                //                                                                tbl_bpsReceipt oRCReceipt = tbl_bpsReceipt.Select(oRCSettment.Receipt_ID);
                                //                                                                if (oRCReceipt != null && oRCReceipt.Receipt_ID != "default")
                                //                                                                {
                                //                                                                    if (oRCReceipt.CashAmount > 0)
                                //                                                                    {
                                //                                                                        dReturnAmountPaid += oRCSettment.SattledAmount;
                                //                                                                        if (dtmPaymentDate < oRCReceipt.ReceiptDate)
                                //                                                                        {
                                //                                                                            dtmPaymentDate = oRCReceipt.ReceiptDate;
                                //                                                                            sPaymentDetail = "RP " + oRCReceipt.Receipt_ID;
                                //                                                                        }
                                //                                                                    }
                                //                                                                }
                                //                                                            }
                                //                                                            #endregion

                                //                                                            #region Credit Note
                                //                                                            else if (oRCSettment.CreditNote_ID != "default")
                                //                                                            {
                                //                                                                tbl_bpsCreditNote oRCCreditNote = tbl_bpsCreditNote.Select(oRCSettment.CreditNote_ID);
                                //                                                                if (oRCCreditNote != null && oRCCreditNote.CreditNote_ID != "default")
                                //                                                                {
                                //                                                                    dReturnAmountPaid += oRCSettment.SattledAmount;
                                //                                                                    if (dtmPaymentDate < oRCCreditNote.CreditNoteDate)
                                //                                                                    {
                                //                                                                        dtmPaymentDate = oRCCreditNote.CreditNoteDate;
                                //                                                                        sPaymentDetail = "RP " + oRCCreditNote.CreditNote_ID;
                                //                                                                    }
                                //                                                                }
                                //                                                            }
                                //                                                            #endregion
                                //                                                        }

                                //                                                        if (dReturnAmountPaid >= dReturnedAmount)
                                //                                                        {
                                //                                                            iDayes = clsCommon.getDays(detail.InvoiceDate, dtmPaymentDate);
                                //                                                            decimal dDaysForCommission = iDayes - oCusFin.CommissionCreditPeriod;
                                //                                                            decimal dAllocatedAmount = 0, dValidAmountForCommission_Over = 0; //decimal dBalanceWithoutVAT = 0;
                                //                                                            decimal dRange1Value = 0, dRange2Value = 0, dRange3Value = 0, dRange4Value = 0, dRange5Value = 0, dRange1Pasantage = 0, dRange2Pasantage = 0, dRange3Pasantage = 0, dRange4Pasantage = 0, dRange5Pasantage = 0, dRange1Commission = 0, dRange2Commission = 0, dRange3Commission = 0, dRange4Commission = 0, dRange5Commission = 0;

                                //                                                            dBalanceAmount -= oSettment.SattledAmount;
                                //                                                            dValidAmountForCommission_Over = dDaysForCommission <= 0 ? oSettment.SattledAmount : 0;
                                //                                                            if (bIsVatNbt_Reduce_Enable)
                                //                                                            {
                                //                                                                dAllocatedAmount = oSettment.SattledAmount;
                                //                                                            }
                                //                                                            else
                                //                                                            {
                                //                                                                clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oSettment.SattledAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dAllocatedAmount, ref dTempValue2, ref  dTempValue3);
                                //                                                                clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dValidAmountForCommission_Over, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dValidAmountForCommission_Over, ref dTempValue2, ref  dTempValue3);
                                //                                                            }
                                //                                                            clsGetValues.get_CommissionValueAll_FromCommissionSlabs(dDaysForCommission, oCusFin.CommissionCreditPeriod, dAllocatedAmount, oEmployee.CommisionPersentage_Normal, ref dRange1Value, ref dRange2Value, ref dRange3Value, ref dRange4Value, ref dRange5Value, ref dRange1Pasantage, ref dRange2Pasantage, ref dRange3Pasantage, ref dRange4Pasantage, ref dRange5Pasantage, ref dRange1Commission, ref dRange2Commission, ref dRange3Commission, ref dRange4Commission, ref dRange5Commission);
                                //                                                            decimal dTotalCommission = dRange1Commission + dRange2Commission + dRange3Commission + dRange4Commission + dRange5Commission;
                                //                                                            glbDtsSales.dt_sasSalesCommissionSummary_DateWise.Adddt_sasSalesCommissionSummary_DateWiseRow(detail.InvoiceDate.Month.ToString(), 0, 0, 0, 0, dCommissionPasantage_Bonus, dSalesTarget_Bonus, "Within 30 Days ", dRange1Value, dglbRange1_Pasantage, dRange1Commission,
                                //                                                           "Within 45 Days ", dRange2Value, dglbRange2_Pasantage, dRange2Commission, "Within 60 Days ", dRange3Value, dglbRange3_Pasantage, dRange3Commission, "Within 90 Days ", dRange4Value, dglbRange4_Pasantage, dRange4Commission, "Over 90 Days", dRange5Value, dglbRange5_Pasantage, dRange5Commission, 0, detail.InvoiceDate.Month, dSalesTarget_Minimum, dCommissionPasantage_Original, dValidAmountForCommission_Over);

                                //                                                        }
                                //                                                    }
                                //                                                    #endregion
                                //                                                }
                                //                                            }
                                //                                        }
                                //                                    }
                                //                                    #endregion

                                //                                    #region Cash
                                //                                    else if (oSettment.ChequeRegister_ID == "default" && oSettment.Receipt_ID != "default")
                                //                                    {
                                //                                        tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(oSettment.Receipt_ID);
                                //                                        if (oReceipt != null && oReceipt.Receipt_ID != "default")
                                //                                        {
                                //                                            if (oReceipt.CashAmount > 0)
                                //                                            {
                                //                                                iDayes = clsCommon.getDays(detail.InvoiceDate, oReceipt.ReceiptDate);
                                //                                                decimal dDaysForCommission = iDayes - oCusFin.CommissionCreditPeriod;
                                //                                                decimal dAllocatedAmount = 0, dValidAmountForCommission = 0;
                                //                                                decimal dRange1Value = 0, dRange2Value = 0, dRange3Value = 0, dRange4Value = 0, dRange5Value = 0, dRange1Pasantage = 0, dRange2Pasantage = 0, dRange3Pasantage = 0, dRange4Pasantage = 0, dRange5Pasantage = 0, dRange1Commission = 0, dRange2Commission = 0, dRange3Commission = 0, dRange4Commission = 0, dRange5Commission = 0;

                                //                                                dBalanceAmount -= oSettment.SattledAmount;
                                //                                                dValidAmountForCommission = dDaysForCommission <= 0 ? oSettment.SattledAmount : 0;
                                //                                                if (bIsVatNbt_Reduce_Enable)
                                //                                                    dAllocatedAmount = oSettment.SattledAmount;
                                //                                                else
                                //                                                {
                                //                                                    clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oSettment.SattledAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dAllocatedAmount, ref dTempValue2, ref  dTempValue3);
                                //                                                    clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dValidAmountForCommission, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dValidAmountForCommission, ref dTempValue2, ref  dTempValue3);
                                //                                                }
                                //                                                clsGetValues.get_CommissionValueAll_FromCommissionSlabs(dDaysForCommission, oCusFin.CommissionCreditPeriod, dAllocatedAmount, oEmployee.CommisionPersentage_Normal, ref dRange1Value, ref dRange2Value, ref dRange3Value, ref dRange4Value, ref dRange5Value, ref dRange1Pasantage, ref dRange2Pasantage, ref dRange3Pasantage, ref dRange4Pasantage, ref dRange5Pasantage, ref dRange1Commission, ref dRange2Commission, ref dRange3Commission, ref dRange4Commission, ref dRange5Commission);
                                //                                                glbDtsSales.dt_sasSalesCommissionSummary_DateWise.Adddt_sasSalesCommissionSummary_DateWiseRow(detail.InvoiceDate.Month.ToString(), 0, 0, 0, 0, dCommissionPasantage_Bonus, dSalesTarget_Bonus, "Within 30 Days ", dRange1Value, dglbRange1_Pasantage, dRange1Commission,
                                //                                                    "Within 45 Days ", dRange2Value, dglbRange2_Pasantage, dRange2Commission, "Within 60 Days ", dRange3Value, dglbRange3_Pasantage, dRange3Commission, "Within 90 Days ", dRange4Value, dglbRange4_Pasantage, dRange4Commission, "Over 90 Days", dRange5Value, dglbRange5_Pasantage, dRange5Commission, 0, detail.InvoiceDate.Month, dSalesTarget_Minimum, dCommissionPasantage_Original, dValidAmountForCommission);
                                //                                            }
                                //                                        }
                                //                                    }
                                //                                    #endregion

                                //                                    #region Credit Note
                                //                                    else if (oSettment.CreditNote_ID != "default")
                                //                                    {
                                //                                        tbl_bpsCreditNote oCreditNote = tbl_bpsCreditNote.Select(oSettment.CreditNote_ID);
                                //                                        if (oCreditNote != null && oCreditNote.CreditNote_ID != "default")
                                //                                        {

                                //                                            iDayes = clsCommon.getDays(detail.InvoiceDate, oCreditNote.CreditNoteDate);
                                //                                            decimal dDaysForCommission = iDayes - oCusFin.CommissionCreditPeriod;
                                //                                            decimal dAllocatedAmount = 0, dValidAmountForCommission = 0;
                                //                                            decimal dRange1Value = 0, dRange2Value = 0, dRange3Value = 0, dRange4Value = 0, dRange5Value = 0, dRange1Pasantage = 0, dRange2Pasantage = 0, dRange3Pasantage = 0, dRange4Pasantage = 0, dRange5Pasantage = 0, dRange1Commission = 0, dRange2Commission = 0, dRange3Commission = 0, dRange4Commission = 0, dRange5Commission = 0;

                                //                                            dBalanceAmount -= oSettment.SattledAmount;
                                //                                            dValidAmountForCommission = dDaysForCommission <= 0 ? oSettment.SattledAmount : 0;
                                //                                            if (bIsVatNbt_Reduce_Enable)
                                //                                                dAllocatedAmount = oSettment.SattledAmount;
                                //                                            else
                                //                                            {
                                //                                                clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oSettment.SattledAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dAllocatedAmount, ref dTempValue2, ref  dTempValue3);
                                //                                                clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dValidAmountForCommission, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dValidAmountForCommission, ref dTempValue2, ref  dTempValue3);
                                //                                            }
                                //                                            clsGetValues.get_CommissionValueAll_FromCommissionSlabs(dDaysForCommission, oCusFin.CommissionCreditPeriod, dAllocatedAmount, oEmployee.CommisionPersentage_Normal, ref dRange1Value, ref dRange2Value, ref dRange3Value, ref dRange4Value, ref dRange5Value, ref dRange1Pasantage, ref dRange2Pasantage, ref dRange3Pasantage, ref dRange4Pasantage, ref dRange5Pasantage, ref dRange1Commission, ref dRange2Commission, ref dRange3Commission, ref dRange4Commission, ref dRange5Commission);
                                //                                            decimal dTotalCommission = dRange1Commission + dRange2Commission + dRange3Commission + dRange4Commission;
                                //                                            glbDtsSales.dt_sasSalesCommissionSummary_DateWise.Adddt_sasSalesCommissionSummary_DateWiseRow(detail.InvoiceDate.Month.ToString(), 0, 0, 0, 0, dCommissionPasantage_Bonus, dSalesTarget_Bonus, "Within 30 Days ", dRange1Value, dglbRange1_Pasantage, dRange1Commission,
                                //                                                "Within 45 Days ", dRange2Value, dglbRange2_Pasantage, dRange2Commission, "Within 60 Days ", dRange3Value, dglbRange3_Pasantage, dRange3Commission, "Within 90 Days ", dRange4Value, dglbRange4_Pasantage, dRange4Commission, "Over 90 Days", dRange5Value, dglbRange5_Pasantage, dRange5Commission, 0, detail.InvoiceDate.Month, dSalesTarget_Minimum, dCommissionPasantage_Original, dValidAmountForCommission);

                                //                                        }
                                //                                    }
                                //                                    #endregion
                                //                                }
                                //                                #endregion

                                //                                #region Invoice Outstanding
                                //                                if (dBalanceAmount > 0)
                                //                                {
                                //                                    decimal dInvoiceOutstandingAmount = 0;
                                //                                    if (bIsVatNbt_Reduce_Enable)
                                //                                        dInvoiceOutstandingAmount = dBalanceAmount;
                                //                                    else
                                //                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dBalanceAmount, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dInvoiceOutstandingAmount, ref dTempValue2, ref  dTempValue3);
                                //                                    glbDtsSales.dt_sasSalesCommissionSummary_DateWise.Adddt_sasSalesCommissionSummary_DateWiseRow(detail.InvoiceDate.Month.ToString(), 0, 0, 0, 0, dCommissionPasantage_Bonus, dSalesTarget_Bonus, "Within 30 Days ", 0, dglbRange1_Pasantage, 0,
                                //                                                          "Within 45 Days ", 0, dglbRange2_Pasantage, 0, "Within 60 Days ", 0, dglbRange3_Pasantage, 0, "Within 90 Days ", 0, dglbRange4_Pasantage, 0, "Over 90 Days ", dglbRange5_Pasantage, 0, 0, dInvoiceOutstandingAmount, detail.InvoiceDate.Month, dSalesTarget_Minimum, dCommissionPasantage_Original, 0);
                                //                                }
                                //                                #endregion

                                //                                #region For Header Details
                                //                                decimal dNetAmount = 0;
                                //                                if (bIsVatNbt_Reduce_Enable)
                                //                                    dNetAmount = detail.GrandTotal;
                                //                                else
                                //                                    clsHelpMethods.SetVATandNBTValues_FromGrandTotal(detail.GrandTotal, detail.VatPercentage, detail.NbtPercentage, ref dTempValue1, ref dNetAmount, ref dTempValue2, ref  dTempValue3);
                                //                                tmpCommissionSummary otmpCommissionSummary = new tmpCommissionSummary();
                                //                                otmpCommissionSummary.dSalesValue = dNetAmount;
                                //                                otmpCommissionSummary.monthID = detail.InvoiceDate.Month;
                                //                                otmpCommissionSummary.dCreditNoteValue = 0;
                                //                                otmpCommissionSummarys.Add(otmpCommissionSummary);
                                //                                #endregion
                                //                            }
                                //                            #endregion

                                //                            #region Credit Notes
                                //                            foreach (tbl_bpsCreditNote oCreditNote in tbl_bpsCreditNote.SelectAll_ByCustomerIDandDateRange(dtpFrom.Value.Date, dtpTo.Value.Date, oCustomer.Customer_ID).Where(p => p.CreditNote_ID != "default" && !p.IsDeleted && p.CreditNoteType_ID != clsAutocode.getCreditNoteTypeID(CreditNoteType.ReturnedChequeDeposit)))
                                //                            {
                                //                                decimal dCreditNoteNetAmount = 0, dTempValue1 = 0, dTempValue2 = 0, dTempValue3 = 0, dNonSalesCreditValues = 0;
                                //                                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                //                                {
                                //                                    foreach (tbl_sasInvoice_Sattled oAllocation in tbl_sasInvoice_Sattled.SelectAllByCreditNote_ID(oCreditNote.CreditNote_ID))
                                //                                    {
                                //                                        tbl_sasInvoice oCRInvoice = tbl_sasInvoice.Select(oAllocation.Invoice_ID);
                                //                                        if (oCRInvoice != null && oCRInvoice.Invoice_ID != "default")
                                //                                        {
                                //                                            if (oCRInvoice.Quotation_ID != "default") //Block Sales
                                //                                                dNonSalesCreditValues += oAllocation.SattledAmount;
                                //                                            else if (oCRInvoice.DeliveryOrder_ID != "default" && oCRInvoice.Job_ID == "default") //Direct Sales
                                //                                                dNonSalesCreditValues += oAllocation.SattledAmount;
                                //                                        }
                                //                                    }
                                //                                }
                                //                                decimal dValidCRAmount = (oCreditNote.TotalAmount - dNonSalesCreditValues);

                                //                                if (bIsVatNbt_Reduce_Enable)
                                //                                    dCreditNoteNetAmount = dValidCRAmount;
                                //                                else
                                //                                    clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dValidCRAmount, oCreditNote.VatPercentage, oCreditNote.NbtPercentage, ref dTempValue1, ref dCreditNoteNetAmount, ref dTempValue2, ref  dTempValue3);
                                //                                tmpCommissionSummary otmpCommissionSummary = new tmpCommissionSummary();
                                //                                otmpCommissionSummary.dSalesValue = 0;
                                //                                otmpCommissionSummary.monthID = oCreditNote.CreditNoteDate.Month;
                                //                                otmpCommissionSummary.dCreditNoteValue = dCreditNoteNetAmount;
                                //                                otmpCommissionSummarys.Add(otmpCommissionSummary);
                                //                            }
                                //                            #endregion

                                //                            #region Add Header Details
                                //                            var oBonusCommissions = otmpCommissionSummarys.GroupBy(gb => new { gb.monthID }, (Key, group) => new { MonthID = Key.monthID, SalesValue = group.Sum(p => p.dSalesValue), CreditNoteValue = group.Sum(p => p.dCreditNoteValue) });
                                //                            foreach (var oBonusCommission in oBonusCommissions.OrderBy(p => (p.MonthID)))
                                //                            {
                                //                                decimal dValidAmountForBonous = oBonusCommission.SalesValue - oBonusCommission.CreditNoteValue;
                                //                                decimal dExceedAmountForBonus = dValidAmountForBonous - dSalesTarget_Bonus;
                                //                                dExceedAmountForBonus = dExceedAmountForBonus > 0 ? dExceedAmountForBonus : 0;

                                //                                glbDtsSales.dt_sasSalesCommissionSummary_DateWise.Adddt_sasSalesCommissionSummary_DateWiseRow(oBonusCommission.MonthID.ToString(), oBonusCommission.SalesValue, oBonusCommission.CreditNoteValue, dValidAmountForBonous, dExceedAmountForBonus, dCommissionPasantage_Bonus, dSalesTarget_Bonus, "Within 30 Days ", 0, dglbRange1_Pasantage, 0,
                                //                                                       "Within 45 Days ", 0, dglbRange2_Pasantage, 0, "Within 60 Days ", 0, dglbRange3_Pasantage, 0, "Within 90 Days ", 0, dglbRange4_Pasantage, 0, "Over 90 Days ", 0, dglbRange5_Pasantage, 0, 0, oBonusCommission.MonthID, dSalesTarget_Minimum, dCommissionPasantage_Original, 0);

                                //                            }
                                //                            #endregion
                                //                        }
                                //                    }
                                //                    if (bSelesRepSelected)
                                //                        sFilter = txtSalesRep.Text.Trim();
                                //                    if (bCustomerSelected)
                                //                        sFilter = txtCustomer.Text.Trim();

                                //                    if (rdoSalesCommissionSummary_DateWise.Checked)
                                //                        print("\\reports\\SAS\\Finance\\rpt_sas_SalesCommissionSummary_DateWise.rpt", "Sales Commission Summary(Month Wise)", glbDtsSales, sFilter);
                                //                    if (rdoSalescommissionStatement.Checked)
                                //                        print("\\reports\\SAS\\Finance\\rpt_sas_SalesCommissionSummary_statement.rpt", "Sales Commission Summary(Month Wise)", glbDtsSales, sFilter);
                                //                }
                                //                catch (Exception ex)
                                //                {
                                //                    SEACCException.Show(ex);
                                //                }
                                //                finally
                                //                {
                                //                    glbDtsSales.dt_sasSalesCommissionSummary_DateWise.Rows.Clear();
                                //                    Cursor = Cursors.Default;
                                //                }
                                //                #endregion
                                //            }
                                //            else
                                //            {
                                //                MessageBox.Show("Please Select One Month......! ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //            }
                                //        }
                                //        else
                                //        {
                                //            MessageBox.Show("Select A Saleman......!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //        }
                                //    }
                                //}
                                //#endregion

                                //#region Incentive Report
                                //else if (rdoInsentive.Checked)
                                //{
                                //    try
                                //    {
                                //        if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Incentive)))
                                //        {
                                //            Cursor = Cursors.WaitCursor;
                                //            glb_dts_bssIncentive.dt_Incenive.Rows.Clear();
                                //            sFilter = "";
                                //            string sOldCOID = "";
                                //            foreach (tbl_sasCustomerOrder oCustomerOrder in tbl_sasCustomerOrder.SelectAll().Where(p => p.CustomerOrder_ID != "default" && p.CustomerOrderDate.Date >= dtpFrom.Value.Date && p.CustomerOrderDate.Date <= dtpTo.Value.Date))
                                //            {
                                //                decimal dOrderedQty = 0;

                                //                if (bCustomerSelected)
                                //                    if (oCustomerOrder.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                //                        continue;

                                //                foreach (tbl_sasCustomerOrder_Detail oCODetail in tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(oCustomerOrder.CustomerOrder_ID))
                                //                    dOrderedQty = oCustomerOrder.IsWeightCalculation ? oCODetail.Weight : oCODetail.Qty;

                                //                foreach (tbl_sasDeliveryOrder oDo in tbl_sasDeliveryOrder.SelectAllByCustomerOrder_ID(oCustomerOrder.CustomerOrder_ID).Where(p => !p.IsDeleted && p.DeliveryOrder_ID != "default"))
                                //                {
                                //                    decimal dSRNQty = 0, dDeliveryQty = 0;
                                //                    foreach (tbl_sasDeliveryOrder_Detail oDoDetail in tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(oDo.DeliveryOrder_ID))
                                //                    {
                                //                        dDeliveryQty += oDo.IsWeightCalculation ? oDoDetail.Weight : oDoDetail.Qty;
                                //                        foreach (tbl_sasSalesReturnedNote oSalesReturn in tbl_sasSalesReturnedNote.SelectAllByDeliveryOrder_ID(oDo.DeliveryOrder_ID).Where(p => !p.IsDeleted && p.SalesReturnedNote_ID != "default"))
                                //                        {
                                //                            foreach (tbl_sasSalesReturnedNote_Detail oSRD in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSalesReturn.SalesReturnedNote_ID))
                                //                                dSRNQty += oSalesReturn.IsWeightCalculation ? oSRD.Weight : oSRD.Qty;
                                //                        }
                                //                    }

                                //                    foreach (tbl_sasInvoice oInvoice in tbl_sasInvoice.SelectAllByDeliveryOrder_ID(oDo.DeliveryOrder_ID).Where(p => !p.IsDeleted && p.Invoice_ID != "default"))
                                //                    {
                                //                        decimal dCRNAmount = 0, dPaidAmount = 0, dInvQty = 0;
                                //                        foreach (tbl_sasInvoice_Detail oInvDetail in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID))
                                //                            dInvQty += oInvoice.IsWeightCalculation ? oInvDetail.Weight : oInvDetail.Qty;

                                //                        foreach (tbl_sasInvoice_Sattled oSettment in tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(oInvoice.Invoice_ID))
                                //                        {
                                //                            if (oSettment.CreditNote_ID != "default")
                                //                            {
                                //                                tbl_bpsCreditNote oCreditNote = tbl_bpsCreditNote.Select(oSettment.CreditNote_ID);
                                //                                if (oCreditNote != null && oCreditNote.CreditNote_ID != "default" && !oCreditNote.IsDeleted)
                                //                                {
                                //                                    dCRNAmount += oCreditNote.TotalAmount;
                                //                                }
                                //                            }
                                //                            else
                                //                                dPaidAmount += oSettment.SattledAmount;
                                //                        }
                                //                        decimal dBalanceAmount = oInvoice.GrandTotal - dPaidAmount - dCRNAmount;
                                //                        decimal dActualQty = dInvQty - dSRNQty;
                                //                        bool bSameOrder = oCustomerOrder.CustomerOrder_ID == sOldCOID ? true : false;
                                //                        string sPO = bSameOrder ? "" : oCustomerOrder.PurchaseOrder_ID;
                                //                        string sJobID = bSameOrder ? "" : oDo.Job_ID;
                                //                        decimal dJobQty = bSameOrder ? 0 : dOrderedQty;
                                //                        glb_dts_bssIncentive.dt_Incenive.Adddt_InceniveRow(sPO, sJobID, dJobQty, oInvoice.InvoiceDate, oInvoice.Invoice_ID, oDo.DeliveryOrder_ID, oInvoice.GrandTotal, dPaidAmount, dCRNAmount, dBalanceAmount, dInvQty, dSRNQty, dActualQty, 0, 0);
                                //                        sOldCOID = oCustomerOrder.CustomerOrder_ID;
                                //                    }
                                //                }
                                //            }
                                //            print("\\reports\\BSS\\Standard\\rpt_sas_Incentive.rpt", "Incentive Report(Customer Order Wise)", glb_dts_bssIncentive, sFilter);
                                //        }
                                //    }
                                //    catch (Exception ex)
                                //    {
                                //        SEACCException.Show(ex);
                                //    }
                                //    finally
                                //    {
                                //        glb_dts_bssIncentive.dt_Incenive.Rows.Clear();
                                //        Cursor = Cursors.Default;
                                //    }
                                //}

                                //#endregion
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

        private void GenarateReport_CustomerOutstandingBackDate(enum_ReportName enmReport, bool isRepWise)
        {
            //if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enmReport)))
            //{
            string sMessage = "";
            //    if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enmReport), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
            //    {
            try
            {
                if (txtSlab1.Text == "")
                    txtSlab1.Text = "0";
                if (txtSlab2.Text == "")
                    txtSlab2.Text = "0";
                if (txtSlab3.Text == "")
                    txtSlab3.Text = "0";
                if (txtSlab4.Text == "")
                    txtSlab4.Text = "0";
                if (txtSlab5.Text == "")
                    txtSlab5.Text = "0";

                if (int.Parse(txtSlab1.Text) < int.Parse(txtSlab2.Text) && int.Parse(txtSlab2.Text) < int.Parse(txtSlab3.Text) && int.Parse(txtSlab3.Text) < int.Parse(txtSlab4.Text) && int.Parse(txtSlab4.Text) < int.Parse(txtSlab5.Text))
                {
                    gbl_dts_bssOutstandingLedger.Clear();
                    glb_dtsReportExport.Clear();

                    int iSalesRepShowType = 0;

                    Cursor = Cursors.WaitCursor;
                    #region Fill Sales rep dataset
                    foreach (tbl_genEmployeeMaster oSalesRep in tbl_genEmployeeMaster.SelectAll().Where(p => p.IsSelesRep))
                    {
                        gbl_dts_bssOutstandingLedger.genSalesRep.AddgenSalesRepRow(oSalesRep.Employee_ID, oSalesRep.EmployeeName);
                    }
                    #endregion

                    #region Fill Customer Finance dataset
                    if (enmReport == enum_ReportName.RG_Outstanding_Invoice_wise_Detail || enmReport == enum_ReportName.RG_Outstanding_Invoice_wise_Summary || enmReport == enum_ReportName.RG_OutstandingStatement || enmReport == enum_ReportName.RG_Age_Analysis_Customer_wise || enmReport == enum_ReportName.RG_Age_Analysis_Salesman_wise || enmReport == enum_ReportName.RG_OutstandingStatement_Salesman_wise)
                    {
                        if (bCustomerSelected)
                        {
                            tbl_genCustomerFinance oDetail =
                                tbl_genCustomerFinance.Select(txtCustomer.Tag.ToString().Trim());
                            if (oDetail != null)
                            {
                                tbl_genCustomerMaster oCustomerMaster = tbl_genCustomerMaster.Select(oDetail.Customer_ID);
                                if (oCustomerMaster != null)
                                {
                                    gbl_dts_bssOutstandingLedger.genCustomerFinance.AddgenCustomerFinanceRow(
                                        oDetail.Customer_ID, oCustomerMaster.CustomerName,
                                        oCustomerMaster.AddressRegister, "", 0,
                                        oDetail.CreditPeriod, oDetail.CreditLimit, oCustomerMaster.SalesRep_ID, clsGenaralName.getName_SalesRep(oCustomerMaster.SalesRep_ID), "", -1, "", "");
                                }
                            }
                        }
                        else
                        {
                            foreach (tbl_genCustomerFinance oDetail in tbl_genCustomerFinance.SelectAll()
                                .Where(p => p.Customer_ID != "default"))
                            {
                                tbl_genCustomerMaster oCustomerMaster = tbl_genCustomerMaster.Select(oDetail.Customer_ID);
                                if (oCustomerMaster != null)
                                {

                                    gbl_dts_bssOutstandingLedger.genCustomerFinance.AddgenCustomerFinanceRow(
                                        oDetail.Customer_ID, oCustomerMaster.CustomerName,
                                       oCustomerMaster.AddressRegister, "", 0,
                                        oDetail.CreditPeriod, oDetail.CreditLimit, oCustomerMaster.SalesRep_ID, clsGenaralName.getName_SalesRep(oCustomerMaster.SalesRep_ID), "", -1, "", "");
                                }
                            }
                        }
                    }
                    #endregion

                    string sSalesRep_ID = "default";
                    List<tbl_genCustomerMaster> ocustomers;
                    #region Customer
                    if (bCustomerSelected)
                        ocustomers = tbl_genCustomerMaster.SelectAll().Where(p => p.Customer_ID == txtCustomer.Tag.ToString().Trim()).ToList();
                    else
                        ocustomers = tbl_genCustomerMaster.SelectAll().Where(p => p.Customer_ID != "default" && p.CompanyBranch_ID == clsSecurity.BranchID).ToList();

                    if (bCustomerClassSelected)
                        ocustomers = ocustomers.Where(p => p.CustomerClass_ID == txtCustomerClassID.Tag.ToString()).ToList();

                    if (bCustomerTypeSelected)
                        ocustomers = ocustomers.Where(p => p.CustomerType_ID == txtCustomerTypeID.Tag.ToString()).ToList();

                    if (bCustomerCategorySelected)
                        ocustomers = ocustomers.Where(p => p.CustomerCategory_ID == txtCategoryID.Tag.ToString()).ToList();
                    #endregion



                    foreach (tbl_genCustomerMaster ocustomer in ocustomers)
                    {
                        if (!bCustomerSelected)
                            clsHelpMethods_Local.startProgressBar(0, ocustomers.Count + 2, 1, ProgressBar);

                        #region Sales rep filter - customer master
                        if (isRepWise)
                        {
                            if (chkUseCustomerMastorSaleRep.Checked)
                            {
                                sSalesRep_ID = ocustomer.SalesRep_ID;
                                if (bSelesRepSelected)
                                    if (ocustomer.SalesRep_ID != txtSalesRep.Tag.ToString().Trim())
                                        continue;
                                iSalesRepShowType = 2;
                            }
                            else
                                iSalesRepShowType = 1;//filter by the SQL 
                        }
                        #endregion

                        var oDetails = srh_bssCustomerOutstanding.SelectAllByCustomerId(ocustomer.Customer_ID, clsSecurity.BranchID, Convert.ToDateTime("01/01/2001"), dtpTo.Value.Date, true);
                        //if (oDetails.Count < 1 && enmReport == enum_ReportName.RG_OutstandingStatement)
                        //{
                        //    //Customers who don't have outstanding...
                        //    gbl_dts_bssOutstandingLedger.bssCustomerOutstanding
                        //           .AddbssCustomerOutstandingRow(ocustomer.Customer_ID,
                        //               ocustomer.CustomerName, -1,
                        //               "", dtpTo.Value.Date,
                        //               0, 0, "",
                        //               false, false, true, "",
                        //               0, "",
                        //               "", "",
                        //               "", 0,
                        //               false, "", 0);
                        //}
                        //else
                        //{
                        foreach (srh_bssCustomerOutstanding oDetail in oDetails)
                        {
                            #region Sales rep filter - Others

                            if (iSalesRepShowType == 1)
                            {
                                if (bSelesRepSelected)
                                    if (oDetail.Employee_ID != txtSalesRep.Tag.ToString().Trim())
                                        continue;
                                sSalesRep_ID = oDetail.Employee_ID;
                            }

                            #endregion

                            if (enmReport == enum_ReportName.RG_Outstanding_Invoice_wise_Detail)
                            {
                                if (oDetail.IsChecueInHand)
                                {
                                    foreach (srh_bssCustomerOutstanding_RecieptDetail oRecipts in
                                        srh_bssCustomerOutstanding_RecieptDetail.SelectAll(
                                            oDetail.PurchaseOrder_ID, dtpTo.Value.Date))
                                    {
                                        //gbl_dts_bssOutstandingLedger.bssCustomerOutstanding
                                        //    .AddbssCustomerOutstandingRow(oDetail.Customer_ID,
                                        //        ocustomer.CustomerName, oDetail.TransactionType,
                                        //        oRecipts.Invoice_ID, oRecipts.InvoiceDate,
                                        //        oRecipts.GrandTotal, oRecipts.SattledAmount, "",
                                        //        oDetail.IsCredit, oDetail.IsChecueInHand, false, "",
                                        //        oRecipts.Age, oRecipts.DeliveryOrder_ID,
                                        //        oRecipts.PurchaseOrder_ID, oRecipts.Receipt_ID,
                                        //        oRecipts.CurrencyCode, oRecipts.CurrencyRate,
                                        //        oDetail.IsAdvance, oDetail.OrderRefNo, 0);
                                    }

                                    continue;
                                }

                                if (oDetail.TransactionType == 3)
                                {
                                    decimal dRCSettledAmount =
                                        oDetail.TransactionAmount - oDetail.Outstanding;

                                    foreach (srh_bssCustomerOutstanding_RecieptDetail oRecipts in
                                        srh_bssCustomerOutstanding_RecieptDetail
                                            .SelectAll(oDetail.PurchaseOrder_ID, dtpTo.Value.Date)
                                            .OrderBy(p => p.Age))
                                    {
                                        if (dRCSettledAmount >= oRecipts.SattledAmount)
                                            dRCSettledAmount -= oRecipts.SattledAmount;
                                        else
                                        {
                                            //gbl_dts_bssOutstandingLedger.bssCustomerOutstanding
                                            //    .AddbssCustomerOutstandingRow(oDetail.Customer_ID,
                                            //        ocustomer.CustomerName, oDetail.TransactionType,
                                            //        oRecipts.Invoice_ID, oRecipts.InvoiceDate,
                                            //        oRecipts.GrandTotal,
                                            //        (oRecipts.SattledAmount - dRCSettledAmount),
                                            //        oDetail.Remarks, oDetail.IsCredit, false, false, "",
                                            //        oRecipts.Age, oRecipts.DeliveryOrder_ID,
                                            //        oRecipts.PurchaseOrder_ID, "", oRecipts.CurrencyCode,
                                            //        oRecipts.CurrencyRate, oDetail.IsAdvance,
                                            //        oDetail.OrderRefNo, 0);
                                            dRCSettledAmount = 0;
                                        }
                                    }

                                    continue;
                                }
                            }
                            else if (enmReport == enum_ReportName.RG_Outstanding_Invoice_wise_Summary ||
                                     enmReport == enum_ReportName.RG_OutstandingStatement)
                            {
                                if (oDetail.IsChecueInHand)
                                    continue;
                            }

                            else if (enmReport == enum_ReportName.RG_OutstandingStatement_Salesman_wise)
                            {
                                if (!(oDetail.TransactionType == 3 || oDetail.TransactionType == 1 ||
                                      oDetail.TransactionType == 100 || oDetail.TransactionType == 2))
                                    continue;
                            }

                            //gbl_dts_bssOutstandingLedger.bssCustomerOutstanding
                            //    .AddbssCustomerOutstandingRow(oDetail.Customer_ID, ocustomer.CustomerName,
                            //        oDetail.TransactionType, oDetail.Transaction_ID,
                            //        oDetail.TransactionDate, oDetail.TransactionAmount, oDetail.Outstanding,
                            //        oDetail.Remarks, oDetail.IsCredit, oDetail.IsChecueInHand, false,
                            //        sSalesRep_ID, oDetail.Age, oDetail.DeliveryOrder_ID,
                            //        oDetail.PurchaseOrder_ID, "", oDetail.CurrencyCode,
                            //        oDetail.CurrencyRate, oDetail.IsAdvance, oDetail.OrderRefNo, 0);

                            if (bCustomerSelected)
                                clsHelpMethods_Local.startProgressBar(0, oDetails.Count + 2, 1,
                                    ProgressBar);
                            //}
                        }

                        if (gbl_dts_bssOutstandingLedger.bssCustomerOutstanding.Rows.Count < 1 &&
                            enmReport == enum_ReportName.RG_OutstandingStatement)
                        {
                            //Customers who don't have outstanding...
                            //gbl_dts_bssOutstandingLedger.bssCustomerOutstanding
                            //       .AddbssCustomerOutstandingRow(ocustomer.Customer_ID,
                            //           ocustomer.CustomerName, -1,
                            //           "", dtpTo.Value.Date,
                            //           0, 0, "",
                            //           false, false, true, "",
                            //           0, "",
                            //           "", "",
                            //           "", 0,
                            //           false, "", 0);
                        }
                    }

                    //string sDateRange = "From :" + dtpFrom.Value.ToString("dd MMM yyyy") + " To :" + dtpTo.Value.ToString("dd MMM yyyy");
                    string sDateRange = "As At : " + dtpTo.Value.Date.ToString("dd/MM/yyyy");

                    string sReportFilter = "";
                    if (bCustomerClassSelected)
                        sReportFilter += " Class: " + txtCustomerClassID.Text.Trim();
                    if (bCustomerTypeSelected)
                        sReportFilter += " Type: " + txtCustomerTypeID.Text.Trim();
                    if (bCustomerCategorySelected)
                        sReportFilter += " Category: " + txtCategoryID.Text.Trim();
                    if (bCustomerSelected)
                        sReportFilter += " Customer Name: " + txtCustomer.Text.Trim();
                    if (bSelesRepSelected)
                        sReportFilter += " Salesman Name: " + txtSalesRep.Text.Trim();
                    else
                        sReportFilter += (sReportFilter.Length > 0) ? "" : " - ";

                    gbl_dts_bssOutstandingLedger.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDateRange, clsSecurity.UserNameLoged, sReportFilter);

                    string sCompanyName = "", sCompanyTell = "", sCompanyAddress = "", sCompanyEmail = "";
                    tbl_genCompanyInfo oInfo = tbl_genCompanyInfo.Select("Company1");
                    if (oInfo != null && oInfo.CompanyID != "default")
                    {
                        //sCompanyName = clsSecurity.decryptPassword(oInfo.CompanyName);
                        sCompanyName = clsCript.Decrypt(oInfo.CompanyName);
                        sCompanyTell = oInfo.Telephone1;
                        sCompanyTell += "," + oInfo.Telephone2 != "" ? oInfo.Telephone2 : "";
                        sCompanyAddress = oInfo.Address;
                    }

                    if (enmReport == enum_ReportName.RG_OutstandingStatement)
                    {
                        tbl_securityCompanyValues oCompany = tbl_securityCompanyValues.Select((int)enum_CompanyValue.companyName);//7
                        if (oCompany != null)
                            sCompanyName = oCompany.CompanyValuesDetail;

                        oCompany = null;
                        oCompany = tbl_securityCompanyValues.Select((int)enum_CompanyValue.companyEmail);//6
                        if (oCompany != null)
                            sCompanyEmail = oCompany.CompanyValuesDetail;

                    }
                    // Slab
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Slab_1", txtSlab1.Text, true);
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Slab_2", txtSlab2.Text, true);
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Slab_3", txtSlab3.Text, true);
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Slab_4", txtSlab4.Text, true);
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Slab_5", txtSlab5.Text, true);

                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("isDetail", isDetailReport ? "1" : "0", true);
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", sCompanyName, true);
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ContactTel", sCompanyTell, true);
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Address", sCompanyAddress, true);
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ContactEmail", sCompanyEmail, true);

                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("BackDate", "As At Date : " + dtpTo.Value.Date.ToString("dd/MM/yyyy"), true);

                    frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                    rpt.print(sReportPath, gbl_dts_bssOutstandingLedger, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enmReport));
                }
                else
                {
                    if (int.Parse(txtSlab1.Text) > int.Parse(txtSlab2.Text))
                        sMessage = "Slab 2 value should be greater than Slab 1 value";
                    if (int.Parse(txtSlab2.Text) > int.Parse(txtSlab3.Text))
                        sMessage = "Slab 3 value should be greater than Slab 2 value";
                    if (int.Parse(txtSlab3.Text) > int.Parse(txtSlab4.Text))
                        sMessage = "Slab 4 value should be greater than Slab 3 value";
                    if (int.Parse(txtSlab4.Text) > int.Parse(txtSlab5.Text))
                        sMessage = "Slab 5 value should be greater than Slab 4 value";
                    MessageBox.Show(sMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                gbl_dts_bssOutstandingLedger.Clear();
                glb_dtsReportExport.Clear();
            }
            //    }
            //    else
            //        MessageBox.Show("Report not found");
            //}
        }

        private string CustomerOutstandings_ByCustomer(bool isSalesRepWise, bool isInvoceWise)
        {
            string sEmpID = "", sEmpName = "", sRemark = "", sRemark2 = "", sFilter = "", sCustomerName = "";
            gbl_dts_bssOutstandingLedger.OutstandingTransection.Clear();
            decimal dCreditPeriod = 0, dCreditLimit = 0;
            //Invoice

            #region invoice
            List<tbl_sasInvoice> oDetails = tbl_sasInvoice.SelectAll().Where(p => p.Invoice_ID != "default" && !p.IsDeleted && !p.IsSeattled && p.GrandTotal > 0 && (p.GrandTotal - p.SeattleAmount) > 0).ToList();
            foreach (tbl_sasInvoice oDetail in oDetails)
            {
                string temp = oDetail.Invoice_ID;
                if (oDetail != null)
                {
                    tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oDetail.Customer_ID);

                    #region Filters
                    if (bCustomerClassSelected && oCustomer != null)
                        if (oCustomer.CustomerClass_ID != txtCustomerClassID.Tag.ToString())
                            continue;

                    if (bCustomerTypeSelected && oCustomer != null)
                        if (oCustomer.CustomerType_ID != txtCustomerTypeID.Tag.ToString())
                            continue;

                    if (bCustomerCategorySelected && oCustomer != null)
                        if (oCustomer.CustomerCategory_ID != txtCategoryID.Tag.ToString())
                            continue;

                    if (bCustomerSelected)
                        if (oDetail.Customer_ID != txtCustomer.Tag.ToString().Trim())
                            continue;
                    #endregion

                    sEmpID = ""; sEmpName = ""; sRemark = ""; sCustomerName = ""; sRemark2 = "";

                    if (oCustomer != null && oCustomer.Customer_ID != "default")
                    {
                        if (txtSalesRep.Tag != null)
                            if (oCustomer.SalesRep_ID != txtSalesRep.Tag.ToString())
                                continue;

                        sCustomerName = oCustomer.CustomerName;
                        if (chkUseCustomerMastorSaleRep.Checked || oDetail.OrderRefNo_ID == "default")
                        {
                            sEmpID = oCustomer.SalesRep_ID;
                            sEmpName = clsGenaralName.getName_SalesRep(oCustomer.SalesRep_ID);
                        }
                        else
                            clsCommon.getEmployeeCodeAndName_ByRefereceNo(oDetail.OrderRefNo_ID, ref sEmpID, ref sEmpName);
                    }
                    tbl_genCustomerFinance oCustomerF = tbl_genCustomerFinance.Select(oDetail.Customer_ID);
                    if (oCustomerF != null && oCustomerF.Customer_ID != "default")
                    {
                        dCreditPeriod = oCustomerF.CreditPeriod;
                        dCreditLimit = oCustomerF.CreditLimit;
                    }

                    #region Filters
                    if (bSelesRepSelected)
                        if (sEmpID != txtSalesRep.Tag.ToString().Trim())
                            continue;
                    #endregion

                    if (!oDetail.IsOpeningBalance && !oDetail.IsReturnedCheque && !oDetail.IsDebitNote) //OutstandingLedger_Invoice
                        sRemark = "INVOICED For <" + oDetail.DeliveryOrder_ID + ">";
                    else if (oDetail.IsOpeningBalance && !oDetail.IsReturnedCheque && !oDetail.IsDebitNote) //OutstandingLedger_OpeningBalance
                        sRemark = "Opening Balance";
                    else if (!oDetail.IsOpeningBalance && oDetail.IsReturnedCheque && !oDetail.IsDebitNote) //OutstandingLedger_ReturnedCheque
                    {
                        tbl_bpsChequeRegister oCRDetail = tbl_bpsChequeRegister.Select(oDetail.ChequeRegister_ID);
                        if (oCRDetail != null)
                        {
                            string sInvoiceID = "";
                            tbl_bpsReceipt oRct = tbl_bpsReceipt.Select(oCRDetail.Receipt_ID);
                            if (oRct != null)
                            {
                                foreach (tbl_bpsReceipt_Invoice oReIn in tbl_bpsReceipt_Invoice.SelectAllByReceipt_ID(oCRDetail.Receipt_ID))
                                    sInvoiceID += oReIn.Invoice_ID + " | ";
                            }

                            try
                            {
                                sRemark = "Debit Note For RTN CHQ <" + oCRDetail.ChequeNumber + ">" + Environment.NewLine + "Rcpt# <" + oCRDetail.Receipt_ID + ">" + Environment.NewLine + "Inv# <" + sInvoiceID.Remove(sInvoiceID.Length - 3, 3) + ">";
                            }
                            catch (Exception)
                            {

                            }
                        }
                    }
                    if (!oDetail.IsOpeningBalance && !oDetail.IsReturnedCheque && oDetail.IsDebitNote) // OutstandingLedger_DebitNote
                        sRemark = "Debit Note";

                    #region For Remove Details from Remark
                    //For Serandib Report only
                    int iCount = sRemark.IndexOf("<");
                    if (iCount != -1)
                    {
                        sRemark2 = sRemark.Substring(0, iCount--);
                        sRemark2 = sRemark2.Replace("For", "");
                    }
                    else
                        sRemark2 = sRemark;

                    #endregion

                    decimal dPendingAmouint = oDetail.GrandTotal - oDetail.SeattleAmount;
                    if (isInvoceWise)
                    {
                        string sPONo = "";
                        if (oDetail.Job_ID == "default" && oDetail.DeliveryOrder_ID != "default") //Direct Sales
                            sPONo = clsGenaralName.getName_OrderRefNo(oDetail.OrderRefNo_ID);
                        else if (oDetail.Quotation_ID != "default" && oDetail.DeliveryOrder_ID == "default") //Block Invoice
                            sPONo = clsGenaralName.getName_OrderRefNo(oDetail.OrderRefNo_ID);
                        else if (oDetail.Job_ID != "default" && oDetail.DeliveryOrder_ID != "default") //Normal Invoice
                            sPONo = clsHelpMethods_Local.GetPONoByProductionJobID(oDetail.Job_ID);

                        gbl_dts_bssOutstandingLedger.OutstandingTransection.AddOutstandingTransectionRow(oDetail.Invoice_ID, oDetail.InvoiceDate, oDetail.Customer_ID, oDetail.GrandTotal, dPendingAmouint, oDetail.IsDeleted,
                            sRemark, sRemark2, false, sCustomerName.Trim(), isSalesRepWise ? sEmpID : "", isSalesRepWise ? sEmpName : "", clsCommon.getDaysUptoDate(oDetail.InvoiceDate), false, dCreditPeriod, oDetail.DeliveryOrder_ID, sPONo, oDetail.Job_ID, "", dCreditLimit, clsGenaralName.getName_CurrencyCode(oDetail.Currency_ID), oDetail.CurrencyRate, false, oDetail.GrandTotal);
                    }
                    else
                        gbl_dts_bssOutstandingLedger.OutstandingTransection.AddOutstandingTransectionRow(oDetail.Invoice_ID, oDetail.InvoiceDate, oDetail.Customer_ID, oDetail.GrandTotal, dPendingAmouint, oDetail.IsDeleted,
                            sRemark, sRemark2, false, sCustomerName.Trim(), isSalesRepWise ? sEmpID : "", isSalesRepWise ? sEmpName : "", clsCommon.getDaysUptoDate(oDetail.InvoiceDate), false, dCreditPeriod, "", "", "", "", dCreditLimit, clsGenaralName.getName_CurrencyCode(oDetail.Currency_ID), oDetail.CurrencyRate, false, oDetail.GrandTotal);
                }
                clsHelpMethods_Local.startProgressBar(0, oDetails.Count + 2, 1, ProgressBar);
            }
            ProgressBar.Value = 0;
            #endregion

            #region Credit Note
            List<tbl_bpsCreditNote> objDetails = tbl_bpsCreditNote.SelectAll().Where(p => p.CreditNote_ID != "default" && !p.IsDeleted && !p.IsSeattled && p.TotalAmount > 0).ToList();
            foreach (tbl_bpsCreditNote oDetail in objDetails)
            {
                if (oDetail != null)
                {
                    sEmpID = ""; sEmpName = ""; sRemark = "Credit Note - Unsettled"; sCustomerName = "";

                    //#region Filters
                    //if (!CheckCustomerType_LocalExport(oDetail.Customer_ID))
                    //    continue;

                    //if (bCustomerSelected)
                    //    if (oDetail.Customer_ID != txtCustomer.Tag.ToString().Trim())
                    //        continue;
                    //#endregion
                    //tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oDetail.Customer_ID);

                    tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oDetail.Customer_ID);

                    #region Filters
                    if (bCustomerClassSelected && oCustomer != null)
                        if (oCustomer.CustomerClass_ID != txtCustomerClassID.Tag.ToString())
                            continue;

                    if (bCustomerTypeSelected && oCustomer != null)
                        if (oCustomer.CustomerType_ID != txtCustomerTypeID.Tag.ToString())
                            continue;

                    if (bCustomerCategorySelected && oCustomer != null)
                        if (oCustomer.CustomerCategory_ID != txtCategoryID.Tag.ToString())
                            continue;

                    if (bCustomerSelected)
                        if (oDetail.Customer_ID != txtCustomer.Tag.ToString().Trim())
                            continue;
                    #endregion

                    if (oCustomer != null && oCustomer.Customer_ID != "default")
                    {
                        sCustomerName = oCustomer.CustomerName;
                        if (chkUseCustomerMastorSaleRep.Checked || oDetail.OrderRefNo_ID == "default")
                        {
                            sEmpID = oCustomer.SalesRep_ID;
                            sEmpName = clsGenaralName.getName_SalesRep(oCustomer.SalesRep_ID);
                        }
                        else
                            clsCommon.getEmployeeCodeAndName_ByRefereceNo(oDetail.OrderRefNo_ID, ref sEmpID, ref sEmpName);
                    }

                    #region Filters
                    if (bSelesRepSelected)
                        if (sEmpID != txtSalesRep.Tag.ToString().Trim())
                            continue;
                    #endregion

                    tbl_genCustomerFinance oCustomerF = tbl_genCustomerFinance.Select(oDetail.Customer_ID);
                    if (oCustomerF != null && oCustomerF.Customer_ID != "default")
                    {
                        dCreditPeriod = oCustomerF.CreditPeriod;
                        dCreditLimit = oCustomerF.CreditLimit;
                    }
                    decimal dPendingAmouint = (oDetail.TotalAmount - oDetail.SeattleAmount) * -1;
                    gbl_dts_bssOutstandingLedger.OutstandingTransection.AddOutstandingTransectionRow(oDetail.CreditNote_ID, oDetail.CreditNoteDate, oDetail.Customer_ID, oDetail.TotalAmount, dPendingAmouint, oDetail.IsDeleted,
                        sRemark, sRemark2, true, sCustomerName, isSalesRepWise ? sEmpID : "", isSalesRepWise ? sEmpName : "", clsCommon.getDaysUptoDate(oDetail.CreditNoteDate), false, dCreditPeriod, "", "", "", "", dCreditLimit, clsGenaralName.getName_CurrencyCode(oDetail.Currency_ID), oDetail.CurrencyRate, false, oDetail.TotalAmount);
                }
                clsHelpMethods_Local.startProgressBar(0, objDetails.Count + 2, 1, ProgressBar);
            }
            ProgressBar.Value = 0;
            #endregion

            #region Cheque Register
            List<tbl_bpsChequeRegister> chkDetails = tbl_bpsChequeRegister.SelectAll().Where(p => p.ChequeRegister_ID != "default" && !p.IsDeleted && !p.IsSetteled && (p.Amount - p.SetteledAmount) > 0 && p.Customer_ID != "default").ToList();
            foreach (tbl_bpsChequeRegister oDetail in chkDetails)
            {
                if (oDetail != null)
                {
                    sEmpID = ""; sEmpName = ""; sRemark = "CHQ Recvd. - Unsettled"; sCustomerName = "";

                    //#region Filters
                    //if (!CheckCustomerType_LocalExport(oDetail.Customer_ID))
                    //    continue;

                    //if (bCustomerSelected)
                    //    if (oDetail.Customer_ID != txtCustomer.Tag.ToString().Trim())
                    //        continue;
                    //#endregion
                    //tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oDetail.Customer_ID);

                    tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oDetail.Customer_ID);

                    #region Filters
                    if (bCustomerClassSelected && oCustomer != null)
                        if (oCustomer.CustomerClass_ID != txtCustomerClassID.Tag.ToString())
                            continue;

                    if (bCustomerTypeSelected && oCustomer != null)
                        if (oCustomer.CustomerType_ID != txtCustomerTypeID.Tag.ToString())
                            continue;

                    if (bCustomerCategorySelected && oCustomer != null)
                        if (oCustomer.CustomerCategory_ID != txtCategoryID.Tag.ToString())
                            continue;

                    if (bCustomerSelected)
                        if (oDetail.Customer_ID != txtCustomer.Tag.ToString().Trim())
                            continue;
                    #endregion

                    if (oCustomer != null && oCustomer.Customer_ID != "default")
                    {
                        sCustomerName = oCustomer.CustomerName;
                        if (chkUseCustomerMastorSaleRep.Checked || oDetail.OrderRefNo_ID == "default")
                        {
                            sEmpID = oCustomer.SalesRep_ID;
                            sEmpName = clsGenaralName.getName_SalesRep(oCustomer.SalesRep_ID);
                        }
                        else
                            clsCommon.getEmployeeCodeAndName_ByRefereceNo(oDetail.OrderRefNo_ID, ref sEmpID, ref sEmpName);
                    }

                    #region Filters
                    if (bSelesRepSelected)
                        if (sEmpID != txtSalesRep.Tag.ToString().Trim())
                            continue;
                    #endregion

                    tbl_genCustomerFinance oCustomerF = tbl_genCustomerFinance.Select(oDetail.Customer_ID);
                    if (oCustomerF != null && oCustomerF.Customer_ID != "default")
                    {
                        dCreditPeriod = oCustomerF.CreditPeriod;
                        dCreditLimit = oCustomerF.CreditLimit;
                    }
                    decimal dPendingAmouint = (oDetail.Amount - oDetail.SetteledAmount) * -1;

                    tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(oDetail.Receipt_ID);
                    if (oReceipt != null && oReceipt.Receipt_ID != "default")
                    {
                        gbl_dts_bssOutstandingLedger.OutstandingTransection.AddOutstandingTransectionRow(oDetail.Receipt_ID, oDetail.DateRegister, oDetail.Customer_ID, oDetail.Amount - oDetail.SetteledAmount, dPendingAmouint, oDetail.IsDeleted,
                            sRemark, sRemark2, true, sCustomerName, isSalesRepWise ? sEmpID : "", isSalesRepWise ? sEmpName : "", clsCommon.getDaysUptoDate(oDetail.DateRegister), false, dCreditPeriod, "", "", "", "", dCreditLimit, clsGenaralName.getName_CurrencyCode(oReceipt.Currency_ID), oReceipt.CurrencyRate, oReceipt.IsAdvance, oDetail.Amount - oDetail.SetteledAmount);
                    }
                }
                clsHelpMethods_Local.startProgressBar(0, chkDetails.Count + 2, 1, ProgressBar);
            }
            ProgressBar.Value = 0;
            #endregion

            #region Reciept
            List<tbl_bpsReceipt> recDetails = tbl_bpsReceipt.SelectAll().Where(p => p.Receipt_ID != "default" && !p.IsDeleted && !p.IsSeattled && p.CashAmount > 0).ToList();
            foreach (tbl_bpsReceipt oDetail in recDetails)
            {
                if (oDetail != null)
                {
                    sEmpID = ""; sEmpName = ""; sRemark = "CASH Recvd. - Unsettled"; sCustomerName = "";

                    //#region Filters

                    //if (!CheckCustomerType_LocalExport(oDetail.Customer_ID))
                    //    continue;

                    //if (bCustomerSelected)
                    //    if (oDetail.Customer_ID != txtCustomer.Tag.ToString().Trim())
                    //        continue;
                    //#endregion
                    //tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oDetail.Customer_ID);

                    tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oDetail.Customer_ID);

                    #region Filters
                    if (bCustomerClassSelected && oCustomer != null)
                        if (oCustomer.CustomerClass_ID != txtCustomerClassID.Tag.ToString())
                            continue;

                    if (bCustomerTypeSelected && oCustomer != null)
                        if (oCustomer.CustomerType_ID != txtCustomerTypeID.Tag.ToString())
                            continue;

                    if (bCustomerCategorySelected && oCustomer != null)
                        if (oCustomer.CustomerCategory_ID != txtCategoryID.Tag.ToString())
                            continue;

                    if (bCustomerSelected)
                        if (oDetail.Customer_ID != txtCustomer.Tag.ToString().Trim())
                            continue;
                    #endregion

                    if (oCustomer != null && oCustomer.Customer_ID != "default")
                    {
                        sCustomerName = oCustomer.CustomerName;
                        if (chkUseCustomerMastorSaleRep.Checked || oDetail.OrderRefNo_ID == "default")
                        {
                            sEmpID = oCustomer.SalesRep_ID;
                            sEmpName = clsGenaralName.getName_SalesRep(oCustomer.SalesRep_ID);
                        }
                        else
                            clsCommon.getEmployeeCodeAndName_ByRefereceNo(oDetail.OrderRefNo_ID, ref sEmpID, ref sEmpName);
                    }

                    #region Filters
                    if (bSelesRepSelected)
                        if (sEmpID != txtSalesRep.Tag.ToString().Trim())
                            continue;
                    #endregion

                    tbl_genCustomerFinance oCustomerF = tbl_genCustomerFinance.Select(oDetail.Customer_ID);
                    if (oCustomerF != null && oCustomerF.Customer_ID != "default")
                    {
                        dCreditPeriod = oCustomerF.CreditPeriod;
                        dCreditLimit = oCustomerF.CreditLimit;
                    }
                    decimal dPendingAmouint = (oDetail.CashAmount - oDetail.SeattleAmount) * -1;

                    gbl_dts_bssOutstandingLedger.OutstandingTransection.AddOutstandingTransectionRow(oDetail.Receipt_ID, oDetail.ReceiptDate, oDetail.Customer_ID, oDetail.CashAmount, dPendingAmouint, oDetail.IsDeleted,
                        sRemark, sRemark2, true, sCustomerName, isSalesRepWise ? sEmpID : "", isSalesRepWise ? sEmpName : "", clsCommon.getDaysUptoDate(oDetail.ReceiptDate), false, dCreditPeriod, "", "", "", "", dCreditLimit, clsGenaralName.getName_CurrencyCode(oDetail.Currency_ID), oDetail.CurrencyRate, oDetail.IsAdvance ? true : false, oDetail.CashAmount);
                }
                clsHelpMethods_Local.startProgressBar(0, recDetails.Count + 2, 1, ProgressBar);
            }
            ProgressBar.Value = 0;
            #endregion

            #region Cheque Register ID
            if (Report != enum_ReportName.RG_OutstandingStatement)
            {
                List<tbl_bpsChequeRegister> regDetails = tbl_bpsChequeRegister.SelectAll().Where(p => p.ChequeRegister_ID != "default" && !p.IsDeleted && !p.IsReIssued && !p.IsDepositted && p.Amount > 0 && p.Customer_ID != "default").ToList();
                int i = 0;

                foreach (tbl_bpsChequeRegister oDetail in regDetails)
                {
                    i++;
                    if (oDetail != null)
                    {
                        sEmpID = ""; sEmpName = ""; sCustomerName = "";
                        sRemark = "Cheques In Hand  <" + clsFormatter.FormatDate_Short(oDetail.DateCheque) + ">";

                        //#region Filters
                        //if (!CheckCustomerType_LocalExport(oDetail.Customer_ID))
                        //    continue;

                        //if (bCustomerSelected)
                        //    if (oDetail.Customer_ID != txtCustomer.Tag.ToString().Trim())
                        //        continue;
                        //#endregion
                        //tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oDetail.Customer_ID);

                        tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oDetail.Customer_ID);

                        #region Filters
                        if (bCustomerClassSelected && oCustomer != null)
                            if (oCustomer.CustomerClass_ID != txtCustomerClassID.Tag.ToString())
                                continue;

                        if (bCustomerTypeSelected && oCustomer != null)
                            if (oCustomer.CustomerType_ID != txtCustomerTypeID.Tag.ToString())
                                continue;

                        if (bCustomerCategorySelected && oCustomer != null)
                            if (oCustomer.CustomerCategory_ID != txtCategoryID.Tag.ToString())
                                continue;

                        if (bCustomerSelected)
                            if (oDetail.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                continue;
                        #endregion

                        if (oCustomer != null && oCustomer.Customer_ID != "default")
                        {
                            sCustomerName = oCustomer.CustomerName;
                            if (chkUseCustomerMastorSaleRep.Checked || oDetail.OrderRefNo_ID == "default")
                            {
                                sEmpID = oCustomer.SalesRep_ID;
                                sEmpName = clsGenaralName.getName_SalesRep(oCustomer.SalesRep_ID);
                            }
                            else
                                clsCommon.getEmployeeCodeAndName_ByRefereceNo(oDetail.OrderRefNo_ID, ref sEmpID, ref sEmpName);
                        }

                        #region Filters
                        if (bSelesRepSelected)
                            if (sEmpID != txtSalesRep.Tag.ToString().Trim())
                                continue;
                        #endregion

                        tbl_genCustomerFinance oCustomerF = tbl_genCustomerFinance.Select(oDetail.Customer_ID);
                        if (oCustomerF != null && oCustomerF.Customer_ID != "default")
                        {
                            dCreditPeriod = oCustomerF.CreditPeriod;
                            dCreditLimit = oCustomerF.CreditLimit;
                        }
                        decimal dPendingAmouint = oDetail.Amount;
                        if (!isInvoceWise)
                        {
                            tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(oDetail.Receipt_ID);
                            if (oReceipt != null && oReceipt.Receipt_ID != "default")
                            {
                                gbl_dts_bssOutstandingLedger.OutstandingTransection.AddOutstandingTransectionRow(oDetail.ChequeRegister_ID, oDetail.DateRegister, oDetail.Customer_ID, oDetail.Amount, dPendingAmouint, oDetail.IsDeleted,
                                    sRemark, sRemark2, true, sCustomerName, isSalesRepWise ? sEmpID : "", isSalesRepWise ? sEmpName : "", clsCommon.getDaysUptoDate(oDetail.DateRegister), true, dCreditPeriod, "", "", "", "", dCreditLimit, clsGenaralName.getName_CurrencyCode(oReceipt.Currency_ID), oReceipt.CurrencyRate, false, oDetail.Amount);
                            }
                        }
                        else
                        {
                            foreach (tbl_sasInvoice_Sattled oInvoiceSettled in tbl_sasInvoice_Sattled.SelectAllByChequeRegister_ID(oDetail.ChequeRegister_ID))
                            {
                                tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(oInvoiceSettled.Invoice_ID);
                                if (oInvoice != null && oInvoice.Invoice_ID != "default")
                                {
                                    string sPONo = "";
                                    if (oInvoice.Job_ID == "default" && oInvoice.DeliveryOrder_ID != "default") //Direct Sales
                                        sPONo = clsGenaralName.getName_OrderRefNo(oInvoice.OrderRefNo_ID);
                                    else if (oInvoice.Quotation_ID != "default" && oInvoice.DeliveryOrder_ID == "default") //Block Invoice
                                        sPONo = clsGenaralName.getName_OrderRefNo(oInvoice.OrderRefNo_ID);
                                    else if (oInvoice.Job_ID != "default" && oInvoice.DeliveryOrder_ID != "default") //Normal Invoice
                                        sPONo = clsHelpMethods_Local.GetPONoByProductionJobID(oInvoice.Job_ID);
                                    decimal dPendingAmountInvoice = oInvoice.GrandTotal - oInvoice.SeattleAmount;

                                    gbl_dts_bssOutstandingLedger.OutstandingTransection.AddOutstandingTransectionRow(oInvoice.Invoice_ID, oInvoice.InvoiceDate, oDetail.Customer_ID, oInvoiceSettled.SattledAmount, dPendingAmountInvoice, oDetail.IsDeleted,
                                        sRemark, sRemark2, true, sCustomerName, isSalesRepWise ? sEmpID : "", isSalesRepWise ? sEmpName : "", clsCommon.getDaysUptoDate(oInvoice.InvoiceDate), true, dCreditPeriod, oInvoice.DeliveryOrder_ID, sPONo, oInvoice.Job_ID, oDetail.Receipt_ID, dCreditLimit, clsGenaralName.getName_CurrencyCode(oInvoice.Currency_ID), oInvoice.CurrencyRate, false, oInvoice.GrandTotal);
                                }
                            }
                        }
                    }
                    clsHelpMethods_Local.startProgressBar(0, regDetails.Count + 2, 1, ProgressBar);
                }
                ProgressBar.Value = 0;
            }
            #endregion

            if (bCustomerClassSelected)
                sFilter += "  Class: " + txtCustomerClassID.Text.Trim();
            if (bCustomerTypeSelected)
                sFilter += "  Type: " + txtCustomerTypeID.Text.Trim();
            if (bCustomerCategorySelected)
                sFilter += "  Category: " + txtCategoryID.Text.Trim();
            if (bCustomerSelected)
                sFilter += "  Customer Name: " + txtCustomer.Text.Trim();
            if (bSelesRepSelected)
                sFilter += "  Salesman Name: " + txtSalesRep.Text.Trim();


            return sFilter;
        }


        private void genCustomerOustanding_Fill()
        {
            gbl_dts_bssOutstandingLedger.genCustomerFinance.Clear();
            foreach (tbl_genCustomerFinance oDetail in tbl_genCustomerFinance.SelectAll().Where(p => p.Customer_ID != "default"))
            {
                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oDetail.Customer_ID);
                if (oCustomer != null)
                    gbl_dts_bssOutstandingLedger.genCustomerFinance.AddgenCustomerFinanceRow(oDetail.Customer_ID, oCustomer.CustomerName, oCustomer.AddressRegister, oCustomer.AddressDelivery, oDetail.DepositAmount, oDetail.CreditPeriod, oDetail.CreditLimit, oCustomer.SalesRep_ID, clsGenaralName.getName_SalesRep(oCustomer.SalesRep_ID), "", -1, "", "");
            }
        }
        #endregion

        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearField();
            //setEnableDisableConctrol();
        }
        #endregion

        #region ClearField
        private void clearField()
        {
            txtCustomerClassID.Tag = null;
            txtCustomerTypeID.Tag = null;
            txtCategoryID.Tag = null;
            txtCustomer.Tag = null;
            txtSalesRep.Tag = null;

            txtCustomerClassID.Text = "<All Classes>";
            txtCustomerTypeID.Text = "<All Types>";
            txtCategoryID.Text = "<All Categories>";
            txtSalesRep.Text = "<All Salesman>";
            txtCustomer.Text = "<All Customer>";

            txtSlab1.Text = "30";
            txtSlab2.Text = "60";
            txtSlab3.Text = "90";
            txtSlab4.Text = "120";
            txtSlab5.Text = "150";

            //grpAgeingSlabs.Visible = false;

            clsCommon.SetEnableDisable_NormalTextbox(txtSlab1, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtSlab2, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtSlab3, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtSlab4, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtSlab5, true);

            clsCommon.SetVisibility_Panel(pnlSalesman, false);
            clsCommon.SetVisibility_Panel(pnlCusClass, false);
            clsCommon.SetVisibility_Panel(pnlCusType, false);
            clsCommon.SetVisibility_Panel(pnlCategory, false);
            clsCommon.SetVisibility_Panel(pnlCustomer, false);

            clsCommon.SetVisibility_Panel(pnlDateFrom, false);
            clsCommon.SetVisibility_Panel(pnlDateAsAt, true);
            clsCommon.SetVisibility_Panel(pnlUseCusMasterSalesRep, false);
            clsCommon.SetVisibility_Panel(pnlAgingSlab, false);
            chkUseCustomerMastorSaleRep.Checked = true;

            chkShowAll.Checked = false;

            clsHelpMethods_Local.startProgressBar(0, 0, 0, ProgressBar);
        }
        #endregion

        #region Print Method
        //private void print(string path, string sReportTitle, string sFormula)
        //{
        //    try
        //    {
        //        Cursor = Cursors.WaitCursor;
        //        string s_Path = "", sHeaderTitle = "Standed Reports";
        //        ReportDocument RD = new ReportDocument();
        //        s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");

        //        //validate single customer ledger
        //        //#region Validate Single Customer Ledger
        //        //if ((txtCustomer.Tag != null && txtCustomer.Tag.ToString().Trim().Length > 0) && (rdoCustomerHistoryLedger.Checked))
        //        //    path = "\\reports\\SAS\\Finance\\rpt_sas_Ledger_SingleCustomer.rpt";
        //        //#endregion
        //        s_Path += path;

        //        frm_ReportViewer viewer = new frm_ReportViewer();
        //        RD.Load(s_Path);
        //        clsSecurity.LogonServer(ref RD);
        //        RD.Refresh();

        //        RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
        //        RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
        //        RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"));
        //        RD.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
        //        RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
        //        RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
        //        RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
        //        RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
        //        RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

        //        //validate filter formula
        //        #region Validate Filter Formula
        //        if (rdoCustomerOutstandingsSummery_Customer.Checked || rdoCustomerOutstandingsDetail_Customer.Checked || rdoCustomerOutstanding_Detail_Invoice.Checked)
        //        {
        //            string sFilter = "";
        //            bool bHasItem = false;
        //            if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Length > 0)
        //            {
        //                sFilter += "Cutomer Name : " + txtCustomer.Text.Trim();
        //                bHasItem = true;
        //            }
        //            if (txtSalesRep.Tag != null && txtSalesRep.Tag.ToString().Length > 0)
        //            {
        //                if (bHasItem)
        //                    sFilter += " / ";
        //                sFilter += "Sales Rep Name : " + txtSalesRep.Text.Trim();
        //                bHasItem = true;
        //            }

        //            RD.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sFilter);
        //        }
        //        #endregion

        //        //validate single customer ledger
        //        //#region Validate Single Customer Ledger
        //        //if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Trim().Length > 0 && (rdoCustomerHistoryLedger.Checked))
        //        //{
        //        //    decimal dBroughtForwardBalance = 0;
        //        //    List<vw_rpt_sasLedger> ledgers = vw_rpt_sasLedger.SelectAllByCustomer_ID(txtCustomer.Tag.ToString());
        //        //    foreach (vw_rpt_sasLedger ledger in ledgers)
        //        //    {
        //        //        if (ledger.TransactionDate.Date < dtpFrom.Value.Date)
        //        //        {
        //        //            if (ledger.TransactionCredit)
        //        //                dBroughtForwardBalance += ledger.GrandTotal;
        //        //            else
        //        //                dBroughtForwardBalance -= ledger.GrandTotal;
        //        //        }
        //        //    }
        //        //    RD.DataDefinition.FormulaFields["BroughtForwardAmount"].Text = dBroughtForwardBalance.ToString();// clsCommon.fncsetstring(500);
        //        //    RD.DataDefinition.FormulaFields["BroughtForwardDate"].Text = clsCommon.fncsetstring(dtpFrom.Value.ToShortDateString());
        //        //    RD.DataDefinition.FormulaFields["CarriedForwardDate"].Text = clsCommon.fncsetstring(dtpTo.Value.ToShortDateString());
        //        //    RD.DataDefinition.FormulaFields["cAddress"].Text = clsCommon.RemoveNewLinestring(clsCommon.fncsetstring(clsGenaralName.getName_CustomerRegisterAddress(txtCustomer.Tag.ToString())));

        //        //}
        //        //#endregion

        //        if (rdopOutstandingStatement.Checked)
        //        {
        //            RD.DataDefinition.FormulaFields["ContactTel"].Text = clsCommon.fncsetstring(clsConfig.sCmp_qContactTelephone);
        //            RD.DataDefinition.FormulaFields["ContactEmail"].Text = clsCommon.fncsetstring(clsConfig.sCmp_qContactEmail);
        //        }

        //        viewer.crystalReportViewer1.ReportSource = RD;
        //        viewer.crystalReportViewer1.SelectionFormula = sFormula;
        //        viewer.crystalReportViewer1.Visible = true;
        //        viewer.crystalReportViewer1.DisplayToolbar = true;
        //        viewer.crystalReportViewer1.CloseView(false);
        //        viewer.WindowState = FormWindowState.Maximized;
        //        viewer.ShowDialog();

        //        RD.Close();
        //        RD.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        SEACCException.Show(ex);
        //    }
        //    finally
        //    {
        //        Cursor = Cursors.Default;
        //    }
        //}

        private void print(string path, string sReportTitle, DataSet ojbDataSetTable, string sReportFilter)
        {
            try
            {
                //Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Standed Reports";
                ReportDocument objRpt = new ReportDocument();

                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(ojbDataSetTable); //(glbDtsBills);

                objRpt.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From :" + dtpFrom.Value.ToString("dd MMM yyyy") + " To :" + dtpTo.Value.ToString("dd MMM yyyy"));
                objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                objRpt.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                try
                {
                    objRpt.DataDefinition.FormulaFields["ToDate"].Text = clsCommon.fncsetstring("AS AT " + dtpTo.Value.ToString("dd MMM yyyy"));
                    objRpt.DataDefinition.FormulaFields["isDetail"].Text = clsCommon.fncsetstring(isDetailReport ? "1" : "0");
                }
                catch (Exception) { }

                if (bCustomerSelected)
                    sReportFilter += " Customer Name : " + txtCustomer.Text.Trim();
                if (bSelesRepSelected)
                    sReportFilter += " Salesman Name : " + txtSalesRep.Text.Trim();
                else
                    sReportFilter += (sReportFilter.Length > 0) ? "" : " - ";

                objRpt.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sReportFilter);

                if (Report == enum_ReportName.RG_OutstandingStatement)
                {
                    objRpt.DataDefinition.FormulaFields["ContactTel"].Text = clsCommon.fncsetstring(clsConfig.sCmp_qContactTelephone);
                    objRpt.DataDefinition.FormulaFields["ContactEmail"].Text = clsCommon.fncsetstring(clsConfig.sCmp_qContactEmail);
                }

                frm_ReportViewer ReportViewer = new frm_ReportViewer();
                ReportViewer.crystalReportViewer1.ReportSource = objRpt;
                ReportViewer.crystalReportViewer1.Refresh();
                ReportViewer.crystalReportViewer1.DisplayToolbar = true;
                ReportViewer.crystalReportViewer1.CloseView(false);
                ReportViewer.WindowState = FormWindowState.Maximized;
                ReportViewer.ShowDialog();

                objRpt.Close();
                objRpt.Dispose();
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

        private void txtSalesRep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtSalesRep_DoubleClick(null, null);
        }
        private void frm_rpt_ChequeManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        #endregion

        #region Events DoublClick
        private void txtSalesRep_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesRepID();
        }
        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
        }
        private void txtCategoryID_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerCategoryID();
        }

        private void txtCustomerTypeID_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerTypeID();
        }

        private void txtCustomerClassID_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerClassID();
        }
        #endregion

        #region Search Methods
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
        private void Search_CustomerID()
        {
            //Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_CustomerMaster(true);
            //frmhelpsearch.ShowDialog();

            //if (frmSearchMaster.s_SearchID.Length > 0)
            //{
            //    if (frmSearchMaster.s_SearchText.Length > 0)
            //        txtCustomer.Text = frmSearchMaster.s_SearchText;
            //    if (frmSearchMaster.s_SearchID.Length > 0)
            //    {
            //string sCus_ID = frmSearchMaster.s_SearchID;

            clsSearch.Search_MasterCustomer(ref txtCustomer, chkShowAll.Checked);

            if (txtCustomer.Tag != null)
            {
                //txtCustomer.Tag = sCus_ID;
                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(txtCustomer.Tag.ToString());
                if (oCustomer != null)
                {
                    txtCustomerClassID.Tag = oCustomer.CustomerClass_ID;
                    txtCustomerTypeID.Tag = oCustomer.CustomerType_ID;
                    txtCategoryID.Tag = oCustomer.CustomerCategory_ID;

                    txtCustomerClassID.Text = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID);
                    txtCustomerTypeID.Text = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID);
                    txtCategoryID.Text = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID);
                }
                //}
            }
            //}
        }
        private void Search_CustomerClassID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_CustomerClass();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtCustomerClassID.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                    txtCustomerClassID.Tag = frmSearchMaster.s_SearchID;
            }
        }

        private void Search_CustomerTypeID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_CustomerType();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtCustomerTypeID.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                    txtCustomerTypeID.Tag = frmSearchMaster.s_SearchID;
            }
        }

        private void Search_CustomerCategoryID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_CustomerCategory();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtCategoryID.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                    txtCategoryID.Tag = frmSearchMaster.s_SearchID;
            }
        }

        #endregion

        #region Set Enable/Disable Controls
        private void setEnableDisableConctrol(int iReportID)
        {
            clearField();

            if (iReportID == (int)enum_ReportName.RG_Outstanding_Customer_Wise_Summary || iReportID == (int)enum_ReportName.RG_Outstanding_Customer_Wise_Detail ||
                iReportID == (int)enum_ReportName.RG_Outstanding_Invoice_wise_Summary || iReportID == (int)enum_ReportName.RG_Outstanding_Invoice_wise_Detail ||
                iReportID == (int)enum_ReportName.RG_OutstandingStatement_Salesman_wise || iReportID == (int)enum_ReportName.RG_Outstanding_Salesman_wise_Detail_TW)
            {
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlCusClass, true);
                clsCommon.SetVisibility_Panel(pnlCusType, true);
                clsCommon.SetVisibility_Panel(pnlCategory, true);
                clsCommon.SetVisibility_Panel(pnlCustomer, true);

                clsCommon.SetVisibility_Panel(pnlUseCusMasterSalesRep, true);

                //clsCommon.SetEnableDisable_NormalRadioButton(rdoLocal, true);
                //clsCommon.SetEnableDisable_NormalRadioButton(rdoExport, true);
                //clsCommon.SetEnableDisable_NormalRadioButton(rdoAll, true);
                //clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);

                //dtpFrom.Visible = false;
                //lblFromDate.Visible = false;
                //clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
                //clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, false);
            }
            else if (iReportID == (int)enum_ReportName.RG_Outstanding_Salesman_wise_Summary || iReportID == (int)enum_ReportName.RG_Outstanding_Salesman_wise_Detail)
            {
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlUseCusMasterSalesRep, true);

                //clsCommon.SetEnableDisable_NormalRadioButton(rdoLocal, true);
                //clsCommon.SetEnableDisable_NormalRadioButton(rdoExport, true);
                //clsCommon.SetEnableDisable_NormalRadioButton(rdoAll, true);
                //clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);

                //dtpFrom.Visible = false;
                //lblFromDate.Visible = false;
                //clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
                //clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, false);
            }
            else if (iReportID == (int)enum_ReportName.RG_Age_Analysis_Customer_wise || iReportID == (int)enum_ReportName.RG_Age_Analysis_Salesman_wise)
            {
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlCusClass, true);
                clsCommon.SetVisibility_Panel(pnlCusType, true);
                clsCommon.SetVisibility_Panel(pnlCategory, true);
                clsCommon.SetVisibility_Panel(pnlCustomer, true);

                clsCommon.SetVisibility_Panel(pnlUseCusMasterSalesRep, true);
                clsCommon.SetVisibility_Panel(pnlAgingSlab, true);

                //clsCommon.SetEnableDisable_NormalRadioButton(rdoLocal, true);
                //clsCommon.SetEnableDisable_NormalRadioButton(rdoExport, true);
                //clsCommon.SetEnableDisable_NormalRadioButton(rdoAll, true);
                //clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
                //dtpFrom.Visible = false;
                //lblFromDate.Visible = false;
                //clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
                //clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, false);

                //grpAgeingSlabs.Visible = true;

            }
            else if (iReportID == (int)enum_ReportName.RG_OutstandingStatement)
            {
                clsCommon.SetVisibility_Panel(pnlCusClass, true);
                clsCommon.SetVisibility_Panel(pnlCusType, true);
                clsCommon.SetVisibility_Panel(pnlCategory, true);
                clsCommon.SetVisibility_Panel(pnlCustomer, true);

                clsCommon.SetVisibility_Panel(pnlUseCusMasterSalesRep, true);

                //clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);

                //dtpFrom.Visible = false;
                //lblFromDate.Visible = false;
                //clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
                //clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, false);
            }
            else if (iReportID == (int)enum_ReportName.ST_Outstanding_Analysis)
            {
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlCusClass, true);
                clsCommon.SetVisibility_Panel(pnlCusType, true);
                clsCommon.SetVisibility_Panel(pnlCategory, true);
                clsCommon.SetVisibility_Panel(pnlCustomer, true);

                clsCommon.SetVisibility_Panel(pnlDateFrom, true);

                //clsCommon.SetEnableDisable_NormalRadioButton(rdoLocal, false);
                //clsCommon.SetEnableDisable_NormalRadioButton(rdoExport, false);
                //clsCommon.SetEnableDisable_NormalRadioButton(rdoAll, false);
                //clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, false);
                //chkUseCustomerMastorSaleRep.Checked = true;

                //dtpFrom.Visible = true;
                //lblFromDate.Visible = true;
                //clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
                //clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
            }

            #region To Be Delete
            //if (rdoSalesCommissionSummary_DateWise.Checked)
            //{
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
            //    clsCommon.SetEnableDisable_NormalRadioButton(rdoLocal, false);
            //    clsCommon.SetEnableDisable_NormalRadioButton(rdoExport, false);
            //    clsCommon.SetEnableDisable_NormalRadioButton(rdoAll, false);
            //    clsCommon.SetEnableDisable_NormalCheckBox(chkAdvance, false);
            //    clsCommon.SetEnableDisable_NormalCheckBox(chkPartPayment, false);
            //    clsCommon.SetEnableDisable_NormalCheckBox(chkOverPayment, false);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpOverdueDate, false);
            //}
            //if (rdoAllocation.Checked)
            //{
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
            //    clsCommon.SetEnableDisable_NormalRadioButton(rdoLocal, false);
            //    clsCommon.SetEnableDisable_NormalRadioButton(rdoExport, false);
            //    clsCommon.SetEnableDisable_NormalRadioButton(rdoAll, false);
            //    clsCommon.SetEnableDisable_NormalCheckBox(chkAdvance, true);
            //    clsCommon.SetEnableDisable_NormalCheckBox(chkPartPayment, true);
            //    clsCommon.SetEnableDisable_NormalCheckBox(chkOverPayment, true);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
            //    clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
            //} 
            //else if (rdoCustomerOutstandingsLedger.Checked)
            //{
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRoute, true);
            //    clsCommon.SetEnableDisable_NormalLabel(lblRoute, true);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
            //    clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
            //    clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
            //    clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpOverdueDate, true);
            //}
            //else if (rdoCustomerHistoryLedger.Checked)
            //{
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRoute, true);
            //    clsCommon.SetEnableDisable_NormalLabel(lblRoute, true);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
            //    clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
            //    clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
            //    clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpOverdueDate, true);
            //}
            //else if (rdoInvoiceSettlementLedger.Checked)
            //{
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
            //    clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
            //    clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpOverdueDate, true);
            //}
            //else if (rdoReceiptSettlementLedger.Checked)
            //{
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
            //    clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
            // //   clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpOverdueDate, true);
            //}
            //else if (rdoSalesCommisionDetail.Checked)
            //{
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
            //    clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
            //    clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpOverdueDate, true);
            //}
            //else if (rdoSalesCommisionSummary.Checked)
            //{
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
            //    clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
            //    clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpOverdueDate, true);
            //}
            //else if (rdoOverPaymentListing.Checked || rdoAdvanceListing.Checked)
            //{
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
            //    clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);


            //}
            //else if (rdoSalesCommisionInvoicewise.Checked)
            //{
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesRep, true);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomer, true);
            //}
            //else if (rdoInsentive.Checked)
            //{
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
            //    clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
            //    clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpOverdueDate, false);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
            //}
            //else if (rdoSalescommissionStatement.Checked)
            //{
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRoute, false);
            //    clsCommon.SetEnableDisable_NormalLabel(lblRoute, false);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
            //    clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);
            //    clsCommon.SetEnableDisable_NormalRadioButton(rdoLocal, false);
            //    clsCommon.SetEnableDisable_NormalRadioButton(rdoExport, false);
            //    clsCommon.SetEnableDisable_NormalRadioButton(rdoAll, false);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
            //}
            #endregion
        }
        #endregion

        #region Events CheckedChange
        #region old
        //private void rdoRegisteredCheques_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoChequeToBeDeposited_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoReIssuedCheques_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoDeposittedCheques_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoReconciliatedCheques_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoChequeReturnedSummery_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoChequeRealizedSummary_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoChequeSummery_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoPendingChequeReconciliate_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoGroupOutstanding_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoDailySalesReport_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoConfirmedJobSummary_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoDailySalesReportSummary_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoClosedJobSummary_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoPendingCustomerOrderSummery_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoPendingCustomerOrderDetail_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoPendingInquiryOrderSummery_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoPendingInquiryOrderDetail_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoPendingInquiryItem_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoPendingOrderItem_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoPendingDeliveryItem_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoPendingDeliverySummary_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoPendingDeliveryDetail_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoInvoiceDetail_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoInvoiceSummary_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoSalseRepInvoiceWise_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoTownSummery_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoRouteTownDateWise_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoTownInvoiceDateWise_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoCustomerOutstandingsSummery_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoCustomerOutstandingsDetail_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoCustomerOutstandingsLedger_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoCustomerOutstandingsSummery_SalesRep_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoCustomerOutstandingsDetail_SalesRep_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdopCustomerOutstandingStatement_TW_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoCustomerOutstandingsDetail_Ageing_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoCustomerOutstandingsDetail_Ageing_SalesRep_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoCustomerOutstandings_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoCustomerOutstandingsSummery_CheckedChanged_1(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //} 
        #endregion

        private void txtSlab1_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowInteger(e);
        }

        private void txtSlab2_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowInteger(e);
        }

        private void txtSlab3_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowInteger(e);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSlab4_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowInteger(e);
        }

        private void txtSlab5_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowInteger(e);
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

        //private void rdopOutstandingStatement_Salesmanwise_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}

        //private void rdoOutstandingAnalysis_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}

        #region To Be Delete
        //private void rdoCustomerHistoryLedger_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoInvoiceSettlementLedger_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoSalesCommisionSummary_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoSalesCommisionDetail_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoReceiptSettlementLedger_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoAdvanceAllocation_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //} 
        //private void rdoOverPaymentListing_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoSalesCommisionInvoicewise_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoSalesCommissionSummary_DateWise_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoInsentive_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoSalescommissionStatement_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        #endregion

        #endregion

        private void Z2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void x1_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}

//private void print(string path, string sReportTitle, DataTable ojbDataSetTable, string sReportFilter)
//{
//    try
//    {
//        Cursor = Cursors.WaitCursor;
//        string s_Path = "", sHeaderTitle = "Standed Reports";
//        //   CrystalDecisions.CrystalReports.Engine.ReportDocument objRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
//        ReportDocument objRpt = new ReportDocument();

//        s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
//        s_Path += path;

//        objRpt.Load(s_Path);
//        objRpt.SetDataSource(ojbDataSetTable); //(glbDtsBills);

//        objRpt.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
//        objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
//        objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From :" + dtpFrom.Value.ToString("dd MMM yyyy") + "To :" + dtpTo.Value.ToString("dd MMM yyyy"));
//        objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
//        objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
//        objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
//        objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
//        objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
//        objRpt.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

//        if (bCustomerSelected)
//            sReportFilter = " Customer Name : " + txtCustomer.Text.Trim();
//        if (bSelesRepSelected)
//            sReportFilter = " Salesman Name : " + txtSalesRep.Text.Trim();
//        else
//            sReportFilter += (sReportFilter.Length > 0) ? "" : " - ";

//        objRpt.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sReportFilter);               

//        frm_ReportViewer ReportViewer = new frm_ReportViewer();
//        ReportViewer.crystalReportViewer1.ReportSource = objRpt;
//        ReportViewer.crystalReportViewer1.Refresh();
//        ReportViewer.crystalReportViewer1.DisplayToolbar = true;
//        ReportViewer.crystalReportViewer1.CloseView(false);
//        ReportViewer.WindowState = FormWindowState.Maximized;
//        ReportViewer.ShowDialog();

//        objRpt.Close();
//        objRpt.Dispose();
//    }
//    catch (Exception ex)
//    {
//        SEACCException.Show(ex);
//    }
//    finally
//    {
//        Cursor = Cursors.Default;
//    }
//}  