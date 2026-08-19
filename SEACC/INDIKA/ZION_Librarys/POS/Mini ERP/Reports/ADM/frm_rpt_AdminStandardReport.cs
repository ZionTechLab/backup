using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Digiteq.DataSets;
using DataTire;

namespace Digiteq
{
    public partial class frm_rpt_AdminStandardReport : Form
    {
        #region Variables
        //form manage
        public int iFormID;

        //for security handle
        public bool bNoAccess;

        dts_Admin1 glb_dts_admin = new dts_Admin1();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        #endregion

        #region Form Load
        public frm_rpt_AdminStandardReport()
        {
            iFormID = clsSecurity.getFormID(FormName.AdminStandardReport);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_rpt_MasterReport_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "Admin Standard Report", 1, iFormID);
            clearField();
            Refresh_ModuleCmbCheck();

            // rdoUserMaster.Checked = true;
        }
        #endregion

        private void Refresh_ModuleCmbCheck()
        {
            cmbModule.Items.Clear();
            cmbModule.DisplayMember = "Value";
            cmbModule.ValueMember = "Text";

            cmbModule.Items.Add(new ComboBoxItem("0", "All"));
            cmbModule.SelectedIndex = cmbModule.FindStringExact("All");
            foreach (tbl_securityFormCategory oDetail in tbl_securityFormCategory.SelectAll().Where(r => r.IsEnable && r.IsVisible))
            {
                if (oDetail.FormCategory_ID != "default")
                    cmbModule.Items.Add(new ComboBoxItem(oDetail.FormCategory_ID, oDetail.CategoryName.ToUpper()));
            }
            foreach (tbl_cfgModule oDetail in tbl_cfgModule.SelectAll().Where(r => r.IsEnable))
            {
                //PROD/016 - Still Prod Apparel Only
                //To Do for Other R2 Modules
                if (oDetail.Module_ID == "PROD/016")
                    cmbModule.Items.Add(new ComboBoxItem(oDetail.Module_ID, oDetail.ModuleName.ToUpper()));
                if (oDetail.Module_ID == "PCB/025")
                    cmbModule.Items.Add(new ComboBoxItem(oDetail.Module_ID, oDetail.ModuleName.ToUpper()));
            }

            //if (cmbModuleCheck.Items.Count > 0)
            //    cmbModuleCheck.SelectedIndex = cmbModuleCheck.FindStringExact("Sales Account System [SAS]");
        }

        #region Btn Print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            bool bUserSelected = false, bFormNameSelected = false, bReportnameSelected = false, bModuleSelected = false;
            string sFormula = "", sFilter = "";
            string sDaterange = "From  : " + dtpFrom.Value.Date.ToString("dd-MMM-yyyy") + " TO : " + dtpTo.Value.Date.ToString("dd-MMM-yyyy");

            if (txtUserName.Tag != null && txtUserName.Tag.ToString().Trim().Length > 0)
                bUserSelected = true;
            if (txtReportName.Tag != null && txtReportName.Tag.ToString().Trim().Length > 0)
                bReportnameSelected = true;
            if (txtFormName.Tag != null && txtFormName.Tag.ToString().Trim().Length > 0)
                bFormNameSelected = true;
            if (((ComboBoxItem)cmbModule.SelectedItem).Value != "0")
                bModuleSelected = true;


            if (rdoPermissionUserwise.Checked)
            {
                sFormula = "{vw_rpt_admUserPermission.user_ID} <>'digiteq' AND {vw_rpt_admUserPermission.user_ID} <>'default' AND {vw_rpt_admUserPermission.user_ID} <>'admin' AND {vw_rpt_admUserPermission.isEnable} = true AND {vw_rpt_admUserPermission.isBlocked} = false AND {vw_rpt_admUserPermission.formCategory_ID} <> 'FCT/007' ";
                if (bUserSelected)
                {
                    sFormula += " and {vw_rpt_admUserPermission.user_ID} = '" + txtUserName.Tag.ToString().Trim() + "' ";
                    sFilter += " User Name : " + txtUserName.Text.Trim();
                }
                if (bFormNameSelected)
                {
                    sFormula += " and {vw_rpt_admUserPermission.form_ID} = " + txtFormName.Tag.ToString().Trim() + " ";
                    sFilter += " Form Name : " + txtFormName.Text.Trim();
                }

                sFormula += " and ({vw_rpt_admUserPermission.allowRead} = true or {vw_rpt_admUserPermission.allowWrite} = true or {vw_rpt_admUserPermission.allowDelete} = true or {vw_rpt_admUserPermission.allowApprovable} = true or {vw_rpt_admUserPermission.allowCheckable} = true or {vw_rpt_admUserPermission.allowUpdate} = true)";
                print("\\Reports\\ADM\\Standard\\rpt_adm_FormPermission_UserWise.rpt", "Form Permission (User-Wise)", sFormula, sFilter);
            }
            else if (rdoPermissionFormWise.Checked)
            {
                sFormula = "{vw_rpt_admUserPermission.user_ID} <>'digiteq' AND {vw_rpt_admUserPermission.user_ID} <>'default' AND {vw_rpt_admUserPermission.user_ID} <>'admin' AND {vw_rpt_admUserPermission.isEnable} = true AND {vw_rpt_admUserPermission.isBlocked} = false AND {vw_rpt_admUserPermission.formCategory_ID} <> 'FCT/007' ";
                if (bUserSelected)
                {
                    sFormula += " and {vw_rpt_admUserPermission.user_ID} = '" + txtUserName.Tag.ToString().Trim() + "' ";
                    sFilter += " User Name : " + txtUserName.Text.Trim();
                }
                if (bFormNameSelected)
                {
                    sFormula += " and {vw_rpt_admUserPermission.form_ID} = " + txtFormName.Tag.ToString().Trim() + " ";
                    sFilter += " Form Name : " + txtFormName.Text.Trim();
                }

                sFormula += " and ({vw_rpt_admUserPermission.allowRead} = true or {vw_rpt_admUserPermission.allowWrite} = true or {vw_rpt_admUserPermission.allowDelete} = true or {vw_rpt_admUserPermission.allowApprovable} = true or {vw_rpt_admUserPermission.allowCheckable} = true or {vw_rpt_admUserPermission.allowUpdate} = true)";
                print("\\Reports\\ADM\\Standard\\rpt_adm_FormPermission_FormWise.rpt", "Form Permission (Form-Wise)", sFormula, sFilter);

            }
            else if (rdoReportPermissionUserWise.Checked)
            {
                sFormula = "{vw_rpt_admReportPermission.user_ID} <>'default' ";
                if (bUserSelected)
                {
                    sFormula += " and {vw_rpt_admReportPermission.user_ID} = '" + txtUserName.Tag.ToString().Trim() + " '";
                    sFilter += " User Name : " + txtUserName.Text.Trim();
                }

                if (bReportnameSelected)
                {
                    sFormula += " and {vw_rpt_admReportPermission.report_ID} = '" + txtReportName.Tag.ToString().Trim() + " '";
                    sFilter += " Report Name : " + txtReportName.Text.Trim();
                }

                sFormula += " and ({vw_rpt_admReportPermission.allowPrint} = true or {vw_rpt_admReportPermission.allowRePrint} = true or {vw_rpt_admReportPermission.allowExport} = true or {vw_rpt_admReportPermission.allowView} = true)";
                print("\\Reports\\ADM\\Standard\\rpt_adm_ReportPermission_UserWise.rpt", "Report Permission (User-Wise) ", sFormula, sFilter);

            }
            else if (rdoReportPermissionReportWise.Checked)
            {

                if (bReportnameSelected)
                {
                    sFormula += " {vw_rpt_admReportPermission.report_ID} = '" + txtReportName.Tag.ToString().Trim() + "' ";
                    sFilter += " Report Name : " + txtReportName.Text.Trim();
                }

                print("\\Reports\\ADM\\Standard\\rpt_adm_ReportPermission_ReportWise.rpt", "Report Permission (Report-Wise)", sFormula, sFilter);
            }

            else if (rdoCancelledTransactions.Checked)
            {
                glb_dts_admin.Clear();
                string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";

                if (bUserSelected)
                    sFilter += " User Name : " + txtUserName.Text.Trim();

                if (bFormNameSelected)
                    sFilter += " Transaction : " + txtFormName.Text.Trim();

                if(bModuleSelected)
                    sFilter += " Module : " + ((ComboBoxItem)cmbModule.SelectedItem).Value;

                if (clsHelpMethods.GetReportPath(clsAutocode.getReportID(enum_ReportName.ADM_Cancel_Transactions), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                {
                    string sModule = ((ComboBoxItem)cmbModule.SelectedItem).Value == "0" ? "%%" : ((ComboBoxItem)cmbModule.SelectedItem).Value;
                    string sForm = txtFormName.Tag != null ? txtFormName.Tag.ToString() : "%%";
                    string sUser = txtUserName.Tag != null ? "%" + txtUserName.Tag.ToString() + "%" : "%%";
                    string sBranch = txtBranch.Tag != null ? "%" + txtBranch.Tag.ToString() + "%" : "%%";
                                        
                    string sQuary = "exec [sp_GetCanceledtransactions] '" + sModule + "', '" + sForm + "', '" + sUser + "', '" + sBranch + "','" + dtpFrom.Value.Date.ToString("yyyy-MM-dd") + "','" + dtpTo.Value.Date.ToString("yyyy-MM-dd") + "'";
                    glb_dts_admin.dt_canceledTransactions.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                    glb_dts_admin.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDaterange, clsSecurity.UserNameLoged, sFilter);
                    frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                    rpt.print(sReportPath, glb_dts_admin, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.ADM_Cancel_Transactions));
                }
            }
        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e, string myformula)
        {

        }
        #endregion

        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearField();
            Refresh_ModuleCmbCheck();
        }
        #endregion

        #region ClearField
        private void clearField()
        {
            //xtModuleName.Tag = null;
            txtFormName.Tag = null;
            //tGroupName.Tag = null;
            txtUserName.Tag = null;
            txtReportName.Tag = null;

            //tModuleName.Text = "<All Modules>";
            txtFormName.Text = "<All Forms>";
            //txtGroupName.Text = "<All Groups>";
            txtUserName.Text = "<All Users>";
            txtReportName.Text = "<All Reports>";

            txtBranch.Tag = clsSecurity.BranchID;
            txtBranch.Text = clsGenaralName.getName_CompanyBranchMaster(clsSecurity.BranchID);

            tbl_genCompanyBranchMaster oBranch = tbl_genCompanyBranchMaster.Select(clsSecurity.BranchID);
            if (oBranch != null)
            {
                if (!oBranch.IsHeadOffice)
                {
                    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtBranch, false);
                    clsCommon.SetEnableDisable_NormalLabel(lblBranch, false);
                }
            }
        }
        #endregion

        #region Print Method
        private void print(string path, string sReportTitle, string sFormula, string sFilter)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Permission Report (User-Wise)";
                ReportDocument RD = new ReportDocument();
                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                frm_ReportViewer viewer = new frm_ReportViewer();
                RD.Load(s_Path);
                clsSecurity.LogonServer(ref RD);
                RD.Refresh();

                RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToShortDateString());
                RD.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
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

        #region Events KeyDown
        private void txtGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_GroupID();
            }
        }
        private void txtUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_UserID();
            }
        }
        private void txtCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                // clsSearch.Search_SecurityFormCategory(ref txtModuleName);
            }
        }
        private void txtFormName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_SecurityFormMaster(ref txtFormName);
            }
        }
        private void txtReprtCatagory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                //earch_ReportCategoryID();
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtGroupName_DoubleClick(object sender, EventArgs e)
        {
            Search_GroupID();
        }
        private void txtUserName_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterUsers(ref txtUserName);
            //Search_UserID();
        }
        private void txtCategory_DoubleClick(object sender, EventArgs e)
        {
            //clsSearch.Search_SecurityFormCategory(ref txtModuleName);
        }
        private void txtFormName_DoubleClick(object sender, EventArgs e)
        {
            //clsSearch.Search_SecurityFormMaster(ref txtFormName);
            clsSearch.Search_Form(ref txtFormName);
        }
        private void txtReprtCatagory_DoubleClick(object sender, EventArgs e)
        {
            //arch_ReportCategoryID();
        }
        private void txtReportName_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterReports(ref txtReportName);
        }
        #endregion

        #region Events CheckedChanged
        private void rdoUserMaster_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }

        private void userPermissionFormWise_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }

        private void rdoPermissionUserwise_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoReportMaster_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }

        private void rdoReportPermissionReportWise_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoReportPermissionUserWise_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoPermissionFormWise_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        #endregion

        #region Serach Methods
        private void Search_GroupID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_Group();
            frmhelpsearch.ShowDialog();

            //if (frmSearchMaster.s_SearchID.Length > 0)
            //{
            //    if (frmSearchMaster.s_SearchText.Length > 0)
            //        txtGroupName.Text = frmSearchMaster.s_SearchText;
            //    if (frmSearchMaster.s_SearchID.Length > 0)
            //        txtGroupName.Tag = frmSearchMaster.s_SearchID;
            //}
        }
        //private void Search_ReportCategoryID()
        //{
        //    clsSearch.Search_MasterReportCategory(ref txtReprtCatagory);          
        //}
        private void Search_UserID()
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
                    txtUserName.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    txtUserName.Tag = frmSearchMaster.s_SearchID;
                }
            }
        }
        #endregion

        #region Set Enable/Disable Controls
        private void setEnableDisableConctrol()
        {
            if (rdoPermissionUserwise.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtUserName, true);
                clsCommon.SetEnableDisable_NormalLabel(lblUserName, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtReportName, false);
                clsCommon.SetEnableDisable_NormalLabel(lblReportName, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtFormName, true);
                clsCommon.SetEnableDisable_NormalLabel(lblFormName, true);
                clsCommon.SetEnableDisable_NormalComboBox(cmbModule, false);
                clsCommon.SetEnableDisable_NormalLabel(lblModule, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtBranch, false);
                clsCommon.SetEnableDisable_NormalLabel(lblBranch, false);

                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtReprtCatagory, false);
                //clsCommon.SetEnableDisable_NormalLabel(lblReprtCatagory, false);
                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtGroupName, true);
                //clsCommon.SetEnableDisable_NormalLabel(lblGroupName, true);
                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtModuleName, true);
                //clsCommon.SetEnableDisable_NormalLabel(lblModuleName, true);

                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, false);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, false);
            }
            else if (rdoPermissionFormWise.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtUserName, true);
                clsCommon.SetEnableDisable_NormalLabel(lblUserName, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtReportName, false);
                clsCommon.SetEnableDisable_NormalLabel(lblReportName, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtFormName, true);
                clsCommon.SetEnableDisable_NormalLabel(lblFormName, true);
                clsCommon.SetEnableDisable_NormalComboBox(cmbModule, false);
                clsCommon.SetEnableDisable_NormalLabel(lblModule, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtBranch, false);
                clsCommon.SetEnableDisable_NormalLabel(lblBranch, false);
                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtReprtCatagory, false);
                //clsCommon.SetEnableDisable_NormalLabel(lblReprtCatagory, false);
                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtGroupName, false);
                //clsCommon.SetEnableDisable_NormalLabel(lblGroupName, false);
                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtModuleName, true);
                //clsCommon.SetEnableDisable_NormalLabel(lblModuleName, true);

                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, false);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, false);
            }
            else if (rdoReportPermissionUserWise.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtUserName, true);
                clsCommon.SetEnableDisable_NormalLabel(lblUserName, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtReportName, true);
                clsCommon.SetEnableDisable_NormalLabel(lblReportName, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtFormName, false);
                clsCommon.SetEnableDisable_NormalLabel(lblFormName, false);
                clsCommon.SetEnableDisable_NormalComboBox(cmbModule, false);
                clsCommon.SetEnableDisable_NormalLabel(lblModule, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtBranch, false);
                clsCommon.SetEnableDisable_NormalLabel(lblBranch, false);
                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtReprtCatagory, true);
                //clsCommon.SetEnableDisable_NormalLabel(lblReprtCatagory, true);
                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtGroupName, false);
                //clsCommon.SetEnableDisable_NormalLabel(lblGroupName, false);
                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtModuleName, false);
                //clsCommon.SetEnableDisable_NormalLabel(lblModuleName, false);

                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, false);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, false);
            }
            else if (rdoReportPermissionReportWise.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtUserName, true);
                clsCommon.SetEnableDisable_NormalLabel(lblUserName, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtFormName, false);
                clsCommon.SetEnableDisable_NormalLabel(lblFormName, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtReportName, true);
                clsCommon.SetEnableDisable_NormalLabel(lblReportName, true);
                clsCommon.SetEnableDisable_NormalComboBox(cmbModule, false);
                clsCommon.SetEnableDisable_NormalLabel(lblModule, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtBranch, false);
                clsCommon.SetEnableDisable_NormalLabel(lblBranch, false);
                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtGroupName, false);
                //clsCommon.SetEnableDisable_NormalLabel(lblGroupName, false);
                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtModuleName, true);
                //clsCommon.SetEnableDisable_NormalLabel(lblModuleName, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, false);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, false);
            }
            else if (rdoReportPermissionReportWise.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtUserName, true);
                clsCommon.SetEnableDisable_NormalLabel(lblUserName, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtFormName, false);
                clsCommon.SetEnableDisable_NormalLabel(lblFormName, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtReportName, true);
                clsCommon.SetEnableDisable_NormalLabel(lblReportName, true);
                clsCommon.SetEnableDisable_NormalComboBox(cmbModule, false);
                clsCommon.SetEnableDisable_NormalLabel(lblModule, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtBranch, false);
                clsCommon.SetEnableDisable_NormalLabel(lblBranch, false);
                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtGroupName, false);
                //clsCommon.SetEnableDisable_NormalLabel(lblGroupName, false);
                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtModuleName, true);
                //clsCommon.SetEnableDisable_NormalLabel(lblModuleName, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, false);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, false);
            }

            else if (rdoCancelledTransactions.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtUserName, true);
                clsCommon.SetEnableDisable_NormalLabel(lblUserName, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtFormName, true);
                clsCommon.SetEnableDisable_NormalLabel(lblFormName, true);
                clsCommon.SetEnableDisable_NormalComboBox(cmbModule, true);
                clsCommon.SetEnableDisable_NormalLabel(lblModule, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtBranch, true);
                clsCommon.SetEnableDisable_NormalLabel(lblBranch, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
            }
        }
        #endregion

        private void txtFormName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBranch_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_CompanyBranch(ref txtBranch);
        }
    }
}
