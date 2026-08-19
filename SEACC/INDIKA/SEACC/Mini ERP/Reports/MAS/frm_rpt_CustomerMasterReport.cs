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
using SEACC.WinFormControls.Forms;
using Zion.ERP.Reports.DataSets;

namespace Digiteq
{
    public partial class frm_rpt_CustomerMasterReport : MettroForm
    {
        


        bool bCustomerSelected = false, bSelesRepSelected = false, bTownSelected = false, bRouteSelected = false, bClassName = false, bTypeName = false, bCategory = false;
       dts_Master dtsMaster = new dts_Master();




        #region Form load
        public frm_rpt_CustomerMasterReport()
        {
            iFormID = clsSecurity.getFormID(FormName.CustomerMasterReport);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_rpt_CustomerMasterReport_Load(object sender, EventArgs e)
        {
            //clsFormatter.setFormatForm(this, " Cash Book Master Report", 3);
            clearField();
        }
        #endregion

        #region Btn print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            
            bCustomerSelected = false; bClassName = false; bTypeName = false; bCategory = false;
            bSelesRepSelected = false; bTownSelected = false; bRouteSelected = false;

            string sFormula = "";
            string sFilter = "";
            #endregion

            #region Selected Filters

            if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Trim().Length > 0)
            {
                bCustomerSelected = true;
                sFilter += "Customer : " + txtCustomer.Text;
            }
            if (txtClassName.Tag != null && txtClassName.Tag.ToString().Trim().Length > 0)
            {
                bClassName = true;
                sFilter += (sFilter == "" ? "" : " | ") + "Customer Class : " + txtClassName.Text;
            }
            if (txtTypeName.Tag != null && txtTypeName.Tag.ToString().Trim().Length > 0)
            {
                bTypeName = true;
                sFilter += (sFilter == "" ? "" : " | ") + "Customer Type : " + txtTypeName.Text;
            }
            if (txtCategory.Tag != null && txtCategory.Tag.ToString().Trim().Length > 0)
            {
                bCategory = true;
                sFilter += (sFilter == "" ? "" : " | ") + "Customer Category : " + txtCategory.Text;
            }
            if (txtSalesRep.Tag != null && txtSalesRep.Tag.ToString().Trim().Length > 0)
            {
                bSelesRepSelected = true;
                sFilter += (sFilter == "" ? "" : " | ") + "Salesman : " + txtSalesRep.Text;
            }
            if (txtTown.Tag != null && txtTown.Tag.ToString().Trim().Length > 0)
            {
                bTownSelected = true;
                sFilter += (sFilter == "" ? "" : " | ") + "Town : " + txtTown.Text;
            }
            if (txtRoute.Tag != null && txtRoute.Tag.ToString().Trim().Length > 0)
            {
                bRouteSelected = true;
                sFilter += (sFilter == "" ? "" : " | ") + "Route : " + txtTown.Text;
            }
            if (chkBlackListed.Checked)
            {
                sFilter += (sFilter == "" ? "" : " | ") + "Black Listed Customers Only";
            }

            #endregion

            #region Old Code (View)
            //if (false)
            //{
            //    #region Search Filters
            //    sFormula += "{vw_rpt_masCustomerSummery.customer_ID} <> 'default' and {vw_rpt_masCustomerSummery.isBlacklisted} = " + chkBlackListed.Checked + " ";
            //    if (bCustomerSelected)
            //        sFormula += "and {vw_rpt_masCustomerSummery.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";
            //    if (bSelesRepSelected)
            //        sFormula += " and {vw_rpt_masCustomerSummery.salesRep_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";
            //    if (bTownSelected)
            //        sFormula += " and {vw_rpt_masCustomerSummery.town_ID} = '" + txtTown.Tag.ToString().Trim() + "'";
            //    if (bRouteSelected)
            //        sFormula += " and {tbl_genRoute.route_ID} = " + txtRoute.Tag.ToString().Trim() + "";
            //    if (bClassName)
            //        sFormula += " and {vw_rpt_masCustomerSummery.customerClass_ID} = '" + txtClassName.Tag.ToString().Trim() + "'";
            //    if (bTypeName)
            //        sFormula += " and {vw_rpt_masCustomerSummery.customerType_ID} = '" + txtTypeName.Tag.ToString().Trim() + "'";
            //    if (bCategory)
            //        sFormula += " and {vw_rpt_masCustomerSummery.customerCategory_ID} = '" + txtCategory.Tag.ToString().Trim() + "'";
            //    #endregion

            //    if (rdoCustomerMaster.Checked)
            //    {
            //        if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_CustomerMasterSummary_CustomerWise)))
            //            print("\\reports\\MAS\\Standard\\rpt_masCustomerSummery_Customer.rpt", "Customer Master [Summary](Customer-wise)  ", sFormula);
            //    }
            //    if (rdoSalesRep.Checked)
            //    {
            //        if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_CustomerMasterSummary_SelesRepWise)))
            //            print("\\reports\\MAS\\Standard\\rpt_masCustomerSummery_SalesRep.rpt", "Customer Master [Summary](Sales-wise)  ", sFormula);
            //    }
            //    if (rdoRouterWise.Checked)
            //    {
            //        if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_CustomerMasterSummary_RouterWise)))
            //            print("\\reports\\MAS\\Standard\\rpt_masCustomerSummery_Route.rpt", "Customer Master [Summary](Router-wise) ", sFormula);
            //    }
            //    if (rdoTownWise.Checked)
            //    {
            //        if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_CustomerMasterSummary_TownWise)))
            //            print("\\reports\\MAS\\Standard\\rpt_masCustomerSummery_Town.rpt", "Customer Master [Summary](Town-wise) ", sFormula);
            //    }
            //}
            //else
            //{ 
            #endregion

            try
            {
                Cursor = Cursors.WaitCursor;
                string sReportTitle_Main = "", sReportTitle_Sub = "", sRptPath = "", sReport_ID = "";

                #region Customer Master Summary (Customer-wise)
                if (rdoCustomerMaster.Checked)
                {
                    if (clsSecurity.PermissionToPrint_WithMessage(
                        clsAutocode.getReportID(enum_ReportName.RG_CustomerMasterSummary_CustomerWise)))
                    {
                        sReport_ID = clsAutocode.getReportID(enum_ReportName.RG_CustomerMasterSummary_CustomerWise);
                        clsHelpMethods_Local.GetReportPath(sReport_ID, ref sReportTitle_Main, ref sReportTitle_Sub,
                            ref sRptPath);
                    }
                }
                #endregion

                #region Customer Master Summary - Credit limit
                if (rdoCreditLimit.Checked)
                {
                    if (clsSecurity.PermissionToPrint_WithMessage(
                        clsAutocode.getReportID(enum_ReportName.RG_CustomerMasterSummary_CreditLimit)))
                    {
                        sReport_ID = clsAutocode.getReportID(enum_ReportName.RG_CustomerMasterSummary_CreditLimit);
                        clsHelpMethods_Local.GetReportPath(sReport_ID, ref sReportTitle_Main, ref sReportTitle_Sub,
                            ref sRptPath);
                    }
                }
                #endregion

                #region Customer Master Summary (Sales Rep-wise)
                if (rdoSalesRep.Checked)
                {
                    if (clsSecurity.PermissionToPrint_WithMessage(
                        clsAutocode.getReportID(enum_ReportName.RG_CustomerMasterSummary_SelesRepWise)))
                    {
                        sReport_ID = clsAutocode.getReportID(enum_ReportName.RG_CustomerMasterSummary_SelesRepWise);
                        clsHelpMethods_Local.GetReportPath(sReport_ID, ref sReportTitle_Main, ref sReportTitle_Sub,
                            ref sRptPath);
                    }
                }
                #endregion

                #region Customer Master Summary (Route-wise)
                if (rdoRouterWise.Checked)
                {
                    if (clsSecurity.PermissionToPrint_WithMessage(
                        clsAutocode.getReportID(enum_ReportName.RG_CustomerMasterSummary_RouterWise)))
                    {
                        sReport_ID = clsAutocode.getReportID(enum_ReportName.RG_CustomerMasterSummary_RouterWise);
                        clsHelpMethods_Local.GetReportPath(sReport_ID, ref sReportTitle_Main, ref sReportTitle_Sub,
                            ref sRptPath);
                    }
                }
                #endregion

                #region Customer Master Summary (Town-wise)
                if (rdoTownWise.Checked)
                {
                    if (clsSecurity.PermissionToPrint_WithMessage(
                        clsAutocode.getReportID(enum_ReportName.RG_CustomerMasterSummary_TownWise)))
                    {
                        sReport_ID = clsAutocode.getReportID(enum_ReportName.RG_CustomerMasterSummary_TownWise);
                        clsHelpMethods_Local.GetReportPath(sReport_ID, ref sReportTitle_Main, ref sReportTitle_Sub,
                            ref sRptPath);
                    }
                }
                #endregion

                #region Fill The Data Set and Show Reports
                if (sRptPath != null && sRptPath.Trim() != "")
                {
                    Cursor = Cursors.WaitCursor;

                    dtsMaster.Clear();
                    dtsMaster.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", "", clsSecurity.UserNameLoged, sFilter);

                    string CustomerID = bCustomerSelected ? txtCustomer.Tag.ToString() : "";
                    string CustomerClassId = bClassName ? txtClassName.Tag.ToString() : "";
                    string CustomerTypeID = bTypeName ? txtTypeName.Tag.ToString() : "";
                    string CustomerCatretoryID = bCategory ? txtCategory.Tag.ToString() : "";
                    string SalesmanID = bSelesRepSelected ? txtSalesRep.Tag.ToString() : "";
                    string Town_ID = bTownSelected ? txtTown.Tag.ToString() : "";
                    int RouteID = bRouteSelected ? int.Parse(txtRoute.Tag.ToString()) : -1;
                    int IsBlackListed = chkBlackListed.Checked ? 1 : 0;


                    string sQuary = "exec [sp_GetRpt_CustomerMaster] '" + CustomerID + "', '" + CustomerClassId + "', '" + CustomerTypeID + "', '" + CustomerCatretoryID + "', '" + SalesmanID + "', '" + Town_ID + "'," + RouteID + "," + IsBlackListed;

                    dtsMaster.dt_masCustomer.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);
                    dts_ReportExport glb_dts_ExportReport = new dts_ReportExport();
                    frm_ReportViewer_New CRViwer = new frm_ReportViewer_New();
                    CRViwer.print(sRptPath, dtsMaster, glb_dts_ExportReport.dt_rptParameter, sReport_ID);
                    Cursor = Cursors.Default;
                    dtsMaster.Clear();

                }
                #endregion
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            #region Customer Mailing Report
            if (rdoCustomerMailing.Checked)
            {
                dtsMaster.dt_masCustomer.Rows.Clear();
                foreach (tbl_genCustomerMaster oCustomers in tbl_genCustomerMaster.SelectAll().Where(p => p.IsBlacklisted == chkBlackListed.Checked && !p.IsDeleted))
                {
                    dtsMaster.dt_masCustomer.Rows.Add(oCustomers.Customer_ID, oCustomers.CustomerName, oCustomers.AddressRegister, oCustomers.SalesRep_ID, clsGenaralName.getName_SalesRep(oCustomers.SalesRep_ID), oCustomers.Town_ID, clsGenaralName.getName_Town(oCustomers.Town_ID));
                }
                printByDataTable("Customer Mail Report ");
            }
            #endregion

            #region Sales Rep Wise Customers
            if (rdoSalesRep2.Checked)
            {
                try
                {
                    string sReportTitle_Main = "", sReportTitle_Sub = "", sRptPath = "";
                    clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.RG_Customer_SelesRepWise), ref sReportTitle_Main, ref sReportTitle_Sub, ref sRptPath);
                    if (sRptPath != null)
                    {
                        dts_Master glb_dts_Master = new dts_Master();
                        glb_dts_Master.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "Salesman wise customer list", "", "", clsSecurity.UserNameLoged, "");
                        dts_ReportExport glb_dts_ExportReport = new dts_ReportExport();

                        string sQuary = "exec [sp_RPT_RepWiceCustomer] '" + clsSecurity.BranchID + "' , " + chkBlackListed.Checked + "";

                        glb_dts_Master.dt_masCustomer.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                        frm_ReportViewer_New CRViwer = new frm_ReportViewer_New();
                        CRViwer.print("\\reports\\MAS\\Standard\\rpt_SalesRepwiceCustomer.rpt", glb_dts_Master, glb_dts_ExportReport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.RG_Customer_SelesRepWise));
                    }
                }
                catch (Exception ex)
                {
                    SEACCException.Show(ex);
                }
            }
            #endregion

            #region Customer Profile Report
            if (rdoCustomerProfile.Checked)
            {
                dts_Master glb_dts_Master = new dts_Master();
                glb_dts_Master.Clear();
                try
                {
                    string sReportTitle_Main = "", sReportTitle_Sub = "", sRptPath = "";
                    clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.RG_CustomerProfile_CustomerWise), ref sReportTitle_Main, ref sReportTitle_Sub, ref sRptPath);
                    if (sRptPath != null)
                    {
                        List<tbl_genCustomerMaster> oCustomerList = null;
                        if (bCustomerSelected)
                            oCustomerList = tbl_genCustomerMaster.SelectAll().Where(p => p.Customer_ID == txtCustomer.Tag.ToString() && p.IsDeleted != true).ToList();
                        else
                            oCustomerList = tbl_genCustomerMaster.SelectAll().Where(p => p.IsDeleted != true).ToList();

                        glb_dts_Master.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "Customer Profile", "", "", clsSecurity.UserNameLoged, "");
                        dts_ReportExport glb_dts_ExportReport = new dts_ReportExport();

                        foreach (tbl_genCustomerMaster oCustomer in oCustomerList.Where(r => r.IsBlacklisted == chkBlackListed.Checked))
                        {
                            glb_dts_Master.dt_masCustomerProfile.Adddt_masCustomerProfileRow(oCustomer.Customer_ID, oCustomer.CustomerCode, oCustomer.Title, oCustomer.CustomerName,
                                clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID), clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID), clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID), "",
                                oCustomer.AddressRegister, oCustomer.AddressDelivery, oCustomer.Telephone, oCustomer.Mobile, oCustomer.Fax, oCustomer.Url, oCustomer.Email, oCustomer.DateOfBirth, oCustomer.NicNo, oCustomer.BusinessRegistraionNo,
                                oCustomer.NbtRegistrationNo, oCustomer.VatRegistrationNo, oCustomer.SvatRegistrationNo, clsGenaralName.getName_Country(oCustomer.Country_ID), clsGenaralName.getName_Province(oCustomer.Province_ID), clsGenaralName.getName_District(oCustomer.District_ID),
                                clsGenaralName.getName_City(oCustomer.City_ID), clsGenaralName.getName_Town(oCustomer.Town_ID), clsGenaralName.getName_Area(oCustomer.Area_ID), "",
                                clsGenaralName.getName_SalesManager(oCustomer.SalesManager_ID), clsGenaralName.getName_AreaManager(oCustomer.AreaManager_ID), clsGenaralName.getName_SalesRep(oCustomer.SalesRep_ID), clsGenaralName.getName_SalesExecutive(oCustomer.SalesExecutive_ID),
                                oCustomer.ItemPriceMode.ToString(), oCustomer.ItemPriceCategory, oCustomer.IsCashCustomer, oCustomer.IsDeleted, oCustomer.IsBlacklisted, oCustomer.IsLocked, oCustomer.IsCustomerPricingEnable, oCustomer.IsCustomerWiseItemCode, oCustomer.DateCreate, oCustomer.CreateUser_ID);

                            tbl_genCustomerFinance oFin = tbl_genCustomerFinance.Select(oCustomer.Customer_ID);
                            if (oFin != null)
                            {
                                glb_dts_Master.dt_masCustomerFinance.Adddt_masCustomerFinanceRow(oFin.Customer_ID, oFin.DepositAmount, clsGenaralName.getName_Currency(oCustomer.Currency_ID), oFin.CreditLimit, oFin.CreditPeriod, oFin.SalesDues,
                                    oFin.CreditBalance, oFin.CommissionCreditPeriod, oFin.TotalSales, oFin.LoyaltyAmount, oFin.LoyalityCardNo, oFin.LoyalityStartDate, oFin.OutstandingAmount, oFin.ChequeInHandAmount);
                            }

                            foreach (tbl_genCustomerMaster_Branches oBranch in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oCustomer.Customer_ID))
                            {
                                glb_dts_Master.dt_masCustomerBranch.Adddt_masCustomerBranchRow(oBranch.Customer_ID, oBranch.BranchName, oBranch.Telephone, oBranch.Fax, oBranch.Address, oBranch.Email, oBranch.IsBillltoHeadOffice, oBranch.Route_ID, clsGenaralName.get_RouteName(oBranch.Route_ID));
                            }

                            foreach (tbl_genCustomerAddressBook oAdd in tbl_genCustomerAddressBook.SelectAllByCustomer_ID(oCustomer.Customer_ID))
                            {
                                glb_dts_Master.dt_masCustomerAddressBook.Adddt_masCustomerAddressBookRow(oAdd.Line_No, oAdd.Customer_ID, oAdd.ContactName,
                                    oAdd.Designation, oAdd.Telephone, oAdd.Mobile, oAdd.Fax, oAdd.Email);
                            }
                        }

                        frm_ReportViewer_New CRViwer = new frm_ReportViewer_New();
                        CRViwer.print("\\reports\\MAS\\NotePrinting\\rpt_masCustomerMaster_New.rpt", glb_dts_Master, glb_dts_ExportReport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.RG_CustomerProfile_CustomerWise));
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            #endregion
        }
     

        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearField();
        }
        #endregion

        #region Print

        private void printByDataTable(string sReportTitle)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string sHeaderTitle = sReportTitle;//s_Path = "",
                Reports.MAS.Standard.rptMailingLablesByName RD = new Reports.MAS.Standard.rptMailingLablesByName();
                RD.SetDataSource(dtsMaster);
                frm_ReportViewer viewer = new frm_ReportViewer();


                RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                RD.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                viewer.crystalReportViewer1.ReportSource = RD;
                // viewer.crystalReportViewer1.SelectionFormula = sFormula;
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

        #region ClearField
        private void clearField()
        {
            txtCustomer.Tag = null;            
            txtCustomer.Tag = null;
            txtSalesRep.Tag = null;
            txtRoute.Tag = null;
            txtTown.Tag = null;
            txtClassName.Tag = null;
            txtTypeName.Tag = null;
            txtCategory.Tag = null;

            txtCustomer.Text = "<All Customers>";
            txtSalesRep.Text = "<All SalesReps>";
            txtRoute.Text = "<All Routes>";
            txtTown.Text = "<All Towns>";
            txtClassName.Text = "<All Class >";
            txtTypeName.Text = "<All Type >";
            txtCategory.Text = "<All Category >";

            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, false);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomer, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, false);
            clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtTown, false);
            clsCommon.SetEnableDisable_NormalLabel(lblTown, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRoute, false);
            clsCommon.SetEnableDisable_NormalLabel(lblRoute, false);

            chkBlackListed.Checked = false;
            //rdoCustomerMaster.Checked = false;
            //rdoSalesRep.Checked = false;
            //rdoTownWise.Checked = false;
            //rdoRouterWise.Checked = false;
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
        private void Search_SalesRepID()
        {
            try
            {
                clsSearch.Search_MasterSalesRep(ref txtSalesRep);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void Search_CustomerClassID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_CustomerClass();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtClassName.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtClassName.Tag = frmSearchMaster.s_SearchID;
        }

        private void Search_CustomerTypeID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_CustomerType();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtTypeName.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtTypeName.Tag = frmSearchMaster.s_SearchID;
        }
        private void Search_CustomerCategoryID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_CustomerCategory();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtCategory.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtCategory.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Double Click Event
        private void txtRoute_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterRoute(ref txtRoute);
        }

        private void txtSalesRep_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesRepID();
        }

        private void txtTown_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterTown(ref txtTown);
        }
        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
        }

        private void txtClassName_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerClassID();
        }

        private void txtTypeName_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerTypeID();
        }



        private void txtCategory_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerCategoryID();
        }
        #endregion        

        #region CheckChanged Event
        private void rdoCustomerMaster_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }

        private void rdoCreditLimit_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }

        private void rdoSalesRep_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }

        private void rdoSalesRep2_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }

        private void rdoRouterWise_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }

        private void rdoTownWise_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoCustomerProfile_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        #endregion

        #region Set Enable/Disable Controls
        private void setEnableDisableConctrol()
        {
            if (rdoCustomerMaster.Checked )
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, false);
                clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtTown, false);
                clsCommon.SetEnableDisable_NormalLabel(lblTown, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRoute, true);
                clsCommon.SetEnableDisable_NormalLabel(lblRoute, true);
            }
           else if ( rdoCreditLimit.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, false);
                clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtTown, false);
                clsCommon.SetEnableDisable_NormalLabel(lblTown, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRoute, true);
                clsCommon.SetEnableDisable_NormalLabel(lblRoute, true);
            }
            else if (rdoSalesRep.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, false);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtTown, false);
                clsCommon.SetEnableDisable_NormalLabel(lblTown, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRoute, false);
                clsCommon.SetEnableDisable_NormalLabel(lblRoute, false);
            }
            else if (rdoSalesRep2.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, false);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, false);
                clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtTown, false);
                clsCommon.SetEnableDisable_NormalLabel(lblTown, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRoute, false);
                clsCommon.SetEnableDisable_NormalLabel(lblRoute, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtClassName, false);
                clsCommon.SetEnableDisable_NormalLabel(label4, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtTypeName, false);
                clsCommon.SetEnableDisable_NormalLabel(label2, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCategory, false);
                clsCommon.SetEnableDisable_NormalLabel(label1, false);
            }
            if (rdoRouterWise.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, false);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, false);
                clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtTown, false);
                clsCommon.SetEnableDisable_NormalLabel(lblTown, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRoute, true);
                clsCommon.SetEnableDisable_NormalLabel(lblRoute, true);
            }
            if (rdoTownWise.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, false);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, false);
                clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtTown, true);
                clsCommon.SetEnableDisable_NormalLabel(lblTown, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRoute, false);
                clsCommon.SetEnableDisable_NormalLabel(lblRoute, false);
            }
            if (rdoCustomerMailing.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, false);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, false);
                clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtTown, false);
                clsCommon.SetEnableDisable_NormalLabel(lblTown, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRoute, false);
                clsCommon.SetEnableDisable_NormalLabel(lblRoute, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtClassName, false);
                clsCommon.SetEnableDisable_NormalLabel(label4, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtTypeName, false);
                clsCommon.SetEnableDisable_NormalLabel(label2, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCategory, false);
                clsCommon.SetEnableDisable_NormalLabel(label1, false);
            }

            if (rdoCustomerProfile.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
            }

        }
        #endregion    

    }
}