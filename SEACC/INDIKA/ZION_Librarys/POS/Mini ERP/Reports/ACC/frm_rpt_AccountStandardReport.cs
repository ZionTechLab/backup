using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using DataTire;
using System.Collections.Generic;
using System.Linq;
using Digiteq.DataSets;
using Digiteq.Reports.ACC.Common;
using Digiteq.DataSets.ACC;
using System.Data;
using Digiteq_Logic;

namespace Digiteq
{
    public partial class frm_rpt_AccountStandardReport : MettroForm
    {
        #region Variables
        public int iFormID, iReport;
        public bool bNoAccess;

        dts_Accounts glb_dts_Accounts = new dts_Accounts();
        dts_accGeneralLedger glb_dts_GeneralLedger = new dts_accGeneralLedger();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        dts_accBudget glb_dts_accBudget = new dts_accBudget();
        dts_GeneralLedger glb_dtsGeneralLedger = new dts_GeneralLedger();
        #endregion

        #region Form Load
        public frm_rpt_AccountStandardReport()
        {
            iFormID = clsSecurity.getFormID(FormName.ReportAccountStanderd);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
            clearField();
        }

        private void frmReportChequeDeposit_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Account Standard Reports", 2, iFormID);
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
                dgvReports.DataSource = DBHandling.ExecQuery("EXEC sp_Reports '" + 14 + "'").Tables[0];
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvReports.SelectedCells.Count != 0)
            {
                if (dgvReports.Rows.Count > 0)
                {
                    try
                    {
                        int iRow = dgvReports.SelectedCells[0].RowIndex;
                        iReport = int.Parse(dgvReports.Rows[iRow].Cells[0].Value.ToString());
                        enum_ReportName Report = (enum_ReportName)iReport;

                        if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(Report)))
                        {
                            string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                            if (clsHelpMethods.GetReportPath(clsAutocode.getReportID(Report), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                            {
                                string sFilterBy = "";
                                bool bCostCenter1 = false, bAcctCodeSelected = false, bSubAcc2Selected = false, bMainGlCodeSelected = false, bSubGlCodeSelected = false, bAcctCodeTypeCode = false;//bAccProcessNote = false;
                                string sFormula = "";
                                string sDaterange = "From " + dtpFrom.Value.Date.ToString("dd-MMM-yyyy") + " TO " + dtpTo.Value.Date.ToString("dd-MMM-yyyy");

                                #region Filters

                                txtFinYear.Tag = clsMethods_GL.getFinancialYear_ID(dtpFrom.Value);

                                if (txtCostCenter1.Tag != null && txtCostCenter1.Tag.ToString().Trim().Length > 0)
                                {
                                    bCostCenter1 = true;
                                    sFilterBy += (sFilterBy != "" ? " | " : "") + "Sub Account :" + txtCostCenter1.Text;
                                }
                                if (txtSubAcct2.Tag != null && txtSubAcct2.Tag.ToString().Trim().Length > 0)
                                {
                                    bSubAcc2Selected = true;
                                    sFilterBy += (sFilterBy != "" ? " | " : "") + "Sub Account 2:" + txtSubAcct2.Text;
                                }
                                if (txtAcctCode.Tag != null && txtAcctCode.Tag.ToString().Trim().Length > 0)
                                {
                                    bAcctCodeSelected = true;
                                    sFilterBy += (sFilterBy != "" ? " | " : "") + "Account :" + txtAcctCode.Text;
                                }
                                if (txtMainGlCode.Tag != null && txtMainGlCode.Tag.ToString().Trim().Length > 0)
                                {
                                    bMainGlCodeSelected = true;
                                    sFilterBy += (sFilterBy != "" ? " | " : "") + "Main GL :" + txtMainGlCode.Text;
                                }
                                if (txtSubGlCode.Tag != null && txtSubGlCode.Tag.ToString().Trim().Length > 0)
                                {
                                    bSubGlCodeSelected = true;
                                    sFilterBy += (sFilterBy != "" ? " | " : "") + "Sub GL :" + txtSubGlCode.Text;
                                }
                                if (txtAcctCodeTypeCode.Tag != null && txtAcctCodeTypeCode.Tag.ToString().Trim().Length > 0)
                                {
                                    bAcctCodeTypeCode = true;
                                    sFilterBy += (sFilterBy != "" ? " | " : "") + "Account Type :" + txtAcctCodeTypeCode.Text;
                                }
                                #endregion

                                glb_dts_Accounts.Clear();

                                #region Trial Balance
                                if (Report == enum_ReportName.ST_ACC_Trail_Balance || Report == enum_ReportName.ST_ACC_Trail_Balance_Advance)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dtsGeneralLedger.Clear();

                                        glb_dtsGeneralLedger.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilterBy);

                                        #region Fill Dataset
                                        string sQuary = "select * from func_AccountTrialBalance( '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "','" + dtpTo.Value.ToString("yyyy-MM-dd") + "','" + txtFinYear.Tag.ToString() + "','" + clsMethods_GL.accountTXNStartMonth() + "')";

                                        if (bAcctCodeTypeCode)
                                            sQuary += " where glAccountType1_ID ='" + txtAcctCodeTypeCode.Tag.ToString() + "'";

                                        glb_dtsGeneralLedger.dt_acc_TrailBalance.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);
                                        #endregion

                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ShowZeros", (chk_HideZeroAmount.Checked ? "0" : "1"), true, false);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dtsGeneralLedger, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        ProgressBar.Value = 0;
                                        glb_dtsGeneralLedger.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region General Ledger
                                else if (Report == enum_ReportName.RG_General_Ledger)
                                {
                                    try
                                    {
                                      

                                        Cursor = Cursors.WaitCursor;
                                        glb_dtsGeneralLedger.Clear();

                                        glb_dtsGeneralLedger.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilterBy);

                                        // dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();

                                        #region Fill Dataset
                                        string sAccType = "'" + (bMainGlCodeSelected ? txtMainGlCode.Tag.ToString() : "%") + "'";
                                        string sAccSubType = "'" + (bSubGlCodeSelected ? txtSubGlCode.Tag.ToString() : "%") + "'";
                                        string sAcc = "'" + (bAcctCodeTypeCode ? txtAcctCodeTypeCode.Tag.ToString() : "%") + "'";
                                        string sSubAcc = "'" + (bAcctCodeSelected ? txtAcctCode.Tag.ToString() : "%") + "'";

                                        string sQuary = "exec [sp_RPT_OpeningBalance] '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "','" + dtpTo.Value.ToString("yyyy-MM-dd") + "','" + txtFinYear.Tag.ToString() + "','" + clsMethods_GL.accountTXNStartMonth() + "'," + sAccType + "," + sAccSubType + "," + sAcc + "," + sSubAcc;
                                        glb_dtsGeneralLedger.dt_acc_AccountHierarchy.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);
                                        string sQuary2 = "exec [sp_RPT_GeneralLedger] '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "','" + dtpTo.Value.ToString("yyyy-MM-dd") + "','" + txtFinYear.Tag.ToString() + "','" + clsMethods_GL.accountTXNStartMonth() + "'," + sAccType + "," + sAccSubType + "," + sAcc + "," + sSubAcc;
                                        glb_dtsGeneralLedger.dt_acc_GeneralLedger.Merge(DBHandling.ExecQuery(sQuary2).Tables[0]);
                                        #endregion

                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ShowZeros", (chk_HideZeroAmount.Checked ? "0" : "1"), true, false);
                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dtsGeneralLedger, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        ProgressBar.Value = 0;
                                        glb_dtsGeneralLedger.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Sub Ledger Debter
                                else if (Report == enum_ReportName.RG_SubLedger_Debtors)
                                {
                                    if (rdoSummary.Checked)
                                        Report = enum_ReportName.RG_SubLedger_Debtors_Summary;

                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dtsGeneralLedger.Clear();

                                        if (txtAcctCode.Tag != null)
                                        {
                                            glb_dtsGeneralLedger.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilterBy);

                                            dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();
                                            //  DateTime dtFinYearEndDate = clsMethods_GL.getFinancialYear_StartDate(txtFinYear.Tag.ToString());

                                            string sQuary = "exec [sp_RPT_OpeningBalance_Debtor] '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "','" + dtpTo.Value.ToString("yyyy-MM-dd") + "','" + txtFinYear.Tag.ToString() + "','" + txtAcctCode.Tag.ToString() + "'";
                                            glb_dtsGeneralLedger.dt_accCusSup_Acc.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);
                                            string sQuary2 = "exec [sp_RPT_GeneralLedger] '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "','" + dtpTo.Value.ToString("yyyy-MM-dd") + "','" + txtFinYear.Tag.ToString() + "','" + clsMethods_GL.accountTXNStartMonth() + "','%','%','" + "%" + "','" + txtAcctCode.Tag.ToString() + "'";
                                            glb_dtsGeneralLedger.dt_acc_GeneralLedger.Merge(DBHandling.ExecQuery(sQuary2).Tables[0]);
                                            frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                            rpt.print(sReportPath, glb_dtsGeneralLedger, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                        }
                                        else
                                            MessageBox.Show("Please Select Account Code", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        ProgressBar.Value = 0;
                                        glb_dtsGeneralLedger.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Sub Ledger Creditor
                                else if (Report == enum_ReportName.RG_SubLedger_Creditors)
                                {
                                    if (rdoSummary.Checked)
                                        Report = enum_ReportName.RG_SubLedger_Creditors_Summary;

                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dtsGeneralLedger.Clear();

                                        if (txtAcctCode.Tag != null)
                                        {
                                            glb_dtsGeneralLedger.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilterBy);

                                            dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();

                                            string sQuary = "exec [sp_RPT_OpeningBalance_Creditors] '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "','" + dtpTo.Value.ToString("yyyy-MM-dd") + "','" + txtFinYear.Tag.ToString() + "','" + txtAcctCode.Tag.ToString() + "'";
                                            glb_dtsGeneralLedger.dt_accCusSup_Acc.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);
                                            string sQuary2 = "exec [sp_RPT_GeneralLedger] '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "','" + dtpTo.Value.ToString("yyyy-MM-dd") + "','" + txtFinYear.Tag.ToString() + "','" + clsMethods_GL.accountTXNStartMonth() + "','%','%','" + "%" + "','" + txtAcctCode.Tag.ToString() + "'";
                                            glb_dtsGeneralLedger.dt_acc_GeneralLedger.Merge(DBHandling.ExecQuery(sQuary2).Tables[0]);
                                            frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                            rpt.print(sReportPath, glb_dtsGeneralLedger, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                        }
                                        else
                                            MessageBox.Show("Please Select Account Code", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        ProgressBar.Value = 0;
                                        glb_dtsGeneralLedger.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region PNL
                                else if (Report == enum_ReportName.ST_Acc_ProfitAndLoss_Std)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dtsGeneralLedger.Clear();

                                        glb_dtsGeneralLedger.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilterBy);

                                        dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();
                                        string sAccount_ID = "'" + (bAcctCodeTypeCode ? txtAcctCodeTypeCode.Tag.ToString() : "%") + "'";

                                        string sQuary = "select * from func_RPT_ProfitAndLoss_Std( '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "','" + dtpTo.Value.ToString("yyyy-MM-dd") + "','" + txtFinYear.Tag.ToString() + "','" + clsMethods_GL.accountTXNStartMonth() + "') WHERE isPNLAccount=1  ";
                                        glb_dtsGeneralLedger.dt_acc_TrailBalance.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CurrentFinYear", clsMethods_GL.getFinancialYear_ID(dtpFrom.Value), true, false);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("PreviusFinYear", clsMethods_GL.getFinancialYear_ID(dtpFrom.Value.AddYears(-1)), true, false);
                                        rpt.print(sReportPath, glb_dtsGeneralLedger, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        ProgressBar.Value = 0;
                                        glb_dtsGeneralLedger.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }

                                else if (Report == enum_ReportName.ST_Acc_ProfitAndLoss_Cus)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dts_Accounts.Clear();

                                        glb_dts_Accounts.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilterBy);

                                        List<PNL> oPNL = new List<PNL>();

                                        string sQuary = "exec [sp_RPT_ProfitAndLoss] '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "','" + dtpTo.Value.ToString("yyyy-MM-dd") + "'";
                                        DataTable table = DBHandling.ExecQuery(sQuary).Tables[0];

                                        decimal dTotal = 0, dTotal_Prev = 0;
                                        foreach (tbl_accGLMaster_PNL oNote in tbl_accGLMaster_PNL.SelectAll().OrderBy(p => p.Pnl_LineNo))
                                        {
                                            if (oNote.IsTotal)
                                            {
                                                glb_dts_Accounts.dt_acc_TrailBalance.Adddt_acc_TrailBalanceRow("", "", 0, "", oNote.GlSubCatagory_Name, oNote.Pnl_LineNo, "", "", 0, "", "T", 0, 0, 0, false, dTotal, dTotal_Prev, 0);
                                            }
                                            else if (!oNote.IsAddition)
                                            {
                                                DataRow[] rows = table.Select("glSubCatagory_ID = '" + oNote.GlSubCatagory_ID + "'");
                                                if (rows.Length > 0)
                                                {
                                                    decimal dAmount = decimal.Parse(rows[0]["Amount"].ToString());
                                                    decimal dAmount_Prev = decimal.Parse(rows[0]["Amount_Prev"].ToString());
                                                    int iNote = int.Parse(rows[0]["note"].ToString());
                                                    dTotal += dAmount;
                                                    dTotal_Prev += dAmount_Prev;
                                                    glb_dts_Accounts.dt_acc_TrailBalance.Adddt_acc_TrailBalanceRow("", "", 0, "", oNote.GlSubCatagory_Name, oNote.Pnl_LineNo, "", "", 0, "", "", 0, 0, 0, false, dAmount, dAmount_Prev, iNote);
                                                }
                                            }
                                            else
                                            {
                                                //This method has not implemented properly

                                                //decimal dAmount1 = 0, dAmount2 = 0;

                                                //DataRow[] rows = table.Select("glSubCatagory_ID = " + oNote.GlSubCatagory_ID);
                                                //dAmount1 = decimal.Parse(rows[0]["Amount"].ToString());

                                                //DataRow[] rows2 = table.Select("glSubCatagory_ID = " + oNote.GlSubCatagory_ID);
                                                //dAmount2 = decimal.Parse(rows2[0]["Amount"].ToString());

                                                //dAmount1 += (oNote.IsAddition ? 1 : -1) * dAmount2;
                                                //dTotal += dAmount1;
                                                //glb_dts_Accounts.dt_acc_TrailBalance.Adddt_acc_TrailBalanceRow("", "", 0, "", oNote.GlSubCatagory_Name, oNote.Pnl_LineNo, "", "", 0, "", "", 0, 0, 0, false, dAmount1, 0, 0);
                                            }
                                        }

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CurrentFinYear", clsMethods_GL.getFinancialYear_ID(dtpFrom.Value), true, false);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("PreviusFinYear", clsMethods_GL.getFinancialYear_ID(dtpFrom.Value.AddYears(-1)), true, false);
                                        rpt.print(sReportPath, glb_dts_Accounts, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                    finally
                                    {
                                        ProgressBar.Value = 0;
                                        glb_dts_Accounts.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Balance Sheet
                                else if (Report == enum_ReportName.ST_Acc_BalanceSheet)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dts_Accounts.dt_acc_TrailBalance.Rows.Clear();

                                        dts_GeneralLedger glb_dts_GeneralLedger = new dts_GeneralLedger();
                                        glb_dts_GeneralLedger.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", "", clsSecurity.UserNameLoged, "AS AT " + dtpTo.Value.ToString("yyyy-MMM-dd"));

                                        dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();
                                        //dtpFrom.Value.ToString("yyyy-MM-dd") + "','" +
                                        string sQuary = "exec [sp_RPT_BalanceSheet] '" + dtpTo.Value.ToString("yyyy-MM-dd") + "','" + txtFinYear.Tag.ToString() + "','" + clsMethods_GL.accountTXNStartMonth() + "'";

                                        glb_dts_GeneralLedger.dt_acc_TrailBalance.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CurrentFinYear", clsMethods_GL.getFinancialYear_ID(dtpFrom.Value), true, false);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("PreviusFinYear", clsMethods_GL.getFinancialYear_ID(dtpFrom.Value.AddYears(-1)), true, false);

                                        rpt.print(sReportPath, glb_dts_GeneralLedger, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        ProgressBar.Value = 0;
                                        glb_dts_Accounts.dt_acc_TrailBalance.Rows.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Accounts Notes
                                else if (Report == enum_ReportName.ST_Acc_Notes)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dtsGeneralLedger.Clear();

                                        glb_dtsGeneralLedger.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilterBy);

                                        int iNoteFrom = 0;
                                        int iNoteTO = 10000;

                                        if (txtAccNoteFrom.Text != "")
                                            iNoteFrom = int.Parse(txtAccNoteFrom.Text);
                                        if (txtAccNoteTo.Text != "")
                                            iNoteTO = int.Parse(txtAccNoteTo.Text);

                                        dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();
                                        string sQuary = "exec [sp_RPT_Notes] '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "','" + dtpTo.Value.ToString("yyyy-MM-dd") + "','" + txtFinYear.Tag.ToString() + "','" + clsMethods_GL.accountTXNStartMonth() + "'," + iNoteFrom.ToString() + "," + iNoteTO.ToString();

                                        glb_dtsGeneralLedger.dt_acc_TrailBalance.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dtsGeneralLedger, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        ProgressBar.Value = 0;
                                        glb_dtsGeneralLedger.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Account Openning Balance
                                else if (Report == enum_ReportName.ST_AccountOpeningBalance)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dtsGeneralLedger.Clear();

                                        glb_dtsGeneralLedger.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, "For The Financial Year - " + txtFinYear.Tag.ToString(), clsSecurity.UserNameLoged, sFilterBy);

                                        dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();

                                        string sAccount_ID = bAcctCodeTypeCode ? txtAcctCodeTypeCode.Tag.ToString() : "%";
                                        DateTime dtmLastDay_previusFY = clsMethods_GL.getFinancialYear_StartDate(txtFinYear.Tag.ToString()).AddDays(-1);
                                        string sLastFYID = clsMethods_GL.getFinancialYear_ID(dtmLastDay_previusFY);

                                        // string sQuary = "exec [sp_RPT_TrialBalance] '" + dtmLastDay_previusFY.ToString("yyyy-MM-dd") + "','" + dtmLastDay_previusFY.ToString("yyyy-MM-dd") + "','" + sLastFYID + "','" + clsMethods_Fin.accountTXNStartMonth() + "'," + sAccount_ID;

                                        string sQuary = "select * from func_AccountTrialBalance( '" + dtmLastDay_previusFY.ToString("yyyy-MM-dd") + "','" + dtmLastDay_previusFY.ToString("yyyy-MM-dd") + "','" + sLastFYID + "','" + clsMethods_GL.accountTXNStartMonth() + "')";

                                        if (bAcctCodeTypeCode)
                                            sQuary += " where glAccountType1_ID ='" + sAccount_ID + "'";


                                        glb_dtsGeneralLedger.dt_acc_TrailBalance.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dtsGeneralLedger, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        ProgressBar.Value = 0;
                                        glb_dtsGeneralLedger.Clear();
                                        Cursor = Cursors.Default;
                                    }

                                    #region Commented
                                    //try
                                    //{
                                    //    Cursor = Cursors.WaitCursor;
                                    //    glb_dts_Accounts.dt_acc_AccountCodeOpenningBalance.Clear();

                                    //    if (txtFinYear.Tag != null && txtFinYear.Tag.ToString().Length > 0)
                                    //    {
                                    //        if (cmbMonth.Text.Length > 0)
                                    //        {
                                    //            List<tbl_accGLMaster> glMasters = tbl_accGLMaster.SelectAll().Where(p => p.Gl_ID != "default").ToList();
                                    //            foreach (tbl_accGLMaster glMaster in glMasters)
                                    //            {
                                    //                bool isCredit = false;
                                    //                decimal dAmount = 0;
                                    //                tbl_accFinancialYearMaster_Month_OpenningBalance findetail = tbl_accFinancialYearMaster_Month_OpenningBalance.Select(glMaster.Gl_ID, txtFinYear.Tag.ToString(), cmbMonth.Text);
                                    //                if (findetail != null)
                                    //                {

                                    //                    if (findetail.IsCreditOpening)
                                    //                    {
                                    //                        dAmount = findetail.OpeningBalance;
                                    //                        isCredit = true;
                                    //                    }
                                    //                    else
                                    //                    {
                                    //                        dAmount = findetail.OpeningBalance;
                                    //                        isCredit = false;

                                    //                    }
                                    //                }

                                    //                if (dAmount > 0)
                                    //                    glb_dts_Accounts.dt_acc_AccountCodeOpenningBalance.Adddt_acc_AccountCodeOpenningBalanceRow(glMaster.Gl_ID, clsGenaralName.getName_AccountName(glMaster.Gl_ID), dAmount, isCredit);
                                    //                clsHelpMethods.startProgressBar(0, glMasters.Count + 2, 1, ProgressBar);

                                    //            }
                                    //            print("\\reports\\ACC\\rpt_accAccountCodeOpenningBalance.rpt", "Account Code Openning Balance", glb_dts_Accounts.dt_acc_AccountCodeOpenningBalance);
                                    //        }
                                    //        else
                                    //            MessageBox.Show("Please Select The Month Before Get The Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //    }
                                    //    else
                                    //        MessageBox.Show("Please Select The Financial Year Before Get The Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    //}
                                    //catch (Exception ex)
                                    //{
                                    //    SEACCException.Show(ex);
                                    //}
                                    //finally
                                    //{
                                    //    ProgressBar.Value = 0;
                                    //    Cursor = Cursors.Default;
                                    //    glb_dts_Accounts.dt_acc_AccountCodeOpenningBalance.Clear();
                                    //} 
                                    #endregion
                                }
                                #endregion

                                #region Bank Book Summary
                                else if (Report == enum_ReportName.ST_BankBook)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dts_Accounts.Clear();
                                        decimal dAmount = 0;

                                        List<tbl_accGLMaster> oGLMasters = tbl_accGLMaster.SelectAll().Where(p => !p.IsDeleted).ToList();
                                        foreach (tbl_accGLMaster oGLMaster in oGLMasters)
                                        {
                                            if (oGLMaster.ControlAcc_Type == clsAutocode.getControlAccount_Types(enum_ControlAccountType.Cash) ||
                                                oGLMaster.ControlAcc_Type == clsAutocode.getControlAccount_Types(enum_ControlAccountType.Bank))
                                            {
                                                dAmount = 0;
                                                bool bIsCredit = false;
                                                //Openning balance
                                                tbl_accFinancialYearMaster_Month_OpenningBalance opBalanceDetail = tbl_accFinancialYearMaster_Month_OpenningBalance.Select(oGLMaster.Gl_ID, txtFinYear.Tag.ToString(), clsMethods_GL.accountTXNStartMonth());
                                                if (opBalanceDetail != null && opBalanceDetail.OpeningBalance > 0)
                                                    dAmount += opBalanceDetail.IsCreditOpening ? opBalanceDetail.OpeningBalance : (opBalanceDetail.OpeningBalance * -1);

                                                //Transaction
                                                foreach (tbl_accGLPosting_Detail oPosting in tbl_accGLPosting_Detail.SelectAllByGl_ID(oGLMaster.Gl_ID).Where(p => p.TransactionDate.Date >= dtpFrom.Value.Date && p.TransactionDate.Date <= dtpTo.Value.Date && !p.IsCanceled))
                                                {
                                                    if (oPosting.Amount != 0)
                                                        dAmount += oPosting.IsCredit ? oPosting.Amount : (oPosting.Amount * -1);
                                                }
                                                // bIsCredit = (dAmount == 0) ? oGLMaster.IsCredit : (dAmount > 0) ? true : false;
                                                dAmount = (dAmount < 0) ? (dAmount * -1) : dAmount;

                                                string sAccountName = clsGenaralName.getName_GlAccountType1(oGLMaster.GlAccountType_ID);

                                                //Fill DataTable
                                                glb_dts_Accounts.dt_acc_BankBook.Adddt_acc_BankBookRow(oGLMaster.GlAccountType_ID, sAccountName, oGLMaster.Gl_ID, oGLMaster.GlName, dAmount, bIsCredit);
                                            }
                                            clsHelpMethods.startProgressBar(0, oGLMasters.Count + 2, 1, ProgressBar);
                                        }
                                        glb_dts_Accounts.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", "", clsSecurity.UserNameLoged, "");

                                        //print1("\\Reports\\ACC\\rpt_accBankBookSummary.rpt", "Cash/Bank Balances", glb_dts_Accounts.dt_acc_BankBook, "");
                                        //print1(sReportPath, sReportTitle_Main, glb_dts_Accounts.dt_acc_BankBook, "");

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dts_Accounts, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception)
                                    {
                                    }
                                    finally
                                    {
                                        ProgressBar.Value = 0;
                                        glb_dts_Accounts.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Cash & Bank Book Detail New
                                else if (Report == enum_ReportName.ST_CashBankDetailBook)
                                {
                                    try
                                    {
                                        #region new
                                        if (true)
                                        {
                                            Cursor = Cursors.WaitCursor;
                                            glb_dts_Accounts.dts_acc_CashBook_GL.Rows.Clear();

                                            List<tbl_accGLMaster> oAccMasters;
                                            if (bAcctCodeSelected)
                                            {
                                                oAccMasters = new List<tbl_accGLMaster>();
                                                oAccMasters.Add(tbl_accGLMaster.Select(txtAcctCode.Tag.ToString()));
                                            }
                                            else
                                                oAccMasters = tbl_accGLMaster.SelectAll().Where(p => !p.IsDeleted && (p.ControlAcc_Type == clsAutocode.getControlAccount_Types(enum_ControlAccountType.Cash) || p.ControlAcc_Type == clsAutocode.getControlAccount_Types(enum_ControlAccountType.Bank))).ToList();

                                            foreach (tbl_accGLMaster oAccount in oAccMasters)
                                            {
                                                if (oAccount.Gl_ID != "default")
                                                {
                                                    #region Variables
                                                    bool isCloseingCredit = false;
                                                    string sYearID = "", sAccountType = "";
                                                    decimal dDebitAmount = 0, dCreditAmount = 0, dBalace = 0, dClosingCreditAmount = 0, dClosingDebitAmount = 0, dOpanningCreditAmount = 0, dOpanningDebitAmount = 0
                                                           , dInsertOpanningCreditAmount = 0, dInsertOpanningDebiteAmount = 0, dUnPostedDebitAmount = 0, dUnPostedCreditAmount = 0, dOpanningUnPostedCreditAmount = 0,
                                                           dOpanningUnPostedDebitAmount = 0, dClosingUnPostedCreditAmount = 0, dClosingUnPostedDebitAmount = 0;
                                                    #endregion

                                                    #region Get user insert Opanning Balance Amount
                                                    tbl_accFinancialYearMaster_Month_OpenningBalance opBalanceDetail = tbl_accFinancialYearMaster_Month_OpenningBalance.Select(oAccount.Gl_ID, txtFinYear.Tag.ToString(), clsMethods_GL.accountTXNStartMonth());
                                                    if (opBalanceDetail != null)
                                                    {
                                                        if (opBalanceDetail.IsCreditOpening)
                                                            dInsertOpanningCreditAmount = opBalanceDetail.OpeningBalance;
                                                        else
                                                            dInsertOpanningDebiteAmount = opBalanceDetail.OpeningBalance;
                                                    }
                                                    #endregion

                                                    #region Get Opanning Balance
                                                    dOpanningUnPostedCreditAmount = 0;
                                                    dUnPostedCreditAmount = 0;
                                                    dOpanningUnPostedDebitAmount = 0;
                                                    dUnPostedDebitAmount = 0;

                                                    #region Posted
                                                    DateTime dtFinancialYearStartDate = clsMethods_GL.getFinancialYear_StartDate(txtFinYear.Tag.ToString());
                                                    foreach (tbl_accGLPosting_Detail GLpostingDetail in tbl_accGLPosting_Detail.SelectAllByGl_ID(oAccount.Gl_ID).Where(p => dtpFrom.Value.Date > p.TransactionDate.Date && p.TransactionDate.Date >= dtFinancialYearStartDate.Date))
                                                    {
                                                        if (GLpostingDetail.IsCredit)
                                                        {
                                                            dOpanningCreditAmount = dOpanningCreditAmount + GLpostingDetail.Amount;
                                                            dCreditAmount = dCreditAmount + GLpostingDetail.Amount;
                                                        }
                                                        else
                                                        {
                                                            dOpanningDebitAmount = dOpanningDebitAmount + GLpostingDetail.Amount;
                                                            dDebitAmount = dDebitAmount + GLpostingDetail.Amount;
                                                        }
                                                    }

                                                    dBalace = (dOpanningCreditAmount - dOpanningDebitAmount) + (dInsertOpanningCreditAmount - dInsertOpanningDebiteAmount);
                                                    #endregion

                                                    #region non posted


                                                    //Receipt Cheque
                                                    //foreach (tbl_bpsChequeRegister obpsChequeRegDetail in tbl_bpsChequeRegister.SelectAll())
                                                    foreach (tbl_bpsChequeRegister obpsChequeRegDetail in tbl_bpsChequeRegister.SelectAll().Where(p => p.IsReconcilied && dtpFrom.Value.Date > p.DateReconcilied.Date && p.DateReconcilied.Date >= dtFinancialYearStartDate.Date))
                                                    {
                                                        //if (obpsChequeRegDetail.IsReconcilied && dtpFrom.Value.Date > obpsChequeRegDetail.DateReconcilied.Date && obpsChequeRegDetail.DateReconcilied.Date >= dtFinancialYearStartDate.Date)                
                                                        if (obpsChequeRegDetail.PostingStatus_ID2 == clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted))
                                                        {
                                                            if (oAccount.Gl_ID == clsMethods_GL.getAccountCode_Bank(obpsChequeRegDetail.DepositedAccountNumber))
                                                            {
                                                                dOpanningDebitAmount += obpsChequeRegDetail.Amount;
                                                                dDebitAmount += obpsChequeRegDetail.Amount;
                                                            }
                                                        }
                                                        else if (obpsChequeRegDetail.PostingStatus_ID2 == clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction))
                                                        {
                                                            if (oAccount.Gl_ID == clsMethods_GL.getAccountCode_Bank(obpsChequeRegDetail.DepositedAccountNumber))
                                                            {
                                                                dOpanningUnPostedDebitAmount += obpsChequeRegDetail.Amount;
                                                                dUnPostedDebitAmount += obpsChequeRegDetail.Amount;
                                                            }
                                                        }

                                                    }

                                                    //Receipt Cash
                                                    foreach (tbl_bpsReceipt obpsReceipt in tbl_bpsReceipt.SelectAll().Where(p => !p.IsDeleted && p.IsCashDeposited && dtpFrom.Value.Date > p.ReceiptDate.Date && p.ReceiptDate.Date >= dtFinancialYearStartDate.Date))
                                                    {
                                                        if (obpsReceipt.CashAmount > 0)
                                                        {
                                                            string sCashDepostiedAcountNum = "";
                                                            foreach (tbl_bpsCashDeposit_Detail obpsCashDepositDetail in tbl_bpsCashDeposit_Detail.SelectAllByReceipt_ID(obpsReceipt.Receipt_ID))
                                                            {
                                                                tbl_bpsCashDeposit obpsCashDeposit = tbl_bpsCashDeposit.Select(obpsCashDepositDetail.CashDeposit_ID);
                                                                if (obpsCashDeposit != null)
                                                                {
                                                                    sCashDepostiedAcountNum = obpsCashDeposit.AccountNumber;
                                                                }
                                                            }
                                                            if (obpsReceipt.PostingStatus_ID2 == clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted))
                                                            {
                                                                if (oAccount.Gl_ID == clsMethods_GL.getAccountCode_Bank(sCashDepostiedAcountNum))
                                                                {
                                                                    dOpanningDebitAmount += obpsReceipt.CashAmount;
                                                                    dDebitAmount += obpsReceipt.CashAmount;
                                                                }
                                                            }
                                                            else if (obpsReceipt.PostingStatus_ID2 == clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction))
                                                            {
                                                                if (oAccount.Gl_ID == clsMethods_GL.getAccountCode_Bank(sCashDepostiedAcountNum))
                                                                {
                                                                    dOpanningUnPostedDebitAmount += obpsReceipt.CashAmount;
                                                                    dUnPostedDebitAmount += obpsReceipt.CashAmount;
                                                                }
                                                            }
                                                        }
                                                    }

                                                    dBalace = (dOpanningUnPostedCreditAmount - dOpanningUnPostedDebitAmount) + (dOpanningCreditAmount - dOpanningDebitAmount) + (dInsertOpanningCreditAmount - dInsertOpanningDebiteAmount);

                                                    #endregion

                                                    #region Adddts_acc_GLRow
                                                    glb_dts_Accounts.dts_acc_CashBook_GL.Adddts_acc_CashBook_GLRow(sYearID, "", oAccount.Gl_ID, (dDebitAmount + dInsertOpanningDebiteAmount) - (dCreditAmount + dInsertOpanningCreditAmount), 0, "Opening Balance", "", true,
                                                        clsGenaralName.getName_AccountName(oAccount.Gl_ID), dBalace, dtpFrom.Value, clsGenaralName.getName_GLMainCatagory(clsGenaralName.getID_GLMainCatagoryBySubGLID(oAccount.Gl_ID)),
                                                        sAccountType, false, true, "", "", 0, dUnPostedDebitAmount - dUnPostedCreditAmount, "A", " - ");
                                                    #endregion
                                                    #region Get Opanning Balance
                                                    //DateTime dtFinancialYearStartDate = clsMethods_Fin.getFinancialYearStartDate_ByFinancialYearID(sFinancialYearID);

                                                    //foreach (tbl_accGLPosting_Detail GLpostingDetail in tbl_accGLPosting_Detail.SelectAllByGl_ID(oAccount.Gl_ID))
                                                    //{
                                                    //    if (GLpostingDetail.Slot_ID.ToString() == clsAutocode.getAccSlotID(AccSlot.PaymetVoucher).ToString())
                                                    //    {
                                                    //        tbl_accPaymentVoucher oPV = tbl_accPaymentVoucher.Select(GLpostingDetail.Transaction_ID);
                                                    //        if (oPV != null)
                                                    //        {
                                                    //            if (oPV.CashAmount > 0 && dtpFrom.Value.Date > oPV.PaymentVoucherDate.Date && oPV.PaymentVoucherDate.Date >= dtFinancialYearStartDate.Date)
                                                    //            {
                                                    //                if (GLpostingDetail.IsCredit)
                                                    //                {
                                                    //                    dOpanningCreditAmount += GLpostingDetail.Amount;
                                                    //                    dCreditAmount += GLpostingDetail.Amount;
                                                    //                }
                                                    //                else
                                                    //                {
                                                    //                    dOpanningDebitAmount += GLpostingDetail.Amount;
                                                    //                    dDebitAmount += GLpostingDetail.Amount;
                                                    //                }
                                                    //            }
                                                    //            else if (oPV.ChequeAmount > 0)
                                                    //            {
                                                    //                foreach (tbl_accChequeRegister oChequeReg in tbl_accChequeRegister.SelectAllByPaymentVoucher_ID(GLpostingDetail.Transaction_ID))
                                                    //                {
                                                    //                    if (oChequeReg.IsReconcilied && dtpFrom.Value.Date > oChequeReg.ReconcilationDate.Date && oChequeReg.ReconcilationDate.Date >= dtFinancialYearStartDate.Date)
                                                    //                    {
                                                    //                        if (GLpostingDetail.IsCredit)
                                                    //                        {
                                                    //                            dOpanningCreditAmount += GLpostingDetail.Amount;
                                                    //                            dCreditAmount += GLpostingDetail.Amount;
                                                    //                        }
                                                    //                        else
                                                    //                        {
                                                    //                            dOpanningDebitAmount += GLpostingDetail.Amount;
                                                    //                            dDebitAmount += GLpostingDetail.Amount;
                                                    //                        }
                                                    //                    }
                                                    //                }
                                                    //            }
                                                    //        }
                                                    //    }
                                                    //    else if (GLpostingDetail.Slot_ID.ToString() == clsAutocode.getAccSlotID(AccSlot.AccountReceipt).ToString())
                                                    //    {
                                                    //        tbl_accAccountReceipt oAR = tbl_accAccountReceipt.Select(GLpostingDetail.Transaction_ID);
                                                    //        if (oAR != null)
                                                    //        {
                                                    //            if (oAR.CashAmount > 0 && dtpFrom.Value.Date > oAR.AccountReceiptDate.Date && oAR.AccountReceiptDate.Date >= dtFinancialYearStartDate.Date)
                                                    //            {
                                                    //                if (GLpostingDetail.IsCredit)
                                                    //                {
                                                    //                    dOpanningCreditAmount += GLpostingDetail.Amount;
                                                    //                    dCreditAmount += GLpostingDetail.Amount;
                                                    //                }
                                                    //                else
                                                    //                {
                                                    //                    dOpanningDebitAmount += GLpostingDetail.Amount;
                                                    //                    dDebitAmount += GLpostingDetail.Amount;
                                                    //                }
                                                    //            }
                                                    //            else if (oAR.ChequeAmount > 0)
                                                    //            {
                                                    //                foreach (tbl_bpsChequeRegister oChequeReg in tbl_bpsChequeRegister.SelectAllByAccountReceipt_ID(GLpostingDetail.Transaction_ID))
                                                    //                {
                                                    //                    if (oChequeReg.IsReconcilied && dtpFrom.Value.Date > oChequeReg.DateReconcilied.Date && oChequeReg.DateReconcilied.Date >= dtFinancialYearStartDate.Date)
                                                    //                    {
                                                    //                        if (GLpostingDetail.IsCredit)
                                                    //                        {
                                                    //                            dOpanningCreditAmount += GLpostingDetail.Amount;
                                                    //                            dCreditAmount += GLpostingDetail.Amount;
                                                    //                        }
                                                    //                        else
                                                    //                        {
                                                    //                            dOpanningDebitAmount += GLpostingDetail.Amount;
                                                    //                            dDebitAmount += GLpostingDetail.Amount;
                                                    //                        }
                                                    //                    }
                                                    //                }
                                                    //            }
                                                    //        }
                                                    //    }
                                                    //    else if (GLpostingDetail.Slot_ID.ToString() == clsAutocode.getAccSlotID(AccSlot.JournalVoucher).ToString())
                                                    //    {
                                                    //        if (dtpFrom.Value.Date > GLpostingDetail.TransactionDate.Date && GLpostingDetail.TransactionDate.Date >= dtFinancialYearStartDate.Date)
                                                    //        {
                                                    //            if (GLpostingDetail.IsCredit)
                                                    //            {
                                                    //                dOpanningCreditAmount += GLpostingDetail.Amount;
                                                    //                dCreditAmount += GLpostingDetail.Amount;
                                                    //            }
                                                    //            else
                                                    //            {
                                                    //                dOpanningDebitAmount += GLpostingDetail.Amount;
                                                    //                dDebitAmount += GLpostingDetail.Amount;
                                                    //            }
                                                    //        }
                                                    //    }
                                                    //    else if (GLpostingDetail.Slot_ID.ToString() == clsAutocode.getAccSlotID(AccSlot.StandardJournalEntries).ToString())
                                                    //    {
                                                    //        if (dtpFrom.Value.Date > GLpostingDetail.TransactionDate.Date && GLpostingDetail.TransactionDate.Date >= dtFinancialYearStartDate.Date)
                                                    //        {
                                                    //            if (GLpostingDetail.IsCredit)
                                                    //            {
                                                    //                dOpanningCreditAmount += GLpostingDetail.Amount;
                                                    //                dCreditAmount += GLpostingDetail.Amount;
                                                    //            }
                                                    //            else
                                                    //            {
                                                    //                dOpanningDebitAmount += GLpostingDetail.Amount;
                                                    //                dDebitAmount += GLpostingDetail.Amount;
                                                    //            }
                                                    //        }
                                                    //    }
                                                    //    else if (GLpostingDetail.Slot_ID.ToString() == clsAutocode.getAccSlotID(AccSlot.BankAdjustmentEntries).ToString())
                                                    //    {
                                                    //        if (dtpFrom.Value.Date > GLpostingDetail.TransactionDate.Date && GLpostingDetail.TransactionDate.Date >= dtFinancialYearStartDate.Date)
                                                    //        {
                                                    //            if (GLpostingDetail.IsCredit)
                                                    //            {
                                                    //                dOpanningCreditAmount += GLpostingDetail.Amount;
                                                    //                dCreditAmount += GLpostingDetail.Amount;
                                                    //            }
                                                    //            else
                                                    //            {
                                                    //                dOpanningDebitAmount += GLpostingDetail.Amount;
                                                    //                dDebitAmount += GLpostingDetail.Amount;
                                                    //            }
                                                    //        }
                                                    //    }
                                                    //}

                                                    //foreach (tbl_accGLPosting_Detail_Tmp GLpostingDetailTemp in tbl_accGLPosting_Detail_Tmp.SelectAllByGl_ID(oAccount.Gl_ID))
                                                    //{
                                                    //    // Unposting Payment Voucher
                                                    //    if (GLpostingDetailTemp.Slot_ID.ToString() == clsAutocode.getAccSlotID(AccSlot.PaymetVoucher).ToString())
                                                    //    {
                                                    //        tbl_accPaymentVoucher oPV = tbl_accPaymentVoucher.Select(GLpostingDetailTemp.Transaction_ID);
                                                    //        if (oPV != null)
                                                    //        {
                                                    //            if (oPV.CashAmount > 0 && dtpFrom.Value.Date > oPV.PaymentVoucherDate.Date && oPV.PaymentVoucherDate.Date >= dtFinancialYearStartDate.Date)
                                                    //            {
                                                    //                if (GLpostingDetailTemp.IsCredit)
                                                    //                {
                                                    //                    dOpanningUnPostedCreditAmount += GLpostingDetailTemp.Amount;
                                                    //                    dUnPostedCreditAmount += GLpostingDetailTemp.Amount;
                                                    //                }
                                                    //                else
                                                    //                {
                                                    //                    dOpanningUnPostedDebitAmount += GLpostingDetailTemp.Amount;
                                                    //                    dUnPostedDebitAmount += GLpostingDetailTemp.Amount;
                                                    //                }
                                                    //            }
                                                    //            else if (oPV.ChequeAmount > 0)
                                                    //            {
                                                    //                foreach (tbl_accChequeRegister oChequeReg in tbl_accChequeRegister.SelectAllByPaymentVoucher_ID(GLpostingDetailTemp.Transaction_ID))
                                                    //                {
                                                    //                    if (oChequeReg.IsReconcilied && dtpFrom.Value.Date > oChequeReg.ReconcilationDate.Date && oChequeReg.ReconcilationDate.Date >= dtFinancialYearStartDate.Date)
                                                    //                    {
                                                    //                        if (GLpostingDetailTemp.IsCredit)
                                                    //                        {
                                                    //                            dOpanningUnPostedCreditAmount += GLpostingDetailTemp.Amount;
                                                    //                            dUnPostedCreditAmount += GLpostingDetailTemp.Amount;
                                                    //                        }
                                                    //                        else
                                                    //                        {
                                                    //                            dOpanningUnPostedDebitAmount += GLpostingDetailTemp.Amount;
                                                    //                            dUnPostedDebitAmount += GLpostingDetailTemp.Amount;
                                                    //                        }
                                                    //                    }
                                                    //                }
                                                    //            }
                                                    //        }
                                                    //    }
                                                    //    // Unposting Account Receipt
                                                    //    else if (GLpostingDetailTemp.Slot_ID.ToString() == clsAutocode.getAccSlotID(AccSlot.AccountReceipt).ToString())
                                                    //    {
                                                    //        tbl_accAccountReceipt oAR = tbl_accAccountReceipt.Select(GLpostingDetailTemp.Transaction_ID);
                                                    //        if (oAR != null)
                                                    //        {
                                                    //            if (oAR.CashAmount > 0 && dtpFrom.Value.Date > oAR.AccountReceiptDate.Date && oAR.AccountReceiptDate.Date >= dtFinancialYearStartDate.Date)
                                                    //            {
                                                    //                if (GLpostingDetailTemp.IsCredit)
                                                    //                {
                                                    //                    dOpanningUnPostedCreditAmount += GLpostingDetailTemp.Amount;
                                                    //                    dUnPostedCreditAmount += GLpostingDetailTemp.Amount;
                                                    //                }
                                                    //                else
                                                    //                {
                                                    //                    dOpanningUnPostedDebitAmount += GLpostingDetailTemp.Amount;
                                                    //                    dUnPostedDebitAmount += GLpostingDetailTemp.Amount;
                                                    //                }
                                                    //            }
                                                    //            else if (oAR.ChequeAmount > 0)
                                                    //            {
                                                    //                foreach (tbl_bpsChequeRegister oChequeReg in tbl_bpsChequeRegister.SelectAllByAccountReceipt_ID(GLpostingDetailTemp.Transaction_ID))
                                                    //                {
                                                    //                    if (oChequeReg.IsReconcilied && dtpFrom.Value.Date > oChequeReg.DateReconcilied.Date && oChequeReg.DateReconcilied.Date >= dtFinancialYearStartDate.Date)
                                                    //                    {
                                                    //                        if (GLpostingDetailTemp.IsCredit)
                                                    //                        {
                                                    //                            dOpanningUnPostedCreditAmount += GLpostingDetailTemp.Amount;
                                                    //                            dUnPostedCreditAmount += GLpostingDetailTemp.Amount;
                                                    //                        }
                                                    //                        else
                                                    //                        {
                                                    //                            dOpanningUnPostedDebitAmount += GLpostingDetailTemp.Amount;
                                                    //                            dUnPostedDebitAmount += GLpostingDetailTemp.Amount;
                                                    //                        }
                                                    //                    }
                                                    //                }
                                                    //            }
                                                    //        }
                                                    //    }
                                                    //    else if (GLpostingDetailTemp.Slot_ID.ToString() == clsAutocode.getAccSlotID(AccSlot.JournalVoucher).ToString())
                                                    //    {
                                                    //        if (dtpFrom.Value.Date > GLpostingDetailTemp.TransactionDate.Date && GLpostingDetailTemp.TransactionDate.Date >= dtFinancialYearStartDate.Date)
                                                    //        {
                                                    //            if (GLpostingDetailTemp.IsCredit)
                                                    //            {
                                                    //                dOpanningUnPostedCreditAmount += GLpostingDetailTemp.Amount;
                                                    //                dUnPostedCreditAmount += GLpostingDetailTemp.Amount;
                                                    //            }
                                                    //            else
                                                    //            {
                                                    //                dOpanningUnPostedDebitAmount += GLpostingDetailTemp.Amount;
                                                    //                dUnPostedDebitAmount += GLpostingDetailTemp.Amount;
                                                    //            }
                                                    //        }
                                                    //    }
                                                    //    else if (GLpostingDetailTemp.Slot_ID.ToString() == clsAutocode.getAccSlotID(AccSlot.StandardJournalEntries).ToString())
                                                    //    {
                                                    //        if (dtpFrom.Value.Date > GLpostingDetailTemp.TransactionDate.Date && GLpostingDetailTemp.TransactionDate.Date >= dtFinancialYearStartDate.Date)
                                                    //        {
                                                    //            if (GLpostingDetailTemp.IsCredit)
                                                    //            {
                                                    //                dOpanningUnPostedCreditAmount += GLpostingDetailTemp.Amount;
                                                    //                dUnPostedCreditAmount += GLpostingDetailTemp.Amount;
                                                    //            }
                                                    //            else
                                                    //            {
                                                    //                dOpanningUnPostedDebitAmount += GLpostingDetailTemp.Amount;
                                                    //                dUnPostedDebitAmount += GLpostingDetailTemp.Amount;
                                                    //            }
                                                    //        }
                                                    //    }
                                                    //    else if (GLpostingDetailTemp.Slot_ID.ToString() == clsAutocode.getAccSlotID(AccSlot.BankAdjustmentEntries).ToString())
                                                    //    {
                                                    //        if (dtpFrom.Value.Date > GLpostingDetailTemp.TransactionDate.Date && GLpostingDetailTemp.TransactionDate.Date >= dtFinancialYearStartDate.Date)
                                                    //        {
                                                    //            if (GLpostingDetailTemp.IsCredit)
                                                    //            {
                                                    //                dOpanningUnPostedCreditAmount += GLpostingDetailTemp.Amount;
                                                    //                dUnPostedCreditAmount += GLpostingDetailTemp.Amount;
                                                    //            }
                                                    //            else
                                                    //            {
                                                    //                dOpanningUnPostedDebitAmount += GLpostingDetailTemp.Amount;
                                                    //                dUnPostedDebitAmount += GLpostingDetailTemp.Amount;
                                                    //            }
                                                    //        }
                                                    //    }
                                                    //}

                                                    ////Receipt Cheque
                                                    ////foreach (tbl_bpsChequeRegister obpsChequeRegDetail in tbl_bpsChequeRegister.SelectAll())
                                                    //foreach (tbl_bpsChequeRegister obpsChequeRegDetail in tbl_bpsChequeRegister.SelectAll().Where(p => p.IsReconcilied && dtpFrom.Value.Date > p.DateReconcilied.Date && p.DateReconcilied.Date >= dtFinancialYearStartDate.Date))
                                                    //{
                                                    //    //if (obpsChequeRegDetail.IsReconcilied && dtpFrom.Value.Date > obpsChequeRegDetail.DateReconcilied.Date && obpsChequeRegDetail.DateReconcilied.Date >= dtFinancialYearStartDate.Date)                
                                                    //    if (obpsChequeRegDetail.PostingStatus_ID2 == clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted))
                                                    //    {
                                                    //        if (oAccount.Gl_ID == clsMethods_GL.getAccountCode_Bank(obpsChequeRegDetail.DepositedAccountNumber))
                                                    //        {
                                                    //            dOpanningDebitAmount += obpsChequeRegDetail.ChequeAmount;
                                                    //            dDebitAmount += obpsChequeRegDetail.ChequeAmount;
                                                    //        }
                                                    //    }
                                                    //    else if (obpsChequeRegDetail.PostingStatus_ID2 == clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction))
                                                    //    {
                                                    //        if (oAccount.Gl_ID == clsMethods_GL.getAccountCode_Bank(obpsChequeRegDetail.DepositedAccountNumber))
                                                    //        {
                                                    //            dOpanningUnPostedDebitAmount += obpsChequeRegDetail.ChequeAmount;
                                                    //            dUnPostedDebitAmount += obpsChequeRegDetail.ChequeAmount;
                                                    //        }
                                                    //    }

                                                    //}

                                                    ////Receipt Cash
                                                    //foreach (tbl_bpsReceipt obpsReceipt in tbl_bpsReceipt.SelectAll().Where(p => !p.IsDeleted && p.IsDeposited && dtpFrom.Value.Date > p.ReceiptDate.Date && p.ReceiptDate.Date >= dtFinancialYearStartDate.Date))
                                                    //{
                                                    //    if (obpsReceipt.CashAmount > 0)
                                                    //    {
                                                    //        string sCashDepostiedAcountNum = "";
                                                    //        foreach (tbl_bpsCashDeposit_Detail obpsCashDepositDetail in tbl_bpsCashDeposit_Detail.SelectAllByReceipt_ID(obpsReceipt.Receipt_ID))
                                                    //        {
                                                    //            tbl_bpsCashDeposit obpsCashDeposit = tbl_bpsCashDeposit.Select(obpsCashDepositDetail.CashDeposit_ID);
                                                    //            if (obpsCashDeposit != null)
                                                    //            {
                                                    //                sCashDepostiedAcountNum = obpsCashDeposit.AccountNumber;
                                                    //            }
                                                    //        }
                                                    //        if (obpsReceipt.PostingStatus_ID2 == clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted))
                                                    //        {
                                                    //            if (oAccount.Gl_ID == clsMethods_GL.getAccountCode_Bank(sCashDepostiedAcountNum))
                                                    //            {
                                                    //                dOpanningDebitAmount += obpsReceipt.CashAmount;
                                                    //                dDebitAmount += obpsReceipt.CashAmount;
                                                    //            }
                                                    //        }
                                                    //        else if (obpsReceipt.PostingStatus_ID2 == clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction))
                                                    //        {
                                                    //            if (oAccount.Gl_ID == clsMethods_GL.getAccountCode_Bank(sCashDepostiedAcountNum))
                                                    //            {
                                                    //                dOpanningUnPostedDebitAmount += obpsReceipt.CashAmount;
                                                    //                dUnPostedDebitAmount += obpsReceipt.CashAmount;
                                                    //            }
                                                    //        }
                                                    //    }
                                                    //}

                                                    //dBalace = (dOpanningUnPostedCreditAmount - dOpanningUnPostedDebitAmount) + (dOpanningCreditAmount - dOpanningDebitAmount) + (dInsertOpanningCreditAmount - dInsertOpanningDebiteAmount);

                                                    //#region Adddts_acc_GLRow
                                                    //glb_dts_Accounts.dts_acc_CashBook_GL.Adddts_acc_CashBook_GLRow(sYearID, "", oAccount.Gl_ID, dDebitAmount + dInsertOpanningDebiteAmount, dCreditAmount + dInsertOpanningCreditAmount, "Opening Balance", "", true,
                                                    //    clsGenaralName.getName_AccountName(oAccount.Gl_ID), dBalace, dtpFrom.Value, clsGenaralName.getName_GLMainCatagory(clsGenaralName.getName_GLMainCatagoryByGLID(oAccount.Gl_ID)),
                                                    //    sAccountType, false, true, "", "", dUnPostedCreditAmount, dUnPostedDebitAmount, "A", " - ");
                                                    //#endregion

                                                    #endregion
                                                    #endregion

                                                    #region Get Debit Credits Amounts

                                                    #region Posted
                                                    //foreach (tbl_accGLPosting_Detail GLpostingDetail1 in tbl_accGLPosting_Detail.SelectAllByGl_ID(oAccount.Gl_ID).Where(p => dtpFrom.Value.Date <= p.TransactionDate.Date && p.TransactionDate.Date <= dtpTo.Value.Date))
                                                    //{
                                                    //    #region Payment Voucher
                                                    //    if (GLpostingDetail1.Slot_ID.ToString() == clsAutocode.getAccSlotID(AccSlot.PaymetVoucher).ToString())
                                                    //    {
                                                    //        tbl_accPaymentVoucher oPV = tbl_accPaymentVoucher.Select(GLpostingDetail1.Transaction_ID);
                                                    //        if (oPV != null)
                                                    //        {
                                                    //            if (oPV.CashAmount > 0)
                                                    //            {
                                                    //                if (GLpostingDetail1.IsCredit)
                                                    //                {
                                                    //                    dCreditAmount = GLpostingDetail1.Amount;
                                                    //                    dBalace = dCreditAmount + dBalace;
                                                    //                    dClosingCreditAmount = dClosingCreditAmount + dCreditAmount;
                                                    //                }
                                                    //                else
                                                    //                {
                                                    //                    dDebitAmount = GLpostingDetail.Amount;
                                                    //                    dBalace = -dDebitAmount + dBalace;
                                                    //                    dClosingDebitAmount = dClosingDebitAmount + dDebitAmount;
                                                    //                }

                                                    //                #region Adddts_acc_GLRow
                                                    //                glb_dts_Accounts.dts_acc_CashBook_GL.Adddts_acc_CashBook_GLRow(sYearID, clsFormatter.GetMonthName(GLpostingDetail.TransactionDate.Month), oAccount.Gl_ID, dDebitAmount, dCreditAmount, "Payment Voucher - Cash",
                                                    //                    GLpostingDetail.Transaction_ID, GLpostingDetail.IsCredit, clsGenaralName.getName_AccountName(GLpostingDetail.Gl_ID), dBalace, GLpostingDetail.TransactionDate,
                                                    //                    clsGenaralName.getName_GLMainCatagory(clsGenaralName.getName_GLMainCatagoryByGLID(oAccount.Gl_ID)), sAccountType,
                                                    //                    false, false, GLpostingDetail.Cheq_No, GLpostingDetail.Remark, dUnPostedCreditAmount, dUnPostedDebitAmount, "B", oPV.CreateUser_ID);
                                                    //                #endregion
                                                    //            }
                                                    //            else if (oPV.ChequeAmount > 0)
                                                    //            {

                                                    //                foreach (tbl_accChequeRegister oChequeReg in tbl_accChequeRegister.SelectAllByPaymentVoucher_ID(GLpostingDetail.Transaction_ID))
                                                    //                {
                                                    //                    if (oChequeReg.IsReconcilied && dtpFrom.Value.Date <= oChequeReg.ReconcilationDate.Date && oChequeReg.ReconcilationDate.Date <= dtpTo.Value.Date)
                                                    //                    {
                                                    //                        if (GLpostingDetail.IsCredit)
                                                    //                        {
                                                    //                            dCreditAmount = GLpostingDetail.Amount;
                                                    //                            dBalace = dCreditAmount + dBalace;
                                                    //                            dClosingCreditAmount = dClosingCreditAmount + dCreditAmount;
                                                    //                        }
                                                    //                        else
                                                    //                        {
                                                    //                            dDebitAmount = GLpostingDetail.Amount;
                                                    //                            dBalace = -dDebitAmount + dBalace;
                                                    //                            dClosingDebitAmount = dClosingDebitAmount + dDebitAmount;
                                                    //                        }

                                                    //                        #region Adddts_acc_GLRow
                                                    //                        glb_dts_Accounts.dts_acc_CashBook_GL.Adddts_acc_CashBook_GLRow(sYearID, clsFormatter.GetMonthName(oChequeReg.ReconcilationDate.Month), oAccount.Gl_ID, dDebitAmount, dCreditAmount, "Payment Voucher - Cheque",
                                                    //                            oChequeReg.PaymentVoucher_ID, GLpostingDetail.IsCredit, clsGenaralName.getName_AccountName(GLpostingDetail.Gl_ID), dBalace, oChequeReg.ReconcilationDate,
                                                    //                            clsGenaralName.getName_GLMainCatagory(clsGenaralName.getName_GLMainCatagoryByGLID(oAccount.Gl_ID)), sAccountType,
                                                    //                            false, false, GLpostingDetail.Cheq_No, GLpostingDetail.Remark, dUnPostedCreditAmount, dUnPostedDebitAmount, "B", oPV.CreateUser_ID);
                                                    //                        #endregion
                                                    //                    }
                                                    //                }
                                                    //            }
                                                    //        }
                                                    //    }
                                                    //    #endregion
                                                    //}


                                                    foreach (tbl_accGLPosting_Detail GLpostingDetail in tbl_accGLPosting_Detail.SelectAllByGl_ID(oAccount.Gl_ID).Where(p => dtpFrom.Value.Date <= p.TransactionDate.Date && p.TransactionDate.Date <= dtpTo.Value.Date))
                                                    {
                                                        dDebitAmount = 0;
                                                        dCreditAmount = 0;
                                                        dUnPostedCreditAmount = 0;
                                                        dUnPostedDebitAmount = 0;

                                                        #region Payment Voucher
                                                        if (GLpostingDetail.Slot_ID.ToString() == clsAutocode.getAccSlotID(AccSlot.PaymetVoucher).ToString())
                                                        {
                                                            tbl_accPaymentVoucher oPV = tbl_accPaymentVoucher.Select(GLpostingDetail.Transaction_ID);
                                                            if (oPV != null)
                                                            {
                                                                if (oPV.CashAmount > 0)
                                                                {
                                                                    if (GLpostingDetail.IsCredit)
                                                                    {
                                                                        dCreditAmount = GLpostingDetail.Amount;
                                                                        dBalace = dCreditAmount + dBalace;
                                                                        dClosingCreditAmount = dClosingCreditAmount + dCreditAmount;
                                                                    }
                                                                    else
                                                                    {
                                                                        dDebitAmount = GLpostingDetail.Amount;
                                                                        dBalace = -dDebitAmount + dBalace;
                                                                        dClosingDebitAmount = dClosingDebitAmount + dDebitAmount;
                                                                    }

                                                                    #region Adddts_acc_GLRow
                                                                    glb_dts_Accounts.dts_acc_CashBook_GL.Adddts_acc_CashBook_GLRow(sYearID, clsFormatter.GetMonthName(GLpostingDetail.TransactionDate.Month), oAccount.Gl_ID, dDebitAmount, dCreditAmount, "Payment Voucher - Cash",
                                                                        GLpostingDetail.Transaction_ID, GLpostingDetail.IsCredit, clsGenaralName.getName_AccountName(GLpostingDetail.Gl_ID), dBalace, GLpostingDetail.TransactionDate,
                                                                        clsGenaralName.getName_GLMainCatagory(clsGenaralName.getID_GLMainCatagoryBySubGLID(oAccount.Gl_ID)), sAccountType,
                                                                        false, false, GLpostingDetail.Cheq_No, GLpostingDetail.Remark, dUnPostedCreditAmount, dUnPostedDebitAmount, "B", oPV.CreateUser_ID);
                                                                    #endregion
                                                                }
                                                                else if (oPV.ChequeAmount > 0)
                                                                {

                                                                    foreach (tbl_accChequeRegister oChequeReg in tbl_accChequeRegister.SelectAllByPaymentVoucher_ID(GLpostingDetail.Transaction_ID))
                                                                    {
                                                                        if (oChequeReg.ChequeStatus_ID == "3" && dtpFrom.Value.Date <= oChequeReg.ReconcilationDate.Date && oChequeReg.ReconcilationDate.Date <= dtpTo.Value.Date)
                                                                        {
                                                                            if (GLpostingDetail.IsCredit)
                                                                            {
                                                                                dCreditAmount = GLpostingDetail.Amount;
                                                                                dBalace = dCreditAmount + dBalace;
                                                                                dClosingCreditAmount = dClosingCreditAmount + dCreditAmount;
                                                                            }
                                                                            else
                                                                            {
                                                                                dDebitAmount = GLpostingDetail.Amount;
                                                                                dBalace = -dDebitAmount + dBalace;
                                                                                dClosingDebitAmount = dClosingDebitAmount + dDebitAmount;
                                                                            }

                                                                            #region Adddts_acc_GLRow
                                                                            glb_dts_Accounts.dts_acc_CashBook_GL.Adddts_acc_CashBook_GLRow(sYearID, clsFormatter.GetMonthName(oChequeReg.ReconcilationDate.Month), oAccount.Gl_ID, dDebitAmount, dCreditAmount, "Payment Voucher - Cheque",
                                                                                oChequeReg.PaymentVoucher_ID, GLpostingDetail.IsCredit, clsGenaralName.getName_AccountName(GLpostingDetail.Gl_ID), dBalace, oChequeReg.ReconcilationDate,
                                                                                clsGenaralName.getName_GLMainCatagory(clsGenaralName.getID_GLMainCatagoryBySubGLID(oAccount.Gl_ID)), sAccountType,
                                                                                false, false, GLpostingDetail.Cheq_No, GLpostingDetail.Remark, dUnPostedCreditAmount, dUnPostedDebitAmount, "B", oPV.CreateUser_ID);
                                                                            #endregion
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        #endregion

                                                        #region Acc Reciept
                                                        else if (GLpostingDetail.Slot_ID.ToString() == clsAutocode.getAccSlotID(AccSlot.AccountReceipt).ToString())
                                                        {
                                                            tbl_accAccountReceipt oAR = tbl_accAccountReceipt.Select(GLpostingDetail.Transaction_ID);
                                                            if (oAR != null)
                                                            {
                                                                if (oAR.CashAmount > 0)
                                                                {
                                                                    if (GLpostingDetail.IsCredit)
                                                                    {
                                                                        dCreditAmount = GLpostingDetail.Amount;
                                                                        dBalace = dCreditAmount + dBalace;
                                                                        dClosingCreditAmount = dClosingCreditAmount + dCreditAmount;
                                                                    }
                                                                    else
                                                                    {
                                                                        dDebitAmount = GLpostingDetail.Amount;
                                                                        dBalace = -dDebitAmount + dBalace;
                                                                        dClosingDebitAmount = dClosingDebitAmount + dDebitAmount;
                                                                    }

                                                                    #region Adddts_acc_GLRow
                                                                    glb_dts_Accounts.dts_acc_CashBook_GL.Adddts_acc_CashBook_GLRow(sYearID, clsFormatter.GetMonthName(GLpostingDetail.TransactionDate.Month), oAccount.Gl_ID, dDebitAmount, dCreditAmount, "Account Receipt - Cash",
                                                                        GLpostingDetail.Transaction_ID, GLpostingDetail.IsCredit, clsGenaralName.getName_AccountName(GLpostingDetail.Gl_ID), dBalace, GLpostingDetail.TransactionDate,
                                                                        clsGenaralName.getName_GLMainCatagory(clsGenaralName.getID_GLMainCatagoryBySubGLID(oAccount.Gl_ID)), sAccountType,
                                                                        false, false, GLpostingDetail.Cheq_No, GLpostingDetail.Remark, dUnPostedCreditAmount, dUnPostedDebitAmount, "B", oAR.CreateUser_ID);
                                                                    #endregion
                                                                }
                                                                else if (oAR.ChequeAmount > 0)
                                                                {
                                                                    foreach (tbl_bpsChequeRegister oChequeReg in tbl_bpsChequeRegister.SelectAllByAccountReceipt_ID(GLpostingDetail.Transaction_ID))
                                                                    {
                                                                        if (oChequeReg.IsReconcilied && dtpFrom.Value.Date <= oChequeReg.DateReconcilied.Date && oChequeReg.DateReconcilied.Date <= dtpTo.Value.Date)
                                                                        {
                                                                            if (GLpostingDetail.IsCredit)
                                                                            {
                                                                                dCreditAmount = GLpostingDetail.Amount;
                                                                                dBalace = dCreditAmount + dBalace;
                                                                                dClosingCreditAmount = dClosingCreditAmount + dCreditAmount;
                                                                            }
                                                                            else
                                                                            {
                                                                                dDebitAmount = GLpostingDetail.Amount;
                                                                                dBalace = -dDebitAmount + dBalace;
                                                                                dClosingDebitAmount = dClosingDebitAmount + dDebitAmount;
                                                                            }

                                                                            #region Adddts_acc_GLRow
                                                                            glb_dts_Accounts.dts_acc_CashBook_GL.Adddts_acc_CashBook_GLRow(sYearID, clsFormatter.GetMonthName(oChequeReg.DateReconcilied.Month), oAccount.Gl_ID, dDebitAmount, dCreditAmount, "Account Receipt - Cheque",
                                                                                oChequeReg.Receipt_ID, GLpostingDetail.IsCredit, clsGenaralName.getName_AccountName(GLpostingDetail.Gl_ID), dBalace, oChequeReg.DateReconcilied,
                                                                                clsGenaralName.getName_GLMainCatagory(clsGenaralName.getID_GLMainCatagoryBySubGLID(oAccount.Gl_ID)), sAccountType,
                                                                                false, false, GLpostingDetail.Cheq_No, GLpostingDetail.Remark, dUnPostedCreditAmount, dUnPostedDebitAmount, "B", oAR.CreateUser_ID);
                                                                            #endregion
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        #endregion

                                                        #region Journal Voucher
                                                        else if (GLpostingDetail.Slot_ID.ToString() == clsAutocode.getAccSlotID(AccSlot.JournalVoucher).ToString())
                                                        {

                                                            //  if (dtpFrom.Value.Date <= GLpostingDetail.TransactionDate.Date && GLpostingDetail.TransactionDate.Date <= dtpTo.Value.Date)
                                                            {
                                                                if (GLpostingDetail.IsCredit)
                                                                {
                                                                    dCreditAmount = GLpostingDetail.Amount;
                                                                    dBalace = dCreditAmount + dBalace;
                                                                    dClosingCreditAmount = dClosingCreditAmount + dCreditAmount;
                                                                }
                                                                else
                                                                {
                                                                    dDebitAmount = GLpostingDetail.Amount;
                                                                    dBalace = -dDebitAmount + dBalace;
                                                                    dClosingDebitAmount = dClosingDebitAmount + dDebitAmount;
                                                                }

                                                                #region Adddts_acc_GLRow
                                                                glb_dts_Accounts.dts_acc_CashBook_GL.Adddts_acc_CashBook_GLRow(sYearID, clsFormatter.GetMonthName(GLpostingDetail.TransactionDate.Month), oAccount.Gl_ID, dDebitAmount, dCreditAmount, "Journal Voucher",
                                                                    GLpostingDetail.Transaction_ID, GLpostingDetail.IsCredit, clsGenaralName.getName_AccountName(GLpostingDetail.Gl_ID), dBalace, GLpostingDetail.TransactionDate,
                                                                    clsGenaralName.getName_GLMainCatagory(clsGenaralName.getID_GLMainCatagoryBySubGLID(oAccount.Gl_ID)), sAccountType,
                                                                    false, false, "", GLpostingDetail.Remark, dUnPostedCreditAmount, dUnPostedDebitAmount, "B", "-");
                                                                #endregion
                                                            }
                                                        }
                                                        #endregion

                                                        #region Standard Journal Entries
                                                        else if (GLpostingDetail.Slot_ID.ToString() == clsAutocode.getAccSlotID(AccSlot.StandardJournalEntries).ToString())
                                                        {
                                                            // if (dtpFrom.Value.Date <= GLpostingDetail.TransactionDate.Date && GLpostingDetail.TransactionDate.Date <= dtpTo.Value.Date)
                                                            {
                                                                if (GLpostingDetail.IsCredit)
                                                                {
                                                                    dCreditAmount = GLpostingDetail.Amount;
                                                                    dBalace = dCreditAmount + dBalace;
                                                                    dClosingCreditAmount = dClosingCreditAmount + dCreditAmount;
                                                                }
                                                                else
                                                                {
                                                                    dDebitAmount = GLpostingDetail.Amount;
                                                                    dBalace = -dDebitAmount + dBalace;
                                                                    dClosingDebitAmount = dClosingDebitAmount + dDebitAmount;
                                                                }

                                                                #region Adddts_acc_GLRow
                                                                glb_dts_Accounts.dts_acc_CashBook_GL.Adddts_acc_CashBook_GLRow(sYearID, clsFormatter.GetMonthName(GLpostingDetail.TransactionDate.Month), oAccount.Gl_ID, dDebitAmount, dCreditAmount, "Std. Journal Entries",
                                                                    GLpostingDetail.Transaction_ID, GLpostingDetail.IsCredit, clsGenaralName.getName_AccountName(GLpostingDetail.Gl_ID), dBalace, GLpostingDetail.TransactionDate,
                                                                    clsGenaralName.getName_GLMainCatagory(clsGenaralName.getID_GLMainCatagoryBySubGLID(oAccount.Gl_ID)), sAccountType,
                                                                    false, false, "", GLpostingDetail.Remark, dUnPostedCreditAmount, dUnPostedDebitAmount, "B", " - ");
                                                                #endregion
                                                            }
                                                        }
                                                        #endregion

                                                        #region Bank Adjustment Entries
                                                        else if (GLpostingDetail.Slot_ID.ToString() == clsAutocode.getAccSlotID(AccSlot.BankAdjustmentEntries).ToString())
                                                        {
                                                            if (dtpFrom.Value.Date <= GLpostingDetail.TransactionDate.Date && GLpostingDetail.TransactionDate.Date <= dtpTo.Value.Date)
                                                            {
                                                                if (GLpostingDetail.IsCredit)
                                                                {
                                                                    dCreditAmount = GLpostingDetail.Amount;
                                                                    dBalace = dCreditAmount + dBalace;
                                                                    dClosingCreditAmount = dClosingCreditAmount + dCreditAmount;
                                                                }
                                                                else
                                                                {
                                                                    dDebitAmount = GLpostingDetail.Amount;
                                                                    dBalace = -dDebitAmount + dBalace;
                                                                    dClosingDebitAmount = dClosingDebitAmount + dDebitAmount;
                                                                }

                                                                #region Adddts_acc_GLRow
                                                                glb_dts_Accounts.dts_acc_CashBook_GL.Adddts_acc_CashBook_GLRow(sYearID, clsFormatter.GetMonthName(GLpostingDetail.TransactionDate.Month), oAccount.Gl_ID, dDebitAmount, dCreditAmount, "Bank Adjustment Entries",
                                                                    GLpostingDetail.Transaction_ID, GLpostingDetail.IsCredit, clsGenaralName.getName_AccountName(GLpostingDetail.Gl_ID), dBalace, GLpostingDetail.TransactionDate,
                                                                    clsGenaralName.getName_GLMainCatagory(clsGenaralName.getID_GLMainCatagoryBySubGLID(oAccount.Gl_ID)), sAccountType,
                                                                    false, false, "", GLpostingDetail.Remark, dUnPostedCreditAmount, dUnPostedDebitAmount, "B", " - ");
                                                                #endregion
                                                            }
                                                        }
                                                        #endregion
                                                    }
                                                    #endregion

                                                    #region non posted - postingTemp
                                                    //foreach (tbl_accGLPosting_Detail_Tmp GLpostingDetailTemp in tbl_accGLPosting_Detail_Tmp.SelectAllByGl_ID(oAccount.Gl_ID).Where(p => dtpFrom.Value.Date <= p.TransactionDate.Date && p.TransactionDate.Date <= dtpTo.Value.Date).OrderBy(p => p.TransactionDate).ToList())
                                                    //{
                                                    //    dDebitAmount = 0; dCreditAmount = 0;
                                                    //    dUnPostedCreditAmount = 0;
                                                    //    dUnPostedDebitAmount = 0;

                                                    //    #region Payment Voucher
                                                    //    if (GLpostingDetailTemp.Slot_ID.ToString() == clsAutocode.getAccSlotID(AccSlot.PaymetVoucher).ToString())
                                                    //    {
                                                    //        tbl_accPaymentVoucher oPV = tbl_accPaymentVoucher.Select(GLpostingDetailTemp.Transaction_ID);
                                                    //        if (oPV != null)
                                                    //        {
                                                    //            if (oPV.CashAmount > 0)
                                                    //            {
                                                    //                if (GLpostingDetailTemp.IsCredit)
                                                    //                {
                                                    //                    dUnPostedCreditAmount = GLpostingDetailTemp.Amount;
                                                    //                    dBalace = dUnPostedCreditAmount + dBalace;
                                                    //                    dClosingUnPostedCreditAmount += dUnPostedCreditAmount;
                                                    //                }
                                                    //                else
                                                    //                {
                                                    //                    dUnPostedDebitAmount = GLpostingDetailTemp.Amount;
                                                    //                    dBalace = -dUnPostedDebitAmount + dBalace;
                                                    //                    dClosingUnPostedDebitAmount += dUnPostedDebitAmount;
                                                    //                }

                                                    //                #region Adddts_acc_GLRow
                                                    //                glb_dts_Accounts.dts_acc_CashBook_GL.Adddts_acc_CashBook_GLRow(sYearID, clsFormatter.GetMonthName(GLpostingDetailTemp.TransactionDate.Month), oAccount.Gl_ID, dDebitAmount, dCreditAmount, "Paymet Voucher - Cash",
                                                    //                    GLpostingDetailTemp.Transaction_ID, GLpostingDetailTemp.IsCredit, clsGenaralName.getName_AccountName(GLpostingDetailTemp.Gl_ID), dBalace, GLpostingDetailTemp.TransactionDate,
                                                    //                    clsGenaralName.getName_GLMainCatagory(clsGenaralName.getID_GLMainCatagoryBySubGLID(oAccount.Gl_ID)), sAccountType,
                                                    //                    false, false, GLpostingDetailTemp.Cheq_No, GLpostingDetailTemp.Remark, dUnPostedCreditAmount, dUnPostedDebitAmount, "B", oPV.CreateUser_ID);
                                                    //                #endregion
                                                    //            }
                                                    //            else if (oPV.ChequeAmount > 0)
                                                    //            {
                                                    //                foreach (tbl_accChequeRegister oChequeReg in tbl_accChequeRegister.SelectAllByPaymentVoucher_ID(GLpostingDetailTemp.Transaction_ID))
                                                    //                {
                                                    //                    if (oChequeReg.IsReconcilied && dtpFrom.Value.Date <= oChequeReg.ReconcilationDate.Date && oChequeReg.ReconcilationDate.Date <= dtpTo.Value.Date)
                                                    //                    {
                                                    //                        if (GLpostingDetailTemp.IsCredit)
                                                    //                        {
                                                    //                            dUnPostedCreditAmount = GLpostingDetailTemp.Amount;
                                                    //                            dBalace = dUnPostedCreditAmount + dBalace;
                                                    //                            dClosingUnPostedCreditAmount += dUnPostedCreditAmount;
                                                    //                        }
                                                    //                        else
                                                    //                        {
                                                    //                            dUnPostedDebitAmount = GLpostingDetailTemp.Amount;
                                                    //                            dBalace = -dUnPostedDebitAmount + dBalace;
                                                    //                            dClosingUnPostedDebitAmount += dUnPostedDebitAmount;
                                                    //                        }

                                                    //                        #region Adddts_acc_GLRow
                                                    //                        glb_dts_Accounts.dts_acc_CashBook_GL.Adddts_acc_CashBook_GLRow(sYearID, clsFormatter.GetMonthName(oChequeReg.ReconcilationDate.Month), oAccount.Gl_ID, dDebitAmount, dCreditAmount, "Paymet Voucher - Cheque",
                                                    //                            GLpostingDetailTemp.Transaction_ID, GLpostingDetailTemp.IsCredit, clsGenaralName.getName_AccountName(GLpostingDetailTemp.Gl_ID), dBalace, oChequeReg.ReconcilationDate,
                                                    //                            clsGenaralName.getName_GLMainCatagory(clsGenaralName.getID_GLMainCatagoryBySubGLID(oAccount.Gl_ID)), sAccountType,
                                                    //                            false, false, GLpostingDetailTemp.Cheq_No, GLpostingDetailTemp.Remark, dUnPostedCreditAmount, dUnPostedDebitAmount, "B", oPV.CreateUser_ID);
                                                    //                        #endregion
                                                    //                    }
                                                    //                }
                                                    //            }
                                                    //        }
                                                    //    }
                                                    //    #endregion
                                                    //    #region Account Receipt
                                                    //    else if (GLpostingDetailTemp.Slot_ID.ToString() == clsAutocode.getAccSlotID(AccSlot.AccountReceipt).ToString())
                                                    //    {
                                                    //        tbl_accAccountReceipt oAR = tbl_accAccountReceipt.Select(GLpostingDetailTemp.Transaction_ID);
                                                    //        if (oAR != null)
                                                    //        {
                                                    //            if (oAR.CashAmount > 0)
                                                    //            {
                                                    //                if (GLpostingDetailTemp.IsCredit)
                                                    //                {
                                                    //                    dUnPostedCreditAmount = GLpostingDetailTemp.Amount;
                                                    //                    dBalace = dUnPostedCreditAmount + dBalace;
                                                    //                    dClosingUnPostedCreditAmount += dUnPostedCreditAmount;
                                                    //                }
                                                    //                else
                                                    //                {
                                                    //                    dUnPostedDebitAmount = GLpostingDetailTemp.Amount;
                                                    //                    dBalace = -dUnPostedDebitAmount + dBalace;
                                                    //                    dClosingUnPostedDebitAmount += dUnPostedDebitAmount;
                                                    //                }

                                                    //                #region Adddts_acc_GLRow
                                                    //                glb_dts_Accounts.dts_acc_CashBook_GL.Adddts_acc_CashBook_GLRow(sYearID, clsFormatter.GetMonthName(GLpostingDetailTemp.TransactionDate.Month), oAccount.Gl_ID, dDebitAmount, dCreditAmount, "Account Receipt - Cash",
                                                    //                    GLpostingDetailTemp.Transaction_ID, GLpostingDetailTemp.IsCredit, clsGenaralName.getName_AccountName(GLpostingDetailTemp.Gl_ID), dBalace, GLpostingDetailTemp.TransactionDate,
                                                    //                    clsGenaralName.getName_GLMainCatagory(clsGenaralName.getID_GLMainCatagoryBySubGLID(oAccount.Gl_ID)), sAccountType,
                                                    //                    false, false, GLpostingDetailTemp.Cheq_No, GLpostingDetailTemp.Remark, dUnPostedCreditAmount, dUnPostedDebitAmount, "B", oAR.CreateUser_ID);
                                                    //                #endregion
                                                    //            }
                                                    //            else if (oAR.ChequeAmount > 0)
                                                    //            {
                                                    //                foreach (tbl_bpsChequeRegister oChequeReg in tbl_bpsChequeRegister.SelectAllByAccountReceipt_ID(GLpostingDetailTemp.Transaction_ID))
                                                    //                {
                                                    //                    if (oChequeReg.IsReconcilied && dtpFrom.Value.Date <= oChequeReg.DateReconcilied.Date && oChequeReg.DateReconcilied.Date <= dtpTo.Value.Date)
                                                    //                    {
                                                    //                        if (GLpostingDetailTemp.IsCredit)
                                                    //                        {
                                                    //                            dUnPostedCreditAmount = GLpostingDetailTemp.Amount;
                                                    //                            dBalace = dUnPostedCreditAmount + dBalace;
                                                    //                            dClosingUnPostedCreditAmount += dUnPostedCreditAmount;
                                                    //                        }
                                                    //                        else
                                                    //                        {
                                                    //                            dUnPostedDebitAmount = GLpostingDetailTemp.Amount;
                                                    //                            dBalace = -dUnPostedDebitAmount + dBalace;
                                                    //                            dClosingUnPostedDebitAmount += dUnPostedDebitAmount;
                                                    //                        }

                                                    //                        #region Adddts_acc_GLRow
                                                    //                        glb_dts_Accounts.dts_acc_CashBook_GL.Adddts_acc_CashBook_GLRow(sYearID, clsFormatter.GetMonthName(oChequeReg.DateReconcilied.Month), oAccount.Gl_ID, dDebitAmount, dCreditAmount, "Account Receipt - Cheque",
                                                    //                            GLpostingDetailTemp.Transaction_ID, GLpostingDetailTemp.IsCredit, clsGenaralName.getName_AccountName(GLpostingDetailTemp.Gl_ID), dBalace, oChequeReg.DateReconcilied,
                                                    //                            clsGenaralName.getName_GLMainCatagory(clsGenaralName.getID_GLMainCatagoryBySubGLID(oAccount.Gl_ID)), sAccountType,
                                                    //                            false, false, GLpostingDetailTemp.Cheq_No, GLpostingDetailTemp.Remark, dUnPostedCreditAmount, dUnPostedDebitAmount, "B", oAR.CreateUser_ID);
                                                    //                        #endregion
                                                    //                    }
                                                    //                }
                                                    //            }
                                                    //        }
                                                    //    }
                                                    //    #endregion
                                                    //    #region Journal Voucher
                                                    //    else if (GLpostingDetailTemp.Slot_ID.ToString() == clsAutocode.getAccSlotID(AccSlot.JournalVoucher).ToString())
                                                    //    {
                                                    //        //if (dtpFrom.Value.Date <= GLpostingDetailTemp.TransactionDate.Date && GLpostingDetailTemp.TransactionDate.Date <= dtpTo.Value.Date)
                                                    //        {
                                                    //            if (GLpostingDetailTemp.IsCredit)
                                                    //            {
                                                    //                dUnPostedCreditAmount = GLpostingDetailTemp.Amount;
                                                    //                dBalace = dUnPostedCreditAmount + dBalace;
                                                    //                dClosingUnPostedCreditAmount += dUnPostedCreditAmount;
                                                    //            }
                                                    //            else
                                                    //            {
                                                    //                dUnPostedDebitAmount = GLpostingDetailTemp.Amount;
                                                    //                dBalace = -dUnPostedDebitAmount + dBalace;
                                                    //                dClosingUnPostedDebitAmount += dUnPostedDebitAmount;
                                                    //            }

                                                    //            #region Adddts_acc_GLRow
                                                    //            glb_dts_Accounts.dts_acc_CashBook_GL.Adddts_acc_CashBook_GLRow(sYearID, clsFormatter.GetMonthName(GLpostingDetailTemp.TransactionDate.Month), oAccount.Gl_ID, dDebitAmount, dCreditAmount, "Journal Voucher",
                                                    //                GLpostingDetailTemp.Transaction_ID, GLpostingDetailTemp.IsCredit, clsGenaralName.getName_AccountName(GLpostingDetailTemp.Gl_ID), dBalace, GLpostingDetailTemp.TransactionDate,
                                                    //                clsGenaralName.getName_GLMainCatagory(clsGenaralName.getID_GLMainCatagoryBySubGLID(oAccount.Gl_ID)), sAccountType,
                                                    //                false, false, "", GLpostingDetailTemp.Remark, dUnPostedCreditAmount, dUnPostedDebitAmount, "B", " - ");
                                                    //            #endregion
                                                    //        }
                                                    //    }
                                                    //    #endregion
                                                    //    #region Standard Journal Entries
                                                    //    else if (GLpostingDetailTemp.Slot_ID.ToString() == clsAutocode.getAccSlotID(AccSlot.StandardJournalEntries).ToString())
                                                    //    {
                                                    //        //if (dtpFrom.Value.Date <= GLpostingDetailTemp.TransactionDate.Date && GLpostingDetailTemp.TransactionDate.Date <= dtpTo.Value.Date)
                                                    //        {
                                                    //            if (GLpostingDetailTemp.IsCredit)
                                                    //            {
                                                    //                dUnPostedCreditAmount = GLpostingDetailTemp.Amount;
                                                    //                dBalace = dUnPostedCreditAmount + dBalace;
                                                    //                dClosingUnPostedCreditAmount += dUnPostedCreditAmount;
                                                    //            }
                                                    //            else
                                                    //            {
                                                    //                dUnPostedDebitAmount = GLpostingDetailTemp.Amount;
                                                    //                dBalace = -dUnPostedDebitAmount + dBalace;
                                                    //                dClosingUnPostedDebitAmount += dUnPostedDebitAmount;
                                                    //            }

                                                    //            #region Adddts_acc_GLRow
                                                    //            glb_dts_Accounts.dts_acc_CashBook_GL.Adddts_acc_CashBook_GLRow(sYearID, clsFormatter.GetMonthName(GLpostingDetailTemp.TransactionDate.Month), oAccount.Gl_ID, dDebitAmount, dCreditAmount, "Standard Journal Entry",
                                                    //                GLpostingDetailTemp.Transaction_ID, GLpostingDetailTemp.IsCredit, clsGenaralName.getName_AccountName(GLpostingDetailTemp.Gl_ID), dBalace, GLpostingDetailTemp.TransactionDate,
                                                    //                clsGenaralName.getName_GLMainCatagory(clsGenaralName.getID_GLMainCatagoryBySubGLID(oAccount.Gl_ID)), sAccountType,
                                                    //                false, false, "", GLpostingDetailTemp.Remark, dUnPostedCreditAmount, dUnPostedDebitAmount, "B", " - ");
                                                    //            #endregion
                                                    //        }
                                                    //    }
                                                    //    #endregion
                                                    //    #region Bank Adjustment Entries
                                                    //    else if (GLpostingDetailTemp.Slot_ID.ToString() == clsAutocode.getAccSlotID(AccSlot.BankAdjustmentEntries).ToString())
                                                    //    {
                                                    //        //if (dtpFrom.Value.Date <= GLpostingDetailTemp.TransactionDate.Date && GLpostingDetailTemp.TransactionDate.Date <= dtpTo.Value.Date)
                                                    //        {
                                                    //            if (GLpostingDetailTemp.IsCredit)
                                                    //            {
                                                    //                dUnPostedCreditAmount = GLpostingDetailTemp.Amount;
                                                    //                dBalace = dUnPostedCreditAmount + dBalace;
                                                    //                dClosingUnPostedCreditAmount += dUnPostedCreditAmount;
                                                    //            }
                                                    //            else
                                                    //            {
                                                    //                dUnPostedDebitAmount = GLpostingDetailTemp.Amount;
                                                    //                dBalace = -dUnPostedDebitAmount + dBalace;
                                                    //                dClosingUnPostedDebitAmount += dUnPostedDebitAmount;
                                                    //            }

                                                    //            #region Adddts_acc_GLRow
                                                    //            glb_dts_Accounts.dts_acc_CashBook_GL.Adddts_acc_CashBook_GLRow(sYearID, clsFormatter.GetMonthName(GLpostingDetailTemp.TransactionDate.Month), oAccount.Gl_ID, dDebitAmount, dCreditAmount, "Bank Adjustment Entry",
                                                    //                GLpostingDetailTemp.Transaction_ID, GLpostingDetailTemp.IsCredit, clsGenaralName.getName_AccountName(GLpostingDetailTemp.Gl_ID), dBalace, GLpostingDetailTemp.TransactionDate,
                                                    //                clsGenaralName.getName_GLMainCatagory(clsGenaralName.getID_GLMainCatagoryBySubGLID(oAccount.Gl_ID)), sAccountType,
                                                    //                false, false, "", GLpostingDetailTemp.Remark, dUnPostedCreditAmount, dUnPostedDebitAmount, "B", " - ");
                                                    //            #endregion
                                                    //        }
                                                    //    }
                                                    //    #endregion
                                                    //}
                                                    #endregion

                                                    #region Cheque Register
                                                    foreach (tbl_bpsChequeRegister obpsChequeRegister in tbl_bpsChequeRegister.SelectAll().Where(p => p.IsReconcilied && dtpFrom.Value.Date <= p.DateReconcilied.Date && p.DateReconcilied.Date <= dtpTo.Value.Date))
                                                    {
                                                        if (obpsChequeRegister.IsReturned) //Task 4165 : Cash book - remove returned cheques || Done by Gayan on 01-March-2017
                                                            continue;


                                                        dDebitAmount = 0; dCreditAmount = 0;
                                                        dUnPostedCreditAmount = 0;
                                                        dUnPostedDebitAmount = 0;
                                                        //if (obpsChequeRegDetail.IsReconcilied && dtpFrom.Value.Date > obpsChequeRegDetail.DateReconcilied.Date && obpsChequeRegDetail.DateReconcilied.Date >= dtFinancialYearStartDate.Date)                
                                                        if (obpsChequeRegister.PostingStatus_ID2 == clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted))
                                                        {
                                                            if (oAccount.Gl_ID == clsMethods_GL.getAccountCode_Bank(obpsChequeRegister.DepositedAccountNumber))
                                                            {
                                                                dDebitAmount = obpsChequeRegister.Amount;
                                                                dBalace = dDebitAmount + dBalace;
                                                                dClosingDebitAmount = dClosingDebitAmount + dDebitAmount;

                                                                #region Adddts_acc_GLRow
                                                                glb_dts_Accounts.dts_acc_CashBook_GL.Adddts_acc_CashBook_GLRow(sYearID, clsFormatter.GetMonthName(obpsChequeRegister.DateReconcilied.Month), oAccount.Gl_ID, dDebitAmount, dCreditAmount, "INWARD Cheque Realized",
                                                                    obpsChequeRegister.ChequeRegister_ID, false, clsGenaralName.getName_AccountName(oAccount.Gl_ID), dBalace, obpsChequeRegister.DateReconcilied,
                                                                    clsGenaralName.getName_GLMainCatagory(clsGenaralName.getID_GLMainCatagoryBySubGLID(oAccount.Gl_ID)), sAccountType,
                                                                    false, false, obpsChequeRegister.ChequeNumber, "INWARD Cheque Realized", dUnPostedCreditAmount, dUnPostedDebitAmount, "B", obpsChequeRegister.CreateUser_ID);
                                                                #endregion
                                                            }
                                                        }
                                                        else if (obpsChequeRegister.PostingStatus_ID2 == clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction))
                                                        {
                                                            if (oAccount.Gl_ID == clsMethods_GL.getAccountCode_Bank(obpsChequeRegister.DepositedAccountNumber))
                                                            {
                                                                dUnPostedDebitAmount = obpsChequeRegister.Amount;
                                                                dBalace = dUnPostedDebitAmount + dBalace;
                                                                dClosingUnPostedDebitAmount += dUnPostedDebitAmount;

                                                                #region Adddts_acc_GLRow
                                                                glb_dts_Accounts.dts_acc_CashBook_GL.Adddts_acc_CashBook_GLRow(sYearID, clsFormatter.GetMonthName(obpsChequeRegister.DateReconcilied.Month), oAccount.Gl_ID, dDebitAmount, dCreditAmount, "INWARD Cheque Realized",
                                                                    obpsChequeRegister.ChequeRegister_ID, false, clsGenaralName.getName_AccountName(oAccount.Gl_ID), dBalace, obpsChequeRegister.DateReconcilied,
                                                                    clsGenaralName.getName_GLMainCatagory(clsGenaralName.getID_GLMainCatagoryBySubGLID(oAccount.Gl_ID)), sAccountType,
                                                                    false, false, obpsChequeRegister.ChequeNumber, "INWARD Cheque Realized", dUnPostedCreditAmount, dUnPostedDebitAmount, "B", obpsChequeRegister.CreateUser_ID);
                                                                #endregion
                                                            }
                                                        }
                                                    }
                                                    #endregion

                                                    #region Receipt
                                                    foreach (tbl_bpsReceipt obpsReceipt in tbl_bpsReceipt.SelectAll().Where(p => !p.IsDeleted && p.IsCashDeposited && dtpFrom.Value.Date <= p.ReceiptDate.Date && p.ReceiptDate.Date <= dtpTo.Value.Date))
                                                    {
                                                        dDebitAmount = 0; dCreditAmount = 0;
                                                        dUnPostedCreditAmount = 0;
                                                        dUnPostedDebitAmount = 0;
                                                        if (obpsReceipt.CashAmount > 0)
                                                        {
                                                            string sCashDepostiedAcountNum = "";
                                                            string sCashDepositID = "";
                                                            foreach (tbl_bpsCashDeposit_Detail obpsCashDepositDetail in tbl_bpsCashDeposit_Detail.SelectAllByReceipt_ID(obpsReceipt.Receipt_ID))
                                                            {

                                                                tbl_bpsCashDeposit obpsCashDeposit = tbl_bpsCashDeposit.Select(obpsCashDepositDetail.CashDeposit_ID);
                                                                if (obpsCashDeposit != null)
                                                                {
                                                                    sCashDepositID = obpsCashDepositDetail.CashDeposit_ID;
                                                                    sCashDepostiedAcountNum = obpsCashDeposit.AccountNumber;
                                                                }
                                                            }

                                                            if (oAccount.Gl_ID == clsMethods_GL.getAccountCode_Bank(sCashDepostiedAcountNum))
                                                            {
                                                                if (obpsReceipt.PostingStatus_ID2 == clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted))
                                                                {

                                                                    dDebitAmount = obpsReceipt.CashAmount;
                                                                    dBalace += dDebitAmount;
                                                                    dClosingDebitAmount += dDebitAmount;
                                                                    dCreditAmount = 0;
                                                                    dUnPostedDebitAmount = 0;
                                                                    dUnPostedCreditAmount = 0;

                                                                    #region Adddts_acc_GLRow
                                                                    glb_dts_Accounts.dts_acc_CashBook_GL.Adddts_acc_CashBook_GLRow(sYearID, clsFormatter.GetMonthName(obpsReceipt.ReceiptDate.Month), oAccount.Gl_ID, dDebitAmount, dCreditAmount, "Cash Deposited",
                                                                        obpsReceipt.Receipt_ID, false, clsGenaralName.getName_AccountName(oAccount.Gl_ID), dBalace, obpsReceipt.ReceiptDate,
                                                                        clsGenaralName.getName_GLMainCatagory(clsGenaralName.getID_GLMainCatagoryBySubGLID(oAccount.Gl_ID)), sAccountType,
                                                                        false, false, sCashDepositID, "Cash Deposited", dUnPostedCreditAmount, dUnPostedDebitAmount, "B", obpsReceipt.CreateUser_ID);
                                                                    #endregion
                                                                }
                                                                else if (obpsReceipt.PostingStatus_ID2 == clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction))
                                                                {

                                                                    dUnPostedDebitAmount = obpsReceipt.CashAmount;
                                                                    dBalace += dUnPostedDebitAmount;
                                                                    dClosingUnPostedDebitAmount += dUnPostedDebitAmount;
                                                                    dCreditAmount = 0;
                                                                    dDebitAmount = 0;
                                                                    dUnPostedCreditAmount = 0;

                                                                    #region Adddts_acc_GLRow
                                                                    glb_dts_Accounts.dts_acc_CashBook_GL.Adddts_acc_CashBook_GLRow(sYearID, clsFormatter.GetMonthName(obpsReceipt.ReceiptDate.Month), oAccount.Gl_ID, dDebitAmount, dCreditAmount, "Cash Deposited",
                                                                        obpsReceipt.Receipt_ID, false, clsGenaralName.getName_AccountName(oAccount.Gl_ID), dBalace, obpsReceipt.ReceiptDate,
                                                                        clsGenaralName.getName_GLMainCatagory(clsGenaralName.getID_GLMainCatagoryBySubGLID(oAccount.Gl_ID)), sAccountType,
                                                                        false, false, sCashDepositID, "Cash Deposited", dUnPostedCreditAmount, dUnPostedDebitAmount, "B", obpsReceipt.CreateUser_ID);
                                                                    #endregion
                                                                }
                                                            }
                                                        }
                                                    }
                                                    #endregion
                                                    #endregion

                                                    #region Adddts_acc_GLRow
                                                    glb_dts_Accounts.dts_acc_CashBook_GL.Adddts_acc_CashBook_GLRow(sYearID, "", oAccount.Gl_ID, dInsertOpanningDebiteAmount + dClosingDebitAmount + dOpanningDebitAmount,
                                                            dInsertOpanningCreditAmount + dClosingCreditAmount + dOpanningCreditAmount, "Closing Balance", "", isCloseingCredit,
                                                            clsGenaralName.getName_AccountName(oAccount.Gl_ID), dBalace, dtpTo.Value, clsGenaralName.getName_GLMainCatagory(clsGenaralName.getID_GLMainCatagoryBySubGLID(oAccount.Gl_ID)),
                                                            sAccountType, true, false, "", "", dClosingUnPostedCreditAmount + dOpanningUnPostedCreditAmount, dClosingUnPostedDebitAmount + dOpanningUnPostedDebitAmount, "C", " - ");
                                                    #endregion
                                                }
                                                clsHelpMethods.startProgressBar(0, oAccMasters.Count + 2, 1, ProgressBar);
                                            }

                                            glb_dts_Accounts.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilterBy);
                                            frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                            rpt.print(sReportPath, glb_dts_Accounts, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                            //print1(sReportPath, sReportTitle_Main, glb_dts_Accounts.dts_acc_CashBook_GL, sFilterBy);
                                        }
                                        #endregion

                                        #region old
                                        else
                                        {
                                            Cursor = Cursors.WaitCursor;
                                            glb_dts_Accounts.dts_acc_CashBook_GL.Rows.Clear();

                                            //   double dAmount = 0;
                                            //   double d = Math.Truncate(dAmount * 100) / 100;
                                            //decimal truncated = decimal.Truncate((3750/112)*100);
                                            //var f = (3750 / 112) * 100;
                                            //f = Math.Truncate(f*100); 

                                            List<tbl_accGLMaster> oAccMasters = tbl_accGLMaster.SelectAll().Where(p => !p.IsDeleted && p.ControlAcc_Type == clsAutocode.getControlAccount_Types(enum_ControlAccountType.Cash) || p.ControlAcc_Type == clsAutocode.getControlAccount_Types(enum_ControlAccountType.Bank)).ToList();
                                            foreach (tbl_accGLMaster glMaster in oAccMasters)
                                            {
                                                //if ((oGLPostingDetail.Cheq_No != "") || (oGLPostingDetail.Cheq_No != null))
                                                //{
                                                //    //transactionID = "";
                                                //    if (oGLPostingDetail.Customer_ID == "Default")
                                                //    {
                                                //        tbl_accChequeRegister accCheckRegister = tbl_accChequeRegister.Select(oGLPostingDetail.Transaction_ID);
                                                //        if (accCheckRegister != null)
                                                //            transactionID = accCheckRegister.PaymentVoucher_ID;
                                                //        else
                                                //            transactionID = glMaster.Transaction_ID;
                                                //    }
                                                //    else
                                                //    {
                                                //        tbl_bpsChequeRegister bpsCheckRegister = tbl_bpsChequeRegister.Select(oGLPostingDetail.Transaction_ID);
                                                //        if (bpsCheckRegister != null)
                                                //            transactionID = bpsCheckRegister.Receipt_ID;
                                                //        else
                                                //            transactionID = oGLPostingDetail.Transaction_ID;
                                                //    }
                                                //}

                                                if (glMaster.Gl_ID != "default")
                                                {
                                                    //Gl_codeTXNForCashBook(glMaster.Gl_ID, sFinancialYearID, glMaster.IsCashAccount);
                                                    //glCodeTransactionForCashBook(glMaster.Gl_ID, sFinancialYearID, glMaster.IsCashAccount);
                                                }
                                                clsHelpMethods.startProgressBar(0, oAccMasters.Count + 2, 1, ProgressBar);
                                            }
                                            print1("\\Reports\\ACC\\Common\\rpt_accCashBankDetailBook.rpt", "Cash & Bank Book(Detail)", glb_dts_Accounts.dts_acc_CashBook_GL, "");
                                        }
                                        #endregion
                                    }
                                    catch (Exception)
                                    {
                                    }
                                    finally
                                    {
                                        ProgressBar.Value = 0;
                                        glb_dts_Accounts.dts_acc_CashBook_GL.Rows.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Bank Book
                                else if (Report == enum_ReportName.ST_CashBook)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        string sFinancialYear = clsMethods_GL.getFinancialYear_ID(dtpTo.Value.Date);
                                        DateTime dtmFY_StartDate = clsMethods_GL.getFinancialYear_StartDate(sFinancialYear);

                                        if (dtpFrom.Value.Date < dtmFY_StartDate)
                                            MessageBox.Show("From Date should be grater than " + dtmFY_StartDate.ToShortDateString());
                                        else
                                        {
                                            if (txtAcctCode.Tag != null)
                                            {
                                                dts_accBankBook glb_dts_BankBook = new dts_accBankBook();

                                                glb_dts_BankBook.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, "", clsSecurity.UserNameLoged, "Filter : Date From " + dtpFrom.Value.ToString("yyyy-MMM-dd") + " - Date To " + dtpTo.Value.ToString("yyyy-MMM-dd") + "  |  Account : " + txtAcctCode.Text + "");
                                                dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();

                                                string sQuary = "exec [sp_RPT_BankBook] '" + dtmFY_StartDate.ToString("yyyy-MM-dd") + "','" + dtpFrom.Value.ToString("yyyy-MM-dd") + "','" + dtpTo.Value.ToString("yyyy-MM-dd") + "','" + txtAcctCode.Tag.ToString() + "','" + sFinancialYear + "','" + clsMethods_GL.accountTXNStartMonth() + "'";

                                                glb_dts_BankBook.dt_BankBook.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                                                frm_ReportViewer_New CRViwer = new frm_ReportViewer_New();
                                                CRViwer.print(sReportPath, glb_dts_BankBook, glb_dts_ExportReport.dt_rptParameter, clsAutocode.getReportID(Report));
                                            }
                                            else
                                                MessageBox.Show("Please select a Bank Account...");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                    finally
                                    {
                                        ProgressBar.Value = 0;
                                        glb_dts_Accounts.dt_acc_TrailBalance.Rows.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Bank Reconcilation
                                else if (Report == enum_ReportName.ST_BankReconcilation)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dts_Accounts.Clear();
                                        glb_dtsReportExport.Clear();

                                        if (txtAcctCode.Tag != null && txtAcctCode.Tag.ToString().Trim().Length > 0)
                                        {
                                            int iCompanyAccount_ID = clsGenaralName.getName_CompanyAccount_IDByGLAccountNo(txtAcctCode.Tag.ToString());
                                            decimal dClosingBalance = 0, dStatementBalance = 0;// dCreditAmount = 0, dDebitAmount = 0,dBalance = 0, dInsertOpanningCreditAmount = 0, dInsertOpanningDebiteAmount = 0,

                                            #region Get Closing Balance
                                            string sQuary = "select opbl from dbo.func_AccountOPBL('1988-8-23','" + dtpTo.Value.ToString("yyyy-MM-dd") + "','" + clsMethods_GL.getFinancialYear_ID(dtpTo.Value.Date) + "','%') where gl_id='" + txtAcctCode.Tag.ToString() + "'";
                                            dClosingBalance = DBHandling.ExecQuery_ReturnDecimal(sQuary);
                                            #endregion

                                            if (txtStatementBalance.Text.Length > 0)
                                                dStatementBalance = decimal.Parse(txtStatementBalance.Text.ToString());

                                            if (iCompanyAccount_ID != -1)
                                            {
                                                #region Inword Cash
                                                foreach (tbl_bpsCashDeposit oCash in tbl_bpsCashDeposit.SelectAll().Where(p => p.CompanyAccount_ID == iCompanyAccount_ID && p.DateDeposit.Date <= dtpTo.Value.Date))
                                                {
                                                    if (oCash.IsReconciled)
                                                    {
                                                        if (oCash.DateReconcilied.Date <= dtpTo.Value.Date)
                                                            continue;
                                                    }

                                                    glb_dts_Accounts.dt_acc_BankReconciliation.Adddt_acc_BankReconciliationRow(oCash.CashDeposit_ID, oCash.DateDeposit, oCash.CashDeposit_ID, "-", oCash.DateDeposit,
                                                   oCash.DateDeposit, oCash.TotalAmount, "", false, false, dClosingBalance, dStatementBalance, false, false, true);
                                                }
                                                #endregion

                                                #region Inword Cheques
                                                foreach (tbl_bpsChequeRegister bpsChequRegister in tbl_bpsChequeRegister.SelectAll().Where(p => p.DateDeposited.Date <= dtpTo.Value.Date && p.ChequeRegister_ID != "default" && (p.Receipt_ID != "default" || p.AccountReceipt_ID != "default")
                                              //   && p.PaymentMethod_ID=PaymentMethod.Cheque 
                                              && p.CompanyAccount_ID == iCompanyAccount_ID && !p.IsDeleted && (p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Deposited) || p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Realized) || p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.ReDeposited)
                                                 || p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C) || p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_O) || p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_R))))
                                                {
                                                    string s = bpsChequRegister.ChequeNumber;
                                                    DateTime dtDocDate = clsSecurity.getServerDateTime();
                                                    string sDocNo = "", sPayeeOrReceivedOf = "";

                                                    if (bpsChequRegister.IsReconcilied || bpsChequRegister.IsReturned)
                                                    {
                                                        if (bpsChequRegister.DateReconcilied.Date <= dtpTo.Value.Date)
                                                            continue;
                                                    }

                                                    #region Receipts
                                                    if (bpsChequRegister.AccountReceipt_ID != "default")
                                                    {
                                                        tbl_accAccountReceipt accAccountReceipt = tbl_accAccountReceipt.Select(bpsChequRegister.AccountReceipt_ID);
                                                        if (accAccountReceipt.AccountReceipt_ID != "default")
                                                        {
                                                            sDocNo = accAccountReceipt.AccountReceipt_ID;
                                                            dtDocDate = accAccountReceipt.AccountReceiptDate;
                                                            sPayeeOrReceivedOf = accAccountReceipt.Receivedof;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        tbl_bpsReceipt bpsReceipt = tbl_bpsReceipt.Select_FromAllReciepts(bpsChequRegister.Receipt_ID);
                                                        if (bpsReceipt.Receipt_ID != "default")
                                                        {
                                                            sDocNo = bpsReceipt.Receipt_ID;
                                                            dtDocDate = bpsReceipt.ReceiptDate;
                                                            sPayeeOrReceivedOf = clsGenaralName.getName_Customer(bpsReceipt.Customer_ID);
                                                        }
                                                    }
                                                    #endregion

                                                    glb_dts_Accounts.dt_acc_BankReconciliation.Adddt_acc_BankReconciliationRow(sDocNo, dtDocDate, bpsChequRegister.ChequeRegister_ID, bpsChequRegister.ChequeNumber, bpsChequRegister.DateCheque,
                                                    bpsChequRegister.DateDeposited, bpsChequRegister.Amount, sPayeeOrReceivedOf, false, false, dClosingBalance, dStatementBalance, false, false, false);
                                                }
                                                #endregion

                                                #region outword Reconcilation
                                                if (chkUseChequeDate.Checked)
                                                {
                                                    foreach (tbl_accChequeRegister accChequeRegister in tbl_accChequeRegister.SelectAll().Where(p => p.DateCheque.Date <= dtpTo.Value.Date && p.ChequeAmount > 0 && p.CompanyAccount_ID == iCompanyAccount_ID && !p.IsDeleted && (p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.New) || p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Realized))))
                                                    {
                                                        if (accChequeRegister.ChequeStatus_ID == "3")
                                                        {
                                                            if (accChequeRegister.ReconcilationDate.Date <= dtpTo.Value.Date)
                                                                continue;
                                                        }

                                                        glb_dts_Accounts.dt_acc_BankReconciliation.Adddt_acc_BankReconciliationRow(accChequeRegister.PaymentVoucher_ID, accChequeRegister.DateCheque, accChequeRegister.ChequeRegister_ID, accChequeRegister.ChequeNumber, accChequeRegister.DateCheque,
                                                                accChequeRegister.DateRegister, accChequeRegister.ChequeAmount, accChequeRegister.Payee, true, false, dClosingBalance, dStatementBalance, false, false, false);
                                                    }
                                                }
                                                else
                                                {
                                                    foreach (tbl_accPaymentVoucher accPV in tbl_accPaymentVoucher.SelectAll().Where(p => p.PaymentVoucherDate.Date <= dtpTo.Value.Date && p.ChequeAmount > 0 && !p.IsDeleted))
                                                    {
                                                        foreach (tbl_accChequeRegister accChequeRegister in tbl_accChequeRegister.SelectAllByPaymentVoucher_ID(accPV.PaymentVoucher_ID).Where(p => p.CompanyAccount_ID == iCompanyAccount_ID && !p.IsDeleted && (p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.New) || p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Realized))))
                                                        {
                                                            if (accChequeRegister.ChequeStatus_ID == "3")
                                                            {
                                                                if (accChequeRegister.ReconcilationDate.Date <= dtpTo.Value.Date)
                                                                    continue;
                                                            }

                                                            glb_dts_Accounts.dt_acc_BankReconciliation.Adddt_acc_BankReconciliationRow(accPV.PaymentVoucher_ID, accPV.PaymentVoucherDate, accChequeRegister.ChequeRegister_ID, accChequeRegister.ChequeNumber, accChequeRegister.DateCheque,
                                                                    accChequeRegister.DateRegister, accChequeRegister.ChequeAmount, accPV.Payee, true, false, dClosingBalance, dStatementBalance, false, false, false);
                                                        }
                                                    }
                                                }
                                                #endregion

                                                #region Adjustment
                                                foreach (tbl_accJournalEntry oJV in tbl_accJournalEntry.SelectAll().Where(p => p.JournalEntry_ID != "default" && p.JournalEntryDate.Date <= dtpTo.Value.Date && !p.IsDeleted))
                                                {
                                                    foreach (tbl_accJournalEntry_Detail oJvDetail in tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(oJV.JournalEntry_ID).Where(p => p.CompanyAccount_ID == iCompanyAccount_ID))//&& !p.IsReconciled
                                                    {
                                                        if (oJvDetail.IsReconciled && oJvDetail.DateReconciled.Date <= dtpTo.Value.Date)
                                                            continue;

                                                        glb_dts_Accounts.dt_acc_BankReconciliation.Adddt_acc_BankReconciliationRow(oJV.JournalEntry_ID, oJV.JournalEntryDate, "", "", oJV.JournalEntryDate, oJV.JournalEntryDate, ((oJvDetail.IsCredit ? -1 : 1) * oJvDetail.Amount), oJvDetail.Remarks == "" ? oJV.Narration : oJvDetail.Remarks, false, true, dClosingBalance, dStatementBalance, oJvDetail.IsCredit, !oJvDetail.IsCredit, false);
                                                    }
                                                }
                                                #endregion

                                                if (glb_dts_Accounts.dt_acc_BankReconciliation.Count == 0)
                                                    glb_dts_Accounts.dt_acc_BankReconciliation.Adddt_acc_BankReconciliationRow("", DateTime.MinValue, "", "", DateTime.MinValue, DateTime.MinValue, 0, "", true, false, dClosingBalance, dStatementBalance, false, false, false);

                                                glb_dts_Accounts.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "Bank Reconciliation", "", dtpTo.Value.ToString("dd MMM yyyy"), clsSecurity.UserNameLoged, "");
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("UserName", clsSecurity.UserNameLoged, true, false);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CurrentFiscalYearDate", clsGenaralName.getName_FinancialYearName(clsMethods_GL.getFinancialYear_ID_Current()), true, false);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("AccountName", txtAcctCode.Text.ToString(), true, false);

                                                frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                                rpt.print(sReportPath, glb_dts_Accounts, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.ST_BankReconcilation));
                                            }
                                            else
                                                MessageBox.Show("GL Account is not linked to bank account");
                                        }
                                        else
                                            MessageBox.Show("Please select a GL Account");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                    finally
                                    {
                                        glb_dts_Accounts.Clear();
                                        glb_dtsReportExport.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Bank Reconcilation old
                                else if (Report == enum_ReportName.ST_BankReconcilationWithoutAdjustment)
                                {
                                    //This is a commen method that can be used in both SEACC and ANJUMAN systems
                                    //2015-03-25
                                    //by Anoj
                                    //
                                    //2015-05-20
                                    //by Priyankara
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dts_Accounts.Clear();
                                        glb_dtsReportExport.Clear();

                                        if (txtAcctCode.Tag != null && txtAcctCode.Tag.ToString().Trim().Length > 0)
                                        {
                                            decimal dCreditAmount = 0, dDebitAmount = 0, dBalance = 0, dInsertOpanningCreditAmount = 0, dInsertOpanningDebiteAmount = 0, dClosingBalance = 0, dStatementBalance = 0;

                                            #region Get Closing Balance
                                            DateTime dtFinancialYearStartDate = clsMethods_GL.getFinancialYear_StartDate(txtFinYear.Tag.ToString());

                                            #region Get user insert Opanning Balance Amount
                                            tbl_accFinancialYearMaster_Month_OpenningBalance opBalanceDetail = tbl_accFinancialYearMaster_Month_OpenningBalance.Select(txtAcctCode.Tag.ToString(), txtFinYear.Tag.ToString(), clsMethods_GL.accountTXNStartMonth());
                                            if (opBalanceDetail != null)
                                            {
                                                if (opBalanceDetail.IsCreditOpening)
                                                    dInsertOpanningCreditAmount = opBalanceDetail.OpeningBalance;
                                                else
                                                    dInsertOpanningDebiteAmount = opBalanceDetail.OpeningBalance;
                                            }
                                            #endregion

                                            foreach (tbl_accGLPosting_Detail GLpostingDetail in tbl_accGLPosting_Detail.SelectAllByGl_ID(txtAcctCode.Tag.ToString())
                                            .Where(p => dtpTo.Value.Date >= p.TransactionDate.Date && p.TransactionDate.Date >= dtFinancialYearStartDate.Date))
                                            {
                                                if (GLpostingDetail.IsCredit)
                                                    dCreditAmount += GLpostingDetail.Amount;
                                                else
                                                    dDebitAmount += GLpostingDetail.Amount;
                                            }
                                            dBalance = (dDebitAmount - dCreditAmount) + (dInsertOpanningDebiteAmount - dInsertOpanningCreditAmount);
                                            dClosingBalance = dBalance;
                                            #endregion
                                            if (txtStatementBalance.Text.Length > 0)
                                                dStatementBalance = decimal.Parse(txtStatementBalance.Text.ToString());

                                            int iBankAccountNumber = -1;
                                            string sBankAccountNumber = "";
                                            foreach (tbl_accGLMaster_Bank detail in tbl_accGLMaster_Bank.SelectAllByGl_ID(txtAcctCode.Tag.ToString()).Where(p => p.AccountNumber != "default"))
                                            {
                                                sBankAccountNumber = detail.AccountNumber;
                                                iBankAccountNumber = clsGenaralName.getName_CompanyAccount_IDByAccountNo(detail.AccountNumber);
                                            }

                                            if (iBankAccountNumber != -1)
                                            {
                                                #region Inword Cheques
                                                foreach (tbl_bpsChequeRegister bpsChequRegister in tbl_bpsChequeRegister.SelectAll().Where(p => p.DateDeposited.Date <= dtpTo.Value.Date && p.ChequeRegister_ID != "default"
                                                && (p.Receipt_ID != "default" || p.AccountReceipt_ID != "default")
                                                && p.DepositedAccountNumber == sBankAccountNumber && !p.IsDeleted
                                                && (p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Deposited) || p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Realized) || p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.ReDeposited)
                                                    || p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C) || p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_O) || p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_R))))
                                                {
                                                    string s = bpsChequRegister.ChequeNumber;
                                                    DateTime dtDocDate = clsSecurity.getServerDateTime();
                                                    string Test = bpsChequRegister.ChequeRegister_ID;
                                                    string sDocNo = "", sPayeeOrReceivedOf = "";

                                                    if (bpsChequRegister.IsReconcilied || bpsChequRegister.IsReturned)
                                                    {
                                                        if (bpsChequRegister.DateReconcilied.Date <= dtpTo.Value.Date)
                                                            continue;
                                                    }

                                                    #region Receipts
                                                    if (bpsChequRegister.AccountReceipt_ID != "default")
                                                    {
                                                        tbl_accAccountReceipt accAccountReceipt = tbl_accAccountReceipt.Select(bpsChequRegister.AccountReceipt_ID);
                                                        if (accAccountReceipt.AccountReceipt_ID != "default")
                                                        {
                                                            sDocNo = accAccountReceipt.AccountReceipt_ID;
                                                            dtDocDate = accAccountReceipt.AccountReceiptDate;
                                                            sPayeeOrReceivedOf = accAccountReceipt.Receivedof;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //tbl_bpsReceipt bpsReceipt = tbl_bpsReceipt.Select(bpsChequRegister.Receipt_ID);
                                                        tbl_bpsReceipt bpsReceipt = tbl_bpsReceipt.Select_FromAllReciepts(bpsChequRegister.Receipt_ID);
                                                        if (bpsReceipt.Receipt_ID != "default")
                                                        {
                                                            sDocNo = bpsReceipt.Receipt_ID;
                                                            dtDocDate = bpsReceipt.ReceiptDate;
                                                            sPayeeOrReceivedOf = clsGenaralName.getName_Customer(bpsReceipt.Customer_ID);
                                                        }
                                                    }
                                                    #endregion

                                                    glb_dts_Accounts.dt_acc_BankReconciliation.Adddt_acc_BankReconciliationRow(sDocNo, dtDocDate, bpsChequRegister.ChequeRegister_ID, bpsChequRegister.ChequeNumber, bpsChequRegister.DateCheque,
                                                    bpsChequRegister.DateDeposited, bpsChequRegister.Amount, sPayeeOrReceivedOf, false, false, dClosingBalance, dStatementBalance, false, false, false);

                                                }
                                                #endregion

                                                #region outword Reconcilation
                                                if (chkUseChequeDate.Checked)
                                                {
                                                    foreach (tbl_accChequeRegister accChequeRegister in tbl_accChequeRegister.SelectAll().Where(p => p.DateCheque.Date <= dtpTo.Value.Date && p.ChequeAmount > 0 && p.CompanyAccount_ID == iBankAccountNumber))//&& !p.IsDeleted && (p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.New) || p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Realized))))
                                                    {
                                                        if (accChequeRegister.ChequeStatus_ID == "3" || accChequeRegister.ChequeStatus_ID == "9" || accChequeRegister.ChequeStatus_ID == "4")//realize
                                                        {
                                                            if (accChequeRegister.ReconcilationDate.Date <= dtpTo.Value.Date)
                                                                continue;
                                                        }
                                                        //else if (accChequeRegister.ChequeStatus_ID == "9")//deleted
                                                        // {
                                                        //     if (accChequeRegister.DateDeleted<= dtpTo.Value.Date)
                                                        //         continue;
                                                        // }
                                                        // else if (accChequeRegister.ChequeStatus_ID == "4")//returned
                                                        // {
                                                        //     if (accChequeRegister.ReconcilationDate <= dtpTo.Value.Date)
                                                        //         continue;
                                                        // }
                                                        glb_dts_Accounts.dt_acc_BankReconciliation.Adddt_acc_BankReconciliationRow(accChequeRegister.PaymentVoucher_ID, accChequeRegister.DateCheque, accChequeRegister.ChequeRegister_ID, accChequeRegister.ChequeNumber, accChequeRegister.DateCheque,
                                                            accChequeRegister.DateRegister, accChequeRegister.ChequeAmount, accChequeRegister.Payee, true, false, dClosingBalance, dStatementBalance, false, false, false);
                                                    }
                                                }
                                                else
                                                {
                                                    #region old
                                                    //foreach (tbl_accPaymentVoucher accPV in tbl_accPaymentVoucher.SelectAll().Where(p => p.PaymentVoucherDate.Date <= dtpTo.Value.Date && p.ChequeAmount > 0 && !p.IsDeleted))
                                                    //{
                                                    //    foreach (tbl_accChequeRegister accChequeRegister in tbl_accChequeRegister.SelectAllByPaymentVoucher_ID(accPV.PaymentVoucher_ID).Where(p => p.AccountNumber == sBankAccountNumber && !p.IsDeleted && (p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.New) || p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Realized))))
                                                    //    {
                                                    //        if (accChequeRegister.IsReconcilied)
                                                    //        {
                                                    //            if (accChequeRegister.ReconcilationDate.Date <= dtpTo.Value.Date)
                                                    //                continue;
                                                    //        }

                                                    //        glb_dts_Accounts.dt_acc_BankReconciliation.Adddt_acc_BankReconciliationRow(accPV.PaymentVoucher_ID, accPV.PaymentVoucherDate, accChequeRegister.ChequeRegister_ID, accChequeRegister.ChequeNumber, accChequeRegister.DateCheque,
                                                    //                accChequeRegister.DateRegister, accChequeRegister.ChequeAmount, accPV.Payee, true, false, dClosingBalance, dStatementBalance);
                                                    //    }
                                                    //} 
                                                    #endregion

                                                    bool bISOK = false;
                                                    //foreach (tbl_accPaymentVoucher accPV in tbl_accPaymentVoucher.SelectAll().Where(p => p.DateDeleted.Date >= dtpFrom.Value.Date && p.ChequeAmount > 0))
                                                    foreach (tbl_accPaymentVoucher accPV in tbl_accPaymentVoucher.SelectAll().Where(p => p.PaymentVoucherDate.Date <= dtpTo.Value.Date && p.ChequeAmount > 0))
                                                    {
                                                        //if (accPV.IsDeleted)
                                                        //{
                                                        //    if (accPV.DateDeleted.Date <= dtpTo.Value.Date)
                                                        //        continue;
                                                        //}
                                                        //else
                                                        //{
                                                        //    if (accPV.PaymentVoucherDate.Date > dtpTo.Value.Date)
                                                        //        continue;
                                                        //}

                                                        //if (bISOK)
                                                        //{
                                                        //foreach (tbl_accChequeRegister accChequeRegister in tbl_accChequeRegister.SelectAllByPaymentVoucher_ID(accPV.PaymentVoucher_ID).Where(p => p.AccountNumber == sBankAccountNumber && !p.IsDeleted && (p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.New) || p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Realized))))
                                                        foreach (tbl_accChequeRegister accChequeRegister in tbl_accChequeRegister.SelectAllByPaymentVoucher_ID(accPV.PaymentVoucher_ID).Where(p => p.CompanyAccount_ID == iBankAccountNumber && (p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.New) || p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Realized) || p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_R) || p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Deleted))))
                                                        {
                                                            //if (!accPV.IsDeleted)
                                                            //    if (accChequeRegister.IsDeleted || accChequeRegister.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Deleted))
                                                            //    continue;

                                                            #region old
                                                            //if (accChequeRegister.IsReconcilied)
                                                            //{
                                                            //    if (accChequeRegister.ReconcilationDate.Date <= dtpTo.Value.Date)
                                                            //        continue;
                                                            //}
                                                            //glb_dts_Accounts.dt_acc_BankReconciliation.Adddt_acc_BankReconciliationRow(accPV.PaymentVoucher_ID, accPV.PaymentVoucherDate, accChequeRegister.ChequeRegister_ID, accChequeRegister.ChequeNumber, accChequeRegister.DateCheque,
                                                            //        accChequeRegister.DateRegister, accChequeRegister.ChequeAmount, accPV.Payee, true, false, dClosingBalance, dStatementBalance); 
                                                            #endregion

                                                            //if (!accChequeRegister.IsReconcilied && !accChequeRegister.IsDeleted)
                                                            //{                                              

                                                            //}

                                                            if (accChequeRegister.ChequeStatus_ID == "3" && !accChequeRegister.IsDeleted)
                                                                if (accChequeRegister.ReconcilationDate.Date <= dtpTo.Value.Date)
                                                                    continue;

                                                            if (accChequeRegister.ChequeStatus_ID == "3" && accChequeRegister.IsDeleted)
                                                                if (accChequeRegister.ReconcilationDate.Date <= dtpTo.Value.Date)
                                                                    continue;

                                                            //if (accChequeRegister.ChequeStatus_ID != "3" && accChequeRegister.IsDeleted)               
                                                            //    continue;

                                                            if (accChequeRegister.ChequeStatus_ID != "3" && accChequeRegister.IsDeleted)
                                                                if (accChequeRegister.ReconcilationDate.Date <= dtpTo.Value.Date)
                                                                    continue;

                                                            glb_dts_Accounts.dt_acc_BankReconciliation.Adddt_acc_BankReconciliationRow(accPV.PaymentVoucher_ID, accPV.PaymentVoucherDate, accChequeRegister.ChequeRegister_ID, accChequeRegister.ChequeNumber, accChequeRegister.DateCheque,
                                                                        accChequeRegister.DateRegister, accChequeRegister.ChequeAmount, accPV.Payee, true, false, dClosingBalance, dStatementBalance, false, false, false);

                                                        }
                                                        //}
                                                    }
                                                }
                                                #endregion

                                                if (glb_dts_Accounts.dt_acc_BankReconciliation.Count == 0)
                                                    glb_dts_Accounts.dt_acc_BankReconciliation.Adddt_acc_BankReconciliationRow("", DateTime.MinValue, "", "", DateTime.MinValue, DateTime.MinValue, 0, "", true, false, dClosingBalance, dStatementBalance, false, false, false);

                                                glb_dts_Accounts.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "Bank Reconciliation", "", dtpTo.Value.ToString("dd MMM yyyy"), clsSecurity.UserNameLoged, "");
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("UserName", clsSecurity.UserNameLoged, true, false);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CurrentFiscalYearDate", clsGenaralName.getName_FinancialYearName(clsMethods_GL.getFinancialYear_ID_Current()), true, false);
                                                //  glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("LastFiscalYearDate", clsGenaralName.getName_FinancialYearName(clsMethods_Fin.getLastFinanceYearID()), true,false);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("AccountName", txtAcctCode.Text.ToString(), true, false);

                                                frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                                rpt.print(sReportPath, glb_dts_Accounts, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                            }
                                            else
                                                MessageBox.Show("GL Account is not linked to bank account");
                                        }
                                        else
                                            MessageBox.Show("Please select a GL Account");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                    finally
                                    {
                                        glb_dts_Accounts.Clear();
                                        glb_dtsReportExport.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Sub Account statement
                                else if (Report == enum_ReportName.ST_SubAcc1Statement)
                                {
                                    sFormula = " {vw_rpt_accPaymentVoucher_SubTotal.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_accPaymentVoucher_SubTotal.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                    if (bCostCenter1)
                                        sFormula += " and {vw_rpt_accPaymentVoucher_SubTotal.costCenter1_ID} = '" + txtCostCenter1.Tag.ToString().Trim() + "'";

                                    print(sReportPath, sReportTitle_Main, sFormula);
                                }
                                #endregion

                                #region Sub Account vise
                                else if (Report == enum_ReportName.ST_SubAcc1Statement)
                                {
                                    sFormula = " {vw_rpt_accGLPosting.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_accGLPosting.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                                    if (bCostCenter1)
                                        sFormula += " and {vw_rpt_accGLPosting.costCenter1_ID} = '" + txtCostCenter1.Tag.ToString().Trim() + "'";
                                    if (bSubAcc2Selected)
                                        sFormula += " and {vw_rpt_accGLPosting.costCenter2_ID} = '" + txtSubAcct2.Tag.ToString().Trim() + "'";

                                    print("\\Reports\\ACC\\Common\\SubAccountReport.rpt", "Sub Accounts Wise Report", sFormula);
                                }
                                #endregion

                                #region GL CodeVise sub Accounts
                                else if (Report == enum_ReportName.ST_GLCodeWise_SubAccounts)
                                {
                                    string transactionID = "";
                                    glb_dts_Accounts.dts_acc_GL_SubAcctWise.Clear();

                                    bool bSubAccount1_Selected = (txtCostCenter1.Tag != null && txtCostCenter1.Tag.ToString().Trim().Length > 0) ? true : false;
                                    bool bSubAccount2_Selected = (txtSubAcct2.Tag != null && txtSubAcct2.Tag.ToString().Trim().Length > 0) ? true : false;
                                    bool bEmployee_Selected = (txtEmployee.Tag != null && txtEmployee.Tag.ToString().Trim().Length > 0) ? true : false;
                                    decimal dCreditAmount = 0, dDebitAmount = 0, dBalance = 0;

                                    #region Acc. code
                                    if (txtAcctCode.Tag != null && txtAcctCode.Tag.ToString().Trim().Length > 0)
                                    {
                                        List<tbl_accGLPosting_Detail> oGLPostingDetails = tbl_accGLPosting_Detail.SelectAllByGl_ID(txtAcctCode.Tag.ToString()).
                                            Where(p => p.TransactionDate >= dtpFrom.Value.Date && p.TransactionDate <= dtpTo.Value.Date &&
                                                (p.Employee_ID != "default" || p.CostCenter1_ID != "default" || p.CostCenter2_ID != "default")).ToList();
                                        foreach (tbl_accGLPosting_Detail oGLPostingDetail in oGLPostingDetails)
                                        {
                                            bool bOK_Subacount1 = true, bOK_Subacount2 = true, bOK_Employee = true;
                                            string sSubAcountName = "", sAccountName = txtAcctCode.Text.Trim();
                                            if (bSubAccount1_Selected)
                                                bOK_Subacount1 = oGLPostingDetail.CostCenter1_ID == txtCostCenter1.Tag.ToString().Trim() ? true : false;
                                            if (bSubAccount2_Selected)
                                                bOK_Subacount2 = oGLPostingDetail.CostCenter2_ID == txtSubAcct2.Tag.ToString().Trim() ? true : false;
                                            if (bEmployee_Selected)
                                                bOK_Employee = oGLPostingDetail.Employee_ID == txtEmployee.Tag.ToString().Trim() ? true : false;

                                            sSubAcountName = "";
                                            sSubAcountName = oGLPostingDetail.CostCenter1_ID != "default" ? clsGenaralName.getName_AccCostCenter1(oGLPostingDetail.CostCenter1_ID) + " : " : "";
                                            sSubAcountName += oGLPostingDetail.CostCenter2_ID != "default" ? clsGenaralName.getName_AccCostCenter2(oGLPostingDetail.CostCenter2_ID) + " : " : "";
                                            sSubAcountName += oGLPostingDetail.Employee_ID != "default" ? clsGenaralName.getName_Employee(oGLPostingDetail.Employee_ID) + " : " : "";

                                            if (bOK_Subacount1 && bOK_Subacount2 && bOK_Employee)
                                            {
                                                decimal dCredit = 0, dDebit = 0;
                                                bool bIsCredit = false;
                                                if (oGLPostingDetail.IsCredit)
                                                {
                                                    dCredit = oGLPostingDetail.Amount;
                                                    dCreditAmount += oGLPostingDetail.Amount;
                                                }
                                                else
                                                {
                                                    dDebit = oGLPostingDetail.Amount;
                                                    dDebitAmount += oGLPostingDetail.Amount;
                                                }
                                                dBalance = dCreditAmount - dDebitAmount;
                                                if (dBalance > 0)
                                                    bIsCredit = true;
                                                else
                                                    dBalance = dBalance * (-1);

                                                if (oGLPostingDetail.Cheq_No.Length > 0 && oGLPostingDetail.Cheq_No != "default")
                                                {
                                                    if (oGLPostingDetail.Customer_ID == "default")
                                                    {
                                                        tbl_accChequeRegister accCheckRegister = tbl_accChequeRegister.Select(oGLPostingDetail.Transaction_ID);
                                                        tbl_bpsChequeRegister bpsCheckRegister = tbl_bpsChequeRegister.Select(oGLPostingDetail.Transaction_ID);
                                                        if ((accCheckRegister != null && accCheckRegister.ChequeRegister_ID != "default"))
                                                            transactionID = accCheckRegister.PaymentVoucher_ID;
                                                        else if ((bpsCheckRegister != null && bpsCheckRegister.ChequeRegister_ID != "default"))
                                                            transactionID = bpsCheckRegister.Receipt_ID;
                                                        else
                                                            transactionID = oGLPostingDetail.Transaction_ID;
                                                    }
                                                }

                                                tbl_accGLPosting oGLPosting = tbl_accGLPosting.Select(oGLPostingDetail.GlPosting_ID);
                                                if (oGLPosting != null)
                                                    glb_dts_Accounts.dts_acc_GL_SubAcctWise.Adddts_acc_GL_SubAcctWiseRow(sAccountName, sSubAcountName, oGLPosting.TransactionDate, transactionID, oGLPostingDetail.Cheq_No, oGLPostingDetail.Narration, oGLPostingDetail.Remark, dDebit, dCredit, dBalance, bIsCredit);
                                            }
                                            clsHelpMethods.startProgressBar(0, oGLPostingDetails.Count + 2, 1, ProgressBar);
                                        }

                                        glb_dts_Accounts.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDaterange, clsSecurity.UserNameLoged, "");
                                        //print("\\Reports\\ACC\\Common\\GLCodeWiseSubAccountsReport_AccCodeWise.rpt", " GL Code Wise Sub Accounts Transactions ", glb_dts_Accounts.dts_acc_GL_SubAcctWise, "", clsAutocode.getReportID(enum_ReportName.ST_GLCodeWise_SubAccounts));
                                        print("\\Reports\\ACC\\Common\\GLCodeWiseSubAccountsReport_AccCodeWise.rpt", " GL Code Wise Sub Accounts Transactions ", glb_dts_Accounts, "", clsAutocode.getReportID(enum_ReportName.ST_GLCodeWise_SubAccounts));
                                    }
                                    #endregion

                                    #region Without Acc. code
                                    else
                                    {
                                        List<tbl_accGLPosting_Detail> oGLPostingDetails = new List<tbl_accGLPosting_Detail>();
                                        string sSubAcountName = "";
                                        if (bSubAccount1_Selected && !bSubAccount2_Selected && !bEmployee_Selected)
                                        {
                                            sSubAcountName = txtCostCenter1.Text.Trim();
                                            oGLPostingDetails = tbl_accGLPosting_Detail.SelectAllByCostCenter1_ID(txtCostCenter1.Tag.ToString()).Where(p => p.TransactionDate.Date >= dtpFrom.Value.Date && p.TransactionDate.Date <= dtpTo.Value.Date).ToList();
                                        }
                                        else if (!bSubAccount1_Selected && bSubAccount2_Selected && !bEmployee_Selected)
                                        {
                                            sSubAcountName = txtSubAcct2.Text.Trim();
                                            oGLPostingDetails = tbl_accGLPosting_Detail.SelectAllByCostCenter1_ID(txtSubAcct2.Tag.ToString()).Where(p => p.TransactionDate.Date >= dtpFrom.Value.Date && p.TransactionDate.Date <= dtpTo.Value.Date).ToList();
                                        }
                                        else if (!bSubAccount1_Selected && !bSubAccount2_Selected && bEmployee_Selected)
                                        {
                                            sSubAcountName = txtEmployee.Text.Trim();
                                            oGLPostingDetails = tbl_accGLPosting_Detail.SelectAllByEmployee_ID(txtEmployee.Tag.ToString()).Where(p => p.TransactionDate.Date >= dtpFrom.Value.Date && p.TransactionDate.Date <= dtpTo.Value.Date).ToList();
                                        }
                                        else
                                        {
                                            sSubAcountName = txtEmployee.Text.Trim();
                                            oGLPostingDetails = tbl_accGLPosting_Detail.SelectAll().Where(p => p.TransactionDate.Date >= dtpFrom.Value.Date && p.TransactionDate.Date <= dtpTo.Value.Date && !p.IsCanceled).OrderBy(p => p.GlPosting_ID).ToList();
                                        }

                                        foreach (tbl_accGLPosting_Detail oGLPostingDetail in oGLPostingDetails)
                                        {
                                            bool bOK_Subacount1 = true, bOK_Subacount2 = true, bOK_Employee = true;
                                            if (bSubAccount1_Selected)
                                            {
                                                sSubAcountName = txtCostCenter1.Text.Trim() + " : ";
                                                bOK_Subacount1 = oGLPostingDetail.CostCenter1_ID == txtCostCenter1.Tag.ToString().Trim() ? true : false;
                                            }
                                            if (bSubAccount2_Selected)
                                            {
                                                sSubAcountName = txtSubAcct2.Text.Trim() + " : ";
                                                bOK_Subacount2 = oGLPostingDetail.CostCenter2_ID == txtSubAcct2.Tag.ToString().Trim() ? true : false;
                                            }
                                            if (bEmployee_Selected)
                                            {
                                                sSubAcountName = txtEmployee.Text.Trim() + " : ";
                                                bOK_Employee = oGLPostingDetail.Employee_ID == txtEmployee.Tag.ToString().Trim() ? true : false;
                                            }

                                            if (bOK_Subacount1 && bOK_Subacount2 && bOK_Employee)
                                            {
                                                decimal dCredit = 0, dDebit = 0;
                                                bool bIsCredit = false;
                                                if (oGLPostingDetail.IsCredit)
                                                {
                                                    dCredit = oGLPostingDetail.Amount;
                                                    dCreditAmount += oGLPostingDetail.Amount;
                                                }
                                                else
                                                {
                                                    dDebit = oGLPostingDetail.Amount;
                                                    dDebitAmount += oGLPostingDetail.Amount;
                                                }
                                                dBalance = dCreditAmount - dDebitAmount;
                                                if (dBalance > 0)
                                                    bIsCredit = true;
                                                else
                                                    dBalance = dBalance * (-1);

                                                tbl_accGLPosting oGLPosting = tbl_accGLPosting.Select(oGLPostingDetail.GlPosting_ID);

                                                if (oGLPostingDetail.Cheq_No.Length > 0 && oGLPostingDetail.Cheq_No != "default")
                                                {
                                                    tbl_accChequeRegister accCheckRegister = tbl_accChequeRegister.Select(oGLPostingDetail.Transaction_ID);
                                                    tbl_bpsChequeRegister bpsCheckRegister = tbl_bpsChequeRegister.Select(oGLPostingDetail.Transaction_ID);
                                                    if ((accCheckRegister != null && accCheckRegister.ChequeRegister_ID != "default"))
                                                        transactionID = accCheckRegister.PaymentVoucher_ID;
                                                    else if ((bpsCheckRegister != null && bpsCheckRegister.ChequeRegister_ID != "default"))
                                                        transactionID = bpsCheckRegister.Receipt_ID;
                                                    else
                                                        transactionID = oGLPostingDetail.Transaction_ID;
                                                }
                                                if (oGLPosting != null)
                                                    glb_dts_Accounts.dts_acc_GL_SubAcctWise.Adddts_acc_GL_SubAcctWiseRow(clsGenaralName.getName_AccountName(oGLPostingDetail.Gl_ID), sSubAcountName, oGLPosting.TransactionDate, transactionID, oGLPostingDetail.Cheq_No, oGLPostingDetail.Narration, oGLPostingDetail.Remark, dDebit, dCredit, dBalance, bIsCredit);

                                            }
                                        }
                                        //clsHelpMethods.startProgressBar(0, oGLPostingDetails.Count + 2, 1, ProgressBar);
                                        glb_dts_Accounts.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDaterange, clsSecurity.UserNameLoged, "");
                                        ProgressBar.Value = 0;
                                        //print(sRptPath, " GL Code Wise Sub Accounts Transactions ", glb_dts_Accounts.dts_acc_GL_SubAcctWise, "", clsAutocode.getReportID(enum_ReportName.ST_GLCodeWise_SubAccounts));
                                        print(sReportPath, " GL Code Wise Sub Accounts Transactions ", glb_dts_Accounts, "", clsAutocode.getReportID(enum_ReportName.ST_GLCodeWise_SubAccounts));
                                    }
                                    #endregion
                                }
                                #endregion

                                #region Budget Planing
                                else if (Report == enum_ReportName.ST_Acc_BudgetPlaningMonthWise)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        string sFillter = "";
                                        decimal dAnnual = 0;

                                        #region Fillter Info
                                        if (txtFinYear.Tag != null)
                                            if (sFillter != "" && sFillter.Length > 0)
                                                sFillter += txtFinYear.Text;
                                            else
                                                sFillter = txtFinYear.Text;
                                        #endregion

                                        if (txtFinYear.Tag != null)
                                        {
                                            tbl_accBudget oHeader = tbl_accBudget.Select(txtFinYear.Tag.ToString());
                                            if (oHeader != null && !oHeader.IsDeleted && oHeader.FinancialYear_ID != "default")
                                            {
                                                foreach (tbl_accBudget_detail odetail in tbl_accBudget_detail.SelectAll().Where(p => p.FinancialYear_ID == oHeader.FinancialYear_ID.ToString().Trim()))
                                                {
                                                    tbl_accGLMaster oGl_Code = tbl_accGLMaster.Select(odetail.Gl_ID);
                                                    if (oGl_Code != null)
                                                    {
                                                        tbl_zAccGLMaster_AccountType oAccountType = tbl_zAccGLMaster_AccountType.Select(oGl_Code.GlAccountType_ID);
                                                        if (oAccountType != null)
                                                        {
                                                            tbl_zAccGLMaster_SubCatagory oAccountSubType = tbl_zAccGLMaster_SubCatagory.Select(oAccountType.GlSubCatagory_ID);
                                                            if (oAccountSubType != null)
                                                            {
                                                                #region Selected Filters
                                                                if (bAcctCodeSelected)
                                                                    if (odetail.Gl_ID != txtAcctCode.Tag.ToString())
                                                                        continue;
                                                                //if (bAcctCodeTypeCode)
                                                                //    if (oAccountType.GlAccountType_ID != txtAcctCodeTypeCode.Tag.ToString())
                                                                //        continue;
                                                                if (bSubGlCodeSelected)
                                                                    if (oAccountType.GlSubCatagory_ID != txtSubGlCode.Tag.ToString())
                                                                        continue;
                                                                if (bMainGlCodeSelected)
                                                                    if (oAccountSubType.GlMainCatagory_ID != txtMainGlCode.Tag.ToString())
                                                                        continue;
                                                                #endregion

                                                                #region Fillter Not budgeted Data
                                                                if (chk_HideZeroAmount.Checked)
                                                                {
                                                                    if (odetail.Value_Jan == 0 && odetail.Value_Feb == 0 && odetail.Value_Mar == 0 && odetail.Value_Apr == 0 &&
                                                                        odetail.Value_May == 0 && odetail.Value_Jun == 0 && odetail.Value_Jul == 0 && odetail.Value_Aug == 0 &&
                                                                        odetail.Value_Sep == 0 && odetail.Value_Oct == 0 && odetail.Value_Nov == 0 && odetail.Value_Dec == 0)
                                                                    {
                                                                        continue;
                                                                    }

                                                                }
                                                                #endregion

                                                                glb_dts_accBudget.dt_BudgetPlan.Adddt_BudgetPlanRow(odetail.Gl_ID, clsGenaralName.getName_AccountName(odetail.Gl_ID), odetail.RevisionCount,
                                                                    odetail.Value_Jan, odetail.Value_Feb, odetail.Value_Mar, odetail.Value_Apr, odetail.Value_May, odetail.Value_Jun, odetail.Value_Jul,
                                                                    odetail.Value_Aug, odetail.Value_Sep, odetail.Value_Oct, odetail.Value_Nov, odetail.Value_Dec,
                                                                    odetail.Value_Quarter_1, odetail.Value_Quarter_2, odetail.Value_Quarter_3, 0, odetail.Value_Year);
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            glb_dts_accBudget.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDaterange, clsSecurity.UserNameLoged, "For the financial year - " + sFillter + " " + sFilterBy);

                                            frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                            rpt.print(sReportPath, glb_dts_accBudget, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                        }
                                        else
                                        {
                                            MessageBox.Show("Please Select Financial Year.....!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                        glb_dts_accBudget.Clear();
                                    }
                                    //  }
                                    //   else
                                    //  {
                                    //  }
                                }
                                #endregion

                                #region Budget Variance
                                else if (Report == enum_ReportName.ST_Acc_BudgetPlaningQuarterWise)
                                {
                                    #region For Single GL Account
                                    if (txtAcctCode.Tag != null && txtAcctCode.Tag.ToString().Length > 0)
                                    {
                                        if (txtFinYear.Tag != null && txtFinYear.Tag.ToString().Length > 0)
                                        {
                                            try
                                            {
                                                Cursor = Cursors.WaitCursor;
                                                glb_dts_accBudget.Clear();
                                                string sFillter = "";

                                                #region Fillter Info
                                                if (txtFinYear.Tag != null)
                                                    if (sFillter != "" && sFillter.Length > 0)
                                                        sFillter += txtFinYear.Text;
                                                    else
                                                        sFillter = txtFinYear.Text;
                                                #endregion

                                                tbl_accBudget oBudget = tbl_accBudget.Select(txtFinYear.Tag.ToString());
                                                if (oBudget != null && !oBudget.IsDeleted && oBudget.FinancialYear_ID != "default")
                                                {
                                                    #region Fill Details
                                                    decimal dJan = 0, dFeb = 0, dMar = 0, dApr = 0, dMay = 0, dJun = 0, dJul = 0, dAug = 0, dSep = 0, dOct = 0, dNov = 0, dDec = 0;

                                                    DateTime dtFinancialYearStartDate = clsMethods_GL.getFinancialYear_StartDate(txtFinYear.Tag.ToString());
                                                    DateTime dtFinancialYearEndDate = clsMethods_GL.getFinancialYear_EndtDate(txtFinYear.Tag.ToString());
                                                    foreach (tbl_accGLPosting_Detail oPosting in tbl_accGLPosting_Detail.SelectAllByGl_ID(txtAcctCode.Tag.ToString()).Where(p => p.TransactionDate.Date >= dtFinancialYearStartDate && p.TransactionDate.Date <= dtFinancialYearEndDate && !p.IsCanceled))
                                                    {
                                                        #region  Assigning Posting amount to Relevent Month
                                                        int iMontNo = oPosting.TransactionDate.Month;
                                                        switch (iMontNo)
                                                        {
                                                            case 1:
                                                                dJan += oPosting.Amount;
                                                                break;
                                                            case 2:
                                                                dFeb += oPosting.Amount;
                                                                break;
                                                            case 3:
                                                                dMar += oPosting.Amount;
                                                                break;
                                                            case 4:
                                                                dApr += oPosting.Amount;
                                                                break;
                                                            case 5:
                                                                dMay += oPosting.Amount;
                                                                break;
                                                            case 6:
                                                                dJun += oPosting.Amount;
                                                                break;
                                                            case 7:
                                                                dJul += oPosting.Amount;
                                                                break;
                                                            case 8:
                                                                dAug += oPosting.Amount;
                                                                break;
                                                            case 9:
                                                                dSep += oPosting.Amount;
                                                                break;
                                                            case 10:
                                                                dOct += oPosting.Amount;
                                                                break;
                                                            case 11:
                                                                dNov += oPosting.Amount;
                                                                break;
                                                            case 12:
                                                                dDec += oPosting.Amount;
                                                                break;
                                                        }
                                                        #endregion
                                                    }

                                                    foreach (tbl_accBudget_detail odetail in tbl_accBudget_detail.SelectAll().Where(p => p.Gl_ID == txtAcctCode.Tag.ToString() && p.FinancialYear_ID == oBudget.FinancialYear_ID))
                                                    {
                                                        for (int icount = 1; icount <= 12; icount++)
                                                        {
                                                            decimal dMonthValue = 0, dVariance = 0, dActualAmount = 0;
                                                            string sMonth = "";

                                                            #region Select Value
                                                            switch (icount)
                                                            {
                                                                case 1:
                                                                    dMonthValue = odetail.Value_Jan;
                                                                    sMonth = "January";
                                                                    dActualAmount = dJan;
                                                                    break;
                                                                case 2:
                                                                    dMonthValue = odetail.Value_Feb;
                                                                    sMonth = "February";
                                                                    dActualAmount = dFeb;
                                                                    break;
                                                                case 3:
                                                                    dMonthValue = odetail.Value_Mar;
                                                                    sMonth = "March";
                                                                    dActualAmount = dMar;
                                                                    break;
                                                                case 4:
                                                                    dMonthValue = odetail.Value_Apr;
                                                                    sMonth = "April";
                                                                    dActualAmount = dApr;
                                                                    break;
                                                                case 5:
                                                                    dMonthValue = odetail.Value_May;
                                                                    sMonth = "May";
                                                                    dActualAmount = dMay;
                                                                    break;
                                                                case 6:
                                                                    dMonthValue = odetail.Value_Jun;
                                                                    sMonth = "June";
                                                                    dActualAmount = dJun;
                                                                    break;
                                                                case 7:
                                                                    dMonthValue = odetail.Value_Jul;
                                                                    sMonth = "July";
                                                                    dActualAmount = dJul;
                                                                    break;
                                                                case 8:
                                                                    dMonthValue = odetail.Value_Aug;
                                                                    sMonth = "August";
                                                                    dActualAmount = dAug;
                                                                    break;
                                                                case 9:
                                                                    dMonthValue = odetail.Value_Sep;
                                                                    sMonth = "September";
                                                                    dActualAmount = dSep;
                                                                    break;
                                                                case 10:
                                                                    dMonthValue = odetail.Value_Oct;
                                                                    sMonth = "October";
                                                                    dActualAmount = dOct;
                                                                    break;
                                                                case 11:
                                                                    dMonthValue = odetail.Value_Nov;
                                                                    sMonth = "November";
                                                                    dActualAmount = dNov;
                                                                    break;
                                                                case 12:
                                                                    dMonthValue = odetail.Value_Dec;
                                                                    sMonth = "December";
                                                                    dActualAmount = dDec;
                                                                    break;
                                                            }
                                                            #endregion

                                                            dVariance = dActualAmount - dMonthValue;
                                                            glb_dts_accBudget.dt_BudgetVariance.Adddt_BudgetVarianceRow(odetail.Gl_ID, sMonth, dMonthValue, dActualAmount, dVariance, 0);
                                                        }
                                                    }
                                                    #endregion
                                                }

                                                //print("\\Reports\\ACC\\rpt_accBudgetVariance.rpt", "Budget Variance Analysis (Single GL Account)", glb_dts_accBudget.dt_BudgetVariance, "");

                                                glb_dts_accBudget.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDaterange, clsSecurity.UserNameLoged, "For the financial year - " + sFillter + " " + sFilterBy);

                                                frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                                rpt.print(sReportPath, glb_dts_accBudget, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.ST_Acc_BudgetPlaningMonthWise));
                                            }
                                            catch (Exception ex)
                                            {
                                                clsValidate.WriteErrorLog("", iFormID, ex);
                                                SEACCException.Show(ex);
                                            }
                                            finally
                                            {
                                                Cursor = Cursors.Default;
                                                glb_dts_accBudget.Clear();
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Please Select Financial Year.....!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    #endregion

                                    #region All Details
                                    else
                                    {
                                        try
                                        {
                                            //  if (rdoQuarterly.Checked || rdoMonthly.Checked)
                                            //   {
                                            bool isRedeyty = true;
                                            string sFillter = "";
                                            if (txtFinYear.Tag != null && txtFinYear.Tag.ToString().Length > 0)
                                            {
                                                Cursor = Cursors.WaitCursor;
                                                glb_dts_accBudget.Clear();

                                                #region Fillter Info
                                                if (txtFinYear.Tag != null)
                                                    if (sFillter != "" && sFillter.Length > 0)
                                                        sFillter += txtFinYear.Text;
                                                    else
                                                        sFillter = txtFinYear.Text;
                                                #endregion

                                                DateTime dtFinancialYearStartDate = clsMethods_GL.getFinancialYear_StartDate(txtFinYear.Tag.ToString());
                                                DateTime dtFinancialYearEndDate = clsMethods_GL.getFinancialYear_EndtDate(txtFinYear.Tag.ToString());
                                                tbl_accBudget oBudget = tbl_accBudget.Select(txtFinYear.Tag.ToString());
                                                if (oBudget != null && !oBudget.IsDeleted && oBudget.FinancialYear_ID != "default")
                                                {
                                                    foreach (tbl_accBudget_detail odetail in tbl_accBudget_detail.SelectAll().Where(p => p.FinancialYear_ID == oBudget.FinancialYear_ID.ToString().Trim()))
                                                    {
                                                        decimal dJan = 0, dFeb = 0, dMar = 0, dApr = 0, dMay = 0, dJun = 0, dJul = 0, dAug = 0, dSep = 0, dOct = 0, dNov = 0, dDec = 0;
                                                        decimal dJanVar = 0, dFebVar = 0, dMarVar = 0, dAprVar = 0, dMayVar = 0, dJunVar = 0, dJullVar = 0, dAugVar = 0, dSepVar = 0, dOctVar = 0, dNovVar = 0, dDecVar = 0;

                                                        #region Fillter Not budgeted Data
                                                        if (chk_HideZeroAmount.Checked)
                                                        {
                                                            if (odetail.Value_Jan == 0 && odetail.Value_Feb == 0 && odetail.Value_Mar == 0 && odetail.Value_Apr == 0 &&
                                                                odetail.Value_May == 0 && odetail.Value_Jun == 0 && odetail.Value_Jul == 0 && odetail.Value_Aug == 0 &&
                                                                odetail.Value_Sep == 0 && odetail.Value_Oct == 0 && odetail.Value_Nov == 0 && odetail.Value_Dec == 0)
                                                            {
                                                                continue;
                                                            }
                                                        }
                                                        //if (rdoQuarterly.Checked)
                                                        //{
                                                        //    if (odetail.Value_Quarter_1 == 0 && odetail.Value_Quarter_2 == 0 && odetail.Value_Quarter_3 == 0)
                                                        //    {
                                                        //        continue;
                                                        //    }
                                                        //}
                                                        #endregion

                                                        foreach (tbl_accGLPosting_Detail oPosting in tbl_accGLPosting_Detail.SelectAllByGl_ID(odetail.Gl_ID).Where(p => p.TransactionDate.Date >= dtFinancialYearStartDate && p.TransactionDate.Date <= dtFinancialYearEndDate && !p.IsCanceled))
                                                        {
                                                            #region  Assigning Posting amount to Relevent Month
                                                            int iMontNo = oPosting.TransactionDate.Month;
                                                            switch (iMontNo)
                                                            {
                                                                case 1:
                                                                    dJan += oPosting.Amount;
                                                                    break;
                                                                case 2:
                                                                    dFeb += oPosting.Amount;
                                                                    break;
                                                                case 3:
                                                                    dMar += oPosting.Amount;
                                                                    break;
                                                                case 4:
                                                                    dApr += oPosting.Amount;
                                                                    break;
                                                                case 5:
                                                                    dMay += oPosting.Amount;
                                                                    break;
                                                                case 6:
                                                                    dJun += oPosting.Amount;
                                                                    break;
                                                                case 7:
                                                                    dJul += oPosting.Amount;
                                                                    break;
                                                                case 8:
                                                                    dAug += oPosting.Amount;
                                                                    break;
                                                                case 9:
                                                                    dSep += oPosting.Amount;
                                                                    break;
                                                                case 10:
                                                                    dOct += oPosting.Amount;
                                                                    break;
                                                                case 11:
                                                                    dNov += oPosting.Amount;
                                                                    break;
                                                                case 12:
                                                                    dDec += oPosting.Amount;
                                                                    break;
                                                            }
                                                            #endregion
                                                        }

                                                        #region Commented
                                                        //foreach (tbl_accBudget_detail odetailes in tbl_accBudget_detail.SelectAll().Where(p => p.Gl_ID == odetail.Gl_ID && p.FinancialYear_ID == oHeaderes.FinancialYear_ID.ToString().Trim()))
                                                        //{
                                                        //    #region Fillter Not budgeted Data
                                                        //    //  if (rdoMonthly.Checked)
                                                        //    //{
                                                        //    if (odetailes.Value_Jan == 0 && odetailes.Value_Feb == 0 && odetailes.Value_Mar == 0 && odetailes.Value_Apr == 0 &&
                                                        //        odetailes.Value_May == 0 && odetailes.Value_Jun == 0 && odetailes.Value_Jul == 0 && odetailes.Value_Aug == 0 &&
                                                        //        odetailes.Value_Sep == 0 && odetailes.Value_Oct == 0 && odetailes.Value_Nov == 0 && odetailes.Value_Dec == 0)
                                                        //    {
                                                        //        continue;
                                                        //    }
                                                        //    //}
                                                        //    //if (rdoQuarterly.Checked)
                                                        //    //{
                                                        //    //    if (odetailes.Value_Quarter_1 == 0 && odetailes.Value_Quarter_2 == 0 && odetailes.Value_Quarter_3 == 0)
                                                        //    //    {
                                                        //    //        continue;
                                                        //    //    }
                                                        //    //}
                                                        //    #endregion

                                                        //    #region Commented
                                                        //    for (int icount = 1; icount <= 12; icount++)
                                                        //    {
                                                        //        //decimal dMonthValue = 0, dVariance = 0, dActualAmount = 0;
                                                        //        // decimal dJanAcc, dFebAcc, dMarAcc, dAprAcc, dMayAcc, dJunAcc, dJullAcc, dAugAcc, dSepAcc, dOctAcc, dNovAcc, dDecAcc;                                         
                                                        //        // string sMonth = "";

                                                        //        //#region Select Value
                                                        //        //switch (icount)
                                                        //        //{
                                                        //        //    case 1:
                                                        //        //        sMonth = "January";
                                                        //        //        dJanVar = dJan - odetail.Value_Jan;
                                                        //        //        break;
                                                        //        //    case 2:
                                                        //        //        sMonth = "February";
                                                        //        //        dFebVar = dFeb - odetail.Value_Feb;
                                                        //        //        break;
                                                        //        //    case 3:
                                                        //        //        sMonth = "March";
                                                        //        //        dMarVar = dMar - odetail.Value_Mar;
                                                        //        //        break;
                                                        //        //    case 4:
                                                        //        //        sMonth = "April";
                                                        //        //        dAprVar = dApr - odetail.Value_Apr;
                                                        //        //        break;
                                                        //        //    case 5:
                                                        //        //        sMonth = "May";
                                                        //        //        dMayVar = dMay - odetail.Value_May;
                                                        //        //        break;
                                                        //        //    case 6:
                                                        //        //        sMonth = "June";
                                                        //        //        dJunVar = dJun - odetail.Value_Jun;
                                                        //        //        break;
                                                        //        //    case 7:
                                                        //        //        sMonth = "July";
                                                        //        //        dJullVar = dJul - odetail.Value_Jul;
                                                        //        //        break;
                                                        //        //    case 8:
                                                        //        //        sMonth = "August";
                                                        //        //        dAugVar = dAug - odetail.Value_Aug;
                                                        //        //        break;
                                                        //        //    case 9:
                                                        //        //        sMonth = "September";
                                                        //        //        dSepVar = dSep - odetail.Value_Sep;
                                                        //        //        break;
                                                        //        //    case 10:
                                                        //        //        sMonth = "October";
                                                        //        //        dOctVar = dOct - odetail.Value_Oct;
                                                        //        //        break;
                                                        //        //    case 11:
                                                        //        //        sMonth = "November";
                                                        //        //        dNovVar = dNov - odetail.Value_Nov;
                                                        //        //        break;
                                                        //        //    case 12:
                                                        //        //        sMonth = "December";
                                                        //        //        dDecVar = dDec - odetail.Value_Dec;
                                                        //        //        break;
                                                        //        //}
                                                        //        //#endregion
                                                        //    }
                                                        //    #endregion

                                                        //    dJanVar = 0; dFebVar = 0; dMarVar = 0; dAprVar = 0; dMayVar = 0; dJunVar = 0; dJullVar = 0; dAugVar = 0; dSepVar = 0; dOctVar = 0; dNovVar = 0; dDecVar = 0;
                                                        //} 
                                                        #endregion

                                                        glb_dts_accBudget.dt_BudgetVarianceMonthWise.Adddt_BudgetVarianceMonthWiseRow(odetail.Gl_ID,
                                                                dJan, dFeb, dMar, dApr, dMay, dJun, dJul, dAug, dSep, dOct, dNov, dDec,
                                                                dJanVar, dFebVar, dMarVar, dAprVar, dMayVar, dJunVar, dJullVar, dAugVar, dSepVar, dOctVar, dNovVar, dDecVar);

                                                        glb_dts_accBudget.dt_BudgetPlan.Adddt_BudgetPlanRow(odetail.Gl_ID, clsGenaralName.getName_AccountName(odetail.Gl_ID), odetail.RevisionCount,
                                                            odetail.Value_Jan, odetail.Value_Feb, odetail.Value_Mar, odetail.Value_Apr, odetail.Value_May, odetail.Value_Jun, odetail.Value_Jul, odetail.Value_Aug,
                                                            odetail.Value_Sep, odetail.Value_Oct, odetail.Value_Nov, odetail.Value_Dec, odetail.Value_Quarter_1, odetail.Value_Quarter_2, odetail.Value_Quarter_3, 0,
                                                            odetail.Value_Year);
                                                    }
                                                }
                                                sReportPath = "\\Reports\\ACC\\rpt_accBudgetVarianceAnalysis_Monthly.rpt";
                                                sReportTitle_Main = "Budget Variance Analysis (All GL Accounts - Monthly)";

                                                glb_dts_accBudget.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDaterange, clsSecurity.UserNameLoged, "For the financial year - " + sFillter + " " + sFilterBy);

                                                frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                                rpt.print(sReportPath, glb_dts_accBudget, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                            }
                                            else
                                            {
                                                MessageBox.Show("Please Select Financial Year.....!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                isRedeyty = false;
                                            }

                                            //  if (rdoMonthly.Checked && isRedeyty)
                                            //{
                                            //print("\\Reports\\ACC\\rpt_accBudgetVarianceAnalysis_Monthly.rpt", "Budget Variance Analysis (All GL Accounts - Monthly)", "", "", glb_dts_accBudget, 0);
                                            //(string path, string sReportTitle1, string sReportTitle2, string sReportTitle3, DataSet ojbDataSet, decimal dGrandTotal_AllInvoice)

                                            //}
                                            //else if (rdoQuarterly.Checked)
                                            //{

                                            //}
                                            //}
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.ToString());
                                        }
                                        finally
                                        {
                                            Cursor = Cursors.Default;
                                            glb_dts_accBudget.Clear();
                                        }
                                    }
                                    #endregion
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

        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearField();
        }
        #endregion

        #region ClearField
        private void clearField()
        {
            txtMainGlCode.Tag = null;
            txtSubGlCode.Tag = null;
            txtAcctCodeTypeCode.Tag = null;
            txtAcctCode.Tag = null;
            txtCostCenter1.Tag = null;
            txtSubAcct2.Tag = null;
            txtEmployee.Tag = null;
            txtAccNoteFrom.Tag = null;
            txtFinYear.Tag = null;

            txtMainGlCode.Text = "<<ALL Accounts>>";
            txtSubGlCode.Text = "<<ALL Accounts>>";
            txtAcctCodeTypeCode.Text = "<<ALL Accounts>>";
            txtAcctCode.Text = "<<ALL Accounts>>";
            txtCostCenter1.Text = "<<ALL Sub Accounts1>>";
            txtSubAcct2.Text = "<<ALL Sub Accounts2>>";
            txtEmployee.Text = "<<ALL Employee>>";
            txtAccNoteFrom.Clear();
            txtFinYear.Text = "<<Select Financial Year>>";

            chkShowAccountNotesAll.Checked = false;
            txtStatementBalance.Text = "";

            clsCommon.SetVisibility_Panel(pnlGLName, false);
            clsCommon.SetVisibility_Panel(pnlSubGLName, false);
            clsCommon.SetVisibility_Panel(pnlAccType, false);
            clsCommon.SetVisibility_Panel(pnlAccName, false);
            clsCommon.SetVisibility_Panel(pnlSubAcc1, false);
            clsCommon.SetVisibility_Panel(pnlSubAcc2, false);
            clsCommon.SetVisibility_Panel(pnlEmployee, false);
            clsCommon.SetVisibility_Panel(pnlAccNotes, false);
            clsCommon.SetVisibility_Panel(pnlStatementBal, false);
            clsCommon.SetVisibility_Panel(pnlFinYear, false);
            clsCommon.SetVisibility_Panel(pnlMonth, false);
            clsCommon.SetVisibility_Panel(pnlHideZeroBal, false);
            clsCommon.SetVisibility_Panel(pnlUseChequeDate, false);
            clsCommon.SetVisibility_Panel(pnlSummery, false);

            chkUseChequeDate.Checked = true;
            chk_HideZeroAmount.Checked = true;

            rdoDetails.Checked = true;
            clsCommon.SetVisibility_Panel(pnlFrom, false);
            clsCommon.SetVisibility_Panel(pnlTo, false);
            dtpFrom.Visible = true;

            txtFinYear.Tag = clsMethods_GL.getFinancialYear_ID_Current();
            txtFinYear.Text = txtFinYear.Tag.ToString();
            dtpFrom.Value = clsMethods_GL.getFinancialYear_StartDate(txtFinYear.Tag.ToString());
            dtpTo.Value = clsMethods_GL.getFinancialYear_EndtDate(txtFinYear.Tag.ToString());
        }
        #endregion

        #region Print Method
        private void print(string path, string sReportTitle, string sFormula)
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

                if (iReport == (int)enum_ReportName.ST_ACC_Trail_Balance || iReport == (int)enum_ReportName.ST_ACC_Trail_Balance_Advance)
                {
                    RD.DataDefinition.FormulaFields["TotalCreditAmount"].Text = clsCommon.fncsetstring(clsFormatter.FormatToCurrecyWithThousendSep(Creditamount()));
                    RD.DataDefinition.FormulaFields["TotalDeditAmount"].Text = clsCommon.fncsetstring(clsFormatter.FormatToCurrecyWithThousendSep(Debitamount()));
                }

                RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                RD.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                string sFilter = "";
                if (txtMainGlCode.Tag != null && txtMainGlCode.Tag.ToString().Length > 0)
                    sFilter += "GL Name : " + txtMainGlCode.Text.Trim();
                if (txtSubGlCode.Tag != null && txtSubGlCode.Tag.ToString().Trim().Length > 0)
                    sFilter += "Sub GL Name : " + txtSubGlCode.Text.Trim();
                if (txtAcctCodeTypeCode.Tag != null && txtAcctCodeTypeCode.Tag.ToString().Length > 0)
                    sFilter += "Account Type Name : " + txtAcctCodeTypeCode.Text.Trim();
                if (txtAcctCode.Tag != null && txtAcctCode.Tag.ToString().Length > 0)
                    sFilter += "Account Name : " + txtAcctCode.Text.Trim();
                if (txtCostCenter1.Tag != null && txtCostCenter1.Tag.ToString().Length > 0)
                    sFilter += "Sub Accounts1 : " + txtCostCenter1.Text.Trim();
                if (txtSubAcct2.Tag != null && txtSubAcct2.Tag.ToString().Length > 0)
                    sFilter += "Sub Accounts2 : " + txtSubAcct2.Text.Trim();
                if (txtEmployee.Tag != null && txtEmployee.Tag.ToString().Length > 0)
                    sFilter += "Employee : " + txtEmployee.Text.Trim();

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
        #endregion

        #region KeyDown Events
        private void frm_rpt_ChequeManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void txtAcctCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_AccountCode();
        }
        private void txtSubAcct2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_costCenter2(ref txtSubAcct2);
        }
        private void txtEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterEmployee(ref txtEmployee);
        }
        private void txtFinYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_FinancialID();
        }
        #endregion

        #region Events DoublClick
        private void txtCostCenter1_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_costCenter1(ref txtCostCenter1);
        }
        private void txtSubAcct2_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_costCenter2(ref txtSubAcct2);
        }
        private void txtAcctCode_DoubleClick(object sender, EventArgs e)
        {
            Search_AccountCode();
        }

        private void txtEmployee_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterEmployee(ref txtEmployee);
        }
        private void txtFinYear_DoubleClick(object sender, EventArgs e)
        {
            Search_FinancialID();
        }
        private void txtMainGlCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_GLCode(txtMainGlCode, null, false);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void txtSubGlCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string sGLCode = "";
            try
            {
                if (txtMainGlCode.Tag != null)
                {
                    sGLCode = txtMainGlCode.Tag.ToString();
                    clsSearch.Search_SubGLCode(txtSubGlCode, null, sGLCode, false);
                }
                else
                {
                    clsSearch.Search_SubGLCode(txtSubGlCode, null, "", false);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void txtAcctCodeTypeCode_DoubleClick_1(object sender, EventArgs e)
        {
            string sSubGLCode = "";
            try
            {
                if (txtSubGlCode.Tag != null)
                {
                    sSubGLCode = txtSubGlCode.Tag.ToString();
                    clsSearch.Search_AccountType(txtAcctCodeTypeCode, null, sSubGLCode, false);
                }
                else
                    clsSearch.Search_AccountType(txtAcctCodeTypeCode, null, "", false);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Search Methods
        private void Search_FinancialID()
        {
            try
            {
                clsSearch.Search_FinancialID(ref txtFinYear);

                dtpFrom.Value = clsMethods_GL.getFinancialYear_StartDate(txtFinYear.Tag.ToString());
                dtpTo.Value = clsMethods_GL.getFinancialYear_EndtDate(txtFinYear.Tag.ToString());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_AccountCode()
        {
            try
            {
                string sAccTypeName = "";
                if (txtMainGlCode.Tag != null)
                    sAccTypeName = txtAcctCodeTypeCode.Tag.ToString();

                int iRow = dgvReports.SelectedCells[0].RowIndex;
                iReport = int.Parse(dgvReports.Rows[iRow].Cells[0].Value.ToString());

                if (iReport == (int)enum_ReportName.ST_BankBook || iReport == (int)enum_ReportName.ST_CashBook || iReport == (int)enum_ReportName.ST_BankReconcilation || iReport == (int)enum_ReportName.ST_BankReconcilationWithoutAdjustment)
                    clsSearch.Search_MasterAccountGLCode(ref txtAcctCode, sAccTypeName, clsAutocode.getControlAccount_Types(enum_ControlAccountType.Bank));
                else if (iReport == (int)enum_ReportName.RG_SubLedger_Debtors)
                    clsSearch.Search_MasterAccountGLCode(ref txtAcctCode, sAccTypeName, clsAutocode.getControlAccount_Types(enum_ControlAccountType.Debtor));
                else if (iReport == (int)enum_ReportName.RG_SubLedger_Creditors)
                    clsSearch.Search_MasterAccountGLCode(ref txtAcctCode, sAccTypeName, clsAutocode.getControlAccount_Types(enum_ControlAccountType.Creditor));
                else
                    clsSearch.Search_MasterAccountGLCode(ref txtAcctCode, sAccTypeName, "");
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

            if (iReportID == (int)enum_ReportName.ST_ACC_Trail_Balance)
            {
                clsCommon.SetVisibility_Panel(pnlFrom, true);
                clsCommon.SetVisibility_Panel(pnlTo, true);
                clsCommon.SetVisibility_Panel(pnlHideZeroBal, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_ACC_Trail_Balance_Advance)
            {
                clsCommon.SetVisibility_Panel(pnlFrom, true);
                clsCommon.SetVisibility_Panel(pnlTo, true);
                clsCommon.SetVisibility_Panel(pnlHideZeroBal, true);
                clsCommon.SetVisibility_Panel(pnlAccType, true);
            }
            else if (iReportID == (int)enum_ReportName.RG_General_Ledger)
            {
                clsCommon.SetVisibility_Panel(pnlFrom, true);
                clsCommon.SetVisibility_Panel(pnlTo, true);
                clsCommon.SetVisibility_Panel(pnlHideZeroBal, true);
                clsCommon.SetVisibility_Panel(pnlAccType, true);
                clsCommon.SetVisibility_Panel(pnlGLName, true);
                clsCommon.SetVisibility_Panel(pnlSubGLName, true);
                clsCommon.SetVisibility_Panel(pnlAccName, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_Acc_ProfitAndLoss_Std || iReportID == (int)enum_ReportName.ST_Acc_ProfitAndLoss_Cus)
            {
                clsCommon.SetVisibility_Panel(pnlFrom, true);
                clsCommon.SetVisibility_Panel(pnlTo, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_Acc_BalanceSheet)
            {
                clsCommon.SetVisibility_Panel(pnlFrom, false);
                clsCommon.SetVisibility_Panel(pnlTo, true);
            }
            else if (iReportID == (int)enum_ReportName.RG_SubLedger_Debtors || iReportID == (int)enum_ReportName.RG_SubLedger_Creditors)
            {
                clsCommon.SetVisibility_Panel(pnlAccName, true);
                clsCommon.SetVisibility_Panel(pnlSummery, true);
                clsCommon.SetVisibility_Panel(pnlFrom, true);
                clsCommon.SetVisibility_Panel(pnlTo, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_SubAcc1Statement || iReportID == (int)enum_ReportName.ST_GLCodeWise_SubAccounts)
            {
                clsCommon.SetVisibility_Panel(pnlAccName, true);
                clsCommon.SetVisibility_Panel(pnlSubAcc1, true);
                clsCommon.SetVisibility_Panel(pnlSubAcc2, true);
                clsCommon.SetVisibility_Panel(pnlFrom, true);
                clsCommon.SetVisibility_Panel(pnlTo, true);
                clsCommon.SetVisibility_Panel(pnlEmployee, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_SubAccWise)
            {
                clsCommon.SetVisibility_Panel(pnlSubAcc1, true);
                clsCommon.SetVisibility_Panel(pnlSubAcc2, true);
                clsCommon.SetVisibility_Panel(pnlFrom, true);
                clsCommon.SetVisibility_Panel(pnlTo, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_Acc_Notes)
            {
                clsCommon.SetVisibility_Panel(pnlFrom, true);
                clsCommon.SetVisibility_Panel(pnlTo, true);
                clsCommon.SetVisibility_Panel(pnlAccNotes, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_CashBook || iReportID == (int)enum_ReportName.ST_CashBankDetailBook)
            {
                clsCommon.SetVisibility_Panel(pnlAccName, true);
                clsCommon.SetVisibility_Panel(pnlFrom, true);
                clsCommon.SetVisibility_Panel(pnlTo, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_BankReconcilation || iReportID == (int)enum_ReportName.ST_BankReconcilationWithoutAdjustment)
            {
                clsCommon.SetVisibility_Panel(pnlFrom, true);
                clsCommon.SetVisibility_Panel(pnlTo, true);
                clsCommon.SetVisibility_Panel(pnlStatementBal, true);
                clsCommon.SetVisibility_Panel(pnlAccName, true);
                clsCommon.SetVisibility_Panel(pnlUseChequeDate, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_AccountOpeningBalance)
            {
                clsCommon.SetVisibility_Panel(pnlFrom, true);
                clsCommon.SetVisibility_Panel(pnlTo, true);
                clsCommon.SetVisibility_Panel(pnlAccType, true);
                clsCommon.SetVisibility_Panel(pnlFinYear, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_Acc_BudgetPlaningMonthWise)
            {
                clsCommon.SetVisibility_Panel(pnlFinYear, true);
                clsCommon.SetVisibility_Panel(pnlGLName, true);
                clsCommon.SetVisibility_Panel(pnlSubGLName, true);
                clsCommon.SetVisibility_Panel(pnlAccType, true);
                clsCommon.SetVisibility_Panel(pnlAccName, true);
                clsCommon.SetVisibility_Panel(pnlHideZeroBal, true);
            }
            if (iReportID == (int)enum_ReportName.ST_Acc_BudgetPlaningQuarterWise)
            {
                clsCommon.SetVisibility_Panel(pnlAccName, true);
                clsCommon.SetVisibility_Panel(pnlHideZeroBal, true);
                clsCommon.SetVisibility_Panel(pnlFinYear, true);
            }
        }
        #endregion

        #region Print method for Data Set
        private void print(string path, string sReportTitle, DataSet objDataTable, string sFilter, string sReportID)
        {
            try
            {
                string sHeaderTitle = "Standed Reports";

                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("HeaderTitle", sHeaderTitle, true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle", sReportTitle, true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", clsSecurity.CompanyName, true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", clsSecurity.CompanyAddress1, true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", clsSecurity.CompanyAddress2, true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqName", clsSecurity.DigiteqName, true, false);

                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqEmail", clsCommon.getCompanyEmail(), true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DateRange", "From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"), true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("UserName", clsSecurity.UserNameLoged, true, false);



                //string sFilter = "";               
                if (txtAcctCode.Tag != null && txtAcctCode.Tag.ToString().Length > 0)
                    sFilter += "Account No : " + txtAcctCode.Text.Trim() + " | ";
                if (txtCostCenter1.Tag != null && txtCostCenter1.Tag.ToString().Length > 0)
                    sFilter += "Sub Account1 : " + txtCostCenter1.Text.Trim() + " | ";
                if (txtSubAcct2.Tag != null && txtSubAcct2.Tag.ToString().Trim().Length > 0)
                    sFilter += "Sub Account2 : " + txtSubAcct2.Text.Trim() + " | ";
                if (txtFinYear.Tag != null && txtFinYear.Tag.ToString().Length > 0)
                    sFilter += " | " + txtFinYear.Text;

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
        #endregion

        #region Calculate
        #region Creditamount
        public decimal Creditamount()
        {
            #region GL Posting Detail
            decimal TotalCreditAmount = 0;
            decimal TotalDebiteAmount = 0;

            var callStats = (from c in tbl_accGLPosting_Detail.SelectAll()
                             group c by c.Gl_ID into d
                             select new
                             {
                                 Gl_ID = d.Key,

                             });

            foreach (var GLDID in callStats)
            {
                decimal CreditAmount = 0;
                decimal DebiteAmount = 0;

                foreach (tbl_accGLPosting_Detail GLPOdetail in tbl_accGLPosting_Detail.SelectAllByGl_ID(GLDID.Gl_ID).Where(p => p.TransactionDate.Date <= dtpTo.Value.Date && p.TransactionDate.Date >= dtpFrom.Value.Date))
                {
                    if (GLPOdetail.IsCredit)
                        CreditAmount = CreditAmount + GLPOdetail.Amount;
                    else
                        DebiteAmount = DebiteAmount + GLPOdetail.Amount;
                }

                if (CreditAmount - DebiteAmount > 0)
                    TotalCreditAmount = TotalCreditAmount + (CreditAmount - DebiteAmount);
                else
                    TotalDebiteAmount = TotalDebiteAmount + (DebiteAmount - CreditAmount);
            }
            #endregion

            return TotalCreditAmount;
        }
        #endregion

        #region Debit amount
        public decimal Debitamount()
        {
            #region GL Posting Detail
            decimal TotalCreditAmount = 0;
            decimal TotalDebiteAmount = 0;

            var callStats = (from c in tbl_accGLPosting_Detail.SelectAll()
                             group c by c.Gl_ID into d
                             select new
                             {
                                 Gl_ID = d.Key,

                             });

            foreach (var GLDID in callStats)
            {
                decimal CreditAmount = 0;
                decimal DebiteAmount = 0;

                foreach (tbl_accGLPosting_Detail GLPOdetail in tbl_accGLPosting_Detail.SelectAllByGl_ID(GLDID.Gl_ID).Where(p => p.TransactionDate.Date >= dtpFrom.Value.Date && p.TransactionDate.Date <= dtpTo.Value.Date))
                {
                    if (GLPOdetail.IsCredit)
                        CreditAmount = CreditAmount + GLPOdetail.Amount;
                    else
                        DebiteAmount = DebiteAmount + GLPOdetail.Amount;
                }

                if (CreditAmount - DebiteAmount > 0)
                    TotalCreditAmount = TotalCreditAmount + (CreditAmount - DebiteAmount);
                else
                    TotalDebiteAmount = TotalDebiteAmount + (DebiteAmount - CreditAmount);
            }
            #endregion

            return TotalDebiteAmount;
        }
        #endregion
        #endregion

        #region Print method for Data Set
        private void print1(string path, string sReportTitle, DataTable objDataTable, string sFilter)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Standed Reports";
                ReportDocument objRpt = new ReportDocument();
                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(objDataTable); //(glbDtsSales)
                string sName = objDataTable.ToString();

                if (sName == "dt_acc_BankReconciliation")
                {
                    objRpt.DataDefinition.FormulaFields["AsatDate"].Text = clsCommon.fncsetstring(dtpTo.Value.ToString("dd MMM yyyy"));
                    objRpt.DataDefinition.FormulaFields["AccountName"].Text = clsCommon.fncsetstring(txtAcctCode.Text.ToString());
                }

                objRpt.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd/MM/yyyy") + " To : " + dtpTo.Value.ToString("dd/MM/yyyy"));
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                objRpt.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                objRpt.DataDefinition.FormulaFields["CurrentFiscalYearDate"].Text = clsCommon.fncsetstring(clsGenaralName.getName_FinancialYearName(clsMethods_GL.getFinancialYear_ID_Current()));
                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                    try
                    {
                        objRpt.DataDefinition.FormulaFields["CurrentFinYear"].Text = clsCommon.fncsetstring(clsMethods_GL.getFinancialYear_ID_Current());
                    }
                    catch (Exception) { }

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

        private void chkShowAccountNotesAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowAccountNotesAll.Checked == true)
            {
                txtAccNoteFrom.Clear();
                txtAccNoteTo.Clear();
                txtAccNoteFrom.Enabled = false;
                txtAccNoteTo.Enabled = false;
            }
            else
            {
                txtAccNoteFrom.Enabled = true;
                txtAccNoteTo.Enabled = true;
            }
        }

        private void txtStatementBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithHypen(txtStatementBalance.Text.ToString(), e);
        }

        private void txtAccNoteFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength(txtAccNoteFrom, e, 9, 2);
        }

        private void txtAccNoteTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength(txtAccNoteTo, e, 9, 2);
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            txtFinYear.Tag = clsMethods_GL.getFinancialYear_ID(dtpFrom.Value);
            txtFinYear.Text = txtFinYear.Tag.ToString();

            string sFinYear2 = clsMethods_GL.getFinancialYear_ID(dtpTo.Value);
            if (txtFinYear.Tag.ToString() != sFinYear2)
            {
                dtpTo.Value = clsMethods_GL.getFinancialYear_EndtDate(txtFinYear.Tag.ToString());
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

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            txtFinYear.Tag = clsMethods_GL.getFinancialYear_ID(dtpTo.Value);
            txtFinYear.Text = txtFinYear.Tag.ToString();

            string sFinYear2 = clsMethods_GL.getFinancialYear_ID(dtpFrom.Value);
            if (txtFinYear.Tag.ToString() != sFinYear2)
            {
                dtpFrom.Value = clsMethods_GL.getFinancialYear_StartDate(txtFinYear.Tag.ToString());
            }
        }

        
    }

    public class PNL
    {
        public string glMainCatagoryID;
        public string noteName;
        public decimal amount;

        public PNL(string GlMainCatagoryID, string NoteName, decimal Amount)
        {
            glMainCatagoryID = GlMainCatagoryID;
            noteName = NoteName;
            amount = Amount;
        }
    }
}