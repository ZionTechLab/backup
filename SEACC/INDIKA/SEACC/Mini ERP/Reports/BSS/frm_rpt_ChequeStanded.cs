#region Using Derectives
using System;
using System.Linq;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;
using System.Collections.Generic;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using DataTire;
using Zion.ERP.Reports.DataSets;
using System.Data;
using Zion.ERP.Reports.DataSets.SAS;
using Zion.ERP.Reports.DataSets.BSS;
using ZION.ERP.Reports.DataSets.BSS;
using ZION.ERP.Reports.DataSets.SAS;
using ZION.ERP.Reports.DataSets;

#endregion

namespace Digiteq
{
    public partial class frm_rpt_ChequeStanded : MettroForm
    {
        


        //objects from datasets        
        dtsBills glbDtsBills = new dtsBills();
        dts_BSS glbDtsBSS = new dts_BSS();
        dts_Sales glbDtsSales = new dts_Sales();
        dts_bssIncentive glb_dts_bssIncentive = new dts_bssIncentive();
        dts_sasReceiptAllocation glb_dtsReceiptAllocation = new dts_sasReceiptAllocation();
        dts_bssOutstandingLedger gbl_dts_bssOutstandingLedger = new dts_bssOutstandingLedger();
        dts_Unspecified glb_dtsUnSpecified = new dts_Unspecified();

        dts_bssRegister glbdts_bssRegister = new dts_bssRegister();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();

        enum_ReportName Report;

        bool bCustomerSelected = false, bCurrencySelected = false, bSelesRepSelected = false, bCollectorSelected = false, bRouteSelected = false, bCreatedUserSelected = false;


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
                            if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(Report), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                            {
                                #region Filters
                                string sFormula = "", sFilter = "";
                                string Filter2 = "";
                                bCustomerSelected = false; bCurrencySelected = false; bSelesRepSelected = false;
                                bRouteSelected = false; bCreatedUserSelected = false;

                                if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Length > 0)
                                    bCustomerSelected = true;
                                if (txtSalesRep.Tag != null && txtSalesRep.Tag.ToString().Length > 0)
                                    bSelesRepSelected = true;
                                if (txtCollector.Tag != null && txtCollector.Tag.ToString().Length > 0)
                                    bCollectorSelected = true;
                                if (cmbCurrency.Tag != null && cmbCurrency.Tag.ToString().Length > 0)
                                    bCurrencySelected = true;
                                if (txtRoute.Tag != null && txtRoute.Tag.ToString().Length > 0)
                                    bRouteSelected = true;
                                if (txtCreatedUser.Tag != null && txtCreatedUser.Tag.ToString().Length > 0)
                                    bCreatedUserSelected = true;

                                if (bCustomerSelected)
                                    Filter2 += " Customer Name : " + txtCustomer.Text.Trim();
                                if (bSelesRepSelected)
                                    Filter2 += " Sales Rep : " + txtSalesRep.Text.Trim();
                                if (bCollectorSelected)
                                    Filter2 += " Collector Name : " + txtCollector.Text.Trim();
                                if (bRouteSelected)
                                    Filter2 += " Route Name : " + txtRoute.Text.Trim();
                                if (bCreatedUserSelected)
                                    Filter2 += (Filter2 == "" ? "" : " | ") + "Created user : " + txtCreatedUser.Text;
                                if (bSelesRepSelected)
                                    Filter2 += (Filter2 == "" ? "" : " | ") + "Sales Rep : " + txtSalesRep.Text;
                                if (rdoDeleted.Checked)
                                    Filter2 += (Filter2 == "" ? "" : " | ") + "Deleted records only";
                                if (rdoActual.Checked)
                                    Filter2 += (Filter2 == "" ? "" : " | ") + "Active records only";

                                if(chkUseChequedate.Checked)
                                    Filter2 += (Filter2 == "" ? "" : " | ") + "Based on Cheque Date";

                                if(chkShowSettledOnly.Checked)
                                    Filter2 += (Filter2 == "" ? "" : " | ") + "Show Settled Collection Only";
                               
                                if (chkShowReturnCollection.Checked)
                                    Filter2 += (Filter2 == "" ? "" : " | ") + "With Return Collection";

                                string sDateRange = "From : " + dtpFrom.Value.ToString("dd MMM  yyyy") + "  To : " + dtpTo.Value.ToString("dd MMM  yyyy");
                                #endregion                           

                                #region Collection Report
                                if (Report == enum_ReportName.ST_Collection_Report_Summary
                                    || Report == enum_ReportName.ST_Collection_Report_Detail)
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
                                                            sSalesRepID, sSalesRepName, clsHelpMethods_Local.getDisplayPrice(oChequeRegister.Amount, oReceipt.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(oReceipt.CashAmount, oReceipt.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(oChequeRegister.Amount, oReceipt.CurrencyRate), clsGenaralName.getName_CurrencyCode(oReceipt.Currency_ID), oChequeRegister.Bank_ID, clsGenaralName.getName_Bank(oChequeRegister.Bank_ID), oChequeRegister.AccountNumber,
                                                            oChequeRegister.ChequeNumber, oChequeRegister.DateCheque, oReceipt.IsAdvance, oReceipt.DateCreate);
                                                    }
                                                    else
                                                    {
                                                        glbDtsBills.dt_bssPaymontCollection.Rows.Add(oReceipt.Receipt_ID, oReceipt.ReceiptDate, oReceipt.Customer_ID, clsGenaralName.getName_Customer(oReceipt.Customer_ID),
                                                          sSalesRepID, sSalesRepName, clsHelpMethods_Local.getDisplayPrice(oChequeRegister.Amount, oReceipt.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(oReceipt.CashAmount, oReceipt.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(oReceipt.ChequeAmount, oReceipt.CurrencyRate),
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
                                                            sSalesRepID, sSalesRepName, clsHelpMethods_Local.getDisplayPrice(dTotal, oReceipt.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(dCashAmount, oReceipt.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(dChqAmount, oReceipt.CurrencyRate), clsGenaralName.getName_CurrencyCode(oReceipt.Currency_ID), "", "", "",
                                                            "", oReceipt.DateCreate, oReceipt.IsAdvance, oReceipt.DateCreate);
                                            }
                                        }
                                        clsHelpMethods_Local.startProgressBar(0, oReceipts.Count + 2, 1, ProgressBar);

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
                                else if (Report == enum_ReportName.ST_Collection_Report_Aging
                                    || Report == enum_ReportName.ST_Collection_Report_Aging_Route
                                    || Report == enum_ReportName.ST_Collection_Report_Aging_Route_Collector
                                    )
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;

                                        glbDtsBills.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, Filter2);

                                        string sCustomerID = bCustomerSelected ? txtCustomer.Tag.ToString() : "";
                                        string sSalesmanID = bSelesRepSelected ? txtSalesRep.Tag.ToString() : "";
                                        string sCollectorID = bCollectorSelected ? txtCollector.Tag.ToString() : "";
                                        string Route = bRouteSelected ? txtRoute.Tag.ToString() : "-1";
                                        string IsLocalCurrency = "";
                                        if (cmbCurrency.Text.Trim() == "Sri Lanka Rupee (LKR)")
                                            IsLocalCurrency = "1";
                                        else if (cmbCurrency.Text.Trim() == "American Dollar (USD)")
                                            IsLocalCurrency = "0";
                                        int ShowInvOnly = chkShowSettledOnly.Checked ? 1 : 0;

                                        string sQuary = "exec [sp_GetRpt_CollectionReportRouteWise] '" + sCustomerID + "','" + sCollectorID + "','" + "','" + sSalesmanID + "'," + (chkUseCustomerMastorSaleRep.Checked ? "1" : "0") + "," + Route +",'"+ dtpFrom.Value.ToString("dd-MMM-yyyy") + "', '" + dtpTo.Value.ToString("dd-MMM-yyyy") + "'," + ShowInvOnly+","+(chkUseChequedate.Checked?"1":"0")+",'"+(int)(Report) +"',"
                                            + (chkShowReturnCollection.Checked ? "1" : "0");

                                        glbDtsBills.dt_bssPaymentCollectionAging.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glbDtsBills, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                    }
                                    catch (Exception)
                                    {

                                        throw;
                                    }
                                    finally
                                    {
                                        glbDtsBills.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Collection Report (Invoice-wise)
                                else if (Report == enum_ReportName.ST_Collection_Aging_InvoiceWise 
                                    ||    Report == enum_ReportName.ST_CollectionReport_InvoiceWise
                                      ||    Report == enum_ReportName.ST_Collection_Aging_InvoiceWise_Detail
                                    )
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;

                                        glbDtsBills.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, Filter2);

                                        string sCustomerID = bCustomerSelected ? txtCustomer.Tag.ToString() : "";
                                        string sSalesmanID = bSelesRepSelected ? txtSalesRep.Tag.ToString() : "";
                                        string sCollectorID = bCollectorSelected ? txtCollector.Tag.ToString() : "";
                                        string Route = bRouteSelected ? txtRoute.Tag.ToString() : "-1";
                                       
                                        string sQuary = "exec [sp_GetRpt_InvoiceWiseCollectionAging] '" + dtpFrom.Value.ToString("dd-MMM-yyyy") + "', '" + dtpTo.Value.ToString("dd-MMM-yyyy") + "','" + sCustomerID + "','" + sSalesmanID + "','" + sCollectorID + "'," + Route + " ";
                                      
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDeTailReport",(chkShowDetailReport.Checked?"1":"0") , true);
                                        glbDtsBills.dt_bssInvCollectionAging.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glbDtsBills, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception)
                                    {
                                        throw;
                                    }
                                    finally
                                    {
                                        glbDtsBills.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Collection Report-Route Wise


                                else if (Report == enum_ReportName.CU_CollectionReportRouteWise)
                                {
                                    Cursor = Cursors.WaitCursor;

                                    glb_dtsUnSpecified.Clear();
                                    glb_dtsUnSpecified.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, sFilter);

                                    dts_ReportExport glb_dts_ExportReport = new dts_ReportExport();

                                    string sCustomerID = bCustomerSelected ? txtCustomer.Tag.ToString() : "";
                                    string sSalesmanID = bSelesRepSelected ? txtSalesRep.Tag.ToString() : "";
                                    string sCollectorID = bCollectorSelected ? txtCollector.Tag.ToString() : "";
                                    string Route = bRouteSelected ? txtRoute.Tag.ToString() : "-1";
                                    string IsLocalCurrency = "";
                                    int ShowInvOnly = chkShowSettledOnly.Checked ? 1 : 0;

                                    string sQuary = "exec [sp_GetRpt_CollectionReportRouteWise] '" + sCustomerID + "','" + sCollectorID + "','" + "','" + sSalesmanID + "'," + (chkUseCustomerMastorSaleRep.Checked ? "1" : "0") + "," + Route + ",'" + dtpFrom.Value.ToString("dd-MMM-yyyy") + "', '" + dtpTo.Value.ToString("dd-MMM-yyyy") + "'," + ShowInvOnly + "," + (chkUseChequedate.Checked ? "1" : "0") + ",'" + (int)(Report) + "',"
                                        +(chkShowReturnCollection.Checked ? "1" : "0");

                                    glb_dtsUnSpecified.dt_Unspecified_01.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                                    frm_ReportViewer_New CRViwer = new frm_ReportViewer_New();
                                    CRViwer.print(sReportPath, glb_dtsUnSpecified, glb_dts_ExportReport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    Cursor = Cursors.Default;
                                    glb_dtsUnSpecified.Clear();

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

                                        #region Customer
                                        List<tbl_genCustomerMaster> oCustomerL;
                                        //if (bCustomerSelected)
                                        //{
                                        //    oCustomerL = new List<tbl_genCustomerMaster>();
                                        //    oCustomerL.Add(tbl_genCustomerMaster.Select(txtCustomer.Tag.ToString()));
                                        //}
                                        //else
                                        //    oCustomerL = tbl_genCustomerMaster.SelectAll().ToList();
                                        #endregion

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
                                            //if (bSelesRepSelected)
                                            //{
                                            //    tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                            //    if (oCustomer != null && oCustomer.Customer_ID != "default")
                                            //    {
                                            //        if (txtSalesRep.Tag.ToString().Trim() != oCustomer.SalesRep_ID)
                                            //            continue;
                                            //    }
                                            //}

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
                                            string sPoNo = oInvoice.Job_ID != "default" ? oInvoice.Job_ID : clsGenaralName.getName_OrderRefNo(oInvoice.OrderRefNo_ID);
                                            int iCount = 0;
                                            foreach (tbl_sasInvoice_Sattled oInvoiceSettle in tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(oInvoice.Invoice_ID.Trim()))
                                            {
                                                bIsSettledInvoice = true;
                                                string sChequNo = "", sPaymentNo = "", sSRNNo = "", sDepositeAccNo = "";
                                                DateTime dRealizeDate = new DateTime();
                                                DateTime dtmChequeDate = new DateTime();
                                                DateTime dtmRecepitDate = new DateTime();
                                                //  DateTime temp = new DateTime();
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
                                                    bIsCheque, iCount == 0 ? oInvoice.GrandTotal : 0, oInvoice.Customer_ID, clsGenaralName.getName_Customer(oInvoice.Customer_ID), sDepositeAccNo, dRealizeDate,"");
                                                iCount++;

                                            }

                                            if (!bIsSettledInvoice)
                                            {
                                                dBalanceAmount = oInvoice.GrandTotal - oInvoice.SeattleAmount;
                                                DateTime dtmNiglectDate = new DateTime(00 - 00 - 0000).Date;
                                                gbl_dts_bssOutstandingLedger.dt_bssInvoiceWisePaymentTracking.Adddt_bssInvoiceWisePaymentTrackingRow(oInvoice.Invoice_ID, oInvoice.InvoiceDate, sPoNo, "", "", dtmNiglectDate, dtmNiglectDate, "", 0, dBalanceAmount, 0, false, oInvoice.GrandTotal, oInvoice.Customer_ID, clsGenaralName.getName_Customer(oInvoice.Customer_ID), "", DateTime.MinValue,"");
                                            }
                                        }

                                        if (rdoDeleted.Checked)
                                            sFilter += (sFilter != "" ? " | " : "") + "Cancelled Records Only ";
                                        if (rdoActual.Checked)
                                            sFilter += (sFilter != "" ? " | " : "") + "Active records Only ";
                                        if (rdoAll.Checked)
                                            sFilter += (sFilter != "" ? " | " : "") + "All Records ";

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

                                else if (Report == enum_ReportName.RG_Customer_wise_payment_Tracking_New
                                    || Report == enum_ReportName.RG_Customer_wise_payment_Statement)
                                {
                                    Cursor = Cursors.WaitCursor;

                                    gbl_dts_bssOutstandingLedger.Clear();
                                    gbl_dts_bssOutstandingLedger.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, sFilter);

                                    dts_ReportExport glb_dts_ExportReport = new dts_ReportExport();

                                    string CustomerID = bCustomerSelected ? txtCustomer.Tag.ToString() : "";
                                    string SalesmanID = bSelesRepSelected ? txtSalesRep.Tag.ToString() : "";
                                    int IsCustomermasterSalesRep = chkUseCustomerMastorSaleRep.Checked ? 1 : 0;
                                    int RouteID = bRouteSelected ? int.Parse(txtRoute.Tag.ToString()) : -1;

                                    string sQuary = "exec [sp_GetRpt_CustomerWisePaymentTracking] '','" + CustomerID + "', '" + SalesmanID + "', " + IsCustomermasterSalesRep + "," + RouteID + ", '" + dtpFrom.Value.ToString("dd-MMM-yyyy") + "','" + dtpTo.Value.ToString("dd-MMM-yyyy") + "'";

                                    gbl_dts_bssOutstandingLedger.dt_bssInvoiceWisePaymentTracking.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                                    frm_ReportViewer_New CRViwer = new frm_ReportViewer_New();
                                    CRViwer.print(sReportPath, gbl_dts_bssOutstandingLedger, glb_dts_ExportReport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    Cursor = Cursors.Default;
                                    gbl_dts_bssOutstandingLedger.Clear();

                                }


                                #region Invoice Settlement Ledger
                                else if (Report == enum_ReportName.RG_Invoice_wise_payment_Tracking
                                    || Report == enum_ReportName.RG_Customer_wise_payment_Tracking)
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
                                        if (bRouteSelected)
                                            sFilter += " Route Name :" + txtRoute.Text.Trim();
                                        #endregion

                                        #region Customer
                                        List<tbl_genCustomerMaster> oCustomerL;
                                        //if (bCustomerSelected)
                                        //{
                                        //    oCustomerL = new List<tbl_genCustomerMaster>();
                                        //    oCustomerL.Add(tbl_genCustomerMaster.Select(txtCustomer.Tag.ToString()));
                                        //}
                                        //else
                                        //    oCustomerL = tbl_genCustomerMaster.SelectAll().ToList();
                                        #endregion

                                        //foreach (tbl_genCustomerMaster oCustomer in oCustomerL.Where(p => !p.IsDeleted && p.CompanyBranch_ID == clsSecurity.BranchID))
                                        //{

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


                                            #region Route Filter
                                            if (bRouteSelected)
                                            {
                                                if (int.Parse(txtRoute.Tag.ToString()) != oInvoice.Route_ID)
                                                    continue;
                                            }
                                            #endregion

                                            dBalanceAmount = oInvoice.GrandTotal;
                                            string sPoNo = oInvoice.Job_ID != "default" ? oInvoice.Job_ID : clsGenaralName.getName_OrderRefNo(oInvoice.OrderRefNo_ID);
                                            int iCount = 0;
                                            foreach (tbl_sasInvoice_Sattled oInvoiceSettle in tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(oInvoice.Invoice_ID.Trim()))
                                            {
                                                bIsSettledInvoice = true;
                                                string sChequNo = "", sPaymentNo = "", sSRNNo = "";
                                                DateTime dtmChequeDate = new DateTime();
                                                DateTime dtmRecepitDate = new DateTime();
                                                //  DateTime temp = new DateTime();
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
                                                //string sChequeNo = "";
                                                //if (oInvoice.IsReturnedCheque)
                                                //{
                                                //    tbl_bpsChequeRegister oChequeRegister = tbl_bpsChequeRegister.Select(oInvoice.ChequeRegister_ID);
                                                //    if (oChequeRegister != null && oChequeRegister.ChequeRegister_ID != "default")
                                                //    {
                                                //        sChequeNo =" | "+ oChequeRegister.ChequeNumber;
                                                //    }
                                                //}

                                                dBalanceAmount -= oInvoiceSettle.SattledAmount;
                                                gbl_dts_bssOutstandingLedger.dt_bssInvoiceWisePaymentTracking.Adddt_bssInvoiceWisePaymentTrackingRow(oInvoiceSettle.Invoice_ID, oInvoice.InvoiceDate, sPoNo, sPaymentNo, sSRNNo, dtmRecepitDate, dtmChequeDate, sChequNo, oInvoiceSettle.SattledAmount, dBalanceAmount, tsNofDate.TotalDays, bIsCheque, iCount == 0 ? oInvoice.GrandTotal : 0, oInvoice.Customer_ID, clsGenaralName.getName_Customer(oInvoice.Customer_ID), "", DateTime.MinValue,"");
                                                iCount++;
                                            }

                                            if (!bIsSettledInvoice)
                                            {
                                                dBalanceAmount = oInvoice.GrandTotal - oInvoice.SeattleAmount;
                                                DateTime dtmNiglectDate = new DateTime(00 - 00 - 0000).Date;
                                                gbl_dts_bssOutstandingLedger.dt_bssInvoiceWisePaymentTracking.Adddt_bssInvoiceWisePaymentTrackingRow(oInvoice.Invoice_ID, oInvoice.InvoiceDate, sPoNo, "", "", dtmNiglectDate, dtmNiglectDate, "", 0, dBalanceAmount, 0, false, oInvoice.GrandTotal, oInvoice.Customer_ID, clsGenaralName.getName_Customer(oInvoice.Customer_ID), "", DateTime.MinValue,"");
                                            }
                                        }

                                        gbl_dts_bssOutstandingLedger.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, sFilter);
                                        //}
                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, gbl_dts_bssOutstandingLedger, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                        //print(sReportPath, sReportName, gbl_dts_bssOutstandingLedger, "", clsAutocode.getReportID(enmReport));
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
                                                // if(detail.Invoice_ID =pr
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
                                                    glb_dtsReceiptAllocation.dt_sasAdvanceAllocation_Summary.Adddt_sasAdvanceAllocation_SummaryRow(detail.AllocationID, detail.AllocationDate, detail.SattledAmount, detail.Receipt_ID, oReceipt.ReceiptDate, oReceipt.TotalAmount, detail.Invoice_ID, oInvoice.InvoiceDate, clsGenaralName.getName_Customer(oReceipt.Customer_ID), detail.SattledDate);
                                            }
                                            sReportTitle_Main = chkPartPayment.Checked ? "Part Payment Receipt Allocation Report" : (chkAdvance.Checked) ? "Advance Receipt Allocation Report" : "Over Payment Receipt Allocation Report";
                                            glb_dtsReceiptAllocation.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, sFilter);

                                            frm_ReportViewer_New rpt = new Digiteq.frm_ReportViewer_New();
                                            rpt.print(sReportPath, glb_dtsReceiptAllocation, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

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
                                else if (Report == enum_ReportName.RG_OverPaymentListing
                                    || Report == enum_ReportName.RG_OverPaymentListing_RouteWise
                                    || Report == enum_ReportName.RG_AdvanceListing)
                                {
                                    glbDtsSales.Clear();
                                    Cursor = Cursors.WaitCursor;
                                    try
                                    {
                                        List<tbl_bpsReceipt> oReceipts = new List<tbl_bpsReceipt>();
                                        if (Report == enum_ReportName.RG_OverPaymentListing || Report == enum_ReportName.RG_OverPaymentListing_RouteWise)
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
                                                    tbl_genCustomerMaster_Branches oRoute = tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oCustomer.Customer_ID).FirstOrDefault();

                                                    if (bRouteSelected)
                                                    {
                                                        int Route = int.Parse(txtRoute.Tag.ToString());
                                                        if (oRoute.Route_ID != Route)
                                                            continue;
                                                    }


                                                    decimal dOverpaymentTotal = 0, dAdvancepaymentTotal = 0, dSettleAmount = 0;
                                                    decimal dAllocatedAmount = 0;
                                                    foreach (tbl_sasInvoice_Sattled oSettle in tbl_sasInvoice_Sattled.SelectAllByReceipt_ID(oReceipt.Receipt_ID))
                                                    {
                                                        dOverpaymentTotal += oSettle.IsOverPayment ? oSettle.SattledAmount : 0;
                                                        dAdvancepaymentTotal += oSettle.IsAdvancePayment ? oSettle.SattledAmount : 0;
                                                        dSettleAmount += oSettle.SattledAmount;
                                                    }

                                                    decimal dBalanceAmount = oReceipt.TotalAmount - dSettleAmount;
                                                    if (Report == enum_ReportName.RG_OverPaymentListing || Report == enum_ReportName.RG_OverPaymentListing_RouteWise)
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

                                                    glbDtsSales.dt_OverPaymentListing.Adddt_OverPaymentListingRow(oReceipt.Receipt_ID, oReceipt.ReceiptDate, oReceipt.Customer_ID, oCustomer.CustomerName, "", oReceipt.TotalAmount, dAllocatedAmount, dBalanceAmount, oReceipt.Remark, sChequeNo, sTransactionCode, clsGenaralName.getName_Employee(sSalesmanID), clsGenaralName.getCode_Route(oRoute.Route_ID));
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

                                        // print("\\reports\\SAS\\Finance\\rpt_sas_OverPaymentListing.rpt", sReportTitle, glbDtsSales, sFilter, clsAutocode.getReportID(enum_ReportName.RG_OverPaymentListing));
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
                                            //  print("\\reports\\BSS\\Standard\\rpt_sas_Incentive.rpt", "Incentive Report(Customer Order Wise)", glb_dts_bssIncentive, sFilter, clsAutocode.getReportID(enum_ReportName.ST_Incentive));
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

                                            if (bCreatedUserSelected)
                                            {
                                                if (oReceipt.CreateUser_ID != txtCreatedUser.Tag.ToString())
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

                                            if (rdoDeleted.Checked)
                                                if (oReceipt.IsDeleted != true)
                                                    continue;

                                            if (rdoActual.Checked)
                                                if (oReceipt.IsDeleted != false)
                                                    continue;

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

                                                glbdts_bssRegister.dt_Receipt_Cheques.Adddt_Receipt_ChequesRow(oReceipt.Receipt_ID, oCheque.ChequeRegister_ID, oCheque.ChequeNumber, oCheque.DateCheque, clsGenaralName.getName_Bank(oCheque.Bank_ID) + " - " + clsGenaralName.getName_BankBranch(oCheque.Branch_ID), oCheque.DepositedAccountNumber, clsGenaralName.getName_ChequeStatus(oCheque.ChequeStatus_ID), oCheque.Amount);
                                            }

                                            glbdts_bssRegister.dt_Receipt.Adddt_ReceiptRow(oReceipt.Receipt_ID, oReceipt.ReceiptDate, oReceipt.Customer_ID, sCustomerName, dCashAmount, dChequeAmount, (dCashAmount + dChequeAmount), oReceipt.IsDeleted);
                                        }

                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CashTotal", clsFormatter.FormatDecimalPlaces_Price(dTotCashAmount), true);
                                        glbdts_bssRegister.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, Filter2);

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
            txtRoute.Text = "<<ALL Routes>>";
            txtCreatedUser.Text = "<<ALL Users>>";
            cmbCurrency.SelectedIndex = 0;

            txtCustomer.Tag = null;
            txtSalesRep.Tag = null;
            txtCollector.Tag = null;
            txtRoute.Tag = null;
            txtCreatedUser.Tag = null;

            chkAdvance.Checked = false;
            chkOverPayment.Checked = false;
            chkPartPayment.Checked = false;
            chkAllocationNumberWise.Checked = false;
            chkUseCustomerMastorSaleRep.Checked = false;
            chkShowSettledOnly.Checked = false;

            chkCash.Checked = true;
            chkCheque.Checked = true;
            rdoActual.Checked = true;
            chkShowAll.Checked = false;
            chkUseChequedate.Checked = false;
            chkShowDetailReport.Checked = false;
            chkShowReturnCollection.Checked = false;

            clsCommon.SetVisibility_Panel(pnlCurrency, false);
            clsCommon.SetVisibility_Panel(pnlCustomer, false);
            clsCommon.SetVisibility_Panel(pnlSalesman, false);
            clsCommon.SetVisibility_Panel(pnlRoute, false);
            clsCommon.SetVisibility_Panel(pnlCollector, false);
            clsCommon.SetVisibility_Panel(pnlUseCustomerMasterSalesPerson, false);
            clsCommon.SetVisibility_Panel(pnlAlloType, false);
            clsCommon.SetVisibility_Panel(pnlType, false);
            clsCommon.SetVisibility_Panel(pnlAllocationNumWise, false);
            clsCommon.SetVisibility_Panel(pnlAllRecords, false);
            clsCommon.SetVisibility_Panel(pnlDate, true);
            clsCommon.SetVisibility_Panel(pnlCreatedUser, false);
            clsCommon.SetVisibility_Panel(pnlShowSettledOnly, false);
            clsCommon.SetVisibility_Panel(pnlUseChequeDate, false);
            clsCommon.SetVisibility_Panel(pnlShowDetailReport, false);
            clsCommon.SetVisibility_Panel(pnlreturnCollection, false);
        }
        #endregion

        #region Print Method

        public  string RemoveNewLinestring(string sTemp)
        {
            string s = sTemp.Replace("\n", "").Trim();
            return s.Replace("\r", "").Trim();
        }
        private void print(string path, string sReportTitle, string sFormula)
        {
            try
            {
                string sFilter = "";
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Cheque Management Reports";
                ReportDocument RD = new ReportDocument();
 
                s_Path = Application.StartupPath.Replace("\\Mini ERP\\bin\\Debug", "\\ZION.ERP.Reports");
                s_Path += path;

                frm_ReportViewer viewer = new frm_ReportViewer();
                RD.Load(s_Path); Digiteq.Classes.ReportHelper.LogonServer(ref RD);
                //clsSecurity.LogonServer(ref RD);
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
                    RD.DataDefinition.FormulaFields["cAddress"].Text = RemoveNewLinestring(clsCommon.fncsetstring(clsGenaralName.getName_CustomerRegisterAddress(txtCustomer.Tag.ToString())));

                }
                #endregion

                string sSeperator = "";
                sFilter += (bCustomerSelected) ? "Customer : " + txtCustomer.Text.Trim() + sSeperator : "";

                sSeperator = sFilter.Length > 0 ? " / " : "";
                sFilter += (bSelesRepSelected) ? "Sales Rep : " + txtSalesRep.Text.Trim() + sSeperator : "";

                sSeperator = sFilter.Length > 0 ? " / " : "";
                sFilter += (bCurrencySelected) ? "Currency : " + cmbCurrency.Text.Trim() + sSeperator : "";

                sSeperator = sFilter.Length > 0 ? " / " : "";
                //  sFilter += (bBankSelected) ? "Bank : " + txtBank.Text.Trim() + sSeperator : "";

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
            clsSearch.Search_MasterCollector(ref txtCollector);
        }

        private void dgvReports_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int iReportID = clsValidate.ValidateGridValue(dgvReports, "report_ID", e.RowIndex, 0);
                setEnableDisableConctrol(iReportID);
            }
        }

        private void txtRoute_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_MasterRoute(ref txtRoute);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Route Search Error", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void txtCreatedUser_DoubleClick(object sender, EventArgs e)
        {
            Form frmhelpsearch = new frmSearchMaster();
            if (clsSecurity.UserIDLoged.Trim().ToUpper() == "DIGITEQ")
                clsSearch.passValue_User(false);
            else
                clsSearch.passValue_User(true);
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtCreatedUser.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                    txtCreatedUser.Tag = frmSearchMaster.s_SearchID;
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

            if (iReportID == (int)enum_ReportName.ST_Collection_Report_Summary
                || iReportID == (int)enum_ReportName.ST_Collection_Report_Detail)
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
                clsCommon.SetVisibility_Panel(pnlCreatedUser, true);
            }

            else if (iReportID == (int)enum_ReportName.RG_Sales_Journal)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
            }

            else if (iReportID == (int)enum_ReportName.ST_Collection_Report_Aging
                || iReportID == (int)enum_ReportName.ST_Collection_Report_Aging_Route
                || iReportID == (int)enum_ReportName.ST_Collection_Report_Aging_Route_Collector
                 || iReportID == (int)enum_ReportName.CU_CollectionReportRouteWise
                )
            {
                clsCommon.SetVisibility_Panel(pnlCurrency, false);
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlCollector, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetVisibility_Panel(pnlUseCustomerMasterSalesPerson, true);
                clsCommon.SetVisibility_Panel(pnlShowSettledOnly, true);
                clsCommon.SetVisibility_Panel(pnlUseChequeDate, true);
                clsCommon.SetVisibility_Panel(pnlreturnCollection, true);
            }

            else if (iReportID == (int)enum_ReportName.ST_Collection_Aging_InvoiceWise ||iReportID == (int)enum_ReportName.ST_Collection_Aging_InvoiceWise_Detail)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlCollector, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
            //    clsCommon.SetVisibility_Panel(pnlShowDetailReport, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_CollectionReport_InvoiceWise)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlCollector, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
           //     clsCommon.SetVisibility_Panel(pnlShowDetailReport, true);
            }
            else if (iReportID == (int)enum_ReportName.RG_Sales_Commission_Detail
                || iReportID == (int)enum_ReportName.RG_Sales_Commission_Statement)
            {
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
            }
            else if (iReportID == (int)enum_ReportName.RG_Sales_Commision_Invoice_wise
                || iReportID == (int)enum_ReportName.ST_Incentive)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
            }

            else if (iReportID == (int)enum_ReportName.RG_Invoice_wise_payment_Tracking_With_Deposited_Detail
                || iReportID == (int)enum_ReportName.RG_Customer_wise_payment_Tracking
                || iReportID == (int)enum_ReportName.RG_Customer_wise_payment_Tracking_New
                || iReportID == (int)enum_ReportName.RG_Customer_wise_payment_Statement
                || iReportID == (int)enum_ReportName.RG_OverPaymentListing
                || iReportID == (int)enum_ReportName.RG_AdvanceListing)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlUseCustomerMasterSalesPerson, true);
            }
            else if (iReportID == (int)enum_ReportName.RG_OverPaymentListing_RouteWise)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlUseCustomerMasterSalesPerson, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
            }
            else if (iReportID == (int)enum_ReportName.RG_Invoice_wise_payment_Tracking)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlUseCustomerMasterSalesPerson, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
            }
            else if (iReportID == (int)enum_ReportName.RG_Receipt_wise_Invoice_Tracking)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlUseCustomerMasterSalesPerson, true);
                chkUseCustomerMastorSaleRep.Checked = true;
            }
            if (iReportID == (int)enum_ReportName.RG_Receipt_Allocation)
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
}