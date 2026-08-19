using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DataTire;
using Digiteq.DataSets.BSS;
using Digiteq.DataSets;

namespace Digiteq
{
    public partial class frm_rpt_BankManagementReports : MettroForm
    {
        #region Variables
        //form manage
        public int iFormID;
        dts_CashDeposit glb_dts_CD = new dts_CashDeposit();
        dts_ChequeDeposit glb_dts_ChqD = new dts_ChequeDeposit();

        dts_bssRegister glb_dts_bssRegister = new dts_bssRegister();

        dtsBills glbDtsBills = new dtsBills();

        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        enum_ReportName Report;

        //for security handle
        public bool bNoAccess;

        bool bCustomerSelected = false, bBankSelected = false, bSelesRepSelected = false, bAccountSelected = false, bCreditNoteTypeSelected = false, bReceiptTypeSelected = false, bChequeNoSelected = false;

        #endregion

        #region Form Load
        public frm_rpt_BankManagementReports()
        {
            iFormID = clsSecurity.getFormID(FormName.ReportBankManagement);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;


            InitializeComponent();
        }
        private void frm_rpt_BankManagementReports_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Bank Management Reports", 2, iFormID);
            clearField();

            DisplayReports();

            AddItemToTypeComboBox(cmbCustomerType);
        }
        #endregion

        #region Display Reports
        private void DisplayReports()
        {
            try
            {
                dgvReports.Rows.Clear();
                dgvReports.DataSource = DBHandling.ExecQuery("EXEC sp_Reports '" + 23 + "'").Tables[0];
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
                        string dateRange = "From " + dtpFrom.Value.Date.ToString("dd-MMM-yyyy") + " to " + dtpTo.Value.Date.ToString("dd-MMM-yyyy");

                        if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(Report)))
                        {
                            string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                            if (clsHelpMethods.GetReportPath(clsAutocode.getReportID(Report), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                            {
                                #region Filters
                                bCustomerSelected = false; bBankSelected = false; bSelesRepSelected = false; bAccountSelected = false; bCreditNoteTypeSelected = false; bReceiptTypeSelected = false;
                                string sFormula = "", sFilter = "";
                                string sDaterange = "From " + dtpFrom.Value.Date.ToString("dd-MMM-yyyy") + " To " + dtpTo.Value.Date.ToString("dd-MMM-yyyy");

                                if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Trim().Length > 0)
                                {
                                    bCustomerSelected = true;
                                    sFilter += (sFilter != "" ? " | " : "") + "Customer : " + txtCustomer.Text.Trim();
                                }
                                if (txtBankAccNo.Tag != null && txtBankAccNo.Tag.ToString().Trim().Length > 0)
                                {
                                    bAccountSelected = true;
                                    sFilter += (sFilter != "" ? " | " : "") + "Bank Account No: " + txtBankAccNo.Text.Trim();
                                }
                                //if (txtDepositAccountNo.Tag != null && txtDepositAccountNo.Tag.ToString().Trim().Length > 0)
                                //{
                                //    bAccountSelected = true;
                                //    sFilter += (sFilter != "" ? " | " : "") + "Deposite Account No : " + txtDepositAccountNo.Text.Trim();
                                //}
                                if (txtSalesRep.Tag != null && txtSalesRep.Tag.ToString().Trim().Length > 0)
                                {
                                    bSelesRepSelected = true;
                                    sFilter += (sFilter != "" ? " | " : "") + "Sales Rep : " + txtSalesRep.Text.Trim();
                                }
                                if (txtCreditNoteType.Tag != null && txtCreditNoteType.Tag.ToString().Trim().Length > 0)
                                {
                                    bCreditNoteTypeSelected = true;
                                }
                                if (txtChequeNo.Tag != null && txtChequeNo.Tag.ToString().Trim().Length > 0)
                                {
                                    bChequeNoSelected = true;
                                    sFilter += (sFilter != "" ? " | " : "") + "Cheque No : " + txtChequeNo.Text.Trim();
                                }
                                if (cmbReceiptType.Text != null && cmbReceiptType.Text.ToString().Length > 0)
                                {
                                    bReceiptTypeSelected = true;
                                    //   sFilter += (sFilter != "" ? " | " : "") + "Receipt type : " + cmbReceiptType.Text.Trim();
                                }
                                #endregion

                                #region Cheque Register-Weekly
                                if (Report == enum_ReportName.RG_ChequeRegisterCheque_Weekly_ByReceiptDate)
                                {
                                    sFormula = " {vw_rpt_bpsChequeRegister.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsChequeRegister.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                    if (bCustomerSelected)
                                        sFormula += "and {vw_rpt_bpsChequeRegister.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";

                                    if (bBankSelected)
                                        sFormula += "and {vw_rpt_bpsChequeRegister.bank_ID} = '" + txtBankAccNo.Tag.ToString().Trim() + "'";

                                    if (bCreditNoteTypeSelected)
                                        sFormula += "and {vw_rpt_bpsChequeRegister.typeName} = '" + txtCreditNoteType.Tag.ToString().Trim() + "'";

                                    if (bSelesRepSelected)
                                        sFormula += "and {vw_rpt_bpsChequeRegister.salesRep_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";

                                    //if (bReceiptTypeSelected)
                                    //    sFormula += "and {vw_rpt_bpsChequeRegister.typeName} = '" + cmbReceiptType.Text.ToString().Trim() + "'";

                                    if (rdoDeleted.Checked)
                                        sFormula += " and {vw_rpt_bpsChequeRegister.isDeleted} = True";
                                    if (rdoActive.Checked)
                                        sFormula += " and {vw_rpt_bpsChequeRegister.isDeleted} = False";

                                    print(sReportPath, sReportTitle_Main, sFormula, sFilter);
                                    //glb_dts_ChqD.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sRptName, "", dateRange, clsSecurity.UserNameLoged, sFilter);
                                    //frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                    //rpt.print(sRptPath, glb_dts_ChqD, glb_dtsReportExport.dt_rptParameter);                                  
                                }
                                #endregion

                                #region Cheque Registered Cheque Daily
                                else if (Report == enum_ReportName.RG_ChequeRegisteredCheque_Daily)
                                {
                                    sFormula = " {vw_rpt_bpsChequeRegister.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsChequeRegister.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                    if (bCustomerSelected)
                                        sFormula += "and {vw_rpt_bpsChequeRegister.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";

                                    if (bBankSelected)
                                        sFormula += "and {vw_rpt_bpsChequeRegister.bank_ID} = '" + txtBankAccNo.Tag.ToString().Trim() + "'";

                                    if (bCreditNoteTypeSelected)
                                        sFormula += "and {vw_rpt_bpsChequeRegister.typeName} = '" + txtCreditNoteType.Tag.ToString().Trim() + "'";

                                    if (bSelesRepSelected)
                                        sFormula += "and {vw_rpt_bpsChequeRegister.salesRep_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";

                                    if (rdoDeleted.Checked)
                                    {
                                        sFormula += " and {vw_rpt_bpsChequeRegister.isDeleted} = True";
                                        if (rdoActive.Checked)
                                            sFormula += " and {vw_rpt_bpsChequeRegister.isDeleted} = False";
                                    }
                                    //glb_dts_ChqD.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", dateRange, clsSecurity.UserNameLoged, sFilter);
                                    //frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                    //rpt.print(sRptPath, glb_dts_ChqD, glb_dtsReportExport.dt_rptParameter);
                                    print(sReportPath, sReportTitle_Main, sFormula, sFilter);
                                }
                                #endregion

                                #region Cheque Registered Cheque_Weekly
                                else if (Report == enum_ReportName.RG_ChequeRegisteredCheque_Weekly_ByChequeDate)
                                {
                                    sFormula = " {vw_rpt_bpsChequeRegister.pd_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsChequeRegister.pd_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                    if (bCustomerSelected)
                                        sFormula += "and {vw_rpt_bpsChequeRegister.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";

                                    if (bBankSelected)
                                        sFormula += "and {vw_rpt_bpsChequeRegister.bank_ID} = '" + txtBankAccNo.Tag.ToString().Trim() + "'";

                                    if (bSelesRepSelected)
                                        sFormula += "and {vw_rpt_bpsChequeRegister.salesRep_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";

                                    if (rdoDeleted.Checked)
                                        sFormula += " and {vw_rpt_bpsChequeRegister.isDeleted} = True";
                                    if (rdoActive.Checked)
                                        sFormula += " and {vw_rpt_bpsChequeRegister.isDeleted} = False";

                                    sFormula += " and {vw_rpt_bpsChequeRegister.companyBranch_ID} = '" + clsSecurity.BranchID + "'";

                                    glb_dts_ChqD.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", dateRange, clsSecurity.UserNameLoged, sFilter);
                                    //frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                    //rpt.print(sRptPath, glb_dts_ChqD, glb_dtsReportExport.dt_rptParameter);
                                    print(sReportPath, sReportTitle_Main, sFormula, sFilter);
                                }
                                #endregion

                                #region Deposited Cheques Bank Acct_Wise
                                else if (Report == enum_ReportName.RG_DepositedChequesBankAcct_Wise)
                                {
                                    try
                                    {
                                        sFilter = "";
                                        string dateRange2 = "From " + dtpFrom.Value.Date.ToString("dd-MMM-yyyy") + " TO " + dtpTo.Value.Date.ToString("dd-MMM-yyyy");

                                        glb_dts_ChqD.Clear();
                                        glb_dtsReportExport.Clear();
                                        Cursor = Cursors.WaitCursor;

                                        List<tbl_bpsChequeDeposit> oChqDeps = tbl_bpsChequeDeposit.SelectAll().Where(d => d.DateDeposit.Date >= dtpFrom.Value.Date && d.DateDeposit.Date <= dtpTo.Value.Date).ToList();
                                        #region Filters
                                        string sCustomerID = "%";
                                        string sSalesRepID = "%";
                                        int isDeleted = 0;

                                        if (txtBankAccNo.Tag != null)
                                        {
                                            sFilter += " Bank Account:" + txtBankAccNo.Text;
                                            oChqDeps = oChqDeps.Where(b => b.AccountNumber == txtBankAccNo.Tag.ToString()).ToList();
                                        }

                                        if (txtCustomer.Tag != null)
                                        {
                                            sCustomerID = txtCustomer.Tag.ToString();
                                            sFilter += " Customer :" + txtCustomer.Text;
                                        }
                                        if (txtSalesRep.Tag != null)
                                        {
                                            sSalesRepID = txtSalesRep.Tag.ToString();
                                            sFilter += " Sales Rep :" + txtSalesRep.Text;
                                        }
                                        if (rdoDeleted.Checked)
                                        {
                                            isDeleted = 1;
                                        }
                                        if (rdoActive.Checked)
                                        {
                                            isDeleted = 0;
                                        }
                                        #endregion

                                        foreach (tbl_bpsChequeDeposit oDetail in oChqDeps)
                                        {
                                            glb_dts_ChqD.dt_bpsChequeDeposit.Adddt_bpsChequeDepositRow(oDetail.ChequeDeposit_ID, oDetail.Remark, oDetail.DateDeposit, oDetail.TotalCheque, oDetail.TotalAmount, oDetail.AccountHolder, oDetail.AccountNumber, oDetail.Bank_ID, clsGenaralName.getName_Bank(oDetail.Bank_ID), oDetail.Branch_ID, clsGenaralName.getName_BankBranch(oDetail.Branch_ID));
                                        }
                                        string sQuary = "sp_getDepositedChequeSummary '" + clsSecurity.CompanyID + "' , '" + clsSecurity.BranchID + "' , '" + dtpFrom.Value.Date + "', '" + dtpTo.Value.Date + "'  , '" + sCustomerID + "', '" + sSalesRepID + "' , '" + isDeleted + "'";
                                        glb_dts_ChqD.dt_bpsChequeDeposit_Detail.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                                        glb_dts_ChqD.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", dateRange, clsSecurity.UserNameLoged, sFilter);
                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dts_ChqD, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception)
                                    {
                                        throw;
                                    }
                                    finally
                                    {
                                        glb_dts_ChqD.Clear();
                                        glb_dtsReportExport.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Cheques Tracking
                                //else if (rdoChequeTracking.Checked)
                                //{
                                //if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_ChequeTracking)))
                                //{

                                //        try
                                //        {
                                //            string sReportTitle_Main = "", sReportTitle_Sub = "";
                                //            string sRptPath = clsHelpMethods.GetReportPath(clsAutocode.getReportID(enum_ReportName.RG_ChequeTracking), ref sReportTitle_Main, ref sReportTitle_Sub);

                                //            if (sRptPath != "")
                                //            {
                                //                sFilter = "";
                                //                string dateRange = "From " + dtpFrom.Value.Date.ToString("dd-MMM-yyyy") + " TO " + dtpTo.Value.Date.ToString("dd-MMM-yyyy");

                                //                glb_dts_ChqD.Clear();
                                //                glb_dtsReportExport.Clear();
                                //                Cursor = Cursors.WaitCursor;

                                //            List<tbl_bpsChequeRegister> oChqDeps = tbl_bpsChequeRegister.SelectAll().Where(d => d.DateCheque.Date >= dtpFrom.Value.Date && d.DateCheque.Date <= dtpTo.Value.Date).ToList();

                                //            #region Filters
                                //            string sCustomerID = "%";
                                //            string sSalesRepID = "%";
                                //            int isDeleted = 0;

                                //            if (txtBankAccNo.Tag != null)
                                //            {
                                //                sFilter += " Bank :" + txtBankAccNo.Text;
                                //                oChqDeps = oChqDeps.Where(b => b.Bank_ID == txtBankAccNo.Tag.ToString()).ToList();
                                //            }
                                //            //if (txtDepositAccountNo.Tag != null)
                                //            //{
                                //            //    sFilter += " Acc No :" + txtDepositAccountNo.Text;
                                //            //    oChqDeps = oChqDeps.Where(b => b.AccountNumber == txtDepositAccountNo.Text).ToList();
                                //            //}
                                //            if (txtCustomer.Tag != null)
                                //            {
                                //                sCustomerID = txtCustomer.Tag.ToString();
                                //                sFilter += " Customer :" + txtCustomer.Text;
                                //            }
                                //            if (txtSalesRep.Tag != null)
                                //            {
                                //                sSalesRepID = txtSalesRep.Tag.ToString();
                                //                sFilter += " Sales Rep :" + txtSalesRep.Text;
                                //            }
                                //            if (rdoDeleted.Checked)
                                //            {
                                //                isDeleted = 1;
                                //            }
                                //            if (rdoDeleted.Checked)
                                //            {
                                //                isDeleted = 0;
                                //            }
                                //            #endregion

                                //            //foreach (tbl_bpsChequeDeposit oDetail in oChqDeps)
                                //            //{
                                //            //    glb_dts_ChqD.dt_bpsChequeDeposit.Adddt_bpsChequeDepositRow(oDetail.ChequeDeposit_ID, oDetail.Remark, oDetail.DateDeposit, oDetail.TotalCheque, oDetail.TotalAmount, oDetail.AccountHolder, oDetail.AccountNumber, oDetail.Bank_ID, clsGenaralName.getName_Bank(oDetail.Bank_ID), oDetail.Branch_ID, clsGenaralName.getName_BankBranch(oDetail.Branch_ID));
                                //            //}
                                //            //string sQuary = "sp_ChequeTracking '" + clsSecurity.CompanyID + "' , '" + clsSecurity.BranchID + "' , '" + dtpFrom.Value.Date + "', '" + dtpTo.Value.Date + "'  , '" + sCustomerID + "', '" + sSalesRepID + "' , '" + isDeleted + "'";
                                //            string sQuary = "sp_ChequeTracking '" + clsSecurity.CompanyID + "' , '" + clsSecurity.BranchID + "' , '" + dtpFrom.Value.Date + "', '" + dtpTo.Value.Date + "'  , '"+txtBankAccNo.Tag.ToString()+ "', '" + sCustomerID + "' , 'Realized'";
                                //            glb_dts_bssRegister.dt_ChequeTracking.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);
                                //            glb_dts_bssRegister.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), " Cheque tracking Report", "", dateRange, clsSecurity.UserNameLoged, "");

                                //                ////foreach po table and fill dataset
                                //                //foreach (tbl_sasCustomerOrder detail in tbl_sasCustomerOrder.SelectAll().Where(p => p.CustomerOrder_ID != "default"))
                                //                //{
                                //                //    glb_dts_sasCustomerOrder.dt_sasCustomerOrder.Adddt_sasCustomerOrderRow(detail.CustomerOrder_ID, detail.CustomerOrderDate, detail.DeliveryDate.Date, detail.DeliveryAddress, clsGenaralName.getName_Customer(detail.Customer_ID), clsGenaralName.getName_Employee(detail.Employee_ID), detail.Remark, detail.Customer_ID, "p_Date", detail.GrandTotal, detail.SubTotal, detail.DiscountTotal, detail.NbtTotal, detail.VatTotal, detail.OtherTaxTotal, detail.AdvanceAmount, detail.Quotation_ID, detail.PurchaseOrder_ID, detail.DiscountPercentage, detail.NbtPercentage, detail.VatPercentage, detail.OtherTaxPercentage, "", "", detail.IsWeightCalculation, detail.IsSeattled, detail.IsDeleted, detail.IsApproved, "", "", "", "", detail.Employee_ID, clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID), "", "", "");
                                //                //}
                                //                //glb_dts_sasCustomerOrder.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                                //                frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                //                rpt.print(sRptPath, glb_dts_bssRegister, glb_dtsReportExport.dt_rptParameter);
                                //            }
                                //        }
                                //        catch (Exception)
                                //        {
                                //            throw;
                                //        }
                                //        finally
                                //        {
                                //            glb_dts_ChqD.Clear();
                                //            glb_dtsReportExport.Clear();
                                //            Cursor = Cursors.Default;
                                //        }
                                //}
                                //}
                                #endregion

                                #region Deposited Cash Summary
                                else if (Report == enum_ReportName.RG_DepositedCashBankAcct_Wise)
                                {
                                    glb_dts_CD.Clear();
                                    Cursor = Cursors.WaitCursor;

                                    bool bIsDeleted = false;

                                    if (rdoDeleted.Checked)
                                        bIsDeleted = true;
                                    if (rdoActive.Checked)
                                        bIsDeleted = false;

                                    List<tbl_bpsCashDeposit> oCashDeps = tbl_bpsCashDeposit.SelectAll().Where(p => p.CashDeposit_ID != "default" && p.DateDeposit.Date >= dtpFrom.Value.Date && p.DateDeposit.Date <= dtpTo.Value.Date).ToList();

                                    if (bAccountSelected)
                                    {
                                        oCashDeps = oCashDeps.Where(p => p.AccountNumber == txtBankAccNo.Tag.ToString()).ToList();
                                        sFilter = "Bank Account No." + txtBankAccNo.Text;
                                    }

                                    foreach (tbl_bpsCashDeposit oDetail in oCashDeps)
                                    {
                                        bool bHasRow = false;
                                        if (oDetail != null)
                                        {
                                            foreach (tbl_bpsCashDeposit_Detail oCDetail in tbl_bpsCashDeposit_Detail.SelectAllByCashDeposit_ID(oDetail.CashDeposit_ID))
                                            {
                                                string sCustomerName = "", sCustomerID = "";
                                                bool bIsDeposit = false, bIsAccountReceipt = false;
                                                decimal dCashAmount = oCDetail.DepositedAmount;

                                                #region Sales receipt
                                                tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(oCDetail.Receipt_ID);
                                                if (oReceipt != null)
                                                {
                                                    sCustomerName = clsGenaralName.getName_Customer(oReceipt.Customer_ID);
                                                    sCustomerID = oReceipt.Customer_ID;
                                                    bIsDeposit = oReceipt.IsCashDeposited;

                                                    //foreach (tbl_bpsChequeRegister oChequeRegister in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID))
                                                    //{
                                                    //    if (oChequeRegister.PaymentMethod_ID == 0)
                                                    //        dCashAmount = oChequeRegister.DepositedCashAmount;
                                                    //}

                                                    //dCashAmount = oCDetail.DepositedAmount;
                                                    //dCashAmount = oReceipt.CashAmount;
                                                }
                                                #endregion

                                                #region Acc Recp
                                                else
                                                {
                                                    tbl_accAccountReceipt oAReceipt = tbl_accAccountReceipt.Select(oCDetail.Receipt_ID);
                                                    if (oAReceipt != null)
                                                    {
                                                        if (oAReceipt.Customer_ID != "default")
                                                        {
                                                            sCustomerName = clsGenaralName.getName_Customer(oAReceipt.Customer_ID);
                                                            sCustomerID = oAReceipt.Customer_ID;
                                                        }
                                                        else
                                                        {
                                                            sCustomerName = oAReceipt.Receivedof;
                                                            sCustomerID = "N/A";
                                                        }
                                                        bIsDeposit = oAReceipt.IsCashDeposited;
                                                        //dCashAmount = oAReceipt.CashAmount;
                                                        //dCashAmount = oAReceipt.DepositedCashAmount;
                                                        bIsAccountReceipt = true;
                                                    }
                                                }
                                                #endregion

                                                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(sCustomerID);
                                                if (oCustomer != null)
                                                {
                                                    if (!chkAllBranches.Checked)
                                                    {
                                                        if (oCustomer.CompanyID.ToLower() != clsSecurity.CompanyID.ToLower() || oCustomer.CompanyBranch_ID != clsSecurity.BranchID)
                                                            continue;
                                                    }

                                                    if (txtCustomer.Tag != null)
                                                    {
                                                        if (oCustomer.Customer_ID != txtCustomer.Tag.ToString())
                                                            continue;
                                                    }
                                                    if (txtSalesRep.Tag != null)
                                                    {
                                                        if (oCustomer.SalesRep_ID != txtSalesRep.Tag.ToString().Trim())
                                                            continue;
                                                    }

                                                    //glb_dts_CD.dt_bpsCashDeposite_detail.Rows.Add(oCDetail.Line_No, oCDetail.CashDeposit_ID, oCDetail.Receipt_ID, sCustomerName, sCustomerID, bIsDeposit, dCashAmount);
                                                    bHasRow = true;
                                                }

                                                glb_dts_CD.dt_bpsCashDeposite_detail.Rows.Add(oCDetail.Line_No, oCDetail.CashDeposit_ID, oCDetail.Receipt_ID, clsSecurity.getServerDateTime(), sCustomerName, sCustomerID, bIsDeposit, dCashAmount, bIsAccountReceipt);
                                            }
                                            //if (bHasRow)
                                            //{
                                            glb_dts_CD.dt_bpsCashDeposite.Rows.Add(oDetail.CashDeposit_ID, clsGenaralName.getName_Bank(oDetail.Bank_ID), clsGenaralName.getName_BankBranch(oDetail.Branch_ID), oDetail.DateDeposit, "", oDetail.TotalAmount, oDetail.Bank_ID, oDetail.AccountNumber);
                                            //}
                                        }

                                    }

                                    glb_dts_CD.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "Deposited Cash Summary", "", sDaterange, clsSecurity.UserNameLoged, sFilter);

                                    Cursor = Cursors.Default;

                                    glb_dts_CD.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", dateRange, clsSecurity.UserNameLoged, sFilter);
                                    frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                    rpt.print(sReportPath, glb_dts_CD, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                    //print("\\reports\\BSS\\Registry\\rpt_sas_Deposited_CashSummary_DepositSlipWise.rpt", "", glb_dts_CD, sFilter);
                                }
                                #endregion

                                #region Deposited Cash Detail
                                else if (Report == enum_ReportName.RG_DepositedCashBankAcct_Wise_Detail)
                                {
                                    glb_dts_CD.Clear();
                                    Cursor = Cursors.WaitCursor;

                                    bool bIsDeleted = false;

                                    if (rdoDeleted.Checked)
                                        bIsDeleted = true;
                                    if (rdoActive.Checked)
                                        bIsDeleted = false;

                                    List<tbl_bpsCashDeposit> oCashDeps = tbl_bpsCashDeposit.SelectAll().Where(p => p.CashDeposit_ID != "default" && p.DateDeposit.Date >= dtpFrom.Value.Date && p.DateDeposit.Date <= dtpTo.Value.Date).ToList();

                                    if (bAccountSelected)
                                    {
                                        oCashDeps = oCashDeps.Where(p => p.AccountNumber == txtBankAccNo.Tag.ToString()).ToList();
                                        sFilter = "Bank Account No." + txtBankAccNo.Text;
                                    }

                                    foreach (tbl_bpsCashDeposit oDetail in oCashDeps)
                                    {
                                        bool bHasRow = false;
                                        if (oDetail != null)
                                        {
                                            foreach (tbl_bpsCashDeposit_Detail oCDetail in tbl_bpsCashDeposit_Detail.SelectAllByCashDeposit_ID(oDetail.CashDeposit_ID))
                                            {
                                                string sCustomerName = "", sCustomerID = "";
                                                bool bIsDeposit = false;
                                                decimal dCashAmount = oCDetail.DepositedAmount;
                                                DateTime dReceiptDate = clsSecurity.getServerDateTime();

                                                #region Sales receipt
                                                tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(oCDetail.Receipt_ID);
                                                if (oReceipt != null)
                                                {
                                                    sCustomerName = clsGenaralName.getName_Customer(oReceipt.Customer_ID);
                                                    sCustomerID = oReceipt.Customer_ID;
                                                    bIsDeposit = oReceipt.IsCashDeposited;

                                                    //foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oCDetail.Receipt_ID).Where(p => p.PaymentMethod_ID == 0))
                                                    //{
                                                    //    dCashAmount = oCheque.DepositedCashAmount;
                                                    //}
                                                    //dCashAmount = oReceipt.CashAmount;
                                                    dReceiptDate = oReceipt.ReceiptDate;
                                                }
                                                #endregion

                                                #region Acc Recp
                                                else
                                                {
                                                    tbl_accAccountReceipt oAReceipt = tbl_accAccountReceipt.Select(oCDetail.Receipt_ID);
                                                    if (oAReceipt != null)
                                                    {
                                                        if (oAReceipt.Customer_ID != "default")
                                                        {
                                                            sCustomerName = clsGenaralName.getName_Customer(oAReceipt.Customer_ID);
                                                            sCustomerID = oAReceipt.Customer_ID;
                                                        }
                                                        else
                                                        {
                                                            sCustomerName = oAReceipt.Receivedof;
                                                            sCustomerID = "N/A";
                                                        }
                                                        bIsDeposit = oAReceipt.IsCashDeposited;
                                                        //dCashAmount = oAReceipt.DepositedCashAmount;
                                                        dReceiptDate = oAReceipt.AccountReceiptDate;
                                                    }
                                                }
                                                #endregion

                                                #region Customer
                                                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(sCustomerID);
                                                if (oCustomer != null)
                                                {
                                                    if (!chkAllBranches.Checked)
                                                    {
                                                        if (oCustomer.CompanyID.ToLower() != clsSecurity.CompanyID.ToLower() || oCustomer.CompanyBranch_ID != clsSecurity.BranchID)
                                                            continue;
                                                    }

                                                    if (txtCustomer.Tag != null)
                                                    {
                                                        if (oCustomer.Customer_ID != txtCustomer.Tag.ToString())
                                                            continue;
                                                    }
                                                    if (txtSalesRep.Tag != null)
                                                    {
                                                        if (oCustomer.SalesRep_ID != txtSalesRep.Tag.ToString().Trim())
                                                            continue;
                                                    }

                                                    bHasRow = true;
                                                }
                                                #endregion

                                                glb_dts_CD.dt_bpsCashDeposite_detail.Rows.Add(oCDetail.Line_No, oCDetail.CashDeposit_ID, oCDetail.Receipt_ID, dReceiptDate, sCustomerName, sCustomerID, bIsDeposit, dCashAmount, false);
                                            }
                                            glb_dts_CD.dt_bpsCashDeposite.Rows.Add(oDetail.CashDeposit_ID, clsGenaralName.getName_Bank(oDetail.Bank_ID), clsGenaralName.getName_BankBranch(oDetail.Branch_ID), oDetail.DateDeposit, "", oDetail.TotalAmount, oDetail.Bank_ID, oDetail.AccountNumber);
                                        }

                                    }
                                    glb_dts_CD.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "Deposited Cash Details", "", sDaterange, clsSecurity.UserNameLoged, sFilter);

                                    Cursor = Cursors.Default;
                                    glb_dts_ChqD.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", dateRange, clsSecurity.UserNameLoged, sFilter);
                                    print(sReportPath, sReportTitle_Main, glb_dts_CD, sFilter);
                                }
                                #endregion

                                #region Re-Issued Cheque Summary
                                else if (Report == enum_ReportName.RG_ReIssuedChequesSummary)
                                {
                                    sFormula = " {vw_rpt_bpsChequeReIssue.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsChequeReIssue.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                    if (bCustomerSelected)
                                        sFormula += "and {vw_rpt_bpsChequeReIssue_Detail.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";

                                    if (bBankSelected)
                                        sFormula += "and {vw_rpt_bpsChequeReIssue.bank_ID} = '" + txtBankAccNo.Tag.ToString().Trim() + "'";

                                    if (rdoDeleted.Checked)
                                        sFormula += " and {vw_rpt_bpsChequeReIssue_Detail.isDeleted} = True";
                                    if (rdoActive.Checked)
                                        sFormula += " and {vw_rpt_bpsChequeReIssue_Detail.isDeleted} = False";

                                    sFormula += " and {vw_rpt_bpsChequeReIssue_Detail.isReIssued} = True";

                                    glb_dts_ChqD.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", dateRange, clsSecurity.UserNameLoged, sFilter);
                                    //frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                    //rpt.print(sRptPath, glb_dts_ChqD, glb_dtsReportExport.dt_rptParameter);
                                    print(sReportPath, sReportTitle_Main, sFormula, sFilter);
                                }
                                #endregion

                                #region Re-Issued Cheque Daily Summary
                                else if (Report == enum_ReportName.RG_REIssuedChequesDaily)
                                {
                                    sFormula = " {vw_rpt_bpsChequeReIssue.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsChequeReIssue.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                    if (bCustomerSelected)
                                        sFormula += "and {vw_rpt_bpsChequeReIssue_Detail.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";

                                    if (bBankSelected)
                                        sFormula += "and {vw_rpt_bpsChequeReIssue.bank_ID} = '" + txtBankAccNo.Tag.ToString().Trim() + "'";

                                    if (rdoDeleted.Checked)
                                        sFormula += " and {vw_rpt_bpsChequeReIssue_Detail.isDeleted} = True";
                                    if (rdoActive.Checked)
                                        sFormula += " and {vw_rpt_bpsChequeReIssue_Detail.isDeleted} = False";

                                    sFormula += " and {vw_rpt_bpsChequeReIssue_Detail.isReIssued} = True";

                                    glb_dts_ChqD.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", dateRange, clsSecurity.UserNameLoged, sFilter);
                                    //frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                    //rpt.print(sRptPath, glb_dts_ChqD, glb_dtsReportExport.dt_rptParameter);
                                    print(sReportPath, sReportTitle_Main, sFormula, sFilter);
                                }
                                #endregion

                                #region Re-Deposited Cheque Summary
                                else if (Report == enum_ReportName.RG_RedepositChequesBankAcct_Wise)
                                {
                                    sFormula = " {vw_rpt_bpsChequeDeposit.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsChequeDeposit.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                    if (bCustomerSelected)
                                        sFormula += "and {vw_rpt_bpsChequeDeposit.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";

                                    //if (bBankSelected)
                                    //sFormula += "and {vw_rpt_bpsChequeDeposit.bank_ID} = '" + txtBankAccNo.Tag.ToString().Trim() + "'";
                                    if (bAccountSelected)
                                        sFormula += "and {vw_rpt_bpsChequeDeposit.accountNumber} = '" + txtBankAccNo.Tag.ToString().Trim() + "'";

                                    if (rdoDeleted.Checked)
                                        sFormula += " and {vw_rpt_bpsChequeDeposit_Detail.isDeleted} = True";
                                    if (rdoActive.Checked)
                                        sFormula += " and {vw_rpt_bpsChequeDeposit_Detail.isDeleted} = False";

                                    sFormula += " and {vw_rpt_bpsChequeDeposit_Detail.isRedeposit} = True";

                                    glb_dts_ChqD.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", dateRange, clsSecurity.UserNameLoged, sFilter);
                                    //frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                    //rpt.print(sRptPath, glb_dts_ChqD, glb_dtsReportExport.dt_rptParameter);
                                    print(sReportPath, sReportTitle_Main, sFormula, sFilter);
                                }
                                #endregion

                                #region Realized Cheque (Bank Wise)
                                else if (Report == enum_ReportName.RG_Realized_Cheque)
                                {
                                    sFormula = " {vw_rpt_bpsChequeReconciliation.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsChequeReconciliation.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                    if (bCustomerSelected)
                                        sFormula += " and {vw_rpt_bpsChequeReconciliation.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";
                                    if (bAccountSelected)
                                        //if (bBankSelected)
                                        //sFormula += " and {vw_rpt_bpsChequeReconciliation.bank_ID} = '" + txtBank.Tag.ToString().Trim() + "'";
                                        sFormula += " and {vw_rpt_bpsChequeReconciliation.accountNumber} = '" + txtBankAccNo.Tag.ToString().Trim() + "'";

                                    if (rdoDeleted.Checked)
                                        sFormula += " and {vw_rpt_bpsChequeReconciliation.isDeleted} = True";
                                    if (rdoActive.Checked)
                                        sFormula += " and {vw_rpt_bpsChequeReconciliation.isDeleted} = False";

                                    sFormula += " and {vw_rpt_bpsChequeReconciliation.chequeStatus_ID} = '" + clsAutocode.getChequeStatusID(ChequeStatus.Realized) + "'";

                                    //glb_dts_ChqD.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", dateRange, clsSecurity.UserNameLoged, sFilter);
                                    //frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                    //rpt.print(sRptPath, glb_dts_ChqD, glb_dtsReportExport.dt_rptParameter);
                                    print(sReportPath, sReportTitle_Main, sFormula, sFilter);
                                }
                                #endregion

                                #region Returned Cheque Summary
                                else if (Report == enum_ReportName.RG_Returned_Cheque_BankWise)
                                {
                                    try
                                    {
                                        sFilter = "";
                                        string dateRange2 = "From " + dtpFrom.Value.Date.ToString("dd-MMM-yyyy") + " TO " + dtpTo.Value.Date.ToString("dd-MMM-yyyy");

                                        glb_dts_ChqD.Clear();
                                        glb_dtsReportExport.Clear();
                                        Cursor = Cursors.WaitCursor;

                                        #region Filters
                                        string sCustomerID = "%";
                                        string sSalesRepID = "%";
                                        int isDeleted = 0;

                                        if (txtBankAccNo.Tag != null)
                                        {
                                            sFilter += " Bank Account:" + txtBankAccNo.Text;
                                        }

                                        if (txtCustomer.Tag != null)
                                        {
                                            sCustomerID = txtCustomer.Tag.ToString();
                                            sFilter += " Customer :" + txtCustomer.Text;
                                        }
                                        if (txtSalesRep.Tag != null)
                                        {
                                            sSalesRepID = txtSalesRep.Tag.ToString();
                                            sFilter += " Sales Rep :" + txtSalesRep.Text;
                                        }
                                        if (rdoDeleted.Checked)
                                        {
                                            isDeleted = 1;
                                        }
                                        if (rdoActive.Checked)
                                        {
                                            isDeleted = 0;
                                        }
                                        #endregion

                                        string sQuary = "sp_getReturnedChequeSummary '" + clsSecurity.CompanyID + "' , '" + clsSecurity.BranchID + "' , '" + dtpFrom.Value.Date + "', '" + dtpTo.Value.Date + "'  , '" + sCustomerID + "', '" + sSalesRepID + "' , '" + isDeleted + "'";
                                        glb_dts_ChqD.dt_bpsReturnedCheque.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                                        glb_dts_ChqD.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", dateRange, clsSecurity.UserNameLoged, sFilter);
                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dts_ChqD, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception)
                                    {
                                        throw;
                                    }
                                    finally
                                    {
                                        glb_dts_ChqD.Clear();
                                        glb_dtsReportExport.Clear();
                                        Cursor = Cursors.Default;
                                    }

                                    // Cursor = Cursors.WaitCursor;

                                    // #region dataset
                                    // glbDtsBills.Clear();
                                    // List<tbl_sasInvoice> oInvoice;

                                    // if (txtCustomer.Tag == null)
                                    // {
                                    //     oInvoice = tbl_sasInvoice.SelectAll();
                                    // }
                                    // else
                                    // {
                                    //     oInvoice = tbl_sasInvoice.SelectAllByCustomer_ID(txtCustomer.Tag.ToString());
                                    // }

                                    // foreach (tbl_sasInvoice Invoice in oInvoice.Where(p => p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date
                                    //&& p.IsReturnedCheque && p.CompanyID.ToLower() == clsSecurity.CompanyID.ToLower() && p.CompanyBranch_ID == clsSecurity.BranchID && !p.IsDeleted))
                                    // {
                                    //     if (txtSalesRep.Tag != null)
                                    //     {



                                    //     }

                                    //     tbl_bpsChequeRegister oCheqRegs = tbl_bpsChequeRegister.Select(Invoice.ChequeRegister_ID);
                                    //     if (oCheqRegs != null)
                                    //     {
                                    //         if (txtBankAccNo.Tag != null)
                                    //         {
                                    //             if (oCheqRegs.DepositedAccountNumber != txtBankAccNo.Tag)
                                    //                 continue;
                                    //         }
                                    //     }

                                    // }


                                    // //foreach (tbl_accAccountReceipt AccountReceipt in tbl_accAccountReceipt.SelectAll().Where(p => !p.IsDeleted))
                                    // //{
                                    // foreach (tbl_sasInvoice Invoice in tbl_sasInvoice.SelectAll().Where(p => p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date && p.CompanyID.ToLower() == clsSecurity.CompanyID.ToLower() && p.CompanyBranch_ID == clsSecurity.BranchID && !p.IsDeleted))
                                    // {
                                    //     //// if (!rdoDeleted.Checked && Invoice.IsDeleted)
                                    //     //     continue;
                                    //     // if (!rdoActual.Checked && !Invoice.IsDeleted)
                                    //     //     continue;


                                    //     //2016-11-03- Added by Gayan---------------------------------------------------------------
                                    //     List<tbl_bpsChequeRegister> oCheqRegs = tbl_bpsChequeRegister.SelectAllChequeRegister_ForReturnedChequeSummary(Invoice.ChequeRegister_ID).Where(p => p.IsReturned).ToList();

                                    //     if (oCheqRegs.Count < 1)
                                    //         continue;

                                    //     if (txtCustomer.Tag != null)
                                    //     {
                                    //         oCheqRegs = oCheqRegs.Where(c => c.Customer_ID == txtCustomer.Tag.ToString().Trim()).ToList();
                                    //         if (oCheqRegs.Count < 1)
                                    //             continue;
                                    //     }
                                    //     if (txtBankAccNo.Tag != null)
                                    //     {
                                    //         oCheqRegs = oCheqRegs.Where(c => c.DepositedAccountNumber == txtBankAccNo.Tag.ToString().Trim()).ToList();
                                    //         if (oCheqRegs.Count < 1)
                                    //             continue;
                                    //     }
                                    //     if (txtSalesRep.Tag != null)
                                    //     {
                                    //         oCheqRegs = oCheqRegs.Where(c => (tbl_genCustomerMaster.Select(c.Customer_ID)).SalesRep_ID == txtSalesRep.Tag.ToString().Trim()).ToList();
                                    //         if (oCheqRegs.Count < 1)
                                    //             continue;
                                    //     }
                                    //     oCheqRegs = oCheqRegs.Where(c => (tbl_zChequeStatus.Select(c.ChequeStatus_ID)) != null).ToList();
                                    //     oCheqRegs = oCheqRegs.Where(c => (tbl_zBankBranches.Select(c.DepositedBranch_ID)) != null).ToList();
                                    //     if (oCheqRegs.Count < 1)
                                    //         continue;
                                    //     ////------------------------------------------------------------------------------------


                                    //     ////foreach (tbl_bpsChequeRegister ChequeRegister in tbl_bpsChequeRegister.SelectAll().Where(p => p.ChequeRegister_ID == Invoice.ChequeRegister_ID && !p.IsDeleted && p.IsReturned))
                                    //     foreach (tbl_bpsChequeRegister ChequeRegister in oCheqRegs.Where(p => !p.IsDeleted))
                                    //     {
                                    //         //2016-11-03- Commented by by Gayan---------------------------------------------------------------
                                    //         //tbl_zBankBranches Branches = tbl_zBankBranches.Select(ChequeRegister.DepositedBranch_ID);
                                    //         //tbl_zBank Bank = tbl_zBank.Select(ChequeRegister.Bank_ID);
                                    //         //tbl_zChequeStatus ChequeStatus = tbl_zChequeStatus.Select(ChequeRegister.ChequeStatus_ID);
                                    //         //tbl_genCustomerMaster Customer = tbl_genCustomerMaster.Select(ChequeRegister.Customer_ID);
                                    //         //if (Invoice != null && Branches != null && Bank != null && ChequeStatus != null && Customer != null)
                                    //         //{
                                    //         //    if (bCustomerSelected && Customer.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                    //         //        continue;
                                    //         //    if (bBankSelected && Bank.Bank_ID != txtBank.Tag.ToString().Trim())
                                    //         //        continue;
                                    //         //    if (bSelesRepSelected && Customer.SalesRep_ID != txtSalesRep.Tag.ToString().Trim())
                                    //         //        continue;
                                    //         //    if (bSelesRepSelected && Customer.SalesRep_ID != txtSalesRep.Tag.ToString().Trim())
                                    //         //        continue;


                                    //         //    glbDtsBills.dt_bpsChequeReturn.Adddt_bpsChequeReturnRow(ChequeRegister.ChequeRegister_ID, ChequeRegister.ChequeStatus_ID, ChequeRegister.ChequeNumber, ChequeRegister.ChequeAmount, ChequeRegister.IsReturned, Invoice.InvoiceDate,
                                    //         //        Invoice.Invoice_ID, Invoice.InvoiceDate, Bank.BankName, Branches.BranchName, Customer.Customer_ID, Customer.CustomerName, ChequeRegister.DateCheque, Branches.Branch_ID, Bank.Bank_ID, ChequeRegister.DepositedAccountNumber,
                                    //         //        Invoice.IsReturnedCheque, Invoice.IsSeattled, ChequeRegister.IsApproved, Invoice.SeattleAmount, Invoice.IsDeleted, Invoice.GrandTotal, Customer.SalesRep_ID, ChequeRegister.AccountReceipt_ID, "");//AccountReceipt.Receivedof );
                                    //         //}
                                    //         //--------------------------------------------------------------------------------------------------------------
                                    //         glbDtsBills.dt_bpsChequeReturn.Adddt_bpsChequeReturnRow(ChequeRegister.ChequeRegister_ID, ChequeRegister.ChequeStatus_ID, ChequeRegister.ChequeNumber, ChequeRegister.Amount, ChequeRegister.IsReturned, Invoice.InvoiceDate,
                                    //                 Invoice.Invoice_ID, Invoice.InvoiceDate, clsGenaralName.getName_Bank(ChequeRegister.DepositedBank_ID), clsGenaralName.getName_BankBranch(ChequeRegister.DepositedBranch_ID), ChequeRegister.Customer_ID, clsGenaralName.getName_Customer(ChequeRegister.Customer_ID), ChequeRegister.DateCheque, ChequeRegister.DepositedBranch_ID, ChequeRegister.Bank_ID, ChequeRegister.DepositedAccountNumber,
                                    //                 Invoice.IsReturnedCheque, Invoice.IsSeattled, true, Invoice.SeattleAmount, Invoice.IsDeleted, Invoice.GrandTotal, clsGenaralName.getName_SalesRep((tbl_genCustomerMaster.Select(ChequeRegister.Customer_ID)).SalesRep_ID), ChequeRegister.AccountReceipt_ID, "");//AccountReceipt.Receivedof );
                                    //                                                                                                                                                                                                                                                                                  //   }
                                    //     }

                                    // }
                                    // //}
                                    // #endregion
                                    // Cursor = Cursors.Default;



                                    // glbDtsBills.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", dateRange, clsSecurity.UserNameLoged, sFilter);
                                    // frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                    // rpt.print(sReportPath, glbDtsBills, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));


                                    // glbDtsBills.Clear();
                                }
                                #endregion

                                #region Pending Cheque Deposit
                                if (Report == enum_ReportName.ST_Pending_Cheque_Deposite)
                                {
                                    sFormula = "{vw_rpt_bpsChequeRegister.pd_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsChequeRegister.pd_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                    sFormula += " and {vw_rpt_bpsChequeRegister.isDeleted} = False";

                                    if (bCustomerSelected)
                                    {
                                        sFormula += " and {vw_rpt_bpsChequeRegister.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";
                                        //    sFilter += " User Name : " + txtCustomer.Text.Trim();
                                    }

                                    if (bSelesRepSelected)
                                    {
                                        sFormula += " and {vw_rpt_bpsChequeRegister.salesRep_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";
                                        //   sFilter += " User Name : " + txtSalesRep.Text.Trim();
                                    }

                                    sFormula += " and {vw_rpt_bpsChequeRegister.isDepositted} = False and {vw_rpt_bpsChequeRegister.isReIssued} = False";

                                    glb_dts_ChqD.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", dateRange, clsSecurity.UserNameLoged, sFilter);
                                    //frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                    //rpt.print(sRptPath, glb_dts_ChqD, glb_dtsReportExport.dt_rptParameter);
                                    print(sReportPath, sReportTitle_Main, sFormula, sFilter);
                                }
                                #endregion

                                #region PD Cheques (Age-Analysis)
                                else if (Report == enum_ReportName.ST_Cheques_Age_Analysis)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        List<tbl_bpsChequeRegister> cChequeRegisters;
                                        glbDtsBills.dt_bssOutstandingChequesAgeAnalysis.Rows.Clear();

                                        DateTime dtNow = clsSecurity.getServerDateTime();
                                        if (bCustomerSelected)
                                        {
                                            cChequeRegisters = tbl_bpsChequeRegister.SelectAllByCustomer_ID(txtCustomer.Tag.ToString()).Where(p => !p.IsDeleted && !p.IsReIssued && p.Receipt_ID != "default" &&
                                            p.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Realized) && p.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_R) &&
                                            p.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C) && p.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_O) &&
                                            p.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Deleted)
                                            && p.PaymentMethod_ID == (int)PaymentMethod.Cheque).ToList();
                                        }
                                        else
                                        {
                                            cChequeRegisters = tbl_bpsChequeRegister.SelectAll().Where(p => !p.IsDeleted && !p.IsReIssued && p.Receipt_ID != "default" &&
                                            p.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Realized) && p.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_R) &&
                                            p.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C) && p.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_O) &&
                                            p.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Deleted)
                                            && p.PaymentMethod_ID == (int)PaymentMethod.Cheque).ToList();
                                        }

                                        if (cChequeRegisters != null)
                                        {
                                            foreach (tbl_bpsChequeRegister oChequeRegister in cChequeRegisters)
                                            {
                                                //if (oChequeRegister.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                                                //{
                                                decimal dTotalChequeAmount = 0, d0to30Days = 0, d31to60Days = 0, d61to90Days = 0, dOver90Days = 0, dPendingRealized = 0, dTotalCheques = 0;

                                                if (oChequeRegister.DateCheque.Date >= dtNow.Date)
                                                {
                                                    int iAgeing = clsCommon.getDays(dtNow.Date, oChequeRegister.DateCheque.Date);
                                                    if (iAgeing <= 30)
                                                        d0to30Days += oChequeRegister.Amount;
                                                    else if (iAgeing >= 31 & iAgeing <= 60)
                                                        d31to60Days += oChequeRegister.Amount;
                                                    else if (iAgeing >= 61 & iAgeing <= 90)
                                                        d61to90Days += oChequeRegister.Amount;
                                                    else if (iAgeing >= 91)
                                                        dOver90Days += oChequeRegister.Amount;
                                                }
                                                else
                                                {
                                                    dPendingRealized += oChequeRegister.Amount;
                                                }

                                                dTotalChequeAmount += oChequeRegister.Amount;
                                                dTotalCheques++;

                                                glbDtsBills.dt_bssOutstandingChequesAgeAnalysis.Adddt_bssOutstandingChequesAgeAnalysisRow(oChequeRegister.Customer_ID, clsGenaralName.getName_Customer(oChequeRegister.Customer_ID), dTotalChequeAmount,
                                                    dTotalCheques, dPendingRealized, d0to30Days, d31to60Days, d61to90Days, dOver90Days);
                                                //}
                                            }
                                        }
                                        ProgressBar.Value = 0;

                                        //glbDtsBills.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", dateRange, clsSecurity.UserNameLoged, sFilter);
                                        //frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        //rpt.print(sReportPath, glbDtsBills, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                        print("\\reports\\BSS\\Standard\\rpt_bss_OutstandingChequesAgeAnalysis.rpt", "PD Cheque (Age-Analysis)", glbDtsBills.dt_bssOutstandingChequesAgeAnalysis);
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
                                        glbDtsBills.dt_ChequeInHand.Rows.Clear();
                                    }
                                }
                                #endregion

                                #region Cheques In Hand
                                else if (Report == enum_ReportName.ST_Cheque_In_HandAll)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glbDtsBills.Clear();

                                        //fill data table
                                        List<tbl_bpsChequeRegister> oCheques = tbl_bpsChequeRegister.SelectAll() //Where(r=>r.DateRegister)
                                            .Where(p => p.ChequeRegister_ID != "default" && !p.IsReconcilied && !p.IsReturned && !p.IsReIssued && p.DateCheque.Date >= dtpFrom.Value.Date.Date && p.DateCheque.Date <= dtpTo.Value.Date.Date).ToList();

                                        if (rdoDeleted.Checked == true)
                                            oCheques = oCheques.Where(r => r.IsDeleted).ToList();
                                        else if (rdoActive.Checked == true)
                                            oCheques = oCheques.Where(r => !r.IsDeleted).ToList();
                                        else if (rdoAll.Checked == true)
                                            oCheques = oCheques;
                                        else
                                            oCheques = oCheques.Where(r => !r.IsDeleted).ToList();

                                        foreach (tbl_bpsChequeRegister oCheque in oCheques)
                                        {
                                            if (oCheque.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                                            {
                                                bool bSalesRepOK = true, bBank = true, bCustomerOK = true;

                                                if (bCustomerSelected)
                                                {
                                                    // sFilter += " Customer Name : " + txtCustomer.Text.Trim();
                                                    bCustomerOK = oCheque.Customer_ID == txtCustomer.Tag.ToString() ? true : false;
                                                }
                                                if (bSelesRepSelected)
                                                {
                                                    // sFilter += " Sales Rep Name : " + txtSalesRep.Text.Trim();
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oCheque.OrderRefNo_ID);
                                                    if (oRef != null)
                                                        bSalesRepOK = oRef.Employee_ID == txtSalesRep.Tag.ToString() ? true : false;
                                                }

                                                if (bCustomerOK && bSalesRepOK)
                                                {
                                                    decimal dToBeReconciledAmount = 0, dCheckinHandAmount = 0;
                                                    double dDateCount = 0;
                                                    if (oCheque.IsDepositted)
                                                    {
                                                        dToBeReconciledAmount = oCheque.Amount;
                                                        dDateCount = (System.DateTime.Now - oCheque.DateDeposited).TotalDays;
                                                    }
                                                    else
                                                        dCheckinHandAmount = oCheque.Amount;

                                                    glbDtsBills.dt_ChequeInHand.Adddt_ChequeInHandRow(oCheque.DateCheque, oCheque.ChequeNumber, clsGenaralName.getShortName_Bank(oCheque.Bank_ID), oCheque.Customer_ID,
                                                        clsGenaralName.getName_Customer(oCheque.Customer_ID), oCheque.DateRegister, dCheckinHandAmount, dToBeReconciledAmount, dDateCount, oCheque.DepositedAccountNumber);
                                                }
                                                clsHelpMethods.startProgressBar(0, oCheques.Count + 2, 1, ProgressBar);
                                            }
                                        }

                                        glbDtsBills.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", dateRange, clsSecurity.UserNameLoged, sFilter);
                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glbDtsBills, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                        ///print("\\reports\\BSS\\Standard\\rpt_sas_ChequesInHand.rpt", sReportName, glbDtsBills.dt_ChequeInHand);
                                        //print("\\reports\\BSS\\Standard\\rpt_sas_ChequesInHand.rpt", "Cheques in Hand (All)", glbDtsBills.dt_ChequeInHand);
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
                                        glbDtsBills.Clear();
                                    }
                                }
                                #endregion

                                #region Cheques in Hand [Approved For Deposit]
                                else if (Report == enum_ReportName.ST_Cheque_In_Hand_Approved_For_Deposit)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glbDtsBills.Clear();

                                        //fill data table
                                        List<tbl_bpsChequeRegister> oCheques = tbl_bpsChequeRegister.SelectAll().Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default" && !p.IsDepositted && !p.IsReIssued //&& p.IsApproved 
                                        && p.CompanyBranch_ID == clsSecurity.BranchID).ToList();
                                        foreach (tbl_bpsChequeRegister oCheque in oCheques)
                                        {
                                            if (oCheque.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                                            {
                                                bool bSalesRepOK = true, bCustomerOK = true; bBankSelected = true;

                                                if (bCustomerSelected)
                                                {
                                                    sFilter += " Customer Name : " + txtCustomer.Text.Trim();
                                                    bCustomerOK = oCheque.Customer_ID == txtCustomer.Tag.ToString() ? true : false;
                                                }
                                                if (bSelesRepSelected)
                                                {
                                                    sFilter += " User Name : " + txtSalesRep.Text.Trim();
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oCheque.OrderRefNo_ID);
                                                    if (oRef != null)
                                                        bSalesRepOK = oRef.Employee_ID == txtSalesRep.Tag.ToString() ? true : false;
                                                }

                                                if (bCustomerOK && bSalesRepOK)
                                                {
                                                    glbDtsBills.dt_ChequeInHand.Rows.Add(oCheque.DateCheque, oCheque.ChequeNumber, clsGenaralName.getShortName_Bank(oCheque.Bank_ID), oCheque.Customer_ID,
                                                        clsGenaralName.getName_Customer(oCheque.Customer_ID), oCheque.DateRegister, oCheque.Amount);
                                                }
                                                clsHelpMethods.startProgressBar(0, oCheques.Count + 2, 1, ProgressBar);
                                            }
                                        }

                                        //glb_dts_ChqD.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sRptName, "", dateRange, clsSecurity.UserNameLoged, sFilter);

                                        glbDtsBills.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", dateRange, clsSecurity.UserNameLoged, sFilter);
                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glbDtsBills, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                        //print("\\reports\\BSS\\Standard\\rpt_sas_ChequesInHand.rpt", "Cheques in Hand (All)", glbDtsBills.dt_ChequeInHand);
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
                                        glbDtsBills.dt_ChequeInHand.Rows.Clear();
                                    }
                                }
                                #endregion

                                #region Cheques in Hand [Pending Approval]
                                else if (Report == enum_ReportName.ST_ChequeIn_Hand_Pending_Approval)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glbDtsBills.dt_ChequeInHand.Rows.Clear();

                                        //fill data table
                                        List<tbl_bpsChequeRegister> oCheques = tbl_bpsChequeRegister.SelectAll().Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default" && !p.IsDepositted && !p.IsReIssued //&& !p.IsApproved 
                                        && p.CompanyBranch_ID == clsSecurity.BranchID).ToList();
                                        foreach (tbl_bpsChequeRegister oCheque in oCheques)
                                        {
                                            if (oCheque.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                                            {
                                                bool bSalesRepOK = true, bBank = true, bCustomerOK = true;

                                                if (bCustomerSelected)
                                                {
                                                    bCustomerOK = oCheque.Customer_ID == txtCustomer.Tag.ToString() ? true : false;
                                                }
                                                if (bSelesRepSelected)
                                                {
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oCheque.OrderRefNo_ID);
                                                    if (oRef != null)
                                                        bSalesRepOK = oRef.Employee_ID == txtSalesRep.Tag.ToString() ? true : false;
                                                }

                                                if (bCustomerOK && bSalesRepOK)
                                                {
                                                    glbDtsBills.dt_ChequeInHand.Rows.Add(oCheque.DateCheque, oCheque.ChequeNumber, clsGenaralName.getShortName_Bank(oCheque.Bank_ID), oCheque.Customer_ID,
                                                        clsGenaralName.getName_Customer(oCheque.Customer_ID), oCheque.DateRegister, oCheque.Amount);
                                                }
                                                clsHelpMethods.startProgressBar(0, oCheques.Count + 2, 1, ProgressBar);
                                            }
                                        }

                                        glbDtsBills.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", dateRange, clsSecurity.UserNameLoged, sFilter);

                                        //glb_dts_ChqD.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sRptName, "", dateRange, clsSecurity.UserNameLoged, sFilter);
                                        //frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        //rpt.print(sRptPath, glb_dts_ChqD, glb_dtsReportExport.dt_rptParameter);
                                        //print(sReportPath, sReportTitle_Main, glbDtsBills.dt_ChequeInHand);

                                        frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
                                        ReportViewer.print(sReportPath, glbDtsBills, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
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
                                        glbDtsBills.Clear();
                                    }
                                }
                                #endregion

                                #region Returned Cheques in Hand
                                else if (Report == enum_ReportName.ST_Returned_Cheque_inHand)
                                {
                                    sFormula += " {vw_rpt_bpsChequeReturn.isSeattled} = False";

                                    if (bCustomerSelected)
                                        sFormula += " and {vw_rpt_bpsChequeReturn.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";

                                    if (bSelesRepSelected)
                                        sFormula += " and {vw_rpt_bpsChequeReturn.salesRep_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";
                                    glb_dts_ChqD.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", dateRange, clsSecurity.UserNameLoged, sFilter);
                                    //frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                    //rpt.print(sRptPath, glb_dts_ChqD, glb_dtsReportExport.dt_rptParameter);
                                    print(sReportPath, sReportTitle_Main, sFormula, sFilter);
                                }
                                #endregion

                                #region Cash In Hand
                                else if (Report == enum_ReportName.ST_Cheque_In_Hand)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glbDtsBills.Clear();
                                        //List<tbl_bpsReceipt> oReceipts = tbl_bpsReceipt.SelectAll().Where(p => !p.IsDeleted && p.Receipt_ID != "default" && p.ReceiptDate.Date >= dtpFrom.Value.Date && p.ReceiptDate.Date <= dtpTo.Value.Date && p.CashAmount > 0 && !p.IsCashDeposited && p.CompanyBranch_ID == clsSecurity.BranchID).ToList();

                                        #region Sales Receipt
                                        List<tbl_bpsReceipt> oReceipts = tbl_bpsReceipt.SelectAll().Where(p => !p.IsDeleted && p.Receipt_ID != "default" && p.ReceiptDate.Date >= dtpFrom.Value.Date && p.ReceiptDate.Date <= dtpTo.Value.Date && !p.IsCashDeposited && p.CompanyBranch_ID == clsSecurity.BranchID).ToList();

                                        foreach (tbl_bpsReceipt oReceipt in oReceipts)
                                        {
                                            decimal dCashAmount = 0;
                                            foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID).Where(p => p.PaymentMethod_ID == 0 && !p.IsDepositted))
                                            {
                                                dCashAmount += oCheque.Amount;
                                            }
                                            if (dCashAmount > 0)
                                            {
                                                bool bSalesRepOK = true, bCustomerOK = true;
                                                string sEmpName = "", sEmpID = "default";
                                                if (bCustomerSelected)
                                                {
                                                    //  sFilter += " Customer Name : " + txtCustomer.Text.Trim();
                                                    bCustomerOK = oReceipt.Customer_ID == txtCustomer.Tag.ToString() ? true : false;
                                                }

                                                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oReceipt.OrderRefNo_ID);
                                                if (oRef != null)
                                                {
                                                    sEmpID = oRef.Employee_ID;
                                                    sEmpName = clsGenaralName.getName_SalesRep(oRef.Employee_ID);
                                                }

                                                if (bSelesRepSelected)
                                                {
                                                    //sFilter += " User Name : " + txtSalesRep.Text.Trim();
                                                    bSalesRepOK = sEmpID == txtSalesRep.Tag.ToString() ? true : false;
                                                }

                                                if (bCustomerOK && bSalesRepOK)
                                                {

                                                    glbDtsBills.dt_bssCashInHand.Adddt_bssCashInHandRow(oReceipt.Receipt_ID, oReceipt.ReceiptDate, oReceipt.Receipt_ID, clsGenaralName.getName_Customer(oReceipt.Customer_ID),
                                                        sEmpID, sEmpName, dCashAmount, oReceipt.Currency_ID, oReceipt.CurrencyRate);
                                                }
                                                clsHelpMethods.startProgressBar(0, oReceipts.Count + 2, 1, ProgressBar);
                                            }
                                        }
                                        #endregion

                                        #region Account Receipt
                                        List<tbl_accAccountReceipt> oAccReceipts = tbl_accAccountReceipt.SelectAll().Where(p => !p.IsDeleted && p.AccountReceipt_ID != "default" && p.AccountReceiptDate.Date >= dtpFrom.Value.Date && p.AccountReceiptDate.Date <= dtpTo.Value.Date && !p.IsCashDeposited && p.CompanyBranch_ID == clsSecurity.BranchID).ToList();
                                        foreach (tbl_accAccountReceipt oReceipt in oAccReceipts)
                                        {
                                            decimal dCashAmount = 0;
                                            foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByAccountReceipt_ID(oReceipt.AccountReceipt_ID).Where(p => p.PaymentMethod_ID == 0 && !p.IsDepositted))
                                            {
                                                dCashAmount += oCheque.Amount;
                                            }

                                            if (dCashAmount > 0)
                                            {
                                                bool bSalesRepOK = true, bCustomerOK = true;
                                                string sEmpName = "", sEmpID = "default";
                                                if (bCustomerSelected)
                                                    bCustomerOK = oReceipt.Customer_ID == txtCustomer.Tag.ToString() ? true : false;

                                                sEmpID = oReceipt.Employee_ID;
                                                sEmpName = clsGenaralName.getName_SalesRep(oReceipt.Employee_ID);

                                                if (bSelesRepSelected)
                                                    bSalesRepOK = sEmpID == txtSalesRep.Tag.ToString() ? true : false;

                                                if (bCustomerOK && bSalesRepOK)
                                                {
                                                    glbDtsBills.dt_bssCashInHand.Adddt_bssCashInHandRow(oReceipt.AccountReceipt_ID, oReceipt.AccountReceiptDate, oReceipt.Customer_ID,
                                                        oReceipt.Customer_ID != "default" ? clsGenaralName.getName_Customer(oReceipt.Customer_ID) : oReceipt.Remark,
                                                        sEmpID, sEmpName, dCashAmount, oReceipt.Currency_ID, oReceipt.CurrencyRate);
                                                }
                                                clsHelpMethods.startProgressBar(0, oReceipts.Count + 2, 1, ProgressBar);
                                            }
                                        }
                                        #endregion

                                        glbDtsBills.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", dateRange, clsSecurity.UserNameLoged, sFilter);
                                        //frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        //rpt.print(sRptPath, glb_dts_ChqD, glb_dtsReportExport.dt_rptParameter);

                                        //print("\\reports\\BSS\\Standard\\rpt_sas_CashInHand.rpt", "Cash in Hand", glbDtsBills.dt_bssCashInHand, sFilter);
                                        frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
                                        ReportViewer.print(sReportPath, glbDtsBills, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
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
                                        glbDtsBills.dt_bssCashInHand.Rows.Clear();
                                    }
                                }
                                #endregion

                                #region Returned Cheques Outstandings
                                else if (Report == enum_ReportName.ST_Returned_Cheque_Outstanding)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glbDtsBills.Clear();

                                        List<tbl_bpsChequeRegister> oCheques = tbl_bpsChequeRegister.SelectAll().Where(p => !p.IsDeleted && (p.ChequeStatus_ID == "4" || p.ChequeStatus_ID == "5" || p.ChequeStatus_ID == "6") && p.DateRegister.Date >= dtpFrom.Value.Date && p.DateRegister.Date <= dtpTo.Value.Date && p.CompanyBranch_ID == clsSecurity.BranchID).ToList();

                                        foreach (tbl_bpsChequeRegister oCheque in oCheques)
                                        {
                                            bool bHasRow = false;
                                            decimal dSettledAmount = 0;

                                            #region Filters
                                            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oCheque.Customer_ID);
                                            if (oCustomer != null)
                                            {
                                                if (txtCustomer.Tag != null)
                                                {
                                                    if (oCustomer.Customer_ID != txtCustomer.Tag.ToString())
                                                        continue;
                                                }
                                                if (!chkUseCustomerMastorSaleRep.Checked)
                                                {
                                                    if (txtSalesRep.Tag != null)
                                                    {
                                                        if (oCustomer.SalesRep_ID != txtSalesRep.Tag.ToString().Trim())
                                                            continue;
                                                    }
                                                }
                                            }

                                            if (chkUseCustomerMastorSaleRep.Checked)
                                            {
                                                if (txtSalesRep.Tag != null)
                                                {
                                                    tbl_zOrderRefNo oRefNo = tbl_zOrderRefNo.Select(oCheque.OrderRefNo_ID);
                                                    if (oRefNo != null)
                                                        if (oRefNo.Employee_ID != txtSalesRep.Tag.ToString().Trim())
                                                            continue;
                                                }
                                            }

                                            if (txtChequeNo.Tag != null)
                                            {
                                                if (oCheque.ChequeNumber != txtChequeNo.Tag.ToString().Trim())
                                                    continue;
                                            }
                                            #endregion

                                            foreach (tbl_sasInvoice oInvoice in tbl_sasInvoice.SelectAllByChequeRegister_ID(oCheque.ChequeRegister_ID))
                                            {
                                                List<tbl_sasInvoice_Sattled> oInvSettled = tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(oInvoice.Invoice_ID).ToList();

                                                var oSettlement = oInvSettled.GroupBy(gb => new { gb.Receipt_ID }, (Key, group) =>
                                                        new { ReceiptID = Key.Receipt_ID, SettledAmount = group.Sum(p => p.SattledAmount) });
                                                foreach (var oInvoiceSettlement in oSettlement.OrderBy(p => (p.ReceiptID)))
                                                {
                                                    dSettledAmount += oInvoiceSettlement.SettledAmount;
                                                    bHasRow = true;

                                                    if (oInvoiceSettlement.ReceiptID != "default" || oInvoiceSettlement.ReceiptID != null)
                                                    {
                                                        tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(oInvoiceSettlement.ReceiptID);
                                                        if (oReceipt != null)
                                                            glbDtsBills.dt_bssReturnedChequesOutstanding.Adddt_bssReturnedChequesOutstandingRow(oCheque.DateCheque, oCheque.Customer_ID, clsGenaralName.getName_Customer(oCheque.Customer_ID), oCheque.ChequeNumber, oCheque.Amount, oInvoiceSettlement.SettledAmount, oCheque.Amount - dSettledAmount, oInvoiceSettlement.ReceiptID, clsFormatter.FormatDate_SL(oReceipt.ReceiptDate));
                                                    }

                                                }

                                                if (!bHasRow)
                                                    glbDtsBills.dt_bssReturnedChequesOutstanding.Adddt_bssReturnedChequesOutstandingRow(oCheque.DateCheque, oCheque.Customer_ID, clsGenaralName.getName_Customer(oCheque.Customer_ID), oCheque.ChequeNumber, oCheque.Amount, 0, oCheque.Amount, "-", "-");

                                                clsHelpMethods.startProgressBar(0, oCheques.Count + 2, 1, ProgressBar);
                                            }
                                        }

                                        glbDtsBills.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", dateRange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
                                        ReportViewer.print(sReportPath, glbDtsBills, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
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
                                        glbDtsBills.dt_bssCashInHand.Rows.Clear();
                                    }
                                }
                                #endregion

                                #region to be delete
                                //#region Receipt Summary (Sales)
                                //else if (rdoRecieptSummary_Sales.Checked)
                                //{
                                //    if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_SalesReceiptSummary)))
                                //    {

                                //        sFormula = " {vw_rpt_bpsReceiptHeder.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsReceiptHeder.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                                //        if (bCustomerSelected)
                                //            sFormula += " and {vw_rpt_bpsReceiptHeder.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "' ";

                                //        if (bSelesRepSelected)
                                //            sFormula += "and {vw_rpt_bpsReceiptHeder.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";


                                //        if (cmbReceiptType.Text == "Advanced Payment")
                                //        {
                                //            sFormula += " and {vw_rpt_bpsReceiptHeder.isAdvance} = True";
                                //            sFilter += " Adavance Payment";
                                //        }
                                //        else if (cmbReceiptType.Text == "Part Payments")
                                //        {
                                //            sFormula += " and {vw_rpt_bpsReceiptHeder.isAdvance} = False";
                                //            sFilter += " Part Payment";
                                //        }

                                //        if (rdoDeleted.Checked)
                                //            sFormula += " and {vw_rpt_bpsReceiptHeder.isDeleted} = True";
                                //        if (rdoActual.Checked)
                                //            sFormula += " and {vw_rpt_bpsReceiptHeder.isDeleted} = False";



                                //        sFormula += " and {vw_rpt_bpsReceiptHeder.isSalesReceipt} = True";
                                //        print("\\reports\\BSS\\Registry\\rpt_sas_Receipt_Registry_Detail.rpt", "Receipt Summary (Sales)", sFormula, sFilter);
                                //    }
                                //}
                                //#endregion

                                //#region Reciept Summary (Interim)
                                //else if (rdoRecieptSummary_Account.Checked)
                                //{
                                //    if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_InterimReceiptSummary)))
                                //    {
                                //        sFormula = " {vw_rpt_bpsReceiptHeder.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsReceiptHeder.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                                //        if (bCustomerSelected)
                                //            sFormula += " and {vw_rpt_bpsReceiptHeder.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "' ";

                                //        if (bSelesRepSelected)
                                //            sFormula += "and {vw_rpt_bpsReceiptHeder.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";

                                //        if (rdoDeleted.Checked)
                                //            sFormula += " and {vw_rpt_bpsReceiptHeder.isDeleted} = True";
                                //        if (rdoActual.Checked)
                                //            sFormula += " and {vw_rpt_bpsReceiptHeder.isDeleted} = False";
                                //        if (cmbReceiptType.Text == "Advanced Payment")
                                //            sFormula += " and {vw_rpt_bpsReceiptHeder.isAdvance} = True";
                                //        if (cmbReceiptType.Text == "Part Payments")
                                //            sFormula += " and {vw_rpt_bpsReceiptHeder.isAdvance} = False";


                                //        sFormula += " and {vw_rpt_bpsReceiptHeder.isSalesReceipt} = False";
                                //        print("\\reports\\BSS\\Registry\\rpt_sas_Receipt_Registry_Detail.rpt", "Reciept Summary (Interim)", sFormula, sFilter);
                                //    }
                                //}
                                //#endregion

                                //#region Receipt Summary (All)
                                //else if (rdoRecieptSummary.Checked)
                                //{
                                //    if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_ReceiptSummary)))
                                //    {
                                //        sFormula = " {vw_rpt_bpsReceiptHeder.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsReceiptHeder.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                                //        if (bCustomerSelected)
                                //            sFormula += " and {vw_rpt_bpsReceiptHeder.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "' ";

                                //        if (bSelesRepSelected)
                                //            sFormula += "and {vw_rpt_bpsReceiptHeder.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";

                                //        if (chkCheque.Checked && chkCash.Checked)
                                //        {
                                //            if (sFilter.Length > 0)
                                //                sFilter += "/Cheque & Cash";
                                //            else
                                //                sFilter += "Cheque & Cash";

                                //            sFormula += " and ({vw_rpt_bpsReceiptHeder.cashAmount} <> 0 " + "or" + " {vw_rpt_bpsReceiptHeder.chequeAmount} <> 0 )";
                                //        }
                                //        else if (chkCheque.Checked)
                                //        {
                                //            if (sFilter.Length > 0)
                                //                sFilter += "/Cheque";
                                //            else
                                //                sFilter += "Cheque";
                                //            sFormula += " and {vw_rpt_bpsReceiptHeder.cashAmount} = 0 ";
                                //        }
                                //        else if (chkCash.Checked)
                                //        {
                                //            if (sFilter.Length > 0)
                                //                sFilter += "/Cash";
                                //            else
                                //                sFilter += "Cash";
                                //            sFormula += " and {vw_rpt_bpsReceiptHeder.chequeAmount} = 0 ";
                                //        }


                                //        if (rdoDeleted.Checked)
                                //            sFormula += " and {vw_rpt_bpsReceiptHeder.isDeleted} = True";
                                //        if (rdoActual.Checked)
                                //            sFormula += " and {vw_rpt_bpsReceiptHeder.isDeleted} = False";


                                //        if (cmbReceiptType.Text == "Advanced Payment")
                                //            sFormula += " and {vw_rpt_bpsReceiptHeder.isAdvance} = True";
                                //        if (cmbReceiptType.Text == "Part Payments")
                                //            sFormula += " and {vw_rpt_bpsReceiptHeder.isAdvance} = False";
                                //        if (cmbCustomerType.Text != "<All Customers>".Trim())
                                //        {
                                //            sFormula += " and {vw_rpt_bpsReceiptHeder.typeName} = '" + cmbCustomerType.Text.Trim() + "'";
                                //        }


                                //        print("\\reports\\BSS\\Registry\\rpt_sas_Receipt_Registry_Detail.rpt", "Receipt Summary (All)", sFormula, sFilter);
                                //    }
                                //}
                                //#endregion

                                //#region Credit Note Summary
                                //else if (rdoCrediteNote.Checked)
                                //{
                                //    if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_CreditNoteSummary)))
                                //    {
                                //        sFormula = " {vw_rpt_bpsCreditNote.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsCreditNote.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                                //        if (bCustomerSelected)
                                //            sFormula += " and {vw_rpt_bpsCreditNote.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "' ";

                                //        if (bSelesRepSelected)
                                //            sFormula += " and {vw_rpt_bpsCreditNote.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";

                                //        if (bCreditNoteTypeSelected)
                                //            sFormula += " and {vw_rpt_bpsCreditNote.creditNoteType_ID} = '" + txtCreditNoteType.Tag.ToString().Trim() + "'";

                                //        if (rdoDeleted.Checked)
                                //            sFormula += " and {vw_rpt_bpsCreditNote.isDeleted} = True";
                                //        if (rdoActual.Checked)
                                //            sFormula += " and {vw_rpt_bpsCreditNote.isDeleted} = False";

                                //        sFormula += " and {vw_rpt_bpsCreditNote.creditNoteType_ID} <> '" + clsAutocode.getCreditNoteTypeID(CreditNoteType.ReturnedChequeDeposit) + "'";
                                //        print("\\reports\\BSS\\Registry\\rpt_sas_Credit_Summary.rpt", " Credit Note Summary ", sFormula, sFilter);
                                //    }
                                //}
                                //#endregion

                                //#region Debit  Note Summary

                                //else if (rdoDebitNote.Checked)
                                //{
                                //    if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_DebitNoteSummary)))
                                //    {
                                //        sFormula = " {vw_rpt_bpsDebitNote.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsDebitNote.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                                //        if (bCustomerSelected)
                                //            sFormula += " and {vw_rpt_bpsDebitNote.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "' ";

                                //        if (bSelesRepSelected)
                                //            sFormula += " and {vw_rpt_bpsDebitNote.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";

                                //        if (rdoDeleted.Checked)
                                //            sFormula += " and {vw_rpt_bpsDebitNote.isDeleted} = True";
                                //        if (rdoActual.Checked)
                                //            sFormula += " and {vw_rpt_bpsDebitNote.isDeleted} = False";

                                //        print("\\reports\\BSS\\Registry\\rpt_sas_Debit_Summary.rpt", "   Debit  Note Summary ", sFormula, sFilter);
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
            txtBankAccNo.Text = "<<ALL Bank>>";
            txtDepositAccountNo.Text = "<<ALL Account>>";
            txtSalesRep.Text = "<<ALL Salesman>>";
            txtCreditNoteType.Text = "<<All Credit Type>>";
            txtChequeNo.Text = "<<ALL Cheques>>";

            txtCustomer.Tag = null;
            txtBankAccNo.Tag = null;
            txtDepositAccountNo.Tag = null;
            txtSalesRep.Tag = null;
            txtCreditNoteType.Tag = null;
            txtChequeNo.Tag = null;

            cmbReceiptType.SelectedIndex = 0;

            rdoAll.Checked = true;
            chkShowDetail.Checked = false;
            chkShowDetail.Enabled = false;
            chkAllBranches.Visible = false;
            chkAllBranches.Checked = false;

            chkUseCustomerMastorSaleRep.Checked = false;
            chkShowAll.Checked = false;

            //lblDepositAccountNo.Visible = false;
            //txtDepositAccountNo.Visible = false;

            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtDepositAccountNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblDepositAccountNo, true);
            clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);

            clsCommon.SetVisibility_Panel(pnlCustomer, false);
            clsCommon.SetVisibility_Panel(pnlBankAccount, false);
            clsCommon.SetVisibility_Panel(pnlAccountNo, false);
            clsCommon.SetVisibility_Panel(pnlSalesman, false);
            clsCommon.SetVisibility_Panel(pnlCRNType, false);
            clsCommon.SetVisibility_Panel(pnlCustomerType, false);
            clsCommon.SetVisibility_Panel(pnlChequeNo, false);
            clsCommon.SetVisibility_Panel(pnlReceiptType, false);
            clsCommon.SetVisibility_Panel(pnlDeletedRecords, false);
            clsCommon.SetVisibility_Panel(pnlShowDetailedReport, false);
            clsCommon.SetVisibility_Panel(pnlShowAllBranches, false);
            clsCommon.SetVisibility_Panel(pnlUseCustomerMasterSalesPerson, false);
            clsCommon.SetVisibility_Panel(pnlCashCheque, false);
            clsCommon.SetVisibility_Panel(pnlDate, false);
        }
        #endregion

        #region Print Method
        private void print(string path, string sReportTitle, DataSet ojbDataSet, string sFilter)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Standed Reports";
                ReportDocument objRpt = new ReportDocument();

                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(ojbDataSet);

                objRpt.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                objRpt.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                objRpt.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sFilter);

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
        private void print(string path, string sReportTitle, string sFormula, string sFilter)
        {
            try
            {
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

                if (!chkShowDetail.Checked)
                {
                    try
                    {
                        RD.DataDefinition.FormulaFields["ShowDetail"].Text = clsCommon.fncsetstring("1");
                    }
                    catch (Exception)
                    {
                    }
                }

                bool bHasItem = false;
                //if (bCustomerSelected)
                //{
                //    sFilter += "Customer : " + txtCustomer.Text.Trim();
                //    bHasItem = true;
                //}
                //if (bSelesRepSelected)
                //{
                //    if (bHasItem)
                //        sFilter += " / ";
                //    sFilter += "Sales Rep : " + txtSalesRep.Text.Trim();
                //    bHasItem = true;
                //}
                //if (bAccountSelected)
                //{
                //    if (bHasItem)
                //        sFilter += " / ";
                //    sFilter += "Deposite Account No : " + txtDepositAccountNo.Text.Trim();
                //    bHasItem = true;
                //}
                //if (bBankSelected)
                //{
                //    if (bHasItem)
                //        sFilter += " / ";
                //    sFilter += "Bank Account : " + txtBankAccNo.Text.Trim();
                //    bHasItem = true;
                //}
                //if (cmbReceiptType.Text != "All Payment")
                //{
                //    if (bReceiptTypeSelected)
                //    {
                //        if (bHasItem)
                //            sFilter += " / ";
                //        sFilter += "Receipt type : " + cmbReceiptType.Text.Trim();
                //        bHasItem = true;
                //    }
                //}
                //if (bCreditNoteTypeSelected)
                //{
                //    if (bHasItem)
                //        sFilter += " / ";
                //    sFilter += "Credit Note Type : " + txtCreditNoteType.Text.Trim();
                //    bHasItem = true;
                //}

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
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void print(string path, string sReportTitle, DataTable objDataTable)
        {
            try
            {
                string sFilter = "";
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Standed Reports";
                CrystalDecisions.CrystalReports.Engine.ReportDocument objRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(objDataTable); //(glbDtsBills);

                objRpt.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                objRpt.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);


                //if (rdoCommission_CustomerWise.Checked || rdoCommission_MonthWise.Checked || rdoCommission_DeductionStatus.Checked)
                //{
                //    objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(dtpTo.Value.ToString("yyyy MMM"));
                //}

                bool bHasItem = false;
                if (bCustomerSelected)
                {
                    sFilter += "Customer : " + txtCustomer.Text.Trim();
                    bHasItem = true;
                }
                if (bSelesRepSelected)
                {
                    if (bHasItem)
                        sFilter += " / ";
                    sFilter += "Sales Rep : " + txtSalesRep.Text.Trim();
                    bHasItem = true;
                }
                //if (bCurrencySelected)
                //{
                //    if (bHasItem)
                //        sFilter += " / ";
                //    sFilter += "Currency : " + cmbCurrency.Text.Trim();
                //    bHasItem = true;
                //}
                if (bBankSelected)
                {
                    if (bHasItem)
                        sFilter += " / ";
                    sFilter += "Bank : " + txtBankAccNo.Text.Trim();
                    bHasItem = true;
                }

                objRpt.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sFilter);

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
        private void print(string path, string sReportTitle, DataTable objDataTable, string sFilter)
        {
            try
            {
                //string sFilter = "";
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Standed Reports";
                CrystalDecisions.CrystalReports.Engine.ReportDocument objRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(objDataTable); //(glbDtsBills);

                objRpt.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                objRpt.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                //objRpt.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sFilter);

                bool bHasItem = false;
                if (bCustomerSelected)
                {
                    sFilter += "Customer : " + txtCustomer.Text.Trim();
                    bHasItem = true;
                }
                if (txtSalesRep.Tag != null && txtSalesRep.Tag.ToString().Length > 0)
                {
                    if (bHasItem)
                        sFilter += " / ";
                    sFilter += "Sales Rep : " + txtSalesRep.Text.Trim();
                    bHasItem = true;
                }
                //if (bCurrencySelected)
                //{
                //    if (bHasItem)
                //        sFilter += " / ";
                //    sFilter += "Currency : " + cmbCurrency.Text.Trim();
                //    bHasItem = true;
                //}
                if (bBankSelected)
                {
                    if (bHasItem)
                        sFilter += " / ";
                    sFilter += "Bank : " + txtBankAccNo.Text.Trim();
                    bHasItem = true;
                }

                objRpt.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sFilter);

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
        private void txt_Customer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CustomerID();
        }
        private void txtBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_BankID();
        }
        private void frm_rpt_ChequeManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void txtDepositAccountName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_AccountForDeposit(txtDepositAccountNo, txtBankAccNo, new TextBox());
        }
        private void txtCreditNoteType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CreditNoteType();
        }
        #endregion

        #region Events DoublClick
        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
        }

        private void txtBank_DoubleClick(object sender, EventArgs e)
        {
            Search_AccountForDeposit(txtBankAccNo, new TextBox(), new TextBox());
        }

        private void txtCreditNoteType_DoubleClick(object sender, EventArgs e)
        {
            Search_CreditNoteType();
        }

        private void txtChequeNo_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_ChequeNo(ref txtChequeNo);
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
        private void Search_BankID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_BankCompany();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtBankAccNo.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                    txtBankAccNo.Tag = frmSearchMaster.s_SearchID;
            }
        }
        private void Search_CreditNoteType()
        {
            try
            {
                clsSearch.Search_MasterCreditNoteType(ref txtCreditNoteType);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_AccountForDeposit(TextBox myTextBox, TextBox DepositBankName, TextBox DepositBranchName)
        {
            try
            {
                Form frmhelpsearch = new frmSearchTransaction();
                clsSearch.passValue_CompanyAccount();

                frmhelpsearch.ShowDialog();
                if (frmSearchTransaction.s_SearchID.Length > 0)
                {
                    if (frmSearchTransaction.s_SearchText.Length > 0)
                        myTextBox.Text = frmSearchTransaction.s_SearchID;
                    if (frmSearchTransaction.s_SearchID.Length > 0)
                        myTextBox.Tag = frmSearchTransaction.s_SearchID;

                    FillBankAndBranch(myTextBox.Tag.ToString(), DepositBankName, DepositBranchName);
                }
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

            if (iReportID == (int)enum_ReportName.RG_DepositedChequesBankAcct_Wise)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlBankAccount, true);
                clsCommon.SetVisibility_Panel(pnlDeletedRecords, true);
                clsCommon.SetVisibility_Panel(pnlDate, true);
            }

            else if (iReportID == (int)enum_ReportName.RG_DepositedCashBankAcct_Wise || iReportID == (int)enum_ReportName.RG_DepositedCashBankAcct_Wise_Detail)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlBankAccount, true);
                clsCommon.SetVisibility_Panel(pnlDeletedRecords, true);
                clsCommon.SetVisibility_Panel(pnlDate, true);
                rdoActive.Checked = true;
                chkAllBranches.Visible = true;
            }

            else if (iReportID == (int)enum_ReportName.RG_DepositedCashBankAcct_Wise_Detail)
            {
                clsCommon.SetVisibility_Panel(pnlShowAllBranches, true);
            }

            else if (iReportID == (int)enum_ReportName.RG_RedepositChequesBankAcct_Wise)
            {
                clsCommon.SetVisibility_Panel(pnlAccountNo, true);
                clsCommon.SetVisibility_Panel(pnlBankAccount, true);
                clsCommon.SetVisibility_Panel(pnlDeletedRecords, true);
                clsCommon.SetVisibility_Panel(pnlDate, true);
            }
            else if (iReportID == (int)enum_ReportName.RG_Realized_Cheque || iReportID == (int)enum_ReportName.RG_Returned_Cheque_BankWise)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                // clsCommon.SetVisibility_Panel(pnlSalesman, true);
                // clsCommon.SetVisibility_Panel(pnlBankAccount, true);
                // clsCommon.SetVisibility_Panel(pnlDeletedRecords, true);
                clsCommon.SetVisibility_Panel(pnlDate, true);
            }

            else if (iReportID == (int)enum_ReportName.RG_ChequeRegisterCheque_Weekly_ByReceiptDate || iReportID == (int)enum_ReportName.RG_ChequeRegisteredCheque_Daily ||
                iReportID == (int)enum_ReportName.RG_ChequeRegisteredCheque_Weekly_ByChequeDate || iReportID == (int)enum_ReportName.RG_ReIssuedChequesSummary ||
                iReportID == (int)enum_ReportName.RG_REIssuedChequesDaily)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlDeletedRecords, true);
                clsCommon.SetVisibility_Panel(pnlDate, true);
            }

            else if (iReportID == (int)enum_ReportName.ST_Pending_Cheque_Deposite || iReportID == (int)enum_ReportName.ST_Cheques_Age_Analysis)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlDate, true);
                //zpanel1.Enabled = false;
            }

            else if (iReportID == (int)enum_ReportName.ST_Cheque_In_HandAll)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlDeletedRecords, true);
                clsCommon.SetVisibility_Panel(pnlDate, true);
                rdoActive.Checked = true;
            }
            else if (iReportID == (int)enum_ReportName.ST_Cheque_In_Hand_Approved_For_Deposit || iReportID == (int)enum_ReportName.ST_ChequeIn_Hand_Pending_Approval)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlDeletedRecords, true);
            }

            else if (iReportID == (int)enum_ReportName.ST_Returned_Cheque_inHand)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlBankAccount, true);
                clsCommon.SetVisibility_Panel(pnlDeletedRecords, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_Returned_Cheque_Outstanding)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlChequeNo, true);
                clsCommon.SetVisibility_Panel(pnlDate, true);
                clsCommon.SetVisibility_Panel(pnlUseCustomerMasterSalesPerson, true);
                clsCommon.SetVisibility_Panel(pnlDeletedRecords, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_Cheque_In_Hand)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlBankAccount, true);
                clsCommon.SetVisibility_Panel(pnlDate, true);
                clsCommon.SetVisibility_Panel(pnlDeletedRecords, true);
            }
        }
        #endregion

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

        private void FillBankAndBranch(string sAccountNo, TextBox DepositBankName, TextBox DepositBranchName)
        {
            try
            {
                tbl_genCompanyAccount Adetail = tbl_genCompanyAccount.Select(sAccountNo);
                if (Adetail != null)
                {
                    tbl_zBank detail = tbl_zBank.Select(Adetail.Bank_ID);
                    if (detail != null)
                    {
                        DepositBankName.Text = detail.BankName;
                        DepositBankName.Tag = detail.Bank_ID;
                    }
                    tbl_zBankBranches details = tbl_zBankBranches.Select(Adetail.Branch_ID);
                    if (detail != null)
                    {
                        DepositBranchName.Text = details.BranchName;
                        DepositBranchName.Tag = details.Branch_ID;
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }

        private void txtSalesRep_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesRepID();
        }

        private void txtSalesRep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SalesRepID();
        }

        #region For Combobox Fill
        private string[] getDetail()
        {
            int iCount = tbl_zCustomerType.SelectAll().Count;
            int iTempCount = 1;
            //Count
            String[] oCustomerType = new string[iCount];
            foreach (tbl_zCustomerType oType in tbl_zCustomerType.SelectAll().Where(p => p.CustomerType_ID != "default"))
            {
                if (iCount != iTempCount)
                {
                    oCustomerType[iTempCount] = oType.TypeName;
                    iTempCount++;
                }
            }

            return oCustomerType;
        }

        private void AddItemToTypeComboBox(ComboBox cmbCustomer)
        {
            cmbCustomer.Items.Add("<All Customers>");
            foreach (string sTypeName in getDetail().Where(p => p != null))
            {
                cmbCustomer.Items.Add(sTypeName);
            }
            cmbCustomer.SelectedIndex = 0;
        }
        #endregion
    }
}