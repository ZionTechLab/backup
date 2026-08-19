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
    public partial class frm_rpt_BillsRegisterReports : MettroForm
    {
        #region Variables
        //form manage
        public int iFormID;

        //for security handle
        public bool bNoAccess;

        bool bCustomerSelected = false, bSelesRepSelected = false, bCreditNoteTypeSelected = false, bReceiptTypeSelected = false;

        dts_bssRegister glbdts_bssRegister = new dts_bssRegister();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        dts_bssDebitNote glb_dtsDebitNote = new dts_bssDebitNote();
        dts_CreditNote glb_dtsCreditNote = new dts_CreditNote();
        dts_SalesReceipt glb_dtsSalesReceipt = new dts_SalesReceipt();

        private int iReportNo;
        #endregion

        #region Form Load
        public frm_rpt_BillsRegisterReports()
        {
            iFormID = clsSecurity.getFormID(FormName.ReportBillsRegister);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }
        private void frm_rpt_BankManagementReports_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Bills Register Reports", 2, iFormID);
            txtSalesRep.Enabled = false;
            AddItemToTypeComboBox();
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
                dgvReports.DataSource = DBHandling.ExecQuery("EXEC sp_Reports '" + 8 + "'").Tables[0];
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
            Print();
        }

        public void Print()
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
                            if (clsHelpMethods.GetReportPath(clsAutocode.getReportID(Report), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                            {
                                bCustomerSelected = false; bSelesRepSelected = false; bCreditNoteTypeSelected = false; bReceiptTypeSelected = false;

                                if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Trim().Length > 0)
                                    bCustomerSelected = true;
                                if (txtSalesRep.Tag != null && txtSalesRep.Tag.ToString().Trim().Length > 0)
                                    bSelesRepSelected = true;
                                if (txtCreditNoteType.Tag != null && txtCreditNoteType.Tag.ToString().Trim().Length > 0)
                                    bCreditNoteTypeSelected = true;
                                if (cmbReceiptType.Text != null && cmbReceiptType.Text.ToString().Length > 0)
                                    bReceiptTypeSelected = true;

                                #region Filltering Data
                                string sFilter = "";//sFormula = "",

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

                                /* if (rdoActual.Checked)
                                 {
                                     if (sFilter != "")
                                         sFilter += " | ";
                                     sFilter += "Active records";
                                 }*/
                                if (rdoDeleted.Checked)
                                {
                                    if (sFilter != "")
                                        sFilter += " | ";
                                    sFilter += "Canceled records Only";
                                }
                                else if (rdoAll.Checked)
                                {
                                    if (sFilter != "")
                                        sFilter += " | ";
                                    sFilter += "All Records";
                                }

                                if (bCreditNoteTypeSelected)
                                {
                                    if (sFilter != "")
                                        sFilter += " | ";
                                    sFilter += "Credit Note Type:" + txtCreditNoteType.Text;
                                }

                                string sDateRange = "From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "  To : " + dtpTo.Value.ToString("dd MMM yyyy");

                                if (cmbReceiptType.Text == "Advanced Payment")
                                {
                                    if (sFilter != "")
                                        sFilter += " | ";
                                    sFilter += "Receipt Type :" + "Advanced Payment";

                                }
                                else if (cmbReceiptType.Text == "Part Payments")
                                {
                                    if (sFilter != "")
                                        sFilter += " | ";
                                    sFilter += "Receipt Type :" + "Part Payments";
                                }

                                if (chkCheque.Checked && chkCash.Checked && chkCash.Enabled && chkCheque.Enabled)
                                {
                                    if (sFilter != "")
                                        sFilter += " | ";
                                    sFilter += "Cheque & Cash";
                                }
                                else if (chkCash.Checked && chkCash.Enabled)
                                {
                                    if (sFilter != "")
                                        sFilter += " | ";
                                    sFilter += "Cash";
                                }
                                else if (chkCheque.Checked && chkCheque.Enabled)
                                {
                                    if (sFilter != "")
                                        sFilter += " | ";
                                    sFilter += "Cheque";
                                }

                                /*if (rdoDeleted.Checked)
                                  {
                                      if (sFilter != "")
                                          sFilter += " | ";
                                      sFilter += "Canceled records";
                                  }
                                  else if (rdoAll.Checked)
                                  {
                                      if (sFilter != "")
                                          sFilter += " | ";
                                      sFilter += "All records";
                                  }*/

                                if (cmbCustomerType.Text != "<All Customers>".Trim())
                                {
                                    if (sFilter != "")
                                        sFilter += " | ";
                                    sFilter += "Customer Type: " + cmbCustomerType.Text;
                                }
                                #endregion

                                #region Receipt Summary
                                if (Report == enum_ReportName.RG_SalesReceiptSummary || Report == enum_ReportName.RG_InterimReceiptSummary || Report == enum_ReportName.RG_ReceiptSummary)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glbdts_bssRegister.Clear();
                                        tbl_zCustomerType oCType = null;

                                        foreach (tbl_bpsReceipt oReceipt in tbl_bpsReceipt.SelectAll().Where(p => p.Receipt_ID != "default" && p.ReceiptDate.Date >= dtpFrom.Value.Date && p.ReceiptDate.Date <= dtpTo.Value.Date && p.CompanyBranch_ID == clsSecurity.BranchID))
                                        {
                                            string sSalesRepID = "", sCustomerName = "";

                                            if (Report == enum_ReportName.RG_SalesReceiptSummary)
                                            {
                                                if (oReceipt.IsSalesReceipt != true)
                                                    continue;
                                            }

                                            else if (Report == enum_ReportName.RG_InterimReceiptSummary)
                                            {
                                                if (oReceipt.IsSalesReceipt != false)
                                                    continue;
                                            }

                                            if (chkCheckedrecOnly.Checked)
                                            {
                                                if (!oReceipt.IsChecked)
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

                                            #region Common Filter
                                            if (bCustomerSelected)
                                                if (oReceipt.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                    continue;

                                            if (bSelesRepSelected)
                                                if (sSalesRepID != txtSalesRep.Tag.ToString().Trim())
                                                    continue;

                                            if (cmbReceiptType.Text == "Advanced Payment")
                                            {
                                                if (oReceipt.IsAdvance != true)
                                                    continue;
                                            }
                                            else if (cmbReceiptType.Text == "Part Payments")
                                            {
                                                if (oReceipt.IsAdvance != false)
                                                    continue;
                                            }

                                            if (rdoDeleted.Checked)
                                                if (oReceipt.IsDeleted != true)
                                                    continue;

                                            if (rdoActual.Checked)
                                                if (oReceipt.IsDeleted != false)
                                                    continue;

                                            //if (chkCheque.Checked && chkCash.Checked)
                                            //{
                                            //    if (oReceipt.CashAmount == 0 && oReceipt.ChequeAmount == 0)
                                            //        continue;
                                            //}
                                            //else if (chkCheque.Checked)
                                            //{
                                            //    if (oReceipt.CashAmount != 0)
                                            //        continue;
                                            //}
                                            //else if (chkCash.Checked)
                                            //{
                                            //    if (oReceipt.ChequeAmount != 0)
                                            //        continue;
                                            //}
                                            //else
                                            //{
                                            //    break;
                                            //}

                                            if (cmbCustomerType.Text != "<All Customers>".Trim())
                                            {
                                                if (oCType != null)
                                                    if (oCType.TypeName != cmbCustomerType.Text.Trim())
                                                        continue;
                                            }
                                            #endregion

                                            decimal dOtherAmount = 0, dChequeAmount = 0;
                                            foreach (tbl_bpsChequeRegister oChequeRegister in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID))
                                            {
                                                if (oChequeRegister.PaymentMethod_ID == 1)
                                                    dChequeAmount += oChequeRegister.Amount;
                                                else
                                                    dOtherAmount += oChequeRegister.Amount;
                                            }

                                            if (chkCheque.Checked && chkCash.Checked)
                                            {
                                                if (dOtherAmount == 0 && dChequeAmount == 0)
                                                    continue;
                                            }
                                            else if (chkCheque.Checked)
                                            {
                                                if (dOtherAmount != 0)
                                                    continue;
                                            }
                                            else if (chkCash.Checked)
                                            {
                                                if (dChequeAmount != 0)
                                                    continue;
                                            }
                                            else
                                            {
                                                break;
                                            }

                                            glbdts_bssRegister.dt_Receipt.Adddt_ReceiptRow(oReceipt.Receipt_ID, oReceipt.ReceiptDate, oReceipt.Customer_ID, sCustomerName, dOtherAmount, dChequeAmount, dOtherAmount + dChequeAmount, oReceipt.IsDeleted);
                                        }

                                        glbdts_bssRegister.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDateRange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glbdts_bssRegister, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glbdts_bssRegister.Clear();
                                    }
                                }
                                #endregion

                                #region Receipt Details
                                if (Report == enum_ReportName.RG_ReceiptDetails)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dtsSalesReceipt.Clear();
                                        tbl_zCustomerType oCType = null;

                                        foreach (tbl_bpsReceipt oReceipt in tbl_bpsReceipt.SelectAll().Where(p => p.Receipt_ID != "default" && p.ReceiptDate.Date >= dtpFrom.Value.Date && p.ReceiptDate.Date <= dtpTo.Value.Date && p.CompanyBranch_ID == clsSecurity.BranchID))
                                        {
                                            string sSalesRepID = "", sCustomerName = "";

                                            #region Set Sales rep
                                            tbl_genCustomerMaster oMaster = tbl_genCustomerMaster.Select(oReceipt.Customer_ID);
                                            if (oMaster != null)
                                            {
                                                oCType = tbl_zCustomerType.Select(oMaster.CustomerType_ID);
                                                sCustomerName = oMaster.CustomerName;
                                                sSalesRepID = oMaster.SalesRep_ID;
                                            }
                                            #endregion

                                            #region Common Filter
                                            if (bCustomerSelected)
                                                if (oReceipt.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                    continue;

                                            if (bSelesRepSelected)
                                                if (sSalesRepID != txtSalesRep.Tag.ToString().Trim())
                                                    continue;

                                            if (rdoDeleted.Checked)
                                                if (oReceipt.IsDeleted != true)
                                                    continue;

                                            if (rdoActual.Checked)
                                                if (oReceipt.IsDeleted != false)
                                                    continue;

                                            decimal dOtherAmount = 0, dChequeAmount = 0, dTotalAmount = 0;
                                            foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID))
                                            {
                                                if (oCheque.PaymentMethod_ID == 1)
                                                    dChequeAmount += oCheque.Amount;
                                                else
                                                    dOtherAmount += oCheque.Amount;

                                                dTotalAmount = dChequeAmount + dOtherAmount;
                                            }

                                            if (chkCheque.Checked && chkCash.Checked)
                                            {
                                                if (dOtherAmount == 0 && dChequeAmount == 0)
                                                    continue;
                                            }
                                            else if (chkCheque.Checked)
                                            {
                                                if (dOtherAmount != 0)
                                                    continue;
                                            }
                                            else if (chkCash.Checked)
                                            {
                                                if (dChequeAmount != 0)
                                                    continue;
                                            }
                                            //if (chkCheque.Checked && chkCash.Checked)
                                            //{
                                            //    if (oReceipt.CashAmount == 0 && oReceipt.ChequeAmount == 0)
                                            //        continue;
                                            //}
                                            //else if (chkCheque.Checked)
                                            //{
                                            //    if (oReceipt.CashAmount != 0)
                                            //        continue;
                                            //}
                                            //else if (chkCash.Checked)
                                            //{
                                            //    if (oReceipt.ChequeAmount != 0)
                                            //        continue;
                                            //}
                                            else
                                            {
                                                break;
                                            }

                                            if (cmbCustomerType.Text != "<All Customers>".Trim())
                                            {
                                                if (oCType != null)
                                                    if (oCType.TypeName != cmbCustomerType.Text.Trim())
                                                        continue;
                                            }
                                            #endregion

                                            glb_dtsSalesReceipt.dt_sasSalesReceiptHeader.Adddt_sasSalesReceiptHeaderRow(oReceipt.Receipt_ID, oReceipt.ReceiptDate, oReceipt.Customer_ID, sCustomerName, oReceipt.Currency_ID, oReceipt.CurrencyRate, dOtherAmount, dChequeAmount, dTotalAmount, oReceipt.IsDeleted, oReceipt.IsSalesReceipt, oReceipt.IsAdvance, oReceipt.Remark, clsGenaralName.getName_SalesRep(sSalesRepID), oReceipt.SalesNoteType_ID, "", "", oReceipt.OrderRefNo_ID, clsGenaralName.getName_User(oReceipt.CreateUser_ID), oReceipt.DateCreate, clsGenaralName.getName_User(oReceipt.CheckedUser_ID), oReceipt.DateChecked, clsGenaralName.getName_User(oReceipt.ApprovedUser_ID), oReceipt.DateApproved);

                                            foreach (tbl_bpsChequeRegister oDetails in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID))
                                            {
                                                glb_dtsSalesReceipt.dt_sasSalesReceipt_Details.Adddt_sasSalesReceipt_DetailsRow(oDetails.Receipt_ID, oDetails.AccountNumber, oDetails.Bank_ID, clsGenaralName.getName_Bank(oDetails.Bank_ID), oDetails.Branch_ID, clsGenaralName.getName_BankBranch(oDetails.Branch_ID), oDetails.ChequeNumber, oDetails.DateCheque, oDetails.Amount, oDetails.ChequeType_ID, oDetails.ChequeStatus_ID);
                                            }

                                            //tbl_accGLPosting oPosting = tbl_accGLPosting.Select(oReceipt.GlPosting_ID);
                                            //if (oPosting != null)
                                            //{
                                            foreach (tbl_bpsChequeRegister oChequeDetails in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID))
                                            {
                                                foreach (tbl_accGLPosting_Detail oPostingDetails in tbl_accGLPosting_Detail.SelectAllByGlPosting_ID(oChequeDetails.GlPosting_ID))
                                                {
                                                    tbl_accGLMaster oGLMas = tbl_accGLMaster.Select(oPostingDetails.Gl_ID);
                                                    if (oGLMas != null)
                                                    {
                                                        glb_dtsSalesReceipt.dt_GL_Posting.Adddt_GL_PostingRow(oReceipt.Receipt_ID, oGLMas.Gl_ID, oGLMas.GlName, oPostingDetails.Amount, oPostingDetails.IsCredit);
                                                    }
                                                }
                                                //}
                                            }
                                        }

                                        glb_dtsSalesReceipt.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDateRange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dtsSalesReceipt, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glbdts_bssRegister.Clear();
                                    }
                                }
                                #endregion

                                #region Credit Note Summary
                                else if (Report == enum_ReportName.RG_CreditNoteSummary)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glbdts_bssRegister.Clear();

                                        foreach (tbl_bpsCreditNote oCNote in tbl_bpsCreditNote.SelectAll().Where(p => p.CreditNote_ID != "default" && p.CreditNoteType_ID != clsAutocode.getCreditNoteTypeID(CreditNoteType.ReturnedChequeDeposit) && p.CreditNoteDate.Date >= dtpFrom.Value.Date && p.CreditNoteDate.Date <= dtpTo.Value.Date && p.AdvanceReceived_Index < 0 && p.PosReturnTransaction_Index < 0))
                                        {
                                            if (bCustomerSelected)
                                                if (oCNote.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                    continue;

                                            if (bSelesRepSelected)
                                            {
                                                tbl_zOrderRefNo oOrderRef = tbl_zOrderRefNo.Select(oCNote.OrderRefNo_ID);
                                                if (oOrderRef != null && oOrderRef.OrderRefNo != "default")
                                                {
                                                    if (oOrderRef.Employee_ID != txtSalesRep.Tag.ToString().Trim())
                                                        continue;
                                                }
                                            }

                                            if (bCreditNoteTypeSelected)
                                                if (oCNote.CreditNoteType_ID != txtCreditNoteType.Tag.ToString().Trim())
                                                    continue;

                                            if (rdoDeleted.Checked)
                                                if (oCNote.IsDeleted != true)
                                                    continue;
                                            if (rdoActual.Checked)
                                                if (oCNote.IsDeleted != false)
                                                    continue;

                                            glbdts_bssRegister.dt_CreditNoteSummary.Adddt_CreditNoteSummaryRow(oCNote.CreditNote_ID, oCNote.CreditNoteDate, clsGenaralName.getName_Customer(oCNote.Customer_ID), clsGenaralName.getName_CreditNoteType(oCNote.CreditNoteType_ID), oCNote.Invoice_ID, oCNote.Remark, oCNote.TotalAmount, oCNote.IsDeleted);
                                        }

                                        glbdts_bssRegister.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDateRange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glbdts_bssRegister, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glbdts_bssRegister.Clear();
                                    }
                                }
                                #endregion

                                #region Credit Note Details
                                else if (Report == enum_ReportName.RG_CreditNoteDetail)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dtsCreditNote.Clear();
                                        foreach (tbl_bpsCreditNote oCNote in tbl_bpsCreditNote.SelectAll().Where(p => p.CreditNote_ID != "default" && p.CreditNoteType_ID != clsAutocode.getCreditNoteTypeID(CreditNoteType.ReturnedChequeDeposit) && p.CreditNoteDate.Date >= dtpFrom.Value.Date && p.CreditNoteDate.Date <= dtpTo.Value.Date && p.AdvanceReceived_Index < 0 && p.PosReturnTransaction_Index < 0))
                                        {
                                            #region Selected Filters
                                            if (bCustomerSelected)
                                                if (oCNote.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                    continue;

                                            if (bSelesRepSelected)
                                            {
                                                tbl_zOrderRefNo oOrderRef = tbl_zOrderRefNo.Select(oCNote.OrderRefNo_ID);
                                                if (oOrderRef != null && oOrderRef.OrderRefNo != "default")
                                                {
                                                    if (oOrderRef.Employee_ID != txtSalesRep.Tag.ToString().Trim())
                                                        continue;
                                                }
                                            }

                                            if (bCreditNoteTypeSelected)
                                                if (oCNote.CreditNoteType_ID != txtCreditNoteType.Tag.ToString().Trim())
                                                    continue;

                                            if (rdoDeleted.Checked)
                                                if (oCNote.IsDeleted != true)
                                                    continue;
                                            if (rdoActual.Checked)
                                                if (oCNote.IsDeleted != false)
                                                    continue;
                                            #endregion

                                            tbl_genCustomerFinance oCusFin = tbl_genCustomerFinance.Select(oCNote.Customer_ID);
                                            glb_dtsCreditNote.dt_CreditNote_Summary.Adddt_CreditNote_SummaryRow(oCNote.CreditNote_ID, oCNote.CreditNoteDate, clsGenaralName.getName_CreditNoteType(oCNote.CreditNoteType_ID), oCNote.Customer_ID, clsGenaralName.getName_Customer(oCNote.Customer_ID), oCNote.Currency_ID, oCNote.CurrencyRate, oCNote.SubTotal, oCNote.VatTotal, oCNote.OtherTaxTotal, oCNote.NbtTotal, oCNote.TotalAmount, oCNote.DiscountTotal, 0, oCNote.OrderRefNo_ID, "", clsGenaralName.getName_SalesNoteType(oCNote.SalesNoteType_ID), oCusFin.CreditPeriod.ToString(), oCNote.IsDeleted, oCNote.Remark, clsGenaralName.getName_User(oCNote.CreateUser_ID), oCNote.DateCreate, clsGenaralName.getName_User(oCNote.CheckedUser_ID), oCNote.DateChecked, clsGenaralName.getName_User(oCNote.ApprovedUser_ID), oCNote.DateApproved);

                                            foreach (tbl_bpsCreditNote_Invoice oDetail in tbl_bpsCreditNote_Invoice.SelectAllByCreditNote_ID(oCNote.CreditNote_ID))
                                            {
                                                tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(oDetail.Invoice_ID);
                                                if (oInvoice != null)
                                                {
                                                    decimal dBalanceAmount = (oInvoice.GrandTotal - oInvoice.SeattleAmount) / oInvoice.CurrencyRate;
                                                    decimal dDueAmount = oInvoice.GrandTotal - (dBalanceAmount + oDetail.AlocatedAmount);

                                                    glb_dtsCreditNote.dt_CreditNote_Details.Adddt_CreditNote_DetailsRow(oDetail.CreditNote_ID, oDetail.Invoice_ID, oInvoice.InvoiceDate, oInvoice.GrandTotal, dBalanceAmount, oDetail.AlocatedAmount, dDueAmount);
                                                }
                                            }

                                            tbl_accGLPosting oPosting = tbl_accGLPosting.Select(oCNote.GlPosting_ID);
                                            if (oPosting != null)
                                            {
                                                foreach (tbl_accGLPosting_Detail oPostingDetails in tbl_accGLPosting_Detail.SelectAllByGlPosting_ID(oCNote.GlPosting_ID))
                                                {
                                                    tbl_accGLMaster oGLMas = tbl_accGLMaster.Select(oPostingDetails.Gl_ID);
                                                    if (oGLMas != null)
                                                    {
                                                        glb_dtsCreditNote.dt_GL_Posting.Adddt_GL_PostingRow(oCNote.CreditNote_ID, oGLMas.Gl_ID, oGLMas.GlName, oPostingDetails.Amount, oPostingDetails.IsCredit);
                                                    }
                                                }
                                            }
                                        }

                                        glb_dtsCreditNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDateRange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dtsCreditNote, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glbdts_bssRegister.Clear();
                                    }
                                }
                                #endregion

                                #region Debit  Note Summary
                                else if (Report == enum_ReportName.RG_DebitNoteSummary)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glbdts_bssRegister.Clear();
                                        foreach (tbl_bpsDebitNote oDebit in tbl_bpsDebitNote.SelectAll().Where(p => p.DebitNote_ID != "default" && p.DebitNoteType_ID!= "ITC/001" && p.DebitNoteDate.Date >= dtpFrom.Value.Date && p.DebitNoteDate.Date <= dtpTo.Value.Date))
                                        {
                                            if (bCustomerSelected)
                                                if (oDebit.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                    continue;
                                            if (bSelesRepSelected)
                                            {
                                                tbl_zOrderRefNo oOrderRef = tbl_zOrderRefNo.Select(oDebit.OrderRefNo_ID);
                                                if (oOrderRef != null && oOrderRef.OrderRefNo != "default")
                                                {
                                                    if (oOrderRef.Employee_ID != txtSalesRep.Tag.ToString().Trim())
                                                        continue;
                                                }
                                            }
                                            if (rdoDeleted.Checked)
                                                if (oDebit.IsDeleted != true)
                                                    continue;
                                            if (rdoActual.Checked)
                                                if (oDebit.IsDeleted != false)
                                                    continue;

                                            glbdts_bssRegister.dt_DebitNoteSummary.Adddt_DebitNoteSummaryRow(oDebit.DebitNote_ID, clsGenaralName.getName_Customer(oDebit.Customer_ID), oDebit.DebitNoteDate, clsGenaralName.getName_DebitNoteType(oDebit.DebitNoteType_ID), oDebit.TotalAmount, oDebit.IsDeleted);

                                        }
                                        glbdts_bssRegister.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDateRange, clsSecurity.UserNameLoged, sFilter);
                                        
                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glbdts_bssRegister, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {

                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glbdts_bssRegister.Clear();
                                    }
                                }
                                #endregion

                                #region Debit  Note Details
                                else if (Report == enum_ReportName.RG_DebitNoteDetails)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dtsDebitNote.Clear();

                                        foreach (tbl_bpsDebitNote oDebit in tbl_bpsDebitNote.SelectAll().Where(p => p.DebitNote_ID != "default" && p.DebitNoteType_ID != "ITC/001" && p.DebitNoteDate.Date >= dtpFrom.Value.Date && p.DebitNoteDate.Date <= dtpTo.Value.Date))
                                        {
                                            #region Selected Filters
                                            if (bCustomerSelected)
                                                if (oDebit.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                    continue;
                                            if (bSelesRepSelected)
                                            {
                                                tbl_zOrderRefNo oOrderRef = tbl_zOrderRefNo.Select(oDebit.OrderRefNo_ID);
                                                if (oOrderRef != null && oOrderRef.OrderRefNo != "default")
                                                {
                                                    if (oOrderRef.Employee_ID != txtSalesRep.Tag.ToString().Trim())
                                                        continue;
                                                }
                                            }
                                            if (rdoDeleted.Checked)
                                                if (oDebit.IsDeleted != true)
                                                    continue;
                                            if (rdoActual.Checked)
                                                if (oDebit.IsDeleted != false)
                                                    continue;
                                            #endregion

                                            tbl_genCustomerFinance oCusFin = tbl_genCustomerFinance.Select(oDebit.Customer_ID);
                                            glb_dtsDebitNote.dt_DebitNote_Summary.Adddt_DebitNote_SummaryRow(oDebit.DebitNote_ID, oDebit.DebitNoteDate, clsGenaralName.getName_DebitNoteType(oDebit.DebitNoteType_ID), oDebit.Customer_ID, clsGenaralName.getName_Customer(oDebit.Customer_ID), oDebit.Currency_ID, oDebit.CurrencyRate, oDebit.SubTotal, oDebit.DiscountTotal, oDebit.NbtTotal, oDebit.VatTotal, oDebit.OtherTaxTotal, oDebit.TotalAmount, oDebit.OrderRefNo_ID, "", clsGenaralName.getName_SalesNoteType(oDebit.SalesNoteType_ID), oCusFin.CreditPeriod.ToString(), oDebit.IsDeleted, oDebit.Remark, clsGenaralName.getName_User(oDebit.CreateUser_ID), oDebit.DateCreate, clsGenaralName.getName_User(oDebit.CheckedUser_ID), oDebit.DateChecked, clsGenaralName.getName_User(oDebit.ApprovedUser_ID), oDebit.DateApproved);

                                            tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(oDebit.DebitNote_ID);
                                            if (oInvoice != null)
                                            {
                                                if (oInvoice.IsDebitNote == true)
                                                {
                                                    decimal dBalanceAmount = (oInvoice.GrandTotal - oInvoice.SeattleAmount) / oInvoice.CurrencyRate;
                                                    decimal dDueAmount = oInvoice.GrandTotal - (dBalanceAmount + 0);

                                                    glb_dtsDebitNote.dt_DebitNote_Details.Adddt_DebitNote_DetailsRow(oDebit.DebitNote_ID, oInvoice.Invoice_ID, oInvoice.InvoiceDate, "", DateTime.Now, oInvoice.GrandTotal, dBalanceAmount, 0, dDueAmount);
                                                }
                                            }
                                            tbl_accGLPosting oPosting = tbl_accGLPosting.Select(oDebit.GlPosting_ID);
                                            if (oPosting != null)
                                            {
                                                foreach (tbl_accGLPosting_Detail oPostingDetails in tbl_accGLPosting_Detail.SelectAllByGlPosting_ID(oDebit.GlPosting_ID))
                                                {
                                                    tbl_accGLMaster oGLMas = tbl_accGLMaster.Select(oPostingDetails.Gl_ID);
                                                    if (oGLMas != null)
                                                    {
                                                       glb_dtsDebitNote.dt_GL_Posting.Adddt_GL_PostingRow(oDebit.DebitNote_ID, oGLMas.Gl_ID, oGLMas.GlName, oPostingDetails.Amount, oPostingDetails.IsCredit);                                                       
                                                    }
                                                }
                                            }
                                        }

                                        glb_dtsDebitNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDateRange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dtsDebitNote, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glbdts_bssRegister.Clear();
                                    }
                                }
                                #endregion

                                #region Inter Company Transfer Summary

                                else if (Report == enum_ReportName.RG_InterCompanyTranferSummary)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glbdts_bssRegister.Clear();
                                        foreach (tbl_bpsDebitNote oDebit in tbl_bpsDebitNote.SelectAll().Where(p => p.DebitNote_ID != "default" && p.DebitNoteType_ID == "ITC/001" && p.DebitNoteDate.Date >= dtpFrom.Value.Date && p.DebitNoteDate.Date <= dtpTo.Value.Date))
                                        {
                                            if (bCustomerSelected)
                                                if (oDebit.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                    continue;
                                            if (bSelesRepSelected)
                                            {
                                                tbl_zOrderRefNo oOrderRef = tbl_zOrderRefNo.Select(oDebit.OrderRefNo_ID);
                                                if (oOrderRef != null && oOrderRef.OrderRefNo != "default")
                                                {
                                                    if (oOrderRef.Employee_ID != txtSalesRep.Tag.ToString().Trim())
                                                        continue;
                                                }
                                            }
                                            if (rdoDeleted.Checked)
                                                if (oDebit.IsDeleted != true)
                                                    continue;
                                            if (rdoActual.Checked)
                                                if (oDebit.IsDeleted != false)
                                                    continue;

                                            glbdts_bssRegister.dt_DebitNoteSummary.Adddt_DebitNoteSummaryRow(oDebit.DebitNote_ID, clsGenaralName.getName_Customer(oDebit.Customer_ID), oDebit.DebitNoteDate, clsGenaralName.getName_DebitNoteType(oDebit.DebitNoteType_ID), oDebit.TotalAmount, oDebit.IsDeleted);

                                        }
                                        glbdts_bssRegister.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDateRange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glbdts_bssRegister, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {

                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glbdts_bssRegister.Clear();
                                    }
                                }
                                #endregion

                                #region Inter Company Transfer Details
                                else if (Report == enum_ReportName.RG_InterCompanyTranferDetail)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dtsDebitNote.Clear();

                                        foreach (tbl_bpsDebitNote oDebit in tbl_bpsDebitNote.SelectAll().Where(p => p.DebitNote_ID != "default" && p.DebitNoteType_ID == "ITC/001" && p.DebitNoteDate.Date >= dtpFrom.Value.Date && p.DebitNoteDate.Date <= dtpTo.Value.Date))
                                        {
                                            #region Selected Filters
                                            if (bCustomerSelected)
                                                if (oDebit.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                    continue;
                                            if (bSelesRepSelected)
                                            {
                                                tbl_zOrderRefNo oOrderRef = tbl_zOrderRefNo.Select(oDebit.OrderRefNo_ID);
                                                if (oOrderRef != null && oOrderRef.OrderRefNo != "default")
                                                {
                                                    if (oOrderRef.Employee_ID != txtSalesRep.Tag.ToString().Trim())
                                                        continue;
                                                }
                                            }
                                            if (rdoDeleted.Checked)
                                                if (oDebit.IsDeleted != true)
                                                    continue;
                                            if (rdoActual.Checked)
                                                if (oDebit.IsDeleted != false)
                                                    continue;
                                            #endregion

                                            tbl_genCustomerFinance oCusFin = tbl_genCustomerFinance.Select(oDebit.Customer_ID);
                                            glb_dtsDebitNote.dt_DebitNote_Summary.Adddt_DebitNote_SummaryRow(oDebit.DebitNote_ID, oDebit.DebitNoteDate, clsGenaralName.getName_DebitNoteType(oDebit.DebitNoteType_ID), oDebit.Customer_ID, clsGenaralName.getName_Customer(oDebit.Customer_ID), oDebit.Currency_ID, oDebit.CurrencyRate, oDebit.SubTotal, oDebit.DiscountTotal, oDebit.NbtTotal, oDebit.VatTotal, oDebit.OtherTaxTotal, oDebit.TotalAmount, oDebit.OrderRefNo_ID, "", clsGenaralName.getName_SalesNoteType(oDebit.SalesNoteType_ID), oCusFin.CreditPeriod.ToString(), oDebit.IsDeleted, oDebit.Remark, clsGenaralName.getName_User(oDebit.CreateUser_ID), oDebit.DateCreate, clsGenaralName.getName_User(oDebit.CheckedUser_ID), oDebit.DateChecked, clsGenaralName.getName_User(oDebit.ApprovedUser_ID), oDebit.DateApproved);

                                            tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(oDebit.DebitNote_ID);
                                            if (oInvoice != null)
                                            {
                                                if (oInvoice.IsDebitNote == true)
                                                {
                                                    decimal dBalanceAmount = (oInvoice.GrandTotal - oInvoice.SeattleAmount) / oInvoice.CurrencyRate;
                                                    decimal dDueAmount = oInvoice.GrandTotal - (dBalanceAmount + 0);

                                                    glb_dtsDebitNote.dt_DebitNote_Details.Adddt_DebitNote_DetailsRow(oDebit.DebitNote_ID, oInvoice.Invoice_ID, oInvoice.InvoiceDate, "", DateTime.Now, oInvoice.GrandTotal, dBalanceAmount, 0, dDueAmount);
                                                }
                                            }
                                            tbl_accGLPosting oPosting = tbl_accGLPosting.Select(oDebit.GlPosting_ID);
                                            if (oPosting != null)
                                            {
                                                foreach (tbl_accGLPosting_Detail oPostingDetails in tbl_accGLPosting_Detail.SelectAllByGlPosting_ID(oDebit.GlPosting_ID))
                                                {
                                                    tbl_accGLMaster oGLMas = tbl_accGLMaster.Select(oPostingDetails.Gl_ID);
                                                    if (oGLMas != null)
                                                    {
                                                        glb_dtsDebitNote.dt_GL_Posting.Adddt_GL_PostingRow(oDebit.DebitNote_ID, oGLMas.Gl_ID, oGLMas.GlName, oPostingDetails.Amount, oPostingDetails.IsCredit);
                                                    }
                                                }
                                            }
                                        }

                                        glb_dtsDebitNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDateRange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dtsDebitNote, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID,ex);
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
            txtCustomer.Text = "<<ALL Customer>>";
            txtSalesRep.Text = "<<ALL Salesman>>";
            txtCreditNoteType.Text = "<<All Credit Type>>";

            txtCustomer.Tag = null;
            txtSalesRep.Tag = null;
            txtCreditNoteType.Tag = null;

            cmbReceiptType.SelectedIndex = 0;
            rdoActual.Checked = true;

            chkCash.Checked = true;
            chkCheque.Checked = true;
            cmbCustomerType.SelectedIndex = 0;

            chkCheckedrecOnly.Checked = false;
            chkCheckedrecOnly.Visible = false;
            chkShowAll.Checked = false;
        }
        #endregion

        #region Print Method
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
                if (cmbReceiptType.Text != "All Payment")
                {
                    if (bReceiptTypeSelected)
                    {
                        if (bHasItem)
                            sFilter += " / ";
                        sFilter += "Receipt type : " + cmbReceiptType.Text.Trim();
                        bHasItem = true;
                    }
                }
                if (bCreditNoteTypeSelected)
                {
                    if (bHasItem)
                        sFilter += " / ";
                    sFilter += "Credit Note Type : " + txtCreditNoteType.Text.Trim();
                    bHasItem = true;
                }

                RD.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sFilter);

                viewer.Process_Print(iReportNo);
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
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void print(string path, string sReportTitle, DataSet objDataSet)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Standed Reports";
                CrystalDecisions.CrystalReports.Engine.ReportDocument objRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(objDataSet); //(glbDtsBills);

                try
                {
                    objRpt.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                    objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                    objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                    objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                    objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                    objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                    objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                    objRpt.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                }
                catch (Exception)
                {

                }
                //if (bCustomerSelected)
                //    sReportFilter += " Customer Name : " + txtCustomer.Text.Trim();                    
                //if (bSelesRepSelected)
                //    sReportFilter += " Salesman Name : " + txtSalesRep.Text.Trim();

                string sFilter = "";
                bool bHasItem = false;
                if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Length > 0)
                {
                    sFilter += "Customer Name : " + txtCustomer.Text.Trim();
                    bHasItem = true;
                }

                if (txtSalesRep.Tag != null && txtSalesRep.Tag.ToString().Length > 0)
                {
                    if (bHasItem)
                        sFilter += " / ";
                    sFilter += "Sales Rep Name : " + txtSalesRep.Text.Trim();
                    bHasItem = true;
                }

                if (rdoActual.Checked)
                {
                    if (bHasItem)
                        sFilter += " / ";
                    sFilter += "Available Debit Notes";
                    bHasItem = true;

                }
                else if (rdoDeleted.Checked)
                {
                    if (bHasItem)
                        sFilter += " / ";
                    sFilter += "Canceled Debit Notes";
                    bHasItem = true;
                }
                else
                {
                    if (bHasItem)
                        sFilter += " / ";
                    sFilter += "All Debit Notes";
                    bHasItem = true;
                }

                objRpt.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sFilter);

                frm_ReportViewer ReportViewer = new frm_ReportViewer();
                ReportViewer.Process_Print(iReportNo);
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
                clsValidate.WriteErrorLog("", iFormID,ex);
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

        private void txtCreditNoteType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CreditNoteType();
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
        private void txtCreditNoteType_DoubleClick(object sender, EventArgs e)
        {
            Search_CreditNoteType();
        }
        private void txtSalesRep_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesRepID();
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
            clsSearch.Search_MasterCustomer(ref txtCustomer, chkShowAll.Checked);

            //Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_CustomerMaster();
            //frmhelpsearch.ShowDialog();

            //if (frmSearchMaster.s_SearchID.Length > 0)
            //{
            //    if (frmSearchMaster.s_SearchText.Length > 0)
            //        txtCustomer.Text = frmSearchMaster.s_SearchText;
            //    if (frmSearchMaster.s_SearchID.Length > 0)
            //        txtCustomer.Tag = frmSearchMaster.s_SearchID;
            //}
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

        private void Search_CreditNoteType()
        {
            try
            {
                clsSearch.Search_MasterCreditNoteType(ref txtCreditNoteType);
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
            clsCommon.SetEnableDisable_NormalTextbox(txtCreditNoteType, false);
            clsCommon.SetEnableDisable_NormalLabel(lblCreditNoteType, false);
            clsCommon.SetEnableDisable_NormalCheckBox(chkCash, false);
            clsCommon.SetEnableDisable_NormalCheckBox(chkCheque, false);
            clsCommon.SetEnableDisable_NormalComboBox(cmbCustomerType, false);
            clsCommon.SetEnableDisable_NormalComboBox(cmbReceiptType, false);
            clsCommon.SetEnableDisable_NormalLabel(lblReceiptType, false);
            clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, false);

            if (iReport == (int)enum_ReportName.RG_SalesReceiptSummary || iReport == (int)enum_ReportName.RG_InterimReceiptSummary ||
                iReport == (int)enum_ReportName.RG_ReceiptSummary || iReport == (int)enum_ReportName.RG_ReceiptDetails)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);
                clsCommon.SetEnableDisable_NormalComboBox(cmbReceiptType, true);
                clsCommon.SetEnableDisable_NormalLabel(lblReceiptType, true);
                clsCommon.SetEnableDisable_NormalRadioButton(rdoDeleted, true);
                clsCommon.SetEnableDisable_NormalRadioButton(rdoActual, true);
                clsCommon.SetEnableDisable_NormalRadioButton(rdoAll, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkCash, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkCheque, true);
                clsCommon.SetEnableDisable_NormalComboBox(cmbCustomerType, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
                chkCheckedrecOnly.Visible = true;
            }
            else if (iReport == (int)enum_ReportName.RG_CreditNoteSummary || iReport == (int)enum_ReportName.RG_CreditNoteDetail)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtCreditNoteType, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCreditNoteType, true);
                clsCommon.SetEnableDisable_NormalRadioButton(rdoDeleted, true);
                clsCommon.SetEnableDisable_NormalRadioButton(rdoActual, true);
                clsCommon.SetEnableDisable_NormalRadioButton(rdoAll, true);
            }
            else if (iReport == (int)enum_ReportName.RG_DebitNoteSummary || iReport == (int)enum_ReportName.RG_DebitNoteDetails)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtCreditNoteType, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCreditNoteType, true);
                clsCommon.SetEnableDisable_NormalRadioButton(rdoDeleted, true);
                clsCommon.SetEnableDisable_NormalRadioButton(rdoActual, true);
                clsCommon.SetEnableDisable_NormalRadioButton(rdoAll, true);
            }
        }
        #endregion

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


        public void AddItemToTypeComboBox()
        {
            cmbCustomerType.Items.Add("<All Customers>");
            foreach (string sTypeName in getDetail().Where(p => p != null))
            {
                cmbCustomerType.Items.Add(sTypeName);
            }
            cmbCustomerType.SelectedIndex = 0;
        }
        #endregion

        public void setReport(enum_ReportName enmRpt)
        {
            if (enmRpt == enum_ReportName.RG_ReceiptSummary)
                rdoRecieptSummary.Checked = true;
        }
        public void SetParameeters(DateTime dtmFrom, DateTime dtmTo, bool isChequeReciept, bool isDeletedRecordsOnly)
        {
            dtpFrom.Value = dtmFrom;
            dtpTo.Value = dtmTo;
            chkCheque.Checked = isChequeReciept;
            rdoDeleted.Checked = isDeletedRecordsOnly;
        }
    }
}


#region Events CheckedChanged

//private void rdoRecieptSummary_CheckedChanged(object sender, EventArgs e)
//{
//    setEnableDisableConctrol();
//}
//private void rdoRecieptSummary_Sales_CheckedChanged(object sender, EventArgs e)
//{
//    setEnableDisableConctrol();
//}
//private void rdoRecieptSummary_Account_CheckedChanged(object sender, EventArgs e)
//{
//    setEnableDisableConctrol();
//}
//private void rdoCrediteNote_CheckedChanged(object sender, EventArgs e)
//{
//    setEnableDisableConctrol();
//}
//private void rdoDebitNote_CheckedChanged(object sender, EventArgs e)
//{
//    setEnableDisableConctrol();
//}
//private void rdoCrediteNote_CheckedChanged_1(object sender, EventArgs e)
//{
//    setEnableDisableConctrol();
//}
//private void rdoDebitNote_CheckedChanged_1(object sender, EventArgs e)
//{
//    setEnableDisableConctrol();
//}
#endregion
#region Old Methord For Credit Note
/*
 
                if (false)
                {
                    if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_CreditNoteSummary)))
                    {
                        sFormula = " {vw_rpt_bpsCreditNote.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsCreditNote.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                        if (bCustomerSelected)
                            sFormula += " and {vw_rpt_bpsCreditNote.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "' ";

                        if (bSelesRepSelected)
                            sFormula += " and {vw_rpt_bpsCreditNote.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";

                        if (bCreditNoteTypeSelected)
                            sFormula += " and {vw_rpt_bpsCreditNote.creditNoteType_ID} = '" + txtCreditNoteType.Tag.ToString().Trim() + "'";

                        if (rdoDeleted.Checked)
                            sFormula += " and {vw_rpt_bpsCreditNote.isDeleted} = True";
                        if (rdoActual.Checked)
                            sFormula += " and {vw_rpt_bpsCreditNote.isDeleted} = False";

                        sFormula += " and {vw_rpt_bpsCreditNote.creditNoteType_ID} <> '" + clsAutocode.getCreditNoteTypeID(CreditNoteType.ReturnedChequeDeposit) + "'";
                        print("\\reports\\BSS\\Registry\\rpt_sas_Credit_Summary.rpt", " Credit Note Summary ", sFormula, sFilter);
                    }
                }*/

#endregion
#region Old Methords For Debit Note
/*
              #region Old Report(using Views)
                if (false)
                {
                    sFormula = " {vw_rpt_bpsDebitNote.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsDebitNote.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                    if (bCustomerSelected)
                        sFormula += " and {vw_rpt_bpsDebitNote.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "' ";

                    if (bSelesRepSelected)
                        sFormula += " and {vw_rpt_bpsDebitNote.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";

                    if (rdoDeleted.Checked)
                        sFormula += " and {vw_rpt_bpsDebitNote.isDeleted} = True";
                    if (rdoActual.Checked)
                        sFormula += " and {vw_rpt_bpsDebitNote.isDeleted} = False";

                }
                #endregion
 */
#endregion