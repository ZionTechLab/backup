using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DataTire;
using Digiteq_Logic;
using Digiteq.DataSets;

namespace Digiteq
{
    public partial class frm_rpt_AccountPayableReports : MettroForm
    {

        #region Variables
        //form manage
        public int iFormID;
        dts_Bills glb_dts_Bills = new dts_Bills();
        dts_Sales glbDtsSales = new dts_Sales();
        dts_AccountsPayable glb_dts_AccountsPayable = new dts_AccountsPayable();
        dts_Accounts glb_dts_Accounts = new dts_Accounts();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        public bool bNoAccess;
        bool bSupplierSelected = false, bSupplierClassSelected = false, bSupplierTypeSelected = false, bSupplierCategorySelected = false;
        enum_ReportName Report;

        #endregion

        #region Form Load
        public frm_rpt_AccountPayableReports()
        {
            iFormID = clsSecurity.getFormID(FormName.AccountPayableReports);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;
            InitializeComponent();
        }

        private void frmReportChequeDeposit_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, clsHelpMethods.getFormName(iFormID), 2, iFormID);
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
                dgvReports.DataSource = DBHandling.ExecQuery("EXEC sp_Reports '" + 21 + "'").Tables[0];
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
                            string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                            if (clsHelpMethods.GetReportPath(clsAutocode.getReportID(Report), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                            {
                                #region Filters
                                prog_ProgressBar.Value = 0;

                                bool bSupplierSelected = false, bSupplierClassSelected = false, bSupplierTypeSelected = false, bSupplierCategorySelected = false, bStoskNoteTypeSelected = false;
                                string sFilter = "";
                                //sReportID = "";
                                if (txtBranch.Tag != null && txtBranch.Tag.ToString().Trim().Length > 0)
                                {
                                    sFilter = "Company Branch : " + txtBranch.Text;
                                }
                                if (txtSupplier.Tag != null && txtSupplier.Tag.ToString().Trim().Length > 0)
                                {
                                    bSupplierSelected = true;
                                    sFilter += (sFilter != "" ? " | " : "") + "Suplier Name : " + txtSupplier.Text;
                                }
                                if (txtSupClass.Tag != null && txtSupClass.Tag.ToString().Trim().Length > 0)
                                {
                                    bSupplierClassSelected = true;
                                    sFilter += (sFilter != "" ? " | " : "") + "Suplier Class : " + txtSupClass.Text;
                                }
                                if (txtSupType.Tag != null && txtSupType.Tag.ToString().Trim().Length > 0)
                                {
                                    bSupplierTypeSelected = true;
                                    sFilter += (sFilter != "" ? " | " : "") + "Suplier Type : " + txtSupType.Text;
                                }
                                if (txtSupCategory.Tag != null && txtSupCategory.Tag.ToString().Trim().Length > 0)
                                {
                                    bSupplierCategorySelected = true;
                                    sFilter += (sFilter != "" ? " | " : "") + "Suplier Category : " + txtSupCategory.Text;
                                }

                                if (txtNoteType.Tag != null && txtNoteType.Tag.ToString().Trim().Length > 0)
                                {
                                    bStoskNoteTypeSelected = true;
                                    sFilter += (sFilter != "" ? " | " : "") + "Stock Note Type : " + txtNoteType.Text;
                                }
                                #endregion

                                #region Supplier Outstanding
                                if (Report == enum_ReportName.RG_Supplier_wise_Outstanding_Summary || Report == enum_ReportName.RG_Supplier_wise_Outstanding_Detail)
                                {
                                    //bool bPermitionOk = false;
                                    //if (rdoSupplierOutstandingsSummary.Checked)
                                    //{
                                    //    if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Supplier_wise_Outstanding_Summary)))
                                    //        bPermitionOk = true;
                                    //    sReportID = clsAutocode.getReportID(enum_ReportName.RG_Supplier_wise_Outstanding_Summary);
                                    //}
                                    //else
                                    //{
                                    //    if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Supplier_wise_Outstanding_Detail)))
                                    //        bPermitionOk = true;
                                    //    sReportID = clsAutocode.getReportID(enum_ReportName.RG_Supplier_wise_Outstanding_Detail);
                                    //}

                                    //if (bPermitionOk)
                                    //{
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glbDtsSales.Clear();

                                        #region As Of Date Report

                                        //    if (false)
                                        //    {
                                        //        #region APN
                                        //        foreach (tbl_accAccountPayableNote oAPN in tbl_accAccountPayableNote.SelectAll().Where(p => p.AccountPayableNote_ID != "default" && !p.IsDeleted && !p.IsSeattled && p.Supplier_ID != "default"))
                                        //        {
                                        //            if (bSupplierSelected)
                                        //            {
                                        //                if (oAPN.Supplier_ID != txtSupplier.Tag.ToString().Trim())
                                        //                    continue;
                                        //            }

                                        //            glbDtsSales.dt_bssSupplierOutstanding.Adddt_bssSupplierOutstandingRow(oAPN.Supplier_ID, clsGenaralName.getName_Supplier(oAPN.Supplier_ID), oAPN.AccountPayableNote_ID,
                                        //                oAPN.AccountPayableNoteDate, oAPN.GrandTotal, (oAPN.GrandTotal - oAPN.SettledAmount), "APN <" + oAPN.AccountPayableNote_ID + ">", false, false);
                                        //        }
                                        //        #endregion

                                        //        #region ACC Debit Note
                                        //        //foreach (tbl_accDebitNote oDebitNote in tbl_accDebitNote.SelectAll().Where(p => p.DebitNote_ID != "default" && !p.IsDeleted))
                                        //        //{
                                        //        //    if (bSupplierSelected)
                                        //        //    {
                                        //        //        if (oDebitNote.Supplier_ID != txtSupplier.Tag.ToString().Trim())
                                        //        //            continue;
                                        //        //    }
                                        //        //    string sAPNID = "";
                                        //        //    int iCount = 0;
                                        //        //    foreach (tbl_accDebitNote_Detail detail in tbl_accDebitNote_Detail.SelectAllByDebitNote_ID(oDebitNote.DebitNote_ID))
                                        //        //    {
                                        //        //        if (iCount != 0)
                                        //        //            sAPNID += " , ";
                                        //        //        sAPNID += detail.AccountPayableNote_ID;
                                        //        //        iCount++;
                                        //        //    }

                                        //        //    glbDtsSales.dt_bssSupplierOutstanding.Adddt_bssSupplierOutstandingRow(oDebitNote.Supplier_ID, clsGenaralName.getName_Supplier(oDebitNote.Supplier_ID), oDebitNote.DebitNote_ID,
                                        //        //                   oDebitNote.DebitNote_Date, oDebitNote.GrandTotal, 0, "Debit Note <" + sAPNID + ">", false, true);
                                        //        //}
                                        //        #endregion

                                        //        #region P. V.
                                        //        foreach (tbl_accChequeRegister oCheque in tbl_accChequeRegister.SelectAll().Where(p => p.ChequeRegister_ID != "delault" && !p.IsDeleted))
                                        //        {
                                        //            tbl_accPaymentVoucher oPV = tbl_accPaymentVoucher.Select(oCheque.PaymentVoucher_ID);
                                        //            if (oPV.Supplier_ID != "default" && oPV != null && oPV.PaymentVoucher_ID != "default")
                                        //            {
                                        //                if (oPV != null && oPV.PaymentVoucher_ID != "Default")
                                        //                {
                                        //                    if (bSupplierSelected)
                                        //                    {
                                        //                        if (oPV.Supplier_ID != txtSupplier.Tag.ToString().Trim())
                                        //                            continue;
                                        //                    }

                                        //                    //unsettled
                                        //                    if (!oPV.IsSeattled)
                                        //                    {
                                        //                        //glbDtsSales.dt_bssSupplierOutstanding.Adddt_bssSupplierOutstandingRow(oPV.Supplier_ID, clsGenaralName.getName_Supplier(oPV.Supplier_ID), oPV.PaymentVoucher_ID,
                                        //                        //    oPV.PaymentVoucherDate, oCheque.ChequeAmount, oCheque.ChequeAmount, "Unsettled Cheque <" + oCheque.ChequeNumber + ">", false, true);
                                        //                    }

                                        //                    //cheque in hand
                                        //                    if (oCheque.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.New))
                                        //                    {
                                        //                        glbDtsSales.dt_bssSupplierOutstanding.Adddt_bssSupplierOutstandingRow(oPV.Supplier_ID, clsGenaralName.getName_Supplier(oPV.Supplier_ID), oPV.PaymentVoucher_ID,
                                        //                            oPV.PaymentVoucherDate, oCheque.ChequeAmount, oCheque.ChequeAmount, "Cheque In Hand <" + oCheque.ChequeNumber + ">", true, false);
                                        //                    }
                                        //                }
                                        //            }
                                        //        }
                                        //        #endregion

                                        //        if (rdoSupplierOutstandingsSummary.Checked)
                                        //            print(@"\Reports\BSS\AP\rpt_sas_Outstanding_Supplier.rpt", "Supplier Outstanding Summary", glbDtsSales.dt_bssSupplierOutstanding);
                                        //        else
                                        //            print(@"\Reports\BSS\AP\rpt_sas_Outstanding_Supplier.rpt", "Supplier Outstanding detail", glbDtsSales.dt_bssSupplierOutstanding);
                                        //        MessageBox.Show("please use back date report");
                                        //    }
                                        #endregion

                                        #region Back Date Report
                                        #region Old Method
                                        //List<tbl_genSupplierMaster> oSuuplier;
                                        //if (cmbCreditorType.SelectedIndex == 0)//All
                                        //    oSuuplier = tbl_genSupplierMaster.SelectAll().Where(p => !p.IsDeleted).ToList();
                                        //if (cmbCreditorType.SelectedIndex == 1)//Supplier only
                                        //{
                                        //    if (bSupplierSelected)
                                        //        oSuuplier = tbl_genSupplierMaster.SelectAll().Where(p => !p.IsDeleted && p.Supplier_ID == txtSupplier.Tag.ToString()).ToList();
                                        //    else
                                        //        oSuuplier = tbl_genSupplierMaster.SelectAll().Where(p => !p.IsDeleted && p.Supplier_ID != "default").ToList();
                                        //}
                                        //else //Gl
                                        //    oSuuplier = tbl_genSupplierMaster.SelectAll().Where(p => !p.IsDeleted && p.Supplier_ID == "default").ToList();

                                        //foreach (tbl_genSupplierMaster oSuupliers in oSuuplier)
                                        //{
                                        //    if (rdoLocal.Checked)
                                        //    {
                                        //        if (oSuupliers.SupplierType_ID.Trim() != "1")
                                        //            continue;
                                        //    }
                                        //    else if (rdoExport.Checked)
                                        //    {
                                        //        if (oSuupliers.SupplierType_ID.Trim() != "2")
                                        //            continue;
                                        //    }

                                        //    foreach (srh_bssSupplierOutstanding oOutstanding in srh_bssSupplierOutstanding.SelectAllBySupplierId(oSuupliers.Supplier_ID, dtpDateTo.Value.Date, chkHidedebitNote.Checked, chkAPNDate.Checked).Where(p => p.OutstandingAmount != 0 || p.ChequeInHand != 0))
                                        //    {
                                        //        glbDtsSales.dt_bssSupplierOutstanding.Adddt_bssSupplierOutstandingRow(oSuupliers.Supplier_ID, oSuupliers.SupplierName, oOutstanding.Transaction_ID, oOutstanding.TransactionDate, oOutstanding.TransactionAmount, (oOutstanding.TransactionType == 1 ? 1 : -1) * oOutstanding.OutstandingAmount, oOutstanding.ChequeInHand, oOutstanding.Remark, (oOutstanding.ChequeInHand == 1 ? true : false), false);
                                        //    }

                                        //    clsHelpMethods.startProgressBar(0, oSuuplier.Count + 2, 1, prog_ProgressBar);
                                        //}
                                        #endregion

                                        string sSupplier = "%%", sOtherCreditor = "%";
                                        int iHideDebitNote = 0;
                                        if (cmbCreditorType.SelectedIndex == 1)//Supplier only  
                                            if (bSupplierSelected)
                                                sSupplier = txtSupplier.Tag.ToString();

                                        //if (cmbCreditorType.SelectedIndex != 1 && cmbCreditorType.SelectedIndex != 0)
                                        //    sSupplier = "default";

                                        if (cmbCreditorType.SelectedIndex == 1)
                                            sOtherCreditor = "%0%";
                                        if (cmbCreditorType.SelectedIndex == 2)
                                            sOtherCreditor = "%1%";

                                        if (chkHidedebitNote.Checked)
                                            iHideDebitNote = 1;

                                        if (chkAPNDate.Checked)
                                            glbDtsSales.dt_bssSupplierOutstanding.Merge(DBHandling.ExecQuery("Exec srh_bssSupplierOutstandingSelectAllBySupplierID_BillDate '" + sSupplier + "','" + dtpDateTo.Value.Date + "','" + iHideDebitNote + "', '" + txtBranch.Tag.ToString() + "', '" + sOtherCreditor + "'").Tables[0]);
                                        else
                                            glbDtsSales.dt_bssSupplierOutstanding.Merge(DBHandling.ExecQuery("Exec srh_bssSupplierOutstandingSelectAllBySupplierID '" + sSupplier + "','" + dtpDateTo.Value.Date + "','" + iHideDebitNote + "', '" + txtBranch.Tag.ToString() + "', '" + sOtherCreditor + "'").Tables[0]);

                                        //string sPath = "", sReportTitle = "";
                                        //if (rdoSupplierOutstandingsSummary.Checked)
                                        //{
                                        //    sPath = @"\Reports\BSS\AP\rpt_sas_Outstanding_Supplier1.rpt";
                                        //    sReportTitle = "Supplier Outstanding Summary";
                                        //}
                                        //else
                                        //{
                                        //    sPath = @"\Reports\BSS\AP\rpt_sas_Outstanding_Supplier1.rpt";
                                        //    sReportTitle = "Supplier Outstanding detail";
                                        //}

                                        glbDtsSales.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", "", clsSecurity.UserNameLoged, "");
                                        print(sReportPath, sReportTitle_Main, glbDtsSales, clsAutocode.getReportID(Report));
                                        #endregion

                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        glbDtsSales.dt_bssSupplierOutstanding.Clear();
                                        Cursor = Cursors.Default;
                                        prog_ProgressBar.Value = 0;
                                    }
                                    //}
                                }
                                #endregion

                                #region Creditors Age Analysis
                                else if (Report == enum_ReportName.AP_Creditors_Age_anlysis_Detail || Report == enum_ReportName.AP_Creditors_Age_anlysis_Summary)
                                {
                                    //if (rdoCreaditorsAge.Checked)
                                    //{
                                    //    sReportTitle = "Creditors Age analysis";
                                    //    sReportPath = "\\Reports\\BSS\\AP\\rpt_accCreditorsAgeAnalysisReport.rpt";
                                    //    ReportName = enum_ReportName.AP_Creditors_Age_anlysis_Detail;
                                    //}
                                    //else
                                    //{
                                    //    sReportTitle = "Creditors Age Analysis Summary";
                                    //    sReportPath = "\\Reports\\BSS\\AP\\rpt_accCreditorsAgeAnalysisSummaryReport.rpt";
                                    //    ReportName = enum_ReportName.AP_Creditors_Age_anlysis_Summary;
                                    //}
                                    try
                                    {
                                        DateTime dtDueDate;
                                        decimal dAgeDays = 0;
                                        // string sFilter = "-";

                                        Cursor = Cursors.WaitCursor;
                                        glb_dts_Accounts.Clear();
                                        glb_dts_Accounts.dt_accCreditorsAgeAnalysis.Rows.Clear();

                                        List<tbl_accAccountPayableNote> oAPNa = null;

                                        #region Supplier Filter
                                        //List<tbl_genSupplierMaster> oSupplerList;
                                        //if (bSupplierSelected)
                                        //    oSupplerList = tbl_genSupplierMaster.SelectAll().Where(p => p.Supplier_ID == txtSupplier.Tag.ToString()).ToList();
                                        //else
                                        //    oSupplerList = tbl_genSupplierMaster.SelectAll().ToList();
                                        #endregion

                                        //foreach (tbl_genSupplierMaster oSupplier in oSupplerList)
                                        //{
                                        //    if (bSupplierClassSelected)
                                        //    {
                                        //        if (oSupplier.SupplierClass_ID != txtSupClass.Tag.ToString().Trim())
                                        //            continue;
                                        //    }
                                        //    if (bSupplierTypeSelected)
                                        //    {
                                        //        if (oSupplier.SupplierType_ID != txtSupType.Tag.ToString().Trim())
                                        //            continue;
                                        //    }
                                        //    if (bSupplierCategorySelected)
                                        //    {
                                        //        if (oSupplier.SupplierCategory_ID != txtSupCategory.Tag.ToString().Trim())
                                        //            continue;
                                        //    }

                                        if (txtSupplier.Tag != null)
                                        {
                                            oAPNa = tbl_accAccountPayableNote.SelectAllBySupplier_ID(txtSupplier.Tag.ToString().Trim()).Where(p => !p.IsDeleted && !p.IsSeattled
                                                        && p.AccountPayableNoteDate.Date >= dtpDateFrom.Value.Date && p.AccountPayableNoteDate.Date <= dtpDateTo.Value.Date).ToList();
                                            //sFilter = "Single Supplier -" + txtSupplier.Text;
                                        }
                                        else
                                        {
                                            if (cmbCreditorType.SelectedIndex == 0)
                                                oAPNa = tbl_accAccountPayableNote.SelectAll().Where(p => !p.IsDeleted && !p.IsSeattled
                                                && p.AccountPayableNoteDate.Date >= dtpDateFrom.Value.Date && p.AccountPayableNoteDate.Date <= dtpDateTo.Value.Date).ToList();
                                            else if (cmbCreditorType.SelectedIndex == 1)
                                                oAPNa = tbl_accAccountPayableNote.SelectAll().Where(p => !p.IsDeleted && !p.IsSeattled && p.Supplier_ID != "default"
                                                && p.AccountPayableNoteDate.Date >= dtpDateFrom.Value.Date && p.AccountPayableNoteDate.Date <= dtpDateTo.Value.Date).ToList();
                                            else if (cmbCreditorType.SelectedIndex == 2)
                                                oAPNa = tbl_accAccountPayableNote.SelectAll().Where(p => !p.IsDeleted && !p.IsSeattled && p.Supplier_ID == "default"
                                                && p.AccountPayableNoteDate.Date >= dtpDateFrom.Value.Date && p.AccountPayableNoteDate.Date <= dtpDateTo.Value.Date).ToList();
                                        }

                                        foreach (tbl_accAccountPayableNote oAPN in oAPNa)
                                        {
                                            //foreach (tbl_genSupplierMaster oSupplier in oAPN.Supplier_ID)
                                            tbl_genSupplierMaster oSupplier = tbl_genSupplierMaster.Select(oAPN.Supplier_ID);
                                            if (oSupplier != null)
                                            {
                                                if (bSupplierClassSelected)
                                                {
                                                    if (oSupplier.SupplierClass_ID != txtSupClass.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bSupplierTypeSelected)
                                                {
                                                    if (oSupplier.SupplierType_ID != txtSupType.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bSupplierCategorySelected)
                                                {
                                                    if (oSupplier.SupplierCategory_ID != txtSupCategory.Tag.ToString().Trim())
                                                        continue;
                                                }
                                            }

                                            if (oAPN.Supplier_ID != "default" && oAPN.AccountPayableNote_ID != "default")
                                            {
                                                if (cmbCreditorType.SelectedIndex == 0 || cmbCreditorType.SelectedIndex == 1)
                                                {
                                                    #region Supplier
                                                    dtDueDate = oAPN.BillDate.Date.AddDays(double.Parse(oAPN.CreditDays.ToString()));
                                                    dAgeDays = decimal.Parse(clsSecurity.getServerDateTime().Date.Subtract(oAPN.BillDate.Date).TotalDays.ToString());

                                                    glb_dts_Accounts.dt_accCreditorsAgeAnalysis.Adddt_accCreditorsAgeAnalysisRow(oAPN.AccountPayableNote_ID, oAPN.Supplier_ID,
                                                        clsGenaralName.getName_Supplier(oAPN.Supplier_ID), oAPN.BillNo, oAPN.BillDate.Date, oAPN.GrandTotal, oAPN.GrandTotal - oAPN.SettledAmount, oAPN.CreditDays, dtDueDate, dAgeDays, oAPN.AccountPayableNote_ID);


                                                    #endregion
                                                }
                                            }
                                            else
                                            {
                                                if (cmbCreditorType.SelectedIndex == 0 || cmbCreditorType.SelectedIndex == 2)
                                                {
                                                    #region GL only
                                                    bool bIsGlCodeOk = false;
                                                    // string sCreditorName = "";
                                                    string sGlCode = "";
                                                    int iCount = 0;

                                                    List<tbl_accAccountPayableNote_SubTotal> oAPNSubs = tbl_accAccountPayableNote_SubTotal.SelectAllByAccountPayableNote_ID(oAPN.AccountPayableNote_ID).Where(p => p.IsCredit).ToList();
                                                    if (oAPNSubs != null)
                                                    {
                                                        dtDueDate = oAPN.BillDate.Date.AddDays(double.Parse(oAPN.CreditDays.ToString()));
                                                        dAgeDays = decimal.Parse(clsSecurity.getServerDateTime().Date.Subtract(oAPN.BillDate.Date).TotalDays.ToString());

                                                        if (oAPNSubs.Count == 1)
                                                        {
                                                            bIsGlCodeOk = true;
                                                        }
                                                        else
                                                        {
                                                            foreach (tbl_accAccountPayableNote_SubTotal oAPNSub in oAPNSubs)
                                                            {
                                                                if (iCount != 0)
                                                                {
                                                                    if (sGlCode == oAPNSub.Gl_ID)
                                                                        bIsGlCodeOk = true;
                                                                    else
                                                                    {
                                                                        bIsGlCodeOk = false;
                                                                        break;
                                                                    }
                                                                }
                                                                sGlCode = oAPNSub.Gl_ID;
                                                                iCount += 1;
                                                            }
                                                        }
                                                        foreach (tbl_accAccountPayableNote_SubTotal oAPNSub in oAPNSubs)
                                                        {
                                                            glb_dts_Accounts.dt_accCreditorsAgeAnalysis.Adddt_accCreditorsAgeAnalysisRow(oAPN.AccountPayableNote_ID, oAPNSub.Gl_ID,
                                                                clsGenaralName.getName_AccountName(oAPNSub.Gl_ID), oAPN.BillNo, oAPN.BillDate.Date, oAPNSub.Amount, oAPNSub.Amount - oAPN.SettledAmount, oAPN.CreditDays, dtDueDate, dAgeDays, oAPN.AccountPayableNote_ID);
                                                            if (bIsGlCodeOk)
                                                            {
                                                                break;
                                                            }
                                                        }
                                                    }
                                                    #endregion
                                                }
                                            }

                                            //clsHelpMethods.startProgressBar(0, oAPNa.Count + 2, 1, prog_ProgressBar);
                                        }
                                        //clsHelpMethods.startProgressBar(0, oAPNa.Count + 2, 1, prog_ProgressBar);
                                        //}
                                        //print(sReportPath, sReportTitle, glb_dts_Accounts.dt_accCreditorsAgeAnalysis, sFilter);
                                        //if (cmbCreditorType.SelectedIndex == 1)
                                        //    sFilter += (sFilter != "" ? "| " : "") + "Supplies Only";
                                        //if (cmbCreditorType.SelectedIndex == 2)
                                        //    sFilter += (sFilter != "" ? "| " : "") + "Non Supplies Only";
                                        //if (Report == enum_ReportName.AP_Creditors_Age_anlysis_Summary)
                                        {
                                            //if (cmbCreditorType.SelectedIndex == 1)
                                            //    sFilter += (sFilter != "" ? "| " : "") + "Supplies Only";
                                            //if (cmbCreditorType.SelectedIndex == 2)
                                            //    sFilter += (sFilter != "" ? "| " : "") + "Non Supplies Only";
                                            string sDaterange = clsCommon.fncsetstring("From : " + dtpDateFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpDateTo.Value.ToString("dd MMM yyyy"));
                                            glb_dts_Accounts.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDaterange, clsSecurity.UserNameLoged, sFilter.Trim());
                                            frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                            rpt.print(sReportPath, glb_dts_Accounts, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                        }
                                        //else
                                        //{
                                        //    if (cmbCreditorType.SelectedIndex == 1)
                                        //        sFilter += (sFilter != "" ? "| " : "") + "Supplies Only";
                                        //    if (cmbCreditorType.SelectedIndex == 2)
                                        //        sFilter += (sFilter != "" ? "| " : "") + "Non Supplies Only";
                                        //    //(sReportPath, sReportTitle_Main, glb_dts_Accounts.dt_accCreditorsAgeAnalysis, clsAutocode.getReportID(Report));
                                        //    print(sReportPath, sReportTitle_Main, glb_dts_Accounts.dt_accCreditorsAgeAnalysis, sFilter.ToUpper());
                                        //}

                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        glb_dts_Accounts.dt_accCreditorsAgeAnalysis.Rows.Clear();
                                        Cursor = Cursors.Default;
                                        prog_ProgressBar.Value = 0;
                                    }
                                }
                                #endregion

                                #region Tax Report(APN)
                                else if (Report == enum_ReportName.AP_Tax)
                                {
                                    try
                                    {
                                        glb_dts_AccountsPayable.dt_TaxReportApn.Rows.Clear();
                                        Cursor = Cursors.WaitCursor;

                                        //Variables
                                        TimeSpan oTimeSpan = new TimeSpan();
                                        //string sFillterBy = "";

                                        //if (txtSupplier.Tag != null && txtSupplier.Tag.ToString().Trim().Length > 0)
                                        //    sFillterBy = txtSupplier.Text;

                                        oTimeSpan = dtpDateFrom.Value.Date - dtpDateTo.Value.Date;
                                        List<tbl_accAccountPayableNote> oAccountPayble = tbl_accAccountPayableNote.SelectAll().Where(p => p.AccountPayableNote_ID != "default" && !p.IsDeleted && p.AccountPayableNoteDate.Date >= dtpDateFrom.Value.Date && p.AccountPayableNoteDate.Date <= dtpDateTo.Value.Date).ToList();
                                        foreach (tbl_accAccountPayableNote oNotes in oAccountPayble)
                                        {
                                            string sSvatRegistrationNo = "", sVatRegistrationNo = "";

                                            if (txtSupplier.Tag != null && txtSupplier.Tag.ToString().Trim().Length > 0)
                                                if (txtSupplier.Tag != oNotes)
                                                    continue;

                                            tbl_genSupplierMaster oSupplier = tbl_genSupplierMaster.Select(oNotes.Supplier_ID);

                                            if (oSupplier != null)
                                            {
                                                sVatRegistrationNo = oSupplier.VatRegistrationNo;
                                                sSvatRegistrationNo = oSupplier.SvatRegistrationNo;
                                            }
                                            glb_dts_AccountsPayable.dt_TaxReportApn.Adddt_TaxReportApnRow("", clsGenaralName.getName_Supplier(oNotes.Supplier_ID), sVatRegistrationNo, sSvatRegistrationNo, oNotes.AccountPayableNote_ID, oNotes.BillNo, oNotes.BillDate, oNotes.SubTotal, oNotes.NbtTotal, oNotes.VatTotal, 0, oNotes.GrandTotal, 0, oTimeSpan.Days);
                                            clsHelpMethods.startProgressBar(0, oAccountPayble.Count + 2, 1, prog_ProgressBar);
                                        }

                                        //print("\\Reports\\BSS\\AP\\rpt_sas_TaxReport.rpt", "Tax Report(APN)", glb_dts_AccountsPayable.dt_TaxReportApn, sFillterBy);
                                        print("\\Reports\\BSS\\AP\\rpt_sas_TaxReport.rpt", "Tax Report(APN)", glb_dts_AccountsPayable.dt_TaxReportApn, sFilter);
                                    }
                                    catch (Exception) { }

                                    finally
                                    {
                                        glb_dts_AccountsPayable.dt_TaxReportApn.Rows.Clear();
                                        Cursor = Cursors.Default;
                                        prog_ProgressBar.Value = 0;
                                    }
                                }
                                #endregion

                                #region Creditors Outstanding

                                else if (Report == enum_ReportName.AP_Supplier_Outstanding_GRN || Report == enum_ReportName.AP_Supplier_Outstanding_PO)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dts_AccountsPayable.Clear();

                                        //string sReportTitle = "Creditors Outstanding Report (GRN Based)";
                                        //string sReportPath = "\\Reports\\BSS\\AP\\rpt_accActualSupplierOutstandingoverGRN.rpt";
                                        string sRetortType_Formular = "GRN";

                                        if (Report == enum_ReportName.AP_Supplier_Outstanding_PO)
                                        {
                                            //sReportTitle = "Creditors Outstanding Report (PO Based)";
                                            sRetortType_Formular = "PO";
                                        }

                                        #region Supplier Filter
                                        List<tbl_genSupplierMaster> oSupplerList;
                                        if (bSupplierSelected)
                                            oSupplerList = tbl_genSupplierMaster.SelectAll().Where(p => p.Supplier_ID == txtSupplier.Tag.ToString()).ToList();
                                        else
                                            oSupplerList = tbl_genSupplierMaster.SelectAll().ToList();
                                        #endregion

                                        foreach (tbl_genSupplierMaster oSupplier in oSupplerList)
                                        {
                                            if (bSupplierClassSelected)
                                            {
                                                if (oSupplier.SupplierClass_ID != txtSupClass.Tag.ToString().Trim())
                                                    continue;
                                            }
                                            if (bSupplierTypeSelected)
                                            {
                                                if (oSupplier.SupplierType_ID != txtSupType.Tag.ToString().Trim())
                                                    continue;
                                            }
                                            if (bSupplierCategorySelected)
                                            {
                                                if (oSupplier.SupplierCategory_ID != txtSupCategory.Tag.ToString().Trim())
                                                    continue;
                                            }

                                            #region Po Based
                                            if (Report == enum_ReportName.AP_Supplier_Outstanding_PO)
                                            {
                                                foreach (tbl_scsPurchaseOrder oPo in tbl_scsPurchaseOrder.SelectAllBySupplier_ID(oSupplier.Supplier_ID).Where(p => !p.IsDeleted && p.PurchaseOrder_ID != "default" && p.PurchaseOrderDate.Date >= dtpDateFrom.Value.Date && p.PurchaseOrderDate.Date <= dtpDateTo.Value.Date))
                                                {
                                                    if (bStoskNoteTypeSelected)
                                                    {
                                                        if (oPo.StockNoteType_ID != txtNoteType.Tag.ToString().Trim())
                                                            continue;
                                                    }

                                                    foreach (tbl_scsExternalGoodReceivedNote oEGRN in tbl_scsExternalGoodReceivedNote.SelectAllByPurchaseOrder_ID(oPo.PurchaseOrder_ID).Where(p => !p.IsDeleted && p.ExternalGoodReceivedNote_ID != "defualt"))
                                                    {
                                                        foreach (tbl_scsPurchaseReturnedNote oPRN in tbl_scsPurchaseReturnedNote.SelectAllByExternalGoodReceivedNote_ID(oEGRN.ExternalGoodReceivedNote_ID).Where(p => !p.IsDeleted && p.PurchaseReturnedNote_ID != "default"))
                                                        {

                                                            glb_dts_AccountsPayable.dt_ActualSupplierOutstandingOverGRN.Adddt_ActualSupplierOutstandingOverGRNRow(oSupplier.Supplier_ID, oSupplier.SupplierName, oPo.PurchaseOrder_ID, oPo.PurchaseOrderDate, 0, "", DateTime.MinValue, 0, "", DateTime.MinValue, 0, oPRN.GrandTotal);
                                                        }
                                                    }

                                                    glb_dts_AccountsPayable.dt_ActualSupplierOutstandingOverGRN.Adddt_ActualSupplierOutstandingOverGRNRow(oSupplier.Supplier_ID, oSupplier.SupplierName, oPo.PurchaseOrder_ID, oPo.PurchaseOrderDate, oPo.GrandTotal, "", DateTime.MinValue, 0, "", DateTime.MinValue, 0, 0);
                                                    foreach (tbl_accAccountPayableNote oAPN in tbl_accAccountPayableNote.SelectAllByPurchaseOrder_ID(oPo.PurchaseOrder_ID).Where(p => !p.IsDeleted))
                                                    {
                                                        glb_dts_AccountsPayable.dt_ActualSupplierOutstandingOverGRN.Adddt_ActualSupplierOutstandingOverGRNRow(oSupplier.Supplier_ID, oSupplier.SupplierName, oPo.PurchaseOrder_ID, oPo.PurchaseOrderDate, 0, oAPN.AccountPayableNote_ID, oAPN.AccountPayableNoteDate, oAPN.GrandTotal, "", DateTime.MinValue, 0, 0);
                                                        foreach (tbl_accPaymentVoucher_Detail oPVdetail in tbl_accPaymentVoucher_Detail.SelectAllByAccountPayableNote_ID(oAPN.AccountPayableNote_ID))
                                                        {
                                                            tbl_accPaymentVoucher oPV = tbl_accPaymentVoucher.Select(oPVdetail.PaymentVoucher_ID);
                                                            if (oPV != null && !oPV.IsDeleted)
                                                            {
                                                                glb_dts_AccountsPayable.dt_ActualSupplierOutstandingOverGRN.Adddt_ActualSupplierOutstandingOverGRNRow(oSupplier.Supplier_ID, oSupplier.SupplierName, oPo.PurchaseOrder_ID, oPo.PurchaseOrderDate, 0, oAPN.AccountPayableNote_ID, oAPN.AccountPayableNoteDate, 0, oPVdetail.PaymentVoucher_ID, oPV.PaymentVoucherDate, oPVdetail.SettleAmount, 0);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            #endregion

                                            #region GRN Based
                                            else
                                            {
                                                foreach (tbl_scsExternalGoodReceivedNote oGrn in tbl_scsExternalGoodReceivedNote.SelectAllBySupplier_ID(oSupplier.Supplier_ID).Where(p => !p.IsDeleted && p.ExternalGoodReceivedNote_ID != "default" && p.ExternalGoodReceivedNoteDate.Date >= dtpDateFrom.Value.Date && p.ExternalGoodReceivedNoteDate.Date <= dtpDateTo.Value.Date))
                                                {
                                                    if (bStoskNoteTypeSelected)
                                                    {
                                                        if (oGrn.StockNoteType_ID != txtNoteType.Tag.ToString().Trim())
                                                            continue;
                                                    }

                                                    foreach (tbl_scsPurchaseReturnedNote oPRN in tbl_scsPurchaseReturnedNote.SelectAllByExternalGoodReceivedNote_ID(oGrn.ExternalGoodReceivedNote_ID).Where(p => !p.IsDeleted && p.PurchaseReturnedNote_ID != "default"))
                                                    {
                                                        glb_dts_AccountsPayable.dt_ActualSupplierOutstandingOverGRN.Adddt_ActualSupplierOutstandingOverGRNRow(oSupplier.Supplier_ID, oSupplier.SupplierName, oGrn.ExternalGoodReceivedNote_ID, oGrn.ExternalGoodReceivedNoteDate, 0, "", DateTime.MinValue, 0, "", DateTime.MinValue, 0, oPRN.GrandTotal);
                                                    }

                                                    glb_dts_AccountsPayable.dt_ActualSupplierOutstandingOverGRN.Adddt_ActualSupplierOutstandingOverGRNRow(oSupplier.Supplier_ID, oSupplier.SupplierName, oGrn.ExternalGoodReceivedNote_ID, oGrn.ExternalGoodReceivedNoteDate, oGrn.GrandTotal, "", DateTime.MinValue, 0, "", DateTime.MinValue, 0, 0);
                                                    foreach (tbl_accAccountPayableNote oAPN in tbl_accAccountPayableNote.SelectAllByExternalGoodReceivedNote_ID(oGrn.ExternalGoodReceivedNote_ID).Where(p => !p.IsDeleted))
                                                    {
                                                        glb_dts_AccountsPayable.dt_ActualSupplierOutstandingOverGRN.Adddt_ActualSupplierOutstandingOverGRNRow(oSupplier.Supplier_ID, oSupplier.SupplierName, oGrn.ExternalGoodReceivedNote_ID, oGrn.ExternalGoodReceivedNoteDate, 0, oAPN.AccountPayableNote_ID, oAPN.AccountPayableNoteDate, oAPN.GrandTotal, "", DateTime.MinValue, 0, 0);
                                                        foreach (tbl_accPaymentVoucher_Detail oPVdetail in tbl_accPaymentVoucher_Detail.SelectAllByAccountPayableNote_ID(oAPN.AccountPayableNote_ID))
                                                        {
                                                            tbl_accPaymentVoucher oPV = tbl_accPaymentVoucher.Select(oPVdetail.PaymentVoucher_ID);
                                                            if (oPV != null && !oPV.IsDeleted)
                                                            {
                                                                glb_dts_AccountsPayable.dt_ActualSupplierOutstandingOverGRN.Adddt_ActualSupplierOutstandingOverGRNRow(oSupplier.Supplier_ID, oSupplier.SupplierName, oGrn.ExternalGoodReceivedNote_ID, oGrn.ExternalGoodReceivedNoteDate, 0, oAPN.AccountPayableNote_ID, oAPN.AccountPayableNoteDate, 0, oPVdetail.PaymentVoucher_ID, oPV.PaymentVoucherDate, oPVdetail.SettleAmount, 0);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            #endregion
                                        }

                                        string sDateRange = "From :" + dtpDateFrom.Value.ToString("dd MMM yyyy") + " To :" + dtpDateTo.Value.ToString("dd MMM yyyy");

                                        glb_dts_AccountsPayable.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("isPO", sRetortType_Formular, true, false);
                                        rpt.print(sReportPath, glb_dts_AccountsPayable, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        glb_dts_AccountsPayable.Clear();
                                        Cursor = Cursors.Default;
                                        prog_ProgressBar.Value = 0;
                                    }
                                }
                                #endregion

                                #region Supplier Journal
                                else if (Report == enum_ReportName.AP_SupplierJournalTrackingReport)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dts_Accounts.Clear();

                                        string sDaterange = "From " + dtpDateFrom.Value.Date.ToString("dd-MMM-yyyy") + " To " + dtpDateTo.Value.Date.ToString("dd-MMM-yyyy");
                                        string sSupplier = "%%";
                                        if (bSupplierSelected)
                                            sSupplier = "%" + txtSupplier.Tag.ToString() + "%";

                                        glb_dts_Accounts.dts_accSuppplierJournal.Merge(DBHandling.ExecQuery("exec spSupplierJournalSelectAll '" + sSupplier + "','" + dtpDateFrom.Value.Date + "','" + dtpDateTo.Value.Date + "','" + clsSecurity.BranchID + "'").Tables[0]);
                                        glb_dts_Accounts.dts_accSuppplierJournalOPBL.Merge(DBHandling.ExecQuery("exec spSupplierJournalOPBLSelectAll '" + sSupplier + "','" + dtpDateFrom.Value.Date + "','" + clsSecurity.BranchID + "'").Tables[0]);

                                        #region Selected Filters
                                        if (sFilter == "")
                                            sFilter += " All Records";
                                        #endregion

                                        glb_dts_Accounts.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDaterange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dts_Accounts, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                    }
                                    catch (Exception ex)
                                    {
                                        SEACCException.Show(ex);
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glb_dts_Accounts.Clear();
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
            //setEnableDisableConctrol();
        }
        #endregion

        #region ClearField
        private void clearField()
        {
            txtSupplier.Tag = null;
            txtSupplier.Clear();
            txtSupplier.Text = "<All Supplier>";
            txtNoteType.Tag = null;
            txtNoteType.Clear();
            txtNoteType.Text = "<All Stock Notes>";
            txtSupClass.Tag = null;
            txtSupClass.Clear();
            txtSupClass.Text = "<All Supplier Class>";
            txtSupType.Tag = null;
            txtSupType.Clear();
            txtSupType.Text = "<All Supplier Type>";
            txtSupCategory.Tag = null;
            txtSupCategory.Clear();
            txtSupCategory.Text = "<All Supplier Category>";

            chkHidedebitNote.Checked = false;
            chkAPNDate.Checked = false;

            clsCommon.SetVisibility_Panel(pnlSupplier, false);
            clsCommon.SetVisibility_Panel(pnlNoteType, false);
            clsCommon.SetVisibility_Panel(pnlSupClass, false);
            clsCommon.SetVisibility_Panel(pnlSupType, false);
            clsCommon.SetVisibility_Panel(pnlSupCategory, false);
            clsCommon.SetVisibility_Panel(pnlFromDate, false);
            clsCommon.SetVisibility_Panel(pnlToDate, false);
            clsCommon.SetVisibility_Panel(pnlBranch, true);
            clsCommon.SetVisibility_Panel(pnlCreditorType, false);
            clsCommon.SetVisibility_Panel(pnlType, false);
            clsCommon.SetVisibility_Panel(pnlDBNOutstanding, false);
            clsCommon.SetVisibility_Panel(pnlUseBillDate, false);

            rdoAll.Checked = true;
            cmbCreditorType.SelectedIndex = 1;

            rdoAll.Visible = false;
            rdoLocal.Visible = false;
            rdoExport.Visible = false;

            tbl_genCompanyBranchMaster oBranch = tbl_genCompanyBranchMaster.Select(clsSecurity.BranchID);
            if (oBranch != null)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtBranch, oBranch.IsHeadOffice);
                clsCommon.SetEnableDisable_NormalLabel(lblBranch, oBranch.IsHeadOffice);
            }

            txtBranch.Text = clsSecurity.BranchName;
            txtBranch.Tag = clsSecurity.BranchID;

            prog_ProgressBar.Value = 0;
        }
        #endregion

        #region Print Method
        #region Print method for Data Set
        private void print(string path, string sReportTitle, DataTable objDataTable, string sFilter)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Standed Reports";
                CrystalDecisions.CrystalReports.Engine.ReportDocument objRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(objDataTable); //(glbDtsSales)

                objRpt.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpDateFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpDateTo.Value.ToString("dd MMM yyyy"));
                objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                objRpt.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                if (Report == enum_ReportName.AP_Creditors_Age_anlysis_Detail || Report == enum_ReportName.AP_Supplier_Outstanding_GRN || Report == enum_ReportName.AP_Supplier_Outstanding_PO)
                    objRpt.DataDefinition.FormulaFields["PrintedDate"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToString());

                //if (txtSupplier.Tag != null)
                //    sFilter += "Suplier Name : " + clsGenaralName.getName_Supplier(txtSupplier.Tag.ToString().Trim());


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

        private void print(string path, string sReportTitle, DataSet objDataTable, string sReportID)
        {
            try
            {
                string sHeaderTitle = "Standed Reports";
                string sFilter = "";
                glb_dtsReportExport.Clear();

                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("HeaderTitle", sHeaderTitle, true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle", sReportTitle, true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", clsSecurity.CompanyName, true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", clsSecurity.CompanyAddress1, true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", clsSecurity.CompanyAddress2, true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqName", clsSecurity.DigiteqName, true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqEmail", clsCommon.getCompanyEmail(), true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DateRange", "As At : " + dtpDateTo.Value.ToString("dd MMM yyyy"), true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("UserName", clsSecurity.UserNameLoged, true, false);

                if (Report == enum_ReportName.RG_Supplier_wise_Outstanding_Summary)
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("isSumaryReport", "1", true, false);

                if (cmbCreditorType.SelectedIndex == 1)//Supplier Only
                {
                    if (txtSupplier.Tag != null)
                        sFilter += "Suplier Name : " + clsGenaralName.getName_Supplier(txtSupplier.Tag.ToString().Trim());
                    else
                    {
                        if (rdoLocal.Checked)
                            sFilter += "Creditor Type : - Local Suppliers Only";
                        else if (rdoExport.Checked)
                            sFilter += "Creditor Type : - Export Suppliers Only";
                        else
                            sFilter += "Creditor Type : - Suppliers Only";
                    }
                }
                if (cmbCreditorType.SelectedIndex == 2)//Non Suppliers
                    sFilter += "Creditor Type : - Non Suppliers";

                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Filter", sFilter, true, false);

                frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
                ReportViewer.print(path, objDataTable, glb_dtsReportExport.dt_rptParameter, sReportID);
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
        //private void print(string path, string sReportTitle, DataTable objDataTable)
        //{
        //    try
        //    {
        //        Cursor = Cursors.WaitCursor;
        //        string s_Path = "", sHeaderTitle = "Standed Reports";
        //        string sFilter = "";
        //        CrystalDecisions.CrystalReports.Engine.ReportDocument objRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //        s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
        //        s_Path += path;

        //        objRpt.Load(s_Path);//glbDtsStock
        //        objRpt.SetDataSource(objDataTable); //(glbDtsSales)

        //        objRpt.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
        //        objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
        //        objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
        //        objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
        //        objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
        //        objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
        //        objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
        //        objRpt.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
        //        //objRpt.DataDefinition.FormulaFields["SupplierName"].Text = clsCommon.fncsetstring(txtSupplier.Text.Trim());
        //        objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("As At : " + dtpDateTo.Value.ToString("dd MMM yyyy"));
        //        if (rdoSupplierOutstandingsSummary.Checked)
        //            objRpt.DataDefinition.FormulaFields["isSumaryReport"].Text = clsCommon.fncsetstring("1");

        //        if (cmbCreditorType.SelectedIndex == 1)//Supplier Only
        //        {
        //            if (txtSupplier.Tag != null)
        //                sFilter += "Suplier Name : " + clsGenaralName.getName_Supplier(txtSupplier.Tag.ToString().Trim());
        //            else
        //            {
        //                if (rdoLocal.Checked)
        //                    sFilter += "Creditor Type : - Local Suppliers Only";
        //                else if (rdoExport.Checked)
        //                    sFilter += "Creditor Type : - Export Suppliers Only";
        //                else
        //                    sFilter += "Creditor Type : - Suppliers Only";
        //            }
        //        }
        //        if (cmbCreditorType.SelectedIndex == 2)//Non Suppliers
        //            sFilter += "Creditor Type : - Non Suppliers";

        //        objRpt.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sFilter);

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
        #endregion

        #region KeyDown Events
        private void txtBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_CompanyBranch(ref txtBranch);
        }
        #endregion

        #region Events DoublClick
        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            Search_SuplierID();
        }
        private void txtNoteType_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterStockNoteType(ref txtNoteType);
        }
        private void txtSupClass_DoubleClick(object sender, EventArgs e)
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_SupplierClass();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtSupClass.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtSupClass.Tag = frmSearchMaster.s_SearchID;
        }

        private void txtSupType_DoubleClick(object sender, EventArgs e)
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_SupplierType();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtSupType.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtSupType.Tag = frmSearchMaster.s_SearchID;
        }

        private void txtSupCategory_DoubleClick(object sender, EventArgs e)
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_SupplierCategory();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtSupCategory.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtSupCategory.Tag = frmSearchMaster.s_SearchID;
        }
        private void txtBranch_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_CompanyBranch(ref txtBranch);
        }
        #endregion

        #region Search Methods

        #endregion

        #region Events CheckedChanged

        #endregion

        #region Set Enable/Disable Controls
        private void setEnableDisableConctrol(int iReportID)
        {
            clearField();
            if (iReportID == (int)enum_ReportName.RG_Supplier_wise_Outstanding_Summary || iReportID == (int)enum_ReportName.RG_Supplier_wise_Outstanding_Detail)
            {
                clsCommon.SetVisibility_Panel(pnlSupplier, true);
                clsCommon.SetVisibility_Panel(pnlType, true);
                clsCommon.SetVisibility_Panel(pnlToDate, true);
                clsCommon.SetVisibility_Panel(pnlDBNOutstanding, true);
                clsCommon.SetVisibility_Panel(pnlUseBillDate, true);
                clsCommon.SetVisibility_Panel(pnlCreditorType, true);
                // cmbCreditorType.Show();
            }
            if (iReportID == (int)enum_ReportName.AP_Tax)
            {
                clsCommon.SetVisibility_Panel(pnlSupplier, true);
                clsCommon.SetVisibility_Panel(pnlType, true);
                clsCommon.SetVisibility_Panel(pnlToDate, true);
                clsCommon.SetVisibility_Panel(pnlFromDate, true);
            }
            if (iReportID == (int)enum_ReportName.AP_Supplier_Outstanding_GRN || iReportID == (int)enum_ReportName.AP_Supplier_Outstanding_PO)
            {
                clsCommon.SetVisibility_Panel(pnlSupplier, true);
                clsCommon.SetVisibility_Panel(pnlNoteType, true);
                clsCommon.SetVisibility_Panel(pnlToDate, true);
                clsCommon.SetVisibility_Panel(pnlFromDate, true);
                clsCommon.SetVisibility_Panel(pnlSupClass, true);
                clsCommon.SetVisibility_Panel(pnlSupType, true);
                clsCommon.SetVisibility_Panel(pnlSupCategory, true);
            }
            if (iReportID == (int)enum_ReportName.AP_SupplierJournalTrackingReport)
            {
                clsCommon.SetVisibility_Panel(pnlSupplier, true);
                clsCommon.SetVisibility_Panel(pnlToDate, true);
                clsCommon.SetVisibility_Panel(pnlFromDate, true);
            }
            if (iReportID == (int)enum_ReportName.AP_Creditors_Age_anlysis_Detail || iReportID == (int)enum_ReportName.AP_Creditors_Age_anlysis_Summary)
            {
                clsCommon.SetVisibility_Panel(pnlSupplier, true);
                clsCommon.SetVisibility_Panel(pnlToDate, true);
                clsCommon.SetVisibility_Panel(pnlFromDate, true);
                clsCommon.SetVisibility_Panel(pnlSupClass, true);
                clsCommon.SetVisibility_Panel(pnlSupType, true);
                clsCommon.SetVisibility_Panel(pnlSupCategory, true);
            }
        }
        #endregion

        #region Events CheckedChange
        #region old
        //private void rdoCustomerOutstandingsSummery_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoCustomerOutstandingsDetail_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoCreaditorsAge_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoCreaditorsAgeSummary_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoReceiptSettlementLedger_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}

        //private void rdoTaxReportApn_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //} 
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

        //private void SupplierOutstandingGRN_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}

        private void cmbCreditorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSupplier.Tag = null;
            txtSupplier.Text = "<All Supplier>";

            if (cmbCreditorType.SelectedIndex == 1)
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSupplier, true);
            else if (cmbCreditorType.SelectedIndex == 2)
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSupplier, false);
            else
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSupplier, false);
        }
        #endregion

        #region Search
        private void Search_SuplierID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_SupplierMaster();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtSupplier.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                    txtSupplier.Tag = frmSearchMaster.s_SearchID;
            }
        }
        #endregion

    }
}
