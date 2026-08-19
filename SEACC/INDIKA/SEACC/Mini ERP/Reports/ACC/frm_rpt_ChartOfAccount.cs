using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Zion.ERP.Reports.DataSets;
using DataTire;

namespace Digiteq
{



    public partial class frm_rpt_ChartOfAccount : MettroForm
    {
        
        //form manage


        dts_Accounts glb_dts_Accounts = new dts_Accounts();
        dts_GeneralLedger glb_dtsGeneralLedger = new dts_GeneralLedger();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();

        //for security handle
        public bool bNoAccess;

        int iReport;


        #region Form Load
        public frm_rpt_ChartOfAccount()
        {
            //iFormID = clsSecurity.getFormID(FormName.ReportFinancialYears);
            //if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            //{
            //    bNoAccess = true;
            //}
            InitializeComponent();
            iFormID = clsSecurity.getFormID(FormName.ReportChartOfAccounts);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
        }

        private void frm_rpt_ChartOfAccount_Load(object sender, EventArgs e)
        {
            if (!bNoAccess)
            {
                clsFormatter.setFormatForm(this, " Master Reports ", 2, iFormID);
                clearField();
                DisplayReports();
            }
            else
            {
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + this.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Display Reports
        private void DisplayReports()
        {
            try
            {
                dgvReports.Rows.Clear();
                dgvReports.DataSource = DBHandling.ExecQuery("EXEC sp_Reports '" + 20 + "'").Tables[0];
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearField();
        }
        #endregion

        #region Btn Print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (PrintValidity())
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
                                if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(Report), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                                {
                                    #region Financial Year
                                    if (Report == enum_ReportName.RG_Financial_Year)
                                    {
                                        //print(sReportPath, sReportTitle_Main);

                                        try
                                        {
                                            Cursor = Cursors.WaitCursor;
                                            glb_dts_Accounts.Clear();

                                            glb_dts_Accounts.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, "", clsSecurity.UserNameLoged, "");

                                            foreach (tbl_accFinancialYearMaster oFinYear in tbl_accFinancialYearMaster.SelectAll())
                                            {
                                                if (oFinYear.FinancialYear_ID != "default")
                                                {
                                                    glb_dts_Accounts.dt_accFinancialYear.Adddt_accFinancialYearRow(oFinYear.FinancialYear_ID, oFinYear.FinancialYearName, oFinYear.StatusID, clsGenaralName.GetStatusName(oFinYear.StatusID), oFinYear.CreateUser_ID, clsGenaralName.getName_User(oFinYear.CreateUser_ID), oFinYear.DateCreate);
                                                }
                                            }
                                            print(sReportPath, sReportTitle_Main, glb_dts_Accounts, clsAutocode.getReportID(Report));

                                        }
                                        catch (Exception)
                                        {
                                        }
                                        finally
                                        {
                                            glb_dts_Accounts.Clear();
                                            Cursor = Cursors.Default;
                                        }
                                    }
                                    #endregion

                                    #region General Ledger
                                    else if (Report == enum_ReportName.RG_ChartOfAccount_GeneralLedger)
                                    {
                                        //print(sReportPath, sReportTitle_Main);
                                        try
                                        {
                                            Cursor = Cursors.WaitCursor;
                                            glb_dts_Accounts.Clear();

                                            glb_dts_Accounts.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, "", clsSecurity.UserNameLoged, "");

                                            foreach (tbl_zAccGLMaster_MainCatagory oGLCat in tbl_zAccGLMaster_MainCatagory.SelectAll())
                                            {
                                                if (oGLCat.GlMainCatagory_ID != "default")
                                                {
                                                    glb_dts_Accounts.dt_accGLMainCategory.Adddt_accGLMainCategoryRow(oGLCat.GlMainCatagory_ID, oGLCat.GlMainCatagoryName, oGLCat.IsCredit ? "Credit" : "Debit");
                                                }
                                            }
                                            print(sReportPath, sReportTitle_Main, glb_dts_Accounts, clsAutocode.getReportID(Report));

                                        }
                                        catch (Exception)
                                        {
                                        }
                                        finally
                                        {
                                            glb_dts_Accounts.Clear();
                                            Cursor = Cursors.Default;
                                        }
                                    }
                                    #endregion

                                    #region Sub Ledger
                                    else if (Report == enum_ReportName.RG_ChartOfAccount_SugLedger)
                                    {
                                        //print(sReportPath, sReportTitle_Main);

                                        try
                                        {
                                            Cursor = Cursors.WaitCursor;
                                            glb_dts_Accounts.Clear();

                                            glb_dts_Accounts.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, "", clsSecurity.UserNameLoged, "");

                                            foreach (tbl_zAccGLMaster_SubCatagory oGLSubCat in tbl_zAccGLMaster_SubCatagory.SelectAll())
                                            {
                                                if (oGLSubCat.GlSubCatagory_ID != "default")
                                                {
                                                    tbl_zAccGLMaster_MainCatagory oMainCat = tbl_zAccGLMaster_MainCatagory.Select(oGLSubCat.GlMainCatagory_ID);
                                                    if (oMainCat != null)
                                                        glb_dts_Accounts.dt_accGLSubCategory.Adddt_accGLSubCategoryRow(oGLSubCat.GlMainCatagory_ID, oMainCat.GlMainCatagoryName, oGLSubCat.GlSubCatagory_ID, oGLSubCat.GlSubCatagoryName, oGLSubCat.IsActive ? "Active" : "In Active");
                                                }
                                            }
                                            print(sReportPath, sReportTitle_Main, glb_dts_Accounts, clsAutocode.getReportID(Report));

                                        }
                                        catch (Exception)
                                        {
                                        }
                                        finally
                                        {
                                            glb_dts_Accounts.Clear();
                                            Cursor = Cursors.Default;
                                        }
                                    }
                                    #endregion

                                    #region Acc Type 1
                                    else if (Report == enum_ReportName.RG_Account_Type)
                                    {
                                        //print(sReportPath, sReportTitle_Main);

                                        try
                                        {
                                            Cursor = Cursors.WaitCursor;
                                            glb_dts_Accounts.Clear();

                                            glb_dts_Accounts.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, "", clsSecurity.UserNameLoged, "");

                                            foreach (tbl_zAccGLMaster_AccountType oGLAccType in tbl_zAccGLMaster_AccountType.SelectAll().Where(p => p.Parent_ID == "default"))
                                            {
                                                if (oGLAccType.GlAccountType_ID != "default")
                                                {
                                                    tbl_zAccGLMaster_SubCatagory oSubCat = tbl_zAccGLMaster_SubCatagory.Select(oGLAccType.GlSubCatagory_ID);
                                                    if (oSubCat != null)
                                                    {
                                                        tbl_zAccGLMaster_MainCatagory oMainCat = tbl_zAccGLMaster_MainCatagory.Select(oSubCat.GlMainCatagory_ID);
                                                        if (oMainCat != null)
                                                            glb_dts_Accounts.dt_accGLAccountType.Adddt_accGLAccountTypeRow(oSubCat.GlMainCatagory_ID, oMainCat.GlMainCatagoryName, oGLAccType.GlSubCatagory_ID, oSubCat.GlSubCatagoryName, oGLAccType.GlAccountType_ID, oGLAccType.GlAccountTypeName, oGLAccType.IsActive ? "Active" : "In Active", oGLAccType.IsCredit, "");
                                                    }
                                                }
                                            }
                                            print(sReportPath, sReportTitle_Main, glb_dts_Accounts, clsAutocode.getReportID(Report));

                                        }
                                        catch (Exception)
                                        {
                                        }
                                        finally
                                        {
                                            glb_dts_Accounts.Clear();
                                            Cursor = Cursors.Default;
                                        }
                                    }
                                    #endregion

                                    #region Acc. type 2
                                    else if (Report == enum_ReportName.RG_Account_Type2)
                                    {
                                        //print(sReportPath, sReportTitle_Main);

                                        try
                                        {
                                            Cursor = Cursors.WaitCursor;
                                            glb_dts_Accounts.Clear();

                                            glb_dts_Accounts.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, "", clsSecurity.UserNameLoged, "");

                                            foreach (tbl_zAccGLMaster_AccountType oGLAccType in tbl_zAccGLMaster_AccountType.SelectAll().Where(p => p.Parent_ID != "default"))
                                            {
                                                if (oGLAccType.GlAccountType_ID != "default")
                                                {
                                                    tbl_zAccGLMaster_SubCatagory oSubCat = tbl_zAccGLMaster_SubCatagory.Select(oGLAccType.GlSubCatagory_ID);
                                                    if (oSubCat != null)
                                                    {
                                                        tbl_zAccGLMaster_MainCatagory oMainCat = tbl_zAccGLMaster_MainCatagory.Select(oSubCat.GlMainCatagory_ID);
                                                        if (oMainCat != null)
                                                            glb_dts_Accounts.dt_accGLAccountType.Adddt_accGLAccountTypeRow(oSubCat.GlMainCatagory_ID, oMainCat.GlMainCatagoryName, oGLAccType.GlSubCatagory_ID, oSubCat.GlSubCatagoryName, oGLAccType.GlAccountType_ID, oGLAccType.GlAccountTypeName, oGLAccType.IsActive ? "Active" : "In Active", oGLAccType.IsCredit, oGLAccType.Parent_ID);
                                                    }
                                                }
                                            }
                                            print(sReportPath, sReportTitle_Main, glb_dts_Accounts, clsAutocode.getReportID(Report));

                                        }
                                        catch (Exception)
                                        {
                                        }
                                        finally
                                        {
                                            glb_dts_Accounts.Clear();
                                            Cursor = Cursors.Default;
                                        }
                                    }
                                    #endregion

                                    #region Acc. Code
                                    else if (Report == enum_ReportName.RG_Account_Code)
                                    {
                                        //print(sReportPath, sReportTitle_Main);

                                        try
                                        {
                                            Cursor = Cursors.WaitCursor;
                                            glb_dts_Accounts.Clear();

                                            glb_dts_Accounts.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, "", clsSecurity.UserNameLoged, "");

                                            foreach (tbl_accGLMaster oGLAcc in tbl_accGLMaster.SelectAll())
                                            {
                                                if (oGLAcc.Gl_ID != "default")
                                                {
                                                    tbl_zAccGLMaster_AccountType oAccType = tbl_zAccGLMaster_AccountType.Select(oGLAcc.GlAccountType_ID);
                                                    if (oAccType != null)
                                                    {
                                                        tbl_zAccGLMaster_SubCatagory oSubCat = tbl_zAccGLMaster_SubCatagory.Select(oAccType.GlSubCatagory_ID);
                                                        if (oSubCat != null)
                                                        {
                                                            tbl_zAccGLMaster_MainCatagory oMainCat = tbl_zAccGLMaster_MainCatagory.Select(oSubCat.GlMainCatagory_ID);
                                                            if (oMainCat != null)
                                                                glb_dts_Accounts.dt_accAccountsCode.Adddt_accAccountsCodeRow(oGLAcc.Gl_ID, oGLAcc.GlName, oAccType.GlSubCatagory_ID, oSubCat.GlSubCatagoryName, oGLAcc.GlAccountType_ID, oAccType.GlAccountTypeName, oSubCat.GlMainCatagory_ID, oMainCat.GlMainCatagoryName, 0, oGLAcc.IsDeleted);
                                                        }
                                                    }
                                                }
                                            }
                                            print(sReportPath, sReportTitle_Main, glb_dts_Accounts, clsAutocode.getReportID(Report));

                                        }
                                        catch (Exception)
                                        {
                                        }
                                        finally
                                        {
                                            glb_dts_Accounts.Clear();
                                            Cursor = Cursors.Default;
                                        }
                                    } 
                                    #endregion

                                    else if (Report == enum_ReportName.RG_ChartOfAccount_GL)
                                    {
                                        //getGLCodeForTree(sReportPath, sReportTitle_Main);
                                        try
                                        {
                                            Cursor = Cursors.WaitCursor;
                                            glb_dtsGeneralLedger.Clear();
                                            glb_dtsGeneralLedger.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, "", clsSecurity.UserNameLoged, "");

                                            string sQuary = "SELECT * FROM [dbo].[func_AccountHierarchy] ()";
                                            glb_dtsGeneralLedger.dt_acc_AccountHierarchyTree.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                                            //frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                            //rpt.print(sReportPath, glb_dtsGeneralLedger, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                            print(sReportPath, sReportTitle_Main, glb_dtsGeneralLedger, clsAutocode.getReportID(Report));
                                        }
                                        catch (Exception)
                                        {
                                        }
                                        finally
                                        {
                                            glb_dts_Accounts.Clear();
                                            Cursor = Cursors.Default;
                                        }
                                    }

                                    else if (Report == enum_ReportName.RG_ChartOfAccount_SubAcc1)
                                    {
                                        //getSubAccount1(sReportPath, sReportTitle_Main);
                                        try
                                        {
                                            Cursor = Cursors.WaitCursor;
                                            glb_dts_Accounts.Clear();

                                            glb_dts_Accounts.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, "", clsSecurity.UserNameLoged, "");
                                            foreach (tbl_zAccCostCenter1 oAccCost1 in tbl_zAccCostCenter1.SelectAll())
                                            {
                                                if (oAccCost1.CostCenter1_ID != "default")
                                                {
                                                    glb_dts_Accounts.dt_accSubAccounts_1.Adddt_accSubAccounts_1Row(oAccCost1.CostCenter1_ID, oAccCost1.CostCenter1Name);
                                                }
                                            }
                                            print(sReportPath, sReportTitle_Main, glb_dts_Accounts, clsAutocode.getReportID(enum_ReportName.RG_ChartOfAccount_SubAcc1));

                                        }
                                        catch (Exception)
                                        {
                                        }
                                        finally
                                        {
                                            glb_dts_Accounts.Clear();
                                            Cursor = Cursors.Default;
                                        }
                                    }

                                    else if (Report == enum_ReportName.RG_ChartOfAccount_SubAcc2)
                                    {
                                        //getSubAccount2(sReportPath, sReportTitle_Main);
                                        try
                                        {
                                            Cursor = Cursors.WaitCursor;
                                            glb_dts_Accounts.Clear();
                                            glb_dts_Accounts.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, "", clsSecurity.UserNameLoged, "");

                                            foreach (tbl_zAccCostCenter2 oAccCost2 in tbl_zAccCostCenter2.SelectAll())
                                            {
                                                if (oAccCost2.CostCenter2_ID != "default")
                                                {
                                                    glb_dts_Accounts.dt_accSubAccounts_2.Adddt_accSubAccounts_2Row(oAccCost2.CostCenter2_ID, oAccCost2.CostCenter2Name);
                                                }
                                            }
                                            print(sReportPath, sReportTitle_Main, glb_dts_Accounts, clsAutocode.getReportID(enum_ReportName.RG_ChartOfAccount_SubAcc2));
                                        }
                                        catch (Exception)
                                        {
                                        }
                                        finally
                                        {
                                            glb_dts_Accounts.Clear();
                                            Cursor = Cursors.Default;
                                        }
                                    }

                                    else if (Report == enum_ReportName.RG_ChartOfAccount_Tagging)
                                    {
                                        //getMasterRecordAccountTagging();
                                        try
                                        {
                                            Cursor = Cursors.WaitCursor;
                                            glb_dts_Accounts.Clear();
                                            glb_dts_Accounts.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, "", clsSecurity.UserNameLoged, "");

                                            int iGLCount = 0;
                                            string sRecordCode = "", sRecordName = "";

                                            #region Customer Master  
                                            foreach (tbl_genCustomerMaster oCustomers in tbl_genCustomerMaster.SelectAll().Where(p => !p.IsDeleted && p.Customer_ID != "default").OrderBy(p => p.CustomerName))
                                            {
                                                iGLCount = 0;
                                                sRecordCode = oCustomers.Customer_ID; sRecordName = oCustomers.CustomerName;
                                                foreach (tbl_accGLMaster_Customer oAccCustomer in tbl_accGLMaster_Customer.SelectAllByCustomer_ID(oCustomers.Customer_ID))
                                                {
                                                    if (iGLCount > 0)
                                                    { sRecordCode = ""; sRecordName = ""; }
                                                    glb_dts_Accounts.dt_accMasterAccountTagging.Adddt_accMasterAccountTaggingRow(sRecordCode, sRecordName, oAccCustomer.Gl_ID, clsGenaralName.getName_AccountName(oAccCustomer.Gl_ID), "Customer Master List");
                                                    iGLCount++;
                                                }
                                                if (iGLCount == 0)
                                                    glb_dts_Accounts.dt_accMasterAccountTagging.Adddt_accMasterAccountTaggingRow(sRecordCode, sRecordName, "", "", "Customer Master List");
                                            }
                                            #endregion

                                            #region Supplier Master      
                                            foreach (tbl_genSupplierMaster oSupplier in tbl_genSupplierMaster.SelectAll().Where(p => !p.IsDeleted && p.Supplier_ID != "default").OrderBy(p => p.SupplierName))
                                            {
                                                iGLCount = 0;
                                                sRecordCode = oSupplier.Supplier_ID; sRecordName = oSupplier.SupplierName;
                                                foreach (tbl_accGLMaster_Supplier oAccCustomer in tbl_accGLMaster_Supplier.SelectAllBySupplier_ID(oSupplier.Supplier_ID))
                                                {
                                                    if (iGLCount > 0)
                                                    { sRecordCode = ""; sRecordName = ""; }
                                                    glb_dts_Accounts.dt_accMasterAccountTagging.Adddt_accMasterAccountTaggingRow(sRecordCode, sRecordName, oAccCustomer.Gl_ID, clsGenaralName.getName_AccountName(oAccCustomer.Gl_ID), "Supplier Master List");
                                                    iGLCount++;
                                                }
                                                if (iGLCount == 0)
                                                    glb_dts_Accounts.dt_accMasterAccountTagging.Adddt_accMasterAccountTaggingRow(sRecordCode, sRecordName, "", "", "Supplier Master List");
                                            }
                                            #endregion

                                            #region Bank Master
                                            foreach (tbl_genCompanyAccount oBank in tbl_genCompanyAccount.SelectAll().Where(p => p.CompanyID != "default" && p.AccountNumber != ""))
                                            {
                                                iGLCount = 0;
                                                sRecordCode = oBank.AccountNumber; sRecordName = clsGenaralName.getName_Bank(oBank.Bank_ID);
                                                foreach (tbl_accGLMaster_Bank oAccBank in tbl_accGLMaster_Bank.SelectAll().Where(q => q.AccountNumber == oBank.AccountNumber))
                                                {
                                                    if (iGLCount > 0)
                                                    { sRecordCode = ""; sRecordName = ""; }
                                                    glb_dts_Accounts.dt_accMasterAccountTagging.Adddt_accMasterAccountTaggingRow(sRecordCode, sRecordName, oAccBank.Gl_ID, clsGenaralName.getName_AccountName(oAccBank.Gl_ID), "Bank Master List");
                                                    iGLCount++;
                                                }
                                                if (iGLCount == 0)
                                                    glb_dts_Accounts.dt_accMasterAccountTagging.Adddt_accMasterAccountTaggingRow(sRecordCode, sRecordName, "", "", "Bank Master List");
                                            }
                                            #endregion

                                            print(sReportPath, sReportTitle_Main, glb_dts_Accounts, clsAutocode.getReportID(Report));
                                        }
                                        catch (Exception) { }
                                        finally
                                        {
                                            glb_dts_Accounts.Clear();
                                            Cursor = Cursors.Default;
                                        }
                                    }

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
        }
        #endregion

        #region Clear Fiels
        private void clearField()
        {
            //txtFinancialYear.Tag = null;

            //txtFinancialYear.Text = "<All Financial Years>";

            //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtFinancialYear, true);
            //clsCommon.SetEnableDisable_NormalLabel(lblFinancialYear, true);
        }
        #endregion        
                


        #region Print method for Data Set

        private void print(string path, string sReportTitle, DataSet ojbDataSet,string sReportID)
        {
            try
            {
                string sHeaderTitle = "Standed Reports";
                
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("HeaderTitle", sHeaderTitle, true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle", sReportTitle, true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", clsSecurity.CompanyName, true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", clsSecurity.CompanyAddress1, true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", clsSecurity.CompanyAddress2, true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqName", clsSecurity.DigiteqName, true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqEmail", clsCommon.getCompanyEmail(), true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DateRange", clsSecurity.getServerDateTime().ToShortDateString(), true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("UserName", clsSecurity.UserNameLoged, true);

                frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
                ReportViewer.print(path, ojbDataSet, glb_dtsReportExport.dt_rptParameter, sReportID);
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
        
        #region Print Permission Validity
        private bool PrintValidity()
        {
            return true;
        }
        #endregion        

        private void getGLCodeForTree(string path, string sReportTitle)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                glb_dtsGeneralLedger.Clear();

                string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.RG_ChartOfAccount_GL), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                {
                    string sQuary = "SELECT * FROM [dbo].[func_AccountHierarchy] ()";
                    glb_dtsGeneralLedger.dt_acc_AccountHierarchyTree.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                    frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                    print(path, sReportTitle, glb_dtsGeneralLedger, clsAutocode.getReportID(enum_ReportName.RG_ChartOfAccount_GL));
                }

                #region old
                //Cursor = Cursors.WaitCursor;
                //glb_dts_Accounts.dt_accAccountsCode.Rows.Clear();
                //string sOldMainCategory = "", sOldSubCategory = "", sOldType = "";

                //string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                //if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.RG_ChartOfAccount_GL), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                //{
                //    foreach (tbl_zAccGLMaster_MainCatagory oGLMainCatagory in tbl_zAccGLMaster_MainCatagory.SelectAll().Where(p => p.IsActive))
                //    {
                //        foreach (tbl_zAccGLMaster_SubCatagory oGLSubCatagory in tbl_zAccGLMaster_SubCatagory.SelectAllByGlMainCatagory_ID(oGLMainCatagory.GlMainCatagory_ID).Where(p => p.IsActive))
                //        {
                //            foreach (tbl_zAccGLMaster_AccountType oGLAccountType in tbl_zAccGLMaster_AccountType.SelectAllByGlSubCatagory_ID(oGLSubCatagory.GlSubCatagory_ID).Where(p => p.IsActive))
                //            {
                //                foreach (tbl_accGLMaster oGLCode in tbl_accGLMaster.SelectAllByGlAccountType_ID(oGLAccountType.GlAccountType_ID))//.Where(p => p.IsActive)
                //                {
                //                    string sTmpMainCategory = oGLMainCatagory.GlMainCatagoryName, sTmpSubCategory = oGLSubCatagory.GlSubCatagoryName, sTmpType = oGLAccountType.GlAccountTypeName;
                //                    string sMainCategory = sOldMainCategory == sTmpMainCategory ? "-" : sTmpMainCategory;
                //                    string sSubCategory = sOldSubCategory == sTmpSubCategory ? "-" : sTmpSubCategory;
                //                    string sType = sOldType == sTmpType ? "-" : sTmpType;

                //                    glb_dts_Accounts.dt_accAccountsCode.Adddt_accAccountsCodeRow(oGLMainCatagory.GlMainCatagory_ID, sMainCategory, oGLSubCatagory.GlSubCatagory_ID, sSubCategory,
                //                    oGLAccountType.GlAccountType_ID, sType, oGLCode.Gl_ID, oGLCode.GlName, 0, true);

                //                    sOldMainCategory = sTmpMainCategory; sOldSubCategory = sTmpSubCategory; sOldType = sTmpType;
                //                }
                //            }
                //        }
                //    }
                //    //print("\\reports\\ACC\\rpt_accAccountCodeTreeView.rpt", "Account Code Master (Tree View)", glb_dts_Accounts.dt_accAccountsCode);
                //    print("\\reports\\ACC\\rpt_accAccountCodeTreeView.rpt", "Account Code Master (Tree View)", glb_dts_Accounts, clsAutocode.getReportID(enum_ReportName.RG_ChartOfAccount_GL));
                //} 
                #endregion
            }
            catch (Exception)
            {
            }
            finally
            {
                glb_dts_Accounts.dt_accAccountsCode.Rows.Clear();
                Cursor = Cursors.Default;
            }
        }

        private void getSubAccount1(string path, string sReportTitle)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                glb_dts_Accounts.dt_accSubAccounts_1.Rows.Clear();

                string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.RG_ChartOfAccount_SubAcc1), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                {
                    foreach (tbl_zAccCostCenter1 oAccCost1 in tbl_zAccCostCenter1.SelectAll())
                    {
                        if (oAccCost1.CostCenter1_ID != "default")
                        {
                            glb_dts_Accounts.dt_accSubAccounts_1.Adddt_accSubAccounts_1Row(oAccCost1.CostCenter1_ID, oAccCost1.CostCenter1Name);
                        }
                    }
                    //print("\\reports\\ACC\\rpt_accSubAccount_1.rpt", "Sub-Account 1   Cost/Profit Center Title", glb_dts_Accounts.dt_accSubAccounts_1);
                    print(path, sReportTitle, glb_dts_Accounts, clsAutocode.getReportID(enum_ReportName.RG_ChartOfAccount_SubAcc1));
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                glb_dts_Accounts.dt_accSubAccounts_1.Rows.Clear();
                Cursor = Cursors.Default;
            }
        }

        private void getSubAccount2(string path, string sReportTitle)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                glb_dts_Accounts.dt_accSubAccounts_2.Rows.Clear();

                string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.RG_ChartOfAccount_SubAcc2), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                {
                foreach (tbl_zAccCostCenter2 oAccCost2 in tbl_zAccCostCenter2.SelectAll())
                {
                    if (oAccCost2.CostCenter2_ID != "default")
                    {
                        glb_dts_Accounts.dt_accSubAccounts_2.Adddt_accSubAccounts_2Row(oAccCost2.CostCenter2_ID, oAccCost2.CostCenter2Name);
                    }
                }
                //print("\\reports\\ACC\\rpt_accSubAccount_2.rpt", "Sub-Account 2 Cost/Profit Center Activity", glb_dts_Accounts.dt_accSubAccounts_2);
                print(path, sReportTitle, glb_dts_Accounts, clsAutocode.getReportID(enum_ReportName.RG_ChartOfAccount_SubAcc2));
            }
            }
            catch (Exception)
            {
            }
            finally
            {
                glb_dts_Accounts.dt_accSubAccounts_2.Rows.Clear();
                Cursor = Cursors.Default;
            }
        }

        private void getMasterRecordAccountTagging()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                glb_dts_Accounts.dt_accMasterAccountTagging.Rows.Clear();
                int iGLCount = 0;
                string sRecordCode = "", sRecordName = "";

                string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.RG_ChartOfAccount_Tagging), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                {
                //Customer Master               
                foreach (tbl_genCustomerMaster oCustomers in tbl_genCustomerMaster.SelectAll().Where(p => !p.IsDeleted && p.Customer_ID != "default").OrderBy(p => p.CustomerName))
                {
                    iGLCount = 0;
                    sRecordCode = oCustomers.Customer_ID; sRecordName = oCustomers.CustomerName;
                    foreach (tbl_accGLMaster_Customer oAccCustomer in tbl_accGLMaster_Customer.SelectAllByCustomer_ID(oCustomers.Customer_ID))
                    {
                        if (iGLCount > 0)
                        { sRecordCode = ""; sRecordName = ""; }
                        glb_dts_Accounts.dt_accMasterAccountTagging.Adddt_accMasterAccountTaggingRow(sRecordCode, sRecordName, oAccCustomer.Gl_ID, clsGenaralName.getName_AccountName(oAccCustomer.Gl_ID), "Customer Master List");
                        iGLCount++;
                    }
                    if (iGLCount == 0)
                        glb_dts_Accounts.dt_accMasterAccountTagging.Adddt_accMasterAccountTaggingRow(sRecordCode, sRecordName, "", "", "Customer Master List");
                }
                //Supplier Master             
                foreach (tbl_genSupplierMaster oSupplier in tbl_genSupplierMaster.SelectAll().Where(p => !p.IsDeleted && p.Supplier_ID != "default").OrderBy(p => p.SupplierName))
                {
                    iGLCount = 0;
                    sRecordCode = oSupplier.Supplier_ID; sRecordName = oSupplier.SupplierName;
                    foreach (tbl_accGLMaster_Supplier oAccCustomer in tbl_accGLMaster_Supplier.SelectAllBySupplier_ID(oSupplier.Supplier_ID))
                    {
                        if (iGLCount > 0)
                        { sRecordCode = ""; sRecordName = ""; }
                        glb_dts_Accounts.dt_accMasterAccountTagging.Adddt_accMasterAccountTaggingRow(sRecordCode, sRecordName, oAccCustomer.Gl_ID, clsGenaralName.getName_AccountName(oAccCustomer.Gl_ID), "Supplier Master List");
                        iGLCount++;
                    }
                    if (iGLCount == 0)
                        glb_dts_Accounts.dt_accMasterAccountTagging.Adddt_accMasterAccountTaggingRow(sRecordCode, sRecordName, "", "", "Supplier Master List");
                }
                //Bank Master
                foreach (tbl_genCompanyAccount oBank in tbl_genCompanyAccount.SelectAll().Where(p => p.CompanyID != "default" && p.AccountNumber != ""))
                {
                    iGLCount = 0;
                    sRecordCode = oBank.AccountNumber; sRecordName = clsGenaralName.getName_Bank(oBank.Bank_ID);
                    foreach (tbl_accGLMaster_Bank oAccBank in tbl_accGLMaster_Bank.SelectAll().Where(q => q.AccountNumber == oBank.AccountNumber))
                    {
                        if (iGLCount > 0)
                        { sRecordCode = ""; sRecordName = ""; }
                        glb_dts_Accounts.dt_accMasterAccountTagging.Adddt_accMasterAccountTaggingRow(sRecordCode, sRecordName, oAccBank.Gl_ID, clsGenaralName.getName_AccountName(oAccBank.Gl_ID), "Bank Master List");
                        iGLCount++;
                    }
                    if (iGLCount == 0)
                        glb_dts_Accounts.dt_accMasterAccountTagging.Adddt_accMasterAccountTaggingRow(sRecordCode, sRecordName, "", "", "Bank Master List");
                }
                //print("\\reports\\ACC\\rpt_accMasterRecordAccountSummary.rpt", "Master Record Account Summary", glb_dts_Accounts.dt_accMasterAccountTagging);
                print("\\reports\\ACC\\rpt_accMasterRecordAccountSummary.rpt", "Master Record Account Summary", glb_dts_Accounts, clsAutocode.getReportID(enum_ReportName.RG_ChartOfAccount_Tagging));
            }
            }
            catch (Exception )
            {

            }
            finally
            {
                glb_dts_Accounts.dt_accMasterAccountTagging.Rows.Clear();
                Cursor = Cursors.Default;
            }
        }
    }
}