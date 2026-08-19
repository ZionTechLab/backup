using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Digiteq_Logic;
using System.Data;
using CrystalDecisions.Shared;
using Digiteq.DataSets.ACC;
using DataTire;
using CrystalDecisions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Digiteq.DataSets.BSS;
using Digiteq.DataSets;
namespace Digiteq
{
    public partial class frm_rpt_AccountRegisterReport : MettroForm
    {
        #region Variables
        //form manage
        public int iFormID;
        int iReport;

        //for security handle
        public bool bNoAccess;

        //for Dataset 
        dts_DebitNote glb_dts_DebitNote = new dts_DebitNote();
        dts_Apn glb_dts_Apn = new dts_Apn();
        dts_accPaymentVoucher glb_dts_accPaymentVoucher = new dts_accPaymentVoucher();
        dts_Accounts glb_dts_accJournalVoucher = new dts_Accounts();

        dts_bssRegister glbdts_bssRegister = new dts_bssRegister();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();

        //Public Variable for PV summary and Detail
        List<tbl_accPaymentVoucher> oDetails;
        List<tbl_accJournalEntry> oJVDetails;

        private int ReportName;
        #endregion

        #region Form Load
        public frm_rpt_AccountRegisterReport()
        {
            iFormID = clsSecurity.getFormID(FormName.AccountRegisterReport);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frmReportChequeDeposit_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Account Register Reports", 2, iFormID);
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
                dgvReports.DataSource = DBHandling.ExecQuery("EXEC sp_Reports '" + 9 + "'").Tables[0];
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
                        iReport = int.Parse(dgvReports.Rows[iRow].Cells[0].Value.ToString());
                        enum_ReportName Report = (enum_ReportName)iReport;

                        if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(Report)))
                        {
                            string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                            if (clsHelpMethods.GetReportPath(clsAutocode.getReportID(Report), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                            {
                                string sFormula = "";
                                string sFilter = "";

                                #region Payment Voucher Summary && Payment Voucher Detail(Old and New)

                                #region View Old
                                //if (false)
                                //{
                                //    #region PaymentVoucher Summary && PaymentVoucher Detail using View
                                //    if (rdoPaymentVoucher.Checked)
                                //    {
                                //        sFormula = " {vw_rpt_accPaymentVocherOriNew.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_accPaymentVocherOriNew.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                //        if (rdoDeleted.Checked)
                                //            sFormula += " and {vw_rpt_accPaymentVocherOriNew.isDeleted} = True";
                                //        if (rdoActual.Checked)
                                //            sFormula += " and {vw_rpt_accPaymentVocherOriNew.isDeleted} = False";

                                //        print("\\Reports\\ACC\\Registry\\rpt_accPaymentVoucherRegister.rpt", " Payment Voucher Register (Summary) ", sFormula, sFilter);

                                //    }
                                //    if (rdoPaymentVoucherdetail.Checked)
                                //    {
                                //        sFormula = " {vw_rpt_accPaymentVocherOriNew.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_accPaymentVocherOriNew.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                //        if (rdoDeleted.Checked)
                                //            sFormula += " and {vw_rpt_accPaymentVocherOriNew.isDeleted} = True";
                                //        if (rdoActual.Checked)
                                //            sFormula += " and {vw_rpt_accPaymentVocherOriNew.isDeleted} = False";

                                //        print("\\Reports\\ACC\\Registry\\rpt_acc_PaymentVoucherRegistry_Detail.rpt", " Payment Voucher Register (Details) ", sFormula, sFilter);
                                //    }
                                //    #endregion
                                //}

                                // if (true)
                                //{
                                #endregion

                                #region PaymentVoucher Summary && PaymentVoucher Detail using Data Set

                                if (Report == enum_ReportName.RG_Payment_Voucher_Summary_Report || Report == enum_ReportName.RG_Payment_Voucher_Detail_Report)
                                {
                                    string sDateRange = "From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "  To : " + dtpTo.Value.ToString("dd MMM yyyy");

                                    try
                                    {
                                        glb_dts_accPaymentVoucher.Clear();
                                        Cursor = Cursors.WaitCursor;

                                        #region Initialize Fillter
                                        if (txtSupplier.Tag != null)
                                            sFilter = "Supplier Name :" + txtSupplier.Text.ToString();

                                        if (rdoDeleted.Checked)
                                        {
                                            if (sFilter.Length > 0)
                                                sFilter += " | " + "Deleted Records Only";
                                            else
                                                sFilter = "Deleted Records Only";
                                        }

                                        if (rdoActual.Checked)
                                        {
                                            if (sFilter.Length > 0)
                                                sFilter += " | " + "Active Record Only";
                                            else
                                                sFilter = "Active Records Only";
                                        }

                                        if (rdoAll.Checked)
                                        {
                                            if (sFilter.Length > 0)
                                                sFilter += " | " + "All Records";
                                            else
                                                sFilter = "All Records";
                                        }

                                        #endregion

                                        #region Fillter Table Data
                                        if (rdoDeleted.Checked)
                                            oDetails = tbl_accPaymentVoucher.SelectAll().Where(p => p.PaymentVoucher_ID != "default" && p.PaymentVoucherDate.Date >= dtpFrom.Value.Date && p.PaymentVoucherDate.Date <= dtpTo.Value.Date && p.IsDeleted == true).ToList();
                                        if (rdoActual.Checked)
                                            oDetails = tbl_accPaymentVoucher.SelectAll().Where(p => p.PaymentVoucher_ID != "default" && p.PaymentVoucherDate.Date >= dtpFrom.Value.Date && p.PaymentVoucherDate.Date <= dtpTo.Value.Date && p.IsDeleted == false).ToList();
                                        if (rdoAll.Checked)
                                            oDetails = tbl_accPaymentVoucher.SelectAll().Where(p => p.PaymentVoucher_ID != "default" && p.PaymentVoucherDate.Date >= dtpFrom.Value.Date && p.PaymentVoucherDate.Date <= dtpTo.Value.Date).ToList();
                                        #endregion

                                        if (oDetails != null)
                                        {
                                            #region Payment Voucher Summary
                                            foreach (tbl_accPaymentVoucher oDetail in oDetails)
                                            {
                                                #region Payment Voucher Summary

                                                #region Supplier Fillter
                                                if (txtSupplier.Tag != null)
                                                    if (txtSupplier.Tag.ToString() != oDetail.Supplier_ID)
                                                        continue;
                                                #endregion

                                                #region Set Crediter Name
                                                string sPayee = oDetail.Payee;
                                                if (sPayee == "")
                                                {
                                                    if (oDetail.Supplier_ID != "default")
                                                        sPayee = clsGenaralName.getName_Supplier(oDetail.Supplier_ID);
                                                    else if (oDetail.Customer_ID != "default")
                                                        sPayee = clsGenaralName.getName_Customer(oDetail.Customer_ID);
                                                    else
                                                        sPayee = "-";
                                                }

                                                //if (oDetail.Customer_ID != "default")
                                                //    sCreditorName = clsGenaralName.getName_Customer(oDetail.Customer_ID);
                                                //else if (oDetail.Supplier_ID != "default")
                                                //    sCreditorName = clsGenaralName.getName_Supplier(oDetail.Supplier_ID);
                                                //else if (oDetail.Employee_ID != "default")
                                                //    sCreditorName = clsGenaralName.getName_Employee(oDetail.Employee_ID);
                                                //else if (oDetail.BankAcc_No != "default")
                                                //    sCreditorName = clsGenaralName.getName_Bank(oDetail.BankAcc_No);
                                                //else if (oDetail.CostCenter1_ID != "default")
                                                //    sCreditorName = clsGenaralName.getName_AccCostCenter1(oDetail.CostCenter1_ID);
                                                //else if (oDetail.CostCenter1_ID != "default")
                                                //    sCreditorName = clsGenaralName.getName_AccCostCenter2(oDetail.CostCenter2_ID);
                                                #endregion

                                                #region Set Cheque Numbers
                                                string sChequeNo = "", sChequeRefNo = "";
                                                string sBankName = "", sBankAccNo = "";
                                                DateTime dtmDateCheque = new DateTime();
                                                decimal dChequeAmount = 0;// dCashAmount = 0;
                                                foreach (tbl_accChequeRegister oChequeReg in tbl_accChequeRegister.SelectAllByPaymentVoucher_ID(oDetail.PaymentVoucher_ID))
                                                {
                                                    tbl_genCompanyAccount oAcc = tbl_genCompanyAccount.Select(oChequeReg.CompanyAccount_ID);
                                                    if (oAcc != null)
                                                    {
                                                        //if (sChequeRefNo.Length > 0)
                                                        //    sChequeRefNo += "|" + oChequeReg.ChequeRegister_ID;
                                                        //else
                                                        sChequeRefNo = oChequeReg.ChequeRegister_ID;

                                                        //if (sBankName.Length > 0)
                                                        //    sBankName += "|" + clsGenaralName.getName_Bank(oChequeReg.Bank_ID);
                                                        //else
                                                        sBankName = clsGenaralName.getName_Bank(oAcc.Bank_ID);
                                                        sBankAccNo = oAcc.AccountNumber;

                                                        //if (sChequeNo.Length > 0)
                                                        //    sChequeNo += "|" + oChequeReg.ChequeNumber;
                                                        //else
                                                        sChequeNo = oChequeReg.ChequeNumber;

                                                        dtmDateCheque = oChequeReg.DateCheque;
                                                        dChequeAmount = oChequeReg.ChequeAmount;
                                                    }
                                                }
                                                #endregion

                                                tbl_accPaymentVoucher_ChequeAmount oCheque = tbl_accPaymentVoucher_ChequeAmount.SelectAllByPaymentVoucher_ID(oDetail.PaymentVoucher_ID).FirstOrDefault();
                                                if (oCheque != null)

                                                    glb_dts_accPaymentVoucher.dt_accPaymentVoucher.Adddt_accPaymentVoucherRow(oDetail.PaymentVoucher_ID, oDetail.PaymentVoucherDate, oDetail.Payee, "", "", "",
                                                        oDetail.TotalAmount, sPayee, "", "", clsGenaralName.getName_AccCostCenter1(oDetail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(oDetail.CostCenter2_ID),
                                                        oDetail.DateCreate, clsGenaralName.getName_Employee(oDetail.Employee_ID), sBankName, sBankAccNo,
                                                        sChequeRefNo, sChequeNo, dtmDateCheque, dChequeAmount, 0, oDetail.IsDeleted, oDetail.Narration, oDetail.Remark, false, "", "", "", "");
                                                #endregion

                                                #region Payment Voucher Detail
                                                if (Report == enum_ReportName.RG_Payment_Voucher_Detail_Report)
                                                {
                                                    foreach (tbl_accPaymentVoucher_SubTotal oPVSubTotal in tbl_accPaymentVoucher_SubTotal.SelectAllByPaymentVoucher_ID(oDetail.PaymentVoucher_ID).OrderBy(x => x.Line_No))
                                                    {
                                                        #region Default && Null Handall
                                                        string sEmployee = oPVSubTotal.Employee_ID == "default" ? "-" : clsGenaralName.getName_Employee(oPVSubTotal.Employee_ID);
                                                        string sGLName = oPVSubTotal.Gl_ID == "default" ? "-" : clsGenaralName.getName_AccountName(oPVSubTotal.Gl_ID);
                                                        string sCostCenter1Name_detail = oPVSubTotal.CostCenter1_ID == "default" ? "-" : clsGenaralName.getName_AccCostCenter1(oPVSubTotal.CostCenter1_ID);
                                                        string sCostCenter2Name_detail = oPVSubTotal.CostCenter2_ID == "default" ? "-" : clsGenaralName.getName_AccCostCenter2(oPVSubTotal.CostCenter2_ID);
                                                        #endregion

                                                        glb_dts_accPaymentVoucher.dt_accPaymentVoucherDetail.Adddt_accPaymentVoucherDetailRow(oPVSubTotal.PaymentVoucher_ID, oPVSubTotal.Gl_ID, sGLName, "", sEmployee, sCostCenter1Name_detail, sCostCenter2Name_detail, oPVSubTotal.Amount, oPVSubTotal.IsCredit, "");
                                                    }
                                                }
                                                #endregion
                                            }
                                            #endregion

                                            glb_dts_accPaymentVoucher.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, "Filters : " + sFilter);

                                            frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                            rpt.print(sReportPath, glb_dts_accPaymentVoucher, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        throw;
                                    }
                                    finally
                                    {
                                        glb_dts_accPaymentVoucher.Clear();
                                        Cursor = Cursors.Default;
                                        oDetails = null;
                                    }
                                }
                                #endregion

                                #endregion

                                #region Apn Report
                                if (Report == enum_ReportName.RG_Account_Payable_Note_Summary_Report || Report == enum_ReportName.RG_Account_Payable_Note_Detail_Report)
                                {
                                    #region APN New Method
                                    try
                                    {
                                        glb_dts_Apn.Clear();
                                        Cursor = Cursors.WaitCursor;
                                        List<tbl_accAccountPayableNote> oDetailes = null;
                                        sFilter = "";
                                        string sDateRange = "From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "  To : " + dtpTo.Value.ToString("dd MMM yyyy");

                                        #region Set Filter Type
                                        if (txtSupplier.Tag != null && txtSupplier.Tag.ToString().Length > 0)
                                        {
                                            if (sFilter.Length > 0)
                                                sFilter += " | ";

                                            if (txtSupplier.Tag != null && txtSupplier.Tag.ToString().Length > 0)
                                                sFilter += clsGenaralName.getName_Supplier(txtSupplier.Tag.ToString().Trim());
                                        }
                                        if (rdoDeleted.Checked)
                                        {
                                            if (sFilter.Length > 0)
                                                sFilter += " | ";

                                            sFilter += "Deleted Records";
                                        }
                                        if (rdoActual.Checked)
                                        {
                                            // if (sFilter.Length > 0)
                                            //   sFilter += " | ";

                                            // sFilter += "Active Records";
                                        }
                                        if (rdoAll.Checked)
                                        {
                                            if (sFilter.Length > 0)
                                                sFilter += " | ";
                                            sFilter += "All Records";
                                        }
                                        if (chkSupplierWiseReport.Checked)
                                        {
                                            if (sFilter.Length > 0)
                                                sFilter += " | ";
                                            sFilter += "Supplier Wise";
                                        }
                                        #endregion

                                        if (chkUseDateAsBillDate.Checked)
                                            oDetailes = tbl_accAccountPayableNote.SelectAll().Where(p => p.AccountPayableNote_ID != "default" && p.BillDate.Date >= dtpFrom.Value.Date && p.BillDate.Date <= dtpTo.Value.Date).ToList();
                                        else
                                            oDetailes = tbl_accAccountPayableNote.SelectAll().Where(p => p.AccountPayableNote_ID != "default" && p.AccountPayableNoteDate.Date >= dtpFrom.Value.Date && p.AccountPayableNoteDate.Date <= dtpTo.Value.Date).ToList();

                                        foreach (tbl_accAccountPayableNote oDetail in oDetailes)
                                        {
                                            #region Adjust Dates for both Report
                                            DateTime dtmBillDate_APNDate = new DateTime();

                                            if (Report == enum_ReportName.RG_Account_Payable_Note_Summary_Report)
                                            {
                                                #region Set Bill Date and APN Date
                                                if (chkUseDateAsBillDate.Checked)
                                                    dtmBillDate_APNDate = oDetail.BillDate;
                                                else
                                                    dtmBillDate_APNDate = oDetail.AccountPayableNoteDate;
                                                #endregion
                                            }
                                            else if (Report == enum_ReportName.RG_Account_Payable_Note_Detail_Report)
                                                dtmBillDate_APNDate = oDetail.AccountPayableNoteDate;
                                            #endregion

                                            #region Filltering Data
                                            if (txtSupplier.Tag != null && txtSupplier.Tag.ToString().Length > 0)
                                            {
                                                if (oDetail.Supplier_ID != txtSupplier.Tag.ToString())
                                                    continue;
                                            }

                                            if (rdoDeleted.Checked)
                                            {
                                                if (oDetail.IsDeleted == false)
                                                    continue;
                                            }

                                            if (rdoActual.Checked)
                                            {
                                                if (oDetail.IsDeleted == true)
                                                    continue;
                                            }
                                            #endregion

                                            #region Default Value Handle
                                            string sPoNo = oDetail.PurchaseOrder_ID != "default" ? oDetail.PurchaseOrder_ID : "-";
                                            #endregion

                                            //string sSupplierDetail = "";
                                            //if (chkSupplierWiseReport.Checked || rdoAPNDetail.Checked)
                                            //{
                                            //    sSupplierDetail = clsGenaralName.getName_Supplier(oDetail.Supplier_ID);
                                            //}

                                            glb_dts_Apn.dts_AccountPaybleNote.Adddts_AccountPaybleNoteRow(oDetail.AccountPayableNote_ID, dtmBillDate_APNDate, "", oDetail.Narration, "", oDetail.BillNo, oDetail.BillDate, sPoNo, oDetail.ExternalGoodReceivedNote_ID, oDetail.NoDeliveryOrder, oDetail.NoAWB, oDetail.NoLC, clsGenaralName.getName_Supplier(oDetail.Supplier_ID), 0, oDetail.NbtTotal, oDetail.VatTotal, oDetail.OtherTaxTotal, oDetail.SubTotal, oDetail.GrandTotal, 0, "", "", 0, 0, oDetail.BillNo, oDetail.CreditDays, oDetail.IsDeleted, "", "", 0, 0, 0, 0);

                                            #region APN Detail Report
                                            if (Report == enum_ReportName.RG_Account_Payable_Note_Detail_Report)
                                            {
                                                foreach (tbl_accAccountPayableNote_SubTotal oGL in tbl_accAccountPayableNote_SubTotal.SelectAllByAccountPayableNote_ID(oDetail.AccountPayableNote_ID))
                                                {
                                                    glb_dts_Apn.dts_AccountPaybleNoteDetail.Adddts_AccountPaybleNoteDetailRow(oDetail.AccountPayableNote_ID, oGL.Gl_ID, clsGenaralName.getName_AccountName(oGL.Gl_ID), clsGenaralName.getName_AccCostCenter1(oGL.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(oGL.CostCenter2_ID), "", oGL.IsCredit, oGL.Amount);
                                                }
                                            }
                                            #endregion
                                        }

                                        if (Report == enum_ReportName.RG_Account_Payable_Note_Detail_Report)
                                        {
                                            printDataSet(sReportPath, sReportTitle_Main, "", glb_dts_Apn, sFilter, clsAutocode.getReportID(Report));
                                        }
                                        else
                                        {
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DynamicalColoumn", chkUseDateAsBillDate.Checked ? "Bill Date" : "APN Date", true, false);
                                            //  glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("GroupPara", chkSupplierWiseReport.Checked ? "true" : "false", false);
                                            glb_dts_Apn.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, sFilter);

                                            frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                            //  rpt.Process_Print((int)sReportName);
                                            rpt.print(sReportPath, glb_dts_Apn, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                        }
                                    }
                                    catch (Exception)
                                    {

                                        throw;
                                    }
                                    finally
                                    {
                                        glb_dts_Apn.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                    #endregion

                                    #region OLD header Report
                                    // } 
                                    //  #endregion


                                    //#region View
                                    //else
                                    //{
                                    //    if (!chkUserDateAsApn.Checked)//false
                                    //    {

                                    //        if (txtSupplier.Tag != null)
                                    //            sFormula = " {vw_rpt_accAccountPayableNote.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_accAccountPayableNote.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "' " + " and {vw_rpt_accAccountPayableNote.supplier_ID} = '" + txtSupplier.Tag + "'";
                                    //        else
                                    //            sFormula = " {vw_rpt_accAccountPayableNote.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_accAccountPayableNote.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                    //        if (rdoDeleted.Checked)
                                    //            sFormula += " and {vw_rpt_accAccountPayableNote.isDeleted} = True";
                                    //        if (rdoActual.Checked)
                                    //            sFormula += " and {vw_rpt_accAccountPayableNote.isDeleted} = False";

                                    //        print("\\Reports\\ACC\\Registry\\rpt_accAccountPayableNoteRegister.rpt", " Account Payable Note Register (Summary) ", sFormula, sFilter);
                                    //    }
                                    //    else
                                    //    {
                                    //        if (txtSupplier.Tag != null)
                                    //            sFormula = " {vw_rpt_accAccountPayableNote.billDate1} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_accAccountPayableNote.billDate1} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "' " + " and {vw_rpt_accAccountPayableNote.supplier_ID} = '" + txtSupplier.Tag + "'";
                                    //        else
                                    //            sFormula = " {vw_rpt_accAccountPayableNote.billDate1} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_accAccountPayableNote.billDate1} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                    //        if (rdoDeleted.Checked)
                                    //            sFormula += " and {vw_rpt_accAccountPayableNote.isDeleted} = True";
                                    //        if (rdoActual.Checked)
                                    //            sFormula += " and {vw_rpt_accAccountPayableNote.isDeleted} = False";

                                    //        print("\\Reports\\ACC\\Registry\\rpt_accAccountPayableNoteRegister_AKT1.rpt", " Account Payable Note Register (Summary) ", sFormula, sFilter);
                                    //    }
                                    //}
                                    //#endregion 
                                    #endregion
                                }

                                #region Old APN Detail Report
                                //if (rdoAPNDetail.Checked)
                                //{
                                //    if (false)
                                //    {
                                //        #region Old Methord
                                //        if (chkUseDateAsBillDate.Checked)
                                //        {
                                //            #region Bill Date
                                //            if (txtSupplier.Tag != null)
                                //            {
                                //                sFormula = " {vw_rpt_accAccountPayableNote.billDate1} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_accAccountPayableNote.billDate1} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "' " + " and {vw_rpt_accAccountPayableNote.supplier_ID} = '" + txtSupplier.Tag + "'";
                                //                sFilter += clsGenaralName.getName_Supplier(txtSupplier.Tag.ToString().Trim()) + "|";
                                //            }
                                //            else
                                //                sFormula = " {vw_rpt_accAccountPayableNote.billDate1} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_accAccountPayableNote.billDate1} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                //            if (rdoDeleted.Checked)
                                //            {
                                //                sFormula += " and {vw_rpt_accAccountPayableNote.isDeleted} = True";
                                //                sFilter += "Deleted Records";
                                //            }
                                //            if (rdoActual.Checked)
                                //            {
                                //                sFormula += " and {vw_rpt_accAccountPayableNote.isDeleted} = False";
                                //                sFilter += "Active Records";
                                //            }

                                //            print("\\Reports\\ACC\\Registry\\rpt_accAccountPayableNoteRegister_Detail_AKT.rpt", " Account Payable Note Register (Details) ", sFormula, sFilter);
                                //            #endregion
                                //        }
                                //        else
                                //        {
                                //            #region Use APN Date
                                //            if (txtSupplier.Tag != null)
                                //            {
                                //                sFormula = " {vw_rpt_accAccountPayableNote.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_accAccountPayableNote.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "' " + " and {vw_rpt_accAccountPayableNote.supplier_ID} = '" + txtSupplier.Tag + "'";
                                //                sFilter += clsGenaralName.getName_Supplier(txtSupplier.Tag.ToString().Trim()) + "|";
                                //            }
                                //            else
                                //            {
                                //                sFormula = " {vw_rpt_accAccountPayableNote.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_accAccountPayableNote.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                                //            }


                                //            if (rdoDeleted.Checked)
                                //            {
                                //                sFormula += " and {vw_rpt_accAccountPayableNote.isDeleted} = True";
                                //                sFilter += "Deleted Records";
                                //            }
                                //            if (rdoActual.Checked)
                                //            {
                                //                sFormula += " and {vw_rpt_accAccountPayableNote.isDeleted} = False";
                                //                sFilter += "Active Records";
                                //            }

                                //            print("\\Reports\\ACC\\Registry\\rpt_accAccountPayableNoteRegister_Detail.rpt", " Account Payable Note Register (Details) ", sFormula, sFilter);
                                //            #endregion
                                //        }
                                //        #endregion
                                //    }
                                //    if (false)
                                //    {
                                //        #region Data Set

                                //        List<tbl_accAccountPayableNote> oDetailes = null;

                                //        #region Variables
                                //        string sApnNo = "", sAWB = "", sCostSenter1 = "", sCostCenter2 = "", sCreditor = "", sNarration = "", sBillNO = "",
                                //                    sGrnNo = "", sPONo = "", sDoNO = "", sLCNo = "", sGLID = "", sGLName = "", sEmployeeName = "";
                                //        decimal dAmount = 0, dCreditsDayes = 0;
                                //        bool bIsCredit = false;

                                //        DateTime dtmApnDate = new DateTime();
                                //        DateTime dtmBillDate = new DateTime();

                                //        #endregion

                                //        #region Initialize Fillters
                                //        sFilter = "";
                                //        if (txtSupplier.Tag != null)
                                //        {
                                //            if (sFilter.Length > 0)
                                //                sFilter += "|";
                                //            sFilter = clsGenaralName.getName_Supplier(txtSupplier.Tag.ToString());
                                //        }
                                //        if (rdoActual.Checked)
                                //        {
                                //            if (sFilter.Length > 0)
                                //                sFilter += "|";
                                //            sFilter = "Active Records";
                                //        }
                                //        if (rdoDeleted.Checked)
                                //        {
                                //            if (sFilter.Length > 0)
                                //                sFilter += "|";
                                //            sFilter = "Deleted Records";
                                //        }
                                //        #endregion

                                //        try
                                //        {
                                //            Cursor = Cursors.WaitCursor;
                                //            glb_dts_Apn.Clear();

                                //            if (chkUseDateAsBillDate.Checked)
                                //                oDetailes = tbl_accAccountPayableNote.SelectAll().Where(p => p.AccountPayableNote_ID != "default" && p.BillDate.Date >= dtpFrom.Value.Date && p.BillDate <= dtpTo.Value.Date).ToList();
                                //            else
                                //                oDetailes = tbl_accAccountPayableNote.SelectAll().Where(p => p.AccountPayableNote_ID != "default" && p.AccountPayableNoteDate.Date >= dtpFrom.Value.Date && p.AccountPayableNoteDate <= dtpTo.Value.Date).ToList();

                                //            foreach (tbl_accAccountPayableNote oDetail in oDetailes)
                                //            {
                                //                #region Fillter
                                //                if (txtSupplier.Tag != null)
                                //                {
                                //                    if (txtSupplier.Tag.ToString().Trim() != oDetail.Supplier_ID)
                                //                        continue;
                                //                }
                                //                if (rdoDeleted.Checked)
                                //                {
                                //                    if (!oDetail.IsDeleted)
                                //                        continue;
                                //                }
                                //                if (rdoActual.Checked)
                                //                {
                                //                    if (oDetail.IsDeleted)
                                //                        continue;
                                //                }
                                //                #endregion

                                //                if (oDetail != null && oDetail.AccountPayableNote_ID != "default")
                                //                {
                                //                    #region Set Header Detail

                                //                    sApnNo = oDetail.AccountPayableNote_ID;
                                //                    dtmApnDate = oDetail.AccountPayableNoteDate.Date;
                                //                    sAWB = oDetail.NoAWB != "default" ? oDetail.NoAWB : "";
                                //                    // sCostSenter1 = clsGenaralName.getName_AccCostCenter1(oDetail.CostCenter1_ID);
                                //                    sCreditor = clsGenaralName.getName_Supplier(oDetail.Supplier_ID);
                                //                    //  sCostCenter2 = clsGenaralName.getName_AccCostCenter2(oDetail.CostCenter2_ID);
                                //                    sNarration = oDetail.Narration != "default" ? oDetail.Narration : "";
                                //                    sBillNO = oDetail.BillNo != "default" ? oDetail.BillNo : "";
                                //                    dtmBillDate = oDetail.BillDate.Date;
                                //                    sGrnNo = oDetail.ExternalGoodReceivedNote_ID;
                                //                    //dAmount =
                                //                    sPONo = oDetail.PurchaseOrder_ID;
                                //                    sDoNO = oDetail.NoDeliveryOrder;
                                //                    sLCNo = oDetail.NoLC;
                                //                    dCreditsDayes = oDetail.CreditDays;

                                //                    glb_dts_Apn.dts_AccountPaybleNote.Adddts_AccountPaybleNoteRow(sApnNo, dtmApnDate, "", sNarration, "", sBillNO, dtmBillDate, sPONo, sGrnNo, sDoNO, sAWB, sLCNo, sCreditor, 0, 0, 0, 0, 0, 0, 0, sGLID, sGLName, 0, 0, "", dCreditsDayes);

                                //                    #endregion

                                //                    #region Set Detail Data

                                //                    foreach (tbl_accAccountPayableNote_SubTotal oGL in tbl_accAccountPayableNote_SubTotal.SelectAllByAccountPayableNote_ID(oDetail.AccountPayableNote_ID).Where(p => p.AccountPayableNote_ID != "default"))
                                //                    {
                                //                        sGLID = oGL.Gl_ID;
                                //                        sGLName = clsGenaralName.getName_AccountName(sGLID);
                                //                        sCostSenter1 = clsGenaralName.getName_AccCostCenter1(oGL.CostCenter1_ID);
                                //                        sCostCenter2 = clsGenaralName.getName_AccCostCenter2(oGL.CostCenter2_ID);
                                //                        sEmployeeName = clsGenaralName.getName_Employee(oGL.Employee_ID);
                                //                        bIsCredit = oGL.IsCredit;
                                //                        dAmount = oGL.Amount;

                                //                        glb_dts_Apn.dts_AccountPaybleNoteDetail.Adddts_AccountPaybleNoteDetailRow(sGLID, sGLName, sCostSenter1, sCostCenter2, sEmployeeName, bIsCredit, dAmount);
                                //                    }

                                //                    #endregion
                                //                }


                                //            }

                                //            string sPath = "\\Reports\\ACC\\Registry\\rpt_accAccountPayableNoteRegister_Detail_AKT_Dataset.rpt";
                                //            printDataSet(sPath, "Account Payable Note Register (Details)", "", glb_dts_Apn, sFilter);
                                //        }
                                //        catch (Exception ex)
                                //        {

                                //        }
                                //        finally
                                //        {
                                //            Cursor = Cursors.Default;
                                //            glb_dts_Apn.Clear();
                                //        }
                                //        #endregion
                                //    }
                                //} 
                                #endregion

                                #endregion

                                #region Journal Entry Summary && Journal Entry Detail using Data Set
                                if (Report == enum_ReportName.RG_JournalVoucher_Summary_Report || Report == enum_ReportName.RG_JournalVoucher_Detail_Report)
                                {
                                    string sDateRange = "From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "  To : " + dtpTo.Value.ToString("dd MMM yyyy");

                                    try
                                    {
                                        #region Selected JV type
                                        string sJVType = "";
                                        switch (cmbJVTypes.SelectedIndex)
                                        {
                                            case 1:
                                                {
                                                    sJVType = "CON/415";
                                                    sReportTitle_Main += " (Standard)";
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    sJVType = "CON/017";
                                                    sReportTitle_Main += " (BE)";
                                                    break;
                                                }
                                            case 3:
                                                {
                                                    sJVType = "CON/631";
                                                    sReportTitle_Main += " (Debtor)";
                                                    break;
                                                }
                                            case 4:
                                                {
                                                    sJVType = "CON/630";
                                                    sReportTitle_Main += " (Creditor)";
                                                    break;
                                                }
                                            case 5:
                                                {
                                                    sJVType = "CON/637";
                                                    sReportTitle_Main += " (Advance)";
                                                    break;
                                                }
                                        }
                                        #endregion

                                        glb_dts_accJournalVoucher.Clear();
                                        Cursor = Cursors.WaitCursor;

                                        #region Initialize Fillter
                                        if (rdoDeleted.Checked)
                                        {
                                            if (sFilter.Length > 0)
                                                sFilter += " | " + "Deleted Records Only";
                                            else
                                                sFilter = "Deleted Records Only";
                                        }
                                        if (rdoActual.Checked)
                                        {
                                            if (sFilter.Length > 0)
                                                sFilter += " | " + "Active Record Only";
                                            else
                                                sFilter = "Active Records Only";
                                        }
                                        if (rdoAll.Checked)
                                        {
                                            if (sFilter.Length > 0)
                                                sFilter += " | " + "All Records";
                                            else
                                                sFilter = "All Records";
                                        }
                                        #endregion

                                        #region Fillter Table Data
                                        if (cmbJVTypes.SelectedIndex == 0)
                                        {
                                            if (rdoDeleted.Checked)
                                                oJVDetails = tbl_accJournalEntry.SelectAll().Where(p => p.JournalEntry_ID != "default" && p.JournalEntryDate.Date >= dtpFrom.Value.Date && p.JournalEntryDate.Date <= dtpTo.Value.Date && p.IsDeleted == true).ToList();
                                            if (rdoActual.Checked)
                                                oJVDetails = tbl_accJournalEntry.SelectAll().Where(p => p.JournalEntry_ID != "default" && p.JournalEntryDate.Date >= dtpFrom.Value.Date && p.JournalEntryDate.Date <= dtpTo.Value.Date && p.IsDeleted == false).ToList();
                                            if (rdoAll.Checked)
                                                oJVDetails = tbl_accJournalEntry.SelectAll().Where(p => p.JournalEntry_ID != "default" && p.JournalEntryDate.Date >= dtpFrom.Value.Date && p.JournalEntryDate.Date <= dtpTo.Value.Date).ToList();
                                        }

                                        else
                                        {
                                            if (rdoDeleted.Checked)
                                                oJVDetails = tbl_accJournalEntry.SelectAll().Where(p => p.JournalEntry_ID != "default" && p.JournalEntryType_ID == sJVType && p.JournalEntryDate.Date >= dtpFrom.Value.Date && p.JournalEntryDate.Date <= dtpTo.Value.Date && p.IsDeleted == true).ToList();
                                            if (rdoActual.Checked)
                                                oJVDetails = tbl_accJournalEntry.SelectAll().Where(p => p.JournalEntry_ID != "default" && p.JournalEntryType_ID == sJVType && p.JournalEntryDate.Date >= dtpFrom.Value.Date && p.JournalEntryDate.Date <= dtpTo.Value.Date && p.IsDeleted == false).ToList();
                                            if (rdoAll.Checked)
                                                oJVDetails = tbl_accJournalEntry.SelectAll().Where(p => p.JournalEntry_ID != "default" && p.JournalEntryType_ID == sJVType && p.JournalEntryDate.Date >= dtpFrom.Value.Date && p.JournalEntryDate.Date <= dtpTo.Value.Date).ToList();
                                        }
                                        #endregion

                                        if (oJVDetails != null)
                                        {
                                            #region Journal Voucher Summary
                                            foreach (tbl_accJournalEntry oDetail in oJVDetails)
                                            {
                                                #region Journal Voucher Summary                             
                                                glb_dts_accJournalVoucher.dt_acc_AccountJurnalVoucher.Adddt_acc_AccountJurnalVoucherRow(oDetail.JournalEntry_ID, oDetail.JournalEntryDate, oDetail.JournalEntryType_ID, oDetail.Narration, oDetail.Remark, oDetail.GrandTotal, oDetail.IsDeleted);
                                                #endregion

                                                #region Journal Voucher Detail
                                                if (Report == enum_ReportName.RG_JournalVoucher_Detail_Report)
                                                {
                                                    foreach (tbl_accJournalEntry_Detail oJVDetails1 in tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(oDetail.JournalEntry_ID).OrderBy(x => x.Line_No))
                                                    {
                                                        #region Default && Null Handall
                                                        string sEmployee = oJVDetails1.Employee_ID == "default" ? "-" : clsGenaralName.getName_Employee(oJVDetails1.Employee_ID);
                                                        string sGLName = oJVDetails1.Gl_ID == "default" ? "-" : clsGenaralName.getName_AccountName(oJVDetails1.Gl_ID);
                                                        string sCostCenter1Name_detail = oJVDetails1.CostCenter1_ID == "default" ? "-" : clsGenaralName.getName_AccCostCenter1(oJVDetails1.CostCenter1_ID);
                                                        string sCostCenter2Name_detail = oJVDetails1.CostCenter2_ID == "default" ? "-" : clsGenaralName.getName_AccCostCenter2(oJVDetails1.CostCenter2_ID);
                                                        #endregion

                                                        glb_dts_accJournalVoucher.dt_acc_AccountJournalVoucher_Detail.Adddt_acc_AccountJournalVoucher_DetailRow(oJVDetails1.JournalEntry_ID, oJVDetails1.Gl_ID, sGLName, oJVDetails1.Customer_ID, clsGenaralName.getName_Customer(oJVDetails1.Customer_ID),
                                                            oJVDetails1.Supplier_ID, clsGenaralName.getName_Supplier(oJVDetails1.Supplier_ID), clsGenaralName.getName_AccCostCenter1(oJVDetails1.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(oJVDetails1.CostCenter2_ID), oJVDetails1.IsCredit, oJVDetails1.Amount, oJVDetails1.Remarks);
                                                    }
                                                }
                                                #endregion
                                            }
                                            #endregion

                                            glb_dts_accJournalVoucher.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, "Filters : " + sFilter);

                                            frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                            rpt.print(sReportPath, glb_dts_accJournalVoucher, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        throw;
                                    }
                                    finally
                                    {
                                        glb_dts_accJournalVoucher.Clear();
                                        Cursor = Cursors.Default;
                                        oJVDetails = null;
                                    }
                                }
                                #endregion

                                #region Journal Voucher
                                //if (rdoJournalVoucher.Checked)
                                //{
                                //    sFormula = " {vw_rpt_accJournalVoucher.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_accJournalVoucher.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                //    //sFormula += " and {vw_rpt_accJournalVoucher.journalEntryType_ID} = 'CON/409'";
                                //    sFormula += " and {vw_rpt_accJournalVoucher.journalEntryType_ID} <> 'CON/017' and {vw_rpt_accJournalVoucher.journalEntryType_ID} <> 'CON/415'";

                                //    if (rdoDeleted.Checked)
                                //    {
                                //        sFormula += " and {vw_rpt_accJournalVoucher.isDeleted} = True";
                                //        if (sFilter != "" && sFilter.Length > 0)
                                //            sFilter += "/ Deleted Recordes";
                                //        else
                                //            sFilter = "Deleted Recordes";
                                //    }
                                //    else if (rdoActual.Checked)
                                //    {
                                //        sFormula += " and {vw_rpt_accJournalVoucher.isDeleted} = False";
                                //        /* if (sFilter != "" && sFilter.Length > 0)
                                //             sFilter += "/Actual Recordes";
                                //         else
                                //             sFilter = "Actual Recordes";*/
                                //    }
                                //    else if (rdoAll.Checked)
                                //    {
                                //        if (sFilter != "" && sFilter.Length > 0)
                                //            sFilter += "/ All records";
                                //        else
                                //            sFilter = "All records";
                                //    }

                                //    print("\\Reports\\ACC\\Registry\\rpt_acc_JournalVoucherSummary.rpt", " Journal Report -Summary (JE) ", sFormula, sFilter);
                                //} 
                                #endregion

                                #region Journal Voucher Details
                                //if (rdoJournalVoucherDetail.Checked)
                                //{
                                //    sFormula = " {vw_rpt_accJournalVoucher_Detail.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_accJournalVoucher_Detail.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                //    //sFormula += " and {vw_rpt_accJournalVoucher_Detail.journalEntryType_ID} = 'CON/409'";
                                //    sFormula += " and {vw_rpt_accJournalVoucher_Detail.journalEntryType_ID} <> 'CON/017' and {vw_rpt_accJournalVoucher_Detail.journalEntryType_ID} <> 'CON/415'";

                                //    if (rdoDeleted.Checked)
                                //    {
                                //        sFormula += " and {vw_rpt_accJournalVoucher_Detail.isDeleted} = True";
                                //        if (sFilter != "" && sFilter.Length > 0)
                                //            sFilter += "/ Deleted Recordes";
                                //        else
                                //            sFilter = "Deleted Recordes";
                                //    }
                                //    else if (rdoActual.Checked)
                                //    {
                                //        sFormula += " and {vw_rpt_accJournalVoucher_Detail.isDeleted} = False";
                                //        //sFilter = "Active Records Only";
                                //    }
                                //    else if (rdoAll.Checked)
                                //    {
                                //        if (sFilter != "" && sFilter.Length > 0)
                                //            sFilter += "/ All records";
                                //        else
                                //            sFilter = "All records";
                                //    }

                                //    print("\\Reports\\ACC\\Registry\\rpt_acc_JournalVoucherRegistry_Detail.rpt", "  Journal Report -Detailed (JE) ", sFormula, sFilter);
                                //} 
                                #endregion

                                #region Standard Journal
                                //if (rdoStandardJournal.Checked)
                                //{
                                //    sFormula = " {vw_rpt_accJournalVoucher.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_accJournalVoucher.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                //    sFormula += " and {vw_rpt_accJournalVoucher.journalEntryType_ID} = 'CON/415'";

                                //    if (rdoDeleted.Checked)
                                //        sFormula += " and {vw_rpt_accJournalVoucher.isDeleted} = True";
                                //    if (rdoActual.Checked)
                                //        sFormula += " and {vw_rpt_accJournalVoucher.isDeleted} = False";

                                //    print("\\Reports\\ACC\\Registry\\rpt_acc_JournalVoucherSummary.rpt", " Standard Journal Entries Register (Summary) ", sFormula, sFilter);
                                //} 
                                #endregion

                                #region Standard Journal E Details
                                //if (rdoSJEDetail.Checked)
                                //{
                                //    sFormula = " {vw_rpt_accJournalVoucher_Detail.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_accJournalVoucher_Detail.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                //    sFormula += " and {vw_rpt_accJournalVoucher_Detail.journalEntryType_ID} = 'CON/415'";

                                //    if (rdoDeleted.Checked)
                                //        sFormula += " and {vw_rpt_accJournalVoucher_Detail.isDeleted} = True";
                                //    if (rdoActual.Checked)
                                //        sFormula += " and {vw_rpt_accJournalVoucher_Detail.isDeleted} = False";

                                //    print("\\Reports\\ACC\\Registry\\rpt_acc_JournalVoucherRegistry_Detail.rpt", " Standard Journal Entries Register (Details) ", sFormula, sFilter);
                                //} 
                                #endregion

                                #region Bank Adjustment Summary
                                //if (rdoBankAdjustmentSummary.Checked)
                                //{
                                //    sFormula = " {vw_rpt_accJournalVoucher.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_accJournalVoucher.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                //    sFormula += " and {vw_rpt_accJournalVoucher.journalEntryType_ID} = 'CON/017'";

                                //    if (rdoDeleted.Checked)
                                //    {
                                //        sFormula += " and {vw_rpt_accJournalVoucher.isDeleted} = True";
                                //        if (sFilter != "" && sFilter.Length > 0)
                                //            sFilter += "/ Deleted Recordes";
                                //        else
                                //            sFilter = "Deleted Recordes";
                                //    }
                                //    else if (rdoActual.Checked)
                                //    {
                                //        sFormula += " and {vw_rpt_accJournalVoucher.isDeleted} = False";
                                //    }
                                //    else if (rdoAll.Checked)
                                //    {
                                //        if (sFilter != "" && sFilter.Length > 0)
                                //            sFilter += "/ All records";
                                //        else
                                //            sFilter = "All records";
                                //    }

                                //    print("\\Reports\\ACC\\Registry\\rpt_acc_JournalVoucherSummary.rpt", " Journal Report -Summary (BE) ", sFormula, sFilter);
                                //} 
                                #endregion

                                #region Bank Adjustment Details
                                //if (rdoBankAdjustmentDetail.Checked)
                                //{
                                //    sFormula = " {vw_rpt_accJournalVoucher_Detail.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_accJournalVoucher_Detail.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                //    sFormula += " and {vw_rpt_accJournalVoucher_Detail.journalEntryType_ID} = 'CON/017'";

                                //    if (rdoDeleted.Checked)
                                //    {
                                //        sFormula += " and {vw_rpt_accJournalVoucher_Detail.isDeleted} = True";
                                //        if (sFilter != "" && sFilter.Length > 0)
                                //            sFilter += "/ Deleted Recordes";
                                //        else
                                //            sFilter = "Deleted Recordes";
                                //    }
                                //    else if (rdoActual.Checked)
                                //    {
                                //        sFormula += " and {vw_rpt_accJournalVoucher_Detail.isDeleted} = False";

                                //    }
                                //    else if (rdoAll.Checked)
                                //    {
                                //        if (sFilter != "" && sFilter.Length > 0)
                                //            sFilter += "/ All records";
                                //        else
                                //            sFilter = "All records";
                                //    }

                                //    print("\\Reports\\ACC\\Registry\\rpt_acc_JournalVoucherRegistry_Detail.rpt", " Journal Report -Detailed (BE) ", sFormula, sFilter);
                                //} 
                                #endregion

                                #region Account Receipt Summary
                                if (Report == enum_ReportName.RG_AccountReceipt_Summary_Report)
                                {
                                    sFormula = " {vw_rpt_accAccountReceipt.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_accAccountReceipt.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                    if (rdoDeleted.Checked)
                                        sFormula += " and {vw_rpt_accAccountReceipt.isDeleted} = True";
                                    if (rdoActual.Checked)
                                        sFormula += " and {vw_rpt_accAccountReceipt.isDeleted} = False";

                                    print(sReportPath, sReportTitle_Main, sFormula, sFilter);
                                }
                                #endregion

                                #region Account Receipt Details
                                if (Report == enum_ReportName.RG_AccountReceipt_Detail_Report)
                                {
                                    sFormula = " {vw_rpt_accAccountReceipt__Detail.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_accAccountReceipt__Detail.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                    if (rdoDeleted.Checked)
                                        sFormula += " and {vw_rpt_accAccountReceipt__Detail.isDeleted} = True";
                                    if (rdoActual.Checked)
                                        sFormula += " and {vw_rpt_accAccountReceipt__Detail.isDeleted} = False";

                                    print(sReportPath, sReportTitle_Main, sFormula, sFilter);
                                }
                                #endregion

                                #region Debit Note Summary and Details
                                if (Report == enum_ReportName.RG_Debit_Note_Summery_Report_Supplier)
                                {
                                    Genarate_Debitnote(true, sReportPath, sReportTitle_Main, "", clsAutocode.getReportID(Report));
                                }

                                if (Report == enum_ReportName.RG_Debit_Note_Detail_Report_Supplier)
                                {
                                    Genarate_Debitnote(true, sReportPath, sReportTitle_Main, "", clsAutocode.getReportID(Report));
                                }

                                #endregion

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        SEACCException.Show(ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }
            }
        }

        #region Debit Note
        private void Genarate_Debitnote(bool isDetail, string sReportPath, string sReportTittle1, string sReportTittle2, string sReportID)
        {
            try
            {
                string sFilter = "";
                #region Initialize Fillter
                if (txtSupplier.Tag != null)
                    sFilter = "Supplier Name :" + txtSupplier.Text.ToString();

                if (rdoDeleted.Checked)
                {
                    if (sFilter.Length > 0)
                        sFilter += " | " + "Deleted Records Only";
                    else
                        sFilter = "Deleted Records Only";
                }

                if (rdoActual.Checked)
                {
                    if (sFilter.Length > 0)
                        sFilter += " | " + "Active Record Only";
                    else
                        sFilter = "Active Records Only";
                }

                if (rdoAll.Checked)
                {
                    if (sFilter.Length > 0)
                        sFilter += " | " + "All Records";
                    else
                        sFilter = "All Records";
                }

                #endregion

                Cursor = Cursors.WaitCursor;
                glb_dts_DebitNote.Clear();
                glb_dts_DebitNote.dt_acc_DebitNote.Clear();
                glb_dts_DebitNote.dt_acc_DebitNote_Detail.Clear();


                foreach (tbl_accDebitNote oDebit in tbl_accDebitNote.SelectAll())
                {
                    if (oDebit != null && oDebit.DebitNote_ID != "default" && oDebit.DebitNote_Date.Date >= dtpFrom.Value.Date && oDebit.DebitNote_Date.Date <= dtpTo.Value.Date)
                    {
                        #region filters
                        if (txtSupplier.Tag != null && txtSupplier.Tag.ToString().Length > 0 && oDebit.Supplier_ID.Trim() != txtSupplier.Tag.ToString().Trim())
                            continue;
                        else
                        {
                            if (rdoDeleted.Checked && !oDebit.IsDeleted)
                                continue;
                            if (rdoActual.Checked && oDebit.IsDeleted)
                                continue;
                        }
                        #endregion

                        glb_dts_DebitNote.dt_acc_DebitNote.Adddt_acc_DebitNoteRow(oDebit.DebitNote_ID, oDebit.DebitNote_Date, clsGenaralName.getName_Supplier(oDebit.Supplier_ID), clsGenaralName.getSupplierAddressRegister(oDebit.Supplier_ID), oDebit.Remarks,
                            oDebit.DiscountPercentage, oDebit.NbtPercentage, oDebit.SubTotal, oDebit.VatPercentage, oDebit.DiscountTotal, oDebit.NbtTotal, oDebit.VatTotal, oDebit.GrandTotal, oDebit.Currency_ID, oDebit.CurrencyRate, oDebit.Invoice_ID, "", DateTime.MinValue, "", 0, "", "", DateTime.MinValue, 0, oDebit.IsDeleted);

                        if (isDetail)
                        {
                            foreach (tbl_accPaymentVoucher_Detail detail in tbl_accPaymentVoucher_Detail.SelectAllByDebitNote_ID(oDebit.DebitNote_ID))
                            {
                                DateTime dtAPNDate;
                                if (detail.AccountPayableNote_ID != "default")
                                {
                                    tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(detail.AccountPayableNote_ID);
                                    if (oAPN != null)
                                        dtAPNDate = oAPN.AccountPayableNoteDate;
                                    else
                                        dtAPNDate = DateTime.MinValue;
                                    glb_dts_DebitNote.dt_acc_DebitNote_Detail.Adddt_acc_DebitNote_DetailRow(detail.DebitNote_ID, detail.AccountPayableNote_ID, dtAPNDate, detail.SettleAmount, false);

                                }
                                //else if (detail.PurchaseReturnedNote_ID != "default")
                                //{
                                //    tbl_scsPurchaseReturnedNote oPRN = tbl_scsPurchaseReturnedNote.Select(detail.PurchaseReturnedNote_ID);
                                //    if (oPRN != null)
                                //        dtAPNDate = oPRN.PurchaseReturnedNoteDate;
                                //    else
                                //        dtAPNDate = DateTime.MinValue;
                                //    glb_dts_DebitNote.dt_acc_DebitNote_Detail.Adddt_acc_DebitNote_DetailRow(detail.DebitNote_ID, detail.PurchaseReturnedNote_ID, dtAPNDate, detail.SettledAmount);
                                //}
                            }

                            foreach (tbl_accDebitNote_SubTotal oPVSubTotal in tbl_accDebitNote_SubTotal.SelectAllByDebitNote_ID(oDebit.DebitNote_ID).OrderBy(x => x.Line_No))
                            {
                                #region Default && Null Handall
                                string sSupplier = oPVSubTotal.Supplier_ID == "default" ? "-" : clsGenaralName.getName_Supplier(oPVSubTotal.Supplier_ID);
                                string sGLName = oPVSubTotal.Gl_ID == "default" ? "-" : clsGenaralName.getName_AccountName(oPVSubTotal.Gl_ID);
                                string sCostCenter1Name_detail = oPVSubTotal.CostCenter1_ID == "default" ? "-" : clsGenaralName.getName_AccCostCenter1(oPVSubTotal.CostCenter1_ID);
                                string sCostCenter2Name_detail = oPVSubTotal.CostCenter2_ID == "default" ? "-" : clsGenaralName.getName_AccCostCenter2(oPVSubTotal.CostCenter2_ID);
                                #endregion

                                glb_dts_DebitNote.dt_acc_DoubleEntry.Adddt_acc_DoubleEntryRow(oPVSubTotal.DebitNote_ID, oPVSubTotal.Gl_ID, sGLName, sSupplier, sCostCenter1Name_detail, sCostCenter2Name_detail, oPVSubTotal.Amount, oPVSubTotal.IsCredi, "");
                            }
                        }
                    }
                }
                //if (txtSupplier.Tag != null)
                //    sFilter = txtSupplier.Text;

                string sDateRange = "From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy");
                glb_dts_DebitNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTittle1, sReportTittle2, sDateRange, clsSecurity.UserNameLoged, sFilter);
                printDataSet(sReportPath, sReportTittle1, sReportTittle2, glb_dts_DebitNote, sFilter, sReportID);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
                glb_dts_DebitNote.Clear();
            }
        }
        #endregion

        #endregion

        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearField();
            //rdoChequeToBeDeposited.Checked = false;
        }
        #endregion

        #region ClearField
        private void clearField()
        {
            txtSupplier.Text = "<<ALL Supplier>>";
            txtCustomer.Text = "<<ALL Customer>>";
            txtBank.Text = "<<ALL Bank>>";

            txtSupplier.Tag = null;
            txtCustomer.Tag = null;
            txtBank.Tag = null;

            cmbJVTypes.SelectedIndex = 0;

            clsCommon.SetVisibility_Panel(pnlSupplier, false);
            clsCommon.SetVisibility_Panel(pnlJETypes, false);
            clsCommon.SetVisibility_Panel(pnlBillDate, false);
            clsCommon.SetVisibility_Panel(pnlSupplierWiseReport, false);
            clsCommon.SetVisibility_Panel(pnlDate, true);
            clsCommon.SetVisibility_Panel(pnlAllRecords, true);

            //if (!rdoAPN.Checked || !rdoAPNDetail.Checked)
            //    chkUseDateAsBillDate.Checked = false;
            //if (rdoJournalVoucher.Checked || rdoJournalVoucherDetail.Checked || rdoBankAdjustmentSummary.Checked || rdoBankAdjustmentDetail.Checked)
            //    rdoActual.Checked = true;

        }
        #endregion

        #region Print Method
        private void print(string path, string sReportTitle, string sFormula, string sFilter)
        {
            try
            {
                //string sFilter = "";
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
                RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                RD.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                //ReportType
                if (iReport == (int)enum_ReportName.St_DelevaryTrackingReport)
                    RD.DataDefinition.FormulaFields["ReportType"].Text = clsCommon.fncsetstring("JV No");
                //else if(rdoBankAdjustmentDetail.Checked)
                //    RD.DataDefinition.FormulaFields["ReportType"].Text = clsCommon.fncsetstring("BE No");




                if (sFilter.Length > 0)
                    RD.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sFilter);



                if (txtSupplier.Tag != null && txtSupplier.Tag.ToString().Length > 0)
                    sFilter += "Supplier Name : " + txtSupplier.Text.Trim();
                //if (txtSalesNoteType.Tag != null && txtSalesNoteType.Tag.ToString().Length > 0)
                //    sFilter += "Note Type : " + txtSalesNoteType.Text.Trim();
                //sFormula = "{vw_rpt_bpsChequeRegister.pd_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00")+ 
                //    dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsChequeRegister.pd_Date} <= '" + dtpTo.Value.Year.ToString() + 
                //    dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";


                viewer.Process_Print(ReportName);
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

        private void printDataSet(string path, string sReportTitle, string sReportTitle2, DataSet ojbDataSet, string sFilter, string sReportID)
        {
            try
            {
                if (iReport == (int)enum_ReportName.RG_Account_Payable_Note_Summary_Report)
                {
                    if (chkUseDateAsBillDate.Checked)
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DynamicalColoumn", clsCommon.fncsetstring("Bill Date"), true, false);
                    else
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DynamicalColoumn", clsCommon.fncsetstring("APN Date"), true, false);
                }

                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle", sReportTitle, true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle2", sReportTitle2, true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", clsSecurity.CompanyName, true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", clsSecurity.CompanyAddress1, true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", clsSecurity.CompanyAddress2, true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqName", clsSecurity.DigiteqName, true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Filter", sFilter, true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqEmail", clsCommon.getCompanyEmail(), true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DateRange", "From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"), true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("UserName", clsSecurity.UserNameLoged, true, false);

                frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
                ReportViewer.print(path, ojbDataSet, glb_dtsReportExport.dt_rptParameter, sReportID);
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

        //private void printDataSet(string path, string sReportTitle, string sReportTitle2, DataSet ojbDataSet, string sFilter)
        //{
        //    try
        //    {
        //        Cursor = Cursors.WaitCursor;
        //        string s_Path = "";// sHeaderTitle = "Standed Reports", sReportFilter = "";
        //        ReportDocument objRpt = new ReportDocument();

        //        s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
        //        s_Path += path;

        //        objRpt.Load(s_Path);
        //        objRpt.SetDataSource(ojbDataSet); //(glbDtsBills);

        //        if (rdoAPN.Checked)
        //        {
        //            if (chkUseDateAsBillDate.Checked)
        //                objRpt.DataDefinition.FormulaFields["DynamicalColoumn"].Text = clsCommon.fncsetstring("Bill Date");
        //            else
        //                objRpt.DataDefinition.FormulaFields["DynamicalColoumn"].Text = clsCommon.fncsetstring("APN Date");
        //        }
        //        objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
        //        objRpt.DataDefinition.FormulaFields["ReportTitle2"].Text = clsCommon.fncsetstring(sReportTitle2);
        //        objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
        //        objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
        //        objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
        //        objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
        //        objRpt.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sFilter);
        //        objRpt.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsCommon.getCompanyEmail());
        //        objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"));
        //        objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);

        //        frm_ReportViewer ReportViewer = new frm_ReportViewer();
        //        ReportViewer.Process_Print(ReportName);
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
        #endregion

        #region KeyDown Events
        private void txt_Customer_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void txtBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_BankID();
            }
        }
        private void frm_rpt_ChequeManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterSupplier(ref txtSupplier);
            }
        }
        #endregion

        #region Events DoublClick
        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
        }

        private void txtBank_DoubleClick(object sender, EventArgs e)
        {
            Search_BankID();
        }
        #endregion

        #region Search Methods
        private void Search_CustomerID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_CustomerMaster();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtCustomer.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                    txtCustomer.Tag = frmSearchMaster.s_SearchID;
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
                    txtBank.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                    txtBank.Tag = frmSearchMaster.s_SearchID;
            }
        }
        private void txtSupplier_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterSupplier(ref txtSupplier);
        }

        #endregion

        private void setEnableDisableConctrol(int iReportID)
        {
            clearField();
            //clsCommon.SetEnableDisable_NormalCheckBox(chkSupplierWiseReport, false);
            if (iReportID == (int)enum_ReportName.RG_Account_Payable_Note_Summary_Report)
            {
                clsCommon.SetVisibility_Panel(pnlSupplier, true);
                clsCommon.SetVisibility_Panel(pnlSupplierWiseReport, true);
                clsCommon.SetVisibility_Panel(pnlBillDate, true);
            }
            else if (iReportID == (int)enum_ReportName.RG_Account_Payable_Note_Detail_Report)
            {
                clsCommon.SetVisibility_Panel(pnlSupplier, true);
                clsCommon.SetVisibility_Panel(pnlBillDate, true);
            }
            else if (iReportID == (int)enum_ReportName.RG_Payment_Voucher_Summary_Report || iReportID == (int)enum_ReportName.RG_Payment_Voucher_Detail_Report
                || iReportID == (int)enum_ReportName.RG_Debit_Note_Summery_Report_Supplier || iReportID == (int)enum_ReportName.RG_Debit_Note_Detail_Report_Supplier)
            {
                clsCommon.SetVisibility_Panel(pnlSupplier, true);
            }

            else if (iReportID == (int)enum_ReportName.RG_JournalVoucher_Summary_Report || iReportID == (int)enum_ReportName.RG_JournalVoucher_Detail_Report)
            {
                clsCommon.SetVisibility_Panel(pnlJETypes, true);
            }
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
    }
}
