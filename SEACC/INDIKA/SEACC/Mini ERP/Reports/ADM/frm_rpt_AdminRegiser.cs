using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DataTire;
using Zion.ERP.Reports.DataSets;
using Digiteq.Reports.ADM;


namespace Digiteq
{
    public partial class frm_rpt_AdminRegiser : Form
    {
        
        //form manage
           public int iFormID;

        //for security handle
        public bool bNoAccess;


        //objects from datasets        
        dts_Admin1 glb_dtsAdmin = new dts_Admin1();
    

        #region Form Load
        public frm_rpt_AdminRegiser()
        {
            iFormID = clsSecurity.getFormID(FormName.AdminRegisterReport);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_rpt_MasterReport_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "Admin Register Report", 1, iFormID);           
            clearField();

            rdoUserMaster.Checked = true;
        } 
        #endregion


        #region Btn Print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            bool bUserSelected = false, bGroupSelected = false, bModuleSelected = false,bReprtCattagorySelected = false, bDocumentSelected = false;
            string sFormula = "", sFilter = "";

            if (txtGroupName.Tag != null && txtGroupName.Tag.ToString().Trim().Length > 0)
                bGroupSelected = true;
            if (txtModuleName.Tag != null && txtModuleName.Tag.ToString().Trim().Length > 0)
                bModuleSelected = true;
            if (txtReprtCatagory.Tag != null && txtReprtCatagory.Tag.ToString().Trim().Length > 0)
                bReprtCattagorySelected = true;
            if (txtUserID.Tag != null && txtUserID.Tag.ToString().Trim().Length > 0)
                bUserSelected = true;
            if (txtDocument.TextLength > 0)
                bDocumentSelected = true;

            //if (txtFormName.Tag != null && txtFormName.Tag.ToString().Trim().Length > 0)
            //    bFormnameSelected = true;
            //if (txtFormName.Tag != null && txtFormName.Tag.ToString().Trim().Length > 0)
            //    bFormSelected = true;
            //if (txtUserName.Tag != null && txtUserName.Tag.ToString().Trim().Length > 0)
            //    bUserSelected = true;

            #region User master

            if (rdoUserMaster.Checked)
            {
                sFormula = "{vw_rpt_genUserMaster.user_ID} <>'digiteq' AND {vw_rpt_genUserMaster.user_ID} <>'default' AND {vw_rpt_genUserMaster.user_ID} <>'admin'";

                if (bUserSelected)
                {
                    sFormula += " and {vw_rpt_genUserMaster.user_ID} = '" + txtUserID.Tag.ToString().Trim() + "' ";
                    sFilter += " User Name : " + txtUserID.Text.Trim();
                }

                if (bGroupSelected)
                {
                    sFormula += " and {vw_rpt_genUserMaster.group_ID} = '" + txtGroupName.Tag.ToString().Trim() + "' ";
                    sFilter += " Group Name : " + txtGroupName.Text.Trim();
                }

                print("\\Reports\\ADM\\Master\\rpt_adm_UserMaster.rpt", "User Master Report ", sFormula, sFilter);

                //{
                // sFormula += " and {vw_rpt_genUserMaster.user_ID} = '" + txtUserName.Tag.ToString().Trim() + "' ";
                //  sFilter += " User Name : " + txtUserName.Text.Trim();
                //} 
            }
            #endregion

            #region repor Master
            else if (rdoReportMaster.Checked)
            {

                if (bReprtCattagorySelected)
                {
                    sFormula += " {vw_rpt_admReportMaster.reportCategory_ID} = '" + txtReprtCatagory.Tag.ToString().Trim() + "' ";
                    sFilter += " Report Catagory : " + txtReprtCatagory.Text.Trim();
                }

                print("\\Reports\\ADM\\Master\\rpt_adm_ReportMaster.rpt", " Report  Master ", sFormula, sFilter);
            }
            #endregion

            #region Form master
            else if (rdoFormaster.Checked)
            {

                if (bModuleSelected)
                {
                    sFormula += " {vw_rpt_admFormMaster.formCategory_ID} = '" + txtModuleName.Tag.ToString().Trim() + "' ";
                    sFilter += " Module Name : " + txtModuleName.Text.Trim();
                }

                print("\\Reports\\ADM\\Master\\rpt_adm_FormMaster.rpt", " Form  Master ", sFormula, sFilter);
            }
            #endregion

            #region dontuse 
            //else if (rdoPermissionUserwise.Checked)
            //{
            //    sFormula = "{vw_rpt_admUserPermission.user_ID} <>'digiteq' AND {vw_rpt_admUserPermission.user_ID} <>'default' AND {vw_rpt_admUserPermission.user_ID} <>'admin' AND {vw_rpt_admUserPermission.isEnable} = true AND {vw_rpt_admUserPermission.isBlocked} = false";
            //    if (bUserSelected)
            //    {
            //        sFormula += " and {vw_rpt_admUserPermission.user_ID} = '" + txtUserName.Tag.ToString().Trim() + "' ";
            //        sFilter += " User Name : " + txtUserName.Text.Trim();
            //    }
            //    if (bGroupSelected)
            //    {
            //        sFormula += " and {vw_rpt_admUserPermission.group_ID} = '" + txtGroupName.Tag.ToString().Trim() + "' ";
            //        sFilter += " Group Name : " + txtGroupName.Text.Trim();
            //    }
            //    if (bModuleSelected)
            //    {
            //        sFormula += " and {vw_rpt_admUserPermission.formCategory_ID} = '" + txtModuleName.Tag.ToString().Trim() + "' ";
            //        sFilter += " Module Name : " + txtModuleName.Text.Trim();
            //    } if (bFormSelected)
            //    {
            //        sFormula += " and {vw_rpt_admUserPermission.form_ID} = '" + txtFormName.Tag.ToString().Trim() + "' ";
            //        sFilter += " Form Name : " + txtFormName.Text.Trim();
            //    }

            //    print("\\Reports\\ADM\\rpt_adm_PermissionReport_UserWise.rpt", "Permission Report (User-Wise) ", sFormula, sFilter);
            //}
            //else if (rdoPermissionFormWise.Checked)
            //{
            //    sFormula = "{vw_rpt_admUserPermission.user_ID} <>'digiteq' AND {vw_rpt_admUserPermission.user_ID} <>'default' AND {vw_rpt_admUserPermission.user_ID} <>'admin' AND {vw_rpt_admUserPermission.isEnable} = true AND {vw_rpt_admUserPermission.isBlocked} = false";
            //    if (bUserSelected)
            //    {
            //        sFormula += " and {vw_rpt_admUserPermission.user_ID} = '" + txtUserName.Tag.ToString().Trim() + "' ";
            //        sFilter += " User Name : " + txtUserName.Text.Trim();
            //    }
            //    if (bGroupSelected)
            //    {
            //        sFormula += " and {vw_rpt_admUserPermission.group_ID} = '" + txtGroupName.Tag.ToString().Trim() + "' ";
            //        sFilter += " Group Name : " + txtGroupName.Text.Trim();
            //    }
            //    if (bModuleSelected)
            //    {
            //        sFormula += " and {vw_rpt_admUserPermission.formCategory_ID} = '" + txtModuleName.Tag.ToString().Trim() + "' ";
            //        sFilter += " Module Name : " + txtModuleName.Text.Trim();
            //    } if (bFormSelected)
            //    {
            //        sFormula += " and {vw_rpt_admUserPermission.form_ID} = '" + txtFormName.Tag.ToString().Trim() + "' ";
            //        sFilter += " Form Name : " + txtFormName.Text.Trim();
            //    }

            //    print("\\Reports\\ADM\\rpt_adm_PermissionReport_FormWise.rpt", "Permission Report (Form-Wise) ", sFormula, sFilter);
            //} 
            #endregion

            #region Print Log
            else if (rdoPrintLog.Checked)
            {
                // if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.)))
                //{
                try
                {
                    Cursor = Cursors.WaitCursor;
                    glb_dtsAdmin.dt_admPrintLog.Rows.Clear();

                    //fill data table

                    foreach (tbl_atlProcess_Print oPrint in tbl_atlProcess_Print.SelectAll().Where(p => p.PrintDate.Date >= dtpFrom.Value.Date && p.PrintDate.Date <= dtpTo.Value.Date))
                    {
                        bool bUserNameOK = true, bDocumentOK = true;
                        if (bUserSelected)
                            bUserNameOK = txtUserID.Tag.ToString().Trim() == oPrint.User_ID ? true : false;
                        if (bDocumentSelected)
                            bDocumentOK = txtDocument.Text.Trim().ToUpper() == oPrint.Note_ID.ToUpper() ? true : false;

                        if (bUserNameOK && bDocumentOK)
                        {
                            glb_dtsAdmin.dt_admPrintLog.Rows.Add(clsGenaralName.getName_ProcessNote(oPrint.ProcessNote_ID), oPrint.Note_ID, oPrint.PrintDate,
                            clsGenaralName.getName_Terminal(oPrint.Terminal_ID), clsGenaralName.getName_User(oPrint.User_ID));
                        }
                    }
                    print("\\Reports\\ADM\\rpt_adm_PrintLog.rpt", " Users print History Log", glb_dtsAdmin);
                }

                catch (Exception ex)
                {
                    SEACCException.Show(ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                    glb_dtsAdmin.dt_admPrintLog.Rows.Clear();
                }

            } 
	#endregion

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
        }
        #endregion


        #region ClearField
        private void clearField()
        {
            txtModuleName.Tag = null;
            txtUserID.Tag = null;
            txtGroupName.Tag = null;
            

            txtModuleName.Text = "<All Modules>";
            txtUserID.Text = "<All Users>";
            txtGroupName.Text = "<All Groups>";
            txtDocument.Text = "";
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

                s_Path = Application.StartupPath.Replace("\\Mini ERP\\bin\\Debug", "\\ZION.ERP.Reports");

                s_Path += path;
              
                frm_ReportViewer viewer = new frm_ReportViewer();
                RD.Load(s_Path); 
                Digiteq.Classes.ReportHelper.LogonServer(ref RD);
             //   clsSecurity.LogonServer(ref RD);
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
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void print(string path, string sReportTitle, DataSet ojbDataSet)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Standed Reports", sReportFilter = "";
                //   CrystalDecisions.CrystalReports.Engine.ReportDocument objRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                ReportDocument objRpt = new ReportDocument();
                s_Path = Application.StartupPath.Replace("\\Mini ERP\\bin\\Debug", "\\ZION.ERP.Reports");
   
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(ojbDataSet); //(glbDtsBills);



                objRpt.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                objRpt.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                //if (bCustomerSelected)
                //    sReportFilter += " Customer Name : " + txtCustomer.Text.Trim();
                //if (bSelesRepSelected)
                //    sReportFilter += " Salesman Name : " + txtSalesRep.Text.Trim();
                objRpt.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sReportFilter);

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
                clsSearch.Search_SecurityFormCategory(ref txtModuleName);
            }
        }
        //private void txtFormName_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.F1)
        //    {
        //        clsSearch.Search_SecurityFormMaster(ref txtFormName);
        //    }
        //}
        private void txtReprtCatagory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_ReportCategoryID();
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
            Search_UserID();
        }
        private void txtCategory_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_SecurityFormCategory(ref txtModuleName);
        }
       // private void txtFormName_DoubleClick(object sender, EventArgs e)
        //{
         //   clsSearch.Search_SecurityFormMaster(ref txtFormName);
        //}
        private void txtReprtCatagory_DoubleClick(object sender, EventArgs e)
        {
            Search_ReportCategoryID();
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
        #endregion


        #region Serach Methods
        private void Search_GroupID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_Group();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtGroupName.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                    txtGroupName.Tag = frmSearchMaster.s_SearchID;
            }
        }
        private void Search_ReportCategoryID()
        {
            clsSearch.Search_MasterReportCategory(ref txtReprtCatagory);          
        }
        private void Search_UserID()
        {
            clsSearch.Search_MasterUserExceptByUserID(ref txtUserID, "Digiteq");
        }
        #endregion

         #region Set Enable/Disable Controls
        private void setEnableDisableConctrol()
        {
            if (rdoUserMaster.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtUserID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblUserName, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtGroupName, true);
                clsCommon.SetEnableDisable_NormalLabel(lblGroupName, true);                
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtModuleName, false);
                clsCommon.SetEnableDisable_NormalLabel(lblModuleName, false);                
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtReprtCatagory, false);
                clsCommon.SetEnableDisable_NormalLabel(lblReprtCatagory, false);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, false);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, false);

                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtReportName, false);
                //clsCommon.SetEnableDisable_NormalLabel(lblReportName, false);
                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtUserName, true);
                //clsCommon.SetEnableDisable_NormalLabel(lblUserName, true);
                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtFormName, false);
                //clsCommon.SetEnableDisable_NormalLabel(lblFormName, false);
                
                
            }
            //else if (rdoPermissionUserwise.Checked)
            //{
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtGroupName, true);
            //    clsCommon.SetEnableDisable_NormalLabel(lblGroupName, true);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtUserName, true);
            //    clsCommon.SetEnableDisable_NormalLabel(lblUserName, true);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtModuleName, true);
            //    clsCommon.SetEnableDisable_NormalLabel(lblModuleName, true);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtFormName, false);
            //    clsCommon.SetEnableDisable_NormalLabel(lblFormName, false);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtReprtCatagory, false);
            //    clsCommon.SetEnableDisable_NormalLabel(lblReprtCatagory, false);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtReportName, false);
            //    clsCommon.SetEnableDisable_NormalLabel(lblReportName, false);

            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, false);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, false);
            //}
            //else if (rdoPermissionFormWise.Checked)
            //{
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtGroupName, false);
            //    clsCommon.SetEnableDisable_NormalLabel(lblGroupName, false);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtUserName, false);
            //    clsCommon.SetEnableDisable_NormalLabel(lblUserName, false);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtModuleName, true);
            //    clsCommon.SetEnableDisable_NormalLabel(lblModuleName, true);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtFormName, true);
            //    clsCommon.SetEnableDisable_NormalLabel(lblFormName, true);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtReprtCatagory, false);
            //    clsCommon.SetEnableDisable_NormalLabel(lblReprtCatagory, false);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtReportName, false);
            //    clsCommon.SetEnableDisable_NormalLabel(lblReportName, false);

            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, false);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, false);
            //}
            //else if (rdoReportMaster.Checked)
            //{
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtGroupName, false);
            //    clsCommon.SetEnableDisable_NormalLabel(lblGroupName, false);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtUserName, false);
            //    clsCommon.SetEnableDisable_NormalLabel(lblUserName, false);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtModuleName, false);
            //    clsCommon.SetEnableDisable_NormalLabel(lblModuleName, false);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtFormName, false);
            //    clsCommon.SetEnableDisable_NormalLabel(lblFormName, false);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtReprtCatagory, true);
            //    clsCommon.SetEnableDisable_NormalLabel(lblReprtCatagory, true);
            //    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtReportName, true);
            //    clsCommon.SetEnableDisable_NormalLabel(lblReportName, true);

            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, false);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, false);
            //}
            else if (rdoFormaster.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtUserID, false);
                clsCommon.SetEnableDisable_NormalLabel(lblUserName, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtGroupName, false);
                clsCommon.SetEnableDisable_NormalLabel(lblGroupName, false);                
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtModuleName, true);
                clsCommon.SetEnableDisable_NormalLabel(lblModuleName, true);                
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtReprtCatagory, false);
                clsCommon.SetEnableDisable_NormalLabel(lblReprtCatagory, false);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, false);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, false);

                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtReportName, false);
                //clsCommon.SetEnableDisable_NormalLabel(lblReportName, false);
                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtUserName, false);
                //clsCommon.SetEnableDisable_NormalLabel(lblUserName, false);
                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtFormName, true);
                //clsCommon.SetEnableDisable_NormalLabel(lblFormName, true);

                
            }
            else if (rdoReportMaster.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtGroupName, false);
                clsCommon.SetEnableDisable_NormalLabel(lblGroupName, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtModuleName, false);
                clsCommon.SetEnableDisable_NormalLabel(lblModuleName, false);                
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtReprtCatagory, true);
                clsCommon.SetEnableDisable_NormalLabel(lblReprtCatagory, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, false);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, false);

                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtReportName, false);
                //clsCommon.SetEnableDisable_NormalLabel(lblReportName, false);
                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtUserName, false);
                //clsCommon.SetEnableDisable_NormalLabel(lblUserName, false);
                //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtFormName, true);
                //clsCommon.SetEnableDisable_NormalLabel(lblFormName, true);
            }
            else if (rdoPrintLog.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtGroupName, false);
                clsCommon.SetEnableDisable_NormalLabel(lblGroupName, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtModuleName, false);
                clsCommon.SetEnableDisable_NormalLabel(lblModuleName, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtReprtCatagory, false);
                clsCommon.SetEnableDisable_NormalLabel(lblReprtCatagory, false);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtUserID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblUserName, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtDocument, true);
                clsCommon.SetEnableDisable_NormalLabel(lblDocument,true);
            }
        }
        #endregion

        private void rdoReportMaster_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblNewCustomer_Click(object sender, EventArgs e)
        {

        }

        private void txtUserID_DoubleClick(object sender, EventArgs e)
        {
        Search_UserID();          
        }

        private void rdoPrintLog_CheckedChanged(object sender, EventArgs e)
        {

        }
        

    }
}
