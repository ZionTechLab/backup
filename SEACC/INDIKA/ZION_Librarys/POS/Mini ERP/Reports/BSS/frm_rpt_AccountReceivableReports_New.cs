using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using DataTire;
using Digiteq.DataSets;
using Digiteq_Logic;
using Digiteq.DataSets.BSS;

namespace Digiteq
{
    public partial class frm_rpt_AccountReceivableReports_New : MettroForm
    {
        #region Variables
        //form manage
        public int iFormID;

        dts_Sales glbDtsSales = new dts_Sales();
        dts_bssOutstandingLedger gbl_dts_bssOutstandingLedger = new dts_bssOutstandingLedger();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        dts_bss_OutstandingAnalysis glb_dts_bss_OutstandingAnalysis = new dts_bss_OutstandingAnalysis();

        public bool bNoAccess;
        bool bCompanyBranchSelected = false, bRouteSelected = false, bSelesRepSelected = false, bCustomerClassSelected = false, bCustomerTypeSelected = false,
                                    bCustomerCategorySelected = false, bCustomerSelected = false;

        bool isDetailReport = false;

        #endregion

        #region Form Load
        public frm_rpt_AccountReceivableReports_New()
        {
            iFormID = clsSecurity.getFormID(FormName.AccountReceivableReports_New);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }
        private void frm_rpt_AccountReceivableReports_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Account Receivable Reports 2", 2, iFormID);
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
                        enum_ReportName Report;
                        int iRow = dgvReports.SelectedCells[0].RowIndex;
                        int iReport = int.Parse(dgvReports.Rows[iRow].Cells[0].Value.ToString());
                        Report = (enum_ReportName)iReport;

                        if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(Report)))
                        {
                            #region Variable Initialization
                            bCompanyBranchSelected = false; bRouteSelected = false; bSelesRepSelected = false; bCustomerClassSelected = false; bCustomerTypeSelected = false;
                            bCustomerCategorySelected = false; bCustomerSelected = false;
                            string sFilter = "";
                            #endregion

                            #region Selected Filters
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

                            if (txtCompanyBranch.Tag != null && txtCompanyBranch.Tag.ToString().Trim().Length > 0)
                                bCompanyBranchSelected = true;

                            if (txtRoute.Tag != null && txtRoute.Tag.ToString().Length > 0)
                                bRouteSelected = true;
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
                                else if (Report == enum_ReportName.RG_OutstandingStatement_Salesman_wise)
                                {
                                    isDetailReport = true;
                                    GenarateReport_CustomerOutstandingBackDate(Report, true);
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
                                else if (Report == enum_ReportName.ST_Outstanding_Analysis)
                                {
                                    try
                                    {
                                        string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                                        if (clsHelpMethods.GetReportPath(clsAutocode.getReportID(Report), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
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

                                            #region Fill Details
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
                                                    if (bRouteSelected)
                                                        if (oInvoices.Route_ID != int.Parse(txtRoute.Tag.ToString().Trim()))
                                                            continue;
                                                    if (bCompanyBranchSelected)
                                                        if (oInvoices.CompanyBranch_ID != txtCompanyBranch.Tag.ToString().Trim())
                                                            continue;

                                                    if (oInvoices.IsDebitNote)
                                                        dDebit += oInvoices.GrandTotal;
                                                    else
                                                        dInvoiceTotal += oInvoices.GrandTotal;
                                                }

                                                foreach (tbl_bpsReceipt oReceipt in tbl_bpsReceipt.SelectAllByCustomer_ID(oCustomer.Customer_ID).Where(p => !p.IsDeleted && p.Receipt_ID != "default" && p.ReceiptDate >= dtpFrom.Value.Date))
                                                {
                                                    //foreach( tbl_bpsReceipt_Invoice oInv_R in tbl_bpsReceipt_Invoice.SelectAllByReceipt_ID(oReceipt.Receipt_ID))
                                                    //{
                                                    //    tbl_sasInvoice oInv = tbl_sasInvoice.Select(oInv_R.Invoice_ID);
                                                    //    if (oInv != null)
                                                    //    {
                                                    //        if (bRouteSelected)
                                                    //            if (oInv.Route_ID != int.Parse(txtRoute.Tag.ToString().Trim()))
                                                    //                continue;
                                                    //        if (bCompanyBranchSelected)
                                                    //            if (oInv.CompanyBranch_ID != txtCompanyBranch.Tag.ToString().Trim())
                                                    //                continue;
                                                    //    }


                                                    //}

                                                    dCash += oReceipt.CashAmount;
                                                    foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID).Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default"))
                                                        dCheque += oCheque.Amount;
                                                }

                                                foreach (tbl_bpsCreditNote oCreditNote in tbl_bpsCreditNote.SelectAllByCustomer_ID(oCustomer.Customer_ID).Where(p => !p.IsDeleted && p.CreditNote_ID != "default" && p.CreditNoteDate >= dtpFrom.Value.Date))
                                                {
                                                    //foreach (tbl_sasInvoice_Sattled oInv_S in tbl_sasInvoice_Sattled.SelectAllByCreditNote_ID(oCreditNote.CreditNote_ID))
                                                    //{
                                                    //    tbl_sasInvoice oInv = tbl_sasInvoice.Select(oInv_S.Invoice_ID);
                                                    //    if (oInv != null)
                                                    //    {
                                                    //        if (bRouteSelected)
                                                    //            if (oInv.Route_ID != int.Parse(txtRoute.Tag.ToString().Trim()))
                                                    //                continue;
                                                    //        if (bCompanyBranchSelected)
                                                    //            if (oInv.CompanyBranch_ID != txtCompanyBranch.Tag.ToString().Trim())
                                                    //                continue;
                                                    //    }

                                                    //}

                                                    dCredit += oCreditNote.TotalAmount;
                                                }

                                                dClosingBalance = (dOpeningBalance + dInvoiceTotal + dDebit) - (dCash + dCheque + dCredit);
                                                if (dClosingBalance != 0)
                                                    glb_dts_bss_OutstandingAnalysis.dt_OutstandingAnalysis.Adddt_OutstandingAnalysisRow(oCustomer.Customer_ID, oCustomer.CustomerName, oCustomer.SalesRep_ID, sSalesman_Name, dOpeningBalance, dInvoiceTotal, dCash, dCheque, dCredit, dDebit, dClosingBalance);
                                            }
                                            #endregion

                                            #region Selected Filters
                                            if (bCompanyBranchSelected)
                                                sFilter += " Company Branch Name: " + txtRoute.Text.Trim();
                                            if (bCustomerSelected)
                                                sFilter += " Customer Name: " + txtCustomer.Text.Trim();
                                            if (bSelesRepSelected)
                                                sFilter += " Salesman Name: " + txtSalesRep.Text.Trim();
                                            if (bRouteSelected)
                                                sFilter += " Route Name: " + txtRoute.Text.Trim();
                                            else
                                                sFilter += (sFilter.Length > 0) ? "" : " - ";
                                            #endregion

                                            string sDateRange = "From : " + clsFormatter.FormatDate_Short(dtpFrom.Value) + "  To : " + clsFormatter.FormatDate_Short(dtpTo.Value);
                                            glb_dts_bss_OutstandingAnalysis.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "Outstanding Analysis Report", "", sDateRange, clsSecurity.UserNameLoged, sFilter);

                                            frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                            rpt.print(sReportPath, glb_dts_bss_OutstandingAnalysis, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.ST_Outstanding_Analysis));
                                        }
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
                            #endregion
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
            try
            {
                string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "", sMessage = "";

                if (clsHelpMethods.GetReportPath(clsAutocode.getReportID(enmReport), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
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

                    if (int.Parse(txtSlab1.Text) < int.Parse(txtSlab2.Text) && int.Parse(txtSlab2.Text) < int.Parse(txtSlab3.Text) 
                        && int.Parse(txtSlab3.Text) < int.Parse(txtSlab4.Text) && int.Parse(txtSlab4.Text) < int.Parse(txtSlab5.Text))
                    {
                        Cursor = Cursors.WaitCursor;

                        gbl_dts_bssOutstandingLedger.Clear();
                        glb_dtsReportExport.Clear();

                        string sCustomer_ClassID = "%%";
                        string sCustomer_TypeID = "%%";
                        string sCustomer_CategoryID = "%%";
                        string sCustomer_ID = "%%";
                        string sSales_Rep = "%%";
                        string sRoute_ID = "%%";
                        string sCompanyBranchID = "%%";
                        DataTable dtOSL;

                        #region Customer Filter
                        if (bCustomerSelected)
                            sCustomer_ID = txtCustomer.Tag.ToString();

                        if (bCustomerClassSelected)
                            sCustomer_ClassID = txtCustomerClassID.Tag.ToString();

                        if (bCustomerTypeSelected)
                            sCustomer_TypeID = txtCustomerTypeID.Tag.ToString();

                        if (bCustomerCategorySelected)
                            sCustomer_CategoryID = txtCategoryID.Tag.ToString();
                        #endregion

                        #region Filters / Fill
                        if (bSelesRepSelected)
                            sSales_Rep = txtSalesRep.Tag.ToString();
                        if (bRouteSelected)
                            sRoute_ID = txtRoute.Tag.ToString();
                        if (bCompanyBranchSelected)
                            sCompanyBranchID = txtCompanyBranch.Tag.ToString();

                        gbl_dts_bssOutstandingLedger.genSalesRep.Merge(DBHandling.ExecQuery(
                            "SELECT [employee_ID] AS [SalesRepID], [employeeName] AS [SalesRepName] FROM [tbl_genEmployeeMaster]").Tables[0]);
                        #endregion

                        #region Fill Customer Finance dataset
                        if (enmReport == enum_ReportName.RG_Outstanding_Invoice_wise_Detail || enmReport == enum_ReportName.RG_Outstanding_Invoice_wise_Summary || enmReport == enum_ReportName.RG_OutstandingStatement || enmReport == enum_ReportName.RG_Age_Analysis_Customer_wise || enmReport == enum_ReportName.RG_Age_Analysis_Salesman_wise || enmReport == enum_ReportName.RG_OutstandingStatement_Salesman_wise)
                        {
                            gbl_dts_bssOutstandingLedger.genCustomerFinance.Merge(DBHandling.ExecQuery("sp_genCustomerFinanceData '" + sCustomer_ID + "'").Tables[0]);
                        }
                        #endregion

                        #region Fill Stored Procedure
                        dtOSL = DBHandling.ExecQuery("sp_bssCustomerOutstanding '"
                                                + sCustomer_ClassID + "', '"
                                                + sCustomer_TypeID + "', '"
                                                + sCustomer_CategoryID + "', '"
                                                + sCustomer_ID + "', '"
                                                + sRoute_ID + "', '"
                                                + sCompanyBranchID + "' , '"
                                                + "2001-01-01', '"
                                                + dtpTo.Value.Date.Date + "', "
                                                + false + ",  "
                                                + isRepWise + "  , "
                                                + chkUseCustomerMastorSaleRep.Checked).Tables[0];

                        string sLnqQuary = "employeeID Like '" + sSales_Rep + "' AND Amount <> 0 ";
                        #endregion

                        #region Report Params
                        if (enmReport == enum_ReportName.RG_Outstanding_Invoice_wise_Detail)
                        {
                            #region Detail Reports

                            foreach (DataRow dr in dtOSL.Select("(IsChequeInHand = true or TransactionType = 3) AND (" + sLnqQuary + ")"))
                            {
                                string sDR_Customer_ID = clsValidate.ValidateRowValue(dr, "customerID", "default");
                                string sDR_Customer_Name = clsValidate.ValidateRowValue(dr, "CustomerName", "default");
                                int iDR_TxType = int.Parse(clsValidate.ValidateRowValue(dr, "TransactionType", "default"));
                                bool bDR_IsCredit = bool.Parse(clsValidate.ValidateRowValue(dr, "isCredit", "false"));
                                bool bDR_IsChequeInHand = bool.Parse(clsValidate.ValidateRowValue(dr, "IsChequeInHand", "false"));
                                bool bDR_IsAdvance = bool.Parse(clsValidate.ValidateRowValue(dr, "IsAdvance", "false"));
                                string sDR_OderRefNo = clsValidate.ValidateRowValue(dr, "OrderRefNo", "-");
                                string sRemarks = clsValidate.ValidateRowValue(dr, "transactionRemark", "");

                                if (bDR_IsChequeInHand)
                                {
                                    foreach (srh_bssCustomerOutstanding_RecieptDetail oRecipts in srh_bssCustomerOutstanding_RecieptDetail.SelectAll(dr["PONo"].ToString(), dtpTo.Value.Date))
                                    {
                                        gbl_dts_bssOutstandingLedger.bssCustomerOutstanding.AddbssCustomerOutstandingRow(sDR_Customer_ID, sDR_Customer_Name, iDR_TxType, oRecipts.Invoice_ID, oRecipts.InvoiceDate, oRecipts.GrandTotal, oRecipts.SattledAmount, "", bDR_IsCredit, bDR_IsChequeInHand, false, "", oRecipts.Age, oRecipts.DeliveryOrder_ID, oRecipts.PurchaseOrder_ID, oRecipts.Receipt_ID, oRecipts.CurrencyCode, oRecipts.CurrencyRate, bDR_IsAdvance, sDR_OderRefNo, 0);
                                    }
                                    continue;
                                }

                                if (iDR_TxType == 3)
                                {
                                    decimal dTransactionAmount = clsValidate.ValidateRowValue(dr, "TotalAmount", 0m);
                                    decimal dOutstanding = clsValidate.ValidateRowValue(dr, "Amount", 0m);
                                    decimal dRCSettledAmount = dTransactionAmount - dOutstanding;

                                    foreach (srh_bssCustomerOutstanding_RecieptDetail oRecipts in srh_bssCustomerOutstanding_RecieptDetail.SelectAll(dr["PONo"].ToString(), dtpTo.Value.Date).OrderBy(p => p.Age))
                                    {
                                        if (dRCSettledAmount >= oRecipts.SattledAmount)
                                            dRCSettledAmount -= oRecipts.SattledAmount;
                                        else
                                        {
                                            gbl_dts_bssOutstandingLedger.bssCustomerOutstanding.AddbssCustomerOutstandingRow(sDR_Customer_ID, sDR_Customer_Name, iDR_TxType, oRecipts.Invoice_ID, oRecipts.InvoiceDate, oRecipts.GrandTotal, (oRecipts.SattledAmount - dRCSettledAmount), sRemarks, bDR_IsCredit, false, false, "", oRecipts.Age, oRecipts.DeliveryOrder_ID, oRecipts.PurchaseOrder_ID, "", oRecipts.CurrencyCode, oRecipts.CurrencyRate, bDR_IsAdvance, sDR_OderRefNo, 0);
                                            dRCSettledAmount = 0;
                                        }
                                    }
                                    continue;
                                }
                            }

                            sLnqQuary += "AND IsChequeInHand <> true AND TransactionType <> 3 ";

                            #endregion
                        }
                        else
                        {
                            if (enmReport == enum_ReportName.RG_Outstanding_Invoice_wise_Summary || enmReport == enum_ReportName.RG_OutstandingStatement)
                            {
                                sLnqQuary += "AND IsChequeInHand = false ";
                            }

                            else if (enmReport == enum_ReportName.RG_OutstandingStatement_Salesman_wise || enmReport == enum_ReportName.RG_Outstanding_Salesman_wise_Detail_TW)
                            {
                                sLnqQuary += "AND ( TransactionType = 3 OR TransactionType = 1 OR TransactionType = 100 OR TransactionType = 2) ";
                            }
                        }
                        #endregion

                        var vResult = dtOSL.Select(sLnqQuary);
                        if (vResult.Length > 0)
                            dtOSL = vResult.CopyToDataTable();
                        else
                            dtOSL.Rows.Clear();
                        gbl_dts_bssOutstandingLedger.bssCustomerOutstanding.Merge(dtOSL);

                        #region Report Commons
                        string sDateRange = "As At : " + dtpTo.Value.Date.ToString("dd/MMM/yyyy");
                        string sReportFilter = "";
                        if (bCompanyBranchSelected)
                            sReportFilter += " Company Branch: " + txtCompanyBranch.Text.Trim();
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
                        if (bRouteSelected)
                            sReportFilter += " Route Name: " + txtRoute.Text.Trim();
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
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Slab_1", txtSlab1.Text, true, false);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Slab_2", txtSlab2.Text, true, false);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Slab_3", txtSlab3.Text, true, false);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Slab_4", txtSlab4.Text, true, false);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Slab_5", txtSlab5.Text, true, false);

                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("isDetail", isDetailReport ? "1" : "0", true, false);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", sCompanyName, true, false);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ContactTel", sCompanyTell, true, false);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Address", sCompanyAddress, true, false);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ContactEmail", sCompanyEmail, true, false);

                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("BackDate", "As At Date : " + dtpTo.Value.Date.ToString("dd/MM/yyyy"), true, false);

                        #endregion

                        #region Outstanding Details
                        //if (enmReport == enum_ReportName.RG_OutstandingStatement)
                        if (gbl_dts_bssOutstandingLedger.genCustomerFinance.Rows.Count > 0)
                        {
                            foreach (DataRow dr in gbl_dts_bssOutstandingLedger.genCustomerFinance.Rows)
                            {
                                string sCus_ID = dr["customer_ID"].ToString();
                                string sCus_Name = dr["customerName"].ToString();
                                DataRow[] vData = gbl_dts_bssOutstandingLedger.bssCustomerOutstanding.Select("customerID = '" + sCus_ID + "'");
                                if (vData == null || vData.Count() < 1)
                                {
                                    tbl_genCustomerMaster oCusMaster = tbl_genCustomerMaster.Select(sCus_ID);
                                    if (bSelesRepSelected)
                                        if (oCusMaster.SalesRep_ID != txtSalesRep.Tag.ToString())
                                            continue;


                                    //Customers who don't have outstanding...
                                    gbl_dts_bssOutstandingLedger.bssCustomerOutstanding
                                           .AddbssCustomerOutstandingRow(sCus_ID,
                                               sCus_Name, -1,
                                               "", dtpTo.Value.Date,
                                               0, 0, "",
                                               false, false, true, oCusMaster != null ? oCusMaster.SalesRep_ID : "",
                                               0, "",
                                               "", "",
                                               "", 0,
                                               false, "", 0);
                                }
                            }
                        }
                            else 
                            {
                                gbl_dts_bssOutstandingLedger.bssCustomerOutstanding
                                    .AddbssCustomerOutstandingRow("",
                                        "", -1,
                                        "", dtpTo.Value.Date,
                                        0, 0, "",
                                        false, false, true, "default",
                                        0, "",
                                        "", "",
                                        "", 0,
                                        false, "", 0);                            
                        }
                        #endregion

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
                else
                    MessageBox.Show("Report not found");
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

        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearField();
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
            txtCompanyBranch.Tag = null;
            txtRoute.Tag = null;

            txtCustomerClassID.Text = "<All Classes>";
            txtCustomerTypeID.Text = "<All Types>";
            txtCategoryID.Text = "<All Categories>";
            txtSalesRep.Text = "<All Salesman>";
            txtCustomer.Text = "<All Customer>";
            txtCompanyBranch.Text = "<All Company Branches>";
            txtRoute.Text = "<All Routes>";

            txtSlab1.Text = "30";
            txtSlab2.Text = "60";
            txtSlab3.Text = "90";
            txtSlab4.Text = "120";
            txtSlab5.Text = "150";

            clsCommon.SetEnableDisable_NormalLabel(lblBranch, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCompanyBranch, true);

            clsCommon.SetVisibility_Panel(pnlBranch, true);
            clsCommon.SetVisibility_Panel(pnlSalesman, false);
            clsCommon.SetVisibility_Panel(pnlCusClass, false);
            clsCommon.SetVisibility_Panel(pnlCusType, false);
            clsCommon.SetVisibility_Panel(pnlCategory, false);
            clsCommon.SetVisibility_Panel(pnlCustomer, false);
            clsCommon.SetVisibility_Panel(pnlRoute, false);

            clsCommon.SetVisibility_Panel(pnlDateFrom, false);
            clsCommon.SetVisibility_Panel(pnlDateAsAt, true);
            clsCommon.SetVisibility_Panel(pnlAgingSlab, false);

            chkShowAll_Branch.Checked = false;
            chkUseCustomerMastorSaleRep.Checked = false;
            chkShowAll.Checked = false;

            tbl_genCompanyBranchMaster oBranch = tbl_genCompanyBranchMaster.Select(clsSecurity.BranchID);
            if (oBranch != null)
            {
                txtCompanyBranch.Text = clsGenaralName.getName_CompanyBranchMaster(clsSecurity.BranchID);
                txtCompanyBranch.Tag = clsSecurity.BranchID;

                if (!oBranch.IsHeadOffice)
                {
                    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCompanyBranch, false);
                    clsCommon.SetEnableDisable_NormalLabel(lblBranch, false);
                    clsCommon.SetEnableDisable_NormalCheckBox(chkShowAll_Branch, false);
                }
            }
        }
        #endregion

        #region Print Method
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
                    objRpt.DataDefinition.FormulaFields["ContactTel"].Text = clsCommon.fncsetstring(clsConfig.sCmp_qContactTelephone);
                    objRpt.DataDefinition.FormulaFields["ContactEmail"].Text = clsCommon.fncsetstring(clsConfig.sCmp_qContactEmail);
                }
                catch (Exception) { }

                if (bCompanyBranchSelected)
                    sReportFilter += " Comapny Branch Name : " + txtCompanyBranch.Text.Trim();
                if (bRouteSelected)
                    sReportFilter += " Route Name : " + txtRoute.Text.Trim();
                if (bCustomerSelected)
                    sReportFilter += " Customer Name : " + txtCustomer.Text.Trim();
                if (bSelesRepSelected)
                    sReportFilter += " Salesman Name : " + txtSalesRep.Text.Trim();
                else
                    sReportFilter += (sReportFilter.Length > 0) ? "" : " - ";

                objRpt.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sReportFilter);

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

        #region Events Keypress
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
        private void txtSlab4_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowInteger(e);
        }
        private void txtSlab5_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowInteger(e);
        }
        #endregion

        #region Events Keydown
        private void frm_rpt_ChequeManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void txtSalesRep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SalesRepID();
        }
        private void txtCompanyBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CompanyBranchID();
        }
        private void txtRoute_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_RouteID();
        }
        private void txtCustomerClassID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CustomerClassID();
        }
        private void txtCustomerTypeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CustomerTypeID();
        }
        private void txtCategoryID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CustomerCategoryID();
        }
        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CustomerID();
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
        private void txtCompanyBranch_DoubleClick(object sender, EventArgs e)
        {
            Search_CompanyBranchID();
        }
        private void txtRoute_DoubleClick(object sender, EventArgs e)
        {
            Search_RouteID();
        }
        #endregion

        #region Checked Change
        private void chkShowAll_Branch_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowAll_Branch.Checked == true)
            {
                txtCompanyBranch.Tag = null;
                txtCompanyBranch.Text = "<All Company Branches>";

                clsCommon.SetEnableDisable_NormalLabel(lblBranch, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCompanyBranch, false);
            }
            else
            {
                txtCompanyBranch.Tag = clsSecurity.BranchID;
                txtCompanyBranch.Text = clsGenaralName.getName_CompanyBranchMaster(clsSecurity.BranchID);

                clsCommon.SetEnableDisable_NormalLabel(lblBranch, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCompanyBranch, true);
            }
        }
        #endregion

        #region Grid Events
        private void dgvReports_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int iReportID = clsValidate.ValidateGridValue(dgvReports, "report_ID", e.RowIndex, 0);
                setEnableDisableConctrol(iReportID);
            }
        }
        #endregion

        #region Search Methods
        private void Search_CompanyBranchID()
        {
            try
            {
                clsSearch.Search_CompanyBranch(ref txtCompanyBranch);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
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
        private void Search_CustomerID()
        {
            clsSearch.Search_MasterCustomer(ref txtCustomer, chkShowAll.Checked);

            if (txtCustomer.Tag != null)
            {
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
            }
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
        private void Search_RouteID()
        {
            try
            {
                clsSearch.Search_MasterRoute(ref txtRoute);
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

            if (iReportID == (int)enum_ReportName.RG_Outstanding_Customer_Wise_Summary || iReportID == (int)enum_ReportName.RG_Outstanding_Customer_Wise_Detail ||
                iReportID == (int)enum_ReportName.RG_Outstanding_Invoice_wise_Summary || iReportID == (int)enum_ReportName.RG_Outstanding_Invoice_wise_Detail ||
                iReportID == (int)enum_ReportName.RG_OutstandingStatement_Salesman_wise || iReportID == (int)enum_ReportName.RG_Outstanding_Salesman_wise_Detail_TW)
            {
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlCusClass, true);
                clsCommon.SetVisibility_Panel(pnlCusType, true);
                clsCommon.SetVisibility_Panel(pnlCategory, true);
                clsCommon.SetVisibility_Panel(pnlCustomer, true);

                dtpFrom.Visible = false;
                lblFromDate.Visible = false;

                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRoute, true);
                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCompanyBranch, true);

                clsCommon.SetEnableDisable_NormalLabel(lblRoute, true);
                //clsCommon.SetEnableDisable_NormalLabel(lblBranch, true);

                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);


                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, false);
            }
            else if (iReportID == (int)enum_ReportName.RG_Outstanding_Salesman_wise_Summary || iReportID == (int)enum_ReportName.RG_Outstanding_Salesman_wise_Detail)
            {
                clsCommon.SetVisibility_Panel(pnlSalesman, true);

                dtpFrom.Visible = false;
                lblFromDate.Visible = false;
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, false);

            }
            else if (iReportID == (int)enum_ReportName.RG_Age_Analysis_Customer_wise || iReportID == (int)enum_ReportName.RG_Age_Analysis_Salesman_wise)
            {
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlCusClass, true);
                clsCommon.SetVisibility_Panel(pnlCusType, true);
                clsCommon.SetVisibility_Panel(pnlCategory, true);
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlAgingSlab, true);

                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRoute, true);
                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCompanyBranch, true);

                clsCommon.SetEnableDisable_NormalLabel(lblRoute, true);
                //clsCommon.SetEnableDisable_NormalLabel(lblBranch, true);

                dtpFrom.Visible = false;
                lblFromDate.Visible = false;
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, false);

                grpAgeingSlabs.Visible = true;
            }
            else if (iReportID == (int)enum_ReportName.RG_OutstandingStatement)
            {
                clsCommon.SetVisibility_Panel(pnlCusClass, true);
                clsCommon.SetVisibility_Panel(pnlCusType, true);
                clsCommon.SetVisibility_Panel(pnlCategory, true);
                clsCommon.SetVisibility_Panel(pnlCustomer, true);

                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRoute, true);
                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCompanyBranch, true);


                clsCommon.SetEnableDisable_NormalLabel(lblRoute, true);
                //clsCommon.SetEnableDisable_NormalLabel(lblBranch, true);

                dtpFrom.Visible = false;
                lblFromDate.Visible = false;
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, false);
            }
            else if (iReportID == (int)enum_ReportName.ST_Outstanding_Analysis)
            {
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlCusClass, true);
                clsCommon.SetVisibility_Panel(pnlCusType, true);
                clsCommon.SetVisibility_Panel(pnlCategory, true);
                clsCommon.SetVisibility_Panel(pnlCustomer, true);

                clsCommon.SetVisibility_Panel(pnlDateFrom, true);

                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRoute, true);
                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCompanyBranch, true);

                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);


                clsCommon.SetEnableDisable_NormalLabel(lblRoute, true);
                //clsCommon.SetEnableDisable_NormalLabel(lblBranch, true);

                chkUseCustomerMastorSaleRep.Checked = true;

                dtpFrom.Visible = true;
                lblFromDate.Visible = true;
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
            }
        }
        #endregion

    }
}

