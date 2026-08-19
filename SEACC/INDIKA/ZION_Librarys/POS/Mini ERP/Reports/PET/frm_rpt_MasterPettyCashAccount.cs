using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; 
using System.Text;
using System.Windows.Forms;
using DataTire;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Digiteq_Logic;

namespace Digiteq
{
    public partial class frm_rpt_MasterPettyCashAccount : Form
    {

        #region Variables
        //form manage
           public int iFormID;

        //for security handle
        public bool bNoAccess;
        #endregion

        #region Form load
        public frm_rpt_MasterPettyCashAccount()
        {
            iFormID = clsSecurity.getFormID(FormName.PettyCashMasterReport);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_rpt_MasterPettyCashAccount_Load(object sender, EventArgs e)
        {
            //clsFormatter.setFormatForm(this, " Cash Book Master Report", 3);
        } 
        #endregion

        #region Btn print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (rdoLevel1Name.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.PT_Level_1_Titles)))
                {
                    print("\\reports\\PET\\rpt_bpsLevel1_Name.rpt", "LEVEL-1 Expenditure Items", "");
                }
            }
            if (rdoLevel2Name.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.PT_Level_2_Titles)))
                {
                    print("\\reports\\PET\\rpt_bpsLevel2_Name.rpt", "LEVEL-2 Expenditure Items", "");
                }
            }
            if (rdoLevel3Name.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.PT_Level_3_Titles)))
                {
                    print("\\reports\\PET\\rpt_bpsLevel3_Name.rpt", "LEVEL-3 Expenditure Items", "");
                }
            }
            if (rdoExpenditureTypes.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.PT_Expenditure_Types)))
                {
                    print("\\reports\\PET\\rpt_bpsExpenditureTypesName.rpt", " Expenditure Items", "");
                }
            }
            if (rdoActiviteCode.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.PT_Activitys_Items)))
                {
                    print("\\reports\\PET\\rpt_bpsActivityItem_Name.rpt", "Expenditure Additional Activity Codes List", "");
                }
            }
            if (rdoCostCenter.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.PT_Cost_Centers)))
                {
                    print("\\reports\\PET\\rpt_bpsCostCenter_Name.rpt", "Expenditure Cost Center List", "");
                }
            }
            if (rdoSupplier.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.PT_Suppliers)))
                {
                    print("\\reports\\PET\\rpt_bpsSupplier.rpt", "Suppliers List", "");
                }
            }
            if (rdoIncomeType.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.PT_Income_Types)))
                {
                    print("\\reports\\PET\\rpt_bpsIncomeTypesName.rpt", "Income Types", "");
                }
            }
        }
        #endregion

        #region Print
        private void print(string path, string sReportTitle, string sFormula)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Cash Book Register";
                ReportDocument RD = new ReportDocument();
                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                frm_ReportViewer viewer = new frm_ReportViewer();
                RD.Load(s_Path);
                clsSecurity.LogonServer(ref RD);
                RD.Refresh();

                RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                RD.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
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

        private void x1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rdoSupplier_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
