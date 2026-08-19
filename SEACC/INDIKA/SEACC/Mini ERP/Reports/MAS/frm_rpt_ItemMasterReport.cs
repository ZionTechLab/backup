using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DataTire;
using Zion.ERP.Reports.DataSets;
using Digiteq.Reports.ADM;



namespace Digiteq
{
    public partial class frm_rpt_ItemMasterReport : MettroForm
    {
        


         //objects from datasets        
        dts_Master glb_dtsMasItem = new dts_Master();
         


        #region Form Load
        public frm_rpt_ItemMasterReport()
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
            clsFormatter.setFormatForm(this, "Item Master Report", 2, iFormID);

            clearField();
            rdoDepartment.Checked = false;
            rdoStore.Checked = true;
        } 
        #endregion


        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearField();
           // bool bUserSelected = false, bGroupSelected = false, bModuleSelected = false, bReprtCattagorySelected = false, bDocumentSelected = false;
           // string sFormula = "", sFilter = "";

            //if (txtItemName.Tag != null && txtItemName.Tag.ToString().Trim().Length > 0)
            //    bGroupSelected = true;
            //if (txtModuleName.Tag != null && txtModuleName.Tag.ToString().Trim().Length > 0)
            //    bModuleSelected = true;
            //if (txtReprtCatagory.Tag != null && txtReprtCatagory.Tag.ToString().Trim().Length > 0)
            //    bReprtCattagorySelected = true;
            //if (txtUserID.Tag != null && txtUserID.Tag.ToString().Trim().Length > 0)
            //    bUserSelected = true;
            //if (txtDocument.TextLength > 0)
            //    bDocumentSelected = true;
        }


        #endregion

        #region Print Btn
        private void btnPrint_Click(object sender, EventArgs e)
        { 
            if (rdoStore.Checked)
            {
                if (!clsSecurity.PermissionToPrint_WithMessage("90101"))
                    return;

                string sFormula = "{vw_rpt_masStoreStock.storeName} <> 'default'";

                if (txtStore.Tag != null)
                    sFormula += "and {vw_rpt_masStoreStock.storeName} = '" + txtStore.Text.Trim() + "'";
                if (txtItemType.Tag != null)
                    sFormula += "and {vw_rpt_masStoreStock.typeName} = '" + txtItemType.Text.Trim() + "'";
                if (txtItemCategory.Tag != null)
                    sFormula += "and {vw_rpt_masStoreStock.categoryName} = '" + txtItemCategory.Text.Trim() + "'";
                if (txtItemName.Tag != null)
                    sFormula += "and {vw_rpt_masStoreStock.itemName} = '" + txtItemName.Text.Trim() + "'";
                if (txtJobCode.Tag != null)
                    sFormula += "and {vw_rpt_masStoreStock.job_ID} = '" + txtJobCode.Tag.ToString().Trim() + "'";

                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                    print("\\reports\\SCS\\rpt_scs_StockReport_Store_WSC.rpt", "Floor Stock Balance", sFormula);
                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                    print("\\reports\\SCS\\rpt_scs_StockReport_Store_APL.rpt", "Floor Stock Balance", sFormula);
                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ceilingAndWallPanal.ToString())
                    print(@"\reports\SCS\rpt_scs_StockReport_Store_CWP_A4.rpt", "Floor Stock Balance", sFormula);
                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                    print(@"\reports\SCS\rpt_scs_StockReport_Store_AKT_A4.rpt", "Floor Stock Balance", sFormula);
                else
                    print("\\reports\\SCS\\rpt_scs_StockReport_Store_WD_A4.rpt", "Floor Stock Balance", sFormula);

            }
        
            if (rdoSection.Checked)
            {
                if (!clsSecurity.PermissionToPrint_WithMessage("90102"))
                    return;

                string sFormula = "{vw_rpt_masSectionStock.sectionName} <> 'default'";

                if (txtSection.Tag != null)
                    sFormula += "and {vw_rpt_masSectionStock.sectionName} = '" + txtSection.Text.Trim() + "'";
                if (txtItemType.Tag != null)
                    sFormula += "and {vw_rpt_masSectionStock.typeName} = '" + txtItemType.Text.Trim() + "'";
                if (txtItemCategory.Tag != null)
                    sFormula += "and {vw_rpt_masSectionStock.categoryName} = '" + txtItemCategory.Text.Trim() + "'";
                if (txtItemName.Tag != null)
                    sFormula += "and {vw_rpt_masSectionStock.itemName} = '" + txtItemName.Text.Trim() + "'";
                if (txtJobCode.Tag != null)
                    sFormula += "and {vw_rpt_masSectionStock.job_ID} = '" + txtJobCode.Tag.ToString().Trim() + "'";

                print("\\reports\\rpt_masSectionStock.rpt", "Floor Stock Balance", sFormula);
            }

            if (rboItemMastercostDetail.Checked)
            {
                if (!clsSecurity.PermissionToPrint_WithMessage("90104"))
                    return;

                try
                {
                    Cursor = Cursors.WaitCursor;
                    glb_dtsMasItem.dt_masItem.Rows.Clear();

                    foreach (tbl_genItemMaster_Pricing oMasItem in tbl_genItemMaster_Pricing.SelectAll().Where(p => p.Item_ID != "default" && p.Item_ID.Length > 0 ))
                    {
                        tbl_genItemMaster detail = tbl_genItemMaster.Select(oMasItem.Item_ID);

                        if (detail != null)
                        {
                            glb_dtsMasItem.dt_masItem.Rows.Add(oMasItem.Item_ID, clsGenaralName.getName_Item(oMasItem.Item_ID), clsGenaralName.getName_ItemClass(detail.ItemClass_ID), clsGenaralName.getName_ItemType(detail.ItemType_ID),
                            clsGenaralName.getName_ItemCategory(detail.ItemCategory_ID),clsGenaralName.getName_ItemSubCategory(detail.Brand_ID), oMasItem.CostPrice1, oMasItem.SellingPrice1, detail.ReOrderQty, detail.ReReoverLevel);
                        }                        
                    }
                    print("\\Reports\\rpt_masRawMaterial.rpt", " Item Master Cost Details", glb_dtsMasItem);
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID,ex);
                    SEACCException.Show(ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                    glb_dtsMasItem.dt_masItem.Rows.Clear();
                }
            } 
         
  

            #region Item Master Report
            if (rdoItemMasterReport.Checked)
            {
                try
                {
                    if (!clsSecurity.PermissionToPrint_WithMessage("90105"))
                        return;

                    Cursor = Cursors.WaitCursor;
                    glb_dtsMasItem.dt_ItemMaster.Rows.Clear();


                    #region Generate Foreach Query 
                    List<tbl_genItemMaster> oItems;

                    oItems = tbl_genItemMaster.SelectAll().Where(p => !p.IsDeleted && p.Item_ID != "default" && p.Item_ID.Length > 0).ToList();

                    if (txtItemName.Tag != null)
                        oItems = oItems.Where(p => p.Item_ID == txtItemName.Tag.ToString()).ToList();

                    if (txtItemType.Tag != null)
                        oItems = oItems.Where(p => p.ItemType_ID == txtItemType.Tag.ToString()).ToList();

                    if (txtItemCategory.Tag != null)
                        oItems = oItems.Where(p => p.ItemCategory_ID == txtItemCategory.Tag.ToString()).ToList(); 
                    #endregion

                    foreach (tbl_genItemMaster oItem in oItems)
                    {
                        tbl_genItemMaster_Pricing oItemF = tbl_genItemMaster_Pricing.Select(oItem.Item_ID);
                        if (oItemF != null)
                        {
                            glb_dtsMasItem.dt_ItemMaster.Adddt_ItemMasterRow(oItem.Item_ID, clsGenaralName.getName_Item(oItem.Item_ID), clsGenaralName.getName_ItemClass(oItem.ItemClass_ID),
                                clsGenaralName.getName_ItemType(oItem.ItemType_ID), clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID), string.Empty, oItemF.SellingPrice6, oItemF.SellingPrice1,
                                oItemF.SellingPrice2, oItemF.SellingPrice3, oItemF.SellingPrice4, oItemF.SellingPrice5, oItem.ReReoverLevel, oItem.ReOrderQty);
                        }
                    }
                    print("\\Reports\\rpt_masItem.rpt", " Item Master Report", glb_dtsMasItem);
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID,ex);
                    SEACCException.Show(ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                    glb_dtsMasItem.dt_ItemMaster.Rows.Clear();
                }
            } 
            #endregion 
        }
        #endregion

        #region ClearField
        private void clearField()
        {
            txtDepartment.Text = "     <<ALL Department>>";
            txtSection.Text = "     <<ALL Section>>";
            txtStore.Text = "     <<ALL Store>>";
            txtItemType.Text = "     <<ALL Item Type>>";
            txtItemCategory.Text = "     <<ALL Item Category>>";
            txtItemName.Text = "     <<ALL Item Name>>";
            txtJobCode.Text = "     <<ALL Jobs>>";

            txtDepartment.Tag = null;
            txtSection.Tag = null;
            txtStore.Tag = null;
            txtItemType.Tag = null;
            txtItemCategory.Tag = null;
            txtItemName.Tag = null;
            txtJobCode.Tag = null;
            rdoStore.Checked = true;
            //chkJobBase.Checked = true;
        }
        #endregion

        #region Print Method
        private void print(string path, string sReportTitle, string sFormula)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Floor Stock Balance";
                ReportDocument RD = new ReportDocument();
       
                s_Path = Application.StartupPath.Replace("\\Mini ERP\\bin\\Debug", "\\ZION.ERP.Reports");
                s_Path += path;

                frm_ReportViewer viewer = new frm_ReportViewer();
                RD.Load(s_Path); Digiteq.Classes.ReportHelper.LogonServer(ref RD);
                //   clsSecurity.LogonServer(ref RD);
                RD.Refresh();

                RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                RD.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString() || clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                    RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);                

                if (chkJobBase.Checked)
                    RD.DataDefinition.FormulaFields["WithJobID"].Text = clsCommon.fncsetstring("yes");
                else
                    RD.DataDefinition.FormulaFields["WithJobID"].Text = clsCommon.fncsetstring("no");

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


         private void print(string path, string sReportTitle, DataSet ojbDataSet)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Standard Reports", sReportFilter = "";
                //   CrystalDecisions.CrystalReports.Engine.ReportDocument objRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                ReportDocument objRpt = new ReportDocument();


                s_Path = Application.StartupPath.Replace("\\Mini ERP\\bin\\Debug", "\\ZION.ERP.Reports");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(ojbDataSet); //(glbDtsBills);

                if (txtItemName.Tag != null)
                    sReportFilter += " Item Name: " + txtItemName.Text;

                if (txtItemType.Tag != null)
                    sReportFilter += " Item Type: " + txtItemType.Text;

                if (txtItemCategory.Tag != null)
                    sReportFilter += " Item Category: " + txtItemCategory.Text;


                objRpt.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("");
                objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                objRpt.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                if (rdoItemMasterReport.Checked)
                    objRpt.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sReportFilter);
                    objRpt.DataDefinition.FormulaFields["SellingPrice1"].Text = clsCommon.fncsetstring(clsConfig.sItemPrice1_Name);
                    objRpt.DataDefinition.FormulaFields["SellingPrice2"].Text = clsCommon.fncsetstring(clsConfig.sItemPrice2_Name);
                    objRpt.DataDefinition.FormulaFields["SellingPrice3"].Text = clsCommon.fncsetstring(clsConfig.sItemPrice3_Name);
                    objRpt.DataDefinition.FormulaFields["SellingPrice4"].Text = clsCommon.fncsetstring(clsConfig.sItemPrice4_Name);
                    objRpt.DataDefinition.FormulaFields["SellingPrice5"].Text = clsCommon.fncsetstring(clsConfig.sItemPrice5_Name);
                    objRpt.DataDefinition.FormulaFields["SellingPrice6"].Text = clsCommon.fncsetstring(clsConfig.sItemPrice6_Name);


                //if (bCustomerSelected)
                //    sReportFilter += " Customer Name : " + txtCustomer.Text.Trim();
                //if (bSelesRepSelected)
                //    sReportFilter += " Salesman Name : " + txtSalesRep.Text.Trim();
                // objRpt.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sReportFilter);

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

        
        #region KeyDown Events
        private void frm_rpt_ChequeManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterStore(ref txtStore, true);
            }
        }
        private void txtSection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterSection(ref txtSection);
            }
        }
        private void txtDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterDepartment(ref txtDepartment);
            }
        }
        private void txtItemType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterItemType(ref txtItemType);
            }
        }
        private void txtItemCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterItemCategory(ref txtItemCategory);
            }
        }
        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                //clsSearch.Search_ItemMaster(ref txtItemName);
                clsSearch.Search_ItemMaster(ref txtItemName, null, null, null, false);
            }
        }
        private void txtJobCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterProductionJob(ref txtJobCode);
        }
        #endregion
      
        #region Events DoublClick
        private void txtStoreStock_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterStore(ref txtStore, true);
        }
        private void txtDepartmentStock_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterDepartment(ref txtDepartment);
        }
        private void txtSectionStoke_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterSection(ref txtSection);
        }
        private void txtItemType_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterItemType(ref txtItemType);
        }
        private void txtItemCategory_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterItemCategory(ref txtItemCategory);
        }
        private void txtItemName_DoubleClick(object sender, EventArgs e)
        {
            //clsSearch.Search_ItemMaster(ref txtItemName);
            clsSearch.Search_ItemMaster(ref txtItemName, null, null, null, false);
        }
        private void txtJobCode_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterProductionJob(ref txtJobCode);
        }
        #endregion

        #region Events CheckedChanged
        private void rdoStoreStock_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoStore.Checked)
            {
                txtDepartment.Text = "     <<ALL Department>>";
                txtSection.Text = "     <<ALL Section>>";
                txtStore.Text = "     <<ALL Store>>";
                
                txtStore.Enabled = true;
                txtDepartment.Enabled = false;
                txtSection.Enabled = false;

                txtDepartment.Tag = null;
                txtSection.Tag = null;
             
            }
        }
        private void rdoDepartmentStock_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDepartment.Checked)
            {
                txtDepartment.Text = "     <<ALL Department>>";
                txtSection.Text = "     <<ALL Section>>";
                txtStore.Text = "     <<ALL Store>>";

                txtDepartment.Enabled = true;
                txtStore.Enabled = false;
                txtSection.Enabled = false;

                txtSection.Tag = null;
                txtStore.Tag = null;
            }
        }
        private void rdoSectionStock_CheckedChanged(object sender, EventArgs e)
        {
            txtDepartment.Text = "     <<ALL Department>>";
            txtSection.Text = "     <<ALL Section>>";
            txtStore.Text = "     <<ALL Store>>";

            txtDepartment.Enabled = false;
            txtStore.Enabled = false;
            txtSection.Enabled = true;

            txtDepartment.Tag = null;
            txtStore.Tag = null;
        }
        #endregion

        private void rdoItemMasterReport_CheckedChanged(object sender, EventArgs e)
        {
            txtItemName.Enabled = true;
            txtItemType.Enabled = true;
            txtItemCategory.Enabled = true;
            txtDepartment.Enabled = false;
            txtStore.Enabled = false;
            txtSection.Enabled = false;

            txtItemName.Tag = null;
            txtItemType.Tag = null;
            txtItemCategory.Tag = null;
            txtDepartment.Tag = null;
            txtStore.Tag = null;
            txtSection.Tag = null;

            txtItemName.Text = "     <<ALL Items>>";
            txtItemType.Text = "     <<ALL Item Types>>";
            txtItemCategory.Text = "     <<ALL Item Categories>>";
        }

        private void rboItemMastercostDetail_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void x1_Paint(object sender, PaintEventArgs e)
        {

        }


    } 
      
}
