using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Digiteq_Logic;
using Digiteq.DataSets;
using DataTire;

namespace Digiteq
{
    public partial class frm_rpt_MasterReport : MettroForm
    {
        #region Variables
        //form manage
           public int iFormID;

        //for security handle
        public bool bNoAccess;
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        dts_Master glb_dts_Master = new dts_Master();// glb_dts_Master  is DataSet of our Created
        #endregion

        public frm_rpt_MasterReport()
        {           
            iFormID = clsSecurity.getFormID(FormName.ReportMaster);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_rpt_MasterReport_Load(object sender, EventArgs e)
        {
            //format Form
           // clsFormatter.setFormatForm(this, "Master Reports", 2);
        }

        #region Btn Print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (rdoItemMaster.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Item_Master)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_masItemSummery.rpt", "Item Master [Summary] ", "{vw_rpt_masItemSummery.item_ID} <> 'default'");
                }
            }

            else if (rdoCustomerMaster.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Customer_Master)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_masCustomerSummery.rpt", "Customer Master [Summary] ", "{vw_rpt_masCustomerSummery.customer_ID} <> 'default'"); //TODO there is error with formula
                }
            }
            //else if (rdoSupplierMaster.Checked)
            //{
            //    if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Supplier_Master)))
            //    {
            //        print("\\Reports\\MAS\\Register\\rpt_masSupplierSummery.rpt", "Supplier Master [Summary] ", "{vw_rpt_masSupplierSummery.supplier_ID} <> 'default'");
            //    }
            //}
            else if (rdoItemCategory.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Item_Category)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refItemCategory.rpt", "Item Category [Summary] ", "{tbl_zItemCategory.itemCategory_ID} <> 'default'");
                }
            }
            else if (rdoItemClass.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Item_Class)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refItemClass.rpt", "Item Class [Summary] ", "{tbl_zItemClass.itemClass_ID} <> 'default'");
                }
            }
            else if (rdoItemType.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Item_Type)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refItemType.rpt", "Item Type [Summary] ", "{tbl_zItemType.itemClass_ID} <> 'default'");
                }
            }
            else if (rdoCustomerClass.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Customer_Class)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refCustomerClass.rpt", "Customer Class [Summary] ", "{tbl_zCustomerClass.customerClass_ID} <> 'default'");
                }
            }
            else if (rdoCustomerType.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Customer_Type)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refCustomerType.rpt", "Customer Type [Summary] ", " {tbl_zCustomerType.customerType_ID} <> 'default'");
                }
            }
            else if (rdoCustomerCategory.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Customer_Category)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refCustomerCategory.rpt", "Customer Categoty [Summary] ", " {tbl_zCustomerCategory.customerCategory_ID} <> 'default'");
                }
            }
            else if (rdoSupplierClass.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Supplier_Class)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refSupplierClass.rpt", "Supplier Class [Summary] ", " {tbl_zSupplierClass.supplierClass_ID} <> 'default'");
                }
            }
            else if (rdoSupplierType.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Supplier_Type)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refSupplierType.rpt", "Supplier Type [Summary] ", " {tbl_zSupplierType.supplierType_ID} <> 'default'");
                }
            }
            else if (rdoSupplierCategory.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Supplier_Category)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refSupplierCategory.rpt", "Supplier category [Summary] ", " {tbl_zSupplierCategory.supplierCategory_ID} <> 'default'");
                }
            }
            else if (rdoCountry.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_County)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refCountry.rpt", "Country [Summary] ", " {tbl_zCountry.country_ID} <> 'default'");
                }
            }
            else if (rdoProvince.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Province)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refProvince.rpt", "Province [Summary] ", " {tbl_zProvince.province_ID} <> 'default'");
                }
            }
            else if (rdoDistrict.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_District)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refDistrict.rpt", "District [Summary] ", " {tbl_zDistrict.district_ID} <> 'default'");
                }
            }
            else if (rdoCity.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_City)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refCity.rpt", "City [Summary] ", " {tbl_zCity.city_ID} <> 'default'");
                }
            }
            else if (rdoTown.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Town)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refTown.rpt", "Town [Summary] ", " {tbl_zTown.town_ID} <> 'default'");
                }
            }
            else if (rdoArea.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Area)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refArea.rpt", "Area [Summary] ", " {tbl_zArea.area_ID} <> 'default'");
                }
            }
            else if (rdoRoot.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Root)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refRoute.rpt", "Route [Summary] ", " {tbl_genRouteMaster.route_ID} <> 'default'");
                }
            }
            else if (rdoBank.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Bank)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refBank.rpt", "Bank [Summary] ", " {tbl_zBank.bank_ID} <> 'default'");
                }
            }
            else if (rdoBranch.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Branch)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refBranch.rpt", "Branch [Summary] ", " {tbl_zBankBranches.branch_ID} <> 'default'");
                }
            }
            else if (rdoSalesManager.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Sales_Manger)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refSalseManager.rpt", "Sales Manager [Summary] ", "{tbl_ZEmpSalesManager.salesManager_ID} <> 'default'");
                }
            }
            else if (rdoAreaManager.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Area_Manager)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refAreaManager.rpt", "Area Manager [Summary] ", "{tbl_ZEmpAreaManager.areaManager_ID} <> 'default'");
                }
            }
            else if (rdoSalesRep.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Sales_Rep)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refSalseRep.rpt", "Sales Rep [Summary] ", " {tbl_ZEmpSalesRep.selesRep_ID} <> 'default'");
                }
            }
            else if (rdoSalesExecutive.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Sales_Executive)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refSalseExecutive.rpt", " Sales Executive [Summary] ", "{tbl_ZEmpSalesExecutive.salesExecutive_ID} <> 'default'");
                }
            }
            else if (rdoBrand.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Brand)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refBrand.rpt", "Brand [Summary] ", " {tbl_zBrand.brand_ID} <> 'default'");
                }
            }
            else if (rdoCheckStates.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Cheque_Status)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refChequeStatus.rpt", "Check States [Summary] ", " {tbl_zChequeStatus.chequeStatus_ID} <> 'default'");
                }
            }
            else if (rdoUom.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Uom)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refUom.rpt", "Uom [Summary] ", " {tbl_zUom.uom_ID} <> 'default'");
                }
            }
            else if (rdoUomCategory.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Uom_Category)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refUomCategory.rpt", "Uom Category [Summary] ", " {tbl_zUomCategory.uomCategory_ID} <> 'default'");
                }
            }
            else if (rdoDriver.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Driver)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refDriver.rpt", "Drive [Summary] ", " {tbl_zDriver.driver_ID} <> 'default'");
                }
            }
            else if (rdoCurrency.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Currency)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refCurrency.rpt", "Currency [Summary] ", " {tbl_zCurrency.currency_ID} <> 'default'");
                }
            }
            else if (rdoAssistant.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Assistant)))
                {
                    //print("\\Reports\\MAS\\Register\\rpt_refAssistant.rpt", "Assistant [Summary] ", " {tbl_zAssistant.assistant_ID} <> 'default'");
                    print("\\Reports\\MAS\\Register\\rpt_refAssistant.rpt", "Assistant [Summary] ", " {tbl_zEmpAssistant.assistant_ID} <> 'default'");
                }
            }
            else if (rdoTax.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Tax)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refTax.rpt", "Tax [Summary] ", "{tbl_zTax.tax_ID} <> 'default'");
                }
            }
            else if (rdovehicles.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Vehicles)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refVehicles.rpt", "Vehicles [Summary] ", "{tbl_zVehicle.vehicle_ID} <> 'default'");
                }
            }
            else if (rdoCheckStates.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Cheque_Status)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refChequeStatus.rpt", "Check States [Summary] ", " {tbl_zChequeStatus.chequeStatus_ID} <> 'default'");
                }
            }
            else if (rdoChequeType.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Cheque_Type)))
                {
                    print("\\Reports\\MAS\\Register\\rpt_refChequeType.rpt", "Cheque Type [Summary] ", "{tbl_zChequeType.chequeType_ID} <> 'default'");
                }
            }
            else if (rdoEmployee.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Employee)))
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        glb_dts_Master.dt_masEmployeeList.Rows.Clear();
                        //glb_dts_Master is our object create using dts_Master DataSet
                        //dt_masEmployeeList is dataTable inside a dts_Master DataSet

                        //Data Fill to DataSet
                        foreach (tbl_genEmployeeMaster oEmployee in tbl_genEmployeeMaster.SelectAll().Where(p => !p.IsDelete && p.Employee_ID != "default"))
                        {
                            string sEmployeeType = oEmployee.IsSelesRep ? "Salesman" :
                                oEmployee.IsOperator ? "Operator" :
                                oEmployee.IsAreaManager ? "AreaManager" :
                                oEmployee.IsDriver ? "Driver" :
                                oEmployee.IsAssistant ? "Assistant" :
                                oEmployee.IsSalesExecutive ? "SalesExecutive" : 
                                oEmployee.IsSalesManager ? "SalesManager" :  "";

                            glb_dts_Master.dt_masEmployeeList.Adddt_masEmployeeListRow(oEmployee.Employee_ID, oEmployee.EmployeeName, oEmployee.Email, oEmployee.Mobile, oEmployee.Designation, sEmployeeType); 
                        }

                        //print("\\Reports\\MAS\\Standard\\rpt_masEmployeeList.rpt", "Employee List", glb_dts_Master.dt_masEmployeeList, clsAutocode.getReportID(enum_ReportName.RG_Employee));
                        frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
                        ReportViewer.print("\\Reports\\MAS\\Standard\\rpt_masEmployeeList.rpt", glb_dts_Master, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.RG_Employee));
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID,ex);
                        SEACCException.Show(ex);
                    }
                    finally
                    {
                        glb_dts_Master.dt_masEmployeeList.Rows.Clear();
                        Cursor = Cursors.Default;
                    }
                }
            }

            else if (rdoSupplierMaster.Checked)
            {

                string sReportID = clsAutocode.getReportID(enum_ReportName.RG_Supplier_Master);

                string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                if (clsHelpMethods.GetReportPath(sReportID, ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        glb_dtsReportExport.Clear();
                        glb_dts_Master.dt_masSupplier.Rows.Clear();

                        foreach (tbl_genSupplierMaster oSupplier in tbl_genSupplierMaster.SelectAll().Where(p => !p.IsDeleted && p.Supplier_ID != "default"))
                        {
                            tbl_zSupplierClass oClass = tbl_zSupplierClass.Select(oSupplier.SupplierClass_ID);
                            tbl_zSupplierType oType = tbl_zSupplierType.Select(oSupplier.SupplierType_ID);
                            tbl_zSupplierCategory oCategory = tbl_zSupplierCategory.Select(oSupplier.SupplierCategory_ID);

                            if (oClass != null && oType != null && oCategory != null)
                            {
                                glb_dts_Master.dt_masSupplier.Adddt_masSupplierRow(oSupplier.Supplier_ID, oSupplier.SupplierName, oSupplier.AddressRegister, oClass.ClassName, oType.TypeName, oCategory.CategoryName, oSupplier.Telephone, oSupplier.Fax, oSupplier.VatRegistrationNo, oSupplier.NbtRegistrationNo, oSupplier.BusinessRegistraionNo, oSupplier.CreditPeriod.ToString(), decimal.Parse(oSupplier.CreditLimit.ToString()));
                            }
                        }
                        glb_dts_Master.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, "", clsSecurity.UserNameLoged, "");
                        
                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                        rpt.print(sReportPath, glb_dts_Master, glb_dtsReportExport.dt_rptParameter, sReportID);

                        //print("\\Reports\\MAS\\Register\\rpt_masSupplierSummery_Dataset.rpt", "Supplier Master [Summary]", glb_dts_Master.dt_masSupplier, clsAutocode.getReportID(enum_ReportName.RG_Supplier_Master));
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID,ex);
                        SEACCException.Show(ex);
                    }
                    finally
                    {
                        glb_dts_Master.dt_masSupplier.Rows.Clear();
                        Cursor = Cursors.Default;
                    }
                }
            }
        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e, string myformula)
        {

        } 
        #endregion

        #region Print Method
        #region Print Method Using Views
        private void print(string path, string sReportTitle, string sFormula)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Master Data Reports [Summary]";
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
        
        #region Print Method Using DataTable
        private void print(string path, string sReportTitle, DataTable objDataTable, string sReportNo)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sFilter = "";//sHeaderTitle = "Standed Reports", sReportFilter = "",
                ReportDocument objRpt = new ReportDocument();

                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(objDataTable); //(glbDtsBills);

                objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                //objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                objRpt.DataDefinition.FormulaFields["sReportNo"].Text = clsCommon.fncsetstring(sReportNo);
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
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #endregion



    }
}
