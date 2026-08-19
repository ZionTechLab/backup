using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Zion.ERP.Reports.DataSets;
using DataTire;

namespace Digiteq
{
    public partial class frm_rpt_FlowStock : Form
    {
        
        //form manage
        public int iFormID;

        //for security handle
        public bool bNoAccess;

        dts_Stock glb_dtsStock = new dts_Stock();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        bool bItemType_Selected = false, bItemCategory_Selected = false, bItemName_Selected = false, bStore_Selected = false;
     

        #region Form Load
        public frm_rpt_FlowStock()
        {
            iFormID = clsSecurity.getFormID(FormName.ReportFlowStock);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }

        private void frmReportChequeDeposit_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "Floor Stock Balance", 2, iFormID);

            clearField();

            //rdoDepartment.Checked = false;
            //rdoStore.Checked = true;
        }
        #endregion

        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            setEnableDisableConctrol();

            //add clear method 2017-09-09
            //clearField();
        }
        #endregion

        #region Print Btn
        private void btnPrint_Click(object sender, EventArgs e)
        {
            bItemType_Selected = false; bItemCategory_Selected = false; bItemName_Selected = false; bStore_Selected = false;
            string sFilter = "", sFormula = "";
            string sDateRange = "From : " + clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()) + "  To : " + dtpTo.Value.ToString("dd MMM yyyy");
            if (txtItemCategory.Tag != null && txtItemCategory.Tag.ToString().Trim().Length > 0)
                bItemCategory_Selected = true;
            if (txtItemType.Tag != null && txtItemType.Tag.ToString().Trim().Length > 0)
                bItemType_Selected = true;
            if (txtItemName.Tag != null && txtItemName.Tag.ToString().Trim().Length > 0)
                bItemName_Selected = true;
            if (txtStore.Tag != null && txtStore.Tag.ToString().Trim().Length > 0)
                bStore_Selected = true;
            if (!chkBackdate.Checked)
            {
                #region OLD method
                #region Store
                if (rdoStore.Checked)
                {
                    if (true)
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;

                            glb_dtsStock.dt_scsFloorStock_Store.Rows.Clear();
                            List<tbl_genStore_Stock> oDetails;

                            if (txtStore.Tag != null && txtStore.Tag.ToString().Trim().Length > 0 && txtStore.Tag.ToString().Trim() != "default")
                                oDetails = tbl_genStore_Stock.SelectAllByStore_ID(txtStore.Tag.ToString().Trim()).Where(p => p.Weight > 0 || p.Qty > 0).ToList();
                            else
                                oDetails = tbl_genStore_Stock.SelectAll().Where(p => p.Weight > 0 || p.Qty > 0).ToList();

                            foreach (tbl_genStore_Stock oDetail in oDetails)
                            {
                                #region Stock Note Type
                                if (txtStockNoteType.Tag != null)
                                {
                                    //  string sStoreNoteTypeID = "";
                                    //foreach (tbl_scsExternalGoodReceivedNote_Detail_Gem oGrnDetail in tbl_scsExternalGoodReceivedNote_Detail_Gem.SelectAllByItem_ID(oDetail.Item_ID).Where(p => p.ItemSerialNo == oDetail.ItemSerialNo))// && p.ItemSerialNo2 == oDetail.ItemSerialNo2 && p.ItemSubCategory_ID == oDetail.ItemSubCategory_ID && p.ItemSubCategory2_ID == oDetail.ItemSubCategory2_ID))
                                    //{
                                    //    tbl_scsExternalGoodReceivedNote oGRN = tbl_scsExternalGoodReceivedNote.Select(oGrnDetail.ExternalGoodReceivedNote_ID);
                                    //    if (oGRN != null && oGRN.ExternalGoodReceivedNote_ID != "default" && !oGRN.IsDeleted)
                                    //    {
                                    //        sStoreNoteTypeID = oGRN.StockNoteType_ID;
                                    //        break;
                                    //    }
                                    //}
                                    //if (txtStockNoteType.Tag.ToString().Trim() != sStoreNoteTypeID)
                                    //    continue;
                                }
                                #endregion

                                //foreach (tbl_accGLPosting_Detail GLpostingDetail in tbl_accGLPosting_Detail.SelectAllByGl_ID(oGLMaster.Gl_ID).Where(p => dtpFrom.Value.Date > p.TransactionDate.Date && p.TransactionDate.Date >= dtFinancialYearStartDate.Date))
                                bool bItemTypeOK = true, bItemCategoryOK = true, bItemNameOK = true;
                                string sItemRefNo = "", sMatelInfo = "", sGemInfo = "";
                                tbl_genItemMaster oItem = tbl_genItemMaster.Select(oDetail.Item_ID);
                                tbl_genItemMaster_Pricing oItemF = tbl_genItemMaster_Pricing.Select(oDetail.Item_ID);
                                if (oItem != null && oItem.Item_ID != "default" && oItemF != null)
                                {
                                    string sUOMCode = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Uom(oItem.Uom_ID));
                                    if (bItemCategory_Selected)
                                        bItemCategoryOK = txtItemCategory.Tag.ToString().Trim() == oItem.ItemCategory_ID ? true : false;
                                    if (bItemType_Selected)
                                        bItemTypeOK = txtItemType.Tag.ToString().Trim() == oItem.ItemType_ID ? true : false;
                                    if (bItemName_Selected)
                                        bItemNameOK = txtItemName.Tag.ToString().Trim() == oItem.Item_ID ? true : false;


                                    //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.gem.ToString())
                                    //{
                                    //    tbl_zItemSerialNo oSerial = tbl_zItemSerialNo.Select(oDetail.ItemSerialNo);
                                    //    if (oSerial != null && oSerial.ItemSerialNo != "default" && oSerial.ItemSerialNo != "0")
                                    //    {
                                    //        sItemRefNo = oSerial.RefNo;
                                    //        sMatelInfo = oSerial.MetalDetail;
                                    //        sGemInfo = oSerial.GemDetail;
                                    //    }
                                    //    else
                                    //    {
                                    //        tbl_genItemMaster_Gem oGem = tbl_genItemMaster_Gem.Select(oDetail.Item_ID);
                                    //        if (oGem != null && oGem.Item_ID != "default")
                                    //        {
                                    //            sItemRefNo = oGem.RefNo;
                                    //            sMatelInfo = oGem.MetalDetail;
                                    //            sGemInfo = oGem.GemDetail;
                                    //        }
                                    //    }
                                    //}

                                    if (bItemTypeOK && bItemCategoryOK && bItemNameOK)
                                    {
                                        glb_dtsStock.dt_scsFloorStock_Store.Adddt_scsFloorStock_StoreRow(clsGenaralName.getName_Store(oDetail.Store_ID), oDetail.Item_ID, sItemRefNo, oItem.ItemName,
                                            clsGenaralName.getName_ItemClass(oItem.ItemClass_ID), clsGenaralName.getName_ItemType(oItem.ItemType_ID),
                                            clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID), sMatelInfo, sGemInfo, sUOMCode,
                                            oDetail.Weight, oDetail.Qty, oItemF.WeightedAverageCostPrice, oItemF.WeightedAverageCostPrice * oDetail.Weight, "", "", "", "",
                                            oDetail.ItemSerialNo, clsGenaralName.getName_ItemCategorySub(oItem.ItemCategorySub_ID));
                                    }
                                }
                            }

                            glb_dtsStock.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "Floor Stock Balance", "", sDateRange, clsSecurity.UserNameLoged, sFilter);


                            //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.gem.ToString())
                            //    print("\\Reports\\SCS\\Commen\\rpt_scs_StockReport_Store_DAP.rpt", " Floor Stock Balance", glb_dtsStock);
                            //else
                            //  {
                            // frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                            // rpt.print("\\Reports\\SCS\\Commen\\rpt_scs_StockReport_Store.rpt", glb_dtsStock, glb_dtsReportExport.dt_rptParameter);
                            print("\\Reports\\SCS\\Commen\\rpt_scs_StockReport_Store.rpt", " Floor Stock Balance", glb_dtsStock);
                            //  }
                        }
                        catch (Exception ex)
                        {
                            clsValidate.WriteErrorLog("", iFormID, ex);
                            SEACCException.Show(ex);
                        }
                        finally
                        {
                            glb_dtsStock.dt_scsFloorStock_Store.Rows.Clear();
                            Cursor = Cursors.Default;
                        }
                    }
                    else
                    {
                        //#region MyRegion
                        //sFormula = "{vw_rpt_masStoreStock.storeName} <> 'default'";

                        //if (txtStore.Tag != null)
                        //    sFormula += "and {vw_rpt_masStoreStock.storeName} = '" + txtStore.Text.Trim() + "'";
                        //if (txtItemType.Tag != null)
                        //    sFormula += "and {vw_rpt_masStoreStock.typeName} = '" + txtItemType.Text.Trim() + "'";
                        //if (txtItemCategory.Tag != null)
                        //    sFormula += "and {vw_rpt_masStoreStock.categoryName} = '" + txtItemCategory.Text.Trim() + "'";
                        //if (txtItemName.Tag != null)
                        //    sFormula += "and {vw_rpt_masStoreStock.itemName} = '" + txtItemName.Text.Trim() + "'";
                        //if (txtJobCode.Tag != null)
                        //    sFormula += "and {vw_rpt_masStoreStock.job_ID} = '" + txtJobCode.Tag.ToString().Trim() + "'";

                        //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                        //    print("\\reports\\SCS\\rpt_scs_StockReport_Store_WSC.rpt", "Floor Stock Balance", sFormula, sFilter);
                        //else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                        //    print("\\reports\\SCS\\rpt_scs_StockReport_Store_APL.rpt", "Floor Stock Balance", sFormula, sFilter);
                        //else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ceilingAndWallPanal.ToString())
                        //    print(@"\reports\SCS\rpt_scs_StockReport_Store_CWP_A4.rpt", "Floor Stock Balance", sFormula, sFilter);
                        //else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                        //    print(@"\reports\SCS\rpt_scs_StockReport_Store_AKT_A4.rpt", "Floor Stock Balance", sFormula, sFilter);
                        //else
                        //    print("\\reports\\SCS\\rpt_scs_StockReport_Store_WD_A4.rpt", "Floor Stock Balance", sFormula, sFilter); 
                        //#endregion
                    }
                }
                #endregion

                #region Section
                if (rdoSection.Checked)
                {
                    sFormula = "{vw_rpt_masSectionStock.sectionName} <> 'default'";

                    if (txtSection.Tag != null)
                    {
                        sFormula += "and {vw_rpt_masSectionStock.sectionName} = '" + txtSection.Text.Trim() + "'";
                        sFilter += "Section : " + txtSection.Text.Trim() + "|";
                    }
                    else
                        sFilter += "All Section" + "|";

                    if (txtItemType.Tag != null)
                    {
                        sFormula += "and {vw_rpt_masSectionStock.typeName} = '" + txtItemType.Text.Trim() + "'";
                        sFilter += "Item Type  :" + txtItemType.Text + "|";
                    }
                    if (txtItemCategory.Tag != null)
                    {
                        sFormula += "and {vw_rpt_masSectionStock.categoryName} = '" + txtItemCategory.Text.Trim() + "'";
                        sFilter += "Item Category  :" + txtItemCategory.Text + "|";
                    }
                    if (txtItemName.Tag != null)
                    {
                        sFormula += "and {vw_rpt_masSectionStock.itemName} = '" + txtItemName.Text.Trim() + "'";
                        sFilter += "Item Name  :" + txtItemName.Text + "|";
                    }
                    if (txtJobCode.Tag != null)
                    {
                        sFormula += "and {vw_rpt_masSectionStock.job_ID} = '" + txtJobCode.Tag.ToString().Trim() + "'";
                        sFilter += "Job Code  :" + txtJobCode.Text + "|";
                    }

                    print("\\reports\\rpt_masSectionStock.rpt", "Floor Stock Balance", sFormula, sFilter);
                }
                #endregion

                #region Department
                if (rdoDepartment.Checked)
                {

                }
                #endregion
                #endregion
            }
            else
            {
                #region Back date report
                Cursor = Cursors.WaitCursor;
                List<string> lstItemType = new List<string>();

                if (bItemType_Selected)
                    lstItemType.Add(txtItemType.Tag.ToString());

                Stockreports oStockreport = new Stockreports(bStore_Selected, bItemCategory_Selected, bItemType_Selected, txtStore, txtItemName, txtItemCategory, lstItemType, dtpTo.Value.Date.AddDays(1), dtpTo.Value.Date.AddDays(1), enum_CostPriceType.CostPrice1, chkShowDeactivate.Checked);
                if (chkShowZeroItem.Checked)
                    oStockreport.bShowAllItems = true;
                oStockreport.GenarateFloorStockReport(enum_ReportName.ST_FloorStockReport, ref progressBar1, false, "Floor Stock Report", "", "");
                oStockreport = null;
                Cursor = Cursors.Default;
                #endregion
            }
        }
        #endregion

        #region ClearField
        private void clearField()
        {
            clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, false);
            clsCommon.SetEnableDisable_NormalCheckBox(chkBackdate, false);
            chkBackdate.Checked = false;
            chkShowDeactivate.Checked = false;

            clsCommon.SetEnableDisable_NormalTextbox(txtDepartment, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtStore, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtSection, false);

            txtDepartment.Text = "     <<ALL Department>>";
            txtSection.Text = "     <<ALL Section>>";
            txtStore.Text = "     <<ALL Store>>";
            txtItemType.Text = "     <<ALL Item Type>>";
            txtItemCategory.Text = "     <<ALL Item Category>>";
            txtItemName.Text = "     <<ALL Item Name>>";
            txtJobCode.Text = "     <<ALL Jobs>>";
            txtStockNoteType.Text = "     <<ALL Note Type>>";

            txtDepartment.Tag = null;
            txtSection.Tag = null;
            txtStore.Tag = null;
            txtItemType.Tag = null;
            txtItemCategory.Tag = null;
            txtItemName.Tag = null;
            txtJobCode.Tag = null;
            txtStockNoteType.Tag = null;

            rdoStore.Checked = true;
            rdoDepartment.Checked = false;
            rdoSection.Checked = false;

            //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.gem.ToString()){
            //    pnlNoteType.Visible = true;
            //    z2.Height = 120;
            //    this.ClientSize = new System.Drawing.Size(344, 285);
            //} 
            //else
            //  {
            pnlNoteType.Visible = false;
            z2.Height = 90;
            this.ClientSize = new System.Drawing.Size(344, 255);
            //  }

            z2.Visible = true;
            z1.Visible = true;
            x1.Visible = true;
            panel2.Visible = true;

            //old method 2017-09-09
            //panel2.Visible = false;
            //this.ClientSize = new System.Drawing.Size(343, 370 - 78);
            //  this.Size.Height = 359 - 48;

            if (clsConfig.bIsEnableStartupStocReconcilation)
                chkBackdate.Visible = false;
        }
        #endregion

        #region Print Method
        private void print(string path, string sReportTitle, string sFormula, string sFilter)
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
                //    clsSecurity.LogonServer(ref RD);
                RD.Refresh();

                RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                RD.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString() || clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                    RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);

                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString() && rdoSection.Checked)
                    RD.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sFilter);


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
                clsValidate.WriteErrorLog("", iFormID, ex);
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
                string s_Path = "", sReportFilter = "";//sHeaderTitle = "Standed Reports", 
                ReportDocument objRpt = new ReportDocument();

                s_Path = Application.StartupPath.Replace("\\Mini ERP\\bin\\Debug", "\\ZION.ERP.Reports");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(ojbDataSet); //(glbDtsBills);

                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);

                try
                {
                    objRpt.DataDefinition.FormulaFields["ToDate"].Text = clsCommon.fncsetstring("As At " + dtpTo.Value.Date.ToString("dd-MMM-yyyy"));
                    objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);

                    if (bStore_Selected)
                        sReportFilter = " Store : " + txtStore.Text;
                    if (bItemName_Selected)
                        sReportFilter += " Item : " + txtItemName.Text;
                    if (bItemCategory_Selected)
                        sReportFilter += " Category : " + txtItemCategory.Text;
                    if (bItemType_Selected)
                        sReportFilter += " type : " + txtItemType.Text;
                    if (sReportFilter == "")
                        sReportFilter = "-";

                    objRpt.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sReportFilter);
                }
                catch (Exception)
                {
                }
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

        #region KeyDown Events
        private void frm_rpt_ChequeManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void txtStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterStore(ref txtStore, true);
        }
        private void txtSection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterSection(ref txtSection);
        }
        private void txtDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterDepartment(ref txtDepartment);
        }
        private void txtItemType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterItemType(ref txtItemType);
        }
        private void txtItemCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterItemCategory(ref txtItemCategory);
        }
        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                //  clsSearch.Search_TransactionDesignPettern_Direct(ref txtItemName);
                //  txtItemName.Text = txtItemName.Tag != null ? clsGenaralName.getName_Item(txtItemName.Tag.ToString().Trim()) : "";
            }
        }
        private void txtJobCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterProductionJob(ref txtJobCode);
        }
        private void txtNoteType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterStockNoteType(ref txtStockNoteType);
        }
        #endregion

        #region Events DoublClick
        private void txtStoreStock_DoubleClick(object sender, EventArgs e)
        {
            //clsSearch.Search_MasterStore(ref txtStore);
            clsSearch.Search_MasterStore_GTN(ref txtStore, true);
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
            //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.gem.ToString())
            //    clsSearch.Search_TransactionDesignPettern_Direct(ref txtItemName);
            //else
            clsSearch.Search_ItemMaster(ref txtItemName, null, null, null, chkShowDeactivate.Checked);
        }
        private void txtJobCode_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterProductionJob(ref txtJobCode);
        }
        private void txtNoteType_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterStockNoteType(ref txtStockNoteType);
        }

        #endregion

        #region Events CheckedChanged
        private void rdoStoreStock_CheckedChanged(object sender, EventArgs e)
        {
            setEnableDisableConctrol();
        }
        private void rdoDepartmentStock_CheckedChanged(object sender, EventArgs e)
        {
            setEnableDisableConctrol();
        }
        private void rdoSectionStock_CheckedChanged(object sender, EventArgs e)
        {
            setEnableDisableConctrol();
        }
        private void chkBackdate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBackdate.Checked)
            {
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkShowDeactivate, true);
            }
            else
            {
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, false);
                clsCommon.SetEnableDisable_NormalCheckBox(chkShowDeactivate, false);
                chkShowDeactivate.Checked = false;
            }
        }
        private void setEnableDisableConctrol()
        {
            clearField();
            if (rdoDepartment.Checked)
                clsCommon.SetEnableDisable_NormalTextbox(txtDepartment, true);

            else if (rdoSection.Checked)
                clsCommon.SetEnableDisable_NormalTextbox(txtSection, true);

            else if (rdoStore.Checked)
            {
                clsCommon.SetEnableDisable_NormalTextbox(txtStore, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkBackdate, true);
                chkBackdate.Checked = true;
                chkItemModel1.Visible = false;
                panel2.Visible = true;

                //old method 2017-09-09
                //chkItemModel1.Text = clsConfig.sItemModel1;
                //this.ClientSize = new System.Drawing.Size(343, 361);
            }
        }
        #endregion
    }

    public class Stockreports_OLD
    {
        dts_Stock glb_dtsStock = new dts_Stock();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        DateTime dtmToDate = DateTime.Now.Date, dtmfromDate = DateTime.Now.Date;
        enum_CostPriceType enCostType = enum_CostPriceType.CostPrice1;


        bool bIsShowDeactivated = false, bItemName_Selected = false, bStore_Selected = false, bItemCategory_Selected = false, bItemType_Selected = false;
        TextBox txtStore, txtItemName, txtItemCategory;
        int iRptType = 0;
        List<string> lstItemType = new List<string>();
        string sDaterange = "";
        string sRptName = "", sRptName2 = "", sRptPath = "";
        string sDateRange = "";
        bool bIsSummaryReport = false;
        public bool bShowAllItems = false;

        public Stockreports_OLD(bool Store_Selected, bool ItemCategory_Selected, bool ItemType_Selected, TextBox TxtStore, TextBox TxtItemName, TextBox TxtItemCategory, List<string> LstItemType, DateTime fromDate, DateTime toDate, enum_CostPriceType eCostType, bool isShowDeactivated)
        {
            bIsShowDeactivated = isShowDeactivated;
            bItemName_Selected = TxtItemName.Tag != null ? true : false;
            bStore_Selected = Store_Selected;
            bItemCategory_Selected = ItemCategory_Selected;
            bItemType_Selected = ItemType_Selected;

            txtStore = TxtStore;
            txtItemName = TxtItemName;
            txtItemCategory = TxtItemCategory;
            lstItemType = LstItemType;

            dtmfromDate = fromDate;
            dtmToDate = toDate;
            enCostType = eCostType;
            sDaterange = "As at :" + clsFormatter.FormatDate_Short(toDate);
        }


        public void GenarateFloorStockReport(enum_ReportName eRPTname, ref ProgressBar pb1, bool bTransactionValidateEnable, string sReportTitle_Main, string sReportTitle_Sub)
        {
            #region Check Permissions
            bool bIsauthenticated = false;
            if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(eRPTname)))
                bIsauthenticated = true;
            #endregion

            if (bIsauthenticated)
            {
                //to do
                //optimize branch name get method
                //optimice single store
                //optimaize singal catagory
                //optimize singal type
                //
                pb1.Value = 0;
                string sFilter = "";
                string sReportPath = "";
                if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(eRPTname), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                {
                    List<string> sItemList = new List<string>();
                    glb_dtsStock.Clear();
                    try
                    {
                        #region Fill reference data and string Filter
                        foreach (tbl_genStoreMaster oStore in tbl_genStoreMaster.SelectAll())
                        {
                            glb_dtsStock.dt_Store.Adddt_StoreRow(oStore.Store_ID, oStore.StoreName);
                        }
                        foreach (tbl_zItemClass oItemClass in tbl_zItemClass.SelectAll())
                        {
                            glb_dtsStock.dt_ItemClass.Adddt_ItemClassRow(oItemClass.ItemClass_ID, oItemClass.ClassName);
                        }
                        foreach (tbl_zItemType oItemType in tbl_zItemType.SelectAll())
                        {
                            glb_dtsStock.dt_ItemType.Adddt_ItemTypeRow(oItemType.ItemType_ID, oItemType.TypeName);
                        }
                        foreach (tbl_zItemCategory oitemCat in tbl_zItemCategory.SelectAll())
                        {
                            glb_dtsStock.dt_ItemCategory.Adddt_ItemCategoryRow(oitemCat.ItemCategory_ID, oitemCat.CategoryName);
                        }
                        foreach (tbl_zItemCategory_Sub oItemCatSub in tbl_zItemCategory_Sub.SelectAll())
                        {
                            glb_dtsStock.dt_ItemSubCategory.Adddt_ItemSubCategoryRow(oItemCatSub.ItemCategorySub_ID, oItemCatSub.CategorySubName);
                        }
                        if (eRPTname == enum_ReportName.ST_Stocks_MovementReport_Detail || eRPTname == enum_ReportName.ST_Items_Card || eRPTname == enum_ReportName.ST_Stock_Statement || eRPTname == enum_ReportName.ST_FloorStockReport)
                        {
                            foreach (tbl_genItemMaster oItem in tbl_genItemMaster.SelectAll())
                            {
                                tbl_genItemMaster_Pricing oItemF = tbl_genItemMaster_Pricing.Select(oItem.Item_ID);
                                if (oItemF != null)
                                {
                                    glb_dtsStock.dt_ItemMaster.Adddt_ItemMasterRow(oItem.Item_ID, oItem.ItemName, oItem.Description, oItem.IsWeightCalculation_Purchase, oItem.Brand_ID, oItemF.SellingPrice1, oItemF.SellingPrice2);
                                }
                            }
                        }

                        if (bStore_Selected)
                            sFilter += "  Item Store : " + txtStore.Text;
                        if (bItemName_Selected)
                            sFilter += "  Item : " + txtItemName.Text;
                        if (bItemCategory_Selected)
                            sFilter += "  Item Category : " + txtItemCategory.Text;
                        if (bItemType_Selected)
                        {
                            sFilter += "  Item type : ";
                            foreach (string sItemType in lstItemType)
                            {
                                sFilter += clsGenaralName.getName_ItemType(sItemType) + ",";
                            }
                        }
                        if (sFilter == "")
                            sFilter = "-";
                        #endregion

                        #region Report Filter
                        decimal dCostPriceValue = 0;
                        if (eRPTname == enum_ReportName.ST_FloorStockReport || eRPTname == enum_ReportName.ST_Stock_Value_Report)
                            iRptType = 0;
                        else
                        {
                            if (eRPTname == enum_ReportName.ST_Stock_Value_Report_Qty || eRPTname == enum_ReportName.ST_Stock_Value_Report_Qty_Detail)
                                iRptType = 1;
                        }
                        if (eRPTname == enum_ReportName.ST_Stock_Value_Report_Qty || eRPTname == enum_ReportName.ST_Stock_Value_Report_Waight)
                            bIsSummaryReport = true;
                        #endregion

                        List<srh_scsFlowStock> oDetail;
                        if (bItemName_Selected)
                            oDetail = srh_scsFlowStock.Select(dtmfromDate.AddDays(-1), txtItemName.Tag.ToString().Trim(), bIsShowDeactivated ? "%" : "0", "");
                        else
                            oDetail = srh_scsFlowStock.Select(dtmfromDate.AddDays(-1), "%", bIsShowDeactivated ? "%" : "0", "");

                        #region Detail report only
                        if (eRPTname == enum_ReportName.ST_Stocks_MovementReport || eRPTname == enum_ReportName.ST_Stocks_MovementReport_Detail || eRPTname == enum_ReportName.ST_Stocks_TrackingReport_Qty || eRPTname == enum_ReportName.ST_Stocks_TrackingReport_Weight || eRPTname == enum_ReportName.ST_Items_Card || eRPTname == enum_ReportName.ST_Stock_Statement)
                        {
                            sDaterange = clsFormatter.FormatDate_Short(dtmfromDate.Date) + " To " + clsFormatter.FormatDate_Short(dtmToDate.Date);

                            if (eRPTname == enum_ReportName.ST_Stocks_TrackingReport_Qty)
                                iRptType = 1;

                            #region filter - Item

                            string sItem_ID_ForDetail = "%%";
                            string sStore_ID_ForDetail = "%%";
                            if (bItemName_Selected)
                            {
                                sItem_ID_ForDetail = txtItemName.Tag.ToString().Trim();
                            }
                            #endregion

                            #region Filter - Store
                            if (bStore_Selected)
                            {
                                sStore_ID_ForDetail = txtStore.Tag.ToString().Trim();
                            }
                            #endregion
                            foreach (srh_scsFlowStock_detail oStocktxn in srh_scsFlowStock_detail.Select(dtmfromDate.AddDays(-1), dtmToDate, "", sItem_ID_ForDetail, sStore_ID_ForDetail))
                            {
                                //oStocktxn.NoteType;

                                #region Filter - Catagory
                                if (bItemCategory_Selected)
                                {
                                    if (txtItemCategory.Tag.ToString().Trim() != oStocktxn.ItemCategory_ID)
                                        continue;
                                }
                                #endregion

                                #region Filter - Type
                                if (bItemType_Selected)
                                {
                                    if (!lstItemType.Contains(oStocktxn.ItemType_ID))
                                        continue;
                                }
                                #endregion

                                glb_dtsStock.dt_scsFloorStock.Adddt_scsFloorStockRow(oStocktxn.Store_ID, oStocktxn.Item_ID, oStocktxn.ItemName, oStocktxn.Brand_ID, oStocktxn.ItemSerialNo, oStocktxn.ItemType_ID, oStocktxn.ItemCategory_ID, "-", oStocktxn.Uom, oStocktxn.Weight_issued, oStocktxn.Weight_received, oStocktxn.Qty_issued, oStocktxn.Qty_received, dCostPriceValue, 0, oStocktxn.TxnID, oStocktxn.TxnDate, oStocktxn.Remarks, oStocktxn.CreateUser_ID, oStocktxn.IsWeightCalculation, oStocktxn.NoteType);

                                #region Transaction Validation
                                if (bTransactionValidateEnable)
                                {
                                    if (!sItemList.Contains(oStocktxn.Item_ID))
                                        sItemList.Add(oStocktxn.Item_ID);
                                }
                                #endregion
                            }
                        }
                        #endregion

                        #region Openning Balance
                        foreach (var oStock in oDetail.GroupBy(cm => new { cm.Item_ID, cm.ItemName, cm.Brand_ID, cm.Store_ID, cm.ItemCategory_ID, cm.ItemCategorySub_ID, cm.ItemSubCategory2_ID, cm.ItemSerialNo, cm.ItemSerialNo2, cm.ItemType_ID, cm.Uom, cm.IsWeightCalculation }, (key, group) => new { itemId = key.Item_ID, itemName = key.ItemName, brandId = key.Brand_ID, storeID = key.Store_ID, itemCatID = key.ItemCategory_ID, itemSubcat1 = key.ItemCategorySub_ID, itemSubcat2 = key.ItemSubCategory2_ID, itemSerialNo1 = key.ItemSerialNo, itemSerialNo2 = key.ItemSerialNo2, typeId = key.ItemType_ID, uom = key.Uom, qty = group.Sum(p => p.Qty), waight = group.Sum(p => p.Weight), isWaight = key.IsWeightCalculation }).ToList())
                        {
                            clsHelpMethods_Local.startProgressBar(0, oDetail.Count + 1, 1, pb1);
                            dCostPriceValue = 0;

                            if (!bShowAllItems)
                            {
                                if (oStock.waight == 0 && oStock.qty == 0)
                                    continue;
                            }

                            #region Transaction Validation
                            if (bTransactionValidateEnable)
                            {
                                if (!sItemList.Contains(oStock.itemId))
                                    continue;
                            }
                            #endregion

                            #region filter - Item
                            if (bItemName_Selected)
                            {
                                if (txtItemName.Tag.ToString().Trim() != oStock.itemId)
                                    continue;
                            }
                            #endregion

                            #region Filter - Store
                            if (bStore_Selected)
                            {
                                if (txtStore.Tag.ToString().Trim() != oStock.storeID)
                                    continue;
                            }
                            #endregion

                            #region Filter - Catagory
                            if (bItemCategory_Selected)
                            {
                                if (txtItemCategory.Tag.ToString().Trim() != oStock.itemCatID)
                                    continue;
                            }
                            #endregion

                            #region Filter - Type
                            if (bItemType_Selected)
                            {
                                if (!lstItemType.Contains(oStock.typeId))
                                    continue;
                            }
                            #endregion

                            if (eRPTname != enum_ReportName.ST_FloorStockReport)
                                dCostPriceValue = clsProcessMethods.GetCostPrice_ByCostType(oStock.itemId, enCostType);

                            glb_dtsStock.dt_scsFloorStock.Adddt_scsFloorStockRow(oStock.storeID, oStock.itemId, oStock.itemName, oStock.brandId, "-", oStock.typeId, oStock.itemCatID, oStock.itemSerialNo1, oStock.uom, 0, oStock.waight, 0, oStock.qty, dCostPriceValue, 0, "-", dtmfromDate.AddDays(-1), "Opening Balance", "-", oStock.isWaight, 0);
                        }
                        #endregion



                        glb_dtsStock.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Filter", sFilter, true);

                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                        if (eRPTname == enum_ReportName.ST_FloorStockReport)
                            rpt.print(sReportPath, glb_dtsStock, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(eRPTname));
                        else
                            print(sReportPath, glb_dtsStock);

                        pb1.Value = 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        glb_dtsStock.Clear();
                    }
                }
            }
        }

        private void print(string path, DataSet ojbDataSet)
        {
            try
            {
                string s_Path = "", sReportFilter = "";
                ReportDocument objRpt = new ReportDocument();

                s_Path = Application.StartupPath.Replace("\\Mini ERP\\bin\\Debug", "\\ZION.ERP.Reports");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(ojbDataSet); //(glbDtsBills);

                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sRptName);
                objRpt.DataDefinition.FormulaFields["ReportTitle2"].Text = clsCommon.fncsetstring(sRptName2);

                objRpt.DataDefinition.FormulaFields["ToDate"].Text = clsCommon.fncsetstring(sDaterange == "" ? "As At " + dtmToDate.Date.ToString("dd-MMM-yyyy") : sDaterange);
                objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);

                objRpt.DataDefinition.FormulaFields["ReportType"].Text = clsCommon.fncsetstring(iRptType.ToString());
                objRpt.DataDefinition.FormulaFields["isSummaryReport"].Text = clsCommon.fncsetstring(bIsSummaryReport ? "1" : "0");

                objRpt.SetParameterValue("NoOfDecimalPlaces", clsConfig.sDecimalPlaces_Quantity);

                string sLCostByValue = "";

                if (enCostType == enum_CostPriceType.WeightedAverage)
                    sLCostByValue = "Weighted Average";
                if (enCostType == enum_CostPriceType.LIFO)
                    sLCostByValue = "LIFO";
                if (enCostType == enum_CostPriceType.FIFO)
                    sLCostByValue = "FIFO";
                if (enCostType == enum_CostPriceType.HighestPurchaseCost)
                    sLCostByValue = "Highest Purchase Cost";
                if (enCostType == enum_CostPriceType.LovestPurchaseCost)
                    sLCostByValue = "Lovest Purchase Cost";
                if (enCostType == enum_CostPriceType.CostPrice1)
                    sLCostByValue = "Cost Price 1";
                if (enCostType == enum_CostPriceType.CostPrice2)
                    sLCostByValue = "Cost Price 2";

                objRpt.DataDefinition.FormulaFields["CostType"].Text = clsCommon.fncsetstring(sLCostByValue);

                if (bStore_Selected)
                    sReportFilter += "  Item Store : " + txtStore.Text;
                if (bItemName_Selected)
                    sReportFilter += "  Item : " + txtItemName.Text;
                if (bItemCategory_Selected)
                    sReportFilter += "  Item Category : " + txtItemCategory.Text;
                if (bItemType_Selected)
                {
                    sReportFilter += "  Item type : ";
                    foreach (string sItemType in lstItemType)
                    {
                        sReportFilter += clsGenaralName.getName_ItemType(sItemType) + ",";
                    }
                }

                if (sReportFilter == "")
                    sReportFilter = "-";

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
                clsValidate.WriteErrorLog("", -1, ex);
                SEACCException.Show(ex);
            }
            finally
            {
            }
        }
    }
}
