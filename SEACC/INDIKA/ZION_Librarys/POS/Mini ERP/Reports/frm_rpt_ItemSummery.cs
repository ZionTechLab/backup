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
using DataTire;
using Digiteq.DataSets;
using Digiteq.Reports.MAS;

namespace Digiteq
{
    public partial class frm_rpt_ItemSummery : Form
    {
        #region Variables
        //form manage
           public int iFormID;

        //for security handle
        public bool bNoAccess;
        #endregion

        //objects from datasets        
        dts_Master glb_MasItam = new dts_Master();
        #region Form Load
        public frm_rpt_ItemSummery()
        {
            iFormID = clsSecurity.getFormID(FormName.ReportItemSummery);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frmReportChequeDeposit_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "Item Register", 2, iFormID);

            clearField();
            rdoCombinationMaterial.Checked = false;
            rdoRawMaterial.Checked = true;
        } 
        #endregion


        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearField();

            rdoCombinationMaterial.Checked = false;
            rdoRawMaterial.Checked = true;
        }
        #endregion

        #region Print Btn
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (rdoRawMaterial.Checked)
            {
                if (txtRawMaterial.Tag != null)
                    print("\\reports\\rpt_masRawMaterial.rpt", "Item Master Raw Material [Summery] ", "{vw_rpt_masItemSummery.item_ID} <> 'default' and {vw_rpt_masItemSummery.categoryName} = '" + txtRawMaterial.Text.Trim() + "'");
                else
                    print("\\reports\\rpt_masRawMaterial.rpt", "Item Master Raw Material [Summery] ", "{vw_rpt_masItemSummery.item_ID} <> 'default'");
            }
            if (rdoFinishedGood.Checked)
            {
                print("\\reports\\rpt_masFinishedGood.rpt", "Item Master Finished Good [Summery] ", "{vw_rpt_masFinishedGood.item_ID} <> 'default'");
            }
            if (rdoSemiFinishedGood.Checked)
            {
                print("\\reports\\rpt_masSemiFinishedGood.rpt", "Item Master Semi Finished Good [Summery] ", "{vw_rpt_masSemiFinishedGood.item_ID} <> 'default'");
            }
            if (rdoCombinationMaterial.Checked)
            {
                print("\\reports\\rpt_masCombinationMaterial.rpt", "Item Master Combination Material [Summery] ", "{vw_rpt_masCombinationMaterial.item_ID} <> 'default'");
            }
            if (rdoLaminationMaterial.Checked)
            {
                print("\\reports\\rpt_masLaminationmaterial.rpt", "Item Master Lamination Material [Summery] ", "{tbl_genItemMaster_LaminatedMaterialSingle.item_ID} <> 'default'");
            }
        }
        #endregion

        #region ClearField
        private void clearField()
        {
            txtRawMaterial.Text = "     <<ALL Category>>";
            txtRawMaterial.Tag = null;
        } 
        #endregion

        #region Print Method
        private void print(string path, string sReportTitle, string sFormula)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Item Master";
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

        
        #region KeyDown Events
        private void frm_rpt_ChequeManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtRawMaterial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterItemCategory(ref txtRawMaterial);
            }
        }
        #endregion
      
        #region Events DoublClick
        private void txtStoreStock_DoubleClick(object sender, EventArgs e)
        {
            //clsSearch.Search_MasterGussestType();
        }

        private void txtDepartmentStock_DoubleClick(object sender, EventArgs e)
        {

        }

        private void txtSectionStoke_DoubleClick(object sender, EventArgs e)
        {

        }

        private void txtRawMaterial_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterItemCategory(ref txtRawMaterial);
        }
        #endregion

        #region Events CheckedChanged
        private void rdoRawMaterial_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRawMaterial.Checked)
            {
                txtRawMaterial.Enabled = true;
            }
            else{
                txtRawMaterial.Enabled = false;
                clearField();
            }
        }
        #endregion

    } 
      
}
