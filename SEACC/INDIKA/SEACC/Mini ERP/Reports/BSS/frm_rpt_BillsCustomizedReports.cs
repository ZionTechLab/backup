using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DataTire;
using Zion.ERP.Reports.DataSets.BSS;
using Zion.ERP.Reports.DataSets;
using System.Diagnostics.Eventing.Reader;

namespace Digiteq
{
    public partial class frm_rpt_BillsCustomizedReports : MettroForm
    {
        


        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        dts_Unspecified glb_dtsUnSpecified = new dts_Unspecified();


        #region Form Load
        public frm_rpt_BillsCustomizedReports()
        {
            iFormID = clsSecurity.getFormID(FormName.ReportCustomized);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }

        private void frm_rpt_BillsCustomizedReports_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Bills Customized Reports", 2, iFormID);
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
                dgvReports.DataSource = DBHandling.ExecQuery("EXEC sp_Reports '" + 33 + "'").Tables[0];
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
                        enum_ReportName Report = (enum_ReportName)iReport;

                        if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(Report)))
                        {
                            string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                            if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(Report), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                            {
                                bool bCustomerSelected = false, bSelesRepSelected = false, bAreamManagerSelected = false, bCollectorSelected = false, bBankAccountSelected = false, bSupplierSelected = false, bRouteSelected = false;

                                #region Fillter
                                if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Trim().Length > 0)
                                    bCustomerSelected = true;
                                if (txtSalesRep.Tag != null && txtSalesRep.Tag.ToString().Trim().Length > 0)
                                    bSelesRepSelected = true;
                                if (txtAreaManager.Tag != null && txtAreaManager.Tag.ToString().Trim().Length > 0)
                                    bAreamManagerSelected = true;
                                if (txtCollector.Tag != null && txtCollector.Tag.ToString().Length > 0)
                                    bCollectorSelected = true;
                                if (txtBankAccount.Tag != null && txtBankAccount.Tag.ToString().Length > 0)
                                    bBankAccountSelected = true;
                                if (txtSupplier.Tag != null && txtSupplier.Tag.ToString().Length > 0)
                                    bSupplierSelected = true;
                                if (txtRoute.Tag != null && txtRoute.Tag.ToString().Length > 0)
                                    bRouteSelected = true;

                                string sFilter = "";

                                if (bCustomerSelected)
                                {
                                    if (sFilter != "")
                                        sFilter += " | ";
                                    sFilter += "Customer Name : " + txtCustomer.Text.Trim();
                                }

                                if (bSelesRepSelected)
                                {
                                    if (sFilter != "")
                                        sFilter += " | ";
                                    sFilter += "Sales Rep Name : " + txtSalesRep.Text.Trim();
                                }

                                if (bAreamManagerSelected)
                                {
                                    if (sFilter != "")
                                        sFilter += " | ";
                                    sFilter += "Area Manager Name : " + txtAreaManager.Text.Trim();
                                }

                                if (bCollectorSelected)
                                {
                                    if (sFilter != "")
                                        sFilter += " | ";
                                    sFilter += "Collector Name : " + txtCollector.Text.Trim();
                                }

                                if (bBankAccountSelected)
                                {
                                    if (sFilter != "")
                                        sFilter += " | ";
                                    sFilter += "Bank Account Number : " + txtBankAccount.Text.ToString();
                                }

                                if (bSupplierSelected)
                                {
                                    if (sFilter != "")
                                        sFilter += " | ";
                                    sFilter += "Supplier Name : " + txtSupplier.Text.Trim();
                                }

                                if (bRouteSelected)
                                {
                                    if (sFilter != "")
                                        sFilter += " | ";
                                    sFilter += "Route Name : " + txtRoute.Text.Trim();
                                }

                                //if (rdoDeleted.Checked)
                                //{
                                //    if (sFilter != "")
                                //        sFilter += " | ";
                                //    sFilter += "Canceled records Only";
                                //}
                                //else if (rdoAll.Checked)
                                //{
                                //    if (sFilter != "")
                                //        sFilter += " | ";
                                //    sFilter += "All Records";
                                //}

                                string sDateRange = "From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "  To : " + dtpTo.Value.ToString("dd MMM yyyy");

                                #endregion

                                #region Unsettled Credit Notes
                                if (Report == enum_ReportName.CU_UnsettledCreditNote)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dtsUnSpecified.Clear();
                                        ProgressBar.Value = 0;
                                        string sSalesmanID = "";
                                        List<tbl_bpsCreditNote> oCRNL = tbl_bpsCreditNote.SelectAll().Where(p => p.CreditNote_ID != "default" &&  !p.IsDeleted && p.CreditNoteDate.Date >= dtpFrom.Value.Date && p.CreditNoteDate.Date <= dtpTo.Value.Date && p.CompanyBranch_ID == clsSecurity.BranchID).ToList();
                                        foreach (tbl_bpsCreditNote oCRN in oCRNL)
                                        {
                                            string sSalesRepID = "";
                                            decimal dUnsettledCreditNoteAmount;

                                            #region Common Filter
                                            //if (rdoDeleted.Checked)
                                            //    if (oCRN.IsDeleted != true)
                                            //        continue;

                                            //if (rdoActive.Checked)
                                            //    if (oCRN.IsDeleted != false)
                                            //        continue;
                                            #endregion

                                            tbl_genCustomerMaster oCustMas = tbl_genCustomerMaster.Select(oCRN.Customer_ID);
                                            if (oCustMas != null)
                                            {
                                                //  sCustomerName = oCustMas.CustomerName;
                                                //  sCustomerID = oCustMas.Customer_ID;
                                                //sSalesRepID = oCustMas.SalesRep_ID;

                                                #region Sales rep
                                                if (!chkUseCustomerMastorSaleRep.Checked)
                                                {
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oCRN.OrderRefNo_ID);
                                                    if (oRef != null && oRef.OrderRefNo != "default")
                                                        sSalesmanID = oRef.Employee_ID;
                                                }
                                                else
                                                    sSalesmanID = oCustMas.SalesRep_ID;

                                                if (bSelesRepSelected)
                                                    if (txtSalesRep.Tag.ToString().Trim() != sSalesmanID)
                                                        continue;
                                                #endregion

                                                #region Customer Filter
                                                if (bCustomerSelected)
                                                    if (oCRN.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                        continue;
                                                #endregion

                                                #region Calculate Unsettled Credit Amount
                                                decimal dSettleTotal = 0;
                                                foreach (tbl_sasInvoice_Sattled oSattle in tbl_sasInvoice_Sattled.SelectAllByCreditNote_ID(oCRN.CreditNote_ID))
                                                {
                                                    dSettleTotal += oSattle.SattledAmount;
                                                }
                                                dUnsettledCreditNoteAmount = oCRN.TotalAmount - dSettleTotal;
                                                #endregion

                                                #region Dataset Fill
                                                glb_dtsUnSpecified.dt_Unspecified_01.Adddt_Unspecified_01Row(oCRN.CreditNote_ID,//CRN NO-S1
                                                  oCustMas.Customer_ID, //Customer ID-S2
                                                  oCustMas.CustomerName, //Customer Name-S3
                                                  clsGenaralName.getName_CreditNoteType(oCRN.CreditNoteType_ID), //CRN Type Name-S4
                                                  "", "", "", "", "", "","","",
                                                  oCRN.TotalAmount, //CRN Amount-D1
                                                  dUnsettledCreditNoteAmount, //Unsettled Amount-D2
                                                  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                                  oCRN.CreditNoteDate,//CRN Date-DT1
                                                  DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, oCRN.IsDeleted, false, false, false);
                                                #endregion

                                                #region Progress Bar
                                                clsHelpMethods_Local.startProgressBar(0, oCRNL.Count + 2, 1, ProgressBar);
                                                #endregion
                                            }
                                        }
                                        glb_dtsUnSpecified.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDateRange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dtsUnSpecified, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glb_dtsUnSpecified.Clear();
                                        ProgressBar.Value = 0;
                                    }
                                }
                                #endregion

                                #region Bank Account Wise Payment Voucher
                                if (Report == enum_ReportName.CU_BankAccountWisePaymentVoucher)
                                {
                                    if (true)
                                    {
                                        try
                                        {
                                            Cursor = Cursors.WaitCursor;
                                            glb_dtsUnSpecified.Clear();

                                            string sAccount = "", sSupplier = "";

                                            if (bBankAccountSelected)
                                                sAccount =txtBankAccount.Tag.ToString();
                                            if (bSupplierSelected)
                                                sSupplier =txtSupplier .Tag.ToString();
                        
                                            #region Fill Dataset
                                            string sQuary = "exec sp_RPT_BankAccountWise_PVCheque '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "','" + dtpTo.Value.ToString("yyyy-MM-dd")+ "','" + sAccount + "','" + sSupplier + "'";
                                            glb_dtsUnSpecified.dt_Unspecified_01.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);
                                            #endregion

                                            glb_dtsUnSpecified.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDateRange, clsSecurity.UserNameLoged, sFilter);

                                            frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                            rpt.print(sReportPath, glb_dtsUnSpecified, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                        }
                                        catch (Exception ex)
                                        {
                                            clsValidate.WriteErrorLog("", iFormID, ex);
                                            SEACCException.Show(ex);
                                        }
                                        finally
                                        {
                                            ProgressBar.Value = 0;
                                            glb_dtsUnSpecified.Clear();
                                            Cursor = Cursors.Default;
                                        }
                                    }
                                    else
                                    {
                                        try
                                        {
                                            Cursor = Cursors.WaitCursor;
                                            glb_dtsUnSpecified.Clear();
                                            ProgressBar.Value = 0;

                                            List<tbl_accPaymentVoucher> oPayments = tbl_accPaymentVoucher.SelectAll().Where(p => p.PaymentVoucher_ID != "default" && !p.IsDeleted && p.PaymentVoucherDate.Date >= dtpFrom.Value.Date && p.PaymentVoucherDate.Date <= dtpTo.Value.Date && p.CompanyBranch_ID == clsSecurity.BranchID).ToList();
                                            foreach (tbl_accPaymentVoucher oPayment in oPayments)
                                            {
                                                string sChequeNo = "", sCrediitNoteTypeName = "", sBankAccountNumber = "", sBankAccountName = "", sBankBranch = "";
                                                decimal dChequeAmount = 0; DateTime dChequeDate = DateTime.MinValue;
                                                #region Supplier Filter
                                                if (bSupplierSelected)
                                                    if (oPayment.Supplier_ID != txtSupplier.Tag.ToString().Trim())
                                                        continue;
                                                #endregion

                                                #region Get Cheque Details
                                                tbl_accChequeRegister oCheque = tbl_accChequeRegister.SelectAllByPaymentVoucher_ID(oPayment.PaymentVoucher_ID).FirstOrDefault();
                                                if (oCheque != null)
                                                {
                                                    sChequeNo = oCheque.ChequeNumber;
                                                    dChequeDate = oCheque.DateCheque;
                                                    dChequeAmount = oCheque.ChequeAmount;

                                                    tbl_genCompanyAccount oBank = tbl_genCompanyAccount.Select(oCheque.CompanyAccount_ID);
                                                    if (oBank != null)
                                                    {
                                                        sBankAccountNumber = oBank.AccountNumber;
                                                        sBankAccountName = clsGenaralName.getName_Bank(oBank.Bank_ID);
                                                        sBankBranch = clsGenaralName.getName_BankBranch(oBank.Branch_ID);

                                                        if (bBankAccountSelected)
                                                            if (oBank.AccountNumber != txtBankAccount.Tag.ToString().Trim())
                                                                continue;
                                                    }
                                                }
                                                #endregion

                                                #region Common Filter
                                                //if (rdoDeleted.Checked)
                                                //    if (oPayment.IsDeleted != true)
                                                //        continue;

                                                //if (rdoActive.Checked)
                                                //    if (oPayment.IsDeleted != false)
                                                //        continue;
                                                #endregion

                                                #region Fill Dataset
                                                if (sBankAccountNumber != "")
                                                {
                                                    glb_dtsUnSpecified.dt_Unspecified_01.Adddt_Unspecified_01Row(
                                                        oPayment.PaymentVoucher_ID,//Payment Voucher No-S1
                                                                  clsGenaralName.getName_Supplier(oPayment.Supplier_ID), //Supplier Name-S2
                                                                  sChequeNo,//Cheque No-S3
                                                                  sBankAccountNumber// Bank Account No - S4
                                                                  , sBankAccountName,//Bank Account Name-S5
                                                                  sBankBranch,//Bank Branch Name-S6
                                                                  "", "", "", "", "", "",
                                                                  dChequeAmount,// Cheque Amount-D1
                                                                  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                                                  oPayment.PaymentVoucherDate,// Voucher Date-DT1 
                                                                  dChequeDate,// Cheque Date-DT2
                                                                  DateTime.MinValue, DateTime.MinValue, oPayment.IsDeleted, false, false, false);

                                                }
                                                #endregion

                                                #region Progress Bar
                                                clsHelpMethods_Local.startProgressBar(0, oPayments.Count + 2, 1, ProgressBar);
                                                #endregion
                                            }
                                            glb_dtsUnSpecified.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDateRange, clsSecurity.UserNameLoged, sFilter);

                                            frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                            rpt.print(sReportPath, glb_dtsUnSpecified, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                        }
                                        catch (Exception ex)
                                        {
                                            clsValidate.WriteErrorLog("", iFormID, ex);
                                            SEACCException.Show(ex);
                                        }
                                        finally
                                        {
                                            Cursor = Cursors.Default;
                                            glb_dtsUnSpecified.Clear();
                                            ProgressBar.Value = 0;
                                        }
                                    }
                                }
                                #endregion

                                #region Invoice Wise Payment Tracking

                                if (Report == enum_ReportName.CU_InvoiceWisePaymentTracking)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dtsUnSpecified.Clear();
                                        string sRouteID = "", sSalesmanID = "";
                                        List<tbl_bpsReceipt> oReceipts = tbl_bpsReceipt.SelectAll().Where(p => p.Receipt_ID != "default" && !p.IsDeleted && p.ReceiptDate.Date >= dtpFrom.Value.Date && p.ReceiptDate.Date <= dtpTo.Value.Date && p.CompanyBranch_ID == clsSecurity.BranchID).ToList();
                                        foreach (tbl_bpsReceipt oReceipt in oReceipts)
                                        {
                                            decimal cheque = 0, cash = 0;
                                            #region Common Filter
                                            //if (rdoDeleted.Checked)
                                            //    if (oReceipt.IsDeleted != true)
                                            //        continue;

                                            //if (rdoActive.Checked)
                                            //    if (oReceipt.IsDeleted != false)
                                            //        continue;
                                            #endregion
                                            string sChequeNo = "", sBankAccountNumber = "", sBankAccountName = "", sBankBranch = "";

                                            decimal dChequeAmount = 0; DateTime dChequeDate = DateTime.MinValue;

                                            if (bCollectorSelected)
                                                if (oReceipt.Collector_ID != txtCollector.Tag.ToString().Trim())
                                                    continue;
                                            if (bCustomerSelected)
                                                if (oReceipt.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                    continue;

                                            #region Sales rep
                                            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oReceipt.Customer_ID);
                                            if (oCustomer != null)
                                            {
                                                if (!chkUseCustomerMastorSaleRep.Checked)
                                                {
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oReceipt.OrderRefNo_ID);
                                                    if (oRef != null && oRef.OrderRefNo != "default")
                                                        sSalesmanID = oRef.Employee_ID;
                                                }
                                                else
                                                    sSalesmanID = oCustomer.SalesRep_ID;
                                            }
                                            if (bSelesRepSelected)
                                                if (txtSalesRep.Tag.ToString().Trim() != sSalesmanID)
                                                    continue;
                                            #endregion

                                            #region Route Filter
                                            if (bRouteSelected)
                                            {
                                                foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oReceipt.Customer_ID).Where(p => p.Route_ID != -1))
                                                {
                                                    sRouteID = oRoute.Route_ID.ToString();
                                                    if (txtRoute.Tag.ToString() == sRouteID)
                                                        break;
                                                }
                                                if (txtRoute.Tag.ToString() != sRouteID)
                                                    continue;
                                            }
                                            #endregion

                                            #region Get Cheque Details
                                            foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID))
                                            {

                                                if (oCheque.PaymentMethod_ID == (int)PaymentMethod.Cash)
                                                    cash = oCheque.Amount;

                                                if (oCheque.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                                                {
                                                    cheque = oCheque.Amount;
                                                    sBankAccountName = clsGenaralName.getName_Bank(oCheque.Bank_ID);
                                                    sChequeNo = oCheque.ChequeNumber;
                                                    dChequeDate = oCheque.DateCheque;
                                                    sBankBranch = clsGenaralName.getName_BankBranch(oCheque.Branch_ID);
                                                }
                                            }
                                            #region Fill Dataset
                                            glb_dtsUnSpecified.dt_Unspecified_01.Adddt_Unspecified_01Row(oReceipt.Receipt_ID,//Receipt No-S1
                                                clsGenaralName.getName_Customer(oReceipt.Customer_ID),//Customer Name-S2
                                                sBankAccountName,//Bank Account Name-S3
                                             sBankBranch,//Branch Name-S4
                                                sChequeNo,//Cheque No-S5
                                                "", "", "", "", "", "", "",
                                                cash,//Cash Collection-D1
                                                cheque,//Cheque Collection-D2
                                                0, 0, 0, 0, 0, 0, 1, 1, 1, 1,
                                                oReceipt.ReceiptDate,//Receipt Date-DT1
                                                dChequeDate,//Cheque Date-DT2
                                                DateTime.MinValue,
                                                DateTime.MinValue,
                                               oReceipt.IsDeleted, false, false, false);
                                            #endregion

                                            #region Progress Bar
                                            clsHelpMethods_Local.startProgressBar(0, oReceipts.Count + 2, 1, ProgressBar);
                                            #endregion
                                        }
                                        #endregion

                                        glb_dtsUnSpecified.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDateRange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dtsUnSpecified, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                        SEACCException.Show(ex);

                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glb_dtsUnSpecified.Clear();
                                        ProgressBar.Value = 0;
                                    }
                                }
                                #endregion



                                #region Deposited Cheque/Cash Summary

                                if (Report == enum_ReportName.CU_DepositedCheque)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dtsUnSpecified.Clear();
                                        string sChequeStatus = "", sCustomerName = "", sSalesmanID = "";
                                        decimal dReIssuedCheques = 0;
                                        ProgressBar.Value = 0;


                                        //Get first 6 account to display
                                        List<tbl_genCompanyAccount> oAccount = tbl_genCompanyAccount.SelectAll().Where(p => p.CompanyAccount_ID != -1).Take(6).ToList();
                                        List<tbl_bpsChequeRegister> oDepositeds = tbl_bpsChequeRegister.SelectAll().Where(p => p.ChequeRegister_ID != "default" && !p.IsDeleted && p.DateDeposited.Date >= dtpFrom.Value.Date && p.DateDeposited.Date <= dtpTo.Value.Date && p.CompanyBranch_ID == clsSecurity.BranchID && (p.IsDepositted || p.IsReIssued)).ToList();
                                        foreach (tbl_bpsChequeRegister oDeposited in oDepositeds)
                                        {
                                            decimal dBankAccount_One = 0, dBankAccount_Two = 0, dBankAccount_Three = 0, dBankAccount_Four = 0, dBankAccount_Five = 0, dBankAccount_Six = 0;
                                            string sBankAccName1 = "", sBankAccName2 = "", sBankAccName3 = "", sBankAccName4 = "", sBankAccName5 = "", sBankAccName6 = "";
                                            DateTime dtDepositedOrReissued = DateTime.MinValue;

                                            #region Common Filter                                               
                                            //if (rdoDeleted.Checked)
                                            //    if (oDeposited.IsDeleted != true)
                                            //        continue;

                                            //if (rdoActive.Checked)
                                            //    if (oDeposited.IsDeleted != false)
                                            //        continue;
                                            #endregion

                                            #region Set Amount For Banks
                                            if (oDeposited.DepositedAccountNumber == oAccount[0].AccountNumber.ToString())
                                            {
                                                dBankAccount_One = oDeposited.Amount;
                                            }
                                            else if (oDeposited.DepositedAccountNumber == oAccount[1].AccountNumber.ToString())
                                            {
                                                dBankAccount_Two = oDeposited.Amount;
                                            }
                                            else if (oDeposited.DepositedAccountNumber == oAccount[2].AccountNumber.ToString())
                                            {
                                                dBankAccount_Three = oDeposited.Amount;
                                            }
                                            else if (oDeposited.DepositedAccountNumber == oAccount[3].AccountNumber.ToString())
                                            {
                                                dBankAccount_Four = oDeposited.Amount;
                                            }
                                            else if (oDeposited.DepositedAccountNumber == oAccount[4].AccountNumber.ToString())
                                            {
                                                dBankAccount_Five = oDeposited.Amount;
                                            }
                                            else if (oDeposited.DepositedAccountNumber == oAccount[5].AccountNumber.ToString())
                                            {
                                                dBankAccount_Six = oDeposited.Amount;
                                            }
                                            #endregion

                                            #region Get Customer Detail
                                            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oDeposited.Customer_ID);
                                            if (oCustomer != null)
                                            {
                                                sCustomerName = oCustomer.CustomerName;

                                                #region Filter Customer                                           
                                                if (bCustomerSelected)
                                                    if (oCustomer.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                        continue;
                                                #endregion
                                            }
                                            #endregion

                                            #region Sales rep
                                            if (!chkUseCustomerMastorSaleRep.Checked)
                                            {
                                                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oDeposited.OrderRefNo_ID);
                                                if (oRef != null && oRef.OrderRefNo != "default")
                                                    sSalesmanID = oRef.Employee_ID;
                                            }
                                            else
                                                sSalesmanID = oCustomer.SalesRep_ID;

                                            if (bSelesRepSelected)
                                                if (txtSalesRep.Tag.ToString().Trim() != sSalesmanID)
                                                    continue;
                                            #endregion

                                            #region Set Deposited Date
                                            dtDepositedOrReissued = oDeposited.DateDeposited;
                                            #endregion

                                            #region Get Cheque Details
                                            tbl_zChequeStatus oStatus = tbl_zChequeStatus.Select(oDeposited.ChequeStatus_ID);
                                            if (oStatus != null)
                                            {
                                                sChequeStatus = clsGenaralName.getName_ChequeStatus(oStatus.ChequeStatus_ID);
                                            }

                                            if (oDeposited.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.ReIssued))
                                            {
                                                dReIssuedCheques = oDeposited.Amount;
                                                dtDepositedOrReissued = oDeposited.DateReIssued;
                                            }
                                            else
                                            {
                                                dReIssuedCheques = 0;
                                            }
                                            #endregion       

                                            #region Fill Dataset
                                            glb_dtsUnSpecified.dt_Unspecified_01.Adddt_Unspecified_01Row(sCustomerName,
                                                oDeposited.ChequeNumber,
                                                sChequeStatus,
                                                "", "", "", "", "", "", "", "", "",
                                                dBankAccount_One,
                                                dBankAccount_Two,
                                                dBankAccount_Three,
                                                dBankAccount_Four,
                                                dBankAccount_Five,
                                                dBankAccount_Six,
                                                dReIssuedCheques,
                                                0, 1, 1, 1, 1,
                                             dtDepositedOrReissued,
                                                oDeposited.DateCheque,
                                                DateTime.MinValue, DateTime.MinValue, oDeposited.IsDeleted, false, false, false); ;
                                            #endregion

                                            #region Progress Bar
                                            clsHelpMethods_Local.startProgressBar(0, oDepositeds.Count + 2, 1, ProgressBar);
                                            #endregion
                                        }


                                        #region Fill Columns Header 
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Acc1Bank", clsGenaralName.getShortName_Bank(oAccount[0].Bank_ID), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Acc1", oAccount[0].AccountNumber.Substring(oAccount[0].AccountNumber.Length - 4, 4), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Acc2Bank", clsGenaralName.getShortName_Bank(oAccount[1].Bank_ID), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Acc2", oAccount[1].AccountNumber.Substring(oAccount[1].AccountNumber.Length - 4, 4), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Acc3Bank", clsGenaralName.getShortName_Bank(oAccount[2].Bank_ID), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Acc3", oAccount[2].AccountNumber.Substring(oAccount[2].AccountNumber.Length - 4, 4), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Acc4Bank", clsGenaralName.getShortName_Bank(oAccount[3].Bank_ID), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Acc4", oAccount[3].AccountNumber.Substring(oAccount[3].AccountNumber.Length - 4, 4), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Acc5Bank", clsGenaralName.getShortName_Bank(oAccount[4].Bank_ID), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Acc5", oAccount[4].AccountNumber.Substring(oAccount[4].AccountNumber.Length - 4, 4), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Acc6Bank", clsGenaralName.getShortName_Bank(oAccount[5].Bank_ID), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Acc6", oAccount[5].AccountNumber.Substring(oAccount[5].AccountNumber.Length - 4, 4), true);
                                        #endregion

                                        glb_dtsUnSpecified.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDateRange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();

                                        rpt.print(sReportPath, glb_dtsUnSpecified, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));


                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glb_dtsUnSpecified.Clear();
                                        ProgressBar.Value = 0;
                                    }
                                }

                                #endregion

                                #region Debtor Outstanding Summary
                                if (Report == enum_ReportName.CU_DebtorOutstanding_Summary || Report == enum_ReportName.CU_DebtorOutstanding_Detail)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dtsUnSpecified.Clear();


                                        string sCustomer = "", sRep = "", sMgr = "", sRoute = "";

                                        if (bCustomerSelected)
                                            sCustomer = txtCustomer.Tag.ToString();
                                        if (bSelesRepSelected)
                                            sRep = txtSalesRep.Tag.ToString();
                                        if (bAreamManagerSelected)
                                            sMgr = txtAreaManager.Tag.ToString();
                                        if (bRouteSelected)
                                            sRoute = txtRoute.Tag.ToString();
                                    

                                        #region Fill Dataset
                                        string sQuary = "exec sp_RPT_CU_DebtorOutstanding '" + sCustomer + "','" + sRep + "','" + sMgr + "','"+ sRoute+"','" + dtpFrom.Value.ToString("yyyy-MM-dd") + "','" + dtpTo.Value.ToString("yyyy-MM-dd") + "'" ;
                                        glb_dtsUnSpecified.dt_Unspecified_01.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);
                                        #endregion

                                        glb_dtsUnSpecified.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDateRange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dtsUnSpecified, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        ProgressBar.Value = 0;
                                        glb_dtsUnSpecified.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID,ex);
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
            txtCustomer.Text = "<<ALL Customers>>";
            txtSalesRep.Text = "<<ALL Salesmans>>";
            txtAreaManager.Text = "<<All Area Managers>>";
            txtSupplier.Text = "<<All Suppliers>>";
            txtBankAccount.Text = "<<All Banks>>";
            txtRoute.Text = "<<All Routes>>";
            txtCollector.Text = "<<All Collectors>>";

            txtCustomer.Tag = null;
            txtSalesRep.Tag = null;
            txtAreaManager.Tag = null;
            txtBankAccount.Tag = null;
            txtSupplier.Tag = null;
            txtRoute.Tag = null;
            txtCollector.Tag = null;
            //rdoActive.Checked = true;

            ckhShowAll.Checked = false;

            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now;
        }
        #endregion     

        #region KeyDown Events
        private void txt_Customer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CustomerID();
        }
        private void txtSalesRep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SalesRepID();
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
        private void txtBankAccount_DoubleClick(object sender, EventArgs e)
        {
            Search_BankAccount();
        }
        private void txtSupplier_DoubleClick(object sender, EventArgs e)
        {
            Search_Supplier();
        }
        private void txtAreaManager_DoubleClick(object sender, EventArgs e)
        {
            Search_AreaManager();
        }
        private void txtRoute_DoubleClick(object sender, EventArgs e)
        {
            Search_RouteName();
        }
        private void txtCollector_DoubleClick(object sender, EventArgs e)
        {
            Search_CollectorName();
        }
        #endregion

        #region Data Grid Event
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
            try
            {
                clsSearch.Search_MasterCustomer(ref txtCustomer, ckhShowAll.Checked);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
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
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_BankAccount()
        {
            try
            {
                clsSearch.SearchMaster_CompanyAccount(ref txtBankAccount, "", "");

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        private void Search_Supplier()
        {
            try
            {
                clsSearch.Search_MasterSupplier(ref txtSupplier);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_AreaManager()
        {
            try
            {
                clsSearch.Search_AreaManager(ref txtAreaManager);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_RouteName()
        {
            try
            {
                clsSearch.Search_MasterRoute(ref txtRoute);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CollectorName()
        {
            try
            {
                clsSearch.Search_MasterCollector(ref txtCollector);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        #endregion

        #region Set Enable/Disable Controls
        public void setEnableDisableConctrol(int iReport)
        {
            clearField();
            clsCommon.SetEnableDisable_NormalTextbox(txtAreaManager, false);
            clsCommon.SetEnableDisable_NormalLabel(lblAreaManger, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtCustomer, false);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomer, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtBankAccount, false);
            clsCommon.SetEnableDisable_NormalLabel(lblBankAccount, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtSalesRep, false);
            clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtSupplier, false);
            clsCommon.SetEnableDisable_NormalLabel(lblSupplier, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtRoute, false);
            clsCommon.SetEnableDisable_NormalLabel(lblRoute, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtCollector, false);
            clsCommon.SetEnableDisable_NormalLabel(lblCollector, false);
            clsCommon.SetEnableDisable_NormalLabel(lblBankAccount, false);

            if (iReport == (int)enum_ReportName.CU_UnsettledCreditNote || iReport == (int)enum_ReportName.CU_DepositedCheque)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);

                //clsCommon.SetEnableDisable_NormalRadioButton(rdoDeleted, true);
                //clsCommon.SetEnableDisable_NormalRadioButton(rdoActive, true);
                //clsCommon.SetEnableDisable_NormalRadioButton(rdoAll, true);
            }
            else if (iReport == (int)enum_ReportName.CU_BankAccountWisePaymentVoucher)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSupplier, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSupplier, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtBankAccount, true);
                clsCommon.SetEnableDisable_NormalLabel(lblBankAccount, true);

                //clsCommon.SetEnableDisable_NormalRadioButton(rdoDeleted, true);
                //clsCommon.SetEnableDisable_NormalRadioButton(rdoActive, true);
                //clsCommon.SetEnableDisable_NormalRadioButton(rdoAll, true);
            }
            else if (iReport == (int)enum_ReportName.CU_CollectionReportRouteWise)
            {

                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtAreaManager, true);
                clsCommon.SetEnableDisable_NormalLabel(lblAreaManger, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCollector, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCollector, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRoute, true);
                clsCommon.SetEnableDisable_NormalLabel(lblRoute, true);

                //clsCommon.SetEnableDisable_NormalRadioButton(rdoDeleted, true);
                //clsCommon.SetEnableDisable_NormalRadioButton(rdoActive, true);
                //clsCommon.SetEnableDisable_NormalRadioButton(rdoAll, true);
            }
            else if (iReport == (int)enum_ReportName.CU_InvoiceWisePaymentTracking)
            {

                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCollector, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCollector, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRoute, true);
                clsCommon.SetEnableDisable_NormalLabel(lblRoute, true);

                //clsCommon.SetEnableDisable_NormalRadioButton(rdoDeleted, true);
                //clsCommon.SetEnableDisable_NormalRadioButton(rdoActive, true);
                //clsCommon.SetEnableDisable_NormalRadioButton(rdoAll, true);
            }
            else if (iReport == (int)enum_ReportName.CU_DebtorOutstanding_Summary || 
                iReport == (int)enum_ReportName.CU_DebtorOutstanding_Detail)
            {
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtAreaManager, true);
           //     clsCommon.SetEnableDisable_NormalLabel(lblAreaManger, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRoute, true);
                clsCommon.SetEnableDisable_NormalLabel(lblRoute, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
            }
        }
        #endregion  
    }
} 