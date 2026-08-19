using DataTire;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Zion.ERP.Reports.DataSets.COM;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;
using Zion.ERP.Reports.DataSets;
using ZION.ERP.Reports.DataSets.COM;
using SEACC.DATA.Data.Com;
using Newtonsoft.Json;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using OfficeOpenXml.Style;

namespace Digiteq.Reports.COM
{
    public partial class frm_rpt_CommissionRegister : MettroForm
    {
        CommishionData commishion = new CommishionData();
        #region Class Variable

        public bool bComPeriodSlection = false, bSalesRepSelected = false, bAreaManager = false, bSalesManager = false, bCollector = false, bItemTypeSelected = false, bItemCategorySelected = false;

        //DataSet Object
        dts_ComDetail glbComDetail = new dts_ComDetail();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();


        private int iReportNo;
        #endregion

        #region Form Load
        public frm_rpt_CommissionRegister()
        {
            iFormID = clsSecurity.getFormID(FormName.Com_RegisterReports);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }

        private void frm_rpt_CommissionRegister_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "Sales Commssion - Register Reports", 2, iFormID);
            ThemeColor = clsFormatter.colorSales;

            ClearField();
            DisplayReports();
        }
        #endregion

        #region Display Reports
        private void DisplayReports()
        {
            try
            {
                dgvReports.Rows.Clear();
                dgvReports.DataSource = DBHandling.ExecQuery("EXEC sp_Reports '" + 37 + "'").Tables[0];
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Button Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearField();
        }
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvReports.SelectedCells.Count != 0)
            {
                if (dgvReports.Rows.Count > 0)
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        ProgressBar.Value = 0;

                        glbComDetail.Clear();
                        glb_dtsReportExport.Clear();

                        int iRow = dgvReports.SelectedCells[0].RowIndex;
                        int iReport = int.Parse(dgvReports.Rows[iRow].Cells[0].Value.ToString());
                        enum_ReportName Report = (enum_ReportName)iReport;

                        if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(Report)))
                        {
                            string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                            if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(Report), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                            {
                                #region Filter
                                ProgressBar.Value = 0;
                                //get selection controls
                                bComPeriodSlection = false; bSalesRepSelected = false; bAreaManager = false; bSalesManager = false; bCollector = false; bItemTypeSelected = false; bItemCategorySelected = false;
                                string sFilter = "";

                                if (txtComPeriod.Tag != null && txtComPeriod.Tag.ToString().Trim().Length > 0)
                                    bComPeriodSlection = true;
                                if (txtSalesRep.Tag != null && txtSalesRep.Tag.ToString().Trim().Length > 0)
                                    bSalesRepSelected = true;
                                if (txtAreaManager.Tag != null && txtAreaManager.Tag.ToString().Trim().Length > 0)
                                    bAreaManager = true;
                                if (txtSalesManager.Tag != null && txtSalesManager.Tag.ToString().Trim().Length > 0)
                                    bSalesManager = true;
                                if (txtCollector.Tag != null && txtCollector.Tag.ToString().Trim().Length > 0)
                                    bCollector = true;
                                if (txtItemType.Tag != null && txtItemType.Tag.ToString().Trim().Length > 0)
                                    bItemTypeSelected = true;
                                if (txtItemCategory.Tag != null && txtItemCategory.Tag.ToString().Trim().Length > 0)
                                    bItemCategorySelected = true;
                                #endregion

                                #region Selected Filters
                                if (bComPeriodSlection)
                                    sFilter += (sFilter == "" ? "" : " | ") + "Commission Period : " + txtComPeriod.Text.Trim();
                                if (bSalesRepSelected)
                                    sFilter += (sFilter == "" ? "" : " | ") + "Sales Rep. : " + txtSalesRep.Text.Trim();
                                if (bAreaManager)
                                    sFilter += (sFilter == "" ? "" : " | ") + "Area Manager : " + txtAreaManager.Text.Trim();
                                if (bSalesManager)
                                    sFilter += (sFilter == "" ? "" : " | ") + "Sales Manager : " + txtSalesManager.Text.Trim();
                                if (bCollector)
                                    sFilter += (sFilter == "" ? "" : " | ") + "Collector : " + txtCollector.Text.Trim();
                                if (bItemTypeSelected)
                                    sFilter += (sFilter == "" ? "" : " | ") + "Item Type : " + txtItemType.Text.Trim();
                                if (bItemCategorySelected)
                                    sFilter += (sFilter == "" ? "" : " | ") + "Sales Note Type : " + txtItemCategory.Tag.ToString();
                                #endregion

                                #region Sales Rep Report
                                if (!bComPeriodSlection)
                                {
                                    MessageBox.Show("Please select Risk Allowance period..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                if (Report == enum_ReportName.COM_Commission_Report_ItemCategory_SalesRep_New )
                                {
                                    Cursor = Cursors.WaitCursor;

                                    int CommishionPeriod = int.Parse(txtComPeriod.Tag.ToString());
                                    string sSalesmanID = bSalesRepSelected ? txtSalesRep.Tag.ToString() : "";
                                    int dateSlab = int.Parse(txtDays.Text);

                                    if (CommishionPeriod != -1)
                                    {
                                        var xx = commishion.get_CommissionSalesRep(CommishionPeriod, sSalesmanID, dateSlab);
                                        var json = JsonConvert.SerializeObject(xx.t1);
                                        DataTable dt1 = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
                                        //dgvMain.DataSource = dt;
                                        var json2 = JsonConvert.SerializeObject(xx.t2);
                                        DataTable dt2 = (DataTable)JsonConvert.DeserializeObject(json2, (typeof(DataTable)));

                                        //var json3 = JsonConvert.SerializeObject(xx.dt3);
                                        //DataTable dt3 = (DataTable)JsonConvert.DeserializeObject(json3, (typeof(DataTable)));

                                        SaveFileDialog dlg = new SaveFileDialog();
                                        dlg.DefaultExt = ".xls";
                                        dlg.Filter = "Text documents (.xls)|*.xlsx";

                                        if (dlg.ShowDialog() == DialogResult.OK)
                                        {
                                            try
                                            {
                                                FileInfo files = new FileInfo(dlg.FileName);

                                                string filename = dlg.FileName;
                                                using (ExcelPackage pck = new ExcelPackage(files))
                                                {
                                                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Summary");

                                                    ws.Cells["A1"].Value = "COMMISSIONS - SALES REP " + txtComPeriod.Text;
                                                    ws.Cells["A2"].Value = "Name  - " + sSalesmanID+" - "+txtSalesRep.Text;

                                                 //   ws.Cells["A4"].LoadFromDataTable(dt2, false);

                                                    int i = 4;
                                                    foreach (DataRow dtRow in dt2.Rows)
                                                    {
                                                        Decimal VAL1 = 0, VAL2 = 0;
                                                        Decimal.TryParse(dtRow[1].ToString(),out VAL1);
                                                        Decimal.TryParse(dtRow[2].ToString(), out VAL2);

                                                        ws.Cells[i,1].Value = dtRow[0].ToString();
                                                        if (VAL1 != 0)
                                                        {
                                                            ws.Cells[i, 2].Value = VAL1;
                                                            ws.Cells[i, 2].Style.Numberformat.Format = "#,##0.00";
                                                        }
                                                        if (VAL2 != 0)
                                                        {
                                                            ws.Cells[i, 3].Value = VAL2;
                                                            ws.Cells[i, 3].Style.Numberformat.Format = "#,##0.00";
                                                        }
                                                        if (  dtRow[3].ToString()=="Y")
                                                            ws.Cells[i, 1, i, 3].Style.Font.Bold = true;

                                                        if (dtRow[4].ToString() != "")
                                                        {
                                                            string[] numbersArray = dtRow[4].ToString().Split(',');
                                                            ws.Cells[i, 1, i, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                                            ws.Cells[i, 1, i, 3].Style.Fill.BackgroundColor.SetColor(int.Parse( numbersArray[0]), int.Parse(numbersArray[1]), int.Parse(numbersArray[2]), int.Parse(numbersArray[3]));
                                                        }
                                                        if (dtRow[5].ToString() == "Y")
                                                            ws.Cells[i, 1, i, 3].Style.Border.Top.Style = ExcelBorderStyle.Thin;

                                                        if (dtRow[6].ToString() == "Y")
                                                            ws.Cells[i, 1, i, 3].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                                                        i++;
                                                    }



                                                    //ws.Cells[4, 1,4,3].Style.Font.Bold = true;
                                                    //ws.Cells[4, 1, 4, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                                    //ws.Cells[4, 1, 4, 3].Style.Fill.BackgroundColor.SetColor(Color.Silver);

                                                    //ws.Cells[5, 1, 5, 3].Style.Font.Bold = true;
                                                    //ws.Cells[8, 1, 8, 3].Style.Font.Bold = true;
                                                    //ws.Cells[8, 1, 8, 3].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                                    //ws.Cells[8, 1, 8, 3].Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                                                    //ExcelRange cellRange = ws.Cells[4, 1, dt2.Rows.Count + 3, (dt2.Columns.Count)];

                                                    //cellRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                                    //cellRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                                    //cellRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                                    //cellRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                                    //   ExcelStyle hh = new ExcelStyle();
                                                    // ws.SelectedRange[4, 1, dt2.Rows.Count + 3, (dt2.Columns.Count)].Style=
                                                    //   ExcelTable tab = ws.Tables.Add(range, "Table1");

                                                    //   tab.ShowFilter = true;
                                                    //  tab.ShowTotal = true;

                                                    //int i = 0;
                                                    //foreach (DataColumn dtRow in dt2.Columns)
                                                    //{
                                                    //    var x = dtRow.DataType.Name.ToString();

                                                    //    tab.Columns[i].Name = dtRow.ColumnName;
                                                    //    if (dtRow.DataType == typeof(decimal) || dtRow.DataType == typeof(Double))
                                                    //    {
                                                    //        tab.Columns[i].TotalsRowFormula = "SUBTOTAL(109,[" + dtRow.ColumnName + "])"; //102 = Count 
                                                    //    }
                                                    //    i++;
                                                    //}

                                                    //  tab.Columns[0].TotalsRowLabel = "Total ";

                                                    //    tab.TableStyle = TableStyles.Light15;


                                                    var cel = "A" + (dt2.Rows.Count + 9);

                                                    ws.Cells[cel].LoadFromDataTable(dt1, true);
                                                    ExcelRange range2 = ws.Cells[dt2.Rows.Count + 9, 1, dt1.Rows.Count + dt2.Rows.Count + 8, dt1.Columns.Count];
                                                    ExcelTable tab2 = ws.Tables.Add(range2, "Table2");

                                                    tab2.ShowFilter = true;
                                                    tab2.ShowTotal = true;

                                                    int j = 0;
                                                    foreach (DataColumn dtRow in dt1.Columns)
                                                    {
                                                        // var x = dtRow.DataType.Name.ToString();

                                                        tab2.Columns[j].Name = dtRow.ColumnName + "_";
                                                        if (dtRow.DataType == typeof(decimal) || dtRow.DataType == typeof(Double))
                                                        {
                                                            tab2.Columns[j].TotalsRowFormula = "SUBTOTAL(109,[" + dtRow.ColumnName + "_])"; //102 = Count 
                                                        }
                                                        j++;
                                                    }



                                                    tab2.Columns[0].TotalsRowLabel = "Total_";

                                                    tab2.TableStyle = TableStyles.Medium2;

                                                    //   var StartCell = "A" +( i+5);
                                                    //   ws.Cells[StartCell].LoadFromDataTable(dt2, true);

                                                    //  ExcelWorksheet ws3 = pck.Workbook.Worksheets.Add("Detail");
                                                    //   DataTable dt = ((DataTable)this.DataSource);
                                                    //    ws3.Cells["A1"].LoadFromDataTable(dt3, true);
                                                    ws.Cells["A:N"].AutoFitColumns();
                                                    pck.Save();
                                                    System.Diagnostics.Process.Start(dlg.FileName);
                                                }
                                            }
                                            catch (Exception ex)
                                            {

                                                MessageBox.Show(ex.Message);
                                            }

                                        }
                                    }
                                            //  glbComDetail.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, "", clsSecurity.UserNameLoged, sFilter);

                                    //        string sItemType = bItemTypeSelected ? txtItemType.Tag.ToString() : "";
                                    //string sItemCategory = bItemCategorySelected ? txtItemCategory.Tag.ToString() : "";
                                    //string sSalesmanID = bSalesRepSelected ? txtSalesRep.Tag.ToString() : "";
                                    //string sAriaManager = bAreaManager ? txtAreaManager.Tag.ToString() : "";
                                    //string sSalesManager = bSalesManager ? txtSalesManager.Tag.ToString() : "";
                                    //string ReportTy = "";
                                    //if (Report == enum_ReportName.COM_Commission_Report_ItemCategory_SalesRep)
                                    //    ReportTy = "SR";
                                    //if (Report == enum_ReportName.COM_Commission_Report_ItemCategory_AreaManager)
                                    //    ReportTy = "AM";
                                    //if (Report == enum_ReportName.COM_Commission_Report_ItemCategory_SalesManager)
                                    //    ReportTy = "SM";

                                    //string sQuary = "exec [sp_GetRpt_Commission] '" + ReportTy + "', '" + sSalesmanID + "', '" + sAriaManager + "', '" + sSalesManager + "', '" + sItemType + "','" + sItemCategory + "'," + txtComPeriod.Tag.ToString();

                                    //glbComDetail.dt_Cat_Commission.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);
                                    //glbComDetail.dt_Rep.Merge(DBHandling.ExecQuery("exec sp_getrpt_SalesRep").Tables[0]);

                                    //frm_ReportViewer_New CRViwer = new frm_ReportViewer_New();
                                    //CRViwer.print(sReportPath, glbComDetail, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                    Cursor = Cursors.Default;
                                }
                             else   if (Report == enum_ReportName.COM_Commission_Report_ItemCategory_SalesRep || Report == enum_ReportName.COM_Commission_Report_ItemCategory_AreaManager || Report == enum_ReportName.COM_Commission_Report_ItemCategory_SalesManager)
                                {
                                    Cursor = Cursors.WaitCursor;
                                    glbComDetail.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, "", clsSecurity.UserNameLoged, sFilter);

                                    string sItemType = bItemTypeSelected ? txtItemType.Tag.ToString() : "";
                                    string sItemCategory = bItemCategorySelected ? txtItemCategory.Tag.ToString() : "";
                                    string sSalesmanID = bSalesRepSelected ? txtSalesRep.Tag.ToString() : "";
                                    string sAriaManager = bAreaManager ? txtAreaManager.Tag.ToString() : "";
                                    string sSalesManager = bSalesManager ? txtSalesManager.Tag.ToString() : "";
                                    string ReportTy = "";
                                    if (Report == enum_ReportName.COM_Commission_Report_ItemCategory_SalesRep)
                                        ReportTy = "SR";
                                    if (Report == enum_ReportName.COM_Commission_Report_ItemCategory_AreaManager)
                                        ReportTy = "AM";
                                    if (Report == enum_ReportName.COM_Commission_Report_ItemCategory_SalesManager)
                                        ReportTy = "SM";

                                    string sQuary = "exec [sp_GetRpt_Commission] '" + ReportTy + "', '" + sSalesmanID + "', '" + sAriaManager + "', '" + sSalesManager + "', '" + sItemType + "','" + sItemCategory + "'," + txtComPeriod.Tag.ToString();

                                    glbComDetail.dt_Cat_Commission.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);
                                    glbComDetail.dt_Rep.Merge(DBHandling.ExecQuery("exec sp_getrpt_SalesRep").Tables[0]);

                                    frm_ReportViewer_New CRViwer = new frm_ReportViewer_New();
                                    CRViwer.print(sReportPath, glbComDetail, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                    Cursor = Cursors.Default;
                                }
                                #endregion



                                #region Collector Report
                                if (Report == enum_ReportName.COM_Commission_Report_ItemCategory_Collecotr)
                                {
                                    if (true)
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glbComDetail.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, "", clsSecurity.UserNameLoged, sFilter);

                                        string sItemType = bItemTypeSelected ? txtItemType.Tag.ToString() : "";
                                        string sItemCategory = bItemCategorySelected ? txtItemCategory.Tag.ToString() : "";
                                        string sSalesmanID = bSalesRepSelected ? txtSalesRep.Tag.ToString() : "";
                                        string sAriaManager = bAreaManager ? txtAreaManager.Tag.ToString() : "";
                                        string sSalesManager = bSalesManager ? txtSalesManager.Tag.ToString() : "";
                                        string ReportTy = "";
                                       
                                        string sQuary = "exec [sp_GetRpt_Commission_Collector] '" + ReportTy + "', '" + sSalesmanID + "', '" + sAriaManager + "', '" + sSalesManager + "', '" + sItemType + "','" + sItemCategory + "'," + txtComPeriod.Tag.ToString();

                                        glbComDetail.dt_Cat_Commission.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);
                                        glbComDetail.dt_Rep.Merge(DBHandling.ExecQuery("exec sp_getrpt_SalesRep").Tables[0]);

                                        frm_ReportViewer_New CRViwer = new frm_ReportViewer_New();
                                        CRViwer.print(sReportPath, glbComDetail, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                        Cursor = Cursors.Default;
                                    }
                                    else
                                    {
                                        //Company Details
                                        glbComDetail.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, "", clsSecurity.UserNameLoged, sFilter);

                                        List<tbl_comCommissionCalculation> oCommissions = null;
                                        if (bComPeriodSlection)
                                            oCommissions = tbl_comCommissionCalculation.SelectAllByPeriodIndex(long.Parse(txtComPeriod.Tag.ToString()));
                                        else
                                            oCommissions = tbl_comCommissionCalculation.SelectAll();

                                        if (bCollector)
                                            oCommissions = oCommissions.Where(r => r.Collector_ID.Trim() == txtCollector.Tag.ToString().Trim()).ToList();

                                        foreach (tbl_comCommissionCalculation oCom in oCommissions.Where(r => r.Collector_ID != "default"))
                                        {
                                            tbl_comCommissionPeriodMaster oPeriod = tbl_comCommissionPeriodMaster.Select(oCom.PeriodIndex);

                                            //Add Invoice Sales
                                            foreach (var oInvoice in tbl_sasInvoice.SelectAllByCollector_ID(oCom.Collector_ID).Where(r => !r.IsDeleted && !r.IsDebitNote && r.InvoiceDate.Date >= oPeriod.DateFrom.Date && r.InvoiceDate.Date <= oPeriod.DateTo.Date))
                                            {
                                                foreach (tbl_sasInvoice_Detail oInvoiceDetail in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID))
                                                {
                                                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oInvoiceDetail.Item_ID);
                                                    if (oItem != null)
                                                    {
                                                        if (bItemTypeSelected)
                                                            if (oItem.ItemType_ID != txtItemType.Tag.ToString())
                                                                continue;

                                                        if (bItemCategorySelected)
                                                            if (oItem.ItemCategory_ID != txtItemCategory.Tag.ToString())
                                                                continue;

                                                        tbl_comItemCategory_comissionRates oItemCategory = tbl_comItemCategory_comissionRates.Select(oItem.ItemCategory_ID);
                                                        if (oItemCategory != null)
                                                        {
                                                            //Item Category Wise Details

                                                            if (oInvoiceDetail.DiscountAmount <= 0)
                                                            {
                                                                glbComDetail.dt_Cat_Commission.Adddt_Cat_CommissionRow(
                                                                    oPeriod.PeriodName, oPeriod.PeriodIndex, oCom.Collector_ID,
                                                                    clsGenaralName.getName_SalesRep(oCom.Collector_ID),
                                                                    oCom.Remarks, oItem.ItemClass_ID,
                                                                    clsGenaralName.getItemClass_ID(oItem.ItemClass_ID),
                                                                    oItem.ItemType_ID,
                                                                    clsGenaralName.getName_ItemType(oItem.ItemType_ID),
                                                                    clsGenaralName.getName_ItemCategoryPrefix(oItem.ItemCategory_ID),
                                                                    clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID),
                                                                    oInvoiceDetail.TatalAmount, oItemCategory.NormalSalesRate_AM,
                                                                    (oInvoiceDetail.TatalAmount * oItemCategory.NormalSalesRate_AM), "");
                                                            }
                                                            else
                                                            {
                                                                glbComDetail.dt_Cat_Commission.Adddt_Cat_CommissionRow(
                                                                    oPeriod.PeriodName, oPeriod.PeriodIndex, oCom.Collector_ID,
                                                                    clsGenaralName.getName_SalesRep(oCom.Collector_ID),
                                                                    oCom.Remarks, oItem.ItemClass_ID,
                                                                    clsGenaralName.getItemClass_ID(oItem.ItemClass_ID),
                                                                    oItem.ItemType_ID,
                                                                    clsGenaralName.getName_ItemType(oItem.ItemType_ID),
                                                                    clsGenaralName.getName_ItemCategoryPrefix(oItem.ItemCategory_ID),
                                                                    clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID),
                                                                    oInvoiceDetail.TatalAmount, oItemCategory.DiscountedSalesRate_AM,
                                                                    (oInvoiceDetail.TatalAmount * oItemCategory.DiscountedSalesRate_AM), "");
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            //Deduct Sales Returns
                                            foreach (tbl_sasSalesReturnedNote oSRN in tbl_sasSalesReturnedNote.SelectAllByCollector_ID(oCom.Collector_ID).Where(r => r.SalesReturnedNoteDate.Date >= oPeriod.DateFrom.Date && r.SalesReturnedNoteDate.Date <= oPeriod.DateTo.Date))
                                            {
                                                tbl_sasInvoice oInvoice = tbl_sasInvoice.SelectAllBySalesManager_ID(oCom.SalesManager_ID).Where(r => r.Invoice_ID == oSRN.Invoice_ID).FirstOrDefault();
                                                if (oInvoice != null)
                                                {
                                                    foreach (var oSRN_Detail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSRN.SalesReturnedNote_ID))
                                                    {
                                                        tbl_genItemMaster oItem = tbl_genItemMaster.Select(oSRN_Detail.Item_ID);
                                                        if (oItem != null)
                                                        {
                                                            if (bItemTypeSelected)
                                                                if (oItem.ItemType_ID != txtItemType.Tag.ToString())
                                                                    continue;

                                                            if (bItemCategorySelected)
                                                                if (oItem.ItemCategory_ID != txtItemCategory.Tag.ToString())
                                                                    continue;

                                                            tbl_comItemCategory_comissionRates oItemCategory = tbl_comItemCategory_comissionRates.Select(oItem.ItemCategory_ID);
                                                            if (oItemCategory != null)
                                                            {
                                                                //Item Category Wise Details
                                                                if (oSRN_Detail.DiscountAmount <= 0)
                                                                {
                                                                    glbComDetail.dt_Cat_Commission.Adddt_Cat_CommissionRow(
                                                                        oPeriod.PeriodName, oPeriod.PeriodIndex, oCom.Collector_ID,
                                                                        clsGenaralName.getName_SalesRep(oCom.Collector_ID),
                                                                        oCom.Remarks, oItem.ItemClass_ID,
                                                                        clsGenaralName.getItemClass_ID(oItem.ItemClass_ID),
                                                                        oItem.ItemType_ID,
                                                                        clsGenaralName.getName_ItemType(oItem.ItemType_ID),
                                                                        clsGenaralName.getName_ItemCategoryPrefix(oItem.ItemCategory_ID),
                                                                        clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID),
                                                                        -oSRN_Detail.TatalAmount, oItemCategory.NormalSalesRate_AM,
                                                                        -(oSRN_Detail.TatalAmount * oItemCategory.NormalSalesRate_AM), "");
                                                                }
                                                                else
                                                                {
                                                                    glbComDetail.dt_Cat_Commission.Adddt_Cat_CommissionRow(
                                                                        oPeriod.PeriodName, oPeriod.PeriodIndex, oCom.Collector_ID,
                                                                        clsGenaralName.getName_SalesRep(oCom.Collector_ID),
                                                                        oCom.Remarks, oItem.ItemClass_ID,
                                                                        clsGenaralName.getItemClass_ID(oItem.ItemClass_ID),
                                                                        oItem.ItemType_ID,
                                                                        clsGenaralName.getName_ItemType(oItem.ItemType_ID),
                                                                        clsGenaralName.getName_ItemCategoryPrefix(oItem.ItemCategory_ID),
                                                                        clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID),
                                                                        -oSRN_Detail.TatalAmount, oItemCategory.DiscountedSalesRate_AM,
                                                                        -(oSRN_Detail.TatalAmount * oItemCategory.DiscountedSalesRate_AM), "");
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            clsHelpMethods_Local.startProgressBar(0, oCommissions.Count + 2, 1, ProgressBar);
                                        }
                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glbComDetail, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                    }
                                }
                                #endregion
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
                        ProgressBar.Value = 0;
                    }
                }
            }

        }

        #region Search Events - Text Box Double Click
        private void txtComPeriod_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_MasterComissionPeriod(ref txtComPeriod);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Commission Period", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void txtSalesRep_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                clsSearch.Search_MasterSalesRep(ref txtSalesRep);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Sales Rep Search", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void txtAreaManager_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_AreaManager(ref txtAreaManager);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Area Manager", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void txtSalesManager_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_SalesManager(ref txtSalesManager);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Sales Manager", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void txtCollector_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_MasterCollector(ref txtCollector);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Collector", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void txtItemType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                clsSearch.Search_MasterItemType(ref txtItemType);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Item Type Search", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void txtItemCategory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                clsSearch.Search_MasterItemCategory(ref txtItemCategory);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Item Type Search", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        #endregion

        #region ClearField
        private void ClearField()
        {
            txtComPeriod.Tag = null;
            txtSalesRep.Tag = null;
            txtAreaManager.Tag = null;
            txtSalesManager.Tag = null;
            txtCollector.Tag = null;
            txtItemType.Tag = null;
            txtItemCategory.Tag = null;
            pnldays.Tag = null;

            txtComPeriod.Text = "<All Periods>";
            txtSalesRep.Text = "<All Sales Reps.>";
            txtAreaManager.Text = "<All Area Managers>";
            txtSalesManager.Text = "<All Sales Managers>";
            txtCollector.Text = "<All Collectors>";
            txtItemType.Text = "<All Item Types>";
            txtItemCategory.Text = "<All Item Categories>";
            
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtComPeriod, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCommissionPeriod, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtAreaManager, true);
            clsCommon.SetEnableDisable_NormalLabel(lblAreaManager, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesManager, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSalesManager, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCollector, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCollector, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemType, true);
            clsCommon.SetEnableDisable_NormalLabel(lblItemType, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemCategory, true);
            clsCommon.SetEnableDisable_NormalLabel(lblItemCategory, true);

            clsCommon.SetVisibility_Panel(pnlComPeriod, false);
            clsCommon.SetVisibility_Panel(pnlSalesman, false);
            clsCommon.SetVisibility_Panel(pnlAreeaManager, false);
            clsCommon.SetVisibility_Panel(pnlSalesManager, false);
            clsCommon.SetVisibility_Panel(pnlCollector, false);
            clsCommon.SetVisibility_Panel(pnlItemType, false);
            clsCommon.SetVisibility_Panel(pnlItemCategory, false);
            clsCommon.SetVisibility_Panel(pnldays, false);
        }

        #endregion

        #region Set Enable/Disable Controls
        private void setEnableDisableConctrol(int iReportID)
        {
            ClearField();

            #region Commission Calculation Item Category
            //Customer / Sale Rep
            if (iReportID == (int)enum_ReportName.COM_Commission_Report_ItemCategory_SalesRep)
            {
                clsCommon.SetVisibility_Panel(pnlComPeriod, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlAreeaManager, false);
                clsCommon.SetVisibility_Panel(pnlSalesManager, false);
                clsCommon.SetVisibility_Panel(pnlCollector, false);
                clsCommon.SetVisibility_Panel(pnlItemType, true);
                clsCommon.SetVisibility_Panel(pnlItemCategory, true);
            }

            if (iReportID == (int)enum_ReportName.COM_Commission_Report_ItemCategory_AreaManager)
            {
                clsCommon.SetVisibility_Panel(pnlComPeriod, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, false);
                clsCommon.SetVisibility_Panel(pnlAreeaManager, true);
                clsCommon.SetVisibility_Panel(pnlSalesManager, false);
                clsCommon.SetVisibility_Panel(pnlCollector, false);
                clsCommon.SetVisibility_Panel(pnlItemType, true);
                clsCommon.SetVisibility_Panel(pnlItemCategory, true);
            }

            if (iReportID == (int)enum_ReportName.COM_Commission_Report_ItemCategory_SalesManager)
            {
                clsCommon.SetVisibility_Panel(pnlComPeriod, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, false);
                clsCommon.SetVisibility_Panel(pnlAreeaManager, false);
                clsCommon.SetVisibility_Panel(pnlSalesManager, true);
                clsCommon.SetVisibility_Panel(pnlCollector, false);
                clsCommon.SetVisibility_Panel(pnlItemType, true);
                clsCommon.SetVisibility_Panel(pnlItemCategory, true);
            }

            if (iReportID == (int)enum_ReportName.COM_Commission_Report_ItemCategory_Collecotr)
            {
                clsCommon.SetVisibility_Panel(pnlComPeriod, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, false);
                clsCommon.SetVisibility_Panel(pnlAreeaManager, false);
                clsCommon.SetVisibility_Panel(pnlSalesManager, false);
                clsCommon.SetVisibility_Panel(pnlCollector, true);
                clsCommon.SetVisibility_Panel(pnlItemType, true);
                clsCommon.SetVisibility_Panel(pnlItemCategory, true);
            }
            if (iReportID == (int)enum_ReportName.COM_Commission_Report_ItemCategory_SalesRep_New)
            {
                clsCommon.SetVisibility_Panel(pnlComPeriod, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnldays, true);
                txtDays.Text = "90";
                // clsCommon.SetVisibility_Panel(pnlAreeaManager, false);
                //  clsCommon.SetVisibility_Panel(pnlSalesManager, false);
                //  clsCommon.SetVisibility_Panel(pnlCollector, true);
                //  clsCommon.SetVisibility_Panel(pnlItemType, true);
                //  clsCommon.SetVisibility_Panel(pnlItemCategory, true);
            }
            #endregion
        }
        #endregion

        #region Report Grid Events
        private void dgvReports_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int iReportID = clsValidate.ValidateGridValue(dgvReports, "report_ID", e.RowIndex, 0);
                setEnableDisableConctrol(iReportID);
            }
        }

        private void dgvReports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvReports_CellClick(sender, e);
        }
        #endregion
    }
}