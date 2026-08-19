using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace Digiteq
{
    public partial class frm_rpt_PaymentAdvicer : Form
    {
        #region Variables
        //form manage
           public int iFormID;
        string sHeaderTitle = "";
        //for security handle
        public bool bNoAccess;
        #endregion

        #region Form Load
        public frm_rpt_PaymentAdvicer()
        {
            iFormID = clsSecurity.getFormID(FormName.ReportDailyProduction);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frmReportChequeDeposit_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "Payment Adviser", 3, iFormID);
            clearField();
        } 
        #endregion

        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearField();
        }
        #endregion

        #region Print Btn
        private void btnPrint_Click(object sender, EventArgs e)
        {
            string sFormula = "";
            sHeaderTitle = "Payment Advicer";
            //if (txtSupplier.Tag != null)
            //{
            //    sFormula += "{vw_rpt_pmsDailyProductionProgress.productionJob_ID} = '" + txtSupplier.Tag.ToString() + "'";
            //    sHeaderTitle = "Job Wise";
            //}
            print("\\reports\\rpt_bssPaymentAdvicer.rpt", "Payment Advicer", sFormula);
        }
        #endregion

        #region ClearField
        private void clearField()
        {
            txtSupplier.Text = "     <<ALL Creditors>>";           
            txtSupplier.Tag = null;
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSupplier, false);
        }
        #endregion

        #region Print Method
        private void print(string path, string sReportTitle, string sFormula)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "";
                ReportDocument RD = new ReportDocument();
                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                frm_ReportViewer viewer = new frm_ReportViewer();
                RD.Load(s_Path);
                clsSecurity.LogonServer(ref RD);
                RD.Refresh();

                //RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                //RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                ////RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToShortDateString() + "      To : " + dtpTo.Value.ToShortDateString());
                //RD.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                //RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                //RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                //RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

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
        #endregion
        
        #region KeyDown Events
        private void frm_rpt_ChequeManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtSection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_DontUse_MasterSupplier(ref txtSupplier);
            }
        }
        #endregion
      
        #region Events DoublClick
        private void txtSectionStoke_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_DontUse_MasterSupplier(ref txtSupplier);
        }
        #endregion
    }
}
